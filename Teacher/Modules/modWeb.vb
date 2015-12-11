Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Module modWeb
    Const URL = "https://aus.au.edu.tw/au/perchk.jsp"
    Const HomeURL = "https://aus.au.edu.tw"
    Private CookieJar As New CookieContainer
    Private sUid As String
    Private sId As String

    ' 回傳String
    Private Function sendHttpRequest(ByVal sUrl As String, ByVal sParameters As String, ByVal sMethod As String) As String
        Dim reader As StreamReader
        Dim Request As HttpWebRequest = HttpWebRequest.Create(sUrl)
        Dim result As String

        Try
            Request.UserAgent = "Mozilla/5.0"
            Request.CookieContainer = CookieJar
            Request.AllowAutoRedirect = False
            Request.ContentType = "application/x-www-form-urlencoded"
            Request.Method = "POST"
            Request.ContentLength = sParameters.Length

            Dim requestStream As Stream = Request.GetRequestStream()
            Dim postBytes As Byte() = Encoding.ASCII.GetBytes(sParameters)

            requestStream.Write(postBytes, 0, postBytes.Length)
            requestStream.Close()

            Dim Response As HttpWebResponse = Request.GetResponse()

            For Each tempCookie As Cookie In Response.Cookies
                CookieJar.Add(tempCookie)
            Next

            reader = New StreamReader(Response.GetResponseStream(), Encoding.GetEncoding("big5"))
            result = reader.ReadToEnd() ' 網頁內容
            Response.Close()
        Catch ex As Exception
            Return ""
        End Try
        Return result
    End Function

    ' 回傳Byte()
    Private Function sendHttpRequest2(ByVal sUrl As String, ByVal sParameters As String, ByVal sMethod As String) As Byte()
        Dim Request As HttpWebRequest = HttpWebRequest.Create(sUrl)

        Try
            Request.UserAgent = "Mozilla/5.0"
            Request.CookieContainer = CookieJar
            Request.AllowAutoRedirect = False
            Request.ContentType = "application/x-www-form-urlencoded"
            Request.Method = "POST"
            Request.ContentLength = sParameters.Length

            Dim requestStream As Stream = Request.GetRequestStream()
            Dim postBytes As Byte() = Encoding.ASCII.GetBytes(sParameters)

            requestStream.Write(postBytes, 0, postBytes.Length)
            requestStream.Close()

            Dim Response As HttpWebResponse = Request.GetResponse()

            For Each tempCookie As Cookie In Response.Cookies
                CookieJar.Add(tempCookie)
            Next

            Dim ms As New MemoryStream()
            Response.GetResponseStream().CopyTo(ms)
            Dim data() As Byte = ms.ToArray()

            Response.Close()
            Return data
        Catch ex As Exception
            Return Nothing
        End Try
        Return Nothing
    End Function

    Public Function auSysLogin(uid As String, pwd As String) As Boolean
        Try
            Dim parameters = "uid=" & uid & "&pwd=" & pwd & "&sys_name=web"
            Dim sResult = sendHttpRequest("https://aus.au.edu.tw/au/perchk.jsp", parameters, "POST")
            If sResult.Contains("alert(") Then
                Return False
            End If
            sUid = uid
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function auSysGetCourseStudents(termY As String, termC As String, sCourseId As String, sPath As String) As DataTable
        Dim dtResult As New DataTable
        dtResult.Columns.Add("序號")
        dtResult.Columns.Add("學號")
        dtResult.Columns.Add("姓名")
        Try
            ' 取得身分證號
            Dim sCoures = sendHttpRequest("https://aus.au.edu.tw/au/ag_pro/ag062_1.jsp", "arg01=" & termY & "&arg02=" & termC & "&arg03=" & sUid & "&arg04=&arg05=&arg06=&fncid=AG062", "POST")
            Dim sId = sCoures.Substring(sCoures.IndexOf("tidno value=""") + 13, 10)

            ' 下載XLS檔案
            'Dim data() = sendHttpRequest2("https://aus.au.edu.tw/au/ag_pro/ag062_3.jsp", "selcode=1320&year=" & termY & "&sms=" & termC & "&tidno=" & sId, "POST")
            'File.WriteAllBytes(sPath, data)

            Dim sSource = sendHttpRequest("https://aus.au.edu.tw/au/ag_pro/ag062_3.jsp", "selcode=" & sCourseId & "&year=" & termY & "&sms=" & termC & "&tidno=" & sId, "POST")
            sSource = sSource.Replace("　", "O")
            sSource = sSource.Replace("", "O")
            sSource = Regex.Replace(sSource, "[\W_]+", " ")
            Dim sClear = ""
            For Each sTemp As String In sSource.Split(" ")
                If sTemp.Length > 1 Then
                    If sTemp = "4327" Then
                        sClear &= ";"
                    End If
                    sClear &= sTemp & " "
                End If
            Next
            sClear = sClear.Substring(1)

            Dim nCount As Integer = 1

            For Each sStu As String In sClear.Split(";")
                Dim sArr(2) As String
                sArr(0) = Format(nCount, "00")
                sArr(1) = sStu.Split(" ")(3)
                sArr(2) = sStu.Split(" ")(4)
                dtResult.Rows.Add(sArr)
                nCount += 1
            Next
        Catch ex As Exception
            MsgBox("從校務資訊系統匯入名單失敗！", MsgBoxStyle.Critical)
            Return dtResult
        End Try
        Return dtResult
    End Function

End Module
