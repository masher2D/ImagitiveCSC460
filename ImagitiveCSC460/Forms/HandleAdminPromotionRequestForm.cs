using ImagitiveCSC460UI.Services;
using ImagitiveLibrary.Core.Models;
using ImagitiveLibrary.Core.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImagitiveCSC460UI.Forms.Components
{
    public partial class HandleAdminPromotionRequestForm : Form
    {
        private AdminRequestModel _adminRequest;
        private readonly AdminRequestAPIService _adminRequestService = new AdminRequestAPIService();
        public HandleAdminPromotionRequestForm(AdminRequestModel adminRequest)
        {
            _adminRequest = adminRequest;
            InitializeComponent();

        }

        private void HandleAdminPromotionRequestForm_Load(object sender, EventArgs e)
        {
            reportedValue.Text = $"User ID: {_adminRequest.RequesteeId}";
            reportDescriptionValue.Text = _adminRequest.Description;

            if (_adminRequest.Status == ModerationStatuses.Resolved)
            {
                submitDecisionBtn.Enabled = false;
                userActionBox.Enabled = false;
                return;
            }

            submitDecisionBtn.Enabled = userActionBox.SelectedItem != null;
            userActionBox.SelectedIndexChanged += (_, _) =>
            {
                submitDecisionBtn.Enabled = userActionBox.SelectedItem != null;
            };
        }

        private async void submitDecisionBtn_Click(object sender, EventArgs e)
        {
            var selectedAction = userActionBox.SelectedItem?.ToString();
            if(string.IsNullOrWhiteSpace(selectedAction))
            {
                MessageBox.Show("Please select an action (Approve or Deny) before submitting.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            var response = await _adminRequestService.ResolvePromoteRequestAsync(_adminRequest.RequestId, new ImagitiveLibrary.Core.Requests.PostAdminPromoteDecisionRequest
            {
                Decision = selectedAction
            });
            if (response)
            {
                MessageBox.Show("The admin promotion request has been successfully resolved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to resolve the admin promotion request.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
