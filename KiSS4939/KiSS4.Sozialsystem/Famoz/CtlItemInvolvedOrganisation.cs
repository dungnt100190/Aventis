using System;
using System.Windows.Forms;
using KiSS4.DB;

namespace KiSS4.Sozialsystem.Famoz
{
    /// <summary>
    /// The container to paint for a single "involvierte Stelle" in Sozialsystem
    /// </summary>
    public class CtlItemInvolvedOrganisation : CtlBaseItem
    {
        private static readonly log4net.ILog LOG = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region Fields

        /// <summary>
        /// Use this flag to setup a test panel only
        /// </summary>
        private bool isTestOnly = false;

        /// <summary>
        /// The involved organisation's name
        /// </summary>
        private string name = "";

        /// <summary>
        /// The involved organisation's address
        /// </summary>
        private string address = "";

        /// <summary>
        /// The involved organisation's contactperson
        /// </summary>
        private string contactPerson = "";

        /// <summary>
        /// The involved organisation's contact
        /// </summary>
        private string contact = "";

        /// <summary>
        /// The primary key of the client of  this involved person
        /// </summary>
        public int PersonID = 0;


        // controls
        private ToolTip ttpClientAge = new ToolTip();
        private PictureBox picIcon;
        private ToolTip ttpName;
        private System.ComponentModel.IContainer components;
        private ToolTip ttpAddress;
        private ToolTip ttpContactPerson;
        private Label lblName;
        private Label lblAddress;
        private Label lblContact;
        private ToolTip ttpContact;
        private Label lblContactPerson;

        #endregion

        #region Constructor / Setup / Init

        /// <summary>
        /// Default empty constructor (only for test and designer purpose)
        /// </summary>
        public CtlItemInvolvedOrganisation()
        {
            // use some testdata
            this.isTestOnly = true;
            this.InitItemInvolvedPerson("Name", "3013 Bern", "Kontaktperson", "031 998 43 20", 0);
        }

        /// <summary>
        /// Constructor for a new CtlItemInvolvedOrganisation
        /// </summary>
        /// <param name="name">The involved organisation's name</param>
        /// <param name="address">The involved organisation's address</param>
        /// <param name="contactPerson">The involved organisation's contact person</param>
        /// <param name="contact">The involved organisation's contact</param>
        public CtlItemInvolvedOrganisation(string name, string address, string contactPerson, string contact, int personID)
        {   
            // init new item
            this.InitItemInvolvedPerson(name, address, contactPerson, contact, personID);
        }

        /// <summary>
        /// Init a new CtlItemInvolvedOrganisation
        /// </summary>
        /// <param name="name">The involved organisation's name</param>
        /// <param name="address">The involved organisation's address</param>
        /// <param name="contactPerson">The involved organisation's contact person</param>
        /// <param name="contact">The involved organisation's contact</param>
        private void InitItemInvolvedPerson(string name, string address, string contactPerson, string contact, int personID)
        {
            // validate parameters
            //TODO: need?
            
            // apply parameters to fields
            this.name = name;
            this.address = address;
            this.contactPerson = contactPerson;
            this.contact = contact;
            this.PersonID = personID;

            // init components
            InitializeComponent();

            // setup control
            base.BaseBackColor = System.Drawing.Color.White;

            // init tooltips
            this.ttpName.ToolTipTitle = KissMsg.GetMLMessage("CtlItemInvolvedOrganisation", "ToolTipTitleName", "Name");
            this.ttpAddress.ToolTipTitle = KissMsg.GetMLMessage("CtlItemInvolvedOrganisation", "ToolTipTitleAddress", "Adresse");
            this.ttpContactPerson.ToolTipTitle = KissMsg.GetMLMessage("CtlItemInvolvedOrganisation", "ToolTipTitleContactPerson", "Kontaktperson");
            this.ttpContact.ToolTipTitle = KissMsg.GetMLMessage("CtlItemInvolvedOrganisation", "ToolTipTitleContact", "Kontakt");

            // setup controls
            // TODO: für Christoph
            // ev. wird das nicht mehr verwendet....
            this.SetupLabels();

            // ....habe hier nun Höhe des Controls neu errechnet, da vorher fehlerhaft:
            int ctlHeight = 0;
            int LineHeight = lblAddress.Location.Y - lblName.Location.Y;
            if (name != "") ctlHeight += LineHeight;
            if (address != "") ctlHeight += LineHeight;
            if (contactPerson != "") ctlHeight += LineHeight;
            if (contact != "") ctlHeight += LineHeight;
            ctlHeight += (2 * lblName.Location.Y);  // Rand oben und unten
            if (ctlHeight < picIcon.Size.Height + (2 * lblName.Location.Y)) 
                ctlHeight = picIcon.Size.Height + (2 * lblName.Location.Y);
            this.Height = ctlHeight;

            
            this.SetupIcon();
            base.CenterIcon(this, picIcon);

            // testing only - show controls with background color
            if (this.isTestOnly)
            {
                this.picIcon.BackColor = System.Drawing.Color.LightBlue;
                this.lblName.BackColor = this.picIcon.BackColor;
                this.lblAddress.BackColor = this.picIcon.BackColor;
                this.lblContactPerson.BackColor = this.picIcon.BackColor;
                this.lblContact.BackColor = this.picIcon.BackColor;
            }
        }

