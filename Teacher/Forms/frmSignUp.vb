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



        Dim sql = "SELECT MAX(Num) FROM Teacher WHERE Num LIKE '%TA%');"        'get user name starts with TA
        Dim result As DataTable = doSqlQuery(sql & ";")
        Dim newNum As Integer = 0                                               'int for storing TA number
        If result Is Nothing Then
            MsgBox("使用者資訊讀取錯誤!!")
            '要怎麼重連?
            ' doSqlQuery這個方法其實我就已經有寫自動重試3次
            ' 這邊可能就跳個訊息然後exit sub吧
        ElseIf result.Rows.Count < 1 Then                                       'if there's no TA account
            newNum = 1                                                          'set TA number as 1
        Else                                                                    'if there's TA account
            newNum = Replace((result.ToString), "TA", "")                       'get previous TA number
            newNum = newNum + 1                                                 'add 1 to TA number
        End If



        'Dim TAuser As String = ("TA" + string(3-len(nuwNum),"0") & newNum)  'set user name
        'show on textfield
        'get password
        'store to db

        ' -*-*-*-*-*-*-*-*-*-DATATABLE 的基礎用法
        If result Is Nothing Then
            ' 查詢錯誤，可能是網路問題導致資料不完全
            ' 建議接在 doSqlQuery 後判斷，沒拿到datatable不要再繼續動作，看是要重試或跳離
            ' ↓======範例
            'Dim sqlGetCourseStudents = String.Format("SELECT cs.StudentCourseId,cs.Seat,s.Num,s.Name " _
            '                     & "FROM Student s,CourseStudent cs " _
            '                     & "WHERE cs.CourseId={0} AND cs.StudentNum=s.Num;", doCourse.Item("Id"))
            'doCourseStudents = doSqlQuery(sqlGetCourseStudents)
            'If doCourseStudents Is Nothing Then
            '    frmProgress.isOff = True
            '    MsgBox("學生資訊讀取錯誤!!")
            '    Exit Sub
            'End If
            'doCourseStudents.Columns(0).ColumnName = "序號"
            'doCourseStudents.Columns(1).ColumnName = "座位"
            'doCourseStudents.Columns(2).ColumnName = "學號"
            'doCourseStudents.Columns(3).ColumnName = "姓名"

            'frmProgress.isOff = True
        End If

        If result.Rows.Count < 1 Then
            ' 該SQL語法找不到資料
        End If

        For Each row As DataRow In result.Rows
            ' 取得每個row裡的某個欄位 並用彈出視窗顯示
            MsgBox(row.Item("欄位名稱"))
        Next



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