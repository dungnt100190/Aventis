namespace KiSS4.Inkasso
{
    partial class CtlIkBetreibungenVerlustscheine
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlIkBetreibungenVerlustscheine));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picTitle = new System.Windows.Forms.PictureBox();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.calcSummeAktiveVerlustscheine = new KiSS4.Gui.KissCalcEdit();
            this.btnNeuerVerlustschein = new KiSS4.Gui.KissButton();
            this.btnNeueBetreibung = new KiSS4.Gui.KissButton();
            this.btnShowVerlustscheine = new KiSS4.Gui.KissButton();
            this.btnShowBoth = new KiSS4.Gui.KissButton();
            this.buttonShowBetreibungen = new KiSS4.Gui.KissButton();
            this.btnClipVerlustscheine = new KiSS4.Gui.KissButton();
            this.btnClipBetreibungen = new KiSS4.Gui.KissButton();
            this.cboAuswahl = new KiSS4.Gui.KissLookUpEdit();
            this.grdBetreibungen = new KiSS4.Gui.KissGrid();
            this.qryBetreibung = new KiSS4.DB.SqlQuery();
            this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colBetreibungAm = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colBetreibungFortsetzungAm = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colBetreibungNummer = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colBetreibungStatus = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colBetreibungBetrag = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colBetreibungVon = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colBetreibungBis = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colBetreibungGlaeubiger = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colVerlustscheinAm = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colVerlustscheinTotal = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colVerlustscheinKosten = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colVerlustscheinZins = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colVerlustscheinNummer = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colVerlustscheinAmt = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colVerlustscheinStatus = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colVerlustscheinTyp = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.xTabControl1 = new KiSS4.Gui.KissTabControlEx();
            this.tabBemerkungen = new SharpLibrary.WinControls.TabPageEx();
            this.panelBemerkungen = new System.Windows.Forms.Panel();
            this.txtBemerkungen = new KiSS4.Gui.KissMemoEdit();
            this.tabZahlungen = new SharpLibrary.WinControls.TabPageEx();
            this.panelZahlungen = new System.Windows.Forms.Panel();
            this.grdZahlungen = new KiSS4.Gui.KissGrid();
            this.qryZahlungen = new KiSS4.DB.SqlQuery();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDateZahlungseingang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBemerkungen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTeilbetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.kissLabel17 = new KiSS4.Gui.KissLabel();
            this.kissLabel16 = new KiSS4.Gui.KissLabel();
            this.calcSaldoVerlustschein = new KiSS4.Gui.KissCalcEdit();
            this.calcSaldoBetreibung = new KiSS4.Gui.KissCalcEdit();
            this.btnNeueZahlung = new KiSS4.Gui.KissButton();
            this.tabVerlustschein = new SharpLibrary.WinControls.TabPageEx();
            this.panelVerlustschein = new System.Windows.Forms.Panel();
            this.kissLabel18 = new KiSS4.Gui.KissLabel();
            this.kissLabel24 = new KiSS4.Gui.KissLabel();
            this.kissLabel15 = new KiSS4.Gui.KissLabel();
            this.kissLabel14 = new KiSS4.Gui.KissLabel();
            this.kissLabel22 = new KiSS4.Gui.KissLabel();
            this.kissLabel19 = new KiSS4.Gui.KissLabel();
            this.kissLabel20 = new KiSS4.Gui.KissLabel();
            this.txtVerlustscheinAmt = new KiSS4.Gui.KissMemoEdit();
            this.calcVerlustscheinZins = new KiSS4.Gui.KissCalcEdit();
            this.calcVerlustscheinKosten = new KiSS4.Gui.KissCalcEdit();
            this.calcVerlustscheinBetrag = new KiSS4.Gui.KissCalcEdit();
            this.txtVerlustscheinNummer = new KiSS4.Gui.KissTextEdit();
            this.dateVerlustscheinVerjaehrung = new KiSS4.Gui.KissDateEdit();
            this.dateVerlustscheinAm = new KiSS4.Gui.KissDateEdit();
            this.cboVerlustscheinTyp = new KiSS4.Gui.KissLookUpEdit();
            this.cboVerlustscheinStatus = new KiSS4.Gui.KissLookUpEdit();
            this.kissLabel23 = new KiSS4.Gui.KissLabel();
            this.kissLabel21 = new KiSS4.Gui.KissLabel();
            this.tabBetreibung = new SharpLibrary.WinControls.TabPageEx();
            this.panelBetreibung = new System.Windows.Forms.Panel();
            this.kissLabel13 = new KiSS4.Gui.KissLabel();
            this.kissLabel12 = new KiSS4.Gui.KissLabel();
            this.kissLabel11 = new KiSS4.Gui.KissLabel();
            this.kissLabel6 = new KiSS4.Gui.KissLabel();
            this.kissLabel10 = new KiSS4.Gui.KissLabel();
            this.kissLabel9 = new KiSS4.Gui.KissLabel();
            this.kissLabel8 = new KiSS4.Gui.KissLabel();
            this.kissLabel7 = new KiSS4.Gui.KissLabel();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.txtBetreibungAmt = new KiSS4.Gui.KissMemoEdit();
            this.txtBetreibungGlaeubiger = new KiSS4.Gui.KissTextEdit();
            this.dateBetreibungBis = new KiSS4.Gui.KissDateEdit();
            this.txtBetreibungNummer = new KiSS4.Gui.KissTextEdit();
            this.dateBetreibungRechtsoeffnungAm = new KiSS4.Gui.KissDateEdit();
            this.dateBetreibungVerwertungAm = new KiSS4.Gui.KissDateEdit();
            this.dateBetreibungFortsetzungAm = new KiSS4.Gui.KissDateEdit();
            this.dateBetreibungVon = new KiSS4.Gui.KissDateEdit();
            this.calcBetreibungBetrag = new KiSS4.Gui.KissCalcEdit();
            this.dateBetreibungEroeffnet = new KiSS4.Gui.KissDateEdit();
            this.cboBetreibungStatus = new KiSS4.Gui.KissLookUpEdit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcSummeAktiveVerlustscheine.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAuswahl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAuswahl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBetreibungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBetreibung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).BeginInit();
            this.xTabControl1.SuspendLayout();
            this.tabBemerkungen.SuspendLayout();
            this.panelBemerkungen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBemerkungen.Properties)).BeginInit();
            this.tabZahlungen.SuspendLayout();
            this.panelZahlungen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdZahlungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZahlungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcSaldoVerlustschein.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcSaldoBetreibung.Properties)).BeginInit();
            this.tabVerlustschein.SuspendLayout();
            this.panelVerlustschein.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVerlustscheinAmt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcVerlustscheinZins.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcVerlustscheinKosten.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcVerlustscheinBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVerlustscheinNummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateVerlustscheinVerjaehrung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateVerlustscheinAm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVerlustscheinTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVerlustscheinTyp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVerlustscheinStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVerlustscheinStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel21)).BeginInit();
            this.tabBetreibung.SuspendLayout();
            this.panelBetreibung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBetreibungAmt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBetreibungGlaeubiger.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBetreibungBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBetreibungNummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBetreibungRechtsoeffnungAm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBetreibungVerwertungAm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBetreibungFortsetzungAm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBetreibungVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcBetreibungBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBetreibungEroeffnet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBetreibungStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBetreibungStatus.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picTitle);
            this.panel1.Controls.Add(this.kissLabel2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.kissLabel1);
            this.panel1.Controls.Add(this.lblTitel);
            this.panel1.Controls.Add(this.calcSummeAktiveVerlustscheine);
            this.panel1.Controls.Add(this.btnNeuerVerlustschein);
            this.panel1.Controls.Add(this.btnNeueBetreibung);
            this.panel1.Controls.Add(this.btnShowVerlustscheine);
            this.panel1.Controls.Add(this.btnShowBoth);
            this.panel1.Controls.Add(this.buttonShowBetreibungen);
            this.panel1.Controls.Add(this.btnClipVerlustscheine);
            this.panel1.Controls.Add(this.btnClipBetreibungen);
            this.panel1.Controls.Add(this.cboAuswahl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(808, 128);
            this.panel1.TabIndex = 0;
            // 
            // picTitle
            // 
            this.picTitle.Location = new System.Drawing.Point(8, 8);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(16, 16);
            this.picTitle.TabIndex = 55;
            this.picTitle.TabStop = false;
            // 
            // kissLabel2
            // 
            this.kissLabel2.Location = new System.Drawing.Point(360, 88);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(176, 24);
            this.kissLabel2.TabIndex = 54;
            this.kissLabel2.Text = "Summe aller aktiven Verlustscheine";
            this.kissLabel2.UseCompatibleTextRendering = true;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(563, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 16);
            this.label4.TabIndex = 50;
            this.label4.Text = "Anzeige Grid";
            this.label4.UseCompatibleTextRendering = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(344, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 16);
            this.label3.TabIndex = 49;
            this.label3.Text = "In Zwischenablage kopieren";
            this.label3.UseCompatibleTextRendering = true;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(560, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 1);
            this.label2.TabIndex = 43;
            this.label2.UseCompatibleTextRendering = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(344, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 1);
            this.label1.TabIndex = 42;
            this.label1.UseCompatibleTextRendering = true;
            // 
            // kissLabel1
            // 
            this.kissLabel1.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.kissLabel1.Location = new System.Drawing.Point(8, 32);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(176, 16);
            this.kissLabel1.TabIndex = 38;
            this.kissLabel1.Text = "Auswahl";
            this.kissLabel1.UseCompatibleTextRendering = true;
            // 
            // lblTitel
            // 
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(35, 8);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(664, 16);
            this.lblTitel.TabIndex = 37;
            this.lblTitel.Text = "Betreibungen, Verlustscheine";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // calcSummeAktiveVerlustscheine
            // 
            this.calcSummeAktiveVerlustscheine.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.calcSummeAktiveVerlustscheine.Location = new System.Drawing.Point(544, 88);
            this.calcSummeAktiveVerlustscheine.Name = "calcSummeAktiveVerlustscheine";
            this.calcSummeAktiveVerlustscheine.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.calcSummeAktiveVerlustscheine.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.calcSummeAktiveVerlustscheine.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.calcSummeAktiveVerlustscheine.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.calcSummeAktiveVerlustscheine.Properties.Appearance.Options.UseBackColor = true;
            this.calcSummeAktiveVerlustscheine.Properties.Appearance.Options.UseBorderColor = true;
            this.calcSummeAktiveVerlustscheine.Properties.Appearance.Options.UseFont = true;
            this.calcSummeAktiveVerlustscheine.Properties.Appearance.Options.UseTextOptions = true;
            this.calcSummeAktiveVerlustscheine.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.calcSummeAktiveVerlustscheine.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.calcSummeAktiveVerlustscheine.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.calcSummeAktiveVerlustscheine.Properties.DisplayFormat.FormatString = "n2";
            this.calcSummeAktiveVerlustscheine.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.calcSummeAktiveVerlustscheine.Properties.EditFormat.FormatString = "n2";
            this.calcSummeAktiveVerlustscheine.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.calcSummeAktiveVerlustscheine.Properties.Mask.EditMask = "n2";
            this.calcSummeAktiveVerlustscheine.Properties.Name = "calcSummeAktiveVerlustscheine.Properties";
            this.calcSummeAktiveVerlustscheine.Properties.ReadOnly = true;
            this.calcSummeAktiveVerlustscheine.Size = new System.Drawing.Size(125, 24);
            this.calcSummeAktiveVerlustscheine.TabIndex = 11;
            // 
            // btnNeuerVerlustschein
            // 
            this.btnNeuerVerlustschein.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNeuerVerlustschein.Location = new System.Drawing.Point(152, 88);
            this.btnNeuerVerlustschein.Name = "btnNeuerVerlustschein";
            this.btnNeuerVerlustschein.Size = new System.Drawing.Size(128, 24);
            this.btnNeuerVerlustschein.TabIndex = 11;
            this.btnNeuerVerlustschein.Text = "Neuer Verlustschein";
            this.btnNeuerVerlustschein.UseCompatibleTextRendering = true;
            this.btnNeuerVerlustschein.UseVisualStyleBackColor = false;
            this.btnNeuerVerlustschein.Click += new System.EventHandler(this.btnNeuerVerlustschein_Click);
            // 
            // btnNeueBetreibung
            // 
            this.btnNeueBetreibung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNeueBetreibung.Location = new System.Drawing.Point(8, 88);
            this.btnNeueBetreibung.Name = "btnNeueBetreibung";
            this.btnNeueBetreibung.Size = new System.Drawing.Size(128, 24);
            this.btnNeueBetreibung.TabIndex = 10;
            this.btnNeueBetreibung.Text = "Neue Betreibung";
            this.btnNeueBetreibung.UseCompatibleTextRendering = true;
            this.btnNeueBetreibung.UseVisualStyleBackColor = false;
            this.btnNeueBetreibung.Click += new System.EventHandler(this.btnNeueBetreibung_Click);
            // 
            // btnShowVerlustscheine
            // 
            this.btnShowVerlustscheine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowVerlustscheine.Location = new System.Drawing.Point(637, 48);
            this.btnShowVerlustscheine.Name = "btnShowVerlustscheine";
            this.btnShowVerlustscheine.Size = new System.Drawing.Size(32, 24);
            this.btnShowVerlustscheine.TabIndex = 9;
            this.btnShowVerlustscheine.Text = ">>";
            this.btnShowVerlustscheine.UseCompatibleTextRendering = true;
            this.btnShowVerlustscheine.UseVisualStyleBackColor = false;
            this.btnShowVerlustscheine.Click += new System.EventHandler(this.btnShowVerlustscheine_Click);
            // 
            // btnShowBoth
            // 
            this.btnShowBoth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowBoth.Location = new System.Drawing.Point(600, 48);
            this.btnShowBoth.Name = "btnShowBoth";
            this.btnShowBoth.Size = new System.Drawing.Size(32, 24);
            this.btnShowBoth.TabIndex = 8;
            this.btnShowBoth.Text = "<>";
            this.btnShowBoth.UseCompatibleTextRendering = true;
            this.btnShowBoth.UseVisualStyleBackColor = false;
            this.btnShowBoth.Click += new System.EventHandler(this.btnShowBoth_Click);
            // 
            // buttonShowBetreibungen
            // 
            this.buttonShowBetreibungen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShowBetreibungen.Location = new System.Drawing.Point(563, 48);
            this.buttonShowBetreibungen.Name = "buttonShowBetreibungen";
            this.buttonShowBetreibungen.Size = new System.Drawing.Size(32, 24);
            this.buttonShowBetreibungen.TabIndex = 7;
            this.buttonShowBetreibungen.Text = "<<";
            this.buttonShowBetreibungen.UseCompatibleTextRendering = true;
            this.buttonShowBetreibungen.UseVisualStyleBackColor = false;
            this.buttonShowBetreibungen.Click += new System.EventHandler(this.buttonShowBetreibungen_Click);
            // 
            // btnClipVerlustscheine
            // 
            this.btnClipVerlustscheine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClipVerlustscheine.Location = new System.Drawing.Point(445, 48);
            this.btnClipVerlustscheine.Name = "btnClipVerlustscheine";
            this.btnClipVerlustscheine.Size = new System.Drawing.Size(96, 24);
            this.btnClipVerlustscheine.TabIndex = 6;
            this.btnClipVerlustscheine.Text = "Verlustscheine";
            this.btnClipVerlustscheine.UseCompatibleTextRendering = true;
            this.btnClipVerlustscheine.UseVisualStyleBackColor = false;
            this.btnClipVerlustscheine.Click += new System.EventHandler(this.btnClipVerlustscheine_Click);
            // 
            // btnClipBetreibungen
            // 
            this.btnClipBetreibungen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClipBetreibungen.Location = new System.Drawing.Point(344, 48);
            this.btnClipBetreibungen.Name = "btnClipBetreibungen";
            this.btnClipBetreibungen.Size = new System.Drawing.Size(96, 24);
            this.btnClipBetreibungen.TabIndex = 5;
            this.btnClipBetreibungen.Text = "Betreibungen";
            this.btnClipBetreibungen.UseCompatibleTextRendering = true;
            this.btnClipBetreibungen.UseVisualStyleBackColor = false;
            this.btnClipBetreibungen.Click += new System.EventHandler(this.btnClipBetreibungen_Click);
            // 
            // cboAuswahl
            // 
            this.cboAuswahl.AllowNull = false;
            this.cboAuswahl.Location = new System.Drawing.Point(8, 48);
            this.cboAuswahl.LOVName = "IkBetreibungVerlustschein";
            this.cboAuswahl.Name = "cboAuswahl";
            this.cboAuswahl.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboAuswahl.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboAuswahl.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboAuswahl.Properties.Appearance.Options.UseBackColor = true;
            this.cboAuswahl.Properties.Appearance.Options.UseBorderColor = true;
            this.cboAuswahl.Properties.Appearance.Options.UseFont = true;
            this.cboAuswahl.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboAuswahl.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboAuswahl.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboAuswahl.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboAuswahl.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.cboAuswahl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.cboAuswahl.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboAuswahl.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DisplayText")});
            this.cboAuswahl.Properties.Name = "cboAuswahl.Properties";
            this.cboAuswahl.Properties.NullText = "";
            this.cboAuswahl.Properties.ShowFooter = false;
            this.cboAuswahl.Properties.ShowHeader = false;
            this.cboAuswahl.Properties.ValueMember = "ItemCode";
            this.cboAuswahl.Size = new System.Drawing.Size(320, 24);
            this.cboAuswahl.TabIndex = 0;
            this.cboAuswahl.EditValueChanged += new System.EventHandler(this.cboAuswahl_EditValueChanged);
            // 
            // grdBetreibungen
            // 
            this.grdBetreibungen.DataSource = this.qryBetreibung;
            this.grdBetreibungen.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdBetreibungen.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.grdBetreibungen.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.grdBetreibungen.EmbeddedNavigator.Name = "grdBetreibungen.EmbeddedNavigator";
            this.grdBetreibungen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            gridLevelNode1.RelationName = "Level1";
            this.grdBetreibungen.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdBetreibungen.Location = new System.Drawing.Point(0, 128);
            this.grdBetreibungen.MainView = this.bandedGridView1;
            this.grdBetreibungen.Name = "grdBetreibungen";
            this.grdBetreibungen.Size = new System.Drawing.Size(808, 192);
            this.grdBetreibungen.TabIndex = 1;
            this.grdBetreibungen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView1});
            this.grdBetreibungen.Load += new System.EventHandler(this.grdBetreibungen_Load);
            // 
            // qryBetreibung
            // 
            this.qryBetreibung.CanDelete = true;
            this.qryBetreibung.CanInsert = true;
            this.qryBetreibung.CanUpdate = true;
            this.qryBetreibung.HostControl = this;
            this.qryBetreibung.IsIdentityInsert = false;
            this.qryBetreibung.SelectStatement = resources.GetString("qryBetreibung.SelectStatement");
            this.qryBetreibung.TableName = "IkBetreibung";
            this.qryBetreibung.AfterInsert += new System.EventHandler(this.qryBetreibung_AfterInsert);
            this.qryBetreibung.AfterPost += new System.EventHandler(this.qryBetreibung_AfterPost);
            this.qryBetreibung.PositionChanged += new System.EventHandler(this.qryBetreibung_PositionChanged);
            // 
            // bandedGridView1
            // 
            this.bandedGridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.bandedGridView1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.bandedGridView1.Appearance.Empty.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.Empty.Options.UseFont = true;
            this.bandedGridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.bandedGridView1.Appearance.EvenRow.Options.UseFont = true;
            this.bandedGridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.bandedGridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.bandedGridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.bandedGridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.FocusedCell.Options.UseFont = true;
            this.bandedGridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.bandedGridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.bandedGridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.bandedGridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.bandedGridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.bandedGridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.bandedGridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.bandedGridView1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.bandedGridView1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.bandedGridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.bandedGridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.bandedGridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.bandedGridView1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.bandedGridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.GroupRow.Options.UseFont = true;
            this.bandedGridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.bandedGridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.bandedGridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.bandedGridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.bandedGridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.bandedGridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.bandedGridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.bandedGridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.bandedGridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.bandedGridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.bandedGridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.bandedGridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.bandedGridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.bandedGridView1.Appearance.OddRow.Options.UseFont = true;
            this.bandedGridView1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.bandedGridView1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.bandedGridView1.Appearance.Row.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.Row.Options.UseFont = true;
            this.bandedGridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.bandedGridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.bandedGridView1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.bandedGridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2});
            this.bandedGridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colBetreibungAm,
            this.colBetreibungFortsetzungAm,
            this.colBetreibungNummer,
            this.colBetreibungStatus,
            this.colBetreibungBetrag,
            this.colBetreibungVon,
            this.colBetreibungBis,
            this.colBetreibungGlaeubiger,
            this.colVerlustscheinAm,
            this.colVerlustscheinTotal,
            this.colVerlustscheinKosten,
            this.colVerlustscheinZins,
            this.colVerlustscheinNummer,
            this.colVerlustscheinAmt,
            this.colVerlustscheinStatus,
            this.colVerlustscheinTyp});
            this.bandedGridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.bandedGridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.bandedGridView1.GridControl = this.grdBetreibungen;
            this.bandedGridView1.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.bandedGridView1.Name = "bandedGridView1";
            this.bandedGridView1.OptionsBehavior.Editable = false;
            this.bandedGridView1.OptionsCustomization.AllowFilter = false;
            this.bandedGridView1.OptionsFilter.AllowFilterEditor = false;
            this.bandedGridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.bandedGridView1.OptionsMenu.EnableColumnMenu = false;
            this.bandedGridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.bandedGridView1.OptionsNavigation.UseTabKey = false;
            this.bandedGridView1.OptionsView.ColumnAutoWidth = false;
            this.bandedGridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.bandedGridView1.OptionsView.ShowGroupPanel = false;
            this.bandedGridView1.OptionsView.ShowIndicator = false;
            this.bandedGridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.bandedGridView1_RowCellStyle);
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.gridBand1.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand1.Caption = "Betreibungen";
            this.gridBand1.Columns.Add(this.colBetreibungAm);
            this.gridBand1.Columns.Add(this.colBetreibungFortsetzungAm);
            this.gridBand1.Columns.Add(this.colBetreibungNummer);
            this.gridBand1.Columns.Add(this.colBetreibungStatus);
            this.gridBand1.Columns.Add(this.colBetreibungBetrag);
            this.gridBand1.Columns.Add(this.colBetreibungVon);
            this.gridBand1.Columns.Add(this.colBetreibungBis);
            this.gridBand1.Columns.Add(this.colBetreibungGlaeubiger);
            this.gridBand1.MinWidth = 20;
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Width = 395;
            // 
            // colBetreibungAm
            // 
            this.colBetreibungAm.Caption = "Datum";
            this.colBetreibungAm.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.colBetreibungAm.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colBetreibungAm.FieldName = "BetreibungAm";
            this.colBetreibungAm.Name = "colBetreibungAm";
            this.colBetreibungAm.Visible = true;
            this.colBetreibungAm.Width = 46;
            // 
            // colBetreibungFortsetzungAm
            // 
            this.colBetreibungFortsetzungAm.Caption = "Fortsetzung am";
            this.colBetreibungFortsetzungAm.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.colBetreibungFortsetzungAm.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colBetreibungFortsetzungAm.FieldName = "BetreibungFortsetzungAm";
            this.colBetreibungFortsetzungAm.Name = "colBetreibungFortsetzungAm";
            this.colBetreibungFortsetzungAm.Visible = true;
            this.colBetreibungFortsetzungAm.Width = 45;
            // 
            // colBetreibungNummer
            // 
            this.colBetreibungNummer.Caption = "Betreibungsnummer";
            this.colBetreibungNummer.FieldName = "BetreibungNummer";
            this.colBetreibungNummer.Name = "colBetreibungNummer";
            this.colBetreibungNummer.Visible = true;
            this.colBetreibungNummer.Width = 71;
            // 
            // colBetreibungStatus
            // 
            this.colBetreibungStatus.Caption = "Betreibungsstatus";
            this.colBetreibungStatus.FieldName = "IkBetreibungStatusCode";
            this.colBetreibungStatus.Name = "colBetreibungStatus";
            this.colBetreibungStatus.Visible = true;
            this.colBetreibungStatus.Width = 86;
            // 
            // colBetreibungBetrag
            // 
            this.colBetreibungBetrag.Caption = "Betrag";
            this.colBetreibungBetrag.DisplayFormat.FormatString = "n2";
            this.colBetreibungBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetreibungBetrag.FieldName = "BetreibungBetrag";
            this.colBetreibungBetrag.Name = "colBetreibungBetrag";
            this.colBetreibungBetrag.Visible = true;
            this.colBetreibungBetrag.Width = 51;
            // 
            // colBetreibungVon
            // 
            this.colBetreibungVon.Caption = "Von";
            this.colBetreibungVon.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.colBetreibungVon.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colBetreibungVon.FieldName = "BetreibungVon";
            this.colBetreibungVon.Name = "colBetreibungVon";
            this.colBetreibungVon.Visible = true;
            this.colBetreibungVon.Width = 34;
            // 
            // colBetreibungBis
            // 
            this.colBetreibungBis.Caption = "Bis";
            this.colBetreibungBis.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.colBetreibungBis.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colBetreibungBis.FieldName = "BetreibungBis";
            this.colBetreibungBis.Name = "colBetreibungBis";
            this.colBetreibungBis.Visible = true;
            this.colBetreibungBis.Width = 29;
            // 
            // colBetreibungGlaeubiger
            // 
            this.colBetreibungGlaeubiger.Caption = "Gläubiger";
            this.colBetreibungGlaeubiger.FieldName = "Glaeubiger";
            this.colBetreibungGlaeubiger.Name = "colBetreibungGlaeubiger";
            this.colBetreibungGlaeubiger.Visible = true;
            this.colBetreibungGlaeubiger.Width = 33;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.Caption = "Verlustscheine";
            this.gridBand2.Columns.Add(this.colVerlustscheinAm);
            this.gridBand2.Columns.Add(this.colVerlustscheinTotal);
            this.gridBand2.Columns.Add(this.colVerlustscheinKosten);
            this.gridBand2.Columns.Add(this.colVerlustscheinZins);
            this.gridBand2.Columns.Add(this.colVerlustscheinNummer);
            this.gridBand2.Columns.Add(this.colVerlustscheinAmt);
            this.gridBand2.Columns.Add(this.colVerlustscheinStatus);
            this.gridBand2.Columns.Add(this.colVerlustscheinTyp);
            this.gridBand2.MinWidth = 20;
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.Width = 817;
            // 
            // colVerlustscheinAm
            // 
            this.colVerlustscheinAm.Caption = "Datum";
            this.colVerlustscheinAm.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.colVerlustscheinAm.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colVerlustscheinAm.FieldName = "VerlustscheinAm";
            this.colVerlustscheinAm.Name = "colVerlustscheinAm";
            this.colVerlustscheinAm.Visible = true;
            this.colVerlustscheinAm.Width = 45;
            // 
            // colVerlustscheinTotal
            // 
            this.colVerlustscheinTotal.Caption = "Total";
            this.colVerlustscheinTotal.DisplayFormat.FormatString = "n2";
            this.colVerlustscheinTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colVerlustscheinTotal.FieldName = "VerlustscheinTotal";
            this.colVerlustscheinTotal.Name = "colVerlustscheinTotal";
            this.colVerlustscheinTotal.Visible = true;
            this.colVerlustscheinTotal.Width = 47;
            // 
            // colVerlustscheinKosten
            // 
            this.colVerlustscheinKosten.Caption = "Anteil Kosten";
            this.colVerlustscheinKosten.DisplayFormat.FormatString = "n2";
            this.colVerlustscheinKosten.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colVerlustscheinKosten.FieldName = "VerlustscheinKosten";
            this.colVerlustscheinKosten.Name = "colVerlustscheinKosten";
            this.colVerlustscheinKosten.Visible = true;
            this.colVerlustscheinKosten.Width = 53;
            // 
            // colVerlustscheinZins
            // 
            this.colVerlustscheinZins.Caption = "Anteil Zins";
            this.colVerlustscheinZins.DisplayFormat.FormatString = "n2";
            this.colVerlustscheinZins.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colVerlustscheinZins.FieldName = "VerlustscheinZins";
            this.colVerlustscheinZins.Name = "colVerlustscheinZins";
            this.colVerlustscheinZins.Visible = true;
            this.colVerlustscheinZins.Width = 54;
            // 
            // colVerlustscheinNummer
            // 
            this.colVerlustscheinNummer.Caption = "Nummer";
            this.colVerlustscheinNummer.FieldName = "VerlustscheinNummer";
            this.colVerlustscheinNummer.Name = "colVerlustscheinNummer";
            this.colVerlustscheinNummer.Visible = true;
            this.colVerlustscheinNummer.Width = 76;
            // 
            // colVerlustscheinAmt
            // 
            this.colVerlustscheinAmt.Caption = "Betreibungsamt";
            this.colVerlustscheinAmt.FieldName = "VerlustscheinAmt";
            this.colVerlustscheinAmt.Name = "colVerlustscheinAmt";
            this.colVerlustscheinAmt.Visible = true;
            this.colVerlustscheinAmt.Width = 60;
            // 
            // colVerlustscheinStatus
            // 
            this.colVerlustscheinStatus.Caption = "Verlustscheinstatus";
            this.colVerlustscheinStatus.FieldName = "IkVerlustscheinStatusCode";
            this.colVerlustscheinStatus.Name = "colVerlustscheinStatus";
            this.colVerlustscheinStatus.Visible = true;
            this.colVerlustscheinStatus.Width = 42;
            // 
            // colVerlustscheinTyp
            // 
            this.colVerlustscheinTyp.Caption = "Typ";
            this.colVerlustscheinTyp.FieldName = "IkVerlustscheinTypCode";
            this.colVerlustscheinTyp.Name = "colVerlustscheinTyp";
            this.colVerlustscheinTyp.Visible = true;
            this.colVerlustscheinTyp.Width = 440;
            // 
            // xTabControl1
            // 
            this.xTabControl1.Controls.Add(this.tabBemerkungen);
            this.xTabControl1.Controls.Add(this.tabZahlungen);
            this.xTabControl1.Controls.Add(this.tabVerlustschein);
            this.xTabControl1.Controls.Add(this.tabBetreibung);
            this.xTabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xTabControl1.Location = new System.Drawing.Point(0, 320);
            this.xTabControl1.Name = "xTabControl1";
            this.xTabControl1.ShowFixedWidthTooltip = true;
            this.xTabControl1.Size = new System.Drawing.Size(808, 248);
            this.xTabControl1.TabIndex = 2;
            this.xTabControl1.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tabBetreibung,
            this.tabVerlustschein,
            this.tabZahlungen,
            this.tabBemerkungen});
            this.xTabControl1.TabsLineColor = System.Drawing.Color.Black;
            this.xTabControl1.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            // 
            // tabBemerkungen
            // 
            this.tabBemerkungen.Controls.Add(this.panelBemerkungen);
            this.tabBemerkungen.Location = new System.Drawing.Point(6, 6);
            this.tabBemerkungen.Name = "tabBemerkungen";
            this.tabBemerkungen.Size = new System.Drawing.Size(796, 210);
            this.tabBemerkungen.TabIndex = 3;
            this.tabBemerkungen.Title = "Bemerkungen";
            // 
            // panelBemerkungen
            // 
            this.panelBemerkungen.Controls.Add(this.txtBemerkungen);
            this.panelBemerkungen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBemerkungen.Location = new System.Drawing.Point(0, 0);
            this.panelBemerkungen.Name = "panelBemerkungen";
            this.panelBemerkungen.Size = new System.Drawing.Size(796, 210);
            this.panelBemerkungen.TabIndex = 0;
            // 
            // txtBemerkungen
            // 
            this.txtBemerkungen.DataMember = "Bemerkung";
            this.txtBemerkungen.DataSource = this.qryBetreibung;
            this.txtBemerkungen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBemerkungen.Location = new System.Drawing.Point(0, 0);
            this.txtBemerkungen.Name = "txtBemerkungen";
            this.txtBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.txtBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.txtBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txtBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.txtBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.txtBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.txtBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtBemerkungen.Properties.Name = "txtBemerkungen.Properties";
            this.txtBemerkungen.Size = new System.Drawing.Size(796, 210);
            this.txtBemerkungen.TabIndex = 0;
            // 
            // tabZahlungen
            // 
            this.tabZahlungen.Controls.Add(this.panelZahlungen);
            this.tabZahlungen.Location = new System.Drawing.Point(6, 6);
            this.tabZahlungen.Name = "tabZahlungen";
            this.tabZahlungen.Size = new System.Drawing.Size(796, 210);
            this.tabZahlungen.TabIndex = 2;
            this.tabZahlungen.Title = "Zahlungen";
            // 
            // panelZahlungen
            // 
            this.panelZahlungen.Controls.Add(this.grdZahlungen);
            this.panelZahlungen.Controls.Add(this.kissLabel17);
            this.panelZahlungen.Controls.Add(this.kissLabel16);
            this.panelZahlungen.Controls.Add(this.calcSaldoVerlustschein);
            this.panelZahlungen.Controls.Add(this.calcSaldoBetreibung);
            this.panelZahlungen.Controls.Add(this.btnNeueZahlung);
            this.panelZahlungen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelZahlungen.Location = new System.Drawing.Point(0, 0);
            this.panelZahlungen.Name = "panelZahlungen";
            this.panelZahlungen.Size = new System.Drawing.Size(796, 210);
            this.panelZahlungen.TabIndex = 0;
            // 
            // grdZahlungen
            // 
            this.grdZahlungen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdZahlungen.DataSource = this.qryZahlungen;
            // 
            // 
            // 
            this.grdZahlungen.EmbeddedNavigator.Name = "grdZahlungen.EmbeddedNavigator";
            this.grdZahlungen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdZahlungen.Location = new System.Drawing.Point(0, 0);
            this.grdZahlungen.MainView = this.gridView3;
            this.grdZahlungen.Name = "grdZahlungen";
            this.grdZahlungen.Size = new System.Drawing.Size(793, 163);
            this.grdZahlungen.TabIndex = 60;
            this.grdZahlungen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // qryZahlungen
            // 
            this.qryZahlungen.CanDelete = true;
            this.qryZahlungen.CanInsert = true;
            this.qryZahlungen.CanUpdate = true;
            this.qryZahlungen.IsIdentityInsert = false;
            this.qryZahlungen.SelectStatement = resources.GetString("qryZahlungen.SelectStatement");
            // 
            // gridView3
            // 
            this.gridView3.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView3.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.Empty.Options.UseBackColor = true;
            this.gridView3.Appearance.Empty.Options.UseFont = true;
            this.gridView3.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.EvenRow.Options.UseFont = true;
            this.gridView3.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView3.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView3.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView3.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView3.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView3.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView3.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView3.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView3.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView3.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView3.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView3.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView3.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView3.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView3.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView3.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView3.Appearance.GroupRow.Options.UseFont = true;
            this.gridView3.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView3.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView3.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView3.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView3.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView3.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView3.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView3.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView3.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView3.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView3.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView3.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView3.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView3.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView3.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.OddRow.Options.UseFont = true;
            this.gridView3.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView3.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.Row.Options.UseBackColor = true;
            this.gridView3.Appearance.Row.Options.UseFont = true;
            this.gridView3.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView3.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView3.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDateZahlungseingang,
            this.colBemerkungen,
            this.colTeilbetrag});
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView3.GridControl = this.grdZahlungen;
            this.gridView3.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.Editable = false;
            this.gridView3.OptionsCustomization.AllowFilter = false;
            this.gridView3.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView3.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView3.OptionsNavigation.UseTabKey = false;
            this.gridView3.OptionsView.ColumnAutoWidth = false;
            this.gridView3.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            this.gridView3.OptionsView.ShowIndicator = false;
            // 
            // colDateZahlungseingang
            // 
            this.colDateZahlungseingang.Caption = "Zahlungseingang";
            this.colDateZahlungseingang.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.colDateZahlungseingang.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDateZahlungseingang.FieldName = "DatumZahlungseingang";
            this.colDateZahlungseingang.Name = "colDateZahlungseingang";
            this.colDateZahlungseingang.Visible = true;
            this.colDateZahlungseingang.VisibleIndex = 0;
            this.colDateZahlungseingang.Width = 117;
            // 
            // colBemerkungen
            // 
            this.colBemerkungen.Caption = "Text";
            this.colBemerkungen.FieldName = "Bemerkungen";
            this.colBemerkungen.Name = "colBemerkungen";
            this.colBemerkungen.Visible = true;
            this.colBemerkungen.VisibleIndex = 1;
            this.colBemerkungen.Width = 277;
            // 
            // colTeilbetrag
            // 
            this.colTeilbetrag.Caption = "Betrag";
            this.colTeilbetrag.DisplayFormat.FormatString = "n2";
            this.colTeilbetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTeilbetrag.FieldName = "Teilbetrag";
            this.colTeilbetrag.Name = "colTeilbetrag";
            this.colTeilbetrag.Visible = true;
            this.colTeilbetrag.VisibleIndex = 2;
            this.colTeilbetrag.Width = 139;
            // 
            // kissLabel17
            // 
            this.kissLabel17.Location = new System.Drawing.Point(168, 176);
            this.kissLabel17.Name = "kissLabel17";
            this.kissLabel17.Size = new System.Drawing.Size(96, 24);
            this.kissLabel17.TabIndex = 59;
            this.kissLabel17.Text = "Saldo Betreibung";
            this.kissLabel17.UseCompatibleTextRendering = true;
            // 
            // kissLabel16
            // 
            this.kissLabel16.Location = new System.Drawing.Point(408, 176);
            this.kissLabel16.Name = "kissLabel16";
            this.kissLabel16.Size = new System.Drawing.Size(104, 24);
            this.kissLabel16.TabIndex = 58;
            this.kissLabel16.Text = "Saldo Verlustschein";
            this.kissLabel16.UseCompatibleTextRendering = true;
            // 
            // calcSaldoVerlustschein
            // 
            this.calcSaldoVerlustschein.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.calcSaldoVerlustschein.Location = new System.Drawing.Point(520, 176);
            this.calcSaldoVerlustschein.Name = "calcSaldoVerlustschein";
            this.calcSaldoVerlustschein.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.calcSaldoVerlustschein.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.calcSaldoVerlustschein.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.calcSaldoVerlustschein.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.calcSaldoVerlustschein.Properties.Appearance.Options.UseBackColor = true;
            this.calcSaldoVerlustschein.Properties.Appearance.Options.UseBorderColor = true;
            this.calcSaldoVerlustschein.Properties.Appearance.Options.UseFont = true;
            this.calcSaldoVerlustschein.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.calcSaldoVerlustschein.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.calcSaldoVerlustschein.Properties.DisplayFormat.FormatString = "n2";
            this.calcSaldoVerlustschein.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.calcSaldoVerlustschein.Properties.EditFormat.FormatString = "n2";
            this.calcSaldoVerlustschein.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.calcSaldoVerlustschein.Properties.Mask.EditMask = "n2";
            this.calcSaldoVerlustschein.Properties.Name = "calcSaldoVerlustschein.Properties";
            this.calcSaldoVerlustschein.Properties.ReadOnly = true;
            this.calcSaldoVerlustschein.Size = new System.Drawing.Size(128, 24);
            this.calcSaldoVerlustschein.TabIndex = 57;
            // 
            // calcSaldoBetreibung
            // 
            this.calcSaldoBetreibung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.calcSaldoBetreibung.Location = new System.Drawing.Point(264, 176);
            this.calcSaldoBetreibung.Name = "calcSaldoBetreibung";
            this.calcSaldoBetreibung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.calcSaldoBetreibung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.calcSaldoBetreibung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.calcSaldoBetreibung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.calcSaldoBetreibung.Properties.Appearance.Options.UseBackColor = true;
            this.calcSaldoBetreibung.Properties.Appearance.Options.UseBorderColor = true;
            this.calcSaldoBetreibung.Properties.Appearance.Options.UseFont = true;
            this.calcSaldoBetreibung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.calcSaldoBetreibung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.calcSaldoBetreibung.Properties.DisplayFormat.FormatString = "n2";
            this.calcSaldoBetreibung.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.calcSaldoBetreibung.Properties.EditFormat.FormatString = "n2";
            this.calcSaldoBetreibung.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.calcSaldoBetreibung.Properties.Mask.EditMask = "n2";
            this.calcSaldoBetreibung.Properties.Name = "calcSaldoBetreibung.Properties";
            this.calcSaldoBetreibung.Properties.ReadOnly = true;
            this.calcSaldoBetreibung.Size = new System.Drawing.Size(128, 24);
            this.calcSaldoBetreibung.TabIndex = 56;
            // 
            // btnNeueZahlung
            // 
            this.btnNeueZahlung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNeueZahlung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNeueZahlung.Location = new System.Drawing.Point(8, 176);
            this.btnNeueZahlung.Name = "btnNeueZahlung";
            this.btnNeueZahlung.Size = new System.Drawing.Size(120, 24);
            this.btnNeueZahlung.TabIndex = 41;
            this.btnNeueZahlung.Text = "neue Zahlung...";
            this.btnNeueZahlung.UseCompatibleTextRendering = true;
            this.btnNeueZahlung.UseVisualStyleBackColor = false;
            this.btnNeueZahlung.Visible = false;
            this.btnNeueZahlung.Click += new System.EventHandler(this.btnNeueZahlung_Click);
            // 
            // tabVerlustschein
            // 
            this.tabVerlustschein.Controls.Add(this.panelVerlustschein);
            this.tabVerlustschein.Location = new System.Drawing.Point(6, 6);
            this.tabVerlustschein.Name = "tabVerlustschein";
            this.tabVerlustschein.Size = new System.Drawing.Size(796, 210);
            this.tabVerlustschein.TabIndex = 1;
            this.tabVerlustschein.Title = "Verlustschein";
            // 
            // panelVerlustschein
            // 
            this.panelVerlustschein.Controls.Add(this.kissLabel18);
            this.panelVerlustschein.Controls.Add(this.kissLabel24);
            this.panelVerlustschein.Controls.Add(this.kissLabel15);
            this.panelVerlustschein.Controls.Add(this.kissLabel14);
            this.panelVerlustschein.Controls.Add(this.kissLabel22);
            this.panelVerlustschein.Controls.Add(this.kissLabel19);
            this.panelVerlustschein.Controls.Add(this.kissLabel20);
            this.panelVerlustschein.Controls.Add(this.txtVerlustscheinAmt);
            this.panelVerlustschein.Controls.Add(this.calcVerlustscheinZins);
            this.panelVerlustschein.Controls.Add(this.calcVerlustscheinKosten);
            this.panelVerlustschein.Controls.Add(this.calcVerlustscheinBetrag);
            this.panelVerlustschein.Controls.Add(this.txtVerlustscheinNummer);
            this.panelVerlustschein.Controls.Add(this.dateVerlustscheinVerjaehrung);
            this.panelVerlustschein.Controls.Add(this.dateVerlustscheinAm);
            this.panelVerlustschein.Controls.Add(this.cboVerlustscheinTyp);
            this.panelVerlustschein.Controls.Add(this.cboVerlustscheinStatus);
            this.panelVerlustschein.Controls.Add(this.kissLabel23);
            this.panelVerlustschein.Controls.Add(this.kissLabel21);
            this.panelVerlustschein.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelVerlustschein.Location = new System.Drawing.Point(0, 0);
            this.panelVerlustschein.Name = "panelVerlustschein";
            this.panelVerlustschein.Size = new System.Drawing.Size(796, 210);
            this.panelVerlustschein.TabIndex = 0;
            // 
            // kissLabel18
            // 
            this.kissLabel18.Location = new System.Drawing.Point(9, 30);
            this.kissLabel18.Name = "kissLabel18";
            this.kissLabel18.Size = new System.Drawing.Size(127, 24);
            this.kissLabel18.TabIndex = 56;
            this.kissLabel18.Text = "Typ des Verlustscheins";
            this.kissLabel18.UseCompatibleTextRendering = true;
            // 
            // kissLabel24
            // 
            this.kissLabel24.Location = new System.Drawing.Point(96, 133);
            this.kissLabel24.Name = "kissLabel24";
            this.kissLabel24.Size = new System.Drawing.Size(40, 24);
            this.kissLabel24.TabIndex = 53;
            this.kissLabel24.Text = "Zins";
            this.kissLabel24.UseCompatibleTextRendering = true;
            // 
            // kissLabel15
            // 
            this.kissLabel15.Location = new System.Drawing.Point(96, 110);
            this.kissLabel15.Name = "kissLabel15";
            this.kissLabel15.Size = new System.Drawing.Size(40, 24);
            this.kissLabel15.TabIndex = 51;
            this.kissLabel15.Text = "Kosten";
            this.kissLabel15.UseCompatibleTextRendering = true;
            // 
            // kissLabel14
            // 
            this.kissLabel14.Location = new System.Drawing.Point(56, 168);
            this.kissLabel14.Name = "kissLabel14";
            this.kissLabel14.Size = new System.Drawing.Size(80, 24);
            this.kissLabel14.TabIndex = 45;
            this.kissLabel14.Text = "Betreibungsamt";
            this.kissLabel14.UseCompatibleTextRendering = true;
            // 
            // kissLabel22
            // 
            this.kissLabel22.Location = new System.Drawing.Point(96, 87);
            this.kissLabel22.Name = "kissLabel22";
            this.kissLabel22.Size = new System.Drawing.Size(40, 24);
            this.kissLabel22.TabIndex = 32;
            this.kissLabel22.Text = "Betrag";
            this.kissLabel22.UseCompatibleTextRendering = true;
            // 
            // kissLabel19
            // 
            this.kissLabel19.Location = new System.Drawing.Point(9, 53);
            this.kissLabel19.Name = "kissLabel19";
            this.kissLabel19.Size = new System.Drawing.Size(135, 24);
            this.kissLabel19.TabIndex = 31;
            this.kissLabel19.Text = "Verlustschein ausgestellt";
            this.kissLabel19.UseCompatibleTextRendering = true;
            // 
            // kissLabel20
            // 
            this.kissLabel20.Location = new System.Drawing.Point(9, 7);
            this.kissLabel20.Name = "kissLabel20";
            this.kissLabel20.Size = new System.Drawing.Size(135, 24);
            this.kissLabel20.TabIndex = 30;
            this.kissLabel20.Text = "Status des Verlustscheins";
            this.kissLabel20.UseCompatibleTextRendering = true;
            // 
            // txtVerlustscheinAmt
            // 
            this.txtVerlustscheinAmt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVerlustscheinAmt.DataMember = "VerlustscheinAmt";
            this.txtVerlustscheinAmt.DataSource = this.qryBetreibung;
            this.txtVerlustscheinAmt.Location = new System.Drawing.Point(144, 168);
            this.txtVerlustscheinAmt.Name = "txtVerlustscheinAmt";
            this.txtVerlustscheinAmt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.txtVerlustscheinAmt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.txtVerlustscheinAmt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txtVerlustscheinAmt.Properties.Appearance.Options.UseBackColor = true;
            this.txtVerlustscheinAmt.Properties.Appearance.Options.UseBorderColor = true;
            this.txtVerlustscheinAmt.Properties.Appearance.Options.UseFont = true;
            this.txtVerlustscheinAmt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtVerlustscheinAmt.Properties.Name = "txtVerlustscheinAmt.Properties";
            this.txtVerlustscheinAmt.Size = new System.Drawing.Size(649, 40);
            this.txtVerlustscheinAmt.TabIndex = 8;
            // 
            // calcVerlustscheinZins
            // 
            this.calcVerlustscheinZins.DataMember = "VerlustscheinZins";
            this.calcVerlustscheinZins.DataSource = this.qryBetreibung;
            this.calcVerlustscheinZins.Location = new System.Drawing.Point(144, 133);
            this.calcVerlustscheinZins.Name = "calcVerlustscheinZins";
            this.calcVerlustscheinZins.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.calcVerlustscheinZins.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.calcVerlustscheinZins.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.calcVerlustscheinZins.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.calcVerlustscheinZins.Properties.Appearance.Options.UseBackColor = true;
            this.calcVerlustscheinZins.Properties.Appearance.Options.UseBorderColor = true;
            this.calcVerlustscheinZins.Properties.Appearance.Options.UseFont = true;
            this.calcVerlustscheinZins.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.calcVerlustscheinZins.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.calcVerlustscheinZins.Properties.DisplayFormat.FormatString = "n2";
            this.calcVerlustscheinZins.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.calcVerlustscheinZins.Properties.EditFormat.FormatString = "n2";
            this.calcVerlustscheinZins.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.calcVerlustscheinZins.Properties.Mask.EditMask = "n2";
            this.calcVerlustscheinZins.Properties.Name = "calcVerlustscheinZins.Properties";
            this.calcVerlustscheinZins.Size = new System.Drawing.Size(96, 24);
            this.calcVerlustscheinZins.TabIndex = 7;
            // 
            // calcVerlustscheinKosten
            // 
            this.calcVerlustscheinKosten.DataMember = "VerlustscheinKosten";
            this.calcVerlustscheinKosten.DataSource = this.qryBetreibung;
            this.calcVerlustscheinKosten.Location = new System.Drawing.Point(144, 110);
            this.calcVerlustscheinKosten.Name = "calcVerlustscheinKosten";
            this.calcVerlustscheinKosten.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.calcVerlustscheinKosten.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.calcVerlustscheinKosten.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.calcVerlustscheinKosten.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.calcVerlustscheinKosten.Properties.Appearance.Options.UseBackColor = true;
            this.calcVerlustscheinKosten.Properties.Appearance.Options.UseBorderColor = true;
            this.calcVerlustscheinKosten.Properties.Appearance.Options.UseFont = true;
            this.calcVerlustscheinKosten.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.calcVerlustscheinKosten.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.calcVerlustscheinKosten.Properties.DisplayFormat.FormatString = "n2";
            this.calcVerlustscheinKosten.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.calcVerlustscheinKosten.Properties.EditFormat.FormatString = "n2";
            this.calcVerlustscheinKosten.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.calcVerlustscheinKosten.Properties.Mask.EditMask = "n2";
            this.calcVerlustscheinKosten.Properties.Name = "calcVerlustscheinKosten.Properties";
            this.calcVerlustscheinKosten.Size = new System.Drawing.Size(96, 24);
            this.calcVerlustscheinKosten.TabIndex = 6;
            // 
            // calcVerlustscheinBetrag
            // 
            this.calcVerlustscheinBetrag.DataMember = "VerlustscheinBetrag";
            this.calcVerlustscheinBetrag.DataSource = this.qryBetreibung;
            this.calcVerlustscheinBetrag.Location = new System.Drawing.Point(144, 87);
            this.calcVerlustscheinBetrag.Name = "calcVerlustscheinBetrag";
            this.calcVerlustscheinBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.calcVerlustscheinBetrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.calcVerlustscheinBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.calcVerlustscheinBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.calcVerlustscheinBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.calcVerlustscheinBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.calcVerlustscheinBetrag.Properties.Appearance.Options.UseFont = true;
            this.calcVerlustscheinBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.calcVerlustscheinBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.calcVerlustscheinBetrag.Properties.DisplayFormat.FormatString = "n2";
            this.calcVerlustscheinBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.calcVerlustscheinBetrag.Properties.EditFormat.FormatString = "n2";
            this.calcVerlustscheinBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.calcVerlustscheinBetrag.Properties.Mask.EditMask = "n2";
            this.calcVerlustscheinBetrag.Properties.Name = "calcVerlustscheinBetrag.Properties";
            this.calcVerlustscheinBetrag.Size = new System.Drawing.Size(96, 24);
            this.calcVerlustscheinBetrag.TabIndex = 5;
            // 
            // txtVerlustscheinNummer
            // 
            this.txtVerlustscheinNummer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVerlustscheinNummer.DataMember = "VerlustscheinNummer";
            this.txtVerlustscheinNummer.DataSource = this.qryBetreibung;
            this.txtVerlustscheinNummer.Location = new System.Drawing.Point(480, 53);
            this.txtVerlustscheinNummer.Name = "txtVerlustscheinNummer";
            this.txtVerlustscheinNummer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.txtVerlustscheinNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.txtVerlustscheinNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txtVerlustscheinNummer.Properties.Appearance.Options.UseBackColor = true;
            this.txtVerlustscheinNummer.Properties.Appearance.Options.UseBorderColor = true;
            this.txtVerlustscheinNummer.Properties.Appearance.Options.UseFont = true;
            this.txtVerlustscheinNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtVerlustscheinNummer.Properties.Name = "txtVerlustscheinNummer.Properties";
            this.txtVerlustscheinNummer.Size = new System.Drawing.Size(313, 24);
            this.txtVerlustscheinNummer.TabIndex = 4;
            // 
            // dateVerlustscheinVerjaehrung
            // 
            this.dateVerlustscheinVerjaehrung.DataMember = "VerlustscheinVerjaehrungAm";
            this.dateVerlustscheinVerjaehrung.DataSource = this.qryBetreibung;
            this.dateVerlustscheinVerjaehrung.EditValue = null;
            this.dateVerlustscheinVerjaehrung.Location = new System.Drawing.Point(328, 53);
            this.dateVerlustscheinVerjaehrung.Name = "dateVerlustscheinVerjaehrung";
            this.dateVerlustscheinVerjaehrung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.dateVerlustscheinVerjaehrung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.dateVerlustscheinVerjaehrung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.dateVerlustscheinVerjaehrung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.dateVerlustscheinVerjaehrung.Properties.Appearance.Options.UseBackColor = true;
            this.dateVerlustscheinVerjaehrung.Properties.Appearance.Options.UseBorderColor = true;
            this.dateVerlustscheinVerjaehrung.Properties.Appearance.Options.UseFont = true;
            this.dateVerlustscheinVerjaehrung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.dateVerlustscheinVerjaehrung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("dateVerlustscheinVerjaehrung.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.dateVerlustscheinVerjaehrung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dateVerlustscheinVerjaehrung.Properties.Name = "dateVerlustscheinVerjaehrung.Properties";
            this.dateVerlustscheinVerjaehrung.Properties.ShowToday = false;
            this.dateVerlustscheinVerjaehrung.Size = new System.Drawing.Size(96, 24);
            this.dateVerlustscheinVerjaehrung.TabIndex = 3;
            // 
            // dateVerlustscheinAm
            // 
            this.dateVerlustscheinAm.DataMember = "VerlustscheinAm";
            this.dateVerlustscheinAm.DataSource = this.qryBetreibung;
            this.dateVerlustscheinAm.EditValue = null;
            this.dateVerlustscheinAm.Location = new System.Drawing.Point(144, 53);
            this.dateVerlustscheinAm.Name = "dateVerlustscheinAm";
            this.dateVerlustscheinAm.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.dateVerlustscheinAm.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.dateVerlustscheinAm.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.dateVerlustscheinAm.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.dateVerlustscheinAm.Properties.Appearance.Options.UseBackColor = true;
            this.dateVerlustscheinAm.Properties.Appearance.Options.UseBorderColor = true;
            this.dateVerlustscheinAm.Properties.Appearance.Options.UseFont = true;
            this.dateVerlustscheinAm.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.dateVerlustscheinAm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("dateVerlustscheinAm.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.dateVerlustscheinAm.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dateVerlustscheinAm.Properties.Name = "dateVerlustscheinAm.Properties";
            this.dateVerlustscheinAm.Properties.ShowToday = false;
            this.dateVerlustscheinAm.Size = new System.Drawing.Size(96, 24);
            this.dateVerlustscheinAm.TabIndex = 2;
            // 
            // cboVerlustscheinTyp
            // 
            this.cboVerlustscheinTyp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboVerlustscheinTyp.DataMember = "IkVerlustscheinTypCode";
            this.cboVerlustscheinTyp.DataSource = this.qryBetreibung;
            this.cboVerlustscheinTyp.Location = new System.Drawing.Point(144, 30);
            this.cboVerlustscheinTyp.LOVName = "IkVerlustscheinTyp";
            this.cboVerlustscheinTyp.Name = "cboVerlustscheinTyp";
            this.cboVerlustscheinTyp.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboVerlustscheinTyp.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboVerlustscheinTyp.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboVerlustscheinTyp.Properties.Appearance.Options.UseBackColor = true;
            this.cboVerlustscheinTyp.Properties.Appearance.Options.UseBorderColor = true;
            this.cboVerlustscheinTyp.Properties.Appearance.Options.UseFont = true;
            this.cboVerlustscheinTyp.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboVerlustscheinTyp.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboVerlustscheinTyp.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboVerlustscheinTyp.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboVerlustscheinTyp.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.cboVerlustscheinTyp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.cboVerlustscheinTyp.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboVerlustscheinTyp.Properties.Name = "cboVerlustscheinTyp.Properties";
            this.cboVerlustscheinTyp.Properties.NullText = "";
            this.cboVerlustscheinTyp.Properties.ShowFooter = false;
            this.cboVerlustscheinTyp.Properties.ShowHeader = false;
            this.cboVerlustscheinTyp.Size = new System.Drawing.Size(649, 24);
            this.cboVerlustscheinTyp.TabIndex = 1;
            // 
            // cboVerlustscheinStatus
            // 
            this.cboVerlustscheinStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboVerlustscheinStatus.DataMember = "IkVerlustscheinStatusCode";
            this.cboVerlustscheinStatus.DataSource = this.qryBetreibung;
            this.cboVerlustscheinStatus.Location = new System.Drawing.Point(144, 7);
            this.cboVerlustscheinStatus.LOVName = "IkVerlustscheinStatus";
            this.cboVerlustscheinStatus.Name = "cboVerlustscheinStatus";
            this.cboVerlustscheinStatus.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboVerlustscheinStatus.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboVerlustscheinStatus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboVerlustscheinStatus.Properties.Appearance.Options.UseBackColor = true;
            this.cboVerlustscheinStatus.Properties.Appearance.Options.UseBorderColor = true;
            this.cboVerlustscheinStatus.Properties.Appearance.Options.UseFont = true;
            this.cboVerlustscheinStatus.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboVerlustscheinStatus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboVerlustscheinStatus.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboVerlustscheinStatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboVerlustscheinStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.cboVerlustscheinStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.cboVerlustscheinStatus.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboVerlustscheinStatus.Properties.Name = "cboVerlustscheinStatus.Properties";
            this.cboVerlustscheinStatus.Properties.NullText = "";
            this.cboVerlustscheinStatus.Properties.ShowFooter = false;
            this.cboVerlustscheinStatus.Properties.ShowHeader = false;
            this.cboVerlustscheinStatus.Size = new System.Drawing.Size(649, 24);
            this.cboVerlustscheinStatus.TabIndex = 0;
            this.cboVerlustscheinStatus.EditValueChanged += new System.EventHandler(this.cboVerlustscheinStatus_EditValueChanged);
            // 
            // kissLabel23
            // 
            this.kissLabel23.Location = new System.Drawing.Point(248, 53);
            this.kissLabel23.Name = "kissLabel23";
            this.kissLabel23.Size = new System.Drawing.Size(80, 24);
            this.kissLabel23.TabIndex = 46;
            this.kissLabel23.Text = "Verjährung am";
            this.kissLabel23.UseCompatibleTextRendering = true;
            // 
            // kissLabel21
            // 
            this.kissLabel21.Location = new System.Drawing.Point(432, 53);
            this.kissLabel21.Name = "kissLabel21";
            this.kissLabel21.Size = new System.Drawing.Size(48, 24);
            this.kissLabel21.TabIndex = 33;
            this.kissLabel21.Text = "Nummer";
            this.kissLabel21.UseCompatibleTextRendering = true;
            // 
            // tabBetreibung
            // 
            this.tabBetreibung.Controls.Add(this.panelBetreibung);
            this.tabBetreibung.Location = new System.Drawing.Point(6, 6);
            this.tabBetreibung.Name = "tabBetreibung";
            this.tabBetreibung.Size = new System.Drawing.Size(796, 210);
            this.tabBetreibung.TabIndex = 0;
            this.tabBetreibung.Title = "Betreibung";
            // 
            // panelBetreibung
            // 
            this.panelBetreibung.Controls.Add(this.kissLabel13);
            this.panelBetreibung.Controls.Add(this.kissLabel12);
            this.panelBetreibung.Controls.Add(this.kissLabel11);
            this.panelBetreibung.Controls.Add(this.kissLabel6);
            this.panelBetreibung.Controls.Add(this.kissLabel10);
            this.panelBetreibung.Controls.Add(this.kissLabel9);
            this.panelBetreibung.Controls.Add(this.kissLabel8);
            this.panelBetreibung.Controls.Add(this.kissLabel7);
            this.panelBetreibung.Controls.Add(this.kissLabel5);
            this.panelBetreibung.Controls.Add(this.kissLabel4);
            this.panelBetreibung.Controls.Add(this.kissLabel3);
            this.panelBetreibung.Controls.Add(this.txtBetreibungAmt);
            this.panelBetreibung.Controls.Add(this.txtBetreibungGlaeubiger);
            this.panelBetreibung.Controls.Add(this.dateBetreibungBis);
            this.panelBetreibung.Controls.Add(this.txtBetreibungNummer);
            this.panelBetreibung.Controls.Add(this.dateBetreibungRechtsoeffnungAm);
            this.panelBetreibung.Controls.Add(this.dateBetreibungVerwertungAm);
            this.panelBetreibung.Controls.Add(this.dateBetreibungFortsetzungAm);
            this.panelBetreibung.Controls.Add(this.dateBetreibungVon);
            this.panelBetreibung.Controls.Add(this.calcBetreibungBetrag);
            this.panelBetreibung.Controls.Add(this.dateBetreibungEroeffnet);
            this.panelBetreibung.Controls.Add(this.cboBetreibungStatus);
            this.panelBetreibung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBetreibung.Location = new System.Drawing.Point(0, 0);
            this.panelBetreibung.Name = "panelBetreibung";
            this.panelBetreibung.Size = new System.Drawing.Size(796, 210);
            this.panelBetreibung.TabIndex = 0;
            // 
            // kissLabel13
            // 
            this.kissLabel13.Location = new System.Drawing.Point(40, 168);
            this.kissLabel13.Name = "kissLabel13";
            this.kissLabel13.Size = new System.Drawing.Size(80, 24);
            this.kissLabel13.TabIndex = 21;
            this.kissLabel13.Text = "Betreibungsamt";
            this.kissLabel13.UseCompatibleTextRendering = true;
            // 
            // kissLabel12
            // 
            this.kissLabel12.Location = new System.Drawing.Point(40, 145);
            this.kissLabel12.Name = "kissLabel12";
            this.kissLabel12.Size = new System.Drawing.Size(72, 24);
            this.kissLabel12.TabIndex = 20;
            this.kissLabel12.Text = "Gläubiger";
            this.kissLabel12.UseCompatibleTextRendering = true;
            // 
            // kissLabel11
            // 
            this.kissLabel11.Location = new System.Drawing.Point(424, 53);
            this.kissLabel11.Name = "kissLabel11";
            this.kissLabel11.Size = new System.Drawing.Size(24, 24);
            this.kissLabel11.TabIndex = 19;
            this.kissLabel11.Text = "bis";
            this.kissLabel11.UseCompatibleTextRendering = true;
            // 
            // kissLabel6
            // 
            this.kissLabel6.Location = new System.Drawing.Point(424, 32);
            this.kissLabel6.Name = "kissLabel6";
            this.kissLabel6.Size = new System.Drawing.Size(48, 24);
            this.kissLabel6.TabIndex = 18;
            this.kissLabel6.Text = "Nummer";
            this.kissLabel6.UseCompatibleTextRendering = true;
            // 
            // kissLabel10
            // 
            this.kissLabel10.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissLabel10.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel10.Location = new System.Drawing.Point(83, 123);
            this.kissLabel10.Name = "kissLabel10";
            this.kissLabel10.Size = new System.Drawing.Size(200, 22);
            this.kissLabel10.TabIndex = 17;
            this.kissLabel10.Text = "Rechtsöffnungsbegehren gestellt";
            this.kissLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.kissLabel10.UseCompatibleTextRendering = true;
            // 
            // kissLabel9
            // 
            this.kissLabel9.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissLabel9.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel9.Location = new System.Drawing.Point(83, 98);
            this.kissLabel9.Name = "kissLabel9";
            this.kissLabel9.Size = new System.Drawing.Size(200, 24);
            this.kissLabel9.TabIndex = 16;
            this.kissLabel9.Text = "Verwertungsbegehren gestellt";
            this.kissLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.kissLabel9.UseCompatibleTextRendering = true;
            // 
            // kissLabel8
            // 
            this.kissLabel8.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissLabel8.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel8.Location = new System.Drawing.Point(83, 76);
            this.kissLabel8.Name = "kissLabel8";
            this.kissLabel8.Size = new System.Drawing.Size(200, 24);
            this.kissLabel8.TabIndex = 15;
            this.kissLabel8.Text = "Fortsetzungsbegehren gestellt";
            this.kissLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.kissLabel8.UseCompatibleTextRendering = true;
            // 
            // kissLabel7
            // 
            this.kissLabel7.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissLabel7.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel7.Location = new System.Drawing.Point(83, 57);
            this.kissLabel7.Name = "kissLabel7";
            this.kissLabel7.Size = new System.Drawing.Size(200, 16);
            this.kissLabel7.TabIndex = 14;
            this.kissLabel7.Text = "Zeitperiode von";
            this.kissLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.kissLabel7.UseCompatibleTextRendering = true;
            // 
            // kissLabel5
            // 
            this.kissLabel5.Location = new System.Drawing.Point(243, 31);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(40, 24);
            this.kissLabel5.TabIndex = 13;
            this.kissLabel5.Text = "Betrag";
            this.kissLabel5.UseCompatibleTextRendering = true;
            // 
            // kissLabel4
            // 
            this.kissLabel4.Location = new System.Drawing.Point(8, 30);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(120, 24);
            this.kissLabel4.TabIndex = 12;
            this.kissLabel4.Text = "Betreibung eröffnet am";
            this.kissLabel4.UseCompatibleTextRendering = true;
            // 
            // kissLabel3
            // 
            this.kissLabel3.Location = new System.Drawing.Point(8, 7);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(120, 24);
            this.kissLabel3.TabIndex = 11;
            this.kissLabel3.Text = "Status der Betreibung";
            this.kissLabel3.UseCompatibleTextRendering = true;
            // 
            // txtBetreibungAmt
            // 
            this.txtBetreibungAmt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBetreibungAmt.DataMember = "BetreibungAmt";
            this.txtBetreibungAmt.DataSource = this.qryBetreibung;
            this.txtBetreibungAmt.Location = new System.Drawing.Point(128, 168);
            this.txtBetreibungAmt.Name = "txtBetreibungAmt";
            this.txtBetreibungAmt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.txtBetreibungAmt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.txtBetreibungAmt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txtBetreibungAmt.Properties.Appearance.Options.UseBackColor = true;
            this.txtBetreibungAmt.Properties.Appearance.Options.UseBorderColor = true;
            this.txtBetreibungAmt.Properties.Appearance.Options.UseFont = true;
            this.txtBetreibungAmt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtBetreibungAmt.Properties.Name = "txtBetreibungAmt.Properties";
            this.txtBetreibungAmt.Size = new System.Drawing.Size(665, 40);
            this.txtBetreibungAmt.TabIndex = 10;
            // 
            // txtBetreibungGlaeubiger
            // 
            this.txtBetreibungGlaeubiger.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBetreibungGlaeubiger.DataMember = "Glaeubiger";
            this.txtBetreibungGlaeubiger.DataSource = this.qryBetreibung;
            this.txtBetreibungGlaeubiger.Location = new System.Drawing.Point(128, 145);
            this.txtBetreibungGlaeubiger.Name = "txtBetreibungGlaeubiger";
            this.txtBetreibungGlaeubiger.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.txtBetreibungGlaeubiger.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.txtBetreibungGlaeubiger.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txtBetreibungGlaeubiger.Properties.Appearance.Options.UseBackColor = true;
            this.txtBetreibungGlaeubiger.Properties.Appearance.Options.UseBorderColor = true;
            this.txtBetreibungGlaeubiger.Properties.Appearance.Options.UseFont = true;
            this.txtBetreibungGlaeubiger.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtBetreibungGlaeubiger.Properties.Name = "txtBetreibungGlaeubiger.Properties";
            this.txtBetreibungGlaeubiger.Size = new System.Drawing.Size(665, 24);
            this.txtBetreibungGlaeubiger.TabIndex = 9;
            // 
            // dateBetreibungBis
            // 
            this.dateBetreibungBis.DataMember = "BetreibungBis";
            this.dateBetreibungBis.DataSource = this.qryBetreibung;
            this.dateBetreibungBis.EditValue = null;
            this.dateBetreibungBis.Location = new System.Drawing.Point(472, 53);
            this.dateBetreibungBis.Name = "dateBetreibungBis";
            this.dateBetreibungBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.dateBetreibungBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.dateBetreibungBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.dateBetreibungBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.dateBetreibungBis.Properties.Appearance.Options.UseBackColor = true;
            this.dateBetreibungBis.Properties.Appearance.Options.UseBorderColor = true;
            this.dateBetreibungBis.Properties.Appearance.Options.UseFont = true;
            this.dateBetreibungBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.dateBetreibungBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("dateBetreibungBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.dateBetreibungBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dateBetreibungBis.Properties.Name = "dateBetreibungBis.Properties";
            this.dateBetreibungBis.Properties.ShowToday = false;
            this.dateBetreibungBis.Size = new System.Drawing.Size(96, 24);
            this.dateBetreibungBis.TabIndex = 8;
            // 
            // txtBetreibungNummer
            // 
            this.txtBetreibungNummer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBetreibungNummer.DataMember = "BetreibungNummer";
            this.txtBetreibungNummer.DataSource = this.qryBetreibung;
            this.txtBetreibungNummer.Location = new System.Drawing.Point(472, 30);
            this.txtBetreibungNummer.Name = "txtBetreibungNummer";
            this.txtBetreibungNummer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.txtBetreibungNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.txtBetreibungNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txtBetreibungNummer.Properties.Appearance.Options.UseBackColor = true;
            this.txtBetreibungNummer.Properties.Appearance.Options.UseBorderColor = true;
            this.txtBetreibungNummer.Properties.Appearance.Options.UseFont = true;
            this.txtBetreibungNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtBetreibungNummer.Properties.Name = "txtBetreibungNummer.Properties";
            this.txtBetreibungNummer.Size = new System.Drawing.Size(321, 24);
            this.txtBetreibungNummer.TabIndex = 7;
            // 
            // dateBetreibungRechtsoeffnungAm
            // 
            this.dateBetreibungRechtsoeffnungAm.DataMember = "BetreibungRechtsoeffnungAm";
            this.dateBetreibungRechtsoeffnungAm.DataSource = this.qryBetreibung;
            this.dateBetreibungRechtsoeffnungAm.EditValue = null;
            this.dateBetreibungRechtsoeffnungAm.Location = new System.Drawing.Point(288, 122);
            this.dateBetreibungRechtsoeffnungAm.Name = "dateBetreibungRechtsoeffnungAm";
            this.dateBetreibungRechtsoeffnungAm.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.dateBetreibungRechtsoeffnungAm.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.dateBetreibungRechtsoeffnungAm.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.dateBetreibungRechtsoeffnungAm.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.dateBetreibungRechtsoeffnungAm.Properties.Appearance.Options.UseBackColor = true;
            this.dateBetreibungRechtsoeffnungAm.Properties.Appearance.Options.UseBorderColor = true;
            this.dateBetreibungRechtsoeffnungAm.Properties.Appearance.Options.UseFont = true;
            this.dateBetreibungRechtsoeffnungAm.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.dateBetreibungRechtsoeffnungAm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("dateBetreibungRechtsoeffnungAm.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.dateBetreibungRechtsoeffnungAm.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dateBetreibungRechtsoeffnungAm.Properties.Name = "dateBetreibungRechtsoeffnungAm.Properties";
            this.dateBetreibungRechtsoeffnungAm.Properties.ShowToday = false;
            this.dateBetreibungRechtsoeffnungAm.Size = new System.Drawing.Size(96, 24);
            this.dateBetreibungRechtsoeffnungAm.TabIndex = 6;
            // 
            // dateBetreibungVerwertungAm
            // 
            this.dateBetreibungVerwertungAm.DataMember = "BetreibungVerwertungAm";
            this.dateBetreibungVerwertungAm.DataSource = this.qryBetreibung;
            this.dateBetreibungVerwertungAm.EditValue = null;
            this.dateBetreibungVerwertungAm.Location = new System.Drawing.Point(288, 99);
            this.dateBetreibungVerwertungAm.Name = "dateBetreibungVerwertungAm";
            this.dateBetreibungVerwertungAm.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.dateBetreibungVerwertungAm.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.dateBetreibungVerwertungAm.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.dateBetreibungVerwertungAm.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.dateBetreibungVerwertungAm.Properties.Appearance.Options.UseBackColor = true;
            this.dateBetreibungVerwertungAm.Properties.Appearance.Options.UseBorderColor = true;
            this.dateBetreibungVerwertungAm.Properties.Appearance.Options.UseFont = true;
            this.dateBetreibungVerwertungAm.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.dateBetreibungVerwertungAm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("dateBetreibungVerwertungAm.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.dateBetreibungVerwertungAm.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dateBetreibungVerwertungAm.Properties.Name = "dateBetreibungVerwertungAm.Properties";
            this.dateBetreibungVerwertungAm.Properties.ShowToday = false;
            this.dateBetreibungVerwertungAm.Size = new System.Drawing.Size(96, 24);
            this.dateBetreibungVerwertungAm.TabIndex = 5;
            // 
            // dateBetreibungFortsetzungAm
            // 
            this.dateBetreibungFortsetzungAm.DataMember = "BetreibungFortsetzungAm";
            this.dateBetreibungFortsetzungAm.DataSource = this.qryBetreibung;
            this.dateBetreibungFortsetzungAm.EditValue = null;
            this.dateBetreibungFortsetzungAm.Location = new System.Drawing.Point(288, 76);
            this.dateBetreibungFortsetzungAm.Name = "dateBetreibungFortsetzungAm";
            this.dateBetreibungFortsetzungAm.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.dateBetreibungFortsetzungAm.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.dateBetreibungFortsetzungAm.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.dateBetreibungFortsetzungAm.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.dateBetreibungFortsetzungAm.Properties.Appearance.Options.UseBackColor = true;
            this.dateBetreibungFortsetzungAm.Properties.Appearance.Options.UseBorderColor = true;
            this.dateBetreibungFortsetzungAm.Properties.Appearance.Options.UseFont = true;
            this.dateBetreibungFortsetzungAm.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.dateBetreibungFortsetzungAm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("dateBetreibungFortsetzungAm.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.dateBetreibungFortsetzungAm.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dateBetreibungFortsetzungAm.Properties.Name = "dateBetreibungFortsetzungAm.Properties";
            this.dateBetreibungFortsetzungAm.Properties.ShowToday = false;
            this.dateBetreibungFortsetzungAm.Size = new System.Drawing.Size(96, 24);
            this.dateBetreibungFortsetzungAm.TabIndex = 4;
            // 
            // dateBetreibungVon
            // 
            this.dateBetreibungVon.DataMember = "BetreibungVon";
            this.dateBetreibungVon.DataSource = this.qryBetreibung;
            this.dateBetreibungVon.EditValue = null;
            this.dateBetreibungVon.Location = new System.Drawing.Point(288, 53);
            this.dateBetreibungVon.Name = "dateBetreibungVon";
            this.dateBetreibungVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.dateBetreibungVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.dateBetreibungVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.dateBetreibungVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.dateBetreibungVon.Properties.Appearance.Options.UseBackColor = true;
            this.dateBetreibungVon.Properties.Appearance.Options.UseBorderColor = true;
            this.dateBetreibungVon.Properties.Appearance.Options.UseFont = true;
            this.dateBetreibungVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.dateBetreibungVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("dateBetreibungVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.dateBetreibungVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dateBetreibungVon.Properties.Name = "dateBetreibungVon.Properties";
            this.dateBetreibungVon.Properties.ShowToday = false;
            this.dateBetreibungVon.Size = new System.Drawing.Size(96, 24);
            this.dateBetreibungVon.TabIndex = 3;
            // 
            // calcBetreibungBetrag
            // 
            this.calcBetreibungBetrag.DataMember = "BetreibungBetrag";
            this.calcBetreibungBetrag.DataSource = this.qryBetreibung;
            this.calcBetreibungBetrag.Location = new System.Drawing.Point(288, 30);
            this.calcBetreibungBetrag.Name = "calcBetreibungBetrag";
            this.calcBetreibungBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.calcBetreibungBetrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.calcBetreibungBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.calcBetreibungBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.calcBetreibungBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.calcBetreibungBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.calcBetreibungBetrag.Properties.Appearance.Options.UseFont = true;
            this.calcBetreibungBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.calcBetreibungBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.calcBetreibungBetrag.Properties.DisplayFormat.FormatString = "n2";
            this.calcBetreibungBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.calcBetreibungBetrag.Properties.EditFormat.FormatString = "n2";
            this.calcBetreibungBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.calcBetreibungBetrag.Properties.Mask.EditMask = "n2";
            this.calcBetreibungBetrag.Properties.Name = "calcBetreibungBetrag.Properties";
            this.calcBetreibungBetrag.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.calcBetreibungBetrag.Size = new System.Drawing.Size(96, 24);
            this.calcBetreibungBetrag.TabIndex = 2;
            // 
            // dateBetreibungEroeffnet
            // 
            this.dateBetreibungEroeffnet.DataMember = "BetreibungAm";
            this.dateBetreibungEroeffnet.DataSource = this.qryBetreibung;
            this.dateBetreibungEroeffnet.EditValue = null;
            this.dateBetreibungEroeffnet.Location = new System.Drawing.Point(128, 30);
            this.dateBetreibungEroeffnet.Name = "dateBetreibungEroeffnet";
            this.dateBetreibungEroeffnet.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.dateBetreibungEroeffnet.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.dateBetreibungEroeffnet.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.dateBetreibungEroeffnet.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.dateBetreibungEroeffnet.Properties.Appearance.Options.UseBackColor = true;
            this.dateBetreibungEroeffnet.Properties.Appearance.Options.UseBorderColor = true;
            this.dateBetreibungEroeffnet.Properties.Appearance.Options.UseFont = true;
            this.dateBetreibungEroeffnet.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.dateBetreibungEroeffnet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("dateBetreibungEroeffnet.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.dateBetreibungEroeffnet.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dateBetreibungEroeffnet.Properties.Name = "dateBetreibungEroeffnet.Properties";
            this.dateBetreibungEroeffnet.Properties.ShowToday = false;
            this.dateBetreibungEroeffnet.Size = new System.Drawing.Size(96, 24);
            this.dateBetreibungEroeffnet.TabIndex = 1;
            // 
            // cboBetreibungStatus
            // 
            this.cboBetreibungStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBetreibungStatus.DataMember = "IkBetreibungStatusCode";
            this.cboBetreibungStatus.DataSource = this.qryBetreibung;
            this.cboBetreibungStatus.Location = new System.Drawing.Point(128, 7);
            this.cboBetreibungStatus.LOVName = "IkBetreibungStatus";
            this.cboBetreibungStatus.Name = "cboBetreibungStatus";
            this.cboBetreibungStatus.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboBetreibungStatus.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboBetreibungStatus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboBetreibungStatus.Properties.Appearance.Options.UseBackColor = true;
            this.cboBetreibungStatus.Properties.Appearance.Options.UseBorderColor = true;
            this.cboBetreibungStatus.Properties.Appearance.Options.UseFont = true;
            this.cboBetreibungStatus.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboBetreibungStatus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboBetreibungStatus.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboBetreibungStatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboBetreibungStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.cboBetreibungStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.cboBetreibungStatus.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboBetreibungStatus.Properties.Name = "cboBetreibungStatus.Properties";
            this.cboBetreibungStatus.Properties.NullText = "";
            this.cboBetreibungStatus.Properties.ShowFooter = false;
            this.cboBetreibungStatus.Properties.ShowHeader = false;
            this.cboBetreibungStatus.Size = new System.Drawing.Size(665, 24);
            this.cboBetreibungStatus.TabIndex = 0;
            this.cboBetreibungStatus.EditValueChanged += new System.EventHandler(this.cboBetreibungStatus_EditValueChanged);
            // 
            // CtlIkBetreibungenVerlustscheine
            // 
            this.ActiveSQLQuery = this.qryBetreibung;
            this.Controls.Add(this.grdBetreibungen);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.xTabControl1);
            this.Name = "CtlIkBetreibungenVerlustscheine";
            this.Size = new System.Drawing.Size(808, 568);
            this.Load += new System.EventHandler(this.CtlIkBetreibungenVerlustscheine_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcSummeAktiveVerlustscheine.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAuswahl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAuswahl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBetreibungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBetreibung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).EndInit();
            this.xTabControl1.ResumeLayout(false);
            this.tabBemerkungen.ResumeLayout(false);
            this.panelBemerkungen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtBemerkungen.Properties)).EndInit();
            this.tabZahlungen.ResumeLayout(false);
            this.panelZahlungen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdZahlungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZahlungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcSaldoVerlustschein.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcSaldoBetreibung.Properties)).EndInit();
            this.tabVerlustschein.ResumeLayout(false);
            this.panelVerlustschein.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVerlustscheinAmt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcVerlustscheinZins.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcVerlustscheinKosten.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcVerlustscheinBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVerlustscheinNummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateVerlustscheinVerjaehrung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateVerlustscheinAm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVerlustscheinTyp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVerlustscheinTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVerlustscheinStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVerlustscheinStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel21)).EndInit();
            this.tabBetreibung.ResumeLayout(false);
            this.panelBetreibung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBetreibungAmt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBetreibungGlaeubiger.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBetreibungBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBetreibungNummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBetreibungRechtsoeffnungAm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBetreibungVerwertungAm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBetreibungFortsetzungAm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBetreibungVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcBetreibungBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBetreibungEroeffnet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBetreibungStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBetreibungStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

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

        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView1;
        private KiSS4.Gui.KissButton btnClipBetreibungen;
        private KiSS4.Gui.KissButton btnClipVerlustscheine;
        private KiSS4.Gui.KissButton btnNeueBetreibung;
        private KiSS4.Gui.KissButton btnNeueZahlung;
        private KiSS4.Gui.KissButton btnNeuerVerlustschein;
        private KiSS4.Gui.KissButton btnShowBoth;
        private KiSS4.Gui.KissButton btnShowVerlustscheine;
        private KiSS4.Gui.KissButton buttonShowBetreibungen;
        private KiSS4.Gui.KissCalcEdit calcBetreibungBetrag;
        private KiSS4.Gui.KissCalcEdit calcSaldoBetreibung;
        private KiSS4.Gui.KissCalcEdit calcSaldoVerlustschein;
        private KiSS4.Gui.KissCalcEdit calcSummeAktiveVerlustscheine;
        private KiSS4.Gui.KissCalcEdit calcVerlustscheinBetrag;
        private KiSS4.Gui.KissCalcEdit calcVerlustscheinKosten;
        private KiSS4.Gui.KissCalcEdit calcVerlustscheinZins;
        private KiSS4.Gui.KissLookUpEdit cboAuswahl;
        private KiSS4.Gui.KissLookUpEdit cboBetreibungStatus;
        private KiSS4.Gui.KissLookUpEdit cboVerlustscheinStatus;
        private KiSS4.Gui.KissLookUpEdit cboVerlustscheinTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colBemerkungen;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colBetreibungAm;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colBetreibungBetrag;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colBetreibungBis;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colBetreibungFortsetzungAm;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colBetreibungGlaeubiger;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colBetreibungNummer;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colBetreibungStatus;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colBetreibungVon;
        private DevExpress.XtraGrid.Columns.GridColumn colDateZahlungseingang;
        private DevExpress.XtraGrid.Columns.GridColumn colTeilbetrag;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colVerlustscheinAm;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colVerlustscheinAmt;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colVerlustscheinKosten;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colVerlustscheinNummer;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colVerlustscheinStatus;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colVerlustscheinTotal;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colVerlustscheinTyp;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colVerlustscheinZins;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissDateEdit dateBetreibungBis;
        private KiSS4.Gui.KissDateEdit dateBetreibungEroeffnet;
        private KiSS4.Gui.KissDateEdit dateBetreibungFortsetzungAm;
        private KiSS4.Gui.KissDateEdit dateBetreibungRechtsoeffnungAm;
        private KiSS4.Gui.KissDateEdit dateBetreibungVerwertungAm;
        private KiSS4.Gui.KissDateEdit dateBetreibungVon;
        private KiSS4.Gui.KissDateEdit dateVerlustscheinAm;
        private KiSS4.Gui.KissDateEdit dateVerlustscheinVerjaehrung;
        private KiSS4.Gui.KissGrid grdBetreibungen;
        private KiSS4.Gui.KissGrid grdZahlungen;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel kissLabel10;
        private KiSS4.Gui.KissLabel kissLabel11;
        private KiSS4.Gui.KissLabel kissLabel12;
        private KiSS4.Gui.KissLabel kissLabel13;
        private KiSS4.Gui.KissLabel kissLabel14;
        private KiSS4.Gui.KissLabel kissLabel15;
        private KiSS4.Gui.KissLabel kissLabel16;
        private KiSS4.Gui.KissLabel kissLabel17;
        private KiSS4.Gui.KissLabel kissLabel18;
        private KiSS4.Gui.KissLabel kissLabel19;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissLabel kissLabel20;
        private KiSS4.Gui.KissLabel kissLabel21;
        private KiSS4.Gui.KissLabel kissLabel22;
        private KiSS4.Gui.KissLabel kissLabel23;
        private KiSS4.Gui.KissLabel kissLabel24;
        private KiSS4.Gui.KissLabel kissLabel3;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel kissLabel5;
        private KiSS4.Gui.KissLabel kissLabel6;
        private KiSS4.Gui.KissLabel kissLabel7;
        private KiSS4.Gui.KissLabel kissLabel8;
        private KiSS4.Gui.KissLabel kissLabel9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private KiSS4.Gui.KissLabel lblTitel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelBemerkungen;
        private System.Windows.Forms.Panel panelBetreibung;
        private System.Windows.Forms.Panel panelVerlustschein;
        private System.Windows.Forms.Panel panelZahlungen;
        private KiSS4.DB.SqlQuery qryBetreibung;
        private KiSS4.DB.SqlQuery qryZahlungen;
        private SharpLibrary.WinControls.TabPageEx tabBemerkungen;
        private SharpLibrary.WinControls.TabPageEx tabBetreibung;
        private SharpLibrary.WinControls.TabPageEx tabVerlustschein;
        private SharpLibrary.WinControls.TabPageEx tabZahlungen;
        private KiSS4.Gui.KissMemoEdit txtBemerkungen;
        private KiSS4.Gui.KissMemoEdit txtBetreibungAmt;
        private KiSS4.Gui.KissTextEdit txtBetreibungGlaeubiger;
        private KiSS4.Gui.KissTextEdit txtBetreibungNummer;
        private KiSS4.Gui.KissMemoEdit txtVerlustscheinAmt;
        private KiSS4.Gui.KissTextEdit txtVerlustscheinNummer;
        private KiSS4.Gui.KissTabControlEx xTabControl1;
        private System.Windows.Forms.PictureBox picTitle;
    }
}
