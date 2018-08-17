using System;
using System.Data;
using System.Drawing;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

namespace KiSS4.Sozialhilfe
{
    internal partial class CtlWhLeistung : KissUserControl
    {
        #region Fields

        #region Private Fields

        private DateTime? _leiOrigDatumBis;

        #endregion

        #endregion

        #region Constructors

        public CtlWhLeistung()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
        }

        public CtlWhLeistung(Image titelImage, string titelText, int faLeistungID)
            : this()
        {
            picTitel.Image = titelImage;
            lblTitel.Text = titelText;

            qryFaLeistung.Fill(faLeistungID);
            qryBgFinanzplan.Fill(faLeistungID);
            qryVorsaldo.Fill(qryFaLeistung["KbKostenstelleID"]);

            colBgBewilligungStatusCode.ColumnEdit = grdBgFinanzplan.GetLOVLookUpEdit("BgBewilligungStatus");

            _leiOrigDatumBis = qryFaLeistung[DBO.FaLeistung.DatumBis] as DateTime?;

            if (DBUtil.IsEmpty(qryFaLeistung[DBO.FaLeistung.GemeindeCode]) && DBUtil.IsEmpty(edtZustaendigeGemeinde.EditValue))
            {
                //only 1 item in a mandatory field --> set value directly
                var queryZustaendigeGemeinde = ((SqlQuery)edtZustaendigeGemeinde.Properties.DataSource);

                if (queryZustaendigeGemeinde.Count == 1)
                {
                    qryFaLeistung[DBO.FaLeistung.GemeindeCode] = queryZustaendigeGemeinde["Code"];
                }
                else if (qryFaLeistung.CanUpdate)
                {
                    qryFaLeistung.RowModified = true;
                }
            }

            //Nur Benutzer mit Spezialrecht CtlWhLeistung_VorsaldoFremdsystemMutieren d�rfen den Vorsaldo editieren
            qryVorsaldo.CanUpdate = DBUtil.UserHasRight("CtlWhLeistung_VorsaldoFremdsystemMutieren");
            qryVorsaldo.EnableBoundFields();
        }

        #endregion

        #region EventHandlers

        private void qryFaLeistung_AfterPost(object sender, EventArgs e)
        {
            if (Session.Transaction == null)
                return;

            // Falls Meldungen nach der Modulreaktivierung angezeigt werden sollen
            var infoAfterReactivation = false;

            try
            {
                // Pendenzen zu Doppelunterstr�tzung WH und Inkasso
                var leiDatumBis = qryFaLeistung[DBO.FaLeistung.DatumBis] as DateTime?;
                int senderId = Session.User.UserID;
                int finanzplanId = Convert.ToInt32(qryBgFinanzplan[DBO.BgFinanzplan.BgFinanzplanID]);
                var personIdCsv = DBUtil.ExecuteScalarSQL(@"
                    SELECT dbo.Conc(BaPersonID)
                    FROM dbo.BgFinanzplan_BaPerson WITH (READUNCOMMITTED)
                    WHERE BgFinanzplanID = {0}
                      AND IstUnterstuetzt = 1",
                        finanzplanId) as string;

                if (!_leiOrigDatumBis.HasValue && leiDatumBis.HasValue && !string.IsNullOrEmpty(personIdCsv))
                {
                    // Sozialhilfe wurde abgeschlossen
                    ShUtil.CreateTaskForDoubleSupport_SozialhilfeAbgeschlossen(senderId, personIdCsv);
                }
                else if (_leiOrigDatumBis.HasValue && !leiDatumBis.HasValue && !string.IsNullOrEmpty(personIdCsv))
                {
                    // Sozialhilfe wurde reaktiviert
                    ShUtil.CreateTaskForDoubleSupport_SozialhilfeReaktiviert(senderId, personIdCsv);

                    // Meldungen nach der Reaktivierung anzeigen
                    infoAfterReactivation = true;
                }

                _leiOrigDatumBis = leiDatumBis;

                //commit transaction
                Session.Commit();
            }
            catch (Exception)
            {
                //rollback
                Session.Rollback();

                throw;
            }

            FormController.SendMessage("FrmFall", "Action", "RefreshTree");

            if (infoAfterReactivation)
            {
                KissMsg.ShowInfo(typeof(CtlWhLeistung).Name, "WhASVAnmeldungAnpassen", "Die ASV-Anmeldung muss angepasst werden.");
            }
        }

        private void qryFaLeistung_BeforeDelete(object sender, EventArgs e)
        {
            // delete autogenerated tasks (EFB)
            DBUtil.ExecuteScalarSQL(@"
                DELETE FROM dbo.XTaskAutogenerated
                WHERE XTaskID IN (SELECT XTaskID
                                  FROM XTask
                                  WHERE FaLeistungID = {0});

                DELETE FROM dbo.XTask
                WHERE FaLeistungID = {0};",
                qryFaLeistung[DBO.FaLeistung.FaLeistungID]);
        }

