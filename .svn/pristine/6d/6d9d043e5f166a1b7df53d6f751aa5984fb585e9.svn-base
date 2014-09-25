
using System;
using System.Windows.Forms;
using Virtual_Lab;

namespace Pathology_Dev
{
	/// <summary>
	/// the pathologies are used in an enumeration type, this is public so that everyone can work
	///  with the same info
	/// </summary>
	public enum Pathology_Cases : int
	{
		Unilateral_Otitis_Media,
        Unilateral_Otosclerosis,
        Ossicular_Discontinuity,
		Acoustic_Tumor,
        Sudden_Onset,
        Progressive_Loss,
        Bilateral_Otitis_Media,
        Bilateral_Otosclerosis,
		Microtia,
        Menieres_Disease,
        Noise_Induced_Trauma,
        Presbyacusis
	}

    public enum Ear : int
    {
        left = 0, right = 1, both = 2, neither = 3
    }

    /*public enum Patient : int
    {
        man = 0, woman = 1, boy = 2, girl = 3
    }*/

	/// <summary>
	/// Pathology is the class responsible for creating and keeping track of the patients
	/// threshold levels as well as case history and other pertinent information
	/// </summary>
	public class Pathology
	{
        // Private Constants
        private const int MinThreshold = -10;   // Minimum for any normal hearing value
        private const int MaxThreshold = 20;    // Maximum for any normal hearing value

        private const int MaxACtoBCDiff = 10;   // Maximum difference between AC and BC of the same ear (same or neihboring frequencies)
        private const int MaxBCtoBCDiff = 5;    // Maximum difference between BC values for both ears at the same frequency
        private const int MaxACtoACDiff = 10;   // Maximum difference between AC values for one ear at neighboring frequencies
        private const int MaxFreqBCtoBCDiff = 10;   // Maximum difference between BC values for the same ear at different frequency

		// Here the class variables are defined
		private int[,] AC_Thresh;
		private int[,] BC_Thresh;
        private int[,] AC_Mask;
        private int[,] BC_Mask;
        private Ear badEar;
        private Ear goodEar;
		private int[] SRT_Thresh;		// size of 2: 0 is left, 1 is right
		private int[] SRT_Masking;
		private int[] WI_Value;
		private int[] WI_Level;
		private int[] WI_Masking;
        public int pathInt; // delete me
		private string caseHistory;
		private string pathType;
        private string patientType;
        //public Patient patient;
        private int traumaDiff;
		

        public int GoodBadEar()
        {
            Random rand_ear = new Random();
            int earCase = rand_ear.Next(2);


            return earCase;
        }
		/// <summary>
		/// Default Constructor used when 'random' is selected
		/// </summary>
		public Pathology()
		{
			///
			/// This is the random pathology constructor
			///

			Random rand = new Random();
			int pathCase = rand.Next(12);

			CreatePathology(pathCase);
		}

		/// <summary>
		/// Constructor with a Pathology passed to it
		/// </summary>
		/// <param name="pathCase">Which Pathology to use</param>
		public Pathology(int pathCase)
		{
			///
			/// This is the selected pathology constructor
			///

			CreatePathology(pathCase);
		}


		/// <summary>
		/// This function takes the pathology case selected and creates the threshold
		/// arrays as well as the case history info and all other pertinent information
		/// </summary>
		/// <param name="pathCase">Which Pathology to use</param>
		private void CreatePathology (int pathCase) 
		{
            Random rand = new Random();
            pathInt = pathCase; // delete me
			AC_Thresh = new int[6,2];
			BC_Thresh = new int[6,2];
            AC_Mask = new int[6, 2];
            BC_Mask = new int[6, 2];
			caseHistory = "";
            if (pathCase < 0)
                pathCase = rand.Next(12);
            
			pathType = MakePathType(pathCase);

			AssignThresholds(pathCase);
			AssignCaseHistory(pathCase);
		}

