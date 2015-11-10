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
        Me.pnlBtn = New System.Windows.Forms.TableLayoutPanel()
        Me.btnAtt = New System.Windows.Forms.Button()
        Me.btnAbs = New System.Windows.Forms.Button()
        Me.tblMain = New System.Windows.Forms.DataGridView()
        Me.tabSeat = New System.Windows.Forms.TabPage()
        Me.cmsSeat = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.rotate = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnLat = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.pnlBtn2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.pnlMain2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tabMain.SuspendLayout()
        Me.tabTable.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        Me.pnlBtn.SuspendLayout()
        CType(Me.tblMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabSeat.SuspendLayout()
        Me.cmsSeat.SuspendLayout()
        Me.pnlBtn2.SuspendLayout()
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
        Me.tabTable.Controls.Add(Me.pnlBtn)
        Me.tabTable.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.tabTable.Location = New System.Drawing.Point(4, 26)
        Me.tabTable.Name = "tabTable"
        Me.tabTable.Padding = New System.Windows.Forms.Padding(3)
        Me.tabTable.Size = New System.Drawing.Size(792, 570)
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
        Me.pnlMain.Size = New System.Drawing.Size(686, 564)
        Me.pnlMain.TabIndex = 0
        '
        'pnlBtn
        '
        Me.pnlBtn.ColumnCount = 1
        Me.pnlBtn.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlBtn.Controls.Add(Me.btnLat, 0, 1)
        Me.pnlBtn.Controls.Add(Me.btnAtt, 0, 0)
        Me.pnlBtn.Controls.Add(Me.btnAbs, 0, 2)
        Me.pnlBtn.Controls.Add(Me.btnSave, 0, 4)
        Me.pnlBtn.Controls.Add(Me.btnCancel, 0, 5)
        Me.pnlBtn.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBtn.Location = New System.Drawing.Point(689, 3)
        Me.pnlBtn.Name = "pnlBtn"
        Me.pnlBtn.RowCount = 6
        Me.pnlBtn.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.pnlBtn.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.pnlBtn.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.pnlBtn.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.pnlBtn.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.pnlBtn.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.pnlBtn.Size = New System.Drawing.Size(100, 564)
        Me.pnlBtn.TabIndex = 2
        '
        'btnAtt
        '
        Me.btnAtt.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnAtt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAtt.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnAtt.Location = New System.Drawing.Point(3, 3)
        Me.btnAtt.Name = "btnAtt"
        Me.btnAtt.Size = New System.Drawing.Size(94, 78)
        Me.btnAtt.TabIndex = 0
        Me.btnAtt.Text = "出　席"
        Me.btnAtt.UseVisualStyleBackColor = False
        '
        'btnAbs
        '
        Me.btnAbs.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnAbs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAbs.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnAbs.Location = New System.Drawing.Point(3, 171)
        Me.btnAbs.Name = "btnAbs"
        Me.btnAbs.Size = New System.Drawing.Size(94, 78)
        Me.btnAbs.TabIndex = 1
        Me.btnAbs.Text = "缺　席"
        Me.btnAbs.UseVisualStyleBackColor = False
        '
        'tblMain
        '
        Me.tblMain.AllowUserToAddRows = False
        Me.tblMain.AllowUserToDeleteRows = False
        Me.tblMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMain.Location = New System.Drawing.Point(0, 0)
        Me.tblMain.MultiSelect = False
        Me.tblMain.Name = "tblMain"
        Me.tblMain.ReadOnly = True
        Me.tblMain.RowTemplate.Height = 24
        Me.tblMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tblMain.Size = New System.Drawing.Size(686, 564)
        Me.tblMain.TabIndex = 0
        '
        'tabSeat
        '
        Me.tabSeat.AutoScroll = True
        Me.tabSeat.ContextMenuStrip = Me.cmsSeat
        Me.tabSeat.Controls.Add(Me.pnlMain2)
        Me.tabSeat.Controls.Add(Me.pnlBtn2)
        Me.tabSeat.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.tabSeat.Location = New System.Drawing.Point(4, 26)
        Me.tabSeat.Name = "tabSeat"
        Me.tabSeat.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSeat.Size = New System.Drawing.Size(792, 570)
        Me.tabSeat.TabIndex = 1
        Me.tabSeat.Text = "座位表檢視"
        Me.tabSeat.UseVisualStyleBackColor = True
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
        Me.rotate.Size = New System.Drawing.Size(142, 24)
        Me.rotate.Text = "座位反轉"
        '
        'btnLat
        '
        Me.btnLat.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnLat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnLat.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnLat.Location = New System.Drawing.Point(3, 87)
        Me.btnLat.Name = "btnLat"
        Me.btnLat.Size = New System.Drawing.Size(94, 78)
        Me.btnLat.TabIndex = 2
        Me.btnLat.Text = "遲　到"
        Me.btnLat.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSave.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnSave.Image = Global.AUCourseHelper_Teacher.My.Resources.Resources.save
        Me.btnSave.Location = New System.Drawing.Point(3, 339)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(94, 106)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "儲存"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCancel.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnCancel.Image = Global.AUCourseHelper_Teacher.My.Resources.Resources.cancel
        Me.btnCancel.Location = New System.Drawing.Point(3, 451)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(94, 110)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "放棄"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'pnlBtn2
        '
        Me.pnlBtn2.ColumnCount = 5
        Me.pnlBtn2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.pnlBtn2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.pnlBtn2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.pnlBtn2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.pnlBtn2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.pnlBtn2.Controls.Add(Me.Button1, 3, 0)
        Me.pnlBtn2.Controls.Add(Me.Button2, 4, 0)
        Me.pnlBtn2.Controls.Add(Me.Label1, 0, 0)
        Me.pnlBtn2.Controls.Add(Me.Label2, 1, 0)
        Me.pnlBtn2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBtn2.Location = New System.Drawing.Point(3, 517)
        Me.pnlBtn2.Name = "pnlBtn2"
        Me.pnlBtn2.RowCount = 1
        Me.pnlBtn2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlBtn2.Size = New System.Drawing.Size(786, 50)
        Me.pnlBtn2.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button1.Image = Global.AUCourseHelper_Teacher.My.Resources.Resources.save
        Me.Button1.Location = New System.Drawing.Point(474, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(151, 44)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "儲存"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button2.Image = Global.AUCourseHelper_Teacher.My.Resources.Resources.cancel
        Me.Button2.Location = New System.Drawing.Point(631, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(152, 44)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "放棄"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = True
        '
        'pnlMain2
        '
        Me.pnlMain2.AutoScroll = True
        Me.pnlMain2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain2.Location = New System.Drawing.Point(3, 3)
        Me.pnlMain2.Name = "pnlMain2"
        Me.pnlMain2.Size = New System.Drawing.Size(786, 514)
        Me.pnlMain2.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(151, 50)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "目前週次：第    週"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(160, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(151, 50)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "尚有 0 位學生" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "未編排座位"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.pnlBtn.ResumeLayout(False)
        CType(Me.tblMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabSeat.ResumeLayout(False)
        Me.cmsSeat.ResumeLayout(False)
        Me.pnlBtn2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents tabTable As System.Windows.Forms.TabPage
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents tabSeat As System.Windows.Forms.TabPage
    Friend WithEvents tblMain As System.Windows.Forms.DataGridView
    Friend WithEvents btnAbs As System.Windows.Forms.Button
    Friend WithEvents btnAtt As System.Windows.Forms.Button
    Friend WithEvents pnlBtn As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmsSeat As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents rotate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnLat As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents pnlBtn2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents pnlMain2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
