Imports MySql.Data.MySqlClient

Public Class Form2
    Dim now As DateTime = Date.Now
    Private countdownValue As Integer = 2

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        student()
        Label5.Text = now.Hour.ToString()
        Label7.Text = now.Minute.ToString()
        Label11.Text = countdownValue.ToString()
        Timer1.Interval = 2500
        Timer1.Start()
        CheckStudentStatus()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label11.Text = (CInt(Label11.Text) - 1).ToString()
        If Label11.Text = "0" Then
            Timer1.Stop()
            Form1.Show()
            Me.Close()
        End If
    End Sub

    Private Sub Form2_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged
        If String.IsNullOrEmpty(Me.Text) Then Exit Sub

        Try
            Using conn As New MySqlConnection("Server=localhost;Database=finals;Uid=root;Pwd=;")
                conn.Open()
                Dim cmd As New MySqlCommand("SELECT * FROM finals.student WHERE `RFID`=@RFID", conn)
                cmd.Parameters.Add("@RFID", MySqlDbType.VarChar).Value = Me.Text
                Dim dr As MySqlDataReader = cmd.ExecuteReader()
                If dr.Read() Then
                    Label9.Text = dr("NAME").ToString()
                    Label2.Text = dr("NUMBER").ToString()
                    Label14.Text = dr("YEAR_AND_COURSE").ToString()
                End If
                dr.Close()
            End Using
            CheckStudentStatus()

        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub student()
        Try
            Using conn As New MySqlConnection("Server=localhost;Database=finals;Uid=root;Pwd=;")
                conn.Open()
                Dim cmd As New MySqlCommand("SELECT * FROM finals.student", conn)
                Dim da As New MySqlDataAdapter(cmd)
                Dim ds As New DataSet()
                da.Fill(ds, "student")
                DataGridView1.DataSource = ds.Tables("student")
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading students: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

   Private Sub CheckStudentStatus()
        Try
            Using conn As New MySqlConnection("Server=localhost;Database=finals;Uid=root;Pwd=;")
                conn.Open()

                ' Check Grades
                Dim cmdGrades As New MySqlCommand("SELECT Programming, `Social Science`, `HRO`, `Filipino 11+`, `MEDLIT`, `Literature 1`, `Physical Education 3`, `English 11+` FROM finals.grades WHERE `NAME` = @NAME", conn)
                cmdGrades.Parameters.AddWithValue("@NAME", Label9.Text)
                Using drGrades As MySqlDataReader = cmdGrades.ExecuteReader()
                    If drGrades.Read() Then
                        Dim allGradesComplete As Boolean = True
                        Dim hasFailingGrade As Boolean = False

                        For i As Integer = 0 To drGrades.FieldCount - 1
                            If drGrades.IsDBNull(i) OrElse drGrades.GetDouble(i) = 0 Then
                                allGradesComplete = False
                                Exit For
                            ElseIf drGrades.GetDouble(i) < 75 Then
                                hasFailingGrade = True
                            End If
                        Next

                        If Not allGradesComplete Then
                            lblstatus.Text = "Grades Not Complete"
                            lblstatus.ForeColor = Color.Orange
                        ElseIf hasFailingGrade Then
                            lblstatus.Text = "Status: At-Risk"
                            lblstatus.ForeColor = Color.Red
                        Else
                            lblstatus.Text = "Passed"
                            lblstatus.ForeColor = Color.Green
                        End If
                    Else
                        lblstatus.Text = "Grades Not Complete"
                        lblstatus.ForeColor = Color.Orange
                    End If
                    If DataGridView1.Columns.Contains("LOGS") Then
                        DataGridView1.Columns("LOGS").Visible = False
                    End If
                End Using ' Ensures the DataReader is closed here

                ' Check Attendance
                Dim cmdAttendance As New MySqlCommand("SELECT ABSENT FROM finals.student WHERE NAME = @NAME", conn)
                cmdAttendance.Parameters.AddWithValue("@NAME", Label9.Text)
                Using drAttendance As MySqlDataReader = cmdAttendance.ExecuteReader()
                    If drAttendance.Read() Then
                        Dim absences As Integer = Convert.ToInt32(drAttendance("ABSENT"))
                        If absences < 3 Then
                            lblAttendanceStatus.Text = "Attendance: Good"
                            lblAttendanceStatus.ForeColor = Color.Green
                        Else
                            lblAttendanceStatus.Text = "Attendance: At-Risk"
                            lblAttendanceStatus.ForeColor = Color.Red
                        End If
                    Else
                        lblAttendanceStatus.Text = "Attendance: Data Not Available"
                        lblAttendanceStatus.ForeColor = Color.Orange
                    End If
                End Using ' Ensures the DataReader is closed here

            End Using ' Ensures the connection is closed here
        Catch ex As Exception
            MessageBox.Show("Error checking student status: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub






    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Label8.Text = DateTime.Now.ToString("yyyy/M/dd")
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
    End Sub

    Private Sub lblstatus_Click(sender As Object, e As EventArgs) Handles lblstatus.Click
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub
End Class