		/// <summary>
		/// This function assigns the pathology threshold values
		/// </summary>
		/// <param name="pathCase">Which Pathology to use</param>
		private void AssignThresholds (int pathCase) 
		{
			int[, ,] normHearing = RandomNormalHearing();
            int[, ,] normHearingNew = RandomNormalHearingNew();

            /*
            int count = 0;
            while (count++ < 10000000)
            {
                normHearingNew = RandomNormalHearingNew();
                //TestNormalHearing(normHearing);
                TestNormalHearing(normHearingNew);
            }
            */

            Random rand = new Random(); // General random variable

            int rand_badEar = new int();
            
            rand_badEar = GoodBadEar();
            System.Diagnostics.Debug.WriteLine("Ear Random Number" + rand_badEar);
            //int count = 0;
            //while (count++ < 10000000)
            //{
            switch (pathCase)
            {
                #region Unilateral_Ostosclerosis (Completed)
                case (int)Pathology_Cases.Unilateral_Otosclerosis:

                    // James Golike
                    // 2/06/2012 

                    // Bad ear pre-randomized prior to switch block
                    badEar = (Ear)rand_badEar;
                    goodEar = (Ear)Math.Abs(rand_badEar - 1);

                    // normal hearing
                    for (int i = 0; i < 6; i++) // good ear
                    {
                        AC_Thresh[i, (int)goodEar] = normHearing[i, 1, 0];
                        BC_Thresh[i, (int)goodEar] = normHearing[i, 0, 0];
                        // good ear is ear 0
                        // bad ear is ear 1
                        AC_Thresh[i, (int)badEar] = normHearing[i, 1, 1];
                        BC_Thresh[i, (int)badEar] = normHearing[i, 0, 1];

                    }

                    for (int i = 3; i < 6; i++)
                    {
                        BC_Thresh[i, (int)badEar] = rand.Next(25, 66);
                        // Code from Bilateral Ostosclerosis. Same Pathology but excluded to one ear.
                        // BC_Thresh[i, (int)goodEar] = BC_Thresh[i, (int)badEar] - rand.Next(0, 10);
                    }

                                     
                    /*AC_Thresh[0, (int)goodEar] = 10;
                    AC_Thresh[0, (int)badEar] = 20;
                    BC_Thresh[0, (int)goodEar] = 10;
                    BC_Thresh[0, (int)badEar] = 15;
                    BC_Mask[0, (int)badEar] = 20;
                    // 500
                    AC_Thresh[1, (int)goodEar] = 10;
                    AC_Thresh[1, (int)badEar] = 20;
                    BC_Thresh[1, (int)goodEar] = 10;
                    BC_Thresh[1, (int)badEar] = 10;
                    BC_Mask[1, (int)badEar] = 20;
                    // 1000
                    AC_Thresh[2, (int)goodEar] = 15;
                    AC_Thresh[2, (int)badEar] = 20;
                    BC_Thresh[2, (int)goodEar] = 15;
                    BC_Thresh[2, (int)badEar] = 10;
                    BC_Mask[2, (int)badEar] = 20;
                    // 2000
                    AC_Thresh[3, (int)goodEar] = 15;
                    AC_Thresh[3, (int)badEar] = 50;
                    BC_Thresh[3, (int)goodEar] = 15;
                    BC_Thresh[3, (int)badEar] = 15;
                    BC_Mask[3, (int)badEar] = 20;
                    // 4000
                    AC_Thresh[4, (int)goodEar] = 20;
                    AC_Thresh[4, (int)badEar] = 50;
                    BC_Thresh[4, (int)goodEar] = 20;
                    BC_Thresh[4, (int)badEar] = 25;
                    BC_Mask[4, (int)badEar] = 30;
                    // 8000
                    AC_Thresh[5, (int)goodEar] = 25;
                    AC_Thresh[5, (int)badEar] = 25;
                    //BC_Thresh[5, (int) goodEar] = ??;
                    //BC_Thresh[5, (int) badEar] = ??;*/
                    
                    break;
                #endregion
                #region Sudden_Onset (Not Done)
                case (int)Pathology_Cases.Sudden_Onset:
                    if (rand_badEar == 0)
                    {
                        goodEar = Ear.left;
                        badEar = Ear.right;
                    }
                    else
                    {
                        goodEar = Ear.right;
                        badEar = Ear.left;
                    }
                    // 250
                    AC_Thresh[0, (int)goodEar] = 70;
                    AC_Thresh[0, (int)badEar] = 20;
                    BC_Thresh[0, (int)goodEar] = 25;
                    BC_Thresh[0, (int)badEar] = 20;
                    BC_Mask[0, (int)goodEar] = 70;
                    AC_Mask[0, (int)goodEar] = 70;
                    // 500
                    AC_Thresh[1, (int)goodEar] = 80;
                    AC_Thresh[1, (int)badEar] = 20;
                    BC_Thresh[1, (int)goodEar] = 20;
                    BC_Thresh[1, (int)badEar] = 20;
                    BC_Mask[1, (int)goodEar] = 80;
                    AC_Mask[1, (int)goodEar] = 80;
                    // 1000
                    AC_Thresh[2, (int)goodEar] = 90;
                    AC_Thresh[2, (int)badEar] = 25;
                    BC_Thresh[2, (int)goodEar] = 25;
                    BC_Thresh[2, (int)badEar] = 25;
                    BC_Mask[2, (int)Ear.left] = 90;
                    AC_Mask[2, (int)goodEar] = 90;
                    // 2000
                    AC_Thresh[3, (int)goodEar] = 90;
                    AC_Thresh[3, (int)badEar] = 30;
                    BC_Thresh[3, (int)goodEar] = 30;
                    BC_Thresh[3, (int)badEar] = 25;
                    BC_Mask[3, (int)Ear.left] = 90;
                    AC_Mask[3, (int)Ear.left] = 90;
                    // 4000
                    AC_Thresh[4, (int)goodEar] = 95;
                    AC_Thresh[4, (int)badEar] = 30;
                    BC_Thresh[4, (int)goodEar] = 30;
                    BC_Thresh[4, (int)badEar] = 25;
                    BC_Mask[4, (int)goodEar] = 95;
                    AC_Mask[4, (int)goodEar] = 95;
                    // 8000
                    AC_Thresh[5, (int)goodEar] = 105;
                    AC_Thresh[5, (int)badEar] = 50;
                    //BC_Thresh[5, (int) goodEar] = ??;
                    BC_Thresh[5, (int)badEar] = 0;
                    AC_Mask[0, (int)goodEar] = 70;
                    break;
                #endregion
                #region Acoustic_Tumor (Completed)
                case (int)Pathology_Cases.Acoustic_Tumor:
                    {
                    
                         // Matt Hunold 
                        // 9/27/2011 hjkl
                        
                        //int randMin, randMax, minBC = 25, maxAC = -10;

                        // Bad ear pre-randomized prior to switch block
                        badEar = (Ear)rand_badEar;
                        goodEar = (Ear)Math.Abs(rand_badEar - 1);

                        // Assign normal hearing values to appropriate array locations
                        // and determine the maximum AC and minimum BC values for the bad ear
                        // this disease has normal hearing up to and including 1k

                        for (int i = 0; i < 6; i++) // good ear
                        {
                            AC_Thresh[i, (int)goodEar] = normHearing[i, 1, 0];
                            BC_Thresh[i, (int)goodEar] = normHearing[i, 0, 0];
                            // good ear is ear 0
                            // bad ear is ear 1
                            AC_Thresh[i, (int)badEar] = normHearing[i, 1, 1];
                            BC_Thresh[i, (int)badEar] = normHearing[i, 0, 1];

                        }
                        
                        for (int i = 3; i < 6; i++)
                        {
                            AC_Thresh[i, (int)badEar] = AC_Thresh[i - 1, (int)badEar] + rand.Next(3, 5) * 5;
                            BC_Mask[i, (int)badEar] = (AC_Thresh[i, (int)badEar]) - (rand.Next(0, 2)  * ((AC_Thresh[i, (int)badEar] - BC_Thresh[i, (int)badEar]) >= 15 ? 5 : 0));
                            AC_Mask[i, (int)badEar] = (AC_Thresh[i, (int)badEar]);
                        
                        }

                    /*
                    if (rand_badEar == 0)
                    {
                        goodEar = Ear.left;
                        badEar = Ear.right;
                    }
                    else
                    {
                        goodEar = Ear.right;
                        badEar = Ear.left;
                    }
                    // 250
                    AC_Thresh[0, (int)goodEar] = 15;
                    AC_Thresh[0, (int)badEar] = 5;
                    BC_Thresh[0, (int)goodEar] = 10;
                    BC_Thresh[0, (int)badEar] = 10;
                    // 500
                    AC_Thresh[1, (int)goodEar] = 15;
                    AC_Thresh[1, (int)badEar] = 10;
                    BC_Thresh[1, (int)goodEar] = 15;
                    BC_Thresh[1, (int)badEar] = 10;
                    // 1000
                    AC_Thresh[2, (int)goodEar] = 20;
                    AC_Thresh[2, (int)badEar] = 10;
                    BC_Thresh[2, (int)goodEar] = 20;
                    BC_Thresh[2, (int)badEar] = 10;
                    // 2000
                    AC_Thresh[3, (int)goodEar] = 25;
                    AC_Thresh[3, (int)badEar] = 15;
                    BC_Thresh[3, (int)goodEar] = 20;
                    BC_Thresh[3, (int)badEar] = 15;
                    // 4000
                    AC_Thresh[4, (int)goodEar] = 50;
                    AC_Thresh[4, (int)badEar] = 15;
                    BC_Thresh[4, (int)goodEar] = 15;
                    BC_Thresh[4, (int)badEar] = 15;
                    BC_Mask[4, (int)goodEar] = 50;
                    BC_Mask[4, (int)badEar] = 15;
                    // 8000
                    AC_Thresh[5, (int)goodEar] = 60;
                    AC_Thresh[5, (int)badEar] = 15;
                    //BC_Thresh[5, (int) goodEar] = ??;
                    //BC_Thresh[5, (int) badEar] = ??;
                    */
                    }
                    break;
                #endregion
                #region Progressive_Loss(Not Done)
                case (int)Pathology_Cases.Progressive_Loss:
                    goodEar = Ear.neither;
                    badEar = Ear.both;
                    // 250
                    AC_Thresh[0, (int)Ear.left] = 10;
                    AC_Thresh[0, (int)Ear.right] = 5;
                    BC_Thresh[0, (int)Ear.left] = 5;
                    BC_Thresh[0, (int)Ear.right] = 5;
                    // 500
                    AC_Thresh[1, (int)Ear.left] = 10;
                    AC_Thresh[1, (int)Ear.right] = 10;
                    BC_Thresh[1, (int)Ear.left] = 5;
                    BC_Thresh[1, (int)Ear.right] = 10;
                    // 1000
                    AC_Thresh[2, (int)Ear.left] = 20;
                    AC_Thresh[2, (int)Ear.right] = 20;
                    BC_Thresh[2, (int)Ear.left] = 20;
                    BC_Thresh[2, (int)Ear.right] = 20;
                    // 2000
                    AC_Thresh[3, (int)Ear.left] = 40;
                    AC_Thresh[3, (int)Ear.right] = 35;
                    BC_Thresh[3, (int)Ear.left] = 40;
                    BC_Thresh[3, (int)Ear.right] = 35;
                    // 4000
                    AC_Thresh[4, (int)Ear.left] = 60;
                    AC_Thresh[4, (int)Ear.right] = 65;
                    // Set the BC_Masked value to the threshold value to prevent
                    // the program from expecting air masking
                    BC_Thresh[4, (int)Ear.left] = BC_Mask[4, (int)Ear.left] = 65;
                    BC_Thresh[4, (int)Ear.right] = BC_Mask[4, (int)Ear.right] = 65;
                    // 8000
                    AC_Thresh[5, (int)Ear.left] = 80;
                    AC_Thresh[5, (int)Ear.right] = 75;
                    //BC_Thresh[5, (int)Ear.left] = ??;
                    //BC_Thresh[5, (int)Ear.right] = ??;
                    break;
                #endregion
                #region Ossicular_Discontinuity (Completed)
                case (int)Pathology_Cases.Ossicular_Discontinuity:
                    {
                        // Matt Hunold 
                        // 9/27/2011 hjkl
                       
                        //int randMin, randMax, minBC = 25, maxAC = -10;

                        // Bad ear pre-randomized prior to switch block
                        badEar = (Ear)rand_badEar;
                        goodEar = (Ear)Math.Abs(rand_badEar - 1);

                        // Assign normal hearing values to appropriate array locations
                        // and determine the maximum AC and minimum BC values for the bad ear
                        // this disease has normal hearing up to and including 1k

                        for (int i = 0; i < 6; i++) // good ear
                        {
                            AC_Thresh[i, (int)goodEar] = normHearing[i, 1, 0];
                            BC_Thresh[i, (int)goodEar] = normHearing[i, 0, 0];
                            // good ear is ear 0
                            // bad ear is ear 1
                            AC_Thresh[i, (int)badEar] = normHearing[i, 1, 1];
                            BC_Thresh[i, (int)badEar] = normHearing[i, 0, 1];

                            BC_Mask[i, (int)badEar] = BC_Thresh[i, (int)badEar];
                            //* ((AC_Thresh[i, (int)badEar] - 40 >= BC_Thresh[i, (int)goodEar] ? 5 : 0));
                            //BC_Mask[i, (int)badEar] = (AC_Thresh[i, (int)badEar]) - (rand.Next(0, 2) * ((AC_Thresh[i, (int)badEar] - BC_Thresh[i, (int)badEar]) >= 15 ? 5 : 0));

                        }

                        int[] AC_min = new int [6];

                        for (int i = 0; i < 6; i++)
                        {
                            AC_min[i] = Math.Max(30, BC_Thresh[i, (int)badEar] + 15);
                            AC_Thresh[i, (int)badEar] = AC_min[i] + rand.Next(0, (60 - AC_min[i] + 1));
                            AC_Mask[i, (int)badEar] = (AC_Thresh[i, (int)badEar]);
                        }


                        /*
                        if (rand_badEar == 0)
                        {
                            goodEar = Ear.left;
                            badEar = Ear.right;
                        }
                        else
                        {
                            goodEar = Ear.right;
                            badEar = Ear.left;
                        }
                        // 250
                        AC_Thresh[0, (int)goodEar] = 50;
                        AC_Thresh[0, (int)badEar] = 0;
                        BC_Thresh[0, (int)goodEar] = 0;
                        BC_Thresh[0, (int)badEar] = 0;
                        // 500
                        AC_Thresh[1, (int)goodEar] = 50;
                        AC_Thresh[1, (int)badEar] = 0;
                        BC_Thresh[1, (int)goodEar] = 0;
                        BC_Thresh[1, (int)badEar] = 0;
                        // 1000
                        AC_Thresh[2, (int)goodEar] = 50;
                        AC_Thresh[2, (int)badEar] = 5;
                        BC_Thresh[2, (int)goodEar] = 5;
                        BC_Thresh[2, (int)badEar] = 5;
                        BC_Mask[2, (int)goodEar] = 5;
                        // 2000
                        AC_Thresh[3, (int)goodEar] = 40;
                        AC_Thresh[3, (int)badEar] = 5;
                        BC_Thresh[3, (int)goodEar] = 5;
                        BC_Thresh[3, (int)badEar] = 5;
                        BC_Mask[3, (int)goodEar] = 5;
                        // 4000
                        AC_Thresh[4, (int)goodEar] = 40;
                        AC_Thresh[4, (int)badEar] = 5;
                        BC_Thresh[4, (int)goodEar] = 5;
                        BC_Thresh[4, (int)badEar] = 5;
                        BC_Mask[4, (int)goodEar] = 5;
                        // 8000
                        AC_Thresh[5, (int)goodEar] = 40;
                        AC_Thresh[5, (int)badEar] = 0;
                        //BC_Thresh[5, (int) goodEar] = ??;
                        BC_Thresh[5, (int)badEar] = 5;
                        */
                    }
                    break;
                #endregion
                #region Unilateral_Otitis_Media (flat loss) (Not Done)
                case (int)Pathology_Cases.Unilateral_Otitis_Media:
                    // Matt Hunold 
                    // 2/28/2012 hjkl

                    //int randMin, randMax, minBC = 25, maxAC = -10;

                    // Bad ear pre-randomized prior to switch block
                    badEar = (Ear)rand_badEar;
                    goodEar = (Ear)Math.Abs(rand_badEar - 1);

                    // Assign normal hearing values to appropriate array locations
                    // and determine the maximum AC and minimum BC values for the bad ear
                   
                    for (int i = 0; i < 6; i++) // good ear
                    {
                        AC_Thresh[i, (int)goodEar] = normHearing[i, 1, 0];
                        BC_Thresh[i, (int)goodEar] = normHearing[i, 0, 0];
                        // good ear is ear 0
                        // bad ear is ear 1
                        BC_Thresh[i, (int)badEar] = normHearing[i, 0, 1];

                    }

                    for (int i = 0; i < 6; i++)
                    {
                        AC_Thresh[i, (int)badEar] = BC_Thresh[i, (int)badEar] + 15;
                    }
                    /*// 250
                    AC_Thresh[0, (int)goodEar] = 10;
                    AC_Thresh[0, (int)badEar] = 40;
                    BC_Thresh[0, (int)goodEar] = 10;
                    BC_Thresh[0, (int)badEar] = 10;
                    BC_Mask[0, (int)goodEar] = 10;
                    BC_Mask[0, (int)badEar] = 10;
                    // 500
                    AC_Thresh[1, (int)goodEar] = 15;
                    AC_Thresh[1, (int)badEar] = 40;
                    BC_Thresh[1, (int)goodEar] = 15;
                    BC_Thresh[1, (int)badEar] = 15;
                    BC_Mask[1, (int)goodEar] = 15;
                    BC_Mask[1, (int)badEar] = 15;
                    // 1000
                    AC_Thresh[2, (int)goodEar] = 15;
                    AC_Thresh[2, (int)badEar] = 15;
                    BC_Thresh[2, (int)goodEar] = 15;
                    BC_Thresh[2, (int)badEar] = 15;
                    // 2000
                    AC_Thresh[3, (int)goodEar] = 15;
                    AC_Thresh[3, (int)badEar] = 15;
                    BC_Thresh[3, (int)goodEar] = 15;
                    BC_Thresh[3, (int)badEar] = 15;
                    // 4000
                    AC_Thresh[4, (int)goodEar] = 15;
                    AC_Thresh[4, (int)badEar] = 15;
                    BC_Thresh[4, (int)goodEar] = 15;
                    BC_Thresh[4, (int)badEar] = 15;
                    // 8000
                    AC_Thresh[5, (int)goodEar] = 10;
                    AC_Thresh[5, (int)badEar] = 10;
                    //BC_Thresh[5, (int) goodEar] = ??;
                    BC_Thresh[5, (int)badEar] = 5; */
                    break;
                #endregion
                #region Presbyacusis (Completed)
                case (int)Pathology_Cases.Presbyacusis:
                    {
                        // Matt Harris
                        // 9/27/2011

                        // Bad ear pre-randomized prior to switch block
                        // For Presbyacusis, this is simply just for randomization purposes
                        // There is "true" good or bad ear in presbyacusis, they are both bad
                        badEar = (Ear)rand_badEar;
                        goodEar = (Ear)Math.Abs(rand_badEar - 1);

                        int[] BCDiffs, AC0Diffs, AC1Diffs;
                        int randMin, randMax, randFloor, randCeiling;
                        double a, b, c, y3, y4, divide;

                        BCDiffs = new int[4];
                        AC0Diffs = new int[4];
                        AC1Diffs = new int[4];

                        // Find the differences for 1000, 2000, 4000, 8000 Hz
                        for (int i = 2; i < 6; i++)
                        {
                            BCDiffs[i - 2] = normHearing[i, 0, 1] - normHearing[i, 0, 0];
                            AC0Diffs[i - 2] = normHearing[i, 1, 0] - normHearing[i, 0, 0];
                            AC1Diffs[i - 2] = normHearing[i, 1, 1] - normHearing[i, 0, 1];
                        }

                        // y_0 and y_1 are the original values (for bone and air, both ears)
                        for (int i = 0; i < 2; i++)
                        {
                            for (int j = 0; j < 2; j++)
                            {
                                BC_Thresh[i, j] = normHearing[i, 0, j];
                                AC_Thresh[i, j] = normHearing[i, 1, j];
                            }
                        }

                        // y_2 is the greater of y_1 and y_2 + 5 to 15 dB
                        BC_Thresh[2, 0] = Math.Max(BC_Thresh[0, 0], BC_Thresh[1, 0]) + rand.Next(1, 4) * 5;

                        // y_5 minimum is y_2 + 15 and maximum is 80 dB
                        randMin = Math.Max((BC_Thresh[2, 0] + 15) / 5, 9);
                        randMax = 16;
                        BC_Thresh[5, 0] = rand.Next(randMin, randMax + 1) * 5;

                        // Solve for the coefficients
                        a = 0.1 * BC_Thresh[0, 0] - BC_Thresh[2, 0] / 6 + BC_Thresh[5, 0] / 15;
                        b = BC_Thresh[2, 0] * 5 / 6 - 0.7 * BC_Thresh[0, 0] - BC_Thresh[5, 0] * 2 / 15;
                        c = BC_Thresh[0, 0];

                        // Compute y3 and y4 from coefficients
                        y3 = a * 9 + b * 3 + c;
                        y4 = a * 16 + b * 4 + c;

                        // Randomly round up or down for y3 and y4
                        divide = y3 / 5;
                        randFloor = rand.Next(0, 2);
                        randCeiling = Math.Abs(randFloor - 1);
                        BC_Thresh[3, 0] = (randFloor * (int)Math.Floor(divide) + randCeiling * (int)Math.Ceiling(divide)) * 5;

                        divide = y4 / 5;
                        randFloor = rand.Next(0, 2);
                        randCeiling = Math.Abs(randFloor - 1);
                        BC_Thresh[4, 0] = (randFloor * (int)Math.Floor(divide) + randCeiling * (int)Math.Ceiling(divide)) * 5;

                        // Adjust remaining AC and BC values using differences determined
                        for (int i = 2; i < 6; i++)
                        {
                            BC_Thresh[i, 1] = BC_Thresh[i, 0] + BCDiffs[i - 2];
                            AC_Thresh[i, 0] = BC_Thresh[i, 0] + AC0Diffs[i - 2];
                            AC_Thresh[i, 1] = BC_Thresh[i, 1] + AC1Diffs[i - 2];
                        }

                        /*if (rand_badEar == 0)
                    {
                        goodEar = Ear.left;
                        badEar = Ear.right;
                    }
                    else
                    {
                        goodEar = Ear.right;
                        badEar = Ear.left;
                    }
                    // 250
                    AC_Thresh[0, (int)goodEar] = 20;
                    AC_Thresh[0, (int)badEar] = 15;
                    BC_Thresh[0, (int)goodEar] = 20;
                    BC_Thresh[0, (int)badEar] = 15;
                    // 500
                    AC_Thresh[1, (int)goodEar] = 15;
                    AC_Thresh[1, (int)badEar] = 15;
                    BC_Thresh[1, (int)goodEar] = 15;
                    BC_Thresh[1, (int)badEar] = 15;
                    // 1000
                    AC_Thresh[2, (int)goodEar] = 25;
                    AC_Thresh[2, (int)badEar] = 20;
                    BC_Thresh[2, (int)goodEar] = 25;
                    BC_Thresh[2, (int)badEar] = 20;
                    // 2000
                    AC_Thresh[3, (int)goodEar] = 30;
                    AC_Thresh[3, (int)badEar] = 30;
                    BC_Thresh[3, (int)goodEar] = 30;
                    BC_Thresh[3, (int)badEar] = 30;
                    // 4000
                    AC_Thresh[4, (int)goodEar] = 45;
                    AC_Thresh[4, (int)badEar] = 45;
                    BC_Thresh[4, (int)goodEar] = 45;
                    BC_Thresh[4, (int)badEar] = 45;
                    // 8000
                    AC_Thresh[5, (int)goodEar] = 60;
                    AC_Thresh[5, (int)badEar] = 60;
                    BC_Thresh[5, (int)goodEar] = 60;
                    BC_Thresh[5, (int)badEar] = 60;
                     */
                    }
                    break;
                #endregion
                #region Noise_Induced_Trauma (Needs Editing)
                case (int)Pathology_Cases.Noise_Induced_Trauma :

                    // Matt Hunold 
                    // 2/28/2012 hjkl

                    //int randMin, randMax, minBC = 25, maxAC = -10;

                    // Bad ear pre-randomized prior to switch block
                    badEar = (Ear)rand_badEar;
                    goodEar = (Ear)Math.Abs(rand_badEar - 1);

                    // Assign normal hearing values to appropriate array locations
                    // and determine the maximum AC and minimum BC values for the bad ear

                    for (int i = 0; i < 6; i++) // good ear
                    {
                        AC_Thresh[i, (int)goodEar] = normHearing[i, 1, 0];
                        BC_Thresh[i, (int)goodEar] = normHearing[i, 0, 0];
                        // good ear is ear 0
                        // bad ear is ear 1
                        AC_Thresh[i, (int)badEar] = normHearing[i, 1, 1];
                        BC_Thresh[i, (int)badEar] = normHearing[i, 0, 1];
                    }

                    // 4000 Hz
                    AC_Thresh[4, (int)badEar] = AC_Thresh[3, (int)badEar] + rand.Next(30, 51);
                    AC_Thresh[4, (int)goodEar] = AC_Thresh[3, (int)goodEar] + rand.Next(20, 51);
                    BC_Thresh[4, (int)badEar] = AC_Thresh[4, (int)badEar] - rand.Next(0,10); // not (0,11) due to style choice: BC and AC are close together most often
                    BC_Thresh[4, (int)goodEar] = AC_Thresh[4, (int)goodEar] - rand.Next(0, 10);
                    // 8000 Hz
                    traumaDiff = AC_Thresh[4, (int)badEar] - AC_Thresh[4, (int)goodEar];
                    AC_Thresh[5, (int)badEar] = AC_Thresh[4, (int)badEar] + rand.Next(0, 11);
                    AC_Thresh[5, (int)goodEar] = AC_Thresh[5, (int)badEar] - traumaDiff;

                /* case (int)Pathology_Cases.Noise_Induced_Trauma:
                    if (rand_badEar == 0)
                    {
                        goodEar = Ear.left;
                        badEar = Ear.right;
                    }
                    else
                    {
                        goodEar = Ear.right;
                        badEar = Ear.left;
                    }
                    // 250
                    AC_Thresh[0, (int)goodEar] = 20;
                    AC_Thresh[0, (int)badEar] = 15;
                    BC_Thresh[0, (int)goodEar] = 15;
                    BC_Thresh[0, (int)badEar] = 10;
                    // 500
                    AC_Thresh[1, (int)goodEar] = 15;
                    AC_Thresh[1, (int)badEar] = 10;
                    BC_Thresh[1, (int)goodEar] = 15;
                    BC_Thresh[1, (int)badEar] = 10;
                    // 1000
                    AC_Thresh[2, (int)goodEar] = 10;
                    AC_Thresh[2, (int)badEar] = 10;
                    BC_Thresh[2, (int)goodEar] = 5;
                    BC_Thresh[2, (int)badEar] = 5;
                    // 2000
                    AC_Thresh[3, (int)goodEar] = 15;
                    AC_Thresh[3, (int)badEar] = 15;
                    BC_Thresh[3, (int)goodEar] = 15;
                    BC_Thresh[3, (int)badEar] = 10;
                    // 4000
                    AC_Thresh[4, (int)goodEar] = 50;
                    AC_Thresh[4, (int)badEar] = 75;
                    BC_Thresh[4, (int)goodEar] = 50;
                    BC_Thresh[4, (int)badEar] = 55;
                    BC_Mask[4, (int)badEar] = 75;
                    // 8000
                    AC_Thresh[5, (int)goodEar] = 45;
                    AC_Thresh[5, (int)badEar] = 60;
                    //BC_Thresh[5, (int) goodEar] = ??;
                    //BC_Thresh[5, (int) badEar] = 60;
                    break;*/
                    break;
                #endregion
                #region Bilateral_Otitis_Media (flat loss) (Needs Editing)
                case (int)Pathology_Cases.Bilateral_Otitis_Media:
                    // Matt Hunold 
                    // 2/28/2012 hjkl

                    //int randMin, randMax, minBC = 25, maxAC = -10;

                    // Bad ear pre-randomized prior to switch block
                    badEar = (Ear)rand_badEar;
                    goodEar = (Ear)Math.Abs(rand_badEar - 1);

                    // Assign normal hearing values to appropriate array locations
                    // and determine the maximum AC and minimum BC values for the bad ear

                    for (int i = 0; i < 6; i++) // good ear
                    {
                        BC_Thresh[i, (int)goodEar] = normHearing[i, 0, 0];
                        // good ear is ear 0
                        // bad ear is ear 1
                        BC_Thresh[i, (int)badEar] = normHearing[i, 0, 1];

                    }

                    for (int i = 0; i < 6; i++)
                    {
                        AC_Thresh[i, (int)badEar] = BC_Thresh[i, (int)badEar] + 15;
                        AC_Thresh[i, (int)goodEar] = BC_Thresh[i, (int)goodEar] + 15;
                    }
                    break;
                #endregion
                #region Bilateral_Otosclerosis (Completed)
                case (int)Pathology_Cases.Bilateral_Otosclerosis:

                    // James Golike
                    // 2/06/2012 

                    // Bad ear pre-randomized prior to switch block
                    badEar = (Ear)rand_badEar;
                    goodEar = (Ear)Math.Abs(rand_badEar - 1);

                    // normal hearing
                    for (int i = 0; i < 6; i++) // good ear
                    {
                        AC_Thresh[i, (int)goodEar] = normHearing[i, 1, 0];
                        BC_Thresh[i, (int)goodEar] = normHearing[i, 0, 0];
                        // good ear is ear 0
                        // bad ear is ear 1
                        AC_Thresh[i, (int)badEar] = normHearing[i, 1, 1];
                        BC_Thresh[i, (int)badEar] = normHearing[i, 0, 1];

                    }

                    for (int i = 3; i < 6; i++)
                    {
                        BC_Thresh[i, (int)badEar] = rand.Next(25, 66);
                        BC_Thresh[i, (int)goodEar] = BC_Thresh[i, (int)badEar] - rand.Next(0, 10);
                    }

                
                /* // 250
                    AC_Thresh[0, (int)Ear.left] = 55;
                    AC_Thresh[0, (int)Ear.right] = 50;
                    BC_Thresh[0, (int)Ear.left] = 0;
                    BC_Thresh[0, (int)Ear.right] = 0;
                    BC_Mask[0, (int)Ear.left] = 10;
                    BC_Mask[0, (int)Ear.right] = 10;
                    // 500
                    AC_Thresh[1, (int)Ear.left] = 60;
                    AC_Thresh[1, (int)Ear.right] = 60;
                    BC_Thresh[1, (int)Ear.left] = 5;
                    BC_Thresh[1, (int)Ear.right] = 5;
                    BC_Mask[1, (int)Ear.left] = 15;
                    BC_Mask[1, (int)Ear.right] = 15;
                    // 1000
                    AC_Thresh[2, (int)Ear.left] = 55;
                    AC_Thresh[2, (int)Ear.right] = 55;
                    BC_Thresh[2, (int)Ear.left] = 10;
                    BC_Thresh[2, (int)Ear.right] = 10;
                    BC_Mask[2, (int)Ear.left] = 15;
                    BC_Mask[2, (int)Ear.right] = 15;
                    // 2000
                    AC_Thresh[3, (int)Ear.left] = 50;
                    AC_Thresh[3, (int)Ear.right] = 45;
                    BC_Thresh[3, (int)Ear.left] = 20;
                    BC_Thresh[3, (int)Ear.right] = 20;
                    BC_Mask[3, (int)Ear.left] = 20;
                    BC_Mask[3, (int)Ear.right] = 20;
                    // 4000
                    AC_Thresh[4, (int)Ear.left] = 30;
                    AC_Thresh[4, (int)Ear.right] = 30;
                    BC_Thresh[4, (int)Ear.left] = 5;
                    BC_Thresh[4, (int)Ear.right] = 5;
                    BC_Mask[4, (int)Ear.left] = 10;
                    BC_Mask[4, (int)Ear.right] = 10;
                    // 8000
                    AC_Thresh[5, (int)Ear.left] = 50;
                    AC_Thresh[5, (int)Ear.right] = 50;
                    //BC_Thresh[5, (int)Ear.left] = ??;
                    //BC_Thresh[5, (int)Ear.right] = 60; */
                    break;
                #endregion
                #region Menieres_Disease (Completed)
                case (int)Pathology_Cases.Menieres_Disease:
                    {
                        // Matt Harris 
                        // 9/26/2007
                        int MenieresDiseaseOffset;
                        int randMin, randMax, maxACOffset = 85, maxOffsetTest, minBC = 25, maxAC = -10;

                        // Bad ear pre-randomized prior to switch block
                        badEar = (Ear)rand_badEar;
                        goodEar = (Ear)Math.Abs(rand_badEar - 1);

                        // Assign normal hearing values to appropriate array locations
                        // and determine the maximum AC and minimum BC values for the bad ear
                        for (int i = 0; i < 6; i++)
                        {
                            AC_Thresh[i, (int)goodEar] = normHearing[i, 1, 0];
                            BC_Thresh[i, (int)goodEar] = normHearing[i, 0, 0];

                            AC_Thresh[i, (int)badEar] = normHearing[i, 1, 1];
                            BC_Thresh[i, (int)badEar] = normHearing[i, 0, 1];

                            maxOffsetTest = BC_Thresh[i, (int)goodEar] + 55 - AC_Thresh[i, (int)badEar];
                            if (maxOffsetTest < maxACOffset)
                                maxACOffset = maxOffsetTest;

                            if (BC_Thresh[i, (int)badEar] < minBC)
                                minBC = BC_Thresh[i, (int)badEar];

                        }

                        // Determine the randomization range
                        randMin = (30 - minBC) / 5;
                        randMax = maxACOffset / 5;

                        // Randomize the offset range and offset the bad ear
                        MenieresDiseaseOffset = rand.Next(randMin, randMax + 1) * 5;
                        for (int i = 0; i < 6; i++)
                        {
                            AC_Thresh[i, (int)badEar] += MenieresDiseaseOffset;
                            BC_Mask[i, (int)badEar] = BC_Thresh[i, (int)badEar] + MenieresDiseaseOffset;
                        }
                        /*
                        // 250
                        AC_Thresh[0, (int)goodEar] = 50;
                        AC_Thresh[0, (int)badEar] = 5;
                        BC_Thresh[0, (int)goodEar] = 5;
                        BC_Thresh[0, (int)badEar] = 5;
                        BC_Mask[0, (int)Ear.left] = 50;
                        // 500
                        AC_Thresh[1, (int)goodEar] = 45;
                        AC_Thresh[1, (int)badEar] = 0;
                        BC_Thresh[1, (int)goodEar] = 0;
                        BC_Thresh[1, (int)badEar] = 0;
                        BC_Mask[1, (int)Ear.left] = 45;
                        // 1000
                        AC_Thresh[2, (int)goodEar] = 40;
                        AC_Thresh[2, (int)badEar] = 5;
                        BC_Thresh[2, (int)goodEar] = 5;
                        BC_Thresh[2, (int)badEar] = 5;
                        BC_Mask[2, (int)Ear.left] = 40;
                        // 2000
                        AC_Thresh[3, (int)goodEar] = 35;
                        AC_Thresh[3, (int)badEar] = 10;
                        BC_Thresh[3, (int)goodEar] = 10;
                        BC_Thresh[3, (int)badEar] = 10;
                        BC_Mask[3, (int)goodEar] = 35;
                        // 4000
                        AC_Thresh[4, (int)goodEar] = 40;
                        AC_Thresh[4, (int)badEar] = 5;
                        BC_Thresh[4, (int)goodEar] = 5;
                        BC_Thresh[4, (int)badEar] = 5;
                        BC_Mask[4, (int)goodEar] = 40;
                        // 8000
                        AC_Thresh[5, (int)goodEar] = 45;
                        AC_Thresh[5, (int)badEar] = 10;
                        //BC_Thresh[5, (int) goodEar] = ??;
                        //BC_Thresh[5, (int) badEar] = 60;
                         */
                    }
                    break;
                #endregion
                #region Microtia (Completed)
                case (int)Pathology_Cases.Microtia:
                    {

                        // Matt Hunold 
                        // 9/27/2011 hjkl

                        int randMin, randMax, minBC = 25, maxAC = -10;

                        // Bad ear pre-randomized prior to switch block
                        badEar = (Ear)rand_badEar;
                        goodEar = (Ear)Math.Abs(rand_badEar - 1);

                        // Assign normal hearing values to appropriate array locations
                        // and determine the maximum AC and minimum BC values for the bad ear MOAR STUFF
                        // this disease has normal hearing up to and including 1k

                        for (int i = 0; i < 6; i++) // good ear
                        {
                            AC_Thresh[i, (int)goodEar] = normHearing[i, 1, 0];
                            BC_Thresh[i, (int)goodEar] = normHearing[i, 0, 0];
                            // good ear is ear 0
                            // bad ear is ear 1
                            AC_Thresh[i, (int)badEar] = normHearing[i, 1, 1];
                            BC_Thresh[i, (int)badEar] = normHearing[i, 0, 1];

                            BC_Mask[i, (int)badEar] = BC_Thresh[i, (int)badEar];
                            //* ((AC_Thresh[i, (int)badEar] - 40 >= BC_Thresh[i, (int)goodEar] ? 5 : 0));
                            //BC_Mask[i, (int)badEar] = (AC_Thresh[i, (int)badEar]) - (rand.Next(0, 2) * ((AC_Thresh[i, (int)badEar] - BC_Thresh[i, (int)badEar]) >= 15 ? 5 : 0));

                        }

                        int[] AC_min = new int[6];

                        for (int i = 0; i < 6; i++)
                        {
                            AC_min[i] = Math.Max(30, BC_Thresh[i, (int)badEar] + 15);
                            AC_Thresh[i, (int)badEar] = AC_min[i] + rand.Next(0, (60 - AC_min[i] + 1));
                            if ((AC_Thresh[i, (int)badEar]) > 60)
                            {
                                AC_Thresh[i, (int)badEar] = 60;
                            }
                            AC_Mask[i, (int)badEar] = (AC_Thresh[i, (int)badEar]);
                        }

                    /*
                    if (rand_badEar == 0)
                    {
                        goodEar = Ear.left;
                        badEar = Ear.right;
                    }
                    else
                    {
                        goodEar = Ear.right;
                        badEar = Ear.left;
                    }
                    // 250
                    AC_Thresh[0, (int)goodEar] = 65;
                    AC_Thresh[0, (int)badEar] = 5;
                    AC_Mask[0, (int)goodEar] = 65;
                    BC_Thresh[0, (int)goodEar] = 10;
                    BC_Thresh[0, (int)badEar] = 5;
                    BC_Mask[0, (int)goodEar] = 10;
                    // 500
                    AC_Thresh[1, (int)goodEar] = 60;
                    AC_Thresh[1, (int)badEar] = 0;
                    AC_Mask[1, (int)goodEar] = 60;
                    BC_Thresh[1, (int)goodEar] = 5;
                    BC_Thresh[1, (int)badEar] = 0;
                    BC_Mask[1, (int)goodEar] = 5;
                    // 1000
                    AC_Thresh[2, (int)goodEar] = 60;
                    AC_Thresh[2, (int)badEar] = 0;
                    AC_Mask[2, (int)goodEar] = 60;
                    BC_Thresh[2, (int)goodEar] = 5;
                    BC_Thresh[2, (int)badEar] = 0;
                    BC_Mask[2, (int)goodEar] = 5;
                    // 2000
                    AC_Thresh[3, (int)goodEar] = 55;
                    AC_Thresh[3, (int)badEar] = 0;
                    BC_Thresh[3, (int)goodEar] = 5;
                    BC_Thresh[3, (int)badEar] = 0;
                    BC_Mask[3, (int)goodEar] = 5;
                    // 4000
                    AC_Thresh[4, (int)goodEar] = 55;
                    AC_Thresh[4, (int)badEar] = 5;
                    BC_Thresh[4, (int)goodEar] = 5;
                    BC_Thresh[4, (int)badEar] = 5;
                    BC_Mask[4, (int)goodEar] = 5;
                    // 8000
                    AC_Thresh[5, (int)goodEar] = 65;
                    AC_Thresh[5, (int)badEar] = 10;
                    //BC_Thresh[5, (int) goodEar] = ??;
                    //BC_Thresh[5, (int) badEar] = 60;*/
                    break;
                   }
                #endregion
            }


                //TestNIT(AC_Thresh[5, 0], AC_Thresh[5, 1]);
                //normHearingNew = RandomNormalHearingNew();
                //TestNormalHearing(normHearing);
                //TestNormalHearing(normHearingNew);
            //}
            
            #region Word Intelligibility and Speach Recognition Test (Needs Implementation)
            //Who made this and when was it made. Is it still relevant? -AW 10/26/11
            
            /*
			// Make WI_Value a multiple of 4 because of the score being out of 25
			WI_Value[0] /= 4;
			WI_Value[1] /= 4;
			WI_Value[0] *= 4;
			WI_Value[1] *= 4;

			// bad ear is both for bilateral
			if (pathCase >= (int)Pathology_Cases.Bilateral_Otitis_Media)
				badEar = (int)Ear.both;

			// check to ensure that AC >= BC
			for (int i = 0; i < 6; i++) 
			{
				for (int j = 0; j < 2; j++) 
				{
					if (AC_Thresh[i,j] < BC_Thresh[i,j]) BC_Thresh[i,j] = AC_Thresh[i,j];
				}
			}

			// Assign SRT Threshold and WI Level
			SRT_Thresh = new int[2];
			SRT_Thresh[0] = (AC_Thresh_Val(500, (int)Ear.left) + AC_Thresh_Val(1000, (int)Ear.left) + AC_Thresh_Val(2000, (int)Ear.left))/3;
			SRT_Thresh[1] = (AC_Thresh_Val(500, (int)Ear.right) + AC_Thresh_Val(1000, (int)Ear.right) + AC_Thresh_Val(2000, (int)Ear.right))/3;
			if(SRT_Thresh[0] % 5 < 3) SRT_Thresh[0] = 5*(SRT_Thresh[0] / 5);
			else SRT_Thresh[0] = 5*(SRT_Thresh[0] / 5 + 1);
			if(SRT_Thresh[1] % 5 < 3) SRT_Thresh[1] = 5*(SRT_Thresh[1] / 5);
			else SRT_Thresh[1] = 5*(SRT_Thresh[1] / 5 + 1);
			WI_Level = new int[2];
			WI_Level[0] = SRT_Thresh[0] + 30;
			WI_Level[1] = SRT_Thresh[1] + 30;

			//Temp
			SRT_Masking = new int[2];
			WI_Masking = new int[2];
			SRT_Masking[0] = 0;
			SRT_Masking[1] = 0;
			WI_Masking[0] = 0;
			WI_Masking[1] = 0;
			// End Temp*/
            #endregion
        }
		
