Imports MySql.Data.MySqlClient

Public Class Form23
    ' Connection string to connect to the MySQL database
    Dim connectionString As String = "server=localhost;userid=root;password=;database=finals"

    ' Variables to track RadioButton states
    Private lastClickedRadioButton As RadioButton = Nothing

    Private Sub Form23_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Attach a common event handler to the RadioButtons
        AddHandler Radioguidance.Click, AddressOf RadioButton_Click
        AddHandler Radioclass.Click, AddressOf RadioButton_Click
        AddHandler Radiorem.Click, AddressOf RadioButton_Click

        ' Initialize the DataGridView columns
        InitializeDataGridView()

        ' Load students with grades below 75
        LoadGradesBelow75()
        Me.BackColor = Color.DarkRed
    End Sub

    Private Sub RadioButton_Click(sender As Object, e As EventArgs)
        Dim radioButton As RadioButton = DirectCast(sender, RadioButton)

        ' Check if the same RadioButton is clicked again
        If lastClickedRadioButton Is radioButton AndAlso radioButton.Checked Then
            radioButton.Checked = False ' Deselect the RadioButton
            lastClickedRadioButton = Nothing ' Reset the last clicked
        Else
            lastClickedRadioButton = radioButton ' Track the current RadioButton
        End If
    End Sub

    Private Sub InitializeDataGridView()
        ' Setup columns in the DataGridView
        With DataGridView1
            .Columns.Clear()
            .Columns.Add("RFID", "RFID")
            .Columns.Add("Name", "Name")
            .Columns.Add("Subject", "Subject")
            .Columns.Add("teacher", "Teacher")
            .AllowUserToAddRows = False
        End With
    End Sub

    Private Sub LoadGradesBelow75()
        Try
            ' Clear existing rows in the DataGridView
            DataGridView1.Rows.Clear()

            ' Connect to the database
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                ' Query to select students who failed in any subject (grades < 75)
                Dim query As String = "SELECT s.RFID, g.NAME, 'Social Science' AS subject, st.teacher " & _
                      "FROM grades g " & _
                      "INNER JOIN subjectsteacher st ON st.subject = 'Social Science' " & _
                      "INNER JOIN student s ON s.NAME = g.NAME " & _
                      "WHERE g.`Social Science` < 75 AND st.teacher = 'Mr. Dejan';"

                ' Execute the query and process the results
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim studentRFID As String = reader("RFID").ToString()
                            Dim studentName As String = reader("NAME").ToString()
                            Dim subject As String = reader("subject").ToString()
                            Dim teacher As String = reader("teacher").ToString()

                            ' Add the student, subject, and teacher to the DataGridView
                            DataGridView1.Rows.Add(studentRFID, studentName, subject, teacher)
                        End While
                    End Using
                End Using
                conn.Close()
            End Using
        Catch ex As Exception
            ' Handle any errors
            MessageBox.Show("Error loading data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        ' Check if the clicked row is valid
        If e.RowIndex >= 0 Then
            ' Get the selected row
            Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

            ' Autofill the textboxes with values from the selected row
            TextBoxRFID.Text = selectedRow.Cells("RFID").Value.ToString()
            txtname.Text = selectedRow.Cells("Name").Value.ToString()
            txtsub.Text = selectedRow.Cells("Subject").Value.ToString()
            txtteach.Text = selectedRow.Cells("Teacher").Value.ToString()
        End If
    End Sub


    Private Sub btnsubmit_Click(sender As Object, e As EventArgs) Handles btnsubmit.Click
        ' Get values from the form fields
        Dim subject As String = txtsub.Text
        Dim teacher As String = txtteach.Text
        Dim student As String = txtname.Text
        Dim cause As String = RichTextBox2.Text
        Dim solution As String = ""

        ' Determine the selected solution
        If Radioguidance.Checked Then
            solution = "Guidance Consultation"
        ElseIf Radioclass.Checked Then
            solution = "Make-up Class"
        ElseIf Radiorem.Checked Then
            solution = "Remedial"
        ElseIf Not String.IsNullOrWhiteSpace(RichTextBox1.Text) Then
            solution = RichTextBox1.Text
        End If

        ' Validate the input fields
        If String.IsNullOrWhiteSpace(subject) OrElse String.IsNullOrWhiteSpace(teacher) OrElse
           String.IsNullOrWhiteSpace(student) OrElse String.IsNullOrWhiteSpace(cause) OrElse
           String.IsNullOrWhiteSpace(solution) Then
            MessageBox.Show("Please fill out all fields before submitting.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            ' Insert data into the database
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "INSERT INTO intervention (subject, teacher, studentname, Cause, Solution, dateissued) VALUES (@subject, @teacher, @student, @cause, @solution, @dateissued)"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@subject", subject)
                    cmd.Parameters.AddWithValue("@teacher", teacher)
                    cmd.Parameters.AddWithValue("@student", student)
                    cmd.Parameters.AddWithValue("@cause", cause)
                    cmd.Parameters.AddWithValue("@solution", solution)
                    cmd.Parameters.AddWithValue("@dateissued", DateTime.Now)
                    cmd.ExecuteNonQuery()
                End Using
                conn.Close()
            End Using

            MessageBox.Show("Intervention details successfully saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Clear all fields after submission
            txtsub.Clear()
            txtteach.Clear()
            txtname.Clear()
            RichTextBox2.Clear()
            RichTextBox1.Clear()
            Radioguidance.Checked = False
            Radioclass.Checked = False
            Radiorem.Checked = False
            lastClickedRadioButton = Nothing ' Reset the last clicked RadioButton
        Catch ex As Exception
            ' Handle any database errors
            MessageBox.Show("Error saving data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Form16.Show()
        Me.Close()
    End Sub

    Private Sub ButtonSearch_Click(sender As Object, e As EventArgs) Handles ButtonSearch.Click
        ' Get the search term from Txtsearch
        Dim searchValue As String = Txtsearch.Text.Trim()

        ' Validate input
        If String.IsNullOrWhiteSpace(searchValue) Then
            MessageBox.Show("Please enter a value to search.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            ' Clear existing rows in the DataGridView
            DataGridView1.Rows.Clear()

            ' Connect to the database
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                ' Query to search for students with matching names or RFID
                Dim query As String = "SELECT s.RFID, g.NAME, 'Programming' AS subject, st.teacher " & _
                                      "FROM grades g " & _
                                      "INNER JOIN subjectsteacher st ON st.subject = 'Programming' " & _
                                      "INNER JOIN student s ON s.NAME = g.NAME " & _
                                      "WHERE (g.`Programming` < 75 AND (s.RFID LIKE @search OR g.NAME LIKE @search)) " & _
                                      "UNION ALL " & _
                                      "SELECT s.RFID, g.NAME, 'Social Science' AS subject, st.teacher " & _
                                      "FROM grades g " & _
                                      "INNER JOIN subjectsteacher st ON st.subject = 'Social Science' " & _
                                      "INNER JOIN student s ON s.NAME = g.NAME " & _
                                      "WHERE (g.`Social Science` < 75 AND (s.RFID LIKE @search OR g.NAME LIKE @search)) " & _
                                      "UNION ALL " & _
                                      "SELECT s.RFID, g.NAME, 'Filipino 11+' AS subject, st.teacher " & _
                                      "FROM grades g " & _
                                      "INNER JOIN subjectsteacher st ON st.subject = 'Filipino 11+' " & _
                                      "INNER JOIN student s ON s.NAME = g.NAME " & _
                                      "WHERE (g.`Filipino 11+` < 75 AND (s.RFID LIKE @search OR g.NAME LIKE @search)) " & _
                                      "UNION ALL " & _
                                      "SELECT s.RFID, g.NAME, 'MEDLIT' AS subject, st.teacher " & _
                                      "FROM grades g " & _
                                      "INNER JOIN subjectsteacher st ON st.subject = 'MEDLIT' " & _
                                      "INNER JOIN student s ON s.NAME = g.NAME " & _
                                      "WHERE (g.MEDLIT < 75 AND (s.RFID LIKE @search OR g.NAME LIKE @search)) " & _
                                      "UNION ALL " & _
                                      "SELECT s.RFID, g.NAME, 'Literature 1' AS subject, st.teacher " & _
                                      "FROM grades g " & _
                                      "INNER JOIN subjectsteacher st ON st.subject = 'Literature 1' " & _
                                      "INNER JOIN student s ON s.NAME = g.NAME " & _
                                      "WHERE (g.`Literature 1` < 75 AND (s.RFID LIKE @search OR g.NAME LIKE @search)) " & _
                                      "UNION ALL " & _
                                      "SELECT s.RFID, g.NAME, 'Literature 2' AS subject, st.teacher " & _
                                      "FROM grades g " & _
                                      "INNER JOIN subjectsteacher st ON st.subject = 'Literature 2' " & _
                                      "INNER JOIN student s ON s.NAME = g.NAME " & _
                                      "WHERE (g.`Literature 2` < 75 AND (s.RFID LIKE @search OR g.NAME LIKE @search)) " & _
                                      "UNION ALL " & _
                                      "SELECT s.RFID, g.NAME, 'English 11+' AS subject, st.teacher " & _
                                      "FROM grades g " & _
                                      "INNER JOIN subjectsteacher st ON st.subject = 'English 11+' " & _
                                      "INNER JOIN student s ON s.NAME = g.NAME " & _
                                      "WHERE (g.`English 11+` < 75 AND (s.RFID LIKE @search OR g.NAME LIKE @search)) " & _
                                      "UNION ALL " & _
                                      "SELECT s.RFID, g.NAME, 'HRO' AS subject, st.teacher " & _
                                      "FROM grades g " & _
                                      "INNER JOIN subjectsteacher st ON st.subject = 'HRO' " & _
                                      "INNER JOIN student s ON s.NAME = g.NAME " & _
                                      "WHERE (g.HRO < 75 AND (s.RFID LIKE @search OR g.NAME LIKE @search));"

                ' Execute the query and process the results
                Using cmd As New MySqlCommand(query, conn)
                    ' Add the parameter to avoid SQL injection
                    cmd.Parameters.AddWithValue("@search", "%" & searchValue & "%")

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim studentRFID As String = reader("RFID").ToString()
                            Dim studentName As String = reader("NAME").ToString()
                            Dim subject As String = reader("subject").ToString()
                            Dim teacher As String = reader("teacher").ToString()

                            ' Add the student, subject, and teacher to the DataGridView
                            DataGridView1.Rows.Add(studentRFID, studentName, subject, teacher)
                        End While
                    End Using
                End Using
                conn.Close()
            End Using
        Catch ex As Exception
            ' Handle any errors
            MessageBox.Show("Error during search: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RefreshControls()
        ' Clear the Txtsearch textbox
        Txtsearch.Clear()

        ' Reset other controls (if applicable)
        txtsub.Clear()
        txtteach.Clear()
        txtname.Clear()
        RichTextBox2.Clear()
        RichTextBox1.Clear()
        TextBoxRFID.Clear()


        ' Uncheck any selected radio buttons
        Radioguidance.Checked = False
        Radioclass.Checked = False
        Radiorem.Checked = False
        lastClickedRadioButton = Nothing
    End Sub

    Private Sub Txtsearch_KeyDown(sender As Object, e As KeyEventArgs) Handles Txtsearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            ' Call the ButtonSearch_Click method to perform the search
            ButtonSearch_Click(sender, e)

            ' Refresh the textbox and other controls
            RefreshControls()

            ' Prevent the beep sound when pressing Enter
            e.SuppressKeyPress = True
        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RefreshControls()
        LoadGradesBelow75()
    End Sub









    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form30.Show()
        Me.Close()

    End Sub
End Class
