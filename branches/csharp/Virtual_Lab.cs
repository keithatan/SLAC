using System;
using System.Drawing;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.Diagnostics;

using Patient;
using Pathology_Dev;
using Audiogram_Dev;
using Plateau_Plot;
//using PatientWindow;
using PatientWindowGif;
using Instructor_Interface;
using SRT;

namespace Virtual_Lab
{
	///	<summary>
	///	The Virtual Lab toplevel
	///	</summary>
    ///	
    public class VirtualLabToplevel	: System.Windows.Forms.Form
    {
        // delete me (click me button)
        private char[] clickme = new char[8];
        // end delete me
	
        private IContainer components;
		private	System.Windows.Forms.MainMenu mainMenu;
		private	System.Windows.Forms.MenuItem menuItem1;
		private	System.Windows.Forms.MenuItem menuNewPat;
		private	System.Windows.Forms.MenuItem menuItem2;
		private	System.Windows.Forms.MenuItem resultsShow;
		private	System.Windows.Forms.MenuItem resultsHidePath;
		private	System.Windows.Forms.MenuItem resultsClear;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem pplotShowHide;
		private System.Windows.Forms.MenuItem menuShowCaseHistory;
		private System.Windows.Forms.SaveFileDialog sFD;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem helpTutorials;

		/// <summary>
		/// User defined variables
		/// </summary>
		// MDI children
		public Patient.Patient pt =	new	Patient.Patient();
		public Plateau_Plot.Plateau_Plot pplot;
		public Audiometer admtr;
		public Audiogram adgrm;
		public PatientWindow ptwind;
        public EvalOutput evalOutput;
		public SRT.SRT srtWind;
		public WI.WI wiWind;

		// previous state data
		private Audiometer.audiometerSettings prevState;

		// test Ear

        Ear testEar;
		//Ear testEar_IA;
		int[] dB;
		ProgramMode programMode;

		// case history form
		CaseHistoryForm chf = new CaseHistoryForm();
		private System.Windows.Forms.MenuItem resultsSave;

		// student information
		StudentInformation si = new StudentInformation();
		DateTime patientStartTime;
		private System.Windows.Forms.MenuItem menuSpeechAudiometry;
		private System.Windows.Forms.MenuItem menuSRT;
		private System.Windows.Forms.MenuItem menuWI;
        private MenuItem menuAbout;
        private MenuItem menuItem6;
        private MenuItem menuExit;
        private MenuItem menuItem5;
        
		// students results
		ResultsInfo ri = new ResultsInfo();

		// program mode enum
		private enum ProgramMode
		{
			Practice, Eval
		}

		/// <summary>
		/// Default Constructor
		/// </summary>
		public VirtualLabToplevel()
		{
			//
			// Required	for	Windows	Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after	InitializeComponent	call
			//
			resultsHidePath.Visible	= false;
			testEar = Ear.neither;
		}

		///	<summary>
		///	Clean up any resources being used.
		///	</summary>
		protected override void	Dispose( bool disposing	)
		{
			if(	disposing )
			{
				if (components != null)	
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing	);
		}

