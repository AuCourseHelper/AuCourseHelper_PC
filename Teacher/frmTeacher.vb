Public Class frmTeacher
    Public version = "1.0.151027"

    Private Sub frmTeacher_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("是否確定要關閉本系統", "關閉程式", MessageBoxButtons.YesNo) = DialogResult.No Then
            e.Cancel = True
            Exit Sub
        End If
        log("====關閉系統====" & vbCrLf, LogType_SYSTEM)
    End Sub

    Private Sub frmTeacher_Load(sender As Object, e As EventArgs) Handles Me.Load
        objFrmTeacher = Me
        log("====執行系統====", LogType_SYSTEM)
        log("==教師端", LogType_SYSTEM)
        log("==版本號:" & version, LogType_SYSTEM)
        If GetRealIPaddress() <> GetIPaddress() Then
            tsmIp.Text = "區網IP: " & GetIPaddress() & " - 對外IP: " & GetRealIPaddress()
        Else
            tsmIp.Text = "IP: " & GetRealIPaddress()
        End If
        log("==" & tsmIp.Text, LogType_SYSTEM)
        tslSysTime.Text = Now
    End Sub

    Private Sub tmrSysTime_Tick(sender As Object, e As EventArgs) Handles tmrSysTime.Tick
        tslSysTime.Text = Now
    End Sub

    Private Sub mnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        Application.Exit()
    End Sub

    Private Sub tsmLog_DropDownOpened(sender As Object, e As EventArgs) Handles tsmLog.DropDownOpened
        Dim logs() = getHistoryLogList()
        mnuViewHistory.DropDownItems.Clear()
        Dim logCount As Integer = 0
        For Each logFilePath In logs
            Dim logFileName = logFilePath.Substring(logFilePath.LastIndexOf("\") + 1)
            mnuViewHistory.DropDownItems.Add(logFileName)
            mnuViewHistory.DropDownItems.Item(logCount).Tag = logFilePath
            AddHandler mnuViewHistory.DropDownItems.Item(logCount).Click, AddressOf historyLog_View
            logCount += 1
        Next
    End Sub

    Public Sub historyLog_View(sender As Object, e As EventArgs)
        Dim historyLog As ToolStripDropDownItem = sender
        Dim filePath As String = historyLog.Tag
        System.Diagnostics.Process.Start(filePath)
    End Sub

    Private Sub mnuViewLog_Click(sender As Object, e As EventArgs) Handles mnuViewLog.Click
        Dim frmLog As New Form
        Dim log As New RichTextBox()
        log.Text = logData
        log.ReadOnly = True
        log.ScrollBars = RichTextBoxScrollBars.Both
        log.Dock = DockStyle.Fill
        frmLog.Text = Me.Text & " | 程式執行紀錄"
        frmLog.Size = New Size(400, 500)
        frmLog.Controls.Add(log)
        frmLog.StartPosition = FormStartPosition.CenterParent
        frmLog.ShowDialog(Me)
    End Sub

    Private Sub mnuLogin_Click(sender As Object, e As EventArgs) Handles mnuLogin.Click
        log("開啟登入視窗", LogType_NORMAL)
        frmLogin.ShowDialog(Me)
    End Sub

    Private Sub tmrServerPing_Tick(sender As Object, e As EventArgs) Handles tmrServerPing.Tick
        ' 每30秒檢查一次伺服器連線狀態
        log("==連線檢查", LogType_SYSTEM)
        If Not connectStatusTest() Then
            ' 斷線處理
            uiLogout("BREAK")
        End If
    End Sub

    Delegate Sub _uiLogout(ByVal type As String)
    Public Sub uiLogout(ByVal type As String)
        If InvokeRequired Then
            Invoke(New _uiLogout(AddressOf uiLogout), type)
            Exit Sub
        End If

        tmrServerPing.Enabled = False
        Select Case type
            Case "LOGOUT"
                MsgBox("已成功登出!", MsgBoxStyle.OkOnly, "登出")
                log(myName & " 已成功登出", LogType_NORMAL)
            Case "BREAK"
                MsgBox("與伺服器失去連線!" & vbCrLf & "請重新登入!!!", MsgBoxStyle.OkOnly, "斷線")
                log("與伺服器失去連線!", LogType_ERROR)
        End Select
        myId = ""
        myName = ""
        myUid = ""
        myPwd = ""
        tsmAccount.Enabled = False
        tsmCourse.Enabled = False
        mnuLogin.Enabled = True
        mnuSignUp.Enabled = False
        mnuLogout.Enabled = False
        tslUserName.Text = "尚未登入"
    End Sub

    Private Sub mnuLogout_Click(sender As Object, e As EventArgs) Handles mnuLogout.Click
        log("執行登出", LogType_NORMAL)
        logout()
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

    Private Sub tslSysTime_Click(sender As Object, e As EventArgs) Handles tslSysTime.Click
        Dim result = doSqlQuery("SELECT * FROM Course;")
        Dim d As New DataGridView()
        d.Dock = DockStyle.Fill
        d.DataSource = result
        d.Refresh()
        d.AutoResizeColumns()
        Dim frmLog As New Form
        frmLog.Text = Me.Text & " | 程式執行紀錄"
        frmLog.Size = New Size(400, 500)
        frmLog.Controls.Add(d)
        frmLog.StartPosition = FormStartPosition.CenterParent
        frmLog.ShowDialog(Me)
    End Sub
End Class
