using System;
using System.Windows.Forms;
using Pathology_Dev;
using Virtual_Lab;

namespace Patient
{
	/// <summary>
	/// To be used for all response descriptions 
	/// (so that response can easily be grown / shrunk)
	/// </summary>
	public enum ResponseType : int
	{
		NoResponse,
		LeftUnsure, LeftSure,
		RightUnsure, RightSure
	}

	/// <summary>
	/// To be used when describing whether a test is air or bone conduction
	/// </summary>
	public enum TestType : int
	{
		BC, AC
	}

	/// <summary>
	/// To be used when describing Speech Audiometry responses
	/// </summary>
	public enum SpeechRespType : int
	{
		Incorrect = -1,
		Unsure = 0,
		Correct = 1
	}

    //private delegate int PathologyThreshold(int, Ear);

	/// <summary>
	/// Summary description for Patient.
	/// </summary>
	public class Patient
	{
		public Pathology path;
		private CaseHistoryForm chf;
		public bool validPatient;
        String patType = "Default";

		public Patient()
		{
			validPatient = false;
		}

		/// <summary>
		/// use this method to create a new patient with a desired pathology
		/// </summary>
		/// <param name="pathology">pathology enumernation type</param>
		public void NewPatient(int pathology) 
		{
			path = new Pathology(pathology);
           /* if (pathology == (int)Pathology_Cases.Unilateral_Otosclerosis)
            {
                patType = "Woman";
                System.Diagnostics.Debug.WriteLine("Patient type in Patient class: " + patType);
            }*/
            switch (pathology)
            {
                
                case ((int)Pathology_Cases.Bilateral_Otosclerosis):
                case ((int)Pathology_Cases.Unilateral_Otosclerosis):
                case ((int)Pathology_Cases.Presbyacusis):
                    patType = "Woman";
                    break;
                case ((int)Pathology_Cases.Noise_Induced_Trauma):
                case ((int)Pathology_Cases.Acoustic_Tumor):
                case ((int)Pathology_Cases.Sudden_Onset):
                    patType = "Man";
                    break;
                
                case ((int)Pathology_Cases.Unilateral_Otitis_Media):
                case ((int)Pathology_Cases.Microtia):
                case ((int)Pathology_Cases.Ossicular_Discontinuity):
                    patType = "Boy";
                    break;
                case ((int)Pathology_Cases.Progressive_Loss):
                case ((int)Pathology_Cases.Bilateral_Otitis_Media):
                case ((int)Pathology_Cases.Menieres_Disease):
                    patType = "Girl";
                    break;
            }
               //showCaseHistory();
			validPatient = true;
		}

		/// <summary>
		/// Use this method to create a new random patient
        /// Obsolete, send a random value to the other NewPatient
        /// function.
		/// </summary>
		/*
         * public void NewPatient()
		{
			path = new Pathology();
			//showCaseHistory();	
			validPatient = true;
		}
        */

        //Sets the patient type for this patient
        public void setType(String s)
        {
            patType = s;
        }

        //Returns the type of patient
        public String returnPatientType()
        {
            return patType;
        }
		/// <summary>
		/// Use this method to show case history infomation to the user
		/// </summary>
		private void showCaseHistory() 
		{
			chf = new CaseHistoryForm();
			chf.FillCaseHistory(path.CaseHist);
			chf.Show();
		}

