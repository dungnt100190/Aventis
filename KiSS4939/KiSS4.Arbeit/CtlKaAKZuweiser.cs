using System;
using System.Drawing;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    /// <summary>
    /// Summary description for CtlKaAKZuweiser.
    /// </summary>
    public partial class CtlKaAKZuweiser : KissUserControl
    {
        #region Fields

        #region Private Fields

        private int _baPersonId;
        private int _faLeistungId;
        private bool _mayUpd;

        #endregion

        #endregion

        #region Constructors

        public CtlKaAKZuweiser()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void dlgBaInstitutionID_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            if (!_mayUpd)
                return;

            var dlg = new DlgAuswahl();
            if (dlg.InstAbeilungSuchen(dlgBaOrganisationID.Text, e.ButtonClicked))
            {
                qryZuweiser["Institution"] = dlg["OrgName"];
                qryZuweiser["InstitutionID"] = dlg["OrgID"];

                dlgBaOrganisationID.EditValue = dlg["OrgName"];
                dlgBaOrganisationID.LookupID = dlg["OrgID"];
            }
            else
                e.Cancel = true;
        }

        private void dlgBerater_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            if (!_mayUpd)
                return;

            var dlg = new DlgAuswahl();
            if (dlg.ZuweiserSuchen(dlgBerater.Text, e.ButtonClicked))
            {
                qryZuweiser["Berater"] = dlg["FullName"];
                //qryAnweisung["BeraterID"] = dlg["BaInstitutionKontaktID"];
                qryZuweiser["BeraterID"] = dlg["BeratID"];

                dlgBerater.EditValue = dlg["FullName"];
                dlgBerater.LookupID = dlg["BeratID"];

                qryZuweiser.Post();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void qryZuweiser_BeforePost(object sender, EventArgs e)
        {
            int parId = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                SELECT ISNULL(ParentID, 0)
                FROM dbo.XOrgUnit ORG1
                WHERE ORG1.OrgUnitID = - {0};",
                qryZuweiser["InstitutionID"]));

            if (parId == 30)
            {
                DBUtil.CheckNotNullField(ddlAnmeldung, lblAnmeldung.Text);
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "BAPERSONID":
                    return _baPersonId;

                case "FALEISTUNGID":
                    return _faLeistungId;

            }

            return base.GetContextValue(fieldName);
        }

        public void Init(string titleName, Image titleImage, int faLeistungId, int baPersonId)
        {
            lblTitel.Text = titleName;
            picTitle.Image = titleImage;
            _faLeistungId = faLeistungId;
            _baPersonId = baPersonId;

            SetEditMode();
            FillZuweiser();
        }

        #endregion

        #region Private Methods

        private void FillZuweiser()
        {
            // Insert row in KaAKZuweiser if there is no entry.
            if (!ZuweiserExists() && DBUtil.UserHasRight("CtlKaAKZuweiser") && _mayUpd)
            {
                DBUtil.ExecSQL(@"INSERT INTO dbo.KaAKZuweiser (FaLeistungID, SichtbarSDFlag) VALUES ({0}, {1});", _faLeistungId, KaUtil.IsVisibleSD(_baPersonId));
            }

            qryZuweiser.Fill(@"
                SELECT AKZ.*,
                       Institution = CASE
                                       WHEN AKZ.InstitutionID < 0 THEN ORG1.ItemName
                                       ELSE ORG.Name
                                     END,
                       Berater     = CASE
                                       WHEN AKZ.BeraterID < 0 THEN XUR.LastName + ISNULL(', ' + XUR.FirstName, '')
                                       ELSE OKO.Name + isNull(', ' + OKO.Vorname,'')
                                     END
                FROM dbo.KaAKZuweiser AKZ WITH(READUNCOMMITTED)
                  LEFT JOIN dbo.BaInstitution        ORG  WITH(READUNCOMMITTED) ON ORG.BaInstitutionID = AKZ.InstitutionID
                  LEFT JOIN dbo.BaInstitutionKontakt OKO  WITH(READUNCOMMITTED) ON OKO.BaInstitutionKontaktID = AKZ.BeraterID
                  LEFT JOIN dbo.XUser                XUR  WITH(READUNCOMMITTED) ON XUR.UserID = -AKZ.BeraterID
                  LEFT JOIN dbo.XOrgUnit             ORG1 WITH(READUNCOMMITTED) ON ORG1.OrgUnitID = -AKZ.InstitutionID
                WHERE AKZ.FaLeistungID = {0}
                  AND (AKZ.SichtbarSDFlag = {1} OR AKZ.SichtbarSDFlag = 1);",
                _faLeistungId, Session.User.IsUserKA ? 0 : 1);

            qryBaPerson.Fill(@"
                SELECT PRS.*,
                       Nationalitaet = PRS.Nationalitaet,
                       Ausweis       = dbo.fnLOVText('Aufenthaltsstatus', AuslaenderStatusCode),
                       Zivilstand    = dbo.fnLOVText('Zivilstand', ZivilstandCode),
                       Status        = dbo.fnLOVText('Aufenthaltsstatus', AuslaenderStatusCode),
                       Tel           = PRS.Telefon_P + IsNull(', ' + PRS.MobilTel, ''),
                       SARModulF     = ISNULL(USR.LastName + ', ', '') + ISNULL(USR.FirstName, '')
                FROM dbo.vwPerson          PRS WITH(READUNCOMMITTED)
                  LEFT JOIN dbo.FaLeistung LEI WITH(READUNCOMMITTED) ON LEI.ModulID = 2 AND LEI.BaPersonID = PRS.BaPersonID AND LEI.DatumBis IS NULL
                  LEFT JOIN dbo.XUser      USR WITH(READUNCOMMITTED) ON USR.UserID = LEI.UserID
                WHERE PRS.BaPersonID = {0}
                  AND (PRS.PersonSichtbarSDFlag = {1} or PRS.PersonSichtbarSDFlag = 1);",
                _baPersonId, Session.User.IsUserKA ? 0 : 1);

            qryAnweisung.Fill(@"
                SELECT	KAE.*,
                        Fachbereich = KEP.Name
                FROM dbo.KaEinsatz                 KAE WITH(READUNCOMMITTED)
                  LEFT JOIN dbo.KaEinsatzplatz2    KEP WITH(READUNCOMMITTED) ON KAE.KaEinsatzplatzID = KEP.KaEinsatzplatzID
                  LEFT JOIN dbo.BaArbeitAusbildung DAA WITH(READUNCOMMITTED) ON DAA.BaPersonID = KAE.BaPersonID
                  LEFT JOIN dbo.BaBeruf            BER WITH(READUNCOMMITTED) ON BER.BaBerufID = DAA.ErlernterBerufCode
                  LEFT JOIN dbo.BaPerson           PRS WITH(READUNCOMMITTED) ON PRS.BaPersonID = {0}
                WHERE KAE.BaPersonID = {0}
                  AND KAE.DatumBis = (SELECT MAX(DatumBis) FROM KaEinsatz WHERE BaPersonID = KAE.BaPersonID)
                  AND (KAE.SichtbarSDFlag = {1} or KAE.SichtbarSDFlag = 1);",
                _baPersonId, Session.User.IsUserKA ? 0 : 1);

            string sarModulF = KaUtil.GetSARModulF(_faLeistungId);
            edtSARModulF.Text = string.IsNullOrEmpty(sarModulF) ? "-" : sarModulF;
        }

        private void SetEditMode()
        {
            bool unused;
            DBUtil.GetFallRights(_faLeistungId, out unused, out unused, out _mayUpd, out unused, out unused, out unused);
            qryZuweiser.CanUpdate = _mayUpd && DBUtil.UserHasRight("CtlKaAKZuweiser", "UI");
            qryZuweiser.EnableBoundFields();
        }

        private bool ZuweiserExists()
        {
            bool rslt = Convert.ToInt32(
                DBUtil.ExecuteScalarSQL(@"
                    SELECT COUNT(*)
                    FROM dbo.KaAKZuweiser
                    WHERE FaLeistungID = {0};",
                    _faLeistungId)) > 0;

            return rslt;
        }

        #endregion

        #endregion
    }
}