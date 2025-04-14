Imports MySql.Data.MySqlClient

Public Class Form9
    Private conn As New MySqlConnection("server=localhost;user id=root;password=;database=finals")
    Private cmd As New MySqlCommand
    Private dr As MySqlDataReader
    Private result As Integer

    Public Sub changePassword(ByVal username As String, ByVal currentPassword As String, ByVal newPassword As String, ByVal confirmPassword As String)
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            Dim checkSql As String = "SELECT PASSWORD FROM teacher WHERE USERNAME = @username AND PASSWORD = @currentPassword"
            cmd.Connection = conn
            cmd.CommandText = checkSql
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@username", username)
            cmd.Parameters.AddWithValue("@currentPassword", currentPassword)

            dr = cmd.ExecuteReader()

            If dr.HasRows Then
                dr.Close()

                If newPassword = confirmPassword Then
                    Dim updateSql As String = "UPDATE teacher SET PASSWORD = @newPassword WHERE USERNAME = @username"
                    cmd.CommandText = updateSql
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@username", username)
                    cmd.Parameters.AddWithValue("@newPassword", newPassword)

                    result = cmd.ExecuteNonQuery()

                    If result > 0 Then
                        MessageBox.Show("Password successfully changed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadTeachersData()
                        ClearTextBoxes()
                    Else
                        MessageBox.Show("Password change failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("New password and confirmation do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Current password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btnchpass_Click(sender As Object, e As EventArgs) Handles btnchpass.Click
        Dim username As String = TextBoxUSERNAME.Text
        Dim currentPassword As String = currentpass.Text
        Dim newPassword As String = newpass.Text
        Dim confirmPassword As String = confirmpass.Text

        changePassword(username, currentPassword, newPassword, confirmPassword)
    End Sub

    Private Sub LoadTeachersData(Optional ByVal searchQuery As String = "")
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            Dim query As String = "SELECT * FROM teacher"
            If Not String.IsNullOrWhiteSpace(searchQuery) Then
                query &= " WHERE NAME LIKE @searchQuery OR USERNAME LIKE @searchQuery"
            End If

            cmd = New MySqlCommand(query, conn)
            cmd.Parameters.Clear()
            If Not String.IsNullOrWhiteSpace(searchQuery) Then
                cmd.Parameters.AddWithValue("@searchQuery", "%" & searchQuery & "%")
            End If

            Dim da As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)
            DataGridView1.DataSource = dt
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub ClearTextBoxes()
        TextBoxUSERNAME.Clear()
        currentpass.Clear()
        newpass.Clear()
        confirmpass.Clear()
    End Sub

    Private Sub TextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxUSERNAME.KeyDown, currentpass.KeyDown, newpass.KeyDown, confirmpass.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim username As String = TextBoxUSERNAME.Text
            Dim currentPassword As String = currentpass.Text
            Dim newPassword As String = newpass.Text
            Dim confirmPassword As String = confirmpass.Text

            changePassword(username, currentPassword, newPassword, confirmPassword)

            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTeachersData()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.CurrentRow IsNot Nothing Then
            TextBoxUSERNAME.Text = DataGridView1.CurrentRow.Cells("username").Value.ToString()
            currentpass.Clear()
            newpass.Clear()
            confirmpass.Clear()
        End If
    End Sub
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadTeachersData()
        MessageBox.Show("Data refreshed successfully!", "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ClearTextBoxes()
    End Sub
    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        Dim searchQuery As String = txtsearch.Text
        LoadTeachersData(searchQuery)
    End Sub
    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        Dim searchQuery As String = txtsearch.Text
        LoadTeachersData(searchQuery)
    End Sub

    Private Sub confirmpass_TextChanged(sender As Object, e As EventArgs) Handles confirmpass.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form8.Show()
    End Sub
End Class
