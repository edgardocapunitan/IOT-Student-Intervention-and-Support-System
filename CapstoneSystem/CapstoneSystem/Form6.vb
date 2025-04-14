Imports MySql.Data.MySqlClient

Public Class Form6
    Dim con As New MySqlConnection
    Dim connectionString As String = "server=localhost;user id=root;database=finals"

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.ConnectionString = connectionString
    End Sub
    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        If Tuser.Text = String.Empty Or Tpass.Text = String.Empty Or Tname.Text = String.Empty Then
            MessageBox.Show("Please enter all details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Using cmd As New MySqlCommand("SELECT COUNT(*) FROM teacher WHERE username = @username OR password = @password", con)
                cmd.Parameters.AddWithValue("@username", Tuser.Text.Trim)
                cmd.Parameters.AddWithValue("@password", Tpass.Text.Trim)

                Dim count = Convert.ToInt32(cmd.ExecuteScalar())
                If count > 0 Then
                    MessageBox.Show("Oops, username or password has already been taken", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End Using
            Using create As New MySqlCommand("INSERT INTO teacher(name, username, password) VALUES(@name, @username, @password)", con)
                create.Parameters.AddWithValue("@name", Tname.Text.Trim)
                create.Parameters.AddWithValue("@username", Tuser.Text.Trim)
                create.Parameters.AddWithValue("@password", Tpass.Text.Trim)

                If create.ExecuteNonQuery() > 0 Then
                    MessageBox.Show("Account Created!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Tname.Clear()
                    Tuser.Clear()
                    Tpass.Clear()
                End If
            End Using

            con.Close()

            Me.Hide()
            Form7.Show()

        Catch ex As MySqlException
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form5.Show()
    End Sub
End Class
