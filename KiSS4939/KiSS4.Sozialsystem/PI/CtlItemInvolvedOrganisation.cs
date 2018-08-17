using System;
using System.Windows.Forms;
using KiSS4.DB;

namespace KiSS4.Sozialsystem.PI
{
    /// <summary>
    /// The container to paint for a single "involvierte Stelle" in Sozialsystem
    /// </summary>
    public partial class CtlItemInvolvedOrganisation : CtlBaseItem
    {
        /// <summary>
        /// The primary key of the client of  this involved person
        /// </summary>
        public int PersonID = 0;

        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Use this flag to setup a test panel only
        /// </summary>
        private readonly bool _isTestOnly;

        /// <summary>
        /// The involved organisation's address
        /// </summary>
        private string _address = "";

        /// <summary>
        /// The involved organisation's contactperson
        /// </summary>
        private string _contactPerson = "";

        /// <summary>
        /// The involved organisation's e-mail address
        /// </summary>
        private string _eMail = "";

        /// <summary>
        /// The involved organisation's name
        /// </summary>
        private string _name = "";

        /// <summary>
        /// The involved organisation's phone number
        /// </summary>
        private string _phone = "";

        /// <summary>
        /// The involved organisation's relations to the person
        /// </summary>
        private string _relation = "";

        /// <summary>
        /// Default empty constructor (only for test and designer purpose)
        /// </summary>
        public CtlItemInvolvedOrganisation()
        {
            // use some testdata
            _isTestOnly = true;
            InitItemInvolvedOrganisationPI("Name", "3013 Bern", "Kontaktperson", "031 998 43 20", "email@domain.com", "relation", 0);
        }

        /// <summary>
        /// Constructor for a new CtlItemInvolvedOrganisation
        /// </summary>
        /// <param name="name">The involved organisation's name</param>
        /// <param name="address">The involved organisation's address</param>
        /// <param name="contactPerson">The involved organisation's contact person</param>
        /// <param name="contact">The involved organisation's contact</param>
        public CtlItemInvolvedOrganisation(string name, string address, string contactPerson, string contact, string email, string relation, int personID)
        {
            // init new item
            InitItemInvolvedOrganisationPI(name, address, contactPerson, contact, email, relation, personID);
        }

        private void CtlItemInvolvedOrganisation_ItemGotFocus(Object sender, EventArgs e)
        {
            if (BackColor2 != GetColor(BoxColors.InvOrg_Focused))
            {
                BackColor2 = GetColor(BoxColors.InvOrg_Focused);
                Invalidate();
            }

            // Damit immer der Rahmen des betroffenenen Klient dick ist:
            int idx = Parent.Parent.Controls.IndexOfKey("panClients");
            if (idx < 0)
                return;
            Panel pnl = (Parent.Parent.Controls[idx] as Panel);
            for (int c = 0; c < pnl.Controls.Count; c++)
                if (pnl.Controls[c] is CtlItemClient)
                {
                    CtlItemClient ctl = (pnl.Controls[c] as CtlItemClient);
                    ctl.ShowBoldBorder((ctl.PersonID == PersonID));
                }
        }

        private void CtlItemInvolvedOrganisation_ItemLostFocus(object sender, EventArgs e)
        {
            if (BackColor2 != GetColor(BoxColors.InvOrg_Normal))
            {
                BackColor2 = GetColor(BoxColors.InvOrg_Normal);
                Invalidate();
            }

            // Rahmen zurücksetzen:
            int idx = Parent.Parent.Controls.IndexOfKey("panClients");

            if (idx < 0)
            {
                return;
            }

            Panel pnl = (Parent.Parent.Controls[idx] as Panel);

            for (int c = 0; c < pnl.Controls.Count; c++)
            {
                if (pnl.Controls[c] is CtlItemClient)
                {
                    CtlItemClient ctl = (pnl.Controls[c] as CtlItemClient);
                    ctl.ShowBoldBorder(false);
                }
            }
        }

