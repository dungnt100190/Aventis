using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.FAMOZ.PSCDServices;
using KiSS4.Gui;
using KiSS4.Messages;

namespace KiSS4.Klientenbuchhaltung.ZH
{
    public class BelegeKorrigierenHelper
    {
        private readonly Control _belegeKorrigierenControl;
        private readonly KissCheckEdit _edtAbgetreten;
        private readonly KissCalcEdit _edtBetrag;
        private readonly KissButtonEdit _edtBetrifftPerson;
        private readonly KissButtonEdit _edtBgKostenartID;
        private readonly KissButtonEdit _edtLeistungstraeger;
        private readonly KissTextEdit _edtTextVariabel;
        private readonly KissDateEdit _edtValutaDatum;
        private readonly KissDateEdit _edtVerwPeriodeBis;
        private readonly KissDateEdit _edtVerwPeriodeVon;
        private readonly Action _enableControls;
        private readonly SqlQuery _qryKbBuchungBrutto;
        private readonly SqlQuery _qryKbBuchungBruttoPerson;
        private readonly SqlQuery _qryKbBuchungBruttoSuche;
        private readonly bool _throwExceptionInPlaceOfMessage;
        private int _tempKbBuchungBruttoIDCounter = -10000;

        public BelegeKorrigierenHelper(
            Control belegeKorrigierenControl,
            SqlQuery qryKbBuchungBruttoSuche,
            SqlQuery qryKbBuchungBrutto,
            SqlQuery qryKbBuchungBruttoPerson,
            KissDateEdit edtValutaDatum,
            KissCalcEdit edtBetrag,
            KissCheckEdit edtAbgetreten,
            KissDateEdit edtVerwPeriodeVon,
            KissDateEdit edtVerwPeriodeBis,
            KissButtonEdit edtBgKostenartID,
            KissButtonEdit edtLeistungstraeger,
            KissButtonEdit edtBetrifftPerson,
            KissTextEdit edtTextVariabel,
            Action enableControls,
            bool throwExceptionInPlaceOfMessage)
        {
            BelegeKorrigierenTemporaryTableHelper.InitTemporaryKbBuchungBruttoPersonTable();
            _qryKbBuchungBruttoSuche = qryKbBuchungBruttoSuche;
            _qryKbBuchungBruttoPerson = qryKbBuchungBruttoPerson ?? GetQryKbBuchungBruttoPerson();
            _qryKbBuchungBrutto = qryKbBuchungBrutto ?? GetQryKbBuchungBrutto();

            _enableControls = enableControls ?? (() => { });
            _belegeKorrigierenControl = belegeKorrigierenControl;
            _edtTextVariabel = edtTextVariabel ?? new KissTextEdit { DataSource = qryKbBuchungBrutto, DataMember = "TextVariabel" };
            _edtBgKostenartID = edtBgKostenartID ?? new KissButtonEdit { DataSource = qryKbBuchungBrutto, DataMember = "BgKostenart" };
            _edtLeistungstraeger = edtLeistungstraeger ?? new KissButtonEdit { DataSource = qryKbBuchungBrutto, DataMember = "LT" };
            _edtBetrifftPerson = edtBetrifftPerson ?? new KissButtonEdit { DataSource = qryKbBuchungBrutto, DataMember = "BetrifftPerson" };
            _edtBetrag = edtBetrag ?? new KissCalcEdit { DataSource = qryKbBuchungBrutto, DataMember = "Betrag" };
            _edtAbgetreten = edtAbgetreten ?? new KissCheckEdit { DataSource = qryKbBuchungBrutto, DataMember = "Abgetreten" };
            _edtVerwPeriodeVon = edtVerwPeriodeVon ?? new KissDateEdit { DataSource = qryKbBuchungBrutto, DataMember = "VerwPeriodeVon" };
            _edtVerwPeriodeBis = edtVerwPeriodeBis ?? new KissDateEdit { DataSource = qryKbBuchungBrutto, DataMember = "VerwPeriodeBis" };
            _edtValutaDatum = edtValutaDatum ?? new KissDateEdit();
            _throwExceptionInPlaceOfMessage = throwExceptionInPlaceOfMessage;
        }

        public bool ChangingData
        {
            get;
            set;
        }

        public bool Inserting
        {
            get;
            set;
        }

        public bool IsBuchungBruttoEditable
        {
            get
            {
                var storno = _qryKbBuchungBrutto["Storno"] as bool? ?? false;
                return !storno && !IsBuchungBruttoReadonly;
            }
        }

        public bool IsBuchungBruttoReadonly
        {
            get
            {
                int status = (int)_qryKbBuchungBrutto["KbBuchungStatusCode"];
                if (status == 1 || status == 2 || status == 5) // Grau, Grün oder Fehlerhaft
                {
                    return false;
                }

                return true;
            }
        }

        // Liste mit KbBuchungBruttoIDs der Belege, die beim Laden schon Detailpositionen hatten, und bei denen RecreateDetailBuchungen() nicht aufgerufen wurde, d.h. die Detailpositionen noch dem ursprünglichen Beleg entsprechen und daher nicht neu angelegt werden müssen
        public List<int> KbBuchungBruttoIDsWithExistingDetailPositions
        {
            get;
            set;
        }

        public bool UpdateWasSuccessfull
        {
            get;
            set;
        }

        /// <summary>
        /// Falls Valuta oder Entscheid dann Bis=Von
        /// </summary>
        public static void CheckAndCorrectVerwendungsperiodGemSplittingArt(bool storno, int splittingArtCode, DateTime verwPeriodVon, ref DateTime verwPeriodBis)
        {
            if (!storno && splittingArtCode == 3 || splittingArtCode == 4) //3=Valuta, 4=Entscheid
            {
                verwPeriodBis = verwPeriodVon;
            }
        }

        /// <summary>
        /// Sucht und prüft die richtige Kombination zwischen bgFinanzplanID faLeistungID und bgFinanzplanID
        /// </summary>
        /// <returns><c>true</c> falls die Daten volständig sind und sonst <c>false</c></returns>
        public static bool CheckSetCombiFinanzplanFaLeistungHaushalt(bool quoting, object betrifftBaPersonID, object faFallID, object lTBaPersonID, ref object bgFinanzplanID, ref object faLeistungID, ref object selectedHaushaltProleistPersonenIDs, ref object selectedHaushaltdatumvon, ref object selectedHaushaltdatumbis, ref string messageinfo)
        {
            // Prüfe zuerst, ob die gequoteten entweder einen Finanzplan oder einen Haushalt selektiert haben
            if (quoting && (DBUtil.IsEmpty(bgFinanzplanID) || (int)bgFinanzplanID == 0) && DBUtil.IsEmpty(selectedHaushaltProleistPersonenIDs))
            {
                messageinfo = string.Format("Bitte wählen Sie einen gültigen Haushalt aus");
                return false;
            }

            // Falls dies ein gequoteter Beleg ist, muss ein Haushalt existieren oder ausgewählt worden sein
            if (quoting && ((!DBUtil.IsEmpty(bgFinanzplanID) && (int)bgFinanzplanID > 0) || !DBUtil.IsEmpty(selectedHaushaltProleistPersonenIDs)))
            {
                // Der Beleg ist gequotet, und entweder ist ein Finanzplan gesetzt, oder ein Proleist-Haushalt wurde selektiert, d.h. dieser Beleg ist OK
                return true;
            }

            // Ist Finanzplan bekannt?
            if (!DBUtil.IsEmpty(bgFinanzplanID))
            {
                // Ja, FP bekant
                if (DBUtil.IsEmpty(faLeistungID))
                {
                    // Aber Leistung nicht, d.h. wir holen uns die LeistungsID gleich vom FP ab
                    faLeistungID = DBUtil.ExecuteScalarSQL("SELECT TOP 1 FaLeistungID FROM BgFinanzplan WHERE BgFinanzplanID = {0}", bgFinanzplanID);
                }

                if (!quoting)
                {
                    // nicht gequotet => Prüfe, ob Person im FP unterstützt ist
                    object count = DBUtil.ExecuteScalarSQL(@"
                            SELECT TOP 1 1 FROM BgFinanzplan_BaPerson FPP
                            WHERE FPP.IstUnterstuetzt = 1 AND FPP.BaPersonID = {0} AND FPP.BgFinanzplanID = {1}",
                        betrifftBaPersonID,
                        bgFinanzplanID);

                    if (count == null || (int)count != 1)
                    {
                        // Person ist in dieser Leistung nicht unterstützt => Lösche die Leistung, so dass sie unten wieder korrekt gefüllt wird
                        faLeistungID = DBNull.Value;
                        bgFinanzplanID = DBNull.Value;
                    }
                }
            }

            if (!quoting)
            {
                // Nicht gequoteter Beleg
                if (DBUtil.IsEmpty(bgFinanzplanID))
                {
                    // Finanzplan noch nicht bekannt, suche weiter
                    if (!DBUtil.IsEmpty(faLeistungID))
                    {
                        // Leistung ist bekannt und Beleg ist nicht gequotet => Suche den neuesten FP mit der unterstützen Person in dieser Leistung
                        object fp = DBUtil.ExecuteScalarSQL(@"
                                SELECT TOP 1 FPL.BgFinanzplanID FROM FaLeistung LEI
                                    INNER JOIN BgFinanzplan FPL ON FPL.FaLeistungID = LEI.FaLeistungID
                                    INNER JOIN BgFinanzplan_BaPerson FPP ON FPP.BgFinanzplanID = FPL.BgFinanzplanID
                                WHERE LEI.FaProzessCode = 300 AND FPP.IstUnterstuetzt = 1
                                    AND FPP.BaPersonID = {0}
                                    AND LEI.FaLeistungID = {1}
                                ORDER BY FPL.GeplantVon DESC",
                            betrifftBaPersonID,
                            faLeistungID);

                        if (fp != null)
                        {
                            bgFinanzplanID = fp;
                        }
                    }
                }

                if (DBUtil.IsEmpty(bgFinanzplanID))
                {
                    // Finanzplan immer noch nicht bekannt, suche weiter

                    // Hole die neueste Leistung des Original-Falls, in der die Person unterstützt ist und mit dem richtigen LT
                    SqlQuery sql = DBUtil.OpenSQL(@"
                            SELECT TOP 1 LEI.FaLeistungID, FPL.BgFinanzplanID FROM FaLeistung LEI
                                INNER JOIN BgFinanzplan FPL ON FPL.FaLeistungID = LEI.FaLeistungID
                                INNER JOIN BgFinanzplan_BaPerson FPP ON FPP.BgFinanzplanID = FPL.BgFinanzplanID
                            WHERE LEI.FaProzessCode = 300 AND FPP.IstUnterstuetzt = 1
                                AND FPP.BaPersonID = {0}
                                AND LEI.FaFallID = {1}
                                AND LEI.BaPersonID = {2}
                            ORDER BY LEI.DatumVon DESC, FPL.GeplantVon DESC",
                        betrifftBaPersonID,
                        faFallID,
                        lTBaPersonID);
                    if (sql.Count == 1)
                    {
                        // Ok, Leistung/FP gefunden
                        faLeistungID = sql["FaLeistungID"];
                        bgFinanzplanID = sql["BgFinanzplanID"];
                    }
                }
            }

            if (DBUtil.IsEmpty(bgFinanzplanID))
            {
                // Finanzplan immer noch nicht bekannt, d.h. wir müssen einen Dummy-Finanzplan erstellen, und zwar in der ältesten Leistung mit dem richtigen LT

                // Hole die älteste Leistung des Original-Falls
                SqlQuery sql = DBUtil.OpenSQL(@"
                        SELECT TOP 1 LEI.FaLeistungID, LEI.DatumVon, LEI.DatumBis FROM FaLeistung LEI
                        WHERE LEI.FaProzessCode = 300 AND LEI.FaFallID = {0} AND LEI.BaPersonID = {1}
                        ORDER BY LEI.DatumVon",
                    faFallID,
                    lTBaPersonID);

                faLeistungID = sql["FaLeistungID"];

                if (!quoting)
                {
                    // Der Beleg ist nicht gequotet => Wir setzen SelectedHaushaltProleistPersonenIDs = BetrifftBaPersonID => Damit wird ein neuer Dummy-FP mit dieser Person erstellt werden in der Methode ProgressStart()
                    selectedHaushaltProleistPersonenIDs = betrifftBaPersonID;
                    selectedHaushaltdatumvon = sql["DatumVon"];
                    selectedHaushaltdatumbis = sql["DatumBis"];
                }
            }

            if (DBUtil.IsEmpty(faLeistungID))
            {
                // Hmm, scheint hartnäckig zu sein, wir haben keine Leistung gefunden
                if (quoting)
                {
                    messageinfo = "Keine gültige Leistung. Bitte wählen Sie einen gültigen Haushalt aus";
                }
                else
                {
                    messageinfo = string.Format("Keine gültige Leistung gefunden für BetrifftPerson {0}", betrifftBaPersonID);
                }

                return false;
            }

            //Leistung gefunden dann ok
            return true;
        }

        /// <summary>
        /// If not SiLei and splittingart=Monat --> Muss : verwVon.Month=1 und verwBis.Month=LastDayOftheMonth
        /// </summary>
        /// <returns><c>true</c> falls die Daten volständig sind und sonst <c>false</c></returns>
        public static bool CheckVerwendungsPeriodeGemSplittingArtMonat(bool isSiLei, int splittingart, DateTime verwPeriodeVon, DateTime verwPeriodeBis, ref string message)
        {
            if (!isSiLei)
            {
                if (splittingart == 2)
                {
                    if (verwPeriodeVon != new DateTime(verwPeriodeVon.Year, verwPeriodeVon.Month, 1))
                    {
                        message = "'Verwendungsperiode von' muss bei Monats-Splitting der erste eines Monats sein";
                        return false;
                    }

                    if (verwPeriodeBis != new DateTime(verwPeriodeBis.Year, verwPeriodeBis.Month, DateTime.DaysInMonth(verwPeriodeBis.Year, verwPeriodeBis.Month)))
                    {
                        message = "'Verwendungsperiode bis' muss bei Monats-Splitting der letzte eines Monats sein";
                        return false;
                    }
                }
            }

            return true;
        }

