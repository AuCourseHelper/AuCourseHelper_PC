Imports System.IO

Module LogFunc
    Public Const LogType_NORMAL = 1
    Public Const LogType_ERROR = 2
    Public Const LogType_SYSTEM = 3

    Public logFilePath As String = Application.StartupPath & "\logs\log-server-" & Format(Now, "yyyyMMdd") & ".txt"
    Public logData As String = ""
    Private historyLogList() As String
    Private logLock As New Object

    Public Sub log(ByVal logText As String, ByVal logType As Integer)
        SyncLock logLock
            objFrmServer.UpdateLog(logText, logType)
        End SyncLock
    End Sub

    Public Sub saveLog(ByVal log As String)
        If Not Directory.Exists(Application.StartupPath & "\logs") Then
            logData = ""
            Directory.CreateDirectory(Application.StartupPath & "\logs")
        End If
        File.AppendAllText(logFilePath, log)
    End Sub

    Public Function getHistoryLogList() As String()
        historyLogList = Directory.GetFiles(Application.StartupPath & "\logs", "log*.txt")
        Return historyLogList
    End Function
End Module