        /// <summary>
        /// Init a new CtlItemInvolvedOrganisation
        /// </summary>
        /// <param name="name">The involved organisation's name</param>
        /// <param name="address">The involved organisation's address</param>
        /// <param name="contactPerson">The involved organisation's contact person</param>
        /// <param name="contact">The involved organisation's contact</param>
        private void InitItemInvolvedOrganisationPI(string name, string address, string contactPerson, string contact, string email, string relation, int personID)
        {
            // validate parameters
            //TODO: need?

            // apply parameters to fields
            _name = name;
            _address = address;
            _contactPerson = contactPerson;
            _phone = contact;
            _eMail = email;
            _relation = relation;
            PersonID = personID;

            // init components
            InitializeComponent();

            // setup control
            BaseBackColor = System.Drawing.Color.White;

            // init tooltips
            ttpName.ToolTipTitle = KissMsg.GetMLMessage("CtlItemInvolvedOrganisation", "ToolTipTitleName", "Name");
            ttpAddress.ToolTipTitle = KissMsg.GetMLMessage("CtlItemInvolvedOrganisation", "ToolTipTitleAddress", "Adresse");
            ttpContactPerson.ToolTipTitle = KissMsg.GetMLMessage("CtlItemInvolvedOrganisation", "ToolTipTitleContactPerson", "Kontaktperson");
            ttpContact.ToolTipTitle = KissMsg.GetMLMessage("CtlItemInvolvedOrganisation", "ToolTipTitleContact", "Kontakt");
            ttpEmail.ToolTipTitle = KissMsg.GetMLMessage("CtlItemInvolvedOrganisation", "ToolTipTitleEmail", "E-Mail");
            ttpRelation.ToolTipTitle = KissMsg.GetMLMessage("CtlItemInvolvedOrganisation", "ToolTipTitleRelation", "Beziehung zu Person");

            // setup controls
            // TODO: für Christoph
            // ev. wird das nicht mehr verwendet....
            SetupLabels();

            // ....habe hier nun Höhe des Controls neu errechnet, da vorher fehlerhaft:
            int ctlHeight = 0;
            int LineHeight = lblAddress.Location.Y - lblName.Location.Y;
            if (name != "")
                ctlHeight += LineHeight;
            if (address != "")
                ctlHeight += LineHeight;
            if (contactPerson != "")
                ctlHeight += LineHeight;
            if (contact != "")
                ctlHeight += LineHeight;
            if (email != "")
                ctlHeight += LineHeight;
            if (relation != "")
                ctlHeight += LineHeight;
            ctlHeight += (2 * lblName.Location.Y);  // Rand oben und unten
            if (ctlHeight < picIcon.Size.Height + (2 * lblName.Location.Y))
                ctlHeight = picIcon.Size.Height + (2 * lblName.Location.Y);
            Height = ctlHeight;

            SetupIcon();
            CenterIcon(this, picIcon);

            // testing only - show controls with background color
            if (_isTestOnly)
            {
                picIcon.BackColor = System.Drawing.Color.LightBlue;
                lblName.BackColor = picIcon.BackColor;
                lblAddress.BackColor = picIcon.BackColor;
                lblContactPerson.BackColor = picIcon.BackColor;
                lblContact.BackColor = picIcon.BackColor;
                lblEmail.BackColor = picIcon.BackColor;
            }
        }

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
                picIcon.Image = Gui.KissImageList.GetLargeImage(190);
            }
            catch (Exception ex)
            {
                // Eintrag ins Log.
                _log.ErrorFormat("Fehler in: [{0}]. Exception: [{1}]", GetType().FullName, ex.Message);

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
            lblName.Text = _name;
            lblAddress.Text = _address;
            lblContactPerson.Text = _contactPerson;
            lblContact.Text = _phone;
            lblEmail.Text = _eMail;
            lblRelation.Text = _relation;

            // tooltips
            ttpName.SetToolTip(lblName, _name);
            ttpAddress.SetToolTip(lblAddress, _address);
            ttpContactPerson.SetToolTip(lblContactPerson, _contactPerson);
            ttpContact.SetToolTip(lblContact, _phone);
            ttpEmail.SetToolTip(lblEmail, _eMail);
            ttpRelation.SetToolTip(lblRelation, _relation);

            // show hide labels
            HideLabel(this, 42, lblName, lblAddress, lblContactPerson, lblContact, lblEmail, lblRelation);
            HideLabel(this, 42, lblAddress, lblContactPerson, lblContact, lblEmail, lblRelation);
            HideLabel(this, 42, lblContactPerson, lblContact, lblEmail, lblRelation);
            HideLabel(this, 42, lblContact, lblEmail, lblRelation);
            HideLabel(this, 42, lblEmail, lblRelation);
            HideLabel(this, 42, lblRelation);
        }
    }
}