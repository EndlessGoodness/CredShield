Public Class FormNewHome
    Inherits Form

    Public Sub New()
        MyBase.New()
        Me.Text = "GEE ASSOCIATES - CredShield"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(1400, 900)
        Me.BackColor = Color.White
        Me.DoubleBuffered = True
        BuildUI()
    End Sub

    Private Sub BuildUI()
        ' Initialize database
        DatabaseConnection.InitializeDatabase()

        ' Create header
        Dim pnlHeader As New Panel()
        pnlHeader.BackColor = Color.FromArgb(15, 23, 42)
        pnlHeader.Size = New Size(1400, 100)
        pnlHeader.Location = New Point(0, 0)
        Me.Controls.Add(pnlHeader)

        ' Company logo area
        Dim lblGEE As New Label()
        lblGEE.Text = "🏢 GEE ASSOCIATES"
        lblGEE.Font = New Font("Segoe UI", 18, FontStyle.Bold)
        lblGEE.ForeColor = Color.FromArgb(59, 130, 246)
        lblGEE.AutoSize = True
        lblGEE.Location = New Point(40, 20)
        pnlHeader.Controls.Add(lblGEE)

        Dim lblCredShield As New Label()
        lblCredShield.Text = "💼 CredShield"
        lblCredShield.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        lblCredShield.ForeColor = Color.FromArgb(34, 197, 94)
        lblCredShield.AutoSize = True
        lblCredShield.Location = New Point(40, 55)
        pnlHeader.Controls.Add(lblCredShield)

        ' Divider
        Dim pnlDivider As New Panel()
        pnlDivider.BackColor = Color.FromArgb(226, 232, 240)
        pnlDivider.Size = New Size(1400, 1)
        pnlDivider.Location = New Point(0, 99)
        Me.Controls.Add(pnlDivider)

        ' Main content area
        Dim pnlContent As New Panel()
        pnlContent.BackColor = Color.White
        pnlContent.Size = New Size(1400, 800)
        pnlContent.Location = New Point(0, 100)
        Me.Controls.Add(pnlContent)

        ' Left side - Company info
        Dim pnlLeft As New Panel()
        pnlLeft.BackColor = Color.FromArgb(249, 250, 251)
        pnlLeft.Size = New Size(700, 800)
        pnlLeft.Location = New Point(0, 0)
        pnlContent.Controls.Add(pnlLeft)

        Dim lblCompanyTitle As New Label()
        lblCompanyTitle.Text = "About GEE ASSOCIATES"
        lblCompanyTitle.Font = New Font("Segoe UI", 20, FontStyle.Bold)
        lblCompanyTitle.ForeColor = Color.FromArgb(15, 23, 42)
        lblCompanyTitle.AutoSize = False
        lblCompanyTitle.Location = New Point(40, 30)
        lblCompanyTitle.Size = New Size(620, 40)
        pnlLeft.Controls.Add(lblCompanyTitle)

        Dim lblCompanyDesc As New Label()
        lblCompanyDesc.Text = "GEE ASSOCIATES is a trusted financial services provider offering comprehensive solutions:"
        lblCompanyDesc.Font = New Font("Segoe UI", 11)
        lblCompanyDesc.ForeColor = Color.FromArgb(100, 116, 139)
        lblCompanyDesc.AutoSize = False
        lblCompanyDesc.Location = New Point(40, 80)
        lblCompanyDesc.Size = New Size(620, 60)
        pnlLeft.Controls.Add(lblCompanyDesc)

        ' Services list
        Dim services = New String() {
            "📊 INCOME TAX - Complete tax planning and filing services",
            "📋 GST - GST compliance and registration",
            "🛡️ INSURANCE - Life, health, and property insurance",
            "🏠 PROPERTIES - Real estate and property management",
            "💰 LOANS - Home, personal, and business loans"
        }

        Dim yPos = 160
        For Each service In services
            Dim lblService As New Label()
            lblService.Text = service
            lblService.Font = New Font("Segoe UI", 10)
            lblService.ForeColor = Color.FromArgb(52, 73, 94)
            lblService.AutoSize = False
            lblService.Location = New Point(40, yPos)
            lblService.Size = New Size(620, 40)
            pnlLeft.Controls.Add(lblService)
            yPos += 50
        Next

        ' CredShield section
        Dim lblCredshieldTitle As New Label()
        lblCredshieldTitle.Text = "What is CredShield?"
        lblCredshieldTitle.Font = New Font("Segoe UI", 18, FontStyle.Bold)
        lblCredshieldTitle.ForeColor = Color.FromArgb(34, 197, 94)
        lblCredshieldTitle.AutoSize = False
        lblCredshieldTitle.Location = New Point(40, 440)
        lblCredshieldTitle.Size = New Size(620, 30)
        pnlLeft.Controls.Add(lblCredshieldTitle)

        Dim lblCredshieldDesc As New Label()
        lblCredshieldDesc.Text = "CredShield is a ONE-STOP SOLUTION that brings all GEE ASSOCIATES services together in a single platform. " & _
                                "This integrated approach significantly reduces documentation requirements and simplifies the entire process for you."
        lblCredshieldDesc.Font = New Font("Segoe UI", 10)
        lblCredshieldDesc.ForeColor = Color.FromArgb(100, 116, 139)
        lblCredshieldDesc.AutoSize = False
        lblCredshieldDesc.Location = New Point(40, 480)
        lblCredshieldDesc.Size = New Size(620, 100)
        pnlLeft.Controls.Add(lblCredshieldDesc)

        Dim lblBenefit As New Label()
        lblBenefit.Text = "✓ Unified platform for all services" & vbCrLf & "✓ Reduced documentation" & vbCrLf & "✓ Faster processing" & vbCrLf & "✓ Better service coordination"
        lblBenefit.Font = New Font("Segoe UI", 10)
        lblBenefit.ForeColor = Color.FromArgb(34, 197, 94)
        lblBenefit.AutoSize = False
        lblBenefit.Location = New Point(40, 600)
        lblBenefit.Size = New Size(620, 80)
        pnlLeft.Controls.Add(lblBenefit)

        ' Right side - Login options
        Dim pnlRight As New Panel()
        pnlRight.BackColor = Color.White
        pnlRight.Size = New Size(700, 800)
        pnlRight.Location = New Point(700, 0)
        pnlContent.Controls.Add(pnlRight)

        ' Login options title
        Dim lblLoginTitle As New Label()
        lblLoginTitle.Text = "Get Started"
        lblLoginTitle.Font = New Font("Segoe UI", 24, FontStyle.Bold)
        lblLoginTitle.ForeColor = Color.FromArgb(15, 23, 42)
        lblLoginTitle.AutoSize = False
        lblLoginTitle.TextAlign = ContentAlignment.MiddleCenter
        lblLoginTitle.Location = New Point(50, 100)
        lblLoginTitle.Size = New Size(600, 50)
        pnlRight.Controls.Add(lblLoginTitle)

        ' New user register button
        Dim btnRegister As New Button()
        btnRegister.Text = "📝 NEW USER" & vbCrLf & "Register Now"
        btnRegister.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        btnRegister.BackColor = Color.FromArgb(59, 130, 246)
        btnRegister.ForeColor = Color.White
        btnRegister.FlatStyle = FlatStyle.Flat
        btnRegister.FlatAppearance.BorderSize = 0
        btnRegister.Size = New Size(250, 120)
        btnRegister.Location = New Point(225, 200)
        btnRegister.Cursor = Cursors.Hand
        AddHandler btnRegister.Click, Sub()
                                          Dim registerForm As New FormRegister()
                                          registerForm.ShowDialog()
                                      End Sub
        pnlRight.Controls.Add(btnRegister)

        ' Client login button
        Dim btnClientLogin As New Button()
        btnClientLogin.Text = "👤 CLIENT LOGIN" & vbCrLf & "Existing User"
        btnClientLogin.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        btnClientLogin.BackColor = Color.FromArgb(34, 197, 94)
        btnClientLogin.ForeColor = Color.White
        btnClientLogin.FlatStyle = FlatStyle.Flat
        btnClientLogin.FlatAppearance.BorderSize = 0
        btnClientLogin.Size = New Size(250, 120)
        btnClientLogin.Location = New Point(225, 360)
        btnClientLogin.Cursor = Cursors.Hand
        AddHandler btnClientLogin.Click, Sub()
                                             Dim loginForm As New FormClientLogin()
                                             loginForm.ShowDialog()
                                         End Sub
        pnlRight.Controls.Add(btnClientLogin)

        ' Admin login button
        Dim btnAdminLogin As New Button()
        btnAdminLogin.Text = "👨‍💼 ADMIN LOGIN" & vbCrLf & "Control Panel"
        btnAdminLogin.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        btnAdminLogin.BackColor = Color.FromArgb(168, 85, 247)
        btnAdminLogin.ForeColor = Color.White
        btnAdminLogin.FlatStyle = FlatStyle.Flat
        btnAdminLogin.FlatAppearance.BorderSize = 0
        btnAdminLogin.Size = New Size(250, 120)
        btnAdminLogin.Location = New Point(225, 520)
        btnAdminLogin.Cursor = Cursors.Hand
        AddHandler btnAdminLogin.Click, Sub()
                                            Dim adminLoginForm As New FormAdminLogin()
                                            adminLoginForm.ShowDialog()
                                        End Sub
        pnlRight.Controls.Add(btnAdminLogin)

        ' Footer
        Dim lblFooter As New Label()
        lblFooter.Text = "© 2026 GEE ASSOCIATES - CredShield. All Rights Reserved."
        lblFooter.Font = New Font("Segoe UI", 9)
        lblFooter.ForeColor = Color.FromArgb(100, 116, 139)
        lblFooter.AutoSize = True
        lblFooter.Location = New Point(40, 770)
        pnlRight.Controls.Add(lblFooter)
    End Sub
End Class
