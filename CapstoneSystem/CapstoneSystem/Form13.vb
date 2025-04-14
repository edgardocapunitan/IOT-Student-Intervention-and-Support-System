Imports MySql.Data.MySqlClient

Public Class Form13
    Private conn As New MySqlConnection("server=localhost;user id=root;password=;database=finals")
    Private cmd As MySqlCommand

    Private Sub txtname_TextChanged(sender As Object, e As EventArgs) Handles txtname.TextChanged
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            Dim query As String = "SELECT s.NAME, g.Programming, g.`Social Science`, g.`HRO`, g.`Filipino 11+`, g.`MEDLIT`, g.`Literature 1`, g.`Literature 2`, g.`English 11+`, g.`Physical Education 3`, g.`General Average` FROM student s LEFT JOIN grades g ON s.NAME = g.NAME WHERE s.NAME LIKE @name;"

            cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@name", "%" & txtname.Text & "%")

            Dim da As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)

            DataGridView1.DataSource = dt

            If dt.Rows.Count > 0 Then
                txtprogramming.Text = dt.Rows(0)("Programming").ToString()
                txtsocsci.Text = dt.Rows(0)("Social Science").ToString()
                txthro.Text = dt.Rows(0)("HRO").ToString()
                txtfil.Text = dt.Rows(0)("Filipino 11+").ToString()
                txtmedlit.Text = dt.Rows(0)("MEDLIT").ToString()
                txtlit.Text = dt.Rows(0)("Literature 1").ToString()
                txtlittwo.Text = dt.Rows(0)("Literature 2").ToString()
                txtenglish.Text = dt.Rows(0)("English 11+").ToString()
                txtphyed.Text = dt.Rows(0)("Physical Education 3").ToString()
                txtaverage.Text = dt.Rows(0)("General Average").ToString()
            Else
                txtprogramming.Clear()
                txtsocsci.Clear()
                txthro.Clear()
                txtfil.Clear()
                txtmedlit.Clear()
                txtlit.Clear()
                txtlittwo.Clear()
                txtenglish.Clear()
                txtphyed.Clear()
                txtaverage.Clear()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btnSaveOrUpdate_Click(sender As Object, e As EventArgs) Handles btnSaveOrUpdate.Click
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            Dim programming As Double = If(Double.TryParse(txtprogramming.Text, programming), programming, 0)
            Dim socsci As Double = If(Double.TryParse(txtsocsci.Text, socsci), socsci, 0)
            Dim hro As Double = If(Double.TryParse(txthro.Text, hro), hro, 0)
            Dim filipino As Double = If(Double.TryParse(txtfil.Text, filipino), filipino, 0)
            Dim medlit As Double = If(Double.TryParse(txtmedlit.Text, medlit), medlit, 0)
            Dim lit As Double = If(Double.TryParse(txtlit.Text, lit), lit, 0)
            Dim littwo As Double = If(Double.TryParse(txtlittwo.Text, littwo), littwo, 0)
            Dim english As Double = If(Double.TryParse(txtenglish.Text, english), english, 0)
            Dim phyed As Double = If(Double.TryParse(txtphyed.Text, phyed), phyed, 0)

            Dim totalGrades As Integer = 0
            Dim total As Double = 0
            Dim grades As Double() = {programming, socsci, hro, filipino, medlit, lit, littwo, english, phyed}

            Dim failedSubjects As Integer = 0

            For Each grade In grades
                If grade > 0 Then
                    total += grade
                    totalGrades += 1
                    If grade < 75 Then
                        failedSubjects += 1
                    End If
                End If
            Next

            Dim average As Double = If(totalGrades > 0, total / totalGrades, 0)
            txtaverage.Text = average.ToString("F2")
            txtfailed.Text = failedSubjects.ToString()
            txtstatus.Text = If(failedSubjects > 0, "At-Risk", "Passed")

            ' First, check if the record already exists
            Dim checkQuery As String = "SELECT COUNT(*) FROM grades WHERE NAME = @NAME"
            cmd = New MySqlCommand(checkQuery, conn)
            cmd.Parameters.AddWithValue("@NAME", txtname.Text)
            Dim exists As Boolean = Convert.ToInt32(cmd.ExecuteScalar()) > 0

            ' Define the query for updating or inserting based on the record's existence
            Dim query As String
            If exists Then
                query = "UPDATE grades SET Programming = @Programming, `Social Science` = @socsci, `HRO` = @hro, `Filipino 11+` = @filipino, `MEDLIT` = @medlit, `Literature 1` = @lit, `Literature 2` = @littwo, `English 11+` = @english, `Physical Education 3` = @phyed, `General Average` = @Average WHERE NAME = @NAME"
            Else
                query = "INSERT INTO grades (NAME, Programming, `Social Science`, `HRO`, `Filipino 11+`, `MEDLIT`, `Literature 1`, `Literature 2`, `Physical Education 3`, `English 11+`, `General Average`) VALUES (@NAME, @Programming, @socsci, @hro, @filipino, @medlit, @lit, @littwo, @phyed, @english, @Average)"
            End If

            cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@NAME", txtname.Text)
            cmd.Parameters.AddWithValue("@Programming", programming)
            cmd.Parameters.AddWithValue("@socsci", socsci)
            cmd.Parameters.AddWithValue("@hro", hro)
            cmd.Parameters.AddWithValue("@filipino", filipino)
            cmd.Parameters.AddWithValue("@medlit", medlit)
            cmd.Parameters.AddWithValue("@lit", lit)
            cmd.Parameters.AddWithValue("@littwo", littwo)
            cmd.Parameters.AddWithValue("@english", english)
            cmd.Parameters.AddWithValue("@phyed", phyed)
            cmd.Parameters.AddWithValue("@Average", average)

            Dim result As Integer = cmd.ExecuteNonQuery()

            If result > 0 Then
                MessageBox.Show("Grades saved or updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed to save or update grades.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()

            ClearTextBoxes()


        End Try

    End Sub






    Private Sub ClearTextBoxes()
        txtprogramming.Clear()
        txtsocsci.Clear()
        txthro.Clear()
        txtfil.Clear()
        txtmedlit.Clear()
        txtlit.Clear()
        txtlittwo.Clear()
        txtenglish.Clear()
        txtphyed.Clear()
        txtaverage.Clear()
        txtfailed.Clear()
        txtstatus.Clear()

    End Sub

    Private Sub Form13_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAllGrades()
    End Sub
    Private Sub LoadAllGrades()
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            Dim query As String = _
    "SELECT s.NAME, g.Programming, g.`Social Science`, g.`HRO`, g.`Filipino 11+`, " & _
    "g.`MEDLIT`, g.`Literature 1`, g.`Literature 2`, g.`Physical Education 3`, g.`English 11+`, " & _
    "g.`General Average` " & _
    "FROM student s " & _
    "LEFT JOIN grades g ON s.NAME = g.NAME;"


            cmd = New MySqlCommand(query, conn)
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

    Private Sub btnedit_Click(sender As Object, e As EventArgs) Handles btnedit.Click
        txtprogramming.ReadOnly = False
        txtsocsci.ReadOnly = False
        txthro.ReadOnly = False
        txtfil.ReadOnly = False
        txtmedlit.ReadOnly = False
        txtlit.ReadOnly = False
        txtlittwo.ReadOnly = False
        txtenglish.ReadOnly = False
        txtphyed.ReadOnly = False

        MessageBox.Show("You can now edit the grades. Remember to save changes.", "Edit Mode", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    ' Method to refresh the grades from the database
    Private Sub btnrefresh_Click(sender As Object, e As EventArgs) Handles btnrefresh.Click
        txtname.Clear()

        ClearTextBoxes()
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

            txtname.Text = row.Cells("NAME").Value.ToString()
            Dim grades As New List(Of Double)
            Dim safeParse As Func(Of TextBox, Double) = Function(tb As TextBox)
                                                            Dim value As Double
                                                            If Double.TryParse(tb.Text, value) Then
                                                                Return value
                                                            Else
                                                                Return 0
                                                            End If
                                                        End Function

            grades.Add(safeParse(txtprogramming))
            grades.Add(safeParse(txtsocsci))
            grades.Add(safeParse(txthro))
            grades.Add(safeParse(txtfil))
            grades.Add(safeParse(txtmedlit))
            grades.Add(safeParse(txtlit))
            grades.Add(safeParse(txtlittwo))
            grades.Add(safeParse(txtenglish))
            grades.Add(safeParse(txtphyed))

            Dim failedCount As Integer = 0
            For Each grade In grades
                If grade < 75 Then
                    failedCount += 1
                End If
            Next
            If failedCount > 0 Then
                txtstatus.Text = "At-Risk"
            Else
                txtstatus.Text = "Passed"
            End If
            txtfailed.Text = failedCount.ToString()
        End If
    End Sub


    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Dim confirmResult As DialogResult = MessageBox.Show("Are you sure you want to delete the grades for " & txtname.Text & "?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If confirmResult = DialogResult.Yes Then
                Dim query As String = "DELETE FROM grades WHERE NAME = @NAME"

                cmd = New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@NAME", txtname.Text)

                Dim result As Integer = cmd.ExecuteNonQuery()

                If result > 0 Then
                    MessageBox.Show("Grades deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ClearTextBoxes()
                    txtname_TextChanged(sender, e)
                Else
                    MessageBox.Show("Failed to delete grades. Record may not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Hide()
        Form12.Show()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs)
        Me.Hide()
        Form7.Show()

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form1.Show()

    End Sub
End Class
