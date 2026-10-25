namespace ImagitiveCSC460UI.Forms
{
    partial class MainDashboard
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
            adminDashboardInstance1 = new ImagitiveCSC460UI.Forms.Components.AdminDashboardInstance();
            panel1 = new Panel();
            headerLabel = new Label();
            settingsTab = new TabControl();
            generalSettingsPage = new TabPage();
            comboBox1 = new ComboBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            changeEmailLabel = new Label();
            changeRegionLabel = new Label();
            changePasswordLabel = new Label();
            changeUsernameLabel = new Label();
            saveAndLogoutBtn = new Button();
            loginSettingsPage = new TabPage();
            availableRolesComboBox = new ComboBox();
            availableRolesLabel = new Label();
            currRoleValue = new Label();
            currRoleLabel = new Label();
            swapRoleBtn = new Button();
            quitBtn = new Button();
            logoutBtn = new Button();
            panel1.SuspendLayout();
            settingsTab.SuspendLayout();
            generalSettingsPage.SuspendLayout();
            loginSettingsPage.SuspendLayout();
            SuspendLayout();
            // 
            // adminDashboardInstance1
            // 
            adminDashboardInstance1.BackColor = Color.Silver;
            adminDashboardInstance1.Font = new Font("Leelawadee UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            adminDashboardInstance1.Location = new Point(12, 12);
            adminDashboardInstance1.MaximumSize = new Size(780, 899);
            adminDashboardInstance1.Name = "adminDashboardInstance1";
            adminDashboardInstance1.Size = new Size(780, 899);
            adminDashboardInstance1.TabIndex = 0;
            adminDashboardInstance1.Load += adminDashboardInstance1_Load_1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.AliceBlue;
            panel1.Controls.Add(headerLabel);
            panel1.Controls.Add(settingsTab);
            panel1.Location = new Point(798, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(664, 899);
            panel1.TabIndex = 1;
            // 
            // headerLabel
            // 
            headerLabel.Font = new Font("Leelawadee UI", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            headerLabel.Location = new Point(228, 9);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(433, 62);
            headerLabel.TabIndex = 12;
            headerLabel.Text = "Settings";
            headerLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // settingsTab
            // 
            settingsTab.Controls.Add(generalSettingsPage);
            settingsTab.Controls.Add(loginSettingsPage);
            settingsTab.Font = new Font("Leelawadee UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            settingsTab.Location = new Point(20, 74);
            settingsTab.Name = "settingsTab";
            settingsTab.SelectedIndex = 0;
            settingsTab.Size = new Size(615, 822);
            settingsTab.TabIndex = 0;
            // 
            // generalSettingsPage
            // 
            generalSettingsPage.Controls.Add(comboBox1);
            generalSettingsPage.Controls.Add(textBox3);
            generalSettingsPage.Controls.Add(textBox2);
            generalSettingsPage.Controls.Add(textBox1);
            generalSettingsPage.Controls.Add(changeEmailLabel);
            generalSettingsPage.Controls.Add(changeRegionLabel);
            generalSettingsPage.Controls.Add(changePasswordLabel);
            generalSettingsPage.Controls.Add(changeUsernameLabel);
            generalSettingsPage.Controls.Add(saveAndLogoutBtn);
            generalSettingsPage.Location = new Point(8, 46);
            generalSettingsPage.Name = "generalSettingsPage";
            generalSettingsPage.Padding = new Padding(3);
            generalSettingsPage.Size = new Size(599, 768);
            generalSettingsPage.TabIndex = 0;
            generalSettingsPage.Text = "General";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(173, 439);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(242, 40);
            comboBox1.TabIndex = 11;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(173, 592);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(242, 39);
            textBox3.TabIndex = 10;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(173, 287);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(242, 39);
            textBox2.TabIndex = 9;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(173, 135);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(242, 39);
            textBox1.TabIndex = 8;
            // 
            // changeEmailLabel
            // 
            changeEmailLabel.AutoSize = true;
            changeEmailLabel.Font = new Font("Leelawadee UI", 11F);
            changeEmailLabel.Location = new Point(192, 515);
            changeEmailLabel.Name = "changeEmailLabel";
            changeEmailLabel.Size = new Size(205, 41);
            changeEmailLabel.TabIndex = 7;
            changeEmailLabel.Text = "Change Email:";
            // 
            // changeRegionLabel
            // 
            changeRegionLabel.AutoSize = true;
            changeRegionLabel.Font = new Font("Leelawadee UI", 11F);
            changeRegionLabel.Location = new Point(180, 362);
            changeRegionLabel.Name = "changeRegionLabel";
            changeRegionLabel.Size = new Size(229, 41);
            changeRegionLabel.TabIndex = 6;
            changeRegionLabel.Text = "Change Region:";
            // 
            // changePasswordLabel
            // 
            changePasswordLabel.AutoSize = true;
            changePasswordLabel.Font = new Font("Leelawadee UI", 11F);
            changePasswordLabel.Location = new Point(164, 210);
            changePasswordLabel.Name = "changePasswordLabel";
            changePasswordLabel.Size = new Size(261, 41);
            changePasswordLabel.TabIndex = 5;
            changePasswordLabel.Text = "Change Password:";
            // 
            // changeUsernameLabel
            // 
            changeUsernameLabel.AutoSize = true;
            changeUsernameLabel.Font = new Font("Leelawadee UI", 11F);
            changeUsernameLabel.Location = new Point(160, 58);
            changeUsernameLabel.Name = "changeUsernameLabel";
            changeUsernameLabel.Size = new Size(269, 41);
            changeUsernameLabel.TabIndex = 4;
            changeUsernameLabel.Text = "Change Username:";
            // 
            // saveAndLogoutBtn
            // 
            saveAndLogoutBtn.Location = new Point(184, 680);
            saveAndLogoutBtn.Name = "saveAndLogoutBtn";
            saveAndLogoutBtn.Size = new Size(221, 46);
            saveAndLogoutBtn.TabIndex = 1;
            saveAndLogoutBtn.Text = "Save and Logout";
            saveAndLogoutBtn.UseVisualStyleBackColor = true;
            // 
            // loginSettingsPage
            // 
            loginSettingsPage.BackColor = Color.Gainsboro;
            loginSettingsPage.Controls.Add(availableRolesComboBox);
            loginSettingsPage.Controls.Add(availableRolesLabel);
            loginSettingsPage.Controls.Add(currRoleValue);
            loginSettingsPage.Controls.Add(currRoleLabel);
            loginSettingsPage.Controls.Add(swapRoleBtn);
            loginSettingsPage.Controls.Add(quitBtn);
            loginSettingsPage.Controls.Add(logoutBtn);
            loginSettingsPage.Location = new Point(8, 46);
            loginSettingsPage.Name = "loginSettingsPage";
            loginSettingsPage.Padding = new Padding(3);
            loginSettingsPage.Size = new Size(599, 768);
            loginSettingsPage.TabIndex = 2;
            loginSettingsPage.Text = "Login";
            // 
            // availableRolesComboBox
            // 
            availableRolesComboBox.FormattingEnabled = true;
            availableRolesComboBox.Location = new Point(170, 170);
            availableRolesComboBox.Name = "availableRolesComboBox";
            availableRolesComboBox.Size = new Size(242, 40);
            availableRolesComboBox.TabIndex = 6;
            // 
            // availableRolesLabel
            // 
            availableRolesLabel.AutoSize = true;
            availableRolesLabel.Font = new Font("Leelawadee UI", 11F);
            availableRolesLabel.Location = new Point(180, 113);
            availableRolesLabel.Name = "availableRolesLabel";
            availableRolesLabel.Size = new Size(223, 41);
            availableRolesLabel.TabIndex = 5;
            availableRolesLabel.Text = "Available Roles:";
            // 
            // currRoleValue
            // 
            currRoleValue.Font = new Font("Leelawadee UI", 11F);
            currRoleValue.Location = new Point(352, 25);
            currRoleValue.Name = "currRoleValue";
            currRoleValue.Size = new Size(241, 41);
            currRoleValue.TabIndex = 4;
            currRoleValue.Text = "{Insert Curr Role}";
            currRoleValue.TextAlign = ContentAlignment.TopRight;
            // 
            // currRoleLabel
            // 
            currRoleLabel.AutoSize = true;
            currRoleLabel.Font = new Font("Leelawadee UI", 11F);
            currRoleLabel.Location = new Point(15, 25);
            currRoleLabel.Name = "currRoleLabel";
            currRoleLabel.Size = new Size(191, 41);
            currRoleLabel.TabIndex = 3;
            currRoleLabel.Text = "Current Role:";
            // 
            // swapRoleBtn
            // 
            swapRoleBtn.Location = new Point(216, 236);
            swapRoleBtn.Name = "swapRoleBtn";
            swapRoleBtn.Size = new Size(150, 46);
            swapRoleBtn.TabIndex = 2;
            swapRoleBtn.Text = "Swap Role";
            swapRoleBtn.UseVisualStyleBackColor = true;
            // 
            // quitBtn
            // 
            quitBtn.Location = new Point(188, 697);
            quitBtn.Name = "quitBtn";
            quitBtn.Size = new Size(207, 46);
            quitBtn.TabIndex = 1;
            quitBtn.Text = "Quit Application";
            quitBtn.UseVisualStyleBackColor = true;
            // 
            // logoutBtn
            // 
            logoutBtn.Location = new Point(216, 645);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.Size = new Size(150, 46);
            logoutBtn.TabIndex = 0;
            logoutBtn.Text = "Logout";
            logoutBtn.UseVisualStyleBackColor = true;
            // 
            // MainDashboard
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1474, 929);
            Controls.Add(panel1);
            Controls.Add(adminDashboardInstance1);
            Name = "MainDashboard";
            Text = "MainDashboard";
            panel1.ResumeLayout(false);
            settingsTab.ResumeLayout(false);
            generalSettingsPage.ResumeLayout(false);
            generalSettingsPage.PerformLayout();
            loginSettingsPage.ResumeLayout(false);
            loginSettingsPage.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Components.AdminDashboardInstance adminDashboardInstance1;
        private Panel panel1;
        private TabControl settingsTab;
        private TabPage generalSettingsPage;
        private Label headerLabel;
        private TabPage loginSettingsPage;
        private Button logoutBtn;
        private Button quitBtn;
        private Label availableRolesLabel;
        private Label currRoleValue;
        private Label currRoleLabel;
        private Button swapRoleBtn;
        private ComboBox availableRolesComboBox;
        private Label changeEmailLabel;
        private Label changeRegionLabel;
        private Label changePasswordLabel;
        private Label changeUsernameLabel;
        private Button saveAndLogoutBtn;
        private ComboBox comboBox1;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
    }
}