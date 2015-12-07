Imports System.Threading

Public Class frmAttend
    Private seatLayout As TableLayoutPanel
    Private seats() As ctrlSeat
    Private seatView As Integer = 0
    Private nRow As Integer = 0
    Private nCol As Integer = 0
    Private nAisle As Integer = 0
    Private Const sHelp1 = "說明：點擊右上角顏色按鈕對當前反白學生點名，點名後自動向下選取。"
    Private Const sHelp2 = "說明：點擊學生座位編號對該學生點名，綠色:出席  藍色:遲到  紅色:缺席  灰色:請假(病、事、公)。"
    Private Const sHelp3 = "說明：點名資料已儲存，若欲編輯資料請至 <<修改資料>> 功能。"

    Private Sub frmAttend_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblDate.Text = nowWeekDetail
        lblDate2.Text = nowWeekDetail
        ' 表格部分
        If Not bAttendHasData Then
            doCourseDtAttend = doCourseStudents.Copy
            doCourseDtAttend.Columns.Add("出席狀況")
            For Each row As DataRow In doCourseDtAttend.Rows
                row.Item("出席狀況") = ""
            Next
        End If
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
            pnlControl2.Enabled = True
        End If
        updateGrid()
        updateSeat()
        lblHelp.Text = sHelp1

        If bAttendHasData Then
            pnlBtn.Enabled = False
            pnlBtn2.Enabled = False
        End If
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
        tblMain.Rows(index).Cells("出席狀況").Value = sAttend
        Select Case sAttend
            Case "出席"
                tblMain.Rows(index).Cells("出席狀況").Style.BackColor = CL_BK_GREEN
            Case "病假", "事假", "公假"
                tblMain.Rows(index).Cells("出席狀況").Style.BackColor = CL_BK_GRAY
            Case "遲到"
                tblMain.Rows(index).Cells("出席狀況").Style.BackColor = CL_BK_BLUE
            Case "缺席"
                tblMain.Rows(index).Cells("出席狀況").Style.BackColor = CL_BK_RED
        End Select
        If index < tblMain.RowCount - 1 Then
            tblMain.Rows(index + 1).Selected = True
            If index > tblMain.DisplayedRowCount(False) - 4 Then
                tblMain.FirstDisplayedScrollingRowIndex = index - tblMain.DisplayedRowCount(False) + 3
            End If
        End If
        isSaved = False
    End Sub

    Private Sub tblMain_Paint(sender As Object, e As PaintEventArgs) Handles tblMain.Paint
        updateGrid()
    End Sub

    Private Sub updateGrid()
        For Each row As DataGridViewRow In tblMain.Rows
            If row.Cells("出席狀況").Value.Equals("出席") Then
                row.Cells("出席狀況").Style.BackColor = CL_BK_GREEN
            ElseIf row.Cells("出席狀況").Value.ToString.Contains("假") Then
                row.Cells("出席狀況").Style.BackColor = CL_BK_GRAY
            ElseIf row.Cells("出席狀況").Value.Equals("遲到") Then
                row.Cells("出席狀況").Style.BackColor = CL_BK_BLUE
            ElseIf row.Cells("出席狀況").Value.Equals("缺席") Then
                row.Cells("出席狀況").Style.BackColor = CL_BK_RED
            Else
                row.Cells("出席狀況").Style.BackColor = tblMain.DefaultCellStyle.BackColor
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

    Private Sub btnSave_Click() Handles btnSave.Click
        Dim bAsAbs As Boolean = False
        For Each row As DataRow In doCourseDtAttend.Rows
            Select Case row.Item("出席狀況")
                Case "出席"

                Case "遲到"
                    doCourseAttend.Lat &= row.Item("學號") & ","
                Case "缺席"
                    doCourseAttend.Abs &= row.Item("學號") & ","
                Case "病假", "事假", "公假"
                    doCourseAttend.Off &= row.Item("學號") & "-" & row.Item("出席狀況").Chars(0) & ","
                Case Else
                    If bAsAbs Then
                        row.Item("出席狀況") = "缺席"
                        doCourseAttend.Abs &= row.Item("學號") & ","
                    Else
                        If MsgBox("尚有學生未點名！" & vbCrLf & "是否將未點名學生視為缺席？" _
                                  , MsgBoxStyle.YesNo, "點名") = MsgBoxResult.Yes Then
                            row.Item("出席狀況") = "缺席"
                            doCourseAttend.Abs &= row.Item("學號") & ","
                            bAsAbs = True
                        Else
                            doCourseAttend.Off = ""
                            doCourseAttend.Lat = ""
                            doCourseAttend.Abs = ""
                            Exit Sub
                        End If
                    End If
            End Select
        Next
        updateGrid()
        lblHelp.Text = sHelp3
        Dim nOff As Integer = doCourseAttend.Off.Split(",").Length
        Dim nLat As Integer = doCourseAttend.Lat.Split(",").Length
        Dim nAbs As Integer = doCourseAttend.Abs.Split(",").Length
        pnlBtn.Enabled = False
        pnlBtn2.Enabled = False
        For Each seat As ctrlSeat In seats
            seat.btnSeat.Enabled = False
        Next
        MsgBox(doCourseAttend.Off)
        MsgBox(doCourseAttend.Lat)
        MsgBox(doCourseAttend.Abs)
        isSaved = True
        bAttendHasData = True
    End Sub

    Private Sub btnCancel_Click() Handles btnCancel.Click
        If MsgBox("確定要清空本次點名資料？", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            For Each row As DataRow In doCourseDtAttend.Rows
                row.Item("出席狀況") = ""
            Next
            doCourseAttend.Off = ""
            doCourseAttend.Lat = ""
            doCourseAttend.Abs = ""
            updateGrid()
            updateSeat()
        End If
    End Sub

    Private Sub btnSave2_Click(sender As Object, e As EventArgs) Handles btnSave2.Click
        btnSave_Click()
        updateSeat()
    End Sub

    Private Sub btnCancel2_Click(sender As Object, e As EventArgs) Handles btnCancel2.Click
        btnCancel_Click()
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

    Private Sub tabMain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabMain.SelectedIndexChanged
        Select Case tabMain.SelectedTab.Name
            Case "tabTable"
                updateGrid()
                lblHelp.Text = sHelp1
            Case "tabSeat"
                updateSeat()
                lblHelp.Text = sHelp2
                For Each seat As ctrlSeat In seats
                    seat.showInfo()
                Next
        End Select
        If bAttendHasData Then
            lblHelp.Text = sHelp3
        End If
    End Sub
End Class