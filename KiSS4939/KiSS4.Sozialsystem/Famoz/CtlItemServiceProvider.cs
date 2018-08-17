using System;
using System.Windows.Forms;
using KiSS4.DB;

namespace KiSS4.Sozialsystem.Famoz
{
    /// <summary>
    /// The container to paint for a single "Leistungserbringer" in Sozialsystem
    /// </summary>
    public class CtlItemServiceProvider : CtlBaseItem
    {
        private static readonly log4net.ILog LOG = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region Fields

        /// <summary>
        /// Use this flag to setup a test panel only
        /// </summary>
        private bool isTestOnly = false;

        /// <summary>
        /// The client's primary key (table BaPerson)
        /// </summary>
        public int UserID = 0;

        /// <summary>
        /// The serviceprovider's function
        /// </summary>
        private string function = "";

        /// <summary>
        /// The serviceprovider's name
        /// </summary>
        private string name = "";

        /// <summary>
        /// The serviceprovider's organisationunit
        /// </summary>
        private string organisationUnit = "";

        /// <summary>
        /// The serviceprovider's contact
        /// </summary>
        private string contact = "";

        // controls
        private ToolTip ttpClientAge = new ToolTip();
        private PictureBox picIcon;
        private ToolTip ttpName;
        private System.ComponentModel.IContainer components;
        private ToolTip ttpOrganisationUnit;
        private ToolTip ttpContact;
        private Label lblName;
        private Label lblOrganisationUnit;
        private Label lblFunction;
        private ToolTip ttpFunction;
        private Label lblContact;

        #endregion

        #region Constructor / Setup / Init

        /// <summary>
        /// Default empty constructor (only for test and designer purpose)
        /// </summary>
        public CtlItemServiceProvider()
        {
            // use some testdata
            this.isTestOnly = true;
            this.InitItemServiceProvider("Funktion", "Name", "Abteilung", "031 998 43 20", 0);
        }

        /// <summary>
        /// Constructor for a new CtlItemServiceProvider
        /// </summary>
        /// <param name="function">The serviceprovider's function</param>
        /// <param name="name">The serviceprovider's name</param>
        /// <param name="organisationUnit">The serviceprovider's organisationunit</param>
        /// <param name="contact">The serviceprovider's contact</param>
        public CtlItemServiceProvider(string function, string name, string organisationUnit, string contact, int userID)
        {   
            // init new item
            this.InitItemServiceProvider(function, name, organisationUnit, contact, userID);
        }

