Public Class LoanOffersDatabase
    ' Database of loan offers from different companies
    Public Shared Function GetAllLoanOffers() As List(Of LoanOffer)
        Dim offers As New List(Of LoanOffer)

        ' HOME LOANS
        ' Company 1 - HDFC Home Loan
        Dim hdfc As New LoanOffer("HDFC Bank", "HDFC001", "Home Loan", 500000, 5000000, 6.5, 8.5, 5, 20, 0.5, "3-5 Days", _
                                  "Get your dream home with competitive rates and flexible repayment options from HDFC Bank.", 4.5, 2847)
        hdfc.Features.AddRange(New String() {
            "✓ Loan up to 50 Lakhs",
            "✓ Interest Rate: 6.5% - 8.5% p.a.",
            "✓ Tenure: 5-20 years",
            "✓ Minimal documentation",
            "✓ Quick processing",
            "✓ Balance Transfer facility"
        })
        offers.Add(hdfc)

        ' Company 2 - ICICI Home Loan
        Dim icici As New LoanOffer("ICICI Bank", "ICICI001", "Home Loan", 300000, 7500000, 6.75, 8.75, 5, 20, 0.5, "2-4 Days", _
                                   "Flexible home loan solutions tailored to your needs from ICICI Bank.", 4.3, 2156)
        icici.Features.AddRange(New String() {
            "✓ Loan up to 75 Lakhs",
            "✓ Interest Rate: 6.75% - 8.75% p.a.",
            "✓ Tenure: 5-20 years",
            "✓ Easy eligibility",
            "✓ Same day approval option",
            "✓ Co-borrower facility"
        })
        offers.Add(icici)

        ' Company 3 - SBI Home Loan
        Dim sbi As New LoanOffer("State Bank of India", "SBI001", "Home Loan", 250000, 10000000, 6.4, 8.4, 5, 20, 0.4, "4-6 Days", _
                                 "State Bank of India offers the best rates for home loans.", 4.6, 3421)
        sbi.Features.AddRange(New String() {
            "✓ Loan up to 1 Crore",
            "✓ Interest Rate: 6.4% - 8.4% p.a.",
            "✓ Tenure: 5-20 years",
            "✓ Government bank security",
            "✓ Lowest processing fee",
            "✓ Loan on inherited property"
        })
        offers.Add(sbi)

        ' BANK LOANS (Personal Loans)
        ' Company 1 - HDFC Personal Loan
        Dim hdfcPersonal As New LoanOffer("HDFC Bank", "HDFC002", "Bank Loan", 50000, 3000000, 9.0, 15.0, 1, 5, 2.0, "Same Day", _
                                          "Get instant personal loan from HDFC Bank with minimal documentation.", 4.4, 5234)
        hdfcPersonal.Features.AddRange(New String() {
            "✓ Loan: 50K - 30 Lakhs",
            "✓ Interest Rate: 9% - 15% p.a.",
            "✓ Tenure: 1-5 years",
            "✓ Instant approval",
            "✓ No collateral required",
            "✓ Flexible repayment options"
        })
        offers.Add(hdfcPersonal)

        ' Company 2 - Bajaj Finserv Personal Loan
        Dim bajaj As New LoanOffer("Bajaj Finserv", "BAJAJ001", "Bank Loan", 25000, 2500000, 11.0, 16.0, 1, 5, 1.5, "1-2 Hours", _
                                   "Fast personal loan approval from Bajaj Finserv with digital process.", 4.2, 4521)
        bajaj.Features.AddRange(New String() {
            "✓ Loan: 25K - 25 Lakhs",
            "✓ Interest Rate: 11% - 16% p.a.",
            "✓ Tenure: 1-5 years",
            "✓ 100% digital application",
            "✓ Fastest disbursement",
            "✓ Hassle-free documentation"
        })
        offers.Add(bajaj)

        ' Company 3 - IndusInd Bank Personal Loan
        Dim indusind As New LoanOffer("IndusInd Bank", "INDUSIND001", "Bank Loan", 50000, 5000000, 8.5, 14.0, 1, 5, 1.0, "1-3 Hours", _
                                      "IndusInd Bank personal loan with best-in-class customer service.", 4.5, 3876)
        indusind.Features.AddRange(New String() {
            "✓ Loan: 50K - 50 Lakhs",
            "✓ Interest Rate: 8.5% - 14% p.a.",
            "✓ Tenure: 1-5 years",
            "✓ Quick approval process",
            "✓ Zero processing fee option",
            "✓ Part-prepayment allowed"
        })
        offers.Add(indusind)

        ' FINANCIAL LOANS
        ' Company 1 - Axis Bank Business Loan
        Dim axis As New LoanOffer("Axis Bank", "AXIS001", "Financial Loan", 100000, 5000000, 10.0, 16.0, 1, 7, 2.5, "3-5 Days", _
                                  "Business loans tailored for startups and enterprises from Axis Bank.", 4.3, 1234)
        axis.Features.AddRange(New String() {
            "✓ Loan: 1L - 50 Lakhs",
            "✓ Interest Rate: 10% - 16% p.a.",
            "✓ Tenure: 1-7 years",
            "✓ Quick fund disbursement",
            "✓ Flexible repayment",
            "✓ Expert financial guidance"
        })
        offers.Add(axis)

        ' Company 2 - ICICI Business Loan
        Dim iciciBusiness As New LoanOffer("ICICI Bank", "ICICI002", "Financial Loan", 150000, 7500000, 9.5, 15.5, 1, 7, 2.0, "2-4 Days", _
                                           "Investment and expansion loans for growing businesses.", 4.4, 987)
        iciciBusiness.Features.AddRange(New String() {
            "✓ Loan: 1.5L - 75 Lakhs",
            "✓ Interest Rate: 9.5% - 15.5% p.a.",
            "✓ Tenure: 1-7 years",
            "✓ Business plan assistance",
            "✓ Growth support services",
            "✓ Competitive rates"
        })
        offers.Add(iciciBusiness)

        ' Company 3 - Kotak Mahindra Business Loan
        Dim kotak As New LoanOffer("Kotak Mahindra Bank", "KOTAK001", "Financial Loan", 100000, 10000000, 9.0, 15.0, 1, 10, 1.5, "1-3 Days", _
                                   "Enterprise loans designed for business growth and expansion.", 4.6, 1543)
        kotak.Features.AddRange(New String() {
            "✓ Loan: 1L - 1 Crore",
            "✓ Interest Rate: 9% - 15% p.a.",
            "✓ Tenure: 1-10 years",
            "✓ Dedicated relationship manager",
            "✓ Custom EMI options",
            "✓ Quick decision making"
        })
        offers.Add(kotak)

        Return offers
    End Function

    Public Shared Function GetLoanOffersByType(loanType As String) As List(Of LoanOffer)
        Dim allOffers = GetAllLoanOffers()
        Return allOffers.Where(Function(x) x.LoanType = loanType).ToList()
    End Function

    Public Shared Function GetCompaniesForLoanType(loanType As String) As List(Of String)
        Dim offers = GetLoanOffersByType(loanType)
        Return offers.Select(Function(x) x.CompanyName).Distinct().ToList()
    End Function

    Public Shared Function GetBestRateForLoanType(loanType As String) As LoanOffer
        Dim offers = GetLoanOffersByType(loanType)
        If offers.Count > 0 Then
            Return offers.OrderBy(Function(x) x.InterestRateMin).First()
        End If
        Return Nothing
    End Function

    Public Shared Function SearchOffers(loanType As String, companyName As String) As List(Of LoanOffer)
        Dim allOffers = GetAllLoanOffers()
        Dim results = allOffers

        If Not String.IsNullOrEmpty(loanType) Then
            results = results.Where(Function(x) x.LoanType = loanType).ToList()
        End If

        If Not String.IsNullOrEmpty(companyName) Then
            results = results.Where(Function(x) x.CompanyName.ToLower().Contains(companyName.ToLower())).ToList()
        End If

        Return results.OrderByDescending(Function(x) x.Rating).ToList()
    End Function
End Class
