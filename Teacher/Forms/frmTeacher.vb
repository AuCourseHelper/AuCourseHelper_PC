﻿Imports System.Net.NetworkInformation
Imports System.Threading

Public Class frmTeacher
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
            dlgLogin.txtUid.Text = "4327"
            dlgLogin.txtPwd.Text = "4327"
            mnuLogin.PerformClick()
        ElseIf e.KeyCode = Keys.F1 Then

        End If
    End Sub

    Private Sub frmTeacher_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not readSetting() Then
            MsgBox("程式設定檔讀取失敗!!!" & vbCrLf & "請確認 setting.xml 檔案是否存在或毀損")
            Application.Exit()
        End If

        objFrmTeacher = Me
        log("====執行系統====", LogType_SYSTEM)
        log("==教師端", LogType_SYSTEM)
        log("==版本號:" & VERSION, LogType_SYSTEM)

        If MYIP = "" And MYREALIP = "" Then
            MsgBox("請確認電腦的網際網路連線狀態!!!")
            Application.Exit()
        Else
            If MYREALIP <> MYIP Then
                tsmIp.Text = "區網IP: " & MYIP & " - 對外IP: " & MYREALIP
            Else
                tsmIp.Text = "IP: " & MYREALIP
            End If
        End If

        log("==" & tsmIp.Text, LogType_SYSTEM)
        Me.Text &= "(" & VERSION & ")"
        tslSysTime.Text = Now
    End Sub

    ' 每天零點更新Log檔名
    Private Sub tmrSysTime_Tick(sender As Object, e As EventArgs) Handles tmrSysTime.Tick
        tslSysTime.Text = Now
        If Now.Hour = 0 And Now.Minute = 0 And Now.Second = 0 Then
            logFilePath = Application.StartupPath & "\logs\log-T-" & Format(Now, "yyyyMMdd") & ".txt"
        End If
    End Sub

    ' 每60秒檢查一次伺服器連線狀態
    Private Sub tmrServerPing_Tick(sender As Object, e As EventArgs) Handles tmrServerPing.Tick
        log("==連線檢查", LogType_SYSTEM)
        If Not connectStatusTest() Then
            ' 斷線處理
            uiLogout("BREAK")
        End If
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
        frmLog.Size = New Size(800, 600)
        frmLog.Controls.Add(d)
        frmLog.StartPosition = FormStartPosition.CenterParent
        frmLog.ShowDialog(Me)
    End Sub

    ' CMD 方法範例
    Private Sub tslUserName_Click(sender As Object, e As EventArgs) Handles tslUserName.Click
        Dim sql = InputBox("SQL COMMAND:")
        Dim result = doSqlCmd(sql & ";")
    End Sub

