<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        Me.txtUid = New System.Windows.Forms.TextBox()
        Me.txtPwd = New System.Windows.Forms.TextBox()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblUidHint = New System.Windows.Forms.Label()
        Me.lblPwdHint = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 14.0!)
        Me.Label1.Location = New System.Drawing.Point(20, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "帳號："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 14.0!)
        Me.Label2.Location = New System.Drawing.Point(20, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 19)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "密碼："
        '
        'txtUid
        '
        Me.txtUid.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtUid.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtUid.Location = New System.Drawing.Point(100, 29)
        Me.txtUid.Name = "txtUid"
        Me.txtUid.Size = New System.Drawing.Size(155, 27)
        Me.txtUid.TabIndex = 2
        '
        'txtPwd
        '
        Me.txtPwd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtPwd.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtPwd.Location = New System.Drawing.Point(100, 79)
        Me.txtPwd.MaxLength = 20
        Me.txtPwd.Name = "txtPwd"
        Me.txtPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPwd.Size = New System.Drawing.Size(155, 27)
        Me.txtPwd.TabIndex = 3
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLogin.Font = New System.Drawing.Font("新細明體", 11.0!)
        Me.btnLogin.Location = New System.Drawing.Point(180, 132)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(75, 23)
        Me.btnLogin.TabIndex = 4
        Me.btnLogin.Text = "登入"
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.Font = New System.Drawing.Font("新細明體", 11.0!)
        Me.btnCancel.Location = New System.Drawing.Point(24, 132)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "取消"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblUidHint
        '
        Me.lblUidHint.AutoSize = True
        Me.lblUidHint.BackColor = System.Drawing.Color.White
        Me.lblUidHint.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.lblUidHint.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblUidHint.Location = New System.Drawing.Point(110, 35)
        Me.lblUidHint.Name = "lblUidHint"
        Me.lblUidHint.Size = New System.Drawing.Size(101, 12)
        Me.lblUidHint.TabIndex = 6
        Me.lblUidHint.Text = "請使用教職員編號"
        '
        'lblPwdHint
        '
        Me.lblPwdHint.AutoSize = True
        Me.lblPwdHint.BackColor = System.Drawing.Color.White
        Me.lblPwdHint.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.lblPwdHint.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblPwdHint.Location = New System.Drawing.Point(110, 85)
        Me.lblPwdHint.Name = "lblPwdHint"
        Me.lblPwdHint.Size = New System.Drawing.Size(113, 12)
        Me.lblPwdHint.TabIndex = 7
        Me.lblPwdHint.Text = "首次登入密碼同帳號"
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Info
        Me.ClientSize = New System.Drawing.Size(284, 181)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblPwdHint)
        Me.Controls.Add(Me.lblUidHint)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.txtPwd)
        Me.Controls.Add(Me.txtUid)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "課程輔助系統-教師端 | 登入"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtUid As System.Windows.Forms.TextBox
    Friend WithEvents txtPwd As System.Windows.Forms.TextBox
    Friend WithEvents btnLogin As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblUidHint As System.Windows.Forms.Label
    Friend WithEvents lblPwdHint As System.Windows.Forms.Label
End Class
