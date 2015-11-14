<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmServer))
        Me.stpMain = New System.Windows.Forms.StatusStrip()
        Me.tslLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslOnlineCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslSysTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.mnuMain = New System.Windows.Forms.MenuStrip()
        Me.tsmFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmServer = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuStart = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuStop = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmReport = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewLog = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewHistory = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmIp = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmDataMang = New System.Windows.Forms.ToolStripMenuItem()
        Me.教師帳號資訊ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.學生帳號資訊ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.課程資訊ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmrSysTime = New System.Windows.Forms.Timer(Me.components)
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.lvTeacher = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lvStudent = New System.Windows.Forms.ListView()
        Me.cohIp = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cohName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cohTime = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmuRMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuKickClient = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.btnEditTerm = New System.Windows.Forms.ToolStripButton()
        Me.lblTerm = New System.Windows.Forms.ToolStripLabel()
        Me.stpMain.SuspendLayout()
        Me.mnuMain.SuspendLayout()
        Me.tlpMain.SuspendLayout()
        Me.cmuRMenu.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'stpMain
        '
        Me.stpMain.Font = New System.Drawing.Font("微軟正黑體", 10.0!)
        Me.stpMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslLabel1, Me.tslStatus, Me.tslOnlineCount, Me.tslSysTime})
        Me.stpMain.Location = New System.Drawing.Point(0, 439)
        Me.stpMain.Name = "stpMain"
        Me.stpMain.Size = New System.Drawing.Size(784, 23)
        Me.stpMain.TabIndex = 0
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
        Me.tslStatus.Size = New System.Drawing.Size(484, 18)
        Me.tslStatus.Spring = True
        Me.tslStatus.Text = "~狀態訊息~"
        Me.tslStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tslOnlineCount
        '
        Me.tslOnlineCount.Name = "tslOnlineCount"
        Me.tslOnlineCount.Size = New System.Drawing.Size(164, 18)
        Me.tslOnlineCount.Text = "伺服器：關閉  人數：0人"
        '
        'tslSysTime
        '
        Me.tslSysTime.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.tslSysTime.Name = "tslSysTime"
        Me.tslSysTime.Size = New System.Drawing.Size(82, 18)
        Me.tslSysTime.Text = "#系統時間#"
        '
        'mnuMain
        '
        Me.mnuMain.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmFile, Me.tsmServer, Me.tsmReport, Me.tsmIp, Me.tsmDataMang})
        Me.mnuMain.Location = New System.Drawing.Point(0, 0)
        Me.mnuMain.Name = "mnuMain"
        Me.mnuMain.Size = New System.Drawing.Size(784, 28)
        Me.mnuMain.TabIndex = 1
        Me.mnuMain.Text = "MenuStrip1"
        '
        'tsmFile
        '
        Me.tsmFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuExit})
        Me.tsmFile.Name = "tsmFile"
        Me.tsmFile.ShortcutKeyDisplayString = ""
        Me.tsmFile.Size = New System.Drawing.Size(53, 24)
        Me.tsmFile.Text = "檔案"
        '
        'mnuExit
        '
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(110, 24)
        Me.mnuExit.Text = "結束"
        '
        'tsmServer
        '
        Me.tsmServer.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuStart, Me.mnuStop})
        Me.tsmServer.Name = "tsmServer"
        Me.tsmServer.Size = New System.Drawing.Size(69, 24)
        Me.tsmServer.Text = "伺服器"
        '
        'mnuStart
        '
        Me.mnuStart.Name = "mnuStart"
        Me.mnuStart.Size = New System.Drawing.Size(110, 24)
        Me.mnuStart.Text = "開啟"
        '
        'mnuStop
        '
        Me.mnuStop.Enabled = False
        Me.mnuStop.Name = "mnuStop"
        Me.mnuStop.Size = New System.Drawing.Size(110, 24)
        Me.mnuStop.Text = "關閉"
        '
        'tsmReport
        '
        Me.tsmReport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuViewLog, Me.mnuViewHistory})
        Me.tsmReport.Name = "tsmReport"
        Me.tsmReport.Size = New System.Drawing.Size(53, 24)
        Me.tsmReport.Text = "報表"
        '
        'mnuViewLog
        '
        Me.mnuViewLog.Name = "mnuViewLog"
        Me.mnuViewLog.Size = New System.Drawing.Size(190, 24)
        Me.mnuViewLog.Text = "檢視今日記錄"
        '
        'mnuViewHistory
        '
        Me.mnuViewHistory.Name = "mnuViewHistory"
        Me.mnuViewHistory.Size = New System.Drawing.Size(190, 24)
        Me.mnuViewHistory.Text = "查閱歷史紀錄檔"
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
        'tsmDataMang
        '
        Me.tsmDataMang.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.教師帳號資訊ToolStripMenuItem, Me.學生帳號資訊ToolStripMenuItem, Me.ToolStripMenuItem1, Me.課程資訊ToolStripMenuItem})
        Me.tsmDataMang.Name = "tsmDataMang"
        Me.tsmDataMang.Size = New System.Drawing.Size(117, 24)
        Me.tsmDataMang.Text = "系統資料管理"
        '
        '教師帳號資訊ToolStripMenuItem
        '
        Me.教師帳號資訊ToolStripMenuItem.Name = "教師帳號資訊ToolStripMenuItem"
        Me.教師帳號資訊ToolStripMenuItem.Size = New System.Drawing.Size(174, 24)
        Me.教師帳號資訊ToolStripMenuItem.Text = "教師帳號資訊"
        '
        '學生帳號資訊ToolStripMenuItem
        '
        Me.學生帳號資訊ToolStripMenuItem.Name = "學生帳號資訊ToolStripMenuItem"
        Me.學生帳號資訊ToolStripMenuItem.Size = New System.Drawing.Size(174, 24)
        Me.學生帳號資訊ToolStripMenuItem.Text = "學生帳號資訊"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(171, 6)
        '
        '課程資訊ToolStripMenuItem
        '
        Me.課程資訊ToolStripMenuItem.Name = "課程資訊ToolStripMenuItem"
        Me.課程資訊ToolStripMenuItem.Size = New System.Drawing.Size(174, 24)
        Me.課程資訊ToolStripMenuItem.Text = "課程資訊"
        '
        'tmrSysTime
        '
        Me.tmrSysTime.Enabled = True
        Me.tmrSysTime.Interval = 1000
        '
        'tlpMain
        '
        Me.tlpMain.AutoScroll = True
        Me.tlpMain.ColumnCount = 2
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpMain.Controls.Add(Me.lvTeacher, 0, 1)
        Me.tlpMain.Controls.Add(Me.Label2, 1, 0)
        Me.tlpMain.Controls.Add(Me.lvStudent, 0, 1)
        Me.tlpMain.Controls.Add(Me.Label1, 0, 0)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Enabled = False
        Me.tlpMain.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tlpMain.Location = New System.Drawing.Point(0, 53)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 2
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.Size = New System.Drawing.Size(784, 386)
        Me.tlpMain.TabIndex = 2
        '
        'lvTeacher
        '
        Me.lvTeacher.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lvTeacher.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lvTeacher.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvTeacher.FullRowSelect = True
        Me.lvTeacher.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvTeacher.Location = New System.Drawing.Point(3, 23)
        Me.lvTeacher.MultiSelect = False
        Me.lvTeacher.Name = "lvTeacher"
        Me.lvTeacher.Size = New System.Drawing.Size(386, 360)
        Me.lvTeacher.TabIndex = 5
        Me.lvTeacher.UseCompatibleStateImageBehavior = False
        Me.lvTeacher.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "教師IP　　　"
        Me.ColumnHeader1.Width = 124
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "教師姓名"
        Me.ColumnHeader2.Width = 88
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "教師登入時間"
        Me.ColumnHeader3.Width = 118
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(395, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(386, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "- 學生上線清單 -"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lvStudent
        '
        Me.lvStudent.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lvStudent.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.cohIp, Me.cohName, Me.cohTime})
        Me.lvStudent.ContextMenuStrip = Me.cmuRMenu
        Me.lvStudent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvStudent.FullRowSelect = True
        Me.lvStudent.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvStudent.Location = New System.Drawing.Point(395, 23)
        Me.lvStudent.MultiSelect = False
        Me.lvStudent.Name = "lvStudent"
        Me.lvStudent.Size = New System.Drawing.Size(386, 360)
        Me.lvStudent.TabIndex = 2
        Me.lvStudent.UseCompatibleStateImageBehavior = False
        Me.lvStudent.View = System.Windows.Forms.View.Details
        '
        'cohIp
        '
        Me.cohIp.Text = "學生IP　　　"
        Me.cohIp.Width = 124
        '
        'cohName
        '
        Me.cohName.Text = "學生姓名"
        Me.cohName.Width = 88
        '
        'cohTime
        '
        Me.cohTime.Text = "學生登入時間"
        Me.cohTime.Width = 118
        '
        'cmuRMenu
        '
        Me.cmuRMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuKickClient})
        Me.cmuRMenu.Name = "cmLsvClient"
        Me.cmuRMenu.Size = New System.Drawing.Size(125, 26)
        '
        'mnuKickClient
        '
        Me.mnuKickClient.Name = "mnuKickClient"
        Me.mnuKickClient.Size = New System.Drawing.Size(124, 22)
        Me.mnuKickClient.Text = "踢除連線"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(386, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "- 教師上線清單 -"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.lblTerm, Me.btnEditTerm})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 28)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(784, 25)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(80, 22)
        Me.ToolStripLabel1.Text = "當前學期別："
        '
        'btnEditTerm
        '
        Me.btnEditTerm.BackColor = System.Drawing.SystemColors.Info
        Me.btnEditTerm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnEditTerm.Image = CType(resources.GetObject("btnEditTerm.Image"), System.Drawing.Image)
        Me.btnEditTerm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEditTerm.Name = "btnEditTerm"
        Me.btnEditTerm.Size = New System.Drawing.Size(60, 22)
        Me.btnEditTerm.Text = "修改學期"
        '
        'lblTerm
        '
        Me.lblTerm.Font = New System.Drawing.Font("微軟正黑體", 12.0!)
        Me.lblTerm.Name = "lblTerm"
        Me.lblTerm.Size = New System.Drawing.Size(45, 22)
        Me.lblTerm.Text = "1041"
        '
        'frmServer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 462)
        Me.Controls.Add(Me.tlpMain)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.stpMain)
        Me.Controls.Add(Me.mnuMain)
        Me.MainMenuStrip = Me.mnuMain
        Me.MinimumSize = New System.Drawing.Size(800, 500)
        Me.Name = "frmServer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "課程輔助系統-伺服端"
        Me.stpMain.ResumeLayout(False)
        Me.stpMain.PerformLayout()
        Me.mnuMain.ResumeLayout(False)
        Me.mnuMain.PerformLayout()
        Me.tlpMain.ResumeLayout(False)
        Me.cmuRMenu.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents stpMain As System.Windows.Forms.StatusStrip
    Friend WithEvents tslLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslOnlineCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslSysTime As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents mnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents tsmFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmServer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuStart As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuStop As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewLog As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewHistory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmrSysTime As System.Windows.Forms.Timer
    Friend WithEvents tslStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lvStudent As System.Windows.Forms.ListView
    Friend WithEvents cohIp As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cohName As System.Windows.Forms.ColumnHeader
    Friend WithEvents cohTime As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvTeacher As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents tsmIp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmuRMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuKickClient As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmDataMang As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 教師帳號資訊ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 學生帳號資訊ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents 課程資訊ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblTerm As System.Windows.Forms.ToolStripLabel
    Friend WithEvents btnEditTerm As System.Windows.Forms.ToolStripButton

End Class
