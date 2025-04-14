Imports MySql.Data.MySqlClient

Public Class Form1

    ' Define cutoff times for each day of the week
    Private Function GetCutOffTimeForDay(dayOfWeek As DayOfWeek) As TimeSpan
        Select Case dayOfWeek
            Case dayOfWeek.Tuesday, dayOfWeek.Thursday
                Return New TimeSpan(9, 15, 0) ' 7:44 AM cutoff for Monday, Tuesday, Thursday, Friday
            Case dayOfWeek.Friday
                Return New TimeSpan(10, 45, 0)
            Case dayOfWeek.Saturday
                Return New TimeSpan(7, 45, 0)
            
            Case Else
                Return New TimeSpan(23, 0, 0) ' Default for weekends (if applicable)
        End Select
    End Function

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                If TextBox1.Text = "" Then
                    MessageBox.Show("Please enter RFID", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    TextBox1.Clear()
                Else
                    ' Check if student exists in the student table
                    reloadtxt("SELECT * FROM finals.student WHERE RFID='" & TextBox1.Text & "'")
                    If dt.Rows.Count > 0 Then
                        ' Check if the student already timed in and timed out for today
                        reloadtxt("SELECT * FROM finals.attendance WHERE RFID='" & TextBox1.Text & "' AND DATE='" & LabelDate.Text & "' AND AM_STATUS='Time_In' AND PM_STATUS='Time_Out'")
                        If dt.Rows.Count > 0 Then
                            MessageBox.Show("You have already Time in and Time out for today", "Already", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            TextBox1.Clear()
                        Else
                            ' Determine if the entry is late
                            Dim isLate As Integer = 0
                            Dim currentTime As DateTime = DateTime.Now
                            Dim cutoffTime As TimeSpan = GetCutOffTimeForDay(currentTime.DayOfWeek) ' Get the cutoff time for today

                            ' Check if it's past the cutoff time for "late"
                            If currentTime.TimeOfDay > cutoffTime Then
                                isLate = 1 ' Mark as late
                            End If

                            ' Check if the student already timed in for the morning
                            reloadtxt("SELECT * FROM finals.attendance WHERE RFID='" & TextBox1.Text & "' AND DATE='" & LabelDate.Text & "' AND AM_STATUS='Time_In'")
                            If dt.Rows.Count > 0 Then
                                ' If already timed in for the morning, mark Time Out for PM without affecting late count
                                updatesLogged("UPDATE finals.attendance SET TIME_OUT='" & TimeOfDay & "', PM_STATUS='Time_Out' WHERE RFID ='" & TextBox1.Text & "' AND DATE ='" & LabelDate.Text & "'")
                            Else
                                ' Mark Time In for AM and evaluate lateness
                                If isLate = 1 Then
                                    ' Increment late count if late
                                    reloadtxt("SELECT LATE_COUNT, ABSENT FROM finals.student WHERE RFID='" & TextBox1.Text & "'")
                                    If dt.Rows.Count > 0 Then
                                        Dim lateCount As Integer = Convert.ToInt32(dt.Rows(0)("LATE_COUNT"))
                                        Dim absentCount As Integer = Convert.ToInt32(dt.Rows(0)("ABSENT"))

                                        ' Increment late count and handle multiple lates leading to absents
                                        lateCount += 1
                                        absentCount += lateCount \ 3
                                        lateCount = lateCount Mod 3  ' Reset late count if it reached a multiple of 3

                                        ' Update database
                                        updatesLogged("UPDATE finals.student SET LATE_COUNT='" & lateCount & "', ABSENT='" & absentCount & "' WHERE RFID='" & TextBox1.Text & "'")
                                    End If
                                End If
                                createlogged("INSERT INTO finals.attendance (RFID, DATE, TIME_IN, AM_STATUS, LATE_STATUS) VALUES('" & TextBox1.Text & "','" & LabelDate.Text & "','" & TimeOfDay & "','Time_In', '" & isLate & "')")
                            End If

                            ' Show Form2 and clear TextBox1 after successful entry
                            Me.Hide()
                            Form2.Show()
                            Form2.Text = TextBox1.Text
                            TextBox1.Clear()
                        End If
                    Else
                        MessageBox.Show("RFID not recognized", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        TextBox1.Clear()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub TimerDate_Tick(sender As Object, e As EventArgs) Handles TimerDate.Tick
        LabelDate.Text = DateTime.Now.ToString("yyyy/MM/dd")
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Me.Focus()
    End Sub

    Private Sub Trys()
        Throw New NotImplementedException
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form3.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form7.Show()
    End Sub
End Class
