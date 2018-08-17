namespace KiSS4.Administration
{
    partial class CtlArchiveManagement
    {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tabArchiv = new KiSS4.Gui.KissTabControlEx();
            this.tabListe = new SharpLibrary.WinControls.TabPageEx();
            this.ctlGotoFall = new KiSS4.Common.CtlGotoFall();
            this.qryFaLeistung = new KiSS4.DB.SqlQuery(this.components);
            this.edtVersNr = new KiSS4.Gui.KissTextEdit();
            this.lblVersNr = new KiSS4.Gui.KissLabel();
            this.edtNNummer = new KiSS4.Gui.KissTextEdit();
            this.edtAHVNummer = new KiSS4.Gui.KissTextEdit();
            this.lblNNummer = new KiSS4.Gui.KissLabel();
            this.lblAHVNummer = new KiSS4.Gui.KissLabel();
            this.lblRowCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnArchivWechsel = new KiSS4.Gui.KissButton();
            this.editArchivNr = new KiSS4.Gui.KissTextEdit();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.editSAR = new KiSS4.Gui.KissButtonEdit();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.editArchivStandort = new KiSS4.Gui.KissLookUpEdit();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.btnZurueckholen = new KiSS4.Gui.KissButton();
            this.btnArchivieren = new KiSS4.Gui.KissButton();
            this.grdHistory = new KiSS4.Gui.KissGrid();
            this.qryHistory = new KiSS4.DB.SqlQuery(this.components);
            this.grvHistory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStandort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArchivNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCheckIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCheckInUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCheckOut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCheckOutUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabControl1 = new KiSS4.Gui.KissTabControlEx();
            this.tabPageListe = new SharpLibrary.WinControls.TabPageEx();
            this.grdFaLeistung = new KiSS4.Gui.KissGrid();
            this.grvFaLeistung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colArchiviert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStandort2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArchivNr2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModul = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNEWOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabPageSuchen = new SharpLibrary.WinControls.TabPageEx();
            this.panel1 = new System.Windows.Forms.Panel();
            this.editVersNrX = new KiSS4.Gui.KissTextEdit();
            this.lblVersNrX = new KiSS4.Gui.KissLabel();
            this.editNNummerX = new KiSS4.Gui.KissTextEdit();
            this.kissLabel15 = new KiSS4.Gui.KissLabel();
            this.editAHVNr = new KiSS4.Gui.KissTextEdit();
            this.kissLabel14 = new KiSS4.Gui.KissLabel();
            this.editStatusX = new KiSS4.Gui.KissLookUpEdit();
            this.kissLabel13 = new KiSS4.Gui.KissLabel();
            this.editArchivNrX = new KiSS4.Gui.KissTextEdit();
            this.kissLabel8 = new KiSS4.Gui.KissLabel();
            this.editSARX = new KiSS4.Gui.KissButtonEdit();
            this.editStandortX = new KiSS4.Gui.KissLookUpEdit();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.kissSearchTitel1 = new KiSS4.Gui.KissSearchTitel();
            this.editModulX = new KiSS4.Gui.KissLookUpEdit();
            this.kissLabel7 = new KiSS4.Gui.KissLabel();
            this.kissLabel6 = new KiSS4.Gui.KissLabel();
            this.editPersonX = new KiSS4.Gui.KissTextEdit();
            this.label25 = new KiSS4.Gui.KissLabel();
            this.btnSearch = new KiSS4.Gui.KissButton();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabSuchen = new SharpLibrary.WinControls.TabPageEx();
            this.lblFilterKandidaten = new KiSS4.Gui.KissLabel();
            this.edtFilterKandidaten = new KiSS4.Gui.KissTextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.edtSortKey = new KiSS4.Gui.KissCalcEdit();
            this.qryArchive = new KiSS4.DB.SqlQuery(this.components);
            this.lblSortKey = new KiSS4.Gui.KissLabel();
            this.edtAddress = new KiSS4.Gui.KissMemoEdit();
            this.lblAddress = new KiSS4.Gui.KissLabel();
            this.gridVerfuegbar = new KiSS4.Gui.KissGrid();
            this.qryKandidaten = new KiSS4.DB.SqlQuery(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUser2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserID2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridZugeteilt = new KiSS4.Gui.KissGrid();
            this.qryZugeteilt = new KiSS4.DB.SqlQuery(this.components);
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserI1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtRemark = new KiSS4.Gui.KissMemoEdit();
            this.btnAddAll = new KiSS4.Gui.KissButton();
            this.btnRemoveAll = new KiSS4.Gui.KissButton();
            this.btnAdd = new KiSS4.Gui.KissButton();
            this.btnRemove = new KiSS4.Gui.KissButton();
            this.edtName = new KiSS4.Gui.KissTextEdit();
            this.lblRemark = new KiSS4.Gui.KissLabel();
            this.lblName = new KiSS4.Gui.KissLabel();
            this.grdArchiv = new KiSS4.Gui.KissGrid();
            this.grvArchiv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSortKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabArchiv.SuspendLayout();
            this.tabListe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLeistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNNummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAHVNummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNNummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAHVNummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editArchivNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editSAR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editArchivStandort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editArchivStandort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvHistory)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageListe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFaLeistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFaLeistung)).BeginInit();
            this.tabPageSuchen.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editVersNrX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersNrX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editNNummerX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAHVNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editStatusX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editStatusX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editArchivNrX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editSARX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editStandortX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editStandortX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editModulX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editModulX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPersonX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            this.tabSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilterKandidaten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterKandidaten.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSortKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryArchive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSortKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKandidaten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRemark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdArchiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvArchiv)).BeginInit();
            this.SuspendLayout();
            // 
            // tabArchiv
            // 
            this.tabArchiv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabArchiv.Controls.Add(this.tabListe);
            this.tabArchiv.Controls.Add(this.tabSuchen);
            this.tabArchiv.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabArchiv.Location = new System.Drawing.Point(5, 5);
            this.tabArchiv.Name = "tabArchiv";
            this.tabArchiv.ShowFixedWidthTooltip = true;
            this.tabArchiv.Size = new System.Drawing.Size(966, 574);
            this.tabArchiv.TabIndex = 64;
            this.tabArchiv.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tabListe,
            this.tabSuchen});
            this.tabArchiv.TabsLineColor = System.Drawing.Color.Black;
            this.tabArchiv.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabArchiv.TabStop = false;
            this.tabArchiv.Text = "kissTabControlEx1";
            // 
            // tabListe
            // 
            this.tabListe.Controls.Add(this.ctlGotoFall);
            this.tabListe.Controls.Add(this.edtVersNr);
            this.tabListe.Controls.Add(this.lblVersNr);
            this.tabListe.Controls.Add(this.edtNNummer);
            this.tabListe.Controls.Add(this.edtAHVNummer);
            this.tabListe.Controls.Add(this.lblNNummer);
            this.tabListe.Controls.Add(this.lblAHVNummer);
            this.tabListe.Controls.Add(this.lblRowCount);
            this.tabListe.Controls.Add(this.label2);
            this.tabListe.Controls.Add(this.btnArchivWechsel);
            this.tabListe.Controls.Add(this.editArchivNr);
            this.tabListe.Controls.Add(this.kissLabel5);
            this.tabListe.Controls.Add(this.editSAR);
            this.tabListe.Controls.Add(this.kissLabel3);
            this.tabListe.Controls.Add(this.editArchivStandort);
            this.tabListe.Controls.Add(this.kissLabel2);
            this.tabListe.Controls.Add(this.btnZurueckholen);
            this.tabListe.Controls.Add(this.btnArchivieren);
            this.tabListe.Controls.Add(this.grdHistory);
            this.tabListe.Controls.Add(this.tabControl1);
            this.tabListe.Controls.Add(this.kissLabel1);
            this.tabListe.Controls.Add(this.lblTitle);
            this.tabListe.Location = new System.Drawing.Point(6, 6);
            this.tabListe.Name = "tabListe";
            this.tabListe.Size = new System.Drawing.Size(954, 536);
            this.tabListe.TabIndex = 0;
            this.tabListe.Title = "Archivieren";
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctlGotoFall.AutoSize = true;
            this.ctlGotoFall.DataMember = "BaPersonID";
            this.ctlGotoFall.DataSource = this.qryFaLeistung;
            this.ctlGotoFall.Location = new System.Drawing.Point(106, 264);
            this.ctlGotoFall.Name = "ctlGotoFall";
            this.ctlGotoFall.Size = new System.Drawing.Size(158, 27);
            this.ctlGotoFall.TabIndex = 56;
            this.ctlGotoFall.Visible = false;
            // 
            // qryFaLeistung
            // 
            this.qryFaLeistung.CanUpdate = true;
            this.qryFaLeistung.HostControl = this;
            this.qryFaLeistung.IsIdentityInsert = false;
            this.qryFaLeistung.TableName = "FaLeistung";
            this.qryFaLeistung.PositionChanged += new System.EventHandler(this.qryFaLeistung_PositionChanged);
            // 
            // edtVersNr
            // 
            this.edtVersNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtVersNr.DataMember = "Versichertennummer";
            this.edtVersNr.DataSource = this.qryFaLeistung;
            this.edtVersNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVersNr.Location = new System.Drawing.Point(800, 362);
            this.edtVersNr.Name = "edtVersNr";
            this.edtVersNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVersNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVersNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVersNr.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtVersNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtVersNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVersNr.Properties.Appearance.Options.UseFont = true;
            this.edtVersNr.Properties.Appearance.Options.UseForeColor = true;
            this.edtVersNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVersNr.Properties.ReadOnly = true;
            this.edtVersNr.Size = new System.Drawing.Size(137, 24);
            this.edtVersNr.TabIndex = 55;
            // 
            // lblVersNr
            // 
            this.lblVersNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVersNr.Location = new System.Drawing.Point(742, 362);
            this.lblVersNr.Name = "lblVersNr";
            this.lblVersNr.Size = new System.Drawing.Size(84, 24);
            this.lblVersNr.TabIndex = 54;
            this.lblVersNr.Text = "Vers.-Nr.";
            // 
            // edtNNummer
            // 
            this.edtNNummer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtNNummer.DataMember = "NNummer";
            this.edtNNummer.DataSource = this.qryFaLeistung;
            this.edtNNummer.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtNNummer.Location = new System.Drawing.Point(800, 328);
            this.edtNNummer.Name = "edtNNummer";
            this.edtNNummer.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtNNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNNummer.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtNNummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtNNummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNNummer.Properties.Appearance.Options.UseFont = true;
            this.edtNNummer.Properties.Appearance.Options.UseForeColor = true;
            this.edtNNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNNummer.Properties.ReadOnly = true;
            this.edtNNummer.Size = new System.Drawing.Size(137, 24);
            this.edtNNummer.TabIndex = 53;
            // 
            // edtAHVNummer
            // 
            this.edtAHVNummer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAHVNummer.DataMember = "AHVNummer";
            this.edtAHVNummer.DataSource = this.qryFaLeistung;
            this.edtAHVNummer.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAHVNummer.Location = new System.Drawing.Point(800, 298);
            this.edtAHVNummer.Name = "edtAHVNummer";
            this.edtAHVNummer.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAHVNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAHVNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAHVNummer.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtAHVNummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtAHVNummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAHVNummer.Properties.Appearance.Options.UseFont = true;
            this.edtAHVNummer.Properties.Appearance.Options.UseForeColor = true;
            this.edtAHVNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAHVNummer.Properties.ReadOnly = true;
            this.edtAHVNummer.Size = new System.Drawing.Size(137, 24);
            this.edtAHVNummer.TabIndex = 52;
            // 
            // lblNNummer
            // 
            this.lblNNummer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNNummer.Location = new System.Drawing.Point(742, 328);
            this.lblNNummer.Name = "lblNNummer";
            this.lblNNummer.Size = new System.Drawing.Size(84, 24);
            this.lblNNummer.TabIndex = 49;
            this.lblNNummer.Text = "N-Nummer";
            // 
            // lblAHVNummer
            // 
            this.lblAHVNummer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAHVNummer.Location = new System.Drawing.Point(742, 298);
            this.lblAHVNummer.Name = "lblAHVNummer";
            this.lblAHVNummer.Size = new System.Drawing.Size(84, 24);
            this.lblAHVNummer.TabIndex = 48;
            this.lblAHVNummer.Text = "AHV-Nr.";
            // 
            // lblRowCount
            // 
            this.lblRowCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRowCount.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblRowCount.Location = new System.Drawing.Point(907, 267);
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Size = new System.Drawing.Size(44, 16);
            this.lblRowCount.TabIndex = 47;
            this.lblRowCount.Text = "0";
            this.lblRowCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label2.Location = new System.Drawing.Point(804, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 14);
            this.label2.TabIndex = 46;
            this.label2.Text = "Anzahl Datensätze:";
            // 
            // btnArchivWechsel
            // 
            this.btnArchivWechsel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnArchivWechsel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnArchivWechsel.Enabled = false;
            this.btnArchivWechsel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArchivWechsel.Location = new System.Drawing.Point(201, 362);
            this.btnArchivWechsel.Name = "btnArchivWechsel";
            this.btnArchivWechsel.Size = new System.Drawing.Size(96, 24);
            this.btnArchivWechsel.TabIndex = 39;
            this.btnArchivWechsel.Text = "Archivwechsel";
            this.btnArchivWechsel.UseVisualStyleBackColor = false;
            this.btnArchivWechsel.Click += new System.EventHandler(this.btnArchivWechsel_Click);
            // 
            // editArchivNr
            // 
            this.editArchivNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editArchivNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editArchivNr.EditValue = "";
            this.editArchivNr.Location = new System.Drawing.Point(95, 298);
            this.editArchivNr.Name = "editArchivNr";
            this.editArchivNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editArchivNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editArchivNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editArchivNr.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.editArchivNr.Properties.Appearance.Options.UseBackColor = true;
            this.editArchivNr.Properties.Appearance.Options.UseBorderColor = true;
            this.editArchivNr.Properties.Appearance.Options.UseFont = true;
            this.editArchivNr.Properties.Appearance.Options.UseForeColor = true;
            this.editArchivNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editArchivNr.Properties.ReadOnly = true;
            this.editArchivNr.Size = new System.Drawing.Size(239, 24);
            this.editArchivNr.TabIndex = 36;
            // 
            // kissLabel5
            // 
            this.kissLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel5.Location = new System.Drawing.Point(7, 298);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(84, 24);
            this.kissLabel5.TabIndex = 45;
            this.kissLabel5.Text = "Neue Archiv-Nr.";
            // 
            // editSAR
            // 
            this.editSAR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editSAR.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editSAR.EditValue = "";
            this.editSAR.Location = new System.Drawing.Point(436, 298);
            this.editSAR.Name = "editSAR";
            this.editSAR.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editSAR.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editSAR.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editSAR.Properties.Appearance.Options.UseBackColor = true;
            this.editSAR.Properties.Appearance.Options.UseBorderColor = true;
            this.editSAR.Properties.Appearance.Options.UseFont = true;
            this.editSAR.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.editSAR.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.editSAR.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editSAR.Properties.ReadOnly = true;
            this.editSAR.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.editSAR.Size = new System.Drawing.Size(239, 24);
            this.editSAR.TabIndex = 40;
            this.editSAR.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.editSAR_UserModifiedFld);
            // 
            // kissLabel3
            // 
            this.kissLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel3.Location = new System.Drawing.Point(367, 298);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(60, 24);
            this.kissLabel3.TabIndex = 44;
            this.kissLabel3.Text = "Neuer SAR";
            // 
            // editArchivStandort
            // 
            this.editArchivStandort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editArchivStandort.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editArchivStandort.Location = new System.Drawing.Point(95, 328);
            this.editArchivStandort.Name = "editArchivStandort";
            this.editArchivStandort.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editArchivStandort.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editArchivStandort.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editArchivStandort.Properties.Appearance.Options.UseBackColor = true;
            this.editArchivStandort.Properties.Appearance.Options.UseBorderColor = true;
            this.editArchivStandort.Properties.Appearance.Options.UseFont = true;
            this.editArchivStandort.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.editArchivStandort.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.editArchivStandort.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.editArchivStandort.Properties.AppearanceDropDown.Options.UseFont = true;
            this.editArchivStandort.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.editArchivStandort.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.editArchivStandort.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editArchivStandort.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.editArchivStandort.Properties.DisplayMember = "Text";
            this.editArchivStandort.Properties.NullText = "";
            this.editArchivStandort.Properties.ReadOnly = true;
            this.editArchivStandort.Properties.ShowFooter = false;
            this.editArchivStandort.Properties.ShowHeader = false;
            this.editArchivStandort.Properties.ValueMember = "Code";
            this.editArchivStandort.Size = new System.Drawing.Size(239, 24);
            this.editArchivStandort.TabIndex = 37;
            // 
            // kissLabel2
            // 
            this.kissLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel2.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel2.Location = new System.Drawing.Point(5, 394);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(100, 16);
            this.kissLabel2.TabIndex = 43;
            this.kissLabel2.Text = "Archiv-History";
            // 
            // btnZurueckholen
            // 
            this.btnZurueckholen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnZurueckholen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnZurueckholen.Enabled = false;
            this.btnZurueckholen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZurueckholen.Location = new System.Drawing.Point(436, 362);
            this.btnZurueckholen.Name = "btnZurueckholen";
            this.btnZurueckholen.Size = new System.Drawing.Size(96, 24);
            this.btnZurueckholen.TabIndex = 41;
            this.btnZurueckholen.Text = "Zurückholen";
            this.btnZurueckholen.UseVisualStyleBackColor = false;
            this.btnZurueckholen.Click += new System.EventHandler(this.btnZurueckholen_Click);
            // 
            // btnArchivieren
            // 
            this.btnArchivieren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnArchivieren.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnArchivieren.Enabled = false;
            this.btnArchivieren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArchivieren.Location = new System.Drawing.Point(95, 362);
            this.btnArchivieren.Name = "btnArchivieren";
            this.btnArchivieren.Size = new System.Drawing.Size(96, 24);
            this.btnArchivieren.TabIndex = 38;
            this.btnArchivieren.Text = "Archivieren";
            this.btnArchivieren.UseVisualStyleBackColor = false;
            this.btnArchivieren.Click += new System.EventHandler(this.btnArchivieren_Click);
            // 
            // grdHistory
            // 
            this.grdHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdHistory.DataSource = this.qryHistory;
            // 
            // 
            // 
            this.grdHistory.EmbeddedNavigator.Name = "";
            this.grdHistory.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdHistory.Location = new System.Drawing.Point(5, 418);
            this.grdHistory.MainView = this.grvHistory;
            this.grdHistory.Name = "grdHistory";
            this.grdHistory.Size = new System.Drawing.Size(947, 114);
            this.grdHistory.TabIndex = 35;
            this.grdHistory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvHistory});
            // 
            // qryHistory
            // 
            this.qryHistory.HostControl = this;
            this.qryHistory.IsIdentityInsert = false;
            // 
            // grvHistory
            // 
            this.grvHistory.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvHistory.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHistory.Appearance.Empty.Options.UseBackColor = true;
            this.grvHistory.Appearance.Empty.Options.UseFont = true;
            this.grvHistory.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvHistory.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHistory.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvHistory.Appearance.EvenRow.Options.UseFont = true;
            this.grvHistory.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvHistory.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHistory.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvHistory.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvHistory.Appearance.FocusedCell.Options.UseFont = true;
            this.grvHistory.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvHistory.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvHistory.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHistory.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvHistory.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvHistory.Appearance.FocusedRow.Options.UseFont = true;
            this.grvHistory.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvHistory.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvHistory.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvHistory.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvHistory.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvHistory.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvHistory.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvHistory.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvHistory.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvHistory.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvHistory.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvHistory.Appearance.GroupRow.Options.UseFont = true;
            this.grvHistory.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvHistory.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvHistory.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvHistory.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvHistory.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvHistory.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvHistory.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvHistory.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvHistory.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHistory.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvHistory.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvHistory.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvHistory.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvHistory.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvHistory.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvHistory.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvHistory.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHistory.Appearance.OddRow.Options.UseBackColor = true;
            this.grvHistory.Appearance.OddRow.Options.UseFont = true;
            this.grvHistory.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvHistory.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHistory.Appearance.Row.Options.UseBackColor = true;
            this.grvHistory.Appearance.Row.Options.UseFont = true;
            this.grvHistory.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvHistory.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHistory.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvHistory.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvHistory.Appearance.SelectedRow.Options.UseFont = true;
            this.grvHistory.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvHistory.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvHistory.Appearance.VertLine.Options.UseBackColor = true;
            this.grvHistory.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvHistory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStandort,
            this.colArchivNr,
            this.colCheckIn,
            this.colCheckInUser,
            this.colCheckOut,
            this.colCheckOutUser});
            this.grvHistory.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvHistory.GridControl = this.grdHistory;
            this.grvHistory.Name = "grvHistory";
            this.grvHistory.OptionsBehavior.Editable = false;
            this.grvHistory.OptionsCustomization.AllowFilter = false;
            this.grvHistory.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvHistory.OptionsNavigation.AutoFocusNewRow = true;
            this.grvHistory.OptionsNavigation.UseTabKey = false;
            this.grvHistory.OptionsView.ColumnAutoWidth = false;
            this.grvHistory.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvHistory.OptionsView.ShowGroupPanel = false;
            this.grvHistory.OptionsView.ShowIndicator = false;
            // 
            // colStandort
            // 
            this.colStandort.Caption = "Standort";
            this.colStandort.FieldName = "Standort";
            this.colStandort.Name = "colStandort";
            this.colStandort.Visible = true;
            this.colStandort.VisibleIndex = 0;
            this.colStandort.Width = 259;
            // 
            // colArchivNr
            // 
            this.colArchivNr.Caption = "Archiv-Nr.";
            this.colArchivNr.FieldName = "ArchivNr";
            this.colArchivNr.Name = "colArchivNr";
            this.colArchivNr.Visible = true;
            this.colArchivNr.VisibleIndex = 1;
            this.colArchivNr.Width = 129;
            // 
            // colCheckIn
            // 
            this.colCheckIn.Caption = "archiviert";
            this.colCheckIn.FieldName = "CheckIn";
            this.colCheckIn.Name = "colCheckIn";
            this.colCheckIn.Visible = true;
            this.colCheckIn.VisibleIndex = 2;
            // 
            // colCheckInUser
            // 
            this.colCheckInUser.Caption = "durch";
            this.colCheckInUser.FieldName = "CheckInUserName";
            this.colCheckInUser.Name = "colCheckInUser";
            this.colCheckInUser.Visible = true;
            this.colCheckInUser.VisibleIndex = 3;
            this.colCheckInUser.Width = 150;
            // 
            // colCheckOut
            // 
            this.colCheckOut.Caption = "zurück";
            this.colCheckOut.FieldName = "CheckOut";
            this.colCheckOut.Name = "colCheckOut";
            this.colCheckOut.Visible = true;
            this.colCheckOut.VisibleIndex = 4;
            // 
            // colCheckOutUser
            // 
            this.colCheckOutUser.Caption = "durch";
            this.colCheckOutUser.FieldName = "CheckOutUserName";
            this.colCheckOutUser.Name = "colCheckOutUser";
            this.colCheckOutUser.Visible = true;
            this.colCheckOutUser.VisibleIndex = 5;
            this.colCheckOutUser.Width = 150;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageListe);
            this.tabControl1.Controls.Add(this.tabPageSuchen);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabControl1.Location = new System.Drawing.Point(5, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabIndex = 1;
            this.tabControl1.ShowFixedWidthTooltip = true;
            this.tabControl1.Size = new System.Drawing.Size(945, 258);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tabPageListe,
            this.tabPageSuchen});
            this.tabControl1.TabsLineColor = System.Drawing.Color.Black;
            this.tabControl1.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabControl1.TabStop = false;
            this.tabControl1.Text = "xTabControl2";
            this.tabControl1.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControl1_SelectedTabChanged);
            // 
            // tabPageListe
            // 
            this.tabPageListe.Controls.Add(this.grdFaLeistung);
            this.tabPageListe.Location = new System.Drawing.Point(6, 6);
            this.tabPageListe.Name = "tabPageListe";
            this.tabPageListe.Size = new System.Drawing.Size(933, 220);
            this.tabPageListe.TabIndex = 0;
            this.tabPageListe.Title = "Liste";
            // 
            // grdFaLeistung
            // 
            this.grdFaLeistung.DataSource = this.qryFaLeistung;
            this.grdFaLeistung.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdFaLeistung.EmbeddedNavigator.Name = "";
            this.grdFaLeistung.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdFaLeistung.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdFaLeistung.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdFaLeistung.Location = new System.Drawing.Point(0, 0);
            this.grdFaLeistung.MainView = this.grvFaLeistung;
            this.grdFaLeistung.Name = "grdFaLeistung";
            this.grdFaLeistung.Size = new System.Drawing.Size(933, 220);
            this.grdFaLeistung.TabIndex = 0;
            this.grdFaLeistung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvFaLeistung});
            // 
            // grvFaLeistung
            // 
            this.grvFaLeistung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvFaLeistung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.Empty.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.Empty.Options.UseFont = true;
            this.grvFaLeistung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.EvenRow.Options.UseFont = true;
            this.grvFaLeistung.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFaLeistung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvFaLeistung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.FocusedCell.Options.UseFont = true;
            this.grvFaLeistung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvFaLeistung.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFaLeistung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvFaLeistung.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.FocusedRow.Options.UseFont = true;
            this.grvFaLeistung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvFaLeistung.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFaLeistung.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvFaLeistung.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvFaLeistung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFaLeistung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFaLeistung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFaLeistung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFaLeistung.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.GroupRow.Options.UseFont = true;
            this.grvFaLeistung.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvFaLeistung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvFaLeistung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvFaLeistung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFaLeistung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvFaLeistung.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvFaLeistung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvFaLeistung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFaLeistung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvFaLeistung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvFaLeistung.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvFaLeistung.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.OddRow.Options.UseFont = true;
            this.grvFaLeistung.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvFaLeistung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.Row.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.Row.Options.UseFont = true;
            this.grvFaLeistung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.SelectedRow.Options.UseFont = true;
            this.grvFaLeistung.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvFaLeistung.Appearance.VertLine.Options.UseBackColor = true;
            this.grvFaLeistung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvFaLeistung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colArchiviert,
            this.colStandort2,
            this.colArchivNr2,
            this.colPerson,
            this.colModul,
            this.colSAR,
            this.colDatumVon,
            this.colDatumBis,
            this.colNEWOD});
            this.grvFaLeistung.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvFaLeistung.GridControl = this.grdFaLeistung;
            this.grvFaLeistung.Name = "grvFaLeistung";
            this.grvFaLeistung.OptionsBehavior.Editable = false;
            this.grvFaLeistung.OptionsCustomization.AllowFilter = false;
            this.grvFaLeistung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvFaLeistung.OptionsNavigation.AutoFocusNewRow = true;
            this.grvFaLeistung.OptionsNavigation.UseTabKey = false;
            this.grvFaLeistung.OptionsView.ColumnAutoWidth = false;
            this.grvFaLeistung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvFaLeistung.OptionsView.ShowGroupPanel = false;
            this.grvFaLeistung.OptionsView.ShowIndicator = false;
            // 
            // colArchiviert
            // 
            this.colArchiviert.Caption = "A";
            this.colArchiviert.FieldName = "A";
            this.colArchiviert.Name = "colArchiviert";
            this.colArchiviert.Visible = true;
            this.colArchiviert.VisibleIndex = 0;
            this.colArchiviert.Width = 20;
            // 
            // colStandort2
            // 
            this.colStandort2.Caption = "Standort";
            this.colStandort2.FieldName = "Standort";
            this.colStandort2.Name = "colStandort2";
            this.colStandort2.Visible = true;
            this.colStandort2.VisibleIndex = 1;
            this.colStandort2.Width = 209;
            // 
            // colArchivNr2
            // 
            this.colArchivNr2.Caption = "ArchivNr";
            this.colArchivNr2.FieldName = "ArchivNr";
            this.colArchivNr2.Name = "colArchivNr2";
            this.colArchivNr2.Visible = true;
            this.colArchivNr2.VisibleIndex = 2;
            this.colArchivNr2.Width = 109;
            // 
            // colPerson
            // 
            this.colPerson.Caption = "Fallträger/-in";
            this.colPerson.FieldName = "Person";
            this.colPerson.Name = "colPerson";
            this.colPerson.Visible = true;
            this.colPerson.VisibleIndex = 3;
            this.colPerson.Width = 161;
            // 
            // colModul
            // 
            this.colModul.Caption = "Modul";
            this.colModul.FieldName = "Modul";
            this.colModul.Name = "colModul";
            this.colModul.Visible = true;
            this.colModul.VisibleIndex = 4;
            this.colModul.Width = 119;
            // 
            // colSAR
            // 
            this.colSAR.Caption = "SAR";
            this.colSAR.FieldName = "SAR";
            this.colSAR.Name = "colSAR";
            this.colSAR.Visible = true;
            this.colSAR.VisibleIndex = 5;
            this.colSAR.Width = 150;
            // 
            // colDatumVon
            // 
            this.colDatumVon.Caption = "Datum von";
            this.colDatumVon.FieldName = "DatumVon";
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.Visible = true;
            this.colDatumVon.VisibleIndex = 6;
            // 
            // colDatumBis
            // 
            this.colDatumBis.Caption = "Datum bis";
            this.colDatumBis.FieldName = "DatumBis";
            this.colDatumBis.Name = "colDatumBis";
            this.colDatumBis.Visible = true;
            this.colDatumBis.VisibleIndex = 7;
            // 
            // colNEWOD
            // 
            this.colNEWOD.Caption = "NEWOD";
            this.colNEWOD.FieldName = "NEWOD";
            this.colNEWOD.Name = "colNEWOD";
            this.colNEWOD.OptionsColumn.ShowInCustomizationForm = false;
            this.colNEWOD.Visible = true;
            this.colNEWOD.VisibleIndex = 8;
            this.colNEWOD.Width = 56;
            // 
            // tabPageSuchen
            // 
            this.tabPageSuchen.Controls.Add(this.panel1);
            this.tabPageSuchen.Controls.Add(this.btnSearch);
            this.tabPageSuchen.Location = new System.Drawing.Point(6, 6);
            this.tabPageSuchen.Name = "tabPageSuchen";
            this.tabPageSuchen.Size = new System.Drawing.Size(933, 220);
            this.tabPageSuchen.TabIndex = 1;
            this.tabPageSuchen.Title = "Suchen";
            this.tabPageSuchen.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.editVersNrX);
            this.panel1.Controls.Add(this.lblVersNrX);
            this.panel1.Controls.Add(this.editNNummerX);
            this.panel1.Controls.Add(this.kissLabel15);
            this.panel1.Controls.Add(this.editAHVNr);
            this.panel1.Controls.Add(this.kissLabel14);
            this.panel1.Controls.Add(this.editStatusX);
            this.panel1.Controls.Add(this.kissLabel13);
            this.panel1.Controls.Add(this.editArchivNrX);
            this.panel1.Controls.Add(this.kissLabel8);
            this.panel1.Controls.Add(this.editSARX);
            this.panel1.Controls.Add(this.editStandortX);
            this.panel1.Controls.Add(this.kissLabel4);
            this.panel1.Controls.Add(this.kissSearchTitel1);
            this.panel1.Controls.Add(this.editModulX);
            this.panel1.Controls.Add(this.kissLabel7);
            this.panel1.Controls.Add(this.kissLabel6);
            this.panel1.Controls.Add(this.editPersonX);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(933, 220);
            this.panel1.TabIndex = 0;
            // 
            // editVersNrX
            // 
            this.editVersNrX.EditValue = "";
            this.editVersNrX.Location = new System.Drawing.Point(90, 100);
            this.editVersNrX.Name = "editVersNrX";
            this.editVersNrX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editVersNrX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editVersNrX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editVersNrX.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.editVersNrX.Properties.Appearance.Options.UseBackColor = true;
            this.editVersNrX.Properties.Appearance.Options.UseBorderColor = true;
            this.editVersNrX.Properties.Appearance.Options.UseFont = true;
            this.editVersNrX.Properties.Appearance.Options.UseForeColor = true;
            this.editVersNrX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editVersNrX.Size = new System.Drawing.Size(239, 24);
            this.editVersNrX.TabIndex = 6;
            // 
            // lblVersNrX
            // 
            this.lblVersNrX.ForeColor = System.Drawing.Color.Black;
            this.lblVersNrX.Location = new System.Drawing.Point(5, 100);
            this.lblVersNrX.Name = "lblVersNrX";
            this.lblVersNrX.Size = new System.Drawing.Size(89, 24);
            this.lblVersNrX.TabIndex = 5;
            this.lblVersNrX.Text = "Versichertennr.";
            // 
            // editNNummerX
            // 
            this.editNNummerX.EditValue = "";
            this.editNNummerX.Location = new System.Drawing.Point(90, 130);
            this.editNNummerX.Name = "editNNummerX";
            this.editNNummerX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editNNummerX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editNNummerX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editNNummerX.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.editNNummerX.Properties.Appearance.Options.UseBackColor = true;
            this.editNNummerX.Properties.Appearance.Options.UseBorderColor = true;
            this.editNNummerX.Properties.Appearance.Options.UseFont = true;
            this.editNNummerX.Properties.Appearance.Options.UseForeColor = true;
            this.editNNummerX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editNNummerX.Size = new System.Drawing.Size(239, 24);
            this.editNNummerX.TabIndex = 8;
            // 
            // kissLabel15
            // 
            this.kissLabel15.ForeColor = System.Drawing.Color.Black;
            this.kissLabel15.Location = new System.Drawing.Point(6, 130);
            this.kissLabel15.Name = "kissLabel15";
            this.kissLabel15.Size = new System.Drawing.Size(74, 24);
            this.kissLabel15.TabIndex = 7;
            this.kissLabel15.Text = "N-Nummer";
            // 
            // editAHVNr
            // 
            this.editAHVNr.EditValue = "";
            this.editAHVNr.Location = new System.Drawing.Point(90, 70);
            this.editAHVNr.Name = "editAHVNr";
            this.editAHVNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editAHVNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editAHVNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editAHVNr.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.editAHVNr.Properties.Appearance.Options.UseBackColor = true;
            this.editAHVNr.Properties.Appearance.Options.UseBorderColor = true;
            this.editAHVNr.Properties.Appearance.Options.UseFont = true;
            this.editAHVNr.Properties.Appearance.Options.UseForeColor = true;
            this.editAHVNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editAHVNr.Size = new System.Drawing.Size(239, 24);
            this.editAHVNr.TabIndex = 4;
            // 
            // kissLabel14
            // 
            this.kissLabel14.ForeColor = System.Drawing.Color.Black;
            this.kissLabel14.Location = new System.Drawing.Point(5, 70);
            this.kissLabel14.Name = "kissLabel14";
            this.kissLabel14.Size = new System.Drawing.Size(74, 24);
            this.kissLabel14.TabIndex = 3;
            this.kissLabel14.Text = "AHV-Nr";
            // 
            // editStatusX
            // 
            this.editStatusX.Location = new System.Drawing.Point(454, 70);
            this.editStatusX.Name = "editStatusX";
            this.editStatusX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editStatusX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editStatusX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editStatusX.Properties.Appearance.Options.UseBackColor = true;
            this.editStatusX.Properties.Appearance.Options.UseBorderColor = true;
            this.editStatusX.Properties.Appearance.Options.UseFont = true;
            this.editStatusX.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.editStatusX.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.editStatusX.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.editStatusX.Properties.AppearanceDropDown.Options.UseFont = true;
            this.editStatusX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.editStatusX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.editStatusX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editStatusX.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.editStatusX.Properties.DisplayMember = "Text";
            this.editStatusX.Properties.NullText = "";
            this.editStatusX.Properties.ShowFooter = false;
            this.editStatusX.Properties.ShowHeader = false;
            this.editStatusX.Properties.ValueMember = "Code";
            this.editStatusX.Size = new System.Drawing.Size(239, 24);
            this.editStatusX.TabIndex = 16;
            // 
            // kissLabel13
            // 
            this.kissLabel13.ForeColor = System.Drawing.Color.Black;
            this.kissLabel13.Location = new System.Drawing.Point(380, 70);
            this.kissLabel13.Name = "kissLabel13";
            this.kissLabel13.Size = new System.Drawing.Size(52, 24);
            this.kissLabel13.TabIndex = 15;
            this.kissLabel13.Text = "Status";
            // 
            // editArchivNrX
            // 
            this.editArchivNrX.EditValue = "";
            this.editArchivNrX.Location = new System.Drawing.Point(454, 100);
            this.editArchivNrX.Name = "editArchivNrX";
            this.editArchivNrX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editArchivNrX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editArchivNrX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editArchivNrX.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.editArchivNrX.Properties.Appearance.Options.UseBackColor = true;
            this.editArchivNrX.Properties.Appearance.Options.UseBorderColor = true;
            this.editArchivNrX.Properties.Appearance.Options.UseFont = true;
            this.editArchivNrX.Properties.Appearance.Options.UseForeColor = true;
            this.editArchivNrX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editArchivNrX.Size = new System.Drawing.Size(239, 24);
            this.editArchivNrX.TabIndex = 18;
            // 
            // kissLabel8
            // 
            this.kissLabel8.ForeColor = System.Drawing.Color.Black;
            this.kissLabel8.Location = new System.Drawing.Point(380, 100);
            this.kissLabel8.Name = "kissLabel8";
            this.kissLabel8.Size = new System.Drawing.Size(74, 24);
            this.kissLabel8.TabIndex = 17;
            this.kissLabel8.Text = "Archiv-Nr.";
            // 
            // editSARX
            // 
            this.editSARX.EditValue = "";
            this.editSARX.Location = new System.Drawing.Point(90, 193);
            this.editSARX.Name = "editSARX";
            this.editSARX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editSARX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editSARX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editSARX.Properties.Appearance.Options.UseBackColor = true;
            this.editSARX.Properties.Appearance.Options.UseBorderColor = true;
            this.editSARX.Properties.Appearance.Options.UseFont = true;
            this.editSARX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.editSARX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.editSARX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editSARX.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.editSARX.Size = new System.Drawing.Size(239, 24);
            this.editSARX.TabIndex = 12;
            this.editSARX.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.editSARX_UserModifiedFld);
            // 
            // editStandortX
            // 
            this.editStandortX.Location = new System.Drawing.Point(454, 40);
            this.editStandortX.Name = "editStandortX";
            this.editStandortX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editStandortX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editStandortX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editStandortX.Properties.Appearance.Options.UseBackColor = true;
            this.editStandortX.Properties.Appearance.Options.UseBorderColor = true;
            this.editStandortX.Properties.Appearance.Options.UseFont = true;
            this.editStandortX.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.editStandortX.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.editStandortX.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.editStandortX.Properties.AppearanceDropDown.Options.UseFont = true;
            this.editStandortX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.editStandortX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.editStandortX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editStandortX.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.editStandortX.Properties.DisplayMember = "Text";
            this.editStandortX.Properties.NullText = "";
            this.editStandortX.Properties.ShowFooter = false;
            this.editStandortX.Properties.ShowHeader = false;
            this.editStandortX.Properties.ValueMember = "Code";
            this.editStandortX.Size = new System.Drawing.Size(239, 24);
            this.editStandortX.TabIndex = 14;
            // 
            // kissLabel4
            // 
            this.kissLabel4.ForeColor = System.Drawing.Color.Black;
            this.kissLabel4.Location = new System.Drawing.Point(380, 40);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(52, 24);
            this.kissLabel4.TabIndex = 13;
            this.kissLabel4.Text = "Standort";
            // 
            // kissSearchTitel1
            // 
            this.kissSearchTitel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissSearchTitel1.Location = new System.Drawing.Point(10, 7);
            this.kissSearchTitel1.Name = "kissSearchTitel1";
            this.kissSearchTitel1.Size = new System.Drawing.Size(200, 24);
            this.kissSearchTitel1.TabIndex = 0;
            // 
            // editModulX
            // 
            this.editModulX.Location = new System.Drawing.Point(90, 163);
            this.editModulX.LOVName = "Modul";
            this.editModulX.Name = "editModulX";
            this.editModulX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editModulX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editModulX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editModulX.Properties.Appearance.Options.UseBackColor = true;
            this.editModulX.Properties.Appearance.Options.UseBorderColor = true;
            this.editModulX.Properties.Appearance.Options.UseFont = true;
            this.editModulX.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.editModulX.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.editModulX.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.editModulX.Properties.AppearanceDropDown.Options.UseFont = true;
            this.editModulX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.editModulX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.editModulX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editModulX.Properties.NullText = "";
            this.editModulX.Properties.ShowFooter = false;
            this.editModulX.Properties.ShowHeader = false;
            this.editModulX.Size = new System.Drawing.Size(239, 24);
            this.editModulX.TabIndex = 10;
            // 
            // kissLabel7
            // 
            this.kissLabel7.ForeColor = System.Drawing.Color.Black;
            this.kissLabel7.Location = new System.Drawing.Point(5, 163);
            this.kissLabel7.Name = "kissLabel7";
            this.kissLabel7.Size = new System.Drawing.Size(38, 24);
            this.kissLabel7.TabIndex = 9;
            this.kissLabel7.Text = "Modul";
            // 
            // kissLabel6
            // 
            this.kissLabel6.ForeColor = System.Drawing.Color.Black;
            this.kissLabel6.Location = new System.Drawing.Point(5, 193);
            this.kissLabel6.Name = "kissLabel6";
            this.kissLabel6.Size = new System.Drawing.Size(38, 24);
            this.kissLabel6.TabIndex = 11;
            this.kissLabel6.Text = "SAR";
            // 
            // editPersonX
            // 
            this.editPersonX.EditValue = "";
            this.editPersonX.Location = new System.Drawing.Point(90, 40);
            this.editPersonX.Name = "editPersonX";
            this.editPersonX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editPersonX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editPersonX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editPersonX.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.editPersonX.Properties.Appearance.Options.UseBackColor = true;
            this.editPersonX.Properties.Appearance.Options.UseBorderColor = true;
            this.editPersonX.Properties.Appearance.Options.UseFont = true;
            this.editPersonX.Properties.Appearance.Options.UseForeColor = true;
            this.editPersonX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editPersonX.Size = new System.Drawing.Size(239, 24);
            this.editPersonX.TabIndex = 2;
            // 
            // label25
            // 
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(5, 40);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(74, 24);
            this.label25.TabIndex = 1;
            this.label25.Text = "Fallträger/-in";
            // 
            // btnSearch
            // 
            this.btnSearch.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(507, 544);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(96, 24);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Suchen";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // kissLabel1
            // 
            this.kissLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel1.Location = new System.Drawing.Point(7, 328);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(84, 24);
            this.kissLabel1.TabIndex = 42;
            this.kissLabel1.Text = "Neuer Standort";
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 25);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Archivieren";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabSuchen
            // 
            this.tabSuchen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.tabSuchen.Controls.Add(this.lblFilterKandidaten);
            this.tabSuchen.Controls.Add(this.edtFilterKandidaten);
            this.tabSuchen.Controls.Add(this.label1);
            this.tabSuchen.Controls.Add(this.edtSortKey);
            this.tabSuchen.Controls.Add(this.lblSortKey);
            this.tabSuchen.Controls.Add(this.edtAddress);
            this.tabSuchen.Controls.Add(this.lblAddress);
            this.tabSuchen.Controls.Add(this.gridVerfuegbar);
            this.tabSuchen.Controls.Add(this.gridZugeteilt);
            this.tabSuchen.Controls.Add(this.edtRemark);
            this.tabSuchen.Controls.Add(this.btnAddAll);
            this.tabSuchen.Controls.Add(this.btnRemoveAll);
            this.tabSuchen.Controls.Add(this.btnAdd);
            this.tabSuchen.Controls.Add(this.btnRemove);
            this.tabSuchen.Controls.Add(this.edtName);
            this.tabSuchen.Controls.Add(this.lblRemark);
            this.tabSuchen.Controls.Add(this.lblName);
            this.tabSuchen.Controls.Add(this.grdArchiv);
            this.tabSuchen.Location = new System.Drawing.Point(6, 6);
            this.tabSuchen.Name = "tabSuchen";
            this.tabSuchen.Size = new System.Drawing.Size(954, 536);
            this.tabSuchen.TabIndex = 1;
            this.tabSuchen.Title = "Archivstandorte";
            this.tabSuchen.Visible = false;
            // 
            // lblFilterKandidaten
            // 
            this.lblFilterKandidaten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFilterKandidaten.Location = new System.Drawing.Point(5, 510);
            this.lblFilterKandidaten.Name = "lblFilterKandidaten";
            this.lblFilterKandidaten.Size = new System.Drawing.Size(43, 24);
            this.lblFilterKandidaten.TabIndex = 278;
            this.lblFilterKandidaten.Text = "Filter";
            this.lblFilterKandidaten.UseCompatibleTextRendering = true;
            // 
            // edtFilterKandidaten
            // 
            this.edtFilterKandidaten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtFilterKandidaten.Location = new System.Drawing.Point(54, 510);
            this.edtFilterKandidaten.Name = "edtFilterKandidaten";
            this.edtFilterKandidaten.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFilterKandidaten.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFilterKandidaten.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFilterKandidaten.Properties.Appearance.Options.UseBackColor = true;
            this.edtFilterKandidaten.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFilterKandidaten.Properties.Appearance.Options.UseFont = true;
            this.edtFilterKandidaten.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFilterKandidaten.Size = new System.Drawing.Size(239, 24);
            this.edtFilterKandidaten.TabIndex = 277;
            this.edtFilterKandidaten.EditValueChanged += new System.EventHandler(this.edtFilterKandidaten_EditValueChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 25);
            this.label1.TabIndex = 31;
            this.label1.Text = "Archivstandorte";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // edtSortKey
            // 
            this.edtSortKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSortKey.DataMember = "SortKey";
            this.edtSortKey.DataSource = this.qryArchive;
            this.edtSortKey.Location = new System.Drawing.Point(607, 189);
            this.edtSortKey.Name = "edtSortKey";
            this.edtSortKey.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSortKey.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSortKey.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSortKey.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSortKey.Properties.Appearance.Options.UseBackColor = true;
            this.edtSortKey.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSortKey.Properties.Appearance.Options.UseFont = true;
            this.edtSortKey.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSortKey.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSortKey.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSortKey.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSortKey.Size = new System.Drawing.Size(35, 24);
            this.edtSortKey.TabIndex = 2;
            // 
            // qryArchive
            // 
            this.qryArchive.CanDelete = true;
            this.qryArchive.CanInsert = true;
            this.qryArchive.CanUpdate = true;
            this.qryArchive.HostControl = this;
            this.qryArchive.IsIdentityInsert = false;
            this.qryArchive.TableName = "XArchive";
            this.qryArchive.AfterInsert += new System.EventHandler(this.qryArchive_AfterInsert);
            this.qryArchive.BeforePost += new System.EventHandler(this.qryArchive_BeforePost);
            this.qryArchive.PositionChanged += new System.EventHandler(this.qryArchive_PositionChanged);
            // 
            // lblSortKey
            // 
            this.lblSortKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSortKey.Location = new System.Drawing.Point(540, 189);
            this.lblSortKey.Name = "lblSortKey";
            this.lblSortKey.Size = new System.Drawing.Size(65, 24);
            this.lblSortKey.TabIndex = 30;
            this.lblSortKey.Text = "Reihenfolge";
            // 
            // edtAddress
            // 
            this.edtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAddress.DataMember = "Address";
            this.edtAddress.DataSource = this.qryArchive;
            this.edtAddress.Location = new System.Drawing.Point(44, 238);
            this.edtAddress.Name = "edtAddress";
            this.edtAddress.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAddress.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAddress.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAddress.Properties.Appearance.Options.UseBackColor = true;
            this.edtAddress.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAddress.Properties.Appearance.Options.UseFont = true;
            this.edtAddress.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAddress.Size = new System.Drawing.Size(244, 71);
            this.edtAddress.TabIndex = 3;
            // 
            // lblAddress
            // 
            this.lblAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAddress.Location = new System.Drawing.Point(43, 214);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(76, 24);
            this.lblAddress.TabIndex = 29;
            this.lblAddress.Text = "Adresse";
            // 
            // gridVerfuegbar
            // 
            this.gridVerfuegbar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gridVerfuegbar.DataSource = this.qryKandidaten;
            // 
            // 
            // 
            this.gridVerfuegbar.EmbeddedNavigator.Name = "";
            this.gridVerfuegbar.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.gridVerfuegbar.Location = new System.Drawing.Point(5, 320);
            this.gridVerfuegbar.MainView = this.gridView2;
            this.gridVerfuegbar.Name = "gridVerfuegbar";
            this.gridVerfuegbar.Size = new System.Drawing.Size(288, 184);
            this.gridVerfuegbar.TabIndex = 5;
            this.gridVerfuegbar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            this.gridVerfuegbar.DoubleClick += new System.EventHandler(this.btnAdd_Click);
            // 
            // qryKandidaten
            // 
            this.qryKandidaten.HostControl = this;
            this.qryKandidaten.IsIdentityInsert = false;
            // 
            // gridView2
            // 
            this.gridView2.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView2.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.Empty.Options.UseBackColor = true;
            this.gridView2.Appearance.Empty.Options.UseFont = true;
            this.gridView2.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.gridView2.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.EvenRow.Options.UseBackColor = true;
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
            this.gridView2.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView2.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView2.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupFooter.Options.UseBorderColor = true;
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
            this.gridView2.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.gridView2.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.OddRow.Options.UseBackColor = true;
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
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUser2,
            this.colUserID2});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView2.GridControl = this.gridVerfuegbar;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsCustomization.AllowFilter = false;
            this.gridView2.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView2.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView2.OptionsNavigation.UseTabKey = false;
            this.gridView2.OptionsSelection.MultiSelect = true;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowIndicator = false;
            // 
            // colUser2
            // 
            this.colUser2.Caption = "Kandidaten";
            this.colUser2.FieldName = "UserName";
            this.colUser2.Name = "colUser2";
            this.colUser2.Visible = true;
            this.colUser2.VisibleIndex = 0;
            this.colUser2.Width = 264;
            // 
            // colUserID2
            // 
            this.colUserID2.Caption = "-";
            this.colUserID2.FieldName = "UserID";
            this.colUserID2.Name = "colUserID2";
            // 
            // gridZugeteilt
            // 
            this.gridZugeteilt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gridZugeteilt.DataSource = this.qryZugeteilt;
            // 
            // 
            // 
            this.gridZugeteilt.EmbeddedNavigator.Name = "";
            this.gridZugeteilt.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.gridZugeteilt.Location = new System.Drawing.Point(355, 320);
            this.gridZugeteilt.MainView = this.gridView4;
            this.gridZugeteilt.Name = "gridZugeteilt";
            this.gridZugeteilt.Size = new System.Drawing.Size(288, 214);
            this.gridZugeteilt.TabIndex = 28;
            this.gridZugeteilt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView4});
            this.gridZugeteilt.DoubleClick += new System.EventHandler(this.btnRemove_Click);
            // 
            // qryZugeteilt
            // 
            this.qryZugeteilt.CanDelete = true;
            this.qryZugeteilt.CanInsert = true;
            this.qryZugeteilt.CanUpdate = true;
            this.qryZugeteilt.HostControl = this;
            this.qryZugeteilt.IsIdentityInsert = false;
            this.qryZugeteilt.TableName = "XUser_Archive";
            // 
            // gridView4
            // 
            this.gridView4.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView4.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.Empty.Options.UseBackColor = true;
            this.gridView4.Appearance.Empty.Options.UseFont = true;
            this.gridView4.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.gridView4.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView4.Appearance.EvenRow.Options.UseFont = true;
            this.gridView4.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView4.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView4.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView4.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView4.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView4.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView4.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView4.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView4.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView4.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView4.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView4.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView4.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView4.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView4.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView4.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView4.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView4.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView4.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView4.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView4.Appearance.GroupRow.Options.UseFont = true;
            this.gridView4.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView4.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView4.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView4.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView4.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView4.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView4.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView4.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView4.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView4.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView4.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView4.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView4.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView4.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView4.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.gridView4.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView4.Appearance.OddRow.Options.UseFont = true;
            this.gridView4.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView4.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.Row.Options.UseBackColor = true;
            this.gridView4.Appearance.Row.Options.UseFont = true;
            this.gridView4.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gridView4.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView4.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView4.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView4.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView4.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView4.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUserID1,
            this.colUserI1});
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView4.GridControl = this.gridZugeteilt;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsBehavior.Editable = false;
            this.gridView4.OptionsCustomization.AllowFilter = false;
            this.gridView4.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView4.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView4.OptionsNavigation.UseTabKey = false;
            this.gridView4.OptionsView.ColumnAutoWidth = false;
            this.gridView4.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            this.gridView4.OptionsView.ShowIndicator = false;
            // 
            // colUserID1
            // 
            this.colUserID1.Caption = "Zugeteilte Gruppen";
            this.colUserID1.FieldName = "UserID";
            this.colUserID1.Name = "colUserID1";
            this.colUserID1.Width = 243;
            // 
            // colUserI1
            // 
            this.colUserI1.Caption = "Archivaren";
            this.colUserI1.FieldName = "UserName";
            this.colUserI1.Name = "colUserI1";
            this.colUserI1.Visible = true;
            this.colUserI1.VisibleIndex = 0;
            this.colUserI1.Width = 264;
            // 
            // edtRemark
            // 
            this.edtRemark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtRemark.DataMember = "Remark";
            this.edtRemark.DataSource = this.qryArchive;
            this.edtRemark.Location = new System.Drawing.Point(301, 238);
            this.edtRemark.Name = "edtRemark";
            this.edtRemark.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtRemark.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtRemark.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtRemark.Properties.Appearance.Options.UseBackColor = true;
            this.edtRemark.Properties.Appearance.Options.UseBorderColor = true;
            this.edtRemark.Properties.Appearance.Options.UseFont = true;
            this.edtRemark.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtRemark.Size = new System.Drawing.Size(342, 69);
            this.edtRemark.TabIndex = 4;
            // 
            // btnAddAll
            // 
            this.btnAddAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAll.IconID = 14;
            this.btnAddAll.Location = new System.Drawing.Point(310, 428);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(28, 24);
            this.btnAddAll.TabIndex = 25;
            this.btnAddAll.UseVisualStyleBackColor = false;
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAll.IconID = 12;
            this.btnRemoveAll.Location = new System.Drawing.Point(310, 458);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(28, 24);
            this.btnRemoveAll.TabIndex = 26;
            this.btnRemoveAll.UseVisualStyleBackColor = false;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.IconID = 13;
            this.btnAdd.Location = new System.Drawing.Point(310, 368);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(28, 24);
            this.btnAdd.TabIndex = 22;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.IconID = 11;
            this.btnRemove.Location = new System.Drawing.Point(310, 398);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(28, 24);
            this.btnRemove.TabIndex = 23;
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // edtName
            // 
            this.edtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtName.DataMember = "Name";
            this.edtName.DataSource = this.qryArchive;
            this.edtName.Location = new System.Drawing.Point(44, 189);
            this.edtName.Name = "edtName";
            this.edtName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtName.Properties.Appearance.Options.UseBackColor = true;
            this.edtName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtName.Properties.Appearance.Options.UseFont = true;
            this.edtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtName.Size = new System.Drawing.Size(479, 24);
            this.edtName.TabIndex = 1;
            // 
            // lblRemark
            // 
            this.lblRemark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRemark.Location = new System.Drawing.Point(301, 214);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(76, 24);
            this.lblRemark.TabIndex = 27;
            this.lblRemark.Text = "Beschreibung";
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblName.Location = new System.Drawing.Point(5, 189);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(74, 24);
            this.lblName.TabIndex = 24;
            this.lblName.Text = "Name";
            // 
            // grdArchiv
            // 
            this.grdArchiv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdArchiv.DataSource = this.qryArchive;
            // 
            // 
            // 
            this.grdArchiv.EmbeddedNavigator.Name = "";
            this.grdArchiv.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdArchiv.Location = new System.Drawing.Point(5, 32);
            this.grdArchiv.MainView = this.grvArchiv;
            this.grdArchiv.Name = "grdArchiv";
            this.grdArchiv.Size = new System.Drawing.Size(637, 144);
            this.grdArchiv.TabIndex = 0;
            this.grdArchiv.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvArchiv});
            // 
            // grvArchiv
            // 
            this.grvArchiv.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvArchiv.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvArchiv.Appearance.Empty.Options.UseBackColor = true;
            this.grvArchiv.Appearance.Empty.Options.UseFont = true;
            this.grvArchiv.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvArchiv.Appearance.EvenRow.Options.UseFont = true;
            this.grvArchiv.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvArchiv.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvArchiv.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvArchiv.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvArchiv.Appearance.FocusedCell.Options.UseFont = true;
            this.grvArchiv.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvArchiv.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvArchiv.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvArchiv.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvArchiv.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvArchiv.Appearance.FocusedRow.Options.UseFont = true;
            this.grvArchiv.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvArchiv.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvArchiv.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvArchiv.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvArchiv.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvArchiv.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvArchiv.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvArchiv.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvArchiv.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvArchiv.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvArchiv.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvArchiv.Appearance.GroupRow.Options.UseFont = true;
            this.grvArchiv.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvArchiv.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvArchiv.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvArchiv.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvArchiv.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvArchiv.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvArchiv.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvArchiv.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvArchiv.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvArchiv.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvArchiv.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvArchiv.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvArchiv.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvArchiv.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvArchiv.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvArchiv.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvArchiv.Appearance.OddRow.Options.UseFont = true;
            this.grvArchiv.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvArchiv.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvArchiv.Appearance.Row.Options.UseBackColor = true;
            this.grvArchiv.Appearance.Row.Options.UseFont = true;
            this.grvArchiv.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvArchiv.Appearance.SelectedRow.Options.UseFont = true;
            this.grvArchiv.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvArchiv.Appearance.VertLine.Options.UseBackColor = true;
            this.grvArchiv.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvArchiv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colSortKey});
            this.grvArchiv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvArchiv.GridControl = this.grdArchiv;
            this.grvArchiv.Name = "grvArchiv";
            this.grvArchiv.OptionsBehavior.Editable = false;
            this.grvArchiv.OptionsCustomization.AllowFilter = false;
            this.grvArchiv.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvArchiv.OptionsNavigation.AutoFocusNewRow = true;
            this.grvArchiv.OptionsNavigation.UseTabKey = false;
            this.grvArchiv.OptionsView.ColumnAutoWidth = false;
            this.grvArchiv.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvArchiv.OptionsView.ShowGroupPanel = false;
            this.grvArchiv.OptionsView.ShowIndicator = false;
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 526;
            // 
            // colSortKey
            // 
            this.colSortKey.Caption = "Reihenfolge";
            this.colSortKey.FieldName = "SortKey";
            this.colSortKey.Name = "colSortKey";
            this.colSortKey.Visible = true;
            this.colSortKey.VisibleIndex = 1;
            this.colSortKey.Width = 88;
            // 
            // CtlArchiveManagement
            // 
            this.Controls.Add(this.tabArchiv);
            this.Name = "CtlArchiveManagement";
            this.Size = new System.Drawing.Size(979, 580);
            this.Text = "Archivverwaltung";
            this.Search += new System.EventHandler(this.CtlArchiveManagement_Search);
            this.Load += new System.EventHandler(this.CtlArchiveManagement_Load);
            this.tabArchiv.ResumeLayout(false);
            this.tabListe.ResumeLayout(false);
            this.tabListe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLeistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNNummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAHVNummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNNummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAHVNummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editArchivNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editSAR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editArchivStandort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editArchivStandort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvHistory)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageListe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFaLeistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFaLeistung)).EndInit();
            this.tabPageSuchen.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.editVersNrX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersNrX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editNNummerX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAHVNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editStatusX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editStatusX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editArchivNrX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editSARX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editStandortX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editStandortX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editModulX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editModulX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPersonX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            this.tabSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblFilterKandidaten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterKandidaten.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSortKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryArchive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSortKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKandidaten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRemark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdArchiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvArchiv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissButton btnAdd;
        private KiSS4.Gui.KissButton btnAddAll;
        private KiSS4.Gui.KissButton btnArchivWechsel;
        private KiSS4.Gui.KissButton btnArchivieren;
        private KiSS4.Gui.KissButton btnRemove;
        private KiSS4.Gui.KissButton btnRemoveAll;
        private KiSS4.Gui.KissButton btnSearch;
        private KiSS4.Gui.KissButton btnZurueckholen;
        private DevExpress.XtraGrid.Columns.GridColumn colArchivNr;
        private DevExpress.XtraGrid.Columns.GridColumn colArchivNr2;
        private DevExpress.XtraGrid.Columns.GridColumn colArchiviert;
        private DevExpress.XtraGrid.Columns.GridColumn colCheckIn;
        private DevExpress.XtraGrid.Columns.GridColumn colCheckInUser;
        private DevExpress.XtraGrid.Columns.GridColumn colCheckOut;
        private DevExpress.XtraGrid.Columns.GridColumn colCheckOutUser;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colModul;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colSAR;
        private DevExpress.XtraGrid.Columns.GridColumn colSortKey;
        private DevExpress.XtraGrid.Columns.GridColumn colStandort;
        private DevExpress.XtraGrid.Columns.GridColumn colStandort2;
        private DevExpress.XtraGrid.Columns.GridColumn colUser2;
        private DevExpress.XtraGrid.Columns.GridColumn colUserI1;
        private DevExpress.XtraGrid.Columns.GridColumn colUserID1;
        private DevExpress.XtraGrid.Columns.GridColumn colUserID2;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissTextEdit editAHVNr;
        private KiSS4.Gui.KissTextEdit editArchivNr;
        private KiSS4.Gui.KissTextEdit editArchivNrX;
        private KiSS4.Gui.KissLookUpEdit editArchivStandort;
        private KiSS4.Gui.KissLookUpEdit editModulX;
        private KiSS4.Gui.KissTextEdit editNNummerX;
        private KiSS4.Gui.KissTextEdit editPersonX;
        private KiSS4.Gui.KissButtonEdit editSAR;
        private KiSS4.Gui.KissButtonEdit editSARX;
        private KiSS4.Gui.KissLookUpEdit editStandortX;
        private KiSS4.Gui.KissLookUpEdit editStatusX;
        private KiSS4.Gui.KissTextEdit editVersNrX;
        private KiSS4.Gui.KissTextEdit edtAHVNummer;
        private KiSS4.Gui.KissMemoEdit edtAddress;
        private KiSS4.Gui.KissTextEdit edtNNummer;
        private KiSS4.Gui.KissTextEdit edtName;
        private KiSS4.Gui.KissMemoEdit edtRemark;
        private KiSS4.Gui.KissCalcEdit edtSortKey;
        private KiSS4.Gui.KissTextEdit edtVersNr;
        private KiSS4.Gui.KissGrid grdArchiv;
        private KiSS4.Gui.KissGrid grdFaLeistung;
        private KiSS4.Gui.KissGrid grdHistory;
        private KiSS4.Gui.KissGrid gridVerfuegbar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private KiSS4.Gui.KissGrid gridZugeteilt;
        private DevExpress.XtraGrid.Views.Grid.GridView grvArchiv;
        private DevExpress.XtraGrid.Views.Grid.GridView grvFaLeistung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvHistory;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel kissLabel13;
        private KiSS4.Gui.KissLabel kissLabel14;
        private KiSS4.Gui.KissLabel kissLabel15;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissLabel kissLabel3;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel kissLabel5;
        private KiSS4.Gui.KissLabel kissLabel6;
        private KiSS4.Gui.KissLabel kissLabel7;
        private KiSS4.Gui.KissLabel kissLabel8;
        private KiSS4.Gui.KissSearchTitel kissSearchTitel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private KiSS4.Gui.KissLabel label25;
        private KiSS4.Gui.KissLabel lblAHVNummer;
        private KiSS4.Gui.KissLabel lblAddress;
        private KiSS4.Gui.KissLabel lblNNummer;
        private KiSS4.Gui.KissLabel lblName;
        private KiSS4.Gui.KissLabel lblRemark;
        private System.Windows.Forms.Label lblRowCount;
        private KiSS4.Gui.KissLabel lblSortKey;
        private System.Windows.Forms.Label lblTitle;
        private KiSS4.Gui.KissLabel lblVersNr;
        private KiSS4.Gui.KissLabel lblVersNrX;
        private System.Windows.Forms.Panel panel1;
        private KiSS4.DB.SqlQuery qryArchive;
        private KiSS4.DB.SqlQuery qryFaLeistung;
        private KiSS4.DB.SqlQuery qryHistory;
        private KiSS4.DB.SqlQuery qryKandidaten;
        private KiSS4.DB.SqlQuery qryZugeteilt;
        private KiSS4.Gui.KissTabControlEx tabArchiv;
        private KiSS4.Gui.KissTabControlEx tabControl1;
        private SharpLibrary.WinControls.TabPageEx tabListe;
        private SharpLibrary.WinControls.TabPageEx tabPageListe;
        private SharpLibrary.WinControls.TabPageEx tabPageSuchen;
        private SharpLibrary.WinControls.TabPageEx tabSuchen;
        private Gui.KissLabel lblFilterKandidaten;
        private Gui.KissTextEdit edtFilterKandidaten;
        protected Common.CtlGotoFall ctlGotoFall;
        private DevExpress.XtraGrid.Columns.GridColumn colNEWOD;
    }
}
