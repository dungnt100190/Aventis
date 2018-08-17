using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Kiss.Infrastructure.Document;
using Kiss.Interfaces.DocumentHandling;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.Common.Report;
using KiSS4.DB;
using KiSS4.Dokument;
using KiSS4.Gui;
using KiSS4.Messages;

namespace KiSS4.Vormundschaft.ZH
{
    public partial class CtlKgKontoblatt : KissSearchUserControl
    {
        private int _baPersonID;
        private int _faLeistungID;
        private int _fallBaPersonID;

        /// <summary>
        /// In der Variable ist die PeriodeId gespeichert.
        /// Bei der ersten Suche bei einem Mandant
        /// ist das Vekehrskonto im Grid expandiert, bei der zweiten
        /// Suche sind alle Konti expandiert.
        /// </summary>
        private int _firstTime;

        private bool _initSearch;
        private bool _positionRefreshing;
        private int? _wartezeitNachDrucken;

        public CtlKgKontoblatt()
        {
            InitializeComponent();
            gridView1.MouseUp += gridView1_MouseUp;
        }

        public override string GetContextName()
        {
            if (qryPeriode.Count > 0)
            {
                return Name;
            }

            return Name + "2";
        }

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "KGPERIODEID":
                    if (qryPeriode.Count > 0)
                    {
                        return qryPeriode["KgPeriodeID"];
                    }

                    return DBNull.Value;

                case "KONTONRVON":
                    return edtKontoVon.EditValue;

                case "KONTONRBIS":
                    return edtKontoBis.EditValue;

                case "DATUMVON":
                    return edtDatumVon.EditValue;

                case "DATUMBIS":
                    return edtDatumBis.EditValue;
            }

