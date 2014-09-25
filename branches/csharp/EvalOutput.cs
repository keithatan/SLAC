using System;
using Pathology_Dev;
using Audiogram_Dev;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace Virtual_Lab
{
    public struct EvalAudiometer
    {
        public Audiometer.audiometerSettings ameterSettings;
        public Audiometer.channelSettings testChannel;
        public Audiometer.channelSettings maskChannel;
    }

    public class EvalHtml
    {
        private string evalReport;

        public EvalHtml()
        {
            Assembly thisAssembly = Assembly.GetExecutingAssembly();
            StreamReader evalReportStream = 
                new StreamReader(thisAssembly.GetManifestResourceStream("Virtual_Lab.EvalReport.htm"));

            evalReport = evalReportStream.ReadToEnd();
        }

        public void SaveEval()
        {
            FileStream fs = new FileStream("EvalReport.htm", FileMode.Create);
            StreamWriter fsr = new StreamWriter(fs);

            fsr.Write(evalReport);

            fsr.Close();
        }

        public bool ChangeTagAttributes(string id, string value, string color)
        {
            int firstBracketIndex = 0;
            int lastBracketIndex = 0;
            int firstQuoteIndex = 0;
            int lastQuoteIndex = 0;
            int classIndex = 0;
            int gtBracketIndex = 0;
            //int ltBracketIndex = 0;

            bool foundID = false;

            string oldTag, newTag;
            string classAttribute;
            string tdValue;

            do
            {
                firstBracketIndex = evalReport.IndexOf('<', firstBracketIndex + 1);
                if (firstBracketIndex == -1) continue;

                lastBracketIndex = evalReport.IndexOf('<', firstBracketIndex + 1);
                if (lastBracketIndex == -1) continue;

                oldTag = evalReport.Substring(firstBracketIndex + 1, lastBracketIndex - firstBracketIndex - 1);
                if (!oldTag.Contains(id)) continue;

                foundID = true;

                classIndex = oldTag.IndexOf("style=");

                firstQuoteIndex = oldTag.IndexOf('\"', classIndex);
                lastQuoteIndex = oldTag.IndexOf('\"', firstQuoteIndex + 1);

                classAttribute = oldTag.Substring(firstQuoteIndex + 1, lastQuoteIndex - firstQuoteIndex - 1);

                gtBracketIndex = oldTag.IndexOf('>');
                tdValue = oldTag.Substring(gtBracketIndex + 1, oldTag.Length - gtBracketIndex - 1);

                newTag = oldTag.Replace(tdValue, value);
                newTag = newTag.Replace(classAttribute, color);

                evalReport = evalReport.Replace(oldTag, newTag);

                firstBracketIndex = -1;

            } while (firstBracketIndex != -1);

            return foundID;
        }
    }

    public class EvalOutput
    {
        // First index = frequency
        // Second index = 0 for BC, 1 for AC
        // Third index = 0 for unmasked, 1 for masked
        // fourth index = 0 for left, 1 for right
        // value is the dB level plotted
        public int[, , ,] StudentAudiogram;
        // in each index pertains to the audiometer setting where the student placed the point
        public EvalAudiometer[, , ,] StudentAudiometer;

        // First index = frequency
        // Second index = 0 for BC, 1 for AC
        // Third index = 0 for left, 1 for right
        // value is the minimum masked db value during masking
        public int[, ,] StudentMaskedMinimums;
        public int[, ,] StudentMaskedMaximums;

        public Pathology pathology;

        public EvalOutput(Pathology path)
        {
            pathology = path;

            StudentAudiogram = new int[6, 2, 2, 2];
            StudentAudiometer = new EvalAudiometer[6, 2, 2, 2];
            StudentMaskedMinimums = new int[6, 2, 2];
            StudentMaskedMaximums = new int[6, 2, 2];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        StudentMaskedMinimums[i, j, k] = int.MaxValue;
                    }
                }
            }
        }

        public void CheckMinimum(int frequencyIndex, Audiometer.channelSettings TestChannel, Audiometer.channelSettings MaskChannel)
        {
            if (MaskChannel.interrupt == false)
                return;

            int ear = MaskChannel.route == Ear.left ? 0 : 1;
            int trans = TestChannel.trans == Audiometer.TransducerType.Bone ? 0 : 1;

            if (StudentMaskedMinimums[frequencyIndex, trans, ear] > MaskChannel.volume)
                StudentMaskedMinimums[frequencyIndex, trans, ear] = MaskChannel.volume;
        }

        public void CompileResults(Audiogram audiogram)
        {
            StudentMaskedMaximums[0, 0, 0] = Convert.ToInt32(audiogram.txtLMaskBC250.Text);
            StudentMaskedMaximums[0, 0, 1] = Convert.ToInt32(audiogram.txtRMaskBC250.Text);
            StudentMaskedMaximums[0, 1, 0] = Convert.ToInt32(audiogram.txtLMaskAC250.Text);
            StudentMaskedMaximums[0, 1, 1] = Convert.ToInt32(audiogram.txtRMaskAC250.Text);
            StudentMaskedMaximums[1, 0, 0] = Convert.ToInt32(audiogram.txtLMaskBC500.Text);
            StudentMaskedMaximums[1, 0, 1] = Convert.ToInt32(audiogram.txtRMaskBC500.Text);
            StudentMaskedMaximums[1, 1, 0] = Convert.ToInt32(audiogram.txtLMaskAC500.Text);
            StudentMaskedMaximums[1, 1, 1] = Convert.ToInt32(audiogram.txtRMaskAC500.Text);
            StudentMaskedMaximums[2, 0, 0] = Convert.ToInt32(audiogram.txtLMaskBC1000.Text);
            StudentMaskedMaximums[2, 0, 1] = Convert.ToInt32(audiogram.txtRMaskBC1000.Text);
            StudentMaskedMaximums[2, 1, 0] = Convert.ToInt32(audiogram.txtLMaskAC1000.Text);
            StudentMaskedMaximums[2, 1, 1] = Convert.ToInt32(audiogram.txtRMaskAC1000.Text);
            StudentMaskedMaximums[3, 0, 0] = Convert.ToInt32(audiogram.txtLMaskBC2000.Text);
            StudentMaskedMaximums[3, 0, 1] = Convert.ToInt32(audiogram.txtRMaskBC2000.Text);
            StudentMaskedMaximums[3, 1, 0] = Convert.ToInt32(audiogram.txtLMaskAC2000.Text);
            StudentMaskedMaximums[3, 1, 1] = Convert.ToInt32(audiogram.txtRMaskAC2000.Text);
            StudentMaskedMaximums[4, 0, 0] = Convert.ToInt32(audiogram.txtLMaskBC4000.Text);
            StudentMaskedMaximums[4, 0, 1] = Convert.ToInt32(audiogram.txtRMaskBC4000.Text);
            StudentMaskedMaximums[4, 1, 0] = Convert.ToInt32(audiogram.txtLMaskAC4000.Text);
            StudentMaskedMaximums[4, 1, 1] = Convert.ToInt32(audiogram.txtRMaskAC4000.Text);

            // No masking at 8000 Hz, but the code is here if needed
            //StudentMaskedMaximums[5, 0, 0] = Convert.ToInt32(audiogram.txtLMaskBC8000.Text);
            //StudentMaskedMaximums[5, 0, 1] = Convert.ToInt32(audiogram.txtRMaskBC8000.Text);
            //StudentMaskedMaximums[5, 1, 0] = Convert.ToInt32(audiogram.txtLMaskAC8000.Text);
            //StudentMaskedMaximums[5, 1, 1] = Convert.ToInt32(audiogram.txtRMaskAC8000.Text);

            EvalHtml eval = new EvalHtml();

            int freq, freqindex, cond, mask, ear;
            int colorCode;

            const int ColorCode_Red = 2;
            const int ColorCode_Yellow = 1;
            const int ColorCode_Green = 0;

            string sFreq, sConduction, sMasked, sEar;
            string outputColor;
            int pathologyValue;
            string studentValue;
            string tagID;

            for (freqindex = 0; freqindex <= 5; freqindex++)
            {
                freq = 250 * (int)Math.Pow(2, freqindex);
                sFreq = freq.ToString();
                for (cond = 0; cond <= 1; cond++)
                {
                    sConduction = cond == 0 ? "bc" : "ac";
                    for (mask = 0; mask <= 1; mask++)
                    {
                        sMasked = mask == 0 ? "u" : "m";
                        for (ear = 0; ear <= 1; ear++)
                        {
                            sEar = ear == 0 ? "l" : "r";

                            if (cond == 0 && mask == 0)
                                pathologyValue = pathology.BC_Thresh_Val(freq, (Ear) ear);
                            else if (cond == 1 && mask == 0)
                                pathologyValue = pathology.AC_Thresh_Val(freq, (Ear) ear);
                            else if (cond == 0 && mask == 1)
                                pathologyValue = pathology.BC_Mask_Val(freq, (Ear) ear);
                            else
                                pathologyValue = pathology.AC_Mask_Val(freq, (Ear) ear);

                            tagID = string.Format("{0}t{1}{2}{3}", sEar, sConduction, sMasked, sFreq);
                            eval.ChangeTagAttributes(tagID, pathologyValue.ToString(), "color:white");

                            colorCode = ColorCode_Green;

                            /*  Yellow Conditions  */
                            if (StudentAudiogram[freqindex, cond, mask, ear] < pathologyValue - 5 || StudentAudiogram[freqindex, cond, mask, ear] >= pathologyValue + 5)
                                colorCode = ColorCode_Yellow;

                            /*  Red Conditions  */
                            // Test to make sure the student didn't plot the wrong transducer symbol
                            switch (StudentAudiometer[freqindex, cond, mask, ear].testChannel.trans)
                            {
                                case Audiometer.TransducerType.Bone :
                                    if (cond != 0)
                                        colorCode = ColorCode_Red;
                                    break;
                                case Audiometer.TransducerType.Insert :
                                    if (cond != 1)
                                        colorCode = ColorCode_Red;
                                    break;
                                case Audiometer.TransducerType.Phone :
                                    if (cond != 1)
                                        colorCode = ColorCode_Red;
                                    break;
                            }

                            // Test to make sure the student didn't plot the wrong ear symbol
                            switch (StudentAudiometer[freqindex, cond, mask, ear].testChannel.route)
                            {
                                case Ear.left :
                                    if (ear != 0)
                                        colorCode = ColorCode_Red;
                                    break;
                                case Ear.right :
                                    if (ear != 1)
                                        colorCode = ColorCode_Red;
                                    break;
                            }

                            // Test to make sure the student didn't present a tone from a channel that has the interrupt set
                            if (StudentAudiometer[freqindex, cond, mask, ear].testChannel.interrupt)
                                colorCode = ColorCode_Red;

                            // Test to make sure the student didn't mask a tone that wasn't supposed to be masked
                            if (mask == 0 && StudentAudiometer[freqindex, cond, mask, ear].maskChannel.interrupt)
                                colorCode = ColorCode_Red;

                            // Test to make sure the student didn't forget to mask a tone that should have been masked
                            if (mask == 1 && !StudentAudiometer[freqindex, cond, mask, ear].maskChannel.interrupt)
                                colorCode = ColorCode_Red;

                            // Test to make sure that while masking, the student had the correct masking channel settings
                            if (mask == 1)
                            {
                                // Test to make sure the student used NBNoise to mask a tone
                                if (StudentAudiometer[freqindex, cond, mask, ear].maskChannel.stim != Audiometer.StimulusType.NB)
                                    colorCode = ColorCode_Red;

                                // Test to make sure the interrupt was sent to the opposite ear
                                if (StudentAudiometer[freqindex, cond, mask, ear].maskChannel.route != (Ear) Math.Abs(ear - 1))
                                    colorCode = ColorCode_Red;

                                // Test to make sure the proper transducer was used to mask
                                if (StudentAudiometer[freqindex, cond, mask, ear].maskChannel.trans != Audiometer.TransducerType.Phone)
                                    colorCode = ColorCode_Red;
                            }

                            // Test to make sure the student placed the point at the proper frequency
                            if (StudentAudiometer[freqindex, cond, mask, ear].ameterSettings.frequency != freq)
                                colorCode = ColorCode_Red;

                            /*  Decode Color Codes  */
                            switch (colorCode)
                            {
                                case ColorCode_Green :
                                    studentValue = StudentAudiogram[freqindex, cond, mask, ear].ToString();
                                    outputColor = "color:green";
                                    break;
                                case ColorCode_Red :
                                    studentValue = "[ " + StudentAudiogram[freqindex, cond, mask, ear].ToString() + " ]";
                                    outputColor = "color:red";
                                    break;
                                case ColorCode_Yellow :
                                    studentValue = "( " + StudentAudiogram[freqindex, cond, mask, ear].ToString() + " )";
                                    outputColor = "color:yellow";
                                    break;
                                default :
                                    studentValue = StudentAudiogram[freqindex, cond, mask, ear].ToString();
                                    outputColor = "color:white";
                                    break;
                            }

                            tagID = string.Format("{0}s{1}{2}{3}", sEar, sConduction, sMasked, sFreq);

                            eval.ChangeTagAttributes(tagID, studentValue, outputColor);
                        }   // for ear
                    }   // for mask
                }   // for cond
            }   // for freqindex
            //eval.ChangeTdTag("rsac250", "50", "color_green");
            
            eval.SaveEval();

        }
    }
}