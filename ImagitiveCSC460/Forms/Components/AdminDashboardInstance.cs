using ImagitiveCSC460UI.Services;
using ImagitiveLibrary.Core.Models;
using ImagitiveLibrary.Core.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace ImagitiveCSC460UI.Forms.Components
{
    public partial class AdminDashboardInstance : UserControl
    {
        //*************************
        // Class Globals Here
        //*************************

        private List<ReportModel> _reports = new List<ReportModel>();
        private List<AdminRequestModel> _requests = new List<AdminRequestModel>();
        private int _currentPage = 1;
        private int _totalPages = 1;
        private const int PageSize = 10;

        private string _currentFilter = string.Empty;

        private string _currentSort = string.Empty;

        //*************************
        // API Services Here
        //*************************

        private readonly UserAPIService _userService = new UserAPIService();
        private readonly ReportAPIService _reportService = new ReportAPIService();
        private readonly AdminRequestAPIService _adminRequestService = new AdminRequestAPIService();
        private readonly ReasonAPIService _reasonService = new ReasonAPIService();

        public AdminDashboardInstance()
        {
            InitializeComponent();
            adminManagementTab.SelectedIndexChanged += onTabChanged;
            reportsListView.DoubleClick += onReportDoubleClick;
            requestsListView.DoubleClick += onRequestDoubleClick;
            loadGif1.Visible = false;
            loadGif2.Visible = false;
        }

        private void reportsListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        private void AdminDashboardInstance_Load(object sender, EventArgs e)
        {

        }

        private void adminRequestsPage_Click(object sender, EventArgs e)
        {

        }

        private void onTabChanged(object? sender, EventArgs e)
        {
            StartTabChangeProtocol();
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

        private void reportsReloadBtn_Click(object sender, EventArgs e)
        {
            LoadReports();
            SetPaginationControls();
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
            StartAddRequest();
        }

        private void requestsReloadBtn_Click(object sender, EventArgs e)
        {

            LoadRequests();
            SetPaginationControls();
        }

        private void requestsNextBtn_Click(object sender, EventArgs e)
        {
            StartRequestsPageForward();
        }

        private void requestsPrevBtn_Click(object sender, EventArgs e)
        {
            StartRequestsPageBack();
        }

        private void reportsNextBtn_Click(object sender, EventArgs e)
        {
            StartReportsPageForward();
        }

        private void reportsPrevBtn_Click(object sender, EventArgs e)
        {
            StartReportsPageBack();
        }

        private async void onReportDoubleClick(object? sender, EventArgs e)
        {
            StartOpenReport();
        }

        private async void onRequestDoubleClick(object? sender, EventArgs e)
        {
            StartOpenRequest();
        }

        //*************************
        // Helper Functions Here
        //*************************

        private async void DisplayCurrentReportsAsync()
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
                var reportedUser = await _userService.GetUserByIdAsync(report.ReportedUserId ?? 0);
                var reason = await _reasonService.GetReasonByIdAsync(report.ReasonId);
                listViewItem.SubItems.Add(reason?.Name ?? "N/A");
                listViewItem.SubItems.Add(report.ReportedAt.ToString("g"));
                listViewItem.SubItems.Add(reportedUser?.Username ?? "N/A");
                listViewItem.SubItems.Add(report.ArtworkId.ToString());
                listViewItem.SubItems.Add(report.Status);

                reportsListView.Items.Add(listViewItem);
            }
            reportsListView.EndUpdate();
        }

        private async void DisplayCurrentRequestsAsync()
        {
            requestsListView.Items.Clear();
            requestsListView.BeginUpdate();
            foreach (var request in _requests)
            {

                var requester = await _userService.GetUserByIdAsync(request.RequesterId);
                var requestee = await _userService.GetUserByIdAsync(request.RequesteeId);


                var listViewItem = new ListViewItem(request.RequestId.ToString());
                listViewItem.SubItems.Add(request.RequestedAt.ToString("g"));
                listViewItem.SubItems.Add(requestee?.Username ?? "N/A");
                listViewItem.SubItems.Add(requester?.Username ?? "N/A");


                requestsListView.Items.Add(listViewItem);
            }
            requestsListView.EndUpdate();
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
                SetPaginationControls();
            }
            else if (adminManagementTab.SelectedTab == reportsPage)
            {
                LoadReports();
                SetPaginationControls();
            }
        }

        private void SetPaginationControls()
        {
            if (_totalPages <= 1)
            {
                reportsPrevBtn.Enabled = false;
                reportsNextBtn.Enabled = false;
                requestsPrevBtn.Enabled = false;
                requestsNextBtn.Enabled = false;
            }
            else
            {
                reportsPrevBtn.Enabled = _currentPage > 1;
                reportsNextBtn.Enabled = _currentPage < _totalPages;
                requestsPrevBtn.Enabled = _currentPage > 1;
                requestsNextBtn.Enabled = _currentPage < _totalPages;
            }
        }

        private async void LoadRequests()
        {
            loadGif2.Visible = true;
            var response = await _adminRequestService.GetAllRequestsAsync(_currentPage, PageSize, _currentFilter, _currentSort);
            MessageBox.Show($"Response: {response?.Items?.Count ?? 0} requests loaded.");
            if (response?.Items != null)
            {
                _requests = response.Items;
                loadGif2.Visible = false;
                DisplayCurrentRequestsAsync();
            }
            else
            {
                MessageBox.Show("Failed to load requests. Try reloading the page.");
            }

        }

        private async void LoadReports()
        {
            loadGif1.Visible = true;
            var response = await _reportService.GetAllReportsAsync(_currentPage, PageSize, _currentFilter, _currentSort);
            MessageBox.Show($"Response: {response?.Items?.Count ?? 0} reports loaded.");
            if (response?.Items != null)
            {
                _reports = response.Items;
                loadGif1.Visible = false;
                DisplayCurrentReportsAsync();
            }
            else
            {
                MessageBox.Show("Failed to load reports. Try reloading the page.");
            }
        }

        //*************************
        // Wire Section Here
        //*************************

        private async void StartTabChangeProtocol()
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

        private async void StartAddRequest()
        {
            addRequestBtn.Enabled = false;
            try
            {
                using (var postAdminRequestForm = new PostAdminRequestForm())
                {
                    postAdminRequestForm.ShowDialog();
                }
            }
            finally
            {
                addRequestBtn.Enabled = true;
                RefreshInstance();

            }
        }

        private void StartRequestsPageBack()
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                LoadRequests();
                SetPaginationControls();
            }
        }

        private void StartRequestsPageForward()
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                LoadRequests();
                SetPaginationControls();
            }
        }

        private void StartReportsPageForward()
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                LoadReports();
                SetPaginationControls();
            }
        }

        private void StartReportsPageBack()
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                LoadReports();
                SetPaginationControls();
            }
        }

        private async void StartOpenRequest()
        {
            if (requestsListView.SelectedItems.Count > 0)
            {
                var selectedRequestId = int.Parse(requestsListView.SelectedItems[0].Text);
                var selectedRequest = _requests.Find(r => r.RequestId == selectedRequestId);
                if (selectedRequest != null)
                {
                    try
                    {
                        using (var requestDetailsForm = new HandleAdminPromotionRequestForm(selectedRequest))
                        {
                            requestDetailsForm.ShowDialog();
                        }
                    }
                    finally
                    {
                        LoadRequests();
                    }
                }
            }
        }

        private async void StartOpenReport()
        {
            bool success = false;
            if (reportsListView.SelectedItems.Count > 0)
            {
                var selectedReportId = int.Parse(reportsListView.SelectedItems[0].Text);
                if (selectedReportId <= 0)
                {
                    MessageBox.Show("Invalid report ID selected.");
                    return;
                }
                if (!_reports.Exists(r => r.ReportId == selectedReportId))
                {
                    MessageBox.Show("Selected report does not exist in the current list.");
                    return;
                }


                var selectedReport = _reports.Find(r => r.ReportId == selectedReportId);
                if (selectedReport == null)
                {
                    MessageBox.Show("Selected report not found.");
                    return;
                }
                if (selectedReport.Status == "Unresolved")
                {
                    await _reportService.UpdateReportStatusAsync(selectedReportId, new UpdateReportStatusRequest { NewStatus = "UnderReview" });
                }
                try
                {
                    if (selectedReport != null)
                    {
                        using (var reportDetailsForm = new HandleReportForm(selectedReport))
                        {
                            reportDetailsForm.ShowDialog();
                            success = reportDetailsForm.success;
                        }
                    }
                }
                finally
                {
                    if (!success && selectedReport != null && selectedReport.Status == "UnderReview")
                    {
                        await _reportService.UpdateReportStatusAsync(selectedReport.ReportId, new UpdateReportStatusRequest
                        {
                            NewStatus = "Unresolved"
                        });
                    }
                    LoadReports();
                }
            }
        }


    }
}
