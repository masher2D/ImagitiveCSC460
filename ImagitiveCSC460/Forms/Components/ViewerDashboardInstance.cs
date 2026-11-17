using ImagitiveCSC460UI.Session;
using ImagitiveCSC460UI.Forms;
using ImagitiveCSC460UI.Services;
using ImagitiveLibrary.Core.Models;
using ImagitiveLibrary.Core.Requests;
using ImagitiveUI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Text;
using System.Windows.Forms;

namespace ImagitiveCSC460UI.Forms.Components
{
    public partial class ViewerDashboardInstance : UserControl
    {
        private List<ArtworkModel> _feedArtworks = new List<ArtworkModel>();
        private int _currentArtworkIndex;
        private int _currentGlobalIndex = -1;
        private int _currentPage = 1;
        private int _totalPages = 1;
        private int _totalArtworks;
        private const int PageSize = 10;
        private string? _currentFilter = null;
        private readonly Dictionary<int, List<ArtworkModel>> _pageCache = new Dictionary<int, List<ArtworkModel>>();
        private readonly SemaphoreSlim _navigationLock = new SemaphoreSlim(1, 1);
        private bool _isNavigating;


        private ArtworkAPIService _artworkService = new ArtworkAPIService();
        private UserAPIService _userService = new UserAPIService();
        private RatingAPIService _ratingSerivce = new RatingAPIService();
        private TagAPIService _tagService = new TagAPIService();
        public ViewerDashboardInstance()
        {
            InitializeComponent();
            feedViewer.ArtworkDoubleClicked += FeedViewer_ArtworkDoubleClicked;
        }

