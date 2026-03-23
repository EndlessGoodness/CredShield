Public Class Form2
    ' Loading Page for CredShield Application

    Private loadingCounter As Integer = 0

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set form properties
        Me.Text = "CredShield - Loading"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(600, 400)
        Me.BackColor = Color.FromArgb(52, 73, 94)
        Me.FormBorderStyle = FormBorderStyle.None

        ' Create loading label
        Dim lblLoading As New Label()
        lblLoading.Text = "CredShield"
        lblLoading.Font = New Font("Arial", 32, FontStyle.Bold)
        lblLoading.ForeColor = Color.FromArgb(41, 128, 185)
        lblLoading.AutoSize = True
        lblLoading.Location = New Point(200, 80)
        Me.Controls.Add(lblLoading)

        ' Create status label
        Dim lblStatus As New Label()
        lblStatus.Text = "Loading..."
        lblStatus.Font = New Font("Arial", 14)
        lblStatus.ForeColor = Color.White
        lblStatus.AutoSize = True
        lblStatus.Location = New Point(250, 180)
        Me.Controls.Add(lblStatus)

        ' Create progress bar
        Dim prgProgress As New ProgressBar()
        prgProgress.Location = New Point(75, 250)
        prgProgress.Size = New Size(450, 30)
        prgProgress.Style = ProgressBarStyle.Continuous
        prgProgress.Value = 0
        Me.Controls.Add(prgProgress)

        ' Create timer for loading animation
        Dim tmrLoading As New Timer()
        tmrLoading.Interval = 50
        AddHandler tmrLoading.Tick, Sub()
                                         loadingCounter += 5
                                         prgProgress.Value = If(loadingCounter > 100, 100, loadingCounter)
                                         lblStatus.Text = "Loading... " & loadingCounter & "%"

                                         If loadingCounter >= 100 Then
                                             tmrLoading.Stop()
                                             Form3.Show()
                                             Me.Hide()
                                         End If
                                     End Sub
        tmrLoading.Start()
    End Sub
End Class
