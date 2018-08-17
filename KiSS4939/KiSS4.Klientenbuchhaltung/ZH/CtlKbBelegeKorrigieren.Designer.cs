namespace KiSS4.Klientenbuchhaltung.ZH
{
    public partial class CtlKbBelegeKorrigieren
    {
        #region Fields

        #region Private Fields

        private KiSS4.Gui.KissButton btnAusführen;
        private KiSS4.Gui.KissButton btnHaushalt;
        private KiSS4.Gui.KissButton btnSprungMonatsbudget;
        private DevExpress.XtraGrid.Columns.GridColumn colAbtretung;
        private DevExpress.XtraGrid.Columns.GridColumn colBaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colBelegDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colBelegNr;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBetragKorrektur;
        private DevExpress.XtraGrid.Columns.GridColumn colBetragOriginal;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrifftBaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungstext;
        private DevExpress.XtraGrid.Columns.GridColumn colDetBaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colDetBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colDetBuchungstext;
        private DevExpress.XtraGrid.Columns.GridColumn colDetPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colDetVerwPeriodeBis;
        private DevExpress.XtraGrid.Columns.GridColumn colDetVerwPeriodeVon;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailAbtretung;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailText;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailVerwPeriodeBis;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailVerwPeriodeVon;
        private DevExpress.XtraGrid.Columns.GridColumn colFaFallID;
        private DevExpress.XtraGrid.Columns.GridColumn colHV;
        private DevExpress.XtraGrid.Columns.GridColumn colJahr;
        private DevExpress.XtraGrid.Columns.GridColumn colKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colKostenart;
        private DevExpress.XtraGrid.Columns.GridColumn colMonat;
        private DevExpress.XtraGrid.Columns.GridColumn colQuoting;
        private DevExpress.XtraGrid.Columns.GridColumn colQuotingDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusBrutto;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusNetto;
        private DevExpress.XtraGrid.Columns.GridColumn colTV;
        private DevExpress.XtraGrid.Columns.GridColumn colText;
        private DevExpress.XtraGrid.Columns.GridColumn colUmbuchungBelegNr;
        private DevExpress.XtraGrid.Columns.GridColumn colValutaDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colVerwPeriodeBis;
        private DevExpress.XtraGrid.Columns.GridColumn colVerwPeriodeBisMaster;
        private DevExpress.XtraGrid.Columns.GridColumn colVerwPeriodeVon;
        private DevExpress.XtraGrid.Columns.GridColumn colVerwPeriodeVonMaster;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissCheckEdit edtAbtretung;
        private KiSS4.Gui.KissCalcEdit edtBetrag;
        private KiSS4.Gui.KissButtonEdit edtBetrifftPerson;
        private KiSS4.Gui.KissButtonEdit edtBgKostenartID;
        private KiSS4.Gui.KissCalcEdit edtFaFallID;
        private KiSS4.Gui.KissCalcEdit edtFaLeistungID;
        private KiSS4.Gui.KissCalcEdit edtHauptvorgang;
        private KiSS4.Gui.KissButtonEdit edtLT;
        private KiSS4.Gui.KissTextEdit edtSplittingart;
        private KiSS4.Gui.KissCalcEdit edtSucheBelegNr;
        private KiSS4.Gui.KissCalcEdit edtSucheBetrag;
        private KiSS4.Gui.KissButtonEdit edtSucheBetrifftPerson;
        private KiSS4.Gui.KissButtonEdit edtSucheBgKostenartID;
        private KiSS4.Gui.KissCalcEdit edtSucheFallNr;
        private KiSS4.Gui.KissButtonEdit edtSucheLT;
        private KiSS4.Gui.KissDateEdit edtSucheValutaDatumBis;
        private KiSS4.Gui.KissDateEdit edtSucheValutaDatumVon;
        private KiSS4.Gui.KissCalcEdit edtTeilvorgang;
        private KiSS4.Gui.KissTextEdit edtTextFix;
        private KiSS4.Gui.KissTextEdit edtTextVariabel;
        private KiSS4.Gui.KissDateEdit edtValutaDatum;
        private KiSS4.Gui.KissDateEdit edtVerwPeriodeBis;
        private KiSS4.Gui.KissDateEdit edtVerwPeriodeVon;
        private KiSS4.Gui.KissGrid grdKbBuchungBruttoPerson;
        private KiSS4.Gui.KissGrid grdKbBuchungBruttoSuche;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKbBuchungBruttoPerson;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKbBuchungBruttoPersonSuche;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKbBuchungBruttoSuche;
        private KiSS4.Gui.KissGrid kissGrid1;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel lblBetragKorr;
        private KiSS4.Gui.KissLabel lblBetrifftPerson;
        private KiSS4.Gui.KissLabel lblBuchungstextKorr;
        private KiSS4.Gui.KissLabel lblFallNr;
        private KiSS4.Gui.KissLabel lblHauptvorgang;
        private KiSS4.Gui.KissLabel lblKlient;
        private KiSS4.Gui.KissLabel lblKorrektur;
        private KiSS4.Gui.KissLabel lblOriginal;
        private KiSS4.Gui.KissLabel lblSucheBelegNr;
        private KiSS4.Gui.KissLabel lblSucheBetrag;
        private KiSS4.Gui.KissLabel lblSucheBetrifftPerson;
        private KiSS4.Gui.KissLabel lblSucheFallNr;
        private KiSS4.Gui.KissLabel lblSucheLA;
        private KiSS4.Gui.KissLabel lblSucheLT;
        private KiSS4.Gui.KissLabel lblSucheValuta;
        private KiSS4.Gui.KissLabel lblValutaDatum;
        private KiSS4.Gui.KissLabel lblVerwPerBisKorr;
        private KiSS4.Gui.KissLabel lblVerwPerVonKorr;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlBuchungstext;
        private KiSS4.DB.SqlQuery qryKbBuchungBruttoSuche;
        private KiSS4.DB.SqlQuery qryQuoting;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit4;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox3;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox4;
        private KiSS4.Gui.KissTabControlEx tabKorrektur;
        private SharpLibrary.WinControls.TabPageEx tabKorrekturDetailBuchungen;
        private SharpLibrary.WinControls.TabPageEx tabKorrekturKopf;

        #endregion

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKbBelegeKorrigieren));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grvKbBuchungBruttoPersonSuche = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDetailPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailVerwPeriodeVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailVerwPeriodeBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdKbBuchungBruttoSuche = new KiSS4.Gui.KissGrid();
            this.qryKbBuchungBruttoSuche = new KiSS4.DB.SqlQuery(this.components);
            this.grvKbBuchungBruttoSuche = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStatusBrutto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox3 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colStatusNetto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colBelegNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBelegDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValutaDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetragOriginal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuoting = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colAbtretung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colFaFallID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJahr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerwPeriodeVonMaster = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerwPeriodeBisMaster = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblOriginal = new KiSS4.Gui.KissLabel();
            this.edtSucheValutaDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtSucheValutaDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtSucheLT = new KiSS4.Gui.KissButtonEdit();
            this.edtSucheBetrifftPerson = new KiSS4.Gui.KissButtonEdit();
            this.edtSucheBgKostenartID = new KiSS4.Gui.KissButtonEdit();
            this.edtSucheFallNr = new KiSS4.Gui.KissCalcEdit();
            this.edtSucheBetrag = new KiSS4.Gui.KissCalcEdit();
            this.lblSucheValuta = new KiSS4.Gui.KissLabel();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.lblSucheBelegNr = new KiSS4.Gui.KissLabel();
            this.lblSucheBetrag = new KiSS4.Gui.KissLabel();
            this.lblSucheFallNr = new KiSS4.Gui.KissLabel();
            this.lblSucheBetrifftPerson = new KiSS4.Gui.KissLabel();
            this.lblSucheLT = new KiSS4.Gui.KissLabel();
            this.lblSucheLA = new KiSS4.Gui.KissLabel();
            this.pnlBuchungstext = new System.Windows.Forms.Panel();
            this.edtTextVariabel = new KiSS4.Gui.KissTextEdit();
            this.edtTextFix = new KiSS4.Gui.KissTextEdit();
            this.edtSplittingart = new KiSS4.Gui.KissTextEdit();
            this.lblVerwPerBisKorr = new KiSS4.Gui.KissLabel();
            this.lblVerwPerVonKorr = new KiSS4.Gui.KissLabel();
            this.lblBetragKorr = new KiSS4.Gui.KissLabel();
            this.btnAusführen = new KiSS4.Gui.KissButton();
            this.lblFallNr = new KiSS4.Gui.KissLabel();
            this.edtFaFallID = new KiSS4.Gui.KissCalcEdit();
            this.edtBetrag = new KiSS4.Gui.KissCalcEdit();
            this.lblBuchungstextKorr = new KiSS4.Gui.KissLabel();
            this.edtVerwPeriodeBis = new KiSS4.Gui.KissDateEdit();
            this.edtVerwPeriodeVon = new KiSS4.Gui.KissDateEdit();
            this.lblHauptvorgang = new KiSS4.Gui.KissLabel();
            this.edtAbtretung = new KiSS4.Gui.KissCheckEdit();
            this.edtTeilvorgang = new KiSS4.Gui.KissCalcEdit();
            this.lblBetrifftPerson = new KiSS4.Gui.KissLabel();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.edtHauptvorgang = new KiSS4.Gui.KissCalcEdit();
            this.edtBgKostenartID = new KiSS4.Gui.KissButtonEdit();
            this.lblKlient = new KiSS4.Gui.KissLabel();
            this.edtBetrifftPerson = new KiSS4.Gui.KissButtonEdit();
            this.edtLT = new KiSS4.Gui.KissButtonEdit();
            this.lblValutaDatum = new KiSS4.Gui.KissLabel();
            this.edtValutaDatum = new KiSS4.Gui.KissDateEdit();
            this.btnSprungMonatsbudget = new KiSS4.Gui.KissButton();
            this.grdKbBuchungBruttoPerson = new KiSS4.Gui.KissGrid();
            this.grvKbBuchungBruttoPerson = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrifftBaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKostenart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetragKorrektur = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colUmbuchungBelegNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerwPeriodeVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerwPeriodeBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuotingDetail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colDetailAbtretung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.lblKorrektur = new KiSS4.Gui.KissLabel();
            this.qryQuoting = new KiSS4.DB.SqlQuery(this.components);
            this.edtSucheBelegNr = new KiSS4.Gui.KissCalcEdit();
            this.tabKorrektur = new KiSS4.Gui.KissTabControlEx();
            this.tabKorrekturKopf = new SharpLibrary.WinControls.TabPageEx();
            this.edtFaLeistungID = new KiSS4.Gui.KissCalcEdit();
            this.btnHaushalt = new KiSS4.Gui.KissButton();
            this.tabKorrekturDetailBuchungen = new SharpLibrary.WinControls.TabPageEx();
            this.kissGrid1 = new KiSS4.Gui.KissGrid();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDetPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetBaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetBuchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetVerwPeriodeVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetVerwPeriodeBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox4 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvKbBuchungBruttoPersonSuche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKbBuchungBruttoSuche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKbBuchungBruttoSuche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKbBuchungBruttoSuche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheValutaDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheValutaDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheLT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBetrifftPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBgKostenartID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFallNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheValuta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBelegNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheFallNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBetrifftPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheLT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheLA)).BeginInit();
            this.pnlBuchungstext.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtTextVariabel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTextFix.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSplittingart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwPerBisKorr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwPerVonKorr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetragKorr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFallNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaFallID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstextKorr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwPeriodeBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwPeriodeVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHauptvorgang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbtretung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTeilvorgang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrifftPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHauptvorgang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKostenartID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrifftPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValutaDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValutaDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKbBuchungBruttoPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKbBuchungBruttoPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKorrektur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuoting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBelegNr.Properties)).BeginInit();
            this.tabKorrektur.SuspendLayout();
            this.tabKorrekturKopf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaLeistungID.Properties)).BeginInit();
            this.tabKorrekturDetailBuchungen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(866, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Location = new System.Drawing.Point(10, 23);
            this.tabControlSearch.Size = new System.Drawing.Size(890, 210);
            this.tabControlSearch.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControlSearch_SelectedTabChanged);
            this.tabControlSearch.SelectedTabChanging += new System.ComponentModel.CancelEventHandler(this.tabControlSearch_SelectedTabChanging);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdKbBuchungBruttoSuche);
            this.tpgListe.Size = new System.Drawing.Size(878, 172);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtSucheBelegNr);
            this.tpgSuchen.Controls.Add(this.lblSucheLA);
            this.tpgSuchen.Controls.Add(this.lblSucheLT);
            this.tpgSuchen.Controls.Add(this.lblSucheBetrifftPerson);
            this.tpgSuchen.Controls.Add(this.lblSucheFallNr);
            this.tpgSuchen.Controls.Add(this.lblSucheBetrag);
            this.tpgSuchen.Controls.Add(this.lblSucheBelegNr);
            this.tpgSuchen.Controls.Add(this.kissLabel4);
            this.tpgSuchen.Controls.Add(this.lblSucheValuta);
            this.tpgSuchen.Controls.Add(this.edtSucheBetrag);
            this.tpgSuchen.Controls.Add(this.edtSucheFallNr);
            this.tpgSuchen.Controls.Add(this.edtSucheBgKostenartID);
            this.tpgSuchen.Controls.Add(this.edtSucheBetrifftPerson);
            this.tpgSuchen.Controls.Add(this.edtSucheLT);
            this.tpgSuchen.Controls.Add(this.edtSucheValutaDatumBis);
            this.tpgSuchen.Controls.Add(this.edtSucheValutaDatumVon);
            this.tpgSuchen.Size = new System.Drawing.Size(878, 172);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheValutaDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheValutaDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheLT, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBetrifftPerson, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBgKostenartID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheFallNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBetrag, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheValuta, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel4, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBelegNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBetrag, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheFallNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBetrifftPerson, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheLT, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheLA, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBelegNr, 0);
            // 
            // grvKbBuchungBruttoPersonSuche
            // 
            this.grvKbBuchungBruttoPersonSuche.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvKbBuchungBruttoPersonSuche.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungBruttoPersonSuche.Appearance.Empty.Options.UseBackColor = true;
            this.grvKbBuchungBruttoPersonSuche.Appearance.Empty.Options.UseFont = true;
            this.grvKbBuchungBruttoPersonSuche.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungBruttoPersonSuche.Appearance.EvenRow.Options.UseFont = true;
            this.grvKbBuchungBruttoPersonSuche.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKbBuchungBruttoPersonSuche.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungBruttoPersonSuche.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKbBuchungBruttoPersonSuche.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKbBuchungBruttoPersonSuche.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKbBuchungBruttoPersonSuche.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKbBuchungBruttoPersonSuche.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKbBuchungBruttoPersonSuche.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungBruttoPersonSuche.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvKbBuchungBruttoPersonSuche.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKbBuchungBruttoPersonSuche.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKbBuchungBruttoPersonSuche.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKbBuchungBruttoPersonSuche.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbBuchungBruttoPersonSuche.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKbBuchungBruttoPersonSuche.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbBuchungBruttoPersonSuche.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungBruttoPersonSuche.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKbBuchungBruttoPersonSuche.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKbBuchungBruttoPersonSuche.Appearance.GroupRow.Options.UseFont = true;
            this.grvKbBuchungBruttoPersonSuche.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKbBuchungBruttoPersonSuche.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKbBuchungBruttoPersonSuche.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKbBuchungBruttoPersonSuche.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungBruttoPersonSuche.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKbBuchungBruttoPersonSuche.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKbBuchungBruttoPersonSuche.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKbBuchungBruttoPersonSuche.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvKbBuchungBruttoPersonSuche.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungBruttoPersonSuche.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKbBuchungBruttoPersonSuche.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKbBuchungBruttoPersonSuche.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKbBuchungBruttoPersonSuche.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKbBuchungBruttoPersonSuche.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvKbBuchungBruttoPersonSuche.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvKbBuchungBruttoPersonSuche.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungBruttoPersonSuche.Appearance.OddRow.Options.UseFont = true;
            this.grvKbBuchungBruttoPersonSuche.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKbBuchungBruttoPersonSuche.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungBruttoPersonSuche.Appearance.Row.Options.UseBackColor = true;
            this.grvKbBuchungBruttoPersonSuche.Appearance.Row.Options.UseFont = true;
            this.grvKbBuchungBruttoPersonSuche.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungBruttoPersonSuche.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKbBuchungBruttoPersonSuche.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvKbBuchungBruttoPersonSuche.Appearance.VertLine.Options.UseBackColor = true;
            this.grvKbBuchungBruttoPersonSuche.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKbBuchungBruttoPersonSuche.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDetailPerson,
            this.colDetailText,
            this.colBetrag,
            this.colDetailVerwPeriodeVon,
            this.colDetailVerwPeriodeBis});
            this.grvKbBuchungBruttoPersonSuche.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvKbBuchungBruttoPersonSuche.GridControl = this.grdKbBuchungBruttoSuche;
            this.grvKbBuchungBruttoPersonSuche.Name = "grvKbBuchungBruttoPersonSuche";
            this.grvKbBuchungBruttoPersonSuche.OptionsBehavior.Editable = false;
            this.grvKbBuchungBruttoPersonSuche.OptionsCustomization.AllowFilter = false;
            this.grvKbBuchungBruttoPersonSuche.OptionsDetail.ShowDetailTabs = false;
            this.grvKbBuchungBruttoPersonSuche.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKbBuchungBruttoPersonSuche.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKbBuchungBruttoPersonSuche.OptionsNavigation.UseTabKey = false;
            this.grvKbBuchungBruttoPersonSuche.OptionsView.ColumnAutoWidth = false;
            this.grvKbBuchungBruttoPersonSuche.OptionsView.ShowChildrenInGroupPanel = true;
            this.grvKbBuchungBruttoPersonSuche.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvKbBuchungBruttoPersonSuche.OptionsView.ShowGroupPanel = false;
            this.grvKbBuchungBruttoPersonSuche.OptionsView.ShowIndicator = false;
            // 
            // colDetailPerson
            // 
            this.colDetailPerson.Caption = "Klient";
            this.colDetailPerson.FieldName = "Person";
            this.colDetailPerson.Name = "colDetailPerson";
            this.colDetailPerson.Visible = true;
            this.colDetailPerson.VisibleIndex = 0;
            this.colDetailPerson.Width = 218;
            // 
            // colDetailText
            // 
            this.colDetailText.Caption = "Buchungstext";
            this.colDetailText.FieldName = "Buchungstext";
            this.colDetailText.Name = "colDetailText";
            this.colDetailText.Visible = true;
            this.colDetailText.VisibleIndex = 1;
            this.colDetailText.Width = 257;
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
            // 
            // colDetailVerwPeriodeVon
            // 
            this.colDetailVerwPeriodeVon.Caption = "Verw.von";
            this.colDetailVerwPeriodeVon.FieldName = "VerwPeriodeVon";
            this.colDetailVerwPeriodeVon.Name = "colDetailVerwPeriodeVon";
            this.colDetailVerwPeriodeVon.Visible = true;
            this.colDetailVerwPeriodeVon.VisibleIndex = 3;
            this.colDetailVerwPeriodeVon.Width = 76;
            // 
            // colDetailVerwPeriodeBis
            // 
            this.colDetailVerwPeriodeBis.Caption = "Verw.bis";
            this.colDetailVerwPeriodeBis.FieldName = "VerwPeriodeBis";
            this.colDetailVerwPeriodeBis.Name = "colDetailVerwPeriodeBis";
            this.colDetailVerwPeriodeBis.Visible = true;
            this.colDetailVerwPeriodeBis.VisibleIndex = 4;
            this.colDetailVerwPeriodeBis.Width = 76;
            // 
            // grdKbBuchungBruttoSuche
            // 
            this.grdKbBuchungBruttoSuche.DataSource = this.qryKbBuchungBruttoSuche;
            this.grdKbBuchungBruttoSuche.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdKbBuchungBruttoSuche.EmbeddedNavigator.Name = "";
            this.grdKbBuchungBruttoSuche.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            gridLevelNode1.LevelTemplate = this.grvKbBuchungBruttoPersonSuche;
            gridLevelNode1.RelationName = "BelegDetail";
            this.grdKbBuchungBruttoSuche.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdKbBuchungBruttoSuche.Location = new System.Drawing.Point(0, 0);
            this.grdKbBuchungBruttoSuche.MainView = this.grvKbBuchungBruttoSuche;
            this.grdKbBuchungBruttoSuche.Name = "grdKbBuchungBruttoSuche";
            this.grdKbBuchungBruttoSuche.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1,
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit3,
            this.repositoryItemImageComboBox3});
            this.grdKbBuchungBruttoSuche.Size = new System.Drawing.Size(878, 172);
            this.grdKbBuchungBruttoSuche.TabIndex = 0;
            this.grdKbBuchungBruttoSuche.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKbBuchungBruttoSuche,
            this.grvKbBuchungBruttoPersonSuche});
            // 
            // qryKbBuchungBruttoSuche
            // 
            this.qryKbBuchungBruttoSuche.FillTimeOut = 300;
            this.qryKbBuchungBruttoSuche.HostControl = this;
            this.qryKbBuchungBruttoSuche.SelectStatement = resources.GetString("qryKbBuchungBruttoSuche.SelectStatement");
            this.qryKbBuchungBruttoSuche.TableName = "KbBuchungBrutto";
            this.qryKbBuchungBruttoSuche.PositionChanged += new System.EventHandler(this.qryKbBuchungBruttoSuche_PositionChanged);
            this.qryKbBuchungBruttoSuche.PositionChanging += new System.EventHandler(this.qryKbBuchungBruttoSuche_PositionChanging);
            // 
            // grvKbBuchungBruttoSuche
            // 
            this.grvKbBuchungBruttoSuche.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvKbBuchungBruttoSuche.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungBruttoSuche.Appearance.Empty.Options.UseBackColor = true;
            this.grvKbBuchungBruttoSuche.Appearance.Empty.Options.UseFont = true;
            this.grvKbBuchungBruttoSuche.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungBruttoSuche.Appearance.EvenRow.Options.UseFont = true;
            this.grvKbBuchungBruttoSuche.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKbBuchungBruttoSuche.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungBruttoSuche.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKbBuchungBruttoSuche.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKbBuchungBruttoSuche.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKbBuchungBruttoSuche.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKbBuchungBruttoSuche.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKbBuchungBruttoSuche.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungBruttoSuche.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvKbBuchungBruttoSuche.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKbBuchungBruttoSuche.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKbBuchungBruttoSuche.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKbBuchungBruttoSuche.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbBuchungBruttoSuche.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKbBuchungBruttoSuche.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvKbBuchungBruttoSuche.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvKbBuchungBruttoSuche.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbBuchungBruttoSuche.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKbBuchungBruttoSuche.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbBuchungBruttoSuche.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKbBuchungBruttoSuche.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKbBuchungBruttoSuche.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKbBuchungBruttoSuche.Appearance.GroupRow.Options.UseFont = true;
            this.grvKbBuchungBruttoSuche.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKbBuchungBruttoSuche.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKbBuchungBruttoSuche.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKbBuchungBruttoSuche.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKbBuchungBruttoSuche.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKbBuchungBruttoSuche.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKbBuchungBruttoSuche.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKbBuchungBruttoSuche.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvKbBuchungBruttoSuche.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungBruttoSuche.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKbBuchungBruttoSuche.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKbBuchungBruttoSuche.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKbBuchungBruttoSuche.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKbBuchungBruttoSuche.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvKbBuchungBruttoSuche.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvKbBuchungBruttoSuche.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungBruttoSuche.Appearance.OddRow.Options.UseFont = true;
            this.grvKbBuchungBruttoSuche.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKbBuchungBruttoSuche.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungBruttoSuche.Appearance.Row.Options.UseBackColor = true;
            this.grvKbBuchungBruttoSuche.Appearance.Row.Options.UseFont = true;
            this.grvKbBuchungBruttoSuche.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungBruttoSuche.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKbBuchungBruttoSuche.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvKbBuchungBruttoSuche.Appearance.VertLine.Options.UseBackColor = true;
            this.grvKbBuchungBruttoSuche.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKbBuchungBruttoSuche.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStatusBrutto,
            this.colStatusNetto,
            this.colBelegNr,
            this.colBelegDatum,
            this.colValutaDatum,
            this.colBetragOriginal,
            this.colText,
            this.colQuoting,
            this.colAbtretung,
            this.colFaFallID,
            this.colMonat,
            this.colJahr,
            this.colVerwPeriodeVonMaster,
            this.colVerwPeriodeBisMaster,
            this.colHV,
            this.colTV});
            this.grvKbBuchungBruttoSuche.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvKbBuchungBruttoSuche.GridControl = this.grdKbBuchungBruttoSuche;
            this.grvKbBuchungBruttoSuche.Name = "grvKbBuchungBruttoSuche";
            this.grvKbBuchungBruttoSuche.OptionsBehavior.Editable = false;
            this.grvKbBuchungBruttoSuche.OptionsCustomization.AllowFilter = false;
            this.grvKbBuchungBruttoSuche.OptionsDetail.ShowDetailTabs = false;
            this.grvKbBuchungBruttoSuche.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKbBuchungBruttoSuche.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKbBuchungBruttoSuche.OptionsNavigation.UseTabKey = false;
            this.grvKbBuchungBruttoSuche.OptionsView.ColumnAutoWidth = false;
            this.grvKbBuchungBruttoSuche.OptionsView.ShowChildrenInGroupPanel = true;
            this.grvKbBuchungBruttoSuche.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvKbBuchungBruttoSuche.OptionsView.ShowGroupPanel = false;
            this.grvKbBuchungBruttoSuche.OptionsView.ShowIndicator = false;
            // 
            // colStatusBrutto
            // 
            this.colStatusBrutto.Caption = "S Brutto";
            this.colStatusBrutto.ColumnEdit = this.repositoryItemImageComboBox3;
            this.colStatusBrutto.FieldName = "KbBuchungStatusCode";
            this.colStatusBrutto.Name = "colStatusBrutto";
            this.colStatusBrutto.Visible = true;
            this.colStatusBrutto.VisibleIndex = 7;
            this.colStatusBrutto.Width = 47;
            // 
            // repositoryItemImageComboBox3
            // 
            this.repositoryItemImageComboBox3.AutoHeight = false;
            this.repositoryItemImageComboBox3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox3.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox3.Name = "repositoryItemImageComboBox3";
            // 
            // colStatusNetto
            // 
            this.colStatusNetto.Caption = "S Netto";
            this.colStatusNetto.ColumnEdit = this.repositoryItemImageComboBox1;
            this.colStatusNetto.FieldName = "StatusNetto";
            this.colStatusNetto.Name = "colStatusNetto";
            this.colStatusNetto.Visible = true;
            this.colStatusNetto.VisibleIndex = 8;
            this.colStatusNetto.Width = 47;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // colBelegNr
            // 
            this.colBelegNr.Caption = "PSCD BelegNr";
            this.colBelegNr.FieldName = "BelegNr";
            this.colBelegNr.Name = "colBelegNr";
            this.colBelegNr.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.colBelegNr.Visible = true;
            this.colBelegNr.VisibleIndex = 1;
            this.colBelegNr.Width = 89;
            // 
            // colBelegDatum
            // 
            this.colBelegDatum.Caption = "Belegdatum";
            this.colBelegDatum.FieldName = "BelegDatum";
            this.colBelegDatum.Name = "colBelegDatum";
            this.colBelegDatum.Visible = true;
            this.colBelegDatum.VisibleIndex = 0;
            this.colBelegDatum.Width = 87;
            // 
            // colValutaDatum
            // 
            this.colValutaDatum.Caption = "Valuta";
            this.colValutaDatum.FieldName = "ValutaDatum";
            this.colValutaDatum.Name = "colValutaDatum";
            this.colValutaDatum.Visible = true;
            this.colValutaDatum.VisibleIndex = 4;
            this.colValutaDatum.Width = 76;
            // 
            // colBetragOriginal
            // 
            this.colBetragOriginal.Caption = "Betrag";
            this.colBetragOriginal.DisplayFormat.FormatString = "n2";
            this.colBetragOriginal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetragOriginal.FieldName = "Betrag";
            this.colBetragOriginal.Name = "colBetragOriginal";
            this.colBetragOriginal.Visible = true;
            this.colBetragOriginal.VisibleIndex = 3;
            // 
            // colText
            // 
            this.colText.Caption = "Buchungstext";
            this.colText.FieldName = "Text";
            this.colText.Name = "colText";
            this.colText.Visible = true;
            this.colText.VisibleIndex = 2;
            this.colText.Width = 158;
            // 
            // colQuoting
            // 
            this.colQuoting.Caption = "Q";
            this.colQuoting.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colQuoting.FieldName = "Quoting";
            this.colQuoting.Name = "colQuoting";
            this.colQuoting.ToolTip = "Quoting";
            this.colQuoting.Visible = true;
            this.colQuoting.VisibleIndex = 5;
            this.colQuoting.Width = 20;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // colAbtretung
            // 
            this.colAbtretung.Caption = "A";
            this.colAbtretung.ColumnEdit = this.repositoryItemCheckEdit3;
            this.colAbtretung.FieldName = "Abgetreten";
            this.colAbtretung.Name = "colAbtretung";
            this.colAbtretung.ToolTip = "Abgetreten";
            this.colAbtretung.Visible = true;
            this.colAbtretung.VisibleIndex = 6;
            this.colAbtretung.Width = 20;
            // 
            // repositoryItemCheckEdit3
            // 
            this.repositoryItemCheckEdit3.AutoHeight = false;
            this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
            // 
            // colFaFallID
            // 
            this.colFaFallID.Caption = "FallNr";
            this.colFaFallID.FieldName = "FaFallID";
            this.colFaFallID.Name = "colFaFallID";
            this.colFaFallID.Visible = true;
            this.colFaFallID.VisibleIndex = 9;
            // 
            // colMonat
            // 
            this.colMonat.Caption = "Monat";
            this.colMonat.FieldName = "Monat";
            this.colMonat.Name = "colMonat";
            this.colMonat.Visible = true;
            this.colMonat.VisibleIndex = 12;
            this.colMonat.Width = 50;
            // 
            // colJahr
            // 
            this.colJahr.Caption = "Jahr";
            this.colJahr.FieldName = "Jahr";
            this.colJahr.Name = "colJahr";
            this.colJahr.Visible = true;
            this.colJahr.VisibleIndex = 13;
            this.colJahr.Width = 46;
            // 
            // colVerwPeriodeVonMaster
            // 
            this.colVerwPeriodeVonMaster.Caption = "Verw.von";
            this.colVerwPeriodeVonMaster.FieldName = "VerwPeriodeVon";
            this.colVerwPeriodeVonMaster.Name = "colVerwPeriodeVonMaster";
            this.colVerwPeriodeVonMaster.Visible = true;
            this.colVerwPeriodeVonMaster.VisibleIndex = 10;
            this.colVerwPeriodeVonMaster.Width = 76;
            // 
            // colVerwPeriodeBisMaster
            // 
            this.colVerwPeriodeBisMaster.Caption = "Verw.bis";
            this.colVerwPeriodeBisMaster.FieldName = "VerwPeriodeBis";
            this.colVerwPeriodeBisMaster.Name = "colVerwPeriodeBisMaster";
            this.colVerwPeriodeBisMaster.Visible = true;
            this.colVerwPeriodeBisMaster.VisibleIndex = 11;
            this.colVerwPeriodeBisMaster.Width = 76;
            // 
            // colHV
            // 
            this.colHV.Caption = "HV";
            this.colHV.FieldName = "Hauptvorgang";
            this.colHV.Name = "colHV";
            this.colHV.ToolTip = "Hauptvorgang";
            this.colHV.Visible = true;
            this.colHV.VisibleIndex = 14;
            this.colHV.Width = 50;
            // 
            // colTV
            // 
            this.colTV.Caption = "TV";
            this.colTV.FieldName = "Teilvorgang";
            this.colTV.Name = "colTV";
            this.colTV.ToolTip = "Teilvorgang";
            this.colTV.Visible = true;
            this.colTV.VisibleIndex = 15;
            this.colTV.Width = 50;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblOriginal);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(912, 23);
            this.panel2.TabIndex = 0;
            // 
            // lblOriginal
            // 
            this.lblOriginal.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblOriginal.Location = new System.Drawing.Point(3, 3);
            this.lblOriginal.Name = "lblOriginal";
            this.lblOriginal.Size = new System.Drawing.Size(165, 16);
            this.lblOriginal.TabIndex = 33;
            this.lblOriginal.Text = "Originalbuchung";
            this.lblOriginal.UseCompatibleTextRendering = true;
            // 
            // edtSucheValutaDatumVon
            // 
            this.edtSucheValutaDatumVon.EditValue = null;
            this.edtSucheValutaDatumVon.Location = new System.Drawing.Point(81, 33);
            this.edtSucheValutaDatumVon.Name = "edtSucheValutaDatumVon";
            this.edtSucheValutaDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheValutaDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheValutaDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheValutaDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheValutaDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheValutaDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheValutaDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheValutaDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtSucheValutaDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheValutaDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.edtSucheValutaDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheValutaDatumVon.Properties.ShowToday = false;
            this.edtSucheValutaDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtSucheValutaDatumVon.TabIndex = 0;
            // 
            // edtSucheValutaDatumBis
            // 
            this.edtSucheValutaDatumBis.EditValue = null;
            this.edtSucheValutaDatumBis.Location = new System.Drawing.Point(214, 33);
            this.edtSucheValutaDatumBis.Name = "edtSucheValutaDatumBis";
            this.edtSucheValutaDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheValutaDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheValutaDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheValutaDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheValutaDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheValutaDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheValutaDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheValutaDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtSucheValutaDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheValutaDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtSucheValutaDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheValutaDatumBis.Properties.ShowToday = false;
            this.edtSucheValutaDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtSucheValutaDatumBis.TabIndex = 1;
            // 
            // edtSucheLT
            // 
            this.edtSucheLT.Location = new System.Drawing.Point(322, 63);
            this.edtSucheLT.Name = "edtSucheLT";
            this.edtSucheLT.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheLT.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheLT.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheLT.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheLT.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheLT.Properties.Appearance.Options.UseFont = true;
            this.edtSucheLT.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtSucheLT.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtSucheLT.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheLT.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSucheLT.Size = new System.Drawing.Size(262, 24);
            this.edtSucheLT.TabIndex = 5;
            this.edtSucheLT.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheLT_UserModifiedFld);
            // 
            // edtSucheBetrifftPerson
            // 
            this.edtSucheBetrifftPerson.Location = new System.Drawing.Point(322, 93);
            this.edtSucheBetrifftPerson.Name = "edtSucheBetrifftPerson";
            this.edtSucheBetrifftPerson.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBetrifftPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBetrifftPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBetrifftPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBetrifftPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBetrifftPerson.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBetrifftPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtSucheBetrifftPerson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtSucheBetrifftPerson.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheBetrifftPerson.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSucheBetrifftPerson.Size = new System.Drawing.Size(262, 24);
            this.edtSucheBetrifftPerson.TabIndex = 6;
            this.edtSucheBetrifftPerson.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheBetrifftPerson_UserModifiedFld);
            // 
            // edtSucheBgKostenartID
            // 
            this.edtSucheBgKostenartID.Location = new System.Drawing.Point(322, 124);
            this.edtSucheBgKostenartID.LookupSQL = "SELECT\r\n  ID$  = BgKostenartID,\r\n  Text = IsNull(KontoNr + \' \', \'\') + Name\r\nFROM " +
    "BgKostenart   BKA\r\nWHERE IsNull(KontoNr + \' \', \'\') + Name LIKE \'%\' + {0} + \'%\'\r\n" +
    "----";
            this.edtSucheBgKostenartID.Name = "edtSucheBgKostenartID";
            this.edtSucheBgKostenartID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBgKostenartID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBgKostenartID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBgKostenartID.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBgKostenartID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBgKostenartID.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBgKostenartID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtSucheBgKostenartID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtSucheBgKostenartID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheBgKostenartID.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSucheBgKostenartID.Size = new System.Drawing.Size(262, 24);
            this.edtSucheBgKostenartID.TabIndex = 7;
            this.edtSucheBgKostenartID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheBgKostenartID_UserModifiedFld);
            // 
            // edtSucheFallNr
            // 
            this.edtSucheFallNr.Location = new System.Drawing.Point(81, 93);
            this.edtSucheFallNr.Name = "edtSucheFallNr";
            this.edtSucheFallNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheFallNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheFallNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheFallNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheFallNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheFallNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheFallNr.Properties.Appearance.Options.UseFont = true;
            this.edtSucheFallNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheFallNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheFallNr.Size = new System.Drawing.Size(100, 24);
            this.edtSucheFallNr.TabIndex = 3;
            // 
            // edtSucheBetrag
            // 
            this.edtSucheBetrag.Location = new System.Drawing.Point(81, 123);
            this.edtSucheBetrag.Name = "edtSucheBetrag";
            this.edtSucheBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheBetrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheBetrag.Size = new System.Drawing.Size(100, 24);
            this.edtSucheBetrag.TabIndex = 4;
            // 
            // lblSucheValuta
            // 
            this.lblSucheValuta.Location = new System.Drawing.Point(4, 33);
            this.lblSucheValuta.Name = "lblSucheValuta";
            this.lblSucheValuta.Size = new System.Drawing.Size(71, 24);
            this.lblSucheValuta.TabIndex = 13;
            this.lblSucheValuta.Text = "Valuta von";
            this.lblSucheValuta.UseCompatibleTextRendering = true;
            // 
            // kissLabel4
            // 
            this.kissLabel4.Location = new System.Drawing.Point(187, 33);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(21, 24);
            this.kissLabel4.TabIndex = 14;
            this.kissLabel4.Text = "bis";
            this.kissLabel4.UseCompatibleTextRendering = true;
            // 
            // lblSucheBelegNr
            // 
            this.lblSucheBelegNr.Location = new System.Drawing.Point(4, 63);
            this.lblSucheBelegNr.Name = "lblSucheBelegNr";
            this.lblSucheBelegNr.Size = new System.Drawing.Size(71, 24);
            this.lblSucheBelegNr.TabIndex = 17;
            this.lblSucheBelegNr.Text = "Beleg-Nr.";
            this.lblSucheBelegNr.UseCompatibleTextRendering = true;
            // 
            // lblSucheBetrag
            // 
            this.lblSucheBetrag.Location = new System.Drawing.Point(4, 122);
            this.lblSucheBetrag.Name = "lblSucheBetrag";
            this.lblSucheBetrag.Size = new System.Drawing.Size(71, 24);
            this.lblSucheBetrag.TabIndex = 17;
            this.lblSucheBetrag.Text = "Betrag";
            this.lblSucheBetrag.UseCompatibleTextRendering = true;
            // 
            // lblSucheFallNr
            // 
            this.lblSucheFallNr.Location = new System.Drawing.Point(4, 92);
            this.lblSucheFallNr.Name = "lblSucheFallNr";
            this.lblSucheFallNr.Size = new System.Drawing.Size(71, 24);
            this.lblSucheFallNr.TabIndex = 17;
            this.lblSucheFallNr.Text = "Fallnummer";
            this.lblSucheFallNr.UseCompatibleTextRendering = true;
            // 
            // lblSucheBetrifftPerson
            // 
            this.lblSucheBetrifftPerson.Location = new System.Drawing.Point(214, 93);
            this.lblSucheBetrifftPerson.Name = "lblSucheBetrifftPerson";
            this.lblSucheBetrifftPerson.Size = new System.Drawing.Size(100, 23);
            this.lblSucheBetrifftPerson.TabIndex = 19;
            this.lblSucheBetrifftPerson.Text = "Betrifft Person";
            this.lblSucheBetrifftPerson.UseCompatibleTextRendering = true;
            // 
            // lblSucheLT
            // 
            this.lblSucheLT.Location = new System.Drawing.Point(214, 63);
            this.lblSucheLT.Name = "lblSucheLT";
            this.lblSucheLT.Size = new System.Drawing.Size(100, 23);
            this.lblSucheLT.TabIndex = 19;
            this.lblSucheLT.Text = "Leistungsträger/in";
            this.lblSucheLT.UseCompatibleTextRendering = true;
            // 
            // lblSucheLA
            // 
            this.lblSucheLA.Location = new System.Drawing.Point(214, 123);
            this.lblSucheLA.Name = "lblSucheLA";
            this.lblSucheLA.Size = new System.Drawing.Size(100, 23);
            this.lblSucheLA.TabIndex = 21;
            this.lblSucheLA.Text = "Leistungsart";
            this.lblSucheLA.UseCompatibleTextRendering = true;
            // 
            // pnlBuchungstext
            // 
            this.pnlBuchungstext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBuchungstext.Controls.Add(this.edtTextVariabel);
            this.pnlBuchungstext.Controls.Add(this.edtTextFix);
            this.pnlBuchungstext.Location = new System.Drawing.Point(526, 4);
            this.pnlBuchungstext.Name = "pnlBuchungstext";
            this.pnlBuchungstext.Size = new System.Drawing.Size(344, 28);
            this.pnlBuchungstext.TabIndex = 8;
            // 
            // edtTextVariabel
            // 
            this.edtTextVariabel.DataMember = "TextVariabel";
            this.edtTextVariabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtTextVariabel.Location = new System.Drawing.Point(117, 0);
            this.edtTextVariabel.Name = "edtTextVariabel";
            this.edtTextVariabel.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTextVariabel.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTextVariabel.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTextVariabel.Properties.Appearance.Options.UseBackColor = true;
            this.edtTextVariabel.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTextVariabel.Properties.Appearance.Options.UseFont = true;
            this.edtTextVariabel.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTextVariabel.Size = new System.Drawing.Size(227, 24);
            this.edtTextVariabel.TabIndex = 1;
            this.edtTextVariabel.Leave += new System.EventHandler(this.edtTextVariabel_Leave);
            // 
            // edtTextFix
            // 
            this.edtTextFix.DataMember = "TextFix";
            this.edtTextFix.Dock = System.Windows.Forms.DockStyle.Left;
            this.edtTextFix.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtTextFix.Location = new System.Drawing.Point(0, 0);
            this.edtTextFix.Name = "edtTextFix";
            this.edtTextFix.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtTextFix.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTextFix.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTextFix.Properties.Appearance.Options.UseBackColor = true;
            this.edtTextFix.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTextFix.Properties.Appearance.Options.UseFont = true;
            this.edtTextFix.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTextFix.Properties.ReadOnly = true;
            this.edtTextFix.Size = new System.Drawing.Size(117, 24);
            this.edtTextFix.TabIndex = 0;
            this.edtTextFix.TabStop = false;
            // 
            // edtSplittingart
            // 
            this.edtSplittingart.DataMember = "Splittingart";
            this.edtSplittingart.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtSplittingart.Location = new System.Drawing.Point(765, 33);
            this.edtSplittingart.Name = "edtSplittingart";
            this.edtSplittingart.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSplittingart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSplittingart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSplittingart.Properties.Appearance.Options.UseBackColor = true;
            this.edtSplittingart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSplittingart.Properties.Appearance.Options.UseFont = true;
            this.edtSplittingart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSplittingart.Properties.ReadOnly = true;
            this.edtSplittingart.Size = new System.Drawing.Size(20, 24);
            this.edtSplittingart.TabIndex = 11;
            this.edtSplittingart.TabStop = false;
            this.edtSplittingart.ToolTip = "Splittingart";
            // 
            // lblVerwPerBisKorr
            // 
            this.lblVerwPerBisKorr.Location = new System.Drawing.Point(632, 33);
            this.lblVerwPerBisKorr.Name = "lblVerwPerBisKorr";
            this.lblVerwPerBisKorr.Size = new System.Drawing.Size(18, 24);
            this.lblVerwPerBisKorr.TabIndex = 19;
            this.lblVerwPerBisKorr.Text = "bis";
            this.lblVerwPerBisKorr.UseCompatibleTextRendering = true;
            // 
            // lblVerwPerVonKorr
            // 
            this.lblVerwPerVonKorr.Location = new System.Drawing.Point(389, 33);
            this.lblVerwPerVonKorr.Name = "lblVerwPerVonKorr";
            this.lblVerwPerVonKorr.Size = new System.Drawing.Size(137, 24);
            this.lblVerwPerVonKorr.TabIndex = 17;
            this.lblVerwPerVonKorr.Text = "Verwendungsperiode von";
            this.lblVerwPerVonKorr.UseCompatibleTextRendering = true;
            // 
            // lblBetragKorr
            // 
            this.lblBetragKorr.Location = new System.Drawing.Point(389, 63);
            this.lblBetragKorr.Name = "lblBetragKorr";
            this.lblBetragKorr.Size = new System.Drawing.Size(100, 23);
            this.lblBetragKorr.TabIndex = 15;
            this.lblBetragKorr.Text = "Betrag";
            this.lblBetragKorr.UseCompatibleTextRendering = true;
            // 
            // btnAusführen
            // 
            this.btnAusführen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAusführen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAusführen.Location = new System.Drawing.Point(800, 589);
            this.btnAusführen.Name = "btnAusführen";
            this.btnAusführen.Size = new System.Drawing.Size(100, 24);
            this.btnAusführen.TabIndex = 0;
            this.btnAusführen.Text = "Ausführen";
            this.btnAusführen.UseCompatibleTextRendering = true;
            this.btnAusführen.UseVisualStyleBackColor = false;
            this.btnAusführen.Click += new System.EventHandler(this.btnAusführen_Click);
            // 
            // lblFallNr
            // 
            this.lblFallNr.Location = new System.Drawing.Point(389, 93);
            this.lblFallNr.Name = "lblFallNr";
            this.lblFallNr.Size = new System.Drawing.Size(100, 23);
            this.lblFallNr.TabIndex = 13;
            this.lblFallNr.Text = "Fall-Nr. / Leistung";
            this.lblFallNr.UseCompatibleTextRendering = true;
            // 
            // edtFaFallID
            // 
            this.edtFaFallID.DataMember = "FaFallID";
            this.edtFaFallID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtFaFallID.Location = new System.Drawing.Point(526, 93);
            this.edtFaFallID.Name = "edtFaFallID";
            this.edtFaFallID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtFaFallID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtFaFallID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaFallID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaFallID.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaFallID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaFallID.Properties.Appearance.Options.UseFont = true;
            this.edtFaFallID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFaFallID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFaFallID.Properties.ReadOnly = true;
            this.edtFaFallID.Size = new System.Drawing.Size(100, 24);
            this.edtFaFallID.TabIndex = 13;
            this.edtFaFallID.TabStop = false;
            // 
            // edtBetrag
            // 
            this.edtBetrag.DataMember = "Betrag";
            this.edtBetrag.Location = new System.Drawing.Point(526, 63);
            this.edtBetrag.Name = "edtBetrag";
            this.edtBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBetrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetrag.Properties.DisplayFormat.FormatString = "N2";
            this.edtBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Properties.EditFormat.FormatString = "N2";
            this.edtBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Size = new System.Drawing.Size(100, 24);
            this.edtBetrag.TabIndex = 12;
            this.edtBetrag.Leave += new System.EventHandler(this.edtBetrag_Leave);
            // 
            // lblBuchungstextKorr
            // 
            this.lblBuchungstextKorr.Location = new System.Drawing.Point(389, 3);
            this.lblBuchungstextKorr.Name = "lblBuchungstextKorr";
            this.lblBuchungstextKorr.Size = new System.Drawing.Size(100, 23);
            this.lblBuchungstextKorr.TabIndex = 11;
            this.lblBuchungstextKorr.Text = "Buchungstext";
            this.lblBuchungstextKorr.UseCompatibleTextRendering = true;
            // 
            // edtVerwPeriodeBis
            // 
            this.edtVerwPeriodeBis.DataMember = "VerwPeriodeBis";
            this.edtVerwPeriodeBis.EditValue = null;
            this.edtVerwPeriodeBis.Location = new System.Drawing.Point(656, 33);
            this.edtVerwPeriodeBis.Name = "edtVerwPeriodeBis";
            this.edtVerwPeriodeBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVerwPeriodeBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVerwPeriodeBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVerwPeriodeBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVerwPeriodeBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerwPeriodeBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVerwPeriodeBis.Properties.Appearance.Options.UseFont = true;
            this.edtVerwPeriodeBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtVerwPeriodeBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVerwPeriodeBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtVerwPeriodeBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVerwPeriodeBis.Properties.ShowToday = false;
            this.edtVerwPeriodeBis.Size = new System.Drawing.Size(100, 24);
            this.edtVerwPeriodeBis.TabIndex = 10;
            this.edtVerwPeriodeBis.Leave += new System.EventHandler(this.edtVerwPeriodeBis_Leave);
            // 
            // edtVerwPeriodeVon
            // 
            this.edtVerwPeriodeVon.DataMember = "VerwPeriodeVon";
            this.edtVerwPeriodeVon.EditValue = null;
            this.edtVerwPeriodeVon.Location = new System.Drawing.Point(526, 33);
            this.edtVerwPeriodeVon.Name = "edtVerwPeriodeVon";
            this.edtVerwPeriodeVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVerwPeriodeVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVerwPeriodeVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVerwPeriodeVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVerwPeriodeVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerwPeriodeVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVerwPeriodeVon.Properties.Appearance.Options.UseFont = true;
            this.edtVerwPeriodeVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtVerwPeriodeVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVerwPeriodeVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtVerwPeriodeVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVerwPeriodeVon.Properties.ShowToday = false;
            this.edtVerwPeriodeVon.Size = new System.Drawing.Size(100, 24);
            this.edtVerwPeriodeVon.TabIndex = 9;
            this.edtVerwPeriodeVon.Leave += new System.EventHandler(this.edtVerwPeriodeVon_Leave);
            // 
            // lblHauptvorgang
            // 
            this.lblHauptvorgang.Location = new System.Drawing.Point(6, 124);
            this.lblHauptvorgang.Name = "lblHauptvorgang";
            this.lblHauptvorgang.Size = new System.Drawing.Size(100, 23);
            this.lblHauptvorgang.TabIndex = 8;
            this.lblHauptvorgang.Text = "Haupt- / Teilvorgang";
            this.lblHauptvorgang.UseCompatibleTextRendering = true;
            // 
            // edtAbtretung
            // 
            this.edtAbtretung.DataMember = "Abgetreten";
            this.edtAbtretung.Location = new System.Drawing.Point(270, 126);
            this.edtAbtretung.Name = "edtAbtretung";
            this.edtAbtretung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAbtretung.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbtretung.Properties.Caption = "Abgetreten";
            this.edtAbtretung.Size = new System.Drawing.Size(84, 19);
            this.edtAbtretung.TabIndex = 6;
            this.edtAbtretung.TabStop = false;
            this.edtAbtretung.EditValueChanged += new System.EventHandler(this.edtAbretung_EditValueChanged);
            // 
            // edtTeilvorgang
            // 
            this.edtTeilvorgang.DataMember = "Teilvorgang";
            this.edtTeilvorgang.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtTeilvorgang.Location = new System.Drawing.Point(191, 123);
            this.edtTeilvorgang.Name = "edtTeilvorgang";
            this.edtTeilvorgang.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtTeilvorgang.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtTeilvorgang.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTeilvorgang.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTeilvorgang.Properties.Appearance.Options.UseBackColor = true;
            this.edtTeilvorgang.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTeilvorgang.Properties.Appearance.Options.UseFont = true;
            this.edtTeilvorgang.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTeilvorgang.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTeilvorgang.Properties.ReadOnly = true;
            this.edtTeilvorgang.Size = new System.Drawing.Size(73, 24);
            this.edtTeilvorgang.TabIndex = 5;
            this.edtTeilvorgang.TabStop = false;
            // 
            // lblBetrifftPerson
            // 
            this.lblBetrifftPerson.Location = new System.Drawing.Point(6, 63);
            this.lblBetrifftPerson.Name = "lblBetrifftPerson";
            this.lblBetrifftPerson.Size = new System.Drawing.Size(99, 24);
            this.lblBetrifftPerson.TabIndex = 6;
            this.lblBetrifftPerson.Text = "Betrifft Person";
            this.lblBetrifftPerson.UseCompatibleTextRendering = true;
            // 
            // kissLabel1
            // 
            this.kissLabel1.Location = new System.Drawing.Point(6, 93);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(99, 24);
            this.kissLabel1.TabIndex = 6;
            this.kissLabel1.Text = "Leistungsart";
            this.kissLabel1.UseCompatibleTextRendering = true;
            // 
            // edtHauptvorgang
            // 
            this.edtHauptvorgang.DataMember = "Hauptvorgang";
            this.edtHauptvorgang.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtHauptvorgang.Location = new System.Drawing.Point(112, 123);
            this.edtHauptvorgang.Name = "edtHauptvorgang";
            this.edtHauptvorgang.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtHauptvorgang.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtHauptvorgang.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHauptvorgang.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHauptvorgang.Properties.Appearance.Options.UseBackColor = true;
            this.edtHauptvorgang.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHauptvorgang.Properties.Appearance.Options.UseFont = true;
            this.edtHauptvorgang.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHauptvorgang.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtHauptvorgang.Properties.ReadOnly = true;
            this.edtHauptvorgang.Size = new System.Drawing.Size(73, 24);
            this.edtHauptvorgang.TabIndex = 4;
            this.edtHauptvorgang.TabStop = false;
            // 
            // edtBgKostenartID
            // 
            this.edtBgKostenartID.DataMember = "BgKostenart";
            this.edtBgKostenartID.Location = new System.Drawing.Point(112, 93);
            this.edtBgKostenartID.Name = "edtBgKostenartID";
            this.edtBgKostenartID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBgKostenartID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgKostenartID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgKostenartID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgKostenartID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgKostenartID.Properties.Appearance.Options.UseFont = true;
            this.edtBgKostenartID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtBgKostenartID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtBgKostenartID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgKostenartID.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtBgKostenartID.Size = new System.Drawing.Size(262, 24);
            this.edtBgKostenartID.TabIndex = 3;
            this.edtBgKostenartID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtBgKostenartID_UserModifiedFld);
            // 
            // lblKlient
            // 
            this.lblKlient.Location = new System.Drawing.Point(6, 33);
            this.lblKlient.Name = "lblKlient";
            this.lblKlient.Size = new System.Drawing.Size(100, 23);
            this.lblKlient.TabIndex = 4;
            this.lblKlient.Text = "LT";
            this.lblKlient.UseCompatibleTextRendering = true;
            // 
            // edtBetrifftPerson
            // 
            this.edtBetrifftPerson.DataMember = "BetrifftPerson";
            this.edtBetrifftPerson.Location = new System.Drawing.Point(112, 63);
            this.edtBetrifftPerson.Name = "edtBetrifftPerson";
            this.edtBetrifftPerson.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBetrifftPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetrifftPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetrifftPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetrifftPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetrifftPerson.Properties.Appearance.Options.UseFont = true;
            this.edtBetrifftPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtBetrifftPerson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtBetrifftPerson.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetrifftPerson.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtBetrifftPerson.Size = new System.Drawing.Size(262, 24);
            this.edtBetrifftPerson.TabIndex = 2;
            this.edtBetrifftPerson.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtBetrifftPerson_UserModifiedFld);
            // 
            // edtLT
            // 
            this.edtLT.DataMember = "LT";
            this.edtLT.Location = new System.Drawing.Point(112, 33);
            this.edtLT.Name = "edtLT";
            this.edtLT.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtLT.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLT.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLT.Properties.Appearance.Options.UseBackColor = true;
            this.edtLT.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLT.Properties.Appearance.Options.UseFont = true;
            this.edtLT.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtLT.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtLT.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtLT.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtLT.Size = new System.Drawing.Size(262, 24);
            this.edtLT.TabIndex = 1;
            this.edtLT.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtLT_UserModifiedFld);
            // 
            // lblValutaDatum
            // 
            this.lblValutaDatum.Location = new System.Drawing.Point(6, 3);
            this.lblValutaDatum.Name = "lblValutaDatum";
            this.lblValutaDatum.Size = new System.Drawing.Size(100, 23);
            this.lblValutaDatum.TabIndex = 2;
            this.lblValutaDatum.Text = "Valutadatum";
            this.lblValutaDatum.UseCompatibleTextRendering = true;
            // 
            // edtValutaDatum
            // 
            this.edtValutaDatum.EditValue = null;
            this.edtValutaDatum.Location = new System.Drawing.Point(112, 3);
            this.edtValutaDatum.Name = "edtValutaDatum";
            this.edtValutaDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtValutaDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
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
            this.edtValutaDatum.Properties.ShowToday = false;
            this.edtValutaDatum.Size = new System.Drawing.Size(100, 24);
            this.edtValutaDatum.TabIndex = 0;
            // 
            // btnSprungMonatsbudget
            // 
            this.btnSprungMonatsbudget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSprungMonatsbudget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSprungMonatsbudget.Location = new System.Drawing.Point(781, 231);
            this.btnSprungMonatsbudget.Name = "btnSprungMonatsbudget";
            this.btnSprungMonatsbudget.Size = new System.Drawing.Size(119, 24);
            this.btnSprungMonatsbudget.TabIndex = 0;
            this.btnSprungMonatsbudget.Text = "> Monatsbudget";
            this.btnSprungMonatsbudget.UseCompatibleTextRendering = true;
            this.btnSprungMonatsbudget.UseVisualStyleBackColor = false;
            this.btnSprungMonatsbudget.Click += new System.EventHandler(this.btnSprungMonatsbudget_Click);
            // 
            // grdKbBuchungBruttoPerson
            // 
            this.grdKbBuchungBruttoPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.grdKbBuchungBruttoPerson.EmbeddedNavigator.Name = "";
            this.grdKbBuchungBruttoPerson.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdKbBuchungBruttoPerson.Location = new System.Drawing.Point(10, 258);
            this.grdKbBuchungBruttoPerson.MainView = this.grvKbBuchungBruttoPerson;
            this.grdKbBuchungBruttoPerson.Name = "grdKbBuchungBruttoPerson";
            this.grdKbBuchungBruttoPerson.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox2,
            this.repositoryItemCheckEdit2,
            this.repositoryItemCheckEdit4});
            this.grdKbBuchungBruttoPerson.Size = new System.Drawing.Size(890, 161);
            this.grdKbBuchungBruttoPerson.TabIndex = 11;
            this.grdKbBuchungBruttoPerson.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKbBuchungBruttoPerson});
            // 
            // grvKbBuchungBruttoPerson
            // 
            this.grvKbBuchungBruttoPerson.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvKbBuchungBruttoPerson.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungBruttoPerson.Appearance.Empty.Options.UseBackColor = true;
            this.grvKbBuchungBruttoPerson.Appearance.Empty.Options.UseFont = true;
            this.grvKbBuchungBruttoPerson.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungBruttoPerson.Appearance.EvenRow.Options.UseFont = true;
            this.grvKbBuchungBruttoPerson.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKbBuchungBruttoPerson.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungBruttoPerson.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKbBuchungBruttoPerson.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKbBuchungBruttoPerson.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKbBuchungBruttoPerson.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKbBuchungBruttoPerson.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKbBuchungBruttoPerson.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungBruttoPerson.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvKbBuchungBruttoPerson.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKbBuchungBruttoPerson.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKbBuchungBruttoPerson.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKbBuchungBruttoPerson.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbBuchungBruttoPerson.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKbBuchungBruttoPerson.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvKbBuchungBruttoPerson.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvKbBuchungBruttoPerson.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbBuchungBruttoPerson.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKbBuchungBruttoPerson.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbBuchungBruttoPerson.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKbBuchungBruttoPerson.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKbBuchungBruttoPerson.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKbBuchungBruttoPerson.Appearance.GroupRow.Options.UseFont = true;
            this.grvKbBuchungBruttoPerson.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKbBuchungBruttoPerson.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKbBuchungBruttoPerson.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKbBuchungBruttoPerson.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKbBuchungBruttoPerson.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKbBuchungBruttoPerson.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKbBuchungBruttoPerson.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKbBuchungBruttoPerson.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvKbBuchungBruttoPerson.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungBruttoPerson.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKbBuchungBruttoPerson.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKbBuchungBruttoPerson.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKbBuchungBruttoPerson.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKbBuchungBruttoPerson.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvKbBuchungBruttoPerson.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvKbBuchungBruttoPerson.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungBruttoPerson.Appearance.OddRow.Options.UseFont = true;
            this.grvKbBuchungBruttoPerson.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKbBuchungBruttoPerson.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungBruttoPerson.Appearance.Row.Options.UseBackColor = true;
            this.grvKbBuchungBruttoPerson.Appearance.Row.Options.UseFont = true;
            this.grvKbBuchungBruttoPerson.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungBruttoPerson.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKbBuchungBruttoPerson.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvKbBuchungBruttoPerson.Appearance.VertLine.Options.UseBackColor = true;
            this.grvKbBuchungBruttoPerson.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKbBuchungBruttoPerson.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKlient,
            this.colBaPersonID,
            this.colBetrifftBaPersonID,
            this.colKostenart,
            this.colBuchungstext,
            this.colBetragKorrektur,
            this.colStatus,
            this.colUmbuchungBelegNr,
            this.colVerwPeriodeVon,
            this.colVerwPeriodeBis,
            this.colQuotingDetail,
            this.colDetailAbtretung});
            this.grvKbBuchungBruttoPerson.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvKbBuchungBruttoPerson.GridControl = this.grdKbBuchungBruttoPerson;
            this.grvKbBuchungBruttoPerson.Name = "grvKbBuchungBruttoPerson";
            this.grvKbBuchungBruttoPerson.OptionsBehavior.Editable = false;
            this.grvKbBuchungBruttoPerson.OptionsCustomization.AllowFilter = false;
            this.grvKbBuchungBruttoPerson.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKbBuchungBruttoPerson.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKbBuchungBruttoPerson.OptionsNavigation.UseTabKey = false;
            this.grvKbBuchungBruttoPerson.OptionsView.ColumnAutoWidth = false;
            this.grvKbBuchungBruttoPerson.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvKbBuchungBruttoPerson.OptionsView.ShowFooter = true;
            this.grvKbBuchungBruttoPerson.OptionsView.ShowGroupPanel = false;
            this.grvKbBuchungBruttoPerson.OptionsView.ShowIndicator = false;
            // 
            // colKlient
            // 
            this.colKlient.Caption = "LT";
            this.colKlient.FieldName = "LT";
            this.colKlient.Name = "colKlient";
            this.colKlient.Visible = true;
            this.colKlient.VisibleIndex = 0;
            this.colKlient.Width = 64;
            // 
            // colBaPersonID
            // 
            this.colBaPersonID.Caption = "Betrifft Person";
            this.colBaPersonID.FieldName = "BetrifftPerson";
            this.colBaPersonID.Name = "colBaPersonID";
            this.colBaPersonID.Visible = true;
            this.colBaPersonID.VisibleIndex = 1;
            this.colBaPersonID.Width = 92;
            // 
            // colBetrifftBaPersonID
            // 
            this.colBetrifftBaPersonID.Caption = "Betr.Nr";
            this.colBetrifftBaPersonID.FieldName = "BetrifftBaPersonID";
            this.colBetrifftBaPersonID.Name = "colBetrifftBaPersonID";
            this.colBetrifftBaPersonID.Visible = true;
            this.colBetrifftBaPersonID.VisibleIndex = 2;
            this.colBetrifftBaPersonID.Width = 57;
            // 
            // colKostenart
            // 
            this.colKostenart.Caption = "LA";
            this.colKostenart.FieldName = "KontoNr";
            this.colKostenart.Name = "colKostenart";
            this.colKostenart.Visible = true;
            this.colKostenart.VisibleIndex = 3;
            this.colKostenart.Width = 48;
            // 
            // colBuchungstext
            // 
            this.colBuchungstext.Caption = "Buchungstext";
            this.colBuchungstext.FieldName = "Text";
            this.colBuchungstext.Name = "colBuchungstext";
            this.colBuchungstext.Visible = true;
            this.colBuchungstext.VisibleIndex = 4;
            this.colBuchungstext.Width = 196;
            // 
            // colBetragKorrektur
            // 
            this.colBetragKorrektur.Caption = "Betrag";
            this.colBetragKorrektur.DisplayFormat.FormatString = "n2";
            this.colBetragKorrektur.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetragKorrektur.FieldName = "Betrag";
            this.colBetragKorrektur.Name = "colBetragKorrektur";
            this.colBetragKorrektur.SummaryItem.DisplayFormat = "{0:n2}";
            this.colBetragKorrektur.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colBetragKorrektur.Visible = true;
            this.colBetragKorrektur.VisibleIndex = 5;
            this.colBetragKorrektur.Width = 91;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "S Brutto";
            this.colStatus.ColumnEdit = this.repositoryItemImageComboBox2;
            this.colStatus.FieldName = "KbBuchungStatusCode";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 6;
            this.colStatus.Width = 47;
            // 
            // repositoryItemImageComboBox2
            // 
            this.repositoryItemImageComboBox2.AutoHeight = false;
            this.repositoryItemImageComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox2.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
            // 
            // colUmbuchungBelegNr
            // 
            this.colUmbuchungBelegNr.Caption = "BelegNr";
            this.colUmbuchungBelegNr.FieldName = "BelegNr";
            this.colUmbuchungBelegNr.Name = "colUmbuchungBelegNr";
            this.colUmbuchungBelegNr.Visible = true;
            this.colUmbuchungBelegNr.VisibleIndex = 7;
            this.colUmbuchungBelegNr.Width = 88;
            // 
            // colVerwPeriodeVon
            // 
            this.colVerwPeriodeVon.Caption = "Verw.periode von";
            this.colVerwPeriodeVon.FieldName = "VerwPeriodeVon";
            this.colVerwPeriodeVon.Name = "colVerwPeriodeVon";
            this.colVerwPeriodeVon.Visible = true;
            this.colVerwPeriodeVon.VisibleIndex = 8;
            this.colVerwPeriodeVon.Width = 110;
            // 
            // colVerwPeriodeBis
            // 
            this.colVerwPeriodeBis.Caption = "Verw.periode bis";
            this.colVerwPeriodeBis.FieldName = "VerwPeriodeBis";
            this.colVerwPeriodeBis.Name = "colVerwPeriodeBis";
            this.colVerwPeriodeBis.Visible = true;
            this.colVerwPeriodeBis.VisibleIndex = 9;
            this.colVerwPeriodeBis.Width = 110;
            // 
            // colQuotingDetail
            // 
            this.colQuotingDetail.Caption = "Q";
            this.colQuotingDetail.ColumnEdit = this.repositoryItemCheckEdit2;
            this.colQuotingDetail.FieldName = "Quoting";
            this.colQuotingDetail.Name = "colQuotingDetail";
            this.colQuotingDetail.ToolTip = "Quoting";
            this.colQuotingDetail.Visible = true;
            this.colQuotingDetail.VisibleIndex = 10;
            this.colQuotingDetail.Width = 25;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // colDetailAbtretung
            // 
            this.colDetailAbtretung.Caption = "A";
            this.colDetailAbtretung.ColumnEdit = this.repositoryItemCheckEdit4;
            this.colDetailAbtretung.FieldName = "Abgetreten";
            this.colDetailAbtretung.Name = "colDetailAbtretung";
            this.colDetailAbtretung.ToolTip = "Abgetreten";
            this.colDetailAbtretung.Visible = true;
            this.colDetailAbtretung.VisibleIndex = 11;
            this.colDetailAbtretung.Width = 20;
            // 
            // repositoryItemCheckEdit4
            // 
            this.repositoryItemCheckEdit4.AutoHeight = false;
            this.repositoryItemCheckEdit4.Name = "repositoryItemCheckEdit4";
            // 
            // lblKorrektur
            // 
            this.lblKorrektur.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblKorrektur.Location = new System.Drawing.Point(10, 236);
            this.lblKorrektur.Name = "lblKorrektur";
            this.lblKorrektur.Size = new System.Drawing.Size(200, 19);
            this.lblKorrektur.TabIndex = 0;
            this.lblKorrektur.Text = "STO / NEU-Buchungen";
            this.lblKorrektur.UseCompatibleTextRendering = true;
            // 
            // qryQuoting
            // 
            this.qryQuoting.HostControl = this;
            // 
            // edtSucheBelegNr
            // 
            this.edtSucheBelegNr.Location = new System.Drawing.Point(81, 63);
            this.edtSucheBelegNr.Name = "edtSucheBelegNr";
            this.edtSucheBelegNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheBelegNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBelegNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBelegNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBelegNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBelegNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBelegNr.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBelegNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheBelegNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheBelegNr.Size = new System.Drawing.Size(100, 24);
            this.edtSucheBelegNr.TabIndex = 2;
            // 
            // tabKorrektur
            // 
            this.tabKorrektur.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabKorrektur.Controls.Add(this.tabKorrekturKopf);
            this.tabKorrektur.Controls.Add(this.tabKorrekturDetailBuchungen);
            this.tabKorrektur.FixedWidth = 150;
            this.tabKorrektur.Location = new System.Drawing.Point(12, 419);
            this.tabKorrektur.Name = "tabKorrektur";
            this.tabKorrektur.ShowClose = false;
            this.tabKorrektur.ShowFixedWidthTooltip = true;
            this.tabKorrektur.Size = new System.Drawing.Size(888, 191);
            this.tabKorrektur.TabIndex = 576;
            this.tabKorrektur.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tabKorrekturKopf,
            this.tabKorrekturDetailBuchungen});
            this.tabKorrektur.TabsFitting = SharpLibrary.WinControls.TabsFitting.FixedWidth;
            this.tabKorrektur.TabsLineColor = System.Drawing.Color.Black;
            this.tabKorrektur.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabKorrektur.Text = "tabKorrektur";
            // 
            // tabKorrekturKopf
            // 
            this.tabKorrekturKopf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabKorrekturKopf.Controls.Add(this.edtFaLeistungID);
            this.tabKorrekturKopf.Controls.Add(this.btnHaushalt);
            this.tabKorrekturKopf.Controls.Add(this.edtValutaDatum);
            this.tabKorrekturKopf.Controls.Add(this.pnlBuchungstext);
            this.tabKorrekturKopf.Controls.Add(this.lblValutaDatum);
            this.tabKorrekturKopf.Controls.Add(this.edtLT);
            this.tabKorrekturKopf.Controls.Add(this.edtSplittingart);
            this.tabKorrekturKopf.Controls.Add(this.edtBetrifftPerson);
            this.tabKorrekturKopf.Controls.Add(this.lblVerwPerBisKorr);
            this.tabKorrekturKopf.Controls.Add(this.lblKlient);
            this.tabKorrekturKopf.Controls.Add(this.lblVerwPerVonKorr);
            this.tabKorrekturKopf.Controls.Add(this.edtBgKostenartID);
            this.tabKorrekturKopf.Controls.Add(this.lblBetragKorr);
            this.tabKorrekturKopf.Controls.Add(this.edtHauptvorgang);
            this.tabKorrekturKopf.Controls.Add(this.kissLabel1);
            this.tabKorrekturKopf.Controls.Add(this.lblFallNr);
            this.tabKorrekturKopf.Controls.Add(this.lblBetrifftPerson);
            this.tabKorrekturKopf.Controls.Add(this.edtTeilvorgang);
            this.tabKorrekturKopf.Controls.Add(this.edtFaFallID);
            this.tabKorrekturKopf.Controls.Add(this.edtAbtretung);
            this.tabKorrekturKopf.Controls.Add(this.edtBetrag);
            this.tabKorrekturKopf.Controls.Add(this.lblHauptvorgang);
            this.tabKorrekturKopf.Controls.Add(this.lblBuchungstextKorr);
            this.tabKorrekturKopf.Controls.Add(this.edtVerwPeriodeVon);
            this.tabKorrekturKopf.Controls.Add(this.edtVerwPeriodeBis);
            this.tabKorrekturKopf.Location = new System.Drawing.Point(6, 6);
            this.tabKorrekturKopf.Name = "tabKorrekturKopf";
            this.tabKorrekturKopf.Padding = new System.Windows.Forms.Padding(3);
            this.tabKorrekturKopf.Size = new System.Drawing.Size(876, 153);
            this.tabKorrekturKopf.TabIndex = 0;
            this.tabKorrekturKopf.Title = "STO/NEU Belegkopf";
            // 
            // edtFaLeistungID
            // 
            this.edtFaLeistungID.DataMember = "FaLeistungID";
            this.edtFaLeistungID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtFaLeistungID.Location = new System.Drawing.Point(634, 93);
            this.edtFaLeistungID.Name = "edtFaLeistungID";
            this.edtFaLeistungID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtFaLeistungID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtFaLeistungID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaLeistungID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaLeistungID.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaLeistungID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaLeistungID.Properties.Appearance.Options.UseFont = true;
            this.edtFaLeistungID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFaLeistungID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFaLeistungID.Properties.ReadOnly = true;
            this.edtFaLeistungID.Size = new System.Drawing.Size(100, 24);
            this.edtFaLeistungID.TabIndex = 20;
            this.edtFaLeistungID.TabStop = false;
            // 
            // btnHaushalt
            // 
            this.btnHaushalt.Enabled = false;
            this.btnHaushalt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHaushalt.Location = new System.Drawing.Point(389, 123);
            this.btnHaushalt.Name = "btnHaushalt";
            this.btnHaushalt.Size = new System.Drawing.Size(80, 24);
            this.btnHaushalt.TabIndex = 14;
            this.btnHaushalt.Text = "Haushalt...";
            this.btnHaushalt.UseCompatibleTextRendering = true;
            this.btnHaushalt.UseVisualStyleBackColor = false;
            this.btnHaushalt.Click += new System.EventHandler(this.btnHaushalt_Click);
            // 
            // tabKorrekturDetailBuchungen
            // 
            this.tabKorrekturDetailBuchungen.Controls.Add(this.kissGrid1);
            this.tabKorrekturDetailBuchungen.Location = new System.Drawing.Point(6, 6);
            this.tabKorrekturDetailBuchungen.Name = "tabKorrekturDetailBuchungen";
            this.tabKorrekturDetailBuchungen.Padding = new System.Windows.Forms.Padding(3);
            this.tabKorrekturDetailBuchungen.Size = new System.Drawing.Size(876, 153);
            this.tabKorrekturDetailBuchungen.TabIndex = 1;
            this.tabKorrekturDetailBuchungen.Title = "STO/NEU Positionen";
            // 
            // kissGrid1
            // 
            this.kissGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.kissGrid1.EmbeddedNavigator.Name = "";
            this.kissGrid1.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.kissGrid1.Location = new System.Drawing.Point(3, 3);
            this.kissGrid1.MainView = this.gridView2;
            this.kissGrid1.Name = "kissGrid1";
            this.kissGrid1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox4});
            this.kissGrid1.Size = new System.Drawing.Size(870, 147);
            this.kissGrid1.TabIndex = 476;
            this.kissGrid1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
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
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDetPerson,
            this.colDetBaPersonID,
            this.colDetBuchungstext,
            this.colDetBetrag,
            this.colDetVerwPeriodeVon,
            this.colDetVerwPeriodeBis});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView2.GridControl = this.kissGrid1;
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
            // colDetPerson
            // 
            this.colDetPerson.Caption = "Person";
            this.colDetPerson.FieldName = "Person";
            this.colDetPerson.Name = "colDetPerson";
            this.colDetPerson.Visible = true;
            this.colDetPerson.VisibleIndex = 0;
            this.colDetPerson.Width = 184;
            // 
            // colDetBaPersonID
            // 
            this.colDetBaPersonID.Caption = "Pers-Nr.";
            this.colDetBaPersonID.FieldName = "BaPersonID";
            this.colDetBaPersonID.Name = "colDetBaPersonID";
            this.colDetBaPersonID.Visible = true;
            this.colDetBaPersonID.VisibleIndex = 1;
            this.colDetBaPersonID.Width = 57;
            // 
            // colDetBuchungstext
            // 
            this.colDetBuchungstext.Caption = "Buchungstext";
            this.colDetBuchungstext.FieldName = "Text";
            this.colDetBuchungstext.Name = "colDetBuchungstext";
            this.colDetBuchungstext.Visible = true;
            this.colDetBuchungstext.VisibleIndex = 2;
            this.colDetBuchungstext.Width = 204;
            // 
            // colDetBetrag
            // 
            this.colDetBetrag.Caption = "Betrag";
            this.colDetBetrag.DisplayFormat.FormatString = "n2";
            this.colDetBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDetBetrag.FieldName = "Betrag";
            this.colDetBetrag.Name = "colDetBetrag";
            this.colDetBetrag.SummaryItem.DisplayFormat = "{0:n2}";
            this.colDetBetrag.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colDetBetrag.Visible = true;
            this.colDetBetrag.VisibleIndex = 3;
            this.colDetBetrag.Width = 91;
            // 
            // colDetVerwPeriodeVon
            // 
            this.colDetVerwPeriodeVon.Caption = "Verw.  von";
            this.colDetVerwPeriodeVon.FieldName = "VerwPeriodeVon";
            this.colDetVerwPeriodeVon.Name = "colDetVerwPeriodeVon";
            this.colDetVerwPeriodeVon.Visible = true;
            this.colDetVerwPeriodeVon.VisibleIndex = 4;
            // 
            // colDetVerwPeriodeBis
            // 
            this.colDetVerwPeriodeBis.Caption = "Verw. bis";
            this.colDetVerwPeriodeBis.FieldName = "VerwPeriodeBis";
            this.colDetVerwPeriodeBis.Name = "colDetVerwPeriodeBis";
            this.colDetVerwPeriodeBis.Visible = true;
            this.colDetVerwPeriodeBis.VisibleIndex = 5;
            // 
            // repositoryItemImageComboBox4
            // 
            this.repositoryItemImageComboBox4.AutoHeight = false;
            this.repositoryItemImageComboBox4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox4.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox4.Name = "repositoryItemImageComboBox4";
            // 
            // CtlKbBelegeKorrigieren
            // 
            this.ActiveSQLQuery = this.qryKbBuchungBruttoSuche;
            this.Controls.Add(this.btnSprungMonatsbudget);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnAusführen);
            this.Controls.Add(this.lblKorrektur);
            this.Controls.Add(this.tabKorrektur);
            this.Controls.Add(this.grdKbBuchungBruttoPerson);
            this.Name = "CtlKbBelegeKorrigieren";
            this.Size = new System.Drawing.Size(912, 619);
            this.Load += new System.EventHandler(this.CtlKbBelegeKorrigieren_Load);
            this.Controls.SetChildIndex(this.grdKbBuchungBruttoPerson, 0);
            this.Controls.SetChildIndex(this.tabKorrektur, 0);
            this.Controls.SetChildIndex(this.lblKorrektur, 0);
            this.Controls.SetChildIndex(this.btnAusführen, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.btnSprungMonatsbudget, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvKbBuchungBruttoPersonSuche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKbBuchungBruttoSuche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKbBuchungBruttoSuche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKbBuchungBruttoSuche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheValutaDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheValutaDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheLT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBetrifftPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBgKostenartID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFallNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheValuta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBelegNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheFallNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBetrifftPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheLT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheLA)).EndInit();
            this.pnlBuchungstext.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtTextVariabel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTextFix.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSplittingart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwPerBisKorr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwPerVonKorr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetragKorr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFallNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaFallID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstextKorr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwPeriodeBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwPeriodeVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHauptvorgang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbtretung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTeilvorgang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrifftPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHauptvorgang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKostenartID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrifftPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValutaDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValutaDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKbBuchungBruttoPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKbBuchungBruttoPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKorrektur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuoting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBelegNr.Properties)).EndInit();
            this.tabKorrektur.ResumeLayout(false);
            this.tabKorrekturKopf.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtFaLeistungID.Properties)).EndInit();
            this.tabKorrekturDetailBuchungen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox4)).EndInit();
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
    }
}