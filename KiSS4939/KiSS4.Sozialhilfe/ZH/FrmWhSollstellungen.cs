using System;
using System.Data;
using System.Windows.Forms;

using Kiss.Infrastructure;
using Kiss.Interfaces.UI;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Dokument;
using KiSS4.Gui;
using KiSS4.Messages;

namespace KiSS4.Sozialhilfe.ZH
{
    public partial class FrmWhSollstellungen : KissSearchForm
    {
        #region Fields

        #region Private Fields

        private bool _filling;
        private object _origVerwPeriodeBis;
        private object _origVerwPeriodeVon;
        private int _totalBelegCount;

        #endregion

        #endregion

        #region Constructors

        public FrmWhSollstellungen()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void FrmWhSollstellungen_Load(object sender, EventArgs e)
        {
            btnDocument.Image = XDokument.BmpImportDoc;

            //Buchungsstati laden
            repositoryItemImageComboBox2.SmallImages = KissImageList.SmallImageList;
            SqlQuery qryStati =
                DBUtil.OpenSQL("select * from XLOVCode where LOVName = 'KbBuchungsStatus' and Code in (1,2,3,5,6,7,8,10) order by SortKey");
            foreach (DataRow row in qryStati.DataTable.Rows)
            {
                repositoryItemImageComboBox2.Items.Add(
                    new DevExpress.XtraEditors.Controls.ImageComboBoxItem(
                        row["Text"].ToString(),
                        (int)row["Code"],
                        KissImageList.GetImageIndex(Convert.ToInt32(row["Value1"]))));
            }
            colStatus.ColumnEdit = repositoryItemImageComboBox2;

            // Dasselbe für edtSucheStatus
            edtSucheStatus.Properties.SmallImages = KissImageList.SmallImageList;
            edtSucheStatus.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", null, -1));

            foreach (DevExpress.XtraEditors.Controls.ImageComboBoxItem item in repositoryItemImageComboBox2.Items)
                edtSucheStatus.Properties.Items.Add(item);

            //edtBgSplittingCode.LoadQuery(DBUtil.OpenSQL("select * from XLOVCode where LOVName = 'BgSplittingart'"),"Code","Text");

            colDocTyp.ColumnEdit = grdDoc.GetLOVLookUpEdit("BgDokumentTyp");

            edtBetrag.Properties.DisplayFormat.FormatString = "N2";
            edtBetrag.Properties.EditFormat.FormatString = "N2";

            grvSollstellung.CustomRowCellEdit += grvSollstellung_CustomRowCellEdit;
            grvSollstellung.CellValueChanging += grvSollstellung_CellValueChanging;

            qryBgDokumente.PostCompleted += qryBgDokumente_PostCompleted;

            btnPositionGrau.Location = btnPositionGruen.Location;

            tabBgPosition.SelectedTabIndex = 0;
            tabControlSearch.SelectedTabIndex = 1;

            qryBgPosition.EnableBoundFields(false);
            PresetSearchFields();
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            qryZugeteilt.Fill(1);
            qryVerfuegbar.Fill(0);
            edtLAList.EditValue = ComposeLaList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (qryVerfuegbar.Count < 1)
                return;

            qryZugeteilt.DataTable.Rows.Add(qryVerfuegbar.Row.ItemArray);
            qryVerfuegbar.DeleteQuestion = null;
            qryVerfuegbar.Delete();
            edtLAList.EditValue = ComposeLaList();
        }

        private void btnAlle_Click(object sender, EventArgs e)
        {
            if (!qryBgPosition.Post())
                return;

            Cursor = Cursors.WaitCursor;
            foreach (DataRow row in qryBgPosition.DataTable.Rows)
            {
                if (!DBUtil.IsEmpty(row["Sel"]))
                {
                    row["Sel"] = true;
                    row.AcceptChanges();
                }
            }
            CalculateTotal();
            qryBgPosition.RowModified = false;
            Cursor = Cursors.Default;
        }

        private void btnDocument_Click(object sender, EventArgs e)
        {
            DocumentImport();
        }

        private void btnKeine_Click(object sender, EventArgs e)
        {
            if (!qryBgPosition.Post())
                return;

            Cursor = Cursors.WaitCursor;
            foreach (DataRow row in qryBgPosition.DataTable.Rows)
            {
                if (!DBUtil.IsEmpty(row["Sel"]))
                {
                    row["Sel"] = false;
                    row.AcceptChanges();
                }
            }
            CalculateTotal();
            qryBgPosition.RowModified = false;
            Cursor = Cursors.Default;
        }

        private void btnMonatsbudget_Click(object sender, EventArgs e)
        {
            if (qryMonatsbudget.Count == 0)
                return;

            if (DBUtil.IsEmpty(qryBgPosition["BgPositionID"]))
            {
                //Sprung ins Monatsbudget
                string pfad = String.Format(@"CtlWhFinanzplan{0}\BBG{1}", qryMonatsbudget["BgFinanzplanID"], qryMonatsbudget["BgBudgetID"]);

                FormController.OpenForm(
                    "FrmFall",
                    "Action",
                    "JumpToNodeByFieldValue",
                    "BaPersonID",
                    qryMonatsbudget["FallBaPersonID"],
                    "ModulID",
                    3,
                    "FieldValue",
                    pfad);
            }
            else
            {
                //Sprung direkt zur Position im Monatsbudget
                string pfad2 = string.Format(
                    "ClassName=FrmFall;" +
                    "BaPersonID={0};" +
                    "ModulID=3;" +
                    "TreeNodeID=CtlWhFinanzplan{1}\\BBG{2};" +
                    "ActiveSQLQuery.Find=BgPositionID = {3};",
                    qryBgPosition["FallBaPersonID"],
                    qryBgPosition["BgFinanzplanID"],
                    qryBgPosition["BgBudgetID"],
                    qryBgPosition["BgPositionID"]);

                System.Collections.Specialized.HybridDictionary dic = FormController.ConvertToDictionary(pfad2);
                FormController.OpenForm((string)dic["ClassName"], "Action", "JumpToPath", dic);
            }
        }

