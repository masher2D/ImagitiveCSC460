namespace ImagitiveCSC460UI.Forms.Components
{
    partial class ArtistDashboardInstance
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
            tabControl1 = new TabControl();
            artworkManagementPage = new TabPage();
            artworkManagerGetPrevPageBtn = new Button();
            artworkManagerGetNextPageBtn = new Button();
            artworkManagerReloadBtn = new Button();
            deleteSelectedArtworkBtn = new Button();
            postNewArtworkBtn = new Button();
            listView1 = new ListView();
            lvArtworkTitle = new ColumnHeader();
            lvTags = new ColumnHeader();
            lvartworkCreationDate = new ColumnHeader();
            statisticsPage = new TabPage();
            statsPrevButton = new Button();
            statNextButton = new Button();
            statsReloadBtn = new Button();
            accountAvgRatingValueLabel = new Label();
            totalViewsValueLabel = new Label();
            avgRatingValueLabel = new Label();
            dailyViewsValueLabel = new Label();
            accountAvgRatingLabel = new Label();
            avgRatingLabel = new Label();
            totalViewsLabel = new Label();
            dailyViewsLabel = new Label();
            statsView = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            headerLabel = new Label();
            tabControl1.SuspendLayout();
            artworkManagementPage.SuspendLayout();
            statisticsPage.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(artworkManagementPage);
            tabControl1.Controls.Add(statisticsPage);
            tabControl1.Font = new Font("Leelawadee UI", 9F);
            tabControl1.Location = new Point(3, 91);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(774, 805);
            tabControl1.TabIndex = 0;
            // 
            // artworkManagementPage
            // 
            artworkManagementPage.Controls.Add(artworkManagerGetPrevPageBtn);
            artworkManagementPage.Controls.Add(artworkManagerGetNextPageBtn);
            artworkManagementPage.Controls.Add(artworkManagerReloadBtn);
            artworkManagementPage.Controls.Add(deleteSelectedArtworkBtn);
            artworkManagementPage.Controls.Add(postNewArtworkBtn);
            artworkManagementPage.Controls.Add(listView1);
            artworkManagementPage.Font = new Font("Leelawadee UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            artworkManagementPage.Location = new Point(8, 46);
            artworkManagementPage.Name = "artworkManagementPage";
            artworkManagementPage.Padding = new Padding(3);
            artworkManagementPage.Size = new Size(758, 751);
            artworkManagementPage.TabIndex = 1;
            artworkManagementPage.Text = "Artwork Manager";
            artworkManagementPage.UseVisualStyleBackColor = true;
            // 
            // artworkManagerGetPrevPageBtn
            // 
            artworkManagerGetPrevPageBtn.Font = new Font("Leelawadee UI", 9F);
            artworkManagerGetPrevPageBtn.Location = new Point(15, 636);
            artworkManagerGetPrevPageBtn.Name = "artworkManagerGetPrevPageBtn";
            artworkManagerGetPrevPageBtn.Size = new Size(181, 46);
            artworkManagerGetPrevPageBtn.TabIndex = 14;
            artworkManagerGetPrevPageBtn.Text = "Get Prev Page";
            artworkManagerGetPrevPageBtn.UseVisualStyleBackColor = true;
            artworkManagerGetPrevPageBtn.Click += artworkManagerGetPrevPageBtn_Click;
            // 
            // artworkManagerGetNextPageBtn
            // 
            artworkManagerGetNextPageBtn.Font = new Font("Leelawadee UI", 9F);
            artworkManagerGetNextPageBtn.Location = new Point(15, 688);
            artworkManagerGetNextPageBtn.Name = "artworkManagerGetNextPageBtn";
            artworkManagerGetNextPageBtn.Size = new Size(181, 46);
            artworkManagerGetNextPageBtn.TabIndex = 13;
            artworkManagerGetNextPageBtn.Text = "Get Next Page";
            artworkManagerGetNextPageBtn.UseVisualStyleBackColor = true;
            artworkManagerGetNextPageBtn.Click += artworkManagerGetNextPageBtn_Click;
            // 
            // artworkManagerReloadBtn
            // 
            artworkManagerReloadBtn.Font = new Font("Leelawadee UI", 9F);
            artworkManagerReloadBtn.Location = new Point(593, 688);
            artworkManagerReloadBtn.Name = "artworkManagerReloadBtn";
            artworkManagerReloadBtn.Size = new Size(150, 46);
            artworkManagerReloadBtn.TabIndex = 12;
            artworkManagerReloadBtn.Text = "Reload";
            artworkManagerReloadBtn.UseVisualStyleBackColor = true;
            // 
            // deleteSelectedArtworkBtn
            // 
            deleteSelectedArtworkBtn.Font = new Font("Leelawadee UI", 9F);
            deleteSelectedArtworkBtn.Location = new Point(362, 26);
            deleteSelectedArtworkBtn.Name = "deleteSelectedArtworkBtn";
            deleteSelectedArtworkBtn.Size = new Size(293, 46);
            deleteSelectedArtworkBtn.TabIndex = 2;
            deleteSelectedArtworkBtn.Text = "Delete Selected Artwork";
            deleteSelectedArtworkBtn.UseVisualStyleBackColor = true;
            deleteSelectedArtworkBtn.Click += deleteSelectedArtworkBtn_Click;
            // 
            // postNewArtworkBtn
            // 
            postNewArtworkBtn.Font = new Font("Leelawadee UI", 9F);
            postNewArtworkBtn.Location = new Point(77, 26);
            postNewArtworkBtn.Name = "postNewArtworkBtn";
            postNewArtworkBtn.Size = new Size(235, 46);
            postNewArtworkBtn.TabIndex = 1;
            postNewArtworkBtn.Text = "Post New Artwork";
            postNewArtworkBtn.UseVisualStyleBackColor = true;
            postNewArtworkBtn.Click += postNewArtworkBtn_Click;
            // 
            // listView1
            // 
            listView1.Activation = ItemActivation.OneClick;
            listView1.Columns.AddRange(new ColumnHeader[] { lvArtworkTitle, lvTags, lvartworkCreationDate });
            listView1.Font = new Font("Leelawadee UI", 9F);
            listView1.Location = new Point(6, 103);
            listView1.MultiSelect = false;
            listView1.Name = "listView1";
            listView1.Size = new Size(746, 642);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // lvArtworkTitle
            // 
            lvArtworkTitle.Text = "ArtworkTitle";
            lvArtworkTitle.Width = 200;
            // 
            // lvTags
            // 
            lvTags.Text = "Tags";
            lvTags.Width = 200;
            // 
            // lvartworkCreationDate
            // 
            lvartworkCreationDate.Text = "Posted At";
            lvartworkCreationDate.Width = 200;
            // 
            // statisticsPage
            // 
            statisticsPage.Controls.Add(statsPrevButton);
            statisticsPage.Controls.Add(statNextButton);
            statisticsPage.Controls.Add(statsReloadBtn);
            statisticsPage.Controls.Add(accountAvgRatingValueLabel);
            statisticsPage.Controls.Add(totalViewsValueLabel);
            statisticsPage.Controls.Add(avgRatingValueLabel);
            statisticsPage.Controls.Add(dailyViewsValueLabel);
            statisticsPage.Controls.Add(accountAvgRatingLabel);
            statisticsPage.Controls.Add(avgRatingLabel);
            statisticsPage.Controls.Add(totalViewsLabel);
            statisticsPage.Controls.Add(dailyViewsLabel);
            statisticsPage.Controls.Add(statsView);
            statisticsPage.Font = new Font("Leelawadee UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            statisticsPage.Location = new Point(8, 46);
            statisticsPage.Name = "statisticsPage";
            statisticsPage.Padding = new Padding(3);
            statisticsPage.Size = new Size(758, 751);
            statisticsPage.TabIndex = 0;
            statisticsPage.Text = "Statistics";
            statisticsPage.UseVisualStyleBackColor = true;
            statisticsPage.Click += statisticsPage_Click;
            // 
            // statsPrevButton
            // 
            statsPrevButton.Font = new Font("Leelawadee UI", 9F);
            statsPrevButton.Location = new Point(15, 636);
            statsPrevButton.Name = "statsPrevButton";
            statsPrevButton.Size = new Size(181, 46);
            statsPrevButton.TabIndex = 16;
            statsPrevButton.Text = "Get Prev Page";
            statsPrevButton.UseVisualStyleBackColor = true;
            statsPrevButton.Click += statsPrevButton_Click;
            // 
            // statNextButton
            // 
            statNextButton.Font = new Font("Leelawadee UI", 9F);
            statNextButton.Location = new Point(15, 688);
            statNextButton.Name = "statNextButton";
            statNextButton.Size = new Size(181, 46);
            statNextButton.TabIndex = 15;
            statNextButton.Text = "Get Next Page";
            statNextButton.UseVisualStyleBackColor = true;
            // 
            // statsReloadBtn
            // 
            statsReloadBtn.Font = new Font("Leelawadee UI", 9F);
            statsReloadBtn.Location = new Point(593, 688);
            statsReloadBtn.Name = "statsReloadBtn";
            statsReloadBtn.Size = new Size(150, 46);
            statsReloadBtn.TabIndex = 11;
            statsReloadBtn.Text = "Reload";
            statsReloadBtn.UseVisualStyleBackColor = true;
            // 
            // accountAvgRatingValueLabel
            // 
            accountAvgRatingValueLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            accountAvgRatingValueLabel.ForeColor = Color.SteelBlue;
            accountAvgRatingValueLabel.Location = new Point(373, 138);
            accountAvgRatingValueLabel.Name = "accountAvgRatingValueLabel";
            accountAvgRatingValueLabel.Size = new Size(379, 45);
            accountAvgRatingValueLabel.TabIndex = 9;
            accountAvgRatingValueLabel.Text = "{Insert Acc Avg Rating}";
            accountAvgRatingValueLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // totalViewsValueLabel
            // 
            totalViewsValueLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            totalViewsValueLabel.Location = new Point(350, 48);
            totalViewsValueLabel.Name = "totalViewsValueLabel";
            totalViewsValueLabel.Size = new Size(402, 45);
            totalViewsValueLabel.TabIndex = 8;
            totalViewsValueLabel.Text = "{Insert Views Total}";
            totalViewsValueLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // avgRatingValueLabel
            // 
            avgRatingValueLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            avgRatingValueLabel.Location = new Point(350, 93);
            avgRatingValueLabel.Name = "avgRatingValueLabel";
            avgRatingValueLabel.Size = new Size(402, 45);
            avgRatingValueLabel.TabIndex = 7;
            avgRatingValueLabel.Text = "{Insert Post Avg Rating}";
            avgRatingValueLabel.TextAlign = ContentAlignment.TopRight;
            avgRatingValueLabel.Click += avgRatingValueLabel_Click;
            // 
            // dailyViewsValueLabel
            // 
            dailyViewsValueLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dailyViewsValueLabel.Location = new Point(350, 3);
            dailyViewsValueLabel.Name = "dailyViewsValueLabel";
            dailyViewsValueLabel.Size = new Size(402, 45);
            dailyViewsValueLabel.TabIndex = 6;
            dailyViewsValueLabel.Text = "{Insert Views for Day}";
            dailyViewsValueLabel.TextAlign = ContentAlignment.TopRight;
            dailyViewsValueLabel.Click += dailyViewsValueLabel_Click;
            // 
            // accountAvgRatingLabel
            // 
            accountAvgRatingLabel.AutoSize = true;
            accountAvgRatingLabel.ForeColor = Color.SteelBlue;
            accountAvgRatingLabel.Location = new Point(6, 138);
            accountAvgRatingLabel.Name = "accountAvgRatingLabel";
            accountAvgRatingLabel.Size = new Size(369, 45);
            accountAvgRatingLabel.TabIndex = 5;
            accountAvgRatingLabel.Text = "Account Average Rating:";
            // 
            // avgRatingLabel
            // 
            avgRatingLabel.AutoSize = true;
            avgRatingLabel.Location = new Point(6, 93);
            avgRatingLabel.Name = "avgRatingLabel";
            avgRatingLabel.Size = new Size(243, 45);
            avgRatingLabel.TabIndex = 4;
            avgRatingLabel.Text = "Average Rating:";
            // 
            // totalViewsLabel
            // 
            totalViewsLabel.AutoSize = true;
            totalViewsLabel.Location = new Point(6, 48);
            totalViewsLabel.Name = "totalViewsLabel";
            totalViewsLabel.Size = new Size(189, 45);
            totalViewsLabel.TabIndex = 3;
            totalViewsLabel.Text = "Views Total:";
            // 
            // dailyViewsLabel
            // 
            dailyViewsLabel.AutoSize = true;
            dailyViewsLabel.Location = new Point(6, 3);
            dailyViewsLabel.Name = "dailyViewsLabel";
            dailyViewsLabel.Size = new Size(204, 45);
            dailyViewsLabel.TabIndex = 2;
            dailyViewsLabel.Text = "Views Today:";
            // 
            // statsView
            // 
            statsView.Activation = ItemActivation.OneClick;
            statsView.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            statsView.Font = new Font("Leelawadee UI", 9F);
            statsView.Location = new Point(6, 209);
            statsView.MultiSelect = false;
            statsView.Name = "statsView";
            statsView.Size = new Size(746, 536);
            statsView.Sorting = SortOrder.Ascending;
            statsView.TabIndex = 1;
            statsView.UseCompatibleStateImageBehavior = false;
            statsView.View = View.Details;
            statsView.SelectedIndexChanged += statsView_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "ArtworkTitle";
            columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Tags";
            columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Posted At";
            columnHeader3.Width = 200;
            // 
            // headerLabel
            // 
            headerLabel.Font = new Font("Leelawadee UI", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            headerLabel.Location = new Point(336, 13);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(433, 62);
            headerLabel.TabIndex = 10;
            headerLabel.Text = "Artist Dashboard";
            headerLabel.TextAlign = ContentAlignment.TopRight;
            headerLabel.Click += headerLabel_Click;
            // 
            // ArtistDashboardInstance
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.LightGray;
            Controls.Add(headerLabel);
            Controls.Add(tabControl1);
            MaximumSize = new Size(780, 899);
            Name = "ArtistDashboardInstance";
            Size = new Size(780, 899);
            Load += ArtistDashboardInstance_Load;
            tabControl1.ResumeLayout(false);
            artworkManagementPage.ResumeLayout(false);
            statisticsPage.ResumeLayout(false);
            statisticsPage.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage statisticsPage;
        private TabPage artworkManagementPage;
        private Label headerLabel;
        private ListView listView1;
        private ColumnHeader lvArtworkTitle;
        private Button deleteSelectedArtworkBtn;
        private Button postNewArtworkBtn;
        private ColumnHeader lvTags;
        private ColumnHeader lvartworkCreationDate;
        private ColumnHeader ArtworkTitle;
        private Label avgRatingLabel;
        private Label totalViewsLabel;
        private Label dailyViewsLabel;
        private ListView statsView;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private Label accountAvgRatingLabel;
        private Label dailyViewsValueLabel;
        private Label totalViewsValueLabel;
        private Label avgRatingValueLabel;
        private Label accountAvgRatingValueLabel;
        private Button artworkManagerReloadBtn;
        private Button statsReloadBtn;
        private Button artworkManagerGetNextPageBtn;
        private Button artworkManagerGetPrevPageBtn;
        private Button statsPrevButton;
        private Button statNextButton;
    }
}
