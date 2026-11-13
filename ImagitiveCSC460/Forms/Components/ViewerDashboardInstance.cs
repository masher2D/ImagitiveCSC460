using ImagitiveAPI.Session;
using ImagitiveCSC460UI.Services;
using ImagitiveLibrary.Core.Models;
using ImagitiveLibrary.Core.Requests;
using ImagitiveUI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImagitiveCSC460UI.Forms.Components
{
    public partial class ViewerDashboardInstance : UserControl
    {
        private List<ArtworkModel> _feedArtworks = new List<ArtworkModel>();
        private int _currentArtworkIndex;
        private int _currentPage = 1;
        private const int PageSize = 10;

        private ArtworkAPIService _artworkService = new ArtworkAPIService();
        private UserAPIService _userService = new UserAPIService();
        private RatingAPIService _ratingSerivce = new RatingAPIService();
        public ViewerDashboardInstance()
        {
            InitializeComponent();
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
            GetFeedPage();
        }

        private void LoadFeedArtworks(List<ArtworkModel> artworks)
        {
            _feedArtworks = artworks;
            _currentArtworkIndex = 0;
            DisplayCurrentArtwork();
        }

        private async void DisplayCurrentArtwork()
        {
            if (_feedArtworks.Count == 0) return;
            if (_currentArtworkIndex < 0 || _currentArtworkIndex >= _feedArtworks.Count)
            {
                MessageBox.Show("No more artworks to display.");
                return;
            }
            var artwork = _feedArtworks[_currentArtworkIndex];
            MessageBox.Show($"Displaying artwork: {artwork.Title} by User ID: {artwork.UserId}");
            var uploader = await _userService.GetUserByIdAsync(artwork.UserId);
            using var stream = await ApiClient.Client.GetStreamAsync(artwork.ImageUrl);
            int fullStars = (int)Math.Floor(artwork.AverageRateValue);
            var averageRatingStars = new string('★', fullStars) + new string('☆', 5 - fullStars);
            feedViewer.SetArtworkDetails(artwork.Title, artwork.Description ?? "", Image.FromStream(stream), uploader.Username ?? "Unknown", averageRatingStars);

        }



        private void backBtn_Click(object sender, EventArgs e)
        {
            _currentArtworkIndex--;
            DisplayCurrentArtwork();
            SetNavigationButtonsState();
        }

        private void forwardBtn_Click(object sender, EventArgs e)
        {
            _currentArtworkIndex++;
            DisplayCurrentArtwork();
            SetNavigationButtonsState();
        }

        private void SetNavigationButtonsState()
        {
            backBtn.Enabled = _currentArtworkIndex > 0;
            forwardBtn.Enabled = _currentArtworkIndex < _feedArtworks.Count - 1;
        }

        private async void GetFeedPage()
        {
            _feedArtworks = await _artworkService.GetFeedAsync(UserSession.UserId, _currentPage, PageSize);
            if (_feedArtworks == null || _feedArtworks.Count == 0)
            {
                MessageBox.Show("No artworks available in the feed.");
                return;
            }
            LoadFeedArtworks(_feedArtworks);
        }

        public void RefreshInstance()
        {
            _currentPage = 1;
            PrepareFeed();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void starRatingBar_Scroll(object sender, EventArgs e)
        {

        }

        private async void ratingSubmitBtn_Click(object sender, EventArgs e)
        {
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
                    DisplayCurrentArtwork();
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
                    if(newAverageRating.HasValue)
                    {
                        _feedArtworks[_currentArtworkIndex].AverageRateValue = newAverageRating.Value;
                    }
                    DisplayCurrentArtwork();
                }
                else
                {
                    MessageBox.Show("Failed to submit rating. Please try again.");
                }
            }



            ratingSubmitBtn.Enabled = true;
        }
    }
}
