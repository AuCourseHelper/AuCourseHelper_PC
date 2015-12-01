Imports System.Net.Sockets
Imports System.Xml

Module modDefine
    Public RETRYTIMES As Integer = 0
    Public serverIp As String = ""
    Public serverPort As Integer = 0

    Public objFrmTeacher As frmTeacher
    Public clientSocket As Socket
    Public resultDbCmd As String = ""
    Public isLogin As Boolean = False
    Public isDeserializeFail = False

    Public myProfile As New TeacherProfile
    Public myCourses As New DataTable
    Public nowCourse As DataRow
    Public nowTerm As String
    Public nowTermStart As Date
    Public nowWeek As Integer

    Public Function readSetting() As Boolean
        Dim xdoc As New XmlDocument
        Dim xRoot As XmlNode

        Try
            xdoc.Load("setting.xml")
            xRoot = CType(xdoc.DocumentElement, XmlNode)
            serverIp = xRoot.SelectNodes("server")(0).Attributes("ip").Value
            serverPort = CInt(xRoot.SelectNodes("server")(0).Attributes("port").Value)

            RETRYTIMES = CInt(xRoot.SelectNodes("const")(0).Attributes("retryTimes").Value)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
End Module
