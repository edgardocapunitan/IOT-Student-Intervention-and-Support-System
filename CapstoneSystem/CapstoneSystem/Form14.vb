Imports MySql.Data.MySqlClient

Public Class Form14
    Private conn As New MySqlConnection("server=localhost;user id=root;password=;database=finals")
    Private cmd As MySqlCommand

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Try
            If String.IsNullOrWhiteSpace(txtUsername.Text) OrElse String.IsNullOrWhiteSpace(txtPassword.Text) Then
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Dim checkQuery As String = "SELECT COUNT(*) FROM admin WHERE username = @username"
            cmd = New MySqlCommand(checkQuery, conn)
            cmd.Parameters.AddWithValue("@username", txtUsername.Text)

            Dim exists As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            If exists > 0 Then
                MessageBox.Show("Username already exists. Please choose another.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                Dim insertQuery As String = "INSERT INTO admin (username, password) VALUES (@username, @password)"
                cmd = New MySqlCommand(insertQuery, conn)
                cmd.Parameters.AddWithValue("@username", txtUsername.Text)
                cmd.Parameters.AddWithValue("@password", txtPassword.Text)

                Dim result As Integer = cmd.ExecuteNonQuery()

                If result > 0 Then
                    MessageBox.Show("Successfully created!", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim form3 As New Form3()
                    form3.Show()
                    Me.Hide()
                Else
                    MessageBox.Show("Registration failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Form14_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form4.Show()
    End Sub
End Class
