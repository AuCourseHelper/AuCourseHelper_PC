Public Class dlgChoose_SeatLayout

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
            Case 1 ' 712
                grbMain.Enabled = False
                txtCol.Text = "12"
                txtRow.Text = "7"
                txtAisle.Text = "4"
        End Select
    End Sub
End Class