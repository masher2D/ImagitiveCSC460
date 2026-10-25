namespace ImagitiveCSC460UI.Forms
{
    partial class PostArtworkForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PostArtworkForm));
            headerLabel = new Label();
            subtitleLabel = new Label();
            descriptionLabel = new Label();
            addImageLabel = new Label();
            openFileDialog1 = new OpenFileDialog();
            descriptionValue = new TextBox();
            titleValue = new TextBox();
            postBtn = new Button();
            addImageBtn = new Button();
            previewBox = new PictureBox();
            previewLabel = new Label();
            addTagValueComboBox = new ComboBox();
            addTagLabel = new Label();
            label1 = new Label();
            clearTagsBtn = new Button();
            addTagBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)previewBox).BeginInit();
            SuspendLayout();
            // 
            // headerLabel
            // 
            headerLabel.AutoSize = true;
            headerLabel.Font = new Font("Leelawadee UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            headerLabel.Location = new Point(12, 9);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(432, 86);
            headerLabel.TabIndex = 1;
            headerLabel.Text = "Create a Post";
            headerLabel.TextAlign = ContentAlignment.TopCenter;
            headerLabel.Click += headerLabel_Click;
            // 
            // subtitleLabel
            // 
            subtitleLabel.AutoSize = true;
            subtitleLabel.Font = new Font("Leelawadee UI", 11F);
            subtitleLabel.Location = new Point(12, 106);
            subtitleLabel.Name = "subtitleLabel";
            subtitleLabel.Size = new Size(74, 41);
            subtitleLabel.TabIndex = 12;
            subtitleLabel.Text = "Title";
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Font = new Font("Leelawadee UI", 11F);
            descriptionLabel.Location = new Point(12, 215);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(169, 41);
            descriptionLabel.TabIndex = 13;
            descriptionLabel.Text = "Description";
            descriptionLabel.Click += label1_Click;
            // 
            // addImageLabel
            // 
            addImageLabel.AutoSize = true;
            addImageLabel.Font = new Font("Leelawadee UI", 11F);
            addImageLabel.Location = new Point(12, 538);
            addImageLabel.Name = "addImageLabel";
            addImageLabel.Size = new Size(164, 41);
            addImageLabel.TabIndex = 14;
            addImageLabel.Text = "Add Image";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // descriptionValue
            // 
            descriptionValue.AcceptsReturn = true;
            descriptionValue.Location = new Point(12, 266);
            descriptionValue.Multiline = true;
            descriptionValue.Name = "descriptionValue";
            descriptionValue.Size = new Size(616, 251);
            descriptionValue.TabIndex = 15;
            descriptionValue.TextChanged += descriptionValue_TextChanged;
            // 
            // titleValue
            // 
            titleValue.Location = new Point(12, 150);
            titleValue.Name = "titleValue";
            titleValue.Size = new Size(200, 39);
            titleValue.TabIndex = 16;
            // 
            // postBtn
            // 
            postBtn.Font = new Font("Leelawadee UI", 12F);
            postBtn.Location = new Point(909, 776);
            postBtn.Name = "postBtn";
            postBtn.Size = new Size(231, 103);
            postBtn.TabIndex = 17;
            postBtn.Text = "Post";
            postBtn.UseVisualStyleBackColor = true;
            postBtn.Click += button1_Click;
            // 
            // addImageBtn
            // 
            addImageBtn.Font = new Font("Leelawadee UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addImageBtn.Location = new Point(12, 582);
            addImageBtn.Name = "addImageBtn";
            addImageBtn.Size = new Size(150, 46);
            addImageBtn.TabIndex = 18;
            addImageBtn.Text = "Open File";
            addImageBtn.UseVisualStyleBackColor = true;
            // 
            // previewBox
            // 
            previewBox.Image = (Image)resources.GetObject("previewBox.Image");
            previewBox.InitialImage = (Image)resources.GetObject("previewBox.InitialImage");
            previewBox.Location = new Point(661, 4);
            previewBox.Name = "previewBox";
            previewBox.Size = new Size(720, 720);
            previewBox.TabIndex = 19;
            previewBox.TabStop = false;
            // 
            // previewLabel
            // 
            previewLabel.AutoSize = true;
            previewLabel.Font = new Font("Leelawadee UI", 11F);
            previewLabel.Location = new Point(919, 676);
            previewLabel.Name = "previewLabel";
            previewLabel.Size = new Size(211, 41);
            previewLabel.TabIndex = 20;
            previewLabel.Text = "Image Preview";
            // 
            // addTagValueComboBox
            // 
            addTagValueComboBox.FormattingEnabled = true;
            addTagValueComboBox.Location = new Point(12, 691);
            addTagValueComboBox.Name = "addTagValueComboBox";
            addTagValueComboBox.Size = new Size(242, 40);
            addTagValueComboBox.TabIndex = 21;
            addTagValueComboBox.SelectedIndexChanged += addTagValueComboBox_SelectedIndexChanged;
            // 
            // addTagLabel
            // 
            addTagLabel.AutoSize = true;
            addTagLabel.Font = new Font("Leelawadee UI", 11F);
            addTagLabel.Location = new Point(12, 647);
            addTagLabel.Name = "addTagLabel";
            addTagLabel.Size = new Size(248, 41);
            addTagLabel.TabIndex = 22;
            addTagLabel.Text = "Add Tags (max 3)";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Leelawadee UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 856);
            label1.Name = "label1";
            label1.Size = new Size(452, 45);
            label1.TabIndex = 23;
            label1.Text = "Taglist: {Insert submitted tags}";
            // 
            // clearTagsBtn
            // 
            clearTagsBtn.Font = new Font("Leelawadee UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clearTagsBtn.Location = new Point(12, 791);
            clearTagsBtn.Name = "clearTagsBtn";
            clearTagsBtn.Size = new Size(150, 46);
            clearTagsBtn.TabIndex = 24;
            clearTagsBtn.Text = "Clear Tags";
            clearTagsBtn.UseVisualStyleBackColor = true;
            // 
            // addTagBtn
            // 
            addTagBtn.Location = new Point(12, 737);
            addTagBtn.Name = "addTagBtn";
            addTagBtn.Size = new Size(150, 46);
            addTagBtn.TabIndex = 25;
            addTagBtn.Text = "Add Tag";
            addTagBtn.UseVisualStyleBackColor = true;
            // 
            // PostArtwork
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1387, 930);
            Controls.Add(addTagBtn);
            Controls.Add(clearTagsBtn);
            Controls.Add(label1);
            Controls.Add(addTagLabel);
            Controls.Add(addTagValueComboBox);
            Controls.Add(previewLabel);
            Controls.Add(previewBox);
            Controls.Add(addImageBtn);
            Controls.Add(postBtn);
            Controls.Add(titleValue);
            Controls.Add(descriptionValue);
            Controls.Add(addImageLabel);
            Controls.Add(descriptionLabel);
            Controls.Add(subtitleLabel);
            Controls.Add(headerLabel);
            Name = "PostArtwork";
            Text = "PostArtwork";
            ((System.ComponentModel.ISupportInitialize)previewBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label headerLabel;
        private Label subtitleLabel;
        private Label descriptionLabel;
        private Label addImageLabel;
        private OpenFileDialog openFileDialog1;
        private TextBox descriptionValue;
        private TextBox titleValue;
        private Button postBtn;
        private Button addImageBtn;
        private PictureBox previewBox;
        private Label previewLabel;
        private ComboBox addTagValueComboBox;
        private Label addTagLabel;
        private Label label1;
        private Button clearTagsBtn;
        private Button addTagBtn;
    }
}