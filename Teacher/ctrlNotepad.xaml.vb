Public Class ctrlNotepad

    Private Sub mainRTB_PreviewMouseWheel(sender As Object, e As Windows.Input.MouseWheelEventArgs) Handles mainRTB.PreviewMouseWheel
        If e.Delta > 0 And Control.ModifierKeys = Keys.Control Then
            mainRTB.FontSize += 5
            e.Handled = True
        ElseIf e.Delta < 0 And Control.ModifierKeys = Keys.Control Then
            If mainRTB.FontSize > 6 Then
                mainRTB.FontSize -= 5
                e.Handled = True
            End If
        End If
    End Sub
End Class
