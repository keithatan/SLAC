using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Virtual_Lab
{
	/// <summary>
	/// Summary description for PathologySelector.
	/// </summary>
	public class PathologySelector : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button okButton;
		public System.Windows.Forms.CheckedListBox pathBox;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PathologySelector()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.okButton = new System.Windows.Forms.Button();
            this.pathBox = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(16, 224);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "Ok";
            // 
            // pathBox
            // 
            this.pathBox.BackColor = System.Drawing.SystemColors.Control;
            this.pathBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pathBox.CheckOnClick = true;
            this.pathBox.Items.AddRange(new object[] {
            "Random",
            "Unilateral Otitis Media",
            "Unilateral Otosclerosis",
            "Ossicular Discontinuity",
            "Acoustic Tumor",
            "Sudden Onset",
            "Progressive Loss ",
            "Bilateral Otitis Media",
            "Bilateral Otosclerosis",
            "Microtia",
            "Menieres Disease",
            "Noise Induced Trauma",
            "Presbyacusis"});
            this.pathBox.Location = new System.Drawing.Point(16, 16);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(152, 195);
            this.pathBox.TabIndex = 1;
            this.pathBox.SelectedIndexChanged += new System.EventHandler(this.pathBox_SelectedIndexChanged);
            // 
            // PathologySelector
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(176, 250);
            this.ControlBox = false;
            this.Controls.Add(this.pathBox);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PathologySelector";
            this.Text = "PathologySelector";
            this.ResumeLayout(false);

		}
		#endregion

		private void pathBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// verify that only 1 box is checked
			for (int i = 0; i < pathBox.Items.Count; i++) 
			{
				if (i == pathBox.SelectedIndex) 
				{
					pathBox.SetItemChecked(i, true);
					continue;
				}
				pathBox.SetItemChecked(i, false);
			}
		}
	}
}
