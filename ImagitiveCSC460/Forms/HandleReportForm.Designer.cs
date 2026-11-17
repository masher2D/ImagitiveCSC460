namespace ImagitiveCSC460UI.Forms.Components
{
    partial class HandleReportForm
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
            reportedLabel = new Label();
            reportedValue = new Label();
            reportDescriptionLabel = new Label();
            reportReasonLabel = new Label();
            reportReasonNameValue = new Label();
            reportDescriptionValue = new Label();
            reporterLabel = new Label();
            judgementLabel = new Label();
            userActionBox = new ComboBox();
            restrictUntilLabel = new Label();
            submitDecisionBtn = new Button();
            restrictUntilDatePicker = new DateTimePicker();
            decisionLabel = new Label();
            decisionValue = new Label();
            resolverValue = new Label();
            resolverLabel = new Label();
            SuspendLayout();
            // 
            // headerLabel
            // 
            headerLabel.Font = new Font("Leelawadee UI", 24F, FontStyle.Bold);
            headerLabel.Location = new Point(12, 9);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(479, 86);
            headerLabel.TabIndex = 12;
            headerLabel.Text = "Handle Report";
            // 
            // reportedLabel
            // 
            reportedLabel.AutoSize = true;
            reportedLabel.Font = new Font("Leelawadee UI", 11F);
            reportedLabel.Location = new Point(12, 153);
            reportedLabel.Name = "reportedLabel";
            reportedLabel.Size = new Size(342, 41);
            reportedLabel.TabIndex = 13;
            reportedLabel.Text = "Reported User / Artwork";
            reportedLabel.Click += reportedLabel_Click;
            // 
            // reportedValue
            // 
            reportedValue.AutoSize = true;
            reportedValue.Font = new Font("Leelawadee UI", 13F, FontStyle.Bold);
            reportedValue.Location = new Point(12, 194);
            reportedValue.Name = "reportedValue";
            reportedValue.Size = new Size(863, 47);
            reportedValue.TabIndex = 14;
            reportedValue.Text = "{Insert Username, userId / ArtworkTitle, artworkId}";
            // 
            // reportDescriptionLabel
            // 
            reportDescriptionLabel.AutoSize = true;
            reportDescriptionLabel.Font = new Font("Leelawadee UI", 11F);
            reportDescriptionLabel.Location = new Point(12, 433);
            reportDescriptionLabel.Name = "reportDescriptionLabel";
            reportDescriptionLabel.Size = new Size(267, 41);
            reportDescriptionLabel.TabIndex = 15;
            reportDescriptionLabel.Text = "Report Description";
            // 
            // reportReasonLabel
            // 
            reportReasonLabel.AutoSize = true;
            reportReasonLabel.Font = new Font("Leelawadee UI", 11F);
            reportReasonLabel.Location = new Point(12, 293);
            reportReasonLabel.Name = "reportReasonLabel";
            reportReasonLabel.Size = new Size(213, 41);
            reportReasonLabel.TabIndex = 16;
            reportReasonLabel.Text = "Report Reason";
            // 
            // reportReasonNameValue
            // 
            reportReasonNameValue.AutoSize = true;
            reportReasonNameValue.Font = new Font("Leelawadee UI", 13F, FontStyle.Bold);
            reportReasonNameValue.Location = new Point(12, 334);
            reportReasonNameValue.Name = "reportReasonNameValue";
            reportReasonNameValue.Size = new Size(360, 47);
            reportReasonNameValue.TabIndex = 17;
            reportReasonNameValue.Text = "{Insert reason name}";
            // 
            // reportDescriptionValue
            // 
            reportDescriptionValue.Font = new Font("Leelawadee UI", 13F, FontStyle.Bold);
            reportDescriptionValue.Location = new Point(12, 474);
            reportDescriptionValue.Name = "reportDescriptionValue";
            reportDescriptionValue.Size = new Size(1100, 141);
            reportDescriptionValue.TabIndex = 18;
            reportDescriptionValue.Text = "{Insert report description}";
            // 
            // reporterLabel
            // 
            reporterLabel.Font = new Font("Leelawadee UI", 11F);
            reporterLabel.Location = new Point(528, 9);
            reporterLabel.Name = "reporterLabel";
            reporterLabel.Size = new Size(584, 86);
            reporterLabel.TabIndex = 19;
            reporterLabel.Text = "Reported by: \r\n{Username, userId}";
            reporterLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // judgementLabel
            // 
            judgementLabel.AutoSize = true;
            judgementLabel.Font = new Font("Leelawadee UI", 11F);
            judgementLabel.Location = new Point(359, 694);
            judgementLabel.Name = "judgementLabel";
            judgementLabel.Size = new Size(403, 41);
            judgementLabel.TabIndex = 20;
            judgementLabel.Text = "How should this be handled?";
            // 
            // userActionBox
            // 
            userActionBox.FormattingEnabled = true;
            userActionBox.Items.AddRange(new object[] { "Dismiss the Report", "Warn the Reported User", "Restrict the Reported User", "Ban the Reported User" });
            userActionBox.Location = new Point(360, 738);
            userActionBox.Name = "userActionBox";
            userActionBox.Size = new Size(402, 40);
            userActionBox.TabIndex = 21;
            // 
            // restrictUntilLabel
            // 
            restrictUntilLabel.AutoSize = true;
            restrictUntilLabel.Font = new Font("Leelawadee UI", 11F);
            restrictUntilLabel.Location = new Point(394, 790);
            restrictUntilLabel.Name = "restrictUntilLabel";
            restrictUntilLabel.Size = new Size(333, 41);
            restrictUntilLabel.TabIndex = 22;
            restrictUntilLabel.Text = "If restricted, until when?";
            // 
            // submitDecisionBtn
            // 
            submitDecisionBtn.Enabled = false;
            submitDecisionBtn.Font = new Font("Leelawadee UI", 12F);
            submitDecisionBtn.Location = new Point(445, 906);
            submitDecisionBtn.Name = "submitDecisionBtn";
            submitDecisionBtn.Size = new Size(231, 103);
            submitDecisionBtn.TabIndex = 24;
            submitDecisionBtn.Text = "Submit Decision";
            submitDecisionBtn.UseVisualStyleBackColor = true;
            submitDecisionBtn.Click += submitDecisionBtn_ClickAsync;
            // 
            // restrictUntilDatePicker
            // 
            restrictUntilDatePicker.Location = new Point(360, 834);
            restrictUntilDatePicker.Name = "restrictUntilDatePicker";
            restrictUntilDatePicker.Size = new Size(400, 39);
            restrictUntilDatePicker.TabIndex = 25;
            // 
            // decisionLabel
            // 
            decisionLabel.AutoSize = true;
            decisionLabel.Font = new Font("Leelawadee UI", 11F);
            decisionLabel.Location = new Point(12, 628);
            decisionLabel.Name = "decisionLabel";
            decisionLabel.Size = new Size(190, 41);
            decisionLabel.TabIndex = 26;
            decisionLabel.Text = "Action Taken";
            decisionLabel.Visible = false;
            // 
            // decisionValue
            // 
            decisionValue.AutoSize = true;
            decisionValue.Font = new Font("Leelawadee UI", 13F, FontStyle.Bold);
            decisionValue.Location = new Point(12, 669);
            decisionValue.Name = "decisionValue";
            decisionValue.Size = new Size(507, 47);
            decisionValue.TabIndex = 27;
            decisionValue.Text = "{Insert decision, if applicable}";
            decisionValue.Visible = false;
            // 
            // resolverValue
            // 
            resolverValue.AutoSize = true;
            resolverValue.Font = new Font("Leelawadee UI", 13F, FontStyle.Bold);
            resolverValue.Location = new Point(12, 831);
            resolverValue.Name = "resolverValue";
            resolverValue.Size = new Size(507, 47);
            resolverValue.TabIndex = 29;
            resolverValue.Text = "{Insert decision, if applicable}";
            resolverValue.Visible = false;
            // 
            // resolverLabel
            // 
            resolverLabel.AutoSize = true;
            resolverLabel.Font = new Font("Leelawadee UI", 11F);
            resolverLabel.Location = new Point(12, 790);
            resolverLabel.Name = "resolverLabel";
            resolverLabel.Size = new Size(185, 41);
            resolverLabel.TabIndex = 28;
            resolverLabel.Text = "Resolved By:";
            resolverLabel.Visible = false;
            // 
            // HandleReportForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1124, 1044);
            Controls.Add(resolverValue);
            Controls.Add(resolverLabel);
            Controls.Add(decisionValue);
            Controls.Add(decisionLabel);
            Controls.Add(restrictUntilDatePicker);
            Controls.Add(submitDecisionBtn);
            Controls.Add(restrictUntilLabel);
            Controls.Add(userActionBox);
            Controls.Add(judgementLabel);
            Controls.Add(reporterLabel);
            Controls.Add(reportDescriptionValue);
            Controls.Add(reportReasonNameValue);
            Controls.Add(reportReasonLabel);
            Controls.Add(reportDescriptionLabel);
            Controls.Add(reportedValue);
            Controls.Add(reportedLabel);
            Controls.Add(headerLabel);
            Name = "HandleReportForm";
            Text = "HandleReportForm";
            Load += HandleReportForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label headerLabel;
        private Label reportedLabel;
        private Label reportedValue;
        private Label reportDescriptionLabel;
        private Label reportReasonLabel;
        private Label reportReasonNameValue;
        private Label reportDescriptionValue;
        private Label reporterLabel;
        private Label judgementLabel;
        private ComboBox userActionBox;
        private Label restrictUntilLabel;
        private Button submitDecisionBtn;
        private DateTimePicker restrictUntilDatePicker;
        private Label decisionLabel;
        private Label decisionValue;
        private Label resolverValue;
        private Label resolverLabel;
    }
}