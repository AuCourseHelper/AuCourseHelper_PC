Public Class frmList
    Private seatLayout As TableLayoutPanel
    Private seats() As ctrlSeat
    Private nRow As Integer = 0
    Private nCol As Integer = 0
    Private nAisle As Integer = 0

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim bm As New Bitmap(seatLayout.Width, seatLayout.Height)
        seatLayout.DrawToBitmap(bm, New Rectangle(0, 0, bm.Width, bm.Height))
        exportSeatToPdf(bm, "D:\20151210.pdf")
    End Sub

    Private Sub frmList_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblDate.Text = nowWeekDetail
        lblDate2.Text = nowWeekDetail
        ' 表格部分
        tblMain.DataSource = doCourseStudents
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
            pnlControl2.Enabled = True
        End If
        updateGrid()
        updateSeat()
        lblHelp.Text = sHelp1

        If bAttendHasData Then
            pnlBtn.Enabled = False
            pnlBtn2.Enabled = False
            seatLayout.Enabled = False
        End If
    End Sub
End Class