Imports MySql.Data.MySqlClient

Public Class Form3

    Dim connectionString As String = "server=localhost;user id=root;database=finals"
    Dim connection As MySqlConnection = New MySqlConnection(connectionString)

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
    End Sub

    Private Sub Form3_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            Login()
        End If
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Login()
    End Sub

    Private Sub Login()
        Dim username As String = txtUsername.Text
        Dim password As String = txtPassword.Text

        Try
            connection.Open()
            Dim query As String = "SELECT * FROM finals.admin WHERE username = @username AND password = @password"
            Dim command As MySqlCommand = New MySqlCommand(query, connection)
            command.Parameters.AddWithValue("@username", username)
            command.Parameters.AddWithValue("@password", password)

            Dim reader As MySqlDataReader = command.ExecuteReader()

            If reader.HasRows Then
                Me.Hide()
                Dim form4 As New Form4
                form4.ShowDialog()
                Me.Close()
            Else
                MessageBox.Show("Invalid username or password!")
            End If

            reader.Close()
        Catch ex As MySqlException
            MessageBox.Show("Error: " & ex.Message)
        Finally
            connection.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Hide()

    End Sub
End Class
