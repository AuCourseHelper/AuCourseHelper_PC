Imports System.Threading
Imports System.Text.RegularExpressions
Imports System.IO
Imports Microsoft.Office.Interop

Public Class dlgLoginWeb
    Public Shared sTodo As String
    Public dtImport As DataTable
    Private tip As New ToolTip()

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
            tip.Show("不能輸入(^%!&+'""?<>/\)等符號喔", sender, New Point(30, -50), 1000)
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
            tip.Show("不能輸入(^%!&+'""?<>/\)等符號喔", sender, New Point(30, -50), 1000)
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

        Dim t As New Thread(AddressOf doLogin)
        t.Start()
        dlgProgress.title = "與校務資訊系統連線中..."
        dlgProgress.ShowDialog(Me)
        Me.Hide()
    End Sub

    Private Sub doLogin()
        If auSysLogin(txtUid.Text, txtPwd.Text) Then
            ' 紀錄帳號密碼至DB
            Dim sSql = String.Format("UPDATE Teacher SET WebUid='{0}',WebPwd='{1}' WHERE Id='{2}';", txtUid.Text, txtPwd.Text, myProfile.Id)
            doSqlCmd(sSql)

            Select Case sTodo
                Case "匯入學生名單"
                    dlgProgress.title = "下載學生名單..."
                    If Not Directory.Exists(Application.StartupPath & "\tmp") Then
                        Directory.CreateDirectory(Application.StartupPath & "\tmp")
                    End If
                    Dim sPath = Application.StartupPath & "\tmp\" & Trim(doCourse.Item("Name")) & ".xls"
                    dtImport = auSysGetCourseStudents(doCourse.Item("Term").Split("-")(0), doCourse.Item("Term").Split("-")(1) _
                                           , doCourse.Item("ChooseNum"), sPath)
            End Select
        End If
        doUiLogin()
    End Sub

    Delegate Sub _doUiLogin()
    Private Sub doUiLogin()
        If InvokeRequired Then
            Invoke(New _doUiLogin(AddressOf doUiLogin))
        End If

        txtPwd.Text = ""
        dlgProgress.Dispose()
    End Sub

    Private Sub chkShowPwd_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPwd.CheckedChanged
        If chkShowPwd.Checked Then
            txtPwd.PasswordChar = Nothing
        Else
            txtPwd.PasswordChar = "*"
        End If
    End Sub

    Private Sub readXls()

    End Sub
End Class