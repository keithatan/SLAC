using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Audiogram_Dev
{
	/// <summary>
	/// Summary description for SpeechAudiometry.
	/// </summary>
	public class SpeechAudiometry : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblSRTLabel;
		private System.Windows.Forms.Label lblWILabel;
		private System.Windows.Forms.TextBox txtSRTLeftThresh;
		private System.Windows.Forms.TextBox txtSRTLeftMask;
		private System.Windows.Forms.TextBox txtSRTRightThresh;
		private System.Windows.Forms.TextBox txtSRTRightMask;
		private System.Windows.Forms.TextBox txtWILeftScore;
		private System.Windows.Forms.TextBox txtWILeftLevel;
		private System.Windows.Forms.TextBox txtWILeftMask;
		private System.Windows.Forms.TextBox txtWIRightScore;
		private System.Windows.Forms.TextBox txtWIRightLevel;
		private System.Windows.Forms.TextBox txtWIRightMask;
		private System.Windows.Forms.Label lblSRTLeftAns;
		private System.Windows.Forms.Label lblSRTRightAns;
		private System.Windows.Forms.Label lblWILeftAns;
		private System.Windows.Forms.Label lblWIRightAns;
		private System.Windows.Forms.Label lblSRTLeft;
		private System.Windows.Forms.Label lblWILeft;
		private System.Windows.Forms.Label lblSRTRight;
		private System.Windows.Forms.Label lblWIRight;
		private System.Windows.Forms.Label lblSRTData1;
		private System.Windows.Forms.Label lblSRTData2;
		private System.Windows.Forms.Label lblSRTData3;
		private System.Windows.Forms.Label lblSRTData4;
		private System.Windows.Forms.Label lblWIData2;
		private System.Windows.Forms.Label lblWIData1;
		private System.Windows.Forms.Label lblWIData3;
		private System.Windows.Forms.Label lblWIData6;
		private System.Windows.Forms.Label lblWIData4;
		private System.Windows.Forms.Label lblWIData5;
		private System.Windows.Forms.Button cmdClear;
		private System.Windows.Forms.Button cmdSave;

		private int[] SRTThresh;
		private int[] SRTMask;
		private int[] WIScore;
		private int[] WILevel;
		private int[] WIMask;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SpeechAudiometry()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			SRTThresh = new int[2];
			SRTMask = new int[2];
			WIScore = new int[2];
			WILevel = new int[2];
			WIMask = new int[2];
			this.Visible = false;
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
			this.lblSRTLabel = new System.Windows.Forms.Label();
			this.lblWILabel = new System.Windows.Forms.Label();
			this.txtSRTLeftThresh = new System.Windows.Forms.TextBox();
			this.txtSRTLeftMask = new System.Windows.Forms.TextBox();
			this.txtSRTRightThresh = new System.Windows.Forms.TextBox();
			this.txtSRTRightMask = new System.Windows.Forms.TextBox();
			this.txtWILeftScore = new System.Windows.Forms.TextBox();
			this.txtWILeftLevel = new System.Windows.Forms.TextBox();
			this.txtWILeftMask = new System.Windows.Forms.TextBox();
			this.txtWIRightScore = new System.Windows.Forms.TextBox();
			this.txtWIRightLevel = new System.Windows.Forms.TextBox();
			this.txtWIRightMask = new System.Windows.Forms.TextBox();
			this.cmdSave = new System.Windows.Forms.Button();
			this.lblSRTLeftAns = new System.Windows.Forms.Label();
			this.lblSRTRightAns = new System.Windows.Forms.Label();
			this.lblWILeftAns = new System.Windows.Forms.Label();
			this.lblWIRightAns = new System.Windows.Forms.Label();
			this.lblSRTLeft = new System.Windows.Forms.Label();
			this.lblWILeft = new System.Windows.Forms.Label();
			this.lblSRTRight = new System.Windows.Forms.Label();
			this.lblWIRight = new System.Windows.Forms.Label();
			this.lblSRTData1 = new System.Windows.Forms.Label();
			this.lblSRTData2 = new System.Windows.Forms.Label();
			this.lblSRTData3 = new System.Windows.Forms.Label();
			this.lblSRTData4 = new System.Windows.Forms.Label();
			this.lblWIData2 = new System.Windows.Forms.Label();
			this.lblWIData1 = new System.Windows.Forms.Label();
			this.lblWIData3 = new System.Windows.Forms.Label();
			this.lblWIData6 = new System.Windows.Forms.Label();
			this.lblWIData4 = new System.Windows.Forms.Label();
			this.lblWIData5 = new System.Windows.Forms.Label();
			this.cmdClear = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblSRTLabel
			// 
			this.lblSRTLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblSRTLabel.Location = new System.Drawing.Point(0, 160);
			this.lblSRTLabel.Name = "lblSRTLabel";
			this.lblSRTLabel.Size = new System.Drawing.Size(248, 24);
			this.lblSRTLabel.TabIndex = 0;
			this.lblSRTLabel.Text = "Speech Recognition Threshold";
			// 
			// lblWILabel
			// 
			this.lblWILabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblWILabel.Location = new System.Drawing.Point(0, 8);
			this.lblWILabel.Name = "lblWILabel";
			this.lblWILabel.Size = new System.Drawing.Size(160, 24);
			this.lblWILabel.TabIndex = 1;
			this.lblWILabel.Text = "Word Identification";
			// 
			// txtSRTLeftThresh
			// 
			this.txtSRTLeftThresh.Location = new System.Drawing.Point(56, 192);
			this.txtSRTLeftThresh.Name = "txtSRTLeftThresh";
			this.txtSRTLeftThresh.Size = new System.Drawing.Size(40, 20);
			this.txtSRTLeftThresh.TabIndex = 2;
			this.txtSRTLeftThresh.Text = "";
			this.txtSRTLeftThresh.TextChanged += new System.EventHandler(this.txtSRTLeftThresh_TextChanged);
			// 
			// txtSRTLeftMask
			// 
			this.txtSRTLeftMask.Location = new System.Drawing.Point(200, 192);
			this.txtSRTLeftMask.Name = "txtSRTLeftMask";
			this.txtSRTLeftMask.Size = new System.Drawing.Size(40, 20);
			this.txtSRTLeftMask.TabIndex = 3;
			this.txtSRTLeftMask.Text = "";
			this.txtSRTLeftMask.TextChanged += new System.EventHandler(this.txtSRTLeftMask_TextChanged);
			// 
			// txtSRTRightThresh
			// 
			this.txtSRTRightThresh.Location = new System.Drawing.Point(56, 248);
			this.txtSRTRightThresh.Name = "txtSRTRightThresh";
			this.txtSRTRightThresh.Size = new System.Drawing.Size(40, 20);
			this.txtSRTRightThresh.TabIndex = 4;
			this.txtSRTRightThresh.Text = "";
			this.txtSRTRightThresh.TextChanged += new System.EventHandler(this.txtSRTRightThresh_TextChanged);
			// 
			// txtSRTRightMask
			// 
			this.txtSRTRightMask.Location = new System.Drawing.Point(200, 248);
			this.txtSRTRightMask.Name = "txtSRTRightMask";
			this.txtSRTRightMask.Size = new System.Drawing.Size(40, 20);
			this.txtSRTRightMask.TabIndex = 5;
			this.txtSRTRightMask.Text = "";
			this.txtSRTRightMask.TextChanged += new System.EventHandler(this.txtSRTRightMask_TextChanged);
			// 
			// txtWILeftScore
			// 
			this.txtWILeftScore.Location = new System.Drawing.Point(56, 40);
			this.txtWILeftScore.Name = "txtWILeftScore";
			this.txtWILeftScore.Size = new System.Drawing.Size(40, 20);
			this.txtWILeftScore.TabIndex = 6;
			this.txtWILeftScore.Text = "";
			this.txtWILeftScore.TextChanged += new System.EventHandler(this.txtWILeftScore_TextChanged);
			// 
			// txtWILeftLevel
			// 
			this.txtWILeftLevel.Location = new System.Drawing.Point(160, 40);
			this.txtWILeftLevel.Name = "txtWILeftLevel";
			this.txtWILeftLevel.Size = new System.Drawing.Size(40, 20);
			this.txtWILeftLevel.TabIndex = 7;
			this.txtWILeftLevel.Text = "";
			this.txtWILeftLevel.TextChanged += new System.EventHandler(this.txtWILeftLevel_TextChanged);
			// 
			// txtWILeftMask
			// 
			this.txtWILeftMask.Location = new System.Drawing.Point(304, 40);
			this.txtWILeftMask.Name = "txtWILeftMask";
			this.txtWILeftMask.Size = new System.Drawing.Size(40, 20);
			this.txtWILeftMask.TabIndex = 8;
			this.txtWILeftMask.Text = "";
			this.txtWILeftMask.TextChanged += new System.EventHandler(this.txtWILeftMask_TextChanged);
			// 
			// txtWIRightScore
			// 
			this.txtWIRightScore.Location = new System.Drawing.Point(56, 96);
			this.txtWIRightScore.Name = "txtWIRightScore";
			this.txtWIRightScore.Size = new System.Drawing.Size(40, 20);
			this.txtWIRightScore.TabIndex = 9;
			this.txtWIRightScore.Text = "";
			this.txtWIRightScore.TextChanged += new System.EventHandler(this.txtWIRightScore_TextChanged);
			// 
			// txtWIRightLevel
			// 
			this.txtWIRightLevel.Location = new System.Drawing.Point(160, 96);
			this.txtWIRightLevel.Name = "txtWIRightLevel";
			this.txtWIRightLevel.Size = new System.Drawing.Size(40, 20);
			this.txtWIRightLevel.TabIndex = 10;
			this.txtWIRightLevel.Text = "";
			this.txtWIRightLevel.TextChanged += new System.EventHandler(this.txtWIRightLevel_TextChanged);
			// 
			// txtWIRightMask
			// 
			this.txtWIRightMask.Location = new System.Drawing.Point(304, 96);
			this.txtWIRightMask.Name = "txtWIRightMask";
			this.txtWIRightMask.Size = new System.Drawing.Size(40, 20);
			this.txtWIRightMask.TabIndex = 11;
			this.txtWIRightMask.Text = "";
			this.txtWIRightMask.TextChanged += new System.EventHandler(this.txtWIRightMask_TextChanged);
			// 
			// cmdSave
			// 
			this.cmdSave.Location = new System.Drawing.Point(280, 256);
			this.cmdSave.Name = "cmdSave";
			this.cmdSave.Size = new System.Drawing.Size(80, 32);
			this.cmdSave.TabIndex = 12;
			this.cmdSave.Text = "Save";
			this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
			// 
			// lblSRTLeftAns
			// 
			this.lblSRTLeftAns.Location = new System.Drawing.Point(24, 224);
			this.lblSRTLeftAns.Name = "lblSRTLeftAns";
			this.lblSRTLeftAns.Size = new System.Drawing.Size(240, 16);
			this.lblSRTLeftAns.TabIndex = 13;
			// 
			// lblSRTRightAns
			// 
			this.lblSRTRightAns.Location = new System.Drawing.Point(24, 280);
			this.lblSRTRightAns.Name = "lblSRTRightAns";
			this.lblSRTRightAns.Size = new System.Drawing.Size(232, 16);
			this.lblSRTRightAns.TabIndex = 14;
			// 
			// lblWILeftAns
			// 
			this.lblWILeftAns.Location = new System.Drawing.Point(56, 72);
			this.lblWILeftAns.Name = "lblWILeftAns";
			this.lblWILeftAns.Size = new System.Drawing.Size(232, 16);
			this.lblWILeftAns.TabIndex = 15;
			// 
			// lblWIRightAns
			// 
			this.lblWIRightAns.Location = new System.Drawing.Point(56, 128);
			this.lblWIRightAns.Name = "lblWIRightAns";
			this.lblWIRightAns.Size = new System.Drawing.Size(232, 16);
			this.lblWIRightAns.TabIndex = 16;
			// 
			// lblSRTLeft
			// 
			this.lblSRTLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblSRTLeft.Location = new System.Drawing.Point(8, 192);
			this.lblSRTLeft.Name = "lblSRTLeft";
			this.lblSRTLeft.Size = new System.Drawing.Size(32, 24);
			this.lblSRTLeft.TabIndex = 17;
			this.lblSRTLeft.Text = "Left";
			// 
			// lblWILeft
			// 
			this.lblWILeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblWILeft.Location = new System.Drawing.Point(8, 40);
			this.lblWILeft.Name = "lblWILeft";
			this.lblWILeft.Size = new System.Drawing.Size(40, 24);
			this.lblWILeft.TabIndex = 18;
			this.lblWILeft.Text = "Left";
			// 
			// lblSRTRight
			// 
			this.lblSRTRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblSRTRight.Location = new System.Drawing.Point(8, 248);
			this.lblSRTRight.Name = "lblSRTRight";
			this.lblSRTRight.Size = new System.Drawing.Size(40, 24);
			this.lblSRTRight.TabIndex = 19;
			this.lblSRTRight.Text = "Right";
			// 
			// lblWIRight
			// 
			this.lblWIRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblWIRight.Location = new System.Drawing.Point(8, 96);
			this.lblWIRight.Name = "lblWIRight";
			this.lblWIRight.Size = new System.Drawing.Size(40, 24);
			this.lblWIRight.TabIndex = 20;
			this.lblWIRight.Text = "Right";
			// 
			// lblSRTData1
			// 
			this.lblSRTData1.Location = new System.Drawing.Point(96, 192);
			this.lblSRTData1.Name = "lblSRTData1";
			this.lblSRTData1.Size = new System.Drawing.Size(104, 16);
			this.lblSRTData1.TabIndex = 21;
			this.lblSRTData1.Text = "dB with masking at";
			// 
			// lblSRTData2
			// 
			this.lblSRTData2.Location = new System.Drawing.Point(248, 192);
			this.lblSRTData2.Name = "lblSRTData2";
			this.lblSRTData2.Size = new System.Drawing.Size(24, 16);
			this.lblSRTData2.TabIndex = 22;
			this.lblSRTData2.Text = "dB";
			// 
			// lblSRTData3
			// 
			this.lblSRTData3.Location = new System.Drawing.Point(96, 248);
			this.lblSRTData3.Name = "lblSRTData3";
			this.lblSRTData3.Size = new System.Drawing.Size(104, 16);
			this.lblSRTData3.TabIndex = 23;
			this.lblSRTData3.Text = "dB with masking at";
			// 
			// lblSRTData4
			// 
			this.lblSRTData4.Location = new System.Drawing.Point(248, 248);
			this.lblSRTData4.Name = "lblSRTData4";
			this.lblSRTData4.Size = new System.Drawing.Size(24, 16);
			this.lblSRTData4.TabIndex = 24;
			this.lblSRTData4.Text = "dB";
			// 
			// lblWIData2
			// 
			this.lblWIData2.Location = new System.Drawing.Point(200, 40);
			this.lblWIData2.Name = "lblWIData2";
			this.lblWIData2.Size = new System.Drawing.Size(104, 16);
			this.lblWIData2.TabIndex = 25;
			this.lblWIData2.Text = "dB with masking at";
			// 
			// lblWIData1
			// 
			this.lblWIData1.Location = new System.Drawing.Point(96, 40);
			this.lblWIData1.Name = "lblWIData1";
			this.lblWIData1.Size = new System.Drawing.Size(64, 16);
			this.lblWIData1.TabIndex = 26;
			this.lblWIData1.Text = "% correct at";
			// 
			// lblWIData3
			// 
			this.lblWIData3.Location = new System.Drawing.Point(344, 40);
			this.lblWIData3.Name = "lblWIData3";
			this.lblWIData3.Size = new System.Drawing.Size(24, 16);
			this.lblWIData3.TabIndex = 27;
			this.lblWIData3.Text = "dB";
			// 
			// lblWIData6
			// 
			this.lblWIData6.Location = new System.Drawing.Point(344, 96);
			this.lblWIData6.Name = "lblWIData6";
			this.lblWIData6.Size = new System.Drawing.Size(24, 16);
			this.lblWIData6.TabIndex = 30;
			this.lblWIData6.Text = "dB";
			// 
			// lblWIData4
			// 
			this.lblWIData4.Location = new System.Drawing.Point(96, 96);
			this.lblWIData4.Name = "lblWIData4";
			this.lblWIData4.Size = new System.Drawing.Size(64, 16);
			this.lblWIData4.TabIndex = 29;
			this.lblWIData4.Text = "% correct at";
			// 
			// lblWIData5
			// 
			this.lblWIData5.Location = new System.Drawing.Point(200, 96);
			this.lblWIData5.Name = "lblWIData5";
			this.lblWIData5.Size = new System.Drawing.Size(104, 16);
			this.lblWIData5.TabIndex = 28;
			this.lblWIData5.Text = "dB with masking at";
			// 
			// cmdClear
			// 
			this.cmdClear.Location = new System.Drawing.Point(280, 200);
			this.cmdClear.Name = "cmdClear";
			this.cmdClear.Size = new System.Drawing.Size(80, 32);
			this.cmdClear.TabIndex = 31;
			this.cmdClear.Text = "Clear Input";
			this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
			// 
			// SpeechAudiometry
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(376, 328);
			this.ControlBox = false;
			this.Controls.Add(this.cmdClear);
			this.Controls.Add(this.lblWIData6);
			this.Controls.Add(this.lblWIData4);
			this.Controls.Add(this.lblWIData5);
			this.Controls.Add(this.lblWIData3);
			this.Controls.Add(this.lblWIData1);
			this.Controls.Add(this.lblWIData2);
			this.Controls.Add(this.lblSRTData4);
			this.Controls.Add(this.lblSRTData3);
			this.Controls.Add(this.lblSRTData2);
			this.Controls.Add(this.lblSRTData1);
			this.Controls.Add(this.lblWIRight);
			this.Controls.Add(this.lblSRTRight);
			this.Controls.Add(this.lblWILeft);
			this.Controls.Add(this.lblSRTLeft);
			this.Controls.Add(this.lblWIRightAns);
			this.Controls.Add(this.lblWILeftAns);
			this.Controls.Add(this.lblSRTRightAns);
			this.Controls.Add(this.lblSRTLeftAns);
			this.Controls.Add(this.cmdSave);
			this.Controls.Add(this.txtWIRightMask);
			this.Controls.Add(this.txtWIRightLevel);
			this.Controls.Add(this.txtWIRightScore);
			this.Controls.Add(this.txtWILeftMask);
			this.Controls.Add(this.txtWILeftLevel);
			this.Controls.Add(this.txtWILeftScore);
			this.Controls.Add(this.txtSRTRightMask);
			this.Controls.Add(this.txtSRTRightThresh);
			this.Controls.Add(this.txtSRTLeftMask);
			this.Controls.Add(this.txtSRTLeftThresh);
			this.Controls.Add(this.lblWILabel);
			this.Controls.Add(this.lblSRTLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SpeechAudiometry";
			this.ShowInTaskbar = false;
			this.Text = "Speech Audiometry";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Returns the SRT Threshold for the passed ear
		/// </summary>
		/// <param name="ear">0 = left, 1 = right</param>
		/// <returns>SRT Threshold</returns>
		public int GetSRTThresh(int ear)
		{
			return ((ear == 0) ? SRTThresh[0] : SRTThresh[1]);
		}

		/// <summary>
		/// Returns the SRT Masking level for the nontest ear when passed the nontest ear
		/// </summary>
		/// <param name="ear">The unmasked test ear, 0 = left, 1 = right</param>
		/// <returns>SRT Masking value</returns>
		public int GetSRTMask(int ear)
		{
			return ((ear == 0) ? SRTMask[0] : SRTMask[1]);
		}

		/// <summary>
		/// Returns the WI Score for the passed ear
		/// </summary>
		/// <param name="ear">0 = left, 1 = right</param>
		/// <returns>WI Score</returns>
		public int GetWIScore(int ear)
		{
			return ((ear == 0) ? WIScore[0] : WIScore[1]);
		}

		/// <summary>
		/// Returns the WI Presentation Level for the passed ear
		/// </summary>
		/// <param name="ear"></param>
		/// <returns></returns>
		public int GetWILevel(int ear)
		{
			return ((ear == 0) ? WILevel[0] : WILevel[1]);
		}

		/// <summary>
		/// Returns the WI Masking level of the nontest ear when passed the nontest ear
		/// </summary>
		/// <param name="ear">0 = left, 1 = right</param>
		/// <returns>WI Masking value</returns>
		public int GetWIMask(int ear)
		{
			return ((ear == 0) ? WIMask[0] : WIMask[1]);
		}

		/// <summary>
		/// This function will show the actual pathology on the form
		/// </summary>
		/// <param name="SRTThresh">Size of 2, SRT Thresholds for both ears</param>
		/// <param name="SRTMask">Size of 2, SRT Masking Levels for both ears</param>
		/// <param name="WIScore">Size of 2, WI Percent Correct Score for both ears</param>
		/// <param name="WILevel">Size of 2, WI Presentation Level for both ears</param>
		/// <param name="WIMask">Size of 2, WI Masking Level for both ears</param>
		public void ShowPathology(int[] _SRTThresh, int[] _SRTMask, int[] _WIScore, int[] _WILevel, int[] _WIMask)
		{
			lblSRTLeftAns.Text = _SRTThresh[0].ToString() + " dB with masking at " + _SRTMask[0].ToString() + " dB";
			lblSRTRightAns.Text = _SRTThresh[1].ToString() + " dB with masking at " + _SRTMask[1].ToString() + " dB";
			lblWILeftAns.Text = _WIScore[0].ToString() + "% correct at " + _WILevel[0].ToString() + " dB with masking at " + _WIMask[0].ToString() + " dB";
			lblWIRightAns.Text = _WIScore[1].ToString() + "% correct at " + _WILevel[1].ToString() + " dB with masking at " + _WIMask[1].ToString() + " dB";
		}

		/// <summary>
		/// This hides the pathology on the form
		/// </summary>
		public void HidePathology()
		{
			lblSRTLeftAns.Text = "";
			lblSRTRightAns.Text = "";
			lblWILeftAns.Text = "";
			lblWIRightAns.Text = "";
		}

		/// <summary>
		/// Clears all of the text boxes
		/// </summary>
		private void cmdClear_Click(object sender, System.EventArgs e)
		{
			ClearInput();
		}

		/// <summary>
		/// Clears all of the text boxes
		/// </summary>
		public void ClearInput()
		{
			txtSRTLeftThresh.Text = "";
			txtSRTLeftMask.Text = "";
			txtSRTRightThresh.Text = "";
			txtSRTRightMask.Text = "";
			txtWILeftScore.Text = "";
			txtWILeftLevel.Text = "";
			txtWILeftMask.Text = "";
			txtWIRightScore.Text = "";
			txtWIRightLevel.Text = "";
			txtWIRightMask.Text = "";
		}

		/// <summary>
		/// Saves the input box values to the correct variables
		/// </summary>
		private void cmdSave_Click(object sender, System.EventArgs e)
		{
			SaveAll();
		}

		/// <summary>
		/// Saves the input box values to the correct variables
		/// </summary>
		public void SaveAll()
		{
			if(txtSRTLeftThresh.Text != "" && IsNumeric(txtSRTLeftThresh.Text)) SRTThresh[0] = Convert.ToInt32(txtSRTLeftThresh.Text);
			if(txtSRTLeftMask.Text != "" && IsNumeric(txtSRTLeftMask.Text)) SRTMask[0] = Convert.ToInt32(txtSRTLeftMask.Text);
			if(txtSRTRightThresh.Text != "" && IsNumeric(txtSRTRightThresh.Text)) SRTThresh[1] = Convert.ToInt32(txtSRTRightThresh.Text);
			if(txtSRTRightMask.Text != "" && IsNumeric(txtSRTRightMask.Text)) SRTMask[1] = Convert.ToInt32(txtSRTRightMask.Text);
			if(txtWILeftScore.Text != "" && IsNumeric(txtWILeftScore.Text)) WIScore[0] = Convert.ToInt32(txtWILeftScore.Text);
			if(txtWILeftLevel.Text != "" && IsNumeric(txtWILeftLevel.Text)) WILevel[0] = Convert.ToInt32(txtWILeftLevel.Text);
			if(txtWILeftMask.Text != "" && IsNumeric(txtWILeftMask.Text)) WIMask[0] = Convert.ToInt32(txtWILeftMask.Text);
			if(txtWIRightScore.Text != "" && IsNumeric(txtWIRightScore.Text)) WIScore[1] = Convert.ToInt32(txtWIRightScore.Text);
			if(txtWIRightLevel.Text != "" && IsNumeric(txtWIRightLevel.Text)) WILevel[1] = Convert.ToInt32(txtWIRightLevel.Text);
			if(txtWIRightMask.Text != "" && IsNumeric(txtWIRightMask.Text)) WIMask[1] = Convert.ToInt32(txtWIRightMask.Text);
		}

		/// <summary>
		/// Clears all text boxes and data labels, and zeroes the inputted data variables
		/// </summary>
		public void ResetAll()
		{
			ClearInput();
			HidePathology();
			for(int i = 0; i < 2; i++)
			{
				SRTThresh[i] = 0;
				SRTMask[i] = 0;
				WIScore[i] = 0;
				WILevel[i] = 0;
				WIMask[i] = 0;
			}
		}

		/// <summary>
		/// Returns true if Text contains only numbers
		/// </summary>
		/// <param name="Text">string for numeric testing</param>
		/// <returns>true if Text is numeric, false otherwise</returns>
		private bool IsNumeric(string Text)
		{
			if(Text.Length == 0) return true;
			char[] temp = new char[Text.Length];
			temp = Text.ToCharArray();
			for(int i = 0; i < Text.Length; i++)
			{
				if(temp[i] < '0' || temp[i] > '9')
				{
					return false;
				}
			}

			return true;
		}

		/// <summary>
		/// Enables or disables the Save button
		/// </summary>
		private void EnableSave()
		{
			 cmdSave.Enabled = IsNumeric(txtSRTLeftThresh.Text) && 
				 IsNumeric(txtSRTLeftMask.Text) && 
				 IsNumeric(txtSRTRightThresh.Text) && 
				 IsNumeric(txtSRTRightMask.Text) && 
				 IsNumeric(txtWILeftScore.Text) && 
				 IsNumeric(txtWILeftLevel.Text) && 
				 IsNumeric(txtWILeftMask.Text) && 
				 IsNumeric(txtWIRightScore.Text) && 
				 IsNumeric(txtWIRightLevel.Text) && 
				 IsNumeric(txtWIRightMask.Text);
		}

		/// <summary>
		/// What is called when a text box's text is changed
		/// </summary>
		private void txtWILeftScore_TextChanged(object sender, System.EventArgs e)
		{
			EnableSave();
		}

		/// <summary>
		/// What is called when a text box's text is changed
		/// </summary>
		private void txtWILeftLevel_TextChanged(object sender, System.EventArgs e)
		{
			EnableSave();
		}

		/// <summary>
		/// What is called when a text box's text is changed
		/// </summary>
		private void txtWILeftMask_TextChanged(object sender, System.EventArgs e)
		{
			EnableSave();
		}

		/// <summary>
		/// What is called when a text box's text is changed
		/// </summary>
		private void txtWIRightScore_TextChanged(object sender, System.EventArgs e)
		{
			EnableSave();
		}

		/// <summary>
		/// What is called when a text box's text is changed
		/// </summary>
		private void txtWIRightLevel_TextChanged(object sender, System.EventArgs e)
		{
			EnableSave();
		}

		/// <summary>
		/// What is called when a text box's text is changed
		/// </summary>
		private void txtWIRightMask_TextChanged(object sender, System.EventArgs e)
		{
			EnableSave();
		}

		/// <summary>
		/// What is called when a text box's text is changed
		/// </summary>
		private void txtSRTLeftThresh_TextChanged(object sender, System.EventArgs e)
		{
			EnableSave();
		}

		/// <summary>
		/// What is called when a text box's text is changed
		/// </summary>
		private void txtSRTLeftMask_TextChanged(object sender, System.EventArgs e)
		{
			EnableSave();
		}

		/// <summary>
		/// What is called when a text box's text is changed
		/// </summary>
		private void txtSRTRightThresh_TextChanged(object sender, System.EventArgs e)
		{
			EnableSave();
		}

		/// <summary>
		/// What is called when a text box's text is changed
		/// </summary>
		private void txtSRTRightMask_TextChanged(object sender, System.EventArgs e)
		{
			EnableSave();
		}
	}
}
