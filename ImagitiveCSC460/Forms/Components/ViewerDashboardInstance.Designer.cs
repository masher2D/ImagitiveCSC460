namespace ImagitiveCSC460UI.Forms.Components
{
    partial class ViewerDashboardInstance
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
            feedViewer = new ImageInstanceViewer();
            backBtn = new Button();
            forwardBtn = new Button();
            starRatingBar = new TrackBar();
            ratingLabel = new Label();
            rating5Label = new Label();
            panel1 = new Panel();
            ratingSubmitBtn = new Button();
            rating4Label = new Label();
            rating3Label = new Label();
            rating2Label = new Label();
            rating1Label = new Label();
            panel2 = new Panel();
            navLabel = new Label();
            headerLabel = new Label();
            label1 = new Label();
            tagFilterBox = new ComboBox();
            clearFiltersBtn = new Button();
            reloadBtn = new Button();
            downloadBtn = new Button();
            reportBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)starRatingBar).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // feedViewer
            // 
            feedViewer.AutoSize = true;
            feedViewer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            feedViewer.BackColor = Color.White;
            feedViewer.Location = new Point(24, 15);
            feedViewer.Name = "feedViewer";
            feedViewer.Size = new Size(503, 857);
            feedViewer.TabIndex = 0;
            // 
            // backBtn
            // 
            backBtn.Location = new Point(0, 3);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(150, 46);
            backBtn.TabIndex = 1;
            backBtn.Text = "↑ Go Back";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // forwardBtn
            // 
            forwardBtn.Location = new Point(0, 54);
            forwardBtn.Name = "forwardBtn";
            forwardBtn.Size = new Size(150, 46);
            forwardBtn.TabIndex = 2;
            forwardBtn.Text = "↓ Continue";
            forwardBtn.UseVisualStyleBackColor = true;
            forwardBtn.Click += forwardBtn_Click;
            // 
            // starRatingBar
            // 
            starRatingBar.Location = new Point(3, 3);
            starRatingBar.Maximum = 5;
            starRatingBar.Minimum = 1;
            starRatingBar.Name = "starRatingBar";
            starRatingBar.Orientation = Orientation.Vertical;
            starRatingBar.Size = new Size(90, 208);
            starRatingBar.TabIndex = 1;
            starRatingBar.Value = 2;
            starRatingBar.Scroll += starRatingBar_Scroll;
            // 
            // ratingLabel
            // 
            ratingLabel.AutoSize = true;
            ratingLabel.Font = new Font("Leelawadee UI", 11F);
            ratingLabel.Location = new Point(604, 580);
            ratingLabel.Name = "ratingLabel";
            ratingLabel.Size = new Size(103, 41);
            ratingLabel.TabIndex = 4;
            ratingLabel.Text = "Rating";
            ratingLabel.Click += ratingLabel_Click;
            // 
            // rating5Label
            // 
            rating5Label.AutoSize = true;
            rating5Label.Font = new Font("Leelawadee UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rating5Label.Location = new Point(120, 7);
            rating5Label.Name = "rating5Label";
            rating5Label.Size = new Size(27, 32);
            rating5Label.TabIndex = 5;
            rating5Label.Text = "5";
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightGray;
            panel1.Controls.Add(ratingSubmitBtn);
            panel1.Controls.Add(rating4Label);
            panel1.Controls.Add(rating3Label);
            panel1.Controls.Add(rating2Label);
            panel1.Controls.Add(rating1Label);
            panel1.Controls.Add(starRatingBar);
            panel1.Controls.Add(rating5Label);
            panel1.Location = new Point(580, 624);
            panel1.Name = "panel1";
            panel1.Size = new Size(150, 272);
            panel1.TabIndex = 6;
            panel1.Paint += panel1_Paint;
            // 
            // ratingSubmitBtn
            // 
            ratingSubmitBtn.Font = new Font("Leelawadee UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ratingSubmitBtn.Location = new Point(3, 217);
            ratingSubmitBtn.Name = "ratingSubmitBtn";
            ratingSubmitBtn.Size = new Size(144, 46);
            ratingSubmitBtn.TabIndex = 9;
            ratingSubmitBtn.Text = "Submit";
            ratingSubmitBtn.UseVisualStyleBackColor = true;
            ratingSubmitBtn.Click += ratingSubmitBtn_Click;
            // 
            // rating4Label
            // 
            rating4Label.AutoSize = true;
            rating4Label.Font = new Font("Leelawadee UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rating4Label.Location = new Point(120, 47);
            rating4Label.Name = "rating4Label";
            rating4Label.Size = new Size(27, 32);
            rating4Label.TabIndex = 8;
            rating4Label.Text = "4";
            // 
            // rating3Label
            // 
            rating3Label.AutoSize = true;
            rating3Label.Font = new Font("Leelawadee UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rating3Label.Location = new Point(120, 87);
            rating3Label.Name = "rating3Label";
            rating3Label.Size = new Size(27, 32);
            rating3Label.TabIndex = 8;
            rating3Label.Text = "3";
            // 
            // rating2Label
            // 
            rating2Label.AutoSize = true;
            rating2Label.Font = new Font("Leelawadee UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rating2Label.Location = new Point(120, 127);
            rating2Label.Name = "rating2Label";
            rating2Label.Size = new Size(27, 32);
            rating2Label.TabIndex = 7;
            rating2Label.Text = "2";
            // 
            // rating1Label
            // 
            rating1Label.AutoSize = true;
            rating1Label.Font = new Font("Leelawadee UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rating1Label.Location = new Point(120, 167);
            rating1Label.Name = "rating1Label";
            rating1Label.Size = new Size(27, 32);
            rating1Label.TabIndex = 6;
            rating1Label.Text = "1";
            // 
            // panel2
            // 
            panel2.Controls.Add(backBtn);
            panel2.Controls.Add(forwardBtn);
            panel2.Location = new Point(578, 472);
            panel2.Name = "panel2";
            panel2.Size = new Size(150, 106);
            panel2.TabIndex = 7;
            // 
            // navLabel
            // 
            navLabel.Font = new Font("Leelawadee UI", 9.5F);
            navLabel.Location = new Point(530, 428);
            navLabel.Name = "navLabel";
            navLabel.Size = new Size(247, 41);
            navLabel.TabIndex = 8;
            navLabel.Text = "Navigation";
            navLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // headerLabel
            // 
            headerLabel.Font = new Font("Leelawadee UI", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            headerLabel.Location = new Point(530, 15);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(247, 130);
            headerLabel.TabIndex = 9;
            headerLabel.Text = "Viewer Dashboard";
            headerLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Leelawadee UI", 11F);
            label1.Location = new Point(560, 242);
            label1.Name = "label1";
            label1.Size = new Size(187, 41);
            label1.TabIndex = 18;
            label1.Text = "Filter By Tag:";
            // 
            // tagFilterBox
            // 
            tagFilterBox.FormattingEnabled = true;
            tagFilterBox.Location = new Point(547, 286);
            tagFilterBox.Name = "tagFilterBox";
            tagFilterBox.Size = new Size(212, 40);
            tagFilterBox.TabIndex = 17;
            tagFilterBox.SelectedIndexChanged += tagFilterBox_SelectedIndexChanged;
            // 
            // clearFiltersBtn
            // 
            clearFiltersBtn.Font = new Font("Leelawadee UI", 8.5F);
            clearFiltersBtn.Location = new Point(563, 332);
            clearFiltersBtn.Name = "clearFiltersBtn";
            clearFiltersBtn.Size = new Size(181, 40);
            clearFiltersBtn.TabIndex = 26;
            clearFiltersBtn.Text = "Clear Filters";
            clearFiltersBtn.UseVisualStyleBackColor = true;
            clearFiltersBtn.Click += clearFiltersBtn_Click;
            // 
            // reloadBtn
            // 
            reloadBtn.Font = new Font("Leelawadee UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            reloadBtn.Location = new Point(581, 378);
            reloadBtn.Name = "reloadBtn";
            reloadBtn.Size = new Size(144, 46);
            reloadBtn.TabIndex = 27;
            reloadBtn.Text = "Reload";
            reloadBtn.UseVisualStyleBackColor = true;
            reloadBtn.Click += reloadBtn_Click;
            // 
            // downloadBtn
            // 
            downloadBtn.Font = new Font("Leelawadee UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            downloadBtn.Location = new Point(581, 141);
            downloadBtn.Name = "downloadBtn";
            downloadBtn.Size = new Size(144, 46);
            downloadBtn.TabIndex = 28;
            downloadBtn.Text = "Download";
            downloadBtn.UseVisualStyleBackColor = true;
            downloadBtn.Click += downloadBtn_Click;
            // 
            // reportBtn
            // 
            reportBtn.Font = new Font("Leelawadee UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            reportBtn.Location = new Point(581, 193);
            reportBtn.Name = "reportBtn";
            reportBtn.Size = new Size(144, 46);
            reportBtn.TabIndex = 29;
            reportBtn.Text = "Report Art";
            reportBtn.UseVisualStyleBackColor = true;
            reportBtn.Click += reportBtn_Click;
            // 
            // ViewerDashboardInstance
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Silver;
            Controls.Add(reportBtn);
            Controls.Add(downloadBtn);
            Controls.Add(reloadBtn);
            Controls.Add(clearFiltersBtn);
            Controls.Add(label1);
            Controls.Add(tagFilterBox);
            Controls.Add(headerLabel);
            Controls.Add(navLabel);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(ratingLabel);
            Controls.Add(feedViewer);
            MaximumSize = new Size(780, 899);
            Name = "ViewerDashboardInstance";
            Size = new Size(780, 899);
            Load += ViewerDashboardInstance_Load;
            ((System.ComponentModel.ISupportInitialize)starRatingBar).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ImageInstanceViewer feedViewer;
        private Button backBtn;
        private Button forwardBtn;
        private TrackBar starRatingBar;
        private Label ratingLabel;
        private Label rating5Label;
        private Panel panel1;
        private Label rating4Label;
        private Label rating3Label;
        private Label rating2Label;
        private Label rating1Label;
        private Button ratingSubmitBtn;
        private Panel panel2;
        private Label navLabel;
        private Label headerLabel;
        private Label label1;
        private ComboBox tagFilterBox;
        private Button clearFiltersBtn;
        private Button reloadBtn;
        private Button downloadBtn;
        private Button reportBtn;
    }
}
