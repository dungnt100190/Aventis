using System.Security.AccessControl;

using DevExpress.XtraGrid.Views.Grid;

namespace KiSS4.Klientenbuchhaltung.ZH
{
    partial class CtlKbBelegeKorrigierenMasse
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKbBelegeKorrigierenMasse));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdKbBelegeKorrigierenMasse = new KiSS4.Gui.KissGrid();
            this.qryKbBelegKorrekturMasse = new KiSS4.DB.SqlQuery(this.components);
            this.grvKbBelegeKorrigierenMasse = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colVerwPeriodeVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerwPeriodeBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnEffektivesZahldatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnBudgetId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grideditLA = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colSplitting = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridedtKlient = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colEinnahme = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAusgabe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDritte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValuta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grideditStatus = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colBruttoBeleg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuswahl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridedtAuswahl = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colFehlermeldung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetragDetail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblSucheFallNr = new KiSS4.Gui.KissLabel();
            this.edtSucheFallNr = new KiSS4.Gui.KissCalcEdit();
            this.lblSucheLeistungstraeger = new KiSS4.Gui.KissLabel();
            this.lblSucheVerwPeriodeBis = new KiSS4.Gui.KissLabel();
            this.lblSucheVerwPeriodeVon = new KiSS4.Gui.KissLabel();
            this.edtSucheVerwDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtSucheVerwDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtSucheLeistungstraeger = new KiSS4.Gui.KissButtonEdit();
            this.lblKlientLeerGanzeUe = new KiSS4.Gui.KissLabel();
            this.edtSuchKlient = new KiSS4.Gui.KissLookUpEdit();
            this.lblKlient = new KiSS4.Gui.KissLabel();
            this.edtLeistungsarten = new KiSS4.Gui.KissDoubleListSelector();
            this.lblLeistungsart = new KiSS4.Gui.KissLabel();
            this.lblInfoZuSpalten = new KiSS4.Gui.KissLabel();
            this.btnAusfuehren = new KiSS4.Gui.KissButton();
            this.btnUmbuchungsjournal = new KiSS4.Gui.KissButton();
            this.btnNeuWerteSetzen = new KiSS4.Gui.KissButton();
            this.btnAlle = new KiSS4.Gui.KissButton();
            this.btnKeine = new KiSS4.Gui.KissButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSelectInfo = new KiSS4.Gui.KissLabel();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdKbBelegeKorrigierenMasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKbBelegKorrekturMasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKbBelegeKorrigierenMasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grideditLA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridedtKlient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grideditStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridedtAuswahl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheFallNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFallNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheLeistungstraeger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVerwPeriodeBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVerwPeriodeVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVerwDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVerwDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheLeistungstraeger.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientLeerGanzeUe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchKlient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchKlient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInfoZuSpalten)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSelectInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(1269, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSearch.Location = new System.Drawing.Point(3, 29);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(1293, 489);
            this.tabControlSearch.TabIndex = 1;
            this.tabControlSearch.SelectedTabChanging += new System.ComponentModel.CancelEventHandler(this.tabControlSearch_SelectedTabChanging);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdKbBelegeKorrigierenMasse);
            this.tpgListe.Size = new System.Drawing.Size(1281, 451);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.lblLeistungsart);
            this.tpgSuchen.Controls.Add(this.edtLeistungsarten);
            this.tpgSuchen.Controls.Add(this.lblKlientLeerGanzeUe);
            this.tpgSuchen.Controls.Add(this.edtSuchKlient);
            this.tpgSuchen.Controls.Add(this.lblKlient);
            this.tpgSuchen.Controls.Add(this.edtSucheLeistungstraeger);
            this.tpgSuchen.Controls.Add(this.lblSucheVerwPeriodeBis);
            this.tpgSuchen.Controls.Add(this.lblSucheVerwPeriodeVon);
            this.tpgSuchen.Controls.Add(this.edtSucheVerwDatumBis);
            this.tpgSuchen.Controls.Add(this.edtSucheVerwDatumVon);
            this.tpgSuchen.Controls.Add(this.lblSucheLeistungstraeger);
            this.tpgSuchen.Controls.Add(this.lblSucheFallNr);
            this.tpgSuchen.Controls.Add(this.edtSucheFallNr);
            this.tpgSuchen.Size = new System.Drawing.Size(1281, 451);
            this.tpgSuchen.TabIndex = 0;
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheFallNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheFallNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheLeistungstraeger, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheVerwDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheVerwDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheVerwPeriodeVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheVerwPeriodeBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheLeistungstraeger, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblKlient, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSuchKlient, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblKlientLeerGanzeUe, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtLeistungsarten, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblLeistungsart, 0);
            // 
            // grdKbBelegeKorrigierenMasse
            // 
            this.grdKbBelegeKorrigierenMasse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdKbBelegeKorrigierenMasse.DataSource = this.qryKbBelegKorrekturMasse;
            // 
            // 
            // 
            this.grdKbBelegeKorrigierenMasse.EmbeddedNavigator.CausesValidation = false;
            this.grdKbBelegeKorrigierenMasse.EmbeddedNavigator.Name = "";
            this.grdKbBelegeKorrigierenMasse.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdKbBelegeKorrigierenMasse.Location = new System.Drawing.Point(0, 0);
            this.grdKbBelegeKorrigierenMasse.MainView = this.grvKbBelegeKorrigierenMasse;
            this.grdKbBelegeKorrigierenMasse.Name = "grdKbBelegeKorrigierenMasse";
            this.grdKbBelegeKorrigierenMasse.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.grideditStatus,
            this.grideditLA,
            this.gridedtKlient,
            this.gridedtAuswahl});
            this.grdKbBelegeKorrigierenMasse.Size = new System.Drawing.Size(1281, 441);
            this.grdKbBelegeKorrigierenMasse.TabIndex = 0;
            this.grdKbBelegeKorrigierenMasse.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKbBelegeKorrigierenMasse});
            this.grdKbBelegeKorrigierenMasse.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.grdKbBelegeKorrigierenMasse_ProcessGridKey);
            // 
            // qryKbBelegKorrekturMasse
            // 
            this.qryKbBelegKorrekturMasse.BatchUpdate = true;
            this.qryKbBelegKorrekturMasse.CanUpdate = true;
            this.qryKbBelegKorrekturMasse.FillTimeOut = 300;
            this.qryKbBelegKorrekturMasse.HostControl = this;
            this.qryKbBelegKorrekturMasse.SelectStatement = "-- in FillMainQuery()";
            // 
            // grvKbBelegeKorrigierenMasse
            // 
            this.grvKbBelegeKorrigierenMasse.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvKbBelegeKorrigierenMasse.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBelegeKorrigierenMasse.Appearance.Empty.Options.UseBackColor = true;
            this.grvKbBelegeKorrigierenMasse.Appearance.Empty.Options.UseFont = true;
            this.grvKbBelegeKorrigierenMasse.Appearance.EvenRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvKbBelegeKorrigierenMasse.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBelegeKorrigierenMasse.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvKbBelegeKorrigierenMasse.Appearance.EvenRow.Options.UseFont = true;
            this.grvKbBelegeKorrigierenMasse.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.grvKbBelegeKorrigierenMasse.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBelegeKorrigierenMasse.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvKbBelegeKorrigierenMasse.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKbBelegeKorrigierenMasse.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKbBelegeKorrigierenMasse.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKbBelegeKorrigierenMasse.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvKbBelegeKorrigierenMasse.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBelegeKorrigierenMasse.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.grvKbBelegeKorrigierenMasse.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKbBelegeKorrigierenMasse.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKbBelegeKorrigierenMasse.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKbBelegeKorrigierenMasse.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grvKbBelegeKorrigierenMasse.Appearance.FooterPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grvKbBelegeKorrigierenMasse.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvKbBelegeKorrigierenMasse.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Blue;
            this.grvKbBelegeKorrigierenMasse.Appearance.FooterPanel.Options.UseFont = true;
            this.grvKbBelegeKorrigierenMasse.Appearance.FooterPanel.Options.UseForeColor = true;
            this.grvKbBelegeKorrigierenMasse.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvKbBelegeKorrigierenMasse.Appearance.GroupFooter.Options.UseFont = true;
            this.grvKbBelegeKorrigierenMasse.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbBelegeKorrigierenMasse.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKbBelegeKorrigierenMasse.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbBelegeKorrigierenMasse.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKbBelegeKorrigierenMasse.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKbBelegeKorrigierenMasse.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKbBelegeKorrigierenMasse.Appearance.GroupRow.Options.UseFont = true;
            this.grvKbBelegeKorrigierenMasse.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKbBelegeKorrigierenMasse.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKbBelegeKorrigierenMasse.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKbBelegeKorrigierenMasse.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKbBelegeKorrigierenMasse.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKbBelegeKorrigierenMasse.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKbBelegeKorrigierenMasse.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKbBelegeKorrigierenMasse.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvKbBelegeKorrigierenMasse.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBelegeKorrigierenMasse.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKbBelegeKorrigierenMasse.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKbBelegeKorrigierenMasse.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKbBelegeKorrigierenMasse.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKbBelegeKorrigierenMasse.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.grvKbBelegeKorrigierenMasse.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvKbBelegeKorrigierenMasse.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBelegeKorrigierenMasse.Appearance.OddRow.Options.UseFont = true;
            this.grvKbBelegeKorrigierenMasse.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.grvKbBelegeKorrigierenMasse.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBelegeKorrigierenMasse.Appearance.Row.Options.UseBackColor = true;
            this.grvKbBelegeKorrigierenMasse.Appearance.Row.Options.UseFont = true;
            this.grvKbBelegeKorrigierenMasse.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvKbBelegeKorrigierenMasse.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBelegeKorrigierenMasse.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvKbBelegeKorrigierenMasse.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvKbBelegeKorrigierenMasse.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKbBelegeKorrigierenMasse.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvKbBelegeKorrigierenMasse.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.grvKbBelegeKorrigierenMasse.Appearance.VertLine.Options.UseBackColor = true;
            this.grvKbBelegeKorrigierenMasse.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKbBelegeKorrigierenMasse.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colVerwPeriodeVon,
            this.colVerwPeriodeBis,
            this.gridColumnEffektivesZahldatum,
            this.gridColumnBudgetId,
            this.colLA,
            this.colSplitting,
            this.colBuchungstext,
            this.colKlient,
            this.colEinnahme,
            this.colAusgabe,
            this.colSD,
            this.colDritte,
            this.colBar,
            this.colDoc,
            this.colValuta,
            this.colSta,
            this.colBruttoBeleg,
            this.colAuswahl,
            this.colFehlermeldung});
            this.grvKbBelegeKorrigierenMasse.GridControl = this.grdKbBelegeKorrigierenMasse;
            this.grvKbBelegeKorrigierenMasse.Name = "grvKbBelegeKorrigierenMasse";
            this.grvKbBelegeKorrigierenMasse.OptionsCustomization.AllowFilter = false;
            this.grvKbBelegeKorrigierenMasse.OptionsDetail.ShowDetailTabs = false;
            this.grvKbBelegeKorrigierenMasse.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKbBelegeKorrigierenMasse.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKbBelegeKorrigierenMasse.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.grvKbBelegeKorrigierenMasse.OptionsSelection.EnableAppearanceHideSelection = false;
            this.grvKbBelegeKorrigierenMasse.OptionsView.ColumnAutoWidth = false;
            this.grvKbBelegeKorrigierenMasse.OptionsView.ShowChildrenInGroupPanel = true;
            this.grvKbBelegeKorrigierenMasse.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvKbBelegeKorrigierenMasse.OptionsView.ShowFooter = true;
            this.grvKbBelegeKorrigierenMasse.OptionsView.ShowGroupPanel = false;
            this.grvKbBelegeKorrigierenMasse.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grvKbBelegeKorrigierenMasse_RowCellStyle);
            this.grvKbBelegeKorrigierenMasse.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.grvKbBelegeKorrigierenMasse_ShowingEditor);
            this.grvKbBelegeKorrigierenMasse.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvKbBelegeKorrigierenMasse_CellValueChanging);
            // 
            // colVerwPeriodeVon
            // 
            this.colVerwPeriodeVon.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colVerwPeriodeVon.AppearanceCell.Options.UseBackColor = true;
            this.colVerwPeriodeVon.Caption = "Verw. von";
            this.colVerwPeriodeVon.DisplayFormat.FormatString = "d";
            this.colVerwPeriodeVon.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colVerwPeriodeVon.Name = "colVerwPeriodeVon";
            this.colVerwPeriodeVon.Visible = true;
            this.colVerwPeriodeVon.VisibleIndex = 0;
            this.colVerwPeriodeVon.Width = 87;
            // 
            // colVerwPeriodeBis
            // 
            this.colVerwPeriodeBis.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colVerwPeriodeBis.AppearanceCell.Options.UseBackColor = true;
            this.colVerwPeriodeBis.Caption = "Verw. bis";
            this.colVerwPeriodeBis.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colVerwPeriodeBis.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colVerwPeriodeBis.Name = "colVerwPeriodeBis";
            this.colVerwPeriodeBis.Visible = true;
            this.colVerwPeriodeBis.VisibleIndex = 1;
            this.colVerwPeriodeBis.Width = 87;
            // 
            // gridColumnEffektivesZahldatum
            // 
            this.gridColumnEffektivesZahldatum.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridColumnEffektivesZahldatum.AppearanceCell.Options.UseBackColor = true;
            this.gridColumnEffektivesZahldatum.Caption = "Eff. Zahldatum";
            this.gridColumnEffektivesZahldatum.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gridColumnEffektivesZahldatum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumnEffektivesZahldatum.Name = "gridColumnEffektivesZahldatum";
            this.gridColumnEffektivesZahldatum.OptionsColumn.AllowEdit = false;
            this.gridColumnEffektivesZahldatum.OptionsColumn.AllowFocus = false;
            this.gridColumnEffektivesZahldatum.Visible = true;
            this.gridColumnEffektivesZahldatum.VisibleIndex = 2;
            // 
            // gridColumnBudgetId
            // 
            this.gridColumnBudgetId.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridColumnBudgetId.AppearanceCell.Options.UseBackColor = true;
            this.gridColumnBudgetId.Caption = "Budget";
            this.gridColumnBudgetId.Name = "gridColumnBudgetId";
            this.gridColumnBudgetId.OptionsColumn.AllowEdit = false;
            this.gridColumnBudgetId.OptionsColumn.AllowFocus = false;
            this.gridColumnBudgetId.Visible = true;
            this.gridColumnBudgetId.VisibleIndex = 3;
            this.gridColumnBudgetId.Width = 49;
            // 
            // colLA
            // 
            this.colLA.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colLA.AppearanceCell.Options.UseBackColor = true;
            this.colLA.Caption = "LA";
            this.colLA.ColumnEdit = this.grideditLA;
            this.colLA.Name = "colLA";
            this.colLA.Visible = true;
            this.colLA.VisibleIndex = 4;
            this.colLA.Width = 49;
            // 
            // grideditLA
            // 
            this.grideditLA.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grideditLA.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grideditLA.AppearanceDropDown.Options.UseBackColor = true;
            this.grideditLA.AppearanceDropDown.Options.UseFont = true;
            this.grideditLA.AutoHeight = false;
            this.grideditLA.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.grideditLA.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("KontoNr", "KontoNr", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 140)});
            this.grideditLA.DisplayMember = "KontoNr";
            this.grideditLA.Name = "grideditLA";
            this.grideditLA.NullText = "";
            this.grideditLA.PopupFormWidth = 300;
            this.grideditLA.PopupWidth = 300;
            this.grideditLA.ShowFooter = false;
            this.grideditLA.ShowHeader = false;
            this.grideditLA.ValueMember = "BgKostenartID";
            // 
            // colSplitting
            // 
            this.colSplitting.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colSplitting.AppearanceCell.Options.UseBackColor = true;
            this.colSplitting.AppearanceCell.Options.UseTextOptions = true;
            this.colSplitting.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSplitting.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSplitting.Caption = "s";
            this.colSplitting.Name = "colSplitting";
            this.colSplitting.OptionsColumn.AllowEdit = false;
            this.colSplitting.OptionsColumn.AllowFocus = false;
            this.colSplitting.Visible = true;
            this.colSplitting.VisibleIndex = 5;
            this.colSplitting.Width = 20;
            // 
            // colBuchungstext
            // 
            this.colBuchungstext.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBuchungstext.AppearanceCell.Options.UseBackColor = true;
            this.colBuchungstext.Caption = "Buchungstext";
            this.colBuchungstext.Name = "colBuchungstext";
            this.colBuchungstext.Visible = true;
            this.colBuchungstext.VisibleIndex = 6;
            this.colBuchungstext.Width = 200;
            // 
            // colKlient
            // 
            this.colKlient.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colKlient.AppearanceCell.Options.UseBackColor = true;
            this.colKlient.Caption = "Klient/in";
            this.colKlient.ColumnEdit = this.gridedtKlient;
            this.colKlient.Name = "colKlient";
            this.colKlient.Visible = true;
            this.colKlient.VisibleIndex = 7;
            this.colKlient.Width = 140;
            // 
            // gridedtKlient
            // 
            this.gridedtKlient.AutoHeight = false;
            this.gridedtKlient.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.gridedtKlient.Name = "gridedtKlient";
            this.gridedtKlient.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.gridedtKlient_ButtonEdit);
            // 
            // colEinnahme
            // 
            this.colEinnahme.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colEinnahme.AppearanceCell.Options.UseBackColor = true;
            this.colEinnahme.Caption = "Einnahme";
            this.colEinnahme.DisplayFormat.FormatString = "n2";
            this.colEinnahme.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colEinnahme.Name = "colEinnahme";
            this.colEinnahme.OptionsColumn.AllowEdit = false;
            this.colEinnahme.OptionsColumn.AllowFocus = false;
            this.colEinnahme.SummaryItem.DisplayFormat = "{0:n2}";
            this.colEinnahme.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colEinnahme.Visible = true;
            this.colEinnahme.VisibleIndex = 8;
            this.colEinnahme.Width = 90;
            // 
            // colAusgabe
            // 
            this.colAusgabe.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colAusgabe.AppearanceCell.Options.UseBackColor = true;
            this.colAusgabe.Caption = "Ausgabe";
            this.colAusgabe.DisplayFormat.FormatString = "n2";
            this.colAusgabe.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAusgabe.Name = "colAusgabe";
            this.colAusgabe.OptionsColumn.AllowEdit = false;
            this.colAusgabe.OptionsColumn.AllowFocus = false;
            this.colAusgabe.SummaryItem.DisplayFormat = "{0:n2}";
            this.colAusgabe.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colAusgabe.Visible = true;
            this.colAusgabe.VisibleIndex = 9;
            this.colAusgabe.Width = 90;
            // 
            // colSD
            // 
            this.colSD.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colSD.AppearanceCell.Options.UseBackColor = true;
            this.colSD.AppearanceCell.Options.UseTextOptions = true;
            this.colSD.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSD.Caption = "S";
            this.colSD.Name = "colSD";
            this.colSD.OptionsColumn.AllowEdit = false;
            this.colSD.OptionsColumn.AllowFocus = false;
            this.colSD.Visible = true;
            this.colSD.VisibleIndex = 10;
            this.colSD.Width = 20;
            // 
            // colDritte
            // 
            this.colDritte.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colDritte.AppearanceCell.Options.UseBackColor = true;
            this.colDritte.AppearanceCell.Options.UseTextOptions = true;
            this.colDritte.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDritte.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDritte.Caption = "D";
            this.colDritte.Name = "colDritte";
            this.colDritte.OptionsColumn.AllowEdit = false;
            this.colDritte.OptionsColumn.AllowFocus = false;
            this.colDritte.Visible = true;
            this.colDritte.VisibleIndex = 11;
            this.colDritte.Width = 20;
            // 
            // colBar
            // 
            this.colBar.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBar.AppearanceCell.Options.UseBackColor = true;
            this.colBar.AppearanceCell.Options.UseTextOptions = true;
            this.colBar.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBar.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBar.Caption = "b";
            this.colBar.Name = "colBar";
            this.colBar.OptionsColumn.AllowEdit = false;
            this.colBar.OptionsColumn.AllowFocus = false;
            this.colBar.Visible = true;
            this.colBar.VisibleIndex = 12;
            this.colBar.Width = 20;
            // 
            // colDoc
            // 
            this.colDoc.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colDoc.AppearanceCell.Options.UseBackColor = true;
            this.colDoc.AppearanceCell.Options.UseTextOptions = true;
            this.colDoc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDoc.Caption = "Dok";
            this.colDoc.Name = "colDoc";
            this.colDoc.OptionsColumn.AllowEdit = false;
            this.colDoc.OptionsColumn.AllowFocus = false;
            this.colDoc.Visible = true;
            this.colDoc.VisibleIndex = 13;
            this.colDoc.Width = 31;
            // 
            // colValuta
            // 
            this.colValuta.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colValuta.AppearanceCell.Options.UseBackColor = true;
            this.colValuta.Caption = "Valuta";
            this.colValuta.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colValuta.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colValuta.Name = "colValuta";
            this.colValuta.Visible = true;
            this.colValuta.VisibleIndex = 14;
            this.colValuta.Width = 87;
            // 
            // colSta
            // 
            this.colSta.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colSta.AppearanceCell.Options.UseBackColor = true;
            this.colSta.Caption = "St.";
            this.colSta.ColumnEdit = this.grideditStatus;
            this.colSta.Name = "colSta";
            this.colSta.OptionsColumn.AllowEdit = false;
            this.colSta.OptionsColumn.AllowFocus = false;
            this.colSta.Visible = true;
            this.colSta.VisibleIndex = 15;
            this.colSta.Width = 27;
            // 
            // grideditStatus
            // 
            this.grideditStatus.AutoHeight = false;
            this.grideditStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.grideditStatus.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grideditStatus.Name = "grideditStatus";
            // 
            // colBruttoBeleg
            // 
            this.colBruttoBeleg.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBruttoBeleg.AppearanceCell.Options.UseBackColor = true;
            this.colBruttoBeleg.Caption = "Brutto Beleg";
            this.colBruttoBeleg.Name = "colBruttoBeleg";
            this.colBruttoBeleg.OptionsColumn.AllowEdit = false;
            this.colBruttoBeleg.OptionsColumn.AllowFocus = false;
            this.colBruttoBeleg.Visible = true;
            this.colBruttoBeleg.VisibleIndex = 16;
            this.colBruttoBeleg.Width = 90;
            // 
            // colAuswahl
            // 
            this.colAuswahl.Caption = "Ausw.";
            this.colAuswahl.ColumnEdit = this.gridedtAuswahl;
            this.colAuswahl.Name = "colAuswahl";
            this.colAuswahl.Visible = true;
            this.colAuswahl.VisibleIndex = 17;
            // 
            // gridedtAuswahl
            // 
            this.gridedtAuswahl.AutoHeight = false;
            this.gridedtAuswahl.Name = "gridedtAuswahl";
            this.gridedtAuswahl.CheckedChanged += new System.EventHandler(this.gridedtAuswahl_CheckedChanged);
            // 
            // colFehlermeldung
            // 
            this.colFehlermeldung.Caption = "Fehlermeldung";
            this.colFehlermeldung.Name = "colFehlermeldung";
            this.colFehlermeldung.Width = 100;
            // 
            // colBetragDetail
            // 
            this.colBetragDetail.Caption = "Betrag";
            this.colBetragDetail.DisplayFormat.FormatString = "n2";
            this.colBetragDetail.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetragDetail.Name = "colBetragDetail";
            this.colBetragDetail.Visible = true;
            this.colBetragDetail.VisibleIndex = 2;
            this.colBetragDetail.Width = 70;
            // 
            // lblSucheFallNr
            // 
            this.lblSucheFallNr.Location = new System.Drawing.Point(11, 38);
            this.lblSucheFallNr.Name = "lblSucheFallNr";
            this.lblSucheFallNr.Size = new System.Drawing.Size(130, 24);
            this.lblSucheFallNr.TabIndex = 1;
            this.lblSucheFallNr.Text = "Fallnummer";
            this.lblSucheFallNr.UseCompatibleTextRendering = true;
            // 
            // edtSucheFallNr
            // 
            this.edtSucheFallNr.Location = new System.Drawing.Point(147, 38);
            this.edtSucheFallNr.Name = "edtSucheFallNr";
            this.edtSucheFallNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheFallNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheFallNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheFallNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheFallNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheFallNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheFallNr.Properties.Appearance.Options.UseFont = true;
            this.edtSucheFallNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheFallNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheFallNr.Size = new System.Drawing.Size(256, 24);
            this.edtSucheFallNr.TabIndex = 2;
            this.edtSucheFallNr.LostFocus += new System.EventHandler(this.edtSucheFallNr_LostFocus);
            // 
            // lblSucheLeistungstraeger
            // 
            this.lblSucheLeistungstraeger.Location = new System.Drawing.Point(11, 68);
            this.lblSucheLeistungstraeger.Name = "lblSucheLeistungstraeger";
            this.lblSucheLeistungstraeger.Size = new System.Drawing.Size(130, 24);
            this.lblSucheLeistungstraeger.TabIndex = 3;
            this.lblSucheLeistungstraeger.Text = "Leistungsträger/in";
            this.lblSucheLeistungstraeger.UseCompatibleTextRendering = true;
            // 
            // lblSucheVerwPeriodeBis
            // 
            this.lblSucheVerwPeriodeBis.Location = new System.Drawing.Point(263, 128);
            this.lblSucheVerwPeriodeBis.Name = "lblSucheVerwPeriodeBis";
            this.lblSucheVerwPeriodeBis.Size = new System.Drawing.Size(21, 24);
            this.lblSucheVerwPeriodeBis.TabIndex = 10;
            this.lblSucheVerwPeriodeBis.Text = "bis";
            this.lblSucheVerwPeriodeBis.UseCompatibleTextRendering = true;
            // 
            // lblSucheVerwPeriodeVon
            // 
            this.lblSucheVerwPeriodeVon.Location = new System.Drawing.Point(11, 128);
            this.lblSucheVerwPeriodeVon.Name = "lblSucheVerwPeriodeVon";
            this.lblSucheVerwPeriodeVon.Size = new System.Drawing.Size(130, 24);
            this.lblSucheVerwPeriodeVon.TabIndex = 8;
            this.lblSucheVerwPeriodeVon.Text = "Verwendungsperiode";
            this.lblSucheVerwPeriodeVon.UseCompatibleTextRendering = true;
            // 
            // edtSucheVerwDatumBis
            // 
            this.edtSucheVerwDatumBis.EditValue = null;
            this.edtSucheVerwDatumBis.Location = new System.Drawing.Point(302, 128);
            this.edtSucheVerwDatumBis.Name = "edtSucheVerwDatumBis";
            this.edtSucheVerwDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheVerwDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheVerwDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheVerwDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheVerwDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheVerwDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheVerwDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheVerwDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtSucheVerwDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheVerwDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtSucheVerwDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheVerwDatumBis.Properties.ShowToday = false;
            this.edtSucheVerwDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtSucheVerwDatumBis.TabIndex = 11;
            // 
            // edtSucheVerwDatumVon
            // 
            this.edtSucheVerwDatumVon.EditValue = null;
            this.edtSucheVerwDatumVon.Location = new System.Drawing.Point(147, 128);
            this.edtSucheVerwDatumVon.Name = "edtSucheVerwDatumVon";
            this.edtSucheVerwDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheVerwDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheVerwDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheVerwDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheVerwDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheVerwDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheVerwDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheVerwDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtSucheVerwDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheVerwDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtSucheVerwDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheVerwDatumVon.Properties.ShowToday = false;
            this.edtSucheVerwDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtSucheVerwDatumVon.TabIndex = 9;
            // 
            // edtSucheLeistungstraeger
            // 
            this.edtSucheLeistungstraeger.Location = new System.Drawing.Point(147, 68);
            this.edtSucheLeistungstraeger.Name = "edtSucheLeistungstraeger";
            this.edtSucheLeistungstraeger.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheLeistungstraeger.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheLeistungstraeger.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheLeistungstraeger.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheLeistungstraeger.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheLeistungstraeger.Properties.Appearance.Options.UseFont = true;
            this.edtSucheLeistungstraeger.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtSucheLeistungstraeger.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtSucheLeistungstraeger.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheLeistungstraeger.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSucheLeistungstraeger.Size = new System.Drawing.Size(256, 24);
            this.edtSucheLeistungstraeger.TabIndex = 4;
            this.edtSucheLeistungstraeger.LookupIDChanged += new System.EventHandler(this.edtSucheLeistungstraeger_LookupIDChanged);
            this.edtSucheLeistungstraeger.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheLeistungstraeger_UserModifiedFld);
            // 
            // lblKlientLeerGanzeUe
            // 
            this.lblKlientLeerGanzeUe.Location = new System.Drawing.Point(407, 99);
            this.lblKlientLeerGanzeUe.Name = "lblKlientLeerGanzeUe";
            this.lblKlientLeerGanzeUe.Size = new System.Drawing.Size(92, 24);
            this.lblKlientLeerGanzeUe.TabIndex = 7;
            this.lblKlientLeerGanzeUe.Text = "(leer = ganze UE)";
            this.lblKlientLeerGanzeUe.UseCompatibleTextRendering = true;
            // 
            // edtSuchKlient
            // 
            this.edtSuchKlient.Location = new System.Drawing.Point(147, 98);
            this.edtSuchKlient.Name = "edtSuchKlient";
            this.edtSuchKlient.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSuchKlient.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSuchKlient.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSuchKlient.Properties.Appearance.Options.UseBackColor = true;
            this.edtSuchKlient.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSuchKlient.Properties.Appearance.Options.UseFont = true;
            this.edtSuchKlient.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSuchKlient.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSuchKlient.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSuchKlient.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSuchKlient.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSuchKlient.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSuchKlient.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSuchKlient.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "Person", 150),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Beziehung", "Beziehung", 80)});
            this.edtSuchKlient.Properties.DisplayMember = "Text";
            this.edtSuchKlient.Properties.NullText = "";
            this.edtSuchKlient.Properties.ShowFooter = false;
            this.edtSuchKlient.Properties.ShowHeader = false;
            this.edtSuchKlient.Properties.ValueMember = "BaPersonID";
            this.edtSuchKlient.Size = new System.Drawing.Size(255, 24);
            this.edtSuchKlient.TabIndex = 6;
            this.edtSuchKlient.ValueMember = "BaPersonID";
            // 
            // lblKlient
            // 
            this.lblKlient.Location = new System.Drawing.Point(10, 98);
            this.lblKlient.Name = "lblKlient";
            this.lblKlient.Size = new System.Drawing.Size(130, 24);
            this.lblKlient.TabIndex = 5;
            this.lblKlient.Text = "Klient/in";
            this.lblKlient.UseCompatibleTextRendering = true;
            // 
            // edtLeistungsarten
            // 
            this.edtLeistungsarten.ButtonRemoveAllVisible = false;
            this.edtLeistungsarten.Location = new System.Drawing.Point(143, 158);
            this.edtLeistungsarten.MaximumSize = new System.Drawing.Size(580, 210);
            this.edtLeistungsarten.MinimumSize = new System.Drawing.Size(580, 210);
            this.edtLeistungsarten.Name = "edtLeistungsarten";
            this.edtLeistungsarten.Size = new System.Drawing.Size(580, 210);
            this.edtLeistungsarten.TabIndex = 13;
            // 
            // lblLeistungsart
            // 
            this.lblLeistungsart.Location = new System.Drawing.Point(11, 158);
            this.lblLeistungsart.Name = "lblLeistungsart";
            this.lblLeistungsart.Size = new System.Drawing.Size(130, 24);
            this.lblLeistungsart.TabIndex = 12;
            this.lblLeistungsart.Text = "Leistungsarten";
            this.lblLeistungsart.UseCompatibleTextRendering = true;
            // 
            // lblInfoZuSpalten
            // 
            this.lblInfoZuSpalten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInfoZuSpalten.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblInfoZuSpalten.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblInfoZuSpalten.Location = new System.Drawing.Point(100, 497);
            this.lblInfoZuSpalten.Name = "lblInfoZuSpalten";
            this.lblInfoZuSpalten.Size = new System.Drawing.Size(309, 16);
            this.lblInfoZuSpalten.TabIndex = 2;
            this.lblInfoZuSpalten.Text = "s = splitting, S = abgetreten an SoD, D = Dritte, b = bar";
            this.lblInfoZuSpalten.UseCompatibleTextRendering = true;
            // 
            // btnAusfuehren
            // 
            this.btnAusfuehren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAusfuehren.Enabled = false;
            this.btnAusfuehren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAusfuehren.Location = new System.Drawing.Point(822, 507);
            this.btnAusfuehren.Name = "btnAusfuehren";
            this.btnAusfuehren.Size = new System.Drawing.Size(100, 24);
            this.btnAusfuehren.TabIndex = 4;
            this.btnAusfuehren.Text = "Ausführen";
            this.btnAusfuehren.UseCompatibleTextRendering = true;
            this.btnAusfuehren.UseVisualStyleBackColor = false;
            this.btnAusfuehren.Click += new System.EventHandler(this.btnAusfuehren_Click);
            // 
            // btnUmbuchungsjournal
            // 
            this.btnUmbuchungsjournal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUmbuchungsjournal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUmbuchungsjournal.Location = new System.Drawing.Point(928, 507);
            this.btnUmbuchungsjournal.Name = "btnUmbuchungsjournal";
            this.btnUmbuchungsjournal.Size = new System.Drawing.Size(136, 24);
            this.btnUmbuchungsjournal.TabIndex = 5;
            this.btnUmbuchungsjournal.Text = "Umbuchungsjournal";
            this.btnUmbuchungsjournal.UseCompatibleTextRendering = true;
            this.btnUmbuchungsjournal.UseVisualStyleBackColor = false;
            this.btnUmbuchungsjournal.Click += new System.EventHandler(this.btnUmbuchungsjournal_Click);
            // 
            // btnNeuWerteSetzen
            // 
            this.btnNeuWerteSetzen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNeuWerteSetzen.Enabled = false;
            this.btnNeuWerteSetzen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNeuWerteSetzen.Location = new System.Drawing.Point(692, 507);
            this.btnNeuWerteSetzen.Name = "btnNeuWerteSetzen";
            this.btnNeuWerteSetzen.Size = new System.Drawing.Size(124, 24);
            this.btnNeuWerteSetzen.TabIndex = 3;
            this.btnNeuWerteSetzen.Text = "Neue Werte setzen";
            this.btnNeuWerteSetzen.UseCompatibleTextRendering = true;
            this.btnNeuWerteSetzen.UseVisualStyleBackColor = false;
            this.btnNeuWerteSetzen.Click += new System.EventHandler(this.btnNeuWerteSetzen_Click);
            // 
            // btnAlle
            // 
            this.btnAlle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlle.Enabled = false;
            this.btnAlle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlle.Location = new System.Drawing.Point(1188, 507);
            this.btnAlle.Name = "btnAlle";
            this.btnAlle.Size = new System.Drawing.Size(48, 24);
            this.btnAlle.TabIndex = 6;
            this.btnAlle.Text = "Alle";
            this.btnAlle.UseCompatibleTextRendering = true;
            this.btnAlle.UseVisualStyleBackColor = false;
            this.btnAlle.Click += new System.EventHandler(this.btnAlle_Click);
            // 
            // btnKeine
            // 
            this.btnKeine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKeine.Enabled = false;
            this.btnKeine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeine.Location = new System.Drawing.Point(1242, 507);
            this.btnKeine.Name = "btnKeine";
            this.btnKeine.Size = new System.Drawing.Size(48, 24);
            this.btnKeine.TabIndex = 7;
            this.btnKeine.Text = "Keine";
            this.btnKeine.UseCompatibleTextRendering = true;
            this.btnKeine.UseVisualStyleBackColor = false;
            this.btnKeine.Click += new System.EventHandler(this.btnKeine_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.lblSelectInfo);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel2.Size = new System.Drawing.Size(1296, 23);
            this.panel2.TabIndex = 0;
            // 
            // lblSelectInfo
            // 
            this.lblSelectInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectInfo.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblSelectInfo.Location = new System.Drawing.Point(928, 2);
            this.lblSelectInfo.Name = "lblSelectInfo";
            this.lblSelectInfo.Size = new System.Drawing.Size(362, 19);
            this.lblSelectInfo.TabIndex = 0;
            this.lblSelectInfo.Text = "";
            this.lblSelectInfo.UseCompatibleTextRendering = true;
            // 
            // CtlKbBelegeKorrigierenMasse
            // 
            this.ActiveSQLQuery = this.qryKbBelegKorrekturMasse;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(1000, 200);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnKeine);
            this.Controls.Add(this.btnAlle);
            this.Controls.Add(this.btnNeuWerteSetzen);
            this.Controls.Add(this.btnUmbuchungsjournal);
            this.Controls.Add(this.btnAusfuehren);
            this.Controls.Add(this.lblInfoZuSpalten);
            this.Name = "CtlKbBelegeKorrigierenMasse";
            this.Size = new System.Drawing.Size(1296, 539);
            this.Load += new System.EventHandler(this.CtlKbBelegeKorrigierenMasse_Load);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.lblInfoZuSpalten, 0);
            this.Controls.SetChildIndex(this.btnAusfuehren, 0);
            this.Controls.SetChildIndex(this.btnUmbuchungsjournal, 0);
            this.Controls.SetChildIndex(this.btnNeuWerteSetzen, 0);
            this.Controls.SetChildIndex(this.btnAlle, 0);
            this.Controls.SetChildIndex(this.btnKeine, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdKbBelegeKorrigierenMasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKbBelegKorrekturMasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKbBelegeKorrigierenMasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grideditLA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridedtKlient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grideditStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridedtAuswahl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheFallNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFallNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheLeistungstraeger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVerwPeriodeBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVerwPeriodeVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVerwDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVerwDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheLeistungstraeger.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientLeerGanzeUe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchKlient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchKlient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInfoZuSpalten)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblSelectInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DB.SqlQuery qryKbBelegKorrekturMasse;
        private Gui.KissGrid grdKbBelegeKorrigierenMasse;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKbBelegeKorrigierenMasse;
        private DevExpress.XtraGrid.Columns.GridColumn colVerwPeriodeVon;
        private DevExpress.XtraGrid.Columns.GridColumn colVerwPeriodeBis;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnEffektivesZahldatum;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnBudgetId;
        private DevExpress.XtraGrid.Columns.GridColumn colLA;
        private DevExpress.XtraGrid.Columns.GridColumn colSplitting;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungstext;
        private DevExpress.XtraGrid.Columns.GridColumn colKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colEinnahme;
        private DevExpress.XtraGrid.Columns.GridColumn colAusgabe;
        private DevExpress.XtraGrid.Columns.GridColumn colSD;
        private DevExpress.XtraGrid.Columns.GridColumn colDritte;
        private DevExpress.XtraGrid.Columns.GridColumn colBar;
        private DevExpress.XtraGrid.Columns.GridColumn colDoc;
        private DevExpress.XtraGrid.Columns.GridColumn colValuta;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox grideditStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colBruttoBeleg;
        private DevExpress.XtraGrid.Columns.GridColumn colBetragDetail;
        private Gui.KissLabel lblSucheFallNr;
        private Gui.KissCalcEdit edtSucheFallNr;
        private Gui.KissLabel lblSucheLeistungstraeger;
        private Gui.KissLabel lblSucheVerwPeriodeBis;
        private Gui.KissLabel lblSucheVerwPeriodeVon;
        private Gui.KissDateEdit edtSucheVerwDatumBis;
        private Gui.KissDateEdit edtSucheVerwDatumVon;
        private Gui.KissButtonEdit edtSucheLeistungstraeger;
        private Gui.KissLabel lblKlientLeerGanzeUe;
        private Gui.KissLookUpEdit edtSuchKlient;
        private Gui.KissLabel lblKlient;
        private Gui.KissDoubleListSelector edtLeistungsarten;
        private Gui.KissLabel lblLeistungsart;
        private DevExpress.XtraGrid.Columns.GridColumn colSta;
        private DevExpress.XtraGrid.Columns.GridColumn colAuswahl;
        private Gui.KissLabel lblInfoZuSpalten;
        private Gui.KissButton btnAusfuehren;
        private Gui.KissButton btnUmbuchungsjournal;
        private Gui.KissButton btnKeine;
        private Gui.KissButton btnAlle;
        private Gui.KissButton btnNeuWerteSetzen;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit grideditLA;
        private System.Windows.Forms.Panel panel2;
        private Gui.KissLabel lblSelectInfo;
        private DevExpress.XtraGrid.Columns.GridColumn colFehlermeldung;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit gridedtKlient;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit gridedtAuswahl;
    }
}
