Public Class Form4
    ' Home Page (Main Dashboard) for CredShield Application

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set form properties
        Me.Text = "CredShield - Home"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(1400, 900)
        Me.BackColor = Color.FromArgb(236, 240, 241)
        Me.DoubleBuffered = True

        ' Create gradient header panel
        Dim pnlHeader As New Panel()
        pnlHeader.BackColor = Color.FromArgb(41, 128, 185)
        pnlHeader.Size = New Size(1400, 70)
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Padding = New Padding(20)
        Me.Controls.Add(pnlHeader)

        ' Create logo/company name in header
        Dim lblLogo As New Label()
        lblLogo.Text = "💼 CredShield"
        lblLogo.Font = New Font("Segoe UI", 20, FontStyle.Bold)
        lblLogo.ForeColor = Color.White
        lblLogo.AutoSize = True
        lblLogo.Location = New Point(20, 12)
        pnlHeader.Controls.Add(lblLogo)

        ' Create tagline in header
        Dim lblTagline As New Label()
        lblTagline.Text = "Your Trusted Financial Advisor - Loans & Taxes"
        lblTagline.Font = New Font("Segoe UI", 10)
        lblTagline.ForeColor = Color.FromArgb(200, 220, 240)
        lblTagline.AutoSize = True
        lblTagline.Location = New Point(180, 22)
        pnlHeader.Controls.Add(lblTagline)

        ' Create Logout button in header with better styling
        Dim btnLogout As New Button()
        btnLogout.Text = "🚪 Logout"
        btnLogout.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnLogout.BackColor = Color.White
        btnLogout.ForeColor = Color.FromArgb(41, 128, 185)
        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.FlatAppearance.BorderSize = 0
        btnLogout.Size = New Size(100, 30)
        btnLogout.Location = New Point(1290, 20)
        btnLogout.Cursor = Cursors.Hand
        AddHandler btnLogout.Click, Sub()
                                        Form1.Show()
                                        Me.Hide()
                                    End Sub
        pnlHeader.Controls.Add(btnLogout)

        ' Create loan type buttons panel with subtle gradient
        Dim pnlLoanButtons As New Panel()
        pnlLoanButtons.BackColor = Color.FromArgb(52, 73, 94)
        pnlLoanButtons.Size = New Size(1400, 90)
        pnlLoanButtons.Location = New Point(0, 70)
        pnlLoanButtons.Padding = New Padding(20)
        Me.Controls.Add(pnlLoanButtons)

        ' Create title for loan section
        Dim lblLoanTitle As New Label()
        lblLoanTitle.Text = "📊 Select a Loan Type"
        lblLoanTitle.Font = New Font("Segoe UI", 13, FontStyle.Bold)
        lblLoanTitle.ForeColor = Color.White
        lblLoanTitle.AutoSize = True
        lblLoanTitle.Location = New Point(20, 5)
        pnlLoanButtons.Controls.Add(lblLoanTitle)

        ' Create Home Loans button with hover effect
        Dim btnHomeLoan As New Button()
        btnHomeLoan.Text = "🏠 HOME LOANS"
        btnHomeLoan.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnHomeLoan.BackColor = Color.FromArgb(41, 128, 185)
        btnHomeLoan.ForeColor = Color.White
        btnHomeLoan.FlatStyle = FlatStyle.Flat
        btnHomeLoan.FlatAppearance.BorderSize = 0
        btnHomeLoan.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 100, 160)
        btnHomeLoan.Size = New Size(280, 50)
        btnHomeLoan.Location = New Point(20, 35)
        btnHomeLoan.Cursor = Cursors.Hand
        AddHandler btnHomeLoan.Click, Sub()
                                          LoanManager.SelectedLoanType = "Home Loan"
                                          Dim comparisonForm As New FormLoanComparison()
                                          comparisonForm.Show()
                                          Me.Hide()
                                      End Sub
        pnlLoanButtons.Controls.Add(btnHomeLoan)

        ' Create Bank Loans button
        Dim btnBankLoan As New Button()
        btnBankLoan.Text = "🏦 BANK LOANS"
        btnBankLoan.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnBankLoan.BackColor = Color.FromArgb(46, 204, 113)
        btnBankLoan.ForeColor = Color.White
        btnBankLoan.FlatStyle = FlatStyle.Flat
        btnBankLoan.FlatAppearance.BorderSize = 0
        btnBankLoan.FlatAppearance.MouseOverBackColor = Color.FromArgb(35, 160, 85)
        btnBankLoan.Size = New Size(280, 50)
        btnBankLoan.Location = New Point(560, 35)
        btnBankLoan.Cursor = Cursors.Hand
        AddHandler btnBankLoan.Click, Sub()
                                          LoanManager.SelectedLoanType = "Bank Loan"
                                          Dim comparisonForm As New FormLoanComparison()
                                          comparisonForm.Show()
                                          Me.Hide()
                                      End Sub
        pnlLoanButtons.Controls.Add(btnBankLoan)

        ' Create Financial Loans button
        Dim btnFinancialLoan As New Button()
        btnFinancialLoan.Text = "💰 FINANCIAL LOANS"
        btnFinancialLoan.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnFinancialLoan.BackColor = Color.FromArgb(155, 89, 182)
        btnFinancialLoan.ForeColor = Color.White
        btnFinancialLoan.FlatStyle = FlatStyle.Flat
        btnFinancialLoan.FlatAppearance.BorderSize = 0
        btnFinancialLoan.FlatAppearance.MouseOverBackColor = Color.FromArgb(130, 70, 160)
        btnFinancialLoan.Size = New Size(280, 50)
        btnFinancialLoan.Location = New Point(1100, 35)
        btnFinancialLoan.Cursor = Cursors.Hand
        AddHandler btnFinancialLoan.Click, Sub()
                                               LoanManager.SelectedLoanType = "Financial Loan"
                                               Dim comparisonForm As New FormLoanComparison()
                                               comparisonForm.Show()
                                               Me.Hide()
                                           End Sub
        pnlLoanButtons.Controls.Add(btnFinancialLoan)

        ' Create main content panel with scrollbar
        Dim pnlContent As New Panel()
        pnlContent.BackColor = Color.FromArgb(236, 240, 241)
        pnlContent.Size = New Size(1390, 745)
        pnlContent.Location = New Point(5, 165)
        pnlContent.AutoScroll = True
        Me.Controls.Add(pnlContent)

        ' Create About CredShield section with better styling
        Dim lblAboutTitle As New Label()
        lblAboutTitle.Text = "Welcome to CREDSHIELD"
        lblAboutTitle.Font = New Font("Segoe UI", 15, FontStyle.Bold)
        lblAboutTitle.ForeColor = Color.FromArgb(41, 128, 185)
        lblAboutTitle.AutoSize = True
        lblAboutTitle.Location = New Point(20, 15)
        pnlContent.Controls.Add(lblAboutTitle)

        ' Create About CredShield description with improved formatting
        Dim lblAboutDesc As New Label()
        lblAboutDesc.Text = "A reliable and user-friendly platform designed to simplify the process of accessing loans and financial services. " & _
                           "We are committed to helping individuals achieve their financial goals by providing a wide range of loan options tailored to meet diverse needs."
        lblAboutDesc.Font = New Font("Segoe UI", 9.5)
        lblAboutDesc.ForeColor = Color.FromArgb(52, 73, 94)
        lblAboutDesc.AutoSize = False
        lblAboutDesc.Location = New Point(20, 45)
        lblAboutDesc.Size = New Size(1340, 70)
        pnlContent.Controls.Add(lblAboutDesc)

        ' Create Services section with improved styling
        Dim lblServicesTitle As New Label()
        lblServicesTitle.Text = "📋 Our Services"
        lblServicesTitle.Font = New Font("Segoe UI", 13, FontStyle.Bold)
        lblServicesTitle.ForeColor = Color.FromArgb(41, 128, 185)
        lblServicesTitle.AutoSize = True
        lblServicesTitle.Location = New Point(20, 125)
        pnlContent.Controls.Add(lblServicesTitle)

        ' Service Card 1 - Home Loans with improved design
        Dim pnlService1 As New Panel()
        pnlService1.BackColor = Color.White
        pnlService1.Size = New Size(1340, 140)
        pnlService1.Location = New Point(20, 160)
        pnlService1.BorderStyle = BorderStyle.FixedSingle
        pnlService1.Padding = New Padding(12)
        pnlContent.Controls.Add(pnlService1)

        Dim lblService1 As New Label()
        lblService1.Text = "🏠 HOME LOAN – Build Your Dream Home"
        lblService1.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        lblService1.ForeColor = Color.FromArgb(41, 128, 185)
        lblService1.AutoSize = False
        lblService1.Location = New Point(0, 0)
        lblService1.Size = New Size(1340, 25)
        pnlService1.Controls.Add(lblService1)

        Dim lblService1Desc As New Label()
        lblService1Desc.Text = "At CREDSHIELD, our Home Loan services help you own your dream home. We provide flexible loan options with easy repayment plans, " & _
                              "quick approvals and minimal documentation. With competitive interest rates and customer-friendly terms, we support you every step of the way."
        lblService1Desc.Font = New Font("Segoe UI", 9)
        lblService1Desc.ForeColor = Color.FromArgb(52, 73, 94)
        lblService1Desc.AutoSize = False
        lblService1Desc.Location = New Point(0, 28)
        lblService1Desc.Size = New Size(1340, 110)
        pnlService1.Controls.Add(lblService1Desc)

        ' Service Card 2 - Bank Loans
        Dim pnlService2 As New Panel()
        pnlService2.BackColor = Color.White
        pnlService2.Size = New Size(1340, 140)
        pnlService2.Location = New Point(20, 310)
        pnlService2.BorderStyle = BorderStyle.FixedSingle
        pnlService2.Padding = New Padding(12)
        pnlContent.Controls.Add(pnlService2)

        Dim lblService2 As New Label()
        lblService2.Text = "🏦 BANK LOAN – Trusted and Secure Lending"
        lblService2.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        lblService2.ForeColor = Color.FromArgb(46, 204, 113)
        lblService2.AutoSize = False
        lblService2.Location = New Point(0, 0)
        lblService2.Size = New Size(1340, 25)
        pnlService2.Controls.Add(lblService2)

        Dim lblService2Desc As New Label()
        lblService2Desc.Text = "Our Bank Loan services provide reliable and secure loan options in collaboration with trusted banking systems. " & _
                              "Ideal for business expansion, investments, and long-term planning. We ensure high security, proper verification, and transparency throughout the process."
        lblService2Desc.Font = New Font("Segoe UI", 9)
        lblService2Desc.ForeColor = Color.FromArgb(52, 73, 94)
        lblService2Desc.AutoSize = False
        lblService2Desc.Location = New Point(0, 28)
        lblService2Desc.Size = New Size(1340, 110)
        pnlService2.Controls.Add(lblService2Desc)

        ' Service Card 3 - Financial Loans
        Dim pnlService3 As New Panel()
        pnlService3.BackColor = Color.White
        pnlService3.Size = New Size(1340, 140)
        pnlService3.Location = New Point(20, 460)
        pnlService3.BorderStyle = BorderStyle.FixedSingle
        pnlService3.Padding = New Padding(12)
        pnlContent.Controls.Add(pnlService3)

        Dim lblService3 As New Label()
        lblService3.Text = "💰 FINANCIAL LOAN – Manage Your Personal Needs"
        lblService3.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        lblService3.ForeColor = Color.FromArgb(155, 89, 182)
        lblService3.AutoSize = False
        lblService3.Location = New Point(0, 0)
        lblService3.Size = New Size(1340, 25)
        pnlService3.Controls.Add(lblService3)

        Dim lblService3Desc As New Label()
        lblService3Desc.Text = "We offer Financial Loans to meet your personal and urgent financial requirements. " & _
                              "Whether for education, medical expenses, or travel, we provide quick access to funds. Our smooth application process ensures fast responses with flexible repayment options."
        lblService3Desc.Font = New Font("Segoe UI", 9)
        lblService3Desc.ForeColor = Color.FromArgb(52, 73, 94)
        lblService3Desc.AutoSize = False
        lblService3Desc.Location = New Point(0, 28)
        lblService3Desc.Size = New Size(1340, 110)
        pnlService3.Controls.Add(lblService3Desc)

        ' Create Why Choose Us section
        Dim lblWhyTitle As New Label()
        lblWhyTitle.Text = "⭐ Why Choose CredShield?"
        lblWhyTitle.Font = New Font("Segoe UI", 13, FontStyle.Bold)
        lblWhyTitle.ForeColor = Color.FromArgb(41, 128, 185)
        lblWhyTitle.AutoSize = True
        lblWhyTitle.Location = New Point(20, 610)
        pnlContent.Controls.Add(lblWhyTitle)

        ' Features ListBox with enhanced styling
        Dim lstFeatures As New ListBox()
        lstFeatures.Location = New Point(20, 645)
        lstFeatures.Size = New Size(1340, 120)
        lstFeatures.Font = New Font("Segoe UI", 9)
        lstFeatures.BackColor = Color.White
        lstFeatures.BorderStyle = BorderStyle.FixedSingle
        lstFeatures.Items.Add("✓ Expert Financial Advisors with extensive industry experience")
        lstFeatures.Items.Add("✓ Fast Approval Process - Get approved in 24-48 hours")
        lstFeatures.Items.Add("✓ Competitive Interest Rates and Flexible Payment Options")
        lstFeatures.Items.Add("✓ Transparent Pricing - No hidden charges or surprises")
        lstFeatures.Items.Add("✓ 24/7 Customer Support and Dedicated Account Manager")
        pnlContent.Controls.Add(lstFeatures)

    End Sub
End Class
