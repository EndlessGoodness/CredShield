Public Class FormRegister
    Inherits Form

    Private txtName As TextBox
    Private txtEmail As TextBox
    Private txtLocation As TextBox
    Private txtContact As TextBox
    Private txtFeedback As TextBox
    Private storedUserId As Integer = -1

    Public Sub New()
        MyBase.New()
        Me.Text = "Register - CredShield"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(700, 800)
        Me.BackColor = Color.FromArgb(249, 250, 251)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        BuildUI()
    End Sub

    Private Sub BuildUI()
        ' Header
        Dim pnlHeader As New Panel()
        pnlHeader.BackColor = Color.FromArgb(59, 130, 246)
        pnlHeader.Size = New Size(700, 60)
        pnlHeader.Location = New Point(0, 0)
        Me.Controls.Add(pnlHeader)

        Dim lblTitle As New Label()
        lblTitle.Text = "📝 New User Registration"
        lblTitle.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.AutoSize = False
        lblTitle.TextAlign = ContentAlignment.MiddleCenter
        lblTitle.Location = New Point(0, 10)
        lblTitle.Size = New Size(700, 40)
        pnlHeader.Controls.Add(lblTitle)

        ' Main content
        Dim pnlContent As New Panel()
        pnlContent.BackColor = Color.White
        pnlContent.Size = New Size(680, 700)
        pnlContent.Location = New Point(10, 70)
        pnlContent.BorderStyle = BorderStyle.FixedSingle
        Me.Controls.Add(pnlContent)

        Dim yPos = 20

        ' Name
        Dim lblName As New Label()
        lblName.Text = "👤 Full Name:"
        lblName.Font = New Font("Segoe UI", 10)
        lblName.ForeColor = Color.FromArgb(52, 73, 94)
        lblName.AutoSize = True
        lblName.Location = New Point(20, yPos)
        pnlContent.Controls.Add(lblName)

        yPos += 25
        txtName = New TextBox()
        txtName.Location = New Point(20, yPos)
        txtName.Size = New Size(640, 30)
        txtName.Font = New Font("Segoe UI", 10)
        txtName.BorderStyle = BorderStyle.FixedSingle
        pnlContent.Controls.Add(txtName)

        yPos += 40

        ' Email
        Dim lblEmail As New Label()
        lblEmail.Text = "📧 Email Address:"
        lblEmail.Font = New Font("Segoe UI", 10)
        lblEmail.ForeColor = Color.FromArgb(52, 73, 94)
        lblEmail.AutoSize = True
        lblEmail.Location = New Point(20, yPos)
        pnlContent.Controls.Add(lblEmail)

        yPos += 25
        txtEmail = New TextBox()
        txtEmail.Location = New Point(20, yPos)
        txtEmail.Size = New Size(640, 30)
        txtEmail.Font = New Font("Segoe UI", 10)
        txtEmail.BorderStyle = BorderStyle.FixedSingle
        pnlContent.Controls.Add(txtEmail)

        yPos += 40

        ' Location
        Dim lblLocation As New Label()
        lblLocation.Text = "📍 Location:"
        lblLocation.Font = New Font("Segoe UI", 10)
        lblLocation.ForeColor = Color.FromArgb(52, 73, 94)
        lblLocation.AutoSize = True
        lblLocation.Location = New Point(20, yPos)
        pnlContent.Controls.Add(lblLocation)

        yPos += 25
        txtLocation = New TextBox()
        txtLocation.Location = New Point(20, yPos)
        txtLocation.Size = New Size(640, 30)
        txtLocation.Font = New Font("Segoe UI", 10)
        txtLocation.BorderStyle = BorderStyle.FixedSingle
        pnlContent.Controls.Add(txtLocation)

        yPos += 40

        ' Contact
        Dim lblContact As New Label()
        lblContact.Text = "📱 Contact Number:"
        lblContact.Font = New Font("Segoe UI", 10)
        lblContact.ForeColor = Color.FromArgb(52, 73, 94)
        lblContact.AutoSize = True
        lblContact.Location = New Point(20, yPos)
        pnlContent.Controls.Add(lblContact)

        yPos += 25
        txtContact = New TextBox()
        txtContact.Location = New Point(20, yPos)
        txtContact.Size = New Size(640, 30)
        txtContact.Font = New Font("Segoe UI", 10)
        txtContact.BorderStyle = BorderStyle.FixedSingle
        pnlContent.Controls.Add(txtContact)

        yPos += 40

        ' Feedback
        Dim lblFeedback As New Label()
        lblFeedback.Text = "💬 Feedback/Suggestions:"
        lblFeedback.Font = New Font("Segoe UI", 10)
        lblFeedback.ForeColor = Color.FromArgb(52, 73, 94)
        lblFeedback.AutoSize = True
        lblFeedback.Location = New Point(20, yPos)
        pnlContent.Controls.Add(lblFeedback)

        yPos += 25
        txtFeedback = New TextBox()
        txtFeedback.Location = New Point(20, yPos)
        txtFeedback.Size = New Size(640, 80)
        txtFeedback.Font = New Font("Segoe UI", 10)
        txtFeedback.Multiline = True
        txtFeedback.BorderStyle = BorderStyle.FixedSingle
        pnlContent.Controls.Add(txtFeedback)

        yPos += 100

        ' Register Button
        Dim btnRegister As New Button()
        btnRegister.Text = "✅ REGISTER"
        btnRegister.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        btnRegister.BackColor = Color.FromArgb(34, 197, 94)
        btnRegister.ForeColor = Color.White
        btnRegister.FlatStyle = FlatStyle.Flat
        btnRegister.FlatAppearance.BorderSize = 0
        btnRegister.Size = New Size(300, 40)
        btnRegister.Location = New Point(190, yPos)
        btnRegister.Cursor = Cursors.Hand
        AddHandler btnRegister.Click, Sub() RegisterUser()
        pnlContent.Controls.Add(btnRegister)

        yPos += 50

        ' Close Button
        Dim btnClose As New Button()
        btnClose.Text = "✕ CLOSE"
        btnClose.Font = New Font("Segoe UI", 10)
        btnClose.BackColor = Color.FromArgb(149, 165, 166)
        btnClose.ForeColor = Color.White
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.FlatAppearance.BorderSize = 0
        btnClose.Size = New Size(300, 35)
        btnClose.Location = New Point(190, yPos)
        btnClose.Cursor = Cursors.Hand
        AddHandler btnClose.Click, Sub() Me.Close()
        pnlContent.Controls.Add(btnClose)
    End Sub

    Private Sub RegisterUser()
        ' Validate inputs
        If String.IsNullOrWhiteSpace(txtName.Text) OrElse String.IsNullOrWhiteSpace(txtEmail.Text) OrElse _
           String.IsNullOrWhiteSpace(txtLocation.Text) OrElse String.IsNullOrWhiteSpace(txtContact.Text) Then
            MessageBox.Show("Please fill in all required fields!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Check if email already exists
        If DatabaseConnection.EmailExists(txtEmail.Text) Then
            MessageBox.Show("Email already registered!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Insert user
        storedUserId = DatabaseConnection.InsertUser(txtName.Text, txtEmail.Text, txtLocation.Text, txtContact.Text)

        If storedUserId > 0 Then
            ' Save feedback if provided
            If Not String.IsNullOrWhiteSpace(txtFeedback.Text) Then
                DatabaseConnection.InsertFeedback(storedUserId, txtFeedback.Text)
            End If

            MessageBox.Show("✅ YOU ARE NOW REGISTERED!" & vbCrLf & vbCrLf & _
                          "Your registration has been saved successfully." & vbCrLf & _
                          "You can now login to access our services.", _
                          "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            MessageBox.Show("Registration failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class
