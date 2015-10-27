Public Class frmLogin

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Hide()
    End Sub

    Private Sub txtUid_TextChanged(sender As Object, e As EventArgs) Handles txtUid.TextChanged
        If txtUid.Text <> "" Then
            lblUidHint.Visible = False
        Else
            lblUidHint.Visible = True
        End If
    End Sub

    Private Sub lblUidHint_Click(sender As Object, e As EventArgs) Handles lblUidHint.Click
        txtUid.Focus()
    End Sub

    Private Sub txtPwd_TextChanged(sender As Object, e As EventArgs) Handles txtPwd.TextChanged
        If txtPwd.Text <> "" Then
            lblPwdHint.Visible = False
        Else
            lblPwdHint.Visible = True
        End If
    End Sub

    Private Sub lblPwdHint_Click(sender As Object, e As EventArgs) Handles lblPwdHint.Click
        txtPwd.Focus()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Me.Cursor = Cursors.WaitCursor
        If connectAndLogin(txtUid.Text, txtPwd.Text) Then
            Me.Cursor = Cursors.Default
        Else
            MsgBox("登入失敗! 帳號或密碼錯誤")
        End If
    End Sub
End Class