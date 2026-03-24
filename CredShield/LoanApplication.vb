Public Class LoanApplication
    ' Class to store consumer loan application details
    Public Property ApplicationId As String
    Public Property ConsumerName As String
    Public Property Email As String
    Public Property ContactNumber As String
    Public Property LoanType As String
    Public Property CompanyName As String
    Public Property LoanAmount As Decimal
    Public Property LoanTenure As Integer
    Public Property AnnualIncome As Decimal
    Public Property EmploymentStatus As String
    Public Property ApplicationDate As DateTime
    Public Property Status As String = "Pending"
    Public Property Notes As String

    Public Sub New()
        ApplicationId = "CSH-" & DateTime.Now.ToString("yyyyMMdd") & "-" & Guid.NewGuid().ToString().Substring(0, 6).ToUpper()
        ApplicationDate = DateTime.Now
    End Sub
End Class

Public Module ApplicationManager
    ' Global storage for all loan applications
    Public AllApplications As New List(Of LoanApplication)

    Public Sub AddApplication(app As LoanApplication)
        AllApplications.Add(app)
    End Sub

    Public Function GetAllApplications() As List(Of LoanApplication)
        Return AllApplications.OrderByDescending(Function(x) x.ApplicationDate).ToList()
    End Function

    Public Function GetApplicationsByStatus(status As String) As List(Of LoanApplication)
        Return AllApplications.Where(Function(x) x.Status = status).ToList()
    End Function

    Public Sub UpdateApplicationStatus(applicationId As String, newStatus As String)
        Dim app = AllApplications.FirstOrDefault(Function(x) x.ApplicationId = applicationId)
        If app IsNot Nothing Then
            app.Status = newStatus
        End If
    End Sub
End Module
