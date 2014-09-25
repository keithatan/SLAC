using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.Threading;
using Pathology_Dev;

namespace PatientWindowGif
{
	/// <summary>
	/// Summary description for PatientWindow.
	/// </summary>
	public class PatientWindow : System.Windows.Forms.Form
	{
		private enum ResponseType : int
		{
			NoResponse,
			LeftUnsure, LeftSure,
			RightUnsure, RightSure
		}

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		Bitmap raiseLeftImageUnsure;
		Bitmap raiseRightImageUnsure;
		Bitmap raiseLeftImageSure;
		Bitmap raiseRightImageSure;

        Bitmap man_right_sure;
        Bitmap man_right_unsure;
        Bitmap man_left_sure;
        Bitmap man_left_unsure;
         
        Bitmap woman_right_sure;
        Bitmap woman_right_unsure;
        Bitmap woman_left_sure;
        Bitmap woman_left_unsure;
         
        Bitmap boy_right_sure;
        Bitmap boy_right_unsure;
        Bitmap boy_left_sure;
        Bitmap boy_left_unsure;
          
        Bitmap girl_right_sure;
        Bitmap girl_right_unsure;
        Bitmap girl_left_sure;
        Bitmap girl_left_unsure;
        

        Bitmap currAnimation;
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
		bool animating = false;		// if an animation is running or not
		int numFrames = 0;			// number of frames in animation
		int currFrame = 0;			// current frame in animation
		int PatientNum;
		private System.Windows.Forms.Label lblSpeechResponse;				// which Patient Image is being used
        String patientType;
        //public Pathology_Dev.Pathology pt = new Pathology_Dev.Pathology();
        //public Pathology_Dev.Pathology patient;

		// playsound wrapper
		//[DllImport("WinMM.dll")]
		//public static extern bool PlaySound(string fName, long handlePtr, int playFlags);

		/// <summary>
		/// Default Constructor
		/// </summary>
		public PatientWindow()
		{
			
            int NumPatients = 1;
			Random rand = new Random();
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			currAnimation = null;

			// enable double buffering
			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.DoubleBuffer, true);

            PatientNum = rand.Next(1, NumPatients);	// For now

            //String patientType = tempPat.returnType();
            //patient.patType();
            //System.Diagnostics.Debug.WriteLine("Patient type: " + patientType);

            // Get the streams for the patient images
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.IO.Stream raiseLeftUnsureStream = myAssembly.GetManifestResourceStream("Virtual_Lab.Images.1_raiseleft60.gif");
            System.IO.Stream raiseLeftSureStream = myAssembly.GetManifestResourceStream("Virtual_Lab.Images.1_raiseleft30.gif");
            System.IO.Stream raiseRightUnsureStream = myAssembly.GetManifestResourceStream("Virtual_Lab.Images.1_raiseright60.gif");
            System.IO.Stream raiseRightSureStream = myAssembly.GetManifestResourceStream("Virtual_Lab.Images.1_raiseright30.gif");
            //System.IO.Stream raiseRightSureStream = myAssembly.GetManifestResourceStream("Virtual_Lab.Images.BoyAnimation.gif");

         
            // MAN IMAGES
            System.IO.Stream man_left_unsure_Stream = myAssembly.GetManifestResourceStream("Virtual_Lab.Images.man_left_unsure.gif");
            System.IO.Stream man_left_sure_Stream = myAssembly.GetManifestResourceStream("Virtual_Lab.Images.man_left_sure.gif");
            System.IO.Stream man_right_unsure_Stream = myAssembly.GetManifestResourceStream("Virtual_Lab.Images.man_right_unsure.gif");
            System.IO.Stream man_right_sure_Stream = myAssembly.GetManifestResourceStream("Virtual_Lab.Images.man_right_sure.gif");
            
