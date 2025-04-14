Imports MySql.Data.MySqlClient

Public Class Form12
    Private conn As New MySqlConnection("server=localhost;user id=root;password=;database=finals")
    Private cmd As MySqlCommand
    Private result As Integer

    Private Sub LoadStudentData()
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            Dim query As String = "SELECT * FROM student"
            cmd = New MySqlCommand(query, conn)
            Dim da As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)
            DataGridView1.DataSource = dt

            If DataGridView1.Columns.Contains("LOGS") Then
                DataGridView1.Columns("LOGS").Visible = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btninsert_Click(sender As Object, e As EventArgs) Handles btninsert.Click
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            Dim query As String = "INSERT INTO student (RFID, NAME, YEAR_AND_COURSE, NUMBER, ADDRESS, EMAIL_ADDRESS) VALUES (@RFID, @NAME, @YEAR_AND_COURSE, @NUMBER, @ADDRESS, @EMAIL_ADDRESS)"
            cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@RFID", txtsn.Text)
            cmd.Parameters.AddWithValue("@NAME", txtfn.Text)
            cmd.Parameters.AddWithValue("@YEAR_AND_COURSE", txtyc.Text)
            cmd.Parameters.AddWithValue("@NUMBER", txtcn.Text)
            cmd.Parameters.AddWithValue("@ADDRESS", txtaddress.Text)
            cmd.Parameters.AddWithValue("@EMAIL_ADDRESS", txtea.Text)

            result = cmd.ExecuteNonQuery()

            If result > 0 Then
                MessageBox.Show("Student record inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadStudentData()
                ClearTextBoxes()
            Else
                MessageBox.Show("Failed to insert student record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            Dim query As String = "UPDATE student SET RFID = @RFID, YEAR_AND_COURSE = @YEAR_AND_COURSE, NUMBER = @NUMBER, ADDRESS = @ADDRESS, EMAIL_ADDRESS = @EMAIL_ADDRESS WHERE RFID = @RFID"
            cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@RFID", txtsn.Text)
            cmd.Parameters.AddWithValue("@NAME", txtfn.Text)
            cmd.Parameters.AddWithValue("@YEAR_AND_COURSE", txtyc.Text)
            cmd.Parameters.AddWithValue("@NUMBER", txtcn.Text)
            cmd.Parameters.AddWithValue("@ADDRESS", txtaddress.Text)
            cmd.Parameters.AddWithValue("@EMAIL_ADDRESS", txtea.Text)

            result = cmd.ExecuteNonQuery()

            If result > 0 Then
                MessageBox.Show("Student record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadStudentData()
                ClearTextBoxes()
            Else
                MessageBox.Show("Update failed or no rows affected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            Dim query As String = "DELETE FROM student WHERE RFID = @RFID"
            cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@RFID", txtsn.Text)

            result = cmd.ExecuteNonQuery()

            If result > 0 Then
                MessageBox.Show("Student record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadStudentData()
                ClearTextBoxes()
            Else
                MessageBox.Show("Failed to delete student record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        SearchStudent()
    End Sub

    Private Sub SearchStudent()
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            Dim query As String = "SELECT * FROM student WHERE RFID LIKE @search OR NAME LIKE @search"
            cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@search", "%" & txtsearch.Text & "%")
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

    Private Sub txtsearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            SearchStudent()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub ClearTextBoxes()
        txtsn.Clear()
        txtfn.Clear()
        txtyc.Clear()
        txtcn.Clear()
        txtaddress.Clear()
        txtea.Clear()
    End Sub

    Private Sub Form12_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadStudentData()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            txtsn.Text = row.Cells("RFID").Value.ToString()
            txtfn.Text = row.Cells("NAME").Value.ToString()
            txtyc.Text = row.Cells("YEAR_AND_COURSE").Value.ToString()
            txtcn.Text = row.Cells("NUMBER").Value.ToString()
            txtaddress.Text = row.Cells("ADDRESS").Value.ToString()
            txtea.Text = row.Cells("EMAIL_ADDRESS").Value.ToString()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form16.Show()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class
