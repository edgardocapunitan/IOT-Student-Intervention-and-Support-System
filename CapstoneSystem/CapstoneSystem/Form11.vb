Imports MySql.Data.MySqlClient

Public Class Form11

    Private Sub Form11_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Showteacher()
    End Sub

    Sub Showteacher()
        conndb()
        cmd = New MySqlCommand("SELECT * FROM finals.teacher", conn)
        da = New MySqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "teacher")
        DataGridView1.DataSource = ds.Tables("teacher")
        cmd.Dispose()
        da.Dispose()
        conn.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.CurrentRow IsNot Nothing Then
            TextBoxSelect1.Text = DataGridView1.CurrentRow.Cells("username").Value.ToString()
            TextBoxSelect2.Text = DataGridView1.CurrentRow.Cells("password").Value.ToString()
            TextBoxSelect3.Text = DataGridView1.CurrentRow.Cells("name").Value.ToString()
            TextBoxsearch.Clear()
        End If
    End Sub

    Private Sub DELETETEACH_Click(sender As Object, e As EventArgs) Handles DELETETEACH.Click
        Dim result As Integer = MessageBox.Show("Are you sure you want to delete?", "Confirmation", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Try
                sql = "DELETE FROM finals.teacher WHERE USERNAME = @username"
                conndb()
                cmd = New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@username", TextBoxSelect1.Text)
                cmd.ExecuteNonQuery()
                MsgBox("Data deleted successfully")

                Showteacher()

                TextBoxSelect1.Clear()
                TextBoxSelect2.Clear()
                TextBoxSelect3.Clear()

            Catch ex As Exception
                MsgBox("Error: " & ex.Message)
            Finally
                cmd.Dispose()
                conn.Close()
            End Try
        End If
    End Sub

    Private Sub Buttonsearch_Click(sender As Object, e As EventArgs) Handles Buttonsearch.Click
        SearchTeacher()
    End Sub

    Private Sub SearchTeacher()
        Dim searchQuery As String = TextBoxsearch.Text.Trim()
        If Not String.IsNullOrEmpty(searchQuery) Then
            conndb()
            Dim query As String = "SELECT * FROM finals.teacher WHERE USERNAME = @searchQuery"
            cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@searchQuery", searchQuery)

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                TextBoxSelect1.Text = reader("username").ToString()
                TextBoxSelect2.Text = reader("password").ToString()
                TextBoxSelect3.Text = reader("name").ToString()
            Else
                MessageBox.Show("Teacher not found", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TextBoxSelect1.Clear()
                TextBoxSelect2.Clear()
                TextBoxSelect3.Clear()
            End If
            reader.Close()
            cmd.Dispose()
            conn.Close()
        End If
    End Sub
    Private Sub TextBoxsearch_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxsearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            SearchTeacher()
        End If
    End Sub

    Private Sub TextBoxsearch_TextChanged(sender As Object, e As EventArgs) Handles TextBoxsearch.TextChanged
    End Sub

    Private Sub updatebutton_Click(sender As Object, e As EventArgs) Handles updatebutton.Click
        Showteacher()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form5.Show()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class
