Public Class ctrlRTBTool
    Public Property 控制列 As Boolean = True

    Private Sub tmrMain_Tick(sender As Object, e As EventArgs) Handles tmrMain.Tick
        If Clipboard.ContainsText Then
            btnPaste.Enabled = True
            btnPasteText.Enabled = True
        ElseIf Clipboard.ContainsImage Then
            btnPaste.Enabled = True
            btnPasteText.Enabled = False
        Else
            btnPaste.Enabled = False
            btnPasteText.Enabled = False
        End If
        lblZoom.Text = rtbMain.ZoomFactor * 100 & "%"
    End Sub

    Private Sub rtbMain_KeyDown(sender As Object, e As KeyEventArgs) Handles rtbMain.KeyDown
        lblZoom.Text = rtbMain.ZoomFactor * 100 & "%"
    End Sub

    Private Sub lblZoom_Click(sender As Object, e As EventArgs) Handles lblZoom.Click
        rtbMain.ZoomFactor = 1
        lblZoom.Text = rtbMain.ZoomFactor * 100 & "%"
    End Sub

    Private Sub rtbMain_SelectionChanged(sender As Object, e As EventArgs) Handles rtbMain.SelectionChanged
        Dim row = rtbMain.GetLineFromCharIndex(rtbMain.SelectionStart) + 1
        Dim col = rtbMain.SelectionStart - rtbMain.GetFirstCharIndexFromLine(row - 1) + 1
        lblPoint.Text = "第" & row & "列，第" & col & "行"
        lblLength.Text = rtbMain.TextLength & "個字元"
        If rtbMain.SelectedText.Length > 0 Then
            btnCut.Enabled = True
            btnCopy.Enabled = True
            If rtbMain.SelectionFont.Bold Then
                btnB.BackColor = Color.LightGreen
            Else
                btnB.BackColor = tosMain.BackColor
            End If
            If rtbMain.SelectionFont.Italic Then
                btnI.BackColor = Color.LightGreen
            Else
                btnI.BackColor = tosMain.BackColor
            End If
            If rtbMain.SelectionFont.Underline Then
                btnU.BackColor = Color.LightGreen
            Else
                btnU.BackColor = tosMain.BackColor
            End If
        Else
            btnCut.Enabled = False
            btnCopy.Enabled = False
            btnB.BackColor = tosMain.BackColor
            btnI.BackColor = tosMain.BackColor
            btnU.BackColor = tosMain.BackColor
        End If
    End Sub

    Private Sub btnCut_Click(sender As Object, e As EventArgs) Handles btnCut.Click
        rtbMain.Cut()
    End Sub

    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        rtbMain.Copy()
    End Sub

    Private Sub btnPaste_Click(sender As Object, e As EventArgs) Handles btnPaste.Click
        rtbMain.Paste()
    End Sub

    Private Sub btnPasteText_Click(sender As Object, e As EventArgs) Handles btnPasteText.Click
        Dim fmtText As DataFormats.Format = DataFormats.GetFormat(DataFormats.Text)
        rtbMain.SelectedText = rtbMain.SelectedText & " "
        rtbMain.Select(rtbMain.SelectionStart - 1, 1)
        rtbMain.SelectionBackColor = rtbMain.BackColor
        rtbMain.SelectionColor = Color.Black
        rtbMain.Paste(fmtText)
    End Sub

    Private Sub btnUndo_Click(sender As Object, e As EventArgs) Handles btnUndo.Click
        rtbMain.Undo()
    End Sub

    Private Sub btnRedo_Click(sender As Object, e As EventArgs) Handles btnRedo.Click
        rtbMain.Redo()
    End Sub

    Private Sub btnB_Click(sender As Object, e As EventArgs) Handles btnB.Click
        If rtbMain.SelectionLength > 0 Then
            Dim currentFont As System.Drawing.Font = rtbMain.SelectionFont
            Dim newFontStyle As System.Drawing.FontStyle
            btnB.BackColor = Color.LightGreen
            newFontStyle = rtbMain.SelectionFont.Style Or FontStyle.Bold
            If rtbMain.SelectionFont.Bold = True Then
                btnB.BackColor = tosMain.BackColor
                newFontStyle = rtbMain.SelectionFont.Style Xor FontStyle.Bold
            End If
            rtbMain.SelectionFont = New Font(currentFont.FontFamily, currentFont.Size, newFontStyle)
        End If
    End Sub

    Private Sub btnI_Click(sender As Object, e As EventArgs) Handles btnI.Click
        If rtbMain.SelectionLength > 0 Then
            Dim currentFont As System.Drawing.Font = rtbMain.SelectionFont
            Dim newFontStyle As System.Drawing.FontStyle
            btnI.BackColor = Color.LightGreen
            newFontStyle = rtbMain.SelectionFont.Style Or FontStyle.Italic
            If rtbMain.SelectionFont.Italic = True Then
                btnI.BackColor = tosMain.BackColor
                newFontStyle = rtbMain.SelectionFont.Style Xor FontStyle.Italic
            End If
            rtbMain.SelectionFont = New Font(currentFont.FontFamily, currentFont.Size, newFontStyle)
        End If
    End Sub

    Private Sub btnU_Click(sender As Object, e As EventArgs) Handles btnU.Click
        If rtbMain.SelectionLength > 0 Then
            Dim currentFont As System.Drawing.Font = rtbMain.SelectionFont
            Dim newFontStyle As System.Drawing.FontStyle
            btnU.BackColor = Color.LightGreen
            newFontStyle = rtbMain.SelectionFont.Style Or FontStyle.Underline
            If rtbMain.SelectionFont.Italic = True Then
                btnU.BackColor = tosMain.BackColor
                newFontStyle = rtbMain.SelectionFont.Style Xor FontStyle.Underline
            End If
            rtbMain.SelectionFont = New Font(currentFont.FontFamily, currentFont.Size, newFontStyle)
        End If
    End Sub

    Private Sub btnUp_Click(sender As Object, e As EventArgs) Handles btnUp.Click
        If rtbMain.SelectionLength > 0 Then
            rtbMain.SelectionFont = New Font(rtbMain.SelectionFont.FontFamily, rtbMain.SelectionFont.Size + 2, rtbMain.SelectionFont.Style)
        End If
    End Sub

    Private Sub btnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
        If rtbMain.SelectionLength > 0 And rtbMain.SelectionFont.Size > 3 Then
            rtbMain.SelectionFont = New Font(rtbMain.SelectionFont.FontFamily, rtbMain.SelectionFont.Size - 2, rtbMain.SelectionFont.Style)
        End If
    End Sub

    Private Sub btnList_Click(sender As Object, e As EventArgs) Handles btnList.Click
        rtbMain.SelectionBullet = Not rtbMain.SelectionBullet
    End Sub

    Private Sub btnLeft_Click(sender As Object, e As EventArgs) Handles btnLeft.Click
        rtbMain.SelectionAlignment = HorizontalAlignment.Left
    End Sub

    Private Sub btnCenter_Click(sender As Object, e As EventArgs) Handles btnCenter.Click
        rtbMain.SelectionAlignment = HorizontalAlignment.Center
    End Sub

    Private Sub btnRight_Click(sender As Object, e As EventArgs) Handles btnRight.Click
        rtbMain.SelectionAlignment = HorizontalAlignment.Right
    End Sub

    Private Sub btnTabR_Click(sender As Object, e As EventArgs) Handles btnTabR.Click
        rtbMain.SelectionIndent = rtbMain.SelectionIndent + 50
    End Sub

    Private Sub btnTabL_Click(sender As Object, e As EventArgs) Handles btnTabL.Click
        rtbMain.SelectionIndent = rtbMain.SelectionIndent - 50
    End Sub

    Private Sub btnCol_Click(sender As Object, e As EventArgs) Handles btnCol.Click
        Dim dlgCol As New ColorDialog
        If dlgCol.ShowDialog = DialogResult.OK Then
            rtbMain.SelectionColor = dlgCol.Color
        End If
    End Sub

    Private Sub btnColBk_Click(sender As Object, e As EventArgs) Handles btnColBk.Click
        Dim dlgCol As New ColorDialog
        If dlgCol.ShowDialog = DialogResult.OK Then
            rtbMain.SelectionBackColor = dlgCol.Color
        End If
    End Sub

    Private Sub ctrlRTBTool_Load(sender As Object, e As EventArgs) Handles Me.Load
        staMain.Visible = 控制列
    End Sub

    Public Function saveFile(ByVal filePath As String) As Boolean
        Try
            rtbMain.SaveFile(filePath, RichTextBoxStreamType.RichText)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Sub openFile(ByVal filePath As String)
        Try
            rtbMain.LoadFile(filePath, RichTextBoxStreamType.RichText)
        Catch ex As Exception
            MsgBox("開啟檔案錯誤! " & ex.Message)
        End Try
    End Sub

    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        Dim dlgFile As New OpenFileDialog
        dlgFile.AddExtension = True
        dlgFile.CheckFileExists = True
        dlgFile.Filter = "RTF檔案|*.rtf"
        dlgFile.InitialDirectory = Application.StartupPath
        dlgFile.Multiselect = False
        If dlgFile.ShowDialog = DialogResult.OK Then
            openFile(dlgFile.FileName)
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim dlgFile As New SaveFileDialog
        dlgFile.AddExtension = True
        dlgFile.Filter = "RTF檔案|*.rtf"
        dlgFile.InitialDirectory = Application.StartupPath
        If dlgFile.ShowDialog = DialogResult.OK Then
            saveFile(dlgFile.FileName)
        End If
    End Sub
End Class
