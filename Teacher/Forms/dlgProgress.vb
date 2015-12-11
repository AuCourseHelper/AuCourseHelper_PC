Public Class dlgProgress
    Private a As Integer = 0
    Public Shared title As String = "..."
    Public Shared isOff As Boolean = False

    Private Sub frmProgress_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Cursor = Cursors.WaitCursor
        If isOff Then
            Me.Dispose()
            isOff = False
        End If
        DrawProgress(e.Graphics, New Rectangle(31, 31, 137, 137), a)
    End Sub

    Private Sub DrawProgress(g As Graphics, rect As Rectangle, percentage As Single)
        'work out the angles for each arc
        Dim progressAngle = CSng(360 / 100 * percentage)
        Dim remainderAngle = 360 - progressAngle

        'create pens to use for the arcs
        Using progressPen As New Pen(Color.DimGray, 13), remainderPen As New Pen(Color.DeepSkyBlue, 13)
            'set the smoothing to high quality for better output
            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            'draw the blue and white arcs
            g.DrawArc(progressPen, rect, -90, progressAngle)
            g.DrawArc(remainderPen, rect, progressAngle - 90, remainderAngle)
        End Using

        Dim font As New Font("", 12, FontStyle.Bold)
        Dim msr = g.MeasureString(title, font)
        Dim pt As New Point((Me.Width - msr.Width) / 2 - 2, (Me.Height - msr.Height) / 2)
        msr.Width += 2
        g.FillRectangle(Brushes.LightYellow, pt.X, pt.Y, msr.Width, msr.Height)
        g.DrawString(title, font, Brushes.Blue, pt)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If a >= 200 Then
            a = 0
        End If
        a += 1
        Me.Refresh()
    End Sub
End Class