		/// <summary>
		/// This function returns an enumerated type to describe the patients response to
		/// to a pure tone test
		///			ex.
		///			DetermineResponsePureTone(Ear.Left,Freq.f_250,TestType.AC, new int[2]{40,40},
		///			               new int[2]{50,20}, ref result);
		/// </summary>
		/// <param name="testEar">pass in the ENUMERATED test ear</param>
		/// <param name="freq">pass in the ENUMERATED frequency</param>
		/// <param name="testType">pass in the ENUMERATED AC or BC type </param>
		/// <param name="IA">pass in an array of IA's [left ear, right ear]</param>
		/// <param name="dBLevels">pass in an array of dB Level's [left ear, right ear]</param>
		/// <param name="result">a reference to a string to store result at current test</param>
		/// <returns>an enumerated type describing the response (includes ear, and relative surety)</returns>
		public int DetermineResponsePureTone(AudiometerPanel.channelSettings TestChannel, 
            AudiometerPanel.channelSettings MaskedChannel, AudiometerPanel.AudiometerPanelSettings ameterSettings)
		{

            int freq = ameterSettings.frequency; // simplify ameterSettings.frequency
            Ear testEar = TestChannel.route;
            Ear ntEar = testEar == Ear.left ? Ear.right : Ear.left;

            int NonTestEarThresh;

            int UnmaskedThreshold, MaskedThreshold;

            int OE;
            int[] IA = new int[2];

			Random rand = new Random(); // Randomize patient response when not masking

			int thresh;
            if (TestChannel.trans == AudiometerPanel.TransducerType.Bone)
            {
                MaskedThreshold = path.BC_Mask_Val(freq, testEar);
                UnmaskedThreshold = path.BC_Thresh_Val(freq, testEar);
                NonTestEarThresh = path.BC_Thresh_Val(freq, ntEar);
            
                // Determine OE
                switch (ameterSettings.frequency)
                {
                    case 250:
                        OE = 20;
                        break;
                    case 500:
                        OE = 15;
                        break;
                    case 1000:
                        OE = 10;
                        break;
                    default:
                        OE = 0;
                        break;
                }
            }
            else
            {
                MaskedThreshold = path.AC_Mask_Val(freq, testEar);
                UnmaskedThreshold = path.AC_Thresh_Val(freq, testEar);
                NonTestEarThresh = path.AC_Thresh_Val(freq, ntEar);

                OE = 0;
            }

            #region Interaural Attenuation
            switch (TestChannel.trans)
            {
                case AudiometerPanel.TransducerType.Phone:
                    IA[(int)testEar] = 40;
                    break;
                case AudiometerPanel.TransducerType.Insert:
                    IA[(int)testEar] = 60;
                    break;
                default:
                    IA[(int)testEar] = 0;
                    break;
            }
            // determine what the IA values	are	for	the	non-test Ear
            switch (MaskedChannel.trans)
            {
                case AudiometerPanel.TransducerType.Phone:
                    IA[(int)ntEar] = 40;
                    break;
                case AudiometerPanel.TransducerType.Insert:
                    IA[(int)ntEar] = 60;
                    break;
                default:
                    IA[(int)ntEar] = 0;
                    break;
            }
            #endregion
 
            int minPlateauPoint;
            int maxPlateauPoint = 0;

            // Determine the minimum and maximum masking levels (Min and Max equations)
            // Maximum: BCnte + IA - 5  for bone and air
            // Minimum: BCnte + 15 + OE for bone 
            //          ACnte + 15      for air (NOTE: OE set to 0 if using air)
            int maxMaskingLevel = IA[(int)ntEar] + path.BC_Thresh_Val(freq, ntEar) - 5;
            int minMaskingLevel = NonTestEarThresh + 15 + OE;

            // Determine the center of the minimum and maximum masking levels
            // The plateau should occur here
            float averageMasking = (float)((maxMaskingLevel + minMaskingLevel) / 2.0);

            // Use truncation to determine if the patient will respond 3 times or 4 times
            // at the plateau
            int truncatedAverage = (int)averageMasking;
            if ((float)truncatedAverage != averageMasking)
            {
                // If the average is not an integer, then use 4 points for the plateau
                // by rounding down to the lowest 5 db point and offsetting the maximum
                // plateau point by 5 db
                truncatedAverage -= 2;
                maxPlateauPoint = 5;
            }

            // Determine where the beginning and end of the plateau is
            minPlateauPoint = truncatedAverage - 5;
            maxPlateauPoint += truncatedAverage + 5;

            // If the minimum masking level is greater than, equal to, or within 15 dB of the
            // maximimum masking level, then this is a masking dilemma
            // 15 dB range is due to the fact that a plateau must be at least 3 points wide
            // to determine true hearing level
            if (MaskedChannel.interrupt && maxMaskingLevel - minMaskingLevel < 15)
                // Since a masking dilemma has been encountered, the patient should not plateau
                maxPlateauPoint = minPlateauPoint;

            if (MaskedChannel.interrupt)
            {
                // Masking

                // Assume the patient will respond at the masked level
                thresh = MaskedThreshold;

                // Determine if the masked noise is to loud or soft for the masked level
                if (MaskedChannel.volume > maxPlateauPoint)
                {
                    // If the masked noise is too loud, then the patient response will be the masked level
                    // plus the difference between the maximum plateau point and the masked test level
                    thresh = MaskedThreshold + MaskedChannel.volume - maxPlateauPoint;
                }

                // check for under masking
                else if (MaskedChannel.volume < minPlateauPoint)
                {
                    // If the masked noise is too soft, then the patient response will be the masked level
                    // plus the difference between the minimum plateau point and the masked test level
                    thresh = MaskedThreshold + MaskedChannel.volume - minPlateauPoint;

                    // If the new threshold is less than the actual bone level, then just assign the threshold to the bone level
                    if (thresh < UnmaskedThreshold)
                        thresh = UnmaskedThreshold;
                }
            }      
            else
            {
                // Not masking, patient responds at the unmasked level
                thresh = UnmaskedThreshold;
            }
            
            // determine response
            if (TestChannel.volume == thresh)
		    {
    			// if masking is not a factor - respond occasionally
                if (MaskedChannel.interrupt == true || rand.Next(10) <= 7)
                    return (testEar == (int)Ear.left) ? (int)ResponseType.LeftUnsure : (int)ResponseType.RightUnsure;
            }
            else if (TestChannel.volume >= thresh + 5)
			{
				return (testEar == (int)Ear.left) ? (int)ResponseType.LeftSure : (int)ResponseType.RightSure;
			}

			return (int)ResponseType.NoResponse;
		}

