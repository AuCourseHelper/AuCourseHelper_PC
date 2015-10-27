Imports System.Net.Sockets
Imports System.Net
Imports System.Text

Public Class frmStudent
    Dim clientSocket As Socket

    Private Sub frmStudent_Load(sender As Object, e As EventArgs) Handles Me.Load
        clientSocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        Dim ipAddress As IPAddress = ipAddress.Parse("192.192.122.202")
        Dim ipEndPoint As IPEndPoint = New IPEndPoint(ipAddress, 5566)
        clientSocket.BeginConnect(ipEndPoint, New AsyncCallback(AddressOf OnConnect), Nothing)
    End Sub

    Private Sub OnConnect(ByVal ar As IAsyncResult)
        clientSocket.EndConnect(ar)
        Dim sendBytes As Byte() = Encoding.UTF8.GetBytes(GetIPaddress() & ";AM001871;a82326")
        clientSocket.Send(sendBytes)
        Dim getBytes(2047) As Byte
        clientSocket.Receive(getBytes)
        Dim message = Encoding.UTF8.GetString(getBytes, 0, getBytes.Length)
        MsgBox(message)
    End Sub

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
End Class
