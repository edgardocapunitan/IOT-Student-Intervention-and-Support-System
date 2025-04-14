
Namespace ExcelInterop
    Class Worksheet

        Private _cells As String

        Property Cells(row As Integer, col As Integer) As String
            Get
                Return _cells
            End Get
            Set(value As String)
                _cells = value
            End Set
        End Property

    End Class
End Namespace
