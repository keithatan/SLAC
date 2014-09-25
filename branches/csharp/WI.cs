using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.Threading;

namespace WI
{
	/// <summary>
	/// Summary description for WI.
	/// </summary>
	public class WI : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox bxVoice;
		private System.Windows.Forms.RadioButton rdFemale;
		private System.Windows.Forms.RadioButton rdMale;
		private System.Windows.Forms.Button cmdDone;
		private System.Windows.Forms.Button cmdUse;
		private System.Windows.Forms.ComboBox cboListNames;
		private System.Windows.Forms.Button cmdSay;
		private System.Windows.Forms.CheckedListBox lstWords;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Button cmdAutoSay;
		private System.Windows.Forms.Label lblSpeechBubble;
		public int SND_SYNC = 0x0000;  /* play synchronously (default) */
		public int SND_ASYNC = 0x0001;  /* play asynchronously */
		public int SND_NODEFAULT = 0x0002;  /* silence (!default) if sound not found */
		public int SND_MEMORY = 0x0004;  /* pszSound points to a memory file */
		public int SND_LOOP = 0x0008;  /* loop the sound until next sndPlaySound */
		public int SND_NOSTOP = 0x0010;  /* don't stop any currently playing sound */
		public int SND_NOWAIT = 0x00002000; /* don't wait if the driver is busy */
		public int SND_ALIAS = 0x00010000; /* name is a registry alias */
		public int SND_ALIAS_ID = 0x00110000; /* alias is a predefined ID */
		public int SND_FILENAME = 0x00020000; /* name is file name */
		public int SND_RESOURCE = 0x00040004;  /* name is resource name or atom */
		private string Voice;	// "female" = Female, "male" = Male, for which voice to play
		private bool bListSelected;	// True if a list is going to be used
		private const string vFemale = "female";	// constant for filename creation
		private const string vMale = "male";
		private bool bAuto;			// True if the autotest is running, false otherwise
		private bool bThreading;	// True if there are separate user-threads running, false otherwise
		private String theWord;		// Which word will be presented as the stimulus

		// Delegates
		public delegate void DoneDelegate();
		public delegate bool ResponseDelegate(String Word, String Type);
		DoneDelegate _doneDelegate;
		ResponseDelegate _responseDelegate;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		// playsound wrapper
		[DllImport("WinMM.dll")]
		public static extern bool PlaySound(string fName, long handlePtr, int playFlags);

