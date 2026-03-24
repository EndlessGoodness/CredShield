Public Class FormLoanRegistration
    Inherits Form

    Private userId As Integer
    Private loanType As String
    Private userName As String
    Private txtCompany As TextBox
    Private txtAmount As TextBox
    Private txtQuery As TextBox

    Public Sub New(uId As Integer, lType As String, uName As String)
        MyBase.New()
        userId = uId
        loanType = lType
        userName = uName
        Me.Text = loanType & " Registration"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(700, 800)
        Me.BackColor = Color.FromArgb(249, 250, 251)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        BuildUI()
    End Sub

    Private Sub BuildUI()
        ' Header
        Dim pnlHeader As New Panel()
        pnlHeader.BackColor = Color.FromArgb(59, 130, 246)
        pnlHeader.Size = New Size(700, 60)
        pnlHeader.Location = New Point(0, 0)
        Me.Controls.Add(pnlHeader)

        Dim lblTitle As New Label()
        lblTitle.Text = "📝 " & loanType & " Registration"
        lblTitle.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.AutoSize = False
        lblTitle.TextAlign = ContentAlignment.MiddleCenter
        lblTitle.Location = New Point(0, 10)
        lblTitle.Size = New Size(700, 40)
        pnlHeader.Controls.Add(lblTitle)

        ' Main content
        Dim pnlContent As New Panel()
        pnlContent.BackColor = Color.White
        pnlContent.Size = New Size(680, 720)
        pnlContent.Location = New Point(10, 70)
        pnlContent.BorderStyle = BorderStyle.FixedSingle
        pnlContent.AutoScroll = True
        Me.Controls.Add(pnlContent)

        Dim yPos = 20

        ' Company selection
        Dim lblCompany As New Label()
        lblCompany.Text = "🏢 Select Company:"
        lblCompany.Font = New Font("Segoe UI", 10)
        lblCompany.ForeColor = Color.FromArgb(52, 73, 94)
        lblCompany.AutoSize = True
        lblCompany.Location = New Point(20, yPos)
        pnlContent.Controls.Add(lblCompany)

        yPos += 25
        Dim cmbCompany As New ComboBox()
        cmbCompany.Location = New Point(20, yPos)
        cmbCompany.Size = New Size(640, 30)
        cmbCompany.Font = New Font("Segoe UI", 10)
        cmbCompany.DropDownStyle = ComboBoxStyle.DropDownList
        
        ' Get companies for loan type
        Dim companies = LoanOffersDatabase.GetCompaniesForLoanType(loanType)
        For Each company In companies
            cmbCompany.Items.Add(company)
        Next
        If cmbCompany.Items.Count > 0 Then
            cmbCompany.SelectedIndex = 0
        End If
        
        pnlContent.Controls.Add(cmbCompany)

        yPos += 40

        ' Loan Amount
        Dim lblAmount As New Label()
        lblAmount.Text = "💰 Loan Amount (₹):"
        lblAmount.Font = New Font("Segoe UI", 10)
        lblAmount.ForeColor = Color.FromArgb(52, 73, 94)
        lblAmount.AutoSize = True
        lblAmount.Location = New Point(20, yPos)
        pnlContent.Controls.Add(lblAmount)

        yPos += 25
        txtAmount = New TextBox()
        txtAmount.Location = New Point(20, yPos)
        txtAmount.Size = New Size(640, 30)
        txtAmount.Font = New Font("Segoe UI", 10)
        txtAmount.BorderStyle = BorderStyle.FixedSingle
        txtAmount.Text = ""
        pnlContent.Controls.Add(txtAmount)

        yPos += 40

        ' Offer details (read-only)
        Dim lblOfferDetails As New Label()
        lblOfferDetails.Text = "📊 Offer Details:"
        lblOfferDetails.Font = New Font("Segoe UI", 10)
        lblOfferDetails.ForeColor = Color.FromArgb(52, 73, 94)
        lblOfferDetails.AutoSize = True
        lblOfferDetails.Location = New Point(20, yPos)
        pnlContent.Controls.Add(lblOfferDetails)

        yPos += 25
        Dim txtOffers As New TextBox()
        txtOffers.Location = New Point(20, yPos)
        txtOffers.Size = New Size(640, 100)
        txtOffers.Font = New Font("Segoe UI", 9)
        txtOffers.Multiline = True
        txtOffers.ReadOnly = True
        txtOffers.BorderStyle = BorderStyle.FixedSingle
        
        Dim offers = LoanOffersDatabase.GetLoanOffersByType(loanType)
        If offers.Count > 0 Then
            Dim offerText = ""
            For Each offer In offers.Take(3)
                offerText &= $"{offer.CompanyName}: {offer.InterestRateMin}%-{offer.InterestRateMax}% | {offer.ApprovalTime}{vbCrLf}"
            Next
            txtOffers.Text = offerText
        End If
        
        pnlContent.Controls.Add(txtOffers)

        yPos += 120

        ' Query/Notes
        Dim lblQuery As New Label()
        lblQuery.Text = "📝 Any Questions/Special Requirements:"
        lblQuery.Font = New Font("Segoe UI", 10)
        lblQuery.ForeColor = Color.FromArgb(52, 73, 94)
        lblQuery.AutoSize = True
        lblQuery.Location = New Point(20, yPos)
        pnlContent.Controls.Add(lblQuery)

        yPos += 25
        txtQuery = New TextBox()
        txtQuery.Location = New Point(20, yPos)
        txtQuery.Size = New Size(640, 80)
        txtQuery.Font = New Font("Segoe UI", 10)
        txtQuery.Multiline = True
        txtQuery.BorderStyle = BorderStyle.FixedSingle
        pnlContent.Controls.Add(txtQuery)

        yPos += 100

        ' Register Button
        Dim btnRegisterLoan As New Button()
        btnRegisterLoan.Text = "✅ REGISTER"
        btnRegisterLoan.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        btnRegisterLoan.BackColor = Color.FromArgb(34, 197, 94)
        btnRegisterLoan.ForeColor = Color.White
        btnRegisterLoan.FlatStyle = FlatStyle.Flat
        btnRegisterLoan.FlatAppearance.BorderSize = 0
        btnRegisterLoan.Size = New Size(300, 40)
        btnRegisterLoan.Location = New Point(170, yPos)
        btnRegisterLoan.Cursor = Cursors.Hand
        AddHandler btnRegisterLoan.Click, Sub() RegisterLoan(cmbCompany.SelectedItem.ToString())
        pnlContent.Controls.Add(btnRegisterLoan)

        yPos += 50

        ' Close Button
        Dim btnClose As New Button()
        btnClose.Text = "✕ CLOSE"
        btnClose.Font = New Font("Segoe UI", 10)
        btnClose.BackColor = Color.FromArgb(149, 165, 166)
        btnClose.ForeColor = Color.White
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.FlatAppearance.BorderSize = 0
        btnClose.Size = New Size(300, 35)
        btnClose.Location = New Point(170, yPos)
        btnClose.Cursor = Cursors.Hand
        AddHandler btnClose.Click, Sub() Me.Close()
        pnlContent.Controls.Add(btnClose)
    End Sub

    Private Sub RegisterLoan(company As String)
        If String.IsNullOrWhiteSpace(txtAmount.Text) Then
            MessageBox.Show("Please enter loan amount!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim amount As Decimal
        If Not Decimal.TryParse(txtAmount.Text, amount) Then
            MessageBox.Show("Invalid amount format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Save loan application
        DatabaseConnection.InsertLoanApplication(userId, loanType, company, amount)

        ' Save query if provided
        If Not String.IsNullOrWhiteSpace(txtQuery.Text) Then
            DatabaseConnection.InsertQuery(userId, txtQuery.Text)
        End If

        MessageBox.Show("✅ YOU'VE BEEN REGISTERED!" & vbCrLf & vbCrLf & _
                       "Your " & loanType & " application has been submitted." & vbCrLf & _
                       "You'll be contacted soon with updates." & vbCrLf & vbCrLf & _
                       "Status: PENDING", _
                       "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.Close()
    End Sub
End Class
