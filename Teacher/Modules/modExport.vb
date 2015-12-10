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
        Dim doc1 As New Document(PageSize.A4.Rotate()) '宣告 Document 文件
        Dim path As String = "D:\000.pdf" '預設檔案存放的路徑
        Dim filename As String = "test" '檔案名稱
        Dim para1 As String = "AAAAAAAAAA" + vbCrLf + "BBBBBBBBBBBB" + vbCrLf + "CCCCCCCCCC" '文字段落1。要跳行要用 vbCrLf 。
        Dim para2 As String = "我是中文字～大家好....." + vbCrLf + "我是中文字～大家好....." '文字段落2
        PdfWriter.GetInstance(doc1, New FileStream(path, FileMode.Create))
        doc1.Open() '開啟文件
        Dim jpgx As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(img, BaseColor.WHITE)
        jpgx.ScalePercent((doc1.PageSize.Height - 100) / jpgx.Height * 100)
        Dim fontPath As String = Environment.GetFolderPath(Environment.SpecialFolder.System) & "\..\Fonts\kaiu.ttf"
        Dim bfChinese As BaseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED)
        Dim fontChinese As New Font(bfChinese, 16.0F, Font.NORMAL)
        Dim content As iTextSharp.text.Paragraph = New iTextSharp.text.Paragraph("" + filename + vbCrLf + para1 + vbCr + para2 + vbCrLf, fontChinese) '將文字段落串起來，並設定文字樣式

        doc1.Add(content) '插入文字段落內容
        doc1.Add(jpgx) '插入 JPG/GIF 圖片
        doc1.Close() ' 關閉輸出文件
        Process.Start(path)
    End Sub

End Module
