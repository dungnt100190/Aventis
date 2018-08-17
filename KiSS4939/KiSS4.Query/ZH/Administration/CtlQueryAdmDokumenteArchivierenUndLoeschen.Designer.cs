namespace KiSS4.Query.ZH
{
    public partial class CtlQueryAdmDokumenteArchivierenUndLoeschen
    {
        private DevExpress.XtraGrid.Columns.GridColumn colAHVNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colAbgeschlossen;
        private DevExpress.XtraGrid.Columns.GridColumn colBE;
        private DevExpress.XtraGrid.Columns.GridColumn colErffnet;
        private DevExpress.XtraGrid.Columns.GridColumn colFNr;
        private DevExpress.XtraGrid.Columns.GridColumn colFT;
        private DevExpress.XtraGrid.Columns.GridColumn colFTGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colFTPNr;
        private DevExpress.XtraGrid.Columns.GridColumn colFallNr;
        private DevExpress.XtraGrid.Columns.GridColumn colFalldauer;
        private DevExpress.XtraGrid.Columns.GridColumn colFallverantwortlich;
        private DevExpress.XtraGrid.Columns.GridColumn colGebDat;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGeschlecht;
        private DevExpress.XtraGrid.Columns.GridColumn colHH;
        private DevExpress.XtraGrid.Columns.GridColumn colHeimatort;
        private DevExpress.XtraGrid.Columns.GridColumn colHeimatortKanton;
        private DevExpress.XtraGrid.Columns.GridColumn colKanton;
        private DevExpress.XtraGrid.Columns.GridColumn colLENr;
        private DevExpress.XtraGrid.Columns.GridColumn colLEaktiv;
        private DevExpress.XtraGrid.Columns.GridColumn colLT;
        private DevExpress.XtraGrid.Columns.GridColumn colLeistung;
        private DevExpress.XtraGrid.Columns.GridColumn colLeistungNr;
        private DevExpress.XtraGrid.Columns.GridColumn colLeistungsdauer;
        private DevExpress.XtraGrid.Columns.GridColumn colLeistungseinheit;
        private DevExpress.XtraGrid.Columns.GridColumn colLst;
        private DevExpress.XtraGrid.Columns.GridColumn colMA;
        private DevExpress.XtraGrid.Columns.GridColumn colModul;
        private DevExpress.XtraGrid.Columns.GridColumn colMonat;
        private DevExpress.XtraGrid.Columns.GridColumn colNNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalitt;
        private DevExpress.XtraGrid.Columns.GridColumn colNr;
        private DevExpress.XtraGrid.Columns.GridColumn colOE;
        private DevExpress.XtraGrid.Columns.GridColumn colOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colPLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colPNr;
        private DevExpress.XtraGrid.Columns.GridColumn colPersHH;
        private DevExpress.XtraGrid.Columns.GridColumn colPersNr;
        private DevExpress.XtraGrid.Columns.GridColumn colRolle;
        private DevExpress.XtraGrid.Columns.GridColumn colSA;
        private DevExpress.XtraGrid.Columns.GridColumn colSAR;
        private DevExpress.XtraGrid.Columns.GridColumn colSB;
        private DevExpress.XtraGrid.Columns.GridColumn colSZ;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasse;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasseNr;
        private DevExpress.XtraGrid.Columns.GridColumn colTag;
        private DevExpress.XtraGrid.Columns.GridColumn colTeam;
        private DevExpress.XtraGrid.Columns.GridColumn colUE;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colZivilstand;
        private DevExpress.XtraGrid.Columns.GridColumn colZusatz;
        private KiSS4.Gui.KissTextEdit edtGetLogonName;
        private KiSS4.Gui.KissLabel lblSucheBemerkung;
        private KiSS4.Gui.KissLabel lblPerson;
        private KiSS4.Gui.KissLabel lblSucheVerwendung;
        private KiSS4.Gui.KissLabel lblSucheDokStatus;
        private KiSS4.Gui.KissLabel lblSucheVisumCode;
        private KiSS4.Gui.KissLabel lblSucheThemen;
        private KiSS4.Gui.KissLabel lblFaDokKorreSucheDatumBis;
        private KiSS4.Gui.KissLabel lblFaDokKorreSucheStichwort;
        private KiSS4.Gui.KissLabel lblFaDokKorreSucheAdressat;
        private KiSS4.Gui.KissLabel lblFaDokKorreSucheAbsender;
        private KiSS4.Gui.KissLabel lblFaDokKorreSucheDatumVon;
        private KiSS4.Gui.KissCheckEdit edtSucheNichtKlibuRelevant;
        private KiSS4.Gui.KissCheckEdit edtSucheKlibuRelevant;
        private KiSS4.Gui.KissLookUpEdit edtSucheFaDokVerwendungCode;
        private KiSS4.Gui.KissLookUpEdit edtSucheFaDokStatusCode;
        private KiSS4.Gui.KissLookUpEdit edtSucheFaDokVisumStatusCode;
        private KiSS4.Gui.KissTextEdit edtSucheBemerkung;
        private KiSS4.Gui.KissLookUpEdit edtSucheFaDokThemaCode;
        private KiSS4.Gui.KissTextEdit edtSucheStichwort;
        private KiSS4.Gui.KissTextEdit edtSucheAdressat;
        private KiSS4.Gui.KissTextEdit edtSucheAbsender;
        private KiSS4.Gui.KissDateEdit edtSucheDatumBis;
        private KiSS4.Gui.KissDateEdit edtSucheDatumVon;
        private KiSS4.Gui.KissTextEdit edtSucheFallNr;
        private KiSS4.Gui.KissLabel lblSucheFallNr;
        private KiSS4.Gui.KissTextEdit edtSuchenErfasser;
        private KiSS4.Gui.KissLabel lblSucheErfasser;
        private KiSS4.Gui.KissTextEdit edtSuchenErstellerOE;
        private KiSS4.Gui.KissLabel lblSucheErstellerOE;
        private KiSS4.Gui.KissButton btnDelete;
        private KiSS4.Gui.KissGrid grdFaDokumente;
        private DevExpress.XtraGrid.Views.Grid.GridView grvFaDokumente;
        private DevExpress.XtraGrid.Columns.GridColumn colFaDokumentID;
        private DevExpress.XtraGrid.Columns.GridColumn colFallNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colThema;
        private DevExpress.XtraGrid.Columns.GridColumn colStichwort;
        private DevExpress.XtraGrid.Columns.GridColumn colBaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colAbsenderIn;
        private DevExpress.XtraGrid.Columns.GridColumn colAdressatIn;
        private DevExpress.XtraGrid.Columns.GridColumn colErstellerIn_User;
        private DevExpress.XtraGrid.Columns.GridColumn colErstellerIn;
        private DevExpress.XtraGrid.Columns.GridColumn colErstelldatum;
        private DevExpress.XtraGrid.Columns.GridColumn colErstellerOE;
        private DevExpress.XtraGrid.Columns.GridColumn colArchiviert;
        private DevExpress.XtraGrid.Columns.GridColumn colSelected;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit gridedtSel;
        private KiSS4.Gui.KissButton btnKeine;
        private KiSS4.Gui.KissButton btnAlle;
        private KiSS4.Gui.KissButton btnArchivieren;
        private System.ComponentModel.IContainer components;
        private KiSS4.Dokument.KissDocumentButton kissDocumentButton1;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryAdmDokumenteArchivierenUndLoeschen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtGetLogonName = new KiSS4.Gui.KissTextEdit();
            this.colAbgeschlossen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAHVNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErffnet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFalldauer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFallNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFallverantwortlich = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFTGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFTPNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGebDat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeschlecht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHeimatort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHeimatortKanton = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKanton = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLEaktiv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLeistung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLeistungNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLeistungsdauer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLeistungseinheit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLENr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLst = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModul = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationalitt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersHH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRolle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasseNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTeam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZivilstand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZusatz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.kissDocumentButton1 = new KiSS4.Dokument.KissDocumentButton();
            this.lblSucheBemerkung = new KiSS4.Gui.KissLabel();
            this.lblPerson = new KiSS4.Gui.KissLabel();
            this.lblSucheVerwendung = new KiSS4.Gui.KissLabel();
            this.lblSucheDokStatus = new KiSS4.Gui.KissLabel();
            this.lblSucheVisumCode = new KiSS4.Gui.KissLabel();
            this.lblSucheThemen = new KiSS4.Gui.KissLabel();
            this.lblFaDokKorreSucheDatumBis = new KiSS4.Gui.KissLabel();
            this.lblFaDokKorreSucheStichwort = new KiSS4.Gui.KissLabel();
            this.lblFaDokKorreSucheAdressat = new KiSS4.Gui.KissLabel();
            this.lblFaDokKorreSucheAbsender = new KiSS4.Gui.KissLabel();
            this.lblFaDokKorreSucheDatumVon = new KiSS4.Gui.KissLabel();
            this.edtSucheNichtKlibuRelevant = new KiSS4.Gui.KissCheckEdit();
            this.edtSucheKlibuRelevant = new KiSS4.Gui.KissCheckEdit();
            this.edtSucheFaDokVerwendungCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtSucheFaDokStatusCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtSucheFaDokVisumStatusCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtSucheBemerkung = new KiSS4.Gui.KissTextEdit();
            this.edtSucheFaDokThemaCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtSucheStichwort = new KiSS4.Gui.KissTextEdit();
            this.edtSucheAdressat = new KiSS4.Gui.KissTextEdit();
            this.edtSucheAbsender = new KiSS4.Gui.KissTextEdit();
            this.edtSucheDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtSucheDatumVon = new KiSS4.Gui.KissDateEdit();
            this.lblSucheFallNr = new KiSS4.Gui.KissLabel();
            this.edtSucheFallNr = new KiSS4.Gui.KissTextEdit();
            this.edtSuchenErfasser = new KiSS4.Gui.KissTextEdit();
            this.lblSucheErfasser = new KiSS4.Gui.KissLabel();
            this.lblSucheErstellerOE = new KiSS4.Gui.KissLabel();
            this.edtSuchenErstellerOE = new KiSS4.Gui.KissTextEdit();
            this.btnDelete = new KiSS4.Gui.KissButton();
            this.grdFaDokumente = new KiSS4.Gui.KissGrid();
            this.grvFaDokumente = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSelected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridedtSel = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colFaDokumentID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFallNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStichwort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThema = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbsenderIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdressatIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErstellerIn_User = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErstellerIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErstelldatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErstellerOE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArchiviert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAlle = new KiSS4.Gui.KissButton();
            this.btnKeine = new KiSS4.Gui.KissButton();
            this.btnArchivieren = new KiSS4.Gui.KissButton();
            this.edtSuchePerson = new KiSS4.Gui.KissButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtGetLogonName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVerwendung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDokStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVisumCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheThemen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaDokKorreSucheDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaDokKorreSucheStichwort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaDokKorreSucheAdressat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaDokKorreSucheAbsender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaDokKorreSucheDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNichtKlibuRelevant.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKlibuRelevant.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFaDokVerwendungCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFaDokVerwendungCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFaDokStatusCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFaDokStatusCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFaDokVisumStatusCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFaDokVisumStatusCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFaDokThemaCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFaDokThemaCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStichwort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAdressat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAbsender.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheFallNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFallNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchenErfasser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheErfasser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheErstellerOE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchenErstellerOE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFaDokumente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFaDokumente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridedtSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchePerson.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.AutoApplyUserRights = false;
            this.qryQuery.BatchUpdate = true;
            this.qryQuery.CanUpdate = true;
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            this.qryQuery.PositionChanged += new System.EventHandler(this.qryQuery_PositionChanged);
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
            this.grvQuery1.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvQuery1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupFooter.Options.UseBorderColor = true;
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
            // 
            // xDocument
            // 
            this.xDocument.DataMember = "DocumentID";
            this.xDocument.EditValue = null;
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = "BaPersonID$";
            this.ctlGotoFall.Location = new System.Drawing.Point(0, 397);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.btnArchivieren);
            this.tpgListe.Controls.Add(this.btnKeine);
            this.tpgListe.Controls.Add(this.btnAlle);
            this.tpgListe.Controls.Add(this.grdFaDokumente);
            this.tpgListe.Controls.Add(this.btnDelete);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Controls.SetChildIndex(this.grdQuery1, 0);
            this.tpgListe.Controls.SetChildIndex(this.lblSuchkriterienInfo, 0);
            this.tpgListe.Controls.SetChildIndex(this.ctlGotoFall, 0);
            this.tpgListe.Controls.SetChildIndex(this.xDocument, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnDelete, 0);
            this.tpgListe.Controls.SetChildIndex(this.grdFaDokumente, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnAlle, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnKeine, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnArchivieren, 0);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtSuchePerson);
            this.tpgSuchen.Controls.Add(this.edtSuchenErstellerOE);
            this.tpgSuchen.Controls.Add(this.lblSucheErstellerOE);
            this.tpgSuchen.Controls.Add(this.lblSucheErfasser);
            this.tpgSuchen.Controls.Add(this.edtSuchenErfasser);
            this.tpgSuchen.Controls.Add(this.edtSucheFallNr);
            this.tpgSuchen.Controls.Add(this.lblSucheFallNr);
            this.tpgSuchen.Controls.Add(this.lblSucheBemerkung);
            this.tpgSuchen.Controls.Add(this.lblPerson);
            this.tpgSuchen.Controls.Add(this.lblSucheVerwendung);
            this.tpgSuchen.Controls.Add(this.lblSucheDokStatus);
            this.tpgSuchen.Controls.Add(this.lblSucheVisumCode);
            this.tpgSuchen.Controls.Add(this.lblSucheThemen);
            this.tpgSuchen.Controls.Add(this.lblFaDokKorreSucheDatumBis);
            this.tpgSuchen.Controls.Add(this.lblFaDokKorreSucheStichwort);
            this.tpgSuchen.Controls.Add(this.lblFaDokKorreSucheAdressat);
            this.tpgSuchen.Controls.Add(this.lblFaDokKorreSucheAbsender);
            this.tpgSuchen.Controls.Add(this.lblFaDokKorreSucheDatumVon);
            this.tpgSuchen.Controls.Add(this.edtSucheNichtKlibuRelevant);
            this.tpgSuchen.Controls.Add(this.edtSucheKlibuRelevant);
            this.tpgSuchen.Controls.Add(this.edtSucheFaDokVerwendungCode);
            this.tpgSuchen.Controls.Add(this.edtSucheFaDokStatusCode);
            this.tpgSuchen.Controls.Add(this.edtSucheFaDokVisumStatusCode);
            this.tpgSuchen.Controls.Add(this.edtSucheBemerkung);
            this.tpgSuchen.Controls.Add(this.edtSucheFaDokThemaCode);
            this.tpgSuchen.Controls.Add(this.edtSucheStichwort);
            this.tpgSuchen.Controls.Add(this.edtSucheAdressat);
            this.tpgSuchen.Controls.Add(this.edtSucheAbsender);
            this.tpgSuchen.Controls.Add(this.edtSucheDatumBis);
            this.tpgSuchen.Controls.Add(this.edtSucheDatumVon);
            this.tpgSuchen.Controls.Add(this.edtGetLogonName);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtGetLogonName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheAbsender, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheAdressat, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheStichwort, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheFaDokThemaCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBemerkung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheFaDokVisumStatusCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheFaDokStatusCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheFaDokVerwendungCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheKlibuRelevant, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheNichtKlibuRelevant, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblFaDokKorreSucheDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblFaDokKorreSucheAbsender, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblFaDokKorreSucheAdressat, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblFaDokKorreSucheStichwort, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblFaDokKorreSucheDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheThemen, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheVisumCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheDokStatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheVerwendung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblPerson, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBemerkung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheFallNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheFallNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSuchenErfasser, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheErfasser, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheErstellerOE, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSuchenErstellerOE, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSuchePerson, 0);
            // 
            // edtGetLogonName
            // 
            this.edtGetLogonName.Location = new System.Drawing.Point(150, 32605);
            this.edtGetLogonName.Name = "edtGetLogonName";
            this.edtGetLogonName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGetLogonName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGetLogonName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGetLogonName.Properties.Appearance.Options.UseBackColor = true;
            this.edtGetLogonName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGetLogonName.Properties.Appearance.Options.UseFont = true;
            this.edtGetLogonName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGetLogonName.Size = new System.Drawing.Size(0, 24);
            this.edtGetLogonName.TabIndex = 200;
            // 
            // colAbgeschlossen
            // 
            this.colAbgeschlossen.Name = "colAbgeschlossen";
            // 
            // colAHVNummer
            // 
            this.colAHVNummer.Name = "colAHVNummer";
            // 
            // colBE
            // 
            this.colBE.Name = "colBE";
            // 
            // colErffnet
            // 
            this.colErffnet.Name = "colErffnet";
            // 
            // colFalldauer
            // 
            this.colFalldauer.Name = "colFalldauer";
            // 
            // colFallNr
            // 
            this.colFallNr.Name = "colFallNr";
            // 
            // colFallverantwortlich
            // 
            this.colFallverantwortlich.Name = "colFallverantwortlich";
            // 
            // colFNr
            // 
            this.colFNr.Name = "colFNr";
            // 
            // colFT
            // 
            this.colFT.Name = "colFT";
            // 
            // colFTGeburtsdatum
            // 
            this.colFTGeburtsdatum.Name = "colFTGeburtsdatum";
            // 
            // colFTPNr
            // 
            this.colFTPNr.Name = "colFTPNr";
            // 
            // colGebDat
            // 
            this.colGebDat.Name = "colGebDat";
            // 
            // colGeburtsdatum
            // 
            this.colGeburtsdatum.Name = "colGeburtsdatum";
            // 
            // colGeschlecht
            // 
            this.colGeschlecht.Name = "colGeschlecht";
            // 
            // colHeimatort
            // 
            this.colHeimatort.Name = "colHeimatort";
            // 
            // colHeimatortKanton
            // 
            this.colHeimatortKanton.Name = "colHeimatortKanton";
            // 
            // colHH
            // 
            this.colHH.Name = "colHH";
            // 
            // colKanton
            // 
            this.colKanton.Name = "colKanton";
            // 
            // colLEaktiv
            // 
            this.colLEaktiv.Name = "colLEaktiv";
            // 
            // colLeistung
            // 
            this.colLeistung.Name = "colLeistung";
            // 
            // colLeistungNr
            // 
            this.colLeistungNr.Name = "colLeistungNr";
            // 
            // colLeistungsdauer
            // 
            this.colLeistungsdauer.Name = "colLeistungsdauer";
            // 
            // colLeistungseinheit
            // 
            this.colLeistungseinheit.Name = "colLeistungseinheit";
            // 
            // colLENr
            // 
            this.colLENr.Name = "colLENr";
            // 
            // colLst
            // 
            this.colLst.Name = "colLst";
            // 
            // colLT
            // 
            this.colLT.Name = "colLT";
            // 
            // colMA
            // 
            this.colMA.Name = "colMA";
            // 
            // colModul
            // 
            this.colModul.Name = "colModul";
            // 
            // colMonat
            // 
            this.colMonat.Name = "colMonat";
            // 
            // colName
            // 
            this.colName.Name = "colName";
            // 
            // colNationalitt
            // 
            this.colNationalitt.Name = "colNationalitt";
            // 
            // colNNummer
            // 
            this.colNNummer.Name = "colNNummer";
            // 
            // colNr
            // 
            this.colNr.Name = "colNr";
            // 
            // colOE
            // 
            this.colOE.Name = "colOE";
            // 
            // colOrt
            // 
            this.colOrt.Name = "colOrt";
            // 
            // colPersHH
            // 
            this.colPersHH.Name = "colPersHH";
            // 
            // colPersNr
            // 
            this.colPersNr.Name = "colPersNr";
            // 
            // colPLZ
            // 
            this.colPLZ.Name = "colPLZ";
            // 
            // colPNr
            // 
            this.colPNr.Name = "colPNr";
            // 
            // colRolle
            // 
            this.colRolle.Name = "colRolle";
            // 
            // colSA
            // 
            this.colSA.Name = "colSA";
            // 
            // colSAR
            // 
            this.colSAR.Name = "colSAR";
            // 
            // colSB
            // 
            this.colSB.Name = "colSB";
            // 
            // colStrasse
            // 
            this.colStrasse.Name = "colStrasse";
            // 
            // colStrasseNr
            // 
            this.colStrasseNr.Name = "colStrasseNr";
            // 
            // colSZ
            // 
            this.colSZ.Name = "colSZ";
            // 
            // colTag
            // 
            this.colTag.Name = "colTag";
            // 
            // colTeam
            // 
            this.colTeam.Name = "colTeam";
            // 
            // colUE
            // 
            this.colUE.Name = "colUE";
            // 
            // colVorname
            // 
            this.colVorname.Name = "colVorname";
            // 
            // colZivilstand
            // 
            this.colZivilstand.Name = "colZivilstand";
            // 
            // colZusatz
            // 
            this.colZusatz.Name = "colZusatz";
            // 
            // kissDocumentButton1
            // 
            this.kissDocumentButton1.Context = null;
            this.kissDocumentButton1.DocumentFormat = KiSS4.Dokument.DlgNewDocument.DocumentAccessModes.All;
            this.kissDocumentButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kissDocumentButton1.Image = ((System.Drawing.Image)(resources.GetObject("kissDocumentButton1.Image")));
            this.kissDocumentButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.kissDocumentButton1.Location = new System.Drawing.Point(0, 0);
            this.kissDocumentButton1.Name = "kissDocumentButton1";
            this.kissDocumentButton1.Size = new System.Drawing.Size(90, 24);
            this.kissDocumentButton1.TabIndex = 0;
            this.kissDocumentButton1.Text = "kissDocumentButton1";
            this.kissDocumentButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.kissDocumentButton1.UseCompatibleTextRendering = true;
            this.kissDocumentButton1.UseVisualStyleBackColor = true;
            // 
            // lblSucheBemerkung
            // 
            this.lblSucheBemerkung.Location = new System.Drawing.Point(7, 199);
            this.lblSucheBemerkung.Name = "lblSucheBemerkung";
            this.lblSucheBemerkung.Size = new System.Drawing.Size(73, 24);
            this.lblSucheBemerkung.TabIndex = 224;
            this.lblSucheBemerkung.Text = "Bemerkung";
            this.lblSucheBemerkung.UseCompatibleTextRendering = true;
            // 
            // lblPerson
            // 
            this.lblPerson.Location = new System.Drawing.Point(427, 168);
            this.lblPerson.Name = "lblPerson";
            this.lblPerson.Size = new System.Drawing.Size(92, 24);
            this.lblPerson.TabIndex = 223;
            this.lblPerson.Text = "Person";
            this.lblPerson.UseCompatibleTextRendering = true;
            // 
            // lblSucheVerwendung
            // 
            this.lblSucheVerwendung.Location = new System.Drawing.Point(427, 109);
            this.lblSucheVerwendung.Name = "lblSucheVerwendung";
            this.lblSucheVerwendung.Size = new System.Drawing.Size(94, 24);
            this.lblSucheVerwendung.TabIndex = 222;
            this.lblSucheVerwendung.Text = "Ein/Aus/Intern";
            this.lblSucheVerwendung.UseCompatibleTextRendering = true;
            // 
            // lblSucheDokStatus
            // 
            this.lblSucheDokStatus.Location = new System.Drawing.Point(427, 79);
            this.lblSucheDokStatus.Name = "lblSucheDokStatus";
            this.lblSucheDokStatus.Size = new System.Drawing.Size(93, 24);
            this.lblSucheDokStatus.TabIndex = 221;
            this.lblSucheDokStatus.Text = "Dokumente Status";
            this.lblSucheDokStatus.UseCompatibleTextRendering = true;
            // 
            // lblSucheVisumCode
            // 
            this.lblSucheVisumCode.Location = new System.Drawing.Point(427, 49);
            this.lblSucheVisumCode.Name = "lblSucheVisumCode";
            this.lblSucheVisumCode.Size = new System.Drawing.Size(92, 24);
            this.lblSucheVisumCode.TabIndex = 220;
            this.lblSucheVisumCode.Text = "Visum Status";
            this.lblSucheVisumCode.UseCompatibleTextRendering = true;
            // 
            // lblSucheThemen
            // 
            this.lblSucheThemen.Location = new System.Drawing.Point(7, 169);
            this.lblSucheThemen.Name = "lblSucheThemen";
            this.lblSucheThemen.Size = new System.Drawing.Size(73, 24);
            this.lblSucheThemen.TabIndex = 219;
            this.lblSucheThemen.Text = "Thema";
            this.lblSucheThemen.UseCompatibleTextRendering = true;
            // 
            // lblFaDokKorreSucheDatumBis
            // 
            this.lblFaDokKorreSucheDatumBis.Location = new System.Drawing.Point(269, 49);
            this.lblFaDokKorreSucheDatumBis.Name = "lblFaDokKorreSucheDatumBis";
            this.lblFaDokKorreSucheDatumBis.Size = new System.Drawing.Size(23, 24);
            this.lblFaDokKorreSucheDatumBis.TabIndex = 218;
            this.lblFaDokKorreSucheDatumBis.Text = "bis";
            this.lblFaDokKorreSucheDatumBis.UseCompatibleTextRendering = true;
            // 
            // lblFaDokKorreSucheStichwort
            // 
            this.lblFaDokKorreSucheStichwort.Location = new System.Drawing.Point(7, 139);
            this.lblFaDokKorreSucheStichwort.Name = "lblFaDokKorreSucheStichwort";
            this.lblFaDokKorreSucheStichwort.Size = new System.Drawing.Size(72, 24);
            this.lblFaDokKorreSucheStichwort.TabIndex = 217;
            this.lblFaDokKorreSucheStichwort.Text = "Stichwort(e)";
            this.lblFaDokKorreSucheStichwort.UseCompatibleTextRendering = true;
            // 
            // lblFaDokKorreSucheAdressat
            // 
            this.lblFaDokKorreSucheAdressat.Location = new System.Drawing.Point(7, 109);
            this.lblFaDokKorreSucheAdressat.Name = "lblFaDokKorreSucheAdressat";
            this.lblFaDokKorreSucheAdressat.Size = new System.Drawing.Size(72, 24);
            this.lblFaDokKorreSucheAdressat.TabIndex = 216;
            this.lblFaDokKorreSucheAdressat.Text = "Adressat/in";
            this.lblFaDokKorreSucheAdressat.UseCompatibleTextRendering = true;
            // 
            // lblFaDokKorreSucheAbsender
            // 
            this.lblFaDokKorreSucheAbsender.Location = new System.Drawing.Point(7, 79);
            this.lblFaDokKorreSucheAbsender.Name = "lblFaDokKorreSucheAbsender";
            this.lblFaDokKorreSucheAbsender.Size = new System.Drawing.Size(72, 24);
            this.lblFaDokKorreSucheAbsender.TabIndex = 215;
            this.lblFaDokKorreSucheAbsender.Text = "Absender/in";
            this.lblFaDokKorreSucheAbsender.UseCompatibleTextRendering = true;
            // 
            // lblFaDokKorreSucheDatumVon
            // 
            this.lblFaDokKorreSucheDatumVon.Location = new System.Drawing.Point(7, 49);
            this.lblFaDokKorreSucheDatumVon.Name = "lblFaDokKorreSucheDatumVon";
            this.lblFaDokKorreSucheDatumVon.Size = new System.Drawing.Size(72, 24);
            this.lblFaDokKorreSucheDatumVon.TabIndex = 214;
            this.lblFaDokKorreSucheDatumVon.Text = "Datum von";
            this.lblFaDokKorreSucheDatumVon.UseCompatibleTextRendering = true;
            // 
            // edtSucheNichtKlibuRelevant
            // 
            this.edtSucheNichtKlibuRelevant.EditValue = true;
            this.edtSucheNichtKlibuRelevant.Location = new System.Drawing.Point(522, 220);
            this.edtSucheNichtKlibuRelevant.Name = "edtSucheNichtKlibuRelevant";
            this.edtSucheNichtKlibuRelevant.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSucheNichtKlibuRelevant.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheNichtKlibuRelevant.Properties.Caption = "nicht Klibu relevant";
            this.edtSucheNichtKlibuRelevant.Size = new System.Drawing.Size(183, 19);
            this.edtSucheNichtKlibuRelevant.TabIndex = 13;
            // 
            // edtSucheKlibuRelevant
            // 
            this.edtSucheKlibuRelevant.EditValue = true;
            this.edtSucheKlibuRelevant.Location = new System.Drawing.Point(522, 202);
            this.edtSucheKlibuRelevant.Name = "edtSucheKlibuRelevant";
            this.edtSucheKlibuRelevant.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSucheKlibuRelevant.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheKlibuRelevant.Properties.Caption = "Klibu relevant";
            this.edtSucheKlibuRelevant.Size = new System.Drawing.Size(172, 19);
            this.edtSucheKlibuRelevant.TabIndex = 12;
            // 
            // edtSucheFaDokVerwendungCode
            // 
            this.edtSucheFaDokVerwendungCode.Location = new System.Drawing.Point(522, 109);
            this.edtSucheFaDokVerwendungCode.LOVName = "FaDokVerwendung";
            this.edtSucheFaDokVerwendungCode.Name = "edtSucheFaDokVerwendungCode";
            this.edtSucheFaDokVerwendungCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheFaDokVerwendungCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheFaDokVerwendungCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheFaDokVerwendungCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheFaDokVerwendungCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheFaDokVerwendungCode.Properties.Appearance.Options.UseFont = true;
            this.edtSucheFaDokVerwendungCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheFaDokVerwendungCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheFaDokVerwendungCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheFaDokVerwendungCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheFaDokVerwendungCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtSucheFaDokVerwendungCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtSucheFaDokVerwendungCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheFaDokVerwendungCode.Properties.NullText = "";
            this.edtSucheFaDokVerwendungCode.Properties.ShowFooter = false;
            this.edtSucheFaDokVerwendungCode.Properties.ShowHeader = false;
            this.edtSucheFaDokVerwendungCode.Size = new System.Drawing.Size(172, 24);
            this.edtSucheFaDokVerwendungCode.TabIndex = 6;
            // 
            // edtSucheFaDokStatusCode
            // 
            this.edtSucheFaDokStatusCode.Location = new System.Drawing.Point(522, 79);
            this.edtSucheFaDokStatusCode.LOVName = "FaDokStatus";
            this.edtSucheFaDokStatusCode.Name = "edtSucheFaDokStatusCode";
            this.edtSucheFaDokStatusCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheFaDokStatusCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheFaDokStatusCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheFaDokStatusCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheFaDokStatusCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheFaDokStatusCode.Properties.Appearance.Options.UseFont = true;
            this.edtSucheFaDokStatusCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheFaDokStatusCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheFaDokStatusCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheFaDokStatusCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheFaDokStatusCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtSucheFaDokStatusCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtSucheFaDokStatusCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheFaDokStatusCode.Properties.NullText = "";
            this.edtSucheFaDokStatusCode.Properties.ShowFooter = false;
            this.edtSucheFaDokStatusCode.Properties.ShowHeader = false;
            this.edtSucheFaDokStatusCode.Size = new System.Drawing.Size(172, 24);
            this.edtSucheFaDokStatusCode.TabIndex = 4;
            // 
            // edtSucheFaDokVisumStatusCode
            // 
            this.edtSucheFaDokVisumStatusCode.Location = new System.Drawing.Point(522, 49);
            this.edtSucheFaDokVisumStatusCode.LOVName = "FaDokVisumStatus";
            this.edtSucheFaDokVisumStatusCode.Name = "edtSucheFaDokVisumStatusCode";
            this.edtSucheFaDokVisumStatusCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheFaDokVisumStatusCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheFaDokVisumStatusCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheFaDokVisumStatusCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheFaDokVisumStatusCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheFaDokVisumStatusCode.Properties.Appearance.Options.UseFont = true;
            this.edtSucheFaDokVisumStatusCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheFaDokVisumStatusCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheFaDokVisumStatusCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheFaDokVisumStatusCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheFaDokVisumStatusCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtSucheFaDokVisumStatusCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtSucheFaDokVisumStatusCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheFaDokVisumStatusCode.Properties.NullText = "";
            this.edtSucheFaDokVisumStatusCode.Properties.ShowFooter = false;
            this.edtSucheFaDokVisumStatusCode.Properties.ShowHeader = false;
            this.edtSucheFaDokVisumStatusCode.Size = new System.Drawing.Size(172, 24);
            this.edtSucheFaDokVisumStatusCode.TabIndex = 2;
            // 
            // edtSucheBemerkung
            // 
            this.edtSucheBemerkung.Location = new System.Drawing.Point(86, 199);
            this.edtSucheBemerkung.Name = "edtSucheBemerkung";
            this.edtSucheBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheBemerkung.Size = new System.Drawing.Size(316, 24);
            this.edtSucheBemerkung.TabIndex = 11;
            // 
            // edtSucheFaDokThemaCode
            // 
            this.edtSucheFaDokThemaCode.Location = new System.Drawing.Point(86, 169);
            this.edtSucheFaDokThemaCode.LOVFilter = "F";
            this.edtSucheFaDokThemaCode.LOVName = "FaDokThema";
            this.edtSucheFaDokThemaCode.Name = "edtSucheFaDokThemaCode";
            this.edtSucheFaDokThemaCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheFaDokThemaCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheFaDokThemaCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheFaDokThemaCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheFaDokThemaCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheFaDokThemaCode.Properties.Appearance.Options.UseFont = true;
            this.edtSucheFaDokThemaCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheFaDokThemaCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheFaDokThemaCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheFaDokThemaCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheFaDokThemaCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtSucheFaDokThemaCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtSucheFaDokThemaCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheFaDokThemaCode.Properties.NullText = "";
            this.edtSucheFaDokThemaCode.Properties.ShowFooter = false;
            this.edtSucheFaDokThemaCode.Properties.ShowHeader = false;
            this.edtSucheFaDokThemaCode.Size = new System.Drawing.Size(316, 24);
            this.edtSucheFaDokThemaCode.TabIndex = 9;
            // 
            // edtSucheStichwort
            // 
            this.edtSucheStichwort.Location = new System.Drawing.Point(86, 139);
            this.edtSucheStichwort.Name = "edtSucheStichwort";
            this.edtSucheStichwort.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheStichwort.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheStichwort.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheStichwort.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheStichwort.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheStichwort.Properties.Appearance.Options.UseFont = true;
            this.edtSucheStichwort.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheStichwort.Size = new System.Drawing.Size(316, 24);
            this.edtSucheStichwort.TabIndex = 7;
            // 
            // edtSucheAdressat
            // 
            this.edtSucheAdressat.Location = new System.Drawing.Point(86, 109);
            this.edtSucheAdressat.Name = "edtSucheAdressat";
            this.edtSucheAdressat.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheAdressat.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheAdressat.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheAdressat.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheAdressat.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheAdressat.Properties.Appearance.Options.UseFont = true;
            this.edtSucheAdressat.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheAdressat.Size = new System.Drawing.Size(316, 24);
            this.edtSucheAdressat.TabIndex = 5;
            // 
            // edtSucheAbsender
            // 
            this.edtSucheAbsender.Location = new System.Drawing.Point(86, 79);
            this.edtSucheAbsender.Name = "edtSucheAbsender";
            this.edtSucheAbsender.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheAbsender.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheAbsender.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheAbsender.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheAbsender.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheAbsender.Properties.Appearance.Options.UseFont = true;
            this.edtSucheAbsender.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheAbsender.Size = new System.Drawing.Size(316, 24);
            this.edtSucheAbsender.TabIndex = 3;
            // 
            // edtSucheDatumBis
            // 
            this.edtSucheDatumBis.EditValue = null;
            this.edtSucheDatumBis.Location = new System.Drawing.Point(298, 49);
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
            this.edtSucheDatumBis.Size = new System.Drawing.Size(104, 24);
            this.edtSucheDatumBis.TabIndex = 1;
            // 
            // edtSucheDatumVon
            // 
            this.edtSucheDatumVon.EditValue = null;
            this.edtSucheDatumVon.Location = new System.Drawing.Point(86, 49);
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
            this.edtSucheDatumVon.Size = new System.Drawing.Size(116, 24);
            this.edtSucheDatumVon.TabIndex = 0;
            // 
            // lblSucheFallNr
            // 
            this.lblSucheFallNr.Location = new System.Drawing.Point(427, 139);
            this.lblSucheFallNr.Name = "lblSucheFallNr";
            this.lblSucheFallNr.Size = new System.Drawing.Size(94, 24);
            this.lblSucheFallNr.TabIndex = 226;
            this.lblSucheFallNr.Text = "Fall-Nr";
            this.lblSucheFallNr.UseCompatibleTextRendering = true;
            // 
            // edtSucheFallNr
            // 
            this.edtSucheFallNr.Location = new System.Drawing.Point(522, 139);
            this.edtSucheFallNr.Name = "edtSucheFallNr";
            this.edtSucheFallNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheFallNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheFallNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheFallNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheFallNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheFallNr.Properties.Appearance.Options.UseFont = true;
            this.edtSucheFallNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheFallNr.Size = new System.Drawing.Size(172, 24);
            this.edtSucheFallNr.TabIndex = 8;
            // 
            // edtSuchenErfasser
            // 
            this.edtSuchenErfasser.Location = new System.Drawing.Point(86, 229);
            this.edtSuchenErfasser.Name = "edtSuchenErfasser";
            this.edtSuchenErfasser.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSuchenErfasser.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSuchenErfasser.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSuchenErfasser.Properties.Appearance.Options.UseBackColor = true;
            this.edtSuchenErfasser.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSuchenErfasser.Properties.Appearance.Options.UseFont = true;
            this.edtSuchenErfasser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSuchenErfasser.Size = new System.Drawing.Size(316, 24);
            this.edtSuchenErfasser.TabIndex = 14;
            // 
            // lblSucheErfasser
            // 
            this.lblSucheErfasser.Location = new System.Drawing.Point(8, 229);
            this.lblSucheErfasser.Name = "lblSucheErfasser";
            this.lblSucheErfasser.Size = new System.Drawing.Size(73, 24);
            this.lblSucheErfasser.TabIndex = 229;
            this.lblSucheErfasser.Text = "Erfasser";
            this.lblSucheErfasser.UseCompatibleTextRendering = true;
            // 
            // lblSucheErstellerOE
            // 
            this.lblSucheErstellerOE.Location = new System.Drawing.Point(8, 257);
            this.lblSucheErstellerOE.Name = "lblSucheErstellerOE";
            this.lblSucheErstellerOE.Size = new System.Drawing.Size(73, 24);
            this.lblSucheErstellerOE.TabIndex = 230;
            this.lblSucheErstellerOE.Text = "Ersteller OE";
            this.lblSucheErstellerOE.UseCompatibleTextRendering = true;
            // 
            // edtSuchenErstellerOE
            // 
            this.edtSuchenErstellerOE.Location = new System.Drawing.Point(86, 259);
            this.edtSuchenErstellerOE.Name = "edtSuchenErstellerOE";
            this.edtSuchenErstellerOE.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSuchenErstellerOE.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSuchenErstellerOE.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSuchenErstellerOE.Properties.Appearance.Options.UseBackColor = true;
            this.edtSuchenErstellerOE.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSuchenErstellerOE.Properties.Appearance.Options.UseFont = true;
            this.edtSuchenErstellerOE.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSuchenErstellerOE.Size = new System.Drawing.Size(316, 24);
            this.edtSuchenErstellerOE.TabIndex = 15;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(629, 397);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 24);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Löschen";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // grdFaDokumente
            // 
            this.grdFaDokumente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdFaDokumente.ColumnFilterActivated = true;
            this.grdFaDokumente.DataSource = this.qryQuery;
            // 
            // 
            // 
            this.grdFaDokumente.EmbeddedNavigator.Name = "";
            this.grdFaDokumente.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdFaDokumente.Location = new System.Drawing.Point(1, 0);
            this.grdFaDokumente.MainView = this.grvFaDokumente;
            this.grdFaDokumente.Name = "grdFaDokumente";
            this.grdFaDokumente.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gridedtSel});
            this.grdFaDokumente.Size = new System.Drawing.Size(768, 391);
            this.grdFaDokumente.TabIndex = 132;
            this.grdFaDokumente.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvFaDokumente});
            // 
            // grvFaDokumente
            // 
            this.grvFaDokumente.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvFaDokumente.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaDokumente.Appearance.Empty.Options.UseBackColor = true;
            this.grvFaDokumente.Appearance.Empty.Options.UseFont = true;
            this.grvFaDokumente.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvFaDokumente.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaDokumente.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvFaDokumente.Appearance.EvenRow.Options.UseFont = true;
            this.grvFaDokumente.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFaDokumente.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaDokumente.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvFaDokumente.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvFaDokumente.Appearance.FocusedCell.Options.UseFont = true;
            this.grvFaDokumente.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvFaDokumente.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFaDokumente.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaDokumente.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvFaDokumente.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvFaDokumente.Appearance.FocusedRow.Options.UseFont = true;
            this.grvFaDokumente.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvFaDokumente.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFaDokumente.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvFaDokumente.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFaDokumente.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaDokumente.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFaDokumente.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvFaDokumente.Appearance.GroupRow.Options.UseFont = true;
            this.grvFaDokumente.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvFaDokumente.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvFaDokumente.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvFaDokumente.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaDokumente.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvFaDokumente.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvFaDokumente.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvFaDokumente.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvFaDokumente.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grvFaDokumente.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvFaDokumente.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaDokumente.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFaDokumente.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvFaDokumente.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvFaDokumente.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvFaDokumente.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvFaDokumente.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvFaDokumente.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvFaDokumente.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaDokumente.Appearance.OddRow.Options.UseBackColor = true;
            this.grvFaDokumente.Appearance.OddRow.Options.UseFont = true;
            this.grvFaDokumente.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvFaDokumente.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaDokumente.Appearance.Row.Options.UseBackColor = true;
            this.grvFaDokumente.Appearance.Row.Options.UseFont = true;
            this.grvFaDokumente.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvFaDokumente.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaDokumente.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvFaDokumente.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvFaDokumente.Appearance.SelectedRow.Options.UseFont = true;
            this.grvFaDokumente.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvFaDokumente.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvFaDokumente.Appearance.VertLine.Options.UseBackColor = true;
            this.grvFaDokumente.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvFaDokumente.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSelected,
            this.colFaDokumentID,
            this.colFallNummer,
            this.colStichwort,
            this.colThema,
            this.colBaPersonID,
            this.colPerson,
            this.colAbsenderIn,
            this.colAdressatIn,
            this.colErstellerIn_User,
            this.colErstellerIn,
            this.colErstelldatum,
            this.colErstellerOE,
            this.colArchiviert});
            this.grvFaDokumente.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvFaDokumente.GridControl = this.grdFaDokumente;
            this.grvFaDokumente.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvFaDokumente.Name = "grvFaDokumente";
            this.grvFaDokumente.OptionsFilter.AllowFilterEditor = false;
            this.grvFaDokumente.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvFaDokumente.OptionsNavigation.AutoFocusNewRow = true;
            this.grvFaDokumente.OptionsNavigation.UseTabKey = false;
            this.grvFaDokumente.OptionsPrint.AutoWidth = false;
            this.grvFaDokumente.OptionsPrint.ExpandAllDetails = true;
            this.grvFaDokumente.OptionsPrint.UsePrintStyles = true;
            this.grvFaDokumente.OptionsView.ColumnAutoWidth = false;
            this.grvFaDokumente.OptionsView.RowAutoHeight = true;
            this.grvFaDokumente.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvFaDokumente.OptionsView.ShowGroupPanel = false;
            this.grvFaDokumente.OptionsView.ShowIndicator = false;
            // 
            // colSelected
            // 
            this.colSelected.Caption = "Sel.";
            this.colSelected.ColumnEdit = this.gridedtSel;
            this.colSelected.FieldName = "Selected";
            this.colSelected.Name = "colSelected";
            this.colSelected.Visible = true;
            this.colSelected.VisibleIndex = 0;
            this.colSelected.Width = 32;
            // 
            // gridedtSel
            // 
            this.gridedtSel.AutoHeight = false;
            this.gridedtSel.Name = "gridedtSel";
            this.gridedtSel.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.gridedtSel.CheckedChanged += new System.EventHandler(this.gridedtSel_CheckedChanged);
            // 
            // colFaDokumentID
            // 
            this.colFaDokumentID.Caption = "FaDokumentID";
            this.colFaDokumentID.FieldName = "FaDokumentID$";
            this.colFaDokumentID.Name = "colFaDokumentID";
            this.colFaDokumentID.OptionsColumn.AllowEdit = false;
            this.colFaDokumentID.OptionsColumn.ReadOnly = true;
            this.colFaDokumentID.Width = 90;
            // 
            // colFallNummer
            // 
            this.colFallNummer.Caption = "FallNummer";
            this.colFallNummer.FieldName = "FallNummer";
            this.colFallNummer.Name = "colFallNummer";
            this.colFallNummer.OptionsColumn.AllowEdit = false;
            this.colFallNummer.OptionsColumn.ReadOnly = true;
            this.colFallNummer.Visible = true;
            this.colFallNummer.VisibleIndex = 1;
            this.colFallNummer.Width = 90;
            // 
            // colStichwort
            // 
            this.colStichwort.Caption = "Stichwort";
            this.colStichwort.FieldName = "Stichwort";
            this.colStichwort.Name = "colStichwort";
            this.colStichwort.OptionsColumn.AllowEdit = false;
            this.colStichwort.OptionsColumn.ReadOnly = true;
            this.colStichwort.Visible = true;
            this.colStichwort.VisibleIndex = 2;
            this.colStichwort.Width = 150;
            // 
            // colThema
            // 
            this.colThema.Caption = "Thema";
            this.colThema.FieldName = "Thema";
            this.colThema.Name = "colThema";
            this.colThema.OptionsColumn.AllowEdit = false;
            this.colThema.OptionsColumn.ReadOnly = true;
            this.colThema.Visible = true;
            this.colThema.VisibleIndex = 3;
            this.colThema.Width = 150;
            // 
            // colBaPersonID
            // 
            this.colBaPersonID.Caption = "BaPersonID";
            this.colBaPersonID.FieldName = "BaPersonID$";
            this.colBaPersonID.Name = "colBaPersonID";
            this.colBaPersonID.OptionsColumn.AllowEdit = false;
            this.colBaPersonID.OptionsColumn.ReadOnly = true;
            // 
            // colPerson
            // 
            this.colPerson.Caption = "BetrifftPerson";
            this.colPerson.FieldName = "BetriffPerson";
            this.colPerson.Name = "colPerson";
            this.colPerson.OptionsColumn.AllowEdit = false;
            this.colPerson.OptionsColumn.ReadOnly = true;
            this.colPerson.Visible = true;
            this.colPerson.VisibleIndex = 4;
            this.colPerson.Width = 90;
            // 
            // colAbsenderIn
            // 
            this.colAbsenderIn.Caption = "AbsenderIn";
            this.colAbsenderIn.FieldName = "AbsenderIn";
            this.colAbsenderIn.Name = "colAbsenderIn";
            this.colAbsenderIn.OptionsColumn.AllowEdit = false;
            this.colAbsenderIn.OptionsColumn.ReadOnly = true;
            this.colAbsenderIn.Visible = true;
            this.colAbsenderIn.VisibleIndex = 5;
            this.colAbsenderIn.Width = 90;
            // 
            // colAdressatIn
            // 
            this.colAdressatIn.Caption = "AdressatIn";
            this.colAdressatIn.FieldName = "AdressatIn";
            this.colAdressatIn.Name = "colAdressatIn";
            this.colAdressatIn.OptionsColumn.AllowEdit = false;
            this.colAdressatIn.OptionsColumn.ReadOnly = true;
            this.colAdressatIn.Visible = true;
            this.colAdressatIn.VisibleIndex = 6;
            this.colAdressatIn.Width = 90;
            // 
            // colErstellerIn_User
            // 
            this.colErstellerIn_User.Caption = "ErstellerIn_User";
            this.colErstellerIn_User.FieldName = "ErstellerIn_User";
            this.colErstellerIn_User.Name = "colErstellerIn_User";
            this.colErstellerIn_User.OptionsColumn.AllowEdit = false;
            this.colErstellerIn_User.OptionsColumn.ReadOnly = true;
            this.colErstellerIn_User.Visible = true;
            this.colErstellerIn_User.VisibleIndex = 7;
            // 
            // colErstellerIn
            // 
            this.colErstellerIn.Caption = "ErstellerIn";
            this.colErstellerIn.FieldName = "ErstellerIn";
            this.colErstellerIn.Name = "colErstellerIn";
            this.colErstellerIn.OptionsColumn.AllowEdit = false;
            this.colErstellerIn.OptionsColumn.ReadOnly = true;
            this.colErstellerIn.Visible = true;
            this.colErstellerIn.VisibleIndex = 8;
            this.colErstellerIn.Width = 90;
            // 
            // colErstelldatum
            // 
            this.colErstelldatum.Caption = "Erstelldatum";
            this.colErstelldatum.FieldName = "Erstelldatum";
            this.colErstelldatum.Name = "colErstelldatum";
            this.colErstelldatum.OptionsColumn.AllowEdit = false;
            this.colErstelldatum.OptionsColumn.ReadOnly = true;
            this.colErstelldatum.Visible = true;
            this.colErstelldatum.VisibleIndex = 9;
            // 
            // colErstellerOE
            // 
            this.colErstellerOE.Caption = "ErstellerOE";
            this.colErstellerOE.FieldName = "ErstellerOE";
            this.colErstellerOE.Name = "colErstellerOE";
            this.colErstellerOE.OptionsColumn.AllowEdit = false;
            this.colErstellerOE.OptionsColumn.ReadOnly = true;
            this.colErstellerOE.Visible = true;
            this.colErstellerOE.VisibleIndex = 10;
            this.colErstellerOE.Width = 90;
            // 
            // colArchiviert
            // 
            this.colArchiviert.Caption = "Archiviert";
            this.colArchiviert.FieldName = "Archiviert";
            this.colArchiviert.Name = "colArchiviert";
            this.colArchiviert.OptionsColumn.AllowEdit = false;
            this.colArchiviert.OptionsColumn.ReadOnly = true;
            this.colArchiviert.Visible = true;
            this.colArchiviert.VisibleIndex = 11;
            // 
            // btnAlle
            // 
            this.btnAlle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAlle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlle.Location = new System.Drawing.Point(348, 397);
            this.btnAlle.Name = "btnAlle";
            this.btnAlle.Size = new System.Drawing.Size(90, 24);
            this.btnAlle.TabIndex = 133;
            this.btnAlle.Text = "Alle";
            this.btnAlle.UseVisualStyleBackColor = false;
            this.btnAlle.Click += new System.EventHandler(this.btnAlle_Click);
            // 
            // btnKeine
            // 
            this.btnKeine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnKeine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeine.Location = new System.Drawing.Point(442, 397);
            this.btnKeine.Name = "btnKeine";
            this.btnKeine.Size = new System.Drawing.Size(90, 24);
            this.btnKeine.TabIndex = 134;
            this.btnKeine.Text = "Keine";
            this.btnKeine.UseVisualStyleBackColor = false;
            this.btnKeine.Click += new System.EventHandler(this.btnKeine_Click);
            // 
            // btnArchivieren
            // 
            this.btnArchivieren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnArchivieren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArchivieren.Location = new System.Drawing.Point(536, 397);
            this.btnArchivieren.Name = "btnArchivieren";
            this.btnArchivieren.Size = new System.Drawing.Size(90, 24);
            this.btnArchivieren.TabIndex = 135;
            this.btnArchivieren.Text = "Archivieren";
            this.btnArchivieren.UseVisualStyleBackColor = false;
            this.btnArchivieren.Visible = false;
            this.btnArchivieren.Click += new System.EventHandler(this.btnArchivieren_Click);
            // 
            // edtSuchePerson
            // 
            this.edtSuchePerson.Location = new System.Drawing.Point(522, 168);
            this.edtSuchePerson.Name = "edtSuchePerson";
            this.edtSuchePerson.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSuchePerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSuchePerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSuchePerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtSuchePerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSuchePerson.Properties.Appearance.Options.UseFont = true;
            this.edtSuchePerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSuchePerson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSuchePerson.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSuchePerson.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSuchePerson.Size = new System.Drawing.Size(172, 24);
            this.edtSuchePerson.TabIndex = 10;
            this.edtSuchePerson.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSuchePerson_UserModifiedFld);
            // 
            // CtlQueryAdmDokumenteArchivierenUndLoeschen
            // 
            this.Name = "CtlQueryAdmDokumenteArchivierenUndLoeschen";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtGetLogonName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVerwendung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDokStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVisumCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheThemen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaDokKorreSucheDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaDokKorreSucheStichwort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaDokKorreSucheAdressat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaDokKorreSucheAbsender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaDokKorreSucheDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNichtKlibuRelevant.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKlibuRelevant.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFaDokVerwendungCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFaDokVerwendungCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFaDokStatusCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFaDokStatusCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFaDokVisumStatusCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFaDokVisumStatusCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFaDokThemaCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFaDokThemaCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStichwort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAdressat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAbsender.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheFallNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFallNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchenErfasser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheErfasser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheErstellerOE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchenErstellerOE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFaDokumente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFaDokumente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridedtSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchePerson.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion Windows Form Designer generated code

        private Gui.KissButtonEdit edtSuchePerson;
    }
}