Module Program
    Sub Main()
        Application.EnableVisualStyles()

        ' Set DataDirectory for |DataDirectory| placeholder in connection strings
        Dim dataDirectory = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data")
        If Not System.IO.Directory.Exists(dataDirectory) Then
            System.IO.Directory.CreateDirectory(dataDirectory)
        End If
        AppDomain.CurrentDomain.SetData("DataDirectory", dataDirectory)

        ' Initialize database tables on startup
        DatabaseConnection.InitializeDatabase()
        Application.Run(New FormNewHome())
    End Sub
End Module
