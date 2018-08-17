using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

using Kiss.Interfaces.UI;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

namespace KiSS4.Klientenbuchhaltung
{
    #region Enumerations

    enum KbAuszahlungsart
    {
        ElektorinscheAuszahlung = 101,
        Papierverfügung = 102,
        Barauszahlung = 103,
        Check = 104,
        InterneVerrechnung = 105,
        Vorerfassung = 106
    }

    #endregion

    public partial class CtlKbAuszahlungVerbuchen : KissSearchUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        /// <summary>
        /// KbBelegKreisCode for manual bookings
        /// </summary>
        private const int BELEGKREIS_MANUELLEBUCHUNG = 10;
        private const string CLASSNAME = "CtlKbAuszahlungVerbuchen";
        private const string GV_AUSZAHLUNG_POSITION_ID = "GvAuszahlungPositionID";

        #endregion

        #region Private Fields

        private bool _isKliBuIntegriert;

        /// <summary>
        /// Der aktuelle Mandant.
        /// </summary>
        private int _kbMandantID;
        private Int32 _kbPeriodeID;

        #endregion

        #endregion

        #region Constructors

        public CtlKbAuszahlungVerbuchen()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void CtlKbAuszahlungVerbuchen_Load(object sender, EventArgs e)
        {
            SetupDataMembers();
            SetupFieldNames();
            SetupRequiredFields();

            try
            {
                if (DBUtil.GetConfigString(@"System\KliBu\KliBuSys", "Integriert").ToUpper().Equals("KEIN"))
                {
                    _isKliBuIntegriert = false;
                    _kbPeriodeID = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                        SELECT KbPeriodeID
                        FROM KbPeriode
                        WHERE PeriodeStatusCode = 1 -- Aktiv
                          AND (GETDATE() BETWEEN PeriodeVon AND PeriodeBis)"));

                }
                else
                {
                    _isKliBuIntegriert = true;
                    _kbPeriodeID = (int)FormController.GetMessage("FrmKbKlientenbuchhaltung", false, "Action", "KbPeriodeID");
                    _kbMandantID = Convert.ToInt32(FormController.GetMessage("FrmKbKlientenbuchhaltung", false, "Action", "KbMandantID"));
                }
            }
            catch (Exception ex)
            {
                // DEBUG ONLY: Remove this
                MessageBox.Show("DEBUG code active: " + ex.Message);
                Debug.WriteLine("CtlKbZahlungslauf.ClassLoad - DEBUG code active");
                _kbPeriodeID = -1;
            }

            // --- drop-downbox für Zahlungskonto füllen
            qryZahlungskonto.Fill(_kbPeriodeID);
            edtKbZahlungskonto.LoadQuery(qryZahlungskonto);
            edtKbZahlungskonto.ItemIndex = 0;

            qryBuchung.SelectStatement = GetQryBuchungSelectStatement();
            qryZugehoerigeBuchung.SelectStatement = GetQryZugehoerigeBuchungSelectStatement();

            // --- set editmodes
            SetEditModes();
            //SetAusgleichKnopf();

            // --- Buchungsstatus laden
            repBuchungStatus.SmallImages = KissImageList.SmallImageList;
            SqlQuery qryStati = DBUtil.OpenSQL(@"
                    SELECT *
                    FROM dbo.XLOVCode WITH (READUNCOMMITTED)
                    WHERE LOVName = 'KbBuchungsStatus'
                    ORDER BY SortKey");

            foreach (DataRow row in qryStati.DataTable.Rows)
            {
                repBuchungStatus.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(
                    row["Text"].ToString(),
                    (int)row["Code"],
                    KissImageList.GetImageIndex(Convert.ToInt32(row["Value1"]))));
            }

            grvKbAuszahlungen.OptionsView.ColumnAutoWidth = true;
            ////grvZugehoerigeBuchungen.OptionsView.ColumnAutoWidth = true;
            NewSearch();
        }

