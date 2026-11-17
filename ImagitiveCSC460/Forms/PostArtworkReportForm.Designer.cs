namespace ImagitiveCSC460UI.Forms.Components
{
    partial class PostArtworkReportForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            headerLabel = new Label();
            reportReasonsBox = new ComboBox();
            reportReasonLabel = new Label();
            reportDescriptionLabel = new Label();
            reportDescriptionValue = new TextBox();
            postReportBtn = new Button();
            reportedLabel = new Label();
            SuspendLayout();
            // 
            // headerLabel
            // 
            headerLabel.AutoSize = true;
            headerLabel.Font = new Font("Leelawadee UI", 18F, FontStyle.Bold);
            headerLabel.Location = new Point(12, 9);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(380, 65);
            headerLabel.TabIndex = 13;
            headerLabel.Text = "Report Artwork";
            // 
            // reportReasonsBox
            // 
            reportReasonsBox.FormattingEnabled = true;
            reportReasonsBox.Location = new Point(12, 211);
            reportReasonsBox.Name = "reportReasonsBox";
            reportReasonsBox.Size = new Size(298, 40);
            reportReasonsBox.TabIndex = 22;
            // 
            // reportReasonLabel
            // 
            reportReasonLabel.AutoSize = true;
            reportReasonLabel.Font = new Font("Leelawadee UI", 11F);
            reportReasonLabel.Location = new Point(12, 167);
            reportReasonLabel.Name = "reportReasonLabel";
            reportReasonLabel.Size = new Size(213, 41);
            reportReasonLabel.TabIndex = 23;
            reportReasonLabel.Text = "Report Reason";
            // 
            // reportDescriptionLabel
            // 
            reportDescriptionLabel.AutoSize = true;
            reportDescriptionLabel.Font = new Font("Leelawadee UI", 11F);
            reportDescriptionLabel.Location = new Point(12, 262);
            reportDescriptionLabel.Name = "reportDescriptionLabel";
            reportDescriptionLabel.Size = new Size(819, 41);
            reportDescriptionLabel.TabIndex = 24;
            reportDescriptionLabel.Text = "Report Description - Briefly describe the need for this report.";
            // 
            // reportDescriptionValue
            // 
            reportDescriptionValue.Location = new Point(12, 306);
            reportDescriptionValue.MaxLength = 1000;
            reportDescriptionValue.Multiline = true;
            reportDescriptionValue.Name = "reportDescriptionValue";
            reportDescriptionValue.Size = new Size(819, 117);
            reportDescriptionValue.TabIndex = 25;
            // 
            // postReportBtn
            // 
            postReportBtn.Font = new Font("Leelawadee UI", 12F);
            postReportBtn.Location = new Point(321, 438);
            postReportBtn.Name = "postReportBtn";
            postReportBtn.Size = new Size(231, 103);
            postReportBtn.TabIndex = 26;
            postReportBtn.Text = "Post Report";
            postReportBtn.UseVisualStyleBackColor = true;
            postReportBtn.Click += postReportBtn_Click;
            // 
            // reportedLabel
            // 
            reportedLabel.AutoSize = true;
            reportedLabel.Font = new Font("Leelawadee UI", 14F, FontStyle.Bold);
            reportedLabel.Location = new Point(12, 94);
            reportedLabel.Name = "reportedLabel";
            reportedLabel.Size = new Size(605, 51);
            reportedLabel.TabIndex = 27;
            reportedLabel.Text = "You are reporting: {artworkTitle}";
            // 
            // PostArtworkReportForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(883, 553);
            Controls.Add(reportedLabel);
            Controls.Add(postReportBtn);
            Controls.Add(reportDescriptionValue);
            Controls.Add(reportDescriptionLabel);
            Controls.Add(reportReasonLabel);
            Controls.Add(reportReasonsBox);
            Controls.Add(headerLabel);
            Name = "PostArtworkReportForm";
            Text = "PostArtworkReportForm";
            Load += PostArtworkReportForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label headerLabel;
        private ComboBox reportReasonsBox;
        private Label reportReasonLabel;
        private Label reportDescriptionLabel;
        private TextBox reportDescriptionValue;
        private Button postReportBtn;
        private Label reportedLabel;
    }
}