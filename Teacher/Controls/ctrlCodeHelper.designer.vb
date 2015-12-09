<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlCodeHelper
    Inherits System.Windows.Forms.UserControl

    'UserControl 覆寫 Dispose 以清除元件清單。
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
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.lstMain = New System.Windows.Forms.ListBox()
        Me.mnuMain = New System.Windows.Forms.ToolStrip()
        Me.mnuExit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.pnlMain.SuspendLayout()
        Me.mnuMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.Controls.Add(Me.lstMain)
        Me.pnlMain.Controls.Add(Me.mnuMain)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Padding = New System.Windows.Forms.Padding(0, 0, 5, 5)
        Me.pnlMain.Size = New System.Drawing.Size(200, 200)
        Me.pnlMain.TabIndex = 3
        '
        'lstMain
        '
        Me.lstMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lstMain.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstMain.FormattingEnabled = True
        Me.lstMain.IntegralHeight = False
        Me.lstMain.ItemHeight = 12
        Me.lstMain.Location = New System.Drawing.Point(0, 25)
        Me.lstMain.Margin = New System.Windows.Forms.Padding(0)
        Me.lstMain.Name = "lstMain"
        Me.lstMain.Size = New System.Drawing.Size(195, 170)
        Me.lstMain.TabIndex = 1
        '
        'mnuMain
        '
        Me.mnuMain.BackColor = System.Drawing.SystemColors.Info
        Me.mnuMain.GripMargin = New System.Windows.Forms.Padding(0)
        Me.mnuMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuExit, Me.ToolStripLabel1})
        Me.mnuMain.Location = New System.Drawing.Point(0, 0)
        Me.mnuMain.Name = "mnuMain"
        Me.mnuMain.Padding = New System.Windows.Forms.Padding(0)
        Me.mnuMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.mnuMain.ShowItemToolTips = False
        Me.mnuMain.Size = New System.Drawing.Size(195, 25)
        Me.mnuMain.TabIndex = 0
        Me.mnuMain.Text = "ToolStrip1"
        '
        'mnuExit
        '
        Me.mnuExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.mnuExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuExit.Font = New System.Drawing.Font("微軟正黑體", 10.0!)
        Me.mnuExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(26, 22)
        Me.mnuExit.Text = "Ｘ"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(115, 22)
        Me.ToolStripLabel1.Text = "Enter取用；Esc離開"
        '
        'ctrlCodeHelper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Controls.Add(Me.pnlMain)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "ctrlCodeHelper"
        Me.Size = New System.Drawing.Size(200, 200)
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.mnuMain.ResumeLayout(False)
        Me.mnuMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents lstMain As System.Windows.Forms.ListBox
    Friend WithEvents mnuMain As System.Windows.Forms.ToolStrip
    Friend WithEvents mnuExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel

End Class
