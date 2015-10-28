Imports System.IO

Module LogFunc
    Public Const LogType_NORMAL = 1
    Public Const LogType_ERROR = 2
    Public Const LogType_SYSTEM = 3

    Private logFilePath As String = Application.StartupPath & "\logs\log-" & Format(Now, "yyyyMMdd") & ".txt"
    Public logData As String = ""
    Private historyLogList() As String
    Private logLock As New Object

    Public Sub log(ByVal log As String, ByVal logType As Integer)
        SyncLock logLock
            Select Case logType
                Case LogType_NORMAL
                    objFrmServer.tslStatus.BackColor = System.Drawing.SystemColors.GrayText
                    objFrmServer.tslStatus.Text = log
                    log = Format(Now, "yyyyMMdd-HHmmss:") & vbTab & "O  " & log & vbCrLf
                Case LogType_ERROR
                    objFrmServer.tslStatus.BackColor = Color.Red
                    objFrmServer.tslStatus.Text = log
                    log = Format(Now, "yyyyMMdd-HHmmss:") & vbTab & "X  " & log & vbCrLf
                Case LogType_SYSTEM
                    objFrmServer.tslStatus.BackColor = System.Drawing.SystemColors.GrayText
                    objFrmServer.tslStatus.Text = log
                    log = Format(Now, "yyyyMMdd-HHmmss:") & vbTab & log & vbCrLf
            End Select
            logData &= log
            saveLog(log)
        End SyncLock
    End Sub

    Private Sub saveLog(ByVal log As String)
        If Not Directory.Exists(Application.StartupPath & "\logs") Then
            Directory.CreateDirectory(Application.StartupPath & "\logs")
        End If
        File.AppendAllText(logFilePath, log)
    End Sub

    Public Function getHistoryLogList() As String()
        historyLogList = Directory.GetFiles(Application.StartupPath & "\logs", "log*.txt")
        Return historyLogList
    End Function
End Module
