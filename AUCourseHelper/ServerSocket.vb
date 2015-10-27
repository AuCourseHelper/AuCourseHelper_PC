Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Module ServerSocket
    Public isServerOn As Boolean = False
    Private serverSocket As Socket
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
        log("伺服器已關閉", LogType_NORMAL)
    End Sub

    Private Sub OnAccept(ByVal ar As IAsyncResult)
        Try
            clientSocket = serverSocket.EndAccept(ar)
            serverSocket.BeginAccept(New AsyncCallback(AddressOf OnAccept), Nothing)
            clientSocket.Receive(byteData)

            ' 客戶端回傳: IP;帳號;密碼;使用者型態
            Dim message = Encoding.UTF8.GetString(byteData, 0, byteData.Length)
            Dim returns() = message.Split(";")
            Dim clientIp = clientSocket.RemoteEndPoint.ToString
            Dim clientUserType = returns(3)

            ' 登入驗證(帳號,密碼,型態)，回傳"ID;姓名"，回傳空字串為登入失敗
            Dim loginStatus = login(returns(1), returns(2), returns(3))

            If loginStatus <> "" Then ' 登入成功
                returns = loginStatus.Split(";")

                ' 更新資料庫內登入紀錄
                If clientUserType = "T" Then
                    exeCmd(String.Format("UPDATE Teacher SET LastLogin='{0}',LastIp='{1}' WHERE Id='{2}'", Format(Now, "yyyyMMdd-HHmm"), clientIp, returns(0)))
                Else
                    exeCmd(String.Format("UPDATE Student SET LastLogin='{0}',LastIp='{1}' WHERE Id='{2}'", Format(Now, "yyyyMMdd-HHmm"), clientIp, returns(0)))
                End If

                ' 回傳"welcome;IP;ID;姓名"
                Dim sendBytes As Byte() = Encoding.UTF8.GetBytes("welcome;" & clientIp & ";" & returns(0) & ";" & returns(1))
                clientSocket.Send(sendBytes)
                'AddClient(clientSocket)
                log(clientIp & ": " & returns(1) & "登入成功", LogType_NORMAL)

            Else ' 登入失敗
                log(clientIp & ": " & returns(1) & "登入失敗", LogType_NORMAL)
                ' 回傳"loginFail"
                Dim sendBytes As Byte() = Encoding.UTF8.GetBytes("loginFail")
                clientSocket.Send(sendBytes)
                ' 關閉連線，結束此socket所有動作
                clientSocket.Close()
            End If
        Catch ex As Exception
            If isServerOn Then
                log("伺服器接收連線建立異常! " & ex.Message, LogType_ERROR)
            End If
        End Try
    End Sub

End Module
