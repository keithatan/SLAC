using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using Pathology_Dev;

namespace Virtual_Lab
{
	/// <summary>
	/// Summary description for Audiometer.
	/// </summary>
	public class Audiometer : System.Windows.Forms.Form
	{
		/// <summary>
		/// Constants associated with PlaySound
		/// </summary>
		#region Playsound constants
        //public int SND_SYNC            = 0x0000;  // play synchronously (default) 
        //public int SND_ASYNC           = 0x0001;  // play asynchronously 
        //public int SND_NODEFAULT       = 0x0002;  // silence (!default) if sound not found 
        //public int SND_MEMORY          = 0x0004;  // pszSound points to a memory file 
        //public int SND_LOOP            = 0x0008;  // loop the sound until next sndPlaySound 
        //public int SND_NOSTOP          = 0x0010;  // don't stop any currently playing sound 

        //public int SND_NOWAIT      = 0x00002000; // don't wait if the driver is busy 
        //public int SND_ALIAS       = 0x00010000; // name is a registry alias 
        //public int SND_ALIAS_ID    = 0x00110000; // alias is a predefined ID 
        //public int SND_FILENAME    = 0x00020000; // name is file name 
        //public int SND_RESOURCE    = 0x00040004; // name is resource name or atom 
        //public int SND_PURGE           = 0x0040;
		private System.Windows.Forms.Button L_Stim_Tone;
		private System.Windows.Forms.Button L_Stim_Mic;
		private System.Windows.Forms.Button L_Stim_ExtA;
		private System.Windows.Forms.Button L_Stim_ExtB;
		private System.Windows.Forms.Button L_Stim_NB;
		private System.Windows.Forms.Button L_Stim_Speech;
		private System.Windows.Forms.Button L_Stim_White;
		private System.Windows.Forms.Button R_Tran_White;
		private System.Windows.Forms.Button R_Tran_Speech;
		private System.Windows.Forms.Button R_Tran_NB;
		private System.Windows.Forms.Button R_Tran_ExtB;
		private System.Windows.Forms.Button R_Tran_ExtA;
		private System.Windows.Forms.Button R_Tran_Mic;
		private System.Windows.Forms.Button R_Stim_Bone;
		private System.Windows.Forms.Button L_Rout_Both;
		private System.Windows.Forms.Button L_Rout_R;
		private System.Windows.Forms.Button L_Rout_L;
		private System.Windows.Forms.Button L_Tran_Insert;
		private System.Windows.Forms.Button L_Tran_Spkr;
		private System.Windows.Forms.Button L_Tran_Bone;
		private System.Windows.Forms.Button L_Tran_Phone;
		private System.Windows.Forms.Button R_Rout_Both;
		private System.Windows.Forms.Button R_Rout_R;
		private System.Windows.Forms.Button R_Rout_L;
		private System.Windows.Forms.Button R_Tran_Insert;
		private System.Windows.Forms.Button R_Tran_Spkr;
		private System.Windows.Forms.Button R_Tran_Bone;
		private System.Windows.Forms.Button R_Tran_Phone;
		private System.Windows.Forms.Button L_Int;
		private System.Windows.Forms.Button R_Int;
		private System.Windows.Forms.Button L_Pres;
		private System.Windows.Forms.Button R_Pres;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnMic;  // purge non-static events for task 
		//public int SND_APPLICATION     = 0x0080;  // look for application specific association
		#endregion
		
		// wrapper for PlaySound
		[DllImport("WinMM.dll")]
		public static extern bool PlaySound(string fName, long handlePtr, int playFlags);
		
		/// <summary>
		/// All the fields created on the audiometer form
		/// </summary>
		#region Info created on form
		private System.Windows.Forms.Label Left_Channel_Disp;
		private System.Windows.Forms.Label Right_Channel_Disp;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Button Test_Frequency_Up;
		private System.Windows.Forms.Button Test_Frequency_Down;
		private System.Windows.Forms.Button Talk_Forward;
		private System.Windows.Forms.Button Interlock;
		private System.Windows.Forms.Button Tracking;
		private System.Windows.Forms.Label Freq_Disp;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label35;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.Label Ch1RoutLbl;
		private System.Windows.Forms.Label Ch1TransLbl;
		private System.Windows.Forms.Label Ch1StimLbl;
		private System.Windows.Forms.Label Ch2RoutLbl;
		private System.Windows.Forms.Label Ch2TransLbl;
		private System.Windows.Forms.Label Ch2StimLbl;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.Label Ch1Interrupt;
		private System.Windows.Forms.Label Ch2Interrupt;
		private System.Windows.Forms.Label label49;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label50;
		private System.Windows.Forms.Label label51;
		private System.Windows.Forms.Label label52;
		private System.Windows.Forms.Label Interlock_Disp;
		private System.Windows.Forms.Label Tracking_Disp;
		private System.Windows.Forms.Label TForward_Disp;
		private System.Windows.Forms.Button Ch1_knobUp;
		private System.Windows.Forms.Button Ch1_knobDown;
		private System.Windows.Forms.Button Ch2_knobUp;
		private System.Windows.Forms.Button Ch2_knobDown;
		private System.Windows.Forms.Button FM_Select;
		private System.Windows.Forms.Button Pulsed_Select;
		private System.Windows.Forms.TrackBar ch1VUmeter;
		private System.Windows.Forms.TrackBar ch2VUmeter;
		#endregion

		/// <summary>
		/// StimulusType is an enumeration field that will be used to keep track of which 
		/// </summary>
		public enum StimulusType : int 
		{
			None=-1, Tone, Mic, ExtA, ExtB, NB, Speech, White
		}

		public enum TransducerType : int
		{
			None=-1, Phone, Bone, Spkr, Insert
		}

		/// <summary>
		/// audiometerControls is a structure designed to make keeping track of test parameters easier
		/// It also will be accessed by the mdi parent
		/// </summary>
		public struct audiometerSettings
		{
			public int frequency;			
			public bool interlock_select;
			public bool talk_forward_select;
			public bool tracking_select;
			public bool fm_select;
			public bool pulsed_select;
		}

        public struct channelSettings
        {
            public int volume; // dB of tone
            public StimulusType stim; // NB noise, tone, or etc.
            public TransducerType trans; // Phones, bones, or inserts
            public Ear route; // left, right or other
            public bool interrupt; // Masking
        }

		public audiometerSettings ameterSettings = new audiometerSettings();
        public channelSettings Channel1 = new channelSettings();
        public channelSettings Channel2 = new channelSettings();

		// delegates used for feedback to audiometer
		public delegate void presentationDelegate(int testEar);
		public delegate void stateChangedDelegate(bool newTest);

		// latch used to check if the presentation bar has been pressed in the current test settings
		// which in effect "consumates" the test as being run
		bool presentationPressed = false;

		presentationDelegate presDel;
		stateChangedDelegate stChDel;

		// VU meter states
		int ch1VUmeterVal;
		int ch2VUmeterVal;

		// Microphone Variable
		public bool MicOn;

		/// <summary>
		/// The constructor of the audiometer class
		/// </summary>
		/// <param name="_presDel">The delegate function to be called when the presentation bar is pressed</param>
		/// <param name="_stChDel">The delegate function to be called when the audiometer state changes</param>
		public Audiometer(presentationDelegate _presDel, stateChangedDelegate _stChDel)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();								
			//
			// TODO: Add any constructor code after InitializeComponent call
			//

            // Modified by Matt Harris 9/16/2011
            // to include default settings of audiometer used in audiology
            // clinic. Notebook page 12.

            // General audiometer default settings
            ameterSettings.frequency = 1000;
            ameterSettings.interlock_select = false;
            ameterSettings.talk_forward_select = false;
            ameterSettings.tracking_select = false;
            ameterSettings.fm_select = false;
            ameterSettings.pulsed_select = false;
            
            // Channel 1 default settings
            Channel1.volume = 0;
            
            Channel1.trans = TransducerType.Phone;
            Channel1.stim = StimulusType.Tone;
            Channel1.route = Ear.right;
            Channel1.interrupt = false;

            // Channel 2 default settings
            Channel2.volume = -10;
            Channel2.trans = TransducerType.Phone;
            Channel2.stim = StimulusType.NB;
            Channel2.route = Ear.left;
            Channel2.interrupt = false;

