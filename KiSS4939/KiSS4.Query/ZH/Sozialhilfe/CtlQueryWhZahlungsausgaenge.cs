using System;
using System.Data;
using System.Windows.Forms;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

using DevExpress.XtraGrid.Views.Grid;

namespace KiSS4.Query.ZH
{
    public partial class CtlQueryWhZahlungsausgaenge : KissQueryControl
    {
        #region Fields

        #region Private Static Fields

        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #endregion

        #region Constructors

        public CtlQueryWhZahlungsausgaenge()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void CtlQueryWhZahlungsausgaenge_Load(object sender, EventArgs e)
        {
            // Diese queries sollen nicht bei RunSearch gefüllt werden, daher werden sie erst hier und nicht im Designer gesetzt.
            grdVerfuegbar.DataSource = qryVerfuegbar;
            grdZugeteilt.DataSource = qryZugeteilt;
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            qryVerfuegbar.Fill(0);
            qryZugeteilt.Fill(1);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (qryVerfuegbar.Count < 1 || qryVerfuegbar.Row.RowState == DataRowState.Deleted)
            {
                return;
            }

            qryZugeteilt.DataTable.Rows.Add(qryVerfuegbar.Row.ItemArray);
            qryVerfuegbar.DeleteQuestion = null;
            qryVerfuegbar.Delete();
        }

