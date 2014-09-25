namespace Virtual_Lab
{
    partial class AboutVML
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutVML));
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.labelCompanyName = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.labelEPICSContributors = new System.Windows.Forms.Label();
            this.richLicense = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // labelProductName
            // 
            this.labelProductName.Location = new System.Drawing.Point(179, 12);
            this.labelProductName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelProductName.MaximumSize = new System.Drawing.Size(271, 17);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(271, 17);
            this.labelProductName.TabIndex = 26;
            this.labelProductName.Text = "Virtual Masking Lab";
            this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelVersion
            // 
            this.labelVersion.Location = new System.Drawing.Point(179, 45);
            this.labelVersion.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelVersion.MaximumSize = new System.Drawing.Size(271, 17);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(271, 17);
            this.labelVersion.TabIndex = 24;
            this.labelVersion.Text = "Version: 1.2.65";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCopyright
            // 
            this.labelCopyright.Location = new System.Drawing.Point(179, 78);
            this.labelCopyright.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelCopyright.MaximumSize = new System.Drawing.Size(271, 17);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(271, 17);
            this.labelCopyright.TabIndex = 27;
            this.labelCopyright.Text = "Copyright (C) 2011";
            this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCompanyName
            // 
            this.labelCompanyName.Location = new System.Drawing.Point(179, 111);
            this.labelCompanyName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelCompanyName.MaximumSize = new System.Drawing.Size(271, 17);
            this.labelCompanyName.Name = "labelCompanyName";
            this.labelCompanyName.Size = new System.Drawing.Size(271, 17);
            this.labelCompanyName.TabIndex = 28;
            this.labelCompanyName.Text = "Purdue University";
            this.labelCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonOK.Location = new System.Drawing.Point(152, 453);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(102, 24);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
            this.logoPictureBox.Location = new System.Drawing.Point(12, 12);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(128, 117);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPictureBox.TabIndex = 25;
            this.logoPictureBox.TabStop = false;
            // 
            // labelEPICSContributors
            // 
            this.labelEPICSContributors.Location = new System.Drawing.Point(12, 263);
            this.labelEPICSContributors.Name = "labelEPICSContributors";
            this.labelEPICSContributors.Size = new System.Drawing.Size(383, 187);
            this.labelEPICSContributors.TabIndex = 30;
            this.labelEPICSContributors.Text = resources.GetString("labelEPICSContributors.Text");
            this.labelEPICSContributors.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelEPICSContributors.Click += new System.EventHandler(this.labelEPICSContributors_Click);
            // 
            // richLicense
            // 
            this.richLicense.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richLicense.Location = new System.Drawing.Point(12, 135);
            this.richLicense.Name = "richLicense";
            this.richLicense.Size = new System.Drawing.Size(383, 125);
            this.richLicense.TabIndex = 31;
            this.richLicense.Text = "";
            // 
            // AboutVML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 485);
            this.Controls.Add(this.richLicense);
            this.Controls.Add(this.labelEPICSContributors);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.logoPictureBox);
            this.Controls.Add(this.labelProductName);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.labelCopyright);
            this.Controls.Add(this.labelCompanyName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutVML";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About Virtual Masking Lab";
            this.Load += new System.EventHandler(this.AboutVML_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.Label labelCompanyName;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelEPICSContributors;
        private System.Windows.Forms.RichTextBox richLicense;

    }
}
