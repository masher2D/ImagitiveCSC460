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
    public partial class ConfirmPasswordForm : Form
    {
        public string ResultValue { get; private set; } = string.Empty;
        private AuthAPIService _authService = new AuthAPIService();
        public ConfirmPasswordForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            
            string password = validateString(passwordValue.Text);
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter your password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var result = MessageBox.Show("Are you sure you want to proceed?", "Confirm Action", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                ResultValue = password;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private string validateString(string dirtyText)
        {
            return dirtyText?.Trim();

        }
    }
}