        private void btnStatusReset_Click(object sender, EventArgs e)
        {
            bool confirmed = KissMsg.ShowQuestion(Name, "ResetBuchungStatus", "Wollen Sie den Status der Buchung mit ID {0} jetzt zurücksetzen?", true, qryBuchung[DBO.KbBuchung.KbBuchungID]);
            if (!confirmed)
            {
                return;
            }
            try
            {
                Session.BeginTransaction();

                DBUtil.ExecSQLThrowingException(@"
                    DECLARE @BuchungId int, @AusgleichBuchungId int, @AusgleichId int;
                    SET @BuchungId = {0}; -- Buchung welche zurückgesetzt werden muss

                    SELECT
                        @AusgleichBuchungId = OPA.AusgleichBuchungID,
                        @AusgleichId = OPA.KbOpAusgleichID
                    FROM dbo.KbOpAusgleich OPA
                    WHERE OPA.OpBuchungID = @BuchungId;

                    DELETE
                    FROM KbOpAusgleich
                    WHERE KbOpAusgleichID = @AusgleichId;

                    DELETE
                    FROM KbBuchung
                    WHERE KbBuchungID = @AusgleichBuchungId;

                    UPDATE BUC
                    SET BelegNr = NULL,
                        BarbelegDatum = NULL,
                        BarbelegUserID = NULL,
                        Remark = NULL,
                        KbBuchungStatusCode = 2
                    FROM KbBuchung BUC
                    WHERE KbBuchungID = @BuchungId;", qryBuchung[DBO.KbBuchung.KbBuchungID]);

                Session.Commit();

                // refresh grid
                qryBuchung.Refresh();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                throw new KissErrorException(KissMsg.GetMLMessage(Name, "ResetVerbuchtError", "Fehler beim Zurücksetzen des Status."), ex);
            }
        }

        private void btnVerbuchen_Click(object sender, EventArgs e)
        {
            try
            {
                DBUtil.CheckNotNullField(edtBelegDatum, lblBelegDatum.Text);
                DBUtil.CheckNotNullField(edtBuchungsDatum, lblBuchungsDatum.Text);
            }
            catch (KissInfoException ex)
            {
                ex.ShowMessage();
                ex.ctlFocus.Focus();
                return;
            }

            // mit integrierter KliBu müssen die Belegdatum und Buchungsdatum in der Periode gültig sein.
            if (_isKliBuIntegriert)
            {
                if (!CheckBelegDatum(_kbPeriodeID, qryBuchung[DBO.KbBuchung.BelegDatum] as DateTime?))
                {
                    KissMsg.ShowInfo(
                        Name,
                        "InvalidBelegDatum",
                        "Das Belegdatum ist leer oder ungültig. Möglicherweise ist die Periode ist nicht aktiv.",
                        KissMsgCode.MsgInfo);
                    edtBelegDatum.Focus();
                    return;
                }

                if (!CheckBelegDatum(_kbPeriodeID, qryBuchung["AusgleichBelegDatum"] as DateTime?))
                {
                    KissMsg.ShowInfo(
                        Name,
                        "InvalidBelegDatum",
                        "Das Belegdatum ist leer oder ungültig. Möglicherweise ist die Periode ist nicht aktiv.",
                        KissMsgCode.MsgInfo);
                    edtBuchungsDatum.Focus();
                    return;
                }
            }

            // Ask for confirmation
            bool confirmation = KissMsg.ShowQuestion(KissMsg.GetMLMessage(Name,
                                                        "QuestionManuellVerbuchen",
                                                        "Soll die Buchung mit ID {0} jetzt verbucht werden?",
                                                        qryBuchung[DBO.KbBuchung.KbBuchungID]),
                                 true);

            if (!confirmation)
            {
                return;
            }

            // Formulardaten speichern
            if (!qryBuchung.Post())
            {
                Debug.WriteLine("qryBuchung.Post failed.");
                return;
            }

            // hole die account information für das ausgewählte aktiv konto
            DataRow row = qryZahlungskonto.DataTable.Rows[edtKbZahlungskonto.ItemIndex];
            KbZahlungskonto account = new KbZahlungskonto(row);

            qryAktivKonto.Fill(
            _kbPeriodeID,
            account.KbZahlungskontoID);

            Int32 aktivKontoId = Utils.ConvertToInt(qryAktivKonto["KbKontoId"]);
            String aktivKonto = Utils.ConvertToString(qryAktivKonto["KontoNr"]);
            Debug.WriteLine("AktivKonto : " + aktivKonto + " / " + aktivKontoId.ToString());

            if (aktivKontoId == 0)
            {
                KissMsg.ShowError(
                    "CtlKbAuszahlungVerbuchen",
                    "AktivKontoNichtSpezifiziert",
                    "Das gewählte Zahlungskonto ist im Kontenplan keinem Konto zugewiesen.");

                return;
            }

            Cursor = Cursors.WaitCursor;
            // starte die transaktion
            Session.BeginTransaction();
            try
            {
                Int32 buchungId = Utils.ConvertToInt(qryBuchung["KbBuchungId"]);
                Decimal betrag = Utils.ConvertToDecimal(qryBuchung["Betrag"]);
                String habenKtoNr = Utils.ConvertToString(qryBuchung["HabenKtoNr"]);

                if (_isKliBuIntegriert)
                {
                    DateTime belegDatum = Convert.ToDateTime(qryBuchung[DBO.KbBuchung.BelegDatum]);

                    // get new BelegNr
                    int kbBelegKreisId;
                    int newBelegNr = GetNewBelegNr(_kbMandantID, BELEGKREIS_MANUELLEBUCHUNG, belegDatum, out kbBelegKreisId);

                    // update BelegNr on KbBuchung depending on BgPositionID and new number
                    int rowCountBuc = Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                        UPDATE dbo.KbBuchung
                        SET BelegNr = {0},
                            KbBelegKreisID = {1},
                            KbBuchungStatusCode = 13    -- Verbucht
                        WHERE BelegNr IS NULL           -- security (do never overwrite an existing BelegNr)
                          AND KbBuchungStatusCode = 2   -- Freigegeben
                          AND KbBuchungID = {2};

                        SELECT @@ROWCOUNT;",
                        newBelegNr,
                        kbBelegKreisId,
                        buchungId));

                    // validate
                    if (rowCountBuc < 1)
                    {
                        throw new KissInfoException(
                            KissMsg.GetMLMessage(
                                Name,
                                "BookingNoEntryUpdated",
                                "Es wurde keine Buchung zum Verbuchen gefunden."));
                    }
                }

                // Ausgleichsbuchung erstellen
                Int32 ausgleichBuchungId = Balance.ErstelleAusgleichsBuchung(betrag, habenKtoNr, aktivKonto, _kbPeriodeID, edtBuchungsDatum.DateTime);

                Int32 ausgleichId = Balance.ErstelleAusgleichEintrag(buchungId, ausgleichBuchungId, betrag);
                Debug.WriteLine("Ausgleich: {0}", ausgleichId);

                // markiere Buchung als 'Ausgeglichen'.
                Balance.AktualisiereBuchungsStatus(buchungId, 6);

                Session.Commit();
            }
            catch (Exception ex)
            {
                // catch über alle Typen von Exceptions muss immer vorhanden sein!
                // hier darf kein Code stehen!
                // Reihenfolge darf hier nicht vertauscht werden!
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            qryBuchung.Refresh();
            qryZugehoerigeBuchung.Refresh();
        }

