namespace ImagitiveCSC460UI.Forms
{
    partial class SplitImageInstanceForm
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
            imageInstanceViewer1 = new ImagitiveCSC460UI.Forms.Components.ImageInstanceViewer();
            SuspendLayout();
            // 
            // imageInstanceViewer1
            // 
            imageInstanceViewer1.AutoSize = true;
            imageInstanceViewer1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            imageInstanceViewer1.BackColor = Color.White;
            imageInstanceViewer1.Location = new Point(12, 12);
            imageInstanceViewer1.Name = "imageInstanceViewer1";
            imageInstanceViewer1.Size = new Size(503, 857);
            imageInstanceViewer1.TabIndex = 0;
            // 
            // SplitImageInstanceForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(530, 879);
            Controls.Add(imageInstanceViewer1);
            Name = "SplitImageInstanceForm";
            Text = "SplitImageInstanceForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Components.ImageInstanceViewer imageInstanceViewer1;
    }
}