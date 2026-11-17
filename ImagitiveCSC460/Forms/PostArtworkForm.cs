using ImagitiveCSC460UI.Session;
using ImagitiveCSC460UI.Services;
using ImagitiveLibrary.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Formats.Cbor;
using System.Text;
using System.Windows.Forms;

namespace ImagitiveCSC460UI.Forms
{
    public partial class PostArtworkForm : Form
    {
        private readonly ArtworkAPIService _artworkService = new ArtworkAPIService();
        private readonly TagAPIService _tagService = new TagAPIService();
        private string? artworkImagePath = string.Empty;
        private List<string> selectedTagNames = new List<string>();
        public PostArtworkForm()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            postBtn.Enabled = false;
            var title = validateString(titleValue.Text);
            var description = validateString(descriptionValue.Text);
            artworkImagePath = validateString(artworkImagePath ?? string.Empty);

            if (string.IsNullOrWhiteSpace(artworkImagePath) || !File.Exists(artworkImagePath))
            {
                MessageBox.Show("Please select a valid image file.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                postBtn.Enabled = true;
                return;
            }

                if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Title cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                postBtn.Enabled = true;
                return;
            }

            var request = new ImagitiveLibrary.Core.Requests.PostArtworkRequest
            {
                Title = title,
                Description = description,
                Tags = selectedTagNames
            };

            pictureBox1.Visible = true;

            var response = await _artworkService.CreateArtworkAsync(artworkImagePath, request);

            if (response == null)
            {
                MessageBox.Show("Failed to post artwork. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                postBtn.Enabled = true;
                pictureBox1.Visible = false;
                return;
            }
            else
            {
                MessageBox.Show("Artwork posted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void headerLabel_Click(object sender, EventArgs e)
        {

        }

        private void descriptionValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void addTagValueComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addImageBtn_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;

            }
            previewBox.Image = null;
            artworkImagePath = null;
            artworkImagePath = openFileDialog1.FileName;
            previewBox.Image = Image.FromFile(artworkImagePath);
        }

        private async void PostArtworkForm_Load(object sender, EventArgs e)
        {
            var tags = await _tagService.GetAllTagsAsync();

            addTagValueComboBox.DataSource = tags;

            addTagValueComboBox.DisplayMember = "Name";

            addTagValueComboBox.ValueMember = "TagId";

            addTagValueComboBox.SelectedIndex = -1;
        }

        private void addTagBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (addTagValueComboBox.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a tag to add.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var selectedTagName = (addTagValueComboBox.SelectedItem as TagModel)?.Name;
                if (!string.IsNullOrWhiteSpace(selectedTagName) && selectedTagNames.Contains(selectedTagName))
                {
                    MessageBox.Show("This tag has already been added.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (selectedTagNames.Count >= 3)
                {
                    MessageBox.Show("You can only add up to 3 tags.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (addTagValueComboBox.SelectedItem is TagModel tag)
            {
                selectedTagNames.Add(tag.Name);
            }
            else
            {
                throw new InvalidOperationException("Selected item is not a TagModel.");
            }
            taglistLabel.Text = "Taglist: " + string.Join(", ", selectedTagNames);
        }

        private void clearTagsBtn_Click(object sender, EventArgs e)
        {
            selectedTagNames.Clear();
            taglistLabel.Text = "Taglist: ";
        }

        private string? validateString(string dirtyText)
        {
            return dirtyText?.Trim();
        }

    }
}
