Public Class FormClientHome
    Inherits Form

    Private bgImage As Image
    Private bgOpacity As Single = 0.3F

    Public Sub New()
        MyBase.New()
        Me.Text = "CredShield - Client Home"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(1000, 750)
        Me.BackColor = Color.White
        Me.DoubleBuffered = True
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False

        ' Load background image
        Try
            Dim possiblePaths As String() = {
                System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "background.png"),
                System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "background.png"),
                System.IO.Path.Combine(System.IO.Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName, "background.png")
            }

            For Each imagePath In possiblePaths
                If System.IO.File.Exists(imagePath) Then
                    bgImage = Image.FromFile(imagePath)
                    Exit For
                End If
            Next
        Catch
        End Try

        BuildUI()
    End Sub

    Private Sub BuildUI()
        ' Header Panel
        Dim pnlHeader As New Panel()
        pnlHeader.BackColor = Color.FromArgb(34, 197, 94)
        pnlHeader.Size = New Size(1000, 80)
        pnlHeader.Location = New Point(0, 0)
        Me.Controls.Add(pnlHeader)

        ' Header Title
        Dim lblTitle As New Label()
        lblTitle.Text = "CredShield - Client Dashboard"
        lblTitle.Font = New Font("Segoe UI", 18, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.AutoSize = False
        lblTitle.TextAlign = ContentAlignment.MiddleLeft
        lblTitle.Location = New Point(20, 15)
        lblTitle.Size = New Size(800, 50)
        pnlHeader.Controls.Add(lblTitle)

        ' Logout Button
        Dim btnLogout As New Button()
        btnLogout.Text = "🚪 Logout"
        btnLogout.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnLogout.BackColor = Color.White
        btnLogout.ForeColor = Color.FromArgb(34, 197, 94)
        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.FlatAppearance.BorderSize = 0
        btnLogout.Size = New Size(120, 40)
        btnLogout.Location = New Point(860, 20)
        btnLogout.Cursor = Cursors.Hand
        AddHandler btnLogout.Click, AddressOf LogoutClick
        pnlHeader.Controls.Add(btnLogout)

        ' Main Content Panel
        Dim pnlContent As New Panel()
        pnlContent.BackColor = Color.FromArgb(245, 245, 245)
        pnlContent.Size = New Size(1000, 670)
        pnlContent.Location = New Point(0, 80)
        Me.Controls.Add(pnlContent)

        ' Welcome Section
        Dim lblWelcome As New Label()
        lblWelcome.Text = "Welcome to Your Financial Dashboard"
        lblWelcome.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        lblWelcome.ForeColor = Color.FromArgb(34, 197, 94)
        lblWelcome.AutoSize = False
        lblWelcome.TextAlign = ContentAlignment.MiddleCenter
        lblWelcome.Location = New Point(0, 30)
        lblWelcome.Size = New Size(1000, 40)
        pnlContent.Controls.Add(lblWelcome)

        ' Services Grid
        Dim services As String() = {"📊 Loan Applications", "💰 Compare Loans", "💬 Send Feedback", "❓ Submit Query"}
        Dim serviceDescriptions As String() = {
            "Apply for loans and track your applications",
            "Compare different loan offers available",
            "Share your feedback with our team",
            "Submit your queries and get support"
        }

        Dim posX As Integer = 50
        Dim posY As Integer = 100

        For i As Integer = 0 To services.Length - 1
            ' Service Card Panel
            Dim pnlCard As New Panel()
            pnlCard.BackColor = Color.White
            pnlCard.BorderStyle = BorderStyle.FixedSingle
            pnlCard.Size = New Size(420, 140)
            pnlCard.Location = New Point(posX, posY)
            pnlCard.Cursor = Cursors.Hand
            pnlContent.Controls.Add(pnlCard)

            ' Service Title
            Dim lblService As New Label()
            lblService.Text = services(i)
            lblService.Font = New Font("Segoe UI", 13, FontStyle.Bold)
            lblService.ForeColor = Color.FromArgb(34, 197, 94)
            lblService.AutoSize = False
            lblService.TextAlign = ContentAlignment.TopLeft
            lblService.Location = New Point(15, 15)
            lblService.Size = New Size(390, 30)
            pnlCard.Controls.Add(lblService)

            ' Service Description
            Dim lblDesc As New Label()
            lblDesc.Text = serviceDescriptions(i)
            lblDesc.Font = New Font("Segoe UI", 10)
            lblDesc.ForeColor = Color.FromArgb(100, 116, 139)
            lblDesc.AutoSize = False
            lblDesc.TextAlign = ContentAlignment.TopLeft
            lblDesc.Location = New Point(15, 50)
            lblDesc.Size = New Size(390, 70)
            lblDesc.AutoSize = True
            pnlCard.Controls.Add(lblDesc)

            ' Click handler for service card
            Dim serviceIndex As Integer = i
            AddHandler pnlCard.Click, Sub(sender As Object, e As EventArgs) ServiceClick(serviceIndex)
            AddHandler lblService.Click, Sub(sender As Object, e As EventArgs) ServiceClick(serviceIndex)
            AddHandler lblDesc.Click, Sub(sender As Object, e As EventArgs) ServiceClick(serviceIndex)

            ' Arrange cards in 2x2 grid
            If i = 1 OrElse i = 3 Then
                posX = 50
                posY += 160
            Else
                posX = 520
            End If
        Next

        ' Footer
        Dim lblFooter As New Label()
        lblFooter.Text = "© 2026 CredShield by GEE ASSOCIATES"
        lblFooter.Font = New Font("Segoe UI", 9)
        lblFooter.ForeColor = Color.FromArgb(156, 163, 175)
        lblFooter.AutoSize = False
        lblFooter.TextAlign = ContentAlignment.MiddleCenter
        lblFooter.Location = New Point(0, 620)
        lblFooter.Size = New Size(1000, 50)
        pnlContent.Controls.Add(lblFooter)
    End Sub

    Private Sub ServiceClick(serviceIndex As Integer)
        Select Case serviceIndex
            Case 0
                ' Loan Applications - show selection form or use default
                Dim loanReg As New FormLoanRegistration(1, "Consumer Loan", "Client")
                loanReg.ShowDialog(Me)
            Case 1
                ' Compare Loans
                Dim loanComp As New FormLoanComparison()
                loanComp.ShowDialog(Me)
            Case 2
                ' Send Feedback
                Dim feedbackMsg As String = InputBox("Enter your feedback:", "Send Feedback")
                If Not String.IsNullOrWhiteSpace(feedbackMsg) Then
                    DatabaseConnection.InsertFeedback(1, feedbackMsg)
                    MessageBox.Show("Thank you for your feedback!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Case 3
                ' Submit Query
                Dim queryMsg As String = InputBox("Enter your query:", "Submit Query")
                If Not String.IsNullOrWhiteSpace(queryMsg) Then
                    DatabaseConnection.InsertQuery(1, queryMsg)
                    MessageBox.Show("Your query has been submitted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
        End Select
    End Sub

    Private Sub LogoutClick(sender As Object, e As EventArgs)
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Dim homeForm As New FormNewHome()
            homeForm.Show()
            Me.Close()
        End If
    End Sub

    Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
        If bgImage IsNot Nothing Then
            Dim cm As New System.Drawing.Imaging.ColorMatrix()
            cm.Matrix33 = bgOpacity
            Dim ia As New System.Drawing.Imaging.ImageAttributes()
            ia.SetColorMatrix(cm, System.Drawing.Imaging.ColorMatrixFlag.Default, System.Drawing.Imaging.ColorAdjustType.Bitmap)
            e.Graphics.DrawImage(bgImage,
                New Rectangle(0, 0, Me.Width, Me.Height),
                0, 0, bgImage.Width, bgImage.Height,
                GraphicsUnit.Pixel, ia)
        Else
            e.Graphics.Clear(Color.White)
        End If
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
    End Sub

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            If bgImage IsNot Nothing Then
                bgImage.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
End Class
