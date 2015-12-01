Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO

Module SocketProcess
    Private byteData(8191) As Byte
    Private pong As Boolean = False
    Private isLogoutIng As Boolean = False
    Private resultDataTable As DataTable = Nothing

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
        Try
            clientSocket.EndReceive(ar)
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
                    myProfile = New TeacherProfile
                    myCourses = New DataTable
                    nowCourse = Nothing
                    Exit Sub
                Case "DATATABLE" ' 承接回傳的DB查詢
                    Try
                        clientSocket.Receive(byteData)
                        Dim size = Encoding.UTF8.GetString(byteData).Split(";")(0)
                        Dim i = clientSocket.Receive(byteData)
                        byteData.Initialize()
                        ' 反序列化DataTable
                        Dim bf As New BinaryFormatter()
                        Dim ms As New MemoryStream(CInt(size))
                        ms.Write(byteData, 0, i)
                        ms.Flush()
                        Thread.Sleep(200)
                        While i = 8192
                            i = clientSocket.Receive(byteData)
                            byteData.Initialize()
                            If i > 0 Then
                                ms.Write(byteData, 0, i)
                                ms.Flush()
                                Thread.Sleep(200)
                            End If
                        End While
                        ms.Seek(0, SeekOrigin.Begin)
                        resultDataTable = bf.Deserialize(ms)
                    Catch ex As Exception
                        resultDataTable = New DataTable
                        isDeserializeFail = True
                        log("接收DB回傳資料異常! " & ex.Message, LogType_ERROR)
                    End Try
                Case "DBCMDRESULT" ' 判斷資料庫命令執行狀態
                    clientSocket.Receive(byteData)
                    resultDbCmd = Encoding.UTF8.GetString(byteData)
            End Select

            clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, New AsyncCallback(AddressOf OnRecieve), clientSocket)
        Catch ex As Exception
            log("接收資料異常! " & ex.Message, LogType_ERROR)
            Exit Sub
        End Try
    End Sub

    Public Function connectAndLogin(ByVal uid As String, ByVal pwd As String) As String
        Try
            Dim ip As New IPEndPoint(Net.IPAddress.Parse(serverIp), 5566)
            clientSocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            Dim dataLength = 0
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
            myProfile.Id = returns(0)
            myProfile.Name = returns(1)
            log("帳號" & uid & " " & myProfile.Name & "登入成功", LogType_NORMAL)

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
        Dim tryCount = 0
        Try
RE:         resultDataTable = Nothing
            isDeserializeFail = False
            clientSocket.Send(Encoding.UTF8.GetBytes("DBQUERY;"))
            clientSocket.Send(Encoding.UTF8.GetBytes(sql))
            While resultDataTable Is Nothing
                Thread.Sleep(100)
            End While
            If isDeserializeFail Then
                If tryCount < RETRYTIMES Then
                    log("重新傳送DBQUERY", LogType_NORMAL)
                    tryCount += 1
                    GoTo RE
                Else
                    log("傳送DBQUERY出錯3次，斷線處理!!", LogType_ERROR)
                    logout()
                End If
            End If
        Catch ex As Exception
            log("傳送DBQUERY出錯: " & ex.Message, LogType_ERROR)
            If tryCount < RETRYTIMES Then
                log("重新傳送DBQUERY: " & ex.Message, LogType_NORMAL)
                tryCount += 1
                GoTo RE
            Else
                log("傳送DBQUERY出錯3次，斷線處理!!", LogType_ERROR)
                logout()
            End If
        End Try

        Return resultDataTable
    End Function

    Public Function doSqlCmd(ByVal sql As String) As Boolean
        Try
            resultDbCmd = ""
            clientSocket.Send(Encoding.UTF8.GetBytes("DBCMD;"))
            clientSocket.Send(Encoding.UTF8.GetBytes(sql))
            While resultDbCmd = ""
                Thread.Sleep(200)
            End While
            If resultDbCmd.StartsWith("FAIL") Then
                log("執行DBCMD出錯: " & resultDbCmd.Split(";")(1), LogType_ERROR)
                Return False
            End If
        Catch ex As Exception
            log("傳送DBCMD出錯: " & ex.Message, LogType_ERROR)
        End Try

        Return True
    End Function

End Module

Public Class TeacherProfile
    Property Id As String
    Property Num As String
    Property Name As String
    Property Pwd As String
    Property LastLogin As String
    Property LastIp As String
    Property WebSite As String
    Property OfficeTime As String
End Class