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
