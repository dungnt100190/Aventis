using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Kiss.Infrastructure;
using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.Common.Report;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Vormundschaft.ZH
{
    public partial class CtlKgBudget : KiSS4.Gui.KissUserControl, IBelegleser
    {
        #region Fields

        #region Private Static Fields

        private static readonly log4net.ILog LOG = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly string SPEZIALRECHT_KLIBUPOSITION_MUTIEREN = "CtlKgBudget_EinzelzahlungenMutieren";

        #endregion

        #region Private Fields

        private bool _baInstitutionModified = false;
        private bool _buchungstextModified = false;
        private bool _isNewPosition;
        private bool _kontoNrModified = false;
        private int BaPersonID = 0;
        private bool BuchungsdatumAnpassung = false;
        private bool CalendarFilling = false;
        private bool DebitorValutaBetragsAnpassung = false;
        private int FaLeistungID = 0;
        private bool firstPostAfterPositionInsert = false;
        private bool isMasterbudget = true;
        private int KgBudgetID = 0;
        private int KgMasterbudgetID = 0;
        private object KgPeriodeID = 0;
        private bool masterBetragValutaDebitorAnpassung = false;
        private int newKgPositionsKategorieCode = 0;
        private bool refreshing = false;
        private bool updatingBuchung = false;

        #endregion

        #endregion

        #region Constructors

        public CtlKgBudget()
        {
            this.InitializeComponent();

            repositoryItemPictureEdit1.NullText = " ";

            btnPositionGrau.Location = btnPositionGruen.Location;
            btnBudgetGrau.Location = btnBudgetGruen.Location;
            btnBewilligungPosition.Location = btnBudgetGruen.Location;

            this.edtReferenzNummer.RightToLeft = System.Windows.Forms.RightToLeft.No;
        }

        #endregion

        #region Properties

        private decimal MaxBarBetrag
        {
            get
            {
                return (decimal)DBUtil.GetConfigValue(@"System\Vormundschaft\MaxBarBezugBetrag", 0);
            }
        }

        #endregion

        #region EventHandlers

        private void btnAusgabeD_Click(object sender, System.EventArgs e)
        {
            NeuePosition(2);
        }

        private void btnAusgabeK_Click(object sender, System.EventArgs e)
        {
            NeuePosition(1);
        }

        private void btnBarbelegDruck_Click(object sender, System.EventArgs e)
        {
            qryBelege.EndCurrentEdit(true);

            int totalcount = 0;
            int countStatus2 = 0;
            decimal maxBarBetrag = MaxBarBetrag;

            foreach (DataRow R in qryBelege.DataTable.Rows)
                if ((bool)R["Sel"])
                {
                    if ((decimal)R["Betrag"] > maxBarBetrag)
                    {
                        ShowDialogUebersteigtMaxBarBetrag();
                        return;
                    }
                    totalcount++;
                    if ((int)R["KgBuchungStatusCode"] == 2)
                        countStatus2++;
                }
            if (totalcount == 0)
                return;

            string BelegText;
            if (totalcount > 1)
                BelegText = string.Format("Sollen {0} Barbelege auf den Standarddrucker gedruckt werden?", totalcount);
            else
                BelegText = "Soll der Barbeleg gedruckt werden?";

            if (countStatus2 > 0)
            {
                if (!KissMsg.ShowQuestion(null, null,
                                          "Achtung:\r\n" +
                                          "Durch den Druck eines Barbelegs wird der Belegstatus auf 'ausgedruckt' gesetzt.\r\n" +
                                          "Dieser Vorgang kann nicht mehr rückgängig gemacht werden und\r\n" +
                                          "das Monatsbudget kann danach nicht mehr auf grau gestellt werden.\r\n\r\n" +
                                          "Ein Barbeleg kann bei Druckerproblemen nochmals ausgedruckt werden.\r\n\r\n" +
                                          BelegText,
                                          700, 250))
                    return;
            }
            else if (totalcount > 0)
            {
                if (!KissMsg.ShowQuestion(BelegText))
                    return;
            }

            // Korrektur: Verwende qryBelege statt direktes Update-Statement, um sicherzugehen, dass die Daten in der Zwischenzeit nicht verändert wurden
            qryBelege.First();
            try
            {
                Session.BeginTransaction();
                updatingBuchung = true;
                do
                {
                    if ((bool)qryBelege["Sel"])
                    {
                        // Beleg ist selektiert
                        if (((int)qryBelege["KgBuchungStatusCode"] == 2 || (int)qryBelege["KgBuchungStatusCode"] == 4))
                        {
                            // Der Beleg ist noch nicht transferiert, d.h. wir können Ihn hier auf Ausgedruckt setzen.
                            // Ein bereits transferierter Beleg kann man noch ausdrucken, der Status darf aber nicht wechseln.
                            qryBelege["KgBuchungStatusCode"] = 4;
                        }

                        qryBelege["BarbelegDatum"] = DateTime.Now;
                        qryBelege["BarbelegUserID"] = Session.User.UserID;

                        // Falls das ValutaDatum in der Zukunft liegt, wird das BarbelegGueltigVon aufs ValutaDatum gesetzt, sonst auf heute
                        qryBelege["BarbelegGueltigVon"] = DBUtil.IsEmpty(qryBelege["ValutaDatum"]) || (DateTime)qryBelege["ValutaDatum"] < DateTime.Today ? DateTime.Today : qryBelege["ValutaDatum"];

                        if (!qryBelege.Post())
                        {
                            throw new Exception("Das Drucken des Barbelegs schlug fehl, weil die Daten nicht gespeichert werden konnten.");
                        }
                    }
                }
                while (qryBelege.Next());
                Session.Commit();
            }
            catch (Exception ex)
            {
                updatingBuchung = false;
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;

                if (totalcount > 1)
                    lblBelegNr.DataSource = null;

                int count = 0;
                foreach (DataRow R in qryBelege.DataTable.Rows)
                {
                    if ((bool)R["Sel"])
                    {
                        count++;

                        if (totalcount > 1)
                            lblBelegNr.Text = string.Format("{0}/{1}", count, totalcount);

                        ApplicationFacade.DoEvents();

                        NamedPrm[] prms = new NamedPrm[2];
                        prms[0] = new NamedPrm("KgBuchungID", R["KgBuchungID"]);
                        prms[1] = new NamedPrm("KasseUserID", Session.User.UserID);

                        if (totalcount == 1)
                            RepUtil.ExecuteReport("KgKassenbeleg", KissReportDestination.Viewer, prms);
                        else
                            RepUtil.ExecuteReport("KgKassenbeleg", KissReportDestination.Printer, prms);

                        ApplicationFacade.DoEvents();
                    }
                }
                lblBelegNr.DataSource = qryBelege;

                qryBelege.Refresh();
                refreshing = true;
                qryKgPosition.Refresh();
                qryKgBudget.Refresh();
                SetBudgetEditMode();
                refreshing = false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnBarbelegGruen_Click(object sender, System.EventArgs e)
        {
            if (KissMsg.ShowQuestion("Soll der bereits ausgedruckte Barbeleg wieder auf grün (noch nicht gedruckt) gestellt werden?"))
            {
                DBUtil.ExecSQL(@"
                    update KgBuchung
                    set    KgBuchungStatusCode = 2, --freigegeben
                            BarbelegDatum = NULL,
                            BarbelegGueltigVon = NULL,
                            BarbelegUserID = NULL
                    from   KgBuchung
                    where  KgBuchungID = {0} and
                           KgBuchungStatusCode = 4 --ausgedruckt",
                    qryBelege["KgBuchungID"]);

                qryBelege.Refresh();
                refreshing = true;
                qryKgPosition.Refresh();
                refreshing = false;
            }
        }

        private void btnBelegeAlle_Click(object sender, System.EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            foreach (DataRow R in qryBelege.DataTable.Rows)
            {
                R["Sel"] = true;
                R.AcceptChanges();
            }
            Cursor = Cursors.Default;
        }

        private void btnBelegeKeine_Click(object sender, System.EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            foreach (DataRow R in qryBelege.DataTable.Rows)
            {
                R["Sel"] = false;
                R.AcceptChanges();
            }
            Cursor = Cursors.Default;
        }

        private void btnBewilligung_Click(object sender, System.EventArgs e)
        {
            if (!qryKgBudget.Post())
                return;
            if (!qryKgPosition.Post())
                return;

            bool DarfVisieren = UserDarfVisieren();
            bool DarfBeenden = DBUtil.UserHasRight("CtlKgBudget_MasterbudgetBeenden");

            switch ((int)qryKgBudget["KgBewilligungCode"])
            {
                case 1: // in Vorbereitung
                case 2: // Bewilligung abgelehnt
                    if (DarfVisieren)
                        MasterbudgetVisieren();
                    else
                        MasterbudgetAnfrage();
                    break;

                case 3: // Bewilligung angefragt
                    if (DarfVisieren)
                        MasterbudgetVisieren();
                    else
                        KissMsg.ShowInfo("Keine Berechtigung, dieses Masterbudget zu visieren!");
                    break;

                case 5: // Bewilligung erteilt

                    if (DBUtil.UserHasRight("CtlKgBudget_MasterbudgetGrauStellen"))
                    {
                        int CountMB = (int)DBUtil.ExecuteScalarSQL("SELECT COUNT(*) FROM KgBudget WHERE KgMasterbudgetID = {0}", KgBudgetID);
                        if (CountMB > 0)
                        {
                            KissMsg.ShowInfo(string.Format("Dieses Masterbudget kann nicht auf grau (in Vorbereitung) gestellt werden, da noch {0} Monatsbudgets existieren!", CountMB));
                            return;
                        }

                        if (KissMsg.ShowQuestion("Soll dieses bewilligte Masterbudget wieder auf grau (in Vorbereitung) gestellt werden?"))
                        {
                            //grünes Masterbudget auf grau stellen
                            qryKgBudget.Refresh();
                            qryKgBudget["KgBewilligungCode"] = 1; //grau, In Vorbereitung
                            qryKgBudget.Post();
                            qryKgBudget.Refresh();
                            SetBudgetEditMode();
                            SetPositionEditMode();

                            //Eintrag ins Fallverlaufsprotokoll
                            DBUtil.ExecSQL(@"
                                DECLARE @FaFallID INT
                                SELECT @FaFallID = FaFallID FROM FaLeistung WHERE FaLeistungID = {0}

                                INSERT FaJournal (FaFallID,FaLeistungID,BaPersonID,UserID,Text,OrgUnitID)
                                VALUES (@FaFallID,{0},{1},{2},{3},{4})",
                                this.FaLeistungID,
                                this.BaPersonID,
                                Session.User.UserID,
                                "Grünes, bewilligtes Masterbudget wieder auf grau (In Vorbereitung) gestellt",
                                Session.User["OrgUnitID"]);

                            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
                        }
                        return;
                    }

                    if (DarfVisieren || DarfBeenden)
                        MasterbudgetBeenden();
                    else
                        KissMsg.ShowInfo("Keine Berechtigung, dieses Masterbudget zu beenden!");
                    break;

                case 9: // Budget gesperrt
                    break;
            }
        }

        private void btnBewilligungPosition_Click(object sender, EventArgs e)
        {
            bool darfVisieren = UserDarfVisieren();

            if (darfVisieren)
            {
                try
                {
                    Session.BeginTransaction();
                    // Der User hat Bewilligungs-Kompetenz => Position wird bewilligt
                    DBUtil.ExecSQLThrowingException(@"
                        EXEC spKgPositionBewilligen {0}, {1}
                        ", qryKgPosition["KgPositionID"], Session.User.UserID);
                    Session.Commit();
                }
                catch (Exception ex)
                {
                    if (Session.Transaction != null)
                    {
                        Session.Rollback();
                    }
                    KissMsg.ShowError("Fehler beim Bewilligen der Position", ex);
                }
                qryKgPosition.Refresh();
            }
            else
            {
                // Der User verfügt nicht über die nötige Kompetenz
                KissMsg.ShowError("Sie verfügen nicht über die benötigte Bewilligungs-Kompetenz. Bitte wenden Sie sich an den zuständigen SA oder SL.");
            }
        }

        private void btnBudgetGrau_Click(object sender, System.EventArgs e)
        {
            //prüfen, ob grau stellen immer noch erlaubt
            qryKgPosition.Refresh();
            qryKgBudget.Refresh();
            SetBudgetEditMode();
            if (!btnBudgetGrau.Visible)
                return;

            try
            {
                Session.BeginTransaction();
                // grünes Budget auf grau stellen
                DBUtil.ExecSQLThrowingException(@"
                    EXEC dbo.spKgBudget_Grausetzen {0}",
                    this.KgBudgetID);
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

            qryKgBudget.Refresh();
            qryKgPosition.Refresh();
            SetBudgetEditMode();
            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
        }

        private void btnBudgetGruen_Click(object sender, System.EventArgs e)
        {
            if (!DBUtil.UserHasRight("CtlKgBudget_BudgetGruenStellen"))
            {
                KissMsg.ShowInfo("Fehlende Berechtigung!");
                return;
            }
            var saveStatus = this.OnSaveData();
            if (!saveStatus)
            {
                //Speichern ist fehlgeschlagen, Budget kann nicht grüngestellt werden.
                KissMsg.ShowInfo(@"Das Budget kann nicht grün gestellt werden.");
                return;
            }

            try
            {
                Session.BeginTransaction();
                int budgetStatus = (int)qryKgBudget["KgBewilligungCode"];
                if (budgetStatus == 9)
                {
                    // rotes Budget auf grün stellen
                    // gesperrte Belege freigeben in KgBuchung
                    DBUtil.ExecSQLThrowingException(@"
                        update BUC
                        set    KgBuchungStatusCode = 2 --grün
                        from   KgBuchung BUC
                                       inner join KgPosition POS on POS.KgPositionID = BUC.KgPositionID
                        where  POS.KgBudgetID = {0} and
                               BUC.KgBuchungStatusCode = 7  --rot

                        Update KgBudget
                        set    KgBewilligungCode = 5
                        where  KgBudgetID = {0} AND KgBewilligungCode = 9",
                        this.KgBudgetID);
                }
                else if (budgetStatus == 5)
                {
                    Session.Rollback();// nothing todo
                    return;
                }
                else if (budgetStatus == 1)
                {
                    // grau -> grün
                    // Budget auf grün stellen
                    DBUtil.ExecSQLThrowingException("EXECUTE spKgBudget_KgBuchung_Create {0}, {1}, {2}, 0", this.KgBudgetID, DBNull.Value, Session.User.UserID);
                }
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

            qryKgBudget.Refresh();
            qryKgPosition.Refresh();
            SetBudgetEditMode();
            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
        }

        private void btnBudgetNeu_Click(object sender, System.EventArgs e)
        {
            NeuesMonatsbudget();
        }

        private void btnBudgetRot_Click(object sender, System.EventArgs e)
        {
            try
            {
                int budgetStatus = (int)qryKgBudget["KgBewilligungCode"];
                if (budgetStatus != 5)
                    return;

                // grünes Budget auf rot stellen
                DBUtil.ExecSQLThrowingException(@"
                    update BUC
                    set    KgBuchungStatusCode = 7 --rot
                    from   KgBuchung BUC
                   	               inner join KgPosition POS on POS.KgPositionID = BUC.KgPositionID
                    where  POS.KgBudgetID = {0} and
                           BUC.KgBuchungStatusCode = 2  --grün

                    Update KgBudget
                    set    KgBewilligungCode = 9
                    where  KgBudgetID = {0}",
                    this.KgBudgetID);
            }
            catch (KissCancelException ex)
            {
                ex.ShowMessage();
                return;
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(ex.Message);
                return;
            }

            qryKgBudget.Refresh();
            qryKgPosition.Refresh();
            SetBudgetEditMode();
            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
        }

        private void btnEinnahme_Click(object sender, System.EventArgs e)
        {
            NeuePosition(3);
        }

        private void btnPositionGrau_Click(object sender, EventArgs e)
        {
            if (!qryKgPosition.Post())
            {
                return;
            }

            try
            {
                if (isMasterbudget)
                {
                    return;
                }

                int bewilligungCode = (int)qryKgBudget["KgBewilligungCode"];

                if (bewilligungCode != 5 && bewilligungCode != 9)
                {
                    return;
                }

                int positionStatus = (int)qryKgPosition["Status"];

                if (positionStatus != 2 && positionStatus != 5)
                {
                    return;
                }

                if (InKreditorenMaskeErstelltUndNichtRot())
                {
                    //Spezialrecht prüfen
                    if (!DBUtil.UserHasRight(SPEZIALRECHT_KLIBUPOSITION_MUTIEREN))
                    {
                        KissMsg.ShowError(GetType().Name, "KlibuPositionenNurMitSpezialrecht", "Positionen, welche in der Kreditorenmaske erstellt worden sind, dürfen nur mit Spezialrecht CtlKgBudget_EinzelzahlungenMutieren mutiert werden");
                        return;
                    }
                }

                Session.BeginTransaction();

                // grüne oder "Zahlauftrag fehlerhaft" Position auf grau stellen -> KgBuchung Eintrag löschen
                DBUtil.ExecSQLThrowingException(@"
                    IF NOT EXISTS (SELECT 1 FROM KgBuchung WHERE KgPositionID = {0} AND KgBuchungStatusCode NOT IN (2, 5))
                    BEGIN
                      DELETE dbo.KgBuchung
                      WHERE KgPositionID = {0}
                        AND KgBuchungStatusCode IN (2, 5);
                    END;",
                    qryKgPosition["KgPositionID"]);

                InsertPositionVerlaufEintrag(KgBewilligung.FreigabeDerZahlungAufgehoben, (int)qryKgPosition["KgPositionID"]);

                Session.Commit();
            }
            catch (KissCancelException ex)
            {
                Session.Rollback();
                ex.ShowMessage();
                return;
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowError(ex.Message);
                return;
            }

            qryKgPosition.Refresh();
        }

        private void btnPositionGruen_Click(object sender, EventArgs e)
        {
            if (!qryKgPosition.Post())
            {
                return;
            }

            int auszahlungsArt = 0;

            if (!DBUtil.IsEmpty(qryKgPosition["KgAuszahlungsArtCode"]))
            {
                auszahlungsArt = (int)qryKgPosition["KgAuszahlungsArtCode"];
            }

            if (auszahlungsArt == 101 && !DBUtil.UserHasRight("CtlKgBudget_PositionGruenStellen"))
            {
                throw new KissCancelException("Fehlende Berechtigung!");
            }

            if (isMasterbudget)
            {
                return;
            }

            int bewilligungCode = (int)qryKgBudget["KgBewilligungCode"];

            if (bewilligungCode == 1)
            {
                return;
            }

            var status = qryKgPosition["Status"] as int?;

            //Positionen, welche in der Maske CtlKgEinzelzahlungen erstellt worden sind, dürfen nur von User mit
            //Spezialrecht auf grün oder grau gestellt werden.
            //Aber das 4 Augenprinzip muss durchgesetzt werden.
            if (InKreditorenMaskeErstelltUndNichtRot())
            {
                //Spezialrecht prüfen
                if (!DBUtil.UserHasRight(SPEZIALRECHT_KLIBUPOSITION_MUTIEREN))
                {
                    KissMsg.ShowError(GetType().Name, "KlibuPositionenNurMitSpezialrecht", "Positionen, welche in der Kreditorenmaske erstellt worden sind, dürfen nur mit Spezialrecht CtlKgBudget_EinzelzahlungenMutieren mutiert werden");
                    return;
                }

                //Als KliBu Sachbearbeiter kann ich in der Maske "Kreditoren" eine graue Position (EZ oder ZL)
                //nur dann grünstellen, wenn ich die Position nicht efasst habe und
                //über ein Spezialrecht verfüge (dann kann ich den Button schon gar nicht drücken)
                if (Session.User.UserID == (int)qryKgPosition["ErstelltUserID"])
                {
                    KissMsg.ShowError(GetType().Name, "FreigabeDurchErfasserNichtMoeglich", "Freigabe durch Erfasser nicht möglich");
                    return;
                }
            }

            int positionStatus = (int)qryKgPosition["Status"];

            try
            {
                Session.BeginTransaction();

                if (positionStatus == 1)
                {
                    // graue Position auf grün stellen
                    DBUtil.ExecSQLThrowingException(@"
                        EXECUTE dbo.spKgBudget_KgBuchung_Create {0}, {1}, {2}, 0",
                        KgBudgetID,
                        qryKgPosition["KgPositionID"],
                        Session.User.UserID);
                }

                // alle roten Belege auf grün stellen
                DBUtil.ExecSQLThrowingException(@"
                    UPDATE dbo.KgBuchung
                    SET KgBuchungStatusCode = 2
                    WHERE KgPositionID = {0}
                        AND KgBuchungStatusCode = 7;",
                    qryKgPosition["KgPositionID"]);

                InsertPositionVerlaufEintrag(KgBewilligung.PositionZurZahlungFreigegeben, (int)qryKgPosition["KgPositionID"]);

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

            qryKgPosition.Refresh();
        }

        private void btnPositionRot_Click(object sender, System.EventArgs e)
        {
            if (!qryKgPosition.Post())
                return;
            try
            {
                if (isMasterbudget)
                    return;

                int BewilligungCode = (int)qryKgBudget["KgBewilligungCode"];
                if (BewilligungCode != 5)
                    return;

                int PositionStatus = (int)qryKgPosition["Status"];

                int PositionStatusMin = 0;
                if (!isMasterbudget && !DBUtil.IsEmpty(qryKgPosition["StatusMin"]))
                    PositionStatusMin = (int)qryKgPosition["StatusMin"];

                if (PositionStatus == 2 || PositionStatusMin == 2)
                {
                    // grüne Position auf rot stellen
                    DBUtil.ExecSQLThrowingException(@"
                        Update KgBuchung
                        set    KgBuchungStatusCode = 7
                        where  KgPositionID = {0} and
                               KgBuchungStatusCode = 2",
                        qryKgPosition["KgPositionID"]);

                    InsertPositionVerlaufEintrag(KgBewilligung.Rotgestellt, (int)qryKgPosition["KgPositionID"]);

                    qryKgPosition.Refresh();
                }
            }
            catch (KissCancelException ex)
            {
                ex.ShowMessage();
                return;
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(ex.Message);
                return;
            }
        }

        private void btnRuecklaeuferDuplizieren_Click(object sender, System.EventArgs e)
        {
            try
            {
                Session.BeginTransaction();

                // Position duplizieren
                object kgPositionID_duplicate = DBUtil.ExecuteScalarSQLThrowingException(@"
                  INSERT INTO KgPosition (KgBudgetID,KgPositionsKategorieCode,MasterbudgetPositionID,KontoNr,Buchungstext,Betrag,Bemerkung,BuchungDatum,BaInstitutionID,KgAuszahlungsArtCode,KgAuszahlungsTerminCode,KgWochentagCodes,BaZahlungswegID,MitteilungZeile1,MitteilungZeile2,MitteilungZeile3,MitteilungZeile4,ReferenzNummer,ErstelltUserID,ErstelltDatum,MutiertUserID,MutiertDatum)
                  SELECT                  KgBudgetID,KgPositionsKategorieCode,NULL                  ,KontoNr,Buchungstext,Betrag,Bemerkung,BuchungDatum,BaInstitutionID,KgAuszahlungsArtCode,KgAuszahlungsTerminCode,KgWochentagCodes,BaZahlungswegID,MitteilungZeile1,MitteilungZeile2,MitteilungZeile3,MitteilungZeile4,ReferenzNummer,{1},{2},{1},{2}
                  FROM KgPosition
                  WHERE KgPositionID = {0}

                  SELECT SCOPE_IDENTITY()",
                    qryKgPosition["KgPositionID"],
                    Session.User.UserID,
                    DateTime.Now);

                // Auch Valutatermine müssen dupliziert werden
                DBUtil.ExecuteScalarSQLThrowingException(@"
                  INSERT INTO KgPositionValuta (KgPositionID, Datum)
                  SELECT {1}, Datum
                  FROM KgPositionValuta
                  WHERE KgPositionID = {0}",
                    qryKgPosition["KgPositionID"],
                    kgPositionID_duplicate);

                // Zuletzt noch den Status der originalen Buchung auf Rückläufer korrigiert setzen, damit die Position nicht mehrfach korrigiert werden kann
                DBUtil.ExecuteScalarSQLThrowingException(@"
                  UPDATE KgBuchung
                  SET KgBuchungStatusCode = CASE KgBuchungStatusCode WHEN 9 THEN 16 ELSE KgBuchungStatusCode END --Rückläufer korrigiert
                  WHERE KgPositionID = {0}",
                    qryKgPosition["KgPositionID"]);

                Session.Commit();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowError("CtlKgBudget", "DuplizierenFehlgeschlagen", "Rückläufer-Position konnte nicht dupliziert werden", ex);
                return;
            }

            qryKgPosition.Refresh();
        }

        private void btnVerlauf_Click(object sender, System.EventArgs e)
        {
            DlgKgMasterbudgetVerlauf dlg = new DlgKgMasterbudgetVerlauf(KgBudgetID);
            dlg.ShowDialog(this);
        }

        /// <summary>
        /// Prüft das ValutaDatum und versursacht ein Exception falls nicht ok
        /// </summary>
        /// <param name="valutaDatum"></param>
        private void CheckValutaDatum(DateTime? valutaDatum)
        {
            if (valutaDatum < DateTime.Today)
            {
                throw new KissInfoException(KissMsg.GetMLMessage(Name, "ValutadatumdarfNichtinderVergangenheit", "Das Valutadatum darf nicht in der Vergangenheit liegen!"));
            }
        }

        /// <summary>
        /// Falls ValutaDatum zu prüfen dann prüft das ValutaDatum und versursacht ein Exception falls nicht ok
        /// </summary>
        /// <param name="kgPositionsKategorie"></param>
        /// <param name="kgAuszahlungsTermin"></param>
        /// <param name="valutaDatum"></param>
        private void CheckValutaDatum(int kgPositionsKategorie, int kgAuszahlungsTermin, DateTime? valutaDatum)
        {
            if ((kgAuszahlungsTermin == 4) //4 Valuta
                    && (kgPositionsKategorie == 1 || kgPositionsKategorie == 2) //1: Auszahlung Klientin 2:Auszahlung Dritte
                    && !(edtEntsperren.Visible && edtEntsperren.Checked) //es wurde nicht explizit eine nachträgliche Änderung ermöglicht
                )
            {
                //ValutaDatum prüfbar
                CheckValutaDatum(valutaDatum);
            }
        }

        /// <summary>
        ///  Falls ValutaDatum zu prüfen dann prüft das ValutaDatum
        /// </summary>
        /// <param name="kgPositionsKategorie"></param>
        /// <param name="kgAuszahlungsTermin"></param>
        /// <param name="valutaDatum"></param>
        /// <param name="isWithShowMessageWithoutException">Falls true dann wird das Exception catched und in einem Message angezeigt, falls false dann kommt ein Excpetion</param>
        /// <returns>true falls Valutdatum nicht zu prüfen oder ValutaDatum mit Erfolg geprüft wurd</returns>
        private bool CheckValutaDatum(int kgPositionsKategorie, int kgAuszahlungsTermin, DateTime valutaDatum, bool isWithShowMessageWithoutException)
        {
            if (!isWithShowMessageWithoutException)
            {
                CheckValutaDatum(kgPositionsKategorie, kgAuszahlungsTermin, valutaDatum);
                return true;
            }

            try
            {
                CheckValutaDatum(kgPositionsKategorie, kgAuszahlungsTermin, valutaDatum);
                return true;
            }
            catch (Exception ex)
            {
                if (ex is KissCancelException)
                {
                    ((KissCancelException)ex).ShowMessage();
                }
                return false;
            }
        }

        private void CtlKgBudget_Load(object sender, EventArgs e)
        {
            qryKgPosition.PostCompleted += qryKgPosition_PostCompleted;
            edtCalendar.DateChanged += edtCalendar_DateChanged;
            timer1.Tick += timer1_Tick;

            edtBetrag.EnterKey += edtBetrag_EnterKey;
            edtKgAuszahlungsTerminCode.EnterKey += edtKgAuszahlungsTerminCode_EnterKey;

            colDocTyp.ColumnEdit = grdDoc.GetLOVLookUpEdit("KgDokumentTyp");
            colKgBewilligungCode.ColumnEdit = grdBewilligung.GetLOVLookUpEdit("KgBewilligung");

            edtInklVergangeneLeistungen.Visible = isMasterbudget;

            if (isMasterbudget)
            {
                //Bewilligungsstati laden
                repositoryItemImageComboBox1.SmallImages = KissImageList.SmallImageList;
                SqlQuery qryStati = DBUtil.OpenSQL("select * from XLOVCode where LOVName = 'KgBewilligung' order by SortKey");
                foreach (DataRow row in qryStati.DataTable.Rows)
                {
                    repositoryItemImageComboBox1.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(
                        row["Text"].ToString(),
                        (int)row["Code"],
                        KissImageList.GetImageIndex(Convert.ToInt32(row["Value1"]))));
                }
                // Individuell macht für Monatsbudgets keinen Sinn. Bisher konnte es nicht abgespeichert werden, neu wird es im Monatsbudget auch nicht mehr angezeigt.
                edtKgAuszahlungsTerminCode.LOVFilter = " Code  <> 99 ";
                edtKgAuszahlungsTerminCode.LOVFilterWhereAppend = true;
            }
            else
            {
                //Buchungsstati laden
                repositoryItemImageComboBox1.SmallImages = KissImageList.SmallImageList;
                SqlQuery qryStati = DBUtil.OpenSQL("select * from XLOVCode where LOVName = 'KgBuchungsStatus' order by SortKey");
                foreach (DataRow row in qryStati.DataTable.Rows)
                {
                    repositoryItemImageComboBox1.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(
                        row["Text"].ToString(),
                        (int)row["Code"],
                        KissImageList.GetImageIndex(Convert.ToInt32(row["Value1"]))));
                }
            }

            toolTip1 = new ToolTip();
            toolTip1.SetToolTip(btnAusgabeK, "Auszahlung Klient/in");
            toolTip1.SetToolTip(btnAusgabeD, "Auszahlung Dritte");
            toolTip1.SetToolTip(btnEinnahme, "Einnahme");

            toolTip1.SetToolTip(btnBudgetGrau, "Monatsbudget auf grau (in Vorbereitung) stellen");
            toolTip1.SetToolTip(btnBudgetGruen, "Monatsbudget auf grün (freigegeben) stellen");
            toolTip1.SetToolTip(btnBudgetRot, "Monatsbudget auf rot (gesperrt) stellen");
            toolTip1.SetToolTip(btnBudgetNeu, "Neues Monatsbudget erzeugen");

            toolTip1.SetToolTip(btnPositionGrau, "Budgetposition auf grau (in Vorbereitung) stellen");
            toolTip1.SetToolTip(btnPositionGruen, "Budgetposition auf grün (freigegeben) stellen");
            toolTip1.SetToolTip(btnPositionRot, "Budgetposition auf rot (gesperrt) stellen");

            toolTip1.SetToolTip(btnBewilligung, "Bewilligung Masterbudget (anfragen, bewilligen, beenden)");
            toolTip1.SetToolTip(btnVerlauf, "Bewilligungsverlauf");

            toolTip1.SetToolTip(btnRuecklaeuferDuplizieren, "Rückläuferposition duplizieren");

            tabKgPosition.SelectedTabIndex = 0;
            tabZahlinfo.SelectedTabIndex = 0;
        }

        private void edtBetrag_EnterKey(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (edtKgAuszahlungsArtCode.EditMode == EditModeType.Normal)
            {
                edtKgAuszahlungsArtCode.Focus();
            }
            else if (edtKgAuszahlungsTerminCode.EditMode == EditModeType.Normal)
            {
                edtKgAuszahlungsTerminCode.Focus();
            }
            else if (edtValutaDatum.EditMode == EditModeType.Normal)
            {
                tabZahlinfo.SelectTab(tpgZahlinfo);
                edtValutaDatum.Focus();
            }
            else if (edtKreditor.EditMode == EditModeType.Normal)
            {
                tabZahlinfo.SelectTab(tpgZahlinfo);
                edtKreditor.Focus();
            }
            else if (edtDebitor.EditMode == EditModeType.Normal)
            {
                tabZahlinfo.SelectTab(tpgZahlinfo);
                edtKreditor.Focus();
            }
            else
            {
                SendKeys.SendWait("{TAB}");
            }
        }

        private void edtCalendar_DateChanged(object sender, System.Windows.Forms.DateRangeEventArgs e)
        {
            if (CalendarFilling)
                return;

            if (Array.IndexOf(edtCalendar.BoldedDates, e.Start) >= 0)
                edtCalendar.RemoveBoldedDate(e.Start);
            else
                edtCalendar.AddBoldedDate(e.Start);

            SaveCalendarBoldDates();
            DisplayValutaTermine();
            timer1.Enabled = true;
        }

        private void edtDebitor_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string SearchString = edtDebitor.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                    qryKgPosition["BaInstitutionID"] = DBNull.Value;
                    qryKgPosition["Debitor"] = DBNull.Value;
                    qryKgPosition["ZusatzInfo"] = DBNull.Value;
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
              SearchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                qryKgPosition["BaInstitutionID"] = dlg["ID$"];
                qryKgPosition["Debitor"] = dlg["Institution"];
                qryKgPosition["ZusatzInfo"] = dlg["Adresse"];
            }
        }

        private void edtEntsperren_EditValueChanged(object sender, System.EventArgs e)
        {
            SetPositionEditMode();
        }

        private void edtInklVergangeneLeistungen_CheckedChanged(object sender, EventArgs e)
        {
            if (!qryKgPosition.Post())
                return;

            object id = qryKgPosition["KgPositionID"];
            string text = qryKgPosition["Text"].ToString();

            qryKgPosition.Fill(KgBudgetID, edtInklVergangeneLeistungen.Checked);

            if (!DBUtil.IsEmpty(id))
                qryKgPosition.Find("KgPositionID = " + id.ToString());
            else
                qryKgPosition.Find("KgPositionID is null and Text = '" + text.ToString() + "'");
        }

        private void edtKgAuszahlungsArtCode_EditValueChanged(object sender, System.EventArgs e)
        {
            if (qryKgPosition.IsFilling)
                return;
            if (!edtKgAuszahlungsArtCode.Focused)
                return;

            qryKgPosition["KgAuszahlungsArtCode"] = edtKgAuszahlungsArtCode.EditValue;

            SetPositionEditMode();

            SqlQuery qry = DBUtil.OpenSQL(@"
                select VornameName,WohnsitzStrasseHausNr,WohnsitzPLZOrt
                from   vwPerson
                where  BaPersonID = {0}",
                BaPersonID);

            int AuszahlungsArt = (int)qryKgPosition["KgAuszahlungsArtCode"];
            switch (AuszahlungsArt)
            {
                case 101:
                    qryKgPosition["MitteilungZeile1"] = TruncateString(qry["VornameName"], 35);
                    qryKgPosition["MitteilungZeile2"] = DBNull.Value;
                    qryKgPosition["MitteilungZeile3"] = DBNull.Value;

                    tabZahlinfo.SelectTab(tpgZahlinfo);
                    break;

                case 103:
                    qryKgPosition["MitteilungZeile1"] = TruncateString(qry["VornameName"], 35);
                    qryKgPosition["MitteilungZeile2"] = TruncateString(qry["WohnsitzStrasseHausNr"], 35);
                    qryKgPosition["MitteilungZeile3"] = TruncateString(qry["WohnsitzPLZOrt"], 35);

                    qryKgPosition["BaZahlungswegID"] = DBNull.Value;
                    qryKgPosition["Kreditor"] = DBNull.Value;
                    qryKgPosition["ZusatzInfo"] = DBNull.Value;
                    qryKgPosition["EinzahlungsscheinCode"] = DBNull.Value;
                    qryKgPosition["ReferenzNummer"] = DBNull.Value;

                    tabZahlinfo.SelectTab(tpgMitteilung);
                    break;
            }
            qryKgPosition.RefreshDisplay();
        }

        private void edtKgAuszahlungsTerminCode_EditValueChanged(object sender, System.EventArgs e)
        {
            if (qryKgPosition.IsFilling)
                return;
            if (!edtKgAuszahlungsTerminCode.Focused)
                return;

            qryKgPosition["KgAuszahlungsTerminCode"] = edtKgAuszahlungsTerminCode.EditValue;
            int KgAuszahlungsTerminCode = (int)qryKgPosition["KgAuszahlungsTerminCode"];

            switch (KgAuszahlungsTerminCode)
            {
                case 6:  // Wochentage
                    qryKgPosition["KgWochentagCodes"] = DBNull.Value;
                    break;

                case 99: //individuell
                    qryKgPositionValuta.DataTable.Rows.Clear();
                    break;
            }

            LoadValutaTermine();
            DisplayValutaTermine();
            //KissMsg.ShowInfo("d: " + qryKgPositionValuta.Count.ToString());
            DisplayCalendarBoldDates();
            SetPositionEditMode();

            switch (KgAuszahlungsTerminCode)
            {
                case 1:  // 1x pro Monat
                case 2:  // 2x pro Monat
                case 3:  // wöchentlich
                case 5:  // 14-täglich
                    break;

                case 4:  // Valuta
                    tabZahlinfo.SelectTab(tpgZahlinfo);
                    break;

                case 6:  // Wochentage
                case 99: //Individuell
                    tabZahlinfo.SelectTab(tpgKalender);
                    break;
            }
        }

        private void edtKgAuszahlungsTerminCode_EnterKey(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (edtValutaDatum.EditMode == EditModeType.Normal)
            {
                tabZahlinfo.SelectTab(tpgZahlinfo);
                edtValutaDatum.Focus();
            }
            else if (edtKreditor.EditMode == EditModeType.Normal)
            {
                tabZahlinfo.SelectTab(tpgZahlinfo);
                edtKreditor.Focus();
            }
            else if (edtDebitor.EditMode == EditModeType.Normal)
            {
                tabZahlinfo.SelectTab(tpgZahlinfo);
                edtKreditor.Focus();
            }
            else
            {
                SendKeys.SendWait("{TAB}");
            }
        }

        private void edtKonto_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string SearchString = edtKonto.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                    qryKgPosition["KontoNr"] = DBNull.Value;
                    qryKgPosition["Konto"] = DBNull.Value;
                    return;
                }
            }

            string Kontoklassen = ((int)qryKgPosition["KgPositionsKategorieCode"] == 3) ? "(4)" : "(3)";

            if (DBUtil.UserHasRight("CtlKgBudget_AufwandOderErtragsKonto"))
            {
                Kontoklassen = "(3,4)";
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
              SELECT distinct
                     Konto   = KTO.KontoNr,
                     Name    = KTO.KontoName,
                     Klasse  = KLA.Text,
                     Konto$  = KTO.KontoNr + ' ' + KTO.KontoName
              FROM   KgBudget BDG
                     INNER JOIN KgPeriode    PER ON PER.FaLeistungID = BDG.FaLeistungID AND
                                                    PER.KgPeriodeStatusCode = 1 --Aktiv
                     INNER JOIN KgKonto      KTO ON KTO.KgPeriodeID = PER.KgPeriodeID AND
                                                    KTO.KontoGruppe = 0 AND
                                                    KTO.KgKontoKlasseCode in (3,4)
                     LEFT  JOIN XLOVCode     KLA ON KLA.LOVName = 'KgKontoKlasse' AND
                                                    KLA.Code = KTO.KgKontoKlasseCode
              WHERE  BDG.KgBudgetID = " + KgBudgetID.ToString() + @"  AND
                     KTO.KgKontoklasseCode in " + Kontoklassen + @" AND
                     (KTO.KontoName like '%' + {0} + '%' OR
                      KTO.KontoNr like {0} + '%')
              ORDER BY KTO.KontoNr",
              SearchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                qryKgPosition["KontoNr"] = dlg["Konto"];
                qryKgPosition["Konto"] = dlg["Konto$"];
                qryKgPosition["Buchungstext"] = dlg["Name"];
            }
        }

        private void edtKreditor_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string SearchString = edtKreditor.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                    qryKgPosition["Kreditor"] = DBNull.Value;
                    qryKgPosition["ZusatzInfo"] = DBNull.Value;
                    qryKgPosition["BaZahlungswegID"] = DBNull.Value;
                    qryKgPosition["EinzahlungsscheinCode"] = DBNull.Value;
                    SetPositionEditMode();
                    return;
                }
            }

            int kategorie = (int)qryKgPosition["KgPositionsKategorieCode"];

            if (kategorie == 1)  // Auszahlung Klient
            {
                KissLookupDialog dlg = new KissLookupDialog();
                if (!DBUtil.UserHasRight("CtlKgBudget_AlleKlientenAuswaehlbar") || SearchString == ".")
                {
                    e.Cancel = !dlg.SearchData(@"
                        SELECT ID$              = KRE.BaZahlungswegID,
                               Person           = KRE.PersonNameVorname,
                               Kontoart         = KRE.BaKontoart,
                               Verwendungszweck = KRE.Verwendungszweck,
                               Zahlungsweg      = KRE.Zahlungsweg,
                               ESCode$          = KRE.EinzahlungsscheinCode,
                               Kreditor$        = KRE.PersonNameVorname,
                               ZusatzInfo$      = KRE.ZusatzInfo
                        FROM   vwKreditor KRE
                        WHERE  KRE.BaPersonID = {1} AND
                               (GETDATE() BETWEEN IsNull(KRE.ZahlungswegDatumVon,'1900-01-01') AND IsNull(KRE.ZahlungswegDatumBis,'9999-12-31')) AND	-- nur gültige Zahlinfos
                               ISNULL(KRE.BaKontoartCode, 0) <> 4 -- ausser dem Verkehrskonto des Klienten",
                    SearchString,
                    e.ButtonClicked, BaPersonID, null, null);
                }
                else
                {
                    // Mit Spezialrecht können auch Auszahlungen an andere K-Klienten getätigt werden
                    e.Cancel = !dlg.SearchData(@"
                        SELECT ID$              = KRE.BaZahlungswegID,
                               Person           = KRE.PersonNameVorname,
                               Kontoart         = KRE.BaKontoart,
                               Verwendungszweck = KRE.Verwendungszweck,
                               Zahlungsweg      = KRE.Zahlungsweg,
                               ESCode$          = KRE.EinzahlungsscheinCode,
                               Kreditor$        = KRE.PersonNameVorname,
                               ZusatzInfo$      = KRE.ZusatzInfo
                        FROM   vwKreditor       KRE
                          INNER JOIN FaLeistung LEI ON LEI.BaPersonID = KRE.BaPersonID AND LEI.FaProzessCode = 500
                        WHERE KRE.PersonNameVorname LIKE '%' + {0} + '%'
                              AND KRE.BaPersonID <> {1}
                              AND BaKontoartCode = 4 /* hier nur Verkehrskonti selektieren */
                              AND (GETDATE() BETWEEN IsNull(KRE.ZahlungswegDatumVon,'1900-01-01') AND IsNull(KRE.ZahlungswegDatumBis,'9999-12-31'))	-- nur gültige Zahlinfos",
                    SearchString,
                    e.ButtonClicked, BaPersonID, null, null);
                }
                if (!e.Cancel)
                {
                    qryKgPosition["Kreditor"] = dlg["Kreditor$"];
                    qryKgPosition["ZusatzInfo"] = dlg["ZusatzInfo$"];
                    qryKgPosition["BaZahlungswegID"] = dlg["ID$"];
                    qryKgPosition["EinzahlungsscheinCode"] = dlg["ESCode$"];
                    SetPositionEditMode();
                }
            }
            else if (kategorie == 2) // Auszahlung Dritte
            {
                DlgKgAuswahlZahlungsweg dlg2 = new DlgKgAuswahlZahlungsweg();
                ApplicationFacade.DoEvents();

                bool transfer = false;
                dlg2.SucheBaZahlungsweg(SearchString);
                switch (dlg2.Count)
                {
                    case 0:
                        KissMsg.ShowInfo("Keine zutreffenden Kreditor-Einträge im Institutionenstamm gefunden!");
                        break;

                    case 1:
                        transfer = true;
                        break;

                    default:
                        transfer = dlg2.ShowDialog(this) == DialogResult.OK;
                        break;
                }

                if (transfer)
                {
                    SqlQuery qry2 = DBUtil.OpenSQL(@"
                        select VornameName,WohnsitzStrasseHausNr,WohnsitzPLZOrt
                        from   vwPerson
                        where  BaPersonID = {0}",
                        BaPersonID);

                    qryKgPosition["BaZahlungswegID"] = dlg2["BaZahlungswegID"];
                    qryKgPosition["Kreditor"] = dlg2["Kreditor"];
                    qryKgPosition["ZusatzInfo"] = dlg2["ZusatzInfo"];
                    qryKgPosition["EinzahlungsscheinCode"] = dlg2["EinzahlungsscheinCode"];
                    qryKgPosition["MitteilungZeile1"] = TruncateString(qry2["VornameName"], 35);
                }

                qryKgPosition.RefreshDisplay();
                SetPositionEditMode();
            }
            else
            {
                return;
            }

            /*
            -----------------------------------------------------

            {
                e.Cancel = !dlg.SearchData(@"
                    SELECT ID$          = ZAH.BaZahlungswegID,
                           Institution  = INS.Name,
                           Adresse      = INS.Adresse,
                           Zahlungsweg  = IsNull(BNK.Name + ', ','') +
                                          COALESCE(ZAH.IBANNummer, ZAH.BankKontoNummer, dbo.fnTnToPc(ZAH.PostKontoNummer)),
                           ESCode$      = ZAH.EinzahlungsscheinCode,
                           Kreditor$    = INS.Name,
                           ZusatzInfo$  = isNull(INS.StrasseHausNr + CHAR(13) + CHAR(10),'') +
                                          isNull(INS.PLZOrt + CHAR(13) + CHAR(10),'') +
                                          isNull(BNK.Name + CHAR(13) + CHAR(10), '') +
                                          COALESCE(ZAH.IBANNummer, ZAH.BankKontoNummer, dbo.fnTnToPc(ZAH.PostKontoNummer))
                    FROM   vwInstitution INS
                           INNER JOIN BaZahlungsweg ZAH ON ZAH.BaInstitutionID = INS.BaInstitutionID
                               LEFT  JOIN BaBank        BNK ON BNK.BaBankID = ZAH.BaBankID
                    WHERE  INS.Kreditor = 1 AND
                                   INS.BaFreigabeStatusCode = 2 AND
                                   GetDate() BETWEEN isNull(ZAH.DatumVon,GetDate()) AND isNull(ZAH.DatumBis,GetDate()) AND
                                   INS.Name + INS.PLZOrt LIKE '%' + {0} + '%'
                    ORDER BY Name , PLZOrt",
                SearchString,
                e.ButtonClicked,null,null,null);
            }
            else
            {
                return;
            }

            */
        }

        private void edtValutaDatum_Validated(object sender, EventArgs e)
        {
            var status = qryKgPosition["Status"] as int?;
            if (!DBUtil.IsEmpty(edtValutaDatum.EditValue) && status != 6) //KZH-2169: ausgeglichen soll keine validierung stattfinden
            {
                if (KgValidierungsHelper.KgCheckVerkehrskonto(this.FaLeistungID, edtValutaDatum.DateTime))
                {
                    KissMsg.ShowInfo(KgValidierungsHelper.ErrorMsg_Verkehrskonto_ungueltig);
                    edtValutaDatum.EditValue = null;
                }
            }
        }

        private void edtWochentagCodes_EditValueChanged(object sender, System.EventArgs e)
        {
            if (edtWochentagCodes.EditMode == EditModeType.Normal)
            {
                qryKgPosition["KgWochentagCodes"] = edtWochentagCodes.EditValue;
                LoadValutaTermine();
                DisplayValutaTermine();
                DisplayCalendarBoldDates();
            }
        }

        private void grvKgPosition_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            return;

            ////////// UNREACHABLE CODE
            //////////******************
            //////////if (e.Column == colDok)
            //////////{
            //////////    if (DBUtil.IsEmpty(grvKgPosition.GetRowCellValue(e.RowHandle, e.Column)))
            //////////        e.RepositoryItem = repositoryItemPictureEdit1;
            //////////    else
            //////////        e.RepositoryItem = repositoryItemCheckEdit1;

            //////////}
        }

        private void qryBelege_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Column == qryBelege.DataTable.Columns["Sel"] && !updatingBuchung &&
                qryBelege.Row["KgBuchungStatusCode", DataRowVersion.Original].Equals(qryBelege.Row["KgBuchungStatusCode"]))
            {
                // durch das Ändern der Selektion soll nicht der Eintrag als verändert markieren werden
                qryBelege.RowModified = false;
                qryBelege.Row.AcceptChanges();
            }
        }

        private void qryBelege_PositionChanged(object sender, System.EventArgs e)
        {
            try
            {
                btnBarbelegGruen.Visible = DBUtil.UserHasRight("CtlKgBudget_BarbelegGruenStellen") &&
                                               ((int)qryBelege["KgBuchungStatusCode"] == 4);  //ausgedruckt
            }
            catch (Exception ex)
            {
                btnBarbelegGruen.Visible = false;
                throw ex;
            }
        }

        private void qryKgBudget_BeforePost(object sender, System.EventArgs e)
        {
            DBUtil.CheckNotNullField(edtBewilligtVon, lblBewilligtVon.Text);
            DBUtil.CheckNotNullField(edtBewilligtBis, "Dauer bis");

            //Datumskorrekturen, falls untermonatig
            qryKgBudget["BewilligtVon"] = Utils.firstDayOfMonth((DateTime)qryKgBudget["BewilligtVon"]);
            qryKgBudget["BewilligtBis"] = Utils.lastDayOfMonth((DateTime)qryKgBudget["BewilligtBis"]);

            //check Datumsbereichüberschneidung
            SqlQuery qry = DBUtil.OpenSQL(@"
                select  top 1 1
                from    KgBudget BDG
                where   BDG.FaLeistungID = {0} and
                    KgBudgetID <> {1} and
                            KgMasterBudgetID is null and
                       ({2} between BewilligtVon and BewilligtBis or
                        {3} between BewilligtVon and BewilligtBis or
                        ({2} <= BewilligtVon and {3} >= BewilligtBis))",
                FaLeistungID,
                qryKgBudget["KgBudgetID"],
                qryKgBudget["BewilligtVon"],
                qryKgBudget["BewilligtBis"]);

            if (qry.Count > 0)
            {
                KissMsg.ShowInfo("Der Datumsbereich des Masterbudgets kann nicht gespeichert werden, da er sich mit bestehenden überschneidet");
                throw new Exception();
            }
        }

        private void qryKgBudget_ColumnChanging(object sender, System.Data.DataColumnChangeEventArgs e)
        {
            qryKgBudget.RowModified = true;
        }

        private void qryKgDokumente_AfterDelete(object sender, EventArgs e)
        {
            // try to delete XDocument
            try
            {
                var documentID = (int?)qryKgDokumente["DocumentID"];
                if (documentID.HasValue)
                {
                    DBUtil.ExecSQL("DELETE FROM XDocument WHERE DocumentID = {0}", documentID.Value);
                }
            }
            catch { }
        }

        private void qryKgDokumente_AfterInsert(object sender, System.EventArgs e)
        {
            string Stichwort = qryKgPosition["Konto"].ToString();
            try
            {
                qryKgDokumente["Stichwort"] = Stichwort.Substring(Stichwort.IndexOf(" "));
            }
            catch { }

            qryKgDokumente["KgDokumentTypCode"] = 1;
            edtDokumentTyp.Focus();
        }

        private void qryKgDokumente_BeforePost(object sender, System.EventArgs e)
        {
            if (!qryKgDokumente.IsSilentPostingFromXDocument && DBUtil.IsEmpty(qryKgDokumente["DocumentID"]))
            {
                KissMsg.ShowInfo("Erfassen sie zuerst ein Dokument.");
                throw new KissCancelException();
            }

            if ((int)qryKgDokumente["KgDokumentTypCode"] == 1)
            {
                qryKgDokumente["KgPositionID"] = qryKgPosition["KgPositionID"];
                qryKgDokumente["KgBudgetID"] = DBNull.Value;
            }
            else
            {
                qryKgDokumente["KgPositionID"] = DBNull.Value;
                qryKgDokumente["KgBudgetID"] = qryKgPosition["KgBudgetID"];
            }

            if (DBUtil.IsEmpty(qryKgDokumente["Stichwort"]))
                qryKgDokumente["Stichwort"] = "-";
        }

        private void qryKgPosition_AfterDelete(object sender, EventArgs e)
        {
            Session.Commit();
        }

        private void qryKgPosition_AfterInsert(object sender, System.EventArgs e)
        {
            qryKgPosition["Gruppe"] = 0;
            qryKgPosition["KgPositionsKategorieCode"] = newKgPositionsKategorieCode;
            qryKgPosition["KategorieCode"] = newKgPositionsKategorieCode;
            qryKgPosition["KgBudgetID"] = KgBudgetID;
            qryKgPosition["BuchungDatum"] = DateTime.Today;
            qryKgPosition["Doc"] = false;
            qryKgPosition["Status"] = 1; // grau

            if (isMasterbudget)
            {
                if ((int)qryKgBudget["KgBewilligungCode"] >= 5)
                {
                    qryKgPosition["KgBewilligungCode"] = 3; // angefragt
                    qryKgPosition["DatumVon"] = (new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1)).AddMonths(1); //1. des nächsten Monats vorschlagen
                }
            }
            else
            {
                qryKgPosition["KgBewilligungCode"] = 1; // In Vorbereitung
            }

            SqlQuery qry2 = DBUtil.OpenSQL(@"
                select VornameName,WohnsitzStrasseHausNr,WohnsitzPLZOrt
                from   vwPerson
                where  BaPersonID = {0}",
                BaPersonID);

            switch (newKgPositionsKategorieCode)
            {
                case 1: //Auszahlungen Klientin

                    //falls ausser ZKB-Kontokorrent kein weiterer Zahlungsweg bei Klient vorhanden: Cash vorschlagen
                    //sonst elektronisch vorschlagen

                    SqlQuery qry = DBUtil.OpenSQL(@"
                        select BaZahlungswegID
                        from   BaZahlungsweg
                                    where  BaPersonID = {0} and
                                   getdate() between isnull(DatumVon,getdate()) and isnull(DatumBis,getdate()) and
                               BaZahlungswegID <> (select top 1 PER.BaZahlungswegID
                                                   from   FaLeistung LEI
                                                          inner join KgPeriode PER on PER.FaLeistungID = LEI.FaLeistungID
                                                   where  LEI.BaPersonID = {0} and
                                                          LEI.FaProzessCode = 500
                                                   order by PER.PeriodeVon desc)",
                    this.BaPersonID);

                    if (qry.Count == 0)
                    {
                        qryKgPosition["KgAuszahlungsArtCode"] = 103; //cash
                        qryKgPosition["MitteilungZeile1"] = TruncateString(qry2["VornameName"], 35);
                        qryKgPosition["MitteilungZeile2"] = TruncateString(qry2["WohnsitzStrasseHausNr"], 35);
                        qryKgPosition["MitteilungZeile3"] = TruncateString(qry2["WohnsitzPLZOrt"], 35);
                    }
                    else
                    {
                        qryKgPosition["KgAuszahlungsArtCode"] = 101; //elektronisch
                        qryKgPosition["MitteilungZeile1"] = TruncateString(qry2["VornameName"], 35);
                    }
                    qryKgPosition["KgAuszahlungsTerminCode"] = 1; // 1 x pro Monat
                    LoadValutaTermine();
                    DisplayCalendarBoldDates();

                    break;

                case 2: //Auszahlungen Dritte
                    qryKgPosition["KgAuszahlungsArtCode"] = 101; //elektronisch
                    qryKgPosition["KgAuszahlungsTerminCode"] = 4; //Valuta
                    qryKgPosition["MitteilungZeile1"] = TruncateString(qry2["VornameName"], 35);
                    break;

                case 3: //Einnahmen
                    qryKgPosition["KgAuszahlungsTerminCode"] = 4; //Valuta
                    break;
            }

            newKgPositionsKategorieCode = 0;
            tabKgPosition.SelectedTabIndex = 0;
            SetPositionEditMode();

            ctlErfassungMutation1.ShowInfo();

            //if (DBUtil.IsEmpty(qryKgPosition["BuchungDatum"]))
            //	edtBuchungDatum.Focus();
            //else
            edtKonto.Focus();

            firstPostAfterPositionInsert = true;
        }

        private void qryKgPosition_AfterPost(object sender, System.EventArgs e)
        {
            bool gruppe = ((int)qryKgPosition["Gruppe"] == 1);
            int kategorie = (int)qryKgPosition["KgPositionsKategorieCode"];

            if (!gruppe)
            {
                //Valuta-Termine speichern
                SaveValutaTermine();

                if (masterBetragValutaDebitorAnpassung)
                {
                    DBUtil.ExecSQLThrowingException(@"
                      UPDATE KgPosition
                      SET    Betrag = {0},
                             BaInstitutionID = {1}
                      FROM   KgPosition     POS
                        LEFT JOIN KgBuchung BUC ON BUC.KgPositionID = POS.KgPositionID
                      WHERE  MasterbudgetPositionID = {3} AND (BUC.KgBuchungID IS NULL OR BUC.KgBuchungStatusCode IN (1, 2, 7)) -- vorbereitet, freigegeben, gesperrt

                      UPDATE KgPositionValuta
                      SET    Datum = DateAdd(m, DateDiff(m, MAS.BewilligtVon, dbo.fnDateSerial(BUD.Jahr, BUD.Monat, 1)), {2})
                      FROM   KgPositionValuta VAL
                        INNER JOIN KgPosition POS ON POS.KgPositionID = VAL.KgPositionID
                        LEFT JOIN KgBuchung   BUC ON BUC.KgPositionID = POS.KgPositionID
                        INNER JOIN KgBudget   BUD ON BUD.KgBudgetID = POS.KgBudgetID
                        INNER JOIN KgBudget   MAS ON MAS.KgBudgetID = BUD.KgMasterBudgetID
                      WHERE  POS.MasterbudgetPositionID = {3} AND (BUC.KgBuchungID IS NULL OR BUC.KgBuchungStatusCode IN (1, 2, 7)) -- vorbereitet, freigegeben, gesperrt

                      UPDATE BUC
                      SET    Betrag = {0},
                             BaInstitutionID = {1},
                             ValutaDatum = DateAdd(m, DateDiff(m, MAS.BewilligtVon, dbo.fnDateSerial(BUD.Jahr, BUD.Monat, 1)), {2})
                      FROM   KgBuchung BUC
                        INNER JOIN KgPosition POS on POS.KgPositionID = BUC.KgPositionID
                        INNER JOIN KgBudget   BUD ON BUD.KgBudgetID = POS.KgBudgetID
                        INNER JOIN KgBudget   MAS ON MAS.KgBudgetID = BUD.KgMasterBudgetID
                      WHERE  POS.MasterbudgetPositionID = {3} AND (BUC.KgBuchungID IS NULL OR BUC.KgBuchungStatusCode IN (1, 2, 7)) -- vorbereitet, freigegeben, gesperrt",
                    qryKgPosition["Betrag"],
                    qryKgPosition["BaInstitutionID"],
                    qryKgPosition["ValutaDatum"],
                    qryKgPosition["KgPositionID"]);
                }

                if (DebitorValutaBetragsAnpassung)
                {
                    DBUtil.ExecSQLThrowingException(@"
                        UPDATE BUC
                        SET    Betrag = {0},
                               ValutaDatum = {1},
                               BaInstitutionID = {2}
                        FROM   KgBuchung BUC
                        WHERE  KgPositionID = {3}",
                        qryKgPosition["Betrag"],
                        qryKgPosition["ValutaDatum"],
                        qryKgPosition["BaInstitutionID"],
                        qryKgPosition["KgPositionID"]);
                }
                if (BuchungsdatumAnpassung)
                {
                    var auszahlungsArt = qryKgPosition["KgAuszahlungsArtCode"] as int?;
                    IList<int> selectedIDs = null;
                    if (auszahlungsArt == 103)
                    {
                        selectedIDs = qryBelege.DataTable.Select("Sel = 1").Select(row => (int)row["KgBuchungID"]).ToList();
                    }
                    else if (qryBelege.HasRow)
                    {
                        selectedIDs = new List<int> { (int)qryBelege["KgBuchungID"] };
                    }
                    KgBuchungshelper.buchungsDatumAnpassen((int)qryKgPosition["KgPositionID"], selectedIDs, (DateTime)qryKgPosition["BuchungDatum"]);
                }
            }

            // Hier müssen allenfalls noch Monatsbudget-Positionen gelöscht werden, weil das DatumBis geändert wurde (Das SQLQuery wird im BeforePost() abgefüllt).
            try
            {
                if (qryPositionenZuLoeschen != null)
                {
                    foreach (DataRow R in qryPositionenZuLoeschen.DataTable.Rows)
                    {
                        // Lösche alle Referenzen zu dieser Position
                        DBUtil.ExecSQL(@"
                        DELETE FROM KgPositionValuta
                        WHERE KgPositionID = {0}

                        DELETE FROM KgBuchung
                        WHERE KgPositionID = {0}

                        DELETE FROM KgBewilligung WHERE KgPositionID = {0}

                        DELETE FROM KgPosition
                        WHERE KgPositionID = {0}
                        ", R["KgPositionID"]);
                    }
                }
            }
            finally
            {
                qryPositionenZuLoeschen = null;
            }

            // Setze die Positions-Bewilligung im bewilligten Masterbudget, falls diese Position eben erst eingefügt wurde
            if (firstPostAfterPositionInsert &&
                isMasterbudget &&
                (int)qryKgBudget["KgBewilligungCode"] >= 5 &&
                (DBUtil.IsEmpty(qryKgPosition["KgBewilligungCode"]) || (int)qryKgPosition["KgBewilligungCode"] != 5))
            {
                bool darfVisieren = UserDarfVisieren();

                if (darfVisieren)
                {
                    // Der User hat Bewilligungs-Kompetenz => Position wird bewilligt
                    DBUtil.ExecSQLThrowingException(@"
                            EXEC spKgPositionBewilligen {0}, {1}
                            ", qryKgPosition["KgPositionID"], Session.User.UserID);
                }
                else
                {
                    // Die Position bleibt in Vorbereitung
                    qryKgPosition["KgBewilligungCode"] = 3; // angefragt
                }
            }
            firstPostAfterPositionInsert = false;

            if (!qryKgDokumente.Post())
            {
                tabKgPosition.SelectedTabIndex = 1;
                throw new KissCancelException();
            }

            // Nachträgliche Änderung am Buchungstext/-datum/Konto
            if (edtEntsperren.Visible && edtEntsperren.Checked && _kontoNrModified)
            {
                KgBuchungshelper.kontoAnpassen((int)qryKgPosition["KgPositionID"],
                    null,
                    kategorie == 1 || kategorie == 2 ? (string)qryKgPosition["KontoNr"] : null,  //Kreditor
                    kategorie == 1 || kategorie == 2 ? null : (string)qryKgPosition["KontoNr"] //Debitor
                    );
            }
            if (edtEntsperren.Visible && edtEntsperren.Checked && _buchungstextModified)
            {
                KgBuchungshelper.buchungstextAnpassen((int)qryKgPosition["KgPositionID"], null,
                    (string)qryKgPosition["Buchungstext"]);
            }
            if (edtEntsperren.Visible && edtEntsperren.Checked && _baInstitutionModified)
            {
                KgBuchungshelper.debitorAnpassen((int)qryKgPosition["KgPositionID"], (int)qryKgPosition["BaInstitutionID"]);
            }

            if (_isNewPosition)
            {
                InsertPositionVerlaufEintrag(KgBewilligung.Erstellt, (int)qryKgPosition["KgPositionID"]);
            }

            Session.Commit();

            if (edtEntsperren.Visible)
            {
                // Als visuelle Rückmeldung wieder sperren
                edtEntsperren.Checked = false;
                SetPositionEditMode();
                qryBelege.Refresh();
            }

            var status = qryKgPosition["Status"] as int?;
            if (((int)qryKgPosition["KgPositionsKategorieCode"] == 1 || (int)qryKgPosition["KgPositionsKategorieCode"] == 2) // Auszahlung Klient/Dritte
                && status != 6) //KZH-2169: ausgeglichen soll keine validierung stattfinden
            {
                if (KgValidierungsHelper.KgCheckVerkehrskonto(this.FaLeistungID, edtBuchungDatum.DateTime))
                {
                    KissMsg.ShowInfo(KgValidierungsHelper.ErrorMsg_Verkehrskonto_ungueltig);
                }
            }
        }

        private void qryKgPosition_BeforeDelete(object sender, EventArgs e)
        {
            try
            {
                Session.BeginTransaction();
                DBUtil.ExecSQLThrowingException(@"
                    DELETE KgPositionValuta WHERE KgPositionID = {0}
                    DELETE KgDokument WHERE KgPositionID = {0}
                    DELETE KgBewilligung WHERE KgPositionID = {0}
                    DELETE KgBuchung        WHERE KgPositionID IN (SELECT KgPositionID FROM KgPosition WHERE MasterbudgetPositionID = {0}) AND
                                                  KgBuchungStatusCode IN (1,2,5,7)
                    DELETE KgPositionValuta WHERE KgPositionID IN (SELECT KgPositionID FROM KgPosition WHERE MasterbudgetPositionID = {0})
                    DELETE KgDokument       WHERE KgPositionID IN (SELECT KgPositionID FROM KgPosition WHERE MasterbudgetPositionID = {0})
                    DELETE KgBewilligung    WHERE KgPositionID IN (SELECT KgPositionID FROM KgPosition WHERE MasterbudgetPositionID = {0})
                    DELETE KgPosition       WHERE KgPositionID IN (SELECT KgPositionID FROM KgPosition WHERE MasterbudgetPositionID = {0})",
                    qryKgPosition["KgPositionID"]);
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowError("Beim Löschen der Position ist ein Fehler aufgetreten", ex);
            }
        }

        private void qryKgPosition_BeforeDeleteQuestion(object sender, System.EventArgs e)
        {
            bool gruppe = ((int)qryKgPosition["Gruppe"] == 1);

            if (gruppe)
                throw new KissInfoException("Gruppenzeilen können nicht gelöscht werden!");

            //nicht löschbar, wenn
            //- in einem abgeschlossenen oder bewilligten,abgelaufenen Masterbudget
            //- in einer Masterbudgetposition eines Monatsbudgets
            //- in einer nicht grauen Position eines Monatsbudgets

            int BewilligungCode = (int)qryKgBudget["KgBewilligungCode"];
            int PositionStatus = isMasterbudget ? 0 : (int)qryKgPosition["Status"];

            if (isMasterbudget)
            {
                if (BewilligungCode == 9 ||
                   (BewilligungCode == 5 && ((DateTime)qryKgBudget["BewilligtBis"]) <= DateTime.Today))
                {
                    throw new KissInfoException("Das Masterbudget ist bereits beendet!");
                }

                if (PositionStatus != 1)
                {
                    //Gibt es bereits abhängige, verbuchte Monatsbudget-Positionen?
                    if ((int)DBUtil.ExecuteScalarSQL(@"
                        select count(*)
                        from   KgPosition POS
                               inner join KgBuchung BUC on BUC.KgPositionID = POS.KgPositionID and
                                                           BUC.KgBuchungStatusCode not in (1,2,5,7)
                        where  MasterbudgetPositionID = {0}",
                        qryKgPosition["KgPositionID"]) > 0)
                    {
                        throw new KissInfoException("Zu dieser Masterbudget-Position gibt es bereits verbuchte Belege!");
                    }

                    //Gibt es Monatsbudget-Positionen mit angehängten Dokumenten?
                    if ((int)DBUtil.ExecuteScalarSQL(@"
                        select count(*)
                        from   KgPosition POS
                               inner join KgDokument DOC on DOC.KgPositionID = POS.KgPositionID
                        where  MasterbudgetPositionID = {0}",
                        qryKgPosition["KgPositionID"]) > 0)
                    {
                        throw new KissInfoException("Löschen nicht erlaubt: In den zu löschenden Monatsbudget-Position gibt es bereits angehängte Dokumente!");
                    }
                }
            }
            else
            {
                if (PositionStatus != 1)
                    throw new KissInfoException("nur graue Positionen können gelöscht werden!");

                if (!DBUtil.IsEmpty(qryKgPosition["MasterbudgetPositionID"]))
                    throw new KissInfoException("Positionen, die aus einem Masterbudget kopiert wurden, können nicht gelöscht werden!");
            }
        }

        private void qryKgPosition_BeforeInsert(object sender, System.EventArgs e)
        {
            if (newKgPositionsKategorieCode != 0)
                return;

            KissLookupDialog dlg = new KissLookupDialog();
            bool cancel = !dlg.SearchData(@"
              SELECT Code$ = Code,
                     Text
              FROM   XLOVCode
              WHERE  LOVName = 'KgPositionsKategorie'
              ORDER BY SortKey",
              "",
              true, null, null, null);

            if (cancel)
            {
                throw new KissCancelException();
            }
            else
            {
                newKgPositionsKategorieCode = (int)dlg["Code$"];
            }
        }

        private void qryKgPosition_BeforePost(object sender, System.EventArgs e)
        {
            _buchungstextModified = qryKgPosition.ColumnModified("Buchungstext");
            _kontoNrModified = qryKgPosition.ColumnModified("KontoNr");
            _baInstitutionModified = qryKgPosition.ColumnModified("BaInstitutionID");
            bool gruppe = ((int)qryKgPosition["Gruppe"] == 1);
            if (gruppe)
            {
                qryKgPosition.RowModified = false;
                qryKgPosition.Row.AcceptChanges();
                return;
            }

            DBUtil.CheckNotNullField(edtBuchungDatum, lblBuchungDatum.Text);
            DBUtil.CheckNotNullField(edtKonto, lblKonto.Text);
            DBUtil.CheckNotNullField(edtBuchungstext, lblBuchungstext.Text);
            DBUtil.CheckNotNullField(edtBetrag, lblBetrag.Text);

            if (Convert.ToDecimal(qryKgPosition["Betrag"]) <= Decimal.Zero)
            {
                tabKgPosition.SelectedTabIndex = 0;
                edtBetrag.Focus();
                throw new KissInfoException("Der Betrag darf nicht 0.00 oder negativ sein!");
            }

            int kategorie = (int)qryKgPosition["KgPositionsKategorieCode"];
            int auszahlungsTermin = (int)qryKgPosition["KgAuszahlungsTerminCode"];
            int auszahlungsArt = (kategorie == 3) ? 0 : (int)qryKgPosition["KgAuszahlungsArtCode"];
            int bewilligungCode = (int)qryKgBudget["KgBewilligungCode"];

            int ES = 0;
            if (!DBUtil.IsEmpty(qryKgPosition["EinzahlungsscheinCode"]))
                ES = (int)qryKgPosition["EinzahlungsscheinCode"];

            if (auszahlungsTermin == 4)
            {
                CheckNotNullFieldOnTabPage(edtValutaDatum, lblValutaDatum.Text, tpgZahlinfo);
            }

            if (auszahlungsTermin == 6)
            {
                CheckNotNullFieldOnTabPage(edtWochentagCodes, "Wochentage", tpgKalender);
            }

            if (auszahlungsTermin == 99 && qryKgPositionValuta.Count == 0)
            {
                throw new KissInfoException("Es sind noch keine individuellen Auszahltermine erfasst.");
            }

            if (auszahlungsArt == 101) // elektronische Auszahlung
            {
                CheckNotNullFieldOnTabPage(edtKreditor, lblKreditor.Text, tpgZahlinfo);
            }

            if (auszahlungsArt == 103) // bar
            {
                CheckNotNullFieldOnTabPage(edtMitteilungZeile1, lblZahlbarAn.Text, tpgMitteilung);
            }

            if (ES == 1)
            {
                CheckNotNullFieldOnTabPage(edtReferenzNummer, lblReferenzNummer.Text, tpgZahlinfo);
            }

            masterBetragValutaDebitorAnpassung = masterBetragValutaDebitorAnpassung && (qryKgPosition.ColumnModified("Betrag") ||
                                             qryKgPosition.ColumnModified("ValutaDatum") ||
                                             qryKgPosition.ColumnModified("BaInstitutionID"));
            BuchungsdatumAnpassung = BuchungsdatumAnpassung && qryKgPosition.ColumnModified("BuchungDatum");

            DebitorValutaBetragsAnpassung = DebitorValutaBetragsAnpassung &&
                                            (qryKgPosition.ColumnModified("Betrag") ||
                                             qryKgPosition.ColumnModified("ValutaDatum") ||
                                             qryKgPosition.ColumnModified("BaInstitutionID"));

            // Nachträgliche Änderung am Buchungstext/-datum/Konto
            if (edtEntsperren.Visible && edtEntsperren.Checked)
            {
                KgPeriodeID = DBUtil.ExecuteScalarSQLThrowingException(@"
                    SELECT  TOP 1 KgPeriodeID
                    FROM    dbo.KgPeriode WITH (READUNCOMMITTED)
                    WHERE   FaLeistungID = {0} AND
                            KgPeriodeStatusCode = 1 AND -- aktiv
                            {1} BETWEEN PeriodeVon AND PeriodeBis",
                    qryKgBudget["FaLeistungID"],
                    qryKgPosition["BuchungDatum"]);

                if (KgPeriodeID == null)
                {
                    edtBuchungDatum.Focus();
                    throw new KissInfoException("Für das neue Buchungsdatum existiert keine aktive Buchungsperiode!");
                }
            }

            qryKgPosition["MitteilungZeile1"] = TruncateString(qryKgPosition["MitteilungZeile1"], 35);
            qryKgPosition["MitteilungZeile2"] = TruncateString(qryKgPosition["MitteilungZeile2"], 35);
            qryKgPosition["MitteilungZeile3"] = TruncateString(qryKgPosition["MitteilungZeile3"], 35);

            if (isMasterbudget)
            {
                if (auszahlungsTermin == 4 && qryKgPosition.ColumnModified("ValutaDatum") && ((DateTime)qryKgPosition["ValutaDatum"] < DateTime.Today) && !masterBetragValutaDebitorAnpassung)
                {
                    CheckValutaDatum(kategorie, auszahlungsTermin, (DateTime)qryKgPosition["ValutaDatum"]);
                }

                if (!DBUtil.IsEmpty(qryKgPosition["DatumVon"]) &&
                    !DBUtil.IsEmpty(qryKgPosition["DatumBis"]) &&
                    (DateTime)qryKgPosition["DatumVon"] > (DateTime)qryKgPosition["DatumBis"])
                {
                    throw new KissInfoException("Das 'Gültig von' - Datum darf nicht nach dem 'Gültig bis' - Datum sein!");
                }

                if (qryKgPosition.ColumnModified("DatumVon") && qryKgPosition.Row.RowState != DataRowState.Added)
                {
                    if (DBUtil.IsEmpty(qryKgPosition["DatumVon"]) || ((DateTime)qryKgPosition["DatumVon"]) < Utils.firstDayOfMonth(DateTime.Today))
                        throw new KissInfoException("'Gültig von' darf nicht auf einen vergangenen Monat mutiert werden!");
                }

                if (!DBUtil.IsEmpty(qryKgPosition["DatumVon"]) && qryKgPosition.ColumnModified("DatumVon"))
                {
                    qryKgPosition["DatumVon"] = Utils.firstDayOfMonth((DateTime)qryKgPosition["DatumVon"]); //Datumskorrektur, falls untermonatig
                }

                DateTime newDatumBis = DateTime.MinValue;
                if (!DBUtil.IsEmpty(qryKgPosition["DatumBis"]))
                {
                    if (qryKgPosition.ColumnModified("DatumBis"))
                        qryKgPosition["DatumBis"] = Utils.lastDayOfMonth((DateTime)qryKgPosition["DatumBis"]); //Datumskorrektur, falls untermonatig

                    newDatumBis = (DateTime)qryKgPosition["DatumBis"];
                }

                if (bewilligungCode >= 5)   // Dies ist ein bewilligtes Budget, d.h. wir müssen hier noch ein paar weitere Prüfungen machen
                {
                    //if (qryKgPosition.Row.RowState == DataRowState.Added)
                    //    DBUtil.CheckNotNullField(edtDatumBis, lblGueltigBis.Text);

                    DateTime oldDatumBis = DateTime.MinValue;
                    try
                    {
                        if (!DBUtil.IsEmpty(qryKgPosition.Row["DatumBis", DataRowVersion.Original]))
                        {
                            oldDatumBis = (DateTime)qryKgPosition.Row["DatumBis", DataRowVersion.Original];
                        }
                    }
                    catch (Exception ex)
                    {
                        // Eintrag ins Log.
                        LOG.ErrorFormat("Fehler in: [{0}]. Exception: [{1}]", GetType().FullName, ex.Message);

                        // Eintrag ins Log (Ansicht unter Anwendung/Newod Schnittstelle/Protokolle)
                        XLog.Create(GetType().FullName, LogLevel.ERROR, ex.Message);

                        oldDatumBis = DateTime.MinValue;
                    }

                    if (oldDatumBis != DateTime.MinValue && newDatumBis == DateTime.MinValue)
                    {
                        // Das DatumBis war gesetzt vorher, nun aber nicht mehr => Fehlermeldung
                        edtDatumBis.Focus();
                        throw new KissInfoException("Ein bestehendes 'Gültig bis' - Datum darf nicht gelöscht werden!");
                    }

                    if (qryPositionenZuLoeschen != null)
                        qryPositionenZuLoeschen.DataTable.Rows.Clear();

                    // Falls das Datum Bis verkürzt wurde, müssen wir allenfalls noch existierende Positionen in späteren Monatsbudgets löschen
                    if (newDatumBis != DateTime.MinValue)
                    {
                        //neues Datum muss kleiner sein als das bisherige
                        if (oldDatumBis != DateTime.MinValue && newDatumBis > oldDatumBis)
                        {
                            edtDatumBis.Focus();
                            throw new KissInfoException("Das neue 'Gültig bis' muss vor dem bisherigen Datum sein!");
                        }

                        // Hole alle zu löschenden Budget-Positionen (d.h. alle Positionen, die nach dem neuen EndDatum liegen) für diese Master-Position mit Zusatzinfos
                        qryPositionenZuLoeschen = DBUtil.OpenSQL(@"
                            SELECT
                            KgPositionID = POS.KgPositionID,
                            Position = 'Monatsbudget ' + dbo.fnLOVShortText('Monat', BUD.Monat) + ' ' + CONVERT(varchar, BUD.Jahr) + ', ' + dbo.fnLOVText('KgPositionsKategorie', POS.KgPositionsKategorieCode) + ': ' + POS.Buchungstext + ' à ' + CONVERT(varchar, POS.Betrag),
                            KgBuchungStatusCode = BUC.KgBuchungStatusCode,
                            PositionHatGeandert = CONVERT(bit, CASE WHEN POS.KgAuszahlungsArtCode <> MPOS.KgAuszahlungsArtCode OR
                                                                         POS.KgAuszahlungsTerminCode <> MPOS.KgAuszahlungsTerminCode OR
                                                                         POS.Betrag <> MPOS.Betrag THEN 1 ELSE 0 END)
                            FROM KgPosition POS
                            LEFT JOIN dbo.KgPosition	MPOS WITH(READUNCOMMITTED) ON MPOS.KgPositionID = POS.MasterBudgetPositionID
                            LEFT JOIN dbo.KgBudget		BUD WITH(READUNCOMMITTED) ON BUD.KgBudgetID = POS.KgBudgetID
                            LEFT JOIN dbo.KgBuchung     BUC WITH(READUNCOMMITTED) ON BUC.KgPositionID = POS.KgPositionID AND
                                                                     BUC.KgBuchungID =
                                                                        (SELECT TOP 1 KgBuchungID FROM dbo.KgBuchung B WITH(READUNCOMMITTED)
                                                                        INNER JOIN dbo.XLOVCode S WITH(READUNCOMMITTED) on S.LOVName = 'KgBuchungsStatus' AND
                                                                                             S.Code = KgBuchungStatusCode
                                                                        WHERE  KgPositionID = POS.KgPositionID
                                                                        ORDER BY S.SortKey DESC)
                            WHERE POS.MasterBudgetPositionID = {0} AND CONVERT(datetime, CONVERT(varchar, BUD.Jahr) + '-' + CONVERT(varchar, BUD.Monat)  + '-01') > {1}",
                            qryKgPosition["KgPositionID"],
                            newDatumBis);

                        // Iteriere durch alle zu löschenden Positionen und prüfe sie
                        string posGeldfluss = "";
                        string posHatGeandert = "";
                        string posGesperrt = "";
                        foreach (DataRow R in qryPositionenZuLoeschen.DataTable.Rows)
                        {
                            // Hat diese Monatsbudget-Position einen Geldfluss uns ist in einem Budget, das nach dem neuen DatumBis ist? Falls ja, Fehlermeldung
                            if (!DBUtil.IsEmpty(R["KgBuchungStatusCode"]) && ((int)R["KgBuchungStatusCode"] > 2 && (int)R["KgBuchungStatusCode"] != 7))  // übermittelt, aber nicht gesperrt
                            {
                                // Ja, merke die Position für die Fehlerausgabe weiter unten
                                posGeldfluss = posGeldfluss + "\r\n" + R["Position"];
                            }

                            // Falls diese Monatsbudget-Position gesperrt ist, dann Hinweis anzeigen mit Abbruchmöglichkeit
                            if (!DBUtil.IsEmpty(R["KgBuchungStatusCode"]) && (int)R["KgBuchungStatusCode"] == 7)   // gesperrt
                            {
                                // Ja, merke die Position für die Fehlerausgabe weiter unten
                                posGesperrt = posGesperrt + "\r\n" + R["Position"];
                            }

                            // Falls die zu löschende Position von der Masterbudget-Position abweicht (zB. Auszahlart, Termin, Fälligkeitsdatum, ...) dann Hinweis anzeigen mit Abbruchmöglichkeit
                            if ((bool)R["PositionHatGeandert"])
                            {
                                // Ja, merke die Position für die Fehlerausgabe weiter unten
                                posHatGeandert = posHatGeandert + "\r\n" + R["Position"];
                            }
                        }

                        if (posGeldfluss != "")
                        {
                            throw new KissInfoException("Das 'Gültig bis' Datum kann nicht auf " + newDatumBis.ToString("dd.MM.yyyy") + " gesetzt werden, da bereits folgende Budget-Positionen mit Geldfluss existieren:" + posGeldfluss);
                        }

                        if (posGesperrt != "")
                        {
                            if (!KissMsg.ShowQuestion("Wenn Sie das 'Datum Bis' dieser Position auf " + newDatumBis.ToString("dd.MM.yyyy") + " ändern, dann werden folgende gesperrte Monatsbudget-Positionen gelöscht. Soll die Datums-Anpassung trotzdem durchgeführt werden?" + posGesperrt))
                            {
                                // Benutzer hat das Speichern abgebrochen
                                throw new KissCancelException();
                            }
                        }

                        if (posHatGeandert != "")
                        {
                            if (!KissMsg.ShowQuestion("Wenn Sie das 'Datum Bis' dieser Position auf " + newDatumBis.ToString("dd.MM.yyyy") + " ändern, dann werden folgende Monatsbudget-Positionen, die manuell angepasst wurden, gelöscht. Soll die Datums-Anpassung trotzdem durchgeführt werden?" + posHatGeandert))
                            {
                                // Benutzer hat das Speichern abgebrochen
                                throw new KissCancelException();
                            }
                        }
                    }
                    //Prüfung, ob von diesem Konto mehrere Leistungen im selben Zeitraum vorhanden sind
                    if ((int)DBUtil.ExecuteScalarSQL(@"
                        select count(*)
                        from   KgPosition
                        where  KgBudgetID = {0} and
                               KgPositionID <> isnull({1},-1) and
                               KontoNr = {2} and
                               dbo.fnDatumUeberschneidung(isnull({3},'19000101'),
                                                          isnull({4},'29990101'),
                                                          isnull(DatumVon,'19000101'),
                                                          isnull(DatumBis,'29990101')) = 1",
                        qryKgBudget["KgBudgetID"],
                        qryKgPosition["KgPositionID"],
                        qryKgPosition["KontoNr"],
                        qryKgPosition["DatumVon"],
                        qryKgPosition["DatumBis"]) > 0)
                    {
                        KissMsg.ShowInfo(string.Format("Achtung: Zum Konto {0} gibt es in diesem Masterbudget weitere Positionen, die sich zeitlich überschneiden!", qryKgPosition["KontoNr"]));
                    }
                }
            }
            else
            {
                if (DBUtil.IsEmpty(qryKgPosition["M"])) //Monatsbudget-Positionen aus dem Masterbudget sollen nicht validiert werden
                {
                    CheckValutaDatum(kategorie, auszahlungsTermin, qryKgPosition["ValutaDatum"] as DateTime?);
                }
            }

            _isNewPosition = qryKgPosition.CurrentRowState == DataRowState.Added;

            ctlErfassungMutation1.SetFields();
            CheckPositionBarzahlungBetrag();
            Session.BeginTransaction(); // Alles oder nichts, Fehlerbehandlung(Rollback) durch SqlQuery
        }

        private void qryKgPosition_PositionChanged(object sender, System.EventArgs e)
        {
            if (refreshing)
                return;
            if (qryKgPosition.Row.RowState == DataRowState.Added)
                return;

            if (DBUtil.IsEmpty(qryKgPosition["Gruppe"]))
            {
                qryKgPosition.EnableBoundFields(false);
                return;
            }

            bool gruppe = ((int)qryKgPosition["Gruppe"] == 1);

            int kategorie = 0;
            if (!DBUtil.IsEmpty(qryKgPosition["KgPositionsKategorieCode"]))
                kategorie = (int)qryKgPosition["KgPositionsKategorieCode"];

            SetPositionEditMode();
            if (!gruppe)
            {
                qryKgPositionValuta.Fill("SELECT * FROM KgPositionValuta WHERE KgPositionID = {0} ORDER BY Datum", qryKgPosition["KgPositionID"]);
                if (kategorie == 1)
                    DisplayCalendarBoldDates();
                qryKgDokumente.Fill(qryKgPosition["KgPositionID"]);
                btnBarbelegGruen.Visible = false;
                qryBelege.Fill(qryKgPosition["KgPositionID"]);
                qryKgBewilligung.Fill(qryKgPosition["KgPositionID"]);
            }

            ctlErfassungMutation1.ShowInfo();

            if (qryKgPosition.Row.RowState != DataRowState.Added)
                grdKgPosition.Focus();
        }

        private void qryKgPosition_PostCompleted(object sender, System.EventArgs e)
        {
            qryKgPosition.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ApplicationFacade.DoEvents();
            timer1.Enabled = false;

            DateTime firstDate = new DateTime((int)qryKgBudget["Jahr"], (int)qryKgBudget["Monat"], 1);
            CalendarFilling = true;
            edtCalendar.SelectionRange = new SelectionRange(firstDate, firstDate.AddDays(1));
            CalendarFilling = false;
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string FieldName)
        {
            switch (FieldName.ToUpper())
            {
                case "KGBUCHUNGID":
                    return qryBelege["KgBuchungID"];

                case "KASSEUSERID":
                    return Session.User.UserID;
            }

            return base.GetContextValue(FieldName);
        }

        public void Init(string Name, Image TitleImage, int KgBudgetID, int KgMasterbudgetID, int FaLeistungID, int BaPersonID)
        {
            picTitel.Image = TitleImage;
            lblTitel.Text = Name;

            this.KgBudgetID = KgBudgetID;
            this.KgMasterbudgetID = KgMasterbudgetID;
            this.FaLeistungID = FaLeistungID;
            this.BaPersonID = BaPersonID;
            this.isMasterbudget = (this.KgMasterbudgetID == 0);

            if (isMasterbudget)
            {
                colEffektiv.Visible = false;
                colAnzahlBelege.Visible = false;
                colStatus.Visible = false;
                colStatusMin.Visible = false;
                colMaster.Visible = false;
            }
            else
            {
                pnlButtonsNeu.Parent = pnlTitle;
                pnlButtonsNeu.Top = pnlButtonsStatus.Top;
                pnlButtonsNeu.Left = pnlButtonsStatus.Left + pnlButtonsStatus.Width + 10;

                colStatusMin.ColumnEdit = colStatus.ColumnEdit;
                colBelegStatus.ColumnEdit = colStatus.ColumnEdit;
                colDatumVon.Visible = false;
                colDatumBis.Visible = false;
                colBewStatus.Visible = false;

                //Gültig von-bis ausblenden und Platz wiederverwenden
                edtDatumVon.Visible = false;
                edtDatumBis.Visible = false;
                lblGueltigVon.Visible = false;
                lblGueltigBis.Visible = false;
                tabKgPosition.Height = tabKgPosition.Height - 30;
                grdKgPosition.Height = grdKgPosition.Height + 30;
            }

            lblDebitor.Location = lblKreditor.Location;
            edtDebitor.Location = edtKreditor.Location;

            lblZahlbarAn.Location = lblMitteilung.Location;

            pnlMasterbudget.Visible = isMasterbudget;
            pnlButtonsStatus.Visible = !isMasterbudget;

            qryKgPositionValuta.Fill("select top 0 * from KgPositionValuta");
            this.qryKgBudget.Fill(KgBudgetID);
            this.qryKgPosition.Fill(KgBudgetID, edtInklVergangeneLeistungen.Checked);
            SetBudgetEditMode();
            SetPositionEditMode();

            this.grdKgPosition.Focus();
        }

        public override bool OnAddData()
        {
            if (tabKgPosition.SelectedTab == tpgDokumente)
                qryKgDokumente.Insert();
            else if (tabKgPosition.SelectedTab == tpgVerlauf)
                return false; //don't add data
            else
                qryKgPosition.Insert();

            return true;
        }

        public override bool OnDeleteData()
        {
            if (tabKgPosition.SelectedTab == tpgDokumente)
            {
                if (!qryKgDokumente.Delete())
                    return false;

                qryKgPosition["Doc"] = (qryKgDokumente.Count > 0);
                qryKgPosition.RowModified = false;
                qryKgPosition.Row.AcceptChanges();
                return true;
            }
            else if (tabKgPosition.SelectedTab == tpgVerlauf)
            {
                return false; //don't delete data
            }
            else
            {
                bool result = qryKgPosition.Delete();
                qryKgPosition.Refresh();
                return result;
            }
        }

        public override bool OnSaveData()
        {
            if (qryKgBudget.RowModified)
            {
                if (!qryKgBudget.Post())
                {
                    return false;
                }
            }

            if (tabKgPosition.SelectedTab == tpgDokumente)
            {
                if (!qryKgPosition.Post())
                {
                    return false;
                }
                if (!qryKgDokumente.Post())
                {
                    return false;
                }

                qryKgPosition["Doc"] = (qryKgDokumente.Count > 0);
                qryKgPosition.RowModified = false;
                qryKgPosition.Row.AcceptChanges();
                return true;
            }
            else
            {
                return qryKgPosition.Post();
            }
        }

        void IBelegleser.ProcessBelegleser(Belegleser beleg)
        {
            //Falls Gruppe: keine Aktion, ohne Meldung
            if (DBUtil.IsEmpty(qryKgPosition["Gruppe"]) || (int)qryKgPosition["Gruppe"] == 1)
                return;

            //nicht editierbar, wenn
            //- qryKgPosition.CanUpdate == false
            //- in einem bewilligten/abgeschlossenen Masterbudget
            //- in einer Masterbudgetposition eines Monatsbudgets
            //- in einer nicht grauen Position eines Monatsbudgets

            bool editable = qryKgPosition.CanUpdate;
            int BewilligungCode = (int)qryKgBudget["KgBewilligungCode"];
            int PositionStatus = isMasterbudget ? 0 : (int)qryKgPosition["Status"];

            int PositionStatusMin = 0;
            if (!isMasterbudget && !DBUtil.IsEmpty(qryKgPosition["StatusMin"]))
                PositionStatusMin = (int)qryKgPosition["StatusMin"];

            if (isMasterbudget)
            {
                editable &= (BewilligungCode != 5) && (BewilligungCode != 9);
            }
            else
            {
                editable &= DBUtil.IsEmpty(qryKgPosition["MasterbudgetPositionID"]);
                editable &= (PositionStatus == 1);
            }

            if (!editable)
            {
                KissMsg.ShowInfo("Neue Daten vom Belegleser: Der Status der Position erlaubt keine Änderung der erfassten Daten");
                return;
            }

            DlgKgAuswahlZahlungsweg dlg = new DlgKgAuswahlZahlungsweg();
            ApplicationFacade.DoEvents();

            bool transfer = false;
            dlg.SucheBaZahlungsweg(beleg);
            switch (dlg.Count)
            {
                case 0:
                    KissMsg.ShowInfo("Keine zutreffenden Kreditor-Einträge im Institutionenstamm gefunden!");
                    qryKgPosition["BaZahlungswegID"] = DBNull.Value;
                    qryKgPosition["Kreditor"] = DBNull.Value;
                    qryKgPosition["ZusatzInfo"] = DBNull.Value;
                    if (beleg.Betrag > 0)
                        qryKgPosition["Betrag"] = beleg.Betrag;
                    qryKgPosition["ReferenzNummer"] = beleg.ReferenzNummer;
                    break;

                case 1:
                    transfer = true;
                    break;

                default:
                    transfer = dlg.ShowDialog(this) == DialogResult.OK;
                    break;
            }

            if (transfer)
            {
                qryKgPosition["BaZahlungswegID"] = dlg["BaZahlungswegID"];
                qryKgPosition["Kreditor"] = dlg["Kreditor"];
                qryKgPosition["ZusatzInfo"] = dlg["ZusatzInfo"];
                if (beleg.Betrag > 0)
                    qryKgPosition["Betrag"] = beleg.Betrag;
                qryKgPosition["ReferenzNummer"] = beleg.ReferenzNummer;
                qryKgPosition["EinzahlungsscheinCode"] = dlg["EinzahlungsscheinCode"];
            }

            qryKgPosition.RefreshDisplay();
            SetPositionEditMode();
        }

        #endregion

        #region Private Methods

        private void CheckNotNullFieldOnTabPage(IKissBindableEdit ctl, String text, SharpLibrary.WinControls.TabPageEx page)
        {
            try { ((KissTabControlEx)page.Parent).SelectTab(page); }
            catch { }
            DBUtil.CheckNotNullField(ctl, text);
        }

        /// <summary>
        /// Warnt bei zu hohen Barauszahlungen
        /// </summary>
        /// <returns>Gibt true zurück, falls die Barauszahlung zu hoch ist.</returns>
        private void CheckPositionBarzahlungBetrag()
        {
            // Einschränkung gilt nur für Barzahlungen
            if (qryKgPosition["KgAuszahlungsArtCode"] as int? != 103)
            {
                return;
            }
            int anzahlAuszahlungstermine = 0;
            int auszahlungsTerminCode = (int)qryKgPosition["KgAuszahlungsTerminCode"];
            if (auszahlungsTerminCode == 1 || auszahlungsTerminCode == 4) // Einmal pro Monat oder Valuta
            {
                anzahlAuszahlungstermine = 1;
            }
            else if (auszahlungsTerminCode == 2) // Zweimal pro Monat
            {
                anzahlAuszahlungstermine = 2;
            }
            else if (!this.isMasterbudget) // Falls es sich um ein Monatsbudget handelt, sind die Auszahltermine in KgPositionValuta gespeichert.
            {
                anzahlAuszahlungstermine = qryKgPositionValuta.Count;
            }
            else if (auszahlungsTerminCode == 3) // wöchentlich, vier bis fünf Termine im Monat: Im Masterbudget nur mit 4 Terminen sinnvoll
            {
                anzahlAuszahlungstermine = 4;
            }
            else if (auszahlungsTerminCode == 5) // alle 14 Tage (zwei bis drei Termine im Monat). Im Masterbudget nur mit zwei Terminen sinnvoll
            {
                anzahlAuszahlungstermine = 2;
            }
            else if (auszahlungsTerminCode == 6) // Wochentage: Anzahl Wochentage *4
            {
                anzahlAuszahlungstermine = (Regex.Matches((string)qryKgPosition["KgWochentagCodes"], ",").Count + 1) * 4;
            }
            // True, falls aufgerundeter Auszahlungsbetrag grösser als maximaler Auszahlungsbetrag
            if (System.Math.Ceiling((decimal)qryKgPosition["Betrag"] / anzahlAuszahlungstermine * 20) / 20 > MaxBarBetrag)
            {
                ShowDialogUebersteigtMaxBarBetrag();
                throw new KissCancelException("Zu hoher Barauszahlungsbetrag");
            }
            return;
        }

        private void DisplayCalendarBoldDates()
        {
            CalendarFilling = true;

            edtCalendar.TodayDate = DateTime.Today;

            this.edtCalendar.BoldedDates = null;
            if (isMasterbudget)
                return;

            DateTime firstDate = new DateTime((int)qryKgBudget["Jahr"], (int)qryKgBudget["Monat"], 1);
            edtCalendar.MaxSelectionCount = 2;
            edtCalendar.SelectionRange = new SelectionRange(firstDate, firstDate.AddDays(1));

            CalendarFilling = true;
            try
            {
                foreach (DataRow R in qryKgPositionValuta.DataTable.Rows)
                {
                    this.edtCalendar.AddBoldedDate((DateTime)R["Datum"]);
                }
            }
            catch { }
            CalendarFilling = false;
        }

        private void DisplayValutaTermine()
        {
            String ValutaTermine = "";
            foreach (DataRow R in qryKgPositionValuta.DataTable.Rows)
            {
                if (ValutaTermine != "")
                    ValutaTermine += @"  ";
                ValutaTermine += ((DateTime)R["Datum"]).ToString("d.M");
            }
            qryKgPosition["ValutaTermine"] = ValutaTermine;
            qryKgPosition.RefreshDisplay();
            tpgKalender.Focus();
        }

        /// <summary>
        /// Prüft, ob die aktuell selektierte Position in der Kreditoren-Maske erstellt worden
        /// ist und ob die Position nicht rot (Es gibt eine Buchung mit Status 7) ist.
        /// Ist die Position Rot, retourniert diese Funktion immer false. Rote Positionen dürfen
        /// das 4 Augenprinzip umgehen da das 4 Augenprinzip bereits forciert wurde.
        /// </summary>
        /// <returns>Wenn ja, dann true</returns>
        private bool InKreditorenMaskeErstelltUndNichtRot()
        {
            //Wenn neue Positionen erstellt werden, dann ist KgPositionID 0 und daher
            //müssen solche Positionen in dieser Maske erstellt worden sein.
            if (DBUtil.IsEmpty(qryKgPosition["KgPositionID"]))
            {
                return false;
            }

            string maskname = (string)
               DBUtil.ExecuteScalarSQL(@"SELECT TOP 1 ClassName
                                            FROM dbo.KgBewilligung
                                            WHERE
                                            KgPositionID = {0}
                                            AND KgBewilligungCode = 6
                                            ORDER BY DATUM ASC", (int)qryKgPosition["KgPositionID"]);

            //Handelt es sich um eine Klibu-Position (eine Position, die in der Maske
            //CtlKgEinzelzahlungen erstellt worden ist.
            if (!string.IsNullOrEmpty(maskname) && maskname == "CtlKgEinzelzahlungen")
            {
                bool positionRot = (!DBUtil.IsEmpty(qryKgPosition["Status"]) && 7 == (int)qryKgPosition["Status"]);  //Status 7 ist rot.

                return (!positionRot);
            }

            return false;
        }

        private void InsertPositionVerlaufEintrag(KgBewilligung kgBewilligungCode, int kgPositionId)
        {
            qryKgBewilligung.CanInsert = true;
            qryKgBewilligung.Fill(kgPositionId);

            qryKgBewilligung.Insert();
            qryKgBewilligung["KgPositionID"] = kgPositionId;
            qryKgBewilligung["UserID"] = Session.User.UserID;
            qryKgBewilligung["ClassName"] = typeof(CtlKgBudget).Name;
            qryKgBewilligung["Datum"] = DateTime.Now;
            qryKgBewilligung["KgBewilligungCode"] = (int)kgBewilligungCode;
            qryKgBewilligung.Post();
            qryKgBewilligung.CanInsert = false;
            qryKgBewilligung.Fill(kgPositionId);
        }

        private void LoadValutaTermine()
        {
            if (DBUtil.IsEmpty(qryKgPosition["KgAuszahlungsTerminCode"]))
            {
                qryKgPositionValuta.Fill("select top 0 * from KgPositionValuta");
                return;
            };

            int KgAuszahlungsTerminCode = (int)qryKgPosition["KgAuszahlungsTerminCode"];
            switch (KgAuszahlungsTerminCode)
            {
                case 1:  // 1x pro Monat
                case 2:  // 2x pro Monat
                case 3:  // wöchentlich
                case 5:  // 14-täglich
                    qryKgPositionValuta.Fill(@"
                        select T.Datum
                        from   fnKgAuszahlTermine((select Jahr  from KgBudget where KgBudgetID = {0}),
                                                  (select Monat from KgBudget where KgBudgetID = {0})) T
                        where  T.KgAuszahlungsTerminCode = {1}
             		        order by T.Datum",
                       KgBudgetID,
                       KgAuszahlungsTerminCode);
                    break;

                case 4:  // Valuta
                    break;

                case 6:  // Wochentage
                    qryKgPositionValuta.Fill(@"
                        select T.Datum
                        from   fnKgAuszahlTermine((select Jahr  from KgBudget where KgBudgetID = {0}),
                                                  (select Monat from KgBudget where KgBudgetID = {0})) T
                        where  T.KgAuszahlungsTerminCode = {1} and
                                   {2} like '%' + convert(varchar,T.KgWochentagCode) + '%'
             		        order by T.Datum",
                       KgBudgetID,
                       KgAuszahlungsTerminCode,
                       qryKgPosition["KgWochentagCodes"]);
                    break;

                case 99: //Individuell
                    break;
            }
        }

        private void MasterbudgetAnfrage()
        {
            DlgKgMasterbudgetAnfragen dlg = new DlgKgMasterbudgetAnfragen(KgBudgetID);

            dlg.ShowDialog(this);

            if (dlg.UserCancel)
                return;

            try
            {
                qryKgBudget.Refresh();
                qryKgBudget["KgBewilligungCode"] = 3; //Bewilligung angefragt
                qryKgBudget.Post();
                qryKgBudget.Refresh();
                SetBudgetEditMode();
                FormController.SendMessage("FrmFall", "Action", "RefreshTree");
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("Ein unerwarteter Fehler ist aufgetreten bei der Anfrage zur Bewilligung des Budgets.", ex);
            }
        }

        private void MasterbudgetBeenden()
        {
            DlgKgMasterbudgetBeenden dlg = new DlgKgMasterbudgetBeenden(KgBudgetID);

            dlg.Datum = qryKgBudget["BewilligtBis"];
            dlg.MinDatum = DBUtil.ExecuteScalarSQL(@"
                select	max(dbo.fnLastDayOf(dbo.fnDateSerial(Jahr,Monat,1)))
                from	KgBudget
                where	FaLeistungID = {0} and
                        KgMasterBudgetID is not null AND
                        KgBewilligungCode >= 5",
                FaLeistungID);

            if (dlg.MinDatum == null)
            {
                dlg.MinDatum = qryKgBudget["BewilligtVon"];
            }

            dlg.ShowDialog(this);

            if (dlg.UserCancel)
                return;

            try
            {
                Session.BeginTransaction();
                DBUtil.ExecSQLThrowingException(@"
                    DECLARE @KgBudgetFiltered TABLE
                    (
                        KgBudgetID int
                    )

                    INSERT INTO @KgBudgetFiltered
                    SELECT KgBudgetID FROM KgBudget BDG
                      WHERE  BDG.KgMasterBudgetID = {0} AND
                             BDG.KgBewilligungCode < 5 AND
                             dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1) > {1}

                    DELETE VAL
                    FROM   KgPositionValuta VAL
                           INNER JOIN KgPosition POS ON POS.KgPositionID = VAL.KgPositionID
                           INNER JOIN @KgBudgetFiltered BDF ON BDF.KgBudgetID = POS.KgBudgetID

                    DELETE POS
                    FROM KgPosition POS
                           INNER JOIN @KgBudgetFiltered BDF ON BDF.KgBudgetID = POS.KgBudgetID

                    DELETE BUD
                    FROM KgBudget BUD
                           INNER JOIN @KgBudgetFiltered BDF ON BDF.KgBudgetID = BUD.KgBudgetID
                    ",
                    this.KgBudgetID,
                    dlg.Datum);

                qryKgBudget["BewilligtBis"] = dlg.Datum;
                if ((DateTime)dlg.Datum <= DateTime.Today)
                    qryKgBudget["KgBewilligungCode"] = 9; //Masterbudget beendet
                qryKgBudget.Post();
                Session.Commit();

                qryKgBudget.Refresh();
                SetBudgetEditMode();

                FormController.SendMessage("FrmFall", "Action", "RefreshTree");
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowError("Ein unerwarteter Fehler ist aufgetreten beim Beenden des Budgets.", ex);
            }
        }

        private void MasterbudgetVisieren()
        {
            DlgKgMasterbudgetVisieren dlg = new DlgKgMasterbudgetVisieren(KgBudgetID);

            dlg.ShowDialog(this);

            if (dlg.UserCancel)
                return;

            try
            {
                Session.BeginTransaction();
                qryKgBudget.Refresh();
                if (dlg.UserYes)
                {
                    qryKgBudget["KgBewilligungCode"] = 5; //Bewilligung erteilt

                    // Setze auch alle Positionen dieses Budgets auf Bewilligt
                    DBUtil.ExecSQL(@"
                        UPDATE KgPosition
                        Set KgBewilligungCode = 5
                        WHERE KgBudgetID = {0}
                        ", qryKgBudget["KgBudgetID"]);
                }
                else
                    qryKgBudget["KgBewilligungCode"] = 2; //Bewilligung abgelehnt

                qryKgBudget.Post();
                Session.Commit();
                qryKgBudget.Refresh();
                SetBudgetEditMode();
                qryKgPosition.Fill(KgBudgetID, edtInklVergangeneLeistungen.Checked);
                FormController.SendMessage("FrmFall", "Action", "RefreshTree");
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowError("Ein unerwarteter Fehler ist aufgetreten beim Bewilligen des Budgets.", ex);
            }
        }

        private void NeuePosition(int KgPositionsKategorieCode)
        {
            if (!qryKgPosition.Post())
                return;
            if (!qryKgPosition.CanInsert)
                return;

            newKgPositionsKategorieCode = KgPositionsKategorieCode;
            qryKgPosition.Insert();
        }

        private void NeuesMonatsbudget()
        {
            if (!this.OnSaveData())
                return;

            try
            {
                int MasterBudgetID = (KgMasterbudgetID == 0) ? KgBudgetID : KgMasterbudgetID;
                SqlQuery qry = DBUtil.OpenSQL(@"EXECUTE spKgBudget_Create {0}, {1}", MasterBudgetID, Session.User.UserID);

                if (DBUtil.IsEmpty(qry["KgBudgetID"]))
                    throw new KissInfoException(qry["Error"].ToString());

                // K-Navigator refresh und positionieren auf neuem Budget
                int FallBaPersonID = (int)DBUtil.ExecuteScalarSQL(@"
                    Select FallBaPersonID = FAL.BaPersonID
                    from   FaFall FAL
                           inner join FaLeistung LEI on LEI.FaFallID = FAL.FaFallID
                           where LEI.FaLeistungID = {0}",
                    FaLeistungID);

                FormController.SendMessage("FrmFall", "Action", "RefreshTree");

                FormController.OpenForm("FrmFall", "Action", "JumpToNodeByFieldValue",
                    "BaPersonID", FallBaPersonID,
                    "ModulID", 5,
                    "FieldValue", string.Format("CtlKgLeistung{0}\\Masterbudget{1}\\Monatsbudget{2}",
                                 FaLeistungID, MasterBudgetID, qry["KgBudgetID"]));
            }
            catch (KissInfoException ex0)
            {
                ex0.ShowMessage();
            }
            catch (Exception ex1)
            {
                KissMsg.ShowInfo(ex1.Message);
            }
        }

        private void SaveCalendarBoldDates()
        {
            qryKgPositionValuta.DataTable.Rows.Clear();
            DateTime[] Dates = (DateTime[])edtCalendar.BoldedDates.Clone();
            Array.Sort(Dates);
            foreach (object D in Dates)
            {
                qryKgPositionValuta.Insert();
                qryKgPositionValuta["Datum"] = D;
                qryKgPositionValuta.RowModified = false;
                qryKgPositionValuta.Row.AcceptChanges();
            }
        }

        private void SaveValutaTermine()
        {
            int AuszahlungsTermin = (int)qryKgPosition["KgAuszahlungsTerminCode"];

            String sql = @"
                declare @KgPositionID int
                set @KgPositionID = {0}

                delete KgPositionValuta where KgPositionID = @KgPositionID ";

            if (AuszahlungsTermin == 4) //Valuta
            {
                sql += @" insert KgPositionValuta (KgPositionID,Datum) values (@KgPositionID," + DBUtil.SqlLiteral(qryKgPosition["ValutaDatum"]) + ") ";
            }
            else
            {
                foreach (DataRow R in qryKgPositionValuta.DataTable.Rows)
                {
                    sql += @" insert KgPositionValuta (KgPositionID,Datum) values (@KgPositionID," + DBUtil.SqlLiteral(R["Datum"]) + ") ";
                }
            }
            DBUtil.ExecSQL(sql, qryKgPosition["KgPositionID"]);
        }

        private void SetBudgetEditMode()
        {
            int BewilligungCode = (int)qryKgBudget["KgBewilligungCode"];
            bool editable = (BewilligungCode != 5) && (BewilligungCode != 9);
            bool darfVisieren = UserDarfVisieren();

            if (isMasterbudget)
            {
                // Positionen können auch im bewilligten, nicht abgelaufenen Budget zugefügt und geändert werden
                bool positionEditable = (BewilligungCode <= 3 ||
                                         (BewilligungCode == 5 && ((DateTime)qryKgBudget["BewilligtBis"]) >= DateTime.Today));

                edtBewilligtVon.EditMode = editable ? EditModeType.Normal : EditModeType.ReadOnly;
                edtBewilligtBis.EditMode = editable ? EditModeType.Normal : EditModeType.ReadOnly;

                qryKgPosition.CanInsert = positionEditable;
                qryKgPosition.CanUpdate = positionEditable || darfVisieren;
                qryKgPosition.CanDelete = positionEditable;

                btnBudgetNeu.Enabled = !editable;
                btnAusgabeK.Enabled = positionEditable;
                btnAusgabeD.Enabled = positionEditable;
                btnEinnahme.Enabled = positionEditable;
            }
            else
            {
                btnBudgetNeu.Enabled = true;
                btnAusgabeK.Enabled = true;
                btnAusgabeD.Enabled = true;
                btnEinnahme.Enabled = true;

                int CountUnveraenderbar = 0;
                foreach (DataRow R in qryKgPosition.DataTable.Rows)
                {
                    if (((int)R["Gruppe"] == 0) && ((int)R["Status"] != 1) && ((int)R["Status"] != 2))
                        CountUnveraenderbar++;
                }

                btnBudgetGrau.Visible = (BewilligungCode == 5) && (CountUnveraenderbar == 0) && qryKgPosition.DataTable.Select("StatusMin NOT IN (1, 2) OR STATUS NOT IN (1, 2)").Length == 0;
                btnBudgetGruen.Visible = (BewilligungCode == 1) || (BewilligungCode == 9);
                btnBudgetRot.Visible = (BewilligungCode == 5);
            }
        }

        private void SetPositionEditMode()
        {
            bool gruppe = ((int)qryKgPosition["Gruppe"] == 1);

            if (gruppe)
            {
                qryKgPosition.EnableBoundFields(false);
                tabZahlinfo.Visible = false;
                tpgDokumente.HideTab = true;
                btnPositionGrau.Visible = false;
                btnPositionGruen.Visible = false;
                btnPositionRot.Visible = false;
                btnBewilligungPosition.Visible = false;
                return;
            }

            bool darfVisieren = UserDarfVisieren();

            //nicht editierbar, wenn
            //- qryKgPosition.CanUpdate == false
            //- in einem bewilligten/abgeschlossenen Masterbudget
            //- in einer Masterbudgetposition eines Monatsbudgets
            //- in einer nicht grauen Position eines Monatsbudgets
            //- verbuchte Position mit Spezialrecht, aber Periode nicht mehr aktiv
            //- Wenn die Position in der Maske Kreditoren erfasst worden ist, dann braucht es ein Spezialrecht.

            bool editable = qryKgPosition.CanUpdate;
            bool TerminEditable = false;
            bool PosAbgelaufen = !DBUtil.IsEmpty(qryKgPosition["DatumBis"]) && ((DateTime)qryKgPosition["DatumBis"] <= DateTime.Today);
            int BewilligungCode = (int)qryKgBudget["KgBewilligungCode"];
            int PositionStatus = isMasterbudget ? 0 : (int)qryKgPosition["Status"];

            int PositionStatusMin = 0;
            if (!isMasterbudget && !DBUtil.IsEmpty(qryKgPosition["StatusMin"]))
                PositionStatusMin = (int)qryKgPosition["StatusMin"];

            int BewilligungPositionCode = 0;
            if (isMasterbudget && !DBUtil.IsEmpty(qryKgPosition["KgBewilligungCode"]))
                BewilligungPositionCode = (int)qryKgPosition["KgBewilligungCode"];

            //Positionen, welche in der Kreditorenmaske erstellt worden sind,
            //dürfen in dieser Maske nur mutiert werden, wenn das Spezialrecht
            //CtlKgBudget_EinzelzahlungenMutieren vorhanden ist.
            //Ausnahme: Rote Positionen dürfen grüngestellt werden.
            bool inKreditorenMaskeErstellt = InKreditorenMaskeErstelltUndNichtRot();
            if (inKreditorenMaskeErstellt)
            {
                editable &= DBUtil.UserHasRight(SPEZIALRECHT_KLIBUPOSITION_MUTIEREN);
            }

            if (isMasterbudget)
            {
                editable &= (BewilligungCode != 9) && !PosAbgelaufen;
                TerminEditable = editable;
            }
            else
            {
                editable &= DBUtil.IsEmpty(qryKgPosition["MasterbudgetPositionID"]);
                editable &= (PositionStatus == 1);
                TerminEditable = (PositionStatus == 1);
            }

            qryKgPosition.EnableBoundFields(editable);
            tabZahlinfo.Visible = true;
            tpgDokumente.HideTab = (qryKgPosition.Row.RowState == DataRowState.Added);

            if (isMasterbudget)
            {
                // DatumBis darf immer editiert werden
                edtDatumBis.EditMode = EditModeType.Normal;

                if (BewilligungPositionCode <= 3 || (BewilligungPositionCode == 5 && darfVisieren))
                {
                    // Entweder ist die Position noch nicht bewilligt, oder der aktuelle User darf bewilligen, dann lassen wir das Anpassen des VonDatums zu
                    edtDatumVon.EditMode = EditModeType.Normal;
                }
                else
                {
                    edtDatumVon.EditMode = EditModeType.ReadOnly;
                }
            }

            //Positionen, welche in der Maske CtlKgEinzelzahlungen erstellt worden sind, dürfen nur von User mit
            //Spezialrecht auf grün oder grau gestellt werden.
            //Aber das 4 Augenprinzip muss durchgesetzt werden.

            bool klibuPosDarfMutieren = true;

            if (inKreditorenMaskeErstellt)
            {
                //Spezialrecht prüfen
                if (!DBUtil.UserHasRight(SPEZIALRECHT_KLIBUPOSITION_MUTIEREN))
                {
                    klibuPosDarfMutieren = false;
                }
                else
                {
                    //Als KliBu Sachbearbeiter kann ich in der Maske "Kreditoren" eine graue Position (EZ oder ZL)
                    //nur dann grünstellen, wenn ich die Position nicht efasst habe und
                    //über ein Spezialrecht verfüge (dann kann ich den Button schon gar nicht drücken)
                    if (Session.User.UserID == (int)qryKgPosition["ErstelltUserID"])
                    {
                        klibuPosDarfMutieren = false;
                    }
                }
            }

            btnPositionGrau.Visible = (PositionStatus == 2 || PositionStatus == 5) && (PositionStatusMin == 2 || PositionStatusMin == 5 || PositionStatusMin == 0) && klibuPosDarfMutieren;  //grün, Zahlauftrag fehlerhaft
            btnPositionGruen.Visible = (BewilligungCode != 1) &&
                                       (PositionStatus == 1 || PositionStatus == 7 || PositionStatusMin == 7) && klibuPosDarfMutieren;  //grau, rot,
            btnPositionRot.Visible = (PositionStatus == 2 || PositionStatusMin == 2);  //freigegeben, grün;
            btnBewilligungPosition.Visible = (isMasterbudget && BewilligungCode == 5 && BewilligungPositionCode <= 3);  //graue/blaue Position in grünem Masterbudget

            // Positionsbuttons rechtsbündig platzieren
            int RightMargin = edtKategorie.Left + edtKategorie.Width;
            if (btnBewilligungPosition.Visible)
            {
                btnBewilligungPosition.Left = RightMargin - btnBewilligungPosition.Width;
                RightMargin -= (btnBewilligungPosition.Width + 6);
            }

            if (btnPositionRot.Visible)
            {
                btnPositionRot.Left = RightMargin - btnPositionRot.Width;
                RightMargin -= (btnPositionRot.Width + 6);
            }

            if (btnPositionGruen.Visible)
            {
                btnPositionGruen.Left = RightMargin - btnPositionGruen.Width;
                RightMargin -= (btnPositionGruen.Width + 6);
            }

            if (btnPositionGrau.Visible)
            {
                btnPositionGrau.Left = RightMargin - btnPositionGrau.Width;
            }

            int kategorie = (int)qryKgPosition["KgPositionsKategorieCode"];

            int ES = 0;
            if (!DBUtil.IsEmpty(qryKgPosition["EinzahlungsscheinCode"]))
                ES = (int)qryKgPosition["EinzahlungsscheinCode"];

            int AuszahlungsTermin = 0;
            if (!DBUtil.IsEmpty(qryKgPosition["KgAuszahlungsTerminCode"]))
                AuszahlungsTermin = (int)qryKgPosition["KgAuszahlungsTerminCode"];

            int AuszahlungsArt = 0;
            if (!DBUtil.IsEmpty(qryKgPosition["KgAuszahlungsArtCode"]))
                AuszahlungsArt = (int)qryKgPosition["KgAuszahlungsArtCode"];

            if (!DBUtil.IsEmpty(qryKgPosition["KgAuszahlungsArtCode"]))
            {
                if ((int)qryKgPosition["KgAuszahlungsArtCode"] == 103) //cash
                    edtKreditor.EditMode = EditModeType.ReadOnly;
                else
                    edtKreditor.EditMode = editable ? EditModeType.Normal : EditModeType.ReadOnly;
            }

            masterBetragValutaDebitorAnpassung = false;
            BuchungsdatumAnpassung = false;
            DebitorValutaBetragsAnpassung = false;

            int KgPeriodeStatusCode = 0;
            if (!DBUtil.IsEmpty(qryKgPosition["KgPeriodeStatusCode"]))
                KgPeriodeStatusCode = (int)qryKgPosition["KgPeriodeStatusCode"];

            switch (kategorie)
            {
                case 1:	//Auszahlung Klient
                    edtKgAuszahlungsArtCode.EditMode = TerminEditable ? EditModeType.Normal : EditModeType.ReadOnly;
                    edtKgAuszahlungsTerminCode.EditMode = TerminEditable ? EditModeType.Normal : EditModeType.ReadOnly;
                    edtWochentagCodes.EditMode = TerminEditable ? EditModeType.Normal : EditModeType.ReadOnly;

                    edtValutaDatum.EditMode = (AuszahlungsTermin == 4) && TerminEditable && klibuPosDarfMutieren ? EditModeType.Normal : EditModeType.ReadOnly;
                    edtValutaDatum.Visible = (AuszahlungsTermin == 4);
                    edtValutaTermine.Visible = (AuszahlungsTermin != 4);
                    lblValutaDatum.Text = "Valuta";
                    edtDebitor.Visible = false;
                    lblDebitor.Visible = false;
                    edtReferenzNummer.EditMode = (ES == 1) && editable ? EditModeType.Normal : EditModeType.ReadOnly;
                    edtReferenzNummer.Visible = true;
                    lblReferenzNummer.Visible = true;

                    edtKreditor.Visible = true;
                    lblKreditor.Visible = true;
                    tpgZahlinfo.Title = lblKreditor.Text;

                    if (AuszahlungsArt == 101)  //elektronisch
                    {
                        edtKreditor.EditMode = editable ? EditModeType.Normal : EditModeType.ReadOnly;
                        tpgMitteilung.HideTab = (ES != 2) && (ES != 3) && (ES != 4) && (ES != 5); //roter ES
                        lblMitteilung.Visible = true;
                        lblZahlbarAn.Visible = false;
                        tpgMitteilung.Title = lblMitteilung.Text;
                        edtMitteilungZeile1.EditMode = TerminEditable && klibuPosDarfMutieren ? EditModeType.Normal : EditModeType.ReadOnly;
                        edtMitteilungZeile2.EditMode = TerminEditable && klibuPosDarfMutieren ? EditModeType.Normal : EditModeType.ReadOnly;
                        edtMitteilungZeile3.EditMode = TerminEditable && klibuPosDarfMutieren ? EditModeType.Normal : EditModeType.ReadOnly;
                    }
                    else  //bar
                    {
                        edtKreditor.EditMode = EditModeType.ReadOnly;
                        tpgMitteilung.HideTab = false;
                        lblMitteilung.Visible = false;
                        lblZahlbarAn.Visible = true;
                        tpgMitteilung.Title = lblZahlbarAn.Text;
                    }

                    tpgKalender.HideTab = (AuszahlungsTermin == 4) || (isMasterbudget && AuszahlungsTermin != 6);

                    if (!tpgKalender.HideTab)
                    {
                        if (isMasterbudget)
                        {
                            edtWochentagCodes.Visible = true;
                            edtCalendar.Visible = false;
                        }
                        else
                        {
                            DateTime firstDate = new DateTime((int)qryKgBudget["Jahr"], (int)qryKgBudget["Monat"], 1);
                            switch (AuszahlungsTermin)
                            {
                                case 6:  //Wochentage
                                    edtWochentagCodes.Visible = true;
                                    edtCalendar.Visible = !isMasterbudget;
                                    edtCalendar.Enabled = false;
                                    edtCalendar.MinDate = firstDate;
                                    edtCalendar.MaxDate = firstDate.AddMonths(1).AddDays(-1);
                                    edtCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
                                    edtCalendar.Left = tpgKalender.Width - edtCalendar.Width - 5;
                                    break;

                                case 3:  //wöchentlich
                                case 5:  //14-täglich
                                case 99: //individuell
                                    edtWochentagCodes.Visible = false;
                                    edtCalendar.Visible = !isMasterbudget;
                                    edtCalendar.Enabled = (AuszahlungsTermin == 99);
                                    edtCalendar.MinDate = firstDate;
                                    edtCalendar.MaxDate = firstDate.AddMonths(1).AddDays(-1);
                                    edtCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
                                    edtCalendar.Left = (tpgKalender.Width - edtCalendar.Width) / 2;
                                    break;

                                default:
                                    edtWochentagCodes.Visible = false;
                                    edtCalendar.Visible = !isMasterbudget;
                                    edtCalendar.Enabled = false;
                                    edtCalendar.MinDate = firstDate.AddMonths(-1);
                                    edtCalendar.MaxDate = firstDate.AddMonths(1).AddDays(-1);
                                    edtCalendar.CalendarDimensions = new System.Drawing.Size(2, 1);
                                    edtCalendar.Left = tpgKalender.Width - edtCalendar.Width;
                                    break;
                            }
                        }
                    }

                    int AnzahlBelege = DBUtil.IsEmpty(qryKgPosition["AnzahlBelege"]) ? 0 : ((int)qryKgPosition["AnzahlBelege"]);
                    if ((PositionStatus == 1) || (AnzahlBelege == 0))
                    {
                        tpgBelege.HideTab = true;
                    }
                    else
                    {
                        tpgBelege.HideTab = false;
                        grdBelege.Dock = (AuszahlungsArt == 103) ? System.Windows.Forms.DockStyle.Top : System.Windows.Forms.DockStyle.Fill;
                        btnBelegeAlle.Visible = (AuszahlungsArt == 103);
                        btnBelegeKeine.Visible = (AuszahlungsArt == 103);
                        btnBarbelegDruck.Visible = (AuszahlungsArt == 103);
                        lblBelegNr.Visible = (AuszahlungsArt == 103);
                        colBelegSel.Visible = (AuszahlungsArt == 103);
                        colGedrucktAb.Visible = (AuszahlungsArt == 103);
                        colBarbezug.Visible = (AuszahlungsArt == 103);
                        colBelegNr.Visible = (AuszahlungsArt != 103);
                    }

                    //this.edtCalendar.Enabled = qryKgPosition.CanUpdate;
                    break;

                case 2:	//Auszahlung Dritte
                    edtKgAuszahlungsArtCode.EditMode = EditModeType.ReadOnly;
                    edtKgAuszahlungsTerminCode.EditMode = EditModeType.ReadOnly;

                    edtValutaDatum.EditMode = TerminEditable && klibuPosDarfMutieren ? EditModeType.Normal : EditModeType.ReadOnly;
                    edtValutaDatum.Visible = true;
                    edtValutaTermine.Visible = false;
                    lblValutaDatum.Text = "Valuta";

                    edtDebitor.Visible = false;
                    lblDebitor.Visible = false;
                    edtKreditor.Visible = true;
                    lblKreditor.Visible = true;
                    edtKreditor.EditMode = editable ? EditModeType.Normal : EditModeType.ReadOnly;
                    tpgZahlinfo.Title = lblKreditor.Text;
                    edtReferenzNummer.EditMode = (ES == 1) && editable ? EditModeType.Normal : EditModeType.ReadOnly;
                    edtReferenzNummer.Visible = true;
                    lblReferenzNummer.Visible = true;

                    tpgMitteilung.HideTab = (ES != 2) && (ES != 3) && (ES != 4) && (ES != 5); //roter ES
                    edtMitteilungZeile1.EditMode = TerminEditable && klibuPosDarfMutieren ? EditModeType.Normal : EditModeType.ReadOnly;
                    edtMitteilungZeile2.EditMode = TerminEditable && klibuPosDarfMutieren ? EditModeType.Normal : EditModeType.ReadOnly;
                    edtMitteilungZeile3.EditMode = TerminEditable && klibuPosDarfMutieren ? EditModeType.Normal : EditModeType.ReadOnly;

                    lblMitteilung.Visible = true;
                    lblZahlbarAn.Visible = false;
                    tpgMitteilung.Title = lblMitteilung.Text;

                    tpgKalender.HideTab = (AuszahlungsTermin == 4);
                    tpgBelege.HideTab = true;
                    break;

                case 3:	//Einnahme
                    edtKgAuszahlungsArtCode.EditMode = EditModeType.ReadOnly;
                    edtKgAuszahlungsTerminCode.EditMode = EditModeType.ReadOnly;

                    edtValutaDatum.EditMode = TerminEditable ? EditModeType.Normal : EditModeType.ReadOnly;
                    edtValutaDatum.Visible = true;
                    edtValutaTermine.Visible = false;
                    lblValutaDatum.Text = "Fällig am";
                    edtDebitor.Visible = true;
                    lblDebitor.Visible = true;
                    edtKreditor.Visible = false;
                    lblKreditor.Visible = false;
                    tpgZahlinfo.Title = lblDebitor.Text;
                    tpgMitteilung.HideTab = true;
                    tpgKalender.HideTab = true;
                    tpgBelege.HideTab = true;
                    edtReferenzNummer.Visible = false;
                    lblReferenzNummer.Visible = false;

                    if (DBUtil.UserHasRight("CtlKgBudget_MasterbudgetBetragAnpassen") && isMasterbudget && BewilligungCode == 5)
                    {
                        qryKgPosition.CanUpdate = true;
                        edtBetrag.EditMode = EditModeType.Normal;
                        masterBetragValutaDebitorAnpassung = true;
                    }

                    if (DBUtil.UserHasRight("CtlKgBudget_DebitorValutaBetragAnpassen") &&
                        !isMasterbudget &&
                        BewilligungCode == 5 &&
                        PositionStatus == 2 &&
                        KgPeriodeStatusCode <= 1)
                    {
                        qryKgPosition.CanUpdate = true;
                        edtBetrag.EditMode = EditModeType.Normal;
                        edtValutaDatum.EditMode = EditModeType.Normal;
                        edtDebitor.EditMode = EditModeType.Normal;
                        DebitorValutaBetragsAnpassung = true;
                    }

                    break;
            }

            btnRuecklaeuferDuplizieren.Visible = (PositionStatus == 9 /*Rückläufer*/ || PositionStatus == 8) && DBUtil.UserHasRight("CtlKgBudget_RuecklaeuferDuplizieren");

            bool nachtraeglichAendernErlaubt = (PositionStatus == 3 || /*ZahlauftragErstellt*/
                                                                       //PositionStatus == 4 || /*ausgedruckt*/
                                     PositionStatus == 5 || /*ZahlauftragFehlerhaft*/
                                     PositionStatus == 6 || /*ausgeglichen*/
                                                            //PositionStatus == 7 || /*gesperrt*/
                                     PositionStatus == 9 || /*Rückläufer*/
                                     PositionStatus == 10 || /*teilweise ausgeglichen*/
                                     PositionStatus == 11 || /*Barbezug*/
                                     PositionStatus == 16)   /*Rückläufer korrigiert*/
              && DBUtil.UserHasRight("CtlKgBudget_BuchungenAendern")
              && (KgPeriodeStatusCode <= 1);

            edtEntsperren.Visible = nachtraeglichAendernErlaubt;

            if (nachtraeglichAendernErlaubt && edtEntsperren.Checked)
            {
                qryKgPosition.CanUpdate = true;
                edtBuchungDatum.EditMode = EditModeType.Normal;
                edtBuchungstext.EditMode = EditModeType.Normal;
                edtKonto.EditMode = EditModeType.Normal;
                BuchungsdatumAnpassung = true;
                edtDebitor.EditMode = EditModeType.Normal;
            }
            else
            {
            }
        }

        private void ShowDialogUebersteigtMaxBarBetrag()
        {
            KissMsg.ShowInfo(String.Format("Die Erstellung eines Barbeleges ist nicht möglich. Der Maximalbetrag pro Barbeleg beträgt CHF {0}.", MaxBarBetrag.ToString("0,000.00")));
        }

        private object TruncateString(object s, int MaxLength)
        {
            if (DBUtil.IsEmpty(s))
                return s;
            if (!(s is String))
                return s;
            if (s.ToString().Length > MaxLength)
                return s.ToString().Substring(0, MaxLength);
            return s;
        }

        private bool UserDarfVisieren()
        {
            int VerantwortlichUserID = (int)DBUtil.ExecuteScalarSQL("SELECT UserID FROM FaLeistung WHERE FaLeistungID = {0}", FaLeistungID);
            return (VerantwortlichUserID == Session.User.UserID) || DBUtil.UserHasRight("DlgKgMasterbudgetVisieren", "I");
        }

        #endregion

        #endregion
    }
}