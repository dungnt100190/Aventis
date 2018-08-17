namespace KiSS4.Sostat
{
    partial class CtlBfsDossiers
    {
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarManager barManager;
        private KiSS4.Gui.KissButton btnCollapse;
        private DevExpress.XtraBars.BarButtonItem btnDossierLoeschen;
        private KiSS4.Gui.KissButton btnExpand;
        private DevExpress.XtraBars.BarButtonItem btnNeuesDossier;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDossier;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colFehler;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colWarnungen;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissTextEdit edtBFSDefault;
        private KiSS4.Gui.KissButtonEdit edtBaPersonIDX;
        private KiSS4.Gui.KissCalcEdit edtErhebungsjahrX;
        private KiSS4.Gui.KissCheckedLookupEdit edtLeistungsartX;
        private KiSS4.Gui.KissCheckEdit edtNurAnfangszustandX;
        private KiSS4.Gui.KissCheckEdit edtNurStichtagX;
        private KiSS4.Gui.KissButtonEdit edtSARX;
        private KiSS4.Gui.KissCalcEdit edtSucheBFSDossierID;
        private KiSS4.ExpressionEvaluation.AdditionalFunctionEventHandler handler;
        private KiSS4.Gui.KissLabel lblEntriesCount;
        private KiSS4.Gui.KissLabel lblSucheBFSDossierID;
        private KiSS4.Gui.KissLabel lblSucheBFSDossierNr;
        private KiSS4.Gui.KissLabel lblSucheErhebungsjahr;
        private KiSS4.Gui.KissLabel lblSucheLeistungsart;
        private KiSS4.Gui.KissLabel lblSucheMitarbeiterIn;
        private KiSS4.Gui.KissLabel lblSuchePerson;
        private System.Windows.Forms.Panel panDetail;
        private KiSS4.Gui.KissScrollablePanel panFragen;
        private System.Windows.Forms.Panel panMain;
        private System.Windows.Forms.Panel panTree;
        private System.Windows.Forms.Panel panTreeButtons;
        private DevExpress.XtraBars.PopupMenu popUpMenu;
        private KiSS4.DB.SqlQuery qryAnswersOfDossier;
        private KiSS4.DB.SqlQuery qryClientTree;
        private KiSS4.DB.SqlQuery qryDatabind;
        private KiSS4.DB.SqlQuery qryFrageWert;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repItemTextEdit;
        private KiSS4.Gui.KissSplitterCollapsible splitterTree;
        private KiSS4.Gui.KissTree treClient;
        private KiSS4.Gui.KissTextEdit edtSucheBFSDossierNr;
        private KiSS4.Common.CtlGotoFall ctlGotoFall;
        private KiSS4.Gui.KissMemoEdit edtHerkunft;
        private KiSS4.Gui.KissLabel lblHerkunft;
        private KiSS4.Gui.KissMemoEdit edtFehler;
        private KiSS4.Gui.KissLabel lblFehler;
        private KiSS4.Gui.KissMemoEdit edtHilfeText;
        private KiSS4.Gui.KissLabel lblHilfe;
        private KiSS4.Gui.KissMemoEdit edtFrage;
        private KiSS4.Gui.KissLabel lblFrage;
        private System.Windows.Forms.Panel panAll;
        private KiSS4.Gui.KissSplitterCollapsible splitterFrage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CtlBfsDossier ctlBfsDossier;
        private System.Windows.Forms.ToolTip ttpError;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBfsDossiers));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panTree = new System.Windows.Forms.Panel();
            this.treClient = new KiSS4.Gui.KissTree();
            this.colDossier = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repItemTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colFehler = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colWarnungen = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.qryClientTree = new KiSS4.DB.SqlQuery();
            this.barManager = new DevExpress.XtraBars.BarManager();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnNeuesDossier = new DevExpress.XtraBars.BarButtonItem();
            this.btnDossierLoeschen = new DevExpress.XtraBars.BarButtonItem();
            this.panTreeButtons = new System.Windows.Forms.Panel();
            this.lblEntriesCount = new KiSS4.Gui.KissLabel();
            this.btnCollapse = new KiSS4.Gui.KissButton();
            this.btnExpand = new KiSS4.Gui.KissButton();
            this.splitterTree = new KiSS4.Gui.KissSplitterCollapsible();
            this.panMain = new System.Windows.Forms.Panel();
            this.panAll = new System.Windows.Forms.Panel();
            this.ctlBfsDossier = new KiSS4.Sostat.CtlBfsDossier();
            this.panFragen = new KiSS4.Gui.KissScrollablePanel();
            this.splitterFrage = new KiSS4.Gui.KissSplitterCollapsible();
            this.panDetail = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ctlGotoFall = new KiSS4.Common.CtlGotoFall();
            this.qryFrageWert = new KiSS4.DB.SqlQuery();
            this.edtHerkunft = new KiSS4.Gui.KissMemoEdit();
            this.edtFrage = new KiSS4.Gui.KissMemoEdit();
            this.lblHerkunft = new KiSS4.Gui.KissLabel();
            this.edtHilfeText = new KiSS4.Gui.KissMemoEdit();
            this.lblFrage = new KiSS4.Gui.KissLabel();
            this.lblFehler = new KiSS4.Gui.KissLabel();
            this.lblHilfe = new KiSS4.Gui.KissLabel();
            this.edtFehler = new KiSS4.Gui.KissMemoEdit();
            this.lblSucheErhebungsjahr = new KiSS4.Gui.KissLabel();
            this.edtErhebungsjahrX = new KiSS4.Gui.KissCalcEdit();
            this.lblSucheMitarbeiterIn = new KiSS4.Gui.KissLabel();
            this.edtSARX = new KiSS4.Gui.KissButtonEdit();
            this.lblSuchePerson = new KiSS4.Gui.KissLabel();
            this.edtNurStichtagX = new KiSS4.Gui.KissCheckEdit();
            this.edtNurAnfangszustandX = new KiSS4.Gui.KissCheckEdit();
            this.lblSucheLeistungsart = new KiSS4.Gui.KissLabel();
            this.edtLeistungsartX = new KiSS4.Gui.KissCheckedLookupEdit();
            this.popUpMenu = new DevExpress.XtraBars.PopupMenu();
            this.edtBFSDefault = new KiSS4.Gui.KissTextEdit();
            this.qryAnswersOfDossier = new KiSS4.DB.SqlQuery();
            this.qryDatabind = new KiSS4.DB.SqlQuery();
            this.ttpError = new System.Windows.Forms.ToolTip();
            this.edtSucheBFSDossierID = new KiSS4.Gui.KissCalcEdit();
            this.lblSucheBFSDossierID = new KiSS4.Gui.KissLabel();
            this.lblSucheBFSDossierNr = new KiSS4.Gui.KissLabel();
            this.edtBaPersonIDX = new KiSS4.Gui.KissButtonEdit();
            this.edtSucheBFSDossierNr = new KiSS4.Gui.KissTextEdit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            this.panTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treClient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemTextEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryClientTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            this.panTreeButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblEntriesCount)).BeginInit();
            this.panMain.SuspendLayout();
            this.panAll.SuspendLayout();
            this.panDetail.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryFrageWert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHerkunft.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFrage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHerkunft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHilfeText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFrage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFehler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHilfe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFehler.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheErhebungsjahr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErhebungsjahrX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMitarbeiterIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSARX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchePerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurStichtagX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurAnfangszustandX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheLeistungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLeistungsartX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popUpMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSDefault.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAnswersOfDossier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryDatabind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBFSDossierID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBFSDossierID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBFSDossierNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonIDX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBFSDossierNr.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(1353, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.Size = new System.Drawing.Size(1377, 845);
            this.tabControlSearch.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControlSearch_SelectedTabChanged);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.panMain);
            this.tpgListe.Controls.Add(this.splitterTree);
            this.tpgListe.Controls.Add(this.panTree);
            this.tpgListe.Size = new System.Drawing.Size(1365, 807);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtSucheBFSDossierNr);
            this.tpgSuchen.Controls.Add(this.edtBaPersonIDX);
            this.tpgSuchen.Controls.Add(this.lblSucheBFSDossierNr);
            this.tpgSuchen.Controls.Add(this.edtSucheBFSDossierID);
            this.tpgSuchen.Controls.Add(this.lblSucheBFSDossierID);
            this.tpgSuchen.Controls.Add(this.edtLeistungsartX);
            this.tpgSuchen.Controls.Add(this.lblSucheLeistungsart);
            this.tpgSuchen.Controls.Add(this.edtNurAnfangszustandX);
            this.tpgSuchen.Controls.Add(this.edtNurStichtagX);
            this.tpgSuchen.Controls.Add(this.lblSuchePerson);
            this.tpgSuchen.Controls.Add(this.edtSARX);
            this.tpgSuchen.Controls.Add(this.lblSucheMitarbeiterIn);
            this.tpgSuchen.Controls.Add(this.edtErhebungsjahrX);
            this.tpgSuchen.Controls.Add(this.lblSucheErhebungsjahr);
            this.tpgSuchen.Size = new System.Drawing.Size(1365, 807);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheErhebungsjahr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtErhebungsjahrX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheMitarbeiterIn, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSARX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSuchePerson, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNurStichtagX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNurAnfangszustandX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheLeistungsart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtLeistungsartX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBFSDossierID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBFSDossierID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBFSDossierNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBaPersonIDX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBFSDossierNr, 0);
            // 
            // panTree
            // 
            this.panTree.Controls.Add(this.treClient);
            this.panTree.Controls.Add(this.panTreeButtons);
            this.panTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.panTree.Location = new System.Drawing.Point(0, 0);
            this.panTree.Name = "panTree";
            this.panTree.Size = new System.Drawing.Size(311, 807);
            this.panTree.TabIndex = 0;
            // 
            // treClient
            // 
            this.treClient.AllowSortTree = true;
            this.treClient.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.treClient.Appearance.Empty.ForeColor = System.Drawing.Color.White;
            this.treClient.Appearance.Empty.Options.UseBackColor = true;
            this.treClient.Appearance.Empty.Options.UseForeColor = true;
            this.treClient.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(236)))), ((int)(((byte)(215)))));
            this.treClient.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.treClient.Appearance.EvenRow.Options.UseBackColor = true;
            this.treClient.Appearance.EvenRow.Options.UseForeColor = true;
            this.treClient.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
            this.treClient.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.treClient.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treClient.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treClient.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.treClient.Appearance.FocusedRow.Options.UseForeColor = true;
            this.treClient.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treClient.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treClient.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.treClient.Appearance.FooterPanel.Options.UseBackColor = true;
            this.treClient.Appearance.FooterPanel.Options.UseFont = true;
            this.treClient.Appearance.FooterPanel.Options.UseForeColor = true;
            this.treClient.Appearance.GroupButton.BackColor = System.Drawing.Color.Transparent;
            this.treClient.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.treClient.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.treClient.Appearance.GroupButton.Options.UseBackColor = true;
            this.treClient.Appearance.GroupButton.Options.UseFont = true;
            this.treClient.Appearance.GroupButton.Options.UseForeColor = true;
            this.treClient.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(226)))), ((int)(((byte)(184)))));
            this.treClient.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.treClient.Appearance.GroupFooter.Options.UseBackColor = true;
            this.treClient.Appearance.GroupFooter.Options.UseForeColor = true;
            this.treClient.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.treClient.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.treClient.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.treClient.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.treClient.Appearance.HeaderPanel.Options.UseFont = true;
            this.treClient.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.treClient.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.treClient.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treClient.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.treClient.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treClient.Appearance.HideSelectionRow.Options.UseFont = true;
            this.treClient.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.treClient.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treClient.Appearance.HorzLine.ForeColor = System.Drawing.Color.Red;
            this.treClient.Appearance.HorzLine.Options.UseBackColor = true;
            this.treClient.Appearance.HorzLine.Options.UseForeColor = true;
            this.treClient.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.treClient.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treClient.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.treClient.Appearance.OddRow.Options.UseBackColor = true;
            this.treClient.Appearance.OddRow.Options.UseFont = true;
            this.treClient.Appearance.OddRow.Options.UseForeColor = true;
            this.treClient.Appearance.Preview.BackColor = System.Drawing.Color.White;
            this.treClient.Appearance.Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treClient.Appearance.Preview.ForeColor = System.Drawing.Color.Maroon;
            this.treClient.Appearance.Preview.Options.UseBackColor = true;
            this.treClient.Appearance.Preview.Options.UseFont = true;
            this.treClient.Appearance.Preview.Options.UseForeColor = true;
            this.treClient.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.treClient.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treClient.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.treClient.Appearance.Row.Options.UseBackColor = true;
            this.treClient.Appearance.Row.Options.UseFont = true;
            this.treClient.Appearance.Row.Options.UseForeColor = true;
            this.treClient.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.treClient.Appearance.SelectedRow.Options.UseForeColor = true;
            this.treClient.Appearance.TreeLine.BackColor = System.Drawing.Color.Gray;
            this.treClient.Appearance.TreeLine.ForeColor = System.Drawing.Color.Gray;
            this.treClient.Appearance.TreeLine.Options.UseBackColor = true;
            this.treClient.Appearance.TreeLine.Options.UseForeColor = true;
            this.treClient.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treClient.Appearance.VertLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(166)))), ((int)(((byte)(70)))));
            this.treClient.Appearance.VertLine.Options.UseBackColor = true;
            this.treClient.Appearance.VertLine.Options.UseForeColor = true;
            this.treClient.Appearance.VertLine.Options.UseTextOptions = true;
            this.treClient.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.treClient.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colDossier,
            this.colFehler,
            this.colWarnungen});
            this.treClient.DataSource = this.qryClientTree;
            this.treClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treClient.ImageIndexFieldName = "IconID";
            this.treClient.Location = new System.Drawing.Point(0, 0);
            this.treClient.MenuManager = this.barManager;
            this.treClient.Name = "treClient";
            this.treClient.OptionsBehavior.AutoSelectAllInEditor = false;
            this.treClient.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treClient.OptionsBehavior.Editable = false;
            this.treClient.OptionsBehavior.KeepSelectedOnClick = false;
            this.treClient.OptionsBehavior.MoveOnEdit = false;
            this.treClient.OptionsMenu.EnableColumnMenu = false;
            this.treClient.OptionsMenu.EnableFooterMenu = false;
            this.treClient.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treClient.OptionsView.AutoWidth = false;
            this.treClient.OptionsView.EnableAppearanceEvenRow = true;
            this.treClient.OptionsView.EnableAppearanceOddRow = true;
            this.treClient.OptionsView.ShowIndicator = false;
            this.treClient.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItemTextEdit});
            this.treClient.Size = new System.Drawing.Size(311, 777);
            this.treClient.TabIndex = 1;
            this.treClient.BeforeFocusNode += new DevExpress.XtraTreeList.BeforeFocusNodeEventHandler(this.treClient_BeforeFocusNode);
            this.treClient.AfterFocusNode += new DevExpress.XtraTreeList.NodeEventHandler(this.treClient_AfterFocusNode);
            // 
            // colDossier
            // 
            this.colDossier.AppearanceCell.ForeColor = System.Drawing.Color.Black;
            this.colDossier.AppearanceCell.Options.UseForeColor = true;
            this.colDossier.Caption = "Dossier";
            this.colDossier.ColumnEdit = this.repItemTextEdit;
            this.colDossier.FieldName = "Text";
            this.colDossier.MinWidth = 100;
            this.colDossier.Name = "colDossier";
            this.colDossier.OptionsColumn.AllowSort = false;
            this.colDossier.VisibleIndex = 0;
            this.colDossier.Width = 202;
            // 
            // repItemTextEdit
            // 
            this.repItemTextEdit.Appearance.ForeColor = System.Drawing.Color.Black;
            this.repItemTextEdit.Appearance.Options.UseForeColor = true;
            this.repItemTextEdit.AutoHeight = false;
            this.repItemTextEdit.Name = "repItemTextEdit";
            // 
            // colFehler
            // 
            this.colFehler.Caption = "Fehl.";
            this.colFehler.FieldName = "Fehler";
            this.colFehler.Name = "colFehler";
            this.colFehler.OptionsColumn.AllowSort = false;
            this.colFehler.VisibleIndex = 1;
            this.colFehler.Width = 40;
            // 
            // colWarnungen
            // 
            this.colWarnungen.Caption = "Warn";
            this.colWarnungen.FieldName = "Warnung";
            this.colWarnungen.Name = "colWarnungen";
            this.colWarnungen.OptionsColumn.AllowSort = false;
            this.colWarnungen.Width = 40;
            // 
            // qryClientTree
            // 
            this.qryClientTree.FillTimeOut = 120;
            this.qryClientTree.HostControl = this;
            this.qryClientTree.IsIdentityInsert = false;
            this.qryClientTree.SelectStatement = resources.GetString("qryClientTree.SelectStatement");
            this.qryClientTree.TableName = "XBfsFrage";
            // 
            // barManager
            // 
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnNeuesDossier,
            this.btnDossierLoeschen});
            this.barManager.MaxItemId = 2;
            // 
            // btnNeuesDossier
            // 
            this.btnNeuesDossier.Caption = "Neues Dossier";
            this.btnNeuesDossier.Id = 0;
            this.btnNeuesDossier.Name = "btnNeuesDossier";
            this.btnNeuesDossier.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNeuesDossier_ItemClick);
            // 
            // btnDossierLoeschen
            // 
            this.btnDossierLoeschen.Caption = "Dossier löschen";
            this.btnDossierLoeschen.Id = 1;
            this.btnDossierLoeschen.Name = "btnDossierLoeschen";
            this.btnDossierLoeschen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDossierLoeschen_ItemClick);
            // 
            // panTreeButtons
            // 
            this.panTreeButtons.Controls.Add(this.lblEntriesCount);
            this.panTreeButtons.Controls.Add(this.btnCollapse);
            this.panTreeButtons.Controls.Add(this.btnExpand);
            this.panTreeButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panTreeButtons.Location = new System.Drawing.Point(0, 777);
            this.panTreeButtons.Name = "panTreeButtons";
            this.panTreeButtons.Size = new System.Drawing.Size(311, 30);
            this.panTreeButtons.TabIndex = 0;
            // 
            // lblEntriesCount
            // 
            this.lblEntriesCount.Location = new System.Drawing.Point(3, 3);
            this.lblEntriesCount.Name = "lblEntriesCount";
            this.lblEntriesCount.Size = new System.Drawing.Size(242, 24);
            this.lblEntriesCount.TabIndex = 2;
            this.lblEntriesCount.Text = "Anzahl Dossiers: <Count>";
            this.lblEntriesCount.UseCompatibleTextRendering = true;
            // 
            // btnCollapse
            // 
            this.btnCollapse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCollapse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCollapse.IconID = 71;
            this.btnCollapse.Location = new System.Drawing.Point(281, 3);
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.Size = new System.Drawing.Size(24, 24);
            this.btnCollapse.TabIndex = 1;
            this.btnCollapse.UseCompatibleTextRendering = true;
            this.btnCollapse.UseVisualStyleBackColor = false;
            this.btnCollapse.Click += new System.EventHandler(this.btnCollapse_Click);
            // 
            // btnExpand
            // 
            this.btnExpand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExpand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpand.IconID = 70;
            this.btnExpand.Location = new System.Drawing.Point(251, 3);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(24, 24);
            this.btnExpand.TabIndex = 0;
            this.btnExpand.UseCompatibleTextRendering = true;
            this.btnExpand.UseVisualStyleBackColor = false;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // splitterTree
            // 
            this.splitterTree.AnimationDelay = 20;
            this.splitterTree.AnimationStep = 20;
            this.splitterTree.BorderStyle3D = System.Windows.Forms.Border3DStyle.Etched;
            this.splitterTree.ControlToHide = this.panTree;
            this.splitterTree.ExpandParentForm = false;
            this.splitterTree.Location = new System.Drawing.Point(311, 0);
            this.splitterTree.Name = "splitter";
            this.splitterTree.TabIndex = 1;
            this.splitterTree.TabStop = false;
            this.splitterTree.UseAnimations = false;
            this.splitterTree.VisualStyle = KiSS4.Gui.VisualStyles.Mozilla;
            // 
            // panMain
            // 
            this.panMain.Controls.Add(this.panAll);
            this.panMain.Controls.Add(this.splitterFrage);
            this.panMain.Controls.Add(this.panDetail);
            this.panMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMain.Location = new System.Drawing.Point(319, 0);
            this.panMain.Name = "panMain";
            this.panMain.Size = new System.Drawing.Size(1046, 807);
            this.panMain.TabIndex = 2;
            // 
            // panAll
            // 
            this.panAll.Controls.Add(this.ctlBfsDossier);
            this.panAll.Controls.Add(this.panFragen);
            this.panAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panAll.Location = new System.Drawing.Point(0, 0);
            this.panAll.Name = "panAll";
            this.panAll.Size = new System.Drawing.Size(1046, 417);
            this.panAll.TabIndex = 3;
            // 
            // ctlBfsDossier
            // 
            this.ctlBfsDossier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlBfsDossier.DataHasChanged = false;
            this.ctlBfsDossier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlBfsDossier.Location = new System.Drawing.Point(0, 0);
            this.ctlBfsDossier.Name = "ctlBfsDossier";
            this.ctlBfsDossier.Size = new System.Drawing.Size(1046, 417);
            this.ctlBfsDossier.TabIndex = 2;
            // 
            // panFragen
            // 
            this.panFragen.AutoScrollMargin = new System.Drawing.Size(6, 6);
            this.panFragen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panFragen.Location = new System.Drawing.Point(0, 0);
            this.panFragen.Name = "panFragen";
            this.panFragen.Size = new System.Drawing.Size(1046, 417);
            this.panFragen.TabIndex = 1;
            // 
            // splitterFrage
            // 
            this.splitterFrage.AnimationDelay = 20;
            this.splitterFrage.AnimationStep = 20;
            this.splitterFrage.BorderStyle3D = System.Windows.Forms.Border3DStyle.Etched;
            this.splitterFrage.ControlToHide = this.panDetail;
            this.splitterFrage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitterFrage.ExpandParentForm = false;
            this.splitterFrage.Location = new System.Drawing.Point(0, 417);
            this.splitterFrage.Name = "splitter";
            this.splitterFrage.TabIndex = 4;
            this.splitterFrage.TabStop = false;
            this.splitterFrage.UseAnimations = false;
            this.splitterFrage.VisualStyle = KiSS4.Gui.VisualStyles.Mozilla;
            // 
            // panDetail
            // 
            this.panDetail.AutoScroll = true;
            this.panDetail.AutoScrollMinSize = new System.Drawing.Size(500, 150);
            this.panDetail.Controls.Add(this.tableLayoutPanel1);
            this.panDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panDetail.Location = new System.Drawing.Point(0, 425);
            this.panDetail.Name = "panDetail";
            this.panDetail.Size = new System.Drawing.Size(1046, 382);
            this.panDetail.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.ctlGotoFall, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.edtHerkunft, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.edtFrage, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblHerkunft, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.edtHilfeText, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblFrage, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblFehler, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblHilfe, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.edtFehler, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1046, 382);
            this.tableLayoutPanel1.TabIndex = 34;
            // 
            // ctlGotoFall
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.ctlGotoFall, 2);
            this.ctlGotoFall.DataMember = "BaPersonID";
            this.ctlGotoFall.DataSource = this.qryFrageWert;
            this.ctlGotoFall.Location = new System.Drawing.Point(3, 3);
            this.ctlGotoFall.Name = "ctlGotoFall";
            this.ctlGotoFall.Size = new System.Drawing.Size(220, 24);
            this.ctlGotoFall.TabIndex = 33;
            // 
            // qryFrageWert
            // 
            this.qryFrageWert.AutoApplyUserRights = false;
            this.qryFrageWert.BatchUpdate = true;
            this.qryFrageWert.CanUpdate = true;
            this.qryFrageWert.HostControl = this;
            this.qryFrageWert.IsIdentityInsert = false;
            this.qryFrageWert.SelectStatement = resources.GetString("qryFrageWert.SelectStatement");
            this.qryFrageWert.TableName = "BfsWert";
            // 
            // edtHerkunft
            // 
            this.edtHerkunft.DataMember = "HerkunftBeschreibung";
            this.edtHerkunft.DataSource = this.qryFrageWert;
            this.edtHerkunft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtHerkunft.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtHerkunft.Location = new System.Drawing.Point(596, 153);
            this.edtHerkunft.Name = "edtHerkunft";
            this.edtHerkunft.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtHerkunft.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHerkunft.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHerkunft.Properties.Appearance.Options.UseBackColor = true;
            this.edtHerkunft.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHerkunft.Properties.Appearance.Options.UseFont = true;
            this.edtHerkunft.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHerkunft.Properties.ReadOnly = true;
            this.edtHerkunft.Size = new System.Drawing.Size(447, 226);
            this.edtHerkunft.TabIndex = 32;
            // 
            // edtFrage
            // 
            this.edtFrage.DataMember = "Frage";
            this.edtFrage.DataSource = this.qryFrageWert;
            this.edtFrage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtFrage.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtFrage.Location = new System.Drawing.Point(73, 38);
            this.edtFrage.Name = "edtFrage";
            this.edtFrage.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtFrage.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFrage.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFrage.Properties.Appearance.Options.UseBackColor = true;
            this.edtFrage.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFrage.Properties.Appearance.Options.UseFont = true;
            this.edtFrage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFrage.Properties.ReadOnly = true;
            this.edtFrage.Size = new System.Drawing.Size(447, 109);
            this.edtFrage.TabIndex = 26;
            // 
            // lblHerkunft
            // 
            this.lblHerkunft.Location = new System.Drawing.Point(526, 150);
            this.lblHerkunft.Name = "lblHerkunft";
            this.lblHerkunft.Size = new System.Drawing.Size(60, 24);
            this.lblHerkunft.TabIndex = 31;
            this.lblHerkunft.Text = "Herkunft";
            this.lblHerkunft.UseCompatibleTextRendering = true;
            // 
            // edtHilfeText
            // 
            this.edtHilfeText.DataMember = "HilfeText";
            this.edtHilfeText.DataSource = this.qryFrageWert;
            this.edtHilfeText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtHilfeText.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtHilfeText.Location = new System.Drawing.Point(73, 153);
            this.edtHilfeText.Name = "edtHilfeText";
            this.edtHilfeText.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtHilfeText.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHilfeText.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHilfeText.Properties.Appearance.Options.UseBackColor = true;
            this.edtHilfeText.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHilfeText.Properties.Appearance.Options.UseFont = true;
            this.edtHilfeText.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHilfeText.Properties.ReadOnly = true;
            this.edtHilfeText.Size = new System.Drawing.Size(447, 226);
            this.edtHilfeText.TabIndex = 28;
            // 
            // lblFrage
            // 
            this.lblFrage.Location = new System.Drawing.Point(3, 35);
            this.lblFrage.Name = "lblFrage";
            this.lblFrage.Size = new System.Drawing.Size(57, 24);
            this.lblFrage.TabIndex = 25;
            this.lblFrage.Text = "Frage";
            this.lblFrage.UseCompatibleTextRendering = true;
            // 
            // lblFehler
            // 
            this.lblFehler.Location = new System.Drawing.Point(526, 35);
            this.lblFehler.Name = "lblFehler";
            this.lblFehler.Size = new System.Drawing.Size(60, 24);
            this.lblFehler.TabIndex = 29;
            this.lblFehler.Text = "Fehler";
            this.lblFehler.UseCompatibleTextRendering = true;
            // 
            // lblHilfe
            // 
            this.lblHilfe.Location = new System.Drawing.Point(3, 150);
            this.lblHilfe.Name = "lblHilfe";
            this.lblHilfe.Size = new System.Drawing.Size(57, 24);
            this.lblHilfe.TabIndex = 27;
            this.lblHilfe.Text = "Hilfe";
            this.lblHilfe.UseCompatibleTextRendering = true;
            // 
            // edtFehler
            // 
            this.edtFehler.DataMember = "PlausiFehler";
            this.edtFehler.DataSource = this.qryFrageWert;
            this.edtFehler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtFehler.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtFehler.Location = new System.Drawing.Point(596, 38);
            this.edtFehler.Name = "edtFehler";
            this.edtFehler.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtFehler.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFehler.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFehler.Properties.Appearance.Options.UseBackColor = true;
            this.edtFehler.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFehler.Properties.Appearance.Options.UseFont = true;
            this.edtFehler.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFehler.Properties.ReadOnly = true;
            this.edtFehler.Size = new System.Drawing.Size(447, 109);
            this.edtFehler.TabIndex = 30;
            // 
            // lblSucheErhebungsjahr
            // 
            this.lblSucheErhebungsjahr.Location = new System.Drawing.Point(8, 44);
            this.lblSucheErhebungsjahr.Name = "lblSucheErhebungsjahr";
            this.lblSucheErhebungsjahr.Size = new System.Drawing.Size(119, 24);
            this.lblSucheErhebungsjahr.TabIndex = 1;
            this.lblSucheErhebungsjahr.Text = "Erhebungsjahr";
            this.lblSucheErhebungsjahr.UseCompatibleTextRendering = true;
            // 
            // edtErhebungsjahrX
            // 
            this.edtErhebungsjahrX.Location = new System.Drawing.Point(133, 44);
            this.edtErhebungsjahrX.Name = "edtErhebungsjahrX";
            this.edtErhebungsjahrX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtErhebungsjahrX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErhebungsjahrX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErhebungsjahrX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErhebungsjahrX.Properties.Appearance.Options.UseBackColor = true;
            this.edtErhebungsjahrX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErhebungsjahrX.Properties.Appearance.Options.UseFont = true;
            this.edtErhebungsjahrX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtErhebungsjahrX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErhebungsjahrX.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtErhebungsjahrX.Properties.Mask.EditMask = "####";
            this.edtErhebungsjahrX.Properties.MaxLength = 4;
            this.edtErhebungsjahrX.Properties.Precision = 0;
            this.edtErhebungsjahrX.Size = new System.Drawing.Size(75, 24);
            this.edtErhebungsjahrX.TabIndex = 0;
            // 
            // lblSucheMitarbeiterIn
            // 
            this.lblSucheMitarbeiterIn.Location = new System.Drawing.Point(8, 74);
            this.lblSucheMitarbeiterIn.Name = "lblSucheMitarbeiterIn";
            this.lblSucheMitarbeiterIn.Size = new System.Drawing.Size(119, 24);
            this.lblSucheMitarbeiterIn.TabIndex = 3;
            this.lblSucheMitarbeiterIn.Text = "Mitarbeiter/-in";
            this.lblSucheMitarbeiterIn.UseCompatibleTextRendering = true;
            // 
            // edtSARX
            // 
            this.edtSARX.Location = new System.Drawing.Point(133, 74);
            this.edtSARX.Name = "edtSARX";
            this.edtSARX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSARX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSARX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSARX.Properties.Appearance.Options.UseBackColor = true;
            this.edtSARX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSARX.Properties.Appearance.Options.UseFont = true;
            this.edtSARX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtSARX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtSARX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSARX.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSARX.Size = new System.Drawing.Size(271, 24);
            this.edtSARX.TabIndex = 1;
            this.edtSARX.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSARX_UserModifiedFld);
            // 
            // lblSuchePerson
            // 
            this.lblSuchePerson.Location = new System.Drawing.Point(8, 104);
            this.lblSuchePerson.Name = "lblSuchePerson";
            this.lblSuchePerson.Size = new System.Drawing.Size(119, 24);
            this.lblSuchePerson.TabIndex = 5;
            this.lblSuchePerson.Text = "Person";
            this.lblSuchePerson.UseCompatibleTextRendering = true;
            // 
            // edtNurStichtagX
            // 
            this.edtNurStichtagX.EditValue = true;
            this.edtNurStichtagX.Location = new System.Drawing.Point(133, 194);
            this.edtNurStichtagX.Name = "edtNurStichtagX";
            this.edtNurStichtagX.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtNurStichtagX.Properties.Appearance.Options.UseBackColor = true;
            this.edtNurStichtagX.Properties.Caption = "Stichtag";
            this.edtNurStichtagX.Size = new System.Drawing.Size(89, 19);
            this.edtNurStichtagX.TabIndex = 5;
            // 
            // edtNurAnfangszustandX
            // 
            this.edtNurAnfangszustandX.EditValue = true;
            this.edtNurAnfangszustandX.Location = new System.Drawing.Point(228, 194);
            this.edtNurAnfangszustandX.Name = "edtNurAnfangszustandX";
            this.edtNurAnfangszustandX.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtNurAnfangszustandX.Properties.Appearance.Options.UseBackColor = true;
            this.edtNurAnfangszustandX.Properties.Caption = "Anfangszustand";
            this.edtNurAnfangszustandX.Size = new System.Drawing.Size(124, 19);
            this.edtNurAnfangszustandX.TabIndex = 6;
            // 
            // lblSucheLeistungsart
            // 
            this.lblSucheLeistungsart.Location = new System.Drawing.Point(8, 219);
            this.lblSucheLeistungsart.Name = "lblSucheLeistungsart";
            this.lblSucheLeistungsart.Size = new System.Drawing.Size(119, 24);
            this.lblSucheLeistungsart.TabIndex = 13;
            this.lblSucheLeistungsart.Text = "Leistungsart";
            this.lblSucheLeistungsart.UseCompatibleTextRendering = true;
            // 
            // edtLeistungsartX
            // 
            this.edtLeistungsartX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.edtLeistungsartX.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.edtLeistungsartX.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLeistungsartX.Appearance.Options.UseBackColor = true;
            this.edtLeistungsartX.Appearance.Options.UseBorderColor = true;
            this.edtLeistungsartX.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtLeistungsartX.CheckOnClick = true;
            this.edtLeistungsartX.Location = new System.Drawing.Point(133, 219);
            this.edtLeistungsartX.LookupSQL = "SELECT Code, Text\r\nFROM BFSLOVCode\r\nWHERE LOVName = \'BFSLeistungsart\'";
            this.edtLeistungsartX.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.edtLeistungsartX.Name = "edtLeistungsartX";
            this.edtLeistungsartX.Size = new System.Drawing.Size(271, 579);
            this.edtLeistungsartX.TabIndex = 7;
            // 
            // popUpMenu
            // 
            this.popUpMenu.Manager = this.barManager;
            this.popUpMenu.Name = "popUpMenu";
            // 
            // edtBFSDefault
            // 
            this.edtBFSDefault.Location = new System.Drawing.Point(0, 0);
            this.edtBFSDefault.Name = "edtBFSDefault";
            this.edtBFSDefault.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBFSDefault.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBFSDefault.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBFSDefault.Properties.Appearance.Options.UseBackColor = true;
            this.edtBFSDefault.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBFSDefault.Properties.Appearance.Options.UseFont = true;
            this.edtBFSDefault.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBFSDefault.Size = new System.Drawing.Size(100, 24);
            this.edtBFSDefault.TabIndex = 0;
            // 
            // qryAnswersOfDossier
            // 
            this.qryAnswersOfDossier.HostControl = this;
            this.qryAnswersOfDossier.IsIdentityInsert = false;
            this.qryAnswersOfDossier.SelectStatement = resources.GetString("qryAnswersOfDossier.SelectStatement");
            // 
            // qryDatabind
            // 
            this.qryDatabind.CanUpdate = true;
            this.qryDatabind.HostControl = this;
            this.qryDatabind.IsIdentityInsert = false;
            this.qryDatabind.BeforePost += new System.EventHandler(this.qryDatabind_BeforePost);
            this.qryDatabind.ColumnChanged += new System.Data.DataColumnChangeEventHandler(this.qryDatabind_ColumnChanged);
            // 
            // ttpError
            // 
            this.ttpError.ToolTipTitle = "Error";
            // 
            // edtSucheBFSDossierID
            // 
            this.edtSucheBFSDossierID.Location = new System.Drawing.Point(133, 164);
            this.edtSucheBFSDossierID.Name = "edtSucheBFSDossierID";
            this.edtSucheBFSDossierID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheBFSDossierID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBFSDossierID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBFSDossierID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBFSDossierID.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBFSDossierID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBFSDossierID.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBFSDossierID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheBFSDossierID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheBFSDossierID.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSucheBFSDossierID.Properties.Precision = 0;
            this.edtSucheBFSDossierID.Size = new System.Drawing.Size(75, 24);
            this.edtSucheBFSDossierID.TabIndex = 4;
            // 
            // lblSucheBFSDossierID
            // 
            this.lblSucheBFSDossierID.Location = new System.Drawing.Point(8, 164);
            this.lblSucheBFSDossierID.Name = "lblSucheBFSDossierID";
            this.lblSucheBFSDossierID.Size = new System.Drawing.Size(119, 24);
            this.lblSucheBFSDossierID.TabIndex = 9;
            this.lblSucheBFSDossierID.Text = "Dossier-ID";
            this.lblSucheBFSDossierID.UseCompatibleTextRendering = true;
            // 
            // lblSucheBFSDossierNr
            // 
            this.lblSucheBFSDossierNr.Location = new System.Drawing.Point(8, 134);
            this.lblSucheBFSDossierNr.Name = "lblSucheBFSDossierNr";
            this.lblSucheBFSDossierNr.Size = new System.Drawing.Size(119, 24);
            this.lblSucheBFSDossierNr.TabIndex = 7;
            this.lblSucheBFSDossierNr.Text = "Dossier-Nr.";
            this.lblSucheBFSDossierNr.UseCompatibleTextRendering = true;
            // 
            // edtBaPersonIDX
            // 
            this.edtBaPersonIDX.Location = new System.Drawing.Point(133, 104);
            this.edtBaPersonIDX.Name = "edtBaPersonIDX";
            this.edtBaPersonIDX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaPersonIDX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonIDX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonIDX.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonIDX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonIDX.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonIDX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtBaPersonIDX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtBaPersonIDX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonIDX.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtBaPersonIDX.Size = new System.Drawing.Size(271, 24);
            this.edtBaPersonIDX.TabIndex = 2;
            this.edtBaPersonIDX.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtBaPersonIDX_UserModifiedFld);
            // 
            // edtSucheBFSDossierNr
            // 
            this.edtSucheBFSDossierNr.Location = new System.Drawing.Point(133, 134);
            this.edtSucheBFSDossierNr.Name = "edtSucheBFSDossierNr";
            this.edtSucheBFSDossierNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBFSDossierNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBFSDossierNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBFSDossierNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBFSDossierNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBFSDossierNr.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBFSDossierNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheBFSDossierNr.Size = new System.Drawing.Size(150, 24);
            this.edtSucheBFSDossierNr.TabIndex = 3;
            // 
            // CtlBfsDossiers
            // 
            this.ActiveSQLQuery = this.qryClientTree;
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "CtlBfsDossiers";
            this.Size = new System.Drawing.Size(1377, 845);
            this.Load += new System.EventHandler(this.CtlBfsDossiers_Load);
            this.Controls.SetChildIndex(this.barDockControlTop, 0);
            this.Controls.SetChildIndex(this.barDockControlBottom, 0);
            this.Controls.SetChildIndex(this.barDockControlRight, 0);
            this.Controls.SetChildIndex(this.barDockControlLeft, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            this.panTree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treClient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemTextEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryClientTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            this.panTreeButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblEntriesCount)).EndInit();
            this.panMain.ResumeLayout(false);
            this.panAll.ResumeLayout(false);
            this.panDetail.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qryFrageWert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHerkunft.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFrage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHerkunft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHilfeText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFrage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFehler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHilfe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFehler.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheErhebungsjahr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErhebungsjahrX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMitarbeiterIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSARX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchePerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurStichtagX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurAnfangszustandX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheLeistungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLeistungsartX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popUpMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSDefault.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAnswersOfDossier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryDatabind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBFSDossierID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBFSDossierID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBFSDossierNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonIDX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBFSDossierNr.Properties)).EndInit();
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
