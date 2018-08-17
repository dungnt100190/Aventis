using System;
using System.Drawing;
using System.Windows.Forms;
using KiSS4.DB;
using KiSS4.Sozialsystem.PI;

namespace KiSS4.Fallfuehrung.PI
{
    public class CtlFaSozialsystemContainer : KiSS4.Gui.KissUserControl
    {
        #region Fields

        private Int32 BaPersonID = -1; // store baPersonID that is shown within diagram
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissLabel lblInfoError;
        private System.Windows.Forms.ToolTip ttpErrorMessage;

        #endregion

        #region Constructors

        public CtlFaSozialsystemContainer()
        {
            this.InitializeComponent();

            // reset border-style, it is only because of the white control...
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblInfoError = new KiSS4.Gui.KissLabel();
            this.ttpErrorMessage = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lblInfoError)).BeginInit();
            this.SuspendLayout();
            //
            // lblInfoError
            //
            this.lblInfoError.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInfoError.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblInfoError.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblInfoError.Location = new System.Drawing.Point(0, 0);
            this.lblInfoError.Name = "lblInfoError";
            this.lblInfoError.Size = new System.Drawing.Size(570, 36);
            this.lblInfoError.TabIndex = 0;
            this.lblInfoError.Text = "<Error-Message>";
            this.lblInfoError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblInfoError.UseCompatibleTextRendering = true;
            this.lblInfoError.Visible = false;
            //
            // CtlFaSozialsystemContainer
            //
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblInfoError);
            this.Name = "CtlFaSozialsystemContainer";
            this.Size = new System.Drawing.Size(570, 382);
            ((System.ComponentModel.ISupportInitialize)(this.lblInfoError)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        #region Dispose

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if ((components != null))
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Public Methods

        public void Init(String titleName, Image titleImage, Int32 baPersonID)
        {
            // debug
            // MessageBox.Show("Called Init(baPersonID=" + Convert.ToString(baPersonID) + ")");

            // apply fields
            this.BaPersonID = baPersonID;

            try
            {
                // hide error-label
                lblInfoError.Visible = false;

                // create new instance of SozialSystem
                CtlSozialsystem ctlSozialsystem = new CtlSozialsystem();

                // init sozialsystem
                ctlSozialsystem.Init(baPersonID, DateTime.Today);

                // setup layout on container
                this.Controls.Add(ctlSozialsystem);
                this.Controls[1].Dock = DockStyle.Fill;
            }
            catch (Exception ex)
            {
                // show error-label
                lblInfoError.Text = KissMsg.GetMLMessage("CtlFaSozialsystemContainer", "ErrorInfo_v02", "Das graphische Sozialsystem kann aufgrund eines Fehlers nicht angezeigt werden.");
                lblInfoError.Visible = true;

                // setup error-tooltip
                ttpErrorMessage.ToolTipTitle = KissMsg.GetMLMessage("CtlFaSozialsystemContainer", "ToolTipTitleError", "Fehler");
                ttpErrorMessage.SetToolTip(lblInfoError, String.Format("{1}{0}{0}StackTrace:{0}{2}", Environment.NewLine, ex.Message, ex.StackTrace));
            }
        }

        #endregion

        protected override void OnLoad(EventArgs e)
        {
            //do nothing
        }
    }
}