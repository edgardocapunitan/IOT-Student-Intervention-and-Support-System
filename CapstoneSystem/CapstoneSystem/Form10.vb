Imports MySql.Data.MySqlClient

Public Class Form10
    Private conn As New MySqlConnection("server=localhost;user id=root;password=;database=finals")
    Private cmd As New MySqlCommand
    Private dr As MySqlDataReader
    Private result As Integer

    Public Sub changeNAME(ByVal username As String, ByVal currentname As String, ByVal newname As String, ByVal confirmname As String)
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            Dim checkSql As String = "SELECT NAME FROM teacher WHERE USERNAME = @username AND NAME = @currentNAME"
            cmd.Connection = conn
            cmd.CommandText = checkSql
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@username", username)
            cmd.Parameters.AddWithValue("@currentNAME", currentname)

            dr = cmd.ExecuteReader()

            If dr.HasRows Then
                dr.Close()
                If newname = confirmname Then
                    Dim updateSql As String = "UPDATE teacher SET NAME = @newNAME WHERE USERNAME = @username"
                    cmd.CommandText = updateSql
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@username", username)
                    cmd.Parameters.AddWithValue("@newNAME", newname)

                    result = cmd.ExecuteNonQuery()

                    If result > 0 Then
                        MessageBox.Show("Name successfully changed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadTeachersData()
                        ClearTextBoxes()
                    Else
                        MessageBox.Show("Name change failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("New name and confirmation do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Current name is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub
    Private Sub btnchNAME_Click(sender As Object, e As EventArgs) Handles btnchNAME.Click
        Dim username As String = TextBoxUSERNAME.Text
        Dim currentNAME As String = currentnames.Text
        Dim newNAME As String = newnames.Text
        Dim confirmNAME As String = confirmnames.Text

        changeNAME(username, currentNAME, newNAME, confirmNAME)
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
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub
    Private Sub ClearTextBoxes()
        TextBoxUSERNAME.Clear()
        currentnames.Clear()
        newnames.Clear()
        confirmnames.Clear()
    End Sub
    Private Sub TextBoxUSERNAME_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxUSERNAME.KeyDown, currentnames.KeyDown, newnames.KeyDown, confirmnames.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim username As String = TextBoxUSERNAME.Text
            Dim currentNAME As String = currentnames.Text
            Dim newNAME As String = newnames.Text
            Dim confirmNAME As String = confirmnames.Text

            changeNAME(username, currentNAME, newNAME, confirmNAME)
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTeachersData()
    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.CurrentRow IsNot Nothing Then
            TextBoxUSERNAME.Text = DataGridView1.CurrentRow.Cells("username").Value.ToString()
            currentnames.Text = DataGridView1.CurrentRow.Cells("name").Value.ToString()
            newnames.Clear()
            confirmnames.Clear()
        End If
    End Sub
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadTeachersData()
        ClearTextBoxes()
        MessageBox.Show("Data refreshed successfully!", "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        Dim searchQuery As String = txtsearch.Text
        LoadTeachersData(searchQuery)
    End Sub
    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        Dim searchQuery As String = txtsearch.Text
        LoadTeachersData(searchQuery)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form8.Show()

    End Sub
End Class