        /// <summary>
        /// Init a new CtlItemClient
        /// </summary>
        /// <param name="function">The serviceprovider's function</param>
        /// <param name="name">The serviceprovider's name</param>
        /// <param name="organisationUnit">The serviceprovider's organisationunit</param>
        /// <param name="contact">The serviceprovider's contact</param>
        private void InitItemServiceProvider(string function, string name, string organisationUnit, string contact, int userID)
        {
            // validate parameters
            if (DBUtil.IsEmpty(name))
            {
                throw new ArgumentNullException("name", "The name of a service provider cannot be empty");
            }
            
            // apply parameters to fields
            this.function = function;
            this.name = name;
            this.organisationUnit = organisationUnit;
            this.contact = contact;
            this.UserID = userID;

            // init components
            InitializeComponent();

            // init tooltips
            this.ttpFunction.ToolTipTitle = KissMsg.GetMLMessage("CtlItemServiceProvider", "ToolTipTitleFunction", "Funktion");
            this.ttpName.ToolTipTitle = KissMsg.GetMLMessage("CtlItemServiceProvider", "ToolTipTitleName", "Name");
            this.ttpOrganisationUnit.ToolTipTitle = KissMsg.GetMLMessage("CtlItemServiceProvider", "ToolTipTitleOrganisationUnit", "Organisationseinheit");
            this.ttpContact.ToolTipTitle = KissMsg.GetMLMessage("CtlItemServiceProvider", "ToolTipTitleContact", "Kontakt");

            // setup controls
            this.SetupLabels();
            this.SetupIcon();

            // testing only - show controls with background color
            if (this.isTestOnly)
            {
                this.picIcon.BackColor = System.Drawing.Color.LightBlue;
                this.lblFunction.BackColor = this.picIcon.BackColor;
                this.lblName.BackColor = this.picIcon.BackColor;
                this.lblOrganisationUnit.BackColor = this.picIcon.BackColor;
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
            this.ttpOrganisationUnit = new System.Windows.Forms.ToolTip(this.components);
            this.ttpContact = new System.Windows.Forms.ToolTip(this.components);
            this.lblName = new System.Windows.Forms.Label();
            this.lblOrganisationUnit = new System.Windows.Forms.Label();
            this.lblContact = new System.Windows.Forms.Label();
            this.lblFunction = new System.Windows.Forms.Label();
            this.ttpFunction = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // picIcon
            // 
            this.picIcon.BackColor = System.Drawing.Color.Transparent;
            this.picIcon.Location = new System.Drawing.Point(4, 5);
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
            this.lblName.Location = new System.Drawing.Point(38, 5);
            this.lblName.Margin = new System.Windows.Forms.Padding(3, 5, 5, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(117, 14);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            // 
            // lblOrganisationUnit
            // 
            this.lblOrganisationUnit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOrganisationUnit.AutoEllipsis = true;
            this.lblOrganisationUnit.BackColor = System.Drawing.Color.Transparent;
            this.lblOrganisationUnit.Location = new System.Drawing.Point(37, 23);
            this.lblOrganisationUnit.Margin = new System.Windows.Forms.Padding(3, 5, 5, 0);
            this.lblOrganisationUnit.Name = "lblOrganisationUnit";
            this.lblOrganisationUnit.Size = new System.Drawing.Size(117, 14);
            this.lblOrganisationUnit.TabIndex = 1;
            this.lblOrganisationUnit.Text = "OrganisationUnit";
            // 
            // lblContact
            // 
            this.lblContact.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContact.AutoEllipsis = true;
            this.lblContact.BackColor = System.Drawing.Color.Transparent;
            this.lblContact.Location = new System.Drawing.Point(37, 41);
            this.lblContact.Margin = new System.Windows.Forms.Padding(3, 5, 5, 0);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(117, 14);
            this.lblContact.TabIndex = 1;
            this.lblContact.Text = "Phone/Email";
            // 
            // lblFunction
            // 
            this.lblFunction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFunction.AutoEllipsis = true;
            this.lblFunction.BackColor = System.Drawing.Color.Transparent;
            this.lblFunction.Location = new System.Drawing.Point(5, 5);
            this.lblFunction.Margin = new System.Windows.Forms.Padding(3, 5, 5, 0);
            this.lblFunction.Name = "lblFunction";
            this.lblFunction.Size = new System.Drawing.Size(11, 14);
            this.lblFunction.TabIndex = 1;
            this.lblFunction.Text = "Function";
            this.lblFunction.Visible = false;
            // 
            // CtlItemServiceProvider
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(235)))));
            this.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(185)))));
            this.BaseBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(235)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.lblOrganisationUnit);
            this.Controls.Add(this.lblFunction);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picIcon);
            this.Curvature = 1;
            this.FocusElement = true;
            this.Name = "CtlItemServiceProvider";
            this.Size = new System.Drawing.Size(160, 78);
            this.ItemLostFocus += new System.EventHandler(this.CtlItemServiceProvider_ItemLostFocus);
            this.ItemGotFocus += new System.EventHandler(this.CtlItemServiceProvider_ItemGotFocus);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Setup icon for the service provider. Icon is always the same.
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

                // apply user icon
                this.picIcon.Image = Gui.KissImageList.GetLargeImage(101);
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
            this.lblFunction.Text = this.function;
            this.lblName.Text = this.name;
            this.lblOrganisationUnit.Text = this.organisationUnit;
            this.lblContact.Text = this.contact;

            // tooltips
            this.ttpFunction.SetToolTip(this.lblFunction, this.function);
            this.ttpName.SetToolTip(this.lblName, this.name);
            this.ttpOrganisationUnit.SetToolTip(this.lblOrganisationUnit, this.organisationUnit);
            this.ttpContact.SetToolTip(this.lblContact, this.contact);
        }

        #endregion        

        private void CtlItemServiceProvider_ItemGotFocus(object sender, EventArgs e)
        {
            if (this.BackColor2 != this.GetColor(BoxColors.ServProv_Focused))
            {
                this.BackColor2 = this.GetColor(BoxColors.ServProv_Focused);
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
                    ctl.ShowBoldBorder(ctl.UserIDs.Contains("," + this.UserID.ToString() + ","));
                }
        }

        private void CtlItemServiceProvider_ItemLostFocus(object sender, EventArgs e)
        {
            if (this.BackColor2 != this.GetColor(BoxColors.ServProv_Normal))
            {
                this.BackColor2 = this.GetColor(BoxColors.ServProv_Normal);
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