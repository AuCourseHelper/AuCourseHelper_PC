Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Module SocketProcess
    Public objFrmTeacher As frmTeacher
    Public serverIp As String = "192.192.122.203" '"127.0.0.1"
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
            Dim sendBytes As Byte() = Encoding.UTF8.GetBytes("PING;")
            clientSocket.Send(sendBytes)
            Dim dataLength = clientSocket.Receive(byteData)
            If dataLength <= 0 Then
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

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
                Case "BYE" ' 被server踢除
                    objFrmTeacher.uiLogout()
            End Select

            clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, New AsyncCallback(AddressOf OnRecieve), clientSocket)
        Catch ex As Exception
            
        End Try
    End Sub

    Public Function connectAndLogin(ByVal uid As String, ByVal pwd As String) As Boolean
        Dim ip As New IPEndPoint(Net.IPAddress.Parse(serverIp), 5566)
        clientSocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        Dim dataLength = 0

        Try
            clientSocket.Connect(ip)
            Dim sendBytes As Byte() = Encoding.UTF8.GetBytes(uid & ";" & pwd & ";T;")
            clientSocket.Send(sendBytes)

            ' Server回傳(Id;Name)或(loginFail)
            dataLength = clientSocket.Receive(byteData)
            Dim returns() = Encoding.UTF8.GetString(byteData, 0, dataLength).Split(";")

            If returns(0) = "loginFail" Then
                Return False
            End If

            isLogin = True
            myId = returns(0)
            myName = returns(1)
            objFrmTeacher.tslUserName.Text = myName & " 你好!"
            clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, New AsyncCallback(AddressOf OnRecieve), clientSocket)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Sub Logout()
        Try
            Dim sendBytes As Byte() = Encoding.UTF8.GetBytes("LOGOUT;")
            clientSocket.Send(sendBytes)
            Dim dataLength = clientSocket.Receive(byteData)
        Catch ex As Exception

        End Try
    End Sub

End Module
