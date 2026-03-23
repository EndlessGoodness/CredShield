Public Class Form5
    ' Loan Registration Page for CredShield Application

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set form properties
        Me.Text = "CredShield - " & LoanManager.SelectedLoanType & " Registration"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(800, 900)
        Me.BackColor = Color.FromArgb(236, 240, 241)

        ' Create header panel
        Dim pnlHeader As New Panel()
        pnlHeader.BackColor = Color.FromArgb(41, 128, 185)
        pnlHeader.Size = New Size(800, 60)
        pnlHeader.Location = New Point(0, 0)
        Me.Controls.Add(pnlHeader)

        ' Create title
        Dim lblTitle As New Label()
        lblTitle.Text = LoanManager.SelectedLoanType & " Application Form"
        lblTitle.Font = New Font("Arial", 18, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.AutoSize = True
        lblTitle.Location = New Point(20, 15)
        pnlHeader.Controls.Add(lblTitle)

        ' Create content panel with scrolling
        Dim pnlContent As New Panel()
        pnlContent.BackColor = Color.FromArgb(236, 240, 241)
        pnlContent.Size = New Size(780, 840)
        pnlContent.Location = New Point(10, 65)
        pnlContent.AutoScroll = True
        Me.Controls.Add(pnlContent)

        Dim yPosition As Integer = 10

        ' Create Loan Type Display
        Dim lblLoanTypeDisplay As New Label()
        lblLoanTypeDisplay.Text = "Loan Type: " & LoanManager.SelectedLoanType
        lblLoanTypeDisplay.Font = New Font("Arial", 12, FontStyle.Bold)
        lblLoanTypeDisplay.ForeColor = Color.FromArgb(41, 128, 185)
        lblLoanTypeDisplay.AutoSize = True
        lblLoanTypeDisplay.Location = New Point(20, yPosition)
        pnlContent.Controls.Add(lblLoanTypeDisplay)

        yPosition += 40

        ' Create Loan Amount label and textbox
        Dim lblLoanAmount As New Label()
        lblLoanAmount.Text = "Loan Amount (₹):"
        lblLoanAmount.Font = New Font("Arial", 11)
        lblLoanAmount.AutoSize = True
        lblLoanAmount.Location = New Point(20, yPosition)
        pnlContent.Controls.Add(lblLoanAmount)

        Dim txtLoanAmount As New TextBox()
        txtLoanAmount.Location = New Point(220, yPosition)
        txtLoanAmount.Size = New Size(500, 25)
        txtLoanAmount.Font = New Font("Arial", 10)
        txtLoanAmount.Name = "txtLoanAmount"
        txtLoanAmount.Tag = "amount"
        pnlContent.Controls.Add(txtLoanAmount)

        yPosition += 45

        ' Create Loan Tenure label and textbox
        Dim lblTenure As New Label()
        lblTenure.Text = "Loan Tenure (Years):"
        lblTenure.Font = New Font("Arial", 11)
        lblTenure.AutoSize = True
        lblTenure.Location = New Point(20, yPosition)
        pnlContent.Controls.Add(lblTenure)

        Dim txtTenure As New TextBox()
        txtTenure.Location = New Point(220, yPosition)
        txtTenure.Size = New Size(500, 25)
        txtTenure.Font = New Font("Arial", 10)
        txtTenure.Name = "txtTenure"
        txtTenure.Tag = "tenure"
        pnlContent.Controls.Add(txtTenure)

        yPosition += 45

        ' Create Annual Income label and textbox
        Dim lblIncome As New Label()
        lblIncome.Text = "Annual Income (₹):"
        lblIncome.Font = New Font("Arial", 11)
        lblIncome.AutoSize = True
        lblIncome.Location = New Point(20, yPosition)
        pnlContent.Controls.Add(lblIncome)

        Dim txtIncome As New TextBox()
        txtIncome.Location = New Point(220, yPosition)
        txtIncome.Size = New Size(500, 25)
        txtIncome.Font = New Font("Arial", 10)
        txtIncome.Name = "txtIncome"
        txtIncome.Tag = "income"
        pnlContent.Controls.Add(txtIncome)

        yPosition += 45

        ' Create Employment Status label and combo
        Dim lblEmployment As New Label()
        lblEmployment.Text = "Employment Status:"
        lblEmployment.Font = New Font("Arial", 11)
        lblEmployment.AutoSize = True
        lblEmployment.Location = New Point(20, yPosition)
        pnlContent.Controls.Add(lblEmployment)

        Dim cmbEmployment As New ComboBox()
        cmbEmployment.Location = New Point(220, yPosition)
        cmbEmployment.Size = New Size(500, 25)
        cmbEmployment.Font = New Font("Arial", 10)
        cmbEmployment.Items.AddRange(New String() {"Employed", "Self-Employed", "Retired", "Student", "Unemployed"})
        cmbEmployment.Name = "cmbEmployment"
        cmbEmployment.Tag = "employment"
        pnlContent.Controls.Add(cmbEmployment)

        yPosition += 45

        ' Add loan-type-specific fields
        If LoanManager.SelectedLoanType = "Home Loan" Then
            Dim lblPropertyValue As New Label()
            lblPropertyValue.Text = "Property Value (₹):"
            lblPropertyValue.Font = New Font("Arial", 11)
            lblPropertyValue.AutoSize = True
            lblPropertyValue.Location = New Point(20, yPosition)
            pnlContent.Controls.Add(lblPropertyValue)

            Dim txtPropertyValue As New TextBox()
            txtPropertyValue.Location = New Point(220, yPosition)
            txtPropertyValue.Size = New Size(500, 25)
            txtPropertyValue.Font = New Font("Arial", 10)
            txtPropertyValue.Name = "txtPropertyValue"
            pnlContent.Controls.Add(txtPropertyValue)

            yPosition += 45

            Dim lblPropertyLocation As New Label()
            lblPropertyLocation.Text = "Property Location:"
            lblPropertyLocation.Font = New Font("Arial", 11)
            lblPropertyLocation.AutoSize = True
            lblPropertyLocation.Location = New Point(20, yPosition)
            pnlContent.Controls.Add(lblPropertyLocation)

            Dim txtPropertyLocation As New TextBox()
            txtPropertyLocation.Location = New Point(220, yPosition)
            txtPropertyLocation.Size = New Size(500, 25)
            txtPropertyLocation.Font = New Font("Arial", 10)
            txtPropertyLocation.Name = "txtPropertyLocation"
            pnlContent.Controls.Add(txtPropertyLocation)

            yPosition += 45

        ElseIf LoanManager.SelectedLoanType = "Bank Loan" Then
            Dim lblPurpose As New Label()
            lblPurpose.Text = "Purpose of Loan:"
            lblPurpose.Font = New Font("Arial", 11)
            lblPurpose.AutoSize = True
            lblPurpose.Location = New Point(20, yPosition)
            pnlContent.Controls.Add(lblPurpose)

            Dim cmbPurpose As New ComboBox()
            cmbPurpose.Location = New Point(220, yPosition)
            cmbPurpose.Size = New Size(500, 25)
            cmbPurpose.Font = New Font("Arial", 10)
            cmbPurpose.Items.AddRange(New String() {"Medical Emergency", "Education", "Travel", "Home Renovation", "Debt Consolidation", "Other"})
            cmbPurpose.Name = "cmbPurpose"
            pnlContent.Controls.Add(cmbPurpose)

            yPosition += 45

            Dim lblRepaymentType As New Label()
            lblRepaymentType.Text = "Repayment Mode:"
            lblRepaymentType.Font = New Font("Arial", 11)
            lblRepaymentType.AutoSize = True
            lblRepaymentType.Location = New Point(20, yPosition)
            pnlContent.Controls.Add(lblRepaymentType)

            Dim cmbRepayment As New ComboBox()
            cmbRepayment.Location = New Point(220, yPosition)
            cmbRepayment.Size = New Size(500, 25)
            cmbRepayment.Font = New Font("Arial", 10)
            cmbRepayment.Items.AddRange(New String() {"Monthly", "Quarterly", "Bi-Annual"})
            cmbRepayment.Name = "cmbRepayment"
            pnlContent.Controls.Add(cmbRepayment)

            yPosition += 45

        ElseIf LoanManager.SelectedLoanType = "Financial Loan" Then
            Dim lblBusinessType As New Label()
            lblBusinessType.Text = "Business/Investment Type:"
            lblBusinessType.Font = New Font("Arial", 11)
            lblBusinessType.AutoSize = True
            lblBusinessType.Location = New Point(20, yPosition)
            pnlContent.Controls.Add(lblBusinessType)

            Dim cmbBusinessType As New ComboBox()
            cmbBusinessType.Location = New Point(220, yPosition)
            cmbBusinessType.Size = New Size(500, 25)
            cmbBusinessType.Font = New Font("Arial", 10)
            cmbBusinessType.Items.AddRange(New String() {"Startup", "Expansion", "Working Capital", "Investment", "Real Estate"})
            cmbBusinessType.Name = "cmbBusinessType"
            pnlContent.Controls.Add(cmbBusinessType)

            yPosition += 45

            Dim lblProjectDetails As New Label()
            lblProjectDetails.Text = "Project Details:"
            lblProjectDetails.Font = New Font("Arial", 11)
            lblProjectDetails.AutoSize = True
            lblProjectDetails.Location = New Point(20, yPosition)
            pnlContent.Controls.Add(lblProjectDetails)

            Dim txtProjectDetails As New TextBox()
            txtProjectDetails.Location = New Point(220, yPosition)
            txtProjectDetails.Size = New Size(500, 60)
            txtProjectDetails.Font = New Font("Arial", 10)
            txtProjectDetails.Multiline = True
            txtProjectDetails.Name = "txtProjectDetails"
            pnlContent.Controls.Add(txtProjectDetails)

            yPosition += 70
        End If

        ' Create Contact Number field
        Dim lblContact As New Label()
        lblContact.Text = "Contact Number:"
        lblContact.Font = New Font("Arial", 11)
        lblContact.AutoSize = True
        lblContact.Location = New Point(20, yPosition)
        pnlContent.Controls.Add(lblContact)

        Dim txtContact As New TextBox()
        txtContact.Location = New Point(220, yPosition)
        txtContact.Size = New Size(500, 25)
        txtContact.Font = New Font("Arial", 10)
        txtContact.Name = "txtContact"
        pnlContent.Controls.Add(txtContact)

        yPosition += 45

        ' Create Email field
        Dim lblEmail As New Label()
        lblEmail.Text = "Email Address:"
        lblEmail.Font = New Font("Arial", 11)
        lblEmail.AutoSize = True
        lblEmail.Location = New Point(20, yPosition)
        pnlContent.Controls.Add(lblEmail)

        Dim txtEmail As New TextBox()
        txtEmail.Location = New Point(220, yPosition)
        txtEmail.Size = New Size(500, 25)
        txtEmail.Font = New Font("Arial", 10)
        txtEmail.Name = "txtEmail"
        pnlContent.Controls.Add(txtEmail)

        yPosition += 45

        ' Create Terms checkbox
        Dim chkTerms As New CheckBox()
        chkTerms.Text = "I agree to the terms and conditions"
        chkTerms.Font = New Font("Arial", 10)
        chkTerms.Location = New Point(20, yPosition)
        chkTerms.Size = New Size(400, 25)
        chkTerms.Name = "chkTerms"
        pnlContent.Controls.Add(chkTerms)

        yPosition += 45

        ' Create button panel
        Dim pnlButtons As New Panel()
        pnlButtons.BackColor = Color.FromArgb(236, 240, 241)
        pnlButtons.Size = New Size(750, 60)
        pnlButtons.Location = New Point(0, yPosition)
        pnlContent.Controls.Add(pnlButtons)

        ' Create Submit button
        Dim btnSubmit As New Button()
        btnSubmit.Text = "Submit Application"
        btnSubmit.Font = New Font("Arial", 12, FontStyle.Bold)
        btnSubmit.BackColor = Color.FromArgb(41, 128, 185)
        btnSubmit.ForeColor = Color.White
        btnSubmit.Size = New Size(180, 40)
        btnSubmit.Location = New Point(150, 10)
        btnSubmit.Cursor = Cursors.Hand
        AddHandler btnSubmit.Click, Sub()
                                        If ValidateLoanForm(pnlContent) Then
                                            Form6.Show()
                                            Me.Hide()
                                        End If
                                    End Sub
        pnlButtons.Controls.Add(btnSubmit)

        ' Create Cancel button
        Dim btnCancel As New Button()
        btnCancel.Text = "Cancel"
        btnCancel.Font = New Font("Arial", 12, FontStyle.Bold)
        btnCancel.BackColor = Color.FromArgb(149, 165, 166)
        btnCancel.ForeColor = Color.White
        btnCancel.Size = New Size(180, 40)
        btnCancel.Location = New Point(420, 10)
        btnCancel.Cursor = Cursors.Hand
        AddHandler btnCancel.Click, Sub()
                                        Form4.Show()
                                        Me.Hide()
                                    End Sub
        pnlButtons.Controls.Add(btnCancel)
    End Sub

    Private Function ValidateLoanForm(panel As Panel) As Boolean
        ' Get all textboxes and comboboxes from the panel
        Dim txtLoanAmount = panel.Controls.Cast(Of Control)().OfType(Of TextBox)().FirstOrDefault(Function(t) t.Name = "txtLoanAmount")
        Dim txtTenure = panel.Controls.Cast(Of Control)().OfType(Of TextBox)().FirstOrDefault(Function(t) t.Name = "txtTenure")
        Dim txtIncome = panel.Controls.Cast(Of Control)().OfType(Of TextBox)().FirstOrDefault(Function(t) t.Name = "txtIncome")
        Dim cmbEmployment = panel.Controls.Cast(Of Control)().OfType(Of ComboBox)().FirstOrDefault(Function(c) c.Name = "cmbEmployment")
        Dim chkTerms = panel.Controls.Cast(Of Control)().OfType(Of CheckBox)().FirstOrDefault(Function(c) c.Name = "chkTerms")

        ' Validate basic fields
        If String.IsNullOrEmpty(txtLoanAmount.Text) OrElse String.IsNullOrEmpty(txtTenure.Text) OrElse
           String.IsNullOrEmpty(txtIncome.Text) OrElse String.IsNullOrEmpty(cmbEmployment.Text) Then
            MessageBox.Show("Please fill all required fields!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' Validate numeric fields
        Dim amount As Decimal
        If Not Decimal.TryParse(txtLoanAmount.Text, amount) Then
            MessageBox.Show("Please enter a valid loan amount!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Dim tenure As Integer
        If Not Integer.TryParse(txtTenure.Text, tenure) Then
            MessageBox.Show("Please enter a valid tenure!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Dim income As Decimal
        If Not Decimal.TryParse(txtIncome.Text, income) Then
            MessageBox.Show("Please enter a valid income!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' Check terms and conditions
        If Not chkTerms.Checked Then
            MessageBox.Show("Please agree to the terms and conditions!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function
End Class
