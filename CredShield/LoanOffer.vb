Public Class LoanOffer
    ' Class to represent a loan offer from a company
    Public Property CompanyName As String
    Public Property CompanyId As String
    Public Property LoanType As String
    Public Property MinAmount As Decimal
    Public Property MaxAmount As Decimal
    Public Property InterestRateMin As Decimal
    Public Property InterestRateMax As Decimal
    Public Property TenureMin As Integer
    Public Property TenureMax As Integer
    Public Property ProcessingFee As Decimal
    Public Property ApprovalTime As String
    Public Property Features As List(Of String)
    Public Property Description As String
    Public Property Image As String
    Public Property Rating As Decimal
    Public Property ReviewCount As Integer

    Public Sub New()
        Features = New List(Of String)()
    End Sub

    Public Sub New(company As String, companyId As String, loanType As String, minAmt As Decimal, maxAmt As Decimal, _
                   intMin As Decimal, intMax As Decimal, tenMin As Integer, tenMax As Integer, fee As Decimal, _
                   approval As String, desc As String, rating As Decimal, reviews As Integer)
        Me.CompanyName = company
        Me.CompanyId = companyId
        Me.LoanType = loanType
        Me.MinAmount = minAmt
        Me.MaxAmount = maxAmt
        Me.InterestRateMin = CDec(intMin)
        Me.InterestRateMax = CDec(intMax)
        Me.TenureMin = tenMin
        Me.TenureMax = tenMax
        Me.ProcessingFee = CDec(fee)
        Me.ApprovalTime = approval
        Me.Description = desc
        Me.Rating = CDec(rating)
        Me.ReviewCount = reviews
        Me.Features = New List(Of String)()
    End Sub
End Class
