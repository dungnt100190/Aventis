using System;
using System.Drawing;
using Kiss.Infrastructure.Enumeration;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    /// <summary>
    /// Summary description for CtlKaAbklaerungIntake.
    /// </summary>
    public partial class CtlKaAbklaerungIntake : KissUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CLASSNAME = "CtlKaAbklaerungIntake";

        #endregion

        #region Private Fields

        private int _baPersonID;
        private int _faLeistungID;
        private bool _mayDel;
        private bool _mayIns;
        private bool _mayUpd;

        #endregion

        #endregion

        #region Constructors

        public CtlKaAbklaerungIntake()
        {
            InitializeComponent();
            SetupDataMembers();
            SetupFieldNames();
            SetupDocContext();
        }

        #endregion

        #region EventHandlers

        private void qryAbklaerungIntake_AfterDelete(object sender, EventArgs e)
        {
            Session.Commit();
        }

        private void qryAbklaerungIntake_AfterInsert(object sender, EventArgs e)
        {
            qryAbklaerungIntake[DBO.KaAbklaerungIntake.FaLeistungID] = _faLeistungID;
            qryAbklaerungIntake[DBO.KaAbklaerungIntake.SichtbarSDFlag] = KaUtil.IsVisibleSD(_baPersonID);
            grdPhasen.SelectLastPosition = true;
        }

        private void qryAbklaerungIntake_AfterPost(object sender, EventArgs e)
        {
            try
            {
                Session.Commit();
            }
            catch (Exception)
            {
                if (Session.Transaction != null)
                {
                    Session.Rollback();
                }

                throw;
            }
        }

        private void qryAbklaerungIntake_BeforeDelete(object sender, EventArgs e)
        {
            Session.BeginTransaction();
            try
            {
                edtIntegrationDok.DeleteDocByID();
                edtFormularAsD.DeleteDocByID();
                edtZusammenfassungEg.DeleteDocByID();
            }
            catch (Exception)
            {
                if (Session.Transaction != null)
                {
                    Session.Rollback();
                }

                throw;
            }
        }

        private void qryAbklaerungIntake_BeforeInsert(object sender, EventArgs e)
        {
            var count = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                IF(EXISTS(SELECT TOP 1 1
                          FROM dbo.KaAKZuweiser WITH (READUNCOMMITTED)
                          WHERE FaLeistungID = {0}))
                BEGIN
                    SELECT COUNT(1)
                    FROM dbo.KaAKZuweiser WITH (READUNCOMMITTED)
                    WHERE FaLeistungID = {0}
                    AND (InstitutionID IS NULL
                      OR BeraterID IS NULL
                      OR Erfassung IS NULL)
                END
                ELSE
                BEGIN
                  SELECT COUNT(1)
                END;",
                _faLeistungID));

            if (count > 0)
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(
                        CLASSNAME,
                        "ZuweiserNichtVollstaendigErfasst",
                        "Zuweiser ist noch nicht vollständig erfasst!\r\n(Datum Erfassung, Institution, Berater)"));
            }

            if (IsInstitutionSd())
            {
                count = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                    SELECT COUNT(1)
                    FROM dbo.KaAbklaerungIntake WITH (READUNCOMMITTED)
                    WHERE FaLeistungID = {0}
                      AND DatumIntegration IS NULL;",
                    _faLeistungID));

                if (count > 0)
                {
                    throw new KissInfoException(
                        KissMsg.GetMLMessage(
                            CLASSNAME,
                            "DatumIntegrationsbeurteilungFehlt",
                            "Das Datum Integrationsbeurteilung fehlt!"));
                }

                count = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                    SELECT COUNT(1)
                    FROM dbo.KaAbklaerungIntake WITH (READUNCOMMITTED)
                    WHERE FaLeistungID = {0}
                      AND KaAbklaerungIntegrBeurCode IS NULL;",
                    _faLeistungID));

                if (count > 0)
                {
                    throw new KissInfoException(
                        KissMsg.GetMLMessage(
                            CLASSNAME,
                            "IntegrationsbeurteilungFehlt",
                            "Die Integrationsbeurteilung fehlt!"));
                }
            }
        }

        private void qryAbklaerungIntake_BeforePost(object sender, EventArgs e)
        {
            // Test Status Dossier
            if (!DBUtil.IsEmpty(edtIntegrationCode.EditValue) && Utils.ConvertToInt(edtStatusDossier.EditValue) != (int)KaAbklaerungStatusDossier.Abgeschlossen)
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(
                        CLASSNAME,
                        "StatusDossierMussAbgeschlossenOderAbgebrochenSein",
                        "Die Integrationsbeurteilung darf nur bei Status 'abgeschlossen' erfasst sein."));
            }

            // Integration = "retour an Zuweiser mit Empf..."
            if (Utils.ConvertToInt(edtIntegrationCode.EditValue) == (int)KaAbklaerungIntegrBeur.RetourAnZuweiserMitEmpfehlung)
            {
                DBUtil.CheckNotNullField(edtGrundDossierrueckgabe, lblGrundDossierrückgabe.Text);
            }

            Session.BeginTransaction();
        }

        private void qryAbklaerungIntake_PositionChanged(object sender, EventArgs e)
        {
            if (qryAbklaerungIntake.Count > 0)
            {
                SetEditMode();
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
                    return _baPersonID;

                case "KAABKLAERUNGINTAKEID":
                    return Utils.ConvertToInt(qryAbklaerungIntake[DBO.KaAbklaerungIntake.KaAbklaerungIntakeID]);

                case "KAABKLAERUNGVERTIEFTID":
                    return 0;

                case "ISTINTAKE":
                    return true;

                case "FALEISTUNGID":
                    return _faLeistungID;

                case "OWNERUSERID":
                    return (int)DBUtil.ExecuteScalarSQL("SELECT UserID FROM dbo.FaLeistung WHERE FaLeistungID = {0};", _faLeistungID);
            }

            return base.GetContextValue(fieldName);
        }

        public void Init(string titleName, Image titleImage, int faLeistungID, int baPersonID)
        {
            lblTitel.Text = titleName;
            picTitle.Image = titleImage;
            _faLeistungID = faLeistungID;
            _baPersonID = baPersonID;

            colModul.ColumnEdit = grdPhasen.GetLOVLookUpEdit("KaAbklaerungPhaseIntake");
            colStatus.ColumnEdit = grdPhasen.GetLOVLookUpEdit("KaAbklaerungStatusDossier");
            colPraesenz.ColumnEdit = grdPhasen.GetLOVLookUpEdit("KaAbklaerungPraesenz");
            colBeurteilung.ColumnEdit = grdPhasen.GetLOVLookUpEdit("KaAbklaerungIntegrBeur");

            SetEditMode();
            FillAbklaerungIntake();

            grdPhasen.SelectLastPosition = true;
        }

        #endregion

        #region Private Methods

        private void FillAbklaerungIntake()
        {
            qryAbklaerungIntake.Fill(_faLeistungID, Session.User.IsUserKA ? 0 : 1);
        }

        private bool IsInstitutionRav()
        {
            var count = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                SELECT COUNT(1)
                FROM dbo.KaAKZuweiser         AKZ WITH (READUNCOMMITTED)
                  LEFT JOIN dbo.BaInstitution ORG WITH (READUNCOMMITTED) ON ORG.BaInstitutionID = AKZ.InstitutionID
                WHERE AKZ.FaLeistungID = {0}
                  AND AKZ.InstitutionID > 0
                  AND ORG.Name LIKE 'RAV%';",
                _faLeistungID));

            return count > 0;
        }

        private bool IsInstitutionSd()
        {
            var parID = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                SELECT ISNULL(ParentID, 0)
                FROM dbo.XOrgUnit ORG WITH (READUNCOMMITTED)
                WHERE ORG.OrgUnitID = - (SELECT ISNULL(InstitutionID, 0)
                                         FROM dbo.KaAKZuweiser WITH (READUNCOMMITTED)
                                         WHERE FaLeistungID = {0});",
                _faLeistungID));

            return parID == 30;
        }

        private void SetEditMode()
        {
            if (KaUtil.GetSichtbarSDFlag(_baPersonID) == 1)
            {
                qryAbklaerungIntake.EnableBoundFields(false);
            }
            else
            {
                bool unused;
                DBUtil.GetFallRights(_faLeistungID, out unused, out _mayIns, out _mayUpd, out _mayDel, out unused, out unused);
                qryAbklaerungIntake.CanUpdate = _mayUpd && DBUtil.UserHasRight(CLASSNAME, "U");
                qryAbklaerungIntake.CanInsert = _mayIns && DBUtil.UserHasRight(CLASSNAME, "I");
                qryAbklaerungIntake.CanDelete = _mayDel && DBUtil.UserHasRight(CLASSNAME, "D");
                qryAbklaerungIntake.EnableBoundFields();
            }
        }

        private void SetupDataMembers()
        {
            edtDatum.DataMember = DBO.KaAbklaerungIntake.Datum;
            edtModul.DataMember = DBO.KaAbklaerungIntake.KaAbklaerungPhaseIntakeCode;
            edtStatusDossier.DataMember = DBO.KaAbklaerungIntake.KaAbklaerungStatusDossierCode;
            edtAsdFragen.DataMember = DBO.KaAbklaerungIntake.AsdFragen;
            edtGespraechstermin.DataMember = DBO.KaAbklaerungIntake.Gespraechstermin;
            edtPraesenz.DataMember = DBO.KaAbklaerungIntake.KaAbklaerungPraesenzCode;
            edtBemerkung.DataMember = DBO.KaAbklaerungIntake.Bemerkung;
            edtDatumIntegration.DataMember = DBO.KaAbklaerungIntake.DatumIntegration;
            edtIntegrationCode.DataMember = DBO.KaAbklaerungIntake.KaAbklaerungIntegrBeurCode;
            edtIntegrationDok.DataMember = DBO.KaAbklaerungIntake.DocumentID_Integration;
            edtGrundDossierrueckgabe.DataMember = DBO.KaAbklaerungIntake.KaAbklaerungGrundDossCode;
            edtFormularAsD.DataMember = DBO.KaAbklaerungIntake.DocumentID_FormularAsD;
            edtZusammenfassungEg.DataMember = DBO.KaAbklaerungIntake.DocumentID_ZusammenfassungEG;
        }

        private void SetupDocContext()
        {
            edtFormularAsD.Context = "KaAKAsDFragen";
            edtIntegrationDok.Context = "KaAKIntBeurteilung";
            edtZusammenfassungEg.Context = "KaAKZusammenfassungEG";
        }

        private void SetupFieldNames()
        {
            colDatum.FieldName = DBO.KaAbklaerungIntake.Datum;
            colModul.FieldName = DBO.KaAbklaerungIntake.KaAbklaerungPhaseIntakeCode;
            colStatus.FieldName = DBO.KaAbklaerungIntake.KaAbklaerungStatusDossierCode;
            colPraesenz.FieldName = DBO.KaAbklaerungIntake.KaAbklaerungPraesenzCode;
            colBeurteilung.FieldName = DBO.KaAbklaerungIntake.KaAbklaerungIntegrBeurCode;
        }

        #endregion

        #endregion
    }
}