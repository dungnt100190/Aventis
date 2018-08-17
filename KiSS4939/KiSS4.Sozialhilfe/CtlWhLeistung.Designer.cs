using System.Windows.Forms;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Sozialhilfe
{
    partial class CtlWhLeistung
    {
        private DevExpress.XtraGrid.Columns.GridColumn colBgBewilligungStatusCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colEnthaeltMonatsbudgets;
        private DevExpress.XtraGrid.Columns.GridColumn colGeplantBis;
        private DevExpress.XtraGrid.Columns.GridColumn colGeplantVon;
        private DevExpress.XtraGrid.Columns.GridColumn colHg;
        private DevExpress.XtraGrid.Columns.GridColumn colUB;
        private DevExpress.XtraGrid.Columns.GridColumn colUe;
        private System.ComponentModel.IContainer components = null;
        private KissLookUpEdit edtAbschlussGrundCode;
        private KissLookUpEdit edtBFSLeistungsart;
        private KissMemoEdit edtBemerkung;
        private KissDateEdit edtDatumBis;
        private KissDateEdit edtDatumVon;
        private KissLookUpEdit edtEroeffnungsGrundCode;
        private KissLookUpEdit edtZustaendigeGemeinde;
        private KissGrid grdBgFinanzplan;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBgFinanzplan;
        private KissLabel lblAbschluss;
        private KissLabel lblBFSLeistungsart;
        private KissLabel lblBemerkung;
        private KissLabel lblBgFinanzplan;
        private KissLabel lblDatumBis;
        private KissLabel lblDatumVon;
        private KissLabel lblEroeffnung;
        private KissLabel lblTitel;
        private KissLabel lblZustGemeinde;
        private PictureBox picTitel;
        private Panel pnTitle;
        private SqlQuery qryBgFinanzplan;
        private SqlQuery qryFaLeistung;
        private KissLabel lblInfo;
        private KissMemoEdit txtInfo;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlWhLeistung));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblZustGemeinde = new KiSS4.Gui.KissLabel();
            this.lblBFSLeistungsart = new KiSS4.Gui.KissLabel();
            this.lblAbschluss = new KiSS4.Gui.KissLabel();
            this.lblEroeffnung = new KiSS4.Gui.KissLabel();
            this.lblBgFinanzplan = new KiSS4.Gui.KissLabel();
            this.pnTitle = new System.Windows.Forms.Panel();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.grdBgFinanzplan = new KiSS4.Gui.KissGrid();
            this.qryBgFinanzplan = new KiSS4.DB.SqlQuery();
            this.grvBgFinanzplan = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBgBewilligungStatusCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colGeplantVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeplantBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEnthaeltMonatsbudgets = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.lblDatumBis = new KiSS4.Gui.KissLabel();
            this.edtAbschlussGrundCode = new KiSS4.Gui.KissLookUpEdit();
            this.qryFaLeistung = new KiSS4.DB.SqlQuery();
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.edtZustaendigeGemeinde = new KiSS4.Gui.KissLookUpEdit();
            this.edtBFSLeistungsart = new KiSS4.Gui.KissLookUpEdit();
            this.edtEroeffnungsGrundCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.lblInfo = new KiSS4.Gui.KissLabel();
            this.txtInfo = new KiSS4.Gui.KissMemoEdit();
            this.lblVorsaldoFremdsystem = new KiSS4.Gui.KissLabel();
            this.edtVorsaldoFremdsystem = new KiSS4.Gui.KissMoneyEdit();
            this.qryVorsaldo = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustGemeinde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBFSLeistungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschluss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffnung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgFinanzplan)).BeginInit();
            this.pnTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBgFinanzplan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgFinanzplan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgFinanzplan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrundCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrundCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLeistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigeGemeinde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigeGemeinde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSLeistungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSLeistungsart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungsGrundCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungsGrundCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorsaldoFremdsystem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorsaldoFremdsystem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVorsaldo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblZustGemeinde
            // 
            this.lblZustGemeinde.Location = new System.Drawing.Point(504, 112);
            this.lblZustGemeinde.Name = "lblZustGemeinde";
            this.lblZustGemeinde.Size = new System.Drawing.Size(124, 24);
            this.lblZustGemeinde.TabIndex = 32;
            this.lblZustGemeinde.Text = "zuständige Gemeinde";
            this.lblZustGemeinde.UseCompatibleTextRendering = true;
            // 
            // lblBFSLeistungsart
            // 
            this.lblBFSLeistungsart.Location = new System.Drawing.Point(504, 59);
            this.lblBFSLeistungsart.Name = "lblBFSLeistungsart";
            this.lblBFSLeistungsart.Size = new System.Drawing.Size(100, 23);
            this.lblBFSLeistungsart.TabIndex = 31;
            this.lblBFSLeistungsart.Text = "BFS-Leistungsart";
            this.lblBFSLeistungsart.UseCompatibleTextRendering = true;
            // 
            // lblAbschluss
            // 
            this.lblAbschluss.Location = new System.Drawing.Point(133, 112);
            this.lblAbschluss.Name = "lblAbschluss";
            this.lblAbschluss.Size = new System.Drawing.Size(100, 23);
            this.lblAbschluss.TabIndex = 30;
            this.lblAbschluss.Text = "Grund";
            this.lblAbschluss.UseCompatibleTextRendering = true;
            // 
            // lblEroeffnung
            // 
            this.lblEroeffnung.Location = new System.Drawing.Point(133, 59);
            this.lblEroeffnung.Name = "lblEroeffnung";
            this.lblEroeffnung.Size = new System.Drawing.Size(100, 23);
            this.lblEroeffnung.TabIndex = 29;
            this.lblEroeffnung.Text = "Grund";
            this.lblEroeffnung.UseCompatibleTextRendering = true;
            // 
            // lblBgFinanzplan
            // 
            this.lblBgFinanzplan.Location = new System.Drawing.Point(6, 425);
            this.lblBgFinanzplan.Name = "lblBgFinanzplan";
            this.lblBgFinanzplan.Size = new System.Drawing.Size(87, 24);
            this.lblBgFinanzplan.TabIndex = 28;
            this.lblBgFinanzplan.Text = "Perioden";
            this.lblBgFinanzplan.UseCompatibleTextRendering = true;
            // 
            // pnTitle
            // 
            this.pnTitle.Controls.Add(this.lblTitel);
            this.pnTitle.Controls.Add(this.picTitel);
            this.pnTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTitle.Location = new System.Drawing.Point(0, 0);
            this.pnTitle.Name = "pnTitle";
            this.pnTitle.Size = new System.Drawing.Size(798, 40);
            this.pnTitle.TabIndex = 27;
            // 
            // lblTitel
            // 
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(35, 10);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(500, 20);
            this.lblTitel.TabIndex = 1;
            this.lblTitel.Text = "FaLeistung";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // picTitel
            // 
            this.picTitel.Location = new System.Drawing.Point(10, 9);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(25, 20);
            this.picTitel.TabIndex = 1;
            this.picTitel.TabStop = false;
            // 
            // grdBgFinanzplan
            // 
            this.grdBgFinanzplan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBgFinanzplan.DataSource = this.qryBgFinanzplan;
            // 
            // 
            // 
            this.grdBgFinanzplan.EmbeddedNavigator.Name = "";
            this.grdBgFinanzplan.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBgFinanzplan.Location = new System.Drawing.Point(6, 452);
            this.grdBgFinanzplan.MainView = this.grvBgFinanzplan;
            this.grdBgFinanzplan.Name = "grdBgFinanzplan";
            this.grdBgFinanzplan.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.grdBgFinanzplan.Size = new System.Drawing.Size(784, 167);
            this.grdBgFinanzplan.TabIndex = 26;
            this.grdBgFinanzplan.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBgFinanzplan});
            // 
            // qryBgFinanzplan
            // 
            this.qryBgFinanzplan.HostControl = this;
            this.qryBgFinanzplan.IsIdentityInsert = false;
            this.qryBgFinanzplan.SelectStatement = resources.GetString("qryBgFinanzplan.SelectStatement");
            this.qryBgFinanzplan.TableName = "BgFinanzplan";
            // 
            // grvBgFinanzplan
            // 
            this.grvBgFinanzplan.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBgFinanzplan.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgFinanzplan.Appearance.Empty.Options.UseBackColor = true;
            this.grvBgFinanzplan.Appearance.Empty.Options.UseFont = true;
            this.grvBgFinanzplan.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgFinanzplan.Appearance.EvenRow.Options.UseFont = true;
            this.grvBgFinanzplan.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBgFinanzplan.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgFinanzplan.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBgFinanzplan.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBgFinanzplan.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBgFinanzplan.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBgFinanzplan.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBgFinanzplan.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgFinanzplan.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBgFinanzplan.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBgFinanzplan.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBgFinanzplan.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBgFinanzplan.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgFinanzplan.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBgFinanzplan.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvBgFinanzplan.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvBgFinanzplan.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgFinanzplan.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBgFinanzplan.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgFinanzplan.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgFinanzplan.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBgFinanzplan.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBgFinanzplan.Appearance.GroupRow.Options.UseFont = true;
            this.grvBgFinanzplan.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBgFinanzplan.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBgFinanzplan.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBgFinanzplan.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgFinanzplan.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBgFinanzplan.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBgFinanzplan.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBgFinanzplan.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBgFinanzplan.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgFinanzplan.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBgFinanzplan.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBgFinanzplan.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBgFinanzplan.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBgFinanzplan.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBgFinanzplan.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBgFinanzplan.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgFinanzplan.Appearance.OddRow.Options.UseFont = true;
            this.grvBgFinanzplan.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBgFinanzplan.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgFinanzplan.Appearance.Row.Options.UseBackColor = true;
            this.grvBgFinanzplan.Appearance.Row.Options.UseFont = true;
            this.grvBgFinanzplan.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgFinanzplan.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBgFinanzplan.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBgFinanzplan.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBgFinanzplan.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBgFinanzplan.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBgBewilligungStatusCode,
            this.colUB,
            this.colGeplantVon,
            this.colGeplantBis,
            this.colDatumVon,
            this.colDatumBis,
            this.colHg,
            this.colUe,
            this.colEnthaeltMonatsbudgets});
            this.grvBgFinanzplan.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBgFinanzplan.GridControl = this.grdBgFinanzplan;
            this.grvBgFinanzplan.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvBgFinanzplan.Name = "grvBgFinanzplan";
            this.grvBgFinanzplan.OptionsBehavior.Editable = false;
            this.grvBgFinanzplan.OptionsCustomization.AllowFilter = false;
            this.grvBgFinanzplan.OptionsFilter.AllowFilterEditor = false;
            this.grvBgFinanzplan.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBgFinanzplan.OptionsMenu.EnableColumnMenu = false;
            this.grvBgFinanzplan.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBgFinanzplan.OptionsNavigation.UseTabKey = false;
            this.grvBgFinanzplan.OptionsView.ColumnAutoWidth = false;
            this.grvBgFinanzplan.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBgFinanzplan.OptionsView.ShowGroupPanel = false;
            this.grvBgFinanzplan.OptionsView.ShowIndicator = false;
            // 
            // colBgBewilligungStatusCode
            // 
            this.colBgBewilligungStatusCode.Caption = "Status";
            this.colBgBewilligungStatusCode.FieldName = "BgBewilligungStatusCode";
            this.colBgBewilligungStatusCode.Name = "colBgBewilligungStatusCode";
            this.colBgBewilligungStatusCode.Visible = true;
            this.colBgBewilligungStatusCode.VisibleIndex = 0;
            this.colBgBewilligungStatusCode.Width = 157;
            // 
            // colUB
            // 
            this.colUB.Caption = "ÜB";
            this.colUB.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colUB.FieldName = "UB";
            this.colUB.Name = "colUB";
            this.colUB.Visible = true;
            this.colUB.VisibleIndex = 1;
            this.colUB.Width = 27;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // colGeplantVon
            // 
            this.colGeplantVon.Caption = "Geplant von";
            this.colGeplantVon.FieldName = "GeplantVon";
            this.colGeplantVon.Name = "colGeplantVon";
            this.colGeplantVon.Visible = true;
            this.colGeplantVon.VisibleIndex = 2;
            // 
            // colGeplantBis
            // 
            this.colGeplantBis.Caption = "Geplant bis";
            this.colGeplantBis.FieldName = "GeplantBis";
            this.colGeplantBis.Name = "colGeplantBis";
            this.colGeplantBis.Visible = true;
            this.colGeplantBis.VisibleIndex = 3;
            // 
            // colDatumVon
            // 
            this.colDatumVon.Caption = "Gültig von";
            this.colDatumVon.FieldName = "DatumVon";
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.Visible = true;
            this.colDatumVon.VisibleIndex = 4;
            // 
            // colDatumBis
            // 
            this.colDatumBis.Caption = "Gültig bis";
            this.colDatumBis.FieldName = "DatumBis";
            this.colDatumBis.Name = "colDatumBis";
            this.colDatumBis.Visible = true;
            this.colDatumBis.VisibleIndex = 5;
            // 
            // colHg
            // 
            this.colHg.Caption = "Hg";
            this.colHg.FieldName = "Hg";
            this.colHg.Name = "colHg";
            this.colHg.Visible = true;
            this.colHg.VisibleIndex = 6;
            this.colHg.Width = 32;
            // 
            // colUe
            // 
            this.colUe.Caption = "Ue";
            this.colUe.FieldName = "Ue";
            this.colUe.Name = "colUe";
            this.colUe.Visible = true;
            this.colUe.VisibleIndex = 7;
            this.colUe.Width = 27;
            // 
            // colEnthaeltMonatsbudgets
            // 
            this.colEnthaeltMonatsbudgets.Caption = "enthält Monatsbudgets";
            this.colEnthaeltMonatsbudgets.FieldName = "FinanzPlaene";
            this.colEnthaeltMonatsbudgets.Name = "colEnthaeltMonatsbudgets";
            this.colEnthaeltMonatsbudgets.Visible = true;
            this.colEnthaeltMonatsbudgets.VisibleIndex = 8;
            this.colEnthaeltMonatsbudgets.Width = 258;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.Location = new System.Drawing.Point(6, 169);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(100, 24);
            this.lblBemerkung.TabIndex = 25;
            this.lblBemerkung.Text = "Bemerkung";
            this.lblBemerkung.UseCompatibleTextRendering = true;
            // 
            // lblDatumBis
            // 
            this.lblDatumBis.Location = new System.Drawing.Point(6, 112);
            this.lblDatumBis.Name = "lblDatumBis";
            this.lblDatumBis.Size = new System.Drawing.Size(100, 23);
            this.lblDatumBis.TabIndex = 24;
            this.lblDatumBis.Text = "Abgeschlossen am";
            this.lblDatumBis.UseCompatibleTextRendering = true;
            // 
            // edtAbschlussGrundCode
            // 
            this.edtAbschlussGrundCode.DataMember = "AbschlussGrundCode";
            this.edtAbschlussGrundCode.DataSource = this.qryFaLeistung;
            this.edtAbschlussGrundCode.Location = new System.Drawing.Point(133, 138);
            this.edtAbschlussGrundCode.LOVName = "AbschlussHauptGrund";
            this.edtAbschlussGrundCode.Name = "edtAbschlussGrundCode";
            this.edtAbschlussGrundCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAbschlussGrundCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAbschlussGrundCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbschlussGrundCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbschlussGrundCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAbschlussGrundCode.Properties.Appearance.Options.UseFont = true;
            this.edtAbschlussGrundCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAbschlussGrundCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbschlussGrundCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAbschlussGrundCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAbschlussGrundCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtAbschlussGrundCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtAbschlussGrundCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAbschlussGrundCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", null, 75)});
            this.edtAbschlussGrundCode.Properties.DisplayMember = "Text";
            this.edtAbschlussGrundCode.Properties.NullText = "";
            this.edtAbschlussGrundCode.Properties.ShowFooter = false;
            this.edtAbschlussGrundCode.Properties.ShowHeader = false;
            this.edtAbschlussGrundCode.Properties.ValueMember = "Code";
            this.edtAbschlussGrundCode.Size = new System.Drawing.Size(350, 24);
            this.edtAbschlussGrundCode.TabIndex = 23;
            // 
            // qryFaLeistung
            // 
            this.qryFaLeistung.CanDelete = true;
            this.qryFaLeistung.CanUpdate = true;
            this.qryFaLeistung.HostControl = this;
            this.qryFaLeistung.IsIdentityInsert = false;
            this.qryFaLeistung.SelectStatement = resources.GetString("qryFaLeistung.SelectStatement");
            this.qryFaLeistung.TableName = "FaLeistung";
            this.qryFaLeistung.AfterPost += new System.EventHandler(this.qryFaLeistung_AfterPost);
            this.qryFaLeistung.BeforeDelete += new System.EventHandler(this.qryFaLeistung_BeforeDelete);
            this.qryFaLeistung.BeforeDeleteQuestion += new System.EventHandler(this.qryFaLeistung_BeforeDeleteQuestion);
            this.qryFaLeistung.BeforePost += new System.EventHandler(this.qryFaLeistung_BeforePost);
            // 
            // lblDatumVon
            // 
            this.lblDatumVon.Location = new System.Drawing.Point(6, 59);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(100, 23);
            this.lblDatumVon.TabIndex = 21;
            this.lblDatumVon.Text = "Eröffnet am";
            this.lblDatumVon.UseCompatibleTextRendering = true;
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.DataMember = "DatumBis";
            this.edtDatumBis.DataSource = this.qryFaLeistung;
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(6, 138);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 22;
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryFaLeistung;
            this.edtBemerkung.Location = new System.Drawing.Point(6, 195);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(784, 71);
            this.edtBemerkung.TabIndex = 20;
            // 
            // edtZustaendigeGemeinde
            // 
            this.edtZustaendigeGemeinde.AllowNull = false;
            this.edtZustaendigeGemeinde.DataMember = "GemeindeCode";
            this.edtZustaendigeGemeinde.DataSource = this.qryFaLeistung;
            this.edtZustaendigeGemeinde.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtZustaendigeGemeinde.Location = new System.Drawing.Point(504, 137);
            this.edtZustaendigeGemeinde.LOVFilter = "(Value3 IS NULL OR \',\' + Value3 + \',\' LIKE \'%,S,%\')";
            this.edtZustaendigeGemeinde.LOVFilterWhereAppend = true;
            this.edtZustaendigeGemeinde.LOVName = "GemeindeSozialdienst";
            this.edtZustaendigeGemeinde.Name = "edtZustaendigeGemeinde";
            this.edtZustaendigeGemeinde.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtZustaendigeGemeinde.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZustaendigeGemeinde.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZustaendigeGemeinde.Properties.Appearance.Options.UseBackColor = true;
            this.edtZustaendigeGemeinde.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZustaendigeGemeinde.Properties.Appearance.Options.UseFont = true;
            this.edtZustaendigeGemeinde.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtZustaendigeGemeinde.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtZustaendigeGemeinde.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtZustaendigeGemeinde.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtZustaendigeGemeinde.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtZustaendigeGemeinde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtZustaendigeGemeinde.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZustaendigeGemeinde.Properties.NullText = "";
            this.edtZustaendigeGemeinde.Properties.ShowFooter = false;
            this.edtZustaendigeGemeinde.Properties.ShowHeader = false;
            this.edtZustaendigeGemeinde.Size = new System.Drawing.Size(286, 24);
            this.edtZustaendigeGemeinde.TabIndex = 19;
            // 
            // edtBFSLeistungsart
            // 
            this.edtBFSLeistungsart.DataMember = "LeistungsartCode";
            this.edtBFSLeistungsart.DataSource = this.qryFaLeistung;
            this.edtBFSLeistungsart.Location = new System.Drawing.Point(504, 84);
            this.edtBFSLeistungsart.LOVFilter = "S";
            this.edtBFSLeistungsart.LOVName = "Leistungsart";
            this.edtBFSLeistungsart.Name = "edtBFSLeistungsart";
            this.edtBFSLeistungsart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBFSLeistungsart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBFSLeistungsart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBFSLeistungsart.Properties.Appearance.Options.UseBackColor = true;
            this.edtBFSLeistungsart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBFSLeistungsart.Properties.Appearance.Options.UseFont = true;
            this.edtBFSLeistungsart.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBFSLeistungsart.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBFSLeistungsart.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBFSLeistungsart.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBFSLeistungsart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtBFSLeistungsart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtBFSLeistungsart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBFSLeistungsart.Properties.NullText = "";
            this.edtBFSLeistungsart.Properties.ShowFooter = false;
            this.edtBFSLeistungsart.Properties.ShowHeader = false;
            this.edtBFSLeistungsart.Size = new System.Drawing.Size(286, 24);
            this.edtBFSLeistungsart.TabIndex = 18;
            // 
            // edtEroeffnungsGrundCode
            // 
            this.edtEroeffnungsGrundCode.DataMember = "EroeffnungsGrundCode";
            this.edtEroeffnungsGrundCode.DataSource = this.qryFaLeistung;
            this.edtEroeffnungsGrundCode.Location = new System.Drawing.Point(133, 85);
            this.edtEroeffnungsGrundCode.LOVName = "Eroeffnungsgrund";
            this.edtEroeffnungsGrundCode.Name = "edtEroeffnungsGrundCode";
            this.edtEroeffnungsGrundCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEroeffnungsGrundCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEroeffnungsGrundCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEroeffnungsGrundCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtEroeffnungsGrundCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEroeffnungsGrundCode.Properties.Appearance.Options.UseFont = true;
            this.edtEroeffnungsGrundCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtEroeffnungsGrundCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtEroeffnungsGrundCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtEroeffnungsGrundCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtEroeffnungsGrundCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtEroeffnungsGrundCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtEroeffnungsGrundCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEroeffnungsGrundCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", null, 75)});
            this.edtEroeffnungsGrundCode.Properties.DisplayMember = "Text";
            this.edtEroeffnungsGrundCode.Properties.NullText = "";
            this.edtEroeffnungsGrundCode.Properties.ShowFooter = false;
            this.edtEroeffnungsGrundCode.Properties.ShowHeader = false;
            this.edtEroeffnungsGrundCode.Properties.ValueMember = "Code";
            this.edtEroeffnungsGrundCode.Size = new System.Drawing.Size(350, 24);
            this.edtEroeffnungsGrundCode.TabIndex = 17;
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.DataMember = "DatumVon";
            this.edtDatumVon.DataSource = this.qryFaLeistung;
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(6, 85);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 16;
            // 
            // lblInfo
            // 
            this.lblInfo.Location = new System.Drawing.Point(6, 324);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(96, 24);
            this.lblInfo.TabIndex = 34;
            this.lblInfo.Text = "Informationen";
            this.lblInfo.UseCompatibleTextRendering = true;
            // 
            // txtInfo
            // 
            this.txtInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfo.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.txtInfo.Location = new System.Drawing.Point(6, 351);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.txtInfo.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.txtInfo.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txtInfo.Properties.Appearance.Options.UseBackColor = true;
            this.txtInfo.Properties.Appearance.Options.UseBorderColor = true;
            this.txtInfo.Properties.Appearance.Options.UseFont = true;
            this.txtInfo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtInfo.Properties.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size(784, 71);
            this.txtInfo.TabIndex = 33;
            // 
            // lblVorsaldoFremdsystem
            // 
            this.lblVorsaldoFremdsystem.Location = new System.Drawing.Point(6, 269);
            this.lblVorsaldoFremdsystem.Name = "lblVorsaldoFremdsystem";
            this.lblVorsaldoFremdsystem.Size = new System.Drawing.Size(146, 24);
            this.lblVorsaldoFremdsystem.TabIndex = 35;
            this.lblVorsaldoFremdsystem.Text = "Vorsaldo Fremdsystem";
            this.lblVorsaldoFremdsystem.UseCompatibleTextRendering = true;
            // 
            // edtVorsaldoFremdsystem
            // 
            this.edtVorsaldoFremdsystem.DataMember = "Vorsaldo";
            this.edtVorsaldoFremdsystem.DataSource = this.qryVorsaldo;
            this.edtVorsaldoFremdsystem.Location = new System.Drawing.Point(6, 297);
            this.edtVorsaldoFremdsystem.Name = "edtVorsaldoFremdsystem";
            this.edtVorsaldoFremdsystem.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVorsaldoFremdsystem.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVorsaldoFremdsystem.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVorsaldoFremdsystem.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVorsaldoFremdsystem.Properties.Appearance.Options.UseBackColor = true;
            this.edtVorsaldoFremdsystem.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVorsaldoFremdsystem.Properties.Appearance.Options.UseFont = true;
            this.edtVorsaldoFremdsystem.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVorsaldoFremdsystem.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVorsaldoFremdsystem.Properties.DisplayFormat.FormatString = "n2";
            this.edtVorsaldoFremdsystem.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtVorsaldoFremdsystem.Properties.EditFormat.FormatString = "n2";
            this.edtVorsaldoFremdsystem.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtVorsaldoFremdsystem.Properties.Mask.EditMask = "n2";
            this.edtVorsaldoFremdsystem.Size = new System.Drawing.Size(100, 24);
            this.edtVorsaldoFremdsystem.TabIndex = 36;
            // 
            // qryVorsaldo
            // 
            this.qryVorsaldo.CanUpdate = true;
            this.qryVorsaldo.HostControl = this;
            this.qryVorsaldo.IsIdentityInsert = false;
            this.qryVorsaldo.SelectStatement = "SELECT KbKostenstelleID, Vorsaldo, KbKostenstelleTS\r\nFROM KbKostenstelle\r\nWHERE K" +
    "bKostenstelleID = {0}";
            this.qryVorsaldo.TableName = "KbKostenstelle";
            // 
            // CtlWhLeistung
            // 
            this.ActiveSQLQuery = this.qryFaLeistung;
            this.Controls.Add(this.edtVorsaldoFremdsystem);
            this.Controls.Add(this.lblVorsaldoFremdsystem);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.lblZustGemeinde);
            this.Controls.Add(this.lblBFSLeistungsart);
            this.Controls.Add(this.lblAbschluss);
            this.Controls.Add(this.lblEroeffnung);
            this.Controls.Add(this.lblBgFinanzplan);
            this.Controls.Add(this.pnTitle);
            this.Controls.Add(this.grdBgFinanzplan);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.lblDatumBis);
            this.Controls.Add(this.edtAbschlussGrundCode);
            this.Controls.Add(this.lblDatumVon);
            this.Controls.Add(this.edtDatumBis);
            this.Controls.Add(this.edtBemerkung);
            this.Controls.Add(this.edtZustaendigeGemeinde);
            this.Controls.Add(this.edtBFSLeistungsart);
            this.Controls.Add(this.edtEroeffnungsGrundCode);
            this.Controls.Add(this.edtDatumVon);
            this.Name = "CtlWhLeistung";
            this.Size = new System.Drawing.Size(798, 632);
            ((System.ComponentModel.ISupportInitialize)(this.lblZustGemeinde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBFSLeistungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschluss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffnung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgFinanzplan)).EndInit();
            this.pnTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBgFinanzplan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgFinanzplan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgFinanzplan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrundCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrundCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLeistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigeGemeinde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigeGemeinde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSLeistungsart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSLeistungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungsGrundCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungsGrundCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorsaldoFremdsystem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorsaldoFremdsystem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVorsaldo)).EndInit();
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

        private KissLabel lblVorsaldoFremdsystem;
        private KissMoneyEdit edtVorsaldoFremdsystem;
        private SqlQuery qryVorsaldo;


    }
}
