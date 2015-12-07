Public Class ctrlSeat
    Private now As Integer = 0 ' 綠藍紅灰灰灰
    Private tip As New ToolTip()

    Public Sub init(sSeat As String, Optional sId As String = "", Optional sName As String = "")
        Me.Tag = sSeat
        Me.Name = sSeat
        Me.Dock = DockStyle.Fill
        tip.IsBalloon = True

        btnSeat.Text = sSeat
        lblId.Text = Trim(sId)
        lblName.Text = Trim(sName)
        If Trim(sId) = "" And Trim(sName) = "" Then
            Me.Enabled = False
            Me.BackColor = Color.DimGray
        End If
    End Sub

    Public Sub updateAttend(sId As String, sName As String, sAttend As String)
        lblId.Text = Trim(sId)
        lblName.Text = Trim(sName)
        lblName.Tag = sAttend
        Me.BackColor = Color.White
        Select Case sAttend
            Case "出席"
                now = 1
                Me.BackColor = CL_BK_GREEN
            Case "遲到"
                now = 2
                Me.BackColor = CL_BK_BLUE
            Case "缺席"
                now = 3
                Me.BackColor = CL_BK_RED
            Case "病假"
                now = 4
                Me.BackColor = CL_BK_GRAY
            Case "事假"
                now = 5
                Me.BackColor = CL_BK_GRAY
            Case "公假"
                now = 6
                Me.BackColor = CL_BK_GRAY
            Case Else
                now = 0
        End Select
        Me.Enabled = True
    End Sub

    Private Sub ctrlSeat_MouseHover(sender As Object, e As EventArgs) Handles btnSeat.MouseHover, lblId.MouseHover, lblName.MouseHover
        tip.Hide(Me)
        Select Case now
            Case 4
                tip.Show("病假", Me, New Point(0, -30), 1500)
            Case 5
                tip.Show("事假", Me, New Point(0, -30), 1500)
            Case 6
                tip.Show("公假", Me, New Point(0, -30), 1500)
        End Select
    End Sub

    Private Sub ctrlSeat_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        If Me.Width <= 100 Then
            btnSeat.Font = New Font(btnSeat.Font.FontFamily.Name, 11, FontStyle.Bold)
            lblId.Font = New Font(lblId.Font.FontFamily.Name, 9)
            lblName.Font = New Font(lblName.Font.FontFamily.Name, 12)
        Else
            btnSeat.Font = New Font(btnSeat.Font.FontFamily.Name, 18, FontStyle.Bold)
            lblId.Font = New Font(lblId.Font.FontFamily.Name, 14)
            lblName.Font = New Font(lblName.Font.FontFamily.Name, 16)
        End If
    End Sub

    Private Sub btnSeat_Click(sender As Object, e As EventArgs) Handles btnSeat.Click
        If now = 6 Then
            now = 1
        Else
            now += 1
        End If

        tip.Hide(Me)
        Select Case now
            Case 1
                doCourseDtAttend.Select(String.Format("學號='{0}'", lblId.Text))(0).Item("出席狀況") = "出席"
                Me.BackColor = CL_BK_GREEN
            Case 2
                doCourseDtAttend.Select(String.Format("學號='{0}'", lblId.Text))(0).Item("出席狀況") = "遲到"
                Me.BackColor = CL_BK_BLUE
                tip.Show("遲到", Me, New Point(0, -30), 1500)
                'doCourseAttend.Lat
            Case 3
                doCourseDtAttend.Select(String.Format("學號='{0}'", lblId.Text))(0).Item("出席狀況") = "缺席"
                Me.BackColor = CL_BK_RED
                tip.Show("缺席", Me, New Point(0, -30), 1500)
                'doCourseAttend.Abs
            Case 4
                doCourseDtAttend.Select(String.Format("學號='{0}'", lblId.Text))(0).Item("出席狀況") = "病假"
                Me.BackColor = CL_BK_GRAY
                tip.Show("病假", Me, New Point(0, -30), 1500)
                'doCourseAttend.Off
            Case 5
                doCourseDtAttend.Select(String.Format("學號='{0}'", lblId.Text))(0).Item("出席狀況") = "事假"
                Me.BackColor = CL_BK_GRAY
                tip.Show("事假", Me, New Point(0, -30), 1500)
            Case 6
                doCourseDtAttend.Select(String.Format("學號='{0}'", lblId.Text))(0).Item("出席狀況") = "公假"
                Me.BackColor = CL_BK_GRAY
                tip.Show("公假", Me, New Point(0, -30), 1500)
        End Select
        isSaved = False
    End Sub

    Public Sub showInfo()
        tip.Hide(Me)
        Select Case now
            Case 4
                tip.Show("病假", Me, New Point(0, -30), 3000)
            Case 5
                tip.Show("事假", Me, New Point(0, -30), 3000)
            Case 6
                tip.Show("公假", Me, New Point(0, -30), 3000)
        End Select
    End Sub
End Class
