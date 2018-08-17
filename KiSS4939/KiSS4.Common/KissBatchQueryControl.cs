using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Messages;

namespace KiSS4.Common
{
    public class KissBatchQueryControl : KissQueryControl
    {
        protected KissButton btnAenderungenUebernehmen;
        protected KissButton btnSelectAll;
        protected KissButton btnSelectNone;
        protected GridColumn colSelektiert;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repSelektiert;

        public KissBatchQueryControl()
        {
            AllowGrouping = false;

            InitializeComponent();

            ShowHideSelectionButtons(false);
            IsAenderungenUebernehmenAllowed = qryQuery.CanUpdate;
        }

        public bool IsAenderungenUebernehmenAllowed { get; set; }
        protected GridColumn SelectionColumn { get { return colSelektiert; } }

        public override bool OnSaveData()
        {
            var result = base.OnSaveData();

            if (IsAenderungenUebernehmenAllowed && IsSelectionModified())
            {
                AenderungenUebernehmen();
            }

            return result;
        }

        public override void OnUndoDataChanges()
        {
            base.OnUndoDataChanges();
            qryQuery.Refresh();
        }

        protected virtual void AenderungenUebernehmen(DataRow row)
        {
            //default: do nothing
        }

        protected virtual void AenderungenUebernehmenEnd()
        {
            //default: refresh query
            qryQuery.Refresh();
        }

        protected virtual void AenderungenUebernehmenStart()
        {
            try
            {
                /*Change Cursor*/
                Cursor = Cursors.WaitCursor;

                DlgProgressLog.AddLine(GetStartMessage());
                DlgProgressLog.ShowTopMost();

                Session.BeginTransaction();

                DBUtil.NewHistoryVersion();

                //perform task
                foreach (DataRow row in qryQuery.DataTable.Rows)
                {
                    if (DlgProgressLog.CancellledByUser)
                    {
                        return;
                    }

                    bool isSelectionModified = IsSelectionModified(row);
                    if (!isSelectionModified)
                    {
                        continue;
                    }

                    AenderungenUebernehmen(row);
                }

                Session.Commit();

                DlgProgressLog.AddLine(GetEndMessage());
            }
            catch (Exception ex)
            {
                DlgProgressLog.AddLine(GetErrorMessage(ex));
                Session.Rollback();
            }
            finally
            {
                /*Change Cursor*/
                Cursor = Cursors.Default;
                DlgProgressLog.EndProgress();
                DlgProgressLog.ShowTopMost();
            }
        }

        protected virtual string GetEndMessage()
        {
            return KissMsg.GetMLMessage(GetType().Name, "VerarbeitungslaufAbgeschlossen",
                "Verarbeitungslauf abgeschlossen");
        }

        protected virtual string GetErrorMessage(Exception ex)
        {
            return KissMsg.GetMLMessage(GetType().Name, "VerarbeitungslaufAbgebrochen",
                "Die Verarbeitung wurde wegen folgendem Fehler abgebrochen: {0}", ex);
        }

        protected virtual int GetNbrSelectedRows()
        {
            if (grdQuery1 == null || grdQuery1.View == null)
            {
                return 0;
            }

            int anzahlZuPruefen = 0;
            int rowCount = AllowMultiselecting ? grdQuery1.View.RowCount : grdQuery1.View.DataRowCount;
            for (var i = 0; i < rowCount; i++)
            {
                if (IsRowSelected(i))
                {
                    anzahlZuPruefen++;
                }
            }

            return anzahlZuPruefen;
        }

        protected virtual string GetProgressTitle()
        {
            return KissMsg.GetMLMessage(GetType().Name, "FortschrittVerarbeitungslauf",
                "Verarbeitungslauf: Aenderungen übernehmen");
        }

        protected virtual string GetStartMessage()
        {
            return KissMsg.GetMLMessage(GetType().Name, "VerarbeitungslaufGestartet",
                "Verarbeitungslauf gestartet...");
        }

