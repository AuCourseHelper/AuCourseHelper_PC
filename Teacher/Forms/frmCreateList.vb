Imports System.Text

Public Class frmCreateList
    Private dtTmpCourseStudents As New DataTable

    Private Sub frmCreateList_Load(sender As Object, e As EventArgs) Handles Me.Load
        dtTmpCourseStudents.Columns.Add("序號")
        dtTmpCourseStudents.Columns.Add("學號")
        dtTmpCourseStudents.Columns.Add("姓名")
        tblMain.DataSource = dtTmpCourseStudents
    End Sub

    Private Sub btnImportWeb_Click(sender As Object, e As EventArgs) Handles btnImportWeb.Click
        frmLoginWeb.sTodo = "匯入學生名單"
        frmLoginWeb.ShowDialog(Me)
        If frmLoginWeb.dtImport IsNot Nothing Then
            dtTmpCourseStudents = frmLoginWeb.dtImport
            tblMain.DataSource = dtTmpCourseStudents
            MsgBox("學生名單匯入成功！" & vbCrLf & "本課程共有 " & dtTmpCourseStudents.Rows.Count & " 位學生" _
                   & vbCrLf & "請確認資料(如學生姓名難字)無誤後，再儲存！", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub btnImportXls_Click(sender As Object, e As EventArgs) Handles btnImportXls.Click

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim sSql = ""
        Dim sSql2 = ""
        For Each row As DataRow In dtTmpCourseStudents.Rows
            sSql = String.Format("INSERT INTO Student(Num,Name,Pwd) VALUES('{0}','{1}','{0}');", _
                                  row.Item("學號"), row.Item("姓名"))
            sSql2 = String.Format("INSERT INTO CourseStudent(CourseId,StudentCourseId,StudentNum) VALUES('{0}','{1}','{2}');", _
                                   doCourse.Item("Id"), row.Item("序號"), row.Item("學號"))
            doSqlCmd(sSql, True)
            doSqlCmd(sSql2)
        Next
        Me.Dispose()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

End Class