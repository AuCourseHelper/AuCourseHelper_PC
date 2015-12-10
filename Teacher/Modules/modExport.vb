Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Text

Module modExport

    Public Sub exportSeatToPdf(img As System.Drawing.Image, sPath As String)
        'Dim doc As New PdfDocument()
        'Dim pge As New PdfPage()
        'pge.Size = PdfSharp.PageSize.A4
        'pge.Rotate = 90
        'doc.Pages.Add(pge)
        'Dim xgr As XGraphics = XGraphics.FromPdfPage(pge)
        'Dim nPageW = xgr.PageSize.Width
        'Dim nPageH = xgr.PageSize.Height
        'Dim imgResult As XImage = XImage.FromGdiPlusImage(img)

        ''Dim options As New XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always)
        ''Dim font As XFont = New XFont("kaiu", 20, XFontStyle.Bold, options)
        'Dim xf As New XFont(New Font("Arial Unicode MS", 24, FontStyle.Bold, GraphicsUnit.World), New XPdfFontOptions(PdfFontEncoding.Unicode))
        'xgr.DrawString("104-1 " & "物件導向程式設計", xf, XBrushes.Blue, 10, 30)
        'xgr.DrawImage(imgResult, 10, 100, nPageH - 20, nPageW - 120)

        'doc.Save(sPath)
        'doc.Close()
        'System.Diagnostics.Process.Start(sPath)
        Dim doc1 As New Document(PageSize.A4.Rotate(), 25, 25, 25, 25) '宣告 Document 文件
        Dim path As String = "D:\000.pdf" '預設檔案存放的路徑
        Dim filename As String = "test" '檔案名稱
        Dim para1 As String = "104-1 物件導向程式設計"
        Dim writer = PdfWriter.GetInstance(doc1, New FileStream(path, FileMode.Create))
        doc1.Open() '開啟文件
        Dim jpgx As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(img, BaseColor.WHITE)
        jpgx.ScalePercent((doc1.PageSize.Height - 100) / jpgx.Height * 100)
        jpgx.Alignment = Element.ALIGN_CENTER

        Dim fontPath As String = Environment.GetFolderPath(Environment.SpecialFolder.System) & "\..\Fonts\kaiu.ttf"
        Dim bfChinese As BaseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED)
        Dim fontChinese As New Font(bfChinese, 24, Font.BOLD, BaseColor.BLUE)
        Dim content1 As New iTextSharp.text.Paragraph(para1, fontChinese)

        Dim cb As PdfContentByte = writer.DirectContent
        cb.BeginText()
        cb.SetFontAndSize(bfChinese, 12)
        cb.SetTextMatrix(660, 10)
        cb.ShowText("座位表匯出日期：" + DateTime.Now.ToShortDateString())
        cb.SetTextMatrix(500, doc1.PageSize.Height - 55)
        cb.ShowText("開課班級：資工二B")
        cb.SetTextMatrix(500, doc1.PageSize.Height - 75)
        cb.ShowText("授課教師：黃信貿")
        cb.SetTextMatrix(650, doc1.PageSize.Height - 55)
        cb.ShowText("上課時間：一/06-09")
        cb.SetTextMatrix(650, doc1.PageSize.Height - 75)
        cb.ShowText("上課教室：0712")
        cb.EndText()

        doc1.Add(content1)
        doc1.Add(jpgx)
        doc1.Close()
        Process.Start(path)
    End Sub

End Module
