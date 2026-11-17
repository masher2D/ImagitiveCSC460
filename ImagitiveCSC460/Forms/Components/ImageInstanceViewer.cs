using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ImagitiveCSC460UI.Forms.Components
{
    public partial class ImageInstanceViewer : UserControl
    {
        public event EventHandler? ArtworkDoubleClicked;

        private readonly ContextMenuStrip _blockedContextMenu;

        public ImageInstanceViewer()
        {
            InitializeComponent();

            _blockedContextMenu = new ContextMenuStrip();
            _blockedContextMenu.Opening += BlockedContextMenu_Opening;
            artworkImageBox.ContextMenuStrip = _blockedContextMenu;

            DoubleClick += HandleArtworkDoubleClick;
            artworkImageBox.DoubleClick += HandleArtworkDoubleClick;
            artworkTitleLabel.DoubleClick += HandleArtworkDoubleClick;

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
        public Image? ArtworkImage
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


        private void artworkTitleLabel_Click(object sender, EventArgs e)
        {

        }

        private void artworkImageBox_Click(object sender, EventArgs e)
        {
        }

        private void artworkOptionsBtn_Click(object sender, EventArgs e)
        {

        }

        private void BlockedContextMenu_Opening(object? sender, CancelEventArgs e)
        {
            e.Cancel = true;
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

        private void HandleArtworkDoubleClick(object? sender, EventArgs e)
        {
            ArtworkDoubleClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
