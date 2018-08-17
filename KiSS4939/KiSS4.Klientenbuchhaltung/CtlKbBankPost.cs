using System.Drawing;

using KiSS4.Common;
using KiSS4.Gui;

using KiSS.KliBu.UI;



namespace KiSS4.Klientenbuchhaltung
{
    public class CtlKbBankPost : KissSearchUserControl
    {
        #region Fields

        #region Private Fields

        private KissButton btnBankHistory;
        private KissButton btnUpdate;
        private DevExpress.XtraGrid.Columns.GridColumn colClearingNr;
        private DevExpress.XtraGrid.Columns.GridColumn colClearingNrNeu;
        private DevExpress.XtraGrid.Columns.GridColumn colFilialeNr;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colPLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colPcKontoNr;
        private DevExpress.XtraGrid.Columns.GridColumn colSicUpdated;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasse;
        private System.ComponentModel.IContainer components;
        private KissCheckEdit edtAuchInaktiveBanken;
        private KiSS4.Gui.KissButtonEdit edtClearingNr;
        private KissButtonEdit edtClearingNrSearch;
        private KiSS4.Gui.KissButtonEdit edtName;
        private KissButtonEdit edtNameSearch;
        private KiSS4.Gui.KissButtonEdit edtPCKontoNr;
        private KissButtonEdit edtPCKontoNrSearch;
        private KissPLZOrt edtPLZOrt;
        private KissPLZOrt edtPLZOrtSearch;
        private KiSS4.Gui.KissButtonEdit edtStrasse;
        private KissButtonEdit edtStrasseSearch;
        private KiSS4.Gui.KissGrid grdBaBank;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBaBank;
        private KissButtonEdit kissButtonEdit1;
        private KissButtonEdit kissButtonEdit2;
        private KiSS4.Gui.KissLabel lblClearingNr;
        private KissLabel lblClearingNrNeu;
        private KissLabel lblFilialeNr;
        private KissLabel lblLastUpdate;
        private KiSS4.Gui.KissLabel lblName;
        private KiSS4.Gui.KissLabel lblPCKontoNr;
        private KiSS4.Gui.KissLabel lblPLZOrt;
        private KiSS4.Gui.KissLabel lblStrasse;
        private KiSS4.Gui.KissLabel lblSucheClearingNr;
        private KiSS4.Gui.KissLabel lblSucheName;
        private KiSS4.Gui.KissLabel lblSuchePLZOrt;
        private KiSS4.Gui.KissLabel lblSuchePostkontoNr;
        private KiSS4.Gui.KissLabel lblSucheStrasse;
        private KiSS4.DB.SqlQuery qryBaBank;

        #endregion

        #endregion

        #region Constructors

