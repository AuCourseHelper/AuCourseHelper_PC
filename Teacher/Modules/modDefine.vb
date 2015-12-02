Imports System.Net.Sockets
Imports System.Xml

Module modDefine
    Public Const VERSION = "1.0.151201"
    Public MYIP = GetIPaddress()
    Public MYREALIP = GetRealIPaddress()

    ' FROM SETTING FILE============
    Public RETRYTIMES As Integer = 0
    Public SERVERIP As String = ""
    Public SERVERPORT As Integer = 0
    ' ============FROM SETTING FILE

    Public CL_BK_RED As Color = Color.FromArgb(255, 192, 192)
    Public CL_BK_GREEN As Color = Color.FromArgb(192, 255, 192)
    Public CL_BK_BLUE As Color = Color.FromArgb(192, 192, 255)
    Public CL_BK_GRAY As Color = Color.LightGray

    Public objFrmTeacher As frmTeacher
    Public isLogin As Boolean = False

    Public myProfile As New TeacherProfile
    Public myCourses As DataTable = Nothing
    Public nowTerm As String
    Public nowTermStart As Date
    Public nowWeek As Integer
    Public nowWeekDetail As String

    Public doCourse As DataRow = Nothing
    Public doCourseStudents As DataTable = Nothing

    Public Structure TeacherProfile
        Property Id As String
        Property Num As String
        Property Name As String
        Property Pwd As String
        Property LastLogin As String
        Property LastIp As String
        Property WebSite As String
        Property OfficeTime As String
    End Structure

    Public Structure CourseAttend
        Property Id As String
        Property CourseId As String
        Property Dates As String ' 點名日期 格式: 2015/12/01
        Property Off As String ' 請假 格式: AM000000-病,AM000001-事...
        Property Lat As String ' 遲到 格式: AM000000,AM000001...
        Property Abs As String ' 曠課 格式: AM000000,AM000001...
    End Structure

    Public Function readSetting() As Boolean
        Dim xdoc As New XmlDocument
        Dim xRoot As XmlNode

        Try
            xdoc.Load("setting.xml")
            xRoot = CType(xdoc.DocumentElement, XmlNode)
            SERVERIP = xRoot.SelectNodes("server")(0).Attributes("ip").Value
            SERVERPORT = CInt(xRoot.SelectNodes("server")(0).Attributes("port").Value)

            RETRYTIMES = CInt(xRoot.SelectNodes("const")(0).Attributes("retryTimes").Value)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
End Module
