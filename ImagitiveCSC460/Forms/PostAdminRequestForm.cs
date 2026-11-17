using ImagitiveCSC460UI.Services;
using ImagitiveLibrary.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.WebSockets;
using System.Text;
using System.Windows.Forms;

namespace ImagitiveCSC460UI.Forms
{
    public partial class PostAdminRequestForm : Form
    {
        private readonly AdminRequestAPIService _adminRequestService = new AdminRequestAPIService();
        private readonly UserAPIService _userService = new UserAPIService();
        public PostAdminRequestForm()
        {
            InitializeComponent();
        }

        private void PostAdminRequestForm_Load(object sender, EventArgs e)
        {

        }

        private async void postRequestBtn_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(descriptionValue.Text) || string.IsNullOrWhiteSpace(usernameValue.Text))
            {
                MessageBox.Show("Please enter a title and description for the request.");
                return;
            }

            string usernameInput = validateString(usernameValue.Text);
            UserModel? user = await _userService.GetUserByUsername(usernameInput);
            if (user == null)
            {
                MessageBox.Show("User not found. Please enter a valid username.");
                return;
            }

            var request = new ImagitiveLibrary.Core.Requests.PostAdminPromoteCreateRequest
            {
                Description = validateString(descriptionValue.Text),
                RequesteeId = user.UserId    
            };

            var response = await _adminRequestService.CreateRequestAsync(request);
            if(response == null)
            {
                MessageBox.Show("Request failed! Please try again.");
            }
            else
            {
                MessageBox.Show("Request was made successfully!");
                Close();
            }
        }

        private string validateString(string dirtyText)
        {
            string cleanText = dirtyText.Trim();
            return cleanText;
        }   
    }
}