        private void qryFaLeistung_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            qryBgFinanzplan.Refresh();

            if (qryBgFinanzplan.Count > 0)
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(
                        "CtlWhLeistung",
                        "FaLeistungL�schen",
                        "Diese Leistung kann nicht gel�scht werden.\r\n\r\nSie enth�lt mindestens 1 Finanzplan."));
            }
        }

        private void qryFaLeistung_BeforePost(object sender, EventArgs e)
        {
            txtInfo.Text = string.Empty;

            DBUtil.CheckNotNullField(edtDatumVon, lblDatumVon.Text);
            DBUtil.CheckNotNullField(edtZustaendigeGemeinde, lblZustGemeinde.Text);

            // DatumBis vor DatumVon pr�fen
            if (!DBUtil.IsEmpty(qryFaLeistung[DBO.FaLeistung.DatumBis]) &&
                ((DateTime)qryFaLeistung[DBO.FaLeistung.DatumBis]).Date < ((DateTime)qryFaLeistung[DBO.FaLeistung.DatumVon]).Date)
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(
                        "CtlWhLeistung",
                        "FallVorEnde",
                        "Der Fall beginnt nach seinem Ende",
                        KissMsgCode.MsgInfo),
                    edtDatumBis);
            }

            //Kontrolle offene Pendenzen
            if (!DBUtil.IsEmpty(qryFaLeistung[DBO.FaLeistung.DatumBis]))
            {
                int countPendenzen = Utils.GetAnzahlOffenePendenzen((int)qryFaLeistung[DBO.FaLeistung.FaLeistungID]);
                if (countPendenzen > 0)
                {
                    string msg =
                        string.Format(
                            KissMsg.GetMLMessage(
                                "CtlWhLeistung",
                                "OffenePendenzenVorhanden",
                                string.Format(
                                    "Es existieren noch {0} offene Pendenzen zu der abzuschliessenden Leistung.",
                                    countPendenzen)));
                    KissMsg.ShowInfo(msg);
                }
            }

            // �berschneidene Leistungen pr�fen
            SqlQuery qryLeistungUeberschneidung = DBUtil.OpenSQL(@"
                SELECT TOP 1 FaLeistungID
                FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                WHERE FaFallID = {0}
                  AND ModulID = {1}
                  AND ISNULL(FaProzessCode, 0) = ISNULL({2}, 0)
                  AND FaLeistungID <> ISNULL({3}, 0)
                  AND dbo.fnDateOf({4})                     <= dbo.fnDateOf(ISNULL(DatumBis, '99991231'))
                  AND dbo.fnDateOf(ISNULL({5}, '99991231')) >= dbo.fnDateOf(DatumVon);",
                qryFaLeistung[DBO.FaLeistung.FaFallID],
                qryFaLeistung[DBO.FaLeistung.ModulID],
                qryFaLeistung[DBO.FaLeistung.FaProzessCode],
                qryFaLeistung[DBO.FaLeistung.FaLeistungID],
                qryFaLeistung[DBO.FaLeistung.DatumVon],
                qryFaLeistung[DBO.FaLeistung.DatumBis]);

            if (!qryLeistungUeberschneidung.IsEmpty)
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(
                        "CtlWhLeistung",
                        "UeberschneidungDatum_v1",
                        "Es gibt eine weitere Sozialhilfe, welche sich zeitlich mit dieser �berschneidet",
                        KissMsgCode.MsgInfo),
                    edtDatumVon);
            }

            // Pr�fen ob ein Finanzplan vor diesem Datum vorhanden ist
            SqlQuery qryBgFinanzplanUeberschneidung =
                DBUtil.OpenSQL(@"
                    SELECT TOP 1 BgFinanzplanID
                    FROM dbo.BgFinanzplan WITH (READUNCOMMITTED)
                    WHERE FaLeistungID = {0} AND IsNull(DatumVon, GeplantVon) < {1}",
                    qryFaLeistung[DBO.FaLeistung.FaLeistungID],
                    Utils.firstDayOfMonth((DateTime)qryFaLeistung[DBO.FaLeistung.DatumVon]));

            if (!qryBgFinanzplanUeberschneidung.IsEmpty)
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(
                        "CtlWhLeistung",
                        "MinEinFinanzplanVorDatum",
                        "Datum von ung�ltig. Mindestens ein Finanzplan beginnt vor diesem Datum.",
                        KissMsgCode.MsgInfo),
                    edtDatumVon);
            }

            if (!DBUtil.IsEmpty(qryFaLeistung[DBO.FaLeistung.DatumBis]))
            {
                // Mindestens ein Finanzplan endet nach diesem Datum
                SqlQuery qryBgFinanzplanVorhanden =
                    DBUtil.OpenSQL(@"
                        SELECT TOP 1 BgFinanzplanID
                        FROM dbo.BgFinanzplan WITH (READUNCOMMITTED)
                        WHERE FaLeistungID = {0}
                          AND dbo.fnDateOf(ISNULL(DatumBis, GeplantBis)) > {1}",
                        qryFaLeistung[DBO.FaLeistung.FaLeistungID],
                        qryFaLeistung[DBO.FaLeistung.DatumBis]);

                if (!qryBgFinanzplanVorhanden.IsEmpty)
                {
                    throw new KissInfoException(
                        KissMsg.GetMLMessage(
                            "CtlWhLeistung",
                            "MinEinFinanzplanNachDatum",
                            "Datum bis ung�ltig. Mindestens ein Finanzplan endet nach diesem Datum.",
                            KissMsgCode.MsgInfo),
                        edtDatumBis);
                }

                // Beim Abschliessen der Sozialhilfe, ASVS Abschlussdaten pr�fen
                CheckAsvAbschlussdaten();

                // Beim Abschliessen der Sozialhilfe, offene Abzahlungskonti pr�fen
                CheckOffeneAbzahlungskonto();

                // Beim Abschliessen der Sozialhilfe, Kontrolle Saldo Vorabzugkonti
                string msg = CheckOffeneVorabzugskonto();
                if (!string.IsNullOrEmpty(msg))
                {
                    if (!KissMsg.ShowQuestion(msg))
                    {
                        throw new KissCancelException();
                    }
                }
            }

            Session.BeginTransaction();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override bool OnSaveData()
        {
            //Vorsaldo (in separatem Query) speichern
            qryVorsaldo.Post(true);
            return base.OnSaveData();
        }

        public override void OnUndoDataChanges()
        {
            //Vorsaldo (in separatem Query) zur�cksetzen
            qryVorsaldo.Cancel();

            base.OnUndoDataChanges();

            txtInfo.Text = "";
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Wenn ASV-Daten vorhanden sind, m�ssen diese beim Abschliessen der S-Leistung gepr�ft werden.
        /// Zur Pr�fung wird immer das j�ngste (Datum Created) pro Klient genommen
        /// - AsvDatum Bis darf nicht leer sein
        /// - ASVDatum Bis darf nicht gr�sser sein als das Datum Bis der S-Leistung
        /// - ASV muss exportiert worden sein
        /// - widerrufene ASV werden nicht mehr ber�cksichtigt
        /// </summary>
        private void CheckAsvAbschlussdaten()
        {
            var qryAsvAbschlussdaten =
                DBUtil.OpenSQL(
                    @"
                     SELECT * FROM (
                           SELECT
                             DatumBis,
                             ASVSEintragStatusCode,
                             Zeilennummer = ROW_NUMBER () OVER (PARTITION BY BaPersonID ORDER BY Created DESC)
                           FROM dbo.Whasvseintrag
                           WHERE FaLeistungid = {0}
                             AND ASVSEintragStatusCode NOT IN (4,5)) AS TempASVS
                     WHERE Zeilennummer = 1",
                    qryFaLeistung[DBO.FaLeistung.FaLeistungID]);
            // Keine ASVS-Daten vorhanden, S-Leistung kann abgeschlossen werden
            if (qryAsvAbschlussdaten.DataTable.Rows.Count == 0)
            {
                return;
            }
            foreach (DataRow asvsRow in qryAsvAbschlussdaten.DataTable.Rows)
            {
                int asvEintragCode = Utils.ConvertToInt(asvsRow["ASVSEintragStatusCode"]);
                // Datum Bis nicht vorhanden
                if (DBUtil.IsEmpty(asvsRow["DatumBis"]) || (DateTime)asvsRow["DatumBis"] > (DateTime)qryFaLeistung[DBO.FaLeistung.DatumBis])
                {
                    throw new KissInfoException(
                        KissMsg.GetMLMessage(
                            "CtlWhLeistung",
                            "ASVSDatumBisGroesserAlsAbschlussdatum_v2",
                            "Die Sozialhilfe kann fr�hestens am ASV-'Datum bis' abgeschlossen werden.",
                            KissMsgCode.MsgInfo),
                        edtDatumVon);
                }
            }
        }

        private void CheckOffeneAbzahlungskonto()
        {
            if (!_leiOrigDatumBis.HasValue)
            {
                SqlQuery qryBgSpezkontoOffen = GetOffeneSpezkonto((int)qryFaLeistung[DBO.FaLeistung.FaLeistungID], BgSpezkontoTyp.Abzahlungskonto);

                if (!qryBgSpezkontoOffen.IsEmpty)
                {
                    txtInfo.Text = KissMsg.GetMLMessage(Name, "OffeneAbzahlungskonto", "Offene Abzahlungskonto m�ssen zuerst abgeschlossen werden");

                    do
                    {
                        txtInfo.Text = txtInfo.Text + Environment.NewLine + "   - " +
                                       KissMsg.GetMLMessage(
                                           Name,
                                           "AbzahlungskontoInfo",
                                           "{0} ({1}, {2}) mit Startsaldo={3} und Saldo={4}",
                                           qryBgSpezkontoOffen[DBO.BgSpezkonto.NameSpezkonto],
                                           ((DateTime)qryBgSpezkontoOffen[DBO.BgSpezkonto.DatumVon]).ToString("dd.MM.yyyy"),
                                           ((DateTime)qryBgSpezkontoOffen[DBO.BgSpezkonto.DatumBis]).ToString("dd.MM.yyyy"),
                                           ((decimal)qryBgSpezkontoOffen[DBO.BgSpezkonto.StartSaldo]).ToString("N2"),
                                           ((decimal)qryBgSpezkontoOffen["Saldo"]).ToString("N2"));
                    }
                    while (qryBgSpezkontoOffen.Next());

                    throw new KissInfoException(
                        KissMsg.GetMLMessage(
                            Name,
                            "OffeneAbzahlungskonto",
                            "Offene Abzahlungskonto m�ssen zuerst abgeschlossen werden"),
                        edtDatumBis);
                }
            }
        }

        private string CheckOffeneVorabzugskonto()
        {
            if (!_leiOrigDatumBis.HasValue)
            {
                SqlQuery qryBgSpezkontoOffen = GetOffeneSpezkonto((int)qryFaLeistung[DBO.FaLeistung.FaLeistungID], BgSpezkontoTyp.Vorabzugkonto);
                string msg = string.Empty;

                if (!qryBgSpezkontoOffen.IsEmpty)
                {
                    //Teil 1 der Message holen
                    msg = KissMsg.GetMLMessage(Name, "OffeneVorabzugskontoAnfang", "Es sind noch Vorabzugkonti mit Saldo ungleich 0.00 vorhanden.") +
                          Environment.NewLine;

                    do
                    {
                        string datumBisString = string.Empty;
                        DateTime? datumbis = qryBgSpezkontoOffen[DBO.BgSpezkonto.DatumBis] as DateTime?;
                        if (datumbis.HasValue)
                        {
                            datumBisString = datumbis.Value.ToString("dd.MM.yyyy");
                        }
                        msg = msg + Environment.NewLine +
                                     KissMsg.GetMLMessage(
                                           Name,
                                           "OffeneVorabzugskontoInfo",
                                           "{0} ({1}, {2}) hat den Startsaldo={3} und Saldo={4}",
                                           qryBgSpezkontoOffen[DBO.BgSpezkonto.NameSpezkonto],
                                           ((DateTime)qryBgSpezkontoOffen[DBO.BgSpezkonto.DatumVon]).ToString("dd.MM.yyyy"),
                                           datumBisString,
                                           ((decimal)qryBgSpezkontoOffen[DBO.BgSpezkonto.StartSaldo]).ToString("N2"),
                                           ((decimal)qryBgSpezkontoOffen["Saldo"]).ToString("N2"));
                    }
                    while (qryBgSpezkontoOffen.Next());
                    //Frage hinzuf�gen
                    msg = msg + Environment.NewLine + Environment.NewLine + KissMsg.GetMLMessage(Name, "OffeneVorabzugskontoEnde", "Wollen Sie die Sozialhilfe trotzdem schliessen?");
                    return msg;
                }
            }
            return string.Empty;
        }

        private SqlQuery GetOffeneSpezkonto(int faLeistung, BgSpezkontoTyp bgSpezkontotyp)
        {
            return DBUtil.OpenSQL(@"
                ;WITH BgSpezkonto_CTE
                AS
                (
                    SELECT
                      SPK.BgSpezkontoID,
                      SPK.NameSpezkonto,
                      SPK.StartSaldo,
                      SPK.DatumVon,
                      SPK.DatumBis,
                      Saldo = dbo.fnBgSpezkonto(SPK.BgSpezkontoID,3,default,default)
                    FROM dbo.BgSpezkonto SPK WITH (READUNCOMMITTED)
                    WHERE SPK.FaLeistungID = {0}
                      AND SPK.BgSpezkontoTypCode = {1}
                      AND ({1} <> 3 OR SPK.AbschlussgrundCode IS NULL) -- noch nicht abgeschlossen
                )

                SELECT *
                FROM BgSpezkonto_CTE
                WHERE Saldo > $0.00;",
                faLeistung, bgSpezkontotyp);
        }

        #endregion

        #endregion
    }
}