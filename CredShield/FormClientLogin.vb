Public Class FormClientLogin
    Inherits Form

    Private currentUserId As Integer = -1
    Private txtEmail As TextBox
    Private txtPassword As TextBox
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
        lblTitle.Text = "👤 LOGIN"
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

        Dim lblPassword As New Label()
        lblPassword.Text = "🔒 Password:"
        lblPassword.Font = New Font("Segoe UI", 11)
        lblPassword.ForeColor = Color.FromArgb(52, 73, 94)
        lblPassword.AutoSize = True
        lblPassword.Location = New Point(50, 130)
        tabLogin.Controls.Add(lblPassword)

        txtPassword = New TextBox()
        txtPassword.Location = New Point(50, 160)
        txtPassword.Size = New Size(780, 35)
        txtPassword.Font = New Font("Segoe UI", 11)
        txtPassword.BorderStyle = BorderStyle.FixedSingle
        txtPassword.PasswordChar = "*"c
        tabLogin.Controls.Add(txtPassword)

        Dim btnLogin As New Button()
        btnLogin.Text = "✅ LOGIN"
        btnLogin.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        btnLogin.BackColor = Color.FromArgb(34, 197, 94)
        btnLogin.ForeColor = Color.White
        btnLogin.FlatStyle = FlatStyle.Flat
        btnLogin.FlatAppearance.BorderSize = 0
        btnLogin.Size = New Size(200, 45)
        btnLogin.Location = New Point(350, 220)
        btnLogin.Cursor = Cursors.Hand
        AddHandler btnLogin.Click, Sub() Login()
        tabLogin.Controls.Add(btnLogin)
    End Sub

    Private Sub Login()
        If String.IsNullOrWhiteSpace(txtEmail.Text) Then
            MessageBox.Show("Please enter your username/email!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MessageBox.Show("Please enter your password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim username As String = txtEmail.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        ' Check for admin login
        If username = "admin" AndAlso password = "abc" Then
            MessageBox.Show("✅ Welcome Admin!" & vbCrLf & vbCrLf & "Logging into Admin Dashboard.", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtPassword.Clear()
            Dim adminDashboard As New FormAdminDashboard()
            adminDashboard.Show()
            Me.Close()
            Return
        End If

        ' Check for client login
        If username = "abc" AndAlso password = "abc" Then
            currentUserName = "abc"
            currentUserId = 1
            MessageBox.Show("✅ Welcome " & currentUserName & "!" & vbCrLf & vbCrLf & "Logging into Client Home.", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtPassword.Clear()
            Dim clientHome As New FormClientHome()
            clientHome.Show()
            Me.Close()
            Return
        End If

        ' Check if user exists in database
        currentUserId = DatabaseConnection.GetUserIDByEmail(username)

        If currentUserId > 0 Then
            currentUserName = DatabaseConnection.GetUserNameByEmail(username)
            MessageBox.Show("✅ Welcome " & currentUserName & "!" & vbCrLf & vbCrLf & "Logging into Client Home.", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtPassword.Clear()
            Dim clientHome As New FormClientHome()
            clientHome.Show()
            Me.Close()
        Else
            MessageBox.Show("❌ Invalid credentials. Please check your username and password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            currentUserId = -1
            currentUserName = ""
            txtPassword.Clear()
        End If
    End Sub
End Class
