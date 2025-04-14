<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form20
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBoxRFID = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ButtonSearch = New System.Windows.Forms.Button()
        Me.Txtsearch = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.RichTextBox2 = New System.Windows.Forms.RichTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtname = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnsubmit = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Radiorem = New System.Windows.Forms.RadioButton()
        Me.Radioclass = New System.Windows.Forms.RadioButton()
        Me.Radioguidance = New System.Windows.Forms.RadioButton()
        Me.txtteach = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtsub = New System.Windows.Forms.TextBox()
        Me.RichTextBox3 = New System.Windows.Forms.RichTextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(484, 325)
        Me.Button1.Name = "Button1"
        Me.Button1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button1.Size = New System.Drawing.Size(164, 46)
        Me.Button1.TabIndex = 141
        Me.Button1.Text = "REFRESH"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'TextBoxRFID
        '
        Me.TextBoxRFID.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxRFID.Location = New System.Drawing.Point(148, 252)
        Me.TextBoxRFID.Name = "TextBoxRFID"
        Me.TextBoxRFID.Size = New System.Drawing.Size(297, 36)
        Me.TextBoxRFID.TabIndex = 140
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(41, 252)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 29)
        Me.Label8.TabIndex = 139
        Me.Label8.Text = "RFID :"
        '
        'ButtonSearch
        '
        Me.ButtonSearch.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ButtonSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSearch.Location = New System.Drawing.Point(299, 325)
        Me.ButtonSearch.Name = "ButtonSearch"
        Me.ButtonSearch.Size = New System.Drawing.Size(164, 46)
        Me.ButtonSearch.TabIndex = 138
        Me.ButtonSearch.Text = "SEARCH"
        Me.ButtonSearch.UseVisualStyleBackColor = False
        '
        'Txtsearch
        '
        Me.Txtsearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtsearch.Location = New System.Drawing.Point(36, 331)
        Me.Txtsearch.Name = "Txtsearch"
        Me.Txtsearch.Size = New System.Drawing.Size(257, 36)
        Me.Txtsearch.TabIndex = 137
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(1157, 31)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(116, 46)
        Me.Button3.TabIndex = 136
        Me.Button3.Text = "BACK"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Maroon
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(835, 108)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(259, 29)
        Me.Label7.TabIndex = 135
        Me.Label7.Text = "Cause of Intervention:"
        '
        'RichTextBox2
        '
        Me.RichTextBox2.Location = New System.Drawing.Point(726, 140)
        Me.RichTextBox2.Name = "RichTextBox2"
        Me.RichTextBox2.Size = New System.Drawing.Size(490, 182)
        Me.RichTextBox2.TabIndex = 134
        Me.RichTextBox2.Text = ""
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Maroon
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label6.Location = New System.Drawing.Point(736, 331)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(125, 29)
        Me.Label6.TabIndex = 133
        Me.Label6.Text = "Solutions:"
        '
        'txtname
        '
        Me.txtname.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtname.Location = New System.Drawing.Point(149, 198)
        Me.txtname.Name = "txtname"
        Me.txtname.Size = New System.Drawing.Size(296, 36)
        Me.txtname.TabIndex = 132
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 201)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 29)
        Me.Label5.TabIndex = 131
        Me.Label5.Text = "Student :"
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(46, 388)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(610, 237)
        Me.DataGridView1.TabIndex = 130
        '
        'btnsubmit
        '
        Me.btnsubmit.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsubmit.Location = New System.Drawing.Point(892, 577)
        Me.btnsubmit.Name = "btnsubmit"
        Me.btnsubmit.Size = New System.Drawing.Size(202, 48)
        Me.btnsubmit.TabIndex = 129
        Me.btnsubmit.Text = "Submit"
        Me.btnsubmit.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(726, 440)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(490, 131)
        Me.RichTextBox1.TabIndex = 128
        Me.RichTextBox1.Text = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Maroon
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label2.Location = New System.Drawing.Point(736, 409)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(180, 17)
        Me.Label2.TabIndex = 127
        Me.Label2.Text = "If other, Please specify:"
        '
        'Radiorem
        '
        Me.Radiorem.AutoSize = True
        Me.Radiorem.BackColor = System.Drawing.Color.Maroon
        Me.Radiorem.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radiorem.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Radiorem.Location = New System.Drawing.Point(1116, 368)
        Me.Radiorem.Name = "Radiorem"
        Me.Radiorem.Size = New System.Drawing.Size(100, 24)
        Me.Radiorem.TabIndex = 126
        Me.Radiorem.TabStop = True
        Me.Radiorem.Text = "Remedial"
        Me.Radiorem.UseVisualStyleBackColor = False
        '
        'Radioclass
        '
        Me.Radioclass.AutoSize = True
        Me.Radioclass.BackColor = System.Drawing.Color.Maroon
        Me.Radioclass.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radioclass.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Radioclass.Location = New System.Drawing.Point(957, 368)
        Me.Radioclass.Name = "Radioclass"
        Me.Radioclass.Size = New System.Drawing.Size(142, 24)
        Me.Radioclass.TabIndex = 125
        Me.Radioclass.TabStop = True
        Me.Radioclass.Text = "Make-up Class"
        Me.Radioclass.UseVisualStyleBackColor = False
        '
        'Radioguidance
        '
        Me.Radioguidance.AutoSize = True
        Me.Radioguidance.BackColor = System.Drawing.Color.Maroon
        Me.Radioguidance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radioguidance.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Radioguidance.Location = New System.Drawing.Point(739, 368)
        Me.Radioguidance.Name = "Radioguidance"
        Me.Radioguidance.Size = New System.Drawing.Size(199, 24)
        Me.Radioguidance.TabIndex = 124
        Me.Radioguidance.TabStop = True
        Me.Radioguidance.Text = "Guidance Consultation"
        Me.Radioguidance.UseVisualStyleBackColor = False
        '
        'txtteach
        '
        Me.txtteach.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtteach.Location = New System.Drawing.Point(149, 140)
        Me.txtteach.Name = "txtteach"
        Me.txtteach.Size = New System.Drawing.Size(296, 36)
        Me.txtteach.TabIndex = 123
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 140)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(128, 29)
        Me.Label4.TabIndex = 122
        Me.Label4.Text = "Teacher :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 29)
        Me.Label3.TabIndex = 121
        Me.Label3.Text = "Subject :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(476, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(365, 48)
        Me.Label1.TabIndex = 120
        Me.Label1.Text = "Intervention Form"
        '
        'txtsub
        '
        Me.txtsub.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsub.Location = New System.Drawing.Point(149, 79)
        Me.txtsub.Name = "txtsub"
        Me.txtsub.Size = New System.Drawing.Size(296, 36)
        Me.txtsub.TabIndex = 119
        '
        'RichTextBox3
        '
        Me.RichTextBox3.BackColor = System.Drawing.Color.Maroon
        Me.RichTextBox3.ForeColor = System.Drawing.Color.Turquoise
        Me.RichTextBox3.Location = New System.Drawing.Point(675, 82)
        Me.RichTextBox3.Name = "RichTextBox3"
        Me.RichTextBox3.Size = New System.Drawing.Size(591, 562)
        Me.RichTextBox3.TabIndex = 142
        Me.RichTextBox3.Text = ""
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(475, 181)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(181, 49)
        Me.Button2.TabIndex = 168
        Me.Button2.Text = "My Records"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Form20
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkRed
        Me.ClientSize = New System.Drawing.Size(1278, 655)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBoxRFID)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ButtonSearch)
        Me.Controls.Add(Me.Txtsearch)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.RichTextBox2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtname)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnsubmit)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Radiorem)
        Me.Controls.Add(Me.Radioclass)
        Me.Controls.Add(Me.Radioguidance)
        Me.Controls.Add(Me.txtteach)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtsub)
        Me.Controls.Add(Me.RichTextBox3)
        Me.Name = "Form20"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MR. LANDEZA"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBoxRFID As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ButtonSearch As System.Windows.Forms.Button
    Friend WithEvents Txtsearch As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents RichTextBox2 As System.Windows.Forms.RichTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtname As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnsubmit As System.Windows.Forms.Button
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Radiorem As System.Windows.Forms.RadioButton
    Friend WithEvents Radioclass As System.Windows.Forms.RadioButton
    Friend WithEvents Radioguidance As System.Windows.Forms.RadioButton
    Friend WithEvents txtteach As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtsub As System.Windows.Forms.TextBox
    Friend WithEvents RichTextBox3 As System.Windows.Forms.RichTextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
