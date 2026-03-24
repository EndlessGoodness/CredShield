Public Class FormClientLogin
    Inherits Form

    Private currentUserId As Integer = -1
    Private txtEmail As TextBox
    Private currentUserName As String = ""

    Public Sub New()
        MyBase.New()
        Me.Text = "Client Login - CredShield"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(900, 700)
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
        pnlHeader.Size = New Size(900, 60)
        pnlHeader.Location = New Point(0, 0)
        Me.Controls.Add(pnlHeader)

        Dim lblTitle As New Label()
        lblTitle.Text = "👤 CLIENT LOGIN"
        lblTitle.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.AutoSize = False
        lblTitle.TextAlign = ContentAlignment.MiddleCenter
        lblTitle.Location = New Point(0, 10)
        lblTitle.Size = New Size(900, 40)
        pnlHeader.Controls.Add(lblTitle)

        ' Create tab control
        Dim tabControl As New TabControl()
        tabControl.Location = New Point(10, 70)
        tabControl.Size = New Size(880, 620)
        tabControl.Font = New Font("Segoe UI", 10)
        Me.Controls.Add(tabControl)

        ' Login Tab
        Dim tabLogin As New TabPage()
        tabLogin.Text = "🔐 Login"
        tabLogin.BackColor = Color.White
        tabControl.TabPages.Add(tabLogin)

        Dim lblEmail As New Label()
        lblEmail.Text = "📧 Email Address:"
        lblEmail.Font = New Font("Segoe UI", 11)
        lblEmail.ForeColor = Color.FromArgb(52, 73, 94)
        lblEmail.AutoSize = True
        lblEmail.Location = New Point(50, 50)
        tabLogin.Controls.Add(lblEmail)

        txtEmail = New TextBox()
        txtEmail.Location = New Point(50, 80)
        txtEmail.Size = New Size(780, 35)
        txtEmail.Font = New Font("Segoe UI", 11)
        txtEmail.BorderStyle = BorderStyle.FixedSingle
        tabLogin.Controls.Add(txtEmail)

        Dim btnLogin As New Button()
        btnLogin.Text = "✅ LOGIN"
        btnLogin.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        btnLogin.BackColor = Color.FromArgb(34, 197, 94)
        btnLogin.ForeColor = Color.White
        btnLogin.FlatStyle = FlatStyle.Flat
        btnLogin.FlatAppearance.BorderSize = 0
        btnLogin.Size = New Size(200, 45)
        btnLogin.Location = New Point(350, 140)
        btnLogin.Cursor = Cursors.Hand
        AddHandler btnLogin.Click, Sub() Login()
        tabLogin.Controls.Add(btnLogin)

        ' Services Tab
        Dim tabServices As New TabPage()
        tabServices.Text = "🎯 Our Services"
        tabServices.BackColor = Color.White
        tabControl.TabPages.Add(tabServices)

        Dim lblMessage As New Label()
        lblMessage.Text = "Select a service to register:"
        lblMessage.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        lblMessage.ForeColor = Color.FromArgb(15, 23, 42)
        lblMessage.AutoSize = True
        lblMessage.Location = New Point(50, 30)
        tabServices.Controls.Add(lblMessage)

        ' Service bubbles
        CreateServiceBubble(tabServices, 50, 80, "💼 INCOME TAX", "Income Tax Services", Color.FromArgb(59, 130, 246))
        CreateServiceBubble(tabServices, 250, 80, "📋 GST", "GST Compliance", Color.FromArgb(34, 197, 94))
        CreateServiceBubble(tabServices, 450, 80, "🛡️ INSURANCE", "Insurance Plans", Color.FromArgb(168, 85, 247))
        CreateServiceBubble(tabServices, 650, 80, "🏠 PROPERTIES", "Property Services", Color.FromArgb(234, 179, 8))
        
        CreateServiceBubble(tabServices, 150, 250, "💰 HOME LOANS", "Home Loan", Color.FromArgb(233, 30, 99))
        CreateServiceBubble(tabServices, 350, 250, "🏦 BANK LOANS", "Bank Loan", Color.FromArgb(0, 150, 136))
        CreateServiceBubble(tabServices, 550, 250, "💳 FINANCIAL", "Financial Loan", Color.FromArgb(255, 87, 34))
    End Sub

    Private Sub CreateServiceBubble(parentTab As TabPage, x As Integer, y As Integer, title As String, loanType As String, color As Color)
        ' Create rounded panel for bubble effect
        Dim bubble As New Button()
        bubble.Text = title
        bubble.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        bubble.BackColor = color
        bubble.ForeColor = Color.White
        bubble.FlatStyle = FlatStyle.Flat
        bubble.FlatAppearance.BorderSize = 0
        bubble.Size = New Size(150, 150)
        bubble.Location = New Point(x, y)
        bubble.Cursor = Cursors.Hand
        bubble.FlatAppearance.MouseOverBackColor = DarkenColor(color, 30)
        
        ' Add click event
        AddHandler bubble.Click, Sub()
                                     If currentUserId <= 0 Then
                                         MessageBox.Show("Please login first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                         Return
                                     End If
                                     ShowLoanRegistration(loanType)
                                 End Sub

        parentTab.Controls.Add(bubble)

        ' Add hover effect
        AddHandler bubble.MouseEnter, Sub()
                                          bubble.BackColor = DarkenColor(color, 20)
                                      End Sub
        AddHandler bubble.MouseLeave, Sub()
                                          bubble.BackColor = color
                                      End Sub
    End Sub

    Private Function DarkenColor(color As Color, amount As Integer) As Color
        Return Color.FromArgb( _
            Math.Max(color.R - amount, 0), _
            Math.Max(color.G - amount, 0), _
            Math.Max(color.B - amount, 0))
    End Function

    Private Sub Login()
        If String.IsNullOrWhiteSpace(txtEmail.Text) Then
            MessageBox.Show("Please enter your email!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        currentUserId = DatabaseConnection.GetUserIDByEmail(txtEmail.Text)

        If currentUserId > 0 Then
            MessageBox.Show("✅ Login successful! You can now select a service.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("❌ Email not found. Please register first.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            currentUserId = -1
        End If
    End Sub

    Private Sub ShowLoanRegistration(loanType As String)
        Dim registrationForm As New FormLoanRegistration(currentUserId, loanType, currentUserName)
        registrationForm.ShowDialog()
    End Sub
End Class
