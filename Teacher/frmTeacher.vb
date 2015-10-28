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
        log.Enabled = False
        log.ScrollBars = RichTextBoxScrollBars.Both
        log.Dock = DockStyle.Fill
        frmLog.Text = Me.Text & " | 程式執行紀錄"
        frmLog.Size = New Size(400, 500)
        frmLog.Controls.Add(log)
        frmLog.ShowDialog()
    End Sub

    Private Sub mnuLogin_Click(sender As Object, e As EventArgs) Handles mnuLogin.Click
        frmLogin.ShowDialog()
    End Sub

    Private Sub tmrServerPing_Tick(sender As Object, e As EventArgs) Handles tmrServerPing.Tick
        ' 每30秒檢查一次伺服器連線狀態
        If Not connectStatusTest() Then
            ' 斷線處理
            uiLogout()
        End If
    End Sub

    Delegate Sub _uiLogout()
    Public Sub uiLogout()
        If InvokeRequired Then
            Invoke(New _uiLogout(AddressOf uiLogout))
            Exit Sub
        End If

        tmrServerPing.Enabled = False
        MsgBox("與伺服器失去連線!" & vbCrLf & "請重新登入!!!", MsgBoxStyle.OkOnly, "斷線")
        isLogin = False
        myId = ""
        myName = ""
        myUid = ""
        myPwd = ""
        clientSocket.Close()
        clientSocket.Dispose()
        tsmAccount.Enabled = False
        tsmCourse.Enabled = False
        mnuLogin.Enabled = True
        mnuSignUp.Enabled = True
        mnuLogout.Enabled = False
        tslUserName.Text = "尚未登入"
    End Sub

    Private Sub mnuLogout_Click(sender As Object, e As EventArgs) Handles mnuLogout.Click
        logout()
    End Sub
End Class