        private void edtSucheFT_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.PersonSuchen(edtSucheFT.Text, e.ButtonClicked);

            if (!e.Cancel)
            {
                edtSucheFT.EditValue = dlg["Name"];
                edtSucheFT.LookupID = dlg["BaPersonID"];
            }
        }

        private void qryBuchung_PositionChanged(object sender, EventArgs e)
        {
            int? budgetId = GetIntOrNull(qryBuchung[DBO.KbBuchung.BgBudgetID]);
            int? gvAuszahlungPositionId = GetIntOrNull(qryBuchung[GV_AUSZAHLUNG_POSITION_ID]);
            qryZugehoerigeBuchung.Fill(budgetId.GetValueOrDefault(), gvAuszahlungPositionId.GetValueOrDefault());
            if (budgetId.HasValue)
            {
                lblZugehoerigeBuchungTitel.Text = KissMsg.GetMLMessage(Name, "ZugehBuchungenTitel", "Alle Belege aus Budget: {0} {1}",
                                                        qryZugehoerigeBuchung[DBO.BgBudget.Monat],
                                                        qryZugehoerigeBuchung[DBO.BgBudget.Jahr]);
            }
            else
            {
                lblZugehoerigeBuchungTitel.Text = KissMsg.GetMLMessage(Name, "ZugehBuchungenTitelGesuch", "Alle Belege aus Gesuchsverwaltung: {0} {1}",
                                                        qryZugehoerigeBuchung[DBO.BgBudget.Monat],
                                                        qryZugehoerigeBuchung[DBO.BgBudget.Jahr]);
            }
            SetEditModes();
            SetAusgleichKnopf();
            SetStatusResetButton();
            SetDefaultDates();
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();
            ClearDetailView();
            SetEditModes();
            SetAusgleichKnopf();
            SetStatusResetButton();
        }

        #endregion

        #region Private Static Methods

        private static bool CheckBelegDatum(int kbPeriodeID, DateTime? belegDatum)
        {
            return Convert.ToBoolean(DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT dbo.fnKbCheckBelegDatum ({0}, {1});", kbPeriodeID, belegDatum));
        }

        /// <summary>
        /// Validates BelegNr for given KbPeriodeID
        /// </summary>
        /// <param name="kbPeriodeID">The id of KbPeriode</param>
        /// <param name="belegNr">The BelegNr to validate within KbPeriode</param>
        /// <returns><c>True</c> if BelegNr is valid, otherwise <c>False</c></returns>
        private static bool CheckBelegNummer(int kbPeriodeID, int belegNr)
        {
            if (kbPeriodeID < 1 || belegNr < 1)
            {
                return false;
            }

            return Convert.ToBoolean(DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT dbo.fnKbCheckBelegNr ({0}, {1}, NULL, {2}, NULL);", kbPeriodeID,
                                                                         BELEGKREIS_MANUELLEBUCHUNG, // lov KbBelegkreis
                                                                         belegNr));
        }

        /// <summary>
        /// Get new BelegNr for bookings. This call should always be done within an open transaction.
        /// </summary>
        /// <param name="kbMandantID">The id of the KbMandant</param>
        /// <param name="kbBelegKreisCode">The code-id of the entry within KbBelegKreis</param>
        /// <param name="belegDatum">The date for getting the KbPeriodeID</param>
        /// <param name="kbBelegKreisId">The id of KbBelegKreis</param>
        /// <returns>A valid BelegNr for the given parameters</returns>
        /// <exception cref="KissCancelException">Thrown in case of validation error</exception>
        private static int GetNewBelegNr(int kbMandantID, int kbBelegKreisCode, DateTime belegDatum, out int kbBelegKreisId)
        {
            // get current KbPeriodeID for given parameters
            int kbPeriodeID = Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT ISNULL(dbo.fnKbGetPeriodeIDByDate({0}, {1}, NULL, 1), -1);", kbMandantID, belegDatum));

            // validate current mandant-id
            if (kbMandantID < 1)
            {
                // invalid BgPositionID
                throw new KissCancelException(KissMsg.GetMLMessage(CLASSNAME,
                                                                   "BelegNrInvalidMandantID",
                                                                   "Die aktuelle Mandant-ID ist ungültig."));
            }

            // validate current belegKreis
            if (kbBelegKreisCode < 1)
            {
                // invalid BgPositionID
                throw new KissCancelException(KissMsg.GetMLMessage(CLASSNAME,
                                                                   "BelegNrInvalidBelegKreis",
                                                                   "Der aktuelle Belegkreis ist ungültig."));
            }

            // validate current BgBudgetID
            if (belegDatum == default(DateTime))
            {
                // invalid BgBudgetID
                throw new KissCancelException(KissMsg.GetMLMessage(CLASSNAME,
                                                                   "BelegNrInvalidBelegDatum",
                                                                   "Das aktuelle Belegdatum ist ungültig."));
            }

            // validate PeriodeID
            if (kbPeriodeID < 0)
            {
                // invalid KbPeriodeID
                throw new KissCancelException(KissMsg.GetMLMessage(CLASSNAME,
                                                                   "BelegNrCouldNotGetKbPeriodeID",
                                                                   "Es konnte keine gültige KbPeriodeID anhand der Mandant-ID und Belegdatums gefunden werden."));
            }

            // get unique record number
            object newBelegNrObj = DBUtil.ExecuteScalarSQLThrowingException(@"
                EXEC dbo.spKbGetBelegNr {0}, {1}, NULL, 0;", kbPeriodeID, kbBelegKreisCode);

            // validate content of new BelegNr
            if (newBelegNrObj == null || !(newBelegNrObj is int) || Convert.ToInt32(newBelegNrObj) < 1)
            {
                // invalid new record number (empty/not int/out of scope)
                throw new KissCancelException(KissMsg.GetMLMessage(CLASSNAME,
                                                                   "InvalidNewRecordNumberValue",
                                                                   "Die automatisch generierte BelegNr. hat einen ungültigen Wert."));

            }

            // set number
            int newBelegNr = Convert.ToInt32(newBelegNrObj);

            // validate new record number for security purpose
            if (!CheckBelegNummer(kbPeriodeID, newBelegNr))
            {
                // invalid new record number (duplicate)
                throw new KissCancelException(KissMsg.GetMLMessage(CLASSNAME,
                                                                   "InvalidNewRecordNumberUnique",
                                                                   "Die automatisch generierte BelegNr. ('{0}') existiert bereits und kann für die Periode ('{1}') nicht nochmals verwendet werden.",
                                                                   newBelegNr,
                                                                   kbPeriodeID));
            }

            // get the ID of the KbBelegKreis
            kbBelegKreisId = Convert.ToInt32(KliBuUtil.GetKbBelegKreisId(kbPeriodeID,kbBelegKreisCode));

            // if we are here, the new BelegNr is valid
            return newBelegNr;
        }

        #endregion

        #region Private Methods

        private void ClearDetailView()
        {
            edtBeguenstigtName.Text = string.Empty;
            edtBeguenstigtName2.Text = string.Empty;
            edtBeguenstigtOrt.Text = string.Empty;
            edtBeguenstigtPLZ.Text = string.Empty;
            edtBankName.Text = string.Empty;
            edtBankKontoNr.Text = string.Empty;
            edtPCKontoNr.Text = string.Empty;
            edtIBAN.Text = string.Empty;
            edtBetrag.Text = string.Empty;
            edtBelegNr.Text = string.Empty;
            edtBelegDatum.Text = string.Empty;
            edtBuchungsDatum.Text = string.Empty;

            qryZugehoerigeBuchung.Fill(-1, -1);

            lblZugehoerigeBuchungTitel.Text = KissMsg.GetMLMessage(Name, "ZugehBuchungenTitel", "Alle Belege aus Budget: {0} {1}", "", "");
        }

        private int? GetIntOrNull(object qryIntValue)
        {
            return qryIntValue as int?;
        }

        private string GetQryBuchungSelectStatement()
        {
            string periodeWhereCondition = "BUC.KbPeriodeID";

            var auszahlungsArten = new Collection<int>
                                       {
                                           (int)KbAuszahlungsart.Papierverfügung,
                                           (int)KbAuszahlungsart.Check
                                       };

            if (_isKliBuIntegriert)
            {
                periodeWhereCondition = _kbPeriodeID.ToString();
            }
            else
            {
                auszahlungsArten.Add((int)KbAuszahlungsart.Barauszahlung);
            }

            string auszahlungsArtCsv = string.Join(",", auszahlungsArten);

            string selectStatement = string.Format(@"
                 SELECT
                    BUC.KbBuchungID,
                    BUC.KbBuchungTS,
                    BUC.BelegDatum,
                    BUC.BelegNr,
                    BUC.Betrag,
                    Falltraeger = (SELECT NameVorname FROM vwPerson WHERE BaPersonID = LEI.BaPersonID), --Klient
                    BUC.Text,
                    BUC.KbBuchungStatusCode,
                    AusgleichBelegDatum = BUC2.Belegdatum,
                    BUC.BeguenstigtName,
                    BUC.BeguenstigtName2,
                    BUC.BeguenstigtPLZ,
                    BUC.BeguenstigtOrt,
                    BUC.BankName,
                    BUC.BankKontoNr,
                    BUC.PCKontoNr,
                    BUC.IBAN,
                    BUC.HabenKtoNr,
                    BUC.BgBudgetID,
                    GvAuszahlungPositionID = GAP.GvAuszahlungPositionID
                FROM dbo.KbBuchung            BUC
                  LEFT JOIN dbo.BgBudget      BDG  ON BDG.BgBudgetID = BUC.BgBudgetID
                  LEFT JOIN dbo.BgFinanzplan  FNP  ON FNP.BgFinanzplanID = BDG.BgFinanzplanID
                  LEFT JOIN dbo.FaLeistung    LEI  ON LEI.FaLeistungID = FNP.FaLeistungID
                  LEFT JOIN dbo.KbOpAusgleich OPA  ON BUC.KbBuchungId = OPA.OpBuchungId
                  LEFT JOIN dbo.KbBuchung     BUC2 ON BUC2.KbBuchungId = OPA.AusgleichBuchungId
                  OUTER APPLY (SELECT GvAuszahlungPositionID = MIN(GvAuszahlungPositionID)
                               FROM dbo.KbBuchungKostenart BKO
                               WHERE BKO.KbBuchungID = BUC.KbBuchungID) GAP
                WHERE BUC.KbAuszahlungsArtCode IN ({0}) -- Papierverfügung, Check
                  AND BUC.KbPeriodeID = {1}
                  AND (BDG.BgBudgetID IS NOT NULL OR GAP.GvAuszahlungPositionID IS NOT NULL)
                ---  AND {{edtSucheFT.LookupID}} =  LEI.BaPersonID
                ---  AND {{edtSucheDatumVon}} <= BUC.BelegDatum
                ---  AND {{edtSucheDatumBis}} >= BUC.BelegDatum
                ---  AND {{edtSucheBudgetNr}} = BUC.BgBudgetID
                ---  AND {{edtSucheBuchungId}} = BUC.KbBuchungID",
                auszahlungsArtCsv,
                periodeWhereCondition);

            return selectStatement;
        }

        private string GetQryZugehoerigeBuchungSelectStatement()
        {
            string selectStatement = @"
                SELECT
                  BUC.KbBuchungID,
                  BUC.KbBuchungTS,
                  BUC.BelegDatum,
                  BUC.BelegNr,
                  BUC.Betrag,
                  Falltraeger = (SELECT NameVorname FROM vwPerson WHERE BaPersonID = LEI.BaPersonID), --Klient
                  BUC.Text,
                  BUC.KbBuchungStatusCode,
                  BDG.Jahr,
                  Monat = dbo.fnLOVText('Monat', BDG.Monat)
                FROM dbo.KbBuchung           BUC
                  LEFT JOIN dbo.BgBudget     BDG ON BDG.BgBudgetID = BUC.BgBudgetID
                  LEFT JOIN dbo.BgFinanzplan FNP ON FNP.BgFinanzplanID = BDG.BgFinanzplanID
                  LEFT JOIN dbo.FaLeistung   LEI ON LEI.FaLeistungID = FNP.FaLeistungID
                  OUTER APPLY (SELECT GvAuszahlungPositionID = MIN(GvAuszahlungPositionID)
                               FROM dbo.KbBuchungKostenart BKO
                               WHERE BKO.KbBuchungID = BUC.KbBuchungID) GAP
                WHERE BUC.BgBudgetID = {0} OR GAP.GvAuszahlungPositionID = {1}";

            return selectStatement;
        }

        /// <summary>
        /// 
        /// </summary>
        private Boolean IsEditable()
        {
            Boolean editable;
            Int32 statusCode = Utils.ConvertToInt(qryBuchung["KbBuchungStatusCode"]);

            switch (statusCode)
            {
                case 2:  // freigegeben
                case 7:  // gesperrt
                case 13: // verbucht
                    editable = true;
                    break;

                case 4:  // Barbeleg ausgedruckt
                    if (!_isKliBuIntegriert)
                    {
                        editable = true;
                    }
                    else
                    {
                        editable = false;
                    }
                    break;

                case 1:  // vorbereitet
                case 3:  // ZahlauftragErstellt
                case 5:  // ZahlauftragFehlerhaft
                case 6:  // ausgeglichen
                case 8:  // storniert
                case 9:  // Rückläufer
                case 10: // teilweise ausgeglichen
                case 11: // Barbezug
                case 12: // angefragt
                case 14: // bewilligt
                case 15: // abgelehnt
                    editable = false;
                    break;

                default:
                    editable = false;
                    break;
            }

            return editable;
        }

        private Boolean IstAusgleichbar()
        {
            return IsEditable();
        }

        /// <summary>
        /// 
        /// </summary>
        private Boolean IstBereitsAusgeglichen(Int32 buchungId)
        {
            Boolean ausgeglichen;

            qryAusgleichExists.Fill(buchungId);

            if (qryAusgleichExists.Count > 0)
            {
                Debug.WriteLine("Buchung " + buchungId.ToString() + " ist bereits ausgeglichen");
                ausgeglichen = true;
            }
            else
            {
                ausgeglichen = false;
            }

            return ausgeglichen;
        }

        private void SetAusgleichKnopf()
        {
            bool ausgleichbar = false;

            if (qryZahlungskonto.Count > 0)
            {
                Int32 buchungId = Utils.ConvertToInt(qryBuchung["KbBuchungId"]);
                ausgleichbar = IstAusgleichbar() && !IstBereitsAusgeglichen(buchungId);
            }

            btnVerbuchen.Enabled = ausgleichbar;
        }

        private void SetDefaultDates()
        {
            if (edtBelegDatum.EditValue == DBNull.Value)
            {
                edtBelegDatum.DateTime = DateTime.Today;
            }
            if (edtBuchungsDatum.EditValue == DBNull.Value && IsEditable())
            {
                edtBuchungsDatum.DateTime = DateTime.Today;
            }
        }

        private void SetEditModes()
        {
            Boolean editable = IsEditable();
            EditModeType editMode;

            if (editable)
            {
                editMode = EditModeType.Required;
            }
            else
            {
                editMode = EditModeType.ReadOnly;
            }

            edtBelegNr.EditMode = !_isKliBuIntegriert && editMode == EditModeType.Required ? EditModeType.Normal : EditModeType.ReadOnly;
            edtBelegDatum.EditMode = editMode;
            edtBuchungsDatum.EditMode = editMode;
        }

        private void SetStatusResetButton()
        {
            btnStatusReset.Visible = !_isKliBuIntegriert;
            int? statusCode = qryBuchung[DBO.KbBuchung.KbBuchungStatusCode] as int?;
            btnStatusReset.Enabled = statusCode.HasValue &&
                                        (statusCode.Value == 6 ||   // Status ausgeglichen
                                        statusCode.Value == 13 ||   // Status verbucht
                                        statusCode.Value == 4);     // Status barbeleg ausgedruckt
        }

        private void SetupDataMembers()
        {
            edtBelegNr.DataMember = DBO.KbBuchung.BelegNr;
            edtBelegDatum.DataMember = DBO.KbBuchung.BelegDatum;
        }

        private void SetupFieldNames()
        {
            colBuchungId.FieldName = DBO.KbBuchung.KbBuchungID;
            colBelegDatum.FieldName = DBO.KbBuchung.BelegDatum;
            colBelegNr.FieldName = DBO.KbBuchung.BelegNr;
            colBetrag.FieldName = DBO.KbBuchung.Betrag;
            colFalltraeger.FieldName = "Falltraeger";
            colBuchungstext.FieldName = DBO.KbBuchung.Text;
            colBuchungsstatus.FieldName = DBO.KbBuchung.KbBuchungStatusCode;

            colZugehBuchungId.FieldName = DBO.KbBuchung.KbBuchungID;
            colZugehBelegDatum.FieldName = DBO.KbBuchung.BelegDatum;
            colZugehBelegNr.FieldName = DBO.KbBuchung.BelegNr;
            colZugehBetrag.FieldName = DBO.KbBuchung.Betrag;
            colZugehFT.FieldName = "Falltraeger";
            colZugehText.FieldName = DBO.KbBuchung.Text;
            colZugehStat.FieldName = DBO.KbBuchung.KbBuchungStatusCode;
        }

        private void SetupRequiredFields()
        {
            if (_isKliBuIntegriert)
            {
                edtBelegNr.EditMode = EditModeType.ReadOnly;
            }
            else
            {
                edtBelegNr.EditMode = EditModeType.Normal;
            }
            edtBelegDatum.EditMode = EditModeType.Required;
            edtBuchungsDatum.EditMode = EditModeType.Required;
        }

        #endregion

        #endregion
    }
}