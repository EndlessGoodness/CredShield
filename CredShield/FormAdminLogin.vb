Public Class FormAdminLogin
    Inherits Form

    Public Sub New()
        MyBase.New()
        Me.Text = "CredShield - Admin Login"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(600, 450)
        Me.BackColor = Color.FromArgb(41, 128, 185)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        BuildUI()
    End Sub

    Private Sub BuildUI()
        ' Create main panel
        Dim pnlMain As New Panel()
        pnlMain.BackColor = Color.White
        pnlMain.Size = New Size(400, 300)
        pnlMain.Location = New Point(100, 75)
        pnlMain.BorderStyle = BorderStyle.FixedSingle
        Me.Controls.Add(pnlMain)

        ' Title
        Dim lblTitle As New Label()
        lblTitle.Text = "🔐 Admin Login"
        lblTitle.Font = New Font("Segoe UI", 18, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(41, 128, 185)
        lblTitle.AutoSize = False
        lblTitle.TextAlign = ContentAlignment.MiddleCenter
        lblTitle.Location = New Point(0, 20)
        lblTitle.Size = New Size(400, 40)
        pnlMain.Controls.Add(lblTitle)

        ' Email Label
        Dim lblEmail As New Label()
        lblEmail.Text = "📧 Email:"
        lblEmail.Font = New Font("Segoe UI", 10)
        lblEmail.ForeColor = Color.FromArgb(52, 73, 94)
        lblEmail.AutoSize = True
        lblEmail.Location = New Point(30, 75)
        pnlMain.Controls.Add(lblEmail)

        ' Email TextBox
        Dim txtEmail As New TextBox()
        txtEmail.Location = New Point(30, 100)
        txtEmail.Size = New Size(340, 35)
        txtEmail.Font = New Font("Segoe UI", 11)
        txtEmail.BorderStyle = BorderStyle.FixedSingle
        pnlMain.Controls.Add(txtEmail)

        ' Password Label
        Dim lblPassword As New Label()
        lblPassword.Text = "🔒 Password:"
        lblPassword.Font = New Font("Segoe UI", 10)
        lblPassword.ForeColor = Color.FromArgb(52, 73, 94)
        lblPassword.AutoSize = True
        lblPassword.Location = New Point(30, 145)
        pnlMain.Controls.Add(lblPassword)

        ' Password TextBox
        Dim txtPassword As New TextBox()
        txtPassword.Location = New Point(30, 170)
        txtPassword.Size = New Size(340, 35)
        txtPassword.Font = New Font("Segoe UI", 11)
        txtPassword.PasswordChar = "*"c
        txtPassword.BorderStyle = BorderStyle.FixedSingle
        pnlMain.Controls.Add(txtPassword)

        ' Login Button
        Dim btnLogin As New Button()
        btnLogin.Text = "🚀 Login"
        btnLogin.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        btnLogin.BackColor = Color.FromArgb(41, 128, 185)
        btnLogin.ForeColor = Color.White
        btnLogin.FlatStyle = FlatStyle.Flat
        btnLogin.Size = New Size(150, 40)
        btnLogin.Location = New Point(125, 235)
        btnLogin.Cursor = Cursors.Hand
        AddHandler btnLogin.Click, Sub()
                                       If txtEmail.Text = "admin" AndAlso txtPassword.Text = "pass" Then
                                           Dim adminForm As New FormAdminDashboard()
                                           adminForm.Show()
                                           Me.Hide()
                                       Else
                                           MessageBox.Show("Invalid credentials!", "Admin Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                           txtEmail.Clear()
                                           txtPassword.Clear()
                                           txtEmail.Focus()
                                       End If
                                   End Sub
        pnlMain.Controls.Add(btnLogin)

        ' Back Button
        Dim btnBack As New Button()
        btnBack.Text = "← Back"
        btnBack.Font = New Font("Segoe UI", 10)
        btnBack.BackColor = Color.FromArgb(149, 165, 166)
        btnBack.ForeColor = Color.White
        btnBack.FlatStyle = FlatStyle.Flat
        btnBack.Size = New Size(100, 35)
        btnBack.Location = New Point(250, 235)
        btnBack.Cursor = Cursors.Hand
        AddHandler btnBack.Click, Sub()
                                      FormNewHome.Show()
                                      Me.Close()
                                  End Sub
        pnlMain.Controls.Add(btnBack)

        ' Credentials info at bottom
        Dim lblInfo As New Label()
        lblInfo.Text = "Demo: Email = admin | Password = pass"
        lblInfo.Font = New Font("Segoe UI", 8)
        lblInfo.ForeColor = Color.FromArgb(100, 100, 100)
        lblInfo.AutoSize = True
        lblInfo.Location = New Point(70, 390)
        Me.Controls.Add(lblInfo)
    End Sub
End Class
