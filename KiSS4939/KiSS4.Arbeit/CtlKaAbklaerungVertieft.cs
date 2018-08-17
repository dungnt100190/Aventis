using System;
using System.Data;
using System.Drawing;
using Kiss.Infrastructure.Enumeration;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    /// <summary>
    /// Summary description for CtlKaAbklaerungVertieft.
    /// </summary>
    public partial class CtlKaAbklaerungVertieft : KissUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CLASSNAME = "CtlKaAbklaerungVertieft";
        private const string QRY_KURS = "Kurs";
        private const string QRY_KURS_DETAIL = "KursDetail";

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

        public CtlKaAbklaerungVertieft()
        {
            InitializeComponent();
            SetupDataMembers();
            SetupFieldNames();
            SetupDocContext();
        }

        #endregion

        #region EventHandlers

        private void edtKurs_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            if (!_mayUpd)
            {
                return;
            }

            var dlg = new DlgAuswahl();
            if (dlg.KurserfassungSuchen(edtKurs.Text, e.ButtonClicked, KaKurssucheCaller.Abklaerung))
            {
                qryAbklaerungVertieft[QRY_KURS] = dlg["KursNrName"];
                qryAbklaerungVertieft[DBO.KaAbklaerungVertieft.KaKurserfassungID] = dlg["KaKurserfassungID"];

                edtKurs.EditValue = dlg["KursNrName"];
                edtKurs.LookupID = dlg["KaKurserfassungID"];
                lblKursDetail.Text = dlg["KursDetail"].ToString();

                qryAbklaerungVertieft.Post();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void qryAbklaerungVertieft_AfterDelete(object sender, EventArgs e)
        {
            Session.Commit();
        }

        private void qryAbklaerungVertieft_AfterFill(object sender, EventArgs e)
        {
            qryAbklaerungVertieft.Last();
        }

        private void qryAbklaerungVertieft_AfterInsert(object sender, EventArgs e)
        {
            qryAbklaerungVertieft[DBO.KaAbklaerungVertieft.FaLeistungID] = _faLeistungID;
            qryAbklaerungVertieft[DBO.KaAbklaerungVertieft.SichtbarSDFlag] = KaUtil.IsVisibleSD(_baPersonID);

            tabControlAbkl.SelectTab(tabPageModule);
            grdPhasen.SelectLastPosition = true;
        }

        private void qryAbklaerungVertieft_AfterPost(object sender, EventArgs e)
        {
            try
            {
                if (DBUtil.IsEmpty(qryProbeeinsatz[DBO.KaAbklaerungVertieftProbeeinsatz.KaAbklaerungVertieftID]))
                {
                    qryProbeeinsatz[DBO.KaAbklaerungVertieftProbeeinsatz.KaAbklaerungVertieftID] = qryAbklaerungVertieft[DBO.KaAbklaerungVertieft.KaAbklaerungVertieftID];
                }

                if (!qryProbeeinsatz.Post())
                {
                    throw new KissCancelException();
                }

                KaUtil.UpdateKaArbeitsRapportRecords(_faLeistungID);
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

        private void qryAbklaerungVertieft_BeforeDelete(object sender, EventArgs e)
        {
            Session.BeginTransaction();
            try
            {
                edtIntegrationDok.DeleteDocByID();
                edtSchlussbericht.DeleteDocByID();
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

        private void qryAbklaerungVertieft_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            var exists = DBUtil.ExecuteScalarSQL(@"
                SELECT TOP 1 CONVERT(BIT, 1)
                FROM dbo.KaAbklaerungVertieftProbeeinsatz AVP WITH (READUNCOMMITTED)
                WHERE AVP.KaAbklaerungVertieftID = {0};",
                qryAbklaerungVertieft[DBO.KaAbklaerungVertieft.KaAbklaerungVertieftID]) as bool? ?? false;

            if (exists)
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(
                        CLASSNAME,
                        "ProbeeinsatzExistiert",
                        "Der Eintrag kann nicht gelöscht werden, da noch abhängige Probeeinsätze existieren."));
            }
        }

        private void qryAbklaerungVertieft_BeforeInsert(object sender, EventArgs e)
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
                        "ZuweiserNichtVollstaemdigErfasst",
                        "Zuweiser ist noch nicht vollständig erfasst!\r\n(Datum Erfassung, Institution, Berater)"));
            }

            if (IsInstitutionSd())
            {
                count = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                    SELECT COUNT(1)
                    FROM dbo.KaAbklaerungVertieft WITH (READUNCOMMITTED)
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
                    FROM dbo.KaAbklaerungVertieft WITH (READUNCOMMITTED)
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

        private void qryAbklaerungVertieft_BeforePost(object sender, EventArgs e)
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

            // prüfen ob KaArbeitsrapport-Einträge vor dem neuen Datum vorhanden sind
            DateTime? datumVon;
            DateTime? datumBis;
            var hatArbeitsrapport = KaUtil.WouldKaArbeitsRapportRecordsBeDeleted(_faLeistungID, qryAbklaerungVertieft[DBO.KaAbklaerungVertieft.DatumIntegration] as DateTime?, out datumVon, out datumBis);

            // wenn ja, fragen ob die Daten gelöscht werden können
            if (hatArbeitsrapport && datumVon.HasValue && datumBis.HasValue)
            {
                var answer = KissMsg.ShowQuestion(
                    Name,
                    "FrageZeiterfassungLoeschen",
                    "Es sind bereits Daten für die Präsenzzeiterfassung vor dem {0} oder nach dem {1} vorhanden." + Environment.NewLine +
                    "Wollen Sie diese Daten löschen?",
                    true,
                    datumVon.Value.ToShortDateString(),
                    datumBis.Value.ToShortDateString());

                if (!answer)
                {
                    qryAbklaerungVertieft[DBO.KaAbklaerungVertieft.DatumIntegration] = null;
                    throw new KissCancelException();
                }
            }

            Session.BeginTransaction();
        }

        private void qryAbklaerungVertieft_PositionChanged(object sender, EventArgs e)
        {
            if (qryAbklaerungVertieft.Count > 0)
            {
                SetEditMode();
                qryProbeeinsatz.Fill(qryAbklaerungVertieft.Count == 0 ? DBNull.Value : qryAbklaerungVertieft[DBO.KaAbklaerungVertieft.KaAbklaerungVertieftID]);
            }
        }

        private void qryProbeeinsatz_AfterDelete(object sender, EventArgs e)
        {
            Session.Commit();
        }

        private void qryProbeeinsatz_AfterFill(object sender, EventArgs e)
        {
            qryProbeeinsatz.Last();
        }

        private void qryProbeeinsatz_AfterInsert(object sender, EventArgs e)
        {
            qryProbeeinsatz[DBO.KaAbklaerungVertieftProbeeinsatz.KaAbklaerungVertieftID] = qryAbklaerungVertieft[DBO.KaAbklaerungVertieft.KaAbklaerungVertieftID];
        }

        private void qryProbeeinsatz_BeforeDelete(object sender, EventArgs e)
        {
            Session.BeginTransaction();

            try
            {
                edtDocProzessschritt.DeleteDocByID();
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

        private void qryProbeeinsatz_BeforeInsert(object sender, EventArgs e)
        {
            qryAbklaerungVertieft.Post();
        }

        private void qryProbeeinsatz_ColumnChanging(object sender, DataColumnChangeEventArgs e)
        {
            if (qryProbeeinsatz.RowModified)
            {
                qryAbklaerungVertieft.RowModified = true;
            }
        }

        private void qryProbeeinsatz_PositionChanging(object sender, EventArgs e)
        {
            if (qryProbeeinsatz.RowModified)
            {
                qryAbklaerungVertieft.RowModified = true;
            }
        }

        private void tabControlAbkl_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            if (page == tabPageProbe)
            {
                qryAbklaerungVertieft.Post();
                if (!qryAbklaerungVertieft.IsEmpty)
                {
                    ActiveSQLQuery = qryProbeeinsatz;
                }
            }
            else
            {
                qryProbeeinsatz.Post();
                ActiveSQLQuery = qryAbklaerungVertieft;
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
                    return 0;

                case "KAABKLAERUNGVERTIEFTID":
                    return Utils.ConvertToInt(qryAbklaerungVertieft[DBO.KaAbklaerungVertieft.KaAbklaerungVertieftID]);

                case "ISTINTAKE":
                    return false;

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

            colModul.ColumnEdit = grdPhasen.GetLOVLookUpEdit("KaAbklaerungPhaseVertiefteAbklaerungen");
            colStatus.ColumnEdit = grdPhasen.GetLOVLookUpEdit("KaAbklaerungStatusDossier");
            colPraesenz.ColumnEdit = grdPhasen.GetLOVLookUpEdit("KaAbklaerungPraesenz");
            colBeurteilung.ColumnEdit = grdPhasen.GetLOVLookUpEdit("KaAbklaerungIntegrBeur");
            colProbeeinsatzProzesschritt.ColumnEdit = grdPhasen.GetLOVLookUpEdit("KaAbklaerungProzessschritt");

            FillAbklaerungVertieft();
            qryProbeeinsatz.Fill(qryAbklaerungVertieft.Count == 0 ? DBNull.Value : qryAbklaerungVertieft[DBO.KaAbklaerungVertieft.KaAbklaerungVertieftID]);
            SetEditMode();

            tabControlAbkl.SelectTab(tabPageModule);
            grdPhasen.SelectLastPosition = true;
            grdProzessschritte.SelectLastPosition = true;
        }

        #endregion

        #region Private Methods

        private void FillAbklaerungVertieft()
        {
            qryAbklaerungVertieft.Fill(_faLeistungID, Session.User.IsUserKA ? 0 : 1);
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
                qryAbklaerungVertieft.EnableBoundFields(false);
                qryProbeeinsatz.EnableBoundFields(false);
            }
            else
            {
                bool unused;
                DBUtil.GetFallRights(_faLeistungID, out unused, out _mayIns, out _mayUpd, out _mayDel, out unused, out unused);
                qryAbklaerungVertieft.CanUpdate = _mayUpd && DBUtil.UserHasRight(CLASSNAME, "U");
                qryAbklaerungVertieft.CanInsert = _mayIns && DBUtil.UserHasRight(CLASSNAME, "I");
                qryAbklaerungVertieft.CanDelete = _mayDel && DBUtil.UserHasRight(CLASSNAME, "D");
                qryAbklaerungVertieft.EnableBoundFields();

                qryProbeeinsatz.CanUpdate = qryAbklaerungVertieft.CanUpdate;
                qryProbeeinsatz.CanInsert = qryAbklaerungVertieft.CanInsert;
                qryProbeeinsatz.CanDelete = qryAbklaerungVertieft.CanDelete;
                qryProbeeinsatz.EnableBoundFields();
            }
        }

        private void SetupDataMembers()
        {
            edtDatum.DataMember = DBO.KaAbklaerungVertieft.Datum;
            edtModul.DataMember = DBO.KaAbklaerungVertieft.KaAbklaerungPhaseVertiefteAbklaerungenCode;
            edtStatusDossier.DataMember = DBO.KaAbklaerungVertieft.KaAbklaerungStatusDossierCode;
            edtKurs.DataMember = QRY_KURS;
            edtDatumKursAbbruch.DataMember = DBO.KaAbklaerungVertieft.DatumKursAbbruch;
            lblKursDetail.DataMember = QRY_KURS_DETAIL;
            edtPraesenz.DataMember = DBO.KaAbklaerungVertieft.KaAbklaerungPraesenzCode;
            edtProbeeinsatzIn.DataMember = DBO.KaAbklaerungVertieft.KaAbklaerungProbeeinsatzInCode;
            edtEinsatzVon.DataMember = DBO.KaAbklaerungVertieft.EinsatzVon;
            edtEinsatzBis.DataMember = DBO.KaAbklaerungVertieft.EinsatzBis;
            edtBemerkung.DataMember = DBO.KaAbklaerungVertieft.Bemerkung;
            edtDatumIntegration.DataMember = DBO.KaAbklaerungVertieft.DatumIntegration;
            edtIntegrationCode.DataMember = DBO.KaAbklaerungVertieft.KaAbklaerungIntegrBeurCode;
            edtIntegrationDok.DataMember = DBO.KaAbklaerungVertieft.DocumentID_Integration;
            edtGrundDossierrueckgabe.DataMember = DBO.KaAbklaerungVertieft.KaAbklaerungGrundDossCode;
            edtDatumAustritt.DataMember = DBO.KaAbklaerungVertieft.DatumAustritt;
            edtSchlussbericht.DataMember = DBO.KaAbklaerungVertieft.DocumentID_Schlussbericht;
        }

        private void SetupDocContext()
        {
            edtSchlussbericht.Context = "KaAKIntSchlussbericht";
            edtIntegrationDok.Context = "KaAKIntBeurteilung";
            edtDocProzessschritt.Context = "KaAbklaerungVertieftProzessschritt";
        }

        private void SetupFieldNames()
        {
            colDatum.FieldName = DBO.KaAbklaerungVertieft.Datum;
            colModul.FieldName = DBO.KaAbklaerungVertieft.KaAbklaerungPhaseVertiefteAbklaerungenCode;
            colStatus.FieldName = DBO.KaAbklaerungVertieft.KaAbklaerungStatusDossierCode;
            colPraesenz.FieldName = DBO.KaAbklaerungVertieft.KaAbklaerungPraesenzCode;
            colBeurteilung.FieldName = DBO.KaAbklaerungVertieft.KaAbklaerungIntegrBeurCode;
            colProbeeinsatzProzesschritt.FieldName = DBO.KaAbklaerungVertieftProbeeinsatz.KaAbklaerungProzessschrittCode;
        }

        #endregion

        #endregion
    }
}