            // WOMAN IMAGES
            System.IO.Stream woman_left_unsure_Stream = myAssembly.GetManifestResourceStream("Virtual_Lab.Images.lady_left_unsure.gif");
            System.IO.Stream woman_left_sure_Stream = myAssembly.GetManifestResourceStream("Virtual_Lab.Images.lady_left_sure.gif");
            System.IO.Stream woman_right_unsure_Stream = myAssembly.GetManifestResourceStream("Virtual_Lab.Images.lady_right_unsure.gif");
            System.IO.Stream woman_right_sure_Stream = myAssembly.GetManifestResourceStream("Virtual_Lab.Images.lady_right_sure.gif");
             
            // BOY IMAGES
            System.IO.Stream boy_left_unsure_Stream = myAssembly.GetManifestResourceStream("Virtual_Lab.Images.boy_left_unsure.gif");
            System.IO.Stream boy_left_sure_Stream = myAssembly.GetManifestResourceStream("Virtual_Lab.Images.boy_left_sure.gif");
            System.IO.Stream boy_right_unsure_Stream = myAssembly.GetManifestResourceStream("Virtual_Lab.Images.boy_right_unsure.gif");
            System.IO.Stream boy_right_sure_Stream = myAssembly.GetManifestResourceStream("Virtual_Lab.Images.boy_right_sure.gif");
            
            // GIRL IMAGES
            System.IO.Stream girl_left_unsure_Stream = myAssembly.GetManifestResourceStream("Virtual_Lab.Images.girl_left_unsure.gif");
            System.IO.Stream girl_left_sure_Stream = myAssembly.GetManifestResourceStream("Virtual_Lab.Images.girl_left_sure.gif");
            System.IO.Stream girl_right_unsure_Stream = myAssembly.GetManifestResourceStream("Virtual_Lab.Images.girl_right_unsure.gif");
            System.IO.Stream girl_right_sure_Stream = myAssembly.GetManifestResourceStream("Virtual_Lab.Images.girl_right_sure.gif");
           
