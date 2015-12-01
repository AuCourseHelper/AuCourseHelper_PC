Imports System.Net.NetworkInformation

Public Class frmTeacher
    Public version = "1.0.151120"
    Private nowCourseMenuItem As New ToolStripButton

    Private Sub frmTeacher_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("是否確定要關閉本系統", "關閉程式", MessageBoxButtons.YesNo) = DialogResult.No Then
            e.Cancel = True
            Exit Sub
        End If
        logout()
        log("====關閉系統====" & vbCrLf, LogType_SYSTEM)
    End Sub

    Private Sub frmTeacher_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F2 Then
            frmLogin.txtUid.Text = "4327"
            frmLogin.txtPwd.Text = "4327"
            mnuLogin.PerformClick()
        End If
    End Sub

    Private Sub frmTeacher_Load(sender As Object, e As EventArgs) Handles Me.Load
        objFrmTeacher = Me
        log("====執行系統====", LogType_SYSTEM)
        log("==教師端", LogType_SYSTEM)
        log("==版本號:" & version, LogType_SYSTEM)
        Try
            If GetRealIPaddress() <> GetIPaddress() Then
                tsmIp.Text = "區網IP: " & GetIPaddress() & " - 對外IP: " & GetRealIPaddress()
            Else
                tsmIp.Text = "IP: " & GetRealIPaddress()
            End If
        Catch ex As Exception
            MsgBox("請確認電腦的網際網路連線狀態!!!")
            Application.Exit()
        End Try
        log("==" & tsmIp.Text, LogType_SYSTEM)
        Me.Text &= "(" & version & ")"
        tslSysTime.Text = Now
    End Sub

    Private Sub tmrSysTime_Tick(sender As Object, e As EventArgs) Handles tmrSysTime.Tick
        tslSysTime.Text = Now
        If Now.Hour = 0 And Now.Minute = 0 And Now.Second = 0 Then ' 早上零點更新Log檔名
            logFilePath = Application.StartupPath & "\logs\log-server-" & Format(Now, "yyyyMMdd") & ".txt"
        End If
    End Sub

    Private Sub mnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        Application.Exit()
    End Sub

    Private Sub tsmLog_DropDownOpened(sender As Object, e As EventArgs) Handles tsmLog.DropDownOpened
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

    Private Sub historyLog_View(sender As Object, e As EventArgs)
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
        frmLog.Text = "課堂輔助系統-教師端 | 程式執行紀錄"
        frmLog.Size = New Size(400, 500)
        frmLog.Controls.Add(txtLog)
        frmLog.ShowDialog()
    End Sub

    Private Sub mnuLogin_Click(sender As Object, e As EventArgs) Handles mnuLogin.Click
        log("開啟登入視窗", LogType_NORMAL)
        frmLogin.ShowDialog(Me)
        If isLogin Then
            tsmCourse.DropDownItems.Clear()
            Dim index = 0
            For Each row As DataRow In myCourses.Rows
                tsmCourse.DropDownItems.Add(row.Item(1) & " " & row.Item(4))
                tsmCourse.DropDownItems(index).Tag = row.Item(0) ' 課程ID
                AddHandler tsmCourse.DropDownItems.Item(index).Click, AddressOf course_Choose
                index += 1
            Next

            tslUserName.Text = myProfile.Name & " 你好!"
            tslTerm.Text = nowTerm
            tmrServerPing.Enabled = True
            tsmAccount.Enabled = True
            tsmCourse.Enabled = True
            mnuLogin.Enabled = False
            mnuSignUp.Enabled = True
            mnuLogout.Enabled = True
            lblWeek.Text = "第 " & nowWeek & " 週"
        End If
    End Sub

    Private Sub course_Choose(sender As Object, e As EventArgs)
        Dim courseItem As ToolStripDropDownItem = sender
        Dim courseRow As DataRow = myCourses.Rows.Find(courseItem.Tag)
        tslCourseName.Text = Trim(courseRow.Item(4))
        nowCourse = courseRow
        mnuCourseTool.Enabled = True
        tsmCourse.Enabled = False
    End Sub

    Private Sub tmrServerPing_Tick(sender As Object, e As EventArgs) Handles tmrServerPing.Tick
        ' 每60秒檢查一次伺服器連線狀態
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
        tslCourseName.Text = "請先選擇課程"
        tslTerm.Text = ""
        mnuCourseTool.Enabled = False
        For Each tsi As ToolStripItem In mnuCourseTool.Items
            tsi.BackColor = Nothing
        Next
        pnlMain.Controls.Clear()
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
        frmLog.Text = "課程輔助系統-教師端 | 程式執行紀錄"
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
        frmMyProfile.ShowDialog(Me)
    End Sub

    Private Sub tslAttend_Click(sender As Object, e As EventArgs) Handles tslAttend.Click
        nowCourseMenuItem.BackColor = Nothing
        nowCourseMenuItem = tslAttend
        nowCourseMenuItem.BackColor = Color.BurlyWood
        pnlMain.Controls.Clear()

        frmAttend.Dispose()
        frmAttend.TopLevel = False
        frmAttend.Dock = DockStyle.Fill
        pnlMain.Controls.Add(frmAttend)
        frmAttend.Show()
    End Sub

    Private Sub tslScore_Click(sender As Object, e As EventArgs) Handles tslScore.Click
        nowCourseMenuItem.BackColor = Nothing
        nowCourseMenuItem = tslScore
        nowCourseMenuItem.BackColor = Color.BurlyWood
        pnlMain.Controls.Clear()

        frmScore.Dispose()
        frmScore.TopLevel = False
        frmScore.Dock = DockStyle.Fill
        pnlMain.Controls.Add(frmScore)
        frmScore.Show()
    End Sub

    Private Sub tslHomeWork_Click(sender As Object, e As EventArgs) Handles tslHomeWork.Click
        nowCourseMenuItem.BackColor = Nothing
        nowCourseMenuItem = tslHomeWork
        nowCourseMenuItem.BackColor = Color.BurlyWood
        pnlMain.Controls.Clear()

        frmHomeWork.Dispose()
        frmHomeWork.TopLevel = False
        frmHomeWork.Dock = DockStyle.Fill
        pnlMain.Controls.Add(frmHomeWork)
        frmHomeWork.Show()
    End Sub

    Private Sub tslExam_Click(sender As Object, e As EventArgs) Handles tslExam.Click
        nowCourseMenuItem.BackColor = Nothing
        nowCourseMenuItem = tslExam
        nowCourseMenuItem.BackColor = Color.BurlyWood
        pnlMain.Controls.Clear()

        frmExam.Dispose()
        frmExam.TopLevel = False
        frmExam.Dock = DockStyle.Fill
        pnlMain.Controls.Add(frmExam)
        frmExam.Show()
    End Sub

    Private Sub tslReport_Click(sender As Object, e As EventArgs) Handles tslReport.Click
        nowCourseMenuItem.BackColor = Nothing
        nowCourseMenuItem = tslReport
        nowCourseMenuItem.BackColor = Color.BurlyWood
        pnlMain.Controls.Clear()

        frmReport.Dispose()
        frmReport.TopLevel = False
        frmReport.Dock = DockStyle.Fill
        pnlMain.Controls.Add(frmReport)
        frmReport.Show()
    End Sub

    Private Sub tslEnd_Click(sender As Object, e As EventArgs) Handles tslEnd.Click
        nowCourseMenuItem.BackColor = Nothing
        pnlMain.Controls.Clear()
        frmAttend.Dispose()
        frmScore.Dispose()
        frmHomeWork.Dispose()
        frmExam.Dispose()
        frmReport.Dispose()
        tslCourseName.Text = "請選擇課程"
        mnuCourseTool.Enabled = False
        tsmCourse.Enabled = True
    End Sub

End Class
