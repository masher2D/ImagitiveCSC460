namespace ImagitiveCSC460UI.Forms.Components
{
    partial class HandleAdminPromotionRequestForm
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
            reportDescriptionValue = new Label();
            requestDescriptionLabel = new Label();
            reportedValue = new Label();
            suggestedUserLabel = new Label();
            headerLabel = new Label();
            submitDecisionBtn = new Button();
            userActionBox = new ComboBox();
            judgementLabel = new Label();
            SuspendLayout();
            // 
            // reportDescriptionValue
            // 
            reportDescriptionValue.Font = new Font("Leelawadee UI", 13F, FontStyle.Bold);
            reportDescriptionValue.Location = new Point(12, 312);
            reportDescriptionValue.Name = "reportDescriptionValue";
            reportDescriptionValue.Size = new Size(1100, 141);
            reportDescriptionValue.TabIndex = 23;
            reportDescriptionValue.Text = "{Insert report description}";
            // 
            // requestDescriptionLabel
            // 
            requestDescriptionLabel.AutoSize = true;
            requestDescriptionLabel.Font = new Font("Leelawadee UI", 11F);
            requestDescriptionLabel.Location = new Point(12, 271);
            requestDescriptionLabel.Name = "requestDescriptionLabel";
            requestDescriptionLabel.Size = new Size(434, 41);
            requestDescriptionLabel.TabIndex = 22;
            requestDescriptionLabel.Text = "Promotion Request Description";
            // 
            // reportedValue
            // 
            reportedValue.AutoSize = true;
            reportedValue.Font = new Font("Leelawadee UI", 13F, FontStyle.Bold);
            reportedValue.Location = new Point(12, 194);
            reportedValue.Name = "reportedValue";
            reportedValue.Size = new Size(435, 47);
            reportedValue.TabIndex = 21;
            reportedValue.Text = "{Insert Username, userId}";
            // 
            // suggestedUserLabel
            // 
            suggestedUserLabel.AutoSize = true;
            suggestedUserLabel.Font = new Font("Leelawadee UI", 11F);
            suggestedUserLabel.Location = new Point(12, 153);
            suggestedUserLabel.Name = "suggestedUserLabel";
            suggestedUserLabel.Size = new Size(422, 41);
            suggestedUserLabel.TabIndex = 20;
            suggestedUserLabel.Text = "Suggested User for Promotion";
            // 
            // headerLabel
            // 
            headerLabel.Font = new Font("Leelawadee UI", 24F, FontStyle.Bold);
            headerLabel.Location = new Point(12, 9);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(479, 86);
            headerLabel.TabIndex = 19;
            headerLabel.Text = "Handle Report";
            // 
            // submitDecisionBtn
            // 
            submitDecisionBtn.Enabled = false;
            submitDecisionBtn.Font = new Font("Leelawadee UI", 12F);
            submitDecisionBtn.Location = new Point(449, 574);
            submitDecisionBtn.Name = "submitDecisionBtn";
            submitDecisionBtn.Size = new Size(231, 103);
            submitDecisionBtn.TabIndex = 25;
            submitDecisionBtn.Text = "Submit Decision";
            submitDecisionBtn.UseVisualStyleBackColor = true;
            submitDecisionBtn.Click += submitDecisionBtn_Click;
            // 
            // userActionBox
            // 
            userActionBox.FormattingEnabled = true;
            userActionBox.Items.AddRange(new object[] { "Approve", "Deny" });
            userActionBox.Location = new Point(459, 515);
            userActionBox.Name = "userActionBox";
            userActionBox.Size = new Size(210, 40);
            userActionBox.TabIndex = 26;
            // 
            // judgementLabel
            // 
            judgementLabel.AutoSize = true;
            judgementLabel.Font = new Font("Leelawadee UI", 11F);
            judgementLabel.Location = new Point(363, 471);
            judgementLabel.Name = "judgementLabel";
            judgementLabel.Size = new Size(403, 41);
            judgementLabel.TabIndex = 27;
            judgementLabel.Text = "How should this be handled?";
            // 
            // HandleAdminPromotionRequestForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1124, 689);
            Controls.Add(judgementLabel);
            Controls.Add(userActionBox);
            Controls.Add(submitDecisionBtn);
            Controls.Add(reportDescriptionValue);
            Controls.Add(requestDescriptionLabel);
            Controls.Add(reportedValue);
            Controls.Add(suggestedUserLabel);
            Controls.Add(headerLabel);
            Name = "HandleAdminPromotionRequestForm";
            Text = "HandleAdminPromotionRequestForm";
            Load += HandleAdminPromotionRequestForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label reportDescriptionValue;
        private Label requestDescriptionLabel;
        private Label reportedValue;
        private Label suggestedUserLabel;
        private Label headerLabel;
        private Button submitDecisionBtn;
        private ComboBox userActionBox;
        private Label judgementLabel;
    }
}