		#region	Windows	Form Designer generated	code
		///	<summary>
		///	Required method	for	Designer support - do not modify
		///	the	contents of	this method	with the code editor.
		///	</summary>
		private	void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuNewPat = new System.Windows.Forms.MenuItem();
            this.menuShowCaseHistory = new System.Windows.Forms.MenuItem();
            this.menuSpeechAudiometry = new System.Windows.Forms.MenuItem();
            this.menuSRT = new System.Windows.Forms.MenuItem();
            this.menuWI = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuExit = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.resultsShow = new System.Windows.Forms.MenuItem();
            this.resultsHidePath = new System.Windows.Forms.MenuItem();
            this.resultsSave = new System.Windows.Forms.MenuItem();
            this.resultsClear = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.pplotShowHide = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.helpTutorials = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuAbout = new System.Windows.Forms.MenuItem();
            this.sFD = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItem3,
            this.menuItem4});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuNewPat,
            this.menuShowCaseHistory,
            this.menuSpeechAudiometry,
            this.menuItem6,
            this.menuExit});
            this.menuItem1.Text = "File";
            // 
            // menuNewPat
            // 
            this.menuNewPat.Index = 0;
            this.menuNewPat.Text = "New Patient";
            this.menuNewPat.Click += new System.EventHandler(this.menuNewPat_Click);
            // 
            // menuShowCaseHistory
            // 
            this.menuShowCaseHistory.Index = 1;
            this.menuShowCaseHistory.Text = "Show Case History";
            this.menuShowCaseHistory.Click += new System.EventHandler(this.menuShowCaseHistory_Click);
            // 
            // menuSpeechAudiometry
            // 
            this.menuSpeechAudiometry.Enabled = false;
            this.menuSpeechAudiometry.Index = 2;
            this.menuSpeechAudiometry.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuSRT,
            this.menuWI});
            this.menuSpeechAudiometry.Text = "Speech Audiometry";
            // 
            // menuSRT
            // 
            this.menuSRT.Index = 0;
            this.menuSRT.Text = "SRT";
            this.menuSRT.Click += new System.EventHandler(this.menuSRT_Click);
            // 
            // menuWI
            // 
            this.menuWI.Index = 1;
            this.menuWI.Text = "WI";
            this.menuWI.Click += new System.EventHandler(this.menuWI_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 3;
            this.menuItem6.Text = "-";
            // 
            // menuExit
            // 
            this.menuExit.Index = 4;
            this.menuExit.Text = "Exit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.resultsShow,
            this.resultsHidePath,
            this.resultsSave,
            this.resultsClear});
            this.menuItem2.Text = "Results";
            // 
            // resultsShow
            // 
            this.resultsShow.Index = 0;
            this.resultsShow.Text = "Show Pathology";
            this.resultsShow.Click += new System.EventHandler(this.resultsShow_Click);
            // 
            // resultsHidePath
            // 
            this.resultsHidePath.Index = 1;
            this.resultsHidePath.Text = "Hide Pathology";
            this.resultsHidePath.Click += new System.EventHandler(this.resultsHidePath_Click);
            // 
            // resultsSave
            // 
            this.resultsSave.Index = 2;
            this.resultsSave.Text = "Save Results";
            this.resultsSave.Click += new System.EventHandler(this.resultsSave_Click);
            // 
            // resultsClear
            // 
            this.resultsClear.Index = 3;
            this.resultsClear.Text = "Clear All";
            this.resultsClear.Click += new System.EventHandler(this.resultsClear_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 2;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.pplotShowHide});
            this.menuItem3.Text = "Plateau Plot";
            // 
            // pplotShowHide
            // 
            this.pplotShowHide.Index = 0;
            this.pplotShowHide.Text = "Show";
            this.pplotShowHide.Click += new System.EventHandler(this.pplotShowHide_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 3;
            this.menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.helpTutorials,
            this.menuItem5,
            this.menuAbout});
            this.menuItem4.Text = "Help";
            // 
            // helpTutorials
            // 
            this.helpTutorials.Index = 0;
            this.helpTutorials.Text = "Tutorials";
            this.helpTutorials.Click += new System.EventHandler(this.helpTutorials_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 1;
            this.menuItem5.Text = "-";
            // 
            // menuAbout
            // 
            this.menuAbout.Index = 2;
            this.menuAbout.Text = "About";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // VirtualLabToplevel
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1028, 733);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.IsMdiContainer = true;
            this.Menu = this.mainMenu;
            this.Name = "VirtualLabToplevel";
            this.Text = "Virtual Masking Lab";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.VirtualLabToplevel_Load);
            this.ResumeLayout(false);

		}
		#endregion

		///	<summary>
		///	The	main entry point for the application.
		///	</summary>
		[STAThread]
		static void	Main() 
		{
			Application.Run(new	VirtualLabToplevel());
		}

		private string buildOutputFile()
		{
			string output;

			// get plotted points
			output = adgrm.GetPlottedPoints(false) + "\n";
			
			// get pathology pts
			if (pt.validPatient) 
			{
				string freqs = string.Empty;
				string threshes = string.Empty;
				string cursors = string.Empty;
				int LBC, RBC, temp;

				for	(int i = 250; i <= 8000; i*=2)
				{
					#region FOR LOOP
					// get the BC values to determine if masking is needed
					LBC = pt.GetPath().BC_Thresh_Val(i, Ear.left);
					RBC = pt.GetPath().BC_Thresh_Val(i, Ear.right);

					// left ear thresh
					temp = pt.GetPath().AC_Thresh_Val(i, Ear.left);
					threshes += temp + ",";
					freqs += i + ",";
					if (temp > RBC + 40)
					{
						// unicode square
						cursors += "\u03A2,";
					}
					else 
					{
						cursors += "AC_Left,";
					}
				
					// right ear thresh
					temp = pt.GetPath().AC_Thresh_Val(i, Ear.right);
					threshes += temp + ((i == 8000) ? "\n" : ",");
					freqs += i + ((i == 8000) ? "\n" : ",");
					if (temp > LBC + 40) 
					{
						// unicode triangle
						cursors += "\u0394" + ((i == 8000) ? "\n" : ",");
					}
					else 
					{
						cursors += "AC_Right" + ((i == 8000) ? "\n" : ",");
					}

					if (i < 8000) 
					{
						threshes += LBC + ",";
						freqs += i + ",";
						if (LBC > RBC + 10) 
						{
							cursors += "],";
						}
						else 
						{
							cursors += "BC_Left,";
						}
				
						threshes += RBC + ",";
						freqs += i + ",";
						if (RBC > LBC + 10) 
						{
							cursors += "[,";
						}
						else 
						{
							cursors += "BC_Right,";
						}
					}
					#endregion
				}

				output += (freqs + threshes + cursors);
			}
			else 
			{
				output += "\n\n\n";
			}

			// get student info
			TimeSpan runTime = DateTime.Now - patientStartTime;
			output += si.stName + ";" + si.stEmail + ";" + si.stID + ";" + 
				si.stCourse + ";" + si.stProf + ";" + DateTime.Now.ToShortDateString() + ";" + 
				runTime + "\n";

			// write Program Mode
			switch (programMode)
			{
				case (int)ProgramMode.Practice:
					output += "Program Mode" + "\n";
					break;
				default:
					output += "Evaluation Mode" + "\n";
					break;
			}

			// get case history
			output += pt.GetPath().CaseHist;

			// get accuracy report
			output += ri.pureToneResults + "\n";

			return output;
		}

		private void saveTestResults() 
		{
			string outputString;

			// parse out hour and am/pm stuff
			int hr = DateTime.Now.Hour;
			string ampm = (hr > 11) ? " pm" : " am";
			hr = (hr > 12) ? hr - 12 : hr;
			hr = (hr == 0) ? 12 : hr;

			sFD = new SaveFileDialog();
			sFD.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
			sFD.FileName = si.stName + " completed at " + hr + "." + DateTime.Now.Minute.ToString("00") + 
				"." + DateTime.Now.Second.ToString("00") + ampm + ".txt";
			sFD.Filter = "Text Files (*.txt)|*.txt";
			sFD.AddExtension = true;

			if (sFD.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			else
			{
				// build file
				outputString = buildOutputFile();

				// save it
				try 
				{
					StreamWriter sw = new StreamWriter(sFD.FileName);
					sw.Write(outputString);
					sw.Close();

					// encrypt it
					EncryptUtil.EncryptFile(sFD.FileName, sFD.FileName + "_e");
					File.Delete(sFD.FileName);
				}
				catch (UnauthorizedAccessException uae)
				{
					MessageBox.Show("Access to this file/drive is denied!  " + uae.Message);
				}
				catch (System.Security.SecurityException se)
				{
					MessageBox.Show("Please run this program locally rather than from a shared drive.  " + 
						se.Message);
				}
				catch (Exception e) 
				{
					MessageBox.Show("Ran into problems of some nature.  " + e.Message);
				}
			}
		}

		private	void presFunc(int testCh)
		{
			// defaults
			//testEar_IA = 0;
			/* assign previous state */
			prevState = admtr.ameterSettings;
			/* handle presentation button */
			if (pt.validPatient) 
			{
				int	patResp	= -1;
                Audiometer.channelSettings TestChannel;
                Audiometer.channelSettings MaskedChannel;

                switch (testCh)
                {
                    case 1:
                        TestChannel = admtr.Channel1;
                        MaskedChannel = admtr.Channel2;
                        break;
                    case 2:
                        TestChannel = admtr.Channel2;
                        MaskedChannel = admtr.Channel1;
                        break;
                    default:
                        // just to have a default, should never execute
                        TestChannel = admtr.Channel1;
                        MaskedChannel = admtr.Channel2;
                        break;
                }
				if ( (testCh == 1 && admtr.Channel1.stim == Audiometer.StimulusType.Tone) ||
					(testCh == 2 &&	admtr.Channel2.stim == Audiometer.StimulusType.Tone)) 
				{
					// test is a pure tone test
					// wait for the tone to finish playing
					Thread.Sleep(500);
					patResp = pureToneTest(TestChannel, MaskedChannel);
				}

                if (programMode == ProgramMode.Eval)
                    evalOutput.CheckMinimum(FrequencyToIndex(admtr.ameterSettings.frequency), TestChannel, MaskedChannel);

				// play	patient	response
                ptwind.ShowAnimation(patResp, pt.returnPatientType());

				// plateau plot
				if (pplot.Visible && 
					(patResp == (int)ResponseType.LeftUnsure || patResp == (int)ResponseType.RightUnsure))
				{
					int minY;
                    // if testing using an air conduction method
                    if (TestChannel.stim == Audiometer.StimulusType.Tone &&
                        (TestChannel.trans == Audiometer.TransducerType.Insert ||
                        TestChannel.trans == Audiometer.TransducerType.Phone))
                    {
                        // set the minimum Y axis value to the air conduction threshold -5
                        minY = pt.GetPath().AC_Thresh_Val(admtr.ameterSettings.frequency, TestChannel.route) - 5;
                    }
                    // if testing using a bone conduction method
                    else if (TestChannel.stim == Audiometer.StimulusType.Tone &&
                        TestChannel.trans == Audiometer.TransducerType.Bone)
                    {
                        // set the minimum Y axis value to the bone conduction threshold -5
                        minY = pt.GetPath().BC_Thresh_Val(admtr.ameterSettings.frequency, TestChannel.route) - 5;
                    }
                    else // Future developers may need to include more coding for other types of tests.
                        minY = 0;

					pplot.Set_Min_Threshold(minY);
					pplot.SetYAxisLabels();
					
					// plot the point
					pplot.PlotDataPt(MaskedChannel.volume, TestChannel.volume);
				}
			}
		}

		///	<summary>
		///	pureToneTest is	used to	control	playing	patients' responses	to pure	tone testing
		///	</summary>
		///	<param name="testCh">which "side" of the audiometer	is used	for	testing</param>
		///	<returns>the patient response</returns>
		private	int	pureToneTest(Audiometer.channelSettings TestChannel, Audiometer.channelSettings MaskedChannel) 
		{
            
			int	patResp	= -1;
            patResp = pt.DetermineResponsePureTone(TestChannel, MaskedChannel, admtr.ameterSettings);

            // Need the "wrong stimuli" message box code from below

            /*
			testEar	= (testCh == (int)Ear.left)	? admtr.Channel1.route : admtr.Channel2.route;
			int	ntEar =	(testEar + 1)%2;
			int	testType;
			
			dB = new int[2];
			//string resString = "";

			if (testCh == (int)Ear.left) 
			{
				// determine whether test is AC	or BC
				testType = (admtr.Channel1.trans == Audiometer.TransducerType.Bone) ?
					(int)TestType.BC : (int)TestType.AC;

				// determine what the IA values	are	for	the	testEar
				

				dB[testEar]	= admtr.ameterSettings.ch1_tone;
				// checks that the ch2 interrupt is selected and the stimulus is NB for masking
				// If interrupt is not selected then set db[ntEar] to a value low enough not to effect the
                // threshold value in the patient response function
                if (admtr.ameterSettings.ch2_interrupt_select == false)
                {
                    dB[ntEar] = -50; // that's pretty low
                }
                dB[ntEar] =	(admtr.ameterSettings.ch2_interrupt_select && 
								admtr.Channel2.stim == Audiometer.StimulusType.NB)	? 
					admtr.ameterSettings.ch2_tone :	0;

				if (admtr.ameterSettings.ch2_interrupt_select && 
					admtr.Channel2.stim != Audiometer.StimulusType.NB)
				{
					// this means that masking isn't set up right -- alert in practice mode
                    MessageBox.Show("Masking is not set up correctly (wrong stimuli)");
					return (int)ResponseType.NoResponse;
				}

				// determine pure tone response
				patResp	= pt.DetermineResponsePureTone(testEar,	admtr.ameterSettings.frequency,	
					testType, IA, dB, ref resString);
			}
			else if	(testCh	== (int)Ear.right) 
			{
				// determine whether test is AC	or BC
				testType = (admtr.Channel2.trans == Audiometer.TransducerType.Bone) ?
					(int)TestType.BC : (int)TestType.AC;

				// determine what the IA values	are	for	the	testEar
				
				dB[testEar]	= admtr.ameterSettings.ch2_tone;
				// checks that the ch1 interrupt is selected and the stimulus is NB for masking
				dB[ntEar] =	(admtr.ameterSettings.ch1_interrupt_select  && 
					admtr.Channel1.stim == Audiometer.StimulusType.NB)	? 
					admtr.ameterSettings.ch1_tone :	0;

				if (admtr.ameterSettings.ch1_interrupt_select && 
					admtr.Channel1.stim != Audiometer.StimulusType.NB)
				{
					// this means that masking isn't set up right -- alert in practice mode
					MessageBox.Show("Masking is not set up correctly (wrong stimuli)");
					return (int)ResponseType.NoResponse;
				}

				// Determine patient's response
				patResp	= pt.DetermineResponsePureTone(testEar,	admtr.ameterSettings.frequency,	
					testType, IA, dB, ref resString);
			}
			else 
			{
				Console.WriteLine("Invalid test	parameters");
				return (int)ResponseType.NoResponse;
			}

			testEar_IA = IA[testEar];
            */
			return patResp;
		}

		private	void stChang(bool newTest)
		{
			// handle settings changed
			// regardless, the plateau plot should be cleared
			pplot.ClearAll();

			if (newTest && pt.validPatient) 
			{
				// this should trigger test complete logic when the time comes
				if (programMode == (int)ProgramMode.Practice) 
				{
					string tType = string.Empty;
					// check which channel is presentation channel
					if ((admtr.Channel1.stim == Audiometer.StimulusType.Tone) ||
						(admtr.Channel2.stim == Audiometer.StimulusType.Tone))
					{
						tType = "Pure Tone Test";
					}
					if ((admtr.Channel1.stim == Audiometer.StimulusType.Speech) ||
						(admtr.Channel2.stim == Audiometer.StimulusType.Speech))
					{
						if (tType.Equals(string.Empty)) 
						{
							tType = "Speech Test";
						}
						else
						{
							tType = "Error";
						}
					}

					if (tType != string.Empty) 
					{
						ri.storePureToneResults(adgrm, pt);
						saveTestResults();
					}
					else
					{
						MessageBox.Show("It doesn't appear that you've performed a pure tone test");
						return;
					}

					if (programMode == (int)ProgramMode.Practice) 
					{
						// instant gratification
						MessageBox.Show(ri.pureToneResults, "Feedback");
					}
				}
			}

			/* assign previous state */
			prevState = admtr.ameterSettings;
		}

		/// <summary>
		/// Writes the status and data of the audiometer to the console
		/// </summary>
		/// <param name="amC">the audiometer controls</param>
        /*
		private void printAmeter(Audiometer.audiometerSettings amC)
		{
			switch (amC.ch1_stim)
			{
				case Audiometer.StimulusType.ExtA:
					Console.WriteLine("Ch1: ExtA");
					break;
				case Audiometer.StimulusType.ExtB:
					Console.WriteLine("Ch1: ExtB");
					break;
				case Audiometer.StimulusType.Mic:
					Console.WriteLine("Ch1: Mic");
					break;
				case Audiometer.StimulusType.NB:
					Console.WriteLine("Ch1: NB");
					break;
				case Audiometer.StimulusType.None:
					Console.WriteLine("Ch1: None");
					break;
				case Audiometer.StimulusType.Speech:
					Console.WriteLine("Ch1: Speech");
					break;
				case Audiometer.StimulusType.Tone:
					Console.WriteLine("Ch1: Tone");
					break;
				case Audiometer.StimulusType.White:
					Console.WriteLine("Ch1: White");
					break;
				default:
					Console.WriteLine("Ch1: Somethun screwy");
					break;
			}

			switch (amC.ch2_stim)
			{
				case Audiometer.StimulusType.ExtA:
					Console.WriteLine("Ch2: ExtA");
					break;
				case Audiometer.StimulusType.ExtB:
					Console.WriteLine("Ch2: ExtB");
					break;
				case Audiometer.StimulusType.Mic:
					Console.WriteLine("Ch2: Mic");
					break;
				case Audiometer.StimulusType.NB:
					Console.WriteLine("Ch2: NB");
					break;
				case Audiometer.StimulusType.None:
					Console.WriteLine("Ch2: None");
					break;
				case Audiometer.StimulusType.Speech:
					Console.WriteLine("Ch2: Speech");
					break;
				case Audiometer.StimulusType.Tone:
					Console.WriteLine("Ch2: Tone");
					break;
				case Audiometer.StimulusType.White:
					Console.WriteLine("Ch2: White");
					break;
				default:
					Console.WriteLine("Ch2: Somethun screwy");
					break;
			}
		}
        */
		/// <summary>
		/// This function will be a delegate to Speech Audiometry that will enable the speech menu when Done is clicked.
		/// </summary>
		private void EnableSpeechMenu()
		{
			menuSpeechAudiometry.Enabled = true;
		}

		/// <summary>
		/// This function will make the patient window respond to the SRT stimuli
		/// </summary>
		/// <param name="Word">Which word was said</param>
		private bool DoResponse(String Word, String Type)
		{
            // This function has to do with SRT and WI. Commented out for now.
    /*
			if(    (admtr.MicOn == false)
				|| (admtr.Channel1.stim != Audiometer.StimulusType.Mic)
				|| (admtr.Channel1.trans == Audiometer.TransducerType.None)
				|| !(admtr.Channel1.volume >= -10)
				|| ((int)admtr.Channel1.route > 1)
				|| ((int)admtr.Channel1.route < 0))
			{
				return false;
			}
			else
			{
				int testEar = (int)admtr.Channel1.route;
				int ntEar = (testEar+1) % 2;

				// dB Levels
				int[] dBLevels = new int[2];
				dBLevels[testEar] = (admtr.ameterSettings.ch1_tone >= -10) ? admtr.ameterSettings.ch1_tone : -50;
				dBLevels[ntEar] = (admtr.ameterSettings.ch2_interrupt_select && 
					admtr.Channel2.stim == Audiometer.StimulusType.NB) ? 
					admtr.ameterSettings.ch2_tone :	0;

				// IA levels
				int[] IA = new int[2];
				switch (admtr.Channel1.trans)
				{
					case Audiometer.TransducerType.Phone:
						IA[testEar]	= 40;
						break;
					case Audiometer.TransducerType.Insert:
						IA[testEar]	= 60;
						break;
					default:
						IA[testEar]	= 0;
						break;
				}
				switch (admtr.Channel2.trans)
				{
					case Audiometer.TransducerType.Phone:
						IA[ntEar] = 40;
						break;
					case Audiometer.TransducerType.Insert:
						IA[ntEar] = 60;
						break;
					default:
						IA[ntEar] = 0;
						break;
				}

				int resp = (int)SpeechRespType.Incorrect;
				resp = pt.DetermineResponseSpeech(testEar, Type, IA, dBLevels);
				if(resp == (int)SpeechRespType.Correct)
				{
					ptwind.PatientSpeechRespond(Word);
				}
				else if(resp == (int)SpeechRespType.Unsure)
				{
					ptwind.PatientSpeechRespond("DontKnow");
				}
     */
//			}

            return true;
		}

		/// <summary>
		/// Called when the whole program first loads
		/// </summary>
		private	void VirtualLabToplevel_Load(object	sender,	System.EventArgs e)
		{
			// Display a "WELCOME SCREEN" allowing the user to chose the program type
			WelcomeScreen ws = new WelcomeScreen();
            DialogResult dResult = ws.ShowDialog();
            switch (dResult)
			{
                
				case DialogResult.Yes:  // practice mode
					programMode = ProgramMode.Practice;
					this.Text += " Practice Mode";
					break;
				case DialogResult.No:	// evaluation mode
					programMode = ProgramMode.Eval;
					resultsShow.Visible = false;
                    pplotShowHide.Enabled = false;
					this.Text += " Evaluation Mode";
                    pplotShowHide.Enabled = false;
					break;
			}

            if (dResult != DialogResult.Cancel)
            {

                // get student parameters
                si.stName = ws.stName;
                si.stID = ws.stID;
                si.stCourse = ws.stCourse;
                si.stEmail = ws.stEmail;
                si.stProf = ws.stProf;

                // show the students name in title (if available
                if (si.stName != string.Empty)
                    Text += "                                             Clinician: " + si.stName;

                // construct and show children
                admtr = new Audiometer(
                    new Audiometer.presentationDelegate(presFunc),
                    new Audiometer.stateChangedDelegate(stChang));
                admtr.MdiParent = this;
                admtr.Show();
                admtr.Location = new Point(0, 0);
                admtr.Size = new Size(661, 460);

                // Patient Window
                //ptwind = new PatientWindow(pt); //Changes made 04/12/2011
                ptwind = new PatientWindow();
                ptwind.MdiParent = this;
                ptwind.Show();
                ptwind.Location = new Point(0, admtr.Height);
                ptwind.Size = new Size(400, 450);

                adgrm = new Audiogram();
                adgrm.vltl = this;
                adgrm.patient = pt; // delete me
                adgrm.MdiParent = this;
                adgrm.Show();
                adgrm.Location = new Point(admtr.Width,0);
                adgrm.SpAudInput.MdiParent = this;
                adgrm.SpAudInput.Location = new Point(750, 496);

                pplot = new Plateau_Plot.Plateau_Plot();
                pplot.MdiParent = this;
                pplot.Show();
                pplot.Location = new Point(adgrm.Width, adgrm.Height);
                pplot.Visible = false;

                // SRT
                srtWind = new SRT.SRT(
                    new SRT.SRT.ResponseDelegate(DoResponse),
                    new SRT.SRT.DoneDelegate(EnableSpeechMenu));
                srtWind.MdiParent = this;
                srtWind.Location = new Point(750, 496);
                srtWind.Hide();

                // WI
                wiWind = new WI.WI(
                    new WI.WI.DoneDelegate(EnableSpeechMenu),
                    new WI.WI.ResponseDelegate(DoResponse));
                wiWind.MdiParent = this;
                wiWind.Location = new Point(750, 496);
                wiWind.Hide();

                // show form
                this.Visible = true;
                WindowState = System.Windows.Forms.FormWindowState.Maximized;
                prevState = admtr.ameterSettings;
            } // end if ( dResult != Cancel )
		}

        // delete me
        // make private
		private void menuNewPat_Click(object sender, System.EventArgs e)
        {
            NewPatientMenu(-1);
		}

        public void NewPatientMenu(int pathology)
        {
            Random rand = new Random();

			if (programMode == ProgramMode.Eval) 
			{
                pt.NewPatient(rand.Next(12));

				// clear the plateaut plot and audiogram
				pplot.ClearAll();
				adgrm.Clear_Graph();

				// reset the show path button
				resultsShow.Visible	= false;
				resultsHidePath.Visible	= false;

                evalOutput = new EvalOutput(pt.path);

                menuNewPat.Enabled = false;
                resultsSave.Enabled = true;
			}
			else
			{
				int pathTypeChoosen = pathology;

				PathologySelector pS = new PathologySelector();
				if (pathology == -1 && pS.ShowDialog() == DialogResult.OK) 
				{
					pathTypeChoosen = pS.pathBox.SelectedIndex - 1;
				}

                // Modified by Matt Harris 9/16/2011
                // to fix random pathology bug where a patient wasn't
                // being shown

				if (pathTypeChoosen < 0)
                    pathTypeChoosen = rand.Next(12);

                pt.NewPatient(pathTypeChoosen);
                
				// clear the plateaut plot and audiogram
				pplot.ClearAll();
				adgrm.Clear_Graph();

				// reset the show path button
				resultsShow.Visible	= true;
				resultsHidePath.Visible	= false;
				ptwind.SetText(pt.GetPath().PathType);
			}

			chf.Dispose();

			chf = new CaseHistoryForm();
			chf.FillCaseHistory(pt.GetPath().CaseHist);
			chf.Show();

			// show the new patient
			ptwind.ShowPatient(pt.returnPatientType());


			patientStartTime = DateTime.Now;
			menuSpeechAudiometry.Enabled = true;
			adgrm.HideSpeechResults();

        }

		private void menuShowCaseHistory_Click(object sender, System.EventArgs e)
		{
			if (pt.validPatient) 
			{
				chf.Dispose();

				chf = new CaseHistoryForm();
				chf.FillCaseHistory(pt.GetPath().CaseHist);
				chf.Show();
			}
		}

        //delete me
        // make private
		public void resultsShow_Click(object sender, System.EventArgs e)
		{
			int	LeftBoneThresh, RightBoneThresh, LeftAirThresh, RightAirThresh, LeftBoneMasked, RightBoneMasked;
            
            Ear badEar;

			if (pt.validPatient) 
			{
                badEar = pt.GetPath().BadEar;
				// Place the SRT and WI Thresholds on Audiogram
				int[] ST = new int[2];
				int[] DoubleZero = new int[2];
				int[] SRTMask = new int[2];
				int[] WS = new int[2];
				int[] WL = new int[2];
				//ST[0] = pt.GetPath().SRT_Thresh_Val(0);
				//ST[1] = pt.GetPath().SRT_Thresh_Val(1);
				DoubleZero[0] = 0; DoubleZero[1] = 0;
				//WS[0] = pt.GetPath().GetWI(0);
				//WS[1] = pt.GetPath().GetWI(1);
				//WL[0] = pt.GetPath().GetWILevel(0);
				//WL[1] = pt.GetPath().GetWILevel(1);
				//SRTMask[0] = ST[0]-40-pt.GetPath().GetMinimumBC(0);
				//if(SRTMask[0] < 0) SRTMask[0] = 0;
				//SRTMask[1] = ST[1]-40-pt.GetPath().GetMinimumBC(1);
				//if(SRTMask[1] < 0) SRTMask[1] = 0;
				//adgrm.ShowPathology(ST, SRTMask, WS, WL, DoubleZero);

                for	(int i = 250; i <= 8000; i*=2)
				{
					// get the BC values to determine if masking is needed
					LeftBoneThresh = pt.GetPath().BC_Thresh_Val(i, Ear.left);
					RightBoneThresh = pt.GetPath().BC_Thresh_Val(i, Ear.right);

					// left ear thresh
					LeftAirThresh = pt.GetPath().AC_Thresh_Val(i, Ear.left);
                    RightAirThresh = pt.GetPath().AC_Thresh_Val(i, Ear.right);
					
                    // Masked Bone Values
                    LeftBoneMasked = pt.GetPath().BC_Mask_Val(i, Ear.left);
                    RightBoneMasked = pt.GetPath().BC_Mask_Val(i, Ear.right);

					adgrm.Patho_PlacePt(i, LeftAirThresh, Audiogram.SymbolType.LeftAir);
                    adgrm.Patho_PlacePt(i,	RightAirThresh, Audiogram.SymbolType.RightAir);

					// because no bone score tested at 8kHz
                    if (i < 8000)
                    {
                        
                        // Bone Conductance needs to be masked if the air conductance is above 10 dB to
                        // prevent one side's sound from bleeding into the other side.
                        if (LeftAirThresh - LeftBoneThresh > 10 && (badEar == Ear.left || badEar == Ear.both) )
                            adgrm.Patho_PlacePt(i, pt.GetPath().BC_Mask_Val(i, Ear.left), Audiogram.SymbolType.LeftBoneMasked);
                        if (RightAirThresh - RightBoneThresh > 10 && (badEar == Ear.right || badEar == Ear.both) )
                            adgrm.Patho_PlacePt(i, pt.GetPath().BC_Mask_Val(i, Ear.right), Audiogram.SymbolType.RightBoneMasked);
                        // Air Masking. Used 60 because Interaural Attenuation for inserts is 60 and the "pathology answer"
                        // is based on using inserts
                        if (LeftAirThresh - 60 >= RightBoneThresh && (badEar == Ear.left || badEar == Ear.both) )
                            adgrm.Patho_PlacePt(i, pt.GetPath().AC_Mask_Val(i, Ear.left), Audiogram.SymbolType.LeftAirMasked);
                        if (RightAirThresh - 60 >= LeftBoneThresh && (badEar == Ear.right || badEar == Ear.both) )
                            adgrm.Patho_PlacePt(i, pt.GetPath().AC_Mask_Val(i, Ear.right), Audiogram.SymbolType.RightAirMasked);

                        adgrm.Patho_PlacePt(i, LeftBoneThresh, Audiogram.SymbolType.LeftBone);
                        adgrm.Patho_PlacePt(i, RightBoneThresh, Audiogram.SymbolType.RightBone);
                    }
				}
				adgrm.Show_Pathology_Results();
			}
			resultsShow.Visible	= false;
			resultsHidePath.Visible	= true;
		}

		private	void resultsClear_Click(object sender, System.EventArgs	e)
		{
			adgrm.Clear_Graph();
			adgrm.ClearSpeechResults();
			resultsShow.Visible	= true;
			resultsHidePath.Visible	= false;
		}

		private void resultsSave_Click(object sender, System.EventArgs e)
		{
			// this is the menu item that triggers "test done"
            resultsSave.Enabled = false;
            menuNewPat.Enabled = true;

            resultsShow.PerformClick();

            evalOutput.CompileResults(adgrm);

			stChang(true);
		}
		private	void resultsHidePath_Click(object sender, System.EventArgs e)
		{
			adgrm.HideSpeechResults();
			adgrm.PathologyCursors.PointsUsed	= 0;
			adgrm.Invalidate();

			resultsShow.Visible	= true;
			resultsHidePath.Visible	= false;
		}

		private void pplotShowHide_Click(object sender, System.EventArgs e)
		{
			pplot.Visible = !pplot.Visible;

			if (pplot.Visible)
			{
				pplotShowHide.Text = "Hide";
				pplot.Location = new Point(adgrm.Width, adgrm.Top + adgrm.Height - pplot.Height);
			}
			else
			{
				pplotShowHide.Text = "Show";
			}
		}

		private void helpTutorials_Click(object sender, System.EventArgs e)
		{
            string path = AppDomain.CurrentDomain.BaseDirectory;
            Process.Start("User Manual.doc");
		}

		private void menuSRT_Click(object sender, System.EventArgs e)
		{
			srtWind.Show();
			srtWind.Location = new Point(560, 12);
			menuSpeechAudiometry.Enabled = false;
			if(this.adgrm.SpAudInput.Visible == false) this.adgrm.ShowSpeechAudiometry();
		}

		private void menuWI_Click(object sender, System.EventArgs e)
		{
			wiWind.Show();
			wiWind.Location = new Point(560, 12);
			menuSpeechAudiometry.Enabled = false;
			if(this.adgrm.SpAudInput.Visible == false) this.adgrm.ShowSpeechAudiometry();
		}

        private void menuAbout_Click(object sender, EventArgs e)
        {
            AboutVML AboutBox = new AboutVML();

            AboutBox.ShowDialog();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        static public int FrequencyToIndex(int Freq)
        {
            switch (Freq)
            {
                case 250:
                    return 0;
                    
                case 500:
                    return 1;
                    
                case 1000:
                    return 2;
                    
                case 2000:
                    return 3;
                    
                case 4000:
                    return 4;
                    
                case 8000:
                    return 5;
                    
                default:
                    return -1;
                    
            }
        }
        
        public void EvalAudiogramUpdate(int frequencyPlotted, int dbPlotted, Audiogram.SymbolType symbol)
        {
            int ear, masked, transducer;
            int frequency;
            byte symb = (byte)symbol;
            Audiometer.channelSettings maskChannel;
            Audiometer.channelSettings testChannel;

            if (programMode != ProgramMode.Eval)
                return;

            frequency = FrequencyToIndex(frequencyPlotted);
            if (frequency < 0 || frequency > 5)
                return;

            ear = symb & Audiogram.RightEar;
            transducer = (symb & Audiogram.AirTrans) >> 1;
            masked = (symb & Audiogram.Masked) >> 2;

            evalOutput.StudentAudiogram[frequency, transducer, masked, ear] = dbPlotted;

            evalOutput.StudentAudiometer[frequency, transducer, masked, ear].ameterSettings = admtr.ameterSettings;
            
            if (admtr.Channel1.interrupt == true)
            {
                maskChannel = admtr.Channel1;
                testChannel = admtr.Channel2;
            }
            else if (admtr.Channel2.interrupt == true)
            {
                maskChannel = admtr.Channel2;
                testChannel = admtr.Channel1;
            }
            else
            {
                // When masking, it is easy to determine the presentation channel.

                // This function is called when the user plots a point on the audiogram. It is not possible to
                // determine exactly how the user came to the conclusion of this response. On top of this, there
                // are two channels to choose from. Therefore, we must rank the channels to determine which channel
                // is most likely to be the one that the user used to plot the point on the audiogram.
                
                Ear earType = ear == 0 ? Ear.left : Ear.right;
                Audiometer.TransducerType transType = transducer == 0 ? Audiometer.TransducerType.Bone : Audiometer.TransducerType.Insert;
                
                // These scores are incremented upon finding a similarity between the plotted point and the channel settings
                int ch1Score = 0, ch2Score = 0;

                if (admtr.Channel1.route == earType) ch1Score++;
                if (admtr.Channel2.route == earType) ch2Score++;
                if (admtr.Channel1.volume == dbPlotted) ch1Score++;
                if (admtr.Channel2.volume == dbPlotted) ch2Score++;
                if (admtr.Channel1.stim == Audiometer.StimulusType.Tone) ch1Score++;
                if (admtr.Channel2.stim == Audiometer.StimulusType.Tone) ch2Score++;

                if (transType == Audiometer.TransducerType.Insert)
                {
                    if (admtr.Channel1.trans == Audiometer.TransducerType.Insert ||
                        admtr.Channel1.trans == Audiometer.TransducerType.Phone)
                        ch1Score++;
                    else if (admtr.Channel2.trans == Audiometer.TransducerType.Insert ||
                             admtr.Channel2.trans == Audiometer.TransducerType.Phone)
                        ch2Score++;
                }
                else
                {
                    if (transType == admtr.Channel1.trans) ch1Score++;
                    if (transType == admtr.Channel2.trans) ch2Score++;
                }

                // Scoring is complete, determine the channel. If the scores are the same, then just go with channel 1
                if (ch1Score >= ch2Score)
                {
                    testChannel = admtr.Channel1;
                    maskChannel = admtr.Channel2;
                }
                else
                {
                    testChannel = admtr.Channel2;
                    maskChannel = admtr.Channel1;
                }
            }

            evalOutput.StudentAudiometer[frequency, transducer, masked, ear].testChannel = testChannel;
            evalOutput.StudentAudiometer[frequency, transducer, masked, ear].maskChannel = maskChannel;
        }
	}

	//
	// Support classes
	//

	/// <summary>
	/// The Student information class simply stores the users info
	/// </summary>
	class StudentInformation 
	{
		public string stName;
		public string stEmail;
		public string stID;
		public string stCourse;
		public string stProf;
	}

	/// <summary>
	/// TestResults is the class allowing the test results at a freq to be sorted in an arraylist
	/// </summary>
	class TestResults : IComparable
	{
		public int tr_freq;
		public int tr_dB;
		public string tr_desc;
		public TestResults (int freq, int dB, string description)
		{
			tr_freq = freq;
			tr_dB = dB;
			tr_desc = description;
		}
		#region IComparable Members

		public int CompareTo(object obj)
		{
			if (obj is TestResults) 
			{
				// compare to will work
				TestResults temp = (TestResults) obj;
				return tr_freq.CompareTo(temp.tr_freq);
			}

			throw new ArgumentException("obj is of type" + obj.GetType().ToString());
		}

		#endregion
	}

	/// <summary>
	/// The ResultsInfo class stores the students results
	/// </summary>
	class ResultsInfo
	{
		// string containing results
		public string pureToneResults;
		private const string UNICODE_TRIANGLE = "\u0394";
		private const string UNICODE_SQUARE = "\u03A2";
		private const string UNICODE_DOWNLEFTARROW = "\u2199";
		private const string UNICODE_DOWNRIGHTARROW = "\u2198";

		// delegate used in the fill Comments function
		private delegate int threshDelegate(int freq, Ear ear);

		public ResultsInfo() 
		{
			pureToneResults = string.Empty;
		}

		/// <summary>
		/// fills the comments in the results info array lists
		/// </summary>
		/// <param name="arrList"></param>
		/// <param name="pt"></param>
		/// <param name="testType">lac/lbc/rac/rbc are all valid</param>
		private void fillComments(ref ArrayList arrList, Patient.Patient pt, string testType)
		{
			int actThresh, currFreq;
			Ear earInQuestion = Ear.neither;
			TestResults tr;
			Pathology ptPath = pt.GetPath();
			
			// function pointer of which function to call
			threshDelegate threshFunc;

			switch (testType) 
			{
				case "lac":
					earInQuestion = Ear.left;
					threshFunc = new threshDelegate(ptPath.AC_Thresh_Val);
					break;
				case "lbc":
					earInQuestion = Ear.left;
					threshFunc = new threshDelegate(ptPath.BC_Thresh_Val);
					break;
				case "rac":
					earInQuestion = Ear.right;
					threshFunc = new threshDelegate(ptPath.AC_Thresh_Val);
					break;
				case "rbc":
					earInQuestion = Ear.right;
					threshFunc = new threshDelegate(ptPath.BC_Thresh_Val);
					break;
				default:
					threshFunc = null;
					return;
			}

			for (int i = 0; i < arrList.Count; i++) 
			{
				tr = (TestResults)arrList[i];
				currFreq = tr.tr_freq;

				actThresh = threshFunc(currFreq, earInQuestion);
				// tested threshhold is too quiet
				if (actThresh - 5 > tr.tr_dB) 
				{
					((TestResults)arrList[i]).tr_desc = "Student recorded threshold at " + 
						tr.tr_dB + " dB, but patient's actual threshold is " + actThresh + " dB.  " + 
						"Maybe try a louder masking stimuli.";
				}
				else if (tr.tr_dB >= actThresh - 5 && tr.tr_dB <= actThresh + 5)
				{
					((TestResults)arrList[i]).tr_desc = "Student recorded threshold at " + 
						tr.tr_dB + " dB, patient's actual threshold is " + actThresh + " dB.  " + 
						"This is within margin of error.";
				}
				else
				{
					((TestResults)arrList[i]).tr_desc = "Student recorded threshold at " + 
						tr.tr_dB + " dB, but patient's actual threshold is " + actThresh + " dB.  " + 
						"Maybe the masking noise was too loud.";
				}
			}
		}

		/// <summary>
		/// Parses the students tested thresholds from the audiogram and compares these
		/// to the patient's actual thresholds
		/// </summary>
		/// <param name="adgrm"> the audiogram used in the test</param>
		/// <param name="pt"> the patient tested</param>
		public void storePureToneResults(Audiogram adgrm, Patient.Patient pt) 
		{
			// this will go through each point plotted on the audiogram and
			// compare it to the corresponding threshold
	
			// values returned from audiogram
			string[] adgrm_freq, adgrm_dB, adgrm_cursors;
			string adgrmPts;
			string[] adgrmPtsSplit;

			// Array lists containing the AC and BC information
			ArrayList l_ac_results = new ArrayList();
			ArrayList l_bc_results = new ArrayList();
			ArrayList r_ac_results = new ArrayList();
			ArrayList r_bc_results = new ArrayList();

			// first get the points string and parse it
			adgrmPts = adgrm.GetPlottedPoints(false);
			adgrmPtsSplit = adgrmPts.Split("\n".ToCharArray());
			
			adgrm_freq = adgrmPtsSplit[0].Split(",".ToCharArray());
			adgrm_dB = adgrmPtsSplit[1].Split(",".ToCharArray());
			adgrm_cursors = adgrmPtsSplit[2].Split(",".ToCharArray());

			// check the empty condition
			if (adgrm_freq[0] == string.Empty) return;

			// sort the pts into AC/BC bins
			int iter = 0;
			foreach (string str in adgrm_cursors) 
			{
				// parse out the pt info
				int pt_freq = Convert.ToInt32(adgrm_freq[iter]);
				int pt_dB = Convert.ToInt32(adgrm_dB[iter]);
				int temp_dB, index;

				TestResults tr_temp = new TestResults(pt_freq, pt_dB, string.Empty);

				// grab the corresponding freq and thresh
				switch (str) 
				{
					case "AC_Left":
					case UNICODE_SQUARE:
						// left ear AC thresh
						index = l_ac_results.BinarySearch(tr_temp);
						if (index < 0) 
						{
							l_ac_results.Add(tr_temp);
						}
						else
						{
							// give it the max dB
							temp_dB = ((TestResults)l_ac_results[index]).tr_dB;
							((TestResults)l_ac_results[index]).tr_dB = 
								(temp_dB > tr_temp.tr_dB) ? temp_dB : tr_temp.tr_dB;
						}
						break;
					case "AC_Right":
					case UNICODE_TRIANGLE:
						// right ear AC thresh
						index = r_ac_results.BinarySearch(tr_temp);
						if (index < 0) 
						{
							r_ac_results.Add(tr_temp);
						}
						else
						{
							// give it the max dB
							temp_dB = ((TestResults)r_ac_results[index]).tr_dB;
							((TestResults)r_ac_results[index]).tr_dB = 
								(temp_dB > tr_temp.tr_dB) ? temp_dB : tr_temp.tr_dB;
						}
						break;
					case "BC_Left":
					case "]":
						// left ear BC thresh
						index = l_bc_results.BinarySearch(tr_temp);
						if (index < 0) 
						{
							l_bc_results.Add(tr_temp);
						}
						else
						{
							// give it the max dB
							temp_dB = ((TestResults)l_bc_results[index]).tr_dB;
							((TestResults)l_bc_results[index]).tr_dB = 
								(temp_dB > tr_temp.tr_dB) ? temp_dB : tr_temp.tr_dB;
						}
						break;
					case "BC_Right":
					case "[":
						// right ear BC thresh
						index = r_bc_results.BinarySearch(tr_temp);
						if (index < 0) 
						{
							r_bc_results.Add(tr_temp);
						}
						else
						{
							// give it the max dB
							temp_dB = ((TestResults)r_bc_results[index]).tr_dB;
							((TestResults)r_bc_results[index]).tr_dB = 
								(temp_dB > tr_temp.tr_dB) ? temp_dB : tr_temp.tr_dB;
						}
						break;
					default:
						Console.WriteLine(str + " Found");
						break;
				}

				iter++;
			}

			// sort and fill comments
			if (l_ac_results.Count > 0) 
			{
				l_ac_results.Sort();
				fillComments(ref l_ac_results, pt, "lac");
			}
			if (l_bc_results.Count > 0)
			{
				l_bc_results.Sort();
				fillComments(ref l_bc_results, pt, "lbc");
			}
			if (r_ac_results.Count > 0)
			{
				r_ac_results.Sort();
				fillComments(ref r_ac_results, pt, "rac");
			}
			if (r_bc_results.Count > 0)
			{
				r_bc_results.Sort();
				fillComments(ref r_bc_results, pt, "rbc");
			}
			
			// add info to the results string
			pureToneResults = "Pure tone results for " + pt.GetPath().PathType + " pathology.\n";
			// first the Left AC
			pureToneResults += "Left Ear Air Conduction Results:\n";
			for (int i = 0; i < l_ac_results.Count; i++) 
			{
				TestResults temp_tr = (TestResults)l_ac_results[i];
				pureToneResults += "At " + temp_tr.tr_freq + ", " + temp_tr.tr_desc + "\n";
			}
			// then the Right AC
			pureToneResults += "Right Ear Air Conduction Results:\n";
			for (int i = 0; i < r_ac_results.Count; i++) 
			{
				TestResults temp_tr = (TestResults)r_ac_results[i];
				pureToneResults += "At " + temp_tr.tr_freq + ", " + temp_tr.tr_desc + "\n";
			}
			// then the Left BC
			pureToneResults += "Left Ear Bone Conduction Results:\n";
			for (int i = 0; i < l_bc_results.Count; i++) 
			{
				TestResults temp_tr = (TestResults)l_bc_results[i];
				pureToneResults += "At " + temp_tr.tr_freq + ", " + temp_tr.tr_desc + "\n";
			}
			// lastly the Right BC
			pureToneResults += "Right Ear Bone Conduction Results:\n";
			for (int i = 0; i < r_bc_results.Count; i++) 
			{
				TestResults temp_tr = (TestResults)r_bc_results[i];
				pureToneResults += "At " + temp_tr.tr_freq + ", " + temp_tr.tr_desc + "\n";
			}
		}
	}
}