		/// <summary>
		/// This function assigns the case history string
		/// </summary>
		/// <param name="pathCase">Which Pathology to use</param>
		private void AssignCaseHistory(int pathCase)
		{
			Random rand = new Random();
			// need name, age and gender info
			string worseEar, betterEar, when, worse, nature, infections, family, noises, dizziness, loud_noise;

			// defaults
			when = ";";
			worse = ";";
			nature = ";";
			infections = ";;";
			family = ";;";
			noises = ";;;;";
			dizziness = ";;;";
			loud_noise = ";;";

			switch (badEar)
			{
				case Ear.left:
					worseEar = "Left;";
					betterEar = "Right;";
					break;
				case Ear.right:
					worseEar = "Right;";
					betterEar = "Left;";
					break;
				default:
					worseEar = "Both;";
					betterEar = "Same;";
					break;
			}

				#region Big_Long_Switch_Statement
			switch (pathCase) 
			{
				case (int)Pathology_Cases.Unilateral_Otitis_Media:
					int wks = rand.Next(1,4);
					when = wks.ToString() + ((wks > 1) ? " weeks ago;" : " week ago;");
					worse = "No;";
					nature = "Fluctuating;";
					infections = "Yes;"+worseEar;
					family = "No;;";
					noises = "No;;;;";
					dizziness = "No;;;";
					loud_noise = "No;;";
					break;
				case (int)Pathology_Cases.Unilateral_Otosclerosis:
					wks = rand.Next(1,4);
					when = "After giving birth;";
					worse = "Yes;";
					nature = "Gradual;";
					infections = "No;;";
					family = "Yes;Mother, grandmother, and aunts;";
					noises = "Yes;" + worseEar + "Frequently;Low-pitched roaring;";
					dizziness = "No;;;";
					loud_noise = "No;;";
					break;
				case (int)Pathology_Cases.Ossicular_Discontinuity:
					wks = rand.Next(1,4);
				switch (wks)
				{
					case 1:
						when = "After getting hit with a softball;";
						break;
					case 2:
						when = "After participating in a boxing match;";
						break;
					case 3:
						when = "After a receiving a concussion in a car accident;";
						break;
				}
					worse = "No;";
					nature = "Sudden Onset;";
					infections = "No;;";
					family = "No;;";
					noises = "No;;;;";
					dizziness = "Yes;No;No;";
					loud_noise = "No;;";
					break;
				case (int)Pathology_Cases.Acoustic_Tumor:
					when = "1-2 years ago;";
					worse = "Yes;";
					nature = "Gradual;";
					infections = "No;;";
					family = "No;;";
					noises = "Yes;" + worseEar + "Frequently;High-pitched ringing;";
					dizziness = "No;;;";
					loud_noise = "No;;";
					break;
				case (int)Pathology_Cases.Sudden_Onset:
					wks = rand.Next(4);
					when = wks.ToString() + ((wks > 1) ? " weeks ago;" : " week ago;");
					worse = "No;";
					nature = "Sudden;";
					infections = "No;;";
					family = "No;;";
					noises = "Yes;" + worseEar + "Often;Ringing;";
					dizziness = "No;;;";
					loud_noise = "No;;";
					break;
				case (int)Pathology_Cases.Progressive_Loss:		
					wks = rand.Next(2,6);
					when = wks.ToString() + " years ago;";
					worse = "Yes;";
					nature = "Gradual;";
					infections = "No;;";
					family = "Yes;Maternal Uncle had a gradual loss and received hearing aids in his 40's;";
					noises = "No;;;;";
					dizziness = "No;;;";
					loud_noise = "No;;";
					break;
				case (int)Pathology_Cases.Bilateral_Otitis_Media:
					wks = rand.Next(1,4);
					when = wks.ToString() + ((wks > 1) ? " weeks ago;" : " week ago;");
					worse = "Yes;";
					nature = "Fluctuating;";
					infections = "Yes;Both;";
					family = "No;;";
					noises = "No;;;;";
					dizziness = "No;;;";
					loud_noise = "No;;";
					break;
				case (int)Pathology_Cases.Bilateral_Otosclerosis:
					wks = rand.Next(1,4);
					when = "After giving birth;";
					worse = "Yes;";
					nature = "Gradual;";
					infections = "No;;";
					family = "Yes;Mother, grandmother, and aunts;";
					noises = "Yes;Both;Frequently;Low-pitched roaring;";
					dizziness = "No;;;";
					loud_noise = "No;;";
					break;
				case (int)Pathology_Cases.Microtia:
					when = "Present since birth;";
					worse = "No;";
					nature = "Present Since birth;";
					infections = "Yes;Both ears;";
					family = "No;;";
					noises = "No;;;;";
					dizziness = "No;;;";
					loud_noise = "No;;";
					break;
				case (int)Pathology_Cases.Menieres_Disease:					
					wks = rand.Next(2,7);
					when = wks.ToString() + " months ago;";
					worse = "Yes;";
					nature = "Flucuating;";
					infections = "No;;";
					family = "No;;";
					noises = "Yes;Both;Frequently;Roaring;";
					dizziness = "Yes;Yes;Yes;";
					loud_noise = "No;;";
					break;
				case (int)Pathology_Cases.Noise_Induced_Trauma:					
					wks = rand.Next(2,8);
					when = wks.ToString() + " years ago;";
					worse = "Yes;";
					nature = "Gradual;";
					infections = "No;;";
					family = "No;;";
					noises = "Yes;Both;Occasionally;High-pitched ringing;";
					dizziness = "No;;;";

					string exposed;
				switch (rand.Next(0,3))
				{
					case 0:
						exposed = "Target shooting and Hunting";
						break;
					case 1:
						exposed = "Huh? - Oh I play in a garage band";
						break;
					default:
						exposed = "Construction";
						break;
				}

					loud_noise = "Yes;" + exposed + ";";
					break;
				case (int)Pathology_Cases.Presbyacusis:
					wks = rand.Next(1,4);
					when = wks.ToString() + " years ago;";
					worse = "Yes;";
					nature = "Gradual;";
					infections = "No;;";
					family = "No;;";
					noises = "Yes;Both;Usually;High-pitched ringing;";
					dizziness = "No;;;";
					loud_noise = "No;;";
					break;
				default:
					break;
			}
			#endregion
			caseHistory = worseEar + betterEar + when + worse + nature + infections + 
				family + noises + dizziness + loud_noise;
		}