#Region "--主選單"
    ' 登入
    Private Sub mnuLogin_Click(sender As Object, e As EventArgs) Handles mnuLogin.Click
        log("開啟登入視窗", LogType_NORMAL)
        dlgLogin.ShowDialog(Me)
        If isLogin Then
            tsmCourse.DropDownItems.Clear()
            Dim index = 0
            For Each row As DataRow In myCourses.Select("Term='" & nowTerm & "'")
                tsmCourse.DropDownItems.Add(row.Item(1) & " " & row.Item(4))
                tsmCourse.DropDownItems(index).Tag = row.Item(0) ' 課程ID
                AddHandler tsmCourse.DropDownItems.Item(index).Click, AddressOf mnuCourse_Click
                index += 1
            Next

            tslUserName.Text = myProfile.Name
            tsmCourse.Text = "我的課程(" & nowTerm & ")"
            tmrServerPing.Enabled = True
            tsmAccount.Enabled = True
            tsmCourse.Enabled = True
            mnuLogin.Enabled = False
            mnuSignUp.Enabled = True
            mnuLogout.Enabled = True
            lblWeek.Text = nowTerm & " 第 " & nowWeek & " 週"

            pnlMain.Controls.Clear()
            Dim lblWelcome As New Label
            lblWelcome.AutoSize = False
            lblWelcome.Dock = DockStyle.Fill
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter
            lblWelcome.Font = New Font("", 24)
            lblWelcome.Text = myProfile.Name & " 老師你好！" & vbCrLf & "請至 <<我的課程>> 選取課程來授課!!"
            pnlMain.Controls.Add(lblWelcome)
        End If
    End Sub

    ' 助教帳號註冊
    Private Sub mnuSignUp_Click(sender As Object, e As EventArgs) Handles mnuSignUp.Click
        log("開啟助教帳號註冊視窗", LogType_NORMAL)
        dlgSignUp.ShowDialog(Me)
    End Sub

    ' 登出
    Private Sub mnuLogout_Click(sender As Object, e As EventArgs) Handles mnuLogout.Click
        log("執行登出", LogType_NORMAL)
        logout()
    End Sub

    ' 結束
    Private Sub mnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        Application.Exit()
    End Sub

    ' 我的課程(動態)
    Private Sub mnuCourse_Click(sender As Object, e As EventArgs)
        Dim courseItem As ToolStripDropDownItem = sender
        doCourse = myCourses.Rows.Find(courseItem.Tag)
        tslCourseName.Text = Trim(doCourse.Item(4))
        mnuCourseTool.Enabled = True
        tsmCourse.Enabled = False

        Dim t As New Thread(AddressOf doGetCourseStudents)
        t.Start()
        dlgProgress.title = "讀取學生資訊..."
        dlgProgress.ShowDialog(Me)

        If doCourseStudents Is Nothing Then
            MsgBox("該課程學生資料取得失敗！請再試一次！", MsgBoxStyle.Critical)
            tslEnd.PerformClick()
        Else
            If doCourseStudents.Rows.Count < 1 Then
                dlgCreateList.ShowDialog(Me)
            End If
            If doCourseStudents.Rows.Count < 1 Then
                tslEnd.PerformClick()
                MsgBox("請先建立本課程學生名單才能夠繼續執行！", MsgBoxStyle.Critical)
            Else
                tslList.PerformClick()
            End If
        End If
    End Sub
    Private Sub doGetCourseStudents()
        Dim sqlGetCourseStudents = String.Format("SELECT cs.StudentCourseId,cs.Seat,s.Num,s.Name " _
                                 & "FROM Student s,CourseStudent cs " _
                                 & "WHERE cs.CourseId={0} AND cs.StudentNum=s.Num ORDER BY cs.StudentCourseId;", doCourse.Item("Id"))
        doCourseStudents = doSqlQuery(sqlGetCourseStudents)
        If doCourseStudents Is Nothing Then
            dlgProgress.isOff = True
            Exit Sub
        End If
        doCourseStudents.Columns(0).ColumnName = "序號"
        doCourseStudents.Columns(1).ColumnName = "座位"
        doCourseStudents.Columns(2).ColumnName = "學號"
        doCourseStudents.Columns(3).ColumnName = "姓名"

        dlgProgress.isOff = True
    End Sub

    ' 檢視個人資訊
    Private Sub mnuViewProfile_Click(sender As Object, e As EventArgs) Handles mnuViewProfile.Click
        log("檢視個人資訊", LogType_NORMAL)
        dlgMyProfile.ShowDialog(Me)
    End Sub

    ' 修改個人資訊
    Private Sub mnuEditProfile_Click(sender As Object, e As EventArgs) Handles mnuEditProfile.Click
        log("修改個人資訊", LogType_NORMAL)
    End Sub

    ' 檢視本次紀錄
    Private Sub mnuViewLog_Click(sender As Object, e As EventArgs) Handles mnuViewLog.Click
        log("檢視本次執行紀錄", LogType_SYSTEM)
        Dim frmLog As New Form
        Dim txtLog As New RichTextBox()
        txtLog.MaxLength = 0
        txtLog.Text = logData
        txtLog.ReadOnly = True
        txtLog.ScrollBars = RichTextBoxScrollBars.Both
        txtLog.Dock = DockStyle.Fill
        txtLog.Select(txtLog.TextLength - 1, 0)
        frmLog.Text = "課堂輔助系統-教師端 | 程式執行紀錄"
        frmLog.Size = New Size(400, 500)
        frmLog.Controls.Add(txtLog)
        frmLog.StartPosition = FormStartPosition.CenterParent
        frmLog.ShowInTaskbar = False
        frmLog.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        frmLog.MinimizeBox = False
        frmLog.MaximizeBox = False
        frmLog.ShowDialog(Me)
    End Sub

    ' 查閱歷史紀錄(動態)
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

    ' 上傳紀錄偵錯
    Private Sub mnuUploadLog_Click(sender As Object, e As EventArgs) Handles mnuUploadLog.Click
        log("上傳紀錄偵錯", LogType_SYSTEM)
    End Sub

    ' IP資訊
    Private Sub tsmIp_Click(sender As Object, e As EventArgs) Handles tsmIp.Click
        If tsmIp.Text.StartsWith("伺服器") Then
            If MYREALIP <> MYIP Then
                tsmIp.Text = "區網IP: " & MYIP & " - 對外IP: " & MYREALIP
            Else
                tsmIp.Text = "IP: " & MYREALIP
            End If
        Else
            tsmIp.Text = "伺服器IP: " & SERVERIP & " , PORT: " & SERVERPORT
        End If
    End Sub

