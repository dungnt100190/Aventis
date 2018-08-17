using System;
using System.Drawing;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    public partial class CtlKaVermittlungBIBIPUebersicht : KissUserControl
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

        public CtlKaVermittlungBIBIPUebersicht()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void btnZuruecksetzen_Click(object sender, EventArgs e)
        {
            if (KissMsg.ShowQuestion("CtlKaVermittlungBIBIPUebersicht", "WerteZuruecksetzen", "Wollen Sie die Daten zurücksetzen?"))
            {
                edtDossierRetourAnSD.Checked = false;
                qryVermittlungBIBIP[DBO.KaVermittlungBIBIP.DossierRetourAnSD] = 0;
                edtDossierRetourAnSDGrund.EditValue = DBNull.Value;
                qryVermittlungBIBIP[DBO.KaVermittlungBIBIP.DossierRetourAnSDGrundCode] = DBNull.Value;
                edtDossierRetourAnSDGrund.EditMode = EditModeType.ReadOnly;

                edtWechselKaIntern.Checked = false;
                qryVermittlungBIBIP[DBO.KaVermittlungBIBIP.WechselKAIntern] = 0;
                edtWechselKAInternGrund.EditValue = DBNull.Value;
                qryVermittlungBIBIP[DBO.KaVermittlungBIBIP.WechselKAInternGrundCode] = DBNull.Value;
                edtWechselKAInternGrund.EditMode = EditModeType.ReadOnly;
            }
        }

        private void CtlKaVermittlungBIBIPUebersicht_Load(object sender, EventArgs e)
        {
            if (KaUtil.GetSichtbarSDFlag(_baPersonID) == 1)
            {
                qryVermittlungBIBIP.EnableBoundFields(false);
                btnZuruecksetzen.Enabled = false;
            }
        }

        private void edtDossierRetourAnSD_CheckedChanged(object sender, EventArgs e)
        {
            if (edtDossierRetourAnSD.Checked)
            {
                edtWechselKaIntern.Checked = false;
                edtWechselKAInternGrund.EditValue = DBNull.Value;
                edtWechselKAInternGrund.EditMode = EditModeType.ReadOnly;

                if (qryVermittlungBIBIP.CanUpdate || _mayUpd)
                    edtDossierRetourAnSDGrund.EditMode = EditModeType.Normal;
            }
            else
            {
                edtDossierRetourAnSDGrund.EditValue = DBNull.Value;
                edtDossierRetourAnSDGrund.EditMode = EditModeType.ReadOnly;
            }
        }

        private void edtWechselKaIntern_CheckedChanged(object sender, EventArgs e)
        {
            if (edtWechselKaIntern.Checked)
            {
                edtDossierRetourAnSD.Checked = false;
                edtDossierRetourAnSDGrund.EditValue = DBNull.Value;
                edtDossierRetourAnSDGrund.EditMode = EditModeType.ReadOnly;

                if (qryVermittlungBIBIP.CanUpdate || _mayUpd)
                    edtWechselKAInternGrund.EditMode = EditModeType.Normal;
            }
            else
            {
                edtWechselKAInternGrund.EditValue = DBNull.Value;
                edtWechselKAInternGrund.EditMode = EditModeType.ReadOnly;
            }
        }

        private void edtZuweiser_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtZuweiser.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryVermittlungBIBIP[DBO.KaVermittlungBIBIP.ZuweiserID] = DBNull.Value;
                    qryVermittlungBIBIP["Zuweiser"] = DBNull.Value;
                    qryVermittlungBIBIP["ZuweiserDet"] = DBNull.Value;
                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                SELECT
                  BeratID$     = OKO.BaInstitutionKontaktID,
                  Name         = OKO.Name + ISNULL(', ' + OKO.Vorname,''),
                  Institution  = ORG.Name,
                  Tel          = OKO.Telefon,
                  Fax          = OKO.Fax,
                  Email        = OKO.Email,
                  ZuweiserDet$ = ISNULL(ORG.Name, '') + ISNULL(', ' + OKO.Telefon, '') + ISNULL(', ' + OKO.Email, '')
                FROM dbo.BaInstitutionKontakt  OKO WITH(READUNCOMMITTED)
                  INNER JOIN dbo.BaInstitution ORG WITH(READUNCOMMITTED) ON ORG.BaInstitutionID = OKO.BaInstitutionID
                WHERE OKO.Name + ISNULL(', ' + OKO.Vorname,'') LIKE '%' + {0} + '%'

                UNION ALL

                SELECT
                  BeratID$     = -USR.UserID,
                  Name         = LastName + ISNULL(', ' + FirstName,''),
                  Institution  = XOU.ItemName,
                  Tel          = USR.Phone,
                  Fax          = '',
                  Email        = USR.Email,
                  ZuweiserDet$ = ISNULL(XOU.ItemName, '') + ISNULL(', ' + USR.Phone, '') + ISNULL(', ' + USR.Email, '')
                FROM dbo.XUser                USR WITH(READUNCOMMITTED)
                  LEFT JOIN dbo.XOrgUnit_User OUU WITH(READUNCOMMITTED) ON OUU.UserID = USR.UserID
                                                                       AND (OUU.OrgUnitMemberCode = 1 OR OUU.OrgUnitMemberCode = 2)
                  LEFT JOIN dbo.XOrgUnit      XOU WITH(READUNCOMMITTED) ON XOU.OrgUnitID = OUU.OrgUnitID
              WHERE LastName + ISNULL(', ' + FirstName,'') LIKE '%' + {0} + '%'
              ORDER BY Name;",
              searchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                qryVermittlungBIBIP[DBO.KaVermittlungBIBIP.ZuweiserID] = dlg[0];
                qryVermittlungBIBIP["Zuweiser"] = dlg[1];
                qryVermittlungBIBIP["ZuweiserDet"] = dlg[6];
            }
        }

        private void qryVermittlungBIBIP_AfterFill(object sender, EventArgs e)
        {
            if (!edtWechselKaIntern.Checked)
            {
                edtWechselKAInternGrund.EditValue = DBNull.Value;
                edtWechselKAInternGrund.EditMode = EditModeType.ReadOnly;
            }

            if (!edtDossierRetourAnSD.Checked)
            {
                edtDossierRetourAnSDGrund.EditValue = DBNull.Value;
                edtDossierRetourAnSDGrund.EditMode = EditModeType.ReadOnly;
            }

            if (!qryVermittlungBIBIP.CanUpdate || !_mayUpd)
            {
                edtWechselKAInternGrund.EditMode = EditModeType.ReadOnly;
                edtWechselKAInternGrund.EditMode = EditModeType.ReadOnly;
                btnZuruecksetzen.Enabled = false;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        // ComponentName: qryVermittlungBIBIP
        public void Init(string maskName, Image maskImage, int faLeistungID, int baPersonID)
        {
            lblTitle.Text = maskName;
            imageTitle.Image = maskImage;
            _faLeistungID = faLeistungID;
            _baPersonID = baPersonID;

            DBUtil.GetFallRights(_faLeistungID, out _mayRead, out _mayIns, out _mayUpd, out _mayDel, out _mayClose, out _mayReopen);

            if (!VermittlungExists() && DBUtil.UserHasRight("CtlKaVermittlungBIBIPUebersicht", "UI") && (_mayUpd || _mayIns))
            {
                DBUtil.ExecSQL(@"
                    INSERT INTO dbo.KaVermittlungBIBIP (FaLeistungID, SichtbarSDFlag, Creator, Modifier)
                    VALUES ({0}, {1}, {2}, {2});",
                    _faLeistungID,
                    KaUtil.IsVisibleSD(_baPersonID),
                    DBUtil.GetDBRowCreatorModifier());
            }

            btnZuruecksetzen.Enabled = qryVermittlungBIBIP.CanUpdate;

            qryVermittlungBIBIP.Fill(_faLeistungID, Session.User.IsUserKA ? 0 : 1);

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
                DBUtil.ExecuteScalarSQL(@"
                    SELECT COUNT(*)
                    FROM dbo.KaVermittlungBIBIP WITH(READUNCOMMITTED)
                    WHERE FaLeistungID = {0};",
                    _faLeistungID)
                           ) > 0;
            return rslt;
        }

        #endregion

        #endregion
    }
}