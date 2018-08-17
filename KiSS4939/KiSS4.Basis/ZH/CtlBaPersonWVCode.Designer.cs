namespace KiSS4.Basis.ZH
{
    public partial class CtlBaPersonWVCode
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colAnzahlEinzelposten;
        private DevExpress.XtraGrid.Columns.GridColumn colBED;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colEinheitenInFall;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colSKZNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colWVCode;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Common.ZH.CtlTimeline ctlTimeline;
        private KiSS4.Gui.KissLookUpEdit ddlBED;
        private KiSS4.Gui.KissLookUpEdit ddlStatus;
        private KiSS4.Gui.KissLookUpEdit ddlWVCode;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissMemoEdit edtFeedback;
        private KiSS4.Gui.KissTextEdit edtHeimatkantonNr;
        private KiSS4.Gui.KissTextEdit edtSKZNummer;
        private KiSS4.Gui.KissGrid grdBaWVCode;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBaWVCode;
        private KiSS4.Gui.KissLabel kissLabel90;
        private KiSS4.Gui.KissLabel lblBED;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblBis;
        private KiSS4.Gui.KissLabel lblGueltigVon;
        private KiSS4.Gui.KissLabel lblHeimatkantonNr;
        private KiSS4.Gui.KissLabel lblSKZNummer;
        private KiSS4.Gui.KissLabel lblStatus;
        private KiSS4.Gui.KissLabel lblWVCode;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Panel pnlFeedback;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Panel pnlTitel;
        private KiSS4.DB.SqlQuery qryBaWVCode;
        private KiSS4.DB.SqlQuery qryBgFinanzplan;
        private KiSS4.DB.SqlQuery qryStatus;
        private KiSS4.DB.SqlQuery qryWVCodeLOV;
        private KiSS4.Gui.KissSplitterCollapsible splitterTimeline;

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBaPersonWVCode));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pnlTitel = new System.Windows.Forms.Panel();
            this.kissLabel90 = new KiSS4.Gui.KissLabel();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.grdBaWVCode = new KiSS4.Gui.KissGrid();
            this.qryBaWVCode = new KiSS4.DB.SqlQuery(this.components);
            this.grvBaWVCode = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWVCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBED = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSKZNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinheitenInFall = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnzahlEinzelposten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitterTimeline = new KiSS4.Gui.KissSplitterCollapsible();
            this.ctlTimeline = new KiSS4.Common.ZH.CtlTimeline();
            this.pnlFeedback = new System.Windows.Forms.Panel();
            this.edtFeedback = new KiSS4.Gui.KissMemoEdit();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.lblSKZNummer = new KiSS4.Gui.KissLabel();
            this.lblHeimatkantonNr = new KiSS4.Gui.KissLabel();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.lblStatus = new KiSS4.Gui.KissLabel();
            this.lblBED = new KiSS4.Gui.KissLabel();
            this.lblBis = new KiSS4.Gui.KissLabel();
            this.lblGueltigVon = new KiSS4.Gui.KissLabel();
            this.lblWVCode = new KiSS4.Gui.KissLabel();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.edtSKZNummer = new KiSS4.Gui.KissTextEdit();
            this.edtHeimatkantonNr = new KiSS4.Gui.KissTextEdit();
            this.ddlStatus = new KiSS4.Gui.KissLookUpEdit();
            this.ddlBED = new KiSS4.Gui.KissLookUpEdit();
            this.ddlWVCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.qryBgFinanzplan = new KiSS4.DB.SqlQuery(this.components);
            this.qryStatus = new KiSS4.DB.SqlQuery(this.components);
            this.qryWVCodeLOV = new KiSS4.DB.SqlQuery(this.components);
            this.pnlTitel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel90)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaWVCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaWVCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaWVCode)).BeginInit();
            this.pnlFeedback.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtFeedback.Properties)).BeginInit();
            this.pnlDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSKZNummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHeimatkantonNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBED)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGueltigVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWVCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSKZNummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHeimatkantonNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlBED)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlBED.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlWVCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlWVCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgFinanzplan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryWVCodeLOV)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitel
            // 
            this.pnlTitel.Controls.Add(this.kissLabel90);
            this.pnlTitel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitel.Location = new System.Drawing.Point(0, 0);
            this.pnlTitel.Name = "pnlTitel";
            this.pnlTitel.Size = new System.Drawing.Size(854, 21);
            this.pnlTitel.TabIndex = 116;
            // 
            // kissLabel90
            // 
            this.kissLabel90.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel90.Location = new System.Drawing.Point(3, 4);
            this.kissLabel90.Name = "kissLabel90";
            this.kissLabel90.Size = new System.Drawing.Size(100, 16);
            this.kissLabel90.TabIndex = 106;
            this.kissLabel90.Text = "WV-Code";
            this.kissLabel90.UseCompatibleTextRendering = true;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.grdBaWVCode);
            this.pnlGrid.Controls.Add(this.splitterTimeline);
            this.pnlGrid.Controls.Add(this.ctlTimeline);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 21);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(2);
            this.pnlGrid.Size = new System.Drawing.Size(854, 410);
            this.pnlGrid.TabIndex = 117;
            // 
            // grdBaWVCode
            // 
            this.grdBaWVCode.DataSource = this.qryBaWVCode;
            this.grdBaWVCode.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdBaWVCode.EmbeddedNavigator.Name = "kissGrid4.EmbeddedNavigator";
            this.grdBaWVCode.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBaWVCode.Location = new System.Drawing.Point(2, 35);
            this.grdBaWVCode.MainView = this.grvBaWVCode;
            this.grdBaWVCode.Name = "grdBaWVCode";
            this.grdBaWVCode.Padding = new System.Windows.Forms.Padding(10);
            this.grdBaWVCode.Size = new System.Drawing.Size(850, 373);
            this.grdBaWVCode.TabIndex = 2;
            this.grdBaWVCode.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBaWVCode});
            // 
            // qryBaWVCode
            // 
            this.qryBaWVCode.BatchUpdate = true;
            this.qryBaWVCode.CanDelete = true;
            this.qryBaWVCode.CanInsert = true;
            this.qryBaWVCode.CanUpdate = true;
            this.qryBaWVCode.HostControl = this;
            this.qryBaWVCode.SelectStatement = resources.GetString("qryBaWVCode.SelectStatement");
            this.qryBaWVCode.TableName = "BaWVCode";
            this.qryBaWVCode.AfterInsert += new System.EventHandler(this.qryBaWVCode_AfterInsert);
            this.qryBaWVCode.BeforePost += new System.EventHandler(this.qryBaWVCode_BeforePost);
            this.qryBaWVCode.BeforeDeleteQuestion += new System.EventHandler(this.qryBaWVCode_BeforeDeleteQuestion);
            this.qryBaWVCode.BeforeDelete += new System.EventHandler(this.qryBaWVCode_BeforeDelete);
            this.qryBaWVCode.PositionChanged += new System.EventHandler(this.qryBaWVCode_PositionChanged);
            // 
            // grvBaWVCode
            // 
            this.grvBaWVCode.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBaWVCode.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWVCode.Appearance.Empty.Options.UseBackColor = true;
            this.grvBaWVCode.Appearance.Empty.Options.UseFont = true;
            this.grvBaWVCode.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWVCode.Appearance.EvenRow.Options.UseFont = true;
            this.grvBaWVCode.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaWVCode.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWVCode.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBaWVCode.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBaWVCode.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBaWVCode.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBaWVCode.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaWVCode.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWVCode.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBaWVCode.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBaWVCode.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBaWVCode.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBaWVCode.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaWVCode.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBaWVCode.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaWVCode.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaWVCode.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaWVCode.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBaWVCode.Appearance.GroupRow.Options.UseFont = true;
            this.grvBaWVCode.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBaWVCode.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBaWVCode.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBaWVCode.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaWVCode.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBaWVCode.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBaWVCode.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBaWVCode.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBaWVCode.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWVCode.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaWVCode.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBaWVCode.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBaWVCode.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBaWVCode.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaWVCode.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBaWVCode.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWVCode.Appearance.OddRow.Options.UseFont = true;
            this.grvBaWVCode.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBaWVCode.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWVCode.Appearance.Row.Options.UseBackColor = true;
            this.grvBaWVCode.Appearance.Row.Options.UseFont = true;
            this.grvBaWVCode.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWVCode.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBaWVCode.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaWVCode.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBaWVCode.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBaWVCode.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatumVon,
            this.colDatumBis,
            this.colWVCode,
            this.colBED,
            this.colSKZNummer,
            this.colStatus,
            this.colID,
            this.colEinheitenInFall,
            this.colAnzahlEinzelposten});
            this.grvBaWVCode.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBaWVCode.GridControl = this.grdBaWVCode;
            this.grvBaWVCode.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvBaWVCode.Name = "grvBaWVCode";
            this.grvBaWVCode.OptionsBehavior.Editable = false;
            this.grvBaWVCode.OptionsCustomization.AllowFilter = false;
            this.grvBaWVCode.OptionsFilter.AllowFilterEditor = false;
            this.grvBaWVCode.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBaWVCode.OptionsMenu.EnableColumnMenu = false;
            this.grvBaWVCode.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBaWVCode.OptionsNavigation.UseTabKey = false;
            this.grvBaWVCode.OptionsView.ColumnAutoWidth = false;
            this.grvBaWVCode.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBaWVCode.OptionsView.ShowGroupPanel = false;
            this.grvBaWVCode.OptionsView.ShowIndicator = false;
            // 
            // colDatumVon
            // 
            this.colDatumVon.Caption = "ab";
            this.colDatumVon.FieldName = "DatumVon";
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.Visible = true;
            this.colDatumVon.VisibleIndex = 0;
            // 
            // colDatumBis
            // 
            this.colDatumBis.Caption = "bis";
            this.colDatumBis.FieldName = "DatumBis";
            this.colDatumBis.Name = "colDatumBis";
            this.colDatumBis.Visible = true;
            this.colDatumBis.VisibleIndex = 1;
            // 
            // colWVCode
            // 
            this.colWVCode.Caption = "WV-Code";
            this.colWVCode.FieldName = "WVCode";
            this.colWVCode.Name = "colWVCode";
            this.colWVCode.Visible = true;
            this.colWVCode.VisibleIndex = 2;
            this.colWVCode.Width = 183;
            // 
            // colBED
            // 
            this.colBED.Caption = "BED";
            this.colBED.FieldName = "BaBedID";
            this.colBED.Name = "colBED";
            this.colBED.Visible = true;
            this.colBED.VisibleIndex = 3;
            this.colBED.Width = 164;
            // 
            // colSKZNummer
            // 
            this.colSKZNummer.Caption = "KSA-Nummer";
            this.colSKZNummer.FieldName = "SKZNummer";
            this.colSKZNummer.Name = "colSKZNummer";
            this.colSKZNummer.Visible = true;
            this.colSKZNummer.VisibleIndex = 4;
            this.colSKZNummer.Width = 90;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "BaWVStatusCode";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 5;
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "BaWVCodeID";
            this.colID.Name = "colID";
            // 
            // colEinheitenInFall
            // 
            this.colEinheitenInFall.Caption = "WV-Einh. in Fall";
            this.colEinheitenInFall.FieldName = "FallNrn";
            this.colEinheitenInFall.Name = "colEinheitenInFall";
            this.colEinheitenInFall.ToolTip = "Fälle, in denen der WV-Code für WV-Einheiten verwendet wird";
            this.colEinheitenInFall.Visible = true;
            this.colEinheitenInFall.VisibleIndex = 6;
            this.colEinheitenInFall.Width = 100;
            // 
            // colAnzahlEinzelposten
            // 
            this.colAnzahlEinzelposten.Caption = "WV-EPs";
            this.colAnzahlEinzelposten.FieldName = "AnzahlEinzelposten";
            this.colAnzahlEinzelposten.Name = "colAnzahlEinzelposten";
            this.colAnzahlEinzelposten.ToolTip = "Anzahl WV-Einzelposten für diesen WV-Code";
            this.colAnzahlEinzelposten.Visible = true;
            this.colAnzahlEinzelposten.VisibleIndex = 7;
            this.colAnzahlEinzelposten.Width = 54;
            // 
            // splitterTimeline
            // 
            this.splitterTimeline.AnimationDelay = 20;
            this.splitterTimeline.AnimationStep = 20;
            this.splitterTimeline.BorderStyle3D = System.Windows.Forms.Border3DStyle.Etched;
            this.splitterTimeline.ControlToHide = this.ctlTimeline;
            this.splitterTimeline.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterTimeline.ExpandParentForm = false;
            this.splitterTimeline.Location = new System.Drawing.Point(2, 27);
            this.splitterTimeline.Name = "splitterTimeline";
            this.splitterTimeline.TabIndex = 1;
            this.splitterTimeline.TabStop = false;
            this.splitterTimeline.UseAnimations = false;
            this.splitterTimeline.VisualStyle = KiSS4.Gui.VisualStyles.Mozilla;
            // 
            // ctlTimeline
            // 
            this.ctlTimeline.BackColor = System.Drawing.Color.Transparent;
            this.ctlTimeline.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctlTimeline.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctlTimeline.FromDate = new System.DateTime(2008, 2, 17, 0, 0, 0, 0);
            this.ctlTimeline.Location = new System.Drawing.Point(2, 2);
            this.ctlTimeline.Name = "ctlTimeline";
            this.ctlTimeline.ShowToday = true;
            this.ctlTimeline.Size = new System.Drawing.Size(850, 25);
            this.ctlTimeline.TabIndex = 0;
            this.ctlTimeline.ToDate = new System.DateTime(2008, 2, 18, 0, 0, 0, 0);
            // 
            // pnlFeedback
            // 
            this.pnlFeedback.Controls.Add(this.edtFeedback);
            this.pnlFeedback.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFeedback.Location = new System.Drawing.Point(0, 431);
            this.pnlFeedback.Name = "pnlFeedback";
            this.pnlFeedback.Padding = new System.Windows.Forms.Padding(2);
            this.pnlFeedback.Size = new System.Drawing.Size(854, 80);
            this.pnlFeedback.TabIndex = 118;
            this.pnlFeedback.Visible = false;
            // 
            // edtFeedback
            // 
            this.edtFeedback.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtFeedback.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtFeedback.Location = new System.Drawing.Point(2, 2);
            this.edtFeedback.Name = "edtFeedback";
            this.edtFeedback.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtFeedback.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFeedback.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFeedback.Properties.Appearance.Options.UseBackColor = true;
            this.edtFeedback.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFeedback.Properties.Appearance.Options.UseFont = true;
            this.edtFeedback.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFeedback.Properties.ReadOnly = true;
            this.edtFeedback.Size = new System.Drawing.Size(850, 76);
            this.edtFeedback.TabIndex = 115;
            // 
            // pnlDetails
            // 
            this.pnlDetails.Controls.Add(this.lblSKZNummer);
            this.pnlDetails.Controls.Add(this.lblHeimatkantonNr);
            this.pnlDetails.Controls.Add(this.lblBemerkung);
            this.pnlDetails.Controls.Add(this.lblStatus);
            this.pnlDetails.Controls.Add(this.lblBED);
            this.pnlDetails.Controls.Add(this.lblBis);
            this.pnlDetails.Controls.Add(this.lblGueltigVon);
            this.pnlDetails.Controls.Add(this.lblWVCode);
            this.pnlDetails.Controls.Add(this.edtBemerkung);
            this.pnlDetails.Controls.Add(this.edtSKZNummer);
            this.pnlDetails.Controls.Add(this.edtHeimatkantonNr);
            this.pnlDetails.Controls.Add(this.ddlStatus);
            this.pnlDetails.Controls.Add(this.ddlBED);
            this.pnlDetails.Controls.Add(this.ddlWVCode);
            this.pnlDetails.Controls.Add(this.edtDatumBis);
            this.pnlDetails.Controls.Add(this.edtDatumVon);
            this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDetails.Location = new System.Drawing.Point(0, 511);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(854, 148);
            this.pnlDetails.TabIndex = 119;
            // 
            // lblSKZNummer
            // 
            this.lblSKZNummer.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblSKZNummer.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSKZNummer.Location = new System.Drawing.Point(432, 42);
            this.lblSKZNummer.Name = "lblSKZNummer";
            this.lblSKZNummer.Size = new System.Drawing.Size(90, 26);
            this.lblSKZNummer.TabIndex = 114;
            this.lblSKZNummer.Text = "KSA-Nummer (migriert)";
            this.lblSKZNummer.UseCompatibleTextRendering = true;
            // 
            // lblHeimatkantonNr
            // 
            this.lblHeimatkantonNr.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblHeimatkantonNr.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblHeimatkantonNr.Location = new System.Drawing.Point(432, 71);
            this.lblHeimatkantonNr.Name = "lblHeimatkantonNr";
            this.lblHeimatkantonNr.Size = new System.Drawing.Size(90, 26);
            this.lblHeimatkantonNr.TabIndex = 114;
            this.lblHeimatkantonNr.Text = "Heimatkanton-Nr (migriert)";
            this.lblHeimatkantonNr.UseCompatibleTextRendering = true;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.Location = new System.Drawing.Point(9, 103);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(87, 24);
            this.lblBemerkung.TabIndex = 113;
            this.lblBemerkung.Text = "Bemerkung";
            this.lblBemerkung.UseCompatibleTextRendering = true;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(432, 13);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(90, 24);
            this.lblStatus.TabIndex = 111;
            this.lblStatus.Text = "Status";
            this.lblStatus.UseCompatibleTextRendering = true;
            // 
            // lblBED
            // 
            this.lblBED.Location = new System.Drawing.Point(9, 73);
            this.lblBED.Name = "lblBED";
            this.lblBED.Size = new System.Drawing.Size(87, 24);
            this.lblBED.TabIndex = 107;
            this.lblBED.Text = "BED";
            this.lblBED.UseCompatibleTextRendering = true;
            // 
            // lblBis
            // 
            this.lblBis.Location = new System.Drawing.Point(208, 13);
            this.lblBis.Name = "lblBis";
            this.lblBis.Size = new System.Drawing.Size(30, 24);
            this.lblBis.TabIndex = 101;
            this.lblBis.Text = "bis";
            this.lblBis.UseCompatibleTextRendering = true;
            // 
            // lblGueltigVon
            // 
            this.lblGueltigVon.Location = new System.Drawing.Point(9, 13);
            this.lblGueltigVon.Name = "lblGueltigVon";
            this.lblGueltigVon.Size = new System.Drawing.Size(87, 24);
            this.lblGueltigVon.TabIndex = 99;
            this.lblGueltigVon.Text = "Gültig ab";
            this.lblGueltigVon.UseCompatibleTextRendering = true;
            // 
            // lblWVCode
            // 
            this.lblWVCode.Location = new System.Drawing.Point(9, 43);
            this.lblWVCode.Name = "lblWVCode";
            this.lblWVCode.Size = new System.Drawing.Size(87, 24);
            this.lblWVCode.TabIndex = 96;
            this.lblWVCode.Text = "WV-Code";
            this.lblWVCode.UseCompatibleTextRendering = true;
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryBaWVCode;
            this.edtBemerkung.Location = new System.Drawing.Point(102, 103);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(526, 40);
            this.edtBemerkung.TabIndex = 6;
            // 
            // edtSKZNummer
            // 
            this.edtSKZNummer.DataMember = "SKZNummer";
            this.edtSKZNummer.DataSource = this.qryBaWVCode;
            this.edtSKZNummer.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtSKZNummer.Location = new System.Drawing.Point(528, 43);
            this.edtSKZNummer.Name = "edtSKZNummer";
            this.edtSKZNummer.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSKZNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSKZNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSKZNummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtSKZNummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSKZNummer.Properties.Appearance.Options.UseFont = true;
            this.edtSKZNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSKZNummer.Properties.ReadOnly = true;
            this.edtSKZNummer.Size = new System.Drawing.Size(100, 24);
            this.edtSKZNummer.TabIndex = 5;
            // 
            // edtHeimatkantonNr
            // 
            this.edtHeimatkantonNr.DataMember = "HeimatkantonNr";
            this.edtHeimatkantonNr.DataSource = this.qryBaWVCode;
            this.edtHeimatkantonNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtHeimatkantonNr.Location = new System.Drawing.Point(528, 72);
            this.edtHeimatkantonNr.Name = "edtHeimatkantonNr";
            this.edtHeimatkantonNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtHeimatkantonNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHeimatkantonNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHeimatkantonNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtHeimatkantonNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHeimatkantonNr.Properties.Appearance.Options.UseFont = true;
            this.edtHeimatkantonNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHeimatkantonNr.Properties.ReadOnly = true;
            this.edtHeimatkantonNr.Size = new System.Drawing.Size(100, 24);
            this.edtHeimatkantonNr.TabIndex = 5;
            // 
            // ddlStatus
            // 
            this.ddlStatus.DataMember = "BaWVStatusCode";
            this.ddlStatus.DataSource = this.qryBaWVCode;
            this.ddlStatus.Location = new System.Drawing.Point(528, 13);
            this.ddlStatus.LOVName = "BaWVStatus";
            this.ddlStatus.Name = "ddlStatus";
            this.ddlStatus.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlStatus.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlStatus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlStatus.Properties.Appearance.Options.UseBackColor = true;
            this.ddlStatus.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlStatus.Properties.Appearance.Options.UseFont = true;
            this.ddlStatus.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlStatus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlStatus.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlStatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.ddlStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.ddlStatus.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlStatus.Properties.NullText = "";
            this.ddlStatus.Properties.ShowFooter = false;
            this.ddlStatus.Properties.ShowHeader = false;
            this.ddlStatus.Size = new System.Drawing.Size(100, 24);
            this.ddlStatus.TabIndex = 4;
            this.ddlStatus.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.ddlStatus_EditValueChanging);
            // 
            // ddlBED
            // 
            this.ddlBED.DataMember = "BaBedID";
            this.ddlBED.DataSource = this.qryBaWVCode;
            this.ddlBED.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.ddlBED.Location = new System.Drawing.Point(102, 73);
            this.ddlBED.Name = "ddlBED";
            this.ddlBED.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.ddlBED.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlBED.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlBED.Properties.Appearance.Options.UseBackColor = true;
            this.ddlBED.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlBED.Properties.Appearance.Options.UseFont = true;
            this.ddlBED.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlBED.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlBED.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlBED.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlBED.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.ddlBED.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.ddlBED.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlBED.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.ddlBED.Properties.DisplayMember = "Text";
            this.ddlBED.Properties.NullText = "";
            this.ddlBED.Properties.ShowFooter = false;
            this.ddlBED.Properties.ShowHeader = false;
            this.ddlBED.Properties.ValueMember = "Code";
            this.ddlBED.Size = new System.Drawing.Size(308, 24);
            this.ddlBED.TabIndex = 3;
            // 
            // ddlWVCode
            // 
            this.ddlWVCode.DataMember = "WVCode";
            this.ddlWVCode.DataSource = this.qryBaWVCode;
            this.ddlWVCode.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.ddlWVCode.Location = new System.Drawing.Point(102, 43);
            this.ddlWVCode.Name = "ddlWVCode";
            this.ddlWVCode.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.ddlWVCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlWVCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlWVCode.Properties.Appearance.Options.UseBackColor = true;
            this.ddlWVCode.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlWVCode.Properties.Appearance.Options.UseFont = true;
            this.ddlWVCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlWVCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlWVCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlWVCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlWVCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.ddlWVCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.ddlWVCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlWVCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.ddlWVCode.Properties.DisplayMember = "Text";
            this.ddlWVCode.Properties.Name = "kissLookUpEdit5.Properties";
            this.ddlWVCode.Properties.NullText = "";
            this.ddlWVCode.Properties.ShowFooter = false;
            this.ddlWVCode.Properties.ShowHeader = false;
            this.ddlWVCode.Properties.ValueMember = "Code";
            this.ddlWVCode.Size = new System.Drawing.Size(308, 24);
            this.ddlWVCode.TabIndex = 2;
            this.ddlWVCode.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.ddlWVCode_CloseUp);
            this.ddlWVCode.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.ddlWVCode_EditValueChanging);
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.DataMember = "DatumBis";
            this.edtDatumBis.DataSource = this.qryBaWVCode;
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(244, 13);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.Name = "kissDateEdit9.Properties";
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 1;
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.DataMember = "DatumVon";
            this.edtDatumVon.DataSource = this.qryBaWVCode;
            this.edtDatumVon.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(102, 13);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.Name = "kissDateEdit8.Properties";
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 0;
            // 
            // qryBgFinanzplan
            // 
            this.qryBgFinanzplan.HostControl = this;
            this.qryBgFinanzplan.SelectStatement = resources.GetString("qryBgFinanzplan.SelectStatement");
            // 
            // qryStatus
            // 
            this.qryStatus.HostControl = this;
            this.qryStatus.SelectStatement = resources.GetString("qryStatus.SelectStatement");
            // 
            // qryWVCodeLOV
            // 
            this.qryWVCodeLOV.HostControl = this;
            this.qryWVCodeLOV.SelectStatement = "SELECT Code, Text, ShortText, BFSCode, Value1, Value2, Dauer = CAST(Value3 as int" +
                ")\r\nFROM XLOVCode\r\nWHERE LOVName = \'BaWVCode\'\r\nORDER BY SortKey";
            // 
            // CtlBaPersonWVCode
            // 
            this.ActiveSQLQuery = this.qryBaWVCode;
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlTitel);
            this.Controls.Add(this.pnlFeedback);
            this.Controls.Add(this.pnlDetails);
            this.MinimumSize = new System.Drawing.Size(708, 264);
            this.Name = "CtlBaPersonWVCode";
            this.Size = new System.Drawing.Size(854, 659);
            this.pnlTitel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel90)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBaWVCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaWVCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaWVCode)).EndInit();
            this.pnlFeedback.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtFeedback.Properties)).EndInit();
            this.pnlDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblSKZNummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHeimatkantonNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBED)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGueltigVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWVCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSKZNummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHeimatkantonNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlBED.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlBED)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlWVCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlWVCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgFinanzplan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryWVCodeLOV)).EndInit();
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
   }
}