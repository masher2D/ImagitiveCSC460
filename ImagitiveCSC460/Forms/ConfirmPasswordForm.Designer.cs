namespace ImagitiveCSC460UI.Forms
{
    partial class ConfirmPasswordForm
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
            passwordValue = new TextBox();
            headerLabel = new Label();
            bodyLabel = new Label();
            submitBtn = new Button();
            SuspendLayout();
            // 
            // passwordValue
            // 
            passwordValue.Location = new Point(216, 237);
            passwordValue.MaxLength = 20;
            passwordValue.Name = "passwordValue";
            passwordValue.Size = new Size(377, 39);
            passwordValue.TabIndex = 0;
            // 
            // headerLabel
            // 
            headerLabel.AutoSize = true;
            headerLabel.Font = new Font("Leelawadee UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            headerLabel.Location = new Point(75, 37);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(658, 65);
            headerLabel.TabIndex = 1;
            headerLabel.Text = "Please enter your password.";
            headerLabel.Click += label1_Click;
            // 
            // bodyLabel
            // 
            bodyLabel.AutoSize = true;
            bodyLabel.Font = new Font("Leelawadee UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bodyLabel.Location = new Point(22, 120);
            bodyLabel.Name = "bodyLabel";
            bodyLabel.Size = new Size(765, 90);
            bodyLabel.TabIndex = 2;
            bodyLabel.Text = "The action you are performing requires confirmation\r\n you are who you are supposed to be.";
            bodyLabel.TextAlign = ContentAlignment.TopCenter;
            bodyLabel.Click += label1_Click_1;
            // 
            // submitBtn
            // 
            submitBtn.Location = new Point(300, 299);
            submitBtn.Name = "submitBtn";
            submitBtn.Size = new Size(209, 46);
            submitBtn.TabIndex = 3;
            submitBtn.Text = "Submit Password";
            submitBtn.UseVisualStyleBackColor = true;
            submitBtn.Click += submitBtn_Click;
            // 
            // ConfirmPasswordForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 377);
            Controls.Add(submitBtn);
            Controls.Add(bodyLabel);
            Controls.Add(headerLabel);
            Controls.Add(passwordValue);
            Name = "ConfirmPasswordForm";
            Text = "ConfirmPasswordForm";
            Load += ConfirmPasswordForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox passwordValue;
        private Label headerLabel;
        private Label bodyLabel;
        private Button submitBtn;
    }
}