		/// <summary>
		/// This will determine the response of speech stimuli with masking
		/// </summary>
		/// <param name="testEar">Which ear is receiving Speech Stimuli</param>
		/// <param name="Type">Which type of speech test is being given</param>
		/// <param name="IA">Interaural attenuation: 2 element array</param>
		/// <param name="dBLevels">2 element array of the dB levels of both channels</param>
		/// <returns>The response to this specific speech stimulus</returns>
		public int DetermineResponseSpeech(int testEar, string Type, int[] IA, int[] dBLevels)
		{
/*
			Random rand = new Random();
			int ntEar = (testEar + 1) % 2;
			int thresh = path.SRT_Thresh_Val(testEar);
			int LowestBC = path.GetMinimumBC(testEar);

			// test for overmasking
			if (MaskedChannel.tone > IA[ntEar] + LowestBC) 
			{
				thresh += (MaskedChannel.tone - IA[ntEar] - LowestBC);
			}
			// check for under masking
			if (TestChannel.tone >= IA[testEar] + MaskedChannel.tone + LowestBC)
			{
				thresh = MaskedChannel.tone + IA[testEar] + LowestBC;
			}

			// determine response
			// if 5 or more above threshold
			if(TestChannel.tone > thresh + 5)
			{
				if(Type == "SRT") return (int)SpeechRespType.Correct;
				if(Type == "WI")
				{
					if(rand.Next(0, 100) < path.GetWI(testEar)) return ((int)SpeechRespType.Correct);
					else return ((int)SpeechRespType.Unsure);
				}
			}
			// if within 5 dB of threshold
			if(TestChannel.tone >= thresh - 5)
			{
				if(Type == "SRT")
				{
					if((rand.Next() % 2) == 1) return ((int)SpeechRespType.Correct);
					else return ((int)SpeechRespType.Unsure);
				}
				if(Type == "WI")
				{
					int temp = rand.Next(0, 100);
					if((temp < path.GetWI(testEar)) && (temp % 2 == 1)) return ((int)SpeechRespType.Correct);
					else return ((int)SpeechRespType.Unsure);
				}
			}
			// if 5 or more under threshold
 */
			return (int)SpeechRespType.Incorrect;
		}
		
		/// <summary>
		/// This function returns the pathology member of the class
		/// </summary>
		/// <returns>pathology object</returns>
		public Pathology GetPath() 
		{
			return path;
		}

		/// <summary>
		/// This function will return the response for a speech stimulus for SRT
		/// </summary>
		/// <param name="TestEar">Which ear is being tested</param>
		/// <param name="dBLevel">dB Level of the word being said</param>
		/// <returns>enumerated type of response representing patient's response</returns>
		public int DetermineResponseSRT(int TestEar, int dBLevel)
		{
			if((TestEar == (int)Ear.left) || (TestEar == (int)Ear.right))
			{
				int dbDifference = dBLevel - path.SRT_Thresh_Val(TestEar);
				if(dbDifference >= 5) return ((int)SpeechRespType.Correct);
				if(dbDifference <= -5) return ((int)SpeechRespType.Incorrect);

				// within +/- 5 dB of threshold so there's 50% accuracy
				Random rand = new Random();
				if((rand.Next() % 2) == 1) return ((int)SpeechRespType.Correct);
				else return ((int)SpeechRespType.Unsure);
			}
			else return -2;
		}

		/// <summary>
		/// This function will determine the WI response based on the inputs
		/// </summary>
		/// <param name="TestEar">Which ear is being tested</param>
		/// <param name="dBLevel">dB Level of the word being said</param>
		/// <returns>enumerated type of response representing patient's response</returns>
		public int DetermineResponseWI(int TestEar, int dBLevel)
		{
			if((TestEar == (int)Ear.left) || (TestEar == (int)Ear.right))
			{
				int dbDifference = dBLevel - path.SRT_Thresh_Val(TestEar);
				if(dbDifference < 10) return ((int)SpeechRespType.Incorrect);
				Random rand = new Random();
				if(rand.Next(0, 100) < path.GetWI(TestEar)) return ((int)SpeechRespType.Correct);
				else return ((int)SpeechRespType.Unsure);
			}
			else return -2;
		}
	}
}
