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

        ' Logo/Title
        Dim lblLogo As New Label()
        lblLogo.Text = "📱 CredShield"
        lblLogo.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblLogo.ForeColor = Color.FromArgb(34, 197, 94)
        lblLogo.AutoSize = True
        lblLogo.Location = New Point(20, 20)
        pnlHeader.Controls.Add(lblLogo)

        ' Back Button
        Dim btnBack As New Button()
        btnBack.Text = "← Back"
        btnBack.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnBack.BackColor = Color.FromArgb(34, 197, 94)
        btnBack.ForeColor = Color.White
        btnBack.FlatStyle = FlatStyle.Flat
        btnBack.FlatAppearance.BorderSize = 0
        btnBack.Size = New Size(100, 35)
        btnBack.Location = New Point(1280, 18)
        btnBack.Cursor = Cursors.Hand
        AddHandler btnBack.Click, Sub() Me.Close()
        pnlHeader.Controls.Add(btnBack)

        ' Main Content Panel
        Dim pnlContent As New Panel()
        pnlContent.BackColor = Color.FromArgb(245, 245, 245)
        pnlContent.AutoScroll = True
        pnlContent.AutoScrollMinSize = New Size(1400, 1200)
        pnlContent.Size = New Size(1400, 730)
        pnlContent.Location = New Point(0, 70)
        Me.Controls.Add(pnlContent)

        ' Main Title
        Dim lblTitle As New Label()
        lblTitle.Text = "Compare " & loanType
        lblTitle.Font = New Font("Segoe UI", 24, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(15, 23, 42)
        lblTitle.AutoSize = False
        lblTitle.TextAlign = ContentAlignment.MiddleCenter
        lblTitle.Location = New Point(0, 20)
        lblTitle.Size = New Size(1400, 40)
        pnlContent.Controls.Add(lblTitle)

        ' Subtitle
        Dim lblSubtitle As New Label()
        lblSubtitle.Text = "Select a loan offer to compare and apply - Find the best rates from top banks"
        lblSubtitle.Font = New Font("Segoe UI", 10)
        lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139)
        lblSubtitle.AutoSize = False
        lblSubtitle.TextAlign = ContentAlignment.MiddleCenter
        lblSubtitle.Location = New Point(100, 65)
        lblSubtitle.Size = New Size(1200, 25)
        pnlContent.Controls.Add(lblSubtitle)

        ' Display loans as cards
        Dim posY As Integer = 110
        For Each offer In loanOffers
            CreateLoanCard(pnlContent, offer, posY)
            posY += 280
        Next
    End Sub

    Private Sub CreateLoanCard(parent As Panel, offer As LoanOffer, posY As Integer)
        ' Card Panel
        Dim pnlCard As New Panel()
        pnlCard.BackColor = Color.White
        pnlCard.BorderStyle = BorderStyle.FixedSingle
        pnlCard.Size = New Size(1320, 250)
        pnlCard.Location = New Point(40, posY)
        pnlCard.Cursor = Cursors.Hand
        parent.Controls.Add(pnlCard)

        ' Store original and hover colors
        Dim originalBackColor As Color = Color.White
        Dim hoverBackColor As Color = Color.FromArgb(245, 250, 255)
        Dim accentColor As Color = Color.FromArgb(34, 197, 94)

        ' Colored Top Border
        Dim pnlBorder As New Panel()
        pnlBorder.BackColor = accentColor
        pnlBorder.Size = New Size(1320, 4)
        pnlBorder.Location = New Point(0, 0)
        pnlCard.Controls.Add(pnlBorder)

        ' Company Name
        Dim lblCompany As New Label()
        lblCompany.Text = offer.CompanyName
        lblCompany.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblCompany.ForeColor = accentColor
        lblCompany.AutoSize = True
        lblCompany.Location = New Point(20, 20)
        pnlCard.Controls.Add(lblCompany)

        ' Rating
        Dim lblRating As New Label()
        lblRating.Text = "⭐ " & offer.Rating & "/5 (" & offer.ReviewCount & " reviews)"
        lblRating.Font = New Font("Segoe UI", 9)
        lblRating.ForeColor = Color.FromArgb(249, 115, 22)
        lblRating.AutoSize = True
        lblRating.Location = New Point(1100, 20)
        pnlCard.Controls.Add(lblRating)

        ' Description
        Dim lblDesc As New Label()
        lblDesc.Text = offer.Description
        lblDesc.Font = New Font("Segoe UI", 11)
        lblDesc.ForeColor = Color.FromArgb(100, 116, 139)
        lblDesc.AutoSize = False
        lblDesc.TextAlign = ContentAlignment.TopLeft
        lblDesc.Location = New Point(20, 50)
        lblDesc.Size = New Size(1280, 40)
        pnlCard.Controls.Add(lblDesc)

        ' Features
        Dim featuresText As String = String.Join("  •  ", offer.Features.Take(3))
        Dim lblFeatures As New Label()
        lblFeatures.Text = featuresText
        lblFeatures.Font = New Font("Segoe UI", 10)
        lblFeatures.ForeColor = Color.FromArgb(52, 73, 94)
        lblFeatures.AutoSize = False
        lblFeatures.TextAlign = ContentAlignment.TopLeft
        lblFeatures.Location = New Point(20, 95)
        lblFeatures.Size = New Size(1280, 35)
        pnlCard.Controls.Add(lblFeatures)

        ' Key Details - 4 columns
        Dim details As String() = {
            "Interest Rate",
            "Tenure",
            "Loan Amount",
            "Approval"
        }
        Dim detailValues As String() = {
            offer.InterestRateMin & "% - " & offer.InterestRateMax & "%",
            offer.TenureMin & "-" & offer.TenureMax & " Years",
            "₹" & Format(offer.MinAmount, "0,0") & " - ₹" & Format(offer.MaxAmount, "0,0"),
            offer.ApprovalTime
        }

        Dim detailPositions As Integer() = {20, 360, 700, 1050}
        For i As Integer = 0 To 3
            Dim lblDetailLabel As New Label()
            lblDetailLabel.Text = details(i)
            lblDetailLabel.Font = New Font("Segoe UI", 9)
            lblDetailLabel.ForeColor = Color.FromArgb(100, 116, 139)
            lblDetailLabel.AutoSize = False
            lblDetailLabel.TextAlign = ContentAlignment.TopLeft
            lblDetailLabel.Location = New Point(detailPositions(i), 135)
            lblDetailLabel.Size = New Size(320, 18)
            pnlCard.Controls.Add(lblDetailLabel)

            Dim lblDetailValue As New Label()
            lblDetailValue.Text = detailValues(i)
            lblDetailValue.Font = New Font("Segoe UI", 12, FontStyle.Bold)
            lblDetailValue.ForeColor = Color.FromArgb(15, 23, 42)
            lblDetailValue.AutoSize = False
            lblDetailValue.TextAlign = ContentAlignment.TopLeft
            lblDetailValue.Location = New Point(detailPositions(i), 156)
            lblDetailValue.Size = New Size(320, 35)
            pnlCard.Controls.Add(lblDetailValue)
        Next

        ' Action Row with buttons
        Dim pnlActions As New Panel()
        pnlActions.BackColor = Color.FromArgb(248, 249, 250)
        pnlActions.BorderStyle = BorderStyle.FixedSingle
        pnlActions.Size = New Size(1320, 50)
        pnlActions.Location = New Point(0, 200)
        pnlCard.Controls.Add(pnlActions)

        ' Apply Button
        Dim btnApply As New Button()
        btnApply.Text = "📝 Apply Now"
        btnApply.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnApply.BackColor = Color.FromArgb(34, 197, 94)
        btnApply.ForeColor = Color.White
        btnApply.FlatStyle = FlatStyle.Flat
        btnApply.FlatAppearance.BorderSize = 0
        btnApply.Size = New Size(130, 35)
        btnApply.Location = New Point(20, 8)
        btnApply.Cursor = Cursors.Hand
        Dim offerCopy = offer
        AddHandler btnApply.Click, Sub(sender As Object, e As EventArgs) ApplyForLoan(offerCopy)
        pnlActions.Controls.Add(btnApply)

        ' Hover effects for Apply button
        AddHandler btnApply.MouseEnter, Sub(sender As Object, e As EventArgs)
                                            btnApply.BackColor = Color.FromArgb(25, 180, 80)
                                        End Sub
        AddHandler btnApply.MouseLeave, Sub(sender As Object, e As EventArgs)
                                            btnApply.BackColor = Color.FromArgb(34, 197, 94)
                                        End Sub

        ' Wishlist Button
        Dim btnWishlist As New Button()
        btnWishlist.Text = "❤️ Add to Wishlist"
        btnWishlist.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnWishlist.BackColor = Color.FromArgb(168, 85, 247)
        btnWishlist.ForeColor = Color.White
        btnWishlist.FlatStyle = FlatStyle.Flat
        btnWishlist.FlatAppearance.BorderSize = 0
        btnWishlist.Size = New Size(150, 35)
        btnWishlist.Location = New Point(160, 8)
        btnWishlist.Cursor = Cursors.Hand
        AddHandler btnWishlist.Click, Sub(sender As Object, e As EventArgs) AddToWishlist(offerCopy, btnWishlist)
        pnlActions.Controls.Add(btnWishlist)

        ' Hover effects for Wishlist button
        AddHandler btnWishlist.MouseEnter, Sub(sender As Object, e As EventArgs)
                                               btnWishlist.BackColor = Color.FromArgb(147, 60, 215)
                                           End Sub
        AddHandler btnWishlist.MouseLeave, Sub(sender As Object, e As EventArgs)
                                               btnWishlist.BackColor = Color.FromArgb(168, 85, 247)
                                           End Sub

        ' Card hover effects
        AddHandler pnlCard.MouseEnter, Sub(sender As Object, e As EventArgs)
                                           pnlCard.BackColor = hoverBackColor
                                           pnlCard.BorderStyle = BorderStyle.FixedSingle
                                           pnlCard.Size = New Size(1325, 255)
                                           pnlCard.Location = New Point(37, posY - 2)
                                       End Sub

        AddHandler pnlCard.MouseLeave, Sub(sender As Object, e As EventArgs)
                                           pnlCard.BackColor = originalBackColor
                                           pnlCard.BorderStyle = BorderStyle.FixedSingle
                                           pnlCard.Size = New Size(1320, 250)
                                           pnlCard.Location = New Point(40, posY)
                                       End Sub
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
