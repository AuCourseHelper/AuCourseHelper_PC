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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTeacher))
        Me.mnuMain = New System.Windows.Forms.MenuStrip()
        Me.stpMain = New System.Windows.Forms.StatusStrip()
        Me.tslLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslUserName = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslSysTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.連線ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.登入ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.註冊ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.登出ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.帳號資訊ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.修改密碼ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.修改公開資訊ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.紀錄ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.檢視紀錄ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.查閱歷史紀錄檔ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.上傳記錄提供偵錯ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmIp = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.mnuMain.SuspendLayout()
        Me.stpMain.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuMain
        '
        Me.mnuMain.Font = New System.Drawing.Font("微軟正黑體", 12.0!)
        Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.連線ToolStripMenuItem, Me.帳號資訊ToolStripMenuItem, Me.ToolStripMenuItem2, Me.紀錄ToolStripMenuItem, Me.tsmIp})
        Me.mnuMain.Location = New System.Drawing.Point(0, 0)
        Me.mnuMain.Name = "mnuMain"
        Me.mnuMain.Size = New System.Drawing.Size(784, 28)
        Me.mnuMain.TabIndex = 0
        Me.mnuMain.Text = "MenuStrip1"
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
        Me.tslStatus.Size = New System.Drawing.Size(584, 18)
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
        Me.ToolStrip1.Font = New System.Drawing.Font("微軟正黑體", 14.0!)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripSeparator1, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripButton5})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 28)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(784, 31)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "tlsMain"
        '
        '連線ToolStripMenuItem
        '
        Me.連線ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.登入ToolStripMenuItem, Me.註冊ToolStripMenuItem, Me.登出ToolStripMenuItem})
        Me.連線ToolStripMenuItem.Name = "連線ToolStripMenuItem"
        Me.連線ToolStripMenuItem.Size = New System.Drawing.Size(53, 24)
        Me.連線ToolStripMenuItem.Text = "連線"
        '
        '登入ToolStripMenuItem
        '
        Me.登入ToolStripMenuItem.Name = "登入ToolStripMenuItem"
        Me.登入ToolStripMenuItem.Size = New System.Drawing.Size(152, 24)
        Me.登入ToolStripMenuItem.Text = "登入"
        '
        '註冊ToolStripMenuItem
        '
        Me.註冊ToolStripMenuItem.Name = "註冊ToolStripMenuItem"
        Me.註冊ToolStripMenuItem.Size = New System.Drawing.Size(152, 24)
        Me.註冊ToolStripMenuItem.Text = "註冊"
        '
        '登出ToolStripMenuItem
        '
        Me.登出ToolStripMenuItem.Name = "登出ToolStripMenuItem"
        Me.登出ToolStripMenuItem.Size = New System.Drawing.Size(152, 24)
        Me.登出ToolStripMenuItem.Text = "登出"
        '
        '帳號資訊ToolStripMenuItem
        '
        Me.帳號資訊ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.修改密碼ToolStripMenuItem, Me.修改公開資訊ToolStripMenuItem})
        Me.帳號資訊ToolStripMenuItem.Name = "帳號資訊ToolStripMenuItem"
        Me.帳號資訊ToolStripMenuItem.Size = New System.Drawing.Size(85, 24)
        Me.帳號資訊ToolStripMenuItem.Text = "帳號資訊"
        '
        '修改密碼ToolStripMenuItem
        '
        Me.修改密碼ToolStripMenuItem.Name = "修改密碼ToolStripMenuItem"
        Me.修改密碼ToolStripMenuItem.Size = New System.Drawing.Size(174, 24)
        Me.修改密碼ToolStripMenuItem.Text = "修改密碼"
        '
        '修改公開資訊ToolStripMenuItem
        '
        Me.修改公開資訊ToolStripMenuItem.Name = "修改公開資訊ToolStripMenuItem"
        Me.修改公開資訊ToolStripMenuItem.Size = New System.Drawing.Size(174, 24)
        Me.修改公開資訊ToolStripMenuItem.Text = "修改公開資訊"
        '
        '紀錄ToolStripMenuItem
        '
        Me.紀錄ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.檢視紀錄ToolStripMenuItem, Me.查閱歷史紀錄檔ToolStripMenuItem, Me.ToolStripMenuItem1, Me.上傳記錄提供偵錯ToolStripMenuItem})
        Me.紀錄ToolStripMenuItem.Name = "紀錄ToolStripMenuItem"
        Me.紀錄ToolStripMenuItem.Size = New System.Drawing.Size(53, 24)
        Me.紀錄ToolStripMenuItem.Text = "紀錄"
        '
        '檢視紀錄ToolStripMenuItem
        '
        Me.檢視紀錄ToolStripMenuItem.Name = "檢視紀錄ToolStripMenuItem"
        Me.檢視紀錄ToolStripMenuItem.Size = New System.Drawing.Size(206, 24)
        Me.檢視紀錄ToolStripMenuItem.Text = "檢視紀錄"
        '
        '查閱歷史紀錄檔ToolStripMenuItem
        '
        Me.查閱歷史紀錄檔ToolStripMenuItem.Name = "查閱歷史紀錄檔ToolStripMenuItem"
        Me.查閱歷史紀錄檔ToolStripMenuItem.Size = New System.Drawing.Size(206, 24)
        Me.查閱歷史紀錄檔ToolStripMenuItem.Text = "查閱歷史紀錄檔"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(203, 6)
        '
        '上傳記錄提供偵錯ToolStripMenuItem
        '
        Me.上傳記錄提供偵錯ToolStripMenuItem.Name = "上傳記錄提供偵錯ToolStripMenuItem"
        Me.上傳記錄提供偵錯ToolStripMenuItem.Size = New System.Drawing.Size(206, 24)
        Me.上傳記錄提供偵錯ToolStripMenuItem.Text = "上傳記錄提供偵錯"
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
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(85, 24)
        Me.ToolStripMenuItem2.Text = "課程資訊"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(86, 28)
        Me.ToolStripLabel1.Text = "課程名稱"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(68, 28)
        Me.ToolStripButton1.Text = "點名"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(68, 28)
        Me.ToolStripButton2.Text = "評分"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(106, 28)
        Me.ToolStripButton3.Text = "建立作業"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(106, 28)
        Me.ToolStripButton4.Text = "建立考試"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(106, 28)
        Me.ToolStripButton5.Text = "統計報表"
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
        Me.Name = "frmTeacher"
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
    Friend WithEvents 連線ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 登入ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 註冊ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 登出ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 帳號資訊ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 修改密碼ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 修改公開資訊ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 紀錄ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 檢視紀錄ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 查閱歷史紀錄檔ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents 上傳記錄提供偵錯ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmIp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents pnlMain As System.Windows.Forms.Panel

End Class
