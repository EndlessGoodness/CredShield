Public Class FormLoanTypeComparison
    Inherits Form

    Private loanType As String
    Private userId As Integer
    Private loanOffers As List(Of LoanOffer)
    Private dgvLoans As DataGridView
    Private selectedLoan As LoanOffer

    Public Sub New(loanType As String, userId As Integer)
        MyBase.New()
        Me.loanType = loanType
        Me.userId = userId
        Me.Text = "CredShield - " & loanType & " Comparison"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(1400, 800)
        Me.BackColor = Color.FromArgb(245, 245, 245)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False

        LoadLoans()
        BuildUI()
    End Sub

    Private Sub LoadLoans()
        ' Get all loan offers and filter by type
        ' Remove "s" from plural to match database (e.g., "Home Loans" -> "Home Loan")
        Dim loanTypeToMatch As String = loanType
        If loanTypeToMatch.EndsWith("s") AndAlso Not loanTypeToMatch.EndsWith("ss") Then
            loanTypeToMatch = loanTypeToMatch.Substring(0, loanTypeToMatch.Length - 1)
        End If

        Dim allOffers = LoanOffersDatabase.GetAllLoanOffers()
        loanOffers = allOffers.Where(Function(x) x.LoanType = loanTypeToMatch).ToList()

        ' If no offers found, try alternative matching
        If loanOffers.Count = 0 Then
            loanOffers = allOffers.Where(Function(x) x.LoanType.Contains(loanTypeToMatch.Split(" ")(0))).ToList()
        End If
    End Sub

    Private Sub BuildUI()
        ' Header Panel
        Dim pnlHeader As New Panel()
        pnlHeader.BackColor = Color.FromArgb(15, 23, 42)
        pnlHeader.Size = New Size(1400, 70)
        pnlHeader.Location = New Point(0, 0)
        Me.Controls.Add(pnlHeader)

        ' Back Button
        Dim btnBack As New Button()
        btnBack.Text = "← Back"
        btnBack.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnBack.BackColor = Color.FromArgb(100, 116, 139)
        btnBack.ForeColor = Color.White
        btnBack.FlatStyle = FlatStyle.Flat
        btnBack.FlatAppearance.BorderSize = 0
        btnBack.Size = New Size(100, 35)
        btnBack.Location = New Point(20, 18)
        btnBack.Cursor = Cursors.Hand
        AddHandler btnBack.Click, Sub() Me.Close()
        pnlHeader.Controls.Add(btnBack)

        ' Title
        Dim lblTitle As New Label()
        lblTitle.Text = "Compare " & loanType
        lblTitle.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.AutoSize = False
        lblTitle.TextAlign = ContentAlignment.MiddleCenter
        lblTitle.Location = New Point(300, 15)
        lblTitle.Size = New Size(800, 40)
        pnlHeader.Controls.Add(lblTitle)

        ' Main Content Panel
        Dim pnlContent As New Panel()
        pnlContent.BackColor = Color.FromArgb(245, 245, 245)
        pnlContent.AutoScroll = True
        pnlContent.Size = New Size(1400, 730)
        pnlContent.Location = New Point(0, 70)
        Me.Controls.Add(pnlContent)

        ' Subtitle
        Dim lblSubtitle As New Label()
        lblSubtitle.Text = "Select a loan offer to compare and apply"
        lblSubtitle.Font = New Font("Segoe UI", 10)
        lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139)
        lblSubtitle.AutoSize = False
        lblSubtitle.TextAlign = ContentAlignment.MiddleCenter
        lblSubtitle.Location = New Point(0, 10)
        lblSubtitle.Size = New Size(1400, 25)
        pnlContent.Controls.Add(lblSubtitle)

        ' Display loans as cards
        Dim posY As Integer = 50
        For Each offer In loanOffers
            CreateLoanCard(pnlContent, offer, posY)
            posY += 220
        Next

        ' Footer with action buttons
        Dim pnlFooter As New Panel()
        pnlFooter.BackColor = Color.FromArgb(15, 23, 42)
        pnlFooter.Size = New Size(1400, 60)
        pnlFooter.Location = New Point(0, 740)
        Me.Controls.Add(pnlFooter)

        Dim lblFooter As New Label()
        lblFooter.Text = "Select a loan above to proceed with application"
        lblFooter.Font = New Font("Segoe UI", 9)
        lblFooter.ForeColor = Color.White
        lblFooter.AutoSize = False
        lblFooter.TextAlign = ContentAlignment.MiddleLeft
        lblFooter.Location = New Point(20, 10)
        lblFooter.Size = New Size(1000, 40)
        pnlFooter.Controls.Add(lblFooter)
    End Sub

    Private Sub CreateLoanCard(parent As Panel, offer As LoanOffer, posY As Integer)
        ' Card Panel
        Dim pnlCard As New Panel()
        pnlCard.BackColor = Color.White
        pnlCard.BorderStyle = BorderStyle.FixedSingle
        pnlCard.Size = New Size(1340, 200)
        pnlCard.Location = New Point(30, posY)
        pnlCard.Cursor = Cursors.Hand
        parent.Controls.Add(pnlCard)

        ' Company Name
        Dim lblCompany As New Label()
        lblCompany.Text = offer.CompanyName
        lblCompany.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblCompany.ForeColor = Color.FromArgb(34, 197, 94)
        lblCompany.AutoSize = True
        lblCompany.Location = New Point(20, 15)
        pnlCard.Controls.Add(lblCompany)

        ' Rating
        Dim lblRating As New Label()
        lblRating.Text = "⭐ " & offer.Rating & "/5 (" & offer.ReviewCount & " reviews)"
        lblRating.Font = New Font("Segoe UI", 9)
        lblRating.ForeColor = Color.FromArgb(249, 115, 22)
        lblRating.AutoSize = True
        lblRating.Location = New Point(1150, 15)
        pnlCard.Controls.Add(lblRating)

        ' Description
        Dim lblDesc As New Label()
        lblDesc.Text = offer.Description
        lblDesc.Font = New Font("Segoe UI", 9)
        lblDesc.ForeColor = Color.FromArgb(100, 116, 139)
        lblDesc.AutoSize = False
        lblDesc.TextAlign = ContentAlignment.TopLeft
        lblDesc.Location = New Point(20, 40)
        lblDesc.Size = New Size(1300, 40)
        pnlCard.Controls.Add(lblDesc)

        ' Features
        Dim featuresText As String = String.Join("  •  ", offer.Features.Take(3))
        Dim lblFeatures As New Label()
        lblFeatures.Text = featuresText
        lblFeatures.Font = New Font("Segoe UI", 8)
        lblFeatures.ForeColor = Color.FromArgb(52, 73, 94)
        lblFeatures.AutoSize = False
        lblFeatures.TextAlign = ContentAlignment.TopLeft
        lblFeatures.Location = New Point(20, 85)
        lblFeatures.Size = New Size(1300, 50)
        pnlCard.Controls.Add(lblFeatures)

        ' Key Details - 4 columns
        Dim details As String() = {
            "Interest Rate: " & offer.InterestRateMin & "% - " & offer.InterestRateMax & "%",
            "Tenure: " & offer.TenureMin & "-" & offer.TenureMax & " Years",
            "Loan Amount: ₹" & Format(offer.MinAmount, "0,0") & " - ₹" & Format(offer.MaxAmount, "0,0"),
            "Approval: " & offer.ApprovalTime
        }

        Dim detailPositions As Integer() = {20, 350, 680, 1000}
        For i As Integer = 0 To 3
            Dim lblDetail As New Label()
            lblDetail.Text = details(i)
            lblDetail.Font = New Font("Segoe UI", 9, FontStyle.Bold)
            lblDetail.ForeColor = Color.FromArgb(52, 73, 94)
            lblDetail.AutoSize = False
            lblDetail.TextAlign = ContentAlignment.TopLeft
            lblDetail.Location = New Point(detailPositions(i), 145)
            lblDetail.Size = New Size(320, 50)
            pnlCard.Controls.Add(lblDetail)
        Next

        ' Apply Button
        Dim btnApply As New Button()
        btnApply.Text = "📝 Apply Now"
        btnApply.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnApply.BackColor = Color.FromArgb(34, 197, 94)
        btnApply.ForeColor = Color.White
        btnApply.FlatStyle = FlatStyle.Flat
        btnApply.FlatAppearance.BorderSize = 0
        btnApply.Size = New Size(120, 35)
        btnApply.Location = New Point(1150, 160)
        btnApply.Cursor = Cursors.Hand
        Dim offerCopy = offer
        AddHandler btnApply.Click, Sub(sender As Object, e As EventArgs) ApplyForLoan(offerCopy)
        pnlCard.Controls.Add(btnApply)

        ' Wishlist Button
        Dim btnWishlist As New Button()
        btnWishlist.Text = "❤️"
        btnWishlist.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        btnWishlist.BackColor = Color.FromArgb(168, 85, 247)
        btnWishlist.ForeColor = Color.White
        btnWishlist.FlatStyle = FlatStyle.Flat
        btnWishlist.FlatAppearance.BorderSize = 0
        btnWishlist.Size = New Size(50, 35)
        btnWishlist.Location = New Point(1275, 160)
        btnWishlist.Cursor = Cursors.Hand
        AddHandler btnWishlist.Click, Sub(sender As Object, e As EventArgs) AddToWishlist(offerCopy, btnWishlist)
        pnlCard.Controls.Add(btnWishlist)

        ' Click handlers for card selection
        AddHandler pnlCard.Click, Sub(sender As Object, e As EventArgs) SelectLoan(offerCopy)
    End Sub

    Private Sub SelectLoan(loan As LoanOffer)
        selectedLoan = loan
    End Sub

    Private Sub ApplyForLoan(offer As LoanOffer)
        ' Open loan registration form with pre-filled data
        Dim loanRegForm As New FormLoanApplicationWithOffer(userId, offer)
        loanRegForm.ShowDialog(Me)
        ' Refresh or update UI if needed
    End Sub

    Private Sub AddToWishlist(offer As LoanOffer, button As Button)
        Dim success = WishlistManager.AddToWishlist(
            offer.CompanyId,
            offer.CompanyName,
            offer.LoanType,
            offer.InterestRateMin,
            offer.InterestRateMax,
            offer.MinAmount,
            offer.MaxAmount,
            offer.Rating
        )

        If success Then
            MessageBox.Show("Added to your wishlist!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            button.BackColor = Color.FromArgb(220, 20, 60)
        Else
            MessageBox.Show("Already in your wishlist!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class
