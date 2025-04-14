Imports MySql.Data.MySqlClient
Module Module1

    Public sql As String
    Public result As String
    Public ds As New DataSet
    Public cmd As New MySqlCommand
    Public dr As MySqlDataReader
    Public da As MySqlDataAdapter
    Public dt As DataTable
    Public conn As New MySqlConnection
    Public Function strstconnection() As MySqlConnection
        Return New MySqlConnection("server=localhost;user id=root;database=finals")
    End Function
    Public strcon As MySqlConnection = strstconnection()
    Public Sub conndb()
        Try
            conn = New MySqlConnection("datasource=localhost;port=3306;username=root;password=")
            conn.Open()
        Catch ex As Exception
            MsgBox("Please Configure Database", MsgBoxStyle.Information, "Database")
        End Try
    End Sub
    Public Sub create(ByVal sql As String)
        Try
            strcon.Open()
            With cmd
                .Connection = strcon
                .CommandText = sql

                result = cmd.ExecuteNonQuery

                If result = 0 Then
                    MessageBox.Show("data faild to insert", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    MessageBox.Show("data has been successfully inserted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End With
        Catch ex As Exception
        Finally
            strcon.Close()
        End Try
    End Sub
    Public Sub reload(ByVal sql As String)
        Try
            strcon.Open()
            dt = New DataTable
            With cmd
                .Connection = strcon
                .CommandText = sql
            End With
            da.SelectCommand = cmd
            da.Fill(dt)
        Catch ex As Exception
        Finally
            strcon.Close()
            da.Dispose()
        End Try
    End Sub
    Public Sub reloadtxt(ByVal sql As String)
        Try
            strcon.Open()
            With cmd
                .Connection = strcon
                .CommandText = sql
            End With

            dt = New DataTable
            da = New MySqlDataAdapter(sql, strcon)
            da.Fill(dt)
        Catch ex As Exception
        Finally
            strcon.Close()
            da.Dispose()
        End Try
    End Sub
    Public Sub createlogged(ByVal sql As String)
        Try
            strcon.Open()
            With cmd
                .Connection = strcon
                .CommandText = sql
                result = cmd.ExecuteNonQuery
            End With
        Catch ex As Exception
        Finally
            strcon.Close()
        End Try
    End Sub
    Public Sub updatesLogged(ByVal sql As String)
        Try
            strcon.Open()
            With cmd
                .Connection = strcon
                .CommandText = sql
                result = cmd.ExecuteNonQuery
            End With
        Catch ex As Exception
        Finally
            strcon.Close()
        End Try
    End Sub
End Module
