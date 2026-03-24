Public Module WishlistManager
    ' Global wishlist management for the application
    Public WishlistItems As New List(Of WishlistItem)

    Public Class WishlistItem
        Public Property LoanOfferId As String
        Public Property CompanyName As String
        Public Property LoanType As String
        Public Property InterestRateMin As Decimal
        Public Property InterestRateMax As Decimal
        Public Property MinAmount As Decimal
        Public Property MaxAmount As Decimal
        Public Property AddedDate As DateTime
        Public Property Rating As Decimal

        Public Sub New()
        End Sub

        Public Sub New(offerId As String, company As String, loanType As String, intMin As Decimal, _
                       intMax As Decimal, minAmt As Decimal, maxAmt As Decimal, rating As Decimal)
            Me.LoanOfferId = offerId
            Me.CompanyName = company
            Me.LoanType = loanType
            Me.InterestRateMin = intMin
            Me.InterestRateMax = intMax
            Me.MinAmount = minAmt
            Me.MaxAmount = maxAmt
            Me.AddedDate = DateTime.Now
            Me.Rating = rating
        End Sub
    End Class

    Public Function AddToWishlist(offerId As String, company As String, loanType As String, intMin As Decimal, _
                                   intMax As Decimal, minAmt As Decimal, maxAmt As Decimal, rating As Decimal) As Boolean
        ' Check if already exists
        If WishlistItems.Any(Function(x) x.LoanOfferId = offerId) Then
            Return False
        End If

        WishlistItems.Add(New WishlistItem(offerId, company, loanType, intMin, intMax, minAmt, maxAmt, rating))
        Return True
    End Function

    Public Function RemoveFromWishlist(offerId As String) As Boolean
        Dim item = WishlistItems.FirstOrDefault(Function(x) x.LoanOfferId = offerId)
        If item IsNot Nothing Then
            WishlistItems.Remove(item)
            Return True
        End If
        Return False
    End Function

    Public Function IsInWishlist(offerId As String) As Boolean
        Return WishlistItems.Any(Function(x) x.LoanOfferId = offerId)
    End Function

    Public Function GetWishlistCount() As Integer
        Return WishlistItems.Count
    End Function

    Public Sub ClearWishlist()
        WishlistItems.Clear()
    End Sub
End Module
