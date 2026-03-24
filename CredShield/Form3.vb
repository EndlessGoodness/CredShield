Public Class Form3
    ' Login Page for CredShield Application

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set form properties
        Me.Text = "CredShield - Login"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(550, 600)
        Me.BackColor = Color.FromArgb(236, 240, 241)
        Me.DoubleBuffered = True

        ' Create header panel
        Dim pnlHeader As New Panel()
        pnlHeader.BackColor = Color.FromArgb(41, 128, 185)
        pnlHeader.Size = New Size(550, 80)
        pnlHeader.Location = New Point(0, 0)
        Me.Controls.Add(pnlHeader)

        ' Create title label
        Dim lblTitle As New Label()
        lblTitle.Text = "🔐 CredShield Login"
        lblTitle.Font = New Font("Segoe UI", 18, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.AutoSize = True
        lblTitle.Location = New Point(100, 10)
        pnlHeader.Controls.Add(lblTitle)

        ' Create tagline
        Dim lblTagline As New Label()
        lblTagline.Text = "Your Trusted Financial Advisor"
        lblTagline.Font = New Font("Segoe UI", 10)
        lblTagline.ForeColor = Color.FromArgb(200, 220, 240)
        lblTagline.AutoSize = True
        lblTagline.Location = New Point(110, 42)
        pnlHeader.Controls.Add(lblTagline)

        ' Create Email label
        Dim lblEmail As New Label()
        lblEmail.Text = "📧 Email Address:"
        lblEmail.Font = New Font("Segoe UI", 11)
        lblEmail.ForeColor = Color.FromArgb(52, 73, 94)
        lblEmail.AutoSize = True
        lblEmail.Location = New Point(50, 110)
        Me.Controls.Add(lblEmail)

        ' Create Email TextBox
        Dim txtEmail As New TextBox()
        txtEmail.Location = New Point(50, 140)
        txtEmail.Size = New Size(450, 35)
        txtEmail.Font = New Font("Segoe UI", 11)
        txtEmail.Name = "txtEmail"
        txtEmail.Tag = "email"
        txtEmail.BorderStyle = BorderStyle.FixedSingle
        Me.Controls.Add(txtEmail)

        ' Create Password label
        Dim lblPassword As New Label()
        lblPassword.Text = "🔒 Password:"
        lblPassword.Font = New Font("Segoe UI", 11)
        lblPassword.ForeColor = Color.FromArgb(52, 73, 94)
        lblPassword.AutoSize = True
        lblPassword.Location = New Point(50, 190)
        Me.Controls.Add(lblPassword)

        ' Create Password TextBox
        Dim txtPassword As New TextBox()
        txtPassword.Location = New Point(50, 220)
        txtPassword.Size = New Size(450, 35)
        txtPassword.Font = New Font("Segoe UI", 11)
        txtPassword.PasswordChar = "*"c
        txtPassword.Name = "txtPassword"
        txtPassword.Tag = "password"
        txtPassword.BorderStyle = BorderStyle.FixedSingle
        Me.Controls.Add(txtPassword)

        ' Create Remember Me checkbox
        Dim chkRemember As New CheckBox()
        chkRemember.Text = "✓ Remember Me"
        chkRemember.Font = New Font("Segoe UI", 10)
        chkRemember.Location = New Point(50, 270)
        chkRemember.Size = New Size(200, 25)
        Me.Controls.Add(chkRemember)

        ' Create Login button
        Dim btnLogin As New Button()
        btnLogin.Text = "🚀 Login"
        btnLogin.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        btnLogin.BackColor = Color.FromArgb(41, 128, 185)
        btnLogin.ForeColor = Color.White
        btnLogin.FlatStyle = FlatStyle.Flat
        btnLogin.FlatAppearance.BorderSize = 0
        btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 100, 160)
        btnLogin.Size = New Size(450, 45)
        btnLogin.Location = New Point(50, 320)
        btnLogin.Cursor = Cursors.Hand
        AddHandler btnLogin.Click, Sub()
                                       If txtEmail.Text <> "" AndAlso txtPassword.Text <> "" Then
                                           Form4.Show()
                                           Me.Hide()
                                       Else
                                           MessageBox.Show("Please enter email and password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                       End If
                                   End Sub
        Me.Controls.Add(btnLogin)

        ' Create Sign Up link
        Dim lblSignUp As New Label()
        lblSignUp.Text = "📝 Don't have an account? Sign Up"
        lblSignUp.Font = New Font("Segoe UI", 10)
        lblSignUp.ForeColor = Color.FromArgb(41, 128, 185)
        lblSignUp.AutoSize = True
        lblSignUp.Location = New Point(120, 400)
        lblSignUp.Cursor = Cursors.Hand
        Me.Controls.Add(lblSignUp)

        ' Create separator
        Dim lblSeparator As New Label()
        lblSeparator.BackColor = Color.FromArgb(200, 200, 200)
        lblSeparator.Size = New Size(450, 1)
        lblSeparator.Location = New Point(50, 440)
        Me.Controls.Add(lblSeparator)

        ' Create Back button
        Dim btnBack As New Button()
        btnBack.Text = "← Back"
        btnBack.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        btnBack.BackColor = Color.FromArgb(149, 165, 166)
        btnBack.ForeColor = Color.White
        btnBack.FlatStyle = FlatStyle.Flat
        btnBack.FlatAppearance.BorderSize = 0
        btnBack.FlatAppearance.MouseOverBackColor = Color.FromArgb(130, 145, 155)
        btnBack.Size = New Size(200, 40)
        btnBack.Location = New Point(175, 480)
        btnBack.Cursor = Cursors.Hand
        AddHandler btnBack.Click, Sub()
                                      Form1.Show()
                                      Me.Hide()
                                  End Sub
        Me.Controls.Add(btnBack)

        ' Add footer
        Dim lblFooter As New Label()
        lblFooter.Text = "© 2026 CredShield - Secure Login"
        lblFooter.Font = New Font("Segoe UI", 9)
        lblFooter.ForeColor = Color.FromArgb(150, 150, 150)
        lblFooter.AutoSize = True
        lblFooter.Location = New Point(140, 560)
        Me.Controls.Add(lblFooter)
    End Sub
End Class
