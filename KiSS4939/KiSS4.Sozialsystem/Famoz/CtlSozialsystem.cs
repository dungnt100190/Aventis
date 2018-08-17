using System;
using System.Drawing;
using System.Windows.Forms;
using KiSS4.Gui;

namespace KiSS4.Sozialsystem.Famoz
{
    public class CtlSozialsystem : KiSS4.Gui.KissUserControl
    {
        #region Fields

        public KissLabel lblClientSystem;

        internal Panel panClients;

        internal Panel panInvolvedOrganisations;

        // Form components and controls
        internal Panel panInvolvedPersons;

        internal Panel panServiceProviders;

        internal Panel panSozialsystem;

        /// <summary>
        /// The builder of the graphic display
        /// </summary>
        private SozialsystemBuilder builder = null;

        private KiSS4.Gui.KissLabel lblInvolvedOrganisations;

        private KiSS4.Gui.KissLabel lblInvolvedPersons;

        private KiSS4.Gui.KissLabel lblServiceProviders;

        /// <summary>
        /// The minimal size the control can have. If smaller: Scrollbar appear, if larger: autosize is possible.
        /// </summary>
        private Size minControlSize = new Size(800, 400);

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

        #region InitializeComponent

        /// <summary>>
        /// Initialize components
        /// </summary>
        private void InitializeComponent()
        {
            this.panInvolvedPersons = new System.Windows.Forms.Panel();
            this.lblInvolvedPersons = new KiSS4.Gui.KissLabel();
            this.lblInvolvedOrganisations = new KiSS4.Gui.KissLabel();
            this.panInvolvedOrganisations = new System.Windows.Forms.Panel();
            this.panServiceProviders = new System.Windows.Forms.Panel();
            this.lblServiceProviders = new KiSS4.Gui.KissLabel();
            this.panClients = new System.Windows.Forms.Panel();
            this.lblClientSystem = new KiSS4.Gui.KissLabel();
            this.panSozialsystem = new System.Windows.Forms.Panel();
            this.panInvolvedPersons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblInvolvedPersons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInvolvedOrganisations)).BeginInit();
            this.panInvolvedOrganisations.SuspendLayout();
            this.panServiceProviders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblServiceProviders)).BeginInit();
            this.panClients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblClientSystem)).BeginInit();
            this.panSozialsystem.SuspendLayout();
            this.SuspendLayout();
            //
            // panInvolvedPersons
            //
            this.panInvolvedPersons.AutoScrollMargin = new System.Drawing.Size(6, 6);
            this.panInvolvedPersons.BackColor = System.Drawing.Color.White;
            this.panInvolvedPersons.Controls.Add(this.lblInvolvedPersons);
            this.panInvolvedPersons.Location = new System.Drawing.Point(0, 0);
            this.panInvolvedPersons.Margin = new System.Windows.Forms.Padding(0);
            this.panInvolvedPersons.Name = "panInvolvedPersons";
            this.panInvolvedPersons.Size = new System.Drawing.Size(200, 297);
            this.panInvolvedPersons.TabIndex = 1;
            //
            // lblInvolvedPersons
            //
            this.lblInvolvedPersons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInvolvedPersons.AutoEllipsis = true;
            this.lblInvolvedPersons.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblInvolvedPersons.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblInvolvedPersons.Location = new System.Drawing.Point(3, 3);
            this.lblInvolvedPersons.Name = "lblInvolvedPersons";
            this.lblInvolvedPersons.Size = new System.Drawing.Size(191, 19);
            this.lblInvolvedPersons.TabIndex = 0;
            this.lblInvolvedPersons.Text = "Involvierte Personen";
            this.lblInvolvedPersons.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.lblInvolvedOrganisations.Size = new System.Drawing.Size(194, 19);
            this.lblInvolvedOrganisations.TabIndex = 0;
            this.lblInvolvedOrganisations.Text = "Involvierte Stellen";
            this.lblInvolvedOrganisations.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            //
            // panInvolvedOrganisations
            //
            this.panInvolvedOrganisations.AutoScrollMargin = new System.Drawing.Size(6, 6);
            this.panInvolvedOrganisations.BackColor = System.Drawing.Color.White;
            this.panInvolvedOrganisations.Controls.Add(this.lblInvolvedOrganisations);
            this.panInvolvedOrganisations.Location = new System.Drawing.Point(564, 0);
            this.panInvolvedOrganisations.Margin = new System.Windows.Forms.Padding(0);
            this.panInvolvedOrganisations.Name = "panInvolvedOrganisations";
            this.panInvolvedOrganisations.Size = new System.Drawing.Size(200, 297);
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
            this.lblServiceProviders.Text = "Leistungserbringer";
            this.lblServiceProviders.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            //
            // panClients
            //
            this.panClients.AutoScrollMargin = new System.Drawing.Size(6, 6);
            this.panClients.BackColor = System.Drawing.Color.White;
            this.panClients.Controls.Add(this.lblClientSystem);
            this.panClients.Location = new System.Drawing.Point(203, 0);
            this.panClients.Name = "panClients";
            this.panClients.Padding = new System.Windows.Forms.Padding(6);
            this.panClients.Size = new System.Drawing.Size(358, 297);
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
            this.lblClientSystem.Size = new System.Drawing.Size(346, 19);
            this.lblClientSystem.TabIndex = 0;
            this.lblClientSystem.Text = "Klientensystem - Fall 2034 - Heute";
            this.lblClientSystem.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            //
            // panSozialsystem
            //
            this.panSozialsystem.AutoSize = true;
            this.panSozialsystem.BackColor = System.Drawing.Color.White;
            this.panSozialsystem.Controls.Add(this.panInvolvedOrganisations);
            this.panSozialsystem.Controls.Add(this.panClients);
            this.panSozialsystem.Controls.Add(this.panInvolvedPersons);
            this.panSozialsystem.Controls.Add(this.panServiceProviders);
            this.panSozialsystem.Location = new System.Drawing.Point(0, 0);
            this.panSozialsystem.Name = "panSozialsystem";
            this.panSozialsystem.Size = new System.Drawing.Size(827, 495);
            this.panSozialsystem.TabIndex = 1;
            //
            // CtlSozialsystem
            //
            this.AutoScroll = true;

            this.Controls.Add(this.panSozialsystem);
            this.Name = "CtlSozialsystem";
            this.Size = new System.Drawing.Size(878, 537);
            this.SizeChanged += new System.EventHandler(this.CtlSozialsystem_SizeChanged);
            this.panInvolvedPersons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblInvolvedPersons)).EndInit();
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

        #region Properties

        /// <summary>
        /// Get and set minimum size for form
        /// </summary>
        public Size MinControlSize
        {
            get { return minControlSize; }
            set
            {
                minControlSize = value;
                DoSizeElements();
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// SizeChanged event, used to setup min- or autosize for panel
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void CtlSozialsystem_SizeChanged(object sender, EventArgs e)
        {
            //DoSizeElements();
        }

        #endregion

        #region Init Control for drawing

        /// <summary>
        /// Init a new control for sozialsystem
        /// </summary>
        /// <param name="baPersonID">The id of the person to show (optional)</param>
        /// <param name="faFallID">The id of the fall to show</param>
        /// <param name="date">The date to use for data (optional)</param>
        public void Init(int baPersonID, int faFallID, DateTime date)
        {
            //TODO: has to be corrected for proper working with date, etc. ...

            string tmpDatum = "heute";
            if (date == DateTime.Today)
                tmpDatum = "heute";
            else tmpDatum = date.ToString("dd.MM.yyyy");

            lblClientSystem.Text =
                string.Format("Klientensystem  - Fall {0} - {1}",
                faFallID.ToString(), tmpDatum);

            // create new builder
            builder = new SozialsystemBuilder(this, baPersonID, faFallID);
        }

        #endregion

        #region Helper methods

        /// <summary>
        /// Arrange elements depending on form's current size and settings
        /// </summary>
        private void DoSizeElements()
        {
            // panInvolvedPersons:
            panInvolvedPersons.Top = 0;
            panInvolvedPersons.Left = 0;

            // panClients:
            panClients.Top = 0;
            panClients.Left = panInvolvedPersons.Width;
            panClients.Width = this.minControlSize.Width - panInvolvedPersons.Width - panInvolvedOrganisations.Width;

            // panInvolvedOrganisations:
            panInvolvedOrganisations.Top = 0;
            panInvolvedOrganisations.Left = panClients.Left + panClients.Width;

            // panServiceProviders:
            panServiceProviders.Left = 0;
            panServiceProviders.Top = this.minControlSize.Height;
            if (panServiceProviders.Width < this.minControlSize.Width)
                panServiceProviders.Left = (this.minControlSize.Width - panServiceProviders.Width) / 2;

            panSozialsystem.Width = this.minControlSize.Width;
            if (panSozialsystem.Width < panServiceProviders.Width)
                panSozialsystem.Width = panServiceProviders.Width;
            panSozialsystem.Height = this.minControlSize.Height + panServiceProviders.Height;

            //panInvolvedOrganisations.Left = panSozialsystem.Width - panInvolvedOrganisations.Width;

            panInvolvedPersons.Height = panSozialsystem.Height - panServiceProviders.Height;
            panClients.Height = panSozialsystem.Height - panServiceProviders.Height;
            panInvolvedOrganisations.Height = panSozialsystem.Height - panServiceProviders.Height;

            /*
            lock (doResizeLock)
            {
                // setup width
                if (this.Width > this.minControlSize.Width && this.Height > this.minControlSize.Height)
                {
                    if (!isPanelDocking)
                    {
                        panSozialsystem.Width = this.minControlSize.Width;
                        panSozialsystem.Height = this.minControlSize.Height;

                        //panSozialsystem.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                        //panSozialsystem.Dock = DockStyle.Fill;
                        isPanelDocking = true;
                    }
                }
                else
                {
                    if (isPanelDocking)
                    {
                        panSozialsystem.Dock = DockStyle.None;
                        panSozialsystem.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                        isPanelDocking = false;
                    }

                    if (this.Width > this.minControlSize.Width)
                    {
                        panSozialsystem.Width = this.Width;
                    }
                    else
                    {
                        panSozialsystem.Width = this.minControlSize.Width;
                    }

                    if (this.Height > this.minControlSize.Height)
                    {
                        panSozialsystem.Height = this.Height;
                    }
                    else
                    {
                        panSozialsystem.Height = this.minControlSize.Height;
                    }
                }
            }
             * */
        }

        #endregion
    }
}