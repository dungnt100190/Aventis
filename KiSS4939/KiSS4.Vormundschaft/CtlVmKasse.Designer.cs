namespace KiSS4.Vormundschaft
{
    partial class CtlVmKasse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlVmKasse));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnAuszahlen = new KiSS4.Gui.KissButton();
            this.lblBelegAuszDatum = new KiSS4.Gui.KissLabel();
            this.lblBelegBewilligtDurch = new KiSS4.Gui.KissLabel();
            this.lblBelegMandTraeger = new KiSS4.Gui.KissLabel();
            this.lblTitelBeleg = new KiSS4.Gui.KissLabel();
            this.lblPlzOrt = new KiSS4.Gui.KissLabel();
            this.lblStrasse = new KiSS4.Gui.KissLabel();
            this.lblAHVNummer = new KiSS4.Gui.KissLabel();
            this.lblGeburtsdatum = new KiSS4.Gui.KissLabel();
            this.lblNameVorname = new KiSS4.Gui.KissLabel();
            this.lblTitelUnterstPers = new KiSS4.Gui.KissLabel();
            this.btnBelegDrucken = new KiSS4.Gui.KissButton();
            this.btnZuBarauszahlung = new KiSS4.Gui.KissButton();
            this.edtBewilligtDurch = new KiSS4.Gui.KissTextEdit();
            this.qryVmKasse = new KiSS4.DB.SqlQuery(this.components);
            this.edtMandatstraeger = new KiSS4.Gui.KissTextEdit();
            this.edtPersAHVNummer = new KiSS4.Gui.KissTextEdit();
            this.edtPersOrt = new KiSS4.Gui.KissTextEdit();
            this.edtPersStrasse = new KiSS4.Gui.KissTextEdit();
            this.edtPersNameVorname = new KiSS4.Gui.KissTextEdit();
            this.edtPersVersNummer = new KiSS4.Gui.KissTextEdit();
            this.lblVersNummer = new KiSS4.Gui.KissLabel();
            this.lblBelegBetrag = new KiSS4.Gui.KissLabel();
            this.edtBetrag = new KiSS4.Gui.KissTextEdit();
            this.lblBelegText = new KiSS4.Gui.KissLabel();
            this.edtBuchungstext = new KiSS4.Gui.KissTextEdit();
            this.lblBelegAuszDurch = new KiSS4.Gui.KissLabel();
            this.edtAuszahlungDurch = new KiSS4.Gui.KissTextEdit();
            this.lblAuszPlzOrt = new KiSS4.Gui.KissLabel();
            this.lblAuszStrasse = new KiSS4.Gui.KissLabel();
            this.lblAuszNameVorname = new KiSS4.Gui.KissLabel();
            this.lblTitelAuszAn = new KiSS4.Gui.KissLabel();
            this.edtAuszStrasse = new KiSS4.Gui.KissTextEdit();
            this.edtAuszNameVorname = new KiSS4.Gui.KissTextEdit();
            this.edtHabenName = new KiSS4.Gui.KissTextEdit();
            this.edtSollName = new KiSS4.Gui.KissTextEdit();
            this.lblBelegHaben = new KiSS4.Gui.KissLabel();
            this.lblBelegSoll = new KiSS4.Gui.KissLabel();
            this.chkAuszNichtKlient = new KiSS4.Gui.KissCheckEdit();
            this.grdBarzahlungen = new KiSS4.Gui.KissGrid();
            this.grvBarzahlungen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBelegNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMandant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStichtag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuszahlungAb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuszahlungBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBewilligtVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuszahlungsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkSucheVerbucht = new KiSS4.Gui.KissCheckEdit();
            this.chkSucheNichtVerbucht = new KiSS4.Gui.KissCheckEdit();
            this.lblSucheMandant = new KiSS4.Gui.KissLabel();
            this.lblSucheDatumBis = new KiSS4.Gui.KissLabel();
            this.lblSucheDatumVon = new KiSS4.Gui.KissLabel();
            this.lblSucheMandantName = new KiSS4.Gui.KissLabel();
            this.lblSucheBezugsperiode = new KiSS4.Gui.KissLabel();
            this.lblSucheBelegstatus = new KiSS4.Gui.KissLabel();
            this.edtPersPLZ = new KiSS4.Gui.KissTextEdit();
            this.edtAuszPLZ = new KiSS4.Gui.KissTextEdit();
            this.edtAuszOrt = new KiSS4.Gui.KissTextEdit();
            this.panDetail = new System.Windows.Forms.Panel();
            this.chkDruckvorschau = new KiSS4.Gui.KissCheckEdit();
            this.edtPersGeburtsdatum = new KiSS4.Gui.KissDateEdit();
            this.edtDatumAuszahlung = new KiSS4.Gui.KissDateEdit();
            this.edtHaben = new KiSS4.Gui.KissButtonEdit();
            this.edtSoll = new KiSS4.Gui.KissButtonEdit();
            this.edtSucheDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtSucheDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtSucheMandant = new KiSS4.Gui.KissButtonEdit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegAuszDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegBewilligtDurch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegMandTraeger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelBeleg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPlzOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAHVNummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelUnterstPers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBewilligtDurch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVmKasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMandatstraeger.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersAHVNummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersNameVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersVersNummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersNummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegAuszDurch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuszahlungDurch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuszPlzOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuszStrasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuszNameVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelAuszAn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuszStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuszNameVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHabenName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegHaben)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegSoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAuszNichtKlient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBarzahlungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBarzahlungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheVerbucht.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheNichtVerbucht.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMandant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMandantName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBezugsperiode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBelegstatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersPLZ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuszPLZ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuszOrt.Properties)).BeginInit();
            this.panDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkDruckvorschau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersGeburtsdatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumAuszahlung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHaben.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSoll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMandant.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(942, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.Size = new System.Drawing.Size(966, 292);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdBarzahlungen);
            this.tpgListe.Size = new System.Drawing.Size(954, 254);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtSucheMandant);
            this.tpgSuchen.Controls.Add(this.edtSucheDatumBis);
            this.tpgSuchen.Controls.Add(this.edtSucheDatumVon);
            this.tpgSuchen.Controls.Add(this.lblSucheBelegstatus);
            this.tpgSuchen.Controls.Add(this.lblSucheBezugsperiode);
            this.tpgSuchen.Controls.Add(this.lblSucheMandantName);
            this.tpgSuchen.Controls.Add(this.lblSucheDatumVon);
            this.tpgSuchen.Controls.Add(this.lblSucheDatumBis);
            this.tpgSuchen.Controls.Add(this.lblSucheMandant);
            this.tpgSuchen.Controls.Add(this.chkSucheNichtVerbucht);
            this.tpgSuchen.Controls.Add(this.chkSucheVerbucht);
            this.tpgSuchen.Size = new System.Drawing.Size(954, 254);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.chkSucheVerbucht, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkSucheNichtVerbucht, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheMandant, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheMandantName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBezugsperiode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBelegstatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheMandant, 0);
            // 
            // btnAuszahlen
            // 
            this.btnAuszahlen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAuszahlen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuszahlen.Location = new System.Drawing.Point(618, 296);
            this.btnAuszahlen.Name = "btnAuszahlen";
            this.btnAuszahlen.Size = new System.Drawing.Size(94, 24);
            this.btnAuszahlen.TabIndex = 33;
            this.btnAuszahlen.Text = "Auszahlen";
            this.btnAuszahlen.UseCompatibleTextRendering = true;
            this.btnAuszahlen.UseVisualStyleBackColor = false;
            this.btnAuszahlen.Click += new System.EventHandler(this.btnAuszahlen_Click);
            // 
            // lblBelegAuszDatum
            // 
            this.lblBelegAuszDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBelegAuszDatum.Location = new System.Drawing.Point(336, 151);
            this.lblBelegAuszDatum.Name = "lblBelegAuszDatum";
            this.lblBelegAuszDatum.Size = new System.Drawing.Size(66, 24);
            this.lblBelegAuszDatum.TabIndex = 80;
            this.lblBelegAuszDatum.Text = "Auszahlung";
            this.lblBelegAuszDatum.UseCompatibleTextRendering = true;
            // 
            // lblBelegBewilligtDurch
            // 
            this.lblBelegBewilligtDurch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBelegBewilligtDurch.Location = new System.Drawing.Point(335, 211);
            this.lblBelegBewilligtDurch.Name = "lblBelegBewilligtDurch";
            this.lblBelegBewilligtDurch.Size = new System.Drawing.Size(88, 24);
            this.lblBelegBewilligtDurch.TabIndex = 79;
            this.lblBelegBewilligtDurch.Text = "Bewilligt durch";
            this.lblBelegBewilligtDurch.UseCompatibleTextRendering = true;
            // 
            // lblBelegMandTraeger
            // 
            this.lblBelegMandTraeger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBelegMandTraeger.Location = new System.Drawing.Point(335, 181);
            this.lblBelegMandTraeger.Name = "lblBelegMandTraeger";
            this.lblBelegMandTraeger.Size = new System.Drawing.Size(88, 24);
            this.lblBelegMandTraeger.TabIndex = 78;
            this.lblBelegMandTraeger.Text = "Mandatsträger";
            this.lblBelegMandTraeger.UseCompatibleTextRendering = true;
            // 
            // lblTitelBeleg
            // 
            this.lblTitelBeleg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTitelBeleg.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTitelBeleg.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblTitelBeleg.Location = new System.Drawing.Point(335, 18);
            this.lblTitelBeleg.Name = "lblTitelBeleg";
            this.lblTitelBeleg.Size = new System.Drawing.Size(156, 17);
            this.lblTitelBeleg.TabIndex = 77;
            this.lblTitelBeleg.Text = "Beleg";
            this.lblTitelBeleg.UseCompatibleTextRendering = true;
            // 
            // lblPlzOrt
            // 
            this.lblPlzOrt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPlzOrt.Location = new System.Drawing.Point(12, 84);
            this.lblPlzOrt.Name = "lblPlzOrt";
            this.lblPlzOrt.Size = new System.Drawing.Size(66, 24);
            this.lblPlzOrt.TabIndex = 74;
            this.lblPlzOrt.Text = "PLZ / Ort";
            this.lblPlzOrt.UseCompatibleTextRendering = true;
            // 
            // lblStrasse
            // 
            this.lblStrasse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStrasse.Location = new System.Drawing.Point(12, 61);
            this.lblStrasse.Name = "lblStrasse";
            this.lblStrasse.Size = new System.Drawing.Size(66, 24);
            this.lblStrasse.TabIndex = 73;
            this.lblStrasse.Text = "Strasse";
            this.lblStrasse.UseCompatibleTextRendering = true;
            // 
            // lblAHVNummer
            // 
            this.lblAHVNummer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAHVNummer.Location = new System.Drawing.Point(12, 144);
            this.lblAHVNummer.Name = "lblAHVNummer";
            this.lblAHVNummer.Size = new System.Drawing.Size(74, 24);
            this.lblAHVNummer.TabIndex = 72;
            this.lblAHVNummer.Text = "AHV-Nummer";
            this.lblAHVNummer.UseCompatibleTextRendering = true;
            // 
            // lblGeburtsdatum
            // 
            this.lblGeburtsdatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGeburtsdatum.Location = new System.Drawing.Point(12, 114);
            this.lblGeburtsdatum.Name = "lblGeburtsdatum";
            this.lblGeburtsdatum.Size = new System.Drawing.Size(74, 24);
            this.lblGeburtsdatum.TabIndex = 71;
            this.lblGeburtsdatum.Text = "Geburtsdatum";
            this.lblGeburtsdatum.UseCompatibleTextRendering = true;
            // 
            // lblNameVorname
            // 
            this.lblNameVorname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNameVorname.Location = new System.Drawing.Point(12, 38);
            this.lblNameVorname.Name = "lblNameVorname";
            this.lblNameVorname.Size = new System.Drawing.Size(66, 24);
            this.lblNameVorname.TabIndex = 70;
            this.lblNameVorname.Text = "Name";
            this.lblNameVorname.UseCompatibleTextRendering = true;
            // 
            // lblTitelUnterstPers
            // 
            this.lblTitelUnterstPers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTitelUnterstPers.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTitelUnterstPers.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblTitelUnterstPers.Location = new System.Drawing.Point(12, 18);
            this.lblTitelUnterstPers.Name = "lblTitelUnterstPers";
            this.lblTitelUnterstPers.Size = new System.Drawing.Size(156, 20);
            this.lblTitelUnterstPers.TabIndex = 69;
            this.lblTitelUnterstPers.Text = "unterstützte Person";
            this.lblTitelUnterstPers.UseCompatibleTextRendering = true;
            // 
            // btnBelegDrucken
            // 
            this.btnBelegDrucken.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBelegDrucken.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBelegDrucken.Location = new System.Drawing.Point(718, 296);
            this.btnBelegDrucken.Name = "btnBelegDrucken";
            this.btnBelegDrucken.Size = new System.Drawing.Size(114, 24);
            this.btnBelegDrucken.TabIndex = 35;
            this.btnBelegDrucken.Text = "Kassenbeleg";
            this.btnBelegDrucken.UseCompatibleTextRendering = true;
            this.btnBelegDrucken.UseVisualStyleBackColor = false;
            this.btnBelegDrucken.Click += new System.EventHandler(this.btnBelegDrucken_Click);
            // 
            // btnZuBarauszahlung
            // 
            this.btnZuBarauszahlung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnZuBarauszahlung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZuBarauszahlung.Location = new System.Drawing.Point(519, 296);
            this.btnZuBarauszahlung.Name = "btnZuBarauszahlung";
            this.btnZuBarauszahlung.Size = new System.Drawing.Size(94, 24);
            this.btnZuBarauszahlung.TabIndex = 32;
            this.btnZuBarauszahlung.Text = "> Barbelege";
            this.btnZuBarauszahlung.UseCompatibleTextRendering = true;
            this.btnZuBarauszahlung.UseVisualStyleBackColor = false;
            this.btnZuBarauszahlung.Click += new System.EventHandler(this.btnZuBarauszahlung_Click);
            // 
            // edtBewilligtDurch
            // 
            this.edtBewilligtDurch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBewilligtDurch.DataSource = this.qryVmKasse;
            this.edtBewilligtDurch.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBewilligtDurch.Location = new System.Drawing.Point(442, 211);
            this.edtBewilligtDurch.Name = "edtBewilligtDurch";
            this.edtBewilligtDurch.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBewilligtDurch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBewilligtDurch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBewilligtDurch.Properties.Appearance.Options.UseBackColor = true;
            this.edtBewilligtDurch.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBewilligtDurch.Properties.Appearance.Options.UseFont = true;
            this.edtBewilligtDurch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBewilligtDurch.Properties.ReadOnly = true;
            this.edtBewilligtDurch.Size = new System.Drawing.Size(390, 24);
            this.edtBewilligtDurch.TabIndex = 25;
            // 
            // qryVmKasse
            // 
            this.qryVmKasse.HostControl = this;
            this.qryVmKasse.IsIdentityInsert = false;
            this.qryVmKasse.AfterFill += new System.EventHandler(this.qryVmKasse_AfterFill);
            this.qryVmKasse.PositionChanged += new System.EventHandler(this.qryVmKasse_PositionChanged);
            this.qryVmKasse.PositionChanging += new System.EventHandler(this.qryVmKasse_PositionChanging);
            // 
            // edtMandatstraeger
            // 
            this.edtMandatstraeger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtMandatstraeger.DataSource = this.qryVmKasse;
            this.edtMandatstraeger.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtMandatstraeger.Location = new System.Drawing.Point(442, 181);
            this.edtMandatstraeger.Name = "edtMandatstraeger";
            this.edtMandatstraeger.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtMandatstraeger.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMandatstraeger.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMandatstraeger.Properties.Appearance.Options.UseBackColor = true;
            this.edtMandatstraeger.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMandatstraeger.Properties.Appearance.Options.UseFont = true;
            this.edtMandatstraeger.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMandatstraeger.Properties.ReadOnly = true;
            this.edtMandatstraeger.Size = new System.Drawing.Size(390, 24);
            this.edtMandatstraeger.TabIndex = 24;
            // 
            // edtPersAHVNummer
            // 
            this.edtPersAHVNummer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtPersAHVNummer.DataSource = this.qryVmKasse;
            this.edtPersAHVNummer.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPersAHVNummer.Location = new System.Drawing.Point(92, 144);
            this.edtPersAHVNummer.Name = "edtPersAHVNummer";
            this.edtPersAHVNummer.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPersAHVNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPersAHVNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPersAHVNummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtPersAHVNummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPersAHVNummer.Properties.Appearance.Options.UseFont = true;
            this.edtPersAHVNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPersAHVNummer.Properties.ReadOnly = true;
            this.edtPersAHVNummer.Size = new System.Drawing.Size(138, 24);
            this.edtPersAHVNummer.TabIndex = 15;
            // 
            // edtPersOrt
            // 
            this.edtPersOrt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtPersOrt.DataSource = this.qryVmKasse;
            this.edtPersOrt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPersOrt.Location = new System.Drawing.Point(153, 84);
            this.edtPersOrt.Name = "edtPersOrt";
            this.edtPersOrt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPersOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPersOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPersOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtPersOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPersOrt.Properties.Appearance.Options.UseFont = true;
            this.edtPersOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPersOrt.Properties.ReadOnly = true;
            this.edtPersOrt.Size = new System.Drawing.Size(142, 24);
            this.edtPersOrt.TabIndex = 13;
            // 
            // edtPersStrasse
            // 
            this.edtPersStrasse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtPersStrasse.DataSource = this.qryVmKasse;
            this.edtPersStrasse.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPersStrasse.Location = new System.Drawing.Point(92, 61);
            this.edtPersStrasse.Name = "edtPersStrasse";
            this.edtPersStrasse.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPersStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPersStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPersStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtPersStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPersStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtPersStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPersStrasse.Properties.ReadOnly = true;
            this.edtPersStrasse.Size = new System.Drawing.Size(203, 24);
            this.edtPersStrasse.TabIndex = 11;
            // 
            // edtPersNameVorname
            // 
            this.edtPersNameVorname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtPersNameVorname.DataSource = this.qryVmKasse;
            this.edtPersNameVorname.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPersNameVorname.Location = new System.Drawing.Point(92, 38);
            this.edtPersNameVorname.Name = "edtPersNameVorname";
            this.edtPersNameVorname.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPersNameVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPersNameVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPersNameVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtPersNameVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPersNameVorname.Properties.Appearance.Options.UseFont = true;
            this.edtPersNameVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPersNameVorname.Properties.ReadOnly = true;
            this.edtPersNameVorname.Size = new System.Drawing.Size(203, 24);
            this.edtPersNameVorname.TabIndex = 10;
            // 
            // edtPersVersNummer
            // 
            this.edtPersVersNummer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtPersVersNummer.DataSource = this.qryVmKasse;
            this.edtPersVersNummer.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPersVersNummer.EditValue = "";
            this.edtPersVersNummer.Location = new System.Drawing.Point(92, 174);
            this.edtPersVersNummer.Name = "edtPersVersNummer";
            this.edtPersVersNummer.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPersVersNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPersVersNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPersVersNummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtPersVersNummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPersVersNummer.Properties.Appearance.Options.UseFont = true;
            this.edtPersVersNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPersVersNummer.Properties.ReadOnly = true;
            this.edtPersVersNummer.Size = new System.Drawing.Size(138, 24);
            this.edtPersVersNummer.TabIndex = 16;
            // 
            // lblVersNummer
            // 
            this.lblVersNummer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVersNummer.Location = new System.Drawing.Point(12, 174);
            this.lblVersNummer.Name = "lblVersNummer";
            this.lblVersNummer.Size = new System.Drawing.Size(74, 24);
            this.lblVersNummer.TabIndex = 83;
            this.lblVersNummer.Text = "Vers. Nummer";
            this.lblVersNummer.UseCompatibleTextRendering = true;
            // 
            // lblBelegBetrag
            // 
            this.lblBelegBetrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBelegBetrag.Location = new System.Drawing.Point(335, 91);
            this.lblBelegBetrag.Name = "lblBelegBetrag";
            this.lblBelegBetrag.Size = new System.Drawing.Size(88, 24);
            this.lblBelegBetrag.TabIndex = 85;
            this.lblBelegBetrag.Text = "Betrag CHF";
            this.lblBelegBetrag.UseCompatibleTextRendering = true;
            // 
            // edtBetrag
            // 
            this.edtBetrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBetrag.DataSource = this.qryVmKasse;
            this.edtBetrag.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBetrag.Location = new System.Drawing.Point(442, 91);
            this.edtBetrag.Name = "edtBetrag";
            this.edtBetrag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetrag.Properties.DisplayFormat.FormatString = "n2";
            this.edtBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Properties.ReadOnly = true;
            this.edtBetrag.Size = new System.Drawing.Size(224, 24);
            this.edtBetrag.TabIndex = 21;
            // 
            // lblBelegText
            // 
            this.lblBelegText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBelegText.Location = new System.Drawing.Point(335, 121);
            this.lblBelegText.Name = "lblBelegText";
            this.lblBelegText.Size = new System.Drawing.Size(88, 24);
            this.lblBelegText.TabIndex = 87;
            this.lblBelegText.Text = "Buchungstext";
            this.lblBelegText.UseCompatibleTextRendering = true;
            // 
            // edtBuchungstext
            // 
            this.edtBuchungstext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBuchungstext.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBuchungstext.Location = new System.Drawing.Point(442, 121);
            this.edtBuchungstext.Name = "edtBuchungstext";
            this.edtBuchungstext.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBuchungstext.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchungstext.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchungstext.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchungstext.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchungstext.Properties.Appearance.Options.UseFont = true;
            this.edtBuchungstext.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBuchungstext.Properties.ReadOnly = true;
            this.edtBuchungstext.Size = new System.Drawing.Size(390, 24);
            this.edtBuchungstext.TabIndex = 22;
            // 
            // lblBelegAuszDurch
            // 
            this.lblBelegAuszDurch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBelegAuszDurch.Location = new System.Drawing.Point(335, 241);
            this.lblBelegAuszDurch.Name = "lblBelegAuszDurch";
            this.lblBelegAuszDurch.Size = new System.Drawing.Size(101, 24);
            this.lblBelegAuszDurch.TabIndex = 89;
            this.lblBelegAuszDurch.Text = "Auszahlung durch";
            this.lblBelegAuszDurch.UseCompatibleTextRendering = true;
            // 
            // edtAuszahlungDurch
            // 
            this.edtAuszahlungDurch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAuszahlungDurch.DataSource = this.qryVmKasse;
            this.edtAuszahlungDurch.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAuszahlungDurch.Location = new System.Drawing.Point(442, 241);
            this.edtAuszahlungDurch.Name = "edtAuszahlungDurch";
            this.edtAuszahlungDurch.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAuszahlungDurch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAuszahlungDurch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuszahlungDurch.Properties.Appearance.Options.UseBackColor = true;
            this.edtAuszahlungDurch.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAuszahlungDurch.Properties.Appearance.Options.UseFont = true;
            this.edtAuszahlungDurch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAuszahlungDurch.Properties.ReadOnly = true;
            this.edtAuszahlungDurch.Size = new System.Drawing.Size(390, 24);
            this.edtAuszahlungDurch.TabIndex = 26;
            // 
            // lblAuszPlzOrt
            // 
            this.lblAuszPlzOrt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAuszPlzOrt.Location = new System.Drawing.Point(12, 296);
            this.lblAuszPlzOrt.Name = "lblAuszPlzOrt";
            this.lblAuszPlzOrt.Size = new System.Drawing.Size(66, 24);
            this.lblAuszPlzOrt.TabIndex = 96;
            this.lblAuszPlzOrt.Text = "PLZ / Ort";
            this.lblAuszPlzOrt.UseCompatibleTextRendering = true;
            // 
            // lblAuszStrasse
            // 
            this.lblAuszStrasse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAuszStrasse.Location = new System.Drawing.Point(12, 273);
            this.lblAuszStrasse.Name = "lblAuszStrasse";
            this.lblAuszStrasse.Size = new System.Drawing.Size(66, 24);
            this.lblAuszStrasse.TabIndex = 95;
            this.lblAuszStrasse.Text = "Strasse";
            this.lblAuszStrasse.UseCompatibleTextRendering = true;
            // 
            // lblAuszNameVorname
            // 
            this.lblAuszNameVorname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAuszNameVorname.Location = new System.Drawing.Point(12, 250);
            this.lblAuszNameVorname.Name = "lblAuszNameVorname";
            this.lblAuszNameVorname.Size = new System.Drawing.Size(66, 24);
            this.lblAuszNameVorname.TabIndex = 94;
            this.lblAuszNameVorname.Text = "Name";
            this.lblAuszNameVorname.UseCompatibleTextRendering = true;
            // 
            // lblTitelAuszAn
            // 
            this.lblTitelAuszAn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTitelAuszAn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTitelAuszAn.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblTitelAuszAn.Location = new System.Drawing.Point(12, 228);
            this.lblTitelAuszAn.Name = "lblTitelAuszAn";
            this.lblTitelAuszAn.Size = new System.Drawing.Size(156, 20);
            this.lblTitelAuszAn.TabIndex = 93;
            this.lblTitelAuszAn.Text = "Auszahlung an";
            this.lblTitelAuszAn.UseCompatibleTextRendering = true;
            // 
            // edtAuszStrasse
            // 
            this.edtAuszStrasse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAuszStrasse.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAuszStrasse.Location = new System.Drawing.Point(92, 273);
            this.edtAuszStrasse.Name = "edtAuszStrasse";
            this.edtAuszStrasse.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAuszStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAuszStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuszStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtAuszStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAuszStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtAuszStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAuszStrasse.Properties.ReadOnly = true;
            this.edtAuszStrasse.Size = new System.Drawing.Size(203, 24);
            this.edtAuszStrasse.TabIndex = 29;
            // 
            // edtAuszNameVorname
            // 
            this.edtAuszNameVorname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAuszNameVorname.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAuszNameVorname.Location = new System.Drawing.Point(92, 250);
            this.edtAuszNameVorname.Name = "edtAuszNameVorname";
            this.edtAuszNameVorname.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAuszNameVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAuszNameVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuszNameVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtAuszNameVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAuszNameVorname.Properties.Appearance.Options.UseFont = true;
            this.edtAuszNameVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAuszNameVorname.Properties.ReadOnly = true;
            this.edtAuszNameVorname.Size = new System.Drawing.Size(203, 24);
            this.edtAuszNameVorname.TabIndex = 28;
            // 
            // edtHabenName
            // 
            this.edtHabenName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtHabenName.DataSource = this.qryVmKasse;
            this.edtHabenName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtHabenName.EditValue = "";
            this.edtHabenName.Location = new System.Drawing.Point(541, 61);
            this.edtHabenName.Name = "edtHabenName";
            this.edtHabenName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtHabenName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHabenName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHabenName.Properties.Appearance.Options.UseBackColor = true;
            this.edtHabenName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHabenName.Properties.Appearance.Options.UseFont = true;
            this.edtHabenName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHabenName.Properties.ReadOnly = true;
            this.edtHabenName.Size = new System.Drawing.Size(291, 24);
            this.edtHabenName.TabIndex = 20;
            this.edtHabenName.TabStop = false;
            // 
            // edtSollName
            // 
            this.edtSollName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSollName.DataSource = this.qryVmKasse;
            this.edtSollName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtSollName.EditValue = "";
            this.edtSollName.Location = new System.Drawing.Point(541, 38);
            this.edtSollName.Name = "edtSollName";
            this.edtSollName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSollName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSollName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSollName.Properties.Appearance.Options.UseBackColor = true;
            this.edtSollName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSollName.Properties.Appearance.Options.UseFont = true;
            this.edtSollName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSollName.Properties.ReadOnly = true;
            this.edtSollName.Size = new System.Drawing.Size(291, 24);
            this.edtSollName.TabIndex = 18;
            this.edtSollName.TabStop = false;
            // 
            // lblBelegHaben
            // 
            this.lblBelegHaben.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBelegHaben.Location = new System.Drawing.Point(335, 61);
            this.lblBelegHaben.Name = "lblBelegHaben";
            this.lblBelegHaben.Size = new System.Drawing.Size(88, 24);
            this.lblBelegHaben.TabIndex = 243;
            this.lblBelegHaben.Text = "Haben";
            this.lblBelegHaben.UseCompatibleTextRendering = true;
            // 
            // lblBelegSoll
            // 
            this.lblBelegSoll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBelegSoll.Location = new System.Drawing.Point(335, 38);
            this.lblBelegSoll.Name = "lblBelegSoll";
            this.lblBelegSoll.Size = new System.Drawing.Size(88, 24);
            this.lblBelegSoll.TabIndex = 244;
            this.lblBelegSoll.Text = "Soll";
            this.lblBelegSoll.UseCompatibleTextRendering = true;
            // 
            // chkAuszNichtKlient
            // 
            this.chkAuszNichtKlient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAuszNichtKlient.EditValue = false;
            this.chkAuszNichtKlient.Location = new System.Drawing.Point(178, 227);
            this.chkAuszNichtKlient.Name = "chkAuszNichtKlient";
            this.chkAuszNichtKlient.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkAuszNichtKlient.Properties.Appearance.Options.UseBackColor = true;
            this.chkAuszNichtKlient.Properties.Caption = "Nicht an Klient";
            this.chkAuszNichtKlient.Size = new System.Drawing.Size(117, 19);
            this.chkAuszNichtKlient.TabIndex = 27;
            this.chkAuszNichtKlient.CheckedChanged += new System.EventHandler(this.chkAuszNichtKlient_CheckedChanged);
            // 
            // grdBarzahlungen
            // 
            this.grdBarzahlungen.DataSource = this.qryVmKasse;
            this.grdBarzahlungen.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdBarzahlungen.EmbeddedNavigator.Name = "";
            this.grdBarzahlungen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBarzahlungen.Location = new System.Drawing.Point(0, 0);
            this.grdBarzahlungen.MainView = this.grvBarzahlungen;
            this.grdBarzahlungen.Name = "grdBarzahlungen";
            this.grdBarzahlungen.Size = new System.Drawing.Size(954, 254);
            this.grdBarzahlungen.TabIndex = 0;
            this.grdBarzahlungen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBarzahlungen});
            // 
            // grvBarzahlungen
            // 
            this.grvBarzahlungen.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBarzahlungen.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBarzahlungen.Appearance.Empty.Options.UseBackColor = true;
            this.grvBarzahlungen.Appearance.Empty.Options.UseFont = true;
            this.grvBarzahlungen.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBarzahlungen.Appearance.EvenRow.Options.UseFont = true;
            this.grvBarzahlungen.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBarzahlungen.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBarzahlungen.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBarzahlungen.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBarzahlungen.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBarzahlungen.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBarzahlungen.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBarzahlungen.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBarzahlungen.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBarzahlungen.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBarzahlungen.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBarzahlungen.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBarzahlungen.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBarzahlungen.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBarzahlungen.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvBarzahlungen.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvBarzahlungen.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBarzahlungen.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBarzahlungen.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBarzahlungen.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBarzahlungen.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBarzahlungen.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBarzahlungen.Appearance.GroupRow.Options.UseFont = true;
            this.grvBarzahlungen.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBarzahlungen.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBarzahlungen.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBarzahlungen.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBarzahlungen.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBarzahlungen.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBarzahlungen.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBarzahlungen.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBarzahlungen.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBarzahlungen.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBarzahlungen.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBarzahlungen.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBarzahlungen.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBarzahlungen.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBarzahlungen.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBarzahlungen.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBarzahlungen.Appearance.OddRow.Options.UseFont = true;
            this.grvBarzahlungen.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBarzahlungen.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBarzahlungen.Appearance.Row.Options.UseBackColor = true;
            this.grvBarzahlungen.Appearance.Row.Options.UseFont = true;
            this.grvBarzahlungen.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBarzahlungen.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBarzahlungen.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBarzahlungen.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBarzahlungen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBarzahlungen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBelegNr,
            this.colMandant,
            this.colStichtag,
            this.colText,
            this.colAuszahlungAb,
            this.colAuszahlungBis,
            this.colBewilligtVon,
            this.colBetrag,
            this.colAuszahlungsdatum,
            this.colStatus});
            this.grvBarzahlungen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBarzahlungen.GridControl = this.grdBarzahlungen;
            this.grvBarzahlungen.Name = "grvBarzahlungen";
            this.grvBarzahlungen.OptionsBehavior.Editable = false;
            this.grvBarzahlungen.OptionsCustomization.AllowFilter = false;
            this.grvBarzahlungen.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBarzahlungen.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBarzahlungen.OptionsNavigation.UseTabKey = false;
            this.grvBarzahlungen.OptionsView.ColumnAutoWidth = false;
            this.grvBarzahlungen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBarzahlungen.OptionsView.ShowGroupPanel = false;
            this.grvBarzahlungen.OptionsView.ShowIndicator = false;
            // 
            // colBelegNr
            // 
            this.colBelegNr.Caption = "Beleg-Nr";
            this.colBelegNr.Name = "colBelegNr";
            this.colBelegNr.OptionsColumn.FixedWidth = true;
            this.colBelegNr.Visible = true;
            this.colBelegNr.VisibleIndex = 0;
            this.colBelegNr.Width = 80;
            // 
            // colMandant
            // 
            this.colMandant.Caption = "Mandant";
            this.colMandant.Name = "colMandant";
            this.colMandant.Visible = true;
            this.colMandant.VisibleIndex = 1;
            this.colMandant.Width = 90;
            // 
            // colStichtag
            // 
            this.colStichtag.Caption = "Stichtag";
            this.colStichtag.Name = "colStichtag";
            this.colStichtag.OptionsColumn.FixedWidth = true;
            this.colStichtag.Visible = true;
            this.colStichtag.VisibleIndex = 2;
            this.colStichtag.Width = 74;
            // 
            // colText
            // 
            this.colText.Caption = "Text";
            this.colText.Name = "colText";
            this.colText.Visible = true;
            this.colText.VisibleIndex = 3;
            this.colText.Width = 128;
            // 
            // colAuszahlungAb
            // 
            this.colAuszahlungAb.Caption = "Auszahlung ab";
            this.colAuszahlungAb.Name = "colAuszahlungAb";
            this.colAuszahlungAb.OptionsColumn.FixedWidth = true;
            this.colAuszahlungAb.Visible = true;
            this.colAuszahlungAb.VisibleIndex = 4;
            this.colAuszahlungAb.Width = 92;
            // 
            // colAuszahlungBis
            // 
            this.colAuszahlungBis.Caption = "Auszahlung bis";
            this.colAuszahlungBis.Name = "colAuszahlungBis";
            this.colAuszahlungBis.OptionsColumn.FixedWidth = true;
            this.colAuszahlungBis.Visible = true;
            this.colAuszahlungBis.VisibleIndex = 5;
            this.colAuszahlungBis.Width = 95;
            // 
            // colBewilligtVon
            // 
            this.colBewilligtVon.Caption = "Bewilligt von";
            this.colBewilligtVon.Name = "colBewilligtVon";
            this.colBewilligtVon.Visible = true;
            this.colBewilligtVon.VisibleIndex = 6;
            this.colBewilligtVon.Width = 82;
            // 
            // colBetrag
            // 
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "n2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 7;
            this.colBetrag.Width = 65;
            // 
            // colAuszahlungsdatum
            // 
            this.colAuszahlungsdatum.Caption = "Auszahl.datum";
            this.colAuszahlungsdatum.Name = "colAuszahlungsdatum";
            this.colAuszahlungsdatum.OptionsColumn.FixedWidth = true;
            this.colAuszahlungsdatum.Visible = true;
            this.colAuszahlungsdatum.VisibleIndex = 8;
            this.colAuszahlungsdatum.Width = 94;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.OptionsColumn.FixedWidth = true;
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 9;
            this.colStatus.Width = 146;
            // 
            // chkSucheVerbucht
            // 
            this.chkSucheVerbucht.EditValue = false;
            this.chkSucheVerbucht.Location = new System.Drawing.Point(455, 63);
            this.chkSucheVerbucht.Name = "chkSucheVerbucht";
            this.chkSucheVerbucht.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkSucheVerbucht.Properties.Appearance.Options.UseBackColor = true;
            this.chkSucheVerbucht.Properties.Caption = "Verbucht";
            this.chkSucheVerbucht.Size = new System.Drawing.Size(156, 19);
            this.chkSucheVerbucht.TabIndex = 4;
            // 
            // chkSucheNichtVerbucht
            // 
            this.chkSucheNichtVerbucht.EditValue = false;
            this.chkSucheNichtVerbucht.Location = new System.Drawing.Point(455, 88);
            this.chkSucheNichtVerbucht.Name = "chkSucheNichtVerbucht";
            this.chkSucheNichtVerbucht.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkSucheNichtVerbucht.Properties.Appearance.Options.UseBackColor = true;
            this.chkSucheNichtVerbucht.Properties.Caption = "Nicht Verbucht";
            this.chkSucheNichtVerbucht.Size = new System.Drawing.Size(156, 19);
            this.chkSucheNichtVerbucht.TabIndex = 5;
            // 
            // lblSucheMandant
            // 
            this.lblSucheMandant.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblSucheMandant.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSucheMandant.Location = new System.Drawing.Point(30, 40);
            this.lblSucheMandant.Name = "lblSucheMandant";
            this.lblSucheMandant.Size = new System.Drawing.Size(156, 20);
            this.lblSucheMandant.TabIndex = 70;
            this.lblSucheMandant.Text = "Mandant";
            this.lblSucheMandant.UseCompatibleTextRendering = true;
            // 
            // lblSucheDatumBis
            // 
            this.lblSucheDatumBis.Location = new System.Drawing.Point(30, 165);
            this.lblSucheDatumBis.Name = "lblSucheDatumBis";
            this.lblSucheDatumBis.Size = new System.Drawing.Size(66, 24);
            this.lblSucheDatumBis.TabIndex = 73;
            this.lblSucheDatumBis.Text = "bis";
            this.lblSucheDatumBis.UseCompatibleTextRendering = true;
            // 
            // lblSucheDatumVon
            // 
            this.lblSucheDatumVon.Location = new System.Drawing.Point(30, 135);
            this.lblSucheDatumVon.Name = "lblSucheDatumVon";
            this.lblSucheDatumVon.Size = new System.Drawing.Size(66, 24);
            this.lblSucheDatumVon.TabIndex = 74;
            this.lblSucheDatumVon.Text = "von";
            this.lblSucheDatumVon.UseCompatibleTextRendering = true;
            // 
            // lblSucheMandantName
            // 
            this.lblSucheMandantName.Location = new System.Drawing.Point(30, 63);
            this.lblSucheMandantName.Name = "lblSucheMandantName";
            this.lblSucheMandantName.Size = new System.Drawing.Size(66, 24);
            this.lblSucheMandantName.TabIndex = 75;
            this.lblSucheMandantName.Text = "Name";
            this.lblSucheMandantName.UseCompatibleTextRendering = true;
            // 
            // lblSucheBezugsperiode
            // 
            this.lblSucheBezugsperiode.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblSucheBezugsperiode.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSucheBezugsperiode.Location = new System.Drawing.Point(30, 112);
            this.lblSucheBezugsperiode.Name = "lblSucheBezugsperiode";
            this.lblSucheBezugsperiode.Size = new System.Drawing.Size(156, 20);
            this.lblSucheBezugsperiode.TabIndex = 76;
            this.lblSucheBezugsperiode.Text = "Bezugsperiode";
            this.lblSucheBezugsperiode.UseCompatibleTextRendering = true;
            // 
            // lblSucheBelegstatus
            // 
            this.lblSucheBelegstatus.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblSucheBelegstatus.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSucheBelegstatus.Location = new System.Drawing.Point(455, 40);
            this.lblSucheBelegstatus.Name = "lblSucheBelegstatus";
            this.lblSucheBelegstatus.Size = new System.Drawing.Size(156, 20);
            this.lblSucheBelegstatus.TabIndex = 77;
            this.lblSucheBelegstatus.Text = "Belegstatus";
            this.lblSucheBelegstatus.UseCompatibleTextRendering = true;
            // 
            // edtPersPLZ
            // 
            this.edtPersPLZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtPersPLZ.DataSource = this.qryVmKasse;
            this.edtPersPLZ.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPersPLZ.Location = new System.Drawing.Point(92, 84);
            this.edtPersPLZ.Name = "edtPersPLZ";
            this.edtPersPLZ.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPersPLZ.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPersPLZ.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPersPLZ.Properties.Appearance.Options.UseBackColor = true;
            this.edtPersPLZ.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPersPLZ.Properties.Appearance.Options.UseFont = true;
            this.edtPersPLZ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPersPLZ.Properties.ReadOnly = true;
            this.edtPersPLZ.Size = new System.Drawing.Size(63, 24);
            this.edtPersPLZ.TabIndex = 12;
            // 
            // edtAuszPLZ
            // 
            this.edtAuszPLZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAuszPLZ.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAuszPLZ.Location = new System.Drawing.Point(92, 296);
            this.edtAuszPLZ.Name = "edtAuszPLZ";
            this.edtAuszPLZ.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAuszPLZ.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAuszPLZ.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuszPLZ.Properties.Appearance.Options.UseBackColor = true;
            this.edtAuszPLZ.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAuszPLZ.Properties.Appearance.Options.UseFont = true;
            this.edtAuszPLZ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAuszPLZ.Properties.ReadOnly = true;
            this.edtAuszPLZ.Size = new System.Drawing.Size(63, 24);
            this.edtAuszPLZ.TabIndex = 30;
            // 
            // edtAuszOrt
            // 
            this.edtAuszOrt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAuszOrt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAuszOrt.Location = new System.Drawing.Point(153, 296);
            this.edtAuszOrt.Name = "edtAuszOrt";
            this.edtAuszOrt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAuszOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAuszOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuszOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtAuszOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAuszOrt.Properties.Appearance.Options.UseFont = true;
            this.edtAuszOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAuszOrt.Properties.ReadOnly = true;
            this.edtAuszOrt.Size = new System.Drawing.Size(142, 24);
            this.edtAuszOrt.TabIndex = 31;
            // 
            // panDetail
            // 
            this.panDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panDetail.Controls.Add(this.chkDruckvorschau);
            this.panDetail.Controls.Add(this.edtPersGeburtsdatum);
            this.panDetail.Controls.Add(this.edtDatumAuszahlung);
            this.panDetail.Controls.Add(this.edtHaben);
            this.panDetail.Controls.Add(this.edtSoll);
            this.panDetail.Controls.Add(this.lblBelegSoll);
            this.panDetail.Controls.Add(this.edtPersNameVorname);
            this.panDetail.Controls.Add(this.edtAuszPLZ);
            this.panDetail.Controls.Add(this.edtPersStrasse);
            this.panDetail.Controls.Add(this.edtAuszOrt);
            this.panDetail.Controls.Add(this.edtPersOrt);
            this.panDetail.Controls.Add(this.edtPersPLZ);
            this.panDetail.Controls.Add(this.chkAuszNichtKlient);
            this.panDetail.Controls.Add(this.edtPersAHVNummer);
            this.panDetail.Controls.Add(this.lblBelegHaben);
            this.panDetail.Controls.Add(this.edtMandatstraeger);
            this.panDetail.Controls.Add(this.edtBewilligtDurch);
            this.panDetail.Controls.Add(this.edtHabenName);
            this.panDetail.Controls.Add(this.btnZuBarauszahlung);
            this.panDetail.Controls.Add(this.edtSollName);
            this.panDetail.Controls.Add(this.btnBelegDrucken);
            this.panDetail.Controls.Add(this.lblTitelUnterstPers);
            this.panDetail.Controls.Add(this.lblAuszPlzOrt);
            this.panDetail.Controls.Add(this.lblNameVorname);
            this.panDetail.Controls.Add(this.lblAuszStrasse);
            this.panDetail.Controls.Add(this.lblGeburtsdatum);
            this.panDetail.Controls.Add(this.lblAuszNameVorname);
            this.panDetail.Controls.Add(this.lblAHVNummer);
            this.panDetail.Controls.Add(this.lblTitelAuszAn);
            this.panDetail.Controls.Add(this.lblStrasse);
            this.panDetail.Controls.Add(this.edtAuszStrasse);
            this.panDetail.Controls.Add(this.lblPlzOrt);
            this.panDetail.Controls.Add(this.edtAuszNameVorname);
            this.panDetail.Controls.Add(this.lblTitelBeleg);
            this.panDetail.Controls.Add(this.lblBelegAuszDurch);
            this.panDetail.Controls.Add(this.lblBelegMandTraeger);
            this.panDetail.Controls.Add(this.edtAuszahlungDurch);
            this.panDetail.Controls.Add(this.lblBelegBewilligtDurch);
            this.panDetail.Controls.Add(this.lblBelegText);
            this.panDetail.Controls.Add(this.lblBelegAuszDatum);
            this.panDetail.Controls.Add(this.edtBuchungstext);
            this.panDetail.Controls.Add(this.btnAuszahlen);
            this.panDetail.Controls.Add(this.lblBelegBetrag);
            this.panDetail.Controls.Add(this.edtPersVersNummer);
            this.panDetail.Controls.Add(this.edtBetrag);
            this.panDetail.Controls.Add(this.lblVersNummer);
            this.panDetail.Location = new System.Drawing.Point(0, 275);
            this.panDetail.Name = "panDetail";
            this.panDetail.Size = new System.Drawing.Size(966, 331);
            this.panDetail.TabIndex = 249;
            // 
            // chkDruckvorschau
            // 
            this.chkDruckvorschau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkDruckvorschau.EditValue = false;
            this.chkDruckvorschau.Location = new System.Drawing.Point(718, 272);
            this.chkDruckvorschau.Name = "chkDruckvorschau";
            this.chkDruckvorschau.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkDruckvorschau.Properties.Appearance.Options.UseBackColor = true;
            this.chkDruckvorschau.Properties.Caption = "Druckvorschau";
            this.chkDruckvorschau.Size = new System.Drawing.Size(112, 19);
            this.chkDruckvorschau.TabIndex = 34;
            this.chkDruckvorschau.Visible = false;
            // 
            // edtPersGeburtsdatum
            // 
            this.edtPersGeburtsdatum.DataSource = this.qryVmKasse;
            this.edtPersGeburtsdatum.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPersGeburtsdatum.EditValue = null;
            this.edtPersGeburtsdatum.Location = new System.Drawing.Point(92, 114);
            this.edtPersGeburtsdatum.Name = "edtPersGeburtsdatum";
            this.edtPersGeburtsdatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtPersGeburtsdatum.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPersGeburtsdatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPersGeburtsdatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPersGeburtsdatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtPersGeburtsdatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPersGeburtsdatum.Properties.Appearance.Options.UseFont = true;
            this.edtPersGeburtsdatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtPersGeburtsdatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtPersGeburtsdatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtPersGeburtsdatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPersGeburtsdatum.Properties.ReadOnly = true;
            this.edtPersGeburtsdatum.Properties.ShowToday = false;
            this.edtPersGeburtsdatum.Size = new System.Drawing.Size(138, 24);
            this.edtPersGeburtsdatum.TabIndex = 14;
            // 
            // edtDatumAuszahlung
            // 
            this.edtDatumAuszahlung.DataSource = this.qryVmKasse;
            this.edtDatumAuszahlung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtDatumAuszahlung.EditValue = null;
            this.edtDatumAuszahlung.Location = new System.Drawing.Point(442, 151);
            this.edtDatumAuszahlung.Name = "edtDatumAuszahlung";
            this.edtDatumAuszahlung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumAuszahlung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtDatumAuszahlung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumAuszahlung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumAuszahlung.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumAuszahlung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumAuszahlung.Properties.Appearance.Options.UseFont = true;
            this.edtDatumAuszahlung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtDatumAuszahlung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumAuszahlung.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtDatumAuszahlung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumAuszahlung.Properties.ReadOnly = true;
            this.edtDatumAuszahlung.Properties.ShowToday = false;
            this.edtDatumAuszahlung.Size = new System.Drawing.Size(100, 24);
            this.edtDatumAuszahlung.TabIndex = 23;
            // 
            // edtHaben
            // 
            this.edtHaben.DataSource = this.qryVmKasse;
            this.edtHaben.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtHaben.Location = new System.Drawing.Point(442, 61);
            this.edtHaben.Name = "edtHaben";
            this.edtHaben.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtHaben.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHaben.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHaben.Properties.Appearance.Options.UseBackColor = true;
            this.edtHaben.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHaben.Properties.Appearance.Options.UseFont = true;
            this.edtHaben.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtHaben.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtHaben.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtHaben.Properties.ReadOnly = true;
            this.edtHaben.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtHaben.Size = new System.Drawing.Size(93, 24);
            this.edtHaben.TabIndex = 19;
            this.edtHaben.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtHaben_UserModifiedFld);
            // 
            // edtSoll
            // 
            this.edtSoll.DataSource = this.qryVmKasse;
            this.edtSoll.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtSoll.Location = new System.Drawing.Point(442, 38);
            this.edtSoll.Name = "edtSoll";
            this.edtSoll.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSoll.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSoll.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSoll.Properties.Appearance.Options.UseBackColor = true;
            this.edtSoll.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSoll.Properties.Appearance.Options.UseFont = true;
            this.edtSoll.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtSoll.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtSoll.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSoll.Properties.ReadOnly = true;
            this.edtSoll.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSoll.Size = new System.Drawing.Size(93, 24);
            this.edtSoll.TabIndex = 17;
            this.edtSoll.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSoll_UserModifiedFld);
            // 
            // edtSucheDatumVon
            // 
            this.edtSucheDatumVon.EditValue = null;
            this.edtSucheDatumVon.Location = new System.Drawing.Point(102, 135);
            this.edtSucheDatumVon.Name = "edtSucheDatumVon";
            this.edtSucheDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtSucheDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtSucheDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheDatumVon.Properties.ShowToday = false;
            this.edtSucheDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtSucheDatumVon.TabIndex = 2;
            // 
            // edtSucheDatumBis
            // 
            this.edtSucheDatumBis.EditValue = null;
            this.edtSucheDatumBis.Location = new System.Drawing.Point(102, 165);
            this.edtSucheDatumBis.Name = "edtSucheDatumBis";
            this.edtSucheDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtSucheDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtSucheDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheDatumBis.Properties.ShowToday = false;
            this.edtSucheDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtSucheDatumBis.TabIndex = 3;
            // 
            // edtSucheMandant
            // 
            this.edtSucheMandant.Location = new System.Drawing.Point(102, 63);
            this.edtSucheMandant.Name = "edtSucheMandant";
            this.edtSucheMandant.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheMandant.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheMandant.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheMandant.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheMandant.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheMandant.Properties.Appearance.Options.UseFont = true;
            this.edtSucheMandant.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtSucheMandant.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtSucheMandant.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheMandant.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSucheMandant.Size = new System.Drawing.Size(292, 24);
            this.edtSucheMandant.TabIndex = 1;
            this.edtSucheMandant.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheMandant_UserModifiedFld);
            // 
            // CtlVmKasse
            // 
            this.ActiveSQLQuery = this.qryVmKasse;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(855, 500);
            this.Controls.Add(this.panDetail);
            this.Name = "CtlVmKasse";
            this.Size = new System.Drawing.Size(966, 606);
            this.Text = "VM Kasse";
            this.Load += new System.EventHandler(this.FrmVmKasse_Load);
            this.Controls.SetChildIndex(this.panDetail, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegAuszDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegBewilligtDurch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegMandTraeger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelBeleg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPlzOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAHVNummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelUnterstPers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBewilligtDurch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVmKasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMandatstraeger.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersAHVNummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersNameVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersVersNummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersNummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegAuszDurch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuszahlungDurch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuszPlzOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuszStrasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuszNameVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelAuszAn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuszStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuszNameVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHabenName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegHaben)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegSoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAuszNichtKlient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBarzahlungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBarzahlungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheVerbucht.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheNichtVerbucht.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMandant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMandantName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBezugsperiode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBelegstatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersPLZ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuszPLZ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuszOrt.Properties)).EndInit();
            this.panDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkDruckvorschau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersGeburtsdatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumAuszahlung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHaben.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSoll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMandant.Properties)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private KiSS4.Gui.KissButton btnAuszahlen;
        private KiSS4.Gui.KissLabel lblBelegAuszDatum;
        private KiSS4.Gui.KissLabel lblBelegBewilligtDurch;
        private KiSS4.Gui.KissLabel lblBelegMandTraeger;
        private KiSS4.Gui.KissLabel lblTitelBeleg;
        private KiSS4.Gui.KissLabel lblPlzOrt;
        private KiSS4.Gui.KissLabel lblStrasse;
        private KiSS4.Gui.KissLabel lblAHVNummer;
        private KiSS4.Gui.KissLabel lblGeburtsdatum;
        private KiSS4.Gui.KissLabel lblNameVorname;
        private KiSS4.Gui.KissLabel lblTitelUnterstPers;
        private KiSS4.Gui.KissButton btnBelegDrucken;
        private KiSS4.Gui.KissButton btnZuBarauszahlung;
        private KiSS4.Gui.KissTextEdit edtBewilligtDurch;
        private KiSS4.Gui.KissTextEdit edtMandatstraeger;
        private KiSS4.Gui.KissTextEdit edtPersAHVNummer;
        private KiSS4.Gui.KissTextEdit edtPersOrt;
        private KiSS4.Gui.KissTextEdit edtPersStrasse;
        private KiSS4.Gui.KissTextEdit edtPersNameVorname;
        private KiSS4.Gui.KissTextEdit edtPersVersNummer;
        private KiSS4.Gui.KissLabel lblVersNummer;
        private KiSS4.Gui.KissLabel lblBelegBetrag;
        private KiSS4.Gui.KissTextEdit edtBetrag;
        private KiSS4.Gui.KissLabel lblBelegText;
        private KiSS4.Gui.KissTextEdit edtBuchungstext;
        private KiSS4.Gui.KissLabel lblBelegAuszDurch;
        private KiSS4.Gui.KissTextEdit edtAuszahlungDurch;
        private KiSS4.Gui.KissLabel lblAuszPlzOrt;
        private KiSS4.Gui.KissLabel lblAuszStrasse;
        private KiSS4.Gui.KissLabel lblAuszNameVorname;
        private KiSS4.Gui.KissLabel lblTitelAuszAn;
        private KiSS4.Gui.KissTextEdit edtAuszStrasse;
        private KiSS4.Gui.KissTextEdit edtAuszNameVorname;
        private KiSS4.Gui.KissTextEdit edtHabenName;
        private KiSS4.Gui.KissTextEdit edtSollName;
        private KiSS4.Gui.KissLabel lblBelegHaben;
        private KiSS4.Gui.KissLabel lblBelegSoll;
        private KiSS4.Gui.KissCheckEdit chkAuszNichtKlient;
        private KiSS4.Gui.KissGrid grdBarzahlungen;
        private KiSS4.Gui.KissLabel lblSucheMandant;
        private KiSS4.Gui.KissCheckEdit chkSucheNichtVerbucht;
        private KiSS4.Gui.KissCheckEdit chkSucheVerbucht;
        private KiSS4.Gui.KissLabel lblSucheBezugsperiode;
        private KiSS4.Gui.KissLabel lblSucheMandantName;
        private KiSS4.Gui.KissLabel lblSucheDatumVon;
        private KiSS4.Gui.KissLabel lblSucheDatumBis;
        private KiSS4.Gui.KissLabel lblSucheBelegstatus;
        private KiSS4.Gui.KissTextEdit edtPersPLZ;
        private KiSS4.Gui.KissTextEdit edtAuszPLZ;
        private KiSS4.Gui.KissTextEdit edtAuszOrt;
        private System.Windows.Forms.Panel panDetail;
        private KiSS4.Gui.KissDateEdit edtSucheDatumVon;
        private KiSS4.Gui.KissButtonEdit edtSucheMandant;
        private KiSS4.Gui.KissDateEdit edtSucheDatumBis;
        private KiSS4.Gui.KissButtonEdit edtSoll;
        private KiSS4.Gui.KissDateEdit edtDatumAuszahlung;
        private KiSS4.Gui.KissButtonEdit edtHaben;
        private KiSS4.Gui.KissDateEdit edtPersGeburtsdatum;
        private KiSS4.DB.SqlQuery qryVmKasse;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBarzahlungen;
        private DevExpress.XtraGrid.Columns.GridColumn colBelegNr;
        private DevExpress.XtraGrid.Columns.GridColumn colMandant;
        private DevExpress.XtraGrid.Columns.GridColumn colStichtag;
        private DevExpress.XtraGrid.Columns.GridColumn colText;
        private DevExpress.XtraGrid.Columns.GridColumn colAuszahlungAb;
        private DevExpress.XtraGrid.Columns.GridColumn colAuszahlungBis;
        private DevExpress.XtraGrid.Columns.GridColumn colBewilligtVon;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colAuszahlungsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private KiSS4.Gui.KissCheckEdit chkDruckvorschau;
    }
}