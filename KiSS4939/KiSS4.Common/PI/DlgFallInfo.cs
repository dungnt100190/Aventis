using KiSS4.DB;

namespace KiSS4.Common.PI
{
    /// <summary>
    /// Class for case module list of client
    /// </summary>
    public class DlgFallInfo : KiSS4.Gui.KissDialog
    {
        #region Fields

        #region Private Fields

        /// <summary>
        /// Store the BaPersonID of current client
        /// </summary>
        private int _baPersonID = -1;
        private KiSS4.Gui.KissButton btnClose;
        private System.ComponentModel.IContainer components;
        private CtlFallInfo ctlFallInfo;
        private System.Windows.Forms.Panel panBottom;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor, used to create new instance of class
        /// </summary>
        /// <param name="baPersonID">The id of the person to show details</param>
        public DlgFallInfo(int baPersonID)
            : this()
        {
            // apply fields
            this._baPersonID = baPersonID;
        }

        /// <summary>
        /// Constructor, used to create new instance of class
        /// </summary>
        public DlgFallInfo()
        {
            this.InitializeComponent();
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
            this.panBottom = new System.Windows.Forms.Panel();
            this.btnClose = new KiSS4.Gui.KissButton();
            this.ctlFallInfo = new KiSS4.Common.PI.CtlFallInfo();
            this.panBottom.SuspendLayout();
            this.SuspendLayout();
            //
            // panBottom
            //
            this.panBottom.Controls.Add(this.btnClose);
            this.panBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panBottom.Location = new System.Drawing.Point(0, 532);
            this.panBottom.Name = "panBottom";
            this.panBottom.Size = new System.Drawing.Size(734, 39);
            this.panBottom.TabIndex = 0;
            //
            // btnClose
            //
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(632, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 24);
            this.btnClose.TabIndex = 32;
            this.btnClose.Text = "&Schliessen";
            this.btnClose.UseCompatibleTextRendering = true;
            this.btnClose.UseVisualStyleBackColor = true;
            //
            // ctlFallInfo
            //
            this.ctlFallInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlFallInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlFallInfo.Location = new System.Drawing.Point(0, 0);
            this.ctlFallInfo.Name = "ctlFallInfo";
            this.ctlFallInfo.Size = new System.Drawing.Size(734, 532);
            this.ctlFallInfo.TabIndex = 1;
            //
            // DlgFallInfo
            //
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(734, 571);
            this.Controls.Add(this.ctlFallInfo);
            this.Controls.Add(this.panBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "DlgFallInfo";
            this.Text = "Fall-Informationen";
            this.Load += new System.EventHandler(this.DlgFallInfo_Load);
            this.panBottom.ResumeLayout(false);
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

        #region EventHandlers

        private void DlgFallInfo_Load(object sender, System.EventArgs e)
        {
            // check if we have a valid BaPersonID
            if (this._baPersonID < 1)
            {
                // show information
                KissMsg.ShowError("DlgFallInfo", "InvalidBaPersonIDInLoad", "Ungültige Personen-Nr. - Daten dazu können nicht geladen werden.");

                // do not continue
                return;
            }

            // load data by applying current BaPersonID on control
            ctlFallInfo.BaPersonID = _baPersonID;

            // set title of dialog (requires a load-data)
            this.Text = string.Format("{0} - {1} ({2})", KissMsg.GetMLMessage("DlgFallInfo", "DialogTitle", "Fall-Informationen"),
                                                         ctlFallInfo.NameVorname,
                                                         ctlFallInfo.BaPersonID);
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Save pending changes and reload Data
        /// </summary>
        public override void OnRefreshData()
        {
            // refresh data on control
            ctlFallInfo.OnRefreshData();
        }

        #endregion

        #endregion
    }
}