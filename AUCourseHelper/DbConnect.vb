Imports System.Data
Imports System.Data.SqlClient

Module DbConnect
    Private sqlConn As SqlConnection
    Private sqlConnString As String = "Data Source=192.192.122.202;Initial Catalog=AUCourse;Persist Security Info=True;User ID=NDML-202;Password=714b"
    Dim sqlExeLock As New Object

    Public Function openDb() As Boolean
        log("連接系統資料庫...", LogType_NORMAL)
        Try
            sqlConn = New SqlConnection(sqlConnString)
            sqlConn.Open()
        Catch ex As Exception
            log("系統資料庫開啟失敗! " & ex.Message, LogType_ERROR)
            Return False
        End Try
        log("系統資料庫已連線", LogType_NORMAL)
        Return True
    End Function

    Public Sub closeDb()
        sqlConn.Close()
        log("系統資料庫連線已斷開", LogType_NORMAL)
    End Sub

    Public Function selectCmd(ByVal sql As String) As DataTable
        Dim result As New DataTable
        Dim sqlAdapter As New SqlDataAdapter(sql, sqlConn)
        Try
            sqlAdapter.Fill(result)
        Catch ex As Exception
            log("資料庫查詢失敗! " & ex.Message, LogType_ERROR)
            Return Nothing
        End Try
        Return result
    End Function

    Public Function exeCmd(ByVal sql As String) As Boolean
        Dim sqlCmd As New SqlCommand(sql, sqlConn)
        Try
            SyncLock sqlExeLock
                sqlCmd.ExecuteNonQuery()
            End SyncLock
        Catch ex As Exception
            log("資料庫命令執行失敗! " & ex.Message, LogType_ERROR)
            Return False
        End Try
        Return True
    End Function

    Public Function login(ByVal uid As String, ByVal pwd As String, ByVal userType As Char) As String
        Dim userInfo As String = ""
        Select Case userType
            Case "T" ' 老師
                Dim sql = String.Format("SELECT Id,RTRIM(Name) FROM Teacher WHERE Num='{0}' AND Pwd='{1}'", uid, pwd)
                Dim result = selectCmd(sql)
                If result.Rows.Count > 0 Then
                    userInfo = result.Rows(0).Item(0) & ";" & result.Rows(0).Item(1)
                End If
            Case "S" ' 學生
                Dim sql = String.Format("SELECT Id,RTRIM(Name) FROM Student WHERE Num='{0}' AND Pwd='{1}'", uid, pwd)
                Dim result = selectCmd(sql)
                If result.Rows.Count > 0 Then
                    userInfo = result.Rows(0).Item(0) & ";" & result.Rows(0).Item(1)
                End If
        End Select
        Return userInfo
    End Function

End Module
