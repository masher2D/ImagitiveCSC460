using EmailValidation;
using ImagitiveCSC460UI.Services;
using ImagitiveCSC460UI.Session;
using ImagitiveLibrary.Core.Requests;
using ImagitiveUI.Services;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ImagitiveCSC460UI.Forms
{
    public partial class LoginForm : Form
    {
        //*************************
        // API Services Here
        //*************************

        private readonly AuthAPIService _authService = new();
        private readonly UserAPIService _userApiService = new();
        private readonly RegionAPIService _regionApiService = new();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
        }

        private void headerLabel_Click(object sender, EventArgs e)
        {
            // This method is intentionally left empty.
        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {
            // This method is intentionally left empty.
        }

        private void usernameValue_TextChanged(object sender, EventArgs e)
        {
            // This method is intentionally left empty.
        }

        private async void loginBtn_Click(object sender, EventArgs e)
        {
            StartLogin();
        }


        private void artistRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            // This method is intentionally left empty.
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
            // This method is intentionally left empty.
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            // This method is intentionally left empty.
        }

        private void newUsersLabel_Click(object sender, EventArgs e)
        {
            // This method is intentionally left empty.
        }

        private void emailValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordValueN_TextChanged(object sender, EventArgs e)
        {

        }

        private void usernameValueN_TextChanged(object sender, EventArgs e)
        {

        }

        private void artistCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void viewerCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private async void signupBtn_Click(object sender, EventArgs e)
        {
            StartSignup();
        }

        private void adminRadioBtn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoginForm_Load_1(object sender, EventArgs e)
        {

        }


        //*************************
        // Helper Functions Below
        //*************************

        private void ResetAllFields()
        {
            //Clears all fields for form reuse
            usernameValueN.Clear();
            emailValue.Clear();
            passwordValueN.Clear();
            artistCheckBox.Checked = false;
            viewerCheckBox.Checked = false;
            usernameValue.Clear();
            passwordValue.Clear();
            selectedRoleComboBox.SelectedIndex = -1;

        }

        private bool validatePassword(string dirtyText)
        {
            return Regex.IsMatch(dirtyText.Trim(), @"^[A-Za-z0-9]{8,20}$");

        }

        private string validateString(string dirtyText)
        {
            return dirtyText.Trim();

        }

        //*************************
        //   Wire Section Below
        //*************************


        private async void StartLogin()
        {
            loginBtn.Enabled = false;
            signupBtn.Enabled = false;


            try
            {
                string username = validateString(usernameValue.Text);
                string password = validateString(passwordValue.Text);
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please enter both username and password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string selectedRole = selectedRoleComboBox.SelectedItem?.ToString() ?? string.Empty;

                if (selectedRole == "")
                {
                    MessageBox.Show("Please enter a role.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                // Proceed with login logic here
                var request = new LogInRequest
                {
                    Username = username,
                    Password = password
                };

                Cursor = Cursors.WaitCursor;
                pictureBox1.Visible = true;
                var response = await _authService.LoginAsync(request);

                if (response == null || !response.Success)
                {
                    MessageBox.Show(
                        "Invalid username or password.");
                    return;
                }

                if (!response.Roles.Contains(selectedRole))
                {
                    MessageBox.Show(
                        $"Your account does not have the {selectedRole} role.");

                    return;
                }




                UserSession.UserId = response.UserId;

                UserSession.Username = response.Username;

                UserSession.JwtToken = response.Token;

                UserSession.Roles = response.Roles;

                UserSession.ActiveRole = selectedRole;

                var user = await _userApiService.GetUserByIdAsync(UserSession.UserId);

                if (user != null)
                {
                    UserSession.Email = user.Email;
                    UserSession.RegionId = user.RegionID;
                }

                var region = await _regionApiService.GetRegionByIdAsync(UserSession.RegionId ?? 0);

                if (!(region == null))
                {
                    UserSession.RegionName = region.Name;
                }



                ApiClient.SetToken(response.Token);
                ApiClient.SetActiveRole(UserSession.ActiveRole);



                MessageBox.Show($"Welcome {response.Username}!");

                MainDashboard dashboard = new MainDashboard(this);

                dashboard.Show();

                Hide();

                ResetAllFields();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
                pictureBox1.Visible = false;
                loginBtn.Enabled = true;
                signupBtn.Enabled = true;
            }
        }

        private async void StartSignup()
        {

            loginBtn.Enabled = false;
            signupBtn.Enabled = false;

            try
            {
                var roleIds = new List<int>();


                if (artistCheckBox.Checked)
                {
                    roleIds.Add(1);
                }

                if (viewerCheckBox.Checked)
                {
                    roleIds.Add(2);
                }





                if (string.IsNullOrEmpty(usernameValueN.Text) || string.IsNullOrEmpty(passwordValueN.Text) || string.IsNullOrEmpty(emailValue.Text))
                {
                    MessageBox.Show("Please enter a value for all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!artistCheckBox.Checked && !viewerCheckBox.Checked)
                {
                    MessageBox.Show("Please select a role.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string username = validateString(usernameValueN.Text);
                string password = validatePassword(passwordValueN.Text) ? validateString(passwordValueN.Text) : string.Empty;
                string email = EmailValidator.TryValidate(validateString(emailValue.Text), true, false, out var emailValidationResult) ? validateString(emailValue.Text) : string.Empty;

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Please enter valid values for all fields. Password must be 8-20 characters long and contain only letters and numbers. Email must be valid.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var request = new SignupRequest
                {
                    Username = username,

                    Email = email,

                    Password = password,

                    RoleIds = roleIds
                };

                pictureBox1.Visible = true;
                var result = await _authService.SignupAsync(request);

                if (result.User == null)
                {
                    MessageBox.Show(result.Error ?? "Failed to create account.");
                    return;
                }

                MessageBox.Show("Account created successfully.");

                usernameValue.Text = usernameValueN.Text;

                passwordValueN.Clear();

                usernameValueN.Text = "";
                emailValue.Clear();
                passwordValueN.Clear();
                passwordValue.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                pictureBox1.Visible = false;

                loginBtn.Enabled = true;
                signupBtn.Enabled = true;
            }
        }


    }
}
