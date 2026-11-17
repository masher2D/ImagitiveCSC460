using ImagitiveCSC460UI.Services;
using ImagitiveLibrary.Core.Constants;
using ImagitiveLibrary.Core.Models;
using ImagitiveLibrary.Core.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImagitiveCSC460UI.Forms.Components
{
    public partial class HandleReportForm : Form
    {
        private ReportModel _report;

        private UserAPIService _userService = new UserAPIService();
        private ArtworkAPIService _artworkService = new ArtworkAPIService();
        private ReasonAPIService _reasonService = new ReasonAPIService();
        private ReportAPIService _reportService = new ReportAPIService();

        public bool success { get; private set; }
        public HandleReportForm(ReportModel model)
        {
            _report = model;
            InitializeComponent();
            if (_report.Status == "Discarded" || _report.Status == "Resolved")
            {
                submitDecisionBtn.Enabled = false;
                userActionBox.Enabled = false;
                restrictUntilDatePicker.Enabled = false;

                judgementLabel.Visible = false;
                restrictUntilLabel.Visible = false;
                submitDecisionBtn.Visible = false;
                userActionBox.Visible = false;
                restrictUntilDatePicker.Visible = false;

                resolverLabel.Visible = true;
                decisionLabel.Visible = true;
                resolverValue.Visible = true;
                decisionValue.Visible = true;


            }
            else
            {
                submitDecisionBtn.Enabled = true;
                userActionBox.Enabled = true;
                restrictUntilDatePicker.Enabled = true;

                judgementLabel.Visible = true;
                restrictUntilLabel.Visible = true;
                submitDecisionBtn.Visible = true;
                userActionBox.Visible = true;
                restrictUntilDatePicker.Visible = true;
                resolverLabel.Visible = false;
                decisionLabel.Visible = false;
                resolverValue.Visible = false;
                decisionValue.Visible = false;
            }

        }

        private void reportedLabel_Click(object sender, EventArgs e)
        {

        }

        private async void HandleReportForm_Load(object sender, EventArgs e)
        {
            success = false;
            if ((_report.ArtworkId.HasValue && _report.ReportedUserId.HasValue) || (!_report.ArtworkId.HasValue && !_report.ReportedUserId.HasValue))
            {
                MessageBox.Show("Illegimate Report was loaded. It will be discarded.", "Illegal Report Found");
                await _reportService.UpdateReportStatusAsync(_report.ReportId, new UpdateReportStatusRequest { NewStatus = ModerationStatuses.Discarded });
                Close();
            }

            if (_report.ArtworkId.HasValue)
            {
                var artwork = await _artworkService.GetArtworkByIdAsync(_report.ArtworkId.Value);
                if (artwork != null)
                {
                    reportedValue.Text = $"{artwork.Title}, ID: {artwork.ArtworkId}";
                }
            }
            else if (_report.ReportedUserId.HasValue)
            {
                var user = await _userService.GetUserByIdAsync(_report.ReportedUserId.Value);
                if (user != null)
                {
                    reportedValue.Text = $"{user.Username}, ID: {user.UserId}";
                }
            }


            var reporter = await _userService.GetUserByIdAsync(_report.ReporterId);
            if (reporter != null)
            {
                reporterLabel.Text = $"Reported by:\n{reporter.Username}, ID: {reporter.UserId}";
            }

            

            string? reasonName = (await _reasonService.GetReasonByIdAsync(_report.ReasonId))?.Name;
            if (string.IsNullOrEmpty(reasonName))
            {
                reasonName = "Unknown Reason";
            }
            reportReasonNameValue.Text = reasonName;
            reportDescriptionValue.Text = _report.Description;

            if(_report.Status == "Resolved")
            {
                if(_report.ResolvedBy == null)
                {
                    resolverValue.Text = "Unknown";
                }
                else
                {
                    var resolver = await _userService.GetUserByIdAsync(_report.ResolvedBy.Value);
                    if (resolver != null)
                    {
                        resolverValue.Text = $"{resolver.Username}, ID: {resolver.UserId}";
                    }
                }
                decisionValue.Text = _report.ActionTaken;
            } else if(_report.Status == "Discarded")
            {
                resolverValue.Text = "N/A";
                decisionValue.Text = "Report Discarded";
            }
        }

        private async void submitDecisionBtn_ClickAsync(object sender, EventArgs e)
        {
            if(userActionBox.SelectedItem == null)
            {
                MessageBox.Show("Please select an action to take.");
                return;
            }
            string? selectedAction = userActionBox.SelectedItem.ToString();
            if(selectedAction == null)
            {
                MessageBox.Show("Please select an action to take.");
                return;
            }
            if(selectedAction == ReportResponseChoices.Restrict)
            {
                if (restrictUntilDatePicker.Value <= DateTime.Now)
                {
                    MessageBox.Show("Please select a valid restriction date.");
                    return;
                }
                if(restrictUntilDatePicker.Value > DateTime.Now.AddYears(1))
                {
                    MessageBox.Show("Please select a restriction date within 1 year.");
                    return;
                }
            }

            var response = await _reportService.ResolveReportAsync(_report.ReportId, new ImagitiveLibrary.Core.Requests.PostAdminReportDecisionRequest
            {
                Decision = selectedAction,
                RestrictedUntil = selectedAction == ReportResponseChoices.Restrict ? restrictUntilDatePicker.Value : (DateTime?)null
            });
            if (response)
            {
                MessageBox.Show("The report has been successfully resolved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                success = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to resolve the report.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
