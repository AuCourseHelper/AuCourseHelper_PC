Public Class dlgChoose_SeatLayout
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
End Class