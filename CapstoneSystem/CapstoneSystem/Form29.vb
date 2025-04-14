
Imports MySql.Data.MySqlClient
Imports PdfSharp.Pdf
Imports PdfSharp.Drawing
Imports System.IO
Imports PdfSharp

Public Class Form29
    ' Database connection string
    Private connectionString As String = "server=localhost;user id=root;password=;database=finals"

    ' Variable to store the selected record's ID
    Private selectedInterventionId As Integer = -1

    ' Method to load data into DataGridView
    ' Method to load and optionally filter data by date range
    Private Sub LoadStudentData(Optional fromDate As DateTime? = Nothing, Optional toDate As DateTime? = Nothing)
        Try
            ' Create a connection and open it
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                ' Base SQL query to fetch data
                Dim query As String = "SELECT * FROM intervention WHERE teacher = @teacher"
                Dim whereClauses As New List(Of String)

                ' Add date filtering if dates are provided
                If fromDate.HasValue Then
                    whereClauses.Add("dateofcompletion >= @fromDate")
                End If
                If toDate.HasValue Then
                    whereClauses.Add("dateofcompletion <= @toDate")
                End If

                ' Combine with additional filtering
                If whereClauses.Count > 0 Then
                    query &= " AND " & String.Join(" AND ", whereClauses)
                End If

                Using cmd As New MySqlCommand(query, conn)
                    ' Add parameters for filtering
                    cmd.Parameters.AddWithValue("@teacher", "Ms. Cruz") ' Filter for Ms. Bacoy
                    If fromDate.HasValue Then
                        cmd.Parameters.AddWithValue("@fromDate", fromDate.Value)
                    End If
                    If toDate.HasValue Then
                        cmd.Parameters.AddWithValue("@toDate", toDate.Value)
                    End If

                    Dim da As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)

                    ' Bind the DataTable to the DataGridView
                    DataGridView1.DataSource = dt

                    ' Hide the "id" column if it exists
                    If DataGridView1.Columns.Contains("id") Then
                        DataGridView1.Columns("id").Visible = False
                    End If

                    ' Optional: Auto-size columns for better display
                    DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                End Using
            End Using
        Catch ex As Exception
            ' Show error if loading fails
            MessageBox.Show("Error loading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub




    ' Form Load Event
    Private Sub Form17_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Call the method to load data into the DataGridView
        LoadStudentData()
    End Sub

    ' DataGridView CellContentClick Event to Populate TextBox and Store Record ID
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        DataGridView1.ReadOnly = True

        Try
            ' Ensure a valid row is clicked
            If e.RowIndex >= 0 Then
                Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

                ' Populate the txtsear textbox (for intervention status)
                txtsear.Text = selectedRow.Cells("studentname").Value.ToString() ' If you want to use any other column from DataGridView

                ' Get the intervention ID from the selected row
                If selectedRow.Cells("id").Value IsNot DBNull.Value Then
                    selectedInterventionId = Convert.ToInt32(selectedRow.Cells("id").Value)
                End If
            End If
        Catch ex As Exception
            ' Handle any errors during cell click
            MessageBox.Show("Error selecting data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Button Click Event to Update the Selected Data
    Private Sub Buttoncomplete_Click(sender As Object, e As EventArgs) Handles Buttoncomplete.Click
        ' Validate that a valid row is selected
        If selectedInterventionId = -1 Then
            MessageBox.Show("Please select a record to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Show a confirmation message to the user
        Dim dialogResult As DialogResult = MessageBox.Show("Are you sure you want to complete the intervention for this student?",
                                                           "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        ' Check if the user selected "No"
        If dialogResult = dialogResult.No Then
            ' Exit the method without updating the database
            Return
        End If

        ' Validate input for intervention status
        Dim interventionStatus As String = "Completed"

        Try
            ' Update the selected record in the database
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                ' SQL query to update the intervention date and status for the selected record
                Dim query As String = "UPDATE intervention SET dateofcompletion = @date, interventionstatus = @interventionstatus WHERE id = @id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@date", DateTime.Now) ' Current date and time
                    cmd.Parameters.AddWithValue("@interventionstatus", interventionStatus) ' The fixed "Completed" status
                    cmd.Parameters.AddWithValue("@id", selectedInterventionId) ' Update the specific record by ID
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            ' Inform the user about the successful update
            MessageBox.Show("Intervention details successfully updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Refresh the DataGridView and clear fields after submission
            LoadStudentData()
            txtsear.Clear() ' Optional: Clear txtsear if necessary
        Catch ex As Exception
            ' Handle any database errors
            MessageBox.Show("Error updating data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form16.Show()
    End Sub


    Private Sub btnsend_Click(sender As Object, e As EventArgs) Handles btnsend.Click
        ' Get the search query from the txtSearch TextBox
        Dim searchQuery As String = txtsear.Text.Trim()

        ' Call the LoadStudentData method with the search query to filter results
        LoadStudentData(searchQuery)
    End Sub

    Private Sub txtsear_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsear.KeyDown
        ' Check if the pressed key is Enter
        If e.KeyCode = Keys.Enter Then
            ' Get the search query from the txtsear TextBox
            Dim searchQuery As String = txtsear.Text.Trim()

            ' Call the LoadStudentData method with the search query to filter results
            LoadStudentData(searchQuery)

            ' Optional: Suppress the beep sound on Enter key press
            e.SuppressKeyPress = True
        End If
    End Sub


    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        txtsear.Clear()

        ' Reload all data in the DataGridView
        LoadStudentData()

        ' Notify the user (optional)
        MessageBox.Show("Data refreshed successfully!", "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        ' Get the selected dates from the DateTimePicker controls
        Dim fromDate As DateTime = dtpFrom.Value.Date
        Dim toDate As DateTime = dtpTo.Value.Date

        ' Ensure the "From" date is not greater than the "To" date
        If fromDate > toDate Then
            MessageBox.Show("The 'From' date cannot be later than the 'To' date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Call LoadStudentData with the specified date range
        LoadStudentData(fromDate, toDate)
    End Sub



    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        ' Reload all data without date filtering
        LoadStudentData()
    End Sub


    Private Sub dtpTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpTo.ValueChanged

    End Sub



    Private Sub btnExportToPDF_Click(sender As Object, e As EventArgs) Handles btnExporttoPDF.Click
        ' Choose a file path to save the PDF
        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf"
        saveFileDialog.Title = "Save PDF File"
        saveFileDialog.FileName = "InterventionRecords.pdf"

        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            Dim filePath As String = saveFileDialog.FileName

            Try
                ' Create a new PDF document
                Dim pdfDoc As New PdfDocument()
                pdfDoc.Info.Title = "Intervention Records"

                ' Create an XGraphics object for drawing in landscape orientation
                Dim page As PdfPage = pdfDoc.AddPage()
                page.Orientation = PageOrientation.Landscape ' Set page orientation to Landscape
                Dim gfx As XGraphics = XGraphics.FromPdfPage(page)

                ' Set a font for the document
                Dim titleFont As New XFont("Times New Roman", 16, XFontStyle.Bold)
                Dim headerFont As New XFont("Times New Roman", 12, XFontStyle.Bold)
                Dim rowFont As New XFont("Times New Roman", 12, XFontStyle.Regular)

                ' Set margins and start position for the content
                Dim marginLeft As Double = 40
                Dim marginTop As Double = 40
                Dim columnSpacing As Double = 120
                Dim y As Double = marginTop

                ' Add title to the document
                gfx.DrawString("Intervention Records", titleFont, XBrushes.Black, New XPoint(marginLeft, y))
                y += 30 ' Move the y position down after the title

                ' Add column headers
                For Each column As DataGridViewColumn In DataGridView1.Columns
                    gfx.DrawString(column.HeaderText, headerFont, XBrushes.Black, New XPoint(marginLeft, y))
                    marginLeft += columnSpacing ' Space out the columns
                Next
                y += 20 ' Add some space after the headers

                ' Reset marginLeft for the data rows
                marginLeft = 40

                ' Add rows from DataGridView
                For Each row As DataGridViewRow In DataGridView1.Rows
                    If Not row.IsNewRow Then
                        For Each cell As DataGridViewCell In row.Cells
                            ' Add cell value
                            gfx.DrawString(cell.Value.ToString(), rowFont, XBrushes.Black, New XPoint(marginLeft, y))
                            marginLeft += columnSpacing ' Space out the columns
                        Next
                        y += 20 ' Add some space after each row
                        marginLeft = 40 ' Reset for next row
                    End If
                Next

                ' Save the PDF to the selected file path
                pdfDoc.Save(filePath)

                ' Notify the user
                MessageBox.Show("PDF generated successfully at: " & filePath, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("Error generating PDF: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

End Class


