using System;
using System.Drawing;
using System.Windows.Forms;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Sozialsystem.PI
{
    public class CtlSozialsystem : KiSS4.Gui.KissUserControl
    {
        #region Fields

        public KissLabel lblClientSystem;

        internal Panel panClients;

        internal Panel panInvolvedOrganisations;

        internal Panel panServiceProviders;

        internal Panel panSozialsystem;

        /// <summary>
        /// The builder of the graphic display
        /// </summary>
        private SozialsystemBuilder builder = null;

        // Form components and controls
        private KiSS4.Gui.KissLabel lblInvolvedOrganisations;

        private KiSS4.Gui.KissLabel lblServiceProviders;

        /// <summary>
        /// The minimal size the control can have. If smaller: Scrollbar appear, if larger: autosize is possible.
        /// </summary>
        private Size minControlSize = new Size(500, 200);

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CtlSozialsystem()
        {
            InitializeComponent();
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>>
        /// Initialize components
        /// </summary>
        private void InitializeComponent()
        {
            this.lblInvolvedOrganisations = new KiSS4.Gui.KissLabel();
            this.panInvolvedOrganisations = new System.Windows.Forms.Panel();
            this.panServiceProviders = new System.Windows.Forms.Panel();
            this.lblServiceProviders = new KiSS4.Gui.KissLabel();
            this.panClients = new System.Windows.Forms.Panel();
            this.lblClientSystem = new KiSS4.Gui.KissLabel();
            this.panSozialsystem = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.lblInvolvedOrganisations)).BeginInit();
            this.panInvolvedOrganisations.SuspendLayout();
            this.panServiceProviders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblServiceProviders)).BeginInit();
            this.panClients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblClientSystem)).BeginInit();
            this.panSozialsystem.SuspendLayout();
            this.SuspendLayout();
            //
            // lblInvolvedOrganisations
            //
            this.lblInvolvedOrganisations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInvolvedOrganisations.AutoEllipsis = true;
            this.lblInvolvedOrganisations.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblInvolvedOrganisations.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblInvolvedOrganisations.Location = new System.Drawing.Point(3, 3);
            this.lblInvolvedOrganisations.Name = "lblInvolvedOrganisations";
            this.lblInvolvedOrganisations.Size = new System.Drawing.Size(234, 19);
            this.lblInvolvedOrganisations.TabIndex = 0;
            this.lblInvolvedOrganisations.Text = "Institutionen";
            this.lblInvolvedOrganisations.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            //
            // panInvolvedOrganisations
            //
            this.panInvolvedOrganisations.AutoScrollMargin = new System.Drawing.Size(6, 6);
            this.panInvolvedOrganisations.BackColor = System.Drawing.Color.White;
            this.panInvolvedOrganisations.Controls.Add(this.lblInvolvedOrganisations);
            this.panInvolvedOrganisations.Location = new System.Drawing.Point(524, 0);
            this.panInvolvedOrganisations.Margin = new System.Windows.Forms.Padding(0);
            this.panInvolvedOrganisations.Name = "panInvolvedOrganisations";
            this.panInvolvedOrganisations.Size = new System.Drawing.Size(240, 297);
            this.panInvolvedOrganisations.TabIndex = 2;
            //
            // panServiceProviders
            //
            this.panServiceProviders.AutoScrollMargin = new System.Drawing.Size(6, 6);
            this.panServiceProviders.BackColor = System.Drawing.Color.White;
            this.panServiceProviders.Controls.Add(this.lblServiceProviders);
            this.panServiceProviders.Location = new System.Drawing.Point(0, 303);
            this.panServiceProviders.Name = "panServiceProviders";
            this.panServiceProviders.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.panServiceProviders.Size = new System.Drawing.Size(764, 118);
            this.panServiceProviders.TabIndex = 3;
            //
            // lblServiceProviders
            //
            this.lblServiceProviders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblServiceProviders.AutoEllipsis = true;
            this.lblServiceProviders.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblServiceProviders.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblServiceProviders.Location = new System.Drawing.Point(3, 0);
            this.lblServiceProviders.Name = "lblServiceProviders";
            this.lblServiceProviders.Size = new System.Drawing.Size(758, 19);
            this.lblServiceProviders.TabIndex = 0;
            this.lblServiceProviders.Text = "Prozess-Verantwortliche";
            this.lblServiceProviders.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            //
            // panClients
            //
            this.panClients.AutoScrollMargin = new System.Drawing.Size(6, 6);
            this.panClients.BackColor = System.Drawing.Color.White;
            this.panClients.Controls.Add(this.lblClientSystem);
            this.panClients.Location = new System.Drawing.Point(0, 0);
            this.panClients.Name = "panClients";
            this.panClients.Padding = new System.Windows.Forms.Padding(6);
            this.panClients.Size = new System.Drawing.Size(521, 297);
            this.panClients.TabIndex = 0;
            //
            // lblClientSystem
            //
            this.lblClientSystem.AutoEllipsis = true;
            this.lblClientSystem.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblClientSystem.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblClientSystem.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblClientSystem.Location = new System.Drawing.Point(6, 6);
            this.lblClientSystem.Name = "lblClientSystem";
            this.lblClientSystem.Size = new System.Drawing.Size(509, 19);
            this.lblClientSystem.TabIndex = 0;
            this.lblClientSystem.Text = "Sozialsystem - Gruber, Hans (12345) - Heute";
            this.lblClientSystem.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            //
            // panSozialsystem
            //
            this.panSozialsystem.AutoSize = true;
            this.panSozialsystem.BackColor = System.Drawing.Color.White;
            this.panSozialsystem.Controls.Add(this.panInvolvedOrganisations);
            this.panSozialsystem.Controls.Add(this.panClients);
            this.panSozialsystem.Controls.Add(this.panServiceProviders);
            this.panSozialsystem.Location = new System.Drawing.Point(0, 0);
            this.panSozialsystem.Name = "panSozialsystem";
            this.panSozialsystem.Size = new System.Drawing.Size(826, 493);
            this.panSozialsystem.TabIndex = 1;
            //
            // CtlSozialsystem
            //
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panSozialsystem);
            this.Name = "CtlSozialsystem";
            this.Size = new System.Drawing.Size(878, 537);
            this.SizeChanged += new System.EventHandler(this.CtlSozialsystem_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.lblInvolvedOrganisations)).EndInit();
            this.panInvolvedOrganisations.ResumeLayout(false);
            this.panServiceProviders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblServiceProviders)).EndInit();
            this.panClients.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblClientSystem)).EndInit();
            this.panSozialsystem.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Get and set minimum size for form
        /// </summary>
        public Size MinControlSize
        {
            get { return this.minControlSize; }
            set
            {
                // check if we have a bigger width than min-value
                if (value.Width > this.minControlSize.Width)
                {
                    // apply width
                    this.minControlSize.Width = value.Width;
                }

                // check if we have a bigger height than min-value
                if (value.Height > this.minControlSize.Height)
                {
                    // apply height
                    this.minControlSize.Height = value.Height;
                }

                // do now resize elements
                this.DoSizeElements();
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Set client control for current BaPersonID as focused (bold bolder)
        /// </summary>
        /// <param name="baPersonID">The BaPersonID for which the social system has to be drawn</param>
        public void FocusBaPerson(Int32 baPersonID)
        {
            // loop all controls
            for (Int32 c = 0; c < panClients.Controls.Count; c++)
            {
                // check if control is client
                if (panClients.Controls[c] is CtlItemClient)
                {
                    // get control
                    CtlItemClient ctl = (panClients.Controls[c] as CtlItemClient);

                    // check if person is main-person
                    if (ctl.PersonID == baPersonID)
                    {
                        // set tabindex to ensure control is first focused even when not drawn yet
                        ctl.TabIndex = 0;

                        // set focus to this control
                        ctl.Focus();
                    }
                }
            }
        }

        /// <summary>
        /// Init a new control for sozialsystem
        /// </summary>
        /// <param name="baPersonID">The id of the person to show (optional)</param>
        /// <param name="date">The date to use for data (optional)</param>
        public void Init(Int32 baPersonID, DateTime date)
        {
            // setup date-info
            String tmpDatum = KissMsg.GetMLMessage("CtlSozialsystemPI", "InitDateToday", "heute");

            if (date != null && date != DateTime.Today)
            {
                // set info-label as given date
                tmpDatum = date.ToString("dd.MM.yyyy");
            }

            // get person info
            String baPersonNameVorname = Convert.ToString(DBUtil.ExecuteScalarSQL(@"
                    DECLARE @NameVorname VARCHAR(500)

                    SELECT @NameVorname = ISNULL(PRS.Name, '') +
                             ISNULL(', '  + PRS.Vorname, '') +
                             ISNULL(' (' + CONVERT(VARCHAR, PRS.BaPersonID) + ')', '')
                    FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
                    WHERE PRS.BaPersonID = {0}

                    SELECT ISNULL(@NameVorname, '???')", baPersonID));

            // apply title-labels
            lblClientSystem.Text = KissMsg.GetMLMessage("CtlSozialsystemPI", "TitelClientSystem", "Sozialsystem  - {0} - {1}", KissMsgCode.Text, baPersonNameVorname, tmpDatum);
            lblInvolvedOrganisations.Text = KissMsg.GetMLMessage("CtlSozialsystemPI", "TitelInvolvedOrganisations", "Institutionen");
            lblServiceProviders.Text = KissMsg.GetMLMessage("CtlSozialsystemPI", "TitelServiceProviders", "Prozess-Verantwortliche");

            // create new builder
            builder = new SozialsystemBuilder(this, baPersonID);

            // focus
            this.FocusBaPerson(baPersonID);
        }

        #endregion

        protected override void OnLoad(EventArgs e)
        {
            //do nothing
        }

        #region Private Methods

        /// <summary>
        /// SizeChanged event, used to setup min- or autosize for panel
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void CtlSozialsystem_SizeChanged(object sender, EventArgs e)
        {
            //DoSizeElements();
        }

        /// <summary>
        /// Arrange elements depending on form's current size and settings
        /// </summary>
        private void DoSizeElements()
        {
            // panClients:
            panClients.Top = 0;
            panClients.Left = 0;
            panClients.Width = this.MinControlSize.Width - panInvolvedOrganisations.Width;

            // panInvolvedOrganisations:
            panInvolvedOrganisations.Top = 0;
            panInvolvedOrganisations.Left = panClients.Left + panClients.Width;

            // panServiceProviders:
            panServiceProviders.Left = 0;
            panServiceProviders.Top = this.MinControlSize.Height;

            if (panServiceProviders.Width < this.MinControlSize.Width)
            {
                panServiceProviders.Left = (this.MinControlSize.Width - panServiceProviders.Width) / 2;
            }

            panSozialsystem.Width = this.MinControlSize.Width;

            if (panSozialsystem.Width < panServiceProviders.Width)
            {
                panSozialsystem.Width = panServiceProviders.Width;
            }

            panSozialsystem.Height = this.MinControlSize.Height + panServiceProviders.Height;

            panClients.Height = panSozialsystem.Height - panServiceProviders.Height;
            panInvolvedOrganisations.Height = panSozialsystem.Height - panServiceProviders.Height;
        }

        #endregion
    }
}