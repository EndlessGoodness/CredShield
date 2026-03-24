Public Class Form1
    ' Welcome Page for CredShield Application

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set form properties
        Me.Text = "CredShield - Welcome"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(900, 700)
        Me.BackColor = Color.FromArgb(41, 128, 185)
        Me.DoubleBuffered = True

        ' Create top panel with gradient effect
        Dim pnlTop As New Panel()
        pnlTop.BackColor = Color.FromArgb(41, 128, 185)
        pnlTop.Size = New Size(900, 150)
        pnlTop.Location = New Point(0, 0)
        Me.Controls.Add(pnlTop)

        ' Create welcome label
        Dim lblWelcome As New Label()
        lblWelcome.Text = "💼 Welcome to CredShield" & vbCrLf & "Your Financial Advisor"
        lblWelcome.Font = New Font("Segoe UI", 32, FontStyle.Bold)
        lblWelcome.ForeColor = Color.White
        lblWelcome.AutoSize = False
        lblWelcome.TextAlign = ContentAlignment.MiddleCenter
        lblWelcome.Location = New Point(50, 40)
        lblWelcome.Size = New Size(800, 100)
        Me.Controls.Add(lblWelcome)

        ' Create description label
        Dim lblDescription As New Label()
        lblDescription.Text = "Manage your loans and financial needs with ease." & vbCrLf & "Get expert guidance on credit and borrowing."
        lblDescription.Font = New Font("Segoe UI", 13)
        lblDescription.ForeColor = Color.FromArgb(220, 240, 255)
        lblDescription.AutoSize = False
        lblDescription.TextAlign = ContentAlignment.MiddleCenter
        lblDescription.Location = New Point(50, 260)
        lblDescription.Size = New Size(800, 80)
        Me.Controls.Add(lblDescription)

        ' Create info panel
        Dim pnlInfo As New Panel()
        pnlInfo.BackColor = Color.FromArgb(52, 73, 94)
        pnlInfo.Size = New Size(800, 90)
        pnlInfo.Location = New Point(50, 360)
        Me.Controls.Add(pnlInfo)

        Dim lblInfo As New Label()
        lblInfo.Text = "Explore 3 Types of Loans" & vbCrLf & "Home Loans • Bank Loans • Financial Loans" & vbCrLf & "Fast Approval • Low Interest Rates • 24/7 Support"
        lblInfo.Font = New Font("Segoe UI", 10)
        lblInfo.ForeColor = Color.White
        lblInfo.AutoSize = False
        lblInfo.TextAlign = ContentAlignment.MiddleCenter
        lblInfo.Location = New Point(0, 0)
        lblInfo.Size = New Size(800, 90)
        pnlInfo.Controls.Add(lblInfo)

        ' Create Get Started button
        Dim btnGetStarted As New Button()
        btnGetStarted.Text = "🚀 Get Started"
        btnGetStarted.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        btnGetStarted.BackColor = Color.White
        btnGetStarted.ForeColor = Color.FromArgb(41, 128, 185)
        btnGetStarted.FlatStyle = FlatStyle.Flat
        btnGetStarted.FlatAppearance.BorderSize = 0
        btnGetStarted.Size = New Size(200, 55)
        btnGetStarted.Location = New Point(350, 490)
        btnGetStarted.Cursor = Cursors.Hand
        AddHandler btnGetStarted.Click, Sub() ShowLoadingForm()
        Me.Controls.Add(btnGetStarted)

        ' Create Exit button
        Dim btnExit As New Button()
        btnExit.Text = "Exit"
        btnExit.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        btnExit.BackColor = Color.FromArgb(149, 165, 166)
        btnExit.ForeColor = Color.White
        btnExit.FlatStyle = FlatStyle.Flat
        btnExit.FlatAppearance.BorderSize = 0
        btnExit.Size = New Size(150, 40)
        btnExit.Location = New Point(375, 590)
        btnExit.Cursor = Cursors.Hand
        AddHandler btnExit.Click, Sub() Application.Exit()
        Me.Controls.Add(btnExit)

        ' Add footer
        Dim lblFooter As New Label()
        lblFooter.Text = "© 2026 CredShield - Loans & Taxes"
        lblFooter.Font = New Font("Segoe UI", 9)
        lblFooter.ForeColor = Color.FromArgb(200, 220, 240)
        lblFooter.AutoSize = True
        lblFooter.Location = New Point(300, 650)
        Me.Controls.Add(lblFooter)
    End Sub

    Private Sub ShowLoadingForm()
        Form2.Show()
        Me.Hide()
    End Sub
End Class
