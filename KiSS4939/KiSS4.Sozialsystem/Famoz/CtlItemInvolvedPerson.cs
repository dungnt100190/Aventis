using System;
using System.Windows.Forms;
using KiSS4.DB;

namespace KiSS4.Sozialsystem.Famoz
{
    /// <summary>
    /// The container to paint for a single "involvierte Person" in Sozialsystem
    /// </summary>
    public class CtlItemInvolvedPerson : CtlBaseItem
    {
        private static readonly log4net.ILog LOG = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region Fields

        /// <summary>
        /// Use this flag to setup a test panel only
        /// </summary>
        private bool isTestOnly = false;

        /// <summary>
        /// The involved person's name
        /// </summary>
        private string name = "";

        /// <summary>
        /// The involved person's gender (1=m, 2=w, else=unknown)
        /// </summary>
        private int gender = -1;

        /// <summary>
        /// The involved person's function
        /// </summary>
        private string function = "";

        /// <summary>
        /// The involved person's contact
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
        private ToolTip ttpFunction;
        private ToolTip ttpContact;
        private Label lblName;
        private Label lblFunction;
        private Label lblContact;

        #endregion

        #region Constructor / Setup / Init

        /// <summary>
        /// Default empty constructor (only for test and designer purpose)
        /// </summary>
        public CtlItemInvolvedPerson()
        {
            // use some testdata
            this.isTestOnly = true;
            this.InitItemInvolvedPerson("Name", 1, "Funktion", "031 998 43 20", 0);
        }

        /// <summary>
        /// Constructor for a new CtlItemInvolvedPerson
        /// </summary>
        /// <param name="name">The involved person's name</param>
        /// <param name="gender">The involved person's gender (1=m, 2=w, else=unknown)</param>
        /// <param name="function">The involved person's function</param>
        /// <param name="contact">The involved person's contact</param>
        public CtlItemInvolvedPerson(string name, int gender, string function, string contact, int personID)
        {   
            // init new item
            this.InitItemInvolvedPerson(name, gender, function, contact, personID);
        }

