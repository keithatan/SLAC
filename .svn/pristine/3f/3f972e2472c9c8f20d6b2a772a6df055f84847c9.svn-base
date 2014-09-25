using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;

namespace Virtual_Lab
{
	/// <summary>
	/// Summary description for WelcomeScreen.
	/// </summary>
	public class WelcomeScreen : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tb_Name;
		private System.Windows.Forms.TextBox tb_ID;
		private System.Windows.Forms.TextBox tb_Course;
		private System.Windows.Forms.Button bt_Pract;
		private System.Windows.Forms.Button bt_Eval;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tb_email;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tb_prof;
		private System.Windows.Forms.Label label8;


		// public strings with student information
		public string stName;
		public string stEmail;
		public string stID;
		public string stCourse;
		public string stProf;
        private PictureBox picClose;
        private TextBox textBox1;
        private TextBox textBox2;
		
		const string fileName = "user.cfg";

		public WelcomeScreen()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// Try to load in a config file with student information
			//

			ReadInfo();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeScreen));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_Name = new System.Windows.Forms.TextBox();
            this.tb_ID = new System.Windows.Forms.TextBox();
            this.tb_Course = new System.Windows.Forms.TextBox();
            this.bt_Pract = new System.Windows.Forms.Button();
            this.bt_Eval = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_email = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_prof = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(424, 336);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 96);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(144)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(624, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to the Virtual Lab";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(336, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "ID:";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(120, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(464, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Please enter (or update) your information";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 24);
            this.label6.TabIndex = 0;
            this.label6.Text = "Course:";
            // 
            // tb_Name
            // 
            this.tb_Name.Location = new System.Drawing.Point(96, 104);
            this.tb_Name.Name = "tb_Name";
            this.tb_Name.Size = new System.Drawing.Size(224, 20);
            this.tb_Name.TabIndex = 1;
            // 
            // tb_ID
            // 
            this.tb_ID.Location = new System.Drawing.Point(408, 104);
            this.tb_ID.Name = "tb_ID";
            this.tb_ID.Size = new System.Drawing.Size(232, 20);
            this.tb_ID.TabIndex = 2;
            // 
            // tb_Course
            // 
            this.tb_Course.Location = new System.Drawing.Point(96, 160);
            this.tb_Course.Name = "tb_Course";
            this.tb_Course.Size = new System.Drawing.Size(224, 20);
            this.tb_Course.TabIndex = 4;
            // 
            // bt_Pract
            // 
            this.bt_Pract.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.bt_Pract.Location = new System.Drawing.Point(368, 216);
            this.bt_Pract.Name = "bt_Pract";
            this.bt_Pract.Size = new System.Drawing.Size(128, 24);
            this.bt_Pract.TabIndex = 6;
            this.bt_Pract.Text = "Enter Practice Mode";
            this.bt_Pract.Click += new System.EventHandler(this.bt_Click);
            // 
            // bt_Eval
            // 
            this.bt_Eval.DialogResult = System.Windows.Forms.DialogResult.No;
            this.bt_Eval.Location = new System.Drawing.Point(512, 216);
            this.bt_Eval.Name = "bt_Eval";
            this.bt_Eval.Size = new System.Drawing.Size(128, 24);
            this.bt_Eval.TabIndex = 7;
            this.bt_Eval.Text = "Enter Evaluation Mode";
            this.bt_Eval.Click += new System.EventHandler(this.bt_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(440, 280);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(216, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Release: Testing";
            // 
            // tb_email
            // 
            this.tb_email.Location = new System.Drawing.Point(96, 128);
            this.tb_email.Name = "tb_email";
            this.tb_email.Size = new System.Drawing.Size(224, 20);
            this.tb_email.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 24);
            this.label7.TabIndex = 0;
            this.label7.Text = "Email:";
            // 
            // tb_prof
            // 
            this.tb_prof.Location = new System.Drawing.Point(408, 160);
            this.tb_prof.Name = "tb_prof";
            this.tb_prof.Size = new System.Drawing.Size(224, 20);
            this.tb_prof.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(328, 160);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 24);
            this.label8.TabIndex = 0;
            this.label8.Text = "Prof:";
            // 
            // picClose
            // 
            this.picClose.Image = ((System.Drawing.Image)(resources.GetObject("picClose.Image")));
            this.picClose.Location = new System.Drawing.Point(656, 12);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(20, 20);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picClose.TabIndex = 8;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            this.picClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picClose_MouseDown);
            this.picClose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picClose_MouseUp);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(144)))), ((int)(((byte)(0)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(12, 196);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(350, 120);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(144)))), ((int)(((byte)(0)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(12, 322);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(350, 130);
            this.textBox2.TabIndex = 10;
            this.textBox2.Text = "Dr. Robert E. Novak - PhD, CCC-A\r\nClinical Audiologist\r\nMD Steer Audiology Clinic" +
                "\r\nDepartment of Speech, Language, and Hearing Sciences\r\nPurdue University";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // WelcomeScreen
            // 
            this.AcceptButton = this.bt_Pract;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(144)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(688, 464);
            this.ControlBox = false;
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.picClose);
            this.Controls.Add(this.tb_prof);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tb_email);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bt_Eval);
            this.Controls.Add(this.bt_Pract);
            this.Controls.Add(this.tb_Course);
            this.Controls.Add(this.tb_ID);
            this.Controls.Add(this.tb_Name);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WelcomeScreen";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WelcomeScreen";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void bt_Click(object sender, System.EventArgs e)
		{
			stName = tb_Name.Text;
			stID = tb_ID.Text;
			stCourse = tb_Course.Text;
			stEmail = tb_email.Text;
			stProf = tb_prof.Text;

			// write info to the config file (if possible)
			try 
			{
				using (StreamWriter fs = new StreamWriter(fileName, false))
				{
					// get the fields
					fs.WriteLine(stName);
					fs.WriteLine(stID);
					fs.WriteLine(stCourse);
					fs.WriteLine(stProf);
					fs.WriteLine(stEmail);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		private void ReadInfo() 
		{
			StreamReader fs;

			// if no configuration file
			if (!File.Exists(fileName)) 
			{
				return;
			}

            // otherwise open and try to read the user information
			try 
			{
				using (fs = new StreamReader(fileName)) 
				{
					// get the fields
					stName = fs.ReadLine();
					stID = fs.ReadLine();
					stCourse = fs.ReadLine();
					stProf = fs.ReadLine();
					stEmail = fs.ReadLine();

					// update text boxes
					tb_Name.Text = stName;
					tb_ID.Text = stID;
					tb_Course.Text = stCourse;
					tb_email.Text = stEmail;
					tb_prof.Text = stProf;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

        // Close Button events
        private void picClose_Click(object sender, EventArgs e)
        {
            Application.Exit(); // This will also send DialogResult.Cancel to the return of ShowDialog.
        }

        private void picClose_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            System.IO.Stream closeDown = Assembly.GetExecutingAssembly().GetManifestResourceStream("Virtual_Lab.Images.closeDown.bmp");
            picClose.Image = new Bitmap(closeDown);
        }

        private void picClose_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            System.IO.Stream closeUp = Assembly.GetExecutingAssembly().GetManifestResourceStream("Virtual_Lab.Images.closeUp.bmp");
            picClose.Image = new Bitmap(closeUp);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

	}
}
