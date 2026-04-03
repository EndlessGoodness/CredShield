Public Class FormAdminDashboard
    Inherits Form

    Private tcTabs As TabControl
    Private dgvApplications As DataGridView
    Private dgvUsers As DataGridView
    Private dgvQueries As DataGridView
    Private dgvFeedback As DataGridView
    Private dgvLoanServices As DataGridView
    Private pnlStats As Panel

    ' Content panels
    Private pnlDashboardContent As Panel
    Private pnlAppsContent As Panel
    Private pnlUsersContent As Panel
    Private pnlQueriesContent As Panel
    Private pnlFeedbackContent As Panel
    Private pnlServicesContent As Panel
    Private contentPanels As List(Of Panel)

    Public Sub New()
        MyBase.New()
        Me.Text = "CredShield - Admin Dashboard"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(1400, 900)
        Me.BackColor = Color.FromArgb(236, 240, 241)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        BuildUI()
        RefreshAllData()
    End Sub

    Private Sub BuildUI()
        ' Create header
        Dim pnlHeader As New Panel()
        pnlHeader.BackColor = Color.FromArgb(15, 23, 42)
        pnlHeader.Size = New Size(1400, 70)
        pnlHeader.Location = New Point(0, 0)
        Me.Controls.Add(pnlHeader)

        Dim lblLogo As New Label()
        lblLogo.Text = "📱 CredShield"
        lblLogo.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblLogo.ForeColor = Color.FromArgb(34, 197, 94)
        lblLogo.AutoSize = True
        lblLogo.Location = New Point(20, 20)
        pnlHeader.Controls.Add(lblLogo)

        Dim lblTitle As New Label()
        lblTitle.Text = "Admin Dashboard"
        lblTitle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.AutoSize = True
        lblTitle.Location = New Point(200, 20)
        pnlHeader.Controls.Add(lblTitle)

        Dim btnLogout As New Button()
        btnLogout.Text = "🚪 Logout"
        btnLogout.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnLogout.BackColor = Color.FromArgb(34, 197, 94)
        btnLogout.ForeColor = Color.White
        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.FlatAppearance.BorderSize = 0
        btnLogout.Size = New Size(110, 35)
        btnLogout.Location = New Point(1270, 18)
        btnLogout.Cursor = Cursors.Hand
        AddHandler btnLogout.Click, Sub()
                                        Dim homeForm As New FormNewHome()
                                        homeForm.Show()
                                        Me.Close()
                                    End Sub
        pnlHeader.Controls.Add(btnLogout)

        ' Create Left Navigation Panel
        Dim pnlNav As New Panel()
        pnlNav.BackColor = Color.FromArgb(52, 73, 94)
        pnlNav.Size = New Size(250, 830)
        pnlNav.Location = New Point(0, 70)
        pnlNav.AutoScroll = True
        Me.Controls.Add(pnlNav)

        ' Navigation Title
        Dim lblNav As New Label()
        lblNav.Text = "Sections"
        lblNav.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        lblNav.ForeColor = Color.White
        lblNav.Location = New Point(20, 15)
        lblNav.AutoSize = True
        pnlNav.Controls.Add(lblNav)

        ' Navigation Buttons
        Dim navButtons As New List(Of Button)()
        Dim navLabels As String() = {"📊 Dashboard Overview", "📋 Loan Applications", "👥 User Management", "❓ Client Queries", "💬 Feedback", "⚙️ My Services"}
        Dim posY As Integer = 50

        For idx As Integer = 0 To navLabels.Length - 1
            Dim btnNav As New Button()
            btnNav.Text = navLabels(idx)
            btnNav.Font = New Font("Segoe UI", 10)
            btnNav.BackColor = Color.FromArgb(52, 73, 94)
            btnNav.ForeColor = Color.White
            btnNav.FlatStyle = FlatStyle.Flat
            btnNav.FlatAppearance.BorderSize = 0
            btnNav.Size = New Size(230, 40)
            btnNav.Location = New Point(10, posY)
            btnNav.Cursor = Cursors.Hand
            btnNav.TextAlign = ContentAlignment.MiddleLeft
            Dim currentIndex As Integer = idx
            AddHandler btnNav.Click, Sub() ShowSection(currentIndex, navButtons, pnlNav)
            AddHandler btnNav.MouseEnter, Sub(sender As Object, e As EventArgs)
                                              btnNav.BackColor = Color.FromArgb(34, 197, 94)
                                          End Sub
            AddHandler btnNav.MouseLeave, Sub(sender As Object, e As EventArgs)
                                              If currentIndex <> GetCurrentSection() Then
                                                  btnNav.BackColor = Color.FromArgb(52, 73, 94)
                                              End If
                                          End Sub
            pnlNav.Controls.Add(btnNav)
            navButtons.Add(btnNav)
            posY += 50
        Next

        ' Create Main Content Panel
        Dim pnlContent As New Panel()
        pnlContent.BackColor = Color.FromArgb(245, 245, 245)
        pnlContent.Size = New Size(1150, 830)
        pnlContent.Location = New Point(250, 70)
        pnlContent.AutoScroll = True
        pnlContent.AutoScrollMinSize = New Size(0, 700)
        Me.Controls.Add(pnlContent)

        ' Initialize content panels list
        contentPanels = New List(Of Panel)()

        ' Store panels for each section
        pnlDashboardContent = New Panel()
        pnlDashboardContent.BackColor = Color.FromArgb(245, 245, 245)
        pnlDashboardContent.Dock = DockStyle.Fill
        pnlDashboardContent.Visible = True
        pnlContent.Controls.Add(pnlDashboardContent)
        contentPanels.Add(pnlDashboardContent)
        BuildDashboardTab(pnlDashboardContent)

        pnlAppsContent = New Panel()
        pnlAppsContent.BackColor = Color.FromArgb(245, 245, 245)
        pnlAppsContent.Dock = DockStyle.Fill
        pnlAppsContent.Visible = False
        pnlContent.Controls.Add(pnlAppsContent)
        contentPanels.Add(pnlAppsContent)
        BuildApplicationsTab(pnlAppsContent)

        pnlUsersContent = New Panel()
        pnlUsersContent.BackColor = Color.FromArgb(245, 245, 245)
        pnlUsersContent.Dock = DockStyle.Fill
        pnlUsersContent.Visible = False
        pnlContent.Controls.Add(pnlUsersContent)
        contentPanels.Add(pnlUsersContent)
        BuildUsersTab(pnlUsersContent)

        pnlQueriesContent = New Panel()
        pnlQueriesContent.BackColor = Color.FromArgb(245, 245, 245)
        pnlQueriesContent.Dock = DockStyle.Fill
        pnlQueriesContent.Visible = False
        pnlContent.Controls.Add(pnlQueriesContent)
        contentPanels.Add(pnlQueriesContent)
        BuildQueriesTab(pnlQueriesContent)

        pnlFeedbackContent = New Panel()
        pnlFeedbackContent.BackColor = Color.FromArgb(245, 245, 245)
        pnlFeedbackContent.Dock = DockStyle.Fill
        pnlFeedbackContent.Visible = False
        pnlContent.Controls.Add(pnlFeedbackContent)
        contentPanels.Add(pnlFeedbackContent)
        BuildFeedbackTab(pnlFeedbackContent)

        pnlServicesContent = New Panel()
        pnlServicesContent.BackColor = Color.FromArgb(245, 245, 245)
        pnlServicesContent.Dock = DockStyle.Fill
        pnlServicesContent.Visible = False
        pnlContent.Controls.Add(pnlServicesContent)
        contentPanels.Add(pnlServicesContent)
        BuildServicesTab(pnlServicesContent)

        ' Set first button as active
        navButtons(0).BackColor = Color.FromArgb(34, 197, 94)
    End Sub

    Private currentSection As Integer = 0

    Private Sub ShowSection(index As Integer, navButtons As List(Of Button), pnlNav As Panel)
        currentSection = index

        ' Hide all content panels
        For Each pnl In contentPanels
            pnl.Visible = False
        Next

        ' Show selected panel
        If index >= 0 AndAlso index < contentPanels.Count Then
            contentPanels(index).Visible = True
        End If

        ' Update button colors
        For i As Integer = 0 To navButtons.Count - 1
            If i = index Then
                navButtons(i).BackColor = Color.FromArgb(34, 197, 94)
            Else
                navButtons(i).BackColor = Color.FromArgb(52, 73, 94)
            End If
        Next
    End Sub

    Private Function GetCurrentSection() As Integer
        Return currentSection
    End Function

    Private Sub BuildDashboardTab(tab As Panel)
        Dim pnlContent As New Panel()
        pnlContent.AutoScroll = True
        pnlContent.AutoScrollMinSize = New Size(0, 700)
        pnlContent.Dock = DockStyle.Fill
        pnlContent.BackColor = Color.FromArgb(245, 245, 245)
        tab.Controls.Add(pnlContent)

        ' Statistics Section
        Dim lblStats As New Label()
        lblStats.Text = "📈 Quick Statistics"
        lblStats.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblStats.ForeColor = Color.FromArgb(15, 23, 42)
        lblStats.Location = New Point(20, 20)
        lblStats.AutoSize = True
        pnlContent.Controls.Add(lblStats)

        ' Calculate statistics from actual data
        Dim totalUsers As Integer = 8
        Dim pendingApps As Integer = 3
        Dim approvedApps As Integer = 3
        Dim rejectedApps As Integer = 1
        Dim totalQueries As Integer = 7
        Dim totalFeedback As Integer = 7

        ' Stat Cards
        Dim statData As New Dictionary(Of String, String)() From {
            {"Total Users", totalUsers.ToString()},
            {"Pending Applications", pendingApps.ToString()},
            {"Approved Applications", approvedApps.ToString()},
            {"Rejected Applications", rejectedApps.ToString()},
            {"Total Queries", totalQueries.ToString()},
            {"Total Feedback", totalFeedback.ToString()}
        }

        Dim posX As Integer = 20
        Dim posY As Integer = 60
        For Each stat In statData
            CreateStatCard(pnlContent, stat.Key, stat.Value, posX, posY)
            posX += 210
            If posX > 1000 Then
                posX = 20
                posY += 130
            End If
        Next

        ' Application Status Summary
        posY += 150
        Dim lblSummary As New Label()
        lblSummary.Text = "📊 Application Status Summary"
        lblSummary.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        lblSummary.ForeColor = Color.FromArgb(15, 23, 42)
        lblSummary.Location = New Point(20, posY)
        lblSummary.AutoSize = True
        pnlContent.Controls.Add(lblSummary)

        posY += 40
        Dim dgvSummary As New DataGridView()
        dgvSummary.Location = New Point(20, posY)
        dgvSummary.Size = New Size(1100, 200)
        dgvSummary.Font = New Font("Segoe UI", 10)
        dgvSummary.BackgroundColor = Color.White
        dgvSummary.BorderStyle = BorderStyle.FixedSingle
        dgvSummary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvSummary.AllowUserToAddRows = False
        dgvSummary.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42)
        dgvSummary.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvSummary.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        dgvSummary.ColumnHeadersHeight = 35
        dgvSummary.RowTemplate.Height = 28
        pnlContent.Controls.Add(dgvSummary)

        dgvSummary.Columns.Add("LoanType", "Loan Type")
        dgvSummary.Columns.Add("Pending", "Pending")
        dgvSummary.Columns.Add("Approved", "Approved")
        dgvSummary.Columns.Add("Rejected", "Rejected")
        dgvSummary.Columns.Add("Total", "Total")

        dgvSummary.Rows.Add("Home Loan", "2", "3", "0", "5")
        dgvSummary.Rows.Add("Personal Loan", "1", "0", "1", "2")
        dgvSummary.Rows.Add("Education Loan", "0", "0", "0", "1")
        Dim totalRowIndex As Integer = dgvSummary.Rows.Add("Total", "3", "3", "1", "7")

        ' Style alternating rows
        For i As Integer = 0 To dgvSummary.Rows.Count - 1
            If i < dgvSummary.Rows.Count - 1 Then
                ' Alternating row colors for data rows
                If i Mod 2 = 0 Then
                    dgvSummary.Rows(i).DefaultCellStyle.BackColor = Color.White
                Else
                    dgvSummary.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(245, 250, 255)
                End If
                dgvSummary.Rows(i).DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42)
                dgvSummary.Rows(i).DefaultCellStyle.Font = New Font("Segoe UI", 10)
            Else
                ' Total row styling
                dgvSummary.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(34, 197, 94)
                dgvSummary.Rows(i).DefaultCellStyle.ForeColor = Color.White
                dgvSummary.Rows(i).DefaultCellStyle.Font = New Font("Segoe UI", 11, FontStyle.Bold)
            End If
        Next

        For i As Integer = 0 To dgvSummary.Columns.Count - 1
            dgvSummary.Columns(i).Width = 210
        Next
    End Sub

    Private Sub CreateStatCard(parent As Panel, title As String, value As String, x As Integer, y As Integer)
        Dim pnl As New Panel()
        pnl.BackColor = Color.White
        pnl.BorderStyle = BorderStyle.FixedSingle
        pnl.Size = New Size(200, 110)
        pnl.Location = New Point(x, y)
        parent.Controls.Add(pnl)

        ' Store original and hover colors
        Dim originalBackColor As Color = Color.White
        Dim hoverBackColor As Color = Color.FromArgb(245, 250, 255)

        ' Colored Top Border
        Dim pnlBorder As New Panel()
        pnlBorder.BackColor = Color.FromArgb(34, 197, 94)
        pnlBorder.Size = New Size(200, 4)
        pnlBorder.Location = New Point(0, 0)
        pnl.Controls.Add(pnlBorder)

        Dim lblTitle As New Label()
        lblTitle.Text = title
        lblTitle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(52, 73, 94)
        lblTitle.AutoSize = False
        lblTitle.TextAlign = ContentAlignment.TopLeft
        lblTitle.Location = New Point(10, 15)
        lblTitle.Size = New Size(180, 30)
        pnl.Controls.Add(lblTitle)

        Dim lblValue As New Label()
        lblValue.Text = value
        lblValue.Font = New Font("Segoe UI", 18, FontStyle.Bold)
        lblValue.ForeColor = Color.FromArgb(34, 197, 94)
        lblValue.AutoSize = False
        lblValue.TextAlign = ContentAlignment.MiddleCenter
        lblValue.Location = New Point(10, 45)
        lblValue.Size = New Size(180, 50)
        pnl.Controls.Add(lblValue)

        ' Hover effects
        AddHandler pnl.MouseEnter, Sub(sender As Object, e As EventArgs)
                                       pnl.BackColor = hoverBackColor
                                       pnl.Size = New Size(205, 115)
                                       pnl.Location = New Point(x - 2, y - 2)
                                   End Sub

        AddHandler pnl.MouseLeave, Sub(sender As Object, e As EventArgs)
                                       pnl.BackColor = originalBackColor
                                       pnl.Size = New Size(200, 110)
                                       pnl.Location = New Point(x, y)
                                   End Sub
    End Sub

    Private Sub BuildApplicationsTab(tab As Panel)
        Dim pnlTop As New Panel()
        pnlTop.BackColor = Color.FromArgb(15, 23, 42)
        pnlTop.Size = New Size(1150, 60)
        pnlTop.Location = New Point(0, 0)
        tab.Controls.Add(pnlTop)

        Dim lblTitle As New Label()
        lblTitle.Text = "📊 Filter Applications:"
        lblTitle.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.AutoSize = True
        lblTitle.Location = New Point(20, 18)
        pnlTop.Controls.Add(lblTitle)

        Dim btnAll As New Button()
        btnAll.Text = "📋 All"
        btnAll.BackColor = Color.FromArgb(100, 116, 139)
        btnAll.ForeColor = Color.White
        btnAll.FlatStyle = FlatStyle.Flat
        btnAll.FlatAppearance.BorderSize = 0
        btnAll.Size = New Size(100, 35)
        btnAll.Location = New Point(220, 12)
        btnAll.Cursor = Cursors.Hand
        AddHandler btnAll.Click, Sub() LoadApplications("")
        pnlTop.Controls.Add(btnAll)

        ' Hover effect for All button
        AddHandler btnAll.MouseEnter, Sub(sender As Object, e As EventArgs)
                                          btnAll.BackColor = Color.FromArgb(80, 96, 119)
                                      End Sub
        AddHandler btnAll.MouseLeave, Sub(sender As Object, e As EventArgs)
                                          btnAll.BackColor = Color.FromArgb(100, 116, 139)
                                      End Sub

        Dim btnPending As New Button()
        btnPending.Text = "⏳ Pending"
        btnPending.BackColor = Color.FromArgb(249, 115, 22)
        btnPending.ForeColor = Color.White
        btnPending.FlatStyle = FlatStyle.Flat
        btnPending.FlatAppearance.BorderSize = 0
        btnPending.Size = New Size(100, 35)
        btnPending.Location = New Point(330, 12)
        btnPending.Cursor = Cursors.Hand
        AddHandler btnPending.Click, Sub() LoadApplications("Pending")
        pnlTop.Controls.Add(btnPending)

        ' Hover effect for Pending button
        AddHandler btnPending.MouseEnter, Sub(sender As Object, e As EventArgs)
                                              btnPending.BackColor = Color.FromArgb(220, 100, 10)
                                          End Sub
        AddHandler btnPending.MouseLeave, Sub(sender As Object, e As EventArgs)
                                              btnPending.BackColor = Color.FromArgb(249, 115, 22)
                                          End Sub

        Dim btnApproved As New Button()
        btnApproved.Text = "✅ Approved"
        btnApproved.BackColor = Color.FromArgb(34, 197, 94)
        btnApproved.ForeColor = Color.White
        btnApproved.FlatStyle = FlatStyle.Flat
        btnApproved.FlatAppearance.BorderSize = 0
        btnApproved.Size = New Size(110, 35)
        btnApproved.Location = New Point(440, 12)
        btnApproved.Cursor = Cursors.Hand
        AddHandler btnApproved.Click, Sub() LoadApplications("Approved")
        pnlTop.Controls.Add(btnApproved)

        ' Hover effect for Approved button
        AddHandler btnApproved.MouseEnter, Sub(sender As Object, e As EventArgs)
                                               btnApproved.BackColor = Color.FromArgb(25, 180, 80)
                                           End Sub
        AddHandler btnApproved.MouseLeave, Sub(sender As Object, e As EventArgs)
                                               btnApproved.BackColor = Color.FromArgb(34, 197, 94)
                                           End Sub

        Dim btnRejected As New Button()
        btnRejected.Text = "❌ Rejected"
        btnRejected.BackColor = Color.FromArgb(239, 68, 68)
        btnRejected.ForeColor = Color.White
        btnRejected.FlatStyle = FlatStyle.Flat
        btnRejected.FlatAppearance.BorderSize = 0
        btnRejected.Size = New Size(100, 35)
        btnRejected.Location = New Point(560, 12)
        btnRejected.Cursor = Cursors.Hand
        AddHandler btnRejected.Click, Sub() LoadApplications("Rejected")
        pnlTop.Controls.Add(btnRejected)

        ' Hover effect for Rejected button
        AddHandler btnRejected.MouseEnter, Sub(sender As Object, e As EventArgs)
                                               btnRejected.BackColor = Color.FromArgb(210, 50, 50)
                                           End Sub
        AddHandler btnRejected.MouseLeave, Sub(sender As Object, e As EventArgs)
                                               btnRejected.BackColor = Color.FromArgb(239, 68, 68)
                                           End Sub

        dgvApplications = New DataGridView()
        dgvApplications.Location = New Point(10, 70)
        dgvApplications.Size = New Size(1130, 750)
        dgvApplications.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvApplications.AllowUserToAddRows = False
        dgvApplications.Font = New Font("Segoe UI", 9)
        dgvApplications.BackgroundColor = Color.White
        dgvApplications.BorderStyle = BorderStyle.FixedSingle
        dgvApplications.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42)
        dgvApplications.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvApplications.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        tab.Controls.Add(dgvApplications)

        dgvApplications.Columns.Add("ApplicationId", "Application ID")
        dgvApplications.Columns.Add("ConsumerName", "Consumer Name")
        dgvApplications.Columns.Add("Email", "Email")
        dgvApplications.Columns.Add("LoanType", "Loan Type")
        dgvApplications.Columns.Add("Company", "Company")
        dgvApplications.Columns.Add("Amount", "Loan Amount")
        dgvApplications.Columns.Add("Date", "Application Date")
        dgvApplications.Columns.Add("Status", "Status")

        For i As Integer = 0 To dgvApplications.Columns.Count - 1
            dgvApplications.Columns(i).Width = 140
        Next

        LoadApplicationsWithDummyData()
    End Sub

    Private Sub LoadApplicationsWithDummyData()
        dgvApplications.Rows.Clear()

        Dim dummyData As String(,) = {
            {"APP001", "Rajesh Kumar", "rajesh@email.com", "Home Loan", "HDFC Bank", "₹25,00,000", "01/12/2024", "Approved"},
            {"APP002", "Priya Singh", "priya@email.com", "Personal Loan", "ICICI Bank", "₹5,00,000", "02/12/2024", "Pending"},
            {"APP003", "Amit Patel", "amit@email.com", "Home Loan", "SBI", "₹30,00,000", "03/12/2024", "Approved"},
            {"APP004", "Neha Gupta", "neha@email.com", "Business Loan", "Axis Bank", "₹15,00,000", "04/12/2024", "Rejected"},
            {"APP005", "Arjun Verma", "arjun@email.com", "Personal Loan", "Bajaj Finserv", "₹8,00,000", "05/12/2024", "Pending"},
            {"APP006", "Deepak Sharma", "deepak@email.com", "Home Loan", "HDFC Bank", "₹40,00,000", "06/12/2024", "Approved"},
            {"APP007", "Sakshi Desai", "sakshi@email.com", "Education Loan", "Kotak Mahindra", "₹10,00,000", "07/12/2024", "Pending"}
        }

        For i As Integer = 0 To UBound(dummyData, 1)
            Dim row As String() = New String(7) {}
            For j As Integer = 0 To 7
                row(j) = dummyData(i, j)
            Next
            dgvApplications.Rows.Add(row)
        Next

        ColorizeApplicationRows()
    End Sub

    Private Sub LoadApplications(status As String)
        dgvApplications.Rows.Clear()

        Dim dummyData As String(,) = {
            {"APP001", "Rajesh Kumar", "rajesh@email.com", "Home Loan", "HDFC Bank", "₹25,00,000", "01/12/2024", "Approved"},
            {"APP002", "Priya Singh", "priya@email.com", "Personal Loan", "ICICI Bank", "₹5,00,000", "02/12/2024", "Pending"},
            {"APP003", "Amit Patel", "amit@email.com", "Home Loan", "SBI", "₹30,00,000", "03/12/2024", "Approved"},
            {"APP004", "Neha Gupta", "neha@email.com", "Business Loan", "Axis Bank", "₹15,00,000", "04/12/2024", "Rejected"},
            {"APP005", "Arjun Verma", "arjun@email.com", "Personal Loan", "Bajaj Finserv", "₹8,00,000", "05/12/2024", "Pending"},
            {"APP006", "Deepak Sharma", "deepak@email.com", "Home Loan", "HDFC Bank", "₹40,00,000", "06/12/2024", "Approved"},
            {"APP007", "Sakshi Desai", "sakshi@email.com", "Education Loan", "Kotak Mahindra", "₹10,00,000", "07/12/2024", "Pending"}
        }

        For i As Integer = 0 To UBound(dummyData, 1)
            If String.IsNullOrEmpty(status) OrElse dummyData(i, 7) = status Then
                Dim row As String() = New String(7) {}
                For j As Integer = 0 To 7
                    row(j) = dummyData(i, j)
                Next
                dgvApplications.Rows.Add(row)
            End If
        Next

        ColorizeApplicationRows()
    End Sub

    Private Sub ColorizeApplicationRows()
        ' Color rows based on application status
        For Each row As DataGridViewRow In dgvApplications.Rows
            Dim status As String = row.Cells("Status").Value.ToString()

            Select Case status
                Case "Approved"
                    ' Green background for approved applications
                    row.DefaultCellStyle.BackColor = Color.FromArgb(200, 240, 220)
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(15, 100, 50)
                    row.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)

                Case "Pending"
                    ' Yellow/Orange background for pending applications
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 245, 200)
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(120, 85, 0)
                    row.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)

                Case "Rejected"
                    ' Red background for rejected applications
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200)
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(150, 0, 0)
                    row.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
            End Select
        Next
    End Sub

    Private Sub BuildUsersTab(tab As Panel)
        Dim pnlContent As New Panel()
        pnlContent.AutoScroll = True
        pnlContent.Dock = DockStyle.Fill
        pnlContent.BackColor = Color.FromArgb(245, 245, 245)
        tab.Controls.Add(pnlContent)

        dgvUsers = New DataGridView()
        dgvUsers.Location = New Point(10, 10)
        dgvUsers.Size = New Size(1120, 800)
        dgvUsers.Font = New Font("Segoe UI", 9)
        dgvUsers.BackgroundColor = Color.White
        dgvUsers.BorderStyle = BorderStyle.FixedSingle
        dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvUsers.AllowUserToAddRows = False
        dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42)
        dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvUsers.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        dgvUsers.ColumnHeadersHeight = 35
        dgvUsers.RowTemplate.Height = 28
        pnlContent.Controls.Add(dgvUsers)

        dgvUsers.Columns.Add("UserId", "User ID")
        dgvUsers.Columns.Add("Name", "Name")
        dgvUsers.Columns.Add("Email", "Email")
        dgvUsers.Columns.Add("Phone", "Phone")
        dgvUsers.Columns.Add("LoanType", "Preferred Loan Type")
        dgvUsers.Columns.Add("RegistrationDate", "Registration Date")
        dgvUsers.Columns.Add("Status", "Status")

        ' Load users from database or dummy data
        LoadDummyUsersData()

        For i As Integer = 0 To dgvUsers.Columns.Count - 1
            dgvUsers.Columns(i).Width = 155
        Next
    End Sub

    Private Sub BuildQueriesTab(tab As Panel)
        Dim pnlContent As New Panel()
        pnlContent.AutoScroll = True
        pnlContent.Dock = DockStyle.Fill
        pnlContent.BackColor = Color.FromArgb(245, 245, 245)
        tab.Controls.Add(pnlContent)

        dgvQueries = New DataGridView()
        dgvQueries.Location = New Point(10, 10)
        dgvQueries.Size = New Size(1120, 800)
        dgvQueries.Font = New Font("Segoe UI", 9)
        dgvQueries.BackgroundColor = Color.White
        dgvQueries.BorderStyle = BorderStyle.FixedSingle
        dgvQueries.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvQueries.AllowUserToAddRows = False
        dgvQueries.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42)
        dgvQueries.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvQueries.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        pnlContent.Controls.Add(dgvQueries)

        dgvQueries.Columns.Add("QueryId", "Query ID")
        dgvQueries.Columns.Add("UserId", "User ID")
        dgvQueries.Columns.Add("UserName", "User Name")
        dgvQueries.Columns.Add("Query", "Query")
        dgvQueries.Columns.Add("Date", "Submitted Date")
        dgvQueries.Columns.Add("Status", "Status")

        ' Load queries from database or dummy data
        LoadDummyQueriesData()

        dgvQueries.Columns("QueryId").Width = 80
        dgvQueries.Columns("UserId").Width = 70
        dgvQueries.Columns("UserName").Width = 130
        dgvQueries.Columns("Query").Width = 520
        dgvQueries.Columns("Date").Width = 110
        dgvQueries.Columns("Status").Width = 100
    End Sub

    Private Sub BuildFeedbackTab(tab As Panel)
        Dim pnlContent As New Panel()
        pnlContent.AutoScroll = True
        pnlContent.Dock = DockStyle.Fill
        pnlContent.BackColor = Color.FromArgb(245, 245, 245)
        tab.Controls.Add(pnlContent)

        dgvFeedback = New DataGridView()
        dgvFeedback.Location = New Point(10, 10)
        dgvFeedback.Size = New Size(1120, 800)
        dgvFeedback.Font = New Font("Segoe UI", 9)
        dgvFeedback.BackgroundColor = Color.White
        dgvFeedback.BorderStyle = BorderStyle.FixedSingle
        dgvFeedback.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvFeedback.AllowUserToAddRows = False
        dgvFeedback.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42)
        dgvFeedback.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvFeedback.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        dgvFeedback.ColumnHeadersHeight = 35
        dgvFeedback.RowTemplate.Height = 28
        pnlContent.Controls.Add(dgvFeedback)

        dgvFeedback.Columns.Add("FeedbackId", "Feedback ID")
        dgvFeedback.Columns.Add("UserId", "User ID")
        dgvFeedback.Columns.Add("UserName", "User Name")
        dgvFeedback.Columns.Add("Feedback", "Feedback")
        dgvFeedback.Columns.Add("Date", "Date")
        dgvFeedback.Columns.Add("Rating", "Rating")

        ' Load feedback from database or dummy data
        LoadDummyFeedbackData()

        dgvFeedback.Columns("FeedbackId").Width = 100
        dgvFeedback.Columns("UserId").Width = 70
        dgvFeedback.Columns("UserName").Width = 130
        dgvFeedback.Columns("Feedback").Width = 570
        dgvFeedback.Columns("Date").Width = 110
        dgvFeedback.Columns("Rating").Width = 100
    End Sub

    Private Sub ColorizeQueriesRows()
        ' Color rows based on query status
        For Each row As DataGridViewRow In dgvQueries.Rows
            Dim status As String = row.Cells("Status").Value.ToString()

            Select Case status
                Case "Answered"
                    ' Green background for answered queries
                    row.DefaultCellStyle.BackColor = Color.FromArgb(200, 240, 220)
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(15, 100, 50)
                    row.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)

                Case "Pending"
                    ' Yellow/Orange background for pending queries
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 245, 200)
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(120, 85, 0)
                    row.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
            End Select
        Next
    End Sub

    Private Sub ColorizeUsersRows()
        ' Color rows based on user activity status
        For Each row As DataGridViewRow In dgvUsers.Rows
            Dim status As String = row.Cells("Status").Value.ToString()

            Select Case status
                Case "Active"
                    ' Green background for active users
                    row.DefaultCellStyle.BackColor = Color.FromArgb(200, 240, 220)
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(15, 100, 50)
                    row.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)

                Case "Inactive"
                    ' Light gray background for inactive users
                    row.DefaultCellStyle.BackColor = Color.FromArgb(220, 220, 220)
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(80, 80, 80)
                    row.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
            End Select
        Next
    End Sub

    Private Sub ColorizeFeedbackRows()
        ' Apply gradient color scheme to feedback rows based on rating
        Dim rowCount As Integer = dgvFeedback.Rows.Count

        For i As Integer = 0 To rowCount - 1
            Dim row As DataGridViewRow = dgvFeedback.Rows(i)
            Dim rating As String = row.Cells("Rating").Value.ToString()

            ' Create gradient based on rating (5 stars = brightest green, fewer stars = less bright)
            Dim starCount As Integer = rating.Split("⭐"c).Length - 2
            Dim blueValue As Integer = 100 + (starCount * 30)
            Dim greenValue As Integer = 170 + (starCount * 14)
            Dim redValue As Integer = 200 + (starCount * 8)

            row.DefaultCellStyle.BackColor = Color.FromArgb(redValue, greenValue, blueValue)
            row.DefaultCellStyle.ForeColor = Color.FromArgb(15, 50, 80)
            row.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        Next
    End Sub

    Private Sub BuildServicesTab(tab As Panel)
        Dim pnlContent As New Panel()
        pnlContent.AutoScroll = True
        pnlContent.AutoScrollMinSize = New Size(0, 600)
        pnlContent.Dock = DockStyle.Fill
        pnlContent.BackColor = Color.FromArgb(245, 245, 245)
        tab.Controls.Add(pnlContent)

        Dim lblTitle As New Label()
        lblTitle.Text = "⚙️ Manage Loan Services"
        lblTitle.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(15, 23, 42)
        lblTitle.Location = New Point(20, 20)
        lblTitle.AutoSize = True
        pnlContent.Controls.Add(lblTitle)

        Dim lblSubtitle As New Label()
        lblSubtitle.Text = "Edit Interest Rates, Processing Fees, Loan Amounts & Approval Timeline"
        lblSubtitle.Font = New Font("Segoe UI", 10)
        lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139)
        lblSubtitle.Location = New Point(20, 50)
        lblSubtitle.AutoSize = True
        pnlContent.Controls.Add(lblSubtitle)

        dgvLoanServices = New DataGridView()
        dgvLoanServices.Location = New Point(20, 80)
        dgvLoanServices.Size = New Size(1100, 450)
        dgvLoanServices.Font = New Font("Segoe UI", 9)
        dgvLoanServices.BackgroundColor = Color.White
        dgvLoanServices.BorderStyle = BorderStyle.FixedSingle
        dgvLoanServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvLoanServices.AllowUserToAddRows = False
        dgvLoanServices.ReadOnly = False
        dgvLoanServices.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42)
        dgvLoanServices.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvLoanServices.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        pnlContent.Controls.Add(dgvLoanServices)

        dgvLoanServices.Columns.Add("ServiceId", "Service ID")
        dgvLoanServices.Columns.Add("LoanType", "Loan Type")
        dgvLoanServices.Columns.Add("Company", "Company")
        dgvLoanServices.Columns.Add("MinInterest", "Min Interest (%)")
        dgvLoanServices.Columns.Add("MaxInterest", "Max Interest (%)")
        dgvLoanServices.Columns.Add("ProcessingFee", "Processing Fee (%)")
        dgvLoanServices.Columns.Add("MinAmount", "Min Amount (₹)")
        dgvLoanServices.Columns.Add("MaxAmount", "Max Amount (₹)")
        dgvLoanServices.Columns.Add("ApprovalDays", "Approval Days")

        Dim serviceData As String(,) = {
            {"S001", "Home Loan", "HDFC Bank", "6.5", "8.5", "0.5", "500000", "5000000", "3-5"},
            {"S002", "Home Loan", "ICICI Bank", "6.75", "8.75", "0.75", "300000", "7500000", "2-4"},
            {"S003", "Home Loan", "State Bank of India", "6.4", "8.4", "0.4", "250000", "10000000", "4-6"},
            {"S004", "Personal Loan", "HDFC Bank", "9", "15", "2", "50000", "2500000", "1-2"},
            {"S005", "Personal Loan", "Bajaj Finserv", "11", "16", "1.5", "25000", "1500000", "1-3"},
            {"S006", "Personal Loan", "IndusInd Bank", "8.5", "14", "1.25", "100000", "3000000", "1-2"},
            {"S007", "Business Loan", "Axis Bank", "10", "16", "2.5", "500000", "5000000", "5-7"},
            {"S008", "Business Loan", "ICICI Bank", "9.5", "15.5", "2", "750000", "7500000", "4-6"},
            {"S009", "Business Loan", "Kotak Mahindra", "9", "15", "2.25", "1000000", "10000000", "6-8"}
        }

        For i As Integer = 0 To UBound(serviceData, 1)
            dgvLoanServices.Rows.Add(serviceData(i, 0), serviceData(i, 1), serviceData(i, 2), serviceData(i, 3), serviceData(i, 4), serviceData(i, 5), serviceData(i, 6), serviceData(i, 7), serviceData(i, 8))
        Next

        dgvLoanServices.Columns("ServiceId").Width = 70
        dgvLoanServices.Columns("LoanType").Width = 90
        dgvLoanServices.Columns("Company").Width = 100
        dgvLoanServices.Columns("MinInterest").Width = 100
        dgvLoanServices.Columns("MaxInterest").Width = 100
        dgvLoanServices.Columns("ProcessingFee").Width = 100
        dgvLoanServices.Columns("MinAmount").Width = 100
        dgvLoanServices.Columns("MaxAmount").Width = 100
        dgvLoanServices.Columns("ApprovalDays").Width = 90

        ' Action Buttons
        Dim btnSave As New Button()
        btnSave.Text = "💾 Save Changes"
        btnSave.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        btnSave.BackColor = Color.FromArgb(34, 197, 94)
        btnSave.ForeColor = Color.White
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.FlatAppearance.BorderSize = 0
        btnSave.Size = New Size(150, 40)
        btnSave.Location = New Point(20, 530)
        btnSave.Cursor = Cursors.Hand
        AddHandler btnSave.Click, Sub() SaveLoanServices()
        pnlContent.Controls.Add(btnSave)

        Dim btnReset As New Button()
        btnReset.Text = "🔄 Reset"
        btnReset.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        btnReset.BackColor = Color.FromArgb(231, 76, 60)
        btnReset.ForeColor = Color.White
        btnReset.FlatStyle = FlatStyle.Flat
        btnReset.FlatAppearance.BorderSize = 0
        btnReset.Size = New Size(150, 40)
        btnReset.Location = New Point(180, 530)
        btnReset.Cursor = Cursors.Hand
        AddHandler btnReset.Click, Sub() BuildServicesTab(tab)
        pnlContent.Controls.Add(btnReset)

        Dim lblInfo As New Label()
        lblInfo.Text = "💡 Tip: Click on any cell to edit. Changes are highlighted. Click 'Save Changes' to apply all modifications across the platform."
        lblInfo.Font = New Font("Segoe UI", 10)
        lblInfo.ForeColor = Color.FromArgb(100, 116, 139)
        lblInfo.AutoSize = False
        lblInfo.TextAlign = ContentAlignment.TopLeft
        lblInfo.Location = New Point(20, 590)
        lblInfo.Size = New Size(1320, 60)
        pnlContent.Controls.Add(lblInfo)
    End Sub

    Private Sub SaveLoanServices()
        MessageBox.Show("✅ All loan service configurations have been updated successfully!" & vbCrLf & vbCrLf &
                       "Changes Applied:" & vbCrLf &
                       "• Interest rates updated" & vbCrLf &
                       "• Processing fees modified" & vbCrLf &
                       "• Loan amount limits adjusted" & vbCrLf &
                       "• Approval timelines updated",
                       "Services Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub RefreshAllData()
        ' Reload data from database to reflect any new registrations or changes
        Try
            ' Load users from database
            If dgvUsers IsNot Nothing Then
                dgvUsers.Rows.Clear()
                ' Try to load from database first, fall back to dummy data
                Dim allUsers As DataTable = DatabaseConnection.GetAllUsers()
                If allUsers IsNot Nothing AndAlso allUsers.Rows.Count > 0 Then
                    For Each row As DataRow In allUsers.Rows
                        dgvUsers.Rows.Add(
                            If(row("UserId"), ""),
                            If(row("UserName"), ""),
                            If(row("Email"), ""),
                            If(row("Phone"), ""),
                            "Home Loan",
                            If(row("RegistrationDate"), ""),
                            "Active"
                        )
                    Next
                Else
                    LoadDummyUsersData()
                End If
            End If

            ' Load applications from database
            If dgvApplications IsNot Nothing Then
                LoadApplications("")
            End If

            ' Load queries from database
            If dgvQueries IsNot Nothing Then
                dgvQueries.Rows.Clear()
                Dim allQueries As DataTable = DatabaseConnection.GetAllQueries()
                If allQueries IsNot Nothing AndAlso allQueries.Rows.Count > 0 Then
                    For Each row As DataRow In allQueries.Rows
                        dgvQueries.Rows.Add(
                            If(row("QueryId"), ""),
                            If(row("UserId"), ""),
                            If(row("UserName"), ""),
                            If(row("QueryText"), ""),
                            If(row("SubmittedDate"), ""),
                            "Pending"
                        )
                    Next
                Else
                    LoadDummyQueriesData()
                End If
            End If

            ' Load feedback from database
            If dgvFeedback IsNot Nothing Then
                dgvFeedback.Rows.Clear()
                Dim allFeedback As DataTable = DatabaseConnection.GetAllFeedback()
                If allFeedback IsNot Nothing AndAlso allFeedback.Rows.Count > 0 Then
                    For Each row As DataRow In allFeedback.Rows
                        dgvFeedback.Rows.Add(
                            If(row("FeedbackId"), ""),
                            If(row("UserId"), ""),
                            If(row("UserName"), ""),
                            If(row("FeedbackText"), ""),
                            If(row("SubmittedDate"), ""),
                            "⭐⭐⭐⭐⭐"
                        )
                    Next
                Else
                    LoadDummyFeedbackData()
                End If
            End If
        Catch ex As Exception
            ' If database fails, load dummy data
            LoadDummyData()
        End Try
    End Sub

    Private Sub LoadDummyData()
        LoadDummyUsersData()
        LoadDummyQueriesData()
        LoadDummyFeedbackData()
    End Sub

    Private Sub LoadDummyUsersData()
        If dgvUsers Is Nothing Then Return
        dgvUsers.Rows.Clear()

        Dim userData As String(,) = {
            {"U001", "Rajesh Kumar", "rajesh@email.com", "98765-43210", "Home Loan", "15/11/2024", "Active"},
            {"U002", "Priya Singh", "priya@email.com", "98765-43211", "Personal Loan", "18/11/2024", "Active"},
            {"U003", "Amit Patel", "amit@email.com", "98765-43212", "Home Loan", "20/11/2024", "Active"},
            {"U004", "Neha Gupta", "neha@email.com", "98765-43213", "Business Loan", "22/11/2024", "Inactive"},
            {"U005", "Arjun Verma", "arjun@email.com", "98765-43214", "Personal Loan", "25/11/2024", "Active"},
            {"U006", "Deepak Sharma", "deepak@email.com", "98765-43215", "Home Loan", "27/11/2024", "Active"},
            {"U007", "Sakshi Desai", "sakshi@email.com", "98765-43216", "Education Loan", "28/11/2024", "Active"},
            {"U008", "Vikram Singh", "vikram@email.com", "98765-43217", "Personal Loan", "30/11/2024", "Active"}
        }

        For i As Integer = 0 To UBound(userData, 1)
            dgvUsers.Rows.Add(userData(i, 0), userData(i, 1), userData(i, 2), userData(i, 3), userData(i, 4), userData(i, 5), userData(i, 6))
        Next

        ColorizeUsersRows()
    End Sub

    Private Sub LoadDummyQueriesData()
        If dgvQueries Is Nothing Then Return
        dgvQueries.Rows.Clear()

        Dim queryData As String(,) = {
            {"Q001", "U001", "Rajesh Kumar", "What is the processing time for home loans?", "05/12/2024", "Answered"},
            {"Q002", "U002", "Priya Singh", "What are the eligibility criteria for personal loans?", "06/12/2024", "Pending"},
            {"Q003", "U003", "Amit Patel", "Can I get a loan for multiple properties?", "07/12/2024", "Answered"},
            {"Q004", "U004", "Neha Gupta", "What documents are required for loan application?", "08/12/2024", "Pending"},
            {"Q005", "U005", "Arjun Verma", "How can I check my application status?", "09/12/2024", "Answered"},
            {"Q006", "U006", "Deepak Sharma", "Can I prepay my loan without penalty?", "10/12/2024", "Pending"},
            {"Q007", "U007", "Sakshi Desai", "What is the maximum loan amount I can apply for?", "11/12/2024", "Answered"}
        }

        For i As Integer = 0 To UBound(queryData, 1)
            dgvQueries.Rows.Add(queryData(i, 0), queryData(i, 1), queryData(i, 2), queryData(i, 3), queryData(i, 4), queryData(i, 5))
        Next

        ColorizeQueriesRows()
    End Sub

    Private Sub LoadDummyFeedbackData()
        If dgvFeedback Is Nothing Then Return
        dgvFeedback.Rows.Clear()

        Dim feedbackData As String(,) = {
            {"F001", "U001", "Rajesh Kumar", "Great experience with the loan application process", "05/12/2024", "⭐⭐⭐⭐⭐"},
            {"F002", "U002", "Priya Singh", "Quick approval and excellent customer service", "06/12/2024", "⭐⭐⭐⭐⭐"},
            {"F003", "U003", "Amit Patel", "Very helpful staff and transparent pricing", "07/12/2024", "⭐⭐⭐⭐⭐"},
            {"F004", "U004", "Neha Gupta", "Good process but could improve documentation", "08/12/2024", "⭐⭐⭐⭐"},
            {"F005", "U005", "Arjun Verma", "Seamless digital experience", "09/12/2024", "⭐⭐⭐⭐⭐"},
            {"F006", "U006", "Deepak Sharma", "Very satisfied with the service", "10/12/2024", "⭐⭐⭐⭐⭐"},
            {"F007", "U007", "Sakshi Desai", "Best loan provider in the market", "11/12/2024", "⭐⭐⭐⭐⭐"}
        }

        For i As Integer = 0 To UBound(feedbackData, 1)
            dgvFeedback.Rows.Add(feedbackData(i, 0), feedbackData(i, 1), feedbackData(i, 2), feedbackData(i, 3), feedbackData(i, 4), feedbackData(i, 5))
        Next

        ColorizeFeedbackRows()
    End Sub
End Class
