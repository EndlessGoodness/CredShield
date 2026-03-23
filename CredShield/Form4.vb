Public Class Form4
    ' Home Page (Main Dashboard) for CredShield Application

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set form properties
        Me.Text = "CredShield - Home"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(1200, 800)
        Me.BackColor = Color.FromArgb(236, 240, 241)

        ' Create main panel for header
        Dim pnlHeader As New Panel()
        pnlHeader.BackColor = Color.FromArgb(41, 128, 185)
        pnlHeader.Size = New Size(1200, 70)
        pnlHeader.Location = New Point(0, 0)
        Me.Controls.Add(pnlHeader)

        ' Create logo/company name in header
        Dim lblLogo As New Label()
        lblLogo.Text = "CredShield"
        lblLogo.Font = New Font("Arial", 20, FontStyle.Bold)
        lblLogo.ForeColor = Color.White
        lblLogo.AutoSize = True
        lblLogo.Location = New Point(20, 15)
        pnlHeader.Controls.Add(lblLogo)

        ' Create tagline in header
        Dim lblTagline As New Label()
        lblTagline.Text = "Your Trusted Financial Advisor - Loans & Taxes"
        lblTagline.Font = New Font("Arial", 10)
        lblTagline.ForeColor = Color.White
        lblTagline.AutoSize = True
        lblTagline.Location = New Point(150, 22)
        pnlHeader.Controls.Add(lblTagline)

        ' Create Logout button in header
        Dim btnLogout As New Button()
        btnLogout.Text = "Logout"
        btnLogout.Font = New Font("Arial", 10, FontStyle.Bold)
        btnLogout.BackColor = Color.White
        btnLogout.ForeColor = Color.FromArgb(41, 128, 185)
        btnLogout.Size = New Size(80, 30)
        btnLogout.Location = New Point(1100, 20)
        btnLogout.Cursor = Cursors.Hand
        AddHandler btnLogout.Click, Sub()
                                        Form1.Show()
                                        Me.Hide()
                                    End Sub
        pnlHeader.Controls.Add(btnLogout)

        ' Create loan type buttons panel
        Dim pnlLoanButtons As New Panel()
        pnlLoanButtons.BackColor = Color.FromArgb(52, 73, 94)
        pnlLoanButtons.Size = New Size(1200, 100)
        pnlLoanButtons.Location = New Point(0, 70)
        Me.Controls.Add(pnlLoanButtons)

        ' Create title for loan section
        Dim lblLoanTitle As New Label()
        lblLoanTitle.Text = "Select a Loan Type to Apply"
        lblLoanTitle.Font = New Font("Arial", 14, FontStyle.Bold)
        lblLoanTitle.ForeColor = Color.White
        lblLoanTitle.AutoSize = True
        lblLoanTitle.Location = New Point(30, 10)
        pnlLoanButtons.Controls.Add(lblLoanTitle)

        ' Create Home Loans button
        Dim btnHomeLoan As New Button()
        btnHomeLoan.Text = "HOME LOANS"
        btnHomeLoan.Font = New Font("Arial", 12, FontStyle.Bold)
        btnHomeLoan.BackColor = Color.FromArgb(41, 128, 185)
        btnHomeLoan.ForeColor = Color.White
        btnHomeLoan.Size = New Size(300, 60)
        btnHomeLoan.Location = New Point(50, 35)
        btnHomeLoan.Cursor = Cursors.Hand
        AddHandler btnHomeLoan.Click, Sub()
                                          LoanManager.SelectedLoanType = "Home Loan"
                                          Form5.Show()
                                          Me.Hide()
                                      End Sub
        pnlLoanButtons.Controls.Add(btnHomeLoan)

        ' Create Bank Loans button
        Dim btnBankLoan As New Button()
        btnBankLoan.Text = "BANK LOANS"
        btnBankLoan.Font = New Font("Arial", 12, FontStyle.Bold)
        btnBankLoan.BackColor = Color.FromArgb(46, 204, 113)
        btnBankLoan.ForeColor = Color.White
        btnBankLoan.Size = New Size(300, 60)
        btnBankLoan.Location = New Point(450, 35)
        btnBankLoan.Cursor = Cursors.Hand
        AddHandler btnBankLoan.Click, Sub()
                                          LoanManager.SelectedLoanType = "Bank Loan"
                                          Form5.Show()
                                          Me.Hide()
                                      End Sub
        pnlLoanButtons.Controls.Add(btnBankLoan)

        ' Create Financial Loans button
        Dim btnFinancialLoan As New Button()
        btnFinancialLoan.Text = "FINANCIAL LOANS"
        btnFinancialLoan.Font = New Font("Arial", 12, FontStyle.Bold)
        btnFinancialLoan.BackColor = Color.FromArgb(155, 89, 182)
        btnFinancialLoan.ForeColor = Color.White
        btnFinancialLoan.Size = New Size(300, 60)
        btnFinancialLoan.Location = New Point(850, 35)
        btnFinancialLoan.Cursor = Cursors.Hand
        AddHandler btnFinancialLoan.Click, Sub()
                                               LoanManager.SelectedLoanType = "Financial Loan"
                                               Form5.Show()
                                               Me.Hide()
                                           End Sub
        pnlLoanButtons.Controls.Add(btnFinancialLoan)

        ' Create main content panel
        Dim pnlContent As New Panel()
        pnlContent.BackColor = Color.FromArgb(236, 240, 241)
        pnlContent.Size = New Size(1200, 630)
        pnlContent.Location = New Point(0, 170)
        pnlContent.AutoScroll = True
        Me.Controls.Add(pnlContent)

        ' Create About CredShield section
        Dim lblAboutTitle As New Label()
        lblAboutTitle.Text = "About CredShield"
        lblAboutTitle.Font = New Font("Arial", 16, FontStyle.Bold)
        lblAboutTitle.ForeColor = Color.FromArgb(41, 128, 185)
        lblAboutTitle.AutoSize = True
        lblAboutTitle.Location = New Point(30, 20)
        pnlContent.Controls.Add(lblAboutTitle)

        ' Create About CredShield description
        Dim lblAboutDesc As New Label()
        lblAboutDesc.Text = "A reliable and user-friendly platform designed to simplify the process of accessing loans and financial services. " & _
                           "We are committed to helping individuals achieve their financial goals by providing a wide range of loan options tailored to meet diverse needs." & vbCrLf & vbCrLf & _
                           "At CREDSHIELD, we specialize in offering Home Loans, Bank Loans, and Financial Loans, ensuring that every user finds the right solution for their requirements. " & _
                           "Whether you are planning to buy your dream home, manage personal expenses, or expand your financial opportunities, our platform makes the process quick, secure, and efficient." & vbCrLf & vbCrLf & _
                           "Our system is designed with a focus on ease of use, transparency, and speed, allowing users to apply for loans seamlessly through a structured and guided process. " & _
                           "We aim to empower users by providing accessible financial solutions, reducing complexity, and delivering a trustworthy digital experience."
        lblAboutDesc.Font = New Font("Arial", 10)
        lblAboutDesc.ForeColor = Color.FromArgb(52, 73, 94)
        lblAboutDesc.AutoSize = False
        lblAboutDesc.Location = New Point(30, 50)
        lblAboutDesc.Size = New Size(1100, 140)
        pnlContent.Controls.Add(lblAboutDesc)

        ' Create Services section
        Dim lblServicesTitle As New Label()
        lblServicesTitle.Text = "Our Services"
        lblServicesTitle.Font = New Font("Arial", 14, FontStyle.Bold)
        lblServicesTitle.ForeColor = Color.FromArgb(41, 128, 185)
        lblServicesTitle.AutoSize = True
        lblServicesTitle.Location = New Point(30, 200)
        pnlContent.Controls.Add(lblServicesTitle)

        ' Service Card 1 - Home Loans
        Dim pnlService1 As New Panel()
        pnlService1.BackColor = Color.White
        pnlService1.Size = New Size(1100, 200)
        pnlService1.Location = New Point(30, 230)
        pnlService1.BorderStyle = BorderStyle.FixedSingle
        pnlContent.Controls.Add(pnlService1)

        Dim lblService1 As New Label()
        lblService1.Text = "🏠 HOME LOAN – Build Your Dream Home"
        lblService1.Font = New Font("Arial", 12, FontStyle.Bold)
        lblService1.ForeColor = Color.FromArgb(41, 128, 185)
        lblService1.AutoSize = False
        lblService1.TextAlign = ContentAlignment.MiddleLeft
        lblService1.Location = New Point(10, 10)
        lblService1.Size = New Size(1080, 30)
        pnlService1.Controls.Add(lblService1)

        Dim lblService1Desc As New Label()
        lblService1Desc.Text = "At CREDSHIELD, our Home Loan services are designed to help you turn your dream of owning a home into reality. " & _
                              "Whether you are purchasing a new house, constructing a property, or renovating your existing home, we provide flexible loan options with easy repayment plans." & vbCrLf & vbCrLf & _
                              "We focus on making the process simple and transparent, ensuring quick approvals and minimal documentation. " & _
                              "With competitive interest rates and customer-friendly terms, CREDSHIELD supports you at every step of your homeownership journey."
        lblService1Desc.Font = New Font("Arial", 9)
        lblService1Desc.ForeColor = Color.FromArgb(52, 73, 94)
        lblService1Desc.AutoSize = False
        lblService1Desc.Location = New Point(10, 45)
        lblService1Desc.Size = New Size(1080, 145)
        pnlService1.Controls.Add(lblService1Desc)

        ' Service Card 2 - Bank Loans
        Dim pnlService2 As New Panel()
        pnlService2.BackColor = Color.White
        pnlService2.Size = New Size(1100, 200)
        pnlService2.Location = New Point(30, 450)
        pnlService2.BorderStyle = BorderStyle.FixedSingle
        pnlContent.Controls.Add(pnlService2)

        Dim lblService2 As New Label()
        lblService2.Text = "🏦 BANK LOAN – Trusted and Secure Lending"
        lblService2.Font = New Font("Arial", 12, FontStyle.Bold)
        lblService2.ForeColor = Color.FromArgb(46, 204, 113)
        lblService2.AutoSize = False
        lblService2.TextAlign = ContentAlignment.MiddleLeft
        lblService2.Location = New Point(10, 10)
        lblService2.Size = New Size(1080, 30)
        pnlService2.Controls.Add(lblService2)

        Dim lblService2Desc As New Label()
        lblService2Desc.Text = "Our Bank Loan services at CREDSHIELD are designed to provide users with reliable and secure loan options in collaboration with trusted banking systems. " & _
                              "These loans are ideal for larger financial needs such as business expansion, investments, or long-term planning." & vbCrLf & vbCrLf & _
                              "We ensure that all bank loan processes are handled with high security, proper verification, and transparency. " & _
                              "CREDSHIELD acts as a bridge between users and structured banking services, making loan access easier and more efficient."
        lblService2Desc.Font = New Font("Arial", 9)
        lblService2Desc.ForeColor = Color.FromArgb(52, 73, 94)
        lblService2Desc.AutoSize = False
        lblService2Desc.Location = New Point(10, 45)
        lblService2Desc.Size = New Size(1080, 145)
        pnlService2.Controls.Add(lblService2Desc)

        ' Service Card 3 - Financial Loans
        Dim pnlService3 As New Panel()
        pnlService3.BackColor = Color.White
        pnlService3.Size = New Size(1100, 200)
        pnlService3.Location = New Point(30, 670)
        pnlService3.BorderStyle = BorderStyle.FixedSingle
        pnlContent.Controls.Add(pnlService3)

        Dim lblService3 As New Label()
        lblService3.Text = "💰 FINANCIAL LOAN – Manage Your Personal Needs"
        lblService3.Font = New Font("Arial", 12, FontStyle.Bold)
        lblService3.ForeColor = Color.FromArgb(155, 89, 182)
        lblService3.AutoSize = False
        lblService3.TextAlign = ContentAlignment.MiddleLeft
        lblService3.Location = New Point(10, 10)
        lblService3.Size = New Size(1080, 30)
        pnlService3.Controls.Add(lblService3)

        Dim lblService3Desc As New Label()
        lblService3Desc.Text = "CREDSHIELD offers Financial Loans to help you meet your personal and urgent financial requirements. " & _
                              "Whether it's for education, medical expenses, travel, or any other personal need, our financial loans provide quick access to funds when you need them the most." & vbCrLf & vbCrLf & _
                              "Our system ensures a smooth and hassle-free application process, allowing users to apply easily and receive fast responses. " & _
                              "With flexible repayment options and secure processing, we aim to make financial support accessible to everyone."
        lblService3Desc.Font = New Font("Arial", 9)
        lblService3Desc.ForeColor = Color.FromArgb(52, 73, 94)
        lblService3Desc.AutoSize = False
        lblService3Desc.Location = New Point(10, 45)
        lblService3Desc.Size = New Size(1080, 145)
        pnlService3.Controls.Add(lblService3Desc)

        ' Create Why Choose Us section
        Dim lblWhyTitle As New Label()
        lblWhyTitle.Text = "Why Choose CredShield?"
        lblWhyTitle.Font = New Font("Arial", 14, FontStyle.Bold)
        lblWhyTitle.ForeColor = Color.FromArgb(41, 128, 185)
        lblWhyTitle.AutoSize = True
        lblWhyTitle.Location = New Point(30, 890)
        pnlContent.Controls.Add(lblWhyTitle)

        ' Features ListBox
        Dim lstFeatures As New ListBox()
        lstFeatures.Location = New Point(30, 920)
        lstFeatures.Size = New Size(1100, 120)
        lstFeatures.Font = New Font("Arial", 10)
        lstFeatures.Items.Add("✓ Expert Financial Advisors with extensive industry experience")
        lstFeatures.Items.Add("✓ Fast Approval Process - Get approved in 24-48 hours")
        lstFeatures.Items.Add("✓ Competitive Interest Rates and Flexible Payment Options")
        lstFeatures.Items.Add("✓ Transparent Pricing - No hidden charges or surprises")
        lstFeatures.Items.Add("✓ 24/7 Customer Support and Dedicated Account Manager")
        pnlContent.Controls.Add(lstFeatures)
    End Sub
End Class