        private void btnMonatsbudget_Click(object sender, EventArgs e)
        {
            // Todo: jump path anpassen
            try
            {
                string jumpToPath = string.Format(
                    "ClassName=FrmFall;" +
                    "BaPersonID={0};" +
                    "ModulID=3;",
                    qryQuery["FallBaPersonID"]);

                if (!DBUtil.IsEmpty(qryQuery["BgFinanzplanID"]))
                {
                    jumpToPath += string.Format("TreeNodeID=CtlWhFinanzplan{0}", qryQuery["BgFinanzplanID"]);

                    if (!DBUtil.IsEmpty(qryQuery["BgBudgetID"]))
                    {
                        jumpToPath += string.Format("\\BBG{0};", qryQuery["BgBudgetID"]);
                        if (!DBUtil.IsEmpty(qryQuery["BgPositionID"]))
                        {
                            jumpToPath += string.Format("ActiveSQLQuery.Find=BgPositionID = {0};", qryQuery["BgPositionID"]);
                        }
                    }
                    else
                    {
                        jumpToPath += ';';
                    }
                }

                System.Collections.Specialized.HybridDictionary dic = FormController.ConvertToDictionary(jumpToPath);
                bool result = FormController.OpenForm((string)dic["ClassName"], "Action", "JumpToPath", dic);
                // resultat ist eigentlich immer true
                if (!result)
                {
                    KissMsg.ShowInfo("Das Budget befindet sich in einer beendeten Reg. WH oder in einem abgeschlossenen W. Deaktivieren Sie die Optionen 'Beendete Reg. WH ausblenden' und 'Abgeschlossene W ausblenden' um das Budget anzuzeigen.");
                    jumpToPath = string.Format(
                        "ClassName=FrmFall;" +
                        "BaPersonID={0};" +
                        "ModulID=3;" +
                        "TreeNodeID=CtlWhKontoauszug;",
                        qryQuery["FallBaPersonID"]);
                    dic = FormController.ConvertToDictionary(jumpToPath);
                    FormController.OpenForm((string)dic["ClassName"], "Action", "JumpToPath", dic);
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowInfo(ex.Message);
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            qryVerfuegbar.Fill(1);
            qryZugeteilt.Fill(0);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (qryZugeteilt.Count < 1 || qryZugeteilt.Row.RowState == DataRowState.Deleted)
            {
                return;
            }

            qryVerfuegbar.DataTable.Rows.Add(qryZugeteilt.Row.ItemArray);
            qryZugeteilt.DeleteQuestion = null;
            qryZugeteilt.Delete();
        }

        private void edtAktiveW_CheckedChanged(object sender, EventArgs e)
        {
            if (edtAktiveW.Checked)
            {
                edtInaktiveW.Checked = false;
            }
        }

        private void edtFilter2_EditValueChanged(object sender, EventArgs e)
        {
            string value = "";

            if (!DBUtil.IsEmpty(edtFilter2.EditValue))
            {
                value = edtFilter2.EditValue.ToString();
            }

            qryZugeteilt.DataTable.DefaultView.RowFilter = "Name like '%" + value + "%'";
        }

        private void edtFilter_EditValueChanged(object sender, EventArgs e)
        {
            string value = "";

            if (!DBUtil.IsEmpty(edtFilter.EditValue))
            {
                value = edtFilter.EditValue.ToString();
            }

            qryVerfuegbar.DataTable.DefaultView.RowFilter = "Name like '%" + value + "%'";
        }

        private void edtInaktiveW_CheckedChanged(object sender, EventArgs e)
        {
            if (edtInaktiveW.Checked)
            {
                edtAktiveW.Checked = false;
            }
        }

        private void grdVerfuegbar_DoubleClick(object sender, EventArgs e)
        {
            if (btnAdd.Enabled)
            {
                btnAdd.PerformClick();
            }
        }

        private void grdZugeteilt_DoubleClick(object sender, EventArgs e)
        {
            if (btnRemove.Enabled)
            {
                btnRemove.PerformClick();
            }
        }

        private void grvMain_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
        {
            GridView detailView = grvMain.GetDetailView(e.RowHandle, 0) as GridView;

            if (detailView != null)
            {
                detailView.BestFitColumns();
            }
        }

        private void qryQuery_AfterFill(object sender, EventArgs e)
        {
            if (DBUtil.IsEmpty(edtPersonenNr.EditValue) && DBUtil.IsEmpty(edtWhSucheKlientX.EditValue))
            {
                // Keine Person ausgewählt => Gruppierung
                DataSet ds = qryQuery.DataSet;
                ds.EnforceConstraints = false; // Workaround: das SqlQuery löscht die Constraints nur auf der zweiten Table, nicht jedoch auf der ersten
                // Beim ersten Durchgang ohne die Option 'verdichtet' (mit vorgängigen Suchvorgängen mit verdichtet) gibt es dadurch eine exception.
                try
                {
                    ds.Relations.Add("Level1",
                        new[] { ds.Tables[0].Columns["KbBuchungBruttoID"], ds.Tables[0].Columns["BgPositionID"] },
                        new[] { ds.Tables[1].Columns["KbBuchungBruttoID"], ds.Tables[1].Columns["BgPositionID"] });
                }
                catch (Exception ex)
                {
                    // was tun? ignorieren?

                    // Eintrag ins Log.
                    _log.ErrorFormat("Fehler in: [{0}]. Exception: [{1}]", GetType().FullName, ex.Message);

                    // Eintrag ins Log (Ansicht unter Anwendung/Newod Schnittstelle/Protokolle)
                    XLog.Create(GetType().FullName, LogLevel.ERROR, ex.Message);
                }
            }
        }

        private void qryQuery_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            edtFaFallID.Enabled = !DBUtil.IsEmpty(qryQuery["FallBaPersonID"]);
        }

        private void tabControlSearch_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            if (page == tpgSuchen)
            {
                lblSuchNachW.Text = "";
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void OnSearch()
        {
            // Workaround um F3 weiter zu reichen, da das FrameWork das OrgUnitTeamUser UserControl nicht kennt
            try
            {
                var container = ActiveControl as ContainerControl;

                if (container != null && container.ActiveControl == ctlOrgUnitTeamUser)
                {
                    edtWhSucheKlientX.Focus();
                }
            }
            catch (Exception ex)
            {
                _log.Debug(ex);
            }

            base.OnSearch();
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();
            ctlOrgUnitTeamUser.NewSearch();

            edtAktiveW.Checked = true;
            edtInaktiveW.Checked = false;

            btnRemoveAll.PerformClick();
        }

        protected override void RunSearch()
        {
            base.RunSearch();
            if (DBUtil.IsEmpty(ctlOrgUnitTeamUser.SucheGruppe.EditValue) &&
                DBUtil.IsEmpty(ctlOrgUnitTeamUser.SucheTeam.EditValue) &&
                DBUtil.IsEmpty(ctlOrgUnitTeamUser.SucheUserID.EditValue) &&
                DBUtil.IsEmpty(edtDatumBis.EditValue) &&
                DBUtil.IsEmpty(edtDatumVon.EditValue) &&
                DBUtil.IsEmpty(edtWhSucheKlientX.EditValue) &&
                DBUtil.IsEmpty(edtPersonenNr.EditValue) &&
                DBUtil.IsEmpty(edtFaFallID.EditValue))
            {
                KissMsg.ShowInfo("Mindestens eines der folgenden Felder muss ausgefüllt werden:\r\n\r\n" +
                    "- Organisationsgruppe\r\n" +
                    "- Team\r\n" +
                    "- Mitarbeiter/in\r\n" +
                    "- Klient\r\n" +
                    "- Pers.-Nr.\r\n" +
                    "- Fall-Nr.\r\n" +
                    "- ZA von/bis\r\n");
                throw new Exception();
            }

            var datumVon = edtDatumVon.EditValue as DateTime?;
            var datumBis = edtDatumBis.EditValue as DateTime?;
            if (datumVon.HasValue && datumBis.HasValue && datumVon > datumBis)
            {
                KissMsg.ShowInfo("Datum von muss kleiner sein als Datum bis.");
                throw new Exception();
            }

            string laListVerfuegbar = "", laListZugeteilt = "";

            if (qryVerfuegbar.Count < qryZugeteilt.Count)
            {
                laListVerfuegbar = ComposeLAList(qryVerfuegbar);
            }
            else
            {
                laListZugeteilt = ComposeLAList(qryZugeteilt);
            }

            grdQuery1.DataSource = null;
            try
            {
                qryQuery.Fill(
                    qryQuery.SelectStatement,
                    laListVerfuegbar,
                    laListZugeteilt);

                grdQuery1.DataSource = qryQuery;
                grvMain.OptionsView.ShowFooter = !DBUtil.IsEmpty(edtWhSucheKlientX.EditValue) || !DBUtil.IsEmpty(edtPersonenNr.EditValue) || !DBUtil.IsEmpty(edtFaFallID.EditValue);
                grvMain.BestFitColumns();
            }
            catch (Exception ex1)
            {
                KissMsg.ShowInfo("Fehler: " + ex1.Message);
            }

            if (edtAktiveW.CheckState == CheckState.Checked)
            {
                lblSuchNachW.Text = "nur aktive W";
            }
            else if (edtInaktiveW.CheckState == CheckState.Checked)
            {
                lblSuchNachW.Text = "nur inaktive W";
            }
            else
            {
                lblSuchNachW.Text = "";
            }
        }

        #endregion

        #region Private Methods

        private string ComposeLAList(SqlQuery qry)
        {
            string laList = "";

            foreach (DataRow row in qry.DataTable.Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    if (laList != "")
                    {
                        laList += ",";
                    }

                    laList += row["KontoNr"].ToString();
                }
            }

            return laList;
        }

        #endregion

        #endregion
    }
}