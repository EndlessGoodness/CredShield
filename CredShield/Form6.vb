Public Class Form6
    ' Result / Confirmation Page for CredShield Application

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set form properties
        Me.Text = "CredShield - Application Confirmation"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(900, 700)
        Me.BackColor = Color.FromArgb(236, 240, 241)

        ' Create header panel
        Dim pnlHeader As New Panel()
        pnlHeader.BackColor = Color.FromArgb(46, 204, 113)
        pnlHeader.Size = New Size(900, 60)
        pnlHeader.Location = New Point(0, 0)
        Me.Controls.Add(pnlHeader)

        ' Create success title
        Dim lblHeaderTitle As New Label()
        lblHeaderTitle.Text = "✓ Application Submitted Successfully!"
        lblHeaderTitle.Font = New Font("Arial", 18, FontStyle.Bold)
        lblHeaderTitle.ForeColor = Color.White
        lblHeaderTitle.AutoSize = True
        lblHeaderTitle.Location = New Point(150, 15)
        pnlHeader.Controls.Add(lblHeaderTitle)

        ' Create main content panel
        Dim pnlMain As New Panel()
        pnlMain.BackColor = Color.White
        pnlMain.Size = New Size(850, 600)
        pnlMain.Location = New Point(25, 70)
        pnlMain.BorderStyle = BorderStyle.FixedSingle
        Me.Controls.Add(pnlMain)

        ' Create success icon
        Dim lblIcon As New Label()
        lblIcon.Text = "✓"
        lblIcon.Font = New Font("Arial", 60, FontStyle.Bold)
        lblIcon.ForeColor = Color.FromArgb(46, 204, 113)
        lblIcon.AutoSize = True
        lblIcon.Location = New Point(375, 15)
        pnlMain.Controls.Add(lblIcon)

        ' Create main title
        Dim lblTitle As New Label()
        lblTitle.Text = "Your " & LoanManager.SelectedLoanType & " Application"
        lblTitle.Font = New Font("Arial", 18, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(41, 128, 185)
        lblTitle.AutoSize = False
        lblTitle.TextAlign = ContentAlignment.MiddleCenter
        lblTitle.Location = New Point(20, 85)
        lblTitle.Size = New Size(810, 40)
        pnlMain.Controls.Add(lblTitle)

        ' Create confirmation message
        Dim lblMessage As New Label()
        lblMessage.Text = "Has Been Successfully Submitted!" & vbCrLf & vbCrLf & _
                         "Thank you for choosing CredShield for your " & LoanManager.SelectedLoanType & "." & vbCrLf & _
                         "We have received your application and will process it within 24-48 hours." & vbCrLf & _
                         "You will receive updates via email and SMS."
        lblMessage.Font = New Font("Arial", 11)
        lblMessage.ForeColor = Color.FromArgb(52, 73, 94)
        lblMessage.AutoSize = False
        lblMessage.TextAlign = ContentAlignment.TopCenter
        lblMessage.Location = New Point(40, 140)
        lblMessage.Size = New Size(770, 90)
        pnlMain.Controls.Add(lblMessage)

        ' Create application details box
        Dim pnlDetails As New Panel()
        pnlDetails.BackColor = Color.FromArgb(236, 240, 241)
        pnlDetails.Size = New Size(770, 140)
        pnlDetails.Location = New Point(40, 250)
        pnlDetails.BorderStyle = BorderStyle.FixedSingle
        pnlMain.Controls.Add(pnlDetails)

        ' Create reference number label
        Dim lblRefLabel As New Label()
        lblRefLabel.Text = "Application Reference Number:"
        lblRefLabel.Font = New Font("Arial", 11, FontStyle.Bold)
        lblRefLabel.ForeColor = Color.FromArgb(52, 73, 94)
        lblRefLabel.AutoSize = True
        lblRefLabel.Location = New Point(20, 15)
        pnlDetails.Controls.Add(lblRefLabel)

        ' Generate and display reference number
        Dim refNumber As String = "CSH" & DateTime.Now.Year & DateTime.Now.Month.ToString("D2") & _
                                  DateTime.Now.Day.ToString("D2") & "-" & New Random().Next(100000, 999999).ToString()

        Dim lblRefNumber As New Label()
        lblRefNumber.Text = refNumber
        lblRefNumber.Font = New Font("Arial", 14, FontStyle.Bold)
        lblRefNumber.ForeColor = Color.FromArgb(41, 128, 185)
        lblRefNumber.AutoSize = True
        lblRefNumber.Location = New Point(20, 45)
        pnlDetails.Controls.Add(lblRefNumber)

        ' Create loan type display
        Dim lblLoanTypeLabel As New Label()
        lblLoanTypeLabel.Text = "Loan Type:"
        lblLoanTypeLabel.Font = New Font("Arial", 10, FontStyle.Bold)
        lblLoanTypeLabel.ForeColor = Color.FromArgb(52, 73, 94)
        lblLoanTypeLabel.AutoSize = True
        lblLoanTypeLabel.Location = New Point(400, 15)
        pnlDetails.Controls.Add(lblLoanTypeLabel)

        Dim lblLoanTypeValue As New Label()
        lblLoanTypeValue.Text = LoanManager.SelectedLoanType
        lblLoanTypeValue.Font = New Font("Arial", 12, FontStyle.Bold)
        lblLoanTypeValue.ForeColor = Color.FromArgb(41, 128, 185)
        lblLoanTypeValue.AutoSize = True
        lblLoanTypeValue.Location = New Point(400, 40)
        pnlDetails.Controls.Add(lblLoanTypeValue)

        ' Create next steps title
        Dim lblStepsTitle As New Label()
        lblStepsTitle.Text = "Next Steps:"
        lblStepsTitle.Font = New Font("Arial", 12, FontStyle.Bold)
        lblStepsTitle.ForeColor = Color.FromArgb(52, 73, 94)
        lblStepsTitle.AutoSize = True
        lblStepsTitle.Location = New Point(40, 410)
        pnlMain.Controls.Add(lblStepsTitle)

        ' Create steps list
        Dim lstSteps As New ListBox()
        lstSteps.Location = New Point(40, 440)
        lstSteps.Size = New Size(770, 100)
        lstSteps.Font = New Font("Arial", 10)
        lstSteps.Items.Add("✓ Our team will verify all your submitted documents")
        lstSteps.Items.Add("✓ You will receive email/SMS updates on your application status")
        lstSteps.Items.Add("✓ Approval decision will be communicated within 3-5 business days")
        lstSteps.Items.Add("✓ Upon approval, we will guide you through the disbursement process")
        pnlMain.Controls.Add(lstSteps)

        ' Create Go to Home button
        Dim btnHome As New Button()
        btnHome.Text = "Go to Home"
        btnHome.Font = New Font("Arial", 11, FontStyle.Bold)
        btnHome.BackColor = Color.FromArgb(41, 128, 185)
        btnHome.ForeColor = Color.White
        btnHome.Size = New Size(150, 40)
        btnHome.Location = New Point(300, 560)
        btnHome.Cursor = Cursors.Hand
        AddHandler btnHome.Click, Sub()
                                       Form4.Show()
                                       Me.Hide()
                                   End Sub
        pnlMain.Controls.Add(btnHome)

        ' Create New Application button
        Dim btnNewApp As New Button()
        btnNewApp.Text = "New Application"
        btnNewApp.Font = New Font("Arial", 11, FontStyle.Bold)
        btnNewApp.BackColor = Color.FromArgb(46, 204, 113)
        btnNewApp.ForeColor = Color.White
        btnNewApp.Size = New Size(150, 40)
        btnNewApp.Location = New Point(500, 560)
        btnNewApp.Cursor = Cursors.Hand
        AddHandler btnNewApp.Click, Sub()
                                         Form4.Show()
                                         Me.Hide()
                                     End Sub
        pnlMain.Controls.Add(btnNewApp)
    End Sub
End Class