        public static SqlQuery GetQryKbBuchungBrutto()
        {
            var qryKbBuchungBrutto = new SqlQuery();
            qryKbBuchungBrutto.CanInsert = true;
            qryKbBuchungBrutto.CanUpdate = true;
            qryKbBuchungBrutto.CanDelete = true;
            qryKbBuchungBrutto.BatchUpdate = true;
            qryKbBuchungBrutto.SelectStatement = @"
                SELECT
                  KBU.KbBuchungBruttoID,
                  KBU.BgBudgetID,
                  KBU.BgKostenartID,
                  BKA.KontoNr,
                  BgKostenart = BKA.KontoNr + ' ' + BKA.Name,
                  KBU.BelegDatum,
                  KBU.Kostenstelle,
                  KBU.Hauptvorgang,
                  KBU.Teilvorgang,
                  BgKostenartHauptvorgang = BKA.Hauptvorgang,
                  BgKostenartTeilvorgang = BKA.Teilvorgang,
                  BgKostenartHauptvorgangAbtretung = BKA.HauptvorgangAbtretung,
                  BgKostenartTeilvorgangAbtretung = BKA.TeilvorgangAbtretung,
                  KBU.Belegart,
                  KBU.BgSplittingArtCode,
                  KBU.Weiterverrechenbar,
                  KBU.Quoting,
                  KBU.FaLeistungID,
                  KBU.ValutaDatum,
                  KBU.KbBuchungStatusCode,
                  KBU.Text,
                  KBU.Abgetreten,
                  KBU.TransferDatum,
                  BelegNr = CASE WHEN 0={1} THEN KBU.BelegNr END,
                  Betrag = KBU.Betrag,
                  KBP.Anzahl,
                  KBP.BaPersonID,
                  KBP.VerwPeriodeVon,
                  KBP.VerwPeriodeBis,
                  LT = PLT.NameVorname + ' (' + convert(varchar,PLT.BaPersonID) + ')',
                  LTBaPersonID = PLT.BaPersonID,
                  BetrifftPerson = BEP.NameVorname + ' (' + convert(varchar,BEP.BaPersonID) + ')',
                  BetrifftBaPersonID = BEP.BaPersonID,
                  Storno = CASE WHEN KBU.StorniertKbBuchungBruttoID IS NOT NULL THEN CAST(1 as bit) ELSE CAST(0 as bit) END,
                  Splittingart = SPL.ShortText,
                  BgSplittingartCode = BKA.BgSplittingartCode,
                  TextFix = '',
                  TextVariabel = KBU.Text,
                  LEI.FaFallID,
                  Budget = MON.ShortText + ' ' + CAST(BUD.Jahr as varchar),
                  BgFinanzplanID = BUD.BgFinanzplanID,
                  SelectedHaushaltDatumVon = GetDate(),
                  SelectedHaushaltDatumBis = GetDate(),
                  SelectedHaushaltProleistPersonenIDs = '',
                  KbBuchungBruttoID_Zuweisung = KBU.KbBuchungBruttoID, --wird für Zuweisung zwischen Vorschlag Detailbuchung gemäss DB und Neuwerten für Detailbuchung aus Massenumbuchungs-Maske verwendet
                  KbBuchungBruttoPersonID_Zuweisung = NULL --wird für Zuweisung zwischen Vorschlag Detailbuchung gemäss DB und Neuwerten für Detailbuchung aus Massenumbuchungs-Maske verwendet
                FROM KbBuchungBrutto                      KBU
                  LEFT  JOIN BgKostenart                  BKA ON BKA.BgKostenartID = KBU.BgKostenartID
                  LEFT  JOIN (SELECT KbBuchungBruttoID, Anzahl = Count(*), BaPersonID = MIN(BaPersonID), VerwPeriodeVon = MIN(VerwPeriodeVon), VerwPeriodeBis = MAX(VerwPeriodeBis)
                              FROM KbBuchungBruttoPerson
                              GROUP BY KbBuchungBruttoID) KBP ON KBP.KbBuchungBruttoID = KBU.KbBuchungBruttoID
                  LEFT  JOIN FaLeistung                   LEI ON LEI.FaLeistungID = KBU.FaLeistungID
                  LEFT  JOIN vwPerson                     PLT ON PLT.BaPersonID = LEI.BaPersonID
                  LEFT  JOIN vwPerson                     BEP ON KBU.Quoting = 0 AND BEP.BaPersonID = KBP.BaPersonID
                  LEFT  JOIN XLOVCode                     SPL ON SPL.LOVName = 'BgSplittingart' AND SPL.Code = BKA.BgSplittingartCode
                  LEFT  JOIN BgBudget                     BUD ON BUD.BgBudgetID = KBU.BgBudgetID
                  LEFT  JOIN XLOVCode                     MON ON MON.LOVName = 'Monat' AND MON.Code = BUD.Monat
                WHERE KBU.KbBuchungBruttoID = {0} AND 1={1}
                  OR 0={1} AND (KBU.StorniertKbBuchungBruttoID = {0} OR KBU.NeubuchungVonKbBuchungBruttoID = {0})";

            return qryKbBuchungBrutto;
        }

        public static SqlQuery GetQryKbBuchungBruttoPerson()
        {
            var qryKbBuchungBruttoPerson = new SqlQuery();
            qryKbBuchungBruttoPerson.CanInsert = true;
            qryKbBuchungBruttoPerson.CanUpdate = true;
            qryKbBuchungBruttoPerson.CanDelete = true;
            qryKbBuchungBruttoPerson.BatchUpdate = true;
            qryKbBuchungBruttoPerson.SelectStatement = @"
                SELECT
                  KbBuchungBruttoPersonID,
                  KbBuchungBruttoID = KBP.KbBuchungBruttoID,
                  Person = PER.Name + IsNull(', ' + PER.Vorname, '') + ' (' +
                                      ISNULL(CONVERT(varchar,dbo.fnGetAgeMortal(PER.Geburtsdatum, GetDate(),PER.Sterbedatum)),'-') + ',' +
                                      ISNULL(PER.GeschlechtKurz,'?') + ')',
                  BaPersonID = PER.BaPersonID,
                  Text = KBP.Buchungstext,
                  Betrag = KBP.Betrag,
                  VerwPeriodeVon = KBP.VerwPeriodeVon,
                  VerwPeriodeBis = KBP.VerwPeriodeBis
                FROM #TempKbBuchungBruttoPerson KBP
                  INNER  JOIN vwPerson PER ON PER.BaPersonID = KBP.BaPersonID
                WHERE  KBP.KbBuchungBruttoID = {0}";

            return qryKbBuchungBruttoPerson;
        }

        /// <summary>
        /// Öffnet KissLookupDialog mit Liste der BetriffPersonen von vwPerson.
        /// <param name="isTargetBelegeKorrigiere">Query abhängig der Maske</param>
        /// </summary>
        /// <returns><c>true</c> falls Dialog mit Erfolg geänderten Daten zurückliefert <c>false</c></returns>
        public static bool ShowBetrifftPersonDialog(bool isSiLei, object lTBaPersonID, string searchString, bool openDialog, bool isTargetBelegeKorrigiere, ref object betrifftPerson, ref object betrifftBaPersonID)
        {
            var dlg = new KissLookupDialog();
            bool dialogRes;

            if (isSiLei)
            {
                if (isTargetBelegeKorrigiere)
                {
                    dialogRes = dlg.SearchData(@"
                        SELECT DISTINCT
                          ID = PRS.BaPersonID,
                          PRS.Name,
                          PRS.Vorname,
                          BaPersonID$ = PRS.BaPersonID,
                          NameVorname$ = PRS.NameVorname + ' (' + CONVERT(VARCHAR, PRS.BaPersonID) + ')'
                        FROM dbo.vwPerson PRS
                        WHERE (PRS.NameVorname LIKE '%' + {0} + '%' OR CAST(PRS.BaPersonID AS VARCHAR) = {0})",
                        searchString,
                        openDialog);

                    if (dialogRes)
                    {
                        betrifftPerson = dlg["NameVorname$"];
                        betrifftBaPersonID = dlg["BaPersonID$"];
                    }
                }
                else
                {
                    dialogRes = dlg.SearchData(@"
                        SELECT DISTINCT
                          ID = PRS.BaPersonID,
                          PRS.Name,
                          PRS.Vorname,
                          BaPersonID$ = PRS.BaPersonID,
                          DisplayText$ = PRS.DisplayText
                        FROM dbo.vwPerson2 PRS
                        WHERE (PRS.DisplayText LIKE '%' + {0} + '%' OR CAST(PRS.BaPersonID AS VARCHAR) = {0})",
                        searchString,
                        openDialog);

                    if (dialogRes)
                    {
                        betrifftPerson = dlg["DisplayText$"];
                        betrifftBaPersonID = dlg["BaPersonID$"];
                    }
                }
            }
            else
            {
                if (isTargetBelegeKorrigiere)
                {
                    dialogRes = dlg.SearchData(@"
                        SELECT DISTINCT
                          ID = PRS.BaPersonID,
                          PRS.Name,
                          PRS.Vorname,
                          BaPersonID$ = PRS.BaPersonID,
                          NameVorname$ = PRS.NameVorname + ' (' + CONVERT(VARCHAR, PRS.BaPersonID) + ')'
                        FROM dbo.vwPerson                      PRS
                          INNER JOIN dbo.BgFinanzplan_BaPerson FPP ON FPP.BaPersonID = PRS.BaPersonID
                          INNER JOIN dbo.BgFinanzplan          FPL ON FPL.BgFinanzplanID = FPP.BgFinanzplanID
                          INNER JOIN dbo.FaLeistung            LEI ON LEI.FaLeistungID = FPL.FaLeistungID
                        WHERE 1=1
                        AND LEI.FaProzessCode = 300
                        AND IstUnterstuetzt = 1
                        AND LEI.BaPersonID = {1}
                        ORDER BY PRS.Name, PRS.Vorname",
                        "",  //Suche für den Haushalt nicht nötig
                        openDialog,
                        lTBaPersonID);

                    if (dialogRes)
                    {
                        betrifftPerson = dlg["NameVorname$"];
                        betrifftBaPersonID = dlg["BaPersonID$"];
                    }
                }
                else
                {
                    dialogRes = dlg.SearchData(@"
                        SELECT DISTINCT
                          ID = PRS.BaPersonID,
                          PRS.Name,
                          PRS.Vorname,
                          BaPersonID$ = PRS.BaPersonID,
                          DisplayText$ = PRS.DisplayText
                        FROM dbo.vwPerson2                     PRS
                          INNER JOIN dbo.BgFinanzplan_BaPerson FPP ON FPP.BaPersonID = PRS.BaPersonID
                          INNER JOIN dbo.BgFinanzplan          FPL ON FPL.BgFinanzplanID = FPP.BgFinanzplanID
                          INNER JOIN dbo.FaLeistung            LEI ON LEI.FaLeistungID = FPL.FaLeistungID
                        WHERE 1=1
                        AND LEI.FaProzessCode = 300
                        AND IstUnterstuetzt = 1
                        AND LEI.BaPersonID = {1}
                        ORDER BY PRS.DisplayText",
                        "", //Suche für den Haushalt nicht nötig
                        openDialog,
                        lTBaPersonID);

                    if (dialogRes)
                    {
                        betrifftPerson = dlg["DisplayText$"];
                        betrifftBaPersonID = dlg["BaPersonID$"];
                    }
                }
            }

            return dialogRes;
        }

        public static DataRow ShowHaushaltDialog(int faFallId, int? ltBaPersonId, int? bgFinanzplanId)
        {
            using (var dlgHaushalt = new KissLookupDialog("Selektieren Sie einen Haushalt des gewählten LT", "OrigHH = 1"))
            {
                var cancel = !dlgHaushalt.SearchData(@"
                    DECLARE @Haushalte TABLE
                    (
                      OrigHH bit,
                      FaLeistungID int,
                      FaFallID int,
                      DatVonKiSS datetime NULL,
                      DatBisKiSS datetime NULL,
                      DatVonProLei datetime NULL,
                      DatBisProLei datetime NULL,
                      AnzPers int,
                      PersonenIDs$ varchar(200),
                      Personen varchar(1000),
                      Bemerkung varchar(100),
                      BgFinanzplanID$ int,
                      EntsprichtProleistHaushalt$ bit,
                      HHVomLT$ bit         -- Haushalt einer Leistung des Leistungsträgers
                    )

                    -- Suche alle KiSS-Haushalte des Leistungsträgers (Gruppiert nach Personenzusammensetzung, Finanzpläne mit gleicher Zusammensetzung werden zusammengezogen in einen Eintrag)
                    INSERT INTO @Haushalte
                      SELECT
                        Max(OH),
                        Max(FaLeistungID),
                        Max(FaFallID),
                        Min(DatVonKiSS),
                        Max(DatBisKiSS),
                        NULL,
                        NULL,
                        AnzPers,
                        PersonenIDs$,
                        Personen,
                        T,
                        Max(BgFinanzplanID),
                        Max(EntsprichtProleistHaushalt),
                        HHVomLT$ = MAX(T.HHVomLT$)          -- Falls der HH mind. einmal für den LT vorkommt, dann wollen wir ihn behalten
                      FROM (
                        SELECT
                          OH = CASE WHEN FIP.BgFinanzplanID = {3} THEN 1 ELSE 0 END,
                          LEI.FaLeistungID,
                          LEI.FaFallID,
                          DatVonKiSS=FIP.DatumVon,
                          DatBisKiSS=FIP.DatumBis,
                          AnzPers=Count(PER.BaPersonID),
                          PersonenIDs$=dbo.ConcDistinctOrder(PER.BaPersonID),
                          Personen=dbo.Conc(PER.DisplayText),
                          T = 'KiSS-Haushalt',
                          FIP.BgFinanzplanID,
                          EntsprichtProleistHaushalt = 0,   -- Dies ist ein KiSS-Haushalt, kein Proleist-Haushalt,
                          HHVomLT$ = CASE WHEN LEI.BaPersonID = {2} THEN 1 ELSE 0 END
                        FROM FaLeistung LEI
                          INNER JOIN BgFinanzplan FIP ON FIP.FaLeistungID = LEI.FaLeistungID
                          INNER JOIN BgFinanzplan_BaPerson FPP ON FPP.BgFinanzplanID = FIP.BgFinanzplanID AND FPP.IstUnterstuetzt = 1
                          INNER JOIN vwPerson PER ON PER.BaPersonID = FPP.BaPersonID
                        WHERE LEI.FaFallID = {1}
                        GROUP BY LEI.FaFallID, LEI.FaLeistungID, FIP.DatumVon, FIP.DatumBis, FIP.BgFinanzplanID, CASE WHEN LEI.BaPersonID = {2} THEN 1 ELSE 0 END
                        ) T
                      GROUP BY AnzPers, PersonenIDs$, Personen, T

                    -- Füge alle Proleist-Haushalte dazu
                    INSERT INTO @Haushalte
                      SELECT
                        OrigHH = 0, -- Dies ist nicht der Originalhaushalt (der kommt ja von einer Neudaten-Umbuchung)
                        FaLeistungID=T2.FaLeistungID,
                        FaFallID=T2.FaFallID,
                        Null,
                        Null,
                        DatVonProLei=Min(T2.DatVonProLei),
                        DatBisProLei=Max(T2.DatBisProLei),
                        AnzPers=T2.AnzPers,
                        PersonenIDs$=T2.PersonenIDs$,
                        Personen=Max(T2.Personen),
                        'Proleist-Haushalt',
                        0,
                        1,   -- Dies ist ein Proleist-Haushalt
                        HHVomLT$ = 1        -- Wir wollen alle Proleist-Haushalte für den LT anzeigen
                      FROM(SELECT DISTINCT
                               FaLeistungID=T.FaLeistungID,
                               FaFallID=T.FaFallID,
                               DatVonProLei=Min(T.DatVonProLei),
                               DatBisProLei=Max(T.DatBisProLei),
                               AnzPers=Count(T.BaPersonID),
                               PersonenIDs$=dbo.ConcDistinctOrder(T.BaPersonID),
                               Personen=dbo.Conc(T.Person)
                           FROM (SELECT DISTINCT
                                   LEI.FaLeistungID,
                                   LEI.FaFallID,
                                   DatVonProLei=Min(MIG.VerwendungVon),
                                   DatBisProLei=Max(MIG.VerwendungBis),
                                   BaPersonID=PER.BaPersonID,
                                   Person=PER.DisplayText,
                                   Beleg = MIG.NummernKreis + '-' + convert(varchar(20),MIG.BelegNummer),
                                   Quoting = CASE WHEN ISNULL(BKA.Quoting,0) = 0 THEN MIG.BaPersonID ELSE 0 END,
                                   LA = CASE WHEN MIG.LeistungsArtNrProLeist BETWEEN 9000 AND 9999 THEN 'V' ELSE '' END + MIG.KissLeistungsart
                                 FROM MigDetailBuchung MIG
                                   INNER JOIN dbo.vwPerson PER ON PER.BaPersonID = MIG.BaPersonID
                                   INNER JOIN dbo.FaLeistung LEI ON LEI.FaLeistungID = MIG.FaLeistungID
                                   LEFT  JOIN dbo.BgKostenart BKA (READUNCOMMITTED)ON BKA.KontoNr = MIG.KissLeistungsart
                                 WHERE LEI.FaFallID = {1}
                                   AND IsNull(BKA.Quoting, 0) <> 0
                                 GROUP BY LEI.FaLeistungID, LEI.FaFallID, PER.BaPersonID, PER.DisplayText,
                                          MIG.NummernKreis + '-' + convert(varchar(20),MIG.BelegNummer),
                                          CASE WHEN ISNULL(BKA.Quoting,0) = 0 THEN MIG.BaPersonID ELSE 0 END,
                                          CASE WHEN MIG.LeistungsArtNrProLeist BETWEEN 9000 AND 9999 THEN 'V' ELSE '' END + MIG.KissLeistungsart
                                ) T
                           GROUP BY T.FaFallID, T.FaLeistungID, T.Beleg, T.Quoting, T.LA
                          ) T2
                      GROUP BY T2.FaFallID, T2.FaLeistungID, T2.AnzPers, T2.PersonenIDs$

                    -- Prüfe, ob einer der KiSS-Haushalte die gleiche Personenkonstellation wir der Proleist-Haushalt hat, und wenn ja, markiere Ihn als 'EntsprichtProleistHaushalt'
                    UPDATE H
                      SET DatVonProLei = HTemp.DatVonProLei,
                          DatBisProLei = HTemp.DatBisProLei,
                          EntsprichtProleistHaushalt$ = 1,
                          Bemerkung='Proleist-Haushalt, im KiSS nacherfasst',
                          OrigHH = CASE WHEN H.OrigHH = 1 OR HTemp.OrigHH = 1 THEN 1 ELSE 0 END,
                          HHVomLT$ = 1        -- Nacherfasste Proleist-Haushalte wollen wir auf jeden Fall anzeigen
                    FROM @Haushalte H
                      INNER JOIN (SELECT DISTINCT PersonenIDs$, OrigHH, DatVonProLei, DatBisProLei FROM @Haushalte  WHERE BgFinanzplanID$ = 0) HTemp ON HTemp.PersonenIDs$ = H.PersonenIDs$
                    WHERE H.BgFinanzplanID$ > 0

                    -- Lösche den Proleist-Haushalt wieder, falls die gleiche Personenkonstellation schon in den echten KiSS-Haushalten vorkommt (Proleist-Haushalte haben keine BgFinanzplanID)
                    DELETE FROM @Haushalte
                    WHERE BgFinanzplanID$ = 0 AND PersonenIDs$ IN (SELECT DISTINCT PersonenIDs$ FROM @Haushalte WHERE BgFinanzplanID$ <> 0)

                    -- Lösche alle Haushalte, die nicht für den LT markiert sind
                    DELETE FROM @Haushalte WHERE HHVomLT$ = 0

                    -- Gib alle gefundenen Haushalte zurück
                    SELECT * FROM @Haushalte ORDER BY IsNull(DatVonKiSS, DatVonProLei) DESC",
                    "",
                    true,
                    faFallId,
                    ltBaPersonId,
                    bgFinanzplanId);

                return cancel ? null : dlgHaushalt.ResultRow;
            }
        }

