using ImagitiveCSC460UI.Services;
using ImagitiveLibrary.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImagitiveCSC460UI.Forms.Components
{
    public partial class AdminDashboardInstance : UserControl
    {
        private List<ReportModel> _reports = new List<ReportModel>();
        private List<AdminRequestModel> _requests = new List<AdminRequestModel>();
        private int _currentPage = 1;
        private const int PageSize = 10;

        private string _currentFilter = string.Empty;

        private string _currentSort = string.Empty;

        private ReportAPIService _reportService = new ReportAPIService();
        private AdminRequestAPIService _adminRequestService = new AdminRequestAPIService();
        public AdminDashboardInstance()
        {
            InitializeComponent();
            adminManagementTab.SelectedIndexChanged += onTabChanged;
        }

        private void reportsListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void LoadRequests()
        {
            var response = await _adminRequestService.GetAllRequestsAsync(_currentPage, PageSize, _currentFilter, _currentSort);
            if (response != null)
            {
                _requests = response.Items;
                DisplayCurrentRequests();
            }
            else
            {
                MessageBox.Show("Failed to load requests. Try reloading the page.");
            }

        }

        private async void LoadReports()
        {
            MessageBox.Show($"Loading reports with filter: '{_currentFilter}' and sort: '{_currentSort}'");
            var response = await _reportService.GetAllReportsAsync(_currentPage, PageSize, _currentFilter, _currentSort);
            MessageBox.Show($"Response: {response?.Items.Count ?? 0} reports loaded.");
            if (response != null)
            {
                _reports = response.Items;
                DisplayCurrentReports();
            }
            else
            {
                MessageBox.Show("Failed to load reports. Try reloading the page.");
            }
        }

        private void AdminDashboardInstance_Load(object sender, EventArgs e)
        {

        }

        private void DisplayCurrentReports()
        {
            reportsListView.Items.Clear();
            reportsListView.BeginUpdate();
            foreach (var report in _reports)
            {
                if (report == null)
                {
                    MessageBox.Show("Encountered a null report while displaying reports. This should not happen.");
                    continue;
                }
                if (report.ArtworkId == null && report.ReportedUserId == null)
                {
                    MessageBox.Show($"Report {report.ReportId} has neither ArtworkId nor ReportedUserId. This should not happen.");
                    continue;
                }
                if (report.ArtworkId != null && report.ReportedUserId != null)
                {
                    MessageBox.Show($"Report {report.ReportId} has both ArtworkId and ReportedUserId. This should not happen.");
                    continue;
                }
                if (report.ReasonId == 0)
                {
                    MessageBox.Show($"Report {report.ReportId} has an invalid ReasonId of 0. This should not happen.");
                    continue;
                }
                var listViewItem = new ListViewItem(report.ReportId.ToString());
                listViewItem.SubItems.Add(report.ReasonId.ToString());
                listViewItem.SubItems.Add(report.ReportedAt.ToString("g"));
                listViewItem.SubItems.Add(report.ReportedUserId.ToString());
                listViewItem.SubItems.Add(report.ArtworkId.ToString());
                listViewItem.SubItems.Add(report.Status);

                reportsListView.Items.Add(listViewItem);
            }
            reportsListView.EndUpdate();
        }

        private void DisplayCurrentRequests()
        {
            requestsListView.Items.Clear();
            requestsListView.BeginUpdate();
            foreach (var request in _requests)
            {
                var listViewItem = new ListViewItem(request.RequestId.ToString());
                listViewItem.SubItems.Add(request.RequesterId.ToString());
                listViewItem.SubItems.Add(request.RequesteeId.ToString());
                listViewItem.SubItems.Add(request.Status);
                listViewItem.SubItems.Add(request.Description);
                listViewItem.SubItems.Add(request.RequestedAt.ToString("g"));
                listViewItem.SubItems.Add(request.ResolvedAt?.ToString("g") ?? "N/A");
                requestsListView.Items.Add(listViewItem);
            }
            requestsListView.EndUpdate();
        }

        private void adminRequestsPage_Click(object sender, EventArgs e)
        {

        }

        private void onTabChanged(object sender, EventArgs e)
        {
            _currentFilter = string.Empty;
            _currentSort = string.Empty;
            ClearFilterSortComboBoxes();
            if (adminManagementTab.SelectedTab == adminRequestsPage)
            {
                _currentPage = 1;
                LoadRequests();
            }
            else if (adminManagementTab.SelectedTab == reportsPage)
            {
                _currentPage = 1;
                LoadReports();
            }
        }

        private void reportsListView_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void filterBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentFilter = filterBox2.SelectedItem?.ToString() ?? string.Empty;
        }

        private void sortBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentSort = sortBox2.SelectedItem?.ToString() ?? string.Empty;
        }

        private void ClearFilterSortComboBoxes()
        {
            filterBox1.SelectedIndex = -1;
            sortBox1.SelectedIndex = -1;
            filterBox2.SelectedIndex = -1;
            sortBox2.SelectedIndex = -1;
        }

        public void RefreshInstance()
        {
            if (adminManagementTab.SelectedTab == adminRequestsPage)
            {
                LoadRequests();
            }
            else if (adminManagementTab.SelectedTab == reportsPage)
            {
                LoadReports();
            }
        }

        private void reportsReloadBtn_Click(object sender, EventArgs e)
        {
            LoadReports();
        }

        private void filterBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentFilter = filterBox1.SelectedItem?.ToString() ?? string.Empty;
        }

        private void sortBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentSort = sortBox1.SelectedItem?.ToString() ?? string.Empty;
        }

        private void clearFiltersBtn1_Click(object sender, EventArgs e)
        {
            _currentFilter = string.Empty;
            _currentSort = string.Empty;
            ClearFilterSortComboBoxes();
        }

        private void clearFiltersBtn2_Click(object sender, EventArgs e)
        {
            _currentFilter = string.Empty;
            _currentSort = string.Empty;
            ClearFilterSortComboBoxes();
        }

        private void addRequestBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
