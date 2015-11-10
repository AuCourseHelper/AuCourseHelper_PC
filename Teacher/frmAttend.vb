Imports System.Threading

Public Class frmAttend
    Dim students As DataTable = Nothing
    Dim isEdited As Boolean = False

    Private Sub frmAttend_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Dim resizer As New Resizer(Me, True, 0)
        Dim table As New TableLayoutPanel()
        table.Dock = DockStyle.Fill
        table.ColumnCount = 14
        table.RowCount = 7

        For col As Integer = 0 To table.ColumnCount - 1
            For row As Integer = 0 To table.RowCount - 1
                If row = 0 Then
                    table.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100))
                End If
                If col = 0 Then
                    table.RowStyles.Add(New RowStyle(SizeType.Percent, 100))
                End If

                If (col + 1) Mod 5 <> 0 And Not (row = 6 And col < 4) Then
                    Dim b As New Button()
                    b.Dock = DockStyle.Fill
                    b.Text = row & "," & col
                    table.Controls.Add(b, col, row)
                End If
            Next
        Next
        pnlMain2.Controls.Add(table)

        Dim t As New Thread(AddressOf doGetStudents)
        t.Start()
        frmProgress.title = "讀取學生資訊..."
        frmProgress.ShowDialog(Me)
    End Sub

    Private Sub doGetStudents()
        Dim sqlGetCourseStudents = String.Format("SELECT cs.StudentCourseId,s.Num,s.Name " _
                                 & "FROM Student s,CourseStudent cs " _
                                 & "WHERE cs.CourseId={0} AND cs.StudentNum=s.Num;", nowCourse.Item(0))
        students = doSqlQuery(sqlGetCourseStudents)
        If students Is Nothing Then
            logout()
        End If
        students.Columns(0).ColumnName = "序號"
        students.Columns(1).ColumnName = "學號"
        students.Columns(2).ColumnName = "姓名"
        students.Columns.Add()
        students.Columns(3).ColumnName = "出席狀況"
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

    Private Sub frmAttend_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        'Resizer.setGridColWidth(tblMain)
    End Sub
End Class