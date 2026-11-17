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

namespace ImagitiveCSC460UI.Forms.Components
{
    public partial class PostArtworkReportForm : Form
    {
        private ArtworkModel _artwork;
        private ReasonAPIService _reasonService = new ReasonAPIService();
        private ReportAPIService _reportService = new ReportAPIService();
        public PostArtworkReportForm(ArtworkModel artwork)
        {
            _artwork = artwork;
            InitializeComponent();
            reportedLabel.Text = $"You are reporting: {_artwork.Title}";
        }

        private async void PostArtworkReportForm_Load(object sender, EventArgs e)
        {
            var reasons = await _reasonService.GetAllReasonsAsync();
            reportReasonsBox.DataSource = reasons;
            reportReasonsBox.DisplayMember = "Name";
            reportReasonsBox.ValueMember = "ReasonId";
        }

        private async void postReportBtn_Click(object sender, EventArgs e)
        {
            if(reportReasonsBox.SelectedValue == null || string.IsNullOrWhiteSpace(reportDescriptionValue.Text.Trim()))
            {
                MessageBox.Show("Please provide a reason and a description for the report.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var response = await _reportService.CreateReportAsync(new PostReportRequest
            {
                ArtworkId = _artwork.ArtworkId,
                ReasonId = (int)reportReasonsBox.SelectedValue,
                Description = reportDescriptionValue.Text.Trim()
            });

            if(response != null)
            {
                MessageBox.Show("Report submitted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to submit the report. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
