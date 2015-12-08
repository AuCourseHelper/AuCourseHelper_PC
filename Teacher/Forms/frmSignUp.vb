Imports System.Text.RegularExpressions

Public Class frmSignUp
    Dim tip As New ToolTip()

    Private Sub lblNameHint_Click(sender As Object, e As EventArgs) Handles lblNameHint.Click
        txtName.Focus()
    End Sub

    Private Sub lblPwdHint_Click(sender As Object, e As EventArgs) Handles lblPwdHint.Click
        txtPwd.Focus()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        If txtName.Text <> "" Then
            lblNameHint.Visible = False
        Else
            lblNameHint.Visible = True
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

    Private Sub btnSign_Click(sender As Object, e As EventArgs) Handles btnSign.Click



        Dim sql = "SELECT MAX(Num) FROM Teacher WHERE Num LIKE '%TA%');"
        Dim result As DataTable = doSqlQuery(sql & ";")
        Dim newNum As Integer = 0
        If IsDBNull(result) Then
            newNum = 1
        ElseIf
            Dim newNum As Integer = Replace((result.ToString), "TA", "")
            newNum += newNum
        End If

        
        



        'Dim userInfo As String = ""
        'Select Case userType
        '    Case "T" ' 老師
        '        Dim sql = String.Format("SELECT Id,RTRIM(Name) FROM Teacher WHERE Num='{0}' AND Pwd='{1}'", uid, pwd)
        '        Dim result = selectCmd(sql)
        '        If result.Rows.Count > 0 Then
        '            userInfo = result.Rows(0).Item(0) & ";" & result.Rows(0).Item(1)
        '        End If
        '    Case "S" ' 學生
        '        Dim sql = String.Format("SELECT Id,RTRIM(Name) FROM Student WHERE Num='{0}' AND Pwd='{1}'", uid, pwd)
        '        Dim result = selectCmd(sql)
        '        If result.Rows.Count > 0 Then
        '            userInfo = result.Rows(0).Item(0) & ";" & result.Rows(0).Item(1)
        '        End If
        'End Select
        'Return userInfo






        ' 按下註冊要做的事
        ' 記得返回帳號給使用者看
        ' 帳號命名規則: TA開頭 + 3位數字
        '                     ↑數字要撈出目前SQL裡最後一個助教的號碼後加一
    End Sub

    ' ====SELECT 方法範例
    ' Dim sql = "我是SELECT語法" <<最後記得一定要加上分號
    ' Dim result As DataTable = doSqlQuery(Sql & ";")

    ' ====CMD 方法範例
    ' Dim sql = "我是INSERT、UPDATE、DELETE語法" <<最後記得一定要加上分號
    ' Dim result As Boolean = doSqlCmd(Sql & ";")
End Class