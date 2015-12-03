Imports System.Threading

Public Class frmAttend
    Private seatLayout As TableLayoutPanel
    Private seats() As ctrlSeat
    Private seatView As Integer = 0
    Private nRow As Integer = 0
    Private nCol As Integer = 0
    Private nAisle As Integer = 0

    Private Sub frmAttend_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblDate.Text = nowWeekDetail
        lblDate2.Text = nowWeekDetail
        Try
            ' 表格部分
            doCourseDtAttend = doCourseStudents.Copy
            doCourseDtAttend.Columns.Add("出席狀況")
            For Each row As DataRow In doCourseDtAttend.Rows
                row.Item("出席狀況") = ""
            Next
            tblMain.DataSource = doCourseDtAttend
            tblMain.Rows(0).Selected = True
            ' 座位部分
            If Not doCourse.Item("Seat").ToString.StartsWith("0,0") Then
                nRow = CInt(doCourse.Item("Seat").ToString.Split(",")(0))
                nCol = CInt(doCourse.Item("Seat").ToString.Split(",")(1))
                nAisle = CInt(doCourse.Item("Seat").ToString.Split(",")(2))
                If nAisle > 0 Then
                    ReDim seats(nRow * (nCol - Math.Floor(nCol / nAisle)) - 1)
                Else
                    ReDim seats(nRow * nCol - 1)
                End If
                Dim nSeatCount = 0

                seatLayout = New TableLayoutPanel
                seatLayout.Dock = DockStyle.Fill
                seatLayout.ColumnCount = nCol
                seatLayout.RowCount = nRow
                For col As Integer = 0 To seatLayout.ColumnCount - 1
                    For row As Integer = 0 To seatLayout.RowCount - 1
                        If row = 0 Then
                            If nAisle <> 0 Then
                                If (col + 1) Mod nAisle = 0 Then
                                    seatLayout.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 25))
                                Else
                                    seatLayout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50))
                                End If
                            Else
                                seatLayout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50))
                            End If
                        End If
                        If col = 0 Then
                            seatLayout.RowStyles.Add(New RowStyle(SizeType.Percent, 50))
                        End If

                        If nAisle <> 0 Then
                            If Not (col + 1) Mod nAisle = 0 Then
                                Dim seat As New ctrlSeat
                                seat.init(Chr(row + 65) & Format(col + 1 - Math.Floor((col + 1) / nAisle), "00"))
                                seatLayout.Controls.Add(seat, col, row)
                                seats(nSeatCount) = seat
                                nSeatCount += 1
                            End If
                        Else
                            Dim seat As New ctrlSeat
                            seat.init(Chr(row + 65) & Format(col + 1 - Math.Floor((col + 1) / nAisle), "00"))
                            seatLayout.Controls.Add(seat, col, row)
                            seats(nSeatCount) = seat
                            nSeatCount += 1
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
                updateGrid()
            Case "tabSeat"
                updateSeat()
        End Select
    End Sub

    Private Sub btnAtt_Click(sender As Object, e As EventArgs) Handles btnAtt.Click
        addAttend("出席")
    End Sub

    Private Sub btnOffSick_Click(sender As Object, e As EventArgs) Handles btnOffSick.Click
        addAttend("病假")
    End Sub

    Private Sub btnOffThing_Click(sender As Object, e As EventArgs) Handles btnOffThing.Click
        addAttend("事假")
    End Sub

    Private Sub btnOffPublic_Click(sender As Object, e As EventArgs) Handles btnOffPublic.Click
        addAttend("公假")
    End Sub

    Private Sub btnLat_Click(sender As Object, e As EventArgs) Handles btnLat.Click
        addAttend("遲到")
    End Sub

    Private Sub btnAbs_Click(sender As Object, e As EventArgs) Handles btnAbs.Click
        addAttend("缺席")
    End Sub

    Private Sub addAttend(sAttend As String)
        Dim index = tblMain.SelectedRows(0).Index

        'If tblMain.Rows(index).Cells("出席狀況").Value IsNot DBNull.Value Then
        '    If doCourseAttend.Off.Contains(tblMain.Rows(index).Cells("學號").Value) Then
        '        Dim sOff As String = doCourseAttend.Off.Chars(doCourseAttend.Off.IndexOf(tblMain.Rows(index).Cells("學號").Value) + 9)
        '        doCourseAttend.Off = doCourseAttend.Off.Replace(tblMain.Rows(index).Cells("學號").Value & "-" & sOff & ",", "")
        '    ElseIf doCourseAttend.Lat.Contains(tblMain.Rows(index).Cells("學號").Value) Then
        '        doCourseAttend.Lat = doCourseAttend.Lat.Replace(tblMain.Rows(index).Cells("學號").Value & ",", "")
        '    ElseIf doCourseAttend.Abs.Contains(tblMain.Rows(index).Cells("學號").Value) Then
        '        doCourseAttend.Abs = doCourseAttend.Abs.Replace(tblMain.Rows(index).Cells("學號").Value & ",", "")
        '    End If
        'End If

        tblMain.Rows(index).Cells("出席狀況").Value = sAttend
        Select Case sAttend
            Case "出席"
                tblMain.Rows(index).Cells("出席狀況").Style.BackColor = CL_BK_GREEN
            Case "病假", "事假", "公假"
                tblMain.Rows(index).Cells("出席狀況").Style.BackColor = CL_BK_GRAY
                'doCourseAttend.Off &= tblMain.Rows(index).Cells("學號").Value & "-" & sAttend.Chars(0) & ","
            Case "遲到"
                tblMain.Rows(index).Cells("出席狀況").Style.BackColor = CL_BK_BLUE
                'doCourseAttend.Lat &= tblMain.Rows(index).Cells("學號").Value & ","
            Case "缺席"
                tblMain.Rows(index).Cells("出席狀況").Style.BackColor = CL_BK_RED
                'doCourseAttend.Abs &= tblMain.Rows(index).Cells("學號").Value & ","
        End Select
        If index < tblMain.RowCount - 1 Then
            tblMain.Rows(index + 1).Selected = True
            If index > tblMain.DisplayedRowCount(False) - 4 Then
                tblMain.FirstDisplayedScrollingRowIndex = index - tblMain.DisplayedRowCount(False) + 3
            End If
        End If
        isSaved = False
    End Sub

    Private Sub tblMain_Sorted(sender As Object, e As EventArgs) Handles tblMain.Sorted
        updateGrid()
    End Sub

    Private Sub updateGrid()
        For Each row As DataGridViewRow In tblMain.Rows
            'Dim sOff() = doCourseAttend.Off.Split(",")
            'If doCourseAttend.Off.Contains(row.Cells("學號").Value) Then
            '    row.Cells("出席狀況").Value = doCourseAttend.Off.Substring(doCourseAttend.Off.IndexOf(row.Cells("學號").Value) + 9, 1) & "假"
            'ElseIf doCourseAttend.Lat.Contains(row.Cells("學號").Value) Then
            '    row.Cells("出席狀況").Value = "遲到"
            'ElseIf doCourseAttend.Abs.Contains(row.Cells("學號").Value) Then
            '    row.Cells("出席狀況").Value = "缺席"
            'End If

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

    Private Sub updateSeat()
        For Each row As DataRow In doCourseDtAttend.Rows
            If row.Item("座位").ToString.Length > 1 Then
                Dim seat As ctrlSeat = seatLayout.Controls.Find(row.Item("座位"), True)(0)
                seat.updateAttend(row.Item("學號"), row.Item("姓名"), row.Item("出席狀況"))
            End If
        Next
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        MsgBox(doCourseAttend.Off)
        MsgBox(doCourseAttend.Lat)
        MsgBox(doCourseAttend.Abs)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

    End Sub

    Private Sub btnSave2_Click(sender As Object, e As EventArgs) Handles btnSave2.Click
        btnSave.PerformClick()
    End Sub

    Private Sub btnCancel2_Click(sender As Object, e As EventArgs) Handles btnCancel2.Click
        btnCancel.PerformClick()
    End Sub

    Private Sub btnChangeView_Click(sender As Object, e As EventArgs) Handles btnChangeView.Click
        Dim nSeatCount = 0
        If seatView = 0 Then
            seatView = 1
            seatLayout.Controls.Clear()
            nSeatCount = seats.Length - 1
            For col As Integer = 0 To seatLayout.ColumnCount - 1
                For row As Integer = 0 To seatLayout.RowCount - 1
                    If nAisle <> 0 Then
                        If Not (col + 1) Mod nAisle = 0 Then
                            seatLayout.Controls.Add(seats(nSeatCount), col, row)
                            nSeatCount -= 1
                        End If
                    Else
                        seatLayout.Controls.Add(seats(nSeatCount), col, row)
                        nSeatCount -= 1
                    End If
                Next
            Next
        Else
            seatView = 0
            seatLayout.Controls.Clear()
            nSeatCount = 0
            For col As Integer = 0 To seatLayout.ColumnCount - 1
                For row As Integer = 0 To seatLayout.RowCount - 1
                    If nAisle <> 0 Then
                        If Not (col + 1) Mod nAisle = 0 Then
                            seatLayout.Controls.Add(seats(nSeatCount), col, row)
                            nSeatCount += 1
                        End If
                    Else
                        seatLayout.Controls.Add(seats(nSeatCount), col, row)
                        nSeatCount += 1
                    End If
                Next
            Next
        End If
    End Sub
End Class