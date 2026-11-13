namespace ImagitiveCSC460UI.Forms.Components
{
    partial class AdminDashboardInstance
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            headerLabel = new Label();
            sortBox2 = new ComboBox();
            sortByLabel = new Label();
            requestsListView = new ListView();
            requestID = new ColumnHeader();
            reportDate = new ColumnHeader();
            consideredUser = new ColumnHeader();
            suggesterUsername = new ColumnHeader();
            label1 = new Label();
            filterBox2 = new ComboBox();
            adminManagementTab = new TabControl();
            reportsPage = new TabPage();
            clearFiltersBtn1 = new Button();
            reportsPrevBtn = new Button();
            reportsNextBtn = new Button();
            reportsReloadBtn = new Button();
            reportsListView = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            label2 = new Label();
            label3 = new Label();
            filterBox1 = new ComboBox();
            sortBox1 = new ComboBox();
            adminRequestsPage = new TabPage();
            addRequestBtn = new Button();
            clearFiltersBtn2 = new Button();
            artworkManagerGetPrevPageBtn = new Button();
            artworkManagerGetNextPageBtn = new Button();
            requestsReloadBtn = new Button();
            adminManagementTab.SuspendLayout();
            reportsPage.SuspendLayout();
            adminRequestsPage.SuspendLayout();
            SuspendLayout();
            // 
            // headerLabel
            // 
            headerLabel.Font = new Font("Leelawadee UI", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            headerLabel.Location = new Point(336, 13);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(433, 62);
            headerLabel.TabIndex = 11;
            headerLabel.Text = "Admin Dashboard";
            headerLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // sortBox2
            // 
            sortBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            sortBox2.FormattingEnabled = true;
            sortBox2.Items.AddRange(new object[] { "Newest to Oldest", "Oldest to Newest" });
            sortBox2.Location = new Point(254, 52);
            sortBox2.Name = "sortBox2";
            sortBox2.Size = new Size(242, 40);
            sortBox2.TabIndex = 12;
            sortBox2.SelectedIndexChanged += sortBox2_SelectedIndexChanged;
            // 
            // sortByLabel
            // 
            sortByLabel.AutoSize = true;
            sortByLabel.Font = new Font("Leelawadee UI", 11F);
            sortByLabel.Location = new Point(254, 8);
            sortByLabel.Name = "sortByLabel";
            sortByLabel.Size = new Size(119, 41);
            sortByLabel.TabIndex = 13;
            sortByLabel.Text = "Sort By:";
            // 
            // requestsListView
            // 
            requestsListView.Columns.AddRange(new ColumnHeader[] { requestID, reportDate, consideredUser, suggesterUsername });
            requestsListView.Location = new Point(0, 98);
            requestsListView.Name = "requestsListView";
            requestsListView.Size = new Size(737, 592);
            requestsListView.TabIndex = 14;
            requestsListView.UseCompatibleStateImageBehavior = false;
            requestsListView.View = View.Details;
            requestsListView.SelectedIndexChanged += reportsListView_SelectedIndexChanged;
            // 
            // requestID
            // 
            requestID.Text = "RequestID";
            requestID.Width = 120;
            // 
            // reportDate
            // 
            reportDate.Text = "Report Date";
            reportDate.Width = 150;
            // 
            // consideredUser
            // 
            consideredUser.Text = "User To be Considered";
            consideredUser.Width = 250;
            // 
            // suggesterUsername
            // 
            suggesterUsername.Text = "Suggester";
            suggesterUsername.Width = 130;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Leelawadee UI", 11F);
            label1.Location = new Point(6, 8);
            label1.Name = "label1";
            label1.Size = new Size(130, 41);
            label1.TabIndex = 16;
            label1.Text = "Filter By:";
            // 
            // filterBox2
            // 
            filterBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            filterBox2.FormattingEnabled = true;
            filterBox2.Items.AddRange(new object[] { "Date: Last 7 Days", "Date: Last Month" });
            filterBox2.Location = new Point(6, 52);
            filterBox2.Name = "filterBox2";
            filterBox2.Size = new Size(242, 40);
            filterBox2.TabIndex = 15;
            filterBox2.SelectedIndexChanged += filterBox2_SelectedIndexChanged;
            // 
            // adminManagementTab
            // 
            adminManagementTab.Controls.Add(reportsPage);
            adminManagementTab.Controls.Add(adminRequestsPage);
            adminManagementTab.Location = new Point(16, 79);
            adminManagementTab.Name = "adminManagementTab";
            adminManagementTab.SelectedIndex = 0;
            adminManagementTab.Size = new Size(753, 796);
            adminManagementTab.TabIndex = 17;
            // 
            // reportsPage
            // 
            reportsPage.Controls.Add(clearFiltersBtn1);
            reportsPage.Controls.Add(reportsPrevBtn);
            reportsPage.Controls.Add(reportsNextBtn);
            reportsPage.Controls.Add(reportsReloadBtn);
            reportsPage.Controls.Add(reportsListView);
            reportsPage.Controls.Add(label2);
            reportsPage.Controls.Add(label3);
            reportsPage.Controls.Add(filterBox1);
            reportsPage.Controls.Add(sortBox1);
            reportsPage.Location = new Point(8, 46);
            reportsPage.Name = "reportsPage";
            reportsPage.Padding = new Padding(3);
            reportsPage.Size = new Size(737, 742);
            reportsPage.TabIndex = 1;
            reportsPage.Text = "Reports";
            reportsPage.UseVisualStyleBackColor = true;
            // 
            // clearFiltersBtn1
            // 
            clearFiltersBtn1.Font = new Font("Leelawadee UI", 8.5F);
            clearFiltersBtn1.Location = new Point(536, 51);
            clearFiltersBtn1.Name = "clearFiltersBtn1";
            clearFiltersBtn1.Size = new Size(181, 40);
            clearFiltersBtn1.TabIndex = 25;
            clearFiltersBtn1.Text = "Clear Filters";
            clearFiltersBtn1.UseVisualStyleBackColor = true;
            clearFiltersBtn1.Click += clearFiltersBtn1_Click;
            // 
            // reportsPrevBtn
            // 
            reportsPrevBtn.Font = new Font("Leelawadee UI", 9F);
            reportsPrevBtn.Location = new Point(6, 696);
            reportsPrevBtn.Name = "reportsPrevBtn";
            reportsPrevBtn.Size = new Size(181, 46);
            reportsPrevBtn.TabIndex = 24;
            reportsPrevBtn.Text = "Get Prev Page";
            reportsPrevBtn.UseVisualStyleBackColor = true;
            // 
            // reportsNextBtn
            // 
            reportsNextBtn.Font = new Font("Leelawadee UI", 9F);
            reportsNextBtn.Location = new Point(553, 696);
            reportsNextBtn.Name = "reportsNextBtn";
            reportsNextBtn.Size = new Size(181, 46);
            reportsNextBtn.TabIndex = 23;
            reportsNextBtn.Text = "Get Next Page";
            reportsNextBtn.UseVisualStyleBackColor = true;
            // 
            // reportsReloadBtn
            // 
            reportsReloadBtn.Font = new Font("Leelawadee UI", 9F);
            reportsReloadBtn.Location = new Point(295, 696);
            reportsReloadBtn.Name = "reportsReloadBtn";
            reportsReloadBtn.Size = new Size(150, 46);
            reportsReloadBtn.TabIndex = 22;
            reportsReloadBtn.Text = "Reload";
            reportsReloadBtn.UseVisualStyleBackColor = true;
            reportsReloadBtn.Click += reportsReloadBtn_Click;
            // 
            // reportsListView
            // 
            reportsListView.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6 });
            reportsListView.Location = new Point(0, 98);
            reportsListView.Name = "reportsListView";
            reportsListView.Size = new Size(737, 589);
            reportsListView.TabIndex = 21;
            reportsListView.UseCompatibleStateImageBehavior = false;
            reportsListView.View = View.Details;
            reportsListView.SelectedIndexChanged += reportsListView_SelectedIndexChanged_1;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "ReportID";
            columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Reason";
            columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Report Date";
            columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Reported User";
            columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Artwork";
            columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Status";
            columnHeader6.Width = 90;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Leelawadee UI", 11F);
            label2.Location = new Point(254, 8);
            label2.Name = "label2";
            label2.Size = new Size(119, 41);
            label2.TabIndex = 18;
            label2.Text = "Sort By:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Leelawadee UI", 11F);
            label3.Location = new Point(6, 8);
            label3.Name = "label3";
            label3.Size = new Size(130, 41);
            label3.TabIndex = 20;
            label3.Text = "Filter By:";
            // 
            // filterBox1
            // 
            filterBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            filterBox1.FormattingEnabled = true;
            filterBox1.Items.AddRange(new object[] { "Status: Resolved", "Status: Unresolved", "Date: Last 7 Days", "Date: Last Month" });
            filterBox1.Location = new Point(6, 52);
            filterBox1.Name = "filterBox1";
            filterBox1.Size = new Size(242, 40);
            filterBox1.TabIndex = 19;
            filterBox1.SelectedIndexChanged += filterBox1_SelectedIndexChanged;
            // 
            // sortBox1
            // 
            sortBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            sortBox1.FormattingEnabled = true;
            sortBox1.Items.AddRange(new object[] { "Newest to Oldest", "Oldest to Newest", "Reason (A-Z)", "Reason (Z-A)" });
            sortBox1.Location = new Point(254, 52);
            sortBox1.Name = "sortBox1";
            sortBox1.Size = new Size(242, 40);
            sortBox1.TabIndex = 17;
            sortBox1.SelectedIndexChanged += sortBox1_SelectedIndexChanged;
            // 
            // adminRequestsPage
            // 
            adminRequestsPage.Controls.Add(addRequestBtn);
            adminRequestsPage.Controls.Add(clearFiltersBtn2);
            adminRequestsPage.Controls.Add(artworkManagerGetPrevPageBtn);
            adminRequestsPage.Controls.Add(artworkManagerGetNextPageBtn);
            adminRequestsPage.Controls.Add(requestsReloadBtn);
            adminRequestsPage.Controls.Add(sortByLabel);
            adminRequestsPage.Controls.Add(label1);
            adminRequestsPage.Controls.Add(requestsListView);
            adminRequestsPage.Controls.Add(filterBox2);
            adminRequestsPage.Controls.Add(sortBox2);
            adminRequestsPage.Location = new Point(8, 46);
            adminRequestsPage.Name = "adminRequestsPage";
            adminRequestsPage.Padding = new Padding(3);
            adminRequestsPage.Size = new Size(737, 742);
            adminRequestsPage.TabIndex = 0;
            adminRequestsPage.Text = "Admin Promotion Requests";
            adminRequestsPage.UseVisualStyleBackColor = true;
            // 
            // addRequestBtn
            // 
            addRequestBtn.Font = new Font("Leelawadee UI", 8.5F);
            addRequestBtn.Location = new Point(550, 10);
            addRequestBtn.Name = "addRequestBtn";
            addRequestBtn.Size = new Size(181, 40);
            addRequestBtn.TabIndex = 27;
            addRequestBtn.Text = "Add Request";
            addRequestBtn.UseVisualStyleBackColor = true;
            addRequestBtn.Click += addRequestBtn_Click;
            // 
            // clearFiltersBtn2
            // 
            clearFiltersBtn2.Font = new Font("Leelawadee UI", 8.5F);
            clearFiltersBtn2.Location = new Point(550, 52);
            clearFiltersBtn2.Name = "clearFiltersBtn2";
            clearFiltersBtn2.Size = new Size(181, 40);
            clearFiltersBtn2.TabIndex = 26;
            clearFiltersBtn2.Text = "Clear Filters";
            clearFiltersBtn2.UseVisualStyleBackColor = true;
            clearFiltersBtn2.Click += clearFiltersBtn2_Click;
            // 
            // artworkManagerGetPrevPageBtn
            // 
            artworkManagerGetPrevPageBtn.Font = new Font("Leelawadee UI", 9F);
            artworkManagerGetPrevPageBtn.Location = new Point(6, 696);
            artworkManagerGetPrevPageBtn.Name = "artworkManagerGetPrevPageBtn";
            artworkManagerGetPrevPageBtn.Size = new Size(181, 46);
            artworkManagerGetPrevPageBtn.TabIndex = 19;
            artworkManagerGetPrevPageBtn.Text = "Get Prev Page";
            artworkManagerGetPrevPageBtn.UseVisualStyleBackColor = true;
            // 
            // artworkManagerGetNextPageBtn
            // 
            artworkManagerGetNextPageBtn.Font = new Font("Leelawadee UI", 9F);
            artworkManagerGetNextPageBtn.Location = new Point(553, 696);
            artworkManagerGetNextPageBtn.Name = "artworkManagerGetNextPageBtn";
            artworkManagerGetNextPageBtn.Size = new Size(181, 46);
            artworkManagerGetNextPageBtn.TabIndex = 18;
            artworkManagerGetNextPageBtn.Text = "Get Next Page";
            artworkManagerGetNextPageBtn.UseVisualStyleBackColor = true;
            // 
            // requestsReloadBtn
            // 
            requestsReloadBtn.Font = new Font("Leelawadee UI", 9F);
            requestsReloadBtn.Location = new Point(295, 696);
            requestsReloadBtn.Name = "requestsReloadBtn";
            requestsReloadBtn.Size = new Size(150, 46);
            requestsReloadBtn.TabIndex = 17;
            requestsReloadBtn.Text = "Reload";
            requestsReloadBtn.UseVisualStyleBackColor = true;
            // 
            // AdminDashboardInstance
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            Controls.Add(headerLabel);
            Controls.Add(adminManagementTab);
            MaximumSize = new Size(780, 899);
            Name = "AdminDashboardInstance";
            Size = new Size(780, 899);
            Load += AdminDashboardInstance_Load;
            adminManagementTab.ResumeLayout(false);
            reportsPage.ResumeLayout(false);
            reportsPage.PerformLayout();
            adminRequestsPage.ResumeLayout(false);
            adminRequestsPage.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label headerLabel;
        private ComboBox sortBox2;
        private Label sortByLabel;
        private ListView requestsListView;
        private ColumnHeader requestID;
        private ColumnHeader consideredUser;
        private ColumnHeader suggesterUsername;
        private ColumnHeader reportDate;
        private Label label1;
        private ComboBox filterBox2;
        private TabControl adminManagementTab;
        private TabPage adminRequestsPage;
        private TabPage reportsPage;
        private ListView reportsListView;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private Label label2;
        private Label label3;
        private ComboBox filterBox1;
        private ComboBox sortBox1;
        private Button artworkManagerGetPrevPageBtn;
        private Button artworkManagerGetNextPageBtn;
        private Button requestsReloadBtn;
        private Button reportsPrevBtn;
        private Button reportsNextBtn;
        private Button reportsReloadBtn;
        private ColumnHeader columnHeader6;
        private Button clearFiltersBtn1;
        private Button clearFiltersBtn2;
        private Button addRequestBtn;
    }
}
