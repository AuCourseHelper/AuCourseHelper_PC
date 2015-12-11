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
        Me.pnlBtn = New System.Windows.Forms.TableLayoutPanel()
        Me.btnAtt = New System.Windows.Forms.Button()
        Me.btnAbs = New System.Windows.Forms.Button()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.pnlBtnSub = New System.Windows.Forms.TableLayoutPanel()
        Me.btnOffPublic = New System.Windows.Forms.Button()
        Me.btnOffThing = New System.Windows.Forms.Button()
        Me.btnOffSick = New System.Windows.Forms.Button()
        Me.btnLat = New System.Windows.Forms.Button()
        Me.tabSeat = New System.Windows.Forms.TabPage()
        Me.pnlMain2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCreateSeat = New System.Windows.Forms.Button()
        Me.pnlControl2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblDate2 = New System.Windows.Forms.Label()
        Me.lblNoSeat = New System.Windows.Forms.Label()
        Me.pnlBtn2 = New System.Windows.Forms.TableLayoutPanel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblHelp = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnCancel2 = New System.Windows.Forms.Button()
        Me.btnSave2 = New System.Windows.Forms.Button()
        Me.btnChangeView = New System.Windows.Forms.Button()
        Me.tabMain.SuspendLayout()
        Me.tabTable.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        CType(Me.tblMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBtn.SuspendLayout()
        Me.pnlBtnSub.SuspendLayout()
        Me.tabSeat.SuspendLayout()
        Me.pnlMain2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.pnlControl2.SuspendLayout()
        Me.pnlBtn2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
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
        Me.tabMain.Size = New System.Drawing.Size(800, 578)
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
        Me.tabTable.Size = New System.Drawing.Size(792, 548)
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
        Me.pnlMain.Size = New System.Drawing.Size(686, 542)
        Me.pnlMain.TabIndex = 0
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
        Me.tblMain.Size = New System.Drawing.Size(686, 542)
        Me.tblMain.TabIndex = 0
        '
        'pnlBtn
        '
        Me.pnlBtn.ColumnCount = 1
        Me.pnlBtn.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlBtn.Controls.Add(Me.btnAtt, 0, 0)
        Me.pnlBtn.Controls.Add(Me.btnAbs, 0, 2)
        Me.pnlBtn.Controls.Add(Me.btnSave, 0, 4)
        Me.pnlBtn.Controls.Add(Me.btnCancel, 0, 5)
        Me.pnlBtn.Controls.Add(Me.lblDate, 0, 3)
        Me.pnlBtn.Controls.Add(Me.pnlBtnSub, 0, 1)
        Me.pnlBtn.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBtn.Location = New System.Drawing.Point(689, 3)
        Me.pnlBtn.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlBtn.Name = "pnlBtn"
        Me.pnlBtn.RowCount = 6
        Me.pnlBtn.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.pnlBtn.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.0!))
        Me.pnlBtn.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.pnlBtn.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.pnlBtn.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.pnlBtn.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.pnlBtn.Size = New System.Drawing.Size(100, 542)
        Me.pnlBtn.TabIndex = 2
        '
        'btnAtt
        '
        Me.btnAtt.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnAtt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAtt.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnAtt.Location = New System.Drawing.Point(3, 3)
        Me.btnAtt.Name = "btnAtt"
        Me.btnAtt.Size = New System.Drawing.Size(94, 59)
        Me.btnAtt.TabIndex = 0
        Me.btnAtt.Text = "出　席"
        Me.btnAtt.UseVisualStyleBackColor = False
        '
        'btnAbs
        '
        Me.btnAbs.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnAbs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAbs.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnAbs.Location = New System.Drawing.Point(3, 208)
        Me.btnAbs.Name = "btnAbs"
        Me.btnAbs.Size = New System.Drawing.Size(94, 59)
        Me.btnAbs.TabIndex = 1
        Me.btnAbs.Text = "缺　席"
        Me.btnAbs.UseVisualStyleBackColor = False
        '
        'lblDate
        '
        Me.lblDate.BackColor = System.Drawing.SystemColors.Info
        Me.lblDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDate.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblDate.Location = New System.Drawing.Point(3, 270)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(94, 108)
        Me.lblDate.TabIndex = 5
        Me.lblDate.Text = "104-1" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "第 X 週"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlBtnSub
        '
        Me.pnlBtnSub.ColumnCount = 2
        Me.pnlBtnSub.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.pnlBtnSub.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.pnlBtnSub.Controls.Add(Me.btnOffPublic, 0, 2)
        Me.pnlBtnSub.Controls.Add(Me.btnOffThing, 0, 1)
        Me.pnlBtnSub.Controls.Add(Me.btnOffSick, 0, 0)
        Me.pnlBtnSub.Controls.Add(Me.btnLat, 1, 0)
        Me.pnlBtnSub.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBtnSub.Location = New System.Drawing.Point(0, 65)
        Me.pnlBtnSub.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlBtnSub.Name = "pnlBtnSub"
        Me.pnlBtnSub.RowCount = 3
        Me.pnlBtnSub.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.pnlBtnSub.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.pnlBtnSub.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.pnlBtnSub.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlBtnSub.Size = New System.Drawing.Size(100, 140)
        Me.pnlBtnSub.TabIndex = 6
        '
        'btnOffPublic
        '
        Me.btnOffPublic.BackColor = System.Drawing.Color.LightGray
        Me.btnOffPublic.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnOffPublic.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnOffPublic.Location = New System.Drawing.Point(3, 95)
        Me.btnOffPublic.Name = "btnOffPublic"
        Me.btnOffPublic.Size = New System.Drawing.Size(44, 42)
        Me.btnOffPublic.TabIndex = 9
        Me.btnOffPublic.Text = "公"
        Me.btnOffPublic.UseVisualStyleBackColor = False
        '
        'btnOffThing
        '
        Me.btnOffThing.BackColor = System.Drawing.Color.LightGray
        Me.btnOffThing.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnOffThing.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnOffThing.Location = New System.Drawing.Point(3, 49)
        Me.btnOffThing.Name = "btnOffThing"
        Me.btnOffThing.Size = New System.Drawing.Size(44, 40)
        Me.btnOffThing.TabIndex = 8
        Me.btnOffThing.Text = "事"
        Me.btnOffThing.UseVisualStyleBackColor = False
        '
        'btnOffSick
        '
        Me.btnOffSick.BackColor = System.Drawing.Color.Gainsboro
        Me.btnOffSick.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnOffSick.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnOffSick.Location = New System.Drawing.Point(3, 3)
        Me.btnOffSick.Name = "btnOffSick"
        Me.btnOffSick.Size = New System.Drawing.Size(44, 40)
        Me.btnOffSick.TabIndex = 7
        Me.btnOffSick.Text = "病"
        Me.btnOffSick.UseVisualStyleBackColor = False
        '
        'btnLat
        '
        Me.btnLat.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnLat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnLat.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnLat.Location = New System.Drawing.Point(53, 3)
        Me.btnLat.Name = "btnLat"
        Me.pnlBtnSub.SetRowSpan(Me.btnLat, 3)
        Me.btnLat.Size = New System.Drawing.Size(44, 134)
        Me.btnLat.TabIndex = 6
        Me.btnLat.Text = "遲　到"
        Me.btnLat.UseVisualStyleBackColor = False
        '
        'tabSeat
        '
        Me.tabSeat.AutoScroll = True
        Me.tabSeat.Controls.Add(Me.pnlMain2)
        Me.tabSeat.Controls.Add(Me.pnlControl2)
        Me.tabSeat.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.tabSeat.Location = New System.Drawing.Point(4, 26)
        Me.tabSeat.Name = "tabSeat"
        Me.tabSeat.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSeat.Size = New System.Drawing.Size(792, 548)
        Me.tabSeat.TabIndex = 1
        Me.tabSeat.Text = "座位表檢視"
        Me.tabSeat.UseVisualStyleBackColor = True
        '
        'pnlMain2
        '
        Me.pnlMain2.AutoScroll = True
        Me.pnlMain2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.pnlMain2.Controls.Add(Me.TableLayoutPanel1)
        Me.pnlMain2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain2.Location = New System.Drawing.Point(3, 3)
        Me.pnlMain2.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlMain2.Name = "pnlMain2"
        Me.pnlMain2.Size = New System.Drawing.Size(786, 492)
        Me.pnlMain2.TabIndex = 1
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCreateSeat, 1, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(786, 492)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("新細明體", 14.0!)
        Me.Label1.Location = New System.Drawing.Point(265, 164)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(256, 164)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "本課程尚未建立學生座位表"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCreateSeat
        '
        Me.btnCreateSeat.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnCreateSeat.Location = New System.Drawing.Point(265, 331)
        Me.btnCreateSeat.Name = "btnCreateSeat"
        Me.btnCreateSeat.Size = New System.Drawing.Size(256, 66)
        Me.btnCreateSeat.TabIndex = 1
        Me.btnCreateSeat.Text = "建立座位表"
        Me.btnCreateSeat.UseVisualStyleBackColor = True
        '
        'pnlControl2
        '
        Me.pnlControl2.ColumnCount = 4
        Me.pnlControl2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.pnlControl2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.pnlControl2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.pnlControl2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.pnlControl2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlControl2.Controls.Add(Me.lblDate2, 0, 0)
        Me.pnlControl2.Controls.Add(Me.lblNoSeat, 1, 0)
        Me.pnlControl2.Controls.Add(Me.pnlBtn2, 3, 0)
        Me.pnlControl2.Controls.Add(Me.btnChangeView, 2, 0)
        Me.pnlControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlControl2.Enabled = False
        Me.pnlControl2.Location = New System.Drawing.Point(3, 495)
        Me.pnlControl2.Name = "pnlControl2"
        Me.pnlControl2.RowCount = 1
        Me.pnlControl2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlControl2.Size = New System.Drawing.Size(786, 50)
        Me.pnlControl2.TabIndex = 0
        '
        'lblDate2
        '
        Me.lblDate2.BackColor = System.Drawing.SystemColors.Info
        Me.lblDate2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDate2.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblDate2.Location = New System.Drawing.Point(3, 0)
        Me.lblDate2.Name = "lblDate2"
        Me.lblDate2.Size = New System.Drawing.Size(151, 50)
        Me.lblDate2.TabIndex = 6
        Me.lblDate2.Text = "104-1" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "第 X 週"
        Me.lblDate2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNoSeat
        '
        Me.lblNoSeat.Cursor = System.Windows.Forms.Cursors.Help
        Me.lblNoSeat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNoSeat.ForeColor = System.Drawing.Color.Red
        Me.lblNoSeat.Location = New System.Drawing.Point(160, 0)
        Me.lblNoSeat.Name = "lblNoSeat"
        Me.lblNoSeat.Size = New System.Drawing.Size(151, 50)
        Me.lblNoSeat.TabIndex = 3
        Me.lblNoSeat.Text = "尚有 0 位學生" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "未編排座位"
        Me.lblNoSeat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlBtn2
        '
        Me.pnlBtn2.ColumnCount = 2
        Me.pnlBtn2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.pnlBtn2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.pnlBtn2.Controls.Add(Me.btnCancel2, 0, 0)
        Me.pnlBtn2.Controls.Add(Me.btnSave2, 0, 0)
        Me.pnlBtn2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBtn2.Location = New System.Drawing.Point(471, 0)
        Me.pnlBtn2.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlBtn2.Name = "pnlBtn2"
        Me.pnlBtn2.RowCount = 1
        Me.pnlBtn2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.pnlBtn2.Size = New System.Drawing.Size(315, 50)
        Me.pnlBtn2.TabIndex = 2
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblHelp})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 578)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(800, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblHelp
        '
        Me.lblHelp.Name = "lblHelp"
        Me.lblHelp.Size = New System.Drawing.Size(32, 17)
        Me.lblHelp.Text = "說明"
        '
        'btnSave
        '
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSave.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnSave.Image = Global.AUCourseHelper_Teacher.My.Resources.Resources.save
        Me.btnSave.Location = New System.Drawing.Point(3, 381)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(94, 75)
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
        Me.btnCancel.Location = New System.Drawing.Point(3, 462)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(94, 77)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "放棄"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnCancel2
        '
        Me.btnCancel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCancel2.Image = Global.AUCourseHelper_Teacher.My.Resources.Resources.cancel
        Me.btnCancel2.Location = New System.Drawing.Point(160, 3)
        Me.btnCancel2.Name = "btnCancel2"
        Me.btnCancel2.Size = New System.Drawing.Size(152, 44)
        Me.btnCancel2.TabIndex = 2
        Me.btnCancel2.Text = "放棄"
        Me.btnCancel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel2.UseVisualStyleBackColor = True
        '
        'btnSave2
        '
        Me.btnSave2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSave2.Image = Global.AUCourseHelper_Teacher.My.Resources.Resources.save
        Me.btnSave2.Location = New System.Drawing.Point(3, 3)
        Me.btnSave2.Name = "btnSave2"
        Me.btnSave2.Size = New System.Drawing.Size(151, 44)
        Me.btnSave2.TabIndex = 1
        Me.btnSave2.Text = "儲存"
        Me.btnSave2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave2.UseVisualStyleBackColor = True
        '
        'btnChangeView
        '
        Me.btnChangeView.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnChangeView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnChangeView.Image = Global.AUCourseHelper_Teacher.My.Resources.Resources.update
        Me.btnChangeView.Location = New System.Drawing.Point(317, 3)
        Me.btnChangeView.Name = "btnChangeView"
        Me.btnChangeView.Size = New System.Drawing.Size(151, 44)
        Me.btnChangeView.TabIndex = 7
        Me.btnChangeView.Text = "切換" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "視角"
        Me.btnChangeView.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnChangeView.UseVisualStyleBackColor = False
        '
        'frmAttend
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 600)
        Me.Controls.Add(Me.tabMain)
        Me.Controls.Add(Me.StatusStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmAttend"
        Me.Text = "frmAttend"
        Me.tabMain.ResumeLayout(False)
        Me.tabTable.ResumeLayout(False)
        Me.pnlMain.ResumeLayout(False)
        CType(Me.tblMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBtn.ResumeLayout(False)
        Me.pnlBtnSub.ResumeLayout(False)
        Me.tabSeat.ResumeLayout(False)
        Me.pnlMain2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.pnlControl2.ResumeLayout(False)
        Me.pnlBtn2.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents tabTable As System.Windows.Forms.TabPage
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents tabSeat As System.Windows.Forms.TabPage
    Friend WithEvents tblMain As System.Windows.Forms.DataGridView
    Friend WithEvents btnAbs As System.Windows.Forms.Button
    Friend WithEvents btnAtt As System.Windows.Forms.Button
    Friend WithEvents pnlBtn As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents pnlControl2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlMain2 As System.Windows.Forms.Panel
    Friend WithEvents lblNoSeat As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents lblDate2 As System.Windows.Forms.Label
    Friend WithEvents btnChangeView As System.Windows.Forms.Button
    Friend WithEvents pnlBtnSub As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnLat As System.Windows.Forms.Button
    Friend WithEvents btnOffPublic As System.Windows.Forms.Button
    Friend WithEvents btnOffThing As System.Windows.Forms.Button
    Friend WithEvents btnOffSick As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCreateSeat As System.Windows.Forms.Button
    Friend WithEvents pnlBtn2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnCancel2 As System.Windows.Forms.Button
    Friend WithEvents btnSave2 As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblHelp As System.Windows.Forms.ToolStripStatusLabel
End Class
