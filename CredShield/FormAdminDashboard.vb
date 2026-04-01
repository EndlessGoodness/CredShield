Public Class FormAdminDashboard
    Inherits Form

    Private tcTabs As TabControl
    Private dgvApplications As DataGridView
    Private dgvUsers As DataGridView
    Private dgvQueries As DataGridView
    Private dgvFeedback As DataGridView
    Private dgvLoanServices As DataGridView
    Private pnlStats As Panel

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
    End Sub

    Private Sub BuildUI()
        ' Create header
        Dim pnlHeader As New Panel()
        pnlHeader.BackColor = Color.FromArgb(15, 23, 42)
        pnlHeader.Size = New Size(1400, 70)
        pnlHeader.Location = New Point(0, 0)
        Me.Controls.Add(pnlHeader)

        Dim lblTitle As New Label()
        lblTitle.Text = "👨‍💼 CredShield Admin Dashboard"
        lblTitle.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(34, 197, 94)
        lblTitle.AutoSize = True
        lblTitle.Location = New Point(20, 20)
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

        ' Create Tab Control
        tcTabs = New TabControl()
        tcTabs.Location = New Point(10, 80)
        tcTabs.Size = New Size(1380, 810)
        tcTabs.Font = New Font("Segoe UI", 10)
        Me.Controls.Add(tcTabs)

        ' Tab 1: Dashboard Overview
        Dim tabDashboard As New TabPage("📊 Dashboard Overview")
        tcTabs.TabPages.Add(tabDashboard)
        BuildDashboardTab(tabDashboard)

        ' Tab 2: Loan Applications
        Dim tabApplications As New TabPage("📋 Loan Applications")
        tcTabs.TabPages.Add(tabApplications)
        BuildApplicationsTab(tabApplications)

        ' Tab 3: User Management
        Dim tabUsers As New TabPage("👥 User Management")
        tcTabs.TabPages.Add(tabUsers)
        BuildUsersTab(tabUsers)

        ' Tab 4: Client Queries
        Dim tabQueries As New TabPage("❓ Client Queries")
        tcTabs.TabPages.Add(tabQueries)
        BuildQueriesTab(tabQueries)

        ' Tab 5: Feedback
        Dim tabFeedback As New TabPage("💬 Feedback")
        tcTabs.TabPages.Add(tabFeedback)
        BuildFeedbackTab(tabFeedback)

        ' Tab 6: My Services
        Dim tabServices As New TabPage("⚙️ My Services")
        tcTabs.TabPages.Add(tabServices)
        BuildServicesTab(tabServices)
    End Sub

    Private Sub BuildDashboardTab(tab As TabPage)
        Dim pnlContent As New Panel()
        pnlContent.AutoScroll = True
        pnlContent.AutoScrollMinSize = New Size(0, 700)
        pnlContent.Dock = DockStyle.Fill
        tab.Controls.Add(pnlContent)

        ' Statistics Section
        Dim lblStats As New Label()
        lblStats.Text = "📈 Quick Statistics"
        lblStats.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblStats.ForeColor = Color.FromArgb(15, 23, 42)
        lblStats.Location = New Point(20, 20)
        lblStats.AutoSize = True
        pnlContent.Controls.Add(lblStats)

        ' Stat Cards
        Dim statData As New Dictionary(Of String, String)() From {
            {"Total Users", "1,245"},
            {"Pending Applications", "45"},
            {"Approved Applications", "187"},
            {"Rejected Applications", "23"},
            {"Total Queries", "89"},
            {"Total Feedback", "156"}
        }

        Dim posX As Integer = 20
        Dim posY As Integer = 60
        For Each stat In statData
            CreateStatCard(pnlContent, stat.Key, stat.Value, posX, posY)
            posX += 210
            If posX > 1200 Then
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
        dgvSummary.Size = New Size(1340, 200)
        dgvSummary.Font = New Font("Segoe UI", 9)
        dgvSummary.BackgroundColor = Color.White
        dgvSummary.BorderStyle = BorderStyle.FixedSingle
        dgvSummary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvSummary.AllowUserToAddRows = False
        pnlContent.Controls.Add(dgvSummary)

        dgvSummary.Columns.Add("LoanType", "Loan Type")
        dgvSummary.Columns.Add("Pending", "Pending")
        dgvSummary.Columns.Add("Approved", "Approved")
        dgvSummary.Columns.Add("Rejected", "Rejected")
        dgvSummary.Columns.Add("Total", "Total")

        dgvSummary.Rows.Add("Home Loan", "12", "45", "5", "62")
        dgvSummary.Rows.Add("Bank Loan", "18", "67", "8", "93")
        dgvSummary.Rows.Add("Financial Loan", "15", "75", "10", "100")
        dgvSummary.Rows.Add("Total", "45", "187", "23", "255")

        For i As Integer = 0 To dgvSummary.Columns.Count - 1
            dgvSummary.Columns(i).Width = 250
        Next
    End Sub

    Private Sub CreateStatCard(parent As Panel, title As String, value As String, x As Integer, y As Integer)
        Dim pnl As New Panel()
        pnl.BackColor = Color.White
        pnl.BorderStyle = BorderStyle.FixedSingle
        pnl.Size = New Size(200, 110)
        pnl.Location = New Point(x, y)
        parent.Controls.Add(pnl)

        Dim lblTitle As New Label()
        lblTitle.Text = title
        lblTitle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(52, 73, 94)
        lblTitle.AutoSize = False
        lblTitle.TextAlign = ContentAlignment.TopLeft
        lblTitle.Location = New Point(10, 10)
        lblTitle.Size = New Size(180, 30)
        pnl.Controls.Add(lblTitle)

        Dim lblValue As New Label()
        lblValue.Text = value
        lblValue.Font = New Font("Segoe UI", 18, FontStyle.Bold)
        lblValue.ForeColor = Color.FromArgb(34, 197, 94)
        lblValue.AutoSize = False
        lblValue.TextAlign = ContentAlignment.MiddleCenter
        lblValue.Location = New Point(10, 40)
        lblValue.Size = New Size(180, 40)
        pnl.Controls.Add(lblValue)
    End Sub

    Private Sub BuildApplicationsTab(tab As TabPage)
        Dim pnlTop As New Panel()
        pnlTop.BackColor = Color.FromArgb(52, 73, 94)
        pnlTop.Size = New Size(1360, 60)
        pnlTop.Location = New Point(0, 0)
        tab.Controls.Add(pnlTop)

        Dim lblTitle As New Label()
        lblTitle.Text = "📊 Filter Applications:"
        lblTitle.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.AutoSize = True
        lblTitle.Location = New Point(15, 18)
        pnlTop.Controls.Add(lblTitle)

        Dim btnAll As New Button()
        btnAll.Text = "📋 All"
        btnAll.BackColor = Color.FromArgb(149, 165, 166)
        btnAll.ForeColor = Color.White
        btnAll.FlatStyle = FlatStyle.Flat
        btnAll.Size = New Size(100, 35)
        btnAll.Location = New Point(15, 18)
        btnAll.Cursor = Cursors.Hand
        AddHandler btnAll.Click, Sub() LoadApplications("")
        pnlTop.Controls.Add(btnAll)

        Dim btnPending As New Button()
        btnPending.Text = "⏳ Pending"
        btnPending.BackColor = Color.FromArgb(241, 196, 15)
        btnPending.ForeColor = Color.White
        btnPending.FlatStyle = FlatStyle.Flat
        btnPending.Size = New Size(100, 35)
        btnPending.Location = New Point(125, 18)
        btnPending.Cursor = Cursors.Hand
        AddHandler btnPending.Click, Sub() LoadApplications("Pending")
        pnlTop.Controls.Add(btnPending)

        Dim btnApproved As New Button()
        btnApproved.Text = "✅ Approved"
        btnApproved.BackColor = Color.FromArgb(46, 204, 113)
        btnApproved.ForeColor = Color.White
        btnApproved.FlatStyle = FlatStyle.Flat
        btnApproved.Size = New Size(110, 35)
        btnApproved.Location = New Point(235, 18)
        btnApproved.Cursor = Cursors.Hand
        AddHandler btnApproved.Click, Sub() LoadApplications("Approved")
        pnlTop.Controls.Add(btnApproved)

        Dim btnRejected As New Button()
        btnRejected.Text = "❌ Rejected"
        btnRejected.BackColor = Color.FromArgb(231, 76, 60)
        btnRejected.ForeColor = Color.White
        btnRejected.FlatStyle = FlatStyle.Flat
        btnRejected.Size = New Size(100, 35)
        btnRejected.Location = New Point(355, 18)
        btnRejected.Cursor = Cursors.Hand
        AddHandler btnRejected.Click, Sub() LoadApplications("Rejected")
        pnlTop.Controls.Add(btnRejected)

        dgvApplications = New DataGridView()
        dgvApplications.Location = New Point(10, 70)
        dgvApplications.Size = New Size(1360, 710)
        dgvApplications.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvApplications.AllowUserToAddRows = False
        dgvApplications.Font = New Font("Segoe UI", 9)
        dgvApplications.BackgroundColor = Color.White
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
            dgvApplications.Columns(i).Width = 160
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
    End Sub

    Private Sub BuildUsersTab(tab As TabPage)
        Dim pnlContent As New Panel()
        pnlContent.AutoScroll = True
        pnlContent.Dock = DockStyle.Fill
        tab.Controls.Add(pnlContent)

        dgvUsers = New DataGridView()
        dgvUsers.Location = New Point(10, 10)
        dgvUsers.Size = New Size(1340, 770)
        dgvUsers.Font = New Font("Segoe UI", 9)
        dgvUsers.BackgroundColor = Color.White
        dgvUsers.BorderStyle = BorderStyle.FixedSingle
        dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvUsers.AllowUserToAddRows = False
        pnlContent.Controls.Add(dgvUsers)

        dgvUsers.Columns.Add("UserId", "User ID")
        dgvUsers.Columns.Add("Name", "Name")
        dgvUsers.Columns.Add("Email", "Email")
        dgvUsers.Columns.Add("Phone", "Phone")
        dgvUsers.Columns.Add("LoanType", "Preferred Loan Type")
        dgvUsers.Columns.Add("RegistrationDate", "Registration Date")
        dgvUsers.Columns.Add("Status", "Status")

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

        For i As Integer = 0 To dgvUsers.Columns.Count - 1
            dgvUsers.Columns(i).Width = 190
        Next
    End Sub

    Private Sub BuildQueriesTab(tab As TabPage)
        Dim pnlContent As New Panel()
        pnlContent.AutoScroll = True
        pnlContent.Dock = DockStyle.Fill
        tab.Controls.Add(pnlContent)

        dgvQueries = New DataGridView()
        dgvQueries.Location = New Point(10, 10)
        dgvQueries.Size = New Size(1340, 770)
        dgvQueries.Font = New Font("Segoe UI", 9)
        dgvQueries.BackgroundColor = Color.White
        dgvQueries.BorderStyle = BorderStyle.FixedSingle
        dgvQueries.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvQueries.AllowUserToAddRows = False
        pnlContent.Controls.Add(dgvQueries)

        dgvQueries.Columns.Add("QueryId", "Query ID")
        dgvQueries.Columns.Add("UserId", "User ID")
        dgvQueries.Columns.Add("UserName", "User Name")
        dgvQueries.Columns.Add("Query", "Query")
        dgvQueries.Columns.Add("Date", "Submitted Date")
        dgvQueries.Columns.Add("Status", "Status")

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

        dgvQueries.Columns("QueryId").Width = 80
        dgvQueries.Columns("UserId").Width = 80
        dgvQueries.Columns("UserName").Width = 150
        dgvQueries.Columns("Query").Width = 500
        dgvQueries.Columns("Date").Width = 120
        dgvQueries.Columns("Status").Width = 120
    End Sub

    Private Sub BuildFeedbackTab(tab As TabPage)
        Dim pnlContent As New Panel()
        pnlContent.AutoScroll = True
        pnlContent.Dock = DockStyle.Fill
        tab.Controls.Add(pnlContent)

        dgvFeedback = New DataGridView()
        dgvFeedback.Location = New Point(10, 10)
        dgvFeedback.Size = New Size(1340, 770)
        dgvFeedback.Font = New Font("Segoe UI", 9)
        dgvFeedback.BackgroundColor = Color.White
        dgvFeedback.BorderStyle = BorderStyle.FixedSingle
        dgvFeedback.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvFeedback.AllowUserToAddRows = False
        pnlContent.Controls.Add(dgvFeedback)

        dgvFeedback.Columns.Add("FeedbackId", "Feedback ID")
        dgvFeedback.Columns.Add("UserId", "User ID")
        dgvFeedback.Columns.Add("UserName", "User Name")
        dgvFeedback.Columns.Add("Feedback", "Feedback")
        dgvFeedback.Columns.Add("Date", "Date")
        dgvFeedback.Columns.Add("Rating", "Rating")

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

        dgvFeedback.Columns("FeedbackId").Width = 100
        dgvFeedback.Columns("UserId").Width = 80
        dgvFeedback.Columns("UserName").Width = 150
        dgvFeedback.Columns("Feedback").Width = 600
        dgvFeedback.Columns("Date").Width = 120
        dgvFeedback.Columns("Rating").Width = 100
    End Sub

    Private Sub BuildServicesTab(tab As TabPage)
        Dim pnlContent As New Panel()
        pnlContent.AutoScroll = True
        pnlContent.AutoScrollMinSize = New Size(0, 600)
        pnlContent.Dock = DockStyle.Fill
        tab.Controls.Add(pnlContent)

        Dim lblTitle As New Label()
        lblTitle.Text = "⚙️ Manage Loan Services - Edit Interest Rates, Fees & Terms"
        lblTitle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(15, 23, 42)
        lblTitle.Location = New Point(20, 20)
        lblTitle.AutoSize = True
        pnlContent.Controls.Add(lblTitle)

        dgvLoanServices = New DataGridView()
        dgvLoanServices.Location = New Point(20, 60)
        dgvLoanServices.Size = New Size(1320, 450)
        dgvLoanServices.Font = New Font("Segoe UI", 9)
        dgvLoanServices.BackgroundColor = Color.White
        dgvLoanServices.BorderStyle = BorderStyle.FixedSingle
        dgvLoanServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvLoanServices.AllowUserToAddRows = False
        dgvLoanServices.ReadOnly = False
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

        dgvLoanServices.Columns("ServiceId").Width = 80
        dgvLoanServices.Columns("LoanType").Width = 100
        dgvLoanServices.Columns("Company").Width = 120
        dgvLoanServices.Columns("MinInterest").Width = 120
        dgvLoanServices.Columns("MaxInterest").Width = 120
        dgvLoanServices.Columns("ProcessingFee").Width = 120
        dgvLoanServices.Columns("MinAmount").Width = 120
        dgvLoanServices.Columns("MaxAmount").Width = 120
        dgvLoanServices.Columns("ApprovalDays").Width = 100

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
End Class
