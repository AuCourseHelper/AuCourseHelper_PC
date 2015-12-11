Imports System.Net
Imports System.Text
Imports System.IO

Module SchoolSystemConnection
    Const URL = "https://aus.au.edu.tw/au/perchk.jsp"
    Const HomeURL = "https://aus.au.edu.tw"
    Dim CookieJar As New CookieContainer
    Dim PostData As String = ""

    Public Function auSysLogin(ByVal uid As String, ByVal pwd As String) As Boolean

        Dim parameters = "uid=" & uid & "&pwd=" & pwd & "&sys_name=web"
        sendHttpRequest("https://aus.au.edu.tw/au/perchk.jsp", parameters, "POST")

        Return True
    End Function

    Public Function auSysGetAllGrade() As Boolean

        Dim web As New Form
        Dim webView As New WebBrowser
        webView.DocumentText = sendHttpRequest("https://aus.au.edu.tw/au/ag_pro/ag102.jsp", "fncid=AG102", "POST")
        webView.Dock = DockStyle.Fill
        web.Size = New Size(800, 600)
        web.Controls.Add(webView)
        web.Show()

        Return True
    End Function

    Public Function auSysGetTimetable(ByVal termY As String, ByVal termC As String) As Boolean

        Dim web As New Form
        Dim webView As New WebBrowser
        webView.DocumentText = sendHttpRequest("https://aus.au.edu.tw/au/ag_pro/ag222.jsp", "spath=ag_pro/ag222.jsp?&arg01=" & termY & "&arg02=" & termC, "POST")
        webView.Dock = DockStyle.Fill
        web.Size = New Size(800, 600)
        web.Controls.Add(webView)
        web.Show()

        Return True
    End Function

    Public Function auSysGetCourseStudents(ByVal termY As String, ByVal termC As String) As Boolean
        Dim num() = {"1297", "1299", "1302", "1295", "1301", "1296", "1312", "1306", "1308", "1311", "1304", "1310", "1305", "1314", "1316", "1315", "1317", "1313", "1235", "1326", "1322", "1323", "1324", "1319", "1321", "1320", "1318", "1330", "1327", "1328", "1331", "1329", "1335", "1336", "1338", "1337", "1334", "1332", "1333", "1339", "1342", "1340"}

        'Dim wc As New WebClient()
        'wc.Headers.Add(HttpRequestHeader.Cookie, "JSESSIONID=AACInU6qVlGym0LCd1tuQw; _ga=GA1.3.1063912275.1445912638; _gat=1; _gali=chk; aus_cookie_persis-47873-aus-group-http=BPMIBAKMFAAA; __utmc=246785684; __utma=246785684.1063912275.1445912638.1446104066.1446104066.1; __utmb=246785684.2.10.1446104066; __utmz=246785684.1446104066.1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none)")
        'wc.DownloadFile("https://aus.au.edu.tw/au/ag_pro/ag_pdf/10411320.pdf", "D:\10411320.pdf")
        'wc.DownloadFile("https://aus.au.edu.tw/au/ag_pro/ag_xls/10411320.xls", "D:\10411343.xls")
        
        For Each n In num
            Dim wc As New WebClient()
            'wc.Headers.Add(HttpRequestHeader.Cookie, "JSESSIONID=AACInU6qVlGym0LCd1tuQw; _ga=GA1.3.1063912275.1445912638; _gat=1; _gali=chk; aus_cookie_persis-47873-aus-group-http=BPMIBAKMFAAA; __utmc=246785684; __utma=246785684.1063912275.1445912638.1446104066.1446104066.1; __utmb=246785684.2.10.1446104066; __utmz=246785684.1446104066.1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none)")
            'wc.DownloadFile("https://aus.au.edu.tw/au/ag_pro/ag_pdf/1041" & n & ".pdf", "D:\點名單\1041" & n & ".pdf")
            wc.DownloadFile("https://aus.au.edu.tw/au/ag_pro/ag_xls/1041" & n & ".xls", "D:\1041" & n & ".xls")
        Next

        Return True
    End Function

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
End Module
