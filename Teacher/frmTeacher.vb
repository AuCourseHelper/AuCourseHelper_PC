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
                log(myProfile.Name & " 已成功登出", LogType_NORMAL)
            Case "BREAK"
                MsgBox("與伺服器失去連線!" & vbCrLf & "請重新登入!!!", MsgBoxStyle.OkOnly, "斷線")
                log("與伺服器失去連線!", LogType_ERROR)
        End Select
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

    Private Sub mnuSignUp_Click(sender As Object, e As EventArgs) Handles mnuSignUp.Click
        log("開啟助教帳號註冊視窗", LogType_NORMAL)
        frmSignUp.ShowDialog(Me)
    End Sub

    ' SELECT 方法範例
    Private Sub tslSysTime_Click(sender As Object, e As EventArgs) Handles tslSysTime.Click
        Dim sql = InputBox("SELECT SQL:")
        Dim result = doSqlQuery(sql & ";")
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

    ' CMD 方法範例
    Private Sub tslUserName_Click(sender As Object, e As EventArgs) Handles tslUserName.Click
        Dim sql = InputBox("SQL COMMAND:")
        Dim result = doSqlCmd(sql & ";")
    End Sub

    Private Sub mnuViewProfile_Click(sender As Object, e As EventArgs) Handles mnuViewProfile.Click
        Dim frmProfile As New Form
        frmProfile.Size = New Size(500, 300)
        frmProfile.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        frmProfile.Text = Me.Text & " | 檢視個人資訊"
        frmProfile.StartPosition = FormStartPosition.CenterParent
        frmProfile.Font = New Font("", 14)

        Dim pnlTable As New TableLayoutPanel()
        pnlTable.ColumnCount = 2
        pnlTable.RowCount = 6
        pnlTable.Dock = DockStyle.Fill
        pnlTable.Padding = New Padding(15)

        Dim lbl As Label
        Dim txt As TextBox

        lbl = New Label()
        lbl.Dock = DockStyle.Fill
        lbl.Margin = New Padding(8)
        lbl.Text = "帳號:"
        pnlTable.Controls.Add(lbl, 0, 0)
        txt = New TextBox()
        txt.Dock = DockStyle.Fill
        txt.ReadOnly = True
        txt.Text = myProfile.Num
        pnlTable.Controls.Add(txt, 1, 0)

        lbl = New Label()
        lbl.Dock = DockStyle.Fill
        lbl.Margin = New Padding(8)
        lbl.Text = "姓名:"
        pnlTable.Controls.Add(lbl, 0, 1)
        txt = New TextBox()
        txt.Dock = DockStyle.Fill
        txt.ReadOnly = True
        txt.Text = myProfile.Name
        pnlTable.Controls.Add(txt, 1, 1)

        lbl = New Label()
        lbl.Dock = DockStyle.Fill
        lbl.Margin = New Padding(8)
        lbl.Text = "上次登入時間:"
        pnlTable.Controls.Add(lbl, 0, 2)
        txt = New TextBox()
        txt.Dock = DockStyle.Fill
        txt.ReadOnly = True
        txt.Text = myProfile.LastLogin
        pnlTable.Controls.Add(txt, 1, 2)

        lbl = New Label()
        lbl.Dock = DockStyle.Fill
        lbl.Margin = New Padding(8)
        lbl.Text = "上次登入位置:"
        pnlTable.Controls.Add(lbl, 0, 3)
        txt = New TextBox()
        txt.Dock = DockStyle.Fill
        txt.ReadOnly = True
        txt.Text = myProfile.LastIp
        pnlTable.Controls.Add(txt, 1, 3)

        lbl = New Label()
        lbl.Dock = DockStyle.Fill
        lbl.Margin = New Padding(8)
        lbl.Text = "個人網站:"
        pnlTable.Controls.Add(lbl, 0, 4)
        txt = New TextBox()
        txt.Dock = DockStyle.Fill
        txt.ReadOnly = True
        txt.Text = myProfile.WebSite
        pnlTable.Controls.Add(txt, 1, 4)

        lbl = New Label()
        lbl.Dock = DockStyle.Fill
        lbl.Margin = New Padding(8)
        lbl.Text = "OfficeHour:"
        pnlTable.Controls.Add(lbl, 0, 5)
        txt = New TextBox()
        txt.Dock = DockStyle.Fill
        txt.ReadOnly = True
        txt.Text = myProfile.OfficeTime
        pnlTable.Controls.Add(txt, 1, 5)

        frmProfile.Controls.Add(pnlTable)
        frmProfile.ShowDialog(Me)
    End Sub
End Class
