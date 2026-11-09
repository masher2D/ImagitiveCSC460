namespace ImagitiveCSC460UI.Forms
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            headerLabel = new Label();
            usernameLabelE = new Label();
            usernameValue = new TextBox();
            passwordValue = new TextBox();
            passwordLabelE = new Label();
            loginBtn = new Button();
            loginAsLabel = new Label();
            splitContainer1 = new SplitContainer();
            selectedRoleComboBox = new ComboBox();
            emailLabel = new Label();
            emailValue = new TextBox();
            viewerCheckBox = new CheckBox();
            artistCheckBox = new CheckBox();
            signupBtn = new Button();
            signupAsLabel = new Label();
            passwordLabelN = new Label();
            passwordValueN = new TextBox();
            usernameLabelN = new Label();
            usernameValueN = new TextBox();
            subtitleLabel = new Label();
            existingUsersLabel = new Label();
            newUsersLabel = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // headerLabel
            // 
            headerLabel.AutoSize = true;
            headerLabel.Font = new Font("Leelawadee UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            headerLabel.Location = new Point(12, 9);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(298, 86);
            headerLabel.TabIndex = 0;
            headerLabel.Text = "Imagitive";
            headerLabel.TextAlign = ContentAlignment.TopCenter;
            headerLabel.Click += headerLabel_Click;
            // 
            // usernameLabelE
            // 
            usernameLabelE.AutoSize = true;
            usernameLabelE.Font = new Font("Leelawadee UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            usernameLabelE.Location = new Point(103, 14);
            usernameLabelE.Name = "usernameLabelE";
            usernameLabelE.Size = new Size(163, 45);
            usernameLabelE.TabIndex = 1;
            usernameLabelE.Text = "Username";
            // 
            // usernameValue
            // 
            usernameValue.Location = new Point(84, 62);
            usernameValue.MaxLength = 50;
            usernameValue.Name = "usernameValue";
            usernameValue.Size = new Size(200, 39);
            usernameValue.TabIndex = 2;
            usernameValue.TextChanged += usernameValue_TextChanged;
            // 
            // passwordValue
            // 
            passwordValue.Location = new Point(84, 153);
            passwordValue.Name = "passwordValue";
            passwordValue.Size = new Size(200, 39);
            passwordValue.TabIndex = 4;
            // 
            // passwordLabelE
            // 
            passwordLabelE.AutoSize = true;
            passwordLabelE.Font = new Font("Leelawadee UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passwordLabelE.Location = new Point(107, 105);
            passwordLabelE.Name = "passwordLabelE";
            passwordLabelE.Size = new Size(154, 45);
            passwordLabelE.TabIndex = 3;
            passwordLabelE.Text = "Password";
            // 
            // loginBtn
            // 
            loginBtn.Location = new Point(109, 424);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(150, 46);
            loginBtn.TabIndex = 5;
            loginBtn.Text = "Login";
            loginBtn.UseVisualStyleBackColor = true;
            loginBtn.Click += loginBtn_Click;
            // 
            // loginAsLabel
            // 
            loginAsLabel.AutoSize = true;
            loginAsLabel.Font = new Font("Leelawadee UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loginAsLabel.Location = new Point(122, 233);
            loginAsLabel.Name = "loginAsLabel";
            loginAsLabel.Size = new Size(125, 37);
            loginAsLabel.TabIndex = 9;
            loginAsLabel.Text = "Login As:";
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(21, 208);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.Gainsboro;
            splitContainer1.Panel1.Controls.Add(selectedRoleComboBox);
            splitContainer1.Panel1.Controls.Add(loginBtn);
            splitContainer1.Panel1.Controls.Add(loginAsLabel);
            splitContainer1.Panel1.Controls.Add(usernameLabelE);
            splitContainer1.Panel1.Controls.Add(usernameValue);
            splitContainer1.Panel1.Controls.Add(passwordValue);
            splitContainer1.Panel1.Controls.Add(passwordLabelE);
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.Gainsboro;
            splitContainer1.Panel2.Controls.Add(emailLabel);
            splitContainer1.Panel2.Controls.Add(emailValue);
            splitContainer1.Panel2.Controls.Add(viewerCheckBox);
            splitContainer1.Panel2.Controls.Add(artistCheckBox);
            splitContainer1.Panel2.Controls.Add(signupBtn);
            splitContainer1.Panel2.Controls.Add(signupAsLabel);
            splitContainer1.Panel2.Controls.Add(passwordLabelN);
            splitContainer1.Panel2.Controls.Add(passwordValueN);
            splitContainer1.Panel2.Controls.Add(usernameLabelN);
            splitContainer1.Panel2.Controls.Add(usernameValueN);
            splitContainer1.Panel2.Paint += splitContainer1_Panel2_Paint;
            splitContainer1.Size = new Size(778, 500);
            splitContainer1.SplitterDistance = 389;
            splitContainer1.TabIndex = 10;
            // 
            // selectedRoleComboBox
            // 
            selectedRoleComboBox.FormattingEnabled = true;
            selectedRoleComboBox.Items.AddRange(new object[] { "Artist", "Viewer", "Admin" });
            selectedRoleComboBox.Location = new Point(63, 290);
            selectedRoleComboBox.Name = "selectedRoleComboBox";
            selectedRoleComboBox.Size = new Size(242, 40);
            selectedRoleComboBox.TabIndex = 10;
            selectedRoleComboBox.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Font = new Font("Leelawadee UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            emailLabel.Location = new Point(143, 195);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(96, 45);
            emailLabel.TabIndex = 19;
            emailLabel.Text = "Email";
            // 
            // emailValue
            // 
            emailValue.Location = new Point(91, 243);
            emailValue.Name = "emailValue";
            emailValue.Size = new Size(200, 39);
            emailValue.TabIndex = 20;
            emailValue.TextChanged += emailValue_TextChanged;
            // 
            // viewerCheckBox
            // 
            viewerCheckBox.AutoSize = true;
            viewerCheckBox.Location = new Point(132, 379);
            viewerCheckBox.Name = "viewerCheckBox";
            viewerCheckBox.Size = new Size(118, 36);
            viewerCheckBox.TabIndex = 18;
            viewerCheckBox.Text = "Viewer";
            viewerCheckBox.UseVisualStyleBackColor = true;
            viewerCheckBox.CheckedChanged += viewerCheckBox_CheckedChanged;
            // 
            // artistCheckBox
            // 
            artistCheckBox.AutoSize = true;
            artistCheckBox.Location = new Point(141, 337);
            artistCheckBox.Name = "artistCheckBox";
            artistCheckBox.Size = new Size(101, 36);
            artistCheckBox.TabIndex = 14;
            artistCheckBox.Text = "Artist";
            artistCheckBox.UseVisualStyleBackColor = true;
            artistCheckBox.CheckedChanged += artistCheckBox_CheckedChanged;
            // 
            // signupBtn
            // 
            signupBtn.Location = new Point(116, 424);
            signupBtn.Name = "signupBtn";
            signupBtn.Size = new Size(150, 46);
            signupBtn.TabIndex = 14;
            signupBtn.Text = "Sign Up";
            signupBtn.UseVisualStyleBackColor = true;
            signupBtn.Click += signupBtn_Click;
            // 
            // signupAsLabel
            // 
            signupAsLabel.AutoSize = true;
            signupAsLabel.Font = new Font("Leelawadee UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            signupAsLabel.Location = new Point(115, 293);
            signupAsLabel.Name = "signupAsLabel";
            signupAsLabel.Size = new Size(152, 37);
            signupAsLabel.TabIndex = 17;
            signupAsLabel.Text = "Sign Up As:";
            // 
            // passwordLabelN
            // 
            passwordLabelN.AutoSize = true;
            passwordLabelN.Font = new Font("Leelawadee UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passwordLabelN.Location = new Point(114, 105);
            passwordLabelN.Name = "passwordLabelN";
            passwordLabelN.Size = new Size(154, 45);
            passwordLabelN.TabIndex = 12;
            passwordLabelN.Text = "Password";
            // 
            // passwordValueN
            // 
            passwordValueN.Location = new Point(91, 153);
            passwordValueN.Name = "passwordValueN";
            passwordValueN.Size = new Size(200, 39);
            passwordValueN.TabIndex = 13;
            passwordValueN.TextChanged += passwordValueN_TextChanged;
            // 
            // usernameLabelN
            // 
            usernameLabelN.AutoSize = true;
            usernameLabelN.Font = new Font("Leelawadee UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            usernameLabelN.Location = new Point(110, 14);
            usernameLabelN.Name = "usernameLabelN";
            usernameLabelN.Size = new Size(163, 45);
            usernameLabelN.TabIndex = 10;
            usernameLabelN.Text = "Username";
            // 
            // usernameValueN
            // 
            usernameValueN.Location = new Point(91, 62);
            usernameValueN.Name = "usernameValueN";
            usernameValueN.Size = new Size(200, 39);
            usernameValueN.TabIndex = 11;
            usernameValueN.TextChanged += usernameValueN_TextChanged;
            // 
            // subtitleLabel
            // 
            subtitleLabel.AutoSize = true;
            subtitleLabel.Font = new Font("Leelawadee UI", 11F);
            subtitleLabel.Location = new Point(21, 95);
            subtitleLabel.Name = "subtitleLabel";
            subtitleLabel.Size = new Size(310, 41);
            subtitleLabel.TabIndex = 11;
            subtitleLabel.Text = "The Portable Museum";
            // 
            // existingUsersLabel
            // 
            existingUsersLabel.AutoSize = true;
            existingUsersLabel.Font = new Font("Leelawadee UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            existingUsersLabel.Location = new Point(78, 155);
            existingUsersLabel.Name = "existingUsersLabel";
            existingUsersLabel.Size = new Size(263, 50);
            existingUsersLabel.TabIndex = 12;
            existingUsersLabel.Text = "Existing Users";
            // 
            // newUsersLabel
            // 
            newUsersLabel.AutoSize = true;
            newUsersLabel.Font = new Font("Leelawadee UI", 14F, FontStyle.Bold);
            newUsersLabel.Location = new Point(505, 154);
            newUsersLabel.Name = "newUsersLabel";
            newUsersLabel.Size = new Size(210, 51);
            newUsersLabel.TabIndex = 13;
            newUsersLabel.Text = "New Users";
            newUsersLabel.Click += newUsersLabel_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(358, 732);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(112, 62);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            pictureBox1.Visible = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(834, 819);
            Controls.Add(pictureBox1);
            Controls.Add(newUsersLabel);
            Controls.Add(existingUsersLabel);
            Controls.Add(subtitleLabel);
            Controls.Add(headerLabel);
            Controls.Add(splitContainer1);
            Name = "LoginForm";
            Text = "LoginForm";
            Load += LoginForm_Load_1;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label headerLabel;
        private Label usernameLabelE;
        private TextBox usernameValue;
        private TextBox passwordValue;
        private Label passwordLabelE;
        private Button loginBtn;
        private Label loginAsLabel;
        private SplitContainer splitContainer1;
        private Label subtitleLabel;
        private Label existingUsersLabel;
        private Label newUsersLabel;
        private CheckBox artistCheckBox;
        private Button signupBtn;
        private Label signupAsLabel;
        private Label passwordLabelN;
        private TextBox passwordValueN;
        private Label usernameLabelN;
        private TextBox usernameValueN;
        private CheckBox viewerCheckBox;
        private Label emailLabel;
        private TextBox emailValue;
        private PictureBox pictureBox1;
        private ComboBox selectedRoleComboBox;
    }
}