            #region Commented Out Section
            /*        
                #region Unilateral_Ostosclerosis
                case (int)Pathology_Cases.Unilateral_Otosclerosis:

                    break;
                #endregion
                #region Sudden_Onset (check this)
                case (int)Pathology_Cases.Sudden_Onset:
                   
                    break;
                #endregion
                #region Acoustic_Tumor(check this)
                case (int)Pathology_Cases.Acoustic_Tumor:
                   break;
                #endregion
                #region Progressive_Loss(check)
                case (int)Pathology_Cases.Progressive_Loss:
                  
                    break;
                #endregion
                #region Ossicular_Discontinuity(check)
                case (int)Pathology_Cases.Ossicular_Discontinuity:
                   
                    break;
                #endregion
                #region Unilateral_Otitis_Media(check - no bone)
                case (int)Pathology_Cases.Unilateral_Otitis_Media:
                 
                    break;
                #endregion
                #region Presbyacusis(check - no left ear bone)
                case (int)Pathology_Cases.Presbyacusis:
    
                    break;
                #endregion
                #region Noise_Induced_Trauma
                case (int)Pathology_Cases.Noise_Induced_Trauma:
                   
                    break;
                #endregion
                #region Bilateral_Otitis_Media
                case (int)Pathology_Cases.Bilateral_Otitis_Media:
                 
                    break;
                #endregion
                #region Bilateral_Otosclerosis
                case (int)Pathology_Cases.Bilateral_Otosclerosis:
           
                    break;
                #endregion
                #region Menieres_Disease
                case (int)Pathology_Cases.Menieres_Disease:
                 
                #endregion
                #region Microtia
                case (int)Pathology_Cases.Microtia:
                   
                    break;
                #endregion
                #region Big_Long_Switch_Statement
                /*
				case (int)Pathology_Cases.Unilateral_Otitis_Media:
					baseVal_AC[badEar] = baseVal_AC[goodEar] + rand.Next(8,11) * 5;
					baseVal_BC[badEar] = baseVal_BC[goodEar];
					for (int i = 0; i < 6; i++) 
					{
						for (int j = 0; j <= (int)Ear.right; j++) 
						{
							var = rand.Next(2);
							var--;
							var *= 5;
							AC_Thresh[i,j] = baseVal_AC[j] + var;
							
							var = rand.Next(2);
							var--;
							var *= 5;
							BC_Thresh[i,j] = baseVal_BC[j] + var;
						}
					}
					break;
				case (int)Pathology_Cases.Unilateral_Otosclerosis:
					baseVal_AC[badEar] = baseVal_AC[goodEar] + rand.Next(8,11) * 5;
					baseVal_BC[badEar] = baseVal_BC[goodEar];
					for (int i = 0; i < 6; i++) 
					{
						if (i == 3) // this is 2000 Hz notch
							baseVal_BC[badEar] = baseVal_AC[badEar] - 10;
						else
							baseVal_BC[badEar] = baseVal_AC[goodEar];

						for (int j = 0; j <= (int)Ear.right; j++) 
						{
							var = rand.Next(2);
							var--;
							var *= 5;
							AC_Thresh[i,j] = baseVal_AC[j] + var;
							
							var = rand.Next(2);
							var--;
							var *= 5;
							BC_Thresh[i,j] = baseVal_BC[j] + var;
						}
					}
					break;
				case (int)Pathology_Cases.Ossicular_Discontinuity:
					baseVal_AC[badEar] = baseVal_AC[goodEar] + rand.Next(11,14) * 5;
					baseVal_BC[badEar] = baseVal_BC[goodEar];
					for (int i = 0; i < 6; i++) 
					{
						for (int j = 0; j <= (int)Ear.right; j++) 
						{
							var = rand.Next(2);
							var--;
							var *= 5;
							AC_Thresh[i,j] = baseVal_AC[j] + var;
							
							var = rand.Next(2);
							var--;
							var *= 5;
							BC_Thresh[i,j] = baseVal_BC[j] + var;
						}
					}
					break;
				case (int)Pathology_Cases.Acoustic_Tumor:
					for (int i = 0; i < 6; i++) 
					{
						baseVal_AC[badEar] = baseVal_AC[goodEar] + (int)((i*i)/2)*5;
						baseVal_BC[badEar] = baseVal_AC[badEar];

						for (int j = 0; j <= (int)Ear.right; j++) 
						{
							var = rand.Next(2);
							var--;
							var *= 5;
							AC_Thresh[i,j] = baseVal_AC[j] + var;
							
							var = rand.Next(2);
							var--;
							var *= 5;
							BC_Thresh[i,j] = baseVal_BC[j] + var;
						}
					}
					WI_Value[badEar] = rand.Next(25, 79);
					break;
				case (int)Pathology_Cases.Sudden_Onset:
					baseVal_AC[badEar] = baseVal_AC[goodEar] + 60;
					baseVal_BC[badEar] = baseVal_AC[badEar];
					for (int i = 0; i < 6; i++) 
					{
						for (int j = 0; j <= (int)Ear.right; j++) 
						{
							AC_Thresh[i,j] = baseVal_AC[j];
							BC_Thresh[i,j] = baseVal_BC[j];
						}
					}
					WI_Value[badEar] = rand.Next(60, 88);
					break;
				case (int)Pathology_Cases.Progressive_Loss:
					for (int i = 0; i < 6; i++) 
					{
						baseVal_AC[badEar] = baseVal_AC[goodEar] + (int)((i*i)/3)*5;
						baseVal_BC[badEar] = baseVal_AC[badEar];
						for (int j = 0; j <= (int)Ear.right; j++) 
						{
							var = rand.Next(2);
							var--;
							var *= 5;
							AC_Thresh[i,j] = baseVal_AC[j] + var;
							
							var = rand.Next(2);
							var--;
							var *= 5;
							BC_Thresh[i,j] = baseVal_BC[j] + var;
						}
					}
					WI_Value[badEar] = rand.Next(60, 88);
					break;
				case (int)Pathology_Cases.Bilateral_Otitis_Media:
					baseVal_AC[badEar] = baseVal_AC[goodEar] + rand.Next(8,13) * 5;
					baseVal_BC[badEar] = baseVal_BC[goodEar];
					baseVal_AC[goodEar] = baseVal_AC[badEar]; // no good ear in bilat
					for (int i = 0; i < 6; i++) 
					{
						for (int j = 0; j <= (int)Ear.right; j++) 
						{
							var = rand.Next(2);
							var--;
							var *= 5;
							AC_Thresh[i,j] = baseVal_AC[badEar] + var;
							
							var = rand.Next(2);
							var--;
							var *= 5;
							BC_Thresh[i,j] = baseVal_BC[badEar] + var;
						}
					}
					break;
				case (int)Pathology_Cases.Bilateral_Otosclerosis:
					baseVal_AC[badEar] = baseVal_AC[goodEar] + rand.Next(8,11) * 5;
					baseVal_AC[goodEar] = baseVal_AC[badEar]; // no good ear in bilat
					for (int i = 0; i < 6; i++) 
					{
						if (i == 3) // this is 2000 Hz notch
							baseVal_BC[badEar] = baseVal_AC[badEar];
						else
							baseVal_BC[badEar] = baseVal_BC[goodEar];

						for (int j = 0; j <= (int)Ear.right; j++) 
						{
							var = rand.Next(2);
							var--;
							var *= 5;
							AC_Thresh[i,j] = baseVal_AC[badEar] + var;
							
							var = rand.Next(2);
							var--;
							var *= 5;
							BC_Thresh[i,j] = baseVal_BC[badEar] + var;
						}
					}
					break;
				case (int)Pathology_Cases.Microtia:
					baseVal_AC[badEar] = baseVal_AC[goodEar] + 60;
					baseVal_BC[badEar] = baseVal_BC[goodEar];
					for (int i = 0; i < 6; i++) 
					{
						for (int j = 0; j <= (int)Ear.right; j++) 
						{
							var = rand.Next(2);
							var--;
							var *= 5;
							AC_Thresh[i,j] = baseVal_AC[badEar] + var;

							var = rand.Next(2);
							var--;
							var *= 5;
							BC_Thresh[i,j] = baseVal_BC[badEar] + var;
						}
					}
					break;
				case (int)Pathology_Cases.Menieres_Disease:
					// this comes and goes .... so if happened is 0 - no loss
					int happened = rand.Next(2);
					baseVal_AC[badEar] = rand.Next(0,3) * 5 + happened * rand.Next(6,11) * 5;
					baseVal_BC[badEar] = baseVal_AC[badEar];
					for (int i = 0; i < 6; i++) 
					{
						for (int j = 0; j <= (int)Ear.right; j++) 
						{
							var = rand.Next(2);
							var--;
							var *= 5;
							AC_Thresh[i,j] = baseVal_AC[badEar] + var;

							var = rand.Next(2);
							var--;
							var *= 5;
							BC_Thresh[i,j] = baseVal_BC[badEar] + var;
						}
					}
					break;
				case (int)Pathology_Cases.Noise_Induced_Trauma:
					baseVal_AC[goodEar] = rand.Next(5,8) * 5;
					baseVal_BC[goodEar] = baseVal_AC[badEar];
					for (int i = 0; i < 6; i++) 
					{
						if (i == 3) // this is 2000 Hz rise
						{
							baseVal_AC[badEar] = baseVal_AC[goodEar] + rand.Next(2,4) * 5;
							baseVal_BC[badEar] = baseVal_AC[badEar];
						}
						else if (i == 4)
						{
							baseVal_AC[badEar] = baseVal_AC[goodEar] + rand.Next(6,8) * 5;
							baseVal_BC[badEar] = baseVal_AC[badEar];
						}
						else
						{
							baseVal_AC[badEar] = baseVal_AC[goodEar];
							baseVal_BC[badEar] = baseVal_AC[badEar];
						}

						for (int j = 0; j <= (int)Ear.right; j++) 
						{
							var = rand.Next(2);
							var--;
							var *= 5;
							AC_Thresh[i,j] = baseVal_AC[badEar] + var;
							
							var = rand.Next(2);
							var--;
							var *= 5;
							BC_Thresh[i,j] = baseVal_BC[badEar] + var;
						}
					}
					break;
				case (int)Pathology_Cases.Presbyacusis:
					baseVal_AC[goodEar] = rand.Next(0,3) * 5;
					baseVal_BC[goodEar] = baseVal_AC[badEar];
					for (int i = 0; i < 6; i++) 
					{
						if (i < 3)
						{
							baseVal_AC[badEar] = baseVal_AC[goodEar] + i * 5;
							baseVal_BC[badEar] = baseVal_AC[badEar];
						}
						else if (i <= 4) // this is 2000 Hz rise
						{
							baseVal_AC[badEar] = baseVal_AC[goodEar] + i*(i-1)*5;
							baseVal_BC[badEar] = baseVal_AC[badEar];
						}
						else
						{
							baseVal_AC[badEar] = baseVal_AC[goodEar] + (2*i+3) * 5;
							baseVal_BC[badEar] = baseVal_AC[badEar];
						}

						for (int j = 0; j <= (int)Ear.right; j++) 
						{
							var = rand.Next(2);
							var--;
							var *= 5;
							AC_Thresh[i,j] = baseVal_AC[badEar] + var;
							
							var = rand.Next(2);
							var--;
							var *= 5;
							BC_Thresh[i,j] = baseVal_BC[badEar] + var;
						}
					}
					break;
				default:
					break;*/
                #endregion;

