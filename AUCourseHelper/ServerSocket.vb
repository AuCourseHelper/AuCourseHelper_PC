Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Module ServerSocket
    Public objFrmServer As frmServer
    Public isServerOn As Boolean = False
    Public clients As New List(Of Client)
    Private serverSocket As Socket
    Private byteData(2047) As Byte

    Public Function GetIPaddress() As String
        Dim myHost As String = System.Net.Dns.GetHostName
        Dim myIPs As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(myHost)
        For Each ipAddress As System.Net.IPAddress In myIPs.AddressList
            If ipAddress.ToString.ElementAt(3) = "." Then
                Return ipAddress.ToString()
            End If
        Next
        Return "Get Ip Fail"
    End Function

    Public Function GetRealIPaddress() As String
        Dim wc As New WebClient
        Dim html = wc.DownloadString("http://whereismyip.com/")
        Dim nStart = html.IndexOf("""verdana"">") + 10
        Dim nStop = html.IndexOf("</font></b>")
        Return html.Substring(nStart, nStop - nStart)
    End Function

    Public Function startServer() As Boolean
        Try
            serverSocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            Dim IpEndPoint As IPEndPoint = New IPEndPoint(IPAddress.Any, 5566)
            serverSocket.Bind(IpEndPoint)
            serverSocket.Listen(511)
            serverSocket.BeginAccept(New AsyncCallback(AddressOf OnAccept), Nothing)
        Catch ex As Exception
            log("伺服器啟動失敗! " & ex.Message, LogType_ERROR)
            Return False
        End Try
        isServerOn = True
        log("伺服器已啟動", LogType_NORMAL)
        Return True
    End Function

    Public Sub stopServer()
        isServerOn = False
        serverSocket.Close()
        serverSocket = Nothing
        clients.Clear()
        objFrmServer.RemoveAllClient()
        log("伺服器已關閉", LogType_NORMAL)
    End Sub

    Private Sub OnAccept(ByVal ar As IAsyncResult)
        Dim dataLength = 0
        Dim clientSocket As Socket

        Try
            clientSocket = serverSocket.EndAccept(ar)
            dataLength = clientSocket.Receive(byteData)

            ' 客戶端回傳: 帳號;密碼;使用者型態
            Dim message = Encoding.UTF8.GetString(byteData, 0, dataLength)
            Dim returns() = message.Split(";")
            Dim clientIp = clientSocket.RemoteEndPoint.ToString.Split(":")(0)
            Dim clientUid = returns(0)
            Dim clientUserType = returns(2)

            ' 登入驗證(帳號,密碼,型態)，回傳"ID;姓名"，回傳空字串為登入失敗
            Dim loginStatus = login(returns(0), returns(1), returns(2))

            If loginStatus <> "" Then ' 登入成功
                returns = loginStatus.Split(";")
                Dim loginTime = Format(Now, "yyyyMMdd-HHmmss")

                ' 更新資料庫內登入紀錄
                If clientUserType = "T" Then
                    exeCmd(String.Format("UPDATE Teacher SET LastLogin='{0}',LastIp='{1}' WHERE Id='{2}'", loginTime, clientIp, returns(0)))
                Else
                    exeCmd(String.Format("UPDATE Student SET LastLogin='{0}',LastIp='{1}' WHERE Id='{2}'", loginTime, clientIp, returns(0)))
                End If

                ' 回傳(ID;姓名)
                Dim sendBytes As Byte() = Encoding.UTF8.GetBytes(returns(0) & ";" & returns(1))
                clientSocket.Send(sendBytes)

                ' 加入資料到視窗畫面，開始監聽
                Dim client As New Client(clientSocket, clientIp, returns(0), returns(1), clientUserType, loginTime)
                clients.Add(client)
                objFrmServer.AddClient(client)
                clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, New AsyncCallback(AddressOf OnRecieve), clientSocket)
                log(clientIp & ": " & returns(1) & "登入成功", LogType_NORMAL)

            Else ' 登入失敗
                log(clientIp & ": 帳號" & clientUid & "登入失敗", LogType_NORMAL)
                ' 回傳"loginFail"
                Dim sendBytes As Byte() = Encoding.UTF8.GetBytes("loginFail;")
                clientSocket.Send(sendBytes)
                ' 關閉連線，結束此socket所有動作
                clientSocket.Close()
            End If
        Catch ex As Exception
            If isServerOn Then
                log("伺服器接收連線建立異常! " & ex.Message, LogType_ERROR)
            Else
                serverSocket = Nothing
            End If
        End Try

        serverSocket.BeginAccept(New AsyncCallback(AddressOf OnAccept), Nothing)
    End Sub

    Private Sub OnRecieve(ByVal ar As IAsyncResult)
        Dim clientSocket As Socket = ar.AsyncState
        Try
            clientSocket.EndReceive(ar)
            ' 讀取對方要求
            Dim returnFunc = Encoding.UTF8.GetString(byteData).Split(";")(0)

            Select Case returnFunc
                Case "PING" ' 測試連線狀態
                    Dim sendBytes As Byte() = Encoding.UTF8.GetBytes("PONG;")
                    clientSocket.Send(sendBytes)
                Case "LOGOUT" ' 登出
                    MsgBox("LOGOUT")
                    Dim sendBytes As Byte() = Encoding.UTF8.GetBytes("BYE;")
                    clientSocket.Send(sendBytes)
                    Dim client = getClientInfo(clientSocket)
                    log(client._ip & ": " & client._name & "已登出", LogType_NORMAL)
                    objFrmServer.RemoveClient(client)
                    clientSocket.Close()
                    clientSocket.Dispose()
                    Exit Sub
            End Select

            clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, New AsyncCallback(AddressOf OnRecieve), clientSocket)
        Catch ex As Exception
            If isServerOn Then
                Dim client = getClientInfo(clientSocket)
                objFrmServer.RemoveClient(client)
                clientSocket.Close()
                clientSocket.Dispose()
                log(client._ip & ": 接收資料異常! " & ex.Message, LogType_ERROR)
                log(client._ip & ": 連線已斷開", LogType_NORMAL)
            Else
                clientSocket.Dispose()
            End If
        End Try
    End Sub

    Public Function getClientInfo(ByVal clientSocket As Socket) As Client
        For Each client In clients
            If client._socket.Equals(clientSocket) Then
                Return client
            End If
        Next
        Return Nothing
    End Function

End Module

Public Class Client
    Property _socket As Socket
    Property _ip As String
    Property _id As String
    Property _name As String
    Property _type As String
    Property _loginTime As String

    Public Sub New(ByVal socket As Socket, ByVal ip As String, ByVal id As String, ByVal name As String, ByVal type As String, ByVal loginTime As String)
        _socket = socket
        _ip = ip
        _id = id
        _name = name
        _type = type
        _loginTime = loginTime
    End Sub
End Class