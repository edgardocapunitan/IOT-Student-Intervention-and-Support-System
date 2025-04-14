<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form11
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DELETETEACH = New System.Windows.Forms.Button()
        Me.TextBoxSelect1 = New System.Windows.Forms.TextBox()
        Me.TextBoxSelect2 = New System.Windows.Forms.TextBox()
        Me.TextBoxSelect3 = New System.Windows.Forms.TextBox()
        Me.TextBoxsearch = New System.Windows.Forms.TextBox()
        Me.Buttonsearch = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.updatebutton = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(350, 339)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(575, 180)
        Me.DataGridView1.TabIndex = 0
        '
        'DELETETEACH
        '
        Me.DELETETEACH.BackColor = System.Drawing.Color.Transparent
        Me.DELETETEACH.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DELETETEACH.Location = New System.Drawing.Point(636, 293)
        Me.DELETETEACH.Margin = New System.Windows.Forms.Padding(4)
        Me.DELETETEACH.Name = "DELETETEACH"
        Me.DELETETEACH.Size = New System.Drawing.Size(133, 40)
        Me.DELETETEACH.TabIndex = 75
        Me.DELETETEACH.Text = "DELETE"
        Me.DELETETEACH.UseVisualStyleBackColor = False
        '
        'TextBoxSelect1
        '
        Me.TextBoxSelect1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxSelect1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxSelect1.Location = New System.Drawing.Point(214, 198)
        Me.TextBoxSelect1.Name = "TextBoxSelect1"
        Me.TextBoxSelect1.Size = New System.Drawing.Size(272, 36)
        Me.TextBoxSelect1.TabIndex = 76
        '
        'TextBoxSelect2
        '
        Me.TextBoxSelect2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxSelect2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxSelect2.Location = New System.Drawing.Point(523, 198)
        Me.TextBoxSelect2.Name = "TextBoxSelect2"
        Me.TextBoxSelect2.Size = New System.Drawing.Size(272, 36)
        Me.TextBoxSelect2.TabIndex = 77
        '
        'TextBoxSelect3
        '
        Me.TextBoxSelect3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxSelect3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxSelect3.Location = New System.Drawing.Point(831, 198)
        Me.TextBoxSelect3.Name = "TextBoxSelect3"
        Me.TextBoxSelect3.Size = New System.Drawing.Size(272, 36)
        Me.TextBoxSelect3.TabIndex = 78
        '
        'TextBoxsearch
        '
        Me.TextBoxsearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxsearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxsearch.Location = New System.Drawing.Point(350, 300)
        Me.TextBoxsearch.Name = "TextBoxsearch"
        Me.TextBoxsearch.Size = New System.Drawing.Size(149, 30)
        Me.TextBoxsearch.TabIndex = 79
        '
        'Buttonsearch
        '
        Me.Buttonsearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Buttonsearch.Location = New System.Drawing.Point(505, 295)
        Me.Buttonsearch.Name = "Buttonsearch"
        Me.Buttonsearch.Size = New System.Drawing.Size(124, 38)
        Me.Buttonsearch.TabIndex = 80
        Me.Buttonsearch.Text = "SEARCH"
        Me.Buttonsearch.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label1.Location = New System.Drawing.Point(283, 152)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 29)
        Me.Label1.TabIndex = 81
        Me.Label1.Text = "Username"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label2.Location = New System.Drawing.Point(602, 152)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 29)
        Me.Label2.TabIndex = 82
        Me.Label2.Text = "Password"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label3.Location = New System.Drawing.Point(908, 152)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 29)
        Me.Label3.TabIndex = 83
        Me.Label3.Text = "Fullname"
        '
        'updatebutton
        '
        Me.updatebutton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.updatebutton.Location = New System.Drawing.Point(776, 293)
        Me.updatebutton.Name = "updatebutton"
        Me.updatebutton.Size = New System.Drawing.Size(127, 38)
        Me.updatebutton.TabIndex = 84
        Me.updatebutton.Text = "REFRESH"
        Me.updatebutton.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(1182, 34)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(109, 44)
        Me.Button1.TabIndex = 85
        Me.Button1.Text = "Back"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form11
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkRed
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1335, 630)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.updatebutton)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Buttonsearch)
        Me.Controls.Add(Me.TextBoxsearch)
        Me.Controls.Add(Me.TextBoxSelect3)
        Me.Controls.Add(Me.TextBoxSelect2)
        Me.Controls.Add(Me.TextBoxSelect1)
        Me.Controls.Add(Me.DELETETEACH)
        Me.Controls.Add(Me.DataGridView1)
        Me.DoubleBuffered = True
        Me.Name = "Form11"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Delete Teacher"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DELETETEACH As System.Windows.Forms.Button
    Friend WithEvents TextBoxSelect1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxSelect2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxSelect3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxsearch As System.Windows.Forms.TextBox
    Friend WithEvents Buttonsearch As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents updatebutton As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
