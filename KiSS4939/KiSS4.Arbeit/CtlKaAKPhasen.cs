using System;
using System.Data;
using System.Drawing;

using Kiss.Interfaces.UI;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    /// <summary>
    /// Summary description for CtlKaAKPhasen.
    /// </summary>
    public partial class CtlKaAKPhasen : KissUserControl
    {
        #region Fields

        #region Private Fields

        private int _baPersonID;
        private int _faLeistungID;
        private bool _mayDel;
        private bool _mayIns;
        private bool _mayUpd;

        #endregion

        #endregion

        #region Constructors

        public CtlKaAKPhasen()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void CtlKaAKPhasen_Load(object sender, EventArgs e)
        {
            //SetEditMode();
            //FillPhasen();
        }

        private void ddlIntegrationCode_EditValueChanged(object sender, EventArgs e)
        {
            if (DBUtil.IsEmpty(ddlIntegrationCode.EditValue) || !ddlIntegrationCode.UserModified)
                return;

            switch (Convert.ToInt32(ddlIntegrationCode.EditValue))
            {
                case 7:
                    // Erstgespräch Erwachsene
                    NeuePhaseOeffnen("Erstgespräch Erwachsene", 5, false);
                    break;

                case 12:
                    // Erstgespräch junge Erwachsene
                    if (!IsInstitutionRav())
                        NeuePhaseOeffnen("Erstgespräch junge Erwachsene", 2, false);
                    break;

                case 5:
                    // Kurzabklärung
                    NeuePhaseOeffnen("Kurzabklärung", 3, false);
                    break;

                case 8:
                    // Basisabklärung
                    NeuePhaseOeffnen("Basisabklärung", 6, false);
                    break;

                case 13:
                    // Praxisdeutsch
                    NeuePhaseOeffnen("Praxisdeutsch", 10, false);
                    break;

                case 9:
                    // Portfoliokurs
                    NeuePhaseOeffnen("Portfoliokurs", 7, false);
                    break;

                case 10:
                    // verlängerte Abklärung
                    NeuePhaseOeffnen("verlängerte Abklärung", 8, false);
                    break;

                case 3:
                    // Qualifizierung Jugend
                    NeuePhaseOeffnen("Qualifizierung Jugend", 0, true);
                    break;
            }
        }

        private void ddlPhase_EditValueChanged(object sender, EventArgs e)
        {
            if (qryPhasen.IsFilling)
            {
                return;
            }

            SetEditMode();
        }

        private void dlgKurs_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            if (!_mayUpd)
                return;

            DlgAuswahl dlg = new DlgAuswahl();
            if (dlg.KurserfassungSuchen(dlgKurs.Text, e.ButtonClicked, KaKurssucheCaller.Abklaerung))
            {
                qryPhasen["Kurs"] = dlg["KursNrName"];
                qryPhasen["KursID"] = dlg["KaKurserfassungID"];

                dlgKurs.EditValue = dlg["KursNrName"];
                dlgKurs.LookupID = dlg["KaKurserfassungID"];
                lblKursDetail.Text = dlg["KursDetail"].ToString();

                qryPhasen.Post();
            }
            else
                e.Cancel = true;
        }

        private void qryPhasen_AfterInsert(object sender, EventArgs e)
        {
            qryPhasen["FaLeistungID"] = _faLeistungID;
            qryPhasen["SichtbarSDFlag"] = KaUtil.IsVisibleSD(_baPersonID);
            qryPhasen.SetCreator();
            qryPhasen["Created"] = DateTime.Now;
        }

        private void qryPhasen_BeforeInsert(object sender, EventArgs e)
        {
            int cnt = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"SELECT COUNT(*)
                        FROM KaAKZuweiser
                        WHERE FaLeistungID = {0}
                        AND (InstitutionID IS NULL
                            OR BeraterID IS NULL
                            OR Erfassung IS NULL)"
                        , _faLeistungID));

            if (cnt > 0)
            {
                throw new KissInfoException("Zuweiser noch nicht vollständig erfasst!\r\n(Datum Erfassung, Institution, Berater)");
            }

            if (IsInstitutionSd())
            {
                cnt = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"SELECT COUNT(*)
                        FROM KaAKPhasen
                        WHERE FaLeistungID = {0}
                        AND PhasenCode = 1
                        AND IntegrationDatum IS NULL"
                    , _faLeistungID));

                if (cnt > 0)
                {
                    throw new KissInfoException("Phase Abklärung: Datum Integrationsbeurteilung fehlt!");
                }

                cnt = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"SELECT COUNT(*)
                        FROM KaAKPhasen
                        WHERE FaLeistungID = {0}
                        AND PhasenCode = 1
                        AND IntegrationCode IS NULL"
                    , _faLeistungID));

                if (cnt > 0)
                {
                    throw new KissInfoException("Phase Abklärung muss eine Integrationsbeurteilung enthalten!");
                }
            }
        }

        private void qryPhasen_BeforePost(object sender, EventArgs e)
        {
            // #5751 Problem beim Speichern
            //qryPhasen["FertigkeitenCodes"] = GetAuswahlList(chlFertigkeiten);
            //qryPhasen["ArbeitsverhaltenCodes"] = GetAuswahlList(chlArbeitsverhalten);
            //qryPhasen["MerkmaleCodes"] = GetAuswahlList(chlMerkmale);

            if (!DBUtil.IsEmpty(ddlPhase.EditValue))
            {
                if (Convert.ToInt32(ddlPhase.EditValue) == 9 && !IsInstitutionRav())
                {
                    throw new KissInfoException("Eröffnung Phase 'Standortbestimmung RAV' ist nur möglich,\r\nwenn die Institution beim Zuweiser RAV ist!");
                }
            }

            if (!DBUtil.IsEmpty(datDatumIntegration.EditValue))
            {
                // Integration = "retour an Zuweiser mit Empf..."
                if (!DBUtil.IsEmpty(ddlIntegrationCode.EditValue))
                {
                    if (Convert.ToInt32(ddlIntegrationCode.EditValue) == 6 && !IsInstitutionRav())
                    {
                        DBUtil.CheckNotNullField(ddlGrund, lblGrund.Text);
                    }
                }

                // Test Status Warteliste
                if (!DBUtil.IsEmpty(ddlPhase.EditValue))
                {
                    // Schlussgepräch darf nich leer sein!
                    if (DBUtil.IsEmpty(qryPhasen["SchlussGespraechDat"]) && Convert.ToInt32(ddlPhase.EditValue) == 8)
                    {
                        datDatumIntegration.EditValue = null;
                        qryPhasen["IntegrationDatum"] = DBNull.Value;
                        throw new KissInfoException("Abschluss Phase nicht möglich!\r\nSchlussgespräch darf nicht leer sein!");
                    }

                    if (Convert.ToInt32(ddlPhase.EditValue) == 3 || Convert.ToInt32(ddlPhase.EditValue) == 6 ||
                        Convert.ToInt32(ddlPhase.EditValue) == 7 || Convert.ToInt32(ddlPhase.EditValue) == 8)
                    {
                        if (!DBUtil.IsEmpty(ddlStatusWarteliste.EditValue))
                        {
                            if (!(Convert.ToInt32(ddlStatusWarteliste.EditValue) == 4 || Convert.ToInt32(ddlStatusWarteliste.EditValue) == 5))
                            {
                                datDatumIntegration.EditValue = null;
                                qryPhasen["IntegrationDatum"] = DBNull.Value;
                                throw new KissInfoException("Status Warteliste muss 'abgebrochen' oder 'abgeschlossen' sein!");
                            }
                        }
                        else
                        {
                            datDatumIntegration.EditValue = null;
                            qryPhasen["IntegrationDatum"] = DBNull.Value;
                            throw new KissInfoException("Status Warteliste muss 'abgebrochen' oder 'abgeschlossen' sein!");
                        }
                    }
                }

                // Status Warteliste = Dossier pendent
                if (!DBUtil.IsEmpty(ddlStatusWarteliste.EditValue))
                {
                    if (Convert.ToInt32(ddlStatusWarteliste.EditValue) == 6)
                    {
                        datDatumIntegration.EditValue = null;
                        qryPhasen["IntegrationDatum"] = DBNull.Value;
                        throw new KissInfoException("Abschluss Phase nicht möglich!\r\nStatus Warteliste = Dossier pendent!");
                    }
                }

                // Präsenz ausfüllen!
                if (!DBUtil.IsEmpty(ddlPhase.EditValue))
                {
                    if (Convert.ToInt32(ddlPhase.EditValue) == 3 || Convert.ToInt32(ddlPhase.EditValue) == 6 ||
                        Convert.ToInt32(ddlPhase.EditValue) == 7 || Convert.ToInt32(ddlPhase.EditValue) == 8 ||
                        Convert.ToInt32(ddlPhase.EditValue) == 2 || Convert.ToInt32(ddlPhase.EditValue) == 5)
                    {
                        DBUtil.CheckNotNullField(ddlPraesenz, lblPraesenz.Text);
                    }
                }
            }

            DBUtil.CheckNotNullField(datAbbruchDatum, "Datum Kursabbruch");

            qryPhasen.SetModifierModified();

            // prüfen ob KaArbeitsrapport-Einträge vor dem neuen Datum vorhanden sind
            DateTime? datumVon;
            DateTime? datumBis;
            var hatArbeitsrapport = KaUtil.WouldKaArbeitsRapportRecordsBeDeleted(_faLeistungID, qryPhasen["AbbruchDatum"] as DateTime?, out datumVon, out datumBis);

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
                    throw new KissCancelException();
                }
            }

            Session.BeginTransaction();
        }

        private void qryPhasen_PositionChanged(object sender, EventArgs e)
        {
            if (qryPhasen.Count > 0)
            {
                chlFertigkeiten.EditValue = qryPhasen["FertigkeitenCodes"].ToString();
                chlArbeitsverhalten.EditValue = qryPhasen["ArbeitsverhaltenCodes"].ToString();
                chlMerkmale.EditValue = qryPhasen["MerkmaleCodes"].ToString();

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

                case "KAAKPHASENID":
                    return Convert.ToInt32(qryPhasen["KaAKPhasenID"]);

                case "FALEISTUNGID":
                    return _faLeistungID;

                case "OWNERUSERID":
                    return (int)DBUtil.ExecuteScalarSQL("select UserID from FaLeistung where FaLeistungID = {0}", _faLeistungID);
            }

            return base.GetContextValue(fieldName);
        }

        public void Init(string titleName, Image titleImage, int faLeistungID, int baPersonID)
        {
            lblTitel.Text = titleName;
            picTitle.Image = titleImage;
            _faLeistungID = faLeistungID;
            _baPersonID = baPersonID;

            colPhase.ColumnEdit = grdPhasen.GetLOVLookUpEdit("KaAbklaerungPhase");
            colStatus.ColumnEdit = grdPhasen.GetLOVLookUpEdit("KaAbklaerungStatusDossier");
            colPraesenz.ColumnEdit = grdPhasen.GetLOVLookUpEdit("KaAbklaerungPraesenz");
            colBeurteilung.ColumnEdit = grdPhasen.GetLOVLookUpEdit("KaAbklaerungIntegrBeur");

            SetEditMode();
            FillPhasen();
        }

        #endregion

        #region Private Methods

        private void FillPhasen()
        {
            qryPhasen.Fill(@"
                select	AKP.*,
                        Kurs = KUE.KursNr + isNull(', ' + KUR.Name, ''),
                        KursDetail = KUE.KursNr + isNull(', ' + KUR.Name, '')
                                     + isNull(', ' + Convert(VARCHAR(15), KUE.DatumVon, 104), '')
                                     + isNull(' - ' + Convert(VARCHAR(15), KUE.DatumBis, 104), '')
                                     + CASE WHEN KUE.SistiertFlag = 1 THEN ', sistiert' ELSE '' END
                from	KaAKPhasen AKP
                    left join KaKurserfassung KUE on KUE.KaKurserfassungID = AKP.KursID
                    left join KaKurs KUR on KUR.KaKursID = KUE.KursID
                where	AKP.FaLeistungID = {0}
                and (AKP.SichtbarSDFlag = {1} or AKP.SichtbarSDFlag = 1)
                order by AKP.Datum DESC",
                _faLeistungID, Session.User.IsUserKA ? 0 : 1);
        }

        private string GetAuswahlList(KissCheckedLookupEdit aLookup)
        {
            string[] arr = new[] { aLookup.EditValue };

            string kriterienCodes = "";
            foreach (string s in arr)
            {
                if (s != "")
                {
                    if (kriterienCodes != "")
                        kriterienCodes += ",";
                    kriterienCodes += s;
                }
            }

            return kriterienCodes;
        }

        private bool IsInstitutionRav()
        {
            var cnt = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"SELECT COUNT(*)
                        FROM KaAKZuweiser AKZ
                            LEFT JOIN BaInstitution ORG ON ORG.BaInstitutionID = AKZ.InstitutionID
                        WHERE AKZ.FaLeistungID = {0}
                        AND AKZ.InstitutionID > 0
                        AND ORG.Name like 'RAV%'"
                , _faLeistungID));

            return cnt > 0;
        }

        private bool IsInstitutionSd()
        {
            var parID = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"SELECT IsNull(ParentID, 0)
                    FROM XOrgUnit ORG1
                    WHERE ORG1.OrgUnitID = - (SELECT IsNull(InstitutionID, 0) FROM KaAKZuweiser WHERE FaLeistungID = {0})"
                    , _faLeistungID));

            return parID == 30;
        }

        private void NeuePhaseOeffnen(string phase, int phasenCode, bool isQj)
        {
            if (KissMsg.ShowQuestion("CtlKaAKPhasen", "PhaseEroeffnen", "Soll eine Phase {0} eröffnet werden?", 0, 0, true, phase))
            {
                if (isQj && PhaseExist(703))
                {
                    // Only for Qualifizierung Jugend!!!
                    KissMsg.ShowInfo("CtlKaAKPhasen", "KeinePhaseErstellt", "Es besteht eine offene Phase {0}. Keine neue Phase erstellt!", 0, 0, phase);
                }
                else
                {
                    if (isQj)
                    {
                        int oldPersSichtbar = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"select PersonSichtbarSDFlag from BaPerson where BaPersonID = {0}",
                            _baPersonID));

                        // Insert a new 'Qualifizierung Jugend'
                        DBUtil.ExecSQL(@"
                            insert FaLeistung (BaPersonID, ModulID, UserID, DatumVon, FaProzessCode, FaFallID, Creator, Created, Modifier, Modified)
                                          values ({0}, 7, {1}, getdate(), 703, {0}, {2}, getdate(), {2}, getdate())",
                            _baPersonID,
                            Session.User.UserID,
                            DBUtil.GetDBRowCreatorModifier());

                        DBUtil.ExecSQL(@"UPDATE BaPerson SET PersonSichtbarSDFlag = {0}, Modifier = {1}, Modified = GetDate() WHERE BaPersonID = {2}", oldPersSichtbar, DBUtil.GetDBRowCreatorModifier(), _baPersonID);

                        //this.GetKissMainForm().TreeFallRefresh();
                        FormController.SendMessage("FrmFall", "Action", "RefreshTree");
                    }
                    else
                    {
                        //qryPhasen.RowModified = true;
                        qryPhasen["IntegrationCode"] = ddlIntegrationCode.EditValue;
                        if (qryPhasen.Post())
                        {
                            DataRow r = qryPhasen.Insert();

                            if (!DBUtil.IsEmpty(r))
                            {
                                qryPhasen["PhasenCode"] = phasenCode;
                                qryPhasen["Datum"] = DateTime.Today;
                            }
                            else
                            {
                                qryPhasen["IntegrationCode"] = null;
                            }
                        }
                    }
                }
            }
        }

        private bool PhaseExist(int faProzessCode)
        {
            // Check if there exists a open process!
            return Convert.ToInt32(
                DBUtil.ExecuteScalarSQL(@"select count(*) from FaLeistung
                                          where BaPersonID = {0}
                                          and   FaProzessCode = {1}
                                          and   ModulID = 7
                                          and   DatumBis is null",
                    _baPersonID,
                    faProzessCode)) > 0;
        }

        private void SetEditMode()
        {
            bool unused;
            DBUtil.GetFallRights(_faLeistungID, out unused, out _mayIns, out _mayUpd, out _mayDel, out unused, out unused);
            qryPhasen.CanUpdate = _mayUpd && DBUtil.UserHasRight("CtlKaAKPhasen", "U");
            qryPhasen.CanInsert = _mayIns && DBUtil.UserHasRight("CtlKaAKPhasen", "I");
            qryPhasen.CanDelete = _mayDel && DBUtil.UserHasRight("CtlKaAKPhasen", "D");
            qryPhasen.EnableBoundFields();

            var editModeNormal = qryPhasen.CanUpdate ? EditModeType.Normal : EditModeType.ReadOnly;

            // datAustritt
            int phaseCode = Utils.ConvertToInt(ddlPhase.EditValue);

            //9: PvB EAF Sozioberufliche Bilanz, 13: PvB EAF Spezifische Ermittlung
            datAustritt.EditMode = (phaseCode == 9 || phaseCode == 13) ? editModeNormal : EditModeType.ReadOnly;
        }

        #endregion

        private void qryPhasen_AfterPost(object sender, EventArgs e)
        {
            try
            {
                KaUtil.UpdateKaArbeitsRapportRecords(_faLeistungID);

                Session.Commit();
            }
            catch (Exception exc)
            {
                Session.Rollback();
                KissMsg.ShowInfo(exc.Message);
                throw new KissCancelException();
            }
        }

        #endregion
    }
}