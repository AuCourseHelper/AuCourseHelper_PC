Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Module ClientSocket
    Private clientSocket As Socket
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

    Public Function connectAndLogin(ByVal uid As String, ByVal pwd As String) As Boolean
        Dim serverIp As New IPEndPoint(Net.IPAddress.Parse("127.0.0.1"), 5566)
        clientSocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

        Try
            clientSocket.Connect(serverIp)
            Dim sendBytes As Byte() = Encoding.UTF8.GetBytes(uid & ";" & pwd & ";T;")
            clientSocket.Send(sendBytes)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return True
    End Function

End Module