            // Load the images into the bitmaps from the streams created above
            raiseLeftImageUnsure = new Bitmap(raiseLeftUnsureStream);
            raiseRightImageUnsure = new Bitmap(raiseRightUnsureStream);
            raiseLeftImageSure = new Bitmap(raiseLeftSureStream);
            raiseRightImageSure = new Bitmap(raiseRightSureStream);


            man_right_sure = new Bitmap(man_right_sure_Stream);
            man_right_unsure = new Bitmap(man_right_unsure_Stream); 
            man_left_sure = new Bitmap(man_left_sure_Stream); 
            man_left_unsure = new Bitmap(man_left_unsure_Stream); 
            
            woman_right_sure = new Bitmap(woman_right_sure_Stream);
            woman_right_unsure = new Bitmap(woman_right_unsure_Stream); 
            woman_left_sure = new Bitmap(woman_left_sure_Stream); 
            woman_left_unsure = new Bitmap(woman_left_unsure_Stream); 
            
            boy_right_sure = new Bitmap(boy_right_sure_Stream);
            boy_right_unsure = new Bitmap(boy_right_unsure_Stream); 
            boy_left_sure = new Bitmap(boy_left_sure_Stream); 
            boy_left_unsure = new Bitmap(boy_left_unsure_Stream); 
            
