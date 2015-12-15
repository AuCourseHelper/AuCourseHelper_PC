Public Class dlgChoose_SeatLayout
    Public Shared nStudentCount As Integer
    Public Shared nCol As Integer = 0
    Public Shared nRow As Integer = 0
    Public Shared nAisle() As Integer

    Private Sub dlgChoose_SeatLayout_Load(sender As Object, e As EventArgs) Handles Me.Load
        cboType.SelectedIndex = 0
    End Sub

    Private Sub cboType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboType.SelectedIndexChanged
        Select Case cboType.SelectedIndex
            Case 0 ' 自訂
                grbMain.Enabled = True
                txtCol.Text = "0"
                txtRow.Text = "0"
                txtAisle.Text = "0"
            Case 1 ' 605電腦教室
                grbMain.Enabled = False
                txtCol.Text = "11"
                txtRow.Text = "7"
                txtAisle.Text = "7"
            Case 2 ' 712電腦教室
                grbMain.Enabled = False
                txtCol.Text = "14"
                txtRow.Text = "7"
                txtAisle.Text = "5-10"
            Case 3 ' 911、912電腦教室
                grbMain.Enabled = False
                txtCol.Text = "16"
                txtRow.Text = "6"
                txtAisle.Text = "5-12"
            Case 4 ' 913電腦教室
                grbMain.Enabled = False
                txtCol.Text = "12"
                txtRow.Text = "9"
                txtAisle.Text = "3-10"
            Case 5 ' 921電腦教室
                grbMain.Enabled = False
                txtCol.Text = "12"
                txtRow.Text = "6"
                txtAisle.Text = "3-10"
        End Select
    End Sub

    Public Shared Function _StringToInteger(ByVal s As String) As Integer
        Return Val(s)
    End Function

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If Val(txtCol.Text) < 1 Or Val(txtRow.Text < 1) Then
            MsgBox("行列數必須大於0！", MsgBoxStyle.Critical)
        Else
            nCol = Val(txtCol.Text)
            nRow = Val(txtRow.Text)
            nAisle = Array.ConvertAll(txtAisle.Text.Split("-"), _
                                      New Converter(Of String, Integer)(AddressOf _StringToInteger))
            Me.Dispose()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub All_TextChanged(sender As Object, e As EventArgs) Handles txtCol.TextChanged, txtRow.TextChanged, txtAisle.TextChanged
        nCol = Val(txtCol.Text)
        nRow = Val(txtRow.Text)
        nAisle = Array.ConvertAll(txtAisle.Text.Split("-"), _
                                  New Converter(Of String, Integer)(AddressOf _StringToInteger))
        Dim pnlShow As New TableLayoutPanel
        pnlShow = New TableLayoutPanel
        pnlShow.Dock = DockStyle.Fill
        pnlShow.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        pnlShow.Margin = New Padding(0)
        pnlShow.ColumnCount = nCol
        pnlShow.RowCount = nRow
        For row As Integer = 0 To pnlShow.RowCount - 1
            For col As Integer = 0 To pnlShow.ColumnCount - 1
                If row = 0 Then
                    If nAisle.Length > 0 Then
                        If Array.IndexOf(nAisle, col + 1) >= 0 Then
                            pnlShow.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 25))
                        Else
                            pnlShow.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50))
                        End If
                    Else
                        pnlShow.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50))
                    End If
                End If
                If col = 0 Then
                    pnlShow.RowStyles.Add(New RowStyle(SizeType.Percent, 50))
                End If

                If nAisle.Length > 0 Then
                    If Array.IndexOf(nAisle, col + 1) >= 0 Then
                        Dim pnlTmp As New Panel
                        pnlTmp.Margin = New Padding(0)
                        pnlTmp.Dock = DockStyle.Fill
                        pnlTmp.BackColor = Color.DarkGray
                        pnlShow.Controls.Add(pnlTmp, col, row)
                    End If
                End If
            Next
        Next
        pnlMain.Controls.Clear()
        pnlMain.Controls.Add(pnlShow)
    End Sub
End Class