Imports System.Threading

Public Class frmAttend
    Dim students As DataTable = Nothing
    Dim isEdited As Boolean = False

    Private Sub frmAttend_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim resizer As New Resizer(Me, True, 0)
        Dim t As New Thread(AddressOf doGetStudents)
        t.Start()
        frmProgress.ShowDialog(Me)
    End Sub

    Private Sub doGetStudents()
        Dim sqlGetCourseStudents = String.Format("SELECT s.Id,s.Num,s.Name " _
                                 & "FROM Student s,CourseStudent cs " _
                                 & "WHERE cs.CourseId={0} AND cs.StudentNum=s.Num;", nowCourse.Item(0))
        students = doSqlQuery(sqlGetCourseStudents)
        If students Is Nothing Then
            logout()
        End If
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

    Private Sub tabMain_Selected(sender As Object, e As TabControlEventArgs) Handles tabMain.Selected
        Select Case e.TabPage.Name
            Case "tabTable"
                Dim t As New Thread(AddressOf doGetStudents)
                t.Start()
                frmProgress.ShowDialog(Me)
            Case "tabSeat"

        End Select
    End Sub
End Class