#End Region

#Region "--功能選單"
    ' 課程名稱
    Private Sub tslCourseName_MouseEnter(sender As Object, e As EventArgs) Handles tslCourseName.MouseEnter
        Cursor = Cursors.Help
    End Sub

    Private Sub tslCourseName_MouseLeave(sender As Object, e As EventArgs) Handles tslCourseName.MouseLeave
        Cursor = Cursors.Default
    End Sub

    Private Sub tslCourseName_Click(sender As Object, e As EventArgs) Handles tslCourseName.Click
        Dim sResult = ""
        sResult &= "選課代號：" & doCourse.Item("ChooseNum") & vbCrLf
        sResult &= "開課班級：" & doCourse.Item("Class") & vbCrLf
        sResult &= "學　　分：" & doCourse.Item("Credit") & vbCrLf
        sResult &= "上課時間：" & doCourse.Item("Time") & vbCrLf
        sResult &= "上課教室：" & doCourse.Item("Classroom") & vbCrLf
        sResult &= "修課人數：" & doCourseStudents.Rows.Count & "人" & vbCrLf
        MsgBox(sResult, MsgBoxStyle.Information, doCourse.Item("Name"))
    End Sub

    ' 學生名單
    Private Sub tslList_Click(sender As Object, e As EventArgs) Handles tslList.Click
        If Not isSaved Then
            If MsgBox("變更的內容尚未儲存！" & vbCrLf & "是否放棄本次變更？", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
            isSaved = True
            bAttendHasData = False
        End If
        nowCourseMenuItem.BackColor = Nothing
        nowCourseMenuItem = tslList
        nowCourseMenuItem.BackColor = Color.BurlyWood
        pnlMain.Controls.Clear()

        doForm.Close()
        doForm = frmList
        frmList.TopLevel = False
        frmList.Dock = DockStyle.Fill
        pnlMain.Controls.Add(frmList)
        frmList.Show()
    End Sub

    ' 點名
    Private Sub tslAttend_Click(sender As Object, e As EventArgs) Handles tslAttend.Click
        If Not isSaved Then
            If MsgBox("變更的內容尚未儲存！" & vbCrLf & "是否放棄本次變更？", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
            isSaved = True
            bAttendHasData = False
        End If
        nowCourseMenuItem.BackColor = Nothing
        nowCourseMenuItem = tslAttend
        nowCourseMenuItem.BackColor = Color.BurlyWood
        pnlMain.Controls.Clear()

        doForm.Close()
        doForm = frmAttend
        frmAttend.TopLevel = False
        frmAttend.Dock = DockStyle.Fill
        pnlMain.Controls.Add(frmAttend)
        frmAttend.Show()
    End Sub

    ' 評分
    Private Sub tslScore_Click(sender As Object, e As EventArgs) Handles tslScore.Click
        If Not isSaved Then
            If MsgBox("變更的內容尚未儲存！" & vbCrLf & "是否放棄本次變更？", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
            isSaved = True
        End If
        nowCourseMenuItem.BackColor = Nothing
        nowCourseMenuItem = tslScore
        nowCourseMenuItem.BackColor = Color.BurlyWood
        pnlMain.Controls.Clear()

        doForm.Close()
        doForm = frmScore
        frmScore.TopLevel = False
        frmScore.Dock = DockStyle.Fill
        pnlMain.Controls.Add(frmScore)
        frmScore.Show()
    End Sub

    ' 作業
    Private Sub tslHomeWork_Click(sender As Object, e As EventArgs) Handles tslHomeWork.Click
        If Not isSaved Then
            If MsgBox("變更的內容尚未儲存！" & vbCrLf & "是否放棄本次變更？", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
            isSaved = True
        End If
        nowCourseMenuItem.BackColor = Nothing
        nowCourseMenuItem = tslHomeWork
        nowCourseMenuItem.BackColor = Color.BurlyWood
        pnlMain.Controls.Clear()

        doForm.Close()
        doForm = frmHomeWork
        frmHomeWork.TopLevel = False
        frmHomeWork.Dock = DockStyle.Fill
        pnlMain.Controls.Add(frmHomeWork)
        frmHomeWork.Show()
    End Sub

    ' 考試
    Private Sub tslExam_Click(sender As Object, e As EventArgs) Handles tslExam.Click
        If Not isSaved Then
            If MsgBox("變更的內容尚未儲存！" & vbCrLf & "是否放棄本次變更？", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
            isSaved = True
        End If
        nowCourseMenuItem.BackColor = Nothing
        nowCourseMenuItem = tslExam
        nowCourseMenuItem.BackColor = Color.BurlyWood
        pnlMain.Controls.Clear()

        doForm.Close()
        doForm = frmExam
        frmExam.TopLevel = False
        frmExam.Dock = DockStyle.Fill
        pnlMain.Controls.Add(frmExam)
        frmExam.Show()
    End Sub

    ' 報表
    Private Sub tslReport_Click(sender As Object, e As EventArgs) Handles tslReport.Click
        If Not isSaved Then
            If MsgBox("變更的內容尚未儲存！" & vbCrLf & "是否放棄本次變更？", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
            isSaved = True
        End If
        nowCourseMenuItem.BackColor = Nothing
        nowCourseMenuItem = tslReport
        nowCourseMenuItem.BackColor = Color.BurlyWood
        pnlMain.Controls.Clear()

        doForm.Close()
        doForm = frmReport
        frmReport.TopLevel = False
        frmReport.Dock = DockStyle.Fill
        pnlMain.Controls.Add(frmReport)
        frmReport.Show()
    End Sub

    ' 修改資料
    Private Sub tslEdit_Click(sender As Object, e As EventArgs) Handles tslEdit.Click

    End Sub

    ' 結束課程
    Private Sub tslEnd_Click(sender As Object, e As EventArgs) Handles tslEnd.Click
        If Not isSaved Then
            If MsgBox("變更的內容尚未儲存！" & vbCrLf & "是否放棄本次變更？", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
            isSaved = True
        End If
        nowCourseMenuItem.BackColor = Nothing
        doForm.Close()
        pnlMain.Controls.Clear()
        tslCourseName.Text = "請選擇課程"
        mnuCourseTool.Enabled = False
        tsmCourse.Enabled = True
        bAttendHasData = False

        pnlMain.Controls.Clear()
        Dim lblWelcome As New Label
        lblWelcome.AutoSize = False
        lblWelcome.Dock = DockStyle.Fill
        lblWelcome.TextAlign = ContentAlignment.MiddleCenter
        lblWelcome.Font = New Font("", 24)
        lblWelcome.Text = myProfile.Name & " 老師你好！" & vbCrLf & "請至 <<我的課程>> 選取課程來授課!!"
        pnlMain.Controls.Add(lblWelcome)
    End Sub
#End Region

#Region "--UI更新執行續"
    ' LOG狀態更新
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

    ' 登出處理
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
        tsmCourse.Text = "我的課程"
        lblWeek.Text = "000-0 第 0 週"
        mnuCourseTool.Enabled = False
        For Each tsi As ToolStripItem In mnuCourseTool.Items
            tsi.BackColor = Nothing
        Next
        pnlMain.Controls.Clear()
    End Sub

#End Region
End Class
