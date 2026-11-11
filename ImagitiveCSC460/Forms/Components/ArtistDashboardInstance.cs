using ImagitiveAPI.Session;
using ImagitiveCSC460UI.Services;
using ImagitiveLibrary.Core.Models;
using System.ComponentModel;

namespace ImagitiveCSC460UI.Forms.Components
{
    public partial class ArtistDashboardInstance : UserControl
    {
        private int _currentPage = 1;
        private int _totalPages = 1;
        private const int PageSize = 15;
        private List<ArtworkModel> _artworks = new List<ArtworkModel>();


        private readonly ArtworkAPIService _artworkService = new ArtworkAPIService();
        private bool IsDesignTime => LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode || Site?.DesignMode == true;

        public ArtistDashboardInstance()
        {
            InitializeComponent();
            tabControl1.SelectedIndexChanged += TabControl_SelectedIndexChanged;
        }



        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void postNewArtworkBtn_Click(object sender, EventArgs e)
        {
            postNewArtworkBtn.Enabled = false;
            try
            {

                using (var postArtworkForm = new PostArtworkForm())
                {
                    postArtworkForm.ShowDialog();
                }

            }
            finally
            {
                postNewArtworkBtn.Enabled = true;
                RefreshInstance();



            }
        }

        private void ArtistDashboardInstance_Load(object sender, EventArgs e)
        {
            if (IsDesignTime)
            {
                return;
            }

            RefreshInstance();
        }

        private async void LoadArtworks(int page)
        {
            if (IsDesignTime)
            {
                return;
            }

            try
            {

                var response = await _artworkService.GetArtworksByUserAsync(UserSession.UserId, page, PageSize);
                if (response != null)
                {
                    _artworks = response.Items;
                    _totalPages = response.TotalPages;
                    PopulateArtistListView();
                    PopulateStatListView();
                    LoadAccountAverageRating();
                }

                else
                {
                    MessageBox.Show("Failed to load artworks. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Cannot reach the API service. Make sure the API project is running.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void artworkManagerGetPrevPageBtn_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                LoadArtworks(_currentPage);
                SetPaginationControls();
            }
        }

        private void artworkManagerGetNextPageBtn_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                LoadArtworks(_currentPage);
                SetPaginationControls();
            }
        }

        private void artworkManagerReloadBtn_Click(object sender, EventArgs e)
        {
            RefreshInstance();
        }

        private void SetPaginationControls()
        {
            if (_totalPages <= 1)
            {
                artworkManagerGetPrevPageBtn.Enabled = false;
                artworkManagerGetNextPageBtn.Enabled = false;
                statNextButton.Enabled = false;
                statsPrevButton.Enabled = false;
            }
            else
            {
                artworkManagerGetPrevPageBtn.Enabled = _currentPage > 1;
                artworkManagerGetNextPageBtn.Enabled = _currentPage < _totalPages;
                statNextButton.Enabled = _currentPage < _totalPages;
                statsPrevButton.Enabled = _currentPage > 1;
            }
        }

        private async void deleteSelectedArtworkBtn_Click(object sender, EventArgs e)
        {
            var selectedItems = listView1.SelectedItems;
            if (selectedItems.Count > 0)
            {
                var selectedArtwork = selectedItems[0].Tag as ImagitiveLibrary.Core.Models.ArtworkModel;
                if (selectedArtwork != null)
                {
                    var result = MessageBox.Show($"Are you sure you want to delete the artwork '{selectedArtwork.Title}'?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        var deleteResult = await _artworkService.RemoveArtworkAsync(selectedArtwork.ArtworkId, null);
                        if (deleteResult)
                        {
                            MessageBox.Show("Artwork deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshInstance();
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete artwork. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an artwork to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void PopulateArtistListView()
        {
            listView1.Items.Clear();

            foreach (var artwork in _artworks)
            {
                var item = new ListViewItem(
                    artwork.Title);

                item.SubItems.Add(
                    string.Join(", ", artwork.Tags));

                item.SubItems.Add(
                    artwork.UploadDate.ToShortDateString());

                item.Tag = artwork;

                listView1.Items.Add(item);
            }
        }

        private void PopulateStatListView()
        {
            statsView.Items.Clear();

            foreach (var artwork in _artworks)
            {
                var item = new ListViewItem(artwork.Title);

                item.SubItems.Add(string.Join(", ", artwork.Tags));

                item.SubItems.Add(artwork.UploadDate.ToShortDateString());

                item.Tag = artwork;

                statsView.Items.Add(item);
            }
        }

        private async void LoadAccountAverageRating()
        {
            if (IsDesignTime)
            {
                return;
            }

            try
            {
                var averageRating = await _artworkService.GetArtistAverageRatingAsync(UserSession.UserId);
                accountAvgRatingValueLabel.Text = $"{averageRating:0.00}";
            }
            catch (HttpRequestException)
            {
                accountAvgRatingValueLabel.Text = "N/A";
            }
        }

        private void statsPrevButton_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                LoadArtworks(_currentPage);
                SetPaginationControls();
            }
        }

        private void statsNextButton_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                LoadArtworks(_currentPage);
                SetPaginationControls();
            }
        }

        private void statsReloadButton_Click(object sender, EventArgs e)
        {
            RefreshInstance();
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsDesignTime)
            {
                return;
            }

            RefreshInstance();
        }

        private void statisticsPage_Click(object sender, EventArgs e)
        {

        }

        private void dailyViewsValueLabel_Click(object sender, EventArgs e)
        {

        }

        private async void statsView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsDesignTime)
            {
                return;
            }

            var selectedItems = statsView.SelectedItems;
            if (selectedItems.Count > 0)
            {
                var selectedArtwork = selectedItems[0].Tag as ImagitiveLibrary.Core.Models.ArtworkModel;
                if (selectedArtwork != null)
                {
                    avgRatingValueLabel.Text = $"{selectedArtwork.AverageRateValue:0.00}";
                    totalViewsValueLabel.Text = selectedArtwork.ViewCount.ToString();

                    try
                    {
                        dailyViewsValueLabel.Text = (await _artworkService.GetTodaysViewsAsync(selectedArtwork.ArtworkId)).ToString();
                    }
                    catch (HttpRequestException)
                    {
                        dailyViewsValueLabel.Text = "N/A";
                    }
                }
            }
        }

        private void headerLabel_Click(object sender, EventArgs e)
        {

        }

        public void RefreshInstance()
        {
            if (IsDesignTime)
            {
                return;
            }
            _currentPage = 1;
            LoadArtworks(_currentPage);
            SetPaginationControls();
        }

        /*
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var selectedArtwork = listView1.SelectedItems[0].Tag as ImagitiveLibrary.Core.Models.ArtworkModel;
                if (selectedArtwork != null)
                {
                    using (var artworkDetailsForm = new ArtworkDetailsForm(selectedArtwork))
                    {
                        artworkDetailsForm.ShowDialog();
                    }
                }
            }
        }
        */


    }
}