        public void Abtretung_ValueChanged()
        {
            _qryKbBuchungBrutto["Abgetreten"] = _edtAbgetreten.EditValue as bool? ?? false;

            if (_qryKbBuchungBrutto["Abgetreten"] as bool? ?? false)
            {
                _qryKbBuchungBrutto["Hauptvorgang"] = _qryKbBuchungBrutto["BgKostenartHauptvorgangAbtretung"];
                _qryKbBuchungBrutto["Teilvorgang"] = _qryKbBuchungBrutto["BgKostenartTeilvorgangAbtretung"];
            }
            else
            {
                _qryKbBuchungBrutto["Hauptvorgang"] = _qryKbBuchungBrutto["BgKostenartHauptvorgang"];
                _qryKbBuchungBrutto["Teilvorgang"] = _qryKbBuchungBrutto["BgKostenartTeilvorgang"];
            }

            RecreateDetailBuchungen(true);
        }

        public void BetrifftPersonUserModifiedField(UserModifiedFldEventArgs e, bool isSiLei)
        {
            string searchString = _edtBetrifftPerson.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    _edtBetrifftPerson.EditValue = DBNull.Value;
                    _edtBetrifftPerson.LookupID = DBNull.Value;
                    return;
                }
            }

            object betrifftPerson = _qryKbBuchungBrutto["BetrifftPerson"];
            object betrifftBaPersonID = _qryKbBuchungBrutto["BetrifftBaPersonID"];

            e.Cancel = !ShowBetrifftPersonDialog(
                    isSiLei,
                    _qryKbBuchungBrutto["LTBaPersonID"],
                    searchString,
                    e.ButtonClicked,
                    true,
                    ref betrifftPerson,
                    ref betrifftBaPersonID);