            girl_right_sure = new Bitmap(girl_right_sure_Stream);
            girl_right_unsure = new Bitmap(girl_right_unsure_Stream); 
            girl_left_sure = new Bitmap(girl_left_sure_Stream); 
            girl_left_unsure = new Bitmap(girl_left_unsure_Stream);  
            
        
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
            this.lblSpeechResponse = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSpeechResponse
            // 
            this.lblSpeechResponse.BackColor = System.Drawing.Color.Transparent;
            this.lblSpeechResponse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeechResponse.Location = new System.Drawing.Point(16, 8);
            this.lblSpeechResponse.Name = "lblSpeechResponse";
            this.lblSpeechResponse.Size = new System.Drawing.Size(264, 32);
            this.lblSpeechResponse.TabIndex = 0;
            this.lblSpeechResponse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PatientWindow
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(496, 458);
            this.ControlBox = false;
            this.Controls.Add(this.lblSpeechResponse);
            this.Name = "PatientWindow";
            this.Text = "Patient";
            this.Load += new System.EventHandler(this.PatientWindow_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PatientWindow_Paint);
            this.Resize += new System.EventHandler(this.PatientWindow_Resize);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Begins the animation
		/// </summary>
		private void AnimateImage() 
		{
			if (!animating) 
			{
				//Begin the animation only once.
				currFrame = 0;
				ImageAnimator.Animate(currAnimation, new EventHandler(this.OnFrameChanged));
				animating = true;
			}
		}

