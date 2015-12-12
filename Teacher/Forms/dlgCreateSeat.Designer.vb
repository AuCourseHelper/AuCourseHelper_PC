<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgCreateSeat
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
        Me.lblHelp = New System.Windows.Forms.Label()
        Me.pnlBtn = New System.Windows.Forms.TableLayoutPanel()
        Me.btnDel = New System.Windows.Forms.Button()
        Me.btnLayout = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.btnRand = New System.Windows.Forms.Button()
        Me.btnChangeView = New System.Windows.Forms.Button()
        Me.pnlBtn.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblHelp
        '
        Me.lblHelp.BackColor = System.Drawing.Color.LightGreen
        Me.lblHelp.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblHelp.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.lblHelp.Location = New System.Drawing.Point(0, 0)
        Me.lblHelp.Name = "lblHelp"
        Me.lblHelp.Size = New System.Drawing.Size(784, 30)
        Me.lblHelp.TabIndex = 1
        Me.lblHelp.Text = "說明：點擊座位名稱可更改學生"
        Me.lblHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlBtn
        '
        Me.pnlBtn.ColumnCount = 7
        Me.pnlBtn.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.pnlBtn.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.pnlBtn.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.pnlBtn.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.pnlBtn.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlBtn.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.pnlBtn.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.pnlBtn.Controls.Add(Me.btnChangeView, 3, 0)
        Me.pnlBtn.Controls.Add(Me.btnRand, 0, 0)
        Me.pnlBtn.Controls.Add(Me.btnDel, 2, 0)
        Me.pnlBtn.Controls.Add(Me.btnLayout, 0, 0)
        Me.pnlBtn.Controls.Add(Me.btnCancel, 6, 0)
        Me.pnlBtn.Controls.Add(Me.btnSave, 5, 0)
        Me.pnlBtn.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBtn.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.pnlBtn.Location = New System.Drawing.Point(0, 501)
        Me.pnlBtn.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlBtn.Name = "pnlBtn"
        Me.pnlBtn.RowCount = 1
        Me.pnlBtn.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlBtn.Size = New System.Drawing.Size(784, 60)
        Me.pnlBtn.TabIndex = 2
        '
        'btnDel
        '
        Me.btnDel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnDel.Image = Global.AUCourseHelper_Teacher.My.Resources.Resources.del
        Me.btnDel.Location = New System.Drawing.Point(202, 2)
        Me.btnDel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(96, 56)
        Me.btnDel.TabIndex = 3
        Me.btnDel.Text = "清空" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "座位"
        Me.btnDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'btnLayout
        '
        Me.btnLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnLayout.Image = Global.AUCourseHelper_Teacher.My.Resources.Resources.seat
        Me.btnLayout.Location = New System.Drawing.Point(2, 2)
        Me.btnLayout.Margin = New System.Windows.Forms.Padding(2)
        Me.btnLayout.Name = "btnLayout"
        Me.btnLayout.Size = New System.Drawing.Size(96, 56)
        Me.btnLayout.TabIndex = 2
        Me.btnLayout.Text = "編輯" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "佈局"
        Me.btnLayout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLayout.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCancel.Image = Global.AUCourseHelper_Teacher.My.Resources.Resources.cancel
        Me.btnCancel.Location = New System.Drawing.Point(686, 2)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(96, 56)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "取消"
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSave.Image = Global.AUCourseHelper_Teacher.My.Resources.Resources.save
        Me.btnSave.Location = New System.Drawing.Point(586, 2)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(96, 56)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "存檔"
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'pnlMain
        '
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 30)
        Me.pnlMain.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(784, 471)
        Me.pnlMain.TabIndex = 3
        '
        'btnRand
        '
        Me.btnRand.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnRand.Image = Global.AUCourseHelper_Teacher.My.Resources.Resources.seat
        Me.btnRand.Location = New System.Drawing.Point(102, 2)
        Me.btnRand.Margin = New System.Windows.Forms.Padding(2)
        Me.btnRand.Name = "btnRand"
        Me.btnRand.Size = New System.Drawing.Size(96, 56)
        Me.btnRand.TabIndex = 4
        Me.btnRand.Text = "亂數" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "排列"
        Me.btnRand.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRand.UseVisualStyleBackColor = True
        '
        'btnChangeView
        '
        Me.btnChangeView.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnChangeView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnChangeView.Image = Global.AUCourseHelper_Teacher.My.Resources.Resources.update
        Me.btnChangeView.Location = New System.Drawing.Point(303, 3)
        Me.btnChangeView.Name = "btnChangeView"
        Me.btnChangeView.Size = New System.Drawing.Size(94, 54)
        Me.btnChangeView.TabIndex = 8
        Me.btnChangeView.Text = "切換" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "視角"
        Me.btnChangeView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnChangeView.UseVisualStyleBackColor = False
        '
        'dlgCreateSeat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pnlBtn)
        Me.Controls.Add(Me.lblHelp)
        Me.MaximumSize = New System.Drawing.Size(800, 600)
        Me.MinimumSize = New System.Drawing.Size(800, 600)
        Me.Name = "dlgCreateSeat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = ">建立座位表"
        Me.pnlBtn.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblHelp As System.Windows.Forms.Label
    Friend WithEvents pnlBtn As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnDel As System.Windows.Forms.Button
    Friend WithEvents btnLayout As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents btnRand As System.Windows.Forms.Button
    Friend WithEvents btnChangeView As System.Windows.Forms.Button
End Class
