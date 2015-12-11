Public Class dlgMyProfile

    Private Sub frmMyProfile_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtUid.Text = myProfile.Num
        txtName.Text = myProfile.Name
        txtLastLogin.Text = myProfile.LastLogin
        txtLastIp.Text = myProfile.LastIp
        txtWebSite.Text = myProfile.WebSite
        txtOfficeTime.Text = myProfile.OfficeTime
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Me.Dispose()
    End Sub
End Class