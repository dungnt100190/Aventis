using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Messages;
using System;
using System.Collections.Generic;

namespace KiSS4.BDE.ExcelImport
{
    public class BdeImportWriter
    {
        private const string MASK_NAME = "FrmBDEZeiterfassung";

        private const string SELECT_BDE_LEISTUNG = @"
            SELECT
              BDELeistungID,
              UserID,
              BDELeistungsartID,
              KostenstelleOrgUnitID,
              Datum,
              Dauer,
              LohnartCode,
              HistKostentraeger,
              HistKostenstelle,
              HistKostenart,
              HistMandantNr,
              Bemerkung,
              Visiert
            FROM dbo.BDELeistung
            WHERE UserID = {0}
              AND Datum = {1}
              AND LohnartCode = {2}
              AND BDELeistungsartID = {3};";

        private readonly IEnumerable<BdeLeistungDTO> _dtos;
        private readonly DateTime _importTimeStamp;
        private readonly SqlQuery _qryBdeLeistung;

        public BdeImportWriter(IEnumerable<BdeLeistungDTO> dtos)
        {
            _dtos = dtos;

            _qryBdeLeistung = new SqlQuery
            {
                SelectStatement = SELECT_BDE_LEISTUNG,
                CanInsert = true,
                CanUpdate = true,
                CanDelete = true,
                TableName = DBO.BDELeistung.DBOName
            };

            _importTimeStamp = DateTime.Now;
        }

        public void WriteToDatabase()
        {
            DlgProgressLog.Show("Excel-Import", true, false, 900, 500, ProgressStart, null, Session.MainForm);
        }

