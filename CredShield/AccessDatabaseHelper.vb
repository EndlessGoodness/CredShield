Imports System.Data.OleDb
Imports System.Configuration

''' <summary>
''' Helper class for managing MS Access database operations
''' Provides methods for executing queries and commands against an MS Access database
''' </summary>
Public Class AccessDatabaseHelper
	Private Shared ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("AccessDatabase").ConnectionString

	''' <summary>
	''' Gets the connection string from App.config
	''' </summary>
	Public Shared Function GetConnectionString() As String
		Return connectionString
	End Function

	''' <summary>
	''' Executes a SELECT query and returns results as a DataTable
	''' </summary>
	Public Shared Function GetData(query As String) As DataTable
		Try
			Using connection As New OleDbConnection(connectionString)
				Using adapter As New OleDbDataAdapter(query, connection)
					Dim table As New DataTable()
					adapter.Fill(table)
					Return table
				End Using
			End Using
		Catch ex As Exception
			MessageBox.Show("Error retrieving data: " & ex.Message)
			Return New DataTable()
		End Try
	End Function

	''' <summary>
	''' Executes a SELECT query with parameters
	''' </summary>
	Public Shared Function GetDataWithParameters(query As String, parameters As OleDbParameter()) As DataTable
		Try
			Using connection As New OleDbConnection(connectionString)
				Using command As New OleDbCommand(query, connection)
					If parameters IsNot Nothing Then
						command.Parameters.AddRange(parameters)
					End If
					Using adapter As New OleDbDataAdapter(command)
						Dim table As New DataTable()
						adapter.Fill(table)
						Return table
					End Using
				End Using
			End Using
		Catch ex As Exception
			MessageBox.Show("Error retrieving data: " & ex.Message)
			Return New DataTable()
		End Try
	End Function

	''' <summary>
	''' Executes an INSERT, UPDATE, or DELETE command
	''' </summary>
	Public Shared Function ExecuteCommand(query As String) As Integer
		Try
			Using connection As New OleDbConnection(connectionString)
				Using command As New OleDbCommand(query, connection)
					connection.Open()
					Return command.ExecuteNonQuery()
				End Using
			End Using
		Catch ex As Exception
			MessageBox.Show("Error executing command: " & ex.Message)
			Return -1
		End Try
	End Function

	''' <summary>
	''' Executes a command with parameters (INSERT, UPDATE, DELETE)
	''' </summary>
	Public Shared Function ExecuteCommandWithParameters(query As String, parameters As OleDbParameter()) As Integer
		Try
			Using connection As New OleDbConnection(connectionString)
				Using command As New OleDbCommand(query, connection)
					If parameters IsNot Nothing Then
						command.Parameters.AddRange(parameters)
					End If
					connection.Open()
					Return command.ExecuteNonQuery()
				End Using
			End Using
		Catch ex As Exception
			MessageBox.Show("Error executing command: " & ex.Message)
			Return -1
		End Try
	End Function

	''' <summary>
	''' Executes a query that returns a scalar value
	''' </summary>
	Public Shared Function ExecuteScalar(query As String) As Object
		Try
			Using connection As New OleDbConnection(connectionString)
				Using command As New OleDbCommand(query, connection)
					connection.Open()
					Return command.ExecuteScalar()
				End Using
			End Using
		Catch ex As Exception
			MessageBox.Show("Error executing scalar query: " & ex.Message)
			Return Nothing
		End Try
	End Function

	''' <summary>
	''' Executes a scalar query with parameters
	''' </summary>
	Public Shared Function ExecuteScalarWithParameters(query As String, parameters As OleDbParameter()) As Object
		Try
			Using connection As New OleDbConnection(connectionString)
				Using command As New OleDbCommand(query, connection)
					If parameters IsNot Nothing Then
						command.Parameters.AddRange(parameters)
					End If
					connection.Open()
					Return command.ExecuteScalar()
				End Using
			End Using
		Catch ex As Exception
			MessageBox.Show("Error executing scalar query: " & ex.Message)
			Return Nothing
		End Try
	End Function

	''' <summary>
	''' Tests the database connection
	''' </summary>
	Public Shared Function TestConnection() As Boolean
		Try
			Using connection As New OleDbConnection(connectionString)
				connection.Open()
				connection.Close()
				Return True
			End Using
		Catch ex As Exception
			MessageBox.Show("Connection test failed: " & ex.Message)
			Return False
		End Try
	End Function

	''' <summary>
	''' Creates the database tables if they don't exist
	''' </summary>
	Public Shared Sub InitializeDatabaseTables()
		Try
			' Create Users Table
			Dim createUsersTable = "CREATE TABLE Users (" &
									   "UserID AUTOINCREMENT PRIMARY KEY, " &
									   "Name TEXT(100), " &
									   "Email TEXT(100) UNIQUE, " &
									   "Location TEXT(100), " &
									   "ContactNumber TEXT(20), " &
									   "RegistrationDate DATETIME, " &
									   "Status TEXT(20))"
			ExecuteCommand(createUsersTable)

			' Create Loan Applications Table
			Dim createLoansTable = "CREATE TABLE LoanApplications (" &
									   "LoanID AUTOINCREMENT PRIMARY KEY, " &
									   "UserID INTEGER, " &
									   "LoanType TEXT(50), " &
									   "CompanyName TEXT(100), " &
									   "Amount CURRENCY, " &
									   "Status TEXT(20), " &
									   "ApplicationDate DATETIME, " &
									   "FOREIGN KEY (UserID) REFERENCES Users(UserID))"
			ExecuteCommand(createLoansTable)

			' Create Feedback Table
			Dim createFeedbackTable = "CREATE TABLE Feedback (" &
										  "FeedbackID AUTOINCREMENT PRIMARY KEY, " &
										  "UserID INTEGER, " &
										  "Message TEXT, " &
										  "SubmittedDate DATETIME, " &
										  "FOREIGN KEY (UserID) REFERENCES Users(UserID))"
			ExecuteCommand(createFeedbackTable)

			' Create Queries Table
			Dim createQueriesTable = "CREATE TABLE Queries (" &
										 "QueryID AUTOINCREMENT PRIMARY KEY, " &
										 "UserID INTEGER, " &
										 "Query TEXT, " &
										 "SubmittedDate DATETIME, " &
										 "FOREIGN KEY (UserID) REFERENCES Users(UserID))"
			ExecuteCommand(createQueriesTable)

			MessageBox.Show("Database tables created successfully!")
		Catch ex As Exception
			' Tables might already exist, which is fine
			' MessageBox.Show("Note: " & ex.Message)
		End Try
	End Sub
End Class
