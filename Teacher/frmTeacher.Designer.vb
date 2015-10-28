<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTeacher
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意:  以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTeacher))
        Me.mnuMain = New System.Windows.Forms.MenuStrip()
        Me.tsmConnection = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLogin = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSignUp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLogout = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmAccount = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditPwd = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditPublic = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmCourse = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmLog = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewLog = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewHistory = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuUploadLog = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmIp = New System.Windows.Forms.ToolStripMenuItem()
        Me.stpMain = New System.Windows.Forms.StatusStrip()
        Me.tslLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslUserName = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslSysTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tslCourseName = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tslAttend = New System.Windows.Forms.ToolStripButton()
        Me.tslScore = New System.Windows.Forms.ToolStripButton()
        Me.tslHomeWork = New System.Windows.Forms.ToolStripButton()
        Me.tslExam = New System.Windows.Forms.ToolStripButton()
        Me.tslReport = New System.Windows.Forms.ToolStripButton()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.tmrSysTime = New System.Windows.Forms.Timer(Me.components)
        Me.tmrServerPing = New System.Windows.Forms.Timer(Me.components)
        Me.mnuMain.SuspendLayout()
        Me.stpMain.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuMain
        '
        Me.mnuMain.Font = New System.Drawing.Font("微軟正黑體", 12.0!)
        Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmConnection, Me.tsmAccount, Me.tsmCourse, Me.tsmLog, Me.tsmIp})
        Me.mnuMain.Location = New System.Drawing.Point(0, 0)
        Me.mnuMain.Name = "mnuMain"
        Me.mnuMain.Size = New System.Drawing.Size(784, 28)
        Me.mnuMain.TabIndex = 0
        Me.mnuMain.Text = "MenuStrip1"
        '
        'tsmConnection
        '
        Me.tsmConnection.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuLogin, Me.mnuSignUp, Me.mnuLogout, Me.ToolStripMenuItem2, Me.mnuExit})
        Me.tsmConnection.Name = "tsmConnection"
        Me.tsmConnection.Size = New System.Drawing.Size(53, 24)
        Me.tsmConnection.Text = "連線"
        '
        'mnuLogin
        '
        Me.mnuLogin.Name = "mnuLogin"
        Me.mnuLogin.Size = New System.Drawing.Size(110, 24)
        Me.mnuLogin.Text = "登入"
        '
        'mnuSignUp
        '
        Me.mnuSignUp.Name = "mnuSignUp"
        Me.mnuSignUp.Size = New System.Drawing.Size(110, 24)
        Me.mnuSignUp.Text = "註冊"
        '
        'mnuLogout
        '
        Me.mnuLogout.Enabled = False
        Me.mnuLogout.Name = "mnuLogout"
        Me.mnuLogout.Size = New System.Drawing.Size(110, 24)
        Me.mnuLogout.Text = "登出"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(107, 6)
        '
        'mnuExit
        '
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(110, 24)
        Me.mnuExit.Text = "結束"
        '
        'tsmAccount
        '
        Me.tsmAccount.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEditPwd, Me.mnuEditPublic})
        Me.tsmAccount.Enabled = False
        Me.tsmAccount.Name = "tsmAccount"
        Me.tsmAccount.Size = New System.Drawing.Size(85, 24)
        Me.tsmAccount.Text = "帳號資訊"
        '
        'mnuEditPwd
        '
        Me.mnuEditPwd.Name = "mnuEditPwd"
        Me.mnuEditPwd.Size = New System.Drawing.Size(174, 24)
        Me.mnuEditPwd.Text = "修改密碼"
        '
        'mnuEditPublic
        '
        Me.mnuEditPublic.Name = "mnuEditPublic"
        Me.mnuEditPublic.Size = New System.Drawing.Size(174, 24)
        Me.mnuEditPublic.Text = "修改公開資訊"
        '
        'tsmCourse
        '
        Me.tsmCourse.Enabled = False
        Me.tsmCourse.Name = "tsmCourse"
        Me.tsmCourse.Size = New System.Drawing.Size(85, 24)
        Me.tsmCourse.Text = "課程資訊"
        '
        'tsmLog
        '
        Me.tsmLog.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuViewLog, Me.mnuViewHistory, Me.ToolStripMenuItem1, Me.mnuUploadLog})
        Me.tsmLog.Name = "tsmLog"
        Me.tsmLog.Size = New System.Drawing.Size(53, 24)
        Me.tsmLog.Text = "紀錄"
        '
        'mnuViewLog
        '
        Me.mnuViewLog.Name = "mnuViewLog"
        Me.mnuViewLog.Size = New System.Drawing.Size(206, 24)
        Me.mnuViewLog.Text = "檢視紀錄"
        '
        'mnuViewHistory
        '
        Me.mnuViewHistory.Name = "mnuViewHistory"
        Me.mnuViewHistory.Size = New System.Drawing.Size(206, 24)
        Me.mnuViewHistory.Text = "查閱歷史紀錄檔"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(203, 6)
        '
        'mnuUploadLog
        '
        Me.mnuUploadLog.Enabled = False
        Me.mnuUploadLog.Name = "mnuUploadLog"
        Me.mnuUploadLog.Size = New System.Drawing.Size(206, 24)
        Me.mnuUploadLog.Text = "上傳記錄提供偵錯"
        '
        'tsmIp
        '
        Me.tsmIp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsmIp.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tsmIp.ForeColor = System.Drawing.Color.Blue
        Me.tsmIp.Name = "tsmIp"
        Me.tsmIp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tsmIp.Size = New System.Drawing.Size(112, 24)
        Me.tsmIp.Text = "IP ADDRESS"
        '
        'stpMain
        '
        Me.stpMain.Font = New System.Drawing.Font("微軟正黑體", 10.0!)
        Me.stpMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslLabel1, Me.tslStatus, Me.tslUserName, Me.tslSysTime})
        Me.stpMain.Location = New System.Drawing.Point(0, 539)
        Me.stpMain.Name = "stpMain"
        Me.stpMain.Size = New System.Drawing.Size(784, 23)
        Me.stpMain.TabIndex = 2
        Me.stpMain.Text = "StatusStrip1"
        '
        'tslLabel1
        '
        Me.tslLabel1.Name = "tslLabel1"
        Me.tslLabel1.Size = New System.Drawing.Size(39, 18)
        Me.tslLabel1.Text = "狀態:"
        Me.tslLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tslStatus
        '
        Me.tslStatus.BackColor = System.Drawing.SystemColors.GrayText
        Me.tslStatus.ForeColor = System.Drawing.SystemColors.Info
        Me.tslStatus.Name = "tslStatus"
        Me.tslStatus.Size = New System.Drawing.Size(553, 18)
        Me.tslStatus.Spring = True
        Me.tslStatus.Text = "~狀態訊息~"
        Me.tslStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tslUserName
        '
        Me.tslUserName.Name = "tslUserName"
        Me.tslUserName.Size = New System.Drawing.Size(64, 18)
        Me.tslUserName.Text = "尚未登入"
        '
        'tslSysTime
        '
        Me.tslSysTime.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.tslSysTime.Name = "tslSysTime"
        Me.tslSysTime.Size = New System.Drawing.Size(82, 18)
        Me.tslSysTime.Text = "#系統時間#"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Enabled = False
        Me.ToolStrip1.Font = New System.Drawing.Font("微軟正黑體", 14.0!)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslCourseName, Me.ToolStripSeparator1, Me.tslAttend, Me.tslScore, Me.tslHomeWork, Me.tslExam, Me.tslReport})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 28)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(784, 31)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "tlsMain"
        '
        'tslCourseName
        '
        Me.tslCourseName.Name = "tslCourseName"
        Me.tslCourseName.Size = New System.Drawing.Size(86, 28)
        Me.tslCourseName.Text = "課程名稱"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'tslAttend
        '
        Me.tslAttend.Image = CType(resources.GetObject("tslAttend.Image"), System.Drawing.Image)
        Me.tslAttend.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tslAttend.Name = "tslAttend"
        Me.tslAttend.Size = New System.Drawing.Size(68, 28)
        Me.tslAttend.Text = "點名"
        '
        'tslScore
        '
        Me.tslScore.Image = CType(resources.GetObject("tslScore.Image"), System.Drawing.Image)
        Me.tslScore.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tslScore.Name = "tslScore"
        Me.tslScore.Size = New System.Drawing.Size(68, 28)
        Me.tslScore.Text = "評分"
        '
        'tslHomeWork
        '
        Me.tslHomeWork.Image = CType(resources.GetObject("tslHomeWork.Image"), System.Drawing.Image)
        Me.tslHomeWork.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tslHomeWork.Name = "tslHomeWork"
        Me.tslHomeWork.Size = New System.Drawing.Size(106, 28)
        Me.tslHomeWork.Text = "建立作業"
        '
        'tslExam
        '
        Me.tslExam.Image = CType(resources.GetObject("tslExam.Image"), System.Drawing.Image)
        Me.tslExam.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tslExam.Name = "tslExam"
        Me.tslExam.Size = New System.Drawing.Size(106, 28)
        Me.tslExam.Text = "建立考試"
        '
        'tslReport
        '
        Me.tslReport.Image = CType(resources.GetObject("tslReport.Image"), System.Drawing.Image)
        Me.tslReport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tslReport.Name = "tslReport"
        Me.tslReport.Size = New System.Drawing.Size(106, 28)
        Me.tslReport.Text = "統計報表"
        '
        'pnlMain
        '
        Me.pnlMain.AutoScroll = True
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 59)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(784, 480)
        Me.pnlMain.TabIndex = 4
        '
        'tmrSysTime
        '
        Me.tmrSysTime.Enabled = True
        Me.tmrSysTime.Interval = 1000
        '
        'tmrServerPing
        '
        Me.tmrServerPing.Interval = 30000
        '
        'frmTeacher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.stpMain)
        Me.Controls.Add(Me.mnuMain)
        Me.MainMenuStrip = Me.mnuMain
        Me.MinimumSize = New System.Drawing.Size(800, 600)
        Me.Name = "frmTeacher"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "課程輔助系統-教師端"
        Me.mnuMain.ResumeLayout(False)
        Me.mnuMain.PerformLayout()
        Me.stpMain.ResumeLayout(False)
        Me.stpMain.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents stpMain As System.Windows.Forms.StatusStrip
    Friend WithEvents tslLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslUserName As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslSysTime As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsmConnection As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLogin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSignUp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLogout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmAccount As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEditPwd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEditPublic As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmLog As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewLog As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewHistory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuUploadLog As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmIp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmCourse As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tslCourseName As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tslAttend As System.Windows.Forms.ToolStripButton
    Friend WithEvents tslScore As System.Windows.Forms.ToolStripButton
    Friend WithEvents tslHomeWork As System.Windows.Forms.ToolStripButton
    Friend WithEvents tslExam As System.Windows.Forms.ToolStripButton
    Friend WithEvents tslReport As System.Windows.Forms.ToolStripButton
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents tmrSysTime As System.Windows.Forms.Timer
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmrServerPing As System.Windows.Forms.Timer

End Class
