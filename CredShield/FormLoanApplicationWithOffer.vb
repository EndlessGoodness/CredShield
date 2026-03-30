Public Class FormLoanApplicationWithOffer
    Inherits Form

    Private userId As Integer
    Private selectedOffer As LoanOffer
    Private txtCompanyName As TextBox
    Private txtLoanType As TextBox
    Private txtAmount As TextBox
    Private cmbTenure As ComboBox
    Private btnSubmit As Button

    Public Sub New(userId As Integer, offer As LoanOffer)
        MyBase.New()
        Me.userId = userId
        Me.selectedOffer = offer
        Me.Text = "CredShield - Apply for " & offer.CompanyName & " " & offer.LoanType
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(800, 750)
        Me.BackColor = Color.FromArgb(249, 250, 251)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False

        BuildUI()
    End Sub

    Private Sub BuildUI()
        ' Header
        Dim pnlHeader As New Panel()
        pnlHeader.BackColor = Color.FromArgb(34, 197, 94)
        pnlHeader.Size = New Size(800, 60)
        pnlHeader.Location = New Point(0, 0)
        Me.Controls.Add(pnlHeader)

        Dim lblTitle As New Label()
        lblTitle.Text = "Loan Application Form"
        lblTitle.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.AutoSize = False
        lblTitle.TextAlign = ContentAlignment.MiddleCenter
        lblTitle.Location = New Point(0, 10)
        lblTitle.Size = New Size(800, 40)
        pnlHeader.Controls.Add(lblTitle)

        ' Main Content with scroll
        Dim pnlContent As New Panel()
        pnlContent.AutoScroll = True
        pnlContent.AutoScrollMinSize = New Size(0, 800)
        pnlContent.Size = New Size(800, 690)
        pnlContent.Location = New Point(0, 60)
        Me.Controls.Add(pnlContent)

        Dim posY As Integer = 20

        ' Section: Loan Details
        Dim lblSection As New Label()
        lblSection.Text = "Loan Details (Pre-filled from your selection)"
        lblSection.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        lblSection.ForeColor = Color.FromArgb(34, 197, 94)
        lblSection.AutoSize = True
        lblSection.Location = New Point(20, posY)
        pnlContent.Controls.Add(lblSection)
        posY += 35

        ' Company Name
        Dim lblCompany As New Label()
        lblCompany.Text = "Company Name:"
        lblCompany.Font = New Font("Segoe UI", 10)
        lblCompany.ForeColor = Color.FromArgb(52, 73, 94)
        lblCompany.AutoSize = True
        lblCompany.Location = New Point(20, posY)
        pnlContent.Controls.Add(lblCompany)
        posY += 25

        txtCompanyName = New TextBox()
        txtCompanyName.Location = New Point(20, posY)
        txtCompanyName.Size = New Size(740, 35)
        txtCompanyName.Font = New Font("Segoe UI", 10)
        txtCompanyName.BorderStyle = BorderStyle.FixedSingle
        txtCompanyName.Text = selectedOffer.CompanyName
        txtCompanyName.ReadOnly = True
        txtCompanyName.BackColor = Color.FromArgb(245, 245, 245)
        pnlContent.Controls.Add(txtCompanyName)
        posY += 45

        ' Loan Type
        Dim lblLoanType As New Label()
        lblLoanType.Text = "Loan Type:"
        lblLoanType.Font = New Font("Segoe UI", 10)
        lblLoanType.ForeColor = Color.FromArgb(52, 73, 94)
        lblLoanType.AutoSize = True
        lblLoanType.Location = New Point(20, posY)
        pnlContent.Controls.Add(lblLoanType)
        posY += 25

        txtLoanType = New TextBox()
        txtLoanType.Location = New Point(20, posY)
        txtLoanType.Size = New Size(740, 35)
        txtLoanType.Font = New Font("Segoe UI", 10)
        txtLoanType.BorderStyle = BorderStyle.FixedSingle
        txtLoanType.Text = selectedOffer.LoanType
        txtLoanType.ReadOnly = True
        txtLoanType.BackColor = Color.FromArgb(245, 245, 245)
        pnlContent.Controls.Add(txtLoanType)
        posY += 45

        ' Interest Rate
        Dim lblInterest As New Label()
        lblInterest.Text = "Interest Rate Range:"
        lblInterest.Font = New Font("Segoe UI", 10)
        lblInterest.ForeColor = Color.FromArgb(52, 73, 94)
        lblInterest.AutoSize = True
        lblInterest.Location = New Point(20, posY)
        pnlContent.Controls.Add(lblInterest)
        posY += 25

        Dim txtInterest As New TextBox()
        txtInterest.Location = New Point(20, posY)
        txtInterest.Size = New Size(740, 35)
        txtInterest.Font = New Font("Segoe UI", 10)
        txtInterest.BorderStyle = BorderStyle.FixedSingle
        txtInterest.Text = selectedOffer.InterestRateMin & "% - " & selectedOffer.InterestRateMax & "% p.a."
        txtInterest.ReadOnly = True
        txtInterest.BackColor = Color.FromArgb(245, 245, 245)
        pnlContent.Controls.Add(txtInterest)
        posY += 45

        ' Processing Fee
        Dim lblFee As New Label()
        lblFee.Text = "Processing Fee:"
        lblFee.Font = New Font("Segoe UI", 10)
        lblFee.ForeColor = Color.FromArgb(52, 73, 94)
        lblFee.AutoSize = True
        lblFee.Location = New Point(20, posY)
        pnlContent.Controls.Add(lblFee)
        posY += 25

        Dim txtFee As New TextBox()
        txtFee.Location = New Point(20, posY)
        txtFee.Size = New Size(740, 35)
        txtFee.Font = New Font("Segoe UI", 10)
        txtFee.BorderStyle = BorderStyle.FixedSingle
        txtFee.Text = selectedOffer.ProcessingFee & "%"
        txtFee.ReadOnly = True
        txtFee.BackColor = Color.FromArgb(245, 245, 245)
        pnlContent.Controls.Add(txtFee)
        posY += 45

        ' Section: Your Application Details
        Dim lblAppSection As New Label()
        lblAppSection.Text = "Your Application Details (Please Fill)"
        lblAppSection.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        lblAppSection.ForeColor = Color.FromArgb(34, 197, 94)
        lblAppSection.AutoSize = True
        lblAppSection.Location = New Point(20, posY)
        pnlContent.Controls.Add(lblAppSection)
        posY += 35

        ' Requested Amount
        Dim lblAmount As New Label()
        lblAmount.Text = "Requested Amount (₹" & Format(selectedOffer.MinAmount, "0,0") & " - ₹" & Format(selectedOffer.MaxAmount, "0,0") & "):"
        lblAmount.Font = New Font("Segoe UI", 10)
        lblAmount.ForeColor = Color.FromArgb(52, 73, 94)
        lblAmount.AutoSize = True
        lblAmount.Location = New Point(20, posY)
        pnlContent.Controls.Add(lblAmount)
        posY += 25

        txtAmount = New TextBox()
        txtAmount.Location = New Point(20, posY)
        txtAmount.Size = New Size(740, 35)
        txtAmount.Font = New Font("Segoe UI", 10)
        txtAmount.BorderStyle = BorderStyle.FixedSingle
        pnlContent.Controls.Add(txtAmount)
        posY += 45

        ' Tenure
        Dim lblTenure As New Label()
        lblTenure.Text = "Preferred Tenure (" & selectedOffer.TenureMin & "-" & selectedOffer.TenureMax & " years):"
        lblTenure.Font = New Font("Segoe UI", 10)
        lblTenure.ForeColor = Color.FromArgb(52, 73, 94)
        lblTenure.AutoSize = True
        lblTenure.Location = New Point(20, posY)
        pnlContent.Controls.Add(lblTenure)
        posY += 25

        cmbTenure = New ComboBox()
        cmbTenure.Location = New Point(20, posY)
        cmbTenure.Size = New Size(740, 35)
        cmbTenure.Font = New Font("Segoe UI", 10)
        For i As Integer = selectedOffer.TenureMin To selectedOffer.TenureMax
            cmbTenure.Items.Add(i & " Years")
        Next
        cmbTenure.SelectedIndex = 0
        pnlContent.Controls.Add(cmbTenure)
        posY += 45

        ' Notes
        Dim lblNotes As New Label()
        lblNotes.Text = "Additional Notes (Optional):"
        lblNotes.Font = New Font("Segoe UI", 10)
        lblNotes.ForeColor = Color.FromArgb(52, 73, 94)
        lblNotes.AutoSize = True
        lblNotes.Location = New Point(20, posY)
        pnlContent.Controls.Add(lblNotes)
        posY += 25

        Dim txtNotes As New TextBox()
        txtNotes.Location = New Point(20, posY)
        txtNotes.Size = New Size(740, 80)
        txtNotes.Font = New Font("Segoe UI", 10)
        txtNotes.BorderStyle = BorderStyle.FixedSingle
        txtNotes.Multiline = True
        pnlContent.Controls.Add(txtNotes)
        posY += 100

        ' Submit Button
        btnSubmit = New Button()
        btnSubmit.Text = "✅ Submit Application"
        btnSubmit.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        btnSubmit.BackColor = Color.FromArgb(34, 197, 94)
        btnSubmit.ForeColor = Color.White
        btnSubmit.FlatStyle = FlatStyle.Flat
        btnSubmit.FlatAppearance.BorderSize = 0
        btnSubmit.Size = New Size(740, 40)
        btnSubmit.Location = New Point(20, posY)
        btnSubmit.Cursor = Cursors.Hand
        AddHandler btnSubmit.Click, Sub(sender As Object, e As EventArgs) SubmitApplication(txtAmount.Text, cmbTenure.Text, txtNotes.Text)
        pnlContent.Controls.Add(btnSubmit)
    End Sub

    Private Sub SubmitApplication(amount As String, tenure As String, notes As String)
        ' Validate inputs
        If String.IsNullOrWhiteSpace(amount) Then
            MessageBox.Show("Please enter the requested amount!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not Decimal.TryParse(amount, Nothing) Then
            MessageBox.Show("Please enter a valid amount!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim amountDecimal As Decimal = CDec(amount)

        ' Validate amount is within range
        If amountDecimal < selectedOffer.MinAmount OrElse amountDecimal > selectedOffer.MaxAmount Then
            MessageBox.Show("Amount must be between ₹" & Format(selectedOffer.MinAmount, "0,0") & " and ₹" & Format(selectedOffer.MaxAmount, "0,0"), 
                          "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Insert into database
        DatabaseConnection.InsertLoanApplication(userId, selectedOffer.LoanType, selectedOffer.CompanyName, amountDecimal)

        ' Show success message
        MessageBox.Show("Your loan application has been submitted successfully!" & vbCrLf & vbCrLf & 
                       "Company: " & selectedOffer.CompanyName & vbCrLf &
                       "Loan Type: " & selectedOffer.LoanType & vbCrLf &
                       "Amount: ₹" & Format(amountDecimal, "0,0") & vbCrLf &
                       "Tenure: " & tenure & vbCrLf & vbCrLf &
                       "We will review your application and contact you soon.",
                       "Application Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Close form
        Me.Close()
    End Sub
End Class
