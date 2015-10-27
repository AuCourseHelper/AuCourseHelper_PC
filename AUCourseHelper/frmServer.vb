Imports System.Net.Sockets
Imports Microsoft.Win32
Imports System.Threading
Imports System.Runtime.InteropServices
Imports System.Management

Public Class frmServer
    Public version = "1.0.151027"
    Dim p As Process

    Private Sub frmServer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("是否確定要關閉本系統", "關閉程式", MessageBoxButtons.YesNo) = DialogResult.No Then
            e.Cancel = True
            Exit Sub
        End If
        closeDb()
        log("====關閉系統====" & vbCrLf, LogType_SYSTEM)

        'Dim strKey As String
        'strKey = "HKCU\Software\Microsoft\Windows\CurrentVersion\Internet Settings"
        'With CreateObject("WScript.Shell")
        '    .RegWrite(strKey & "\ProxyEnable", 0, "REG_DWORD")
        'End With
        'p.Kill()
    End Sub

    Private Sub frmServer_Load(sender As Object, e As EventArgs) Handles Me.Load
        objFrmServer = Me
        log("====執行系統====", LogType_SYSTEM)
        log("==伺服端", LogType_SYSTEM)
        log("==版本號:" & version, LogType_SYSTEM)
        If GetRealIPaddress() <> GetIPaddress() Then
            MsgBox("您可能位於路由器底下" & vbCrLf _
                   & "請將路由器Port:5566" & vbCrLf _
                   & "對應到目前IP:" & GetIPaddress() & vbCrLf _
                   & "否則將造成教師與學生無法連線!!!" _
                   , MsgBoxStyle.OkOnly, "實際對外IP位址與目前網卡IP位址不相同！")
            tsmIp.Text = "區網IP: " & GetIPaddress() & " - 對外IP: " & GetRealIPaddress()
        Else
            tsmIp.Text = "IP: " & GetRealIPaddress()
        End If
        log("==" & tsmIp.Text, LogType_SYSTEM)
        tslSysTime.Text = Now
        lvTeacher.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        lvStudent.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

        openDb()
        mnuStart.PerformClick()

        'Me.MaximizeBox = False
        'Me.MinimizeBox = False
        'Me.TopMost = True
        'Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'Me.WindowState = FormWindowState.Maximized

        'p = System.Diagnostics.Process.Start(Application.StartupPath & "\KCProxy.exe")
        'Dim strKey As String
        'strKey = "HKCU\Software\Microsoft\Windows\CurrentVersion\Internet Settings"
        'With CreateObject("WScript.Shell")
        '    .RegWrite(strKey & "\ProxyEnable", 1, "REG_DWORD")
        '    .RegWrite(strKey & "\ProxyServer", "127.0.0.1:8889", "REG_SZ")
        'End With

        'auSysLogin("AM001871", "a0tim82326")
        'auSysGetAllGrade()
        'auSysGetTimetable("103", "2")
    End Sub

    Delegate Sub _AddClient(ByVal client As Socket, ByVal userType As String, ByVal userName As String, ByVal time As String)
    Public Sub AddClient(ByVal client As Socket, ByVal userType As String, ByVal userName As String, ByVal time As String)
        If InvokeRequired Then
            Invoke(New _AddClient(AddressOf AddClient), client, userType, userName, time)
            Exit Sub
        End If

        Dim item As New ListViewItem(client.LocalEndPoint.ToString)
        item.SubItems.Add(userName)
        item.SubItems.Add(time)
        item.Tag = client

        If userType = "T" Then
            lvTeacher.Items.Add(item)
        Else
            lvStudent.Items.Add(item)
        End If
        tslOnlineCount.Text = "伺服器：開啟  人數：" & clients.Count & "人"
    End Sub

    Private Sub tmrSysTime_Tick(sender As Object, e As EventArgs) Handles tmrSysTime.Tick
        tslSysTime.Text = Now
    End Sub

    Private Sub tsmExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        Application.Exit()
    End Sub

    Private Sub mnuStart_Click(sender As Object, e As EventArgs) Handles mnuStart.Click
        If startServer() Then
            tlpMain.Enabled = True
            mnuStart.Enabled = False
            mnuStop.Enabled = True
            tslOnlineCount.Text = "伺服器：開啟  人數：0人"
        End If
    End Sub

    Private Sub mnuStop_Click(sender As Object, e As EventArgs) Handles mnuStop.Click
        If clients.Count > 0 Then
            Select Case MsgBox("目前仍有使用者連接中，是否確定關閉？", MsgBoxStyle.YesNo, "伺服器關閉確認")
                Case MsgBoxResult.No
                    Exit Sub
            End Select
        End If
        stopServer()
        tlpMain.Enabled = False
        mnuStart.Enabled = True
        mnuStop.Enabled = False
        tslOnlineCount.Text = "伺服器：關閉  人數：0人"
    End Sub

    Private Sub tsmReport_DropDownOpened(sender As Object, e As EventArgs) Handles tsmReport.DropDownOpened
        Dim logs() = getHistoryLogList()
        mnuViewHistory.DropDownItems.Clear()
        Dim logCount As Integer = 0
        For Each logFilePath In logs
            Dim logFileName = logFilePath.Substring(logFilePath.LastIndexOf("\") + 1)
            mnuViewHistory.DropDownItems.Add(logFileName)
            mnuViewHistory.DropDownItems.Item(logCount).Tag = logFilePath
            AddHandler mnuViewHistory.DropDownItems.Item(logCount).Click, AddressOf historyLog_View
            logCount += 1
        Next
    End Sub

    Public Sub historyLog_View(sender As Object, e As EventArgs)
        Dim historyLog As ToolStripDropDownItem = sender
        Dim filePath As String = historyLog.Tag
        System.Diagnostics.Process.Start(filePath)
    End Sub

    Private Sub mnuViewLog_Click(sender As Object, e As EventArgs) Handles mnuViewLog.Click
        Dim frmLog As New Form
        Dim log As New RichTextBox()
        log.Text = logData
        log.Enabled = False
        log.ScrollBars = RichTextBoxScrollBars.Both
        log.Dock = DockStyle.Fill
        frmLog.Text = Me.Text & " | 程式執行紀錄"
        frmLog.Size = New Size(400, 500)
        frmLog.Controls.Add(log)
        frmLog.ShowDialog()
    End Sub
End Class