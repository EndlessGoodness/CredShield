Public Class FormModernHome
    Inherits Form

    Private pnlContent As Panel

    Public Sub New()
        MyBase.New()
        Me.Text = "CredShield - Loan Solutions"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(1500, 1000)
        Me.BackColor = Color.FromArgb(249, 250, 251)
        Me.DoubleBuffered = True
        BuildUI()
    End Sub

    Private Sub BuildUI()
        ' Create header
        Dim pnlHeader As New Panel()
        pnlHeader.BackColor = Color.White
        pnlHeader.Size = New Size(1500, 80)
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Padding = New Padding(20)
        Me.Controls.Add(pnlHeader)

        Dim lblLogo As New Label()
        lblLogo.Text = "💼 CredShield"
        lblLogo.Font = New Font("Segoe UI", 20, FontStyle.Bold)
        lblLogo.ForeColor = Color.FromArgb(59, 130, 246)
        lblLogo.AutoSize = True
        lblLogo.Location = New Point(20, 15)
        pnlHeader.Controls.Add(lblLogo)

        Dim btnLogout As New Button()
        btnLogout.Text = "🚪 Logout"
        btnLogout.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnLogout.BackColor = Color.FromArgb(59, 130, 246)
        btnLogout.ForeColor = Color.White
        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.FlatAppearance.BorderSize = 0
        btnLogout.Size = New Size(100, 35)
        btnLogout.Location = New Point(1380, 22)
        btnLogout.Cursor = Cursors.Hand
        AddHandler btnLogout.Click, Sub()
                                        Form1.Show()
                                        Me.Close()
                                    End Sub
        pnlHeader.Controls.Add(btnLogout)

        ' Create scrollable content area
        pnlContent = New Panel()
        pnlContent.BackColor = Color.FromArgb(249, 250, 251)
        pnlContent.Size = New Size(1490, 910)
        pnlContent.Location = New Point(5, 85)
        pnlContent.AutoScroll = True
        Me.Controls.Add(pnlContent)

        ' Hero Section
        Dim pnlHero As New Panel()
        pnlHero.BackColor = Color.White
        pnlHero.Size = New Size(1480, 200)
        pnlHero.Location = New Point(0, 0)
        pnlContent.Controls.Add(pnlHero)

        Dim lblHeroTitle As New Label()
        lblHeroTitle.Text = "Find Your Perfect Loan Solution"
        lblHeroTitle.Font = New Font("Segoe UI", 32, FontStyle.Bold)
        lblHeroTitle.ForeColor = Color.FromArgb(15, 23, 42)
        lblHeroTitle.AutoSize = False
        lblHeroTitle.Location = New Point(40, 30)
        lblHeroTitle.Size = New Size(900, 70)
        lblHeroTitle.TextAlign = ContentAlignment.TopLeft
        pnlHero.Controls.Add(lblHeroTitle)

        Dim lblHeroSubtitle As New Label()
        lblHeroSubtitle.Text = "Compare the best loan offers from India's top banks. Fast approvals, transparent pricing, zero hidden charges."
        lblHeroSubtitle.Font = New Font("Segoe UI", 12)
        lblHeroSubtitle.ForeColor = Color.FromArgb(100, 116, 139)
        lblHeroSubtitle.AutoSize = False
        lblHeroSubtitle.Location = New Point(40, 110)
        lblHeroSubtitle.Size = New Size(900, 60)
        pnlHero.Controls.Add(lblHeroSubtitle)

        ' Award badges
        Dim lblBadge1 As New Label()
        lblBadge1.Text = "⭐ India's #1" & vbCrLf & "Loan Platform"
        lblBadge1.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        lblBadge1.ForeColor = Color.FromArgb(59, 130, 246)
        lblBadge1.AutoSize = False
        lblBadge1.TextAlign = ContentAlignment.MiddleCenter
        lblBadge1.Location = New Point(1000, 50)
        lblBadge1.Size = New Size(140, 60)
        pnlHero.Controls.Add(lblBadge1)

        Dim lblBadge2 As New Label()
        lblBadge2.Text = "🏆 Best Rates" & vbCrLf & "2025"
        lblBadge2.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        lblBadge2.ForeColor = Color.FromArgb(168, 85, 247)
        lblBadge2.AutoSize = False
        lblBadge2.TextAlign = ContentAlignment.MiddleCenter
        lblBadge2.Location = New Point(1200, 50)
        lblBadge2.Size = New Size(140, 60)
        pnlHero.Controls.Add(lblBadge2)

        ' Divider
        Dim lblDivider As New Label()
        lblDivider.BackColor = Color.FromArgb(226, 232, 240)
        lblDivider.Size = New Size(1480, 1)
        lblDivider.Location = New Point(0, 199)
        pnlHero.Controls.Add(lblDivider)

        Dim yPosition = 220

        ' Section Title
        Dim lblProductsTitle As New Label()
        lblProductsTitle.Text = "Our Loan Products"
        lblProductsTitle.Font = New Font("Segoe UI", 20, FontStyle.Bold)
        lblProductsTitle.ForeColor = Color.FromArgb(15, 23, 42)
        lblProductsTitle.AutoSize = False
        lblProductsTitle.Location = New Point(40, yPosition)
        lblProductsTitle.Size = New Size(400, 40)
        pnlContent.Controls.Add(lblProductsTitle)

        yPosition += 60

        ' Product Card 1 - Home Loans
        CreateProductCard(pnlContent, "🏠", "Home Loans", _
                         "Build Your Dream Home", _
                         "Starting from 6.4% p.a.", _
                         "₹50 Lakhs - ₹10 Crore", _
                         "3 companies available", _
                         40, yPosition, Color.FromArgb(59, 130, 246), "Home Loan")

        ' Product Card 2 - Bank Loans
        CreateProductCard(pnlContent, "🏦", "Bank Loans", _
                         "Instant Personal Loans", _
                         "Starting from 8.5% p.a.", _
                         "₹25,000 - ₹50 Lakhs", _
                         "Same day approval", _
                         540, yPosition, Color.FromArgb(34, 197, 94), "Bank Loan")

        ' Product Card 3 - Financial Loans
        CreateProductCard(pnlContent, "💰", "Financial Loans", _
                         "Business Expansion", _
                         "Starting from 9% p.a.", _
                         "₹1 Lakh - ₹1 Crore", _
                         "For entrepreneurs", _
                         1040, yPosition, Color.FromArgb(168, 85, 247), "Financial Loan")

        yPosition += 320

        ' Why Choose Us Section
        Dim lblWhyTitle As New Label()
        lblWhyTitle.Text = "Why Choose CredShield?"
        lblWhyTitle.Font = New Font("Segoe UI", 20, FontStyle.Bold)
        lblWhyTitle.ForeColor = Color.FromArgb(15, 23, 42)
        lblWhyTitle.AutoSize = False
        lblWhyTitle.Location = New Point(40, yPosition)
        lblWhyTitle.Size = New Size(600, 40)
        pnlContent.Controls.Add(lblWhyTitle)

        yPosition += 60

        ' Features Grid
        CreateFeatureBox(pnlContent, "⚡ Fast Approval", "Get approved in as little as 24 hours", 40, yPosition, Color.FromArgb(59, 130, 246))
        CreateFeatureBox(pnlContent, "💰 Best Rates", "Compare and get the lowest interest rates", 380, yPosition, Color.FromArgb(34, 197, 94))
        CreateFeatureBox(pnlContent, "📱 Digital Process", "100% online, no paperwork hassle", 720, yPosition, Color.FromArgb(168, 85, 247))
        CreateFeatureBox(pnlContent, "🔒 Secure", "Bank-level security & data protection", 1060, yPosition, Color.FromArgb(234, 179, 8))

        yPosition += 150

        ' Statistics Section
        Dim lblStatsTitle As New Label()
        lblStatsTitle.Text = "Trusted by Thousands"
        lblStatsTitle.Font = New Font("Segoe UI", 18, FontStyle.Bold)
        lblStatsTitle.ForeColor = Color.FromArgb(15, 23, 42)
        lblStatsTitle.AutoSize = False
        lblStatsTitle.Location = New Point(40, yPosition)
        lblStatsTitle.Size = New Size(1400, 30)
        lblStatsTitle.TextAlign = ContentAlignment.MiddleCenter
        pnlContent.Controls.Add(lblStatsTitle)

        yPosition += 50

        CreateStatBox(pnlContent, "50,000+", "Active Users", 80, yPosition)
        CreateStatBox(pnlContent, "₹5,000 Cr", "Loans Processed", 380, yPosition)
        CreateStatBox(pnlContent, "9/10", "Average Rating", 680, yPosition)
        CreateStatBox(pnlContent, "24/7", "Customer Support", 980, yPosition)

        yPosition += 120

        ' Call to Action
        Dim pnlCTA As New Panel()
        pnlCTA.BackColor = Color.White
        pnlCTA.Size = New Size(1400, 100)
        pnlCTA.Location = New Point(40, yPosition)
        pnlCTA.BorderStyle = BorderStyle.FixedSingle
        pnlContent.Controls.Add(pnlCTA)

        Dim lblCTATitle As New Label()
        lblCTATitle.Text = "Ready to Get Your Loan?"
        lblCTATitle.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        lblCTATitle.ForeColor = Color.FromArgb(15, 23, 42)
        lblCTATitle.AutoSize = True
        lblCTATitle.Location = New Point(30, 15)
        pnlCTA.Controls.Add(lblCTATitle)

        Dim lblCTADesc As New Label()
        lblCTADesc.Text = "Compare loans from top banks and apply instantly. It takes less than 5 minutes!"
        lblCTADesc.Font = New Font("Segoe UI", 11)
        lblCTADesc.ForeColor = Color.FromArgb(100, 116, 139)
        lblCTADesc.AutoSize = True
        lblCTADesc.Location = New Point(30, 45)
        pnlCTA.Controls.Add(lblCTADesc)

        Dim btnCTA As New Button()
        btnCTA.Text = "🚀 Explore Loans"
        btnCTA.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        btnCTA.BackColor = Color.FromArgb(59, 130, 246)
        btnCTA.ForeColor = Color.White
        btnCTA.FlatStyle = FlatStyle.Flat
        btnCTA.FlatAppearance.BorderSize = 0
        btnCTA.Size = New Size(150, 40)
        btnCTA.Location = New Point(1250, 30)
        btnCTA.Cursor = Cursors.Hand
        AddHandler btnCTA.Click, Sub()
                                     Dim comparisonForm As New FormLoanComparison()
                                     comparisonForm.Show()
                                     Me.Close()
                                 End Sub
        pnlCTA.Controls.Add(btnCTA)
    End Sub

    Private Sub CreateProductCard(panel As Panel, emoji As String, title As String, subtitle As String, _
                                 rate As String, amount As String, feature As String, x As Integer, _
                                 y As Integer, color As Color, loanType As String)
        Dim card As New Panel()
        card.BackColor = Color.White
        card.Size = New Size(400, 280)
        card.Location = New Point(x, y)
        card.BorderStyle = BorderStyle.FixedSingle
        panel.Controls.Add(card)

        ' Color header bar
        Dim pnlColorBar As New Panel()
        pnlColorBar.BackColor = color
        pnlColorBar.Size = New Size(400, 5)
        pnlColorBar.Location = New Point(0, 0)
        card.Controls.Add(pnlColorBar)

        ' Emoji
        Dim lblEmoji As New Label()
        lblEmoji.Text = emoji
        lblEmoji.Font = New Font("Arial", 36)
        lblEmoji.AutoSize = True
        lblEmoji.Location = New Point(20, 15)
        card.Controls.Add(lblEmoji)

        ' Title
        Dim lblTitle As New Label()
        lblTitle.Text = title
        lblTitle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(15, 23, 42)
        lblTitle.AutoSize = True
        lblTitle.Location = New Point(20, 65)
        card.Controls.Add(lblTitle)

        ' Subtitle
        Dim lblSubtitle As New Label()
        lblSubtitle.Text = subtitle
        lblSubtitle.Font = New Font("Segoe UI", 11)
        lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139)
        lblSubtitle.AutoSize = False
        lblSubtitle.Location = New Point(20, 90)
        lblSubtitle.Size = New Size(360, 30)
        card.Controls.Add(lblSubtitle)

        ' Rate
        Dim lblRate As New Label()
        lblRate.Text = rate
        lblRate.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        lblRate.ForeColor = color
        lblRate.AutoSize = True
        lblRate.Location = New Point(20, 130)
        card.Controls.Add(lblRate)

        ' Amount
        Dim lblAmount As New Label()
        lblAmount.Text = "✓ " & amount
        lblAmount.Font = New Font("Segoe UI", 10)
        lblAmount.ForeColor = Color.FromArgb(100, 116, 139)
        lblAmount.AutoSize = True
        lblAmount.Location = New Point(20, 155)
        card.Controls.Add(lblAmount)

        ' Feature
        Dim lblFeature As New Label()
        lblFeature.Text = "✓ " & feature
        lblFeature.Font = New Font("Segoe UI", 10)
        lblFeature.ForeColor = Color.FromArgb(100, 116, 139)
        lblFeature.AutoSize = True
        lblFeature.Location = New Point(20, 175)
        card.Controls.Add(lblFeature)

        ' Apply Button
        Dim btnApply As New Button()
        btnApply.Text = "→ Compare"
        btnApply.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnApply.BackColor = color
        btnApply.ForeColor = Color.White
        btnApply.FlatStyle = FlatStyle.Flat
        btnApply.FlatAppearance.BorderSize = 0
        btnApply.Size = New Size(360, 40)
        btnApply.Location = New Point(20, 220)
        btnApply.Cursor = Cursors.Hand
        AddHandler btnApply.Click, Sub()
                                       Dim comparisonForm As New FormLoanComparison()
                                       comparisonForm.Show()
                                       Me.Close()
                                   End Sub
        card.Controls.Add(btnApply)
    End Sub

    Private Sub CreateFeatureBox(panel As Panel, title As String, description As String, x As Integer, y As Integer, color As Color)
        Dim box As New Panel()
        box.BackColor = Color.White
        box.Size = New Size(320, 100)
        box.Location = New Point(x, y)
        box.BorderStyle = BorderStyle.FixedSingle
        panel.Controls.Add(box)

        Dim lblTitle As New Label()
        lblTitle.Text = title
        lblTitle.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        lblTitle.ForeColor = color
        lblTitle.AutoSize = False
        lblTitle.Location = New Point(15, 10)
        lblTitle.Size = New Size(290, 30)
        box.Controls.Add(lblTitle)

        Dim lblDesc As New Label()
        lblDesc.Text = description
        lblDesc.Font = New Font("Segoe UI", 9)
        lblDesc.ForeColor = Color.FromArgb(100, 116, 139)
        lblDesc.AutoSize = False
        lblDesc.Location = New Point(15, 40)
        lblDesc.Size = New Size(290, 50)
        box.Controls.Add(lblDesc)
    End Sub

    Private Sub CreateStatBox(panel As Panel, stat As String, label As String, x As Integer, y As Integer)
        Dim box As New Panel()
        box.BackColor = Color.White
        box.Size = New Size(280, 80)
        box.Location = New Point(x, y)
        box.BorderStyle = BorderStyle.FixedSingle
        panel.Controls.Add(box)

        Dim lblStat As New Label()
        lblStat.Text = stat
        lblStat.Font = New Font("Segoe UI", 18, FontStyle.Bold)
        lblStat.ForeColor = Color.FromArgb(59, 130, 246)
        lblStat.AutoSize = False
        lblStat.TextAlign = ContentAlignment.MiddleCenter
        lblStat.Location = New Point(0, 10)
        lblStat.Size = New Size(280, 35)
        box.Controls.Add(lblStat)

        Dim lblLabel As New Label()
        lblLabel.Text = label
        lblLabel.Font = New Font("Segoe UI", 10)
        lblLabel.ForeColor = Color.FromArgb(100, 116, 139)
        lblLabel.AutoSize = False
        lblLabel.TextAlign = ContentAlignment.MiddleCenter
        lblLabel.Location = New Point(0, 45)
        lblLabel.Size = New Size(280, 25)
        box.Controls.Add(lblLabel)
    End Sub
End Class