            return base.GetContextValue(fieldName);
        }

        public void Init(string name, Image titleImage, int faLeistungID, int baPersonID, int fallBaPersonID)
        {
            _initSearch = (_baPersonID != baPersonID);  // If the BaPerson to show is not the one already shown, then reinitialize the search

            lblTitel.Text = name;
            picTitel.Image = titleImage;
            _faLeistungID = faLeistungID;
            _baPersonID = baPersonID;
            _fallBaPersonID = fallBaPersonID;

            if (_initSearch)
            {
                InitSearch();
            }
        }

        public void InitSearch()
        {
            _firstTime = 0;

            if (_baPersonID > 0)
            {
                PresetSearchValues();
                edtMandant.EditMode = EditModeType.ReadOnly;
                if (tabControlSearch.SelectedTabIndex != 0)
                {
                    // ein Tabwechsel löst RunSearch aus
                    tabControlSearch.SelectedTabIndex = 0;
                }
                else
                {
                    RunSearch();
                }

                //Initialanzeige: 1040 Expanded, alle anderen Konti collapsed
            }
            else
            {
                _firstTime = 0;
                edtMandant.EditMode = EditModeType.Normal;
                NewSearch();
            }
        }

        public override void OnRefreshData()
        {
            if (tabControlSearch.SelectedTab == tpgSuchen)
            {
                RefreshPeriode();
                edtDatumVon.DateTime = (DateTime)qryPeriode["PeriodeVon"];
                edtDatumBis.DateTime = (DateTime)qryPeriode["PeriodeBis"];
            }
            base.OnRefreshData();
        }

        protected override void NewSearch()
        {
            base.NewSearch();
            PresetSearchValues();

            if (_baPersonID > 0)
            {
                edtValutaBis.Focus();
            }
            else
            {
                edtMandant.Focus();
            }
        }

        protected override void RunSearch()
        {
            if (!CheckPrms())
            {
                throw new Exception();
            }

            colKtoName.GroupIndex = -1;

            Cursor = Cursors.WaitCursor;

            // Parameter aufbereiten
            qryKontoblaetter.Fill("exec spKgGetKontoblaetter {0},{1},{2},{3},{4},{5},{6},{7}",
                                  qryPeriode["KgPeriodeID"],
                                  edtKontoVon.EditValue,
                                  edtKontoBis.EditValue,
                                  edtDatumVon.EditValue,
                                  edtDatumBis.EditValue,
                                  edtValutaVon.EditValue,
                                  edtValutaBis.EditValue,
                                  edtAusgeglicheneKDAusblenden.EditValue);

            lblMandant.Text = edtMandant.Text + "  (" + edtDatumVon.Text + " - " + edtDatumBis.Text + ")";

            colKtoName.GroupIndex = 0;

            if (_firstTime != (int)qryPeriode["KgPeriodeID"])
            {
                //erste Anzeige: Verkehrskonto expandiert, alle anderen Konti collapsed
                _firstTime = (int)qryPeriode["KgPeriodeID"];

                try
                {
                    //Gruppe finden, sorry ist ein hack. Es scheint so, als könnte man zu diesem Zeitpunkt noch nicht
                    //auf Daten im DevExpressGrid zugreiffen. In DevExpross sind die Ids der GroupRows: -1, -2, ...
                    //und die Ids der Datenrows: 1,2,3,
                    var kontoNamen = new List<string>();
                    for (int i = 0; i < qryKontoblaetter.Count; i++)
                    {
                        string kontoName = qryKontoblaetter.DataTable.Rows[i]["KtoName"].ToString();
                        var kontoArtCode = qryKontoblaetter.DataTable.Rows[i]["KgKontoartCode"] as int?;

                        if (kontoNamen.Contains(kontoName) == false)
                        {
                            kontoNamen.Add(kontoName);
                        }

                        //Überprüfen, ob es ein Verkehrskontoist
                        if (kontoArtCode.HasValue && kontoArtCode.Value == 1) //1: Verkehrskonto
                        {
                            int index = kontoNamen.IndexOf(kontoName);
                            int groupRowHandle = -1 * index - 1; //GroupRows sind negativ mit basis -1: -1, -2 u.s.w.
                            gridView1.ExpandGroupRow(groupRowHandle);
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    KissMsg.ShowError("Fehler bei der Darstellung.", ex);
                }
            }
            else
            {
                gridView1.ExpandAllGroups();
            }

            Cursor = Cursors.Default;
        }

        private void btnAlleDokumenteAuswaehlen_Click(object sender, EventArgs e)
        {
            SetDokumenteSelection(true);
        }

        private void btnCollapse_Click(object sender, EventArgs e)
        {
            gridView1.CollapseAllGroups();
            grid.Focus();
        }

        private void btnDokumenteDrucken_Click(object sender, EventArgs e)
        {
            if (!IsOneDocumentSelected())
            {
                KissMsg.ShowInfo(Name, "KeinDokumentSelektiert", "Sie haben kein Dokument zum ausdrucken selektiert.");
                return;
            }

            if (!_wartezeitNachDrucken.HasValue)
            {
                _wartezeitNachDrucken = DBUtil.GetConfigInt(@"System\Dokumentemanagement\WartezeitNachDrucken", 0);
                //sicherstellen, dass Wert positiv ist (sonst wird unendlich lange gewartet)
                if (_wartezeitNachDrucken < 0)
                {
                    _wartezeitNachDrucken = 0;
                }
            }

            try
            {
                var currentCursor = Cursor.Current;
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    var documentHandlers = new List<XDocFileHandler>();
                    var printInfos = new List<PdfFileInfo>();

                    foreach (var row in qryDocument.DataTable.Rows.Cast<DataRow>().Where(x => !DBUtil.IsEmpty(x[DBO.XDocument.DocumentID])).OrderBy(x => (x[DBO.XDocument.DateCreation] as DateTime?) ?? DateTime.MinValue))
                    {
                        if (Utils.ConvertToBool(row["Selektion"]))
                        {
                            var docFileHandler = XDocFileHandler.CreateFileHandler(
                                DokTyp.Dokument,
                                row[DBO.XDocument.DocumentID],
                                row[DBO.XDocument.FileExtension].ToString(),
                                false);
                            docFileHandler.DBToFile(false, false, false);
                            documentHandlers.Add(docFileHandler);

                            printInfos.Add(new PdfFileInfo(docFileHandler.FileInfo, Utils.ConvertToBool(row["Deckblatt"])));
                        }
                    }

                    // PDFs drucken
                    var printOptions = new PdfPrintOptions
                    {
                        DeleteMergedPdfAfterPrinting = true,
                        MaxDeleteAttemptOfMergedDocument = DBUtil.GetConfigInt(@"System\Dokumentemanagement\MaxLoeschversucheVonPdfNachDrucken", 1),
                        MergeBeforePrint = true,
                        PrinterName = (string)edtDrucker.SelectedItem,
                        WaitTimeAfterPrint = _wartezeitNachDrucken.Value,
                        TempPath = DBUtil.GetConfigString(@"System\Dokumentemanagement\Temporaerpfad", Path.GetTempPath()),
                    };

                    var result = PdfHelper.Print(printInfos.Where(x => x.FileInfo.Extension.ToUpper() == ".PDF").ToList(), printOptions);

                    // Dokumente die nicht PDFs sind einzeln drucken
                    var notPdfFileInfos = printInfos.Where(x => x.FileInfo.Extension.ToUpper() != ".PDF").ToList();
                    notPdfFileInfos.ForEach(
                        x =>
                        {
                            DocumentHelper.PrintDocument(x.FileInfo, printOptions.PrinterName);
                            var waitTask = Task.Factory.StartNew(() => Thread.Sleep(_wartezeitNachDrucken.Value));
                            waitTask.Wait();
                        });

                    documentHandlers.ForEach(x => x.DestroyWatcherAndDeleteFileAndUnlock(true, false));

                    if (!result.IsOk)
                    {
                        Cursor.Current = currentCursor;
                        KissMsg.ShowInfo(string.Format("Fehler beim Drucken: \r\n{0}", result.GetWarningsAndErrors()));
                    }
                }
                finally
                {
                    Cursor.Current = currentCursor;
                }
            }
            catch (KissErrorException exp)
            {
                KissMsg.ShowError(string.Format("Fehler beim Drucken: \r\n{0}", exp.Message));
            }
        }

        private void btnDrucken_Click(object sender, EventArgs e)
        {
            if (qryPeriode.Count == 0) return;
            if (!CheckPrms()) return;

            var prms = new NamedPrm[8];
            prms[0] = new NamedPrm("KgPeriodeID", qryPeriode["KgPeriodeID"]);
            prms[1] = new NamedPrm("KontoNrVon", edtKontoVon.EditValue);
            prms[2] = new NamedPrm("KontoNrBis", edtKontoBis.EditValue);
            prms[3] = new NamedPrm("DatumVon", edtDatumVon.EditValue);
            prms[4] = new NamedPrm("DatumBis", edtDatumBis.EditValue);
            prms[5] = new NamedPrm("ValutaVon", edtValutaVon.EditValue);
            prms[6] = new NamedPrm("ValutaBis", edtValutaBis.EditValue);
            prms[7] = new NamedPrm("AusgeglicheneAusblenden", edtAusgeglicheneKDAusblenden.EditValue);

            KissMsg.ShowInfo("Bitte Beachten: Beim Erstellen des Reports 'Kontoauszug' sind möglicherweise Unterschiede zwischen Reportausdruck und effektiver Buchungslage (zB. ZKB-Verkehrskonto) vorhanden. Sollte der Report an Dritte weitergereicht werden, ist eine Kontaktaufnahme mit der KLIBU für eine allfällige Aktualisierung vorzunehmen");

            RepUtil.ExecuteReport("KgKontoblatt", KissReportDestination.Viewer, prms);
        }

        private void btnExpand_Click(object sender, EventArgs e)
        {
            gridView1.ExpandAllGroups();
            grid.Focus();
        }

        private void btnKeineDokumenteAuswaehlen_Click(object sender, EventArgs e)
        {
            SetDokumenteSelection(false);
        }

        private void btnMonatsbudget_Click(object sender, EventArgs e)
        {
            var dic = new System.Collections.Specialized.HybridDictionary();
            dic.Add("ClassName", "FrmFall");
            dic.Add("BaPersonID", _fallBaPersonID);
            dic.Add("ModulID", 5); // K
            dic.Add("TreeNodeID", qryKontoblaetter["JumpToMBPfad"]);
            dic.Add("ActiveSQLQuery.Find", String.Format("KgPositionID = {0}", qryKontoblaetter["JumpToKgPositionID"]));
            FormController.OpenForm((string)dic["ClassName"], "Action", "JumpToPath", dic);
        }

        private bool CheckPrms()
        {
            // Suchfelder validieren
            if (DBUtil.IsEmpty(edtMandant.EditValue))
            {
                DlgInfo.Show("Das Feld 'Mandant' darf nicht leer bleiben", 0, 0);
                return false;
            }

            if (DBUtil.IsEmpty(edtKontoVon.EditValue))
            {
                DlgInfo.Show("Das Feld 'Konto-Nr. von' darf nicht leer bleiben", 0, 0);
                return false;
            }

            if (DBUtil.IsEmpty(edtKontoBis.EditValue))
            {
                edtKontoBis.EditValue = edtKontoVon.EditValue;
            }

            if (DBUtil.IsEmpty(edtDatumVon.EditValue))
            {
                DlgInfo.Show("Das Feld 'Datum von' darf nicht leer bleiben", 0, 0);
                return false;
            }

            if (DBUtil.IsEmpty(edtDatumBis.EditValue))
            {
                DlgInfo.Show("Das Feld 'Datum bis' darf nicht leer bleiben", 0, 0);
                return false;
            }
            return true;
        }

        private void CtlKgKontoblatt_Load(object sender, EventArgs e)
        {
            lblMandant.Text = "";

            gridView1.Appearance.HideSelectionRow.Options.UseFont = false;
            gridView1.Appearance.FocusedRow.Options.UseFont = false;
            gridView1.Appearance.FocusedCell.Options.UseFont = false;

            if (_initSearch)
            {
                InitSearch();
            }

            colDokumentTyp.ColumnEdit = grdDokumente.GetLOVLookUpEdit("KgDokumentTyp");

            //init Drucker-Feld
            FillEdtDrucker();
        }

        private void DisplayPerioden()
        {
            tpgSuchen.Visible = true;
            qryPeriode.Fill(_baPersonID);
            try
            {
                while (!((DateTime)qryPeriode["PeriodeVon"] <= DateTime.Today && (DateTime)qryPeriode["PeriodeBis"] >= DateTime.Today))
                {
                    if (!qryPeriode.Next())
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(ex.Message);
            }
        }

        private void edtKontoBis_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            SetKontoNames();
        }

        private void edtKontoVon_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            SetKontoNames();
        }

        private void edtMandant_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtMandant.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    _baPersonID = -1;
                    edtMandant.EditValue = null;
                    edtBaPersonID.EditValue = null;
                    edtAdresse.EditValue = null;
                    edtMT.EditValue = null;
                    qryPeriode.DataTable.Rows.Clear();
                    qryPeriode.EnableBoundFields(false);
                    return;
                }
            }

            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
              SELECT distinct
                     BaPersonID$      = PRS.BaPersonID,
                     [Personen-Nr.]   = PRS.BaPersonID,
                     Name             = PRS.NameVorname,
                     Geburtsdatum     = PRS.Geburtsdatum,
                     [Alter]          = PRS.[Alter],
                     Adresse          = PRS.Wohnsitz,
                     [Beist. oder Vorm.] = dbo.fnVmGetMTName(PRS.BaPersonID)
              FROM   vwPerson PRS
                     inner join FaLeistung LEI on LEI.BaPersonID = PRS.BaPersonID and
                                                  LEI.FaProzessCode = 500
              WHERE  PRS.NameVorname LIKE '%' + {0} + '%'
              ORDER BY PRS.NameVorname",
              searchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                _baPersonID = (int)dlg["BaPersonID$"];
                edtMandant.EditValue = dlg["Name"];
                edtBaPersonID.EditValue = dlg["BaPersonID$"];
                edtAdresse.EditValue = dlg["Adresse"];
                edtMT.EditValue = dlg["Beist. oder Vorm."];

                DisplayPerioden();
                SetRanges();
            }
        }

        private void FillEdtDrucker()
        {
            string defaultPrinter = null;

            foreach (String printerName in PrinterSettings.InstalledPrinters)
            {
                edtDrucker.Properties.Items.Add(printerName);

                // Retrieve the printer settings.
                var printer = new PrinterSettings();
                printer.PrinterName = printerName;

                if (printer.IsDefaultPrinter)
                {
                    defaultPrinter = printerName;
                }
            }

            if (defaultPrinter != null)
            {
                edtDrucker.SelectedItem = defaultPrinter;
            }
        }

        private void grid_DoubleClick(object sender, EventArgs e)
        {
            gridView1.CalcHitInfo(new Point(0, 0));
        }

        private void gridView1_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            try
            {
                int firstRowHandle = gridView1.GetDataRowHandleByGroupRowHandle(e.RowHandle);
                Brush brushBackGround = new SolidBrush(gridView1.Appearance.GroupRow.BackColor);

                string initialText = gridView1.GetGroupRowDisplayText(e.RowHandle);
                DataRow row = gridView1.GetDataRow(firstRowHandle);
                Brush brushText = Brushes.Black;
                Rectangle textBounds = e.Bounds;
                Rectangle dokTextBounds = e.Bounds;
                var groupRowINfo = e.Info as GridGroupRowInfo;
                textBounds.X = groupRowINfo.ButtonBounds.Right + 4;
                e.Graphics.FillRectangle(brushBackGround, groupRowINfo.DataBounds);

                var painter = e.Painter as DevExpress.XtraGrid.Drawing.GridGroupRowPainter;
                var groupInfo = e.Info as GridGroupRowInfo;
                var openCloseButton = new DevExpress.Utils.Drawing.OpenCloseButtonInfoArgs(e.Cache, groupInfo.ButtonBounds, groupInfo.GroupExpanded, groupInfo.AppearanceGroupButton, DevExpress.Utils.Drawing.ObjectState.Normal);
                painter.ElementsPainter.OpenCloseButton.DrawObject(openCloseButton);

                // kleiner Hack: Laut devexpress kann erst in neueren Versionen auf Viewinfo zugegriffen werden, in älteren soll der Zugriff über Reflection stattfinden
                var gridInfo = typeof(GridView).GetField("fViewInfo", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(gridView1) as GridViewInfo;
                dokTextBounds.X = gridInfo.GetColumnLeftCoord(colDokument);
                dokTextBounds.Width = colDokument.Width;

                var textFormat = new StringFormat();
                textFormat.Alignment = StringAlignment.Center;
                string anzDoc = (row["AnzahlKontoDoc"] as int?).ToString();
                e.Appearance.DrawString(e.Cache, initialText, textBounds, Brushes.Black);
                e.Appearance.DrawString(e.Cache, anzDoc, dokTextBounds, brushText, textFormat);
                e.Handled = true;
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(ex.Message);
            }
        }

        private void gridView1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                var info = gridView1.CalcHitInfo(new Point(e.X, e.Y));
                var isGroupRow = gridView1.IsGroupRow(info.RowHandle);
                int? anzDoks;
                var dokIDs = string.Empty;
                if (isGroupRow)
                {
                    // finde die erste Daten-Zeile, sie enthält die Dokumenten-Angaben
                    var firstRowHandle = gridView1.GetDataRowHandleByGroupRowHandle(info.RowHandle);
                    var row = gridView1.GetDataRow(firstRowHandle);
                    // kleiner Hack um die Spalte in einer Group Row zu finden:
                    info = gridView1.CalcHitInfo(new Point(e.X, grid.Views[0].ViewRect.Y + 5));
                    dokIDs = row["DocIDsKonto"] as string;
                    anzDoks = qryKontoblaetter["AnzahlKontoDoc"] as int?;
                }
                else
                {
                    anzDoks = qryKontoblaetter["AnzahlDoc"] as int?;
                    if (!DBUtil.IsEmpty(qryKontoblaetter["DocIDsBuchung"]))
                        dokIDs += (string)qryKontoblaetter["DocIDsBuchung"];
                    if (!DBUtil.IsEmpty(qryKontoblaetter["DocIDsPosition"]))
                    {
                        dokIDs = dokIDs == string.Empty ? dokIDs : dokIDs + ",";
                        dokIDs += (string)qryKontoblaetter["DocIDsPosition"];
                    }
                }
                qryDocument.Fill(qryDocument.SelectStatement, dokIDs);

                if (info == null || info.Column == null || info.Column.Name != "colDokument" || anzDoks == null || anzDoks == 0)
                {
                    return;
                }

                if (anzDoks == 1)
                {
                    int kgDokumentID;
                    if (int.TryParse(dokIDs, out kgDokumentID))
                    {
                        var docID = (int)DBUtil.ExecuteScalarSQLThrowingException(@"SELECT DocumentID FROM KgDokument WHERE KgDokumentID = {0}", kgDokumentID);
                        edtDokumentHidden.DocumentID = docID;
                        edtDokumentHidden.OpenDoc();
                    }
                }
                else if (anzDoks > 1)
                {
                    var dlg = new KissLookupDialog();
                    bool cancel = !dlg.SearchData(@"
                      SELECT ID$ = DocumentID,
                             Stichwort,
                             Herkunft = LOV.Text
                      FROM   KgDokument DOK
                        LEFT JOIN XLOVCode LOV ON LOV.LOVName = 'KgDokumentTyp' AND LOV.Code = DOK.KgDokumentTypCode
                      WHERE DOK.KgDokumentID IN (SELECT SplitValue FROM dbo.fnSplitStringToValues({0}, ',', 1))
                      ORDER BY Stichtag DESC
                      ",
                        dokIDs,
                        true);

                    edtDokumentHidden.DocumentID = dlg["ID$"];
                    edtDokumentHidden.OpenDoc();
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(ex.Message);
            }
        }

        private bool IsOneDocumentSelected()
        {
            if (qryDocument.IsEmpty)
            {
                return false;
            }

            foreach (DataRow row in qryDocument.DataTable.Rows)
            {
                if (Utils.ConvertToBool(row["Selektion"]))
                {
                    return true;
                }
            }

            return false;
        }

        private void PresetSearchValues()
        {
            SqlQuery qry = DBUtil.OpenSQL(@"
              SELECT Name    = PRS.NameVorname,
                     Adresse = PRS.Wohnsitz,
                     [Beist. oder Vorm.] = dbo.fnVmGetMTName(PRS.BaPersonID)
              FROM   vwPerson PRS
              WHERE  PRS.BaPersonID = {0}",
              _baPersonID);

            edtBaPersonID.EditValue = _baPersonID;
            edtMandant.EditValue = qry["Name"];
            edtAdresse.EditValue = qry["Adresse"];
            edtMT.EditValue = qry["Beist. oder Vorm."];

            if (_baPersonID > 0)
            {
                DisplayPerioden();
            }
            SetRanges();
        }

        private void qryKontoblaetter_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            qryDocument.Fill(qryKontoblaetter["DocIDsPosition"] + "," + qryKontoblaetter["DocIDsBuchung"]);
        }

        private void qryKontoblaetter_PositionChanged(object sender, EventArgs e)
        {
            btnBudgetPosition.Enabled = !DBUtil.IsEmpty(qryKontoblaetter["JumpToMBPfad"]);
        }

        private void qryPeriode_PositionChanged(object sender, EventArgs e)
        {
            if (!_positionRefreshing)
            {
                SetRanges();
            }
        }

        private void RefreshPeriode()
        {
            var kgPeriodeID = qryPeriode["KgPeriodeID"] as int?;
            try
            {
                _positionRefreshing = true;
                qryPeriode.Refresh();
                if (kgPeriodeID.HasValue)
                {
                    // versuche die letzte gewählte Periode wieder zu setzen
                    qryPeriode.Find(string.Format("KgPeriodeID = {0}", kgPeriodeID.Value));
                }
            }
            finally
            {
                _positionRefreshing = false;
            }
        }

        private void SetDokumenteSelection(bool selection)
        {
            qryDocument.CanUpdate = true;
            foreach (DataRow row in qryDocument.DataTable.Rows)
            {
                row["Selektion"] = selection;
                row.AcceptChanges();
            }
            qryDocument.CanUpdate = false;
        }

        private void SetKontoNames()
        {
            edtKontonameVon.Text = DBUtil.ExecuteScalarSQL(@"
                select	KontoName
                from	KgKonto
                where	(KgPeriodeID = {0} OR KgPeriodeID IS NULL AND {0} IS NULL) AND
                        KontoNr = {1}",
                qryPeriode["KgPeriodeID"],
                edtKontoVon.EditValue) as String;

            edtKontonameBis.Text = DBUtil.ExecuteScalarSQL(@"
                select	KontoName
                from	KgKonto
                where	(KgPeriodeID = {0} OR KgPeriodeID IS NULL AND {0} IS NULL) AND
                        KontoNr = {1}",
                qryPeriode["KgPeriodeID"],
                edtKontoBis.EditValue) as string;
        }

        private void SetRanges()
        {
            if (qryPeriode.Count == 0) return;

            edtDatumVon.DateTime = (DateTime)qryPeriode["PeriodeVon"];
            edtDatumBis.DateTime = (DateTime)qryPeriode["PeriodeBis"];

            edtKontoVon.EditValue = qryPeriode["MinKontoNr"];
            edtKontoBis.EditValue = qryPeriode["MaxKontoNr"];
            SetKontoNames();
        }

        private void tabControlSearch_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            if (page == tpgSuchen)
            {
                RefreshPeriode();
            }
        }
    }
}