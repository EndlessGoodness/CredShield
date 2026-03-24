Public Class FormAdminDashboard
    Inherits Form

    Private dgvApplications As DataGridView
    Private pnlContent As Panel

    Public Sub New()
        MyBase.New()
        Me.Text = "CredShield - Admin Dashboard"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(1400, 850)
        Me.BackColor = Color.FromArgb(236, 240, 241)
        Me.DoubleBuffered = True
        BuildUI()
    End Sub

    Private Sub BuildUI()
        ' Create header
        Dim pnlHeader As New Panel()
        pnlHeader.BackColor = Color.FromArgb(41, 128, 185)
        pnlHeader.Size = New Size(1400, 70)
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Padding = New Padding(15)
        Me.Controls.Add(pnlHeader)

        Dim lblTitle As New Label()
        lblTitle.Text = "👨‍💼 Admin Dashboard - Consumer Loan Applications"
        lblTitle.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.AutoSize = True
        lblTitle.Location = New Point(15, 18)
        pnlHeader.Controls.Add(lblTitle)

        Dim btnLogout As New Button()
        btnLogout.Text = "🚪 Logout"
        btnLogout.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnLogout.BackColor = Color.White
        btnLogout.ForeColor = Color.FromArgb(41, 128, 185)
        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.Size = New Size(100, 32)
        btnLogout.Location = New Point(1285, 19)
        btnLogout.Cursor = Cursors.Hand
        AddHandler btnLogout.Click, Sub()
                                        Form1.Show()
                                        Me.Close()
                                    End Sub
        pnlHeader.Controls.Add(btnLogout)

        ' Create filter panel
        Dim pnlFilter As New Panel()
        pnlFilter.BackColor = Color.FromArgb(52, 73, 94)
        pnlFilter.Size = New Size(1400, 60)
        pnlFilter.Location = New Point(0, 70)
        Me.Controls.Add(pnlFilter)

        Dim lblFilterTitle As New Label()
        lblFilterTitle.Text = "📊 Filter Applications:"
        lblFilterTitle.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        lblFilterTitle.ForeColor = Color.White
        lblFilterTitle.AutoSize = True
        lblFilterTitle.Location = New Point(15, 10)
        pnlFilter.Controls.Add(lblFilterTitle)

        ' Filter buttons
        Dim btnAll As New Button()
        btnAll.Text = "📋 All"
        btnAll.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        btnAll.BackColor = Color.FromArgb(149, 165, 166)
        btnAll.ForeColor = Color.White
        btnAll.FlatStyle = FlatStyle.Flat
        btnAll.Size = New Size(100, 35)
        btnAll.Location = New Point(15, 18)
        btnAll.Cursor = Cursors.Hand
        AddHandler btnAll.Click, Sub() LoadApplications("")
        pnlFilter.Controls.Add(btnAll)

        Dim btnPending As New Button()
        btnPending.Text = "⏳ Pending"
        btnPending.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        btnPending.BackColor = Color.FromArgb(241, 196, 15)
        btnPending.ForeColor = Color.White
        btnPending.FlatStyle = FlatStyle.Flat
        btnPending.Size = New Size(100, 35)
        btnPending.Location = New Point(125, 18)
        btnPending.Cursor = Cursors.Hand
        AddHandler btnPending.Click, Sub() LoadApplications("Pending")
        pnlFilter.Controls.Add(btnPending)

        Dim btnApproved As New Button()
        btnApproved.Text = "✅ Approved"
        btnApproved.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        btnApproved.BackColor = Color.FromArgb(46, 204, 113)
        btnApproved.ForeColor = Color.White
        btnApproved.FlatStyle = FlatStyle.Flat
        btnApproved.Size = New Size(100, 35)
        btnApproved.Location = New Point(235, 18)
        btnApproved.Cursor = Cursors.Hand
        AddHandler btnApproved.Click, Sub() LoadApplications("Approved")
        pnlFilter.Controls.Add(btnApproved)

        Dim btnRejected As New Button()
        btnRejected.Text = "❌ Rejected"
        btnRejected.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        btnRejected.BackColor = Color.FromArgb(231, 76, 60)
        btnRejected.ForeColor = Color.White
        btnRejected.FlatStyle = FlatStyle.Flat
        btnRejected.Size = New Size(100, 35)
        btnRejected.Location = New Point(345, 18)
        btnRejected.Cursor = Cursors.Hand
        AddHandler btnRejected.Click, Sub() LoadApplications("Rejected")
        pnlFilter.Controls.Add(btnRejected)

        ' Create DataGridView
        dgvApplications = New DataGridView()
        dgvApplications.Location = New Point(10, 140)
        dgvApplications.Size = New Size(1380, 680)
        dgvApplications.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvApplications.AllowUserToAddRows = False
        dgvApplications.AllowUserToDeleteRows = False
        dgvApplications.ReadOnly = False
        dgvApplications.Font = New Font("Segoe UI", 9)
        Me.Controls.Add(dgvApplications)

        ' Setup columns
        dgvApplications.Columns.Add("ApplicationId", "Application ID")
        dgvApplications.Columns.Add("ConsumerName", "Consumer Name")
        dgvApplications.Columns.Add("Email", "Email")
        dgvApplications.Columns.Add("Phone", "Phone")
        dgvApplications.Columns.Add("LoanType", "Loan Type")
        dgvApplications.Columns.Add("Company", "Company")
        dgvApplications.Columns.Add("Amount", "Loan Amount")
        dgvApplications.Columns.Add("Date", "Application Date")
        dgvApplications.Columns.Add("Status", "Status")

        ' Set column widths
        dgvApplications.Columns("ApplicationId").Width = 120
        dgvApplications.Columns("ConsumerName").Width = 100
        dgvApplications.Columns("Email").Width = 120
        dgvApplications.Columns("Phone").Width = 100
        dgvApplications.Columns("LoanType").Width = 90
        dgvApplications.Columns("Company").Width = 100
        dgvApplications.Columns("Amount").Width = 90
        dgvApplications.Columns("Date").Width = 120
        dgvApplications.Columns("Status").Width = 90

        ' Add CellEndEdit event for status changes
        AddHandler dgvApplications.CellEndEdit, Sub(sender As Object, e As DataGridViewCellEventArgs)
                                                    If e.ColumnIndex = dgvApplications.Columns("Status").Index Then
                                                        Dim appId = dgvApplications.Rows(e.RowIndex).Cells("ApplicationId").Value.ToString()
                                                        Dim newStatus = dgvApplications.Rows(e.RowIndex).Cells("Status").Value.ToString()
                                                        ApplicationManager.UpdateApplicationStatus(appId, newStatus)
                                                    End If
                                                End Sub

        ' Load initial data
        LoadApplications("")
    End Sub

    Private Sub LoadApplications(status As String)
        dgvApplications.Rows.Clear()

        Dim applications As List(Of LoanApplication)
        If String.IsNullOrEmpty(status) Then
            applications = ApplicationManager.GetAllApplications()
        Else
            applications = ApplicationManager.GetApplicationsByStatus(status)
        End If

        For Each app In applications
            dgvApplications.Rows.Add(New String() { _
                app.ApplicationId, _
                app.ConsumerName, _
                app.Email, _
                app.ContactNumber, _
                app.LoanType, _
                app.CompanyName, _
                "₹" & app.LoanAmount.ToString("N0"), _
                app.ApplicationDate.ToString("dd/MM/yyyy"), _
                app.Status _
            })
        Next
    End Sub
End Class
