Public Class FormLoanComparison
    Inherits Form

    Private allOffers As List(Of LoanOffer)
    Private selectedLoanType As String = ""
    Private pnlContent As Panel

    Public Sub New()
        MyBase.New()
        Me.Text = "CredShield - Loan Comparison"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(1600, 1000)
        Me.BackColor = Color.FromArgb(236, 240, 241)
        Me.DoubleBuffered = True
        BuildUI()
    End Sub

    Private Sub BuildUI()
        ' Create header
        Dim pnlHeader As New Panel()
        pnlHeader.BackColor = Color.FromArgb(41, 128, 185)
        pnlHeader.Size = New Size(1600, 80)
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Padding = New Padding(20)
        Me.Controls.Add(pnlHeader)

        Dim lblLogo As New Label()
        lblLogo.Text = "💼 CredShield - Loan Comparison"
        lblLogo.Font = New Font("Segoe UI", 20, FontStyle.Bold)
        lblLogo.ForeColor = Color.White
        lblLogo.AutoSize = True
        lblLogo.Location = New Point(20, 15)
        pnlHeader.Controls.Add(lblLogo)

        Dim btnWishlist As New Button()
        btnWishlist.Text = "❤️ Wishlist (" & WishlistManager.GetWishlistCount() & ")"
        btnWishlist.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnWishlist.BackColor = Color.White
        btnWishlist.ForeColor = Color.FromArgb(41, 128, 185)
        btnWishlist.FlatStyle = FlatStyle.Flat
        btnWishlist.Size = New Size(140, 35)
        btnWishlist.Location = New Point(1440, 22)
        btnWishlist.Cursor = Cursors.Hand
        AddHandler btnWishlist.Click, Sub() ShowWishlist()
        pnlHeader.Controls.Add(btnWishlist)

        ' Create filter panel
        Dim pnlFilter As New Panel()
        pnlFilter.BackColor = Color.FromArgb(52, 73, 94)
        pnlFilter.Size = New Size(1600, 100)
        pnlFilter.Location = New Point(0, 80)
        Me.Controls.Add(pnlFilter)

        Dim lblFilterTitle As New Label()
        lblFilterTitle.Text = "📊 Select Loan Type:"
        lblFilterTitle.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        lblFilterTitle.ForeColor = Color.White
        lblFilterTitle.AutoSize = True
        lblFilterTitle.Location = New Point(30, 15)
        pnlFilter.Controls.Add(lblFilterTitle)

        ' Home Loan Filter Button
        Dim btnHome As New Button()
        btnHome.Text = "🏠 Home Loans"
        btnHome.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnHome.BackColor = Color.FromArgb(41, 128, 185)
        btnHome.ForeColor = Color.White
        btnHome.FlatStyle = FlatStyle.Flat
        btnHome.Size = New Size(180, 50)
        btnHome.Location = New Point(30, 45)
        btnHome.Cursor = Cursors.Hand
        AddHandler btnHome.Click, Sub() DisplayOffers("Home Loan")
        pnlFilter.Controls.Add(btnHome)

        ' Bank Loan Filter Button
        Dim btnBank As New Button()
        btnBank.Text = "🏦 Bank Loans"
        btnBank.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnBank.BackColor = Color.FromArgb(46, 204, 113)
        btnBank.ForeColor = Color.White
        btnBank.FlatStyle = FlatStyle.Flat
        btnBank.Size = New Size(180, 50)
        btnBank.Location = New Point(230, 45)
        btnBank.Cursor = Cursors.Hand
        AddHandler btnBank.Click, Sub() DisplayOffers("Bank Loan")
        pnlFilter.Controls.Add(btnBank)

        ' Financial Loan Filter Button
        Dim btnFinancial As New Button()
        btnFinancial.Text = "💰 Financial Loans"
        btnFinancial.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnFinancial.BackColor = Color.FromArgb(155, 89, 182)
        btnFinancial.ForeColor = Color.White
        btnFinancial.FlatStyle = FlatStyle.Flat
        btnFinancial.Size = New Size(180, 50)
        btnFinancial.Location = New Point(430, 45)
        btnFinancial.Cursor = Cursors.Hand
        AddHandler btnFinancial.Click, Sub() DisplayOffers("Financial Loan")
        pnlFilter.Controls.Add(btnFinancial)

        ' All Loans Button
        Dim btnAll As New Button()
        btnAll.Text = "📋 All Loans"
        btnAll.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnAll.BackColor = Color.FromArgb(149, 165, 166)
        btnAll.ForeColor = Color.White
        btnAll.FlatStyle = FlatStyle.Flat
        btnAll.Size = New Size(150, 50)
        btnAll.Location = New Point(630, 45)
        btnAll.Cursor = Cursors.Hand
        AddHandler btnAll.Click, Sub() DisplayOffers("")
        pnlFilter.Controls.Add(btnAll)

        ' Create content panel with scrollbar
        pnlContent = New Panel()
        pnlContent.BackColor = Color.FromArgb(236, 240, 241)
        pnlContent.Size = New Size(1580, 820)
        pnlContent.Location = New Point(10, 190)
        pnlContent.AutoScroll = True
        Me.Controls.Add(pnlContent)

        ' Load all offers
        allOffers = LoanOffersDatabase.GetAllLoanOffers()
        DisplayOffers("")
    End Sub

    Private Sub DisplayOffers(loanType As String)
        pnlContent.Controls.Clear()

        Dim offers As List(Of LoanOffer)
        If String.IsNullOrEmpty(loanType) Then
            offers = allOffers
        Else
            offers = allOffers.Where(Function(x) x.LoanType = loanType).ToList()
        End If

        Dim yPosition As Integer = 20

        ' Create title
        Dim lblTitle As New Label()
        If String.IsNullOrEmpty(loanType) Then
            lblTitle.Text = "📊 All Available Loan Offers"
        Else
            lblTitle.Text = "📊 " & loanType & " Offers (" & offers.Count & " Available)"
        End If
        lblTitle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(41, 128, 185)
        lblTitle.AutoSize = True
        lblTitle.Location = New Point(20, yPosition)
        pnlContent.Controls.Add(lblTitle)

        yPosition += 50

        ' Display each offer
        For Each offer In offers
            CreateOfferCard(offer, 20, yPosition)
            yPosition += 320
        Next
    End Sub

    Private Sub CreateOfferCard(offer As LoanOffer, x As Integer, y As Integer)
        Dim card As New Panel()
        card.BackColor = Color.White
        card.Size = New Size(1520, 300)
        card.Location = New Point(x, y)
        card.BorderStyle = BorderStyle.FixedSingle
        card.Padding = New Padding(15)
        pnlContent.Controls.Add(card)

        ' Company Name and Rating
        Dim lblCompany As New Label()
        lblCompany.Text = "🏢 " & offer.CompanyName & " ⭐ " & offer.Rating.ToString("F1") & " (" & offer.ReviewCount & " reviews)"
        lblCompany.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        lblCompany.ForeColor = Color.FromArgb(41, 128, 185)
        lblCompany.AutoSize = False
        lblCompany.Location = New Point(0, 0)
        lblCompany.Size = New Size(1490, 30)
        card.Controls.Add(lblCompany)

        ' Loan Details
        Dim lblDetails As New Label()
        lblDetails.Text = $"💰 Amount: ₹{offer.MinAmount:N0} - ₹{offer.MaxAmount:N0} | " & _
                         $"📊 Interest Rate: {offer.InterestRateMin}% - {offer.InterestRateMax}% p.a. | " & _
                         $"⏱️ Tenure: {offer.TenureMin} - {offer.TenureMax} years | " & _
                         $"⚡ Approval: {offer.ApprovalTime} | " & _
                         $"💳 Processing Fee: {offer.ProcessingFee}%"
        lblDetails.Font = New Font("Segoe UI", 9)
        lblDetails.ForeColor = Color.FromArgb(52, 73, 94)
        lblDetails.AutoSize = False
        lblDetails.Location = New Point(0, 35)
        lblDetails.Size = New Size(1490, 50)
        card.Controls.Add(lblDetails)

        ' Description
        Dim lblDesc As New Label()
        lblDesc.Text = offer.Description
        lblDesc.Font = New Font("Segoe UI", 9)
        lblDesc.ForeColor = Color.FromArgb(100, 100, 100)
        lblDesc.AutoSize = False
        lblDesc.Location = New Point(0, 90)
        lblDesc.Size = New Size(1490, 40)
        card.Controls.Add(lblDesc)

        ' Features
        Dim lblFeatures As New Label()
        lblFeatures.Text = String.Join("  |  ", offer.Features.Take(3))
        lblFeatures.Font = New Font("Segoe UI", 8)
        lblFeatures.ForeColor = Color.FromArgb(100, 150, 100)
        lblFeatures.AutoSize = False
        lblFeatures.Location = New Point(0, 135)
        lblFeatures.Size = New Size(1490, 45)
        card.Controls.Add(lblFeatures)

        ' Action Buttons
        Dim btnDetails As New Button()
        btnDetails.Text = "📋 View Details"
        btnDetails.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        btnDetails.BackColor = Color.FromArgb(41, 128, 185)
        btnDetails.ForeColor = Color.White
        btnDetails.FlatStyle = FlatStyle.Flat
        btnDetails.Size = New Size(140, 35)
        btnDetails.Location = New Point(900, 255)
        btnDetails.Cursor = Cursors.Hand
        AddHandler btnDetails.Click, Sub() ShowOfferDetails(offer)
        card.Controls.Add(btnDetails)

        Dim wishlistStatus = WishlistManager.IsInWishlist(offer.CompanyId & "-" & offer.LoanType)
        Dim btnWishlist As New Button()
        btnWishlist.Text = If(wishlistStatus, "❌ Remove Wishlist", "❤️ Add Wishlist")
        btnWishlist.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        btnWishlist.BackColor = If(wishlistStatus, Color.FromArgb(231, 76, 60), Color.FromArgb(46, 204, 113))
        btnWishlist.ForeColor = Color.White
        btnWishlist.FlatStyle = FlatStyle.Flat
        btnWishlist.Size = New Size(160, 35)
        btnWishlist.Location = New Point(1050, 255)
        btnWishlist.Cursor = Cursors.Hand
        AddHandler btnWishlist.Click, Sub()
                                           Dim offerId = offer.CompanyId & "-" & offer.LoanType
                                           If WishlistManager.IsInWishlist(offerId) Then
                                               WishlistManager.RemoveFromWishlist(offerId)
                                               btnWishlist.Text = "❤️ Add Wishlist"
                                               btnWishlist.BackColor = Color.FromArgb(46, 204, 113)
                                               MessageBox.Show("Removed from wishlist!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                           Else
                                               WishlistManager.AddToWishlist(offerId, offer.CompanyName, offer.LoanType, _
                                                                              offer.InterestRateMin, offer.InterestRateMax, _
                                                                              offer.MinAmount, offer.MaxAmount, offer.Rating)
                                               btnWishlist.Text = "❌ Remove Wishlist"
                                               btnWishlist.BackColor = Color.FromArgb(231, 76, 60)
                                               MessageBox.Show("Added to wishlist!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                           End If
                                       End Sub
        card.Controls.Add(btnWishlist)

        Dim btnApply As New Button()
        btnApply.Text = "🚀 Apply Now"
        btnApply.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        btnApply.BackColor = Color.FromArgb(155, 89, 182)
        btnApply.ForeColor = Color.White
        btnApply.FlatStyle = FlatStyle.Flat
        btnApply.Size = New Size(140, 35)
        btnApply.Location = New Point(1220, 255)
        btnApply.Cursor = Cursors.Hand
        AddHandler btnApply.Click, Sub()
                                       LoanManager.SelectedLoanType = offer.LoanType
                                       Form5.Show()
                                       Me.Hide()
                                   End Sub
        card.Controls.Add(btnApply)
    End Sub

    Private Sub ShowOfferDetails(offer As LoanOffer)
        Dim detailsForm As New Form()
        detailsForm.Text = offer.CompanyName & " - " & offer.LoanType
        detailsForm.StartPosition = FormStartPosition.CenterScreen
        detailsForm.Size = New Size(700, 600)
        detailsForm.BackColor = Color.FromArgb(236, 240, 241)

        Dim detailsText = $"Company: {offer.CompanyName}{vbCrLf}" & _
                         $"Loan Type: {offer.LoanType}{vbCrLf}" & _
                         $"Loan Amount: ₹{offer.MinAmount:N0} - ₹{offer.MaxAmount:N0}{vbCrLf}" & _
                         $"Interest Rate: {offer.InterestRateMin}% - {offer.InterestRateMax}% p.a.{vbCrLf}" & _
                         $"Tenure: {offer.TenureMin} - {offer.TenureMax} years{vbCrLf}" & _
                         $"Processing Fee: {offer.ProcessingFee}%{vbCrLf}" & _
                         $"Approval Time: {offer.ApprovalTime}{vbCrLf}" & _
                         $"Rating: {offer.Rating} / 5.0{vbCrLf}" & _
                         $"Reviews: {offer.ReviewCount}{vbCrLf}{vbCrLf}" & _
                         $"Description:{vbCrLf}{offer.Description}{vbCrLf}{vbCrLf}" & _
                         $"Key Features:{vbCrLf}" & String.Join(vbCrLf, offer.Features)

        Dim txtDetails As New TextBox()
        txtDetails.Multiline = True
        txtDetails.ScrollBars = ScrollBars.Both
        txtDetails.Text = detailsText
        txtDetails.Font = New Font("Segoe UI", 10)
        txtDetails.ReadOnly = True
        txtDetails.Dock = DockStyle.Fill
        detailsForm.Controls.Add(txtDetails)

        detailsForm.ShowDialog()
    End Sub

    Private Sub ShowWishlist()
        Dim wishlistForm As New Form()
        wishlistForm.Text = "❤️ My Wishlist"
        wishlistForm.StartPosition = FormStartPosition.CenterScreen
        wishlistForm.Size = New Size(900, 600)
        wishlistForm.BackColor = Color.FromArgb(236, 240, 241)

        Dim pnl As New Panel()
        pnl.BackColor = Color.FromArgb(236, 240, 241)
        pnl.Dock = DockStyle.Fill
        pnl.AutoScroll = True
        wishlistForm.Controls.Add(pnl)

        If WishlistManager.WishlistItems.Count = 0 Then
            Dim lblEmpty As New Label()
            lblEmpty.Text = "Your wishlist is empty!"
            lblEmpty.Font = New Font("Segoe UI", 14, FontStyle.Bold)
            lblEmpty.ForeColor = Color.FromArgb(100, 100, 100)
            lblEmpty.AutoSize = True
            lblEmpty.Location = New Point(300, 250)
            pnl.Controls.Add(lblEmpty)
        Else
            Dim yPos = 20
            For Each item In WishlistManager.WishlistItems
                Dim card As New Panel()
                card.BackColor = Color.White
                card.Size = New Size(850, 100)
                card.Location = New Point(20, yPos)
                card.BorderStyle = BorderStyle.FixedSingle
                pnl.Controls.Add(card)

                Dim lblItem As New Label()
                lblItem.Text = $"🏢 {item.CompanyName} | {item.LoanType} | ⭐ {item.Rating} | Interest: {item.InterestRateMin}% - {item.InterestRateMax}% | Amount: ₹{item.MinAmount:N0} - ₹{item.MaxAmount:N0}"
                lblItem.Font = New Font("Segoe UI", 10)
                lblItem.AutoSize = False
                lblItem.Location = New Point(10, 10)
                lblItem.Size = New Size(750, 80)
                card.Controls.Add(lblItem)

                Dim btnRemove As New Button()
                btnRemove.Text = "Remove"
                btnRemove.Font = New Font("Segoe UI", 9)
                btnRemove.BackColor = Color.FromArgb(231, 76, 60)
                btnRemove.ForeColor = Color.White
                btnRemove.FlatStyle = FlatStyle.Flat
                btnRemove.Size = New Size(100, 35)
                btnRemove.Location = New Point(770, 30)
                btnRemove.Cursor = Cursors.Hand
                AddHandler btnRemove.Click, Sub()
                                                WishlistManager.RemoveFromWishlist(item.LoanOfferId)
                                                MessageBox.Show("Removed from wishlist!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                wishlistForm.Close()
                                                ShowWishlist()
                                            End Sub
                card.Controls.Add(btnRemove)

                yPos += 120
            Next
        End If

        wishlistForm.ShowDialog()
    End Sub
End Class