		/// <summary>
		/// This just returns the AC threshold requested
		/// </summary>
		/// <param name="frequency">frequency</param>
		/// <param name="ear"> what ear do you want</param>
		/// <returns>AC Threshold at specified frequency for specified ear</returns>
        public int AC_Mask_Val(int frequency, Ear ear)
        {
            if (ear != Ear.left && ear != Ear.right) return -200;

            int freqToPass;
            switch (frequency)
            {
                case 250:
                    freqToPass = 0;
                    break;
                case 500:
                    freqToPass = 1;
                    break;
                case 1000:
                    freqToPass = 2;
                    break;
                case 2000:
                    freqToPass = 3;
                    break;
                case 4000:
                    freqToPass = 4;
                    break;
                case 8000:
                    freqToPass = 5;
                    break;
                default:
                    return -200;
            }
            return AC_Mask[freqToPass, (int)ear];
        }
        public int BC_Mask_Val(int frequency, Ear ear)
        {
            if (ear != Ear.left && ear != Ear.right) return -200;

            int freqToPass;
            switch (frequency)
            {
                case 250:
                    freqToPass = 0;
                    break;
                case 500:
                    freqToPass = 1;
                    break;
                case 1000:
                    freqToPass = 2;
                    break;
                case 2000:
                    freqToPass = 3;
                    break;
                case 4000:
                    freqToPass = 4;
                    break;
                case 8000:
                    freqToPass = 5;
                    break;
                default:
                    return -200;
            }
            return BC_Mask[freqToPass, (int)ear];
        }
        public int AC_Thresh_Val (int frequency, Ear ear)
		{
			if (ear != Ear.left && ear != Ear.right) return -200;
			
			int freqToPass;
			switch (frequency) 
			{
				case 250:
					freqToPass = 0;
					break;
				case 500:
					freqToPass = 1;
					break;
				case 1000:
					freqToPass = 2;
					break;
				case 2000:
					freqToPass = 3;
					break;
				case 4000:
					freqToPass = 4;
					break;
				case 8000:
					freqToPass = 5;
					break;
				default:
					return -200;
			}
			return AC_Thresh[freqToPass,(int)ear];
		}
		/// <summary>
		/// This just returns the BC threshold requested
		/// </summary>
		/// <param name="frequency">frequency</param>
		/// <param name="ear"> what ear do you want</param>
		/// <returns>BC Threshold at specified frequency for specified ear</returns>
		public int BC_Thresh_Val (int frequency, Ear ear) 
		{
            if (ear != Ear.left && ear != Ear.right) return -200;

			int freqToPass;
			switch (frequency) 
			{
				case 250:
					freqToPass = 0;
					break;
				case 500:
					freqToPass = 1;
					break;
				case 1000:
					freqToPass = 2;
					break;
				case 2000:
					freqToPass = 3;
					break;
				case 4000:
					freqToPass = 4;
					break;
				case 8000:
					freqToPass = 5;
					break;
				default:
					return -200;
			}
			return BC_Thresh[freqToPass,(int)ear];
		}

