<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgChoose_SeatLayout
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
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grbMain = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAisle = New System.Windows.Forms.TextBox()
        Me.txtRow = New System.Windows.Forms.TextBox()
        Me.txtCol = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.grbMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboType
        '
        Me.cboType.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.cboType.FormattingEnabled = True
        Me.cboType.Items.AddRange(New Object() {"自　訂", "605 電腦教室", "712 電腦教室", "911、912 電腦教室", "913 電腦教室", "921 電腦教室"})
        Me.cboType.Location = New System.Drawing.Point(107, 12)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(159, 24)
        Me.cboType.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(13, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "佈局樣式："
        '
        'grbMain
        '
        Me.grbMain.Controls.Add(Me.Label5)
        Me.grbMain.Controls.Add(Me.txtAisle)
        Me.grbMain.Controls.Add(Me.txtRow)
        Me.grbMain.Controls.Add(Me.txtCol)
        Me.grbMain.Controls.Add(Me.Label4)
        Me.grbMain.Controls.Add(Me.Label3)
        Me.grbMain.Controls.Add(Me.Label2)
        Me.grbMain.Enabled = False
        Me.grbMain.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.grbMain.Location = New System.Drawing.Point(16, 42)
        Me.grbMain.Name = "grbMain"
        Me.grbMain.Size = New System.Drawing.Size(356, 141)
        Me.grbMain.TabIndex = 3
        Me.grbMain.TabStop = False
        Me.grbMain.Text = "設定值"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Gray
        Me.Label5.Location = New System.Drawing.Point(88, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(262, 12)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "(無走道請設0，多個走道以 - 號間隔，如 5-10-15)"
        '
        'txtAisle
        '
        Me.txtAisle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtAisle.Location = New System.Drawing.Point(157, 90)
        Me.txtAisle.MaxLength = 2
        Me.txtAisle.Name = "txtAisle"
        Me.txtAisle.Size = New System.Drawing.Size(101, 27)
        Me.txtAisle.TabIndex = 3
        Me.txtAisle.Text = "0"
        Me.txtAisle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtAisle.WordWrap = False
        '
        'txtRow
        '
        Me.txtRow.Location = New System.Drawing.Point(91, 58)
        Me.txtRow.MaxLength = 2
        Me.txtRow.Name = "txtRow"
        Me.txtRow.Size = New System.Drawing.Size(60, 27)
        Me.txtRow.TabIndex = 3
        Me.txtRow.Text = "0"
        Me.txtRow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtRow.WordWrap = False
        '
        'txtCol
        '
        Me.txtCol.Location = New System.Drawing.Point(91, 25)
        Me.txtCol.MaxLength = 2
        Me.txtCol.Name = "txtCol"
        Me.txtCol.Size = New System.Drawing.Size(60, 27)
        Me.txtCol.TabIndex = 3
        Me.txtCol.Text = "0"
        Me.txtCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtCol.WordWrap = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label4.Location = New System.Drawing.Point(132, 93)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(216, 16)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "第　　　　　　　列設置走道"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label3.Location = New System.Drawing.Point(8, 61)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(204, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "列(排)數：　　　　　(橫向)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(8, 28)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(268, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "行(欄)數：　　　　　(直向，含走道)"
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.SystemColors.Info
        Me.btnOk.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.btnOk.Image = Global.AUCourseHelper_Teacher.My.Resources.Resources.ok
        Me.btnOk.Location = New System.Drawing.Point(166, 189)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(100, 60)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "確定"
        Me.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnOk.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.btnCancel.Image = Global.AUCourseHelper_Teacher.My.Resources.Resources.cancel
        Me.btnCancel.Location = New System.Drawing.Point(272, 189)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 60)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "取消"
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'dlgChoose_SeatLayout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 261)
        Me.ControlBox = False
        Me.Controls.Add(Me.grbMain)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboType)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "dlgChoose_SeatLayout"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = ">編輯座位佈局"
        Me.grbMain.ResumeLayout(False)
        Me.grbMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grbMain As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCol As System.Windows.Forms.TextBox
    Friend WithEvents txtAisle As System.Windows.Forms.TextBox
    Friend WithEvents txtRow As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
