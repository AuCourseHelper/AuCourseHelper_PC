Imports System.Text
Imports System.Threading

Public Class dlgCreateList
    Private dtTmpCourseStudents As New DataTable

    Private Sub frmCreateList_Load(sender As Object, e As EventArgs) Handles Me.Load
        dtTmpCourseStudents.Columns.Add("序號")
        dtTmpCourseStudents.Columns.Add("學號")
        dtTmpCourseStudents.Columns.Add("姓名")
        tblMain.DataSource = dtTmpCourseStudents
    End Sub

    Private Sub btnImportWeb_Click(sender As Object, e As EventArgs) Handles btnImportWeb.Click
        dlgLoginWeb.sTodo = "匯入學生名單"
        dlgLoginWeb.ShowDialog(Me)
        If dlgLoginWeb.dtImport IsNot Nothing Then
            dtTmpCourseStudents = dlgLoginWeb.dtImport
            tblMain.DataSource = dtTmpCourseStudents
            MsgBox("學生名單匯入成功！" & vbCrLf & "本課程共有 " & dtTmpCourseStudents.Rows.Count & " 位學生" _
                   & vbCrLf & "請確認資料(如學生姓名難字)無誤後，再儲存！", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub btnImportXls_Click(sender As Object, e As EventArgs) Handles btnImportXls.Click

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If MsgBox("是否替學生建立座位表？" & vbCrLf & "你也可以於 <<學生名單、點名、評分、修改資料>> 等功能再行新增座位表", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            dlgCreateSeat.dtStudents = dtTmpCourseStudents
            dlgCreateSeat.ShowDialog(Me)
        End If
        Dim t As New Thread(AddressOf doSave)
        t.Start()
        dlgProgress.title = "儲存學生資訊..."
        dlgProgress.ShowDialog(Me)
        Me.Dispose()
    End Sub

    Private Sub doSave()
        Dim sSql1 = ""
        Dim sSql2 = ""
        For Each row As DataRow In dtTmpCourseStudents.Rows
            sSql1 &= String.Format("INSERT INTO Student(Num,Name,Pwd) VALUES('{0}','{1}','{0}')#", _
                                  row.Item("學號"), row.Item("姓名"))
            sSql2 &= String.Format("INSERT INTO CourseStudent(CourseId,StudentCourseId,StudentNum) VALUES('{0}','{1}','{2}')#", _
                                   doCourse.Item("Id"), row.Item("序號"), row.Item("學號"))
        Next
        doSqlCmd(sSql1)
        dlgProgress.title = "儲存課程名單..."
        doSqlCmd(sSql2)

        dlgProgress.title = "讀取學生資訊..."
        Dim sqlGetCourseStudents = String.Format("SELECT cs.StudentCourseId,cs.Seat,s.Num,s.Name " _
                                 & "FROM Student s,CourseStudent cs " _
                                 & "WHERE cs.CourseId={0} AND cs.StudentNum=s.Num;", doCourse.Item("Id"))
        doCourseStudents = doSqlQuery(sqlGetCourseStudents)
        If doCourseStudents Is Nothing Then
            dlgProgress.isOff = True
            Exit Sub
        End If
        doCourseStudents.Columns(0).ColumnName = "序號"
        doCourseStudents.Columns(1).ColumnName = "座位"
        doCourseStudents.Columns(2).ColumnName = "學號"
        doCourseStudents.Columns(3).ColumnName = "姓名"

        dlgProgress.isOff = True
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

End Class