		/// <summary>
		/// Called when a frame changes
		/// </summary>
		private void OnFrameChanged(object o, EventArgs e) 
		{
			// repaint
            Rectangle imageRect = new Rectangle(new Point(0, 0), this.Size);

            if (/*animating &&*/ currFrame < numFrames) 
            {
                currFrame++;
            // get the next frame
                ImageAnimator.UpdateFrames(this.currAnimation);

            }
            else// if (currFrame >= numFrames) 
            {
            	animating = false;
            	ImageAnimator.StopAnimate(this.currAnimation, new EventHandler(this.OnFrameChanged));
            }

            // Tell windows that the current image drawn is not valid and needs to update
			this.Invalidate();
		}

		/// <summary>
		/// Paint function of the window
		/// </summary>
		private void PatientWindow_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if (currAnimation == null) 
			{
				return;		// no image
			}
			// otherwise draw things
			
            // the image will be scaled to fill the window
            Rectangle imageRect = new Rectangle(new Point(0,0), this.Size);
			
            // draw the current frame in the animation scaled to the height & width of the patient window
			e.Graphics.DrawImage(this.currAnimation, imageRect);
		}

		/// <summary>
		/// This can be used to "load" the patient when a new patient is selected
		/// In time parameters can be passed here describing the type of patient to use
		/// </summary>
        public void ShowPatient(String patientType)
		{
			//currAnimation = raiseLeftImageSure;
            System.Diagnostics.Debug.WriteLine("Patient type in ShowPatient: " + patientType);
            switch (patientType)
            {
                case "Woman":
                    currAnimation = woman_left_sure;
                    break;
                case "Man":
                    currAnimation = man_right_sure;
                    break;
                case "Boy":
                    currAnimation = boy_right_sure;
                    break;
                case "Girl":
                    currAnimation = girl_right_sure;
                    break;
            }
           // currAnimation = raiseRightImageSure;
			this.Invalidate();
		}

