Public Class Form3
    ' Login Page for CredShield Application

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set form properties
        Me.Text = "CredShield - Login"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(500, 550)
        Me.BackColor = Color.FromArgb(236, 240, 241)

        ' Create header panel
        Dim pnlHeader As New Panel()
        pnlHeader.BackColor = Color.FromArgb(41, 128, 185)
        pnlHeader.Size = New Size(500, 60)
        pnlHeader.Location = New Point(0, 0)
        Me.Controls.Add(pnlHeader)

        ' Create title label
        Dim lblTitle As New Label()
        lblTitle.Text = "CredShield Login"
        lblTitle.Font = New Font("Arial", 16, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.AutoSize = True
        lblTitle.Location = New Point(130, 10)
        pnlHeader.Controls.Add(lblTitle)

        ' Create tagline
        Dim lblTagline As New Label()
        lblTagline.Text = "Your Trusted Financial Advisor"
        lblTagline.Font = New Font("Arial", 9)
        lblTagline.ForeColor = Color.White
        lblTagline.AutoSize = True
        lblTagline.Location = New Point(140, 35)
        pnlHeader.Controls.Add(lblTagline)

        ' Create Email label
        Dim lblEmail As New Label()
        lblEmail.Text = "Email Address:"
        lblEmail.Font = New Font("Arial", 12)
        lblEmail.AutoSize = True
        lblEmail.Location = New Point(50, 90)
        Me.Controls.Add(lblEmail)

        ' Create Email TextBox
        Dim txtEmail As New TextBox()
        txtEmail.Location = New Point(50, 120)
        txtEmail.Size = New Size(400, 30)
        txtEmail.Font = New Font("Arial", 11)
        txtEmail.Name = "txtEmail"
        txtEmail.Tag = "email"
        Me.Controls.Add(txtEmail)

        ' Create Password label
        Dim lblPassword As New Label()
        lblPassword.Text = "Password:"
        lblPassword.Font = New Font("Arial", 12)
        lblPassword.AutoSize = True
        lblPassword.Location = New Point(50, 170)
        Me.Controls.Add(lblPassword)

        ' Create Password TextBox
        Dim txtPassword As New TextBox()
        txtPassword.Location = New Point(50, 200)
        txtPassword.Size = New Size(400, 30)
        txtPassword.Font = New Font("Arial", 11)
        txtPassword.PasswordChar = "*"c
        txtPassword.Name = "txtPassword"
        txtPassword.Tag = "password"
        Me.Controls.Add(txtPassword)

        ' Create Remember Me checkbox
        Dim chkRemember As New CheckBox()
        chkRemember.Text = "Remember Me"
        chkRemember.Font = New Font("Arial", 10)
        chkRemember.Location = New Point(50, 250)
        chkRemember.Size = New Size(150, 20)
        Me.Controls.Add(chkRemember)

        ' Create Login button
        Dim btnLogin As New Button()
        btnLogin.Text = "Login"
        btnLogin.Font = New Font("Arial", 12, FontStyle.Bold)
        btnLogin.BackColor = Color.FromArgb(41, 128, 185)
        btnLogin.ForeColor = Color.White
        btnLogin.Size = New Size(400, 40)
        btnLogin.Location = New Point(50, 300)
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
        lblSignUp.Text = "Don't have an account? Sign Up"
        lblSignUp.Font = New Font("Arial", 10)
        lblSignUp.ForeColor = Color.FromArgb(41, 128, 185)
        lblSignUp.AutoSize = True
        lblSignUp.Location = New Point(120, 370)
        lblSignUp.Cursor = Cursors.Hand
        Me.Controls.Add(lblSignUp)

        ' Create Back button
        Dim btnBack As New Button()
        btnBack.Text = "Back"
        btnBack.Font = New Font("Arial", 11)
        btnBack.BackColor = Color.FromArgb(149, 165, 166)
        btnBack.ForeColor = Color.White
        btnBack.Size = New Size(100, 35)
        btnBack.Location = New Point(200, 410)
        btnBack.Cursor = Cursors.Hand
        AddHandler btnBack.Click, Sub()
                                      Form1.Show()
                                      Me.Hide()
                                  End Sub
        Me.Controls.Add(btnBack)
    End Sub
End Class
