Public Class frmList
    Private seatLayout As TableLayoutPanel
    Private seats() As ctrlSeat
    Private seatView As Integer = 0
    Private nRow As Integer = 0
    Private nCol As Integer = 0
    Private nAisle As Integer = 0

    Private Sub btnCreateSeat_Click(sender As Object, e As EventArgs) Handles btnCreateSeat.Click
        
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
            tabMain.SelectedIndex = 1
        End If

        updateSeat()
    End Sub

    Private Sub updateSeat()
        Dim nNoSeat As Integer = 0
        For Each row As DataRow In doCourseStudents.Rows
            If row.Item("座位").ToString.Length > 1 Then
                Dim seat As ctrlSeat = seatLayout.Controls.Find(row.Item("座位"), True)(0)
                seat.updateAttend(row.Item("學號"), row.Item("姓名"), "顯示")
            Else
                nNoSeat += 1
            End If
        Next
        If nNoSeat > 0 Then
            lblNoSeat.Text = "尚有 " & nNoSeat & " 位學生" & vbCrLf & "未編排座位"
        Else
            lblNoSeat.Text = ""
        End If
    End Sub

    Private Sub btnChangeView_Click(sender As Object, e As EventArgs) Handles btnChangeView.Click
        seatLayout.Visible = False
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
        seatLayout.Visible = True
    End Sub

    Private Sub lblNoSeat_Click(sender As Object, e As EventArgs) Handles lblNoSeat.Click
        Dim allAutoCompletes = From row In doCourseStudents.Select("座位=''").AsEnumerable()
                       Let autoComplete = New String(row.Item("學號") & "  " & Trim(row.Item("姓名")))
                       Select autoComplete
        Dim autoCompleteString As String() = allAutoCompletes.ToArray()
        Dim x As String = ""
        MsgBox("編輯座位請使用 <<修改資料>> 功能" & vbCrLf & String.Join(vbCrLf, autoCompleteString), MsgBoxStyle.OkOnly, "未編排座位名單")
    End Sub

    Private Sub btnPrintSeat_Click(sender As Object, e As EventArgs) Handles btnPrintSeat.Click

    End Sub

    Private Sub btnExportSeat_Click(sender As Object, e As EventArgs) Handles btnExportSeat.Click
        Dim bm As New Bitmap(Me.Width, Me.Height)
        Me.DrawToBitmap(bm, New Rectangle(0, 0, Me.Width, Me.Height))
        exportSeatToPdf(bm, "D:\20151210.pdf")
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click

    End Sub
End Class