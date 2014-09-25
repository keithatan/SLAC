using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Pathology_Dev
{
	/// <summary>
	/// Summary description for CaseHistoryFrom.
	/// </summary>
	public class CaseHistoryForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbName;
		private System.Windows.Forms.TextBox tbAge;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox tbGender;
		private System.Windows.Forms.TextBox tbWhen;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.TextBox tbBadEar;
		private System.Windows.Forms.TextBox tbGoodEar;
		private System.Windows.Forms.TextBox tbWorse;
		private System.Windows.Forms.TextBox tbNature;
		private System.Windows.Forms.TextBox tbInfection;
		private System.Windows.Forms.TextBox tbInfEar;
		private System.Windows.Forms.TextBox tbFamily;
		private System.Windows.Forms.TextBox tbFamWho;
		private System.Windows.Forms.TextBox tbNoises;
		private System.Windows.Forms.TextBox tbNoiseEar;
		private System.Windows.Forms.TextBox tbNoiseFreq;
		private System.Windows.Forms.TextBox tbNoiseDesc;
		private System.Windows.Forms.TextBox tbDizzy;
		private System.Windows.Forms.TextBox tbNausea;
		private System.Windows.Forms.TextBox tbPuke;
		private System.Windows.Forms.TextBox tbExpNoise;
		private System.Windows.Forms.TextBox tbExpNoiseDesc;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CaseHistoryForm()
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tbName = new System.Windows.Forms.TextBox();
			this.tbAge = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.tbGender = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.tbWhen = new System.Windows.Forms.TextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.tbBadEar = new System.Windows.Forms.TextBox();
			this.tbGoodEar = new System.Windows.Forms.TextBox();
			this.tbWorse = new System.Windows.Forms.TextBox();
			this.tbNature = new System.Windows.Forms.TextBox();
			this.tbInfection = new System.Windows.Forms.TextBox();
			this.tbInfEar = new System.Windows.Forms.TextBox();
			this.tbFamily = new System.Windows.Forms.TextBox();
			this.tbFamWho = new System.Windows.Forms.TextBox();
			this.tbNoises = new System.Windows.Forms.TextBox();
			this.tbNoiseEar = new System.Windows.Forms.TextBox();
			this.tbNoiseFreq = new System.Windows.Forms.TextBox();
			this.tbNoiseDesc = new System.Windows.Forms.TextBox();
			this.tbDizzy = new System.Windows.Forms.TextBox();
			this.tbNausea = new System.Windows.Forms.TextBox();
			this.tbPuke = new System.Windows.Forms.TextBox();
			this.tbExpNoise = new System.Windows.Forms.TextBox();
			this.tbExpNoiseDesc = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Age:";
			// 
			// tbName
			// 
			this.tbName.BackColor = System.Drawing.Color.White;
			this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbName.Location = new System.Drawing.Point(72, 16);
			this.tbName.Name = "tbName";
			this.tbName.ReadOnly = true;
			this.tbName.Size = new System.Drawing.Size(208, 13);
			this.tbName.TabIndex = 2;
			this.tbName.TabStop = false;
			this.tbName.Text = "";
			this.tbName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tbAge
			// 
			this.tbAge.BackColor = System.Drawing.Color.White;
			this.tbAge.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbAge.Location = new System.Drawing.Point(72, 40);
			this.tbAge.Name = "tbAge";
			this.tbAge.ReadOnly = true;
			this.tbAge.Size = new System.Drawing.Size(208, 13);
			this.tbAge.TabIndex = 3;
			this.tbAge.TabStop = false;
			this.tbAge.Text = "";
			this.tbAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Gender:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 104);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(176, 16);
			this.label4.TabIndex = 5;
			this.label4.Text = "Do you have difficulty hearing?";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(112, 128);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 16);
			this.label5.TabIndex = 6;
			this.label5.Text = "In which ear?";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(112, 152);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 16);
			this.label6.TabIndex = 7;
			this.label6.Text = "Better ear?";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 248);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(216, 16);
			this.label7.TabIndex = 8;
			this.label7.Text = "What is the nature of your hearing loss?";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(40, 432);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(64, 16);
			this.label8.TabIndex = 9;
			this.label8.Text = "How often?";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(8, 552);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(320, 16);
			this.label9.TabIndex = 10;
			this.label9.Text = "Have you been exposed to loud noises for any length of time?";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(40, 456);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(64, 16);
			this.label10.TabIndex = 11;
			this.label10.Text = "Describe:";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(8, 480);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(128, 16);
			this.label11.TabIndex = 12;
			this.label11.Text = "Do you have dizziness?";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(40, 504);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(160, 16);
			this.label12.TabIndex = 13;
			this.label12.Text = "Is it accompanied by nausea?";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(8, 176);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(200, 16);
			this.label13.TabIndex = 14;
			this.label13.Text = "When did you first notice this problem?";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(8, 272);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(192, 16);
			this.label14.TabIndex = 15;
			this.label14.Text = "Have you ever had an ear infection?";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(8, 224);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(392, 16);
			this.label15.TabIndex = 16;
			this.label15.Text = "Is your hearing worse since you first noticed it or since your last hearing test?" +
				"";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(112, 296);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(80, 16);
			this.label16.TabIndex = 17;
			this.label16.Text = "In which ear?";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(8, 320);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(272, 16);
			this.label17.TabIndex = 18;
			this.label17.Text = "Does anyone in your family have a hearing problem?";
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(120, 576);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(64, 16);
			this.label18.TabIndex = 19;
			this.label18.Text = "Describe:";
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(40, 344);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(104, 16);
			this.label19.TabIndex = 20;
			this.label19.Text = "If so, who and type:";
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(8, 384);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(176, 16);
			this.label20.TabIndex = 21;
			this.label20.Text = "Do you hear noises in your head?";
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(40, 408);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(64, 16);
			this.label21.TabIndex = 22;
			this.label21.Text = "Which ear?";
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.tbGender);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.tbAge);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.tbName);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(296, 88);
			this.panel1.TabIndex = 23;
			// 
			// tbGender
			// 
			this.tbGender.BackColor = System.Drawing.Color.White;
			this.tbGender.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbGender.Location = new System.Drawing.Point(72, 64);
			this.tbGender.Name = "tbGender";
			this.tbGender.ReadOnly = true;
			this.tbGender.Size = new System.Drawing.Size(208, 13);
			this.tbGender.TabIndex = 5;
			this.tbGender.TabStop = false;
			this.tbGender.Text = "";
			this.tbGender.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.Color.White;
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(200, 104);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(48, 13);
			this.textBox1.TabIndex = 24;
			this.textBox1.TabStop = false;
			this.textBox1.Text = "Yes";
			// 
			// tbWhen
			// 
			this.tbWhen.BackColor = System.Drawing.Color.White;
			this.tbWhen.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbWhen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbWhen.Location = new System.Drawing.Point(8, 200);
			this.tbWhen.Name = "tbWhen";
			this.tbWhen.ReadOnly = true;
			this.tbWhen.Size = new System.Drawing.Size(504, 13);
			this.tbWhen.TabIndex = 25;
			this.tbWhen.TabStop = false;
			this.tbWhen.Text = "";
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(40, 528);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(160, 16);
			this.label22.TabIndex = 26;
			this.label22.Text = "Is it accompanied by vomiting?";
			// 
			// label23
			// 
			this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label23.Location = new System.Drawing.Point(40, 616);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(424, 8);
			this.label23.TabIndex = 27;
			this.label23.Text = "This form is adapted from the form used at Purdue University Audiology Clinic - a" +
				"dapted by R. Benjamin and L. Scott";
			// 
			// tbBadEar
			// 
			this.tbBadEar.BackColor = System.Drawing.Color.White;
			this.tbBadEar.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbBadEar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbBadEar.Location = new System.Drawing.Point(200, 128);
			this.tbBadEar.Name = "tbBadEar";
			this.tbBadEar.ReadOnly = true;
			this.tbBadEar.Size = new System.Drawing.Size(104, 13);
			this.tbBadEar.TabIndex = 28;
			this.tbBadEar.TabStop = false;
			this.tbBadEar.Text = "";
			// 
			// tbGoodEar
			// 
			this.tbGoodEar.BackColor = System.Drawing.Color.White;
			this.tbGoodEar.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbGoodEar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbGoodEar.Location = new System.Drawing.Point(200, 152);
			this.tbGoodEar.Name = "tbGoodEar";
			this.tbGoodEar.ReadOnly = true;
			this.tbGoodEar.Size = new System.Drawing.Size(104, 13);
			this.tbGoodEar.TabIndex = 29;
			this.tbGoodEar.TabStop = false;
			this.tbGoodEar.Text = "";
			// 
			// tbWorse
			// 
			this.tbWorse.BackColor = System.Drawing.Color.White;
			this.tbWorse.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbWorse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbWorse.Location = new System.Drawing.Point(416, 224);
			this.tbWorse.Name = "tbWorse";
			this.tbWorse.ReadOnly = true;
			this.tbWorse.Size = new System.Drawing.Size(48, 13);
			this.tbWorse.TabIndex = 30;
			this.tbWorse.TabStop = false;
			this.tbWorse.Text = "";
			// 
			// tbNature
			// 
			this.tbNature.BackColor = System.Drawing.Color.White;
			this.tbNature.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbNature.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbNature.Location = new System.Drawing.Point(232, 248);
			this.tbNature.Name = "tbNature";
			this.tbNature.ReadOnly = true;
			this.tbNature.Size = new System.Drawing.Size(184, 13);
			this.tbNature.TabIndex = 31;
			this.tbNature.TabStop = false;
			this.tbNature.Text = "";
			// 
			// tbInfection
			// 
			this.tbInfection.BackColor = System.Drawing.Color.White;
			this.tbInfection.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbInfection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbInfection.Location = new System.Drawing.Point(232, 272);
			this.tbInfection.Name = "tbInfection";
			this.tbInfection.ReadOnly = true;
			this.tbInfection.Size = new System.Drawing.Size(184, 13);
			this.tbInfection.TabIndex = 32;
			this.tbInfection.TabStop = false;
			this.tbInfection.Text = "";
			// 
			// tbInfEar
			// 
			this.tbInfEar.BackColor = System.Drawing.Color.White;
			this.tbInfEar.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbInfEar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbInfEar.Location = new System.Drawing.Point(232, 296);
			this.tbInfEar.Name = "tbInfEar";
			this.tbInfEar.ReadOnly = true;
			this.tbInfEar.Size = new System.Drawing.Size(184, 13);
			this.tbInfEar.TabIndex = 33;
			this.tbInfEar.TabStop = false;
			this.tbInfEar.Text = "";
			// 
			// tbFamily
			// 
			this.tbFamily.BackColor = System.Drawing.Color.White;
			this.tbFamily.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbFamily.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbFamily.Location = new System.Drawing.Point(280, 320);
			this.tbFamily.Name = "tbFamily";
			this.tbFamily.ReadOnly = true;
			this.tbFamily.Size = new System.Drawing.Size(48, 13);
			this.tbFamily.TabIndex = 34;
			this.tbFamily.TabStop = false;
			this.tbFamily.Text = "";
			// 
			// tbFamWho
			// 
			this.tbFamWho.BackColor = System.Drawing.Color.White;
			this.tbFamWho.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbFamWho.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbFamWho.Location = new System.Drawing.Point(144, 344);
			this.tbFamWho.Multiline = true;
			this.tbFamWho.Name = "tbFamWho";
			this.tbFamWho.ReadOnly = true;
			this.tbFamWho.Size = new System.Drawing.Size(368, 32);
			this.tbFamWho.TabIndex = 35;
			this.tbFamWho.TabStop = false;
			this.tbFamWho.Text = "";
			// 
			// tbNoises
			// 
			this.tbNoises.BackColor = System.Drawing.Color.White;
			this.tbNoises.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbNoises.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbNoises.Location = new System.Drawing.Point(184, 384);
			this.tbNoises.Name = "tbNoises";
			this.tbNoises.ReadOnly = true;
			this.tbNoises.Size = new System.Drawing.Size(48, 13);
			this.tbNoises.TabIndex = 36;
			this.tbNoises.TabStop = false;
			this.tbNoises.Text = "";
			// 
			// tbNoiseEar
			// 
			this.tbNoiseEar.BackColor = System.Drawing.Color.White;
			this.tbNoiseEar.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbNoiseEar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbNoiseEar.Location = new System.Drawing.Point(184, 408);
			this.tbNoiseEar.Name = "tbNoiseEar";
			this.tbNoiseEar.ReadOnly = true;
			this.tbNoiseEar.Size = new System.Drawing.Size(48, 13);
			this.tbNoiseEar.TabIndex = 37;
			this.tbNoiseEar.TabStop = false;
			this.tbNoiseEar.Text = "";
			// 
			// tbNoiseFreq
			// 
			this.tbNoiseFreq.BackColor = System.Drawing.Color.White;
			this.tbNoiseFreq.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbNoiseFreq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbNoiseFreq.Location = new System.Drawing.Point(184, 432);
			this.tbNoiseFreq.Name = "tbNoiseFreq";
			this.tbNoiseFreq.ReadOnly = true;
			this.tbNoiseFreq.Size = new System.Drawing.Size(120, 13);
			this.tbNoiseFreq.TabIndex = 38;
			this.tbNoiseFreq.TabStop = false;
			this.tbNoiseFreq.Text = "";
			// 
			// tbNoiseDesc
			// 
			this.tbNoiseDesc.BackColor = System.Drawing.Color.White;
			this.tbNoiseDesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbNoiseDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbNoiseDesc.Location = new System.Drawing.Point(184, 456);
			this.tbNoiseDesc.Name = "tbNoiseDesc";
			this.tbNoiseDesc.ReadOnly = true;
			this.tbNoiseDesc.Size = new System.Drawing.Size(120, 13);
			this.tbNoiseDesc.TabIndex = 39;
			this.tbNoiseDesc.TabStop = false;
			this.tbNoiseDesc.Text = "";
			// 
			// tbDizzy
			// 
			this.tbDizzy.BackColor = System.Drawing.Color.White;
			this.tbDizzy.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbDizzy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbDizzy.Location = new System.Drawing.Point(208, 480);
			this.tbDizzy.Name = "tbDizzy";
			this.tbDizzy.ReadOnly = true;
			this.tbDizzy.Size = new System.Drawing.Size(48, 13);
			this.tbDizzy.TabIndex = 40;
			this.tbDizzy.TabStop = false;
			this.tbDizzy.Text = "";
			// 
			// tbNausea
			// 
			this.tbNausea.BackColor = System.Drawing.Color.White;
			this.tbNausea.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbNausea.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbNausea.Location = new System.Drawing.Point(208, 504);
			this.tbNausea.Name = "tbNausea";
			this.tbNausea.ReadOnly = true;
			this.tbNausea.Size = new System.Drawing.Size(48, 13);
			this.tbNausea.TabIndex = 41;
			this.tbNausea.TabStop = false;
			this.tbNausea.Text = "";
			// 
			// tbPuke
			// 
			this.tbPuke.BackColor = System.Drawing.Color.White;
			this.tbPuke.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbPuke.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbPuke.Location = new System.Drawing.Point(208, 528);
			this.tbPuke.Name = "tbPuke";
			this.tbPuke.ReadOnly = true;
			this.tbPuke.Size = new System.Drawing.Size(48, 13);
			this.tbPuke.TabIndex = 42;
			this.tbPuke.TabStop = false;
			this.tbPuke.Text = "";
			// 
			// tbExpNoise
			// 
			this.tbExpNoise.BackColor = System.Drawing.Color.White;
			this.tbExpNoise.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbExpNoise.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbExpNoise.Location = new System.Drawing.Point(336, 552);
			this.tbExpNoise.Name = "tbExpNoise";
			this.tbExpNoise.ReadOnly = true;
			this.tbExpNoise.Size = new System.Drawing.Size(48, 13);
			this.tbExpNoise.TabIndex = 43;
			this.tbExpNoise.TabStop = false;
			this.tbExpNoise.Text = "";
			// 
			// tbExpNoiseDesc
			// 
			this.tbExpNoiseDesc.BackColor = System.Drawing.Color.White;
			this.tbExpNoiseDesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbExpNoiseDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbExpNoiseDesc.Location = new System.Drawing.Point(176, 576);
			this.tbExpNoiseDesc.Name = "tbExpNoiseDesc";
			this.tbExpNoiseDesc.ReadOnly = true;
			this.tbExpNoiseDesc.Size = new System.Drawing.Size(312, 13);
			this.tbExpNoiseDesc.TabIndex = 44;
			this.tbExpNoiseDesc.TabStop = false;
			this.tbExpNoiseDesc.Text = "";
			// 
			// CaseHistoryForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.ClientSize = new System.Drawing.Size(522, 636);
			this.Controls.Add(this.tbExpNoiseDesc);
			this.Controls.Add(this.tbExpNoise);
			this.Controls.Add(this.tbPuke);
			this.Controls.Add(this.tbNausea);
			this.Controls.Add(this.tbDizzy);
			this.Controls.Add(this.tbNoiseDesc);
			this.Controls.Add(this.tbNoiseFreq);
			this.Controls.Add(this.tbNoiseEar);
			this.Controls.Add(this.tbNoises);
			this.Controls.Add(this.tbFamWho);
			this.Controls.Add(this.tbFamily);
			this.Controls.Add(this.tbInfEar);
			this.Controls.Add(this.tbInfection);
			this.Controls.Add(this.tbNature);
			this.Controls.Add(this.tbWorse);
			this.Controls.Add(this.tbGoodEar);
			this.Controls.Add(this.tbBadEar);
			this.Controls.Add(this.label23);
			this.Controls.Add(this.label22);
			this.Controls.Add(this.tbWhen);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label21);
			this.Controls.Add(this.label20);
			this.Controls.Add(this.label19);
			this.Controls.Add(this.label18);
			this.Controls.Add(this.label17);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CaseHistoryForm";
			this.Text = "Case History";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public void FillCaseHistory(string hist)
		{
			string[] temp = new string[22];
			temp = hist.Split(";".ToCharArray(),22);

			// assign values to text boxes
			int i = 0;
			tbBadEar.Text = temp[i++];
			tbGoodEar.Text = temp[i++];
			tbWhen.Text = temp[i++];
			tbWorse.Text = temp[i++];
			tbNature.Text = temp[i++];
			tbInfection.Text = temp[i++];
			tbInfEar.Text = temp[i++];
			tbFamily.Text = temp[i++];
			tbFamWho.Text = temp[i++];
			tbNoises.Text = temp[i++];
			tbNoiseEar.Text = temp[i++];
			tbNoiseFreq.Text = temp[i++];
			tbNoiseDesc.Text = temp[i++];
			tbDizzy.Text = temp[i++];
			tbNausea.Text = temp[i++];
			tbPuke.Text = temp[i++];
			tbExpNoise.Text = temp[i++];
			tbExpNoiseDesc.Text = temp[i++];
		}
	}
}
