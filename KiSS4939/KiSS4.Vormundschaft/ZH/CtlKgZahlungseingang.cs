using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using Kiss.Infrastructure;
using Kiss.Interfaces.UI;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Vormundschaft.ZH
{
    public partial class CtlKgZahlungseingang : KissSearchUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly Color _clrGreen = Color.DarkSeaGreen;
        private readonly Color _clrRed = Color.Salmon;

        #endregion

        #region Private Fields

        private KgBuchungstext _buchungstextDebitor;
        private DataRow _saveRow;

        #endregion

        #endregion

        #region Constructors

        public CtlKgZahlungseingang()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void btnAusgleich_Click(object sender, EventArgs e)
        {
            int[] kgBuchungIDs = UpdateAusgleichSum();

            if (!btnAusgleich.Enabled)
            {
                KissMsg.ShowInfo(KissMsg.GetMLMessage("CtlKgZahlungseingang", "AusgleichNichtMöglich", "Ausgleich nicht möglich: Total der auszugleichenden Beträge stimmt nicht mit Zahlungseingang überein"));
                return;
            }

            try
            {
                Session.BeginTransaction();

                //Prüfen, ob es eine aktive Periode gibt.
                int? kgPeriodeID = (int?)DBUtil.ExecuteScalarSQLThrowingException(@"
                    SELECT KgPeriodeID
                    FROM   dbo.KgPeriode PER WITH (READUNCOMMITTED)
                           INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = PER.FaLeistungID
                    WHERE  LEI.BaPersonID = {0} AND
                           PER.KgPeriodeStatusCode = 1 /*aktiv*/ AND
                           PER.PeriodeVon <= {1} AND PER.PeriodeBis >= {1}", qryZahlungseingang["BaPersonID"], qryZahlungseingang["Datum"]);
                if (!kgPeriodeID.HasValue)
                {
                    Session.Rollback();
                    KissMsg.ShowError(KissMsg.GetMLMessage("CtlKgZahlungseingang", "KeineOffenePeriode", "Es existiert keine aktive Buchungsperiode für das Datum {0:dd.MM.yyyy}",
                            KissMsgCode.MsgError, qryZahlungseingang["Datum"]));
                    return;
                }

                //Prüfen, ob die Person für die aktive Periode ein Verkehrskonto hat.
                int? verkehrskontoId = (int?)DBUtil.ExecuteScalarSQLThrowingException(@"
                   SELECT KTO.KgKontoId
                   FROM KgKonto KTO
                     INNER JOIN KgPeriode PER ON PER.KgPeriodeId = KTO.KgPeriodeId
                     INNER JOIN FaLeistung LEI ON LEI.FaLeistungId = PER.FaLeistungId
                   WHERE
                      PER.KgPeriodeId = {0}
                      AND KTO.KgKontoartCode = 1;",
                   kgPeriodeID.Value);

                if (!verkehrskontoId.HasValue)
                {
                    Session.Rollback();
                    KissMsg.ShowError(KissMsg.GetMLMessage(
                        "CtlKgZahlungseingang",
                        "KeinVerkehrskonto",
                        "Der Ausgleich kann nicht gespeichert werden, da zurzeit kein Kontokorrentkonto im aktuellen Kontoplan des Mandanten definiert ist.\n Eventuell wird gerade ein Wechsel des Kontokorrentkontos (Verkehrskontos) vorgenommen.\n Bitte später nochmals versuchen oder durch einen berechtigten Klibu MA einrichten lassen.",
                        KissMsgCode.MsgError));
                    return;
                }

                // Debitorenkonto bestimmen
                object kontokorrentKontoNr = DBUtil.ExecuteScalarSQLThrowingException("SELECT KontoNr FROM dbo.KgKonto WITH (READUNCOMMITTED) WHERE KgKontoartCode = 1 AND KgPeriodeID = {0}", kgPeriodeID.Value);
                object debitorKontoNr = DBUtil.ExecuteScalarSQLThrowingException("SELECT KontoNr FROM dbo.KgKonto WITH (READUNCOMMITTED) WHERE KgKontoartCode = 2 AND KgPeriodeID = {0}", kgPeriodeID.Value);

                // Falls Restbetrag = Zahlungsbetrag: Direktbuchung ohne Debitor-Kto und OP-Ausgleich
                bool direkt = (edtRestbetrag.Value == (Decimal)qryZahlungseingang["Betrag"]);

                // Buchungstext bestimmen
                string text;

                if (!direkt)
                {
                    // Buchungstexte der OPs von DB lesen
                    string ids = string.Join(", ", (new List<int>(kgBuchungIDs)).ConvertAll(Convert.ToString).ToArray());
                    SqlQuery qryText = DBUtil.OpenSQL(string.Format(@"
                      SELECT [Text]
                      FROM dbo.KgBuchung WITH (READUNCOMMITTED)
                      WHERE KgBuchungID IN ({0})", ids));

                    // Buchungstexte der OPs zusammenstringen
                    List<string> texts = new List<string>();
                    foreach (DataRow row in qryText.DataTable.Rows)
                    {
                        string rowText = row["Text"] as string;

                        if (!string.IsNullOrWhiteSpace(rowText) && !texts.Contains(rowText))
                        {
                            texts.Add(rowText);
                        }
                    }

                    if (!DBUtil.IsEmpty(edtTextRestbetrag.EditValue))
                    {
                        // Addiere auch noch den Restbetrags-Text dazu
                        string restbetragText = edtTextRestbetrag.EditValue.ToString();
                        if (!string.IsNullOrWhiteSpace(restbetragText) && !texts.Contains(restbetragText))
                        {
                            texts.Add(restbetragText);
                        }
                    }

                    text = string.Join(", ", texts.ToArray());

                    if (!string.IsNullOrEmpty(text))
                    {
                        text = text.Substring(0, Math.Min(200, text.Length));
                    }
                }
                else
                {
                    text = edtTextRestbetrag.EditValue.ToString();
                }

                // KbBuchung für ganze Zahlung erstellen
                int ausgleichKgBuchungID = (int)DBUtil.ExecuteScalarSQLThrowingException(@"
                    INSERT INTO KgBuchung (KgPeriodeID, KgBuchungTypCode, KgZahlungseingangID, BuchungsDatum, ValutaDatum,
                                           SollKtoNr, HabenKtoNr, Betrag, Text, ErstelltDatum)
                    VALUES ({0}, 4, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8})
                    SELECT CAST(SCOPE_IDENTITY() AS int)",
                    kgPeriodeID.Value,
                    qryZahlungseingang["KgZahlungseingangID"],
                    qryZahlungseingang["Datum"],
                    qryZahlungseingang["Datum"],
                    kontokorrentKontoNr,
                    direkt ? edtKontoRestbetrag.LookupID : debitorKontoNr,
                    qryZahlungseingang["Betrag"],
                    text,
                    DateTime.Now);

                if (!direkt)
                {
                    foreach (DataRow row in qryAusgleich.DataTable.Rows)
                    {
                        decimal? ausglBetrag = row["AusglBetrag"] as decimal?;
                        if (ausglBetrag.HasValue && ausglBetrag > 0m)
                        {
                            DBUtil.ExecuteScalarSQLThrowingException(@"
                                INSERT INTO KgOpAusgleich (OpBuchungID, AusgleichBuchungID, Betrag)
                                    VALUES ({0},{1},{2})

                                DECLARE @TotAusgleichBetrag MONEY
                                SELECT @TotAusgleichBetrag = SUM(Betrag)
                                FROM   dbo.KgOpAusgleich WITH (READUNCOMMITTED)
                                WHERE  OpBuchungID = {0}

                                UPDATE KgBuchung
                                SET    KgBuchungStatusCode = CASE WHEN @TotAusgleichBetrag >= Betrag THEN 6 ELSE 10 END
                                WHERE  KgBuchungID = {0}",
                                row["KgBuchungID"], ausgleichKgBuchungID, row["AusglBetrag"]);
                        }
                    }

                    if (edtRestbetrag.Value != 0m)
                    {
                        // Restbetrag verbuchen
                        // Eintrag in KbBuchung hat keinen direkten link zur Zahlung, sondern nur via KbOpAusgleich)

                        //Betrag immer positiv: Soll/Haben vertauschen, falls Restbetrag negativ;
                        DBUtil.ExecuteScalarSQLThrowingException(@"
                            INSERT INTO KgBuchung (KgPeriodeID, KgBuchungTypCode, BuchungsDatum, ValutaDatum,
                                                   SollKtoNr, HabenKtoNr, Betrag, Text, ErstelltDatum)
                            VALUES ({0}, 5, {1}, {2}, {3}, {4}, {5}, {6}, {7})  -- Code 5: RestAusgleich

                            INSERT INTO KgOpAusgleich (OpBuchungID, AusgleichBuchungID, Betrag)
                            VALUES (SCOPE_IDENTITY(),{8},{5})",
                            kgPeriodeID.Value,
                            qryZahlungseingang["Datum"],
                            qryZahlungseingang["Datum"],
                            (edtRestbetrag.Value > 0m) ? debitorKontoNr : edtKontoRestbetrag.LookupID,
                            (edtRestbetrag.Value > 0m) ? edtKontoRestbetrag.LookupID : debitorKontoNr,
                            Math.Abs(edtRestbetrag.Value),
                            edtTextRestbetrag.EditValue,
                            DateTime.Now,
                            ausgleichKgBuchungID);
                    }
                }

                qryZahlungseingang["Ausgeglichen"] = 1;
                qryZahlungseingang.Post();
                Session.Commit();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowError(ex.Message);
            }

            int nextKgZahlungseingangID = 0;

            try
            {
                int nextRowHandle = grvZahlungseingang.GetNextVisibleRow(grvZahlungseingang.FocusedRowHandle);

                if (nextRowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                {
                    nextKgZahlungseingangID = (int)grvZahlungseingang.GetRowCellValue(nextRowHandle, "KgZahlungseingangID");
                }
            }
            catch (Exception ex2)
            {
                KissMsg.ShowError("Positionierung auf nächsten Zahlungseingang\r\n\r\n" + ex2.Message);
            }

            qryZahlungseingang.Refresh();
            qryZahlungseingang.Find("KgZahlungseingangID = " + nextKgZahlungseingangID.ToString());
        }

        private void btnAusgleichAufheben_Click(object sender, EventArgs e)
        {
            if (!KissMsg.ShowQuestion("Soll die Buchung des Zahlungseingangs und deren Ausgleichsinformationen gelöscht werden?"))
            {
                return;
            }

            try
            {
                Session.BeginTransaction();
                SqlQuery qry = DBUtil.OpenSQL(@"
                    SELECT PER.KgPeriodeStatusCode, PER.AbgeschlossenBis
                    FROM   dbo.KgPeriode PER WITH (READUNCOMMITTED)
                           INNER JOIN dbo.KgBuchung BUC WITH (READUNCOMMITTED) ON BUC.KgPeriodeID = PER.KgPeriodeID
                    WHERE  BUC.KgZahlungseingangID = {0}",
                    qryZahlungseingang["KgZahlungseingangID"]);

                if (qry.Count > 0)
                {
                    if ((int)qry["KgPeriodeStatusCode"] != 1)
                    {
                        Session.Rollback();
                        KissMsg.ShowInfo("Die zur Zahlung gehörende Periode ist nicht mehr aktiv!");
                        return;
                    }

                    if (!DBUtil.IsEmpty(qry["AbgeschlossenBis"]) && (DateTime)qry["AbgeschlossenBis"] <= (DateTime)qryZahlungseingang["Datum"])
                    {
                        Session.Rollback();
                        KissMsg.ShowInfo("Das Datum Eingangszahlung befindet sich in einem bereits definitiv verbuchten Datumsbereich!");
                        return;
                    }

                    DBUtil.ExecuteScalarSQLThrowingException(@"
                    DECLARE @OP TABLE (KgBuchungID int, TotAusgleichBetrag money)

                    INSERT @OP (KgBuchungID)
                    SELECT AUS.OpBuchungID
                    FROM   dbo.KgOpAusgleich AUS WITH (READUNCOMMITTED)
                           INNER JOIN dbo.KgBuchung BUC WITH (READUNCOMMITTED) ON BUC.KgBuchungID = AUS.AusgleichBuchungID
                    WHERE  BUC.KgZahlungseingangID = {0}

                    DELETE AUS
                    FROM   dbo.KgOpAusgleich AUS WITH (READUNCOMMITTED)
                           INNER JOIN dbo.KgBuchung BUC WITH (READUNCOMMITTED) ON BUC.KgBuchungID = AUS.AusgleichBuchungID
                    WHERE  BUC.KgZahlungseingangID = {0}

                    DELETE BUC
                    FROM   dbo.KgBuchung BUC WITH (READUNCOMMITTED)
                           INNER JOIN @OP OP ON OP.KgBuchungID = BUC.KgBuchungID
                    WHERE  BUC.KgBuchungTypCode = 5 -- RestAusgleich

                    DELETE KgBuchung
                    WHERE  KgZahlungseingangID = {0}

                    UPDATE @OP
                    SET    TotAusgleichBetrag = IsNull((SELECT SUM(Betrag) FROM dbo.KgOpAusgleich WITH (READUNCOMMITTED) WHERE OpBuchungID = KgBuchungID),0)

                    UPDATE BUC
                    SET    KgBuchungStatusCode = CASE
                                                 WHEN OP.TotAusgleichBetrag = 0 THEN 2            -- freigegeben (grün)
                                                 WHEN OP.TotAusgleichBetrag >= BUC.Betrag THEN 6  -- ausgeglichen
                                                 ELSE 10                                          -- teilausgeglichen
                                                 END
                    FROM   dbo.KgBuchung BUC WITH (READUNCOMMITTED)
                           inner join @OP OP ON OP.KgBuchungID = BUC.KgBuchungID",
                        qryZahlungseingang["KgZahlungseingangID"]);
                }
                qryZahlungseingang["Ausgeglichen"] = 0;
                qryZahlungseingang.Post();
                Session.Commit();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowError(ex.Message);
            }
            qryZahlungseingang.Refresh();
        }

        private void btnAusgleichAufhebenRL_Click(object sender, EventArgs e)
        {
            if (!KissMsg.ShowQuestion("Soll die Buchung des Rückläufers und deren Ausgleichsinformationen gelöscht werden?"))
            {
                return;
            }

            try
            {
                Session.BeginTransaction();
                SqlQuery qry = DBUtil.OpenSQL(@"
                    SELECT PER.KgPeriodeStatusCode, PER.AbgeschlossenBis
                    FROM   dbo.KgPeriode PER WITH (READUNCOMMITTED)
                           INNER JOIN dbo.KgBuchung BUC WITH (READUNCOMMITTED) ON BUC.KgPeriodeID = PER.KgPeriodeID
                    WHERE  BUC.KgZahlungseingangID = {0}",
                    qryZahlungseingang["KgZahlungseingangID"]);

                if ((int)qry["KgPeriodeStatusCode"] != 1)
                {
                    Session.Rollback();
                    KissMsg.ShowInfo("Die zur Zahlung gehörende Periode ist nicht mehr aktiv!");
                    return;
                }

                if (!DBUtil.IsEmpty(qry["AbgeschlossenBis"]) && (DateTime)qry["AbgeschlossenBis"] <= (DateTime)qryZahlungseingang["Datum"])
                {
                    Session.Rollback();
                    KissMsg.ShowInfo("Das Datum Eingangszahlung befindet sich in einem bereits definitiv verbuchten Datumsbereich!");
                    return;
                }

                DBUtil.ExecuteScalarSQLThrowingException(@"
                    UPDATE KgBuchung
                    SET KgBuchungStatusCode = 6 --ausgeglichen
                    WHERE KgBuchungID IN
                    (
                        -- Buchung Kreditor->Kontokorrent
                        SELECT AUS.OpBuchungID
                        FROM dbo.KgBuchung             BUC WITH (READUNCOMMITTED)
                          INNER JOIN dbo.KgOpAusgleich AUS WITH (READUNCOMMITTED) ON BUC.KgBuchungID = AUS.AusgleichBuchungID
                        WHERE  BUC.KgZahlungseingangID = {0}

                        UNION

                        -- Buchung Aufwand->Kreditor
                        SELECT AUS2.OpBuchungID
                        FROM dbo.KgBuchung             BUC  WITH (READUNCOMMITTED)
                          INNER JOIN dbo.KgOpAusgleich AUS  WITH (READUNCOMMITTED) ON BUC.KgBuchungID = AUS.AusgleichBuchungID
                          INNER JOIN dbo.KgOpAusgleich AUS2 WITH (READUNCOMMITTED) ON AUS.OpBuchungID = AUS2.AusgleichBuchungID
                        WHERE  BUC.KgZahlungseingangID = {0}
                    )

                    DECLARE @KbBuchungID_Aufwand int
                    SELECT @KbBuchungID_Aufwand = AUB.KgBuchungID
                    FROM dbo.KgBuchung             BUC
                      INNER JOIN dbo.KgOpAusgleich AUS ON BUC.KgBuchungID = AUS.OpBuchungID
                      INNER JOIN dbo.KgBuchung     AUB ON AUB.KgBuchungID = AUS.AusgleichBuchungID
                    WHERE  BUC.KgZahlungseingangID = {0}

                    DELETE FROM AUS
                    FROM dbo.KgBuchung             BUC
                      INNER JOIN dbo.KgOpAusgleich AUS ON BUC.KgBuchungID = AUS.OpBuchungID
                    WHERE  BUC.KgZahlungseingangID = {0}

                    DELETE FROM AUS
                    FROM dbo.KgBuchung             BUC
                      INNER JOIN dbo.KgOpAusgleich AUS ON BUC.KgBuchungID = AUS.AusgleichBuchungID
                    WHERE  BUC.KgZahlungseingangID = {0}

                    -- Beide Rücklaufer-Buchungen löschen: Bank->Kreditor und Kreditor->Aufwand
                    DELETE FROM dbo.KgBuchung
                    WHERE  KgZahlungseingangID = {0} OR KgBuchungID = @KbBuchungID_Aufwand",
                    qryZahlungseingang["KgZahlungseingangID"]);

                qryZahlungseingang["Ausgeglichen"] = 0;
                qryZahlungseingang.Post();
                Session.Commit();
                KissMsg.ShowInfo("Der Rückläufer wurde erfolgreich aufgehoben");
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowError(ex.Message);
            }
            qryZahlungseingang.Refresh();
        }

        private void btnAusgleichErzeugen_Click(object sender, EventArgs e)
        {
            bool betragGleich = false;
            object opBuchungID;

            if (!DBUtil.IsEmpty(qryDebitor["Betrag"]))
            {
                betragGleich = ((Decimal)qryDebitor["Betrag"] == (Decimal)qryZahlungseingang["Betrag"]);

                if (!betragGleich)
                {
                    if (!KissMsg.ShowQuestion(
                        "Der Debitor-Betrag ist nicht gleich dem Betrag des Zahlungseingangs." +
                        "\r\nEin Ausgleich ist deshalb nicht möglich." +
                        "\r\n\r\nDebitor-Posten trotzdem speichern?"))
                        return;
                }
            }

            if (!qryDebitor.Post())
            {
                return;  //return bei leerem Betrag
            }

            DataTable tmpTable = qryDebitor.DataTable.Clone();
            tmpTable.Columns.Add("Monat");
            tmpTable.Columns.Add("Jahr");
            _saveRow = tmpTable.NewRow();
            _saveRow.ItemArray = (object[])qryDebitor.Row.ItemArray.Clone();
            _saveRow["Monat"] = qryMonatsbudget["Monat"];
            _saveRow["Jahr"] = qryMonatsbudget["Jahr"];

            //automatisches Grünstellen
            try
            {
                Session.BeginTransaction();
                // graue Position auf grün stellen
                DBUtil.ExecSQLThrowingException(@"
                    EXECUTE spKgBudget_KgBuchung_Create {0}, {1}, {2}, 0",
                    qryMonatsbudget["KgBudgetID"],
                    qryDebitor["KgPositionID"],
                    Session.User.UserID);

                opBuchungID = DBUtil.ExecuteScalarSQLThrowingException(
                    "select KgBuchungID from KgBuchung where KgPositionID = {0}",
                    qryDebitor["KgPositionID"]);
                Session.Commit();
            }
            catch (KissCancelException ex)
            {
                if (Session.Transaction != null)
                {
                    Session.Rollback();
                }
                ex.ShowMessage();
                return;
            }
            catch (Exception ex)
            {
                if (Session.Transaction != null)
                {
                    Session.Rollback();
                }
                KissMsg.ShowError(ex.Message);
                return;
            }

            //Ausgleich

            if (!betragGleich)
            {
                FillQryAusgleiche();
                DebitorVorbereiten();
                return;
            }

            try
            {
                Session.BeginTransaction();

                int? kgPeriodeID = (int?)DBUtil.ExecuteScalarSQLThrowingException(@"
                    SELECT KgPeriodeID
                    FROM   dbo.KgPeriode PER WITH (READUNCOMMITTED)
                           INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = PER.FaLeistungID
                    WHERE  LEI.BaPersonID = {0} AND
                           PER.KgPeriodeStatusCode = 1 /*aktiv*/ AND
                           PER.PeriodeVon <= {1} AND PER.PeriodeBis >= {1}", qryZahlungseingang["BaPersonID"], qryZahlungseingang["Datum"]);

                if (!kgPeriodeID.HasValue)
                {
                    Session.Rollback();
                    KissMsg.ShowError(KissMsg.GetMLMessage("CtlKgZahlungseingang", "KeineOffenePeriode", "Es existiert keine aktive Buchungsperiode für das Datum {0:dd.MM.yyyy}",
                            KissMsgCode.MsgError, qryZahlungseingang["Datum"]));
                    return;
                }

                // Debitorenkonto bestimmen
                object kontokorrentKontoNr = DBUtil.ExecuteScalarSQLThrowingException("SELECT KontoNr FROM dbo.KgKonto WITH (READUNCOMMITTED) WHERE KgKontoartCode = 1 AND KgPeriodeID = {0}", kgPeriodeID.Value);
                object debitorKontoNr = DBUtil.ExecuteScalarSQLThrowingException("SELECT KontoNr FROM dbo.KgKonto WITH (READUNCOMMITTED) WHERE KgKontoartCode = 2 AND KgPeriodeID = {0}", kgPeriodeID.Value);

                // KbBuchung für ganze Zahlung erstellen
                int ausgleichKgBuchungID = (int)DBUtil.ExecuteScalarSQLThrowingException(@"
                    INSERT INTO KgBuchung (KgPeriodeID, KgBuchungTypCode, KgZahlungseingangID, BuchungsDatum, ValutaDatum,
                                           SollKtoNr, HabenKtoNr, Betrag, Text, ErstelltDatum)
                    VALUES ({0}, 4, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8})
                    SELECT CAST(SCOPE_IDENTITY() AS int)",
                    kgPeriodeID.Value,
                    qryZahlungseingang["KgZahlungseingangID"],
                    qryZahlungseingang["Datum"],
                    qryZahlungseingang["Datum"],
                    kontokorrentKontoNr,
                    debitorKontoNr,
                    qryZahlungseingang["Betrag"],
                    qryDebitor["Buchungstext"],
                    DateTime.Now);

                DBUtil.ExecuteScalarSQLThrowingException(@"
                    INSERT INTO KgOpAusgleich (OpBuchungID, AusgleichBuchungID, Betrag)
                        VALUES ({0},{1},{2})

                    UPDATE KgBuchung
                    SET    KgBuchungStatusCode = 6 --ausgeglichen
                    WHERE  KgBuchungID = {0}",
                    opBuchungID,
                    ausgleichKgBuchungID,
                    qryZahlungseingang["Betrag"]);

                qryZahlungseingang["Ausgeglichen"] = 1;
                qryZahlungseingang.Post();
                Session.Commit();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowError(ex.Message);
            }

            int nextKgZahlungseingangID = 0;

            try
            {
                int nextRowHandle = grvZahlungseingang.GetNextVisibleRow(grvZahlungseingang.FocusedRowHandle);

                if (nextRowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                {
                    nextKgZahlungseingangID = (int)grvZahlungseingang.GetRowCellValue(nextRowHandle, "KgZahlungseingangID");
                }
            }
            catch (Exception ex2)
            {
                KissMsg.ShowError("Positionierung auf nächsten Zahlungseingang\r\n\r\n" + ex2.Message);
            }

            qryZahlungseingang.Refresh();
            qryZahlungseingang.Find("KgZahlungseingangID = " + nextKgZahlungseingangID.ToString());
        }

        private void btnAusgleichRL_Click(object sender, EventArgs e)
        {
            int[] kgBuchungIDs = UpdateAusgleichRLSum();

            if (!btnAusgleichRL.Enabled)
            {
                KissMsg.ShowInfo(KissMsg.GetMLMessage("CtlKgZahlungseingang", "AusgleichNichtMöglich", "Ausgleich nicht möglich: Total der auszugleichenden Beträge stimmt nicht mit Zahlungseingang überein"));
                return;
            }
            if (kgBuchungIDs.Length != 1)
            {
                KissMsg.ShowInfo(KissMsg.GetMLMessage("CtlKgZahlungseingang", "NichtEineBuchungAusgewählt", "Ausgleich nicht möglich: Es ist nicht genau eine Buchung ausgewählt"));
                return;
            }
            //int kgBuchungID = kgBuchungIDs[0];

            try
            {
                Session.BeginTransaction();
                int? kgPeriodeID = (int?)DBUtil.ExecuteScalarSQLThrowingException(@"
                    SELECT KgPeriodeID
                    FROM   dbo.KgPeriode PER WITH (READUNCOMMITTED)
                           INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = PER.FaLeistungID
                    WHERE  LEI.BaPersonID = {0} AND
                           PER.KgPeriodeStatusCode = 1 /*aktiv*/ AND
                           PER.PeriodeVon <= {1} AND PER.PeriodeBis >= {1}", qryZahlungseingang["BaPersonID"], qryZahlungseingang["Datum"]);
                if (!kgPeriodeID.HasValue)
                {
                    Session.Rollback();
                    KissMsg.ShowError(KissMsg.GetMLMessage("CtlKgZahlungseingang", "KeineOffenePeriode", "Es existiert keine aktive Buchungsperiode für das Datum {0:dd.MM.yyyy}",
                            KissMsgCode.MsgError, qryZahlungseingang["Datum"]));
                    return;
                }
                // Debitorenkonto bestimmen
                object kontokorrentKontoNr = DBUtil.ExecuteScalarSQLThrowingException("SELECT KontoNr FROM dbo.KgKonto WITH (READUNCOMMITTED) WHERE KgKontoartCode = 1 AND KgPeriodeID = {0}", kgPeriodeID.Value);
                object kreditorKontoNr = DBUtil.ExecuteScalarSQLThrowingException("SELECT KontoNr FROM dbo.KgKonto WITH (READUNCOMMITTED) WHERE KgKontoartCode = 3 AND KgPeriodeID = {0}", kgPeriodeID.Value);

                // Buchungstext bestimmen
                string text = edtBuchungstextRL.Text;//string.Format("Rückläufer ({0})", qryAusgleichRL["Text"]);
                if (!string.IsNullOrEmpty(text))
                    text = text.Substring(0, Math.Min(200, text.Length));

                // Rückläufer-KbBuchung für ganze Zahlung erstellen. 1.Teil: Buchung Bank->Kreditor
                int ruecklaeuferKgBuchungIDBank = (int)DBUtil.ExecuteScalarSQLThrowingException(@"
                    INSERT INTO KgBuchung (KgPeriodeID, KgBuchungTypCode, KgZahlungseingangID, BuchungsDatum, ValutaDatum,
                                           SollKtoNr, HabenKtoNr, Betrag, Text, KgBuchungStatusCode, ErstelltDatum, ErstelltUserID)
                    VALUES ({0}, 4, {1}, {2}, {3}, {4}, {5}, {6}, {7}, 9 /*Rückläufer*/, {8}, {9})
                    SELECT CAST(SCOPE_IDENTITY() AS int)",
                    kgPeriodeID.Value,
                    qryZahlungseingang["KgZahlungseingangID"],
                    qryZahlungseingang["Datum"],
                    qryZahlungseingang["Datum"],
                    kontokorrentKontoNr,
                    kreditorKontoNr, //qryAusgleichRL["SollKtoNr"], // Aufwandkonto
                    qryZahlungseingang["Betrag"],
                    text,
                    DateTime.Now,
                    Session.User.UserID);

                decimal? ausglBetrag = qryAusgleichRL["AusglBetrag"] as decimal?;
                if (ausglBetrag.HasValue && ausglBetrag > 0m)
                {
                    DBUtil.ExecuteScalarSQLThrowingException(@"
                        DECLARE @AusgleichBuchungID int

                        SELECT @AusgleichBuchungID = MIN(AusgleichBuchungID)
                        FROM   KgOpAusgleich
                        WHERE  OpBuchungID = {0}

                        INSERT INTO KgOpAusgleich (OpBuchungID, AusgleichBuchungID, Betrag, KbAusgleichGrundCode)
                        VALUES (@AusgleichBuchungID, {1}, {2}, 10 /*Rückläufer*/)

                        UPDATE KgBuchung
                        SET    KgBuchungStatusCode = 9 --Rückläufer
                        WHERE  KgBuchungID IN ({0},@AusgleichBuchungID)",
                        qryAusgleichRL["KgBuchungID"], //
                        ruecklaeuferKgBuchungIDBank,
                        qryAusgleichRL["AusglBetrag"]);
                }

                // Rückläufer-KbBuchung für ganze Zahlung erstellen. 2.Teil: Buchung Kreditor->Aufwand
                int ruecklaeuferKgBuchungIDAufwand = (int)DBUtil.ExecuteScalarSQLThrowingException(@"
                    INSERT INTO KgBuchung (KgPeriodeID, KgBuchungTypCode, KgZahlungseingangID, BuchungsDatum, ValutaDatum,
                                           SollKtoNr, HabenKtoNr, Betrag, Text, KgBuchungStatusCode, ErstelltDatum, ErstelltUserID)
                    VALUES ({0}, 4, {1}, {2}, {3}, {4}, {5}, {6}, {7}, 9 /*Rückläufer*/, {8}, {9})
                    SELECT CAST(SCOPE_IDENTITY() AS int)",
                    kgPeriodeID.Value,
                    DBNull.Value,
                    qryZahlungseingang["Datum"],
                    qryZahlungseingang["Datum"],
                    kreditorKontoNr,
                    qryAusgleichRL["SollKtoNr"], // Aufwandkonto
                    qryZahlungseingang["Betrag"],
                    text,
                    DateTime.Now,
                    Session.User.UserID);

                if (ausglBetrag.HasValue && ausglBetrag > 0m)
                {
                    DBUtil.ExecuteScalarSQLThrowingException(@"
                        INSERT INTO KgOpAusgleich (OpBuchungID, AusgleichBuchungID, Betrag, KbAusgleichGrundCode)
                        VALUES ({0}, {1}, {2}, 10 /*Rückläufer*/)",
                          ruecklaeuferKgBuchungIDBank, //
                          ruecklaeuferKgBuchungIDAufwand,
                          qryAusgleichRL["AusglBetrag"]);
                }

                qryZahlungseingang["Ausgeglichen"] = 1;
                qryZahlungseingang.Post();
                Session.Commit();
                KissMsg.ShowInfo(KissMsg.GetMLMessage("CtlKgZahlungseingang", "RückläuferErfolgreich", "Der Rückläufer wurde erfolgreich gespeichert"));
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowError(ex.Message);
                return;
            }

            btnMonatsbudgetRL.PerformClick();

            int nextKgZahlungseingangID = 0;
            try
            {
                int nextRowHandle = grvZahlungseingang.GetNextVisibleRow(grvZahlungseingang.FocusedRowHandle);

                if (nextRowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                {
                    nextKgZahlungseingangID = (int)grvZahlungseingang.GetRowCellValue(nextRowHandle, "KgZahlungseingangID");
                }
            }
            catch (Exception ex2)
            {
                KissMsg.ShowError("Positionierung auf nächsten Zahlungseingang\r\n\r\n" + ex2.Message);
            }

            qryZahlungseingang.Refresh();
            qryZahlungseingang.Find("KgZahlungseingangID = " + nextKgZahlungseingangID.ToString());
        }

        private void btnBudget2_Click(object sender, EventArgs e)
        {
            if (qryMonatsbudget.Count == 0)
            {
                return;
            }

            SqlQuery qry = DBUtil.OpenSQL(@"
                select top 1 FallBaPersonID = FAL.BaPersonID, LEI.FaLeistungID, BDG.KgMasterbudgetID, BDG.KgBudgetID
                from   dbo.KgBudget BDG WITH (READUNCOMMITTED)
                       inner join dbo.FaLeistung LEI WITH (READUNCOMMITTED) on LEI.FaLeistungID = BDG.FaLeistungID
                       inner join dbo.FaFall     FAL WITH (READUNCOMMITTED) on FAL.FaFallID = LEI.FaFallID
                where  BDG.KgBudgetID = {0}",
                qryMonatsbudget["KgBudgetID"]);

            if (qry.Count == 0)
            {
                return;
            }

            string pfad = String.Format(@"CtlKgLeistung{0}\Masterbudget{1}\Monatsbudget{2}",
                             qry["FaLeistungID"], qry["KgMasterbudgetID"], qry["KgBudgetID"]);

            FormController.OpenForm("FrmFall", "Action", "JumpToNodeByFieldValue",
                        "BaPersonID", qry["FallBaPersonID"],
                        "ModulID", 5,
                        "FieldValue", pfad);
        }

        private void btnMonatsbudget_Click(object sender, EventArgs e)
        {
            SqlQuery qry;
            if (qryAusgleich.Count > 0)
            {
                qry = DBUtil.OpenSQL(@"
                    select FallBaPersonID = FAL.BaPersonID, LEI.FaLeistungID, BDG.KgMasterbudgetID, BDG.KgBudgetID
                    from   dbo.KgBuchung BUC WITH (READUNCOMMITTED)
                           inner join dbo.KgPosition POS WITH (READUNCOMMITTED) on POS.KgPositionID = BUC.KgPositionID
                           inner join dbo.KgBudget   BDG WITH (READUNCOMMITTED) on BDG.KgBudgetID = POS.KgBudgetID
                           inner join dbo.FaLeistung LEI WITH (READUNCOMMITTED) on LEI.FaLeistungID = BDG.FaLeistungID
                           inner join dbo.FaFall     FAL WITH (READUNCOMMITTED) on FAL.FaFallID = LEI.FaFallID
                    where  KgBuchungID = {0}",
                    qryAusgleich["KgBuchungID"]);
            }
            else
            {
                qry = DBUtil.OpenSQL(@"
                    select top 1 FallBaPersonID = FAL.BaPersonID, LEI.FaLeistungID, BDG.KgMasterbudgetID, BDG.KgBudgetID
                    from   dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                           inner join dbo.KgBudget BDG WITH (READUNCOMMITTED) on BDG.FaLeistungID = LEI.FaLeistungID
                           inner join dbo.FaFall   FAL WITH (READUNCOMMITTED) on FAL.FaFallID = LEI.FaFallID
                    where  LEI.BaPersonID = {0}
                    order by BDG.Jahr desc,BDG.Monat desc",
                    qryZahlungseingang["BaPersonID"]);
            }

            if (qry.Count == 0) return;

            string pfad = String.Format(@"CtlKgLeistung{0}\Masterbudget{1}\Monatsbudget{2}",
                             qry["FaLeistungID"], qry["KgMasterbudgetID"], qry["KgBudgetID"]);

            FormController.OpenForm("FrmFall", "Action", "JumpToNodeByFieldValue",
                        "BaPersonID", qry["FallBaPersonID"],
                        "ModulID", 5,
                        "FieldValue", pfad);
        }

        private void btnMonatsbudgetRL_Click(object sender, EventArgs e)
        {
            SqlQuery qry;
            if (qryAusgleichRL.Count > 0)
            {
                qry = DBUtil.OpenSQL(@"
                    select FallBaPersonID = FAL.BaPersonID, LEI.FaLeistungID, BDG.KgMasterbudgetID, BDG.KgBudgetID, POS.KgPositionID
                    from   dbo.KgBuchung BUC WITH (READUNCOMMITTED)
                           inner join dbo.KgPosition POS WITH (READUNCOMMITTED) on POS.KgPositionID = BUC.KgPositionID
                           inner join dbo.KgBudget   BDG WITH (READUNCOMMITTED) on BDG.KgBudgetID = POS.KgBudgetID
                           inner join dbo.FaLeistung LEI WITH (READUNCOMMITTED) on LEI.FaLeistungID = BDG.FaLeistungID
                           inner join dbo.FaFall     FAL WITH (READUNCOMMITTED) on FAL.FaFallID = LEI.FaFallID
                    where  KgBuchungID = {0}",
                    qryAusgleichRL["KgBuchungID"]);
            }
            else
            {
                qry = DBUtil.OpenSQL(@"
                    select top 1 FallBaPersonID = FAL.BaPersonID, LEI.FaLeistungID, BDG.KgMasterbudgetID, BDG.KgBudgetID, KgPositionID = NULL
                    from   dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                           inner join dbo.KgBudget BDG WITH (READUNCOMMITTED) on BDG.FaLeistungID = LEI.FaLeistungID
                           inner join dbo.FaFall   FAL WITH (READUNCOMMITTED) on FAL.FaFallID = LEI.FaFallID
                    where  LEI.BaPersonID = {0}
                    order by BDG.Jahr desc,BDG.Monat desc",
                    qryZahlungseingang["BaPersonID"]);
            }

            if (qry.Count == 0)
            {
                return;
            }

            string jumpToPath = string.Format(
                "ClassName=FrmFall;" +
                "BaPersonID={0};" +
                "ModulID=5;" +
                @"TreeNodeID=CtlKgLeistung{1}\Masterbudget{2}\Monatsbudget{3};" +
                (DBUtil.IsEmpty(qry["KgPositionID"]) ? "" : "ActiveSQLQuery.Find=KgPositionID = {4};"),
                    qry["FallBaPersonID"],
                    qry["FaLeistungID"],
                    qry["KgMasterbudgetID"],
                    qry["KgBudgetID"],
                    qry["KgPositionID"]);

            System.Collections.Specialized.HybridDictionary dic = FormController.ConvertToDictionary(jumpToPath);

            FormController.OpenForm((string)dic["ClassName"], "Action", "JumpToPath", dic);
        }

        private void CtlKgZahlungseingang_Load(object sender, EventArgs e)
        {
            //Budgetstati laden
            repositoryItemImageComboBox2.SmallImages = KissImageList.SmallImageList;
            SqlQuery qryStati = DBUtil.OpenSQL(@"
                SELECT *
                FROM dbo.XLOVCode WITH(READUNCOMMITTED)
                WHERE LOVName = 'KgBewilligung'
                ORDER BY SortKey;");

            foreach (DataRow row in qryStati.DataTable.Rows)
            {
                repositoryItemImageComboBox2.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(
                    row["Text"].ToString(),
                    (int)row["Code"],
                    KissImageList.GetImageIndex(Convert.ToInt32(row["Value1"]))));
            }

            repositoryItemButtonEdit1.Click += AusgleichClick;
            repositoryItemTextEdit1.EditValueChanging += repositoryItemTextEdit1_EditValueChanging;

            _buchungstextDebitor = new KgBuchungstext(edtBuchungstext, qryDebitor);

            btnAusgleichAufheben.Location = btnAusgleich.Location;
            tabDetails.SelectedTabIndex = 1;
            tabDetails.SelectedTabIndex = 0;

            qryZahlungseingang.EnableBoundFields(false);

            tabControlSearch.SelectedTabIndex = 1;
            ApplicationFacade.DoEvents();
            tabControlSearch.SelectedTabIndex = 0;

            RunSearch();
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
                    edtBaInstitutionIDX.LookupID = DBNull.Value;
                    edtBaInstitutionIDX.EditValue = DBNull.Value;
                    return;
                }
                return;
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
              SELECT BaInstitutionID$ = INS.BaInstitutionID,
                     [Inst.-Nr]       = INS.BaInstitutionID,
                     Institution      = INS.Name,
                     Adresse          = INS.Adresse
              FROM   dbo.vwInstitution INS
              WHERE  INS.BaFreigabeStatusCode = 2 AND
                     INS.Name like '%' + {0} + '%'
              ORDER BY INS.Name",
              searchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                edtBaInstitutionIDX.LookupID = dlg["BaInstitutionID$"];
                edtBaInstitutionIDX.Text = dlg["Institution"] as string;
                edtBaInstitutionIDX.UserModified = false;
            }
        }

        private void edtBaPersonIDX_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString;

            if (edtBaPersonIDX.Text == null)
            {
                searchString = "";
            }
            else
            {
                searchString = edtBaPersonIDX.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");
            }

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    KissMsg.ShowInfo("Bitte zuerst einen Suchbegriff eingeben!");
                }
                else
                {
                    edtBaPersonIDX.LookupID = DBNull.Value;
                    edtBaPersonIDX.EditValue = DBNull.Value;
                    return;
                }
                return;
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
              SELECT BaPersonID$  = PRS.BaPersonID,
                     [Pers.-Nr]   = PRS.BaPersonID,
                     Name         = PRS.Name,
                     Vorname      = PRS.Vorname,
                     Wohnsitz     = PRS.Wohnsitz,
                     Klient$      = PRS.NameVorname
              FROM   dbo.vwPerson PRS
                INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) on LEI.BaPersonID = PRS.BaPersonID and
                                             LEI.FaProzessCode = 500
              WHERE  PRS.NameVorname like '%' + {0} + '%'
              ORDER BY PRS.NameVorname",
              searchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                edtBaPersonIDX.LookupID = dlg["BaPersonID$"];
                edtBaPersonIDX.Text = dlg["Klient$"] as string;
            }
        }

        private void edtBuchungstext_Enter(object sender, EventArgs e)
        {
            edtBuchungstext.SelectAll();
        }

        private void edtBuchungstext_TextChanged(object sender, EventArgs e)
        {
            if (edtBuchungstext.UserModified && edtBuchungstext.EditValue != null)
            {
                _buchungstextDebitor.FilterBuchungstext(edtBuchungstext.EditValue.ToString());
            }
        }

        private void edtDebitor_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtDebitor.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    KissMsg.ShowInfo("Bitte zuerst einen Suchbegriff eingeben!");
                }
                else
                {
                    qryZahlungseingang["BaInstitutionID"] = DBNull.Value;
                    qryZahlungseingang["DebitorText"] = DBNull.Value;
                    qryZahlungseingang["ZusatzInfo"] = DBNull.Value;
                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
              SELECT ID$                 = INS.BaInstitutionID,
                     Institution         = INS.Name,
                     Adresse             = INS.AdresseMehrzeilig,
                     Typ                 = INS.Typ
              FROM   dbo.vwInstitution INS
              WHERE  INS.Name LIKE '%' + {0} + '%' AND
                     INS.Debitor = 1 AND
                     INS.BaFreigabeStatusCode = 2 --definitv
              ORDER BY INS.Name",
              searchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                qryZahlungseingang["BaInstitutionID"] = dlg["ID$"];
                qryZahlungseingang["DebitorText"] = dlg["Institution"];
                qryZahlungseingang["ZusatzInfo"] = dlg["Adresse"];
            }
        }

        private void edtDebitor2_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtDebitor2.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryDebitor["BaInstitutionID"] = DBNull.Value;
                    qryDebitor["Debitor"] = DBNull.Value;
                    qryDebitor["ZusatzInfo"] = DBNull.Value;
                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
              SELECT ID$                 = INS.BaInstitutionID,
                     Institution         = INS.Name,
                     Adresse             = INS.Adresse,
                     Typ                 = INS.Typ
              FROM   vwInstitution INS
              WHERE  INS.BaFreigabeStatusCode = 2 AND
                     INS.Name LIKE '%' + {0} + '%' AND
                     INS.Debitor = 1
              ORDER BY INS.Name",
              searchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                SetDebitor((int)dlg["ID$"], dlg["Institution"].ToString(), dlg["Adresse"].ToString());
            }
        }

        private void edtKonto2_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtKonto2.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryDebitor["KontoNr"] = DBNull.Value;
                    qryDebitor["Konto"] = DBNull.Value;
                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
              SELECT distinct
                     Konto   = KTO.KontoNr,
                     Name    = KTO.KontoName,
                     Klasse  = KLA.Text,
                     Konto$  = KTO.KontoNr + ' ' + KTO.KontoName
              FROM   FaLeistung LEI
                     INNER JOIN KgPeriode    PER ON PER.FaLeistungID = LEI.FaLeistungID AND
                                                    PER.KgPeriodeStatusCode = 1 --Aktiv
                     INNER JOIN KgKonto      KTO ON KTO.KgPeriodeID = PER.KgPeriodeID AND
                                                    KTO.KontoGruppe = 0 AND
                                                    KTO.KgKontoKlasseCode in (3,4)
                     LEFT  JOIN XLOVCode     KLA ON KLA.LOVName = 'KgKontoKlasse' AND
                                                    KLA.Code = KTO.KgKontoKlasseCode
              WHERE  LEI.BaPersonID = " + qryDebitor["BaPersonID"] + @"  AND
                     KTO.KgKontoklasseCode in (3,4) AND
                     (KTO.KontoName like '%' + {0} + '%' OR
                      KTO.KontoNr like {0} + '%') AND
                     (KTO.KgKontoartCode IS NULL OR KTO.KgKontoartCode <> 1)  -- Alle Konten ausser dem Kontokorrent-Konto #7450/#7666
              ORDER BY KTO.KontoNr",
              searchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                qryDebitor["KontoNr"] = dlg["Konto"];
                qryDebitor["Konto"] = dlg["Konto$"];
                qryDebitor["Buchungstext"] = dlg["Name"];

                _buchungstextDebitor.LoadBuchungstext(qryDebitor["KontoNr"], true);
            }
        }

        private void edtKontoRestbetrag_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtKontoRestbetrag.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    edtKontoRestbetrag.EditValue = DBNull.Value;
                    edtKontoRestbetrag.LookupID = DBNull.Value;
                    UpdateAusgleichSum();
                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
              SELECT distinct
                     Konto   = KTO.KontoNr,
                     Name    = KTO.KontoName,
                     Klasse  = KLA.Text,
                     Konto$  = KTO.KontoNr + ' ' + KTO.KontoName
              FROM   dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                     INNER JOIN dbo.KgPeriode    PER WITH (READUNCOMMITTED) ON PER.FaLeistungID = LEI.FaLeistungID AND
                                                    PER.KgPeriodeStatusCode = 1 --Aktiv
                     INNER JOIN dbo.KgKonto      KTO WITH (READUNCOMMITTED) ON KTO.KgPeriodeID = PER.KgPeriodeID AND
                                                    KTO.KontoGruppe = 0 AND
                                                    KTO.KgKontoKlasseCode in (1,2,3,4)
                     LEFT  JOIN dbo.XLOVCode     KLA WITH (READUNCOMMITTED) ON KLA.LOVName = 'KgKontoKlasse' AND
                                                    KLA.Code = KTO.KgKontoKlasseCode
              WHERE  LEI.BaPersonID = " + qryZahlungseingang["BaPersonID"] + @"  AND
                     (KTO.KontoName like '%' + {0} + '%' OR
                      KTO.KontoNr like {0} + '%') AND
                     (KTO.KgKontoartCode IS NULL OR KTO.KgKontoartCode <> 1) -- Alle Konten ausser dem Kontokorrent-Konto #7450/#7666
              ORDER BY KTO.KontoNr",
              searchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                edtKontoRestbetrag.EditValue = dlg["Konto$"];
                edtKontoRestbetrag.LookupID = dlg["Konto"];
                UpdateAusgleichSum();
            }
        }

        private void edtMandant_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtMandant.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    KissMsg.ShowInfo("Bitte zuerst einen Suchbegriff eingeben!");
                }
                else
                {
                    qryZahlungseingang["BaPersonID"] = DBNull.Value;
                    qryZahlungseingang["Mandant"] = DBNull.Value;
                    qryZahlungseingang["Adresse"] = DBNull.Value;
                    qryZahlungseingang["MT"] = DBNull.Value;
                }
                return;
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
              DECLARE @suchID INT
              IF ISNUMERIC({0}) = 1 AND CHARINDEX('.', {0}) = 0 AND CHARINDEX(',', {0}) = 0 BEGIN
                SELECT @suchID =  CONVERT(int, {0})
              END
              SELECT BaPersonID$  = PRS.BaPersonID,
                     [Pers.-Nr]   = PRS.BaPersonID,
                     Name         = PRS.Name,
                     Vorname      = PRS.Vorname,
                     Wohnsitz     = PRS.Wohnsitz,
                     [Beist. oder Vorm.] = dbo.fnVmGetMTName(PRS.BaPersonID),
                     Mandant$     = PRS.NameVorname
              FROM   dbo.vwPerson PRS
                     inner join dbo.FaLeistung LEI WITH (READUNCOMMITTED) on LEI.BaPersonID = PRS.BaPersonID and
                                                  LEI.FaProzessCode = 500
              WHERE  PRS.NameVorname like '%' + {0} + '%'
                     OR LEI.FaFallID = @suchID OR PRS.BaPersonID = @suchID
              ORDER BY PRS.NameVorname",
              searchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                qryZahlungseingang["BaPersonID"] = dlg["BaPersonID$"];
                qryZahlungseingang["Mandant"] = dlg["Mandant$"];
                qryZahlungseingang["Adresse"] = dlg["Wohnsitz"];
                qryZahlungseingang["MT"] = dlg["Beist. oder Vorm."];
                DebitorVorbereiten();
            }
        }

        private void edtNurGleicherBetrag_EditValueChanged(object sender, EventArgs e)
        {
            FillQryAusgleicheRL();
        }

        private void edtTextRestbetrag_EditValueChanged(object sender, EventArgs e)
        {
            UpdateAusgleichSum();
        }

        private void label_Click(object sender, EventArgs e)
        {
            if (!(sender is KissLabel))
            {
                return;
            }

            var lbl = (KissLabel)sender;
            lbl.Font = new Font(GuiConfig.LabelFontName,
                                 GuiConfig.LabelFontSize,
                                 lbl.Font.Underline ? FontStyle.Regular : FontStyle.Underline | FontStyle.Bold,
                                 GuiConfig.LabelFontGraphicUnit);
        }

        private void qryAusgleich_PositionChanged(object sender, EventArgs e)
        {
            if (!(bool)qryZahlungseingang["Ausgeglichen"])
            {
                UpdateAusgleichSum();
            }
        }

        private void qryAusgleichRL_PositionChanged(object sender, EventArgs e)
        {
            if (!(bool)qryZahlungseingang["Ausgeglichen"])
            {
                foreach (DataRow row in qryAusgleichRL.DataTable.Rows)
                {
                    row["AusglBetrag"] = 0m;
                }

                qryAusgleichRL["AusglBetrag"] = qryAusgleichRL["Betrag"];
                UpdateAusgleichRLSum();
            }
        }

        private void qryDebitor_AfterPost(object sender, EventArgs e)
        {
            //Save ValutaDatum in KgPositionValuta

            DBUtil.ExecSQL(@"
                delete KgPositionValuta where KgPositionID = {0}
                insert KgPositionValuta (KgPositionID,Datum) values ({0},{1})",
                qryDebitor["KgPositionID"],
                qryDebitor["FaelligAm"]);
        }

        private void qryDebitor_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtErfassungDatum2, lblErfassungDatum2.Text);
            DBUtil.CheckNotNullField(edtMandant2, lblMandant2.Text);
            DBUtil.CheckNotNullField(edtKonto2, lblKonto2.Text);
            DBUtil.CheckNotNullField(edtBuchungstext, lblBuchungstext2.Text);
            DBUtil.CheckNotNullField(edtBetrag2, lblBetrag2.Text);

            if (Convert.ToDecimal(qryDebitor["Betrag"]) <= Decimal.Zero)
            {
                edtBetrag.Focus();
                throw new KissInfoException("Der Betrag darf nicht 0.00 oder negativ sein!");
            }

            DBUtil.CheckNotNullField(edtFaelligAm2, lblFaelligAm2.Text);
            DBUtil.CheckNotNullField(edtDebitor2, lblDebitor2.Text);

            if (qryMonatsbudget.Count == 0)
            {
                throw new KissInfoException("Es gibt keine verfügbaren Budgets für diesen Mandanten!");
            }

            if ((int)qryMonatsbudget["KgBewilligungCode"] == 1)
            {
                throw new KissInfoException("in dieser Maske kann eine Einnahme nicht in ein graues Monatsbudget erfasst werden!");
            }

            qryDebitor["KgBudgetID"] = qryMonatsbudget["KgBudgetID"];

            ctlErfassungMutation1.SetFields();
        }

        private void qryZahlungseingang_AfterDelete(object sender, EventArgs e)
        {
            UpdateCounters();
        }

        private void qryZahlungseingang_AfterFill(object sender, EventArgs e)
        {
            UpdateCounters();
        }

        private void qryZahlungseingang_AfterInsert(object sender, EventArgs e)
        {
            UpdateCounters();
            qryZahlungseingang["ErstelltDatum"] = DateTime.Now;
            qryZahlungseingang["ErstelltUserID"] = Session.User.UserID;

            _buchungstextDebitor.LoadBuchungstext(null, false);
            if (edtBuchungstext.EditValue != null)
            {
                _buchungstextDebitor.FilterBuchungstext(edtBuchungstext.EditValue.ToString());
            }
        }

        private void qryZahlungseingang_AfterPost(object sender, EventArgs e)
        {
            tpgAusgleich.HideTab = DBUtil.IsEmpty(qryZahlungseingang["BaPersonID"]);
            FillQryAusgleiche();
            FillQryAusgleicheRL();
            UpdateCounters();
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
            qryZahlungseingang["MutiertDatum"] = DateTime.Now;
            qryZahlungseingang["MutiertUserID"] = Session.User.UserID;
        }

        private void qryZahlungseingang_PositionChanged(object sender, EventArgs e)
        {
            tpgAusgleich.HideTab = (qryZahlungseingang.Row.RowState == DataRowState.Added) || DBUtil.IsEmpty(qryZahlungseingang["BaPersonID"]);
            FillQryAusgleiche();
            FillQryAusgleicheRL();
            edtBuchungstextRL.Text = @"Rückläufer/Zahlung nicht ausgeführt";
            bool ausgeglichen = (bool)qryZahlungseingang["Ausgeglichen"];
            tpgDebitor.HideTab = ausgeglichen;

            if (!ausgeglichen)
            {
                DebitorVorbereiten();
            }

            // automatische Einträge dürfen nicht in allen Feldern verändert werden
            bool manuell = DBUtil.IsEmpty(qryZahlungseingang["PSCDKontoauszug"]);
            edtBetrag.EditMode = manuell ? EditModeType.Normal : EditModeType.ReadOnly;
            edtDatum.EditMode = manuell ? EditModeType.Normal : EditModeType.ReadOnly;
            kissMemoEdit1.EditMode = manuell ? EditModeType.Normal : EditModeType.ReadOnly;
        }

        // ComponentName: repositoryItemTextEdit1
        private void repositoryItemTextEdit1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if ((bool)qryZahlungseingang["Ausgeglichen"]) return;

            qryAusgleich["AusglBetrag"] = e.NewValue;
            UpdateAusgleichSum();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override bool OnDeleteData()
        {
            if (DBUtil.IsEmpty(qryZahlungseingang["PSCDKontoauszug"]))
            {
                // manueller Eintrag
                return base.OnDeleteData();
            }
            // Schnittstelleneintrag => darf nicht gelöscht werden, da er für auswertungen benötigt wirdd
            qryZahlungseingang["Ausgeglichen"] = 1;
            qryZahlungseingang.Post();
            return true;
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();
            edtNurAusgeglichenX.Checked = true;
            edtDatumVonX.Focus();
        }

        #endregion

        #region Private Methods

        private void AusgleichClick(object sender, EventArgs e)
        {
            decimal summe = decimal.Zero;
            foreach (DataRow row in qryAusgleich.DataTable.Rows)
            {
                decimal? ausglBetrag = row["AusglBetrag"] as decimal?;

                if (ausglBetrag.HasValue)
                {
                    summe += ausglBetrag.Value;
                }
            }
            decimal restBetrag = (decimal)qryAusgleich["RestBetrag"];
            decimal totalBetrag = (decimal)qryZahlungseingang["Betrag"];
            qryAusgleich["AusglBetrag"] = Math.Max(Math.Min(restBetrag, totalBetrag - summe), 0m);
            UpdateAusgleichSum();
        }

        private void CopyDebitorValues()
        {
            //Konto
            if (lblKonto2.Font.Underline && _saveRow != null)
            {
                qryDebitor["Konto"] = _saveRow["Konto"];
                qryDebitor["KontoNr"] = _saveRow["KontoNr"];
                edtKonto2.TabStop = false;
            }
            else
            {
                edtKonto2.TabStop = true;
            }

            //Buchungstext
            if (lblBuchungstext2.Font.Underline && _saveRow != null)
            {
                qryDebitor["Buchungstext"] = _saveRow["Buchungstext"];
                edtBuchungstext.TabStop = false;
            }
            else
            {
                edtBuchungstext.TabStop = true;
            }

            //Monatsbudget
            if (kissLabel23.Font.Underline && _saveRow != null)
            {
                // qryMonatsbudget.Find(string.Format("KgBudgetID={0}", _saveRow["KgBudgetID"]));
                qryMonatsbudget.Find(string.Format("Monat={0} AND Jahr={1}", _saveRow["Monat"], _saveRow["Jahr"]));
                grdMonatsbudget.TabStop = false;
            }
            else
            {
                grdMonatsbudget.TabStop = true;
            }

            //Debitor
            if (lblDebitor2.Font.Underline && _saveRow != null)
            {
                qryDebitor["Debitor"] = _saveRow["Debitor"];
                //  qryDebitor["DebitorNr"] = _saveRow["DebitorNr"];
                edtDebitor2.TabStop = false;
                SetDebitor((int)_saveRow["BaInstitutionID"], _saveRow["Debitor"].ToString(), _saveRow["ZusatzInfo"].ToString());
            }
            else
            {
                edtDebitor2.TabStop = true;
            }
        }

        private void DebitorVorbereiten()
        {
            qryDebitor.Fill();
            qryDebitor.Insert();
            qryDebitor["KgPositionsKategorieCode"] = 3; //Einnahmen
            qryDebitor["KgAuszahlungsTerminCode"] = 4; //Valuta
            qryDebitor["BuchungDatum"] = qryZahlungseingang["Datum"];
            qryDebitor["Mandant"] = qryZahlungseingang["Mandant"];
            qryDebitor["BaPersonID"] = qryZahlungseingang["BaPersonID"];
            qryDebitor["Betrag"] = qryZahlungseingang["Betrag"];
            qryDebitor["FaelligAm"] = qryZahlungseingang["Datum"];
            qryMonatsbudget.Fill(qryZahlungseingang["BaPersonID"]);
            try
            {
                while (Convert.ToInt32(qryMonatsbudget["Jahr"]) != ((DateTime)qryZahlungseingang["Datum"]).Year ||
                       Convert.ToInt32(qryMonatsbudget["Monat"]) != ((DateTime)qryZahlungseingang["Datum"]).Month)
                {
                    if (!qryMonatsbudget.Next()) break;
                }
            }
            catch { }
            CopyDebitorValues();
            _buchungstextDebitor.LoadBuchungstext(qryDebitor["KontoNr"], false);
        }

        private void FillQryAusgleiche()
        {
            if ((bool)qryZahlungseingang["Ausgeglichen"])
            {
                qryAusgleich.Fill(@"
                    --alle bereits zugewiesenen Posten
                    select KgBuchungID = BUC2.KgBuchungID,
                           Valuta      = BUC2.ValutaDatum,
                           Haben       = BUC2.HabenKtoNr,
                           Text        = BUC2.Text,
                           Betrag      = BUC2.Betrag,
                           RestBetrag  = (select BUC2.Betrag - sum(Betrag) from dbo.KgOpAusgleich WITH (READUNCOMMITTED) where OPBuchungID = AUS.OpBuchungID),
                           AusglBetrag = AUS.Betrag,
                           AUS.OpBuchungID,
                           AUS.AusgleichBuchungID,
                           SortKey = 1,
                           Debitor = INS.Name + IsNull( ', ' + INS.Adresse, '')
                    from   dbo.KgZahlungseingang ZEI WITH (READUNCOMMITTED)
                           inner join dbo.KgBuchung     BUC WITH (READUNCOMMITTED)  on BUC.KgZahlungseingangID = ZEI.KgZahlungseingangID
                           inner join dbo.KgOpAusgleich AUS WITH (READUNCOMMITTED)  on AUS.AusgleichBuchungID = BUC.KgBuchungID
                           inner join dbo.KgBuchung     BUC2 WITH (READUNCOMMITTED) on BUC2.KgBuchungID = AUS.OpBuchungID
                           left  join dbo.vwInstitution INS  on INS.BaInstitutionID = BUC2.BaInstitutionID
                    where  ZEI.KgZahlungseingangID = {0} and
                           BUC2.KgBuchungTypCode <> 5
                    order by SortKey, Valuta",
                    qryZahlungseingang["KgZahlungseingangID"]);

                grdAusgleich.GridStyle = GridStyleType.ReadOnly;
                colAusgleich.VisibleIndex = -1;
                btnAusgleich.Visible = false;
                btnAusgleichAufheben.Visible = true;

                edtKontoRestbetrag.EditMode = EditModeType.ReadOnly;
                edtTextRestbetrag.EditMode = EditModeType.ReadOnly;

                edtKontoRestbetrag.EditValue = DBNull.Value;
                edtTextRestbetrag.EditValue = DBNull.Value;
                edtBelegRestbetrag.EditValue = DBNull.Value;

                SqlQuery qryRestBetrag = DBUtil.OpenSQL(@"
                    declare @Text   varchar(200),
                            @Betrag money,
                            @Konto  varchar(200),
                            @Beleg  int

                    -- via KgOPAusgleich  (Soll/Haben Tausch, falls Restbetrag ursprünglich negativ war)
                    select @Text   = BUC2.Text,
                           @Betrag = case when BUC.HabenKtoNr = BUC2.SollKtoNr
                                     then BUC2.Betrag
                                     else -BUC2.Betrag
                                     end,
                           @Konto  = case when BUC.HabenKtoNr = BUC2.SollKtoNr
                                     then KTOH.KontoNr + ' ' + KTOH.KontoName
                                     else KTOS.KontoNr + ' ' + KTOS.KontoName
                                     end,
                           @Beleg  = BUC2.KgBuchungID
                    from   dbo.KgBuchung BUC WITH (READUNCOMMITTED)
                           inner join dbo.KgOpAusgleich AUS WITH (READUNCOMMITTED)  on AUS.AusgleichBuchungID = BUC.KgBuchungID
                           inner join dbo.KgBuchung     BUC2 WITH (READUNCOMMITTED) on BUC2.KgBuchungID = AUS.OpBuchungID
                           left  join dbo.KgKonto       KTOS WITH (READUNCOMMITTED) on KTOS.KgPeriodeID = BUC2.KgPeriodeID and KTOS.KontoNr = BUC2.SollKtoNr
                           left  join dbo.KgKonto       KTOH WITH (READUNCOMMITTED) on KTOH.KgPeriodeID = BUC2.KgPeriodeID and KTOH.KontoNr = BUC2.HabenKtoNr
                    where  BUC.KgZahlungseingangID = {0} and
                           BUC2.KgBuchungTypCode = 5

                    if @Text is null
                        -- DirektBuchung
                        select @Text   = BUC.Text,
                               @Betrag = BUC.Betrag,
                               @Konto  = KTOH.KontoNr + ' ' + KTOH.KontoName,
                               @Beleg  = BUC.KgBuchungID
                        from   dbo.KgBuchung BUC WITH (READUNCOMMITTED)
                               left join dbo.KgKonto       KTOH WITH (READUNCOMMITTED) on KTOH.KgPeriodeID = BUC.KgPeriodeID and KTOH.KontoNr = BUC.HabenKtoNr
                               left join dbo.KgOpAusgleich AUS WITH (READUNCOMMITTED)  on AUS.AusgleichBuchungID = BUC.KgBuchungID
                        where  BUC.KgZahlungseingangID = {0} and
                               AUS.KgOpAusgleichID is null

                    select Text = @Text, Betrag = @Betrag, Konto = @Konto, Beleg = @Beleg",
                    qryZahlungseingang["KgZahlungseingangID"]);

                edtKontoRestbetrag.EditValue = qryRestBetrag["Konto"];
                edtTextRestbetrag.EditValue = qryRestBetrag["Text"];
                edtRestbetrag.EditValue = qryRestBetrag["Betrag"];
                edtBelegRestbetrag.EditValue = qryRestBetrag["Beleg"];
                edtRestbetrag.BackColor = _clrGreen;
                edtRestbetrag.Visible = !DBUtil.IsEmpty(qryRestBetrag["Betrag"]);
                lblRestbetrag.Visible = !DBUtil.IsEmpty(qryRestBetrag["Betrag"]);
            }
            else
            {
                qryAusgleich.Fill(@"
                    --alle offenen Posten dieses Klienten
                    select KgBuchungID = BUC.KgBuchungID,
                           Valuta      = BUC.ValutaDatum,
                           Haben       = BUC.HabenKtoNr,
                           Text        = BUC.Text,
                           Betrag      = BUC.Betrag,
                           RestBetrag  = IsNull((select BUC.Betrag - sum(Betrag) from dbo.KgOpAusgleich WITH (READUNCOMMITTED) where OPBuchungID = BUC.KgBuchungID), BUC.Betrag),
                           AusglBetrag = CAST( 0 as money ),
                           OpBuchungID = null,
                           AusgleichBuchungID = null,
                           SortKey = 0,
                           Debitor = INS.Name + IsNull( ', ' + INS.Adresse, '')
                    from   dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                           inner join dbo.KgPeriode     PER WITH (READUNCOMMITTED)  on PER.FaLeistungID = LEI.FaLeistungID
                           inner join dbo.KgBuchung     BUC WITH (READUNCOMMITTED)  on BUC.KgPeriodeID = PER.KgPeriodeID and
                                                            (BUC.KgZahlungseingangID <> {0} OR BUC.KgZahlungseingangID IS NULL ) and
                                                            BUC.KgAusgleichstatusCode in (1,2) -- offen + Teilausgleich
                           inner join dbo.KgKonto       KTO WITH (READUNCOMMITTED)  on KTO.KgPeriodeID = BUC.KgPeriodeID and
                                                            KTO.KontoNr = BUC.SollKtoNr and
                                                            KTO.KgKontoartCode = 2 -- Debitorkonto
                           left  join dbo.vwInstitution INS  on INS.BaInstitutionID = BUC.BaInstitutionID
                    where  LEI.BaPersonID = {1} and
                           LEI.FaProzessCode = 500 and
                           BUC.KgBuchungStatusCode IN (2,10) and -- OP
                           (IsNull((select BUC.Betrag - sum(Betrag) from dbo.KgOpAusgleich WITH (READUNCOMMITTED) where OPBuchungID = BUC.KgBuchungID), BUC.Betrag)) <> 0
                    order by SortKey, Valuta",
                    qryZahlungseingang["KgZahlungseingangID"],
                    qryZahlungseingang["BaPersonID"]);

                grdAusgleich.GridStyle = GridStyleType.Editable;
                colAusgleich.VisibleIndex = 6;
                edtRestbetrag.Visible = true;
                lblRestbetrag.Visible = true;
                btnAusgleich.Visible = true;
                btnAusgleichAufheben.Visible = false;

                edtKontoRestbetrag.EditMode = EditModeType.Normal;
                edtTextRestbetrag.EditMode = EditModeType.Normal;
                edtKontoRestbetrag.EditValue = DBNull.Value;
                edtKontoRestbetrag.LookupID = DBNull.Value;
                edtTextRestbetrag.EditValue = DBNull.Value;
                edtBelegRestbetrag.EditValue = DBNull.Value;

                UpdateAusgleichSum();
            }
        }

        private void FillQryAusgleicheRL()
        {
            if ((bool)qryZahlungseingang["Ausgeglichen"])
            {
                qryAusgleichRL.Fill(@"
                    --alle bereits zugewiesenen Posten
                    select KgBuchungID = BUC3.KgBuchungID,
                           Valuta      = BUC3.ValutaDatum,
                           Haben       = BUC3.HabenKtoNr,
                           SollKtoNr   = BUC3.SollKtoNr,
                           Text        = BUC3.Text,
                           Betrag      = BUC3.Betrag,
                           AusglBetrag = AUS.Betrag,
                           AUS.OpBuchungID,
                           AUS.AusgleichBuchungID,
                           SortKey     = 1,
                           Kreditor    = KRE.Kreditor,
                           BUC3.KgBuchungStatusCode
                    from   dbo.KgZahlungseingang   ZEI  WITH (READUNCOMMITTED)
                      inner join dbo.KgBuchung     BUC  WITH (READUNCOMMITTED) ON BUC.KgZahlungseingangID = ZEI.KgZahlungseingangID -- Rückläuferbuchung Bank->Kreditoren
                      inner join dbo.KgOpAusgleich AUS  WITH (READUNCOMMITTED) ON AUS.AusgleichBuchungID  = BUC.KgBuchungID
                      inner join dbo.KgBuchung     BUC2 WITH (READUNCOMMITTED) ON BUC2.KgBuchungID        = AUS.OpBuchungID         -- Auszahlungsbuchung Kreditoren->Bank
                      inner join dbo.KgOpAusgleich AUS2 WITH (READUNCOMMITTED) ON AUS2.AusgleichBuchungID = BUC2.KgBuchungID
                      inner join dbo.KgBuchung     BUC3 WITH (READUNCOMMITTED) ON BUC3.KgBuchungID        = AUS2.OpBuchungID        -- Auszahlungsbuchung Aufwand->Kreditoren
                      left  join dbo.vwKreditor    KRE  WITH (READUNCOMMITTED) ON KRE.BaZahlungswegID     = BUC3.BaZahlungswegID
                    where  ZEI.KgZahlungseingangID = {0} and
                           BUC2.KgBuchungTypCode <> 5
                    order by SortKey, Valuta",
                    qryZahlungseingang["KgZahlungseingangID"]);

                //grdAusgleichRL.GridStyle = GridStyleType.ReadOnly;
                //colAusgleichRL.VisibleIndex = -1;
                btnAusgleichRL.Visible = false;
                btnAusgleichAufhebenRL.Visible = true;
                //Nur Status 'Rückläufer' darf wieder zurückgenommen werden. Für 'Rückläufer korrigiert' ist bereits eine neue Auszahlung erstellt worden
                btnAusgleichAufhebenRL.Enabled = qryAusgleichRL.Count > 0 && (int)qryAusgleichRL["KgBuchungStatusCode"] == 9;

                edtRestbetragRL.BackColor = _clrGreen;
            }
            else
            {
                qryAusgleichRL.Fill(@"
                    --alle offenen Posten dieses Klienten
                    select KgBuchungID = BUC.KgBuchungID,
                           Valuta      = BUC.ValutaDatum,
                           Haben       = BUC.HabenKtoNr,
                           SollKtoNr   = BUC.SollKtoNr,
                           Text        = BUC.Text,
                           Betrag      = BUC.Betrag,
                           AusglBetrag = CAST( 0 as money ),
                           OpBuchungID = null,
                           AusgleichBuchungID = null,
                           SortKey     = 0,
                           Kreditor    = KRE.Kreditor,
                           BUC.KgBuchungStatusCode
                    from   dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                      inner join dbo.KgPeriode     PER WITH (READUNCOMMITTED) ON PER.FaLeistungID = LEI.FaLeistungID
                      inner join dbo.KgBuchung     BUC WITH (READUNCOMMITTED) ON BUC.KgPeriodeID = PER.KgPeriodeID and
                                                                                (BUC.KgZahlungseingangID <> {0} OR BUC.KgZahlungseingangID IS NULL) and
                                                                                 BUC.KgAusgleichstatusCode = 1 -- Position darf nicht ausgeglichen sein
                      inner join dbo.KgKonto       KTO WITH (READUNCOMMITTED) ON KTO.KgPeriodeID = BUC.KgPeriodeID and
                                                                                 KTO.KontoNr = BUC.HabenKtoNr and
                                                                                 KTO.KgKontoartCode = 3 -- Kreditorkonto
                      left  join dbo.vwKreditor    KRE WITH (READUNCOMMITTED) ON KRE.BaZahlungswegID = BUC.BaZahlungswegID
                    where  LEI.BaPersonID = {1} and
                           LEI.FaProzessCode = 500 and
                           BUC.KgBuchungStatusCode IN (6) and -- ausgeglichen; damit es einen Rückläufer gibt, muss die Zahlung zuvor ausbezahlt worden sein
                           ({2} = 0 OR BUC.Betrag = {3})
                    order by SortKey, Valuta",
                    qryZahlungseingang["KgZahlungseingangID"],
                    qryZahlungseingang["BaPersonID"],
                    edtNurGleicherBetrag.Checked,
                    qryZahlungseingang["Betrag"]);

                //grdAusgleichRL.GridStyle = GridStyleType.Editable;
                //colAusgleichRL.VisibleIndex = 6;
                btnAusgleichRL.Visible = true;
                btnAusgleichAufhebenRL.Visible = false;

                UpdateAusgleichRLSum();
            }
        }

        private void SetDebitor(int baInstitutionID, string debitor, string zusatzinfo)
        {
            qryDebitor["BaInstitutionID"] = baInstitutionID;
            qryDebitor["Debitor"] = debitor;
            qryDebitor["ZusatzInfo"] = zusatzinfo;
        }

        private int[] UpdateAusgleichRLSum()
        {
            return UpdateSum(qryAusgleichRL, false, btnAusgleichRL, edtRestbetragRL);
        }

        private int[] UpdateAusgleichSum()
        {
            return UpdateSum(qryAusgleich, !DBUtil.IsEmpty(edtKontoRestbetrag.LookupID) && !DBUtil.IsEmpty(edtTextRestbetrag.EditValue), btnAusgleich, edtRestbetrag);
        }

        private void UpdateCounters()
        {
            edtAnzahl.EditValue = qryZahlungseingang.Count;
            decimal sum = 0;
            foreach (DataRow row in qryZahlungseingang.DataTable.Rows)
            {
                if (row["Betrag"] is decimal)
                {
                    sum += (decimal)row["Betrag"];
                }
            }
            edtTotal.EditValue = sum;
        }

        private int[] UpdateSum(SqlQuery qry, bool restbetragZugeordnet, KissButton btn, KissCalcEdit edt)
        {
            qry.EndCurrentEdit();
            List<int> kgBuchungIDs = new List<int>();
            decimal summe = decimal.Zero;
            foreach (DataRow row in qry.DataTable.Rows)
            {
                decimal? ausglBetrag = row["AusglBetrag"] as decimal?;
                if (ausglBetrag.HasValue)
                {
                    if (ausglBetrag.Value < 0m)
                    {
                        row["AusglBetrag"] = 0m;
                        ausglBetrag = 0m;
                    }
                    summe += ausglBetrag.Value;
                    if (ausglBetrag.Value > 0m)
                        kgBuchungIDs.Add((int)row["KgBuchungID"]);
                }
            }
            decimal? betragSoll = qryZahlungseingang["Betrag"] as decimal?;

            if (!betragSoll.HasValue)
            {
                betragSoll = 0m;
            }

            edt.EditValue = betragSoll - summe;

            if (betragSoll == summe || restbetragZugeordnet)
            {
                btn.Enabled = !(bool)qryZahlungseingang["Ausgeglichen"];
                edt.BackColor = _clrGreen;
            }
            else
            {
                btn.Enabled = false;
                edt.BackColor = _clrRed;
            }
            return kgBuchungIDs.ToArray();
        }

        #endregion

        #endregion
    }
}