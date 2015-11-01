Imports System.Threading

Public Class frmAttend
    Dim students As New DataTable

    Private Sub frmAttend_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim t As New Thread(AddressOf doGetStudents)
        t.Start()
        frmProgress.ShowDialog(Me)
    End Sub

    Private Sub doGetStudents()
        Dim sqlGetCourseStudents = String.Format("SELECT s.Id,s.Num,s.Name " _
                                 & "FROM Student s,CourseStudent cs " _
                                 & "WHERE cs.CourseId={0} AND cs.StudentNum=s.Num;", nowCourse.Item(0))
        students = doSqlQuery(sqlGetCourseStudents)
        doUiGetStudents()
    End Sub

    Delegate Sub _doUiGetStudents()
    Private Sub doUiGetStudents()
        If InvokeRequired Then
            Invoke(New _doUiGetStudents(AddressOf doUiGetStudents))
        End If

        tblMain.DataSource = students
        frmProgress.Dispose()
    End Sub

End Class