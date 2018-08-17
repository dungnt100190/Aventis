using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Kiss.Infrastructure;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Sozialhilfe.ZH
{
    public partial class CtlWhAbfrageBewilligung : KissQueryControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string TYPEFULLNAME = "KiSS4.Sozialhilfe.ZH.CtlWhAbfrageBewilligung";

        #endregion

        #endregion

        #region Constructors

        public CtlWhAbfrageBewilligung()
        {
            InitializeComponent();

            grdQuery1.Width = tpgListe.Width - 9;
            grdQuery1.Height = tpgListe.Height - 220;

            grvQuery1.OptionsBehavior.Editable = true;
        }

        #endregion

        #region EventHandlers

        private void btnAlle_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            foreach (DataRow row in qryQuery.DataTable.Rows)
            {
                if (!DBUtil.IsEmpty(row["Sel"]))
                {
                    row["Sel"] = true;
                    row.AcceptChanges();
                }
            }

            qryQuery.RowModified = false;
            Cursor = Cursors.Default;
            qryQuery_PositionChanged(null, new EventArgs());
        }

        private void btnJumpTo_Click(object sender, EventArgs e)
        {
            if (qryQuery.Row == null)
            {
                return;
            }

            var dic = FormController.ConvertToDictionary(GetJumpToPath(qryQuery.Row));
            FormController.OpenForm((string)dic["ClassName"], "Action", "JumpToPath", dic);
        }

        private void btnKeine_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            foreach (DataRow row in qryQuery.DataTable.Rows)
            {
                if (!DBUtil.IsEmpty(row["Sel"]))
                {
                    row["Sel"] = false;
                    row.AcceptChanges();
                }
            }

            qryQuery.RowModified = false;
            Cursor = Cursors.Default;
            qryQuery_PositionChanged(null, new EventArgs());
        }

        private void btnVisieren_Click(object sender, EventArgs e)
        {
            int totalCountFp = 0;
            int totalCountZl = 0;

            foreach (DataRow row in qryQuery.DataTable.Rows)
            {
                if (!DBUtil.IsEmpty(row["Sel"]) && (bool)row["Sel"])
                {
                    if ((bool)row["Masterbudget"])
                    {
                        totalCountFp++;
                    }
                    else
                    {
                        totalCountZl++;
                    }
                }
            }

            if (totalCountFp == 0 && totalCountZl == 0)
            {
                return;
            }

            if ((totalCountFp == 1 && totalCountZl == 0) || ((totalCountFp == 0 && totalCountZl == 1)))
            {
                //falls nur eine einzelne Position selektiert ist
                foreach (DataRow row in qryQuery.DataTable.Rows)
                {
                    if (!DBUtil.IsEmpty(row["Sel"]) && (bool)row["Sel"])
                    {
                        // Einzelvisum
                        DlgWhPositionVisieren dlg = new DlgWhPositionVisieren((int)row["BgPositionID"], Name);
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
                                // Position ist bewilligt
                                PositionBewilligen(row, false);
                            }
                            else
                            {
                                // Position wurde abgelehnt
                                if ((bool)row["Masterbudget"])
                                {
                                    // Finanzplan-Anpassung ablehnen
                                    FpAnpassungAblehnen(row, dlg.TaskDescription, dlg.ReceiverID);
                                }
                                else
                                {
                                    // Zusätzliche Leistung ablehnen
                                    ZusaetzlicheLeistungAblehnen(row, dlg.TaskDescription, dlg.ReceiverID);
                                }
                            }

                            Session.Commit();
                            qryQuery.Refresh();
                        }
                        catch (Exception ex)
                        {
                            Session.Rollback();
                            KissMsg.ShowInfo(ex.Message);
                        }

                        return;
                    }
                }
            }

            if (!KissMsg.ShowQuestion(string.Format("Sollen\r\n\r\n{0}  Finanzplananpassung{1} und\r\n{2}  zusätzliche Leistung{3}\r\n\r\nbewilligt werden?",
                                        totalCountFp,
                                        totalCountFp > 1 ? "en" : "",
                                        totalCountZl,
                                        totalCountZl > 1 ? "en" : "")))
            {
                return;
            }

            List<int> fehlerhafteEintraege = new List<int>();

            try
            {
                Cursor = Cursors.WaitCursor;

                if ((totalCountFp + totalCountZl) > 1)
                {
                    lblFortschritt.Visible = true;
                }

                int count = 0;

                foreach (DataRow row in qryQuery.DataTable.Rows)
                {
                    if (!DBUtil.IsEmpty(row["Sel"]) && (bool)row["Sel"])
                    {
                        count++;

                        lblFortschritt.Text = string.Format("{0}/{1}", count, totalCountFp + totalCountZl);
                        ApplicationFacade.DoEvents();

                        Session.BeginTransaction();
                        try
                        {
                            PositionBewilligen(row, true);

                            if (!DBUtil.IsEmpty(row["BgPositionID"]))
                            {
                                fehlerhafteEintraege.Add((int)row["BgPositionID"]);
                            }

                            Session.Commit();
                        }
                        catch (Exception ex)
                        {
                            Session.Rollback();
                            KissMsg.ShowInfo(ex.Message);

                            if (!DBUtil.IsEmpty(row["BgPositionID"]))
                            {
                                fehlerhafteEintraege.Add((int)row["BgPositionID"]);
                            }
                        }

                        ApplicationFacade.DoEvents();
                    }
                }

                lblFortschritt.Visible = false;
            }
            catch (KissCancelException ex)
            {
                ex.ShowMessage();
            }
            catch (Exception ex)
            {
                KissMsg.ShowInfo(string.Format("Fehler beim Visieren\r\n\r\n{0}", ex.Message));
            }
            finally
            {
                Cursor = Cursors.Default;
                qryQuery.Refresh();

                foreach (int bgPositionId in fehlerhafteEintraege)
                {
                    foreach (DataRow row in qryQuery.DataTable.Rows)
                    {
                        if (!DBUtil.IsEmpty(row["BgPositionID"]) && (int)row["BgPositionID"] == bgPositionId && !DBUtil.IsEmpty(row["Sel"]))
                        {
                            row["Sel"] = true;
                            row.AcceptChanges();
                            qryQuery.RowModified = false;
                        }
                    }
                }
            }
        }

        private void CtlWhAbfrageBewilligung_Load(object sender, EventArgs e)
        {
            grvQuery1.CustomRowCellEdit += grvQuery1_CustomRowCellEdit;
            grvQuery1.CellValueChanging += grvQuery1_CellValueChanging;

            // Setze DataSource erst hier, da das SQL-Statement des Queries Parameter enthält.
            // Wenn die DataSource schon im Designer gesetzt wird, führt das zu Problemen beim Instanzieren dieser Maske,
            // da SQLQuery versucht das SQL-Statement ohne den Parameter auszuführen
            grdDoc.DataSource = qryBgDokumente;
        }

        private void edtWhSucheEmpfX_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            WhUtil.SearchEmpfaenger(edtWhSucheEmpfX, e);
        }

        private void grvQuery1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column != colSelektion)
            {
                return;
            }

            grvQuery1.SetRowCellValue(e.RowHandle, colSelektion, e.Value);
            qryQuery.Row.AcceptChanges();
            qryQuery.RowModified = false;

            qryQuery_PositionChanged(null, new EventArgs());
        }

        private void grvQuery1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column == colSelektion)
            {
                if (DBUtil.IsEmpty(grvQuery1.GetRowCellValue(e.RowHandle, e.Column)))
                {
                    e.RepositoryItem = repositoryItemTextEdit1;
                }
                else
                {
                    e.RepositoryItem = repositoryItemCheckEdit1;
                }
            }
        }

        private void qryQuery_PositionChanged(object sender, EventArgs e)
        {
            btnJumpTo.Enabled = !DBUtil.IsEmpty(qryQuery["BgFinanzplanID"]);

            int count = 0;

            foreach (DataRow row in qryQuery.DataTable.Rows)
            {
                if (!DBUtil.IsEmpty(row["Sel"]) && (bool)row["Sel"])
                {
                    count++;
                }
            }

            btnVisieren.Enabled = (count > 0);

            qryBgDokumente.SelectStatement = @"
                SELECT
                  BgDokumentID,
                  BgFinanzplanID,
                  BgBudgetID,
                  BgPositionID,
                  BgDokumentTypCode,
                  DocumentID,
                  BgDocumentTS,
                  Stichwort,
                  DateCreation,
                  DateLastSave
                FROM dbo.fnBgGetDokumente({0})
                ORDER BY Stichwort";

            qryBgDokumente.Fill(qryQuery["BgPositionID"]);
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void OnSearch()
        {
            if (tabControlSearch.SelectedTab == tpgSuchen)
            {
                foreach (Control ctl in UtilsGui.AllControls(tpgSuchen))
                {
                    if (ctl is KissButtonEdit)
                    {
                        KissButtonEdit edt = (KissButtonEdit)ctl;
                        edt.CheckPendingSearchValue();
                    }
                }

                if (DBUtil.IsEmpty(edtWhSucheEmpfX.EditValue))
                {
                    KissMsg.ShowInfo("Das Feld Empfänger darf nicht leer bleiben");
                    return;
                }
            }

            qryBgDokumente.SelectStatement = "";

            base.OnSearch();
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();
            //edtWhSucheEmpfX.EditValue = Session.User.UserID;

            //Falls Sachbearbeiter, Empfänger= default "leer", sonst ID der eingeloggten Users
            SetEmpfaengerDefault();

            edtUserID.EditValue = Session.User.UserID;
        }

        #endregion

        #region Private Methods

        private void FpAnpassungAblehnen(DataRow row, string taskDescription, int receiverId)
        {
            try
            {
                // Pendenz erzeugen: Rückmeldung, pendent
                // + BgBewilligungsStatus der Position auf "abgelehnt"
                DBUtil.ExecSQLThrowingException(@"
                    INSERT INTO XTask (TaskTypeCode, TaskStatusCode, CreateDate, StartDate,
                                       [Subject], TaskDescription, SenderID, TaskSenderCode, ReceiverID, TaskReceiverCode,
                                       FaLeistungID, BaPersonID, JumpToPath)
                    VALUES (5, 1, GetDate(), GetDate(), {0}, {1}, {2}, 1, {3}, 1, {4}, {5}, {6})

                    UPDATE BgPosition SET BgBewilligungStatusCode = 2 WHERE BgPositionID = {7}",
                    string.Format("Bewilligung {0} abgelehnt.", row["Gruppe"]),
                    taskDescription,
                    Session.User.UserID,
                    receiverId,
                    row["FaLeistungID"],
                    row["BaPersonID"],
                    GetJumpToPath(row),
                    row["BgPositionID"]);
            }
            catch (Exception ex)
            {
                throw new KissErrorException("Fehler beim Ablehnen der FP-Anpassung:\r\n\r\n" + ex.Message, ex);
            }
        }

        private string GetJumpToPath(DataRow row)
        {
            string jumpToPath = string.Format(
                "ClassName=FrmFall;" +
                "BaPersonID={0};" +
                "ModulID=3;",
                row["FAL_BaPersonID"]);

            if (DBUtil.IsEmpty(row["BgPositionID"])) // Finanzplan
            {
                jumpToPath += string.Format(
                    "TreeNodeID=CtlWhFinanzplan{0};",
                    row["BgFinanzplanID"]);
            }
            else if ((bool)row["MasterBudget"]) // Finanzplan-Position
            {
                jumpToPath += string.Format(
                    "TreeNodeID=CtlWhFinanzplan{0}/CtlBgUebersicht/{1};" +
                    "ActiveSQLQuery.Find=BgPositionID = {2};",
                    row["BgFinanzplanID"], row["BgGruppeValue1"],
                    row["BgPositionID"]);
            }
            else
            {
                jumpToPath += string.Format(
                    "TreeNodeID=CtlWhFinanzplan{0}\\BBG{1};" +
                    "ActiveSQLQuery.Find=BgPositionID = {2};",
                    row["BgFinanzplanID2"], row["BgBudgetID2"],
                    row["BgPositionID"]);
            }

            return jumpToPath;
        }

        private void PositionBewilligen(DataRow row, bool verlaufsEintrag)
        {
            try
            {
                if (verlaufsEintrag)
                {
                    // Bewilligungs-Verlauf
                    DBUtil.ExecSQLThrowingException(@"
                        INSERT BgBewilligung (BgFinanzplanID,BgBudgetID,BgPositionID,UserID,UserID_An,Datum,BgBewilligungCode)
                        VALUES ({0},{1},{2},{3},{4}, getdate(),2)",
                        row["BgFinanzplanID2"],
                        row["BgBudgetID2"],
                        row["BgPositionID"],
                        Session.User.UserID,
                        row["UserID"]);
                }

                if ((bool)row["Masterbudget"])
                {
                    // FPAnpassung
                    DBUtil.ExecSQLThrowingException(@"
                        EXECUTE spWhFinanzplan_Bewilligen {0}, {1}, {2}",
                        row["BgFinanzplanID2"],
                        row["DatumVon"],
                        row["BgPositionID"]);

                    WhUtil.InsertOrUpdateVerrechnungsposition((int)row["BgPositionID"]);
                }
                else
                {
                    // zusätzliche Leistung
                    DBUtil.ExecSQLThrowingException(@"
                        UPDATE BgPosition
                        SET    BgBewilligungStatusCode = 5
                        WHERE  BgPositionID = {0} or
                               BgPositionID_Parent = {0}",
                        row["BgPositionID"]);

                    WhUtil.CheckIfInsertVerrechnungspositionIsAllowed((int)row["BgKategorieCode"], (int)row["BgBewilligungStatusCode"], row["BgPositionsartID"] as int?);
                    WhUtil.InsertOrUpdateVerrechnungsposition((int)row["BgPositionID"]);

                    XLog.Create(TYPEFULLNAME, 0, LogLevel.DEBUG,
                        "Position bewilligt", string.Format("NeuerPositionsBgBewilligungStatusCode 5, BgBudgetBewilligungStatusCode {0}, IsMasterbudget {1}",
                        row["BgBewilligungStatusCode"],
                        row["MasterBudget"]),
                        "BgPosition",
                        Utils.ConvertToInt(row["BgPositionID"]));

                    if ((bool)row["KbBuchungErzeugen"])
                    { // bewilligte Position auf grün stellen in einem grünen Monatsbudget
                        DBUtil.ExecSQLThrowingException(@"
                            EXECUTE spWhBudget_CreateKbBuchung {0}, {1}, 0, null, {2}",
                            row["BgBudgetID2"],
                            Session.User.UserID,
                            row["BgPositionID"]);
                        XLog.Create(TYPEFULLNAME, 1, LogLevel.DEBUG,
                            "Buchung erstellt",
                            string.Format("KbBuchungID: {0}",
                            DBUtil.ExecuteScalarSQL("SELECT TOP 1 KbBuchungID FROM KbBuchungKostenart WHERE BgPositionID = {0}",
                            row["BgPositionID"])),
                            "BgPositionID",
                            ShUtil.GetCode(Utils.ConvertToInt(row["BgPositionID"])));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new KissErrorException("Fehler beim Bewilligen der Anfrage:\r\n\r\n" + ex.Message, ex);
            }
        }

        private void SetEmpfaengerDefault()
        {
            if (!WhUtil.IsSachbearbeiter())
            {
                edtWhSucheEmpfX.EditValue = Session.User.LastFirstName;
                edtWhSucheEmpfX.LookupID = Session.User.UserID;
            }
            else
            {
                edtWhSucheEmpfX.LookupID = null;
            }
        }

        private void ZusaetzlicheLeistungAblehnen(DataRow row, string taskDescription, int receiverId)
        {
            try
            {
                // Pendenz erzeugen: Rückmeldung, pendent
                // + BgBewilligungsStatus der Position auf "bewilligt"
                DBUtil.ExecSQLThrowingException(@"
                    INSERT INTO XTask (TaskTypeCode, TaskStatusCode, CreateDate, StartDate,
                                       [Subject], TaskDescription, SenderID, TaskSenderCode, ReceiverID, TaskReceiverCode,
                                       FaLeistungID, BaPersonID, JumpToPath)
                    VALUES (5, 1, GetDate(), GetDate(), {0}, {1}, {2}, 1, {3}, 1, {4}, {5}, {6})

                    UPDATE BgPosition SET BgBewilligungStatusCode = 2
                    WHERE  BgPositionID = {7} or
                           BgPositionID_Parent = {7}",
                    string.Format("Bewilligung {0} abgelehnt.", row["Gruppe"]),
                    taskDescription,
                    Session.User.UserID,
                    receiverId,
                    row["FaLeistungID"],
                    row["BaPersonID"],
                    GetJumpToPath(row),
                    row["BgPositionID"]);
            }
            catch (Exception ex)
            {
                throw new KissErrorException("Fehler beim Ablehnen der zusätzlichen Leistung:\r\n\r\n" + ex.Message, ex);
            }
        }

        #endregion

        #endregion
    }
}