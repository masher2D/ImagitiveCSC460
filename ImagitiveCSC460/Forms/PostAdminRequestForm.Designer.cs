namespace ImagitiveCSC460UI.Forms
{
    partial class PostAdminRequestForm
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
            descriptionLabel = new Label();
            usernameLabel = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            postBtn = new Button();
            SuspendLayout();
            // 
            // headerLabel
            // 
            headerLabel.AutoSize = true;
            headerLabel.Font = new Font("Leelawadee UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            headerLabel.Location = new Point(12, 9);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(932, 86);
            headerLabel.TabIndex = 2;
            headerLabel.Text = "Request a User for Promotion";
            headerLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Font = new Font("Leelawadee UI", 11F);
            descriptionLabel.Location = new Point(12, 217);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(834, 41);
            descriptionLabel.TabIndex = 14;
            descriptionLabel.Text = "Description - Briefly explain what makes them admin material.";
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Font = new Font("Leelawadee UI", 11F);
            usernameLabel.Location = new Point(12, 116);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(335, 41);
            usernameLabel.TabIndex = 15;
            usernameLabel.Text = "Username of Requestee";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 160);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(335, 39);
            textBox1.TabIndex = 16;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 261);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(834, 117);
            textBox2.TabIndex = 17;
            // 
            // postBtn
            // 
            postBtn.Font = new Font("Leelawadee UI", 12F);
            postBtn.Location = new Point(12, 425);
            postBtn.Name = "postBtn";
            postBtn.Size = new Size(231, 103);
            postBtn.TabIndex = 18;
            postBtn.Text = "Post Request";
            postBtn.UseVisualStyleBackColor = true;
            // 
            // PostAdminRequestForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1055, 554);
            Controls.Add(postBtn);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(usernameLabel);
            Controls.Add(descriptionLabel);
            Controls.Add(headerLabel);
            Name = "PostAdminRequestForm";
            Text = "PostAdminRequestForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label headerLabel;
        private Label descriptionLabel;
        private Label usernameLabel;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button postBtn;
    }
}