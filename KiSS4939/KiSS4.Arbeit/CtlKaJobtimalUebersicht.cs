using System;
using System.Drawing;

using Kiss.Interfaces.UI;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    partial class CtlKaJobtimalUebersicht : KissUserControl
    {
        #region Fields

        #region Private Fields

        private int _baPersonID = -1;
        private int _faLeistungID = -1;
        private bool _isFillJobtimal;
        private bool _mayClose;
        private bool _mayDel;
        private bool _mayIns;
        private bool _mayRead;
        private bool _mayReopen;
        private bool _mayUpd;
        private bool _userUpdAustritt;

        #endregion

        #endregion

        #region Constructors

        public CtlKaJobtimalUebersicht()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void btnZurueksetzen_Click(object sender, EventArgs e)
        {
            if (KissMsg.ShowQuestion("CtlKaJobtimalUebersicht", "WerteZuruecksetzen", "Wollen sie die Daten zurücksetzen?"))
            {
                edtAustrittdatum.EditValue = null;
                edtAustrittsgrund.EditValue = null;
                edtDossierRetourAnSDGrundCode.EditValue = null;

                edtAustrittdatum.EditMode = EditModeType.Normal;
                edtAustrittsgrund.EditMode = EditModeType.Normal;
                edtDossierRetourAnSDGrundCode.EditMode = EditModeType.ReadOnly;
            }
        }

        private void CtlKaJobtimalUebersicht_Load(object sender, EventArgs e)
        {
            if (KaUtil.GetSichtbarSDFlag(_baPersonID) == 1)
            {
                qryJobtimal.EnableBoundFields(false);
                btnZurueksetzen.Enabled = false;
            }
        }

        private void edtAustrittsgrund_SelectedIndexChanged(object sender, EventArgs e)
        {
            // update dropdown
            SetAustrittEditmode();
        }

        private void edtZuweiser_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var searchString = edtZuweiser.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryJobtimal["ZuweiserID"] = DBNull.Value;
                    qryJobtimal["Zuweiser"] = DBNull.Value;
                    qryJobtimal["ZuweiserDet"] = DBNull.Value;
                    return;
                }
            }

            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                            SELECT BeratID$     = OKO.BaInstitutionKontaktID,
                                    Name         = OKO.Name + ISNULL(', ' + OKO.Vorname,''),
                                    Institution  = ORG.Name,
                                    Tel          = OKO.Telefon,
                                    Fax          = OKO.Fax,
                                    Email        = OKO.Email,
                                    ZuweiserDet$ = ISNULL(ORG.Name, '') + ISNULL(', ' + OKO.Telefon, '') + ISNULL(', ' + OKO.Email, '')
                            FROM BaInstitutionKontakt  OKO WITH (READUNCOMMITTED)
                                INNER JOIN BaInstitution ORG WITH (READUNCOMMITTED) ON ORG.BaInstitutionID = OKO.BaInstitutionID
                            WHERE OKO.Name + ISNULL(', ' + OKO.Vorname,'') LIKE '%' + {0} + '%'

                            UNION ALL

                            SELECT BeratID$     = -USR.UserID,
                                    Name         = USR.LastName + ISNULL(', ' + USR.FirstName,''),
                                    Institution  = XOU.ItemName,
                                    Tel          = USR.Phone,
                                    Fax          = '',
                                    Email        = USR.Email,
                                    ZuweiserDet$ = ISNULL(XOU.ItemName, '') + ISNULL(', ' + USR.Phone, '') + ISNULL(', ' + USR.Email, '')
                            FROM XUser                USR WITH (READUNCOMMITTED)
                                LEFT JOIN XOrgUnit_User OUU WITH (READUNCOMMITTED) ON OUU.UserID = USR.UserID AND (OUU.OrgUnitMemberCode = 1 OR OUU.OrgUnitMemberCode = 2)
                                LEFT JOIN XOrgUnit      XOU WITH (READUNCOMMITTED) ON XOU.OrgUnitID = OUU.OrgUnitID
                            WHERE USR.LastName + ISNULL(', ' + USR.FirstName,'') LIKE '%' + {0} + '%'
                            ORDER BY Name",
              searchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                qryJobtimal["ZuweiserID"] = dlg[0];
                qryJobtimal["Zuweiser"] = dlg[1];
                qryJobtimal["ZuweiserDet"] = dlg[6];
            }
        }

        private void qryJobtimal_AfterFill(object sender, EventArgs e)
        {
            SetAustrittEditmode();
        }

        private void qryJobtimal_BeforePost(object sender, EventArgs e)
        {
            if (!DBUtil.IsEmpty(edtAustrittdatum.EditValue))
            {
                DBUtil.CheckNotNullField(edtAustrittsgrund, "aus Vermittlung / aus Einsatz");
                DBUtil.CheckNotNullField(edtDossierRetourAnSDGrundCode, lblGrundDossierRetourAnSD.Text);
            }

            if (!DBUtil.IsEmpty(edtAustrittsgrund.EditValue))
            {
                DBUtil.CheckNotNullField(edtAustrittdatum, lblDatumAbschluss.Text);
                DBUtil.CheckNotNullField(edtDossierRetourAnSDGrundCode, lblGrundDossierRetourAnSD.Text);
            }
        }

        private void SetAustrittEditmode()
        {
            if (!_userUpdAustritt)
            {
                edtAustrittsgrund.EditMode = EditModeType.ReadOnly;
                edtAustrittdatum.EditMode = EditModeType.ReadOnly;
                edtDossierRetourAnSDGrundCode.EditMode = EditModeType.ReadOnly;
                btnZurueksetzen.Enabled = false;
                return;
            }

            if (!DBUtil.IsEmpty(edtAustrittdatum.EditValue))
            {
                edtDossierRetourAnSDGrundCode.EditMode = EditModeType.Required;
                edtAustrittsgrund.EditMode = EditModeType.Required;
                edtAustrittdatum.EditMode = EditModeType.Required;
            }
            else
            {
                edtDossierRetourAnSDGrundCode.EditMode = EditModeType.Normal;
                edtAustrittsgrund.EditMode = EditModeType.Normal;
                edtAustrittdatum.EditMode = EditModeType.Normal;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        // ComponentName: qryJobtimal
        public void Init(string maskName, Image maskImage, int faLeistungID, int baPersonID)
        {
            lblTitle.Text = maskName;
            imageTitle.Image = maskImage;
            _faLeistungID = faLeistungID;
            _baPersonID = baPersonID;

            DBUtil.GetFallRights(_faLeistungID, out _mayRead, out _mayIns, out _mayUpd, out _mayDel, out _mayClose, out _mayReopen);
            _userUpdAustritt = _mayUpd;

            if (!JobtimalExists() && DBUtil.UserHasRight("CtlKaJobtimalUebersicht", "UI") && (_mayUpd || _mayIns))
            {
                DBUtil.ExecSQL(@"
                    INSERT INTO dbo.KaJobtimal (FaLeistungID, SichtbarSDFlag, Creator, Created, Modifier, Modified)
                    VALUES ({0}, {1}, {2}, {3}, {2}, {3})",
                    _faLeistungID,
                    KaUtil.IsVisibleSD(_baPersonID),
                    Session.User.CreatorModifier,
                    DateTime.Now);
            }

            // set flag
            _isFillJobtimal = true;

            qryJobtimal.Fill(_faLeistungID, Session.User.IsUserKA ? 0 : 1);

            // reset flag
            _isFillJobtimal = false;

            edtSarModulF.Text = KaUtil.GetSARModulF(_faLeistungID);
        }

        #endregion

        #region Private Methods

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "FALEISTUNGID":
                    return _faLeistungID;

                case "BAPERSONID":
                    return _baPersonID;

                case "OWNERUSERID":
                    return (int)DBUtil.ExecuteScalarSQL("select UserID from FaLeistung where FaLeistungID = {0}", _faLeistungID);
            }

            return base.GetContextValue(fieldName);
        }

        private bool JobtimalExists()
        {
            var rslt = Convert.ToInt32(
                DBUtil.ExecuteScalarSQL(@"SELECT COUNT(*) FROM KaJobtimal WHERE FaLeistungID = {0}",
                                        _faLeistungID)
                            ) > 0;

            return rslt;
        }

        #endregion

        private void edtAustrittdatum_EditValueChanged(object sender, EventArgs e)
        {
            SetAustrittEditmode();
        }

        #endregion
    }
}