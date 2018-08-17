using System;
using System.Drawing;
using KiSS.KliBu.UI;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Fibu
{
    /// <summary>
    /// Summary description for CtlFibuBankPost.
    /// </summary>
    public class CtlFibuBankPost : KiSS4.Gui.KissUserControl
    {
        #region Fields

        #region Private Fields

        private KiSS4.Gui.KissButton btnBankHistory;
        private KiSS4.Gui.KissButton btnUpdate;
        private DevExpress.XtraGrid.Columns.GridColumn colClearingNr;
        private DevExpress.XtraGrid.Columns.GridColumn colClearingNrNeu;
        private DevExpress.XtraGrid.Columns.GridColumn colFilialeNr;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colPcKontoNr;
        private DevExpress.XtraGrid.Columns.GridColumn colPLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colSicUpdated;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasse;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissButtonEdit editClearingNr;
        private KiSS4.Gui.KissButtonEdit editName;
        private KiSS4.Gui.KissButtonEdit editStrasse;
        private KiSS4.Gui.KissButtonEdit editZusatz;
        private KissCheckEdit edtAuchInaktiveBanken;
        private KiSS4.Gui.KissButtonEdit edtClearingNrSearch;
        private KiSS4.Gui.KissButtonEdit edtNameSearch;
        private KiSS4.Gui.KissButtonEdit edtPCKontoNrSearch;
        private KiSS4.Common.KissPLZOrt edtPLZOrtSearch;
        private KiSS4.Gui.KissButtonEdit edtStrasseSearch;
        private KiSS4.Gui.KissButtonEdit edtZusatzSearch;
        private KiSS4.Gui.KissGrid grdBaBank;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBaBank;
        private KiSS4.Gui.KissButtonEdit kissButtonEdit1;
        private KissButtonEdit kissButtonEdit2;
        private KissButtonEdit kissButtonEdit3;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel kissLabel10;
        private KiSS4.Gui.KissLabel kissLabel11;
        private KiSS4.Gui.KissLabel kissLabel12;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissLabel kissLabel3;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel kissLabel5;
        private KiSS4.Gui.KissLabel kissLabel6;
        private KiSS4.Gui.KissLabel kissLabel7;
        private KiSS4.Gui.KissLabel kissLabel8;
        private KiSS4.Gui.KissLabel kissLabel9;
        private KiSS4.Common.KissPLZOrt kissPLZOrt1;
        private KiSS4.Gui.KissSearchTitel kissSearchTitel1;
        private KissLabel lblClearingNrNeu;
        private KissLabel lblFilialeNr;
        private KiSS4.Gui.KissLabel lblLastUpdate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private KiSS4.DB.SqlQuery qryBaBank;
        private KiSS4.Gui.KissTabControlEx tabControlSearch;
        private SharpLibrary.WinControls.TabPageEx tpgListe;
        private SharpLibrary.WinControls.TabPageEx tpgSuchen;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlFibuBankPost"/> class.
        /// </summary>
        public CtlFibuBankPost()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            this.grdBaBank.View.Columns["PCKontoNr"].DisplayFormat.Format = new GridColumnPCKontoFormatter();
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFibuBankPost));
            this.qryBaBank = new KiSS4.DB.SqlQuery(this.components);
            this.tabControlSearch = new KiSS4.Gui.KissTabControlEx();
            this.tpgListe = new SharpLibrary.WinControls.TabPageEx();
            this.grdBaBank = new KiSS4.Gui.KissGrid();
            this.grvBaBank = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPcKontoNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClearingNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFilialeNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClearingNrNeu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSicUpdated = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kissButtonEdit2 = new KiSS4.Gui.KissButtonEdit();
            this.kissButtonEdit3 = new KiSS4.Gui.KissButtonEdit();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.kissPLZOrt1 = new KiSS4.Common.KissPLZOrt();
            this.kissButtonEdit1 = new KiSS4.Gui.KissButtonEdit();
            this.editClearingNr = new KiSS4.Gui.KissButtonEdit();
            this.editStrasse = new KiSS4.Gui.KissButtonEdit();
            this.editZusatz = new KiSS4.Gui.KissButtonEdit();
            this.editName = new KiSS4.Gui.KissButtonEdit();
            this.lblClearingNrNeu = new KiSS4.Gui.KissLabel();
            this.lblFilialeNr = new KiSS4.Gui.KissLabel();
            this.kissLabel6 = new KiSS4.Gui.KissLabel();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.tpgSuchen = new SharpLibrary.WinControls.TabPageEx();
            this.panel2 = new System.Windows.Forms.Panel();
            this.edtAuchInaktiveBanken = new KiSS4.Gui.KissCheckEdit();
            this.kissSearchTitel1 = new KiSS4.Gui.KissSearchTitel();
            this.kissLabel7 = new KiSS4.Gui.KissLabel();
            this.kissLabel8 = new KiSS4.Gui.KissLabel();
            this.kissLabel9 = new KiSS4.Gui.KissLabel();
            this.kissLabel10 = new KiSS4.Gui.KissLabel();
            this.kissLabel11 = new KiSS4.Gui.KissLabel();
            this.kissLabel12 = new KiSS4.Gui.KissLabel();
            this.edtPLZOrtSearch = new KiSS4.Common.KissPLZOrt();
            this.edtPCKontoNrSearch = new KiSS4.Gui.KissButtonEdit();
            this.edtClearingNrSearch = new KiSS4.Gui.KissButtonEdit();
            this.edtZusatzSearch = new KiSS4.Gui.KissButtonEdit();
            this.edtStrasseSearch = new KiSS4.Gui.KissButtonEdit();
            this.edtNameSearch = new KiSS4.Gui.KissButtonEdit();
            this.btnBankHistory = new KiSS4.Gui.KissButton();
            this.btnUpdate = new KiSS4.Gui.KissButton();
            this.lblLastUpdate = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaBank)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaBank)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissButtonEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissButtonEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissButtonEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editClearingNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editZusatz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblClearingNrNeu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilialeNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            this.tpgSuchen.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuchInaktiveBanken.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPCKontoNrSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtClearingNrSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasseSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLastUpdate)).BeginInit();
            this.SuspendLayout();
            //
            // qryBaBank
            //
            this.qryBaBank.HostControl = this;
            this.qryBaBank.SelectStatement = resources.GetString("qryBaBank.SelectStatement");
            this.qryBaBank.TableName = "BaBank";
            this.qryBaBank.AfterInsert += new System.EventHandler(this.qryBank_AfterInsert);
            this.qryBaBank.BeforePost += new System.EventHandler(this.qryBank_BeforePost);
            //
            // tabControlSearch
            //
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSearch.Controls.Add(this.tpgListe);
            this.tabControlSearch.Controls.Add(this.tpgSuchen);
            this.tabControlSearch.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.Name = "tabControlSearch";
            this.tabControlSearch.ShowFixedWidthTooltip = true;
            this.tabControlSearch.Size = new System.Drawing.Size(825, 535);
            this.tabControlSearch.TabIndex = 2;
            this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgListe,
            this.tpgSuchen});
            this.tabControlSearch.TabsLineColor = System.Drawing.Color.Black;
            this.tabControlSearch.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabControlSearch.TabStop = false;
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.grdBaBank);
            this.tpgListe.Controls.Add(this.panel1);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Name = "tpgListe";
            this.tpgListe.Size = new System.Drawing.Size(813, 497);
            this.tpgListe.TabIndex = 0;
            this.tpgListe.Title = "Liste";
            //
            // grdBaBank
            //
            this.grdBaBank.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBaBank.DataSource = this.qryBaBank;
            //
            //
            //
            this.grdBaBank.EmbeddedNavigator.Name = "";
            this.grdBaBank.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBaBank.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdBaBank.Location = new System.Drawing.Point(0, 0);
            this.grdBaBank.MainView = this.grvBaBank;
            this.grdBaBank.Name = "grdBaBank";
            this.grdBaBank.Size = new System.Drawing.Size(813, 377);
            this.grdBaBank.TabIndex = 5;
            this.grdBaBank.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBaBank});
            //
            // grvBaBank
            //
            this.grvBaBank.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBaBank.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaBank.Appearance.Empty.Options.UseBackColor = true;
            this.grvBaBank.Appearance.Empty.Options.UseFont = true;
            this.grvBaBank.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvBaBank.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaBank.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvBaBank.Appearance.EvenRow.Options.UseFont = true;
            this.grvBaBank.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaBank.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaBank.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBaBank.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBaBank.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBaBank.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBaBank.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaBank.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaBank.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBaBank.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBaBank.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBaBank.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBaBank.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaBank.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBaBank.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvBaBank.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvBaBank.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaBank.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBaBank.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaBank.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaBank.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaBank.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBaBank.Appearance.GroupRow.Options.UseFont = true;
            this.grvBaBank.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBaBank.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBaBank.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBaBank.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaBank.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBaBank.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBaBank.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBaBank.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBaBank.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaBank.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaBank.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBaBank.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBaBank.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBaBank.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaBank.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBaBank.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvBaBank.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaBank.Appearance.OddRow.Options.UseBackColor = true;
            this.grvBaBank.Appearance.OddRow.Options.UseFont = true;
            this.grvBaBank.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBaBank.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaBank.Appearance.Row.Options.UseBackColor = true;
            this.grvBaBank.Appearance.Row.Options.UseFont = true;
            this.grvBaBank.Appearance.RowSeparator.BackColor = System.Drawing.Color.Firebrick;
            this.grvBaBank.Appearance.RowSeparator.Options.UseBackColor = true;
            this.grvBaBank.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvBaBank.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaBank.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvBaBank.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvBaBank.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBaBank.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvBaBank.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaBank.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBaBank.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBaBank.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colStrasse,
            this.colPcKontoNr,
            this.colPLZ,
            this.colOrt,
            this.colClearingNr,
            this.colFilialeNr,
            this.colClearingNrNeu,
            this.colSicUpdated});
            this.grvBaBank.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBaBank.GridControl = this.grdBaBank;
            this.grvBaBank.Name = "grvBaBank";
            this.grvBaBank.OptionsBehavior.Editable = false;
            this.grvBaBank.OptionsCustomization.AllowFilter = false;
            this.grvBaBank.OptionsFilter.AllowFilterEditor = false;
            this.grvBaBank.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBaBank.OptionsMenu.EnableColumnMenu = false;
            this.grvBaBank.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBaBank.OptionsNavigation.UseTabKey = false;
            this.grvBaBank.OptionsView.ColumnAutoWidth = false;
            this.grvBaBank.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBaBank.OptionsView.ShowGroupPanel = false;
            this.grvBaBank.OptionsView.ShowIndicator = false;
            this.grvBaBank.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grvBaBank_CustomDrawCell);
            //
            // colName
            //
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 222;
            //
            // colStrasse
            //
            this.colStrasse.Caption = "Strasse";
            this.colStrasse.FieldName = "Strasse";
            this.colStrasse.Name = "colStrasse";
            this.colStrasse.Visible = true;
            this.colStrasse.VisibleIndex = 2;
            this.colStrasse.Width = 170;
            //
            // colPcKontoNr
            //
            this.colPcKontoNr.Caption = "PostKonto Nr";
            this.colPcKontoNr.FieldName = "PCKontoNr";
            this.colPcKontoNr.Name = "colPcKontoNr";
            this.colPcKontoNr.Visible = true;
            this.colPcKontoNr.VisibleIndex = 1;
            this.colPcKontoNr.Width = 95;
            //
            // colPLZ
            //
            this.colPLZ.Caption = "PLZ";
            this.colPLZ.FieldName = "PLZ";
            this.colPLZ.Name = "colPLZ";
            this.colPLZ.Visible = true;
            this.colPLZ.VisibleIndex = 3;
            this.colPLZ.Width = 74;
            //
            // colOrt
            //
            this.colOrt.Caption = "Ort";
            this.colOrt.FieldName = "Ort";
            this.colOrt.Name = "colOrt";
            this.colOrt.Visible = true;
            this.colOrt.VisibleIndex = 4;
            this.colOrt.Width = 139;
            //
            // colClearingNr
            //
            this.colClearingNr.Caption = "Clearing Nr";
            this.colClearingNr.FieldName = "ClearingNr";
            this.colClearingNr.Name = "colClearingNr";
            this.colClearingNr.Visible = true;
            this.colClearingNr.VisibleIndex = 5;
            //
            // colFilialeNr
            //
            this.colFilialeNr.Caption = "Filiale Nr";
            this.colFilialeNr.FieldName = "FilialeNr";
            this.colFilialeNr.Name = "colFilialeNr";
            this.colFilialeNr.Visible = true;
            this.colFilialeNr.VisibleIndex = 6;
            //
            // colClearingNrNeu
            //
            this.colClearingNrNeu.Caption = "neue Clearing Nr";
            this.colClearingNrNeu.FieldName = "ClearingNrNeu";
            this.colClearingNrNeu.Name = "colClearingNrNeu";
            this.colClearingNrNeu.Visible = true;
            this.colClearingNrNeu.VisibleIndex = 7;
            //
            // colSicUpdated
            //
            this.colSicUpdated.Caption = "SicUpdated";
            this.colSicUpdated.FieldName = "SicUpdated";
            this.colSicUpdated.Name = "colSicUpdated";
            this.colSicUpdated.Visible = true;
            this.colSicUpdated.VisibleIndex = 8;
            //
            // panel1
            //
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.panel1.Controls.Add(this.kissButtonEdit2);
            this.panel1.Controls.Add(this.kissButtonEdit3);
            this.panel1.Controls.Add(this.kissLabel4);
            this.panel1.Controls.Add(this.kissLabel3);
            this.panel1.Controls.Add(this.kissLabel2);
            this.panel1.Controls.Add(this.kissLabel1);
            this.panel1.Controls.Add(this.kissPLZOrt1);
            this.panel1.Controls.Add(this.kissButtonEdit1);
            this.panel1.Controls.Add(this.editClearingNr);
            this.panel1.Controls.Add(this.editStrasse);
            this.panel1.Controls.Add(this.editZusatz);
            this.panel1.Controls.Add(this.editName);
            this.panel1.Controls.Add(this.lblClearingNrNeu);
            this.panel1.Controls.Add(this.lblFilialeNr);
            this.panel1.Controls.Add(this.kissLabel6);
            this.panel1.Controls.Add(this.kissLabel5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 377);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(813, 120);
            this.panel1.TabIndex = 4;
            //
            // kissButtonEdit2
            //
            this.kissButtonEdit2.DataMember = "ClearingNrNeu";
            this.kissButtonEdit2.DataSource = this.qryBaBank;
            this.kissButtonEdit2.Location = new System.Drawing.Point(493, 78);
            this.kissButtonEdit2.Name = "kissButtonEdit2";
            this.kissButtonEdit2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.kissButtonEdit2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissButtonEdit2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissButtonEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.kissButtonEdit2.Properties.Appearance.Options.UseBorderColor = true;
            this.kissButtonEdit2.Properties.Appearance.Options.UseFont = true;
            this.kissButtonEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissButtonEdit2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.kissButtonEdit2.Properties.Name = "editClearingNr.Properties";
            this.kissButtonEdit2.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.kissButtonEdit2.Size = new System.Drawing.Size(280, 24);
            this.kissButtonEdit2.TabIndex = 325;
            //
            // kissButtonEdit3
            //
            this.kissButtonEdit3.DataMember = "FilialeNr";
            this.kissButtonEdit3.DataSource = this.qryBaBank;
            this.kissButtonEdit3.Location = new System.Drawing.Point(493, 32);
            this.kissButtonEdit3.Name = "kissButtonEdit3";
            this.kissButtonEdit3.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.kissButtonEdit3.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissButtonEdit3.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissButtonEdit3.Properties.Appearance.Options.UseBackColor = true;
            this.kissButtonEdit3.Properties.Appearance.Options.UseBorderColor = true;
            this.kissButtonEdit3.Properties.Appearance.Options.UseFont = true;
            this.kissButtonEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissButtonEdit3.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.kissButtonEdit3.Properties.Name = "editClearingNr.Properties";
            this.kissButtonEdit3.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.kissButtonEdit3.Size = new System.Drawing.Size(280, 24);
            this.kissButtonEdit3.TabIndex = 323;
            //
            // kissLabel4
            //
            this.kissLabel4.Location = new System.Drawing.Point(9, 78);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(64, 24);
            this.kissLabel4.TabIndex = 314;
            this.kissLabel4.Text = "Plz/Ort";
            //
            // kissLabel3
            //
            this.kissLabel3.Location = new System.Drawing.Point(9, 55);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(64, 24);
            this.kissLabel3.TabIndex = 313;
            this.kissLabel3.Text = "Strasse";
            //
            // kissLabel2
            //
            this.kissLabel2.Location = new System.Drawing.Point(9, 32);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(64, 24);
            this.kissLabel2.TabIndex = 312;
            this.kissLabel2.Text = "Zusatz";
            //
            // kissLabel1
            //
            this.kissLabel1.Location = new System.Drawing.Point(9, 9);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(64, 24);
            this.kissLabel1.TabIndex = 311;
            this.kissLabel1.Text = "Name";
            //
            // kissPLZOrt1
            //
            this.kissPLZOrt1.BackColor = System.Drawing.SystemColors.Control;
            this.kissPLZOrt1.DataMemberBaGemeindeID = null;
            this.kissPLZOrt1.DataSource = this.qryBaBank;
            this.kissPLZOrt1.Location = new System.Drawing.Point(83, 78);
            this.kissPLZOrt1.Name = "kissPLZOrt1";
            this.kissPLZOrt1.ShowKanton = false;
            this.kissPLZOrt1.ShowLand = false;
            this.kissPLZOrt1.Size = new System.Drawing.Size(285, 24);
            this.kissPLZOrt1.TabIndex = 3;
            //
            // kissButtonEdit1
            //
            this.kissButtonEdit1.DataMember = "PCKontoNr";
            this.kissButtonEdit1.DataSource = this.qryBaBank;
            this.kissButtonEdit1.Location = new System.Drawing.Point(493, 55);
            this.kissButtonEdit1.Name = "kissButtonEdit1";
            this.kissButtonEdit1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.kissButtonEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissButtonEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissButtonEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.kissButtonEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.kissButtonEdit1.Properties.Appearance.Options.UseFont = true;
            this.kissButtonEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissButtonEdit1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.kissButtonEdit1.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.kissButtonEdit1.Size = new System.Drawing.Size(280, 24);
            this.kissButtonEdit1.TabIndex = 5;
            this.kissButtonEdit1.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.kissButtonEdit1_ParseEditValue);
            this.kissButtonEdit1.FormatEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.kissButtonEdit1_FormatEditValue);
            //
            // editClearingNr
            //
            this.editClearingNr.DataMember = "ClearingNr";
            this.editClearingNr.DataSource = this.qryBaBank;
            this.editClearingNr.Location = new System.Drawing.Point(493, 9);
            this.editClearingNr.Name = "editClearingNr";
            this.editClearingNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editClearingNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editClearingNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editClearingNr.Properties.Appearance.Options.UseBackColor = true;
            this.editClearingNr.Properties.Appearance.Options.UseBorderColor = true;
            this.editClearingNr.Properties.Appearance.Options.UseFont = true;
            this.editClearingNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editClearingNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editClearingNr.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.editClearingNr.Size = new System.Drawing.Size(280, 24);
            this.editClearingNr.TabIndex = 4;
            //
            // editStrasse
            //
            this.editStrasse.DataMember = "Strasse";
            this.editStrasse.DataSource = this.qryBaBank;
            this.editStrasse.Location = new System.Drawing.Point(83, 55);
            this.editStrasse.Name = "editStrasse";
            this.editStrasse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.editStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.editStrasse.Properties.Appearance.Options.UseFont = true;
            this.editStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editStrasse.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editStrasse.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.editStrasse.Size = new System.Drawing.Size(285, 24);
            this.editStrasse.TabIndex = 2;
            //
            // editZusatz
            //
            this.editZusatz.DataMember = "Zusatz";
            this.editZusatz.DataSource = this.qryBaBank;
            this.editZusatz.Location = new System.Drawing.Point(83, 32);
            this.editZusatz.Name = "editZusatz";
            this.editZusatz.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editZusatz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editZusatz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editZusatz.Properties.Appearance.Options.UseBackColor = true;
            this.editZusatz.Properties.Appearance.Options.UseBorderColor = true;
            this.editZusatz.Properties.Appearance.Options.UseFont = true;
            this.editZusatz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editZusatz.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editZusatz.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.editZusatz.Size = new System.Drawing.Size(285, 24);
            this.editZusatz.TabIndex = 1;
            //
            // editName
            //
            this.editName.DataMember = "Name";
            this.editName.DataSource = this.qryBaBank;
            this.editName.Location = new System.Drawing.Point(83, 9);
            this.editName.Name = "editName";
            this.editName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editName.Properties.Appearance.Options.UseBackColor = true;
            this.editName.Properties.Appearance.Options.UseBorderColor = true;
            this.editName.Properties.Appearance.Options.UseFont = true;
            this.editName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editName.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editName.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.editName.Size = new System.Drawing.Size(285, 24);
            this.editName.TabIndex = 0;
            //
            // lblClearingNrNeu
            //
            this.lblClearingNrNeu.Location = new System.Drawing.Point(399, 78);
            this.lblClearingNrNeu.Name = "lblClearingNrNeu";
            this.lblClearingNrNeu.Size = new System.Drawing.Size(97, 24);
            this.lblClearingNrNeu.TabIndex = 326;
            this.lblClearingNrNeu.Text = "neue Clearing Nr";
            this.lblClearingNrNeu.UseCompatibleTextRendering = true;
            //
            // lblFilialeNr
            //
            this.lblFilialeNr.Location = new System.Drawing.Point(399, 32);
            this.lblFilialeNr.Name = "lblFilialeNr";
            this.lblFilialeNr.Size = new System.Drawing.Size(97, 24);
            this.lblFilialeNr.TabIndex = 324;
            this.lblFilialeNr.Text = "Filiale Nr";
            this.lblFilialeNr.UseCompatibleTextRendering = true;
            //
            // kissLabel6
            //
            this.kissLabel6.Location = new System.Drawing.Point(399, 56);
            this.kissLabel6.Name = "kissLabel6";
            this.kissLabel6.Size = new System.Drawing.Size(97, 24);
            this.kissLabel6.TabIndex = 316;
            this.kissLabel6.Text = "Postkonto Nr";
            //
            // kissLabel5
            //
            this.kissLabel5.Location = new System.Drawing.Point(399, 10);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(97, 24);
            this.kissLabel5.TabIndex = 315;
            this.kissLabel5.Text = "Clearing Nr";
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.panel2);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Name = "tpgSuchen";
            this.tpgSuchen.Size = new System.Drawing.Size(813, 497);
            this.tpgSuchen.TabIndex = 0;
            this.tpgSuchen.Title = "Suchen";
            this.tpgSuchen.Visible = false;
            //
            // panel2
            //
            this.panel2.Controls.Add(this.edtAuchInaktiveBanken);
            this.panel2.Controls.Add(this.kissSearchTitel1);
            this.panel2.Controls.Add(this.kissLabel7);
            this.panel2.Controls.Add(this.kissLabel8);
            this.panel2.Controls.Add(this.kissLabel9);
            this.panel2.Controls.Add(this.kissLabel10);
            this.panel2.Controls.Add(this.kissLabel11);
            this.panel2.Controls.Add(this.kissLabel12);
            this.panel2.Controls.Add(this.edtPLZOrtSearch);
            this.panel2.Controls.Add(this.edtPCKontoNrSearch);
            this.panel2.Controls.Add(this.edtClearingNrSearch);
            this.panel2.Controls.Add(this.edtZusatzSearch);
            this.panel2.Controls.Add(this.edtStrasseSearch);
            this.panel2.Controls.Add(this.edtNameSearch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(813, 203);
            this.panel2.TabIndex = 0;
            //
            // edtAuchInaktiveBanken
            //
            this.edtAuchInaktiveBanken.EditValue = false;
            this.edtAuchInaktiveBanken.Location = new System.Drawing.Point(84, 174);
            this.edtAuchInaktiveBanken.Name = "edtAuchInaktiveBanken";
            this.edtAuchInaktiveBanken.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAuchInaktiveBanken.Properties.Appearance.Options.UseBackColor = true;
            this.edtAuchInaktiveBanken.Properties.Caption = "auch inaktive Banken auflisten";
            this.edtAuchInaktiveBanken.Size = new System.Drawing.Size(195, 19);
            this.edtAuchInaktiveBanken.TabIndex = 342;
            //
            // kissSearchTitel1
            //
            this.kissSearchTitel1.Location = new System.Drawing.Point(6, 1);
            this.kissSearchTitel1.Name = "kissSearchTitel1";
            this.kissSearchTitel1.Size = new System.Drawing.Size(200, 24);
            this.kissSearchTitel1.TabIndex = 329;
            //
            // kissLabel7
            //
            this.kissLabel7.Location = new System.Drawing.Point(6, 145);
            this.kissLabel7.Name = "kissLabel7";
            this.kissLabel7.Size = new System.Drawing.Size(73, 24);
            this.kissLabel7.TabIndex = 328;
            this.kissLabel7.Text = "Postkonto Nr";
            //
            // kissLabel8
            //
            this.kissLabel8.Location = new System.Drawing.Point(6, 122);
            this.kissLabel8.Name = "kissLabel8";
            this.kissLabel8.Size = new System.Drawing.Size(73, 24);
            this.kissLabel8.TabIndex = 327;
            this.kissLabel8.Text = "Clearing Nr";
            //
            // kissLabel9
            //
            this.kissLabel9.Location = new System.Drawing.Point(6, 99);
            this.kissLabel9.Name = "kissLabel9";
            this.kissLabel9.Size = new System.Drawing.Size(64, 24);
            this.kissLabel9.TabIndex = 326;
            this.kissLabel9.Text = "Plz/Ort";
            //
            // kissLabel10
            //
            this.kissLabel10.Location = new System.Drawing.Point(6, 76);
            this.kissLabel10.Name = "kissLabel10";
            this.kissLabel10.Size = new System.Drawing.Size(64, 24);
            this.kissLabel10.TabIndex = 325;
            this.kissLabel10.Text = "Strasse";
            //
            // kissLabel11
            //
            this.kissLabel11.Location = new System.Drawing.Point(6, 53);
            this.kissLabel11.Name = "kissLabel11";
            this.kissLabel11.Size = new System.Drawing.Size(64, 24);
            this.kissLabel11.TabIndex = 324;
            this.kissLabel11.Text = "Zusatz";
            //
            // kissLabel12
            //
            this.kissLabel12.Location = new System.Drawing.Point(6, 29);
            this.kissLabel12.Name = "kissLabel12";
            this.kissLabel12.Size = new System.Drawing.Size(64, 24);
            this.kissLabel12.TabIndex = 323;
            this.kissLabel12.Text = "Name";
            //
            // edtPLZOrtSearch
            //
            this.edtPLZOrtSearch.BackColor = System.Drawing.SystemColors.Control;
            this.edtPLZOrtSearch.DataMemberBaGemeindeID = null;
            this.edtPLZOrtSearch.DataMemberKanton = "";
            this.edtPLZOrtSearch.DataMemberLand = "";
            this.edtPLZOrtSearch.DataMemberOrt = "";
            this.edtPLZOrtSearch.DataMemberPLZ = "";
            this.edtPLZOrtSearch.Location = new System.Drawing.Point(84, 98);
            this.edtPLZOrtSearch.Name = "edtPLZOrtSearch";
            this.edtPLZOrtSearch.ShowKanton = false;
            this.edtPLZOrtSearch.ShowLand = false;
            this.edtPLZOrtSearch.Size = new System.Drawing.Size(285, 24);
            this.edtPLZOrtSearch.TabIndex = 322;
            //
            // edtPCKontoNrSearch
            //
            this.edtPCKontoNrSearch.Location = new System.Drawing.Point(84, 144);
            this.edtPCKontoNrSearch.Name = "edtPCKontoNrSearch";
            this.edtPCKontoNrSearch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPCKontoNrSearch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPCKontoNrSearch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPCKontoNrSearch.Properties.Appearance.Options.UseBackColor = true;
            this.edtPCKontoNrSearch.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPCKontoNrSearch.Properties.Appearance.Options.UseFont = true;
            this.edtPCKontoNrSearch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPCKontoNrSearch.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPCKontoNrSearch.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtPCKontoNrSearch.Size = new System.Drawing.Size(285, 24);
            this.edtPCKontoNrSearch.TabIndex = 321;
            //
            // edtClearingNrSearch
            //
            this.edtClearingNrSearch.Location = new System.Drawing.Point(84, 121);
            this.edtClearingNrSearch.Name = "edtClearingNrSearch";
            this.edtClearingNrSearch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtClearingNrSearch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtClearingNrSearch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtClearingNrSearch.Properties.Appearance.Options.UseBackColor = true;
            this.edtClearingNrSearch.Properties.Appearance.Options.UseBorderColor = true;
            this.edtClearingNrSearch.Properties.Appearance.Options.UseFont = true;
            this.edtClearingNrSearch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtClearingNrSearch.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtClearingNrSearch.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtClearingNrSearch.Size = new System.Drawing.Size(285, 24);
            this.edtClearingNrSearch.TabIndex = 320;
            //
            // edtZusatzSearch
            //
            this.edtZusatzSearch.Location = new System.Drawing.Point(84, 52);
            this.edtZusatzSearch.Name = "edtZusatzSearch";
            this.edtZusatzSearch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZusatzSearch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZusatzSearch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZusatzSearch.Properties.Appearance.Options.UseBackColor = true;
            this.edtZusatzSearch.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZusatzSearch.Properties.Appearance.Options.UseFont = true;
            this.edtZusatzSearch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZusatzSearch.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZusatzSearch.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtZusatzSearch.Size = new System.Drawing.Size(285, 24);
            this.edtZusatzSearch.TabIndex = 319;
            //
            // edtStrasseSearch
            //
            this.edtStrasseSearch.Location = new System.Drawing.Point(84, 75);
            this.edtStrasseSearch.Name = "edtStrasseSearch";
            this.edtStrasseSearch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStrasseSearch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStrasseSearch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStrasseSearch.Properties.Appearance.Options.UseBackColor = true;
            this.edtStrasseSearch.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStrasseSearch.Properties.Appearance.Options.UseFont = true;
            this.edtStrasseSearch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStrasseSearch.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStrasseSearch.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtStrasseSearch.Size = new System.Drawing.Size(285, 24);
            this.edtStrasseSearch.TabIndex = 318;
            //
            // edtNameSearch
            //
            this.edtNameSearch.Location = new System.Drawing.Point(84, 29);
            this.edtNameSearch.Name = "edtNameSearch";
            this.edtNameSearch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNameSearch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameSearch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameSearch.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameSearch.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameSearch.Properties.Appearance.Options.UseFont = true;
            this.edtNameSearch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNameSearch.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNameSearch.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtNameSearch.Size = new System.Drawing.Size(285, 24);
            this.edtNameSearch.TabIndex = 317;
            //
            // btnBankHistory
            //
            this.btnBankHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBankHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBankHistory.Location = new System.Drawing.Point(6, 541);
            this.btnBankHistory.Name = "btnBankHistory";
            this.btnBankHistory.Size = new System.Drawing.Size(173, 24);
            this.btnBankHistory.TabIndex = 320;
            this.btnBankHistory.Text = "Bankenstamm-History";
            this.btnBankHistory.UseVisualStyleBackColor = false;
            this.btnBankHistory.Click += new System.EventHandler(this.btnBankHistory_Click);
            //
            // btnUpdate
            //
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Location = new System.Drawing.Point(185, 541);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(173, 24);
            this.btnUpdate.TabIndex = 319;
            this.btnUpdate.Text = "Bankenstamm aktualisieren";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            //
            // lblLastUpdate
            //
            this.lblLastUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLastUpdate.Location = new System.Drawing.Point(364, 541);
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new System.Drawing.Size(352, 24);
            this.lblLastUpdate.TabIndex = 324;
            this.lblLastUpdate.Text = "letzte Aktualisierung am";
            this.lblLastUpdate.UseCompatibleTextRendering = true;
            //
            // CtlFibuBankPost
            //
            this.ActiveSQLQuery = this.qryBaBank;
            this.AutoRefresh = false;
            this.Controls.Add(this.lblLastUpdate);
            this.Controls.Add(this.btnBankHistory);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.tabControlSearch);
            this.Name = "CtlFibuBankPost";
            this.Size = new System.Drawing.Size(825, 572);
            this.Search += new System.EventHandler(this.CtlFibuBankPost_Search);
            this.Load += new System.EventHandler(this.ctlFibuBuchung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryBaBank)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBaBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaBank)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissButtonEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissButtonEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissButtonEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editClearingNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editZusatz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblClearingNrNeu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilialeNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            this.tpgSuchen.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtAuchInaktiveBanken.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPCKontoNrSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtClearingNrSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasseSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLastUpdate)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        #region Dispose

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region EventHandlers

        private void btnBankHistory_Click(object sender, System.EventArgs e)
        {
            KissDialog dlg = new DlgBankenabgleich();
            dlg.ShowDialog();
            SetLastUpdateText();
        }

        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            KissDialog dlg = new DlgBankenabgleich(true);
            dlg.ShowDialog();
            SetLastUpdateText();
        }

        /// <summary>
        /// Handles the Search event of the CtlFibuBankPost control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CtlFibuBankPost_Search(
            object sender,
            System.EventArgs e)
        {
            if (this.tabControlSearch.SelectedTabIndex == 0)
            {
                if (this.qryBaBank.Post())
                {
                    NeueSuche();
                    this.tabControlSearch.SelectedTabIndex = 1;
                }
            }
            else
            {
                Suchen();
            }
        }

        /// <summary>
        /// Handles the Load event of the ctlFibuBuchung control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ctlFibuBuchung_Load(object sender, System.EventArgs e)
        {
            qryBaBank.Fill();
            grdBaBank.Focus();
            SetLastUpdateText();
        }

        private void grvBaBank_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            e.Handled = false;
            if (grvBaBank.FocusedRowHandle == e.RowHandle) return;

            bool isSicUpdated = Utils.ConvertToBool(grvBaBank.GetRowCellValue(e.RowHandle, grvBaBank.Columns["SicUpdated"]), false);
            if (isSicUpdated)
            {
                e.Appearance.BackColor = GuiConfig.GridRowReadOnly;
            }
            else
            {
                e.Appearance.BackColor = GuiConfig.GridRowHighlightedRed;
            }

            bool hasClearingNrNeu = null != grvBaBank.GetRowCellValue(e.RowHandle, grvBaBank.Columns["ClearingNrNeu"]) as int?;
            if (hasClearingNrNeu && isSicUpdated)
            {
                e.Appearance.BackColor = Color.AliceBlue;
            }
        }

        /// <summary>
        /// Handles the FormatEditValue event of the kissButtonEdit1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs"/> instance containing the event data.</param>
        private void kissButtonEdit1_FormatEditValue(
            object sender,
            DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            try
            {
                e.Handled = true;
                e.Value = Utils.FormatPCKontoNummerToUserFormat(e.Value.ToString().Replace("*", ""));
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        /// <summary>
        /// Handles the ParseEditValue event of the kissButtonEdit1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs"/> instance containing the event data.</param>
        private void kissButtonEdit1_ParseEditValue(
            object sender,
            DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            try
            {
                e.Handled = true;
                e.Value = Utils.FormatPCKontoNummerToDBFormat(e.Value.ToString());
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        /// <summary>
        /// Handles the AfterInsert event of the qryBank control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void qryBank_AfterInsert(
            object sender,
            System.EventArgs e)
        {
            editName.Focus();
        }

        /// <summary>
        /// Handles the BeforePost event of the qryBank control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void qryBank_BeforePost(
            object sender,
            System.EventArgs e)
        {
            kissPLZOrt1.DoValidate();

            string errorText = "";

            FibuUtilities.CheckPCKontoNr(qryBaBank.Row, ref errorText, true);

            if (errorText != "")
            {
                KissMsg.ShowInfo(errorText);
                throw new Exception();
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Gets the contect name.
        /// </summary>
        /// <returns></returns>
        public override string GetContextName()
        {
            return "VmFibu";
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Start new search.
        /// </summary>
        private void NeueSuche()
        {
            edtPCKontoNrSearch.Text = String.Empty;
            edtNameSearch.Text = String.Empty;
            edtClearingNrSearch.Text = String.Empty;
            edtPLZOrtSearch.PLZ = String.Empty;
            edtPLZOrtSearch.Ort = String.Empty;
            edtStrasseSearch.Text = String.Empty;
            edtZusatzSearch.Text = String.Empty;
            edtPCKontoNrSearch.Focus();
        }

        private void SetLastUpdateText()
        {
            lblLastUpdate.Text = "letzte Aktualisierung am " + DlgBankenabgleich.GetLastUpdateDate().ToString();
        }

        /// <summary>
        /// Suche ausführen.
        /// </summary>
        private void Suchen()
        {
            // TODO Delete
            qryBaBank.SelectStatement = "SELECT B.* FROM BaBank B ";

            // --- Kreditor Search Params
            if (!(bool)edtAuchInaktiveBanken.EditValue)
            {
                qryBaBank.SelectStatement +=
                    FibuUtilities.AndOrWhere(qryBaBank.SelectStatement) + " B.ClearingNrNeu IS NULL ";
            }
            if (!String.IsNullOrEmpty(edtNameSearch.Text))
            {
                qryBaBank.SelectStatement +=
                    FibuUtilities.AndOrWhere(qryBaBank.SelectStatement) + " B.Name LIKE '%" + edtNameSearch.Text + "%' ";
            }

            if (!String.IsNullOrEmpty(edtZusatzSearch.Text))
            {
                qryBaBank.SelectStatement +=
                    FibuUtilities.AndOrWhere(qryBaBank.SelectStatement) + " B.Zusatz LIKE '%" + edtZusatzSearch.Text + "%' ";
            }

            if (!String.IsNullOrEmpty(edtStrasseSearch.Text))
            {
                qryBaBank.SelectStatement +=
                    FibuUtilities.AndOrWhere(qryBaBank.SelectStatement) + " B.Strasse LIKE '%" + edtStrasseSearch.Text + "%' ";
            }

            if (!String.IsNullOrEmpty(edtPLZOrtSearch.PLZ))
            {
                qryBaBank.SelectStatement +=
                    FibuUtilities.AndOrWhere(qryBaBank.SelectStatement) + " B.PLZ LIKE '%" + edtPLZOrtSearch.PLZ + "%' ";
            }

            if (!String.IsNullOrEmpty(edtPLZOrtSearch.Ort))
            {
                qryBaBank.SelectStatement +=
                    FibuUtilities.AndOrWhere(qryBaBank.SelectStatement) + " B.Ort LIKE '%" + edtPLZOrtSearch.Ort + "%' ";
            }

            if (!String.IsNullOrEmpty(edtClearingNrSearch.Text))
            {
                qryBaBank.SelectStatement +=
                    FibuUtilities.AndOrWhere(qryBaBank.SelectStatement) + " B.ClearingNr LIKE '%" + edtClearingNrSearch.Text + "%' ";
            }

            if (!String.IsNullOrEmpty(edtPCKontoNrSearch.Text))
            {
                qryBaBank.SelectStatement +=
                    FibuUtilities.AndOrWhere(qryBaBank.SelectStatement) + " B.PCKontoNr LIKE '%" + edtPCKontoNrSearch.Text + "%' ";
            }

            qryBaBank.SelectStatement += " ORDER BY B.Name, B.PLZ";

            qryBaBank.Fill();
            qryBaBank.RefreshDisplay();
            this.tabControlSearch.SelectedTabIndex = 0;
        }

        #endregion

        #endregion
    }
}