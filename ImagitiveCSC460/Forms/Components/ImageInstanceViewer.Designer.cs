namespace ImagitiveCSC460UI.Forms.Components
{
    partial class ImageInstanceViewer
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
            artworkImageBox = new PictureBox();
            artworkTitleLabel = new Label();
            artworkDescriptionLabel = new Label();
            artworkOptionsBtn = new Button();
            artworkUsernameLabel = new Label();
            artworkAvgRatingLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)artworkImageBox).BeginInit();
            SuspendLayout();
            // 
            // artworkImageBox
            // 
            artworkImageBox.Location = new Point(10, 3);
            artworkImageBox.Name = "artworkImageBox";
            artworkImageBox.Size = new Size(480, 480);
            artworkImageBox.SizeMode = PictureBoxSizeMode.Zoom;
            artworkImageBox.TabIndex = 0;
            artworkImageBox.TabStop = false;
            artworkImageBox.Click += artworkImageBox_Click;
            // 
            // artworkTitleLabel
            // 
            artworkTitleLabel.Font = new Font("Leelawadee UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            artworkTitleLabel.ImageAlign = ContentAlignment.MiddleRight;
            artworkTitleLabel.Location = new Point(34, 486);
            artworkTitleLabel.Name = "artworkTitleLabel";
            artworkTitleLabel.Size = new Size(432, 150);
            artworkTitleLabel.TabIndex = 1;
            artworkTitleLabel.Text = "{InsertArtworkTitle}";
            artworkTitleLabel.TextAlign = ContentAlignment.TopCenter;
            artworkTitleLabel.Click += artworkTitleLabel_Click;
            // 
            // artworkDescriptionLabel
            // 
            artworkDescriptionLabel.BackColor = Color.Silver;
            artworkDescriptionLabel.Font = new Font("Leelawadee UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            artworkDescriptionLabel.Location = new Point(3, 677);
            artworkDescriptionLabel.Name = "artworkDescriptionLabel";
            artworkDescriptionLabel.Size = new Size(497, 133);
            artworkDescriptionLabel.TabIndex = 2;
            artworkDescriptionLabel.Text = "{InsertArtworkDescription}";
            artworkDescriptionLabel.TextAlign = ContentAlignment.TopCenter;
            artworkDescriptionLabel.Click += artworkDescriptionLabel_Click;
            // 
            // artworkOptionsBtn
            // 
            artworkOptionsBtn.Location = new Point(447, 813);
            artworkOptionsBtn.Name = "artworkOptionsBtn";
            artworkOptionsBtn.Size = new Size(50, 50);
            artworkOptionsBtn.TabIndex = 5;
            artworkOptionsBtn.Text = "⋮";
            artworkOptionsBtn.UseVisualStyleBackColor = true;
            artworkOptionsBtn.Click += artworkOptionsBtn_Click;
            // 
            // artworkUsernameLabel
            // 
            artworkUsernameLabel.Font = new Font("Leelawadee UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            artworkUsernameLabel.Location = new Point(51, 812);
            artworkUsernameLabel.Name = "artworkUsernameLabel";
            artworkUsernameLabel.Size = new Size(390, 45);
            artworkUsernameLabel.TabIndex = 3;
            artworkUsernameLabel.Text = "{InsertUsername}";
            artworkUsernameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // artworkAvgRatingLabel
            // 
            artworkAvgRatingLabel.Font = new Font("Leelawadee UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            artworkAvgRatingLabel.Location = new Point(6, 636);
            artworkAvgRatingLabel.Name = "artworkAvgRatingLabel";
            artworkAvgRatingLabel.Size = new Size(494, 41);
            artworkAvgRatingLabel.TabIndex = 6;
            artworkAvgRatingLabel.Text = "{InsertArtworkAvgRating}";
            artworkAvgRatingLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // ImageInstanceViewer
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            Controls.Add(artworkAvgRatingLabel);
            Controls.Add(artworkUsernameLabel);
            Controls.Add(artworkOptionsBtn);
            Controls.Add(artworkDescriptionLabel);
            Controls.Add(artworkTitleLabel);
            Controls.Add(artworkImageBox);
            Name = "ImageInstanceViewer";
            Size = new Size(503, 866);
            Load += ImageInstanceViewer_Load;
            ((System.ComponentModel.ISupportInitialize)artworkImageBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox artworkImageBox;
        private Label artworkTitleLabel;
        private Label artworkDescriptionLabel;
        private Button artworkOptionsBtn;
        private Label artworkUsernameLabel;
        private Label artworkAvgRatingLabel;
    }
}