        private bool InsertBdeLeistung(BdeLeistungDTO bdeLeistungDTO)
        {
            // Musswerte aus DB holen

            // Kostenstelle
            var kostenStelleOrgUnitId = Utils.ConvertToInt(DBUtil.ExecuteScalarSQL(@"
                        SELECT OrgUnitID
                        FROM dbo.XOrgUnit
                        WHERE Kostenstelle = dbo.fnBDEGetHistKostenstellePerDate({0}, {1}, NULL);", bdeLeistungDTO.UserId, bdeLeistungDTO.Datum));

            if (kostenStelleOrgUnitId <= 0)
            {
                DlgProgressLog.AddError(
                    KissMsg.GetMLMessage(
                        MASK_NAME,
                        "ExcelImportKeineKostenstelle",
                        "Für den Mitarbeiter {0} existiert am {1} keine Kostenstelle.",
                        bdeLeistungDTO.MitarbeiterNr,
                        bdeLeistungDTO.Datum));
                return false;
            }

            var histKostenstelle = BdeUtil.GetKostenstelleAtDate(bdeLeistungDTO.UserId, bdeLeistungDTO.Datum, kostenStelleOrgUnitId);

            if (histKostenstelle <= 0)
            {
                DlgProgressLog.AddError(
                    KissMsg.GetMLMessage(
                        MASK_NAME,
                        "ExcelImportKeineKostenstelle",
                        "Für den Mitarbeiter {0} ist am {1} keine Kostenstelle definiert.",
                        bdeLeistungDTO.MitarbeiterNr,
                        bdeLeistungDTO.Datum.ToShortDateString()));
                return false;
            }

            // Kostenträger
            var histKostentraegerQry = BdeUtil.GetKostentraegerAtDate(bdeLeistungDTO.UserId, bdeLeistungDTO.BdeLeistungsartId, bdeLeistungDTO.Datum);
            var histKostentraeger = histKostentraegerQry.IsEmpty ? -1 : Convert.ToInt32(histKostentraegerQry["Kostentraeger"]);

            if (histKostentraeger <= 0)
            {
                DlgProgressLog.AddError(
                    KissMsg.GetMLMessage(
                        MASK_NAME,
                        "ExcelImportKeinKostentraeger",
                        "Für den Mitarbeiter {0} ist am {1} ist kein Kostenträger definiert.",
                        bdeLeistungDTO.MitarbeiterNr,
                        bdeLeistungDTO.Datum.ToShortDateString()));
                return false;
            }

            // Kostenart
            var histKostenart = BdeUtil.GetKostenartAtDate(bdeLeistungDTO.UserId, bdeLeistungDTO.BdeLeistungsartId, bdeLeistungDTO.Datum);

            if (histKostenart <= 0)
            {
                DlgProgressLog.AddError(
                    KissMsg.GetMLMessage(
                        MASK_NAME,
                        "ExcelImportKeineKostenart",
                        "Für den Mitarbeiter {0} und die Leistungsart {1} ist am {2} keine Kostenart definiert.",
                        bdeLeistungDTO.MitarbeiterNr,
                        bdeLeistungDTO.BdeLeistungsartId,
                        bdeLeistungDTO.Datum.ToShortDateString()));
                return false;
            }

            // Mandant-Nr
            var memberOrgUnit = BdeUtil.GetMemberOrgUnitAtDate(bdeLeistungDTO.UserId, bdeLeistungDTO.Datum);

            if (memberOrgUnit <= 0)
            {
                DlgProgressLog.AddError(
                    KissMsg.GetMLMessage(
                        MASK_NAME,
                        "ExcelImportKeinMitglied",
                        "Der Mitarbeiter {0} ist am {1} kein Mitglied in einer Abteilung.",
                        bdeLeistungDTO.MitarbeiterNr,
                        bdeLeistungDTO.Datum.ToShortDateString()));
                return false;
            }

            var histMandantNr = BdeUtil.GetMandantennummerAtDate(bdeLeistungDTO.Datum, memberOrgUnit);

            var msgImport = KissMsg.GetMLMessage(MASK_NAME, "ExcelImportBemerkungVom", "Excel-Import vom {0}", _importTimeStamp);

            _qryBdeLeistung.Insert();

            _qryBdeLeistung[DBO.BDELeistung.UserID] = bdeLeistungDTO.UserId;
            _qryBdeLeistung[DBO.BDELeistung.Datum] = bdeLeistungDTO.Datum;
            _qryBdeLeistung[DBO.BDELeistung.Dauer] = bdeLeistungDTO.Dauer;
            _qryBdeLeistung[DBO.BDELeistung.LohnartCode] = bdeLeistungDTO.LohnartCode;
            _qryBdeLeistung[DBO.BDELeistung.BDELeistungsartID] = bdeLeistungDTO.BdeLeistungsartId;
            _qryBdeLeistung[DBO.BDELeistung.KostenstelleOrgUnitID] = kostenStelleOrgUnitId;
            _qryBdeLeistung[DBO.BDELeistung.HistKostenstelle] = histKostenstelle;
            _qryBdeLeistung[DBO.BDELeistung.HistKostentraeger] = histKostentraeger;
            _qryBdeLeistung[DBO.BDELeistung.HistKostenart] = histKostenart;
            _qryBdeLeistung[DBO.BDELeistung.HistMandantNr] = histMandantNr;
            _qryBdeLeistung[DBO.BDELeistung.Bemerkung] = msgImport;

            try
            {
                DBUtil.NewHistoryVersion();

                if (_qryBdeLeistung.Post())
                {
                    DlgProgressLog.AddLine(
                        KissMsg.GetMLMessage(
                            MASK_NAME,
                            "ExcelImportLeistungImportiert",
                            "Leistung importiert: Mitarbeiter {0}, Datum: {1}, Dauer: {2}, Lohnart: {3}",
                            bdeLeistungDTO.MitarbeiterNr,
                            bdeLeistungDTO.Datum,
                            bdeLeistungDTO.Dauer,
                            bdeLeistungDTO.Ansatz));
                }
            }
            catch (Exception ex)
            {
                DlgProgressLog.AddError("Error: " + ex.Message);
            }

            return true;
        }

        private void ProgressStart()
        {
            var counterSuccessful = 0;
            var counterError = 0;
            var counterIgnored = 0;
            var counterUpdated = 0;
            foreach (var bdeLeistungDTO in _dtos)
            {
                if (DlgProgressLog.CancellledByUser)
                {
                    return;
                }

                // BDE-Leistungsart konnte nicht als int konvertiert werden
                if (bdeLeistungDTO.StandardKostentraeger == -1)
                {
                    counterError++;
                    DlgProgressLog.AddError(
                        KissMsg.GetMLMessage(
                            MASK_NAME,
                            "ExcelImportLeistungsartNichtGueltigeZahl",
                            "Import für Mitarbeiter mit Personal-Nr. {0} fehlgeschlagen. Die Leistungsart ist nicht eine gültige Zahl.",
                            bdeLeistungDTO.MitarbeiterNr));
                    continue;
                }

                // BDE-Leistungsart darf nicht leer sein
                if (bdeLeistungDTO.StandardKostentraeger == 0)
                {
                    counterError++;
                    DlgProgressLog.AddError(
                        KissMsg.GetMLMessage(
                            MASK_NAME,
                            "ExcelImportLeistungsartLeer",
                            "Import für Mitarbeiter mit Personal-Nr. {0} fehlgeschlagen. Die Leistungsart darf nicht leer sein.",
                            bdeLeistungDTO.MitarbeiterNr));
                    continue;
                }

                // BDE-Leistung nur erstellen wenn es eine gültige Leistungsart mit dem gewünschten ABACUS-Code gibt
                var qryLeistungsartAbacus = Utils.ConvertToInt(DBUtil.ExecuteScalarSQL(@"
                    SELECT COUNT(*)
                    FROM dbo.BDELeistungsart
                    WHERE KTRStandard = {0}
                      AND {1} BETWEEN ISNULL(DatumVon, '19000101')
                      AND ISNULL(DatumBis, '99991231');", bdeLeistungDTO.StandardKostentraeger, bdeLeistungDTO.Datum));

                if (qryLeistungsartAbacus <= 0)
                {
                    counterError++;
                    DlgProgressLog.AddError(
                        KissMsg.GetMLMessage(
                            MASK_NAME,
                            "ExcelImportLeistungsartKostentraegerNichtGefunden",
                            "Import für Mitarbeiter mit Personal-Nr. {0} fehlgeschlagen. Es konnte keine Leistungsart mit Standard Kostenträger {1} gefunden werden.",
                            bdeLeistungDTO.MitarbeiterNr, bdeLeistungDTO.StandardKostentraeger));
                    continue;
                }

                // Prüfen ob es nur eine Leistungsart mit diesem Code gibt
                if (qryLeistungsartAbacus != 1)
                {
                    counterError++;
                    DlgProgressLog.AddError(
                        KissMsg.GetMLMessage(
                            MASK_NAME,
                            "ExcelImportLeistungsartKostentraegerNichtEindeutig",
                            "Import für Mitarbeiter mit Personal-Nr. {0} fehlgeschlagen. Es konnte keine eindeutige Leistungsart mit Standard Kostenträger {1} gefunden werden.",
                            bdeLeistungDTO.MitarbeiterNr, bdeLeistungDTO.StandardKostentraeger));
                    continue;
                }

                // Benutzer überprüfen, UserID ermitteln
                var qryUser = DBUtil.OpenSQL(@"
                    SELECT TOP 1 UserID, IsLocked
                    FROM dbo.XUser
                    WHERE MitarbeiterNr = {0};", bdeLeistungDTO.MitarbeiterNr);

                if (qryUser.IsEmpty || DBUtil.IsEmpty(qryUser[DBO.XUser.UserID]))
                {
                    counterError++;
                    DlgProgressLog.AddError(
                        KissMsg.GetMLMessage(
                            MASK_NAME,
                            "ExcelImportMitarbeiterNichtVorhanden",
                            "Der Mitarbeiter mit Personal-Nr. {0} ist in KiSS nicht vorhanden. Bitte synchronisieren Sie KiSS mit Abacus und starten den Import erneut.",
                            bdeLeistungDTO.MitarbeiterNr));
                    continue;
                }

                if (!qryUser.IsEmpty && !DBUtil.IsEmpty(qryUser[DBO.XUser.UserID]) && (bool)qryUser[DBO.XUser.IsLocked])
                {
                    counterError++;
                    DlgProgressLog.AddError(
                        KissMsg.GetMLMessage(
                            MASK_NAME,
                            "ExcelImportMitarbeiterGesperrt",
                            "Der Mitarbeiter mit Personal-Nr. {0} ist in KiSS gesperrt. Der Stundenimport ist für gesperrte Benutzer nicht zulässig.",
                            bdeLeistungDTO.MitarbeiterNr));
                    continue;
                }

                bdeLeistungDTO.UserId = (int)qryUser[DBO.XUser.UserID];

                // Stundenansatz überprüfen
                var qryStundenansatz = DBUtil.OpenSQL(string.Format(@"
                    --SQLCHECK_IGNORE--
                    SELECT Ansatz = Lohnart{0}
                    FROM dbo.XUserStundenansatz
                    WHERE UserID = {{0}};", bdeLeistungDTO.Ansatz),
                    bdeLeistungDTO.UserId);

                if (qryStundenansatz.IsEmpty || DBUtil.IsEmpty(qryStundenansatz["Ansatz"]) || Utils.ConvertToDecimal(qryStundenansatz["Ansatz"]) == 0)
                {
                    counterError++;
                    DlgProgressLog.AddError(
                        KissMsg.GetMLMessage(
                            MASK_NAME,
                            "ExcelImportStundenansatzNichtVorhanden",
                            "Der Mitarbeiter mit Personal-Nr {0} hat keinen Betrag für den Stundenansatz {1} hinterlegt. Bitte synchronisieren Sie KiSS mit Abacus und starten den Import erneut.",
                            bdeLeistungDTO.MitarbeiterNr,
                            bdeLeistungDTO.Ansatz));
                    continue;
                }

                // Datum auf letzten Tag im Monat setzen
                bdeLeistungDTO.Datum = new DateTime(bdeLeistungDTO.Datum.Year, bdeLeistungDTO.Datum.Month, 1).AddMonths(1).AddDays(-1);

                // Werte aus DB holen, die für Check benötigt werden
                bdeLeistungDTO.LohnartCode = Utils.ConvertToInt(DBUtil.ExecuteScalarSQL(@"
                    SELECT Code
                    FROM dbo.XLOVCode
                    WHERE LOVName = 'BDELohnart'
                      AND Value1 = 'LA' + CONVERT(VARCHAR(2), {0});", bdeLeistungDTO.Ansatz));

                bdeLeistungDTO.BdeLeistungsartId = Utils.ConvertToInt(DBUtil.ExecuteScalarSQL(@"
                    SELECT TOP 1 BDELeistungsartID
                    FROM dbo.BDELeistungsart
                    WHERE KTRStandard = {0}
                      AND {1} BETWEEN ISNULL(DatumVon, '19000101') AND ISNULL(DatumBis, '99991231')
                    ORDER BY DatumVon DESC;", bdeLeistungDTO.StandardKostentraeger, bdeLeistungDTO.Datum));

                if (bdeLeistungDTO.BdeLeistungsartId <= 0)
                {
                    counterError++;
                    DlgProgressLog.AddError(
                        KissMsg.GetMLMessage(
                            MASK_NAME,
                            "ExcelImportLeistungsartNichtGefunden",
                            "Import für Mitarbeiter mit Personal-Nr {0} fehlgeschlagen. Es konnte keine Leistungsart für den Stunden-Import mit LeistungsartTypCode: 5 gefunden werden.",
                            bdeLeistungDTO.MitarbeiterNr));
                    continue;
                }

                //prüfen, ob der Datensatz bereits importiert wurde
                _qryBdeLeistung.Fill(bdeLeistungDTO.UserId, bdeLeistungDTO.Datum, bdeLeistungDTO.LohnartCode, bdeLeistungDTO.BdeLeistungsartId);

                if (_qryBdeLeistung.IsEmpty)
                {
                    //es gibt noch keinen Eintrag -> importieren
                    var success = InsertBdeLeistung(bdeLeistungDTO);
                    if (success)
                    {
                        counterSuccessful++;
                    }
                    else
                    {
                        counterError++;
                    }
                }
                else if (Utils.ConvertToDecimal(_qryBdeLeistung[DBO.BDELeistung.Dauer]) != bdeLeistungDTO.Dauer)
                {
                    //es gibt bereits einen Eintrag, die Dauer ist aber unterschiedlich -> aktualisieren
                    var success = UpdateBdeLeistung(bdeLeistungDTO);
                    if (success)
                    {
                        counterUpdated++;
                    }
                    else
                    {
                        counterError++;
                    }
                }
                else
                {
                    //es gibt bereits einen Eintrag, die Dauer ist identisch -> ignorieren
                    counterIgnored++;
                    DlgProgressLog.AddLine(
                        KissMsg.GetMLMessage(
                            MASK_NAME,
                            "ExcelImportBereitsVorhanden",
                            "Datensatz bereits vorhanden. Mitarbeiter {0}, Datum: {1}, Dauer: {2}, Lohnart: {3}",
                            bdeLeistungDTO.MitarbeiterNr,
                            bdeLeistungDTO.Datum.ToShortDateString(),
                            bdeLeistungDTO.Dauer,
                            bdeLeistungDTO.Ansatz));
                }
            }

            //Zusammenfassung anzeigen
            if (counterError != 0)
            {
                DlgProgressLog.AddLine(
                    KissMsg.GetMLMessage(
                        MASK_NAME,
                        "ExcelImportFehlerhaftAbgeschlossen",
                        "Import mit Fehler abgeschlossen. (Fehlerhaft: {0}, Erfolgreich: {1}, Aktualisiert: {2}, Bereits vorhanden: {3})",
                        counterError,
                        counterSuccessful,
                        counterUpdated,
                        counterIgnored));
                DlgProgressLog.EndProgress();
            }
            else
            {
                DlgProgressLog.AddLine(
                    KissMsg.GetMLMessage(
                        MASK_NAME,
                        "ExcelImportErfolgreichAbgeschlossen",
                        "Import erfolgreich abgeschlossen. (Erfolgreich: {0}, Aktualisiert: {1}, Bereits vorhanden: {2}, Fehlerhaft: {3})",
                        counterSuccessful,
                        counterUpdated,
                        counterIgnored,
                        counterError));
                DlgProgressLog.EndProgress();
            }
        }

        private bool UpdateBdeLeistung(BdeLeistungDTO bdeLeistungDTO)
        {
            var msgAktualisierung = KissMsg.GetMLMessage(MASK_NAME, "ExcelImportAktualisiertUm", ", aktualisiert um {0}", _importTimeStamp);

            if (Utils.ConvertToBool(_qryBdeLeistung[DBO.BDELeistung.Visiert]))
            {
                DlgProgressLog.AddError(
                    KissMsg.GetMLMessage(
                        MASK_NAME,
                        "ExcelImportUpdateNichtMoeglichLeistungBereitsVisiert",
                        "Die Leistung von Mitarbeiter {0}, Datum: {1}, Lohnart: {3} kann nicht aktualisiert werden. Sie ist bereits visiert.",
                        bdeLeistungDTO.MitarbeiterNr,
                        bdeLeistungDTO.Datum,
                        bdeLeistungDTO.LohnartCode));
                return false;
            }

            var dauerAlt = _qryBdeLeistung[DBO.BDELeistung.Dauer];
            _qryBdeLeistung[DBO.BDELeistung.Dauer] = bdeLeistungDTO.Dauer;
            _qryBdeLeistung[DBO.BDELeistung.Bemerkung] = _qryBdeLeistung[DBO.BDELeistung.Bemerkung] + msgAktualisierung;

            try
            {
                DBUtil.NewHistoryVersion();

                if (_qryBdeLeistung.Post())
                {
                    DlgProgressLog.AddLine(
                        KissMsg.GetMLMessage(
                            MASK_NAME,
                            "ExcelImportLeistungAktualisiert",
                            "Leistung aktualisiert: Mitarbeiter {0}, Datum: {1}, Lohnart: {2}, Dauer alt: {3}, Dauer neu: {4}",
                            bdeLeistungDTO.MitarbeiterNr,
                            bdeLeistungDTO.Datum,
                            bdeLeistungDTO.Ansatz,
                            dauerAlt,
                            bdeLeistungDTO.Dauer));
                }
            }
            catch (Exception ex)
            {
                DlgProgressLog.AddError("Error: " + ex.Message);
                return false;
            }

            return true;
        }
    }
}