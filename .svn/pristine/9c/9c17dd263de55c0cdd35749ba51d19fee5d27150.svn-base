using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Plateau_Panel
{
    /// <summary>
    /// Summary description for Form2.
    /// </summary>
    public class PlateauPlotPanel : System.Windows.Forms.Panel
    {
        private System.Windows.Forms.Panel PlotArea;
        private System.Windows.Forms.Label label0;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblY0;
        private System.Windows.Forms.Label lblY1;
        private System.Windows.Forms.Label lblY6;
        private System.Windows.Forms.Label lblY5;
        private System.Windows.Forms.Label lblY4;
        private System.Windows.Forms.Label lblY3;
        private System.Windows.Forms.Label lblY2;
        private const String PT_SYMBOL = "X";
        private System.Drawing.Color LINE_COLOR = System.Drawing.Color.Black;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        // Used in plotting user input coordinates
        struct gPts
        {
            public int X;
            public int Y;
        }
        gPts thePoint = new gPts();

        // User defined Variables
        public const int MIN_X = 0;
        public const int MAX_X = 120;
        public static int minThresholdLvl;
        public bool bMinSet;
        protected ArrayList PlottedPoints;
        private Label lblY7;
        protected ArrayList SortedPoints;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PlateauPlotPanel()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            PlottedPoints = new ArrayList();
            SortedPoints = new ArrayList();
            ClearAll();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlateauPlotPanel));
            this.PlotArea = new System.Windows.Forms.Panel();
            this.label0 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblY0 = new System.Windows.Forms.Label();
            this.lblY1 = new System.Windows.Forms.Label();
            this.lblY6 = new System.Windows.Forms.Label();
            this.lblY5 = new System.Windows.Forms.Label();
            this.lblY4 = new System.Windows.Forms.Label();
            this.lblY3 = new System.Windows.Forms.Label();
            this.lblY2 = new System.Windows.Forms.Label();
            this.lblY7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PlotArea
            // 
            this.PlotArea.BackColor = System.Drawing.Color.Transparent;
            this.PlotArea.ForeColor = System.Drawing.Color.Transparent;
            this.PlotArea.Location = new System.Drawing.Point(48, 0);
            this.PlotArea.Name = "PlotArea";
            this.PlotArea.Size = new System.Drawing.Size(521, 384);
            this.PlotArea.TabIndex = 0;
            this.PlotArea.Paint += new System.Windows.Forms.PaintEventHandler(this.PlotArea_Paint);
            // 
            // label0
            // 
            this.label0.BackColor = System.Drawing.Color.White;
            this.label0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label0.Location = new System.Drawing.Point(48, 383);
            this.label0.Name = "label0";
            this.label0.Size = new System.Drawing.Size(22, 16);
            this.label0.TabIndex = 1;
            this.label0.Text = "0";
            this.label0.Click += new System.EventHandler(this.label0_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(88, 383);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "10";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(168, 383);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "30";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(128, 383);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "20";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(328, 383);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "70";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(288, 383);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "60";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(248, 383);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "50";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(208, 383);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "40";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(488, 383);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 16);
            this.label11.TabIndex = 12;
            this.label11.Text = "110";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(448, 383);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 16);
            this.label10.TabIndex = 11;
            this.label10.Text = "100";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(408, 383);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 16);
            this.label9.TabIndex = 10;
            this.label9.Text = "90";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(368, 383);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 16);
            this.label8.TabIndex = 9;
            this.label8.Text = "80";
            // 
            // lblY0
            // 
            this.lblY0.BackColor = System.Drawing.Color.White;
            this.lblY0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblY0.Location = new System.Drawing.Point(24, 368);
            this.lblY0.Name = "lblY0";
            this.lblY0.Size = new System.Drawing.Size(28, 16);
            this.lblY0.TabIndex = 13;
            this.lblY0.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblY1
            // 
            this.lblY1.BackColor = System.Drawing.Color.White;
            this.lblY1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblY1.Location = new System.Drawing.Point(24, 318);
            this.lblY1.Name = "lblY1";
            this.lblY1.Size = new System.Drawing.Size(28, 16);
            this.lblY1.TabIndex = 14;
            this.lblY1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblY6
            // 
            this.lblY6.BackColor = System.Drawing.Color.White;
            this.lblY6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblY6.Location = new System.Drawing.Point(24, 68);
            this.lblY6.Name = "lblY6";
            this.lblY6.Size = new System.Drawing.Size(28, 16);
            this.lblY6.TabIndex = 15;
            this.lblY6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblY5
            // 
            this.lblY5.BackColor = System.Drawing.Color.White;
            this.lblY5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblY5.Location = new System.Drawing.Point(24, 118);
            this.lblY5.Name = "lblY5";
            this.lblY5.Size = new System.Drawing.Size(28, 16);
            this.lblY5.TabIndex = 16;
            this.lblY5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblY4
            // 
            this.lblY4.BackColor = System.Drawing.Color.White;
            this.lblY4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblY4.Location = new System.Drawing.Point(24, 168);
            this.lblY4.Name = "lblY4";
            this.lblY4.Size = new System.Drawing.Size(28, 16);
            this.lblY4.TabIndex = 17;
            this.lblY4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblY3
            // 
            this.lblY3.BackColor = System.Drawing.Color.White;
            this.lblY3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblY3.Location = new System.Drawing.Point(24, 218);
            this.lblY3.Name = "lblY3";
            this.lblY3.Size = new System.Drawing.Size(28, 16);
            this.lblY3.TabIndex = 18;
            this.lblY3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblY2
            // 
            this.lblY2.BackColor = System.Drawing.Color.White;
            this.lblY2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblY2.Location = new System.Drawing.Point(24, 268);
            this.lblY2.Name = "lblY2";
            this.lblY2.Size = new System.Drawing.Size(28, 16);
            this.lblY2.TabIndex = 19;
            this.lblY2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblY7
            // 
            this.lblY7.BackColor = System.Drawing.Color.White;
            this.lblY7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblY7.Location = new System.Drawing.Point(24, 18);
            this.lblY7.Name = "lblY7";
            this.lblY7.Size = new System.Drawing.Size(28, 16);
            this.lblY7.TabIndex = 20;
            this.lblY7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PlateauPlotPanel
            // 
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(554, 429);
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblY7);
            this.Controls.Add(this.lblY2);
            this.Controls.Add(this.lblY3);
            this.Controls.Add(this.lblY4);
            this.Controls.Add(this.lblY5);
            this.Controls.Add(this.lblY6);
            this.Controls.Add(this.lblY1);
            this.Controls.Add(this.lblY0);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label0);
            this.Controls.Add(this.PlotArea);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            //this.MaximizeBox = false;
            this.Name = "PlateauPlotPanel";
            this.Text = "Plateau Plot";
            //this.Load += new System.EventHandler(this.PlateauPlotPanel_Load);
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        ///  Sets the minimum Threshold level on the Y axis
        /// </summary>
        /// <param name="Value">Minimum Threshold</param>
        public void Set_Min_Threshold(int Value)
        {
            minThresholdLvl = Value;
            bMinSet = true;
        }

        /// <summary>
        /// Fills the labels on the Y axis with the appropriate values
        /// </summary>
        public void SetYAxisLabels()
        {
            if (bMinSet)
            {
                // Hardcoding -10 to be the minimum for test purposes. A floating threshold axis
                // may be programmed by removing the following line.
                //minThresholdLvl = -10;


                this.lblY0.Text = String.Format("{0}", minThresholdLvl);
                this.lblY1.Text = String.Format("{0}", minThresholdLvl + 10);
                this.lblY2.Text = String.Format("{0}", minThresholdLvl + 20);
                this.lblY3.Text = String.Format("{0}", minThresholdLvl + 30);
                this.lblY4.Text = String.Format("{0}", minThresholdLvl + 40);
                this.lblY5.Text = String.Format("{0}", minThresholdLvl + 50);
                this.lblY6.Text = String.Format("{0}", minThresholdLvl + 60);
                this.lblY7.Text = String.Format("{0}", minThresholdLvl + 70);
            }
        }

        /// <summary>
        /// Clears all the dynamic fields
        /// </summary>
        public void ClearAll()
        {
            // Clear Labels
            minThresholdLvl = 0;
            bMinSet = false;
            this.lblY0.Text = "";
            this.lblY1.Text = "";
            this.lblY2.Text = "";
            this.lblY3.Text = "";
            this.lblY4.Text = "";
            this.lblY5.Text = "";
            this.lblY6.Text = "";
            this.lblY7.Text = "";

            // Initialize Point Array
            this.PlottedPoints.Clear();
            this.SortedPoints.Clear();
            this.PlotArea.Invalidate();
        }

        /// <summary>
        /// Plot a point on the graph
        /// </summary>
        /// <param name="X">X coordinate in dB</param>
        /// <param name="Y">Y coordinate in dB</param>
        public void PlotDataPt(int X, int Y)
        {
            if (bMinSet == false) return;

            // Validate Data
            if ((X < MIN_X)
                || (X > MAX_X)
                || (Y < minThresholdLvl)
                || (Y > minThresholdLvl + 80))
            {
                return;
            }
            else
            {
                // Insert Data into array
                System.Drawing.Point temp = new System.Drawing.Point(X, Y);
                // Make sure this is not a duplicate point
                if (PlottedPoints.Contains(temp) == false) this.PlottedPoints.Add(temp);
                else return;
            }

            // Draw the points
            this.Paint += new PaintEventHandler(PlateauPlotPanel_Paint);
            if (this.PlottedPoints.Count > 0) ConnectPoints();
            this.PlotArea.Invalidate();
        }

        /// <summary>
        /// Special Paint function for the Plateau Plot
        /// </summary>
        private void PlateauPlotPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < this.PlottedPoints.Count; i++)
            {
                thePoint = FindPixelCoord((System.Drawing.Point)this.PlottedPoints[i]);

                // Draw it
                g.DrawString(PT_SYMBOL, new Font("Arial", 12, System.Drawing.FontStyle.Bold),
                    new SolidBrush(System.Drawing.Color.Black), thePoint.X, thePoint.Y);
            }
        }

        /// <summary>
        /// This function will connect the points on the plot with a line
        /// </summary>
        public void ConnectPoints()
        {
            // Verify there is enough data
            if (this.PlottedPoints.Count < 2)
            {
                SortedPoints.Clear();
                return;
            }

            // Sort Data in ascending order based on X value
            SortedPoints = new ArrayList(this.PlottedPoints);
            for (int i = 0; i < SortedPoints.Count - 1; i++)
            {
                System.Drawing.Point thisPoint = (System.Drawing.Point)SortedPoints[i];
                System.Drawing.Point nextPoint = (System.Drawing.Point)SortedPoints[i + 1];
                System.Drawing.Point temp = new System.Drawing.Point();
                if ((thisPoint.X > nextPoint.X)
                    || (thisPoint.X == nextPoint.X && thisPoint.Y > nextPoint.Y))
                {
                    temp = (System.Drawing.Point)SortedPoints[i];
                    SortedPoints[i] = SortedPoints[i + 1];
                    SortedPoints[i + 1] = temp;
                    if (i > 0) i -= 2;
                }
            }

            // Draw the lines
            this.Paint += new PaintEventHandler(PlateauPlotPanel_Line_Paint);
            this.PlotArea.Invalidate();
        }

        /// <summary>
        /// This function is the paint function for the line drawing
        /// </summary>
        private void PlateauPlotPanel_Line_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Draw lines between each two consecutive points
            for (int i = 0; i < SortedPoints.Count - 1; i++)
            {
                gPts P1 = new gPts();
                gPts P2 = new gPts();
                P1 = FindPixelCoord((System.Drawing.Point)SortedPoints[i]);
                P2 = FindPixelCoord((System.Drawing.Point)SortedPoints[i + 1]);
                P1.X += 8;
                P1.Y += 9;
                P2.X += 8;
                P2.Y += 9;
                g.DrawLine(new System.Drawing.Pen(LINE_COLOR, 2.0f), P1.X, P1.Y, P2.X, P2.Y);
            }
        }

        /// <summary>
        ///  This function will calculate the pixel coordinates of a data point
        /// </summary>
        /// <param name="point">Data point to be plotted</param>
        /// <returns>Point with new coordinates</returns>
        private gPts FindPixelCoord(System.Drawing.Point point)
        {
            gPts temp = new gPts();
            temp.X = point.X;
            temp.Y = point.Y;

            // Get actual Pixel coordinate from plot coordinate
            temp.X *= 4; // there are four pixels per decibel on the X axis
            temp.X += this.PlotArea.Location.X; // account for location offset
            temp.Y -= minThresholdLvl; // subtract off min Threshold level
            temp.Y *= 5; // there are 50 pixels every 10 db in the Y axis
            temp.Y = 376 - temp.Y; // min threshold on Y is at pixel 376

            // Adjust the Fudge Factor
            //			temp.X += 4;
            temp.Y -= 7;

            return temp;
        }

        /// <summary>
        ///  This function removes the most recently ADDED point, not the highest X point
        /// </summary>
        public void RemoveRecentPoint()
        {
            // Remove last point
            if (this.PlottedPoints.Count <= 0) return;
            this.PlottedPoints.RemoveAt(this.PlottedPoints.Count - 1);

            // Draw the points
            this.Paint += new PaintEventHandler(PlateauPlotPanel_Paint);
            if (this.SortedPoints.Count > 0) ConnectPoints();
            this.PlotArea.Invalidate();
        }

        private void PlotArea_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label0_Click(object sender, EventArgs e)
        {

        }

        private void Plateau_Panel(object sender, EventArgs e)
        {

        }

        public Virtual_Lab.VirtualLabToplevel MdiParent { get; set; }
    }
}
