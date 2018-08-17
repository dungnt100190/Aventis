namespace KiSS4.Basis.ZH.Strassenverzeichnis
{
    partial class FrmBaStrassenverzeichnis
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnUpdate = new KiSS4.Gui.KissButton();
            this.tabMain = new KiSS4.Gui.KissTabControlEx();
            this.tbpUpdate = new SharpLibrary.WinControls.TabPageEx();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.btnAccept = new KiSS4.Gui.KissButton();
            this.grdHausNeu = new KiSS4.Gui.KissGrid();
            this.grvHausNeu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colHausNeu_Strasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHausNeu_QT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit7 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grdStrassenNeu = new KiSS4.Gui.KissGrid();
            this.grvStrasseNeu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStrasseNeuID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasseNeuName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit6 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grdDifferenzenHaus = new KiSS4.Gui.KissGrid();
            this.grvDifferenzenHaus = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colHausDiff_Strasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiffHaus_QT_bisher = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiffHaus_QT_neu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grdDifferenzenStrasse = new KiSS4.Gui.KissGrid();
            this.grvDifferenzenStrasse = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDiffStr_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiffStr_NameBisher = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiffStr_NameNeu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.lblDiffStrasse = new KiSS4.Gui.KissLabel();
            this.tbpUebersicht = new SharpLibrary.WinControls.TabPageEx();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.lblImportedBaHaus = new KiSS4.Gui.KissLabel();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.grdBaStrasseEingelesen = new KiSS4.Gui.KissGrid();
            this.grvBaStrasseEingelesen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStrasse_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasse_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grdBaHausEingelesen = new KiSS4.Gui.KissGrid();
            this.grvBaHausEingelesen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colHaus_Hausnummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHaus_Suffix = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHaus_QT_Import = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHaus_QT_Kiss = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHaus_PLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHaus_Kreis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHaus_Quartier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHaus_Zone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHaus_StatistischeZone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grdImport = new KiSS4.Gui.KissGrid();
            this.grvImport = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBaStrasseID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrassenName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHausnummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSuffix = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQTKiSS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKreis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuartier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatistischeZone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.tabMain.SuspendLayout();
            this.tbpUpdate.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHausNeu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvHausNeu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStrassenNeu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStrasseNeu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDifferenzenHaus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDifferenzenHaus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDifferenzenStrasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDifferenzenStrasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDiffStrasse)).BeginInit();
            this.tbpUebersicht.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblImportedBaHaus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaStrasseEingelesen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaStrasseEingelesen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaHausEingelesen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaHausEingelesen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Location = new System.Drawing.Point(3, 3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(124, 24);
            this.btnUpdate.TabIndex = 327;
            this.btnUpdate.Text = "Datei einlesen...";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tbpUpdate);
            this.tabMain.Controls.Add(this.tbpUebersicht);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedTabIndex = 1;
            this.tabMain.ShowFixedWidthTooltip = true;
            this.tabMain.Size = new System.Drawing.Size(949, 474);
            this.tabMain.TabIndex = 328;
            this.tabMain.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tbpUebersicht,
            this.tbpUpdate});
            this.tabMain.TabsLineColor = System.Drawing.Color.Black;
            this.tabMain.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabMain.Text = "kissTabControlEx1";
            // 
            // tbpUpdate
            // 
            this.tbpUpdate.Controls.Add(this.tableLayoutPanel2);
            this.tbpUpdate.Location = new System.Drawing.Point(6, 6);
            this.tbpUpdate.Name = "tbpUpdate";
            this.tbpUpdate.Size = new System.Drawing.Size(937, 436);
            this.tbpUpdate.TabIndex = 1;
            this.tbpUpdate.Title = "Update";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.kissLabel3, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.kissLabel2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.kissLabel1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnAccept, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.grdHausNeu, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.grdStrassenNeu, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.grdDifferenzenHaus, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.grdDifferenzenStrasse, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblDiffStrasse, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(937, 436);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // kissLabel3
            // 
            this.kissLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kissLabel3.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel3.Location = new System.Drawing.Point(471, 203);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.kissLabel3.Size = new System.Drawing.Size(463, 30);
            this.kissLabel3.TabIndex = 338;
            this.kissLabel3.Text = "Neue Adressen";
            // 
            // kissLabel2
            // 
            this.kissLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kissLabel2.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel2.Location = new System.Drawing.Point(3, 203);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.kissLabel2.Size = new System.Drawing.Size(462, 30);
            this.kissLabel2.TabIndex = 337;
            this.kissLabel2.Text = "Neue Strassen";
            // 
            // kissLabel1
            // 
            this.kissLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kissLabel1.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel1.Location = new System.Drawing.Point(471, 0);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.kissLabel1.Size = new System.Drawing.Size(463, 30);
            this.kissLabel1.TabIndex = 336;
            this.kissLabel1.Text = "Geänderte Adressen";
            // 
            // btnAccept
            // 
            this.btnAccept.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(713, 409);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(221, 24);
            this.btnAccept.TabIndex = 328;
            this.btnAccept.Text = "Änderungen anwenden";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // grdHausNeu
            // 
            this.grdHausNeu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdHausNeu.EmbeddedNavigator.Name = "";
            this.grdHausNeu.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdHausNeu.Location = new System.Drawing.Point(471, 236);
            this.grdHausNeu.MainView = this.grvHausNeu;
            this.grdHausNeu.Name = "grdHausNeu";
            this.grdHausNeu.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit7});
            this.grdHausNeu.Size = new System.Drawing.Size(463, 167);
            this.grdHausNeu.TabIndex = 334;
            this.grdHausNeu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvHausNeu});
            // 
            // grvHausNeu
            // 
            this.grvHausNeu.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvHausNeu.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHausNeu.Appearance.Empty.Options.UseBackColor = true;
            this.grvHausNeu.Appearance.Empty.Options.UseFont = true;
            this.grvHausNeu.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHausNeu.Appearance.EvenRow.Options.UseFont = true;
            this.grvHausNeu.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvHausNeu.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHausNeu.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvHausNeu.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvHausNeu.Appearance.FocusedCell.Options.UseFont = true;
            this.grvHausNeu.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvHausNeu.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvHausNeu.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHausNeu.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvHausNeu.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvHausNeu.Appearance.FocusedRow.Options.UseFont = true;
            this.grvHausNeu.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvHausNeu.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvHausNeu.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvHausNeu.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvHausNeu.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvHausNeu.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvHausNeu.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvHausNeu.Appearance.GroupRow.Options.UseFont = true;
            this.grvHausNeu.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvHausNeu.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvHausNeu.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvHausNeu.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvHausNeu.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvHausNeu.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvHausNeu.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvHausNeu.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvHausNeu.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHausNeu.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvHausNeu.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvHausNeu.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvHausNeu.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvHausNeu.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvHausNeu.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvHausNeu.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHausNeu.Appearance.OddRow.Options.UseFont = true;
            this.grvHausNeu.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvHausNeu.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHausNeu.Appearance.Row.Options.UseBackColor = true;
            this.grvHausNeu.Appearance.Row.Options.UseFont = true;
            this.grvHausNeu.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHausNeu.Appearance.SelectedRow.Options.UseFont = true;
            this.grvHausNeu.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvHausNeu.Appearance.VertLine.Options.UseBackColor = true;
            this.grvHausNeu.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvHausNeu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colHausNeu_Strasse,
            this.gridColumn1,
            this.gridColumn2,
            this.colHausNeu_QT,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18});
            this.grvHausNeu.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvHausNeu.GridControl = this.grdHausNeu;
            this.grvHausNeu.Name = "grvHausNeu";
            this.grvHausNeu.OptionsBehavior.Editable = false;
            this.grvHausNeu.OptionsCustomization.AllowFilter = false;
            this.grvHausNeu.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvHausNeu.OptionsNavigation.AutoFocusNewRow = true;
            this.grvHausNeu.OptionsNavigation.UseTabKey = false;
            this.grvHausNeu.OptionsView.ColumnAutoWidth = false;
            this.grvHausNeu.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvHausNeu.OptionsView.ShowGroupPanel = false;
            this.grvHausNeu.OptionsView.ShowIndicator = false;
            // 
            // colHausNeu_Strasse
            // 
            this.colHausNeu_Strasse.Caption = "Strasse";
            this.colHausNeu_Strasse.FieldName = "StrassenName";
            this.colHausNeu_Strasse.Name = "colHausNeu_Strasse";
            this.colHausNeu_Strasse.Visible = true;
            this.colHausNeu_Strasse.VisibleIndex = 0;
            this.colHausNeu_Strasse.Width = 140;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Hausnr.";
            this.gridColumn1.FieldName = "Hausnummer";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 54;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Zus.";
            this.gridColumn2.FieldName = "Suffix";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 36;
            // 
            // colHausNeu_QT
            // 
            this.colHausNeu_QT.Caption = "QT";
            this.colHausNeu_QT.FieldName = "OrgUnitID_QT";
            this.colHausNeu_QT.Name = "colHausNeu_QT";
            this.colHausNeu_QT.Visible = true;
            this.colHausNeu_QT.VisibleIndex = 3;
            this.colHausNeu_QT.Width = 110;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "QT (neu)";
            this.gridColumn13.FieldName = "OrgUnitID_QT";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Width = 120;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "PLZ";
            this.gridColumn14.FieldName = "PLZ";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 4;
            this.gridColumn14.Width = 40;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Kreis";
            this.gridColumn15.FieldName = "Kreis";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 5;
            this.gridColumn15.Width = 41;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Quartier";
            this.gridColumn16.FieldName = "Quartier";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 6;
            this.gridColumn16.Width = 57;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Zone";
            this.gridColumn17.FieldName = "Zone";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 7;
            this.gridColumn17.Width = 40;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Stat. Zone";
            this.gridColumn18.FieldName = "StatistischeZone";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 8;
            this.gridColumn18.Width = 67;
            // 
            // repositoryItemCheckEdit7
            // 
            this.repositoryItemCheckEdit7.AutoHeight = false;
            this.repositoryItemCheckEdit7.Name = "repositoryItemCheckEdit7";
            this.repositoryItemCheckEdit7.ValueChecked = 1;
            this.repositoryItemCheckEdit7.ValueUnchecked = 0;
            // 
            // grdStrassenNeu
            // 
            this.grdStrassenNeu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStrassenNeu.EmbeddedNavigator.Name = "";
            this.grdStrassenNeu.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdStrassenNeu.Location = new System.Drawing.Point(3, 236);
            this.grdStrassenNeu.MainView = this.grvStrasseNeu;
            this.grdStrassenNeu.Name = "grdStrassenNeu";
            this.grdStrassenNeu.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit6});
            this.grdStrassenNeu.Size = new System.Drawing.Size(462, 167);
            this.grdStrassenNeu.TabIndex = 333;
            this.grdStrassenNeu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvStrasseNeu});
            // 
            // grvStrasseNeu
            // 
            this.grvStrasseNeu.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvStrasseNeu.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvStrasseNeu.Appearance.Empty.Options.UseBackColor = true;
            this.grvStrasseNeu.Appearance.Empty.Options.UseFont = true;
            this.grvStrasseNeu.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvStrasseNeu.Appearance.EvenRow.Options.UseFont = true;
            this.grvStrasseNeu.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvStrasseNeu.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvStrasseNeu.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvStrasseNeu.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvStrasseNeu.Appearance.FocusedCell.Options.UseFont = true;
            this.grvStrasseNeu.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvStrasseNeu.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvStrasseNeu.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvStrasseNeu.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvStrasseNeu.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvStrasseNeu.Appearance.FocusedRow.Options.UseFont = true;
            this.grvStrasseNeu.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvStrasseNeu.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvStrasseNeu.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvStrasseNeu.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvStrasseNeu.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvStrasseNeu.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvStrasseNeu.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvStrasseNeu.Appearance.GroupRow.Options.UseFont = true;
            this.grvStrasseNeu.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvStrasseNeu.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvStrasseNeu.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvStrasseNeu.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvStrasseNeu.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvStrasseNeu.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvStrasseNeu.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvStrasseNeu.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvStrasseNeu.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvStrasseNeu.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvStrasseNeu.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvStrasseNeu.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvStrasseNeu.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvStrasseNeu.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvStrasseNeu.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvStrasseNeu.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvStrasseNeu.Appearance.OddRow.Options.UseFont = true;
            this.grvStrasseNeu.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvStrasseNeu.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvStrasseNeu.Appearance.Row.Options.UseBackColor = true;
            this.grvStrasseNeu.Appearance.Row.Options.UseFont = true;
            this.grvStrasseNeu.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvStrasseNeu.Appearance.SelectedRow.Options.UseFont = true;
            this.grvStrasseNeu.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvStrasseNeu.Appearance.VertLine.Options.UseBackColor = true;
            this.grvStrasseNeu.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvStrasseNeu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStrasseNeuID,
            this.colStrasseNeuName});
            this.grvStrasseNeu.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvStrasseNeu.GridControl = this.grdStrassenNeu;
            this.grvStrasseNeu.Name = "grvStrasseNeu";
            this.grvStrasseNeu.OptionsBehavior.Editable = false;
            this.grvStrasseNeu.OptionsCustomization.AllowFilter = false;
            this.grvStrasseNeu.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvStrasseNeu.OptionsNavigation.AutoFocusNewRow = true;
            this.grvStrasseNeu.OptionsNavigation.UseTabKey = false;
            this.grvStrasseNeu.OptionsView.ColumnAutoWidth = false;
            this.grvStrasseNeu.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvStrasseNeu.OptionsView.ShowGroupPanel = false;
            this.grvStrasseNeu.OptionsView.ShowIndicator = false;
            // 
            // colStrasseNeuID
            // 
            this.colStrasseNeuID.Caption = "ID";
            this.colStrasseNeuID.FieldName = "BaStrasseID";
            this.colStrasseNeuID.Name = "colStrasseNeuID";
            this.colStrasseNeuID.Visible = true;
            this.colStrasseNeuID.VisibleIndex = 0;
            this.colStrasseNeuID.Width = 50;
            // 
            // colStrasseNeuName
            // 
            this.colStrasseNeuName.Caption = "Name";
            this.colStrasseNeuName.FieldName = "StrassenName";
            this.colStrasseNeuName.Name = "colStrasseNeuName";
            this.colStrasseNeuName.Visible = true;
            this.colStrasseNeuName.VisibleIndex = 1;
            this.colStrasseNeuName.Width = 261;
            // 
            // repositoryItemCheckEdit6
            // 
            this.repositoryItemCheckEdit6.AutoHeight = false;
            this.repositoryItemCheckEdit6.Name = "repositoryItemCheckEdit6";
            this.repositoryItemCheckEdit6.ValueChecked = 1;
            this.repositoryItemCheckEdit6.ValueUnchecked = 0;
            // 
            // grdDifferenzenHaus
            // 
            this.grdDifferenzenHaus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDifferenzenHaus.EmbeddedNavigator.Name = "";
            this.grdDifferenzenHaus.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdDifferenzenHaus.Location = new System.Drawing.Point(471, 33);
            this.grdDifferenzenHaus.MainView = this.grvDifferenzenHaus;
            this.grdDifferenzenHaus.Name = "grdDifferenzenHaus";
            this.grdDifferenzenHaus.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit5});
            this.grdDifferenzenHaus.Size = new System.Drawing.Size(463, 167);
            this.grdDifferenzenHaus.TabIndex = 332;
            this.grdDifferenzenHaus.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDifferenzenHaus});
            // 
            // grvDifferenzenHaus
            // 
            this.grvDifferenzenHaus.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvDifferenzenHaus.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDifferenzenHaus.Appearance.Empty.Options.UseBackColor = true;
            this.grvDifferenzenHaus.Appearance.Empty.Options.UseFont = true;
            this.grvDifferenzenHaus.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDifferenzenHaus.Appearance.EvenRow.Options.UseFont = true;
            this.grvDifferenzenHaus.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvDifferenzenHaus.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDifferenzenHaus.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvDifferenzenHaus.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvDifferenzenHaus.Appearance.FocusedCell.Options.UseFont = true;
            this.grvDifferenzenHaus.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvDifferenzenHaus.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvDifferenzenHaus.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDifferenzenHaus.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvDifferenzenHaus.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvDifferenzenHaus.Appearance.FocusedRow.Options.UseFont = true;
            this.grvDifferenzenHaus.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvDifferenzenHaus.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvDifferenzenHaus.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvDifferenzenHaus.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvDifferenzenHaus.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvDifferenzenHaus.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvDifferenzenHaus.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvDifferenzenHaus.Appearance.GroupRow.Options.UseFont = true;
            this.grvDifferenzenHaus.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvDifferenzenHaus.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvDifferenzenHaus.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvDifferenzenHaus.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvDifferenzenHaus.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvDifferenzenHaus.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvDifferenzenHaus.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvDifferenzenHaus.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvDifferenzenHaus.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDifferenzenHaus.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvDifferenzenHaus.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvDifferenzenHaus.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvDifferenzenHaus.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvDifferenzenHaus.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvDifferenzenHaus.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvDifferenzenHaus.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDifferenzenHaus.Appearance.OddRow.Options.UseFont = true;
            this.grvDifferenzenHaus.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvDifferenzenHaus.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDifferenzenHaus.Appearance.Row.Options.UseBackColor = true;
            this.grvDifferenzenHaus.Appearance.Row.Options.UseFont = true;
            this.grvDifferenzenHaus.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDifferenzenHaus.Appearance.SelectedRow.Options.UseFont = true;
            this.grvDifferenzenHaus.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvDifferenzenHaus.Appearance.VertLine.Options.UseBackColor = true;
            this.grvDifferenzenHaus.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvDifferenzenHaus.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colHausDiff_Strasse,
            this.gridColumn3,
            this.gridColumn4,
            this.colDiffHaus_QT_bisher,
            this.colDiffHaus_QT_neu,
            this.gridColumn9,
            this.gridColumn7,
            this.gridColumn5,
            this.gridColumn8,
            this.gridColumn19,
            this.gridColumn20,
            this.gridColumn10,
            this.gridColumn6,
            this.gridColumn11,
            this.gridColumn12});
            this.grvDifferenzenHaus.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvDifferenzenHaus.GridControl = this.grdDifferenzenHaus;
            this.grvDifferenzenHaus.Name = "grvDifferenzenHaus";
            this.grvDifferenzenHaus.OptionsBehavior.Editable = false;
            this.grvDifferenzenHaus.OptionsCustomization.AllowFilter = false;
            this.grvDifferenzenHaus.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvDifferenzenHaus.OptionsNavigation.AutoFocusNewRow = true;
            this.grvDifferenzenHaus.OptionsNavigation.UseTabKey = false;
            this.grvDifferenzenHaus.OptionsView.ColumnAutoWidth = false;
            this.grvDifferenzenHaus.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvDifferenzenHaus.OptionsView.ShowGroupPanel = false;
            this.grvDifferenzenHaus.OptionsView.ShowIndicator = false;
            // 
            // colHausDiff_Strasse
            // 
            this.colHausDiff_Strasse.Caption = "Strasse";
            this.colHausDiff_Strasse.FieldName = "StrassenName";
            this.colHausDiff_Strasse.Name = "colHausDiff_Strasse";
            this.colHausDiff_Strasse.Visible = true;
            this.colHausDiff_Strasse.VisibleIndex = 0;
            this.colHausDiff_Strasse.Width = 140;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Hausnr.";
            this.gridColumn3.FieldName = "Hausnummer";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 54;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Zus.";
            this.gridColumn4.FieldName = "Suffix";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 36;
            // 
            // colDiffHaus_QT_bisher
            // 
            this.colDiffHaus_QT_bisher.Caption = "QT (bisher)";
            this.colDiffHaus_QT_bisher.FieldName = "OrgUnitID_bisher";
            this.colDiffHaus_QT_bisher.Name = "colDiffHaus_QT_bisher";
            this.colDiffHaus_QT_bisher.Visible = true;
            this.colDiffHaus_QT_bisher.VisibleIndex = 3;
            this.colDiffHaus_QT_bisher.Width = 110;
            // 
            // colDiffHaus_QT_neu
            // 
            this.colDiffHaus_QT_neu.Caption = "QT (neu)";
            this.colDiffHaus_QT_neu.FieldName = "OrgUnitID_neu";
            this.colDiffHaus_QT_neu.Name = "colDiffHaus_QT_neu";
            this.colDiffHaus_QT_neu.Visible = true;
            this.colDiffHaus_QT_neu.VisibleIndex = 4;
            this.colDiffHaus_QT_neu.Width = 120;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "PLZ (bisher)";
            this.gridColumn9.FieldName = "PLZ_alt";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 5;
            this.gridColumn9.Width = 70;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "PLZ (neu)";
            this.gridColumn7.FieldName = "PLZ_neu";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 70;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Kreis (bisher)";
            this.gridColumn5.FieldName = "Kreis_alt";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 7;
            this.gridColumn5.Width = 85;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Kreis (neu)";
            this.gridColumn8.FieldName = "Kreis_neu";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 8;
            this.gridColumn8.Width = 85;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Quartier (bisher)";
            this.gridColumn19.FieldName = "Quartier_alt";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 9;
            this.gridColumn19.Width = 85;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "Quartier (neu)";
            this.gridColumn20.FieldName = "Quartier_neu";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 10;
            this.gridColumn20.Width = 85;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Zone (bisher)";
            this.gridColumn10.FieldName = "Zone_alt";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 11;
            this.gridColumn10.Width = 70;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Zone (neu)";
            this.gridColumn6.FieldName = "Zone_neu";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 12;
            this.gridColumn6.Width = 70;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Stat. Zone (bisher)";
            this.gridColumn11.FieldName = "StatistischeZone_alt";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 13;
            this.gridColumn11.Width = 100;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Stat. Zone (neu)";
            this.gridColumn12.FieldName = "StatistischeZone_neu";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 14;
            this.gridColumn12.Width = 100;
            // 
            // repositoryItemCheckEdit5
            // 
            this.repositoryItemCheckEdit5.AutoHeight = false;
            this.repositoryItemCheckEdit5.Name = "repositoryItemCheckEdit5";
            this.repositoryItemCheckEdit5.ValueChecked = 1;
            this.repositoryItemCheckEdit5.ValueUnchecked = 0;
            // 
            // grdDifferenzenStrasse
            // 
            this.grdDifferenzenStrasse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDifferenzenStrasse.EmbeddedNavigator.Name = "";
            this.grdDifferenzenStrasse.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdDifferenzenStrasse.Location = new System.Drawing.Point(3, 33);
            this.grdDifferenzenStrasse.MainView = this.grvDifferenzenStrasse;
            this.grdDifferenzenStrasse.Name = "grdDifferenzenStrasse";
            this.grdDifferenzenStrasse.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit4});
            this.grdDifferenzenStrasse.Size = new System.Drawing.Size(462, 167);
            this.grdDifferenzenStrasse.TabIndex = 331;
            this.grdDifferenzenStrasse.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDifferenzenStrasse});
            // 
            // grvDifferenzenStrasse
            // 
            this.grvDifferenzenStrasse.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvDifferenzenStrasse.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDifferenzenStrasse.Appearance.Empty.Options.UseBackColor = true;
            this.grvDifferenzenStrasse.Appearance.Empty.Options.UseFont = true;
            this.grvDifferenzenStrasse.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDifferenzenStrasse.Appearance.EvenRow.Options.UseFont = true;
            this.grvDifferenzenStrasse.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvDifferenzenStrasse.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDifferenzenStrasse.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvDifferenzenStrasse.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvDifferenzenStrasse.Appearance.FocusedCell.Options.UseFont = true;
            this.grvDifferenzenStrasse.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvDifferenzenStrasse.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvDifferenzenStrasse.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDifferenzenStrasse.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvDifferenzenStrasse.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvDifferenzenStrasse.Appearance.FocusedRow.Options.UseFont = true;
            this.grvDifferenzenStrasse.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvDifferenzenStrasse.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvDifferenzenStrasse.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvDifferenzenStrasse.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvDifferenzenStrasse.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvDifferenzenStrasse.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvDifferenzenStrasse.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvDifferenzenStrasse.Appearance.GroupRow.Options.UseFont = true;
            this.grvDifferenzenStrasse.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvDifferenzenStrasse.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvDifferenzenStrasse.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvDifferenzenStrasse.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvDifferenzenStrasse.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvDifferenzenStrasse.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvDifferenzenStrasse.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvDifferenzenStrasse.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvDifferenzenStrasse.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDifferenzenStrasse.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvDifferenzenStrasse.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvDifferenzenStrasse.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvDifferenzenStrasse.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvDifferenzenStrasse.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvDifferenzenStrasse.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvDifferenzenStrasse.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDifferenzenStrasse.Appearance.OddRow.Options.UseFont = true;
            this.grvDifferenzenStrasse.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvDifferenzenStrasse.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDifferenzenStrasse.Appearance.Row.Options.UseBackColor = true;
            this.grvDifferenzenStrasse.Appearance.Row.Options.UseFont = true;
            this.grvDifferenzenStrasse.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDifferenzenStrasse.Appearance.SelectedRow.Options.UseFont = true;
            this.grvDifferenzenStrasse.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvDifferenzenStrasse.Appearance.VertLine.Options.UseBackColor = true;
            this.grvDifferenzenStrasse.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvDifferenzenStrasse.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDiffStr_ID,
            this.colDiffStr_NameBisher,
            this.colDiffStr_NameNeu});
            this.grvDifferenzenStrasse.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvDifferenzenStrasse.GridControl = this.grdDifferenzenStrasse;
            this.grvDifferenzenStrasse.Name = "grvDifferenzenStrasse";
            this.grvDifferenzenStrasse.OptionsBehavior.Editable = false;
            this.grvDifferenzenStrasse.OptionsCustomization.AllowFilter = false;
            this.grvDifferenzenStrasse.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvDifferenzenStrasse.OptionsNavigation.AutoFocusNewRow = true;
            this.grvDifferenzenStrasse.OptionsNavigation.UseTabKey = false;
            this.grvDifferenzenStrasse.OptionsView.ColumnAutoWidth = false;
            this.grvDifferenzenStrasse.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvDifferenzenStrasse.OptionsView.ShowGroupPanel = false;
            this.grvDifferenzenStrasse.OptionsView.ShowIndicator = false;
            // 
            // colDiffStr_ID
            // 
            this.colDiffStr_ID.Caption = "ID";
            this.colDiffStr_ID.FieldName = "BaStrasseID";
            this.colDiffStr_ID.Name = "colDiffStr_ID";
            this.colDiffStr_ID.Visible = true;
            this.colDiffStr_ID.VisibleIndex = 0;
            this.colDiffStr_ID.Width = 50;
            // 
            // colDiffStr_NameBisher
            // 
            this.colDiffStr_NameBisher.Caption = "Name (bisher)";
            this.colDiffStr_NameBisher.FieldName = "NameBisher";
            this.colDiffStr_NameBisher.Name = "colDiffStr_NameBisher";
            this.colDiffStr_NameBisher.Visible = true;
            this.colDiffStr_NameBisher.VisibleIndex = 1;
            this.colDiffStr_NameBisher.Width = 200;
            // 
            // colDiffStr_NameNeu
            // 
            this.colDiffStr_NameNeu.Caption = "Name (neu)";
            this.colDiffStr_NameNeu.FieldName = "NameNeu";
            this.colDiffStr_NameNeu.Name = "colDiffStr_NameNeu";
            this.colDiffStr_NameNeu.Visible = true;
            this.colDiffStr_NameNeu.VisibleIndex = 2;
            this.colDiffStr_NameNeu.Width = 200;
            // 
            // repositoryItemCheckEdit4
            // 
            this.repositoryItemCheckEdit4.AutoHeight = false;
            this.repositoryItemCheckEdit4.Name = "repositoryItemCheckEdit4";
            this.repositoryItemCheckEdit4.ValueChecked = 1;
            this.repositoryItemCheckEdit4.ValueUnchecked = 0;
            // 
            // lblDiffStrasse
            // 
            this.lblDiffStrasse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDiffStrasse.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblDiffStrasse.Location = new System.Drawing.Point(3, 0);
            this.lblDiffStrasse.Name = "lblDiffStrasse";
            this.lblDiffStrasse.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblDiffStrasse.Size = new System.Drawing.Size(462, 30);
            this.lblDiffStrasse.TabIndex = 335;
            this.lblDiffStrasse.Text = "Geänderte Strassen";
            // 
            // tbpUebersicht
            // 
            this.tbpUebersicht.Controls.Add(this.tableLayoutPanel1);
            this.tbpUebersicht.Location = new System.Drawing.Point(6, 6);
            this.tbpUebersicht.Name = "tbpUebersicht";
            this.tbpUebersicht.Size = new System.Drawing.Size(937, 436);
            this.tbpUebersicht.TabIndex = 0;
            this.tbpUebersicht.Title = "Import";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.kissLabel5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblImportedBaHaus, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.kissLabel4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.grdBaStrasseEingelesen, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.grdBaHausEingelesen, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.grdImport, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnUpdate, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(937, 436);
            this.tableLayoutPanel1.TabIndex = 328;
            // 
            // kissLabel5
            // 
            this.kissLabel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kissLabel5.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel5.Location = new System.Drawing.Point(3, 30);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.kissLabel5.Size = new System.Drawing.Size(368, 30);
            this.kissLabel5.TabIndex = 340;
            this.kissLabel5.Text = "Import (unstrukturiert)";
            // 
            // lblImportedBaHaus
            // 
            this.lblImportedBaHaus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblImportedBaHaus.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblImportedBaHaus.Location = new System.Drawing.Point(377, 233);
            this.lblImportedBaHaus.Name = "lblImportedBaHaus";
            this.lblImportedBaHaus.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblImportedBaHaus.Size = new System.Drawing.Size(557, 30);
            this.lblImportedBaHaus.TabIndex = 339;
            this.lblImportedBaHaus.Text = "Importierte Adressen";
            // 
            // kissLabel4
            // 
            this.kissLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kissLabel4.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel4.Location = new System.Drawing.Point(3, 233);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.kissLabel4.Size = new System.Drawing.Size(368, 30);
            this.kissLabel4.TabIndex = 338;
            this.kissLabel4.Text = "Importierte Strassen";
            // 
            // grdBaStrasseEingelesen
            // 
            this.grdBaStrasseEingelesen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBaStrasseEingelesen.EmbeddedNavigator.Name = "";
            this.grdBaStrasseEingelesen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBaStrasseEingelesen.Location = new System.Drawing.Point(3, 266);
            this.grdBaStrasseEingelesen.MainView = this.grvBaStrasseEingelesen;
            this.grdBaStrasseEingelesen.Name = "grdBaStrasseEingelesen";
            this.grdBaStrasseEingelesen.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit2});
            this.grdBaStrasseEingelesen.Size = new System.Drawing.Size(368, 167);
            this.grdBaStrasseEingelesen.TabIndex = 330;
            this.grdBaStrasseEingelesen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBaStrasseEingelesen});
            // 
            // grvBaStrasseEingelesen
            // 
            this.grvBaStrasseEingelesen.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBaStrasseEingelesen.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaStrasseEingelesen.Appearance.Empty.Options.UseBackColor = true;
            this.grvBaStrasseEingelesen.Appearance.Empty.Options.UseFont = true;
            this.grvBaStrasseEingelesen.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaStrasseEingelesen.Appearance.EvenRow.Options.UseFont = true;
            this.grvBaStrasseEingelesen.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaStrasseEingelesen.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaStrasseEingelesen.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBaStrasseEingelesen.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBaStrasseEingelesen.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBaStrasseEingelesen.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBaStrasseEingelesen.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaStrasseEingelesen.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaStrasseEingelesen.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBaStrasseEingelesen.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBaStrasseEingelesen.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBaStrasseEingelesen.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBaStrasseEingelesen.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaStrasseEingelesen.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBaStrasseEingelesen.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaStrasseEingelesen.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaStrasseEingelesen.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaStrasseEingelesen.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBaStrasseEingelesen.Appearance.GroupRow.Options.UseFont = true;
            this.grvBaStrasseEingelesen.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBaStrasseEingelesen.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBaStrasseEingelesen.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBaStrasseEingelesen.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaStrasseEingelesen.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBaStrasseEingelesen.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBaStrasseEingelesen.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBaStrasseEingelesen.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBaStrasseEingelesen.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaStrasseEingelesen.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaStrasseEingelesen.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBaStrasseEingelesen.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBaStrasseEingelesen.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBaStrasseEingelesen.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaStrasseEingelesen.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBaStrasseEingelesen.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaStrasseEingelesen.Appearance.OddRow.Options.UseFont = true;
            this.grvBaStrasseEingelesen.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBaStrasseEingelesen.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaStrasseEingelesen.Appearance.Row.Options.UseBackColor = true;
            this.grvBaStrasseEingelesen.Appearance.Row.Options.UseFont = true;
            this.grvBaStrasseEingelesen.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaStrasseEingelesen.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBaStrasseEingelesen.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaStrasseEingelesen.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBaStrasseEingelesen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBaStrasseEingelesen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStrasse_ID,
            this.colStrasse_Name});
            this.grvBaStrasseEingelesen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBaStrasseEingelesen.GridControl = this.grdBaStrasseEingelesen;
            this.grvBaStrasseEingelesen.Name = "grvBaStrasseEingelesen";
            this.grvBaStrasseEingelesen.OptionsBehavior.Editable = false;
            this.grvBaStrasseEingelesen.OptionsCustomization.AllowFilter = false;
            this.grvBaStrasseEingelesen.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBaStrasseEingelesen.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBaStrasseEingelesen.OptionsNavigation.UseTabKey = false;
            this.grvBaStrasseEingelesen.OptionsView.ColumnAutoWidth = false;
            this.grvBaStrasseEingelesen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBaStrasseEingelesen.OptionsView.ShowGroupPanel = false;
            this.grvBaStrasseEingelesen.OptionsView.ShowIndicator = false;
            this.grvBaStrasseEingelesen.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvBaStrasseEingelesen_FocusedRowChanged);
            // 
            // colStrasse_ID
            // 
            this.colStrasse_ID.Caption = "ID";
            this.colStrasse_ID.FieldName = "BaStrasseID";
            this.colStrasse_ID.Name = "colStrasse_ID";
            this.colStrasse_ID.Visible = true;
            this.colStrasse_ID.VisibleIndex = 0;
            // 
            // colStrasse_Name
            // 
            this.colStrasse_Name.Caption = "Strassenname";
            this.colStrasse_Name.FieldName = "StrassenName";
            this.colStrasse_Name.Name = "colStrasse_Name";
            this.colStrasse_Name.Visible = true;
            this.colStrasse_Name.VisibleIndex = 1;
            this.colStrasse_Name.Width = 250;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            this.repositoryItemCheckEdit2.ValueChecked = 1;
            this.repositoryItemCheckEdit2.ValueUnchecked = 0;
            // 
            // grdBaHausEingelesen
            // 
            this.grdBaHausEingelesen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBaHausEingelesen.EmbeddedNavigator.Name = "";
            this.grdBaHausEingelesen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBaHausEingelesen.Location = new System.Drawing.Point(377, 266);
            this.grdBaHausEingelesen.MainView = this.grvBaHausEingelesen;
            this.grdBaHausEingelesen.Name = "grdBaHausEingelesen";
            this.grdBaHausEingelesen.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit3});
            this.grdBaHausEingelesen.Size = new System.Drawing.Size(557, 167);
            this.grdBaHausEingelesen.TabIndex = 330;
            this.grdBaHausEingelesen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBaHausEingelesen});
            // 
            // grvBaHausEingelesen
            // 
            this.grvBaHausEingelesen.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBaHausEingelesen.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaHausEingelesen.Appearance.Empty.Options.UseBackColor = true;
            this.grvBaHausEingelesen.Appearance.Empty.Options.UseFont = true;
            this.grvBaHausEingelesen.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaHausEingelesen.Appearance.EvenRow.Options.UseFont = true;
            this.grvBaHausEingelesen.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaHausEingelesen.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaHausEingelesen.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBaHausEingelesen.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBaHausEingelesen.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBaHausEingelesen.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBaHausEingelesen.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaHausEingelesen.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaHausEingelesen.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBaHausEingelesen.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBaHausEingelesen.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBaHausEingelesen.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBaHausEingelesen.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaHausEingelesen.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBaHausEingelesen.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaHausEingelesen.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaHausEingelesen.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaHausEingelesen.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBaHausEingelesen.Appearance.GroupRow.Options.UseFont = true;
            this.grvBaHausEingelesen.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBaHausEingelesen.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBaHausEingelesen.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBaHausEingelesen.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaHausEingelesen.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBaHausEingelesen.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBaHausEingelesen.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBaHausEingelesen.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBaHausEingelesen.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaHausEingelesen.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaHausEingelesen.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBaHausEingelesen.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBaHausEingelesen.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBaHausEingelesen.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaHausEingelesen.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBaHausEingelesen.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaHausEingelesen.Appearance.OddRow.Options.UseFont = true;
            this.grvBaHausEingelesen.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBaHausEingelesen.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaHausEingelesen.Appearance.Row.Options.UseBackColor = true;
            this.grvBaHausEingelesen.Appearance.Row.Options.UseFont = true;
            this.grvBaHausEingelesen.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaHausEingelesen.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBaHausEingelesen.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaHausEingelesen.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBaHausEingelesen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBaHausEingelesen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colHaus_Hausnummer,
            this.colHaus_Suffix,
            this.colHaus_QT_Import,
            this.colHaus_QT_Kiss,
            this.colHaus_PLZ,
            this.colHaus_Kreis,
            this.colHaus_Quartier,
            this.colHaus_Zone,
            this.colHaus_StatistischeZone});
            this.grvBaHausEingelesen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBaHausEingelesen.GridControl = this.grdBaHausEingelesen;
            this.grvBaHausEingelesen.Name = "grvBaHausEingelesen";
            this.grvBaHausEingelesen.OptionsBehavior.Editable = false;
            this.grvBaHausEingelesen.OptionsCustomization.AllowFilter = false;
            this.grvBaHausEingelesen.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBaHausEingelesen.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBaHausEingelesen.OptionsNavigation.UseTabKey = false;
            this.grvBaHausEingelesen.OptionsView.ColumnAutoWidth = false;
            this.grvBaHausEingelesen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBaHausEingelesen.OptionsView.ShowGroupPanel = false;
            this.grvBaHausEingelesen.OptionsView.ShowIndicator = false;
            // 
            // colHaus_Hausnummer
            // 
            this.colHaus_Hausnummer.Caption = "Hausnr.";
            this.colHaus_Hausnummer.FieldName = "Hausnummer";
            this.colHaus_Hausnummer.Name = "colHaus_Hausnummer";
            this.colHaus_Hausnummer.Visible = true;
            this.colHaus_Hausnummer.VisibleIndex = 0;
            this.colHaus_Hausnummer.Width = 54;
            // 
            // colHaus_Suffix
            // 
            this.colHaus_Suffix.Caption = "Zus.";
            this.colHaus_Suffix.FieldName = "Suffix";
            this.colHaus_Suffix.Name = "colHaus_Suffix";
            this.colHaus_Suffix.Visible = true;
            this.colHaus_Suffix.VisibleIndex = 1;
            this.colHaus_Suffix.Width = 36;
            // 
            // colHaus_QT_Import
            // 
            this.colHaus_QT_Import.Caption = "QT (import)";
            this.colHaus_QT_Import.FieldName = "QuartierTeam";
            this.colHaus_QT_Import.Name = "colHaus_QT_Import";
            this.colHaus_QT_Import.Visible = true;
            this.colHaus_QT_Import.VisibleIndex = 2;
            this.colHaus_QT_Import.Width = 110;
            // 
            // colHaus_QT_Kiss
            // 
            this.colHaus_QT_Kiss.Caption = "QT (KiSS)";
            this.colHaus_QT_Kiss.FieldName = "OrgUnitID_QT";
            this.colHaus_QT_Kiss.Name = "colHaus_QT_Kiss";
            this.colHaus_QT_Kiss.Visible = true;
            this.colHaus_QT_Kiss.VisibleIndex = 3;
            this.colHaus_QT_Kiss.Width = 120;
            // 
            // colHaus_PLZ
            // 
            this.colHaus_PLZ.Caption = "PLZ";
            this.colHaus_PLZ.FieldName = "PLZ";
            this.colHaus_PLZ.Name = "colHaus_PLZ";
            this.colHaus_PLZ.Visible = true;
            this.colHaus_PLZ.VisibleIndex = 4;
            this.colHaus_PLZ.Width = 40;
            // 
            // colHaus_Kreis
            // 
            this.colHaus_Kreis.Caption = "Kreis";
            this.colHaus_Kreis.FieldName = "Kreis";
            this.colHaus_Kreis.Name = "colHaus_Kreis";
            this.colHaus_Kreis.Visible = true;
            this.colHaus_Kreis.VisibleIndex = 5;
            this.colHaus_Kreis.Width = 41;
            // 
            // colHaus_Quartier
            // 
            this.colHaus_Quartier.Caption = "Quartier";
            this.colHaus_Quartier.FieldName = "Quartier";
            this.colHaus_Quartier.Name = "colHaus_Quartier";
            this.colHaus_Quartier.Visible = true;
            this.colHaus_Quartier.VisibleIndex = 6;
            this.colHaus_Quartier.Width = 57;
            // 
            // colHaus_Zone
            // 
            this.colHaus_Zone.Caption = "Zone";
            this.colHaus_Zone.FieldName = "Zone";
            this.colHaus_Zone.Name = "colHaus_Zone";
            this.colHaus_Zone.Visible = true;
            this.colHaus_Zone.VisibleIndex = 7;
            this.colHaus_Zone.Width = 40;
            // 
            // colHaus_StatistischeZone
            // 
            this.colHaus_StatistischeZone.Caption = "Stat. Zone";
            this.colHaus_StatistischeZone.FieldName = "StatistischeZone";
            this.colHaus_StatistischeZone.Name = "colHaus_StatistischeZone";
            this.colHaus_StatistischeZone.Visible = true;
            this.colHaus_StatistischeZone.VisibleIndex = 8;
            this.colHaus_StatistischeZone.Width = 67;
            // 
            // repositoryItemCheckEdit3
            // 
            this.repositoryItemCheckEdit3.AutoHeight = false;
            this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
            this.repositoryItemCheckEdit3.ValueChecked = 1;
            this.repositoryItemCheckEdit3.ValueUnchecked = 0;
            // 
            // grdImport
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grdImport, 2);
            this.grdImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdImport.EmbeddedNavigator.Name = "";
            this.grdImport.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdImport.Location = new System.Drawing.Point(3, 63);
            this.grdImport.MainView = this.grvImport;
            this.grdImport.Name = "grdImport";
            this.grdImport.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemLookUpEdit1});
            this.grdImport.Size = new System.Drawing.Size(931, 167);
            this.grdImport.TabIndex = 329;
            this.grdImport.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvImport});
            // 
            // grvImport
            // 
            this.grvImport.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvImport.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvImport.Appearance.Empty.Options.UseBackColor = true;
            this.grvImport.Appearance.Empty.Options.UseFont = true;
            this.grvImport.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvImport.Appearance.EvenRow.Options.UseFont = true;
            this.grvImport.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvImport.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvImport.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvImport.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvImport.Appearance.FocusedCell.Options.UseFont = true;
            this.grvImport.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvImport.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvImport.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvImport.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvImport.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvImport.Appearance.FocusedRow.Options.UseFont = true;
            this.grvImport.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvImport.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvImport.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvImport.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvImport.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvImport.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvImport.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvImport.Appearance.GroupRow.Options.UseFont = true;
            this.grvImport.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvImport.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvImport.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvImport.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvImport.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvImport.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvImport.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvImport.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvImport.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvImport.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvImport.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvImport.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvImport.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvImport.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvImport.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvImport.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvImport.Appearance.OddRow.Options.UseFont = true;
            this.grvImport.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvImport.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvImport.Appearance.Row.Options.UseBackColor = true;
            this.grvImport.Appearance.Row.Options.UseFont = true;
            this.grvImport.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvImport.Appearance.SelectedRow.Options.UseFont = true;
            this.grvImport.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvImport.Appearance.VertLine.Options.UseBackColor = true;
            this.grvImport.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvImport.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBaStrasseID,
            this.colStrassenName,
            this.colHausnummer,
            this.colSuffix,
            this.colQT,
            this.colQTKiSS,
            this.colPLZ,
            this.colKreis,
            this.colQuartier,
            this.colZone,
            this.colStatistischeZone});
            this.grvImport.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvImport.GridControl = this.grdImport;
            this.grvImport.Name = "grvImport";
            this.grvImport.OptionsBehavior.Editable = false;
            this.grvImport.OptionsCustomization.AllowFilter = false;
            this.grvImport.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvImport.OptionsNavigation.AutoFocusNewRow = true;
            this.grvImport.OptionsNavigation.UseTabKey = false;
            this.grvImport.OptionsView.ColumnAutoWidth = false;
            this.grvImport.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvImport.OptionsView.ShowGroupPanel = false;
            this.grvImport.OptionsView.ShowIndicator = false;
            // 
            // colBaStrasseID
            // 
            this.colBaStrasseID.Caption = "ID (Strasse)";
            this.colBaStrasseID.FieldName = "BaStrasseID";
            this.colBaStrasseID.Name = "colBaStrasseID";
            this.colBaStrasseID.Visible = true;
            this.colBaStrasseID.VisibleIndex = 0;
            this.colBaStrasseID.Width = 74;
            // 
            // colStrassenName
            // 
            this.colStrassenName.Caption = "Strasse";
            this.colStrassenName.FieldName = "StrassenName";
            this.colStrassenName.Name = "colStrassenName";
            this.colStrassenName.Visible = true;
            this.colStrassenName.VisibleIndex = 1;
            this.colStrassenName.Width = 138;
            // 
            // colHausnummer
            // 
            this.colHausnummer.Caption = "Hausnr.";
            this.colHausnummer.FieldName = "Hausnummer";
            this.colHausnummer.Name = "colHausnummer";
            this.colHausnummer.Visible = true;
            this.colHausnummer.VisibleIndex = 2;
            this.colHausnummer.Width = 54;
            // 
            // colSuffix
            // 
            this.colSuffix.Caption = "Zus.";
            this.colSuffix.FieldName = "Suffix";
            this.colSuffix.Name = "colSuffix";
            this.colSuffix.ToolTip = "Zusatz";
            this.colSuffix.Visible = true;
            this.colSuffix.VisibleIndex = 3;
            this.colSuffix.Width = 37;
            // 
            // colQT
            // 
            this.colQT.Caption = "QT (import)";
            this.colQT.FieldName = "QuartierTeam";
            this.colQT.Name = "colQT";
            this.colQT.Visible = true;
            this.colQT.VisibleIndex = 4;
            this.colQT.Width = 110;
            // 
            // colQTKiSS
            // 
            this.colQTKiSS.Caption = "QT (KiSS)";
            this.colQTKiSS.FieldName = "OrgUnitID_QT";
            this.colQTKiSS.Name = "colQTKiSS";
            this.colQTKiSS.Visible = true;
            this.colQTKiSS.VisibleIndex = 5;
            this.colQTKiSS.Width = 120;
            // 
            // colPLZ
            // 
            this.colPLZ.Caption = "PLZ";
            this.colPLZ.FieldName = "PLZ";
            this.colPLZ.Name = "colPLZ";
            this.colPLZ.Visible = true;
            this.colPLZ.VisibleIndex = 6;
            this.colPLZ.Width = 40;
            // 
            // colKreis
            // 
            this.colKreis.Caption = "Kreis";
            this.colKreis.FieldName = "Kreis";
            this.colKreis.Name = "colKreis";
            this.colKreis.Visible = true;
            this.colKreis.VisibleIndex = 7;
            this.colKreis.Width = 41;
            // 
            // colQuartier
            // 
            this.colQuartier.Caption = "Quartier";
            this.colQuartier.FieldName = "Quartier";
            this.colQuartier.Name = "colQuartier";
            this.colQuartier.Visible = true;
            this.colQuartier.VisibleIndex = 8;
            this.colQuartier.Width = 57;
            // 
            // colZone
            // 
            this.colZone.Caption = "Zone";
            this.colZone.FieldName = "Zone";
            this.colZone.Name = "colZone";
            this.colZone.Visible = true;
            this.colZone.VisibleIndex = 9;
            this.colZone.Width = 40;
            // 
            // colStatistischeZone
            // 
            this.colStatistischeZone.Caption = "Stat. Zone";
            this.colStatistischeZone.FieldName = "StatistischeZone";
            this.colStatistischeZone.Name = "colStatistischeZone";
            this.colStatistischeZone.ToolTip = "Statistische Zone";
            this.colStatistischeZone.Visible = true;
            this.colStatistischeZone.VisibleIndex = 10;
            this.colStatistischeZone.Width = 67;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.ValueChecked = 1;
            this.repositoryItemCheckEdit1.ValueUnchecked = 0;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.repositoryItemLookUpEdit1.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.repositoryItemLookUpEdit1.AppearanceDropDown.Options.UseBackColor = true;
            this.repositoryItemLookUpEdit1.AppearanceDropDown.Options.UseFont = true;
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "";
            this.repositoryItemLookUpEdit1.ShowFooter = false;
            this.repositoryItemLookUpEdit1.ShowHeader = false;
            // 
            // FrmBaStrassenverzeichnis
            // 
            this.ClientSize = new System.Drawing.Size(949, 474);
            this.Controls.Add(this.tabMain);
            this.Name = "FrmBaStrassenverzeichnis";
            this.tabMain.ResumeLayout(false);
            this.tbpUpdate.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHausNeu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvHausNeu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStrassenNeu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStrasseNeu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDifferenzenHaus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDifferenzenHaus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDifferenzenStrasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDifferenzenStrasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDiffStrasse)).EndInit();
            this.tbpUebersicht.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblImportedBaHaus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaStrasseEingelesen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaStrasseEingelesen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaHausEingelesen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaHausEingelesen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissButton btnUpdate;
        private KiSS4.Gui.KissTabControlEx tabMain;
        private SharpLibrary.WinControls.TabPageEx tbpUpdate;
        private SharpLibrary.WinControls.TabPageEx tbpUebersicht;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private KiSS4.Gui.KissGrid grdImport;
        private DevExpress.XtraGrid.Views.Grid.GridView grvImport;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colBaStrasseID;
        private DevExpress.XtraGrid.Columns.GridColumn colStrassenName;
        private DevExpress.XtraGrid.Columns.GridColumn colHausnummer;
        private DevExpress.XtraGrid.Columns.GridColumn colSuffix;
        private DevExpress.XtraGrid.Columns.GridColumn colKreis;
        private DevExpress.XtraGrid.Columns.GridColumn colQuartier;
        private DevExpress.XtraGrid.Columns.GridColumn colZone;
        private DevExpress.XtraGrid.Columns.GridColumn colStatistischeZone;
        private DevExpress.XtraGrid.Columns.GridColumn colQT;
        private DevExpress.XtraGrid.Columns.GridColumn colQTKiSS;
        private DevExpress.XtraGrid.Columns.GridColumn colPLZ;
        private KiSS4.Gui.KissGrid grdBaStrasseEingelesen;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBaStrasseEingelesen;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private KiSS4.Gui.KissGrid grdBaHausEingelesen;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBaHausEingelesen;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasse_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasse_Name;
        private DevExpress.XtraGrid.Columns.GridColumn colHaus_Hausnummer;
        private DevExpress.XtraGrid.Columns.GridColumn colHaus_Suffix;
        private DevExpress.XtraGrid.Columns.GridColumn colHaus_QT_Import;
        private DevExpress.XtraGrid.Columns.GridColumn colHaus_Quartier;
        private DevExpress.XtraGrid.Columns.GridColumn colHaus_PLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colHaus_Kreis;
        private DevExpress.XtraGrid.Columns.GridColumn colHaus_Zone;
        private DevExpress.XtraGrid.Columns.GridColumn colHaus_StatistischeZone;
        private DevExpress.XtraGrid.Columns.GridColumn colHaus_QT_Kiss;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private KiSS4.Gui.KissGrid grdDifferenzenHaus;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDifferenzenHaus;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn colDiffHaus_QT_bisher;
        private DevExpress.XtraGrid.Columns.GridColumn colDiffHaus_QT_neu;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit5;
        private KiSS4.Gui.KissGrid grdDifferenzenStrasse;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDifferenzenStrasse;
        private DevExpress.XtraGrid.Columns.GridColumn colDiffStr_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colDiffStr_NameBisher;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit4;
        private DevExpress.XtraGrid.Columns.GridColumn colDiffStr_NameNeu;
        private KiSS4.Gui.KissGrid grdHausNeu;
        private DevExpress.XtraGrid.Views.Grid.GridView grvHausNeu;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn colHausNeu_QT;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit7;
        private KiSS4.Gui.KissGrid grdStrassenNeu;
        private DevExpress.XtraGrid.Views.Grid.GridView grvStrasseNeu;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasseNeuID;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasseNeuName;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit6;
        private DevExpress.XtraGrid.Columns.GridColumn colHausDiff_Strasse;
        private DevExpress.XtraGrid.Columns.GridColumn colHausNeu_Strasse;
        private KiSS4.Gui.KissButton btnAccept;
        private KiSS4.Gui.KissLabel lblDiffStrasse;
        private KiSS4.Gui.KissLabel kissLabel3;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel lblImportedBaHaus;
        private KiSS4.Gui.KissLabel kissLabel4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private KiSS4.Gui.KissLabel kissLabel5;
    }
}
