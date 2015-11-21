Imports System.Windows.Media
Imports System.Windows.Documents

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

    Private Sub Button_Click(sender As Object, e As Windows.RoutedEventArgs)
        Dim dlgColor As New ColorDialog
        If dlgColor.ShowDialog() = DialogResult.OK Then
            Dim trg As New TextRange(mainRTB.Selection.Start, mainRTB.Selection.End)
            trg.ApplyPropertyValue(TextElement.ForegroundProperty, New SolidColorBrush(Color.FromRgb(dlgColor.Color.R, dlgColor.Color.G, dlgColor.Color.B)))
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As Windows.RoutedEventArgs)
        Dim dlgColor As New ColorDialog
        If dlgColor.ShowDialog() = DialogResult.OK Then
            Dim trg As New TextRange(mainRTB.Selection.Start, mainRTB.Selection.End)
            trg.ApplyPropertyValue(TextElement.BackgroundProperty, New SolidColorBrush(Color.FromRgb(dlgColor.Color.R, dlgColor.Color.G, dlgColor.Color.B)))
        End If
    End Sub
End Class
