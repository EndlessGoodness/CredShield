Imports System.Data.OleDb

Public Class DatabaseConnection
    ' MS ACCESS Database Connection Helper
    Private Shared connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|CredShield.accdb;"

    Public Shared Function GetConnection() As OleDbConnection
        Return New OleDbConnection(connectionString)
    End Function

    ' CREATE TABLES IF THEY DON'T EXIST
    Public Shared Sub InitializeDatabase()
        Try
            Using connection = GetConnection()
                connection.Open()

                ' Create Users Table
                Dim userTableQuery = "CREATE TABLE Users (UserID AutoIncrement PRIMARY KEY, Name Text, Email Text, Location Text, ContactNumber Text, RegistrationDate DateTime, Status Text)"
                ExecuteQuery(userTableQuery, connection)

                ' Create Loan Applications Table
                Dim loanTableQuery = "CREATE TABLE LoanApplications (LoanID AutoIncrement PRIMARY KEY, UserID Number, LoanType Text, CompanyName Text, Amount Currency, Status Text, ApplicationDate DateTime, Notes Text)"
                ExecuteQuery(loanTableQuery, connection)

                ' Create Feedback Table
                Dim feedbackTableQuery = "CREATE TABLE Feedback (FeedbackID AutoIncrement PRIMARY KEY, UserID Number, Message Text, SubmitDate DateTime)"
                ExecuteQuery(feedbackTableQuery, connection)

                ' Create Queries Table
                Dim queriesTableQuery = "CREATE TABLE UserQueries (QueryID AutoIncrement PRIMARY KEY, UserID Number, Query Text, Status Text, SubmitDate DateTime, Response Text)"
                ExecuteQuery(queriesTableQuery, connection)

                connection.Close()
            End Using
        Catch ex As Exception
            ' Table might already exist - that's fine
        End Try
    End Sub

    Private Shared Sub ExecuteQuery(query As String, connection As OleDbConnection)
        Try
            Using command = New OleDbCommand(query, connection)
                command.ExecuteNonQuery()
            End Using
        Catch
            ' Ignore errors (tables might exist)
        End Try
    End Sub

    ' INSERT USER
    Public Shared Function InsertUser(name As String, email As String, location As String, contact As String) As Integer
        Try
            Using connection = GetConnection()
                connection.Open()
                Dim query = "INSERT INTO Users (Name, Email, Location, ContactNumber, RegistrationDate, Status) VALUES (@name, @email, @location, @contact, @date, 'Active')"
                Using command = New OleDbCommand(query, connection)
                    command.Parameters.AddWithValue("@name", name)
                    command.Parameters.AddWithValue("@email", email)
                    command.Parameters.AddWithValue("@location", location)
                    command.Parameters.AddWithValue("@contact", contact)
                    command.Parameters.AddWithValue("@date", DateTime.Now)
                    command.ExecuteNonQuery()
                End Using
                connection.Close()
                Return GetUserIDByEmail(email)
            End Using
        Catch ex As Exception
            MessageBox.Show("Error inserting user: " & ex.Message)
            Return -1
        End Try
    End Function

    ' GET USER ID BY EMAIL
    Public Shared Function GetUserIDByEmail(email As String) As Integer
        Try
            Using connection = GetConnection()
                connection.Open()
                Dim query = "SELECT UserID FROM Users WHERE Email = @email"
                Using command = New OleDbCommand(query, connection)
                    command.Parameters.AddWithValue("@email", email)
                    Dim result = command.ExecuteScalar()
                    If result IsNot Nothing Then
                        Return CInt(result)
                    End If
                End Using
                connection.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
        Return -1
    End Function

    ' CHECK IF EMAIL EXISTS
    Public Shared Function EmailExists(email As String) As Boolean
        Try
            Using connection = GetConnection()
                connection.Open()
                Dim query = "SELECT COUNT(*) FROM Users WHERE Email = @email"
                Using command = New OleDbCommand(query, connection)
                    command.Parameters.AddWithValue("@email", email)
                    Dim count = CInt(command.ExecuteScalar())
                    connection.Close()
                    Return count > 0
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    ' INSERT LOAN APPLICATION
    Public Shared Sub InsertLoanApplication(userId As Integer, loanType As String, companyName As String, amount As Decimal)
        Try
            Using connection = GetConnection()
                connection.Open()
                Dim query = "INSERT INTO LoanApplications (UserID, LoanType, CompanyName, Amount, Status, ApplicationDate) VALUES (@userId, @loanType, @company, @amount, 'Pending', @date)"
                Using command = New OleDbCommand(query, connection)
                    command.Parameters.AddWithValue("@userId", userId)
                    command.Parameters.AddWithValue("@loanType", loanType)
                    command.Parameters.AddWithValue("@company", companyName)
                    command.Parameters.AddWithValue("@amount", amount)
                    command.Parameters.AddWithValue("@date", DateTime.Now)
                    command.ExecuteNonQuery()
                End Using
                connection.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error inserting loan: " & ex.Message)
        End Try
    End Sub

    ' INSERT FEEDBACK
    Public Shared Sub InsertFeedback(userId As Integer, message As String)
        Try
            Using connection = GetConnection()
                connection.Open()
                Dim query = "INSERT INTO Feedback (UserID, Message, SubmitDate) VALUES (@userId, @message, @date)"
                Using command = New OleDbCommand(query, connection)
                    command.Parameters.AddWithValue("@userId", userId)
                    command.Parameters.AddWithValue("@message", message)
                    command.Parameters.AddWithValue("@date", DateTime.Now)
                    command.ExecuteNonQuery()
                End Using
                connection.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error inserting feedback: " & ex.Message)
        End Try
    End Sub

    ' INSERT QUERY
    Public Shared Sub InsertQuery(userId As Integer, query As String)
        Try
            Using connection = GetConnection()
                connection.Open()
                Dim sql = "INSERT INTO UserQueries (UserID, Query, Status, SubmitDate) VALUES (@userId, @query, 'Pending', @date)"
                Using command = New OleDbCommand(sql, connection)
                    command.Parameters.AddWithValue("@userId", userId)
                    command.Parameters.AddWithValue("@query", query)
                    command.Parameters.AddWithValue("@date", DateTime.Now)
                    command.ExecuteNonQuery()
                End Using
                connection.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error inserting query: " & ex.Message)
        End Try
    End Sub

    ' GET ALL USERS
    Public Shared Function GetAllUsers() As DataTable
        Try
            Using connection = GetConnection()
                connection.Open()
                Dim query = "SELECT * FROM Users ORDER BY RegistrationDate DESC"
                Dim adapter = New OleDbDataAdapter(query, connection)
                Dim dt = New DataTable()
                adapter.Fill(dt)
                connection.Close()
                Return dt
            End Using
        Catch ex As Exception
            MessageBox.Show("Error retrieving users: " & ex.Message)
            Return New DataTable()
        End Try
    End Function

    ' GET ALL FEEDBACK
    Public Shared Function GetAllFeedback() As DataTable
        Try
            Using connection = GetConnection()
                connection.Open()
                Dim query = "SELECT F.FeedbackID, U.Name, F.Message, F.SubmitDate FROM Feedback F INNER JOIN Users U ON F.UserID = U.UserID ORDER BY F.SubmitDate DESC"
                Dim adapter = New OleDbDataAdapter(query, connection)
                Dim dt = New DataTable()
                adapter.Fill(dt)
                connection.Close()
                Return dt
            End Using
        Catch ex As Exception
            Return New DataTable()
        End Try
    End Function

    ' GET ALL QUERIES
    Public Shared Function GetAllQueries() As DataTable
        Try
            Using connection = GetConnection()
                connection.Open()
                Dim query = "SELECT Q.QueryID, U.Name, Q.Query, Q.Status, Q.SubmitDate FROM UserQueries Q INNER JOIN Users U ON Q.UserID = U.UserID ORDER BY Q.SubmitDate DESC"
                Dim adapter = New OleDbDataAdapter(query, connection)
                Dim dt = New DataTable()
                adapter.Fill(dt)
                connection.Close()
                Return dt
            End Using
        Catch ex As Exception
            Return New DataTable()
        End Try
    End Function

    ' GET USER LOANS
    Public Shared Function GetUserLoans(userId As Integer) As DataTable
        Try
            Using connection = GetConnection()
                connection.Open()
                Dim query = "SELECT * FROM LoanApplications WHERE UserID = @userId ORDER BY ApplicationDate DESC"
                Dim adapter = New OleDbDataAdapter(query, connection)
                adapter.SelectCommand.Parameters.AddWithValue("@userId", userId)
                Dim dt = New DataTable()
                adapter.Fill(dt)
                connection.Close()
                Return dt
            End Using
        Catch ex As Exception
            Return New DataTable()
        End Try
    End Function

    ' GET LOAN STATISTICS
    Public Shared Function GetLoanStatistics() As Dictionary(Of String, Integer)
        Dim stats = New Dictionary(Of String, Integer)
        Try
            Using connection = GetConnection()
                connection.Open()
                
                ' Count by status
                Dim query = "SELECT Status, COUNT(*) as Count FROM LoanApplications GROUP BY Status"
                Using command = New OleDbCommand(query, connection)
                    Using reader = command.ExecuteReader()
                        While reader.Read()
                            Dim status = reader("Status").ToString()
                            Dim count = CInt(reader("Count"))
                            stats(status) = count
                        End While
                    End Using
                End Using
                
                connection.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error getting statistics: " & ex.Message)
        End Try
        Return stats
    End Function
End Class