		/// <summary>
		/// Shows the animation requested
		/// </summary>
		/// <param name="respType">The integer value of an enumerated type describing the response</param>
		public void ShowAnimation(int respType, string patientType) 
		{
            System.Diagnostics.Debug.WriteLine("Patient type: " + patientType);
			// don't allow animations to stack up.
			if (!animating) 
			{
				// switch to the correct gif
                /*
				switch (respType) 
				{
					case (int)ResponseType.LeftSure:
						currAnimation = raiseLeftImageSure;
						break;
					case (int)ResponseType.LeftUnsure:
						currAnimation = raiseLeftImageUnsure;
						break;
					case (int)ResponseType.RightSure:
						currAnimation = raiseRightImageSure;
						break;
					case (int)ResponseType.RightUnsure:
						currAnimation = raiseRightImageUnsure;
						break;
                    default:
                        {
                            Console.WriteLine("Breaking with default");
                            return;
                        }
                } */

                #region Big Animation Switcher (NOT WORKING)
                
                switch (patientType)
                {
                    case ("Woman"):
                        switch (respType)
                        {
                            case (int)ResponseType.LeftSure:
						        currAnimation = woman_left_sure;
						        break;
					        case (int)ResponseType.LeftUnsure:
					        	currAnimation = woman_left_unsure;
					        	break;
				        	case (int)ResponseType.RightSure:
				        		currAnimation = woman_right_sure;
				        		break;
				        	case (int)ResponseType.RightUnsure:
				        		currAnimation = woman_right_unsure;
				        		break;
                            default:
                            {
                                 Console.WriteLine("Breaking with default");
                                 return;
                            }
                        }
                        break;

                    case ("Man"):
                        switch (respType)
                        {
                            case (int)ResponseType.LeftSure:
                                currAnimation = man_left_sure;
                                break;
                            case (int)ResponseType.LeftUnsure:
                                currAnimation = man_left_unsure;
                                break;
                            case (int)ResponseType.RightSure:
                                currAnimation = man_right_sure;
                                break;
                            case (int)ResponseType.RightUnsure:
                                currAnimation = man_right_unsure;
                                break;
                            default:
                                {
                                    Console.WriteLine("Breaking with default");
                                    return;
                                }
                        }
                        break;

                    case ("Boy"):
                        switch (respType)
                        {
                            case (int)ResponseType.LeftSure:
                                currAnimation = boy_left_sure;
                                break;
                            case (int)ResponseType.LeftUnsure:
                                currAnimation = boy_left_unsure;
                                break;
                            case (int)ResponseType.RightSure:
                                currAnimation = boy_right_sure;
                                break;
                            case (int)ResponseType.RightUnsure:
                                currAnimation = boy_right_unsure;
                                break;
                            default:
                                {
                                    Console.WriteLine("Breaking with default");
                                    return;
                                }
                        }
                        break;

                    case ("Girl"):
                        switch (respType)
                        {
                            case (int)ResponseType.LeftSure:
                                currAnimation = girl_left_sure;
                                break;
                            case (int)ResponseType.LeftUnsure:
                                currAnimation = girl_left_unsure;
                                break;
                            case (int)ResponseType.RightSure:
                                currAnimation = girl_right_sure;
                                break;
                            case (int)ResponseType.RightUnsure:
                                currAnimation = girl_right_unsure;
                                break;
                            default:
                                {
                                    Console.WriteLine("Breaking with default");
                                    return;
                                }
                        }
                        break;
                }
                
                #endregion;

                // get the number of frames
				numFrames = currAnimation.GetFrameCount(
					new System.Drawing.Imaging.FrameDimension(
					currAnimation.FrameDimensionsList[0]));

				//begin the animation
				AnimateImage();
			}
		}

		/// <summary>
		/// This function will have the patient respond with the appropriate word.
		/// Threading is not an issue here as nothing else needs to be done in this module
		/// simultaneously.
		/// </summary>
		/// <param name="Word">Which word to say</param>
		public void PatientSpeechRespond(String Word)
		{
            /* Finish Later
			const int Time = 2500;

			if(Word != String.Empty)
			{
				Shift(false);
				if(Word == "DontKnow") lblSpeechResponse.Text = "I don't know...";
				else lblSpeechResponse.Text = Word + "!";
				DateTime dt = DateTime.Now;
				String filename = "Sounds\\Patient\\" + Convert.ToString(PatientNum) + "_" + Word + ".wav";
				//PlaySound(filename, 0, SND_ASYNC);
				while(dt.Ticks + Time*TimeSpan.TicksPerMillisecond > DateTime.Now.Ticks);
				lblSpeechResponse.Text = String.Empty;
				Shift(true);
			}
            */
		}

		/// <summary>
		/// Resize function
		/// </summary>
		private void PatientWindow_Resize(object sender, System.EventArgs e)
		{
			// repaint on resize
			this.Invalidate();
		}

		/// <summary>
		/// This function will set the text to "Patient - [Pathology Type]"
		/// </summary>
		/// <param name="Pathology">Pathology of Patient</param>
		public void SetText(String Pathology)
		{
			this.Text = "Patient - " + Pathology;
		}

		/// <summary>
		/// Makes the patient look like he/she is shifting
		/// </summary>
		/// <param name="bLeft">True: use left image, False: use right image</param>
		public void Shift(bool bLeft)
		{
			currAnimation = bLeft ? raiseLeftImageSure : raiseRightImageSure;
			this.Invalidate();
		}

        private void PatientWindow_Load(object sender, EventArgs e)
        {

        }
	}
}