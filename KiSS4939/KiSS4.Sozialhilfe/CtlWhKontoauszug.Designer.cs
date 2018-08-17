namespace KiSS4.Sozialhilfe
{
    partial class CtlWhKontoauszug
    {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlWhKontoauszug));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panTitel = new System.Windows.Forms.Panel();
            this.btnAuszugDrucken = new KiSS4.Dokument.KissDocumentButton();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.grdKbBuchungKostenart = new KiSS4.Gui.KissGrid();
            this.qryKontoauszug = new KiSS4.DB.SqlQuery();
            this.grvKbBuchungKostenart = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBuchDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBelegNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValuta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerwPeriodeVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerwPeriodeBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinnahme = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAusgabe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaldo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colDoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblKonto = new KiSS4.Gui.KissLabel();
            this.lblZeitraum = new KiSS4.Gui.KissLabel();
            this.edtZeitraum = new KiSS4.Gui.KissLookUpEdit();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblBis = new KiSS4.Gui.KissLabel();
            this.lblVon = new KiSS4.Gui.KissLabel();
            this.lblLeistungsart = new KiSS4.Gui.KissLabel();
            this.grdVerfuegbar = new KiSS4.Gui.KissGrid();
            this.qryVerfuegbar = new KiSS4.DB.SqlQuery();
            this.grvVerfugbar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAdd = new KiSS4.Gui.KissButton();
            this.btnRemove = new KiSS4.Gui.KissButton();
            this.btnAddAll = new KiSS4.Gui.KissButton();
            this.btnRemoveAll = new KiSS4.Gui.KissButton();
            this.grdZugeteilt = new KiSS4.Gui.KissGrid();
            this.qryZugeteilt = new KiSS4.DB.SqlQuery();
            this.grvZugeteilt = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtVerdichtet = new KiSS4.Gui.KissCheckEdit();
            this.lblFilter = new KiSS4.Gui.KissLabel();
            this.edtFilter = new KiSS4.Gui.KissTextEdit();
            this.lblLeer2 = new KiSS4.Gui.KissLabel();
            this.edtBetraegeAnpassen = new KiSS4.Gui.KissCheckEdit();
            this.kissTabControlEx1 = new KiSS4.Gui.KissTabControlEx();
            this.tpgBuchung = new SharpLibrary.WinControls.TabPageEx();
            this.edtValutaDatum = new KiSS4.Gui.KissDateEdit();
            this.lblValutaDatum = new KiSS4.Gui.KissLabel();
            this.lblKreditor = new KiSS4.Gui.KissLabel();
            this.lblAuszahlart = new KiSS4.Gui.KissLabel();
            this.edtBetrag100 = new KiSS4.Gui.KissCalcEdit();
            this.lblBetrag100 = new KiSS4.Gui.KissLabel();
            this.edtBelegNr = new KiSS4.Gui.KissTextEdit();
            this.edtBgSplittingCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblBgSplittingCode = new KiSS4.Gui.KissLabel();
            this.edtVerwPeriodeBis = new KiSS4.Gui.KissDateEdit();
            this.lblVerwPeriodeStrich = new KiSS4.Gui.KissLabel();
            this.edtVerwPeriodeVon = new KiSS4.Gui.KissDateEdit();
            this.lblVerwPeriode = new KiSS4.Gui.KissLabel();
            this.edtKoA = new KiSS4.Gui.KissTextEdit();
            this.edtKlient = new KiSS4.Gui.KissTextEdit();
            this.lblMandant = new KiSS4.Gui.KissLabel();
            this.lblBelegNr = new KiSS4.Gui.KissLabel();
            this.lblBuchungstext = new KiSS4.Gui.KissLabel();
            this.edtBaPersonID = new KiSS4.Gui.KissTextEdit();
            this.edtKreditor = new KiSS4.Gui.KissMemoEdit();
            this.edtAuszahlart = new KiSS4.Gui.KissTextEdit();
            this.lblKoA = new KiSS4.Gui.KissLabel();
            this.edtBuchungstext = new KiSS4.Gui.KissTextEdit();
            this.tpgDokumente = new SharpLibrary.WinControls.TabPageEx();
            this.grdDoc = new KiSS4.Gui.KissGrid();
            this.qryBgDokumente = new KiSS4.DB.SqlQuery();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStichwort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateCreation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateLastSave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtDocument = new KiSS4.Dokument.XDokument();
            this.lblDokument = new KiSS4.Gui.KissLabel();
            this.edtDokumentTyp = new KiSS4.Gui.KissLookUpEdit();
            this.lblDokumentTyp = new KiSS4.Gui.KissLabel();
            this.edtStichwort = new KiSS4.Gui.KissTextEdit();
            this.lblStichwort = new KiSS4.Gui.KissLabel();
            this.edtPersonen = new KiSS4.Gui.KissMultiCheckEdit();
            this.edtSaldovortragKiss = new KiSS4.Gui.KissCheckEdit();
            this.edtSaldovortragFremdsystem = new KiSS4.Gui.KissCheckEdit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            this.panTitel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKbBuchungKostenart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKontoauszug)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKbBuchungKostenart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZeitraum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZeitraum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVerfugbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerdichtet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetraegeAnpassen.Properties)).BeginInit();
            this.kissTabControlEx1.SuspendLayout();
            this.tpgBuchung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtValutaDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValutaDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuszahlart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag100.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag100)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSplittingCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSplittingCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgSplittingCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwPeriodeBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwPeriodeStrich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwPeriodeVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwPeriode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKoA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuszahlart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKoA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).BeginInit();
            this.tpgDokumente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgDokumente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDocument.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentTyp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokumentTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichwort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichwort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSaldovortragKiss.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSaldovortragFremdsystem.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Location = new System.Drawing.Point(5, -1);
            this.searchTitle.Size = new System.Drawing.Size(818, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSearch.Location = new System.Drawing.Point(5, 31);
            this.tabControlSearch.Size = new System.Drawing.Size(842, 496);
            this.tabControlSearch.TabIndex = 1;
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdKbBuchungKostenart);
            this.tpgListe.Size = new System.Drawing.Size(830, 458);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtSaldovortragFremdsystem);
            this.tpgSuchen.Controls.Add(this.edtSaldovortragKiss);
            this.tpgSuchen.Controls.Add(this.edtPersonen);
            this.tpgSuchen.Controls.Add(this.edtBetraegeAnpassen);
            this.tpgSuchen.Controls.Add(this.lblLeer2);
            this.tpgSuchen.Controls.Add(this.edtFilter);
            this.tpgSuchen.Controls.Add(this.lblFilter);
            this.tpgSuchen.Controls.Add(this.edtVerdichtet);
            this.tpgSuchen.Controls.Add(this.grdZugeteilt);
            this.tpgSuchen.Controls.Add(this.btnRemoveAll);
            this.tpgSuchen.Controls.Add(this.btnAddAll);
            this.tpgSuchen.Controls.Add(this.btnRemove);
            this.tpgSuchen.Controls.Add(this.btnAdd);
            this.tpgSuchen.Controls.Add(this.grdVerfuegbar);
            this.tpgSuchen.Controls.Add(this.lblLeistungsart);
            this.tpgSuchen.Controls.Add(this.lblVon);
            this.tpgSuchen.Controls.Add(this.lblBis);
            this.tpgSuchen.Controls.Add(this.edtDatumBis);
            this.tpgSuchen.Controls.Add(this.edtDatumVon);
            this.tpgSuchen.Controls.Add(this.edtZeitraum);
            this.tpgSuchen.Controls.Add(this.lblZeitraum);
            this.tpgSuchen.Controls.Add(this.lblKonto);
            this.tpgSuchen.Size = new System.Drawing.Size(830, 458);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblKonto, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZeitraum, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtZeitraum, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblLeistungsart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.grdVerfuegbar, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.btnAdd, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.btnRemove, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.btnAddAll, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.btnRemoveAll, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.grdZugeteilt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtVerdichtet, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblFilter, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFilter, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblLeer2, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBetraegeAnpassen, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtPersonen, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSaldovortragKiss, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSaldovortragFremdsystem, 0);
            // 
            // panTitel
            // 
            this.panTitel.Controls.Add(this.btnAuszugDrucken);
            this.panTitel.Controls.Add(this.picTitel);
            this.panTitel.Controls.Add(this.lblTitel);
            this.panTitel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitel.Location = new System.Drawing.Point(0, 0);
            this.panTitel.Name = "panTitel";
            this.panTitel.Size = new System.Drawing.Size(852, 30);
            this.panTitel.TabIndex = 0;
            // 
            // btnAuszugDrucken
            // 
            this.btnAuszugDrucken.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAuszugDrucken.Context = "WhKontoauszug";
            this.btnAuszugDrucken.DocumentFormat = KiSS4.Dokument.DlgNewDocument.DocumentAccessModes.Excel;
            this.btnAuszugDrucken.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuszugDrucken.Image = ((System.Drawing.Image)(resources.GetObject("btnAuszugDrucken.Image")));
            this.btnAuszugDrucken.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAuszugDrucken.Location = new System.Drawing.Point(686, 4);
            this.btnAuszugDrucken.Name = "btnAuszugDrucken";
            this.btnAuszugDrucken.Size = new System.Drawing.Size(161, 24);
            this.btnAuszugDrucken.TabIndex = 36;
            this.btnAuszugDrucken.Text = "Kontoauszug drucken";
            this.btnAuszugDrucken.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAuszugDrucken.UseVisualStyleBackColor = false;
            // 
            // picTitel
            // 
            this.picTitel.Location = new System.Drawing.Point(10, 5);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(25, 20);
            this.picTitel.TabIndex = 1;
            this.picTitel.TabStop = false;
            // 
            // lblTitel
            // 
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(35, 6);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(500, 20);
            this.lblTitel.TabIndex = 1;
            this.lblTitel.Text = "Kontoauszug";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // grdKbBuchungKostenart
            // 
            this.grdKbBuchungKostenart.DataSource = this.qryKontoauszug;
            this.grdKbBuchungKostenart.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdKbBuchungKostenart.EmbeddedNavigator.Name = "";
            this.grdKbBuchungKostenart.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdKbBuchungKostenart.Location = new System.Drawing.Point(0, 0);
            this.grdKbBuchungKostenart.MainView = this.grvKbBuchungKostenart;
            this.grdKbBuchungKostenart.Name = "grdKbBuchungKostenart";
            this.grdKbBuchungKostenart.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1});
            this.grdKbBuchungKostenart.Size = new System.Drawing.Size(830, 458);
            this.grdKbBuchungKostenart.TabIndex = 0;
            this.grdKbBuchungKostenart.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKbBuchungKostenart});
            this.grdKbBuchungKostenart.XtraPrint += new KiSS4.Gui.XtraPrintEventHandler(this.grdKbBuchungKostenart_XtraPrint);
            // 
            // qryKontoauszug
            // 
            this.qryKontoauszug.HostControl = this;
            this.qryKontoauszug.IsIdentityInsert = false;
            this.qryKontoauszug.SelectStatement = "EXEC dbo.spWhKontoauszug {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, " +
    "{11}, {12};";
            this.qryKontoauszug.AfterFill += new System.EventHandler(this.qryKontoauszug_AfterFill);
            this.qryKontoauszug.PositionChanged += new System.EventHandler(this.qryKontoauszug_PositionChanged);
            // 
            // grvKbBuchungKostenart
            // 
            this.grvKbBuchungKostenart.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvKbBuchungKostenart.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungKostenart.Appearance.Empty.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.Empty.Options.UseFont = true;
            this.grvKbBuchungKostenart.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvKbBuchungKostenart.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungKostenart.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.EvenRow.Options.UseFont = true;
            this.grvKbBuchungKostenart.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKbBuchungKostenart.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungKostenart.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKbBuchungKostenart.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKbBuchungKostenart.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKbBuchungKostenart.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKbBuchungKostenart.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungKostenart.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvKbBuchungKostenart.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKbBuchungKostenart.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKbBuchungKostenart.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbBuchungKostenart.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbBuchungKostenart.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKbBuchungKostenart.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKbBuchungKostenart.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.GroupRow.Options.UseFont = true;
            this.grvKbBuchungKostenart.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKbBuchungKostenart.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKbBuchungKostenart.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKbBuchungKostenart.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKbBuchungKostenart.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKbBuchungKostenart.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKbBuchungKostenart.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvKbBuchungKostenart.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungKostenart.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKbBuchungKostenart.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKbBuchungKostenart.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKbBuchungKostenart.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvKbBuchungKostenart.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungKostenart.Appearance.OddRow.Options.UseFont = true;
            this.grvKbBuchungKostenart.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKbBuchungKostenart.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungKostenart.Appearance.Row.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.Row.Options.UseFont = true;
            this.grvKbBuchungKostenart.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvKbBuchungKostenart.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungKostenart.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvKbBuchungKostenart.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKbBuchungKostenart.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvKbBuchungKostenart.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvKbBuchungKostenart.Appearance.VertLine.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKbBuchungKostenart.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBuchDatum,
            this.colBelegNr,
            this.colValuta,
            this.colKlient,
            this.colLA,
            this.colBuchungstext,
            this.colVerwPeriodeVon,
            this.colVerwPeriodeBis,
            this.colEinnahme,
            this.colAusgabe,
            this.colSaldo,
            this.colStatus,
            this.colDoc});
            this.grvKbBuchungKostenart.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvKbBuchungKostenart.GridControl = this.grdKbBuchungKostenart;
            this.grvKbBuchungKostenart.Name = "grvKbBuchungKostenart";
            this.grvKbBuchungKostenart.OptionsBehavior.Editable = false;
            this.grvKbBuchungKostenart.OptionsCustomization.AllowFilter = false;
            this.grvKbBuchungKostenart.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKbBuchungKostenart.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKbBuchungKostenart.OptionsNavigation.UseTabKey = false;
            this.grvKbBuchungKostenart.OptionsView.ColumnAutoWidth = false;
            this.grvKbBuchungKostenart.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvKbBuchungKostenart.OptionsView.ShowFooter = true;
            this.grvKbBuchungKostenart.OptionsView.ShowGroupPanel = false;
            this.grvKbBuchungKostenart.OptionsView.ShowIndicator = false;
            // 
            // colBuchDatum
            // 
            this.colBuchDatum.Caption = "Beleg-Datum";
            this.colBuchDatum.FieldName = "BelegDatum";
            this.colBuchDatum.Name = "colBuchDatum";
            this.colBuchDatum.Visible = true;
            this.colBuchDatum.VisibleIndex = 0;
            this.colBuchDatum.Width = 80;
            // 
            // colBelegNr
            // 
            this.colBelegNr.Caption = "Beleg-Nr.";
            this.colBelegNr.FieldName = "BelegNr";
            this.colBelegNr.Name = "colBelegNr";
            this.colBelegNr.Visible = true;
            this.colBelegNr.VisibleIndex = 1;
            this.colBelegNr.Width = 70;
            // 
            // colValuta
            // 
            this.colValuta.Caption = "Valuta";
            this.colValuta.FieldName = "ValutaDatum";
            this.colValuta.Name = "colValuta";
            // 
            // colKlient
            // 
            this.colKlient.Caption = "Klient/in";
            this.colKlient.FieldName = "Klient";
            this.colKlient.Name = "colKlient";
            this.colKlient.Visible = true;
            this.colKlient.VisibleIndex = 2;
            this.colKlient.Width = 160;
            // 
            // colLA
            // 
            this.colLA.Caption = "KoA";
            this.colLA.FieldName = "LAText";
            this.colLA.Name = "colLA";
            this.colLA.Visible = true;
            this.colLA.VisibleIndex = 3;
            this.colLA.Width = 200;
            // 
            // colBuchungstext
            // 
            this.colBuchungstext.Caption = "Buchungstext";
            this.colBuchungstext.FieldName = "Buchungstext";
            this.colBuchungstext.Name = "colBuchungstext";
            this.colBuchungstext.Visible = true;
            this.colBuchungstext.VisibleIndex = 4;
            this.colBuchungstext.Width = 170;
            // 
            // colVerwPeriodeVon
            // 
            this.colVerwPeriodeVon.Caption = "Verw. P. von";
            this.colVerwPeriodeVon.FieldName = "VerwPeriodeVon";
            this.colVerwPeriodeVon.Name = "colVerwPeriodeVon";
            this.colVerwPeriodeVon.Visible = true;
            this.colVerwPeriodeVon.VisibleIndex = 5;
            this.colVerwPeriodeVon.Width = 80;
            // 
            // colVerwPeriodeBis
            // 
            this.colVerwPeriodeBis.Caption = "Verw. P. bis";
            this.colVerwPeriodeBis.FieldName = "VerwPeriodeBis";
            this.colVerwPeriodeBis.Name = "colVerwPeriodeBis";
            this.colVerwPeriodeBis.Visible = true;
            this.colVerwPeriodeBis.VisibleIndex = 6;
            this.colVerwPeriodeBis.Width = 80;
            // 
            // colEinnahme
            // 
            this.colEinnahme.Caption = "Einnahme";
            this.colEinnahme.DisplayFormat.FormatString = "n2";
            this.colEinnahme.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colEinnahme.FieldName = "Einnahme";
            this.colEinnahme.Name = "colEinnahme";
            this.colEinnahme.SummaryItem.DisplayFormat = "{0:n2}";
            this.colEinnahme.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colEinnahme.Visible = true;
            this.colEinnahme.VisibleIndex = 8;
            // 
            // colAusgabe
            // 
            this.colAusgabe.Caption = "Auszahlung";
            this.colAusgabe.DisplayFormat.FormatString = "n2";
            this.colAusgabe.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAusgabe.FieldName = "Ausgabe";
            this.colAusgabe.Name = "colAusgabe";
            this.colAusgabe.SummaryItem.DisplayFormat = "{0:n2}";
            this.colAusgabe.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colAusgabe.Visible = true;
            this.colAusgabe.VisibleIndex = 7;
            // 
            // colSaldo
            // 
            this.colSaldo.Caption = "Saldo";
            this.colSaldo.DisplayFormat.FormatString = "n2";
            this.colSaldo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaldo.FieldName = "Saldo";
            this.colSaldo.Name = "colSaldo";
            this.colSaldo.Visible = true;
            this.colSaldo.VisibleIndex = 9;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Sta.";
            this.colStatus.ColumnEdit = this.repositoryItemImageComboBox1;
            this.colStatus.FieldName = "KbBuchungStatusCode";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 10;
            this.colStatus.Width = 31;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // colDoc
            // 
            this.colDoc.AppearanceCell.Options.UseTextOptions = true;
            this.colDoc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDoc.Caption = "Dok";
            this.colDoc.FieldName = "Doc";
            this.colDoc.Name = "colDoc";
            this.colDoc.Visible = true;
            this.colDoc.VisibleIndex = 11;
            this.colDoc.Width = 31;
            // 
            // lblKonto
            // 
            this.lblKonto.Location = new System.Drawing.Point(5, 37);
            this.lblKonto.Name = "lblKonto";
            this.lblKonto.Size = new System.Drawing.Size(91, 24);
            this.lblKonto.TabIndex = 1;
            this.lblKonto.Text = "Klient/in";
            this.lblKonto.UseCompatibleTextRendering = true;
            // 
            // lblZeitraum
            // 
            this.lblZeitraum.Location = new System.Drawing.Point(415, 37);
            this.lblZeitraum.Name = "lblZeitraum";
            this.lblZeitraum.Size = new System.Drawing.Size(93, 24);
            this.lblZeitraum.TabIndex = 4;
            this.lblZeitraum.Text = "Zeitraum";
            this.lblZeitraum.UseCompatibleTextRendering = true;
            // 
            // edtZeitraum
            // 
            this.edtZeitraum.AllowNull = false;
            this.edtZeitraum.Location = new System.Drawing.Point(514, 37);
            this.edtZeitraum.LOVName = "KbKontoZeitraum";
            this.edtZeitraum.Name = "edtZeitraum";
            this.edtZeitraum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZeitraum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZeitraum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZeitraum.Properties.Appearance.Options.UseBackColor = true;
            this.edtZeitraum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZeitraum.Properties.Appearance.Options.UseFont = true;
            this.edtZeitraum.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtZeitraum.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtZeitraum.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtZeitraum.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtZeitraum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtZeitraum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtZeitraum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZeitraum.Properties.NullText = "";
            this.edtZeitraum.Properties.ShowFooter = false;
            this.edtZeitraum.Properties.ShowHeader = false;
            this.edtZeitraum.Size = new System.Drawing.Size(241, 24);
            this.edtZeitraum.TabIndex = 5;
            this.edtZeitraum.EditValueChanged += new System.EventHandler(this.edtZeitraum_EditValueChanged);
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(514, 65);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 6;
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(655, 66);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 7;
            // 
            // lblBis
            // 
            this.lblBis.Location = new System.Drawing.Point(628, 65);
            this.lblBis.Name = "lblBis";
            this.lblBis.Size = new System.Drawing.Size(22, 24);
            this.lblBis.TabIndex = 8;
            this.lblBis.Text = "bis";
            this.lblBis.UseCompatibleTextRendering = true;
            // 
            // lblVon
            // 
            this.lblVon.Location = new System.Drawing.Point(415, 65);
            this.lblVon.Name = "lblVon";
            this.lblVon.Size = new System.Drawing.Size(68, 24);
            this.lblVon.TabIndex = 9;
            this.lblVon.Text = "Datum von";
            this.lblVon.UseCompatibleTextRendering = true;
            // 
            // lblLeistungsart
            // 
            this.lblLeistungsart.Location = new System.Drawing.Point(5, 205);
            this.lblLeistungsart.Name = "lblLeistungsart";
            this.lblLeistungsart.Size = new System.Drawing.Size(93, 24);
            this.lblLeistungsart.TabIndex = 10;
            this.lblLeistungsart.Text = "Kostenarten";
            this.lblLeistungsart.UseCompatibleTextRendering = true;
            // 
            // grdVerfuegbar
            // 
            this.grdVerfuegbar.DataSource = this.qryVerfuegbar;
            // 
            // 
            // 
            this.grdVerfuegbar.EmbeddedNavigator.Name = "";
            this.grdVerfuegbar.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdVerfuegbar.Location = new System.Drawing.Point(101, 205);
            this.grdVerfuegbar.MainView = this.grvVerfugbar;
            this.grdVerfuegbar.Name = "grdVerfuegbar";
            this.grdVerfuegbar.Size = new System.Drawing.Size(257, 168);
            this.grdVerfuegbar.TabIndex = 17;
            this.grdVerfuegbar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVerfugbar});
            this.grdVerfuegbar.DoubleClick += new System.EventHandler(this.grdVerfuegbar_DoubleClick);
            // 
            // qryVerfuegbar
            // 
            this.qryVerfuegbar.AutoApplyUserRights = false;
            this.qryVerfuegbar.BatchUpdate = true;
            this.qryVerfuegbar.CanDelete = true;
            this.qryVerfuegbar.CanInsert = true;
            this.qryVerfuegbar.DeleteQuestion = null;
            this.qryVerfuegbar.HostControl = this;
            this.qryVerfuegbar.IsIdentityInsert = false;
            this.qryVerfuegbar.SelectStatement = "SELECT KontoNr,\r\n       Name = IsNull(KontoNr + \' \', \'\') + Name\r\nFROM BgKostenart" +
    "\r\nWHERE ModulId = 3  \r\n  AND {0} = 1\r\nORDER BY KontoNr ASC";
            // 
            // grvVerfugbar
            // 
            this.grvVerfugbar.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvVerfugbar.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfugbar.Appearance.Empty.Options.UseBackColor = true;
            this.grvVerfugbar.Appearance.Empty.Options.UseFont = true;
            this.grvVerfugbar.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfugbar.Appearance.EvenRow.Options.UseFont = true;
            this.grvVerfugbar.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVerfugbar.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfugbar.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvVerfugbar.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvVerfugbar.Appearance.FocusedCell.Options.UseFont = true;
            this.grvVerfugbar.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvVerfugbar.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVerfugbar.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfugbar.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvVerfugbar.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvVerfugbar.Appearance.FocusedRow.Options.UseFont = true;
            this.grvVerfugbar.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvVerfugbar.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVerfugbar.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvVerfugbar.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvVerfugbar.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvVerfugbar.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVerfugbar.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvVerfugbar.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVerfugbar.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVerfugbar.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVerfugbar.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvVerfugbar.Appearance.GroupRow.Options.UseFont = true;
            this.grvVerfugbar.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvVerfugbar.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvVerfugbar.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvVerfugbar.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVerfugbar.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvVerfugbar.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvVerfugbar.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvVerfugbar.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvVerfugbar.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfugbar.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVerfugbar.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvVerfugbar.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvVerfugbar.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvVerfugbar.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvVerfugbar.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvVerfugbar.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfugbar.Appearance.OddRow.Options.UseFont = true;
            this.grvVerfugbar.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvVerfugbar.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfugbar.Appearance.Row.Options.UseBackColor = true;
            this.grvVerfugbar.Appearance.Row.Options.UseFont = true;
            this.grvVerfugbar.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfugbar.Appearance.SelectedRow.Options.UseFont = true;
            this.grvVerfugbar.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvVerfugbar.Appearance.VertLine.Options.UseBackColor = true;
            this.grvVerfugbar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvVerfugbar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUserText});
            this.grvVerfugbar.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvVerfugbar.GridControl = this.grdVerfuegbar;
            this.grvVerfugbar.Name = "grvVerfugbar";
            this.grvVerfugbar.OptionsBehavior.Editable = false;
            this.grvVerfugbar.OptionsCustomization.AllowFilter = false;
            this.grvVerfugbar.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvVerfugbar.OptionsNavigation.AutoFocusNewRow = true;
            this.grvVerfugbar.OptionsNavigation.UseTabKey = false;
            this.grvVerfugbar.OptionsView.ColumnAutoWidth = false;
            this.grvVerfugbar.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvVerfugbar.OptionsView.ShowGroupPanel = false;
            this.grvVerfugbar.OptionsView.ShowIndicator = false;
            // 
            // colUserText
            // 
            this.colUserText.Caption = "Verfügbare Kostenart";
            this.colUserText.FieldName = "Name";
            this.colUserText.Name = "colUserText";
            this.colUserText.Visible = true;
            this.colUserText.VisibleIndex = 0;
            this.colUserText.Width = 234;
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.IconID = 13;
            this.btnAdd.Location = new System.Drawing.Point(370, 229);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(28, 24);
            this.btnAdd.TabIndex = 18;
            this.btnAdd.UseCompatibleTextRendering = true;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.IconID = 11;
            this.btnRemove.Location = new System.Drawing.Point(370, 259);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(28, 24);
            this.btnRemove.TabIndex = 19;
            this.btnRemove.UseCompatibleTextRendering = true;
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAddAll
            // 
            this.btnAddAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAll.IconID = 14;
            this.btnAddAll.Location = new System.Drawing.Point(370, 289);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(28, 24);
            this.btnAddAll.TabIndex = 20;
            this.btnAddAll.UseCompatibleTextRendering = true;
            this.btnAddAll.UseVisualStyleBackColor = false;
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAll.IconID = 12;
            this.btnRemoveAll.Location = new System.Drawing.Point(370, 319);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(28, 24);
            this.btnRemoveAll.TabIndex = 21;
            this.btnRemoveAll.UseCompatibleTextRendering = true;
            this.btnRemoveAll.UseVisualStyleBackColor = false;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // grdZugeteilt
            // 
            this.grdZugeteilt.DataSource = this.qryZugeteilt;
            // 
            // 
            // 
            this.grdZugeteilt.EmbeddedNavigator.Name = "";
            this.grdZugeteilt.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdZugeteilt.Location = new System.Drawing.Point(415, 205);
            this.grdZugeteilt.MainView = this.grvZugeteilt;
            this.grdZugeteilt.Name = "grdZugeteilt";
            this.grdZugeteilt.Size = new System.Drawing.Size(257, 168);
            this.grdZugeteilt.TabIndex = 22;
            this.grdZugeteilt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvZugeteilt});
            this.grdZugeteilt.DoubleClick += new System.EventHandler(this.grdZugeteilt_DoubleClick);
            // 
            // qryZugeteilt
            // 
            this.qryZugeteilt.AutoApplyUserRights = false;
            this.qryZugeteilt.BatchUpdate = true;
            this.qryZugeteilt.CanDelete = true;
            this.qryZugeteilt.CanInsert = true;
            this.qryZugeteilt.HostControl = this;
            this.qryZugeteilt.IsIdentityInsert = false;
            this.qryZugeteilt.SelectStatement = "SELECT KontoNr,\r\n       Name = IsNull(KontoNr + \' \', \'\') + Name\r\nFROM BgKostenart" +
    "\r\nWHERE ModulId = 3\r\n  AND {0} = 1\r\nORDER BY KontoNr ASC";
            // 
            // grvZugeteilt
            // 
            this.grvZugeteilt.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvZugeteilt.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.Empty.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.Empty.Options.UseFont = true;
            this.grvZugeteilt.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvZugeteilt.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.EvenRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvZugeteilt.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvZugeteilt.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.FocusedCell.Options.UseFont = true;
            this.grvZugeteilt.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvZugeteilt.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvZugeteilt.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvZugeteilt.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.FocusedRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvZugeteilt.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZugeteilt.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvZugeteilt.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvZugeteilt.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZugeteilt.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZugeteilt.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvZugeteilt.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZugeteilt.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.GroupRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvZugeteilt.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvZugeteilt.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvZugeteilt.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvZugeteilt.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvZugeteilt.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvZugeteilt.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvZugeteilt.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZugeteilt.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvZugeteilt.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvZugeteilt.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.OddRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvZugeteilt.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.Row.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.Row.Options.UseFont = true;
            this.grvZugeteilt.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvZugeteilt.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvZugeteilt.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.SelectedRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvZugeteilt.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvZugeteilt.Appearance.VertLine.Options.UseBackColor = true;
            this.grvZugeteilt.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvZugeteilt.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUser});
            this.grvZugeteilt.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvZugeteilt.GridControl = this.grdZugeteilt;
            this.grvZugeteilt.Name = "grvZugeteilt";
            this.grvZugeteilt.OptionsBehavior.Editable = false;
            this.grvZugeteilt.OptionsCustomization.AllowFilter = false;
            this.grvZugeteilt.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvZugeteilt.OptionsNavigation.AutoFocusNewRow = true;
            this.grvZugeteilt.OptionsNavigation.UseTabKey = false;
            this.grvZugeteilt.OptionsView.ColumnAutoWidth = false;
            this.grvZugeteilt.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvZugeteilt.OptionsView.ShowGroupPanel = false;
            this.grvZugeteilt.OptionsView.ShowIndicator = false;
            // 
            // colUser
            // 
            this.colUser.Caption = "Zugeteilte Kostenart";
            this.colUser.FieldName = "Name";
            this.colUser.Name = "colUser";
            this.colUser.Visible = true;
            this.colUser.VisibleIndex = 0;
            this.colUser.Width = 234;
            // 
            // edtVerdichtet
            // 
            this.edtVerdichtet.EditValue = false;
            this.edtVerdichtet.Location = new System.Drawing.Point(415, 127);
            this.edtVerdichtet.Name = "edtVerdichtet";
            this.edtVerdichtet.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVerdichtet.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerdichtet.Properties.Caption = "verdichtet";
            this.edtVerdichtet.Size = new System.Drawing.Size(230, 19);
            this.edtVerdichtet.TabIndex = 23;
            // 
            // lblFilter
            // 
            this.lblFilter.Location = new System.Drawing.Point(101, 379);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(50, 24);
            this.lblFilter.TabIndex = 25;
            this.lblFilter.Text = "Filter";
            this.lblFilter.UseCompatibleTextRendering = true;
            // 
            // edtFilter
            // 
            this.edtFilter.Location = new System.Drawing.Point(142, 379);
            this.edtFilter.Name = "edtFilter";
            this.edtFilter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFilter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFilter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFilter.Properties.Appearance.Options.UseBackColor = true;
            this.edtFilter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFilter.Properties.Appearance.Options.UseFont = true;
            this.edtFilter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFilter.Size = new System.Drawing.Size(214, 24);
            this.edtFilter.TabIndex = 26;
            this.edtFilter.EditValueChanged += new System.EventHandler(this.edtFilter_EditValueChanged);
            // 
            // lblLeer2
            // 
            this.lblLeer2.Location = new System.Drawing.Point(415, 376);
            this.lblLeer2.Name = "lblLeer2";
            this.lblLeer2.Size = new System.Drawing.Size(144, 24);
            this.lblLeer2.TabIndex = 27;
            this.lblLeer2.Text = "(leer = alle Kostenarten)";
            this.lblLeer2.UseCompatibleTextRendering = true;
            // 
            // edtBetraegeAnpassen
            // 
            this.edtBetraegeAnpassen.EditValue = false;
            this.edtBetraegeAnpassen.Location = new System.Drawing.Point(415, 102);
            this.edtBetraegeAnpassen.Name = "edtBetraegeAnpassen";
            this.edtBetraegeAnpassen.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBetraegeAnpassen.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetraegeAnpassen.Properties.Caption = "Beträge an Verwendungsperiode anpassen";
            this.edtBetraegeAnpassen.Size = new System.Drawing.Size(230, 19);
            this.edtBetraegeAnpassen.TabIndex = 28;
            // 
            // kissTabControlEx1
            // 
            this.kissTabControlEx1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissTabControlEx1.Controls.Add(this.tpgBuchung);
            this.kissTabControlEx1.Controls.Add(this.tpgDokumente);
            this.kissTabControlEx1.Location = new System.Drawing.Point(3, 527);
            this.kissTabControlEx1.Name = "kissTabControlEx1";
            this.kissTabControlEx1.ShowFixedWidthTooltip = true;
            this.kissTabControlEx1.Size = new System.Drawing.Size(844, 215);
            this.kissTabControlEx1.TabIndex = 12;
            this.kissTabControlEx1.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgBuchung,
            this.tpgDokumente});
            this.kissTabControlEx1.TabsLineColor = System.Drawing.Color.Black;
            this.kissTabControlEx1.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.kissTabControlEx1.Text = "kissTabControlEx1";
            // 
            // tpgBuchung
            // 
            this.tpgBuchung.Controls.Add(this.edtValutaDatum);
            this.tpgBuchung.Controls.Add(this.lblValutaDatum);
            this.tpgBuchung.Controls.Add(this.lblKreditor);
            this.tpgBuchung.Controls.Add(this.lblAuszahlart);
            this.tpgBuchung.Controls.Add(this.edtBetrag100);
            this.tpgBuchung.Controls.Add(this.lblBetrag100);
            this.tpgBuchung.Controls.Add(this.edtBelegNr);
            this.tpgBuchung.Controls.Add(this.edtBgSplittingCode);
            this.tpgBuchung.Controls.Add(this.lblBgSplittingCode);
            this.tpgBuchung.Controls.Add(this.edtVerwPeriodeBis);
            this.tpgBuchung.Controls.Add(this.lblVerwPeriodeStrich);
            this.tpgBuchung.Controls.Add(this.edtVerwPeriodeVon);
            this.tpgBuchung.Controls.Add(this.lblVerwPeriode);
            this.tpgBuchung.Controls.Add(this.edtKoA);
            this.tpgBuchung.Controls.Add(this.edtKlient);
            this.tpgBuchung.Controls.Add(this.lblMandant);
            this.tpgBuchung.Controls.Add(this.lblBelegNr);
            this.tpgBuchung.Controls.Add(this.lblBuchungstext);
            this.tpgBuchung.Controls.Add(this.edtBaPersonID);
            this.tpgBuchung.Controls.Add(this.edtKreditor);
            this.tpgBuchung.Controls.Add(this.edtAuszahlart);
            this.tpgBuchung.Controls.Add(this.lblKoA);
            this.tpgBuchung.Controls.Add(this.edtBuchungstext);
            this.tpgBuchung.Location = new System.Drawing.Point(6, 6);
            this.tpgBuchung.Name = "tpgBuchung";
            this.tpgBuchung.Size = new System.Drawing.Size(832, 177);
            this.tpgBuchung.TabIndex = 0;
            this.tpgBuchung.Title = "Buchung";
            // 
            // edtValutaDatum
            // 
            this.edtValutaDatum.DataMember = "ValutaDatum";
            this.edtValutaDatum.DataSource = this.qryKontoauszug;
            this.edtValutaDatum.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtValutaDatum.EditValue = null;
            this.edtValutaDatum.Location = new System.Drawing.Point(93, 88);
            this.edtValutaDatum.Name = "edtValutaDatum";
            this.edtValutaDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtValutaDatum.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtValutaDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtValutaDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtValutaDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtValutaDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtValutaDatum.Properties.Appearance.Options.UseFont = true;
            this.edtValutaDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtValutaDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtValutaDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtValutaDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtValutaDatum.Properties.ReadOnly = true;
            this.edtValutaDatum.Properties.ShowToday = false;
            this.edtValutaDatum.Size = new System.Drawing.Size(90, 24);
            this.edtValutaDatum.TabIndex = 417;
            // 
            // lblValutaDatum
            // 
            this.lblValutaDatum.Location = new System.Drawing.Point(5, 88);
            this.lblValutaDatum.Name = "lblValutaDatum";
            this.lblValutaDatum.Size = new System.Drawing.Size(86, 24);
            this.lblValutaDatum.TabIndex = 416;
            this.lblValutaDatum.Text = "Valuta";
            this.lblValutaDatum.UseCompatibleTextRendering = true;
            // 
            // lblKreditor
            // 
            this.lblKreditor.Location = new System.Drawing.Point(473, 59);
            this.lblKreditor.Name = "lblKreditor";
            this.lblKreditor.Size = new System.Drawing.Size(49, 24);
            this.lblKreditor.TabIndex = 415;
            this.lblKreditor.Text = "Kreditor";
            this.lblKreditor.UseCompatibleTextRendering = true;
            // 
            // lblAuszahlart
            // 
            this.lblAuszahlart.Location = new System.Drawing.Point(473, 35);
            this.lblAuszahlart.Name = "lblAuszahlart";
            this.lblAuszahlart.Size = new System.Drawing.Size(73, 24);
            this.lblAuszahlart.TabIndex = 414;
            this.lblAuszahlart.Text = "Auszahlart";
            this.lblAuszahlart.UseCompatibleTextRendering = true;
            // 
            // edtBetrag100
            // 
            this.edtBetrag100.DataMember = "Betrag100";
            this.edtBetrag100.DataSource = this.qryKontoauszug;
            this.edtBetrag100.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBetrag100.Location = new System.Drawing.Point(552, 5);
            this.edtBetrag100.Name = "edtBetrag100";
            this.edtBetrag100.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBetrag100.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBetrag100.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetrag100.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetrag100.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetrag100.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetrag100.Properties.Appearance.Options.UseFont = true;
            this.edtBetrag100.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetrag100.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetrag100.Properties.DisplayFormat.FormatString = "n2";
            this.edtBetrag100.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag100.Properties.ReadOnly = true;
            this.edtBetrag100.Size = new System.Drawing.Size(100, 24);
            this.edtBetrag100.TabIndex = 413;
            // 
            // lblBetrag100
            // 
            this.lblBetrag100.Location = new System.Drawing.Point(473, 5);
            this.lblBetrag100.Name = "lblBetrag100";
            this.lblBetrag100.Size = new System.Drawing.Size(73, 24);
            this.lblBetrag100.TabIndex = 412;
            this.lblBetrag100.Text = "Betrag 100%";
            this.lblBetrag100.UseCompatibleTextRendering = true;
            // 
            // edtBelegNr
            // 
            this.edtBelegNr.DataMember = "BelegNr";
            this.edtBelegNr.DataSource = this.qryKontoauszug;
            this.edtBelegNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBelegNr.Location = new System.Drawing.Point(354, 88);
            this.edtBelegNr.Name = "edtBelegNr";
            this.edtBelegNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBelegNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBelegNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBelegNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtBelegNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBelegNr.Properties.Appearance.Options.UseFont = true;
            this.edtBelegNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBelegNr.Properties.ReadOnly = true;
            this.edtBelegNr.Size = new System.Drawing.Size(113, 24);
            this.edtBelegNr.TabIndex = 408;
            // 
            // edtBgSplittingCode
            // 
            this.edtBgSplittingCode.AllowNull = false;
            this.edtBgSplittingCode.DataMember = "BgSplittingArtCode";
            this.edtBgSplittingCode.DataSource = this.qryKontoauszug;
            this.edtBgSplittingCode.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBgSplittingCode.Location = new System.Drawing.Point(354, 118);
            this.edtBgSplittingCode.LOVName = "BgSplittingArt";
            this.edtBgSplittingCode.Name = "edtBgSplittingCode";
            this.edtBgSplittingCode.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBgSplittingCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgSplittingCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgSplittingCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgSplittingCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgSplittingCode.Properties.Appearance.Options.UseFont = true;
            this.edtBgSplittingCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgSplittingCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgSplittingCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgSplittingCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgSplittingCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBgSplittingCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgSplittingCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtBgSplittingCode.Properties.DisplayMember = "Text";
            this.edtBgSplittingCode.Properties.NullText = "";
            this.edtBgSplittingCode.Properties.ReadOnly = true;
            this.edtBgSplittingCode.Properties.ShowFooter = false;
            this.edtBgSplittingCode.Properties.ShowHeader = false;
            this.edtBgSplittingCode.Properties.ValueMember = "Code";
            this.edtBgSplittingCode.Size = new System.Drawing.Size(113, 24);
            this.edtBgSplittingCode.TabIndex = 407;
            this.edtBgSplittingCode.TabStop = false;
            // 
            // lblBgSplittingCode
            // 
            this.lblBgSplittingCode.Location = new System.Drawing.Point(300, 118);
            this.lblBgSplittingCode.Name = "lblBgSplittingCode";
            this.lblBgSplittingCode.Size = new System.Drawing.Size(49, 24);
            this.lblBgSplittingCode.TabIndex = 406;
            this.lblBgSplittingCode.Text = "Splitting";
            this.lblBgSplittingCode.UseCompatibleTextRendering = true;
            // 
            // edtVerwPeriodeBis
            // 
            this.edtVerwPeriodeBis.DataMember = "VerwPeriodeBis";
            this.edtVerwPeriodeBis.DataSource = this.qryKontoauszug;
            this.edtVerwPeriodeBis.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVerwPeriodeBis.EditValue = null;
            this.edtVerwPeriodeBis.Location = new System.Drawing.Point(199, 118);
            this.edtVerwPeriodeBis.Name = "edtVerwPeriodeBis";
            this.edtVerwPeriodeBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVerwPeriodeBis.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVerwPeriodeBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVerwPeriodeBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVerwPeriodeBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerwPeriodeBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVerwPeriodeBis.Properties.Appearance.Options.UseFont = true;
            this.edtVerwPeriodeBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtVerwPeriodeBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVerwPeriodeBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtVerwPeriodeBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVerwPeriodeBis.Properties.ReadOnly = true;
            this.edtVerwPeriodeBis.Properties.ShowToday = false;
            this.edtVerwPeriodeBis.Size = new System.Drawing.Size(90, 24);
            this.edtVerwPeriodeBis.TabIndex = 405;
            // 
            // lblVerwPeriodeStrich
            // 
            this.lblVerwPeriodeStrich.Location = new System.Drawing.Point(188, 118);
            this.lblVerwPeriodeStrich.Name = "lblVerwPeriodeStrich";
            this.lblVerwPeriodeStrich.Size = new System.Drawing.Size(7, 24);
            this.lblVerwPeriodeStrich.TabIndex = 404;
            this.lblVerwPeriodeStrich.Text = "-";
            this.lblVerwPeriodeStrich.UseCompatibleTextRendering = true;
            // 
            // edtVerwPeriodeVon
            // 
            this.edtVerwPeriodeVon.DataMember = "VerwPeriodeVon";
            this.edtVerwPeriodeVon.DataSource = this.qryKontoauszug;
            this.edtVerwPeriodeVon.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVerwPeriodeVon.EditValue = null;
            this.edtVerwPeriodeVon.Location = new System.Drawing.Point(93, 118);
            this.edtVerwPeriodeVon.Name = "edtVerwPeriodeVon";
            this.edtVerwPeriodeVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVerwPeriodeVon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVerwPeriodeVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVerwPeriodeVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVerwPeriodeVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerwPeriodeVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVerwPeriodeVon.Properties.Appearance.Options.UseFont = true;
            this.edtVerwPeriodeVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtVerwPeriodeVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVerwPeriodeVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtVerwPeriodeVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVerwPeriodeVon.Properties.ReadOnly = true;
            this.edtVerwPeriodeVon.Properties.ShowToday = false;
            this.edtVerwPeriodeVon.Size = new System.Drawing.Size(90, 24);
            this.edtVerwPeriodeVon.TabIndex = 403;
            // 
            // lblVerwPeriode
            // 
            this.lblVerwPeriode.Location = new System.Drawing.Point(5, 118);
            this.lblVerwPeriode.Name = "lblVerwPeriode";
            this.lblVerwPeriode.Size = new System.Drawing.Size(86, 24);
            this.lblVerwPeriode.TabIndex = 402;
            this.lblVerwPeriode.Text = "Verwendungsp.";
            this.lblVerwPeriode.UseCompatibleTextRendering = true;
            // 
            // edtKoA
            // 
            this.edtKoA.DataMember = "LAText";
            this.edtKoA.DataSource = this.qryKontoauszug;
            this.edtKoA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKoA.Location = new System.Drawing.Point(93, 35);
            this.edtKoA.Name = "edtKoA";
            this.edtKoA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKoA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKoA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKoA.Properties.Appearance.Options.UseBackColor = true;
            this.edtKoA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKoA.Properties.Appearance.Options.UseFont = true;
            this.edtKoA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKoA.Properties.ReadOnly = true;
            this.edtKoA.Size = new System.Drawing.Size(374, 24);
            this.edtKoA.TabIndex = 401;
            // 
            // edtKlient
            // 
            this.edtKlient.DataMember = "Klient";
            this.edtKlient.DataSource = this.qryKontoauszug;
            this.edtKlient.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKlient.Location = new System.Drawing.Point(93, 5);
            this.edtKlient.Name = "edtKlient";
            this.edtKlient.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKlient.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKlient.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKlient.Properties.Appearance.Options.UseBackColor = true;
            this.edtKlient.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKlient.Properties.Appearance.Options.UseFont = true;
            this.edtKlient.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKlient.Properties.ReadOnly = true;
            this.edtKlient.Size = new System.Drawing.Size(305, 24);
            this.edtKlient.TabIndex = 394;
            // 
            // lblMandant
            // 
            this.lblMandant.Location = new System.Drawing.Point(5, 5);
            this.lblMandant.Name = "lblMandant";
            this.lblMandant.Size = new System.Drawing.Size(52, 24);
            this.lblMandant.TabIndex = 383;
            this.lblMandant.Text = "Klient/in";
            this.lblMandant.UseCompatibleTextRendering = true;
            // 
            // lblBelegNr
            // 
            this.lblBelegNr.Location = new System.Drawing.Point(299, 88);
            this.lblBelegNr.Name = "lblBelegNr";
            this.lblBelegNr.Size = new System.Drawing.Size(50, 24);
            this.lblBelegNr.TabIndex = 61;
            this.lblBelegNr.Text = "Beleg-Nr.";
            this.lblBelegNr.UseCompatibleTextRendering = true;
            // 
            // lblBuchungstext
            // 
            this.lblBuchungstext.Location = new System.Drawing.Point(5, 58);
            this.lblBuchungstext.Name = "lblBuchungstext";
            this.lblBuchungstext.Size = new System.Drawing.Size(75, 24);
            this.lblBuchungstext.TabIndex = 53;
            this.lblBuchungstext.Text = "Buchungstext";
            this.lblBuchungstext.UseCompatibleTextRendering = true;
            // 
            // edtBaPersonID
            // 
            this.edtBaPersonID.DataMember = "BaPersonID";
            this.edtBaPersonID.DataSource = this.qryKontoauszug;
            this.edtBaPersonID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBaPersonID.Location = new System.Drawing.Point(397, 5);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBaPersonID.Properties.Name = "editMandantNr.Properties";
            this.edtBaPersonID.Properties.ReadOnly = true;
            this.edtBaPersonID.Size = new System.Drawing.Size(70, 24);
            this.edtBaPersonID.TabIndex = 10;
            // 
            // edtKreditor
            // 
            this.edtKreditor.DataMember = "KreditorDebitor";
            this.edtKreditor.DataSource = this.qryKontoauszug;
            this.edtKreditor.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKreditor.Location = new System.Drawing.Point(552, 58);
            this.edtKreditor.Name = "edtKreditor";
            this.edtKreditor.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKreditor.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKreditor.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKreditor.Properties.Appearance.Options.UseBackColor = true;
            this.edtKreditor.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKreditor.Properties.Appearance.Options.UseFont = true;
            this.edtKreditor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKreditor.Properties.ReadOnly = true;
            this.edtKreditor.Size = new System.Drawing.Size(272, 114);
            this.edtKreditor.TabIndex = 9;
            // 
            // edtAuszahlart
            // 
            this.edtAuszahlart.DataMember = "Auszahlart";
            this.edtAuszahlart.DataSource = this.qryKontoauszug;
            this.edtAuszahlart.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAuszahlart.Location = new System.Drawing.Point(552, 35);
            this.edtAuszahlart.Name = "edtAuszahlart";
            this.edtAuszahlart.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAuszahlart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAuszahlart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuszahlart.Properties.Appearance.Options.UseBackColor = true;
            this.edtAuszahlart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAuszahlart.Properties.Appearance.Options.UseFont = true;
            this.edtAuszahlart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAuszahlart.Properties.ReadOnly = true;
            this.edtAuszahlart.Size = new System.Drawing.Size(272, 24);
            this.edtAuszahlart.TabIndex = 8;
            // 
            // lblKoA
            // 
            this.lblKoA.Location = new System.Drawing.Point(5, 35);
            this.lblKoA.Name = "lblKoA";
            this.lblKoA.Size = new System.Drawing.Size(76, 24);
            this.lblKoA.TabIndex = 4;
            this.lblKoA.Text = "KoA";
            this.lblKoA.UseCompatibleTextRendering = true;
            // 
            // edtBuchungstext
            // 
            this.edtBuchungstext.DataMember = "Buchungstext";
            this.edtBuchungstext.DataSource = this.qryKontoauszug;
            this.edtBuchungstext.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBuchungstext.Location = new System.Drawing.Point(93, 58);
            this.edtBuchungstext.Name = "edtBuchungstext";
            this.edtBuchungstext.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBuchungstext.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchungstext.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchungstext.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchungstext.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchungstext.Properties.Appearance.Options.UseFont = true;
            this.edtBuchungstext.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBuchungstext.Properties.ReadOnly = true;
            this.edtBuchungstext.Size = new System.Drawing.Size(374, 24);
            this.edtBuchungstext.TabIndex = 2;
            // 
            // tpgDokumente
            // 
            this.tpgDokumente.Controls.Add(this.grdDoc);
            this.tpgDokumente.Controls.Add(this.edtDocument);
            this.tpgDokumente.Controls.Add(this.lblDokument);
            this.tpgDokumente.Controls.Add(this.edtDokumentTyp);
            this.tpgDokumente.Controls.Add(this.lblDokumentTyp);
            this.tpgDokumente.Controls.Add(this.edtStichwort);
            this.tpgDokumente.Controls.Add(this.lblStichwort);
            this.tpgDokumente.Location = new System.Drawing.Point(6, 6);
            this.tpgDokumente.Name = "tpgDokumente";
            this.tpgDokumente.Size = new System.Drawing.Size(832, 177);
            this.tpgDokumente.TabIndex = 1;
            this.tpgDokumente.Title = "Dokumente";
            // 
            // grdDoc
            // 
            this.grdDoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdDoc.DataSource = this.qryBgDokumente;
            // 
            // 
            // 
            this.grdDoc.EmbeddedNavigator.Name = "";
            this.grdDoc.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdDoc.Location = new System.Drawing.Point(0, 0);
            this.grdDoc.MainView = this.gridView1;
            this.grdDoc.Name = "grdDoc";
            this.grdDoc.Size = new System.Drawing.Size(773, 145);
            this.grdDoc.TabIndex = 20;
            this.grdDoc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // qryBgDokumente
            // 
            this.qryBgDokumente.HostControl = this;
            this.qryBgDokumente.IsIdentityInsert = false;
            this.qryBgDokumente.SelectStatement = resources.GetString("qryBgDokumente.SelectStatement");
            this.qryBgDokumente.TableName = "BgDokument";
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
            this.gridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseBorderColor = true;
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
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTyp,
            this.colStichwort,
            this.colDateCreation,
            this.colDateLastSave});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.grdDoc;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // colTyp
            // 
            this.colTyp.Caption = "Typ";
            this.colTyp.FieldName = "BgDokumentTypCode";
            this.colTyp.Name = "colTyp";
            this.colTyp.Visible = true;
            this.colTyp.VisibleIndex = 0;
            this.colTyp.Width = 123;
            // 
            // colStichwort
            // 
            this.colStichwort.Caption = "Stichwort";
            this.colStichwort.FieldName = "Stichwort";
            this.colStichwort.Name = "colStichwort";
            this.colStichwort.Visible = true;
            this.colStichwort.VisibleIndex = 1;
            this.colStichwort.Width = 382;
            // 
            // colDateCreation
            // 
            this.colDateCreation.Caption = "Erstellungsdatum";
            this.colDateCreation.FieldName = "DateCreation";
            this.colDateCreation.Name = "colDateCreation";
            this.colDateCreation.Visible = true;
            this.colDateCreation.VisibleIndex = 2;
            this.colDateCreation.Width = 110;
            // 
            // colDateLastSave
            // 
            this.colDateLastSave.Caption = "Letzte Speicherung";
            this.colDateLastSave.FieldName = "DateLastSave";
            this.colDateLastSave.Name = "colDateLastSave";
            this.colDateLastSave.Visible = true;
            this.colDateLastSave.VisibleIndex = 3;
            this.colDateLastSave.Width = 121;
            // 
            // edtDocument
            // 
            this.edtDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDocument.Context = null;
            this.edtDocument.DataMember = "DocumentID";
            this.edtDocument.DataSource = this.qryBgDokumente;
            this.edtDocument.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtDocument.Location = new System.Drawing.Point(644, 151);
            this.edtDocument.Name = "edtDocument";
            this.edtDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDocument.Properties.Appearance.Options.UseBackColor = true;
            this.edtDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDocument.Properties.Appearance.Options.UseFont = true;
            this.edtDocument.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "Dokument öffnen")});
            this.edtDocument.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDocument.Properties.ReadOnly = true;
            this.edtDocument.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtDocument.Size = new System.Drawing.Size(120, 24);
            this.edtDocument.TabIndex = 19;
            // 
            // lblDokument
            // 
            this.lblDokument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDokument.Location = new System.Drawing.Point(578, 151);
            this.lblDokument.Name = "lblDokument";
            this.lblDokument.Size = new System.Drawing.Size(59, 24);
            this.lblDokument.TabIndex = 18;
            this.lblDokument.Text = "Dokument";
            this.lblDokument.UseCompatibleTextRendering = true;
            // 
            // edtDokumentTyp
            // 
            this.edtDokumentTyp.AllowNull = false;
            this.edtDokumentTyp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDokumentTyp.DataMember = "BgDokumentTypCode";
            this.edtDokumentTyp.DataSource = this.qryBgDokumente;
            this.edtDokumentTyp.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtDokumentTyp.Location = new System.Drawing.Point(39, 151);
            this.edtDokumentTyp.LOVName = "BgDokumentTyp";
            this.edtDokumentTyp.Name = "edtDokumentTyp";
            this.edtDokumentTyp.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtDokumentTyp.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDokumentTyp.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDokumentTyp.Properties.Appearance.Options.UseBackColor = true;
            this.edtDokumentTyp.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDokumentTyp.Properties.Appearance.Options.UseFont = true;
            this.edtDokumentTyp.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtDokumentTyp.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtDokumentTyp.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtDokumentTyp.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtDokumentTyp.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtDokumentTyp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtDokumentTyp.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDokumentTyp.Properties.NullText = "";
            this.edtDokumentTyp.Properties.ReadOnly = true;
            this.edtDokumentTyp.Properties.ShowFooter = false;
            this.edtDokumentTyp.Properties.ShowHeader = false;
            this.edtDokumentTyp.Size = new System.Drawing.Size(134, 24);
            this.edtDokumentTyp.TabIndex = 17;
            // 
            // lblDokumentTyp
            // 
            this.lblDokumentTyp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDokumentTyp.Location = new System.Drawing.Point(5, 151);
            this.lblDokumentTyp.Name = "lblDokumentTyp";
            this.lblDokumentTyp.Size = new System.Drawing.Size(28, 24);
            this.lblDokumentTyp.TabIndex = 16;
            this.lblDokumentTyp.Text = "Typ";
            this.lblDokumentTyp.UseCompatibleTextRendering = true;
            // 
            // edtStichwort
            // 
            this.edtStichwort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtStichwort.DataMember = "Stichwort";
            this.edtStichwort.DataSource = this.qryBgDokumente;
            this.edtStichwort.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtStichwort.Location = new System.Drawing.Point(240, 151);
            this.edtStichwort.Name = "edtStichwort";
            this.edtStichwort.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtStichwort.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStichwort.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStichwort.Properties.Appearance.Options.UseBackColor = true;
            this.edtStichwort.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStichwort.Properties.Appearance.Options.UseFont = true;
            this.edtStichwort.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStichwort.Properties.ReadOnly = true;
            this.edtStichwort.Size = new System.Drawing.Size(326, 24);
            this.edtStichwort.TabIndex = 15;
            // 
            // lblStichwort
            // 
            this.lblStichwort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStichwort.Location = new System.Drawing.Point(179, 151);
            this.lblStichwort.Name = "lblStichwort";
            this.lblStichwort.Size = new System.Drawing.Size(66, 24);
            this.lblStichwort.TabIndex = 14;
            this.lblStichwort.Text = "Stichwort";
            this.lblStichwort.UseCompatibleTextRendering = true;
            // 
            // edtPersonen
            // 
            this.edtPersonen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPersonen.Location = new System.Drawing.Point(101, 37);
            this.edtPersonen.Name = "edtPersonen";
            this.edtPersonen.Size = new System.Drawing.Size(257, 115);
            this.edtPersonen.TabIndex = 31;
            this.edtPersonen.TextCheckbox = "Ganze UE";
            // 
            // edtSaldovortragKiss
            // 
            this.edtSaldovortragKiss.EditValue = false;
            this.edtSaldovortragKiss.Location = new System.Drawing.Point(415, 152);
            this.edtSaldovortragKiss.Name = "edtSaldovortragKiss";
            this.edtSaldovortragKiss.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSaldovortragKiss.Properties.Appearance.Options.UseBackColor = true;
            this.edtSaldovortragKiss.Properties.Caption = "Saldovortrag aus KiSS";
            this.edtSaldovortragKiss.Size = new System.Drawing.Size(230, 19);
            this.edtSaldovortragKiss.TabIndex = 32;
            // 
            // edtSaldovortragFremdsystem
            // 
            this.edtSaldovortragFremdsystem.EditValue = false;
            this.edtSaldovortragFremdsystem.Location = new System.Drawing.Point(415, 177);
            this.edtSaldovortragFremdsystem.Name = "edtSaldovortragFremdsystem";
            this.edtSaldovortragFremdsystem.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSaldovortragFremdsystem.Properties.Appearance.Options.UseBackColor = true;
            this.edtSaldovortragFremdsystem.Properties.Caption = "Saldovortrag aus Fremdsystem";
            this.edtSaldovortragFremdsystem.Size = new System.Drawing.Size(230, 19);
            this.edtSaldovortragFremdsystem.TabIndex = 33;
            // 
            // CtlWhKontoauszug
            // 
            this.ActiveSQLQuery = this.qryKontoauszug;
            this.Controls.Add(this.kissTabControlEx1);
            this.Controls.Add(this.panTitel);
            this.Name = "CtlWhKontoauszug";
            this.Size = new System.Drawing.Size(852, 742);
            this.Load += new System.EventHandler(this.CtlWhKontoauszug_Load);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.panTitel, 0);
            this.Controls.SetChildIndex(this.kissTabControlEx1, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            this.panTitel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKbBuchungKostenart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKontoauszug)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKbBuchungKostenart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZeitraum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZeitraum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVerfugbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerdichtet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetraegeAnpassen.Properties)).EndInit();
            this.kissTabControlEx1.ResumeLayout(false);
            this.tpgBuchung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtValutaDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValutaDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuszahlart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag100.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag100)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSplittingCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSplittingCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgSplittingCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwPeriodeBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwPeriodeStrich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwPeriodeVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwPeriode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKoA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuszahlart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKoA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).EndInit();
            this.tpgDokumente.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgDokumente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDocument.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentTyp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokumentTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichwort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichwort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSaldovortragKiss.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSaldovortragFremdsystem.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissGrid grdKbBuchungKostenart;
        private KiSS4.DB.SqlQuery qryKontoauszug;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissTabControlEx kissTabControlEx1;
        private SharpLibrary.WinControls.TabPageEx tpgDokumente;
        private KiSS4.Gui.KissGrid grdDoc;
        private KiSS4.DB.SqlQuery qryBgDokumente;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colStichwort;
        private DevExpress.XtraGrid.Columns.GridColumn colDateCreation;
        private DevExpress.XtraGrid.Columns.GridColumn colDateLastSave;
        private KiSS4.Dokument.XDokument edtDocument;
        private KiSS4.Gui.KissLabel lblDokument;
        private KiSS4.Gui.KissLookUpEdit edtDokumentTyp;
        private KiSS4.Gui.KissLabel lblDokumentTyp;
        private KiSS4.Gui.KissTextEdit edtStichwort;
        private KiSS4.Gui.KissLabel lblStichwort;
        private SharpLibrary.WinControls.TabPageEx tpgBuchung;
        private KiSS4.Gui.KissDateEdit edtValutaDatum;
        private KiSS4.Gui.KissLabel lblValutaDatum;
        private KiSS4.Gui.KissLabel lblKreditor;
        private KiSS4.Gui.KissLabel lblAuszahlart;
        private KiSS4.Gui.KissCalcEdit edtBetrag100;
        private KiSS4.Gui.KissLabel lblBetrag100;
        private KiSS4.Gui.KissTextEdit edtBelegNr;
        private KiSS4.Gui.KissLookUpEdit edtBgSplittingCode;
        private KiSS4.Gui.KissLabel lblBgSplittingCode;
        private KiSS4.Gui.KissDateEdit edtVerwPeriodeBis;
        private KiSS4.Gui.KissLabel lblVerwPeriodeStrich;
        private KiSS4.Gui.KissDateEdit edtVerwPeriodeVon;
        private KiSS4.Gui.KissLabel lblVerwPeriode;
        private KiSS4.Gui.KissTextEdit edtKoA;
        private KiSS4.Gui.KissTextEdit edtKlient;
        private KiSS4.Gui.KissLabel lblMandant;
        private KiSS4.Gui.KissLabel lblBelegNr;
        private KiSS4.Gui.KissLabel lblBuchungstext;
        private KiSS4.Gui.KissTextEdit edtBaPersonID;
        private KiSS4.Gui.KissMemoEdit edtKreditor;
        private KiSS4.Gui.KissTextEdit edtAuszahlart;
        private KiSS4.Gui.KissLabel lblKoA;
        private KiSS4.Gui.KissTextEdit edtBuchungstext;
        private System.Windows.Forms.Panel panTitel;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.Gui.KissLabel lblTitel;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKbBuchungKostenart;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colBelegNr;
        private DevExpress.XtraGrid.Columns.GridColumn colValuta;
        private DevExpress.XtraGrid.Columns.GridColumn colKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colLA;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungstext;
        private DevExpress.XtraGrid.Columns.GridColumn colVerwPeriodeVon;
        private DevExpress.XtraGrid.Columns.GridColumn colVerwPeriodeBis;
        private DevExpress.XtraGrid.Columns.GridColumn colEinnahme;
        private DevExpress.XtraGrid.Columns.GridColumn colAusgabe;
        private DevExpress.XtraGrid.Columns.GridColumn colSaldo;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraGrid.Columns.GridColumn colDoc;
        private KiSS4.Gui.KissCheckEdit edtBetraegeAnpassen;
        private KiSS4.Gui.KissLabel lblLeer2;
        private KiSS4.Gui.KissTextEdit edtFilter;
        private KiSS4.Gui.KissLabel lblFilter;
        private KiSS4.Gui.KissCheckEdit edtVerdichtet;
        private KiSS4.Gui.KissGrid grdZugeteilt;
        private KiSS4.DB.SqlQuery qryZugeteilt;
        private DevExpress.XtraGrid.Views.Grid.GridView grvZugeteilt;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
        private KiSS4.Gui.KissButton btnRemoveAll;
        private KiSS4.Gui.KissButton btnAddAll;
        private KiSS4.Gui.KissButton btnRemove;
        private KiSS4.Gui.KissButton btnAdd;
        private KiSS4.Gui.KissGrid grdVerfuegbar;
        private KiSS4.DB.SqlQuery qryVerfuegbar;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVerfugbar;
        private DevExpress.XtraGrid.Columns.GridColumn colUserText;
        private KiSS4.Gui.KissLabel lblLeistungsart;
        private KiSS4.Gui.KissLabel lblVon;
        private KiSS4.Gui.KissLabel lblBis;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissLookUpEdit edtZeitraum;
        private KiSS4.Gui.KissLabel lblZeitraum;
        private KiSS4.Gui.KissMultiCheckEdit edtPersonen;
        private KiSS4.Gui.KissLabel lblKonto;
        private Gui.KissCheckEdit edtSaldovortragFremdsystem;
        private Gui.KissCheckEdit edtSaldovortragKiss;
        private Dokument.KissDocumentButton btnAuszugDrucken;
    }
}