        /// <summary>
        /// Initialize components
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.ttpName = new System.Windows.Forms.ToolTip(this.components);
            this.ttpAddress = new System.Windows.Forms.ToolTip(this.components);
            this.ttpContactPerson = new System.Windows.Forms.ToolTip(this.components);
            this.lblName = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblContactPerson = new System.Windows.Forms.Label();
            this.lblContact = new System.Windows.Forms.Label();
            this.ttpContact = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // picIcon
            // 
            this.picIcon.BackColor = System.Drawing.Color.Transparent;
            this.picIcon.Location = new System.Drawing.Point(7, 5);
            this.picIcon.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(32, 32);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIcon.TabIndex = 0;
            this.picIcon.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.AutoEllipsis = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Location = new System.Drawing.Point(43, 5);
            this.lblName.Margin = new System.Windows.Forms.Padding(3, 5, 5, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(112, 14);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            // 
            // lblAddress
            // 
            this.lblAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAddress.AutoEllipsis = true;
            this.lblAddress.BackColor = System.Drawing.Color.Transparent;
            this.lblAddress.Location = new System.Drawing.Point(42, 23);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(3, 5, 5, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(112, 14);
            this.lblAddress.TabIndex = 1;
            this.lblAddress.Text = "Address";
            // 
            // lblContactPerson
            // 
            this.lblContactPerson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContactPerson.AutoEllipsis = true;
            this.lblContactPerson.BackColor = System.Drawing.Color.Transparent;
            this.lblContactPerson.Location = new System.Drawing.Point(42, 41);
            this.lblContactPerson.Margin = new System.Windows.Forms.Padding(3, 5, 5, 0);
            this.lblContactPerson.Name = "lblContactPerson";
            this.lblContactPerson.Size = new System.Drawing.Size(112, 14);
            this.lblContactPerson.TabIndex = 1;
            this.lblContactPerson.Text = "ContactPerson";
            // 
            // lblContact
            // 
            this.lblContact.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContact.AutoEllipsis = true;
            this.lblContact.BackColor = System.Drawing.Color.Transparent;
            this.lblContact.Location = new System.Drawing.Point(42, 59);
            this.lblContact.Margin = new System.Windows.Forms.Padding(3, 5, 5, 5);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(112, 14);
            this.lblContact.TabIndex = 1;
            this.lblContact.Text = "Phone/Email";
            // 
            // CtlItemInvolvedOrganisation
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(255)))), ((int)(((byte)(235)))));
            this.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(255)))), ((int)(((byte)(185)))));
            this.BaseBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(255)))), ((int)(((byte)(235)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.lblContactPerson);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picIcon);
            this.Curvature = 15;
            this.CurveMode = ((KiSS4.Sozialsystem.CornerCurveMode)((KiSS4.Sozialsystem.CornerCurveMode.TopLeft | KiSS4.Sozialsystem.CornerCurveMode.BottomLeft)));
            this.FocusElement = true;
            this.GradientMode = KiSS4.Sozialsystem.LinearGradientMode.Horizontal;
            this.Name = "CtlItemInvolvedOrganisation";
            this.Size = new System.Drawing.Size(160, 78);
            this.ItemLostFocus += new System.EventHandler(this.CtlItemInvolvedOrganisation_ItemLostFocus);
            this.ItemGotFocus += new System.EventHandler(this.CtlItemInvolvedOrganisation_ItemGotFocus);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Setup icon for the involved organisation. Icon is always the same.
        /// </summary>
        private void SetupIcon()
        {
            try
            {
                // do nothing in design mode
                if (DesignMode)
                {
                    return;
                }

                // apply icon
                // woman
                this.picIcon.Image = Gui.KissImageList.GetLargeImage(190);
            }
            catch (Exception ex)
            {
                // Eintrag ins Log.
                LOG.ErrorFormat("Fehler in: [{0}]. Exception: [{1}]", GetType().FullName, ex.Message);

                // Eintrag ins Log (Ansicht unter Anwendung/Newod Schnittstelle/Protokolle)
                XLog.Create(GetType().FullName, LogLevel.ERROR, ex.Message);

                // stop if debugger attached
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    System.Diagnostics.Debugger.Break();
                }
            }
        }

        /// <summary>
        /// Setup labels with defined vars
        /// </summary>
        private void SetupLabels()
        {
            // common labels
            this.lblName.Text = this.name;
            this.lblAddress.Text = this.address;
            this.lblContactPerson.Text = this.contactPerson;
            this.lblContact.Text = this.contact;

            // tooltips
            this.ttpName.SetToolTip(this.lblName, this.name);
            this.ttpAddress.SetToolTip(this.lblAddress, this.address);
            this.ttpContactPerson.SetToolTip(this.lblContactPerson, this.contactPerson);
            this.ttpContact.SetToolTip(this.lblContact, this.contact);

            // show hide labels
            base.HideLabel(this, 42, lblName, lblAddress, lblContactPerson, lblContact);
            base.HideLabel(this, 42, lblAddress, lblContactPerson, lblContact);
            base.HideLabel(this, 42, lblContactPerson, lblContact);
            base.HideLabel(this, 42, lblContact);
        }

        #endregion        

        private void CtlItemInvolvedOrganisation_ItemGotFocus(object sender, EventArgs e)
        {
            if (this.BackColor2 != this.GetColor(BoxColors.InvOrg_Focused))
            {
                this.BackColor2 = this.GetColor(BoxColors.InvOrg_Focused);
                this.Invalidate();
            }

            // Damit immer der Rahmen des betroffenenen Klient dick ist:
            int idx = this.Parent.Parent.Controls.IndexOfKey("panClients");
            if (idx < 0) return;
            Panel pnl = (this.Parent.Parent.Controls[idx] as Panel);
            for (int c = 0; c < pnl.Controls.Count; c++)
                if (pnl.Controls[c] is CtlItemClient)
                {
                    CtlItemClient ctl = (pnl.Controls[c] as CtlItemClient);
                    ctl.ShowBoldBorder((ctl.PersonID == this.PersonID));
                }
        }

        private void CtlItemInvolvedOrganisation_ItemLostFocus(object sender, EventArgs e)
        {
            if (this.BackColor2 != this.GetColor(BoxColors.InvOrg_Normal))
            {
                this.BackColor2 = this.GetColor(BoxColors.InvOrg_Normal);
                this.Invalidate();
            }

            // Rahmen zurücksetzen:
            int idx = this.Parent.Parent.Controls.IndexOfKey("panClients");
            if (idx < 0) return;
            Panel pnl = (this.Parent.Parent.Controls[idx] as Panel);
            for (int c = 0; c < pnl.Controls.Count; c++)
                if (pnl.Controls[c] is CtlItemClient)
                {
                    CtlItemClient ctl = (pnl.Controls[c] as CtlItemClient);
                    ctl.ShowBoldBorder(false);
                }
        }
    }
}