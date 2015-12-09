Imports System.Drawing

Public Class ctrlCodeHelper
    Dim dtResult As DataTable
    Dim ctrlSeat As ctrlSeat
    Dim smCodeType As String
    Dim lock As New Object

    Public Sub setInit(ctrlSeat As ctrlSeat, Optional nWidth As Integer = 200)
        Me.ctrlSeat = ctrlSeat

        Me.Left = ctrlSeat.Left + 30
        Me.Top = ctrlSeat.Top + ctrlSeat.Height
        Me.Width = nWidth
        Me.Height = ctrlSeat.Height * 6
        lstMain.Font = ctrlSeat.lblName.Font

        updateLst()
        If lstMain.Items.Count > 0 Then
            Me.Parent = ctrlSeat.Parent
            Me.BringToFront()
            Me.Show()
        End If
    End Sub

    Private Sub lstMain_DoubleClick(sender As Object, e As EventArgs) Handles lstMain.DoubleClick
        fillText()
    End Sub

    Private Sub lstMain_KeyDown(sender As Object, e As KeyEventArgs) Handles lstMain.KeyDown
        If e.KeyCode = Keys.Enter Then
            fillText()
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Hide()
        End If
    End Sub

    Private Sub mnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        Me.Hide()
    End Sub

    Private Sub updateLst()
        lstMain.Items.Clear()
        Dim drResult As DataRow() = doCourseStudents.Select("座位=''")
        For Each row As DataRow In drResult
            lstMain.Items.Add(row.Item("學號") & " - " & row.Item("姓名"))
        Next
    End Sub

    Private Sub fillText()
        Dim sId = lstMain.SelectedItem.ToString.Split(" - ")(0)
        Dim sName = lstMain.SelectedItem.ToString.Split(" - ")(1)
        ctrlSeat.updateAttend(sId, sName, "")
    End Sub
End Class
