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
        frmProgress.title = "與伺服器連線中..."
        frmProgress.ShowDialog(Me)
        Me.Hide()
    End Sub

    Private Sub doLogin()
        Try
            Select Case connectAndLogin(txtUid.Text, txtPwd.Text)
                Case "SUCCESS"
                    frmProgress.title = "取得帳號資訊.."
                    ' 取得帳號資訊
                    Dim sqlGetProfile = "SELECT * FROM Teacher WHERE Id=" & myProfile.Id & ";"
                    Dim tblProfile = doSqlQuery(sqlGetProfile)
                    If tblProfile.Rows.Count > 0 Then
                        myProfile.Num = RTrim(tblProfile.Rows(0).Item(1))
                        myProfile.Name = RTrim(tblProfile.Rows(0).Item(2))
                        myProfile.Pwd = RTrim(tblProfile.Rows(0).Item(3))
                        myProfile.LastLogin = RTrim(tblProfile.Rows(0).Item(4).ToString)
                        myProfile.LastIp = RTrim(tblProfile.Rows(0).Item(5).ToString)
                        myProfile.WebSite = RTrim(tblProfile.Rows(0).Item(6).ToString)
                        myProfile.OfficeTime = RTrim(tblProfile.Rows(0).Item(7).ToString)
                    Else
                        MsgBox("登入失敗! 無法取得帳號詳細資訊")
                        logout()
                        Exit Try
                    End If

                    frmProgress.title = "取得系統資訊.."
                    ' 取得當前系統學期別
                    Dim sqlGetSysInfo = "SELECT Term FROM Sys;"
                    nowTerm = doSqlQuery(sqlGetSysInfo).Rows(0).Item(0).ToString
                    ' 取得當前系統學期開始日
                    Dim sqlGetSysDateInfo = "SELECT StartDate FROM Sys_Date WHERE Term='" & nowTerm & "';"
                    nowTermStart = Date.Parse(doSqlQuery(sqlGetSysDateInfo).Rows(0).Item(0).ToString).AddDays(-1)
                    nowWeek = Math.Ceiling(Now.Subtract(nowTermStart).Days / 7)
                    nowWeekDetail = nowTerm & vbCrLf & "第 " & nowWeek & " 週"

                    frmProgress.title = "取得課程資訊.."
                    ' 取得課程資訊
                    Dim sqlGetCourses = "SELECT * FROM Course WHERE Teacher LIKE '%" & myProfile.Name & "%';"
                    myCourses = doSqlQuery(sqlGetCourses)
                    Dim c() = {myCourses.Columns(0)}
                    myCourses.PrimaryKey = c
                Case "FAIL"
                    MsgBox("登入失敗! 帳號或密碼錯誤")
                Case "RELOGIN"
                    MsgBox("登入失敗! 帳號重覆登入")
                Case "TIMEOUT"
                    MsgBox("無法連線!" & vbCrLf & "伺服器可能斷線或未開啟")
            End Select
        Catch ex As Exception
            log("登入失敗! 資料傳輸錯誤 " & ex.Message, LogType_ERROR)
            isLogin = False
            logout()
        End Try
        doUiLogin()
    End Sub

    Delegate Sub _doUiLogin()
    Private Sub doUiLogin()
        If InvokeRequired Then
            Invoke(New _doUiLogin(AddressOf doUiLogin))
        End If

        txtPwd.Text = ""
        frmProgress.Dispose()
    End Sub

    Private Sub chkShowPwd_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPwd.CheckedChanged
        If chkShowPwd.Checked Then
            txtPwd.PasswordChar = Nothing
        Else
            txtPwd.PasswordChar = "*"
        End If
    End Sub
End Class