        protected virtual bool IsRowSelected(int rowHandle)
        {
            return Utils.ConvertToBool(grdQuery1.View.GetRowCellValue(rowHandle, SelectionColumn));
        }

        protected virtual bool IsRowSelected(DataRow row)
        {
            return row[colSelektiert.FieldName] as bool? ?? false;
        }

        protected virtual bool IsSelectionModified()
        {
            foreach (DataRow row in qryQuery.DataTable.Rows)
            {
                if (IsSelectionModified(row))
                {
                    return true;
                }
            }
            return false;
        }

        protected virtual bool IsSelectionModified(DataRow row)
        {
            var dataOriginal = row[colSelektiert.FieldName, DataRowVersion.Original] as bool? ?? false;
            var dataCurrent = row[colSelektiert.FieldName, DataRowVersion.Current] as bool? ?? false;
            if (dataOriginal != dataCurrent)
            {
                return true;
            }
            return false;
        }

        protected virtual void OnSelectionChanged()
        {
            //default: do nothing
        }

        protected virtual bool OnSelectionChanging(bool oldValue, bool newValue, int rowHandle, DataRow row)
        {
            //allow = true
            //cancel = false;
            return true;
        }

        protected virtual void OnSelectionCheckStateChanged()
        {
            //default: do nothing
        }

        protected virtual void OnSelectionRowCellStyle(RowCellStyleEventArgs rowCellStyleEventArgs)
        {
            //default: do nothing
        }

        protected virtual void SetFlagOnAllRows(bool flagStatus)
        {
            int rowCount = AllowMultiselecting ? grdQuery1.View.RowCount : grdQuery1.View.DataRowCount;

            for (var i = 0; i < rowCount; i++)
            {
                var datasourceRowIndex = grvQuery1.GetDataSourceRowIndex(i);
                var row = qryQuery.DataTable.Rows[datasourceRowIndex];
                SetFlagOnRow(flagStatus, i, row);
            }
        }

        protected virtual void SetFlagOnRow(bool flagStatus, int rowHandle, DataRow row)
        {
            grdQuery1.View.SetRowCellValue(rowHandle, SelectionColumn, flagStatus);
            grvQuery1.UpdateCurrentRow();
        }

        protected virtual void SetupGridColumnEditMode()
        {
            var editable = qryQuery.CanUpdate;

            foreach (GridColumn column in grvQuery1.Columns)
            {
                if (column == SelectionColumn)
                {
                    grdQuery1.SetColumnEditable(column, editable);
                }
                else
                {
                    grdQuery1.SetColumnEditable(column, false);
                }
            }
        }

        protected void ShowHideSelectionButtons(bool visible)
        {
            btnSelectNone.Visible = visible;
            btnSelectAll.Visible = visible;

            if (!visible)
            {
                btnAenderungenUebernehmen.Enabled = false;
            }
            else
            {
                btnAenderungenUebernehmen.Enabled = IsAenderungenUebernehmenAllowed;
            }
        }

        protected override void UpdateCountLabel(KissGrid grid)
        {
            base.UpdateCountLabel(grid);

            if (grid == null || grid.View == null)
            {
                ShowHideSelectionButtons(false);
                return;
            }

            int rowCount = AllowMultiselecting ? grid.View.RowCount : grid.View.DataRowCount;
            if (rowCount == 0)
            {
                ShowHideSelectionButtons(false);
                return;
            }

            ShowHideSelectionButtons(true);
        }

        private void AenderungenUebernehmen()
        {
            //Ask for confirmation
            if (KissMsg.ShowQuestion(
                GetType().Name,
                "FrageAenderungenUebernehmen",
                @"Möchten Sie die vorgenommenen Änderungen übernehmen?")
                )
            {
                DlgProgressLog.Show(
                        GetProgressTitle(),
                        700,
                        300,
                        AenderungenUebernehmenStart,
                        AenderungenUebernehmenEnd,
                        Session.MainForm
                    );
                return;
            }

            if (KissMsg.ShowQuestion(
                    GetType().Name,
                    "FrageAenderungenVerwerfen",
                    @"Möchten Sie die vorgenommenen Änderungen verwerfen?")
                    )
            {
                qryQuery.Refresh();
            }
        }

