Public Class frmList
    Private seatLayout As TableLayoutPanel
    Private seats() As ctrlSeat

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim bm As New Bitmap(seatLayout.Width, seatLayout.Height)
        seatLayout.DrawToBitmap(bm, New Rectangle(0, 0, bm.Width, bm.Height))
        exportSeatToPdf(bm, "D:\20151210.pdf")
    End Sub
End Class