		/// <summary>
		/// This function returns the SRT Threshold for the passed ear
		/// </summary>
		/// <param name="ear">Which Ear</param>
		/// <returns>The SRT Threshold Value in dB</returns>
		public int SRT_Thresh_Val(int ear)
		{
			if((ear == (int)Ear.left) || (ear == (int)Ear.right)) return SRT_Thresh[ear];
			else return -200;
		}

		/// <summary>
		/// This just returns the pathology type
		/// </summary>
		/// <returns>Pathology Type</returns>
		public string PathType
		{
			get 
			{
				return pathType;
			}
		}

		/// <summary>
		/// This just returns the bad ear
		/// </summary>
		/// <returns>The Bad Ear</returns>
		public Ear BadEar
		{
			get
			{
				return badEar;
			}
		}

		/// <summary>
		/// This returns the case history info
		/// </summary>
		/// <returns>string - ; delimited</returns>
		public string CaseHist
		{
			get 
			{
				return caseHistory;
			}
		}
		
        public String patType
        {
            get
            {

                return patientType;
            }
        }

		/// <summary>
		/// Creates the string name from the pathology case constants
		/// </summary>
		/// <param name="pathCase">Which Pathology to use</param>
		/// <returns>Returns String description of integer pathCase</returns>
		private string MakePathType(int pathCase) 
		{
			switch (pathCase) 
			{
				case (int)Pathology_Cases.Acoustic_Tumor:
					return "Acoustic Tumor";
				case (int)Pathology_Cases.Bilateral_Otitis_Media:
					return "Bilateral Otitis Media";
				case (int)Pathology_Cases.Bilateral_Otosclerosis:
					return "Bilateral Otosclerosis";
				case (int)Pathology_Cases.Menieres_Disease:
					return "Meniere's Disease";
				case (int)Pathology_Cases.Microtia:
					return "Microtia";
				case (int)Pathology_Cases.Noise_Induced_Trauma:
					return "Noise Induced Trauma";
				case (int)Pathology_Cases.Ossicular_Discontinuity:
					return "Ossicular Discontinuity";
				case (int)Pathology_Cases.Presbyacusis:
					return "Presbyacusis";
				case (int)Pathology_Cases.Progressive_Loss:
					return "Progressive Loss";
				case (int)Pathology_Cases.Sudden_Onset:
					return "Sudden Onset";
				case (int)Pathology_Cases.Unilateral_Otitis_Media:
					return "Unilateral Otitis Media";
				case (int)Pathology_Cases.Unilateral_Otosclerosis:
					return "Unilateral Otosclerosis";
				default:
					return "Unknown";
			}
		}

