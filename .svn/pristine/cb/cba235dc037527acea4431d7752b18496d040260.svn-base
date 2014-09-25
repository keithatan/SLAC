using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Audiogram_Dev;
using System.Resources;
using Virtual_Lab;


namespace Audiogram_Dev
{
    /// <summary>
    /// </summary>
    public class AudiogramPanel : System.Windows.Forms.Panel
    {

        // delete me (click me button)
        public Patient.Patient patient;
        private char[] clickme;
        // end delete me
        public Virtual_Lab.VirtualLabToplevel vltl;
        public const int MAX_ARRAY = 100;

        public const byte LeftEar = 0x0;
        public const byte RightEar = 0x1;
        public const byte BoneTrans = 0x0;
        public const byte AirTrans = 0x2;
        public const byte Unmasked = 0x0;
        public const byte Masked = 0x4;
        public const byte Response = 0x0;
        public const byte NoResponse = 0x8;

        public enum SymbolType
        {
            LeftAir = LeftEar | AirTrans | Unmasked | Response,
            LeftBone = LeftEar | BoneTrans | Unmasked | Response,
            LeftAirMasked = LeftEar | AirTrans | Masked | Response,
            LeftBoneMasked = LeftEar | BoneTrans | Masked | Response,
            LeftBoneNR = LeftEar | BoneTrans | Unmasked | NoResponse,
            LeftBoneMaskedNR = LeftEar | BoneTrans | Masked | NoResponse,
            LeftNoResponse = LeftEar | NoResponse,

            RightAir = RightEar | AirTrans | Unmasked | Response,
            RightBone = RightEar | BoneTrans | Unmasked | Response,
            RightAirMasked = RightEar | AirTrans | Masked | Response,
            RightBoneMasked = RightEar | BoneTrans | Masked | Response,
            RightBoneNR = RightEar | BoneTrans | Unmasked | NoResponse,
            RightBoneMaskedNR = RightEar | BoneTrans | Masked | NoResponse,
            RightNoResponse = RightEar | NoResponse,

            //Aided = 15,
            //SoundField = 16
        }
        public struct CursorArray
        {
            public int PointsUsed;
            public SymbolType[] Symbols;
            public Point[] Points;
        }

        private System.ComponentModel.IContainer components;

        //for local Audiogram functionality
        public CursorArray UserCursors;
        //protected System.Drawing.Point[] UserCursors.Points;
        //public SymbolType[] cursor_Array;
        // protected int ptsUsed;		
        protected SymbolType CurrentSymbol;
        public const int MAX_MASKS = 24;
        public int[] MaskArray;

        //for pathology
        //public SymbolType[] patho_cursorArray;
        //public System.Drawing.Point[] patho_UserCursors.Points;
        //public int patho_ptsUsed;
        public CursorArray PathologyCursors;
        private int zero_x;
        private int zero_y;
        private int true_x;
        private int true_y;

        //shared
        //public string cursor;
        public bool clickok;
        //private System.Drawing.Color rgb;

        private System.Windows.Forms.Panel boundingBox;
        private System.Windows.Forms.Button btnRightAir;
        private System.Windows.Forms.Label lblLeft;
        private System.Windows.Forms.Label lblRight;
        private System.Windows.Forms.Button btnLeftAir;
        private System.Windows.Forms.Button btnRightBone;
        private System.Windows.Forms.Button btnLeftBone;
        private System.Windows.Forms.Label lblAC;
        private System.Windows.Forms.Label lblBC;
        private System.Windows.Forms.Button btnRightAirMasked;
        private System.Windows.Forms.Button btnLeftAirMasked;
        private System.Windows.Forms.Label lblMAC;
        private System.Windows.Forms.Button btnLeftBoneMasked;
        private System.Windows.Forms.Button btnRightBoneMasked;
        private System.Windows.Forms.Label lblMB;
        private System.Windows.Forms.Label lblNR;
        private System.Windows.Forms.Button btnLeftNoResponse;
        private System.Windows.Forms.Button btnRightNoResponse;
        private System.Windows.Forms.Button Sound_field;
        private System.Windows.Forms.Button Aided;
        private System.Windows.Forms.Label lblSoundField;
        private System.Windows.Forms.Label lblAided;
        private System.Windows.Forms.Label lblUCL;
        private System.Windows.Forms.Button UCL_L;
        private System.Windows.Forms.Button UCL_R;

        public System.Windows.Forms.TextBox txtRMaskAC250;
        public System.Windows.Forms.TextBox txtLMaskAC250;
        public System.Windows.Forms.TextBox txtRMaskBC250;
        public System.Windows.Forms.TextBox txtLMaskBC250;
        public System.Windows.Forms.TextBox txtLMaskBC500;
        public System.Windows.Forms.TextBox txtRMaskBC500;
        public System.Windows.Forms.TextBox txtLMaskAC500;
        public System.Windows.Forms.TextBox txtRMaskAC500;
        public System.Windows.Forms.TextBox txtLMaskBC1000;
        public System.Windows.Forms.TextBox txtRMaskBC1000;
        public System.Windows.Forms.TextBox txtLMaskAC1000;
        public System.Windows.Forms.TextBox txtRMaskAC1000;
        public System.Windows.Forms.TextBox txtLMaskBC2000;
        public System.Windows.Forms.TextBox txtRMaskBC2000;
        public System.Windows.Forms.TextBox txtLMaskAC2000;
        public System.Windows.Forms.TextBox txtRMaskAC2000;
        public System.Windows.Forms.TextBox txtLMaskBC4000;
        public System.Windows.Forms.TextBox txtRMaskBC4000;
        public System.Windows.Forms.TextBox txtLMaskAC4000;
        public System.Windows.Forms.TextBox txtRMaskAC4000;
        public System.Windows.Forms.TextBox txtRMaskAC8000;
        public System.Windows.Forms.TextBox txtLMaskBC8000;
        public System.Windows.Forms.TextBox txtRMaskBC8000;
        public System.Windows.Forms.TextBox txtLMaskAC8000;
        private const int MIN_X = 0;
        private const int MAX_X = 569;
        private const int MIN_Y = 0;
        private const int MAX_Y = 570;
        private const int FONT_SIZE = 11;
        private const int NumYGrids = 28;
        private const int NumXGrids = 12;
        private const int SpecialMinX = 55;
        private const int SpecialMaxX = 464;
        private System.Windows.Forms.ToolTip ttCoord;
        private System.Windows.Forms.Button btnSpeechAudiometry;
        public SpeechAudiometry SpAudInput;
        private Button button1;

        Point globalPts = new Point();

        /// <summary>
        /// Default Constructor
        /// </summary>
        public AudiogramPanel()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //			

            UserCursors.Symbols = new SymbolType[MAX_ARRAY];
            UserCursors.Points = new Point[MAX_ARRAY];
            UserCursors.PointsUsed = 0;

            PathologyCursors.Symbols = new SymbolType[MAX_ARRAY];
            PathologyCursors.Points = new Point[MAX_ARRAY];
            PathologyCursors.PointsUsed = 0;

            //UserCursors.Points = new System.Drawing.Point[MAX_ARRAY];
            //cursor_Array = new SymbolType[MAX_ARRAY];
            //patho_UserCursors.Points = new System.Drawing.Point[MAX_ARRAY];
            //patho_cursorArray = new SymbolType[MAX_ARRAY];
            MaskArray = new int[MAX_MASKS];
            //ptsUsed = 0;
            //patho_ptsUsed = 0;
            CurrentSymbol = SymbolType.RightAir;
            //cursor = "O";
            clickok = false;
            ttCoord = new ToolTip();
            ttCoord.ShowAlways = true;
            SpAudInput = new SpeechAudiometry();

