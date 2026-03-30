Public Class FormNewHome
    Inherits Form

    Private bgImage As Image
    Private bgOpacity As Single = 0.3F

    Public Sub New()
        MyBase.New()
        Me.Text = "CredShield - Welcome"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(900, 700)
        Me.BackColor = Color.White
        Me.DoubleBuffered = True
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = True
        Me.Icon = Nothing

        ' Load background image
        Try
            ' Try multiple possible locations for the background image
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
            ' Image not found, continue without background
        End Try

        BuildUI()
    End Sub

    Private Sub BuildUI()
        ' Initialize database
        DatabaseConnection.InitializeDatabase()

        ' Create header panel with gradient effect
        Dim pnlHeader As New Panel()
        pnlHeader.BackColor = Color.FromArgb(15, 23, 42)
        pnlHeader.Size = New Size(900, 160)
        pnlHeader.Location = New Point(0, 0)
        Me.Controls.Add(pnlHeader)

        ' Header title with better styling
        Dim lblHeaderTitle As New Label()
        lblHeaderTitle.Text = "GEE Associates"
        lblHeaderTitle.Font = New Font("Segoe UI", 18, FontStyle.Bold)
        lblHeaderTitle.ForeColor = Color.FromArgb(156, 163, 175)
        lblHeaderTitle.AutoSize = False
        lblHeaderTitle.TextAlign = ContentAlignment.MiddleCenter
        lblHeaderTitle.Location = New Point(0, 12)
        lblHeaderTitle.Size = New Size(900, 30)
        pnlHeader.Controls.Add(lblHeaderTitle)

        ' Main header title
        Dim lblMainTitle As New Label()
        lblMainTitle.Text = "PRESENTS"
        lblMainTitle.Font = New Font("Segoe UI", 16, FontStyle.Regular)
        lblMainTitle.ForeColor = Color.FromArgb(100, 116, 139)
        lblMainTitle.AutoSize = False
        lblMainTitle.TextAlign = ContentAlignment.MiddleCenter
        lblMainTitle.Location = New Point(0, 42)
        lblMainTitle.Size = New Size(900, 25)
        pnlHeader.Controls.Add(lblMainTitle)

        ' CredShield title in green
        Dim lblCredShieldTitle As New Label()
        lblCredShieldTitle.Text = "CredShield"
        lblCredShieldTitle.Font = New Font("Segoe UI", 32, FontStyle.Bold)
        lblCredShieldTitle.ForeColor = Color.FromArgb(34, 197, 94)
        lblCredShieldTitle.AutoSize = False
        lblCredShieldTitle.TextAlign = ContentAlignment.MiddleCenter
        lblCredShieldTitle.Location = New Point(0, 67)
        lblCredShieldTitle.Size = New Size(900, 50)
        pnlHeader.Controls.Add(lblCredShieldTitle)

        ' Divider line
        Dim pnlDivider As New Panel()
        pnlDivider.BackColor = Color.FromArgb(34, 197, 94)
        pnlDivider.Size = New Size(900, 3)
        pnlDivider.Location = New Point(0, 159)
        Me.Controls.Add(pnlDivider)

        ' Main content area - semi-transparent white
        Dim pnlContent As New Panel()
        pnlContent.BackColor = Color.FromArgb(245, 245, 245)
        pnlContent.Size = New Size(900, 540)
        pnlContent.Location = New Point(0, 160)
        Me.Controls.Add(pnlContent)

        ' Subtitle
        Dim lblSubtitle As New Label()
        lblSubtitle.Text = "Your One-Stop Financial Solution"
        lblSubtitle.Font = New Font("Segoe UI", 14, FontStyle.Regular)
        lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139)
        lblSubtitle.AutoSize = False
        lblSubtitle.TextAlign = ContentAlignment.MiddleCenter
        lblSubtitle.Location = New Point(0, 25)
        lblSubtitle.Size = New Size(900, 30)
        pnlContent.Controls.Add(lblSubtitle)

        ' Subtitle description
        Dim lblSubtitleDesc As New Label()
        lblSubtitleDesc.Text = "Bridging the gap between financial consultants and clients through integrated digital solutions"
        lblSubtitleDesc.Font = New Font("Segoe UI", 9)
        lblSubtitleDesc.ForeColor = Color.FromArgb(60, 80, 100)
        lblSubtitleDesc.AutoSize = False
        lblSubtitleDesc.TextAlign = ContentAlignment.MiddleCenter
        lblSubtitleDesc.Location = New Point(50, 55)
        lblSubtitleDesc.Size = New Size(800, 20)
        pnlContent.Controls.Add(lblSubtitleDesc)

        ' Container for buttons - moved below description
        Dim pnlButtonContainer As New Panel()
        pnlButtonContainer.BackColor = Color.Transparent
        pnlButtonContainer.Size = New Size(480, 90)
        pnlButtonContainer.Location = New Point(210, 305)
        pnlContent.Controls.Add(pnlButtonContainer)

        ' Login button with improved styling
        Dim btnLogin As New Button()
        btnLogin.Text = "🔐 LOGIN"
        btnLogin.Font = New Font("Segoe UI", 13, FontStyle.Bold)
        btnLogin.BackColor = Color.FromArgb(34, 197, 94)
        btnLogin.ForeColor = Color.White
        btnLogin.FlatStyle = FlatStyle.Flat
        btnLogin.FlatAppearance.BorderSize = 0
        btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(22, 163, 74)
        btnLogin.Size = New Size(200, 65)
        btnLogin.Location = New Point(0, 0)
        btnLogin.Cursor = Cursors.Hand
        AddHandler btnLogin.Click, AddressOf ClientLoginButtonClick
        AddHandler btnLogin.MouseHover, Sub()
                                            btnLogin.BackColor = Color.FromArgb(22, 163, 74)
                                            btnLogin.Font = New Font("Segoe UI", 13, FontStyle.Bold)
                                        End Sub
        AddHandler btnLogin.MouseLeave, Sub() btnLogin.BackColor = Color.FromArgb(34, 197, 94)
        pnlButtonContainer.Controls.Add(btnLogin)

        ' Register button with improved styling
        Dim btnRegister As New Button()
        btnRegister.Text = "📝 REGISTER"
        btnRegister.Font = New Font("Segoe UI", 13, FontStyle.Bold)
        btnRegister.BackColor = Color.FromArgb(59, 130, 246)
        btnRegister.ForeColor = Color.White
        btnRegister.FlatStyle = FlatStyle.Flat
        btnRegister.FlatAppearance.BorderSize = 0
        btnRegister.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 99, 235)
        btnRegister.Size = New Size(200, 65)
        btnRegister.Location = New Point(280, 0)
        btnRegister.Cursor = Cursors.Hand
        AddHandler btnRegister.Click, AddressOf RegisterButtonClick
        AddHandler btnRegister.MouseHover, Sub()
                                               btnRegister.BackColor = Color.FromArgb(37, 99, 235)
                                               btnRegister.Font = New Font("Segoe UI", 13, FontStyle.Bold)
                                           End Sub
        AddHandler btnRegister.MouseLeave, Sub() btnRegister.BackColor = Color.FromArgb(59, 130, 246)
        pnlButtonContainer.Controls.Add(btnRegister)

        ' Description box with background
        Dim pnlDescBox As New Panel()
        pnlDescBox.BackColor = Color.FromArgb(249, 250, 251)
        pnlDescBox.BorderStyle = BorderStyle.None
        pnlDescBox.Size = New Size(800, 120)
        pnlDescBox.Location = New Point(50, 85)
        pnlContent.Controls.Add(pnlDescBox)

        ' Description text
        Dim lblDescription As New Label()
        lblDescription.Text = "GEE Associates identified a critical need for a centralized digital platform that could unify all financial services under a single system. This realization led to the conceptualization of CredShield, a comprehensive solution aimed at bridging the gap between financial consultants and their clients." & vbCrLf & vbCrLf & "Enabling users to access multiple financial services through a single platform. By integrating various functionalities into one system, it eliminates redundancy, enhances efficiency, and provides a seamless user experience. The platform not only simplifies service access but also ensures better data management and communication between clients and administrators."
        lblDescription.Font = New Font("Segoe UI", 10)
        lblDescription.ForeColor = Color.FromArgb(80, 100, 120)
        lblDescription.AutoSize = False
        lblDescription.TextAlign = ContentAlignment.TopLeft
        lblDescription.Location = New Point(10, 10)
        lblDescription.Size = New Size(780, 100)
        pnlDescBox.Controls.Add(lblDescription)

        ' Features section
        Dim lblFeaturesTitle As New Label()
        lblFeaturesTitle.Text = "Why Choose CredShield?"
        lblFeaturesTitle.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        lblFeaturesTitle.ForeColor = Color.FromArgb(34, 197, 94)
        lblFeaturesTitle.AutoSize = False
        lblFeaturesTitle.TextAlign = ContentAlignment.MiddleCenter
        lblFeaturesTitle.Location = New Point(0, 410)
        lblFeaturesTitle.Size = New Size(900, 25)
        pnlContent.Controls.Add(lblFeaturesTitle)

        ' Features text
        Dim lblFeatures As New Label()
        lblFeatures.Text = "✓ Centralized Platform  •  ✓ Eliminate Redundancy  •  ✓ Enhanced Efficiency  •  ✓ Seamless Integration"
        lblFeatures.Font = New Font("Segoe UI", 9)
        lblFeatures.ForeColor = Color.FromArgb(100, 116, 139)
        lblFeatures.AutoSize = False
        lblFeatures.TextAlign = ContentAlignment.MiddleCenter
        lblFeatures.Location = New Point(50, 435)
        lblFeatures.Size = New Size(800, 50)
        pnlContent.Controls.Add(lblFeatures)

        ' Footer
        Dim lblFooter As New Label()
        lblFooter.Text = "© 2026 CredShield by GEE ASSOCIATES  |  Loans, Taxes & Financial Services"
        lblFooter.Font = New Font("Segoe UI", 8)
        lblFooter.ForeColor = Color.FromArgb(156, 163, 175)
        lblFooter.AutoSize = False
        lblFooter.TextAlign = ContentAlignment.MiddleCenter
        lblFooter.Location = New Point(0, 505)
        lblFooter.Size = New Size(900, 40)
        pnlContent.Controls.Add(lblFooter)
    End Sub

    Private Sub RegisterButtonClick(sender As Object, e As EventArgs)
        Try
            Dim registerForm As New FormRegister()
            registerForm.ShowDialog(Me)
        Catch ex As Exception
            MessageBox.Show("Error opening registration form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClientLoginButtonClick(sender As Object, e As EventArgs)
        Try
            Dim loginForm As New FormClientLogin()
            loginForm.ShowDialog(Me)
        Catch ex As Exception
            MessageBox.Show("Error opening login form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
        ' Draw background image with transparency before painting controls
        If bgImage IsNot Nothing Then
            ' Create a semi-transparent version of the background image
            Dim cm As New System.Drawing.Imaging.ColorMatrix()
            cm.Matrix33 = bgOpacity ' Set opacity (0.0 = transparent, 1.0 = opaque)

            Dim ia As New System.Drawing.Imaging.ImageAttributes()
            ia.SetColorMatrix(cm, System.Drawing.Imaging.ColorMatrixFlag.Default, System.Drawing.Imaging.ColorAdjustType.Bitmap)

            e.Graphics.DrawImage(bgImage,
                New Rectangle(0, 0, Me.Width, Me.Height),
                0, 0, bgImage.Width, bgImage.Height,
                GraphicsUnit.Pixel, ia)
        Else
            ' If no image, paint white background
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

