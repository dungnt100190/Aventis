using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query
{
    public partial class CtlQueryWhZahlungseingaenge : KissQueryControl
    {
        #region Fields

        #region Private Static Fields

        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Constant/Read-Only Fields

        private const string XRIGHT_SALDIEREN = "CtlQueryWhZahlungseingaenge_Saldieren";

        #endregion

        #endregion

        #region Constructors

        public CtlQueryWhZahlungseingaenge()
        {
            InitializeComponent();
            SetupDataMembers();
            SetUpRights();
            SetUpGrid();

            if (edtFoderungsTyp.EditValue == null)
            {
                // Defaultmässig ist "alle" ausgewählt
                edtFoderungsTyp.SelectedIndex = 0;
            }

            if (edtSaldierungSuche.EditValue == null)
            {
                // Defaultmässig ist "alle" ausgewählt
                edtSaldierungSuche.SelectedIndex = 0;
            }

            var qry = DBUtil.OpenSQL(@"
                SELECT  Code = OrgUnitID,
                        Text = ItemName
                FROM dbo.XOrgUnit WITH (READUNCOMMITTED)
                ORDER BY ItemName;");
            var newRow = qry.DataTable.NewRow();
            newRow["Text"] = "";
            qry.DataTable.Rows.InsertAt(newRow, 0);
            newRow.AcceptChanges();
            edtOrgUnitID.Properties.Columns.Clear();
            edtOrgUnitID.Properties.Columns.AddRange(new[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default) });
            edtOrgUnitID.Properties.ShowFooter = false;
            edtOrgUnitID.Properties.ShowHeader = false;
            edtOrgUnitID.Properties.DisplayMember = "Text";
            edtOrgUnitID.Properties.ValueMember = "Code";
            edtOrgUnitID.Properties.DropDownRows = Math.Min(qry.Count, 7);
            edtOrgUnitID.Properties.DataSource = qry;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Sagt aus, ob der User die Felder Saldiert und BemerkungSaldierung
        /// ändern darf (Spezialrecht).
        /// </summary>
        private bool HasRight
        {
            get
            {
                bool hasRight = DBUtil.UserHasRight(XRIGHT_SALDIEREN);
                return hasRight;
            }
        }

        #endregion

        #region EventHandlers

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

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            qryVerfuegbar.Fill(0);
            qryZugeteilt.Fill(1);
        }

        private void btnMonatsbudget_Click(object sender, EventArgs e)
        {
            try
            {
                var jumpToPath = string.Format("ClassName=FrmFall;BaPersonID={0};ModulID=3;", qryQuery["BaPersonID_Fall"]);

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

                var dic = FormController.ConvertToDictionary(jumpToPath);
                var result = FormController.OpenForm((string)dic["ClassName"], "Action", "JumpToPath", dic);

                // resultat ist eigentlich immer true
                if (!result)
                {
                    KissMsg.ShowInfo("Das Budget befindet sich in einer beendeten Reg. WH oder in einem abgeschlossenen W. Deaktivieren Sie die Optionen 'Beendete Reg. WH ausblenden' und 'Abgeschlossene W ausblenden' um das Budget anzuzeigen.");
                    jumpToPath = string.Format("ClassName=FrmFall;BaPersonID={0};ModulID=3;TreeNodeID=CtlWhKontoauszug;", qryQuery["BaPersonID_Fall"]);

                    dic = FormController.ConvertToDictionary(jumpToPath);
                    FormController.OpenForm((string)dic["ClassName"], "Action", "JumpToPath", dic);
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowInfo(ex.Message);
            }
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

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            qryVerfuegbar.Fill(1);
            qryZugeteilt.Fill(0);
        }

        private void CtlQueryWhZahlungseingaenge_Load(object sender, EventArgs e)
        {
            // Diese queries sollen nicht bei RunSearch gefüllt werden, daher werden sie erst hier und nicht im Designer gesetzt.
            grdVerfuegbar.DataSource = qryVerfuegbar;
            grdZugeteilt.DataSource = qryZugeteilt;
        }

        private void edtAktiveW_CheckedChanged(object sender, EventArgs e)
        {
            if (edtAktiveS.Checked)
            {
                edtInaktiveS.Checked = false;
            }
        }

        private void edtBaPerson_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            using (var dlg = new DlgAuswahl())
            {
                var result = dlg.PersonSuchen(edtBaPerson.Text, e.ButtonClicked);

                e.Cancel = !result;

                if (result)
                {
                    edtBaPerson.LookupID = dlg["BaPersonID"];
                    edtBaPerson.Text = Utils.ConvertToString(dlg["Name"]);
                    edtBaPerson.UserModified = false;
                }
            }
        }

        private void edtDatumBis_Validated(object sender, EventArgs e)
        {
            if (!DBUtil.IsEmpty(edtZEDatumVon.EditValue) && !DBUtil.IsEmpty(edtZEDatumVon.EditValue) && edtZEDatumVon.DateTime > edtZEDatumBis.DateTime)
            {
                edtZEDatumVon.EditValue = edtZEDatumBis.EditValue;
            }
        }

        private void edtDatumVon_Validated(object sender, EventArgs e)
        {
            if (!DBUtil.IsEmpty(edtZEDatumVon.EditValue) && !DBUtil.IsEmpty(edtZEDatumVon.EditValue) && edtZEDatumVon.DateTime > edtZEDatumBis.DateTime)
            {
                edtZEDatumBis.EditValue = edtZEDatumVon.EditValue;
            }
        }

        private void edtFalltraeger_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            using (var dlg = new DlgAuswahl())
            {
                var result = dlg.ShFalltraegerSuchen(edtFalltraeger.Text, false, e.ButtonClicked);

                e.Cancel = !result;

                if (result)
                {
                    edtFalltraeger.LookupID = dlg["BaPersonID"];
                    edtFalltraeger.Text = Utils.ConvertToString(dlg["Name"]);
                }
            }
        }

        private void edtFilter_EditValueChanged(object sender, EventArgs e)
        {
            var value = "";

            if (!DBUtil.IsEmpty(edtFilterVerfuegbar.EditValue))
            {
                value = edtFilterVerfuegbar.EditValue.ToString();
            }

            qryVerfuegbar.DataTable.DefaultView.RowFilter = "Name like '%" + value + "%'";
        }

        private void edtFilter2_EditValueChanged(object sender, EventArgs e)
        {
            var value = "";

            if (!DBUtil.IsEmpty(edtFilterZugeteilt.EditValue))
            {
                value = edtFilterZugeteilt.EditValue.ToString();
            }

            qryZugeteilt.DataTable.DefaultView.RowFilter = "Name like '%" + value + "%'";
        }

        private void edtInaktiveW_CheckedChanged(object sender, EventArgs e)
        {
            if (edtInaktiveS.Checked)
            {
                edtAktiveS.Checked = false;
            }
        }

        private void edtUserID_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            using (var dlg = new DlgAuswahl())
            {
                var result = dlg.MitarbeiterSuchen(edtUserID.Text, e.ButtonClicked);

                e.Cancel = !result;

                if (result)
                {
                    edtUserID.LookupID = dlg["UserID"];
                    edtUserID.Text = Convert.ToString(dlg["Name"]);
                }
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

        private void grvMain_MasterRowExpanded(object sender, DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs e)
        {
            var detailView = grvMain.GetDetailView(e.RowHandle, 0) as DevExpress.XtraGrid.Views.Grid.GridView;

            if (detailView == null)
            {
                return;
            }

            try
            {
                detailView.Columns["BelegDatum"].BestFit();
                detailView.Columns["VerwPeriodeVon"].BestFit();
                detailView.Columns["VerwPeriodeBis"].BestFit();
                detailView.Columns["Diff"].BestFit();
                detailView.Columns["Betrag"].BestFit();
                detailView.Columns["DisplayText"].Width = colName.Width;
            }
            catch (Exception ex)
            {
                KissMsg.ShowInfo(ex.Message);
            }
        }

        private void qryQuery_AfterFill(object sender, EventArgs e)
        {
            if (!DBUtil.IsEmpty(edtFalltraeger.EditValue) || !DBUtil.IsEmpty(edtBaPerson.EditValue))
            {
                return;
            }

            // Keine Person ausgewählt => Gruppierung
            var ds = qryQuery.DataSet;
            ds.EnforceConstraints = false; // Workaround: das SqlQuery löscht die Constraints nur auf der zweiten Table, nicht jedoch auf der ersten

            // Beim ersten Durchgang ohne die Option 'verdichtet' (mit vorgängigen Suchvorgängen mit verdichtet) gibt es dadurch eine exception.
            try
            {
                ds.Relations.Add("Level1",
                    new[] { ds.Tables[0].Columns["KbBuchungID"], ds.Tables[0].Columns["BgPositionID"] },
                    new[] { ds.Tables[1].Columns["KbBuchungID"], ds.Tables[1].Columns["BgPositionID"] });
            }
            catch (Exception ex)
            {
                // was tun? ignorieren?

                // Eintrag ins Log.
                _logger.ErrorFormat("Fehler in: [{0}]. Exception: [{1}]", GetType().FullName, ex.Message);

                // Eintrag ins Log (Ansicht unter Anwendung/Newod Schnittstelle/Protokolle)
                XLog.Create(GetType().FullName, LogLevel.ERROR, ex.Message);
            }
        }

        private void qryQuery_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            edtFalltraeger.Enabled = !DBUtil.IsEmpty(qryQuery["BaPersonID_Fall"]);
        }

        private void qryQuery_PositionChanged(object sender, EventArgs e)
        {
            EnableDetailPanel();
        }

        private void tabControlSearch_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            if (page == tpgSuchen)
            {
                lblSuchNachS.Text = "";
            }

            if (tabControlSearch.SelectedTab == tpgListe)
            {
                EnableDetailPanel();
            }
            else
            {
                panelDetail.Enabled = false;
            }
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();

            edtAktiveS.Checked = true;
            edtInaktiveS.Checked = false;

            if (edtFoderungsTyp.EditValue == null)
            {
                // Defaultmässig ist "alle" angewählt.
                edtFoderungsTyp.SelectedIndex = 0;
            }
            if (edtSaldierungSuche.EditValue == null)
            {
                //Defaultmässsig ist "alle" ausgewählt.
                edtSaldierungSuche.SelectedIndex = 0;
            }

            btnRemoveAll.PerformClick();
        }

        protected override void RunSearch()
        {
            base.RunSearch();
            if (DBUtil.IsEmpty(edtOrgUnitID.EditValue) &&
                DBUtil.IsEmpty(edtUserID.EditValue) &&
                DBUtil.IsEmpty(edtZEDatumBis.EditValue) &&
                DBUtil.IsEmpty(edtZEDatumVon.EditValue) &&
                DBUtil.IsEmpty(edtBudgetBis.EditValue) &&
                DBUtil.IsEmpty(edtBudgetVon.EditValue) &&
                DBUtil.IsEmpty(edtForderungDatumBis.EditValue) &&
                DBUtil.IsEmpty(edtForderungDatumVon.EditValue) &&
                DBUtil.IsEmpty(edtBaPerson.EditValue) &&
                DBUtil.IsEmpty(edtFalltraeger.EditValue))
            {
                KissMsg.ShowInfo("Mindestens eines der folgenden Felder muss ausgefüllt werden:\r\n\r\n" +
                    "- Sektion\r\n" +
                    "- SAR\r\n" +
                    "- Belegdatum Von\r\n" +
                    "- Belegdatum Bis\r\n" +
                    "- Valutadatum Von\r\n" +
                    "- Valutadatum Bis\r\n" +
                    "- Budget Von\r\n" +
                    "- Budget Bis\r\n" +
                    "- Person\r\n" +
                    "- Fallträger\r\n");
                throw new Exception();
            }

            var laListVerfuegbar = "";
            var laListZugeteilt = "";

            if (qryVerfuegbar.Count < qryZugeteilt.Count)
            {
                laListVerfuegbar = ComposeLaList(qryVerfuegbar);
            }
            else
            {
                laListZugeteilt = ComposeLaList(qryZugeteilt);
            }

            grdQuery1.DataSource = null;

            try
            {
                int kbPeriodeIdMin = DBUtil.GetConfigInt(@"System\KliBu\KliBuIntegriertSeitPeriode", 0);

                //Forderungstyp (alle, ausgeglichen, nicht ausgeglichen u.s.w.)
                int forderungsTyp = edtFoderungsTyp.SelectedIndex;
                int saldierungsTyp = edtSaldierungSuche.SelectedIndex;

                qryQuery.Fill(
                    qryQuery.SelectStatement,
                    laListVerfuegbar,
                    laListZugeteilt,
                    kbPeriodeIdMin,
                    forderungsTyp,
                    saldierungsTyp);

                grdQuery1.DataSource = qryQuery;
                grvMain.OptionsView.ShowFooter = !DBUtil.IsEmpty(edtBaPerson.EditValue) || !DBUtil.IsEmpty(edtFalltraeger.EditValue);
                grvMain.BestFitColumns();
            }
            catch (Exception ex1)
            {
                KissMsg.ShowInfo("Fehler: " + ex1.Message);
            }

            if (edtAktiveS.CheckState == CheckState.Checked)
            {
                lblSuchNachS.Text = edtAktiveS.Text;
            }
            else if (edtInaktiveS.CheckState == CheckState.Checked)
            {
                lblSuchNachS.Text = edtInaktiveS.Text;
            }
            else
            {
                lblSuchNachS.Text = "";
            }
        }

        #endregion

        #region Private Static Methods

        private static string ComposeLaList(SqlQuery qry)
        {
            var laList = "";

            foreach (var row in qry.DataTable.Rows.Cast<DataRow>().Where(row => row.RowState != DataRowState.Deleted))
            {
                if (laList != "")
                {
                    laList += ",";
                }

                laList += row["KontoNr"].ToString();
            }

            return laList;
        }

        #endregion

        #region Private Methods

        private void EnableDetailPanel()
        {
            // #8045: Saldierung soll immer möglich sein (vorher: "Diff" != 0)
            panelDetail.Enabled = !qryQuery.IsEmpty;
        }

        /// <summary>
        /// Setzt die DataMemmbers für die Schreibenden controls
        /// </summary>
        private void SetupDataMembers()
        {
            edtBemerkungSaldierung.DataMember = DBO.BgPosition.BemerkungSaldierung;
            edtSaldiert.DataMember = DBO.BgPosition.Saldiert;
        }

        /// <summary>
        /// Setup vom Grid.
        /// Das Setup wird von Hand gemacht, da das Control grdQuery1 im Designer ReadOnly ist.
        /// Hat jemand eine Lösung?
        /// </summary>
        private void SetUpGrid()
        {
            var gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();

            grdQuery1.EmbeddedNavigator.Name = "";
            gridLevelNode1.LevelTemplate = grvDetail;
            gridLevelNode1.RelationName = "Level1";
            grdQuery1.LevelTree.Nodes.AddRange(new[] { gridLevelNode1 });
            grdQuery1.MainView = grvMain;
            grdQuery1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { grvDetail, grvMain });
            grvDetail.GridControl = grdQuery1;
        }

        /// <summary>
        /// Enabled oder disabled Felder, je nach zugeteiltem Spezialrecht.
        /// </summary>
        private void SetUpRights()
        {
            var editMode = EditModeType.ReadOnly;

            if (HasRight)
            {
                editMode = EditModeType.Normal;
            }

            edtSaldiert.EditMode = editMode;
            edtBemerkungSaldierung.EditMode = editMode;
        }

        #endregion

        #endregion
    }
}