		/// <summary>
		/// Returns the appropriate WI value for the patient
		/// </summary>
		/// <param name="ear">Which ear to get the value of</param>
		/// <returns>WI value</returns>
		public int GetWI(int ear)
		{
			if(ear == 0 || ear == 1) return WI_Value[ear];
			else return 0;
		}

		/// <summary>
		/// Returns the WI level of the ear
		/// </summary>
		/// <param name="ear">Which ear to get the value of</param>
		/// <returns>WI Presentation level</returns>
		public int GetWILevel(int ear)
		{
			if(ear == 0 || ear == 1) return WI_Level[ear];
			else return 0;
		}

		/// <summary>
		/// Obtains the minimum value of the BC Thresholds for the given ear
		/// </summary>
		/// <param name="ear">which ear is being tested</param>
		/// <returns>miminum BC Threshold value</returns>
		public int GetMinimumBC(Ear ear)
		{
			int min = int.MaxValue;
			for(int i = 250; i < 8000; i*=2)
			{
				int val = BC_Thresh_Val(i, ear);
				if(val < min) min = val;
			}
			return min;
		}

        public int[, ,] RandomNormalHearing()
        {
            #region Function Info
            // Generates a normal hearing pathology from which all other pathologies may be derived
            // Returns: 3D int Array containing air and bone conduction values for a single ear
            //  First index is the frequency index, 
            //  Second index is 0 for Bone, 1 for Air.
            //  Third index is for an ear (0 for an ear, 1 for the opposite ear)

            // This algorithm is based on the following rules:
            // BC for one ear is within +- 5 dB of BC for the other ear (IA approximately 0)
            // BC between neighboring frequencies for the same ear must be within 10 dB
            // Difference between AC and BC of the same ear must be within 10 dB
            // BC must not exceed AC for the same ear
            // AC between neihboring frequencies must be within 10 dB
            // AC between left and right for the same frequency must be within 10 dB
            #endregion

            // Matt Harris
            // 09/17/2011
            // See documentation for thought process

            int[, ,] result = new int[6, 2, 2];
            Random Rand = new Random();     // Random number generator
            int randMin = 0, randMax = 3;   // Minimum and Maximum random values
            int whichMax;                  // The maximum value to base the value of AC for Ear 1

            int diffACcurBCprev = 0;        // Difference between the AC of the current frequency
            // and the BC of the previous frequency (BCprev - ACcur)
            int diffBC1prevBC0cur = 0;      // Difference between the BC for ear 1 of the previous frequency
            // and BC for ear 0 of the current frequency (BC0cur - BC1prev)
            int diffBCcurACprev = 0;        // Difference between the BC for the current frequency
            // and the AC for the previous frequency (ACprev - BCcur)

            // All values will be multiplied by 5 at the end to scale each random value to a multiple of 5
            // minValue argument on Random.Next is inclusive
            // maxValue argument on Random.Next is exclusive
            // Review the Ternary Operator to understand ? : operations

            result[0, 1, 0] = Rand.Next(-2, 5);// Randomize air conduction at 250 Hz between -10 and 25 for Ear 0
            randMin = result[0, 1, 0] - 2;     // BC value within 10 dB of AC value

            result[0, 0, 0] = Rand.Next(randMin < -2 ? -2 : randMin, result[0, 1, 0] + 1); //Randomize the bone conduction value for Ear 0

            // Based off the ear 0 bone conduction value @ 250 Hz, determine the bone conduction value for ear 1 @ 250 Hz
            randMin = result[0, 0, 0] - 1;
            randMax = result[0, 0, 0] + 1;
            result[0, 0, 1] = Rand.Next(randMin < -2 ? -2 : randMin, randMax > 4 ? 5 : randMax + 1);

            // Now the air conduction value for ear 1 @ 250 Hz can be determined
            randMin = result[0, 0, 1];
            whichMax = result[0, 1, 0] < result[0, 0, 1] ? result[0, 1, 0] : result[0, 0, 1];
            randMax = whichMax + 2;
            result[0, 1, 1] = Rand.Next(randMin, randMax > 4 ? 5 : randMax + 1);

            // Randomize all other values for the ear
            for (int i = 0; i <= 4; i++)
            {
                randMin = result[i, 1, 0] - 2; // Air conduction between two neighboring frequencies must be within
                randMax = result[i, 1, 0] + 2; // 10 dB of each other

                // Range is between -10 dB and 25 dB (-2 and 5), randomize next frequencies AC value for Ear 0
                result[i + 1, 1, 0] = Rand.Next(randMin < -2 ? -2 : randMin, randMax > 4 ? 5 : randMax + 1);

                diffACcurBCprev = result[i, 0, 0] - result[i + 1, 1, 0];   // Compute differences for determining BC value for Ear 0
                // diffACprevACcur = result[i, 1, 0] - result[i+1, 1, 0];
                // diffBCprevACprev = result[i, 0, 0] - result[i, 1, 0];

                // BC of the current frequency must be within 10 dB of BC of the previous frequency,
                // within 10dB of AC of the current frequency, and also
                // no greater than AC of the current frequency.
                // This if block will determine the randMin and randMax values to achieve this

                if (diffACcurBCprev > 0)
                    randMin = result[i + 1, 1, 0] + diffACcurBCprev - 2;
                else
                    randMin = result[i + 1, 1, 0] - 2;

                if (diffACcurBCprev < -2)
                    randMax = result[i + 1, 1, 0] + diffACcurBCprev + 2;
                else
                    randMax = result[i + 1, 1, 0];

                // Since the AC will not be generated > 25 and BC must be <= AC, randMax does not need
                // a conditional ternary operator.
                result[i + 1, 0, 0] = Rand.Next(randMin < -2 ? -2 : randMin, randMax + 1);

                // Determine the range for the BC for ear 1 and randomize
                diffBC1prevBC0cur = result[i, 0, 1] - result[i + 1, 0, 0];

                if (diffBC1prevBC0cur > 1)
                    randMin = result[i + 1, 0, 0] + diffBC1prevBC0cur - 2;
                else
                    randMin = result[i + 1, 0, 0] - 1;

                if (diffBC1prevBC0cur < -1)
                    randMax = result[i + 1, 0, 0] + diffBC1prevBC0cur + 2;
                else
                    randMax = result[i + 1, 0, 0] + 1;

                result[i + 1, 0, 1] = Rand.Next(randMin < -2 ? -2 : randMin, randMax > 4 ? 5 : randMax + 1);

                // Determine the range for AC for ear 1
                diffBCcurACprev = result[i, 1, 1] - result[i + 1, 0, 1];

                if (diffBCcurACprev > 2)
                    randMin = result[i + 1, 0, 1] + diffBCcurACprev - 2;
                else
                    randMin = result[i + 1, 0, 1];

                // whichMax is used to ensure that the AC between both ears of the same frequency stays within 10 dB
                if (result[i + 1, 0, 1] > result[i + 1, 1, 0])
                    whichMax = result[i + 1, 1, 0];
                else
                    whichMax = result[i + 1, 0, 1];

                if (diffBCcurACprev < 0)
                    randMax = result[i + 1, 0, 1] + diffBCcurACprev + 2;
                else
                    randMax = whichMax + 2;

                // Randomize
                result[i + 1, 1, 1] = Rand.Next(randMin, randMax > 4 ? 5 : randMax + 1);

            };

            // Mulitply all values by 5 to align them to 5 dB increments
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        result[i, j, k] *= 5;
                    }
                }
            }
            #region Old Code
            /*
            }
            //#region B1
            /*
                        int b1 = a1 - (Rand.Next(-2, 2)) * 5;

                        if (b1 < -10)
                        {
                            b1 = -10;
                        }
                        else if (b1 > 25)
                        {
                            b1 = 25;
                        }
                        else if (b1 < (b0 - 10))
                        {
                            b1 = (b0 - 10);
                        }
                        else if (b1 > (b0 + 10))
                        {
                            b1 = (b0 + 10);
                        }
             */
            /*
    #endregion
                    #region A2

                    int a2 = a1 + (Rand.Next(0, 2)) * 5;
                    if (a2 < -10)
                    {
                        a2 = -10;
                    }
                    else if (a2 > 25)
                    {
                        a2=25;
                    }
                    #endregion
                    #region B2
                    int b2 = a2 - (Rand.Next(0, 2)) * 5;
                    if (b2 < -10)
                    {
                        b2 = 10;
                    }
                    if (b2 > 25)
                    {
                        b2 = 25;
                    }
                    if (b2 < (b1 - 10))
                    {
                        b2 = b1 - 10;
                    }
                    else if (b2 > (b1 + 10))
                    {
                        b2 = b1 + 10;
                    }
                    #endregion
                    #region A3

                    int a3 = a2 + (Rand.Next(0, 2)) * 5;
                    if (a3 < -10)
                    {
                        a3 = -10;
                    }
                    else if (a3 > 25)
                    {
                        a3 = 25;
                    }
                    #endregion
                    #region B3
                    int b3 = a3 - (Rand.Next(0, 2)) * 5;
                    if (b3 < -10)
                    {
                        b3 = 10;
                    }
                    if (b3 > 25)
                    {
                        b3 = 25;
                    }
                    if (b3 < (b2 - 10))
                    {
                        b3 = b2 - 10;
                    }
                    else if (b3 > (b2 + 10))
                    {
                        b3 = b2 + 10;
                    }
                    #endregion
                    #region A4

                    int a4 = a3 + (Rand.Next(0, 2)) * 5;
                    if (a4 < -10)
                    {
                        a4 = -10;
                    }
                    else if (a4 > 25)
                    {
                        a4 = 25;
                    }
                    #endregion
                    #region B4
                    int b4 = a4 - (Rand.Next(0, 2)) * 5;
                    if (b4 < -10)
                    {
                        b4 = 10;
                    }
                    if (b4 > 25)
                    {
                        b4 = 25;
                    }
                    if (b4 < (b3 - 10))
                    {
                        b4 = b3 - 10;
                    }
                    else if (b4 > (b3 + 10))
                    {
                        b4 = b3 + 10;
                    }
                    #endregion
                    #region A5
                    int a5 = a4 + (Rand.Next(0, 2)) * 5;
                    if (a5 < -10)
                    {
                        a5 = -10;
                    }
                    else if (a5 > 25)
                    {
                        a5 = 25;
                    }
                    #endregion
                    #region B5
                    int b5 = a5 - (Rand.Next(0, 2)) * 5;
                    if (b5 < -10)
                    {
                        b5 = 10;
                    }
                    if (b5 > 25)
                    {
                        b5 = 25;
                    }
                    if (b5 < (b4 - 10))
                    {
                        b5 = b4 - 10;
                    }
                    else if (b5 > (b4 + 10))
                    {
                        b5 = b4 + 10;
                    }
                    #endregion
            result[0,0] = b0;
            result[0,1] = a0;
            result[1,0] = b1;
            result[1,1] = a1;
            result[2,0] = b2;
            result[2,1] = a2;
            result[3,0] = b3;
            result[3,1] = a3;
            result[4,0] = b4;
            result[4,1] = a4;
            result[5,0] = b5;
            result[5,1] = a5;
            //#region A0
            //int a0=Rand.Next(-2,5)*5;
            //#endregion
            //#region A1
            /*                    int a1 = a0 + (Rand.Next(-2, 2)) * 5;
                                if (a1 < -10)
                                {
                                    a1 = -10;
                                }
                                else if (a1 > 25)
                                {
                                    a1 = 25;
                                }*/
            //#endregion


            //#region B0
            //int b0 = a0 - (Rand.Next(0, 2)) * 5;
            //if (b0 < -10)
            //{
            //    b0 = -10;
            //}      
            //#endregion
            #endregion
            return result;
        }
        public int[, ,] RandomNormalHearingNew()
        {
            #region Function Info
            // Generates a normal hearing pathology from which all other pathologies may be derived
            // Returns: 3D int Array containing air and bone conduction values for a single ear
            //  First index is the frequency index, 
            //  Second index is 0 for Bone, 1 for Air.
            //  Third index is for an ear (0 for an ear, 1 for the opposite ear)

            // This algorithm is based on the following rules:
            // All values must fall within the range of -10 to 20 dB
            // BC for one ear is within +- 5 dB of BC for the other ear (IA approximately 0)
            // BC between neighboring frequencies for the same ear must be within 10 dB
            // Difference between AC and BC of the same ear must be within 10 dB
            // BC must not exceed AC for the same ear
            // AC between neihboring frequencies must be within 10 dB
            // AC between left and right for the same frequency must be within 10 dB
            #endregion

            // Matt Harris
            // 10/07/2011
            // See documentation for thought process

            int[, ,] result = new int[6, 2, 2];
            Random rand = new Random();     // Random number generator
            int randMin = 0, randMax = 3;   // Minimum and Maximum random values
            int curFreqIndex = 0, prevFreqIndex;
            
            const int BC = 0;
            const int AC = 1;

            int diffACcurBCprev = 0;    // Difference between the AC of the current frequency
            // and the BC of the previous frequency (BCprev - ACcur)
            int diffBC1prevBC0cur = 0;  // Difference between the BC for ear 1 of the previous frequency
            // and BC for ear 0 of the current frequency (BC0cur - BC1prev)
            int diffBCcurACprev = 0;    // Difference between the BC for the current frequency
            // and the AC for the previous frequency (ACprev - BCcur)
            int diffAC0curAC1prev = 0;  // Difference between the AC for ear 0 at the current frequency
            // and the AC for ear 1 at the previous frequency
            int diffAC0curBC1cur = 0;   // Difference between the AC for ear 0 at the current frequency
            // and the BC for ear 1 at the current frequency

            // minValue argument on Random.Next is inclusive
            // maxValue argument on Random.Next is exclusive
            // Review the Ternary Operator to understand ? : operations

            // Randomize air conduction at 250 Hz between -10 and 25 for Ear 0
            result[curFreqIndex, AC, 0] = rand.Next(MinThreshold, MaxThreshold + 1);
            
            randMin = result[curFreqIndex, AC, 0] - MaxACtoBCDiff;     // BC value within 10 dB of AC value
            result[curFreqIndex, BC, 0] = rand.Next(randMin < MinThreshold ? MinThreshold : randMin, 
                                                    result[curFreqIndex, AC, 0] + 1); //Randomize the bone conduction value for Ear 0

            // Based off the ear 0 bone conduction value @ 250 Hz, determine the bone conduction value for ear 1 @ 250 Hz
            randMin = result[curFreqIndex, BC, 0] - MaxBCtoBCDiff;
            randMax = result[curFreqIndex, BC, 0] + MaxBCtoBCDiff;
            result[curFreqIndex, BC, 1] = rand.Next(randMin < MinThreshold ? MinThreshold : randMin, 
                                        randMax > MaxThreshold ? MaxThreshold + 1 : randMax + 1);

            // Now the air conduction value for ear 1 @ 250 Hz can be determined
            randMin = result[curFreqIndex, AC, 0] - result[curFreqIndex, BC, 1] > 10 ? 
                        result[curFreqIndex, AC, 0] - MaxACtoACDiff : 
                        result[curFreqIndex, BC, 1];
            randMax = result[curFreqIndex, AC, 0] - result[curFreqIndex, BC, 1] < 0 ? 
                        result[curFreqIndex, AC, 0] + MaxACtoACDiff : 
                        result[curFreqIndex, BC, 1] + MaxACtoBCDiff;
            result[curFreqIndex, AC, 1] = rand.Next(randMin, 
                                        randMax > MaxThreshold ? MaxThreshold + 1 : randMax + 1);

            // Randomize all other values for the ear
            for (int i = 0; i <= 4; i++)
            {
                curFreqIndex = i + 1;
                prevFreqIndex = i;

                randMin = result[prevFreqIndex, AC, 0] - MaxACtoACDiff; // Air conduction between two neighboring frequencies must be within
                randMax = result[prevFreqIndex, AC, 0] + MaxACtoACDiff; // 10 dB of each other

                // Range is between -10 dB and 20 dB, randomize next frequencies AC value for Ear 0
                result[curFreqIndex, AC, 0] = rand.Next(randMin < MinThreshold ? MinThreshold : randMin, 
                                                randMax > MaxThreshold ? MaxThreshold + 1 : randMax + 1);

                // Compute differences for determining BC value for Ear 0
                diffACcurBCprev = result[prevFreqIndex, BC, 0] - result[curFreqIndex, AC, 0];

                // BC of the current frequency must be within 10 dB of BC of the previous frequency,
                // within 10dB of AC of the current frequency, and also
                // no greater than AC of the current frequency.
                // This if block will determine the randMin and randMax values to achieve this

                if (diffACcurBCprev > 0)
                    // If the difference is greater than zero then previous frequency BC is more limiting
                    randMin = result[prevFreqIndex, BC, 0] - MaxFreqBCtoBCDiff;
                else
                    // Otherwise current frequency AC is more limiting
                    randMin = result[curFreqIndex, AC, 0] - MaxACtoBCDiff;

                if (diffACcurBCprev < -MaxFreqBCtoBCDiff)
                    randMax = result[prevFreqIndex, BC, 0] + MaxFreqBCtoBCDiff;
                else
                    randMax = result[curFreqIndex, AC, 0];

                // Since the AC will not be generated > 20 and BC must be <= AC, randMax does not need
                // a conditional ternary operator.
                result[curFreqIndex, BC, 0] = rand.Next(randMin < MinThreshold ? MinThreshold : randMin, 
                                                randMax + 1);
                
                // Determine the range for the BC for ear 1 and randomize
                diffBC1prevBC0cur = result[prevFreqIndex, BC, 1] - result[curFreqIndex, BC, 0];

                if (diffBC1prevBC0cur > MaxBCtoBCDiff)
                    randMin = result[prevFreqIndex, BC, 1] - MaxFreqBCtoBCDiff;
                else
                    randMin = result[curFreqIndex, BC, 0] - MaxBCtoBCDiff;

                if (diffBC1prevBC0cur < -MaxBCtoBCDiff)
                    randMax = result[prevFreqIndex, BC, 1] + MaxFreqBCtoBCDiff;
                else
                    randMax = result[curFreqIndex, BC, 0] + MaxBCtoBCDiff;

                result[curFreqIndex, BC, 1] = rand.Next(randMin < MinThreshold ? MinThreshold : randMin, 
                                                        randMax > MaxThreshold ? MaxThreshold + 1 : randMax + 1);
               
                // Determine the range for AC for ear 1
                diffBCcurACprev = result[prevFreqIndex, AC, 1] - result[curFreqIndex, BC, 1];
                diffAC0curAC1prev = result[curFreqIndex, AC, 0] - result[prevFreqIndex, AC, 1];
                diffAC0curBC1cur = result[curFreqIndex, AC, 0] - result[curFreqIndex, BC, 1];

                // randMin
                if (diffAC0curBC1cur > MaxACtoACDiff)
                {
                    if (diffAC0curAC1prev < 0)
                        randMin = result[prevFreqIndex, AC, 1] - MaxACtoACDiff;
                    else
                        randMin = result[curFreqIndex, AC, 0] - MaxACtoACDiff;
                }
                else if (diffBCcurACprev > MaxACtoBCDiff)
                    randMin = result[prevFreqIndex, AC, 1] - MaxACtoACDiff;
                else
                    randMin = result[curFreqIndex, BC, 1];

                // randMax
                if (diffAC0curBC1cur < 0)
                {
                    if (diffAC0curAC1prev > 0)
                        randMax = result[prevFreqIndex, AC, 1] + MaxACtoACDiff;
                    else
                        randMax = result[curFreqIndex, AC, 0] + MaxACtoACDiff;
                }
                else if (diffBCcurACprev < 0)
                    randMax = result[prevFreqIndex, AC, 1] + MaxACtoACDiff;
                else
                    randMax = result[curFreqIndex, BC, 1] + MaxACtoBCDiff;
                
                // Randomize
                result[curFreqIndex, AC, 1] = rand.Next(randMin, 
                                                randMax > MaxThreshold ? MaxThreshold + 1 : randMax + 1);

            };

            return result;
        }

        void TestNormalHearing(int[, ,] normHearing)
        {
            // This tests a normal hearing pathology based on the following rules:
            // All values must fall within the range of -10 to 20 dB
            // BC for one ear is within +- 5 dB of BC for the other ear (IA approximately 0)
            // BC between neighboring frequencies for the same ear must be within 10 dB
            // Difference between AC and BC of the same ear must be within 10 dB
            // BC must not exceed AC for the same ear
            // AC between neihboring frequencies must be within 10 dB
            // AC between left and right for the same frequency must be within 10 dB

            //bool inconsistency = false;

            for (int frequencyIndex = 0; frequencyIndex <= 5; frequencyIndex++)
            {
                for (int BCorAC = 0; BCorAC <= 1; BCorAC++)
                {
                    for (int ear = 0; ear <= 1; ear++)
                    {
                        int otherEar = Math.Abs(ear - 1);
                        int valueInTest = normHearing[frequencyIndex, BCorAC, ear];
                        // Test "All values must fall within the range of -10 to 20 dB"
                        if (valueInTest < MinThreshold ||
                            valueInTest > MaxThreshold)
                        {
                            //object[] stringFormatValues = new object()
                            System.Windows.Forms.MessageBox.Show(String.Format("A value is outside the normal hearing range ({0:d} to {1:d})\n\nValue - {2:d}\nFreqIndex - {3:d}\nBCorAC - {4:d}\nEar - {5:d}",
                                                                 new object[] {MinThreshold, MaxThreshold, valueInTest, frequencyIndex, BCorAC, ear}));

                            System.Diagnostics.Debugger.Break();
                        }

                        // BC for one ear is within +- 5 dB of BC for the other ear
                        if (BCorAC == 0 &&
                            (valueInTest < normHearing[frequencyIndex, 0, otherEar] - MaxBCtoBCDiff ||
                            valueInTest > normHearing[frequencyIndex, 0, otherEar] + MaxBCtoBCDiff))
                        {
                            System.Windows.Forms.MessageBox.Show(String.Format("BC for one ear is outside {4:d} dB of the other ear at the same frequency\n\nValue - {0:d}\nFreqIndex - {1:d}\nBCorAC - {2:d}\nEar - {3:d}",
                                                                 new object[] { valueInTest, frequencyIndex, BCorAC, ear, MaxBCtoBCDiff }));

                            System.Diagnostics.Debugger.Break();
                        }

                        // BC between neighboring frequencies for the same ear must be within 10 dB
                        if (frequencyIndex >= 1 &&
                            BCorAC == 0 &&
                            (valueInTest < normHearing[frequencyIndex - 1, 0, ear] - MaxFreqBCtoBCDiff ||
                            valueInTest > normHearing[frequencyIndex - 1, 0, ear] + MaxFreqBCtoBCDiff))
                        {
                            System.Windows.Forms.MessageBox.Show(String.Format("BC for one freq is outside {4:d} dB of the same ear but neighboring frequency\n\nValue - {0:d}\nFreqIndex - {1:d}\nBCorAC - {2:d}\nEar - {3:d}",
                                                                 new object[] { valueInTest, frequencyIndex, BCorAC, ear, MaxFreqBCtoBCDiff }));

                            System.Diagnostics.Debugger.Break();
                        }

                        // Difference between AC and BC of the same ear must be within 10 dB
                        // BC must not exceed AC for the same ear
                        if (BCorAC == 0 &&
                            (valueInTest < normHearing[frequencyIndex, 1, ear] - MaxACtoBCDiff ||
                            valueInTest > normHearing[frequencyIndex, 1, ear]))
                        {
                            System.Windows.Forms.MessageBox.Show(String.Format("AC and BC for the same ear at the same frequency are inconsistent\n\nValue - {0:d}\nFreqIndex - {1:d}\nBCorAC - {2:d}\nEar - {3:d}",
                                                                 new object[] { valueInTest, frequencyIndex, BCorAC, ear }));

                            System.Diagnostics.Debugger.Break();

                        }

                        // AC between neihboring frequencies must be within 10 dB
                        if (frequencyIndex >= 1 &&
                            BCorAC == 1 &&
                            (valueInTest < normHearing[frequencyIndex - 1, 1, ear] - MaxACtoACDiff ||
                            valueInTest > normHearing[frequencyIndex - 1, 1, ear] + MaxACtoACDiff))
                        {
                            System.Windows.Forms.MessageBox.Show(String.Format("Neihboring Frequency AC values are outside {4:d} dB of eachother\n\nValue - {0:d}\nFreqIndex - {1:d}\nBCorAC - {2:d}\nEar - {3:d}",
                                                                 new object[] { valueInTest, frequencyIndex, BCorAC, ear, MaxACtoACDiff }));

                            System.Diagnostics.Debugger.Break();
                        }

                        // AC between left and right for the same frequency must be within 10 dB
                        if (BCorAC == 1 &&
                            (valueInTest < normHearing[frequencyIndex, 1, otherEar] - MaxACtoACDiff ||
                            valueInTest > normHearing[frequencyIndex, 1, otherEar] + MaxACtoACDiff))
                        {
                            System.Windows.Forms.MessageBox.Show(String.Format("AC values for the same frequency are outside {4:d} dB of eachother\n\nValue - {0:d}\nFreqIndex - {1:d}\nBCorAC - {2:d}\nEar - {3:d}",
                                                                 new object[] { valueInTest, frequencyIndex, BCorAC, ear, MaxACtoACDiff }));

                            System.Diagnostics.Debugger.Break();
                        }
                    }
                }
            }
        }
        void TestNIT(int LAC8000, int RAC8000)
        {
            if (LAC8000 < -15 || RAC8000 < -15)
                System.Diagnostics.Debugger.Break();
        }
	}
}