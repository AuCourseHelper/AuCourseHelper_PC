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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.stpMain.SuspendLayout()
        Me.mnuMain.SuspendLayout()
        Me.tlpMain.SuspendLayout()
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
        Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmFile, Me.tsmServer, Me.tsmReport, Me.tsmIp})
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
        Me.mnuViewLog.Text = "檢視記錄"
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
        Me.tlpMain.Location = New System.Drawing.Point(0, 28)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 2
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.Size = New System.Drawing.Size(784, 411)
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
        Me.lvTeacher.Size = New System.Drawing.Size(386, 385)
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
        Me.lvStudent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvStudent.FullRowSelect = True
        Me.lvStudent.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvStudent.Location = New System.Drawing.Point(395, 23)
        Me.lvStudent.MultiSelect = False
        Me.lvStudent.Name = "lvStudent"
        Me.lvStudent.Size = New System.Drawing.Size(386, 385)
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
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(386, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "- 教師上線清單 -"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmServer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 462)
        Me.Controls.Add(Me.tlpMain)
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

End Class
