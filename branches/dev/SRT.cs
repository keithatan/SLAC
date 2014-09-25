using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.Threading;

namespace SRT
{
	/// <summary>
	/// Summary description for SRT.
	/// </summary>
	public class SRT : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox bxVoice;
		private System.Windows.Forms.RadioButton rdFemale;
		private System.Windows.Forms.RadioButton rdMale;
		private System.Windows.Forms.Button cmdRemove;
		private System.Windows.Forms.Button cmdAdd;
		private System.Windows.Forms.Button cmdSay;
		private System.Windows.Forms.Button cmdDone;
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
		private const string vFemale = "female";
		private const string vMale = "male";
		private bool bAuto;
		private bool bThreading;
		private System.Windows.Forms.ComboBox cboAllWords;
		private String theWord;

		// Delegate
		public delegate bool ResponseDelegate(String Word, String Type);
		public delegate void DoneDelegate();
		ResponseDelegate _responseDelegate;
		DoneDelegate _doneDelegate;
		private System.Windows.Forms.CheckedListBox lstWords;
		private System.Windows.Forms.Button cmdAutoSay;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Label lblSpeechBubble;

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
		public SRT()
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
		/// Constructor with passed response delegate
		/// </summary>
		/// <param name="_rd">Function name of response delegate</param>
		/// <param name="_dd">Function name of done delegate</param>
		public SRT(ResponseDelegate _rd, DoneDelegate _dd)
		{
			InitializeComponent();
			ResetAll();
			_responseDelegate = _rd;
			_doneDelegate = _dd;
		}

		/// <summary>
		/// Resets all pertinent members of the class
		/// </summary>
		private void ResetAll()
		{
			rdFemale.Checked = true;
			Voice = GetVoiceVal();
			LoadWords();
			lstWords.Items.Clear();
			cboAllWords.SelectedIndex = -1;
			cmdAutoSay.Text = "Auto Test";
			cmdAutoSay.Enabled = false;
			SetLabelProper(lstWords.Items.Count, lstWords.CheckedItems.Count);
			bAuto = false;
			theWord = String.Empty;
			bThreading = false;
		}

		/// <summary>
		/// Checks to enable or disable cmdAutoSay
		/// </summary>
		private void EnableAutoSay()
		{
			cmdAutoSay.Enabled = (lstWords.Items.Count > 0);
		}