        public CtlKbBankPost()
        {
            this.InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKbBankPost));
            this.edtName = new KiSS4.Gui.KissButtonEdit();
            this.qryBaBank = new KiSS4.DB.SqlQuery(this.components);
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
            this.lblSucheName = new KiSS4.Gui.KissLabel();
            this.lblSucheStrasse = new KiSS4.Gui.KissLabel();
            this.lblSuchePLZOrt = new KiSS4.Gui.KissLabel();
            this.lblSucheClearingNr = new KiSS4.Gui.KissLabel();
            this.lblSuchePostkontoNr = new KiSS4.Gui.KissLabel();
            this.edtStrasse = new KiSS4.Gui.KissButtonEdit();
            this.edtClearingNr = new KiSS4.Gui.KissButtonEdit();
            this.edtPCKontoNr = new KiSS4.Gui.KissButtonEdit();
            this.lblName = new KiSS4.Gui.KissLabel();
            this.lblStrasse = new KiSS4.Gui.KissLabel();
            this.lblPLZOrt = new KiSS4.Gui.KissLabel();
            this.lblClearingNr = new KiSS4.Gui.KissLabel();
            this.lblPCKontoNr = new KiSS4.Gui.KissLabel();
            this.btnUpdate = new KiSS4.Gui.KissButton();
            this.btnBankHistory = new KiSS4.Gui.KissButton();
            this.lblFilialeNr = new KiSS4.Gui.KissLabel();
            this.kissButtonEdit1 = new KiSS4.Gui.KissButtonEdit();
            this.lblClearingNrNeu = new KiSS4.Gui.KissLabel();
            this.kissButtonEdit2 = new KiSS4.Gui.KissButtonEdit();
            this.edtAuchInaktiveBanken = new KiSS4.Gui.KissCheckEdit();
            this.lblLastUpdate = new KiSS4.Gui.KissLabel();
            this.edtPLZOrtSearch = new KiSS4.Common.KissPLZOrt();
            this.edtPCKontoNrSearch = new KiSS4.Gui.KissButtonEdit();
            this.edtClearingNrSearch = new KiSS4.Gui.KissButtonEdit();
            this.edtStrasseSearch = new KiSS4.Gui.KissButtonEdit();
            this.edtNameSearch = new KiSS4.Gui.KissButtonEdit();
            this.edtPLZOrt = new KiSS4.Common.KissPLZOrt();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheStrasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchePLZOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheClearingNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchePostkontoNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtClearingNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPCKontoNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPLZOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblClearingNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPCKontoNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilialeNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissButtonEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblClearingNrNeu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissButtonEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuchInaktiveBanken.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLastUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPCKontoNrSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtClearingNrSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasseSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameSearch.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // searchTitle
            //
            this.searchTitle.Size = new System.Drawing.Size(729, 24);
            //
            // tabControlSearch
            //
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(753, 261);
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.grdBaBank);
            this.tpgListe.Size = new System.Drawing.Size(741, 223);
            this.tpgListe.Title = "Liste";
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.edtPLZOrtSearch);
            this.tpgSuchen.Controls.Add(this.edtPCKontoNrSearch);
            this.tpgSuchen.Controls.Add(this.edtClearingNrSearch);
            this.tpgSuchen.Controls.Add(this.edtStrasseSearch);
            this.tpgSuchen.Controls.Add(this.edtNameSearch);
            this.tpgSuchen.Controls.Add(this.edtAuchInaktiveBanken);
            this.tpgSuchen.Controls.Add(this.lblSuchePostkontoNr);
            this.tpgSuchen.Controls.Add(this.lblSucheClearingNr);
            this.tpgSuchen.Controls.Add(this.lblSuchePLZOrt);
            this.tpgSuchen.Controls.Add(this.lblSucheStrasse);
            this.tpgSuchen.Controls.Add(this.lblSucheName);
            this.tpgSuchen.Size = new System.Drawing.Size(741, 223);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheStrasse, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSuchePLZOrt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheClearingNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSuchePostkontoNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAuchInaktiveBanken, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNameSearch, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtStrasseSearch, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtClearingNrSearch, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtPCKontoNrSearch, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtPLZOrtSearch, 0);
            //
            // edtName
            //
            this.edtName.DataMember = "Name";
            this.edtName.DataSource = this.qryBaBank;
            this.edtName.Location = new System.Drawing.Point(75, 279);
            this.edtName.Name = "edtName";
            this.edtName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtName.Properties.Appearance.Options.UseBackColor = true;
            this.edtName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtName.Properties.Appearance.Options.UseFont = true;
            this.edtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtName.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtName.Properties.Name = "editName.Properties";
            this.edtName.Size = new System.Drawing.Size(285, 24);
            this.edtName.TabIndex = 0;
            //
            // qryBaBank
            //
            this.qryBaBank.HostControl = this;
            this.qryBaBank.SelectStatement = resources.GetString("qryBaBank.SelectStatement");
            this.qryBaBank.TableName = "BaBank";
            //
            // grdBaBank
            //
            this.grdBaBank.DataSource = this.qryBaBank;
            this.grdBaBank.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBaBank.EmbeddedNavigator.Name = "grid.EmbeddedNavigator";
            this.grdBaBank.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBaBank.Location = new System.Drawing.Point(0, 0);
            this.grdBaBank.MainView = this.grvBaBank;
            this.grdBaBank.Name = "grdBaBank";
            this.grdBaBank.Size = new System.Drawing.Size(741, 223);
            this.grdBaBank.TabIndex = 6;
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
            this.grvBaBank.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaBank.Appearance.OddRow.Options.UseFont = true;
            this.grvBaBank.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBaBank.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaBank.Appearance.Row.Options.UseBackColor = true;
            this.grvBaBank.Appearance.Row.Options.UseFont = true;
            this.grvBaBank.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
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
            this.grvBaBank.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
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
            // lblSucheName
            //
            this.lblSucheName.Location = new System.Drawing.Point(8, 49);
            this.lblSucheName.Name = "lblSucheName";
            this.lblSucheName.Size = new System.Drawing.Size(64, 24);
            this.lblSucheName.TabIndex = 335;
            this.lblSucheName.Text = "Name";
            this.lblSucheName.UseCompatibleTextRendering = true;
            //
            // lblSucheStrasse
            //
            this.lblSucheStrasse.Location = new System.Drawing.Point(8, 72);
            this.lblSucheStrasse.Name = "lblSucheStrasse";
            this.lblSucheStrasse.Size = new System.Drawing.Size(64, 24);
            this.lblSucheStrasse.TabIndex = 337;
            this.lblSucheStrasse.Text = "Strasse";
            this.lblSucheStrasse.UseCompatibleTextRendering = true;
            //
            // lblSuchePLZOrt
            //
            this.lblSuchePLZOrt.Location = new System.Drawing.Point(8, 95);
            this.lblSuchePLZOrt.Name = "lblSuchePLZOrt";
            this.lblSuchePLZOrt.Size = new System.Drawing.Size(64, 24);
            this.lblSuchePLZOrt.TabIndex = 338;
            this.lblSuchePLZOrt.Text = "Plz/Ort";
            this.lblSuchePLZOrt.UseCompatibleTextRendering = true;
            //
            // lblSucheClearingNr
            //
            this.lblSucheClearingNr.Location = new System.Drawing.Point(8, 118);
            this.lblSucheClearingNr.Name = "lblSucheClearingNr";
            this.lblSucheClearingNr.Size = new System.Drawing.Size(73, 24);
            this.lblSucheClearingNr.TabIndex = 339;
            this.lblSucheClearingNr.Text = "Clearing Nr";
            this.lblSucheClearingNr.UseCompatibleTextRendering = true;
            //
            // lblSuchePostkontoNr
            //
            this.lblSuchePostkontoNr.Location = new System.Drawing.Point(8, 141);
            this.lblSuchePostkontoNr.Name = "lblSuchePostkontoNr";
            this.lblSuchePostkontoNr.Size = new System.Drawing.Size(73, 24);
            this.lblSuchePostkontoNr.TabIndex = 340;
            this.lblSuchePostkontoNr.Text = "Postkonto Nr";
            this.lblSuchePostkontoNr.UseCompatibleTextRendering = true;
            //
            // edtStrasse
            //
            this.edtStrasse.DataMember = "Strasse";
            this.edtStrasse.DataSource = this.qryBaBank;
            this.edtStrasse.Location = new System.Drawing.Point(75, 302);
            this.edtStrasse.Name = "edtStrasse";
            this.edtStrasse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStrasse.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStrasse.Properties.Name = "editStrasse.Properties";
            this.edtStrasse.Size = new System.Drawing.Size(285, 24);
            this.edtStrasse.TabIndex = 1;
            //
            // edtClearingNr
            //
            this.edtClearingNr.DataMember = "ClearingNr";
            this.edtClearingNr.DataSource = this.qryBaBank;
            this.edtClearingNr.Location = new System.Drawing.Point(469, 278);
            this.edtClearingNr.Name = "edtClearingNr";
            this.edtClearingNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtClearingNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtClearingNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtClearingNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtClearingNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtClearingNr.Properties.Appearance.Options.UseFont = true;
            this.edtClearingNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtClearingNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtClearingNr.Properties.Name = "editClearingNr.Properties";
            this.edtClearingNr.Size = new System.Drawing.Size(280, 24);
            this.edtClearingNr.TabIndex = 4;
            //
            // edtPCKontoNr
            //
            this.edtPCKontoNr.DataMember = "PCKontoNr";
            this.edtPCKontoNr.DataSource = this.qryBaBank;
            this.edtPCKontoNr.Location = new System.Drawing.Point(469, 324);
            this.edtPCKontoNr.Name = "edtPCKontoNr";
            this.edtPCKontoNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPCKontoNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPCKontoNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPCKontoNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtPCKontoNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPCKontoNr.Properties.Appearance.Options.UseFont = true;
            this.edtPCKontoNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPCKontoNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPCKontoNr.Properties.Name = "kissButtonEdit1.Properties";
            this.edtPCKontoNr.Size = new System.Drawing.Size(280, 24);
            this.edtPCKontoNr.TabIndex = 5;
            //
            // lblName
            //
            this.lblName.Location = new System.Drawing.Point(11, 279);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(64, 24);
            this.lblName.TabIndex = 311;
            this.lblName.Text = "Name";
            this.lblName.UseCompatibleTextRendering = true;
            //
            // lblStrasse
            //
            this.lblStrasse.Location = new System.Drawing.Point(11, 302);
            this.lblStrasse.Name = "lblStrasse";
            this.lblStrasse.Size = new System.Drawing.Size(64, 24);
            this.lblStrasse.TabIndex = 313;
            this.lblStrasse.Text = "Strasse";
            this.lblStrasse.UseCompatibleTextRendering = true;
            //
            // lblPLZOrt
            //
            this.lblPLZOrt.Location = new System.Drawing.Point(11, 325);
            this.lblPLZOrt.Name = "lblPLZOrt";
            this.lblPLZOrt.Size = new System.Drawing.Size(64, 24);
            this.lblPLZOrt.TabIndex = 314;
            this.lblPLZOrt.Text = "Plz/Ort";
            this.lblPLZOrt.UseCompatibleTextRendering = true;
            //
            // lblClearingNr
            //
            this.lblClearingNr.Location = new System.Drawing.Point(375, 278);
            this.lblClearingNr.Name = "lblClearingNr";
            this.lblClearingNr.Size = new System.Drawing.Size(97, 24);
            this.lblClearingNr.TabIndex = 315;
            this.lblClearingNr.Text = "Clearing Nr";
            this.lblClearingNr.UseCompatibleTextRendering = true;
            //
            // lblPCKontoNr
            //
            this.lblPCKontoNr.Location = new System.Drawing.Point(374, 325);
            this.lblPCKontoNr.Name = "lblPCKontoNr";
            this.lblPCKontoNr.Size = new System.Drawing.Size(97, 24);
            this.lblPCKontoNr.TabIndex = 316;
            this.lblPCKontoNr.Text = "Postkonto Nr";
            this.lblPCKontoNr.UseCompatibleTextRendering = true;
            //
            // btnUpdate
            //
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Location = new System.Drawing.Point(190, 388);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(173, 24);
            this.btnUpdate.TabIndex = 317;
            this.btnUpdate.Text = "Bankenstamm aktualisieren";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            //
            // btnBankHistory
            //
            this.btnBankHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBankHistory.Location = new System.Drawing.Point(11, 388);
            this.btnBankHistory.Name = "btnBankHistory";
            this.btnBankHistory.Size = new System.Drawing.Size(173, 24);
            this.btnBankHistory.TabIndex = 318;
            this.btnBankHistory.Text = "Bankenstamm-History";
            this.btnBankHistory.UseVisualStyleBackColor = false;
            this.btnBankHistory.Click += new System.EventHandler(this.btnBankHistory_Click);
            //
            // lblFilialeNr
            //
            this.lblFilialeNr.Location = new System.Drawing.Point(375, 301);
            this.lblFilialeNr.Name = "lblFilialeNr";
            this.lblFilialeNr.Size = new System.Drawing.Size(97, 24);
            this.lblFilialeNr.TabIndex = 320;
            this.lblFilialeNr.Text = "Filiale Nr";
            this.lblFilialeNr.UseCompatibleTextRendering = true;
            //
            // kissButtonEdit1
            //
            this.kissButtonEdit1.DataMember = "FilialeNr";
            this.kissButtonEdit1.DataSource = this.qryBaBank;
            this.kissButtonEdit1.Location = new System.Drawing.Point(469, 301);
            this.kissButtonEdit1.Name = "kissButtonEdit1";
            this.kissButtonEdit1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.kissButtonEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissButtonEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissButtonEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.kissButtonEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.kissButtonEdit1.Properties.Appearance.Options.UseFont = true;
            this.kissButtonEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissButtonEdit1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.kissButtonEdit1.Properties.Name = "editClearingNr.Properties";
            this.kissButtonEdit1.Size = new System.Drawing.Size(280, 24);
            this.kissButtonEdit1.TabIndex = 319;
            //
            // lblClearingNrNeu
            //
            this.lblClearingNrNeu.Location = new System.Drawing.Point(375, 347);
            this.lblClearingNrNeu.Name = "lblClearingNrNeu";
            this.lblClearingNrNeu.Size = new System.Drawing.Size(97, 24);
            this.lblClearingNrNeu.TabIndex = 322;
            this.lblClearingNrNeu.Text = "neue Clearing Nr";
            this.lblClearingNrNeu.UseCompatibleTextRendering = true;
            //
            // kissButtonEdit2
            //
            this.kissButtonEdit2.DataMember = "ClearingNrNeu";
            this.kissButtonEdit2.DataSource = this.qryBaBank;
            this.kissButtonEdit2.Location = new System.Drawing.Point(469, 347);
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
            this.kissButtonEdit2.Size = new System.Drawing.Size(280, 24);
            this.kissButtonEdit2.TabIndex = 321;
            //
            // edtAuchInaktiveBanken
            //
            this.edtAuchInaktiveBanken.EditValue = false;
            this.edtAuchInaktiveBanken.Location = new System.Drawing.Point(113, 171);
            this.edtAuchInaktiveBanken.Name = "edtAuchInaktiveBanken";
            this.edtAuchInaktiveBanken.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtAuchInaktiveBanken.Properties.Appearance.Options.UseBackColor = true;
            this.edtAuchInaktiveBanken.Properties.Caption = "auch inaktive Banken auflisten";
            this.edtAuchInaktiveBanken.Size = new System.Drawing.Size(195, 19);
            this.edtAuchInaktiveBanken.TabIndex = 341;
            //
            // lblLastUpdate
            //
            this.lblLastUpdate.Location = new System.Drawing.Point(11, 420);
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new System.Drawing.Size(352, 24);
            this.lblLastUpdate.TabIndex = 323;
            this.lblLastUpdate.Text = "letzte Aktualisierung am";
            this.lblLastUpdate.UseCompatibleTextRendering = true;
            //
            // edtPLZOrtSearch
            //
            this.edtPLZOrtSearch.BackColor = System.Drawing.SystemColors.Control;
            this.edtPLZOrtSearch.DataMemberKanton = "";
            this.edtPLZOrtSearch.DataMemberLand = "";
            this.edtPLZOrtSearch.DataMemberOrt = "";
            this.edtPLZOrtSearch.DataMemberPLZ = "";
            this.edtPLZOrtSearch.Location = new System.Drawing.Point(113, 95);
            this.edtPLZOrtSearch.Name = "edtPLZOrtSearch";
            this.edtPLZOrtSearch.ShowKanton = false;
            this.edtPLZOrtSearch.ShowLand = false;
            this.edtPLZOrtSearch.Size = new System.Drawing.Size(285, 24);
            this.edtPLZOrtSearch.TabIndex = 347;
            //
            // edtPCKontoNrSearch
            //
            this.edtPCKontoNrSearch.Location = new System.Drawing.Point(113, 141);
            this.edtPCKontoNrSearch.Name = "edtPCKontoNrSearch";
            this.edtPCKontoNrSearch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPCKontoNrSearch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPCKontoNrSearch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPCKontoNrSearch.Properties.Appearance.Options.UseBackColor = true;
            this.edtPCKontoNrSearch.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPCKontoNrSearch.Properties.Appearance.Options.UseFont = true;
            this.edtPCKontoNrSearch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPCKontoNrSearch.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPCKontoNrSearch.Size = new System.Drawing.Size(285, 24);
            this.edtPCKontoNrSearch.TabIndex = 346;
            //
            // edtClearingNrSearch
            //
            this.edtClearingNrSearch.Location = new System.Drawing.Point(113, 118);
            this.edtClearingNrSearch.Name = "edtClearingNrSearch";
            this.edtClearingNrSearch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtClearingNrSearch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtClearingNrSearch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtClearingNrSearch.Properties.Appearance.Options.UseBackColor = true;
            this.edtClearingNrSearch.Properties.Appearance.Options.UseBorderColor = true;
            this.edtClearingNrSearch.Properties.Appearance.Options.UseFont = true;
            this.edtClearingNrSearch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtClearingNrSearch.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtClearingNrSearch.Size = new System.Drawing.Size(285, 24);
            this.edtClearingNrSearch.TabIndex = 345;
            //
            // edtStrasseSearch
            //
            this.edtStrasseSearch.Location = new System.Drawing.Point(113, 72);
            this.edtStrasseSearch.Name = "edtStrasseSearch";
            this.edtStrasseSearch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStrasseSearch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStrasseSearch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStrasseSearch.Properties.Appearance.Options.UseBackColor = true;
            this.edtStrasseSearch.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStrasseSearch.Properties.Appearance.Options.UseFont = true;
            this.edtStrasseSearch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStrasseSearch.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStrasseSearch.Size = new System.Drawing.Size(285, 24);
            this.edtStrasseSearch.TabIndex = 343;
            //
            // edtNameSearch
            //
            this.edtNameSearch.Location = new System.Drawing.Point(113, 49);
            this.edtNameSearch.Name = "edtNameSearch";
            this.edtNameSearch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNameSearch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameSearch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameSearch.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameSearch.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameSearch.Properties.Appearance.Options.UseFont = true;
            this.edtNameSearch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNameSearch.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNameSearch.Size = new System.Drawing.Size(285, 24);
            this.edtNameSearch.TabIndex = 342;
            //
            // edtPLZOrt
            //
            this.edtPLZOrt.BackColor = System.Drawing.SystemColors.Control;
            this.edtPLZOrt.DataSource = this.qryBaBank;
            this.edtPLZOrt.Location = new System.Drawing.Point(75, 325);
            this.edtPLZOrt.Name = "edtPLZOrt";
            this.edtPLZOrt.ShowKanton = false;
            this.edtPLZOrt.ShowLand = false;
            this.edtPLZOrt.Size = new System.Drawing.Size(285, 24);
            this.edtPLZOrt.TabIndex = 348;
            //
            // CtlKbBankPost
            //
            this.ActiveSQLQuery = this.qryBaBank;
            this.Controls.Add(this.edtPLZOrt);
            this.Controls.Add(this.lblLastUpdate);
            this.Controls.Add(this.kissButtonEdit2);
            this.Controls.Add(this.kissButtonEdit1);
            this.Controls.Add(this.btnBankHistory);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblPLZOrt);
            this.Controls.Add(this.lblStrasse);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.edtPCKontoNr);
            this.Controls.Add(this.edtClearingNr);
            this.Controls.Add(this.edtStrasse);
            this.Controls.Add(this.edtName);
            this.Controls.Add(this.lblClearingNrNeu);
            this.Controls.Add(this.lblFilialeNr);
            this.Controls.Add(this.lblPCKontoNr);
            this.Controls.Add(this.lblClearingNr);
            this.Name = "CtlKbBankPost";
            this.Size = new System.Drawing.Size(759, 452);
            this.Load += new System.EventHandler(this.CtlKbBankPost_Load);
            this.Controls.SetChildIndex(this.lblClearingNr, 0);
            this.Controls.SetChildIndex(this.lblPCKontoNr, 0);
            this.Controls.SetChildIndex(this.lblFilialeNr, 0);
            this.Controls.SetChildIndex(this.lblClearingNrNeu, 0);
            this.Controls.SetChildIndex(this.edtName, 0);
            this.Controls.SetChildIndex(this.edtStrasse, 0);
            this.Controls.SetChildIndex(this.edtClearingNr, 0);
            this.Controls.SetChildIndex(this.edtPCKontoNr, 0);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.lblStrasse, 0);
            this.Controls.SetChildIndex(this.lblPLZOrt, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.btnUpdate, 0);
            this.Controls.SetChildIndex(this.btnBankHistory, 0);
            this.Controls.SetChildIndex(this.kissButtonEdit1, 0);
            this.Controls.SetChildIndex(this.kissButtonEdit2, 0);
            this.Controls.SetChildIndex(this.lblLastUpdate, 0);
            this.Controls.SetChildIndex(this.edtPLZOrt, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheStrasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchePLZOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheClearingNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchePostkontoNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtClearingNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPCKontoNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPLZOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblClearingNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPCKontoNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilialeNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissButtonEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblClearingNrNeu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissButtonEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuchInaktiveBanken.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLastUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPCKontoNrSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtClearingNrSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasseSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameSearch.Properties)).EndInit();
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
                if ((components != null))
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region EventHandlers

        private void CtlKbBankPost_Load(object sender, System.EventArgs e)
        {
            qryBaBank.Fill();
            grdBaBank.Focus();
            SetLastUpdateText();
        }

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

        private void grvBaBank_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            e.Handled = false;
            if (grvBaBank.FocusedRowHandle == e.RowHandle) return;

            bool isSicUpdated = Utils.ConvertToBool(grvBaBank.GetRowCellValue(e.RowHandle, grvBaBank.Columns["SicUpdated"]), false);
            if (isSicUpdated)
            {
                e.Appearance.BackColor = Color.Bisque;
            }
            else
            {
                e.Appearance.BackColor = Color.LightSalmon;
            }

            bool hasClearingNrNeu = null != grvBaBank.GetRowCellValue(e.RowHandle, grvBaBank.Columns["ClearingNrNeu"]) as string;
            if (hasClearingNrNeu && isSicUpdated)
            {
                e.Appearance.BackColor = Color.AliceBlue;
            }
        }

        #endregion

        #region Methods

        #region Private Methods

        private void SetLastUpdateText()
        {
            lblLastUpdate.Text = "letzte Aktualisierung am " + DlgBankenabgleich.GetLastUpdateDate().ToString();
        }

        #endregion

        #endregion
    }
}