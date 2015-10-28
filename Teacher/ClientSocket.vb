Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Module SocketProcess
    Public objFrmTeacher As frmTeacher
    Public serverIp As String = "192.192.122.202"
    Public clientSocket As Socket
    Private byteData(2047) As Byte
    Public isLogin As Boolean = False
    Public myId As String
    Public myName As String
    Public myUid As String
    Public myPwd As String

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

    Public Function connectStatusTest() As Boolean
        Try
            log("送出PING", LogType_NORMAL)
            Dim sendBytes As Byte() = Encoding.UTF8.GetBytes("PING;")
            log("接收PONG", LogType_NORMAL)
            clientSocket.Send(sendBytes)
            clientSocket.Shutdown(SocketShutdown.Receive)

            Dim dataLength = clientSocket.Receive(byteData)
            log("接到了" & dataLength & "個byte", LogType_NORMAL)
            clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, New AsyncCallback(AddressOf OnRecieve), clientSocket)
            If dataLength <= 0 Then
                log("接到長度<0", LogType_NORMAL)
                Return False
            End If
        Catch ex As Exception
            log("傳接PINGPONG出錯", LogType_NORMAL)
            clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, New AsyncCallback(AddressOf OnRecieve), clientSocket)
            Return False
        End Try
        Return True
    End Function

    Private Sub OnRecieve(ByVal ar As IAsyncResult)
        Dim clientSocket As Socket = ar.AsyncState
        Try
            clientSocket.EndReceive(ar)
            log("讀取訊息", LogType_NORMAL)
            ' 讀取對方要求
            Dim returnFunc = Encoding.UTF8.GetString(byteData).Split(";")(0)

            Select Case returnFunc
                Case "PING" ' 測試連線狀態
                    log("對方測試PING", LogType_NORMAL)
                    Dim sendBytes As Byte() = Encoding.UTF8.GetBytes("PONG;")
                    log("我方回傳PONG", LogType_NORMAL)
                    clientSocket.Send(sendBytes)
                Case "BYE" ' 被server踢除
                    log("對方叫我BYE", LogType_NORMAL)
                    objFrmTeacher.uiLogout()
            End Select

            log("開啟再次聆聽", LogType_NORMAL)
            clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, New AsyncCallback(AddressOf OnRecieve), clientSocket)
        Catch ex As Exception
            
        End Try
    End Sub

    Public Function connectAndLogin(ByVal uid As String, ByVal pwd As String) As String
        Dim ip As New IPEndPoint(Net.IPAddress.Parse(serverIp), 5566)
        clientSocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        Dim dataLength = 0

        Try
            clientSocket.ReceiveTimeout = 5000
            clientSocket.SendTimeout = 5000
            clientSocket.ReceiveBufferSize = 2048
            clientSocket.SendBufferSize = 2048
            clientSocket.BeginConnect(ip)
            log("連線伺服器", LogType_NORMAL)
            'MsgBox(clientSocket.ReceiveTimeout)

            Dim sendBytes As Byte() = Encoding.UTF8.GetBytes(uid & ";" & pwd & ";T;")
            clientSocket.Send(sendBytes)
            log("送出登入資訊", LogType_NORMAL)

            ' Server回傳(Id;Name)或(loginFail)
            dataLength = clientSocket.Receive(byteData)
            log("伺服器回傳登入狀態", LogType_NORMAL)
            Dim returns() = Encoding.UTF8.GetString(byteData, 0, dataLength).Split(";")

            If returns(0) = "loginFail" Then
                log("登入失敗", LogType_NORMAL)
                Return "FAIL"
            End If

            isLogin = True
            myId = returns(0)
            myName = returns(1)

            log("開啟聆聽", LogType_NORMAL)
            clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, New AsyncCallback(AddressOf OnRecieve), clientSocket)
        Catch ex As Exception
            Return "TIMEOUT"
        End Try
        Return "SUCCESS"
    End Function

    Public Sub logout()
        Try
            Dim sendBytes As Byte() = Encoding.UTF8.GetBytes("LOGOUT;")
            log("傳送LOGOUT", LogType_NORMAL)
            clientSocket.Send(sendBytes)
        Catch ex As Exception

        End Try
    End Sub

End Module