            // Other defaults
			presDel = _presDel;
			stChDel = _stChDel;
			MicOn = false;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Audiometer));
            this.Freq_Disp = new System.Windows.Forms.Label();
            this.Left_Channel_Disp = new System.Windows.Forms.Label();
            this.Right_Channel_Disp = new System.Windows.Forms.Label();
            this.Test_Frequency_Up = new System.Windows.Forms.Button();
            this.Test_Frequency_Down = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.Talk_Forward = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.Interlock = new System.Windows.Forms.Button();
            this.Tracking = new System.Windows.Forms.Button();
            this.FM_Select = new System.Windows.Forms.Button();
            this.label34 = new System.Windows.Forms.Label();
            this.Pulsed_Select = new System.Windows.Forms.Button();
            this.label35 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.Ch1RoutLbl = new System.Windows.Forms.Label();
            this.Ch1TransLbl = new System.Windows.Forms.Label();
            this.Ch1StimLbl = new System.Windows.Forms.Label();
            this.Ch2RoutLbl = new System.Windows.Forms.Label();
            this.Ch2TransLbl = new System.Windows.Forms.Label();
            this.Ch2StimLbl = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.Ch1Interrupt = new System.Windows.Forms.Label();
            this.Ch2Interrupt = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TForward_Disp = new System.Windows.Forms.Label();
            this.Tracking_Disp = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.Interlock_Disp = new System.Windows.Forms.Label();
            this.Ch1_knobUp = new System.Windows.Forms.Button();
            this.Ch1_knobDown = new System.Windows.Forms.Button();
            this.Ch2_knobUp = new System.Windows.Forms.Button();
            this.Ch2_knobDown = new System.Windows.Forms.Button();
            this.ch1VUmeter = new System.Windows.Forms.TrackBar();
            this.ch2VUmeter = new System.Windows.Forms.TrackBar();
            this.L_Stim_Tone = new System.Windows.Forms.Button();
            this.L_Stim_Mic = new System.Windows.Forms.Button();
            this.L_Stim_ExtA = new System.Windows.Forms.Button();
            this.L_Stim_ExtB = new System.Windows.Forms.Button();
            this.L_Stim_NB = new System.Windows.Forms.Button();
            this.L_Stim_Speech = new System.Windows.Forms.Button();
            this.L_Stim_White = new System.Windows.Forms.Button();
            this.R_Tran_White = new System.Windows.Forms.Button();
            this.R_Tran_Speech = new System.Windows.Forms.Button();
            this.R_Tran_NB = new System.Windows.Forms.Button();
            this.R_Tran_ExtB = new System.Windows.Forms.Button();
            this.R_Tran_ExtA = new System.Windows.Forms.Button();
            this.R_Tran_Mic = new System.Windows.Forms.Button();
            this.R_Stim_Bone = new System.Windows.Forms.Button();
            this.L_Rout_Both = new System.Windows.Forms.Button();
            this.L_Rout_R = new System.Windows.Forms.Button();
            this.L_Rout_L = new System.Windows.Forms.Button();
            this.L_Tran_Insert = new System.Windows.Forms.Button();
            this.L_Tran_Spkr = new System.Windows.Forms.Button();
            this.L_Tran_Bone = new System.Windows.Forms.Button();
            this.L_Tran_Phone = new System.Windows.Forms.Button();
            this.R_Rout_Both = new System.Windows.Forms.Button();
            this.R_Rout_R = new System.Windows.Forms.Button();
            this.R_Rout_L = new System.Windows.Forms.Button();
            this.R_Tran_Insert = new System.Windows.Forms.Button();
            this.R_Tran_Spkr = new System.Windows.Forms.Button();
            this.R_Tran_Bone = new System.Windows.Forms.Button();
            this.R_Tran_Phone = new System.Windows.Forms.Button();
            this.L_Int = new System.Windows.Forms.Button();
            this.R_Int = new System.Windows.Forms.Button();
            this.L_Pres = new System.Windows.Forms.Button();
            this.R_Pres = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMic = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ch1VUmeter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ch2VUmeter)).BeginInit();
            this.SuspendLayout();
            // 
            // Freq_Disp
            // 
            this.Freq_Disp.BackColor = System.Drawing.Color.Transparent;
            this.Freq_Disp.Font = new System.Drawing.Font("Agency FB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Freq_Disp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Freq_Disp.Location = new System.Drawing.Point(278, 0);
            this.Freq_Disp.Name = "Freq_Disp";
            this.Freq_Disp.Size = new System.Drawing.Size(100, 50);
            this.Freq_Disp.TabIndex = 0;
            this.Freq_Disp.Text = "1000";
            this.Freq_Disp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Left_Channel_Disp
            // 
            this.Left_Channel_Disp.BackColor = System.Drawing.Color.Transparent;
            this.Left_Channel_Disp.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Left_Channel_Disp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Left_Channel_Disp.Location = new System.Drawing.Point(214, 0);
            this.Left_Channel_Disp.Name = "Left_Channel_Disp";
            this.Left_Channel_Disp.Size = new System.Drawing.Size(64, 50);
            this.Left_Channel_Disp.TabIndex = 1;
            this.Left_Channel_Disp.Text = "0";
            this.Left_Channel_Disp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Right_Channel_Disp
            // 
            this.Right_Channel_Disp.BackColor = System.Drawing.Color.Transparent;
            this.Right_Channel_Disp.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Right_Channel_Disp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Right_Channel_Disp.Location = new System.Drawing.Point(372, 0);
            this.Right_Channel_Disp.Name = "Right_Channel_Disp";
            this.Right_Channel_Disp.Size = new System.Drawing.Size(61, 50);
            this.Right_Channel_Disp.TabIndex = 2;
            this.Right_Channel_Disp.Text = "-10";
            this.Right_Channel_Disp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Test_Frequency_Up
            // 
            this.Test_Frequency_Up.BackColor = System.Drawing.Color.Transparent;
            this.Test_Frequency_Up.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Test_Frequency_Up.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Test_Frequency_Up.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Test_Frequency_Up.ForeColor = System.Drawing.Color.Black;
            this.Test_Frequency_Up.Location = new System.Drawing.Point(330, 368);
            this.Test_Frequency_Up.Name = "Test_Frequency_Up";
            this.Test_Frequency_Up.Size = new System.Drawing.Size(41, 20);
            this.Test_Frequency_Up.TabIndex = 35;
            this.Test_Frequency_Up.Text = "+";
            this.Test_Frequency_Up.UseVisualStyleBackColor = false;
            this.Test_Frequency_Up.Click += new System.EventHandler(this.Test_Frequency_Up_Click);
            // 
            // Test_Frequency_Down
            // 
            this.Test_Frequency_Down.BackColor = System.Drawing.Color.Transparent;
            this.Test_Frequency_Down.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Test_Frequency_Down.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Test_Frequency_Down.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Test_Frequency_Down.ForeColor = System.Drawing.Color.Black;
            this.Test_Frequency_Down.Location = new System.Drawing.Point(283, 368);
            this.Test_Frequency_Down.Name = "Test_Frequency_Down";
            this.Test_Frequency_Down.Size = new System.Drawing.Size(41, 20);
            this.Test_Frequency_Down.TabIndex = 36;
            this.Test_Frequency_Down.Text = "-";
            this.Test_Frequency_Down.UseVisualStyleBackColor = false;
            this.Test_Frequency_Down.Click += new System.EventHandler(this.Test_Frequency_Down_Click);
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.SystemColors.Info;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(296, 358);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(68, 8);
            this.label18.TabIndex = 39;
            this.label18.Text = "Test Frequency";
            this.label18.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // Talk_Forward
            // 
            this.Talk_Forward.BackColor = System.Drawing.Color.Transparent;
            this.Talk_Forward.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Talk_Forward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Talk_Forward.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Talk_Forward.ForeColor = System.Drawing.Color.Transparent;
            this.Talk_Forward.Location = new System.Drawing.Point(305, 403);
            this.Talk_Forward.Name = "Talk_Forward";
            this.Talk_Forward.Size = new System.Drawing.Size(43, 16);
            this.Talk_Forward.TabIndex = 40;
            this.Talk_Forward.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Talk_Forward.UseVisualStyleBackColor = false;
            this.Talk_Forward.Click += new System.EventHandler(this.Talk_Forward_Click);
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.SystemColors.Info;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(296, 392);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(66, 8);
            this.label19.TabIndex = 41;
            this.label19.Text = "Talk Forward";
            this.label19.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // Interlock
            // 
            this.Interlock.BackColor = System.Drawing.Color.Transparent;
            this.Interlock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Interlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Interlock.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Interlock.ForeColor = System.Drawing.Color.Transparent;
            this.Interlock.Location = new System.Drawing.Point(261, 339);
            this.Interlock.Name = "Interlock";
            this.Interlock.Size = new System.Drawing.Size(38, 9);
            this.Interlock.TabIndex = 42;
            this.Interlock.Text = "OFF";
            this.Interlock.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Interlock.UseVisualStyleBackColor = false;
            this.Interlock.Click += new System.EventHandler(this.Interlock_Click);
            // 
            // Tracking
            // 
            this.Tracking.BackColor = System.Drawing.Color.Transparent;
            this.Tracking.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Tracking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Tracking.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tracking.ForeColor = System.Drawing.Color.Transparent;
            this.Tracking.Location = new System.Drawing.Point(355, 338);
            this.Tracking.Name = "Tracking";
            this.Tracking.Size = new System.Drawing.Size(42, 11);
            this.Tracking.TabIndex = 43;
            this.Tracking.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Tracking.UseVisualStyleBackColor = false;
            this.Tracking.Click += new System.EventHandler(this.Tracking_Click);
            // 
            // FM_Select
            // 
            this.FM_Select.BackColor = System.Drawing.Color.Transparent;
            this.FM_Select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FM_Select.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FM_Select.ForeColor = System.Drawing.Color.Black;
            this.FM_Select.Location = new System.Drawing.Point(145, 107);
            this.FM_Select.Name = "FM_Select";
            this.FM_Select.Size = new System.Drawing.Size(43, 18);
            this.FM_Select.TabIndex = 77;
            this.FM_Select.Text = "OFF";
            this.FM_Select.UseVisualStyleBackColor = false;
            this.FM_Select.Click += new System.EventHandler(this.FM_Select_Click);
            // 
            // label34
            // 
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(118, 111);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(27, 8);
            this.label34.TabIndex = 78;
            this.label34.Text = "FM";
            this.label34.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // Pulsed_Select
            // 
            this.Pulsed_Select.BackColor = System.Drawing.Color.Transparent;
            this.Pulsed_Select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Pulsed_Select.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pulsed_Select.ForeColor = System.Drawing.Color.Black;
            this.Pulsed_Select.Location = new System.Drawing.Point(145, 129);
            this.Pulsed_Select.Name = "Pulsed_Select";
            this.Pulsed_Select.Size = new System.Drawing.Size(44, 19);
            this.Pulsed_Select.TabIndex = 79;
            this.Pulsed_Select.Text = "OFF";
            this.Pulsed_Select.UseVisualStyleBackColor = false;
            this.Pulsed_Select.Click += new System.EventHandler(this.Pulsed_Select_Click);
            // 
            // label35
            // 
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(108, 136);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(37, 8);
            this.label35.TabIndex = 80;
            this.label35.Text = "Pulsed";
            this.label35.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Agency FB", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(10, 7);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 37);
            this.label15.TabIndex = 81;
            this.label15.Text = "CH 1";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label36
            // 
            this.label36.BackColor = System.Drawing.Color.Transparent;
            this.label36.Location = new System.Drawing.Point(262, 31);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(20, 15);
            this.label36.TabIndex = 82;
            this.label36.Text = "dB";
            // 
            // label37
            // 
            this.label37.BackColor = System.Drawing.Color.Transparent;
            this.label37.Location = new System.Drawing.Point(417, 32);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(20, 15);
            this.label37.TabIndex = 83;
            this.label37.Text = "dB";
            // 
            // label38
            // 
            this.label38.BackColor = System.Drawing.Color.Transparent;
            this.label38.Font = new System.Drawing.Font("Agency FB", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(595, 8);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(54, 37);
            this.label38.TabIndex = 84;
            this.label38.Text = "CH 2";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label39
            // 
            this.label39.BackColor = System.Drawing.Color.Transparent;
            this.label39.Location = new System.Drawing.Point(360, 30);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(20, 15);
            this.label39.TabIndex = 85;
            this.label39.Text = "Hz";
            // 
            // label40
            // 
            this.label40.BackColor = System.Drawing.Color.Transparent;
            this.label40.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.Location = new System.Drawing.Point(58, 4);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(56, 13);
            this.label40.TabIndex = 86;
            this.label40.Text = "Stimulus:";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label41
            // 
            this.label41.BackColor = System.Drawing.Color.Transparent;
            this.label41.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.Location = new System.Drawing.Point(59, 18);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(56, 13);
            this.label41.TabIndex = 87;
            this.label41.Text = "Transducer:";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label42
            // 
            this.label42.BackColor = System.Drawing.Color.Transparent;
            this.label42.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(59, 31);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(56, 13);
            this.label42.TabIndex = 88;
            this.label42.Text = "Routing:";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label43
            // 
            this.label43.BackColor = System.Drawing.Color.Transparent;
            this.label43.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(493, 31);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(56, 13);
            this.label43.TabIndex = 91;
            this.label43.Text = "Routing:";
            this.label43.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label44
            // 
            this.label44.BackColor = System.Drawing.Color.Transparent;
            this.label44.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.Location = new System.Drawing.Point(493, 18);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(56, 13);
            this.label44.TabIndex = 90;
            this.label44.Text = "Transducer:";
            this.label44.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label45
            // 
            this.label45.BackColor = System.Drawing.Color.Transparent;
            this.label45.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(492, 4);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(56, 13);
            this.label45.TabIndex = 89;
            this.label45.Text = "Stimulus:";
            this.label45.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Ch1RoutLbl
            // 
            this.Ch1RoutLbl.BackColor = System.Drawing.Color.Transparent;
            this.Ch1RoutLbl.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ch1RoutLbl.Location = new System.Drawing.Point(119, 32);
            this.Ch1RoutLbl.Name = "Ch1RoutLbl";
            this.Ch1RoutLbl.Size = new System.Drawing.Size(56, 13);
            this.Ch1RoutLbl.TabIndex = 94;
            this.Ch1RoutLbl.Text = "Right";
            // 
            // Ch1TransLbl
            // 
            this.Ch1TransLbl.BackColor = System.Drawing.Color.Transparent;
            this.Ch1TransLbl.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ch1TransLbl.Location = new System.Drawing.Point(119, 19);
            this.Ch1TransLbl.Name = "Ch1TransLbl";
            this.Ch1TransLbl.Size = new System.Drawing.Size(56, 13);
            this.Ch1TransLbl.TabIndex = 93;
            this.Ch1TransLbl.Text = "Phone";
            // 
            // Ch1StimLbl
            // 
            this.Ch1StimLbl.BackColor = System.Drawing.Color.Transparent;
            this.Ch1StimLbl.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ch1StimLbl.Location = new System.Drawing.Point(119, 5);
            this.Ch1StimLbl.Name = "Ch1StimLbl";
            this.Ch1StimLbl.Size = new System.Drawing.Size(56, 13);
            this.Ch1StimLbl.TabIndex = 92;
            this.Ch1StimLbl.Text = "Tone";
            // 
            // Ch2RoutLbl
            // 
            this.Ch2RoutLbl.BackColor = System.Drawing.Color.Transparent;
            this.Ch2RoutLbl.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ch2RoutLbl.Location = new System.Drawing.Point(553, 32);
            this.Ch2RoutLbl.Name = "Ch2RoutLbl";
            this.Ch2RoutLbl.Size = new System.Drawing.Size(47, 13);
            this.Ch2RoutLbl.TabIndex = 97;
            this.Ch2RoutLbl.Text = "Left";
            // 
            // Ch2TransLbl
            // 
            this.Ch2TransLbl.BackColor = System.Drawing.Color.Transparent;
            this.Ch2TransLbl.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ch2TransLbl.Location = new System.Drawing.Point(553, 19);
            this.Ch2TransLbl.Name = "Ch2TransLbl";
            this.Ch2TransLbl.Size = new System.Drawing.Size(40, 13);
            this.Ch2TransLbl.TabIndex = 96;
            this.Ch2TransLbl.Text = "Phone";
            // 
            // Ch2StimLbl
            // 
            this.Ch2StimLbl.BackColor = System.Drawing.Color.Transparent;
            this.Ch2StimLbl.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ch2StimLbl.Location = new System.Drawing.Point(553, 5);
            this.Ch2StimLbl.Name = "Ch2StimLbl";
            this.Ch2StimLbl.Size = new System.Drawing.Size(46, 13);
            this.Ch2StimLbl.TabIndex = 95;
            this.Ch2StimLbl.Text = "NBNoise";
            // 
            // label46
            // 
            this.label46.BackColor = System.Drawing.Color.Transparent;
            this.label46.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(159, 10);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(61, 13);
            this.label46.TabIndex = 99;
            this.label46.Text = "INTERRUPT:";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Ch1Interrupt
            // 
            this.Ch1Interrupt.BackColor = System.Drawing.Color.Transparent;
            this.Ch1Interrupt.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ch1Interrupt.Location = new System.Drawing.Point(157, 24);
            this.Ch1Interrupt.Name = "Ch1Interrupt";
            this.Ch1Interrupt.Size = new System.Drawing.Size(61, 13);
            this.Ch1Interrupt.TabIndex = 101;
            this.Ch1Interrupt.Text = "OFF";
            this.Ch1Interrupt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Ch2Interrupt
            // 
            this.Ch2Interrupt.BackColor = System.Drawing.Color.Transparent;
            this.Ch2Interrupt.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ch2Interrupt.Location = new System.Drawing.Point(447, 24);
            this.Ch2Interrupt.Name = "Ch2Interrupt";
            this.Ch2Interrupt.Size = new System.Drawing.Size(35, 13);
            this.Ch2Interrupt.TabIndex = 103;
            this.Ch2Interrupt.Text = "OFF";
            this.Ch2Interrupt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label49
            // 
            this.label49.BackColor = System.Drawing.Color.Transparent;
            this.label49.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.Location = new System.Drawing.Point(435, 9);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(61, 13);
            this.label49.TabIndex = 102;
            this.label49.Text = "INTERRUPT:";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.TForward_Disp);
            this.panel1.Controls.Add(this.Tracking_Disp);
            this.panel1.Controls.Add(this.label52);
            this.panel1.Controls.Add(this.label51);
            this.panel1.Controls.Add(this.label50);
            this.panel1.Controls.Add(this.Interlock_Disp);
            this.panel1.Location = new System.Drawing.Point(47, 172);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(67, 89);
            this.panel1.TabIndex = 104;
            // 
            // TForward_Disp
            // 
            this.TForward_Disp.BackColor = System.Drawing.Color.Transparent;
            this.TForward_Disp.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TForward_Disp.Location = new System.Drawing.Point(9, 68);
            this.TForward_Disp.Name = "TForward_Disp";
            this.TForward_Disp.Size = new System.Drawing.Size(38, 13);
            this.TForward_Disp.TabIndex = 109;
            this.TForward_Disp.Text = "OFF";
            this.TForward_Disp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Tracking_Disp
            // 
            this.Tracking_Disp.BackColor = System.Drawing.Color.Transparent;
            this.Tracking_Disp.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tracking_Disp.Location = new System.Drawing.Point(-3, 41);
            this.Tracking_Disp.Name = "Tracking_Disp";
            this.Tracking_Disp.Size = new System.Drawing.Size(61, 13);
            this.Tracking_Disp.TabIndex = 108;
            this.Tracking_Disp.Text = "OFF";
            this.Tracking_Disp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label52
            // 
            this.label52.BackColor = System.Drawing.Color.Transparent;
            this.label52.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label52.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.Location = new System.Drawing.Point(5, 55);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(50, 13);
            this.label52.TabIndex = 107;
            this.label52.Text = "Talk Fwd.:";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label51
            // 
            this.label51.BackColor = System.Drawing.Color.Transparent;
            this.label51.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label51.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.Location = new System.Drawing.Point(8, 31);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(45, 8);
            this.label51.TabIndex = 106;
            this.label51.Text = "Tracking:";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label50
            // 
            this.label50.BackColor = System.Drawing.Color.Transparent;
            this.label50.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label50.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.Location = new System.Drawing.Point(9, 1);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(41, 13);
            this.label50.TabIndex = 105;
            this.label50.Text = "Interlock:";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Interlock_Disp
            // 
            this.Interlock_Disp.BackColor = System.Drawing.Color.Transparent;
            this.Interlock_Disp.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Interlock_Disp.Location = new System.Drawing.Point(-3, 15);
            this.Interlock_Disp.Name = "Interlock_Disp";
            this.Interlock_Disp.Size = new System.Drawing.Size(61, 13);
            this.Interlock_Disp.TabIndex = 105;
            this.Interlock_Disp.Text = "OFF";
            this.Interlock_Disp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Ch1_knobUp
            // 
            this.Ch1_knobUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Ch1_knobUp.BackgroundImage")));
            this.Ch1_knobUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Ch1_knobUp.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Ch1_knobUp.Location = new System.Drawing.Point(52, 340);
            this.Ch1_knobUp.Name = "Ch1_knobUp";
            this.Ch1_knobUp.Size = new System.Drawing.Size(55, 25);
            this.Ch1_knobUp.TabIndex = 111;
            this.Ch1_knobUp.Click += new System.EventHandler(this.Ch1_knobUp_Click);
            // 
            // Ch1_knobDown
            // 
            this.Ch1_knobDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Ch1_knobDown.BackgroundImage")));
            this.Ch1_knobDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Ch1_knobDown.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Ch1_knobDown.Location = new System.Drawing.Point(52, 372);
            this.Ch1_knobDown.Name = "Ch1_knobDown";
            this.Ch1_knobDown.Size = new System.Drawing.Size(55, 25);
            this.Ch1_knobDown.TabIndex = 112;
            this.Ch1_knobDown.Click += new System.EventHandler(this.Ch1_knobDown_Click);
            // 
            // Ch2_knobUp
            // 
            this.Ch2_knobUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Ch2_knobUp.BackgroundImage")));
            this.Ch2_knobUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Ch2_knobUp.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Ch2_knobUp.Location = new System.Drawing.Point(551, 347);
            this.Ch2_knobUp.Name = "Ch2_knobUp";
            this.Ch2_knobUp.Size = new System.Drawing.Size(55, 25);
            this.Ch2_knobUp.TabIndex = 113;
            this.Ch2_knobUp.Click += new System.EventHandler(this.Ch2_knobUp_Click);
            // 
            // Ch2_knobDown
            // 
            this.Ch2_knobDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Ch2_knobDown.BackgroundImage")));
            this.Ch2_knobDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Ch2_knobDown.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Ch2_knobDown.Location = new System.Drawing.Point(551, 376);
            this.Ch2_knobDown.Name = "Ch2_knobDown";
            this.Ch2_knobDown.Size = new System.Drawing.Size(55, 25);
            this.Ch2_knobDown.TabIndex = 114;
            this.Ch2_knobDown.Click += new System.EventHandler(this.Ch2_knobDown_Click);
            // 
            // ch1VUmeter
            // 
            this.ch1VUmeter.AutoSize = false;
            this.ch1VUmeter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(169)))), ((int)(((byte)(150)))));
            this.ch1VUmeter.Location = new System.Drawing.Point(14, 44);
            this.ch1VUmeter.Maximum = 20;
            this.ch1VUmeter.Name = "ch1VUmeter";
            this.ch1VUmeter.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ch1VUmeter.Size = new System.Drawing.Size(277, 32);
            this.ch1VUmeter.TabIndex = 119;
            this.ch1VUmeter.Scroll += new System.EventHandler(this.ch1VUmeter_Scroll);
            // 
            // ch2VUmeter
            // 
            this.ch2VUmeter.AutoSize = false;
            this.ch2VUmeter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(169)))), ((int)(((byte)(150)))));
            this.ch2VUmeter.Location = new System.Drawing.Point(374, 44);
            this.ch2VUmeter.Maximum = 20;
            this.ch2VUmeter.Name = "ch2VUmeter";
            this.ch2VUmeter.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ch2VUmeter.Size = new System.Drawing.Size(271, 32);
            this.ch2VUmeter.TabIndex = 120;
            this.ch2VUmeter.Scroll += new System.EventHandler(this.ch2VUmeter_Scroll);
            // 
            // L_Stim_Tone
            // 
            this.L_Stim_Tone.BackColor = System.Drawing.Color.Transparent;
            this.L_Stim_Tone.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("L_Stim_Tone.BackgroundImage")));
            this.L_Stim_Tone.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.L_Stim_Tone.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Stim_Tone.ForeColor = System.Drawing.Color.Black;
            this.L_Stim_Tone.Location = new System.Drawing.Point(206, 108);
            this.L_Stim_Tone.Name = "L_Stim_Tone";
            this.L_Stim_Tone.Size = new System.Drawing.Size(50, 19);
            this.L_Stim_Tone.TabIndex = 149;
            this.L_Stim_Tone.Text = "Tone";
            this.L_Stim_Tone.UseVisualStyleBackColor = false;
            this.L_Stim_Tone.Click += new System.EventHandler(this.L_Stimulus_Tone_Click);
            // 
            // L_Stim_Mic
            // 
            this.L_Stim_Mic.BackColor = System.Drawing.Color.Transparent;
            this.L_Stim_Mic.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("L_Stim_Mic.BackgroundImage")));
            this.L_Stim_Mic.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.L_Stim_Mic.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Stim_Mic.ForeColor = System.Drawing.Color.Black;
            this.L_Stim_Mic.Location = new System.Drawing.Point(206, 130);
            this.L_Stim_Mic.Name = "L_Stim_Mic";
            this.L_Stim_Mic.Size = new System.Drawing.Size(50, 19);
            this.L_Stim_Mic.TabIndex = 150;
            this.L_Stim_Mic.Text = "Mic";
            this.L_Stim_Mic.UseVisualStyleBackColor = false;
            this.L_Stim_Mic.Click += new System.EventHandler(this.L_Stimulus_Mic_Click);
            // 
            // L_Stim_ExtA
            // 
            this.L_Stim_ExtA.BackColor = System.Drawing.Color.Transparent;
            this.L_Stim_ExtA.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("L_Stim_ExtA.BackgroundImage")));
            this.L_Stim_ExtA.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.L_Stim_ExtA.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Stim_ExtA.ForeColor = System.Drawing.Color.Black;
            this.L_Stim_ExtA.Location = new System.Drawing.Point(205, 153);
            this.L_Stim_ExtA.Name = "L_Stim_ExtA";
            this.L_Stim_ExtA.Size = new System.Drawing.Size(50, 19);
            this.L_Stim_ExtA.TabIndex = 151;
            this.L_Stim_ExtA.Text = "ExtA";
            this.L_Stim_ExtA.UseVisualStyleBackColor = false;
            this.L_Stim_ExtA.Click += new System.EventHandler(this.L_Stimulus_ExtA_Click);
            // 
            // L_Stim_ExtB
            // 
            this.L_Stim_ExtB.BackColor = System.Drawing.Color.Transparent;
            this.L_Stim_ExtB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("L_Stim_ExtB.BackgroundImage")));
            this.L_Stim_ExtB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.L_Stim_ExtB.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Stim_ExtB.ForeColor = System.Drawing.Color.Black;
            this.L_Stim_ExtB.Location = new System.Drawing.Point(204, 177);
            this.L_Stim_ExtB.Name = "L_Stim_ExtB";
            this.L_Stim_ExtB.Size = new System.Drawing.Size(50, 19);
            this.L_Stim_ExtB.TabIndex = 152;
            this.L_Stim_ExtB.Text = "ExtB";
            this.L_Stim_ExtB.UseVisualStyleBackColor = false;
            this.L_Stim_ExtB.Click += new System.EventHandler(this.L_Stimulus_ExtB_Click);
            // 
            // L_Stim_NB
            // 
            this.L_Stim_NB.BackColor = System.Drawing.Color.Transparent;
            this.L_Stim_NB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("L_Stim_NB.BackgroundImage")));
            this.L_Stim_NB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.L_Stim_NB.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Stim_NB.ForeColor = System.Drawing.Color.Black;
            this.L_Stim_NB.Location = new System.Drawing.Point(204, 201);
            this.L_Stim_NB.Name = "L_Stim_NB";
            this.L_Stim_NB.Size = new System.Drawing.Size(50, 19);
            this.L_Stim_NB.TabIndex = 153;
            this.L_Stim_NB.Text = "NB";
            this.L_Stim_NB.UseVisualStyleBackColor = false;
            this.L_Stim_NB.Click += new System.EventHandler(this.L_Stimulus_NBNoise_Click);
            // 
            // L_Stim_Speech
            // 
            this.L_Stim_Speech.BackColor = System.Drawing.Color.Transparent;
            this.L_Stim_Speech.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("L_Stim_Speech.BackgroundImage")));
            this.L_Stim_Speech.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.L_Stim_Speech.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Stim_Speech.ForeColor = System.Drawing.Color.Black;
            this.L_Stim_Speech.Location = new System.Drawing.Point(203, 225);
            this.L_Stim_Speech.Name = "L_Stim_Speech";
            this.L_Stim_Speech.Size = new System.Drawing.Size(50, 19);
            this.L_Stim_Speech.TabIndex = 154;
            this.L_Stim_Speech.Text = "Speech";
            this.L_Stim_Speech.UseVisualStyleBackColor = false;
            this.L_Stim_Speech.Click += new System.EventHandler(this.L_Stimulus_SpeechNoise_Click);
            // 
            // L_Stim_White
            // 
            this.L_Stim_White.BackColor = System.Drawing.Color.Transparent;
            this.L_Stim_White.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("L_Stim_White.BackgroundImage")));
            this.L_Stim_White.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.L_Stim_White.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Stim_White.ForeColor = System.Drawing.Color.Black;
            this.L_Stim_White.Location = new System.Drawing.Point(202, 249);
            this.L_Stim_White.Name = "L_Stim_White";
            this.L_Stim_White.Size = new System.Drawing.Size(50, 19);
            this.L_Stim_White.TabIndex = 155;
            this.L_Stim_White.Text = "White";
            this.L_Stim_White.UseVisualStyleBackColor = false;
            this.L_Stim_White.Click += new System.EventHandler(this.L_Stimulus_WhiteNoise_Click);
            // 
            // R_Tran_White
            // 
            this.R_Tran_White.BackColor = System.Drawing.Color.Transparent;
            this.R_Tran_White.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("R_Tran_White.BackgroundImage")));
            this.R_Tran_White.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.R_Tran_White.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.R_Tran_White.ForeColor = System.Drawing.Color.Black;
            this.R_Tran_White.Location = new System.Drawing.Point(411, 250);
            this.R_Tran_White.Name = "R_Tran_White";
            this.R_Tran_White.Size = new System.Drawing.Size(50, 19);
            this.R_Tran_White.TabIndex = 162;
            this.R_Tran_White.Text = "White";
            this.R_Tran_White.UseVisualStyleBackColor = false;
            this.R_Tran_White.Click += new System.EventHandler(this.R_Stimulus_WhiteNoise_Click);
            // 
            // R_Tran_Speech
            // 
            this.R_Tran_Speech.BackColor = System.Drawing.Color.Transparent;
            this.R_Tran_Speech.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("R_Tran_Speech.BackgroundImage")));
            this.R_Tran_Speech.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.R_Tran_Speech.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.R_Tran_Speech.ForeColor = System.Drawing.Color.Black;
            this.R_Tran_Speech.Location = new System.Drawing.Point(411, 226);
            this.R_Tran_Speech.Name = "R_Tran_Speech";
            this.R_Tran_Speech.Size = new System.Drawing.Size(50, 19);
            this.R_Tran_Speech.TabIndex = 161;
            this.R_Tran_Speech.Text = "Speech";
            this.R_Tran_Speech.UseVisualStyleBackColor = false;
            this.R_Tran_Speech.Click += new System.EventHandler(this.R_Stimulus_SpeechNoise_Click);
            // 
            // R_Tran_NB
            // 
            this.R_Tran_NB.BackColor = System.Drawing.Color.Transparent;
            this.R_Tran_NB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("R_Tran_NB.BackgroundImage")));
            this.R_Tran_NB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.R_Tran_NB.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.R_Tran_NB.ForeColor = System.Drawing.Color.Black;
            this.R_Tran_NB.Location = new System.Drawing.Point(411, 202);
            this.R_Tran_NB.Name = "R_Tran_NB";
            this.R_Tran_NB.Size = new System.Drawing.Size(50, 19);
            this.R_Tran_NB.TabIndex = 160;
            this.R_Tran_NB.Text = "NB";
            this.R_Tran_NB.UseVisualStyleBackColor = false;
            this.R_Tran_NB.Click += new System.EventHandler(this.R_Stimulus_NBNoise_Click);
            // 
            // R_Tran_ExtB
            // 
            this.R_Tran_ExtB.BackColor = System.Drawing.Color.Transparent;
            this.R_Tran_ExtB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("R_Tran_ExtB.BackgroundImage")));
            this.R_Tran_ExtB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.R_Tran_ExtB.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.R_Tran_ExtB.ForeColor = System.Drawing.Color.Black;
            this.R_Tran_ExtB.Location = new System.Drawing.Point(410, 178);
            this.R_Tran_ExtB.Name = "R_Tran_ExtB";
            this.R_Tran_ExtB.Size = new System.Drawing.Size(50, 19);
            this.R_Tran_ExtB.TabIndex = 159;
            this.R_Tran_ExtB.Text = "ExtB";
            this.R_Tran_ExtB.UseVisualStyleBackColor = false;
            this.R_Tran_ExtB.Click += new System.EventHandler(this.R_Stimulus_ExtB_Click);
            // 
            // R_Tran_ExtA
            // 
            this.R_Tran_ExtA.BackColor = System.Drawing.Color.Transparent;
            this.R_Tran_ExtA.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("R_Tran_ExtA.BackgroundImage")));
            this.R_Tran_ExtA.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.R_Tran_ExtA.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.R_Tran_ExtA.ForeColor = System.Drawing.Color.Black;
            this.R_Tran_ExtA.Location = new System.Drawing.Point(410, 154);
            this.R_Tran_ExtA.Name = "R_Tran_ExtA";
            this.R_Tran_ExtA.Size = new System.Drawing.Size(50, 19);
            this.R_Tran_ExtA.TabIndex = 158;
            this.R_Tran_ExtA.Text = "ExtA";
            this.R_Tran_ExtA.UseVisualStyleBackColor = false;
            this.R_Tran_ExtA.Click += new System.EventHandler(this.R_Stimulus_ExtA_Click);
            // 
            // R_Tran_Mic
            // 
            this.R_Tran_Mic.BackColor = System.Drawing.Color.Transparent;
            this.R_Tran_Mic.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("R_Tran_Mic.BackgroundImage")));
            this.R_Tran_Mic.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.R_Tran_Mic.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.R_Tran_Mic.ForeColor = System.Drawing.Color.Black;
            this.R_Tran_Mic.Location = new System.Drawing.Point(410, 131);
            this.R_Tran_Mic.Name = "R_Tran_Mic";
            this.R_Tran_Mic.Size = new System.Drawing.Size(50, 19);
            this.R_Tran_Mic.TabIndex = 157;
            this.R_Tran_Mic.Text = "Mic";
            this.R_Tran_Mic.UseVisualStyleBackColor = false;
            this.R_Tran_Mic.Click += new System.EventHandler(this.R_Stimulus_Mic_Click);
            // 
            // R_Stim_Bone
            // 
            this.R_Stim_Bone.BackColor = System.Drawing.Color.Transparent;
            this.R_Stim_Bone.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("R_Stim_Bone.BackgroundImage")));
            this.R_Stim_Bone.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.R_Stim_Bone.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.R_Stim_Bone.ForeColor = System.Drawing.Color.Black;
            this.R_Stim_Bone.Location = new System.Drawing.Point(409, 109);
            this.R_Stim_Bone.Name = "R_Stim_Bone";
            this.R_Stim_Bone.Size = new System.Drawing.Size(50, 19);
            this.R_Stim_Bone.TabIndex = 156;
            this.R_Stim_Bone.Text = "Tone";
            this.R_Stim_Bone.UseVisualStyleBackColor = false;
            this.R_Stim_Bone.Click += new System.EventHandler(this.R_Stimulus_Tone_Click);
            // 
            // L_Rout_Both
            // 
            this.L_Rout_Both.BackColor = System.Drawing.Color.Transparent;
            this.L_Rout_Both.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("L_Rout_Both.BackgroundImage")));
            this.L_Rout_Both.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.L_Rout_Both.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Rout_Both.ForeColor = System.Drawing.Color.Black;
            this.L_Rout_Both.Location = new System.Drawing.Point(267, 248);
            this.L_Rout_Both.Name = "L_Rout_Both";
            this.L_Rout_Both.Size = new System.Drawing.Size(50, 19);
            this.L_Rout_Both.TabIndex = 169;
            this.L_Rout_Both.Text = "L /R";
            this.L_Rout_Both.UseVisualStyleBackColor = false;
            this.L_Rout_Both.Click += new System.EventHandler(this.L_Routing_Both_Click);
            // 
            // L_Rout_R
            // 
            this.L_Rout_R.BackColor = System.Drawing.Color.Transparent;
            this.L_Rout_R.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("L_Rout_R.BackgroundImage")));
            this.L_Rout_R.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.L_Rout_R.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Rout_R.ForeColor = System.Drawing.Color.Black;
            this.L_Rout_R.Location = new System.Drawing.Point(268, 224);
            this.L_Rout_R.Name = "L_Rout_R";
            this.L_Rout_R.Size = new System.Drawing.Size(50, 19);
            this.L_Rout_R.TabIndex = 168;
            this.L_Rout_R.Text = "Right";
            this.L_Rout_R.UseVisualStyleBackColor = false;
            this.L_Rout_R.Click += new System.EventHandler(this.L_Routing_Right_Click);
            // 
            // L_Rout_L
            // 
            this.L_Rout_L.BackColor = System.Drawing.Color.Transparent;
            this.L_Rout_L.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("L_Rout_L.BackgroundImage")));
            this.L_Rout_L.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.L_Rout_L.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Rout_L.ForeColor = System.Drawing.Color.Black;
            this.L_Rout_L.Location = new System.Drawing.Point(269, 200);
            this.L_Rout_L.Name = "L_Rout_L";
            this.L_Rout_L.Size = new System.Drawing.Size(50, 19);
            this.L_Rout_L.TabIndex = 167;
            this.L_Rout_L.Text = "Left";
            this.L_Rout_L.UseVisualStyleBackColor = false;
            this.L_Rout_L.Click += new System.EventHandler(this.L_Routing_Left_Click);
            // 
            // L_Tran_Insert
            // 
            this.L_Tran_Insert.BackColor = System.Drawing.Color.Transparent;
            this.L_Tran_Insert.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("L_Tran_Insert.BackgroundImage")));
            this.L_Tran_Insert.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.L_Tran_Insert.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Tran_Insert.ForeColor = System.Drawing.Color.Black;
            this.L_Tran_Insert.Location = new System.Drawing.Point(269, 176);
            this.L_Tran_Insert.Name = "L_Tran_Insert";
            this.L_Tran_Insert.Size = new System.Drawing.Size(50, 19);
            this.L_Tran_Insert.TabIndex = 166;
            this.L_Tran_Insert.Text = "Insert";
            this.L_Tran_Insert.UseVisualStyleBackColor = false;
            this.L_Tran_Insert.Click += new System.EventHandler(this.L_Transducer_Insert_Click);
            // 
            // L_Tran_Spkr
            // 
            this.L_Tran_Spkr.BackColor = System.Drawing.Color.Transparent;
            this.L_Tran_Spkr.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("L_Tran_Spkr.BackgroundImage")));
            this.L_Tran_Spkr.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.L_Tran_Spkr.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Tran_Spkr.ForeColor = System.Drawing.Color.Black;
            this.L_Tran_Spkr.Location = new System.Drawing.Point(270, 152);
            this.L_Tran_Spkr.Name = "L_Tran_Spkr";
            this.L_Tran_Spkr.Size = new System.Drawing.Size(50, 19);
            this.L_Tran_Spkr.TabIndex = 165;
            this.L_Tran_Spkr.Text = "Spkr";
            this.L_Tran_Spkr.UseVisualStyleBackColor = false;
            this.L_Tran_Spkr.Click += new System.EventHandler(this.L_Transducer_Spkr_Click);
            // 
            // L_Tran_Bone
            // 
            this.L_Tran_Bone.BackColor = System.Drawing.Color.Transparent;
            this.L_Tran_Bone.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("L_Tran_Bone.BackgroundImage")));
            this.L_Tran_Bone.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.L_Tran_Bone.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Tran_Bone.ForeColor = System.Drawing.Color.Black;
            this.L_Tran_Bone.Location = new System.Drawing.Point(271, 129);
            this.L_Tran_Bone.Name = "L_Tran_Bone";
            this.L_Tran_Bone.Size = new System.Drawing.Size(50, 19);
            this.L_Tran_Bone.TabIndex = 164;
            this.L_Tran_Bone.Text = "Bone";
            this.L_Tran_Bone.UseVisualStyleBackColor = false;
            this.L_Tran_Bone.Click += new System.EventHandler(this.L_Transducer_Bone_Click);
            // 
            // L_Tran_Phone
            // 
            this.L_Tran_Phone.BackColor = System.Drawing.Color.Transparent;
            this.L_Tran_Phone.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("L_Tran_Phone.BackgroundImage")));
            this.L_Tran_Phone.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.L_Tran_Phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Tran_Phone.ForeColor = System.Drawing.Color.Black;
            this.L_Tran_Phone.Location = new System.Drawing.Point(271, 107);
            this.L_Tran_Phone.Name = "L_Tran_Phone";
            this.L_Tran_Phone.Size = new System.Drawing.Size(50, 19);
            this.L_Tran_Phone.TabIndex = 163;
            this.L_Tran_Phone.Text = "Phone";
            this.L_Tran_Phone.UseVisualStyleBackColor = false;
            this.L_Tran_Phone.Click += new System.EventHandler(this.L_Transducer_Phones_Click);
            // 
            // R_Rout_Both
            // 
            this.R_Rout_Both.BackColor = System.Drawing.Color.Transparent;
            this.R_Rout_Both.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("R_Rout_Both.BackgroundImage")));
            this.R_Rout_Both.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.R_Rout_Both.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.R_Rout_Both.ForeColor = System.Drawing.Color.Black;
            this.R_Rout_Both.Location = new System.Drawing.Point(341, 249);
            this.R_Rout_Both.Name = "R_Rout_Both";
            this.R_Rout_Both.Size = new System.Drawing.Size(50, 19);
            this.R_Rout_Both.TabIndex = 176;
            this.R_Rout_Both.Text = "L /R";
            this.R_Rout_Both.UseVisualStyleBackColor = false;
            this.R_Rout_Both.Click += new System.EventHandler(this.R_Routing_Both_Click);
            // 
            // R_Rout_R
            // 
            this.R_Rout_R.BackColor = System.Drawing.Color.Transparent;
            this.R_Rout_R.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("R_Rout_R.BackgroundImage")));
            this.R_Rout_R.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.R_Rout_R.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.R_Rout_R.ForeColor = System.Drawing.Color.Black;
            this.R_Rout_R.Location = new System.Drawing.Point(342, 225);
            this.R_Rout_R.Name = "R_Rout_R";
            this.R_Rout_R.Size = new System.Drawing.Size(50, 19);
            this.R_Rout_R.TabIndex = 175;
            this.R_Rout_R.Text = "Right";
            this.R_Rout_R.UseVisualStyleBackColor = false;
            this.R_Rout_R.Click += new System.EventHandler(this.R_Routing_Right_Click);
            // 
            // R_Rout_L
            // 
            this.R_Rout_L.BackColor = System.Drawing.Color.Transparent;
            this.R_Rout_L.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("R_Rout_L.BackgroundImage")));
            this.R_Rout_L.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.R_Rout_L.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.R_Rout_L.ForeColor = System.Drawing.Color.Black;
            this.R_Rout_L.Location = new System.Drawing.Point(343, 201);
            this.R_Rout_L.Name = "R_Rout_L";
            this.R_Rout_L.Size = new System.Drawing.Size(50, 19);
            this.R_Rout_L.TabIndex = 174;
            this.R_Rout_L.Text = "Left";
            this.R_Rout_L.UseVisualStyleBackColor = false;
            this.R_Rout_L.Click += new System.EventHandler(this.R_Routing_Left_Click);
            // 
            // R_Tran_Insert
            // 
            this.R_Tran_Insert.BackColor = System.Drawing.Color.Transparent;
            this.R_Tran_Insert.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("R_Tran_Insert.BackgroundImage")));
            this.R_Tran_Insert.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.R_Tran_Insert.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.R_Tran_Insert.ForeColor = System.Drawing.Color.Black;
            this.R_Tran_Insert.Location = new System.Drawing.Point(343, 177);
            this.R_Tran_Insert.Name = "R_Tran_Insert";
            this.R_Tran_Insert.Size = new System.Drawing.Size(50, 19);
            this.R_Tran_Insert.TabIndex = 173;
            this.R_Tran_Insert.Text = "Insert";
            this.R_Tran_Insert.UseVisualStyleBackColor = false;
            this.R_Tran_Insert.Click += new System.EventHandler(this.R_Transducer_Insert_Click);
            // 
            // R_Tran_Spkr
            // 
            this.R_Tran_Spkr.BackColor = System.Drawing.Color.Transparent;
            this.R_Tran_Spkr.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("R_Tran_Spkr.BackgroundImage")));
            this.R_Tran_Spkr.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.R_Tran_Spkr.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.R_Tran_Spkr.ForeColor = System.Drawing.Color.Black;
            this.R_Tran_Spkr.Location = new System.Drawing.Point(343, 153);
            this.R_Tran_Spkr.Name = "R_Tran_Spkr";
            this.R_Tran_Spkr.Size = new System.Drawing.Size(50, 19);
            this.R_Tran_Spkr.TabIndex = 172;
            this.R_Tran_Spkr.Text = "Spkr";
            this.R_Tran_Spkr.UseVisualStyleBackColor = false;
            this.R_Tran_Spkr.Click += new System.EventHandler(this.R_Transducer_Spkr_Click);
            // 
            // R_Tran_Bone
            // 
            this.R_Tran_Bone.BackColor = System.Drawing.Color.Transparent;
            this.R_Tran_Bone.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("R_Tran_Bone.BackgroundImage")));
            this.R_Tran_Bone.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.R_Tran_Bone.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.R_Tran_Bone.ForeColor = System.Drawing.Color.Black;
            this.R_Tran_Bone.Location = new System.Drawing.Point(343, 130);
            this.R_Tran_Bone.Name = "R_Tran_Bone";
            this.R_Tran_Bone.Size = new System.Drawing.Size(50, 19);
            this.R_Tran_Bone.TabIndex = 171;
            this.R_Tran_Bone.Text = "Bone";
            this.R_Tran_Bone.UseVisualStyleBackColor = false;
            this.R_Tran_Bone.Click += new System.EventHandler(this.R_Transducer_Bone_Click);
            // 
            // R_Tran_Phone
            // 
            this.R_Tran_Phone.BackColor = System.Drawing.Color.Transparent;
            this.R_Tran_Phone.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("R_Tran_Phone.BackgroundImage")));
            this.R_Tran_Phone.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.R_Tran_Phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.R_Tran_Phone.ForeColor = System.Drawing.Color.Black;
            this.R_Tran_Phone.Location = new System.Drawing.Point(342, 108);
            this.R_Tran_Phone.Name = "R_Tran_Phone";
            this.R_Tran_Phone.Size = new System.Drawing.Size(50, 19);
            this.R_Tran_Phone.TabIndex = 170;
            this.R_Tran_Phone.Text = "Phone";
            this.R_Tran_Phone.UseVisualStyleBackColor = false;
            this.R_Tran_Phone.Click += new System.EventHandler(this.R_Transducer_Phones_Click);
            // 
            // L_Int
            // 
            this.L_Int.BackColor = System.Drawing.Color.Transparent;
            this.L_Int.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("L_Int.BackgroundImage")));
            this.L_Int.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.L_Int.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Int.ForeColor = System.Drawing.Color.Black;
            this.L_Int.Location = new System.Drawing.Point(154, 321);
            this.L_Int.Name = "L_Int";
            this.L_Int.Size = new System.Drawing.Size(79, 19);
            this.L_Int.TabIndex = 177;
            this.L_Int.Text = "Interrupt";
            this.L_Int.UseVisualStyleBackColor = false;
            this.L_Int.Click += new System.EventHandler(this.L_Interrupt_Click);
            // 
            // R_Int
            // 
            this.R_Int.BackColor = System.Drawing.Color.Transparent;
            this.R_Int.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("R_Int.BackgroundImage")));
            this.R_Int.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.R_Int.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.R_Int.ForeColor = System.Drawing.Color.Black;
            this.R_Int.Location = new System.Drawing.Point(425, 325);
            this.R_Int.Name = "R_Int";
            this.R_Int.Size = new System.Drawing.Size(79, 19);
            this.R_Int.TabIndex = 178;
            this.R_Int.Text = "Interrupt";
            this.R_Int.UseVisualStyleBackColor = false;
            this.R_Int.Click += new System.EventHandler(this.R_Interrupt_Click);
            // 
            // L_Pres
            // 
            this.L_Pres.BackColor = System.Drawing.Color.Transparent;
            this.L_Pres.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("L_Pres.BackgroundImage")));
            this.L_Pres.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.L_Pres.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Pres.ForeColor = System.Drawing.Color.Black;
            this.L_Pres.Location = new System.Drawing.Point(157, 346);
            this.L_Pres.Name = "L_Pres";
            this.L_Pres.Size = new System.Drawing.Size(38, 71);
            this.L_Pres.TabIndex = 179;
            this.L_Pres.UseVisualStyleBackColor = false;
            this.L_Pres.Click += new System.EventHandler(this.L_Presentation_Bar_Click);
            // 
            // R_Pres
            // 
            this.R_Pres.BackColor = System.Drawing.Color.Transparent;
            this.R_Pres.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("R_Pres.BackgroundImage")));
            this.R_Pres.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.R_Pres.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.R_Pres.ForeColor = System.Drawing.Color.Black;
            this.R_Pres.Location = new System.Drawing.Point(460, 350);
            this.R_Pres.Name = "R_Pres";
            this.R_Pres.Size = new System.Drawing.Size(43, 71);
            this.R_Pres.TabIndex = 180;
            this.R_Pres.UseVisualStyleBackColor = false;
            this.R_Pres.Click += new System.EventHandler(this.R_Presentation_Bar_Click);
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.SystemColors.Info;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(356, 327);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(42, 8);
            this.label21.TabIndex = 45;
            this.label21.Text = "Tracking";
            this.label21.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.SystemColors.Info;
            this.label20.Cursor = System.Windows.Forms.Cursors.Default;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(258, 328);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(42, 8);
            this.label20.TabIndex = 44;
            this.label20.Text = "Interlock";
            this.label20.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(229, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 181;
            this.label1.Text = "Channel 1";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(371, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 182;
            this.label2.Text = "Channel 2";
            // 
            // btnMic
            // 
            this.btnMic.BackColor = System.Drawing.Color.Transparent;
            this.btnMic.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMic.BackgroundImage")));
            this.btnMic.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMic.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMic.ForeColor = System.Drawing.Color.Black;
            this.btnMic.Location = new System.Drawing.Point(561, 107);
            this.btnMic.Name = "btnMic";
            this.btnMic.Size = new System.Drawing.Size(32, 43);
            this.btnMic.TabIndex = 183;
            this.btnMic.UseVisualStyleBackColor = false;
            this.btnMic.Click += new System.EventHandler(this.btnMic_Click);
            // 
            // Audiometer
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(659, 458);
            this.ControlBox = false;
            this.Controls.Add(this.btnMic);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.R_Pres);
            this.Controls.Add(this.L_Pres);
            this.Controls.Add(this.R_Int);
            this.Controls.Add(this.L_Int);
            this.Controls.Add(this.R_Rout_Both);
            this.Controls.Add(this.R_Rout_R);
            this.Controls.Add(this.R_Rout_L);
            this.Controls.Add(this.R_Tran_Insert);
            this.Controls.Add(this.R_Tran_Spkr);
            this.Controls.Add(this.R_Tran_Bone);
            this.Controls.Add(this.R_Tran_Phone);
            this.Controls.Add(this.L_Rout_Both);
            this.Controls.Add(this.L_Rout_R);
            this.Controls.Add(this.L_Rout_L);
            this.Controls.Add(this.L_Tran_Insert);
            this.Controls.Add(this.L_Tran_Spkr);
            this.Controls.Add(this.L_Tran_Bone);
            this.Controls.Add(this.L_Tran_Phone);
            this.Controls.Add(this.R_Tran_White);
            this.Controls.Add(this.R_Tran_Speech);
            this.Controls.Add(this.R_Tran_NB);
            this.Controls.Add(this.R_Tran_ExtB);
            this.Controls.Add(this.R_Tran_ExtA);
            this.Controls.Add(this.R_Tran_Mic);
            this.Controls.Add(this.R_Stim_Bone);
            this.Controls.Add(this.L_Stim_White);
            this.Controls.Add(this.L_Stim_Speech);
            this.Controls.Add(this.L_Stim_NB);
            this.Controls.Add(this.L_Stim_ExtB);
            this.Controls.Add(this.L_Stim_ExtA);
            this.Controls.Add(this.L_Stim_Mic);
            this.Controls.Add(this.L_Stim_Tone);
            this.Controls.Add(this.ch2VUmeter);
            this.Controls.Add(this.ch1VUmeter);
            this.Controls.Add(this.Ch2_knobDown);
            this.Controls.Add(this.Ch2_knobUp);
            this.Controls.Add(this.Ch1_knobDown);
            this.Controls.Add(this.Ch1_knobUp);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Ch2Interrupt);
            this.Controls.Add(this.label49);
            this.Controls.Add(this.Ch1Interrupt);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.Ch2RoutLbl);
            this.Controls.Add(this.Ch2TransLbl);
            this.Controls.Add(this.Ch2StimLbl);
            this.Controls.Add(this.Ch1RoutLbl);
            this.Controls.Add(this.Ch1TransLbl);
            this.Controls.Add(this.Ch1StimLbl);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.Pulsed_Select);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.FM_Select);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.Tracking);
            this.Controls.Add(this.Interlock);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.Talk_Forward);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.Test_Frequency_Down);
            this.Controls.Add(this.Test_Frequency_Up);
            this.Controls.Add(this.Right_Channel_Disp);
            this.Controls.Add(this.Left_Channel_Disp);
            this.Controls.Add(this.Freq_Disp);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(125, 330);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(661, 460);
            this.Name = "Audiometer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Audiometer";
            this.Load += new System.EventHandler(this.Audiometer_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ch1VUmeter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ch2VUmeter)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        /// <summary>
        /// This region contains all the events that can trigger the stChDel(true) statement to be made
        /// </summary>
		#region Set of user actions triggering a new test type
		
		private bool PotentialTestChanged(ref System.Windows.Forms.Label textBox, string newStim)
		{
			if (textBox.Text.Equals("******") || presentationPressed == false)
			{
				textBox.Text = newStim;
				presentationPressed = false;
				return true;
			}
			else if(!textBox.Text.Equals(newStim))
			{
				if (MessageBox.Show("Are you sure you want to start a new test?",
					"New Test", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					stChDel(true);
					textBox.Text = newStim;
					presentationPressed = false;
					return true;
				}
			}
			return false;
		}

		private void L_Stimulus_Tone_Click(object sender, System.EventArgs e)
		{
			if (PotentialTestChanged(ref Ch1StimLbl, "Tone"))
				Channel1.stim = StimulusType.Tone;
		}

		private void L_Stimulus_Mic_Click(object sender, System.EventArgs e)
		{
			if (PotentialTestChanged(ref Ch1StimLbl, "Mic"))
				Channel1.stim = StimulusType.Mic;
		}

		private void L_Stimulus_NBNoise_Click(object sender, System.EventArgs e)
		{
			if (PotentialTestChanged(ref Ch1StimLbl, "NBNoise"))
				Channel1.stim = StimulusType.NB;
		}

		private void L_Stimulus_SpeechNoise_Click(object sender, System.EventArgs e)
		{
			if (PotentialTestChanged(ref Ch1StimLbl, "Speech"))
				Channel1.stim = StimulusType.Speech;
		}

		private void L_Stimulus_WhiteNoise_Click(object sender, System.EventArgs e)
		{
			if (PotentialTestChanged(ref Ch1StimLbl, "White n."))
				Channel1.stim = StimulusType.White;
		}

		private void L_Stimulus_ExtA_Click(object sender, System.EventArgs e)
		{
			if (PotentialTestChanged(ref Ch1StimLbl, "EXT A"))
				Channel1.stim = StimulusType.ExtA;
		}

		private void L_Stimulus_ExtB_Click(object sender, System.EventArgs e)
		{
			if (PotentialTestChanged(ref Ch1StimLbl, "EXT B"))
				Channel1.stim = StimulusType.ExtB;
		}

		private void R_Stimulus_Tone_Click(object sender, System.EventArgs e)
		{
			if (PotentialTestChanged(ref Ch2StimLbl, "Tone"))
				Channel2.stim = StimulusType.Tone;
		}

		private void R_Stimulus_Mic_Click(object sender, System.EventArgs e)
		{
			if (PotentialTestChanged(ref Ch2StimLbl, "Mic"))
				Channel2.stim = StimulusType.Mic;
		}

		private void R_Stimulus_NBNoise_Click(object sender, System.EventArgs e)
		{
			if (PotentialTestChanged(ref Ch2StimLbl, "NBNoise"))
				Channel2.stim = StimulusType.NB;
		}

		private void R_Stimulus_SpeechNoise_Click(object sender, System.EventArgs e)
		{
			if (PotentialTestChanged(ref Ch2StimLbl, "Speech"))
				Channel2.stim = StimulusType.Speech;
		}

		private void R_Stimulus_WhiteNoise_Click(object sender, System.EventArgs e)
		{
			if (PotentialTestChanged(ref Ch2StimLbl, "White n."))
				Channel2.stim = StimulusType.White;
		}

		private void R_Stimulus_ExtA_Click(object sender, System.EventArgs e)
		{
			if (PotentialTestChanged(ref Ch2StimLbl, "EXT A"))
				Channel2.stim = StimulusType.ExtA;
		}

		private void R_Stimulus_ExtB_Click(object sender, System.EventArgs e)
		{
			if (PotentialTestChanged(ref Ch2StimLbl, "EXT B"))
				Channel2.stim = StimulusType.ExtB;
		}
		#endregion


		/// <summary>
		/// This region contains all the events that can trigger the stChDel(false) statement to be made
		/// </summary>
		#region Set of user actions triggering a param changed event
		private void Test_Frequency_Up_Click(object sender, System.EventArgs e)
		{						
			ameterSettings.frequency = ameterSettings.frequency * 2;
			if (ameterSettings.frequency > 8000)
			{
				ameterSettings.frequency = 250;
			}
			Freq_Disp.Text = Convert.ToString(ameterSettings.frequency);

            if (overAudThresh(ref Channel2.volume, Channel2.trans, Channel2.stim, Channel1.interrupt))
                Right_Channel_Disp.Text = Convert.ToString(Channel2.volume);
            if (overAudThresh(ref Channel1.volume, Channel1.trans, Channel1.stim, Channel2.interrupt))
                Left_Channel_Disp.Text = Convert.ToString(Channel1.volume);

			stChDel(false);
		}

		private void Test_Frequency_Down_Click(object sender, System.EventArgs e)
		{
			ameterSettings.frequency = ameterSettings.frequency / 2;
			if (ameterSettings.frequency < 250)
			{
				ameterSettings.frequency = 8000;
			}
			Freq_Disp.Text = Convert.ToString(ameterSettings.frequency);

            if (overAudThresh(ref Channel2.volume, Channel2.trans, Channel2.stim, Channel1.interrupt))
                Right_Channel_Disp.Text = Convert.ToString(Channel2.volume);
            if (overAudThresh(ref Channel1.volume, Channel1.trans, Channel1.stim, Channel2.interrupt))
                Left_Channel_Disp.Text = Convert.ToString(Channel1.volume);

			stChDel(false);
		}

		
		private void PotentialParameterChanged(ref System.Windows.Forms.Label textBox, string newParam)
		{
			if (textBox.Text.Equals("******"))
			{
				textBox.Text = newParam;
			}
			else if(!textBox.Text.Equals(newParam))
			{
				stChDel(false);
				textBox.Text = newParam;
			}
		}

		private void L_Transducer_Phones_Click(object sender, System.EventArgs e)
		{
			PotentialParameterChanged(ref Ch1TransLbl, "Phones");
			Channel1.trans = TransducerType.Phone;

            if (overAudThresh(ref Channel1.volume, Channel1.trans, Channel1.stim, Channel2.interrupt))
                Left_Channel_Disp.Text = Convert.ToString(Channel1.volume);

		}

		private void L_Transducer_Bone_Click(object sender, System.EventArgs e)
		{
			PotentialParameterChanged(ref Ch1TransLbl, "Bone");
            Channel1.trans = TransducerType.Bone;

            if (overAudThresh(ref Channel1.volume, Channel1.trans, Channel1.stim, Channel2.interrupt))
                Left_Channel_Disp.Text = Convert.ToString(Channel1.volume);

		}

		private void L_Transducer_Spkr_Click(object sender, System.EventArgs e)
		{
			PotentialParameterChanged(ref Ch1TransLbl, "Speaker");
            Channel1.trans = TransducerType.Spkr;
		}

		private void L_Transducer_Insert_Click(object sender, System.EventArgs e)
		{
			PotentialParameterChanged(ref Ch1TransLbl, "Insert");
            Channel1.trans = TransducerType.Insert;

            if (overAudThresh(ref Channel1.volume, Channel1.trans, Channel1.stim, Channel2.interrupt))
                Left_Channel_Disp.Text = Convert.ToString(Channel1.volume);

		}

		private void L_Routing_Left_Click(object sender, System.EventArgs e)
		{
			PotentialParameterChanged(ref Ch1RoutLbl, "Left");
            Channel1.route = Ear.left;
		}

		private void L_Routing_Right_Click(object sender, System.EventArgs e)
		{
			PotentialParameterChanged(ref Ch1RoutLbl, "Right");
            Channel1.route = Ear.right;
		}

		private void L_Routing_Both_Click(object sender, System.EventArgs e)
		{
			PotentialParameterChanged(ref Ch1RoutLbl, "L/R");
            Channel1.route = Ear.both;
		}

		private void R_Transducer_Phones_Click(object sender, System.EventArgs e)
		{
			PotentialParameterChanged(ref Ch2TransLbl, "Phones");
            Channel2.trans = TransducerType.Phone;

            if (overAudThresh(ref Channel2.volume, Channel2.trans, Channel2.stim, Channel1.interrupt))
                Right_Channel_Disp.Text = Convert.ToString(Channel2.volume);
		}

		private void R_Transducer_Bone_Click(object sender, System.EventArgs e)
		{
			PotentialParameterChanged(ref Ch2TransLbl, "Bone");
            Channel2.trans = TransducerType.Bone;

            if (overAudThresh(ref Channel2.volume, Channel2.trans, Channel2.stim, Channel1.interrupt))
                Right_Channel_Disp.Text = Convert.ToString(Channel2.volume);
		}

		private void R_Transducer_Spkr_Click(object sender, System.EventArgs e)
		{
			PotentialParameterChanged(ref Ch2TransLbl, "Speaker");
            Channel2.trans = TransducerType.Spkr;

		}

		private void R_Transducer_Insert_Click(object sender, System.EventArgs e)
		{
			PotentialParameterChanged(ref Ch2TransLbl, "Insert");
            Channel2.trans = TransducerType.Insert;
        
            if (overAudThresh(ref Channel2.volume, Channel2.trans, Channel2.stim, Channel1.interrupt))
                Right_Channel_Disp.Text = Convert.ToString(Channel2.volume);
        }

		private void R_Routing_Left_Click(object sender, System.EventArgs e)
		{
			PotentialParameterChanged(ref Ch2RoutLbl, "Left");
            Channel2.route = Ear.left;
		}

		private void R_Routing_Right_Click(object sender, System.EventArgs e)
		{
			PotentialParameterChanged(ref Ch2RoutLbl, "Right");
            Channel2.route = Ear.right;
		}

		private void R_Routing_Both_Click(object sender, System.EventArgs e)
		{
			PotentialParameterChanged(ref Ch2RoutLbl, "L/R");
            Channel2.route = Ear.both;
		}
		#endregion
		
		/// <summary>
		/// This region contains the presentation events
		/// </summary>
		#region Presentation response functions
		private void presDelChannel1() 
		{
			presDel(1);
		}
		private void presDelChannel2()
		{
			presDel(2);
		}


        /// <summary>
        /// This is needed by invoke
        /// </summary>
        /// <param name="text"></param>
        delegate void SetIntCallback(int val);
        private void SafeSetCh1VU(int i)
        {
            if (ch1VUmeter.InvokeRequired)
            {
                SetIntCallback d = new SetIntCallback(SafeSetCh1VU);
                this.Invoke(d, new object[] { i });
            }
            else
            {
                ch1VUmeter.Value = i;
            }
        }
        private void SafeSetCh2VU(int i)
        {
            if (ch2VUmeter.InvokeRequired)
            {
                SetIntCallback d = new SetIntCallback(SafeSetCh2VU);
                this.Invoke(d, new object[] { i });
            }
            else
            {
                ch2VUmeter.Value = i;
            }
        }


		private void PlayToneCh1()
		{
            SafeSetCh1VU(10);
			ch1VUmeterVal = 10;
			try 
			{
                System.Reflection.Assembly thisAssembly = System.Reflection.Assembly.GetExecutingAssembly();
                System.IO.Stream currStream;
                System.Media.SoundPlayer sndPlayer;

                currStream = thisAssembly.GetManifestResourceStream("Virtual_Lab.Sounds.Tones.Tone" + ameterSettings.frequency + ".wav");

                if (currStream != null)
                {
                    sndPlayer = new System.Media.SoundPlayer(currStream);
                    sndPlayer.Play();
                }
			}
			catch(System.Security.SecurityException se)
			{
				/* Security exception - do nothing */
				Console.WriteLine(se.Message);
			}
			if (Ch1Interrupt.Text.Equals("ON") == false)
			{
				//ch1VUmeter.Value = 0; deprecated
                SafeSetCh1VU(0);
				ch1VUmeterVal = 0;
			}
		}

		private void L_Presentation_Bar_Click(object sender, System.EventArgs e)
		{
			// this state is for real (as in not for fake?)
			presentationPressed = true;

			if ( (this.Ch1TransLbl.Text == "Bone") & (this.Ch1RoutLbl.Text == "L/R") )
			{
				MessageBox.Show("Cannot select Bone vibrator & left/right routing!");
				this.Ch1TransLbl.Text = "******";																																																				
			}
			else if( this.Ch1StimLbl.Text == "Tone" && Channel1.interrupt == false)
			{
				// create a thread to play the tone
				Thread t1 = new Thread(new ThreadStart(PlayToneCh1));
				t1.Start();
				t1.Priority = ThreadPriority.AboveNormal;

				// and another to show response
				//Thread t2 = new Thread(new ThreadStart(presDelChannel1));
				//t2.Start();
                presDelChannel1();
			}			  
		}

		private void PlayToneCh2()
		{
			
            //ch2VUmeter.Value = 10;
            SafeSetCh2VU(10);
            ch2VUmeterVal = 10;
			try 
			{
                System.Reflection.Assembly thisAssembly = System.Reflection.Assembly.GetExecutingAssembly();
                System.IO.Stream currStream;
                System.Media.SoundPlayer sndPlayer;

                currStream = thisAssembly.GetManifestResourceStream("Virtual_Lab.Sounds.Tones.Tone" + ameterSettings.frequency + ".wav");

                if (currStream != null)
                {
                    sndPlayer = new System.Media.SoundPlayer(currStream);
                    sndPlayer.Play();
                }
			}
			catch(System.Security.SecurityException se)
			{
				/* Security exception - do nothing */
				Console.WriteLine(se.Message);
			}
			if (!Ch2Interrupt.Text.Equals("ON"))
			{
				//ch2VUmeter.Value = 0;
                SafeSetCh2VU(0);
				ch2VUmeterVal = 0;
			}
		}

		private void R_Presentation_Bar_Click(object sender, System.EventArgs e)
		{
			// this state is for real (as in not for fake?)
			presentationPressed = true;

			if ( (this.Ch2TransLbl.Text == "Bone") & (this.Ch2RoutLbl.Text == "L/R") )
			{
				MessageBox.Show("Cannot select Bone vibrator & left/right routing!");
				this.Ch2TransLbl.Text = "******";																																																				
			}
			else if (this.Ch2StimLbl.Text == "Tone" && Channel2.interrupt == false)
			{
				// create a thread to play tone
				Thread t1 = new Thread(new ThreadStart(PlayToneCh2));
				t1.Start();
				t1.Priority = ThreadPriority.AboveNormal;

				// and another to show response
				//Thread t2 = new Thread(new ThreadStart(presDelChannel2));
				//t2.Start();
                presDelChannel2();
			}
		}
		#endregion


		/// <summary>
		/// This region contains other general setting button callbacks
		/// </summary>
		#region Other button responses
		private void L_Channel_Knob_Up_Click(object sender, System.EventArgs e)
		{
			Channel1.volume += 5;
            if (Channel1.volume >= 120)
			{
				Left_Channel_Disp.Text = "120";
                Channel1.volume = 120;
			}
			else
			{
                Left_Channel_Disp.Text = Convert.ToString(Channel1.volume);
			}
		}

		private void L_Channel_Knob_Down_Click(object sender, System.EventArgs e)
		{
            Channel1.volume -= 5;
            if (Channel1.volume <= -10)
			{
				Left_Channel_Disp.Text = "-10";
                Channel1.volume = -10;
			}

			else
			{
                Left_Channel_Disp.Text = Convert.ToString(Channel1.volume);
			}
		}

		private void R_Channel_Knob_Up_Click(object sender, System.EventArgs e)
		{
			Channel2.volume += 5;
            if (Channel2.volume >= 120)
			{
				Right_Channel_Disp.Text = "120";
                Channel2.volume = 120;
			}
			else
			{
                Right_Channel_Disp.Text = Convert.ToString(Channel2.volume);
			}
		}

		private void R_Channel_Knob_Down_Click(object sender, System.EventArgs e)
		{
            Channel2.volume -= 5;
            if (Channel2.volume <= -10)
			{
				Right_Channel_Disp.Text = "-10";
                Channel2.volume = -10;			
			}
			else
			{
                Right_Channel_Disp.Text = Convert.ToString(Channel2.volume);
			}
		}

		private void Interlock_Click(object sender, System.EventArgs e)
		{
			ameterSettings.interlock_select = !(ameterSettings.interlock_select);
			if (ameterSettings.interlock_select == true)
			{
				this.Interlock_Disp.Text = "ON";
			}
			else
			{
				this.Interlock_Disp.Text = "OFF";
			}
		}

		private void Tracking_Click(object sender, System.EventArgs e)
		{
			ameterSettings.tracking_select = !(ameterSettings.tracking_select);			
			if (ameterSettings.tracking_select == true)
			{
				this.Tracking_Disp.Text = "ON";
			}
			else
			{
				this.Tracking_Disp.Text = "OFF";
			}				
		}

		private void Talk_Forward_Click(object sender, System.EventArgs e)
		{
			ameterSettings.talk_forward_select = !(ameterSettings.talk_forward_select);
			if (ameterSettings.talk_forward_select == true)
			{
				this.TForward_Disp.Text = "ON";
			}
			else
			{
				this.TForward_Disp.Text = "OFF";
			}
		}

		private void L_Interrupt_Click(object sender, System.EventArgs e)
		{
            Channel1.interrupt = !(Channel1.interrupt);
            if (Channel1.interrupt == true)
			{
				this.Ch1Interrupt.Text = "ON";
				//ch1VUmeter.Value = 10; deprecated
                SafeSetCh1VU(10);
				ch1VUmeterVal = 10;
			}
			else
			{
				this.Ch1Interrupt.Text = "OFF";
                //ch1VUmeter.Value = 0;
                SafeSetCh1VU(0);
				ch2VUmeterVal = 0;
            }
            if (overAudThresh(ref Channel2.volume, Channel2.trans, Channel2.stim, false))
                Right_Channel_Disp.Text = Convert.ToString(Channel2.volume);
        }
		
		private void R_Interrupt_Click(object sender, System.EventArgs e)
		{
            Channel2.interrupt = !(Channel2.interrupt);
            if (Channel2.interrupt == true)
			{
				this.Ch2Interrupt.Text = "ON";
				ch2VUmeter.Value = 10;
				ch2VUmeterVal = 10;
			}
			else
			{
				this.Ch2Interrupt.Text = "OFF";
				ch2VUmeter.Value = 0;
				ch2VUmeterVal = 0;
            }
            if (overAudThresh(ref Channel1.volume, Channel1.trans, Channel1.stim, false))
                Left_Channel_Disp.Text = Convert.ToString(Channel1.volume);
		}

		private bool overAudThresh(ref int currVol, TransducerType transducer, StimulusType stimulus, bool OtherChannelInterrupt) 
		{
            #region Speech Stimulus
			if (stimulus == StimulusType.Speech) 
			{
				switch (transducer) 
				{
					case TransducerType.Bone:
						if (currVol > 70) 
						{
							currVol = 70;
							return true;
						}
						break;
					case TransducerType.Phone:
						if (currVol > 110) 
						{
							currVol = 110;
							return true;
						}
						break;
					case TransducerType.Insert:
						if (currVol > 115) 
						{
							currVol = 115;
							return true;
						}
						break;
					default:
						break;
				}
				return false;
			}
            #endregion
			switch (transducer) 
			{
		    case TransducerType.Bone:
				switch (ameterSettings.frequency)
                {
                    #region case 250:
                    case 250:
                        if (currVol > 55) // Bone @ 250 is always 55
				        {
					        currVol = 55;
					        return true;
				        }
                        break;
                    #endregion
                    #region case 500:
                    case 500:
						if (OtherChannelInterrupt)
						{
                            if (currVol > 70) // Bone @ 500 is 70 with interrupt on other channel
                            {
                                currVol = 70;
                                return true;
                            }
						}
                        else if (currVol > 65) // Bone @ 500 is 65 without interrupt on other channel
                        {
                            currVol = 65;
                            return true;
                        }
					    break;
                    #endregion
                    #region case 1000:
                    case 1000:
                        if (OtherChannelInterrupt)
                        {
                            if (currVol > 80) // Bone & 1000 is 80 with interrupt on other channel
                            {
                                currVol = 80;
                                return true;
                            }
                        }
                        else if (currVol > 75) // etc. See Max_Audiometer_Output spreadsheet
                        {
                            currVol = 75;
                            return true;
                        }
                        break;
                    #endregion
                    #region case 2000:
                    case 2000:
                        if (OtherChannelInterrupt)
                        {
                            if (currVol > 85)
                            {
                                currVol = 85;
                                return true;
                            }
                        }
                        else if (currVol > 80)
                        {
                            currVol = 80;
                            return true;
                        }
                        break;
                    #endregion
                    #region case 4000:
                    case 4000:
                    
                        if (OtherChannelInterrupt)
                        {
                            if (currVol > 90)
                            {
                                currVol = 90;
                                return true;
                            }
                        }
                        else if (currVol > 85)
                        {
                            currVol = 85;
                            return true;
                        }
                        break;
                    #endregion
                    #region case 8000:
                    case 8000:
						if (OtherChannelInterrupt)
                        {
                            if (currVol > 50)
                            {
                                currVol = 50;
                                return true;
                            }
                        }
                        else if (currVol > 45)
						{
							currVol = 45;
							return true;
						}
                        break;
                    #endregion
                    #region default: (should never execute)
                    default:
                        // Default to 90 which is the largest bone volume allowed
                        // although, this code should never execute
						if (currVol > 90)
						{
							currVol = 90;
							return true;
                        }
                        break;
                    #endregion
                }
				break;	
			case TransducerType.Insert:
				switch (ameterSettings.frequency)
                {
                    #region case 250:
                    case 250:
                        if (OtherChannelInterrupt)
                        {
                            if (currVol > 100)
                            {
                                currVol = 100;
                                break;
                            }
                        }
                        else if (currVol > 90)
                        {
                            currVol = 90;
                            break;
                        }
                        break;
                    #endregion
                    #region case 500:
                    case 500:
                        if (currVol > 110)
                        {
                            currVol = 110;
                            return true;
                        }
                        break;
                    #endregion
                    #region case 1000, 2000, 4000: (same limits)
                    case 1000:
                    case 2000:
                    case 4000:
                        if (currVol > 115)
                        {
                            currVol = 115;
                            return true;
                        }
                        break;
                    #endregion
                    #region case 8000:
                    case 8000:
                        if (OtherChannelInterrupt)
                        {
                            if (currVol > 85) // Check and verify this is correct
                            { // Intuitively, the interrupt should cause the volume
                              // to be greater than the non-interrupt value, so this
                              // may be incorrect...
                                currVol = 85;
                                return true;
                            }
                        }
                        else if (currVol > 90)
                        {
                            currVol = 90;
                            return true;
                        }
                        break;
                    #endregion
                    #region default: (should never execute)
                    default:
                        // Default to 115 which is the largest insert volume allowed
                        // although, this code should never execute
                        if (currVol > 115)
					    {
						    currVol = 115;
						    return true;
					    }
                        break;
                    #endregion
                }
				break;
			case TransducerType.Phone:
                switch (ameterSettings.frequency)
                {
                    #region case 250:
                    case 250:
                        if (currVol > 105)
                        {
                            currVol = 105;
                            return true;
                        }
                        break;
                    #endregion
                    #region case 500, 1000, 2000, 4000: (same limits)
                    case 500:
                    case 1000:
                    case 2000:
                    case 4000:
                        if (currVol > 120)
                        {
                            currVol = 120;
                            return true;
                        }
                        break;
                    #endregion
                    #region case 8000:
                    case 8000:
                        if (currVol > 105)
                        {
                            currVol = 105;
                            return true;
                        }
                        break;
                    #endregion
                    #region default: (should never execute)
                    default:
                        // Default to 120 which is the largest phones volume allowed
                        // although, this code should never execute
                        if (currVol > 120)
                        {
                            currVol = 120;
                            return true;
                        }
                        break;
                    #endregion
                }
			    break;
			default:
                if (currVol > 120)
                {
                    currVol = 120;
                    return true;
                }
				break;
			}
			return false;
		}

		
		private void checkAudThresh_ch1() 
		{
			if (overAudThresh(ref Channel1.volume, Channel1.trans, Channel1.stim, Channel2.interrupt))
			{
				Left_Channel_Disp.Text = "NR";
				Left_Channel_Disp.Refresh();
				Thread.Sleep(250);
			}
		}

		private void checkAudThresh_ch2()
		{
			if (overAudThresh(ref Channel2.volume, Channel2.trans, Channel2.stim, Channel1.interrupt))
			{
				Right_Channel_Disp.Text = "NR";
				Right_Channel_Disp.Refresh();
				Thread.Sleep(250);
			}
		}

		private void Ch1_knobUp_Click(object sender, System.EventArgs e)
		{
			Channel1.volume += 5;
			checkAudThresh_ch1();
						
			Left_Channel_Disp.Text = Convert.ToString(Channel1.volume);
		}

		private void Ch1_knobDown_Click(object sender, System.EventArgs e)
		{
			Channel1.volume -= 5;
			checkAudThresh_ch1();

			if (Channel1.volume <= -10 )
				Channel1.volume = -10;
    
            Left_Channel_Disp.Text = Convert.ToString(Channel1.volume);
		}

		private void Ch2_knobUp_Click(object sender, System.EventArgs e)
		{
			Channel2.volume += 5;
			checkAudThresh_ch2();

			Right_Channel_Disp.Text = Convert.ToString(Channel2.volume);
		}

		private void Ch2_knobDown_Click(object sender, System.EventArgs e)
		{
			Channel2.volume = Channel2.volume - 5;
			checkAudThresh_ch2();

			if (Channel2.volume <= -10)
				Channel2.volume = -10;			

            Right_Channel_Disp.Text = Convert.ToString(Channel2.volume);
		}

		private void FM_Select_Click(object sender, System.EventArgs e)
		{
			ameterSettings.fm_select = !(ameterSettings.fm_select);
			if (ameterSettings.fm_select == true)
			{
				this.FM_Select.Text = "ON";
			}
			else
			{
				this.FM_Select.Text = "OFF";
			}
		}

		private void Pulsed_Select_Click(object sender, System.EventArgs e)
		{
			ameterSettings.pulsed_select = !(ameterSettings.pulsed_select);
			if (ameterSettings.pulsed_select == true)
			{
				this.Pulsed_Select.Text = "ON";
			}
			else
			{
				this.Pulsed_Select.Text = "OFF";
			}
		}
		#endregion

		private void ch2VUmeter_Scroll(object sender, System.EventArgs e)
		{
			ch2VUmeter.Value = ch2VUmeterVal;
		}

		private void ch1VUmeter_Scroll(object sender, System.EventArgs e)
		{
			//ch1VUmeter.Value = ch1VUmeterVal;

            SafeSetCh1VU(ch1VUmeterVal);
		}

		private void Audiometer_Load(object sender, System.EventArgs e)
		{
            
		}

		private void btnMic_Click(object sender, System.EventArgs e)
		{
			System.Drawing.Bitmap Pressed, Unpressed;
			Pressed = new System.Drawing.Bitmap("pics\\pressed.bmp");
			Unpressed = new System.Drawing.Bitmap("pics\\unpressed.bmp");
			MicOn = !MicOn;
			btnMic.BackgroundImage = (MicOn) ? Pressed : Unpressed;
		}
	}	
}