        private void btnAenderungenUebernehmen_Click(object sender, EventArgs e)
        {
            if (IsSelectionModified())
            {
                AenderungenUebernehmen();
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            SetFlagOnAllRows(true);
        }

        private void btnSelectNone_Click(object sender, EventArgs e)
        {
            SetFlagOnAllRows(false);
        }

        private void grvQuery1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //invoke only on SelectionColumn
            if (e.Column != SelectionColumn)
                return;

            OnSelectionRowCellStyle(e);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KissBatchQueryControl));
            this.btnSelectNone = new KiSS4.Gui.KissButton();
            this.btnSelectAll = new KiSS4.Gui.KissButton();
            this.colSelektiert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSelektiert = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.btnAenderungenUebernehmen = new KiSS4.Gui.KissButton();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repSelektiert)).BeginInit();
            this.SuspendLayout();
            //
            // qryQuery
            //
            this.qryQuery.BatchUpdate = true;
            this.qryQuery.CanUpdate = true;
            //
            // grvQuery1
            //
            this.grvQuery1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvQuery1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.Empty.Options.UseBackColor = true;
            this.grvQuery1.Appearance.Empty.Options.UseFont = true;
            this.grvQuery1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvQuery1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.EvenRow.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvQuery1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvQuery1.Appearance.FocusedCell.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvQuery1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvQuery1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.FocusedRow.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvQuery1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvQuery1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvQuery1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseFont = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvQuery1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvQuery1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvQuery1.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvQuery1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvQuery1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery1.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvQuery1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvQuery1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.OddRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.OddRow.Options.UseFont = true;
            this.grvQuery1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvQuery1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.Row.Options.UseBackColor = true;
            this.grvQuery1.Appearance.Row.Options.UseFont = true;
            this.grvQuery1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvQuery1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvQuery1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.SelectedRow.Options.UseFont = true;
            this.grvQuery1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery1.Appearance.VertLine.Options.UseBackColor = true;
            this.grvQuery1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSelektiert});
            this.grvQuery1.OptionsBehavior.Editable = false;
            this.grvQuery1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvQuery1.OptionsNavigation.AutoFocusNewRow = true;
            this.grvQuery1.OptionsNavigation.UseTabKey = false;
            this.grvQuery1.OptionsPrint.AutoWidth = false;
            this.grvQuery1.OptionsPrint.ExpandAllDetails = true;
            this.grvQuery1.OptionsPrint.UsePrintStyles = true;
            this.grvQuery1.OptionsView.ColumnAutoWidth = false;
            this.grvQuery1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvQuery1.OptionsView.ShowGroupPanel = false;
            this.grvQuery1.OptionsView.ShowIndicator = false;
            this.grvQuery1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grvQuery1_RowCellStyle);
            //
            // grdQuery1
            //
            //
            //
            //
            this.grdQuery1.EmbeddedNavigator.Name = "";
            this.grdQuery1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repSelektiert});
            //
            // xDocument
            //
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.btnAenderungenUebernehmen);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Controls.SetChildIndex(this.grdQuery1, 0);
            this.tpgListe.Controls.SetChildIndex(this.ctlGotoFall, 0);
            this.tpgListe.Controls.SetChildIndex(this.xDocument, 0);
            this.tpgListe.Controls.SetChildIndex(this.lblSuchkriterienInfo, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnAenderungenUebernehmen, 0);
            //
            // tpgSuchen
            //
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            //
            // btnSelectNone
            //
            this.btnSelectNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectNone.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectNone.Image")));
            this.btnSelectNone.Location = new System.Drawing.Point(38, 5);
            this.btnSelectNone.Name = "btnSelectNone";
            this.btnSelectNone.Size = new System.Drawing.Size(24, 24);
            this.btnSelectNone.TabIndex = 53;
            this.btnSelectNone.UseCompatibleTextRendering = true;
            this.btnSelectNone.UseVisualStyleBackColor = false;
            this.btnSelectNone.Click += new System.EventHandler(this.btnSelectNone_Click);
            //
            // btnSelectAll
            //
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectAll.Image")));
            this.btnSelectAll.Location = new System.Drawing.Point(8, 5);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(24, 24);
            this.btnSelectAll.TabIndex = 52;
            this.btnSelectAll.UseCompatibleTextRendering = true;
            this.btnSelectAll.UseVisualStyleBackColor = false;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            //
            // colSelektiert
            //
            this.colSelektiert.Caption = "Selektiert";
            this.colSelektiert.ColumnEdit = this.repSelektiert;
            this.colSelektiert.FieldName = "Selektiert";
            this.colSelektiert.Name = "colSelektiert";
            this.colSelektiert.Visible = true;
            this.colSelektiert.VisibleIndex = 0;
            //
            // repSelektiert
            //
            this.repSelektiert.AutoHeight = false;
            this.repSelektiert.Name = "repSelektiert";
            this.repSelektiert.CheckStateChanged += new System.EventHandler(this.repSelektiert_CheckStateChanged);
            this.repSelektiert.EditValueChanged += new System.EventHandler(this.repSelektiert_EditValueChanged);
            this.repSelektiert.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.repSelektiert_EditValueChanging);
            //
            // btnAenderungenUebernehmen
            //
            this.btnAenderungenUebernehmen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAenderungenUebernehmen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAenderungenUebernehmen.Location = new System.Drawing.Point(607, 398);
            this.btnAenderungenUebernehmen.Name = "btnAenderungenUebernehmen";
            this.btnAenderungenUebernehmen.Size = new System.Drawing.Size(162, 24);
            this.btnAenderungenUebernehmen.TabIndex = 8;
            this.btnAenderungenUebernehmen.Text = "Änderungen übernehmen";
            this.btnAenderungenUebernehmen.UseVisualStyleBackColor = false;
            this.btnAenderungenUebernehmen.Click += new System.EventHandler(this.btnAenderungenUebernehmen_Click);
            //
            // KissBatchQueryControl
            //
            this.Controls.Add(this.btnSelectNone);
            this.Controls.Add(this.btnSelectAll);
            this.Name = "KissBatchQueryControl";
            this.Load += new System.EventHandler(this.KissBatchQueryControl_Load);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.btnSelectAll, 0);
            this.Controls.SetChildIndex(this.btnSelectNone, 0);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repSelektiert)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void KissBatchQueryControl_Load(object sender, EventArgs e)
        {
            //make sure, the gridview is editable (is set to false in super-class)
            grvQuery1.OptionsBehavior.Editable = true;

            SetupGridColumnEditMode();
        }

        private void repSelektiert_CheckStateChanged(object sender, EventArgs e)
        {
            OnSelectionCheckStateChanged();
        }

        private void repSelektiert_EditValueChanged(object sender, EventArgs e)
        {
            OnSelectionChanged();
        }

        private void repSelektiert_EditValueChanging(object sender, ChangingEventArgs args)
        {
            var oldValue = args.OldValue as bool? ?? false;
            var newValue = args.NewValue as bool? ?? false;
            var rowHandle = grvQuery1.FocusedRowHandle;
            var datasourceIndex = grvQuery1.GetDataSourceRowIndex(rowHandle);
            var row = qryQuery.DataTable.Rows[datasourceIndex];

            args.Cancel = !OnSelectionChanging(oldValue, newValue, rowHandle, row);
        }
    }
}