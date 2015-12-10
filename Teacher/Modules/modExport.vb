Imports PdfSharp.Pdf
Imports PdfSharp.Drawing

Module modExport

    Public Sub exportSeatToPdf(img As Image, sPath As String)
        Dim doc As New PdfDocument()
        Dim pge As New PdfPage()
        pge.Size = PdfSharp.PageSize.A4
        pge.Rotate = 90
        doc.Pages.Add(pge)
        Dim xgr As XGraphics = XGraphics.FromPdfPage(pge)
        Dim nPageW = xgr.PageSize.Width
        Dim nPageH = xgr.PageSize.Height
        Dim imgResult As XImage = XImage.FromGdiPlusImage(img)
        xgr.DrawImage(imgResult, 0, 0, nPageH, nPageW)

        doc.Save(sPath)
        doc.Close()
        System.Diagnostics.Process.Start(sPath)
    End Sub

End Module
