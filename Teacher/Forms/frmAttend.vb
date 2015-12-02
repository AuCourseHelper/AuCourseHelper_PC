Imports System.Threading

Public Class frmAttend
    Dim isEdited As Boolean = False
    Dim seatLayout As TableLayoutPanel

    Private Sub frmAttend_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblDate.Text = nowWeekDetail
        lblDate2.Text = nowWeekDetail
        Try
            ' 表格部分
            Dim dtAttend As DataTable = doCourseStudents.Copy
            dtAttend.Columns.Add("出席狀況")
            tblMain.DataSource = dtAttend
            tblMain.Rows(0).Selected = True
            ' 座位部分
            If doCourse.Item("HasSeat").ToString = "1" Then
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
                pnlMain2.Controls.Clear()
                pnlMain2.Controls.Add(seatLayout)
                pnlBtn2.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub tabMain_Selected(sender As Object, e As TabControlEventArgs) Handles tabMain.Selected
        Select Case e.TabPage.Name
            Case "tabTable"
                
            Case "tabSeat"
                
        End Select
    End Sub

    Private Sub btnAtt_Click(sender As Object, e As EventArgs) Handles btnAtt.Click
        Dim index = tblMain.SelectedRows(0).Index
        tblMain.Rows(index).Cells("出席狀況").Value = "出席"
        tblMain.Rows(index).Cells("出席狀況").Style.BackColor = CL_BK_GREEN
        If index < tblMain.RowCount - 1 Then
            tblMain.Rows(index + 1).Selected = True
            If index > tblMain.DisplayedRowCount(False) - 4 Then
                tblMain.FirstDisplayedScrollingRowIndex = index - tblMain.DisplayedRowCount(False) + 3
            End If
        End If
    End Sub

    Private Sub btnOffSick_Click(sender As Object, e As EventArgs) Handles btnOffSick.Click
        Dim index = tblMain.SelectedRows(0).Index
        tblMain.Rows(index).Cells("出席狀況").Value = "病假"
        tblMain.Rows(index).Cells("出席狀況").Style.BackColor = CL_BK_GRAY
        If index < tblMain.RowCount - 1 Then
            tblMain.Rows(index + 1).Selected = True
            If index > tblMain.DisplayedRowCount(False) - 4 Then
                tblMain.FirstDisplayedScrollingRowIndex = index - tblMain.DisplayedRowCount(False) + 3
            End If
        End If
    End Sub

    Private Sub btnOffThing_Click(sender As Object, e As EventArgs) Handles btnOffThing.Click
        Dim index = tblMain.SelectedRows(0).Index
        tblMain.Rows(index).Cells("出席狀況").Value = "事假"
        tblMain.Rows(index).Cells("出席狀況").Style.BackColor = CL_BK_GRAY
        If index < tblMain.RowCount - 1 Then
            tblMain.Rows(index + 1).Selected = True
            If index > tblMain.DisplayedRowCount(False) - 4 Then
                tblMain.FirstDisplayedScrollingRowIndex = index - tblMain.DisplayedRowCount(False) + 3
            End If
        End If
    End Sub

    Private Sub btnOffPublic_Click(sender As Object, e As EventArgs) Handles btnOffPublic.Click
        Dim index = tblMain.SelectedRows(0).Index
        tblMain.Rows(index).Cells("出席狀況").Value = "公假"
        tblMain.Rows(index).Cells("出席狀況").Style.BackColor = CL_BK_GRAY
        If index < tblMain.RowCount - 1 Then
            tblMain.Rows(index + 1).Selected = True
            If index > tblMain.DisplayedRowCount(False) - 4 Then
                tblMain.FirstDisplayedScrollingRowIndex = index - tblMain.DisplayedRowCount(False) + 3
            End If
        End If
    End Sub

    Private Sub btnLat_Click(sender As Object, e As EventArgs) Handles btnLat.Click
        Dim index = tblMain.SelectedRows(0).Index
        tblMain.Rows(index).Cells("出席狀況").Value = "遲到"
        tblMain.Rows(index).Cells("出席狀況").Style.BackColor = CL_BK_BLUE
        If index < tblMain.RowCount - 1 Then
            tblMain.Rows(index + 1).Selected = True
            If index > tblMain.DisplayedRowCount(False) - 4 Then
                tblMain.FirstDisplayedScrollingRowIndex = index - tblMain.DisplayedRowCount(False) + 3
            End If
        End If
    End Sub

    Private Sub btnAbs_Click(sender As Object, e As EventArgs) Handles btnAbs.Click
        Dim index = tblMain.SelectedRows(0).Index
        tblMain.Rows(index).Cells("出席狀況").Value = "缺席"
        tblMain.Rows(index).Cells("出席狀況").Style.BackColor = CL_BK_RED
        If index < tblMain.RowCount - 1 Then
            tblMain.Rows(index + 1).Selected = True
            If index > tblMain.DisplayedRowCount(False) - 4 Then
                tblMain.FirstDisplayedScrollingRowIndex = index - tblMain.DisplayedRowCount(False) + 3
            End If
        End If
    End Sub

    Private Sub tblMain_Sorted(sender As Object, e As EventArgs) Handles tblMain.Sorted
        For Each row As DataGridViewRow In tblMain.Rows
            If row.Cells("出席狀況").Value.Equals("出席") Then
                row.Cells("出席狀況").Style.BackColor = CL_BK_GREEN
            ElseIf row.Cells("出席狀況").Value.ToString.Contains("假") Then
                row.Cells("出席狀況").Style.BackColor = CL_BK_GRAY
            ElseIf row.Cells("出席狀況").Value.Equals("遲到") Then
                row.Cells("出席狀況").Style.BackColor = CL_BK_BLUE
            ElseIf row.Cells("出席狀況").Value.Equals("缺席") Then
                row.Cells("出席狀況").Style.BackColor = CL_BK_RED
            End If
        Next
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

    End Sub
End Class