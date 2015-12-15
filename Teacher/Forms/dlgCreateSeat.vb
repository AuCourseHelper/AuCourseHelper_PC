Imports System.Threading

Public Class dlgCreateSeat
    Private seatLayout As TableLayoutPanel
    Private seats() As ctrlSeat
    Private seatView As Integer = 0
    Private nRow As Integer = 0
    Private nCol As Integer = 0
    Private nAisle() As Integer

    Public Shared dtStudents As DataTable
    Public Shared sType As String ' 座位表新增型態: 首次、新增、編輯

    Private Sub dlgCreateSeat_Load(sender As Object, e As EventArgs) Handles Me.Load
        btnLayout.PerformClick()
    End Sub

    Private Sub btnLayout_Click(sender As Object, e As EventArgs) Handles btnLayout.Click
        dlgChoose_SeatLayout.ShowDialog(Me)
        If dlgChoose_SeatLayout.nCol <> nCol Or dlgChoose_SeatLayout.nRow <> nRow Or dlgChoose_SeatLayout.nAisle IsNot nAisle Then
            ' 清空學生座位內容
            pnlSeat.Controls.Clear()
            For Each row As DataRow In dlgCreateSeat.dtStudents.Rows
                row.Item("座位") = ""
            Next

            seatView = 0
            nCol = dlgChoose_SeatLayout.nCol
            nRow = dlgChoose_SeatLayout.nRow
            nAisle = dlgChoose_SeatLayout.nAisle

            ReDim seats(nRow * (nCol - nAisle.Length) - 1)
            Dim nSeatCount = 0

            ' 定義欄位名稱
            Dim sColName(nCol - 1) As String
            Dim nTemp As Integer = 1
            For i As Integer = 0 To nCol - 1
                If Array.IndexOf(nAisle, i + 1) < 0 Then
                    sColName(i) = Format(nTemp, "00")
                    nTemp += 1
                End If
            Next

            seatLayout = New TableLayoutPanel
            seatLayout.Dock = DockStyle.Fill
            seatLayout.ColumnCount = nCol
            seatLayout.RowCount = nRow
            For row As Integer = 0 To seatLayout.RowCount - 1
                For col As Integer = 0 To seatLayout.ColumnCount - 1
                    If row = 0 Then
                        If nAisle.Length > 0 Then
                            If Array.IndexOf(nAisle, col + 1) >= 0 Then
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

                    If nAisle.Length > 0 Then
                        If Array.IndexOf(nAisle, col + 1) < 0 Then
                            Dim seat As New ctrlSeat
                            seat.init(Chr(row + 65) & sColName(col), , , 1)
                            seatLayout.Controls.Add(seat, col, row)
                            seats(nSeatCount) = seat
                            nSeatCount += 1
                        End If
                    Else
                        Dim seat As New ctrlSeat
                        seat.init(Chr(row + 65) & sColName(col), , , 1)
                        seatLayout.Controls.Add(seat, col, row)
                        seats(nSeatCount) = seat
                        nSeatCount += 1
                    End If
                Next
            Next
            pnlSeat.Controls.Add(seatLayout)
        End If
    End Sub

    Private Sub btnRand_Click(sender As Object, e As EventArgs) Handles btnRand.Click
        btnDel.PerformClick()
        Dim rndNum As New Random
        Dim dtForRand As DataTable = dtStudents.Copy
        Dim nSeatCount As Integer = 0
        While dtForRand.Rows.Count > 0
            Dim row As DataRow = dtForRand.Rows(rndNum.Next(dtForRand.Rows.Count))
            seats(nSeatCount).updateAttend(row.Item("學號"), row.Item("姓名"), "")
            dlgCreateSeat.dtStudents.Select("學號='" & row.Item("學號") & "'")(0).Item("座位") = seats(nSeatCount).Tag
            dtForRand.Rows.Remove(row)
            nSeatCount += 1
        End While
    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        ' 清空學生座位內容
        For Each row As DataRow In dlgCreateSeat.dtStudents.Rows
            row.Item("座位") = ""
        Next

        ' 清空座位顯示內容
        For Each seat As ctrlSeat In seats
            seat.init(seat.Tag, , , 1)
        Next
    End Sub

    Private Sub btnChangeView_Click(sender As Object, e As EventArgs) Handles btnChangeView.Click
        Dim nSeatCount = 0
        pnlSeat.Controls.Clear()

        ' 定義欄位名稱
        Dim sColName(nCol - 1) As String

        If seatView = 0 Then ' 原黑板在上
            seatView = 1
            Dim nTemp As Integer = nCol - nAisle.Length
            For i As Integer = 0 To nCol - 1
                If Array.IndexOf(nAisle, i + 1) < 0 Then ' 不是走道時
                    sColName(i) = Format(nTemp, "00")
                    nTemp -= 1
                Else
                    sColName(i) = "-"
                End If
            Next

            lblFront.Dock = DockStyle.Bottom
            seatLayout = New TableLayoutPanel
            seatLayout.Dock = DockStyle.Fill
            seatLayout.ColumnCount = nCol
            seatLayout.RowCount = nRow
            For row As Integer = seatLayout.RowCount - 1 To 0 Step -1
                For col As Integer = seatLayout.ColumnCount - 1 To 0 Step -1
                    If row = seatLayout.RowCount - 1 Then
                        If nAisle.Length > 0 Then
                            If Array.IndexOf(nAisle, col + 1) >= 0 Then
                                seatLayout.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 25))
                            Else
                                seatLayout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50))
                            End If
                        Else
                            seatLayout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50))
                        End If
                    End If
                    If col = seatLayout.ColumnCount - 1 Then
                        seatLayout.RowStyles.Add(New RowStyle(SizeType.Percent, 50))
                    End If

                    If nAisle.Length > 0 Then
                        If Array.IndexOf(nAisle, col + 1) < 0 Then
                            seatLayout.Controls.Add(getSeatByName(Chr(64 + seatLayout.RowCount - row) & sColName(col)), col, row)
                        End If
                    Else
                        seatLayout.Controls.Add(getSeatByName(Chr(64 + seatLayout.RowCount - row) & sColName(col)), col, row)
                    End If
                Next
            Next
            pnlSeat.Controls.Add(seatLayout)
        Else ' 原黑板在下
            seatView = 0
            Dim nTemp As Integer = 1
            For i As Integer = 0 To nCol - 1
                If Array.IndexOf(nAisle, i + 1) < 0 Then ' 不是走道時
                    sColName(i) = Format(nTemp, "00")
                    nTemp += 1
                End If
            Next

            lblFront.Dock = DockStyle.Top
            seatLayout = New TableLayoutPanel
            seatLayout.Dock = DockStyle.Fill
            seatLayout.ColumnCount = nCol
            seatLayout.RowCount = nRow
            For row As Integer = 0 To seatLayout.RowCount - 1
                For col As Integer = 0 To seatLayout.ColumnCount - 1
                    If row = 0 Then
                        If nAisle.Length > 0 Then
                            If Array.IndexOf(nAisle, col + 1) >= 0 Then
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

                    If nAisle.Length > 0 Then
                        If Array.IndexOf(nAisle, col + 1) < 0 Then
                            seatLayout.Controls.Add(seats(nSeatCount), col, row)
                            nSeatCount += 1
                        End If
                    Else
                        seatLayout.Controls.Add(seats(nSeatCount), col, row)
                        nSeatCount += 1
                    End If
                Next
            Next
            pnlSeat.Controls.Add(seatLayout)
        End If
    End Sub

    Private Function getSeatByName(sSeatName As String) As ctrlSeat
        For Each seat As ctrlSeat In seats
            If seat.Tag = sSeatName Then
                Return seat
            End If
        Next
        Return Nothing
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Select Case sType
            Case "首次"
                dlgCreateList.dtTmpCourseStudents = dtStudents
            Case "新增"
                Me.Enabled = False
                Dim t As New Thread(AddressOf doSave)
                t.Start()
                dlgProgress.title = "儲存課程座位編排..."
                dlgProgress.ShowDialog(Me)
                Me.Enabled = True
            Case "編輯"

        End Select
        Me.Dispose()
    End Sub

    Private Sub doSave()
        Dim sSeat = nCol & "," & nRow & ","
        For Each nAis As Integer In nAisle
            sSeat &= nAis & "-"
        Next
        sSeat = sSeat.Substring(0, sSeat.Length - 1)
        Dim sSql = String.Format("UPDATE Course SET Seat='{0}' WHERE Id='{1}';", sSeat, doCourse.Item("Id"))
        doSqlCmd(sSql)

        dlgProgress.title = "儲存學生座位資訊..."
        sSql = ""
        For Each row As DataRow In dtStudents.Rows
            sSql &= String.Format("UPDATE CourseStudent SET Seat='{0}' WHERE CourseId='{1}' AND StudentNum='{2}'#", _
                                  row.Item("座位"), doCourse.Item("Id"), row.Item("學號"))
        Next
        doSqlCmds(sSql)
        dlgProgress.isOff = True
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub
End Class