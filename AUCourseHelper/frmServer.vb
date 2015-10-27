Imports System.Net.Sockets
Imports Microsoft.Win32
Imports System.Threading
Imports System.Runtime.InteropServices
Imports System.Management

Public Class frmServer
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

    Private Sub frmServer_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.RWin Then
            e.SuppressKeyPress = False
        End If
        If e.Alt = True Then
            If e.KeyCode = Keys.Tab Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub frmServer_Load(sender As Object, e As EventArgs) Handles Me.Load
        log("====執行系統====", LogType_SYSTEM)
        tslSysTime.Text = Now
        lvTeacher.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        lvStudent.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
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
        openDb()
        MsgBox(auSysLogin("AM001871", "a0tim82326"))
        'auSysGetAllGrade()
        auSysGetTimetable("103", "2")
    End Sub

    Delegate Sub _AddClient(ByVal client As Socket)
    Private Sub AddClient(ByVal client As Socket)
        If InvokeRequired Then
            Invoke(New _AddClient(AddressOf AddClient), client)
            Exit Sub
        End If
        Dim item As New ListViewItem(client.LocalEndPoint.ToString)
        item.SubItems.Add("王小明")
        item.SubItems.Add("2015/10/25 17:52:00")
        item.Tag = client
        lvTeacher.Items.Add(item)
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
        If isServerOn Then

        End If
        stopServer()
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

End Class