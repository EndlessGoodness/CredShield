Public Class Form1
    ' Welcome Page for CredShield Application

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set form properties
        Me.Text = "CredShield - Welcome"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(800, 600)
        Me.BackColor = Color.FromArgb(41, 128, 185)

        ' Create welcome label
        Dim lblWelcome As New Label()
        lblWelcome.Text = "Welcome to CredShield" & vbCrLf & "Your Financial Advisor"
        lblWelcome.Font = New Font("Arial", 28, FontStyle.Bold)
        lblWelcome.ForeColor = Color.White
        lblWelcome.AutoSize = False
        lblWelcome.TextAlign = ContentAlignment.MiddleCenter
        lblWelcome.Location = New Point(50, 100)
        lblWelcome.Size = New Size(700, 150)
        Me.Controls.Add(lblWelcome)

        ' Create description label
        Dim lblDescription As New Label()
        lblDescription.Text = "Manage your loans and financial needs with ease." & vbCrLf & "Get expert guidance on credit and borrowing."
        lblDescription.Font = New Font("Arial", 14)
        lblDescription.ForeColor = Color.White
        lblDescription.AutoSize = False
        lblDescription.TextAlign = ContentAlignment.MiddleCenter
        lblDescription.Location = New Point(50, 270)
        lblDescription.Size = New Size(700, 100)
        Me.Controls.Add(lblDescription)

        ' Create Get Started button
        Dim btnGetStarted As New Button()
        btnGetStarted.Text = "Get Started"
        btnGetStarted.Font = New Font("Arial", 14, FontStyle.Bold)
        btnGetStarted.BackColor = Color.White
        btnGetStarted.ForeColor = Color.FromArgb(41, 128, 185)
        btnGetStarted.Size = New Size(200, 50)
        btnGetStarted.Location = New Point(300, 400)
        btnGetStarted.Cursor = Cursors.Hand
        AddHandler btnGetStarted.Click, Sub() ShowLoadingForm()
        Me.Controls.Add(btnGetStarted)

        ' Create Exit button
        Dim btnExit As New Button()
        btnExit.Text = "Exit"
        btnExit.Font = New Font("Arial", 12)
        btnExit.BackColor = Color.White
        btnExit.ForeColor = Color.FromArgb(41, 128, 185)
        btnExit.Size = New Size(150, 40)
        btnExit.Location = New Point(325, 480)
        btnExit.Cursor = Cursors.Hand
        AddHandler btnExit.Click, Sub() Application.Exit()
        Me.Controls.Add(btnExit)
    End Sub

    Private Sub ShowLoadingForm()
        Form2.Show()
        Me.Hide()
    End Sub
End Class
