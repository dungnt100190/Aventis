using System;
using System.Data;
using System.Drawing;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Sozialhilfe.ZH
{
    public partial class CtlBgFPAusgaben : KissUserControl
    {
        private const int BG_GRUPPE_CODE_KRANKENKASSE = 3202;
        private const int BG_GRUPPE_CODE_MIETE = 3206;

        private readonly int _bgBudgetID;
        private readonly int _bgGruppeCode;
        private bool _beginTransactionInBeforePost;

        public CtlBgFPAusgaben(Image titelImage, string titelText, int bgBudgetID, int bgGruppeCode)
            : this()
        {
            picTitle.Image = titelImage;
            _bgBudgetID = bgBudgetID;
            _bgGruppeCode = bgGruppeCode;

            // Arrangiere Controls abhängig vom Gruppencode
            switch (_bgGruppeCode)
            {
                // Krankenkasse
                case BG_GRUPPE_CODE_KRANKENKASSE:
                    colBetrag.Caption = "Prämie";
                    colReduktion.Caption = "IPV";
                    colTotal.Caption = "Unterstützung";
                    lblBemerkung.Text = "SEK Entscheid";
                    lblBetrag.Text = "Prämie";
                    lblReduktion.Text = "IPV";

                    // Total wird berechnet
                    edtTotal.EditMode = EditModeType.ReadOnly;

                    // Verstecke Institution
                    lblInstitution.Visible = false;
                    edtInstitution.Visible = false;
                    edtAdresse.Visible = false;

                    // Verstecke Kennzahlen
                    fraKennzahlen.Visible = false;

                    break;

                // Miete
                case BG_GRUPPE_CODE_MIETE:
                    colBetrag.Caption = "Miete BE";
                    colReduktion.Caption = "Reduktion";
                    colTotal.Caption = "Miete UE";
                    lblBemerkung.Text = "SL/SEK Entscheid";
                    lblBetrag.Text = "Miete BE";
                    lblReduktion.Text = "Reduktion";
                    lblTotal.Text = "Miete UE";

                    // Verstecke Reduktion
                    colReduktion.Visible = false;
                    lblMinus.Visible = false;
                    lblReduktion.Visible = false;
                    edtReduktion.Visible = false;

                    // Verstecke Institution
                    lblInstitution.Visible = false;
                    edtInstitution.Visible = false;
                    edtAdresse.Visible = false;

                    // Verschiebe Total
                    lblTotal.Left = lblMinus.Left;
                    edtTotal.Left = edtReduktion.Left;

                    // Verstecke Kommentar
                    lblKommentar.Visible = false;

                    // Verstecke Person
                    lblBaPersonID.Visible = false;
                    edtBaPersonID.Visible = false;
                    colBaPersonID.Visible = false;
                    colPersNr.Visible = false;

                    // Schiebe die Buttons nach Links
                    btnPositionBewilligung.Left = 372;
                    btnPositionVerlauf.Left = 402;

                    break;

                // Alle anderen
                default:
                    // Verstecke Reduktion und Total
                    colReduktion.Visible = false;
                    colTotal.Visible = false;
                    lblMinus.Visible = false;
                    lblReduktion.Visible = false;
                    edtReduktion.Visible = false;
                    lblTotal.Visible = false;
                    edtTotal.Visible = false;

                    // Verstecke Kommentar
                    lblKommentar.Visible = false;

                    // Verstecke Kennzahlen
                    fraKennzahlen.Visible = false;

                    // Schiebe die Buttons nach Links
                    btnPositionBewilligung.Left = 211;
                    btnPositionVerlauf.Left = 241;
                    break;
            }

            qryBgFinanzplan = DBUtil.OpenSQL(@"
                SELECT FLE.FaFallID, FLE.FaLeistungID, SFP.BgFinanzplanID,
                  LeiDatumBis   = FLE.DatumBis,
                  FPStatus      = SFP.BgBewilligungStatusCode,
                  FinanzplanVon = IsNull(SFP.DatumVon, SFP.GeplantVon),
                  FinanzplanBis = IsNull(SFP.DatumBis, SFP.GeplantBis),
                  AnpassenVon   = IsNull((SELECT MAX(DATEADD(m, 1, dbo.fnDateSerial(Jahr, Monat, 1))) FROM BgBudget
                                          WHERE BgFinanzplanID = SFP.BgFinanzplanID AND MasterBudget = 0
                                            AND BgBewilligungStatusCode >= 5), SFP.GeplantVon),
                  AnpassenBis   = SFP.DatumBis
                FROM BgBudget             BBG
                  INNER JOIN BgFinanzplan SFP ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
                  INNER JOIN FaLeistung   FLE ON FLE.FaLeistungID = SFP.FaLeistungID
                WHERE BBG.BgBudgetID = {0}"
                , bgBudgetID);

            lblTitel.Text = string.Format(lblTitel.Text, qryBgFinanzplan["FinanzplanVon"], qryBgFinanzplan["FinanzplanBis"], titelText);

            ShUtil.GetPersonen_Unterstuetzt(_bgBudgetID);

            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT PRS.BaPersonID, PRS.NameVorname, PRS.Name, PRS.Vorname, LT = CASE WHEN LST.BaPersonID = PRS.BaPersonID THEN 0 ELSE 1 END,
                       Person = PRS.NameVorname + ' (' + isNull(convert(varchar,PRS.AlterMortal),'-') + isNull(',' + GES.ShortText,'') + ')'
                FROM BgBudget                       BBG
                  INNER JOIN BgFinanzplan           SFP ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
                  INNER JOIN FaLeistung             LST ON LST.FaLeistungID   = SFP.FaLeistungID
                  INNER JOIN BgFinanzplan_BaPerson  SPP ON SPP.BgFinanzplanID = BBG.BgFinanzplanID
                  INNER JOIN vwPerson               PRS ON PRS.BaPersonID     = SPP.BaPersonID
                  LEFT  JOIN XLOVCode               GES ON GES.LOVName = 'BaGeschlecht' AND GES.Code = PRS.GeschlechtCode
                WHERE BBG.BgBudgetID = {0} AND SPP.IstUnterstuetzt = 1
                UNION ALL SELECT NULL, '', '', '', 0, ''
                ORDER BY LT, PRS.Name, PRS.Vorname"
                , _bgBudgetID);

            colBaPersonID.ColumnEdit = grdBgPosition.GetLOVLookUpEdit(qry, "BaPersonID", "Person");
            edtBaPersonID.LoadQuery(qry, "BaPersonID", "Person");

            //Bewilligungsstati laden
            repositoryItemImageComboBox1.SmallImages = KissImageList.SmallImageList;
            SqlQuery qryStati = DBUtil.OpenSQL("select * from XLOVCode where LOVName = 'BgBewilligungStatus' order by SortKey");
            foreach (DataRow row in qryStati.DataTable.Rows)
            {
                repositoryItemImageComboBox1.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(
                    row["Text"].ToString(),
                    (int)row["Code"],
                    KissImageList.GetImageIndex(Convert.ToInt32(row["Value1"]))));
            }

            //Buchungsstati laden
            repositoryItemImageComboBox2.SmallImages = KissImageList.SmallImageList;
            qryStati = DBUtil.OpenSQL("select * from XLOVCode where LOVName = 'KbBuchungsStatus' order by SortKey");
            foreach (DataRow row in qryStati.DataTable.Rows)
            {
                repositoryItemImageComboBox2.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(
                    row["Text"].ToString(),
                    (int)row["Code"],
                    KissImageList.GetImageIndex(Convert.ToInt32(row["Value1"]))));
            }

            qryBgPosition.PostCompleted += qryBgPosition_PostCompleted;

            // Fülle die Positionen
            if (_bgGruppeCode == BG_GRUPPE_CODE_KRANKENKASSE)
            {
                // Krankenkasse: Hier müssen wir noch die PositionsArt 32021 (VVW aus GBL)
                //               mit-darstellen, zumindest solange diese PositionsArt noch verwendet
                //               wird in aktiven Budgets
                qryBgPosition.Fill(_bgBudgetID, _bgGruppeCode, 1, 32021);
            }
            else
            {
                qryBgPosition.Fill(_bgBudgetID, _bgGruppeCode, 0, 0);
            }

            if (_bgGruppeCode == BG_GRUPPE_CODE_MIETE)
            {
                // Lade die Miet-Kennzahlen
                qryWhKennzahlen.Fill(qryBgPosition["BgFinanzplanID"]);
            }
        }

        public CtlBgFPAusgaben()
        {
            InitializeComponent();
        }

        private bool AuswahlInstitutionFAMOZ(string searchString, bool buttonClicked)
        {
            bool cancel = false;
            searchString = searchString.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (buttonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryBgPosition["BaInstitutionID"] = DBNull.Value;
                    qryBgPosition["Institution"] = DBNull.Value;
                    qryBgPosition["Adresse"] = DBNull.Value;
                    return false;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();

            switch (searchString)
            {
                case "":
                    break;

                case ".":
                    // Institution aus Involvierte Stellen - FaInvolvierteInstitution Krankenkasse -
                    // BaKrankenversicherung Vermieter - BaWohnsituation Arbeitgeber - BaArbeit

                    cancel = !dlg.SearchData(@"
                        -- InvolvierteStelle
                        SELECT  Art              = 'involvierte Stelle',
                                Name             = INS.Name,
                                Adresse          = INS.Adresse,
                                Typ              = INS.Typ,
                                BaInstitutionID$ = INS.BaInstitutionID,
                                BaPersonID$      = null,
                                Adresse$         = INS.AdresseMehrzeilig,
                                SortKey$         = 2
                        FROM    FaInvolvierteInstitution INV
                                INNER JOIN vwInstitution INS ON INS.BaInstitutionID = INV.BaInstitutionID
                        WHERE   INV.FaFallID = {0}

                        UNION

                        -- Krankenkasse
                        SELECT  Art              = 'Krankenkasse',
                                Name             = INS.Name,
                                Adresse          = INS.Adresse,
                                Typ              = INS.Typ,
                                BaInstitutionID$ = INS.BaInstitutionID,
                                BaPersonID$      = null,
                                Adresse$         = INS.AdresseMehrzeilig,
                                SortKey$         = 3
                        FROM    FaFallPerson FAP
                                INNER JOIN BaKrankenversicherung KKV ON KKV.BaPersonID = FAP.BaPersonID
                                INNER JOIN vwInstitution         INS ON INS.BaInstitutionID = KKV.BaInstitutionID
                        WHERE   FAP.FaFallID = {0}

                        UNION

                        -- Vermieter
                        SELECT  Art              = 'Vermieter',
                                Name             = INS.Name,
                                Adresse          = INS.Adresse,
                                Typ              = INS.Typ,
                                BaInstitutionID$ = INS.BaInstitutionID,
                                BaPersonID$      = null,
                                Adresse$         = INS.AdresseMehrzeilig,
                                SortKey$         = 4
                        FROM    FaFallPerson FAP
                                INNER JOIN BaWohnsituationPerson WOP ON WOP.BaPersonID = FAP.BaPersonID
                                INNER JOIN BaWohnsituation       WOH ON WOH.BaWohnsituationID = WOP.BaWohnsituationID
                                INNER JOIN vwInstitution         INS ON INS.BaInstitutionID = WOH.BaInstitutionID
                        WHERE   FAP.FaFallID = {0}

                        UNION

                        -- Arbeitgeber
                        SELECT  Art              = 'Arbeitgeber',
                                Name             = INS.Name,
                                Adresse          = INS.Adresse,
                                Typ              = INS.Typ,
                                BaInstitutionID$ = INS.BaInstitutionID,
                                BaPersonID$      = null,
                                Adresse$         = INS.AdresseMehrzeilig,
                                SortKey$         = 5
                        FROM    FaFallPerson FAP
                                INNER JOIN BaArbeit      ARB ON ARB.BaPersonID = FAP.BaPersonID
                                INNER JOIN vwInstitution INS ON INS.BaInstitutionID = ARB.BaInstitutionID
                        WHERE   FAP.FaFallID = {0}

                        ORDER BY SortKey$, Name, Adresse
                        ",
                        qryBgPosition["FaFallID"].ToString(), buttonClicked);
                    break;

                default:
                    cancel = !dlg.SearchData(@"
              			SELECT Institution      = INS.Name,
                               Adresse          = INS.Adresse,
                               Typ              = INS.Typ,
                               BaInstitutionID$ = INS.BaInstitutionID,
                               BaPersonID$      = null,
                               Adresse$         = INS.AdresseMehrzeilig
                        FROM   vwInstitution INS
                        WHERE  INS.BaFreigabeStatusCode = 2 AND
                               (INS.Name LIKE '%' + {0} + '%' OR
                                INS.AdressZusatz LIKE '%' + {0} + '%')
              			ORDER BY Institution",
                        searchString,
                        buttonClicked, null, null, null);
                    break;
            }

            if (!cancel)
            {
                qryBgPosition["BaInstitutionID"] = dlg["BaInstitutionID$"];
                qryBgPosition["Institution"] = DBUtil.IsEmpty(dlg["Name"]) ? dlg["Institution"] : dlg["Name"];
                qryBgPosition["Adresse"] = dlg["Adresse$"];
            }
            return cancel;
        }

        private void btnPositionBewilligung_Click(object sender, EventArgs e)
        {
            if (!qryBgPosition.Post()) return;

            if (qryBgPosition.Count == 0)
            {
                btnPositionBewilligung.Visible = false;
                return;
            }

            BgBewilligungStatus status = (BgBewilligungStatus)qryBgPosition["BgBewilligungStatusCode"];

            if (status == BgBewilligungStatus.Erteilt)
            {
                if (WhUtil.FinanzplanPositionAufheben(this, qryBgPosition))
                {
                    return;
                }

                WhUtil.DeleteVerrechnungsposition((int)qryBgPosition["BgPositionID"]);
            }
            else if (GetUserPermission())
            {
                DlgWhPositionVisieren dlg = new DlgWhPositionVisieren((int)qryBgPosition["BgPositionID"], null);

                dlg.ShowDialog(this);
                if (dlg.UserCancel)
                {
                    return;
                }

                Session.BeginTransaction();

                try
                {
                    // Schreibe zuerst die Bewilligungs-History (via Bewilligungs-Dialog)
                    dlg.InsertBewilligungsHistory();

                    if (dlg.UserYes)
                    {
                        DBUtil.ExecSQLThrowingException(@"
                            EXECUTE spWhFinanzplan_Bewilligen {0}, {1}, {2}",
                            qryBgFinanzplan["BgFinanzplanID"],
                            qryBgPosition["DatumVon"],
                            qryBgPosition["BgPositionID"]);
                    }
                    else
                    {
                        qryBgPosition["BgBewilligungStatusCode"] = dlg.BgBewilligungStatusCode;	// Abgelehnt
                        FPAnpassungAblehnen(dlg.TaskDescription, dlg.ReceiverID);
                    }

                    qryBgPosition.Refresh();

                    // Verrechnungsposition erstellen, da diese bei einem bewilligten Finanzplan
                    // nicht schon beim Erstellen der Position erzeugt wird.
                    WhUtil.InsertOrUpdateVerrechnungsposition(qryBgPosition);

                    Session.Commit();
                }
                catch (Exception ex)
                {
                    if (Session.Transaction != null)
                    {
                    Session.Rollback();
                    }

                    KissMsg.ShowInfo(ex.Message);
                }
            }
            else
            {
                //Wenn der Benutzer in DlgBewilligungAnfragen 'Anfragen' klickt, erstellt einen Bewilligungs-Record und öffnet dazu bereits eine Transaktion!
                DlgBewilligungAnfragen dlg = new DlgPositionBewilligungAnfragen((int)qryBgPosition["BgPositionID"], (int)qryBgFinanzplan["BgFinanzPlanID"], _bgBudgetID, null, true);

                dlg.ShowDialog(this);
                if (dlg.UserCancel)
                {
                    return;
                }

                try
                {
                    qryBgPosition["BgBewilligungStatusCode"] = (int)BgBewilligungStatus.Angefragt;
                    qryBgPosition.Post();

                    Session.Commit();

                    qryBgPosition.Refresh();
                }
                catch (Exception ex)
                {
                    if (Session.Transaction != null)
                    {
                    Session.Rollback();
                    }

                    KissMsg.ShowInfo(ex.Message);
                }
            }
        }

        private void edtInstitution_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            e.Cancel = AuswahlInstitutionFAMOZ(edtInstitution.EditValue.ToString(), e.ButtonClicked);
        }

        private void edtKostenart_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            e.Cancel = SelectKostenart(e.ButtonClicked);
        }

        private void FPAnpassungAblehnen(string taskDescription, int receiverID)
        {
            try
            {
                // Pfad für Pendenz erzeugen
                string jumpToPath = string.Format(
                    "ActiveSQLQuery.Find=BgPositionID = {0};" +
                    "BaPersonID={1};" +
                    "ModulID=3;" +
                    "TreeNodeID=CtlWhFinanzplan{2}" +
                    "/CtlBgUebersicht/{3}{4};FaLeistungID={5};" +
                    "FaFallID={6};" +
                    "ClassName=FrmFall;",
                    qryBgPosition["BgPositionID"],
                    qryBgPosition["FallBaPersonID"],
                    qryBgPosition["BgFinanzplanID"],
                    Name,
                    _bgGruppeCode,
                    qryBgPosition["FaLeistungID"],
                    qryBgPosition["FaFallID"]);

                // Pendenz erzeugen: Rückmeldung, pendent
                // + BgBewilligungsStatus der Position auf "abgelehnt"
                DBUtil.ExecSQLThrowingException(@"
                    INSERT INTO XTask (TaskTypeCode, TaskStatusCode, CreateDate, StartDate,
                                       [Subject], TaskDescription, SenderID, TaskSenderCode, ReceiverID, TaskReceiverCode,
                                       FaLeistungID, BaPersonID, JumpToPath)
                    VALUES (5, 1, GetDate(), GetDate(), {0}, {1}, {2}, 1, {3}, 1, {4}, {5}, {6})

                    UPDATE BgPosition SET BgBewilligungStatusCode = 2 WHERE BgPositionID = {7}",
                    string.Format("Bewilligung {0} abgelehnt.", qryBgPosition["Gruppe"]),
                    taskDescription,
                    Session.User.UserID,
                    receiverID,
                    qryBgPosition["FaLeistungID"],
                    qryBgPosition["BaPersonID"],
                    jumpToPath,
                    qryBgPosition["BgPositionID"]);
            }
            catch (Exception ex)
            {
                throw new KissErrorException("Fehler beim Ablehnen der FP-Anpassung:\r\n\r\n" + ex.Message, ex);
            }
        }

        private bool GetUserPermission()
        {
            SqlQuery qry = DBUtil.OpenSQL(@"
                select ok = dbo.fnWhPosition_Permission({0},{1})",
                qryBgPosition["BgPositionID"],
                Session.User.UserID);

            if (qry.Count > 0)
            {
                return (bool)qry["ok"];
            }

            return false;
        }

        private void qryBgPosition_AfterDelete(object sender, EventArgs e)
        {
            if (Session.Transaction != null)
        {
                Session.Commit();
            }

            if (qryBgPosition.Count == 0)
            {
                btnPositionBewilligung.Visible = false;
            }
        }

        private void qryBgPosition_AfterInsert(object sender, EventArgs e)
        {
            qryBgPosition["BgBudgetID"] = _bgBudgetID;
            qryBgPosition["BgKategorieCode"] = 2;
            qryBgPosition["BgBewilligungStatusCode"] = BgBewilligungStatus.InVorbereitung;

            qryBgPosition["DatumVon"] = qryBgFinanzplan["FinanzplanVon"];
            qryBgPosition["DatumBis"] = qryBgFinanzplan["FinanzplanBis"];
            qryBgPosition["DatumVonFP"] = qryBgFinanzplan["FinanzplanVon"];
            qryBgPosition["DatumBisFP"] = qryBgFinanzplan["FinanzplanBis"];
            qryBgPosition["DatumVonKonsolidiert"] = qryBgFinanzplan["FinanzplanVon"];
            qryBgPosition["DatumBisKonsolidiert"] = qryBgFinanzplan["FinanzplanBis"];

            qryBgPosition["ProPerson"] = false;
            qryBgPosition["ProUE"] = true;

            if (_bgGruppeCode == BG_GRUPPE_CODE_MIETE)
            {
                // Die Kostenart bei Miete wird gesetzt (unveränderbar)
                edtKostenart.EditValue = "130";
                SelectKostenart(false);
                edtBetrag.Focus();
            }
            else
            {
                edtKostenart.Focus();
            }
        }

        private void qryBgPosition_AfterPost(object sender, EventArgs e)
        {
            try
            {
                var fpStatus = (BgBewilligungStatus)qryBgFinanzplan["FPStatus"];
                var posStatus = (BgBewilligungStatus)qryBgPosition["BgBewilligungStatusCode"];
                if (fpStatus < BgBewilligungStatus.Erteilt || posStatus == BgBewilligungStatus.Erteilt)
                {
                    // Verrechnungsposition direkt erstellen/aktualisieren, wenn Finanzplan noch
                    // nicht bewilligt
                    WhUtil.InsertOrUpdateVerrechnungsposition(qryBgPosition);
                }

                if (_beginTransactionInBeforePost)
                {
                    Session.Commit();
                }
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

        private void qryBgPosition_BeforeDelete(object sender, EventArgs e)
        {
            Session.BeginTransaction();

            try
            {
                // Ok, zuerst lösche allfällige abhängige Positionen (inkl. allfällig vorhandener
                // Dokumente und Bewilligung)
                DBUtil.ExecSQL(@"
                delete BgPosition where BgPositionID in (SELECT BgPositionID FROM BgPosition WHERE BgPositionID_parent = {0})
                delete BgDokument where BgPositionID in (SELECT BgPositionID FROM BgPosition WHERE BgPositionID_parent = {0})
                delete BgBewilligung where BgPositionID in (SELECT BgPositionID FROM BgPosition WHERE BgPositionID_parent = {0})",
                    qryBgPosition["BgPositionID"]);

                // Dann lösche die Position selber (inkl. allfällig vorhandener Dokumente und Bewilligung)
                DBUtil.ExecSQL(@"
                delete BgDokument where BgPositionID = {0}
                delete BgBewilligung where BgPositionID = {0}",
                    qryBgPosition["BgPositionID"]);
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

        private void qryBgPosition_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            if (!DBUtil.IsEmpty(qryBgPosition["F"]))
            {
                throw new KissInfoException("Positionen des LE können nicht mehr gelöscht werden.");
            }

            if (qryMonatsbudget.Count > 0)
            {
                throw new KissInfoException("Diese Position wird bereits in einem oder mehreren Monatsbudgets verwendet.");
            }

            // Prüfe, ob es andere LE Positionen gibt, die auf diese Position verweisen via BgPositionID_parent
            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT BgPositionID FROM BgPosition WHERE BgPositionID_parent = {0} AND FPPosition = 1", qryBgPosition["BgPositionID"]);

            if (qry.Count > 0)
            {
                // Es gibt mind. eine abhängige LE Position => Position kann nicht gelöscht werden
                throw new KissInfoException("Diese Position wird hat mind. eine abhängige LE Position und kann daher nicht gelöscht werden.");
            }

            // Prüfe, ob es andere nicht LE Positionen gibt, die auf diese Position verweisen via
            // BgPositionID_parent und die bereits in Budgets verwendet werden
            qry = DBUtil.OpenSQL(@"
                SELECT POS2.BgPositionID FROM BgPosition POS1
                    INNER JOIN BgPosition POS2 ON POS2.BgPositionID_CopyOf = POS1.BgPositionID
                WHERE POS1.BgPositionID_parent = {0}", qryBgPosition["BgPositionID"]);

            if (qry.Count > 0)
            {
                // Es gibt mind. eine abhängige Position => Position kann nicht gelöscht werden
                throw new KissInfoException("Diese Position wird hat mind. eine abhängige Position, die bereits in einem oder mehreren Monatsbudgets verwendet wird.");
            }
        }

        private void qryBgPosition_BeforePost(object sender, EventArgs e)
        {
            try
            {
                BgBewilligungStatus fpStatus = (BgBewilligungStatus)qryBgFinanzplan["FPStatus"];
                
                if (fpStatus == BgBewilligungStatus.Erteilt && edtDatumVon.EditMode != EditModeType.ReadOnly)
                {
                    //bei existierenden Positionen (wenn sie aus dem vorherigen Finanzplan kopiert wurden) kann DatumVon NULL sein
                    DBUtil.CheckNotNullField(edtDatumVon, lblDatumVon.Text);
                }
                
                DBUtil.CheckNotNullField(edtKostenart, lblKostenart.Text);
                DBUtil.CheckNotNullField(edtBuchungstext, lblBuchungstext.Text);
                DBUtil.CheckNotNullField(edtBetrag, lblBetrag.Text);

                switch (_bgGruppeCode)
                {
                    case BG_GRUPPE_CODE_MIETE:
                        // Miete: Reduktion wird berechnet
                        DBUtil.CheckNotNullField(edtTotal, lblTotal.Text);
                        if ((Decimal)edtTotal.EditValue > (Decimal)edtBetrag.EditValue)
                        {
                            throw new KissInfoException(lblTotal.Text + " darf nicht grösser als " + lblBetrag.Text + " sein.");
                        }

                        decimal reduktion = edtBetrag.Value - edtTotal.Value;

                        // Reduktion und MaxBeitragSD werden hier angepasst
                        qryBgPosition["Reduktion"] = reduktion;
                        qryBgPosition["MaxBeitragSD"] = edtTotal.Value;		// Es wird maximal die Miete UE ausbezahlt

                        break;

                    case BG_GRUPPE_CODE_KRANKENKASSE:
                        DBUtil.CheckNotNullField(edtReduktion, lblReduktion.Text);
                        if ((Decimal)edtReduktion.EditValue > (Decimal)edtBetrag.EditValue)
                        {
                            throw new KissInfoException(lblReduktion.Text + " darf nicht grösser als " + lblBetrag.Text + " sein.");
                        }
                        break;
                }

                DateTime gueltigVon;
                DateTime gueltigBis;
                int koa = Convert.ToInt32(qryBgPosition["KOA"]);

                if (DBUtil.IsEmpty(edtDatumVon.EditValue))
                {
                    // Es wurde kein DatumVon eingegeben, d.h. für die Checks verwenden wir das
                    // frühest mögliche Datum
                    gueltigVon = new DateTime(1900, 1, 1);
                }
                else
                {
                    gueltigVon = (DateTime)edtDatumVon.EditValue;
                }

                if (DBUtil.IsEmpty(edtDatumBis.EditValue))
                {
                    // Es wurde kein DatumBis eingegeben, d.h. für die Checks verwenden wir das
                    // spätest mögliche Datum
                    gueltigBis = new DateTime(2079, 12, 31);
                }
                else
                {
                    gueltigBis = (DateTime)edtDatumBis.EditValue;

                    // Nur wenn das Datum explitit eingegeben wird, wird überprüft, ob es sicher
                    // grösser ist als Gültig bis
                    // = > Dies erlaubt, dass der User zukünftige Leistungen ohne fixiertes Ende
                    //   eingeben kann, die über den FP hinausgehen, z.B. eine Mieterhöhung, die
                    //   erst in mehreren Monaten gültig ist
                    if (gueltigBis < gueltigVon)
                    {
                        throw new KissInfoException("'Gültig von' muss kleiner sein als 'Gültig bis'.");
                    }

                    // Krankenkasse: Falls die Kostenart 110 (VVG aus GBL) ist, soll das End-datum
                    //               nicht später als 31.5.2009 gesetzt werden dürfen
                    if (_bgGruppeCode == BG_GRUPPE_CODE_KRANKENKASSE && koa == 110 && gueltigBis > new DateTime(2009, 5, 31))
                    {
                        throw new KissInfoException("VVG aus GBL (LA 110) ist nur bis zum 31.5.2009 gültig.");
                    }

                    WhUtil.CheckIfGueltigBisIsValidWithMonatsbudget(qryBgPosition["BgPositionID"] as int?, gueltigBis);
                }

                // Krankenkassen-Spezifische Prüfungen
                if (_bgGruppeCode == BG_GRUPPE_CODE_KRANKENKASSE)
                {
                    if (gueltigVon.Day != 1)
                    {
                        throw new KissInfoException("'Gültig von' muss immer der erste Tag eines Monats sein.");
                    }

                    if (gueltigBis.AddDays(1).Day != 1)
                    {
                        throw new KissInfoException("'Gültig Bis' muss immer der letzte Tag eines Monats sein.");
                    }

                    if (koa == 140)
                    {
                        // Von der LA 140 darf es nur eine geben pro Person und Periode
                        string sql = @"
                            SELECT BPO.BgPositionID, BPO.DatumBis
                            FROM   BgPosition BPO
                           		INNER JOIN BgPositionsart  BPA ON BPA.BgPositionsartID = BPO.BgPositionsartID
                                INNER JOIN BgKostenart     BKA ON BKA.BgKostenartID = BPA.BgKostenartID
                                INNER JOIN BgBudget        BDG ON BDG.BgBudgetID = BPO.BgBudgetID
                         		INNER JOIN BgFinanzplan    FPL ON FPL.BgFinanzplanID = BDG.BgFinanzplanID
                            WHERE BPO.BgBudgetID = {0} AND
                                BPA.BgGruppeCode = {1} AND
                                BKA.KontoNr = {2} AND
                                BPO.BaPersonID = {3} AND
                                BPO.Betrag <> 0 AND
                                ISNULL(BPO.Hidden, 0) = 0 AND
                          		dbo.fnDatumUeberschneidung(IsNull(BPO.DatumVon, CONVERT(DateTime, '1900-01-01')), IsNull(BPO.DatumBis, CONVERT(DateTime, '2079-12-31')), {4}, {5}) = 1 AND
                          		(ISNULL({6},0) <> BPO.BgPositionID)	-- Stelle sicher, dass wir unsere eigene Position nicht mitzählen
                                ";

                        SqlQuery qry = DBUtil.OpenSQL(sql, _bgBudgetID, _bgGruppeCode, koa, qryBgPosition["BaPersonID"], gueltigVon, gueltigBis, qryBgPosition["BgPositionID"]);
                        if (qry.Count > 0)
                        {
                            // Immer noch überschneidungen => Fehlermeldung
                            throw new KissInfoException("Die LA 140 darf pro Person und Periode nur einmal definiert sein. Bitte prüfen Sie das Von- und Bis-Datum der existierenden Position.");
                        }
                    }
                }

                if ((int)qryBgPosition["BgBewilligungStatusCode"] == 5)
                {
                    // Bewilligung erteilt, d.h. neues Datum und neuer Betrag müssen sich innerhalb
                    // der Bewilligung bewegen, falls die Bewilligung enger als der FP ist
                    if (!DBUtil.IsEmpty(qryBgPosition["BewilligtVon"]) && (DateTime)qryBgPosition["BewilligtVon"] > (DateTime)qryBgPosition["DatumVonFP"])
                    {
                        if ((DateTime)qryBgPosition["BewilligtVon"] > gueltigVon)
                        {
                            throw new KissInfoException(string.Format("Gültig von muss innherhalb der bewilligten Zeitspanne liegen ({0:d} - {1:d}).", qryBgPosition["BewilligtVon"], qryBgPosition["BewilligtBis"]));
                        }

                        if ((DateTime)qryBgPosition["BewilligtVon"] > gueltigBis)
                        {
                            throw new KissInfoException(string.Format("Gültig bis muss innherhalb der bewilligten Zeitspanne liegen ({0:d} - {1:d}).", qryBgPosition["BewilligtVon"], qryBgPosition["BewilligtBis"]));
                        }
                    }

                    if (!DBUtil.IsEmpty(qryBgPosition["BewilligtBis"]) && (DateTime)qryBgPosition["BewilligtBis"] < (DateTime)qryBgPosition["DatumBisFP"])
                    {
                        if ((DateTime)qryBgPosition["BewilligtBis"] < gueltigVon)
                        {
                            throw new KissInfoException(string.Format("Gültig von muss innherhalb der bewilligten Zeitspanne liegen ({0:d} - {1:d}).", qryBgPosition["BewilligtVon"], qryBgPosition["BewilligtBis"]));
                        }

                        if ((DateTime)qryBgPosition["BewilligtBis"] < gueltigBis)
                        {
                            throw new KissInfoException(string.Format("Gültig bis muss innherhalb der bewilligten Zeitspanne liegen ({0:d} - {1:d}).", qryBgPosition["BewilligtVon"], qryBgPosition["BewilligtBis"]));
                        }
                    }

                    switch (_bgGruppeCode)
                    {
                        case BG_GRUPPE_CODE_KRANKENKASSE:
                            // Berücksichtige auch Reduktion
                            if ((Decimal)qryBgPosition["BewilligtBetrag"] < ((Decimal)edtBetrag.EditValue - (Decimal)edtReduktion.EditValue))
                            {
                                throw new KissInfoException(lblBetrag.Text + " minus " + lblReduktion.Text + " darf nicht grösser sein als der bewilligte Betrag");
                            }
                            break;

                        case BG_GRUPPE_CODE_MIETE:
                            // Prüfe Betrag UE (Feld Total)
                            if ((Decimal)qryBgPosition["BewilligtBetrag"] < (Decimal)edtTotal.EditValue)
                            {
                                throw new KissInfoException(edtTotal.Text + " darf nicht grösser sein als der bewilligte Betrag");
                            }
                            break;

                        default:
                            if ((Decimal)qryBgPosition["BewilligtBetrag"] < (Decimal)edtBetrag.EditValue)
                            {
                                throw new KissInfoException("Der Betrag darf nicht grösser sein als der bewilligte Betrag");
                            }
                            break;
                    }
                }

                // VonDatum wird nicht geprüft, damit das Erfassen von Zukünftigen Leistungen
                // möglich ist
                if ((DateTime)qryBgFinanzplan["FinanzplanVon"] > gueltigBis)
                {
                    throw new KissInfoException(string.Format("Gültig bis muss nach dem Start ({0:d}) des Finanzplans liegen.", qryBgFinanzplan["FinanzplanVon"]));
                }

                //Betrifft Person
                if (!DBUtil.IsEmpty(qryBgPosition["ProPerson"]) && !DBUtil.IsEmpty(qryBgPosition["ProUE"]))
                {
                    bool proPerson = (bool)qryBgPosition["ProPerson"];
                    bool proUe = (bool)qryBgPosition["ProUE"];

                    if (proPerson && !proUe && DBUtil.IsEmpty(qryBgPosition["BaPersonID"]))
                    {
                        edtBaPersonID.Focus();
                        throw new KissInfoException("Das Feld 'Betrifft Person' darf nicht leer bleiben für diese Leistungsart!");
                    }
                }

                int posStatus = ShUtil.GetCode(qryBgPosition["BgBewilligungStatusCode"]);

                //Betrag
                if (posStatus == 1 && (Decimal)qryBgPosition["Betrag"] <= Decimal.Zero)
                {
                    edtBetrag.Focus();
                    throw new KissInfoException("Das Feld 'Betrag' darf nicht kleiner oder gleich 0.00 sein!");
                }

                if (Session.Transaction == null)
                {
                    Session.BeginTransaction();
                    _beginTransactionInBeforePost = true;
                }
                else
                {
                    _beginTransactionInBeforePost = false;
                }
            }
            catch (KissInfoException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new KissInfoException("Unbekanntes Problem:" + ex);
            }
        }

        private void qryBgPosition_PositionChanged(object sender, EventArgs e)
        {
            SetEditMode();
            qryMonatsbudget.Fill(qryBgPosition["BgPositionID"]);
        }

        private void qryBgPosition_PostCompleted(object sender, EventArgs e)
        {
            qryBgPosition.Refresh();
        }

        private bool SelectKostenart(bool buttonClicked)
        {
            string searchString = edtKostenart.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (buttonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryBgPosition["BgPositionsArtID"] = DBNull.Value;
                    qryBgPosition["Kostenart"] = DBNull.Value;
                    return true;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            string sql = @"
                select LA                  = BKA.KontoNr,
                       Positionsart        = BPA.Name,
                       Gruppe              = GRP.Text,
                       BgPositionsartID$   = BPA.BgPositionsartID,
                       ProPerson$          = BPA.ProPerson,
                       ProUE$              = BPA.ProUE,
                       KOAPositinsart$     = BKA.KontoNr + ' '+ BPA.Name,
                       Name$               = BPA.Name
                from   WhPositionsart BPA
                       inner join BgKostenart BKA on BKA.BgKostenartID = BPA.BgKostenartID
                       left  join XLOVCode    GRP on GRP.LOVName = 'BgGruppe' AND GRP.Code = BPA.BgGruppeCode
                where  BPA.BgGruppeCode = " + _bgGruppeCode.ToString() + @" and
                       BPA.BgKategorieCode = 2 and
                       (BKA.Name like '%' + {0} + '%' or
                        BKA.KontoNr like {0} + '%')
                order by 1,2";

            bool cancel = !dlg.SearchData(sql, searchString, buttonClicked, null, null, null);

            if (!cancel)
            {
                qryBgPosition["KOA"] = dlg["LA"];
                qryBgPosition["BgPositionsArtID"] = dlg["BgPositionsartID$"];
                qryBgPosition["Kostenart"] = dlg["KOAPositinsart$"];
                qryBgPosition["Buchungstext"] = dlg["Name$"];
                qryBgPosition["ProPerson"] = dlg["ProPerson$"];
                qryBgPosition["ProUE"] = dlg["ProUE$"];

                bool proPerson = (bool)qryBgPosition["ProPerson"];
                bool proUe = (bool)qryBgPosition["ProUE"];

                if (proUe && !proPerson)
                {
                    qryBgPosition["BaPersonID"] = null;
                }

                SetEditMode();
            }

            return cancel;
        }

        private void SetEditMode()
        {
            if (qryBgPosition.IsEmpty)
            {
                return;
            }

            BgBewilligungStatus fpStatus = (BgBewilligungStatus)qryBgFinanzplan["FPStatus"];
            BgBewilligungStatus posStatus = (BgBewilligungStatus)qryBgPosition["BgBewilligungStatusCode"];

            bool abgeschlossen = !DBUtil.IsEmpty(qryBgFinanzplan["LeiDatumBis"]);
            bool editierbar = !abgeschlossen &&
                                 (fpStatus != BgBewilligungStatus.Gesperrt) &&
                                 (posStatus != BgBewilligungStatus.Erteilt);

            bool anpassbar = !abgeschlossen &&
                                 (fpStatus != BgBewilligungStatus.Gesperrt);

            // Setze die Felder auf Readonly oder Editierbar
            qryBgPosition.EnableBoundFields(editierbar);

            // Spezialfall Miete: Die Kostenart ist hier unveränderbar
            if (_bgGruppeCode == BG_GRUPPE_CODE_MIETE)
            {
                edtKostenart.EditMode = EditModeType.ReadOnly;
            }

            var istNachtraeglichErstellteFpPosition = DBUtil.IsEmpty(qryBgPosition["F"]);
            btnPositionBewilligung.Visible = !abgeschlossen && (fpStatus == BgBewilligungStatus.Erteilt) && istNachtraeglichErstellteFpPosition;

            if (!DBUtil.IsEmpty(qryBgPosition["ProPerson"]) && !DBUtil.IsEmpty(qryBgPosition["ProUE"]))
            {
                bool proPerson = (bool)qryBgPosition["ProPerson"];
                bool proUe = (bool)qryBgPosition["ProUE"];

                edtBaPersonID.EditMode = editierbar && (proPerson || !proUe) ? EditModeType.Normal : EditModeType.ReadOnly;
            }
            else
            {
                edtBaPersonID.EditMode = EditModeType.ReadOnly;
            }

            var editModeEditierbar = editierbar ? EditModeType.Normal : EditModeType.ReadOnly;
            edtDatumVon.EditMode = editModeEditierbar;
            edtBetrag.EditMode = editModeEditierbar;
            switch (_bgGruppeCode)
            {
                case BG_GRUPPE_CODE_KRANKENKASSE:
                    edtReduktion.EditMode = editModeEditierbar;
                    break;

                case BG_GRUPPE_CODE_MIETE:
                    edtTotal.EditMode = editModeEditierbar;
                    break;
            }

            if (anpassbar)
            {
                edtDatumBis.EditMode = EditModeType.Normal;
            }
        }
    }
}