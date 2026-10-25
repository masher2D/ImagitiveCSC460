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
            listView1 = new ListView();
            reportID = new ColumnHeader();
            reason = new ColumnHeader();
            reportDate = new ColumnHeader();
            reportedUsername = new ColumnHeader();
            reporterUsername = new ColumnHeader();
            label1 = new Label();
            comboBox1 = new ComboBox();
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
            sortByComboBox.Location = new Point(527, 123);
            sortByComboBox.Name = "sortByComboBox";
            sortByComboBox.Size = new Size(242, 40);
            sortByComboBox.TabIndex = 12;
            // 
            // sortByLabel
            // 
            sortByLabel.AutoSize = true;
            sortByLabel.Font = new Font("Leelawadee UI", 11F);
            sortByLabel.Location = new Point(650, 79);
            sortByLabel.Name = "sortByLabel";
            sortByLabel.Size = new Size(119, 41);
            sortByLabel.TabIndex = 13;
            sortByLabel.Text = "Sort By:";
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { reportID, reason, reportDate, reportedUsername, reporterUsername });
            listView1.Location = new Point(16, 169);
            listView1.Name = "listView1";
            listView1.Size = new Size(753, 706);
            listView1.TabIndex = 14;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // reportID
            // 
            reportID.Text = "ReportID";
            reportID.Width = 120;
            // 
            // reason
            // 
            reason.Text = "Reason";
            reason.Width = 150;
            // 
            // reportDate
            // 
            reportDate.Text = "Report Date";
            reportDate.Width = 150;
            // 
            // reportedUsername
            // 
            reportedUsername.Text = "Reported User";
            reportedUsername.Width = 150;
            // 
            // reporterUsername
            // 
            reporterUsername.Text = "Reporter";
            reporterUsername.Width = 130;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Leelawadee UI", 11F);
            label1.Location = new Point(380, 79);
            label1.Name = "label1";
            label1.Size = new Size(130, 41);
            label1.TabIndex = 16;
            label1.Text = "Filter By:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Resolved", "Unresolved" });
            comboBox1.Location = new Point(268, 123);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(242, 40);
            comboBox1.TabIndex = 15;
            // 
            // AdminDashboardInstance
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(listView1);
            Controls.Add(sortByLabel);
            Controls.Add(sortByComboBox);
            Controls.Add(headerLabel);
            MaximumSize = new Size(780, 899);
            Name = "AdminDashboardInstance";
            Size = new Size(780, 899);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label headerLabel;
        private ComboBox sortByComboBox;
        private Label sortByLabel;
        private ListView listView1;
        private ColumnHeader reportID;
        private ColumnHeader reportedUsername;
        private ColumnHeader reporterUsername;
        private ColumnHeader reason;
        private ColumnHeader reportDate;
        private Label label1;
        private ComboBox comboBox1;
    }
}