        /// <summary>
        /// Init a new CtlItemInvolvedPerson
        /// </summary>
        /// <param name="name">The involved person's name</param>
        /// <param name="gender">The involved person's gender (1=m, 2=w, else=unknown)</param>
        /// <param name="function">The involved person's function</param>
        /// <param name="contact">The involved person's contact</param>
        private void InitItemInvolvedPerson(string name, int gender, string function, string contact, int personID)
        {
            // validate parameters
            //TODO: need?
            
            // apply parameters to fields
            this.name = name;
            this.gender = gender;
            this.function = function;
            this.contact = contact;
            this.PersonID = personID;

            // init components
            InitializeComponent();

            // setup control
            base.BaseBackColor = System.Drawing.Color.White;

            // init tooltips
            this.ttpName.ToolTipTitle = KissMsg.GetMLMessage("CtlItemInvolvedPerson", "ToolTipTitleName", "Name");
            this.ttpFunction.ToolTipTitle = KissMsg.GetMLMessage("CtlItemInvolvedPerson", "ToolTipTitleFunction", "Funktion");
            this.ttpContact.ToolTipTitle = KissMsg.GetMLMessage("CtlItemInvolvedPerson", "ToolTipTitleContact", "Kontakt");

            // setup controls
            this.SetupLabels();
            this.SetupIcon();
            base.CenterIcon(this, picIcon);

            // testing only - show controls with background color
            if (this.isTestOnly)
            {
                this.picIcon.BackColor = System.Drawing.Color.LightBlue;
                this.lblName.BackColor = this.picIcon.BackColor;
                this.lblFunction.BackColor = this.picIcon.BackColor;
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
            this.ttpFunction = new System.Windows.Forms.ToolTip(this.components);
            this.ttpContact = new System.Windows.Forms.ToolTip(this.components);
            this.lblName = new System.Windows.Forms.Label();
            this.lblFunction = new System.Windows.Forms.Label();
            this.lblContact = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // picIcon
            // 
            this.picIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picIcon.BackColor = System.Drawing.Color.Transparent;
            this.picIcon.Location = new System.Drawing.Point(121, 5);
            this.picIcon.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
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
            this.lblName.Location = new System.Drawing.Point(5, 5);
            this.lblName.Margin = new System.Windows.Forms.Padding(5, 5, 3, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(112, 14);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            // 
            // lblFunction
            // 
            this.lblFunction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFunction.AutoEllipsis = true;
            this.lblFunction.BackColor = System.Drawing.Color.Transparent;
            this.lblFunction.Location = new System.Drawing.Point(5, 23);
            this.lblFunction.Margin = new System.Windows.Forms.Padding(5, 5, 3, 0);
            this.lblFunction.Name = "lblFunction";
            this.lblFunction.Size = new System.Drawing.Size(112, 14);
            this.lblFunction.TabIndex = 1;
            this.lblFunction.Text = "Function";
            // 
            // lblContact
            // 
            this.lblContact.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContact.AutoEllipsis = true;
            this.lblContact.BackColor = System.Drawing.Color.Transparent;
            this.lblContact.Location = new System.Drawing.Point(5, 41);
            this.lblContact.Margin = new System.Windows.Forms.Padding(5, 5, 3, 5);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(112, 14);
            this.lblContact.TabIndex = 1;
            this.lblContact.Text = "Phone/Email";
            // 
            // CtlItemInvolvedPerson
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.BaseBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.lblFunction);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picIcon);
            this.Curvature = 15;
            this.CurveMode = ((KiSS4.Sozialsystem.CornerCurveMode)((KiSS4.Sozialsystem.CornerCurveMode.TopRight | KiSS4.Sozialsystem.CornerCurveMode.BottomRight)));
            this.FocusElement = true;
            this.GradientMode = KiSS4.Sozialsystem.LinearGradientMode.Horizontal;
            this.Name = "CtlItemInvolvedPerson";
            this.Size = new System.Drawing.Size(160, 60);
            this.ItemLostFocus += new System.EventHandler(this.CtlItemInvolvedPerson_ItemLostFocus);
            this.ItemGotFocus += new System.EventHandler(this.CtlItemInvolvedPerson_ItemGotFocus);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Setup icon for the involved person. Icon depends on gender of person.
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

                // setup iconName from XIcon depending on gender
                switch (this.gender)
                {
                    case 1:
                        // male
                        this.picIcon.Image = Gui.KissImageList.GetLargeImage(136);
                        break;

                    case 2:
                        // female
                        this.picIcon.Image = Gui.KissImageList.GetLargeImage(135);
                        break;

                    default:
                        // no icon defined
                        this.picIcon.Image = null;
                        break;
                }
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
            this.lblFunction.Text = this.function;
            this.lblContact.Text = this.contact;

            // tooltips
            this.ttpName.SetToolTip(this.lblName, this.name);
            this.ttpFunction.SetToolTip(this.lblFunction, this.function);
            this.ttpContact.SetToolTip(this.lblContact, this.contact);
            
            // show hide labels
            base.HideLabel(this, 42, lblName, lblFunction, lblContact);
            base.HideLabel(this, 42, lblFunction, lblContact);
            base.HideLabel(this, 42, lblContact);
        }

        #endregion        

        private void CtlItemInvolvedPerson_ItemGotFocus(object sender, EventArgs e)
        {
            if (this.BackColor != this.GetColor(BoxColors.InvPerson_Focused))
            {
                this.BackColor = this.GetColor(BoxColors.InvPerson_Focused);
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

        private void CtlItemInvolvedPerson_ItemLostFocus(object sender, EventArgs e)
        {
            if (this.BackColor != this.GetColor(BoxColors.InvPerson_Normal))
            {
                this.BackColor = this.GetColor(BoxColors.InvPerson_Normal);
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