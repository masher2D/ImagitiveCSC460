using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImagitiveCSC460UI.Forms.Components
{
    public partial class ImageInstanceViewer : UserControl
    {
        public ImageInstanceViewer()
        {
            InitializeComponent();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ArtworkTitle
        {
            get => artworkTitleLabel.Text;
            set => artworkTitleLabel.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ArtworkDescription
        {
            get => artworkDescriptionLabel.Text;
            set => artworkDescriptionLabel.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Image ArtworkImage
        {
            get => artworkImageBox.Image;
            set => artworkImageBox.Image = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ArtworkUsername
        {
            get => artworkUsernameLabel.Text;
            set => artworkUsernameLabel.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ArtworkAvgRating
        {
            get => artworkAvgRatingLabel.Text;
            set => artworkAvgRatingLabel.Text = value;
        }

        public void SetArtworkDetails(string title, string description, Image image, string username, string avgRating)
        {
            ArtworkTitle = title;
            ArtworkDescription = description;
            ArtworkImage = image;
            ArtworkUsername = username;
            ArtworkAvgRating = avgRating;
        }

        // Add this method to your ImageInstanceViewer.cs (code-behind file)
        private void artworkTitleLabel_Click(object sender, EventArgs e)
        {
            // Add your click handling logic here, or leave empty if not needed
        }

        private void artworkImageBox_Click(object sender, EventArgs e)
        {
            // TODO: Add logic if needed
        }

        private void artworkOptionsBtn_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void artworkDescriptionLabel_Click(object sender, EventArgs e)
        {

        }

        private void ImageInstanceViewer_Load(object sender, EventArgs e)
        {

        }

        private void artworkAvgRatingLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