            // delete me (click me button)
            clickme = new char[8];
            // end delete me
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Audiogram));
            this.boundingBox = new System.Windows.Forms.Panel();
            this.txtLMaskBC8000 = new System.Windows.Forms.TextBox();
            this.txtRMaskBC8000 = new System.Windows.Forms.TextBox();
            this.txtLMaskAC8000 = new System.Windows.Forms.TextBox();
            this.txtRMaskAC8000 = new System.Windows.Forms.TextBox();
            this.txtLMaskBC4000 = new System.Windows.Forms.TextBox();
            this.txtRMaskBC4000 = new System.Windows.Forms.TextBox();
            this.txtLMaskAC4000 = new System.Windows.Forms.TextBox();
            this.txtRMaskAC4000 = new System.Windows.Forms.TextBox();
            this.txtLMaskBC2000 = new System.Windows.Forms.TextBox();
            this.txtRMaskBC2000 = new System.Windows.Forms.TextBox();
            this.txtLMaskAC2000 = new System.Windows.Forms.TextBox();
            this.txtRMaskAC2000 = new System.Windows.Forms.TextBox();
            this.txtLMaskBC1000 = new System.Windows.Forms.TextBox();
            this.txtRMaskBC1000 = new System.Windows.Forms.TextBox();
            this.txtLMaskAC1000 = new System.Windows.Forms.TextBox();
            this.txtRMaskAC1000 = new System.Windows.Forms.TextBox();
            this.txtLMaskBC500 = new System.Windows.Forms.TextBox();
            this.txtRMaskBC500 = new System.Windows.Forms.TextBox();
            this.txtLMaskAC500 = new System.Windows.Forms.TextBox();
            this.txtRMaskAC500 = new System.Windows.Forms.TextBox();
            this.txtLMaskBC250 = new System.Windows.Forms.TextBox();
            this.txtRMaskBC250 = new System.Windows.Forms.TextBox();
            this.txtLMaskAC250 = new System.Windows.Forms.TextBox();
            this.txtRMaskAC250 = new System.Windows.Forms.TextBox();
            this.btnRightAir = new System.Windows.Forms.Button();
            this.lblLeft = new System.Windows.Forms.Label();
            this.lblRight = new System.Windows.Forms.Label();
            this.btnLeftAir = new System.Windows.Forms.Button();
            this.btnRightBone = new System.Windows.Forms.Button();
            this.btnLeftBone = new System.Windows.Forms.Button();
            this.lblAC = new System.Windows.Forms.Label();
            this.lblBC = new System.Windows.Forms.Label();
            this.btnRightAirMasked = new System.Windows.Forms.Button();
            this.btnLeftAirMasked = new System.Windows.Forms.Button();
            this.lblMAC = new System.Windows.Forms.Label();
            this.btnLeftBoneMasked = new System.Windows.Forms.Button();
            this.btnRightBoneMasked = new System.Windows.Forms.Button();
            this.lblMB = new System.Windows.Forms.Label();
            this.lblNR = new System.Windows.Forms.Label();
            this.btnLeftNoResponse = new System.Windows.Forms.Button();
            this.btnRightNoResponse = new System.Windows.Forms.Button();
            this.Sound_field = new System.Windows.Forms.Button();
            this.Aided = new System.Windows.Forms.Button();
            this.lblSoundField = new System.Windows.Forms.Label();
            this.lblAided = new System.Windows.Forms.Label();
            this.lblUCL = new System.Windows.Forms.Label();
            this.UCL_L = new System.Windows.Forms.Button();
            this.UCL_R = new System.Windows.Forms.Button();
            this.ttCoord = new System.Windows.Forms.ToolTip(this.components);
            this.btnSpeechAudiometry = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.boundingBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // boundingBox
            // 
            this.boundingBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.boundingBox.BackColor = System.Drawing.Color.Transparent;
            this.boundingBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.boundingBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boundingBox.Controls.Add(this.txtLMaskBC8000);
            this.boundingBox.Controls.Add(this.txtRMaskBC8000);
            this.boundingBox.Controls.Add(this.txtLMaskAC8000);
            this.boundingBox.Controls.Add(this.txtRMaskAC8000);
            this.boundingBox.Controls.Add(this.txtLMaskBC4000);
            this.boundingBox.Controls.Add(this.txtRMaskBC4000);
            this.boundingBox.Controls.Add(this.txtLMaskAC4000);
            this.boundingBox.Controls.Add(this.txtRMaskAC4000);
            this.boundingBox.Controls.Add(this.txtLMaskBC2000);
            this.boundingBox.Controls.Add(this.txtRMaskBC2000);
            this.boundingBox.Controls.Add(this.txtLMaskAC2000);
            this.boundingBox.Controls.Add(this.txtRMaskAC2000);
            this.boundingBox.Controls.Add(this.txtLMaskBC1000);
            this.boundingBox.Controls.Add(this.txtRMaskBC1000);
            this.boundingBox.Controls.Add(this.txtLMaskAC1000);
            this.boundingBox.Controls.Add(this.txtRMaskAC1000);
            this.boundingBox.Controls.Add(this.txtLMaskBC500);
            this.boundingBox.Controls.Add(this.txtRMaskBC500);
            this.boundingBox.Controls.Add(this.txtLMaskAC500);
            this.boundingBox.Controls.Add(this.txtRMaskAC500);
            this.boundingBox.Controls.Add(this.txtLMaskBC250);
            this.boundingBox.Controls.Add(this.txtRMaskBC250);
            this.boundingBox.Controls.Add(this.txtLMaskAC250);
            this.boundingBox.Controls.Add(this.txtRMaskAC250);
            this.boundingBox.ForeColor = System.Drawing.Color.Transparent;
            this.boundingBox.Location = new System.Drawing.Point(0, 0);
            this.boundingBox.Name = "boundingBox";
            this.boundingBox.Size = new System.Drawing.Size(514, 235);
            this.boundingBox.Size = Utils.CalculateResizeToFit(this.ClientSize, this.boundingBox.Size);
            this.boundingBox.TabIndex = 0;
            this.boundingBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Graph_MouseDown);
            this.boundingBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.boundingBox_MouseMove);
            // 
            // txtLMaskBC8000
            // 
            this.txtLMaskBC8000.Location = new System.Drawing.Point(497, 32);
            this.txtLMaskBC8000.Name = "txtLMaskBC8000";
            this.txtLMaskBC8000.Size = new System.Drawing.Size(31, 20);
            this.txtLMaskBC8000.TabIndex = 23;
            this.txtLMaskBC8000.Text = "0";
            // 
            // txtRMaskBC8000
            // 
            this.txtRMaskBC8000.Location = new System.Drawing.Point(466, 32);
            this.txtRMaskBC8000.Name = "txtRMaskBC8000";
            this.txtRMaskBC8000.Size = new System.Drawing.Size(31, 20);
            this.txtRMaskBC8000.TabIndex = 22;
            this.txtRMaskBC8000.Text = "0";
            // 
            // txtLMaskAC8000
            // 
            this.txtLMaskAC8000.Location = new System.Drawing.Point(497, 11);
            this.txtLMaskAC8000.Name = "txtLMaskAC8000";
            this.txtLMaskAC8000.Size = new System.Drawing.Size(31, 20);
            this.txtLMaskAC8000.TabIndex = 21;
            this.txtLMaskAC8000.Text = "0";
            // 
            // txtRMaskAC8000
            // 
            this.txtRMaskAC8000.Location = new System.Drawing.Point(466, 11);
            this.txtRMaskAC8000.Name = "txtRMaskAC8000";
            this.txtRMaskAC8000.Size = new System.Drawing.Size(31, 20);
            this.txtRMaskAC8000.TabIndex = 20;
            this.txtRMaskAC8000.Text = "0";
            // 
            // txtLMaskBC4000
            // 
            this.txtLMaskBC4000.Location = new System.Drawing.Point(435, 32);
            this.txtLMaskBC4000.Name = "txtLMaskBC4000";
            this.txtLMaskBC4000.Size = new System.Drawing.Size(31, 20);
            this.txtLMaskBC4000.TabIndex = 19;
            this.txtLMaskBC4000.Text = "0";
            // 
            // txtRMaskBC4000
            // 
            this.txtRMaskBC4000.Location = new System.Drawing.Point(404, 32);
            this.txtRMaskBC4000.Name = "txtRMaskBC4000";
            this.txtRMaskBC4000.Size = new System.Drawing.Size(31, 20);
            this.txtRMaskBC4000.TabIndex = 18;
            this.txtRMaskBC4000.Text = "0";
            // 
            // txtLMaskAC4000
            // 
            this.txtLMaskAC4000.Location = new System.Drawing.Point(435, 11);
            this.txtLMaskAC4000.Name = "txtLMaskAC4000";
            this.txtLMaskAC4000.Size = new System.Drawing.Size(31, 20);
            this.txtLMaskAC4000.TabIndex = 17;
            this.txtLMaskAC4000.Text = "0";
            // 
            // txtRMaskAC4000
            // 
            this.txtRMaskAC4000.Location = new System.Drawing.Point(404, 11);
            this.txtRMaskAC4000.Name = "txtRMaskAC4000";
            this.txtRMaskAC4000.Size = new System.Drawing.Size(31, 20);
            this.txtRMaskAC4000.TabIndex = 16;
            this.txtRMaskAC4000.Text = "0";
            // 
            // txtLMaskBC2000
            // 
            this.txtLMaskBC2000.Location = new System.Drawing.Point(373, 32);
            this.txtLMaskBC2000.Name = "txtLMaskBC2000";
            this.txtLMaskBC2000.Size = new System.Drawing.Size(31, 20);
            this.txtLMaskBC2000.TabIndex = 15;
            this.txtLMaskBC2000.Text = "0";
            // 
            // txtRMaskBC2000
            // 
            this.txtRMaskBC2000.Location = new System.Drawing.Point(342, 32);
            this.txtRMaskBC2000.Name = "txtRMaskBC2000";
            this.txtRMaskBC2000.Size = new System.Drawing.Size(31, 20);
            this.txtRMaskBC2000.TabIndex = 14;
            this.txtRMaskBC2000.Text = "0";
            // 
            // txtLMaskAC2000
            // 
            this.txtLMaskAC2000.Location = new System.Drawing.Point(373, 11);
            this.txtLMaskAC2000.Name = "txtLMaskAC2000";
            this.txtLMaskAC2000.Size = new System.Drawing.Size(31, 20);
            this.txtLMaskAC2000.TabIndex = 13;
            this.txtLMaskAC2000.Text = "0";
            // 
            // txtRMaskAC2000
            // 
            this.txtRMaskAC2000.Location = new System.Drawing.Point(342, 11);
            this.txtRMaskAC2000.Name = "txtRMaskAC2000";
            this.txtRMaskAC2000.Size = new System.Drawing.Size(31, 20);
            this.txtRMaskAC2000.TabIndex = 12;
            this.txtRMaskAC2000.Text = "0";
            // 
            // txtLMaskBC1000
            // 
            this.txtLMaskBC1000.Location = new System.Drawing.Point(311, 32);
            this.txtLMaskBC1000.Name = "txtLMaskBC1000";
            this.txtLMaskBC1000.Size = new System.Drawing.Size(31, 20);
            this.txtLMaskBC1000.TabIndex = 11;
            this.txtLMaskBC1000.Text = "0";
            // 
            // txtRMaskBC1000
            // 
            this.txtRMaskBC1000.Location = new System.Drawing.Point(280, 32);
            this.txtRMaskBC1000.Name = "txtRMaskBC1000";
            this.txtRMaskBC1000.Size = new System.Drawing.Size(31, 20);
            this.txtRMaskBC1000.TabIndex = 10;
            this.txtRMaskBC1000.Text = "0";
            // 
            // txtLMaskAC1000
            // 
            this.txtLMaskAC1000.Location = new System.Drawing.Point(311, 11);
            this.txtLMaskAC1000.Name = "txtLMaskAC1000";
            this.txtLMaskAC1000.Size = new System.Drawing.Size(31, 20);
            this.txtLMaskAC1000.TabIndex = 9;
            this.txtLMaskAC1000.Text = "0";
            // 
            // txtRMaskAC1000
            // 
            this.txtRMaskAC1000.Location = new System.Drawing.Point(280, 11);
            this.txtRMaskAC1000.Name = "txtRMaskAC1000";
            this.txtRMaskAC1000.Size = new System.Drawing.Size(31, 20);
            this.txtRMaskAC1000.TabIndex = 8;
            this.txtRMaskAC1000.Text = "0";
            // 
            // txtLMaskBC500
            // 
            this.txtLMaskBC500.Location = new System.Drawing.Point(249, 32);
            this.txtLMaskBC500.Name = "txtLMaskBC500";
            this.txtLMaskBC500.Size = new System.Drawing.Size(31, 20);
            this.txtLMaskBC500.TabIndex = 7;
            this.txtLMaskBC500.Text = "0";
            // 
            // txtRMaskBC500
            // 
            this.txtRMaskBC500.Location = new System.Drawing.Point(218, 32);
            this.txtRMaskBC500.Name = "txtRMaskBC500";
            this.txtRMaskBC500.Size = new System.Drawing.Size(31, 20);
            this.txtRMaskBC500.TabIndex = 6;
            this.txtRMaskBC500.Text = "0";
            // 
            // txtLMaskAC500
            // 
            this.txtLMaskAC500.Location = new System.Drawing.Point(249, 11);
            this.txtLMaskAC500.Name = "txtLMaskAC500";
            this.txtLMaskAC500.Size = new System.Drawing.Size(31, 20);
            this.txtLMaskAC500.TabIndex = 5;
            this.txtLMaskAC500.Text = "0";
            // 
            // txtRMaskAC500
            // 
            this.txtRMaskAC500.Location = new System.Drawing.Point(218, 11);
            this.txtRMaskAC500.Name = "txtRMaskAC500";
            this.txtRMaskAC500.Size = new System.Drawing.Size(31, 20);
            this.txtRMaskAC500.TabIndex = 4;
            this.txtRMaskAC500.Text = "0";
            // 
            // txtLMaskBC250
            // 
            this.txtLMaskBC250.Location = new System.Drawing.Point(187, 32);
            this.txtLMaskBC250.Name = "txtLMaskBC250";
            this.txtLMaskBC250.Size = new System.Drawing.Size(31, 20);
            this.txtLMaskBC250.TabIndex = 3;
            this.txtLMaskBC250.Text = "0";
            // 
            // txtRMaskBC250
            // 
            this.txtRMaskBC250.Location = new System.Drawing.Point(156, 32);
            this.txtRMaskBC250.Name = "txtRMaskBC250";
            this.txtRMaskBC250.Size = new System.Drawing.Size(31, 20);
            this.txtRMaskBC250.TabIndex = 2;
            this.txtRMaskBC250.Text = "0";
            this.txtRMaskBC250.TextChanged += new System.EventHandler(this.txtRMaskBC250_TextChanged);
            // 
            // txtLMaskAC250
            // 
            this.txtLMaskAC250.Location = new System.Drawing.Point(187, 11);
            this.txtLMaskAC250.Name = "txtLMaskAC250";
            this.txtLMaskAC250.Size = new System.Drawing.Size(31, 20);
            this.txtLMaskAC250.TabIndex = 1;
            this.txtLMaskAC250.Text = "0";
            // 
            // txtRMaskAC250
            // 
            this.txtRMaskAC250.Location = new System.Drawing.Point(156, 11);
            this.txtRMaskAC250.Name = "txtRMaskAC250";
            this.txtRMaskAC250.Size = new System.Drawing.Size(31, 20);
            this.txtRMaskAC250.TabIndex = 0;
            this.txtRMaskAC250.Text = "0";
            this.txtRMaskAC250.TextChanged += new System.EventHandler(this.txtRMaskAC250_TextChanged);
            this.txtRMaskAC250.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRMask1_KeyPress);
            // 
            // btnRightAir
            // 
            this.btnRightAir.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnRightAir.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRightAir.ForeColor = System.Drawing.Color.Red;
            this.btnRightAir.Location = new System.Drawing.Point(55, 508);
            this.btnRightAir.Name = "btnRightAir";
            this.btnRightAir.Size = new System.Drawing.Size(30, 23);
            this.btnRightAir.TabIndex = 1;
            this.btnRightAir.Text = "O";
            this.btnRightAir.UseVisualStyleBackColor = false;
            this.btnRightAir.Click += new System.EventHandler(this.AC_Right_Click);
            // 
            // lblLeft
            // 
            this.lblLeft.AutoSize = true;
            this.lblLeft.BackColor = System.Drawing.Color.Transparent;
            this.lblLeft.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeft.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblLeft.Location = new System.Drawing.Point(16, 539);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(33, 14);
            this.lblLeft.TabIndex = 5;
            this.lblLeft.Text = "LEFT";
            // 
            // lblRight
            // 
            this.lblRight.AutoSize = true;
            this.lblRight.BackColor = System.Drawing.Color.Transparent;
            this.lblRight.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRight.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblRight.Location = new System.Drawing.Point(10, 512);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(39, 14);
            this.lblRight.TabIndex = 6;
            this.lblRight.Text = "RIGHT";
            // 
            // btnLeftAir
            // 
            this.btnLeftAir.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnLeftAir.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftAir.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnLeftAir.Location = new System.Drawing.Point(55, 535);
            this.btnLeftAir.Name = "btnLeftAir";
            this.btnLeftAir.Size = new System.Drawing.Size(30, 23);
            this.btnLeftAir.TabIndex = 7;
            this.btnLeftAir.Text = "X";
            this.btnLeftAir.UseVisualStyleBackColor = false;
            this.btnLeftAir.Click += new System.EventHandler(this.AC_Left_Click);
            // 
            // btnRightBone
            // 
            this.btnRightBone.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnRightBone.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRightBone.ForeColor = System.Drawing.Color.Red;
            this.btnRightBone.Location = new System.Drawing.Point(94, 508);
            this.btnRightBone.Name = "btnRightBone";
            this.btnRightBone.Size = new System.Drawing.Size(30, 23);
            this.btnRightBone.TabIndex = 8;
            this.btnRightBone.Text = "<";
            this.btnRightBone.UseVisualStyleBackColor = false;
            this.btnRightBone.Click += new System.EventHandler(this.BC_Right_Click);
            // 
            // btnLeftBone
            // 
            this.btnLeftBone.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnLeftBone.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftBone.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnLeftBone.Location = new System.Drawing.Point(94, 535);
            this.btnLeftBone.Name = "btnLeftBone";
            this.btnLeftBone.Size = new System.Drawing.Size(30, 23);
            this.btnLeftBone.TabIndex = 9;
            this.btnLeftBone.Text = ">";
            this.btnLeftBone.UseVisualStyleBackColor = false;
            this.btnLeftBone.Click += new System.EventHandler(this.BC_Left_Click);
            // 
            // lblAC
            // 
            this.lblAC.AutoSize = true;
            this.lblAC.BackColor = System.Drawing.Color.Transparent;
            this.lblAC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAC.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblAC.Location = new System.Drawing.Point(59, 491);
            this.lblAC.Name = "lblAC";
            this.lblAC.Size = new System.Drawing.Size(23, 14);
            this.lblAC.TabIndex = 10;
            this.lblAC.Text = "AC";
            // 
            // lblBC
            // 
            this.lblBC.AutoSize = true;
            this.lblBC.BackColor = System.Drawing.Color.Transparent;
            this.lblBC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBC.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblBC.Location = new System.Drawing.Point(98, 491);
            this.lblBC.Name = "lblBC";
            this.lblBC.Size = new System.Drawing.Size(22, 14);
            this.lblBC.TabIndex = 11;
            this.lblBC.Text = "BC";
            // 
            // btnRightAirMasked
            // 
            this.btnRightAirMasked.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnRightAirMasked.Font = new System.Drawing.Font("Wingdings 3", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnRightAirMasked.ForeColor = System.Drawing.Color.Red;
            this.btnRightAirMasked.Location = new System.Drawing.Point(134, 508);
            this.btnRightAirMasked.Name = "btnRightAirMasked";
            this.btnRightAirMasked.Size = new System.Drawing.Size(30, 23);
            this.btnRightAirMasked.TabIndex = 16;
            this.btnRightAirMasked.Text = "r";
            this.btnRightAirMasked.UseVisualStyleBackColor = false;
            this.btnRightAirMasked.Click += new System.EventHandler(this.MAC_Right_Click);
            // 
            // btnLeftAirMasked
            // 
            this.btnLeftAirMasked.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnLeftAirMasked.Font = new System.Drawing.Font("Wingdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnLeftAirMasked.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnLeftAirMasked.Location = new System.Drawing.Point(134, 535);
            this.btnLeftAirMasked.Name = "btnLeftAirMasked";
            this.btnLeftAirMasked.Size = new System.Drawing.Size(30, 23);
            this.btnLeftAirMasked.TabIndex = 17;
            this.btnLeftAirMasked.Text = "¨";
            this.btnLeftAirMasked.UseVisualStyleBackColor = false;
            this.btnLeftAirMasked.Click += new System.EventHandler(this.Mac_Left_Click);
            // 
            // lblMAC
            // 
            this.lblMAC.AutoSize = true;
            this.lblMAC.BackColor = System.Drawing.Color.Transparent;
            this.lblMAC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMAC.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblMAC.Location = new System.Drawing.Point(131, 491);
            this.lblMAC.Name = "lblMAC";
            this.lblMAC.Size = new System.Drawing.Size(36, 14);
            this.lblMAC.TabIndex = 18;
            this.lblMAC.Text = "M.AC";
            // 
            // btnLeftBoneMasked
            // 
            this.btnLeftBoneMasked.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnLeftBoneMasked.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftBoneMasked.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnLeftBoneMasked.Location = new System.Drawing.Point(174, 535);
            this.btnLeftBoneMasked.Name = "btnLeftBoneMasked";
            this.btnLeftBoneMasked.Size = new System.Drawing.Size(30, 23);
            this.btnLeftBoneMasked.TabIndex = 20;
            this.btnLeftBoneMasked.Text = "]";
            this.btnLeftBoneMasked.UseVisualStyleBackColor = false;
            this.btnLeftBoneMasked.Click += new System.EventHandler(this.MBC_Left_Click);
            // 
            // btnRightBoneMasked
            // 
            this.btnRightBoneMasked.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnRightBoneMasked.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRightBoneMasked.ForeColor = System.Drawing.Color.Red;
            this.btnRightBoneMasked.Location = new System.Drawing.Point(174, 508);
            this.btnRightBoneMasked.Name = "btnRightBoneMasked";
            this.btnRightBoneMasked.Size = new System.Drawing.Size(30, 23);
            this.btnRightBoneMasked.TabIndex = 19;
            this.btnRightBoneMasked.Text = "[";
            this.btnRightBoneMasked.UseVisualStyleBackColor = false;
            this.btnRightBoneMasked.Click += new System.EventHandler(this.MBC_Right_Click);
            // 
            // lblMB
            // 
            this.lblMB.AutoSize = true;
            this.lblMB.BackColor = System.Drawing.Color.Transparent;
            this.lblMB.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMB.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblMB.Location = new System.Drawing.Point(172, 491);
            this.lblMB.Name = "lblMB";
            this.lblMB.Size = new System.Drawing.Size(35, 14);
            this.lblMB.TabIndex = 21;
            this.lblMB.Text = "M.BC";
            // 
            // lblNR
            // 
            this.lblNR.AutoSize = true;
            this.lblNR.BackColor = System.Drawing.Color.Transparent;
            this.lblNR.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNR.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblNR.Location = new System.Drawing.Point(219, 491);
            this.lblNR.Name = "lblNR";
            this.lblNR.Size = new System.Drawing.Size(21, 14);
            this.lblNR.TabIndex = 22;
            this.lblNR.Text = "NR";
            // 
            // btnLeftNoResponse
            // 
            this.btnLeftNoResponse.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnLeftNoResponse.Font = new System.Drawing.Font("Wingdings 3", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnLeftNoResponse.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnLeftNoResponse.Location = new System.Drawing.Point(214, 535);
            this.btnLeftNoResponse.Name = "btnLeftNoResponse";
            this.btnLeftNoResponse.Size = new System.Drawing.Size(30, 23);
            this.btnLeftNoResponse.TabIndex = 24;
            this.btnLeftNoResponse.Text = "m";
            this.btnLeftNoResponse.UseVisualStyleBackColor = false;
            this.btnLeftNoResponse.Click += new System.EventHandler(this.NoResp_Left_Click);
            // 
            // btnRightNoResponse
            // 
            this.btnRightNoResponse.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnRightNoResponse.Font = new System.Drawing.Font("Wingdings 3", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnRightNoResponse.ForeColor = System.Drawing.Color.Red;
            this.btnRightNoResponse.Location = new System.Drawing.Point(214, 508);
            this.btnRightNoResponse.Name = "btnRightNoResponse";
            this.btnRightNoResponse.Size = new System.Drawing.Size(30, 23);
            this.btnRightNoResponse.TabIndex = 23;
            this.btnRightNoResponse.Text = "l";
            this.btnRightNoResponse.UseVisualStyleBackColor = false;
            this.btnRightNoResponse.Click += new System.EventHandler(this.NoResp_Right_Click);
            // 
            // Sound_field
            // 
            this.Sound_field.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Sound_field.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sound_field.ForeColor = System.Drawing.Color.Red;
            this.Sound_field.Location = new System.Drawing.Point(306, 535);
            this.Sound_field.Name = "Sound_field";
            this.Sound_field.Size = new System.Drawing.Size(20, 23);
            this.Sound_field.TabIndex = 25;
            this.Sound_field.Text = "S";
            this.Sound_field.UseVisualStyleBackColor = false;
            this.Sound_field.Visible = false;
            this.Sound_field.Click += new System.EventHandler(this.Sound_field_Click);
            // 
            // Aided
            // 
            this.Aided.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Aided.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Aided.ForeColor = System.Drawing.Color.Red;
            this.Aided.Location = new System.Drawing.Point(306, 508);
            this.Aided.Name = "Aided";
            this.Aided.Size = new System.Drawing.Size(20, 23);
            this.Aided.TabIndex = 26;
            this.Aided.Text = "A";
            this.Aided.UseVisualStyleBackColor = false;
            this.Aided.Visible = false;
            this.Aided.Click += new System.EventHandler(this.Aided_Click);
            // 
            // lblSoundField
            // 
            this.lblSoundField.AutoSize = true;
            this.lblSoundField.BackColor = System.Drawing.Color.Transparent;
            this.lblSoundField.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoundField.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblSoundField.Location = new System.Drawing.Point(333, 539);
            this.lblSoundField.Name = "lblSoundField";
            this.lblSoundField.Size = new System.Drawing.Size(71, 14);
            this.lblSoundField.TabIndex = 27;
            this.lblSoundField.Text = "Sound Field";
            this.lblSoundField.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSoundField.Visible = false;
            // 
            // lblAided
            // 
            this.lblAided.AutoSize = true;
            this.lblAided.BackColor = System.Drawing.Color.Transparent;
            this.lblAided.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAided.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblAided.Location = new System.Drawing.Point(333, 512);
            this.lblAided.Name = "lblAided";
            this.lblAided.Size = new System.Drawing.Size(39, 14);
            this.lblAided.TabIndex = 28;
            this.lblAided.Text = "Aided";
            this.lblAided.Visible = false;
            // 
            // lblUCL
            // 
            this.lblUCL.AutoSize = true;
            this.lblUCL.BackColor = System.Drawing.Color.Transparent;
            this.lblUCL.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUCL.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblUCL.Location = new System.Drawing.Point(255, 491);
            this.lblUCL.Name = "lblUCL";
            this.lblUCL.Size = new System.Drawing.Size(29, 14);
            this.lblUCL.TabIndex = 29;
            this.lblUCL.Text = "UCL";
            this.lblUCL.Visible = false;
            // 
            // UCL_L
            // 
            this.UCL_L.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.UCL_L.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UCL_L.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.UCL_L.Location = new System.Drawing.Point(254, 508);
            this.UCL_L.Name = "UCL_L";
            this.UCL_L.Size = new System.Drawing.Size(30, 23);
            this.UCL_L.TabIndex = 31;
            this.UCL_L.Text = "UL";
            this.UCL_L.UseVisualStyleBackColor = false;
            this.UCL_L.Visible = false;
            this.UCL_L.Click += new System.EventHandler(this.UCL_L_Click);
            // 
            // UCL_R
            // 
            this.UCL_R.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.UCL_R.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UCL_R.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.UCL_R.Location = new System.Drawing.Point(254, 535);
            this.UCL_R.Name = "UCL_R";
            this.UCL_R.Size = new System.Drawing.Size(30, 23);
            this.UCL_R.TabIndex = 30;
            this.UCL_R.Text = "UR";
            this.UCL_R.UseVisualStyleBackColor = false;
            this.UCL_R.Visible = false;
            this.UCL_R.Click += new System.EventHandler(this.UCL_R_Click);
            // 
            // btnSpeechAudiometry
            // 
            this.btnSpeechAudiometry.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSpeechAudiometry.Location = new System.Drawing.Point(395, 494);
            this.btnSpeechAudiometry.Name = "btnSpeechAudiometry";
            this.btnSpeechAudiometry.Size = new System.Drawing.Size(87, 37);
            this.btnSpeechAudiometry.TabIndex = 32;
            this.btnSpeechAudiometry.Text = "Show Speech Audiometry";
            this.btnSpeechAudiometry.Click += new System.EventHandler(this.cmdSpeechAudiometry_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(407, 535);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 22);
            this.button1.TabIndex = 33;
            this.button1.Text = "Click Me!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Audiogram
            // 
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(568, 569);
            this.Controls.Add(this.button1);
            // Speech Audiometry not currently needed.
            //this.Controls.Add(this.btnSpeechAudiometry);
            this.Controls.Add(this.UCL_L);
            this.Controls.Add(this.UCL_R);
            this.Controls.Add(this.lblUCL);
            this.Controls.Add(this.lblAided);
            this.Controls.Add(this.lblSoundField);
            this.Controls.Add(this.Aided);
            this.Controls.Add(this.Sound_field);
            this.Controls.Add(this.btnLeftNoResponse);
            this.Controls.Add(this.btnRightNoResponse);
            this.Controls.Add(this.lblNR);
            this.Controls.Add(this.lblMB);
            this.Controls.Add(this.btnLeftBoneMasked);
            this.Controls.Add(this.btnRightBoneMasked);
            this.Controls.Add(this.lblMAC);
            this.Controls.Add(this.btnLeftAirMasked);
            this.Controls.Add(this.btnRightAirMasked);
            this.Controls.Add(this.lblBC);
            this.Controls.Add(this.lblAC);
            this.Controls.Add(this.btnLeftBone);
            this.Controls.Add(this.btnRightBone);
            this.Controls.Add(this.btnLeftAir);
            this.Controls.Add(this.lblRight);
            this.Controls.Add(this.btnRightAir);
            this.Controls.Add(this.boundingBox);
            this.Controls.Add(this.lblLeft);
            this.Name = "Audiogram";
            this.Text = "Audiogram";
            //this.Load += new System.EventHandler(this.Audiogram_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Draw_User_Cursors);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AudiogramPanel_KeyPress);
            this.boundingBox.ResumeLayout(false);
            this.boundingBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        /// <summary>
        /// places pathology points into patho_ptArray & patho_cursorArray
        /// </summary>
        /// <param name="X">Frequency</param>
        /// <param name="Y">dB value</param>
        /// <param name="to_plot">Symbol of point</param>
        public void Patho_PlacePt(int X, int Y, SymbolType to_plot)
        {
            //scaling the frequency and DB to pixels
            zero_x = 89;
            zero_y = 151;
            true_x = ((int)Math.Log(X / 125, 2)) * 68 + zero_x;
            true_y = Y / 5;
            if (true_y >= -10)
            {
                true_y = (true_y + 2) * 7 + zero_y;
            }
            else
            {
                true_y = zero_y;
            }

            /* NOTE: *** for some reason if you run the .exe file and a point is plotted
            for frequency = 1000 or 8000, the cursors are drawn on the wrong places. The Math.Log
            function seems to be the problem.*/

            if (X == 1000)
            {
                true_x = 260;
            }
            if (X == 8000)
            {
                true_x = 464;
            }

            PathologyCursors.Points[PathologyCursors.PointsUsed].X = true_x - 6;
            PathologyCursors.Points[PathologyCursors.PointsUsed].Y = true_y - 6;
            //patho_UserCursors.Points[patho_ptsUsed].X = true_x-6;
            //patho_UserCursors.Points[patho_ptsUsed].Y = true_y-6;
            PathologyCursors.Symbols[PathologyCursors.PointsUsed] = to_plot;
            //patho_cursorArray[patho_ptsUsed] = to_plot;			
            PathologyCursors.PointsUsed++;
            //patho_ptsUsed++;
        }

        /// <summary>
        /// places mouse click coordinates & cursor type in UserCursors.Points & cursorArray
        /// </summary>
        /// <param name="X">Pixel Coordinate X</param>
        /// <param name="Y">Pixel Coordinate Y</param>
        public void Place_Pt(int X, int Y)
        {
            int New_C = 0, Best_C = 0, TempDist = Int32.MaxValue;

            if (UserCursors.PointsUsed >= MAX_ARRAY) return;

            // Check bounds
            if (X <= MIN_X || X >= MAX_X || Y <= MIN_Y || Y >= MAX_Y) return;

            // Snap to Y Grid
            for (int i = 0; i <= NumYGrids; i++)
            {
                New_C = MIN_Y + (MAX_Y - MIN_Y) * i / NumYGrids;
                if (TempDist > Math.Abs(New_C - Y))
                {
                    TempDist = Math.Abs(New_C - Y);
                    Best_C = New_C;
                }
            }
            UserCursors.Points[UserCursors.PointsUsed].Y = Best_C - (MAX_Y - MIN_Y) / NumYGrids / 2 - 4;

            // Snap to X Grid
            TempDist = Int32.MaxValue;
            for (int j = 0; j <= NumXGrids; j++)
            {
                // don't snap to the first two middle grids (grids 1 and 3)
                if (j == 1 || j == 3) continue;
                New_C = SpecialMinX + (SpecialMaxX - SpecialMinX) * j / NumXGrids;
                if (TempDist > Math.Abs(New_C - X))
                {
                    TempDist = Math.Abs(New_C - X);
                    Best_C = New_C;
                }
            }
            UserCursors.Points[UserCursors.PointsUsed].X = Best_C - 5; // - (SpecialMaxX-SpecialMinX)/NumXGrids/2;

            UserCursors.Symbols[UserCursors.PointsUsed] = CurrentSymbol; // Covers the if statements below...

            UserCursors.PointsUsed++;

            vltl.EvalAudiogramPanelUpdate(ConvertXCoord(X), ConvertYCoord(Y), CurrentSymbol);
        }


        /// <summary>
        /// clears last point placed on audiogram
        /// </summary>
        /// <param name="X">Pixel Coordinate X</param>
        /// <param name="Y">Pixel Coordinate Y</param>
        public void Clear_Pt(int X, int Y)
        {
            const double Tolerance = 20.0;
            int Index = -1, i = 0;
            double Distance = 0.0;
            double ClosestDist = 0.0;

            if (UserCursors.PointsUsed > 0)
            {
                // Find index of closest point
                for (i = 0; i < UserCursors.PointsUsed; i++)
                {
                    Distance = Math.Sqrt((X - UserCursors.Points[i].X) * (X - UserCursors.Points[i].X) + (Y - UserCursors.Points[i].Y) * (Y - UserCursors.Points[i].Y));
                    if ((Distance <= Tolerance) && (1 / Distance >= ClosestDist))
                    {
                        Index = i;
                        ClosestDist = 1 / Distance;
                    }
                }

                // If an index was found
                if (Index >= 0)
                {
                    if ((UserCursors.Symbols[Index] == SymbolType.LeftNoResponse)
                        || (UserCursors.Symbols[Index] == SymbolType.RightNoResponse))
                    {
                        // Remove
                        for (i = Index - 1; i < UserCursors.PointsUsed - 2; i++)
                        {
                            UserCursors.Points[i] = UserCursors.Points[i + 2];
                            UserCursors.Symbols[i] = UserCursors.Symbols[i + 2];
                        }
                        UserCursors.PointsUsed -= 2;
                    }
                    else
                    {
                        // Remove element
                        for (i = Index; i < UserCursors.PointsUsed - 1; i++)
                        {
                            UserCursors.Points[i] = UserCursors.Points[i + 1];
                            UserCursors.Symbols[i] = UserCursors.Symbols[i + 1];
                        }
                        UserCursors.PointsUsed = UserCursors.PointsUsed - 1;
                    }
                }
            }
        }

        /// <summary>
        /// Called when graph area is clicked
        /// </summary>
        private void Graph_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (clickok == true)
                {
                    Place_Pt(e.X, e.Y);
                }
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                Clear_Pt(e.X, e.Y);
            }
            this.boundingBox.Invalidate();
        }

        /// <summary>
        ///  draws the cursors from pathology
        /// </summary>
        private void Draw_Patho_Cursors(object sender, PaintEventArgs e)
        {
            DrawCursors(PathologyCursors, e.Graphics, true);
        }

        /// <summary>
        /// draws user input cursors
        /// </summary>
        private void Draw_User_Cursors(object sender, PaintEventArgs e)
        {
            DrawCursors(UserCursors, e.Graphics, false);
            #region OldCode
            /*
			Graphics g = e.Graphics;
			for (int i = 0; i < UserCursors.PointsUsed; i++)
			{ 				
				if (this.cursor_Array[i] == "AC_Right")
				{
					cursor = "O";
					rgb = RIGHT_COLOR;
				}
				else if (this.cursor_Array[i] == "AC_Left")
				{
					cursor = "X";
					rgb = LEFT_COLOR;
				}
				else if (this.cursor_Array[i] == "BC_Right")
				{
					cursor = "<";
					rgb = RIGHT_COLOR;
				}
				else if (this.cursor_Array[i] == "BC_Left")
				{
					cursor = ">";
					rgb = LEFT_COLOR;
				}
				else if (this.cursor_Array[i] == UNICODE_TRIANGLE)
				{
					cursor = UNICODE_TRIANGLE;
					rgb = RIGHT_COLOR;
				}
				else if (this.cursor_Array[i] == UNICODE_SQUARE)
				{
					cursor = UNICODE_SQUARE;
					rgb = LEFT_COLOR;
				}
				else if (this.cursor_Array[i] == "[")
				{
					cursor = "[";
					rgb = RIGHT_COLOR;
				}
				else if (this.cursor_Array[i] == "]")
				{
					cursor = "]";
					rgb = LEFT_COLOR;
				}
				else if (this.cursor_Array[i] == UNICODE_DOWNLEFTARROW)
				{
					cursor = UNICODE_DOWNLEFTARROW;
					rgb = RIGHT_COLOR;
				}
				else if (this.cursor_Array[i] == UNICODE_DOWNRIGHTARROW)
				{
					cursor = UNICODE_DOWNRIGHTARROW;
					rgb = LEFT_COLOR;
				}
				else if (this.cursor_Array[i] == "S")
				{
					cursor = "S";
					rgb = RIGHT_COLOR;
				}
				else if (this.cursor_Array[i] == "A")
				{
					cursor = "A";
					rgb = RIGHT_COLOR;
				}
				else if (this.cursor_Array[i] == "UR")
				{
					cursor = "UR";
					rgb = RIGHT_COLOR;
				}
				else if (this.cursor_Array[i] == "UL")
				{
					cursor = "UL";
					rgb = LEFT_COLOR;
				}
				
				// Shift Bone Conduction cursors to the side slightly
				switch (cursor)
				{
					case "<": globalPts.X = UserCursors.Points[i].X-3; globalPts.Y = UserCursors.Points[i].Y; if(BCExists(false, UserCursors.Points[i], i) > 0) globalPts.X -= 5; break;
					case ">": globalPts.X = UserCursors.Points[i].X+8; globalPts.Y = UserCursors.Points[i].Y; if(BCExists(true, UserCursors.Points[i], i) > 0) globalPts.X += 5; break;
					case "[": globalPts.X = UserCursors.Points[i].X-1; globalPts.Y = UserCursors.Points[i].Y-1; if(BCExists(false, UserCursors.Points[i], i) > 0) globalPts.X -= 5; break;
					case "]": globalPts.X = UserCursors.Points[i].X+8; globalPts.Y = UserCursors.Points[i].Y-1; if(BCExists(true, UserCursors.Points[i], i) > 0) globalPts.X += 5; break;
					case "S": // drop down with A
					case "A": globalPts.X = UserCursors.Points[i].X+1; globalPts.Y = UserCursors.Points[i].Y; break;
					case UNICODE_SQUARE: globalPts.X = UserCursors.Points[i].X; globalPts.Y = UserCursors.Points[i].Y-1; break;
					case UNICODE_TRIANGLE: globalPts.X = UserCursors.Points[i].X+1; globalPts.Y = UserCursors.Points[i].Y; break;
					case UNICODE_DOWNLEFTARROW: globalPts.X = UserCursors.Points[i].X-7; globalPts.Y = UserCursors.Points[i].Y+7; if(BCExists(false, UserCursors.Points[i], i) > 1) globalPts.X -= 5; break;
					case UNICODE_DOWNRIGHTARROW: globalPts.X = UserCursors.Points[i].X+7; globalPts.Y = UserCursors.Points[i].Y+7; if(BCExists(true, UserCursors.Points[i], i) > 1) globalPts.X += 5; break;
					default: globalPts.X = UserCursors.Points[i].X; globalPts.Y = UserCursors.Points[i].Y; break;
				}
				g.DrawString(this.cursor,new Font("Arial",FONT_SIZE,System.Drawing.FontStyle.Bold),
					new SolidBrush(rgb),globalPts.X,globalPts.Y);
												
			}
			*/
            #endregion
        }

        /// <summary>
        ///  Determines whether there is already a BC symbol of that side at the point
        /// </summary>
        /// <param name="bRight">True if for right ear, false for left</param>
        /// <param name="Pt">Point containing coordinates of conflicting point</param>
        /// <param name="Index">Size of array</param>
        /// <returns>Number of BC's already there</returns>
        private int BCExists(bool bRight, System.Drawing.Point Pt, int Index)
        {
            int ret = 0;

            for (int i = 0; i < Index; i++)		// cycle through all points
            {
                if (Pt.X == UserCursors.Points[i].X && Pt.Y == UserCursors.Points[i].Y)   // make sure points are at the same coordinate
                {
                    if (bRight)			// if cursor is ">" or "]"
                    {
                        if (UserCursors.Symbols[i] == SymbolType.LeftBone)
                            ret++;
                    }
                    else				// if cursor is "<" or "["
                    {
                        if (UserCursors.Symbols[i] == SymbolType.RightBone)
                            ret++;
                    }
                }
            }
            return ret;
        }

        /// <summary>
        /// Symbol Command Button Click Procedure
        /// </summary>
        private void AC_Right_Click(object sender, System.EventArgs e)
        {
            CurrentSymbol = SymbolType.RightAir;
            clickok = true;
        }

        /// <summary>
        /// Symbol Command Button Click Procedure
        /// </summary>
        private void AC_Left_Click(object sender, System.EventArgs e)
        {
            CurrentSymbol = SymbolType.LeftAir;
            clickok = true;
        }

        /// <summary>
        /// Symbol Command Button Click Procedure
        /// </summary>
        private void BC_Right_Click(object sender, System.EventArgs e)
        {
            CurrentSymbol = SymbolType.RightBone;
            clickok = true;
        }

        /// <summary>
        /// Symbol Command Button Click Procedure
        /// </summary>
        private void BC_Left_Click(object sender, System.EventArgs e)
        {
            CurrentSymbol = SymbolType.LeftBone;
            clickok = true;
        }

        /// <summary>
        /// Symbol Command Button Click Procedure
        /// </summary>
        private void MAC_Right_Click(object sender, System.EventArgs e)
        {
            CurrentSymbol = SymbolType.RightAirMasked;
            clickok = true;
        }

        /// <summary>
        /// Symbol Command Button Click Procedure
        /// </summary>
        private void Sound_field_Click(object sender, System.EventArgs e)
        {
            //CurrentSymbol = SymbolType.SoundField;
            clickok = true;
        }

        /// <summary>
        /// Symbol Command Button Click Procedure
        /// </summary>
        private void Aided_Click(object sender, System.EventArgs e)
        {
            //CurrentSymbol = SymbolType.Aided;
            clickok = true;
        }

        /// <summary>
        /// Symbol Command Button Click Procedure
        /// </summary>
        private void Mac_Left_Click(object sender, System.EventArgs e)
        {
            this.CurrentSymbol = SymbolType.LeftAirMasked;
            clickok = true;
        }

        /// <summary>
        /// Symbol Command Button Click Procedure
        /// </summary>
        private void NoResp_Right_Click(object sender, System.EventArgs e)
        {
            //SymbolType Temp = CurrentSymbol;
            this.CurrentSymbol = SymbolType.RightNoResponse;
            //SetNoResponse();
            //this.CurrentSymbol = Temp;
            clickok = true;
        }

        /// <summary>
        /// Symbol Command Button Click Procedure
        /// </summary>
        private void NoResp_Left_Click(object sender, System.EventArgs e)
        {
            //SymbolType Temp = CurrentSymbol;
            this.CurrentSymbol = SymbolType.LeftNoResponse;
            //SetNoResponse();
            //this.CurrentSymbol = Temp;
            clickok = true;
        }

        /// <summary>
        /// Symbol Command Button Click Procedure
        /// </summary>
        private void UCL_R_Click(object sender, System.EventArgs e)
        {
            //this.CurrentCursor = "UR";
            clickok = true;
        }

        /// <summary>
        /// Symbol Command Button Click Procedure
        /// </summary>
        private void UCL_L_Click(object sender, System.EventArgs e)
        {
            //this.CurrentCursor = "UL";
            clickok = true;
        }

        /// <summary>
        /// Symbol Command Button Click Procedure
        /// </summary>
        private void MBC_Right_Click(object sender, System.EventArgs e)
        {
            CurrentSymbol = SymbolType.RightBoneMasked;
            clickok = true;
        }

        /// <summary>
        /// Symbol Command Button Click Procedure
        /// </summary>
        private void MBC_Left_Click(object sender, System.EventArgs e)
        {
            CurrentSymbol = SymbolType.LeftBoneMasked;
            clickok = true;
        }

        /// <summary>
        /// Symbol Command Button Click Procedure
        /// </summary>
        private void button1_Click(object sender, System.EventArgs e)
        {
            this.Clear_Graph();
        }

        /// <summary>
        /// Clears all points on the graph
        /// </summary>
        public void Clear_Graph()
        {
            UserCursors.PointsUsed = 0;
            PathologyCursors.PointsUsed = 0;
            this.boundingBox.Invalidate();
        }

        /// <summary>
        /// used to drive event that draws pathology cursors
        /// </summary>
        private void Show_Pathology_Click(object sender, System.EventArgs e)
        {
            this.Show_Pathology_Results();
        }

        /// <summary>
        /// Paint handler
        /// </summary>
        public void Show_Pathology_Results()
        {
            this.boundingBox.Invalidate();
        }

        /// <summary>
        /// This fills the Mask Array with all of the values placed in the masking text boxes
        /// </summary>
        public void Fill_Mask_Array()
        {
            MaskArray[0] = Convert.ToInt32(this.txtRMaskAC250.Text);
            MaskArray[1] = Convert.ToInt32(this.txtLMaskAC250.Text);
            MaskArray[2] = Convert.ToInt32(this.txtRMaskBC250.Text);
            MaskArray[3] = Convert.ToInt32(this.txtLMaskBC250.Text);
            MaskArray[4] = Convert.ToInt32(this.txtRMaskAC500.Text);
            MaskArray[5] = Convert.ToInt32(this.txtLMaskAC500.Text);
            MaskArray[6] = Convert.ToInt32(this.txtRMaskBC500.Text);
            MaskArray[7] = Convert.ToInt32(this.txtLMaskBC500.Text);
            MaskArray[8] = Convert.ToInt32(this.txtRMaskAC1000.Text);
            MaskArray[9] = Convert.ToInt32(this.txtLMaskAC1000.Text);
            MaskArray[10] = Convert.ToInt32(this.txtRMaskBC1000.Text);
            MaskArray[11] = Convert.ToInt32(this.txtLMaskBC1000.Text);
            MaskArray[12] = Convert.ToInt32(this.txtRMaskAC2000.Text);
            MaskArray[13] = Convert.ToInt32(this.txtLMaskAC2000.Text);
            MaskArray[14] = Convert.ToInt32(this.txtRMaskBC2000.Text);
            MaskArray[15] = Convert.ToInt32(this.txtLMaskBC2000.Text);
            MaskArray[16] = Convert.ToInt32(this.txtRMaskAC4000.Text);
            MaskArray[17] = Convert.ToInt32(this.txtLMaskAC4000.Text);
            MaskArray[18] = Convert.ToInt32(this.txtRMaskBC4000.Text);
            MaskArray[19] = Convert.ToInt32(this.txtLMaskBC4000.Text);
            MaskArray[20] = Convert.ToInt32(this.txtRMaskAC8000.Text);
            MaskArray[21] = Convert.ToInt32(this.txtLMaskAC8000.Text);
            MaskArray[22] = Convert.ToInt32(this.txtRMaskBC8000.Text);
            MaskArray[23] = Convert.ToInt32(this.txtLMaskBC8000.Text);
        }

        /// <summary>
        ///  This function places no response arrows in their places
        /// </summary>
        private void SetNoResponse()
        {
            /* Update this code FALL 2010 
             * 
			// Check to make sure correct no response arrow was selected
			if(ptsUsed == 0 || cursor_Array[ptsUsed-1] == UNICODE_DOWNLEFTARROW || cursor_Array[ptsUsed-1] == UNICODE_DOWNRIGHTARROW) return;
			if(    this.PlotCursor == UNICODE_DOWNRIGHTARROW 
				&& (cursor_Array[ptsUsed-1]=="AC_Right" || cursor_Array[ptsUsed-1]=="BC_Right" || cursor_Array[ptsUsed-1]==UNICODE_TRIANGLE || cursor_Array[ptsUsed-1]=="["))
				return;
			if(    this.PlotCursor == UNICODE_DOWNLEFTARROW
				&& (cursor_Array[ptsUsed-1]=="AC_Left" || cursor_Array[ptsUsed-1]=="BC_Left" || cursor_Array[ptsUsed-1]==UNICODE_SQUARE || cursor_Array[ptsUsed-1]=="]"))
				return;

			// Place the point
			ptArray[ptsUsed].X = ptArray[ptsUsed-1].X;
			ptArray[ptsUsed].X = ptArray[ptsUsed-1].X;
			ptArray[ptsUsed].Y = ptArray[ptsUsed-1].Y;
			cursor_Array[ptsUsed] = this.PlotCursor;
			ptsUsed++;
			this.boundingBox.Invalidate();
            */
        }

        /// <summary>
        ///  This will return the plotted points in a three line string from the selected array
        /// </summary>
        /// <param name="bPatho">True if you need pathology, false if you need user points</param>
        /// <returns>A String of the data in three lines</returns>
        public String GetPlottedPoints(bool bPatho)
        {
            String retString = "";
            String sX = "", sY = "", sCursor = "";
            int i = 0;

            if (bPatho)
            {
                for (i = 0; i < PathologyCursors.PointsUsed; i++)
                {
                    if (i != 0)
                    {
                        sX += ",";
                        sY += ",";
                        sCursor += ",";
                    }
                    sX += Convert.ToString(ConvertXCoord(PathologyCursors.Points[i].X), 10);
                    sY += Convert.ToString(ConvertYCoord(PathologyCursors.Points[i].Y), 10);
                    sCursor += PathologyCursors.Symbols[i];
                }
            }
            else
            {
                for (i = 0; i < UserCursors.PointsUsed; i++)
                {
                    if (i != 0)
                    {
                        sX += ",";
                        sY += ",";
                        sCursor += ",";
                    }
                    sX += Convert.ToString(ConvertXCoord(UserCursors.Points[i].X), 10);
                    sY += Convert.ToString(ConvertYCoord(UserCursors.Points[i].Y), 10);
                    sCursor += UserCursors.Symbols[i];
                }
            }

            retString = sX + "\n" + sY + "\n" + sCursor;
            return retString;
        }

        /// <summary>
        /// Converts X pixel coordinate to real data that Nathan can use
        /// </summary>
        /// <param name="Pixel">X pixel coordinate</param>
        /// <returns>Frequency of closest octave to passed x coordinate</returns>
        private int ConvertXCoord(int Pixel)
        {
            int New_C = 0, Best_C = 0;
            int TempDist = Int32.MaxValue;

            // Snap to X Grid
            for (int j = 0; j <= NumXGrids; j++)
            {
                // don't snap to the first two middle grids (grids 1 and 3)
                if (j == 1 || j == 3) continue;
                New_C = SpecialMinX + (SpecialMaxX - SpecialMinX) * j / NumXGrids;
                if (TempDist > Math.Abs(New_C - Pixel))
                {
                    TempDist = Math.Abs(New_C - Pixel);
                    Best_C = j;
                }
            }
            return (125 * (0x1 << Best_C / 2) + Best_C % 2 * (0x1 << Best_C / 2) * 125 / 2);
        }

        /// <summary>
        /// Converts Y pixel coordinate to real data so Nathan can use it
        /// </summary>
        /// <param name="Pixel">Y pixel coordinate</param>
        /// <returns>dB level of nearest 5 dB mark to passed Y coordinate</returns>
        private int ConvertYCoord(int Pixel)
        {
            int New_C = 0, Best_C = 0;
            int TempDist = Int32.MaxValue;

            // Snap to Y Grid
            for (int i = 0; i <= NumYGrids; i++)
            {
                New_C = MIN_Y + (MAX_Y - MIN_Y) * i / NumYGrids;
                if (TempDist > Math.Abs(New_C - Pixel))
                {
                    TempDist = Math.Abs(New_C - Pixel);
                    Best_C = i;
                }
            }
            return (5 * Best_C - 10);
        }

        /// <summary>
        /// This function sets the tool tip text
        /// </summary>
        private void boundingBox_MouseMove(object sender, MouseEventArgs e)
        {
            String thetip;
            if (e.X <= MIN_X || e.X >= MAX_X || e.Y <= MIN_Y || e.Y >= MAX_Y)
                thetip = "";
            else
                thetip = Convert.ToString(ConvertXCoord(e.X)) + " Hz, " + Convert.ToString(ConvertYCoord(e.Y)) + " dB";
            ttCoord.SetToolTip(this.boundingBox, thetip);
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
            SpAudInput.ShowPathology(_SRTThresh, _SRTMask, _WIScore, _WILevel, _WIMask);
        }

        /// <summary>
        /// Hides the speech pathology from the user
        /// </summary>
        public void HideSpeechResults()
        {
            SpAudInput.HidePathology();
        }

        /// <summary>
        /// Clears the Speech Input boxes for user input
        /// </summary>
        public void ClearSpeechResults()
        {
            SpAudInput.ClearInput();
        }

        /// <summary>
        /// Will show or hide the Speech Audiometry Form
        /// </summary>
        private void cmdSpeechAudiometry_Click(object sender, System.EventArgs e)
        {
            ShowSpeechAudiometry();
        }

        /// <summary>
        /// Shows or hides the speech audiometry form
        /// </summary>
        public void ShowSpeechAudiometry()
        {
            if (btnSpeechAudiometry.Text == "Show Speech Audiometry")
            {
                btnSpeechAudiometry.Text = "Hide Speech Audiometry";
                SpAudInput.Show();
                SpAudInput.Location = new Point(this.Location.X + this.Width - this.SpAudInput.Width, this.Location.Y - this.SpAudInput.Height);
            }
            else
            {
                btnSpeechAudiometry.Text = "Show Speech Audiometry";
                SpAudInput.SaveAll();
                SpAudInput.Hide();
            }
        }

        /// <summary>
        /// Draws the cursors of a particular cursor array
        /// </summary>
        /// <param name="Cursors">The array of cursors to draw</param>
        public void DrawCursors(CursorArray Cursors, Graphics g, bool bold)
        {
            string UseFont;
            float FontSize;
            string CursorText;
            Color rgb;

            // for each cursor used in the array, determine features
            // and draw it to the audiogram
            for (int i = 0; i < Cursors.PointsUsed; i++)
            {
                if ((RightEar & (byte)Cursors.Symbols[i]) == RightEar)
                    rgb = Color.Red; // Cursor is a right cursor
                else
                    rgb = Color.Blue; // Cursor is a left cursor

                UseFont = "Arial"; // Unless otherwise specified
                FontSize = FONT_SIZE;
                // Location of the cursor on the plot
                globalPts.X = Cursors.Points[i].X;
                globalPts.Y = Cursors.Points[i].Y;

                switch (Cursors.Symbols[i])
                {
                    // Some cursor positions require shifts
                    // or change of font
                    case SymbolType.LeftAir:
                        CursorText = "X";
                        globalPts.X += 2;
                        break;
                    case SymbolType.RightAir:
                        CursorText = "O";
                        break;
                    case SymbolType.LeftBone:
                        CursorText = ">";
                        globalPts.X += 13;
                        break;
                    case SymbolType.RightBone:
                        CursorText = "<";
                        globalPts.X -= 10;
                        break;
                    case SymbolType.LeftAirMasked:
                        CursorText = "\x0063"; // A square in Wingdings (ASCII code A8 = 168)
                        UseFont = "Webdings"; // NOT wingdings 3!!
                        FontSize = 12;
                        globalPts.X -= 2;
                        globalPts.Y -= 1;
                        break;
                    case SymbolType.RightAirMasked:
                        CursorText = "\x00EA"; // A triangle in Wingdings 3 (r)
                        //UseFont = "Wingdings 3";
                        UseFont = "Webdings";
                        //UseFont = "Arial Narrow";
                        FontSize = 19;
                        globalPts.X -= 8;
                        globalPts.Y -= 6;
                        break;
                    case SymbolType.LeftBoneMasked:
                        CursorText = "]";
                        globalPts.X += 20;
                        globalPts.Y -= 1;
                        break;
                    case SymbolType.RightBoneMasked:
                        CursorText = "[";
                        globalPts.X -= 13;
                        globalPts.Y -= 1;
                        break;
                    case SymbolType.LeftNoResponse:
                        CursorText = "m"; // A down-right arrow in Wingdings 3
                        UseFont = "Wingdings 3";
                        globalPts.X += 7;
                        globalPts.Y += 7;
                        break;
                    case SymbolType.RightNoResponse:
                        CursorText = "l"; // A down-left arrow in Wingdings 3
                        UseFont = "Wingdings 3";
                        globalPts.X -= 7;
                        globalPts.Y += 7;
                        break;
                    /*case SymbolType.Aided:
                        CursorText = "A";
                        globalPts.X += 1;
                        break;
                    case SymbolType.SoundField:
                        CursorText = "S";
                        globalPts.X += 1;
                        break;*/
                    default:
                        CursorText = "O";
                        break;

                }
                #region removemesoon
                /*
				else if (this.patho_cursorArray[i] == "UR")
				{
					cursor = "UR";
					rgb = ACTUAL_RIGHT_COLOR;
				}
				else if (this.patho_cursorArray[i] == "UL")
				{
					cursor = "UL";
					rgb = ACTUAL_LEFT_COLOR;
				}*/
                #endregion

                Font font;

                if (bold)
                    font = new Font(UseFont, FontSize, FontStyle.Bold);
                else
                    font = new Font(UseFont, FontSize);

                g.DrawString(CursorText, font, new SolidBrush(rgb), globalPts.X, globalPts.Y);
            }

        }

        private void AudiogramPanel_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (patient.path != null)
            {
                vltl.NewPatientMenu(patient.path.pathInt);
                vltl.resultsShow_Click(null, null);
            }
        }

        private void AudiogramPanel_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtRMask1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // delete me (clickme button)

            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
            {
                int i;
                for (i = 1; i < clickme.Length - 1; i++)
                    clickme[i - 1] = clickme[i];

                clickme[i - 1] = e.KeyChar;

                if (String.Compare("clickme", new string(clickme)) == 0)
                    button1.Show();
            }
            // end delete me
        }

        private void txtRMaskBC250_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRMaskAC250_TextChanged(object sender, EventArgs e)
        {

        }


        internal void Patho_PlacePt1(int i, int RightAirThresh, AudiogramPanel.SymbolType symbolType)
        {
            throw new NotImplementedException();
        }

        internal void Patho_PlacePt(int i, int LeftAirThresh, Audiogram.SymbolType symbolType)
        {
            throw new NotImplementedException();
        }
    }
}