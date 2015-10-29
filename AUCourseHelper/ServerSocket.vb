Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO

Module ServerSocket
    Public objFrmServer As frmServer
    Public isServerOn As Boolean = False
    Public clients As New List(Of Client)
    Private serverSocket As Socket
    Private byteData(8191) As Byte

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
            serverSocket.Listen(511) ' 最多提供512人同時連線
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
        Try
            For Each client In clients
                Dim sendBytes As Byte() = Encoding.UTF8.GetBytes("BYE;")
                client._socket.Send(sendBytes)
                log("強制踢除: " & client._ip & "-" & client._name, LogType_SYSTEM)
                client._socket.Shutdown(SocketShutdown.Both)
                client._socket.Close()
                objFrmServer.RemoveClient(client)
            Next
            serverSocket.Close()
            serverSocket = Nothing
            clients.Clear()
        Catch ex As Exception
            log("stopServer異常! " & ex.Message, LogType_ERROR)
        End Try
        'objFrmServer.RemoveAllClient()
        log("伺服器已關閉", LogType_NORMAL)
    End Sub

    Private Sub OnAccept(ByVal ar As IAsyncResult)
        Dim dataLength = 0
        Dim clientSocket As Socket

        Try
            clientSocket = serverSocket.EndAccept(ar)
            Dim clientIp = clientSocket.RemoteEndPoint.ToString.Split(":")(0)
            log(clientIp & ": 連線", LogType_NORMAL)

            ' 客戶端回傳: 帳號;密碼;使用者型態
            dataLength = clientSocket.Receive(byteData)
            Dim message = Encoding.UTF8.GetString(byteData, 0, dataLength)
            Dim returns() = message.Split(";")
            Dim clientUid = returns(0)
            Dim clientUserType = returns(2)

            ' 登入驗證(帳號,密碼,型態)，回傳"ID;姓名"，回傳空字串為登入失敗
            Dim loginStatus = login(returns(0), returns(1), returns(2))

            If loginStatus <> "" Then
                returns = loginStatus.Split(";")
                If checkIfLogined(returns(0), clientUserType) Then ' =====重複登入=====
                    log(clientIp & ": 帳號" & clientUid & "登入失敗", LogType_NORMAL)
                    ' 重複登入，回傳"RELOGIN"
                    Dim sendBytes_RE As Byte() = Encoding.UTF8.GetBytes("RELOGIN;")
                    clientSocket.Send(sendBytes_RE)
                    ' 關閉連線，結束此socket所有動作
                    clientSocket.Close()
                Else ' =====登入成功=====
                    ' 更新資料庫內登入紀錄
                    Dim loginTime = Format(Now, "yyyyMMdd-HHmmss")
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
                End If
            Else ' =====登入失敗=====
                log(clientIp & ": 帳號" & clientUid & "登入失敗", LogType_NORMAL)
                ' 回傳"loginFail"
                Dim sendBytes As Byte() = Encoding.UTF8.GetBytes("LOGINFAIL;")
                clientSocket.Send(sendBytes)
                ' 關閉連線，結束此socket所有動作
                clientSocket.Close()
            End If

            serverSocket.BeginAccept(New AsyncCallback(AddressOf OnAccept), Nothing)
        Catch ex As Exception
            If isServerOn Then
                log("伺服器接收連線建立異常! " & ex.Message, LogType_ERROR)
            Else
                serverSocket = Nothing
            End If
        End Try
    End Sub

    Private Sub OnRecieve(ByVal ar As IAsyncResult)
        Dim clientSocket As Socket = ar.AsyncState
        Try
            clientSocket.EndReceive(ar)
            ' 讀取對方要求
            Dim returnFunc = Encoding.UTF8.GetString(byteData).Split(";")(0)

            Select Case returnFunc
                Case "PING" ' 測試連線狀態
                    log(clientSocket.RemoteEndPoint.ToString & ": 要求測試連線PING", LogType_NORMAL)
                    Dim sendBytes As Byte() = Encoding.UTF8.GetBytes("PONG;")
                    clientSocket.Send(sendBytes)
                Case "LOGOUT" ' 登出
                    log(clientSocket.RemoteEndPoint.ToString & ": 要求LOGOUT", LogType_NORMAL)
                    Dim sendBytes As Byte() = Encoding.UTF8.GetBytes("BYE;")
                    clientSocket.Send(sendBytes)
                    Dim client = getClientInfo(clientSocket)
                    log(client._ip & ": " & client._name & "已登出", LogType_NORMAL)

                    objFrmServer.RemoveClient(client)
                    clientSocket.Shutdown(SocketShutdown.Both)
                    clientSocket.Close()
                    Exit Sub
                Case "DBQUERY"
                    log(clientSocket.RemoteEndPoint.ToString & ": 要求DBQUERY", LogType_NORMAL)
                    clientSocket.Receive(byteData)
                    Dim sql = Encoding.UTF8.GetString(byteData).Split(";")(0)
                    clientSocket.Send(Encoding.UTF8.GetBytes("DATATABLE;"))
                    Dim result = selectCmd(sql)
                    ' 序列化DataTable
                    Dim bf As New BinaryFormatter()
                    Dim ms As New MemoryStream
                    bf.Serialize(ms, result)
                    Dim ObjectBytes() = ms.ToArray()
                    clientSocket.Send(ObjectBytes)
            End Select

            If clientSocket.Connected Then
                clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, New AsyncCallback(AddressOf OnRecieve), clientSocket)
            End If
        Catch ex As Exception
            If isServerOn Then
                Dim client = getClientInfo(clientSocket)
                If client IsNot Nothing Then
                    log(client._ip & ": 接收資料異常! " & ex.Message, LogType_ERROR)
                    log(client._ip & ": 連線已斷開", LogType_NORMAL)
                    objFrmServer.RemoveClient(client)
                    clients.Remove(client)
                End If
                clientSocket.Close()
            Else
                clientSocket.Close()
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

    Public Function checkIfLogined(ByVal id As String, ByVal type As String) As Boolean
        For Each client In clients
            If client._id = id And client._type = type Then
                Return True
            End If
        Next
        Return False
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