        private void artworkTitleLabel_Click(object sender, EventArgs e)
        {
            // Add your click handling logic here, or leave empty if not needed
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void ViewerDashboardInstance_Load(object sender, EventArgs e)
        {


        }

        private async void PrepareFeed()
        {
            await InitializeFeedAsync();
        }

        private async Task InitializeFeedAsync()
        {
            _pageCache.Clear();
            _totalPages = 1;
            _totalArtworks = 0;
            _currentPage = 1;
            _feedArtworks = [];
            _currentArtworkIndex = 0;
            _currentGlobalIndex = -1;
            SetNavigationButtonsState();

            var loaded = await EnsurePageLoadedAsync(1);
            if (!loaded)
            {
                return;
            }

            if (_totalArtworks > 0)
            {
                await NavigateToGlobalIndexAsync(0);
            }
        }

        private async Task DisplayCurrentArtworkAsync()
        {
            if (_feedArtworks.Count == 0)
            {
                return;
            }
            if (_currentArtworkIndex < 0 || _currentArtworkIndex >= _feedArtworks.Count)
            {
                return;
            }

            var artwork = _feedArtworks[_currentArtworkIndex];
            _ = await _artworkService.RecordViewAsync(artwork.ArtworkId);
            var uploader = await _userService.GetUserByIdAsync(artwork.UserId);
            using var stream = await _artworkService.GetImageStreamAsync(artwork.CompressedUrl);
            if (stream == null)
            {
                return;
            }

            int fullStars = (int)Math.Floor(artwork.AverageRateValue);
            var averageRatingStars = new string('★', fullStars) + new string('☆', 5 - fullStars);
            feedViewer.SetArtworkDetails(artwork.Title, artwork.Description ?? "", Image.FromStream(stream), uploader?.Username ?? "Unknown", averageRatingStars);

            _ = PrefetchNearbyPagesAsync(_currentPage);
        }



        private async void backBtn_Click(object sender, EventArgs e)
        {
            await NavigateByAsync(-1);
        }

        private async void forwardBtn_Click(object sender, EventArgs e)
        {
            await NavigateByAsync(1);
        }

        private void SetNavigationButtonsState()
        {
            if (_isNavigating || _totalArtworks == 0 || _currentGlobalIndex < 0)
            {
                backBtn.Enabled = false;
                forwardBtn.Enabled = false;
                navLabel.Text = _isNavigating ? "Navigation (loading...)" : "Navigation (0/0)";
                return;
            }

            backBtn.Enabled = _currentGlobalIndex > 0;
            forwardBtn.Enabled = _currentGlobalIndex < _totalArtworks - 1;
            navLabel.Text = $"Navigation ({_currentGlobalIndex + 1}/{_totalArtworks})";
        }

        private async Task<bool> EnsurePageLoadedAsync(int page)
        {
            if (page < 1)
            {
                return false;
            }

            if (_pageCache.ContainsKey(page))
            {
                return true;
            }

            var pagedResponse = await _artworkService.GetFeedAsync(page, PageSize, _currentFilter);
            if (pagedResponse == null || pagedResponse.Items.Count == 0)
            {
                MessageBox.Show("No artworks available to display. Try reloading or selecting another filter.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            _totalPages = Math.Max(1, pagedResponse.TotalPages);
            _totalArtworks = pagedResponse.TotalCount;
            _pageCache[page] = pagedResponse.Items;
            return true;
        }

        private async Task<bool> NavigateToGlobalIndexAsync(int targetIndex)
        {
            if (targetIndex < 0 || targetIndex >= _totalArtworks)
            {
                return false;
            }

            var targetPage = (targetIndex / PageSize) + 1;
            var loaded = await EnsurePageLoadedAsync(targetPage);
            if (!loaded)
            {
                return false;
            }

            _currentPage = targetPage;
            _feedArtworks = _pageCache[targetPage];
            _currentArtworkIndex = targetIndex % PageSize;
            if (_currentArtworkIndex >= _feedArtworks.Count)
            {
                return false;
            }

            _currentGlobalIndex = targetIndex;
            await DisplayCurrentArtworkAsync();
            SetNavigationButtonsState();
            return true;
        }

        private async Task NavigateByAsync(int delta)
        {
            await _navigationLock.WaitAsync();
            try
            {
                if (_totalArtworks == 0 || _currentGlobalIndex < 0)
                {
                    return;
                }

                _isNavigating = true;
                SetNavigationButtonsState();

                var targetIndex = _currentGlobalIndex + delta;
                await NavigateToGlobalIndexAsync(targetIndex);
            }
            finally
            {
                _isNavigating = false;
                SetNavigationButtonsState();
                _navigationLock.Release();
            }
        }

        private async Task PrefetchNearbyPagesAsync(int currentPage)
        {
            if (currentPage < _totalPages)
            {
                await EnsurePageLoadedAsync(currentPage + 1);
            }

            if (currentPage > 1)
            {
                await EnsurePageLoadedAsync(currentPage - 1);
            }
        }

        public void RefreshInstance()
        {
            PopulateFilterBox();
            PrepareFeed();
        }



        private void starRatingBar_Scroll(object sender, EventArgs e)
        {

        }

        private async void ratingSubmitBtn_Click(object sender, EventArgs e)
        {
            if (_feedArtworks.Count <= 0)
          
            {
                MessageBox.Show("No artwork is currently selected for rating.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ratingSubmitBtn.Enabled = false;
            var currentRating = await _ratingSerivce.GetUserRatingAsync(_feedArtworks[_currentArtworkIndex].ArtworkId);
            var ratingValue = (byte)starRatingBar.Value;
            var ratingRequest = new PostRatingRequest
            {
                ArtworkId = _feedArtworks[_currentArtworkIndex].ArtworkId,
                RateValue = ratingValue
            };


            if (currentRating != null)
            {
                var response = await _ratingSerivce.UpdateRatingAsync(ratingRequest);
                if (response.Success)
                {
                    MessageBox.Show("Rating submitted successfully!");
                    var newAverageRating = response.AverageRating;
                    if (newAverageRating.HasValue)
                    {
                        _feedArtworks[_currentArtworkIndex].AverageRateValue = newAverageRating.Value;
                    }
                    await DisplayCurrentArtworkAsync();
                }
                else
                {
                    MessageBox.Show("Failed to submit rating. Please try again.");
                }
            }
            else
            {
                var response = await _ratingSerivce.PostRatingAsync(ratingRequest);
                if (response.Success)
                {
                    MessageBox.Show("Rating submitted successfully!");
                    var newAverageRating = response.AverageRating;
                    if (newAverageRating.HasValue)
                    {
                        _feedArtworks[_currentArtworkIndex].AverageRateValue = newAverageRating.Value;
                    }
                    await DisplayCurrentArtworkAsync();
                }
                else
                {
                    MessageBox.Show("Failed to submit rating. Please try again.");
                }
            }



            ratingSubmitBtn.Enabled = true;
        }

        private async void PopulateFilterBox()
        {
            var tags = await _tagService.GetAllTagsAsync();

            tagFilterBox.DataSource = tags;

            tagFilterBox.DisplayMember = "Name";

            tagFilterBox.ValueMember = "TagId";

            tagFilterBox.SelectedIndex = -1;
        }

        private void clearFiltersBtn_Click(object sender, EventArgs e)
        {
            ClearFilters();
        }

        private void tagFilterBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentFilter = tagFilterBox.SelectedItem is TagModel selectedTag ? selectedTag.Name : null;
        }

        private async void reloadBtn_Click(object sender, EventArgs e)
        {
            PrepareFeed();
        }

        public void ClearFilters()
        {
            tagFilterBox.SelectedIndex = -1;
            _currentFilter = null;
        }

        private async void FeedViewer_ArtworkDoubleClicked(object? sender, EventArgs e)
        {
            if (_feedArtworks.Count == 0 || _currentArtworkIndex < 0 || _currentArtworkIndex >= _feedArtworks.Count)
            {
                return;
            }

            var selectedArtwork = _feedArtworks[_currentArtworkIndex];

            try
            {
                using var stream = await _artworkService.GetImageStreamAsync(selectedArtwork.ImageUrl);
                if (stream == null)
                {
                    return;
                }

                using var imageBytesStream = new MemoryStream();
                await stream.CopyToAsync(imageBytesStream);
                using var fullImageForm = new FullImageForm(imageBytesStream.ToArray(), selectedArtwork.Title);
                fullImageForm.ShowDialog(FindForm());
            }
            catch
            {
                return;
            }
        }

        private async void downloadBtn_Click(object sender, EventArgs e)
        {
            if (_feedArtworks.Count <= 0)

            {
                MessageBox.Show("No artwork is currently selected for download.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            downloadBtn.Enabled = false;
            try
            {
                await DownloadWatermarkedArtwork();
            }
            finally
            {
                downloadBtn.Enabled = true;
            }
        }

        private async Task DownloadWatermarkedArtwork()
        {
            if (_feedArtworks.Count == 0 || _currentArtworkIndex < 0 || _currentArtworkIndex >= _feedArtworks.Count)
            {
                return;
            }

            var selectedArtwork = _feedArtworks[_currentArtworkIndex];
            var extension = Path.GetExtension(selectedArtwork.WatermarkedUrl);
            if (string.IsNullOrWhiteSpace(extension))
            {
                extension = ".jpg";
            }

            var safeTitle = string.IsNullOrWhiteSpace(selectedArtwork.Title)
                ? $"artwork_{selectedArtwork.ArtworkId}"
                : string.Concat(selectedArtwork.Title.Split(Path.GetInvalidFileNameChars())).Trim();

            using var saveFileDialog = new SaveFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                Title = "Save Watermarked Artwork",
                FileName = $"{safeTitle}_watermarked{extension}",
                DefaultExt = extension.TrimStart('.')
            };

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            using var stream = await _artworkService.GetImageStreamAsync(selectedArtwork.WatermarkedUrl);
            if (stream == null)
            {
                MessageBox.Show("Failed to download the watermarked image.");
                return;
            }

            using var fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
            await stream.CopyToAsync(fileStream);
        }

        private void ratingLabel_Click(object sender, EventArgs e)
        {

        }

        private void reportBtn_Click(object sender, EventArgs e)
        {
            if (_feedArtworks.Count <= 0)

            {
                MessageBox.Show("No artwork is currently selected for reporting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            reportBtn.Enabled = false;
            try
            {
                if (_currentArtworkIndex < 0 || _currentArtworkIndex >= _feedArtworks.Count)
                {
                    return;
                }
                var selectedArtwork = _feedArtworks[_currentArtworkIndex];
                using var reportForm = new PostArtworkReportForm(selectedArtwork);
                reportForm.ShowDialog(FindForm());

            }
            finally
            {
                reportBtn.Enabled = true;
            }
        }
    }
}
