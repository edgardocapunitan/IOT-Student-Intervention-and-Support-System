Imports MySql.Data.MySqlClient
Imports System.Net.Http
Imports System.Threading.Tasks


Public Class Form15
    Dim conn As New MySqlConnection("server=localhost;uid=root;pwd=;database=finals") ' Adjust connection string
    Dim cmd As New MySqlCommand
    Dim reader As MySqlDataReader

    ' Method to load data into the DataGridView

    Private Sub LoadStatusData()
        ' Use LEFT JOIN to get student names along with status information, and filter only atRisk students
        Dim dt As New DataTable()
        cmd.Connection = conn
        cmd.CommandText = "SELECT student.NAME, student.ABSENT, status.failedSubjects, status.atRiskStatus " & _
                          "FROM student " & _
                          "LEFT JOIN status ON student.NAME = status.NAME " & _
                          "WHERE status.atRiskStatus = 'At-Risk'"
        conn.Open()
        dt.Load(cmd.ExecuteReader())
        conn.Close()

        ' Bind the DataGridView to the data
        DataGridView1.DataSource = dt

        ' Check column names to verify the correct ones are loaded
        For Each column As DataColumn In dt.Columns
            Console.WriteLine(column.ColumnName)  ' This will show the column names in the Output window
        Next
    End Sub


    ' TextChanged event for txtname to search and show status
    Private Sub txtname_TextChanged(sender As Object, e As EventArgs)
        ' Trigger search when the name changes
        If txtname.Text <> "" Then
            Dim studentName As String = txtname.Text
            Dim failedCount As Integer = 0
            Dim atRisk As Boolean = False

            ' Query to count the number of failed subjects for the student
            cmd.Connection = conn
            cmd.CommandText = "SELECT * FROM grades WHERE NAME = @name"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@name", studentName)

            conn.Open()
            reader = cmd.ExecuteReader()

            While reader.Read()
                ' Check each grade and count the failed subjects (below 75)
                If reader("Programming") < 75 Then failedCount += 1
                If reader("Social Science") < 75 Then failedCount += 1
                If reader("HRO") < 75 Then failedCount += 1
                If reader("Filipino 11+") < 75 Then failedCount += 1
                If reader("MEDLIT") < 75 Then failedCount += 1
                If reader("Literature 1") < 75 Then failedCount += 1
                If reader("Literature 2") < 75 Then failedCount += 1
                If reader("Physical Education 3") < 75 Then failedCount += 1
                If reader("English 11+") < 75 Then failedCount += 1
            End While
            conn.Close()

            ' Set the txtfailed with the number of failed subjects
            txtfailed.Text = failedCount.ToString()

            ' Set the status based on failed subjects count
            If failedCount > 0 Then
                txtstatus.Text = "At-Risk"
                atRisk = True
            Else
                txtstatus.Text = "Passed"
            End If

            ' Insert or update the status table with the new information
            UpdateStatusTable(studentName, failedCount, atRisk)
        End If
    End Sub

    ' Method to update the status table
    Private Sub UpdateStatusTable(studentName As String, failedCount As Integer, atRisk As Boolean)
        ' Insert or update the status table with the student's status
        cmd.Connection = conn
        cmd.CommandText = "SELECT * FROM status WHERE NAME = @name"
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@name", studentName)

        conn.Open()
        reader = cmd.ExecuteReader()

        If reader.HasRows Then
            ' Update the status if the student already exists in the status table
            conn.Close()
            cmd.CommandText = "UPDATE status SET failedSubjects = @failedCount, atRiskStatus = @atRisk WHERE NAME = @name"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@failedCount", failedCount)
            cmd.Parameters.AddWithValue("@atRisk", If(atRisk, "At-Risk", "Passed"))
            cmd.Parameters.AddWithValue("@name", studentName)
        Else
            ' Insert new status for the student
            conn.Close()
            cmd.CommandText = "INSERT INTO status (NAME, failedSubjects, atRiskStatus) VALUES (@name, @failedCount, @atRisk)"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@name", studentName)
            cmd.Parameters.AddWithValue("@failedCount", failedCount)
            cmd.Parameters.AddWithValue("@atRisk", If(atRisk, "At-Risk", "Passed"))
        End If

        conn.Open()
        cmd.ExecuteNonQuery()
        conn.Close()
    End Sub

    ' Event for DataGridView cell click to display status in textboxes
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        ' Ensure a valid row is clicked
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

            ' Retrieve and display values in textboxes
            txtname.Text = selectedRow.Cells("NAME").Value.ToString()  ' Name (column name "NAME")
            txtfailed.Text = selectedRow.Cells("failedSubjects").Value.ToString() ' Failed Subjects (column name "failedSubjects")
            txtstatus.Text = selectedRow.Cells("atRiskStatus").Value.ToString() ' Status (column name "atRiskStatus")
        End If
    End Sub

    ' Event to save data when button is clicked
    ' Event to update and refresh all records when the button is clicked
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Query all student names
        cmd.Connection = conn
        cmd.CommandText = "SELECT NAME FROM student"
        Dim dt As New DataTable()

        Try
            conn.Open()
            dt.Load(cmd.ExecuteReader())
            conn.Close()

            ' Process each student's grades
            For Each row As DataRow In dt.Rows
                Dim studentName As String = row("NAME").ToString()
                Dim failedCount As Integer = 0
                Dim atRisk As Boolean = False

                ' Query grades for the student
                cmd.CommandText = "SELECT * FROM grades WHERE NAME = @name"
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@name", studentName)

                conn.Open()
                reader = cmd.ExecuteReader()

                While reader.Read()
                    ' Count failed subjects
                    If reader("Programming") < 75 Then failedCount += 1
                    If reader("Social Science") < 75 Then failedCount += 1
                    If reader("HRO") < 75 Then failedCount += 1
                    If reader("Filipino 11+") < 75 Then failedCount += 1
                    If reader("MEDLIT") < 75 Then failedCount += 1
                    If reader("Literature 1") < 75 Then failedCount += 1
                    If reader("Literature 2") < 75 Then failedCount += 1
                    If reader("Physical Education 3") < 75 Then failedCount += 1
                    If reader("English 11+") < 75 Then failedCount += 1
                End While
                conn.Close()

                ' Determine status
                atRisk = failedCount > 0

                ' Update the status table
                UpdateStatusTable(studentName, failedCount, atRisk)
            Next

            ' Reload the DataGridView
            LoadStatusData()
            MessageBox.Show("All records refreshed successfully!", "Refresh Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub


    ' Form Load Event
    Private Sub Form15_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load data into DataGridView when the form loads
        LoadStatusData()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form16.Show()
    End Sub


  Private Async Sub btnsend_Click(sender As Object, e As EventArgs) Handles btnsend.Click
        Dim link As String = "http://localhost/phpmailer/Emailforatrisk.php"
        Try
            Using client As New HttpClient()
                client.Timeout = TimeSpan.FromSeconds(30)
                Dim response As HttpResponseMessage = Await client.GetAsync(link)

                If response.IsSuccessStatusCode Then
                    MessageBox.Show("Emails sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Dim errorDetails As String = Await response.Content.ReadAsStringAsync()
                    MessageBox.Show("Failed to send emails. Status code: {response.StatusCode}. Details: {errorDetails}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
        Catch ex As HttpRequestException
            MessageBox.Show("HTTP Request failed: {ex.Message}", "Request Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As TaskCanceledException
            MessageBox.Show("Request timed out. Please try again later.", "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            MessageBox.Show("Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub





    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class