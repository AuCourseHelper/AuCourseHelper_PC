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
        Me.components = New System.ComponentModel.Container()
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tabTable = New System.Windows.Forms.TabPage()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.tblMain = New System.Windows.Forms.DataGridView()
        Me.tabSeat = New System.Windows.Forms.TabPage()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pnlBtn = New System.Windows.Forms.TableLayoutPanel()
        Me.cmsSeat = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.rotate = New System.Windows.Forms.ToolStripMenuItem()
        Me.tabMain.SuspendLayout()
        Me.tabTable.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        CType(Me.tblMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBtn.SuspendLayout()
        Me.cmsSeat.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.tabTable)
        Me.tabMain.Controls.Add(Me.tabSeat)
        Me.tabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabMain.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.tabMain.ItemSize = New System.Drawing.Size(200, 22)
        Me.tabMain.Location = New System.Drawing.Point(0, 0)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.Padding = New System.Drawing.Point(10, 3)
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(800, 600)
        Me.tabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabMain.TabIndex = 0
        '
        'tabTable
        '
        Me.tabTable.Controls.Add(Me.pnlMain)
        Me.tabTable.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.tabTable.Location = New System.Drawing.Point(4, 26)
        Me.tabTable.Name = "tabTable"
        Me.tabTable.Padding = New System.Windows.Forms.Padding(3)
        Me.tabTable.Size = New System.Drawing.Size(1016, 738)
        Me.tabTable.TabIndex = 0
        Me.tabTable.Text = "表格檢視"
        Me.tabTable.UseVisualStyleBackColor = True
        '
        'pnlMain
        '
        Me.pnlMain.Controls.Add(Me.pnlBtn)
        Me.pnlMain.Controls.Add(Me.tblMain)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(3, 3)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(1010, 732)
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
        Me.tblMain.Size = New System.Drawing.Size(1010, 732)
        Me.tblMain.TabIndex = 0
        '
        'tabSeat
        '
        Me.tabSeat.AutoScroll = True
        Me.tabSeat.ContextMenuStrip = Me.cmsSeat
        Me.tabSeat.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.tabSeat.Location = New System.Drawing.Point(4, 26)
        Me.tabSeat.Name = "tabSeat"
        Me.tabSeat.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSeat.Size = New System.Drawing.Size(792, 570)
        Me.tabSeat.TabIndex = 1
        Me.tabSeat.Text = "座位表檢視"
        Me.tabSeat.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button2.Location = New System.Drawing.Point(205, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(196, 29)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button1.Location = New System.Drawing.Point(3, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(196, 29)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'pnlBtn
        '
        Me.pnlBtn.ColumnCount = 5
        Me.pnlBtn.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.pnlBtn.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.pnlBtn.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.pnlBtn.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.pnlBtn.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.pnlBtn.Controls.Add(Me.Button1, 0, 0)
        Me.pnlBtn.Controls.Add(Me.Button2, 1, 0)
        Me.pnlBtn.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBtn.Location = New System.Drawing.Point(0, 697)
        Me.pnlBtn.Name = "pnlBtn"
        Me.pnlBtn.RowCount = 1
        Me.pnlBtn.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlBtn.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlBtn.Size = New System.Drawing.Size(1010, 35)
        Me.pnlBtn.TabIndex = 2
        '
        'cmsSeat
        '
        Me.cmsSeat.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmsSeat.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.rotate})
        Me.cmsSeat.Name = "cmsSeat"
        Me.cmsSeat.Size = New System.Drawing.Size(143, 28)
        '
        'rotate
        '
        Me.rotate.Name = "rotate"
        Me.rotate.Size = New System.Drawing.Size(152, 22)
        Me.rotate.Text = "座位反轉"
        '
        'frmAttend
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 600)
        Me.Controls.Add(Me.tabMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmAttend"
        Me.Text = "frmAttend"
        Me.tabMain.ResumeLayout(False)
        Me.tabTable.ResumeLayout(False)
        Me.pnlMain.ResumeLayout(False)
        CType(Me.tblMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBtn.ResumeLayout(False)
        Me.cmsSeat.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents tabTable As System.Windows.Forms.TabPage
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents tabSeat As System.Windows.Forms.TabPage
    Friend WithEvents tblMain As System.Windows.Forms.DataGridView
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents pnlBtn As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmsSeat As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents rotate As System.Windows.Forms.ToolStripMenuItem
End Class
