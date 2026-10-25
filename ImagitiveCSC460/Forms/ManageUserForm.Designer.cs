namespace ImagitiveCSC460UI.Forms
{
    partial class ManageUserForm
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
            headerLabel = new Label();
            reportedUsernameLabel = new Label();
            presetPenaltiesComboBox = new ComboBox();
            reporterUsernameLabel = new Label();
            reasonLabel = new Label();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            addPenaltyButton = new Button();
            label3 = new Label();
            pendingPenaltiesList = new ListBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // headerLabel
            // 
            headerLabel.AutoSize = true;
            headerLabel.Font = new Font("Leelawadee UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            headerLabel.Location = new Point(34, 9);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(731, 86);
            headerLabel.TabIndex = 2;
            headerLabel.Text = "Manage Reported User";
            headerLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // reportedUsernameLabel
            // 
            reportedUsernameLabel.AutoSize = true;
            reportedUsernameLabel.Font = new Font("Leelawadee UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            reportedUsernameLabel.Location = new Point(12, 124);
            reportedUsernameLabel.Name = "reportedUsernameLabel";
            reportedUsernameLabel.Size = new Size(570, 45);
            reportedUsernameLabel.TabIndex = 3;
            reportedUsernameLabel.Text = "Reported User: {Insert Username Here}";
            // 
            // presetPenaltiesComboBox
            // 
            presetPenaltiesComboBox.FormattingEnabled = true;
            presetPenaltiesComboBox.Location = new Point(35, 631);
            presetPenaltiesComboBox.Name = "presetPenaltiesComboBox";
            presetPenaltiesComboBox.Size = new Size(242, 40);
            presetPenaltiesComboBox.TabIndex = 4;
            // 
            // reporterUsernameLabel
            // 
            reporterUsernameLabel.AutoSize = true;
            reporterUsernameLabel.Font = new Font("Leelawadee UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            reporterUsernameLabel.Location = new Point(12, 179);
            reporterUsernameLabel.Name = "reporterUsernameLabel";
            reporterUsernameLabel.Size = new Size(489, 45);
            reporterUsernameLabel.TabIndex = 5;
            reporterUsernameLabel.Text = "Reporter: {Insert Username Here}";
            // 
            // reasonLabel
            // 
            reasonLabel.AutoSize = true;
            reasonLabel.Font = new Font("Leelawadee UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            reasonLabel.Location = new Point(12, 234);
            reasonLabel.Name = "reasonLabel";
            reasonLabel.Size = new Size(428, 45);
            reasonLabel.TabIndex = 6;
            reasonLabel.Text = "Reason: {Insert Reason Here}";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Leelawadee UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 289);
            label1.Name = "label1";
            label1.Size = new Size(189, 45);
            label1.TabIndex = 7;
            label1.Text = "Description:";
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Leelawadee UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 334);
            label2.Name = "label2";
            label2.Size = new Size(753, 236);
            label2.TabIndex = 8;
            label2.Text = "{Insert Description Here}";
            // 
            // button1
            // 
            button1.Font = new Font("Leelawadee UI", 12F);
            button1.Location = new Point(31, 725);
            button1.Name = "button1";
            button1.Size = new Size(249, 122);
            button1.TabIndex = 9;
            button1.Text = "Submit and Resolve";
            button1.UseVisualStyleBackColor = true;
            // 
            // addPenaltyButton
            // 
            addPenaltyButton.Font = new Font("Leelawadee UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addPenaltyButton.Location = new Point(81, 677);
            addPenaltyButton.Name = "addPenaltyButton";
            addPenaltyButton.Size = new Size(150, 46);
            addPenaltyButton.TabIndex = 10;
            addPenaltyButton.Text = "Add Penalty";
            addPenaltyButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Leelawadee UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(84, 583);
            label3.Name = "label3";
            label3.Size = new Size(147, 45);
            label3.TabIndex = 11;
            label3.Text = "Penalties";
            label3.Click += label3_Click;
            // 
            // pendingPenaltiesList
            // 
            pendingPenaltiesList.FormattingEnabled = true;
            pendingPenaltiesList.Items.AddRange(new object[] { " " });
            pendingPenaltiesList.Location = new Point(324, 629);
            pendingPenaltiesList.Name = "pendingPenaltiesList";
            pendingPenaltiesList.Size = new Size(464, 228);
            pendingPenaltiesList.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Leelawadee UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(392, 583);
            label4.Name = "label4";
            label4.Size = new Size(335, 45);
            label4.TabIndex = 13;
            label4.Text = "Penalties to be Added";
            label4.Click += label4_Click;
            // 
            // ManageUserForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 869);
            Controls.Add(label4);
            Controls.Add(pendingPenaltiesList);
            Controls.Add(label3);
            Controls.Add(addPenaltyButton);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(reasonLabel);
            Controls.Add(reporterUsernameLabel);
            Controls.Add(presetPenaltiesComboBox);
            Controls.Add(reportedUsernameLabel);
            Controls.Add(headerLabel);
            Name = "ManageUserForm";
            Text = "ManageUserForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label headerLabel;
        private Label reportedUsernameLabel;
        private ComboBox presetPenaltiesComboBox;
        private Label reporterUsernameLabel;
        private Label reasonLabel;
        private Label label1;
        private Label label2;
        private Button button1;
        private Button addPenaltyButton;
        private Label label3;
        private ListBox pendingPenaltiesList;
        private Label label4;
    }
}