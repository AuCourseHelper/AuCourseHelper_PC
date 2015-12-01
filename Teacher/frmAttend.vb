Imports System.Threading

Public Class frmAttend
    Dim students As DataTable = Nothing
    Dim isEdited As Boolean = False
    Dim seatLayout As TableLayoutPanel

    Private Sub frmAttend_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim t As New Thread(AddressOf doGetStudents)
        t.Start()
        frmProgress.title = "讀取學生資訊..."
        frmProgress.ShowDialog(Me)
    End Sub

    Private Sub doGetStudents()
        Dim sqlGetCourseStudents = String.Format("SELECT cs.StudentCourseId,cs.Seat,s.Num,s.Name " _
                                 & "FROM Student s,CourseStudent cs " _
                                 & "WHERE cs.CourseId={0} AND cs.StudentNum=s.Num;", nowCourse.Item(0))
        students = doSqlQuery(sqlGetCourseStudents)
        If students Is Nothing Then
            logout()
        End If
        students.Columns(0).ColumnName = "序號"
        students.Columns(1).ColumnName = "座位"
        students.Columns(2).ColumnName = "學號"
        students.Columns(3).ColumnName = "姓名"
        students.Columns.Add()
        students.Columns(4).ColumnName = "出席狀況"
        doUiGetStudents()
    End Sub

    Delegate Sub _doUiGetStudents()
    Private Sub doUiGetStudents()
        If InvokeRequired Then
            Invoke(New _doUiGetStudents(AddressOf doUiGetStudents))
        End If
        lblDate.Text = Now.Month & "/" & Now.Day & vbCrLf & "第 " & nowWeek & " 週"
        lblDate2.Text = Now.Month & "/" & Now.Day & vbCrLf & "第 " & nowWeek & " 週"

        ' 表格部分
        tblMain.DataSource = students
        tblMain.Rows(0).Selected = True
        frmProgress.Dispose()
        ' 座位部分
        If nowCourse.Item(11).ToString = "1" Then
            seatLayout = New TableLayoutPanel
            seatLayout.Dock = DockStyle.Fill
            seatLayout.ColumnCount = 14
            seatLayout.RowCount = 7
            For col As Integer = 0 To seatLayout.ColumnCount - 1
                For row As Integer = 0 To seatLayout.RowCount - 1
                    If row = 0 Then
                        seatLayout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100))
                    End If
                    If col = 0 Then
                        seatLayout.RowStyles.Add(New RowStyle(SizeType.Percent, 100))
                    End If
                    If (col + 1) Mod 5 <> 0 And Not (row = 6 And col < 4) Then
                        Dim b As New Button()
                        b.Dock = DockStyle.Fill
                        b.Text = row & "," & col
                        seatLayout.Controls.Add(b, col, row)
                    End If
                Next
            Next
            pnlMain2.Controls.Add(seatLayout)
        End If
    End Sub

    Private Sub tabMain_Selected(sender As Object, e As TabControlEventArgs) Handles tabMain.Selected
        Select Case e.TabPage.Name
            Case "tabTable"
                
            Case "tabSeat"
                
        End Select
    End Sub

    Private Sub btnAtt_Click(sender As Object, e As EventArgs) Handles btnAtt.Click
        Dim index = tblMain.SelectedRows(0).Index
        tblMain.Rows(index).Cells(4).Value = "出席"
        tblMain.Rows(index).Cells(4).Style.BackColor = Color.LightGreen
        If index < tblMain.RowCount - 1 Then
            tblMain.Rows(index + 1).Selected = True
            tblMain.FirstDisplayedScrollingRowIndex = index
        End If
    End Sub

    Private Sub btnOff_Click(sender As Object, e As EventArgs) Handles btnOff.Click
        Dim index = tblMain.SelectedRows(0).Index
        tblMain.Rows(index).Cells(4).Value = "請假"
        tblMain.Rows(index).Cells(4).Style.BackColor = Color.LightGray
        If index < tblMain.RowCount - 1 Then
            tblMain.Rows(index + 1).Selected = True
            tblMain.FirstDisplayedScrollingRowIndex = index
        End If
    End Sub

    Private Sub btnLat_Click(sender As Object, e As EventArgs) Handles btnLat.Click
        Dim index = tblMain.SelectedRows(0).Index
        tblMain.Rows(index).Cells(4).Value = "遲到"
        tblMain.Rows(index).Cells(4).Style.BackColor = Color.LightBlue
        If index < tblMain.RowCount - 1 Then
            tblMain.Rows(index + 1).Selected = True
            tblMain.FirstDisplayedScrollingRowIndex = index
        End If
    End Sub

    Private Sub btnAbs_Click(sender As Object, e As EventArgs) Handles btnAbs.Click
        Dim index = tblMain.SelectedRows(0).Index
        tblMain.Rows(index).Cells(4).Value = "缺席"
        tblMain.Rows(index).Cells(4).Style.BackColor = Color.PaleVioletRed
        If index < tblMain.RowCount - 1 Then
            tblMain.Rows(index + 1).Selected = True
            tblMain.FirstDisplayedScrollingRowIndex = index
        End If
    End Sub

    Private Sub tblMain_Sorted(sender As Object, e As EventArgs) Handles tblMain.Sorted
        For Each row As DataGridViewRow In tblMain.Rows
            If row.Cells(4).Value.Equals("出席") Then
                row.Cells(4).Style.BackColor = Color.LightGreen
            ElseIf row.Cells(4).Value.Equals("請假") Then
                row.Cells(4).Style.BackColor = Color.LightGray
            ElseIf row.Cells(4).Value.Equals("遲到") Then
                row.Cells(4).Style.BackColor = Color.LightBlue
            ElseIf row.Cells(4).Value.Equals("缺席") Then
                row.Cells(4).Style.BackColor = Color.PaleVioletRed
            End If
        Next
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

    End Sub

End Class