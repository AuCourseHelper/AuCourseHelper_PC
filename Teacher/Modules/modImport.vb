Imports Microsoft.Office.Interop

Module modImport

    Public Function readXlsAsCourseStudent(sPath As String, nNum As Integer, nId As Integer, nName As Integer) As DataTable
        Dim dtResult As New DataTable()
        dtResult.Columns.Add("序號")
        dtResult.Columns.Add("學號")
        dtResult.Columns.Add("姓名")

        Try
            Dim objExcel As Excel.Application
            Dim objBook As Excel.Workbook
            Dim objSheet As Excel.Worksheet
            objExcel = CreateObject("Excel.Application")
            objBook = objExcel.Workbooks.Open(sPath)
            objSheet = objBook.Worksheets(1)
            objExcel.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return dtResult
    End Function
End Module
