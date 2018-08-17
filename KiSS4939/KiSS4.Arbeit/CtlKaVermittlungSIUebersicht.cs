using System;
using System.Drawing;

using Kiss.Interfaces.UI;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    partial class CtlKaVermittlungSIUebersicht : KissUserControl
    {
        #region Fields

        #region Private Fields

        private int _baPersonID = -1;
        private int _faLeistungID = -1;
        private bool _mayClose;
        private bool _mayDel;
        private bool _mayIns;
        private bool _mayRead;
        private bool _mayReopen;
        private bool _mayUpd;

        #endregion

        #endregion

        #region Constructors

        public CtlKaVermittlungSIUebersicht()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void btnZurueksetzen_Click(object sender, EventArgs e)
        {
            if (KissMsg.ShowQuestion("CtlKaVermittlungSIUebersicht", "WerteZuruecksetzen", "Wollen sie die Daten zurücksetzen?"))
            {
                edtDossierRetourAnSD.Checked = false;
                qryVermittlungSI["DossierRetourAnSD"] = 0;
                edtDossierRetourAnSDGrundCode.EditValue = DBNull.Value;
                qryVermittlungSI["DossierRetourAnSDGrundCode"] = DBNull.Value;
                edtDossierRetourAnSDGrundCode.EditMode = EditModeType.ReadOnly;
                qryVermittlungSI["AbschlussDatum"] = DBNull.Value;

                edtWechselKaIntern.Checked = false;
                qryVermittlungSI["WechselKAIntern"] = 0;
                edtWechselKaInternGrundCode.EditValue = DBNull.Value;
                qryVermittlungSI["WechselKAInternGrundCode"] = DBNull.Value;
                edtWechselKaInternGrundCode.EditMode = EditModeType.ReadOnly;
            }
        }

        private void CtlKaVermittlungSIUebersicht_Load(object sender, EventArgs e)
        {
            if (KaUtil.GetSichtbarSDFlag(_baPersonID) == 1)
            {
                qryVermittlungSI.EnableBoundFields(false);
                btnZurueksetzen.Enabled = false;
            }
        }

        private void edtDossierRetourAnSD_CheckedChanged(object sender, EventArgs e)
        {
            if (edtDossierRetourAnSD.Checked)
            {
                edtWechselKaIntern.Checked = false;
                edtWechselKaInternGrundCode.EditValue = DBNull.Value;
                edtWechselKaInternGrundCode.EditMode = EditModeType.ReadOnly;

                if (qryVermittlungSI.CanUpdate || _mayUpd)
                {
                    edtDossierRetourAnSDGrundCode.EditMode = EditModeType.Normal;
                }
            }
            else
            {
                edtDossierRetourAnSDGrundCode.EditValue = DBNull.Value;
                edtDossierRetourAnSDGrundCode.EditMode = EditModeType.ReadOnly;
            }
        }

        private void edtWechselKaIntern_CheckedChanged(object sender, EventArgs e)
        {
            if (edtWechselKaIntern.Checked)
            {
                edtDossierRetourAnSD.Checked = false;
                edtDossierRetourAnSDGrundCode.EditValue = DBNull.Value;
                edtDossierRetourAnSDGrundCode.EditMode = EditModeType.ReadOnly;

                if (qryVermittlungSI.CanUpdate || _mayUpd)
                {
                    edtWechselKaInternGrundCode.EditMode = EditModeType.Normal;
                }
            }
            else
            {
                edtWechselKaInternGrundCode.EditValue = DBNull.Value;
                edtWechselKaInternGrundCode.EditMode = EditModeType.ReadOnly;
            }
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
                    qryVermittlungSI["ZuweiserID"] = DBNull.Value;
                    qryVermittlungSI["Zuweiser"] = DBNull.Value;
                    qryVermittlungSI["ZuweiserDet"] = DBNull.Value;
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
                qryVermittlungSI["ZuweiserID"] = dlg[0];
                qryVermittlungSI["Zuweiser"] = dlg[1];
                qryVermittlungSI["ZuweiserDet"] = dlg[6];
            }
        }

        private void qryVermittlungSI_AfterFill(object sender, EventArgs e)
        {
            if (!edtWechselKaIntern.Checked)
            {
                edtWechselKaInternGrundCode.EditValue = DBNull.Value;
                edtWechselKaInternGrundCode.EditMode = EditModeType.ReadOnly;
            }

            if (!edtDossierRetourAnSD.Checked)
            {
                edtDossierRetourAnSDGrundCode.EditValue = DBNull.Value;
                edtDossierRetourAnSDGrundCode.EditMode = EditModeType.ReadOnly;
            }

            if (!qryVermittlungSI.CanUpdate || !_mayUpd)
            {
                edtWechselKaInternGrundCode.EditMode = EditModeType.ReadOnly;
                edtDossierRetourAnSDGrundCode.EditMode = EditModeType.ReadOnly;
                btnZurueksetzen.Enabled = false;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        // ComponentName: qryVermittlungSI
        public void Init(string maskName, Image maskImage, int faLeistungID, int baPersonID)
        {
            lblTitle.Text = maskName;
            imageTitle.Image = maskImage;
            _faLeistungID = faLeistungID;
            _baPersonID = baPersonID;

            DBUtil.GetFallRights(_faLeistungID, out _mayRead, out _mayIns, out _mayUpd, out _mayDel, out _mayClose, out _mayReopen);

            if (!VermittlungExists() && DBUtil.UserHasRight("CtlKaVermittlungSIUebersicht", "UI") && (_mayUpd || _mayIns))
            {
                DBUtil.ExecSQL(@"
                    INSERT INTO dbo.KaVermittlungSI (FaLeistungID, SichtbarSDFlag, Creator, Created, Modifier, Modified)
                    VALUES ({0}, {1}, {2}, {3}, {2}, {3})",
                    _faLeistungID,
                    KaUtil.IsVisibleSD(_baPersonID),
                    Session.User.CreatorModifier,
                    DateTime.Now);
            }

            qryVermittlungSI.Fill(_faLeistungID, Session.User.IsUserKA ? 0 : 1);

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

        private bool VermittlungExists()
        {
            var rslt = Convert.ToInt32(
                DBUtil.ExecuteScalarSQL(@"SELECT COUNT(*) FROM KaVermittlungSI WHERE FaLeistungID = {0}",
                                        _faLeistungID)
                            ) > 0;

            return rslt;
        }

        #endregion

        #endregion
    }
}