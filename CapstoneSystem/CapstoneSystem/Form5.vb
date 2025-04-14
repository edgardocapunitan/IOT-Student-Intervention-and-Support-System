Imports MySql.Data.MySqlClient

Public Class Form5
    Dim connectionString As String = "server=localhost;user id=root;database=finals"
    Dim connection As MySqlConnection = New MySqlConnection(connectionString)

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTeacherData()
    End Sub

    Private Sub LoadTeacherData()
        Try
            connection.Open()
            Dim query As String = "SELECT * FROM teacher"
            Dim adapter As New MySqlDataAdapter(query, connection)
            Dim table As New DataTable()

            adapter.Fill(table)
            DataGridView1.DataSource = table

        Catch ex As MySqlException
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form6.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Form8.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form11.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Form4.Show()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadTeacherData()
        MessageBox.Show("Data refreshed successfully!", "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Class
