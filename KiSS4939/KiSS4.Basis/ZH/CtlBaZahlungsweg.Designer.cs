namespace KiSS4.Basis.ZH
{
    public partial class CtlBaZahlungsweg
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colBankPost;
        private DevExpress.XtraGrid.Columns.GridColumn colEZ;
        private DevExpress.XtraGrid.Columns.GridColumn colGueltigAb;
        private DevExpress.XtraGrid.Columns.GridColumn colGueltigBis;
        private DevExpress.XtraGrid.Columns.GridColumn colKontoNr;
        private DevExpress.XtraGrid.Columns.GridColumn colPCKonto;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissLookUpEdit edtBaKontoart;
        private KiSS4.Gui.KissCheckedLookupEdit edtBaZahlwegModulStdCodes;
        private KiSS4.Gui.KissTextEdit edtBankPC;
        private KiSS4.Gui.KissButtonEdit edtBankPost;
        private KiSS4.Gui.KissTextEdit edtBankkontoNr;
        private KiSS4.Gui.KissTextEdit edtClearingNummer;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissLookUpEdit edtEinzahlungsschein;
        private KiSS4.Gui.KissTextEdit edtHausNr;
        private KiSS4.Gui.KissTextEdit edtIBAN;
        private KiSS4.Gui.KissMemoEdit edtIBANErrorMsg;
        private KiSS4.Gui.KissTextEdit edtName;
        private KiSS4.Gui.KissTextEdit edtOrt;
        private KiSS4.Gui.KissTextEdit edtPLZ;
        private KiSS4.Gui.KissTextEdit edtPostkontoNr;
        private KiSS4.Gui.KissTextEdit edtReferenz;
        private KiSS4.Gui.KissTextEdit edtStrasse;
        private KiSS4.Gui.KissCheckEdit edtWMAVerwenden;
        private KiSS4.Gui.KissTextEdit edtZusatz;
        private KiSS4.Gui.KissGrid grdBaZahlungsweg;
        private DevExpress.XtraGrid.Views.Grid.GridView grvZahlungsweg;
        private KiSS4.Gui.KissLabel lblZahlungsempfaenger;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissLabel kissLabel24;
        private KiSS4.Gui.KissLabel kissLabel26;
        private KiSS4.Gui.KissLabel kissLabel29;
        private KiSS4.Gui.KissLabel kissLabel3;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissTextEdit kissTextEdit1;
        private KiSS4.Gui.KissTextEdit kissTextEdit2;
        private KiSS4.Gui.KissTextEdit kissTextEdit3;
        private KiSS4.Gui.KissTextEdit kissTextEdit4;
        private KiSS4.Gui.KissTextEdit kissTextEdit5;
        private KiSS4.Gui.KissTextEdit kissTextEdit6;
        private KiSS4.Gui.KissTextEdit kissTextEdit7;
        private KiSS4.Gui.KissLabel lblBCN;
        private KiSS4.Gui.KissLabel lblBaKontoart;
        private KiSS4.Gui.KissLabel lblBankPost;
        private KiSS4.Gui.KissLabel lblBankkontoNr;
        private KiSS4.Gui.KissLabel lblDatumVon;
        private KiSS4.Gui.KissLabel lblEinzahlungsschein;
        private KiSS4.Gui.KissLabel lblGueltigBis;
        private KiSS4.Gui.KissLabel lblIBAN;
        private KiSS4.Gui.KissLabel lblName;
        private KiSS4.Gui.KissLabel lblPostKonto;
        private KiSS4.Gui.KissLabel lblRefNr;
        private System.Windows.Forms.Panel pnPersonOnly;
        private System.Windows.Forms.Panel pnlAdresse;
        private KiSS4.DB.SqlQuery qryBaPerson;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private KiSS4.Gui.KissTabControlEx tabZusatz;
        private SharpLibrary.WinControls.TabPageEx tpgStandard;
        private SharpLibrary.WinControls.TabPageEx tpgZahlungsempfaenger;
        private KiSS4.Gui.KissLabel lblVerwendungszweck;
        private KiSS4.Gui.KissTextEdit edtVerwendungszweck;
        private DevExpress.XtraGrid.Columns.GridColumn colKontoart;
        private DevExpress.XtraGrid.Columns.GridColumn colVerwendungszweck;

        public KiSS4.DB.SqlQuery qryBaZahlungsweg;

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBaZahlungsweg));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.qryBaZahlungsweg = new KiSS4.DB.SqlQuery(this.components);
            this.grdBaZahlungsweg = new KiSS4.Gui.KissGrid();
            this.grvZahlungsweg = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGueltigAb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGueltigBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBankPost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKontoart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerwendungszweck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKontoNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPCKonto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtEinzahlungsschein = new KiSS4.Gui.KissLookUpEdit();
            this.edtBankPost = new KiSS4.Gui.KissButtonEdit();
            this.edtBankkontoNr = new KiSS4.Gui.KissTextEdit();
            this.edtClearingNummer = new KiSS4.Gui.KissTextEdit();
            this.edtIBAN = new KiSS4.Gui.KissTextEdit();
            this.edtBankPC = new KiSS4.Gui.KissTextEdit();
            this.edtPostkontoNr = new KiSS4.Gui.KissTextEdit();
            this.edtReferenz = new KiSS4.Gui.KissTextEdit();
            this.edtBaKontoart = new KiSS4.Gui.KissLookUpEdit();
            this.lblEinzahlungsschein = new KiSS4.Gui.KissLabel();
            this.lblBankPost = new KiSS4.Gui.KissLabel();
            this.lblBankkontoNr = new KiSS4.Gui.KissLabel();
            this.lblPostKonto = new KiSS4.Gui.KissLabel();
            this.lblIBAN = new KiSS4.Gui.KissLabel();
            this.lblBCN = new KiSS4.Gui.KissLabel();
            this.lblRefNr = new KiSS4.Gui.KissLabel();
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            this.lblGueltigBis = new KiSS4.Gui.KissLabel();
            this.tabZusatz = new KiSS4.Gui.KissTabControlEx();
            this.tpgZahlungsempfaenger = new SharpLibrary.WinControls.TabPageEx();
            this.pnPersonOnly = new System.Windows.Forms.Panel();
            this.pnlAdresse = new System.Windows.Forms.Panel();
            this.kissTextEdit3 = new KiSS4.Gui.KissTextEdit();
            this.qryBaPerson = new KiSS4.DB.SqlQuery(this.components);
            this.kissTextEdit4 = new KiSS4.Gui.KissTextEdit();
            this.kissTextEdit5 = new KiSS4.Gui.KissTextEdit();
            this.kissTextEdit2 = new KiSS4.Gui.KissTextEdit();
            this.kissTextEdit6 = new KiSS4.Gui.KissTextEdit();
            this.kissTextEdit7 = new KiSS4.Gui.KissTextEdit();
            this.edtWMAVerwenden = new KiSS4.Gui.KissCheckEdit();
            this.lblZahlungsempfaenger = new KiSS4.Gui.KissLabel();
            this.kissLabel26 = new KiSS4.Gui.KissLabel();
            this.kissLabel29 = new KiSS4.Gui.KissLabel();
            this.kissLabel24 = new KiSS4.Gui.KissLabel();
            this.lblName = new KiSS4.Gui.KissLabel();
            this.edtOrt = new KiSS4.Gui.KissTextEdit();
            this.edtPLZ = new KiSS4.Gui.KissTextEdit();
            this.edtHausNr = new KiSS4.Gui.KissTextEdit();
            this.edtStrasse = new KiSS4.Gui.KissTextEdit();
            this.edtZusatz = new KiSS4.Gui.KissTextEdit();
            this.edtName = new KiSS4.Gui.KissTextEdit();
            this.tpgStandard = new SharpLibrary.WinControls.TabPageEx();
            this.kissTextEdit1 = new KiSS4.Gui.KissTextEdit();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.edtBaZahlwegModulStdCodes = new KiSS4.Gui.KissCheckedLookupEdit();
            this.edtIBANErrorMsg = new KiSS4.Gui.KissMemoEdit();
            this.tpgDokumente = new SharpLibrary.WinControls.TabPageEx();
            this.edtDocument = new KiSS4.Dokument.XDokument();
            this.qryBaZahlungswegDokumente = new KiSS4.DB.SqlQuery(this.components);
            this.lblStichwort = new KiSS4.Gui.KissLabel();
            this.edtStichwort = new KiSS4.Gui.KissTextEdit();
            this.lblDokumentTyp = new KiSS4.Gui.KissLabel();
            this.edtDokumentTyp = new KiSS4.Gui.KissLookUpEdit();
            this.grdDoc = new KiSS4.Gui.KissGrid();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDocTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStichwort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateCreation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateLastSave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblBaKontoart = new KiSS4.Gui.KissLabel();
            this.lblVerwendungszweck = new KiSS4.Gui.KissLabel();
            this.edtVerwendungszweck = new KiSS4.Gui.KissTextEdit();
            this.tabPageEx1 = new SharpLibrary.WinControls.TabPageEx();
            this.ctlErfassungMutation = new KiSS4.Common.CtlErfassungMutation();
            this.lblStatus = new KiSS4.Gui.KissLabel();
            this.edtBaFreigabeStatus = new KiSS4.Gui.KissLookUpEdit();
            this.btnDefinitiv = new KiSS4.Gui.KissButton();
            this.lblDefinitiv = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaZahlungsweg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaZahlungsweg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZahlungsweg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinzahlungsschein)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinzahlungsschein.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBankPost.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBankkontoNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtClearingNummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIBAN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBankPC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPostkontoNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtReferenz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaKontoart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaKontoart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinzahlungsschein)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBankPost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBankkontoNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPostKonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIBAN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBCN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRefNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGueltigBis)).BeginInit();
            this.tabZusatz.SuspendLayout();
            this.tpgZahlungsempfaenger.SuspendLayout();
            this.pnPersonOnly.SuspendLayout();
            this.pnlAdresse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit6.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit7.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWMAVerwenden.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungsempfaenger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPLZ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHausNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).BeginInit();
            this.tpgStandard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaZahlwegModulStdCodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIBANErrorMsg.Properties)).BeginInit();
            this.tpgDokumente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtDocument.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaZahlungswegDokumente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichwort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichwort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokumentTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentTyp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaKontoart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwendungszweck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwendungszweck.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaFreigabeStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaFreigabeStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDefinitiv)).BeginInit();
            this.SuspendLayout();
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDatumVon.DataMember = "DatumVon";
            this.edtDatumVon.DataSource = this.qryBaZahlungsweg;
            this.edtDatumVon.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(116, 276);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 0;
            // 
            // qryBaZahlungsweg
            // 
            this.qryBaZahlungsweg.CanDelete = true;
            this.qryBaZahlungsweg.CanInsert = true;
            this.qryBaZahlungsweg.CanUpdate = true;
            this.qryBaZahlungsweg.HostControl = this;
            this.qryBaZahlungsweg.IsIdentityInsert = false;
            this.qryBaZahlungsweg.TableName = "BaZahlungsweg";
            this.qryBaZahlungsweg.AfterDelete += new System.EventHandler(this.qryBaZahlungsweg_AfterDelete);
            this.qryBaZahlungsweg.AfterFill += new System.EventHandler(this.qryBaZahlungsweg_AfterFill);
            this.qryBaZahlungsweg.AfterInsert += new System.EventHandler(this.qryBaZahlungsweg_AfterInsert);
            this.qryBaZahlungsweg.BeforeDelete += new System.EventHandler(this.qryBaZahlungsweg_BeforeDelete);
            this.qryBaZahlungsweg.BeforePost += new System.EventHandler(this.qryBaZahlungsweg_BeforePost);
            this.qryBaZahlungsweg.PositionChanged += new System.EventHandler(this.qryBaZahlungsweg_PositionChanged);
            // 
            // grdBaZahlungsweg
            // 
            this.grdBaZahlungsweg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBaZahlungsweg.DataSource = this.qryBaZahlungsweg;
            // 
            // 
            // 
            this.grdBaZahlungsweg.EmbeddedNavigator.Name = "kissGrid6.EmbeddedNavigator";
            this.grdBaZahlungsweg.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBaZahlungsweg.Location = new System.Drawing.Point(7, 3);
            this.grdBaZahlungsweg.MainView = this.grvZahlungsweg;
            this.grdBaZahlungsweg.Name = "grdBaZahlungsweg";
            this.grdBaZahlungsweg.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1});
            this.grdBaZahlungsweg.Size = new System.Drawing.Size(938, 267);
            this.grdBaZahlungsweg.TabIndex = 0;
            this.grdBaZahlungsweg.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvZahlungsweg});
            // 
            // grvZahlungsweg
            // 
            this.grvZahlungsweg.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvZahlungsweg.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungsweg.Appearance.Empty.Options.UseBackColor = true;
            this.grvZahlungsweg.Appearance.Empty.Options.UseFont = true;
            this.grvZahlungsweg.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungsweg.Appearance.EvenRow.Options.UseFont = true;
            this.grvZahlungsweg.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvZahlungsweg.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungsweg.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvZahlungsweg.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvZahlungsweg.Appearance.FocusedCell.Options.UseFont = true;
            this.grvZahlungsweg.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvZahlungsweg.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvZahlungsweg.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungsweg.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvZahlungsweg.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvZahlungsweg.Appearance.FocusedRow.Options.UseFont = true;
            this.grvZahlungsweg.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvZahlungsweg.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZahlungsweg.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvZahlungsweg.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvZahlungsweg.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvZahlungsweg.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZahlungsweg.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvZahlungsweg.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZahlungsweg.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvZahlungsweg.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZahlungsweg.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvZahlungsweg.Appearance.GroupRow.Options.UseFont = true;
            this.grvZahlungsweg.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvZahlungsweg.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvZahlungsweg.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvZahlungsweg.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvZahlungsweg.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvZahlungsweg.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvZahlungsweg.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvZahlungsweg.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvZahlungsweg.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungsweg.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZahlungsweg.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvZahlungsweg.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvZahlungsweg.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvZahlungsweg.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvZahlungsweg.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvZahlungsweg.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungsweg.Appearance.OddRow.Options.UseFont = true;
            this.grvZahlungsweg.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvZahlungsweg.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungsweg.Appearance.Row.Options.UseBackColor = true;
            this.grvZahlungsweg.Appearance.Row.Options.UseFont = true;
            this.grvZahlungsweg.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungsweg.Appearance.SelectedRow.Options.UseFont = true;
            this.grvZahlungsweg.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvZahlungsweg.Appearance.VertLine.Options.UseBackColor = true;
            this.grvZahlungsweg.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvZahlungsweg.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGueltigAb,
            this.colGueltigBis,
            this.colEZ,
            this.colBankPost,
            this.colKontoart,
            this.colVerwendungszweck,
            this.colKontoNr,
            this.colPCKonto});
            this.grvZahlungsweg.CustomizationFormBounds = new System.Drawing.Rectangle(816, 459, 208, 175);
            this.grvZahlungsweg.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvZahlungsweg.GridControl = this.grdBaZahlungsweg;
            this.grvZahlungsweg.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvZahlungsweg.Name = "grvZahlungsweg";
            this.grvZahlungsweg.OptionsBehavior.Editable = false;
            this.grvZahlungsweg.OptionsCustomization.AllowFilter = false;
            this.grvZahlungsweg.OptionsFilter.AllowFilterEditor = false;
            this.grvZahlungsweg.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvZahlungsweg.OptionsMenu.EnableColumnMenu = false;
            this.grvZahlungsweg.OptionsNavigation.AutoFocusNewRow = true;
            this.grvZahlungsweg.OptionsNavigation.UseTabKey = false;
            this.grvZahlungsweg.OptionsView.ColumnAutoWidth = false;
            this.grvZahlungsweg.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvZahlungsweg.OptionsView.ShowGroupPanel = false;
            this.grvZahlungsweg.OptionsView.ShowIndicator = false;
            // 
            // colGueltigAb
            // 
            this.colGueltigAb.Caption = "Von";
            this.colGueltigAb.FieldName = "DatumVon";
            this.colGueltigAb.Name = "colGueltigAb";
            this.colGueltigAb.Visible = true;
            this.colGueltigAb.VisibleIndex = 0;
            // 
            // colGueltigBis
            // 
            this.colGueltigBis.Caption = "bis";
            this.colGueltigBis.FieldName = "DatumBis";
            this.colGueltigBis.Name = "colGueltigBis";
            this.colGueltigBis.Visible = true;
            this.colGueltigBis.VisibleIndex = 1;
            // 
            // colEZ
            // 
            this.colEZ.Caption = "EZ";
            this.colEZ.FieldName = "EinzahlungsscheinCode";
            this.colEZ.Name = "colEZ";
            this.colEZ.Visible = true;
            this.colEZ.VisibleIndex = 2;
            this.colEZ.Width = 115;
            // 
            // colBankPost
            // 
            this.colBankPost.Caption = "Bank / Post";
            this.colBankPost.FieldName = "Bankname";
            this.colBankPost.Name = "colBankPost";
            this.colBankPost.Visible = true;
            this.colBankPost.VisibleIndex = 3;
            this.colBankPost.Width = 145;
            // 
            // colKontoart
            // 
            this.colKontoart.Caption = "Kontoart";
            this.colKontoart.FieldName = "BaKontoartCode";
            this.colKontoart.Name = "colKontoart";
            this.colKontoart.Visible = true;
            this.colKontoart.VisibleIndex = 4;
            this.colKontoart.Width = 97;
            // 
            // colVerwendungszweck
            // 
            this.colVerwendungszweck.Caption = "Verwendungszweck";
            this.colVerwendungszweck.FieldName = "Verwendungszweck";
            this.colVerwendungszweck.Name = "colVerwendungszweck";
            this.colVerwendungszweck.Visible = true;
            this.colVerwendungszweck.VisibleIndex = 5;
            this.colVerwendungszweck.Width = 200;
            // 
            // colKontoNr
            // 
            this.colKontoNr.Caption = "Bank Konto-Nr.";
            this.colKontoNr.FieldName = "BankKontoNummer";
            this.colKontoNr.Name = "colKontoNr";
            this.colKontoNr.Visible = true;
            this.colKontoNr.VisibleIndex = 6;
            this.colKontoNr.Width = 111;
            // 
            // colPCKonto
            // 
            this.colPCKonto.Caption = "Postkonto-Nr.";
            this.colPCKonto.FieldName = "PcNr";
            this.colPCKonto.Name = "colPCKonto";
            this.colPCKonto.Visible = true;
            this.colPCKonto.VisibleIndex = 7;
            this.colPCKonto.Width = 95;
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
            // edtDatumBis
            // 
            this.edtDatumBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDatumBis.DataMember = "DatumBis";
            this.edtDatumBis.DataSource = this.qryBaZahlungsweg;
            this.edtDatumBis.EditMode = Kiss.Interfaces.UI.EditModeType.Optional;
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(255, 276);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(109, 24);
            this.edtDatumBis.TabIndex = 1;
            // 
            // edtEinzahlungsschein
            // 
            this.edtEinzahlungsschein.AllowNull = false;
            this.edtEinzahlungsschein.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtEinzahlungsschein.DataMember = "EinzahlungsscheinCode";
            this.edtEinzahlungsschein.DataSource = this.qryBaZahlungsweg;
            this.edtEinzahlungsschein.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtEinzahlungsschein.Location = new System.Drawing.Point(116, 306);
            this.edtEinzahlungsschein.LOVName = "BgEinzahlungsschein";
            this.edtEinzahlungsschein.Name = "edtEinzahlungsschein";
            this.edtEinzahlungsschein.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtEinzahlungsschein.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinzahlungsschein.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinzahlungsschein.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinzahlungsschein.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinzahlungsschein.Properties.Appearance.Options.UseFont = true;
            this.edtEinzahlungsschein.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtEinzahlungsschein.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinzahlungsschein.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtEinzahlungsschein.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtEinzahlungsschein.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtEinzahlungsschein.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtEinzahlungsschein.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEinzahlungsschein.Properties.Name = "kissLookUpEdit6.Properties";
            this.edtEinzahlungsschein.Properties.NullText = "";
            this.edtEinzahlungsschein.Properties.ShowFooter = false;
            this.edtEinzahlungsschein.Properties.ShowHeader = false;
            this.edtEinzahlungsschein.Size = new System.Drawing.Size(271, 24);
            this.edtEinzahlungsschein.TabIndex = 2;
            this.edtEinzahlungsschein.EnterKey += new System.Windows.Forms.KeyEventHandler(this.edtEinzahlungsschein_EnterKey);
            this.edtEinzahlungsschein.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.edtEinzahlungsschein_CloseUp);
            this.edtEinzahlungsschein.EditValueChanged += new System.EventHandler(this.edtEinzahlungsschein_EditValueChanged);
            // 
            // edtBankPost
            // 
            this.edtBankPost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBankPost.DataMember = "Bankname";
            this.edtBankPost.DataSource = this.qryBaZahlungsweg;
            this.edtBankPost.Location = new System.Drawing.Point(116, 336);
            this.edtBankPost.Name = "edtBankPost";
            this.edtBankPost.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBankPost.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBankPost.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBankPost.Properties.Appearance.Options.UseBackColor = true;
            this.edtBankPost.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBankPost.Properties.Appearance.Options.UseFont = true;
            this.edtBankPost.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtBankPost.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtBankPost.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBankPost.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtBankPost.Size = new System.Drawing.Size(271, 24);
            this.edtBankPost.TabIndex = 3;
            this.edtBankPost.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtBankPost_UserModifiedFld);
            // 
            // edtBankkontoNr
            // 
            this.edtBankkontoNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBankkontoNr.DataMember = "BankKontoNummer";
            this.edtBankkontoNr.DataSource = this.qryBaZahlungsweg;
            this.edtBankkontoNr.Location = new System.Drawing.Point(116, 426);
            this.edtBankkontoNr.Name = "edtBankkontoNr";
            this.edtBankkontoNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBankkontoNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBankkontoNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBankkontoNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtBankkontoNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBankkontoNr.Properties.Appearance.Options.UseFont = true;
            this.edtBankkontoNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBankkontoNr.Properties.MaxLength = 50;
            this.edtBankkontoNr.Properties.Name = "kissTextEdit13.Properties";
            this.edtBankkontoNr.Size = new System.Drawing.Size(187, 24);
            this.edtBankkontoNr.TabIndex = 6;
            // 
            // edtClearingNummer
            // 
            this.edtClearingNummer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtClearingNummer.DataMember = "ClearingNr";
            this.edtClearingNummer.DataSource = this.qryBaZahlungsweg;
            this.edtClearingNummer.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtClearingNummer.Location = new System.Drawing.Point(334, 426);
            this.edtClearingNummer.Name = "edtClearingNummer";
            this.edtClearingNummer.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtClearingNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtClearingNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtClearingNummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtClearingNummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtClearingNummer.Properties.Appearance.Options.UseFont = true;
            this.edtClearingNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtClearingNummer.Properties.ReadOnly = true;
            this.edtClearingNummer.Size = new System.Drawing.Size(52, 24);
            this.edtClearingNummer.TabIndex = 7;
            this.edtClearingNummer.TabStop = false;
            // 
            // edtIBAN
            // 
            this.edtIBAN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtIBAN.DataMember = "IBANNummer";
            this.edtIBAN.DataSource = this.qryBaZahlungsweg;
            this.edtIBAN.Location = new System.Drawing.Point(116, 456);
            this.edtIBAN.Name = "edtIBAN";
            this.edtIBAN.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIBAN.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIBAN.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIBAN.Properties.Appearance.Options.UseBackColor = true;
            this.edtIBAN.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIBAN.Properties.Appearance.Options.UseFont = true;
            this.edtIBAN.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtIBAN.Properties.MaxLength = 50;
            this.edtIBAN.Properties.Name = "kissTextEdit16.Properties";
            this.edtIBAN.Size = new System.Drawing.Size(271, 24);
            this.edtIBAN.TabIndex = 8;
            // 
            // edtBankPC
            // 
            this.edtBankPC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBankPC.DataMember = "BankPC";
            this.edtBankPC.DataSource = this.qryBaZahlungsweg;
            this.edtBankPC.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBankPC.Location = new System.Drawing.Point(116, 486);
            this.edtBankPC.Name = "edtBankPC";
            this.edtBankPC.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBankPC.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBankPC.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBankPC.Properties.Appearance.Options.UseBackColor = true;
            this.edtBankPC.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBankPC.Properties.Appearance.Options.UseFont = true;
            this.edtBankPC.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBankPC.Properties.ReadOnly = true;
            this.edtBankPC.Size = new System.Drawing.Size(187, 24);
            this.edtBankPC.TabIndex = 9;
            this.edtBankPC.TabStop = false;
            this.edtBankPC.Visible = false;
            // 
            // edtPostkontoNr
            // 
            this.edtPostkontoNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtPostkontoNr.DataMember = "PcNr";
            this.edtPostkontoNr.DataSource = this.qryBaZahlungsweg;
            this.edtPostkontoNr.Location = new System.Drawing.Point(187, 486);
            this.edtPostkontoNr.Name = "edtPostkontoNr";
            this.edtPostkontoNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPostkontoNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPostkontoNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPostkontoNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtPostkontoNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPostkontoNr.Properties.Appearance.Options.UseFont = true;
            this.edtPostkontoNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPostkontoNr.Properties.MaxLength = 20;
            this.edtPostkontoNr.Properties.Name = "kissTextEdit14.Properties";
            this.edtPostkontoNr.Size = new System.Drawing.Size(102, 24);
            this.edtPostkontoNr.TabIndex = 10;
            // 
            // edtReferenz
            // 
            this.edtReferenz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtReferenz.DataMember = "ESRTeilnehmer";
            this.edtReferenz.DataSource = this.qryBaZahlungsweg;
            this.edtReferenz.Location = new System.Drawing.Point(116, 516);
            this.edtReferenz.Name = "edtReferenz";
            this.edtReferenz.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtReferenz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtReferenz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtReferenz.Properties.Appearance.Options.UseBackColor = true;
            this.edtReferenz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtReferenz.Properties.Appearance.Options.UseFont = true;
            this.edtReferenz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtReferenz.Properties.MaxLength = 100;
            this.edtReferenz.Size = new System.Drawing.Size(271, 24);
            this.edtReferenz.TabIndex = 11;
            // 
            // edtBaKontoart
            // 
            this.edtBaKontoart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBaKontoart.DataMember = "BaKontoartCode";
            this.edtBaKontoart.DataSource = this.qryBaZahlungsweg;
            this.edtBaKontoart.Location = new System.Drawing.Point(115, 366);
            this.edtBaKontoart.LOVName = "BaKontoart";
            this.edtBaKontoart.Name = "edtBaKontoart";
            this.edtBaKontoart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaKontoart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaKontoart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaKontoart.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaKontoart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaKontoart.Properties.Appearance.Options.UseFont = true;
            this.edtBaKontoart.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBaKontoart.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaKontoart.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBaKontoart.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBaKontoart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtBaKontoart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtBaKontoart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaKontoart.Properties.Name = "kissLookUpEdit6.Properties";
            this.edtBaKontoart.Properties.NullText = "";
            this.edtBaKontoart.Properties.ShowFooter = false;
            this.edtBaKontoart.Properties.ShowHeader = false;
            this.edtBaKontoart.Size = new System.Drawing.Size(271, 24);
            this.edtBaKontoart.TabIndex = 4;
            // 
            // lblEinzahlungsschein
            // 
            this.lblEinzahlungsschein.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEinzahlungsschein.Location = new System.Drawing.Point(7, 306);
            this.lblEinzahlungsschein.Name = "lblEinzahlungsschein";
            this.lblEinzahlungsschein.Size = new System.Drawing.Size(70, 24);
            this.lblEinzahlungsschein.TabIndex = 22;
            this.lblEinzahlungsschein.Text = "Zahlwegtyp";
            this.lblEinzahlungsschein.UseCompatibleTextRendering = true;
            // 
            // lblBankPost
            // 
            this.lblBankPost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBankPost.Location = new System.Drawing.Point(7, 336);
            this.lblBankPost.Name = "lblBankPost";
            this.lblBankPost.Size = new System.Drawing.Size(70, 24);
            this.lblBankPost.TabIndex = 23;
            this.lblBankPost.Text = "Bank/Post";
            this.lblBankPost.UseCompatibleTextRendering = true;
            // 
            // lblBankkontoNr
            // 
            this.lblBankkontoNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBankkontoNr.Location = new System.Drawing.Point(7, 426);
            this.lblBankkontoNr.Name = "lblBankkontoNr";
            this.lblBankkontoNr.Size = new System.Drawing.Size(72, 24);
            this.lblBankkontoNr.TabIndex = 26;
            this.lblBankkontoNr.Text = "Bankkonto-Nr.";
            this.lblBankkontoNr.UseCompatibleTextRendering = true;
            // 
            // lblPostKonto
            // 
            this.lblPostKonto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPostKonto.Location = new System.Drawing.Point(7, 486);
            this.lblPostKonto.Name = "lblPostKonto";
            this.lblPostKonto.Size = new System.Drawing.Size(70, 24);
            this.lblPostKonto.TabIndex = 28;
            this.lblPostKonto.Text = "Postkonto-Nr.";
            this.lblPostKonto.UseCompatibleTextRendering = true;
            // 
            // lblIBAN
            // 
            this.lblIBAN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblIBAN.Location = new System.Drawing.Point(7, 456);
            this.lblIBAN.Name = "lblIBAN";
            this.lblIBAN.Size = new System.Drawing.Size(70, 24);
            this.lblIBAN.TabIndex = 29;
            this.lblIBAN.Text = "IBAN";
            this.lblIBAN.UseCompatibleTextRendering = true;
            // 
            // lblBCN
            // 
            this.lblBCN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBCN.Location = new System.Drawing.Point(309, 426);
            this.lblBCN.Name = "lblBCN";
            this.lblBCN.Size = new System.Drawing.Size(23, 24);
            this.lblBCN.TabIndex = 32;
            this.lblBCN.Text = "BC";
            this.lblBCN.UseCompatibleTextRendering = true;
            // 
            // lblRefNr
            // 
            this.lblRefNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRefNr.Location = new System.Drawing.Point(7, 516);
            this.lblRefNr.Name = "lblRefNr";
            this.lblRefNr.Size = new System.Drawing.Size(70, 24);
            this.lblRefNr.TabIndex = 33;
            this.lblRefNr.Text = "Referenz-Nr. ";
            this.lblRefNr.UseCompatibleTextRendering = true;
            // 
            // lblDatumVon
            // 
            this.lblDatumVon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDatumVon.Location = new System.Drawing.Point(7, 276);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(70, 24);
            this.lblDatumVon.TabIndex = 41;
            this.lblDatumVon.Text = "Gültig von";
            this.lblDatumVon.UseCompatibleTextRendering = true;
            // 
            // lblGueltigBis
            // 
            this.lblGueltigBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGueltigBis.Location = new System.Drawing.Point(222, 276);
            this.lblGueltigBis.Name = "lblGueltigBis";
            this.lblGueltigBis.Size = new System.Drawing.Size(27, 24);
            this.lblGueltigBis.TabIndex = 43;
            this.lblGueltigBis.Text = "bis";
            this.lblGueltigBis.UseCompatibleTextRendering = true;
            // 
            // tabZusatz
            // 
            this.tabZusatz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabZusatz.Controls.Add(this.tpgZahlungsempfaenger);
            this.tabZusatz.Controls.Add(this.tpgStandard);
            this.tabZusatz.Controls.Add(this.tpgDokumente);
            this.tabZusatz.Location = new System.Drawing.Point(395, 277);
            this.tabZusatz.Name = "tabZusatz";
            this.tabZusatz.SelectedTabIndex = 2;
            this.tabZusatz.ShowFixedWidthTooltip = true;
            this.tabZusatz.Size = new System.Drawing.Size(550, 219);
            this.tabZusatz.TabIndex = 12;
            this.tabZusatz.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgZahlungsempfaenger,
            this.tpgStandard,
            this.tpgDokumente});
            this.tabZusatz.TabsLineColor = System.Drawing.Color.Black;
            this.tabZusatz.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabZusatz.Text = "kissTabControlEx1";
            this.tabZusatz.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabZusatz_SelectedTabChanged);
            // 
            // tpgZahlungsempfaenger
            // 
            this.tpgZahlungsempfaenger.Controls.Add(this.pnPersonOnly);
            this.tpgZahlungsempfaenger.Location = new System.Drawing.Point(6, 6);
            this.tpgZahlungsempfaenger.Name = "tpgZahlungsempfaenger";
            this.tpgZahlungsempfaenger.Size = new System.Drawing.Size(538, 181);
            this.tpgZahlungsempfaenger.TabIndex = 0;
            this.tpgZahlungsempfaenger.Title = "Zahlungsempfänger";
            // 
            // pnPersonOnly
            // 
            this.pnPersonOnly.Controls.Add(this.pnlAdresse);
            this.pnPersonOnly.Controls.Add(this.edtWMAVerwenden);
            this.pnPersonOnly.Controls.Add(this.lblZahlungsempfaenger);
            this.pnPersonOnly.Controls.Add(this.kissLabel26);
            this.pnPersonOnly.Controls.Add(this.kissLabel29);
            this.pnPersonOnly.Controls.Add(this.kissLabel24);
            this.pnPersonOnly.Controls.Add(this.lblName);
            this.pnPersonOnly.Controls.Add(this.edtOrt);
            this.pnPersonOnly.Controls.Add(this.edtPLZ);
            this.pnPersonOnly.Controls.Add(this.edtHausNr);
            this.pnPersonOnly.Controls.Add(this.edtStrasse);
            this.pnPersonOnly.Controls.Add(this.edtZusatz);
            this.pnPersonOnly.Controls.Add(this.edtName);
            this.pnPersonOnly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnPersonOnly.Location = new System.Drawing.Point(0, 0);
            this.pnPersonOnly.Name = "pnPersonOnly";
            this.pnPersonOnly.Size = new System.Drawing.Size(538, 181);
            this.pnPersonOnly.TabIndex = 126;
            // 
            // pnlAdresse
            // 
            this.pnlAdresse.Controls.Add(this.kissTextEdit3);
            this.pnlAdresse.Controls.Add(this.kissTextEdit4);
            this.pnlAdresse.Controls.Add(this.kissTextEdit5);
            this.pnlAdresse.Controls.Add(this.kissTextEdit2);
            this.pnlAdresse.Controls.Add(this.kissTextEdit6);
            this.pnlAdresse.Controls.Add(this.kissTextEdit7);
            this.pnlAdresse.Location = new System.Drawing.Point(68, 52);
            this.pnlAdresse.Name = "pnlAdresse";
            this.pnlAdresse.Size = new System.Drawing.Size(265, 106);
            this.pnlAdresse.TabIndex = 127;
            // 
            // kissTextEdit3
            // 
            this.kissTextEdit3.DataMember = "WohnsitzOrt";
            this.kissTextEdit3.DataSource = this.qryBaPerson;
            this.kissTextEdit3.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit3.Location = new System.Drawing.Point(51, 73);
            this.kissTextEdit3.Name = "kissTextEdit3";
            this.kissTextEdit3.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit3.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit3.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit3.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit3.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit3.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit3.Properties.MaxLength = 100;
            this.kissTextEdit3.Properties.Name = "editStrasseWohnsitz.Properties";
            this.kissTextEdit3.Properties.ReadOnly = true;
            this.kissTextEdit3.Size = new System.Drawing.Size(207, 24);
            this.kissTextEdit3.TabIndex = 21;
            // 
            // qryBaPerson
            // 
            this.qryBaPerson.HostControl = this;
            this.qryBaPerson.IsIdentityInsert = false;
            this.qryBaPerson.SelectStatement = "select \r\n  VornameName, \r\n  WohnsitzAdressZusatz, \r\n  WohnsitzStrasse, \r\n  Wohnsi" +
    "tzHausNr, \r\n  WohnsitzPLZ, \r\n  WohnsitzOrt \r\nfrom dbo.vwPerson \r\nwhere BaPersonI" +
    "D = {0}";
            // 
            // kissTextEdit4
            // 
            this.kissTextEdit4.DataMember = "WohnsitzPLZ";
            this.kissTextEdit4.DataSource = this.qryBaPerson;
            this.kissTextEdit4.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit4.Location = new System.Drawing.Point(3, 73);
            this.kissTextEdit4.Name = "kissTextEdit4";
            this.kissTextEdit4.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit4.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit4.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit4.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit4.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit4.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit4.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit4.Properties.MaxLength = 10;
            this.kissTextEdit4.Properties.Name = "editNummerWohnsitz.Properties";
            this.kissTextEdit4.Properties.ReadOnly = true;
            this.kissTextEdit4.Size = new System.Drawing.Size(49, 24);
            this.kissTextEdit4.TabIndex = 20;
            // 
            // kissTextEdit5
            // 
            this.kissTextEdit5.DataMember = "WohnsitzHausNr";
            this.kissTextEdit5.DataSource = this.qryBaPerson;
            this.kissTextEdit5.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit5.Location = new System.Drawing.Point(209, 50);
            this.kissTextEdit5.Name = "kissTextEdit5";
            this.kissTextEdit5.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit5.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit5.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit5.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit5.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit5.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit5.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit5.Properties.MaxLength = 10;
            this.kissTextEdit5.Properties.Name = "editNummerWohnsitz.Properties";
            this.kissTextEdit5.Properties.ReadOnly = true;
            this.kissTextEdit5.Size = new System.Drawing.Size(49, 24);
            this.kissTextEdit5.TabIndex = 19;
            // 
            // kissTextEdit2
            // 
            this.kissTextEdit2.DataMember = "WohnsitzStrasse";
            this.kissTextEdit2.DataSource = this.qryBaPerson;
            this.kissTextEdit2.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit2.Location = new System.Drawing.Point(3, 50);
            this.kissTextEdit2.Name = "kissTextEdit2";
            this.kissTextEdit2.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit2.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit2.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit2.Properties.MaxLength = 100;
            this.kissTextEdit2.Properties.Name = "editStrasseWohnsitz.Properties";
            this.kissTextEdit2.Properties.ReadOnly = true;
            this.kissTextEdit2.Size = new System.Drawing.Size(207, 24);
            this.kissTextEdit2.TabIndex = 18;
            // 
            // kissTextEdit6
            // 
            this.kissTextEdit6.DataMember = "WohnsitzAdressZusatz";
            this.kissTextEdit6.DataSource = this.qryBaPerson;
            this.kissTextEdit6.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit6.Location = new System.Drawing.Point(3, 27);
            this.kissTextEdit6.Name = "kissTextEdit6";
            this.kissTextEdit6.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit6.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit6.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit6.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit6.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit6.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit6.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit6.Properties.MaxLength = 200;
            this.kissTextEdit6.Properties.Name = "editZusatzWohnsitz.Properties";
            this.kissTextEdit6.Properties.ReadOnly = true;
            this.kissTextEdit6.Size = new System.Drawing.Size(255, 24);
            this.kissTextEdit6.TabIndex = 17;
            // 
            // kissTextEdit7
            // 
            this.kissTextEdit7.DataMember = "VornameName";
            this.kissTextEdit7.DataSource = this.qryBaPerson;
            this.kissTextEdit7.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit7.Location = new System.Drawing.Point(3, 4);
            this.kissTextEdit7.Name = "kissTextEdit7";
            this.kissTextEdit7.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit7.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit7.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit7.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit7.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit7.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit7.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit7.Properties.Name = "kissTextEdit11.Properties";
            this.kissTextEdit7.Properties.ReadOnly = true;
            this.kissTextEdit7.Size = new System.Drawing.Size(255, 24);
            this.kissTextEdit7.TabIndex = 16;
            // 
            // edtWMAVerwenden
            // 
            this.edtWMAVerwenden.DataMember = "WMAVerwenden";
            this.edtWMAVerwenden.DataSource = this.qryBaZahlungsweg;
            this.edtWMAVerwenden.Location = new System.Drawing.Point(68, 29);
            this.edtWMAVerwenden.Name = "edtWMAVerwenden";
            this.edtWMAVerwenden.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtWMAVerwenden.Properties.Appearance.Options.UseBackColor = true;
            this.edtWMAVerwenden.Properties.Caption = "WMA verwenden";
            this.edtWMAVerwenden.Size = new System.Drawing.Size(117, 24);
            this.edtWMAVerwenden.TabIndex = 126;
            this.edtWMAVerwenden.EditValueChanged += new System.EventHandler(this.edtWMAVerwenden_EditValueChanged);
            // 
            // lblZahlungsempfaenger
            // 
            this.lblZahlungsempfaenger.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblZahlungsempfaenger.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblZahlungsempfaenger.Location = new System.Drawing.Point(71, 8);
            this.lblZahlungsempfaenger.Name = "lblZahlungsempfaenger";
            this.lblZahlungsempfaenger.Size = new System.Drawing.Size(255, 14);
            this.lblZahlungsempfaenger.TabIndex = 124;
            this.lblZahlungsempfaenger.Text = "Adresse des Zahlungsempfängers";
            this.lblZahlungsempfaenger.UseCompatibleTextRendering = true;
            // 
            // kissLabel26
            // 
            this.kissLabel26.Location = new System.Drawing.Point(7, 125);
            this.kissLabel26.Name = "kissLabel26";
            this.kissLabel26.Size = new System.Drawing.Size(62, 24);
            this.kissLabel26.TabIndex = 119;
            this.kissLabel26.Text = "PLZ / Ort";
            this.kissLabel26.UseCompatibleTextRendering = true;
            // 
            // kissLabel29
            // 
            this.kissLabel29.Location = new System.Drawing.Point(7, 102);
            this.kissLabel29.Name = "kissLabel29";
            this.kissLabel29.Size = new System.Drawing.Size(62, 24);
            this.kissLabel29.TabIndex = 117;
            this.kissLabel29.Text = "Strasse / Nr";
            this.kissLabel29.UseCompatibleTextRendering = true;
            // 
            // kissLabel24
            // 
            this.kissLabel24.Location = new System.Drawing.Point(7, 79);
            this.kissLabel24.Name = "kissLabel24";
            this.kissLabel24.Size = new System.Drawing.Size(62, 24);
            this.kissLabel24.TabIndex = 116;
            this.kissLabel24.Text = "Zusatz";
            this.kissLabel24.UseCompatibleTextRendering = true;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(7, 56);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(62, 24);
            this.lblName.TabIndex = 115;
            this.lblName.Text = "Name";
            this.lblName.UseCompatibleTextRendering = true;
            // 
            // edtOrt
            // 
            this.edtOrt.DataMember = "AdresseOrt";
            this.edtOrt.DataSource = this.qryBaZahlungsweg;
            this.edtOrt.Location = new System.Drawing.Point(119, 125);
            this.edtOrt.Name = "edtOrt";
            this.edtOrt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtOrt.Properties.Appearance.Options.UseFont = true;
            this.edtOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtOrt.Properties.MaxLength = 100;
            this.edtOrt.Properties.Name = "editStrasseWohnsitz.Properties";
            this.edtOrt.Size = new System.Drawing.Size(207, 24);
            this.edtOrt.TabIndex = 15;
            // 
            // edtPLZ
            // 
            this.edtPLZ.DataMember = "AdressePLZ";
            this.edtPLZ.DataSource = this.qryBaZahlungsweg;
            this.edtPLZ.Location = new System.Drawing.Point(71, 125);
            this.edtPLZ.Name = "edtPLZ";
            this.edtPLZ.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPLZ.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPLZ.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPLZ.Properties.Appearance.Options.UseBackColor = true;
            this.edtPLZ.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPLZ.Properties.Appearance.Options.UseFont = true;
            this.edtPLZ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPLZ.Properties.MaxLength = 10;
            this.edtPLZ.Properties.Name = "editNummerWohnsitz.Properties";
            this.edtPLZ.Size = new System.Drawing.Size(49, 24);
            this.edtPLZ.TabIndex = 14;
            // 
            // edtHausNr
            // 
            this.edtHausNr.DataMember = "AdresseHausNr";
            this.edtHausNr.DataSource = this.qryBaZahlungsweg;
            this.edtHausNr.Location = new System.Drawing.Point(277, 102);
            this.edtHausNr.Name = "edtHausNr";
            this.edtHausNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtHausNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHausNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHausNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtHausNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHausNr.Properties.Appearance.Options.UseFont = true;
            this.edtHausNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHausNr.Properties.MaxLength = 10;
            this.edtHausNr.Properties.Name = "editNummerWohnsitz.Properties";
            this.edtHausNr.Size = new System.Drawing.Size(49, 24);
            this.edtHausNr.TabIndex = 13;
            // 
            // edtStrasse
            // 
            this.edtStrasse.DataMember = "AdresseStrasse";
            this.edtStrasse.DataSource = this.qryBaZahlungsweg;
            this.edtStrasse.Location = new System.Drawing.Point(71, 102);
            this.edtStrasse.Name = "edtStrasse";
            this.edtStrasse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStrasse.Properties.MaxLength = 100;
            this.edtStrasse.Properties.Name = "editStrasseWohnsitz.Properties";
            this.edtStrasse.Size = new System.Drawing.Size(207, 24);
            this.edtStrasse.TabIndex = 12;
            // 
            // edtZusatz
            // 
            this.edtZusatz.DataMember = "AdresseName2";
            this.edtZusatz.DataSource = this.qryBaZahlungsweg;
            this.edtZusatz.Location = new System.Drawing.Point(71, 79);
            this.edtZusatz.Name = "edtZusatz";
            this.edtZusatz.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZusatz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZusatz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZusatz.Properties.Appearance.Options.UseBackColor = true;
            this.edtZusatz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZusatz.Properties.Appearance.Options.UseFont = true;
            this.edtZusatz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZusatz.Properties.MaxLength = 200;
            this.edtZusatz.Properties.Name = "editZusatzWohnsitz.Properties";
            this.edtZusatz.Size = new System.Drawing.Size(255, 24);
            this.edtZusatz.TabIndex = 11;
            // 
            // edtName
            // 
            this.edtName.DataMember = "AdresseName";
            this.edtName.DataSource = this.qryBaZahlungsweg;
            this.edtName.Location = new System.Drawing.Point(71, 56);
            this.edtName.Name = "edtName";
            this.edtName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtName.Properties.Appearance.Options.UseBackColor = true;
            this.edtName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtName.Properties.Appearance.Options.UseFont = true;
            this.edtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtName.Properties.Name = "kissTextEdit11.Properties";
            this.edtName.Size = new System.Drawing.Size(255, 24);
            this.edtName.TabIndex = 10;
            // 
            // tpgStandard
            // 
            this.tpgStandard.Controls.Add(this.kissTextEdit1);
            this.tpgStandard.Controls.Add(this.kissLabel4);
            this.tpgStandard.Controls.Add(this.kissLabel3);
            this.tpgStandard.Controls.Add(this.kissLabel2);
            this.tpgStandard.Controls.Add(this.edtBaZahlwegModulStdCodes);
            this.tpgStandard.Controls.Add(this.edtIBANErrorMsg);
            this.tpgStandard.Location = new System.Drawing.Point(6, 6);
            this.tpgStandard.Name = "tpgStandard";
            this.tpgStandard.Size = new System.Drawing.Size(538, 181);
            this.tpgStandard.TabIndex = 1;
            this.tpgStandard.Title = "Standard-Zahlweg / IBAN-Fehler";
            // 
            // kissTextEdit1
            // 
            this.kissTextEdit1.DataMember = "BaZahlungswegID";
            this.kissTextEdit1.DataSource = this.qryBaZahlungsweg;
            this.kissTextEdit1.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit1.Location = new System.Drawing.Point(82, 154);
            this.kissTextEdit1.Name = "kissTextEdit1";
            this.kissTextEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit1.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit1.Properties.ReadOnly = true;
            this.kissTextEdit1.Size = new System.Drawing.Size(100, 24);
            this.kissTextEdit1.TabIndex = 129;
            // 
            // kissLabel4
            // 
            this.kissLabel4.Location = new System.Drawing.Point(6, 154);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(70, 24);
            this.kissLabel4.TabIndex = 128;
            this.kissLabel4.Text = "Zahlinfo-ID";
            this.kissLabel4.UseCompatibleTextRendering = true;
            // 
            // kissLabel3
            // 
            this.kissLabel3.Location = new System.Drawing.Point(6, 87);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(70, 24);
            this.kissLabel3.TabIndex = 127;
            this.kissLabel3.Text = "IBAN-Fehler";
            this.kissLabel3.UseCompatibleTextRendering = true;
            // 
            // kissLabel2
            // 
            this.kissLabel2.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissLabel2.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel2.Location = new System.Drawing.Point(82, 4);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(123, 16);
            this.kissLabel2.TabIndex = 125;
            this.kissLabel2.Text = "Standard-Zahlweg für";
            this.kissLabel2.UseCompatibleTextRendering = true;
            // 
            // edtBaZahlwegModulStdCodes
            // 
            this.edtBaZahlwegModulStdCodes.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaZahlwegModulStdCodes.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaZahlwegModulStdCodes.Appearance.Options.UseBackColor = true;
            this.edtBaZahlwegModulStdCodes.Appearance.Options.UseBorderColor = true;
            this.edtBaZahlwegModulStdCodes.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtBaZahlwegModulStdCodes.CheckOnClick = true;
            this.edtBaZahlwegModulStdCodes.DataMember = "BaZahlwegModulStdCodes";
            this.edtBaZahlwegModulStdCodes.DataSource = this.qryBaZahlungsweg;
            this.edtBaZahlwegModulStdCodes.Location = new System.Drawing.Point(82, 23);
            this.edtBaZahlwegModulStdCodes.LOVName = "BaZahlwegModulStd";
            this.edtBaZahlwegModulStdCodes.Name = "edtBaZahlwegModulStdCodes";
            this.edtBaZahlwegModulStdCodes.Size = new System.Drawing.Size(206, 55);
            this.edtBaZahlwegModulStdCodes.TabIndex = 16;
            // 
            // edtIBANErrorMsg
            // 
            this.edtIBANErrorMsg.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtIBANErrorMsg.EditValue = "";
            this.edtIBANErrorMsg.Location = new System.Drawing.Point(82, 87);
            this.edtIBANErrorMsg.Name = "edtIBANErrorMsg";
            this.edtIBANErrorMsg.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtIBANErrorMsg.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIBANErrorMsg.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIBANErrorMsg.Properties.Appearance.Options.UseBackColor = true;
            this.edtIBANErrorMsg.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIBANErrorMsg.Properties.Appearance.Options.UseFont = true;
            this.edtIBANErrorMsg.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtIBANErrorMsg.Properties.ReadOnly = true;
            this.edtIBANErrorMsg.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.edtIBANErrorMsg.Size = new System.Drawing.Size(453, 61);
            this.edtIBANErrorMsg.TabIndex = 15;
            this.edtIBANErrorMsg.TabStop = false;
            // 
            // tpgDokumente
            // 
            this.tpgDokumente.Controls.Add(this.edtDocument);
            this.tpgDokumente.Controls.Add(this.lblStichwort);
            this.tpgDokumente.Controls.Add(this.edtStichwort);
            this.tpgDokumente.Controls.Add(this.lblDokumentTyp);
            this.tpgDokumente.Controls.Add(this.edtDokumentTyp);
            this.tpgDokumente.Controls.Add(this.grdDoc);
            this.tpgDokumente.Location = new System.Drawing.Point(6, 6);
            this.tpgDokumente.Name = "tpgDokumente";
            this.tpgDokumente.Size = new System.Drawing.Size(538, 181);
            this.tpgDokumente.TabIndex = 3;
            this.tpgDokumente.Title = "Dokumente";
            // 
            // edtDocument
            // 
            this.edtDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDocument.CanCreateDocument = false;
            this.edtDocument.Context = null;
            this.edtDocument.DataMember = "DocumentID";
            this.edtDocument.DataSource = this.qryBaZahlungswegDokumente;
            this.edtDocument.Location = new System.Drawing.Point(415, 154);
            this.edtDocument.Name = "edtDocument";
            this.edtDocument.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDocument.Properties.Appearance.Options.UseBackColor = true;
            this.edtDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDocument.Properties.Appearance.Options.UseFont = true;
            this.edtDocument.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocument.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocument.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocument.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "Dokument importieren")});
            this.edtDocument.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDocument.Properties.ReadOnly = true;
            this.edtDocument.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtDocument.Size = new System.Drawing.Size(120, 24);
            this.edtDocument.TabIndex = 14;
            this.edtDocument.DocumentCreated += new System.EventHandler(this.edtDocument_DocumentCreated);
            this.edtDocument.DocumentDeleted += new System.EventHandler(this.edtDocument_DocumentDeleted);
            this.edtDocument.DocumentImported += new System.EventHandler(this.edtDocument_DocumentImported);
            this.edtDocument.DocumentSaved += new System.EventHandler(this.edtDocument_DocumentSaved);
            // 
            // qryBaZahlungswegDokumente
            // 
            this.qryBaZahlungswegDokumente.CanDelete = true;
            this.qryBaZahlungswegDokumente.CanInsert = true;
            this.qryBaZahlungswegDokumente.CanUpdate = true;
            this.qryBaZahlungswegDokumente.DeleteQuestion = "Soll das Dokument gelöscht werden ?";
            this.qryBaZahlungswegDokumente.HostControl = this;
            this.qryBaZahlungswegDokumente.IsIdentityInsert = false;
            this.qryBaZahlungswegDokumente.SelectStatement = resources.GetString("qryBaZahlungswegDokumente.SelectStatement");
            this.qryBaZahlungswegDokumente.TableName = "BaZahlungswegDokument";
            this.qryBaZahlungswegDokumente.AfterDelete += new System.EventHandler(this.qryBaZahlungswegDokumente_AfterDelete);
            this.qryBaZahlungswegDokumente.AfterInsert += new System.EventHandler(this.qryBaZahlungswegDokumente_AfterInsert);
            this.qryBaZahlungswegDokumente.BeforeDelete += new System.EventHandler(this.qryBaZahlungswegDokumente_BeforeDelete);
            this.qryBaZahlungswegDokumente.BeforeDeleteQuestion += new System.EventHandler(this.qryBaZahlungswegDokumente_BeforeDeleteQuestion);
            this.qryBaZahlungswegDokumente.BeforeInsert += new System.EventHandler(this.qryBaZahlungswegDokumente_BeforeInsert);
            this.qryBaZahlungswegDokumente.BeforePost += new System.EventHandler(this.qryBaZahlungswegDokumente_BeforePost);
            this.qryBaZahlungswegDokumente.PositionChanged += new System.EventHandler(this.qryBaZahlungswegDokumente_PositionChanged);
            // 
            // lblStichwort
            // 
            this.lblStichwort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStichwort.Location = new System.Drawing.Point(179, 154);
            this.lblStichwort.Name = "lblStichwort";
            this.lblStichwort.Size = new System.Drawing.Size(55, 24);
            this.lblStichwort.TabIndex = 13;
            this.lblStichwort.Text = "Stichwort";
            this.lblStichwort.UseCompatibleTextRendering = true;
            // 
            // edtStichwort
            // 
            this.edtStichwort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtStichwort.DataMember = "Stichwort";
            this.edtStichwort.DataSource = this.qryBaZahlungswegDokumente;
            this.edtStichwort.Location = new System.Drawing.Point(240, 154);
            this.edtStichwort.Name = "edtStichwort";
            this.edtStichwort.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStichwort.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStichwort.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStichwort.Properties.Appearance.Options.UseBackColor = true;
            this.edtStichwort.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStichwort.Properties.Appearance.Options.UseFont = true;
            this.edtStichwort.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStichwort.Size = new System.Drawing.Size(169, 24);
            this.edtStichwort.TabIndex = 12;
            // 
            // lblDokumentTyp
            // 
            this.lblDokumentTyp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDokumentTyp.Location = new System.Drawing.Point(3, 154);
            this.lblDokumentTyp.Name = "lblDokumentTyp";
            this.lblDokumentTyp.Size = new System.Drawing.Size(28, 24);
            this.lblDokumentTyp.TabIndex = 11;
            this.lblDokumentTyp.Text = "Typ";
            this.lblDokumentTyp.UseCompatibleTextRendering = true;
            // 
            // edtDokumentTyp
            // 
            this.edtDokumentTyp.AllowNull = false;
            this.edtDokumentTyp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDokumentTyp.DataMember = "BaZahlungswegDokumentTypCode";
            this.edtDokumentTyp.DataSource = this.qryBaZahlungswegDokumente;
            this.edtDokumentTyp.Location = new System.Drawing.Point(37, 154);
            this.edtDokumentTyp.LOVName = "BaZahlungswegDokumentTyp";
            this.edtDokumentTyp.Name = "edtDokumentTyp";
            this.edtDokumentTyp.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
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
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtDokumentTyp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtDokumentTyp.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDokumentTyp.Properties.NullText = "";
            this.edtDokumentTyp.Properties.ShowFooter = false;
            this.edtDokumentTyp.Properties.ShowHeader = false;
            this.edtDokumentTyp.Size = new System.Drawing.Size(136, 24);
            this.edtDokumentTyp.TabIndex = 10;
            // 
            // grdDoc
            // 
            this.grdDoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDoc.DataSource = this.qryBaZahlungswegDokumente;
            // 
            // 
            // 
            this.grdDoc.EmbeddedNavigator.Name = "";
            this.grdDoc.Location = new System.Drawing.Point(0, -2);
            this.grdDoc.MainView = this.gridView1;
            this.grdDoc.Name = "grdDoc";
            this.grdDoc.Size = new System.Drawing.Size(538, 151);
            this.grdDoc.TabIndex = 1;
            this.grdDoc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
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
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
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
            this.colDocTyp,
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
            // colDocTyp
            // 
            this.colDocTyp.Caption = "Typ";
            this.colDocTyp.FieldName = "BaZahlungswegDokumentTypCode";
            this.colDocTyp.Name = "colDocTyp";
            this.colDocTyp.Visible = true;
            this.colDocTyp.VisibleIndex = 0;
            this.colDocTyp.Width = 150;
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
            // lblBaKontoart
            // 
            this.lblBaKontoart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBaKontoart.Location = new System.Drawing.Point(6, 366);
            this.lblBaKontoart.Name = "lblBaKontoart";
            this.lblBaKontoart.Size = new System.Drawing.Size(70, 24);
            this.lblBaKontoart.TabIndex = 130;
            this.lblBaKontoart.Text = "Kontoart";
            this.lblBaKontoart.UseCompatibleTextRendering = true;
            // 
            // lblVerwendungszweck
            // 
            this.lblVerwendungszweck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVerwendungszweck.Location = new System.Drawing.Point(6, 396);
            this.lblVerwendungszweck.Name = "lblVerwendungszweck";
            this.lblVerwendungszweck.Size = new System.Drawing.Size(109, 24);
            this.lblVerwendungszweck.TabIndex = 132;
            this.lblVerwendungszweck.Text = "Verwendungszweck";
            this.lblVerwendungszweck.UseCompatibleTextRendering = true;
            // 
            // edtVerwendungszweck
            // 
            this.edtVerwendungszweck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtVerwendungszweck.DataMember = "Verwendungszweck";
            this.edtVerwendungszweck.DataSource = this.qryBaZahlungsweg;
            this.edtVerwendungszweck.Location = new System.Drawing.Point(115, 396);
            this.edtVerwendungszweck.Name = "edtVerwendungszweck";
            this.edtVerwendungszweck.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVerwendungszweck.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVerwendungszweck.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVerwendungszweck.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerwendungszweck.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVerwendungszweck.Properties.Appearance.Options.UseFont = true;
            this.edtVerwendungszweck.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVerwendungszweck.Properties.MaxLength = 30;
            this.edtVerwendungszweck.Properties.Name = "kissTextEdit16.Properties";
            this.edtVerwendungszweck.Size = new System.Drawing.Size(271, 24);
            this.edtVerwendungszweck.TabIndex = 5;
            // 
            // tabPageEx1
            // 
            this.tabPageEx1.Location = new System.Drawing.Point(0, 0);
            this.tabPageEx1.Name = "tabPageEx1";
            this.tabPageEx1.Size = new System.Drawing.Size(150, 150);
            this.tabPageEx1.TabIndex = 0;
            this.tabPageEx1.Title = "tabPageEx1";
            // 
            // ctlErfassungMutation
            // 
            this.ctlErfassungMutation.ActiveSQLQuery = this.qryBaZahlungsweg;
            this.ctlErfassungMutation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctlErfassungMutation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlErfassungMutation.DataMemberErfassungDatum = "Created";
            this.ctlErfassungMutation.DataMemberMutationDatum = "Modified";
            this.ctlErfassungMutation.LabelLength = 60;
            this.ctlErfassungMutation.Location = new System.Drawing.Point(395, 502);
            this.ctlErfassungMutation.Name = "ctlErfassungMutation";
            this.ctlErfassungMutation.Size = new System.Drawing.Size(244, 38);
            this.ctlErfassungMutation.TabIndex = 133;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.Location = new System.Drawing.Point(640, 499);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(64, 24);
            this.lblStatus.TabIndex = 596;
            this.lblStatus.Text = "Status";
            this.lblStatus.UseCompatibleTextRendering = true;
            // 
            // edtBaFreigabeStatus
            // 
            this.edtBaFreigabeStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBaFreigabeStatus.DataMember = "BaFreigabeStatusCode";
            this.edtBaFreigabeStatus.DataSource = this.qryBaZahlungsweg;
            this.edtBaFreigabeStatus.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBaFreigabeStatus.Location = new System.Drawing.Point(710, 499);
            this.edtBaFreigabeStatus.LOVName = "BaFreigabeStatus";
            this.edtBaFreigabeStatus.Name = "edtBaFreigabeStatus";
            this.edtBaFreigabeStatus.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBaFreigabeStatus.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaFreigabeStatus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaFreigabeStatus.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaFreigabeStatus.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaFreigabeStatus.Properties.Appearance.Options.UseFont = true;
            this.edtBaFreigabeStatus.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBaFreigabeStatus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaFreigabeStatus.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBaFreigabeStatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBaFreigabeStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtBaFreigabeStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtBaFreigabeStatus.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaFreigabeStatus.Properties.Name = "editOrganisationTypX.Properties";
            this.edtBaFreigabeStatus.Properties.NullText = "";
            this.edtBaFreigabeStatus.Properties.ReadOnly = true;
            this.edtBaFreigabeStatus.Properties.ShowFooter = false;
            this.edtBaFreigabeStatus.Properties.ShowHeader = false;
            this.edtBaFreigabeStatus.Size = new System.Drawing.Size(114, 24);
            this.edtBaFreigabeStatus.TabIndex = 595;
            // 
            // btnDefinitiv
            // 
            this.btnDefinitiv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDefinitiv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDefinitiv.Location = new System.Drawing.Point(830, 499);
            this.btnDefinitiv.Name = "btnDefinitiv";
            this.btnDefinitiv.Size = new System.Drawing.Size(88, 24);
            this.btnDefinitiv.TabIndex = 594;
            this.btnDefinitiv.Text = "definitiv";
            this.btnDefinitiv.UseCompatibleTextRendering = true;
            this.btnDefinitiv.UseVisualStyleBackColor = false;
            this.btnDefinitiv.Click += new System.EventHandler(this.btnDefinitiv_Click);
            // 
            // lblDefinitiv
            // 
            this.lblDefinitiv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDefinitiv.DataMember = "Definitiv";
            this.lblDefinitiv.DataSource = this.qryBaZahlungsweg;
            this.lblDefinitiv.Location = new System.Drawing.Point(710, 526);
            this.lblDefinitiv.Name = "lblDefinitiv";
            this.lblDefinitiv.Size = new System.Drawing.Size(235, 24);
            this.lblDefinitiv.TabIndex = 597;
            this.lblDefinitiv.UseCompatibleTextRendering = true;
            // 
            // CtlBaZahlungsweg
            // 
            this.ActiveSQLQuery = this.qryBaZahlungsweg;
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.edtBaFreigabeStatus);
            this.Controls.Add(this.btnDefinitiv);
            this.Controls.Add(this.lblDefinitiv);
            this.Controls.Add(this.ctlErfassungMutation);
            this.Controls.Add(this.lblVerwendungszweck);
            this.Controls.Add(this.edtVerwendungszweck);
            this.Controls.Add(this.lblBaKontoart);
            this.Controls.Add(this.tabZusatz);
            this.Controls.Add(this.lblGueltigBis);
            this.Controls.Add(this.lblDatumVon);
            this.Controls.Add(this.lblRefNr);
            this.Controls.Add(this.lblBCN);
            this.Controls.Add(this.lblIBAN);
            this.Controls.Add(this.lblPostKonto);
            this.Controls.Add(this.lblBankkontoNr);
            this.Controls.Add(this.lblBankPost);
            this.Controls.Add(this.lblEinzahlungsschein);
            this.Controls.Add(this.edtBaKontoart);
            this.Controls.Add(this.edtReferenz);
            this.Controls.Add(this.edtPostkontoNr);
            this.Controls.Add(this.edtBankPC);
            this.Controls.Add(this.edtIBAN);
            this.Controls.Add(this.edtClearingNummer);
            this.Controls.Add(this.edtBankkontoNr);
            this.Controls.Add(this.edtBankPost);
            this.Controls.Add(this.edtEinzahlungsschein);
            this.Controls.Add(this.edtDatumBis);
            this.Controls.Add(this.grdBaZahlungsweg);
            this.Controls.Add(this.edtDatumVon);
            this.Name = "CtlBaZahlungsweg";
            this.Size = new System.Drawing.Size(956, 556);
            this.Load += new System.EventHandler(this.CtlBaZahlungsweg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaZahlungsweg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaZahlungsweg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZahlungsweg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinzahlungsschein.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinzahlungsschein)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBankPost.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBankkontoNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtClearingNummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIBAN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBankPC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPostkontoNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtReferenz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaKontoart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaKontoart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinzahlungsschein)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBankPost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBankkontoNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPostKonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIBAN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBCN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRefNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGueltigBis)).EndInit();
            this.tabZusatz.ResumeLayout(false);
            this.tpgZahlungsempfaenger.ResumeLayout(false);
            this.pnPersonOnly.ResumeLayout(false);
            this.pnlAdresse.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit6.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit7.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWMAVerwenden.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungsempfaenger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPLZ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHausNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).EndInit();
            this.tpgStandard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaZahlwegModulStdCodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIBANErrorMsg.Properties)).EndInit();
            this.tpgDokumente.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtDocument.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaZahlungswegDokumente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichwort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichwort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokumentTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentTyp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaKontoart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwendungszweck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwendungszweck.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaFreigabeStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaFreigabeStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDefinitiv)).EndInit();
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
        private SharpLibrary.WinControls.TabPageEx tabPageEx1;
        private Common.CtlErfassungMutation ctlErfassungMutation;
        private SharpLibrary.WinControls.TabPageEx tpgDokumente;
        private Gui.KissGrid grdDoc;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colDocTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colStichwort;
        private DevExpress.XtraGrid.Columns.GridColumn colDateCreation;
        private DevExpress.XtraGrid.Columns.GridColumn colDateLastSave;
        private Gui.KissLabel lblDokumentTyp;
        private Gui.KissLookUpEdit edtDokumentTyp;
        private Gui.KissLabel lblStichwort;
        private Gui.KissTextEdit edtStichwort;
        private Dokument.XDokument edtDocument;
        private DB.SqlQuery qryBaZahlungswegDokumente;
        private Gui.KissLabel lblStatus;
        private Gui.KissLookUpEdit edtBaFreigabeStatus;
        private Gui.KissButton btnDefinitiv;
        private Gui.KissLabel lblDefinitiv;
    }
}