Public Class FormWishlist
    Inherits Form

    Private dgvWishlist As DataGridView
    Private lblEmpty As Label

    Public Sub New()
        MyBase.New()
        Me.Text = "CredShield - My Wishlist"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(1000, 600)
        Me.BackColor = Color.FromArgb(245, 245, 245)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False

        BuildUI()
        LoadWishlist()
    End Sub

    Private Sub BuildUI()
        ' Header
        Dim pnlHeader As New Panel()
        pnlHeader.BackColor = Color.FromArgb(168, 85, 247)
        pnlHeader.Size = New Size(1000, 70)
        pnlHeader.Location = New Point(0, 0)
        Me.Controls.Add(pnlHeader)

        Dim lblTitle As New Label()
        lblTitle.Text = "❤️ My Wishlist"
        lblTitle.Font = New Font("Segoe UI", 18, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.AutoSize = False
        lblTitle.TextAlign = ContentAlignment.MiddleCenter
        lblTitle.Location = New Point(0, 15)
        lblTitle.Size = New Size(1000, 40)
        pnlHeader.Controls.Add(lblTitle)

        ' Clear Wishlist Button
        Dim btnClear As New Button()
        btnClear.Text = "🗑️ Clear All"
        btnClear.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnClear.BackColor = Color.FromArgb(220, 20, 60)
        btnClear.ForeColor = Color.White
        btnClear.FlatStyle = FlatStyle.Flat
        btnClear.FlatAppearance.BorderSize = 0
        btnClear.Size = New Size(100, 35)
        btnClear.Location = New Point(880, 18)
        btnClear.Cursor = Cursors.Hand
        AddHandler btnClear.Click, AddressOf ClearWishlist
        pnlHeader.Controls.Add(btnClear)

        ' DataGridView
        dgvWishlist = New DataGridView()
        dgvWishlist.Location = New Point(20, 90)
        dgvWishlist.Size = New Size(960, 410)
        dgvWishlist.Font = New Font("Segoe UI", 10)
        dgvWishlist.BackgroundColor = Color.White
        dgvWishlist.BorderStyle = BorderStyle.FixedSingle
        dgvWishlist.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvWishlist.RowHeadersVisible = False
        dgvWishlist.AllowUserToAddRows = False
        dgvWishlist.MultiSelect = False
        dgvWishlist.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.Controls.Add(dgvWishlist)

        ' Empty Message Label
        lblEmpty = New Label()
        lblEmpty.Text = "Your wishlist is empty. Add loans from the comparison page!"
        lblEmpty.Font = New Font("Segoe UI", 12)
        lblEmpty.ForeColor = Color.FromArgb(100, 116, 139)
        lblEmpty.AutoSize = False
        lblEmpty.TextAlign = ContentAlignment.MiddleCenter
        lblEmpty.Location = New Point(100, 250)
        lblEmpty.Size = New Size(800, 50)
        lblEmpty.Visible = False
        Me.Controls.Add(lblEmpty)

        ' Footer with action buttons
        Dim pnlFooter As New Panel()
        pnlFooter.BackColor = Color.FromArgb(245, 245, 245)
        pnlFooter.Size = New Size(1000, 60)
        pnlFooter.Location = New Point(0, 510)
        Me.Controls.Add(pnlFooter)

        Dim btnRemoveSelected As New Button()
        btnRemoveSelected.Text = "❌ Remove Selected"
        btnRemoveSelected.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnRemoveSelected.BackColor = Color.FromArgb(220, 20, 60)
        btnRemoveSelected.ForeColor = Color.White
        btnRemoveSelected.FlatStyle = FlatStyle.Flat
        btnRemoveSelected.FlatAppearance.BorderSize = 0
        btnRemoveSelected.Size = New Size(150, 35)
        btnRemoveSelected.Location = New Point(20, 12)
        btnRemoveSelected.Cursor = Cursors.Hand
        AddHandler btnRemoveSelected.Click, AddressOf RemoveSelected
        pnlFooter.Controls.Add(btnRemoveSelected)

        Dim btnApplySelected As New Button()
        btnApplySelected.Text = "📝 Apply Now"
        btnApplySelected.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnApplySelected.BackColor = Color.FromArgb(34, 197, 94)
        btnApplySelected.ForeColor = Color.White
        btnApplySelected.FlatStyle = FlatStyle.Flat
        btnApplySelected.FlatAppearance.BorderSize = 0
        btnApplySelected.Size = New Size(150, 35)
        btnApplySelected.Location = New Point(180, 12)
        btnApplySelected.Cursor = Cursors.Hand
        AddHandler btnApplySelected.Click, AddressOf ApplyFromWishlist
        pnlFooter.Controls.Add(btnApplySelected)

        Dim btnClose As New Button()
        btnClose.Text = "✖️ Close"
        btnClose.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnClose.BackColor = Color.FromArgb(100, 116, 139)
        btnClose.ForeColor = Color.White
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.FlatAppearance.BorderSize = 0
        btnClose.Size = New Size(100, 35)
        btnClose.Location = New Point(880, 12)
        btnClose.Cursor = Cursors.Hand
        AddHandler btnClose.Click, Sub() Me.Close()
        pnlFooter.Controls.Add(btnClose)
    End Sub

    Private Sub LoadWishlist()
        dgvWishlist.DataSource = Nothing
        dgvWishlist.Columns.Clear()

        If WishlistManager.WishlistItems.Count = 0 Then
            lblEmpty.Visible = True
            dgvWishlist.Visible = False
            Return
        End If

        lblEmpty.Visible = False
        dgvWishlist.Visible = True

        ' Create columns
        dgvWishlist.Columns.Add("CompanyName", "Company")
        dgvWishlist.Columns.Add("LoanType", "Loan Type")
        dgvWishlist.Columns.Add("InterestRate", "Interest Rate")
        dgvWishlist.Columns.Add("AmountRange", "Loan Amount Range")
        dgvWishlist.Columns.Add("Rating", "Rating")
        dgvWishlist.Columns.Add("AddedDate", "Added Date")

        ' Add data
        For Each item In WishlistManager.WishlistItems
            dgvWishlist.Rows.Add(
                item.CompanyName,
                item.LoanType,
                item.InterestRateMin & "% - " & item.InterestRateMax & "%",
                "₹" & Format(item.MinAmount, "0,0") & " - ₹" & Format(item.MaxAmount, "0,0"),
                "⭐ " & item.Rating,
                item.AddedDate.ToString("dd/MM/yyyy")
            )
        Next

        ' Adjust column widths
        dgvWishlist.Columns(0).Width = 150
        dgvWishlist.Columns(1).Width = 120
        dgvWishlist.Columns(2).Width = 150
        dgvWishlist.Columns(3).Width = 250
        dgvWishlist.Columns(4).Width = 100
        dgvWishlist.Columns(5).Width = 120
    End Sub

    Private Sub RemoveSelected(sender As Object, e As EventArgs)
        If dgvWishlist.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a loan to remove!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim selectedIndex As Integer = dgvWishlist.SelectedRows(0).Index
        Dim offerId As String = WishlistManager.WishlistItems(selectedIndex).LoanOfferId

        Dim result As DialogResult = MessageBox.Show("Remove this loan from your wishlist?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            WishlistManager.RemoveFromWishlist(offerId)
            LoadWishlist()
            MessageBox.Show("Loan removed from wishlist!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ClearWishlist(sender As Object, e As EventArgs)
        If WishlistManager.WishlistItems.Count = 0 Then
            MessageBox.Show("Your wishlist is already empty!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim result As DialogResult = MessageBox.Show("Clear all loans from your wishlist? This cannot be undone.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            WishlistManager.WishlistItems.Clear()
            LoadWishlist()
            MessageBox.Show("Wishlist cleared!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ApplyFromWishlist(sender As Object, e As EventArgs)
        If dgvWishlist.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a loan to apply for!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim selectedIndex As Integer = dgvWishlist.SelectedRows(0).Index
        Dim item = WishlistManager.WishlistItems(selectedIndex)

        MessageBox.Show("Feature to apply from wishlist will be implemented. You can apply from the Loan Comparison page." & vbCrLf & vbCrLf & 
                       "Company: " & item.CompanyName & vbCrLf &
                       "Loan Type: " & item.LoanType,
                       "Apply Now", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class