        private void btnPositionGrau_Click(object sender, EventArgs e)
        {
            if (!qryBgPosition.Post())
            {
                return;
            }

            Session.BeginTransaction();
            try
            {
                int positionStatus = (int)qryBgPosition["Status"];
                if (positionStatus != 2)
                    return;

                // grüne Einzelzahlung auf grau stellen
                DBUtil.ExecSQLThrowingException(@"exec spWhBudget_DeleteKbBuchung {0}", qryBgPosition["BgPositionID"]);

                Session.Commit();
                qryBgPosition.Refresh();
                SetEditMode();
            }
            catch (KissCancelException ex)
            {
                Session.Rollback();
                ex.ShowMessage();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowError(ex.Message);
            }
        }

        private void btnPositionGruen_Click(object sender, EventArgs e)
        {
            if (!qryBgPosition.Post())
                return;

            int positionBewilligung = ShUtil.GetCode(qryBgPosition["BgBewilligungStatusCode"]);
            int budgetBewilligung = ShUtil.GetCode(qryMonatsbudget["BgBewilligungStatusCode"]);

            //Grünstellen nur möglich, wenn Position grau/neu und Budget nicht grau
            if (positionBewilligung > 1 || budgetBewilligung == 1)
            {
                btnPositionGruen.Visible = false;
                return;
            }

            try
            {
                DBUtil.ExecSQLThrowingException(
                    @"
                    EXECUTE spWhBudget_CreateKbBuchung {0}, {1}, 0, null, {2}",
                    qryMonatsbudget["BgBudgetID"],
                    Session.User.UserID,
                    qryBgPosition["BgPositionID"]);

                qryBgPosition["Status"] = 2; // freigegeben
                qryBgPosition["Sel"] = false;

                qryBgPosition["KbBuchungBruttoID"] =
                    DBUtil.ExecuteScalarSQLThrowingException(
                        @"
                    SELECT max(KbBuchungBruttoID)
                    FROM   KbBuchungBruttoPerson
                    WHERE  BgPositionID = {0}",
                        qryBgPosition["BgPositionID"]);

                qryBgPosition.Row.AcceptChanges();
                qryBgPosition.RowModified = false;
                SetEditMode();
                qryBgPosition.RefreshDisplay();

                // Monatsbudgets einschränken, damit die Position nicht verschoben werden kann
                qryBgPosition_PositionChanged(null, null);
                //alte Version: qryMonatsbudget.Fill(qryBgPosition["KlientID"], qryBgPosition["BgBudgetID"]);
            }
            catch (KissCancelException ex)
            {
                ex.ShowMessage();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(ex.Message);
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            qryVerfuegbar.Fill(1);
            qryZugeteilt.Fill(0);
            edtLAList.EditValue = ComposeLaList();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (qryZugeteilt.Count < 1)
                return;

            qryVerfuegbar.DataTable.Rows.Add(qryZugeteilt.Row.ItemArray);
            qryZugeteilt.DeleteQuestion = null;
            qryZugeteilt.Delete();
            edtLAList.EditValue = ComposeLaList();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            System.Collections.Generic.List<int> idListBrutto = new System.Collections.Generic.List<int>();

            decimal totalBrutto = 0;
            CalculateTotal();

            foreach (DataRow row in qryBgPosition.DataTable.Rows)
            {
                if (!DBUtil.IsEmpty(row["Sel"]) && (bool)row["Sel"])
                {
                    idListBrutto.Add((int)row["KbBuchungBruttoID"]);
                    totalBrutto += (decimal)row["Betrag"];
                }
            }
            if (idListBrutto.Count == 0)
                return;

            _totalBelegCount = idListBrutto.Count; //für die Anzeige in ProgressStart

            String msg;
            if (idListBrutto.Count == 1)
                msg = string.Format("Soll 1 Forderungsbeleg mit dem Betrag von CHF {0:0,0.00} an PSCD übermittelt werden?", totalBrutto);
            else
                msg = string.Format(
                    "Sollen {0} Forderung(en) mit dem Total von CHF {1:0,0.00}" +
                    " an PSCD übermittelt werden?",
                    idListBrutto.Count,
                    totalBrutto);

            if (KissMsg.ShowQuestion(msg))
            {
                DlgProgressLog.Show("Transfer Sollstellungen an PSCD", 700, 500, ProgressStart, ProgressEnd, Session.MainForm);
            }
        }

        private void edtDebitor_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            e.Cancel = AuswahlDebitor(edtDebitor.EditValue.ToString(), e.ButtonClicked);

            /*
            if (kiSSKunde == KiSSKunde.BSS)
                e.Cancel = AuswahlKreditorBSS(edtDebitor.EditValue.ToString(),e.ButtonClicked);

            if (kiSSKunde == KiSSKunde.FAMOZ)
                e.Cancel = AuswahlKreditorFAMOZ(edtDebitor.EditValue.ToString(),e.ButtonClicked);
            */
        }

        private void edtFilter2_EditValueChanged(object sender, EventArgs e)
        {
            string value = "";
            if (!DBUtil.IsEmpty(edtFilter2.EditValue))
                value = edtFilter2.EditValue.ToString();

            qryZugeteilt.DataTable.DefaultView.RowFilter = "Name like '%" + value + "%'";
        }

        private void edtFilter_EditValueChanged(object sender, EventArgs e)
        {
            string value = "";
            if (!DBUtil.IsEmpty(edtFilter.EditValue))
                value = edtFilter.EditValue.ToString();

            qryVerfuegbar.DataTable.DefaultView.RowFilter = "Name like '%" + value + "%'";
        }

