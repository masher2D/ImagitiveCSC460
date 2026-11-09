using ImagitiveAPI.Session;
using ImagitiveCSC460UI.Services;
using ImagitiveLibrary.Core.Models;
using ImagitiveLibrary.Core.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImagitiveCSC460UI.Forms
{
    public partial class MainDashboard : Form
    {
        private LoginForm loginForm;
        private readonly UserAPIService _userService = new UserAPIService();
        private readonly RegionAPIService _regionService = new RegionAPIService();


        public MainDashboard(LoginForm loginForm)
        {
            InitializeComponent();
            this.loginForm = loginForm;
        }

        private void adminDashboardInstance1_Load(object sender, EventArgs e)
        {

        }

        private void adminDashboardInstance1_Load_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private async void MainDashboard_Load(object sender, EventArgs e)
        {

            ConfigureRoleAccess();
            availableRolesComboBox.Items.AddRange(UserSession.Roles.ToArray());
            await LoadRegionsAsync();
            currUsernameValue.Text = UserSession.Username;
            currRegionValue.Text = UserSession.RegionName;
            currEmailValue.Text = UserSession.Email;


        }

        private void ConfigureRoleAccess()
        {
            currRoleValue.Text = UserSession.ActiveRole;

            availableRolesComboBox.SelectedIndex = availableRolesComboBox.Items.IndexOf(UserSession.ActiveRole);

            adminDashboardInstance1.Visible = false;
            artistDashboardInstance1.Visible = false;
            viewerDashboardInstance1.Visible = false;
            // Check the user's active role and configure access accordingly
            switch (UserSession.ActiveRole)
            {
                case "Artist":
                    // Artist has access to artist-specific features
                    adminDashboardInstance1.Enabled = false;
                    viewerDashboardInstance1.Enabled = false;
                    artistDashboardInstance1.Enabled = true;

                    artistDashboardInstance1.Visible = true;
                    break;
                case "Viewer":
                    // Viewer has access to general viewing features
                    adminDashboardInstance1.Enabled = false;
                    viewerDashboardInstance1.Enabled = true;
                    artistDashboardInstance1.Enabled = false;

                    viewerDashboardInstance1.Visible = true;
                    break;
                case "Admin":
                    // Admin has access to moderation and management features
                    adminDashboardInstance1.Enabled = true;
                    viewerDashboardInstance1.Enabled = false;
                    artistDashboardInstance1.Enabled = false;

                    adminDashboardInstance1.Visible = true;
                    break;
                default:
                    // Default case, disable all features if role is unknown
                    adminDashboardInstance1.Enabled = false;
                    viewerDashboardInstance1.Enabled = false;
                    artistDashboardInstance1.Enabled = false;
                    break;
            }

        }

        private async Task LoadRegionsAsync()
        {
            var regions = await _regionService.GetRegionsAsync();
            

            if (regions == null)
            {
                MessageBox.Show("Unable to load regions.");
                return;
            }

            regionComboBox.DataSource = regions;

            regionComboBox.DisplayMember = nameof(RegionModel.Name);

            regionComboBox.ValueMember = nameof(RegionModel.RegionId);

            if (UserSession.RegionId == null)
            {
                regionComboBox.SelectedIndex = -1;
            }
            else
            {
                regionComboBox.SelectedValue = (int)UserSession.RegionId;
            }
        }

        private void currRoleValue_Click(object sender, EventArgs e)
        {

        }

        private void currRoleValue_Click_1(object sender, EventArgs e)
        {

        }

        private void availableRolesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void swapRoleBtn_Click(object sender, EventArgs e)
        {
            // Update the active role in the UserSession based on the selected role from the combo box
            UserSession.ActiveRole = availableRolesComboBox.SelectedItem.ToString();
            ConfigureRoleAccess();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {

            // Confirm logout action with the user
            DialogResult result = MessageBox.Show("Are you sure you wish to logout? You will be taken back to the login screen.", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                loginForm.Show();
                ClearSession();
                Close();
            }


        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            // Confirm quit action with the user
            DialogResult result = MessageBox.Show("Are you sure you wish to quit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


        private async void saveAndLogoutBtn_Click(object sender, EventArgs e)
        {
            using var verifyForm = new ConfirmPasswordForm();

            if (verifyForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }



            var request = new UpdateUserRequest
            {
                Username = usernameValue.Text,
                Email = emailValue.Text,
                RegionId = regionComboBox.SelectedValue as int?,
                CurrentPassword = verifyForm.ResultValue
            };

            var response = await _userService.UpdateUserAsync(request);
            if (!response)
            {
                MessageBox.Show("Failed to update user information. Please check your current password and try again.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Profile updated. You will now be logged out.");
            ClearSession();
            loginForm.Show();
            Close();
        }

        private void ClearSession()
        {
            UserSession.UserId = 0;
            UserSession.JwtToken = string.Empty;
            UserSession.Username = string.Empty;
            UserSession.Roles.Clear();
            UserSession.ActiveRole = string.Empty;
        }

        private void regionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void changeUsernameLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
