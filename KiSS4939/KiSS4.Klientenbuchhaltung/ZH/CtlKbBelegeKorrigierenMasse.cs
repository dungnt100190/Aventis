using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Messages;

namespace KiSS4.Klientenbuchhaltung.ZH
{
    public partial class CtlKbBelegeKorrigierenMasse : KissSearchUserControl
    {
        private const string CLASSNAME = "CtlKbBelegeKorrigierenMasse";

        private readonly List<string> _editableColumnNames = new List<string>
        {
            GridColNames.VerwPeriodeVon,
            GridColNames.VerwPeriodeBis,
            GridColNames.LA,
            GridColNames.Buchungstext,
            GridColNames.Klient,
            GridColNames.Valuta
        };

        private BelegeKorrigierenHelper _belegeKorrigierenHelper;
        private int _selectedRowCount;
        private bool _userHasMRight;

        public CtlKbBelegeKorrigierenMasse()
        {
            InitializeComponent();

            //Nach ValutaDatum darf nicht sortiert werden, da beim editierbar machen das ValutaDatum auf das aktuelle Datum gesetzt wird.
            //Würde nach ValutaDatum sortiert, springt der soeben editierbar gemachte Datensatz an den Anfang oder das Ende der Liste.
            //Deshalb explizit AllowSort auf false gesetzt.
            colValuta.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

            AutoPost = false;
            AutoRefresh = false;
        }

        private bool IsCurrentCellEditable
        {
            get { return IsCellEditable(grvKbBelegeKorrigierenMasse.FocusedRowHandle, grvKbBelegeKorrigierenMasse.FocusedColumn.Name); }
        }

        private string LeistungsartenList
        {
            get { return string.Join(",", edtLeistungsarten.GetSelectedHiddenCol("KontoNr")); }
        }

        public override bool BeforeCloseView()
        {
            //Called before to Close this View

            //Not editing any rows
            if (_selectedRowCount < 1 || tabControlSearch.SelectedTabIndex != TabControlSearchSelectedTabIndex.Liste)
            {
                return true;
            }

            //Row Changed, then ask user
            if (KissMsg.ShowQuestion(
                CLASSNAME,
                "MaskeVerlassenFragen",
                "Wollen Sie diese Maske wirklich verlassen? Bereits erfasste Umbuchungen werden verloren."))
            {
                UnlockCloseFromFrame();
                return true;
            }

            return false;
        }

        public override void OnRefreshData()
        {
            //Nichts machen weil neues Suchen durch Tabwechesln muss gemacht werden
        }

        public override void OnSearch()
        {
            if (tabControlSearch.SelectedTabIndex == TabControlSearchSelectedTabIndex.Liste)
            {
                tabControlSearch.SelectedTabIndex = TabControlSearchSelectedTabIndex.Suche;
                OnNewSearch();
            }
            else
            {
                tabControlSearch.SelectedTabIndex = TabControlSearchSelectedTabIndex.Liste;
            }
        }

        public override void OnUndoDataChanges()
        {
            //Nichts machen weil die Daten sind nicht durch diese Methode rückgängig gemacht
        }

        protected override void RunSearch()
        {
            //Check Form
            if (DBUtil.IsEmpty(edtSucheFallNr.EditValue) && DBUtil.IsEmpty(edtSucheLeistungstraeger.LookupID))
            {
                KissMsg.ShowInfo(CLASSNAME, "MinimalesSuchkriterium", "Bitte als minimales Suchkriterium entweder Fallnummer oder Leistungsträger/in eingeben.");
                throw new KissCancelException();
            }

            base.RunSearch();

            FillMainQuery();
        }

        /// <summary>
        /// Selects all rows.
        /// </summary>
        private void btnAlle_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in qryKbBelegKorrekturMasse.DataTable.Rows)
            {
                if (!(bool)row[GridFieldNames.Auswahl])
                {
                    row[GridFieldNames.Auswahl] = true;

                    UpdateGridSelection(row, true);
                }
            }

            UpdateSelectionInfo();

