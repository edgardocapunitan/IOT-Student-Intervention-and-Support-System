Imports MySql.Data.MySqlClient

Public Class Form7
    Dim connectionString As String = "server=localhost;user id=root;database=finals"
    Dim connection As MySqlConnection = New MySqlConnection(connectionString)

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
    End Sub

    Private Sub Form7_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            Login()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Login()
    End Sub

    Private Sub Login()
        Dim username As String = TextBox1.Text.Trim()
        Dim password As String = TextBox2.Text.Trim()

        Try
            connection.Open()
            Dim query As String = "SELECT COUNT(*) FROM teacher WHERE username = @username AND password = @password"
            Dim command As MySqlCommand = New MySqlCommand(query, connection)
            command.Parameters.AddWithValue("@username", username)
            command.Parameters.AddWithValue("@password", password)

            Dim result As Integer = Convert.ToInt32(command.ExecuteScalar())

            If result > 0 Then
                ' Check specific username and password for navigation
                If username = "ursolino" And password = "ursolino" Then
                    MessageBox.Show("Login successful!")
                    Me.Hide()
                    Dim form21 As New Form21
                    form21.ShowDialog()
                    Me.Close()
                ElseIf username = "bacoy" And password = "bacoy" Then
                    MessageBox.Show("Login successful!")
                    Me.Hide()
                    Dim form19 As New Form19
                    form19.ShowDialog()
                    Me.Close()
                ElseIf username = "landeza" And password = "landeza" Then
                    MessageBox.Show("Login successful!")
                    Me.Hide()
                    Dim form20 As New Form20
                    form20.ShowDialog()
                    Me.Close()
                ElseIf username = "cruz" And password = "cruz" Then
                    MessageBox.Show("Login successful!")
                    Me.Hide()
                    Dim form22 As New Form22
                    form22.ShowDialog()
                    Me.Close()
                ElseIf username = "dejan" And password = "dejan" Then
                    MessageBox.Show("Login successful!")
                    Me.Hide()
                    Dim form23 As New Form23
                    form23.ShowDialog()
                    Me.Close()
                ElseIf username = "casipit" And password = "casipit" Then
                    MessageBox.Show("Login successful!")
                    Me.Hide()
                    Dim form24 As New Form24
                    form24.ShowDialog()
                    Me.Close()
                ElseIf username = "bautista" And password = "bautista" Then
                    MessageBox.Show("Login successful!")
                    Me.Hide()
                    Dim form25 As New Form25
                    form25.ShowDialog()
                    Me.Close()
                Else
                    ' Default action for valid users but unspecified redirection
                    MessageBox.Show("Login successful!")
                    Me.Hide()
                    Dim form16 As New Form16
                    form16.ShowDialog()
                    Me.Close()
                End If
            Else
                MessageBox.Show("Invalid username or password. Please try again.")
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox1.Focus()
            End If
        Catch ex As MySqlException
            MessageBox.Show("Error: " & ex.Message)
        Finally
            connection.Close()
        End Try
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.Show()
        Me.Hide()
    End Sub
End Class
