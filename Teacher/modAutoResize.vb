Imports Microsoft.Office.Interop

'===============================
'   Grid應用函式集
'   20150909 - 黃騰嶢
'===============================
Public Module modAutoResize

    '******************************
    '   將傳入的Grid匯出到Excel(含內容、欄位大小、字型、背景色)
    '   20150910 - 黃騰嶢
    '******************************
    Sub exportExcel(ByVal sFileName As String, ByVal sTitle As String, ByVal grdToExport As DataGridView)
        Dim objExcel As Excel.Application
        Dim objBook As Excel.Workbook
        Dim objSheet As Excel.Worksheet
        objExcel = CreateObject("Excel.Application")
        objBook = objExcel.Workbooks.Add(Type.Missing)
        objSheet = objBook.Worksheets(1)
        objExcel.Visible = True
        Try
            Dim nRow As Integer = 5
            Dim nCol As Integer = 1

            '20150914 黃騰嶢 - 更新標題文字大小符合內容大小
            objSheet.Cells(1, 1) = sTitle
            objSheet.Cells(1, 1).Font.Size = grdToExport.DefaultCellStyle.Font.Size + 30
            objSheet.Cells(1, 1).Font.Bold = True
            objSheet.Cells(1, 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            objSheet.Cells(1, 1).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            objSheet.Range(objSheet.Cells(1, 1), objSheet.Cells(1, grdToExport.ColumnCount)).Merge()
            objSheet.Cells(2, 1) = "檔案匯出時間：" & Now
            objSheet.Cells(2, 1).Font.Size = grdToExport.DefaultCellStyle.Font.Size
            objSheet.Range(objSheet.Cells(2, 1), objSheet.Cells(2, grdToExport.ColumnCount)).Merge()

            For nCol = 1 To grdToExport.ColumnCount
                objSheet.Cells(4, nCol) = grdToExport.Columns(nCol - 1).HeaderText
                objSheet.Cells(4, nCol).Font.Size = grdToExport.DefaultCellStyle.Font.Size
                objSheet.Cells(4, nCol).Font.Bold = True
            Next
            nCol = 1

            objSheet.Range(objSheet.Cells(nRow, 1), objSheet.Cells(nRow + grdToExport.RowCount, grdToExport.ColumnCount)).Font.Name _
                = grdToExport.DefaultCellStyle.Font.Name
            objSheet.Range(objSheet.Cells(nRow, 1), objSheet.Cells(nRow + grdToExport.RowCount, grdToExport.ColumnCount)).Font.Size _
                = grdToExport.DefaultCellStyle.Font.Size
            objSheet.Range(objSheet.Cells(nRow, 1), objSheet.Cells(nRow + grdToExport.RowCount, grdToExport.ColumnCount)).NumberFormatLocal _
                = "@"

            For Each row As DataGridViewRow In grdToExport.Rows
                For Each cell As DataGridViewCell In row.Cells
                    Dim xlsCell As Excel.Range = objSheet.Cells(nRow, nCol)
                    With xlsCell
                        .Value = cell.Value.ToString

                        'Excel 列高/像素 = 3/4
                        If cell.Size.Height / 4 * 3 > 255 Then
                            .RowHeight = 255
                        Else
                            .RowHeight = cell.Size.Height / 4 * 3
                        End If
                        'Excel 欄寬/像素 = 9/77
                        If cell.Size.Width / 77 * 9 > 255 Then
                            .ColumnWidth = 255
                        Else
                            .ColumnWidth = cell.Size.Width / 77 * 9
                        End If

                        If Not cell.Style.BackColor.IsEmpty Then
                            .Interior.Color = ColorTranslator.ToOle(cell.Style.BackColor)
                        Else
                            If Not row.DefaultCellStyle.BackColor.IsEmpty Then
                                .Interior.Color = ColorTranslator.ToOle(row.DefaultCellStyle.BackColor)
                            End If
                        End If
                    End With
                    nCol += 1
                Next
                nRow += 1
                nCol = 1
            Next

            'objSheet.Columns.AutoFit()
            objSheet.SaveAs(sFileName)
        Catch ex As Exception
            MsgBox("Excel檔案：" & sFileName & "匯出失敗")
        Finally
            'objBook.Close()
            'System.Runtime.InteropServices.Marshal.ReleaseComObject(objExcel)
        End Try
    End Sub

    '******************************
    '   將傳入的Form掃描所有元件的原始屬性並加入Resize監聽，自動調整元件大小(寬高、位置、字體大小)
    '   請於Form_Load時初始化物件
    '   20150910 - 黃騰嶢
    '******************************
    Public Class Resizer
        Private frmMain As Form
        Private nLastW As Integer
        Private nLastH As Integer
        Private nScreenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Private nScreenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Private sDefaultChangeRatio As Single = 1
        Private bResizeGrid As Boolean = False
        Private nCustomColWidth As Integer = 0
        Private Structure ControlInfo
            Public sName As String
            Public sParentName As String
            Public fLeftOffsetPercent As Double
            Public fTopOffsetPercent As Double
            Public fHeightPercent As Double
            Public fWidthPercent As Double
            Public nOriginalHeight As Integer
            Public nOriginalWidth As Integer
            Public fOriginalFontSize As Single
        End Structure
        Private dictionaryOfControl As Dictionary(Of String, ControlInfo) = New Dictionary(Of String, ControlInfo)

        Public Sub New(ByRef _frmMain As Control, ByVal _bResizeGrid As Boolean, ByVal _nCustomColWidth As Integer)
            frmMain = _frmMain
            bResizeGrid = _bResizeGrid
            nCustomColWidth = _nCustomColWidth

            '設定自動縮放模式為DPI
            frmMain.AutoScaleMode = AutoScaleMode.Dpi
            '新增Form的大小變更事件監聽
            AddHandler (frmMain.Resize), AddressOf MainControl_Resize
            '螢幕解析度過小處理，縮放至最大邊比例的60%
            If frmMain.Width > nScreenWidth Or frmMain.Height > nScreenHeight Then
                Dim WHratio As Single = frmMain.Width / frmMain.Height
                If nScreenWidth > nScreenHeight Then
                    sDefaultChangeRatio = nScreenWidth * 0.6 / frmMain.Width
                    frmMain.Width = nScreenWidth * 0.6
                    frmMain.Height = frmMain.Width / WHratio
                Else
                    sDefaultChangeRatio = nScreenHeight * 0.6 / frmMain.Height
                    frmMain.Height = nScreenHeight * 0.6
                    frmMain.Width = frmMain.Height * WHratio
                End If
                frmMain.MinimumSize = New Size(frmMain.Width, frmMain.Height)
            End If
            FindAllControls(frmMain)
        End Sub

        '*******************************
        '   尋找所有子元件並記錄原始資訊
        '   20150911 - 黃騰嶢
        '*******************************
        Private Sub FindAllControls(thisCtrl As Control)
            If IsNothing(thisCtrl.Parent) Then
                nLastW = thisCtrl.Width
                nLastH = thisCtrl.Height
                thisCtrl.Tag = Math.Round(thisCtrl.Width / thisCtrl.Height, 2)
            End If
            For Each ctlChild As Control In thisCtrl.Controls
                Try
                    If Not IsNothing(ctlChild.Parent) Then
                        If ctlChild.Name = "" Then   '-- 忽略沒有名字的元件
                            Continue For
                        End If
                        Dim parentHeight = ctlChild.Parent.Height
                        Dim parentWidth = ctlChild.Parent.Width

                        Dim ctlChildInfo As New ControlInfo
                        With ctlChildInfo
                            .sName = ctlChild.Name
                            .sParentName = ctlChild.Parent.Name
                            .fTopOffsetPercent = Convert.ToDouble(ctlChild.Top) / Convert.ToDouble(parentHeight) * sDefaultChangeRatio
                            .fLeftOffsetPercent = Convert.ToDouble(ctlChild.Left) / Convert.ToDouble(parentWidth) * sDefaultChangeRatio
                            .fHeightPercent = Convert.ToDouble(ctlChild.Height) / Convert.ToDouble(parentHeight) * sDefaultChangeRatio
                            .fWidthPercent = Convert.ToDouble(ctlChild.Width) / Convert.ToDouble(parentWidth) * sDefaultChangeRatio
                            .fOriginalFontSize = ctlChild.Font.SizeInPoints * sDefaultChangeRatio
                            .nOriginalHeight = ctlChild.Height * sDefaultChangeRatio
                            .nOriginalWidth = ctlChild.Width * sDefaultChangeRatio
                            dictionaryOfControl.Add(.sName, ctlChildInfo)
                        End With
                    End If
                Catch ex As Exception
                    Debug.WriteLine(ex.Message)
                End Try
                '-- 遞迴做子元件搜尋
                If ctlChild.Controls.Count > 0 Then
                    '-- 忽略Grid的子元件(交給setGridColWidth處理)
                    If TypeName(ctlChild).Contains("Grid") Then
                        Continue For
                    End If
                    FindAllControls(ctlChild)
                End If
            Next
        End Sub

        '*******************************
        '   於視窗大小變更時呼叫，自動調整所有元件
        '   20150911 - 黃騰嶢
        '*******************************
        Private Sub ResizeAllControls(thisCtrl As Control)
            Dim fFontRatioW As Single
            Dim fFontRatioH As Single
            Dim fFontRatio As Single
            Dim fontOfCtrl As Font

            For Each ctlChild As Control In thisCtrl.Controls
                Try
                    If Not IsNothing(ctlChild.Parent) And Not ctlChild.Name.StartsWith("tab") Then
                        Dim nParentHeight = ctlChild.Parent.Height
                        Dim nParentWidth = ctlChild.Parent.Width

                        Dim ctlChildInfo As New ControlInfo

                        '-- 取得該元件原始資訊
                        If dictionaryOfControl.TryGetValue(ctlChild.Name, ctlChildInfo) Then
                            '-- Size
                            ctlChild.Width = Int(nParentWidth * ctlChildInfo.fWidthPercent)
                            ctlChild.Height = Int(nParentHeight * ctlChildInfo.fHeightPercent)

                            '-- Position
                            ctlChild.Top = Int(nParentHeight * ctlChildInfo.fTopOffsetPercent)
                            ctlChild.Left = Int(nParentWidth * ctlChildInfo.fLeftOffsetPercent)

                            '-- Font
                            fontOfCtrl = ctlChild.Font
                            fFontRatioW = ctlChild.Width / ctlChildInfo.nOriginalWidth
                            fFontRatioH = ctlChild.Height / ctlChildInfo.nOriginalHeight
                            fFontRatio = (fFontRatioW + fFontRatioH) / 2 '-- 平均寬度高度變化量
                            ctlChild.Font = New Font(fontOfCtrl.FontFamily, ctlChildInfo.fOriginalFontSize * fFontRatio, fontOfCtrl.Style)
                        End If
                    End If
                Catch ex As Exception
                    Debug.WriteLine(ex.Message)
                End Try
                '-- 遞迴做子元件調整
                If ctlChild.Controls.Count > 0 Then
                    If TypeName(ctlChild).Contains("Grid") Then
                        If bResizeGrid Then
                            setGridColWidth(ctlChild)
                        End If
                        Continue For
                    End If
                    ResizeAllControls(ctlChild)
                End If
            Next
        End Sub

        '*******************************
        '   監聽視窗大小變更
        '   20150914 - 黃騰嶢
        '*******************************
        Private Sub MainControl_Resize(sender As Object, e As EventArgs)
            Me.ResizeAllControls(frmMain)
        End Sub

        '*******************************
        '   設定grid欄位寬度(Width,Grid)
        '       -Width=0時，自動隨視窗及欄位大小調整
        '   20150911 - 黃騰嶢
        '*******************************
        Public Sub setGridColWidth(ByRef grdToEdit As DataGridView)
            Select Case nCustomColWidth
                Case 0
                    grdToEdit.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                    grdToEdit.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                    grdToEdit.AutoResizeColumns()
                    grdToEdit.AutoResizeRows()

                    Dim arrColWidth(grdToEdit.Columns.Count - 1) As Integer
                    Dim nTotalColWidth As Integer = 0
                    Dim nGridWidth As Integer = grdToEdit.Width

                    For nIndex As Integer = 0 To grdToEdit.Columns.Count - 1
                        arrColWidth(nIndex) = grdToEdit.Columns.Item(nIndex).Width
                        nTotalColWidth += arrColWidth(nIndex)
                    Next

                    If nTotalColWidth < grdToEdit.Width - 10 Then
                        grdToEdit.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                        For nIndex As Integer = 0 To grdToEdit.Columns.Count - 1
                            grdToEdit.Columns.Item(nIndex).Width = Math.Floor((arrColWidth(nIndex) / nTotalColWidth) * nGridWidth)
                        Next
                    End If
                Case Else
                    For nIndex As Integer = 0 To grdToEdit.Columns.Count - 1
                        grdToEdit.Columns.Item(nIndex).Width = nCustomColWidth
                    Next
            End Select
        End Sub
    End Class

End Module