            if (!e.Cancel)
            {
                _qryKbBuchungBrutto["BetrifftPerson"] = betrifftPerson;
                _qryKbBuchungBrutto["BetrifftBaPersonID"] = betrifftBaPersonID;

                RecreateDetailBuchungen(true);
            }
        }

        public bool CheckAndSaveUmbuchungBuchung()
        {
            if (_qryKbBuchungBruttoSuche.Count == 0 || _qryKbBuchungBrutto.Row == null)
            {
                return true;
            }

            try
            {
                CheckBetrag();
                CheckTextVariabel();
                CheckVerwPeriodeVon();
                CheckVerwPeriodeBis();

                _qryKbBuchungBrutto.EndCurrentEdit();
                if (!CheckRow())
                {
                    return false;
                }
            }
            catch (KissCancelException ex)
            {
                if (_throwExceptionInPlaceOfMessage)
                {
                    throw;
                }
                ex.ShowMessage();
                return false;
            }

            _qryKbBuchungBrutto.DataTable.AcceptChanges();

            return true;
        }

        public void CheckBetrag()
        {
            if (_edtBetrag.EditMode != EditModeType.ReadOnly
                && !DBUtil.IsEmpty(_edtBetrag.EditValue)
                && (DBUtil.IsEmpty(_qryKbBuchungBrutto["Betrag"]) || (decimal)_edtBetrag.EditValue != (decimal)_qryKbBuchungBrutto["Betrag"]))
            {
                // Das Feld ist editierbar, und der Betrag wurde verändert
                _qryKbBuchungBrutto["Betrag"] = _edtBetrag.EditValue;
                RecreateDetailBuchungen(true);
            }
        }

        public bool CheckRow()
        {
            if (Inserting)
            {
                return true;
            }

            bool storno = (bool)_qryKbBuchungBrutto["Storno"];
            bool isSiLei = _qryKbBuchungBruttoSuche["PscdKennzeichen"] as string == "S";
            if (storno || _qryKbBuchungBrutto.Count == 0)
            {
                return true;
            }

            DBUtil.CheckNotNullField(_edtVerwPeriodeVon, "Verwendungsperiode von");
            DBUtil.CheckNotNullField(_edtVerwPeriodeBis, "Verwendungsperiode bis");
            DBUtil.CheckNotNullField(_edtBetrag, "Betrag");
            DBUtil.CheckNotNullField(_edtAbgetreten, "Abgetreten");
            if (DBUtil.IsEmpty(_qryKbBuchungBrutto["Hauptvorgang"]) || DBUtil.IsEmpty(_qryKbBuchungBrutto["Teilvorgang"]))
            {
                throw new KissInfoException(string.Format(
                    "Neu-Beleg: Es wurden keine Haupt/Teilvorgänge für die Leistungsart {0} gefunden. Bitte wählen Sie eine neue Leistungsart aus.",
                    _qryKbBuchungBrutto["BgKostenart"]));
            }

            DBUtil.CheckNotNullField(_edtValutaDatum, "Valuta");
            DBUtil.CheckNotNullField(_edtBgKostenartID, "Kostenart");
            if (!isSiLei)
            {
                DBUtil.CheckNotNullField(_edtLeistungstraeger, "Leistungsträger");
            }

            if (!(bool)_qryKbBuchungBrutto["Quoting"])
            {
                DBUtil.CheckNotNullField(_edtBetrifftPerson, "Betrifft Person");
            }

            if (_edtValutaDatum.DateTime > DateTime.Today)
            {
                throw new KissInfoException("Das Valutadatum darf nicht in der Zukunft liegen");
            }

            var vpVon = (DateTime)_qryKbBuchungBrutto["VerwPeriodeVon"];
            var vpBis = (DateTime)_qryKbBuchungBrutto["VerwPeriodeBis"];
            if (vpVon > vpBis)
            {
                throw new KissInfoException("'Verwendungsperiode von' muss vor 'Verwendungsperiode bis' liegen");
            }

            if (!DBUtil.IsEmpty(_qryKbBuchungBrutto["BgSplittingArtCode"]))
            {
                int splittingart = (int)_qryKbBuchungBrutto["BgSplittingArtCode"];
                string message = string.Empty;

                //CheckVerwendungsPeriode für SplittingArt=Monat
                bool rescheck = CheckVerwendungsPeriodeGemSplittingArtMonat(
                    isSiLei,
                    splittingart,
                    vpVon,
                    vpBis,
                    ref message);

                if (!rescheck)
                {
                    throw new KissInfoException(message);
                }
            }

            // Prüfe die Detailpositionen: Betrag und Text muss definiert sein für jeden Detailbeleg, Prüfe Summe der Beträge
            decimal totalKopf = (decimal.Parse(_qryKbBuchungBrutto["Betrag"].ToString()));
            decimal totalDetails = 0;

            foreach (DataRow row in _qryKbBuchungBruttoPerson.DataTable.Rows)
            {
                if (DBUtil.IsEmpty(row["Betrag"]))
                {
                    throw new KissInfoException("'Betrag' einer Detailposition darf nicht leer sein.");
                }

                if (DBUtil.IsEmpty(row["Text"]))
                {
                    throw new KissInfoException("'Buchungstext' einer Detailposition darf nicht leer sein.");
                }

                totalDetails += (decimal.Parse(row["Betrag"].ToString()));
            }

            if (Math.Truncate(totalKopf * 100) != Math.Truncate(totalDetails * 100))
            {
                // Die Detailbeträge sind falsch => Baue die Detailbuchungen nochmals auf
                if (!RecreateDetailBuchungen(true))
                {
                    return false;
                }
            }

            return true;
        }

        public void CheckTextVariabel()
        {
            if (_edtTextVariabel.EditMode != EditModeType.ReadOnly && !DBUtil.IsEmpty(_edtTextVariabel.EditValue) && _edtTextVariabel.EditValue != _qryKbBuchungBrutto["TextVariabel"])
            {
                // Das Feld ist editierbar, und es wurde verändert
                _qryKbBuchungBrutto["TextVariabel"] = _edtTextVariabel.Text;
                _qryKbBuchungBrutto["Text"] = string.Format("{0} {1}", _qryKbBuchungBrutto["TextFix"], _edtTextVariabel.Text);

                if (!DBUtil.IsEmpty(_qryKbBuchungBrutto["KbBuchungBruttoID"]))
                {
                    int id = (int)_qryKbBuchungBrutto["KbBuchungBruttoID"];

                    // Entferne die ID aus der Liste, da nun die Detailpositionen neu aufgebaut werden
                    if (KbBuchungBruttoIDsWithExistingDetailPositions.Contains(id))
                    {
                        KbBuchungBruttoIDsWithExistingDetailPositions.Remove(id);
                    }

                    BelegeKorrigierenTemporaryTableHelper.UpdateBuchungstextOfTemporaryKbBuchungBruttoPersonTable(id, (string)_qryKbBuchungBrutto["Text"]);
                    _qryKbBuchungBruttoPerson.Refresh();
                }
            }
        }

        public void CheckVerwPeriodeBis()
        {
            if (_edtVerwPeriodeBis.EditMode != EditModeType.ReadOnly
                && !DBUtil.IsEmpty(_edtVerwPeriodeBis.EditValue)
                && (DBUtil.IsEmpty(_qryKbBuchungBrutto["VerwPeriodeBis"]) // DB-Feld ist nicht gesetzt
                    || (DateTime)_edtVerwPeriodeBis.EditValue != (DateTime)_qryKbBuchungBrutto["VerwPeriodeBis"])) // Oder DB-Feld und UI-Control sind unterschiedlich
            {
                // Das Feld ist editierbar, und es wurde verändert
                UpdateVerwPeriodeOfDetailPositionen();
            }
        }

        public void CheckVerwPeriodeVon()
        {
            if (_edtVerwPeriodeVon.EditMode != EditModeType.ReadOnly
                && !DBUtil.IsEmpty(_edtVerwPeriodeVon.EditValue)
                && (DBUtil.IsEmpty(_qryKbBuchungBrutto["VerwPeriodeVon"]) // DB-Feld ist nicht gesetzt
                    || (DateTime)_edtVerwPeriodeVon.EditValue != (DateTime)_qryKbBuchungBrutto["VerwPeriodeVon"])) // Oder DB-Feld und UI-Control sind unterschiedlich
            {
                // Das Feld ist editierbar, und es wurde verändert
                if (!DBUtil.IsEmpty(_qryKbBuchungBrutto["BgSplittingartCode"]))
                {
                    //verwVon und verwBis gem. SplittingArt prüfen und korrigieren
                    int splittingArtCode = (int)_qryKbBuchungBrutto["BgSplittingartCode"];
                    bool storno = (bool)_qryKbBuchungBrutto["Storno"];

                    DateTime verwVon = _edtVerwPeriodeVon.DateTime;
                    DateTime verwBis = _edtVerwPeriodeBis.DateTime;

                    CheckAndCorrectVerwendungsperiodGemSplittingArt(
                                                        storno,
                                                        splittingArtCode,
                                                        verwVon,
                                                        ref verwBis);

                    _edtVerwPeriodeBis.DateTime = verwBis;
                }

                UpdateVerwPeriodeOfDetailPositionen();
            }
        }

        public void EnableHaushaltButton(KissButton btnHaushalt)
        {
            // Der Haushalt kann definiert werden, wenn der Beleg editierbar ist (als Probe prüfe das Textfeld) und das quoting enabled und gesetzt ist
            btnHaushalt.Enabled = (IsBuchungBruttoEditable) && !DBUtil.IsEmpty(_qryKbBuchungBrutto["Quoting"]) && (bool)_qryKbBuchungBrutto["Quoting"];
        }

        public void KostenartUserModifiedField(UserModifiedFldEventArgs e, KissButton btnHaushalt, bool updateSplittingArt)
        {
            string searchString = _edtBgKostenartID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    _edtBgKostenartID.EditValue = DBNull.Value;
                    _edtBgKostenartID.LookupID = DBNull.Value;
                    return;
                }
            }

            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                SELECT KontoNr, Name,
                  BgKostenartID$      = BgKostenartID,
                  KontoNrName$        = KontoNr + ' ' + Name,
                  Hauptvorgang$       = Hauptvorgang,
                  Teilvorgang$        = Teilvorgang,
                  HauptvorgangAbgetreten$       = HauptvorgangAbtretung,
                  TeilvorgangAbgetreten$        = TeilvorgangAbtretung,
                  Belegart$           = Belegart,
                  BgSplittingArtCode$ = BgSplittingArtCode,
                  SplittingArt$       = SPL.ShortText,
                  Weiterverrechenbar$ = Weiterverrechenbar,
                  Quoting             = Quoting
                FROM dbo.BgKostenart     BKA
                  LEFT JOIN dbo.XLOVCode SPL ON SPL.LOVName = 'BgSplittingart' AND SPL.Code = BKA.BgSplittingartCode
                WHERE ModulID = 3
                  AND ((Hauptvorgang IS NOT NULL AND Teilvorgang IS NOT NULL) OR (HauptvorgangAbtretung IS NOT NULL AND TeilvorgangAbtretung IS NOT NULL))
                  AND (KontoNr LIKE '%' + {0} + '%'
                    OR Name LIKE '%' + {0} + '%'
                    OR KontoNr + ' ' + Name LIKE '%' + {0} + '%')
                ORDER BY 1, 2",
                searchString,
                e.ButtonClicked);

            if (!e.Cancel)
            {
                _qryKbBuchungBrutto["BgKostenartID"] = dlg["BgKostenartID$"];
                _qryKbBuchungBrutto["KontoNr"] = dlg["KontoNr"];
                _qryKbBuchungBrutto["BgKostenart"] = dlg["KontoNrName$"];
                if (_qryKbBuchungBrutto["Abgetreten"] as bool? ?? false)
                {
                    _qryKbBuchungBrutto["Hauptvorgang"] = dlg["HauptvorgangAbgetreten$"];
                    _qryKbBuchungBrutto["Teilvorgang"] = dlg["TeilvorgangAbgetreten$"];
                }
                else
                {
                    _qryKbBuchungBrutto["Hauptvorgang"] = dlg["Hauptvorgang$"];
                    _qryKbBuchungBrutto["Teilvorgang"] = dlg["Teilvorgang$"];
                }

                _qryKbBuchungBrutto["BgKostenartHauptvorgang"] = dlg["Hauptvorgang$"];
                _qryKbBuchungBrutto["BgKostenartTeilvorgang"] = dlg["Teilvorgang$"];
                _qryKbBuchungBrutto["BgKostenartHauptvorgangAbtretung"] = dlg["HauptvorgangAbgetreten$"];
                _qryKbBuchungBrutto["BgKostenartTeilvorgangAbtretung"] = dlg["TeilvorgangAbgetreten$"];
                _qryKbBuchungBrutto["Belegart"] = dlg["Belegart$"];
                _qryKbBuchungBrutto["BgSplittingArtCode"] = dlg["BgSplittingArtCode$"];
                _qryKbBuchungBrutto["Weiterverrechenbar"] = dlg["Weiterverrechenbar$"];
                _qryKbBuchungBrutto["Quoting"] = dlg["Quoting"];
                _qryKbBuchungBrutto["SplittingArt"] = dlg["SplittingArt$"];

                if (updateSplittingArt)
                {
                    SetSplittingArt(dlg["BgSplittingArtCode$"]);
                }

                if ((bool)dlg["Quoting"])
                {
                    _edtBetrifftPerson.EditMode = EditModeType.ReadOnly;
                    _qryKbBuchungBrutto["BetrifftBaPersonID"] = DBNull.Value;
                    _qryKbBuchungBrutto["BetrifftPerson"] = DBNull.Value;

                    // Stelle sicher, dass der Haushalt nochmals gewählt wird
                    _qryKbBuchungBrutto["BgFinanzplanID"] = DBNull.Value;
                    _qryKbBuchungBrutto["SelectedHaushaltProleistPersonenIDs"] = DBNull.Value;
                    _qryKbBuchungBrutto["SelectedHaushaltDatumVon"] = DBNull.Value;
                    _qryKbBuchungBrutto["SelectedHaushaltDatumBis"] = DBNull.Value;
                }
                else
                {
                    _edtBetrifftPerson.EditMode = EditModeType.Normal;
                }

                RecreateDetailBuchungen(true);

                EnableHaushaltButton(btnHaushalt);
            }
        }

        public void LeistungstraegerUserModifiedField(UserModifiedFldEventArgs e)
        {
            string searchString = _edtLeistungstraeger.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    _edtLeistungstraeger.EditValue = DBNull.Value;
                    _edtLeistungstraeger.LookupID = DBNull.Value;
                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();

            if (searchString == "." && !DBUtil.IsEmpty(_qryKbBuchungBrutto["FaFallID"]))
            {
                e.Cancel = !dlg.SearchData(@"
                    SELECT DISTINCT
                      ID = PRS.BaPersonID,
                      PRS.Name,
                      PRS.Vorname,
                      LeistungID = LEI.FaLeistungID,
                      DatumVon = LEI.DatumVon,
                      DatumBis = LEI.DatumBis,
                      BaPersonID$ = PRS.BaPersonID,
                      NameVorname$ = PRS.NameVorname + ' (' + CONVERT(VARCHAR, PRS.BaPersonID) + ')'
                    FROM dbo.FaLeistung       LEI
                      INNER JOIN dbo.vwPerson PRS ON PRS.BaPersonID = LEI.BaPersonID
                    WHERE LEI.FaFallID = {1} AND LEI.FaProzessCode = 300    -- 300=W-Leistungen
                    ORDER BY PRS.Name, PRS.Vorname",
                    searchString,
                    e.ButtonClicked,
                    _qryKbBuchungBrutto["FaFallID"]);

                if (e.Cancel)
                {
                    return;
                }

                _qryKbBuchungBrutto["BgBudgetID"] = _qryKbBuchungBruttoSuche["BgBudgetID"];
                _qryKbBuchungBrutto["Kostenstelle"] = _qryKbBuchungBruttoSuche["Kostenstelle"];
                _qryKbBuchungBrutto["FaLeistungID"] = dlg["LeistungID"];
                _qryKbBuchungBrutto["FaFallID"] = _qryKbBuchungBruttoSuche["FaFallID"];
            }
            else
            {
                // Irgendeinen LT auswählen
                e.Cancel = !dlg.SearchData(@"
                    SELECT DISTINCT
                        ID = PRS.BaPersonID,
                        PRS.Name,
                        PRS.Vorname,
                        LeistungID = LEI.FaLeistungID,
                        DatumVon = LEI.DatumVon,
                        DatumBis = LEI.DatumBis,
                        BaPersonID$ = PRS.BaPersonID,
                        NameVorname$ = PRS.NameVorname + ' (' + CONVERT(VARCHAR, PRS.BaPersonID) + ')',
                        FaFallID$ = LEI.FaFallID
                    FROM dbo.FaLeistung             LEI
                        INNER JOIN dbo.vwPerson     PRS ON PRS.BaPersonID = LEI.BaPersonID
                        INNER JOIN dbo.BgFinanzplan FIP ON FIP.FaLeistungID = LEI.FaLeistungID
                    WHERE (PRS.NameVorname LIKE '%' + {0} + '%' OR CAST(PRS.BaPersonID AS VARCHAR) = {0})
                        AND LEI.FaProzessCode = 300
                    ORDER BY PRS.Name, PRS.Vorname",
                    searchString,
                    e.ButtonClicked);

                if (e.Cancel)
                {
                    return;
                }

                _qryKbBuchungBrutto["FaLeistungID"] = dlg["LeistungID"];
                _qryKbBuchungBrutto["FaFallID"] = dlg["FaFallID$"];
                _qryKbBuchungBrutto["BetrifftPerson"] = DBNull.Value;
                _qryKbBuchungBrutto["BetrifftBaPersonID"] = DBNull.Value;
            }

            _qryKbBuchungBrutto["LTBaPersonID"] = dlg["BaPersonID$"];
            _qryKbBuchungBrutto["LT"] = dlg["NameVorname$"];

            if ((bool)_qryKbBuchungBrutto["Quoting"])
            {
                SelectHaushalt();
            }

            RecreateDetailBuchungen(true);
        }

        public bool OnAddData()
        {
            // Solange noch mind. eine der Buchungen grau, grün oder fehlerhaft ist, kann noch eine weitere NEU-Buchung zugefügt werden
            bool addAllowed = true;

            foreach (DataRow row in _qryKbBuchungBrutto.DataTable.Rows)
            {
                int status = (int)row["KbBuchungStatusCode"];

                if (status != 1 && status != 2 && status != 5) // Ist nicht grau, grün oder fehlerhaft
                {
                    addAllowed = false;
                    break;
                }
            }

            if (!addAllowed)
            {
                KissMsg.ShowInfo("Es können keine Neubuchungen mehr erfasst werden, da die NEU-Belege bereits verarbeitet sind");
                return false;
            }

            if (!DBUtil.IsEmpty(_qryKbBuchungBruttoSuche["PscdKennzeichen", DataRowVersion.Original]) && (string)_qryKbBuchungBruttoSuche["PscdKennzeichen", DataRowVersion.Original] == "S")
            {
                // Die Originalbuchung ist eine SiLei-Buchung, bei welcher die LA/HV/TV auf den Detailpositionen definiert sind => Problematisch für die Umbuchung
                if (!KissMsg.ShowQuestion("Der ausgewählte Originalbeleg ist ein SiLei-Beleg, bei dem die LA und HV/TV auf den Detailpositionen definiert sind,\r\nweshalb eine Umbuchung mit dieser Umbuchungsmaske problematisch ist.\r\nBitte verwenden Sie die dafür vorgesehene Storno-Funktion in der SiLei-Maske.\r\n\r\nMöchten Sie trotzdem weiterfahren mit der Umbuchung", false))
                {
                    return false;
                }
            }

            _qryKbBuchungBrutto.EndCurrentEdit();

            try
            {
                Inserting = true;

                bool quoting = (bool)_qryKbBuchungBruttoSuche["Quoting", DataRowVersion.Original];
                bool onlyInsertAdditionalNeu = _qryKbBuchungBrutto.Count > 0;

                if (!onlyInsertAdditionalNeu)
                {
                    _edtValutaDatum.EditValue = DateTime.Today;

                    // Stornobuchung erstellen
                    try
                    {
                        ChangingData = true;
                        _qryKbBuchungBrutto.Insert();
                        CopyBelegFields(true, quoting);
                        _qryKbBuchungBrutto.Post();
                    }
                    finally
                    {
                        ChangingData = false;
                    }

                    RecreateDetailBuchungen(false);
                }

                // Neubuchungen
                try
                {
                    if (onlyInsertAdditionalNeu)
                    {
                        ChangingData = true;

                        _qryKbBuchungBrutto.Insert();
                        CopyBelegFields(false, quoting);
                        _qryKbBuchungBrutto.Post();

                        ChangingData = false;

                        RecreateDetailBuchungen(false);
                    }
                    else
                    {
                        bool isSiLei = _qryKbBuchungBruttoSuche["PscdKennzeichen", DataRowVersion.Original] as string == "S";
                        if (isSiLei)
                        {
                            // Silei-Beleg, aus jeder Detailposition wird ein NEU-Kopfbeleg mit einer Detailposition erstellt
                            SqlQuery qryPositionen = DBUtil.OpenSQL(@"
                                SELECT Betrag, Buchungstext, BaPersonID, VerwPeriodeVon, VerwPeriodeBis, SpezBgKostenartID, SpezHauptvorgang, SpezTeilvorgang, BKA.BgSplittingartCode, BKA.Weiterverrechenbar, BKA.Quoting, BgKostenart = BKA.KontoNr + ' ' + BKA.Name, BKA.KontoNr
                                FROM KbBuchungBruttoPerson KBB
                                  INNER JOIN BgKostenart   BKA ON BKA.BgKostenartID = KBB.SpezBgKostenartID
                                WHERE KbBuchungBruttoID = {0}",
                                _qryKbBuchungBruttoSuche["KbBuchungBruttoID"]);

                            foreach (DataRow row in qryPositionen.DataTable.Rows)
                            {
                                ChangingData = true;

                                _qryKbBuchungBrutto.Insert();

                                CopyBelegFields(false, quoting);

                                _qryKbBuchungBrutto["BgKostenartID"] = row["SpezBgKostenartID"];
                                _qryKbBuchungBrutto["Hauptvorgang"] = row["SpezHauptvorgang"];
                                _qryKbBuchungBrutto["Teilvorgang"] = row["SpezTeilvorgang"];
                                _qryKbBuchungBrutto["Betrag"] = row["Betrag"];
                                _qryKbBuchungBrutto["TextVariabel"] = row["Buchungstext"];
                                _qryKbBuchungBrutto["Text"] = string.Format("NEU {0} {1}", _qryKbBuchungBruttoSuche["BelegNr"], row["Buchungstext"]);
                                _qryKbBuchungBrutto["BetrifftPerson"] = quoting
                                                                           ? DBNull.Value
                                                                           : (object)
                                                                             string.Format(
                                                                                 "{0} ({1})",
                                                                                 DBUtil.ExecuteScalarSQL("SELECT NameVorname FROM vwPerson WHERE BaPersonID = {0}", row["BaPersonID"]),
                                                                                 row["BaPersonID"]);
                                _qryKbBuchungBrutto["BetrifftBaPersonID"] = quoting ? DBNull.Value : row["BaPersonID"];
                                _qryKbBuchungBrutto["VerwPeriodeVon"] = row["VerwPeriodeVon"];
                                _qryKbBuchungBrutto["VerwPeriodeBis"] = row["VerwPeriodeBis"];

                                _qryKbBuchungBrutto.Post();

                                ChangingData = false;

                                RecreateDetailBuchungen(false);
                            }
                        }
                        else if (quoting)
                        {
                            ChangingData = true;

                            _qryKbBuchungBrutto.Insert();
                            _qryKbBuchungBrutto["KbBuchungBruttoID_Zuweisung"] = _qryKbBuchungBruttoSuche["KbBuchungBruttoID"];
                            CopyBelegFields(false, quoting);
                            _qryKbBuchungBrutto.Post();

                            ChangingData = false;

                            RecreateDetailBuchungen(false);
                        }
                        else
                        {
                            // Nicht gequotete Belege werden aufgeteilt, d.h. aus jeder Detailposition wird ein neuer NEU-Belegkopf erstellt
                            SqlQuery qryPositionen = DBUtil.OpenSQL(@"
                                SELECT KbBuchungBruttoPersonID, BaPersonID, Buchungstext, Betrag, VerwPeriodeVon, VerwPeriodeBis
                                FROM KbBuchungBruttoPerson
                                WHERE KbBuchungBruttoID = {0}",
                                _qryKbBuchungBruttoSuche["KbBuchungBruttoID"]);

                            foreach (DataRow row in qryPositionen.DataTable.Rows)
                            {
                                ChangingData = true;
                                _qryKbBuchungBrutto.Insert();

                                CopyBelegFields(false, quoting);

                                // Korrigiere den neuen Kopfbeleg mit den Detailpositionsdaten
                                _qryKbBuchungBrutto["KbBuchungBruttoPersonID_Zuweisung"] = row["KbBuchungBruttoPersonID"];
                                _qryKbBuchungBrutto["Betrag"] = row["Betrag"];
                                _qryKbBuchungBrutto["TextVariabel"] = row["Buchungstext"];
                                _qryKbBuchungBrutto["Text"] = string.Format("NEU {0} {1}", _qryKbBuchungBruttoSuche["BelegNr"], row["Buchungstext"]);
                                _qryKbBuchungBrutto["BetrifftPerson"] = quoting
                                                                           ? DBNull.Value
                                                                           : (object)
                                                                             string.Format(
                                                                                 "{0} ({1})",
                                                                                 DBUtil.ExecuteScalarSQL("SELECT NameVorname FROM vwPerson WHERE BaPersonID = {0}", row["BaPersonID"]),
                                                                                 row["BaPersonID"]);
                                _qryKbBuchungBrutto["BetrifftBaPersonID"] = quoting ? DBNull.Value : row["BaPersonID"];
                                _qryKbBuchungBrutto["VerwPeriodeVon"] = row["VerwPeriodeVon"];
                                _qryKbBuchungBrutto["VerwPeriodeBis"] = row["VerwPeriodeBis"];

                                _qryKbBuchungBrutto.Post();
                                ChangingData = false;

                                RecreateDetailBuchungen(false);
                            }
                        }
                    }
                }
                finally
                {
                    ChangingData = false;
                }

                // Setze nochmals die SplittingArt => Falls die Verwendungsperiode angepasst wird, wird dies auch in den eben erst erstellten Detailpositionen der NEU-Belege reflektiert
                SetSplittingArt(_qryKbBuchungBrutto["BgSplittingartCode"]);
            }
            finally
            {
                Inserting = false;
            }

            return true;
        }

        public void ProgressStart()
        {
            try
            {
                _belegeKorrigierenControl.Cursor = Cursors.WaitCursor;
                Application.DoEvents();

                UpdateWasSuccessfull = false;

                DlgProgressLog.AddLine("Start der Umbuchung");
                Application.DoEvents();

                HashSet<int> kbBuchungBruttoIDs_AlreadyUmgebucht = new HashSet<int>();

                if (_throwExceptionInPlaceOfMessage)
                {
                    var isOk = true;
                    var positionInit = _qryKbBuchungBruttoSuche.Position;
                    var positionFirstError = -1;
                    _qryKbBuchungBruttoSuche.First();
                    var totalUmbuchung = _qryKbBuchungBruttoSuche.DataTable.Rows.Cast<DataRow>().Count(x => x["Auswahl"] as bool? ?? false);
                    var countUmbuchung = 0;

                    do
                    {
                        if (_qryKbBuchungBruttoSuche["Auswahl"] as bool? ?? false)
                        {
                            countUmbuchung++;

                            DlgProgressLog.AddLine(string.Format("Umbuchung {0} von {1}", countUmbuchung, totalUmbuchung));
                            KbBuchungBruttoIDsWithExistingDetailPositions = new List<int>();

                            int kbBuchungBruttoID = (int)_qryKbBuchungBruttoSuche["KbBuchungBruttoID"];

                            bool alreadyUmgebucht = kbBuchungBruttoIDs_AlreadyUmgebucht.Contains(kbBuchungBruttoID);

                            if (alreadyUmgebucht)
                            {
                                //Diese Buchung wurde bereits im Rahmen dieser Verarbeitung umgebucht.
                                //Hinweis: nicht gequotete Brutto-Belege mit gleichem Auszahldatum und Leistungsart werden zu einem Beleg mit mehreren Detailbuchungen zusammengefasst.
                                //In dieser Maske werden solche Belege aber auf mehreren Zeilen angezeigt und würden somit eigentlich getrennt verarbeitet.
                                //Sie müssen aber in einem Durchlauf storniert und neugebucht werden.
                                //Deshalb sind alle nachfolgenden Zeilen bereits umgebucht und können übersprungen werden.
                                //Es muss aber noch sichergestellt werden, dass der Status und das Auswahl-Häkchen korrekt dargestellt wird
                                DlgProgressLog.AddLine(string.Format("Storno-/Neubuchungen von {0} wurden bereits erzeugt", _qryKbBuchungBruttoSuche["BelegNr"]));

                                _qryKbBuchungBruttoSuche["KbBuchungStatusCode"] = 8; // storniert
                                _qryKbBuchungBruttoSuche["Auswahl"] = 0;
                                continue;
                            }

                            _qryKbBuchungBrutto.Fill(kbBuchungBruttoID, 0);

                            bool detailDataLoaded = false;
                            foreach (DataRow row in _qryKbBuchungBrutto.DataTable.Rows)
                            {
                                if (!DBUtil.IsEmpty(row["KbBuchungBruttoID"]))
                                {
                                    int id = (int)row["KbBuchungBruttoID"];
                                    if (BelegeKorrigierenTemporaryTableHelper.LoadDetailsIntoTemporaryKbBuchungBruttoPersonTable(id) > 0)
                                    {
                                        // Es wurde mind. eine Detailposition geladen, d.h. es gibt OriginalPositionen. Füge die ID in die Liste der noch nicht geänderten Belege ein
                                        detailDataLoaded = true;
                                        KbBuchungBruttoIDsWithExistingDetailPositions.Add(id);
                                    }
                                }
                            }

                            if (!detailDataLoaded)
                            {
                                _qryKbBuchungBruttoPerson.DataTable.Clear();

                                // Storno- und Neubuchung in _qryKbBuchungBrutto erstellen
                                try
                                {
                                    if (!OnAddData())
                                    {
                                        continue;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    DlgProgressLog.AddError(string.Format("Fehler beim erstellen von Storno- und Neu-Buchung: {0}", ex.Message));
                                    DlgProgressLog.EndProgress();
                                    DlgProgressLog.ShowTopMost();
                                    _belegeKorrigierenControl.Cursor = Cursors.Default;
                                    continue;
                                }
                            }
                            else
                            {
                                _qryKbBuchungBruttoPerson.Fill(kbBuchungBruttoID);
                            }

                            bool checkIsOk = false;

                            try
                            {
                                try
                                {
                                    //Daten für die Neubuchung setzen. Im Rahmen dieser Methode werden die Neubuchungen auch validiert
                                    checkIsOk = SetNeuBuchung();
                                }
                                catch (Exception ex)
                                {
                                    DlgProgressLog.AddError(
                                        string.Format("Interner Fehler beim Erstellen von Storno- und Neu-Buchung: {0}", ex.Message));
                                    _belegeKorrigierenControl.Cursor = Cursors.Default;

                                    isOk = false;
                                    continue;
                                }

                                // Umbuchen und erste fehlerhafte Buchung selektieren
                                if (checkIsOk && !_qryKbBuchungBrutto.IsEmpty)
                                {
                                    bool umbuchenIsOk = BelegUmbuchen();
                                    if (umbuchenIsOk)
                                    {
                                        _qryKbBuchungBruttoSuche["KbBuchungStatusCode"] = 8; // storniert
                                        _qryKbBuchungBruttoSuche["Auswahl"] = 0;
                                    }

                                    isOk = isOk && umbuchenIsOk;
                                }
                            }
                            finally
                            {
                                isOk = isOk && checkIsOk;

                                if (!isOk && positionFirstError < 0)
                                {
                                    positionFirstError = _qryKbBuchungBruttoSuche.Position;
                                }

                                UpdateWasSuccessfull = isOk;

                                kbBuchungBruttoIDs_AlreadyUmgebucht.Add(kbBuchungBruttoID);
                            }
                        }
                    }
                    while (_qryKbBuchungBruttoSuche.Next());

                    if (isOk)
                    {
                        _qryKbBuchungBruttoSuche.Position = positionInit;
                    }
                    else
                    {
                        _qryKbBuchungBruttoSuche.Position = positionFirstError;
                    }
                }
                else
                {
                    BelegUmbuchen();
                }

                DlgProgressLog.EndProgress();
                DlgProgressLog.ShowTopMost();
            }
            finally
            {
                _belegeKorrigierenControl.Cursor = Cursors.Default;
            }
        }

        public bool RecreateDetailBuchungen(bool forceRecreate)
        {
            if (ChangingData)
            {
                return true; // Keine Buchungen erstellen, wärend noch Daten zugefügt werden
            }

            if ((int)_qryKbBuchungBrutto["KbBuchungStatusCode"] == 3 || (int)_qryKbBuchungBrutto["KbBuchungStatusCode"] == 8)
            {
                return true; // Buchungen, die bereits übermittelt oder storniert sind, können nicht mehr geändert werden
            }

            try
            {
                Session.BeginTransaction();

                bool storno = (bool)_qryKbBuchungBrutto["Storno"];
                bool quoting = (bool)_qryKbBuchungBrutto["Quoting"];
                bool isSiLei = _qryKbBuchungBruttoSuche["PscdKennzeichen"] as string == "S";
                decimal neuBetrag = (decimal)_qryKbBuchungBrutto["Betrag"];
                bool useOriginalDetailBelege = false;
                decimal sign = storno ? -1 : 1;
                List<int> personen = new List<int>();

                int kbBuchungBruttoID = (int)_qryKbBuchungBrutto["KbBuchungBruttoID"];

                // Entferne die ID aus der Liste, da nun die Detailpositionen neu aufgebaut werden
                if (KbBuchungBruttoIDsWithExistingDetailPositions.Contains(kbBuchungBruttoID))
                {
                    KbBuchungBruttoIDsWithExistingDetailPositions.Remove(kbBuchungBruttoID);
                }

                // Entferne zuerst alle Detail-Rows für die Kopf-Buchung
                BelegeKorrigierenTemporaryTableHelper.RemoveDetailsFromTemporaryKbBuchungBruttoPersonTable(kbBuchungBruttoID);

                if (!forceRecreate && (storno || (quoting && DBUtil.IsEmpty(_qryKbBuchungBrutto["BgFinanzplanID"]))))
                {
                    // Wenn das Flag forceRecreate nicht gesetzt ist und oder wenn dies ein STO-Beleg ist, oder ein gequoteter Beleg ist ohne definiertem Finanzplan,
                    // dann übernehme die Detailbelege vom Originalbeleg
                    useOriginalDetailBelege = true;
                }

                if (useOriginalDetailBelege)
                {
                    // übernehme die Detailbelege vom Originalbeleg (quoting & splitting)
                    DataTable origDetailTable = _qryKbBuchungBruttoSuche.DataSet.Tables[1];
                    foreach (DataRow origRow in origDetailTable.Rows)
                    {
                        if (origRow["KbBuchungBruttoID"].Equals(_qryKbBuchungBruttoSuche["KbBuchungBruttoID"]))
                        {
                            // Kopiere diese Detail-Zeile
                            int baPersonID = DBUtil.IsEmpty(origRow["BaPersonID"]) ? 0 : (int)origRow["BaPersonID"];
                            BelegeKorrigierenTemporaryTableHelper.AddDetailToTemporaryKbBuchungBruttoPersonTable(
                                kbBuchungBruttoID,
                                (string)origRow["Person"],
                                baPersonID,
                                origRow["Schuldner_BaInstitutionID"],
                                origRow["Schuldner_BaPersonID"],
                                (string)_qryKbBuchungBrutto["Text"],
                                sign * decimal.Parse(origRow["Betrag"].ToString()),
                                (DateTime)origRow["VerwPeriodeVon"],
                                (DateTime)origRow["VerwPeriodeBis"],
                                origRow["SpezBgKostenartID"],
                                origRow["SpezHauptvorgang"],
                                origRow["SpezTeilvorgang"],
                                (bool)origRow["GesperrtFuerWV"],
                                origRow["Zinsperiode"]);
                        }
                    }
                }
                else
                {
                    if (quoting)
                    {
                        // Quoting
                        if (!DBUtil.IsEmpty(_qryKbBuchungBrutto["BgFinanzplanID"]) && (int)_qryKbBuchungBrutto["BgFinanzplanID"] > 0)
                        {
                            // Der Finanzplan des NEU-Belegs ist definiert => verwende den Haushalt aus dem Finanzplan fürs quoting
                            SqlQuery haushalt = DBUtil.OpenSQL("SELECT DISTINCT BaPersonID FROM BgFinanzplan_BaPerson WHERE BgFinanzplanID = {0} AND IstUnterstuetzt = 1", _qryKbBuchungBrutto["BgFinanzplanID"]);

                            foreach (DataRow row in haushalt.DataTable.Rows)
                            {
                                personen.Add((int)row["BaPersonID"]);
                            }
                        }
                        else if (!DBUtil.IsEmpty(_qryKbBuchungBrutto["SelectedHaushaltProleistPersonenIDs"]) &&
                                 ((string)_qryKbBuchungBrutto["SelectedHaushaltProleistPersonenIDs"]).Length > 0)
                        {
                            // Ein Proleist-Haushalt wurde selektiert
                            foreach (string id in ((string)_qryKbBuchungBrutto["SelectedHaushaltProleistPersonenIDs"]).Split(','))
                            {
                                personen.Add(int.Parse(id));
                            }
                        }
                        else
                        {
                            // Weder der Proleist-Haushalt noch ein KiSS-Finanzplan ist definiert => Fehler
                            throw new Exception("Bitte selektieren Sie einen gültigen Haushalt.");
                        }
                    }
                    else
                    {
                        // Kein Quoting, d.h. wir erstellen nur einen Detailbeleg für BetrifftPerson (falls definiert) und sonst für LT
                        personen.Add(DBUtil.IsEmpty(_qryKbBuchungBrutto["BetrifftBaPersonID"]) ? (int)_qryKbBuchungBrutto["LTBaPersonID"] : (int)_qryKbBuchungBrutto["BetrifftBaPersonID"]);
                    }

                    // Nun erstelle die Detailbelege
                    int anzahlPersonen = personen.Count;

                    // runden
                    decimal teilbetrag = neuBetrag / anzahlPersonen;
                    teilbetrag = Math.Floor(teilbetrag * 20m + 0.5m) / 20m;
                    int counter = 0;
                    decimal summe = 0m;
                    decimal betrag;

                    SqlQuery person = DBUtil.OpenSQL("SELECT Person=NameVorname + ' (' + convert(varchar,BaPersonID) + ')' FROM vwPerson WHERE BaPersonID = {0}", 0);

                    foreach (int personID in personen)
                    {
                        if (++counter == anzahlPersonen)
                        {
                            betrag = neuBetrag - summe;
                        }
                        else
                        {
                            betrag = teilbetrag;
                        }

                        person.Fill(personID);

                        BelegeKorrigierenTemporaryTableHelper.AddDetailToTemporaryKbBuchungBruttoPersonTable(
                            kbBuchungBruttoID,
                            (string)person["Person"],
                            personID,
                            (string)_qryKbBuchungBrutto["Text"],
                            betrag,
                            (DateTime)_qryKbBuchungBrutto["VerwPeriodeVon"],
                            (DateTime)_qryKbBuchungBrutto["VerwPeriodeBis"]);

                        summe += teilbetrag;
                    }
                }

                Session.Commit();

                _qryKbBuchungBruttoPerson.Fill(kbBuchungBruttoID);
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);

                return false;
            }

            return true;
        }

        /// <summary>
        /// Lässt den Benutzer aus den möglichen KiSS- und dem Proleist-Haushalt wählen.
        /// </summary>
        public int SelectHaushalt()
        {
            var resultRow = ShowHaushaltDialog(
                Utils.ConvertToInt(_qryKbBuchungBrutto["FaFallID"]),
                _qryKbBuchungBrutto["LTBaPersonID"] as int?,
                _qryKbBuchungBrutto["BgFinanzplanID"] as int?);

            if (resultRow == null)
            {
                return -1;
            }

            // Speichere hier die Finanzplan-ID, die Leistungs-ID und die Eckdaten des selektierten Haushalts ab
            _qryKbBuchungBrutto["SelectedHaushaltDatumVon"] = DBUtil.IsEmpty(resultRow["DatVonProLei"]) ? resultRow["DatVonKiSS"] : resultRow["DatVonProLei"];
            _qryKbBuchungBrutto["SelectedHaushaltDatumBis"] = DBUtil.IsEmpty(resultRow["DatBisProLei"]) ? resultRow["DatBisKiSS"] : resultRow["DatBisProLei"];
            _qryKbBuchungBrutto["SelectedHaushaltProleistPersonenIDs"] = resultRow["PersonenIDs$"];
            _qryKbBuchungBrutto["BgFinanzplanID"] = resultRow["BgFinanzplanID$"];
            _qryKbBuchungBrutto["FaLeistungID"] = resultRow["FaLeistungID"];

            return (int)resultRow["BgFinanzplanID$"];
        }

        public void SetSplittingArt(object splittingartCode)
        {
            if (!(splittingartCode is int))
            {
                return;
            }

            int art = (int)splittingartCode;
            int originalArt = 0;

            if (!DBUtil.IsEmpty(_qryKbBuchungBruttoSuche["BgSplittingArtCode", DataRowVersion.Original]))
            {
                originalArt = (int)_qryKbBuchungBruttoSuche["BgSplittingArtCode", DataRowVersion.Original];
            }

            bool storno = _qryKbBuchungBrutto["Storno"] as bool? ?? false;

            var verwVonNeu = (DateTime)_qryKbBuchungBrutto["VerwPeriodeVon"];
            var verwBisNeu = (DateTime)_qryKbBuchungBrutto["VerwPeriodeBis"];
            bool verwPeriodeChanged = SetVerwPeriode(art, originalArt, storno, (DateTime)_qryKbBuchungBruttoSuche["VerwPeriodeVon", DataRowVersion.Original], (DateTime)_qryKbBuchungBruttoSuche["VerwPeriodeBis", DataRowVersion.Original], (DateTime)_qryKbBuchungBruttoSuche["ValutaDatum"], ref verwVonNeu, ref verwBisNeu);

            if (verwPeriodeChanged)
            {
                _qryKbBuchungBrutto["VerwPeriodeVon"] = verwVonNeu;
                _qryKbBuchungBrutto["VerwPeriodeBis"] = verwBisNeu;
                UpdateVerwPeriodeOfDetailPositionen();
            }

            _enableControls(); // Das Ändern der Splittinart hat ev. Auswirkungen auf das Control-Enabling
        }

        public bool SetVerwPeriode(int? splittingartCode, int? originalArt, bool storno, DateTime verwPeriodeVonOriginal, DateTime verwPeriodeBisOriginal, DateTime valuta, ref DateTime verwPeriodeVon, ref DateTime verwPeriodeBis)
        {
            if (!splittingartCode.HasValue)
            {
                return false;
            }

            originalArt = originalArt ?? 0;

            bool verwPeriodeChanged = false;
            if (!storno && splittingartCode == 2) // Monatssplitting
            {
                // Gewisse Altbuchungen haben für das Monatssplitting noch ungültige Verwendungsperioden

                if (verwPeriodeVon.Day != 1)
                {
                    // VerwendungsperiodeVon ist nicht am Anfang des Monats => Korrigiere dies auf Anfang des Monats
                    verwPeriodeVon = new DateTime(verwPeriodeVon.Year, verwPeriodeVon.Month, 1);
                    verwPeriodeChanged = true;
                }

                if (verwPeriodeBis.AddDays(1).Day != 1)
                {
                    // VerwendungsperiodeBis ist nicht am Ende des Monats => Korrigiere dies auf Ende des Monat
                    verwPeriodeBis = new DateTime(verwPeriodeBis.Year, verwPeriodeBis.Month, 1).AddMonths(1).AddDays(-1);
                    verwPeriodeChanged = true;
                }
            }

            if (!storno && splittingartCode == 3) // Valuta
            {
                if (originalArt == 3)
                {
                    // Der Originalbeleg war auch nach valuta gesplittet => Wir können die Verwendungsperiode 1 zu 1 übernehmen
                    verwPeriodeVon = verwPeriodeVonOriginal;
                    verwPeriodeBis = verwPeriodeBisOriginal;
                    verwPeriodeChanged = true;
                }
                else
                {
                    // Der Originalbeleg war nicht nach Valuta gesplittet, d.h. die neue Verwendungsperiode leitet sich vom Valutadatum des Originalbelegs ab
                    verwPeriodeVon = valuta;
                    verwPeriodeBis = valuta;
                    verwPeriodeChanged = true;
                }
            }
            else if (!storno && splittingartCode == 4) // Entscheid
            {
                verwPeriodeBis = verwPeriodeVon;
                verwPeriodeChanged = true;
            }

            return verwPeriodeChanged;
        }

        public void UpdateVerwPeriodeOfDetailPositionen()
        {
            if (!DBUtil.IsEmpty(_qryKbBuchungBrutto["KbBuchungBruttoID"]))
            {
                int id = (int)_qryKbBuchungBrutto["KbBuchungBruttoID"];

                // Entferne die ID aus der Liste, da nun die Detailpositionen neu aufgebaut werden
                if (KbBuchungBruttoIDsWithExistingDetailPositions.Contains(id))
                {
                    KbBuchungBruttoIDsWithExistingDetailPositions.Remove(id);
                }

                // Ändere auch die VerwendungsperiodeVon der Detailpositionen
                BelegeKorrigierenTemporaryTableHelper.UpdateVerwPeriodeOfTemporaryKbBuchungBruttoPersonTable(id, _edtVerwPeriodeVon.DateTime, _edtVerwPeriodeBis.DateTime);

                _qryKbBuchungBruttoPerson.Refresh();
            }
        }

        /// <summary>
        /// Daten vor die Belegkorrektur validieren
        /// </summary>
        /// <returns><c>true</c> falls die Daten volständig sind und sonst <c>false</c></returns>
        public bool ValidateBeforeProcessStart()
        {
            if (_qryKbBuchungBruttoSuche.Count == 0)
            {
                return false;
            }

            if (!CheckAndSaveUmbuchungBuchung())
            {
                return false;
            }

            _qryKbBuchungBrutto.DataTable.AcceptChanges();

            // Gehe nochmals alle Belege durch und prüfe sie
            try
            {
                _qryKbBuchungBrutto.First();
                do
                {
                    CheckRow();
                }
                while (_qryKbBuchungBrutto.Next());
            }
            catch (KissCancelException ex)
            {
                if (_throwExceptionInPlaceOfMessage)
                {
                    throw;
                }
                ex.ShowMessage();
                return false;
            }

            // Prüfe übergreifende Daten
            decimal betrag = 0;

            foreach (DataRow row in _qryKbBuchungBrutto.DataTable.Rows)
            {
                betrag += (decimal)row["Betrag"];
            }

            if (betrag != 0)
            {
                KissMsg.ShowInfo(string.Format("Die Betrags-Summe der NEU-Buchung(en) entspricht nicht dem STO-Betrag.\r\nDie Differenz beträgt {0}", betrag));
                return false;
            }

            if (DBUtil.IsEmpty(_edtValutaDatum.EditValue))
            {
                KissMsg.ShowInfo("CtlKbBelegeKorrigieren", "BelegDatumLeer", "Valutadatum muss ausgefüllt sein.");
                return false;
            }

            // Hier stellen wir sicher, dass ein Finanzplan bekannt ist, in dem der Haushalt resp. die betroffene Person der STO- resp. NEU-Buchungen existiert
            foreach (DataRow row in _qryKbBuchungBrutto.DataTable.Rows)
            {
                bool stornoRow = (bool)row["Storno"];
                if (stornoRow)
                {
                    continue; // Der Storno soll auf die Original-Leistung gebucht werden, d.h. da ändern wir nichts
                }

                //Check and set Combi {Finanzplan - FaLeistung - Haushalt}

                bool quoting = (bool)row["Quoting"];
                object bgFinanzplanID = row["BgFinanzplanID"];
                object faLeistungID = row["FaLeistungID"];
                object selectedHaushaltProleistPersonenIDs = row["SelectedHaushaltProleistPersonenIDs"];
                object selectedHaushaltDatumVon = row["SelectedHaushaltDatumVon"];
                object selectedHaushaltDatumBis = row["SelectedHaushaltDatumBis"];

                string messageInfo = string.Empty;

                bool faLeistungValidateRes = CheckSetCombiFinanzplanFaLeistungHaushalt(
                    quoting,
                    row["BetrifftBaPersonID"],
                    row["FaFallID"],
                    row["LTBaPersonID"],
                    ref bgFinanzplanID,
                    ref faLeistungID,
                    ref selectedHaushaltProleistPersonenIDs,
                    ref selectedHaushaltDatumVon,
                    ref selectedHaushaltDatumBis,
                    ref messageInfo);

                row["BgFinanzplanID"] = bgFinanzplanID;
                row["FaLeistungID"] = faLeistungID;
                row["SelectedHaushaltProleistPersonenIDs"] = selectedHaushaltProleistPersonenIDs;
                row["SelectedHaushaltDatumVon"] = selectedHaushaltDatumVon;
                row["SelectedHaushaltDatumBis"] = selectedHaushaltDatumBis;

                //InfoMessage ?
                if (!string.IsNullOrEmpty(messageInfo))
                {
                    KissMsg.ShowInfo(messageInfo);
                }

                //Fehler...
                if (!faLeistungValidateRes)
                {
                    return false;
                }
            }

            return true;
        }

        private static long GetBelegNr(object belegart)
        {
            if (DBUtil.IsEmpty(belegart))
            {
                throw new Exception("Belegart ist nicht definiert!");
            }

            return (long)DBUtil.ExecuteScalarSQLThrowingException(@"
                DECLARE @BelegNr bigint
                EXEC spKbGetBelegNr_out {0}, @BelegNr OUT
                SELECT @BelegNr", belegart);
        }

        private static object GetValue(SqlQuery qry, string propertyName, bool original)
        {
            if (original)
            {
                return qry[propertyName, DataRowVersion.Original];
            }

            return qry[propertyName];
        }

        private bool BelegUmbuchen()
        {
            SqlQuery qryUpdateBuchungBrutto = DBUtil.OpenSQL("SELECT * FROM KbBuchungBrutto WHERE 1 = 0");
            SqlQuery qryUpdateBuchungBruttoPerson = DBUtil.OpenSQL("SELECT * FROM KbBuchungBruttoPerson WHERE 1 = 0");

            int countNeuBuchungen = 0;
            var kbBuchungBruttoIDsForTransfer = new List<int>();
            var mapAlreadyCreatedProleistHaushalteToBgFinanzplanID = new Dictionary<string, int>();
            var listFaelleMitNeuenProleistHaushalten = new List<int>();

            try
            {
                Session.BeginTransaction();

                object valutaDatum = _edtValutaDatum.EditValue;
                SqlQuery qryKbPeriode = DBUtil.OpenSQL(@"
                    SELECT *
                    FROM dbo.KbPeriode
                    WHERE KbMandantCode = 1 /*für ZH nur Mandant 1*/
                        AND PeriodeStatusCode = 1 /*offen*/
                        AND GETDATE() BETWEEN PeriodeVon AND PeriodeBis");

                string gruppierungUmbuchung = string.Format("S{0}", GetBelegNr("PYGRP").ToString("00000000"));

                DlgProgressLog.AddLine(string.Format("Storno-/Neubuchungen von {0} erzeugen...", _qryKbBuchungBruttoSuche["BelegNr"]));

                foreach (DataRow row in _qryKbBuchungBrutto.DataTable.Rows)
                {
                    bool stornoRow = (bool)row["Storno"];

                    if (stornoRow)
                    {
                        // Prüfe, ob die Original-Buchung nicht schon umgebucht wurde in der Zwischenzeit.
                        // Dies wäre der Fall, falls wir eine STO-Buchung finden würden, deren KbBuchungBruttoID nicht der KbBuchungBruttoID dieses Belegs entspricht
                        object nrOfSto =
                            DBUtil.ExecuteScalarSQLThrowingException(
                                @"
                                SELECT COUNT(KbBuchungBruttoID) FROM KbBuchungBrutto
                                WHERE StorniertKbBuchungBruttoID = {0} and KbBuchungBruttoID <> {1}",
                                _qryKbBuchungBruttoSuche["KbBuchungBruttoID"],
                                row["KbBuchungBruttoID"]);

                        if (nrOfSto is int && (int)nrOfSto > 0)
                        {
                            UpdateWasSuccessfull = true; // Wir setzen dies hier auf True, weil dies den Reload der Originalbelege auslöst, und das ist hier gewünscht.
                            throw new Exception("Der Originalbeleg wurde in der Zwischenzeit bereits umgebucht, es existiert bereits eine STO-Buchung.");
                        }
                    }

                    int status = (int)row["KbBuchungStatusCode"];

                    if (status == 2 || status == 5) //grün/fehlerhaft, nochmals an PSCD senden
                    {
                        kbBuchungBruttoIDsForTransfer.Add((int)row["KbBuchungBruttoID"]);

                        qryUpdateBuchungBrutto = DBUtil.OpenSQL("SELECT * FROM KbBuchungBrutto WHERE KbBuchungBruttoID = {0}", row["KbBuchungBruttoID"]);
                        gruppierungUmbuchung = (string)qryUpdateBuchungBrutto["GruppierungUmbuchung"]; // Hole die GruppierungUmbuchung der pendenten Umbuchung
                    }
                    else if (status == 1) // grau, noch nicht erstellt und übermittelt
                    {
                        qryUpdateBuchungBrutto.Insert("KbBuchungBrutto");
                    }
                    else
                    {
                        continue;
                    }

                    qryUpdateBuchungBrutto["KbPeriodeID"] = qryKbPeriode["KbPeriodeID"];
                    qryUpdateBuchungBrutto["BgBudgetID"] = DBNull.Value; // BudgetID soll immer NULL sein bei Umbuchungen
                    qryUpdateBuchungBrutto["BgKostenartID"] = row["BgKostenartID"];
                    qryUpdateBuchungBrutto["FaLeistungID"] = row["FaLeistungID"];

                    if (stornoRow)
                    {
                        qryUpdateBuchungBrutto["StorniertKbBuchungBruttoID"] = _qryKbBuchungBruttoSuche["KbBuchungBruttoID"];
                        qryUpdateBuchungBrutto["NeubuchungVonKbBuchungBruttoID"] = DBNull.Value;
                    }
                    else
                    {
                        qryUpdateBuchungBrutto["StorniertKbBuchungBruttoID"] = DBNull.Value;
                        qryUpdateBuchungBrutto["NeubuchungVonKbBuchungBruttoID"] = _qryKbBuchungBruttoSuche["KbBuchungBruttoID"];
                    }

                    qryUpdateBuchungBrutto["KbBuchungTypCode"] = 5; // Umbuchung
                    qryUpdateBuchungBrutto["ValutaDatum"] = valutaDatum;
                    qryUpdateBuchungBrutto["BelegDatum"] = valutaDatum;
                    qryUpdateBuchungBrutto["Text"] = row["Text"];

                    qryUpdateBuchungBrutto["Kostenstelle"] = row["Kostenstelle"];
                    qryUpdateBuchungBrutto["Hauptvorgang"] = row["Hauptvorgang"];
                    qryUpdateBuchungBrutto["Teilvorgang"] = row["Teilvorgang"];

                    object belegart = stornoRow ? "UB" : row["Belegart"];
                    qryUpdateBuchungBrutto["Belegart"] = belegart;
                    qryUpdateBuchungBrutto["BelegNr"] = DBUtil.IsEmpty(row["BelegNr"]) ? GetBelegNr(belegart) : row["BelegNr"];
                    qryUpdateBuchungBrutto["Abgetreten"] = row["Abgetreten"];
                    qryUpdateBuchungBrutto["GruppierungUmbuchung"] = gruppierungUmbuchung;
                    qryUpdateBuchungBrutto["PscdKennzeichen"] = "U";

                    qryUpdateBuchungBrutto["BgSplittingArtCode"] = row["BgSplittingArtCode"];
                    qryUpdateBuchungBrutto["Weiterverrechenbar"] = row["Weiterverrechenbar"];

                    bool quoting = (bool)row["Quoting"];
                    qryUpdateBuchungBrutto["Quoting"] = quoting;

                    qryUpdateBuchungBrutto["KbBuchungStatusCode"] = 2;
                    qryUpdateBuchungBrutto["ErfassungsDatum"] = DateTime.Today;
                    qryUpdateBuchungBrutto["UserID"] = Session.User.UserID;
                    qryUpdateBuchungBrutto["ModulID"] = 3;

                    qryUpdateBuchungBrutto["BetragEffektiv"] = (decimal)0;

                    decimal belegBetrag = (decimal)row["Betrag"];
                    qryUpdateBuchungBrutto["Betrag"] = belegBetrag;
                    qryUpdateBuchungBrutto.Post("KbBuchungBrutto");

                    if (status == 1)
                    {
                        countNeuBuchungen++;
                        kbBuchungBruttoIDsForTransfer.Add((int)qryUpdateBuchungBrutto["KbBuchungBruttoID"]);
                    }

                    // Die Detailpositionen müssen nur (neu) aufgebaut werden, wenn der Beleg nicht schon noch korrekte Detailpositionen besitzt
                    if (!KbBuchungBruttoIDsWithExistingDetailPositions.Contains((int)qryUpdateBuchungBrutto["KbBuchungBruttoID"]))
                    {
                        // Nur NEU-Belege: Falls dies ein gequoteter Beleg ist, muss ein Haushalt existieren oder ausgewählt worden sein
                        if (!stornoRow && (DBUtil.IsEmpty(row["BgFinanzplanID"]) || (int)row["BgFinanzplanID"] == 0))
                        {
                            // Es gibt kein KiSS-Finanzplan
                            if (DBUtil.IsEmpty(row["SelectedHaushaltProleistPersonenIDs"]))
                            {
                                if (quoting)
                                {
                                    // Problem, es wurde kein Haushalt ausgewählt (dürfte eigentlich gar nicht vorkommen, das wird schon vorher überprüft)
                                    throw new Exception("Bitte wählen Sie einen gültigen Haushalt aus, die Umbuchung kann sonst nicht verarbeitet werden.");
                                }

                                // Für die BetrifftPerson konnte offensichlich keine Leistung gefunden werden, in dem der Dummy-Haushalt erstellt werden könnte
                                throw new Exception(string.Format("Keine gültige Leistung gefunden für BetrifftPerson {0}", row["BetrifftBaPersonID"]));
                            }

                            string personenIDs = (string)row["SelectedHaushaltProleistPersonenIDs"];
                            int finanzplanID;

                            if (mapAlreadyCreatedProleistHaushalteToBgFinanzplanID.TryGetValue(personenIDs, out finanzplanID) && finanzplanID > 0)
                            {
                                // Speichere die FinanzplanID
                                row["BgFinanzplanID"] = finanzplanID;
                            }
                            else
                            {
                                // Der Proleist-Haushalt wurde noch nicht erstellt, d.h. es muss ein Proleist-Haushalt im KiSS nachgebildet werden

                                // Erstelle einen Dummy-Haushalt in der Leistung des Belegs

                                // Erstelle dazu zuerst einen neuen Finanzplan
                                object objfinanzplanID =
                                    DBUtil.ExecuteScalarSQLThrowingException(
                                        @"
                                        DECLARE @BgFinanzplanID int

                                        INSERT INTO [dbo].[BgFinanzplan]
                                                   ([FaLeistungID]
                                                   ,[BgBewilligungStatusCode]
                                                   ,[WhHilfeTypCode]
                                                   ,[GeplantVon]
                                                   ,[GeplantBis]
                                                   ,[DatumVon]
                                                   ,[DatumBis]
                                                   ,[Bemerkung])
                                             VALUES
                                                   ({0}
                                                   ,9 -- Gesperrt
                                                   ,2 -- Normale WH
                                                   ,{1}
                                                   ,{2}
                                                   ,{1}
                                                   ,{2}
                                                   ,'Automatisch generierter Finanzplan, einzig um den Proleist-Haushalt abzubilden')

                                        SELECT SCOPE_IDENTITY()",
                                        qryUpdateBuchungBrutto["FaLeistungID"],
                                        row["SelectedHaushaltDatumVon"],
                                        row["SelectedHaushaltDatumBis"]);

                                finanzplanID = int.Parse(objfinanzplanID.ToString());

                                // Speichere die neue Finanzplan-ID
                                row["BgFinanzplanID"] = finanzplanID;

                                // Erstelle nun ein Masterbudget
                                DBUtil.ExecSQLThrowingException(
                                    @"
                                        INSERT INTO [dbo].[BgBudget]
                                               ([BgFinanzplanID]
                                               ,[MasterBudget]
                                               ,[BgBewilligungStatusCode]
                                               ,[Jahr]
                                               ,[Monat])
                                            VALUES
                                               ({0}
                                               ,1
                                               ,9
                                               ,YEAR({1})
                                               ,MONTH({1}))",
                                    finanzplanID,
                                    row["SelectedHaushaltDatumVon"]);

                                // Füge nun alle Personen im Haushalt zum Finanzplan dazu
                                foreach (string id in personenIDs.Split(','))
                                {
                                    int personID = int.Parse(id);

                                    DBUtil.ExecSQLThrowingException(
                                        @"
                                            INSERT INTO [dbo].[BgFinanzplan_BaPerson]
                                                       ([BgFinanzplanID]
                                                       ,[BaPersonID]
                                                       ,[IstUnterstuetzt])
                                                 VALUES
                                                       ({0}
                                                       ,{1}
                                                       ,1)",
                                        finanzplanID,
                                        personID);
                                }

                                // Speichere den erstellen Proleist-Haushalt, falls nochmals eine Buchung mit dem gleichen Proleist-Haushalt vorkommt
                                mapAlreadyCreatedProleistHaushalteToBgFinanzplanID.Add(personenIDs, finanzplanID);

                                // Hier merken wir uns alle FallIDs, die neue Haushalte bekommen haben, damit wir weiter unten die WV-Einheiten nachbilden können
                                if (!listFaelleMitNeuenProleistHaushalten.Contains((int)row["FaFallID"]))
                                {
                                    listFaelleMitNeuenProleistHaushalten.Add((int)row["FaFallID"]);
                                }
                            }
                        }

                        // Detailpositionen einfügen
                        if (status != 1)
                        {
                            // Der Status ist grün oder fehlerhaft, d.h. es gibt bereits einen Detailbeleg
                            // Da wir die Detailbelege neu aufbauen, müssen wir zuerst die existierenden Detailbelege löschen
                            DBUtil.ExecSQLThrowingException("DELETE FROM dbo.KbBuchungBruttoPerson WHERE KbBuchungBruttoID = {0}", row["KbBuchungBruttoID"]);
                        }

                        int positionImBeleg = 1;
                        SqlQuery qryDetailPositionen = DBUtil.OpenSQL("SELECT * FROM #TempKbBuchungBruttoPerson WHERE KbBuchungBruttoID = {0}", row["KbBuchungBruttoID"]);

                        foreach (DataRow detailRow in qryDetailPositionen.DataTable.Rows)
                        {
                            // Erstelle eine neuen Detailposition
                            qryUpdateBuchungBruttoPerson.Insert("KbBuchungBruttoPerson");

                            qryUpdateBuchungBruttoPerson["KbBuchungBruttoID"] = qryUpdateBuchungBrutto["KbBuchungBruttoID"];

                            // Kopiere die Detailpositions-Daten
                            qryUpdateBuchungBruttoPerson["BaPersonID"] = detailRow["BaPersonID"];
                            qryUpdateBuchungBruttoPerson["Schuldner_BaInstitutionID"] = detailRow["Schuldner_BaInstitutionID"];
                            qryUpdateBuchungBruttoPerson["Schuldner_BaPersonID"] = detailRow["Schuldner_BaPersonID"];
                            qryUpdateBuchungBruttoPerson["Buchungstext"] = detailRow["Buchungstext"];
                            qryUpdateBuchungBruttoPerson["Betrag"] = detailRow["Betrag"];
                            qryUpdateBuchungBruttoPerson["VerwPeriodeVon"] = detailRow["VerwPeriodeVon"];
                            qryUpdateBuchungBruttoPerson["VerwPeriodeBis"] = detailRow["VerwPeriodeBis"];
                            qryUpdateBuchungBruttoPerson["SpezBgKostenartID"] = detailRow["SpezBgKostenartID"];
                            qryUpdateBuchungBruttoPerson["SpezHauptvorgang"] = detailRow["SpezHauptvorgang"];
                            qryUpdateBuchungBruttoPerson["SpezTeilvorgang"] = detailRow["SpezTeilvorgang"];
                            qryUpdateBuchungBruttoPerson["GesperrtFuerWV"] = detailRow["GesperrtFuerWV"];
                            qryUpdateBuchungBruttoPerson["Zinsperiode"] = detailRow["Zinsperiode"];

                            // Stelle sicher, dass nur Belege ans PSCD gesendet werden, bei denen die Beträge <> 0.00 sind.
                            if ((decimal)qryUpdateBuchungBruttoPerson["Betrag"] == 0)
                            {
                                qryUpdateBuchungBruttoPerson["PositionImBeleg"] = 0; // Dieser Beleg soll nicht ans PSCD geschickt werden, da der Betrag = 0.00 ist
                            }
                            else
                            {
                                qryUpdateBuchungBruttoPerson["PositionImBeleg"] = positionImBeleg++;
                            }

                            qryUpdateBuchungBruttoPerson.Post("KbBuchungBruttoPerson");
                        }
                    }

                    // Bei einer Neubuchung auf SiLei-LA muss eine neue SiLei erstellt werden
                    if (status == 1 && !stornoRow && IsSiLeiAuszahlung(row["Teilvorgang"] as int?))
                    {
                        string kontoNr = row["KontoNr"] as string;
                        int? baMieteSicherheitsleistungArtCode = null;
                        if (kontoNr == "320")
                        {
                            baMieteSicherheitsleistungArtCode = 3; //AS
                        }
                        else if (kontoNr == "321")
                        {
                            baMieteSicherheitsleistungArtCode = 2; //MD
                        }

                        DBUtil.ExecSQLThrowingException(
                            @"
                                INSERT INTO dbo.BaSicherheitsleistung(BaPersonID, AuszahlungAm, BaMieteSicherheitsleistungArtCode)
                                VALUES ({0}, {1}, {2})

                                INSERT INTO BaSicherheitsleistungPosition(BaSicherheitsleistungID, KbBuchungBruttoID)
                                VALUES (SCOPE_IDENTITY(), {3})",
                            row["LTBaPersonID"],
                            valutaDatum,
                            baMieteSicherheitsleistungArtCode,
                            qryUpdateBuchungBrutto["KbBuchungBruttoID"]);
                    }
                }

                // Falls Proleist-Haushalte im KiSS nachgebildet wurden, müssen die WV-Einheiten neu gebildet werden
                foreach (int fallID in listFaelleMitNeuenProleistHaushalten)
                {
                    DBUtil.ExecuteScalarSQLThrowingException("EXEC spWhWVModifyUnits {0}", fallID);
                }

                Session.Commit();

                UpdateWasSuccessfull = true;

                DlgProgressLog.AddLine(string.Format("{0} Storno-/Neubuchung(en) erzeugt", countNeuBuchungen));
            }
            catch (Exception ex)
            {
                Session.Rollback();
                DlgProgressLog.AddError(string.Format("Neubuchungen erzeugen fehlgeschlagen: {0}", ex.Message));
                _belegeKorrigierenControl.Cursor = Cursors.Default;
                return false;
            }

            if (kbBuchungBruttoIDsForTransfer.Count == 0)
            {
                DlgProgressLog.AddLine("Keine Buchungen an PSCD zu übertragen");
            }
            else
            {
                try
                {
                    //Neubuchungen übertragen
                    DlgProgressLog.AddLine(kbBuchungBruttoIDsForTransfer.Count + " Buchungen an PSCD übertragen...");
                    PSCDInterface.SubmitWhBuchungsstoff(null, kbBuchungBruttoIDsForTransfer.ToArray(), _edtValutaDatum.DateTime);
                    DlgProgressLog.AddLine(kbBuchungBruttoIDsForTransfer.Count + " Buchungen erfolgreich an PSCD übertragen");
                }
                catch (Exception ex)
                {
                    DlgProgressLog.AddError(string.Format("Buchungen an PSCD übertragen fehlgeschlagen: {0}", ex.Message));

                    // Setze den Status der Belege, die nicht korrekt übermittelt wurden (d.h. noch Status 2 (grün) haben , auf Status 5 (Fehlerhaft)
                    foreach (int id in kbBuchungBruttoIDsForTransfer)
                    {
                        try
                        {
                            DBUtil.ExecSQL(
                                @"
                                    UPDATE dbo.KbBuchungBrutto
                                      SET KbBuchungStatusCode = 5
                                    WHERE KbBuchungBruttoID = {0}
                                      AND KbBuchungStatusCode = 2",
                                id);
                        }
                        catch (Exception ex2)
                        {
                            DlgProgressLog.AddError(string.Format("Problem beim Setzen des Status von Beleg {0} auf status 'Fehlerhaft': {1}", id, ex2.Message));
                        }
                    }

                    DlgProgressLog.EndProgress();
                    DlgProgressLog.ShowTopMost();
                    return false;
                }
            }

            // Update von Buchungs-Stati
            //==========================

            // Wenn der Originalbeleg auf Status ausgeglichen war, setze auch die NEU-Belege auf Status ausgeglichen
            DBUtil.ExecSQL(@"
                UPDATE dbo.KbBuchungBrutto
                    SET KbBuchungStatusCode = 6
                WHERE NeubuchungVonKbBuchungBruttoID = {0}
                    AND TransferDatum is not null
                    AND Text like 'NEU%'
                    AND 1 = (SELECT COUNT(KbBuchungStatusCode) FROM KbBuchungBrutto WHERE KbBuchungBruttoID = {0} AND KbBuchungStatusCode = 6)",
                _qryKbBuchungBruttoSuche["KbBuchungBruttoID"]);

            // Der Status der Stornobuchung wurde durch die Übermittlung ans PSCD auf 3 (ZahlauftragErstellt) gesetzt
            // Er sollte 8 (storniert) sein
            // Zusätzlich setze auch die Original-Buchung auf Status Storno
            DBUtil.ExecSQL(@"
                UPDATE dbo.KbBuchungBrutto
                    SET KbBuchungStatusCode = 8 /*storniert*/
                WHERE StorniertKbBuchungBruttoID = {0}

                UPDATE dbo.KbBuchungBrutto
                    SET KbBuchungStatusCode = 8 /*storniert*/
                WHERE  KbBuchungBruttoID = {0}",
                _qryKbBuchungBruttoSuche["KbBuchungBruttoID"]);

            DlgProgressLog.AddLine("");
            DlgProgressLog.AddLine("Folgende Belege wurden übermittelt:");

            foreach (DataRow row in qryUpdateBuchungBrutto.DataTable.Rows)
            {
                DlgProgressLog.AddLine(string.Format("{0} ({1})", row["BelegNr"], row["Text"]));
            }

            return true;
        }

        private void CopyBelegFields(bool storno, bool quoting)
        {
            try
            {
                ChangingData = true;

                const bool fromOriginal = true;
                object pscdKennzeichen = GetValue(_qryKbBuchungBruttoSuche, "PscdKennzeichen", fromOriginal);
                object bgKostenartId = GetValue(_qryKbBuchungBruttoSuche, "BgKostenartID", fromOriginal);
                object kontoNr = GetValue(_qryKbBuchungBruttoSuche, "KontoNr", fromOriginal);
                object bgKostenart = GetValue(_qryKbBuchungBruttoSuche, "BgKostenart", fromOriginal);
                object kostenstelle = GetValue(_qryKbBuchungBruttoSuche, "Kostenstelle", fromOriginal);
                object hauptvorgang = GetValue(_qryKbBuchungBruttoSuche, "Hauptvorgang", fromOriginal);
                object teilvorgang = GetValue(_qryKbBuchungBruttoSuche, "Teilvorgang", fromOriginal);
                object bgKostenartHauptvorgang = GetValue(_qryKbBuchungBruttoSuche, "BgKostenartHauptvorgang", fromOriginal);
                object bgKostenartTeilvorgang = GetValue(_qryKbBuchungBruttoSuche, "BgKostenartTeilvorgang", fromOriginal);
                object bgKostenartHauptvorgangAbtretung = GetValue(_qryKbBuchungBruttoSuche, "BgKostenartHauptvorgangAbtretung", fromOriginal);
                object bgKostenartTeilvorgangAbtretung = GetValue(_qryKbBuchungBruttoSuche, "BgKostenartTeilvorgangAbtretung", fromOriginal);
                object belegart = GetValue(_qryKbBuchungBruttoSuche, "Belegart", fromOriginal);
                object weiterverrechenbar = GetValue(_qryKbBuchungBruttoSuche, "Weiterverrechenbar", fromOriginal);
                object faLeistungId = GetValue(_qryKbBuchungBruttoSuche, "FaLeistungID", fromOriginal);
                object belegNr = GetValue(_qryKbBuchungBruttoSuche, "BelegNr", fromOriginal);
                object text = GetValue(_qryKbBuchungBruttoSuche, "Text", fromOriginal);
                object abgetreten = GetValue(_qryKbBuchungBruttoSuche, "Abgetreten", fromOriginal);
                object baPersonId = GetValue(_qryKbBuchungBruttoSuche, "BaPersonID", fromOriginal);
                object betrifftBaPersonIds = GetValue(_qryKbBuchungBruttoSuche, "BetrifftBaPersonIDs", fromOriginal);
                object betrifftPersonen = GetValue(_qryKbBuchungBruttoSuche, "BetrifftPersonen", fromOriginal);
                object betrag = storno ? GetValue(_qryKbBuchungBruttoSuche, "BetragKopf", fromOriginal) : GetValue(_qryKbBuchungBruttoSuche, "Betrag", fromOriginal); //BetragKopf nur bei StornoBuchung nehmen
                object verwPeriodeVon = GetValue(_qryKbBuchungBruttoSuche, "VerwPeriodeVon", fromOriginal);
                object verwPeriodeBis = GetValue(_qryKbBuchungBruttoSuche, "VerwPeriodeBis", fromOriginal);
                object bgSplittingArtCode = GetValue(_qryKbBuchungBruttoSuche, "BgSplittingArtCode", fromOriginal);
                object bgFinanzplanId = GetValue(_qryKbBuchungBruttoSuche, "BgFinanzplanID", fromOriginal);
                object faFallId = GetValue(_qryKbBuchungBruttoSuche, "FaFallID", fromOriginal);

                string praefix = storno ? "STO" : "NEU";
                bool isSiLei = pscdKennzeichen as string == "S";

                _qryKbBuchungBrutto["KbBuchungBruttoID"] = _tempKbBuchungBruttoIDCounter--;
                _qryKbBuchungBrutto["Storno"] = storno;
                _qryKbBuchungBrutto["KbBuchungStatusCode"] = 1; //anfangs immer grau,  vorher: storno ? 8 : 1; //storniert:grau
                _qryKbBuchungBrutto["BgKostenartID"] = bgKostenartId;
                _qryKbBuchungBrutto["KontoNr"] = kontoNr;
                _qryKbBuchungBrutto["BgKostenart"] = bgKostenart;
                _qryKbBuchungBrutto["Kostenstelle"] = kostenstelle;
                _qryKbBuchungBrutto["Hauptvorgang"] = hauptvorgang;
                _qryKbBuchungBrutto["Teilvorgang"] = teilvorgang;
                _qryKbBuchungBrutto["BgKostenartHauptvorgang"] = bgKostenartHauptvorgang;
                _qryKbBuchungBrutto["BgKostenartTeilvorgang"] = bgKostenartTeilvorgang;
                _qryKbBuchungBrutto["BgKostenartHauptvorgangAbtretung"] = bgKostenartHauptvorgangAbtretung;
                _qryKbBuchungBrutto["BgKostenartTeilvorgangAbtretung"] = bgKostenartTeilvorgangAbtretung;
                _qryKbBuchungBrutto["Belegart"] = belegart;
                _qryKbBuchungBrutto["Weiterverrechenbar"] = weiterverrechenbar;
                _qryKbBuchungBrutto["Quoting"] = quoting;
                _qryKbBuchungBrutto["FaLeistungID"] = faLeistungId;
                _qryKbBuchungBrutto["Text"] = string.Format(praefix + " {0} {1}", belegNr, text);
                _qryKbBuchungBrutto["TextFix"] = string.Format(praefix + " {0}", belegNr);
                _qryKbBuchungBrutto["TextVariabel"] = text;
                _qryKbBuchungBrutto["Abgetreten"] = abgetreten;
                _qryKbBuchungBrutto["LT"] = string.Format(
                    "{0} ({1})",
                    DBUtil.ExecuteScalarSQL("SELECT NameVorname FROM vwPerson WHERE BaPersonID = {0}", baPersonId),
                    baPersonId);
                _qryKbBuchungBrutto["LTBaPersonID"] = baPersonId;
                if (storno)
                {
                    string baPersonIDs = betrifftBaPersonIds as string;
                    int betrifftBaPersonID;
                    if (int.TryParse(baPersonIDs, out betrifftBaPersonID))
                    {
                        _qryKbBuchungBrutto["BetrifftPerson"] = betrifftPersonen;
                        _qryKbBuchungBrutto["BetrifftBaPersonID"] = betrifftBaPersonID;
                    }
                    else
                    {
                        _qryKbBuchungBrutto["BetrifftPerson"] = DBNull.Value;
                        _qryKbBuchungBrutto["BetrifftBaPersonID"] = DBNull.Value;
                    }
                }
                else
                {
                    _qryKbBuchungBrutto["BetrifftPerson"] = quoting ? DBNull.Value : _qryKbBuchungBrutto["LT"];
                    _qryKbBuchungBrutto["BetrifftBaPersonID"] = quoting ? DBNull.Value : baPersonId;
                }

                _qryKbBuchungBrutto["Betrag"] = storno ? -((decimal)betrag) : betrag;
                _qryKbBuchungBrutto["VerwPeriodeVon"] = verwPeriodeVon;
                _qryKbBuchungBrutto["VerwPeriodeBis"] = verwPeriodeBis;
                _qryKbBuchungBrutto["BgSplittingArtCode"] = bgSplittingArtCode;
                SetSplittingArt(_qryKbBuchungBrutto["BgSplittingartCode"]);
                _qryKbBuchungBrutto["BgFinanzplanID"] = bgFinanzplanId;
                _qryKbBuchungBrutto["BgBudgetID"] = DBNull.Value; // BudgetID ist bei Umbuchungen immer NULL
                _qryKbBuchungBrutto["FaFallID"] = faFallId;

                // Da ev. der Kontenplan geändert wurde seit der Original-Beleg erstellt wurde,
                // müssen wir hier proaktiv die aktuellen Haupt/Teilvorgänge und andere Kostenart-abhängige Daten neu laden
                if (!FindAndSetKostenart((bool)abgetreten, isSiLei))
                {
                    if (KissMsg.ShowQuestion(string.Format(
                            "Es wurden keine Haupt/Teilvorgänge für die {1}Leistungsart {0} gefunden. Soll die analoge {2}Leistungsart {0} verwendet werden?",
                            bgKostenart,
                            (bool)abgetreten ? "abgetretene " : "",
                            (bool)abgetreten ? "nicht abgetretene " : "abgetretene ")))
                    {
                        if (!FindAndSetKostenart(!(bool)abgetreten, isSiLei))
                        {
                            KissMsg.ShowInfo(string.Format(
                                "Neu-Beleg: Es wurden keine Haupt/Teilvorgänge für die Leistungsart {0} gefunden. Bitte wählen Sie eine neue Leistungsart aus.",
                                bgKostenart));
                            _qryKbBuchungBrutto["BgKostenartID"] = DBNull.Value;
                            _qryKbBuchungBrutto["BgKostenart"] = "";
                        }
                    }
                    else
                    {
                        KissMsg.ShowInfo(string.Format(
                            "Neu-Beleg: Es wurden keine Haupt/Teilvorgänge für die Leistungsart {0} gefunden. Bitte wählen Sie eine neue Leistungsart aus.",
                            bgKostenart));
                        _qryKbBuchungBrutto["BgKostenartID"] = DBNull.Value;
                        _qryKbBuchungBrutto["BgKostenart"] = "";
                    }
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowInfo(ex.Message);
            }
            finally
            {
                ChangingData = false;
            }
        }

        private bool FindAndSetKostenart(bool abgetreten, bool isSilei)
        {
            SqlQuery qryKostenart = DBUtil.OpenSQL(@"
                SELECT
                  KontoNr,
                  Name,
                  BgKostenartID$      = BgKostenartID,
                  KontoNrName$        = KontoNr + ' ' + Name,
                  Hauptvorgang$       = Hauptvorgang,
                  Teilvorgang$        = Teilvorgang,
                  HauptvorgangAbtretung$       = HauptvorgangAbtretung,
                  TeilvorgangAbtretung$        = TeilvorgangAbtretung,
                  Belegart$           = Belegart,
                  BgSplittingArtCode$ = BgSplittingArtCode,
                  SplittingArt$       = SPL.ShortText,
                  Weiterverrechenbar$ = Weiterverrechenbar,
                  Quoting             = Quoting
                FROM dbo.BgKostenart     BKA
                  LEFT JOIN dbo.XLOVCode SPL ON SPL.LOVName = 'BgSplittingart' AND SPL.Code = BKA.BgSplittingartCode
                WHERE ModulID = 3
                  AND (1 = {1}
                        OR (Hauptvorgang IS NOT NULL AND Teilvorgang IS NOT NULL)
                        OR (HauptvorgangAbtretung IS NOT NULL AND TeilvorgangAbtretung IS NOT NULL))
                  AND BgKostenartID = {0}
                ORDER BY 1, 2",
                _qryKbBuchungBruttoSuche["BgKostenartID", DataRowVersion.Original],
                isSilei);

            if (qryKostenart.Count == 1)
            {
                // Ok, wir haben die Kostenart gefunden, kopiere nun die aktuellen Daten hierzu
                _qryKbBuchungBrutto["BgKostenartID"] = qryKostenart["BgKostenartID$"];
                _qryKbBuchungBrutto["KontoNr"] = qryKostenart["KontoNr"];
                _qryKbBuchungBrutto["BgKostenart"] = qryKostenart["KontoNrName$"];
                _qryKbBuchungBrutto["Abgetreten"] = abgetreten;
                if (!isSilei)
                {
                    if (abgetreten)
                    {
                        _qryKbBuchungBrutto["Hauptvorgang"] = qryKostenart["HauptvorgangAbtretung$"];
                        _qryKbBuchungBrutto["Teilvorgang"] = qryKostenart["TeilvorgangAbtretung$"];
                    }
                    else
                    {
                        _qryKbBuchungBrutto["Hauptvorgang"] = qryKostenart["Hauptvorgang$"];
                        _qryKbBuchungBrutto["Teilvorgang"] = qryKostenart["Teilvorgang$"];
                    }

                    _qryKbBuchungBrutto["BgKostenartHauptvorgang"] = qryKostenart["Hauptvorgang$"];
                    _qryKbBuchungBrutto["BgKostenartTeilvorgang"] = qryKostenart["Teilvorgang$"];
                    _qryKbBuchungBrutto["BgKostenartHauptvorgangAbtretung"] = qryKostenart["HauptvorgangAbtretung$"];
                    _qryKbBuchungBrutto["BgKostenartTeilvorgangAbtretung"] = qryKostenart["TeilvorgangAbtretung$"];
                }
                _qryKbBuchungBrutto["Belegart"] = qryKostenart["Belegart$"];
                _qryKbBuchungBrutto["BgSplittingArtCode"] = qryKostenart["BgSplittingArtCode$"];
                _qryKbBuchungBrutto["SplittingArt"] = qryKostenart["SplittingArt$"];
                SetSplittingArt(qryKostenart["BgSplittingArtCode$"]);
                _qryKbBuchungBrutto["Weiterverrechenbar"] = qryKostenart["Weiterverrechenbar$"];
                _qryKbBuchungBrutto["Quoting"] = qryKostenart["Quoting"];
                if ((bool)qryKostenart["Quoting"])
                {
                    _edtBetrifftPerson.EditMode = EditModeType.ReadOnly;
                    _qryKbBuchungBrutto["BetrifftBaPersonID"] = DBNull.Value;
                    _qryKbBuchungBrutto["BetrifftPerson"] = DBNull.Value;
                }
                else
                {
                    _edtBetrifftPerson.EditMode = EditModeType.Normal;
                }

                return true;
            }

            // Wenn wir hierhin kommen, haben wir keine Kostenart gefunden
            return false;
        }

        private bool IsSiLeiAuszahlung(int? teilvorgang)
        {
            return teilvorgang.HasValue && (teilvorgang.Value == 5320 ||
                                            teilvorgang.Value == 5321);
        }

        private bool IsSiLeiLA(int? teilvorgang)
        {
            return teilvorgang.HasValue && (teilvorgang.Value == 5320 ||
                                            teilvorgang.Value == 5321 ||
                                            teilvorgang.Value == 5860 ||
                                            teilvorgang.Value == 5861 ||
                                            teilvorgang.Value == 5862 ||
                                            teilvorgang.Value == 5031 ||
                                            teilvorgang.Value == 5032 ||
                                            teilvorgang.Value == 5033 ||
                                            teilvorgang.Value == 5034 ||
                                            teilvorgang.Value == 5041);
        }

        private bool SetNeuBuchung()
        {
            bool checkIsOk = true;

            _qryKbBuchungBrutto.Find("Storno=0");
            do
            {
                var dataView = new DataView(_qryKbBuchungBruttoSuche.DataTable.Copy());
                if (!DBUtil.IsEmpty(_qryKbBuchungBrutto["KbBuchungBruttoPersonID_Zuweisung"]))
                {
                    dataView.RowFilter = string.Format("KbBuchungBruttoPersonID = {0}", _qryKbBuchungBrutto["KbBuchungBruttoPersonID_Zuweisung"]);
                }
                else
                {
                    dataView.RowFilter = string.Format("KbBuchungBruttoID = {0}", _qryKbBuchungBrutto["KbBuchungBruttoID_Zuweisung"]);
                }

                if (dataView.Count > 0)
                {
                    var dataRowView = dataView[0];

                    _qryKbBuchungBrutto["ValutaDatum"] = dataRowView["ValutaDatum"];
                    _qryKbBuchungBrutto["Betrag"] = dataRowView["Betrag"];
                    _qryKbBuchungBrutto["VerwPeriodeVon"] = dataRowView["VerwPeriodeVon"];
                    _qryKbBuchungBrutto["VerwPeriodeBis"] = dataRowView["VerwPeriodeBis"];
                    _qryKbBuchungBrutto["BgKostenartID"] = dataRowView["BgKostenartID"];
                    _qryKbBuchungBrutto["BgKostenart"] = dataRowView["BgKostenart"];
                    _qryKbBuchungBrutto["BaPersonID"] = dataRowView["BetrifftBaPersonID"];
                    _qryKbBuchungBrutto["LTBaPersonID"] = dataRowView["BaPersonID"];
                    _qryKbBuchungBrutto["BetrifftBaPersonID"] = dataRowView["BetrifftBaPersonID"];
                    _qryKbBuchungBrutto["BetrifftPerson"] = dataRowView["BetrifftPerson"];
                    _qryKbBuchungBrutto["BgFinanzplanID"] = dataRowView["BgFinanzplanID"];

                    _qryKbBuchungBrutto["BgKostenartID"] = dataRowView["BgKostenartID"];
                    _qryKbBuchungBrutto["KontoNr"] = dataRowView["KontoNr"];
                    _qryKbBuchungBrutto["BgKostenart"] = dataRowView["BgKostenart"];
                    _qryKbBuchungBrutto["Abgetreten"] = dataRowView["Abgetreten"];
                    _qryKbBuchungBrutto["Hauptvorgang"] = dataRowView["Hauptvorgang"];
                    _qryKbBuchungBrutto["Teilvorgang"] = dataRowView["Teilvorgang"];
                    _qryKbBuchungBrutto["Belegart"] = dataRowView["Belegart"];
                    _qryKbBuchungBrutto["BgSplittingArtCode"] = dataRowView["BgSplittingArtCode"];
                    _qryKbBuchungBrutto["Weiterverrechenbar"] = dataRowView["Weiterverrechenbar"];
                    _qryKbBuchungBrutto["Quoting"] = dataRowView["Quoting"];
                    _qryKbBuchungBrutto["SplittingArt"] = dataRowView["Splittingart"];

                    _qryKbBuchungBrutto["Kostenstelle"] = dataRowView["Kostenstelle"];
                    _qryKbBuchungBrutto["FaLeistungID"] = dataRowView["FaLeistungID"];
                    _qryKbBuchungBrutto["Text"] = _qryKbBuchungBrutto["TextFix"] + " " + dataRowView["Text"];
                    _qryKbBuchungBrutto["TextVariabel"] = dataRowView["Text"];

                    _qryKbBuchungBrutto["SelectedHaushaltDatumVon"] = dataRowView["SelectedHaushaltDatumVon"];
                    _qryKbBuchungBrutto["SelectedHaushaltDatumBis"] = dataRowView["SelectedHaushaltDatumBis"];
                    _qryKbBuchungBrutto["SelectedHaushaltProleistPersonenIDs"] =
                        dataRowView["SelectedHaushaltProleistPersonenIDs"];

                    _edtValutaDatum.EditValue = dataRowView["ValutaDatum"];
                    _edtBetrag.EditValue = dataRowView["Betrag"];
                    _edtAbgetreten.EditValue = dataRowView["Abgetreten"];
                    _edtTextVariabel.EditValue = dataRowView["Text"];
                    _edtVerwPeriodeVon.EditValue = dataRowView["VerwPeriodeVon"];
                    _edtVerwPeriodeBis.EditValue = dataRowView["VerwPeriodeBis"];
                    _edtBgKostenartID.LookupID = dataRowView["BgKostenartID"];
                    _edtBgKostenartID.EditValue = dataRowView["BgKostenart"];
                    _edtLeistungstraeger.LookupID = dataRowView["BaPersonID"];
                    _edtLeistungstraeger.EditValue = dataRowView["BaPersonID"];
                    _edtBetrifftPerson.LookupID = dataRowView["BetrifftBaPersonID"];
                    _edtBetrifftPerson.EditValue = dataRowView["BetrifftBaPersonID"];

                    RecreateDetailBuchungen(true);
                }

                checkIsOk &= CheckAndSaveUmbuchungBuchung();
            } while (_qryKbBuchungBrutto.Next());

            return checkIsOk;
        }
    }
}