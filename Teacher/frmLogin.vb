Imports System.Threading
Imports System.Text.RegularExpressions

Public Class frmLogin
    Dim tip As New ToolTip()

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Hide()
    End Sub

    Private Sub txtUid_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUid.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPwd.Focus()
        End If
    End Sub

    Private Sub txtUid_TextChanged(sender As Object, e As EventArgs) Handles txtUid.TextChanged
        If txtUid.Text <> "" Then
            lblUidHint.Visible = False
        Else
            lblUidHint.Visible = True
        End If
        If Regex.IsMatch(txtUid.Text, "[^\w_]+") Then
            tip.Hide(sender)
            tip.IsBalloon = True
            tip.Show("不能輸入(^%!&+'""?<>/\\)等符號喔", sender, New Point(30, -50), 1000)
            txtUid.Text = Regex.Replace(txtUid.Text, "[\W_]+", "")
            txtUid.SelectionStart = txtUid.Text.Length
        End If
    End Sub

    Private Sub lblUidHint_Click(sender As Object, e As EventArgs) Handles lblUidHint.Click
        txtUid.Focus()
    End Sub

    Private Sub txtPwd_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPwd.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin.PerformClick()
        End If
    End Sub

    Private Sub txtPwd_TextChanged(sender As Object, e As EventArgs) Handles txtPwd.TextChanged
        If txtPwd.Text <> "" Then
            lblPwdHint.Visible = False
        Else
            lblPwdHint.Visible = True
        End If
        If Regex.IsMatch(txtPwd.Text, "[^\w_]+") Then
            tip.Hide(sender)
            tip.IsBalloon = True
            tip.Show("不能輸入(^%!&+'""?<>/\\)等符號喔", sender, New Point(30, -50), 1000)
            txtPwd.Text = Regex.Replace(txtPwd.Text, "[\W_]+", "")
            txtPwd.SelectionStart = txtPwd.Text.Length
        End If
    End Sub

    Private Sub lblPwdHint_Click(sender As Object, e As EventArgs) Handles lblPwdHint.Click
        txtPwd.Focus()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If txtUid.Text.Length = 0 Then
            MsgBox("帳號未輸入!")
            txtUid.Focus()
            Exit Sub
        End If
        If txtPwd.Text.Length = 0 Then
            MsgBox("密碼未輸入!")
            txtPwd.Focus()
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        Select Case connectAndLogin(txtUid.Text, txtPwd.Text)
            Case "SUCCESS"
                ' 帳號資訊
                ' 課程資訊

                objFrmTeacher.tslUserName.Text = myName & " 你好!"
                objFrmTeacher.tmrServerPing.Enabled = True
                objFrmTeacher.tsmAccount.Enabled = True
                objFrmTeacher.tsmCourse.Enabled = True
                objFrmTeacher.mnuLogin.Enabled = False
                objFrmTeacher.mnuSignUp.Enabled = True
                objFrmTeacher.mnuLogout.Enabled = True
                Me.Cursor = Cursors.Default
                Me.Hide()
            Case "FAIL"
                Me.Cursor = Cursors.Default
                MsgBox("登入失敗! 帳號或密碼錯誤")
            Case "TIMEOUT"
                Me.Cursor = Cursors.Default
                MsgBox("無法連線!" & vbCrLf & "伺服器可能斷線或未開啟")
        End Select

        txtPwd.Text = ""
    End Sub

    Private Sub chkShowPwd_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPwd.CheckedChanged
        If chkShowPwd.Checked Then
            txtPwd.PasswordChar = Nothing
        Else
            txtPwd.PasswordChar = "*"
        End If
    End Sub
End Class