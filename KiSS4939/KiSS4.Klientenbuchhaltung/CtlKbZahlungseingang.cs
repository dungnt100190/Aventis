using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Klientenbuchhaltung
{
    public partial class CtlKbZahlungseingang : KissSearchUserControl
    {
        #region Fields

        #region Private Static Fields

        private static readonly Color _clrGreen = Color.DarkSeaGreen;
        private static readonly Color _clrRed = Color.Salmon;

        #endregion Private Static Fields

        #region Private Constant/Read-Only Fields

        private readonly string _baPersonNameVorname;

        #endregion Private Constant/Read-Only Fields

        #region Private Fields

        private bool _alimentenvermittlungAuszahlen;
        private int? _baPersonID;
        private int _kbPeriodeID;

        #endregion Private Fields

        #endregion Fields

        #region Constructors

        public CtlKbZahlungseingang()
        {
            InitializeComponent();
        }

        public CtlKbZahlungseingang(int baPersonID)
            : this()
        {
            _baPersonID = baPersonID;
            _baPersonNameVorname = DBUtil.ExecuteScalarSQLThrowingException(
                "SELECT NameVorname FROM dbo.vwPersonSimple WHERE BaPersonID = {0}",
                _baPersonID).ToString();
        }

        #endregion Constructors

        #region EventHandlers

        private void btnAusgleichAufheben_Click(object sender, EventArgs e)
        {
            if (!KissMsg.ShowQuestion("Soll die Buchung des Zahlungseingangs und deren Ausgleichsinformationen gelöscht werden?"))
            {
                return;
            }

            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT PER.PeriodeStatusCode, PER.PeriodeBis
                FROM dbo.KbPeriode         PER
                  INNER JOIN dbo.KbBuchung BUC ON BUC.KbPeriodeID = PER.KbPeriodeID
                WHERE BUC.KbZahlungseingangID = {0}",
                qryZahlungseingang["KbZahlungseingangID"]);

            if ((int)qry["PeriodeStatusCode"] != 1)
            {
                KissMsg.ShowInfo("Die zur Zahlung gehörende Periode ist nicht mehr aktiv!");
                return;
            }

            if (!DBUtil.IsEmpty(qry["PeriodeBis"]) && (DateTime)qry["PeriodeBis"] < (DateTime)qryZahlungseingang["Datum"])
            {
                KissMsg.ShowInfo("Das Datum Eingangszahlung befindet sich in einem bereits definitiv verbuchten Datumsbereich!");
                return;
            }

            Session.BeginTransaction();
            // hier darf kein Code stehen!
            try
            {
                DBUtil.ExecuteScalarSQLThrowingException(@"
                    DECLARE @OP TABLE (KbBuchungID int, TotAusgleichBetrag money)

                    INSERT @OP (KbBuchungID)
                    SELECT AUS.OpBuchungID
                    FROM   KbOpAusgleich   AUS
                      INNER JOIN KbBuchung BUC ON BUC.KbBuchungID = AUS.AusgleichBuchungID
                    WHERE BUC.KbZahlungseingangID = {0}

                    DELETE AUS
                    FROM   KbOpAusgleich   AUS
                      INNER JOIN KbBuchung BUC ON BUC.KbBuchungID = AUS.AusgleichBuchungID
                    WHERE BUC.KbZahlungseingangID = {0}

                    DELETE KbBuchungKostenart
                    WHERE KbBuchungID IN (SELECT KbBuchungID FROM KbBuchung WHERE KbZahlungsEingangID = {0})

                    DELETE KbBuchung
                    WHERE KbZahlungseingangID = {0}

                    UPDATE @OP
                    SET    TotAusgleichBetrag = IsNull((SELECT SUM(Betrag) FROM KbOpAusgleich WHERE OpBuchungID = KbBuchungID),0)

                    UPDATE BUC
                    SET    KbBuchungStatusCode = CASE
                                                 WHEN OP.TotAusgleichBetrag = 0 THEN 2            -- freigegeben (grün)
                                                 WHEN OP.TotAusgleichBetrag >= BUC.Betrag THEN 6  -- ausgeglichen
                                                 ELSE 10                                          -- teilausgeglichen
                                                 END
                    FROM   KbBuchung BUC
                      INNER JOIN @OP OP ON OP.KbBuchungID = BUC.KbBuchungID",
                    qryZahlungseingang["KbZahlungseingangID"]);

                qryZahlungseingang["Ausgeglichen"] = 0;
                qryZahlungseingang.Post();
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
            KissMsg.ShowInfo("Der Ausgleich wurde erfolgreich aufgehoben");

            qryZahlungseingang.Refresh();
        }

        private void btnAusgleichen_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("btnAusgleichen_Click");

            decimal summe = decimal.Zero;
            foreach (DataRow row in qryAusgleich.DataTable.Rows)
            {
                var ausglBetrag = row["AusglBetrag"] as decimal?;
                if (ausglBetrag.HasValue)
                {
                    summe += ausglBetrag.Value;
                }
            }

            var restBetrag = (decimal)qryAusgleich["RestBetrag"];
            var totalBetrag = (decimal)qryZahlungseingang["Betrag"];

            qryAusgleich["AusglBetrag"] = Math.Max(Math.Min(restBetrag, totalBetrag - summe), 0m);

            UpdateSum();
        }

        private void btnAusgleichSpeichern_Click(object sender, EventArgs e)
        {
            int[] buchungIDs = UpdateSum();

            if (!btnAusgleichSpeichern.Enabled)
            {
                KissMsg.ShowInfo(
                    KissMsg.GetMLMessage(
                        "CtlKbZahlungseingang",
                        "AusgleichNichtMöglich",
                        "Ausgleich nicht möglich: Total der auszugleichenden Beträge stimmt nicht mit Zahlungseingang überein"));
                return;
            }

            // validate BelegDatum and BelegNr using db-functions
            bool isBelegDatumValid = Convert.ToBoolean(
                DBUtil.ExecuteScalarSQLThrowingException(
                    @"SELECT dbo.fnKbCheckBelegDatum({0}, {1})",
                    _kbPeriodeID,
                    qryZahlungseingang["Datum"]));

            if (!isBelegDatumValid)
            {
                // invalid BelegDatum
                edtDatum.Focus();
                throw new KissInfoException(
                    string.Format(
                        "Das eingegebene Beleg-Datum ist ungültig für das aktuelle Budget und die zugehörige Periode (ID={0}).",
                        _kbPeriodeID));
            }

            // Debitorenkonto bestimmen --> kontokorrentk: konto von kbzahlungseingang soll
            object kontokorrentKontoNr = qryZahlungseingang["KontoNr"];
            // haben: debitor konto von periode
            object debitorKontoNr =
                DBUtil.ExecuteScalarSQLThrowingException(
                    @"SELECT KontoNr FROM KbKonto WHERE REPLACE(REPLACE(',' + KbKontoartCodes + ',', ',', ','), ' ', ',') LIKE '%,20,%' AND KbPeriodeID = {0}",
                    _kbPeriodeID);

            // Buchungstext bestimmen
            object text = "Diverses";
            if (buchungIDs.Length == 1)
            {
                text = DBUtil.ExecuteScalarSQLThrowingException("SELECT Text FROM KbBuchung WHERE KbBuchungID = {0}", buchungIDs[0]);
            }

            Session.BeginTransaction();
            // hier darf kein Code stehen!
            try
            {
                // Gegenbuchung erstellen
                var ausgleichKbBuchungID = (int)DBUtil.ExecuteScalarSQLThrowingException(@"
                    INSERT INTO KbBuchung (KbPeriodeID, KbBuchungTypCode, KbBuchungStatusCode, KbZahlungseingangID, BelegDatum, ValutaDatum, SollKtoNr, HabenKtoNr, Betrag, Text, ErstelltUserID)
                        VALUES ({0}, 4, 2, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}) --KbBuchungTypCode 4: Ausgleich
                    SELECT CAST(SCOPE_IDENTITY() AS int)",
                    _kbPeriodeID,
                    qryZahlungseingang["KbZahlungseingangID"],
                    qryZahlungseingang["Datum"], //cka 29.04.2008: Gegenbuchung soll BelegDatum von Eingang erhalten! nicht: DateTime.Now,
                    DateTime.Now,             //cka 06.05.2008: Valutadatum wird eigentlich nicht verwendet; zur Info, wann Buchung erstellt wurde
                    kontokorrentKontoNr,
                    debitorKontoNr,
                    qryZahlungseingang["Betrag"],
                    text,
                    Session.User.UserID);

                qryZahlungseingang["KbBuchungID"] = ausgleichKbBuchungID;

                foreach (DataRow row in qryAusgleich.DataTable.Rows)
                {
                    var ausglBetrag = row["AusglBetrag"] as decimal?;
                    if (ausglBetrag.HasValue && ausglBetrag > 0m)
                    {
                        //##4108 pro OP-und Ausgleichbuchung nur noch ein Eintrag in KbOpAusgleich
                        DBUtil.ExecuteScalarSQLThrowingException(@"
                            DECLARE @KbOpAusgleichID INT
                            SET @KbOpAusgleichID = (SELECT KbOpAusgleichID
                                                    FROM dbo.KbOpAusgleich OPA
                                                    WHERE OPA.OpBuchungID = {0}
                                                      AND OPA.AusgleichBuchungID = {1})
                            IF @KbOpAusgleichID IS NOT NULL
                            BEGIN
                              UPDATE KbOpAusgleich
                                SET Betrag = Betrag + {2}
                              WHERE KbOpAusgleichID = @KbOpAusgleichID
                            END
                            ELSE BEGIN
                              INSERT INTO KbOpAusgleich (OpBuchungID, AusgleichBuchungID, Betrag)
                                VALUES ({0}, {1}, {2})
                            END

                            DECLARE @TotAusgleichBetrag MONEY
                            SELECT @TotAusgleichBetrag = SUM(Betrag)
                            FROM   KbOpAusgleich
                            WHERE  OpBuchungID = {0}

                            UPDATE KbBuchung
                              SET  KbBuchungStatusCode = CASE WHEN @TotAusgleichBetrag >= Betrag THEN 6 ELSE 10 END
                            WHERE  KbBuchungID = {0}",
                            row["KbBuchungID"],
                            ausgleichKbBuchungID,
                            row["AusglBetrag"]);
                    }
                }
                if (!qryZahlungseingang.Post())
                {
                    throw new Exception("Zahlungseingang konnte nicht verändert werden");
                }
                Session.Commit();
                // hier darf kein Code stehen!
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
            }
            KissMsg.ShowInfo(KissMsg.GetMLMessage("CtlKbZahlungseingang", "AugleichErfolgreich", "Der Ausgleich wurde erfolgreich gespeichert"));

            int nextKbZahlungseingangID = 0;
            try
            {
                int nextRowHandle = grvZahlungseingang.GetNextVisibleRow(grvZahlungseingang.FocusedRowHandle);
                if (nextRowHandle != GridControl.InvalidRowHandle)
                {
                    nextKbZahlungseingangID = (int)grvZahlungseingang.GetRowCellValue(nextRowHandle, "KbZahlungseingangID");
                }
            }
            catch (Exception ex2)
            {
                KissMsg.ShowError("Positionierung auf nächsten Zahlungseingang\r\n\r\n" + ex2.Message);
            }

            qryZahlungseingang.Refresh();
            qryZahlungseingang.Find("KbZahlungseingangID = " + nextKbZahlungseingangID);
        }

        private void btnSelektieren_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in qryZahlungseingang.DataTable.Rows)
            {
                if (!(bool)row["AusgleichVerbucht"])
                {
                    row["selektiert"] = true;
                }
            }
        }

        private void btnVerbuchen_Click(object sender, EventArgs e)
        {
            // --- wenn zahlungseingang nicht gespeichert werden konnte, nicht weiterverabeiten
            if (!qryZahlungseingang.Post())
            {
                return;
            }

            foreach (var row in qryZahlungseingang.DataTable.Rows.Cast<DataRow>().Where(row => (bool)row["selektiert"] && (bool)row["Beglichen"]))
            {
                if (_alimentenvermittlungAuszahlen &&
                    !IsGlaeubigerAuszahlungAktivNichtGestoppt((int)row[DBO.KbZahlungseingang.KbZahlungseingangID]))
                {
                    KissMsg.ShowInfo(
                        Name,
                        "GlaeubigerAuszahlungNichtAktiv_v01",
                        "Der Zahlungseingang kann nicht verbucht werden." + Environment.NewLine +
                        "Auszahlbelege können nicht erstellt werden, da die Auszahlung des Gläubigers nicht aktiv ist." + Environment.NewLine +
                        "  Datum:\t{0}" + Environment.NewLine +
                        "  Betrag:\t{1}" + Environment.NewLine +
                        "  Konto:\t{2}" + Environment.NewLine +
                        "  Klient:\t{3}" + Environment.NewLine +
                        "  BelegNr:\t{4}",
                        ((DateTime)row[DBO.KbZahlungseingang.Datum]).ToString("dd.MM.yyyy"),
                        ((decimal)row[DBO.KbZahlungseingang.Betrag]).ToString("N2"),
                        row[DBO.KbZahlungseingang.KontoNr],
                        row["Klient"],
                        row[DBO.KbBuchung.BelegNr]);
                }
                else
                {
                    FillQryAusgleiche(row);

                    Session.BeginTransaction();
                    // hier darf kein Code stehen!
                    try
                    {
                        // falls noch keine BelegNr gesetzt, diese erstellen
                        if (DBUtil.IsEmpty(row["BelegNr"]))
                        {
                            DBUtil.ExecuteScalarSQLThrowingException(@"
                                DECLARE @BelegNr  int
                                EXECUTE @BelegNr = spKbGetBelegNr {1}, 1, {2}, 1

                                DECLARE @KbBelegKreisID INT;
                                SELECT @KbBelegKreisID = KbBelegKreisID
                                FROM dbo.KbBelegKreis BLK WITH (READUNCOMMITTED)
                                WHERE KbPeriodeID = {1}
                                  AND KbBelegKreisCode = 1
                                  AND ISNULL(BLK.KontoNr, '') = ISNULL({2}, '');

                                UPDATE KbBuchung
                                  SET BelegNr = @BelegNr,
                                      KbBelegKreisID = @KbBelegKreisID
                                WHERE KbZahlungseingangID = {0}
                                  AND KbBuchungTypCode = 4",
                                row["KbZahlungseingangID"],
                                _kbPeriodeID,
                                row["KontoNr"]); //aktivkonto
                        }
                        //und sonst: bei allen Gegenbuchungen das Datum der Datum des Zahlungseingangs updaten (nach R.Hertig)
                        DBUtil.ExecuteScalarSQLThrowingException(@"
                                UPDATE KbBuchung
                                  SET BelegDatum = {1}
                                WHERE KbZahlungseingangID = {0} AND KbBuchungTypCode = 4",
                            row["KbZahlungseingangID"],
                            row["Datum"]);

                        foreach (DataRow buchung in qryAusgleich.DataTable.Rows)
                        {
                            DBUtil.ExecuteScalarSQLThrowingException(@"
                                    UPDATE KbBuchung
                                      SET BelegDatum = IsNull(BelegDatum, {2}),
                                          KbBuchungStatusCode = CASE WHEN {1} > $0.00 THEN 10 ELSE 6 END -- teil- / ausgeglichen
                                    WHERE KbBuchungID = {0}",
                                buchung["KbBuchungID"],
                                buchung["RestBetrag"],
                                row["Datum"]);

                            DBUtil.ExecuteScalarSQLThrowingException(@"
                                    DECLARE @KbBuchungKostenartID  int,
                                            @Betrag                money,
                                            @BetragRound           money,
                                            @Differenz             money

                                    SET @Differenz = $0.00

                                    DECLARE cKbBuchungKostenart CURSOR FAST_FORWARD FOR
                                      SELECT KbBuchungKostenartID, Betrag * {2} / {3}
                                      FROM KbBuchungKostenart
                                      WHERE KbBuchungID = {0}

                                    OPEN cKbBuchungKostenart
                                    WHILE (1 = 1) BEGIN
                                      FETCH NEXT FROM cKbBuchungKostenart INTO @KbBuchungKostenartID, @Betrag
                                      IF @@FETCH_STATUS < 0 BREAK

                                      SELECT
                                        @BetragRound = FLOOR((@Betrag + @Differenz) * 20.0 + 0.5) / 20.0,
                                        @Differenz   = @Differenz + @Betrag - @BetragRound

                                      INSERT INTO KbBuchungKostenart (KbBuchungID, BgKostenartID, Buchungstext, Betrag, BaPersonID, KbKostenstelleID, VerwPeriodeVon, VerwPeriodeBis, BgSplittingArtCode, Weiterverrechenbar, Quoting)
                                        SELECT {1}, BgKostenartID, Buchungstext, @BetragRound, BaPersonID, KbKostenstelleID, VerwPeriodeVon, VerwPeriodeBis, BgSplittingArtCode, Weiterverrechenbar, Quoting
                                        FROM KbBuchungKostenart
                                        WHERE KbBuchungKostenartID = @KbBuchungKostenartID

                                      SELECT @KbBuchungKostenartID = SCOPE_IDENTITY()
                                    END
                                    CLOSE cKbBuchungKostenart
                                    DEALLOCATE cKbBuchungKostenart

                                    UPDATE KbBuchungKostenart
                                      SET Betrag = FLOOR((Betrag + @Differenz) * 100.0 + 0.5) / 100.0
                                    WHERE @KbBuchungKostenartID = KbBuchungKostenartID AND @Differenz <> $0.00",
                                buchung["KbBuchungID"],
                                row["KbBuchungID"],
                                buchung["AusglBetrag"],
                                buchung["Betrag"]);
                        }

                        // Konsistenzprüfung: ist die Summe der Detailbeträge gleich dem Kopfbetrag?
                        // Sobald ein entsprechender Constraint auf der DB eingerichtet ist, kann dieser Abschnitt entfernt werden
                        decimal diff = (decimal)DBUtil.ExecuteScalarSQLThrowingException(@"
                                SELECT KBU.Betrag - SUM(KBK.Betrag)
                                FROM KbBuchungKostenart KBK
                                  INNER JOIN KbBuchung  KBU ON KBU.KbBuchungID = KBK.KbBuchungID
                                WHERE KBU.KbBuchungID = {0}
                                GROUP BY KBU.Betrag",
                            row["KbBuchungID"]);
                        if (diff != decimal.Zero)
                        {
                            throw new KissErrorException("Buchung ist inkonsistent, die Summe der Detailbeträge entspricht nicht dem Betrag der Buchung. Deshalb kann sie nicht verbucht werden.", string.Format("Differenz = {0}", diff), null);
                        }

                        DBUtil.ExecuteScalarSQLThrowingException(@"
                                UPDATE KbBuchung
                                  SET KbBuchungStatusCode = 6
                                WHERE KbZahlungseingangID = {0} AND KbBuchungTypCode = 4

                                UPDATE KbZahlungseingang
                                  SET Ausgeglichen = 1
                                WHERE KbZahlungseingangID = {0}",
                        row["KbZahlungseingangID"]);

                        // für vermittelte Forderungen, automatisch eine Auszahlung erstellen
                        if (_alimentenvermittlungAuszahlen)
                        {
                            AuszahlungAlimentenvermittlungErstellen((int)row[DBO.KbZahlungseingang.KbZahlungseingangID]);
                        }

                        Session.Commit();
                        // hier darf kein Code stehen!
                    }
                    catch (Exception ex)
                    {
                        // catch über alle Typen von Exceptions muss immer vorhanden sein!
                        // hier darf kein Code stehen!
                        // Reihenfolge darf hier nicht vertauscht werden!
                        Session.Rollback();
                        KissMsg.ShowInfo(ex.Message);
                    }
                }
            }

            qryZahlungseingang.Refresh();
        }

        private void CtlKbZahlungseingang_Load(object sender, EventArgs e)
        {
            _kbPeriodeID = Utils.ConvertToInt(FormController.GetMessage("FrmKbKlientenbuchhaltung", false, "Action", "KbPeriodeID"));
            SetKbPeriodeIDIfBaPersonIDHasValue();

            kissSearch.SelectParameters = new object[] { _kbPeriodeID, _baPersonID, Session.User.UserID };

            repositoryItemTextEdit1.EditValueChanging += repositoryItemTextEdit1_EditValueChanging;

            btnAusgleichAufheben.Location = btnAusgleichSpeichern.Location;
            tabDetails.SelectedTabIndex = 0;
            //hack für's Summenfeld --> im after fill wieder gesetzt
            grdZahlungsingang.DataSource = null;

            qryZahlungseingang.EnableBoundFields(false);

            kissSearch.OnRunSearch();

            btnVerbuchen.Enabled = DBUtil.UserHasRight("CtlKbZahlungseingang_BelegeVerbuchen");
            InitIfBaPersonIDHasValue();

            _alimentenvermittlungAuszahlen = DBUtil.GetConfigBool(@"System\KliBu\AlimentenvermittlungAuszahlen", false);

            SetupGrid();
        }

        private void edtBaInstitutionIDX_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = Utils.ConvertToString(edtBaInstitutionIDX.Text).Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    KissMsg.ShowInfo("Bitte zuerst einen Suchbegriff eingeben!");
                }
                else
                {
                    edtBaInstitutionIDX.EditValue = DBNull.Value;
                    edtBaInstitutionIDX.LookupID = DBNull.Value;
                    return;
                }
                return;
            }

            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                SELECT BaInstitutionID$ = INS.BaInstitutionID,
                        [Inst.-Nr]       = INS.BaInstitutionID,
                        Institution      = INS.Name,
                        Adresse          = INS.Adresse
                FROM   vwInstitution INS
                WHERE  INS.BaFreigabeStatusCode = 2 AND
                        INS.Name like '%' + {0} + '%'
                ORDER BY INS.Name",
                searchString,
                e.ButtonClicked);

            if (!e.Cancel)
            {
                edtBaInstitutionIDX.EditValue = dlg["Institution"];
                edtBaInstitutionIDX.LookupID = dlg["BaInstitutionID$"];
            }
        }

        private void edtInstitution_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtInstitution.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    KissMsg.ShowInfo("Es kann nicht der ganze Institutionenstamm angezeigt werden. Bitte Suchbegriff eingeben!");
                }
                else
                {
                    qryZahlungseingang["BaInstitutionID"] = DBNull.Value;
                    qryZahlungseingang["Debitor"] = DBNull.Value;
                }
                return;
            }

            var dlg = new DlgAuswahl();
            e.Cancel = !dlg.InstitutionSuchenWh(searchString, e.ButtonClicked);

            if (!e.Cancel)
            {
                qryZahlungseingang["BaInstitutionID"] = dlg["ID$"];
                qryZahlungseingang["Institution"] = dlg["Institution"];
                qryZahlungseingang["Debitor"] = dlg["Institution"] + ", " + dlg["Adresse"];
            }
        }

        private void edtKlient_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtKlient.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (!e.ButtonClicked)
                {
                    qryZahlungseingang["BaPersonID"] = DBNull.Value;
                    qryZahlungseingang["Klient"] = DBNull.Value;
                }
                return;
            }

            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                SELECT distinct BaPersonID$  = PRS.BaPersonID,
                        [Pers.-Nr]   = PRS.BaPersonID,
                        Name         = PRS.Name,
                        Vorname      = PRS.Vorname,
                        Wohnsitz     = PRS.Wohnsitz,
                        Klient$      = PRS.NameVorname
                FROM   vwPerson PRS
                        inner join FaLeistung LEI on LEI.BaPersonID = PRS.BaPersonID
                WHERE  PRS.NameVorname like '%' + {0} + '%'
                ORDER BY PRS.NameVorname",
                searchString,
                e.ButtonClicked);

            if (!e.Cancel)
            {
                qryZahlungseingang["BaPersonID"] = dlg["BaPersonID$"];
                qryZahlungseingang["Klient"] = dlg["Klient$"];
                FillQryAusgleiche();
            }
        }

        private void edtKontoNrBisX_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            // prepare search string
            string searchString = "";

            // check if we have a value to parse
            if (!DBUtil.IsEmpty(edtKontoNrBisX.EditValue))
            {
                // prepare for database search
                searchString = edtKontoNrBisX.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%").Replace("'", "''");
            }

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    return;
                }
            }

            var dlg = new KissLookupDialog();

            e.Cancel = !dlg.SearchData(@"
                SELECT KbKontoID$  = KTO.KbKontoID,
                       Mandant = dbo.fnGetMLTextByDefault(MND.MandantTID, {2}, MND.Mandant),
                       [Konto-Nr.] = KTO.KontoNr,
                       Name        = KTO.KontoName,
                       KontoNr$    = KTO.KontoNr
                FROM dbo.KbKonto KTO
                  INNER JOIN dbo.KbPeriode PRD ON KTO.KbPeriodeID = PRD.KbPeriodeID
                  INNER JOIN dbo.KbMandant MND ON MND.KbMandantID = PRD.KbMandantID
                WHERE KTO.KbPeriodeID = {1}
                  AND KTO.KontoGruppe = 0
                  AND ((',' + KbKontoartCodes + ',') LIKE ('%,40,%')
                    OR (',' + KbKontoartCodes + ',') LIKE ('%,50,%'))
                  AND KTO.KontoNr + KTO.KontoName LIKE '%' + {0} + '%'
                ORDER BY KTO.KontoNr;",
                searchString,
                e.ButtonClicked,
                _kbPeriodeID,
                Session.User.LanguageCode);

            if (!e.Cancel)
            {
                edtKontoNrBisX.EditValue = dlg["KontoNr$"];
            }
        }

        private void edtKontoNrVonX_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            // prepare search string
            string searchString = "";

            // check if we have a value to parse
            if (!DBUtil.IsEmpty(edtKontoNrVonX.EditValue))
            {
                // prepare for database search
                searchString = edtKontoNrVonX.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%").Replace("'", "''");
            }

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    return;
                }
            }

            var dlg = new KissLookupDialog();

            e.Cancel = !dlg.SearchData(@"
                SELECT KbKontoID$  = KTO.KbKontoID,
                       Mandant = dbo.fnGetMLTextByDefault(MND.MandantTID, {2}, MND.Mandant),
                       [Konto-Nr.] = KTO.KontoNr,
                       Name        = KTO.KontoName,
                       KontoNr$    = KTO.KontoNr
                FROM dbo.KbKonto KTO
                  INNER JOIN dbo.KbPeriode PRD ON KTO.KbPeriodeID = PRD.KbPeriodeID
                  INNER JOIN dbo.KbMandant MND ON MND.KbMandantID = PRD.KbMandantID
                WHERE KTO.KbPeriodeID = {1}
                  AND KTO.KontoGruppe = 0
                  AND ((',' + KbKontoartCodes + ',') LIKE ('%,40,%')
                    OR (',' + KbKontoartCodes + ',') LIKE ('%,50,%'))
                  AND KTO.KontoNr + KTO.KontoName LIKE '%' + {0} + '%'
                ORDER BY KTO.KontoNr",
                searchString,
                e.ButtonClicked,
                _kbPeriodeID,
                Session.User.LanguageCode);

            if (!e.Cancel)
            {
                edtKontoNrVonX.EditValue = dlg["KontoNr$"];
            }
        }

        private void edtKontoZahlung_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtKontoZahlung.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (!e.ButtonClicked)
                {
                    qryZahlungseingang["KontoNr"] = DBNull.Value;
                    qryZahlungseingang["Konto"] = DBNull.Value;
                }
                return;
            }

            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                SELECT KbKontoID$  = KTO.KbKontoID,
                       Mandant = dbo.fnGetMLTextByDefault(MND.MandantTID, {2}, MND.Mandant),
                       [Konto-Nr.] = KTO.KontoNr,
                       Name        = KTO.KontoName,
                       Konto$      = KTO.KontoNr + ' ' + KTO.KontoName
                FROM dbo.KbKonto       KTO
                  INNER JOIN dbo.KbPeriode PRD ON KTO.KbPeriodeID = PRD.KbPeriodeID
                  INNER JOIN dbo.KbMandant MND ON MND.KbMandantID = PRD.KbMandantID
                WHERE KTO.KbPeriodeID = {1}
                  AND KTO.KontoGruppe = 0
                  AND ((',' + KbKontoartCodes + ',') LIKE ('%,40,%')
                    OR (',' + KbKontoartCodes + ',') LIKE ('%,50,%'))
                  AND KTO.KontoNr + KTO.KontoName LIKE '%' + {0} + '%'
                ORDER BY KTO.KontoNr",
                searchString,
                e.ButtonClicked,
                _kbPeriodeID,
                Session.User.LanguageCode);

            if (!e.Cancel)
            {
                qryZahlungseingang["KontoNr"] = dlg["Konto-Nr."];
                qryZahlungseingang["Konto"] = dlg["Konto$"];
            }
        }

        private void edtZugeteiltUserID_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtZugeteiltUserID.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (!e.ButtonClicked)
                {
                    qryZahlungseingang["ZugeteiltUserID"] = DBNull.Value;
                    qryZahlungseingang["SAR"] = DBNull.Value;
                }
                return;
            }

            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                SELECT UserID$      = USR.UserID,
                       SAR$         = USR.NameVorname,
                       LogonName    = USR.LogonName,
                       Name         = USR.LastName,
                       Vorname      = USR.FirstName,
                       Organisation = USR.OrgUnit
                FROM dbo.vwUser USR
                WHERE USR.NameVorname LIKE '%' + {0} + '%' OR LogonName LIKE '%' + {0} + '%' OR ShortName LIKE '%' + {0} + '%'
                ORDER BY USR.NameVorname",
                searchString,
                e.ButtonClicked);

            if (!e.Cancel)
            {
                qryZahlungseingang["ZugeteiltUserID"] = dlg["UserID$"];
                qryZahlungseingang["SAR"] = dlg["SAR$"];
            }
        }

        private void qryAusgleich_PositionChanged(object sender, EventArgs e)
        {
            if (!(bool)qryZahlungseingang["Ausgeglichen"])
            {
                UpdateSum();
            }
        }

        private void qryZahlungseingang_AfterFill(object sender, EventArgs e)
        {
            grdZahlungsingang.DataSource = qryZahlungseingang;
        }

        private void qryZahlungseingang_AfterInsert(object sender, EventArgs e)
        {
            qryZahlungseingang[colAusgeglichen.FieldName] = false;
            qryZahlungseingang["selektiert"] = false;
            qryZahlungseingang["AusgleichVerbucht"] = false;

            SetFieldsIfBaPersonIDHasValue();

            edtDatum.Focus();
        }

        private void qryZahlungseingang_AfterPost(object sender, EventArgs e)
        {
            tpgAusgleich.HideTab = DBUtil.IsEmpty(qryZahlungseingang["BaPersonID"]);
            FillQryAusgleiche();
        }

        private void qryZahlungseingang_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            if ((bool)qryZahlungseingang["Ausgeglichen"])
            {
                throw new KissInfoException("Eine ausgeglichene Zahlung kann nicht gelöscht werden!");
            }
        }

        private void qryZahlungseingang_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtDatum, lblDatum.Text);
            DBUtil.CheckNotNullField(edtBetrag, lblBetrag.Text);
            DBUtil.CheckNotNullField(edtKontoZahlung, lblKontoZahlung.Text);
        }

        private void qryZahlungseingang_PositionChanged(object sender, EventArgs e)
        {
            qryZahlungseingang.EnableBoundFields(DBUtil.IsEmpty(qryZahlungseingang["Beglichen"]) || !(bool)qryZahlungseingang["Beglichen"]);
            // BSS Wunsch, Eingangsdatum soll ständig verändert werden können Mantis 3101. --> Aber nicht wenn der ZE definitiv verbucht ist (#6700, #7011)
            if (!(bool)qryZahlungseingang["AusgleichVerbucht"])
            {
                edtDatum.EditMode = EditModeType.Normal;
            }

            tpgAusgleich.HideTab = (qryZahlungseingang.Row.RowState == DataRowState.Added)
                                   || DBUtil.IsEmpty(qryZahlungseingang["BaPersonID"]);
            FillQryAusgleiche();

            //Ik-Ausgleiche dürfen nicht in der KliBu aufgehoben werden
            btnAusgleichAufheben.Enabled = DBUtil.IsEmpty(qryAusgleich["IkPositionID"]) && !(bool)qryZahlungseingang["AusgleichVerbucht"];
        }

        private void repositoryItemCheckEdit1_Click(object sender, EventArgs e)
        {
            if ((bool)qryZahlungseingang["AusgleichVerbucht"])
            {
                KissMsg.ShowInfo("CtlKbZahlungseingang", "AusgleichVerbucht", "Dieser Zahlungseingang wurde bereits verbucht!");
                qryZahlungseingang["selektiert"] = 0;
            }
        }

        private void repositoryItemTextEdit1_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if ((bool)qryZahlungseingang["Ausgeglichen"])
            {
                return;
            }

            qryAusgleich["AusglBetrag"] = e.NewValue;
            UpdateSum();
        }

        private void SetupGrid()
        {
            if (GuiConfig.Theme == GuiConfig.KissTheme.KissBlue)
            {
                grdZahlungsingang.SetColumnEditable(colDatum2, false);
                grdZahlungsingang.SetColumnEditable(colBetrag, false);
                grdZahlungsingang.SetColumnEditable(colKonto, false);
                grdZahlungsingang.SetColumnEditable(colDebitor, false);
                grdZahlungsingang.SetColumnEditable(colKlient, false);
                grdZahlungsingang.SetColumnEditable(colZuteilungSAR, false);
                grdZahlungsingang.SetColumnEditable(colBelegNr, false);
                grdZahlungsingang.SetColumnEditable(colAusgeglichen, false);
                grdZahlungsingang.SetColumnEditable(colVerbucht, false);
                grdZahlungsingang.SetColumnEditable(colEingangSelektiert, true);
                grdZahlungsingang.SetSelectionColor(false);

                grdAusgleich.SetColumnEditable(colBudgetMonatJahr, false);
                grdAusgleich.SetColumnEditable(colDatum, false);
                grdAusgleich.SetColumnEditable(colHaben, false);
                grdAusgleich.SetColumnEditable(colDebitor3, false);
                grdAusgleich.SetColumnEditable(colKostenstelle, false);
                grdAusgleich.SetColumnEditable(colText, false);
                grdAusgleich.SetColumnEditable(colTotalbetrag, false);
                grdAusgleich.SetColumnEditable(colRestbetrag, false);
                grdAusgleich.SetColumnEditable(colAusgleich, false, true);
                grdAusgleich.SetColumnEditable(colAusgleichBetrag, true);
            }
        }

        #endregion EventHandlers

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();
            edtNurUnverbuchtX.Checked = true;
            edtDatumVonX.Focus();
        }

        #endregion Protected Methods

        #region Private Static Methods

        private static bool IsGlaeubigerAuszahlungAktivNichtGestoppt(int kbZahlungseingangId)
        {
            return DBUtil.ExecuteScalarSQLThrowingException(@"
                IF NOT EXISTS(SELECT GLB.Aktiv
                              FROM dbo.KbBuchung                       BUCA WITH (READUNCOMMITTED) -- Ausgleichsbuchung
                                INNER JOIN dbo.KbOpAusgleich           OPA  WITH (READUNCOMMITTED)
                                                                            ON OPA.AusgleichBuchungID = BUCA.KbBuchungID
                                INNER JOIN dbo.KbBuchung               BUC  WITH (READUNCOMMITTED)
                                                                            ON BUC.KbBuchungID = OPA.OpBuchungID
                                INNER JOIN dbo.KbBuchungKostenart      BKO  WITH (READUNCOMMITTED)
                                                                            ON BKO.KbBuchungID = BUC.KbBuchungID
                                INNER JOIN dbo.IkPosition              IPO  WITH (READUNCOMMITTED)
                                                                            ON IPO.IkPositionID = BUC.IkPositionID
                                LEFT  JOIN dbo.IkRechtstitel           RTT  WITH (READUNCOMMITTED)
                                                                            ON RTT.IkRechtstitelID = IPO.IkRechtstitelID
                                LEFT  JOIN dbo.FaLeistung              LEI  WITH (READUNCOMMITTED)
                                                                            ON LEI.FaLeistungID = IPO.FaLeistungID
                                INNER JOIN dbo.IkGlaeubiger            GLB  WITH (READUNCOMMITTED)
                                                                            ON (GLB.IkRechtstitelID = RTT.IkRechtstitelID OR GLB.FaLeistungID = LEI.FaLeistungID)
                                                                           AND GLB.BaPersonID = IPO.BaPersonID
                                                                           AND NOT (GLB.Aktiv = 1 AND GLB.AuszahlungVermittlungStoppen = 0
                                                                             OR GLB.Aktiv = 0 AND GLB.AuszahlungVermittlungStoppen = 1)

                                OUTER APPLY (SELECT IkForderungPeriodischCode
                                             FROM dbo.fnIkForderung(IPO.IkPositionID, BKO.KbForderungArtCode)
                                             WHERE Unterstuetzungsfall = 0) FRD

                                INNER JOIN dbo.IkForderung_BgKostenart FKA  WITH (READUNCOMMITTED)
                                                                            ON FKA.BgKostenartID_Forderung = BKO.BgKostenartID
                                                                           AND ((IPO.Einmalig = 0 AND FKA.IkForderungPeriodischCode = FRD.IkForderungPeriodischCode)
                                                                            OR (IPO.Einmalig = 1 AND FKA.IkForderungEinmaligCode = IPO.IkForderungCode AND FKA.IkForderungEinmaligCode != 2)) -- einmalige Kinderalimente (Bevorschussung) nicht berücksichtigen
                                LEFT  JOIN dbo.KbForderungAuszahlung   AUS  WITH (READUNCOMMITTED)
                                                                            ON AUS.KbBuchungID_Forderung = OPA.OpBuchungID
                                LEFT  JOIN dbo.KbBuchung               BUCZ WITH (READUNCOMMITTED)
                                                                            ON BUCZ.KbBuchungID = AUS.KbBuchungID_Auszahlung
                                LEFT  JOIN dbo.KbBuchungKostenart      BKOZ WITH (READUNCOMMITTED)
                                                                            ON BKOZ.KbBuchungID = BUCZ.KbBuchungID
                              WHERE BUCA.KbZahlungseingangID = {0}
                                -- ALBV-Forderung nich berücksichtigen (Bevorschussung sind bereits ausbezahlt)
                                AND (BKOZ.KbForderungArtCode IS NULL OR BKOZ.KbForderungArtCode <> 10))
                BEGIN
                  -- Gläubiger ist aktiv oder Auszahlung von Vermittlungen ist gestoppt
                  SELECT CONVERT(BIT, 1);
                END
                ELSE
                BEGIN
                  -- Gläubiger ist inaktiv und Auszahlung von Vermittlungen ist nicht gestoppt
                  SELECT CONVERT(BIT, 0);
                END;",
                kbZahlungseingangId) as bool? ?? true;
        }

        #endregion Private Static Methods

        #region Private Methods

        private void AuszahlungAlimentenvermittlungErstellen(int kbZahlungseingangId)
        {
            DBUtil.ExecSQLThrowingException(@"EXEC dbo.spKbAuszahlungAlimentenvermittlungErstellen {0}, {1}, {2};", kbZahlungseingangId, _kbPeriodeID, Session.User.UserID);
        }

        private void FillQryAusgleiche()
        {
            FillQryAusgleiche(qryZahlungseingang.Row);
        }

        private void FillQryAusgleiche(DataRow row)
        {
            //if((bool)qryZahlungseingang["AusgleichVerbucht"])
            if (!DBUtil.IsEmpty(row["Beglichen"]) && (bool)row["Beglichen"])
            {
                qryAusgleich.Fill(@"
                    --alle bereits zugewiesenen Posten
                    SELECT
                       KbBuchungID         = BUC2.KbBuchungID,
                       Valuta              = BUC2.ValutaDatum,
                       Haben               = 'div', --KOA.KontoNr, -- ,  -- KreditorKonto ?!?
                       Soll                = BUC2.SollKtoNr,    -- DebitorKonto  ?!?
                       Text                = BUC2.Text, --KOA.Buchungstext,
                       Betrag              = BUC2.Betrag,--KOA.Betrag,
                       RestBetrag          = (SELECT BUC2.Betrag - SUM(Betrag)
                                              FROM KbOpAusgleich
                                              WHERE OPBuchungID = AUS.OpBuchungID),
                       AusglBetrag         = AUS.Betrag,
                       ObBuchungID         = AUS.OpBuchungID,
                       AusgleichBuchungID  = AUS.AusgleichBuchungID,
                       SortKey             = 1,
                       Debitor             = ISNULL(DBP.VornameName + ISNULL(', ' + DBP.Wohnsitz, ''), DBI.Name + ISNULL(', ' + DBI.Adresse, '')),
                       KbPeriodeID         = BUC.KbPeriodeID,
                       KbBuchungStatusCode = BUC.KbBuchungStatusCode,
                       IkPositionID        = BUC2.IkPositionID
                    FROM dbo.KbZahlungseingang          ZEI
                      INNER JOIN dbo.KbBuchung          BUC  ON BUC.KbZahlungseingangID = ZEI.KbZahlungseingangID
                      INNER JOIN dbo.KbOpAusgleich      AUS  ON AUS.AusgleichBuchungID = BUC.KbBuchungID
                      INNER JOIN dbo.KbBuchung          BUC2 ON BUC2.KbBuchungID = AUS.OpBuchungID
                      LEFT  JOIN dbo.vwInstitution      DBI  ON DBI.BaInstitutionID = BUC2.Schuldner_BaInstitutionID
                      LEFT  JOIN dbo.vwPerson           DBP  ON DBP.BaPersonID = BUC2.Schuldner_BaPersonID
                    WHERE ZEI.KbZahlungseingangID = {0}
                    ORDER BY SortKey, Valuta",
                    row["KbZahlungseingangID"]);

                grdAusgleich.GridStyle = GridStyleType.ReadOnly;
                edtRestbetrag.Visible = false;
                lblAusgleichRestbetrag.Visible = false;
                colAusgleich.VisibleIndex = -1;
                btnAusgleichSpeichern.Visible = false;
                btnAusgleichAufheben.Visible = true;
            }
            else
            {
                qryAusgleich.Fill(@"
                    --alle offenen Posten dieses Klienten
                    SELECT
                       KbBuchungID         = BUC.KbBuchungID,
                       Valuta              = BUC.ValutaDatum,
                       Haben               = KOS.KontoNr,
                       Soll                = BUC.SollKtoNr,
                       Monat               = BDG.Monat,
                       Jahr                = BDG.Jahr,
                       BudgetMonatJahr     = CONVERT(VARCHAR, ISNULL(BDG.Jahr, '')) + '.' + RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR, ISNULL(BDG.Monat, '')), 2),
                       VerwPeriodeVon      = BPO.VerwPeriodeVon,
                       VerwPeriodeBis      = BPO.VerwPeriodeBis,
                       Text                = KOS.Buchungstext, --BUC.Text,
                       Betrag              = KOS.Betrag,
                       RestBetrag          = ISNULL((SELECT KOS.Betrag - SUM(Betrag)
                                                     FROM KbOpAusgleich
                                                     WHERE OPBuchungID = BUC.KbBuchungID), KOS.Betrag),
                       AusglBetrag         = CONVERT(MONEY, NULL),
                       KbZahlungseingangID = NULL,
                       SortKey             = 0,
                       ausgeglichen        = CONVERT(BIT, 0),
                       KbBuchungID         = BUC.KbBuchungID,
                       KbOpAusgleichID     = NULL,
                       Debitor             = ISNULL(DBP.VornameName + ISNULL(', ' + DBP.Wohnsitz, ''), DBI.Name + ISNULL(', ' + DBI.Adresse, '')),
                       KbPeriodeID         = BUC.KbPeriodeID,
                       KbBuchungStatusCode = BUC.KbBuchungStatusCode,
                       Kostenstelle        = dbo.fnKbGetKostenstelle(KST.BaPersonID),
                       IkPositionID        = BUC.IkPositionID
                    FROM dbo.KbBuchung                       BUC
                      LEFT  JOIN dbo.vwInstitution           DBI ON DBI.BaInstitutionID = BUC.Schuldner_BaInstitutionID
                      LEFT  JOIN dbo.vwPerson                DBP ON DBP.BaPersonID = BUC.Schuldner_BaPersonID
                      INNER JOIN dbo.KbBuchungKostenart      KOS ON KOS.KbBuchungID = BUC.KbBuchungID
                      INNER JOIN dbo.BgPosition              BPO ON BPO.BgPositionID = KOS.BgPositionID
                      INNER JOIN dbo.BgBudget                BDG ON BDG.BgBudgetID = BUC.BgBudgetID
                      INNER JOIN dbo.BgFinanzplan            FPP ON FPP.BgFinanzplanID = BDG.BgFinanzplanID
                      INNER JOIN dbo.FaLeistung              LST ON LST.FaLeistungID = FPP.FaLeistungID
                      INNER JOIN dbo.KbKostenstelle_BaPerson KST ON KST.KbKostenstelleID = KOS.KbKostenstelleID
                                                                AND (KST.DatumBis IS NULL
                                                                  OR GETDATE() BETWEEN KST.DatumVon AND KST.DatumBis)
                    WHERE LST.BaPersonID = {1}
                      AND BPO.BgKategorieCode = 1            -- Einnahmen
                      AND BUC.KbBuchungStatusCode IN (2, 10) -- offen, teilausgeglichen
                      AND (BUC.KbZahlungseingangID <> {0}
                        OR BUC.KbZahlungseingangID IS NULL)",
                    row["KbZahlungseingangID"],
                    row["BaPersonID"]);

                grdAusgleich.GridStyle = GridStyleType.Editable;
                colAusgleich.VisibleIndex = 6;
                edtRestbetrag.Visible = true;
                lblAusgleichRestbetrag.Visible = true;
                btnAusgleichSpeichern.Visible = true;
                btnAusgleichAufheben.Visible = false;
                UpdateSum();
            }
        }

        private void InitIfBaPersonIDHasValue()
        {
            if (_baPersonID.HasValue)
            {
                edtZugeteiltUserID.EditMode = EditModeType.ReadOnly;
                edtKlient.EditMode = EditModeType.ReadOnly;
                btnSelektieren.Enabled = false;
                btnVerbuchen.Enabled = false;
            }
        }

        private void SetFieldsIfBaPersonIDHasValue()
        {
            if (_baPersonID.HasValue)
            {
                qryZahlungseingang["ZugeteiltUserID"] = Session.User.UserID;
                qryZahlungseingang["SAR"] = Session.User.LastFirstName;
                qryZahlungseingang["BaPersonID"] = _baPersonID;
                qryZahlungseingang["Klient"] = _baPersonNameVorname;
            }
        }

        private void SetKbPeriodeIDIfBaPersonIDHasValue()
        {
            if (_baPersonID.HasValue)
            {
                _kbPeriodeID = (int)DBUtil.ExecuteScalarSQLThrowingException(
                    "SELECT dbo.fnKbGetPeriodeIDByDate(1, {0}, NULL, 1)",
                    DateTime.Now.ToString("yyyyMMdd"));
            }
        }

        private int[] UpdateSum()
        {
            qryAusgleich.EndCurrentEdit();
            var buchungIDs = new List<int>();
            decimal summe = decimal.Zero;
            foreach (DataRow row in qryAusgleich.DataTable.Rows)
            {
                var ausglBetrag = row["AusglBetrag"] as decimal?;
                if (ausglBetrag.HasValue)
                {
                    if (ausglBetrag.Value < 0m)
                    {
                        row["AusglBetrag"] = 0m;
                        ausglBetrag = 0m;
                    }
                    summe += ausglBetrag.Value;
                    if (ausglBetrag.Value > 0m)
                    {
                        buchungIDs.Add((int)row["KbBuchungID"]);
                    }
                }
            }

            var betragSoll = qryZahlungseingang["Betrag"] as decimal?;
            if (!betragSoll.HasValue)
            {
                betragSoll = 0m;
            }

            edtRestbetrag.EditValue = betragSoll - summe;
            if (betragSoll == summe)
            {
                btnAusgleichSpeichern.Enabled = !(bool)qryZahlungseingang["Ausgeglichen"];
                edtRestbetrag.BackColor = _clrGreen;
            }
            else
            {
                btnAusgleichSpeichern.Enabled = false;
                edtRestbetrag.BackColor = _clrRed;
            }

            return buchungIDs.ToArray();
        }

        #endregion Private Methods

        #endregion Methods
    }
}