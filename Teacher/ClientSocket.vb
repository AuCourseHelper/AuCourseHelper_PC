Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO

Module SocketProcess
    Public objFrmTeacher As frmTeacher
    Public serverIp As String = "127.0.0.1"
    Public clientSocket As Socket
    Private byteData(8191) As Byte
    Private pong As Boolean = False
    Private isLogoutIng As Boolean = False
    Private resultDataTable As New DataTable
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
            pong = False

            Dim sendBytes As Byte() = Encoding.UTF8.GetBytes("PING;")
            clientSocket.Send(sendBytes)
            Thread.Sleep("500")

        Catch ex As Exception
            log("傳送PING出錯: " & ex.Message, LogType_ERROR)
        End Try
        Return pong
    End Function

    Private Sub OnRecieve(ByVal ar As IAsyncResult)
        Dim clientSocket As Socket = ar.AsyncState
        clientSocket.EndReceive(ar)
        Try
            ' 讀取對方要求
            Dim returnFunc = Encoding.UTF8.GetString(byteData).Split(";")(0)

            Select Case returnFunc
                Case "PING" ' 測試連線狀態
                    Dim sendBytes As Byte() = Encoding.UTF8.GetBytes("PONG;")
                    clientSocket.Send(sendBytes)
                Case "PONG" ' server回傳我方PING要求
                    pong = True
                Case "BYE" ' 被server踢除(被踢或自己登出)
                    If isLogoutIng Then
                        objFrmTeacher.uiLogout("LOGOUT")
                    Else
                        objFrmTeacher.uiLogout("BREAK")
                    End If
                    isLogin = False
                    isLogoutIng = False
                    clientSocket.Close()
                    Exit Sub
                Case "DATATABLE" ' 承接回傳的DB查詢
                    Dim i = clientSocket.Receive(byteData)
                    ' 反序列化DataTable
                    Dim bf As New BinaryFormatter()
                    Dim ms As New MemoryStream()
                    ms.Write(byteData, 0, i)
                    If i = 8192 Then
                        While True
                            i = clientSocket.Receive(byteData)
                            ms.Write(byteData, 0, i)
                            If i < 8192 Then
                                Exit While
                            End If
                        End While
                    End If
                    Dim s = ""
                    For Each b In ms.ToArray
                        s &= b & " "
                    Next
                    MsgBox(s)
                    resultDataTable = CType(bf.Deserialize(ms), DataTable)
            End Select

            clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, New AsyncCallback(AddressOf OnRecieve), clientSocket)
        Catch ex As Exception
            log("接收資料異常! " & ex.Message, LogType_ERROR)
            Exit Sub
        End Try
    End Sub

    Public Function connectAndLogin(ByVal uid As String, ByVal pwd As String) As String
        Dim ip As New IPEndPoint(Net.IPAddress.Parse(serverIp), 5566)
        clientSocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        Dim dataLength = 0

        Try
            clientSocket.ReceiveTimeout = 7000
            clientSocket.SendTimeout = 7000
            clientSocket.Connect(ip)
            log("與伺服器取得連線: " & ip.ToString, LogType_NORMAL)

            Dim sendBytes As Byte() = Encoding.UTF8.GetBytes(uid & ";" & pwd & ";T;")
            clientSocket.Send(sendBytes)
            log("送出" & uid & "帳號登入要求", LogType_NORMAL)

            ' Server回傳(Id;Name)或(loginFail)
            dataLength = clientSocket.Receive(byteData)
            Dim returns() = Encoding.UTF8.GetString(byteData, 0, dataLength).Split(";")

            If returns(0) = "LOGINFAIL" Then
                log("帳號" & uid & "登入失敗", LogType_ERROR)
                Return "FAIL"
            End If

            If returns(0) = "RELOGIN" Then
                log("帳號" & uid & "重複登入", LogType_ERROR)
                Return "RELOGIN"
            End If

            isLogin = True
            myId = returns(0)
            myName = returns(1)
            log("帳號" & uid & " " & myName & "登入成功", LogType_NORMAL)

            clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, New AsyncCallback(AddressOf OnRecieve), clientSocket)
        Catch ex As Exception
            Return "TIMEOUT"
        End Try

        Return "SUCCESS"
    End Function

    Public Sub logout()
        Try
            isLogoutIng = True
            Dim sendBytes As Byte() = Encoding.UTF8.GetBytes("LOGOUT;")
            log("傳送LOGOUT", LogType_NORMAL)
            clientSocket.Send(sendBytes)
        Catch ex As Exception
            isLogoutIng = False
            log("登出時錯誤: " & ex.Message, LogType_ERROR)
        End Try
    End Sub

    Public Function doSqlQuery(ByVal sql As String) As DataTable
        Try
            clientSocket.Send(Encoding.UTF8.GetBytes("DBQUERY;"))
            clientSocket.Send(Encoding.UTF8.GetBytes(sql))
            While resultDataTable IsNot Nothing
                Thread.Sleep(200)
            End While
        Catch ex As Exception
            log("傳送DBQUERY出錯: " & ex.Message, LogType_ERROR)
        End Try

        Return resultDataTable
    End Function

End Module
