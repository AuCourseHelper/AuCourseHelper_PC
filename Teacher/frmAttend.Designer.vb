<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAttend
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
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tabTable = New System.Windows.Forms.TabPage()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.tblMain = New System.Windows.Forms.DataGridView()
        Me.tabSeat = New System.Windows.Forms.TabPage()
        Me.pnlMain_seat = New System.Windows.Forms.Panel()
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.tabMain.SuspendLayout()
        Me.tabTable.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        CType(Me.tblMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabSeat.SuspendLayout()
        Me.pnlButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.tabTable)
        Me.tabMain.Controls.Add(Me.tabSeat)
        Me.tabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabMain.Location = New System.Drawing.Point(0, 0)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(768, 391)
        Me.tabMain.TabIndex = 0
        '
        'tabTable
        '
        Me.tabTable.Controls.Add(Me.pnlMain)
        Me.tabTable.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.tabTable.Location = New System.Drawing.Point(4, 22)
        Me.tabTable.Name = "tabTable"
        Me.tabTable.Padding = New System.Windows.Forms.Padding(3)
        Me.tabTable.Size = New System.Drawing.Size(760, 365)
        Me.tabTable.TabIndex = 0
        Me.tabTable.Text = "表格檢視"
        Me.tabTable.UseVisualStyleBackColor = True
        '
        'pnlMain
        '
        Me.pnlMain.Controls.Add(Me.tblMain)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(3, 3)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(754, 359)
        Me.pnlMain.TabIndex = 0
        '
        'tblMain
        '
        Me.tblMain.AllowUserToAddRows = False
        Me.tblMain.AllowUserToDeleteRows = False
        Me.tblMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMain.Location = New System.Drawing.Point(0, 0)
        Me.tblMain.Name = "tblMain"
        Me.tblMain.RowTemplate.Height = 24
        Me.tblMain.Size = New System.Drawing.Size(754, 359)
        Me.tblMain.TabIndex = 0
        '
        'tabSeat
        '
        Me.tabSeat.Controls.Add(Me.pnlMain_seat)
        Me.tabSeat.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.tabSeat.Location = New System.Drawing.Point(4, 22)
        Me.tabSeat.Name = "tabSeat"
        Me.tabSeat.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSeat.Size = New System.Drawing.Size(760, 365)
        Me.tabSeat.TabIndex = 1
        Me.tabSeat.Text = "座位表檢視"
        Me.tabSeat.UseVisualStyleBackColor = True
        '
        'pnlMain_seat
        '
        Me.pnlMain_seat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain_seat.Location = New System.Drawing.Point(3, 3)
        Me.pnlMain_seat.Name = "pnlMain_seat"
        Me.pnlMain_seat.Size = New System.Drawing.Size(754, 359)
        Me.pnlMain_seat.TabIndex = 1
        '
        'pnlButtons
        '
        Me.pnlButtons.BackColor = System.Drawing.SystemColors.Control
        Me.pnlButtons.Controls.Add(Me.Button2)
        Me.pnlButtons.Controls.Add(Me.Button1)
        Me.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlButtons.Location = New System.Drawing.Point(0, 391)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(768, 50)
        Me.pnlButtons.TabIndex = 2
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(95, 7)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(13, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmAttend
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(768, 441)
        Me.Controls.Add(Me.tabMain)
        Me.Controls.Add(Me.pnlButtons)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmAttend"
        Me.Text = "frmAttend"
        Me.tabMain.ResumeLayout(False)
        Me.tabTable.ResumeLayout(False)
        Me.pnlMain.ResumeLayout(False)
        CType(Me.tblMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabSeat.ResumeLayout(False)
        Me.pnlButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents tabTable As System.Windows.Forms.TabPage
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents tabSeat As System.Windows.Forms.TabPage
    Friend WithEvents pnlMain_seat As System.Windows.Forms.Panel
    Friend WithEvents pnlButtons As System.Windows.Forms.Panel
    Friend WithEvents tblMain As System.Windows.Forms.DataGridView
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
