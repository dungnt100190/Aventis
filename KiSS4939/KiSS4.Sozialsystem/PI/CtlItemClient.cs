using System;
using System.Windows.Forms;
using KiSS4.DB;

namespace KiSS4.Sozialsystem.PI
{
    /// <summary>
    /// The container to paint for a single "Klient" in Sozialsystem
    /// </summary>
    public class CtlItemClient : CtlBaseItem
    {
        private static readonly log4net.ILog LOG = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region Fields

        /// <summary>
        /// The client's age
        /// </summary>
        private Int32 Age = -1;

        /// <summary>
        /// The client's firstname
        /// </summary>
        private String FirstName = "";

        /// <summary>
        /// The client's gender (1=m, 2=w, else=unknown)
        /// </summary>
        private Int32 Gender = -1;

        /// <summary>
        /// The client's additional info
        /// </summary>
        private String InfoText = "";

        /// <summary>
        /// Flag if client is dead >> used for additional info
        /// </summary>
        private Boolean IsDead = false;

        /// <summary>
        /// Use this flag to setup a test panel only
        /// </summary>
        private Boolean IsTestOnly = false;

        /// <summary>
        /// The client's lastname
        /// </summary>
        private String LastName = "";
        private System.ComponentModel.IContainer components;
        private Label lblAge;
        private Label lblFirstName;
        private Label lblInfoText;
        private Label lblLastName;
        private PictureBox picIcon;
        private ToolTip ttpAge;

        // controls
        private ToolTip ttpClientAge = new ToolTip();
        private ToolTip ttpFirstName;
        private ToolTip ttpInfoText;
        private ToolTip ttpLastName;

        /// <summary>
        /// The client's primary key (table BaPerson)
        /// </summary>
        public Int32 PersonID = 0;

        /// <summary>
        /// All IDs of involved persons, comma separated
        /// </summary>
        public String UserIDs = "";

        #endregion

        #region Constructors

        /// <summary>
        /// Default empty constructor (only for test and designer purpose)
        /// </summary>
        public CtlItemClient()
        {
            // use some testdata
            this.IsTestOnly = true;
            this.InitItemClient(0, "Vorname", "Nachname", 1, 25, "Some InfoText", false, "");
        }

