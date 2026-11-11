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
            sortByComboBox = new ComboBox();
            sortByLabel = new Label();
            reportsListView = new ListView();
            requestID = new ColumnHeader();
            reportDate = new ColumnHeader();
            consideredUser = new ColumnHeader();
            suggesterUsername = new ColumnHeader();
            label1 = new Label();
            comboBox1 = new ComboBox();
            adminManagementTab = new TabControl();
            reportsPage = new TabPage();
            adminPromotePage = new TabPage();
            label2 = new Label();
            label3 = new Label();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            listView2 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            artworkManagerGetPrevPageBtn = new Button();
            artworkManagerGetNextPageBtn = new Button();
            artworkManagerReloadBtn = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            adminManagementTab.SuspendLayout();
            reportsPage.SuspendLayout();
            adminPromotePage.SuspendLayout();
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
            // sortByComboBox
            // 
            sortByComboBox.FormattingEnabled = true;
            sortByComboBox.Items.AddRange(new object[] { "Newest to Oldest", "Oldest to Newest", "Reason (A-Z)", "Reason (Z-A)" });
            sortByComboBox.Location = new Point(254, 52);
            sortByComboBox.Name = "sortByComboBox";
            sortByComboBox.Size = new Size(242, 40);
            sortByComboBox.TabIndex = 12;
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
            // reportsListView
            // 
            reportsListView.Columns.AddRange(new ColumnHeader[] { requestID, reportDate, consideredUser, suggesterUsername });
            reportsListView.Location = new Point(0, 98);
            reportsListView.Name = "reportsListView";
            reportsListView.Size = new Size(737, 644);
            reportsListView.TabIndex = 14;
            reportsListView.UseCompatibleStateImageBehavior = false;
            reportsListView.View = View.Details;
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
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Resolved", "Unresolved" });
            comboBox1.Location = new Point(6, 52);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(242, 40);
            comboBox1.TabIndex = 15;
            // 
            // adminManagementTab
            // 
            adminManagementTab.Controls.Add(reportsPage);
            adminManagementTab.Controls.Add(adminPromotePage);
            adminManagementTab.Location = new Point(16, 79);
            adminManagementTab.Name = "adminManagementTab";
            adminManagementTab.SelectedIndex = 0;
            adminManagementTab.Size = new Size(753, 796);
            adminManagementTab.TabIndex = 17;
            // 
            // reportsPage
            // 
            reportsPage.Controls.Add(artworkManagerGetPrevPageBtn);
            reportsPage.Controls.Add(artworkManagerGetNextPageBtn);
            reportsPage.Controls.Add(artworkManagerReloadBtn);
            reportsPage.Controls.Add(sortByLabel);
            reportsPage.Controls.Add(label1);
            reportsPage.Controls.Add(reportsListView);
            reportsPage.Controls.Add(comboBox1);
            reportsPage.Controls.Add(sortByComboBox);
            reportsPage.Location = new Point(8, 46);
            reportsPage.Name = "reportsPage";
            reportsPage.Padding = new Padding(3);
            reportsPage.Size = new Size(737, 742);
            reportsPage.TabIndex = 0;
            reportsPage.Text = "Reports";
            reportsPage.UseVisualStyleBackColor = true;
            // 
            // adminPromotePage
            // 
            adminPromotePage.Controls.Add(button1);
            adminPromotePage.Controls.Add(button2);
            adminPromotePage.Controls.Add(button3);
            adminPromotePage.Controls.Add(listView2);
            adminPromotePage.Controls.Add(label2);
            adminPromotePage.Controls.Add(label3);
            adminPromotePage.Controls.Add(comboBox2);
            adminPromotePage.Controls.Add(comboBox3);
            adminPromotePage.Location = new Point(8, 46);
            adminPromotePage.Name = "adminPromotePage";
            adminPromotePage.Padding = new Padding(3);
            adminPromotePage.Size = new Size(737, 742);
            adminPromotePage.TabIndex = 1;
            adminPromotePage.Text = "Admin Promotion Requests";
            adminPromotePage.UseVisualStyleBackColor = true;
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
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Resolved", "Unresolved" });
            comboBox2.Location = new Point(6, 52);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(242, 40);
            comboBox2.TabIndex = 19;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "Newest to Oldest", "Oldest to Newest", "Reason (A-Z)", "Reason (Z-A)" });
            comboBox3.Location = new Point(254, 52);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(242, 40);
            comboBox3.TabIndex = 17;
            // 
            // listView2
            // 
            listView2.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5 });
            listView2.Location = new Point(0, 98);
            listView2.Name = "listView2";
            listView2.Size = new Size(737, 644);
            listView2.TabIndex = 21;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "ReportID";
            columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Reason";
            columnHeader2.Width = 150;
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
            columnHeader5.Text = "Reporter";
            columnHeader5.Width = 130;
            // 
            // artworkManagerGetPrevPageBtn
            // 
            artworkManagerGetPrevPageBtn.Font = new Font("Leelawadee UI", 9F);
            artworkManagerGetPrevPageBtn.Location = new Point(3, 641);
            artworkManagerGetPrevPageBtn.Name = "artworkManagerGetPrevPageBtn";
            artworkManagerGetPrevPageBtn.Size = new Size(181, 46);
            artworkManagerGetPrevPageBtn.TabIndex = 19;
            artworkManagerGetPrevPageBtn.Text = "Get Prev Page";
            artworkManagerGetPrevPageBtn.UseVisualStyleBackColor = true;
            // 
            // artworkManagerGetNextPageBtn
            // 
            artworkManagerGetNextPageBtn.Font = new Font("Leelawadee UI", 9F);
            artworkManagerGetNextPageBtn.Location = new Point(3, 693);
            artworkManagerGetNextPageBtn.Name = "artworkManagerGetNextPageBtn";
            artworkManagerGetNextPageBtn.Size = new Size(181, 46);
            artworkManagerGetNextPageBtn.TabIndex = 18;
            artworkManagerGetNextPageBtn.Text = "Get Next Page";
            artworkManagerGetNextPageBtn.UseVisualStyleBackColor = true;
            // 
            // artworkManagerReloadBtn
            // 
            artworkManagerReloadBtn.Font = new Font("Leelawadee UI", 9F);
            artworkManagerReloadBtn.Location = new Point(581, 693);
            artworkManagerReloadBtn.Name = "artworkManagerReloadBtn";
            artworkManagerReloadBtn.Size = new Size(150, 46);
            artworkManagerReloadBtn.TabIndex = 17;
            artworkManagerReloadBtn.Text = "Reload";
            artworkManagerReloadBtn.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Font = new Font("Leelawadee UI", 9F);
            button1.Location = new Point(3, 641);
            button1.Name = "button1";
            button1.Size = new Size(181, 46);
            button1.TabIndex = 24;
            button1.Text = "Get Prev Page";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Leelawadee UI", 9F);
            button2.Location = new Point(3, 693);
            button2.Name = "button2";
            button2.Size = new Size(181, 46);
            button2.TabIndex = 23;
            button2.Text = "Get Next Page";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Font = new Font("Leelawadee UI", 9F);
            button3.Location = new Point(581, 693);
            button3.Name = "button3";
            button3.Size = new Size(150, 46);
            button3.TabIndex = 22;
            button3.Text = "Reload";
            button3.UseVisualStyleBackColor = true;
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
            adminManagementTab.ResumeLayout(false);
            reportsPage.ResumeLayout(false);
            reportsPage.PerformLayout();
            adminPromotePage.ResumeLayout(false);
            adminPromotePage.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label headerLabel;
        private ComboBox sortByComboBox;
        private Label sortByLabel;
        private ListView reportsListView;
        private ColumnHeader requestID;
        private ColumnHeader consideredUser;
        private ColumnHeader suggesterUsername;
        private ColumnHeader reportDate;
        private Label label1;
        private ComboBox comboBox1;
        private TabControl adminManagementTab;
        private TabPage reportsPage;
        private TabPage adminPromotePage;
        private ListView listView2;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private Label label2;
        private Label label3;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private Button artworkManagerGetPrevPageBtn;
        private Button artworkManagerGetNextPageBtn;
        private Button artworkManagerReloadBtn;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}
