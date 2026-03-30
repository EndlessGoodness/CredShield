Public Class FormClientHome
    Inherits Form

    Private bgImage As Image
    Private bgOpacity As Single = 0.3F
    Private currentUserId As Integer = 1

    Public Sub New()
        MyBase.New()
        Me.Text = "CredShield - Find Your Perfect Loan Solution"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(1200, 850)
        Me.BackColor = Color.White
        Me.DoubleBuffered = True
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False

        ' Load background image
        Try
            Dim possiblePaths As String() = {
                System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "background.png"),
                System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "background.png"),
                System.IO.Path.Combine(System.IO.Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName, "background.png")
            }

            For Each imagePath In possiblePaths
                If System.IO.File.Exists(imagePath) Then
                    bgImage = Image.FromFile(imagePath)
                    Exit For
                End If
            Next
        Catch
        End Try

        BuildUI()
    End Sub

    Private Sub BuildUI()
        ' Header Panel
        Dim pnlHeader As New Panel()
        pnlHeader.BackColor = Color.FromArgb(15, 23, 42)
        pnlHeader.Size = New Size(1200, 70)
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

        ' Logout Button
        Dim btnLogout As New Button()
        btnLogout.Text = "🚪 Logout"
        btnLogout.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnLogout.BackColor = Color.FromArgb(34, 197, 94)
        btnLogout.ForeColor = Color.White
        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.FlatAppearance.BorderSize = 0
        btnLogout.Size = New Size(110, 35)
        btnLogout.Location = New Point(1060, 18)
        btnLogout.Cursor = Cursors.Hand
        AddHandler btnLogout.Click, AddressOf LogoutClick
        pnlHeader.Controls.Add(btnLogout)

        ' Main Content Panel
        Dim pnlContent As New Panel()
        pnlContent.BackColor = Color.FromArgb(245, 245, 245)
        pnlContent.AutoScroll = True
        pnlContent.Size = New Size(1200, 780)
        pnlContent.Location = New Point(0, 70)
        Me.Controls.Add(pnlContent)

        ' Main Title
        Dim lblTitle As New Label()
        lblTitle.Text = "Find Your Perfect Loan Solution"
        lblTitle.Font = New Font("Segoe UI", 24, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(15, 23, 42)
        lblTitle.AutoSize = False
        lblTitle.TextAlign = ContentAlignment.MiddleCenter
        lblTitle.Location = New Point(0, 30)
        lblTitle.Size = New Size(1200, 40)
        pnlContent.Controls.Add(lblTitle)

        ' Subtitle
        Dim lblSubtitle As New Label()
        lblSubtitle.Text = "Compare the best loan offers from India's top banks. Fast approvals, transparent pricing, zero hidden charges."
        lblSubtitle.Font = New Font("Segoe UI", 10)
        lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139)
        lblSubtitle.AutoSize = False
        lblSubtitle.TextAlign = ContentAlignment.MiddleCenter
        lblSubtitle.Location = New Point(100, 75)
        lblSubtitle.Size = New Size(1000, 30)
        pnlContent.Controls.Add(lblSubtitle)

        ' Loan Products Section Title
        Dim lblLoanProducts As New Label()
        lblLoanProducts.Text = "Our Loan Products"
        lblLoanProducts.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblLoanProducts.ForeColor = Color.FromArgb(52, 73, 94)
        lblLoanProducts.AutoSize = True
        lblLoanProducts.Location = New Point(50, 120)
        pnlContent.Controls.Add(lblLoanProducts)

        ' Divider line
        Dim pnlDivider As New Panel()
        pnlDivider.BackColor = Color.FromArgb(34, 197, 94)
        pnlDivider.Size = New Size(60, 3)
        pnlDivider.Location = New Point(50, 145)
        pnlContent.Controls.Add(pnlDivider)

        ' Three Loan Type Buttons
        Dim loanTypes As String() = {"Home Loans", "Bank Loans", "Financial Loans"}
        Dim loanEmojis As String() = {"🏠", "💰", "📊"}
        Dim loanDescriptions As String() = {
            "Build Your Dream Home",
            "Instant Personal Loans",
            "Business Expansion"
        }
        Dim loanColors As Color() = {
            Color.FromArgb(59, 130, 246),
            Color.FromArgb(34, 197, 94),
            Color.FromArgb(168, 85, 247)
        }

        For i As Integer = 0 To 2
            ' Card Panel
            Dim pnlCard As New Panel()
            pnlCard.BackColor = Color.White
            pnlCard.BorderStyle = BorderStyle.FixedSingle
            pnlCard.Size = New Size(310, 180)
            pnlCard.Location = New Point(50 + (i * 340), 170)
            pnlCard.Cursor = Cursors.Hand
            pnlContent.Controls.Add(pnlCard)

            ' Colored Border
            Dim pnlBorder As New Panel()
            pnlBorder.BackColor = loanColors(i)
            pnlBorder.Size = New Size(310, 5)
            pnlBorder.Location = New Point(0, 0)
            pnlCard.Controls.Add(pnlBorder)

            ' Emoji/Icon
            Dim lblEmoji As New Label()
            lblEmoji.Text = loanEmojis(i)
            lblEmoji.Font = New Font("Segoe UI", 32)
            lblEmoji.AutoSize = False
            lblEmoji.TextAlign = ContentAlignment.MiddleCenter
            lblEmoji.Location = New Point(0, 20)
            lblEmoji.Size = New Size(310, 40)
            pnlCard.Controls.Add(lblEmoji)

            ' Loan Type Title
            Dim lblType As New Label()
            lblType.Text = loanTypes(i)
            lblType.Font = New Font("Segoe UI", 14, FontStyle.Bold)
            lblType.ForeColor = loanColors(i)
            lblType.AutoSize = False
            lblType.TextAlign = ContentAlignment.MiddleCenter
            lblType.Location = New Point(0, 65)
            lblType.Size = New Size(310, 25)
            pnlCard.Controls.Add(lblType)

            ' Description
            Dim lblDesc As New Label()
            lblDesc.Text = loanDescriptions(i)
            lblDesc.Font = New Font("Segoe UI", 9)
            lblDesc.ForeColor = Color.FromArgb(100, 116, 139)
            lblDesc.AutoSize = False
            lblDesc.TextAlign = ContentAlignment.MiddleCenter
            lblDesc.Location = New Point(10, 95)
            lblDesc.Size = New Size(290, 30)
            pnlCard.Controls.Add(lblDesc)

            ' Compare Button
            Dim btnCompare As New Button()
            btnCompare.Text = "🔍 Compare"
            btnCompare.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            btnCompare.BackColor = loanColors(i)
            btnCompare.ForeColor = Color.White
            btnCompare.FlatStyle = FlatStyle.Flat
            btnCompare.FlatAppearance.BorderSize = 0
            btnCompare.Size = New Size(270, 35)
            btnCompare.Location = New Point(20, 130)
            btnCompare.Cursor = Cursors.Hand
            Dim loanTypeIndex As Integer = i
            AddHandler btnCompare.Click, Sub(sender As Object, e As EventArgs) OpenLoanComparison(loanTypes(loanTypeIndex))
            pnlCard.Controls.Add(btnCompare)

            ' Click handlers for card
            AddHandler pnlCard.Click, Sub(sender As Object, e As EventArgs) OpenLoanComparison(loanTypes(loanTypeIndex))
            AddHandler lblType.Click, Sub(sender As Object, e As EventArgs) OpenLoanComparison(loanTypes(loanTypeIndex))
            AddHandler lblEmoji.Click, Sub(sender As Object, e As EventArgs) OpenLoanComparison(loanTypes(loanTypeIndex))
        Next

        ' Why Choose Section
        Dim lblWhyChoose As New Label()
        lblWhyChoose.Text = "Why Choose CredShield?"
        lblWhyChoose.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblWhyChoose.ForeColor = Color.FromArgb(52, 73, 94)
        lblWhyChoose.AutoSize = True
        lblWhyChoose.Location = New Point(50, 380)
        pnlContent.Controls.Add(lblWhyChoose)

        ' Why Choose Items
        Dim whyItems As String() = {"✓ Fast Approved", "✓ Best Rates", "✓ Digital Process", "✓ Secure"}
        Dim whyDescriptions As String() = {
            "Get approved in less than 2 hours",
            "Compare and get the lowest interest rates",
            "100% digital application process",
            "Bank-level data security guaranteed"
        }

        For i As Integer = 0 To 3
            Dim pnlItem As New Panel()
            pnlItem.BackColor = Color.White
            pnlItem.BorderStyle = BorderStyle.FixedSingle
            pnlItem.Size = New Size(250, 100)
            pnlItem.Location = New Point(50 + (i * 270), 410)
            pnlContent.Controls.Add(pnlItem)

            Dim lblItemTitle As New Label()
            lblItemTitle.Text = whyItems(i)
            lblItemTitle.Font = New Font("Segoe UI", 11, FontStyle.Bold)
            lblItemTitle.ForeColor = Color.FromArgb(34, 197, 94)
            lblItemTitle.AutoSize = False
            lblItemTitle.TextAlign = ContentAlignment.TopLeft
            lblItemTitle.Location = New Point(10, 10)
            lblItemTitle.Size = New Size(230, 25)
            pnlItem.Controls.Add(lblItemTitle)

            Dim lblItemDesc As New Label()
            lblItemDesc.Text = whyDescriptions(i)
            lblItemDesc.Font = New Font("Segoe UI", 8)
            lblItemDesc.ForeColor = Color.FromArgb(100, 116, 139)
            lblItemDesc.AutoSize = False
            lblItemDesc.TextAlign = ContentAlignment.TopLeft
            lblItemDesc.Location = New Point(10, 35)
            lblItemDesc.Size = New Size(230, 60)
            pnlItem.Controls.Add(lblItemDesc)
        Next

        ' Support Section
        Dim pnlSupport As New Panel()
        pnlSupport.BackColor = Color.FromArgb(15, 23, 42)
        pnlSupport.Size = New Size(1200, 120)
        pnlSupport.Location = New Point(0, 540)
        pnlContent.Controls.Add(pnlSupport)

        Dim lblSupport As New Label()
        lblSupport.Text = "Need Help? We're Here For You"
        lblSupport.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblSupport.ForeColor = Color.White
        lblSupport.AutoSize = False
        lblSupport.TextAlign = ContentAlignment.MiddleCenter
        lblSupport.Location = New Point(0, 15)
        lblSupport.Size = New Size(1200, 25)
        pnlSupport.Controls.Add(lblSupport)

        ' Feedback Button
        Dim btnFeedback As New Button()
        btnFeedback.Text = "💬 Send Feedback"
        btnFeedback.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnFeedback.BackColor = Color.FromArgb(34, 197, 94)
        btnFeedback.ForeColor = Color.White
        btnFeedback.FlatStyle = FlatStyle.Flat
        btnFeedback.FlatAppearance.BorderSize = 0
        btnFeedback.Size = New Size(150, 35)
        btnFeedback.Location = New Point(300, 50)
        btnFeedback.Cursor = Cursors.Hand
        AddHandler btnFeedback.Click, AddressOf SendFeedback
        pnlSupport.Controls.Add(btnFeedback)

        ' Query Button
        Dim btnQuery As New Button()
        btnQuery.Text = "❓ Submit Query"
        btnQuery.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnQuery.BackColor = Color.FromArgb(59, 130, 246)
        btnQuery.ForeColor = Color.White
        btnQuery.FlatStyle = FlatStyle.Flat
        btnQuery.FlatAppearance.BorderSize = 0
        btnQuery.Size = New Size(150, 35)
        btnQuery.Location = New Point(500, 50)
        btnQuery.Cursor = Cursors.Hand
        AddHandler btnQuery.Click, AddressOf SubmitQuery
        pnlSupport.Controls.Add(btnQuery)

        ' Wishlist Button
        Dim btnWishlist As New Button()
        btnWishlist.Text = "❤️ My Wishlist"
        btnWishlist.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnWishlist.BackColor = Color.FromArgb(168, 85, 247)
        btnWishlist.ForeColor = Color.White
        btnWishlist.FlatStyle = FlatStyle.Flat
        btnWishlist.FlatAppearance.BorderSize = 0
        btnWishlist.Size = New Size(150, 35)
        btnWishlist.Location = New Point(700, 50)
        btnWishlist.Cursor = Cursors.Hand
        AddHandler btnWishlist.Click, AddressOf ViewWishlist
        pnlSupport.Controls.Add(btnWishlist)

        ' Footer
        Dim lblFooter As New Label()
        lblFooter.Text = "© 2026 CredShield by GEE ASSOCIATES  |  Loans, Taxes & Financial Services"
        lblFooter.Font = New Font("Segoe UI", 8)
        lblFooter.ForeColor = Color.FromArgb(156, 163, 175)
        lblFooter.AutoSize = False
        lblFooter.TextAlign = ContentAlignment.MiddleCenter
        lblFooter.Location = New Point(0, 680)
        lblFooter.Size = New Size(1200, 30)
        pnlContent.Controls.Add(lblFooter)
    End Sub

    Private Sub OpenLoanComparison(loanType As String)
        Dim comparisonForm As New FormLoanTypeComparison(loanType, currentUserId)
        comparisonForm.ShowDialog(Me)
    End Sub

    Private Sub SendFeedback(sender As Object, e As EventArgs)
        Dim feedbackMsg As String = InputBox("Please share your feedback with us:", "Send Feedback")
        If Not String.IsNullOrWhiteSpace(feedbackMsg) Then
            DatabaseConnection.InsertFeedback(currentUserId, feedbackMsg)
            MessageBox.Show("Thank you for your feedback!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub SubmitQuery(sender As Object, e As EventArgs)
        Dim queryMsg As String = InputBox("Please enter your query:", "Submit Query")
        If Not String.IsNullOrWhiteSpace(queryMsg) Then
            DatabaseConnection.InsertQuery(currentUserId, queryMsg)
            MessageBox.Show("Your query has been submitted! We'll get back to you soon.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ViewWishlist(sender As Object, e As EventArgs)
        Dim wishlistForm As New FormWishlist()
        wishlistForm.ShowDialog(Me)
    End Sub

    Private Sub LogoutClick(sender As Object, e As EventArgs)
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Dim homeForm As New FormNewHome()
            homeForm.Show()
            Me.Close()
        End If
    End Sub

    Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
        If bgImage IsNot Nothing Then
            Dim cm As New System.Drawing.Imaging.ColorMatrix()
            cm.Matrix33 = bgOpacity
            Dim ia As New System.Drawing.Imaging.ImageAttributes()
            ia.SetColorMatrix(cm, System.Drawing.Imaging.ColorMatrixFlag.Default, System.Drawing.Imaging.ColorAdjustType.Bitmap)
            e.Graphics.DrawImage(bgImage,
                New Rectangle(0, 0, Me.Width, Me.Height),
                0, 0, bgImage.Width, bgImage.Height,
                GraphicsUnit.Pixel, ia)
        Else
            e.Graphics.Clear(Color.White)
        End If
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
    End Sub

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            If bgImage IsNot Nothing Then
                bgImage.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
End Class