        private void edtKlient_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtKlient.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryBgPosition["Klient"] = null;
                    qryBgPosition["KlientID"] = null;
                    qryBgPosition["Adresse"] = null;
                    qryMonatsbudget.DataTable.Rows.Clear();
                    return;
                }
            }

            int searchNr;
            int.TryParse(searchString, out searchNr);

            string sql =
                @"
              SELECT distinct
                     BaPersonID$      = PRS.BaPersonID,
                     [Pers.-Nr.]   = PRS.BaPersonID,
                     Name             = PRS.NameVorname +
                                        ' (' + isNull(convert(varchar,PRS.AlterMortal),'-') +
                                        isNull(',' + GES.ShortText,'') + ')',
                     Adresse          = PRS.Wohnsitz,
                     [Fall-Nr]        = LEI.FaFallID,
                     [MB grau]        = (select count(*)
                                         from   BgBudget B
                                                inner join BgFinanzplan F on F.BgFinanzplanID = B.BgFinanzplanID
                                                inner join FaLeistung   L on L.FaLeistungID = F.FaLeistungID
                                         where  L.FaFallID = LEI.FaFallID and
                                                L.BaPersonID = PRS.BaPersonID and
                                                B.Masterbudget = 0 and
                                                B.BgBewilligungStatusCode = 1),
                     [MB grün]        = (select count(*)
                                         from   BgBudget B
                                                inner join BgFinanzplan F on F.BgFinanzplanID = B.BgFinanzplanID
                                                inner join FaLeistung   L on L.FaLeistungID = F.FaLeistungID
                                         where  L.FaFallID = LEI.FaFallID and
                                                L.BaPersonID = LEI.BaPersonID and
                                                B.Masterbudget = 0 and
                                                B.BgBewilligungStatusCode = 5),
                     [MB rot]        = (select count(*)
                                         from   BgBudget B
                                                inner join BgFinanzplan F on F.BgFinanzplanID = B.BgFinanzplanID
                                                inner join FaLeistung   L on L.FaLeistungID = F.FaLeistungID
                                         where  L.FaFallID = LEI.FaFallID and
                                                L.BaPersonID = LEI.BaPersonID and
                                                B.Masterbudget = 0 and
                                                B.BgBewilligungStatusCode = 9),
                     Name$            = PRS.NameVorname + ' (' + convert(varchar,PRS.BaPersonID) + ')'
              FROM   vwPerson PRS
                     inner join FaLeistung LEI on LEI.BaPersonID = PRS.BaPersonID and
                                                  LEI.FaProzessCode = 300
                     left  join XLOVCode   GES on GES.LOVName = 'BaGeschlecht' AND GES.Code = PRS.GeschlechtCode";

            if (searchNr != 0)
                sql += " WHERE PRS.BaPersonID = {0} OR LEI.FaFallID = {0} ORDER BY Name";
            else
                sql += " WHERE PRS.NameVorname LIKE '%' + {0} + '%' ORDER BY Name";

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(sql, searchString, e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                qryBgPosition["Klient"] = dlg["Name$"];
                qryBgPosition["KlientID"] = dlg["BaPersonID$"];
                qryBgPosition["Adresse"] = dlg["Adresse"];

                _filling = true;
                qryMonatsbudget.Fill(qryBgPosition["KlientID"], null);
                while (Convert.ToInt32(qryMonatsbudget["Jahr"]) != DateTime.Now.Year ||
                       Convert.ToInt32(qryMonatsbudget["Monat"]) != DateTime.Now.Month)
                {
                    if (!qryMonatsbudget.Next())
                        break;
                }
                _filling = false;
                SetVerwendungsPeriode();
                LoadPerson(true);
            }
        }

        private void edtKostenart_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtKostenart.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryBgPosition["BgPositionsArtID"] = DBNull.Value;
                    qryBgPosition["Kostenart"] = DBNull.Value;
                    qryBgPosition["KOA"] = DBNull.Value;
                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            string KOAText = "LA"; //this.kiSSKunde == KiSSKunde.BSS ? "KOA":"LA";
            string sql =
                "select " + KOAText +
                @"    = BKA.KontoNr,
                       Positionsart        = BPA.Name,
                       Quoting             = BKA.Quoting,
                       Gruppe              = GRP.Text,
                       BgPositionsartID$   = BPA.BgPositionsartID,
                       BgKostenartID$      = BPA.BgKostenartID,
                       KOAPositionsart$    = BKA.KontoNr + ' '+ BPA.Name,
                       KOA$                = BKA.KontoNr,
                       Name$               = BPA.Name,
                       BgSplittingArtCode$ = BKA.BgSplittingArtCode,
                       sqlRichtlinie$      = BPA.sqlRichtlinie,
                       GruppeFilter$       = convert(varchar(50),GRP.Value3),
                       BaZahlungswegIDFix$ = BKA.BaZahlungswegIDFix
                from   WhPositionsart BPA
                       inner join BgKostenart BKA on BKA.BgKostenartID = BPA.BgKostenartID
                       left  join XLOVCode    GRP on GRP.LOVName = 'BgGruppe' AND GRP.Code = BPA.BgGruppeCode
                where  BgKategorieCode = " +
                qryBgPosition["BgKategorieCode"] +
                @" and
                       (BPA.Name like '%' + {0} + '%' or
                        BKA.KontoNr like {0} + '%') and
                        BKA.KontoNr not in (860, 861, 862) -- Ertrags-SiLei dürfen im Budget nicht ausgewählt werden (siehe auch #90)
                        order by 1,2";

            e.Cancel = !dlg.SearchData(sql, searchString, e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                qryBgPosition["BgPositionsArtID"] = dlg["BgPositionsartID$"];
                qryBgPosition["Kostenart"] = dlg["KOAPositionsart$"];
                qryBgPosition["KOA"] = dlg["KOA$"];
                qryBgPosition["Buchungstext"] = dlg["Name$"];
                qryBgPosition["BgSplittingArtCode"] = dlg["BgSplittingArtCode$"];
                qryBgPosition["Quoting"] = dlg["Quoting"];

                if ((bool)dlg["Quoting"])
                    qryBgPosition["BaPersonID"] = null;
                else
                    LoadPerson(true);

                SetVerwendungsPeriode();
                SetEditMode();
            }
        }

        private void edtSucheErfassungMA_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtSucheErfassungMA.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                    searchString = "%";
                else
                {
                    edtSucheErfassungMA.EditValue = DBNull.Value;
                    edtSucheErfassungMA.LookupID = DBNull.Value;
                    edtSucheErfassungMA.ToolTip = "";
                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel =
                !dlg.SearchData(
                    @"
              SELECT ID$ = UserID,
                [Kürzel] = LogonName,
                [Mitarbeiter/in] = NameVorname,
                [Org.Einheit] = OrgUnit,
                DisplayText$ = DisplayText
              FROM   vwUser
              WHERE  DisplayText LIKE '%' + {0} + '%'
              ORDER BY NameVorname",
                    searchString,
                    e.ButtonClicked,
                    null,
                    null,
                    null);

            if (!e.Cancel)
            {
                edtSucheErfassungMA.EditValue = dlg["Kürzel"];
                edtSucheErfassungMA.LookupID = dlg["ID$"];
                edtSucheErfassungMA.ToolTip = dlg["DisplayText$"].ToString();
            }
        }

        private void edtSucheKlient_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtSucheKlient.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    edtSucheKlient.EditValue = null;
                    edtSucheKlient.LookupID = null;
                    return;
                }
            }

            int searchNr = 0;
            try
            {
                searchNr = Convert.ToInt32(searchString);
            }
            catch
            {
            }

            string sql =
                @"
              SELECT distinct
                     BaPersonID$      = PRS.BaPersonID,
                     [Pers.-Nr.]   = PRS.BaPersonID,
                     Name             = PRS.NameVorname +
                                        ' (' + isNull(convert(varchar,PRS.AlterMortal),'-') +
                                        isNull(',' + GES.ShortText,'') + ')',
                     Adresse          = PRS.Wohnsitz,
                     [Fall-Nr]        = LEI.FaFallID,
                     [MB grau]        = (select count(*)
                                         from   BgBudget B
                                                inner join BgFinanzplan F on F.BgFinanzplanID = B.BgFinanzplanID
                                                inner join FaLeistung   L on L.FaLeistungID = F.FaLeistungID
                                         where  L.FaFallID = LEI.FaFallID and
                                                L.BaPersonID = PRS.BaPersonID and
                                                B.Masterbudget = 0 and
                                                B.BgBewilligungStatusCode = 1),
                     [MB grün]        = (select count(*)
                                         from   BgBudget B
                                                inner join BgFinanzplan F on F.BgFinanzplanID = B.BgFinanzplanID
                                                inner join FaLeistung   L on L.FaLeistungID = F.FaLeistungID
                                         where  L.FaFallID = LEI.FaFallID and
                                                L.BaPersonID = LEI.BaPersonID and
                                                B.Masterbudget = 0 and
                                                B.BgBewilligungStatusCode = 5),
                     [MB rot]        = (select count(*)
                                         from   BgBudget B
                                                inner join BgFinanzplan F on F.BgFinanzplanID = B.BgFinanzplanID
                                                inner join FaLeistung   L on L.FaLeistungID = F.FaLeistungID
                                         where  L.FaFallID = LEI.FaFallID and
                                                L.BaPersonID = LEI.BaPersonID and
                                                B.Masterbudget = 0 and
                                                B.BgBewilligungStatusCode = 9),
                     Name$            = PRS.NameVorname + ' (' + convert(varchar,PRS.BaPersonID) + ')'
              FROM   vwPerson PRS
                     inner join FaLeistung LEI on LEI.BaPersonID = PRS.BaPersonID and
                                                  LEI.FaProzessCode = 300
                     left  join XLOVCode   GES on GES.LOVName = 'BaGeschlecht' AND GES.Code = PRS.GeschlechtCode";

            if (searchNr != 0)
                sql += " WHERE PRS.BaPersonID = {0} OR LEI.FaFallID = {0} ORDER BY Name";
            else
                sql += " WHERE PRS.NameVorname LIKE '%' + {0} + '%' ORDER BY Name";

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(sql, searchString, e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                edtSucheKlient.EditValue = dlg["Name$"];
                edtSucheKlient.LookupID = dlg["BaPersonID$"];
            }
        }

        private void grdSollstellung_Click(object sender, EventArgs e)
        {
            qryBgPosition.EndCurrentEdit();
            CalculateTotal();
        }

        private void grvSollstellung_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column != colSelektion)
                return;
            if (qryBgPosition.Post())
            {
                grvSollstellung.SetRowCellValue(e.RowHandle, colSelektion, e.Value);
                qryBgPosition.Row.AcceptChanges();
                qryBgPosition.RowModified = false;
            }
            else
            {
                grvSollstellung.SetRowCellValue(e.RowHandle, colSelektion, qryBgPosition["Sel"]);
            }
            CalculateTotal();
        }

        private void grvSollstellung_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column == colSelektion)
            {
                if (DBUtil.IsEmpty(grvSollstellung.GetRowCellValue(e.RowHandle, e.Column)))
                    e.RepositoryItem = repositoryItemTextEdit1;
                else
                    e.RepositoryItem = repositoryItemCheckEdit1;
            }
        }

        private void qryBgDokumente_AfterDelete(object sender, EventArgs e)
        {
            UpdateDocCount();
            // try to delete XDocument
            try
            {
                var documentID = (int?)qryBgDokumente["DocumentID"];
                if (documentID.HasValue)
                {
                    DBUtil.ExecSQL("DELETE FROM XDocument WHERE DocumentID = {0}", documentID.Value);
                }
            }
            catch
            {
            }
        }

        private void qryBgDokumente_AfterInsert(object sender, EventArgs e)
        {
            qryBgDokumente["BgDokumentTypCode"] = 1;
            qryBgDokumente["Stichwort"] = qryBgPosition["Kostenart"];

            edtDokumentTyp.Focus();
        }

        private void qryBgDokumente_BeforeInsert(object sender, EventArgs e)
        {
            if (!qryBgPosition.Post())
            {
                tabBgPosition.SelectedTabIndex = 0;
                throw new Exception();
            }
        }

        private void qryBgDokumente_BeforePost(object sender, EventArgs e)
        {
            if (!qryBgDokumente.IsSilentPostingFromXDocument && DBUtil.IsEmpty(qryBgDokumente["DocumentID"]))
            {
                KissMsg.ShowInfo("Erfassen sie zuerst ein Dokument.");
                throw new KissCancelException();
            }

            qryBgDokumente["BgPositionID"] = DBNull.Value;
            qryBgDokumente["BgBudgetID"] = DBNull.Value;
            qryBgDokumente["BgFinanzplanID"] = DBNull.Value;

            switch ((int)qryBgDokumente["BgDokumentTypCode"])
            {
                case 1:
                    qryBgDokumente["BgPositionID"] = qryBgPosition["BgPositionID"];
                    break;

                case 2:
                    qryBgDokumente["BgBudgetID"] = qryMonatsbudget["BgBudgetID"];
                    break;

                case 3:
                    qryBgDokumente["BgFinanzplanID"] = qryMonatsbudget["BgFinanzPlanID"];
                    break;
            }

            if (DBUtil.IsEmpty(qryBgDokumente["Stichwort"]))
                qryBgDokumente["Stichwort"] = "-";
        }

        private void qryBgDokumente_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            qryBgPosition.RowModified = true;
        }

        private void qryBgDokumente_PostCompleted(object sender, EventArgs e)
        {
            UpdateDocCount();
            if (!DBUtil.IsEmpty(qryBgDokumente["BgPositionID"]) && !qryBgDokumente.IsSilentPostingFromXDocument)
            {
                qryBgDokumente.Fill(qryBgDokumente["BgPositionID"]);
            }
        }

        private void qryBgPosition_AfterFill(object sender, EventArgs e)
        {
            CalculateTotal();
            lblRowCount.Text = qryBgPosition.Count.ToString();
        }

        private void qryBgPosition_AfterInsert(object sender, EventArgs e)
        {
            qryBgPosition["BgKategorieCode"] = 1;
            qryBgPosition["Status"] = 1; //grau
            qryBgPosition["Quoting"] = true;
            qryBgPosition["VerwaltungSD"] = true;

            _origVerwPeriodeVon = qryBgPosition["VerwPeriodeVon"];
            _origVerwPeriodeBis = qryBgPosition["VerwPeriodeBis"];

            tabBgPosition.SelectedTabIndex = 0;
            SetEditMode();

            ctlErfassungMutation1.ShowInfo();

            edtKlient.Focus();
        }

        private void qryBgPosition_BeforeDelete(object sender, EventArgs e)
        {
            DBUtil.ExecSQL(
                @"
                delete BgDokument where BgPositionID = {0}",
                qryBgPosition["BgPositionID"]);
        }

        private void qryBgPosition_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            int status = ShUtil.GetCode(qryBgPosition["Status"]);

            if (status != 1)
                throw new KissInfoException("nur graue Positionen können gelöscht werden!");
        }

        private void qryBgPosition_BeforePost(object sender, EventArgs e)
        {
            int positionBewilligung = ShUtil.GetCode(qryBgPosition["BgBewilligungStatusCode"]);
            int budgetBewilligung = ShUtil.GetCode(qryMonatsbudget["BgBewilligungStatusCode"]);

            // check must fields
            DBUtil.CheckNotNullField(edtKlientID, lblKlient.Text);
            DBUtil.CheckNotNullField(edtBuchungstext, lblBuchungstext.Text);
            DBUtil.CheckNotNullField(edtKostenart, lblKostenart.Text);
            DBUtil.CheckNotNullField(edtBuchungstext, lblBuchungstext.Text);
            DBUtil.CheckNotNullField(edtBetrag, lblBetrag.Text);

            if (Convert.ToDecimal(qryBgPosition["Betrag"]) <= Decimal.Zero)
            {
                edtBetrag.Focus();
                throw new KissInfoException("Der Betrag darf nicht 0.00 oder negativ sein!");
            }

            //Betrifft Person
            bool quoting = !DBUtil.IsEmpty(qryBgPosition["Quoting"]) && (bool)qryBgPosition["Quoting"];
            if (quoting)
            {
                qryBgPosition["BaPersonID"] = null;
            }
            else
            {
                if (DBUtil.IsEmpty(qryBgPosition["BaPersonID"]))
                {
                    edtBaPersonID.Focus();
                    throw new KissInfoException("Das Feld 'Betrifft Person' darf nicht leer bleiben für diese Leistungsart!");
                }
            }

            //Verwendungsperiode
            int bgSplittingArtCode = ShUtil.GetCode(qryBgPosition["BgSplittingArtCode"]);
            qryBgPosition["FaelligAm"] = edtFaelligAm.EditValue; //get pending edit changes (KiSS bug)
            switch (bgSplittingArtCode)
            {
                case 1: //Taggenau
                case 2: //Monat
                    DBUtil.CheckNotNullField(edtVerwPeriodeVon, "Verwendungsperiode von");
                    DBUtil.CheckNotNullField(edtVerwPeriodeBis, "Verwendungsperiode bis");
                    if ((DateTime)edtVerwPeriodeBis.EditValue < (DateTime)edtVerwPeriodeVon.EditValue)
                    {
                        throw new KissInfoException("'Verwendungsperiode von' muss kleiner sein als 'Verwendungsperiode bis'.");
                    }
                    break;

                case 3: //Valuta
                    qryBgPosition["VerwPeriodeVon"] = qryBgPosition["FaelligAm"];
                    qryBgPosition["VerwPeriodeBis"] = qryBgPosition["FaelligAm"];
                    break;

                case 4: //Entscheid
                    DBUtil.CheckNotNullField(edtVerwPeriodeVon, "Verwendungsperiode von");
                    break;
            }

            //Fällig am + Debitor sind Mussfelder für abgetretene Einnahmen
            if ((bool)qryBgPosition["VerwaltungSD"])
            {
                DBUtil.CheckNotNullField(edtFaelligAm, lblValutaDatum.Text);
                DBUtil.CheckNotNullField(edtDebitor, lblDebitor.Text);
            }

            if (budgetBewilligung >= 5 && positionBewilligung == 1 && !(bool)qryBgPosition["VerwaltungSD"])
            {
                throw new KissInfoException("In einem grünen/roten Budget können nur noch abgetretene Einnahmen erfasst werden!");
            }

            if (qryMonatsbudget.Count == 0)
            {
                throw new KissInfoException("Es gibt keine verfügbaren Budgets für diesen Mandanten!");
            }

            qryBgPosition["BgBudgetID"] = qryMonatsbudget["BgBudgetID"];
            qryBgPosition["FallBaPersonID"] = qryMonatsbudget["FallBaPersonID"];
            qryBgPosition["BgFinanzplanID"] = qryMonatsbudget["BgFinanzplanID"];

            qryBgPosition["MA"] = Session.User.LogonName;

            //Calculated Grid columns
            qryBgPosition["S"] = ((bool)qryBgPosition["VerwaltungSD"]) ? "S" : null;
            qryBgPosition["Tage"] = ((DateTime)qryBgPosition["FaelligAm"]).Subtract(DateTime.Today).Days;

            ctlErfassungMutation1.SetFields();
        }

        private void qryBgPosition_PositionChanged(object sender, EventArgs e)
        {
            ctlErfassungMutation1.ShowInfo();

            _origVerwPeriodeVon = qryBgPosition["VerwPeriodeVon"];
            _origVerwPeriodeBis = qryBgPosition["VerwPeriodeBis"];

            int status = ShUtil.GetCode(qryBgPosition["Status"]);

            _filling = true;
            switch (status)
            {
                case 0:
                    qryMonatsbudget.Fill(qryBgPosition["KlientID"], null);
                    try
                    {
                        while (Convert.ToInt32(qryMonatsbudget["Jahr"]) != DateTime.Now.Year ||
                               Convert.ToInt32(qryMonatsbudget["Monat"]) != DateTime.Now.Month)
                        {
                            if (!qryMonatsbudget.Next())
                                break;
                        }
                    }
                    catch
                    {
                    }
                    break;

                case 1:
                case 12:
                case 14:
                case 15:
                    qryMonatsbudget.Fill(qryBgPosition["KlientID"], null);
                    while (!DBUtil.IsEmpty(qryBgPosition["BgBudgetID"]) &&
                           (DBUtil.IsEmpty(qryMonatsbudget["BgBudgetID"]) || (int)qryBgPosition["BgBudgetID"] != (int)qryMonatsbudget["BgBudgetID"]))
                    {
                        if (!qryMonatsbudget.Next())
                        {
                            break;
                        }
                    }
                    break;

                default:
                    qryMonatsbudget.Fill(qryBgPosition["KlientID"], qryBgPosition["BgBudgetID"]);
                    break;
            }
            _filling = false;

            qryBgDokumente.Fill(qryBgPosition["BgPositionID"]);

            LoadPerson(false);
            SetEditMode();
        }

        private void qryMonatsbudget_PositionChanged(object sender, EventArgs e)
        {
            if (_filling)
                return;

            qryMonatsbudget.RowModified = true;

            if (_origVerwPeriodeVon.ToString() == qryBgPosition["VerwPeriodeVon"].ToString() &&
                _origVerwPeriodeBis.ToString() == qryBgPosition["VerwPeriodeBis"].ToString())
            {
                SetVerwendungsPeriode();
            }
            LoadPerson(false);
            SetEditMode();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override bool OnAddData()
        {
            //keine Reakion, falls noch nie gesucht wurde
            if (tabControlSearch.SelectedTabIndex == 1 && qryBgPosition.DataTable.Columns.Count == 0)
            {
                return false;
            }

            if (tabBgPosition.SelectedTab == tpgDokumente)
            {
                qryBgDokumente.Insert();
            }
            else
            {
                qryBgPosition.Insert();
            }
            return true;
        }

        public override bool OnDeleteData()
        {
            if (tabBgPosition.SelectedTab == tpgDokumente)
            {
                return qryBgDokumente.Delete();
            }

            return qryBgPosition.Delete();
        }

        public override bool OnKeyDownKiss(KeyEventArgs e)
        {
            var keys = DBUtil.GetConfigShortcut(@"System\Allgemein\NeuesDokumentShortcut", "Control+N");

            if (e.KeyData == keys.KeyData)
            {
                DocumentImport();
            }

            return base.OnKeyDownKiss(e);
        }

        public override bool OnSaveData()
        {
            if (tabBgPosition.SelectedTab == tpgDokumente)
            {
                return qryBgDokumente.Post();
            }

            return qryBgPosition.Post();
        }

        public override void OnSearch()
        {
            if (tabControlSearch.SelectedTab == tpgListe && edtKeepValues.Checked)
            {
                tabControlSearch.SelectedTabIndex = 1;
            }
            else
            {
                base.OnSearch();
            }
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();
            PresetSearchFields();
            edtSucheErfassungMA.Focus();
        }

        protected override void RunSearch()
        {
            base.RunSearch();

            if (qryBgPosition.Count == 0)
            {
                qryBgPosition_PositionChanged(null, null);
            }
            else
            {
                qryBgPosition.Last();
            }
        }

        #endregion

        #region Private Methods

        private bool AuswahlDebitor(string searchString, bool buttonClicked)
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
                    qryBgPosition["DebitorBaPersonID"] = DBNull.Value;
                    qryBgPosition["Debitor"] = DBNull.Value;
                    qryBgPosition["ZusatzInfo"] = DBNull.Value;
                    return false;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();

            switch (searchString)
            {
                case "":
                    break;

                case ".":
                    // Debitor aus
                    // Klientensystem       - FaFallPerson
                    // Involvierte Stellen  - FaInvolvierteInstitution
                    // Krankenkasse         - BaKrankenversicherung
                    // Vermieter            - BaWohnsituation
                    // Arbeitgeber          - BaArbeit

                    cancel =
                        !dlg.SearchData(
                            @"
                        -- Klientensystem
                        SELECT  Art               = 'Klientensystem',
                                Name              = PRS.NameVorname,
                                Adresse           = PRS.Wohnsitz,
                                Typ               = null,
                                BaInstitutionID$  = null,
                                BaPersonID$       = PRS.BaPersonID,
                                Adresse$          = PRS.WohnsitzMehrzeilig,
                                SortKey$          = 1
                        FROM    FaFallPerson FAP
                                INNER JOIN vwPerson PRS ON PRS.BaPersonID = FAP.BaPersonID
                        WHERE   FAP.FaFallID = {0}

                        UNION

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
                            qryMonatsbudget["FaFallID"].ToString(),
                            buttonClicked);
                    break;

                default:
                    cancel =
                        !dlg.SearchData(
                            @"
              			SELECT Name             = INS.Name,
                               Adresse          = INS.Adresse,
                               Typ              = INS.Typ,
                               BaInstitutionID$ = INS.BaInstitutionID,
                               BaPersonID$      = null,
                               Adresse$         = INS.AdresseMehrzeilig
                        FROM   vwInstitution INS
                        WHERE  INS.BaFreigabeStatusCode = 2 AND
                               (INS.Name LIKE '%' + {0} + '%' OR
                                INS.AdressZusatz LIKE '%' + {0} + '%') AND
                               INS.Debitor = 1
              			ORDER BY Name",
                            searchString,
                            buttonClicked,
                            null,
                            null,
                            null);
                    break;
            }

            if (!cancel)
            {
                qryBgPosition["BaInstitutionID"] = dlg["BaInstitutionID$"];
                qryBgPosition["DebitorBaPersonID"] = dlg["BaPersonID$"];
                qryBgPosition["Debitor"] = dlg["Name"];
                qryBgPosition["ZusatzInfo"] = dlg["Adresse$"];
            }
            return cancel;
        }

        private void CalculateTotal()
        {
            int count = 0;
            decimal total = 0;

            foreach (DataRow row in qryBgPosition.DataTable.Rows)
            {
                if (!DBUtil.IsEmpty(row["Sel"]) && (bool)row["Sel"])
                {
                    count++;
                    total += (decimal)row["Betrag"];
                }
            }

            edtTotal.EditValue = total;
            edtAnzahl.EditValue = count;

            btnTransfer.Enabled = (count > 0);
        }

        private string ComposeLaList()
        {
            if (qryZugeteilt.Count == 0)
                return null;

            string laList = "";
            foreach (DataRow row in qryZugeteilt.DataTable.Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    if (laList != "")
                        laList += ",";
                    laList += row["KontoNr"].ToString();
                }
            }
            return laList;
        }

        private void DocumentImport()
        {
            if (qryBgPosition.Post())
            {
                tabBgPosition.SelectTab(tpgDokumente);
                qryBgDokumente.Insert();
                edtDocument.Focus();
                edtDocument.ImportDoc();
            }
        }

        private void LoadPerson(bool autoSetSinglePerson)
        {
            edtBaPersonID.LoadQuery(
                DBUtil.OpenSQL(
                    @"
                select Code = FPP.BaPersonID,
                       Text = PRS.NameVorname + ' (' + convert(varchar,PRS.BaPersonID) + ')',
                       NameVorname = PRS.NameVorname
                from   BgFinanzPlan_BaPerson FPP
                       inner join vwPerson PRS on PRS.BaPersonID = FPP.BaPersoNID
                       left  join XLOVCode GES on GES.LOVName = 'BaGeschlecht' AND GES.Code = PRS.GeschlechtCode
                where  BgFinanzplanID = {0} and
                       IstUnterstuetzt = 1
                order by PRS.NameVorname",
                    qryMonatsbudget["BgFinanzplanID"]));

            SqlQuery qry = (SqlQuery)edtBaPersonID.Properties.DataSource;
            if (autoSetSinglePerson && !(bool)qryBgPosition["Quoting"] && qry.Count == 1)
            {
                qryBgPosition["BaPersonID"] = qry["Code"];
            }
        }

        private void PresetSearchFields()
        {
            //edtSucheErfassungMA.EditValue = Session.User.LogonName;
            //edtSucheErfassungMA.LookupID = Session.User.UserID;
            edtSucheSelectTop.EditValue = 100;
            edtInklNichtAbgetreteneEinnahmen.Checked = false;
            btnRemoveAll.PerformClick();
        }

        private void ProgressEnd()
        {
            qryBgPosition.Refresh();
        }

        private void ProgressStart()
        {
            Cursor = Cursors.WaitCursor;
            ApplicationFacade.DoEvents();

            DlgProgressLog.AddLine("Start der Übertragung");
            ApplicationFacade.DoEvents();
            int successCount = 0;
            int failureCount = 0;
            int count = 1;

            try
            {
                foreach (DataRow row in qryBgPosition.DataTable.Rows)
                {
                    if (!DBUtil.IsEmpty(row["Sel"]) && (bool)row["Sel"])
                    {
                        string userText = string.Format("Beleg {0}/{1}  {2}; CHF {3:N2}", count, _totalBelegCount, row["Klient"], row["Betrag"]);

                        DlgProgressLog.AddLine(userText + ": senden ... ");

                        try
                        {
                            // Das ValutaDatum wird bei Debitoren nicht mitgegeben
                            bool success = FAMOZ.PSCDServices.PSCDInterface.SubmitWhBuchungsstoff(null, new int[] { (int)row["KbBuchungBruttoID"] });

                            if (success)
                                successCount++;
                            else
                                failureCount++;
                        }
                        catch (Exception ex)
                        {
                            DlgProgressLog.AddLine(ex.Message);
                            failureCount++;
                        }
                        count++;
                    }
                }
                DlgProgressLog.AddLine("Ende der Übertragung");
                DlgProgressLog.AddLine(string.Format("- {0} Beleg(e) erfolgreich übermittelt", successCount));
                DlgProgressLog.AddLine(string.Format("- {0} Beleg(e) fehlerhaft", failureCount));
            }
            catch (CancelledByUserException)
            {
                KissMsg.ShowInfo(
                    "Abbruch durch Benutzer/in\r\n\r\n" +
                    string.Format("- {0} Beleg(e) erfolgreich übermittelt", successCount) + "\r\n" +
                    string.Format("- {0} Beleg(e) fehlerhaft", failureCount));
            }

            Cursor = Cursors.Default;

            DlgProgressLog.EndProgress();
            DlgProgressLog.ShowTopMost();
        }

        private void SetEditMode()
        {
            int status = ShUtil.GetCode(qryBgPosition["Status"]);
            int bgSplittingArtCode = ShUtil.GetCode(qryBgPosition["BgSplittingArtCode"]);
            int budgetBewilligung = ShUtil.GetCode(qryMonatsbudget["BgBewilligungStatusCode"]);

            bool editable = (status <= 1) && qryBgPosition.Count > 0;

            qryBgPosition.EnableBoundFields(editable);

            //Verwendungsperiode + Splitting
            switch (bgSplittingArtCode)
            {
                case 1: //Taggenau
                case 2: //monat
                    edtVerwPeriodeVon.EditMode = editable ? EditModeType.Normal : EditModeType.ReadOnly;
                    edtVerwPeriodeBis.EditMode = editable ? EditModeType.Normal : EditModeType.ReadOnly;
                    break;

                case 4: //Entscheid
                    edtVerwPeriodeVon.EditMode = editable ? EditModeType.Normal : EditModeType.ReadOnly;
                    edtVerwPeriodeBis.EditMode = EditModeType.ReadOnly;
                    break;

                default:
                    edtVerwPeriodeVon.EditMode = EditModeType.ReadOnly;
                    edtVerwPeriodeBis.EditMode = EditModeType.ReadOnly;
                    break;
            }

            //Positionsbuttons Bewilligung, Gruen, Grau
            btnPositionGruen.Visible = (status <= 1 && budgetBewilligung >= 5); //graue/neue Position im grünen/roten Budget
            btnPositionGrau.Visible = (status == 2) || (status == 7); //grüne/rote Position

            //set edit modes of edit fields
            edtKostenart.EditMode = editable ? EditModeType.Normal : EditModeType.ReadOnly;
            edtBuchungstext.EditMode = editable ? EditModeType.Normal : EditModeType.ReadOnly;
            edtBetrag.EditMode = editable ? EditModeType.Normal : EditModeType.ReadOnly;

            edtDebitor.EditMode = editable ? EditModeType.Normal : EditModeType.ReadOnly;

            bool quoting = !DBUtil.IsEmpty(qryBgPosition["Quoting"]) && (bool)qryBgPosition["Quoting"];
            edtBaPersonID.EditMode = editable && !quoting ? EditModeType.Normal : EditModeType.ReadOnly;
        }

        private void SetVerwendungsPeriode()
        {
            try
            {
                int bgSplittingArtCode = ShUtil.GetCode(qryBgPosition["BgSplittingArtCode"]);
                switch (bgSplittingArtCode)
                {
                    case 1: //Taggenau
                    case 2: //Monat
                        DateTime firstDate = new DateTime((int)qryMonatsbudget["Jahr"], (int)qryMonatsbudget["Monat"], 1);
                        qryBgPosition["VerwPeriodeVon"] = firstDate;
                        qryBgPosition["VerwPeriodeBis"] = firstDate.AddMonths(1).AddDays(-1);
                        qryBgPosition.RefreshDisplay();
                        break;

                    case 3: //Valuta
                    case 4: //Entscheid
                        qryBgPosition["VerwPeriodeVon"] = DBNull.Value;
                        qryBgPosition["VerwPeriodeBis"] = DBNull.Value;
                        qryBgPosition.RefreshDisplay();
                        break;
                }
            }
            catch
            {
            }
            _origVerwPeriodeVon = qryBgPosition["VerwPeriodeVon"];
            _origVerwPeriodeBis = qryBgPosition["VerwPeriodeBis"];
        }

        private void UpdateDocCount()
        {
            bool modified = qryBgPosition.RowModified;

            if (qryBgDokumente.Count > 0)
                qryBgPosition["Doc"] = qryBgDokumente.Count;
            else
                qryBgPosition["Doc"] = null;

            if (!modified)
            {
                qryBgPosition.RowModified = false;
                qryBgPosition.Row.AcceptChanges();
            }
        }

        #endregion

        #endregion
    }
}