namespace ImagitiveCSC460UI.Forms
{
    partial class MainDashboard
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
            artistDashboardInstance1 = new ImagitiveCSC460UI.Forms.Components.ArtistDashboardInstance();
            SuspendLayout();
            // 
            // artistDashboardInstance1
            // 
            artistDashboardInstance1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            artistDashboardInstance1.BackColor = Color.LightGray;
            artistDashboardInstance1.Location = new Point(12, 12);
            artistDashboardInstance1.Name = "artistDashboardInstance1";
            artistDashboardInstance1.Size = new Size(780, 899);
            artistDashboardInstance1.TabIndex = 0;
            // 
            // MainDashboard
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1474, 929);
            Controls.Add(artistDashboardInstance1);
            Name = "MainDashboard";
            Text = "MainDashboard";
            ResumeLayout(false);
        }

        #endregion

        private Components.ArtistDashboardInstance artistDashboardInstance1;
    }
}