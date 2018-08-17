using System;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Common.ZH
{
    public partial class CtlOrgUnitTeamUser : KissComplexControl
    {
        private bool _bShowUser = true;

        private int _lLableWidth = 113;

        private bool _setUserOnNewSearch;

        private string _strParentControl = "";

        private bool _sucheUserIDEditValueChanged;

        public CtlOrgUnitTeamUser()
        {
            InitializeComponent();

            if (Session.User != null)
            {
                qryOrgUnitTeam.Fill(Session.User["OrgUnitID"]);
            }
        }

        public event EventHandler UserModifiedFldMA;

        public event EventHandler UserModifiedFldOE;

        public event EventHandler UserModifiedFldTeam;

        public int LableWidth
        {
            get
            {
                return _lLableWidth;
            }

            set
            {
                _lLableWidth = value;

                edtSucheGruppe.Left = _lLableWidth;
                edtSucheTeam.Left = _lLableWidth;
                edtSucheUserID.Left = _lLableWidth;

                edtSucheGruppe.Width = Size.Width - _lLableWidth;
                edtSucheTeam.Width = Size.Width - _lLableWidth;
                edtSucheUserID.Width = Size.Width - _lLableWidth;
            }
        }

        /// <summary>
        /// If set, then the UserID field will be set to the currently logged in user when NewSearch() is called
        /// </summary>
        public bool SetUserOnNewSearch
        {
            get { return _setUserOnNewSearch; }
            set { _setUserOnNewSearch = value; }
        }

        public bool ShowUser
        {
            get
            {
                return _bShowUser;
            }

            set
            {
                _bShowUser = value;

                if (_bShowUser)
                {
                    lblSucheUserID.Visible = true;
                    edtSucheUserID.Visible = true;
                    Height = edtSucheUserID.Top + edtSucheUserID.Height;
                }
                else
                {
                    lblSucheUserID.Visible = false;
                    edtSucheUserID.Visible = false;
                    Height = edtSucheTeam.Top + edtSucheTeam.Height;
                }
            }
        }

        public KissLookUpEdit SucheGruppe
        {
            get { return edtSucheGruppe; }
        }

        public KissLookUpEdit SucheTeam
        {
            get { return edtSucheTeam; }
        }

        public KissButtonEdit SucheUserID
        {
            get { return edtSucheUserID; }
        }

        public void CheckPendingSearchValue()
        {
            edtSucheUserID.CheckPendingSearchValue();
        }

        public void Init()
        {
            // Nachsehen wie unser Parentcontrol heisst und in der Variable "strParentControl" ablegen
            Control objParent = this;
            while (objParent != null && (!(typeof(KissQueryControl) == objParent.GetType().BaseType)
                                     && (!(typeof(KissSearchForm) == objParent.GetType().BaseType)))
                                     && (!(typeof(KissSearchUserControl) == objParent.GetType().BaseType)))
            {
                //KissMsg.ShowInfo(objParent.GetType().BaseType.ToString());
                objParent = objParent.Parent;
            }

            // Wenn es einen Parent gibt, den Namen auslesen zwecks Rechteüberprüfung
            if (objParent != null)
                _strParentControl = objParent.Name;
            else
                KissMsg.ShowError("Diese Control kann nur auf einem \"KiSS4.Common.KissQueryControl\" oder \"KiSS4.Common.KissSearchForm\" eingesetzt werden.");

            // Berechtigung überprüfen
            if (!DBUtil.UserHasRight(_strParentControl + "_AuswahlGruppe"))
                edtSucheGruppe.EditMode = EditModeType.ReadOnly;

            if (!DBUtil.UserHasRight(_strParentControl + "_AuswahlTeam"))
                edtSucheTeam.EditMode = EditModeType.ReadOnly;
        }

        public void NewSearch()
        {
            // Rechte setzten
            Init();

            // Vorauswahl vornehmen
            try
            {
                // Auswahl auf eigene Gruppe beschränken
                if (!DBUtil.UserHasRight(_strParentControl + "_AuswahlGruppe"))
                    edtSucheGruppe.EditValue = qryOrgUnitTeam["TeamCode"];

                // Auswahl auf eigenes Team beschränken
                if (!DBUtil.UserHasRight(_strParentControl + "_AuswahlTeam"))
                    edtSucheTeam.EditValue = qryOrgUnitTeam["OrgUnitID"];

                // Eigenen Name vorschlagen
                if (_setUserOnNewSearch || !(DBUtil.UserHasRight(_strParentControl + "_AuswahlGruppe") && DBUtil.UserHasRight(_strParentControl + "_AuswahlTeam")))
                {
                    // Login-User vorschlagen
                    edtSucheUserID.EditValue = DBUtil.ExecuteScalarSQL("select DisplayText from vwUser where UserID = {0}", Session.User.UserID);
                    edtSucheUserID.LookupID = Session.User.UserID;
                }
                // Bei Zentrumsleitern (diejenige die die Rechte AuswahlGruppe und AuswahlTeam haben) wird kein Name vorgeschlagen
                else
                {
                    // Login-User leer lassen
                    edtSucheUserID.EditValue = DBNull.Value;
                    edtSucheUserID.LookupID = DBNull.Value;
                }
            }
            catch { }

            // Fokus setzten
            edtSucheUserID.Focus();
        }

        /// <summary>
        /// Raises the <see cref="E:UserModifiedFldMA"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnUserModifiedFldMA(EventArgs e)
        {
            if (UserModifiedFldMA != null) UserModifiedFldMA(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:UserModifiedFldOE"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnUserModifiedFldOE(EventArgs e)
        {
            if (UserModifiedFldOE != null) UserModifiedFldOE(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:UserModifiedFldTeam"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnUserModifiedFldTeam(EventArgs e)
        {
            if (UserModifiedFldTeam != null) UserModifiedFldTeam(this, e);
        }

        private void edtSucheGruppe_EditValueChanged(object sender, EventArgs e)
        {
            edtSucheTeam.LOVFilter = (string)DBUtil.ExecuteScalarSQL(@"
                     SELECT Filter = IsNull(Value1, '')
                     FROM XLOVCode
                     WHERE LOVName = 'QuOrgUnitGroup' AND Code = {0}
                     UNION ALL SELECT 'FF'", edtSucheGruppe.EditValue);
            edtSucheTeam.LOVName = "QuOrgUnitTeam";

            edtSucheTeam.EditValue = DBNull.Value;
            edtSucheUserID.LookupID = DBNull.Value;
            edtSucheUserID.EditValue = DBNull.Value;

            // Fire Event
            OnUserModifiedFldOE(EventArgs.Empty);
        }

        private void edtSucheTeam_EditValueChanged(object sender, EventArgs e)
        {
            edtSucheUserID.LookupID = DBNull.Value;
            edtSucheUserID.EditValue = DBNull.Value;

            // Fire Event
            OnUserModifiedFldTeam(EventArgs.Empty);
        }

        private void edtSucheUserID_EditValueChanged(object sender, EventArgs e)
        {
            _sucheUserIDEditValueChanged = true;
        }

        private void edtSucheUserID_Enter(object sender, EventArgs e)
        {
            _sucheUserIDEditValueChanged = false;
        }

        private void edtSucheUserID_Leave(object sender, EventArgs e)
        {
            if (_sucheUserIDEditValueChanged)
            {
                OnUserModifiedFldMA(EventArgs.Empty);
            }
            _sucheUserIDEditValueChanged = false;
        }

        private void edtSucheUserID_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            // Begin Rule
            // ControlName: edtSucheUserID, RuleType: IKissUserModified_UserModifiedFld
            string searchString = edtSucheUserID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                    searchString = "%";
                else
                {
                    edtSucheUserID.LookupID = DBNull.Value;
                    edtSucheUserID.EditValue = DBNull.Value;
                    return;
                }
            }

            string whereAddOn = "";
            if (!DBUtil.IsEmpty(edtSucheGruppe.EditValue) || !DBUtil.IsEmpty(edtSucheTeam.EditValue))
            {
                string gruppeText = DBUtil.IsEmpty(edtSucheGruppe.EditValue) ? "null" : edtSucheGruppe.EditValue.ToString();
                string teamText = DBUtil.IsEmpty(edtSucheTeam.EditValue) ? "null" : edtSucheTeam.EditValue.ToString();
                whereAddOn = " and OrgUnitID in (select OrgUnitID from dbo.fnOrgUnitsOfTeam(" + gruppeText + "," + teamText + ")) ";
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
              SELECT ID$ = UserID,
                [Kürzel] = LogonName,
                [Mitarbeiter/in] = NameVorname,
                [Org.Einheit] = OrgUnit,
                DisplayText$ = DisplayText
              FROM   vwUser
              WHERE  DisplayText LIKE '%' + {0} + '%' " + whereAddOn + @"
              ORDER BY NameVorname",
              searchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                if (DBUtil.UserHasRight(_strParentControl + "_AuswahlGruppe"))
                    edtSucheGruppe.EditValue = null;

                if (DBUtil.UserHasRight(_strParentControl + "_AuswahlTeam"))
                    edtSucheTeam.EditValue = null;

                edtSucheUserID.LookupID = dlg["ID$"];
                edtSucheUserID.EditValue = dlg["DisplayText$"].ToString();
            }

            // Fire Event
            OnUserModifiedFldMA(EventArgs.Empty);

            _sucheUserIDEditValueChanged = false;
        }
    }
}