		/// <summary>
		/// Loads the words into the combo box from the wordlist passed in
		/// </summary>
		/// <param name="filename">File name of word list</param>
		public void LoadWords()
		{

			cboAllWords.Items.Clear();
            //System.IO.Stream
			System.IO.StreamReader ListFile = new System.IO.StreamReader(".\\Lists\\SRTList.txt");
			try
			{
				while(true) cboAllWords.Items.Add(ListFile.ReadLine());
			}
			catch (System.ArgumentNullException e)
			{
				String Msg = e.Message;
			}
			ListFile.Close();
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
			this.cmdRemove = new System.Windows.Forms.Button();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.cmdSay = new System.Windows.Forms.Button();
			this.cmdDone = new System.Windows.Forms.Button();
			this.cboAllWords = new System.Windows.Forms.ComboBox();
			this.lstWords = new System.Windows.Forms.CheckedListBox();
			this.cmdAutoSay = new System.Windows.Forms.Button();
			this.lblTitle = new System.Windows.Forms.Label();
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
			// cmdRemove
			// 
			this.cmdRemove.Enabled = false;
			this.cmdRemove.Location = new System.Drawing.Point(8, 104);
			this.cmdRemove.Name = "cmdRemove";
			this.cmdRemove.Size = new System.Drawing.Size(88, 24);
			this.cmdRemove.TabIndex = 4;
			this.cmdRemove.Text = "Remove <<";
			this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
			// 
			// cmdAdd
			// 
			this.cmdAdd.Enabled = false;
			this.cmdAdd.Location = new System.Drawing.Point(8, 136);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.Size = new System.Drawing.Size(88, 24);
			this.cmdAdd.TabIndex = 5;
			this.cmdAdd.Text = "Add >>";
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			// 
			// cmdSay
			// 
			this.cmdSay.Enabled = false;
			this.cmdSay.Location = new System.Drawing.Point(8, 200);
			this.cmdSay.Name = "cmdSay";
			this.cmdSay.Size = new System.Drawing.Size(88, 24);
			this.cmdSay.TabIndex = 6;
			this.cmdSay.Text = "Say";
			this.cmdSay.Click += new System.EventHandler(this.cmdSay_Click);
			// 
			// cmdDone
			// 
			this.cmdDone.Location = new System.Drawing.Point(8, 264);
			this.cmdDone.Name = "cmdDone";
			this.cmdDone.Size = new System.Drawing.Size(88, 24);
			this.cmdDone.TabIndex = 7;
			this.cmdDone.Text = "Done";
			this.cmdDone.Click += new System.EventHandler(this.cmdDone_Click);
			// 
			// cboAllWords
			// 
			this.cboAllWords.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboAllWords.Location = new System.Drawing.Point(8, 168);
			this.cboAllWords.MaxDropDownItems = 10;
			this.cboAllWords.Name = "cboAllWords";
			this.cboAllWords.Size = new System.Drawing.Size(88, 21);
			this.cboAllWords.Sorted = true;
			this.cboAllWords.TabIndex = 11;
			this.cboAllWords.SelectedIndexChanged += new System.EventHandler(this.cboAllWords_SelectedIndexChanged);
			// 
			// lstWords
			// 
			this.lstWords.Location = new System.Drawing.Point(112, 64);
			this.lstWords.Name = "lstWords";
			this.lstWords.Size = new System.Drawing.Size(112, 229);
			this.lstWords.TabIndex = 12;
			this.lstWords.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstWords_MouseDown);
			this.lstWords.SelectedIndexChanged += new System.EventHandler(this.lstWords_SelectedIndexChanged);
			this.lstWords.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstWords_ItemCheck);
			// 
			// cmdAutoSay
			// 
			this.cmdAutoSay.Location = new System.Drawing.Point(8, 232);
			this.cmdAutoSay.Name = "cmdAutoSay";
			this.cmdAutoSay.Size = new System.Drawing.Size(88, 24);
			this.cmdAutoSay.TabIndex = 13;
			this.cmdAutoSay.Text = "Auto Test";
			this.cmdAutoSay.Click += new System.EventHandler(this.cmdAutoSay_Click);
			// 
			// lblTitle
			// 
			this.lblTitle.Location = new System.Drawing.Point(120, 40);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(104, 16);
			this.lblTitle.TabIndex = 14;
			// 
			// lblSpeechBubble
			// 
			this.lblSpeechBubble.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblSpeechBubble.Location = new System.Drawing.Point(16, 8);
			this.lblSpeechBubble.Name = "lblSpeechBubble";
			this.lblSpeechBubble.Size = new System.Drawing.Size(200, 24);
			this.lblSpeechBubble.TabIndex = 15;
			// 
			// SRT
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(242, 320);
			this.ControlBox = false;
			this.Controls.Add(this.lblSpeechBubble);
			this.Controls.Add(this.lblTitle);
			this.Controls.Add(this.cmdAutoSay);
			this.Controls.Add(this.lstWords);
			this.Controls.Add(this.cboAllWords);
			this.Controls.Add(this.cmdDone);
			this.Controls.Add(this.cmdSay);
			this.Controls.Add(this.cmdAdd);
			this.Controls.Add(this.cmdRemove);
			this.Controls.Add(this.bxVoice);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.Name = "SRT";
			this.Text = "SRT";
			this.bxVoice.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Called when rdMale radio button is changed. It will set the voice variable to the correct value
		/// </summary>
		private void rdMale_CheckedChanged(object sender, System.EventArgs e)
		{
			Voice = GetVoiceVal();
		}

		/// <summary>
		/// Returns which voice to play
		/// </summary>
		/// <returns>"male" or "female" depending on which radio button is checked</returns>
		private string GetVoiceVal()
		{
			if(rdFemale.Checked) return vFemale;
			else return vMale;
		}

		/// <summary>
		/// Called when rdFemale radio button is changed. It will set the voice variable to the correct value
		/// </summary>
		private void rdFemale_CheckedChanged(object sender, System.EventArgs e)
		{
			Voice = GetVoiceVal();
		}

		/// <summary>
		/// This will enable or disable cmdRemove based on selected index
		/// </summary>
		private void lstWords_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			cmdRemove.Enabled = (lstWords.SelectedIndex >= 0) && !bAuto;
		}

		/// <summary>
		/// Adds word to lstWords items. If word is already in the list, it will select that word.
		/// That way there are no duplicates.
		/// </summary>
		/// <param name="Word">Word to add to the list</param>
		public void AddWord_UseWords(string Word)
		{
			if(lstWords.Items.Contains(Word))
				lstWords.SelectedItem = Word;
			else
				lstWords.Items.Add(Word);
		}

		/// <summary>
		/// Adds a word to cboWords
		/// </summary>
		/// <param name="Word">Word to add</param>
		public void AddWord_TotalWords(string Word)
		{
			cboAllWords.Items.Add(Word);
		}

		/// <summary>
		/// cmdAdd Click procedure. Adds selected word from cboAllWords to list box
		/// </summary>
		private void cmdAdd_Click(object sender, System.EventArgs e)
		{
			AddWord_UseWords((string)cboAllWords.SelectedItem);
			EnableAutoSay();
			SetLabelProper(lstWords.Items.Count, lstWords.CheckedItems.Count);
			cboAllWords.SelectedIndex = -1;
		}

		/// <summary>
		/// Removes the selected word from list box
		/// </summary>
		private void cmdRemove_Click(object sender, System.EventArgs e)
		{
			lstWords.Items.Remove(lstWords.SelectedItem);
			EnableAutoSay();
			SetLabelProper(lstWords.Items.Count, lstWords.CheckedItems.Count);
		}

		/// <summary>
		/// Calls SayWord function with selected word from combobox
		/// </summary>
		private void cmdSay_Click(object sender, System.EventArgs e)
		{
			theWord = (String)cboAllWords.SelectedItem;
			SayWord();
		}

		/// <summary>
		/// Starts a new thread for saying a word with the response.
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
		/// Enables or Disables cmdAdd and cmdSay
		/// </summary>
		private void cboAllWords_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			cmdAdd.Enabled = (cboAllWords.SelectedIndex >= 0) && !bAuto;
			EnableSay();
		}

		/// <summary>
		/// Enables Say button
		/// </summary>
		private void EnableSay()
		{
			cmdSay.Enabled = (cboAllWords.SelectedIndex >= 0) && !bAuto;
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
		/// Called when cmdDone is clicked. It will reset everything and hide the form.
		/// </summary>
		private void cmdDone_Click(object sender, System.EventArgs e)
		{
			ResetAll();
			this.Hide();
			_doneDelegate();
		}

		/// <summary>
		/// This function is called when mouse is clicked
		/// </summary>
		private void lstWords_MouseDown(object sender, MouseEventArgs e)
		{
			if(    (e.Button == System.Windows.Forms.MouseButtons.Right)
				&& (lstWords.SelectedIndex >= 0)) 
			{
				theWord = (String)lstWords.SelectedItem;
				SayWord();
			}
		}

		/// <summary>
		/// Set's the label to keep track of how many are correct
		/// </summary>
		/// <param name="cs">Checked state of click</param>
		private void SetCorrectLabel(System.Windows.Forms.CheckState cs)
		{
			int NumWords = lstWords.Items.Count;
			int NumChecked = lstWords.CheckedItems.Count;
			if(cs == System.Windows.Forms.CheckState.Checked) NumChecked++;
			if(cs == System.Windows.Forms.CheckState.Unchecked) NumChecked--;
			SetLabelProper(NumWords, NumChecked);
		}

		/// <summary>
		/// Sets the label text
		/// </summary>
		/// <param name="NumWords">Total number of words</param>
		/// <param name="NumChecked">Total number of checked words</param>
		private void SetLabelProper(int NumWords, int NumChecked)
		{
			lblTitle.Text = NumChecked.ToString() + "/" + NumWords.ToString() + " Correct";
		}

		/// <summary>
		/// Called when an item is checked or unchecked
		/// </summary>
		private void lstWords_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			SetCorrectLabel(e.NewValue);
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
			EnableSay();
			bAuto = false;
			cmdAdd.Enabled = (cboAllWords.SelectedIndex >= 0);
			cmdRemove.Enabled = (lstWords.SelectedIndex >= 0);
			bThreading = false;
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
				if(!bThreading) 
				{
					cmdAutoSay.Text = "Stop";
					bAuto = true;
					EnableSay();
					t1.Start();
					t1.Priority = ThreadPriority.AboveNormal;
					cmdAdd.Enabled = false;
					cmdRemove.Enabled = false;
				}
			}
			else
			{
				cmdAutoSay.Text = "Auto Test";
				t1.Abort();
				EnableSay();
				bAuto = false;
				cmdAdd.Enabled = (cboAllWords.SelectedIndex >= 0);
				cmdRemove.Enabled = (lstWords.SelectedIndex >= 0);
			}
		}
	}
}
