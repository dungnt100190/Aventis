namespace KiSS4.Arbeit
{
    partial class CtlKaQEEPQ
    {
        #region Fields

        #region Internal Fields

        protected internal KiSS4.Gui.KissTabControlEx tabControlEPQ;

        #endregion

        #region Private Fields

        private Dokument.XDokument docIntakeVorstellungsgespraech;
        private Gui.KissLabel lblIntakeVorstellungsgespraech;
        private Dokument.XDokument docPrzStandortBestimmung2;
        private Dokument.XDokument docPrzStandortBestimmung1;
        private KiSS4.Gui.KissButton btnPraesenzzeit;
        private KiSS4.Gui.KissButton btnReset;
        private KiSS4.Gui.KissCheckEdit chkVerlaengerung;
        private KiSS4.Gui.KissCheckedLookupEdit chlIntakeCodes;
        private DevExpress.XtraGrid.Columns.GridColumn colAutor;
        private DevExpress.XtraGrid.Columns.GridColumn colBildung;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colErgebnis;
        private DevExpress.XtraGrid.Columns.GridColumn colErgebnisVerl;
        private DevExpress.XtraGrid.Columns.GridColumn colErreichenBis;
        private DevExpress.XtraGrid.Columns.GridColumn colErreichenBisVerl;
        private DevExpress.XtraGrid.Columns.GridColumn colFeinziel;
        private DevExpress.XtraGrid.Columns.GridColumn colFeinzielDat;
        private DevExpress.XtraGrid.Columns.GridColumn colFeinzielDatVerl;
        private DevExpress.XtraGrid.Columns.GridColumn colFeinzielVerl;
        private DevExpress.XtraGrid.Columns.GridColumn colKontaktpers;
        private DevExpress.XtraGrid.Columns.GridColumn colStichwort;
        private DevExpress.XtraGrid.Columns.GridColumn colThema;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissDateEdit datAustritt;
        private KiSS4.Gui.KissDateEdit datAustrittDatum;
        private KiSS4.Gui.KissDateEdit datEinladung1;
        private KiSS4.Gui.KissDateEdit datEinladung2;
        private KiSS4.Gui.KissDateEdit datEintritt;
        private KiSS4.Gui.KissDateEdit datFeinziel;
        private KiSS4.Gui.KissDateEdit datFeinzielVerl;
        private KiSS4.Gui.KissDateEdit datMuendAufford1;
        private KiSS4.Gui.KissDateEdit datMuendAufford2;
        private KiSS4.Gui.KissDateEdit datStaoDatum;
        private KiSS4.Gui.KissDateEdit datVerlaengerung;
        private KiSS4.Gui.KissDateEdit datZielVereinb1;
        private KiSS4.Gui.KissDateEdit datZielVereinb2;
        private KiSS4.Gui.KissLookUpEdit ddlGrund;
        private KiSS4.Dokument.XDokument docAntwortAnbieter;
        private KiSS4.Dokument.XDokument docArbeitszeugnis;
        private KiSS4.Dokument.XDokument docAufforderung1;
        private KiSS4.Dokument.XDokument docAufforderung2;
        private KiSS4.Dokument.XDokument docAufforderung3;
        private KiSS4.Dokument.XDokument docEinladung1;
        private KiSS4.Dokument.XDokument docEinladung2;
        private KiSS4.Dokument.XDokument docEinladungProgBeginn1;
        private KiSS4.Dokument.XDokument docEinladungProgBeginn2;
        private KiSS4.Dokument.XDokument docIndivZieleRAV;
        private KiSS4.Dokument.XDokument docIndivZieleRAVVerl;
        private KiSS4.Dokument.XDokument docPersonalblatt;
        private KiSS4.Dokument.XDokument docProgAbbruch;
        private KiSS4.Dokument.XDokument docSchlussbericht1;
        private KiSS4.Dokument.XDokument docSchlussbericht2;
        private KiSS4.Dokument.XDokument docTaetigProg;
        private KiSS4.Dokument.XDokument docVereinbarung1;
        private KiSS4.Dokument.XDokument docVereinbarung2;
        private KiSS4.Dokument.XDokument docVerlaengerung;
        private KiSS4.Dokument.XDokument docVerwNichterscheinen;
        private KiSS4.Dokument.XDokument docVerwRegelverstoss;
        private KiSS4.Dokument.XDokument docZwischenbericht1;
        private KiSS4.Dokument.XDokument docZwischenbericht2;
        private KiSS4.Dokument.XDokument docZwischenzeugnis;
        private KiSS4.Gui.KissTextEdit edtBeschGrad;
        private KiSS4.Gui.KissTextEdit edtCoach;
        private KiSS4.Gui.KissTextEdit edtErreichenBis;
        private KiSS4.Gui.KissTextEdit edtErreichenBisVerl;
        private KiSS4.Gui.KissTextEdit edtRavBerater;
        private KiSS4.Gui.KissTextEdit edtTelefon;
        private KiSS4.Gui.KissGrid grdIntegBildung;
        private KiSS4.Gui.KissGrid grdVerlauf;
        private KiSS4.Gui.KissGrid grdZielvereinb;
        private KiSS4.Gui.KissGrid grdZielvereinbVerl;
        private DevExpress.XtraGrid.Views.Grid.GridView gvIntegBildung;
        private DevExpress.XtraGrid.Views.Grid.GridView gvVerlauf;
        private DevExpress.XtraGrid.Views.Grid.GridView gvZielvereinb;
        private DevExpress.XtraGrid.Views.Grid.GridView gvZielvereinbVerl;
        private KiSS4.Gui.KissLabel lblAntwortAnbieter;
        private KiSS4.Gui.KissLabel lblArbeitszeugnis;
        private KiSS4.Gui.KissLabel lblAufforderung;
        private KiSS4.Gui.KissLabel lblAustritt;
        private KiSS4.Gui.KissLabel lblAustrittBem;
        private KiSS4.Gui.KissLabel lblAustrittDatum;
        private System.Windows.Forms.Label lblBemerkungen;
        private KiSS4.Gui.KissLabel lblBeschGrad;
        private KiSS4.Gui.KissLabel lblCoach;
        private KiSS4.Gui.KissLabel lblEinladugProgBeginn;
        private KiSS4.Gui.KissLabel lblEinladung;
        private KiSS4.Gui.KissLabel lblEintritt;
        private KiSS4.Gui.KissLabel lblErgebnis;
        private KiSS4.Gui.KissLabel lblErgebnisVerl;
        private KiSS4.Gui.KissLabel lblErreichenBis;
        private KiSS4.Gui.KissLabel lblErreichenBisVerl;
        private KiSS4.Gui.KissLabel lblFeinziel;
        private KiSS4.Gui.KissLabel lblFeinzielVerl;
        private KiSS4.Gui.KissLabel lblGrund;
        private System.Windows.Forms.Label lblIndivZieleRAV;
        private System.Windows.Forms.Label lblIndivZieleRAVVerl;
        private KiSS4.Gui.KissLabel lblMessungZielerreichung;
        private KiSS4.Gui.KissLabel lblMessungZielerreichungVerl;
        private KiSS4.Gui.KissLabel lblMuendAufforderung;
        private KiSS4.Gui.KissLabel lblPersonalblatt;
        private KiSS4.Gui.KissLabel lblProgAbbruch;
        private KiSS4.Gui.KissLabel lblProgBeginn;
        private KiSS4.Gui.KissLabel lblProzent;
        private KiSS4.Gui.KissLabel lblPrzStandortBestimmung;
        private KiSS4.Gui.KissLabel lblRAVBerater;
        private KiSS4.Gui.KissLabel lblSchlussbericht1;
        private KiSS4.Gui.KissLabel lblSchlussbericht2;
        private KiSS4.Gui.KissLabel lblStaoDatum;
        private KiSS4.Gui.KissLabel lblTaetigProg;
        private KiSS4.Gui.KissLabel lblTelefon;
        private System.Windows.Forms.Label lblTitel;
        private KiSS4.Gui.KissLabel lblVereinbarung;
        private KiSS4.Gui.KissLabel lblVerlängerung;
        private KiSS4.Gui.KissLabel lblVerwNichterscheinen;
        private KiSS4.Gui.KissLabel lblVerwRegelverstoss;
        private KiSS4.Gui.KissLabel lblZielVereinb1;
        private KiSS4.Gui.KissLabel lblZielVereinb2;
        private KiSS4.Gui.KissLabel lblZwischenbericht1;
        private KiSS4.Gui.KissLabel lblZwischenbericht2;
        private KiSS4.Gui.KissLabel lblZwischenzeugnis;
        private KiSS4.Gui.KissMemoEdit memAustrittBem;
        private KiSS4.Gui.KissMemoEdit memBemerkungen;
        private KiSS4.Gui.KissMemoEdit memErgebnis;
        private KiSS4.Gui.KissMemoEdit memErgebnisVerl;
        private KiSS4.Gui.KissMemoEdit memFeinziel;
        private KiSS4.Gui.KissMemoEdit memFeinzielVerl;
        private KiSS4.Gui.KissMemoEdit memIndivZieleRAV;
        private KiSS4.Gui.KissMemoEdit memIndivZieleRAVVerl;
        private KiSS4.Gui.KissMemoEdit memMessungZielerreichung;
        private KiSS4.Gui.KissMemoEdit memMessungZielerreichungVerl;
        private KiSS4.Gui.KissMemoEdit memMuendAufford1;
        private KiSS4.Gui.KissMemoEdit memMuendAufford2;
        private System.Windows.Forms.PictureBox picTitle;
        private System.Windows.Forms.Panel pnlHead;
        private System.Windows.Forms.Panel pnlTitle;
        private KiSS4.DB.SqlQuery qryAnweisung;
        private KiSS4.DB.SqlQuery qryDates;
        private KiSS4.DB.SqlQuery qryEPQ;
        private KiSS4.DB.SqlQuery qryIntegBildung;
        private KiSS4.DB.SqlQuery qryVerlauf;
        private KiSS4.DB.SqlQuery qryZielvereinb;
        private KiSS4.DB.SqlQuery qryZielvereinbVerl;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit4;
        private KiSS4.Gui.KissRadioGroup rgGrund;
        private KiSS4.Gui.KissRadioGroup rgProgBeginn;
        private SharpLibrary.WinControls.TabPageEx tpgAustritt;
        private SharpLibrary.WinControls.TabPageEx tpgIntake;
        private SharpLibrary.WinControls.TabPageEx tpgInterventionen;
        private SharpLibrary.WinControls.TabPageEx tpgProzessuebersicht;
        private SharpLibrary.WinControls.TabPageEx tpgZielVereinbarung;
        private SharpLibrary.WinControls.TabPageEx tpgZielVereinbarungVerl;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKaQEEPQ));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject71 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject72 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject73 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject74 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject121 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject122 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject14 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject15 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject16 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject17 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject18 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject19 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject20 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject21 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject22 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject23 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject24 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject25 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject26 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject27 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject28 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject29 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject30 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject31 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject32 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject33 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject34 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject35 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject36 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject37 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject38 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject39 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject40 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject41 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject42 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject43 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject44 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject123 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject124 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject125 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject126 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject49 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject50 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject51 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject52 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject53 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject54 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject55 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject56 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject57 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject58 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject59 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject60 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject61 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject62 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject63 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject64 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject65 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject66 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject67 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject68 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject69 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject70 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject45 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject46 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject47 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject48 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject75 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject76 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject77 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject78 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject79 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject80 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject81 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject82 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject83 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject84 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject85 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject86 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject87 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject88 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject89 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject90 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject91 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject92 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject93 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject94 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject95 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject96 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject97 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject98 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject99 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject100 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject101 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject102 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject103 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject104 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject105 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject106 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject107 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject108 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject109 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject110 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject111 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject112 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject113 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject114 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject115 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject116 = new DevExpress.Utils.SerializableAppearanceObject();
            this.picTitle = new System.Windows.Forms.PictureBox();
            this.lblTitel = new System.Windows.Forms.Label();
            this.qryAnweisung = new KiSS4.DB.SqlQuery(this.components);
            this.datEintritt = new KiSS4.Gui.KissDateEdit();
            this.lblEintritt = new KiSS4.Gui.KissLabel();
            this.datAustritt = new KiSS4.Gui.KissDateEdit();
            this.lblAustritt = new KiSS4.Gui.KissLabel();
            this.edtBeschGrad = new KiSS4.Gui.KissTextEdit();
            this.lblProzent = new KiSS4.Gui.KissLabel();
            this.lblBeschGrad = new KiSS4.Gui.KissLabel();
            this.edtTelefon = new KiSS4.Gui.KissTextEdit();
            this.lblTelefon = new KiSS4.Gui.KissLabel();
            this.edtRavBerater = new KiSS4.Gui.KissTextEdit();
            this.lblRAVBerater = new KiSS4.Gui.KissLabel();
            this.edtCoach = new KiSS4.Gui.KissTextEdit();
            this.lblCoach = new KiSS4.Gui.KissLabel();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pnlHead = new System.Windows.Forms.Panel();
            this.tabControlEPQ = new KiSS4.Gui.KissTabControlEx();
            this.tpgProzessuebersicht = new SharpLibrary.WinControls.TabPageEx();
            this.docVerlaengerung = new KiSS4.Dokument.XDokument();
            this.qryEPQ = new KiSS4.DB.SqlQuery(this.components);
            this.chkVerlaengerung = new KiSS4.Gui.KissCheckEdit();
            this.lblZwischenzeugnis = new KiSS4.Gui.KissLabel();
            this.docZwischenzeugnis = new KiSS4.Dokument.XDokument();
            this.lblArbeitszeugnis = new KiSS4.Gui.KissLabel();
            this.docArbeitszeugnis = new KiSS4.Dokument.XDokument();
            this.datVerlaengerung = new KiSS4.Gui.KissDateEdit();
            this.lblVerlängerung = new KiSS4.Gui.KissLabel();
            this.lblZwischenbericht2 = new KiSS4.Gui.KissLabel();
            this.docZwischenbericht2 = new KiSS4.Dokument.XDokument();
            this.lblZielVereinb2 = new KiSS4.Gui.KissLabel();
            this.lblPersonalblatt = new KiSS4.Gui.KissLabel();
            this.grdIntegBildung = new KiSS4.Gui.KissGrid();
            this.qryIntegBildung = new KiSS4.DB.SqlQuery(this.components);
            this.gvIntegBildung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBildung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.datZielVereinb2 = new KiSS4.Gui.KissDateEdit();
            this.qryDates = new KiSS4.DB.SqlQuery(this.components);
            this.lblZielVereinb1 = new KiSS4.Gui.KissLabel();
            this.datZielVereinb1 = new KiSS4.Gui.KissDateEdit();
            this.docTaetigProg = new KiSS4.Dokument.XDokument();
            this.docPrzStandortBestimmung2 = new KiSS4.Dokument.XDokument();
            this.docPrzStandortBestimmung1 = new KiSS4.Dokument.XDokument();
            this.docPersonalblatt = new KiSS4.Dokument.XDokument();
            this.lblSchlussbericht2 = new KiSS4.Gui.KissLabel();
            this.docSchlussbericht2 = new KiSS4.Dokument.XDokument();
            this.lblSchlussbericht1 = new KiSS4.Gui.KissLabel();
            this.docSchlussbericht1 = new KiSS4.Dokument.XDokument();
            this.lblZwischenbericht1 = new KiSS4.Gui.KissLabel();
            this.docZwischenbericht1 = new KiSS4.Dokument.XDokument();
            this.lblStaoDatum = new KiSS4.Gui.KissLabel();
            this.datStaoDatum = new KiSS4.Gui.KissDateEdit();
            this.lblTaetigProg = new KiSS4.Gui.KissLabel();
            this.lblPrzStandortBestimmung = new KiSS4.Gui.KissLabel();
            this.btnPraesenzzeit = new KiSS4.Gui.KissButton();
            this.grdVerlauf = new KiSS4.Gui.KissGrid();
            this.qryVerlauf = new KiSS4.DB.SqlQuery(this.components);
            this.gvVerlauf = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKontaktpers = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStichwort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThema = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAutor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.tpgIntake = new SharpLibrary.WinControls.TabPageEx();
            this.docIntakeVorstellungsgespraech = new KiSS4.Dokument.XDokument();
            this.lblIntakeVorstellungsgespraech = new KiSS4.Gui.KissLabel();
            this.lblProgBeginn = new KiSS4.Gui.KissLabel();
            this.chlIntakeCodes = new KiSS4.Gui.KissCheckedLookupEdit();
            this.lblBemerkungen = new System.Windows.Forms.Label();
            this.docEinladungProgBeginn2 = new KiSS4.Dokument.XDokument();
            this.docEinladungProgBeginn1 = new KiSS4.Dokument.XDokument();
            this.docAntwortAnbieter = new KiSS4.Dokument.XDokument();
            this.lblAntwortAnbieter = new KiSS4.Gui.KissLabel();
            this.lblEinladugProgBeginn = new KiSS4.Gui.KissLabel();
            this.memBemerkungen = new KiSS4.Gui.KissMemoEdit();
            this.rgProgBeginn = new KiSS4.Gui.KissRadioGroup(this.components);
            this.docEinladung2 = new KiSS4.Dokument.XDokument();
            this.docEinladung1 = new KiSS4.Dokument.XDokument();
            this.datEinladung2 = new KiSS4.Gui.KissDateEdit();
            this.lblEinladung = new KiSS4.Gui.KissLabel();
            this.datEinladung1 = new KiSS4.Gui.KissDateEdit();
            this.tpgZielVereinbarung = new SharpLibrary.WinControls.TabPageEx();
            this.edtErreichenBis = new KiSS4.Gui.KissTextEdit();
            this.qryZielvereinb = new KiSS4.DB.SqlQuery(this.components);
            this.lblErreichenBis = new KiSS4.Gui.KissLabel();
            this.memErgebnis = new KiSS4.Gui.KissMemoEdit();
            this.lblErgebnis = new KiSS4.Gui.KissLabel();
            this.memMessungZielerreichung = new KiSS4.Gui.KissMemoEdit();
            this.lblMessungZielerreichung = new KiSS4.Gui.KissLabel();
            this.memFeinziel = new KiSS4.Gui.KissMemoEdit();
            this.lblFeinziel = new KiSS4.Gui.KissLabel();
            this.datFeinziel = new KiSS4.Gui.KissDateEdit();
            this.grdZielvereinb = new KiSS4.Gui.KissGrid();
            this.gvZielvereinb = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFeinzielDat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFeinziel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colErreichenBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErgebnis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.lblIndivZieleRAV = new System.Windows.Forms.Label();
            this.docIndivZieleRAV = new KiSS4.Dokument.XDokument();
            this.memIndivZieleRAV = new KiSS4.Gui.KissMemoEdit();
            this.tpgZielVereinbarungVerl = new SharpLibrary.WinControls.TabPageEx();
            this.edtErreichenBisVerl = new KiSS4.Gui.KissTextEdit();
            this.qryZielvereinbVerl = new KiSS4.DB.SqlQuery(this.components);
            this.lblErreichenBisVerl = new KiSS4.Gui.KissLabel();
            this.memErgebnisVerl = new KiSS4.Gui.KissMemoEdit();
            this.lblErgebnisVerl = new KiSS4.Gui.KissLabel();
            this.memMessungZielerreichungVerl = new KiSS4.Gui.KissMemoEdit();
            this.lblMessungZielerreichungVerl = new KiSS4.Gui.KissLabel();
            this.memFeinzielVerl = new KiSS4.Gui.KissMemoEdit();
            this.lblFeinzielVerl = new KiSS4.Gui.KissLabel();
            this.datFeinzielVerl = new KiSS4.Gui.KissDateEdit();
            this.grdZielvereinbVerl = new KiSS4.Gui.KissGrid();
            this.gvZielvereinbVerl = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFeinzielDatVerl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFeinzielVerl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colErreichenBisVerl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErgebnisVerl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.lblIndivZieleRAVVerl = new System.Windows.Forms.Label();
            this.docIndivZieleRAVVerl = new KiSS4.Dokument.XDokument();
            this.memIndivZieleRAVVerl = new KiSS4.Gui.KissMemoEdit();
            this.tpgInterventionen = new SharpLibrary.WinControls.TabPageEx();
            this.lblVerwNichterscheinen = new KiSS4.Gui.KissLabel();
            this.lblVerwRegelverstoss = new KiSS4.Gui.KissLabel();
            this.docVerwNichterscheinen = new KiSS4.Dokument.XDokument();
            this.docVerwRegelverstoss = new KiSS4.Dokument.XDokument();
            this.lblAufforderung = new KiSS4.Gui.KissLabel();
            this.lblVereinbarung = new KiSS4.Gui.KissLabel();
            this.lblProgAbbruch = new KiSS4.Gui.KissLabel();
            this.docProgAbbruch = new KiSS4.Dokument.XDokument();
            this.docVereinbarung2 = new KiSS4.Dokument.XDokument();
            this.docVereinbarung1 = new KiSS4.Dokument.XDokument();
            this.docAufforderung3 = new KiSS4.Dokument.XDokument();
            this.docAufforderung2 = new KiSS4.Dokument.XDokument();
            this.docAufforderung1 = new KiSS4.Dokument.XDokument();
            this.memMuendAufford2 = new KiSS4.Gui.KissMemoEdit();
            this.datMuendAufford2 = new KiSS4.Gui.KissDateEdit();
            this.memMuendAufford1 = new KiSS4.Gui.KissMemoEdit();
            this.lblMuendAufforderung = new KiSS4.Gui.KissLabel();
            this.datMuendAufford1 = new KiSS4.Gui.KissDateEdit();
            this.tpgAustritt = new SharpLibrary.WinControls.TabPageEx();
            this.lblAustrittBem = new KiSS4.Gui.KissLabel();
            this.lblGrund = new KiSS4.Gui.KissLabel();
            this.lblAustrittDatum = new KiSS4.Gui.KissLabel();
            this.btnReset = new KiSS4.Gui.KissButton();
            this.memAustrittBem = new KiSS4.Gui.KissMemoEdit();
            this.ddlGrund = new KiSS4.Gui.KissLookUpEdit();
            this.rgGrund = new KiSS4.Gui.KissRadioGroup(this.components);
            this.datAustrittDatum = new KiSS4.Gui.KissDateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAnweisung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datEintritt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEintritt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datAustritt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAustritt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeschGrad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProzent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeschGrad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRavBerater.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRAVBerater)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCoach.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCoach)).BeginInit();
            this.pnlTitle.SuspendLayout();
            this.pnlHead.SuspendLayout();
            this.tabControlEPQ.SuspendLayout();
            this.tpgProzessuebersicht.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.docVerlaengerung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryEPQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVerlaengerung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZwischenzeugnis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docZwischenzeugnis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblArbeitszeugnis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docArbeitszeugnis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datVerlaengerung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerlängerung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZwischenbericht2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docZwischenbericht2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZielVereinb2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonalblatt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIntegBildung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryIntegBildung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvIntegBildung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datZielVereinb2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryDates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZielVereinb1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datZielVereinb1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docTaetigProg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docPrzStandortBestimmung2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docPrzStandortBestimmung1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docPersonalblatt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSchlussbericht2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docSchlussbericht2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSchlussbericht1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docSchlussbericht1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZwischenbericht1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docZwischenbericht1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStaoDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datStaoDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTaetigProg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPrzStandortBestimmung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVerlauf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVerlauf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvVerlauf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            this.tpgIntake.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.docIntakeVorstellungsgespraech.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIntakeVorstellungsgespraech)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProgBeginn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chlIntakeCodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docEinladungProgBeginn2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docEinladungProgBeginn1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docAntwortAnbieter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAntwortAnbieter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinladugProgBeginn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memBemerkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgProgBeginn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgProgBeginn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docEinladung2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docEinladung1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datEinladung2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinladung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datEinladung1.Properties)).BeginInit();
            this.tpgZielVereinbarung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtErreichenBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZielvereinb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErreichenBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memErgebnis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErgebnis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memMessungZielerreichung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMessungZielerreichung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memFeinziel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFeinziel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFeinziel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZielvereinb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvZielvereinb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docIndivZieleRAV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memIndivZieleRAV.Properties)).BeginInit();
            this.tpgZielVereinbarungVerl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtErreichenBisVerl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZielvereinbVerl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErreichenBisVerl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memErgebnisVerl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErgebnisVerl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memMessungZielerreichungVerl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMessungZielerreichungVerl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memFeinzielVerl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFeinzielVerl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFeinzielVerl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZielvereinbVerl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvZielvereinbVerl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docIndivZieleRAVVerl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memIndivZieleRAVVerl.Properties)).BeginInit();
            this.tpgInterventionen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwNichterscheinen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwRegelverstoss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docVerwNichterscheinen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docVerwRegelverstoss.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAufforderung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVereinbarung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProgAbbruch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docProgAbbruch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docVereinbarung2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docVereinbarung1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docAufforderung3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docAufforderung2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docAufforderung1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memMuendAufford2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datMuendAufford2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memMuendAufford1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMuendAufforderung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datMuendAufford1.Properties)).BeginInit();
            this.tpgAustritt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblAustrittBem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAustrittDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memAustrittBem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlGrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlGrund.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgGrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgGrund.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datAustrittDatum.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // picTitle
            // 
            this.picTitle.Image = ((System.Drawing.Image)(resources.GetObject("picTitle.Image")));
            this.picTitle.Location = new System.Drawing.Point(10, 9);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(25, 20);
            this.picTitle.TabIndex = 101;
            this.picTitle.TabStop = false;
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblTitel.ForeColor = System.Drawing.Color.Black;
            this.lblTitel.Location = new System.Drawing.Point(35, 10);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(31, 15);
            this.lblTitel.TabIndex = 102;
            this.lblTitel.Text = "Titel";
            // 
            // qryAnweisung
            // 
            this.qryAnweisung.HostControl = this;
            this.qryAnweisung.IsIdentityInsert = false;
            this.qryAnweisung.TableName = "KaEinsatz";
            // 
            // datEintritt
            // 
            this.datEintritt.DataMember = "DatumVon";
            this.datEintritt.DataSource = this.qryAnweisung;
            this.datEintritt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.datEintritt.EditValue = null;
            this.datEintritt.Location = new System.Drawing.Point(80, 15);
            this.datEintritt.Name = "datEintritt";
            this.datEintritt.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datEintritt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.datEintritt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datEintritt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datEintritt.Properties.Appearance.Options.UseBackColor = true;
            this.datEintritt.Properties.Appearance.Options.UseBorderColor = true;
            this.datEintritt.Properties.Appearance.Options.UseFont = true;
            this.datEintritt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject71.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject71.Options.UseBackColor = true;
            this.datEintritt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, false, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datEintritt.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject71)});
            this.datEintritt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datEintritt.Properties.ReadOnly = true;
            this.datEintritt.Properties.ShowToday = false;
            this.datEintritt.Size = new System.Drawing.Size(89, 24);
            this.datEintritt.TabIndex = 579;
            // 
            // lblEintritt
            // 
            this.lblEintritt.Location = new System.Drawing.Point(10, 15);
            this.lblEintritt.Name = "lblEintritt";
            this.lblEintritt.Size = new System.Drawing.Size(50, 24);
            this.lblEintritt.TabIndex = 578;
            this.lblEintritt.Text = "Eintritt";
            // 
            // datAustritt
            // 
            this.datAustritt.DataMember = "DatumBis";
            this.datAustritt.DataSource = this.qryAnweisung;
            this.datAustritt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.datAustritt.EditValue = null;
            this.datAustritt.Location = new System.Drawing.Point(289, 15);
            this.datAustritt.Name = "datAustritt";
            this.datAustritt.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datAustritt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.datAustritt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datAustritt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datAustritt.Properties.Appearance.Options.UseBackColor = true;
            this.datAustritt.Properties.Appearance.Options.UseBorderColor = true;
            this.datAustritt.Properties.Appearance.Options.UseFont = true;
            this.datAustritt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject72.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject72.Options.UseBackColor = true;
            this.datAustritt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, false, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datAustritt.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject72)});
            this.datAustritt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datAustritt.Properties.ReadOnly = true;
            this.datAustritt.Properties.ShowToday = false;
            this.datAustritt.Size = new System.Drawing.Size(89, 24);
            this.datAustritt.TabIndex = 581;
            // 
            // lblAustritt
            // 
            this.lblAustritt.Location = new System.Drawing.Point(185, 15);
            this.lblAustritt.Name = "lblAustritt";
            this.lblAustritt.Size = new System.Drawing.Size(101, 24);
            this.lblAustritt.TabIndex = 580;
            this.lblAustritt.Text = "Ende Anweisung";
            // 
            // edtBeschGrad
            // 
            this.edtBeschGrad.DataMember = "BeschGrad";
            this.edtBeschGrad.DataSource = this.qryAnweisung;
            this.edtBeschGrad.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBeschGrad.Location = new System.Drawing.Point(507, 15);
            this.edtBeschGrad.Name = "edtBeschGrad";
            this.edtBeschGrad.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBeschGrad.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBeschGrad.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBeschGrad.Properties.Appearance.Options.UseBackColor = true;
            this.edtBeschGrad.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBeschGrad.Properties.Appearance.Options.UseFont = true;
            this.edtBeschGrad.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBeschGrad.Properties.ReadOnly = true;
            this.edtBeschGrad.Size = new System.Drawing.Size(38, 24);
            this.edtBeschGrad.TabIndex = 582;
            // 
            // lblProzent
            // 
            this.lblProzent.Location = new System.Drawing.Point(547, 15);
            this.lblProzent.Name = "lblProzent";
            this.lblProzent.Size = new System.Drawing.Size(16, 24);
            this.lblProzent.TabIndex = 584;
            this.lblProzent.Text = "%";
            // 
            // lblBeschGrad
            // 
            this.lblBeschGrad.Location = new System.Drawing.Point(387, 15);
            this.lblBeschGrad.Name = "lblBeschGrad";
            this.lblBeschGrad.Size = new System.Drawing.Size(111, 24);
            this.lblBeschGrad.TabIndex = 583;
            this.lblBeschGrad.Text = "Beschäftigungsgrad";
            // 
            // edtTelefon
            // 
            this.edtTelefon.DataMember = "Tel";
            this.edtTelefon.DataSource = this.qryAnweisung;
            this.edtTelefon.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtTelefon.Location = new System.Drawing.Point(670, 15);
            this.edtTelefon.Name = "edtTelefon";
            this.edtTelefon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtTelefon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTelefon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTelefon.Properties.Appearance.Options.UseBackColor = true;
            this.edtTelefon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTelefon.Properties.Appearance.Options.UseFont = true;
            this.edtTelefon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTelefon.Properties.ReadOnly = true;
            this.edtTelefon.Size = new System.Drawing.Size(310, 24);
            this.edtTelefon.TabIndex = 585;
            // 
            // lblTelefon
            // 
            this.lblTelefon.Location = new System.Drawing.Point(590, 15);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new System.Drawing.Size(85, 24);
            this.lblTelefon.TabIndex = 586;
            this.lblTelefon.Text = "Telefon Klient";
            // 
            // edtRavBerater
            // 
            this.edtRavBerater.DataMember = "ZuweiserAnzeige";
            this.edtRavBerater.DataSource = this.qryAnweisung;
            this.edtRavBerater.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtRavBerater.Location = new System.Drawing.Point(80, 45);
            this.edtRavBerater.Name = "edtRavBerater";
            this.edtRavBerater.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtRavBerater.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtRavBerater.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtRavBerater.Properties.Appearance.Options.UseBackColor = true;
            this.edtRavBerater.Properties.Appearance.Options.UseBorderColor = true;
            this.edtRavBerater.Properties.Appearance.Options.UseFont = true;
            this.edtRavBerater.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtRavBerater.Properties.ReadOnly = true;
            this.edtRavBerater.Size = new System.Drawing.Size(483, 24);
            this.edtRavBerater.TabIndex = 587;
            // 
            // lblRAVBerater
            // 
            this.lblRAVBerater.Location = new System.Drawing.Point(10, 45);
            this.lblRAVBerater.Name = "lblRAVBerater";
            this.lblRAVBerater.Size = new System.Drawing.Size(65, 24);
            this.lblRAVBerater.TabIndex = 588;
            this.lblRAVBerater.Text = "RAV Berater";
            // 
            // edtCoach
            // 
            this.edtCoach.DataMember = "Coach";
            this.edtCoach.DataSource = this.qryAnweisung;
            this.edtCoach.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtCoach.Location = new System.Drawing.Point(670, 45);
            this.edtCoach.Name = "edtCoach";
            this.edtCoach.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtCoach.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtCoach.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtCoach.Properties.Appearance.Options.UseBackColor = true;
            this.edtCoach.Properties.Appearance.Options.UseBorderColor = true;
            this.edtCoach.Properties.Appearance.Options.UseFont = true;
            this.edtCoach.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtCoach.Properties.ReadOnly = true;
            this.edtCoach.Size = new System.Drawing.Size(250, 24);
            this.edtCoach.TabIndex = 589;
            // 
            // lblCoach
            // 
            this.lblCoach.Location = new System.Drawing.Point(595, 45);
            this.lblCoach.Name = "lblCoach";
            this.lblCoach.Size = new System.Drawing.Size(50, 24);
            this.lblCoach.TabIndex = 590;
            this.lblCoach.Text = "Coach";
            // 
            // pnlTitle
            // 
            this.pnlTitle.Controls.Add(this.lblTitel);
            this.pnlTitle.Controls.Add(this.picTitle);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(990, 35);
            this.pnlTitle.TabIndex = 591;
            // 
            // pnlHead
            // 
            this.pnlHead.Controls.Add(this.lblEintritt);
            this.pnlHead.Controls.Add(this.edtTelefon);
            this.pnlHead.Controls.Add(this.lblTelefon);
            this.pnlHead.Controls.Add(this.lblBeschGrad);
            this.pnlHead.Controls.Add(this.lblRAVBerater);
            this.pnlHead.Controls.Add(this.edtBeschGrad);
            this.pnlHead.Controls.Add(this.lblProzent);
            this.pnlHead.Controls.Add(this.datAustritt);
            this.pnlHead.Controls.Add(this.lblCoach);
            this.pnlHead.Controls.Add(this.edtCoach);
            this.pnlHead.Controls.Add(this.edtRavBerater);
            this.pnlHead.Controls.Add(this.lblAustritt);
            this.pnlHead.Controls.Add(this.datEintritt);
            this.pnlHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHead.Location = new System.Drawing.Point(0, 35);
            this.pnlHead.Name = "pnlHead";
            this.pnlHead.Size = new System.Drawing.Size(990, 85);
            this.pnlHead.TabIndex = 592;
            // 
            // tabControlEPQ
            // 
            this.tabControlEPQ.Controls.Add(this.tpgProzessuebersicht);
            this.tabControlEPQ.Controls.Add(this.tpgIntake);
            this.tabControlEPQ.Controls.Add(this.tpgZielVereinbarung);
            this.tabControlEPQ.Controls.Add(this.tpgZielVereinbarungVerl);
            this.tabControlEPQ.Controls.Add(this.tpgInterventionen);
            this.tabControlEPQ.Controls.Add(this.tpgAustritt);
            this.tabControlEPQ.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabControlEPQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlEPQ.Location = new System.Drawing.Point(0, 120);
            this.tabControlEPQ.Name = "tabControlEPQ";
            this.tabControlEPQ.ShowFixedWidthTooltip = true;
            this.tabControlEPQ.Size = new System.Drawing.Size(990, 615);
            this.tabControlEPQ.TabIndex = 1;
            this.tabControlEPQ.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgProzessuebersicht,
            this.tpgIntake,
            this.tpgZielVereinbarung,
            this.tpgZielVereinbarungVerl,
            this.tpgInterventionen,
            this.tpgAustritt});
            this.tabControlEPQ.TabsLineColor = System.Drawing.Color.Black;
            this.tabControlEPQ.TabsLocation = SharpLibrary.WinControls.TabsLocation.Top;
            this.tabControlEPQ.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabControlEPQ.TabStop = false;
            this.tabControlEPQ.Text = "tabControlEPQ";
            this.tabControlEPQ.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControlEPQ_SelectedTabChanged);
            this.tabControlEPQ.SelectedTabChanging += new System.ComponentModel.CancelEventHandler(this.tabControlEPQ_SelectedTabChanging);
            // 
            // tpgProzessuebersicht
            // 
            this.tpgProzessuebersicht.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.tpgProzessuebersicht.Controls.Add(this.docVerlaengerung);
            this.tpgProzessuebersicht.Controls.Add(this.chkVerlaengerung);
            this.tpgProzessuebersicht.Controls.Add(this.lblZwischenzeugnis);
            this.tpgProzessuebersicht.Controls.Add(this.docZwischenzeugnis);
            this.tpgProzessuebersicht.Controls.Add(this.lblArbeitszeugnis);
            this.tpgProzessuebersicht.Controls.Add(this.docArbeitszeugnis);
            this.tpgProzessuebersicht.Controls.Add(this.datVerlaengerung);
            this.tpgProzessuebersicht.Controls.Add(this.lblVerlängerung);
            this.tpgProzessuebersicht.Controls.Add(this.lblZwischenbericht2);
            this.tpgProzessuebersicht.Controls.Add(this.docZwischenbericht2);
            this.tpgProzessuebersicht.Controls.Add(this.lblZielVereinb2);
            this.tpgProzessuebersicht.Controls.Add(this.lblPersonalblatt);
            this.tpgProzessuebersicht.Controls.Add(this.grdIntegBildung);
            this.tpgProzessuebersicht.Controls.Add(this.datZielVereinb2);
            this.tpgProzessuebersicht.Controls.Add(this.lblZielVereinb1);
            this.tpgProzessuebersicht.Controls.Add(this.datZielVereinb1);
            this.tpgProzessuebersicht.Controls.Add(this.docTaetigProg);
            this.tpgProzessuebersicht.Controls.Add(this.docPrzStandortBestimmung2);
            this.tpgProzessuebersicht.Controls.Add(this.docPrzStandortBestimmung1);
            this.tpgProzessuebersicht.Controls.Add(this.docPersonalblatt);
            this.tpgProzessuebersicht.Controls.Add(this.lblSchlussbericht2);
            this.tpgProzessuebersicht.Controls.Add(this.docSchlussbericht2);
            this.tpgProzessuebersicht.Controls.Add(this.lblSchlussbericht1);
            this.tpgProzessuebersicht.Controls.Add(this.docSchlussbericht1);
            this.tpgProzessuebersicht.Controls.Add(this.lblZwischenbericht1);
            this.tpgProzessuebersicht.Controls.Add(this.docZwischenbericht1);
            this.tpgProzessuebersicht.Controls.Add(this.lblStaoDatum);
            this.tpgProzessuebersicht.Controls.Add(this.datStaoDatum);
            this.tpgProzessuebersicht.Controls.Add(this.lblTaetigProg);
            this.tpgProzessuebersicht.Controls.Add(this.lblPrzStandortBestimmung);
            this.tpgProzessuebersicht.Controls.Add(this.btnPraesenzzeit);
            this.tpgProzessuebersicht.Controls.Add(this.grdVerlauf);
            this.tpgProzessuebersicht.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.tpgProzessuebersicht.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tpgProzessuebersicht.Location = new System.Drawing.Point(6, 32);
            this.tpgProzessuebersicht.Name = "tpgProzessuebersicht";
            this.tpgProzessuebersicht.Size = new System.Drawing.Size(978, 577);
            this.tpgProzessuebersicht.TabIndex = 0;
            this.tpgProzessuebersicht.Title = "Prozessübersicht";
            // 
            // docVerlaengerung
            // 
            this.docVerlaengerung.Context = "KaQEEPQVerlaengerung";
            this.docVerlaengerung.DataMember = "VerlaengerungDokID";
            this.docVerlaengerung.DataSource = this.qryEPQ;
            this.docVerlaengerung.Location = new System.Drawing.Point(295, 381);
            this.docVerlaengerung.Name = "docVerlaengerung";
            this.docVerlaengerung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docVerlaengerung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docVerlaengerung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docVerlaengerung.Properties.Appearance.Options.UseBackColor = true;
            this.docVerlaengerung.Properties.Appearance.Options.UseBorderColor = true;
            this.docVerlaengerung.Properties.Appearance.Options.UseFont = true;
            this.docVerlaengerung.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docVerlaengerung.Properties.AppearanceDisabled.Options.UseFont = true;
            this.docVerlaengerung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject73.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject73.Options.UseBackColor = true;
            serializableAppearanceObject74.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject74.Options.UseBackColor = true;
            serializableAppearanceObject121.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject121.Options.UseBackColor = true;
            serializableAppearanceObject122.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject122.Options.UseBackColor = true;
            this.docVerlaengerung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docVerlaengerung.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject73, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docVerlaengerung.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject74, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docVerlaengerung.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject121, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docVerlaengerung.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject122, "Dokument importieren")});
            this.docVerlaengerung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docVerlaengerung.Properties.ReadOnly = true;
            this.docVerlaengerung.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docVerlaengerung.Size = new System.Drawing.Size(136, 24);
            this.docVerlaengerung.TabIndex = 21;
            // 
            // qryEPQ
            // 
            this.qryEPQ.AutoApplyUserRights = false;
            this.qryEPQ.CanUpdate = true;
            this.qryEPQ.HostControl = this;
            this.qryEPQ.IsIdentityInsert = false;
            this.qryEPQ.TableName = "KaQEEPQ";
            this.qryEPQ.AfterPost += new System.EventHandler(this.qryEPQ_AfterPost);
            this.qryEPQ.BeforePost += new System.EventHandler(this.qryEPQ_BeforePost);
            // 
            // chkVerlaengerung
            // 
            this.chkVerlaengerung.DataMember = "VerlaengerungFlag";
            this.chkVerlaengerung.DataSource = this.qryEPQ;
            this.chkVerlaengerung.Location = new System.Drawing.Point(160, 381);
            this.chkVerlaengerung.Name = "chkVerlaengerung";
            this.chkVerlaengerung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkVerlaengerung.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.chkVerlaengerung.Properties.Appearance.Options.UseBackColor = true;
            this.chkVerlaengerung.Properties.Appearance.Options.UseForeColor = true;
            this.chkVerlaengerung.Properties.Caption = "";
            this.chkVerlaengerung.Size = new System.Drawing.Size(20, 19);
            this.chkVerlaengerung.TabIndex = 19;
            // 
            // lblZwischenzeugnis
            // 
            this.lblZwischenzeugnis.Location = new System.Drawing.Point(15, 501);
            this.lblZwischenzeugnis.Name = "lblZwischenzeugnis";
            this.lblZwischenzeugnis.Size = new System.Drawing.Size(130, 24);
            this.lblZwischenzeugnis.TabIndex = 28;
            this.lblZwischenzeugnis.Text = "Zwischenzeugnis";
            // 
            // docZwischenzeugnis
            // 
            this.docZwischenzeugnis.Context = "KaQEEPQZwischenzeugnis";
            this.docZwischenzeugnis.DataMember = "ZwischenzeugnisDokID";
            this.docZwischenzeugnis.DataSource = this.qryEPQ;
            this.docZwischenzeugnis.Location = new System.Drawing.Point(150, 501);
            this.docZwischenzeugnis.Name = "docZwischenzeugnis";
            this.docZwischenzeugnis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docZwischenzeugnis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docZwischenzeugnis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docZwischenzeugnis.Properties.Appearance.Options.UseBackColor = true;
            this.docZwischenzeugnis.Properties.Appearance.Options.UseBorderColor = true;
            this.docZwischenzeugnis.Properties.Appearance.Options.UseFont = true;
            this.docZwischenzeugnis.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docZwischenzeugnis.Properties.AppearanceDisabled.Options.UseFont = true;
            this.docZwischenzeugnis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.docZwischenzeugnis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docZwischenzeugnis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docZwischenzeugnis.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docZwischenzeugnis.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docZwischenzeugnis.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "Dokument importieren")});
            this.docZwischenzeugnis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docZwischenzeugnis.Properties.ReadOnly = true;
            this.docZwischenzeugnis.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docZwischenzeugnis.Size = new System.Drawing.Size(136, 24);
            this.docZwischenzeugnis.TabIndex = 29;
            // 
            // lblArbeitszeugnis
            // 
            this.lblArbeitszeugnis.Location = new System.Drawing.Point(15, 471);
            this.lblArbeitszeugnis.Name = "lblArbeitszeugnis";
            this.lblArbeitszeugnis.Size = new System.Drawing.Size(115, 24);
            this.lblArbeitszeugnis.TabIndex = 26;
            this.lblArbeitszeugnis.Text = "Arbeitszeugnis";
            // 
            // docArbeitszeugnis
            // 
            this.docArbeitszeugnis.Context = "KaQEEPQArbeitszeugnis";
            this.docArbeitszeugnis.DataMember = "ArbeitszeugnisDokID";
            this.docArbeitszeugnis.DataSource = this.qryEPQ;
            this.docArbeitszeugnis.Location = new System.Drawing.Point(150, 471);
            this.docArbeitszeugnis.Name = "docArbeitszeugnis";
            this.docArbeitszeugnis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docArbeitszeugnis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docArbeitszeugnis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docArbeitszeugnis.Properties.Appearance.Options.UseBackColor = true;
            this.docArbeitszeugnis.Properties.Appearance.Options.UseBorderColor = true;
            this.docArbeitszeugnis.Properties.Appearance.Options.UseFont = true;
            this.docArbeitszeugnis.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docArbeitszeugnis.Properties.AppearanceDisabled.Options.UseFont = true;
            this.docArbeitszeugnis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.docArbeitszeugnis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docArbeitszeugnis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docArbeitszeugnis.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docArbeitszeugnis.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docArbeitszeugnis.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8, "Dokument importieren")});
            this.docArbeitszeugnis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docArbeitszeugnis.Properties.ReadOnly = true;
            this.docArbeitszeugnis.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docArbeitszeugnis.Size = new System.Drawing.Size(136, 24);
            this.docArbeitszeugnis.TabIndex = 27;
            // 
            // datVerlaengerung
            // 
            this.datVerlaengerung.DataMember = "VerlaengerungDat";
            this.datVerlaengerung.DataSource = this.qryEPQ;
            this.datVerlaengerung.EditValue = null;
            this.datVerlaengerung.Location = new System.Drawing.Point(195, 381);
            this.datVerlaengerung.Name = "datVerlaengerung";
            this.datVerlaengerung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datVerlaengerung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.datVerlaengerung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datVerlaengerung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datVerlaengerung.Properties.Appearance.Options.UseBackColor = true;
            this.datVerlaengerung.Properties.Appearance.Options.UseBorderColor = true;
            this.datVerlaengerung.Properties.Appearance.Options.UseFont = true;
            this.datVerlaengerung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.datVerlaengerung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datVerlaengerung.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.datVerlaengerung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datVerlaengerung.Properties.ShowToday = false;
            this.datVerlaengerung.Size = new System.Drawing.Size(91, 24);
            this.datVerlaengerung.TabIndex = 20;
            // 
            // lblVerlängerung
            // 
            this.lblVerlängerung.Location = new System.Drawing.Point(15, 381);
            this.lblVerlängerung.Name = "lblVerlängerung";
            this.lblVerlängerung.Size = new System.Drawing.Size(115, 24);
            this.lblVerlängerung.TabIndex = 18;
            this.lblVerlängerung.Text = "Verlängerung";
            // 
            // lblZwischenbericht2
            // 
            this.lblZwischenbericht2.Location = new System.Drawing.Point(15, 351);
            this.lblZwischenbericht2.Name = "lblZwischenbericht2";
            this.lblZwischenbericht2.Size = new System.Drawing.Size(115, 24);
            this.lblZwischenbericht2.TabIndex = 16;
            this.lblZwischenbericht2.Text = "Zwischenbericht 2";
            // 
            // docZwischenbericht2
            // 
            this.docZwischenbericht2.Context = "KaQEEPQZwischenbericht";
            this.docZwischenbericht2.DataMember = "ZwBericht2DokID";
            this.docZwischenbericht2.DataSource = this.qryEPQ;
            this.docZwischenbericht2.Location = new System.Drawing.Point(150, 351);
            this.docZwischenbericht2.Name = "docZwischenbericht2";
            this.docZwischenbericht2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docZwischenbericht2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docZwischenbericht2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docZwischenbericht2.Properties.Appearance.Options.UseBackColor = true;
            this.docZwischenbericht2.Properties.Appearance.Options.UseBorderColor = true;
            this.docZwischenbericht2.Properties.Appearance.Options.UseFont = true;
            this.docZwischenbericht2.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docZwischenbericht2.Properties.AppearanceDisabled.Options.UseFont = true;
            this.docZwischenbericht2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            serializableAppearanceObject13.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject13.Options.UseBackColor = true;
            this.docZwischenbericht2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docZwischenbericht2.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docZwischenbericht2.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docZwischenbericht2.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docZwischenbericht2.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13, "Dokument importieren")});
            this.docZwischenbericht2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docZwischenbericht2.Properties.ReadOnly = true;
            this.docZwischenbericht2.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docZwischenbericht2.Size = new System.Drawing.Size(136, 24);
            this.docZwischenbericht2.TabIndex = 17;
            // 
            // lblZielVereinb2
            // 
            this.lblZielVereinb2.Location = new System.Drawing.Point(15, 291);
            this.lblZielVereinb2.Name = "lblZielVereinb2";
            this.lblZielVereinb2.Size = new System.Drawing.Size(120, 24);
            this.lblZielVereinb2.TabIndex = 12;
            this.lblZielVereinb2.Text = "Zielvereinbarung 2";
            // 
            // lblPersonalblatt
            // 
            this.lblPersonalblatt.Location = new System.Drawing.Point(15, 231);
            this.lblPersonalblatt.Name = "lblPersonalblatt";
            this.lblPersonalblatt.Size = new System.Drawing.Size(110, 24);
            this.lblPersonalblatt.TabIndex = 8;
            this.lblPersonalblatt.Text = "Personalblatt";
            // 
            // grdIntegBildung
            // 
            this.grdIntegBildung.DataSource = this.qryIntegBildung;
            // 
            // 
            // 
            this.grdIntegBildung.EmbeddedNavigator.Name = "";
            this.grdIntegBildung.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdIntegBildung.Location = new System.Drawing.Point(567, 291);
            this.grdIntegBildung.MainView = this.gvIntegBildung;
            this.grdIntegBildung.Name = "grdIntegBildung";
            this.grdIntegBildung.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit2});
            this.grdIntegBildung.Size = new System.Drawing.Size(403, 234);
            this.grdIntegBildung.TabIndex = 31;
            this.grdIntegBildung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvIntegBildung});
            // 
            // qryIntegBildung
            // 
            this.qryIntegBildung.HostControl = this;
            this.qryIntegBildung.IsIdentityInsert = false;
            this.qryIntegBildung.TableName = "KaEPQ";
            // 
            // gvIntegBildung
            // 
            this.gvIntegBildung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gvIntegBildung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvIntegBildung.Appearance.Empty.Options.UseBackColor = true;
            this.gvIntegBildung.Appearance.Empty.Options.UseFont = true;
            this.gvIntegBildung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvIntegBildung.Appearance.EvenRow.Options.UseFont = true;
            this.gvIntegBildung.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvIntegBildung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvIntegBildung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gvIntegBildung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvIntegBildung.Appearance.FocusedCell.Options.UseFont = true;
            this.gvIntegBildung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvIntegBildung.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvIntegBildung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvIntegBildung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gvIntegBildung.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvIntegBildung.Appearance.FocusedRow.Options.UseFont = true;
            this.gvIntegBildung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvIntegBildung.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.gvIntegBildung.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.gvIntegBildung.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gvIntegBildung.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gvIntegBildung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gvIntegBildung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gvIntegBildung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gvIntegBildung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvIntegBildung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvIntegBildung.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvIntegBildung.Appearance.GroupRow.Options.UseFont = true;
            this.gvIntegBildung.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvIntegBildung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gvIntegBildung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gvIntegBildung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvIntegBildung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvIntegBildung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gvIntegBildung.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvIntegBildung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gvIntegBildung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvIntegBildung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvIntegBildung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvIntegBildung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvIntegBildung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvIntegBildung.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gvIntegBildung.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvIntegBildung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvIntegBildung.Appearance.OddRow.Options.UseFont = true;
            this.gvIntegBildung.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gvIntegBildung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvIntegBildung.Appearance.Row.Options.UseBackColor = true;
            this.gvIntegBildung.Appearance.Row.Options.UseFont = true;
            this.gvIntegBildung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvIntegBildung.Appearance.SelectedRow.Options.UseFont = true;
            this.gvIntegBildung.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gvIntegBildung.Appearance.VertLine.Options.UseBackColor = true;
            this.gvIntegBildung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gvIntegBildung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBildung});
            this.gvIntegBildung.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gvIntegBildung.GridControl = this.grdIntegBildung;
            this.gvIntegBildung.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.gvIntegBildung.Name = "gvIntegBildung";
            this.gvIntegBildung.OptionsBehavior.Editable = false;
            this.gvIntegBildung.OptionsCustomization.AllowFilter = false;
            this.gvIntegBildung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gvIntegBildung.OptionsNavigation.AutoFocusNewRow = true;
            this.gvIntegBildung.OptionsNavigation.UseTabKey = false;
            this.gvIntegBildung.OptionsView.ColumnAutoWidth = false;
            this.gvIntegBildung.OptionsView.RowAutoHeight = true;
            this.gvIntegBildung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvIntegBildung.OptionsView.ShowGroupPanel = false;
            this.gvIntegBildung.OptionsView.ShowIndicator = false;
            // 
            // colBildung
            // 
            this.colBildung.Caption = "Integrierte Bildung";
            this.colBildung.FieldName = "KursDetail";
            this.colBildung.Name = "colBildung";
            this.colBildung.Visible = true;
            this.colBildung.VisibleIndex = 0;
            this.colBildung.Width = 350;
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            this.repositoryItemMemoEdit2.ReadOnly = true;
            // 
            // datZielVereinb2
            // 
            this.datZielVereinb2.DataMember = "ZielDate2";
            this.datZielVereinb2.DataSource = this.qryDates;
            this.datZielVereinb2.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.datZielVereinb2.EditValue = null;
            this.datZielVereinb2.Location = new System.Drawing.Point(150, 291);
            this.datZielVereinb2.Name = "datZielVereinb2";
            this.datZielVereinb2.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datZielVereinb2.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.datZielVereinb2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datZielVereinb2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datZielVereinb2.Properties.Appearance.Options.UseBackColor = true;
            this.datZielVereinb2.Properties.Appearance.Options.UseBorderColor = true;
            this.datZielVereinb2.Properties.Appearance.Options.UseFont = true;
            this.datZielVereinb2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject14.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject14.Options.UseBackColor = true;
            this.datZielVereinb2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, false, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datZielVereinb2.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject14)});
            this.datZielVereinb2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datZielVereinb2.Properties.ReadOnly = true;
            this.datZielVereinb2.Properties.ShowToday = false;
            this.datZielVereinb2.Size = new System.Drawing.Size(89, 24);
            this.datZielVereinb2.TabIndex = 13;
            // 
            // qryDates
            // 
            this.qryDates.HostControl = this;
            this.qryDates.IsIdentityInsert = false;
            this.qryDates.TableName = "KaQEEPQZielvereinb";
            // 
            // lblZielVereinb1
            // 
            this.lblZielVereinb1.Location = new System.Drawing.Point(15, 261);
            this.lblZielVereinb1.Name = "lblZielVereinb1";
            this.lblZielVereinb1.Size = new System.Drawing.Size(120, 24);
            this.lblZielVereinb1.TabIndex = 10;
            this.lblZielVereinb1.Text = "Zielvereinbarung 1";
            // 
            // datZielVereinb1
            // 
            this.datZielVereinb1.DataMember = "ZielDate1";
            this.datZielVereinb1.DataSource = this.qryDates;
            this.datZielVereinb1.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.datZielVereinb1.EditValue = null;
            this.datZielVereinb1.Location = new System.Drawing.Point(150, 261);
            this.datZielVereinb1.Name = "datZielVereinb1";
            this.datZielVereinb1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datZielVereinb1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.datZielVereinb1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datZielVereinb1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datZielVereinb1.Properties.Appearance.Options.UseBackColor = true;
            this.datZielVereinb1.Properties.Appearance.Options.UseBorderColor = true;
            this.datZielVereinb1.Properties.Appearance.Options.UseFont = true;
            this.datZielVereinb1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject15.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject15.Options.UseBackColor = true;
            this.datZielVereinb1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, false, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datZielVereinb1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject15)});
            this.datZielVereinb1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datZielVereinb1.Properties.ReadOnly = true;
            this.datZielVereinb1.Properties.ShowToday = false;
            this.datZielVereinb1.Size = new System.Drawing.Size(89, 24);
            this.datZielVereinb1.TabIndex = 11;
            // 
            // docTaetigProg
            // 
            this.docTaetigProg.Context = "KaQEEPQTaetigProgramm";
            this.docTaetigProg.DataMember = "TaetigProgrammDokID";
            this.docTaetigProg.DataSource = this.qryEPQ;
            this.docTaetigProg.Location = new System.Drawing.Point(150, 201);
            this.docTaetigProg.Name = "docTaetigProg";
            this.docTaetigProg.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docTaetigProg.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docTaetigProg.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docTaetigProg.Properties.Appearance.Options.UseBackColor = true;
            this.docTaetigProg.Properties.Appearance.Options.UseBorderColor = true;
            this.docTaetigProg.Properties.Appearance.Options.UseFont = true;
            this.docTaetigProg.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docTaetigProg.Properties.AppearanceDisabled.Options.UseFont = true;
            this.docTaetigProg.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject16.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject16.Options.UseBackColor = true;
            serializableAppearanceObject17.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject17.Options.UseBackColor = true;
            serializableAppearanceObject18.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject18.Options.UseBackColor = true;
            serializableAppearanceObject19.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject19.Options.UseBackColor = true;
            this.docTaetigProg.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docTaetigProg.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject16, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docTaetigProg.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject17, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docTaetigProg.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject18, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docTaetigProg.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject19, "Dokument importieren")});
            this.docTaetigProg.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docTaetigProg.Properties.ReadOnly = true;
            this.docTaetigProg.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docTaetigProg.Size = new System.Drawing.Size(136, 24);
            this.docTaetigProg.TabIndex = 7;
            // 
            // docPrzStandortBestimmung2
            // 
            this.docPrzStandortBestimmung2.Context = "KaQEEPQStandortbestimmung2";
            this.docPrzStandortBestimmung2.DataMember = "XDocumentID_Standortbestimmung2";
            this.docPrzStandortBestimmung2.DataSource = this.qryEPQ;
            this.docPrzStandortBestimmung2.Location = new System.Drawing.Point(418, 171);
            this.docPrzStandortBestimmung2.Name = "docPrzStandortBestimmung2";
            this.docPrzStandortBestimmung2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docPrzStandortBestimmung2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docPrzStandortBestimmung2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docPrzStandortBestimmung2.Properties.Appearance.Options.UseBackColor = true;
            this.docPrzStandortBestimmung2.Properties.Appearance.Options.UseBorderColor = true;
            this.docPrzStandortBestimmung2.Properties.Appearance.Options.UseFont = true;
            this.docPrzStandortBestimmung2.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docPrzStandortBestimmung2.Properties.AppearanceDisabled.Options.UseFont = true;
            this.docPrzStandortBestimmung2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject20.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject20.Options.UseBackColor = true;
            serializableAppearanceObject21.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject21.Options.UseBackColor = true;
            serializableAppearanceObject22.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject22.Options.UseBackColor = true;
            serializableAppearanceObject23.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject23.Options.UseBackColor = true;
            this.docPrzStandortBestimmung2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docPrzStandortBestimmung2.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject20, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docPrzStandortBestimmung2.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject21, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docPrzStandortBestimmung2.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject22, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docPrzStandortBestimmung2.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject23, "Dokument importieren")});
            this.docPrzStandortBestimmung2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docPrzStandortBestimmung2.Properties.ReadOnly = true;
            this.docPrzStandortBestimmung2.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docPrzStandortBestimmung2.Size = new System.Drawing.Size(136, 24);
            this.docPrzStandortBestimmung2.TabIndex = 5;
            // 
            // docPrzStandortBestimmung1
            // 
            this.docPrzStandortBestimmung1.Context = "KaQEEPQStandortbestimmung1";
            this.docPrzStandortBestimmung1.DataMember = "XDocumentID_Standortbestimmung1";
            this.docPrzStandortBestimmung1.DataSource = this.qryEPQ;
            this.docPrzStandortBestimmung1.Location = new System.Drawing.Point(418, 141);
            this.docPrzStandortBestimmung1.Name = "docPrzStandortBestimmung1";
            this.docPrzStandortBestimmung1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docPrzStandortBestimmung1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docPrzStandortBestimmung1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docPrzStandortBestimmung1.Properties.Appearance.Options.UseBackColor = true;
            this.docPrzStandortBestimmung1.Properties.Appearance.Options.UseBorderColor = true;
            this.docPrzStandortBestimmung1.Properties.Appearance.Options.UseFont = true;
            this.docPrzStandortBestimmung1.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docPrzStandortBestimmung1.Properties.AppearanceDisabled.Options.UseFont = true;
            this.docPrzStandortBestimmung1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject24.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject24.Options.UseBackColor = true;
            serializableAppearanceObject25.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject25.Options.UseBackColor = true;
            serializableAppearanceObject26.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject26.Options.UseBackColor = true;
            serializableAppearanceObject27.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject27.Options.UseBackColor = true;
            this.docPrzStandortBestimmung1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docPrzStandortBestimmung1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject24, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docPrzStandortBestimmung1.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject25, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docPrzStandortBestimmung1.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject26, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docPrzStandortBestimmung1.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject27, "Dokument importieren")});
            this.docPrzStandortBestimmung1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docPrzStandortBestimmung1.Properties.ReadOnly = true;
            this.docPrzStandortBestimmung1.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docPrzStandortBestimmung1.Size = new System.Drawing.Size(136, 24);
            this.docPrzStandortBestimmung1.TabIndex = 4;
            // 
            // docPersonalblatt
            // 
            this.docPersonalblatt.Context = "KaQEEPQPersonalblatt";
            this.docPersonalblatt.DataMember = "PersonalblattDokID";
            this.docPersonalblatt.DataSource = this.qryEPQ;
            this.docPersonalblatt.Location = new System.Drawing.Point(150, 231);
            this.docPersonalblatt.Name = "docPersonalblatt";
            this.docPersonalblatt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docPersonalblatt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docPersonalblatt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docPersonalblatt.Properties.Appearance.Options.UseBackColor = true;
            this.docPersonalblatt.Properties.Appearance.Options.UseBorderColor = true;
            this.docPersonalblatt.Properties.Appearance.Options.UseFont = true;
            this.docPersonalblatt.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docPersonalblatt.Properties.AppearanceDisabled.Options.UseFont = true;
            this.docPersonalblatt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject28.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject28.Options.UseBackColor = true;
            serializableAppearanceObject29.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject29.Options.UseBackColor = true;
            serializableAppearanceObject30.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject30.Options.UseBackColor = true;
            serializableAppearanceObject31.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject31.Options.UseBackColor = true;
            this.docPersonalblatt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docPersonalblatt.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject28, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docPersonalblatt.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject29, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docPersonalblatt.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject30, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docPersonalblatt.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject31, "Dokument importieren")});
            this.docPersonalblatt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docPersonalblatt.Properties.ReadOnly = true;
            this.docPersonalblatt.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docPersonalblatt.Size = new System.Drawing.Size(136, 24);
            this.docPersonalblatt.TabIndex = 9;
            // 
            // lblSchlussbericht2
            // 
            this.lblSchlussbericht2.Location = new System.Drawing.Point(15, 441);
            this.lblSchlussbericht2.Name = "lblSchlussbericht2";
            this.lblSchlussbericht2.Size = new System.Drawing.Size(130, 24);
            this.lblSchlussbericht2.TabIndex = 24;
            this.lblSchlussbericht2.Text = "Schlussbericht 2";
            // 
            // docSchlussbericht2
            // 
            this.docSchlussbericht2.Context = "KaQEEPQSchlussbericht";
            this.docSchlussbericht2.DataMember = "Schlussbericht2DokID";
            this.docSchlussbericht2.DataSource = this.qryEPQ;
            this.docSchlussbericht2.Location = new System.Drawing.Point(150, 441);
            this.docSchlussbericht2.Name = "docSchlussbericht2";
            this.docSchlussbericht2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docSchlussbericht2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docSchlussbericht2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docSchlussbericht2.Properties.Appearance.Options.UseBackColor = true;
            this.docSchlussbericht2.Properties.Appearance.Options.UseBorderColor = true;
            this.docSchlussbericht2.Properties.Appearance.Options.UseFont = true;
            this.docSchlussbericht2.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docSchlussbericht2.Properties.AppearanceDisabled.Options.UseFont = true;
            this.docSchlussbericht2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject32.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject32.Options.UseBackColor = true;
            serializableAppearanceObject33.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject33.Options.UseBackColor = true;
            serializableAppearanceObject34.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject34.Options.UseBackColor = true;
            serializableAppearanceObject35.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject35.Options.UseBackColor = true;
            this.docSchlussbericht2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docSchlussbericht2.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject32, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docSchlussbericht2.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject33, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docSchlussbericht2.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject34, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docSchlussbericht2.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject35, "Dokument importieren")});
            this.docSchlussbericht2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docSchlussbericht2.Properties.ReadOnly = true;
            this.docSchlussbericht2.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docSchlussbericht2.Size = new System.Drawing.Size(136, 24);
            this.docSchlussbericht2.TabIndex = 25;
            // 
            // lblSchlussbericht1
            // 
            this.lblSchlussbericht1.Location = new System.Drawing.Point(15, 411);
            this.lblSchlussbericht1.Name = "lblSchlussbericht1";
            this.lblSchlussbericht1.Size = new System.Drawing.Size(115, 24);
            this.lblSchlussbericht1.TabIndex = 22;
            this.lblSchlussbericht1.Text = "Schlussbericht 1";
            // 
            // docSchlussbericht1
            // 
            this.docSchlussbericht1.Context = "KaQEEPQSchlussbericht";
            this.docSchlussbericht1.DataMember = "Schlussbericht1DokID";
            this.docSchlussbericht1.DataSource = this.qryEPQ;
            this.docSchlussbericht1.Location = new System.Drawing.Point(150, 411);
            this.docSchlussbericht1.Name = "docSchlussbericht1";
            this.docSchlussbericht1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docSchlussbericht1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docSchlussbericht1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docSchlussbericht1.Properties.Appearance.Options.UseBackColor = true;
            this.docSchlussbericht1.Properties.Appearance.Options.UseBorderColor = true;
            this.docSchlussbericht1.Properties.Appearance.Options.UseFont = true;
            this.docSchlussbericht1.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docSchlussbericht1.Properties.AppearanceDisabled.Options.UseFont = true;
            this.docSchlussbericht1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject36.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject36.Options.UseBackColor = true;
            serializableAppearanceObject37.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject37.Options.UseBackColor = true;
            serializableAppearanceObject38.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject38.Options.UseBackColor = true;
            serializableAppearanceObject39.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject39.Options.UseBackColor = true;
            this.docSchlussbericht1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docSchlussbericht1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject36, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docSchlussbericht1.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject37, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docSchlussbericht1.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject38, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docSchlussbericht1.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject39, "Dokument importieren")});
            this.docSchlussbericht1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docSchlussbericht1.Properties.ReadOnly = true;
            this.docSchlussbericht1.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docSchlussbericht1.Size = new System.Drawing.Size(136, 24);
            this.docSchlussbericht1.TabIndex = 23;
            // 
            // lblZwischenbericht1
            // 
            this.lblZwischenbericht1.Location = new System.Drawing.Point(15, 321);
            this.lblZwischenbericht1.Name = "lblZwischenbericht1";
            this.lblZwischenbericht1.Size = new System.Drawing.Size(115, 24);
            this.lblZwischenbericht1.TabIndex = 14;
            this.lblZwischenbericht1.Text = "Zwischenbericht 1";
            // 
            // docZwischenbericht1
            // 
            this.docZwischenbericht1.Context = "KaQEEPQZwischenbericht";
            this.docZwischenbericht1.DataMember = "ZwBericht1DokID";
            this.docZwischenbericht1.DataSource = this.qryEPQ;
            this.docZwischenbericht1.Location = new System.Drawing.Point(150, 321);
            this.docZwischenbericht1.Name = "docZwischenbericht1";
            this.docZwischenbericht1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docZwischenbericht1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docZwischenbericht1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docZwischenbericht1.Properties.Appearance.Options.UseBackColor = true;
            this.docZwischenbericht1.Properties.Appearance.Options.UseBorderColor = true;
            this.docZwischenbericht1.Properties.Appearance.Options.UseFont = true;
            this.docZwischenbericht1.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docZwischenbericht1.Properties.AppearanceDisabled.Options.UseFont = true;
            this.docZwischenbericht1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject40.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject40.Options.UseBackColor = true;
            serializableAppearanceObject41.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject41.Options.UseBackColor = true;
            serializableAppearanceObject42.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject42.Options.UseBackColor = true;
            serializableAppearanceObject43.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject43.Options.UseBackColor = true;
            this.docZwischenbericht1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docZwischenbericht1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject40, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docZwischenbericht1.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject41, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docZwischenbericht1.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject42, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docZwischenbericht1.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject43, "Dokument importieren")});
            this.docZwischenbericht1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docZwischenbericht1.Properties.ReadOnly = true;
            this.docZwischenbericht1.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docZwischenbericht1.Size = new System.Drawing.Size(136, 24);
            this.docZwischenbericht1.TabIndex = 15;
            // 
            // lblStaoDatum
            // 
            this.lblStaoDatum.Location = new System.Drawing.Point(15, 140);
            this.lblStaoDatum.Name = "lblStaoDatum";
            this.lblStaoDatum.Size = new System.Drawing.Size(115, 24);
            this.lblStaoDatum.TabIndex = 1;
            this.lblStaoDatum.Text = "Stao. Datum";
            // 
            // datStaoDatum
            // 
            this.datStaoDatum.DataMember = "StaoDat";
            this.datStaoDatum.DataSource = this.qryEPQ;
            this.datStaoDatum.EditValue = null;
            this.datStaoDatum.Location = new System.Drawing.Point(150, 140);
            this.datStaoDatum.Name = "datStaoDatum";
            this.datStaoDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datStaoDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.datStaoDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datStaoDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datStaoDatum.Properties.Appearance.Options.UseBackColor = true;
            this.datStaoDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.datStaoDatum.Properties.Appearance.Options.UseFont = true;
            this.datStaoDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject44.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject44.Options.UseBackColor = true;
            this.datStaoDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datStaoDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject44)});
            this.datStaoDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datStaoDatum.Properties.ShowToday = false;
            this.datStaoDatum.Size = new System.Drawing.Size(89, 24);
            this.datStaoDatum.TabIndex = 2;
            // 
            // lblTaetigProg
            // 
            this.lblTaetigProg.Location = new System.Drawing.Point(15, 201);
            this.lblTaetigProg.Name = "lblTaetigProg";
            this.lblTaetigProg.Size = new System.Drawing.Size(110, 24);
            this.lblTaetigProg.TabIndex = 6;
            this.lblTaetigProg.Text = "Tätigkeitsprogramm";
            // 
            // lblPrzStandortBestimmung
            // 
            this.lblPrzStandortBestimmung.Location = new System.Drawing.Point(292, 140);
            this.lblPrzStandortBestimmung.Name = "lblPrzStandortBestimmung";
            this.lblPrzStandortBestimmung.Size = new System.Drawing.Size(120, 24);
            this.lblPrzStandortBestimmung.TabIndex = 3;
            this.lblPrzStandortBestimmung.Text = "Standortbestimmung";
            // 
            // btnPraesenzzeit
            // 
            this.btnPraesenzzeit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPraesenzzeit.Location = new System.Drawing.Point(418, 231);
            this.btnPraesenzzeit.Name = "btnPraesenzzeit";
            this.btnPraesenzzeit.Size = new System.Drawing.Size(136, 24);
            this.btnPraesenzzeit.TabIndex = 30;
            this.btnPraesenzzeit.Text = "Präsenzzeit erfassen";
            this.btnPraesenzzeit.UseVisualStyleBackColor = false;
            this.btnPraesenzzeit.Click += new System.EventHandler(this.btnPraesenzzeit_Click);
            // 
            // grdVerlauf
            // 
            this.grdVerlauf.DataSource = this.qryVerlauf;
            // 
            // 
            // 
            this.grdVerlauf.EmbeddedNavigator.Name = "";
            this.grdVerlauf.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdVerlauf.Location = new System.Drawing.Point(5, 5);
            this.grdVerlauf.MainView = this.gvVerlauf;
            this.grdVerlauf.Name = "grdVerlauf";
            this.grdVerlauf.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
            this.grdVerlauf.Size = new System.Drawing.Size(965, 130);
            this.grdVerlauf.TabIndex = 0;
            this.grdVerlauf.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvVerlauf});
            // 
            // qryVerlauf
            // 
            this.qryVerlauf.HostControl = this;
            this.qryVerlauf.IsIdentityInsert = false;
            this.qryVerlauf.TableName = "KaQEEPQ";
            // 
            // gvVerlauf
            // 
            this.gvVerlauf.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gvVerlauf.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvVerlauf.Appearance.Empty.Options.UseBackColor = true;
            this.gvVerlauf.Appearance.Empty.Options.UseFont = true;
            this.gvVerlauf.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvVerlauf.Appearance.EvenRow.Options.UseFont = true;
            this.gvVerlauf.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvVerlauf.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvVerlauf.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gvVerlauf.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvVerlauf.Appearance.FocusedCell.Options.UseFont = true;
            this.gvVerlauf.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvVerlauf.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvVerlauf.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvVerlauf.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gvVerlauf.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvVerlauf.Appearance.FocusedRow.Options.UseFont = true;
            this.gvVerlauf.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvVerlauf.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.gvVerlauf.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.gvVerlauf.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gvVerlauf.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gvVerlauf.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gvVerlauf.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gvVerlauf.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gvVerlauf.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvVerlauf.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvVerlauf.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvVerlauf.Appearance.GroupRow.Options.UseFont = true;
            this.gvVerlauf.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvVerlauf.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gvVerlauf.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gvVerlauf.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvVerlauf.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvVerlauf.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gvVerlauf.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvVerlauf.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gvVerlauf.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvVerlauf.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvVerlauf.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvVerlauf.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvVerlauf.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvVerlauf.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gvVerlauf.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvVerlauf.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvVerlauf.Appearance.OddRow.Options.UseFont = true;
            this.gvVerlauf.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gvVerlauf.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvVerlauf.Appearance.Row.Options.UseBackColor = true;
            this.gvVerlauf.Appearance.Row.Options.UseFont = true;
            this.gvVerlauf.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvVerlauf.Appearance.SelectedRow.Options.UseFont = true;
            this.gvVerlauf.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gvVerlauf.Appearance.VertLine.Options.UseBackColor = true;
            this.gvVerlauf.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gvVerlauf.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatum,
            this.colKontaktpers,
            this.colStichwort,
            this.colThema,
            this.colAutor});
            this.gvVerlauf.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gvVerlauf.GridControl = this.grdVerlauf;
            this.gvVerlauf.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.gvVerlauf.Name = "gvVerlauf";
            this.gvVerlauf.OptionsBehavior.Editable = false;
            this.gvVerlauf.OptionsCustomization.AllowFilter = false;
            this.gvVerlauf.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gvVerlauf.OptionsNavigation.AutoFocusNewRow = true;
            this.gvVerlauf.OptionsNavigation.UseTabKey = false;
            this.gvVerlauf.OptionsView.ColumnAutoWidth = false;
            this.gvVerlauf.OptionsView.RowAutoHeight = true;
            this.gvVerlauf.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvVerlauf.OptionsView.ShowGroupPanel = false;
            this.gvVerlauf.OptionsView.ShowIndicator = false;
            // 
            // colDatum
            // 
            this.colDatum.Caption = "Datum";
            this.colDatum.FieldName = "Datum";
            this.colDatum.Name = "colDatum";
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 0;
            this.colDatum.Width = 80;
            // 
            // colKontaktpers
            // 
            this.colKontaktpers.Caption = "Kontaktpers.";
            this.colKontaktpers.FieldName = "Kontaktpers";
            this.colKontaktpers.Name = "colKontaktpers";
            this.colKontaktpers.Visible = true;
            this.colKontaktpers.VisibleIndex = 1;
            this.colKontaktpers.Width = 150;
            // 
            // colStichwort
            // 
            this.colStichwort.Caption = "Stichwort";
            this.colStichwort.FieldName = "Stichwort";
            this.colStichwort.Name = "colStichwort";
            this.colStichwort.Visible = true;
            this.colStichwort.VisibleIndex = 2;
            this.colStichwort.Width = 200;
            // 
            // colThema
            // 
            this.colThema.Caption = "Thema";
            this.colThema.FieldName = "Thema";
            this.colThema.Name = "colThema";
            this.colThema.Visible = true;
            this.colThema.VisibleIndex = 3;
            this.colThema.Width = 130;
            // 
            // colAutor
            // 
            this.colAutor.Caption = "Autor";
            this.colAutor.FieldName = "Autor";
            this.colAutor.Name = "colAutor";
            this.colAutor.Visible = true;
            this.colAutor.VisibleIndex = 4;
            this.colAutor.Width = 100;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            this.repositoryItemMemoEdit1.ReadOnly = true;
            // 
            // tpgIntake
            // 
            this.tpgIntake.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.tpgIntake.Controls.Add(this.docIntakeVorstellungsgespraech);
            this.tpgIntake.Controls.Add(this.lblIntakeVorstellungsgespraech);
            this.tpgIntake.Controls.Add(this.lblProgBeginn);
            this.tpgIntake.Controls.Add(this.chlIntakeCodes);
            this.tpgIntake.Controls.Add(this.lblBemerkungen);
            this.tpgIntake.Controls.Add(this.docEinladungProgBeginn2);
            this.tpgIntake.Controls.Add(this.docEinladungProgBeginn1);
            this.tpgIntake.Controls.Add(this.docAntwortAnbieter);
            this.tpgIntake.Controls.Add(this.lblAntwortAnbieter);
            this.tpgIntake.Controls.Add(this.lblEinladugProgBeginn);
            this.tpgIntake.Controls.Add(this.memBemerkungen);
            this.tpgIntake.Controls.Add(this.rgProgBeginn);
            this.tpgIntake.Controls.Add(this.docEinladung2);
            this.tpgIntake.Controls.Add(this.docEinladung1);
            this.tpgIntake.Controls.Add(this.datEinladung2);
            this.tpgIntake.Controls.Add(this.lblEinladung);
            this.tpgIntake.Controls.Add(this.datEinladung1);
            this.tpgIntake.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tpgIntake.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tpgIntake.Location = new System.Drawing.Point(6, 32);
            this.tpgIntake.Name = "tpgIntake";
            this.tpgIntake.Size = new System.Drawing.Size(978, 577);
            this.tpgIntake.TabIndex = 1;
            this.tpgIntake.Title = "Intake";
            // 
            // docIntakeVorstellungsgespraech
            // 
            this.docIntakeVorstellungsgespraech.Context = "KaQEEPQVorstellungsgespraech";
            this.docIntakeVorstellungsgespraech.DataMember = "XDocumentID_Vorstellungsgespraech";
            this.docIntakeVorstellungsgespraech.DataSource = this.qryEPQ;
            this.docIntakeVorstellungsgespraech.Location = new System.Drawing.Point(145, 256);
            this.docIntakeVorstellungsgespraech.Name = "docIntakeVorstellungsgespraech";
            this.docIntakeVorstellungsgespraech.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docIntakeVorstellungsgespraech.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docIntakeVorstellungsgespraech.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docIntakeVorstellungsgespraech.Properties.Appearance.Options.UseBackColor = true;
            this.docIntakeVorstellungsgespraech.Properties.Appearance.Options.UseBorderColor = true;
            this.docIntakeVorstellungsgespraech.Properties.Appearance.Options.UseFont = true;
            this.docIntakeVorstellungsgespraech.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docIntakeVorstellungsgespraech.Properties.AppearanceDisabled.Options.UseFont = true;
            this.docIntakeVorstellungsgespraech.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject123.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject123.Options.UseBackColor = true;
            serializableAppearanceObject124.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject124.Options.UseBackColor = true;
            serializableAppearanceObject125.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject125.Options.UseBackColor = true;
            serializableAppearanceObject126.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject126.Options.UseBackColor = true;
            this.docIntakeVorstellungsgespraech.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docIntakeVorstellungsgespraech.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject123, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docIntakeVorstellungsgespraech.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject124, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docIntakeVorstellungsgespraech.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject125, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docIntakeVorstellungsgespraech.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject126, "Dokument importieren")});
            this.docIntakeVorstellungsgespraech.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docIntakeVorstellungsgespraech.Properties.ReadOnly = true;
            this.docIntakeVorstellungsgespraech.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docIntakeVorstellungsgespraech.Size = new System.Drawing.Size(136, 24);
            this.docIntakeVorstellungsgespraech.TabIndex = 9;
            // 
            // lblIntakeVorstellungsgespraech
            // 
            this.lblIntakeVorstellungsgespraech.Location = new System.Drawing.Point(14, 256);
            this.lblIntakeVorstellungsgespraech.Name = "lblIntakeVorstellungsgespraech";
            this.lblIntakeVorstellungsgespraech.Size = new System.Drawing.Size(124, 24);
            this.lblIntakeVorstellungsgespraech.TabIndex = 8;
            this.lblIntakeVorstellungsgespraech.Text = "Vorstellungsgespräch";
            // 
            // lblProgBeginn
            // 
            this.lblProgBeginn.Location = new System.Drawing.Point(15, 221);
            this.lblProgBeginn.Name = "lblProgBeginn";
            this.lblProgBeginn.Size = new System.Drawing.Size(122, 24);
            this.lblProgBeginn.TabIndex = 6;
            this.lblProgBeginn.Text = "Programmbeginn";
            // 
            // chlIntakeCodes
            // 
            this.chlIntakeCodes.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.chlIntakeCodes.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.chlIntakeCodes.Appearance.Options.UseBackColor = true;
            this.chlIntakeCodes.Appearance.Options.UseBorderColor = true;
            this.chlIntakeCodes.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.chlIntakeCodes.CheckOnClick = true;
            this.chlIntakeCodes.DataMember = "IntakeCodes";
            this.chlIntakeCodes.DataSource = this.qryEPQ;
            this.chlIntakeCodes.Location = new System.Drawing.Point(20, 90);
            this.chlIntakeCodes.LOVName = "KaQEEPQIntakeGrund";
            this.chlIntakeCodes.Name = "chlIntakeCodes";
            this.chlIntakeCodes.Size = new System.Drawing.Size(593, 115);
            this.chlIntakeCodes.TabIndex = 5;
            // 
            // lblBemerkungen
            // 
            this.lblBemerkungen.Location = new System.Drawing.Point(15, 391);
            this.lblBemerkungen.Name = "lblBemerkungen";
            this.lblBemerkungen.Size = new System.Drawing.Size(95, 24);
            this.lblBemerkungen.TabIndex = 15;
            this.lblBemerkungen.Text = "Bemerkungen";
            this.lblBemerkungen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // docEinladungProgBeginn2
            // 
            this.docEinladungProgBeginn2.Context = "KaQEEPQProgBeginn";
            this.docEinladungProgBeginn2.DataMember = "EinladungProgBeginn2DokID";
            this.docEinladungProgBeginn2.DataSource = this.qryEPQ;
            this.docEinladungProgBeginn2.Location = new System.Drawing.Point(195, 356);
            this.docEinladungProgBeginn2.Name = "docEinladungProgBeginn2";
            this.docEinladungProgBeginn2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docEinladungProgBeginn2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docEinladungProgBeginn2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docEinladungProgBeginn2.Properties.Appearance.Options.UseBackColor = true;
            this.docEinladungProgBeginn2.Properties.Appearance.Options.UseBorderColor = true;
            this.docEinladungProgBeginn2.Properties.Appearance.Options.UseFont = true;
            this.docEinladungProgBeginn2.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docEinladungProgBeginn2.Properties.AppearanceDisabled.Options.UseFont = true;
            this.docEinladungProgBeginn2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject49.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject49.Options.UseBackColor = true;
            serializableAppearanceObject50.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject50.Options.UseBackColor = true;
            serializableAppearanceObject51.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject51.Options.UseBackColor = true;
            serializableAppearanceObject52.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject52.Options.UseBackColor = true;
            this.docEinladungProgBeginn2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docEinladungProgBeginn2.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject49, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docEinladungProgBeginn2.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject50, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docEinladungProgBeginn2.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject51, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docEinladungProgBeginn2.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject52, "Dokument importieren")});
            this.docEinladungProgBeginn2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docEinladungProgBeginn2.Properties.ReadOnly = true;
            this.docEinladungProgBeginn2.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docEinladungProgBeginn2.Size = new System.Drawing.Size(136, 24);
            this.docEinladungProgBeginn2.TabIndex = 14;
            // 
            // docEinladungProgBeginn1
            // 
            this.docEinladungProgBeginn1.Context = "KaQEEPQProgBeginn";
            this.docEinladungProgBeginn1.DataMember = "EinladungProgBeginn1DokID";
            this.docEinladungProgBeginn1.DataSource = this.qryEPQ;
            this.docEinladungProgBeginn1.Location = new System.Drawing.Point(195, 326);
            this.docEinladungProgBeginn1.Name = "docEinladungProgBeginn1";
            this.docEinladungProgBeginn1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docEinladungProgBeginn1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docEinladungProgBeginn1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docEinladungProgBeginn1.Properties.Appearance.Options.UseBackColor = true;
            this.docEinladungProgBeginn1.Properties.Appearance.Options.UseBorderColor = true;
            this.docEinladungProgBeginn1.Properties.Appearance.Options.UseFont = true;
            this.docEinladungProgBeginn1.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docEinladungProgBeginn1.Properties.AppearanceDisabled.Options.UseFont = true;
            this.docEinladungProgBeginn1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject53.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject53.Options.UseBackColor = true;
            serializableAppearanceObject54.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject54.Options.UseBackColor = true;
            serializableAppearanceObject55.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject55.Options.UseBackColor = true;
            serializableAppearanceObject56.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject56.Options.UseBackColor = true;
            this.docEinladungProgBeginn1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docEinladungProgBeginn1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject53, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docEinladungProgBeginn1.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject54, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docEinladungProgBeginn1.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject55, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docEinladungProgBeginn1.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject56, "Dokument importieren")});
            this.docEinladungProgBeginn1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docEinladungProgBeginn1.Properties.ReadOnly = true;
            this.docEinladungProgBeginn1.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docEinladungProgBeginn1.Size = new System.Drawing.Size(136, 24);
            this.docEinladungProgBeginn1.TabIndex = 13;
            // 
            // docAntwortAnbieter
            // 
            this.docAntwortAnbieter.Context = "KaQEEPQRueckantwort";
            this.docAntwortAnbieter.DataMember = "RueckanwortDokID";
            this.docAntwortAnbieter.DataSource = this.qryEPQ;
            this.docAntwortAnbieter.Location = new System.Drawing.Point(145, 286);
            this.docAntwortAnbieter.Name = "docAntwortAnbieter";
            this.docAntwortAnbieter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docAntwortAnbieter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docAntwortAnbieter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docAntwortAnbieter.Properties.Appearance.Options.UseBackColor = true;
            this.docAntwortAnbieter.Properties.Appearance.Options.UseBorderColor = true;
            this.docAntwortAnbieter.Properties.Appearance.Options.UseFont = true;
            this.docAntwortAnbieter.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docAntwortAnbieter.Properties.AppearanceDisabled.Options.UseFont = true;
            this.docAntwortAnbieter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject57.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject57.Options.UseBackColor = true;
            serializableAppearanceObject58.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject58.Options.UseBackColor = true;
            serializableAppearanceObject59.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject59.Options.UseBackColor = true;
            serializableAppearanceObject60.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject60.Options.UseBackColor = true;
            this.docAntwortAnbieter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docAntwortAnbieter.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject57, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docAntwortAnbieter.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject58, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docAntwortAnbieter.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject59, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docAntwortAnbieter.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject60, "Dokument importieren")});
            this.docAntwortAnbieter.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docAntwortAnbieter.Properties.ReadOnly = true;
            this.docAntwortAnbieter.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docAntwortAnbieter.Size = new System.Drawing.Size(136, 24);
            this.docAntwortAnbieter.TabIndex = 11;
            // 
            // lblAntwortAnbieter
            // 
            this.lblAntwortAnbieter.Location = new System.Drawing.Point(15, 286);
            this.lblAntwortAnbieter.Name = "lblAntwortAnbieter";
            this.lblAntwortAnbieter.Size = new System.Drawing.Size(124, 24);
            this.lblAntwortAnbieter.TabIndex = 10;
            this.lblAntwortAnbieter.Text = "Rückantwort Anbieter";
            // 
            // lblEinladugProgBeginn
            // 
            this.lblEinladugProgBeginn.ForeColor = System.Drawing.Color.Black;
            this.lblEinladugProgBeginn.Location = new System.Drawing.Point(15, 326);
            this.lblEinladugProgBeginn.Name = "lblEinladugProgBeginn";
            this.lblEinladugProgBeginn.Size = new System.Drawing.Size(174, 24);
            this.lblEinladugProgBeginn.TabIndex = 12;
            this.lblEinladugProgBeginn.Text = "Einladung Programmbeginn";
            this.lblEinladugProgBeginn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // memBemerkungen
            // 
            this.memBemerkungen.DataMember = "Bemerkung";
            this.memBemerkungen.DataSource = this.qryEPQ;
            this.memBemerkungen.Location = new System.Drawing.Point(15, 421);
            this.memBemerkungen.Name = "memBemerkungen";
            this.memBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.memBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.memBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.memBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memBemerkungen.Size = new System.Drawing.Size(598, 105);
            this.memBemerkungen.TabIndex = 16;
            // 
            // rgProgBeginn
            // 
            this.rgProgBeginn.DataMember = "ProgBeg";
            this.rgProgBeginn.DataSource = this.qryEPQ;
            this.rgProgBeginn.EditValue = "";
            this.rgProgBeginn.Location = new System.Drawing.Point(145, 220);
            this.rgProgBeginn.LookupSQL = null;
            this.rgProgBeginn.LOVFilter = null;
            this.rgProgBeginn.LOVName = null;
            this.rgProgBeginn.Name = "rgProgBeginn";
            this.rgProgBeginn.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgProgBeginn.Properties.Appearance.Options.UseBackColor = true;
            this.rgProgBeginn.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.rgProgBeginn.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.rgProgBeginn.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgProgBeginn.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "Ja"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("0", "Nein")});
            this.rgProgBeginn.Size = new System.Drawing.Size(117, 30);
            this.rgProgBeginn.TabIndex = 7;
            // 
            // docEinladung2
            // 
            this.docEinladung2.Context = "KaQEEPQEinladung";
            this.docEinladung2.DataMember = "Einladung2DokID";
            this.docEinladung2.DataSource = this.qryEPQ;
            this.docEinladung2.Location = new System.Drawing.Point(225, 55);
            this.docEinladung2.Name = "docEinladung2";
            this.docEinladung2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docEinladung2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docEinladung2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docEinladung2.Properties.Appearance.Options.UseBackColor = true;
            this.docEinladung2.Properties.Appearance.Options.UseBorderColor = true;
            this.docEinladung2.Properties.Appearance.Options.UseFont = true;
            this.docEinladung2.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docEinladung2.Properties.AppearanceDisabled.Options.UseFont = true;
            this.docEinladung2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject61.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject61.Options.UseBackColor = true;
            serializableAppearanceObject62.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject62.Options.UseBackColor = true;
            serializableAppearanceObject63.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject63.Options.UseBackColor = true;
            serializableAppearanceObject64.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject64.Options.UseBackColor = true;
            this.docEinladung2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docEinladung2.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject61, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docEinladung2.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject62, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docEinladung2.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject63, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docEinladung2.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject64, "Dokument importieren")});
            this.docEinladung2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docEinladung2.Properties.ReadOnly = true;
            this.docEinladung2.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docEinladung2.Size = new System.Drawing.Size(136, 24);
            this.docEinladung2.TabIndex = 4;
            // 
            // docEinladung1
            // 
            this.docEinladung1.Context = "KaQEEPQEinladung";
            this.docEinladung1.DataMember = "Einladung1DokID";
            this.docEinladung1.DataSource = this.qryEPQ;
            this.docEinladung1.Location = new System.Drawing.Point(225, 25);
            this.docEinladung1.Name = "docEinladung1";
            this.docEinladung1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docEinladung1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docEinladung1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docEinladung1.Properties.Appearance.Options.UseBackColor = true;
            this.docEinladung1.Properties.Appearance.Options.UseBorderColor = true;
            this.docEinladung1.Properties.Appearance.Options.UseFont = true;
            this.docEinladung1.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docEinladung1.Properties.AppearanceDisabled.Options.UseFont = true;
            this.docEinladung1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject65.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject65.Options.UseBackColor = true;
            serializableAppearanceObject66.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject66.Options.UseBackColor = true;
            serializableAppearanceObject67.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject67.Options.UseBackColor = true;
            serializableAppearanceObject68.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject68.Options.UseBackColor = true;
            this.docEinladung1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docEinladung1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject65, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docEinladung1.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject66, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docEinladung1.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject67, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docEinladung1.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject68, "Dokument importieren")});
            this.docEinladung1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docEinladung1.Properties.ReadOnly = true;
            this.docEinladung1.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docEinladung1.Size = new System.Drawing.Size(136, 24);
            this.docEinladung1.TabIndex = 2;
            // 
            // datEinladung2
            // 
            this.datEinladung2.DataMember = "EinladungDat2";
            this.datEinladung2.DataSource = this.qryEPQ;
            this.datEinladung2.EditValue = null;
            this.datEinladung2.Location = new System.Drawing.Point(130, 55);
            this.datEinladung2.Name = "datEinladung2";
            this.datEinladung2.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datEinladung2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.datEinladung2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datEinladung2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datEinladung2.Properties.Appearance.Options.UseBackColor = true;
            this.datEinladung2.Properties.Appearance.Options.UseBorderColor = true;
            this.datEinladung2.Properties.Appearance.Options.UseFont = true;
            this.datEinladung2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject69.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject69.Options.UseBackColor = true;
            this.datEinladung2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datEinladung2.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject69)});
            this.datEinladung2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datEinladung2.Properties.ShowToday = false;
            this.datEinladung2.Size = new System.Drawing.Size(89, 24);
            this.datEinladung2.TabIndex = 3;
            // 
            // lblEinladung
            // 
            this.lblEinladung.Location = new System.Drawing.Point(15, 25);
            this.lblEinladung.Name = "lblEinladung";
            this.lblEinladung.Size = new System.Drawing.Size(105, 24);
            this.lblEinladung.TabIndex = 0;
            this.lblEinladung.Text = "Termin / Einladung";
            // 
            // datEinladung1
            // 
            this.datEinladung1.DataMember = "EinladungDat1";
            this.datEinladung1.DataSource = this.qryEPQ;
            this.datEinladung1.EditValue = null;
            this.datEinladung1.Location = new System.Drawing.Point(130, 25);
            this.datEinladung1.Name = "datEinladung1";
            this.datEinladung1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datEinladung1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.datEinladung1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datEinladung1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datEinladung1.Properties.Appearance.Options.UseBackColor = true;
            this.datEinladung1.Properties.Appearance.Options.UseBorderColor = true;
            this.datEinladung1.Properties.Appearance.Options.UseFont = true;
            this.datEinladung1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject70.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject70.Options.UseBackColor = true;
            this.datEinladung1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datEinladung1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject70)});
            this.datEinladung1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datEinladung1.Properties.ShowToday = false;
            this.datEinladung1.Size = new System.Drawing.Size(89, 24);
            this.datEinladung1.TabIndex = 1;
            // 
            // tpgZielVereinbarung
            // 
            this.tpgZielVereinbarung.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.tpgZielVereinbarung.Controls.Add(this.edtErreichenBis);
            this.tpgZielVereinbarung.Controls.Add(this.lblErreichenBis);
            this.tpgZielVereinbarung.Controls.Add(this.memErgebnis);
            this.tpgZielVereinbarung.Controls.Add(this.lblErgebnis);
            this.tpgZielVereinbarung.Controls.Add(this.memMessungZielerreichung);
            this.tpgZielVereinbarung.Controls.Add(this.lblMessungZielerreichung);
            this.tpgZielVereinbarung.Controls.Add(this.memFeinziel);
            this.tpgZielVereinbarung.Controls.Add(this.lblFeinziel);
            this.tpgZielVereinbarung.Controls.Add(this.datFeinziel);
            this.tpgZielVereinbarung.Controls.Add(this.grdZielvereinb);
            this.tpgZielVereinbarung.Controls.Add(this.lblIndivZieleRAV);
            this.tpgZielVereinbarung.Controls.Add(this.docIndivZieleRAV);
            this.tpgZielVereinbarung.Controls.Add(this.memIndivZieleRAV);
            this.tpgZielVereinbarung.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpgZielVereinbarung.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tpgZielVereinbarung.Location = new System.Drawing.Point(6, 32);
            this.tpgZielVereinbarung.Name = "tpgZielVereinbarung";
            this.tpgZielVereinbarung.Size = new System.Drawing.Size(978, 577);
            this.tpgZielVereinbarung.TabIndex = 2;
            this.tpgZielVereinbarung.Title = "Zielvereinbarung";
            // 
            // edtErreichenBis
            // 
            this.edtErreichenBis.DataMember = "ErreichenBis";
            this.edtErreichenBis.DataSource = this.qryZielvereinb;
            this.edtErreichenBis.Location = new System.Drawing.Point(400, 380);
            this.edtErreichenBis.Name = "edtErreichenBis";
            this.edtErreichenBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErreichenBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErreichenBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErreichenBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtErreichenBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErreichenBis.Properties.Appearance.Options.UseFont = true;
            this.edtErreichenBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtErreichenBis.Size = new System.Drawing.Size(287, 24);
            this.edtErreichenBis.TabIndex = 31;
            // 
            // qryZielvereinb
            // 
            this.qryZielvereinb.AutoApplyUserRights = false;
            this.qryZielvereinb.CanDelete = true;
            this.qryZielvereinb.CanInsert = true;
            this.qryZielvereinb.CanUpdate = true;
            this.qryZielvereinb.HostControl = this;
            this.qryZielvereinb.IsIdentityInsert = false;
            this.qryZielvereinb.TableName = "KaQEEPQZielvereinb";
            this.qryZielvereinb.AfterInsert += new System.EventHandler(this.qryZielvereinb_AfterInsert);
            // 
            // lblErreichenBis
            // 
            this.lblErreichenBis.Location = new System.Drawing.Point(400, 355);
            this.lblErreichenBis.Name = "lblErreichenBis";
            this.lblErreichenBis.Size = new System.Drawing.Size(88, 24);
            this.lblErreichenBis.TabIndex = 601;
            this.lblErreichenBis.Text = "zu erreichen bis";
            // 
            // memErgebnis
            // 
            this.memErgebnis.DataMember = "Ergebnis";
            this.memErgebnis.DataSource = this.qryZielvereinb;
            this.memErgebnis.Location = new System.Drawing.Point(400, 490);
            this.memErgebnis.Name = "memErgebnis";
            this.memErgebnis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memErgebnis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memErgebnis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memErgebnis.Properties.Appearance.Options.UseBackColor = true;
            this.memErgebnis.Properties.Appearance.Options.UseBorderColor = true;
            this.memErgebnis.Properties.Appearance.Options.UseFont = true;
            this.memErgebnis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memErgebnis.Size = new System.Drawing.Size(365, 75);
            this.memErgebnis.TabIndex = 33;
            // 
            // lblErgebnis
            // 
            this.lblErgebnis.Location = new System.Drawing.Point(400, 465);
            this.lblErgebnis.Name = "lblErgebnis";
            this.lblErgebnis.Size = new System.Drawing.Size(305, 24);
            this.lblErgebnis.TabIndex = 599;
            this.lblErgebnis.Text = "Ergebnis";
            // 
            // memMessungZielerreichung
            // 
            this.memMessungZielerreichung.DataMember = "MessungZielerreichung";
            this.memMessungZielerreichung.DataSource = this.qryZielvereinb;
            this.memMessungZielerreichung.Location = new System.Drawing.Point(10, 490);
            this.memMessungZielerreichung.Name = "memMessungZielerreichung";
            this.memMessungZielerreichung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memMessungZielerreichung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memMessungZielerreichung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memMessungZielerreichung.Properties.Appearance.Options.UseBackColor = true;
            this.memMessungZielerreichung.Properties.Appearance.Options.UseBorderColor = true;
            this.memMessungZielerreichung.Properties.Appearance.Options.UseFont = true;
            this.memMessungZielerreichung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memMessungZielerreichung.Size = new System.Drawing.Size(365, 75);
            this.memMessungZielerreichung.TabIndex = 32;
            // 
            // lblMessungZielerreichung
            // 
            this.lblMessungZielerreichung.Location = new System.Drawing.Point(10, 465);
            this.lblMessungZielerreichung.Name = "lblMessungZielerreichung";
            this.lblMessungZielerreichung.Size = new System.Drawing.Size(225, 24);
            this.lblMessungZielerreichung.TabIndex = 597;
            this.lblMessungZielerreichung.Text = "Messung Zielerreichung";
            // 
            // memFeinziel
            // 
            this.memFeinziel.DataMember = "Feinziel";
            this.memFeinziel.DataSource = this.qryZielvereinb;
            this.memFeinziel.Location = new System.Drawing.Point(10, 380);
            this.memFeinziel.Name = "memFeinziel";
            this.memFeinziel.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memFeinziel.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memFeinziel.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memFeinziel.Properties.Appearance.Options.UseBackColor = true;
            this.memFeinziel.Properties.Appearance.Options.UseBorderColor = true;
            this.memFeinziel.Properties.Appearance.Options.UseFont = true;
            this.memFeinziel.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memFeinziel.Size = new System.Drawing.Size(365, 75);
            this.memFeinziel.TabIndex = 30;
            // 
            // lblFeinziel
            // 
            this.lblFeinziel.Location = new System.Drawing.Point(10, 355);
            this.lblFeinziel.Name = "lblFeinziel";
            this.lblFeinziel.Size = new System.Drawing.Size(120, 24);
            this.lblFeinziel.TabIndex = 595;
            this.lblFeinziel.Text = "Feinziel";
            // 
            // datFeinziel
            // 
            this.datFeinziel.DataMember = "FeinzielDat";
            this.datFeinziel.DataSource = this.qryZielvereinb;
            this.datFeinziel.EditValue = null;
            this.datFeinziel.Location = new System.Drawing.Point(10, 320);
            this.datFeinziel.Name = "datFeinziel";
            this.datFeinziel.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datFeinziel.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.datFeinziel.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datFeinziel.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datFeinziel.Properties.Appearance.Options.UseBackColor = true;
            this.datFeinziel.Properties.Appearance.Options.UseBorderColor = true;
            this.datFeinziel.Properties.Appearance.Options.UseFont = true;
            this.datFeinziel.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject45.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject45.Options.UseBackColor = true;
            this.datFeinziel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datFeinziel.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject45)});
            this.datFeinziel.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datFeinziel.Properties.ShowToday = false;
            this.datFeinziel.Size = new System.Drawing.Size(89, 24);
            this.datFeinziel.TabIndex = 29;
            // 
            // grdZielvereinb
            // 
            this.grdZielvereinb.DataSource = this.qryZielvereinb;
            // 
            // 
            // 
            this.grdZielvereinb.EmbeddedNavigator.Name = "";
            this.grdZielvereinb.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdZielvereinb.Location = new System.Drawing.Point(10, 160);
            this.grdZielvereinb.MainView = this.gvZielvereinb;
            this.grdZielvereinb.Name = "grdZielvereinb";
            this.grdZielvereinb.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemMemoEdit3});
            this.grdZielvereinb.Size = new System.Drawing.Size(895, 145);
            this.grdZielvereinb.Styles.AddReplace("StyleNear", new DevExpress.Utils.ViewStyleEx("StyleNear", null, "", DevExpress.Utils.StyleOptions.UseHorzAlignment, true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
            this.grdZielvereinb.Styles.AddReplace("ReadOnly", new DevExpress.Utils.ViewStyleEx("ReadOnly", null, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))), DevExpress.Utils.StyleOptions.UseBackColor, System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231))))), System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
            this.grdZielvereinb.Styles.AddReplace("StyleFar", new DevExpress.Utils.ViewStyleEx("StyleFar", null, "", DevExpress.Utils.StyleOptions.UseHorzAlignment, true, false, false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
            this.grdZielvereinb.Styles.AddReplace("StyleCenter", new DevExpress.Utils.ViewStyleEx("StyleCenter", null, "", DevExpress.Utils.StyleOptions.UseHorzAlignment, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
            this.grdZielvereinb.Styles.AddReplace("rotVerein", new DevExpress.Utils.ViewStyleEx("rotVerein", null, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))), DevExpress.Utils.StyleOptions.UseBackColor, System.Drawing.Color.LightSalmon, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
            this.grdZielvereinb.Styles.AddReplace("gelbVerein", new DevExpress.Utils.ViewStyleEx("gelbVerein", null, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))), DevExpress.Utils.StyleOptions.UseBackColor, System.Drawing.Color.Yellow, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
            this.grdZielvereinb.TabIndex = 593;
            this.grdZielvereinb.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvZielvereinb});
            // 
            // gvZielvereinb
            // 
            this.gvZielvereinb.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.gvZielvereinb.Appearance.Empty.Options.UseBackColor = true;
            this.gvZielvereinb.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvZielvereinb.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvZielvereinb.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gvZielvereinb.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvZielvereinb.Appearance.FocusedCell.Options.UseFont = true;
            this.gvZielvereinb.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvZielvereinb.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvZielvereinb.Appearance.FocusedRow.Options.UseFont = true;
            this.gvZielvereinb.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gvZielvereinb.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gvZielvereinb.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gvZielvereinb.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvZielvereinb.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvZielvereinb.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvZielvereinb.Appearance.GroupRow.Options.UseFont = true;
            this.gvZielvereinb.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvZielvereinb.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gvZielvereinb.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gvZielvereinb.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvZielvereinb.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvZielvereinb.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gvZielvereinb.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvZielvereinb.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gvZielvereinb.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvZielvereinb.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvZielvereinb.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvZielvereinb.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvZielvereinb.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvZielvereinb.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gvZielvereinb.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvZielvereinb.Appearance.Row.Options.UseBackColor = true;
            this.gvZielvereinb.Appearance.Row.Options.UseFont = true;
            this.gvZielvereinb.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gvZielvereinb.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFeinzielDat,
            this.colFeinziel,
            this.colErreichenBis,
            this.colErgebnis});
            this.gvZielvereinb.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gvZielvereinb.GridControl = this.grdZielvereinb;
            this.gvZielvereinb.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.gvZielvereinb.Name = "gvZielvereinb";
            this.gvZielvereinb.OptionsBehavior.Editable = false;
            this.gvZielvereinb.OptionsCustomization.AllowFilter = false;
            this.gvZielvereinb.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gvZielvereinb.OptionsNavigation.AutoFocusNewRow = true;
            this.gvZielvereinb.OptionsNavigation.UseTabKey = false;
            this.gvZielvereinb.OptionsView.ColumnAutoWidth = false;
            this.gvZielvereinb.OptionsView.RowAutoHeight = true;
            this.gvZielvereinb.OptionsView.ShowGroupPanel = false;
            this.gvZielvereinb.OptionsView.ShowIndicator = false;
            // 
            // colFeinzielDat
            // 
            this.colFeinzielDat.Caption = "Datum";
            this.colFeinzielDat.FieldName = "FeinzielDat";
            this.colFeinzielDat.Name = "colFeinzielDat";
            this.colFeinzielDat.Visible = true;
            this.colFeinzielDat.VisibleIndex = 0;
            this.colFeinzielDat.Width = 80;
            // 
            // colFeinziel
            // 
            this.colFeinziel.Caption = "Feinziel";
            this.colFeinziel.ColumnEdit = this.repositoryItemMemoEdit3;
            this.colFeinziel.FieldName = "Feinziel";
            this.colFeinziel.Name = "colFeinziel";
            this.colFeinziel.Visible = true;
            this.colFeinziel.VisibleIndex = 1;
            this.colFeinziel.Width = 320;
            // 
            // repositoryItemMemoEdit3
            // 
            this.repositoryItemMemoEdit3.Name = "repositoryItemMemoEdit3";
            this.repositoryItemMemoEdit3.ReadOnly = true;
            // 
            // colErreichenBis
            // 
            this.colErreichenBis.Caption = "zu erreichen bis";
            this.colErreichenBis.FieldName = "ErreichenBis";
            this.colErreichenBis.Name = "colErreichenBis";
            this.colErreichenBis.OptionsColumn.AllowEdit = false;
            this.colErreichenBis.OptionsColumn.ReadOnly = true;
            this.colErreichenBis.Visible = true;
            this.colErreichenBis.VisibleIndex = 2;
            this.colErreichenBis.Width = 150;
            // 
            // colErgebnis
            // 
            this.colErgebnis.Caption = "Ergebnis";
            this.colErgebnis.ColumnEdit = this.repositoryItemMemoEdit3;
            this.colErgebnis.FieldName = "Ergebnis";
            this.colErgebnis.Name = "colErgebnis";
            this.colErgebnis.Visible = true;
            this.colErgebnis.VisibleIndex = 3;
            this.colErgebnis.Width = 320;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // lblIndivZieleRAV
            // 
            this.lblIndivZieleRAV.Location = new System.Drawing.Point(10, 10);
            this.lblIndivZieleRAV.Name = "lblIndivZieleRAV";
            this.lblIndivZieleRAV.Size = new System.Drawing.Size(330, 24);
            this.lblIndivZieleRAV.TabIndex = 592;
            this.lblIndivZieleRAV.Text = "individuelle Ziele RAV";
            this.lblIndivZieleRAV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // docIndivZieleRAV
            // 
            this.docIndivZieleRAV.Context = "KaQEEPQZieleRAV";
            this.docIndivZieleRAV.DataMember = "IndivZieleRAVDokID";
            this.docIndivZieleRAV.DataSource = this.qryEPQ;
            this.docIndivZieleRAV.Location = new System.Drawing.Point(625, 40);
            this.docIndivZieleRAV.Name = "docIndivZieleRAV";
            this.docIndivZieleRAV.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docIndivZieleRAV.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docIndivZieleRAV.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docIndivZieleRAV.Properties.Appearance.Options.UseBackColor = true;
            this.docIndivZieleRAV.Properties.Appearance.Options.UseBorderColor = true;
            this.docIndivZieleRAV.Properties.Appearance.Options.UseFont = true;
            this.docIndivZieleRAV.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docIndivZieleRAV.Properties.AppearanceDisabled.Options.UseFont = true;
            this.docIndivZieleRAV.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject46.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject46.Options.UseBackColor = true;
            serializableAppearanceObject47.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject47.Options.UseBackColor = true;
            serializableAppearanceObject48.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject48.Options.UseBackColor = true;
            serializableAppearanceObject75.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject75.Options.UseBackColor = true;
            this.docIndivZieleRAV.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docIndivZieleRAV.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject46, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docIndivZieleRAV.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject47, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docIndivZieleRAV.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject48, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docIndivZieleRAV.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject75, "Dokument importieren")});
            this.docIndivZieleRAV.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docIndivZieleRAV.Properties.ReadOnly = true;
            this.docIndivZieleRAV.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docIndivZieleRAV.Size = new System.Drawing.Size(136, 24);
            this.docIndivZieleRAV.TabIndex = 28;
            // 
            // memIndivZieleRAV
            // 
            this.memIndivZieleRAV.DataMember = "IndivZieleRAV";
            this.memIndivZieleRAV.DataSource = this.qryEPQ;
            this.memIndivZieleRAV.Location = new System.Drawing.Point(10, 40);
            this.memIndivZieleRAV.Name = "memIndivZieleRAV";
            this.memIndivZieleRAV.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memIndivZieleRAV.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memIndivZieleRAV.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memIndivZieleRAV.Properties.Appearance.Options.UseBackColor = true;
            this.memIndivZieleRAV.Properties.Appearance.Options.UseBorderColor = true;
            this.memIndivZieleRAV.Properties.Appearance.Options.UseFont = true;
            this.memIndivZieleRAV.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memIndivZieleRAV.Size = new System.Drawing.Size(547, 105);
            this.memIndivZieleRAV.TabIndex = 27;
            // 
            // tpgZielVereinbarungVerl
            // 
            this.tpgZielVereinbarungVerl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.tpgZielVereinbarungVerl.Controls.Add(this.edtErreichenBisVerl);
            this.tpgZielVereinbarungVerl.Controls.Add(this.lblErreichenBisVerl);
            this.tpgZielVereinbarungVerl.Controls.Add(this.memErgebnisVerl);
            this.tpgZielVereinbarungVerl.Controls.Add(this.lblErgebnisVerl);
            this.tpgZielVereinbarungVerl.Controls.Add(this.memMessungZielerreichungVerl);
            this.tpgZielVereinbarungVerl.Controls.Add(this.lblMessungZielerreichungVerl);
            this.tpgZielVereinbarungVerl.Controls.Add(this.memFeinzielVerl);
            this.tpgZielVereinbarungVerl.Controls.Add(this.lblFeinzielVerl);
            this.tpgZielVereinbarungVerl.Controls.Add(this.datFeinzielVerl);
            this.tpgZielVereinbarungVerl.Controls.Add(this.grdZielvereinbVerl);
            this.tpgZielVereinbarungVerl.Controls.Add(this.lblIndivZieleRAVVerl);
            this.tpgZielVereinbarungVerl.Controls.Add(this.docIndivZieleRAVVerl);
            this.tpgZielVereinbarungVerl.Controls.Add(this.memIndivZieleRAVVerl);
            this.tpgZielVereinbarungVerl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpgZielVereinbarungVerl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tpgZielVereinbarungVerl.Location = new System.Drawing.Point(6, 32);
            this.tpgZielVereinbarungVerl.Name = "tpgZielVereinbarungVerl";
            this.tpgZielVereinbarungVerl.Size = new System.Drawing.Size(978, 577);
            this.tpgZielVereinbarungVerl.TabIndex = 3;
            this.tpgZielVereinbarungVerl.Title = "Zielvereinbarung Verlängerung";
            // 
            // edtErreichenBisVerl
            // 
            this.edtErreichenBisVerl.DataMember = "ErreichenBis";
            this.edtErreichenBisVerl.DataSource = this.qryZielvereinbVerl;
            this.edtErreichenBisVerl.Location = new System.Drawing.Point(400, 380);
            this.edtErreichenBisVerl.Name = "edtErreichenBisVerl";
            this.edtErreichenBisVerl.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErreichenBisVerl.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErreichenBisVerl.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErreichenBisVerl.Properties.Appearance.Options.UseBackColor = true;
            this.edtErreichenBisVerl.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErreichenBisVerl.Properties.Appearance.Options.UseFont = true;
            this.edtErreichenBisVerl.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtErreichenBisVerl.Size = new System.Drawing.Size(287, 24);
            this.edtErreichenBisVerl.TabIndex = 38;
            // 
            // qryZielvereinbVerl
            // 
            this.qryZielvereinbVerl.AutoApplyUserRights = false;
            this.qryZielvereinbVerl.CanDelete = true;
            this.qryZielvereinbVerl.CanInsert = true;
            this.qryZielvereinbVerl.CanUpdate = true;
            this.qryZielvereinbVerl.HostControl = this;
            this.qryZielvereinbVerl.IsIdentityInsert = false;
            this.qryZielvereinbVerl.TableName = "KaQEEPQZielvereinbVerl";
            this.qryZielvereinbVerl.AfterInsert += new System.EventHandler(this.qryZielvereinbVerl_AfterInsert);
            // 
            // lblErreichenBisVerl
            // 
            this.lblErreichenBisVerl.Location = new System.Drawing.Point(400, 355);
            this.lblErreichenBisVerl.Name = "lblErreichenBisVerl";
            this.lblErreichenBisVerl.Size = new System.Drawing.Size(88, 24);
            this.lblErreichenBisVerl.TabIndex = 611;
            this.lblErreichenBisVerl.Text = "zu erreichen bis";
            // 
            // memErgebnisVerl
            // 
            this.memErgebnisVerl.DataMember = "Ergebnis";
            this.memErgebnisVerl.DataSource = this.qryZielvereinbVerl;
            this.memErgebnisVerl.Location = new System.Drawing.Point(400, 490);
            this.memErgebnisVerl.Name = "memErgebnisVerl";
            this.memErgebnisVerl.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memErgebnisVerl.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memErgebnisVerl.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memErgebnisVerl.Properties.Appearance.Options.UseBackColor = true;
            this.memErgebnisVerl.Properties.Appearance.Options.UseBorderColor = true;
            this.memErgebnisVerl.Properties.Appearance.Options.UseFont = true;
            this.memErgebnisVerl.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memErgebnisVerl.Size = new System.Drawing.Size(365, 75);
            this.memErgebnisVerl.TabIndex = 40;
            // 
            // lblErgebnisVerl
            // 
            this.lblErgebnisVerl.Location = new System.Drawing.Point(400, 465);
            this.lblErgebnisVerl.Name = "lblErgebnisVerl";
            this.lblErgebnisVerl.Size = new System.Drawing.Size(305, 24);
            this.lblErgebnisVerl.TabIndex = 610;
            this.lblErgebnisVerl.Text = "Ergebnis";
            // 
            // memMessungZielerreichungVerl
            // 
            this.memMessungZielerreichungVerl.DataMember = "MessungZielerreichung";
            this.memMessungZielerreichungVerl.DataSource = this.qryZielvereinbVerl;
            this.memMessungZielerreichungVerl.Location = new System.Drawing.Point(10, 490);
            this.memMessungZielerreichungVerl.Name = "memMessungZielerreichungVerl";
            this.memMessungZielerreichungVerl.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memMessungZielerreichungVerl.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memMessungZielerreichungVerl.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memMessungZielerreichungVerl.Properties.Appearance.Options.UseBackColor = true;
            this.memMessungZielerreichungVerl.Properties.Appearance.Options.UseBorderColor = true;
            this.memMessungZielerreichungVerl.Properties.Appearance.Options.UseFont = true;
            this.memMessungZielerreichungVerl.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memMessungZielerreichungVerl.Size = new System.Drawing.Size(365, 75);
            this.memMessungZielerreichungVerl.TabIndex = 39;
            // 
            // lblMessungZielerreichungVerl
            // 
            this.lblMessungZielerreichungVerl.Location = new System.Drawing.Point(10, 465);
            this.lblMessungZielerreichungVerl.Name = "lblMessungZielerreichungVerl";
            this.lblMessungZielerreichungVerl.Size = new System.Drawing.Size(225, 24);
            this.lblMessungZielerreichungVerl.TabIndex = 609;
            this.lblMessungZielerreichungVerl.Text = "Messung Zielerreichung";
            // 
            // memFeinzielVerl
            // 
            this.memFeinzielVerl.DataMember = "Feinziel";
            this.memFeinzielVerl.DataSource = this.qryZielvereinbVerl;
            this.memFeinzielVerl.Location = new System.Drawing.Point(10, 380);
            this.memFeinzielVerl.Name = "memFeinzielVerl";
            this.memFeinzielVerl.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memFeinzielVerl.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memFeinzielVerl.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memFeinzielVerl.Properties.Appearance.Options.UseBackColor = true;
            this.memFeinzielVerl.Properties.Appearance.Options.UseBorderColor = true;
            this.memFeinzielVerl.Properties.Appearance.Options.UseFont = true;
            this.memFeinzielVerl.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memFeinzielVerl.Size = new System.Drawing.Size(365, 75);
            this.memFeinzielVerl.TabIndex = 37;
            // 
            // lblFeinzielVerl
            // 
            this.lblFeinzielVerl.Location = new System.Drawing.Point(10, 355);
            this.lblFeinzielVerl.Name = "lblFeinzielVerl";
            this.lblFeinzielVerl.Size = new System.Drawing.Size(120, 24);
            this.lblFeinzielVerl.TabIndex = 608;
            this.lblFeinzielVerl.Text = "Feinziel";
            // 
            // datFeinzielVerl
            // 
            this.datFeinzielVerl.DataMember = "FeinzielDat";
            this.datFeinzielVerl.DataSource = this.qryZielvereinbVerl;
            this.datFeinzielVerl.EditValue = null;
            this.datFeinzielVerl.Location = new System.Drawing.Point(10, 320);
            this.datFeinzielVerl.Name = "datFeinzielVerl";
            this.datFeinzielVerl.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datFeinzielVerl.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.datFeinzielVerl.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datFeinzielVerl.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datFeinzielVerl.Properties.Appearance.Options.UseBackColor = true;
            this.datFeinzielVerl.Properties.Appearance.Options.UseBorderColor = true;
            this.datFeinzielVerl.Properties.Appearance.Options.UseFont = true;
            this.datFeinzielVerl.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject76.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject76.Options.UseBackColor = true;
            this.datFeinzielVerl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datFeinzielVerl.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject76)});
            this.datFeinzielVerl.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datFeinzielVerl.Properties.ShowToday = false;
            this.datFeinzielVerl.Size = new System.Drawing.Size(89, 24);
            this.datFeinzielVerl.TabIndex = 36;
            // 
            // grdZielvereinbVerl
            // 
            this.grdZielvereinbVerl.DataSource = this.qryZielvereinbVerl;
            // 
            // 
            // 
            this.grdZielvereinbVerl.EmbeddedNavigator.Name = "";
            this.grdZielvereinbVerl.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdZielvereinbVerl.Location = new System.Drawing.Point(10, 160);
            this.grdZielvereinbVerl.MainView = this.gvZielvereinbVerl;
            this.grdZielvereinbVerl.Name = "grdZielvereinbVerl";
            this.grdZielvereinbVerl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit2,
            this.repositoryItemMemoEdit4});
            this.grdZielvereinbVerl.Size = new System.Drawing.Size(895, 145);
            this.grdZielvereinbVerl.Styles.AddReplace("StyleNear", new DevExpress.Utils.ViewStyleEx("StyleNear", null, "", DevExpress.Utils.StyleOptions.UseHorzAlignment, true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
            this.grdZielvereinbVerl.Styles.AddReplace("ReadOnly", new DevExpress.Utils.ViewStyleEx("ReadOnly", null, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))), DevExpress.Utils.StyleOptions.UseBackColor, System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231))))), System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
            this.grdZielvereinbVerl.Styles.AddReplace("StyleFar", new DevExpress.Utils.ViewStyleEx("StyleFar", null, "", DevExpress.Utils.StyleOptions.UseHorzAlignment, true, false, false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
            this.grdZielvereinbVerl.Styles.AddReplace("StyleCenter", new DevExpress.Utils.ViewStyleEx("StyleCenter", null, "", DevExpress.Utils.StyleOptions.UseHorzAlignment, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
            this.grdZielvereinbVerl.Styles.AddReplace("rotVerein", new DevExpress.Utils.ViewStyleEx("rotVerein", null, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))), DevExpress.Utils.StyleOptions.UseBackColor, System.Drawing.Color.LightSalmon, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
            this.grdZielvereinbVerl.Styles.AddReplace("gelbVerein", new DevExpress.Utils.ViewStyleEx("gelbVerein", null, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))), DevExpress.Utils.StyleOptions.UseBackColor, System.Drawing.Color.Yellow, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
            this.grdZielvereinbVerl.TabIndex = 607;
            this.grdZielvereinbVerl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvZielvereinbVerl});
            // 
            // gvZielvereinbVerl
            // 
            this.gvZielvereinbVerl.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.gvZielvereinbVerl.Appearance.Empty.Options.UseBackColor = true;
            this.gvZielvereinbVerl.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvZielvereinbVerl.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvZielvereinbVerl.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gvZielvereinbVerl.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvZielvereinbVerl.Appearance.FocusedCell.Options.UseFont = true;
            this.gvZielvereinbVerl.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvZielvereinbVerl.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvZielvereinbVerl.Appearance.FocusedRow.Options.UseFont = true;
            this.gvZielvereinbVerl.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gvZielvereinbVerl.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gvZielvereinbVerl.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gvZielvereinbVerl.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvZielvereinbVerl.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvZielvereinbVerl.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvZielvereinbVerl.Appearance.GroupRow.Options.UseFont = true;
            this.gvZielvereinbVerl.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvZielvereinbVerl.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gvZielvereinbVerl.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gvZielvereinbVerl.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvZielvereinbVerl.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvZielvereinbVerl.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gvZielvereinbVerl.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvZielvereinbVerl.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gvZielvereinbVerl.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvZielvereinbVerl.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvZielvereinbVerl.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvZielvereinbVerl.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvZielvereinbVerl.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvZielvereinbVerl.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gvZielvereinbVerl.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvZielvereinbVerl.Appearance.Row.Options.UseBackColor = true;
            this.gvZielvereinbVerl.Appearance.Row.Options.UseFont = true;
            this.gvZielvereinbVerl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gvZielvereinbVerl.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFeinzielDatVerl,
            this.colFeinzielVerl,
            this.colErreichenBisVerl,
            this.colErgebnisVerl});
            this.gvZielvereinbVerl.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gvZielvereinbVerl.GridControl = this.grdZielvereinbVerl;
            this.gvZielvereinbVerl.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.gvZielvereinbVerl.Name = "gvZielvereinbVerl";
            this.gvZielvereinbVerl.OptionsBehavior.Editable = false;
            this.gvZielvereinbVerl.OptionsCustomization.AllowFilter = false;
            this.gvZielvereinbVerl.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gvZielvereinbVerl.OptionsNavigation.AutoFocusNewRow = true;
            this.gvZielvereinbVerl.OptionsNavigation.UseTabKey = false;
            this.gvZielvereinbVerl.OptionsView.ColumnAutoWidth = false;
            this.gvZielvereinbVerl.OptionsView.RowAutoHeight = true;
            this.gvZielvereinbVerl.OptionsView.ShowGroupPanel = false;
            this.gvZielvereinbVerl.OptionsView.ShowIndicator = false;
            // 
            // colFeinzielDatVerl
            // 
            this.colFeinzielDatVerl.Caption = "Datum";
            this.colFeinzielDatVerl.FieldName = "FeinzielDat";
            this.colFeinzielDatVerl.Name = "colFeinzielDatVerl";
            this.colFeinzielDatVerl.Visible = true;
            this.colFeinzielDatVerl.VisibleIndex = 0;
            this.colFeinzielDatVerl.Width = 80;
            // 
            // colFeinzielVerl
            // 
            this.colFeinzielVerl.Caption = "Feinziel";
            this.colFeinzielVerl.ColumnEdit = this.repositoryItemMemoEdit4;
            this.colFeinzielVerl.FieldName = "Feinziel";
            this.colFeinzielVerl.Name = "colFeinzielVerl";
            this.colFeinzielVerl.Visible = true;
            this.colFeinzielVerl.VisibleIndex = 1;
            this.colFeinzielVerl.Width = 320;
            // 
            // repositoryItemMemoEdit4
            // 
            this.repositoryItemMemoEdit4.Name = "repositoryItemMemoEdit4";
            this.repositoryItemMemoEdit4.ReadOnly = true;
            // 
            // colErreichenBisVerl
            // 
            this.colErreichenBisVerl.Caption = "zu erreichen bis";
            this.colErreichenBisVerl.FieldName = "ErreichenBis";
            this.colErreichenBisVerl.Name = "colErreichenBisVerl";
            this.colErreichenBisVerl.OptionsColumn.AllowEdit = false;
            this.colErreichenBisVerl.OptionsColumn.ReadOnly = true;
            this.colErreichenBisVerl.Visible = true;
            this.colErreichenBisVerl.VisibleIndex = 2;
            this.colErreichenBisVerl.Width = 150;
            // 
            // colErgebnisVerl
            // 
            this.colErgebnisVerl.Caption = "Ergebnis";
            this.colErgebnisVerl.ColumnEdit = this.repositoryItemMemoEdit4;
            this.colErgebnisVerl.FieldName = "Ergebnis";
            this.colErgebnisVerl.Name = "colErgebnisVerl";
            this.colErgebnisVerl.Visible = true;
            this.colErgebnisVerl.VisibleIndex = 3;
            this.colErgebnisVerl.Width = 320;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // lblIndivZieleRAVVerl
            // 
            this.lblIndivZieleRAVVerl.Location = new System.Drawing.Point(10, 10);
            this.lblIndivZieleRAVVerl.Name = "lblIndivZieleRAVVerl";
            this.lblIndivZieleRAVVerl.Size = new System.Drawing.Size(330, 24);
            this.lblIndivZieleRAVVerl.TabIndex = 595;
            this.lblIndivZieleRAVVerl.Text = "individuelle Ziele RAV";
            this.lblIndivZieleRAVVerl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // docIndivZieleRAVVerl
            // 
            this.docIndivZieleRAVVerl.Context = "KaQEEPQZieleRAV";
            this.docIndivZieleRAVVerl.DataMember = "IndivZieleRAVVerlDokID";
            this.docIndivZieleRAVVerl.DataSource = this.qryEPQ;
            this.docIndivZieleRAVVerl.Location = new System.Drawing.Point(625, 40);
            this.docIndivZieleRAVVerl.Name = "docIndivZieleRAVVerl";
            this.docIndivZieleRAVVerl.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docIndivZieleRAVVerl.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docIndivZieleRAVVerl.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docIndivZieleRAVVerl.Properties.Appearance.Options.UseBackColor = true;
            this.docIndivZieleRAVVerl.Properties.Appearance.Options.UseBorderColor = true;
            this.docIndivZieleRAVVerl.Properties.Appearance.Options.UseFont = true;
            this.docIndivZieleRAVVerl.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docIndivZieleRAVVerl.Properties.AppearanceDisabled.Options.UseFont = true;
            this.docIndivZieleRAVVerl.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject77.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject77.Options.UseBackColor = true;
            serializableAppearanceObject78.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject78.Options.UseBackColor = true;
            serializableAppearanceObject79.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject79.Options.UseBackColor = true;
            serializableAppearanceObject80.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject80.Options.UseBackColor = true;
            this.docIndivZieleRAVVerl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docIndivZieleRAVVerl.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject77, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docIndivZieleRAVVerl.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject78, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docIndivZieleRAVVerl.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject79, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docIndivZieleRAVVerl.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject80, "Dokument importieren")});
            this.docIndivZieleRAVVerl.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docIndivZieleRAVVerl.Properties.ReadOnly = true;
            this.docIndivZieleRAVVerl.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docIndivZieleRAVVerl.Size = new System.Drawing.Size(136, 24);
            this.docIndivZieleRAVVerl.TabIndex = 35;
            // 
            // memIndivZieleRAVVerl
            // 
            this.memIndivZieleRAVVerl.DataMember = "IndivZieleRAVVerl";
            this.memIndivZieleRAVVerl.DataSource = this.qryEPQ;
            this.memIndivZieleRAVVerl.Location = new System.Drawing.Point(10, 40);
            this.memIndivZieleRAVVerl.Name = "memIndivZieleRAVVerl";
            this.memIndivZieleRAVVerl.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memIndivZieleRAVVerl.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memIndivZieleRAVVerl.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memIndivZieleRAVVerl.Properties.Appearance.Options.UseBackColor = true;
            this.memIndivZieleRAVVerl.Properties.Appearance.Options.UseBorderColor = true;
            this.memIndivZieleRAVVerl.Properties.Appearance.Options.UseFont = true;
            this.memIndivZieleRAVVerl.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memIndivZieleRAVVerl.Size = new System.Drawing.Size(547, 105);
            this.memIndivZieleRAVVerl.TabIndex = 34;
            // 
            // tpgInterventionen
            // 
            this.tpgInterventionen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.tpgInterventionen.Controls.Add(this.lblVerwNichterscheinen);
            this.tpgInterventionen.Controls.Add(this.lblVerwRegelverstoss);
            this.tpgInterventionen.Controls.Add(this.docVerwNichterscheinen);
            this.tpgInterventionen.Controls.Add(this.docVerwRegelverstoss);
            this.tpgInterventionen.Controls.Add(this.lblAufforderung);
            this.tpgInterventionen.Controls.Add(this.lblVereinbarung);
            this.tpgInterventionen.Controls.Add(this.lblProgAbbruch);
            this.tpgInterventionen.Controls.Add(this.docProgAbbruch);
            this.tpgInterventionen.Controls.Add(this.docVereinbarung2);
            this.tpgInterventionen.Controls.Add(this.docVereinbarung1);
            this.tpgInterventionen.Controls.Add(this.docAufforderung3);
            this.tpgInterventionen.Controls.Add(this.docAufforderung2);
            this.tpgInterventionen.Controls.Add(this.docAufforderung1);
            this.tpgInterventionen.Controls.Add(this.memMuendAufford2);
            this.tpgInterventionen.Controls.Add(this.datMuendAufford2);
            this.tpgInterventionen.Controls.Add(this.memMuendAufford1);
            this.tpgInterventionen.Controls.Add(this.lblMuendAufforderung);
            this.tpgInterventionen.Controls.Add(this.datMuendAufford1);
            this.tpgInterventionen.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tpgInterventionen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tpgInterventionen.Location = new System.Drawing.Point(6, 32);
            this.tpgInterventionen.Name = "tpgInterventionen";
            this.tpgInterventionen.Size = new System.Drawing.Size(978, 577);
            this.tpgInterventionen.TabIndex = 4;
            this.tpgInterventionen.Title = "Interventionen";
            // 
            // lblVerwNichterscheinen
            // 
            this.lblVerwNichterscheinen.Location = new System.Drawing.Point(15, 370);
            this.lblVerwNichterscheinen.Name = "lblVerwNichterscheinen";
            this.lblVerwNichterscheinen.Size = new System.Drawing.Size(161, 24);
            this.lblVerwNichterscheinen.TabIndex = 610;
            this.lblVerwNichterscheinen.Text = "Verwarnung Nichterscheinen";
            // 
            // lblVerwRegelverstoss
            // 
            this.lblVerwRegelverstoss.Location = new System.Drawing.Point(15, 340);
            this.lblVerwRegelverstoss.Name = "lblVerwRegelverstoss";
            this.lblVerwRegelverstoss.Size = new System.Drawing.Size(161, 24);
            this.lblVerwRegelverstoss.TabIndex = 609;
            this.lblVerwRegelverstoss.Text = "Verwarnung Regelverstoss";
            // 
            // docVerwNichterscheinen
            // 
            this.docVerwNichterscheinen.Context = "KaQEEPQVerwNichterscheinen";
            this.docVerwNichterscheinen.DataMember = "VerwNichterscheinenDokID";
            this.docVerwNichterscheinen.DataSource = this.qryEPQ;
            this.docVerwNichterscheinen.Location = new System.Drawing.Point(176, 370);
            this.docVerwNichterscheinen.Name = "docVerwNichterscheinen";
            this.docVerwNichterscheinen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docVerwNichterscheinen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docVerwNichterscheinen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docVerwNichterscheinen.Properties.Appearance.Options.UseBackColor = true;
            this.docVerwNichterscheinen.Properties.Appearance.Options.UseBorderColor = true;
            this.docVerwNichterscheinen.Properties.Appearance.Options.UseFont = true;
            this.docVerwNichterscheinen.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docVerwNichterscheinen.Properties.AppearanceDisabled.Options.UseFont = true;
            this.docVerwNichterscheinen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject81.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject81.Options.UseBackColor = true;
            serializableAppearanceObject82.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject82.Options.UseBackColor = true;
            serializableAppearanceObject83.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject83.Options.UseBackColor = true;
            serializableAppearanceObject84.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject84.Options.UseBackColor = true;
            this.docVerwNichterscheinen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docVerwNichterscheinen.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject81, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docVerwNichterscheinen.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject82, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docVerwNichterscheinen.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject83, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docVerwNichterscheinen.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject84, "Dokument importieren")});
            this.docVerwNichterscheinen.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docVerwNichterscheinen.Properties.ReadOnly = true;
            this.docVerwNichterscheinen.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docVerwNichterscheinen.Size = new System.Drawing.Size(136, 24);
            this.docVerwNichterscheinen.TabIndex = 608;
            // 
            // docVerwRegelverstoss
            // 
            this.docVerwRegelverstoss.Context = "KaQEEPQVerwRegelverstoss";
            this.docVerwRegelverstoss.DataMember = "VerwRegelverstossDokID";
            this.docVerwRegelverstoss.DataSource = this.qryEPQ;
            this.docVerwRegelverstoss.Location = new System.Drawing.Point(176, 340);
            this.docVerwRegelverstoss.Name = "docVerwRegelverstoss";
            this.docVerwRegelverstoss.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docVerwRegelverstoss.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docVerwRegelverstoss.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docVerwRegelverstoss.Properties.Appearance.Options.UseBackColor = true;
            this.docVerwRegelverstoss.Properties.Appearance.Options.UseBorderColor = true;
            this.docVerwRegelverstoss.Properties.Appearance.Options.UseFont = true;
            this.docVerwRegelverstoss.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docVerwRegelverstoss.Properties.AppearanceDisabled.Options.UseFont = true;
            this.docVerwRegelverstoss.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject85.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject85.Options.UseBackColor = true;
            serializableAppearanceObject86.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject86.Options.UseBackColor = true;
            serializableAppearanceObject87.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject87.Options.UseBackColor = true;
            serializableAppearanceObject88.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject88.Options.UseBackColor = true;
            this.docVerwRegelverstoss.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docVerwRegelverstoss.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject85, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docVerwRegelverstoss.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject86, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docVerwRegelverstoss.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject87, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docVerwRegelverstoss.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject88, "Dokument importieren")});
            this.docVerwRegelverstoss.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docVerwRegelverstoss.Properties.ReadOnly = true;
            this.docVerwRegelverstoss.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docVerwRegelverstoss.Size = new System.Drawing.Size(136, 24);
            this.docVerwRegelverstoss.TabIndex = 607;
            // 
            // lblAufforderung
            // 
            this.lblAufforderung.Location = new System.Drawing.Point(15, 170);
            this.lblAufforderung.Name = "lblAufforderung";
            this.lblAufforderung.Size = new System.Drawing.Size(145, 24);
            this.lblAufforderung.TabIndex = 606;
            this.lblAufforderung.Text = "Aufforderung";
            // 
            // lblVereinbarung
            // 
            this.lblVereinbarung.Location = new System.Drawing.Point(15, 270);
            this.lblVereinbarung.Name = "lblVereinbarung";
            this.lblVereinbarung.Size = new System.Drawing.Size(110, 24);
            this.lblVereinbarung.TabIndex = 605;
            this.lblVereinbarung.Text = "Vereinbarung";
            // 
            // lblProgAbbruch
            // 
            this.lblProgAbbruch.Location = new System.Drawing.Point(15, 409);
            this.lblProgAbbruch.Name = "lblProgAbbruch";
            this.lblProgAbbruch.Size = new System.Drawing.Size(125, 24);
            this.lblProgAbbruch.TabIndex = 604;
            this.lblProgAbbruch.Text = "Programmabbruch";
            // 
            // docProgAbbruch
            // 
            this.docProgAbbruch.Context = "KaQEEPQProgAbbruch";
            this.docProgAbbruch.DataMember = "ProgAbbruchDokID";
            this.docProgAbbruch.DataSource = this.qryEPQ;
            this.docProgAbbruch.Location = new System.Drawing.Point(176, 409);
            this.docProgAbbruch.Name = "docProgAbbruch";
            this.docProgAbbruch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docProgAbbruch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docProgAbbruch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docProgAbbruch.Properties.Appearance.Options.UseBackColor = true;
            this.docProgAbbruch.Properties.Appearance.Options.UseBorderColor = true;
            this.docProgAbbruch.Properties.Appearance.Options.UseFont = true;
            this.docProgAbbruch.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docProgAbbruch.Properties.AppearanceDisabled.Options.UseFont = true;
            this.docProgAbbruch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject89.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject89.Options.UseBackColor = true;
            serializableAppearanceObject90.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject90.Options.UseBackColor = true;
            serializableAppearanceObject91.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject91.Options.UseBackColor = true;
            serializableAppearanceObject92.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject92.Options.UseBackColor = true;
            this.docProgAbbruch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docProgAbbruch.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject89, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docProgAbbruch.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject90, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docProgAbbruch.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject91, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docProgAbbruch.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject92, "Dokument importieren")});
            this.docProgAbbruch.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docProgAbbruch.Properties.ReadOnly = true;
            this.docProgAbbruch.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docProgAbbruch.Size = new System.Drawing.Size(136, 24);
            this.docProgAbbruch.TabIndex = 50;
            // 
            // docVereinbarung2
            // 
            this.docVereinbarung2.Context = "KaQEEPQVereinbarung";
            this.docVereinbarung2.DataMember = "Vereinbarung2DokID";
            this.docVereinbarung2.DataSource = this.qryEPQ;
            this.docVereinbarung2.Location = new System.Drawing.Point(176, 300);
            this.docVereinbarung2.Name = "docVereinbarung2";
            this.docVereinbarung2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docVereinbarung2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docVereinbarung2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docVereinbarung2.Properties.Appearance.Options.UseBackColor = true;
            this.docVereinbarung2.Properties.Appearance.Options.UseBorderColor = true;
            this.docVereinbarung2.Properties.Appearance.Options.UseFont = true;
            this.docVereinbarung2.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docVereinbarung2.Properties.AppearanceDisabled.Options.UseFont = true;
            this.docVereinbarung2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject93.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject93.Options.UseBackColor = true;
            serializableAppearanceObject94.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject94.Options.UseBackColor = true;
            serializableAppearanceObject95.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject95.Options.UseBackColor = true;
            serializableAppearanceObject96.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject96.Options.UseBackColor = true;
            this.docVereinbarung2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docVereinbarung2.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject93, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docVereinbarung2.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject94, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docVereinbarung2.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject95, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docVereinbarung2.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject96, "Dokument importieren")});
            this.docVereinbarung2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docVereinbarung2.Properties.ReadOnly = true;
            this.docVereinbarung2.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docVereinbarung2.Size = new System.Drawing.Size(136, 24);
            this.docVereinbarung2.TabIndex = 49;
            // 
            // docVereinbarung1
            // 
            this.docVereinbarung1.Context = "KaQEEPQVereinbarung";
            this.docVereinbarung1.DataMember = "Vereinbarung1DokID";
            this.docVereinbarung1.DataSource = this.qryEPQ;
            this.docVereinbarung1.Location = new System.Drawing.Point(176, 270);
            this.docVereinbarung1.Name = "docVereinbarung1";
            this.docVereinbarung1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docVereinbarung1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docVereinbarung1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docVereinbarung1.Properties.Appearance.Options.UseBackColor = true;
            this.docVereinbarung1.Properties.Appearance.Options.UseBorderColor = true;
            this.docVereinbarung1.Properties.Appearance.Options.UseFont = true;
            this.docVereinbarung1.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docVereinbarung1.Properties.AppearanceDisabled.Options.UseFont = true;
            this.docVereinbarung1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject97.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject97.Options.UseBackColor = true;
            serializableAppearanceObject98.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject98.Options.UseBackColor = true;
            serializableAppearanceObject99.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject99.Options.UseBackColor = true;
            serializableAppearanceObject100.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject100.Options.UseBackColor = true;
            this.docVereinbarung1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docVereinbarung1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject97, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docVereinbarung1.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject98, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docVereinbarung1.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject99, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docVereinbarung1.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject100, "Dokument importieren")});
            this.docVereinbarung1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docVereinbarung1.Properties.ReadOnly = true;
            this.docVereinbarung1.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docVereinbarung1.Size = new System.Drawing.Size(136, 24);
            this.docVereinbarung1.TabIndex = 48;
            // 
            // docAufforderung3
            // 
            this.docAufforderung3.Context = "KaQEEPQAufforderung";
            this.docAufforderung3.DataMember = "Aufforderung3DokID";
            this.docAufforderung3.DataSource = this.qryEPQ;
            this.docAufforderung3.Location = new System.Drawing.Point(176, 230);
            this.docAufforderung3.Name = "docAufforderung3";
            this.docAufforderung3.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docAufforderung3.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docAufforderung3.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docAufforderung3.Properties.Appearance.Options.UseBackColor = true;
            this.docAufforderung3.Properties.Appearance.Options.UseBorderColor = true;
            this.docAufforderung3.Properties.Appearance.Options.UseFont = true;
            this.docAufforderung3.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docAufforderung3.Properties.AppearanceDisabled.Options.UseFont = true;
            this.docAufforderung3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject101.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject101.Options.UseBackColor = true;
            serializableAppearanceObject102.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject102.Options.UseBackColor = true;
            serializableAppearanceObject103.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject103.Options.UseBackColor = true;
            serializableAppearanceObject104.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject104.Options.UseBackColor = true;
            this.docAufforderung3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docAufforderung3.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject101, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docAufforderung3.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject102, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docAufforderung3.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject103, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docAufforderung3.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject104, "Dokument importieren")});
            this.docAufforderung3.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docAufforderung3.Properties.ReadOnly = true;
            this.docAufforderung3.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docAufforderung3.Size = new System.Drawing.Size(136, 24);
            this.docAufforderung3.TabIndex = 47;
            // 
            // docAufforderung2
            // 
            this.docAufforderung2.Context = "KaQEEPQAufforderung";
            this.docAufforderung2.DataMember = "Aufforderung2DokID";
            this.docAufforderung2.DataSource = this.qryEPQ;
            this.docAufforderung2.Location = new System.Drawing.Point(176, 200);
            this.docAufforderung2.Name = "docAufforderung2";
            this.docAufforderung2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docAufforderung2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docAufforderung2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docAufforderung2.Properties.Appearance.Options.UseBackColor = true;
            this.docAufforderung2.Properties.Appearance.Options.UseBorderColor = true;
            this.docAufforderung2.Properties.Appearance.Options.UseFont = true;
            this.docAufforderung2.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docAufforderung2.Properties.AppearanceDisabled.Options.UseFont = true;
            this.docAufforderung2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject105.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject105.Options.UseBackColor = true;
            serializableAppearanceObject106.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject106.Options.UseBackColor = true;
            serializableAppearanceObject107.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject107.Options.UseBackColor = true;
            serializableAppearanceObject108.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject108.Options.UseBackColor = true;
            this.docAufforderung2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docAufforderung2.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject105, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docAufforderung2.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject106, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docAufforderung2.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject107, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docAufforderung2.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject108, "Dokument importieren")});
            this.docAufforderung2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docAufforderung2.Properties.ReadOnly = true;
            this.docAufforderung2.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docAufforderung2.Size = new System.Drawing.Size(136, 24);
            this.docAufforderung2.TabIndex = 46;
            // 
            // docAufforderung1
            // 
            this.docAufforderung1.Context = "KaQEEPQAufforderung";
            this.docAufforderung1.DataMember = "Aufforderung1DokID";
            this.docAufforderung1.DataSource = this.qryEPQ;
            this.docAufforderung1.Location = new System.Drawing.Point(176, 170);
            this.docAufforderung1.Name = "docAufforderung1";
            this.docAufforderung1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docAufforderung1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docAufforderung1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docAufforderung1.Properties.Appearance.Options.UseBackColor = true;
            this.docAufforderung1.Properties.Appearance.Options.UseBorderColor = true;
            this.docAufforderung1.Properties.Appearance.Options.UseFont = true;
            this.docAufforderung1.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docAufforderung1.Properties.AppearanceDisabled.Options.UseFont = true;
            this.docAufforderung1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject109.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject109.Options.UseBackColor = true;
            serializableAppearanceObject110.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject110.Options.UseBackColor = true;
            serializableAppearanceObject111.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject111.Options.UseBackColor = true;
            serializableAppearanceObject112.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject112.Options.UseBackColor = true;
            this.docAufforderung1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docAufforderung1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject109, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docAufforderung1.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject110, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docAufforderung1.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject111, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docAufforderung1.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject112, "Dokument importieren")});
            this.docAufforderung1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docAufforderung1.Properties.ReadOnly = true;
            this.docAufforderung1.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docAufforderung1.Size = new System.Drawing.Size(136, 24);
            this.docAufforderung1.TabIndex = 45;
            // 
            // memMuendAufford2
            // 
            this.memMuendAufford2.DataMember = "muendAuffordBem2";
            this.memMuendAufford2.DataSource = this.qryEPQ;
            this.memMuendAufford2.Location = new System.Drawing.Point(415, 75);
            this.memMuendAufford2.Name = "memMuendAufford2";
            this.memMuendAufford2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memMuendAufford2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memMuendAufford2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memMuendAufford2.Properties.Appearance.Options.UseBackColor = true;
            this.memMuendAufford2.Properties.Appearance.Options.UseBorderColor = true;
            this.memMuendAufford2.Properties.Appearance.Options.UseFont = true;
            this.memMuendAufford2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memMuendAufford2.Size = new System.Drawing.Size(375, 75);
            this.memMuendAufford2.TabIndex = 44;
            // 
            // datMuendAufford2
            // 
            this.datMuendAufford2.DataMember = "muendAuffordDat2";
            this.datMuendAufford2.DataSource = this.qryEPQ;
            this.datMuendAufford2.EditValue = null;
            this.datMuendAufford2.Location = new System.Drawing.Point(415, 45);
            this.datMuendAufford2.Name = "datMuendAufford2";
            this.datMuendAufford2.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datMuendAufford2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.datMuendAufford2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datMuendAufford2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datMuendAufford2.Properties.Appearance.Options.UseBackColor = true;
            this.datMuendAufford2.Properties.Appearance.Options.UseBorderColor = true;
            this.datMuendAufford2.Properties.Appearance.Options.UseFont = true;
            this.datMuendAufford2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject113.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject113.Options.UseBackColor = true;
            this.datMuendAufford2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datMuendAufford2.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject113)});
            this.datMuendAufford2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datMuendAufford2.Properties.ShowToday = false;
            this.datMuendAufford2.Size = new System.Drawing.Size(89, 24);
            this.datMuendAufford2.TabIndex = 43;
            // 
            // memMuendAufford1
            // 
            this.memMuendAufford1.DataMember = "muendAuffordBem1";
            this.memMuendAufford1.DataSource = this.qryEPQ;
            this.memMuendAufford1.Location = new System.Drawing.Point(15, 75);
            this.memMuendAufford1.Name = "memMuendAufford1";
            this.memMuendAufford1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memMuendAufford1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memMuendAufford1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memMuendAufford1.Properties.Appearance.Options.UseBackColor = true;
            this.memMuendAufford1.Properties.Appearance.Options.UseBorderColor = true;
            this.memMuendAufford1.Properties.Appearance.Options.UseFont = true;
            this.memMuendAufford1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memMuendAufford1.Size = new System.Drawing.Size(375, 75);
            this.memMuendAufford1.TabIndex = 42;
            // 
            // lblMuendAufforderung
            // 
            this.lblMuendAufforderung.Location = new System.Drawing.Point(15, 15);
            this.lblMuendAufforderung.Name = "lblMuendAufforderung";
            this.lblMuendAufforderung.Size = new System.Drawing.Size(215, 24);
            this.lblMuendAufforderung.TabIndex = 212;
            this.lblMuendAufforderung.Text = "mündliche Aufforderung";
            // 
            // datMuendAufford1
            // 
            this.datMuendAufford1.DataMember = "muendAuffordDat1";
            this.datMuendAufford1.DataSource = this.qryEPQ;
            this.datMuendAufford1.EditValue = null;
            this.datMuendAufford1.Location = new System.Drawing.Point(15, 45);
            this.datMuendAufford1.Name = "datMuendAufford1";
            this.datMuendAufford1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datMuendAufford1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.datMuendAufford1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datMuendAufford1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datMuendAufford1.Properties.Appearance.Options.UseBackColor = true;
            this.datMuendAufford1.Properties.Appearance.Options.UseBorderColor = true;
            this.datMuendAufford1.Properties.Appearance.Options.UseFont = true;
            this.datMuendAufford1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject114.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject114.Options.UseBackColor = true;
            this.datMuendAufford1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datMuendAufford1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject114)});
            this.datMuendAufford1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datMuendAufford1.Properties.ShowToday = false;
            this.datMuendAufford1.Size = new System.Drawing.Size(89, 24);
            this.datMuendAufford1.TabIndex = 41;
            // 
            // tpgAustritt
            // 
            this.tpgAustritt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.tpgAustritt.Controls.Add(this.lblAustrittBem);
            this.tpgAustritt.Controls.Add(this.lblGrund);
            this.tpgAustritt.Controls.Add(this.lblAustrittDatum);
            this.tpgAustritt.Controls.Add(this.btnReset);
            this.tpgAustritt.Controls.Add(this.memAustrittBem);
            this.tpgAustritt.Controls.Add(this.ddlGrund);
            this.tpgAustritt.Controls.Add(this.rgGrund);
            this.tpgAustritt.Controls.Add(this.datAustrittDatum);
            this.tpgAustritt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tpgAustritt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tpgAustritt.Location = new System.Drawing.Point(6, 32);
            this.tpgAustritt.Name = "tpgAustritt";
            this.tpgAustritt.Size = new System.Drawing.Size(978, 577);
            this.tpgAustritt.TabIndex = 5;
            this.tpgAustritt.Title = "Austritt";
            // 
            // lblAustrittBem
            // 
            this.lblAustrittBem.Location = new System.Drawing.Point(15, 158);
            this.lblAustrittBem.Name = "lblAustrittBem";
            this.lblAustrittBem.Size = new System.Drawing.Size(276, 24);
            this.lblAustrittBem.TabIndex = 626;
            this.lblAustrittBem.Text = "Bemerkungen";
            // 
            // lblGrund
            // 
            this.lblGrund.Location = new System.Drawing.Point(15, 60);
            this.lblGrund.Name = "lblGrund";
            this.lblGrund.Size = new System.Drawing.Size(101, 24);
            this.lblGrund.TabIndex = 625;
            this.lblGrund.Text = "Austrittsgrund";
            // 
            // lblAustrittDatum
            // 
            this.lblAustrittDatum.Location = new System.Drawing.Point(15, 20);
            this.lblAustrittDatum.Name = "lblAustrittDatum";
            this.lblAustrittDatum.Size = new System.Drawing.Size(101, 24);
            this.lblAustrittDatum.TabIndex = 624;
            this.lblAustrittDatum.Text = "Datum";
            // 
            // btnReset
            // 
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Location = new System.Drawing.Point(580, 60);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(107, 24);
            this.btnReset.TabIndex = 623;
            this.btnReset.Text = "zurücksetzen";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // memAustrittBem
            // 
            this.memAustrittBem.DataMember = "AustrittBemerkung";
            this.memAustrittBem.DataSource = this.qryEPQ;
            this.memAustrittBem.Location = new System.Drawing.Point(15, 185);
            this.memAustrittBem.Name = "memAustrittBem";
            this.memAustrittBem.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memAustrittBem.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memAustrittBem.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memAustrittBem.Properties.Appearance.Options.UseBackColor = true;
            this.memAustrittBem.Properties.Appearance.Options.UseBorderColor = true;
            this.memAustrittBem.Properties.Appearance.Options.UseFont = true;
            this.memAustrittBem.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memAustrittBem.Size = new System.Drawing.Size(547, 105);
            this.memAustrittBem.TabIndex = 54;
            // 
            // ddlGrund
            // 
            this.ddlGrund.DataMember = "AustrittCode";
            this.ddlGrund.DataSource = this.qryEPQ;
            this.ddlGrund.Location = new System.Drawing.Point(336, 60);
            this.ddlGrund.LOVName = "KaQeAustrittGrund";
            this.ddlGrund.Name = "ddlGrund";
            this.ddlGrund.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlGrund.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlGrund.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlGrund.Properties.Appearance.Options.UseBackColor = true;
            this.ddlGrund.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlGrund.Properties.Appearance.Options.UseFont = true;
            this.ddlGrund.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlGrund.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlGrund.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlGrund.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlGrund.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject115.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject115.Options.UseBackColor = true;
            this.ddlGrund.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject115)});
            this.ddlGrund.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlGrund.Properties.NullText = "";
            this.ddlGrund.Properties.ShowFooter = false;
            this.ddlGrund.Properties.ShowHeader = false;
            this.ddlGrund.Size = new System.Drawing.Size(226, 24);
            this.ddlGrund.TabIndex = 53;
            // 
            // rgGrund
            // 
            this.rgGrund.DataMember = "AustrittGrund";
            this.rgGrund.DataSource = this.qryEPQ;
            this.rgGrund.EditValue = "";
            this.rgGrund.Location = new System.Drawing.Point(122, 58);
            this.rgGrund.LookupSQL = null;
            this.rgGrund.LOVFilter = null;
            this.rgGrund.LOVName = null;
            this.rgGrund.Name = "rgGrund";
            this.rgGrund.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgGrund.Properties.Appearance.Options.UseBackColor = true;
            this.rgGrund.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.rgGrund.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.rgGrund.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgGrund.Properties.Columns = 1;
            this.rgGrund.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Massnahme beendet"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Arbeitgeber Abbruch"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(3, "Arbeitnehmer Abbruch"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(4, "Gegenseitiger Abbruch")});
            this.rgGrund.Size = new System.Drawing.Size(169, 94);
            this.rgGrund.TabIndex = 52;
            this.rgGrund.SelectedIndexChanged += new System.EventHandler(this.rgGrund_SelectedIndexChanged);
            this.rgGrund.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.rgGrund_EditValueChanging);
            // 
            // datAustrittDatum
            // 
            this.datAustrittDatum.DataMember = "AustrittDatum";
            this.datAustrittDatum.DataSource = this.qryEPQ;
            this.datAustrittDatum.EditValue = null;
            this.datAustrittDatum.Location = new System.Drawing.Point(122, 20);
            this.datAustrittDatum.Name = "datAustrittDatum";
            this.datAustrittDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datAustrittDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.datAustrittDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datAustrittDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datAustrittDatum.Properties.Appearance.Options.UseBackColor = true;
            this.datAustrittDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.datAustrittDatum.Properties.Appearance.Options.UseFont = true;
            this.datAustrittDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject116.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject116.Options.UseBackColor = true;
            this.datAustrittDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datAustrittDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject116)});
            this.datAustrittDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datAustrittDatum.Properties.ShowToday = false;
            this.datAustrittDatum.Size = new System.Drawing.Size(89, 24);
            this.datAustrittDatum.TabIndex = 51;
            // 
            // CtlKaQEEPQ
            // 
            this.ActiveSQLQuery = this.qryEPQ;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(980, 725);
            this.Controls.Add(this.tabControlEPQ);
            this.Controls.Add(this.pnlHead);
            this.Controls.Add(this.pnlTitle);
            this.Name = "CtlKaQEEPQ";
            this.Size = new System.Drawing.Size(990, 735);
            this.Load += new System.EventHandler(this.CtlKaQEEPQ_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAnweisung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datEintritt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEintritt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datAustritt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAustritt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeschGrad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProzent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeschGrad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRavBerater.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRAVBerater)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCoach.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCoach)).EndInit();
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.pnlHead.ResumeLayout(false);
            this.tabControlEPQ.ResumeLayout(false);
            this.tpgProzessuebersicht.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.docVerlaengerung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryEPQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVerlaengerung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZwischenzeugnis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docZwischenzeugnis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblArbeitszeugnis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docArbeitszeugnis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datVerlaengerung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerlängerung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZwischenbericht2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docZwischenbericht2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZielVereinb2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonalblatt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIntegBildung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryIntegBildung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvIntegBildung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datZielVereinb2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryDates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZielVereinb1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datZielVereinb1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docTaetigProg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docPrzStandortBestimmung2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docPrzStandortBestimmung1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docPersonalblatt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSchlussbericht2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docSchlussbericht2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSchlussbericht1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docSchlussbericht1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZwischenbericht1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docZwischenbericht1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStaoDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datStaoDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTaetigProg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPrzStandortBestimmung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVerlauf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVerlauf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvVerlauf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            this.tpgIntake.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.docIntakeVorstellungsgespraech.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIntakeVorstellungsgespraech)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProgBeginn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chlIntakeCodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docEinladungProgBeginn2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docEinladungProgBeginn1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docAntwortAnbieter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAntwortAnbieter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinladugProgBeginn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memBemerkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgProgBeginn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgProgBeginn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docEinladung2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docEinladung1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datEinladung2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinladung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datEinladung1.Properties)).EndInit();
            this.tpgZielVereinbarung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtErreichenBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZielvereinb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErreichenBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memErgebnis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErgebnis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memMessungZielerreichung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMessungZielerreichung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memFeinziel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFeinziel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFeinziel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZielvereinb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvZielvereinb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docIndivZieleRAV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memIndivZieleRAV.Properties)).EndInit();
            this.tpgZielVereinbarungVerl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtErreichenBisVerl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZielvereinbVerl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErreichenBisVerl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memErgebnisVerl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErgebnisVerl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memMessungZielerreichungVerl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMessungZielerreichungVerl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memFeinzielVerl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFeinzielVerl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFeinzielVerl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZielvereinbVerl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvZielvereinbVerl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docIndivZieleRAVVerl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memIndivZieleRAVVerl.Properties)).EndInit();
            this.tpgInterventionen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwNichterscheinen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwRegelverstoss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docVerwNichterscheinen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docVerwRegelverstoss.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAufforderung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVereinbarung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProgAbbruch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docProgAbbruch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docVereinbarung2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docVereinbarung1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docAufforderung3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docAufforderung2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docAufforderung1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memMuendAufford2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datMuendAufford2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memMuendAufford1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMuendAufforderung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datMuendAufford1.Properties)).EndInit();
            this.tpgAustritt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblAustrittBem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAustrittDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memAustrittBem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlGrund.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlGrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgGrund.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgGrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datAustrittDatum.Properties)).EndInit();
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
                if (components != null)
                {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        #endregion
    }
}
