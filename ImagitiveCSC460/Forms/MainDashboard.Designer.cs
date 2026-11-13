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
            currEmailValue = new Label();
            currRegionValue = new Label();
            currUsernameValue = new Label();
            currEmailLabel = new Label();
            currRegionLabel = new Label();
            currUsernameLabel = new Label();
            accountSettingsPage = new TabPage();
            regionComboBox = new ComboBox();
            emailValue = new TextBox();
            usernameValue = new TextBox();
            changeEmailLabel = new Label();
            changeRegionLabel = new Label();
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
            artistDashboardInstance1 = new ImagitiveCSC460UI.Forms.Components.ArtistDashboardInstance();
            viewerDashboardInstance1 = new ImagitiveCSC460UI.Forms.Components.ViewerDashboardInstance();
            panel1.SuspendLayout();
            settingsTab.SuspendLayout();
            generalSettingsPage.SuspendLayout();
            accountSettingsPage.SuspendLayout();
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
            adminDashboardInstance1.Visible = false;
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
            settingsTab.Controls.Add(accountSettingsPage);
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
            generalSettingsPage.Controls.Add(currEmailValue);
            generalSettingsPage.Controls.Add(currRegionValue);
            generalSettingsPage.Controls.Add(currUsernameValue);
            generalSettingsPage.Controls.Add(currEmailLabel);
            generalSettingsPage.Controls.Add(currRegionLabel);
            generalSettingsPage.Controls.Add(currUsernameLabel);
            generalSettingsPage.Location = new Point(8, 46);
            generalSettingsPage.Name = "generalSettingsPage";
            generalSettingsPage.Padding = new Padding(3);
            generalSettingsPage.Size = new Size(599, 768);
            generalSettingsPage.TabIndex = 3;
            generalSettingsPage.Text = "General";
            generalSettingsPage.UseVisualStyleBackColor = true;
            // 
            // currEmailValue
            // 
            currEmailValue.Font = new Font("Leelawadee UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            currEmailValue.Location = new Point(15, 442);
            currEmailValue.Name = "currEmailValue";
            currEmailValue.Size = new Size(565, 45);
            currEmailValue.TabIndex = 20;
            currEmailValue.Text = "{Insert Email}";
            currEmailValue.TextAlign = ContentAlignment.TopCenter;
            // 
            // currRegionValue
            // 
            currRegionValue.Font = new Font("Leelawadee UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            currRegionValue.Location = new Point(15, 258);
            currRegionValue.Name = "currRegionValue";
            currRegionValue.Size = new Size(565, 45);
            currRegionValue.TabIndex = 19;
            currRegionValue.Text = "{Insert Region}";
            currRegionValue.TextAlign = ContentAlignment.TopCenter;
            // 
            // currUsernameValue
            // 
            currUsernameValue.Font = new Font("Leelawadee UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            currUsernameValue.Location = new Point(15, 74);
            currUsernameValue.Name = "currUsernameValue";
            currUsernameValue.Size = new Size(565, 45);
            currUsernameValue.TabIndex = 18;
            currUsernameValue.Text = "{Insert Username}";
            currUsernameValue.TextAlign = ContentAlignment.TopCenter;
            // 
            // currEmailLabel
            // 
            currEmailLabel.AutoSize = true;
            currEmailLabel.Font = new Font("Leelawadee UI", 11F);
            currEmailLabel.Location = new Point(200, 401);
            currEmailLabel.Name = "currEmailLabel";
            currEmailLabel.Size = new Size(195, 41);
            currEmailLabel.TabIndex = 17;
            currEmailLabel.Text = "Current Email";
            // 
            // currRegionLabel
            // 
            currRegionLabel.AutoSize = true;
            currRegionLabel.Font = new Font("Leelawadee UI", 11F);
            currRegionLabel.Location = new Point(188, 217);
            currRegionLabel.Name = "currRegionLabel";
            currRegionLabel.Size = new Size(219, 41);
            currRegionLabel.TabIndex = 16;
            currRegionLabel.Text = "Current Region";
            // 
            // currUsernameLabel
            // 
            currUsernameLabel.AutoSize = true;
            currUsernameLabel.Font = new Font("Leelawadee UI", 11F);
            currUsernameLabel.Location = new Point(168, 33);
            currUsernameLabel.Name = "currUsernameLabel";
            currUsernameLabel.Size = new Size(259, 41);
            currUsernameLabel.TabIndex = 15;
            currUsernameLabel.Text = "Current Username";
            // 
            // accountSettingsPage
            // 
            accountSettingsPage.Controls.Add(regionComboBox);
            accountSettingsPage.Controls.Add(emailValue);
            accountSettingsPage.Controls.Add(usernameValue);
            accountSettingsPage.Controls.Add(changeEmailLabel);
            accountSettingsPage.Controls.Add(changeRegionLabel);
            accountSettingsPage.Controls.Add(changeUsernameLabel);
            accountSettingsPage.Controls.Add(saveAndLogoutBtn);
            accountSettingsPage.Location = new Point(8, 46);
            accountSettingsPage.Name = "accountSettingsPage";
            accountSettingsPage.Padding = new Padding(3);
            accountSettingsPage.Size = new Size(599, 768);
            accountSettingsPage.TabIndex = 0;
            accountSettingsPage.Text = "Account";
            // 
            // regionComboBox
            // 
            regionComboBox.FormattingEnabled = true;
            regionComboBox.Location = new Point(169, 374);
            regionComboBox.Name = "regionComboBox";
            regionComboBox.Size = new Size(242, 40);
            regionComboBox.TabIndex = 11;
            regionComboBox.SelectedIndexChanged += regionComboBox_SelectedIndexChanged;
            // 
            // emailValue
            // 
            emailValue.Location = new Point(169, 591);
            emailValue.Name = "emailValue";
            emailValue.Size = new Size(242, 39);
            emailValue.TabIndex = 10;
            // 
            // usernameValue
            // 
            usernameValue.Location = new Point(169, 158);
            usernameValue.Name = "usernameValue";
            usernameValue.Size = new Size(242, 39);
            usernameValue.TabIndex = 8;
            // 
            // changeEmailLabel
            // 
            changeEmailLabel.AutoSize = true;
            changeEmailLabel.Font = new Font("Leelawadee UI", 11F);
            changeEmailLabel.Location = new Point(188, 482);
            changeEmailLabel.Name = "changeEmailLabel";
            changeEmailLabel.Size = new Size(205, 41);
            changeEmailLabel.TabIndex = 7;
            changeEmailLabel.Text = "Change Email:";
            // 
            // changeRegionLabel
            // 
            changeRegionLabel.AutoSize = true;
            changeRegionLabel.Font = new Font("Leelawadee UI", 11F);
            changeRegionLabel.Location = new Point(176, 265);
            changeRegionLabel.Name = "changeRegionLabel";
            changeRegionLabel.Size = new Size(229, 41);
            changeRegionLabel.TabIndex = 6;
            changeRegionLabel.Text = "Change Region:";
            // 
            // changeUsernameLabel
            // 
            changeUsernameLabel.AutoSize = true;
            changeUsernameLabel.Font = new Font("Leelawadee UI", 11F);
            changeUsernameLabel.Location = new Point(156, 49);
            changeUsernameLabel.Name = "changeUsernameLabel";
            changeUsernameLabel.Size = new Size(269, 41);
            changeUsernameLabel.TabIndex = 4;
            changeUsernameLabel.Text = "Change Username:";
            changeUsernameLabel.Click += changeUsernameLabel_Click;
            // 
            // saveAndLogoutBtn
            // 
            saveAndLogoutBtn.Location = new Point(180, 698);
            saveAndLogoutBtn.Name = "saveAndLogoutBtn";
            saveAndLogoutBtn.Size = new Size(221, 46);
            saveAndLogoutBtn.TabIndex = 1;
            saveAndLogoutBtn.Text = "Save and Logout";
            saveAndLogoutBtn.UseVisualStyleBackColor = true;
            saveAndLogoutBtn.Click += saveAndLogoutBtn_Click;
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
            availableRolesComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            availableRolesComboBox.FormattingEnabled = true;
            availableRolesComboBox.Location = new Point(170, 170);
            availableRolesComboBox.Name = "availableRolesComboBox";
            availableRolesComboBox.Size = new Size(242, 40);
            availableRolesComboBox.TabIndex = 6;
            availableRolesComboBox.SelectedIndexChanged += availableRolesComboBox_SelectedIndexChanged;
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
            currRoleValue.Click += currRoleValue_Click_1;
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
            swapRoleBtn.Click += swapRoleBtn_Click;
            // 
            // quitBtn
            // 
            quitBtn.Location = new Point(188, 697);
            quitBtn.Name = "quitBtn";
            quitBtn.Size = new Size(207, 46);
            quitBtn.TabIndex = 1;
            quitBtn.Text = "Quit Application";
            quitBtn.UseVisualStyleBackColor = true;
            quitBtn.Click += quitBtn_Click;
            // 
            // logoutBtn
            // 
            logoutBtn.Location = new Point(216, 645);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.Size = new Size(150, 46);
            logoutBtn.TabIndex = 0;
            logoutBtn.Text = "Logout";
            logoutBtn.UseVisualStyleBackColor = true;
            logoutBtn.Click += logoutBtn_Click;
            // 
            // artistDashboardInstance1
            // 
            artistDashboardInstance1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            artistDashboardInstance1.BackColor = Color.LightGray;
            artistDashboardInstance1.Location = new Point(12, 12);
            artistDashboardInstance1.MaximumSize = new Size(780, 899);
            artistDashboardInstance1.Name = "artistDashboardInstance1";
            artistDashboardInstance1.Size = new Size(780, 899);
            artistDashboardInstance1.TabIndex = 2;
            artistDashboardInstance1.Visible = false;
            // 
            // viewerDashboardInstance1
            // 
            viewerDashboardInstance1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            viewerDashboardInstance1.BackColor = Color.Silver;
            viewerDashboardInstance1.Location = new Point(12, 12);
            viewerDashboardInstance1.MaximumSize = new Size(780, 899);
            viewerDashboardInstance1.Name = "viewerDashboardInstance1";
            viewerDashboardInstance1.Size = new Size(780, 899);
            viewerDashboardInstance1.TabIndex = 3;
            viewerDashboardInstance1.Visible = false;
            viewerDashboardInstance1.Load += viewerDashboardInstance1_Load;
            // 
            // MainDashboard
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1474, 929);
            Controls.Add(viewerDashboardInstance1);
            Controls.Add(adminDashboardInstance1);
            Controls.Add(artistDashboardInstance1);
            Controls.Add(panel1);
            Name = "MainDashboard";
            Text = "MainDashboard";
            Load += MainDashboard_Load;
            panel1.ResumeLayout(false);
            settingsTab.ResumeLayout(false);
            generalSettingsPage.ResumeLayout(false);
            generalSettingsPage.PerformLayout();
            accountSettingsPage.ResumeLayout(false);
            accountSettingsPage.PerformLayout();
            loginSettingsPage.ResumeLayout(false);
            loginSettingsPage.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Components.AdminDashboardInstance adminDashboardInstance1;
        private Panel panel1;
        private TabControl settingsTab;
        private TabPage accountSettingsPage;
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
        private Label changeUsernameLabel;
        private Button saveAndLogoutBtn;
        private ComboBox regionComboBox;
        private TextBox emailValue;
        private TextBox usernameValue;
        private Components.ArtistDashboardInstance artistDashboardInstance1;
        private Components.ViewerDashboardInstance viewerDashboardInstance1;
        private TabPage generalSettingsPage;
        private Label currEmailValue;
        private Label currRegionValue;
        private Label currUsernameValue;
        private Label currEmailLabel;
        private Label currRegionLabel;
        private Label currUsernameLabel;
    }
}