            PreventCloseFromFrame();
        }

        private void btnAusfuehren_Click(object sender, EventArgs e)
        {
            if (!ValidateSelectedRows())
            {
                return;
            }

            DlgProgressLog.Show("Beleg stornieren", false, 700, 500, ProgressStart, ProgressEnd, Session.MainForm);

            UpdateSelectionInfo();
            UpdateSelectedRowCount();
        }

        /// <summary>
        /// Deselects all rows.
        /// </summary>
        private void btnKeine_Click(object sender, EventArgs e)
        {
            if (!KissMsg.ShowQuestion(CLASSNAME, "AenderungenRueckgaengig", "Änderungen rückgängig machen?"))
            {
                return;
            }

            foreach (DataRow row in qryKbBelegKorrekturMasse.DataTable.Rows)
            {
                if ((bool)row[GridFieldNames.Auswahl])
                {
                    row[GridFieldNames.Auswahl] = false;

                    UpdateGridSelection(row, false);
                }
            }

            UpdateSelectionInfo();

            colFehlermeldung.Visible = false;

            UnlockCloseFromFrame();
        }

        private void btnNeuWerteSetzen_Click(object sender, EventArgs e)
        {
            var selectedRows = qryKbBelegKorrekturMasse.DataTable.Rows.Cast<DataRow>().Where(x => Utils.ConvertToBool(x[GridFieldNames.Auswahl])).ToList();

            if (selectedRows.Count <= 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeineEintraegeGewaehlt", "Wählen Sie zuerst einen Eintrag.");
                return;
            }

            using (var dlg = new DlgKbBelegeKorrigierenNeueWerte(selectedRows))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var resultRow = dlg.ResultRow;

                    foreach (var row in selectedRows)
                    {
                        SetRowValueIfNotEmpty(row, GridFieldNames.BaPersonID_LT, resultRow[DlgKbBelegeKorrigierenNeueWerte.ResultFieldNames.LTBaPersonID]);
                        SetRowValueIfNotEmpty(row, GridFieldNames.BgFinanzplanID, resultRow[GridFieldNames.BgFinanzplanID]);
                        SetRowValueIfNotEmpty(row, GridFieldNames.Buchungstext, resultRow[GridFieldNames.Buchungstext]);
                        SetRowValueIfNotEmpty(row, GridFieldNames.FaFallID, resultRow[GridFieldNames.FaFallID]);
                        SetRowValueIfNotEmpty(row, GridFieldNames.FaLeistungID, resultRow[GridFieldNames.FaLeistungID]);
                        SetRowValueIfNotEmpty(row, GridFieldNames.Valuta, resultRow[GridFieldNames.Valuta]);
                        SetRowValueIfNotEmpty(row, GridFieldNames.VerwPeriodeBis, resultRow[GridFieldNames.VerwPeriodeBis]);
                        SetRowValueIfNotEmpty(row, GridFieldNames.VerwPeriodeVon, resultRow[GridFieldNames.VerwPeriodeVon]);
                        SetRowValueIfNotEmpty(row, GridFieldNames.StornoCode, resultRow[DlgKbBelegeKorrigierenNeueWerte.ResultFieldNames.Storno]);

                        if (SetRowValueIfNotEmpty(row, GridFieldNames.BetrifftBaPersonID, resultRow[DlgKbBelegeKorrigierenNeueWerte.ResultFieldNames.BetrifftBaPersonID]))
                        {
                            row[GridFieldNames.Klient] = GetKlientText((int)resultRow[DlgKbBelegeKorrigierenNeueWerte.ResultFieldNames.BetrifftBaPersonID]);
                        }

                        if (SetRowValueIfNotEmpty(row, GridFieldNames.KlientBaPersonIDList, resultRow[GridFieldNames.KlientBaPersonIDList]))
                        {
                            row[GridFieldNames.Klient] = GetKlientText(true, (int)resultRow[GridFieldNames.BgFinanzplanID], (string)resultRow[GridFieldNames.KlientBaPersonIDList]);
                        }

                        if (SetRowValueIfNotEmpty(row, GridFieldNames.BgKostenartID, resultRow[GridFieldNames.BgKostenartID]))
                        {
                            row[GridFieldNames.BgKostenartID] = resultRow[GridFieldNames.BgKostenartID];
                            row[GridFieldNames.KontoNr] = resultRow[DlgKbBelegeKorrigierenNeueWerte.ResultFieldNames.KontoNr];
                            row[GridFieldNames.BgKostenart] = resultRow[GridFieldNames.BgKostenart];
                            row[GridFieldNames.Hauptvorgang] = resultRow[GridFieldNames.Hauptvorgang];
                            row[GridFieldNames.Teilvorgang] = resultRow[GridFieldNames.Teilvorgang];
                            row[GridFieldNames.BgKostenartHauptvorgang] = resultRow[GridFieldNames.BgKostenartHauptvorgang];
                            row[GridFieldNames.BgKostenartTeilvorgang] = resultRow[GridFieldNames.BgKostenartTeilvorgang];
                            row[GridFieldNames.BgKostenartHauptvorgangAbtretung] = resultRow[GridFieldNames.BgKostenartHauptvorgangAbtretung];
                            row[GridFieldNames.BgKostenartTeilvorgangAbtretung] = resultRow[GridFieldNames.BgKostenartTeilvorgangAbtretung];
                            row[GridFieldNames.Belegart] = resultRow[GridFieldNames.Belegart];
                            row[GridFieldNames.SplittingArtCode] = resultRow[GridFieldNames.SplittingArtCode];
                            row[GridFieldNames.Weiterverrechenbar] = resultRow[GridFieldNames.Weiterverrechenbar];
                            row[GridFieldNames.Quoting] = resultRow[GridFieldNames.Quoting];
                            row[GridFieldNames.SplittingArt] = resultRow[DlgKbBelegeKorrigierenNeueWerte.ResultFieldNames.SplittingArt];
                        }

                        if (SetRowValueIfNotEmpty(row, GridFieldNames.SelectedHaushaltDatumVon, resultRow[GridFieldNames.SelectedHaushaltDatumVon]))
                        {
                            row[GridFieldNames.SelectedHaushaltProleistPersonenIDs] = resultRow[GridFieldNames.SelectedHaushaltProleistPersonenIDs];
                            row[GridFieldNames.SelectedHaushaltDatumBis] = resultRow[GridFieldNames.SelectedHaushaltDatumBis];
                        }
                    }
                }
            }
        }

        private void btnUmbuchungsjournal_Click(object sender, EventArgs e)
        {
            //Absprung auf Datenexplorer-Abfrage: QU - W - Umbuchungsjournal
            System.Collections.Specialized.HybridDictionary param = new System.Collections.Specialized.HybridDictionary();
            param.Add("Action", "ShowQueryItem");
            param.Add("ClassName", "CtlQueryWhUmbuchungsjournal");

            FormController.OpenForm("FrmDataExplorer", param);
        }

        private void ClearDataSource()
        {
            grdKbBelegeKorrigierenMasse.DataSource = null;
            _selectedRowCount = 0;
        }

        private void ClearSelectionInfo()
        {
            lblSelectInfo.Text = string.Empty;
        }

        private void CtlKbBelegeKorrigierenMasse_Load(object sender, EventArgs e)
        {
            edtSucheFallNr.Focus();
            SetupFieldName();

            _belegeKorrigierenHelper = new BelegeKorrigierenHelper(
                this,
                qryKbBelegKorrekturMasse,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                true);

            var qryLeistungsarten = @"
                SELECT
                  KontoNr,
                  Name = ISNULL(KontoNr + ' ', '') + Name
                FROM dbo.BgKostenart WITH(READUNCOMMITTED)
                ORDER BY KontoNr;";
            edtLeistungsarten.Initialize(qryLeistungsarten, "Name", "Verfügbare Leistungsarten", "Zugeteilte Leistungsarten");

            var qryLaGridEdit = DBUtil.OpenSQL(@"
                SELECT
                  BgKostenartID,
                  KontoNr,
                  Name,
                  Quoting,
                  KontoNrName           = KontoNr + ' ' + Name,
                  Hauptvorgang          = Hauptvorgang,
                  Teilvorgang           = Teilvorgang,
                  HauptvorgangAbtretung = HauptvorgangAbtretung,
                  TeilvorgangAbtretung  = TeilvorgangAbtretung,
                  Belegart              = Belegart,
                  BgSplittingArtCode    = BgSplittingArtCode,
                  SplittingArt          = dbo.fnLOVMLShortText('BgSplittingArt', BgSplittingArtCode, 1),
                  Weiterverrechenbar    = Weiterverrechenbar
                FROM dbo.BgKostenart WITH(READUNCOMMITTED)
                ORDER BY KontoNr;");
            grideditLA.DataSource = qryLaGridEdit;
            grideditLA.EditValueChanged += grideditLA_EditValueChanged;

            KbBuchungStatusHelper.AddBuchungStatusToRepositoryItems(new List<RepositoryItemImageComboBox> { grideditStatus });

            //sicherstellen, dass Suche-Register selektiert ist, unabhängig vom Designer-Code
            tabControlSearch.SelectedTabIndex = TabControlSearchSelectedTabIndex.Suche;

            _userHasMRight = DBUtil.UserHasRight(this.Name, "U");
            colAuswahl.Visible = _userHasMRight;
        }

        private void edtSucheFallNr_LostFocus(object sender, EventArgs e)
        {
            if (edtSucheFallNr.UserModified)
            {
                LoadKlientSucheQuery();
                edtSucheFallNr.UserModified = false;
            }
        }

        private void edtSucheLeistungstraeger_LookupIDChanged(object sender, EventArgs e)
        {
            LoadKlientSucheQuery();
        }

        private void edtSucheLeistungstraeger_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtSucheLeistungstraeger.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    edtSucheLeistungstraeger.EditValue = DBNull.Value;
                    edtSucheLeistungstraeger.LookupID = DBNull.Value;
                    return;
                }
            }

            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                SELECT
                  ID           = PRS.BaPersonID,
                  PRS.DisplayText,
                  BaPersonID$  = PRS.BaPersonID,
                  NameVorname$ = PRS.NameVorname
                FROM dbo.vwPerson PRS
                WHERE (PRS.NameVorname LIKE '%' + {0} + '%' OR CAST(PRS.BaPersonID AS VARCHAR) = {0})
                  AND EXISTS (SELECT BaPersonID
                              FROM dbo.FaLeistung           LEI
                                INNER JOIN dbo.BgFinanzplan BFP ON BFP.FaLeistungID = LEI.FaLeistungID
                              WHERE BaPersonID = PRS.BaPersonID
                                AND FaProzessCode = 300)
                ORDER BY PRS.Name, PRS.Vorname;",
                searchString,
                e.ButtonClicked);

            if (!e.Cancel)
            {
                edtSucheLeistungstraeger.EditValue = dlg["NameVorname$"];
                edtSucheLeistungstraeger.LookupID = dlg["BaPersonID$"];
            }
        }

        private void EnableDisableButtons(bool enabled)
        {
            //sicherstellen, dass Buttons nur aktiviert werden, wenn der Benutzer das M-Recht hat
            enabled &= _userHasMRight;

            btnAlle.Enabled = enabled;
            btnKeine.Enabled = enabled;
            btnAusfuehren.Enabled = enabled;
            btnNeuWerteSetzen.Enabled = enabled;

            //Absprung auf Umbuchungsjournal ist immer erlaubt
            //btnUmbuchungsjournal.Enabled = true;
        }

        private void FillMainQuery()
        {
            ClearDataSource();

            //Fill List
            qryKbBelegKorrekturMasse.Fill(
                "EXEC dbo.spKbBelegKorrigierenMasse {0}, {1}, {2}, {3}, {4}, {5};",
                edtSucheFallNr.EditValue,
                edtSucheLeistungstraeger.LookupID,
                edtSuchKlient.EditValue,
                edtSucheVerwDatumVon.EditValue,
                edtSucheVerwDatumBis.EditValue,
                LeistungsartenList);

            grdKbBelegeKorrigierenMasse.DataSource = qryKbBelegKorrekturMasse;
        }

        private int FindNextFocusableRow(int rowHandle)
        {
            var count = grvKbBelegeKorrigierenMasse.DataRowCount;

            for (int i = 0; i < count; i++)
            {
                rowHandle++;

                if (rowHandle == grvKbBelegeKorrigierenMasse.DataRowCount)
                {
                    rowHandle = 0;
                }

                if ((bool)grvKbBelegeKorrigierenMasse.GetRowCellValue(rowHandle, grvKbBelegeKorrigierenMasse.Columns[GridFieldNames.Auswahl]))
                {
                    return rowHandle;
                }
            }

            // no row found
            return -1;
        }

        private int FindPreviousFocusableRow(int rowHandle)
        {
            var count = grvKbBelegeKorrigierenMasse.DataRowCount;

            for (int i = 0; i < count; i++)
            {
                rowHandle--;

                // are we at the top of the table?
                if (rowHandle < 0)
                {
                    rowHandle = grvKbBelegeKorrigierenMasse.DataRowCount - 1;
                }

                if ((bool)grvKbBelegeKorrigierenMasse.GetRowCellValue(rowHandle, grvKbBelegeKorrigierenMasse.Columns[GridFieldNames.Auswahl]))
                {
                    return rowHandle;
                }
            }

            // no row found
            return -1;
        }

        private DataRow GetBgKostenartRow(int bgKostenartId)
        {
            var isFound = ((SqlQuery)grideditLA.DataSource).Find(String.Format("BgKostenartID = {0}", Convert.ToString(bgKostenartId)));
            return isFound ? ((SqlQuery)grideditLA.DataSource).Row : null;
        }

        private string GetKlientText(bool quoting, int bgFinanzplanId = 0, string personBaPersonIDList = "")
        {
            if (quoting)
            {
                if (bgFinanzplanId > 0)
                {
                    SqlQuery qry = DBUtil.OpenSQL(string.Format(@"
                                SELECT KlientBaPersonCount = COUNT(BaPersonID), BaPersonIDMax = MAX(BaPersonID)
                                FROM dbo.BgFinanzplan_BaPerson WITH(READUNCOMMITTED)
                                WHERE BgFinanzplanid = {0}
                                AND IstUnterstuetzt = 1;", bgFinanzplanId));

                    if (qry.HasRow)
                    {
                        int nbPerson = (int)qry["KlientBaPersonCount"];

                        if (nbPerson > 1)
                        {
                            return string.Format("ganze UE ({0})", qry["KlientBaPersonCount"]);
                        }

                        if (nbPerson == 1)
                        {
                            return GetKlientText((int)qry["BaPersonIDMax"]);
                        }

                        return string.Empty;
                    }
                }
                else
                {
                    //bgFinanzplanId<=0
                    return GetKlientText(personBaPersonIDList);
                }
            }

            return string.Empty;
        }

        private string GetKlientText(int baPersonID)
        {
            var qryPerson = DBUtil.OpenSQL(@"
                SELECT DisplayText
                FROM dbo.vwPerson2
                WHERE BaPersonID = {0};", baPersonID);

            if (qryPerson.HasRow)
            {
                return (string)qryPerson["DisplayText"];
            }
            return string.Empty;
        }

        private string GetKlientText(string personBaPersonIDList)
        {
            int nbPerson = personBaPersonIDList.Split(',').Count();

            if (nbPerson > 1)
            {
                return string.Format("ganze UE ({0})", nbPerson);
            }

            if (!string.IsNullOrEmpty(personBaPersonIDList))
            {
                int baPersonID;
                if (int.TryParse(personBaPersonIDList, out baPersonID))
                {
                    return GetKlientText(baPersonID);
                }
            }

            return string.Empty;
        }

        private void grdKbBelegeKorrigierenMasse_ProcessGridKey(object sender, KeyEventArgs e)
        {
            var grid = grvKbBelegeKorrigierenMasse;
            if (!e.Shift && e.KeyCode == Keys.Tab
                || e.KeyCode == Keys.Right)
            {
                //try to move focus forward:

                //do we need to select next editable row?
                bool currentRowNotEditable = !(bool)grid.GetRowCellValue(grid.FocusedRowHandle, colAuswahl);
                if (_selectedRowCount > 0 && currentRowNotEditable
                    || grid.FocusedColumn == colAuswahl && _selectedRowCount > 1)
                {
                    //search next focusable row
                    var rowHandle = FindNextFocusableRow(grid.FocusedRowHandle);
                    if (rowHandle != -1)
                    {
                        grid.FocusedRowHandle = rowHandle;
                        grid.FocusedColumn = colVerwPeriodeVon;
                        e.Handled = true;
                    }
                }
            }
            else if (e.Shift && e.KeyCode == Keys.Tab
                     || e.KeyCode == Keys.Left)
            {
                //try to move focus backwards

                //do we need to select previous editable row?
                bool currentRowNotEditable = !(bool)grid.GetRowCellValue(grid.FocusedRowHandle, colAuswahl);
                if (_selectedRowCount > 0 && currentRowNotEditable
                    || grid.FocusedColumn == colVerwPeriodeVon && _selectedRowCount > 1)
                {
                    //search previous focusable row
                    var rowHandle = FindPreviousFocusableRow(grid.FocusedRowHandle);
                    if (rowHandle != -1)
                    {
                        grid.FocusedRowHandle = rowHandle;
                        grid.FocusedColumn = colAuswahl;
                        e.Handled = true;
                    }
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                //search next focusable row
                var rowHandle = FindNextFocusableRow(grid.FocusedRowHandle);
                if (rowHandle != -1)
                {
                    grid.FocusedRowHandle = rowHandle;
                    e.Handled = true;
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                //search previous focusable row
                var rowHandle = FindPreviousFocusableRow(grid.FocusedRowHandle);
                if (rowHandle != -1)
                {
                    grid.FocusedRowHandle = rowHandle;
                    e.Handled = true;
                }
            }
        }

        private void grideditLA_EditValueChanged(object sender, EventArgs args)
        {
            //LeistungArt Changing
            var bgkostenartId = (int)((LookUpEdit)sender).EditValue;
            SetBgKostenartValues(bgkostenartId);
            grvKbBelegeKorrigierenMasse.RefreshRow(grvKbBelegeKorrigierenMasse.FocusedRowHandle);
        }

        private void gridedtAuswahl_CheckedChanged(object sender, EventArgs e)
        {
            grvKbBelegeKorrigierenMasse.PostEditor();
            grvKbBelegeKorrigierenMasse.LayoutChanged();
        }

        private void gridedtKlient_ButtonEdit(object sender, ButtonPressedEventArgs e)
        {
            var quotingCurrent = qryKbBelegKorrekturMasse[GridFieldNames.Quoting] as bool? ?? false;

            if (quotingCurrent)
            {
                //Quoting Current==true

                //Haushaltliste anzeigen
                var selectedHaushaltRow = BelegeKorrigierenHelper.ShowHaushaltDialog(
                    Utils.ConvertToInt(qryKbBelegKorrekturMasse[GridFieldNames.FaFallID]),
                    Utils.ConvertToInt(qryKbBelegKorrekturMasse[GridFieldNames.BaPersonID_LT]),
                    Utils.ConvertToInt(qryKbBelegKorrekturMasse[GridFieldNames.BgFinanzplanID]));

                if (selectedHaushaltRow != null)
                {
                    //Update Data
                    qryKbBelegKorrekturMasse[GridFieldNames.BgFinanzplanID] = selectedHaushaltRow["BgFinanzplanID$"];
                    qryKbBelegKorrekturMasse[GridFieldNames.FaLeistungID] = selectedHaushaltRow["FaLeistungID"];
                    qryKbBelegKorrekturMasse[GridFieldNames.FaFallID] = selectedHaushaltRow["FaFallID"];
                    qryKbBelegKorrekturMasse[GridFieldNames.Klient] = GetKlientText(true, (int)selectedHaushaltRow["BgFinanzplanID$"], (string)selectedHaushaltRow["PersonenIDs$"]);
                    qryKbBelegKorrekturMasse[GridFieldNames.KlientBaPersonIDList] = selectedHaushaltRow["PersonenIDs$"];
                    qryKbBelegKorrekturMasse[GridFieldNames.BetrifftBaPersonID] = DBNull.Value;
                }
                else
                {
                    //Abbruch oder Daten ungültig
                    //Get original Quoting
                    var quotingOld = qryKbBelegKorrekturMasse[GridFieldNames.Quoting, DataRowVersion.Original] as bool? ?? false;

                    if (quotingOld)
                    {
                        //CurrentQuoting==OriginalQuoting
                        //Reload Original Data
                        qryKbBelegKorrekturMasse[GridFieldNames.BgFinanzplanID] = qryKbBelegKorrekturMasse[GridFieldNames.BgFinanzplanID, DataRowVersion.Original];
                        qryKbBelegKorrekturMasse[GridFieldNames.FaLeistungID] = qryKbBelegKorrekturMasse[GridFieldNames.FaLeistungID, DataRowVersion.Original];
                        qryKbBelegKorrekturMasse[GridFieldNames.FaFallID] = qryKbBelegKorrekturMasse[GridFieldNames.FaFallID, DataRowVersion.Original];
                        qryKbBelegKorrekturMasse[GridFieldNames.Klient] = qryKbBelegKorrekturMasse[GridFieldNames.Klient, DataRowVersion.Original];
                        qryKbBelegKorrekturMasse[GridFieldNames.KlientBaPersonIDList] = qryKbBelegKorrekturMasse[GridFieldNames.KlientBaPersonIDList, DataRowVersion.Original];
                        qryKbBelegKorrekturMasse[GridFieldNames.BetrifftBaPersonID] = qryKbBelegKorrekturMasse[GridFieldNames.BetrifftBaPersonID, DataRowVersion.Original];
                    }
                    else
                    {
                        //CurrentQuoting!=OriginalQuoting
                        //Alten Daten dürfen wir in diesem Fall nicht laden, sonst ist das Combi LA-Klient falsch
                        //Set Null Value
                        qryKbBelegKorrekturMasse[GridFieldNames.Klient] = DBNull.Value;
                        qryKbBelegKorrekturMasse[GridFieldNames.KlientBaPersonIDList] = DBNull.Value;
                        qryKbBelegKorrekturMasse[GridFieldNames.BetrifftBaPersonID] = DBNull.Value;
                    }
                }
            }
            else
            {
                //Quoting=false
                //Liste der möglichen BaPerson anzeigen
                object baPersonID = qryKbBelegKorrekturMasse[GridFieldNames.BetrifftBaPersonID];
                object klient = qryKbBelegKorrekturMasse[GridFieldNames.Klient];
                bool isSiLei = (bool)qryKbBelegKorrekturMasse[GridFieldNames.IsSiLei];

                //preprare searchString (nur für SiLei, sont zeigen wir nur die Mitglieder des Haushalts
                string searchString = string.Empty;
                if (isSiLei)
                {
                    searchString = Convert.ToString(((ButtonEdit)sender).EditValue).Replace("*", "%").Replace("?", "_").Replace(" ", "%");
                }

                bool personGefunden = BelegeKorrigierenHelper.ShowBetrifftPersonDialog(
                    isSiLei,
                    qryKbBelegKorrekturMasse[GridFieldNames.BaPersonID_LT],
                    searchString,
                    true,
                    false,
                    ref klient,
                    ref baPersonID);

                if (personGefunden)
                {
                    //Set new Data
                    qryKbBelegKorrekturMasse[GridFieldNames.BetrifftBaPersonID] = baPersonID;
                    qryKbBelegKorrekturMasse[GridFieldNames.Klient] = klient;
                    qryKbBelegKorrekturMasse[GridFieldNames.KlientBaPersonIDList] = DBNull.Value;
                }
                else
                {
                    //Abbruch oder Daten ungültig
                    //Get original Quoting
                    var quotingOriginal = qryKbBelegKorrekturMasse[GridFieldNames.Quoting, DataRowVersion.Original] as bool? ?? false;

                    if (!quotingOriginal)
                    {
                        //CurrentQuoting==OriginalQuoting
                        //Reload Original Data
                        qryKbBelegKorrekturMasse[GridFieldNames.BetrifftBaPersonID] = qryKbBelegKorrekturMasse[GridFieldNames.BetrifftBaPersonID, DataRowVersion.Original];
                        qryKbBelegKorrekturMasse[GridFieldNames.Klient] = qryKbBelegKorrekturMasse[GridFieldNames.Klient, DataRowVersion.Original];
                        qryKbBelegKorrekturMasse[GridFieldNames.KlientBaPersonIDList] = qryKbBelegKorrekturMasse[GridFieldNames.KlientBaPersonIDList, DataRowVersion.Original];
                    }
                    else
                    {
                        //CurrentQuoting!=OriginalQuoting
                        //Alten Daten dürfen wir in diesem Fall nicht laden, sonst ist das Combi LA-Klient falsch
                        //Set Null Value
                        qryKbBelegKorrekturMasse[GridFieldNames.BetrifftBaPersonID] = DBNull.Value;
                        qryKbBelegKorrekturMasse[GridFieldNames.Klient] = DBNull.Value;
                        qryKbBelegKorrekturMasse[GridFieldNames.KlientBaPersonIDList] = DBNull.Value;
                    }
                }
            }

            //RefreshRow
            grvKbBelegeKorrigierenMasse.RefreshRow(grvKbBelegeKorrigierenMasse.FocusedRowHandle);
        }

        private void grvKbBelegeKorrigierenMasse_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var gridView = ((GridView)sender);

            if (e.Column.Name == GridColNames.Auswahl)
            {
                if ((int)qryKbBelegKorrekturMasse[GridFieldNames.KbBuchungStatusCode] == 8)
                {
                    KissMsg.ShowInfo(CLASSNAME, "BereitsUmgebucht", "Diese Buchung wurde bereits umgebucht");
                }
                else
                {
                    var dataRow = grvKbBelegeKorrigierenMasse.GetDataRow(e.RowHandle);
                    UpdateGridSelection(dataRow, (bool)e.Value);
                    UpdateSelectionOnOtherDetailBuchungen(e.RowHandle, dataRow["KbBuchungBruttoID"] as int? ?? -1, (bool)e.Value);
                    UpdateSelectionInfo(e.RowHandle, (bool)e.Value);
                    gridView.RefreshRow(e.RowHandle);

                    PreventCloseFromFrame();
                }
            }
            else if (e.Column.Name == GridColNames.LA)
            {
                //LeistungArt Changing
                if (qryKbBelegKorrekturMasse[GridFieldNames.BgKostenartID] != e.Value)
                {
                    var bgkostenartId = (int)e.Value;
                    SetBgKostenartValues(bgkostenartId);
                    gridView.RefreshRow(e.RowHandle);
                }
            }
        }

        private void grvKbBelegeKorrigierenMasse_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (IsCellEditable(e.RowHandle, e.Column.Name))
            {
                e.Appearance.BackColor = Color.White;

                //If Fehlermeldung? -> Backcolor=Red
                string cellValueFehlermeldung = grvKbBelegeKorrigierenMasse.GetRowCellValue(e.RowHandle, GridFieldNames.Fehlermeldung).ToString();

                if (!string.IsNullOrEmpty(cellValueFehlermeldung))
                {
                    e.Appearance.BackColor = Color.Red;
                }
            }
        }

        private void grvKbBelegeKorrigierenMasse_ShowingEditor(object sender, CancelEventArgs e)
        {
            var myGrid = (GridView)sender;
            //prevent editing
            if (!IsCurrentCellEditable && myGrid.FocusedColumn.Name != GridColNames.Auswahl)
            {
                e.Cancel = true;
            }
        }

        private bool IsCellEditable(int rowHandle, string columnName)
        {
            var auswahl = grvKbBelegeKorrigierenMasse.GetRowCellValue(rowHandle, GridFieldNames.Auswahl) as bool?;
            var isColumnEditable = _editableColumnNames.Contains(columnName);
            return auswahl.HasValue && auswahl.Value && isColumnEditable;
        }

        private void LoadKlientSucheQuery()
        {
            edtSuchKlient.LoadQuery(DBUtil.OpenSQL(@"
                DECLARE @BaPersonID INT;
                DECLARE @FaFallID INT;

                SET @BaPersonID = {0}
                SET @FaFallID = {1}

                IF ((@BaPersonID IS NOT NULL) OR (@FaFallID IS NOT NULL))
                BEGIN
                  SELECT DISTINCT
                    BaPersonID = PRS.BaPersonID,
                    [Text]     = PRS.DisplayText
                  FROM BgFinanzplan_BaPerson    BFB WITH (READUNCOMMITTED)
                    INNER JOIN vwPerson         PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = BFB.BaPersonID
                    INNER JOIN BgFinanzplan     BFP WITH (READUNCOMMITTED) ON BFP.BgFinanzplanID = BFB.BgFinanzplanID
                    INNER JOIN FaLeistung       FLE WITH (READUNCOMMITTED) ON FLE.FaLeistungID = BFP.FaLeistungID
                    INNER JOIN FaFall           FAL WITH (READUNCOMMITTED) ON FAL.FaFallID = FLE.FaFallID
                  WHERE 1=1
                    AND FAL.BaPersonID = ISNULL(@BaPersonID, FAL.BaPersonID)
                    AND FAL.FaFallID = ISNULL(@FaFallID, FAL.FaFallID)
                    AND BFB.IstUnterstuetzt = 1

                  UNION ALL
                  SELECT BaPersonID =  NULL,
                         [Text]     = NULL
                  ORDER BY 2;
                END
                ELSE
                BEGIN
                  SELECT BaPersonID =  NULL,
                         [Text]     = NULL
                END;",
                edtSucheLeistungstraeger.LookupID,
                edtSucheFallNr.EditValue));
        }

        /// <summary>
        /// Lock CloseForm from Frame
        /// Achtung : sicherstellen dass es wieder unlock wird, sonst kann den Benutzer das Fenster nicht mehr schliessen
        /// </summary>
        private void LockCloseFromFrame()
        {
            var myMainForm = GetKissMainForm();
            var myFrame = myMainForm.GetChildForm(typeof(FrmKbPSCDSchnittstelle));

            //Must be locked only one time
            if (!myFrame.IsClosingLocked)
            {
                myFrame.LockCloseForm();
            }
        }

        /// <summary>
        /// PreventCloseFromFrame : Verhindern dass der Benutzer das Fenster schliessen kann
        /// </summary>
        private void PreventCloseFromFrame()
        {
            //Prevent Close from From
            if (_selectedRowCount > 0)
            {
                LockCloseFromFrame();
            }
            else
            {
                UnlockCloseFromFrame();
            }
        }

        private void ProgressEnd()
        {
            if (_belegeKorrigierenHelper.UpdateWasSuccessfull)
            {
                qryKbBelegKorrekturMasse.Refresh();
            }
        }

        private void ProgressStart()
        {
            _belegeKorrigierenHelper.ProgressStart();
        }

        private void SetBgKostenartValues(int bgkostenartId)
        {
            var kostenartRow = GetBgKostenartRow(bgkostenartId);

            qryKbBelegKorrekturMasse[GridFieldNames.BgKostenartID] = bgkostenartId;
            qryKbBelegKorrekturMasse[GridFieldNames.KontoNr] = kostenartRow["KontoNr"];
            qryKbBelegKorrekturMasse[GridFieldNames.BgKostenart] = kostenartRow["KontoNrName"];
            var abgetreten = qryKbBelegKorrekturMasse[GridFieldNames.Abgetreten] as bool? ?? false;
            if (abgetreten)
            {
                qryKbBelegKorrekturMasse[GridFieldNames.Hauptvorgang] = kostenartRow["HauptvorgangAbtretung"];
                qryKbBelegKorrekturMasse[GridFieldNames.Teilvorgang] = kostenartRow["TeilvorgangAbtretung"];
            }
            else
            {
                qryKbBelegKorrekturMasse[GridFieldNames.Hauptvorgang] = kostenartRow["Hauptvorgang"];
                qryKbBelegKorrekturMasse[GridFieldNames.Teilvorgang] = kostenartRow["Teilvorgang"];
            }

            qryKbBelegKorrekturMasse[GridFieldNames.BgKostenartHauptvorgang] = kostenartRow["Hauptvorgang"];
            qryKbBelegKorrekturMasse[GridFieldNames.BgKostenartTeilvorgang] = kostenartRow["Teilvorgang"];
            qryKbBelegKorrekturMasse[GridFieldNames.BgKostenartHauptvorgangAbtretung] = kostenartRow["HauptvorgangAbtretung"];
            qryKbBelegKorrekturMasse[GridFieldNames.BgKostenartTeilvorgangAbtretung] = kostenartRow["TeilvorgangAbtretung"];
            qryKbBelegKorrekturMasse[GridFieldNames.Belegart] = kostenartRow["Belegart"];
            qryKbBelegKorrekturMasse[GridFieldNames.SplittingArtCode] = kostenartRow["BgSplittingArtCode"];
            qryKbBelegKorrekturMasse[GridFieldNames.Weiterverrechenbar] = kostenartRow["Weiterverrechenbar"];
            var quotingOld = qryKbBelegKorrekturMasse[GridFieldNames.Quoting] as bool? ?? false;
            qryKbBelegKorrekturMasse[GridFieldNames.Quoting] = kostenartRow["Quoting"];
            qryKbBelegKorrekturMasse[GridFieldNames.SplittingArt] = kostenartRow["SplittingArt"];
            var splittingart = qryKbBelegKorrekturMasse[GridFieldNames.SplittingArtCode] as int?;
            var splittingartOriginal = qryKbBelegKorrekturMasse[GridFieldNames.SplittingArtCode, DataRowVersion.Original] as int?;
            var verwVonNeu = (DateTime)qryKbBelegKorrekturMasse[GridFieldNames.VerwPeriodeVon];
            var verwBisNeu = (DateTime)qryKbBelegKorrekturMasse[GridFieldNames.VerwPeriodeBis];
            var verwVonOriginal = (DateTime)qryKbBelegKorrekturMasse[GridFieldNames.VerwPeriodeVon, DataRowVersion.Original];
            var verwBisOriginal = (DateTime)qryKbBelegKorrekturMasse[GridFieldNames.VerwPeriodeBis, DataRowVersion.Original];
            var verwPeriodeChanged = _belegeKorrigierenHelper.SetVerwPeriode(splittingart, splittingartOriginal, false, verwVonOriginal, verwBisOriginal, (DateTime)qryKbBelegKorrekturMasse[GridFieldNames.Valuta], ref verwVonNeu, ref verwBisNeu);
            if (verwPeriodeChanged)
            {
                qryKbBelegKorrekturMasse[GridFieldNames.VerwPeriodeVon] = verwVonNeu;
                qryKbBelegKorrekturMasse[GridFieldNames.VerwPeriodeBis] = verwBisNeu;
            }

            if (quotingOld != (qryKbBelegKorrekturMasse[GridFieldNames.Quoting] as bool? ?? false))
            {
                // Stelle sicher, dass der Haushalt nochmals gewählt wird
                qryKbBelegKorrekturMasse[GridFieldNames.BgFinanzplanID] = DBNull.Value;
                qryKbBelegKorrekturMasse[GridFieldNames.Klient] = DBNull.Value;
                qryKbBelegKorrekturMasse[GridFieldNames.KlientBaPersonIDList] = DBNull.Value;
                qryKbBelegKorrekturMasse[GridFieldNames.BetrifftBaPersonID] = DBNull.Value;
                qryKbBelegKorrekturMasse[GridFieldNames.SelectedHaushaltProleistPersonenIDs] = DBNull.Value;
                qryKbBelegKorrekturMasse[GridFieldNames.BetrifftPerson] = DBNull.Value;
            }
        }

        private bool SetRowValueIfNotEmpty(DataRow row, string fieldName, object value)
        {
            if (!DBUtil.IsEmpty(value))
            {
                row[fieldName] = value;
                return true;
            }

            return false;
        }

        private void SetupFieldName()
        {
            colVerwPeriodeVon.FieldName = GridFieldNames.VerwPeriodeVon;
            colVerwPeriodeBis.FieldName = GridFieldNames.VerwPeriodeBis;
            gridColumnEffektivesZahldatum.FieldName = GridFieldNames.DatumEffektiv;
            gridColumnBudgetId.FieldName = GridFieldNames.Budget;
            colLA.FieldName = GridFieldNames.BgKostenartID;
            colSplitting.FieldName = GridFieldNames.SplittingArt;
            colBuchungstext.FieldName = GridFieldNames.Buchungstext;
            colKlient.FieldName = GridFieldNames.Klient;
            colEinnahme.FieldName = GridFieldNames.Einnahme;
            colAusgabe.FieldName = GridFieldNames.Ausgabe;
            colSD.FieldName = GridFieldNames.VerwaltungSD;
            colDritte.FieldName = GridFieldNames.AnDritte;
            colBar.FieldName = GridFieldNames.Bar;
            colDoc.FieldName = GridFieldNames.Doc;
            colValuta.FieldName = GridFieldNames.Valuta;
            colSta.FieldName = GridFieldNames.KbBuchungStatusCode;
            colBruttoBeleg.FieldName = GridFieldNames.BelegNr;
            colAuswahl.FieldName = GridFieldNames.Auswahl;
            colFehlermeldung.FieldName = GridFieldNames.Fehlermeldung;
            colBetragDetail.FieldName = GridFieldNames.Betrag;
        }

        private void tabControlSearch_SelectedTabChanging(object sender, CancelEventArgs e)
        {
            //(Datengeändert) && (CurrentTab==Liste) ?
            if ((_selectedRowCount > 0) && (tabControlSearch.SelectedTabIndex == TabControlSearchSelectedTabIndex.Liste))
            {
                e.Cancel = !KissMsg.ShowQuestion(
                    CLASSNAME,
                    "TAbWechselnFragen",
                    "Wollen Sie den Register wirklich verlassen? Bereits erfasste Umbuchungen werden verloren.");
            }

            //Will Leave TabList ?
            if (!e.Cancel && (tabControlSearch.SelectedTabIndex == TabControlSearchSelectedTabIndex.Liste))
            {
                //UnlockCloseFromFrame
                UnlockCloseFromFrame();
                //Clear SelectInfo ?
                ClearSelectionInfo();
            }

            //Bei Wechsel auf Register Suche: Buttons deaktivieren
            //Bei Wechsel auf Register Liste: Buttons aktivieren
            if (!e.Cancel)
            {
                EnableDisableButtons(tabControlSearch.SelectedTabIndex == TabControlSearchSelectedTabIndex.Suche);
            }
        }

        /// <summary>
        /// Allow CloseForm from Frame
        /// </summary>
        private void UnlockCloseFromFrame()
        {
            var myMainForm = GetKissMainForm();
            var myFrame = myMainForm.GetChildForm(typeof(FrmKbPSCDSchnittstelle));

            myFrame.UnlockCloseForm();
        }

        private void UpdateGridSelection(DataRow myDataRow, bool auswahlTargetValue)
        {
            if (auswahlTargetValue)
            {
                myDataRow[GridFieldNames.Valuta] = DateTime.Today;
                _selectedRowCount++;
            }
            else
            {
                //Reload All Original Fields which could be modified
                myDataRow[GridFieldNames.BgKostenartID] = myDataRow[GridFieldNames.BgKostenartID, DataRowVersion.Original];
                myDataRow[GridFieldNames.BgKostenart] = myDataRow[GridFieldNames.BgKostenart, DataRowVersion.Original];
                myDataRow[GridFieldNames.KontoNr] = myDataRow[GridFieldNames.KontoNr, DataRowVersion.Original];
                myDataRow[GridFieldNames.Abgetreten] = myDataRow[GridFieldNames.Abgetreten, DataRowVersion.Original];
                myDataRow[GridFieldNames.Hauptvorgang] = myDataRow[GridFieldNames.Hauptvorgang, DataRowVersion.Original];
                myDataRow[GridFieldNames.Teilvorgang] = myDataRow[GridFieldNames.Teilvorgang, DataRowVersion.Original];
                myDataRow[GridFieldNames.BgKostenartHauptvorgang] = myDataRow[GridFieldNames.Hauptvorgang, DataRowVersion.Original];
                myDataRow[GridFieldNames.BgKostenartTeilvorgang] = myDataRow[GridFieldNames.Teilvorgang, DataRowVersion.Original];
                myDataRow[GridFieldNames.BgKostenartHauptvorgangAbtretung] = myDataRow[GridFieldNames.BgKostenartHauptvorgangAbtretung, DataRowVersion.Original];
                myDataRow[GridFieldNames.BgKostenartTeilvorgangAbtretung] = myDataRow[GridFieldNames.BgKostenartTeilvorgangAbtretung, DataRowVersion.Original];
                myDataRow[GridFieldNames.Belegart] = myDataRow[GridFieldNames.Belegart, DataRowVersion.Original];
                myDataRow[GridFieldNames.SplittingArtCode] = myDataRow[GridFieldNames.SplittingArtCode, DataRowVersion.Original];
                myDataRow[GridFieldNames.Weiterverrechenbar] = myDataRow[GridFieldNames.Weiterverrechenbar, DataRowVersion.Original];
                myDataRow[GridFieldNames.Quoting] = myDataRow[GridFieldNames.Quoting, DataRowVersion.Original];
                myDataRow[GridFieldNames.SplittingArt] = myDataRow[GridFieldNames.SplittingArt, DataRowVersion.Original];
                myDataRow[GridFieldNames.SelectedHaushaltProleistPersonenIDs] = myDataRow[GridFieldNames.SelectedHaushaltProleistPersonenIDs, DataRowVersion.Original];
                myDataRow[GridFieldNames.Klient] = myDataRow[GridFieldNames.Klient, DataRowVersion.Original];
                myDataRow[GridFieldNames.KlientBaPersonIDList] = myDataRow[GridFieldNames.KlientBaPersonIDList, DataRowVersion.Original];
                myDataRow[GridFieldNames.BetrifftBaPersonID] = myDataRow[GridFieldNames.BetrifftBaPersonID, DataRowVersion.Original];
                myDataRow[GridFieldNames.BetrifftPerson] = myDataRow[GridFieldNames.BetrifftPerson, DataRowVersion.Original];

                myDataRow[GridFieldNames.BgFinanzplanID] = myDataRow[GridFieldNames.BgFinanzplanID, DataRowVersion.Original];
                myDataRow[GridFieldNames.Buchungstext] = myDataRow[GridFieldNames.Buchungstext, DataRowVersion.Original];
                myDataRow[GridFieldNames.FaFallID] = myDataRow[GridFieldNames.FaFallID, DataRowVersion.Original];
                myDataRow[GridFieldNames.FaLeistungID] = myDataRow[GridFieldNames.FaLeistungID, DataRowVersion.Original];
                myDataRow[GridFieldNames.Fehlermeldung] = string.Empty;
                myDataRow[GridFieldNames.Valuta] = myDataRow[GridFieldNames.Valuta, DataRowVersion.Original];
                myDataRow[GridFieldNames.VerwPeriodeBis] = myDataRow[GridFieldNames.VerwPeriodeBis, DataRowVersion.Original];
                myDataRow[GridFieldNames.VerwPeriodeVon] = myDataRow[GridFieldNames.VerwPeriodeVon, DataRowVersion.Original];

                _selectedRowCount--;
            }
        }

        private void UpdateSelectedRowCount()
        {
            int newRowCount = 0;

            foreach (DataRow row in qryKbBelegKorrekturMasse.DataTable.Rows)
            {
                if ((bool)row[GridFieldNames.Auswahl])
                {
                    newRowCount++;
                }
            }

            _selectedRowCount = newRowCount;
        }

        private void UpdateSelectionInfo(int currentChangingRowHandle = int.MinValue, bool auswahlChangingTargetValue = false)
        {
            int nbItemSelected = 0;
            decimal betragTotal = 0;

            for (int i = 0; i < qryKbBelegKorrekturMasse.DataTable.Rows.Count; i++)
            {
                var row = grvKbBelegeKorrigierenMasse.GetDataRow(i);

                //if (!currentChangingRow && Auswahl==true) OR (TargetValue==true && currentChangingRow)
                //so weil im DataGrid das current TargetValue noch nicht validiert wurde
                if (((bool)row[GridFieldNames.Auswahl] && (i != currentChangingRowHandle)) ||
                    ((i == currentChangingRowHandle) && (auswahlChangingTargetValue)))
                {
                    nbItemSelected++;

                    decimal betrag = 0;
                    object einnahme = row[GridFieldNames.Einnahme];
                    if (!DBUtil.IsEmpty(einnahme))
                    {
                        betrag = (decimal)einnahme;
                    }
                    else
                    {
                        object ausgabe = row[GridFieldNames.Ausgabe];
                        if (!DBUtil.IsEmpty(ausgabe))
                        {
                            betrag = -(decimal)ausgabe;
                        }
                    }

                    betragTotal += betrag;
                }
            }

            if (nbItemSelected > 0)
            {
                betragTotal = Utils.RoundMoney(betragTotal, (decimal)0.01);
                lblSelectInfo.Text = string.Format("Selektierte Belege: {0}, Betragstotal: Fr. {1}", nbItemSelected, betragTotal);
            }
            else
            {
                ClearSelectionInfo();
            }
        }

        private void UpdateSelectionOnOtherDetailBuchungen(int currentChangingRowHandle, int kbBuchungBruttoID, bool auswahlChangingTargetValue)
        {
            for (int i = 0; i < qryKbBelegKorrekturMasse.DataTable.Rows.Count; i++)
            {
                if (i == currentChangingRowHandle)
                {
                    continue; //skip row which is currently modified and triggered this function
                }

                var row = grvKbBelegeKorrigierenMasse.GetDataRow(i);
                var kbbuchungBruttoIDRow = row["KbBuchungBruttoID"] as int? ?? -1;
                if (kbBuchungBruttoID != -1
                    && kbbuchungBruttoIDRow != -1
                    && kbbuchungBruttoIDRow == kbBuchungBruttoID)
                {
                    //set the same selection-state as auswahlChangingTargetValue
                    UpdateGridSelection(row, auswahlChangingTargetValue);
                }
            }
        }

        /// <summary>
        /// Validierung :Prüft/Korrigiert jede Linie mit Auswahl=true im GridView
        /// Jede ungültige Line bekommt ihre Fehlermeldung im Grid
        /// Allgemeine Fehlermeldung für den Benutzer am Ende
        /// </summary>
        private bool ValidateSelectedRows()
        {
            int nbRowMitFehler = 0;

            foreach (DataRow row in qryKbBelegKorrekturMasse.DataTable.Rows)
            {
                //Auswahl=true ?

                if ((bool)row[GridFieldNames.Auswahl])
                {
                    string fehlerMeldungLinie = "";
                    const string messageSeparator = "\r\n";

                    //Grund Checks
                    if (DBUtil.IsEmpty(row[GridFieldNames.VerwPeriodeVon]) ||
                        DBUtil.IsEmpty(row[GridFieldNames.VerwPeriodeBis]) ||
                        DBUtil.IsEmpty(row[GridFieldNames.Valuta]))
                    {
                        //Datum(s) nicht leer, prüft nicht weiter
                        fehlerMeldungLinie = "Alle Datumsfelder müssen einen Wert haben.";
                        row[GridFieldNames.Fehlermeldung] = fehlerMeldungLinie;
                        nbRowMitFehler++;
                        continue;
                    }

                    DateTime verwVon = (DateTime)row[GridFieldNames.VerwPeriodeVon];
                    DateTime verwBis = (DateTime)row[GridFieldNames.VerwPeriodeBis];
                    string buchungsText = Convert.ToString(row[GridFieldNames.Buchungstext]);
                    DateTime valuta = (DateTime)row[GridFieldNames.Valuta];

                    if (verwVon > verwBis)
                    {
                        fehlerMeldungLinie += "'Verwendungsperiode von' muss vor 'Verwendungsperiode bis' liegen. " + messageSeparator;
                    }

                    if (buchungsText.Equals(string.Empty))
                    {
                        fehlerMeldungLinie += "Buchungstext ist leer. " + messageSeparator;
                    }

                    if (valuta.Date > DateTime.Today)
                    {
                        fehlerMeldungLinie += "Das Valutadatum darf nicht in der Zukunft liegen. " + messageSeparator;
                    }

                    //Grundfehler -> prüft nicht weiter
                    if (!fehlerMeldungLinie.Equals(string.Empty))
                    {
                        row[GridFieldNames.Fehlermeldung] = fehlerMeldungLinie;
                        nbRowMitFehler++;
                        continue;
                    }

                    //Korrektur: Falls Valuta oder Entscheid dann Bis=Von
                    int splittingArtCode = (int)row[GridFieldNames.SplittingArtCode];
                    BelegeKorrigierenHelper.CheckAndCorrectVerwendungsperiodGemSplittingArt(
                        false,
                        splittingArtCode,
                        verwVon,
                        ref verwBis);

                    //Check VerwendungsPeriode für splittingArt=Monat
                    bool isSiLei = (bool)row[GridFieldNames.IsSiLei];
                    string messageCheckVerwPeriod = string.Empty;

                    bool resCheckVerwPeriod = BelegeKorrigierenHelper.CheckVerwendungsPeriodeGemSplittingArtMonat(
                        isSiLei,
                        splittingArtCode,
                        verwVon,
                        verwBis,
                        ref messageCheckVerwPeriod);

                    if (!resCheckVerwPeriod)
                    {
                        //Verwendungsperiode nicht ok, prüft nicht weiter
                        fehlerMeldungLinie += messageCheckVerwPeriod + messageSeparator;
                        row[GridFieldNames.Fehlermeldung] = fehlerMeldungLinie;
                        nbRowMitFehler++;
                        continue;
                    }

                    //Check and Set Combi Finanzplan - FaLeistung - Haushalt
                    var quoting = row[GridFieldNames.Quoting] as bool?;
                    if (!quoting.HasValue)
                    {
                        //Quoting könnte nicht gefunden werden, geht nicht weiter
                        fehlerMeldungLinie += "Für diese Leistungsart konnte das Quoting nicht gefunden werden." + messageSeparator;
                        row[GridFieldNames.Fehlermeldung] = fehlerMeldungLinie;
                        nbRowMitFehler++;
                        continue;
                    }

                    if (row[GridFieldNames.FaFallID] == DBNull.Value)
                    {
                        //FaFallID darf nicht null sein
                        fehlerMeldungLinie += "FaFallID ist leer." + messageSeparator;
                        row[GridFieldNames.Fehlermeldung] = fehlerMeldungLinie;
                        nbRowMitFehler++;
                        continue;
                    }

                    object faFallID = (int)row[GridFieldNames.FaFallID];

                    if (row[GridFieldNames.BaPersonID_LT] == DBNull.Value)
                    {
                        //baPersonID_LT darf nicht null sein
                        fehlerMeldungLinie += "Leistungsträger ist leer." + messageSeparator;
                        row[GridFieldNames.Fehlermeldung] = fehlerMeldungLinie;
                        nbRowMitFehler++;
                        continue;
                    }

                    object baPersonIdLt = (int)row[GridFieldNames.BaPersonID_LT];

                    object bgFinanzplanID = (row[GridFieldNames.BgFinanzplanID] != DBNull.Value) ? (int)row[GridFieldNames.BgFinanzplanID] : (object)null;
                    object faLeistungID = (row[GridFieldNames.FaLeistungID] != DBNull.Value) ? row[GridFieldNames.FaLeistungID] : null;
                    object selectedHaushaltProleistPersonenIDs = row[GridFieldNames.SelectedHaushaltProleistPersonenIDs];
                    object selectedHaushaltdatumvon = row[GridFieldNames.SelectedHaushaltDatumVon];
                    object selectedHaushaltdatumbis = row[GridFieldNames.SelectedHaushaltDatumBis];

                    string messageCheckCombi = string.Empty;
                    bool resCheckCombi = true;

                    if (quoting.Value)
                    {
                        //Quoting=1
                        //dann prüfen wir mit klientBaPersonIDList
                        if (DBUtil.IsEmpty(row[GridFieldNames.KlientBaPersonIDList]))
                        {
                            nbRowMitFehler++;
                            fehlerMeldungLinie += "Kein Haushalt ausgewählt." + messageSeparator;
                            row[GridFieldNames.Fehlermeldung] = fehlerMeldungLinie;
                            continue;
                        }

                        foreach (string klientID in Convert.ToString(row[GridFieldNames.KlientBaPersonIDList]).Split(','))
                        {
                            //For each KlientID
                            resCheckCombi = BelegeKorrigierenHelper.CheckSetCombiFinanzplanFaLeistungHaushalt(
                                true,
                                klientID,
                                faFallID,
                                baPersonIdLt,
                                ref bgFinanzplanID,
                                ref faLeistungID,
                                ref selectedHaushaltProleistPersonenIDs,
                                ref selectedHaushaltdatumvon,
                                ref selectedHaushaltdatumbis,
                                ref messageCheckCombi
                            );

                            if (!resCheckCombi)
                            {
                                //Fehler
                                fehlerMeldungLinie += (messageCheckCombi ?? "Prüfung der Kombi. Finanzplan - FaLeistung - Haushalt fehlgeschlagen.") + messageSeparator;
                                break;
                            }
                        }
                    }
                    else
                    {
                        //Quoting=0
                        //dann prüfen wir mit klientBaPersonID
                        if (DBUtil.IsEmpty(row[GridFieldNames.BetrifftBaPersonID]))
                        {
                            nbRowMitFehler++;
                            fehlerMeldungLinie += "Klient leer." + messageSeparator;
                            row[GridFieldNames.Fehlermeldung] = fehlerMeldungLinie;
                            continue;
                        }

                        resCheckCombi = BelegeKorrigierenHelper.CheckSetCombiFinanzplanFaLeistungHaushalt(
                            false,
                            Convert.ToString(row[GridFieldNames.BetrifftBaPersonID]),
                            faFallID,
                            baPersonIdLt,
                            ref bgFinanzplanID,
                            ref faLeistungID,
                            ref selectedHaushaltProleistPersonenIDs,
                            ref selectedHaushaltdatumvon,
                            ref selectedHaushaltdatumbis,
                            ref messageCheckCombi
                        );

                        if (!resCheckCombi)
                        {
                            //Fehler
                            fehlerMeldungLinie += (messageCheckCombi ?? "Prüfung der Kombi. Finanzplan - FaLeistung - Haushalt fehlgeschlagen.") +
                                                  messageSeparator;
                        }
                    }

                    if (!resCheckCombi)
                    {
                        //Combi Finanzplan - FaLeistung - Haushalt nicht ok, prüft nicht weiter
                        row[GridFieldNames.Fehlermeldung] = fehlerMeldungLinie;
                        nbRowMitFehler++;
                        continue;
                    }

                    //End der Validierung
                    if (fehlerMeldungLinie.Equals(string.Empty))
                    {
                        //Keine Fehler gefunden
                        row[GridFieldNames.Fehlermeldung] = string.Empty;

                        //aktualisierten Daten setzen
                        row[GridFieldNames.VerwPeriodeBis] = verwBis;
                        row[GridFieldNames.BgFinanzplanID] = bgFinanzplanID;
                        row[GridFieldNames.FaLeistungID] = faLeistungID;
                        row[GridFieldNames.SelectedHaushaltProleistPersonenIDs] = selectedHaushaltProleistPersonenIDs;
                        row[GridFieldNames.SelectedHaushaltDatumVon] = selectedHaushaltdatumvon;
                        row[GridFieldNames.SelectedHaushaltDatumBis] = selectedHaushaltdatumbis;
                    }
                    else
                    {
                        //Fehler gefunden
                        row[GridFieldNames.Fehlermeldung] = fehlerMeldungLinie;
                        nbRowMitFehler++;
                    }
                }
                else
                {
                    //Auswahl=False
                    row[GridFieldNames.Fehlermeldung] = string.Empty;
                }
            }

            if (nbRowMitFehler == 0)
            {
                colFehlermeldung.Visible = false;
                return true;
            }

            colFehlermeldung.BestFit();

            colFehlermeldung.Visible = true;
            KissMsg.ShowInfo(CLASSNAME, "FehlerValidierung", "Validierung fehlgeschlagen. Anzahl ungültiger Einträge: {0}.", nbRowMitFehler);
            return false;
        }

        internal static class GridFieldNames
        {
            public const string Abgetreten = "Abgetreten";
            public const string AnDritte = "D";
            public const string Ausgabe = "Ausgabe";
            public const string Auswahl = "Auswahl";
            public const string BaPersonID_LT = "BaPersonID";
            public const string Bar = "Bar";
            public const string Belegart = "Belegart";
            public const string BelegNr = "BelegNr";
            public const string Betrag = "Betrag";
            public const string BetrifftBaPersonID = "BetrifftBaPersonID";
            public const string BetrifftPerson = "BetrifftPerson";
            public const string BgFinanzplanID = "BgFinanzplanID";
            public const string BgKostenart = "BgKostenart";
            public const string BgKostenartHauptvorgang = "BgKostenartHauptvorgang";
            public const string BgKostenartHauptvorgangAbtretung = "BgKostenartHauptvorgangAbtretung";
            public const string BgKostenartID = "BgKostenartID";
            public const string BgKostenartTeilvorgang = "BgKostenartTeilvorgang";
            public const string BgKostenartTeilvorgangAbtretung = "BgKostenartTeilvorgangAbtretung";
            public const string Buchungstext = "Text";
            public const string Budget = "Budget";
            public const string DatumEffektiv = "DatumEffektiv";
            public const string Doc = "Doc";
            public const string EA = "EA";
            public const string Einnahme = "Einnahme";
            public const string FaFallID = "FaFallID";
            public const string FaLeistungID = "FaLeistungID";
            public const string Fehlermeldung = "Fehlermeldung";
            public const string Hauptvorgang = "Hauptvorgang";
            public const string IsSiLei = "isSiLei";
            public const string KbBuchungStatusCode = "KbBuchungStatusCode";
            public const string Klient = "Klient";
            public const string KlientBaPersonCount = "KlientBaPersonCount";
            public const string KlientBaPersonIDList = "BetrifftBaPersonIDs";
            public const string KontoNr = "KontoNr";
            public const string Quoting = "Quoting";
            public const string SelectedHaushaltDatumBis = "SelectedHaushaltDatumBis";
            public const string SelectedHaushaltDatumVon = "SelectedHaushaltDatumVon";
            public const string SelectedHaushaltProleistPersonenIDs = "SelectedHaushaltProleistPersonenIDs";
            public const string SplittingArt = "Splittingart";
            public const string SplittingArtCode = "BgSplittingArtCode";
            public const string StornoCode = "StornoCode";
            public const string Teilvorgang = "Teilvorgang";
            public const string Valuta = "ValutaDatum";
            public const string VerwaltungSD = "S";
            public const string VerwPeriodeBis = "VerwPeriodeBis";
            public const string VerwPeriodeVon = "VerwPeriodeVon";
            public const string Weiterverrechenbar = "Weiterverrechenbar";
        }

        private static class GridColNames
        {
            public const string Auswahl = "colAuswahl";
            public const string Buchungstext = "colBuchungstext";
            public const string Klient = "colKlient";
            public const string LA = "colLA";
            public const string Valuta = "colValuta";
            public const string VerwPeriodeBis = "colVerwPeriodeBis";
            public const string VerwPeriodeVon = "colVerwPeriodeVon";
        }

        private static class TabControlSearchSelectedTabIndex
        {
            public const int Liste = 0;
            public const int Suche = 1;
        }
    }
}