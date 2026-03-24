Public Class Form2
    ' Loading Page for CredShield Application

    Private loadingCounter As Integer = 0

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set form properties
        Me.Text = "CredShield - Loading"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(700, 500)
        Me.BackColor = Color.FromArgb(52, 73, 94)
        Me.FormBorderStyle = FormBorderStyle.None
        Me.DoubleBuffered = True

        ' Create central panel
        Dim pnlCenter As New Panel()
        pnlCenter.BackColor = Color.FromArgb(52, 73, 94)
        pnlCenter.Size = New Size(700, 500)
        pnlCenter.Location = New Point(0, 0)
        Me.Controls.Add(pnlCenter)

        ' Create loading icon label
        Dim lblIcon As New Label()
        lblIcon.Text = "💼"
        lblIcon.Font = New Font("Arial", 60)
        lblIcon.ForeColor = Color.FromArgb(41, 128, 185)
        lblIcon.AutoSize = True
        lblIcon.Location = New Point(290, 50)
        pnlCenter.Controls.Add(lblIcon)

        ' Create loading label
        Dim lblLoading As New Label()
        lblLoading.Text = "CredShield"
        lblLoading.Font = New Font("Segoe UI", 32, FontStyle.Bold)
        lblLoading.ForeColor = Color.FromArgb(41, 128, 185)
        lblLoading.AutoSize = True
        lblLoading.Location = New Point(200, 120)
        pnlCenter.Controls.Add(lblLoading)

        ' Create status label
        Dim lblStatus As New Label()
        lblStatus.Text = "Initializing..."
        lblStatus.Font = New Font("Segoe UI", 14)
        lblStatus.ForeColor = Color.White
        lblStatus.AutoSize = True
        lblStatus.Location = New Point(290, 220)
        pnlCenter.Controls.Add(lblStatus)

        ' Create progress bar with better styling
        Dim prgProgress As New ProgressBar()
        prgProgress.Location = New Point(100, 280)
        prgProgress.Size = New Size(500, 30)
        prgProgress.Style = ProgressBarStyle.Continuous
        prgProgress.Value = 0
        prgProgress.ForeColor = Color.FromArgb(41, 128, 185)
        pnlCenter.Controls.Add(prgProgress)

        ' Create percentage label
        Dim lblPercent As New Label()
        lblPercent.Text = "0%"
        lblPercent.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        lblPercent.ForeColor = Color.FromArgb(41, 128, 185)
        lblPercent.AutoSize = True
        lblPercent.Location = New Point(320, 330)
        pnlCenter.Controls.Add(lblPercent)

        ' Create loading dots label for animation
        Dim lblDots As New Label()
        lblDots.Text = "●○○○○"
        lblDots.Font = New Font("Arial", 20)
        lblDots.ForeColor = Color.FromArgb(46, 204, 113)
        lblDots.AutoSize = True
        lblDots.Location = New Point(300, 380)
        pnlCenter.Controls.Add(lblDots)

        ' Create timer for loading animation
        Dim tmrLoading As New Timer()
        tmrLoading.Interval = 50
        Dim dotIndex As Integer = 0
        Dim dots As String() = {"●○○○○", "●●○○○", "●●●○○", "●●●●○", "●●●●●", "●●●●●"}

        AddHandler tmrLoading.Tick, Sub()
                                         loadingCounter += 5
                                         prgProgress.Value = If(loadingCounter > 100, 100, loadingCounter)
                                         lblStatus.Text = "Loading... " & loadingCounter & "%"
                                         lblPercent.Text = loadingCounter & "%"

                                         ' Animate dots
                                         dotIndex = (loadingCounter \ 10) Mod dots.Length
                                         lblDots.Text = dots(dotIndex)

                                         If loadingCounter >= 100 Then
                                             tmrLoading.Stop()
                                             Form3.Show()
                                             Me.Hide()
                                         End If
                                     End Sub
        tmrLoading.Start()
    End Sub
End Class
