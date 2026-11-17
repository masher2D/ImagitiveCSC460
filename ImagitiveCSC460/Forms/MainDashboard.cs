using ImagitiveCSC460UI.Session;
using ImagitiveCSC460UI.Services;
using ImagitiveLibrary.Core.Models;
using ImagitiveLibrary.Core.Requests;
using ImagitiveUI.Services;
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

        //*************************
        // API Services Here
        //*************************

        private readonly UserAPIService _userService = new UserAPIService();
        private readonly RegionAPIService _regionService = new RegionAPIService();

        private bool isLoggingOut = false;
        private bool isIgnoringCloseEvent = false;


        public MainDashboard(LoginForm loginForm)
        {
            InitializeComponent();
            this.loginForm = loginForm;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private async void MainDashboard_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            isLoggingOut = false;
            ConfigureRoleAccess();
            availableRolesComboBox.Items.AddRange(UserSession.Roles.ToArray());
            await LoadRegionsAsync();
            currUsernameValue.Text = UserSession.Username;
            currRegionValue.Text = UserSession.RegionName;
            currEmailValue.Text = UserSession.Email;



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
            StartSwapRole();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {

            // Confirm logout action with the user
            isLoggingOut = true;
            ClearSession();
            Close();

        }

        private void quitBtn_Click(object sender, EventArgs e)
        {

            Application.Exit();

        }


        private async void saveAndLogoutBtn_Click(object sender, EventArgs e)
        {
            StartSaveAndLogout();
        }



        private void regionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void changeUsernameLabel_Click(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!isIgnoringCloseEvent)
            {
                DialogResult result = MessageBox.Show("Are you sure you wish to quit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Cancel the closing event
                    return;
                }
            }
            // Confirm exit action with the user

            if (isLoggingOut)
            {
                loginForm.Show();
            }

            base.OnFormClosing(e);
        }

        private void viewerDashboardInstance1_Load(object sender, EventArgs e)
        {

        }

        private async void addRoleBtn_Click(object sender, EventArgs e)
        {
            StartAddRole();
        }

        //*************************
        // Helper Functions Below
        //*************************

        private void ConfigureRoleAccess()
        {
            ApiClient.SetActiveRole(UserSession.ActiveRole);

            currRoleValue.Text = UserSession.ActiveRole;

            availableRolesComboBox.SelectedIndex = availableRolesComboBox.Items.IndexOf(UserSession.ActiveRole);

            adminDashboardInstance1.Visible = false;
            artistDashboardInstance1.Visible = false;
            viewerDashboardInstance1.Visible = false;

            viewerDashboardInstance1.ClearFilters();
            // Check the user's active role and configure access accordingly
            switch (UserSession.ActiveRole)
            {
                case "Artist":
                    // Artist has access to artist-specific features
                    adminDashboardInstance1.Enabled = false;
                    viewerDashboardInstance1.Enabled = false;
                    artistDashboardInstance1.Enabled = true;

                    artistDashboardInstance1.Visible = true;
                    artistDashboardInstance1.RefreshInstance();
                    break;
                case "Viewer":
                    // Viewer has access to general viewing features
                    adminDashboardInstance1.Enabled = false;
                    viewerDashboardInstance1.Enabled = true;
                    artistDashboardInstance1.Enabled = false;

                    viewerDashboardInstance1.Visible = true;
                    viewerDashboardInstance1.RefreshInstance();
                    break;
                case "Admin":
                    // Admin has access to moderation and management features
                    adminDashboardInstance1.Enabled = true;
                    viewerDashboardInstance1.Enabled = false;
                    artistDashboardInstance1.Enabled = false;

                    adminDashboardInstance1.Visible = true;
                    adminDashboardInstance1.RefreshInstance();
                    break;
                default:
                    // Default case, disable all features if role is unknown
                    adminDashboardInstance1.Enabled = false;
                    viewerDashboardInstance1.Enabled = false;
                    artistDashboardInstance1.Enabled = false;
                    MessageBox.Show("Unknown role. I suggest logging out and selecting a valid role. If this issue persists, contact support.", "Role Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void ClearSession()
        {
            UserSession.UserId = 0;
            UserSession.JwtToken = string.Empty;
            UserSession.Username = string.Empty;
            UserSession.Roles.Clear();
            UserSession.ActiveRole = string.Empty;
            ApiClient.ClearAuthContext();
        }



        //*************************
        // Wire Section Here
        //*************************

        private async void StartAddRole()
        {
            if (string.IsNullOrEmpty(possibleRoleBox.Text))
            {
                MessageBox.Show("Please enter a role to add.");
                return;
            }
            if (UserSession.Roles.Contains(possibleRoleBox.Text))
            {
                MessageBox.Show("You already have this role.");
                return;
            }
            var confirmResult = MessageBox.Show($"Are you sure you want to add the role '{possibleRoleBox.Text}'? Roles added cannot be removed.", "Confirm Role Addition", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult != DialogResult.Yes)
            {
                return;
            }
            var result = await _userService.AddUserRole(possibleRoleBox.Text);
            if (result)
            {
                UserSession.Roles.Add(possibleRoleBox.Text);
                MessageBox.Show("Role added successfully.");
                availableRolesComboBox.Items.Clear();
                availableRolesComboBox.Items.AddRange(UserSession.Roles.ToArray());

            }
            else
            {
                MessageBox.Show("Failed to add role.");
            }
        }

        private async void StartSwapRole()
        {
            string? selectedRole = availableRolesComboBox.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedRole) || selectedRole == UserSession.ActiveRole)
            {
                MessageBox.Show("Please select a different role to switch to.");
                return;
            }
            // Update the active role in the UserSession based on the selected role from the combo box
            UserSession.ActiveRole = selectedRole;
            ApiClient.SetActiveRole(UserSession.ActiveRole);
            ConfigureRoleAccess();
        }

        private async void StartSaveAndLogout()
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
            isIgnoringCloseEvent = true;
            isLoggingOut = true;
            Close();
        }

    }
}
