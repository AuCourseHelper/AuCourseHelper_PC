Public Class frmProgress
    Dim a As Integer = 0
    Public Shared title As String = "..."

    Private Sub frmProgress_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        'e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
        DrawProgress(e.Graphics, New Rectangle(6, 6, 137, 137), a)
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
        Dim pt As New Point((150 - msr.Width) / 2, (150 - msr.Height) / 2)
        msr.Width += 2
        g.FillRectangle(Brushes.LightGreen, pt.X, pt.Y, msr.Width, msr.Height)
        g.DrawString(title, font, Brushes.Black, pt)
        'draw the text in the centre by working out how big it is and adjusting the co-ordinates accordingly
        'Using fnt As New Font(Me.Font.FontFamily, 14)
        '    Dim text As String = percentage.ToString + "%"
        '    Dim textSize = g.MeasureString(text, fnt)
        '    Dim textPoint As New Point(CInt(rect.Left + (rect.Width / 2) - (textSize.Width / 2)), CInt(rect.Top + (rect.Height / 2) - (textSize.Height / 2)))
        '    'now we have all the values draw the text
        '    g.DrawString(text, fnt, Brushes.Black, textPoint)
        'End Using
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If a >= 200 Then
            a = 0
        End If
        a += 1
        Me.Refresh()
    End Sub
End Class