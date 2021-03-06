﻿Public Class frmList
    Private seatLayout As TableLayoutPanel
    Private seats() As ctrlSeat
    Private seatView As Integer = 0
    Private nRow As Integer = 0
    Private nCol As Integer = 0
    Private nAisle() As Integer

    Private Sub btnCreateSeat_Click(sender As Object, e As EventArgs) Handles btnCreateSeat.Click
        dlgCreateSeat.dtStudents = doCourseStudents
        dlgCreateSeat.sType = "新增"
        dlgCreateSeat.ShowDialog(Me)
        Me.frmList_Load(Nothing, Nothing)
    End Sub

    Public Shared Function _StringToInteger(ByVal s As String) As Integer
        Return Val(s)
    End Function

    Private Sub frmList_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblDate.Text = nowWeekDetail
        lblDate2.Text = nowWeekDetail
        ' 表格部分
        tblMain.DataSource = doCourseStudents
        tblMain.Rows(0).Selected = True
        ' 座位部分
        If Not doCourse.Item("Seat").ToString.StartsWith("0,0") Then
            nCol = CInt(doCourse.Item("Seat").ToString.Split(",")(0))
            nRow = CInt(doCourse.Item("Seat").ToString.Split(",")(1))
            nAisle = Array.ConvertAll(doCourse.Item("Seat").ToString.Split(",")(2).Split("-"), _
                                      New Converter(Of String, Integer)(AddressOf _StringToInteger))
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
                            seat.init(Chr(row + 65) & sColName(col))
                            seatLayout.Controls.Add(seat, col, row)
                            seats(nSeatCount) = seat
                            nSeatCount += 1
                        End If
                    Else
                        Dim seat As New ctrlSeat
                        seat.init(Chr(row + 65) & sColName(col))
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
        pnlMain2.Controls.Clear()

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

            seatLayout = New TableLayoutPanel
            seatLayout.Dock = DockStyle.Fill
            seatLayout.ColumnCount = nCol
            seatLayout.RowCount = nRow
            For row As Integer = seatLayout.RowCount - 1 To 0 Step -1
                Dim nCount = 0
                For col As Integer = seatLayout.ColumnCount - 1 To 0 Step -1
                    If row = seatLayout.RowCount - 1 Then
                        If nAisle.Length > 0 Then
                            If Array.IndexOf(nAisle, nCount + 2) >= 0 Then
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
                        If Array.IndexOf(nAisle, nCount + 1) < 0 Then
                            seatLayout.Controls.Add(getSeatByName(Chr(64 + seatLayout.RowCount - row) & sColName(nCount)), col, row)
                        End If
                    Else
                        seatLayout.Controls.Add(getSeatByName(Chr(64 + seatLayout.RowCount - row) & sColName(nCount)), col, row)
                    End If
                    nCount += 1
                Next
            Next
            pnlMain2.Controls.Add(seatLayout)
        Else ' 原黑板在下
            seatView = 0

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
            pnlMain2.Controls.Add(seatLayout)
        End If
        seatLayout.Visible = True
    End Sub

    Private Function getSeatByName(sSeatName As String) As ctrlSeat
        For Each seat As ctrlSeat In seats
            If seat.Tag = sSeatName Then
                Return seat
            End If
        Next
        Return Nothing
    End Function

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