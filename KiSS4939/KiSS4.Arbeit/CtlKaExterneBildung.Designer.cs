namespace KiSS4.Arbeit
{
    partial class CtlKaExterneBildung
    {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKaExterneBildung));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtKurstyp = new KiSS4.Gui.KissLookUpEdit();
            this.qryExterneBildung = new KiSS4.DB.SqlQuery(this.components);
            this.edtBezeichnung = new KiSS4.Gui.KissTextEdit();
            this.edtKursort = new KiSS4.Gui.KissTextEdit();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtAnzahlKurstage = new KiSS4.Gui.KissCalcEdit();
            this.edtKaProgramm = new KiSS4.Gui.KissLookUpEdit();
            this.edtAnteilKA = new KiSS4.Gui.KissCalcEdit();
            this.edtAnteilDritte = new KiSS4.Gui.KissCalcEdit();
            this.grdExterneBildung = new KiSS4.Gui.KissGrid();
            this.grvExterneBildung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBezeichnung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeginn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEnde = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeplant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZahlungen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnTitle = new System.Windows.Forms.Panel();
            this.imageTitle = new System.Windows.Forms.PictureBox();
            this.lblTitle = new KiSS4.Gui.KissLabel();
            this.lblKurstyp = new KiSS4.Gui.KissLabel();
            this.lblBezeichnung = new KiSS4.Gui.KissLabel();
            this.lblKursort = new KiSS4.Gui.KissLabel();
            this.edtTotalZahlungenKA = new KiSS4.Gui.KissCalcEdit();
            this.lblDauerVon = new KiSS4.Gui.KissLabel();
            this.lblBis = new KiSS4.Gui.KissLabel();
            this.lblAnzahlKurstage = new KiSS4.Gui.KissLabel();
            this.edtKursbestaetigung = new KiSS4.Gui.KissCheckEdit();
            this.lblKaProgramm = new KiSS4.Gui.KissLabel();
            this.lblGeplanteKosten = new KiSS4.Gui.KissLabel();
            this.lblAnteilKA = new KiSS4.Gui.KissLabel();
            this.lblAnteilDritte = new KiSS4.Gui.KissLabel();
            this.lblCHF3 = new KiSS4.Gui.KissLabel();
            this.lblCHF1 = new KiSS4.Gui.KissLabel();
            this.lblTotalZahlungenKA = new KiSS4.Gui.KissLabel();
            this.pnlZahlungen = new System.Windows.Forms.Panel();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnLoeschenZahlung = new KiSS4.Gui.KissButton();
            this.btnNeuZahlung = new KiSS4.Gui.KissButton();
            this.lblZahlungen = new KiSS4.Gui.KissLabel();
            this.lblCHF2 = new KiSS4.Gui.KissLabel();
            this.lblZweck = new KiSS4.Gui.KissLabel();
            this.lblBetrag = new KiSS4.Gui.KissLabel();
            this.lblZahlungDatum = new KiSS4.Gui.KissLabel();
            this.edtZahlungZweck = new KiSS4.Gui.KissTextEdit();
            this.qryZahlung = new KiSS4.DB.SqlQuery(this.components);
            this.edtZahlungBetrag = new KiSS4.Gui.KissCalcEdit();
            this.edtZahlungDatum = new KiSS4.Gui.KissDateEdit();
            this.grdGeplanteKosten = new KiSS4.Gui.KissGrid();
            this.grvGeplanteKosten = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZweck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblFaLeistung = new KiSS4.Gui.KissLabel();
            this.edtFaLeistung = new KiSS4.Gui.KissLookUpEdit();
            this.qryFaLeistung = new KiSS4.DB.SqlQuery(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.edtKurstyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurstyp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryExterneBildung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBezeichnung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKursort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnzahlKurstage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKaProgramm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKaProgramm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnteilKA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnteilDritte.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdExterneBildung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvExterneBildung)).BeginInit();
            this.pnTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurstyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBezeichnung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKursort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTotalZahlungenKA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDauerVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahlKurstage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKursbestaetigung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKaProgramm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeplanteKosten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnteilKA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnteilDritte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHF3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHF1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalZahlungenKA)).BeginInit();
            this.pnlZahlungen.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHF2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZweck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungZweck.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZahlung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGeplanteKosten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvGeplanteKosten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaLeistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaLeistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaLeistung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLeistung)).BeginInit();
            this.SuspendLayout();
            // 
            // edtKurstyp
            // 
            this.edtKurstyp.DataMember = "Kurstyp";
            this.edtKurstyp.DataSource = this.qryExterneBildung;
            this.edtKurstyp.Location = new System.Drawing.Point(118, 163);
            this.edtKurstyp.LOVName = "KaExterneBildungKurstyp";
            this.edtKurstyp.Name = "edtKurstyp";
            this.edtKurstyp.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKurstyp.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKurstyp.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKurstyp.Properties.Appearance.Options.UseBackColor = true;
            this.edtKurstyp.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKurstyp.Properties.Appearance.Options.UseFont = true;
            this.edtKurstyp.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKurstyp.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKurstyp.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKurstyp.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKurstyp.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtKurstyp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtKurstyp.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKurstyp.Properties.NullText = "";
            this.edtKurstyp.Properties.ShowFooter = false;
            this.edtKurstyp.Properties.ShowHeader = false;
            this.edtKurstyp.Size = new System.Drawing.Size(235, 24);
            this.edtKurstyp.TabIndex = 0;
            // 
            // qryExterneBildung
            // 
            this.qryExterneBildung.CanDelete = true;
            this.qryExterneBildung.CanInsert = true;
            this.qryExterneBildung.CanUpdate = true;
            this.qryExterneBildung.HostControl = this;
            this.qryExterneBildung.IsIdentityInsert = false;
            this.qryExterneBildung.SelectStatement = resources.GetString("qryExterneBildung.SelectStatement");
            this.qryExterneBildung.TableName = "KaExterneBildung";
            this.qryExterneBildung.AfterFill += new System.EventHandler(this.qryExterneBildung_AfterFill);
            this.qryExterneBildung.AfterInsert += new System.EventHandler(this.qryExterneBildung_AfterInsert);
            this.qryExterneBildung.AfterPost += new System.EventHandler(this.qryExterneBildung_AfterPost);
            this.qryExterneBildung.BeforeDelete += new System.EventHandler(this.qryExterneBildung_BeforeDelete);
            this.qryExterneBildung.BeforeInsert += new System.EventHandler(this.qryExterneBildung_BeforeInsert);
            this.qryExterneBildung.BeforePost += new System.EventHandler(this.qryExterneBildung_BeforePost);
            this.qryExterneBildung.PositionChanged += new System.EventHandler(this.qryExterneBildung_PositionChanged);
            // 
            // edtBezeichnung
            // 
            this.edtBezeichnung.DataMember = "Bezeichnung";
            this.edtBezeichnung.DataSource = this.qryExterneBildung;
            this.edtBezeichnung.Location = new System.Drawing.Point(118, 193);
            this.edtBezeichnung.Name = "edtBezeichnung";
            this.edtBezeichnung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBezeichnung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBezeichnung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBezeichnung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBezeichnung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBezeichnung.Properties.Appearance.Options.UseFont = true;
            this.edtBezeichnung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBezeichnung.Size = new System.Drawing.Size(597, 24);
            this.edtBezeichnung.TabIndex = 1;
            // 
            // edtKursort
            // 
            this.edtKursort.DataMember = "Kursort";
            this.edtKursort.DataSource = this.qryExterneBildung;
            this.edtKursort.Location = new System.Drawing.Point(118, 223);
            this.edtKursort.Name = "edtKursort";
            this.edtKursort.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKursort.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKursort.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKursort.Properties.Appearance.Options.UseBackColor = true;
            this.edtKursort.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKursort.Properties.Appearance.Options.UseFont = true;
            this.edtKursort.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKursort.Size = new System.Drawing.Size(597, 24);
            this.edtKursort.TabIndex = 2;
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.DataMember = "DatumVon";
            this.edtDatumVon.DataSource = this.qryExterneBildung;
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(118, 253);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
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
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 3;
            this.edtDatumVon.Leave += new System.EventHandler(this.datum_Leave);
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.DataMember = "DatumBis";
            this.edtDatumBis.DataSource = this.qryExterneBildung;
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(253, 253);
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
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 4;
            this.edtDatumBis.Leave += new System.EventHandler(this.datum_Leave);
            // 
            // edtAnzahlKurstage
            // 
            this.edtAnzahlKurstage.DataMember = "AnzahlKurstage";
            this.edtAnzahlKurstage.DataSource = this.qryExterneBildung;
            this.edtAnzahlKurstage.Location = new System.Drawing.Point(483, 253);
            this.edtAnzahlKurstage.Name = "edtAnzahlKurstage";
            this.edtAnzahlKurstage.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAnzahlKurstage.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAnzahlKurstage.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAnzahlKurstage.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnzahlKurstage.Properties.Appearance.Options.UseBackColor = true;
            this.edtAnzahlKurstage.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAnzahlKurstage.Properties.Appearance.Options.UseFont = true;
            this.edtAnzahlKurstage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAnzahlKurstage.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAnzahlKurstage.Size = new System.Drawing.Size(100, 24);
            this.edtAnzahlKurstage.TabIndex = 5;
            // 
            // edtKaProgramm
            // 
            this.edtKaProgramm.DataMember = "KaProgrammCode";
            this.edtKaProgramm.DataSource = this.qryExterneBildung;
            this.edtKaProgramm.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtKaProgramm.Location = new System.Drawing.Point(118, 283);
            this.edtKaProgramm.LOVFilter = "\',\' + Value2 + \',\' like \'%,1,%\'";
            this.edtKaProgramm.LOVFilterWhereAppend = true;
            this.edtKaProgramm.LOVName = "KaVermittlungProgramm";
            this.edtKaProgramm.Name = "edtKaProgramm";
            this.edtKaProgramm.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtKaProgramm.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKaProgramm.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKaProgramm.Properties.Appearance.Options.UseBackColor = true;
            this.edtKaProgramm.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKaProgramm.Properties.Appearance.Options.UseFont = true;
            this.edtKaProgramm.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKaProgramm.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKaProgramm.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKaProgramm.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKaProgramm.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtKaProgramm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtKaProgramm.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKaProgramm.Properties.NullText = "";
            this.edtKaProgramm.Properties.ShowFooter = false;
            this.edtKaProgramm.Properties.ShowHeader = false;
            this.edtKaProgramm.Size = new System.Drawing.Size(235, 24);
            this.edtKaProgramm.TabIndex = 6;
            // 
            // edtAnteilKA
            // 
            this.edtAnteilKA.DataMember = "AnteilKA";
            this.edtAnteilKA.DataSource = this.qryExterneBildung;
            this.edtAnteilKA.Location = new System.Drawing.Point(118, 370);
            this.edtAnteilKA.Name = "edtAnteilKA";
            this.edtAnteilKA.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAnteilKA.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAnteilKA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAnteilKA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnteilKA.Properties.Appearance.Options.UseBackColor = true;
            this.edtAnteilKA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAnteilKA.Properties.Appearance.Options.UseFont = true;
            this.edtAnteilKA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAnteilKA.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAnteilKA.Properties.DisplayFormat.FormatString = "n2";
            this.edtAnteilKA.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtAnteilKA.Properties.EditFormat.FormatString = "n2";
            this.edtAnteilKA.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtAnteilKA.Size = new System.Drawing.Size(100, 24);
            this.edtAnteilKA.TabIndex = 7;
            // 
            // edtAnteilDritte
            // 
            this.edtAnteilDritte.DataMember = "AnteilDritte";
            this.edtAnteilDritte.DataSource = this.qryExterneBildung;
            this.edtAnteilDritte.Location = new System.Drawing.Point(331, 370);
            this.edtAnteilDritte.Name = "edtAnteilDritte";
            this.edtAnteilDritte.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAnteilDritte.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAnteilDritte.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAnteilDritte.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnteilDritte.Properties.Appearance.Options.UseBackColor = true;
            this.edtAnteilDritte.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAnteilDritte.Properties.Appearance.Options.UseFont = true;
            this.edtAnteilDritte.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAnteilDritte.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAnteilDritte.Properties.DisplayFormat.FormatString = "n2";
            this.edtAnteilDritte.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtAnteilDritte.Properties.EditFormat.FormatString = "n2";
            this.edtAnteilDritte.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtAnteilDritte.Size = new System.Drawing.Size(100, 24);
            this.edtAnteilDritte.TabIndex = 8;
            // 
            // grdExterneBildung
            // 
            this.grdExterneBildung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdExterneBildung.DataSource = this.qryExterneBildung;
            // 
            // 
            // 
            this.grdExterneBildung.EmbeddedNavigator.Name = "";
            this.grdExterneBildung.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdExterneBildung.Location = new System.Drawing.Point(0, 40);
            this.grdExterneBildung.MainView = this.grvExterneBildung;
            this.grdExterneBildung.Name = "grdExterneBildung";
            this.grdExterneBildung.Size = new System.Drawing.Size(715, 117);
            this.grdExterneBildung.TabIndex = 9;
            this.grdExterneBildung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvExterneBildung});
            // 
            // grvExterneBildung
            // 
            this.grvExterneBildung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvExterneBildung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvExterneBildung.Appearance.Empty.Options.UseBackColor = true;
            this.grvExterneBildung.Appearance.Empty.Options.UseFont = true;
            this.grvExterneBildung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvExterneBildung.Appearance.EvenRow.Options.UseFont = true;
            this.grvExterneBildung.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvExterneBildung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvExterneBildung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvExterneBildung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvExterneBildung.Appearance.FocusedCell.Options.UseFont = true;
            this.grvExterneBildung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvExterneBildung.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvExterneBildung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvExterneBildung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvExterneBildung.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvExterneBildung.Appearance.FocusedRow.Options.UseFont = true;
            this.grvExterneBildung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvExterneBildung.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvExterneBildung.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvExterneBildung.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvExterneBildung.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvExterneBildung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvExterneBildung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvExterneBildung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvExterneBildung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvExterneBildung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvExterneBildung.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvExterneBildung.Appearance.GroupRow.Options.UseFont = true;
            this.grvExterneBildung.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvExterneBildung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvExterneBildung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvExterneBildung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvExterneBildung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvExterneBildung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvExterneBildung.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvExterneBildung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvExterneBildung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvExterneBildung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvExterneBildung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvExterneBildung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvExterneBildung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvExterneBildung.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvExterneBildung.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvExterneBildung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvExterneBildung.Appearance.OddRow.Options.UseFont = true;
            this.grvExterneBildung.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvExterneBildung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvExterneBildung.Appearance.Row.Options.UseBackColor = true;
            this.grvExterneBildung.Appearance.Row.Options.UseFont = true;
            this.grvExterneBildung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvExterneBildung.Appearance.SelectedRow.Options.UseFont = true;
            this.grvExterneBildung.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvExterneBildung.Appearance.VertLine.Options.UseBackColor = true;
            this.grvExterneBildung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvExterneBildung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTyp,
            this.colBezeichnung,
            this.colBeginn,
            this.colEnde,
            this.colGeplant,
            this.colZahlungen});
            this.grvExterneBildung.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvExterneBildung.GridControl = this.grdExterneBildung;
            this.grvExterneBildung.Name = "grvExterneBildung";
            this.grvExterneBildung.OptionsBehavior.Editable = false;
            this.grvExterneBildung.OptionsCustomization.AllowFilter = false;
            this.grvExterneBildung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvExterneBildung.OptionsNavigation.AutoFocusNewRow = true;
            this.grvExterneBildung.OptionsNavigation.UseTabKey = false;
            this.grvExterneBildung.OptionsView.ColumnAutoWidth = false;
            this.grvExterneBildung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvExterneBildung.OptionsView.ShowGroupPanel = false;
            this.grvExterneBildung.OptionsView.ShowIndicator = false;
            // 
            // colTyp
            // 
            this.colTyp.Caption = "Typ";
            this.colTyp.FieldName = "Kurstyp";
            this.colTyp.Name = "colTyp";
            this.colTyp.Visible = true;
            this.colTyp.VisibleIndex = 0;
            this.colTyp.Width = 126;
            // 
            // colBezeichnung
            // 
            this.colBezeichnung.Caption = "Bezeichnung";
            this.colBezeichnung.FieldName = "Bezeichnung";
            this.colBezeichnung.Name = "colBezeichnung";
            this.colBezeichnung.Visible = true;
            this.colBezeichnung.VisibleIndex = 1;
            this.colBezeichnung.Width = 230;
            // 
            // colBeginn
            // 
            this.colBeginn.Caption = "Beginn";
            this.colBeginn.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.colBeginn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colBeginn.FieldName = "DatumVon";
            this.colBeginn.Name = "colBeginn";
            this.colBeginn.Visible = true;
            this.colBeginn.VisibleIndex = 2;
            this.colBeginn.Width = 95;
            // 
            // colEnde
            // 
            this.colEnde.Caption = "Ende";
            this.colEnde.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.colEnde.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colEnde.FieldName = "DatumBis";
            this.colEnde.Name = "colEnde";
            this.colEnde.Visible = true;
            this.colEnde.VisibleIndex = 3;
            this.colEnde.Width = 94;
            // 
            // colGeplant
            // 
            this.colGeplant.Caption = "geplant";
            this.colGeplant.DisplayFormat.FormatString = "n2";
            this.colGeplant.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGeplant.FieldName = "AnteilKA";
            this.colGeplant.Name = "colGeplant";
            this.colGeplant.Visible = true;
            this.colGeplant.VisibleIndex = 4;
            this.colGeplant.Width = 62;
            // 
            // colZahlungen
            // 
            this.colZahlungen.Caption = "Zahlungen";
            this.colZahlungen.DisplayFormat.FormatString = "n2";
            this.colZahlungen.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colZahlungen.FieldName = "Zahlungen";
            this.colZahlungen.Name = "colZahlungen";
            this.colZahlungen.Visible = true;
            this.colZahlungen.VisibleIndex = 5;
            this.colZahlungen.Width = 69;
            // 
            // pnTitle
            // 
            this.pnTitle.Controls.Add(this.imageTitle);
            this.pnTitle.Controls.Add(this.lblTitle);
            this.pnTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTitle.Location = new System.Drawing.Point(0, 0);
            this.pnTitle.Name = "pnTitle";
            this.pnTitle.Size = new System.Drawing.Size(718, 40);
            this.pnTitle.TabIndex = 10;
            // 
            // imageTitle
            // 
            this.imageTitle.Location = new System.Drawing.Point(10, 9);
            this.imageTitle.Name = "imageTitle";
            this.imageTitle.Size = new System.Drawing.Size(25, 20);
            this.imageTitle.TabIndex = 1;
            this.imageTitle.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitle.Location = new System.Drawing.Point(35, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(500, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QJ Extern";
            this.lblTitle.UseCompatibleTextRendering = true;
            // 
            // lblKurstyp
            // 
            this.lblKurstyp.Location = new System.Drawing.Point(3, 163);
            this.lblKurstyp.Name = "lblKurstyp";
            this.lblKurstyp.Size = new System.Drawing.Size(90, 24);
            this.lblKurstyp.TabIndex = 11;
            this.lblKurstyp.Text = "Kurstyp";
            this.lblKurstyp.UseCompatibleTextRendering = true;
            // 
            // lblBezeichnung
            // 
            this.lblBezeichnung.Location = new System.Drawing.Point(3, 193);
            this.lblBezeichnung.Name = "lblBezeichnung";
            this.lblBezeichnung.Size = new System.Drawing.Size(90, 24);
            this.lblBezeichnung.TabIndex = 12;
            this.lblBezeichnung.Text = "Bezeichnung";
            this.lblBezeichnung.UseCompatibleTextRendering = true;
            // 
            // lblKursort
            // 
            this.lblKursort.Location = new System.Drawing.Point(3, 223);
            this.lblKursort.Name = "lblKursort";
            this.lblKursort.Size = new System.Drawing.Size(90, 24);
            this.lblKursort.TabIndex = 13;
            this.lblKursort.Text = "Kursort";
            this.lblKursort.UseCompatibleTextRendering = true;
            // 
            // edtTotalZahlungenKA
            // 
            this.edtTotalZahlungenKA.DataMember = "Zahlungen";
            this.edtTotalZahlungenKA.DataSource = this.qryExterneBildung;
            this.edtTotalZahlungenKA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtTotalZahlungenKA.Location = new System.Drawing.Point(117, 604);
            this.edtTotalZahlungenKA.Name = "edtTotalZahlungenKA";
            this.edtTotalZahlungenKA.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtTotalZahlungenKA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtTotalZahlungenKA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTotalZahlungenKA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTotalZahlungenKA.Properties.Appearance.Options.UseBackColor = true;
            this.edtTotalZahlungenKA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTotalZahlungenKA.Properties.Appearance.Options.UseFont = true;
            this.edtTotalZahlungenKA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTotalZahlungenKA.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTotalZahlungenKA.Properties.DisplayFormat.FormatString = "n2";
            this.edtTotalZahlungenKA.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtTotalZahlungenKA.Properties.EditFormat.FormatString = "n2";
            this.edtTotalZahlungenKA.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtTotalZahlungenKA.Properties.ReadOnly = true;
            this.edtTotalZahlungenKA.Size = new System.Drawing.Size(100, 24);
            this.edtTotalZahlungenKA.TabIndex = 14;
            // 
            // lblDauerVon
            // 
            this.lblDauerVon.Location = new System.Drawing.Point(3, 253);
            this.lblDauerVon.Name = "lblDauerVon";
            this.lblDauerVon.Size = new System.Drawing.Size(90, 24);
            this.lblDauerVon.TabIndex = 14;
            this.lblDauerVon.Text = "Dauer von";
            this.lblDauerVon.UseCompatibleTextRendering = true;
            // 
            // lblBis
            // 
            this.lblBis.Location = new System.Drawing.Point(230, 253);
            this.lblBis.Name = "lblBis";
            this.lblBis.Size = new System.Drawing.Size(17, 24);
            this.lblBis.TabIndex = 15;
            this.lblBis.Text = "bis";
            this.lblBis.UseCompatibleTextRendering = true;
            // 
            // lblAnzahlKurstage
            // 
            this.lblAnzahlKurstage.Location = new System.Drawing.Point(387, 253);
            this.lblAnzahlKurstage.Name = "lblAnzahlKurstage";
            this.lblAnzahlKurstage.Size = new System.Drawing.Size(90, 24);
            this.lblAnzahlKurstage.TabIndex = 16;
            this.lblAnzahlKurstage.Text = "Anzahl Kurstage";
            this.lblAnzahlKurstage.UseCompatibleTextRendering = true;
            // 
            // edtKursbestaetigung
            // 
            this.edtKursbestaetigung.DataMember = "Kursbestaetigung";
            this.edtKursbestaetigung.DataSource = this.qryExterneBildung;
            this.edtKursbestaetigung.Location = new System.Drawing.Point(593, 257);
            this.edtKursbestaetigung.Name = "edtKursbestaetigung";
            this.edtKursbestaetigung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKursbestaetigung.Properties.Appearance.Options.UseBackColor = true;
            this.edtKursbestaetigung.Properties.Caption = "Kursbestätigung";
            this.edtKursbestaetigung.Size = new System.Drawing.Size(106, 19);
            this.edtKursbestaetigung.TabIndex = 17;
            // 
            // lblKaProgramm
            // 
            this.lblKaProgramm.Location = new System.Drawing.Point(3, 283);
            this.lblKaProgramm.Name = "lblKaProgramm";
            this.lblKaProgramm.Size = new System.Drawing.Size(96, 24);
            this.lblKaProgramm.TabIndex = 18;
            this.lblKaProgramm.Text = "KA-Programm";
            this.lblKaProgramm.UseCompatibleTextRendering = true;
            // 
            // lblGeplanteKosten
            // 
            this.lblGeplanteKosten.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblGeplanteKosten.Location = new System.Drawing.Point(10, 351);
            this.lblGeplanteKosten.Name = "lblGeplanteKosten";
            this.lblGeplanteKosten.Size = new System.Drawing.Size(114, 16);
            this.lblGeplanteKosten.TabIndex = 19;
            this.lblGeplanteKosten.Text = "Geplante Kosten";
            this.lblGeplanteKosten.UseCompatibleTextRendering = true;
            // 
            // lblAnteilKA
            // 
            this.lblAnteilKA.Location = new System.Drawing.Point(11, 370);
            this.lblAnteilKA.Name = "lblAnteilKA";
            this.lblAnteilKA.Size = new System.Drawing.Size(101, 24);
            this.lblAnteilKA.TabIndex = 20;
            this.lblAnteilKA.Text = "Anteil KA";
            this.lblAnteilKA.UseCompatibleTextRendering = true;
            // 
            // lblAnteilDritte
            // 
            this.lblAnteilDritte.Location = new System.Drawing.Point(224, 370);
            this.lblAnteilDritte.Name = "lblAnteilDritte";
            this.lblAnteilDritte.Size = new System.Drawing.Size(107, 24);
            this.lblAnteilDritte.TabIndex = 21;
            this.lblAnteilDritte.Text = "CHF    Anteil Dritte";
            this.lblAnteilDritte.UseCompatibleTextRendering = true;
            // 
            // lblCHF3
            // 
            this.lblCHF3.Location = new System.Drawing.Point(437, 370);
            this.lblCHF3.Name = "lblCHF3";
            this.lblCHF3.Size = new System.Drawing.Size(27, 24);
            this.lblCHF3.TabIndex = 22;
            this.lblCHF3.Text = "CHF";
            this.lblCHF3.UseCompatibleTextRendering = true;
            // 
            // lblCHF1
            // 
            this.lblCHF1.Location = new System.Drawing.Point(223, 604);
            this.lblCHF1.Name = "lblCHF1";
            this.lblCHF1.Size = new System.Drawing.Size(25, 24);
            this.lblCHF1.TabIndex = 32;
            this.lblCHF1.Text = "CHF";
            this.lblCHF1.UseCompatibleTextRendering = true;
            // 
            // lblTotalZahlungenKA
            // 
            this.lblTotalZahlungenKA.Location = new System.Drawing.Point(5, 604);
            this.lblTotalZahlungenKA.Name = "lblTotalZahlungenKA";
            this.lblTotalZahlungenKA.Size = new System.Drawing.Size(107, 24);
            this.lblTotalZahlungenKA.TabIndex = 34;
            this.lblTotalZahlungenKA.Text = "Total Zahlungen KA";
            this.lblTotalZahlungenKA.UseCompatibleTextRendering = true;
            // 
            // pnlZahlungen
            // 
            this.pnlZahlungen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlZahlungen.Controls.Add(this.pnlButtons);
            this.pnlZahlungen.Controls.Add(this.lblZahlungen);
            this.pnlZahlungen.Controls.Add(this.lblCHF2);
            this.pnlZahlungen.Controls.Add(this.lblZweck);
            this.pnlZahlungen.Controls.Add(this.lblBetrag);
            this.pnlZahlungen.Controls.Add(this.lblZahlungDatum);
            this.pnlZahlungen.Controls.Add(this.edtZahlungZweck);
            this.pnlZahlungen.Controls.Add(this.edtZahlungBetrag);
            this.pnlZahlungen.Controls.Add(this.edtZahlungDatum);
            this.pnlZahlungen.Controls.Add(this.grdGeplanteKosten);
            this.pnlZahlungen.Location = new System.Drawing.Point(3, 400);
            this.pnlZahlungen.Name = "pnlZahlungen";
            this.pnlZahlungen.Size = new System.Drawing.Size(712, 198);
            this.pnlZahlungen.TabIndex = 35;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnLoeschenZahlung);
            this.pnlButtons.Controls.Add(this.btnNeuZahlung);
            this.pnlButtons.Location = new System.Drawing.Point(105, 0);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(61, 30);
            this.pnlButtons.TabIndex = 34;
            // 
            // btnLoeschenZahlung
            // 
            this.btnLoeschenZahlung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoeschenZahlung.IconID = 4;
            this.btnLoeschenZahlung.Location = new System.Drawing.Point(32, 3);
            this.btnLoeschenZahlung.Name = "btnLoeschenZahlung";
            this.btnLoeschenZahlung.Size = new System.Drawing.Size(25, 24);
            this.btnLoeschenZahlung.TabIndex = 3;
            this.btnLoeschenZahlung.UseCompatibleTextRendering = true;
            this.btnLoeschenZahlung.UseVisualStyleBackColor = false;
            this.btnLoeschenZahlung.Click += new System.EventHandler(this.btnLoeschenZahlung_Click);
            // 
            // btnNeuZahlung
            // 
            this.btnNeuZahlung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNeuZahlung.IconID = 1;
            this.btnNeuZahlung.Location = new System.Drawing.Point(3, 3);
            this.btnNeuZahlung.Name = "btnNeuZahlung";
            this.btnNeuZahlung.Size = new System.Drawing.Size(25, 24);
            this.btnNeuZahlung.TabIndex = 2;
            this.btnNeuZahlung.UseCompatibleTextRendering = true;
            this.btnNeuZahlung.UseVisualStyleBackColor = false;
            this.btnNeuZahlung.Click += new System.EventHandler(this.btnNeuZahlung_Click);
            // 
            // lblZahlungen
            // 
            this.lblZahlungen.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblZahlungen.Location = new System.Drawing.Point(6, 5);
            this.lblZahlungen.Name = "lblZahlungen";
            this.lblZahlungen.Size = new System.Drawing.Size(90, 16);
            this.lblZahlungen.TabIndex = 33;
            this.lblZahlungen.Text = "Zahlungen ";
            this.lblZahlungen.UseCompatibleTextRendering = true;
            // 
            // lblCHF2
            // 
            this.lblCHF2.Location = new System.Drawing.Point(415, 132);
            this.lblCHF2.Name = "lblCHF2";
            this.lblCHF2.Size = new System.Drawing.Size(25, 24);
            this.lblCHF2.TabIndex = 31;
            this.lblCHF2.Text = "CHF";
            this.lblCHF2.UseCompatibleTextRendering = true;
            // 
            // lblZweck
            // 
            this.lblZweck.Location = new System.Drawing.Point(7, 162);
            this.lblZweck.Name = "lblZweck";
            this.lblZweck.Size = new System.Drawing.Size(54, 24);
            this.lblZweck.TabIndex = 30;
            this.lblZweck.Text = "Zweck";
            this.lblZweck.UseCompatibleTextRendering = true;
            // 
            // lblBetrag
            // 
            this.lblBetrag.Location = new System.Drawing.Point(230, 132);
            this.lblBetrag.Name = "lblBetrag";
            this.lblBetrag.Size = new System.Drawing.Size(60, 24);
            this.lblBetrag.TabIndex = 29;
            this.lblBetrag.Text = "Betrag";
            this.lblBetrag.UseCompatibleTextRendering = true;
            // 
            // lblZahlungDatum
            // 
            this.lblZahlungDatum.Location = new System.Drawing.Point(6, 132);
            this.lblZahlungDatum.Name = "lblZahlungDatum";
            this.lblZahlungDatum.Size = new System.Drawing.Size(54, 24);
            this.lblZahlungDatum.TabIndex = 28;
            this.lblZahlungDatum.Text = "Datum";
            this.lblZahlungDatum.UseCompatibleTextRendering = true;
            // 
            // edtZahlungZweck
            // 
            this.edtZahlungZweck.DataMember = "Zweck";
            this.edtZahlungZweck.DataSource = this.qryZahlung;
            this.edtZahlungZweck.Location = new System.Drawing.Point(114, 162);
            this.edtZahlungZweck.Name = "edtZahlungZweck";
            this.edtZahlungZweck.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZahlungZweck.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZahlungZweck.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZahlungZweck.Properties.Appearance.Options.UseBackColor = true;
            this.edtZahlungZweck.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZahlungZweck.Properties.Appearance.Options.UseFont = true;
            this.edtZahlungZweck.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZahlungZweck.Size = new System.Drawing.Size(581, 24);
            this.edtZahlungZweck.TabIndex = 18;
            // 
            // qryZahlung
            // 
            this.qryZahlung.CanDelete = true;
            this.qryZahlung.CanInsert = true;
            this.qryZahlung.CanUpdate = true;
            this.qryZahlung.HostControl = this;
            this.qryZahlung.IsIdentityInsert = false;
            this.qryZahlung.SelectStatement = "SELECT ZAL.*\r\nFROM KaExterneBildungZahlung ZAL\r\nWHERE ZAL.KaExterneBildungID = {0" +
    "}\r\nORDER BY Datum DESC";
            this.qryZahlung.TableName = "KaExterneBildungZahlung";
            this.qryZahlung.AfterDelete += new System.EventHandler(this.qryZahlung_AfterDelete);
            this.qryZahlung.AfterInsert += new System.EventHandler(this.qryZahlung_AfterInsert);
            this.qryZahlung.AfterPost += new System.EventHandler(this.qryZahlung_AfterPost);
            this.qryZahlung.ColumnChanging += new System.Data.DataColumnChangeEventHandler(this.qryZahlung_ColumnChanging);
            this.qryZahlung.PositionChanging += new System.EventHandler(this.qryZahlung_PositionChanging);
            // 
            // edtZahlungBetrag
            // 
            this.edtZahlungBetrag.DataMember = "Betrag";
            this.edtZahlungBetrag.DataSource = this.qryZahlung;
            this.edtZahlungBetrag.Location = new System.Drawing.Point(309, 132);
            this.edtZahlungBetrag.Name = "edtZahlungBetrag";
            this.edtZahlungBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtZahlungBetrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZahlungBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZahlungBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZahlungBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtZahlungBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZahlungBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtZahlungBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZahlungBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZahlungBetrag.Properties.DisplayFormat.FormatString = "n2";
            this.edtZahlungBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtZahlungBetrag.Properties.EditFormat.FormatString = "n2";
            this.edtZahlungBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtZahlungBetrag.Size = new System.Drawing.Size(100, 24);
            this.edtZahlungBetrag.TabIndex = 17;
            // 
            // edtZahlungDatum
            // 
            this.edtZahlungDatum.DataMember = "Datum";
            this.edtZahlungDatum.DataSource = this.qryZahlung;
            this.edtZahlungDatum.EditValue = null;
            this.edtZahlungDatum.Location = new System.Drawing.Point(114, 132);
            this.edtZahlungDatum.Name = "edtZahlungDatum";
            this.edtZahlungDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtZahlungDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZahlungDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZahlungDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZahlungDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtZahlungDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZahlungDatum.Properties.Appearance.Options.UseFont = true;
            this.edtZahlungDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtZahlungDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtZahlungDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtZahlungDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZahlungDatum.Properties.ShowToday = false;
            this.edtZahlungDatum.Size = new System.Drawing.Size(100, 24);
            this.edtZahlungDatum.TabIndex = 16;
            // 
            // grdGeplanteKosten
            // 
            this.grdGeplanteKosten.DataSource = this.qryZahlung;
            // 
            // 
            // 
            this.grdGeplanteKosten.EmbeddedNavigator.Name = "";
            this.grdGeplanteKosten.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdGeplanteKosten.Location = new System.Drawing.Point(6, 34);
            this.grdGeplanteKosten.MainView = this.grvGeplanteKosten;
            this.grdGeplanteKosten.Name = "grdGeplanteKosten";
            this.grdGeplanteKosten.Size = new System.Drawing.Size(689, 91);
            this.grdGeplanteKosten.TabIndex = 15;
            this.grdGeplanteKosten.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvGeplanteKosten});
            // 
            // grvGeplanteKosten
            // 
            this.grvGeplanteKosten.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvGeplanteKosten.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGeplanteKosten.Appearance.Empty.Options.UseBackColor = true;
            this.grvGeplanteKosten.Appearance.Empty.Options.UseFont = true;
            this.grvGeplanteKosten.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGeplanteKosten.Appearance.EvenRow.Options.UseFont = true;
            this.grvGeplanteKosten.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvGeplanteKosten.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGeplanteKosten.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvGeplanteKosten.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvGeplanteKosten.Appearance.FocusedCell.Options.UseFont = true;
            this.grvGeplanteKosten.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvGeplanteKosten.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvGeplanteKosten.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGeplanteKosten.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvGeplanteKosten.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvGeplanteKosten.Appearance.FocusedRow.Options.UseFont = true;
            this.grvGeplanteKosten.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvGeplanteKosten.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvGeplanteKosten.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvGeplanteKosten.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvGeplanteKosten.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvGeplanteKosten.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvGeplanteKosten.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvGeplanteKosten.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvGeplanteKosten.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvGeplanteKosten.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvGeplanteKosten.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvGeplanteKosten.Appearance.GroupRow.Options.UseFont = true;
            this.grvGeplanteKosten.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvGeplanteKosten.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvGeplanteKosten.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvGeplanteKosten.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvGeplanteKosten.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvGeplanteKosten.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvGeplanteKosten.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvGeplanteKosten.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvGeplanteKosten.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGeplanteKosten.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvGeplanteKosten.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvGeplanteKosten.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvGeplanteKosten.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvGeplanteKosten.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvGeplanteKosten.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvGeplanteKosten.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGeplanteKosten.Appearance.OddRow.Options.UseFont = true;
            this.grvGeplanteKosten.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvGeplanteKosten.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGeplanteKosten.Appearance.Row.Options.UseBackColor = true;
            this.grvGeplanteKosten.Appearance.Row.Options.UseFont = true;
            this.grvGeplanteKosten.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGeplanteKosten.Appearance.SelectedRow.Options.UseFont = true;
            this.grvGeplanteKosten.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvGeplanteKosten.Appearance.VertLine.Options.UseBackColor = true;
            this.grvGeplanteKosten.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvGeplanteKosten.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatum,
            this.colZweck,
            this.colBetrag});
            this.grvGeplanteKosten.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvGeplanteKosten.GridControl = this.grdGeplanteKosten;
            this.grvGeplanteKosten.Name = "grvGeplanteKosten";
            this.grvGeplanteKosten.OptionsBehavior.Editable = false;
            this.grvGeplanteKosten.OptionsCustomization.AllowFilter = false;
            this.grvGeplanteKosten.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvGeplanteKosten.OptionsNavigation.AutoFocusNewRow = true;
            this.grvGeplanteKosten.OptionsNavigation.UseTabKey = false;
            this.grvGeplanteKosten.OptionsView.ColumnAutoWidth = false;
            this.grvGeplanteKosten.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvGeplanteKosten.OptionsView.ShowGroupPanel = false;
            this.grvGeplanteKosten.OptionsView.ShowIndicator = false;
            // 
            // colDatum
            // 
            this.colDatum.Caption = "Datum";
            this.colDatum.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.colDatum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDatum.FieldName = "Datum";
            this.colDatum.Name = "colDatum";
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 0;
            this.colDatum.Width = 98;
            // 
            // colZweck
            // 
            this.colZweck.Caption = "Zweck";
            this.colZweck.FieldName = "Zweck";
            this.colZweck.Name = "colZweck";
            this.colZweck.Visible = true;
            this.colZweck.VisibleIndex = 1;
            this.colZweck.Width = 320;
            // 
            // colBetrag
            // 
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "n2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 2;
            this.colBetrag.Width = 94;
            // 
            // lblFaLeistung
            // 
            this.lblFaLeistung.Location = new System.Drawing.Point(3, 313);
            this.lblFaLeistung.Name = "lblFaLeistung";
            this.lblFaLeistung.Size = new System.Drawing.Size(100, 23);
            this.lblFaLeistung.TabIndex = 36;
            this.lblFaLeistung.Text = "Leistung";
            // 
            // edtFaLeistung
            // 
            this.edtFaLeistung.DataMember = "FaLeistungID";
            this.edtFaLeistung.DataSource = this.qryExterneBildung;
            this.edtFaLeistung.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtFaLeistung.Location = new System.Drawing.Point(118, 313);
            this.edtFaLeistung.Name = "edtFaLeistung";
            this.edtFaLeistung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtFaLeistung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaLeistung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaLeistung.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaLeistung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaLeistung.Properties.Appearance.Options.UseFont = true;
            this.edtFaLeistung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtFaLeistung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaLeistung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtFaLeistung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtFaLeistung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtFaLeistung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtFaLeistung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFaLeistung.Properties.NullText = "";
            this.edtFaLeistung.Properties.ShowFooter = false;
            this.edtFaLeistung.Properties.ShowHeader = false;
            this.edtFaLeistung.Size = new System.Drawing.Size(235, 24);
            this.edtFaLeistung.TabIndex = 37;
            // 
            // qryFaLeistung
            // 
            this.qryFaLeistung.HostControl = this;
            this.qryFaLeistung.IsIdentityInsert = false;
            this.qryFaLeistung.SelectStatement = resources.GetString("qryFaLeistung.SelectStatement");
            // 
            // CtlKaExterneBildung
            // 
            this.ActiveSQLQuery = this.qryExterneBildung;
            this.AutoScroll = true;
            this.Controls.Add(this.edtFaLeistung);
            this.Controls.Add(this.lblFaLeistung);
            this.Controls.Add(this.pnlZahlungen);
            this.Controls.Add(this.lblTotalZahlungenKA);
            this.Controls.Add(this.lblCHF1);
            this.Controls.Add(this.lblCHF3);
            this.Controls.Add(this.lblAnteilDritte);
            this.Controls.Add(this.lblAnteilKA);
            this.Controls.Add(this.lblGeplanteKosten);
            this.Controls.Add(this.lblKaProgramm);
            this.Controls.Add(this.edtKursbestaetigung);
            this.Controls.Add(this.lblAnzahlKurstage);
            this.Controls.Add(this.lblBis);
            this.Controls.Add(this.lblDauerVon);
            this.Controls.Add(this.edtTotalZahlungenKA);
            this.Controls.Add(this.lblKursort);
            this.Controls.Add(this.lblBezeichnung);
            this.Controls.Add(this.lblKurstyp);
            this.Controls.Add(this.pnTitle);
            this.Controls.Add(this.grdExterneBildung);
            this.Controls.Add(this.edtAnteilDritte);
            this.Controls.Add(this.edtAnteilKA);
            this.Controls.Add(this.edtKaProgramm);
            this.Controls.Add(this.edtAnzahlKurstage);
            this.Controls.Add(this.edtDatumBis);
            this.Controls.Add(this.edtDatumVon);
            this.Controls.Add(this.edtKursort);
            this.Controls.Add(this.edtBezeichnung);
            this.Controls.Add(this.edtKurstyp);
            this.Name = "CtlKaExterneBildung";
            this.Size = new System.Drawing.Size(718, 633);
            ((System.ComponentModel.ISupportInitialize)(this.edtKurstyp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurstyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryExterneBildung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBezeichnung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKursort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnzahlKurstage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKaProgramm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKaProgramm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnteilKA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnteilDritte.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdExterneBildung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvExterneBildung)).EndInit();
            this.pnTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurstyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBezeichnung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKursort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTotalZahlungenKA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDauerVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahlKurstage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKursbestaetigung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKaProgramm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeplanteKosten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnteilKA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnteilDritte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHF3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHF1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalZahlungenKA)).EndInit();
            this.pnlZahlungen.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHF2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZweck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungZweck.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZahlung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGeplanteKosten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvGeplanteKosten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaLeistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaLeistung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaLeistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLeistung)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissButton btnLoeschenZahlung;
        private KiSS4.Gui.KissButton btnNeuZahlung;
        private DevExpress.XtraGrid.Columns.GridColumn colBeginn;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBezeichnung;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colEnde;
        private DevExpress.XtraGrid.Columns.GridColumn colGeplant;
        private DevExpress.XtraGrid.Columns.GridColumn colTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colZahlungen;
        private DevExpress.XtraGrid.Columns.GridColumn colZweck;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissCalcEdit edtAnteilDritte;
        private KiSS4.Gui.KissCalcEdit edtAnteilKA;
        private KiSS4.Gui.KissCalcEdit edtAnzahlKurstage;
        private KiSS4.Gui.KissTextEdit edtBezeichnung;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissLookUpEdit edtKaProgramm;
        private KiSS4.Gui.KissCheckEdit edtKursbestaetigung;
        private KiSS4.Gui.KissTextEdit edtKursort;
        private KiSS4.Gui.KissLookUpEdit edtKurstyp;
        private KiSS4.Gui.KissCalcEdit edtTotalZahlungenKA;
        private KiSS4.Gui.KissCalcEdit edtZahlungBetrag;
        private KiSS4.Gui.KissDateEdit edtZahlungDatum;
        private KiSS4.Gui.KissTextEdit edtZahlungZweck;
        private KiSS4.Gui.KissGrid grdExterneBildung;
        private KiSS4.Gui.KissGrid grdGeplanteKosten;
        private DevExpress.XtraGrid.Views.Grid.GridView grvExterneBildung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvGeplanteKosten;
        private System.Windows.Forms.PictureBox imageTitle;
        private KiSS4.Gui.KissLabel lblAnteilDritte;
        private KiSS4.Gui.KissLabel lblAnteilKA;
        private KiSS4.Gui.KissLabel lblAnzahlKurstage;
        private KiSS4.Gui.KissLabel lblBetrag;
        private KiSS4.Gui.KissLabel lblBezeichnung;
        private KiSS4.Gui.KissLabel lblBis;
        private KiSS4.Gui.KissLabel lblCHF1;
        private KiSS4.Gui.KissLabel lblCHF2;
        private KiSS4.Gui.KissLabel lblCHF3;
        private KiSS4.Gui.KissLabel lblDauerVon;
        private KiSS4.Gui.KissLabel lblGeplanteKosten;
        private KiSS4.Gui.KissLabel lblKaProgramm;
        private KiSS4.Gui.KissLabel lblKursort;
        private KiSS4.Gui.KissLabel lblKurstyp;
        private KiSS4.Gui.KissLabel lblTitle;
        private KiSS4.Gui.KissLabel lblTotalZahlungenKA;
        private KiSS4.Gui.KissLabel lblZahlungDatum;
        private KiSS4.Gui.KissLabel lblZahlungen;
        private KiSS4.Gui.KissLabel lblZweck;
        private System.Windows.Forms.Panel pnTitle;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Panel pnlZahlungen;
        private KiSS4.DB.SqlQuery qryExterneBildung;
        private KiSS4.DB.SqlQuery qryZahlung;
        private Gui.KissLabel lblFaLeistung;
        private Gui.KissLookUpEdit edtFaLeistung;
        private DB.SqlQuery qryFaLeistung;
    }
}
