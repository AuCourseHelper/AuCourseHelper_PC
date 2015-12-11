<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgSignUp
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSign = New System.Windows.Forms.Button()
        Me.txtUid = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtPwd = New System.Windows.Forms.TextBox()
        Me.lblUidHint = New System.Windows.Forms.Label()
        Me.lblNameHint = New System.Windows.Forms.Label()
        Me.lblPwdHint = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(384, 40)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "~ 助教帳號註冊 ~"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 14.0!)
        Me.Label2.Location = New System.Drawing.Point(13, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 19)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "帳號："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 14.0!)
        Me.Label3.Location = New System.Drawing.Point(12, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Padding = New System.Windows.Forms.Padding(0, 30, 0, 0)
        Me.Label3.Size = New System.Drawing.Size(66, 49)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "姓名："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 14.0!)
        Me.Label4.Location = New System.Drawing.Point(12, 133)
        Me.Label4.Name = "Label4"
        Me.Label4.Padding = New System.Windows.Forms.Padding(0, 30, 0, 0)
        Me.Label4.Size = New System.Drawing.Size(66, 49)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "密碼："
        '
        'btnCancel
        '
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.Font = New System.Drawing.Font("新細明體", 14.0!)
        Me.btnCancel.Location = New System.Drawing.Point(12, 212)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(130, 35)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "取消"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSign
        '
        Me.btnSign.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnSign.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSign.Font = New System.Drawing.Font("新細明體", 14.0!)
        Me.btnSign.Location = New System.Drawing.Point(242, 212)
        Me.btnSign.Name = "btnSign"
        Me.btnSign.Size = New System.Drawing.Size(130, 35)
        Me.btnSign.TabIndex = 5
        Me.btnSign.Text = "確定註冊"
        Me.btnSign.UseVisualStyleBackColor = False
        '
        'txtUid
        '
        Me.txtUid.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtUid.Enabled = False
        Me.txtUid.Font = New System.Drawing.Font("新細明體", 14.0!)
        Me.txtUid.Location = New System.Drawing.Point(85, 58)
        Me.txtUid.Name = "txtUid"
        Me.txtUid.ReadOnly = True
        Me.txtUid.Size = New System.Drawing.Size(287, 30)
        Me.txtUid.TabIndex = 6
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("新細明體", 14.0!)
        Me.txtName.Location = New System.Drawing.Point(84, 106)
        Me.txtName.MaxLength = 10
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(287, 30)
        Me.txtName.TabIndex = 7
        '
        'txtPwd
        '
        Me.txtPwd.Font = New System.Drawing.Font("新細明體", 14.0!)
        Me.txtPwd.Location = New System.Drawing.Point(84, 156)
        Me.txtPwd.MaxLength = 20
        Me.txtPwd.Name = "txtPwd"
        Me.txtPwd.Size = New System.Drawing.Size(287, 30)
        Me.txtPwd.TabIndex = 8
        '
        'lblUidHint
        '
        Me.lblUidHint.AutoSize = True
        Me.lblUidHint.BackColor = System.Drawing.SystemColors.Info
        Me.lblUidHint.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.lblUidHint.Font = New System.Drawing.Font("新細明體", 10.0!)
        Me.lblUidHint.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblUidHint.Location = New System.Drawing.Point(280, 66)
        Me.lblUidHint.Name = "lblUidHint"
        Me.lblUidHint.Size = New System.Drawing.Size(91, 14)
        Me.lblUidHint.TabIndex = 9
        Me.lblUidHint.Text = "系統自動編號"
        '
        'lblNameHint
        '
        Me.lblNameHint.AutoSize = True
        Me.lblNameHint.BackColor = System.Drawing.Color.White
        Me.lblNameHint.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.lblNameHint.Font = New System.Drawing.Font("新細明體", 10.0!)
        Me.lblNameHint.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblNameHint.Location = New System.Drawing.Point(94, 114)
        Me.lblNameHint.Name = "lblNameHint"
        Me.lblNameHint.Size = New System.Drawing.Size(133, 14)
        Me.lblNameHint.TabIndex = 10
        Me.lblNameHint.Text = "十個字以內助教姓名"
        '
        'lblPwdHint
        '
        Me.lblPwdHint.AutoSize = True
        Me.lblPwdHint.BackColor = System.Drawing.Color.White
        Me.lblPwdHint.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.lblPwdHint.Font = New System.Drawing.Font("新細明體", 10.0!)
        Me.lblPwdHint.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblPwdHint.Location = New System.Drawing.Point(94, 164)
        Me.lblPwdHint.Name = "lblPwdHint"
        Me.lblPwdHint.Size = New System.Drawing.Size(217, 14)
        Me.lblPwdHint.TabIndex = 11
        Me.lblPwdHint.Text = "英數字二十個字以內，區分大小寫"
        '
        'dlgSignUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(384, 262)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblPwdHint)
        Me.Controls.Add(Me.lblNameHint)
        Me.Controls.Add(Me.lblUidHint)
        Me.Controls.Add(Me.txtPwd)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.txtUid)
        Me.Controls.Add(Me.btnSign)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximumSize = New System.Drawing.Size(400, 278)
        Me.MinimumSize = New System.Drawing.Size(400, 278)
        Me.Name = "dlgSignUp"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSign As System.Windows.Forms.Button
    Friend WithEvents txtUid As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtPwd As System.Windows.Forms.TextBox
    Friend WithEvents lblUidHint As System.Windows.Forms.Label
    Friend WithEvents lblNameHint As System.Windows.Forms.Label
    Friend WithEvents lblPwdHint As System.Windows.Forms.Label
End Class
