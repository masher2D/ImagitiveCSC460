using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ImagitiveCSC460UI.Forms
{
    public partial class FullImageForm : Form
    {
        private MemoryStream? _imageStream;
        private readonly ContextMenuStrip _blockedContextMenu;

        public FullImageForm()
        {
            InitializeComponent();

            _blockedContextMenu = new ContextMenuStrip();
            _blockedContextMenu.Opening += BlockedContextMenu_Opening;
            pictureBox1.ContextMenuStrip = _blockedContextMenu;
        }

        public FullImageForm(byte[] imageBytes, string? title = null) : this()
        {
            _imageStream = new MemoryStream(imageBytes);
            pictureBox1.Image = Image.FromStream(_imageStream, useEmbeddedColorManagement: true, validateImageData: true);

            if (!string.IsNullOrWhiteSpace(title))
            {
                Text = title;
            }
        }

        public FullImageForm(Image image, string? title = null) : this()
        {
            pictureBox1.Image = image;

            if (!string.IsNullOrWhiteSpace(title))
            {
                Text = title;
            }
        }

        private void FullImageForm_Load(object sender, EventArgs e)
        {

        }

        private void BlockedContextMenu_Opening(object? sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            pictureBox1.Image?.Dispose();
            pictureBox1.Image = null;
            _imageStream?.Dispose();
            _imageStream = null;
            base.OnFormClosed(e);
        }


    }
}
