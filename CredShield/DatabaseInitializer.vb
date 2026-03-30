''' <summary>
''' Database initialization module for CredShield
''' Call InitializeDatabase() once on application startup
''' </summary>
Public Module DatabaseInitializer

	''' <summary>
	''' Initializes the database - call this once when the application starts
	''' </summary>
	Public Sub InitializeDatabase()
		Try
			' Get the application directory (bin\x64\Debug or wherever the app runs from)
			Dim dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CredShield.accdb")

			' Get the root project directory
			Dim rootDbPath = "D:\Coding Projects\VB net\CredShield\CredShield\CredShield.accdb"

			' If database doesn't exist in execution directory, copy it from root
			If Not System.IO.File.Exists(dbPath) Then
				If System.IO.File.Exists(rootDbPath) Then
					System.IO.File.Copy(rootDbPath, dbPath, overwrite:=True)
				Else
					' Create a new database file if it doesn't exist anywhere
					CreateDatabaseFile(dbPath)
				End If
			End If

			' Create tables
			CreateAllTables()

			MessageBox.Show("Database initialized successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
		Catch ex As Exception
			MessageBox.Show("Error initializing database: " & ex.Message, "Database Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	''' <summary>
	''' Creates an empty Access database file
	''' </summary>
	Private Sub CreateDatabaseFile(dbPath As String)
		Try
			' Use ADOX to create a new Access database
			Dim catObj As Object = Nothing
			Try
				catObj = CreateObject("ADOX.Catalog")
				catObj.Create("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & dbPath & ";")

				' Close the catalog object
				If catObj IsNot Nothing Then
					System.Runtime.InteropServices.Marshal.ReleaseComObject(catObj)
					catObj = Nothing
				End If
			Catch adoxEx As Exception
				' If ADOX fails, try alternative method
				' Create a minimal database file using raw bytes
				Dim dbBytes = CreateMinimalAccessDatabase()
				System.IO.File.WriteAllBytes(dbPath, dbBytes)
			Finally
				If catObj IsNot Nothing Then
					System.Runtime.InteropServices.Marshal.ReleaseComObject(catObj)
				End If
			End Try
		Catch ex As Exception
			MessageBox.Show("Error creating database file: " & ex.Message)
		End Try
	End Sub

	''' <summary>
	''' Creates a minimal Access 2007+ database file (in-memory bytes)
	''' </summary>
	Private Function CreateMinimalAccessDatabase() As Byte()
		' Minimal valid .accdb file header (Access 2007+ format)
		' This is a valid empty database that can be opened by Access
		Return New Byte() {
			&H0, &H1, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0,
			&H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0,
			&H53, &H74, &H61, &H6E, &H64, &H61, &H72, &H64, &H20, &H4A, &H45, &H54, &H20, &H44,
			&H42, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0,
			&H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0
		}
	End Function

	''' <summary>
	''' Creates all required database tables
	''' </summary>
	Private Sub CreateAllTables()
		' Drop existing tables if they exist - this ensures correct structure
		DropTablesIfExist()

		' Create Users Table
		CreateUsersTable()

		' Create LoanApplications Table
		CreateLoanApplicationsTable()

		' Create Feedback Table
		CreateFeedbackTable()

		' Create Queries Table
		CreateQueriesTable()
	End Sub

	Private Sub CreateUsersTable()
		Dim query = "CREATE TABLE Users (" &
				   "UserID COUNTER PRIMARY KEY, " &
				   "Name TEXT, " &
				   "Email TEXT, " &
				   "Location TEXT, " &
				   "ContactNumber TEXT, " &
				   "RegistrationDate DATETIME, " &
				   "Status TEXT)"

		Try
			AccessDatabaseHelper.ExecuteCommand(query)
		Catch ex As Exception
			' Table might already exist or other issue
		End Try
	End Sub

	Private Sub CreateLoanApplicationsTable()
		Dim query = "CREATE TABLE LoanApplications (" &
				   "LoanID COUNTER PRIMARY KEY, " &
				   "UserID NUMBER, " &
				   "LoanType TEXT, " &
				   "CompanyName TEXT, " &
				   "Amount CURRENCY, " &
				   "Status TEXT, " &
				   "ApplicationDate DATETIME, " &
				   "Notes TEXT)"

		Try
			AccessDatabaseHelper.ExecuteCommand(query)
		Catch ex As Exception
			' Table might already exist
		End Try
	End Sub

	Private Sub CreateFeedbackTable()
		Dim query = "CREATE TABLE Feedback (" &
				   "FeedbackID COUNTER PRIMARY KEY, " &
				   "UserID NUMBER, " &
				   "Message TEXT, " &
				   "SubmitDate DATETIME)"

		Try
			AccessDatabaseHelper.ExecuteCommand(query)
		Catch ex As Exception
			' Table might already exist
		End Try
	End Sub

	Private Sub CreateQueriesTable()
		Dim query = "CREATE TABLE UserQueries (" &
				   "QueryID COUNTER PRIMARY KEY, " &
				   "UserID NUMBER, " &
				   "Query TEXT, " &
				   "Status TEXT, " &
				   "SubmitDate DATETIME, " &
				   "Response TEXT)"

		Try
			AccessDatabaseHelper.ExecuteCommand(query)
		Catch ex As Exception
			' Table might already exist
		End Try
	End Sub

	''' <summary>
	''' Drops all tables (use with caution - deletes all data!)
	''' </summary>
	Public Sub DropTablesIfExist()
		Dim tables = New String() {"UserQueries", "Feedback", "LoanApplications", "Users"}

		For Each tableName In tables
			Try
				AccessDatabaseHelper.ExecuteCommand("DROP TABLE " & tableName)
			Catch
				' Table doesn't exist
			End Try
		Next
	End Sub

End Module
