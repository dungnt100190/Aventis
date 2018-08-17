namespace KiSS4.Query
{
    public class CtlQueryStatShFallzahlen : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colAlter;
        private DevExpress.XtraGrid.Columns.GridColumn colAlterTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colAnzPersHaushalt;
        private DevExpress.XtraGrid.Columns.GridColumn colAnzPersUnterst;
        private DevExpress.XtraGrid.Columns.GridColumn colAnzahlFP;
        private DevExpress.XtraGrid.Columns.GridColumn colAnzahlUE;
        private DevExpress.XtraGrid.Columns.GridColumn colArchiviertAm;
        private DevExpress.XtraGrid.Columns.GridColumn colFall;
        private DevExpress.XtraGrid.Columns.GridColumn colFallNr;
        private DevExpress.XtraGrid.Columns.GridColumn colFalltrger;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGeffnet;
        private DevExpress.XtraGrid.Columns.GridColumn colGeschlecht;
        private DevExpress.XtraGrid.Columns.GridColumn colGeschlossen;
        private DevExpress.XtraGrid.Columns.GridColumn colHeimatort;
        private DevExpress.XtraGrid.Columns.GridColumn colHeimatortKanton;
        private DevExpress.XtraGrid.Columns.GridColumn colKanton;
        private DevExpress.XtraGrid.Columns.GridColumn colModul;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalitt;
        private DevExpress.XtraGrid.Columns.GridColumn colOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colPLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colSARKrzel;
        private DevExpress.XtraGrid.Columns.GridColumn colSARName;
        private DevExpress.XtraGrid.Columns.GridColumn colSARSektion;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasse;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasseNr;
        private DevExpress.XtraGrid.Columns.GridColumn colZivilstand;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissCheckEdit edt6MontateRegel;
        private KiSS4.Gui.KissCheckEdit edtFT;
        private KiSS4.Gui.KissTextEdit edtJahr;
        private KiSS4.Gui.KissGrid grdListe2;
        private KiSS4.Gui.KissGrid grdListe3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView grvListe2;
        private KiSS4.Gui.KissLabel lblAuswertungsjahr;
        private SharpLibrary.WinControls.TabPageEx tpgListe2;
        private SharpLibrary.WinControls.TabPageEx tpgListe3;

        #endregion

        #region Constructors

        public CtlQueryStatShFallzahlen()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryStatShFallzahlen));
            this.lblAuswertungsjahr = new KiSS4.Gui.KissLabel();
            this.edtJahr = new KiSS4.Gui.KissTextEdit();
            this.edtFT = new KiSS4.Gui.KissCheckEdit();
            this.edt6MontateRegel = new KiSS4.Gui.KissCheckEdit();
            this.tpgListe2 = new SharpLibrary.WinControls.TabPageEx();
            this.grdListe2 = new KiSS4.Gui.KissGrid();
            this.grvListe2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tpgListe3 = new SharpLibrary.WinControls.TabPageEx();
            this.grdListe3 = new KiSS4.Gui.KissGrid();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAlter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlterTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnzahlFP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnzahlUE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnzPersHaushalt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnzPersUnterst = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArchiviertAm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFall = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFallNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFalltrger = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeffnet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeschlecht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeschlossen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHeimatort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHeimatortKanton = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKanton = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModul = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationalitt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSARKrzel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSARName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSARSektion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasseNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZivilstand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuswertungsjahr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJahr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt6MontateRegel.Properties)).BeginInit();
            this.tpgListe2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdListe2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvListe2)).BeginInit();
            this.tpgListe3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdListe3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            this.qryQuery.AfterFill += new System.EventHandler(this.qryQuery_AfterFill);
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
            this.grdQuery1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // xDocument
            // 
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
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
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Controls.Add(this.tpgListe3);
            this.tabControlSearch.Controls.Add(this.tpgListe2);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgListe2,
            this.tpgListe3});
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgSuchen, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe2, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe3, 0);
            // 
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edt6MontateRegel);
            this.tpgSuchen.Controls.Add(this.edtFT);
            this.tpgSuchen.Controls.Add(this.edtJahr);
            this.tpgSuchen.Controls.Add(this.lblAuswertungsjahr);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblAuswertungsjahr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtJahr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFT, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edt6MontateRegel, 0);
            // 
            // lblAuswertungsjahr
            // 
            this.lblAuswertungsjahr.Location = new System.Drawing.Point(10, 40);
            this.lblAuswertungsjahr.Name = "lblAuswertungsjahr";
            this.lblAuswertungsjahr.Size = new System.Drawing.Size(130, 24);
            this.lblAuswertungsjahr.TabIndex = 1;
            this.lblAuswertungsjahr.Text = "Auswertungsjahr";
            this.lblAuswertungsjahr.UseCompatibleTextRendering = true;
            // 
            // edtJahr
            // 
            this.edtJahr.EditValue = "";
            this.edtJahr.Location = new System.Drawing.Point(150, 40);
            this.edtJahr.Name = "edtJahr";
            this.edtJahr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtJahr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtJahr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtJahr.Properties.Appearance.Options.UseBackColor = true;
            this.edtJahr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtJahr.Properties.Appearance.Options.UseFont = true;
            this.edtJahr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtJahr.Size = new System.Drawing.Size(60, 24);
            this.edtJahr.TabIndex = 20;
            // 
            // edtFT
            // 
            this.edtFT.EditValue = false;
            this.edtFT.Location = new System.Drawing.Point(150, 70);
            this.edtFT.Name = "edtFT";
            this.edtFT.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtFT.Properties.Appearance.Options.UseBackColor = true;
            this.edtFT.Properties.Caption = "nur Falltraeger";
            this.edtFT.Size = new System.Drawing.Size(200, 19);
            this.edtFT.TabIndex = 21;
            // 
            // edt6MontateRegel
            // 
            this.edt6MontateRegel.EditValue = false;
            this.edt6MontateRegel.Location = new System.Drawing.Point(150, 100);
            this.edt6MontateRegel.Name = "edt6MontateRegel";
            this.edt6MontateRegel.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edt6MontateRegel.Properties.Appearance.Options.UseBackColor = true;
            this.edt6MontateRegel.Properties.Caption = "6 Monate Regel anwenden: Fälle zusammenlegen mit weniger als 6 Monate Unterbruch";
            this.edt6MontateRegel.Size = new System.Drawing.Size(540, 19);
            this.edt6MontateRegel.TabIndex = 22;
            // 
            // tpgListe2
            // 
            this.tpgListe2.Controls.Add(this.grdListe2);
            this.tpgListe2.Location = new System.Drawing.Point(6, 6);
            this.tpgListe2.Name = "tpgListe2";
            this.tpgListe2.Size = new System.Drawing.Size(772, 424);
            this.tpgListe2.TabIndex = 1;
            this.tpgListe2.Title = "Total 1";
            // 
            // grdListe2
            // 
            this.grdListe2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdListe2.DataSource = this.qryQuery;
            // 
            // 
            // 
            this.grdListe2.EmbeddedNavigator.Name = "";
            this.grdListe2.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdListe2.Location = new System.Drawing.Point(3, 16);
            this.grdListe2.MainView = this.grvListe2;
            this.grdListe2.Name = "grdListe2";
            this.grdListe2.Size = new System.Drawing.Size(766, 392);
            this.grdListe2.TabIndex = 9;
            this.grdListe2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvListe2});
            // 
            // grvListe2
            // 
            this.grvListe2.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvListe2.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2.Appearance.Empty.Options.UseBackColor = true;
            this.grvListe2.Appearance.Empty.Options.UseFont = true;
            this.grvListe2.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2.Appearance.EvenRow.Options.UseFont = true;
            this.grvListe2.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvListe2.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvListe2.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvListe2.Appearance.FocusedCell.Options.UseFont = true;
            this.grvListe2.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvListe2.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvListe2.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvListe2.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvListe2.Appearance.FocusedRow.Options.UseFont = true;
            this.grvListe2.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvListe2.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvListe2.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvListe2.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvListe2.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvListe2.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvListe2.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvListe2.Appearance.GroupRow.Options.UseFont = true;
            this.grvListe2.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvListe2.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvListe2.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvListe2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvListe2.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvListe2.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvListe2.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvListe2.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvListe2.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvListe2.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvListe2.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvListe2.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvListe2.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvListe2.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvListe2.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2.Appearance.OddRow.Options.UseFont = true;
            this.grvListe2.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvListe2.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2.Appearance.Row.Options.UseBackColor = true;
            this.grvListe2.Appearance.Row.Options.UseFont = true;
            this.grvListe2.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2.Appearance.SelectedRow.Options.UseFont = true;
            this.grvListe2.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvListe2.Appearance.VertLine.Options.UseBackColor = true;
            this.grvListe2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvListe2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvListe2.GridControl = this.grdListe2;
            this.grvListe2.Name = "grvListe2";
            this.grvListe2.OptionsBehavior.Editable = false;
            this.grvListe2.OptionsCustomization.AllowFilter = false;
            this.grvListe2.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvListe2.OptionsNavigation.AutoFocusNewRow = true;
            this.grvListe2.OptionsNavigation.UseTabKey = false;
            this.grvListe2.OptionsView.ColumnAutoWidth = false;
            this.grvListe2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvListe2.OptionsView.ShowGroupPanel = false;
            this.grvListe2.OptionsView.ShowIndicator = false;
            // 
            // tpgListe3
            // 
            this.tpgListe3.Controls.Add(this.grdListe3);
            this.tpgListe3.Location = new System.Drawing.Point(6, 6);
            this.tpgListe3.Name = "tpgListe3";
            this.tpgListe3.Size = new System.Drawing.Size(772, 424);
            this.tpgListe3.TabIndex = 2;
            this.tpgListe3.Title = "Total 2";
            // 
            // grdListe3
            // 
            this.grdListe3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdListe3.DataSource = this.qryQuery;
            // 
            // 
            // 
            this.grdListe3.EmbeddedNavigator.Name = "";
            this.grdListe3.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdListe3.Location = new System.Drawing.Point(3, 16);
            this.grdListe3.MainView = this.gridView2;
            this.grdListe3.Name = "grdListe3";
            this.grdListe3.Size = new System.Drawing.Size(766, 392);
            this.grdListe3.TabIndex = 10;
            this.grdListe3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView2.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.Empty.Options.UseBackColor = true;
            this.gridView2.Appearance.Empty.Options.UseFont = true;
            this.gridView2.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.EvenRow.Options.UseFont = true;
            this.gridView2.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView2.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView2.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView2.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView2.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView2.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView2.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView2.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView2.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView2.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView2.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView2.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView2.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupRow.Options.UseFont = true;
            this.gridView2.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView2.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView2.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView2.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView2.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView2.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView2.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView2.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView2.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView2.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView2.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView2.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.OddRow.Options.UseFont = true;
            this.gridView2.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.Row.Options.UseBackColor = true;
            this.gridView2.Appearance.Row.Options.UseFont = true;
            this.gridView2.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView2.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView2.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView2.GridControl = this.grdListe3;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsCustomization.AllowFilter = false;
            this.gridView2.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView2.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView2.OptionsNavigation.UseTabKey = false;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowIndicator = false;
            // 
            // colAlter
            // 
            this.colAlter.Name = "colAlter";
            // 
            // colAlterTyp
            // 
            this.colAlterTyp.Name = "colAlterTyp";
            // 
            // colAnzahlFP
            // 
            this.colAnzahlFP.Name = "colAnzahlFP";
            // 
            // colAnzahlUE
            // 
            this.colAnzahlUE.Name = "colAnzahlUE";
            // 
            // colAnzPersHaushalt
            // 
            this.colAnzPersHaushalt.Name = "colAnzPersHaushalt";
            // 
            // colAnzPersUnterst
            // 
            this.colAnzPersUnterst.Name = "colAnzPersUnterst";
            // 
            // colArchiviertAm
            // 
            this.colArchiviertAm.Name = "colArchiviertAm";
            // 
            // colFall
            // 
            this.colFall.Name = "colFall";
            // 
            // colFallNr
            // 
            this.colFallNr.Name = "colFallNr";
            // 
            // colFalltrger
            // 
            this.colFalltrger.Name = "colFalltrger";
            // 
            // colGeburtsdatum
            // 
            this.colGeburtsdatum.Name = "colGeburtsdatum";
            // 
            // colGeffnet
            // 
            this.colGeffnet.Name = "colGeffnet";
            // 
            // colGeschlecht
            // 
            this.colGeschlecht.Name = "colGeschlecht";
            // 
            // colGeschlossen
            // 
            this.colGeschlossen.Name = "colGeschlossen";
            // 
            // colHeimatort
            // 
            this.colHeimatort.Name = "colHeimatort";
            // 
            // colHeimatortKanton
            // 
            this.colHeimatortKanton.Name = "colHeimatortKanton";
            // 
            // colKanton
            // 
            this.colKanton.Name = "colKanton";
            // 
            // colModul
            // 
            this.colModul.Name = "colModul";
            // 
            // colNationalitt
            // 
            this.colNationalitt.Name = "colNationalitt";
            // 
            // colOrt
            // 
            this.colOrt.Name = "colOrt";
            // 
            // colPerson
            // 
            this.colPerson.Name = "colPerson";
            // 
            // colPLZ
            // 
            this.colPLZ.Name = "colPLZ";
            // 
            // colSARKrzel
            // 
            this.colSARKrzel.Name = "colSARKrzel";
            // 
            // colSARName
            // 
            this.colSARName.Name = "colSARName";
            // 
            // colSARSektion
            // 
            this.colSARSektion.Name = "colSARSektion";
            // 
            // colStrasse
            // 
            this.colStrasse.Name = "colStrasse";
            // 
            // colStrasseNr
            // 
            this.colStrasseNr.Name = "colStrasseNr";
            // 
            // colZivilstand
            // 
            this.colZivilstand.Name = "colZivilstand";
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.Empty.Options.UseFont = true;
            this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.EvenRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.OddRow.Options.UseFont = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.grdQuery1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // CtlQueryStatShFallzahlen
            // 
            this.Name = "CtlQueryStatShFallzahlen";
            this.Load += new System.EventHandler(this.CtlQueryStatShFallzahlen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblAuswertungsjahr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJahr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt6MontateRegel.Properties)).EndInit();
            this.tpgListe2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdListe2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvListe2)).EndInit();
            this.tpgListe3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdListe3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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

        #region Private Methods

        private void CtlQueryStatShFallzahlen_Load(object sender, System.EventArgs e)
        {
            tpgListe.Title = "Detail";
        }

        private void qryQuery_AfterFill(object sender, System.EventArgs e)
        {
            this.grdListe2.DataSource = qryQuery.DataSet.Tables[1];
            this.grdListe3.DataSource = qryQuery.DataSet.Tables[2];
        }

        #endregion
    }
}