Imports System.Xml

Module Module2
    Sub Main()
        Dim xmlFile As String = "C:\Users\EDUARDO\Desktop\CapstoneSystem\TextFile1.xml"

        ' Load the XML file
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(xmlFile)

        ' Print the XML content to the console
        Console.WriteLine(xmlDoc.OuterXml)
    End Sub
End Module
