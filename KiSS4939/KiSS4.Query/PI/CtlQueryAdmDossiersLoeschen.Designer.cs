using System;

using KiSS4.Common.PI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query.PI
{
    partial class CtlQueryAdmDossiersLoeschen 
    {
        #region Fields

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryAdmDossiersLoeschen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblSucheKostenstelle = new KiSS4.Gui.KissLabel();
            this.edtSucheMitarbeiter = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheSAR = new KiSS4.Gui.KissLabel();
            this.edtSucheKostenstelle = new KiSS4.Gui.KissLookUpEdit();
            this.btnDossiersLoeschen = new KiSS4.Gui.KissButton();
            this.colSelektiert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLetzteZeiterfassung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFallverlaufNichtAbgeschlossen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblSucheJahr = new KiSS4.Gui.KissLabel();
            this.colFallverantwortlich = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtSucheJahr = new KiSS4.Gui.KissIntEdit();
            this.colNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridKostenstelle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKGS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBezirk = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKanton = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationalitaet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeschlecht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVersichertennummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHauptbehinderungsart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBSVBehinderungsart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIVBerechtigung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSelectNone = new KiSS4.Gui.KissButton();
            this.btnSelectAll = new KiSS4.Gui.KissButton();
            this.cbVerwaistePersonen = new System.Windows.Forms.CheckBox();
            this.qryQueryOrphans = new KiSS4.DB.SqlQuery(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKostenstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheSAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKostenstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKostenstelle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheJahr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheJahr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryQueryOrphans)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.BatchUpdate = true;
            this.qryQuery.CanUpdate = true;
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            this.qryQuery.BeforePost += new System.EventHandler(this.qryQuery_BeforePost);
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
            this.colSelektiert,
            this.colNr,
            this.colName,
            this.colVorname,
            this.colLetzteZeiterfassung,
            this.colFallverlaufNichtAbgeschlossen,
            this.gridKostenstelle,
            this.colKGS,
            this.colFallverantwortlich,
            this.colPLZ,
            this.colOrt,
            this.colBezirk,
            this.colKanton,
            this.colNationalitaet,
            this.colGeschlecht,
            this.colGeburtsdatum,
            this.colAlter,
            this.colVersichertennummer,
            this.colHauptbehinderungsart,
            this.colBSVBehinderungsart,
            this.colIVBerechtigung});
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
            // 
            // grdQuery1
            // 
            // 
            // 
            // 
            this.grdQuery1.EmbeddedNavigator.Name = "";
            // 
            // xDocument
            // 
            this.xDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Location = new System.Drawing.Point(180, 398);
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            this.xDocument.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = "BaPersonID$";
            this.ctlGotoFall.Size = new System.Drawing.Size(171, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.SelectedTabIndex = 1;
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.btnDossiersLoeschen);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Controls.SetChildIndex(this.grdQuery1, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnDossiersLoeschen, 0);
            this.tpgListe.Controls.SetChildIndex(this.xDocument, 0);
            this.tpgListe.Controls.SetChildIndex(this.ctlGotoFall, 0);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.cbVerwaistePersonen);
            this.tpgSuchen.Controls.Add(this.edtSucheJahr);
            this.tpgSuchen.Controls.Add(this.lblSucheJahr);
            this.tpgSuchen.Controls.Add(this.edtSucheMitarbeiter);
            this.tpgSuchen.Controls.Add(this.lblSucheSAR);
            this.tpgSuchen.Controls.Add(this.lblSucheKostenstelle);
            this.tpgSuchen.Controls.Add(this.edtSucheKostenstelle);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheKostenstelle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheKostenstelle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheSAR, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheMitarbeiter, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheJahr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheJahr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.cbVerwaistePersonen, 0);
            // 
            // lblSucheKostenstelle
            // 
            this.lblSucheKostenstelle.Location = new System.Drawing.Point(31, 40);
            this.lblSucheKostenstelle.Name = "lblSucheKostenstelle";
            this.lblSucheKostenstelle.Size = new System.Drawing.Size(133, 24);
            this.lblSucheKostenstelle.TabIndex = 3;
            this.lblSucheKostenstelle.Text = "Kostenstelle";
            this.lblSucheKostenstelle.UseCompatibleTextRendering = true;
            // 
            // edtSucheMitarbeiter
            // 
            this.edtSucheMitarbeiter.Location = new System.Drawing.Point(170, 100);
            this.edtSucheMitarbeiter.Name = "edtSucheMitarbeiter";
            this.edtSucheMitarbeiter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheMitarbeiter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheMitarbeiter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheMitarbeiter.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheMitarbeiter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheMitarbeiter.Properties.Appearance.Options.UseFont = true;
            this.edtSucheMitarbeiter.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheMitarbeiter.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheMitarbeiter.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheMitarbeiter.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheMitarbeiter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSucheMitarbeiter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSucheMitarbeiter.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheMitarbeiter.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 5, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtSucheMitarbeiter.Properties.DisplayMember = "Text";
            this.edtSucheMitarbeiter.Properties.NullText = "";
            this.edtSucheMitarbeiter.Properties.ShowFooter = false;
            this.edtSucheMitarbeiter.Properties.ShowHeader = false;
            this.edtSucheMitarbeiter.Properties.ValueMember = "Code";
            this.edtSucheMitarbeiter.Size = new System.Drawing.Size(244, 24);
            this.edtSucheMitarbeiter.TabIndex = 6;
            // 
            // lblSucheSAR
            // 
            this.lblSucheSAR.Location = new System.Drawing.Point(31, 100);
            this.lblSucheSAR.Name = "lblSucheSAR";
            this.lblSucheSAR.Size = new System.Drawing.Size(133, 24);
            this.lblSucheSAR.TabIndex = 5;
            this.lblSucheSAR.Text = "Mitarbeiter/in";
            this.lblSucheSAR.UseCompatibleTextRendering = true;
            // 
            // edtSucheKostenstelle
            // 
            this.edtSucheKostenstelle.Location = new System.Drawing.Point(170, 40);
            this.edtSucheKostenstelle.Name = "edtSucheKostenstelle";
            this.edtSucheKostenstelle.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheKostenstelle.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheKostenstelle.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheKostenstelle.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheKostenstelle.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheKostenstelle.Properties.Appearance.Options.UseFont = true;
            this.edtSucheKostenstelle.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheKostenstelle.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheKostenstelle.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheKostenstelle.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheKostenstelle.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtSucheKostenstelle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtSucheKostenstelle.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheKostenstelle.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 5, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtSucheKostenstelle.Properties.DisplayMember = "Text";
            this.edtSucheKostenstelle.Properties.NullText = "";
            this.edtSucheKostenstelle.Properties.ShowFooter = false;
            this.edtSucheKostenstelle.Properties.ShowHeader = false;
            this.edtSucheKostenstelle.Properties.ValueMember = "Code";
            this.edtSucheKostenstelle.Size = new System.Drawing.Size(244, 24);
            this.edtSucheKostenstelle.TabIndex = 2;
            // 
            // btnDossiersLoeschen
            // 
            this.btnDossiersLoeschen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDossiersLoeschen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDossiersLoeschen.Location = new System.Drawing.Point(631, 398);
            this.btnDossiersLoeschen.Name = "btnDossiersLoeschen";
            this.btnDossiersLoeschen.Size = new System.Drawing.Size(138, 24);
            this.btnDossiersLoeschen.TabIndex = 3;
            this.btnDossiersLoeschen.Text = "Dossiers löschen";
            this.btnDossiersLoeschen.UseVisualStyleBackColor = false;
            this.btnDossiersLoeschen.Click += new System.EventHandler(this.btnDossiersLoeschen_Click);
            // 
            // colSelektiert
            // 
            this.colSelektiert.Caption = "Löschen";
            this.colSelektiert.FieldName = "Selektiert";
            this.colSelektiert.Name = "colSelektiert";
            this.colSelektiert.Visible = true;
            this.colSelektiert.VisibleIndex = 0;
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.OptionsColumn.AllowFocus = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            // 
            // colLetzteZeiterfassung
            // 
            this.colLetzteZeiterfassung.Caption = "Letzte Zeiterfassung";
            this.colLetzteZeiterfassung.FieldName = "LetzteZeiterfassung";
            this.colLetzteZeiterfassung.Name = "colLetzteZeiterfassung";
            this.colLetzteZeiterfassung.OptionsColumn.AllowEdit = false;
            this.colLetzteZeiterfassung.OptionsColumn.AllowFocus = false;
            this.colLetzteZeiterfassung.Visible = true;
            this.colLetzteZeiterfassung.VisibleIndex = 4;
            // 
            // colFallverlaufNichtAbgeschlossen
            // 
            this.colFallverlaufNichtAbgeschlossen.Caption = "Unabgeschlossener Fallverlauf";
            this.colFallverlaufNichtAbgeschlossen.FieldName = "FallverlaufNichtAbgeschlossen";
            this.colFallverlaufNichtAbgeschlossen.Name = "colFallverlaufNichtAbgeschlossen";
            this.colFallverlaufNichtAbgeschlossen.OptionsColumn.AllowEdit = false;
            this.colFallverlaufNichtAbgeschlossen.OptionsColumn.AllowFocus = false;
            this.colFallverlaufNichtAbgeschlossen.Visible = true;
            this.colFallverlaufNichtAbgeschlossen.VisibleIndex = 5;
            this.colFallverlaufNichtAbgeschlossen.Width = 90;
            // 
            // lblSucheJahr
            // 
            this.lblSucheJahr.Location = new System.Drawing.Point(31, 70);
            this.lblSucheJahr.Name = "lblSucheJahr";
            this.lblSucheJahr.Size = new System.Drawing.Size(133, 24);
            this.lblSucheJahr.TabIndex = 10;
            this.lblSucheJahr.Text = "Stichtag";
            this.lblSucheJahr.UseCompatibleTextRendering = true;
            // 
            // colFallverantwortlich
            // 
            this.colFallverantwortlich.Caption = "Verantwortliche/r FV";
            this.colFallverantwortlich.FieldName = "FallVerantwortlich";
            this.colFallverantwortlich.Name = "colFallverantwortlich";
            this.colFallverantwortlich.OptionsColumn.AllowEdit = false;
            this.colFallverantwortlich.OptionsColumn.AllowFocus = false;
            this.colFallverantwortlich.Visible = true;
            this.colFallverantwortlich.VisibleIndex = 8;
            // 
            // edtSucheJahr
            // 
            this.edtSucheJahr.Location = new System.Drawing.Point(170, 70);
            this.edtSucheJahr.Name = "edtSucheJahr";
            this.edtSucheJahr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheJahr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheJahr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheJahr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheJahr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheJahr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheJahr.Properties.Appearance.Options.UseFont = true;
            this.edtSucheJahr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheJahr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheJahr.Properties.DisplayFormat.FormatString = "################################";
            this.edtSucheJahr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSucheJahr.Properties.EditFormat.FormatString = "################################";
            this.edtSucheJahr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSucheJahr.Properties.Mask.EditMask = "################################";
            this.edtSucheJahr.Size = new System.Drawing.Size(100, 24);
            this.edtSucheJahr.TabIndex = 20;
            // 
            // colNr
            // 
            this.colNr.Caption = "Nr.";
            this.colNr.FieldName = "Nr";
            this.colNr.Name = "colNr";
            this.colNr.OptionsColumn.AllowEdit = false;
            this.colNr.OptionsColumn.AllowFocus = false;
            this.colNr.Visible = true;
            this.colNr.VisibleIndex = 1;
            // 
            // colVorname
            // 
            this.colVorname.Caption = "Vorname";
            this.colVorname.FieldName = "Vorname";
            this.colVorname.Name = "colVorname";
            this.colVorname.OptionsColumn.AllowEdit = false;
            this.colVorname.OptionsColumn.AllowFocus = false;
            this.colVorname.Visible = true;
            this.colVorname.VisibleIndex = 3;
            // 
            // gridKostenstelle
            // 
            this.gridKostenstelle.Caption = "Kostenstelle";
            this.gridKostenstelle.FieldName = "Kostenstelle";
            this.gridKostenstelle.Name = "gridKostenstelle";
            this.gridKostenstelle.OptionsColumn.AllowEdit = false;
            this.gridKostenstelle.OptionsColumn.AllowFocus = false;
            this.gridKostenstelle.Visible = true;
            this.gridKostenstelle.VisibleIndex = 6;
            // 
            // colKGS
            // 
            this.colKGS.Caption = "KGS";
            this.colKGS.FieldName = "KGS";
            this.colKGS.Name = "colKGS";
            this.colKGS.OptionsColumn.AllowEdit = false;
            this.colKGS.OptionsColumn.AllowFocus = false;
            this.colKGS.Visible = true;
            this.colKGS.VisibleIndex = 7;
            // 
            // colPLZ
            // 
            this.colPLZ.Caption = "PLZ";
            this.colPLZ.FieldName = "PLZ";
            this.colPLZ.Name = "colPLZ";
            this.colPLZ.OptionsColumn.AllowEdit = false;
            this.colPLZ.OptionsColumn.AllowFocus = false;
            this.colPLZ.Visible = true;
            this.colPLZ.VisibleIndex = 9;
            // 
            // colOrt
            // 
            this.colOrt.Caption = "Ort";
            this.colOrt.FieldName = "Ort";
            this.colOrt.Name = "colOrt";
            this.colOrt.OptionsColumn.AllowEdit = false;
            this.colOrt.OptionsColumn.AllowFocus = false;
            this.colOrt.Visible = true;
            this.colOrt.VisibleIndex = 10;
            // 
            // colBezirk
            // 
            this.colBezirk.Caption = "Bezirk";
            this.colBezirk.FieldName = "Bezirk";
            this.colBezirk.Name = "colBezirk";
            this.colBezirk.OptionsColumn.AllowEdit = false;
            this.colBezirk.OptionsColumn.AllowFocus = false;
            this.colBezirk.Visible = true;
            this.colBezirk.VisibleIndex = 11;
            // 
            // colKanton
            // 
            this.colKanton.Caption = "Kanton";
            this.colKanton.FieldName = "Kanton";
            this.colKanton.Name = "colKanton";
            this.colKanton.OptionsColumn.AllowEdit = false;
            this.colKanton.OptionsColumn.AllowFocus = false;
            this.colKanton.Visible = true;
            this.colKanton.VisibleIndex = 12;
            // 
            // colNationalitaet
            // 
            this.colNationalitaet.Caption = "Nationalität";
            this.colNationalitaet.FieldName = "Nationalitaet";
            this.colNationalitaet.Name = "colNationalitaet";
            this.colNationalitaet.OptionsColumn.AllowEdit = false;
            this.colNationalitaet.OptionsColumn.AllowFocus = false;
            this.colNationalitaet.Visible = true;
            this.colNationalitaet.VisibleIndex = 13;
            // 
            // colGeschlecht
            // 
            this.colGeschlecht.Caption = "Geschlecht";
            this.colGeschlecht.FieldName = "Geschlecht";
            this.colGeschlecht.Name = "colGeschlecht";
            this.colGeschlecht.OptionsColumn.AllowEdit = false;
            this.colGeschlecht.OptionsColumn.AllowFocus = false;
            this.colGeschlecht.Visible = true;
            this.colGeschlecht.VisibleIndex = 14;
            // 
            // colGeburtsdatum
            // 
            this.colGeburtsdatum.Caption = "Geburtsdatum";
            this.colGeburtsdatum.FieldName = "Geburtsdatum";
            this.colGeburtsdatum.Name = "colGeburtsdatum";
            this.colGeburtsdatum.OptionsColumn.AllowEdit = false;
            this.colGeburtsdatum.OptionsColumn.AllowFocus = false;
            this.colGeburtsdatum.Visible = true;
            this.colGeburtsdatum.VisibleIndex = 15;
            // 
            // colAlter
            // 
            this.colAlter.Caption = "Alter";
            this.colAlter.FieldName = "Alter";
            this.colAlter.Name = "colAlter";
            this.colAlter.OptionsColumn.AllowEdit = false;
            this.colAlter.OptionsColumn.AllowFocus = false;
            this.colAlter.Visible = true;
            this.colAlter.VisibleIndex = 16;
            // 
            // colVersichertennummer
            // 
            this.colVersichertennummer.Caption = "Vers.-Nr.";
            this.colVersichertennummer.FieldName = "Versichertennummer";
            this.colVersichertennummer.Name = "colVersichertennummer";
            this.colVersichertennummer.OptionsColumn.AllowEdit = false;
            this.colVersichertennummer.OptionsColumn.AllowFocus = false;
            this.colVersichertennummer.Visible = true;
            this.colVersichertennummer.VisibleIndex = 17;
            // 
            // colHauptbehinderungsart
            // 
            this.colHauptbehinderungsart.Caption = "Hauptbehinderungsart";
            this.colHauptbehinderungsart.FieldName = "Hauptbehinderungsart";
            this.colHauptbehinderungsart.Name = "colHauptbehinderungsart";
            this.colHauptbehinderungsart.OptionsColumn.AllowEdit = false;
            this.colHauptbehinderungsart.OptionsColumn.AllowFocus = false;
            this.colHauptbehinderungsart.Visible = true;
            this.colHauptbehinderungsart.VisibleIndex = 18;
            // 
            // colBSVBehinderungsart
            // 
            this.colBSVBehinderungsart.Caption = "BSV-Behinderungsart";
            this.colBSVBehinderungsart.FieldName = "BSVBehinderungsart";
            this.colBSVBehinderungsart.Name = "colBSVBehinderungsart";
            this.colBSVBehinderungsart.OptionsColumn.AllowEdit = false;
            this.colBSVBehinderungsart.OptionsColumn.AllowFocus = false;
            this.colBSVBehinderungsart.Visible = true;
            this.colBSVBehinderungsart.VisibleIndex = 19;
            // 
            // colIVBerechtigung
            // 
            this.colIVBerechtigung.Caption = "IV Berechtigung";
            this.colIVBerechtigung.FieldName = "IVBerechtigung";
            this.colIVBerechtigung.Name = "colIVBerechtigung";
            this.colIVBerechtigung.OptionsColumn.AllowEdit = false;
            this.colIVBerechtigung.OptionsColumn.AllowFocus = false;
            this.colIVBerechtigung.Visible = true;
            this.colIVBerechtigung.VisibleIndex = 20;
            // 
            // btnSelectNone
            // 
            this.btnSelectNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectNone.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectNone.Image")));
            this.btnSelectNone.Location = new System.Drawing.Point(133, 5);
            this.btnSelectNone.Name = "btnSelectNone";
            this.btnSelectNone.Size = new System.Drawing.Size(24, 24);
            this.btnSelectNone.TabIndex = 51;
            this.btnSelectNone.UseCompatibleTextRendering = true;
            this.btnSelectNone.UseVisualStyleBackColor = false;
            this.btnSelectNone.Click += new System.EventHandler(this.btnSelectNone_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectAll.Image")));
            this.btnSelectAll.Location = new System.Drawing.Point(103, 5);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(24, 24);
            this.btnSelectAll.TabIndex = 50;
            this.btnSelectAll.UseCompatibleTextRendering = true;
            this.btnSelectAll.UseVisualStyleBackColor = false;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // cbVerwaistePersonen
            // 
            this.cbVerwaistePersonen.AutoSize = true;
            this.cbVerwaistePersonen.Location = new System.Drawing.Point(170, 130);
            this.cbVerwaistePersonen.Name = "cbVerwaistePersonen";
            this.cbVerwaistePersonen.Size = new System.Drawing.Size(180, 19);
            this.cbVerwaistePersonen.TabIndex = 21;
            this.cbVerwaistePersonen.Text = "suche \"verwaiste\" Personen";
            this.cbVerwaistePersonen.UseVisualStyleBackColor = true;
            this.cbVerwaistePersonen.Visible = false;
            this.cbVerwaistePersonen.CheckedChanged += new System.EventHandler(this.cbVerwaistePersonen_CheckedChanged);
            // 
            // qryQueryOrphans
            // 
            this.qryQueryOrphans.HostControl = this;
            this.qryQueryOrphans.SelectStatement = resources.GetString("qryQueryOrphans.SelectStatement");
            // 
            // CtlQueryAdmDossiersLoeschen
            // 
            this.Controls.Add(this.btnSelectNone);
            this.Controls.Add(this.btnSelectAll);
            this.Name = "CtlQueryAdmDossiersLoeschen";
            this.Load += new System.EventHandler(this.CtlQueryBaDossiersLoeschen_Load);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.btnSelectAll, 0);
            this.Controls.SetChildIndex(this.btnSelectNone, 0);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            this.tpgSuchen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKostenstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheSAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKostenstelle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKostenstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheJahr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheJahr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryQueryOrphans)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KissLookUpEdit edtSucheKostenstelle;
        private KissLookUpEdit edtSucheMitarbeiter;
        private KiSS4.Gui.KissLabel lblSucheKostenstelle;
        private KissLabel lblSucheSAR;
        private KissButton btnDossiersLoeschen;
        private DevExpress.XtraGrid.Columns.GridColumn colSelektiert;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colLetzteZeiterfassung;
        private DevExpress.XtraGrid.Columns.GridColumn colFallverlaufNichtAbgeschlossen;
        private KissLabel lblSucheJahr;
        private DevExpress.XtraGrid.Columns.GridColumn colFallverantwortlich;
        private KissIntEdit edtSucheJahr;
        private DevExpress.XtraGrid.Columns.GridColumn colNr;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private DevExpress.XtraGrid.Columns.GridColumn gridKostenstelle;
        private DevExpress.XtraGrid.Columns.GridColumn colKGS;
        private DevExpress.XtraGrid.Columns.GridColumn colPLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colBezirk;
        private DevExpress.XtraGrid.Columns.GridColumn colKanton;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalitaet;
        private DevExpress.XtraGrid.Columns.GridColumn colGeschlecht;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colAlter;
        private DevExpress.XtraGrid.Columns.GridColumn colVersichertennummer;
        private DevExpress.XtraGrid.Columns.GridColumn colHauptbehinderungsart;
        private DevExpress.XtraGrid.Columns.GridColumn colBSVBehinderungsart;
        private DevExpress.XtraGrid.Columns.GridColumn colIVBerechtigung;
        private KissButton btnSelectNone;
        private KissButton btnSelectAll;
        private System.Windows.Forms.CheckBox cbVerwaistePersonen;
        private SqlQuery qryQueryOrphans;
        private System.ComponentModel.IContainer components;
    }
}