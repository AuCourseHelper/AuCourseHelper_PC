Imports System.Net.Sockets
Imports Microsoft.Win32
Imports System.Threading
Imports System.Runtime.InteropServices
Imports System.Management
Imports System.Text

Public Class frmServer
    Public Shared version = "1.0.151110"
    Public Shared nowTerm = ""
    'Dim p As Process

    Private Sub frmServer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If isServerOn Then
            If clients.Count > 0 Then
                If MsgBox("目前仍有使用者連接中，是否確定關閉？", MsgBoxStyle.YesNo, "伺服器關閉確認") = MsgBoxResult.No Then
                    e.Cancel = True
                End If
            Else
                If MessageBox.Show("是否確定要關閉本系統", "關閉程式", MessageBoxButtons.YesNo) = DialogResult.No Then
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Else
            If MessageBox.Show("是否確定要關閉本系統", "關閉程式", MessageBoxButtons.YesNo) = DialogResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If

        stopServer()
        closeDb()
        log("====關閉系統====" & vbCrLf, LogType_SYSTEM)

        'Dim strKey As String
        'strKey = "HKCU\Software\Microsoft\Windows\CurrentVersion\Internet Settings"
        'With CreateObject("WScript.Shell")
        '    .RegWrite(strKey & "\ProxyEnable", 0, "REG_DWORD")
        'End With
        'p.Kill()
    End Sub

    Private Sub frmServer_Load(sender As Object, e As EventArgs) Handles Me.Load
        objFrmServer = Me
        log("====執行系統====", LogType_SYSTEM)
        log("==伺服端", LogType_SYSTEM)
        log("==版本號:" & version, LogType_SYSTEM)
        If GetRealIPaddress() <> GetIPaddress() Then
            tsmIp.Text = "區網IP: " & GetIPaddress() & " - 對外IP: " & GetRealIPaddress()
        Else
            tsmIp.Text = "IP: " & GetRealIPaddress()
        End If
        log("==" & tsmIp.Text, LogType_SYSTEM)
        Me.Text &= "(" & version & ")"

        If Now.Month > 8 Then
            nowTerm = (Now.Year - 1911) & "1"
        Else
            nowTerm = (Now.Year - 1911 - 1) & "2"
        End If

        lblTerm.Text = nowTerm
        tslSysTime.Text = Now
        lvTeacher.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        lvStudent.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

        openDb()
        mnuStart.PerformClick()
        'p = System.Diagnostics.Process.Start(Application.StartupPath & "\KCProxy.exe")
        'Dim strKey As String
        'strKey = "HKCU\Software\Microsoft\Windows\CurrentVersion\Internet Settings"
        'With CreateObject("WScript.Shell")
        '    .RegWrite(strKey & "\ProxyEnable", 1, "REG_DWORD")
        '    .RegWrite(strKey & "\ProxyServer", "127.0.0.1:8889", "REG_SZ")
        'End With

        'auSysLogin("AM001871", "a0tim82326")
        'auSysGetCourseStudents("104", "1")
        'auSysGetAllGrade()
        'auSysGetTimetable("103", "2")
    End Sub

    Private Sub tmrSysTime_Tick(sender As Object, e As EventArgs) Handles tmrSysTime.Tick
        tslSysTime.Text = Now

        ' 早上零點更新Log檔名
        If Now.Hour = 0 And Now.Minute = 0 And Now.Second = 0 Then
            logFilePath = Application.StartupPath & "\logs\log-server-" & Format(Now, "yyyyMMdd") & ".txt"
        End If

        ' 早上五點定時排程，重開伺服器
        If Now.Hour = 5 And Now.Minute = 0 And Now.Second = 0 Then
            log("==執行系統排程，重啟伺服器", LogType_SYSTEM)
            ' 重開server，藉此排除登入狀態卡死導致使用者無法再登入
            stopServer()
            Thread.Sleep(1000)
            startServer()
        End If

        ' 每10分鐘踢除閒置超過10分鐘的連線
        If (Now.Minute Mod 10) = 0 And Now.Second = 0 And (Now.Hour <> 5 And Now.Minute <> 0) Then
            log("==執行系統排程，踢除閒置10分鐘連線", LogType_SYSTEM)
            For i As Integer = 0 To clients.Count - 1
                Dim client = clients.ElementAt(i)
                If Now.Subtract(client._eventTime).Minutes >= 10 Then
                    log("踢除閒置連線: " & client._ip & client._name, LogType_NORMAL)
                    client._socket.Close()
                    RemoveClient(client)
                    clients.Remove(client)
                Else
                    i += 1
                End If
            Next
        End If
    End Sub

    Private Sub tsmExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        Application.Exit()
    End Sub

    Private Sub mnuStart_Click(sender As Object, e As EventArgs) Handles mnuStart.Click
        If GetRealIPaddress() <> GetIPaddress() Then
            MsgBox("您可能位於路由器底下" & vbCrLf _
                   & "請將路由器Port:5566" & vbCrLf _
                   & "對應到目前IP:" & GetIPaddress() & vbCrLf _
                   & "否則將造成教師與學生無法連線!!!" _
                   , MsgBoxStyle.OkOnly, "對外IP與目前網卡IP不相同！")
            tsmIp.Text = "區網IP: " & GetIPaddress() & " - 對外IP: " & GetRealIPaddress()
        End If
        If startServer() Then
            tlpMain.Enabled = True
            mnuStart.Enabled = False
            mnuStop.Enabled = True
            tslOnlineCount.Text = "伺服器：開啟  人數：0人"
            btnEditTerm.Enabled = False
        End If
    End Sub

    Private Sub mnuStop_Click(sender As Object, e As EventArgs) Handles mnuStop.Click
        If clients.Count > 0 Then
            If MsgBox("目前仍有使用者連接中，是否確定關閉？", MsgBoxStyle.YesNo, "伺服器關閉確認") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        stopServer()
        tlpMain.Enabled = False
        mnuStart.Enabled = True
        mnuStop.Enabled = False
        tslOnlineCount.Text = "伺服器：關閉  人數：0人"
        btnEditTerm.Enabled = True
    End Sub

    Private Sub tsmReport_DropDownOpened(sender As Object, e As EventArgs) Handles tsmReport.DropDownOpened
        Dim logs() = getHistoryLogList()
        mnuViewHistory.DropDownItems.Clear()
        Dim logCount As Integer = 0
        For Each logPath In logs
            Dim logFileName = logPath.Substring(logPath.LastIndexOf("\") + 1)
            mnuViewHistory.DropDownItems.Add(logFileName)
            mnuViewHistory.DropDownItems.Item(logCount).Tag = logPath
            AddHandler mnuViewHistory.DropDownItems.Item(logCount).Click, AddressOf historyLog_View
            logCount += 1
        Next
    End Sub

    Public Sub historyLog_View(sender As Object, e As EventArgs)
        Dim historyLog As ToolStripDropDownItem = sender
        log("檢視歷史紀錄: " & historyLog.Text, LogType_SYSTEM)
        Dim filePath As String = historyLog.Tag
        System.Diagnostics.Process.Start(filePath)
    End Sub

    Private Sub mnuViewLog_Click(sender As Object, e As EventArgs) Handles mnuViewLog.Click
        log("檢視執行紀錄", LogType_SYSTEM)
        Dim frmLog As New Form
        Dim txtLog As New RichTextBox()
        txtLog.Text = logData
        txtLog.ReadOnly = True
        txtLog.ScrollBars = RichTextBoxScrollBars.Both
        txtLog.Dock = DockStyle.Fill
        frmLog.Text = Me.Text & " | 程式執行紀錄"
        frmLog.Size = New Size(400, 500)
        frmLog.Controls.Add(txtLog)
        frmLog.ShowDialog()
    End Sub

    Delegate Sub _AddClient(ByVal client As Client)
    Public Sub AddClient(ByVal client As Client)
        If InvokeRequired Then
            Invoke(New _AddClient(AddressOf AddClient), client)
            Exit Sub
        End If

        Dim item As New ListViewItem(client._ip)
        item.SubItems.Add(client._name)
        item.SubItems.Add(client._loginTime)
        item.Tag = client

        If client._type = "T" Then
            lvTeacher.Items.Add(item)
            lvTeacher.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        Else
            lvStudent.Items.Add(item)
            lvStudent.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        End If

        tslOnlineCount.Text = "伺服器：開啟  人數：" & clients.Count & "人"
    End Sub

    Delegate Sub _RemoveClient(ByVal client As Client)
    Public Sub RemoveClient(ByVal client As Client)
        If InvokeRequired Then
            Invoke(New _RemoveClient(AddressOf RemoveClient), client)
            Exit Sub
        End If

        ' 更新資料庫內登入紀錄
        If client._type = "T" Then
            exeCmd(String.Format("UPDATE Teacher SET LastLogin='{0}',LastIp='{1}' WHERE Id='{2}'", client._loginTime, client._ip, client._id))
        Else
            exeCmd(String.Format("UPDATE Student SET LastLogin='{0}',LastIp='{1}' WHERE Id='{2}'", client._loginTime, client._ip, client._id))
        End If

        For Each item In lvTeacher.Items
            If item.tag.Equals(client) Then
                lvTeacher.Items.Remove(item)
            End If
        Next
        For Each item In lvStudent.Items
            If item.tag.Equals(client) Then
                lvStudent.Items.Remove(item)
            End If
        Next
        tslOnlineCount.Text = "伺服器：開啟  人數：" & clients.Count - 1 & "人"
    End Sub

    Private Sub mnuKickClient_Click(sender As Object, e As EventArgs) Handles mnuKickClient.Click
        If lvTeacher.Focused Then
            Dim client As Client = lvTeacher.SelectedItems(0).Tag
            log("踢除教師: " & client._ip & "-" & client._name, LogType_SYSTEM)
            Dim sendBytes As Byte() = Encoding.UTF8.GetBytes("BYE;")
            client._socket.Send(sendBytes)
            RemoveClient(client)
            clients.Remove(client)
        Else
            Dim client As Client = lvStudent.SelectedItems(0).Tag
            log("踢除學生: " & client._ip & "-" & client._name, LogType_SYSTEM)
            Dim sendBytes As Byte() = Encoding.UTF8.GetBytes("BYE;")
            client._socket.Send(sendBytes)
            RemoveClient(client)
            clients.Remove(client)
        End If
    End Sub

    Private Sub lvTeacher_MouseClick(sender As Object, e As MouseEventArgs) Handles lvTeacher.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If lvTeacher.GetItemAt(e.X, e.Y) IsNot Nothing Then
                lvTeacher.GetItemAt(e.X, e.Y).Selected = True
                cmuRMenu.Show(lvTeacher, New Point(e.X, e.Y))
            End If
        End If
    End Sub

    Private Sub lvStudent_MouseClick(sender As Object, e As MouseEventArgs) Handles lvStudent.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If lvStudent.GetItemAt(e.X, e.Y) IsNot Nothing Then
                lvStudent.GetItemAt(e.X, e.Y).Selected = True
                cmuRMenu.Show(lvStudent, New Point(e.X, e.Y))
            End If
        End If
    End Sub

    Delegate Sub _UpdateLog(ByVal logText As String, ByVal logType As Integer)
    Public Sub UpdateLog(ByVal logText As String, ByVal logType As Integer)
        If InvokeRequired Then
            Invoke(New _UpdateLog(AddressOf UpdateLog), logText, logType)
            Exit Sub
        End If

        Select Case logType
            Case LogType_NORMAL
                tslStatus.BackColor = System.Drawing.SystemColors.GrayText
                tslStatus.Text = logText
                logText = Format(Now, "yyyyMMdd-HHmmss:") & vbTab & "O  " & logText & vbCrLf
            Case LogType_ERROR
                tslStatus.BackColor = Color.Red
                tslStatus.Text = logText
                logText = Format(Now, "yyyyMMdd-HHmmss:") & vbTab & "X  " & logText & vbCrLf
            Case LogType_SYSTEM
                tslStatus.BackColor = System.Drawing.SystemColors.GrayText
                tslStatus.Text = logText
                logText = Format(Now, "yyyyMMdd-HHmmss:") & vbTab & logText & vbCrLf
        End Select
        logData &= logText
        saveLog(logText)
    End Sub

    Private Sub btnEditTerm_Click(sender As Object, e As EventArgs) Handles btnEditTerm.Click

    End Sub
End Class