Public Class ctrlImageTip
    Inherits ToolTip
    Property imgMain As Image = IMG_NULL

    Public Sub New(Optional img As Image = Nothing)
        MyBase.New()
        If img IsNot Nothing Then
            imgMain = img
        End If
        Me.OwnerDraw = True 'Must be set otherwise will not draw the image properly
        Me.IsBalloon = False
    End Sub

    Private Sub ImageTip_Draw(ByVal sender As Object, ByVal e As DrawToolTipEventArgs) _
                Handles Me.Draw
        'Draws the image in the tooltip popup by reading the tooltip
        'text on the control that you want to have a popup for
        e.Graphics.DrawImage(imgMain, 0, 0)
    End Sub

    Private Sub ImageTip_Popup(ByVal sender As Object, ByVal e As PopupEventArgs) _
                Handles Me.Popup
        'Creates the popup and sets its dimensions from the resource name
        e.ToolTipSize = New Size(imgMain.Width, imgMain.Height)
    End Sub
End Class
