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

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

End Class