		/// <summary>
		/// Default Constructor
		/// </summary>
		public WI()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			ResetAll();
		}

		/// <summary>
		/// Constructor with passed delegates
		/// </summary>
		/// <param name="_dd">Name of Done Delegate</param>
		/// <param name="_rd">Name of Response Delegate</param>
		public WI(DoneDelegate _dd, ResponseDelegate _rd)
		{
			InitializeComponent();
			ResetAll();
			_doneDelegate = _dd;
			_responseDelegate = _rd;
		}

		/// <summary>
		/// Clears and resets all pertinent data and members
		/// </summary>
		private void ResetAll()
		{
			cboListNames.SelectedIndex = -1;
			Voice = GetVoiceVal();
			LoadLists();
			bListSelected = false;
			lstWords.Items.Clear();
			cboListNames.Enabled = true;
			cmdSay.Enabled = false;
			bAuto = false;
			cmdAutoSay.Text = "Auto Test";
			cmdAutoSay.Enabled = false;
			theWord = String.Empty;
			bThreading = false;
		}

		/// <summary>
		/// Loads the list names into the combo box
		/// </summary>
		/// <param name="path">Directory containing lists</param>
		public void LoadLists()
		{
            // Load the assembly and load all of the resource strings into resourceStrings
            System.Reflection.Assembly thisAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            string[] resourceStrings = thisAssembly.GetManifestResourceNames();

            // Loop through all of the resource strings and find the ones that begin with
            // Virtual_Lab.List.WI . Thses are the lists that we want to load.
            foreach (string s in resourceStrings)
            {
                if (s.StartsWith("Virtual_Lab.List.WI"))
                {
                    string[] wiSplit = s.Split(new Char[] {'.'});

                    cboListNames.Items.Add(wiSplit[3]);
                }
            }

			/* OLD CODE
             * cboListNames.Items.Clear();
			 * DirectoryInfo thisdir = new DirectoryInfo(path);
			 * FileInfo[] fi = thisdir.GetFiles("*.txt");
			 * for(int i = 0; i < fi.Length; i++)
			 * {
			 *  	int length = fi[i].Name.Length - 4;
			 *      String theItem = fi[i].Name.Substring(0, length);
			 *      cboListNames.Items.Add(theItem);
			 * }
             */
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
			this.bxVoice = new System.Windows.Forms.GroupBox();
			this.rdMale = new System.Windows.Forms.RadioButton();
			this.rdFemale = new System.Windows.Forms.RadioButton();
			this.cmdSay = new System.Windows.Forms.Button();
			this.cmdUse = new System.Windows.Forms.Button();
			this.cmdDone = new System.Windows.Forms.Button();
			this.cboListNames = new System.Windows.Forms.ComboBox();
			this.lstWords = new System.Windows.Forms.CheckedListBox();
			this.lblTitle = new System.Windows.Forms.Label();
			this.cmdAutoSay = new System.Windows.Forms.Button();
			this.lblSpeechBubble = new System.Windows.Forms.Label();
			this.bxVoice.SuspendLayout();
			this.SuspendLayout();
			// 
			// bxVoice
			// 
			this.bxVoice.Controls.Add(this.rdMale);
			this.bxVoice.Controls.Add(this.rdFemale);
			this.bxVoice.Location = new System.Drawing.Point(8, 40);
			this.bxVoice.Name = "bxVoice";
			this.bxVoice.Size = new System.Drawing.Size(80, 56);
			this.bxVoice.TabIndex = 3;
			this.bxVoice.TabStop = false;
			this.bxVoice.Text = "Voice";
			// 
			// rdMale
			// 
			this.rdMale.Location = new System.Drawing.Point(8, 32);
			this.rdMale.Name = "rdMale";
			this.rdMale.Size = new System.Drawing.Size(48, 16);
			this.rdMale.TabIndex = 2;
			this.rdMale.Text = "Male";
			this.rdMale.CheckedChanged += new System.EventHandler(this.rdMale_CheckedChanged);
			// 
			// rdFemale
			// 
			this.rdFemale.Checked = true;
			this.rdFemale.Location = new System.Drawing.Point(8, 16);
			this.rdFemale.Name = "rdFemale";
			this.rdFemale.Size = new System.Drawing.Size(64, 16);
			this.rdFemale.TabIndex = 1;
			this.rdFemale.TabStop = true;
			this.rdFemale.Text = "Female";
			this.rdFemale.CheckedChanged += new System.EventHandler(this.rdFemale_CheckedChanged);
			// 
			// cmdSay
			// 
			this.cmdSay.Enabled = false;
			this.cmdSay.Location = new System.Drawing.Point(8, 176);
			this.cmdSay.Name = "cmdSay";
			this.cmdSay.Size = new System.Drawing.Size(88, 24);
			this.cmdSay.TabIndex = 13;
			this.cmdSay.Text = "Say";
			this.cmdSay.Click += new System.EventHandler(this.cmdSay_Click);
			// 
			// cmdUse
			// 
			this.cmdUse.Enabled = false;
			this.cmdUse.Location = new System.Drawing.Point(8, 112);
			this.cmdUse.Name = "cmdUse";
			this.cmdUse.Size = new System.Drawing.Size(88, 24);
			this.cmdUse.TabIndex = 6;
			this.cmdUse.Text = "Use";
			this.cmdUse.Click += new System.EventHandler(this.cmdUse_Click);
			// 
			// cmdDone
			// 
			this.cmdDone.Location = new System.Drawing.Point(8, 240);
			this.cmdDone.Name = "cmdDone";
			this.cmdDone.Size = new System.Drawing.Size(88, 24);
			this.cmdDone.TabIndex = 7;
			this.cmdDone.Text = "Done";
			this.cmdDone.Click += new System.EventHandler(this.cmdDone_Click);
			// 
			// cboListNames
			// 
			this.cboListNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboListNames.Location = new System.Drawing.Point(8, 144);
			this.cboListNames.MaxDropDownItems = 10;
			this.cboListNames.Name = "cboListNames";
			this.cboListNames.Size = new System.Drawing.Size(88, 21);
			this.cboListNames.Sorted = true;
			this.cboListNames.TabIndex = 11;
			this.cboListNames.SelectedIndexChanged += new System.EventHandler(this.cboListNames_SelectedIndexChanged);
			// 
			// lstWords
			// 
			this.lstWords.Location = new System.Drawing.Point(112, 64);
			this.lstWords.Name = "lstWords";
			this.lstWords.Size = new System.Drawing.Size(104, 199);
			this.lstWords.TabIndex = 14;
			this.lstWords.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstWords_MouseDown);
			this.lstWords.SelectedIndexChanged += new System.EventHandler(this.lstWords_SelectedIndexChanged);
			this.lstWords.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstWords_ItemCheck);
			// 
			// lblTitle
			// 
			this.lblTitle.Location = new System.Drawing.Point(120, 40);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(88, 16);
			this.lblTitle.TabIndex = 15;
			// 
			// cmdAutoSay
			// 
			this.cmdAutoSay.Enabled = false;
			this.cmdAutoSay.Location = new System.Drawing.Point(8, 208);
			this.cmdAutoSay.Name = "cmdAutoSay";
			this.cmdAutoSay.Size = new System.Drawing.Size(88, 24);
			this.cmdAutoSay.TabIndex = 16;
			this.cmdAutoSay.Text = "Auto Test";
			this.cmdAutoSay.Click += new System.EventHandler(this.cmdAutoSay_Click);
			// 
			// lblSpeechBubble
			// 
			this.lblSpeechBubble.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
			this.lblSpeechBubble.Location = new System.Drawing.Point(16, 8);
			this.lblSpeechBubble.Name = "lblSpeechBubble";
			this.lblSpeechBubble.Size = new System.Drawing.Size(192, 24);
			this.lblSpeechBubble.TabIndex = 17;
			// 
			// WI
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(234, 296);
			this.ControlBox = false;
			this.Controls.Add(this.lblSpeechBubble);
			this.Controls.Add(this.cmdAutoSay);
			this.Controls.Add(this.lblTitle);
			this.Controls.Add(this.lstWords);
			this.Controls.Add(this.cboListNames);
			this.Controls.Add(this.cmdDone);
			this.Controls.Add(this.cmdUse);
			this.Controls.Add(this.bxVoice);
			this.Controls.Add(this.cmdSay);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.Name = "WI";
			this.Text = "WI";
			this.bxVoice.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Changes the Voice member variable based on radio buttons
		/// </summary>
		private void rdMale_CheckedChanged(object sender, System.EventArgs e)
		{
			Voice = GetVoiceVal();
		}

		/// <summary>
		///  Returns which voice to play
		/// </summary>
		/// <returns>"female" or "male" depending on which radio button is checked</returns>
		private string GetVoiceVal()
		{
			if(rdFemale.Checked) return vFemale;
			else return vMale;
		}

		/// <summary>
		/// Changes the Voice member variable based on radio buttons
		/// </summary>
		private void rdFemale_CheckedChanged(object sender, System.EventArgs e)
		{
			Voice = GetVoiceVal();
		}

		/// <summary>
		/// Called when index of lstWords changes
		/// </summary>
		private void lstWords_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			EnableSay();
		}

		/// <summary>
		///  Adds word to lstWords
		/// </summary>
		/// <param name="Word">The word to add to the list</param>
		public void AddWord_UseWords(string Word)
		{
			if(lstWords.Items.Contains(Word))
				lstWords.SelectedItem = Word;
			else
				lstWords.Items.Add(Word);
		}

		/// <summary>
		/// Called when cmdUse is clicked. Will make sure the current list is permanently selected for this test
		/// </summary>
		private void cmdUse_Click(object sender, System.EventArgs e)
		{
			bListSelected = true;
			cmdUse.Enabled = false;
			cboListNames.Enabled = false;
			EnableSay();
			cmdAutoSay.Enabled = true;
			SetCorrectLabel(System.Windows.Forms.CheckState.Indeterminate);
		}

		/// <summary>
		/// Set's the label to keep track of how many are correct
		/// </summary>
		/// <param name="cs">Checked state of click</param>
		private void SetCorrectLabel(System.Windows.Forms.CheckState cs)
		{
			if(bListSelected)
			{
				int NumWords = lstWords.Items.Count;
				int NumChecked = lstWords.CheckedItems.Count;
				if(cs == System.Windows.Forms.CheckState.Checked) NumChecked++;
				if(cs == System.Windows.Forms.CheckState.Unchecked) NumChecked--;
				lblTitle.Text = NumChecked.ToString() + "/" + NumWords.ToString() + " Correct";
			}
		}

		/// <summary>
		/// Will enable or disable cmdSay based on states of other objects
		/// </summary>
		private void EnableSay()
		{
			cmdSay.Enabled = bListSelected && (lstWords.SelectedIndex >= 0) && !bAuto;
		}

		/// <summary>
		/// This will play the wav file for the corresponding word
		/// </summary>
		private void SayWord()
		{
			if(!bThreading)
			{
				Thread t1 = new Thread(new ThreadStart(SayWordToPatient));
				t1.Name = "Say_Word_Thread";
				t1.Priority = ThreadPriority.AboveNormal;
				t1.Start();
			}
		}

		/// <summary>
		/// The threaded function that takes care of presenting the word to patient,
		/// and its subsequent response
		/// </summary>
		private void SayWordToPatient()
		{
			const int Time = 2000;

			if(!bAuto) bThreading = true;
			if(theWord != String.Empty) 
			{
				lblSpeechBubble.Text = "Say the word '" + theWord + "'";
				DateTime dt = DateTime.Now;
				String Gender = (rdFemale.Checked) ? "f_" : "m_";
				String filename = "Sounds\\Audiologist\\"+ Gender + theWord + ".wav";
				PlaySound(filename, 0, SND_ASYNC);
				while(dt.Ticks + Time*TimeSpan.TicksPerMillisecond > DateTime.Now.Ticks);
				lblSpeechBubble.Text = "";
				_responseDelegate(theWord, "SRT");
			}
			if(!bAuto) bThreading = false;
		}

		/// <summary>
		/// Called when cmdDone is clicked. Will reset everything before calling doneDelegate.
		/// </summary>
		private void cmdDone_Click(object sender, System.EventArgs e)
		{
			ResetAll();
			_doneDelegate();
			this.Hide();
		}

		/// <summary>
		/// Called when combo box's index is changed. Will call LoadNewList()
		/// </summary>
		private void cboListNames_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(cboListNames.SelectedIndex >= 0)
			{
				String filename = "lists\\WI\\" + (String)cboListNames.SelectedItem + ".txt";
				LoadNewList(filename);
			}
		}

		/// <summary>
		/// Loads a new list into list box
		/// </summary>
		/// <param name="filename">Filename of list to load</param>
		private void LoadNewList(String filename)
		{
			System.IO.StreamReader ListFile = new System.IO.StreamReader(filename);
			lstWords.Items.Clear();
			try
			{
				while(true) lstWords.Items.Add(ListFile.ReadLine());
			}
			catch (System.ArgumentNullException exc)
			{
				String Msg = exc.Message;
			}
			ListFile.Close();

			if(cboListNames.SelectedIndex >= 0) cmdUse.Enabled = true;
			else cmdUse.Enabled = false;
		}

		/// <summary>
		/// Will call Sayword when cmdSay is clicked
		/// </summary>
		private void cmdSay_Click(object sender, System.EventArgs e)
		{
			theWord = (String)lstWords.SelectedItem;
			SayWord();
		}

		/// <summary>
		/// Called when an item in the list is changed
		/// </summary>
		private void lstWords_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			SetCorrectLabel(e.NewValue);
		}

		/// <summary>
		/// Called when cmdAutoSay is clicked
		/// </summary>
		private void cmdAutoSay_Click(object sender, System.EventArgs e)
		{
			Thread t1 = new Thread(new ThreadStart(AutoSay));
			t1.Name = "AutoSay_Thread";
			if(cmdAutoSay.Text == "Auto Test")
			{
				if(!bThreading) // only allow if there is not a thread running
				{
					cmdAutoSay.Text = "Stop";
					cmdSay.Enabled = false;
					bAuto = true;
					t1.Start();
					t1.Priority = ThreadPriority.AboveNormal;
				}
			}
			else
			{
				cmdAutoSay.Text = "Auto Test";
				cmdSay.Enabled = true;
				bAuto = false;
			}
		}

		/// <summary>
		/// This will run through all the elements in the list box and try to get a response
		/// </summary>
		private void AutoSay()
		{
			bThreading = true;
			for(int i = 0; i < lstWords.Items.Count; i++)
			{
				theWord = (String)lstWords.Items[i];
				SayWordToPatient();
				if(bAuto == false) break;
			}
			cmdAutoSay.Text = "Auto Test";
			cmdSay.Enabled = true;
			bAuto = false;
			bThreading = false;
		}

		/// <summary>
		/// This is called when the mouse is clicked
		/// </summary>
		private void lstWords_MouseDown(object sender, MouseEventArgs e)
		{
			if(    (e.Button == System.Windows.Forms.MouseButtons.Right)
				&& (lstWords.SelectedIndex >= 0)
				&& (bAuto == false)) 
			{
				theWord = (String)lstWords.SelectedItem;
				SayWord();
			}
		}
	}
}
