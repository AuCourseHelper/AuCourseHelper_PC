<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgCreateList
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlBtn = New System.Windows.Forms.TableLayoutPanel()
        Me.btnImportXls = New System.Windows.Forms.Button()
        Me.btnImportWeb = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.tblMain = New System.Windows.Forms.DataGridView()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.lblHelp = New System.Windows.Forms.Label()
        Me.pnlBtn.SuspendLayout()
        CType(Me.tblMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlBtn
        '
        Me.pnlBtn.ColumnCount = 5
        Me.pnlBtn.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.pnlBtn.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.pnlBtn.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlBtn.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.pnlBtn.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.pnlBtn.Controls.Add(Me.btnImportXls, 1, 0)
        Me.pnlBtn.Controls.Add(Me.btnImportWeb, 0, 0)
        Me.pnlBtn.Controls.Add(Me.btnCancel, 4, 0)
        Me.pnlBtn.Controls.Add(Me.btnSave, 3, 0)
        Me.pnlBtn.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBtn.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.pnlBtn.Location = New System.Drawing.Point(0, 501)
        Me.pnlBtn.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlBtn.Name = "pnlBtn"
        Me.pnlBtn.RowCount = 1
        Me.pnlBtn.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlBtn.Size = New System.Drawing.Size(784, 60)
        Me.pnlBtn.TabIndex = 0
        '
        'btnImportXls
        '
        Me.btnImportXls.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnImportXls.Image = Global.AUCourseHelper_Teacher.My.Resources.Resources.xls
        Me.btnImportXls.Location = New System.Drawing.Point(152, 2)
        Me.btnImportXls.Margin = New System.Windows.Forms.Padding(2)
        Me.btnImportXls.Name = "btnImportXls"
        Me.btnImportXls.Size = New System.Drawing.Size(146, 56)
        Me.btnImportXls.TabIndex = 3
        Me.btnImportXls.Text = "從Excel" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "檔案匯入"
        Me.btnImportXls.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnImportXls.UseVisualStyleBackColor = True
        '
        'btnImportWeb
        '
        Me.btnImportWeb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnImportWeb.Image = Global.AUCourseHelper_Teacher.My.Resources.Resources.web
        Me.btnImportWeb.Location = New System.Drawing.Point(2, 2)
        Me.btnImportWeb.Margin = New System.Windows.Forms.Padding(2)
        Me.btnImportWeb.Name = "btnImportWeb"
        Me.btnImportWeb.Size = New System.Drawing.Size(146, 56)
        Me.btnImportWeb.TabIndex = 2
        Me.btnImportWeb.Text = "從校務系統" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "匯入"
        Me.btnImportWeb.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnImportWeb.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCancel.Image = Global.AUCourseHelper_Teacher.My.Resources.Resources.cancel
        Me.btnCancel.Location = New System.Drawing.Point(636, 2)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(146, 56)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "取消"
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSave.Image = Global.AUCourseHelper_Teacher.My.Resources.Resources.save
        Me.btnSave.Location = New System.Drawing.Point(486, 2)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(146, 56)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "存檔"
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'tblMain
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 14.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tblMain.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.tblMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.tblMain.DefaultCellStyle = DataGridViewCellStyle2
        Me.tblMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMain.Location = New System.Drawing.Point(0, 30)
        Me.tblMain.Name = "tblMain"
        Me.tblMain.RowTemplate.Height = 24
        Me.tblMain.Size = New System.Drawing.Size(784, 471)
        Me.tblMain.TabIndex = 1
        '
        'pnlMain
        '
        Me.pnlMain.Controls.Add(Me.tblMain)
        Me.pnlMain.Controls.Add(Me.lblHelp)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(784, 501)
        Me.pnlMain.TabIndex = 2
        '
        'lblHelp
        '
        Me.lblHelp.BackColor = System.Drawing.Color.LightGreen
        Me.lblHelp.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblHelp.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.lblHelp.Location = New System.Drawing.Point(0, 0)
        Me.lblHelp.Name = "lblHelp"
        Me.lblHelp.Size = New System.Drawing.Size(784, 30)
        Me.lblHelp.TabIndex = 0
        Me.lblHelp.Text = "說明：點選欄位兩下可編輯，點選列頭選取整列後按下 Del 即可刪除該學生"
        Me.lblHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dlgCreateList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pnlBtn)
        Me.MaximumSize = New System.Drawing.Size(800, 600)
        Me.MinimumSize = New System.Drawing.Size(800, 600)
        Me.Name = "dlgCreateList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = ">建立授課名單"
        Me.pnlBtn.ResumeLayout(False)
        CType(Me.tblMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBtn As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnImportXls As System.Windows.Forms.Button
    Friend WithEvents btnImportWeb As System.Windows.Forms.Button
    Friend WithEvents tblMain As System.Windows.Forms.DataGridView
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents lblHelp As System.Windows.Forms.Label
End Class
