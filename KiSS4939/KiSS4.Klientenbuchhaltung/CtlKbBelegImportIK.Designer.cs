namespace KiSS4.Klientenbuchhaltung
{
    partial class CtlKbBelegImportIK
    {
        #region Fields


        #region Private Fields
        private KiSS4.Gui.KissButton btnAlleAuswaehlen;
        private KiSS4.Gui.KissButton btnAlleEntfernen;
        private KiSS4.Gui.KissButton btnBelegeImportieren;
        private KiSS4.Gui.KissButton btnMonatszahlen;
        private KiSS4.Gui.KissButton btnRueckgaengig;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchung_BelegNr;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchung_BelegStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchung_Belegdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchung_Betrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchung_Buchungstext;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchung_IstAuszahlung;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchung_IstAuszahlungALBV;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchung_KbAuszahlungsArtCode;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchung_KbBuchungID;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchung_KbPeriodeID;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchung_Valuta;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchung_Zahlungsempfaenger;
        private DevExpress.XtraGrid.Columns.GridColumn colListe_Betrag;
        private DevExpress.XtraGrid.Columns.GridColumn colListe_Datum;
        private DevExpress.XtraGrid.Columns.GridColumn colListe_ErledigterMonat;
        private DevExpress.XtraGrid.Columns.GridColumn colListe_ForderungTitel;
        private DevExpress.XtraGrid.Columns.GridColumn colListe_Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colListe_Glaeubiger;
        private DevExpress.XtraGrid.Columns.GridColumn colListe_IstSelektiert;
        private DevExpress.XtraGrid.Columns.GridColumn colListe_SAR;
        private DevExpress.XtraGrid.Columns.GridColumn colListe_Schuldner;
        private DevExpress.XtraGrid.Columns.GridColumn colListe_Status;
        private DevExpress.XtraGrid.Columns.GridColumn colListe_ZahlauftragErstellt;
        private DevExpress.XtraGrid.Columns.GridColumn colListe_ZahlungAn;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissDateEdit edtBuchungsDatum;
        private KiSS4.Gui.KissTextEdit edtBuchungsText;
        private KiSS4.Gui.KissDateEdit edtGeneriertAm;
        private KiSS4.Gui.KissRadioGroup edtSelektionFallX;
        private KiSS4.Gui.KissRadioGroup edtSelektionMonatX;
        private KiSS4.Gui.KissRadioGroup edtSelektionStatusX;
        private KiSS4.Gui.KissRadioGroup edtSelektionTypX;
        private KiSS4.Gui.KissDateEdit edtSollstellungsDatumX;
        private KiSS4.Gui.KissDateEdit edtValutaDatum;
        private KiSS4.Gui.KissLabel edtZuletztErstellteSollstellung;
        private KiSS4.Gui.KissGrid grdBuchung;
        private KiSS4.Gui.KissGrid grdListe;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBuchung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvListe;
        private KiSS4.Gui.KissLabel lblBuchungsDatum;
        private KiSS4.Gui.KissLabel lblBuchungstext;
        private KiSS4.Gui.KissLabel lblGeneriertAm;
        private KiSS4.Gui.KissLabel lblLetzteSollstellung;
        private KiSS4.Gui.KissLabel lblMonat;
        private KiSS4.Gui.KissLabel lblProgress;
        private KiSS4.Gui.KissLabel lblProgress2;
        private KiSS4.Gui.KissLabel lblSelektionFaelle;
        private KiSS4.Gui.KissLabel lblSelektionInkassotyp;
        private KiSS4.Gui.KissLabel lblSelektionMonat;
        private KiSS4.Gui.KissLabel lblSelektionStatus;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblValutaDatum;
        private System.Windows.Forms.PictureBox picTitle;
        private System.Windows.Forms.Panel pnlBuchung;
        private System.Windows.Forms.Panel pnlListe;
        private KiSS4.DB.SqlQuery qryKbBuchung;
        private KiSS4.DB.SqlQuery qryListe;

        #endregion

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKbBelegImportIK));
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition3 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition4 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.colBuchung_BelegStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtBuchungsText = new KiSS4.Gui.KissTextEdit();
            this.edtBuchungsDatum = new KiSS4.Gui.KissDateEdit();
            this.edtValutaDatum = new KiSS4.Gui.KissDateEdit();
            this.edtGeneriertAm = new KiSS4.Gui.KissDateEdit();
            this.btnBelegeImportieren = new KiSS4.Gui.KissButton();
            this.btnRueckgaengig = new KiSS4.Gui.KissButton();
            this.btnAlleAuswaehlen = new KiSS4.Gui.KissButton();
            this.btnAlleEntfernen = new KiSS4.Gui.KissButton();
            this.grdListe = new KiSS4.Gui.KissGrid();
            this.qryListe = new KiSS4.DB.SqlQuery();
            this.grvListe = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colListe_IstSelektiert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListe_SAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListe_Datum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListe_Glaeubiger = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListe_Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListe_Schuldner = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListe_ForderungTitel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListe_Betrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListe_ErledigterMonat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListe_ZahlauftragErstellt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListe_Status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListe_ZahlungAn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListe_Bearbeitet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblBuchungsDatum = new KiSS4.Gui.KissLabel();
            this.lblValutaDatum = new KiSS4.Gui.KissLabel();
            this.lblBuchungstext = new KiSS4.Gui.KissLabel();
            this.lblGeneriertAm = new KiSS4.Gui.KissLabel();
            this.pnlBuchung = new System.Windows.Forms.Panel();
            this.grdBuchung = new KiSS4.Gui.KissGrid();
            this.qryKbBuchung = new KiSS4.DB.SqlQuery();
            this.grvBuchung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBuchung_KbBuchungID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchung_Betrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchung_Valuta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchung_Buchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchung_BelegNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchung_Belegdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchung_KbAuszahlungsArtCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchung_Zahlungsempfaenger = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchung_KbPeriodeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchung_IstAuszahlung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchung_IstAuszahlungALBV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtSelektionTypX = new KiSS4.Gui.KissRadioGroup();
            this.edtSelektionFallX = new KiSS4.Gui.KissRadioGroup();
            this.lblSelektionFaelle = new KiSS4.Gui.KissLabel();
            this.btnMonatszahlen = new KiSS4.Gui.KissButton();
            this.lblLetzteSollstellung = new KiSS4.Gui.KissLabel();
            this.edtZuletztErstellteSollstellung = new KiSS4.Gui.KissLabel();
            this.lblProgress = new KiSS4.Gui.KissLabel();
            this.lblSelektionInkassotyp = new KiSS4.Gui.KissLabel();
            this.lblProgress2 = new KiSS4.Gui.KissLabel();
            this.edtSelektionMonatX = new KiSS4.Gui.KissRadioGroup();
            this.lblSelektionMonat = new KiSS4.Gui.KissLabel();
            this.edtSelektionStatusX = new KiSS4.Gui.KissRadioGroup();
            this.lblSelektionStatus = new KiSS4.Gui.KissLabel();
            this.edtSollstellungsDatumX = new KiSS4.Gui.KissDateEdit();
            this.lblMonat = new KiSS4.Gui.KissLabel();
            this.pnlListe = new System.Windows.Forms.Panel();
            this.picTitle = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.lblSelektionSuche = new KiSS4.Gui.KissLabel();
            this.edtSelektionSucheX = new KiSS4.Gui.KissRadioGroup();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungsText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungsDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValutaDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeneriertAm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdListe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryListe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvListe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungsDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValutaDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeneriertAm)).BeginInit();
            this.pnlBuchung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBuchung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKbBuchung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBuchung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSelektionTypX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSelektionTypX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSelektionFallX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSelektionFallX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSelektionFaelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLetzteSollstellung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZuletztErstellteSollstellung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSelektionInkassotyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProgress2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSelektionMonatX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSelektionMonatX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSelektionMonat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSelektionStatusX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSelektionStatusX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSelektionStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollstellungsDatumX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMonat)).BeginInit();
            this.pnlListe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSelektionSuche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSelektionSucheX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSelektionSucheX.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(744, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 24);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(768, 484);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.pnlBuchung);
            this.tpgListe.Controls.Add(this.lblGeneriertAm);
            this.tpgListe.Controls.Add(this.lblBuchungstext);
            this.tpgListe.Controls.Add(this.lblValutaDatum);
            this.tpgListe.Controls.Add(this.lblBuchungsDatum);
            this.tpgListe.Controls.Add(this.grdListe);
            this.tpgListe.Controls.Add(this.btnAlleEntfernen);
            this.tpgListe.Controls.Add(this.btnAlleAuswaehlen);
            this.tpgListe.Controls.Add(this.btnRueckgaengig);
            this.tpgListe.Controls.Add(this.btnBelegeImportieren);
            this.tpgListe.Controls.Add(this.edtGeneriertAm);
            this.tpgListe.Controls.Add(this.edtValutaDatum);
            this.tpgListe.Controls.Add(this.edtBuchungsDatum);
            this.tpgListe.Controls.Add(this.edtBuchungsText);
            this.tpgListe.Size = new System.Drawing.Size(756, 446);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.lblSelektionSuche);
            this.tpgSuchen.Controls.Add(this.edtSelektionSucheX);
            this.tpgSuchen.Controls.Add(this.lblMonat);
            this.tpgSuchen.Controls.Add(this.edtSollstellungsDatumX);
            this.tpgSuchen.Controls.Add(this.lblSelektionStatus);
            this.tpgSuchen.Controls.Add(this.edtSelektionStatusX);
            this.tpgSuchen.Controls.Add(this.lblSelektionMonat);
            this.tpgSuchen.Controls.Add(this.edtSelektionMonatX);
            this.tpgSuchen.Controls.Add(this.lblProgress2);
            this.tpgSuchen.Controls.Add(this.lblSelektionInkassotyp);
            this.tpgSuchen.Controls.Add(this.lblProgress);
            this.tpgSuchen.Controls.Add(this.edtZuletztErstellteSollstellung);
            this.tpgSuchen.Controls.Add(this.lblLetzteSollstellung);
            this.tpgSuchen.Controls.Add(this.btnMonatszahlen);
            this.tpgSuchen.Controls.Add(this.lblSelektionFaelle);
            this.tpgSuchen.Controls.Add(this.edtSelektionFallX);
            this.tpgSuchen.Controls.Add(this.edtSelektionTypX);
            this.tpgSuchen.Size = new System.Drawing.Size(756, 446);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSelektionTypX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSelektionFallX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSelektionFaelle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.btnMonatszahlen, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblLetzteSollstellung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtZuletztErstellteSollstellung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblProgress, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSelektionInkassotyp, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblProgress2, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSelektionMonatX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSelektionMonat, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSelektionStatusX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSelektionStatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSollstellungsDatumX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblMonat, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSelektionSucheX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSelektionSuche, 0);
            // 
            // colBuchung_BelegStatus
            // 
            this.colBuchung_BelegStatus.Caption = "Belegstatus";
            this.colBuchung_BelegStatus.FieldName = "KbBuchungStatusCode";
            this.colBuchung_BelegStatus.Name = "colBuchung_BelegStatus";
            this.colBuchung_BelegStatus.Visible = true;
            this.colBuchung_BelegStatus.VisibleIndex = 4;
            this.colBuchung_BelegStatus.Width = 84;
            // 
            // edtBuchungsText
            // 
            this.edtBuchungsText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBuchungsText.Location = new System.Drawing.Point(108, 347);
            this.edtBuchungsText.Name = "edtBuchungsText";
            this.edtBuchungsText.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBuchungsText.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchungsText.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchungsText.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchungsText.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchungsText.Properties.Appearance.Options.UseFont = true;
            this.edtBuchungsText.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBuchungsText.Size = new System.Drawing.Size(644, 24);
            this.edtBuchungsText.TabIndex = 0;
            // 
            // edtBuchungsDatum
            // 
            this.edtBuchungsDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBuchungsDatum.EditValue = null;
            this.edtBuchungsDatum.Location = new System.Drawing.Point(109, 381);
            this.edtBuchungsDatum.Name = "edtBuchungsDatum";
            this.edtBuchungsDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBuchungsDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBuchungsDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchungsDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchungsDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchungsDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchungsDatum.Properties.Appearance.Options.UseFont = true;
            this.edtBuchungsDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtBuchungsDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtBuchungsDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtBuchungsDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBuchungsDatum.Properties.ShowToday = false;
            this.edtBuchungsDatum.Size = new System.Drawing.Size(99, 24);
            this.edtBuchungsDatum.TabIndex = 1;
            // 
            // edtValutaDatum
            // 
            this.edtValutaDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtValutaDatum.EditValue = null;
            this.edtValutaDatum.Location = new System.Drawing.Point(301, 381);
            this.edtValutaDatum.Name = "edtValutaDatum";
            this.edtValutaDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtValutaDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtValutaDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtValutaDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtValutaDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtValutaDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtValutaDatum.Properties.Appearance.Options.UseFont = true;
            this.edtValutaDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtValutaDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtValutaDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtValutaDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtValutaDatum.Properties.ShowToday = false;
            this.edtValutaDatum.Size = new System.Drawing.Size(99, 24);
            this.edtValutaDatum.TabIndex = 2;
            // 
            // edtGeneriertAm
            // 
            this.edtGeneriertAm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtGeneriertAm.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGeneriertAm.EditValue = null;
            this.edtGeneriertAm.Location = new System.Drawing.Point(506, 381);
            this.edtGeneriertAm.Name = "edtGeneriertAm";
            this.edtGeneriertAm.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGeneriertAm.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGeneriertAm.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeneriertAm.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeneriertAm.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeneriertAm.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeneriertAm.Properties.Appearance.Options.UseFont = true;
            this.edtGeneriertAm.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtGeneriertAm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGeneriertAm.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtGeneriertAm.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeneriertAm.Properties.ReadOnly = true;
            this.edtGeneriertAm.Properties.ShowToday = false;
            this.edtGeneriertAm.Size = new System.Drawing.Size(100, 24);
            this.edtGeneriertAm.TabIndex = 3;
            // 
            // btnBelegeImportieren
            // 
            this.btnBelegeImportieren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBelegeImportieren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBelegeImportieren.Location = new System.Drawing.Point(109, 420);
            this.btnBelegeImportieren.Name = "btnBelegeImportieren";
            this.btnBelegeImportieren.Size = new System.Drawing.Size(127, 24);
            this.btnBelegeImportieren.TabIndex = 4;
            this.btnBelegeImportieren.Text = "Belege importieren";
            this.btnBelegeImportieren.UseCompatibleTextRendering = true;
            this.btnBelegeImportieren.UseVisualStyleBackColor = false;
            this.btnBelegeImportieren.Click += new System.EventHandler(this.btnBelegeImportieren_Click);
            // 
            // btnRueckgaengig
            // 
            this.btnRueckgaengig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRueckgaengig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRueckgaengig.Location = new System.Drawing.Point(281, 420);
            this.btnRueckgaengig.Name = "btnRueckgaengig";
            this.btnRueckgaengig.Size = new System.Drawing.Size(127, 24);
            this.btnRueckgaengig.TabIndex = 5;
            this.btnRueckgaengig.Text = "Rückgängig";
            this.btnRueckgaengig.UseCompatibleTextRendering = true;
            this.btnRueckgaengig.UseVisualStyleBackColor = false;
            this.btnRueckgaengig.Click += new System.EventHandler(this.btnRueckgaengig_Click);
            // 
            // btnAlleAuswaehlen
            // 
            this.btnAlleAuswaehlen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlleAuswaehlen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlleAuswaehlen.Location = new System.Drawing.Point(482, 420);
            this.btnAlleAuswaehlen.Name = "btnAlleAuswaehlen";
            this.btnAlleAuswaehlen.Size = new System.Drawing.Size(127, 24);
            this.btnAlleAuswaehlen.TabIndex = 6;
            this.btnAlleAuswaehlen.Text = "Alle auswählen";
            this.btnAlleAuswaehlen.UseCompatibleTextRendering = true;
            this.btnAlleAuswaehlen.UseVisualStyleBackColor = false;
            this.btnAlleAuswaehlen.Visible = false;
            // 
            // btnAlleEntfernen
            // 
            this.btnAlleEntfernen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlleEntfernen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlleEntfernen.Location = new System.Drawing.Point(625, 420);
            this.btnAlleEntfernen.Name = "btnAlleEntfernen";
            this.btnAlleEntfernen.Size = new System.Drawing.Size(127, 24);
            this.btnAlleEntfernen.TabIndex = 7;
            this.btnAlleEntfernen.Text = "Alle entfernen";
            this.btnAlleEntfernen.UseCompatibleTextRendering = true;
            this.btnAlleEntfernen.UseVisualStyleBackColor = false;
            this.btnAlleEntfernen.Visible = false;
            // 
            // grdListe
            // 
            this.grdListe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdListe.DataSource = this.qryListe;
            // 
            // 
            // 
            this.grdListe.EmbeddedNavigator.Name = "";
            this.grdListe.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdListe.Location = new System.Drawing.Point(0, 0);
            this.grdListe.MainView = this.grvListe;
            this.grdListe.Name = "grdListe";
            this.grdListe.Size = new System.Drawing.Size(756, 161);
            this.grdListe.TabIndex = 106;
            this.grdListe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvListe});
            // 
            // qryListe
            // 
            this.qryListe.BatchUpdate = true;
            this.qryListe.CanUpdate = true;
            this.qryListe.FillTimeOut = 90;
            this.qryListe.HostControl = this;
            this.qryListe.IsIdentityInsert = false;
            this.qryListe.SelectStatement = resources.GetString("qryListe.SelectStatement");
            this.qryListe.TableName = "IkPosition";
            this.qryListe.PositionChanged += new System.EventHandler(this.qryListe_PositionChanged);
            // 
            // grvListe
            // 
            this.grvListe.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvListe.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe.Appearance.Empty.Options.UseBackColor = true;
            this.grvListe.Appearance.Empty.Options.UseFont = true;
            this.grvListe.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvListe.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvListe.Appearance.EvenRow.Options.UseFont = true;
            this.grvListe.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvListe.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvListe.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvListe.Appearance.FocusedCell.Options.UseFont = true;
            this.grvListe.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvListe.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvListe.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvListe.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvListe.Appearance.FocusedRow.Options.UseFont = true;
            this.grvListe.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvListe.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvListe.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvListe.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvListe.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvListe.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvListe.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvListe.Appearance.GroupRow.Options.UseFont = true;
            this.grvListe.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvListe.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvListe.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvListe.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvListe.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvListe.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvListe.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvListe.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvListe.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvListe.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvListe.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvListe.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvListe.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvListe.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvListe.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe.Appearance.OddRow.Options.UseFont = true;
            this.grvListe.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvListe.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe.Appearance.Row.Options.UseBackColor = true;
            this.grvListe.Appearance.Row.Options.UseFont = true;
            this.grvListe.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvListe.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvListe.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvListe.Appearance.SelectedRow.Options.UseFont = true;
            this.grvListe.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvListe.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvListe.Appearance.VertLine.Options.UseBackColor = true;
            this.grvListe.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvListe.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colListe_IstSelektiert,
            this.colListe_SAR,
            this.colListe_Datum,
            this.colListe_Glaeubiger,
            this.colListe_Geburtsdatum,
            this.colListe_Schuldner,
            this.colListe_ForderungTitel,
            this.colListe_Betrag,
            this.colListe_ErledigterMonat,
            this.colListe_ZahlauftragErstellt,
            this.colListe_Status,
            this.colListe_ZahlungAn,
            this.colListe_Bearbeitet});
            this.grvListe.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvListe.GridControl = this.grdListe;
            this.grvListe.Name = "grvListe";
            this.grvListe.OptionsBehavior.Editable = false;
            this.grvListe.OptionsCustomization.AllowFilter = false;
            this.grvListe.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvListe.OptionsNavigation.AutoFocusNewRow = true;
            this.grvListe.OptionsNavigation.UseTabKey = false;
            this.grvListe.OptionsSelection.MultiSelect = true;
            this.grvListe.OptionsView.ColumnAutoWidth = false;
            this.grvListe.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvListe.OptionsView.ShowGroupPanel = false;
            this.grvListe.OptionsView.ShowIndicator = false;
            this.grvListe.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grvListe_CustomDrawCell);
            // 
            // colListe_IstSelektiert
            // 
            this.colListe_IstSelektiert.AppearanceCell.BackColor = System.Drawing.Color.AliceBlue;
            this.colListe_IstSelektiert.AppearanceCell.Options.UseBackColor = true;
            this.colListe_IstSelektiert.Caption = "sel.";
            this.colListe_IstSelektiert.FieldName = "IstSelektiert";
            this.colListe_IstSelektiert.Name = "colListe_IstSelektiert";
            this.colListe_IstSelektiert.Width = 36;
            // 
            // colListe_SAR
            // 
            this.colListe_SAR.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colListe_SAR.AppearanceCell.Options.UseBackColor = true;
            this.colListe_SAR.Caption = "SAR";
            this.colListe_SAR.FieldName = "Username";
            this.colListe_SAR.Name = "colListe_SAR";
            this.colListe_SAR.OptionsColumn.AllowEdit = false;
            this.colListe_SAR.Visible = true;
            this.colListe_SAR.VisibleIndex = 0;
            this.colListe_SAR.Width = 91;
            // 
            // colListe_Datum
            // 
            this.colListe_Datum.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colListe_Datum.AppearanceCell.Options.UseBackColor = true;
            this.colListe_Datum.Caption = "Monat";
            this.colListe_Datum.DisplayFormat.FormatString = "yyyy.MM";
            this.colListe_Datum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colListe_Datum.FieldName = "Datum";
            this.colListe_Datum.Name = "colListe_Datum";
            this.colListe_Datum.OptionsColumn.AllowEdit = false;
            this.colListe_Datum.Visible = true;
            this.colListe_Datum.VisibleIndex = 1;
            this.colListe_Datum.Width = 73;
            // 
            // colListe_Glaeubiger
            // 
            this.colListe_Glaeubiger.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colListe_Glaeubiger.AppearanceCell.Options.UseBackColor = true;
            this.colListe_Glaeubiger.Caption = "Gläubiger";
            this.colListe_Glaeubiger.FieldName = "Glaeubiger";
            this.colListe_Glaeubiger.Name = "colListe_Glaeubiger";
            this.colListe_Glaeubiger.OptionsColumn.AllowEdit = false;
            this.colListe_Glaeubiger.Visible = true;
            this.colListe_Glaeubiger.VisibleIndex = 2;
            this.colListe_Glaeubiger.Width = 165;
            // 
            // colListe_Geburtsdatum
            // 
            this.colListe_Geburtsdatum.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colListe_Geburtsdatum.AppearanceCell.Options.UseBackColor = true;
            this.colListe_Geburtsdatum.Caption = "Geb.Datum";
            this.colListe_Geburtsdatum.FieldName = "Geburtsdatum";
            this.colListe_Geburtsdatum.Name = "colListe_Geburtsdatum";
            this.colListe_Geburtsdatum.OptionsColumn.AllowEdit = false;
            this.colListe_Geburtsdatum.Visible = true;
            this.colListe_Geburtsdatum.VisibleIndex = 3;
            this.colListe_Geburtsdatum.Width = 74;
            // 
            // colListe_Schuldner
            // 
            this.colListe_Schuldner.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colListe_Schuldner.AppearanceCell.Options.UseBackColor = true;
            this.colListe_Schuldner.Caption = "Schuldner";
            this.colListe_Schuldner.FieldName = "Schuldner";
            this.colListe_Schuldner.Name = "colListe_Schuldner";
            this.colListe_Schuldner.OptionsColumn.AllowEdit = false;
            this.colListe_Schuldner.Visible = true;
            this.colListe_Schuldner.VisibleIndex = 4;
            this.colListe_Schuldner.Width = 108;
            // 
            // colListe_ForderungTitel
            // 
            this.colListe_ForderungTitel.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colListe_ForderungTitel.AppearanceCell.Options.UseBackColor = true;
            this.colListe_ForderungTitel.Caption = "Forderungs Art";
            this.colListe_ForderungTitel.FieldName = "ForderungTitel";
            this.colListe_ForderungTitel.Name = "colListe_ForderungTitel";
            this.colListe_ForderungTitel.OptionsColumn.AllowEdit = false;
            this.colListe_ForderungTitel.Visible = true;
            this.colListe_ForderungTitel.VisibleIndex = 5;
            this.colListe_ForderungTitel.Width = 115;
            // 
            // colListe_Betrag
            // 
            this.colListe_Betrag.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colListe_Betrag.AppearanceCell.Options.UseBackColor = true;
            this.colListe_Betrag.AppearanceHeader.Options.UseTextOptions = true;
            this.colListe_Betrag.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colListe_Betrag.Caption = "Betrag";
            this.colListe_Betrag.DisplayFormat.FormatString = "N2";
            this.colListe_Betrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colListe_Betrag.FieldName = "Betrag";
            this.colListe_Betrag.Name = "colListe_Betrag";
            this.colListe_Betrag.OptionsColumn.AllowEdit = false;
            this.colListe_Betrag.Visible = true;
            this.colListe_Betrag.VisibleIndex = 6;
            this.colListe_Betrag.Width = 70;
            // 
            // colListe_ErledigterMonat
            // 
            this.colListe_ErledigterMonat.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colListe_ErledigterMonat.AppearanceCell.Options.UseBackColor = true;
            this.colListe_ErledigterMonat.Caption = "verb.";
            this.colListe_ErledigterMonat.FieldName = "ErledigterMonat";
            this.colListe_ErledigterMonat.Name = "colListe_ErledigterMonat";
            this.colListe_ErledigterMonat.Visible = true;
            this.colListe_ErledigterMonat.VisibleIndex = 7;
            this.colListe_ErledigterMonat.Width = 40;
            // 
            // colListe_ZahlauftragErstellt
            // 
            this.colListe_ZahlauftragErstellt.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colListe_ZahlauftragErstellt.AppearanceCell.Options.UseBackColor = true;
            this.colListe_ZahlauftragErstellt.Caption = "bez.";
            this.colListe_ZahlauftragErstellt.FieldName = "ZahlauftragErstellt";
            this.colListe_ZahlauftragErstellt.Name = "colListe_ZahlauftragErstellt";
            this.colListe_ZahlauftragErstellt.OptionsColumn.AllowEdit = false;
            this.colListe_ZahlauftragErstellt.Visible = true;
            this.colListe_ZahlauftragErstellt.VisibleIndex = 8;
            this.colListe_ZahlauftragErstellt.Width = 40;
            // 
            // colListe_Status
            // 
            this.colListe_Status.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colListe_Status.AppearanceCell.Options.UseBackColor = true;
            this.colListe_Status.Caption = "Status";
            this.colListe_Status.FieldName = "Status";
            this.colListe_Status.Name = "colListe_Status";
            this.colListe_Status.OptionsColumn.AllowEdit = false;
            this.colListe_Status.Visible = true;
            this.colListe_Status.VisibleIndex = 9;
            this.colListe_Status.Width = 120;
            // 
            // colListe_ZahlungAn
            // 
            this.colListe_ZahlungAn.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colListe_ZahlungAn.AppearanceCell.Options.UseBackColor = true;
            this.colListe_ZahlungAn.Caption = "Zahlung an";
            this.colListe_ZahlungAn.FieldName = "ZahlungAn";
            this.colListe_ZahlungAn.Name = "colListe_ZahlungAn";
            this.colListe_ZahlungAn.OptionsColumn.AllowEdit = false;
            this.colListe_ZahlungAn.Visible = true;
            this.colListe_ZahlungAn.VisibleIndex = 10;
            this.colListe_ZahlungAn.Width = 120;
            // 
            // colListe_Bearbeitet
            // 
            this.colListe_Bearbeitet.Caption = "Bearbeitet";
            this.colListe_Bearbeitet.FieldName = "Bearbeitet";
            this.colListe_Bearbeitet.Name = "colListe_Bearbeitet";
            this.colListe_Bearbeitet.Visible = true;
            this.colListe_Bearbeitet.VisibleIndex = 11;
            // 
            // lblBuchungsDatum
            // 
            this.lblBuchungsDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBuchungsDatum.Location = new System.Drawing.Point(2, 381);
            this.lblBuchungsDatum.Name = "lblBuchungsDatum";
            this.lblBuchungsDatum.Size = new System.Drawing.Size(100, 24);
            this.lblBuchungsDatum.TabIndex = 114;
            this.lblBuchungsDatum.Text = "Buchungs Datum";
            this.lblBuchungsDatum.UseCompatibleTextRendering = true;
            // 
            // lblValutaDatum
            // 
            this.lblValutaDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblValutaDatum.Location = new System.Drawing.Point(227, 381);
            this.lblValutaDatum.Name = "lblValutaDatum";
            this.lblValutaDatum.Size = new System.Drawing.Size(68, 24);
            this.lblValutaDatum.TabIndex = 115;
            this.lblValutaDatum.Text = "Valuta Datum";
            this.lblValutaDatum.UseCompatibleTextRendering = true;
            // 
            // lblBuchungstext
            // 
            this.lblBuchungstext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBuchungstext.Location = new System.Drawing.Point(2, 347);
            this.lblBuchungstext.Name = "lblBuchungstext";
            this.lblBuchungstext.Size = new System.Drawing.Size(100, 24);
            this.lblBuchungstext.TabIndex = 116;
            this.lblBuchungstext.Text = "Buchungstext";
            this.lblBuchungstext.UseCompatibleTextRendering = true;
            // 
            // lblGeneriertAm
            // 
            this.lblGeneriertAm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGeneriertAm.Location = new System.Drawing.Point(427, 381);
            this.lblGeneriertAm.Name = "lblGeneriertAm";
            this.lblGeneriertAm.Size = new System.Drawing.Size(73, 24);
            this.lblGeneriertAm.TabIndex = 118;
            this.lblGeneriertAm.Text = "Generiert am";
            this.lblGeneriertAm.UseCompatibleTextRendering = true;
            // 
            // pnlBuchung
            // 
            this.pnlBuchung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBuchung.Controls.Add(this.grdBuchung);
            this.pnlBuchung.Location = new System.Drawing.Point(0, 167);
            this.pnlBuchung.Name = "pnlBuchung";
            this.pnlBuchung.Size = new System.Drawing.Size(756, 172);
            this.pnlBuchung.TabIndex = 119;
            // 
            // grdBuchung
            // 
            this.grdBuchung.DataSource = this.qryKbBuchung;
            this.grdBuchung.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdBuchung.EmbeddedNavigator.Name = "";
            this.grdBuchung.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBuchung.Location = new System.Drawing.Point(0, 0);
            this.grdBuchung.MainView = this.grvBuchung;
            this.grdBuchung.Name = "grdBuchung";
            this.grdBuchung.Size = new System.Drawing.Size(756, 172);
            this.grdBuchung.TabIndex = 3;
            this.grdBuchung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBuchung});
            // 
            // qryKbBuchung
            // 
            this.qryKbBuchung.HostControl = this;
            this.qryKbBuchung.IsIdentityInsert = false;
            this.qryKbBuchung.SelectStatement = resources.GetString("qryKbBuchung.SelectStatement");
            this.qryKbBuchung.PositionChanged += new System.EventHandler(this.qryKbBuchung_PositionChanged);
            // 
            // grvBuchung
            // 
            this.grvBuchung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBuchung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBuchung.Appearance.Empty.Options.UseBackColor = true;
            this.grvBuchung.Appearance.Empty.Options.UseFont = true;
            this.grvBuchung.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvBuchung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBuchung.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvBuchung.Appearance.EvenRow.Options.UseFont = true;
            this.grvBuchung.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBuchung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBuchung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBuchung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBuchung.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBuchung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBuchung.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBuchung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBuchung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBuchung.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBuchung.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBuchung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBuchung.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBuchung.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBuchung.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvBuchung.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvBuchung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBuchung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBuchung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBuchung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBuchung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBuchung.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBuchung.Appearance.GroupRow.Options.UseFont = true;
            this.grvBuchung.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBuchung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBuchung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBuchung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBuchung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBuchung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBuchung.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBuchung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBuchung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBuchung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBuchung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBuchung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBuchung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBuchung.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBuchung.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBuchung.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvBuchung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBuchung.Appearance.OddRow.Options.UseBackColor = true;
            this.grvBuchung.Appearance.OddRow.Options.UseFont = true;
            this.grvBuchung.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBuchung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBuchung.Appearance.Row.Options.UseBackColor = true;
            this.grvBuchung.Appearance.Row.Options.UseFont = true;
            this.grvBuchung.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvBuchung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBuchung.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvBuchung.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvBuchung.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBuchung.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvBuchung.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBuchung.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBuchung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBuchung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBuchung_KbBuchungID,
            this.colBuchung_Betrag,
            this.colBuchung_Valuta,
            this.colBuchung_Buchungstext,
            this.colBuchung_BelegStatus,
            this.colBuchung_BelegNr,
            this.colBuchung_Belegdatum,
            this.colBuchung_KbAuszahlungsArtCode,
            this.colBuchung_Zahlungsempfaenger,
            this.colBuchung_KbPeriodeID,
            this.colBuchung_IstAuszahlung,
            this.colBuchung_IstAuszahlungALBV});
            this.grvBuchung.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.PaleGreen;
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.colBuchung_BelegStatus;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = 102;
            styleFormatCondition2.Appearance.BackColor = System.Drawing.Color.Gold;
            styleFormatCondition2.Appearance.Options.UseBackColor = true;
            styleFormatCondition2.ApplyToRow = true;
            styleFormatCondition2.Column = this.colBuchung_BelegStatus;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition2.Value1 = 103;
            styleFormatCondition3.Appearance.BackColor = System.Drawing.Color.LightCoral;
            styleFormatCondition3.Appearance.Options.UseBackColor = true;
            styleFormatCondition3.ApplyToRow = true;
            styleFormatCondition3.Column = this.colBuchung_BelegStatus;
            styleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition3.Value1 = "104";
            styleFormatCondition4.Appearance.BackColor = System.Drawing.Color.DarkGray;
            styleFormatCondition4.Appearance.Options.UseBackColor = true;
            styleFormatCondition4.ApplyToRow = true;
            styleFormatCondition4.Column = this.colBuchung_BelegStatus;
            styleFormatCondition4.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition4.Value1 = "106";
            this.grvBuchung.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2,
            styleFormatCondition3,
            styleFormatCondition4});
            this.grvBuchung.GridControl = this.grdBuchung;
            this.grvBuchung.Name = "grvBuchung";
            this.grvBuchung.OptionsBehavior.Editable = false;
            this.grvBuchung.OptionsCustomization.AllowFilter = false;
            this.grvBuchung.OptionsDetail.ShowDetailTabs = false;
            this.grvBuchung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBuchung.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBuchung.OptionsNavigation.UseTabKey = false;
            this.grvBuchung.OptionsSelection.MultiSelect = true;
            this.grvBuchung.OptionsView.ColumnAutoWidth = false;
            this.grvBuchung.OptionsView.ShowChildrenInGroupPanel = true;
            this.grvBuchung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBuchung.OptionsView.ShowFooter = true;
            this.grvBuchung.OptionsView.ShowGroupPanel = false;
            this.grvBuchung.OptionsView.ShowIndicator = false;
            this.grvBuchung.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grvBuchung_CustomDrawCell);
            // 
            // colBuchung_KbBuchungID
            // 
            this.colBuchung_KbBuchungID.AppearanceCell.Options.UseTextOptions = true;
            this.colBuchung_KbBuchungID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colBuchung_KbBuchungID.Caption = "Beleg-ID";
            this.colBuchung_KbBuchungID.FieldName = "KbBuchungID";
            this.colBuchung_KbBuchungID.MinWidth = 10;
            this.colBuchung_KbBuchungID.Name = "colBuchung_KbBuchungID";
            this.colBuchung_KbBuchungID.Visible = true;
            this.colBuchung_KbBuchungID.VisibleIndex = 0;
            this.colBuchung_KbBuchungID.Width = 64;
            // 
            // colBuchung_Betrag
            // 
            this.colBuchung_Betrag.AppearanceCell.Options.UseTextOptions = true;
            this.colBuchung_Betrag.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colBuchung_Betrag.Caption = "Betrag";
            this.colBuchung_Betrag.DisplayFormat.FormatString = "n2";
            this.colBuchung_Betrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBuchung_Betrag.FieldName = "Betrag";
            this.colBuchung_Betrag.Name = "colBuchung_Betrag";
            this.colBuchung_Betrag.SummaryItem.DisplayFormat = "{0:n2}";
            this.colBuchung_Betrag.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colBuchung_Betrag.Visible = true;
            this.colBuchung_Betrag.VisibleIndex = 1;
            // 
            // colBuchung_Valuta
            // 
            this.colBuchung_Valuta.Caption = "Valuta";
            this.colBuchung_Valuta.FieldName = "ValutaDatum";
            this.colBuchung_Valuta.Name = "colBuchung_Valuta";
            this.colBuchung_Valuta.Visible = true;
            this.colBuchung_Valuta.VisibleIndex = 2;
            this.colBuchung_Valuta.Width = 77;
            // 
            // colBuchung_Buchungstext
            // 
            this.colBuchung_Buchungstext.Caption = "Buchungstext";
            this.colBuchung_Buchungstext.FieldName = "Text";
            this.colBuchung_Buchungstext.Name = "colBuchung_Buchungstext";
            this.colBuchung_Buchungstext.Visible = true;
            this.colBuchung_Buchungstext.VisibleIndex = 3;
            this.colBuchung_Buchungstext.Width = 135;
            // 
            // colBuchung_BelegNr
            // 
            this.colBuchung_BelegNr.Caption = "Beleg-Nr";
            this.colBuchung_BelegNr.FieldName = "BelegNr";
            this.colBuchung_BelegNr.Name = "colBuchung_BelegNr";
            this.colBuchung_BelegNr.Visible = true;
            this.colBuchung_BelegNr.VisibleIndex = 5;
            this.colBuchung_BelegNr.Width = 92;
            // 
            // colBuchung_Belegdatum
            // 
            this.colBuchung_Belegdatum.Caption = "Belegdatum";
            this.colBuchung_Belegdatum.FieldName = "BelegDatum";
            this.colBuchung_Belegdatum.Name = "colBuchung_Belegdatum";
            this.colBuchung_Belegdatum.Visible = true;
            this.colBuchung_Belegdatum.VisibleIndex = 6;
            this.colBuchung_Belegdatum.Width = 80;
            // 
            // colBuchung_KbAuszahlungsArtCode
            // 
            this.colBuchung_KbAuszahlungsArtCode.Caption = "Auszahlungsart";
            this.colBuchung_KbAuszahlungsArtCode.FieldName = "KbAuszahlungsArtCode";
            this.colBuchung_KbAuszahlungsArtCode.Name = "colBuchung_KbAuszahlungsArtCode";
            this.colBuchung_KbAuszahlungsArtCode.Visible = true;
            this.colBuchung_KbAuszahlungsArtCode.VisibleIndex = 7;
            this.colBuchung_KbAuszahlungsArtCode.Width = 122;
            // 
            // colBuchung_Zahlungsempfaenger
            // 
            this.colBuchung_Zahlungsempfaenger.Caption = "Zahlungsempfaenger";
            this.colBuchung_Zahlungsempfaenger.FieldName = "Zahlungsempfaenger";
            this.colBuchung_Zahlungsempfaenger.Name = "colBuchung_Zahlungsempfaenger";
            this.colBuchung_Zahlungsempfaenger.Visible = true;
            this.colBuchung_Zahlungsempfaenger.VisibleIndex = 8;
            this.colBuchung_Zahlungsempfaenger.Width = 159;
            // 
            // colBuchung_KbPeriodeID
            // 
            this.colBuchung_KbPeriodeID.Caption = "KbPeriodeID";
            this.colBuchung_KbPeriodeID.FieldName = "KbPeriodeID";
            this.colBuchung_KbPeriodeID.Name = "colBuchung_KbPeriodeID";
            // 
            // colBuchung_IstAuszahlung
            // 
            this.colBuchung_IstAuszahlung.Caption = "IstAuszahlung";
            this.colBuchung_IstAuszahlung.FieldName = "IstAuszahlung";
            this.colBuchung_IstAuszahlung.Name = "colBuchung_IstAuszahlung";
            // 
            // colBuchung_IstAuszahlungALBV
            // 
            this.colBuchung_IstAuszahlungALBV.Caption = "IstAuszahlungALBV";
            this.colBuchung_IstAuszahlungALBV.FieldName = "IstAuszahlungALBV";
            this.colBuchung_IstAuszahlungALBV.Name = "colBuchung_IstAuszahlungALBV";
            // 
            // edtSelektionTypX
            // 
            this.edtSelektionTypX.EditValue = "1";
            this.edtSelektionTypX.Location = new System.Drawing.Point(9, 124);
            this.edtSelektionTypX.LookupSQL = null;
            this.edtSelektionTypX.LOVFilter = null;
            this.edtSelektionTypX.LOVName = null;
            this.edtSelektionTypX.Name = "edtSelektionTypX";
            this.edtSelektionTypX.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtSelektionTypX.Properties.Appearance.Options.UseBackColor = true;
            this.edtSelektionTypX.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.edtSelektionTypX.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.edtSelektionTypX.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "Forderungen + ALBV Auszahlung"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("2", "Alimentenvermittlung Auszahlung")});
            this.edtSelektionTypX.Size = new System.Drawing.Size(221, 47);
            this.edtSelektionTypX.TabIndex = 120;
            this.edtSelektionTypX.EditValueChanged += new System.EventHandler(this.edtSelektionTypX_EditValueChanged);
            // 
            // edtSelektionFallX
            // 
            this.edtSelektionFallX.EditValue = "2";
            this.edtSelektionFallX.Location = new System.Drawing.Point(236, 125);
            this.edtSelektionFallX.LookupSQL = null;
            this.edtSelektionFallX.LOVFilter = null;
            this.edtSelektionFallX.LOVName = null;
            this.edtSelektionFallX.Name = "edtSelektionFallX";
            this.edtSelektionFallX.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtSelektionFallX.Properties.Appearance.Options.UseBackColor = true;
            this.edtSelektionFallX.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.edtSelektionFallX.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.edtSelektionFallX.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "Nur eigene Fälle"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("2", "alle Fälle")});
            this.edtSelektionFallX.Size = new System.Drawing.Size(141, 46);
            this.edtSelektionFallX.TabIndex = 121;
            // 
            // lblSelektionFaelle
            // 
            this.lblSelektionFaelle.Location = new System.Drawing.Point(237, 97);
            this.lblSelektionFaelle.Name = "lblSelektionFaelle";
            this.lblSelektionFaelle.Size = new System.Drawing.Size(79, 24);
            this.lblSelektionFaelle.TabIndex = 123;
            this.lblSelektionFaelle.Text = "Selektion Fälle";
            this.lblSelektionFaelle.UseCompatibleTextRendering = true;
            // 
            // btnMonatszahlen
            // 
            this.btnMonatszahlen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonatszahlen.Location = new System.Drawing.Point(3, 383);
            this.btnMonatszahlen.Name = "btnMonatszahlen";
            this.btnMonatszahlen.Size = new System.Drawing.Size(125, 24);
            this.btnMonatszahlen.TabIndex = 124;
            this.btnMonatszahlen.Text = "Monatszahlen";
            this.btnMonatszahlen.UseCompatibleTextRendering = true;
            this.btnMonatszahlen.UseVisualStyleBackColor = false;
            this.btnMonatszahlen.Click += new System.EventHandler(this.btnMonatszahlen_Click);
            // 
            // lblLetzteSollstellung
            // 
            this.lblLetzteSollstellung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLetzteSollstellung.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblLetzteSollstellung.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblLetzteSollstellung.Location = new System.Drawing.Point(3, 309);
            this.lblLetzteSollstellung.Name = "lblLetzteSollstellung";
            this.lblLetzteSollstellung.Size = new System.Drawing.Size(336, 66);
            this.lblLetzteSollstellung.TabIndex = 125;
            this.lblLetzteSollstellung.Text = "Sollstellung";
            this.lblLetzteSollstellung.UseCompatibleTextRendering = true;
            // 
            // edtZuletztErstellteSollstellung
            // 
            this.edtZuletztErstellteSollstellung.Location = new System.Drawing.Point(3, 285);
            this.edtZuletztErstellteSollstellung.Name = "edtZuletztErstellteSollstellung";
            this.edtZuletztErstellteSollstellung.Size = new System.Drawing.Size(213, 24);
            this.edtZuletztErstellteSollstellung.TabIndex = 126;
            this.edtZuletztErstellteSollstellung.Text = "zuletzt erstellte Sollstellung";
            this.edtZuletztErstellteSollstellung.UseCompatibleTextRendering = true;
            // 
            // lblProgress
            // 
            this.lblProgress.Location = new System.Drawing.Point(147, 383);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(455, 24);
            this.lblProgress.TabIndex = 127;
            this.lblProgress.Text = "0 /  0";
            this.lblProgress.UseCompatibleTextRendering = true;
            // 
            // lblSelektionInkassotyp
            // 
            this.lblSelektionInkassotyp.Location = new System.Drawing.Point(10, 97);
            this.lblSelektionInkassotyp.Name = "lblSelektionInkassotyp";
            this.lblSelektionInkassotyp.Size = new System.Drawing.Size(124, 24);
            this.lblSelektionInkassotyp.TabIndex = 128;
            this.lblSelektionInkassotyp.Text = "Selektion Inkassotyp";
            this.lblSelektionInkassotyp.UseCompatibleTextRendering = true;
            // 
            // lblProgress2
            // 
            this.lblProgress2.Location = new System.Drawing.Point(147, 413);
            this.lblProgress2.Name = "lblProgress2";
            this.lblProgress2.Size = new System.Drawing.Size(455, 24);
            this.lblProgress2.TabIndex = 129;
            this.lblProgress2.Text = "";
            this.lblProgress2.UseCompatibleTextRendering = true;
            // 
            // edtSelektionMonatX
            // 
            this.edtSelektionMonatX.EditValue = "1";
            this.edtSelektionMonatX.Location = new System.Drawing.Point(390, 125);
            this.edtSelektionMonatX.LookupSQL = null;
            this.edtSelektionMonatX.LOVFilter = null;
            this.edtSelektionMonatX.LOVName = null;
            this.edtSelektionMonatX.Name = "edtSelektionMonatX";
            this.edtSelektionMonatX.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtSelektionMonatX.Properties.Appearance.Options.UseBackColor = true;
            this.edtSelektionMonatX.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.edtSelektionMonatX.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.edtSelektionMonatX.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "alle für diesen Monat"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("2", "alle vor diesem Monat")});
            this.edtSelektionMonatX.Size = new System.Drawing.Size(159, 46);
            this.edtSelektionMonatX.TabIndex = 130;
            // 
            // lblSelektionMonat
            // 
            this.lblSelektionMonat.Location = new System.Drawing.Point(391, 97);
            this.lblSelektionMonat.Name = "lblSelektionMonat";
            this.lblSelektionMonat.Size = new System.Drawing.Size(111, 24);
            this.lblSelektionMonat.TabIndex = 131;
            this.lblSelektionMonat.Text = "Selektion Monate";
            this.lblSelektionMonat.UseCompatibleTextRendering = true;
            // 
            // edtSelektionStatusX
            // 
            this.edtSelektionStatusX.EditValue = "1";
            this.edtSelektionStatusX.Location = new System.Drawing.Point(236, 209);
            this.edtSelektionStatusX.LookupSQL = null;
            this.edtSelektionStatusX.LOVFilter = null;
            this.edtSelektionStatusX.LOVName = null;
            this.edtSelektionStatusX.Name = "edtSelektionStatusX";
            this.edtSelektionStatusX.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtSelektionStatusX.Properties.Appearance.Options.UseBackColor = true;
            this.edtSelektionStatusX.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.edtSelektionStatusX.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.edtSelektionStatusX.Properties.Columns = 2;
            this.edtSelektionStatusX.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "nur unverbuchte Daten"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("2", "nur verbuchte Daten"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("3", "nur bezahlte Daten"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("4", "alle Daten")});
            this.edtSelektionStatusX.Size = new System.Drawing.Size(313, 46);
            this.edtSelektionStatusX.TabIndex = 132;
            // 
            // lblSelektionStatus
            // 
            this.lblSelektionStatus.Location = new System.Drawing.Point(237, 182);
            this.lblSelektionStatus.Name = "lblSelektionStatus";
            this.lblSelektionStatus.Size = new System.Drawing.Size(111, 24);
            this.lblSelektionStatus.TabIndex = 133;
            this.lblSelektionStatus.Text = "Selektion Status";
            this.lblSelektionStatus.UseCompatibleTextRendering = true;
            // 
            // edtSollstellungsDatumX
            // 
            this.edtSollstellungsDatumX.EditValue = null;
            this.edtSollstellungsDatumX.Location = new System.Drawing.Point(163, 45);
            this.edtSollstellungsDatumX.Name = "edtSollstellungsDatumX";
            this.edtSollstellungsDatumX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSollstellungsDatumX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSollstellungsDatumX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSollstellungsDatumX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSollstellungsDatumX.Properties.Appearance.Options.UseBackColor = true;
            this.edtSollstellungsDatumX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSollstellungsDatumX.Properties.Appearance.Options.UseFont = true;
            this.edtSollstellungsDatumX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtSollstellungsDatumX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSollstellungsDatumX.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtSollstellungsDatumX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSollstellungsDatumX.Properties.DisplayFormat.FormatString = "MM.yyyy";
            this.edtSollstellungsDatumX.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtSollstellungsDatumX.Properties.EditFormat.FormatString = "MM.yyyy";
            this.edtSollstellungsDatumX.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtSollstellungsDatumX.Properties.Mask.EditMask = "MM.yyyy";
            this.edtSollstellungsDatumX.Properties.ShowToday = false;
            this.edtSollstellungsDatumX.Size = new System.Drawing.Size(99, 24);
            this.edtSollstellungsDatumX.TabIndex = 134;
            // 
            // lblMonat
            // 
            this.lblMonat.Location = new System.Drawing.Point(9, 45);
            this.lblMonat.Name = "lblMonat";
            this.lblMonat.Size = new System.Drawing.Size(148, 24);
            this.lblMonat.TabIndex = 135;
            this.lblMonat.Text = "Monat  MM.JJJJ";
            this.lblMonat.UseCompatibleTextRendering = true;
            // 
            // pnlListe
            // 
            this.pnlListe.Controls.Add(this.picTitle);
            this.pnlListe.Controls.Add(this.lblTitel);
            this.pnlListe.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlListe.Location = new System.Drawing.Point(0, 0);
            this.pnlListe.Name = "pnlListe";
            this.pnlListe.Size = new System.Drawing.Size(768, 24);
            this.pnlListe.TabIndex = 30;
            // 
            // picTitle
            // 
            this.picTitle.Location = new System.Drawing.Point(5, 5);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(16, 16);
            this.picTitle.TabIndex = 293;
            this.picTitle.TabStop = false;
            // 
            // lblTitel
            // 
            this.lblTitel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(32, 5);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(726, 15);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Sollstellung ALBV, ALV und Forderung";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // lblSelektionSuche
            // 
            this.lblSelektionSuche.Location = new System.Drawing.Point(10, 182);
            this.lblSelektionSuche.Name = "lblSelektionSuche";
            this.lblSelektionSuche.Size = new System.Drawing.Size(111, 24);
            this.lblSelektionSuche.TabIndex = 137;
            this.lblSelektionSuche.Text = "Selektion Suche";
            this.lblSelektionSuche.UseCompatibleTextRendering = true;
            // 
            // edtSelektionSucheX
            // 
            this.edtSelektionSucheX.EditValue = "1";
            this.edtSelektionSucheX.Location = new System.Drawing.Point(8, 209);
            this.edtSelektionSucheX.LookupSQL = null;
            this.edtSelektionSucheX.LOVFilter = null;
            this.edtSelektionSucheX.LOVName = null;
            this.edtSelektionSucheX.Name = "edtSelektionSucheX";
            this.edtSelektionSucheX.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtSelektionSucheX.Properties.Appearance.Options.UseBackColor = true;
            this.edtSelektionSucheX.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.edtSelektionSucheX.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.edtSelektionSucheX.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "Forderung"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("2", "Zahlungseingang")});
            this.edtSelektionSucheX.Size = new System.Drawing.Size(222, 46);
            this.edtSelektionSucheX.TabIndex = 136;
            this.edtSelektionSucheX.EditValueChanged += new System.EventHandler(this.edtSelektionSucheX_EditValueChanged);
            // 
            // CtlKbBelegImportIK
            // 
            this.ActiveSQLQuery = this.qryListe;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(750, 500);
            this.Controls.Add(this.pnlListe);
            this.Name = "CtlKbBelegImportIK";
            this.Size = new System.Drawing.Size(768, 508);
            this.Load += new System.EventHandler(this.CtlKbBelegImportIK_Load);
            this.Controls.SetChildIndex(this.pnlListe, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungsText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungsDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValutaDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeneriertAm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdListe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryListe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvListe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungsDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValutaDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeneriertAm)).EndInit();
            this.pnlBuchung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBuchung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKbBuchung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBuchung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSelektionTypX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSelektionTypX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSelektionFallX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSelektionFallX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSelektionFaelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLetzteSollstellung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZuletztErstellteSollstellung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSelektionInkassotyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProgress2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSelektionMonatX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSelektionMonatX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSelektionMonat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSelektionStatusX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSelektionStatusX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSelektionStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollstellungsDatumX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMonat)).EndInit();
            this.pnlListe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSelektionSuche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSelektionSucheX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSelektionSucheX)).EndInit();
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

        private Gui.KissLabel lblSelektionSuche;
        private Gui.KissRadioGroup edtSelektionSucheX;
        private DevExpress.XtraGrid.Columns.GridColumn colListe_Bearbeitet;

    }
}