        /// <summary>
        /// Constructor for a new CtlItemClient
        /// </summary>
        /// <param name="firstName">The client's firstname</param>
        /// <param name="lastName"> The client's lastname</param>
        /// <param name="gender">The client's gender (1=m, 2=w, else=unknown)</param>
        /// <param name="age">The client's age</param>
        /// <param name="infoText">The client's additional info</param>
        public CtlItemClient(Int32 personID, String firstName, String lastName, Int32 gender, Int32 age, String infoText, Boolean isDead, String userIDs)
        {
            // init new item
            this.InitItemClient(personID, firstName, lastName, gender, age, infoText, isDead, userIDs);
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Initialize components
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.ttpFirstName = new System.Windows.Forms.ToolTip(this.components);
            this.ttpLastName = new System.Windows.Forms.ToolTip(this.components);
            this.ttpAge = new System.Windows.Forms.ToolTip(this.components);
            this.ttpInfoText = new System.Windows.Forms.ToolTip(this.components);
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblInfoText = new System.Windows.Forms.Label();
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
            // lblFirstName
            // 
            this.lblFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFirstName.AutoEllipsis = true;
            this.lblFirstName.BackColor = System.Drawing.Color.Transparent;
            this.lblFirstName.Location = new System.Drawing.Point(42, 5);
            this.lblFirstName.Margin = new System.Windows.Forms.Padding(3, 5, 5, 0);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(152, 14);
            this.lblFirstName.TabIndex = 1;
            this.lblFirstName.Text = "FirstName";
            // 
            // lblLastName
            // 
            this.lblLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastName.AutoEllipsis = true;
            this.lblLastName.BackColor = System.Drawing.Color.Transparent;
            this.lblLastName.Location = new System.Drawing.Point(42, 23);
            this.lblLastName.Margin = new System.Windows.Forms.Padding(3, 5, 5, 0);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(152, 14);
            this.lblLastName.TabIndex = 1;
            this.lblLastName.Text = "LastName";
            // 
            // lblAge
            // 
            this.lblAge.AutoEllipsis = true;
            this.lblAge.BackColor = System.Drawing.Color.Transparent;
            this.lblAge.Location = new System.Drawing.Point(7, 41);
            this.lblAge.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(32, 14);
            this.lblAge.TabIndex = 1;
            this.lblAge.Text = "Age";
            this.lblAge.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblInfoText
            // 
            this.lblInfoText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfoText.AutoEllipsis = true;
            this.lblInfoText.BackColor = System.Drawing.Color.Transparent;
            this.lblInfoText.Location = new System.Drawing.Point(42, 41);
            this.lblInfoText.Margin = new System.Windows.Forms.Padding(3, 5, 5, 0);
            this.lblInfoText.Name = "lblInfoText";
            this.lblInfoText.Size = new System.Drawing.Size(152, 14);
            this.lblInfoText.TabIndex = 1;
            this.lblInfoText.Text = "Any Text";
            // 
            // CtlItemClient
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(185)))), ((int)(((byte)(185)))));
            this.BaseBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.lblInfoText);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.picIcon);
            this.Curvature = 15;
            this.FocusElement = true;
            this.Name = "CtlItemClient";
            this.Size = new System.Drawing.Size(200, 78);
            this.ItemGotFocus += new System.EventHandler(this.CtlItemClient_ItemGotFocus);
            this.ItemLostFocus += new System.EventHandler(this.CtlItemClient_ItemLostFocus);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region Private Methods

        private void CtlItemClient_ItemGotFocus(object sender, EventArgs e)
        {
            if (this.BackColor2 == this.GetColor(BoxColors.Client_Focused))
                return;
            this.BackColor2 = this.GetColor(BoxColors.Client_Focused);
            this.Invalidate();
        }

        private void CtlItemClient_ItemLostFocus(object sender, EventArgs e)
        {
            if (this.BackColor2 == this.GetColor(BoxColors.Client_Normal))
                return;
            this.BackColor2 = this.GetColor(BoxColors.Client_Normal);
            this.Invalidate();
        }

        /// <summary>
        /// Init a new CtlItemClient
        /// </summary>
        /// <param name="firstName">The client's firstname</param>
        /// <param name="lastName"> The client's lastname</param>
        /// <param name="gender">The client's gender (1=m, 2=w, else=unknown)</param>
        /// <param name="age">The client's age</param>
        /// <param name="infoText">The client's additional info</param>
        private void InitItemClient(Int32 personID, String firstName, String lastName, Int32 gender, Int32 age, String infoText, Boolean isDead, String userIDs)
        {
            // validate parameters
            // Erst wieder einschalten, wenn die Eingabe des Alters beim Erfassen einer Person zwingend ist:
            //if (age < 0)
            //{
            //    throw new ArgumentOutOfRangeException("age", "The age of a person cannot be less than 0");
            //}

            // apply parameters to fields
            this.PersonID = personID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Gender = gender;
            this.Age = age;
            this.InfoText = infoText;
            this.IsDead = isDead;
            this.UserIDs = userIDs;

            // init components
            this.InitializeComponent();

            // setup control
            base.BaseBackColor = System.Drawing.Color.White;

            // init tooltips
            this.ttpFirstName.ToolTipTitle = KissMsg.GetMLMessage("CtlItemClient", "ToolTipTitleFirstName", "Vorname");
            this.ttpLastName.ToolTipTitle = KissMsg.GetMLMessage("CtlItemClient", "ToolTipTitleLastName", "Nachname");
            this.ttpAge.ToolTipTitle = KissMsg.GetMLMessage("CtlItemClient", "ToolTipTitleAge", "Alter");
            this.ttpInfoText.ToolTipTitle = KissMsg.GetMLMessage("CtlItemClient", "ToolTipTitleInfoText", "Informationen");

            // setup controls
            this.SetupIcon();
            this.SetupLabels();

            // testing only - show controls with background color
            if (this.IsTestOnly)
            {
                this.picIcon.BackColor = System.Drawing.Color.LightBlue;
                this.lblFirstName.BackColor = this.picIcon.BackColor;
                this.lblLastName.BackColor = this.picIcon.BackColor;
                this.lblAge.BackColor = this.picIcon.BackColor;
                this.lblInfoText.BackColor = this.picIcon.BackColor;
            }
        }

        /// <summary>
        /// Setup icon for the client. Icon is depending on age and gender.
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

                // init name for icon ("" = no icon)
                String iconName = "";

                // age depending icon
                if (this.Age >= 0 && this.Age <= 3)
                {
                    iconName = "01";
                }
                else if (this.Age <= 8)
                {
                    iconName = "05";
                }
                else if (this.Age <= 15)
                {
                    iconName = "10";
                }
                else if (this.Age <= 25)
                {
                    iconName = "20";
                }
                else if (this.Age <= 35)
                {
                    iconName = "30";
                }
                else if (this.Age <= 45)
                {
                    iconName = "40";
                }
                else if (this.Age <= 55)
                {
                    iconName = "50";
                }
                else if (this.Age <= 65)
                {
                    iconName = "60";
                }
                else
                {
                    iconName = "70";
                }

                // setup iconName from XIcon depending on gender
                if (!DBUtil.IsEmpty(iconName))
                {
                    switch (this.Gender)
                    {
                        case 1:
                            // male
                            this.picIcon.Image = Gui.KissImageList.GetLargeImage(String.Format("m{0}", iconName));
                            break;

                        case 2:
                            // female
                            this.picIcon.Image = Gui.KissImageList.GetLargeImage(String.Format("f{0}", iconName));
                            break;

                        default:
                            // no icon defined
                            this.picIcon.Image = null;
                            break;
                    }
                }
                else
                {
                    // no icon defined
                    this.picIcon.Image = null;
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
            this.lblFirstName.Text = this.FirstName;
            this.lblLastName.Text = this.LastName;
            this.lblInfoText.Text = this.InfoText;

            // tooltips
            this.ttpFirstName.SetToolTip(this.lblFirstName, this.FirstName);
            this.ttpLastName.SetToolTip(this.lblLastName, this.LastName);
            this.ttpInfoText.SetToolTip(this.lblInfoText, this.InfoText);

            // dead
            this.lblAge.Text = this.IsDead ? "†" : "";

            // age
            if (this.Age >= 0)
            {
                this.lblAge.Text = String.Format("{0}{1}", this.lblAge.Text, this.Age);
                this.ttpAge.SetToolTip(this.lblAge, this.lblAge.Text);
            }
            else
            {
                // reset label
                this.lblAge.Text = "";
                this.ttpAge.RemoveAll();
            }
        }

        #endregion
    }
}