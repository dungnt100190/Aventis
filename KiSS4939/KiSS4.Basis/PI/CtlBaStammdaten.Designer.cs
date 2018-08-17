using System.Windows.Forms;
using KiSS4.DB;
using KiSS4.Gui;
using SharpLibrary.WinControls;
namespace KiSS4.Basis.PI
{
    partial class CtlBaStammdaten
    {
        private KiSS4.Gui.KissButton btnIVBerechtigungBearbeiten;
        private KiSS4.Gui.KissButton btnKZSAdd;
        private KiSS4.Gui.KissButton btnKZSRemove;
        private KiSS4.Gui.KissCheckEdit chkALK;
        private KissCheckEdit chkBPZeigeTelGeschaeft;
        private KissCheckEdit chkBPZeigeTelMobil;
        private KissCheckEdit chkBPZeigeTelPrivat;
        private KiSS4.Gui.KissCheckEdit chkBVGRente;
        private KiSS4.Gui.KissCheckEdit chkBeruflicheMassnahmeIV;
        private KissCheckEdit chkEigenerMietvertrag;
        private KiSS4.Gui.KissCheckEdit chkErgaenzungsLeistungen;
        private KiSS4.Gui.KissCheckEdit chkIVHilfsmittel;
        private KiSS4.Gui.KissCheckEdit chkIVTaggeld;
        private KiSS4.Gui.KissCheckEdit chkInCHSeitGeburt;
        private KiSS4.Gui.KissCheckEdit chkKTG;
        private KiSS4.Gui.KissCheckEdit chkKontoFuehrung;
        private KiSS4.Gui.KissCheckEdit chkKurzGleicherHaushalt;
        private KissCheckEdit chkKurzKeinSerienbrief;
        private KissCheckEdit chkKurzManuelleAnrede;
        private KissCheckEdit chkKurzPostfachOhneNr;
        private KiSS4.Gui.KissCheckEdit chkLaufendeVollmachtErlaubnis;
        private KissCheckEdit chkMedizinischeMassnahmeIV;
        private KiSS4.Gui.KissCheckEdit chkMehrfachbehinderungBSV;
        private KissCheckEdit chkMietdepotProInfirmis;
        private KissCheckEdit chkPersonKeinSerienbrief;
        private KissCheckEdit chkPersonManuelleAnrede;
        private KiSS4.Gui.KissCheckEdit chkSozialhilfe;
        private KiSS4.Gui.KissCheckEdit chkUVGRente;
        private KiSS4.Gui.KissCheckEdit chkUVGTaggeld;
        private KiSS4.Gui.KissCheckEdit chkVormundPI;
        private KiSS4.Gui.KissCheckEdit chkZeigeDetails;
        private KissCheckEdit chkZeigeTelGeschaeft;
        private KissCheckEdit chkZeigeTelMobil;
        private KissCheckEdit chkZeigeTelPrivat;
        private DevExpress.XtraGrid.Columns.GridColumn colDienstleistung;
        private DevExpress.XtraGrid.Columns.GridColumn colKZSVerfBaKantonalerZuschussBezeichnung;
        private DevExpress.XtraGrid.Columns.GridColumn colKZSVerfBaKantonalerZuschussID;
        private DevExpress.XtraGrid.Columns.GridColumn colKZSZugtBaKantonalerZuschussBezeichung;
        private DevExpress.XtraGrid.Columns.GridColumn colKZSZugtBaKantonalerZuschussID;
        private DevExpress.XtraGrid.Columns.GridColumn colNameVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colPLZOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colPostfach;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasseNr;
        private DevExpress.XtraGrid.Columns.GridColumn colZusatz;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissLookUpEdit edtAusbildungCode;
        private KiSS4.Gui.KissLookUpEdit edtAuslaenderStatusCode;
        private KiSS4.Gui.KissLookUpEdit edtBSVBehinderungsartCode;
        private KiSS4.Gui.KissTextEdit edtBaPersonID;
        private KiSS4.Gui.KissLookUpEdit edtBehinderungsart2Code;
        private KissTextEdit edtEMail;
        private KiSS4.Gui.KissLookUpEdit edtErwerbssituationCode;
        private KissTextEdit edtFax;
        private KiSS4.Gui.KissTextEdit edtFruehererName;
        private KiSS4.Gui.KissDateEdit edtGeburtsdatum;
        private KiSS4.Gui.KissLookUpEdit edtGeschlechtCode;
        private KissDateEdit edtHelbDatumEntscheid;
        private KiSS4.Gui.KissLookUpEdit edtHauptBehinderungsartCode;
        private KiSS4.Gui.KissButtonEdit edtHeimatGemeinde;
        private KiSS4.Gui.KissDateEdit edtHelbAbWann;
        private KiSS4.Gui.KissDateEdit edtHelbAnmeldung;
        private KiSS4.Gui.KissLookUpEdit edtHelpEntscheid;
        private KiSS4.Gui.KissLookUpEdit edtHilfslosenEntschaedigung;
        private KiSS4.Gui.KissLookUpEdit edtIVBerechtigungAktuellerStatus;
        private KiSS4.Gui.KissCalcEdit edtIVGrad;
        private KiSS4.Gui.KissDateEdit edtInCHSeit;
        private KiSS4.Gui.KissLookUpEdit edtIntensivPflegeZuschlag;
        private KiSS4.Gui.KissTextEdit edtKZSFilter;
        private KissLookUpEdit edtKorrespondenzSpracheCode;
        private KiSS4.Gui.KissTextEdit edtKurzAdresseBezirk;
        private KiSS4.Gui.KissTextEdit edtKurzAdresseHausNr;
        private KiSS4.Gui.KissTextEdit edtKurzAdresseKt;
        private KiSS4.Gui.KissLookUpEdit edtKurzAdresseLand;
        private KiSS4.Gui.KissTextEdit edtKurzAdresseOrt;
        private KiSS4.Gui.KissTextEdit edtKurzAdressePLZ;
        private KiSS4.Gui.KissTextEdit edtKurzAdressePostfach;
        private KiSS4.Gui.KissTextEdit edtKurzAdresseStrasse;
        private KiSS4.Gui.KissTextEdit edtKurzAdresseZusatz;
        private KissTextEdit edtKurzAnrede;
        private KiSS4.Gui.KissLookUpEdit edtKurzBeziehung;
        private KissTextEdit edtKurzBriefanrede;
        private KiSS4.Gui.KissDateEdit edtKurzGeburtsdatum;
        private KiSS4.Gui.KissLookUpEdit edtKurzGeschlechtCode;
        private KiSS4.Gui.KissTextEdit edtKurzKontaktEmail;
        private KiSS4.Gui.KissTextEdit edtKurzKontaktFax;
        private KiSS4.Gui.KissTextEdit edtKurzKontaktTelG;
        private KiSS4.Gui.KissTextEdit edtKurzKontaktTelM;
        private KiSS4.Gui.KissTextEdit edtKurzKontaktTelP;
        private KiSS4.Gui.KissTextEdit edtKurzName;
        private KiSS4.Gui.KissTextEdit edtKurzPersonenNr;
        private KiSS4.Gui.KissLookUpEdit edtKurzSprache;
        private KiSS4.Gui.KissDateEdit edtKurzSterbedatum;
        private KiSS4.Gui.KissTextEdit edtKurzTitel;
        private KiSS4.Gui.KissVersichertenNrEdit edtKurzVersichertenNummer;
        private KiSS4.Gui.KissTextEdit edtKurzVorname;
        private KissTextEdit edtMobilTel;
        private KiSS4.Gui.KissTextEdit edtName;
        private KiSS4.Gui.KissLookUpEdit edtNationalitaetCode;
        private KissTextEdit edtPersonAnrede;
        private KissTextEdit edtPersonBriefanrede;
        private KiSS4.Gui.KissCalcEdit edtPersonKlientenkontoNr;
        private KiSS4.Gui.KissTextEdit edtRechnungsadresseBezirk;
        private KiSS4.Gui.KissLookUpEdit edtRechnungsadresseDL;
        private KiSS4.Gui.KissTextEdit edtRechnungsadresseHausNr;
        private KiSS4.Gui.KissTextEdit edtRechnungsadresseKanton;
        private KiSS4.Gui.KissLookUpEdit edtRechnungsadresseLand;
        private KiSS4.Gui.KissTextEdit edtRechnungsadresseOrt;
        private KiSS4.Gui.KissTextEdit edtRechnungsadressePLZ;
        private KiSS4.Gui.KissTextEdit edtRechnungsadressePostfach;
        private KiSS4.Gui.KissTextEdit edtRechnungsadresseStrasse;
        private KiSS4.Gui.KissTextEdit edtRechnungsadresseVornameName;
        private KiSS4.Gui.KissTextEdit edtRechnungsadresseZusatz;
        private KiSS4.Gui.KissLookUpEdit edtRentenstufe;
        private KiSS4.Gui.KissLookUpEdit edtSprachCode;
        private KiSS4.Gui.KissDateEdit edtSterbedatum;
        private KissTextEdit edtTelefon_G;
        private KissTextEdit edtTelefon_P;
        private KiSS4.Gui.KissTextEdit edtTitel;
        private KiSS4.Gui.KissVersichertenNrEdit edtVersicherungsNr;
        private KiSS4.Gui.KissLookUpEdit edtVormundMassnahmenCode;
        private KiSS4.Gui.KissTextEdit edtVorname;
        private KiSS4.Gui.KissTextEdit edtWichtigerHinweis;
        private KissLookUpEdit edtWohnsituationStatusCode;
        private KiSS4.Gui.KissLookUpEdit edtZivilstandCode;
        private KiSS4.Gui.KissGrid grdKZSVerfuegbar;
        private KiSS4.Gui.KissGrid grdKZSZugeteilt;
        private KiSS4.Gui.KissGrid grdRechnungsadressen;
        private KissGroupBox grpAdresseBemerkungen;
        private KissGroupBox grpBankPostZahlungsverbindungen;
        private KiSS4.Gui.KissGroupBox grpHELB;
        private KiSS4.Gui.KissGroupBox grpIVBerechtigung;
        private KiSS4.Gui.KissGroupBox grpKantonaleZuschuesse;
        private KissGroupBox grpKontakt;
        private KiSS4.Gui.KissGroupBox grpKurzKontakt;
        private KiSS4.Gui.KissGroupBox grpKurzWohnsitz;
        private KissGroupBox grpWohnsitzDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKZSVerfuegbar;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKZSZugeteilt;
        private DevExpress.XtraGrid.Views.Grid.GridView grvRechnungsadressen;
        private KiSS4.Gui.KissLabel lblALK;
        private KissLabel lblAdresseWohnstatus;
        private KiSS4.Gui.KissLabel lblAndereSVLeistungen;
        private KiSS4.Gui.KissLabel lblAusbildung;
        private KiSS4.Gui.KissLabel lblAuslStatus;
        private KiSS4.Gui.KissLabel lblBSVBehinderungsart;
        private KiSS4.Gui.KissLabel lblBVGRente;
        private KiSS4.Gui.KissLabel lblBehinderungsart2;
        private KiSS4.Gui.KissLabel lblBeruflicheMassnahmenIV;
        private KissLabel lblEmail;
        private KiSS4.Gui.KissLabel lblErgaenzungsleistungen;
        private KiSS4.Gui.KissLabel lblErwerbssituation;
        private KissLabel lblFax;
        private KiSS4.Gui.KissLabel lblFruehererName;
        private KiSS4.Gui.KissLabel lblGeburt;
        private KiSS4.Gui.KissLabel lblGeschlecht;
        private KissLabel lblHelbDatumEntscheid;
        private KiSS4.Gui.KissLabel lblHauptbehinderungsArt;
        private KiSS4.Gui.KissLabel lblHeimatGemeinde;
        private KiSS4.Gui.KissLabel lblHelbAbWann;
        private KiSS4.Gui.KissLabel lblHelbAnmeldung;
        private KiSS4.Gui.KissLabel lblHelbEntscheid;
        private KiSS4.Gui.KissLabel lblHilfslosenentschaedigung;
        private KiSS4.Gui.KissLabel lblIVBerechtigungAktuellerStatus;
        private KiSS4.Gui.KissLabel lblIVGrad;
        private KiSS4.Gui.KissLabel lblIVGradProzent;
        private KiSS4.Gui.KissLabel lblIVHilfsmittel;
        private KiSS4.Gui.KissLabel lblIVTaggeld;
        private KiSS4.Gui.KissLabel lblInCHSeit;
        private KiSS4.Gui.KissLabel lblIntensivPflegeZuschlag;
        private KiSS4.Gui.KissLabel lblKTG;
        private KiSS4.Gui.KissLabel lblKZSFilter;
        private KissLabel lblKorrespondenzSprache;
        private KiSS4.Gui.KissLabel lblKurzAdresseBezirk;
        private KiSS4.Gui.KissLabel lblKurzAdresseLand;
        private KiSS4.Gui.KissLabel lblKurzAdressePLZOrtKt;
        private KiSS4.Gui.KissLabel lblKurzAdressePostfach;
        private KiSS4.Gui.KissLabel lblKurzAdresseStrasseNr;
        private KiSS4.Gui.KissLabel lblKurzAdresseZusatz;
        private KissLabel lblKurzAnrede;
        private KiSS4.Gui.KissLabel lblKurzBemerkungen;
        private KiSS4.Gui.KissLabel lblKurzBeziehung;
        private KissLabel lblKurzBriefanrede;
        private KiSS4.Gui.KissLabel lblKurzGeburt;
        private KiSS4.Gui.KissLabel lblKurzGeschlecht;
        private KiSS4.Gui.KissLabel lblKurzKontaktEmail;
        private KiSS4.Gui.KissLabel lblKurzKontaktFax;
        private KiSS4.Gui.KissLabel lblKurzKontaktTelG;
        private KiSS4.Gui.KissLabel lblKurzKontaktTelM;
        private KiSS4.Gui.KissLabel lblKurzKontaktTelP;
        private KiSS4.Gui.KissLabel lblKurzNameVorname;
        private KiSS4.Gui.KissLabel lblKurzPersonenNr;
        private KiSS4.Gui.KissLabel lblKurzSprache;
        private KiSS4.Gui.KissLabel lblKurzTitel;
        private KiSS4.Gui.KissLabel lblKurzTod;
        private KiSS4.Gui.KissLabel lblKurzVersichertenNummer;
        private KissLabel lblMedizinischeMassnahmeIV;
        private KiSS4.Gui.KissLabel lblNameVorname;
        private KiSS4.Gui.KissLabel lblNation;
        private KissLabel lblPersonAnrede;
        private KissLabel lblPersonBriefanrede;
        private KiSS4.Gui.KissLabel lblPersonKlientenkontoNr;
        private KiSS4.Gui.KissLabel lblPersonNumber;
        private KiSS4.Gui.KissLabel lblPersonTitel;
        private KiSS4.Gui.KissLabel lblPersonalienBemerkungen;
        private KiSS4.Gui.KissLabel lblRechnungsadresseBemerkungen;
        private KiSS4.Gui.KissLabel lblRechnungsadresseBezirk;
        private KiSS4.Gui.KissLabel lblRechnungsadresseDL;
        private KiSS4.Gui.KissLabel lblRechnungsadresseLand;
        private KiSS4.Gui.KissLabel lblRechnungsadresseNameVorname;
        private KiSS4.Gui.KissLabel lblRechnungsadressePLZOrtKt;
        private KiSS4.Gui.KissLabel lblRechnungsadressePostfach;
        private KiSS4.Gui.KissLabel lblRechnungsadresseStrasseNr;
        private KiSS4.Gui.KissLabel lblRechnungsadresseZusatz;
        private KiSS4.Gui.KissLabel lblRentenstufe;
        private KiSS4.Gui.KissLabel lblSozialhilfe;
        private KiSS4.Gui.KissLabel lblSozialversicherungBemerkungen;
        private KiSS4.Gui.KissLabel lblSprache;
        private KissLabel lblTelefonGeschaeft;
        private KissLabel lblTelefonMobil;
        private KissLabel lblTelefonPrivat;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblTod;
        private KiSS4.Gui.KissLabel lblUVGRente;
        private KiSS4.Gui.KissLabel lblUVGTaggeld;
        private KiSS4.Gui.KissLabel lblVersicherungsNr;
        private KiSS4.Gui.KissLabel lblVormundschaftlicheMassnahmen;
        private KiSS4.Gui.KissLabel lblWichtigerHinweis;
        private KiSS4.Gui.KissLabel lblZeigeDetails;
        private KiSS4.Gui.KissLabel lblZivilstand;
        private KiSS4.Gui.KissMemoEdit memAndereSVLeistungen;
        private KissMemoEdit memBemerkungenAdresse;
        private KiSS4.Gui.KissRTFEdit memBemerkungenPersonalien;
        private KiSS4.Gui.KissMemoEdit memBemerkungenSV;
        private KiSS4.Gui.KissRTFEdit memKurzBemerkungen;
        private KiSS4.Gui.KissMemoEdit memRechnungsadresseBemerkungen;
        private Panel panKontakt;
        private System.Windows.Forms.Panel panRechnungsadressenUnten;
        private TableLayoutPanel panTblAdresseBottom;
        private System.Windows.Forms.Panel panTitel;
        private System.Windows.Forms.PictureBox picTitel;
        private System.Windows.Forms.PictureBox picWichtigerHinweis;
        private System.Windows.Forms.Panel pnlTab;
        private SqlQuery qryBaAdresseBezugsperson;
        private KiSS4.DB.SqlQuery qryBaPerson;
        private KiSS4.DB.SqlQuery qryPersonRelation;
        private KiSS4.DB.SqlQuery qryRechnungsadressen;
        private KiSS4.DB.SqlQuery qryRelationFemale;
        private KiSS4.DB.SqlQuery qryRelationGeneric;
        private KiSS4.DB.SqlQuery qryRelationMale;
        private KiSS4.Gui.KissTabControlEx tabStammdaten;
        private SharpLibrary.WinControls.TabPageEx tpgAdresse;
        private TabPageEx tpgKontaktBankPost;
        private SharpLibrary.WinControls.TabPageEx tpgKurz;
        private SharpLibrary.WinControls.TabPageEx tpgPersonalien;
        private SharpLibrary.WinControls.TabPageEx tpgRechnungsadressen;
        private SharpLibrary.WinControls.TabPageEx tpgSozialversicherung;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBaStammdaten));
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
            this.panTitel = new System.Windows.Forms.Panel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.chkZeigeDetails = new KiSS4.Gui.KissCheckEdit();
            this.qryBaPerson = new KiSS4.DB.SqlQuery(this.components);
            this.lblZeigeDetails = new KiSS4.Gui.KissLabel();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.pnlTab = new System.Windows.Forms.Panel();
            this.tabStammdaten = new KiSS4.Gui.KissTabControlEx();
            this.tpgPersonalien = new SharpLibrary.WinControls.TabPageEx();
            this.edtPersonDebitorNr = new KiSS4.Gui.KissCalcEdit();
            this.lblPersonDebitorNr = new KiSS4.Gui.KissLabel();
            this.edtPersonAnrede = new KiSS4.Gui.KissTextEdit();
            this.chkPersonManuelleAnrede = new KiSS4.Gui.KissCheckEdit();
            this.lblPersonBriefanrede = new KiSS4.Gui.KissLabel();
            this.edtPersonBriefanrede = new KiSS4.Gui.KissTextEdit();
            this.lblPersonAnrede = new KiSS4.Gui.KissLabel();
            this.chkPersonKeinSerienbrief = new KiSS4.Gui.KissCheckEdit();
            this.picWichtigerHinweis = new System.Windows.Forms.PictureBox();
            this.memBemerkungenPersonalien = new KiSS4.Gui.KissRTFEdit();
            this.lblPersonalienBemerkungen = new KiSS4.Gui.KissLabel();
            this.edtWichtigerHinweis = new KiSS4.Gui.KissTextEdit();
            this.lblWichtigerHinweis = new KiSS4.Gui.KissLabel();
            this.grpIVBerechtigung = new KiSS4.Gui.KissGroupBox();
            this.btnIVBerechtigungBearbeiten = new KiSS4.Gui.KissButton();
            this.edtIVBerechtigungAktuellerStatus = new KiSS4.Gui.KissLookUpEdit();
            this.lblIVBerechtigungAktuellerStatus = new KiSS4.Gui.KissLabel();
            this.chkVormundPI = new KiSS4.Gui.KissCheckEdit();
            this.edtVormundMassnahmenCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblVormundschaftlicheMassnahmen = new KiSS4.Gui.KissLabel();
            this.edtErwerbssituationCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblErwerbssituation = new KiSS4.Gui.KissLabel();
            this.edtAusbildungCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblAusbildung = new KiSS4.Gui.KissLabel();
            this.chkInCHSeitGeburt = new KiSS4.Gui.KissCheckEdit();
            this.edtInCHSeit = new KiSS4.Gui.KissDateEdit();
            this.lblInCHSeit = new KiSS4.Gui.KissLabel();
            this.edtAuslaenderStatusCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblAuslStatus = new KiSS4.Gui.KissLabel();
            this.edtKorrespondenzSpracheCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtSprachCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblKorrespondenzSprache = new KiSS4.Gui.KissLabel();
            this.lblSprache = new KiSS4.Gui.KissLabel();
            this.edtPersonKlientenkontoNr = new KiSS4.Gui.KissCalcEdit();
            this.lblPersonKlientenkontoNr = new KiSS4.Gui.KissLabel();
            this.edtBaPersonID = new KiSS4.Gui.KissTextEdit();
            this.lblPersonNumber = new KiSS4.Gui.KissLabel();
            this.chkKontoFuehrung = new KiSS4.Gui.KissCheckEdit();
            this.chkMehrfachbehinderungBSV = new KiSS4.Gui.KissCheckEdit();
            this.edtBSVBehinderungsartCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblBSVBehinderungsart = new KiSS4.Gui.KissLabel();
            this.edtBehinderungsart2Code = new KiSS4.Gui.KissLookUpEdit();
            this.lblBehinderungsart2 = new KiSS4.Gui.KissLabel();
            this.edtHauptBehinderungsartCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblHauptbehinderungsArt = new KiSS4.Gui.KissLabel();
            this.edtHeimatGemeinde = new KiSS4.Gui.KissButtonEdit();
            this.lblHeimatGemeinde = new KiSS4.Gui.KissLabel();
            this.edtNationalitaetCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblNation = new KiSS4.Gui.KissLabel();
            this.edtZivilstandCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblZivilstand = new KiSS4.Gui.KissLabel();
            this.edtGeschlechtCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblGeschlecht = new KiSS4.Gui.KissLabel();
            this.edtSterbedatum = new KiSS4.Gui.KissDateEdit();
            this.lblTod = new KiSS4.Gui.KissLabel();
            this.edtGeburtsdatum = new KiSS4.Gui.KissDateEdit();
            this.lblGeburt = new KiSS4.Gui.KissLabel();
            this.edtVersicherungsNr = new KiSS4.Gui.KissVersichertenNrEdit();
            this.lblVersicherungsNr = new KiSS4.Gui.KissLabel();
            this.edtFruehererName = new KiSS4.Gui.KissTextEdit();
            this.lblFruehererName = new KiSS4.Gui.KissLabel();
            this.edtVorname = new KiSS4.Gui.KissTextEdit();
            this.edtName = new KiSS4.Gui.KissTextEdit();
            this.lblNameVorname = new KiSS4.Gui.KissLabel();
            this.edtTitel = new KiSS4.Gui.KissTextEdit();
            this.lblPersonTitel = new KiSS4.Gui.KissLabel();
            this.chkLaufendeVollmachtErlaubnis = new KiSS4.Gui.KissCheckEdit();
            this.tpgAdresse = new SharpLibrary.WinControls.TabPageEx();
            this._ctlBaPersonAdresse = new KiSS4.Basis.CtlBaPersonAdresse();
            this.panTblAdresseBottom = new System.Windows.Forms.TableLayoutPanel();
            this.grpAdresseBemerkungen = new KiSS4.Gui.KissGroupBox();
            this.memBemerkungenAdresse = new KiSS4.Gui.KissMemoEdit();
            this.grpWohnsitzDetails = new KiSS4.Gui.KissGroupBox();
            this.chkEigenerMietvertrag = new KiSS4.Gui.KissCheckEdit();
            this.chkMietdepotProInfirmis = new KiSS4.Gui.KissCheckEdit();
            this.edtWohnsituationStatusCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblAdresseWohnstatus = new KiSS4.Gui.KissLabel();
            this.tpgKontaktBankPost = new SharpLibrary.WinControls.TabPageEx();
            this.grpBankPostZahlungsverbindungen = new KiSS4.Gui.KissGroupBox();
            this._ctlBaZahlungsweg = new KiSS4.Basis.CtlBaZahlungsweg();
            this.panKontakt = new System.Windows.Forms.Panel();
            this.grpKontakt = new KiSS4.Gui.KissGroupBox();
            this.edtEMail = new KiSS4.Gui.KissTextEdit();
            this.lblEmail = new KiSS4.Gui.KissLabel();
            this.edtFax = new KiSS4.Gui.KissTextEdit();
            this.lblFax = new KiSS4.Gui.KissLabel();
            this.chkZeigeTelMobil = new KiSS4.Gui.KissCheckEdit();
            this.edtMobilTel = new KiSS4.Gui.KissTextEdit();
            this.lblTelefonMobil = new KiSS4.Gui.KissLabel();
            this.chkZeigeTelGeschaeft = new KiSS4.Gui.KissCheckEdit();
            this.edtTelefon_G = new KiSS4.Gui.KissTextEdit();
            this.lblTelefonGeschaeft = new KiSS4.Gui.KissLabel();
            this.chkZeigeTelPrivat = new KiSS4.Gui.KissCheckEdit();
            this.edtTelefon_P = new KiSS4.Gui.KissTextEdit();
            this.lblTelefonPrivat = new KiSS4.Gui.KissLabel();
            this.tpgSozialversicherung = new SharpLibrary.WinControls.TabPageEx();
            this.grpAssistenz = new KiSS4.Gui.KissGroupBox();
            this.lblAssistenzbeitrag = new KiSS4.Gui.KissLabel();
            this.lblDatumVerfuegung = new KiSS4.Gui.KissLabel();
            this.edtAssistenzbeitrag = new KiSS4.Gui.KissCheckEdit();
            this.lblABeitragAb = new KiSS4.Gui.KissLabel();
            this.lblIvVerfuegteAssistenzberatung = new KiSS4.Gui.KissLabel();
            this.edtDatumVerfuegung = new KiSS4.Gui.KissDateEdit();
            this.edtIvVerfuegteAssistenzberatung = new KiSS4.Gui.KissCalcEdit();
            this.edtABeitragAb = new KiSS4.Gui.KissDateEdit();
            this.lblIvVerfuegteAssistenzberatungStunden = new KiSS4.Gui.KissLabel();
            this.lblWitwenWitwerWaisenrente = new KiSS4.Gui.KissLabel();
            this.chkWittwenWittwerWaisenrente = new KiSS4.Gui.KissCheckEdit();
            this.memBemerkungenSV = new KiSS4.Gui.KissMemoEdit();
            this.lblSozialversicherungBemerkungen = new KiSS4.Gui.KissLabel();
            this.memAndereSVLeistungen = new KiSS4.Gui.KissMemoEdit();
            this.lblAndereSVLeistungen = new KiSS4.Gui.KissLabel();
            this.chkKTG = new KiSS4.Gui.KissCheckEdit();
            this.lblKTG = new KiSS4.Gui.KissLabel();
            this.chkALK = new KiSS4.Gui.KissCheckEdit();
            this.lblALK = new KiSS4.Gui.KissLabel();
            this.chkSozialhilfe = new KiSS4.Gui.KissCheckEdit();
            this.lblSozialhilfe = new KiSS4.Gui.KissLabel();
            this.chkUVGTaggeld = new KiSS4.Gui.KissCheckEdit();
            this.lblUVGTaggeld = new KiSS4.Gui.KissLabel();
            this.chkUVGRente = new KiSS4.Gui.KissCheckEdit();
            this.lblUVGRente = new KiSS4.Gui.KissLabel();
            this.chkBVGRente = new KiSS4.Gui.KissCheckEdit();
            this.lblBVGRente = new KiSS4.Gui.KissLabel();
            this.chkErgaenzungsLeistungen = new KiSS4.Gui.KissCheckEdit();
            this.lblErgaenzungsleistungen = new KiSS4.Gui.KissLabel();
            this.chkMedizinischeMassnahmeIV = new KiSS4.Gui.KissCheckEdit();
            this.chkIVHilfsmittel = new KiSS4.Gui.KissCheckEdit();
            this.lblMedizinischeMassnahmeIV = new KiSS4.Gui.KissLabel();
            this.lblIVHilfsmittel = new KiSS4.Gui.KissLabel();
            this.chkBeruflicheMassnahmeIV = new KiSS4.Gui.KissCheckEdit();
            this.lblBeruflicheMassnahmenIV = new KiSS4.Gui.KissLabel();
            this.chkIVTaggeld = new KiSS4.Gui.KissCheckEdit();
            this.lblIVTaggeld = new KiSS4.Gui.KissLabel();
            this.edtIntensivPflegeZuschlag = new KiSS4.Gui.KissLookUpEdit();
            this.lblIntensivPflegeZuschlag = new KiSS4.Gui.KissLabel();
            this.grpKantonaleZuschuesse = new KiSS4.Gui.KissGroupBox();
            this.grdKZSZugeteilt = new KiSS4.Gui.KissGrid();
            this.grvKZSZugeteilt = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKZSZugtBaKantonalerZuschussID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKZSZugtBaKantonalerZuschussBezeichung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnKZSRemove = new KiSS4.Gui.KissButton();
            this.btnKZSAdd = new KiSS4.Gui.KissButton();
            this.grdKZSVerfuegbar = new KiSS4.Gui.KissGrid();
            this.grvKZSVerfuegbar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKZSVerfBaKantonalerZuschussID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKZSVerfBaKantonalerZuschussBezeichnung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtKZSFilter = new KiSS4.Gui.KissTextEdit();
            this.lblKZSFilter = new KiSS4.Gui.KissLabel();
            this.grpHELB = new KiSS4.Gui.KissGroupBox();
            this.chkHelbKeinAntrag = new KiSS4.Gui.KissCheckEdit();
            this.lblHelbKeinAntrag = new KiSS4.Gui.KissLabel();
            this.lblHelbDatumEntscheid = new KiSS4.Gui.KissLabel();
            this.edtHelbDatumEntscheid = new KiSS4.Gui.KissDateEdit();
            this.edtHelbAbWann = new KiSS4.Gui.KissDateEdit();
            this.lblHelbAbWann = new KiSS4.Gui.KissLabel();
            this.edtHelpEntscheid = new KiSS4.Gui.KissLookUpEdit();
            this.lblHelbEntscheid = new KiSS4.Gui.KissLabel();
            this.edtHelbAnmeldung = new KiSS4.Gui.KissDateEdit();
            this.lblHelbAnmeldung = new KiSS4.Gui.KissLabel();
            this.edtHilfslosenEntschaedigung = new KiSS4.Gui.KissLookUpEdit();
            this.lblHilfslosenentschaedigung = new KiSS4.Gui.KissLabel();
            this.lblIVGradProzent = new KiSS4.Gui.KissLabel();
            this.edtIVGrad = new KiSS4.Gui.KissCalcEdit();
            this.lblIVGrad = new KiSS4.Gui.KissLabel();
            this.edtRentenstufe = new KiSS4.Gui.KissLookUpEdit();
            this.lblRentenstufe = new KiSS4.Gui.KissLabel();
            this.tpgRechnungsadressen = new SharpLibrary.WinControls.TabPageEx();
            this.grdRechnungsadressen = new KiSS4.Gui.KissGrid();
            this.qryRechnungsadressen = new KiSS4.DB.SqlQuery(this.components);
            this.grvRechnungsadressen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDienstleistung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZusatz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasseNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPostfach = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLZOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panRechnungsadressenUnten = new System.Windows.Forms.Panel();
            this.memRechnungsadresseBemerkungen = new KiSS4.Gui.KissMemoEdit();
            this.lblRechnungsadresseBemerkungen = new KiSS4.Gui.KissLabel();
            this.edtRechnungsadresseLand = new KiSS4.Gui.KissLookUpEdit();
            this.lblRechnungsadresseLand = new KiSS4.Gui.KissLabel();
            this.edtRechnungsadresseBezirk = new KiSS4.Gui.KissTextEdit();
            this.lblRechnungsadresseBezirk = new KiSS4.Gui.KissLabel();
            this.edtRechnungsadresseKanton = new KiSS4.Gui.KissTextEdit();
            this.edtRechnungsadresseOrt = new KiSS4.Gui.KissTextEdit();
            this.edtRechnungsadressePLZ = new KiSS4.Gui.KissTextEdit();
            this.lblRechnungsadressePLZOrtKt = new KiSS4.Gui.KissLabel();
            this.edtRechnungsadressePostfach = new KiSS4.Gui.KissTextEdit();
            this.lblRechnungsadressePostfach = new KiSS4.Gui.KissLabel();
            this.edtRechnungsadresseHausNr = new KiSS4.Gui.KissTextEdit();
            this.edtRechnungsadresseStrasse = new KiSS4.Gui.KissTextEdit();
            this.lblRechnungsadresseStrasseNr = new KiSS4.Gui.KissLabel();
            this.edtRechnungsadresseZusatz = new KiSS4.Gui.KissTextEdit();
            this.lblRechnungsadresseZusatz = new KiSS4.Gui.KissLabel();
            this.edtRechnungsadresseVornameName = new KiSS4.Gui.KissTextEdit();
            this.lblRechnungsadresseNameVorname = new KiSS4.Gui.KissLabel();
            this.edtRechnungsadresseDL = new KiSS4.Gui.KissLookUpEdit();
            this.lblRechnungsadresseDL = new KiSS4.Gui.KissLabel();
            this.tpgKurz = new SharpLibrary.WinControls.TabPageEx();
            this.edtKurzAnrede = new KiSS4.Gui.KissTextEdit();
            this.chkKurzManuelleAnrede = new KiSS4.Gui.KissCheckEdit();
            this.lblKurzBriefanrede = new KiSS4.Gui.KissLabel();
            this.edtKurzBriefanrede = new KiSS4.Gui.KissTextEdit();
            this.lblKurzAnrede = new KiSS4.Gui.KissLabel();
            this.chkKurzKeinSerienbrief = new KiSS4.Gui.KissCheckEdit();
            this.memKurzBemerkungen = new KiSS4.Gui.KissRTFEdit();
            this.lblKurzBemerkungen = new KiSS4.Gui.KissLabel();
            this.chkKurzGleicherHaushalt = new KiSS4.Gui.KissCheckEdit();
            this.qryPersonRelation = new KiSS4.DB.SqlQuery(this.components);
            this.edtKurzBeziehung = new KiSS4.Gui.KissLookUpEdit();
            this.lblKurzBeziehung = new KiSS4.Gui.KissLabel();
            this.edtKurzSprache = new KiSS4.Gui.KissLookUpEdit();
            this.lblKurzSprache = new KiSS4.Gui.KissLabel();
            this.edtKurzGeschlechtCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblKurzGeschlecht = new KiSS4.Gui.KissLabel();
            this.edtKurzSterbedatum = new KiSS4.Gui.KissDateEdit();
            this.lblKurzTod = new KiSS4.Gui.KissLabel();
            this.edtKurzGeburtsdatum = new KiSS4.Gui.KissDateEdit();
            this.lblKurzGeburt = new KiSS4.Gui.KissLabel();
            this.edtKurzVersichertenNummer = new KiSS4.Gui.KissVersichertenNrEdit();
            this.lblKurzVersichertenNummer = new KiSS4.Gui.KissLabel();
            this.edtKurzPersonenNr = new KiSS4.Gui.KissTextEdit();
            this.lblKurzPersonenNr = new KiSS4.Gui.KissLabel();
            this.grpKurzKontakt = new KiSS4.Gui.KissGroupBox();
            this.chkBPZeigeTelMobil = new KiSS4.Gui.KissCheckEdit();
            this.chkBPZeigeTelGeschaeft = new KiSS4.Gui.KissCheckEdit();
            this.chkBPZeigeTelPrivat = new KiSS4.Gui.KissCheckEdit();
            this.edtKurzKontaktEmail = new KiSS4.Gui.KissTextEdit();
            this.lblKurzKontaktEmail = new KiSS4.Gui.KissLabel();
            this.edtKurzKontaktFax = new KiSS4.Gui.KissTextEdit();
            this.lblKurzKontaktFax = new KiSS4.Gui.KissLabel();
            this.edtKurzKontaktTelM = new KiSS4.Gui.KissTextEdit();
            this.lblKurzKontaktTelM = new KiSS4.Gui.KissLabel();
            this.edtKurzKontaktTelG = new KiSS4.Gui.KissTextEdit();
            this.lblKurzKontaktTelG = new KiSS4.Gui.KissLabel();
            this.edtKurzKontaktTelP = new KiSS4.Gui.KissTextEdit();
            this.lblKurzKontaktTelP = new KiSS4.Gui.KissLabel();
            this.grpKurzWohnsitz = new KiSS4.Gui.KissGroupBox();
            this.chkKurzPostfachOhneNr = new KiSS4.Gui.KissCheckEdit();
            this.qryBaAdresseBezugsperson = new KiSS4.DB.SqlQuery(this.components);
            this.edtKurzAdresseLand = new KiSS4.Gui.KissLookUpEdit();
            this.lblKurzAdresseLand = new KiSS4.Gui.KissLabel();
            this.edtKurzAdresseBezirk = new KiSS4.Gui.KissTextEdit();
            this.lblKurzAdresseBezirk = new KiSS4.Gui.KissLabel();
            this.edtKurzAdresseKt = new KiSS4.Gui.KissTextEdit();
            this.edtKurzAdresseOrt = new KiSS4.Gui.KissTextEdit();
            this.edtKurzAdressePLZ = new KiSS4.Gui.KissTextEdit();
            this.lblKurzAdressePLZOrtKt = new KiSS4.Gui.KissLabel();
            this.edtKurzAdressePostfach = new KiSS4.Gui.KissTextEdit();
            this.lblKurzAdressePostfach = new KiSS4.Gui.KissLabel();
            this.edtKurzAdresseHausNr = new KiSS4.Gui.KissTextEdit();
            this.edtKurzAdresseStrasse = new KiSS4.Gui.KissTextEdit();
            this.lblKurzAdresseStrasseNr = new KiSS4.Gui.KissLabel();
            this.edtKurzAdresseZusatz = new KiSS4.Gui.KissTextEdit();
            this.lblKurzAdresseZusatz = new KiSS4.Gui.KissLabel();
            this.edtKurzVorname = new KiSS4.Gui.KissTextEdit();
            this.edtKurzName = new KiSS4.Gui.KissTextEdit();
            this.lblKurzNameVorname = new KiSS4.Gui.KissLabel();
            this.edtKurzTitel = new KiSS4.Gui.KissTextEdit();
            this.lblKurzTitel = new KiSS4.Gui.KissLabel();
            this.qryRelationFemale = new KiSS4.DB.SqlQuery(this.components);
            this.qryRelationGeneric = new KiSS4.DB.SqlQuery(this.components);
            this.qryRelationMale = new KiSS4.DB.SqlQuery(this.components);
            this.panTitel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkZeigeDetails.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeigeDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            this.pnlTab.SuspendLayout();
            this.tabStammdaten.SuspendLayout();
            this.tpgPersonalien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonDebitorNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonDebitorNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonAnrede.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPersonManuelleAnrede.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonBriefanrede)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonBriefanrede.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonAnrede)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPersonKeinSerienbrief.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWichtigerHinweis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonalienBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWichtigerHinweis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWichtigerHinweis)).BeginInit();
            this.grpIVBerechtigung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtIVBerechtigungAktuellerStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIVBerechtigungAktuellerStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIVBerechtigungAktuellerStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVormundPI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVormundMassnahmenCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVormundMassnahmenCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVormundschaftlicheMassnahmen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErwerbssituationCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErwerbssituationCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErwerbssituation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusbildungCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusbildungCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusbildung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkInCHSeitGeburt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInCHSeit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInCHSeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuslaenderStatusCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuslaenderStatusCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuslStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKorrespondenzSpracheCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKorrespondenzSpracheCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSprachCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSprachCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKorrespondenzSprache)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSprache)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonKlientenkontoNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonKlientenkontoNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKontoFuehrung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMehrfachbehinderungBSV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBSVBehinderungsartCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBSVBehinderungsartCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBSVBehinderungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBehinderungsart2Code)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBehinderungsart2Code.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBehinderungsart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHauptBehinderungsartCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHauptBehinderungsartCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHauptbehinderungsArt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHeimatGemeinde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHeimatGemeinde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaetCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaetCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZivilstandCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZivilstandCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZivilstand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlechtCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlechtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeschlecht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSterbedatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsdatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersicherungsNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersicherungsNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFruehererName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFruehererName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTitel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLaufendeVollmachtErlaubnis.Properties)).BeginInit();
            this.tpgAdresse.SuspendLayout();
            this.panTblAdresseBottom.SuspendLayout();
            this.grpAdresseBemerkungen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memBemerkungenAdresse.Properties)).BeginInit();
            this.grpWohnsitzDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkEigenerMietvertrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMietdepotProInfirmis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsituationStatusCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsituationStatusCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseWohnstatus)).BeginInit();
            this.tpgKontaktBankPost.SuspendLayout();
            this.grpBankPostZahlungsverbindungen.SuspendLayout();
            this.panKontakt.SuspendLayout();
            this.grpKontakt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtEMail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkZeigeTelMobil.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMobilTel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefonMobil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkZeigeTelGeschaeft.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefon_G.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefonGeschaeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkZeigeTelPrivat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefon_P.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefonPrivat)).BeginInit();
            this.tpgSozialversicherung.SuspendLayout();
            this.grpAssistenz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblAssistenzbeitrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVerfuegung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAssistenzbeitrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblABeitragAb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIvVerfuegteAssistenzberatung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVerfuegung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIvVerfuegteAssistenzberatung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtABeitragAb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIvVerfuegteAssistenzberatungStunden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWitwenWitwerWaisenrente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkWittwenWittwerWaisenrente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memBemerkungenSV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSozialversicherungBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memAndereSVLeistungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAndereSVLeistungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKTG.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKTG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkALK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblALK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSozialhilfe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSozialhilfe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUVGTaggeld.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUVGTaggeld)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUVGRente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUVGRente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBVGRente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBVGRente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkErgaenzungsLeistungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErgaenzungsleistungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMedizinischeMassnahmeIV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIVHilfsmittel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMedizinischeMassnahmeIV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIVHilfsmittel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBeruflicheMassnahmeIV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeruflicheMassnahmenIV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIVTaggeld.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIVTaggeld)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIntensivPflegeZuschlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIntensivPflegeZuschlag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIntensivPflegeZuschlag)).BeginInit();
            this.grpKantonaleZuschuesse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdKZSZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKZSZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKZSVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKZSVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKZSFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKZSFilter)).BeginInit();
            this.grpHELB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkHelbKeinAntrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHelbKeinAntrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHelbDatumEntscheid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHelbDatumEntscheid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHelbAbWann.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHelbAbWann)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHelpEntscheid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHelpEntscheid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHelbEntscheid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHelbAnmeldung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHelbAnmeldung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHilfslosenEntschaedigung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHilfslosenEntschaedigung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHilfslosenentschaedigung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIVGradProzent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIVGrad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIVGrad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRentenstufe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRentenstufe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRentenstufe)).BeginInit();
            this.tpgRechnungsadressen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRechnungsadressen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryRechnungsadressen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRechnungsadressen)).BeginInit();
            this.panRechnungsadressenUnten.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memRechnungsadresseBemerkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechnungsadresseBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungsadresseLand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungsadresseLand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechnungsadresseLand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungsadresseBezirk.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechnungsadresseBezirk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungsadresseKanton.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungsadresseOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungsadressePLZ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechnungsadressePLZOrtKt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungsadressePostfach.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechnungsadressePostfach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungsadresseHausNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungsadresseStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechnungsadresseStrasseNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungsadresseZusatz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechnungsadresseZusatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungsadresseVornameName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechnungsadresseNameVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungsadresseDL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungsadresseDL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechnungsadresseDL)).BeginInit();
            this.tpgKurz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzAnrede.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKurzManuelleAnrede.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzBriefanrede)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzBriefanrede.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzAnrede)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKurzKeinSerienbrief.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKurzGleicherHaushalt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPersonRelation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzBeziehung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzBeziehung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzBeziehung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzSprache)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzSprache.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzSprache)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzGeschlechtCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzGeschlechtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzGeschlecht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzSterbedatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzTod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzGeburtsdatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzGeburt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzVersichertenNummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzVersichertenNummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzPersonenNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzPersonenNr)).BeginInit();
            this.grpKurzKontakt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkBPZeigeTelMobil.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBPZeigeTelGeschaeft.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBPZeigeTelPrivat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzKontaktEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzKontaktEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzKontaktFax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzKontaktFax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzKontaktTelM.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzKontaktTelM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzKontaktTelG.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzKontaktTelG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzKontaktTelP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzKontaktTelP)).BeginInit();
            this.grpKurzWohnsitz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkKurzPostfachOhneNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaAdresseBezugsperson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzAdresseLand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzAdresseLand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzAdresseLand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzAdresseBezirk.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzAdresseBezirk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzAdresseKt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzAdresseOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzAdressePLZ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzAdressePLZOrtKt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzAdressePostfach.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzAdressePostfach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzAdresseHausNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzAdresseStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzAdresseStrasseNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzAdresseZusatz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzAdresseZusatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzNameVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzTitel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryRelationFemale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryRelationGeneric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryRelationMale)).BeginInit();
            this.SuspendLayout();
            // 
            // panTitel
            // 
            this.panTitel.Controls.Add(this.picTitel);
            this.panTitel.Controls.Add(this.chkZeigeDetails);
            this.panTitel.Controls.Add(this.lblZeigeDetails);
            this.panTitel.Controls.Add(this.lblTitel);
            this.panTitel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitel.Location = new System.Drawing.Point(0, 0);
            this.panTitel.Name = "panTitel";
            this.panTitel.Size = new System.Drawing.Size(722, 30);
            this.panTitel.TabIndex = 0;
            // 
            // picTitel
            // 
            this.picTitel.Location = new System.Drawing.Point(10, 7);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 293;
            this.picTitel.TabStop = false;
            // 
            // chkZeigeDetails
            // 
            this.chkZeigeDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkZeigeDetails.DataMember = "ZeigeDetails";
            this.chkZeigeDetails.DataSource = this.qryBaPerson;
            this.chkZeigeDetails.Location = new System.Drawing.Point(696, 6);
            this.chkZeigeDetails.Name = "chkZeigeDetails";
            this.chkZeigeDetails.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkZeigeDetails.Properties.Appearance.Options.UseBackColor = true;
            this.chkZeigeDetails.Properties.Caption = " .";
            this.chkZeigeDetails.Size = new System.Drawing.Size(25, 19);
            this.chkZeigeDetails.TabIndex = 2;
            this.chkZeigeDetails.EditValueChanged += new System.EventHandler(this.chkZeigeDetails_EditValueChanged);
            this.chkZeigeDetails.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.chkZeigeDetails_EditValueChanging);
            // 
            // qryBaPerson
            // 
            this.qryBaPerson.CanUpdate = true;
            this.qryBaPerson.HostControl = this;
            this.qryBaPerson.TableName = "BaPerson";
            this.qryBaPerson.AfterPost += new System.EventHandler(this.qryBaPerson_AfterPost);
            this.qryBaPerson.BeforeDelete += new System.EventHandler(this.qryBaPerson_BeforeDelete);
            this.qryBaPerson.BeforePost += new System.EventHandler(this.qryBaPerson_BeforePost);
            this.qryBaPerson.ColumnChanged += new System.Data.DataColumnChangeEventHandler(this.qryBaPerson_ColumnChanged);
            this.qryBaPerson.PostCompleted += new System.EventHandler(this.qryBaPerson_PostCompleted);
            // 
            // lblZeigeDetails
            // 
            this.lblZeigeDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblZeigeDetails.Location = new System.Drawing.Point(632, 3);
            this.lblZeigeDetails.Name = "lblZeigeDetails";
            this.lblZeigeDetails.Size = new System.Drawing.Size(58, 24);
            this.lblZeigeDetails.TabIndex = 1;
            this.lblZeigeDetails.Text = "Details";
            this.lblZeigeDetails.UseCompatibleTextRendering = true;
            // 
            // lblTitel
            // 
            this.lblTitel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblTitel.Location = new System.Drawing.Point(35, 7);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(591, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Stammdaten";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // pnlTab
            // 
            this.pnlTab.Controls.Add(this.tabStammdaten);
            this.pnlTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTab.Location = new System.Drawing.Point(0, 30);
            this.pnlTab.Name = "pnlTab";
            this.pnlTab.Size = new System.Drawing.Size(722, 662);
            this.pnlTab.TabIndex = 1;
            // 
            // tabStammdaten
            // 
            this.tabStammdaten.Controls.Add(this.tpgPersonalien);
            this.tabStammdaten.Controls.Add(this.tpgAdresse);
            this.tabStammdaten.Controls.Add(this.tpgKontaktBankPost);
            this.tabStammdaten.Controls.Add(this.tpgSozialversicherung);
            this.tabStammdaten.Controls.Add(this.tpgRechnungsadressen);
            this.tabStammdaten.Controls.Add(this.tpgKurz);
            this.tabStammdaten.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabStammdaten.Location = new System.Drawing.Point(0, 0);
            this.tabStammdaten.Name = "tabStammdaten";
            this.tabStammdaten.SelectedTabIndex = 2;
            this.tabStammdaten.ShowFixedWidthTooltip = true;
            this.tabStammdaten.Size = new System.Drawing.Size(722, 662);
            this.tabStammdaten.TabIndex = 0;
            this.tabStammdaten.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgPersonalien,
            this.tpgAdresse,
            this.tpgKontaktBankPost,
            this.tpgSozialversicherung,
            this.tpgRechnungsadressen,
            this.tpgKurz});
            this.tabStammdaten.TabsLineColor = System.Drawing.Color.Black;
            this.tabStammdaten.TabsLocation = SharpLibrary.WinControls.TabsLocation.Top;
            this.tabStammdaten.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabStammdaten.Text = "kissTabControlEx1";
            this.tabStammdaten.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabStammdaten_SelectedTabChanged);
            this.tabStammdaten.SelectedTabChanging += new System.ComponentModel.CancelEventHandler(this.tabStammdaten_SelectedTabChanging);
            // 
            // tpgPersonalien
            // 
            this.tpgPersonalien.Controls.Add(this.edtPersonDebitorNr);
            this.tpgPersonalien.Controls.Add(this.lblPersonDebitorNr);
            this.tpgPersonalien.Controls.Add(this.edtPersonAnrede);
            this.tpgPersonalien.Controls.Add(this.chkPersonManuelleAnrede);
            this.tpgPersonalien.Controls.Add(this.lblPersonBriefanrede);
            this.tpgPersonalien.Controls.Add(this.edtPersonBriefanrede);
            this.tpgPersonalien.Controls.Add(this.lblPersonAnrede);
            this.tpgPersonalien.Controls.Add(this.chkPersonKeinSerienbrief);
            this.tpgPersonalien.Controls.Add(this.picWichtigerHinweis);
            this.tpgPersonalien.Controls.Add(this.memBemerkungenPersonalien);
            this.tpgPersonalien.Controls.Add(this.lblPersonalienBemerkungen);
            this.tpgPersonalien.Controls.Add(this.edtWichtigerHinweis);
            this.tpgPersonalien.Controls.Add(this.lblWichtigerHinweis);
            this.tpgPersonalien.Controls.Add(this.grpIVBerechtigung);
            this.tpgPersonalien.Controls.Add(this.chkVormundPI);
            this.tpgPersonalien.Controls.Add(this.edtVormundMassnahmenCode);
            this.tpgPersonalien.Controls.Add(this.lblVormundschaftlicheMassnahmen);
            this.tpgPersonalien.Controls.Add(this.edtErwerbssituationCode);
            this.tpgPersonalien.Controls.Add(this.lblErwerbssituation);
            this.tpgPersonalien.Controls.Add(this.edtAusbildungCode);
            this.tpgPersonalien.Controls.Add(this.lblAusbildung);
            this.tpgPersonalien.Controls.Add(this.chkInCHSeitGeburt);
            this.tpgPersonalien.Controls.Add(this.edtInCHSeit);
            this.tpgPersonalien.Controls.Add(this.lblInCHSeit);
            this.tpgPersonalien.Controls.Add(this.edtAuslaenderStatusCode);
            this.tpgPersonalien.Controls.Add(this.lblAuslStatus);
            this.tpgPersonalien.Controls.Add(this.edtKorrespondenzSpracheCode);
            this.tpgPersonalien.Controls.Add(this.edtSprachCode);
            this.tpgPersonalien.Controls.Add(this.lblKorrespondenzSprache);
            this.tpgPersonalien.Controls.Add(this.lblSprache);
            this.tpgPersonalien.Controls.Add(this.edtPersonKlientenkontoNr);
            this.tpgPersonalien.Controls.Add(this.lblPersonKlientenkontoNr);
            this.tpgPersonalien.Controls.Add(this.edtBaPersonID);
            this.tpgPersonalien.Controls.Add(this.lblPersonNumber);
            this.tpgPersonalien.Controls.Add(this.chkKontoFuehrung);
            this.tpgPersonalien.Controls.Add(this.chkMehrfachbehinderungBSV);
            this.tpgPersonalien.Controls.Add(this.edtBSVBehinderungsartCode);
            this.tpgPersonalien.Controls.Add(this.lblBSVBehinderungsart);
            this.tpgPersonalien.Controls.Add(this.edtBehinderungsart2Code);
            this.tpgPersonalien.Controls.Add(this.lblBehinderungsart2);
            this.tpgPersonalien.Controls.Add(this.edtHauptBehinderungsartCode);
            this.tpgPersonalien.Controls.Add(this.lblHauptbehinderungsArt);
            this.tpgPersonalien.Controls.Add(this.edtHeimatGemeinde);
            this.tpgPersonalien.Controls.Add(this.lblHeimatGemeinde);
            this.tpgPersonalien.Controls.Add(this.edtNationalitaetCode);
            this.tpgPersonalien.Controls.Add(this.lblNation);
            this.tpgPersonalien.Controls.Add(this.edtZivilstandCode);
            this.tpgPersonalien.Controls.Add(this.lblZivilstand);
            this.tpgPersonalien.Controls.Add(this.edtGeschlechtCode);
            this.tpgPersonalien.Controls.Add(this.lblGeschlecht);
            this.tpgPersonalien.Controls.Add(this.edtSterbedatum);
            this.tpgPersonalien.Controls.Add(this.lblTod);
            this.tpgPersonalien.Controls.Add(this.edtGeburtsdatum);
            this.tpgPersonalien.Controls.Add(this.lblGeburt);
            this.tpgPersonalien.Controls.Add(this.edtVersicherungsNr);
            this.tpgPersonalien.Controls.Add(this.lblVersicherungsNr);
            this.tpgPersonalien.Controls.Add(this.edtFruehererName);
            this.tpgPersonalien.Controls.Add(this.lblFruehererName);
            this.tpgPersonalien.Controls.Add(this.edtVorname);
            this.tpgPersonalien.Controls.Add(this.edtName);
            this.tpgPersonalien.Controls.Add(this.lblNameVorname);
            this.tpgPersonalien.Controls.Add(this.edtTitel);
            this.tpgPersonalien.Controls.Add(this.lblPersonTitel);
            this.tpgPersonalien.Controls.Add(this.chkLaufendeVollmachtErlaubnis);
            this.tpgPersonalien.Location = new System.Drawing.Point(6, 32);
            this.tpgPersonalien.Name = "tpgPersonalien";
            this.tpgPersonalien.Size = new System.Drawing.Size(710, 624);
            this.tpgPersonalien.TabIndex = 0;
            this.tpgPersonalien.Title = "Pers&onalien";
            // 
            // edtPersonDebitorNr
            // 
            this.edtPersonDebitorNr.DataMember = "DebitorNr";
            this.edtPersonDebitorNr.DataSource = this.qryBaPerson;
            this.edtPersonDebitorNr.Location = new System.Drawing.Point(529, 99);
            this.edtPersonDebitorNr.Name = "edtPersonDebitorNr";
            this.edtPersonDebitorNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtPersonDebitorNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPersonDebitorNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPersonDebitorNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPersonDebitorNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtPersonDebitorNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPersonDebitorNr.Properties.Appearance.Options.UseFont = true;
            this.edtPersonDebitorNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPersonDebitorNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPersonDebitorNr.Properties.Precision = 0;
            this.edtPersonDebitorNr.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.edtPersonDebitorNr.Size = new System.Drawing.Size(178, 24);
            this.edtPersonDebitorNr.TabIndex = 43;
            // 
            // lblPersonDebitorNr
            // 
            this.lblPersonDebitorNr.Location = new System.Drawing.Point(418, 99);
            this.lblPersonDebitorNr.Name = "lblPersonDebitorNr";
            this.lblPersonDebitorNr.Size = new System.Drawing.Size(105, 24);
            this.lblPersonDebitorNr.TabIndex = 42;
            this.lblPersonDebitorNr.Text = "Debitor-Nr.";
            this.lblPersonDebitorNr.UseCompatibleTextRendering = true;
            // 
            // edtPersonAnrede
            // 
            this.edtPersonAnrede.DataMember = "Anrede";
            this.edtPersonAnrede.DataSource = this.qryBaPerson;
            this.edtPersonAnrede.Location = new System.Drawing.Point(101, 53);
            this.edtPersonAnrede.Name = "edtPersonAnrede";
            this.edtPersonAnrede.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPersonAnrede.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPersonAnrede.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPersonAnrede.Properties.Appearance.Options.UseBackColor = true;
            this.edtPersonAnrede.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPersonAnrede.Properties.Appearance.Options.UseFont = true;
            this.edtPersonAnrede.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPersonAnrede.Properties.Name = "kissTextEdit1.Properties";
            this.edtPersonAnrede.Size = new System.Drawing.Size(188, 24);
            this.edtPersonAnrede.TabIndex = 4;
            // 
            // chkPersonManuelleAnrede
            // 
            this.chkPersonManuelleAnrede.DataMember = "ManuelleAnrede";
            this.chkPersonManuelleAnrede.DataSource = this.qryBaPerson;
            this.chkPersonManuelleAnrede.Location = new System.Drawing.Point(295, 55);
            this.chkPersonManuelleAnrede.Name = "chkPersonManuelleAnrede";
            this.chkPersonManuelleAnrede.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkPersonManuelleAnrede.Properties.Appearance.Options.UseBackColor = true;
            this.chkPersonManuelleAnrede.Properties.Caption = "Manuelle Anrede";
            this.chkPersonManuelleAnrede.Size = new System.Drawing.Size(119, 19);
            this.chkPersonManuelleAnrede.TabIndex = 5;
            this.chkPersonManuelleAnrede.CheckedChanged += new System.EventHandler(this.chkPersonManuelleAnrede_CheckedChanged);
            // 
            // lblPersonBriefanrede
            // 
            this.lblPersonBriefanrede.Location = new System.Drawing.Point(5, 76);
            this.lblPersonBriefanrede.Name = "lblPersonBriefanrede";
            this.lblPersonBriefanrede.Size = new System.Drawing.Size(90, 24);
            this.lblPersonBriefanrede.TabIndex = 6;
            this.lblPersonBriefanrede.Text = "Briefanrede";
            this.lblPersonBriefanrede.UseCompatibleTextRendering = true;
            // 
            // edtPersonBriefanrede
            // 
            this.edtPersonBriefanrede.DataMember = "Briefanrede";
            this.edtPersonBriefanrede.DataSource = this.qryBaPerson;
            this.edtPersonBriefanrede.Location = new System.Drawing.Point(101, 76);
            this.edtPersonBriefanrede.Name = "edtPersonBriefanrede";
            this.edtPersonBriefanrede.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPersonBriefanrede.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPersonBriefanrede.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPersonBriefanrede.Properties.Appearance.Options.UseBackColor = true;
            this.edtPersonBriefanrede.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPersonBriefanrede.Properties.Appearance.Options.UseFont = true;
            this.edtPersonBriefanrede.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPersonBriefanrede.Size = new System.Drawing.Size(300, 24);
            this.edtPersonBriefanrede.TabIndex = 7;
            // 
            // lblPersonAnrede
            // 
            this.lblPersonAnrede.Location = new System.Drawing.Point(5, 53);
            this.lblPersonAnrede.Name = "lblPersonAnrede";
            this.lblPersonAnrede.Size = new System.Drawing.Size(90, 24);
            this.lblPersonAnrede.TabIndex = 3;
            this.lblPersonAnrede.Text = "Anrede";
            this.lblPersonAnrede.UseCompatibleTextRendering = true;
            // 
            // chkPersonKeinSerienbrief
            // 
            this.chkPersonKeinSerienbrief.DataMember = "KeinSerienbrief";
            this.chkPersonKeinSerienbrief.DataSource = this.qryBaPerson;
            this.chkPersonKeinSerienbrief.Location = new System.Drawing.Point(101, 5);
            this.chkPersonKeinSerienbrief.Name = "chkPersonKeinSerienbrief";
            this.chkPersonKeinSerienbrief.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkPersonKeinSerienbrief.Properties.Appearance.Options.UseBackColor = true;
            this.chkPersonKeinSerienbrief.Properties.Caption = "Kein Serienbrief";
            this.chkPersonKeinSerienbrief.Size = new System.Drawing.Size(313, 19);
            this.chkPersonKeinSerienbrief.TabIndex = 0;
            // 
            // picWichtigerHinweis
            // 
            this.picWichtigerHinweis.Location = new System.Drawing.Point(688, 456);
            this.picWichtigerHinweis.Name = "picWichtigerHinweis";
            this.picWichtigerHinweis.Size = new System.Drawing.Size(16, 16);
            this.picWichtigerHinweis.TabIndex = 63;
            this.picWichtigerHinweis.TabStop = false;
            this.picWichtigerHinweis.Visible = false;
            // 
            // memBemerkungenPersonalien
            // 
            this.memBemerkungenPersonalien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.memBemerkungenPersonalien.BackColor = System.Drawing.Color.White;
            this.memBemerkungenPersonalien.DataMember = "Bemerkung";
            this.memBemerkungenPersonalien.DataSource = this.qryBaPerson;
            this.memBemerkungenPersonalien.Font = new System.Drawing.Font("Arial", 10F);
            this.memBemerkungenPersonalien.Location = new System.Drawing.Point(101, 482);
            this.memBemerkungenPersonalien.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.memBemerkungenPersonalien.Name = "memBemerkungenPersonalien";
            this.memBemerkungenPersonalien.Size = new System.Drawing.Size(606, 139);
            this.memBemerkungenPersonalien.TabIndex = 64;
            // 
            // lblPersonalienBemerkungen
            // 
            this.lblPersonalienBemerkungen.Location = new System.Drawing.Point(4, 482);
            this.lblPersonalienBemerkungen.Name = "lblPersonalienBemerkungen";
            this.lblPersonalienBemerkungen.Size = new System.Drawing.Size(90, 24);
            this.lblPersonalienBemerkungen.TabIndex = 63;
            this.lblPersonalienBemerkungen.Text = "Bemerkungen";
            this.lblPersonalienBemerkungen.UseCompatibleTextRendering = true;
            // 
            // edtWichtigerHinweis
            // 
            this.edtWichtigerHinweis.DataMember = "WichtigerHinweis";
            this.edtWichtigerHinweis.DataSource = this.qryBaPerson;
            this.edtWichtigerHinweis.Location = new System.Drawing.Point(101, 452);
            this.edtWichtigerHinweis.Name = "edtWichtigerHinweis";
            this.edtWichtigerHinweis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWichtigerHinweis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWichtigerHinweis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWichtigerHinweis.Properties.Appearance.Options.UseBackColor = true;
            this.edtWichtigerHinweis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWichtigerHinweis.Properties.Appearance.Options.UseFont = true;
            this.edtWichtigerHinweis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtWichtigerHinweis.Size = new System.Drawing.Size(606, 24);
            this.edtWichtigerHinweis.TabIndex = 62;
            this.edtWichtigerHinweis.EditValueChanged += new System.EventHandler(this.edtWichtigerHinweis_EditValueChanged);
            // 
            // lblWichtigerHinweis
            // 
            this.lblWichtigerHinweis.Location = new System.Drawing.Point(5, 452);
            this.lblWichtigerHinweis.Name = "lblWichtigerHinweis";
            this.lblWichtigerHinweis.Size = new System.Drawing.Size(90, 24);
            this.lblWichtigerHinweis.TabIndex = 61;
            this.lblWichtigerHinweis.Text = "Wichtiger Hinw.";
            this.lblWichtigerHinweis.UseCompatibleTextRendering = true;
            // 
            // grpIVBerechtigung
            // 
            this.grpIVBerechtigung.Controls.Add(this.btnIVBerechtigungBearbeiten);
            this.grpIVBerechtigung.Controls.Add(this.edtIVBerechtigungAktuellerStatus);
            this.grpIVBerechtigung.Controls.Add(this.lblIVBerechtigungAktuellerStatus);
            this.grpIVBerechtigung.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grpIVBerechtigung.Location = new System.Drawing.Point(418, 357);
            this.grpIVBerechtigung.Name = "grpIVBerechtigung";
            this.grpIVBerechtigung.Size = new System.Drawing.Size(289, 82);
            this.grpIVBerechtigung.TabIndex = 60;
            this.grpIVBerechtigung.TabStop = false;
            this.grpIVBerechtigung.Text = "IV-Berechtigung";
            this.grpIVBerechtigung.UseCompatibleTextRendering = true;
            // 
            // btnIVBerechtigungBearbeiten
            // 
            this.btnIVBerechtigungBearbeiten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIVBerechtigungBearbeiten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIVBerechtigungBearbeiten.IconID = 5005;
            this.btnIVBerechtigungBearbeiten.Location = new System.Drawing.Point(253, 48);
            this.btnIVBerechtigungBearbeiten.Name = "btnIVBerechtigungBearbeiten";
            this.btnIVBerechtigungBearbeiten.Size = new System.Drawing.Size(24, 24);
            this.btnIVBerechtigungBearbeiten.TabIndex = 2;
            this.btnIVBerechtigungBearbeiten.UseCompatibleTextRendering = true;
            this.btnIVBerechtigungBearbeiten.UseVisualStyleBackColor = false;
            this.btnIVBerechtigungBearbeiten.Click += new System.EventHandler(this.btnIVBerechtigungBearbeiten_Click);
            // 
            // edtIVBerechtigungAktuellerStatus
            // 
            this.edtIVBerechtigungAktuellerStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtIVBerechtigungAktuellerStatus.DataMember = "IVBerechtigungAktuellerStatusCode";
            this.edtIVBerechtigungAktuellerStatus.DataSource = this.qryBaPerson;
            this.edtIVBerechtigungAktuellerStatus.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtIVBerechtigungAktuellerStatus.Location = new System.Drawing.Point(12, 48);
            this.edtIVBerechtigungAktuellerStatus.LOVName = "BaIVBerechtigung";
            this.edtIVBerechtigungAktuellerStatus.Name = "edtIVBerechtigungAktuellerStatus";
            this.edtIVBerechtigungAktuellerStatus.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtIVBerechtigungAktuellerStatus.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIVBerechtigungAktuellerStatus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIVBerechtigungAktuellerStatus.Properties.Appearance.Options.UseBackColor = true;
            this.edtIVBerechtigungAktuellerStatus.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIVBerechtigungAktuellerStatus.Properties.Appearance.Options.UseFont = true;
            this.edtIVBerechtigungAktuellerStatus.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtIVBerechtigungAktuellerStatus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtIVBerechtigungAktuellerStatus.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtIVBerechtigungAktuellerStatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtIVBerechtigungAktuellerStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtIVBerechtigungAktuellerStatus.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIVBerechtigungAktuellerStatus.Properties.NullText = "";
            this.edtIVBerechtigungAktuellerStatus.Properties.ReadOnly = true;
            this.edtIVBerechtigungAktuellerStatus.Properties.ShowFooter = false;
            this.edtIVBerechtigungAktuellerStatus.Properties.ShowHeader = false;
            this.edtIVBerechtigungAktuellerStatus.Size = new System.Drawing.Size(235, 24);
            this.edtIVBerechtigungAktuellerStatus.TabIndex = 1;
            // 
            // lblIVBerechtigungAktuellerStatus
            // 
            this.lblIVBerechtigungAktuellerStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIVBerechtigungAktuellerStatus.Location = new System.Drawing.Point(12, 20);
            this.lblIVBerechtigungAktuellerStatus.Margin = new System.Windows.Forms.Padding(9, 9, 9, 3);
            this.lblIVBerechtigungAktuellerStatus.Name = "lblIVBerechtigungAktuellerStatus";
            this.lblIVBerechtigungAktuellerStatus.Size = new System.Drawing.Size(265, 24);
            this.lblIVBerechtigungAktuellerStatus.TabIndex = 0;
            this.lblIVBerechtigungAktuellerStatus.Text = "Aktuelle Berechtigung gem. Kriterien des BSV";
            this.lblIVBerechtigungAktuellerStatus.UseCompatibleTextRendering = true;
            // 
            // chkVormundPI
            // 
            this.chkVormundPI.DataMember = "VormundPI";
            this.chkVormundPI.DataSource = this.qryBaPerson;
            this.chkVormundPI.Location = new System.Drawing.Point(529, 325);
            this.chkVormundPI.Name = "chkVormundPI";
            this.chkVormundPI.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkVormundPI.Properties.Appearance.Options.UseBackColor = true;
            this.chkVormundPI.Properties.Caption = "Durch PI";
            this.chkVormundPI.Size = new System.Drawing.Size(178, 19);
            this.chkVormundPI.TabIndex = 59;
            // 
            // edtVormundMassnahmenCode
            // 
            this.edtVormundMassnahmenCode.DataMember = "VormundMassnahmenCode";
            this.edtVormundMassnahmenCode.DataSource = this.qryBaPerson;
            this.edtVormundMassnahmenCode.Location = new System.Drawing.Point(529, 295);
            this.edtVormundMassnahmenCode.LOVName = "BaVormundMassnahmen";
            this.edtVormundMassnahmenCode.Name = "edtVormundMassnahmenCode";
            this.edtVormundMassnahmenCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVormundMassnahmenCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVormundMassnahmenCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVormundMassnahmenCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtVormundMassnahmenCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVormundMassnahmenCode.Properties.Appearance.Options.UseFont = true;
            this.edtVormundMassnahmenCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtVormundMassnahmenCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtVormundMassnahmenCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtVormundMassnahmenCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtVormundMassnahmenCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtVormundMassnahmenCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtVormundMassnahmenCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVormundMassnahmenCode.Properties.NullText = "";
            this.edtVormundMassnahmenCode.Properties.PopupWidth = 500;
            this.edtVormundMassnahmenCode.Properties.ShowFooter = false;
            this.edtVormundMassnahmenCode.Properties.ShowHeader = false;
            this.edtVormundMassnahmenCode.Size = new System.Drawing.Size(178, 24);
            this.edtVormundMassnahmenCode.TabIndex = 58;
            // 
            // lblVormundschaftlicheMassnahmen
            // 
            this.lblVormundschaftlicheMassnahmen.Location = new System.Drawing.Point(418, 295);
            this.lblVormundschaftlicheMassnahmen.Name = "lblVormundschaftlicheMassnahmen";
            this.lblVormundschaftlicheMassnahmen.Size = new System.Drawing.Size(114, 24);
            this.lblVormundschaftlicheMassnahmen.TabIndex = 57;
            this.lblVormundschaftlicheMassnahmen.Text = "KESB-Massnahmen";
            this.lblVormundschaftlicheMassnahmen.UseCompatibleTextRendering = true;
            // 
            // edtErwerbssituationCode
            // 
            this.edtErwerbssituationCode.AllowNull = false;
            this.edtErwerbssituationCode.DataMember = "ErwerbssituationCode";
            this.edtErwerbssituationCode.DataSource = this.qryBaPerson;
            this.edtErwerbssituationCode.Location = new System.Drawing.Point(529, 265);
            this.edtErwerbssituationCode.LOVName = "BaErwerbssituation";
            this.edtErwerbssituationCode.Name = "edtErwerbssituationCode";
            this.edtErwerbssituationCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErwerbssituationCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErwerbssituationCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErwerbssituationCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtErwerbssituationCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErwerbssituationCode.Properties.Appearance.Options.UseFont = true;
            this.edtErwerbssituationCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtErwerbssituationCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtErwerbssituationCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtErwerbssituationCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtErwerbssituationCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtErwerbssituationCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtErwerbssituationCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErwerbssituationCode.Properties.NullText = "";
            this.edtErwerbssituationCode.Properties.PopupWidth = 500;
            this.edtErwerbssituationCode.Properties.ShowFooter = false;
            this.edtErwerbssituationCode.Properties.ShowHeader = false;
            this.edtErwerbssituationCode.Size = new System.Drawing.Size(178, 24);
            this.edtErwerbssituationCode.TabIndex = 56;
            // 
            // lblErwerbssituation
            // 
            this.lblErwerbssituation.Location = new System.Drawing.Point(418, 265);
            this.lblErwerbssituation.Name = "lblErwerbssituation";
            this.lblErwerbssituation.Size = new System.Drawing.Size(92, 24);
            this.lblErwerbssituation.TabIndex = 55;
            this.lblErwerbssituation.Text = "Erwerbssituation";
            this.lblErwerbssituation.UseCompatibleTextRendering = true;
            // 
            // edtAusbildungCode
            // 
            this.edtAusbildungCode.AllowNull = false;
            this.edtAusbildungCode.DataMember = "AusbildungCode";
            this.edtAusbildungCode.DataSource = this.qryBaPerson;
            this.edtAusbildungCode.Location = new System.Drawing.Point(529, 242);
            this.edtAusbildungCode.LOVName = "BaAusbildungCode";
            this.edtAusbildungCode.Name = "edtAusbildungCode";
            this.edtAusbildungCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAusbildungCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAusbildungCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAusbildungCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtAusbildungCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAusbildungCode.Properties.Appearance.Options.UseFont = true;
            this.edtAusbildungCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAusbildungCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAusbildungCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAusbildungCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAusbildungCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtAusbildungCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtAusbildungCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAusbildungCode.Properties.NullText = "";
            this.edtAusbildungCode.Properties.PopupWidth = 500;
            this.edtAusbildungCode.Properties.ShowFooter = false;
            this.edtAusbildungCode.Properties.ShowHeader = false;
            this.edtAusbildungCode.Size = new System.Drawing.Size(178, 24);
            this.edtAusbildungCode.TabIndex = 54;
            // 
            // lblAusbildung
            // 
            this.lblAusbildung.Location = new System.Drawing.Point(418, 242);
            this.lblAusbildung.Name = "lblAusbildung";
            this.lblAusbildung.Size = new System.Drawing.Size(92, 24);
            this.lblAusbildung.TabIndex = 53;
            this.lblAusbildung.Text = "Ausbildung";
            this.lblAusbildung.UseCompatibleTextRendering = true;
            // 
            // chkInCHSeitGeburt
            // 
            this.chkInCHSeitGeburt.DataMember = "InCHSeitGeburt";
            this.chkInCHSeitGeburt.DataSource = this.qryBaPerson;
            this.chkInCHSeitGeburt.Location = new System.Drawing.Point(630, 216);
            this.chkInCHSeitGeburt.Name = "chkInCHSeitGeburt";
            this.chkInCHSeitGeburt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkInCHSeitGeburt.Properties.Appearance.Options.UseBackColor = true;
            this.chkInCHSeitGeburt.Properties.Caption = "seit Geburt";
            this.chkInCHSeitGeburt.Size = new System.Drawing.Size(80, 19);
            this.chkInCHSeitGeburt.TabIndex = 52;
            this.chkInCHSeitGeburt.EditValueChanged += new System.EventHandler(this.chkInCHSeitGeburt_EditValueChanged);
            // 
            // edtInCHSeit
            // 
            this.edtInCHSeit.DataMember = "InCHSeit";
            this.edtInCHSeit.DataSource = this.qryBaPerson;
            this.edtInCHSeit.EditValue = null;
            this.edtInCHSeit.Location = new System.Drawing.Point(529, 212);
            this.edtInCHSeit.Name = "edtInCHSeit";
            this.edtInCHSeit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtInCHSeit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtInCHSeit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtInCHSeit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtInCHSeit.Properties.Appearance.Options.UseBackColor = true;
            this.edtInCHSeit.Properties.Appearance.Options.UseBorderColor = true;
            this.edtInCHSeit.Properties.Appearance.Options.UseFont = true;
            this.edtInCHSeit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtInCHSeit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtInCHSeit.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtInCHSeit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtInCHSeit.Properties.ShowToday = false;
            this.edtInCHSeit.Size = new System.Drawing.Size(95, 24);
            this.edtInCHSeit.TabIndex = 51;
            // 
            // lblInCHSeit
            // 
            this.lblInCHSeit.Location = new System.Drawing.Point(418, 212);
            this.lblInCHSeit.Name = "lblInCHSeit";
            this.lblInCHSeit.Size = new System.Drawing.Size(92, 24);
            this.lblInCHSeit.TabIndex = 50;
            this.lblInCHSeit.Text = "In Schweiz seit";
            this.lblInCHSeit.UseCompatibleTextRendering = true;
            // 
            // edtAuslaenderStatusCode
            // 
            this.edtAuslaenderStatusCode.DataMember = "AuslaenderStatusCode";
            this.edtAuslaenderStatusCode.DataSource = this.qryBaPerson;
            this.edtAuslaenderStatusCode.Location = new System.Drawing.Point(529, 182);
            this.edtAuslaenderStatusCode.LOVName = "BaAuslaenderAufenthaltStatus";
            this.edtAuslaenderStatusCode.Name = "edtAuslaenderStatusCode";
            this.edtAuslaenderStatusCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAuslaenderStatusCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAuslaenderStatusCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuslaenderStatusCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtAuslaenderStatusCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAuslaenderStatusCode.Properties.Appearance.Options.UseFont = true;
            this.edtAuslaenderStatusCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAuslaenderStatusCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuslaenderStatusCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAuslaenderStatusCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAuslaenderStatusCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtAuslaenderStatusCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtAuslaenderStatusCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAuslaenderStatusCode.Properties.NullText = "";
            this.edtAuslaenderStatusCode.Properties.PopupWidth = 250;
            this.edtAuslaenderStatusCode.Properties.ShowFooter = false;
            this.edtAuslaenderStatusCode.Properties.ShowHeader = false;
            this.edtAuslaenderStatusCode.Size = new System.Drawing.Size(178, 24);
            this.edtAuslaenderStatusCode.TabIndex = 49;
            // 
            // lblAuslStatus
            // 
            this.lblAuslStatus.Location = new System.Drawing.Point(418, 182);
            this.lblAuslStatus.Name = "lblAuslStatus";
            this.lblAuslStatus.Size = new System.Drawing.Size(92, 24);
            this.lblAuslStatus.TabIndex = 48;
            this.lblAuslStatus.Text = "Ausl.-Status";
            this.lblAuslStatus.UseCompatibleTextRendering = true;
            // 
            // edtKorrespondenzSpracheCode
            // 
            this.edtKorrespondenzSpracheCode.DataMember = "KorrespondenzSpracheCode";
            this.edtKorrespondenzSpracheCode.DataSource = this.qryBaPerson;
            this.edtKorrespondenzSpracheCode.Location = new System.Drawing.Point(529, 152);
            this.edtKorrespondenzSpracheCode.LOVName = "BaKorrespondenzSprache";
            this.edtKorrespondenzSpracheCode.Name = "edtKorrespondenzSpracheCode";
            this.edtKorrespondenzSpracheCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKorrespondenzSpracheCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKorrespondenzSpracheCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKorrespondenzSpracheCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtKorrespondenzSpracheCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKorrespondenzSpracheCode.Properties.Appearance.Options.UseFont = true;
            this.edtKorrespondenzSpracheCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKorrespondenzSpracheCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKorrespondenzSpracheCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKorrespondenzSpracheCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKorrespondenzSpracheCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtKorrespondenzSpracheCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtKorrespondenzSpracheCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKorrespondenzSpracheCode.Properties.NullText = "";
            this.edtKorrespondenzSpracheCode.Properties.ShowFooter = false;
            this.edtKorrespondenzSpracheCode.Properties.ShowHeader = false;
            this.edtKorrespondenzSpracheCode.Size = new System.Drawing.Size(178, 24);
            this.edtKorrespondenzSpracheCode.TabIndex = 47;
            // 
            // edtSprachCode
            // 
            this.edtSprachCode.DataMember = "SprachCode";
            this.edtSprachCode.DataSource = this.qryBaPerson;
            this.edtSprachCode.Location = new System.Drawing.Point(529, 129);
            this.edtSprachCode.LOVName = "BaSprache";
            this.edtSprachCode.Name = "edtSprachCode";
            this.edtSprachCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSprachCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSprachCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSprachCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtSprachCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSprachCode.Properties.Appearance.Options.UseFont = true;
            this.edtSprachCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSprachCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSprachCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSprachCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSprachCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtSprachCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtSprachCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSprachCode.Properties.NullText = "";
            this.edtSprachCode.Properties.ShowFooter = false;
            this.edtSprachCode.Properties.ShowHeader = false;
            this.edtSprachCode.Size = new System.Drawing.Size(178, 24);
            this.edtSprachCode.TabIndex = 45;
            // 
            // lblKorrespondenzSprache
            // 
            this.lblKorrespondenzSprache.Location = new System.Drawing.Point(418, 152);
            this.lblKorrespondenzSprache.Name = "lblKorrespondenzSprache";
            this.lblKorrespondenzSprache.Size = new System.Drawing.Size(92, 24);
            this.lblKorrespondenzSprache.TabIndex = 46;
            this.lblKorrespondenzSprache.Text = "Korrespondenz";
            this.lblKorrespondenzSprache.UseCompatibleTextRendering = true;
            // 
            // lblSprache
            // 
            this.lblSprache.Location = new System.Drawing.Point(418, 129);
            this.lblSprache.Name = "lblSprache";
            this.lblSprache.Size = new System.Drawing.Size(92, 24);
            this.lblSprache.TabIndex = 44;
            this.lblSprache.Text = "Sprache";
            this.lblSprache.UseCompatibleTextRendering = true;
            // 
            // edtPersonKlientenkontoNr
            // 
            this.edtPersonKlientenkontoNr.DataMember = "KlientenkontoNr";
            this.edtPersonKlientenkontoNr.DataSource = this.qryBaPerson;
            this.edtPersonKlientenkontoNr.Location = new System.Drawing.Point(529, 76);
            this.edtPersonKlientenkontoNr.Name = "edtPersonKlientenkontoNr";
            this.edtPersonKlientenkontoNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtPersonKlientenkontoNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPersonKlientenkontoNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPersonKlientenkontoNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPersonKlientenkontoNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtPersonKlientenkontoNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPersonKlientenkontoNr.Properties.Appearance.Options.UseFont = true;
            this.edtPersonKlientenkontoNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPersonKlientenkontoNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPersonKlientenkontoNr.Properties.Precision = 0;
            this.edtPersonKlientenkontoNr.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.edtPersonKlientenkontoNr.Size = new System.Drawing.Size(178, 24);
            this.edtPersonKlientenkontoNr.TabIndex = 41;
            // 
            // lblPersonKlientenkontoNr
            // 
            this.lblPersonKlientenkontoNr.Location = new System.Drawing.Point(418, 76);
            this.lblPersonKlientenkontoNr.Name = "lblPersonKlientenkontoNr";
            this.lblPersonKlientenkontoNr.Size = new System.Drawing.Size(105, 24);
            this.lblPersonKlientenkontoNr.TabIndex = 40;
            this.lblPersonKlientenkontoNr.Text = "Klientenkonto-Nr.";
            this.lblPersonKlientenkontoNr.UseCompatibleTextRendering = true;
            // 
            // edtBaPersonID
            // 
            this.edtBaPersonID.DataMember = "BaPersonIDVISNumber";
            this.edtBaPersonID.DataSource = this.qryBaPerson;
            this.edtBaPersonID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBaPersonID.Location = new System.Drawing.Point(529, 53);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBaPersonID.Properties.ReadOnly = true;
            this.edtBaPersonID.Size = new System.Drawing.Size(178, 24);
            this.edtBaPersonID.TabIndex = 39;
            this.edtBaPersonID.TabStop = false;
            // 
            // lblPersonNumber
            // 
            this.lblPersonNumber.Location = new System.Drawing.Point(418, 53);
            this.lblPersonNumber.Name = "lblPersonNumber";
            this.lblPersonNumber.Size = new System.Drawing.Size(92, 24);
            this.lblPersonNumber.TabIndex = 38;
            this.lblPersonNumber.Text = "Personen-Nr.";
            this.lblPersonNumber.UseCompatibleTextRendering = true;
            // 
            // chkKontoFuehrung
            // 
            this.chkKontoFuehrung.DataMember = "KontoFuehrung";
            this.chkKontoFuehrung.DataSource = this.qryBaPerson;
            this.chkKontoFuehrung.Location = new System.Drawing.Point(418, 28);
            this.chkKontoFuehrung.Name = "chkKontoFuehrung";
            this.chkKontoFuehrung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkKontoFuehrung.Properties.Appearance.Options.UseBackColor = true;
            this.chkKontoFuehrung.Properties.Caption = "Hat Kontoführung";
            this.chkKontoFuehrung.Size = new System.Drawing.Size(276, 19);
            this.chkKontoFuehrung.TabIndex = 37;
            // 
            // chkMehrfachbehinderungBSV
            // 
            this.chkMehrfachbehinderungBSV.DataMember = "Mehrfachbehinderung";
            this.chkMehrfachbehinderungBSV.DataSource = this.qryBaPerson;
            this.chkMehrfachbehinderungBSV.Location = new System.Drawing.Point(101, 424);
            this.chkMehrfachbehinderungBSV.Name = "chkMehrfachbehinderungBSV";
            this.chkMehrfachbehinderungBSV.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkMehrfachbehinderungBSV.Properties.Appearance.Options.UseBackColor = true;
            this.chkMehrfachbehinderungBSV.Properties.Caption = "Mehrfachbehinderung";
            this.chkMehrfachbehinderungBSV.Size = new System.Drawing.Size(313, 19);
            this.chkMehrfachbehinderungBSV.TabIndex = 35;
            // 
            // edtBSVBehinderungsartCode
            // 
            this.edtBSVBehinderungsartCode.DataMember = "BSVBehinderungsartCode";
            this.edtBSVBehinderungsartCode.DataSource = this.qryBaPerson;
            this.edtBSVBehinderungsartCode.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBSVBehinderungsartCode.Location = new System.Drawing.Point(101, 394);
            this.edtBSVBehinderungsartCode.LOVName = "BaBSVBehinderungsart";
            this.edtBSVBehinderungsartCode.Name = "edtBSVBehinderungsartCode";
            this.edtBSVBehinderungsartCode.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBSVBehinderungsartCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBSVBehinderungsartCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBSVBehinderungsartCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtBSVBehinderungsartCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBSVBehinderungsartCode.Properties.Appearance.Options.UseFont = true;
            this.edtBSVBehinderungsartCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBSVBehinderungsartCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBSVBehinderungsartCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBSVBehinderungsartCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBSVBehinderungsartCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtBSVBehinderungsartCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtBSVBehinderungsartCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBSVBehinderungsartCode.Properties.NullText = "";
            this.edtBSVBehinderungsartCode.Properties.ReadOnly = true;
            this.edtBSVBehinderungsartCode.Properties.ShowFooter = false;
            this.edtBSVBehinderungsartCode.Properties.ShowHeader = false;
            this.edtBSVBehinderungsartCode.Size = new System.Drawing.Size(300, 24);
            this.edtBSVBehinderungsartCode.TabIndex = 34;
            this.edtBSVBehinderungsartCode.TabStop = false;
            // 
            // lblBSVBehinderungsart
            // 
            this.lblBSVBehinderungsart.Location = new System.Drawing.Point(5, 394);
            this.lblBSVBehinderungsart.Name = "lblBSVBehinderungsart";
            this.lblBSVBehinderungsart.Size = new System.Drawing.Size(90, 24);
            this.lblBSVBehinderungsart.TabIndex = 33;
            this.lblBSVBehinderungsart.Text = "BSV Behind.Art";
            this.lblBSVBehinderungsart.UseCompatibleTextRendering = true;
            // 
            // edtBehinderungsart2Code
            // 
            this.edtBehinderungsart2Code.DataMember = "Behinderungsart2Code";
            this.edtBehinderungsart2Code.DataSource = this.qryBaPerson;
            this.edtBehinderungsart2Code.Location = new System.Drawing.Point(101, 371);
            this.edtBehinderungsart2Code.LOVName = "BaBehinderungsart";
            this.edtBehinderungsart2Code.Name = "edtBehinderungsart2Code";
            this.edtBehinderungsart2Code.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBehinderungsart2Code.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBehinderungsart2Code.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBehinderungsart2Code.Properties.Appearance.Options.UseBackColor = true;
            this.edtBehinderungsart2Code.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBehinderungsart2Code.Properties.Appearance.Options.UseFont = true;
            this.edtBehinderungsart2Code.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBehinderungsart2Code.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBehinderungsart2Code.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBehinderungsart2Code.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBehinderungsart2Code.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtBehinderungsart2Code.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtBehinderungsart2Code.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBehinderungsart2Code.Properties.NullText = "";
            this.edtBehinderungsart2Code.Properties.ShowFooter = false;
            this.edtBehinderungsart2Code.Properties.ShowHeader = false;
            this.edtBehinderungsart2Code.Size = new System.Drawing.Size(300, 24);
            this.edtBehinderungsart2Code.TabIndex = 32;
            // 
            // lblBehinderungsart2
            // 
            this.lblBehinderungsart2.Location = new System.Drawing.Point(5, 371);
            this.lblBehinderungsart2.Name = "lblBehinderungsart2";
            this.lblBehinderungsart2.Size = new System.Drawing.Size(90, 24);
            this.lblBehinderungsart2.TabIndex = 31;
            this.lblBehinderungsart2.Text = "Behind.Art 2";
            this.lblBehinderungsart2.UseCompatibleTextRendering = true;
            // 
            // edtHauptBehinderungsartCode
            // 
            this.edtHauptBehinderungsartCode.DataMember = "HauptBehinderungsartCode";
            this.edtHauptBehinderungsartCode.DataSource = this.qryBaPerson;
            this.edtHauptBehinderungsartCode.Location = new System.Drawing.Point(101, 348);
            this.edtHauptBehinderungsartCode.LOVName = "BaBehinderungsart";
            this.edtHauptBehinderungsartCode.Name = "edtHauptBehinderungsartCode";
            this.edtHauptBehinderungsartCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtHauptBehinderungsartCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHauptBehinderungsartCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHauptBehinderungsartCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtHauptBehinderungsartCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHauptBehinderungsartCode.Properties.Appearance.Options.UseFont = true;
            this.edtHauptBehinderungsartCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtHauptBehinderungsartCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtHauptBehinderungsartCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtHauptBehinderungsartCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtHauptBehinderungsartCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtHauptBehinderungsartCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtHauptBehinderungsartCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtHauptBehinderungsartCode.Properties.NullText = "";
            this.edtHauptBehinderungsartCode.Properties.ShowFooter = false;
            this.edtHauptBehinderungsartCode.Properties.ShowHeader = false;
            this.edtHauptBehinderungsartCode.Size = new System.Drawing.Size(300, 24);
            this.edtHauptBehinderungsartCode.TabIndex = 30;
            this.edtHauptBehinderungsartCode.EditValueChanged += new System.EventHandler(this.edtHauptBehinderungsartCode_EditValueChanged);
            // 
            // lblHauptbehinderungsArt
            // 
            this.lblHauptbehinderungsArt.Location = new System.Drawing.Point(5, 348);
            this.lblHauptbehinderungsArt.Name = "lblHauptbehinderungsArt";
            this.lblHauptbehinderungsArt.Size = new System.Drawing.Size(90, 24);
            this.lblHauptbehinderungsArt.TabIndex = 29;
            this.lblHauptbehinderungsArt.Text = "Hauptbehind.Art";
            this.lblHauptbehinderungsArt.UseCompatibleTextRendering = true;
            // 
            // edtHeimatGemeinde
            // 
            this.edtHeimatGemeinde.DataMember = "HeimatgemeindeName";
            this.edtHeimatGemeinde.DataSource = this.qryBaPerson;
            this.edtHeimatGemeinde.Location = new System.Drawing.Point(101, 318);
            this.edtHeimatGemeinde.Name = "edtHeimatGemeinde";
            this.edtHeimatGemeinde.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtHeimatGemeinde.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHeimatGemeinde.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHeimatGemeinde.Properties.Appearance.Options.UseBackColor = true;
            this.edtHeimatGemeinde.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHeimatGemeinde.Properties.Appearance.Options.UseFont = true;
            this.edtHeimatGemeinde.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtHeimatGemeinde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.edtHeimatGemeinde.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtHeimatGemeinde.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtHeimatGemeinde.Size = new System.Drawing.Size(300, 24);
            this.edtHeimatGemeinde.TabIndex = 28;
            this.edtHeimatGemeinde.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtHeimatGemeinde_UserModifiedFld);
            this.edtHeimatGemeinde.EditValueChanged += new System.EventHandler(this.edtHeimatGemeinde_EditValueChanged);
            // 
            // lblHeimatGemeinde
            // 
            this.lblHeimatGemeinde.Location = new System.Drawing.Point(5, 318);
            this.lblHeimatGemeinde.Name = "lblHeimatGemeinde";
            this.lblHeimatGemeinde.Size = new System.Drawing.Size(90, 24);
            this.lblHeimatGemeinde.TabIndex = 27;
            this.lblHeimatGemeinde.Text = "Heimatort";
            this.lblHeimatGemeinde.UseCompatibleTextRendering = true;
            // 
            // edtNationalitaetCode
            // 
            this.edtNationalitaetCode.DataMember = "NationalitaetCode";
            this.edtNationalitaetCode.DataSource = this.qryBaPerson;
            this.edtNationalitaetCode.Location = new System.Drawing.Point(101, 288);
            this.edtNationalitaetCode.Name = "edtNationalitaetCode";
            this.edtNationalitaetCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNationalitaetCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNationalitaetCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNationalitaetCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtNationalitaetCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNationalitaetCode.Properties.Appearance.Options.UseFont = true;
            this.edtNationalitaetCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtNationalitaetCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtNationalitaetCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtNationalitaetCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtNationalitaetCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.edtNationalitaetCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.edtNationalitaetCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNationalitaetCode.Properties.NullText = "";
            this.edtNationalitaetCode.Properties.ShowFooter = false;
            this.edtNationalitaetCode.Properties.ShowHeader = false;
            this.edtNationalitaetCode.Size = new System.Drawing.Size(300, 24);
            this.edtNationalitaetCode.TabIndex = 26;
            this.edtNationalitaetCode.EditValueChanged += new System.EventHandler(this.edtNationalitaetCode_EditValueChanged);
            // 
            // lblNation
            // 
            this.lblNation.Location = new System.Drawing.Point(5, 288);
            this.lblNation.Name = "lblNation";
            this.lblNation.Size = new System.Drawing.Size(90, 24);
            this.lblNation.TabIndex = 25;
            this.lblNation.Text = "Nationalität";
            this.lblNation.UseCompatibleTextRendering = true;
            // 
            // edtZivilstandCode
            // 
            this.edtZivilstandCode.DataMember = "ZivilstandCode";
            this.edtZivilstandCode.DataSource = this.qryBaPerson;
            this.edtZivilstandCode.Location = new System.Drawing.Point(101, 258);
            this.edtZivilstandCode.LOVName = "Zivilstand";
            this.edtZivilstandCode.Name = "edtZivilstandCode";
            this.edtZivilstandCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZivilstandCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZivilstandCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZivilstandCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtZivilstandCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZivilstandCode.Properties.Appearance.Options.UseFont = true;
            this.edtZivilstandCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtZivilstandCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtZivilstandCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtZivilstandCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtZivilstandCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject13.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject13.Options.UseBackColor = true;
            this.edtZivilstandCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13)});
            this.edtZivilstandCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZivilstandCode.Properties.NullText = "";
            this.edtZivilstandCode.Properties.ShowFooter = false;
            this.edtZivilstandCode.Properties.ShowHeader = false;
            this.edtZivilstandCode.Size = new System.Drawing.Size(300, 24);
            this.edtZivilstandCode.TabIndex = 24;
            // 
            // lblZivilstand
            // 
            this.lblZivilstand.Location = new System.Drawing.Point(5, 258);
            this.lblZivilstand.Name = "lblZivilstand";
            this.lblZivilstand.Size = new System.Drawing.Size(90, 24);
            this.lblZivilstand.TabIndex = 23;
            this.lblZivilstand.Text = "Zivilstand";
            this.lblZivilstand.UseCompatibleTextRendering = true;
            // 
            // edtGeschlechtCode
            // 
            this.edtGeschlechtCode.DataMember = "GeschlechtCode";
            this.edtGeschlechtCode.DataSource = this.qryBaPerson;
            this.edtGeschlechtCode.Location = new System.Drawing.Point(101, 235);
            this.edtGeschlechtCode.LOVName = "Geschlecht";
            this.edtGeschlechtCode.Name = "edtGeschlechtCode";
            this.edtGeschlechtCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGeschlechtCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeschlechtCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeschlechtCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeschlechtCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeschlechtCode.Properties.Appearance.Options.UseFont = true;
            this.edtGeschlechtCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtGeschlechtCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeschlechtCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtGeschlechtCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtGeschlechtCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject14.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject14.Options.UseBackColor = true;
            this.edtGeschlechtCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject14)});
            this.edtGeschlechtCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeschlechtCode.Properties.NullText = "";
            this.edtGeschlechtCode.Properties.ShowFooter = false;
            this.edtGeschlechtCode.Properties.ShowHeader = false;
            this.edtGeschlechtCode.Size = new System.Drawing.Size(300, 24);
            this.edtGeschlechtCode.TabIndex = 22;
            this.edtGeschlechtCode.EditValueChanged += new System.EventHandler(this.edtGeschlechtCode_EditValueChanged);
            // 
            // lblGeschlecht
            // 
            this.lblGeschlecht.Location = new System.Drawing.Point(5, 234);
            this.lblGeschlecht.Name = "lblGeschlecht";
            this.lblGeschlecht.Size = new System.Drawing.Size(90, 24);
            this.lblGeschlecht.TabIndex = 21;
            this.lblGeschlecht.Text = "Geschlecht";
            this.lblGeschlecht.UseCompatibleTextRendering = true;
            // 
            // edtSterbedatum
            // 
            this.edtSterbedatum.DataMember = "Sterbedatum";
            this.edtSterbedatum.DataSource = this.qryBaPerson;
            this.edtSterbedatum.EditValue = null;
            this.edtSterbedatum.Location = new System.Drawing.Point(306, 205);
            this.edtSterbedatum.Name = "edtSterbedatum";
            this.edtSterbedatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSterbedatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSterbedatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSterbedatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSterbedatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtSterbedatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSterbedatum.Properties.Appearance.Options.UseFont = true;
            this.edtSterbedatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject15.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject15.Options.UseBackColor = true;
            this.edtSterbedatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSterbedatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject15)});
            this.edtSterbedatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSterbedatum.Properties.ShowToday = false;
            this.edtSterbedatum.Size = new System.Drawing.Size(95, 24);
            this.edtSterbedatum.TabIndex = 20;
            this.edtSterbedatum.EditValueChanged += new System.EventHandler(this.edtSterbedatum_EditValueChanged);
            // 
            // lblTod
            // 
            this.lblTod.Location = new System.Drawing.Point(246, 206);
            this.lblTod.Name = "lblTod";
            this.lblTod.Size = new System.Drawing.Size(54, 24);
            this.lblTod.TabIndex = 19;
            this.lblTod.Text = "Tod";
            this.lblTod.UseCompatibleTextRendering = true;
            // 
            // edtGeburtsdatum
            // 
            this.edtGeburtsdatum.DataMember = "Geburtsdatum";
            this.edtGeburtsdatum.DataSource = this.qryBaPerson;
            this.edtGeburtsdatum.EditValue = null;
            this.edtGeburtsdatum.Location = new System.Drawing.Point(306, 182);
            this.edtGeburtsdatum.Name = "edtGeburtsdatum";
            this.edtGeburtsdatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGeburtsdatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGeburtsdatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeburtsdatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeburtsdatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeburtsdatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeburtsdatum.Properties.Appearance.Options.UseFont = true;
            this.edtGeburtsdatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject16.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject16.Options.UseBackColor = true;
            this.edtGeburtsdatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGeburtsdatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject16)});
            this.edtGeburtsdatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeburtsdatum.Properties.ShowToday = false;
            this.edtGeburtsdatum.Size = new System.Drawing.Size(95, 24);
            this.edtGeburtsdatum.TabIndex = 18;
            this.edtGeburtsdatum.EditValueChanged += new System.EventHandler(this.edtGeburtsdatum_EditValueChanged);
            // 
            // lblGeburt
            // 
            this.lblGeburt.Location = new System.Drawing.Point(246, 182);
            this.lblGeburt.Name = "lblGeburt";
            this.lblGeburt.Size = new System.Drawing.Size(54, 24);
            this.lblGeburt.TabIndex = 17;
            this.lblGeburt.Text = "Geburt";
            this.lblGeburt.UseCompatibleTextRendering = true;
            // 
            // edtVersicherungsNr
            // 
            this.edtVersicherungsNr.DataMember = "VersichertenNummer";
            this.edtVersicherungsNr.DataSource = this.qryBaPerson;
            this.edtVersicherungsNr.Location = new System.Drawing.Point(101, 182);
            this.edtVersicherungsNr.Name = "edtVersicherungsNr";
            this.edtVersicherungsNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVersicherungsNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVersicherungsNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVersicherungsNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVersicherungsNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtVersicherungsNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVersicherungsNr.Properties.Appearance.Options.UseFont = true;
            this.edtVersicherungsNr.Properties.Appearance.Options.UseTextOptions = true;
            this.edtVersicherungsNr.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.edtVersicherungsNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVersicherungsNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVersicherungsNr.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None);
            this.edtVersicherungsNr.Properties.DisplayFormat.FormatString = "000\\.0000\\.0000\\.00";
            this.edtVersicherungsNr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtVersicherungsNr.Properties.EditFormat.FormatString = "000\\.0000\\.0000\\.00";
            this.edtVersicherungsNr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtVersicherungsNr.Properties.Mask.EditMask = "000\\.0000\\.0000\\.00";
            this.edtVersicherungsNr.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.edtVersicherungsNr.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.edtVersicherungsNr.Properties.MaxLength = 13;
            this.edtVersicherungsNr.Properties.Precision = 0;
            this.edtVersicherungsNr.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.edtVersicherungsNr.Size = new System.Drawing.Size(135, 24);
            this.edtVersicherungsNr.TabIndex = 16;
            // 
            // lblVersicherungsNr
            // 
            this.lblVersicherungsNr.Location = new System.Drawing.Point(5, 182);
            this.lblVersicherungsNr.Name = "lblVersicherungsNr";
            this.lblVersicherungsNr.Size = new System.Drawing.Size(90, 24);
            this.lblVersicherungsNr.TabIndex = 15;
            this.lblVersicherungsNr.Text = "Vers.-Nr.";
            this.lblVersicherungsNr.UseCompatibleTextRendering = true;
            // 
            // edtFruehererName
            // 
            this.edtFruehererName.DataMember = "FruehererName";
            this.edtFruehererName.DataSource = this.qryBaPerson;
            this.edtFruehererName.Location = new System.Drawing.Point(101, 152);
            this.edtFruehererName.Name = "edtFruehererName";
            this.edtFruehererName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFruehererName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFruehererName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFruehererName.Properties.Appearance.Options.UseBackColor = true;
            this.edtFruehererName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFruehererName.Properties.Appearance.Options.UseFont = true;
            this.edtFruehererName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFruehererName.Size = new System.Drawing.Size(300, 24);
            this.edtFruehererName.TabIndex = 12;
            // 
            // lblFruehererName
            // 
            this.lblFruehererName.Location = new System.Drawing.Point(5, 152);
            this.lblFruehererName.Name = "lblFruehererName";
            this.lblFruehererName.Size = new System.Drawing.Size(90, 24);
            this.lblFruehererName.TabIndex = 11;
            this.lblFruehererName.Text = "Früherer Name";
            this.lblFruehererName.UseCompatibleTextRendering = true;
            // 
            // edtVorname
            // 
            this.edtVorname.DataMember = "Vorname";
            this.edtVorname.DataSource = this.qryBaPerson;
            this.edtVorname.Location = new System.Drawing.Point(288, 129);
            this.edtVorname.Name = "edtVorname";
            this.edtVorname.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVorname.Properties.Appearance.Options.UseFont = true;
            this.edtVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVorname.Size = new System.Drawing.Size(113, 24);
            this.edtVorname.TabIndex = 10;
            this.edtVorname.EditValueChanged += new System.EventHandler(this.edtVorname_EditValueChanged);
            // 
            // edtName
            // 
            this.edtName.DataMember = "Name";
            this.edtName.DataSource = this.qryBaPerson;
            this.edtName.Location = new System.Drawing.Point(101, 129);
            this.edtName.Name = "edtName";
            this.edtName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtName.Properties.Appearance.Options.UseBackColor = true;
            this.edtName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtName.Properties.Appearance.Options.UseFont = true;
            this.edtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtName.Size = new System.Drawing.Size(188, 24);
            this.edtName.TabIndex = 9;
            this.edtName.EditValueChanged += new System.EventHandler(this.edtName_EditValueChanged);
            // 
            // lblNameVorname
            // 
            this.lblNameVorname.Location = new System.Drawing.Point(5, 129);
            this.lblNameVorname.Name = "lblNameVorname";
            this.lblNameVorname.Size = new System.Drawing.Size(90, 24);
            this.lblNameVorname.TabIndex = 8;
            this.lblNameVorname.Text = "Name / Vorname";
            this.lblNameVorname.UseCompatibleTextRendering = true;
            // 
            // edtTitel
            // 
            this.edtTitel.DataMember = "Titel";
            this.edtTitel.DataSource = this.qryBaPerson;
            this.edtTitel.Location = new System.Drawing.Point(101, 30);
            this.edtTitel.Name = "edtTitel";
            this.edtTitel.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTitel.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTitel.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTitel.Properties.Appearance.Options.UseBackColor = true;
            this.edtTitel.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTitel.Properties.Appearance.Options.UseFont = true;
            this.edtTitel.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTitel.Size = new System.Drawing.Size(188, 24);
            this.edtTitel.TabIndex = 2;
            // 
            // lblPersonTitel
            // 
            this.lblPersonTitel.Location = new System.Drawing.Point(5, 30);
            this.lblPersonTitel.Name = "lblPersonTitel";
            this.lblPersonTitel.Size = new System.Drawing.Size(90, 24);
            this.lblPersonTitel.TabIndex = 1;
            this.lblPersonTitel.Text = "Titel";
            this.lblPersonTitel.UseCompatibleTextRendering = true;
            // 
            // chkLaufendeVollmachtErlaubnis
            // 
            this.chkLaufendeVollmachtErlaubnis.DataMember = "LaufendeVollmachtErlaubnis";
            this.chkLaufendeVollmachtErlaubnis.DataSource = this.qryBaPerson;
            this.chkLaufendeVollmachtErlaubnis.Location = new System.Drawing.Point(418, 5);
            this.chkLaufendeVollmachtErlaubnis.Name = "chkLaufendeVollmachtErlaubnis";
            this.chkLaufendeVollmachtErlaubnis.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkLaufendeVollmachtErlaubnis.Properties.Appearance.Options.UseBackColor = true;
            this.chkLaufendeVollmachtErlaubnis.Properties.Caption = "Laufende Vollmacht / Erlaubnis";
            this.chkLaufendeVollmachtErlaubnis.Size = new System.Drawing.Size(276, 19);
            this.chkLaufendeVollmachtErlaubnis.TabIndex = 36;
            // 
            // tpgAdresse
            // 
            this.tpgAdresse.Controls.Add(this._ctlBaPersonAdresse);
            this.tpgAdresse.Controls.Add(this.panTblAdresseBottom);
            this.tpgAdresse.Location = new System.Drawing.Point(6, 32);
            this.tpgAdresse.Name = "tpgAdresse";
            this.tpgAdresse.Size = new System.Drawing.Size(710, 624);
            this.tpgAdresse.TabIndex = 0;
            this.tpgAdresse.Title = "&Adressen";
            // 
            // _ctlBaPersonAdresse
            // 
            this._ctlBaPersonAdresse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this._ctlBaPersonAdresse.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ctlBaPersonAdresse.IsWohnstatusVisible = false;
            this._ctlBaPersonAdresse.Location = new System.Drawing.Point(0, 0);
            this._ctlBaPersonAdresse.Name = "_ctlBaPersonAdresse";
            this._ctlBaPersonAdresse.Size = new System.Drawing.Size(710, 524);
            this._ctlBaPersonAdresse.TabIndex = 0;
            this._ctlBaPersonAdresse.AfterDelete += new KiSS4.Basis.CtlBaPersonAdresse.AfterDeleteHandler(this._ctlBaPersonAdresse_AfterDelete);
            this._ctlBaPersonAdresse.AfterInsert += new KiSS4.Basis.CtlBaPersonAdresse.AfterInsertHandler(this._ctlBaPersonAdresse_AfterInsert);
            this._ctlBaPersonAdresse.PositionChanged += new KiSS4.Basis.CtlBaPersonAdresse.PositionChangedHandler(this._ctlBaPersonAdresse_PositionChanged);
            // 
            // panTblAdresseBottom
            // 
            this.panTblAdresseBottom.ColumnCount = 2;
            this.panTblAdresseBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panTblAdresseBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panTblAdresseBottom.Controls.Add(this.grpAdresseBemerkungen, 1, 0);
            this.panTblAdresseBottom.Controls.Add(this.grpWohnsitzDetails, 0, 0);
            this.panTblAdresseBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panTblAdresseBottom.Location = new System.Drawing.Point(0, 524);
            this.panTblAdresseBottom.Name = "panTblAdresseBottom";
            this.panTblAdresseBottom.RowCount = 1;
            this.panTblAdresseBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panTblAdresseBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panTblAdresseBottom.Size = new System.Drawing.Size(710, 100);
            this.panTblAdresseBottom.TabIndex = 1;
            // 
            // grpAdresseBemerkungen
            // 
            this.grpAdresseBemerkungen.Controls.Add(this.memBemerkungenAdresse);
            this.grpAdresseBemerkungen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAdresseBemerkungen.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grpAdresseBemerkungen.Location = new System.Drawing.Point(358, 3);
            this.grpAdresseBemerkungen.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.grpAdresseBemerkungen.Name = "grpAdresseBemerkungen";
            this.grpAdresseBemerkungen.Padding = new System.Windows.Forms.Padding(6);
            this.grpAdresseBemerkungen.Size = new System.Drawing.Size(347, 94);
            this.grpAdresseBemerkungen.TabIndex = 1;
            this.grpAdresseBemerkungen.TabStop = false;
            this.grpAdresseBemerkungen.Text = "Bemerkungen";
            // 
            // memBemerkungenAdresse
            // 
            this.memBemerkungenAdresse.DataMember = "BemerkungenAdresse";
            this.memBemerkungenAdresse.DataSource = this.qryBaPerson;
            this.memBemerkungenAdresse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memBemerkungenAdresse.Location = new System.Drawing.Point(6, 20);
            this.memBemerkungenAdresse.Name = "memBemerkungenAdresse";
            this.memBemerkungenAdresse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memBemerkungenAdresse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memBemerkungenAdresse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memBemerkungenAdresse.Properties.Appearance.Options.UseBackColor = true;
            this.memBemerkungenAdresse.Properties.Appearance.Options.UseBorderColor = true;
            this.memBemerkungenAdresse.Properties.Appearance.Options.UseFont = true;
            this.memBemerkungenAdresse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memBemerkungenAdresse.Size = new System.Drawing.Size(335, 68);
            this.memBemerkungenAdresse.TabIndex = 0;
            // 
            // grpWohnsitzDetails
            // 
            this.grpWohnsitzDetails.Controls.Add(this.chkEigenerMietvertrag);
            this.grpWohnsitzDetails.Controls.Add(this.chkMietdepotProInfirmis);
            this.grpWohnsitzDetails.Controls.Add(this.edtWohnsituationStatusCode);
            this.grpWohnsitzDetails.Controls.Add(this.lblAdresseWohnstatus);
            this.grpWohnsitzDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpWohnsitzDetails.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grpWohnsitzDetails.Location = new System.Drawing.Point(5, 5);
            this.grpWohnsitzDetails.Margin = new System.Windows.Forms.Padding(5);
            this.grpWohnsitzDetails.Name = "grpWohnsitzDetails";
            this.grpWohnsitzDetails.Size = new System.Drawing.Size(345, 90);
            this.grpWohnsitzDetails.TabIndex = 0;
            this.grpWohnsitzDetails.TabStop = false;
            this.grpWohnsitzDetails.Text = "Weitere Angaben";
            this.grpWohnsitzDetails.UseCompatibleTextRendering = true;
            // 
            // chkEigenerMietvertrag
            // 
            this.chkEigenerMietvertrag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkEigenerMietvertrag.DataMember = "EigenerMietvertrag";
            this.chkEigenerMietvertrag.DataSource = this.qryBaPerson;
            this.chkEigenerMietvertrag.Location = new System.Drawing.Point(109, 66);
            this.chkEigenerMietvertrag.Name = "chkEigenerMietvertrag";
            this.chkEigenerMietvertrag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkEigenerMietvertrag.Properties.Appearance.Options.UseBackColor = true;
            this.chkEigenerMietvertrag.Properties.Caption = "eigener Mietvertrag";
            this.chkEigenerMietvertrag.Size = new System.Drawing.Size(224, 19);
            this.chkEigenerMietvertrag.TabIndex = 3;
            // 
            // chkMietdepotProInfirmis
            // 
            this.chkMietdepotProInfirmis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkMietdepotProInfirmis.DataMember = "MietdepotPI";
            this.chkMietdepotProInfirmis.DataSource = this.qryBaPerson;
            this.chkMietdepotProInfirmis.Location = new System.Drawing.Point(109, 47);
            this.chkMietdepotProInfirmis.Name = "chkMietdepotProInfirmis";
            this.chkMietdepotProInfirmis.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkMietdepotProInfirmis.Properties.Appearance.Options.UseBackColor = true;
            this.chkMietdepotProInfirmis.Properties.Caption = "Mietdepot PI";
            this.chkMietdepotProInfirmis.Size = new System.Drawing.Size(224, 19);
            this.chkMietdepotProInfirmis.TabIndex = 2;
            // 
            // edtWohnsituationStatusCode
            // 
            this.edtWohnsituationStatusCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtWohnsituationStatusCode.DataMember = "WohnstatusCode";
            this.edtWohnsituationStatusCode.DataSource = this.qryBaPerson;
            this.edtWohnsituationStatusCode.Location = new System.Drawing.Point(109, 17);
            this.edtWohnsituationStatusCode.LOVName = "BaWohnstatus";
            this.edtWohnsituationStatusCode.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.edtWohnsituationStatusCode.Name = "edtWohnsituationStatusCode";
            this.edtWohnsituationStatusCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWohnsituationStatusCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWohnsituationStatusCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWohnsituationStatusCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtWohnsituationStatusCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWohnsituationStatusCode.Properties.Appearance.Options.UseFont = true;
            this.edtWohnsituationStatusCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtWohnsituationStatusCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtWohnsituationStatusCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtWohnsituationStatusCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtWohnsituationStatusCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject17.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject17.Options.UseBackColor = true;
            this.edtWohnsituationStatusCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject17)});
            this.edtWohnsituationStatusCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtWohnsituationStatusCode.Properties.NullText = "";
            this.edtWohnsituationStatusCode.Properties.ShowFooter = false;
            this.edtWohnsituationStatusCode.Properties.ShowHeader = false;
            this.edtWohnsituationStatusCode.Size = new System.Drawing.Size(224, 24);
            this.edtWohnsituationStatusCode.TabIndex = 1;
            // 
            // lblAdresseWohnstatus
            // 
            this.lblAdresseWohnstatus.Location = new System.Drawing.Point(7, 17);
            this.lblAdresseWohnstatus.Name = "lblAdresseWohnstatus";
            this.lblAdresseWohnstatus.Size = new System.Drawing.Size(96, 24);
            this.lblAdresseWohnstatus.TabIndex = 0;
            this.lblAdresseWohnstatus.Text = "Wohnstatus";
            this.lblAdresseWohnstatus.UseCompatibleTextRendering = true;
            // 
            // tpgKontaktBankPost
            // 
            this.tpgKontaktBankPost.Controls.Add(this.grpBankPostZahlungsverbindungen);
            this.tpgKontaktBankPost.Controls.Add(this.panKontakt);
            this.tpgKontaktBankPost.Location = new System.Drawing.Point(6, 32);
            this.tpgKontaktBankPost.Name = "tpgKontaktBankPost";
            this.tpgKontaktBankPost.Size = new System.Drawing.Size(710, 624);
            this.tpgKontaktBankPost.TabIndex = 1;
            this.tpgKontaktBankPost.Title = "Kontakt / &Bank, Post";
            // 
            // grpBankPostZahlungsverbindungen
            // 
            this.grpBankPostZahlungsverbindungen.Controls.Add(this._ctlBaZahlungsweg);
            this.grpBankPostZahlungsverbindungen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBankPostZahlungsverbindungen.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grpBankPostZahlungsverbindungen.Location = new System.Drawing.Point(0, 161);
            this.grpBankPostZahlungsverbindungen.Name = "grpBankPostZahlungsverbindungen";
            this.grpBankPostZahlungsverbindungen.Padding = new System.Windows.Forms.Padding(6);
            this.grpBankPostZahlungsverbindungen.Size = new System.Drawing.Size(710, 463);
            this.grpBankPostZahlungsverbindungen.TabIndex = 1;
            this.grpBankPostZahlungsverbindungen.TabStop = false;
            this.grpBankPostZahlungsverbindungen.Text = "Zahlungsverbindungen - Bank, Post";
            // 
            // _ctlBaZahlungsweg
            // 
            this._ctlBaZahlungsweg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this._ctlBaZahlungsweg.BaInstitutionID = 0;
            this._ctlBaZahlungsweg.BaPersonID = 1;
            this._ctlBaZahlungsweg.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ctlBaZahlungsweg.Location = new System.Drawing.Point(6, 20);
            this._ctlBaZahlungsweg.Name = "_ctlBaZahlungsweg";
            this._ctlBaZahlungsweg.Size = new System.Drawing.Size(698, 437);
            this._ctlBaZahlungsweg.TabIndex = 0;
            // 
            // panKontakt
            // 
            this.panKontakt.Controls.Add(this.grpKontakt);
            this.panKontakt.Dock = System.Windows.Forms.DockStyle.Top;
            this.panKontakt.Location = new System.Drawing.Point(0, 0);
            this.panKontakt.Name = "panKontakt";
            this.panKontakt.Size = new System.Drawing.Size(710, 161);
            this.panKontakt.TabIndex = 0;
            // 
            // grpKontakt
            // 
            this.grpKontakt.Controls.Add(this.edtEMail);
            this.grpKontakt.Controls.Add(this.lblEmail);
            this.grpKontakt.Controls.Add(this.edtFax);
            this.grpKontakt.Controls.Add(this.lblFax);
            this.grpKontakt.Controls.Add(this.chkZeigeTelMobil);
            this.grpKontakt.Controls.Add(this.edtMobilTel);
            this.grpKontakt.Controls.Add(this.lblTelefonMobil);
            this.grpKontakt.Controls.Add(this.chkZeigeTelGeschaeft);
            this.grpKontakt.Controls.Add(this.edtTelefon_G);
            this.grpKontakt.Controls.Add(this.lblTelefonGeschaeft);
            this.grpKontakt.Controls.Add(this.chkZeigeTelPrivat);
            this.grpKontakt.Controls.Add(this.edtTelefon_P);
            this.grpKontakt.Controls.Add(this.lblTelefonPrivat);
            this.grpKontakt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grpKontakt.Location = new System.Drawing.Point(4, 6);
            this.grpKontakt.Name = "grpKontakt";
            this.grpKontakt.Size = new System.Drawing.Size(394, 149);
            this.grpKontakt.TabIndex = 0;
            this.grpKontakt.TabStop = false;
            this.grpKontakt.Text = "Kontakt";
            this.grpKontakt.UseCompatibleTextRendering = true;
            // 
            // edtEMail
            // 
            this.edtEMail.DataMember = "EMail";
            this.edtEMail.DataSource = this.qryBaPerson;
            this.edtEMail.Location = new System.Drawing.Point(106, 115);
            this.edtEMail.Name = "edtEMail";
            this.edtEMail.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEMail.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEMail.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEMail.Properties.Appearance.Options.UseBackColor = true;
            this.edtEMail.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEMail.Properties.Appearance.Options.UseFont = true;
            this.edtEMail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEMail.Size = new System.Drawing.Size(275, 24);
            this.edtEMail.TabIndex = 12;
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(7, 115);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(93, 24);
            this.lblEmail.TabIndex = 11;
            this.lblEmail.Text = "E-Mail";
            this.lblEmail.UseCompatibleTextRendering = true;
            // 
            // edtFax
            // 
            this.edtFax.DataMember = "Fax";
            this.edtFax.DataSource = this.qryBaPerson;
            this.edtFax.Location = new System.Drawing.Point(106, 92);
            this.edtFax.Name = "edtFax";
            this.edtFax.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFax.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFax.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFax.Properties.Appearance.Options.UseBackColor = true;
            this.edtFax.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFax.Properties.Appearance.Options.UseFont = true;
            this.edtFax.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFax.Size = new System.Drawing.Size(275, 24);
            this.edtFax.TabIndex = 10;
            // 
            // lblFax
            // 
            this.lblFax.Location = new System.Drawing.Point(7, 92);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(93, 24);
            this.lblFax.TabIndex = 9;
            this.lblFax.Text = "Fax";
            this.lblFax.UseCompatibleTextRendering = true;
            // 
            // chkZeigeTelMobil
            // 
            this.chkZeigeTelMobil.DataMember = "ZeigeTelMobil";
            this.chkZeigeTelMobil.DataSource = this.qryBaPerson;
            this.chkZeigeTelMobil.Location = new System.Drawing.Point(361, 66);
            this.chkZeigeTelMobil.Name = "chkZeigeTelMobil";
            this.chkZeigeTelMobil.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkZeigeTelMobil.Properties.Appearance.Options.UseBackColor = true;
            this.chkZeigeTelMobil.Properties.Caption = " .";
            this.chkZeigeTelMobil.Size = new System.Drawing.Size(25, 19);
            this.chkZeigeTelMobil.TabIndex = 8;
            // 
            // edtMobilTel
            // 
            this.edtMobilTel.DataMember = "MobilTel";
            this.edtMobilTel.DataSource = this.qryBaPerson;
            this.edtMobilTel.Location = new System.Drawing.Point(106, 62);
            this.edtMobilTel.Name = "edtMobilTel";
            this.edtMobilTel.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMobilTel.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMobilTel.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMobilTel.Properties.Appearance.Options.UseBackColor = true;
            this.edtMobilTel.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMobilTel.Properties.Appearance.Options.UseFont = true;
            this.edtMobilTel.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMobilTel.Size = new System.Drawing.Size(245, 24);
            this.edtMobilTel.TabIndex = 7;
            // 
            // lblTelefonMobil
            // 
            this.lblTelefonMobil.Location = new System.Drawing.Point(7, 62);
            this.lblTelefonMobil.Name = "lblTelefonMobil";
            this.lblTelefonMobil.Size = new System.Drawing.Size(93, 24);
            this.lblTelefonMobil.TabIndex = 6;
            this.lblTelefonMobil.Text = "Telefon mobil";
            this.lblTelefonMobil.UseCompatibleTextRendering = true;
            // 
            // chkZeigeTelGeschaeft
            // 
            this.chkZeigeTelGeschaeft.DataMember = "ZeigeTelGeschaeft";
            this.chkZeigeTelGeschaeft.DataSource = this.qryBaPerson;
            this.chkZeigeTelGeschaeft.Location = new System.Drawing.Point(361, 42);
            this.chkZeigeTelGeschaeft.Name = "chkZeigeTelGeschaeft";
            this.chkZeigeTelGeschaeft.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkZeigeTelGeschaeft.Properties.Appearance.Options.UseBackColor = true;
            this.chkZeigeTelGeschaeft.Properties.Caption = " .";
            this.chkZeigeTelGeschaeft.Size = new System.Drawing.Size(25, 19);
            this.chkZeigeTelGeschaeft.TabIndex = 5;
            // 
            // edtTelefon_G
            // 
            this.edtTelefon_G.DataMember = "Telefon_G";
            this.edtTelefon_G.DataSource = this.qryBaPerson;
            this.edtTelefon_G.Location = new System.Drawing.Point(106, 39);
            this.edtTelefon_G.Name = "edtTelefon_G";
            this.edtTelefon_G.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTelefon_G.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTelefon_G.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTelefon_G.Properties.Appearance.Options.UseBackColor = true;
            this.edtTelefon_G.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTelefon_G.Properties.Appearance.Options.UseFont = true;
            this.edtTelefon_G.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTelefon_G.Size = new System.Drawing.Size(245, 24);
            this.edtTelefon_G.TabIndex = 4;
            // 
            // lblTelefonGeschaeft
            // 
            this.lblTelefonGeschaeft.Location = new System.Drawing.Point(7, 39);
            this.lblTelefonGeschaeft.Name = "lblTelefonGeschaeft";
            this.lblTelefonGeschaeft.Size = new System.Drawing.Size(93, 24);
            this.lblTelefonGeschaeft.TabIndex = 3;
            this.lblTelefonGeschaeft.Text = "Telefon gesch.";
            this.lblTelefonGeschaeft.UseCompatibleTextRendering = true;
            // 
            // chkZeigeTelPrivat
            // 
            this.chkZeigeTelPrivat.DataMember = "ZeigeTelPrivat";
            this.chkZeigeTelPrivat.DataSource = this.qryBaPerson;
            this.chkZeigeTelPrivat.Location = new System.Drawing.Point(361, 18);
            this.chkZeigeTelPrivat.Name = "chkZeigeTelPrivat";
            this.chkZeigeTelPrivat.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkZeigeTelPrivat.Properties.Appearance.Options.UseBackColor = true;
            this.chkZeigeTelPrivat.Properties.Caption = " .";
            this.chkZeigeTelPrivat.Size = new System.Drawing.Size(25, 19);
            this.chkZeigeTelPrivat.TabIndex = 2;
            // 
            // edtTelefon_P
            // 
            this.edtTelefon_P.DataMember = "Telefon_P";
            this.edtTelefon_P.DataSource = this.qryBaPerson;
            this.edtTelefon_P.Location = new System.Drawing.Point(106, 16);
            this.edtTelefon_P.Name = "edtTelefon_P";
            this.edtTelefon_P.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTelefon_P.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTelefon_P.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTelefon_P.Properties.Appearance.Options.UseBackColor = true;
            this.edtTelefon_P.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTelefon_P.Properties.Appearance.Options.UseFont = true;
            this.edtTelefon_P.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTelefon_P.Size = new System.Drawing.Size(245, 24);
            this.edtTelefon_P.TabIndex = 1;
            // 
            // lblTelefonPrivat
            // 
            this.lblTelefonPrivat.Location = new System.Drawing.Point(7, 16);
            this.lblTelefonPrivat.Name = "lblTelefonPrivat";
            this.lblTelefonPrivat.Size = new System.Drawing.Size(93, 24);
            this.lblTelefonPrivat.TabIndex = 0;
            this.lblTelefonPrivat.Text = "Telefon privat";
            this.lblTelefonPrivat.UseCompatibleTextRendering = true;
            // 
            // tpgSozialversicherung
            // 
            this.tpgSozialversicherung.AutoScroll = true;
            this.tpgSozialversicherung.AutoScrollMinSize = new System.Drawing.Size(709, 623);
            this.tpgSozialversicherung.Controls.Add(this.grpAssistenz);
            this.tpgSozialversicherung.Controls.Add(this.lblWitwenWitwerWaisenrente);
            this.tpgSozialversicherung.Controls.Add(this.chkWittwenWittwerWaisenrente);
            this.tpgSozialversicherung.Controls.Add(this.memBemerkungenSV);
            this.tpgSozialversicherung.Controls.Add(this.lblSozialversicherungBemerkungen);
            this.tpgSozialversicherung.Controls.Add(this.memAndereSVLeistungen);
            this.tpgSozialversicherung.Controls.Add(this.lblAndereSVLeistungen);
            this.tpgSozialversicherung.Controls.Add(this.chkKTG);
            this.tpgSozialversicherung.Controls.Add(this.lblKTG);
            this.tpgSozialversicherung.Controls.Add(this.chkALK);
            this.tpgSozialversicherung.Controls.Add(this.lblALK);
            this.tpgSozialversicherung.Controls.Add(this.chkSozialhilfe);
            this.tpgSozialversicherung.Controls.Add(this.lblSozialhilfe);
            this.tpgSozialversicherung.Controls.Add(this.chkUVGTaggeld);
            this.tpgSozialversicherung.Controls.Add(this.lblUVGTaggeld);
            this.tpgSozialversicherung.Controls.Add(this.chkUVGRente);
            this.tpgSozialversicherung.Controls.Add(this.lblUVGRente);
            this.tpgSozialversicherung.Controls.Add(this.chkBVGRente);
            this.tpgSozialversicherung.Controls.Add(this.lblBVGRente);
            this.tpgSozialversicherung.Controls.Add(this.chkErgaenzungsLeistungen);
            this.tpgSozialversicherung.Controls.Add(this.lblErgaenzungsleistungen);
            this.tpgSozialversicherung.Controls.Add(this.chkMedizinischeMassnahmeIV);
            this.tpgSozialversicherung.Controls.Add(this.chkIVHilfsmittel);
            this.tpgSozialversicherung.Controls.Add(this.lblMedizinischeMassnahmeIV);
            this.tpgSozialversicherung.Controls.Add(this.lblIVHilfsmittel);
            this.tpgSozialversicherung.Controls.Add(this.chkBeruflicheMassnahmeIV);
            this.tpgSozialversicherung.Controls.Add(this.lblBeruflicheMassnahmenIV);
            this.tpgSozialversicherung.Controls.Add(this.chkIVTaggeld);
            this.tpgSozialversicherung.Controls.Add(this.lblIVTaggeld);
            this.tpgSozialversicherung.Controls.Add(this.edtIntensivPflegeZuschlag);
            this.tpgSozialversicherung.Controls.Add(this.lblIntensivPflegeZuschlag);
            this.tpgSozialversicherung.Controls.Add(this.grpKantonaleZuschuesse);
            this.tpgSozialversicherung.Controls.Add(this.grpHELB);
            this.tpgSozialversicherung.Controls.Add(this.edtHilfslosenEntschaedigung);
            this.tpgSozialversicherung.Controls.Add(this.lblHilfslosenentschaedigung);
            this.tpgSozialversicherung.Controls.Add(this.lblIVGradProzent);
            this.tpgSozialversicherung.Controls.Add(this.edtIVGrad);
            this.tpgSozialversicherung.Controls.Add(this.lblIVGrad);
            this.tpgSozialversicherung.Controls.Add(this.edtRentenstufe);
            this.tpgSozialversicherung.Controls.Add(this.lblRentenstufe);
            this.tpgSozialversicherung.Location = new System.Drawing.Point(6, 32);
            this.tpgSozialversicherung.Name = "tpgSozialversicherung";
            this.tpgSozialversicherung.Size = new System.Drawing.Size(710, 624);
            this.tpgSozialversicherung.TabIndex = 0;
            this.tpgSozialversicherung.Title = "So&zialversicherung";
            // 
            // grpAssistenz
            // 
            this.grpAssistenz.Controls.Add(this.lblAssistenzbeitrag);
            this.grpAssistenz.Controls.Add(this.lblDatumVerfuegung);
            this.grpAssistenz.Controls.Add(this.edtAssistenzbeitrag);
            this.grpAssistenz.Controls.Add(this.lblABeitragAb);
            this.grpAssistenz.Controls.Add(this.lblIvVerfuegteAssistenzberatung);
            this.grpAssistenz.Controls.Add(this.edtDatumVerfuegung);
            this.grpAssistenz.Controls.Add(this.edtIvVerfuegteAssistenzberatung);
            this.grpAssistenz.Controls.Add(this.edtABeitragAb);
            this.grpAssistenz.Controls.Add(this.lblIvVerfuegteAssistenzberatungStunden);
            this.grpAssistenz.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grpAssistenz.Location = new System.Drawing.Point(9, 472);
            this.grpAssistenz.Name = "grpAssistenz";
            this.grpAssistenz.Size = new System.Drawing.Size(270, 148);
            this.grpAssistenz.TabIndex = 47;
            this.grpAssistenz.TabStop = false;
            this.grpAssistenz.Text = "Assistenz";
            this.grpAssistenz.UseCompatibleTextRendering = true;
            // 
            // lblAssistenzbeitrag
            // 
            this.lblAssistenzbeitrag.Location = new System.Drawing.Point(10, 21);
            this.lblAssistenzbeitrag.Name = "lblAssistenzbeitrag";
            this.lblAssistenzbeitrag.Size = new System.Drawing.Size(128, 24);
            this.lblAssistenzbeitrag.TabIndex = 39;
            this.lblAssistenzbeitrag.Text = "Assistenzbeitrag";
            this.lblAssistenzbeitrag.UseCompatibleTextRendering = true;
            // 
            // lblDatumVerfuegung
            // 
            this.lblDatumVerfuegung.Location = new System.Drawing.Point(10, 111);
            this.lblDatumVerfuegung.Name = "lblDatumVerfuegung";
            this.lblDatumVerfuegung.Size = new System.Drawing.Size(128, 24);
            this.lblDatumVerfuegung.TabIndex = 46;
            this.lblDatumVerfuegung.Text = "Datum Verfügung ab";
            this.lblDatumVerfuegung.UseCompatibleTextRendering = true;
            // 
            // edtAssistenzbeitrag
            // 
            this.edtAssistenzbeitrag.DataMember = "Assistenzbeitrag";
            this.edtAssistenzbeitrag.DataSource = this.qryBaPerson;
            this.edtAssistenzbeitrag.Location = new System.Drawing.Point(144, 24);
            this.edtAssistenzbeitrag.Name = "edtAssistenzbeitrag";
            this.edtAssistenzbeitrag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAssistenzbeitrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtAssistenzbeitrag.Properties.Caption = " .";
            this.edtAssistenzbeitrag.Size = new System.Drawing.Size(25, 19);
            this.edtAssistenzbeitrag.TabIndex = 40;
            // 
            // lblABeitragAb
            // 
            this.lblABeitragAb.Location = new System.Drawing.Point(10, 51);
            this.lblABeitragAb.Name = "lblABeitragAb";
            this.lblABeitragAb.Size = new System.Drawing.Size(128, 24);
            this.lblABeitragAb.TabIndex = 45;
            this.lblABeitragAb.Text = "Assistenzbeitrag ab";
            this.lblABeitragAb.UseCompatibleTextRendering = true;
            // 
            // lblIvVerfuegteAssistenzberatung
            // 
            this.lblIvVerfuegteAssistenzberatung.Location = new System.Drawing.Point(10, 81);
            this.lblIvVerfuegteAssistenzberatung.Name = "lblIvVerfuegteAssistenzberatung";
            this.lblIvVerfuegteAssistenzberatung.Size = new System.Drawing.Size(128, 24);
            this.lblIvVerfuegteAssistenzberatung.TabIndex = 41;
            this.lblIvVerfuegteAssistenzberatung.Text = "IV verfügte AB";
            this.lblIvVerfuegteAssistenzberatung.UseCompatibleTextRendering = true;
            // 
            // edtDatumVerfuegung
            // 
            this.edtDatumVerfuegung.DataMember = "DatumIvVerfuegung";
            this.edtDatumVerfuegung.DataSource = this.qryBaPerson;
            this.edtDatumVerfuegung.EditValue = null;
            this.edtDatumVerfuegung.Location = new System.Drawing.Point(144, 111);
            this.edtDatumVerfuegung.Name = "edtDatumVerfuegung";
            this.edtDatumVerfuegung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVerfuegung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVerfuegung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVerfuegung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVerfuegung.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVerfuegung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVerfuegung.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVerfuegung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject18.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject18.Options.UseBackColor = true;
            this.edtDatumVerfuegung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVerfuegung.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject18)});
            this.edtDatumVerfuegung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVerfuegung.Properties.ShowToday = false;
            this.edtDatumVerfuegung.Size = new System.Drawing.Size(112, 24);
            this.edtDatumVerfuegung.TabIndex = 44;
            // 
            // edtIvVerfuegteAssistenzberatung
            // 
            this.edtIvVerfuegteAssistenzberatung.DataMember = "IvVerfuegteAssistenzberatung";
            this.edtIvVerfuegteAssistenzberatung.DataSource = this.qryBaPerson;
            this.edtIvVerfuegteAssistenzberatung.Location = new System.Drawing.Point(144, 81);
            this.edtIvVerfuegteAssistenzberatung.Name = "edtIvVerfuegteAssistenzberatung";
            this.edtIvVerfuegteAssistenzberatung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtIvVerfuegteAssistenzberatung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIvVerfuegteAssistenzberatung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIvVerfuegteAssistenzberatung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIvVerfuegteAssistenzberatung.Properties.Appearance.Options.UseBackColor = true;
            this.edtIvVerfuegteAssistenzberatung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIvVerfuegteAssistenzberatung.Properties.Appearance.Options.UseFont = true;
            this.edtIvVerfuegteAssistenzberatung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtIvVerfuegteAssistenzberatung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIvVerfuegteAssistenzberatung.Properties.DisplayFormat.FormatString = "F3";
            this.edtIvVerfuegteAssistenzberatung.Properties.EditFormat.FormatString = "F3";
            this.edtIvVerfuegteAssistenzberatung.Properties.Mask.EditMask = "##";
            this.edtIvVerfuegteAssistenzberatung.Properties.MaxLength = 2;
            this.edtIvVerfuegteAssistenzberatung.Properties.Precision = 0;
            this.edtIvVerfuegteAssistenzberatung.Size = new System.Drawing.Size(45, 24);
            this.edtIvVerfuegteAssistenzberatung.TabIndex = 42;
            // 
            // edtABeitragAb
            // 
            this.edtABeitragAb.DataMember = "DatumAssistenzbeitrag";
            this.edtABeitragAb.DataSource = this.qryBaPerson;
            this.edtABeitragAb.EditValue = null;
            this.edtABeitragAb.Location = new System.Drawing.Point(144, 51);
            this.edtABeitragAb.Name = "edtABeitragAb";
            this.edtABeitragAb.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtABeitragAb.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtABeitragAb.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtABeitragAb.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtABeitragAb.Properties.Appearance.Options.UseBackColor = true;
            this.edtABeitragAb.Properties.Appearance.Options.UseBorderColor = true;
            this.edtABeitragAb.Properties.Appearance.Options.UseFont = true;
            this.edtABeitragAb.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject19.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject19.Options.UseBackColor = true;
            this.edtABeitragAb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtABeitragAb.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject19)});
            this.edtABeitragAb.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtABeitragAb.Properties.ShowToday = false;
            this.edtABeitragAb.Size = new System.Drawing.Size(112, 24);
            this.edtABeitragAb.TabIndex = 10;
            // 
            // lblIvVerfuegteAssistenzberatungStunden
            // 
            this.lblIvVerfuegteAssistenzberatungStunden.Location = new System.Drawing.Point(195, 81);
            this.lblIvVerfuegteAssistenzberatungStunden.Name = "lblIvVerfuegteAssistenzberatungStunden";
            this.lblIvVerfuegteAssistenzberatungStunden.Size = new System.Drawing.Size(16, 24);
            this.lblIvVerfuegteAssistenzberatungStunden.TabIndex = 43;
            this.lblIvVerfuegteAssistenzberatungStunden.Text = "h";
            this.lblIvVerfuegteAssistenzberatungStunden.UseCompatibleTextRendering = true;
            // 
            // lblWitwenWitwerWaisenrente
            // 
            this.lblWitwenWitwerWaisenrente.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblWitwenWitwerWaisenrente.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblWitwenWitwerWaisenrente.Location = new System.Drawing.Point(550, 310);
            this.lblWitwenWitwerWaisenrente.Name = "lblWitwenWitwerWaisenrente";
            this.lblWitwenWitwerWaisenrente.Size = new System.Drawing.Size(126, 33);
            this.lblWitwenWitwerWaisenrente.TabIndex = 38;
            this.lblWitwenWitwerWaisenrente.Text = "Witwen-/Witwer-/\r\nWaisenrente";
            this.lblWitwenWitwerWaisenrente.UseCompatibleTextRendering = true;
            // 
            // chkWittwenWittwerWaisenrente
            // 
            this.chkWittwenWittwerWaisenrente.DataMember = "WittwenWittwerWaisenrente";
            this.chkWittwenWittwerWaisenrente.DataSource = this.qryBaPerson;
            this.chkWittwenWittwerWaisenrente.Location = new System.Drawing.Point(682, 309);
            this.chkWittwenWittwerWaisenrente.Name = "chkWittwenWittwerWaisenrente";
            this.chkWittwenWittwerWaisenrente.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkWittwenWittwerWaisenrente.Properties.Appearance.Options.UseBackColor = true;
            this.chkWittwenWittwerWaisenrente.Properties.Caption = " .";
            this.chkWittwenWittwerWaisenrente.Size = new System.Drawing.Size(25, 19);
            this.chkWittwenWittwerWaisenrente.TabIndex = 37;
            // 
            // memBemerkungenSV
            // 
            this.memBemerkungenSV.DataMember = "BemerkungenSV";
            this.memBemerkungenSV.DataSource = this.qryBaPerson;
            this.memBemerkungenSV.Location = new System.Drawing.Point(356, 436);
            this.memBemerkungenSV.Name = "memBemerkungenSV";
            this.memBemerkungenSV.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memBemerkungenSV.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memBemerkungenSV.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memBemerkungenSV.Properties.Appearance.Options.UseBackColor = true;
            this.memBemerkungenSV.Properties.Appearance.Options.UseBorderColor = true;
            this.memBemerkungenSV.Properties.Appearance.Options.UseFont = true;
            this.memBemerkungenSV.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memBemerkungenSV.Size = new System.Drawing.Size(351, 89);
            this.memBemerkungenSV.TabIndex = 36;
            // 
            // lblSozialversicherungBemerkungen
            // 
            this.lblSozialversicherungBemerkungen.Location = new System.Drawing.Point(222, 436);
            this.lblSozialversicherungBemerkungen.Name = "lblSozialversicherungBemerkungen";
            this.lblSozialversicherungBemerkungen.Size = new System.Drawing.Size(128, 24);
            this.lblSozialversicherungBemerkungen.TabIndex = 35;
            this.lblSozialversicherungBemerkungen.Text = "Bemerkungen";
            this.lblSozialversicherungBemerkungen.UseCompatibleTextRendering = true;
            // 
            // memAndereSVLeistungen
            // 
            this.memAndereSVLeistungen.DataMember = "AndereSVLeistungen";
            this.memAndereSVLeistungen.DataSource = this.qryBaPerson;
            this.memAndereSVLeistungen.Location = new System.Drawing.Point(356, 346);
            this.memAndereSVLeistungen.Name = "memAndereSVLeistungen";
            this.memAndereSVLeistungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memAndereSVLeistungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memAndereSVLeistungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memAndereSVLeistungen.Properties.Appearance.Options.UseBackColor = true;
            this.memAndereSVLeistungen.Properties.Appearance.Options.UseBorderColor = true;
            this.memAndereSVLeistungen.Properties.Appearance.Options.UseFont = true;
            this.memAndereSVLeistungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memAndereSVLeistungen.Size = new System.Drawing.Size(351, 84);
            this.memAndereSVLeistungen.TabIndex = 34;
            // 
            // lblAndereSVLeistungen
            // 
            this.lblAndereSVLeistungen.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblAndereSVLeistungen.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblAndereSVLeistungen.Location = new System.Drawing.Point(222, 346);
            this.lblAndereSVLeistungen.Name = "lblAndereSVLeistungen";
            this.lblAndereSVLeistungen.Size = new System.Drawing.Size(128, 63);
            this.lblAndereSVLeistungen.TabIndex = 33;
            this.lblAndereSVLeistungen.Text = "Andere Sozialversicherungs-\r\nleistungen";
            this.lblAndereSVLeistungen.UseCompatibleTextRendering = true;
            // 
            // chkKTG
            // 
            this.chkKTG.DataMember = "KTG";
            this.chkKTG.DataSource = this.qryBaPerson;
            this.chkKTG.Location = new System.Drawing.Point(682, 284);
            this.chkKTG.Name = "chkKTG";
            this.chkKTG.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkKTG.Properties.Appearance.Options.UseBackColor = true;
            this.chkKTG.Properties.Caption = " .";
            this.chkKTG.Size = new System.Drawing.Size(25, 19);
            this.chkKTG.TabIndex = 32;
            // 
            // lblKTG
            // 
            this.lblKTG.Location = new System.Drawing.Point(550, 281);
            this.lblKTG.Name = "lblKTG";
            this.lblKTG.Size = new System.Drawing.Size(104, 24);
            this.lblKTG.TabIndex = 31;
            this.lblKTG.Text = "KTG";
            this.lblKTG.UseCompatibleTextRendering = true;
            // 
            // chkALK
            // 
            this.chkALK.DataMember = "ALK";
            this.chkALK.DataSource = this.qryBaPerson;
            this.chkALK.Location = new System.Drawing.Point(682, 259);
            this.chkALK.Name = "chkALK";
            this.chkALK.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkALK.Properties.Appearance.Options.UseBackColor = true;
            this.chkALK.Properties.Caption = " .";
            this.chkALK.Size = new System.Drawing.Size(25, 19);
            this.chkALK.TabIndex = 30;
            // 
            // lblALK
            // 
            this.lblALK.Location = new System.Drawing.Point(550, 256);
            this.lblALK.Name = "lblALK";
            this.lblALK.Size = new System.Drawing.Size(104, 24);
            this.lblALK.TabIndex = 29;
            this.lblALK.Text = "ALK";
            this.lblALK.UseCompatibleTextRendering = true;
            // 
            // chkSozialhilfe
            // 
            this.chkSozialhilfe.DataMember = "Sozialhilfe";
            this.chkSozialhilfe.DataSource = this.qryBaPerson;
            this.chkSozialhilfe.Location = new System.Drawing.Point(682, 234);
            this.chkSozialhilfe.Name = "chkSozialhilfe";
            this.chkSozialhilfe.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkSozialhilfe.Properties.Appearance.Options.UseBackColor = true;
            this.chkSozialhilfe.Properties.Caption = " .";
            this.chkSozialhilfe.Size = new System.Drawing.Size(25, 19);
            this.chkSozialhilfe.TabIndex = 28;
            // 
            // lblSozialhilfe
            // 
            this.lblSozialhilfe.Location = new System.Drawing.Point(548, 231);
            this.lblSozialhilfe.Name = "lblSozialhilfe";
            this.lblSozialhilfe.Size = new System.Drawing.Size(128, 24);
            this.lblSozialhilfe.TabIndex = 27;
            this.lblSozialhilfe.Text = "Sozialhilfe";
            this.lblSozialhilfe.UseCompatibleTextRendering = true;
            // 
            // chkUVGTaggeld
            // 
            this.chkUVGTaggeld.DataMember = "UVGTaggeld";
            this.chkUVGTaggeld.DataSource = this.qryBaPerson;
            this.chkUVGTaggeld.Location = new System.Drawing.Point(432, 284);
            this.chkUVGTaggeld.Name = "chkUVGTaggeld";
            this.chkUVGTaggeld.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkUVGTaggeld.Properties.Appearance.Options.UseBackColor = true;
            this.chkUVGTaggeld.Properties.Caption = " .";
            this.chkUVGTaggeld.Size = new System.Drawing.Size(25, 19);
            this.chkUVGTaggeld.TabIndex = 26;
            // 
            // lblUVGTaggeld
            // 
            this.lblUVGTaggeld.Location = new System.Drawing.Point(298, 281);
            this.lblUVGTaggeld.Name = "lblUVGTaggeld";
            this.lblUVGTaggeld.Size = new System.Drawing.Size(128, 24);
            this.lblUVGTaggeld.TabIndex = 25;
            this.lblUVGTaggeld.Text = "UVG-Taggeld";
            this.lblUVGTaggeld.UseCompatibleTextRendering = true;
            // 
            // chkUVGRente
            // 
            this.chkUVGRente.DataMember = "UVGRente";
            this.chkUVGRente.DataSource = this.qryBaPerson;
            this.chkUVGRente.Location = new System.Drawing.Point(432, 259);
            this.chkUVGRente.Name = "chkUVGRente";
            this.chkUVGRente.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkUVGRente.Properties.Appearance.Options.UseBackColor = true;
            this.chkUVGRente.Properties.Caption = " .";
            this.chkUVGRente.Size = new System.Drawing.Size(25, 19);
            this.chkUVGRente.TabIndex = 24;
            // 
            // lblUVGRente
            // 
            this.lblUVGRente.Location = new System.Drawing.Point(298, 256);
            this.lblUVGRente.Name = "lblUVGRente";
            this.lblUVGRente.Size = new System.Drawing.Size(128, 24);
            this.lblUVGRente.TabIndex = 23;
            this.lblUVGRente.Text = "UVG-Rente";
            this.lblUVGRente.UseCompatibleTextRendering = true;
            // 
            // chkBVGRente
            // 
            this.chkBVGRente.DataMember = "BVGRente";
            this.chkBVGRente.DataSource = this.qryBaPerson;
            this.chkBVGRente.Location = new System.Drawing.Point(432, 234);
            this.chkBVGRente.Name = "chkBVGRente";
            this.chkBVGRente.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkBVGRente.Properties.Appearance.Options.UseBackColor = true;
            this.chkBVGRente.Properties.Caption = " .";
            this.chkBVGRente.Size = new System.Drawing.Size(25, 19);
            this.chkBVGRente.TabIndex = 22;
            // 
            // lblBVGRente
            // 
            this.lblBVGRente.Location = new System.Drawing.Point(298, 231);
            this.lblBVGRente.Name = "lblBVGRente";
            this.lblBVGRente.Size = new System.Drawing.Size(128, 24);
            this.lblBVGRente.TabIndex = 21;
            this.lblBVGRente.Text = "BVG-Rente";
            this.lblBVGRente.UseCompatibleTextRendering = true;
            // 
            // chkErgaenzungsLeistungen
            // 
            this.chkErgaenzungsLeistungen.DataMember = "ErgaenzungsLeistungen";
            this.chkErgaenzungsLeistungen.DataSource = this.qryBaPerson;
            this.chkErgaenzungsLeistungen.Location = new System.Drawing.Point(143, 411);
            this.chkErgaenzungsLeistungen.Name = "chkErgaenzungsLeistungen";
            this.chkErgaenzungsLeistungen.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkErgaenzungsLeistungen.Properties.Appearance.Options.UseBackColor = true;
            this.chkErgaenzungsLeistungen.Properties.Caption = " .";
            this.chkErgaenzungsLeistungen.Size = new System.Drawing.Size(25, 19);
            this.chkErgaenzungsLeistungen.TabIndex = 20;
            // 
            // lblErgaenzungsleistungen
            // 
            this.lblErgaenzungsleistungen.Location = new System.Drawing.Point(9, 408);
            this.lblErgaenzungsleistungen.Name = "lblErgaenzungsleistungen";
            this.lblErgaenzungsleistungen.Size = new System.Drawing.Size(128, 24);
            this.lblErgaenzungsleistungen.TabIndex = 19;
            this.lblErgaenzungsleistungen.Text = "Ergänzungsleistungen";
            this.lblErgaenzungsleistungen.UseCompatibleTextRendering = true;
            // 
            // chkMedizinischeMassnahmeIV
            // 
            this.chkMedizinischeMassnahmeIV.DataMember = "MedizinischeMassnahmeIV";
            this.chkMedizinischeMassnahmeIV.DataSource = this.qryBaPerson;
            this.chkMedizinischeMassnahmeIV.Location = new System.Drawing.Point(143, 361);
            this.chkMedizinischeMassnahmeIV.Name = "chkMedizinischeMassnahmeIV";
            this.chkMedizinischeMassnahmeIV.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkMedizinischeMassnahmeIV.Properties.Appearance.Options.UseBackColor = true;
            this.chkMedizinischeMassnahmeIV.Properties.Caption = " .";
            this.chkMedizinischeMassnahmeIV.Size = new System.Drawing.Size(25, 19);
            this.chkMedizinischeMassnahmeIV.TabIndex = 16;
            // 
            // chkIVHilfsmittel
            // 
            this.chkIVHilfsmittel.DataMember = "IVHilfsmittel";
            this.chkIVHilfsmittel.DataSource = this.qryBaPerson;
            this.chkIVHilfsmittel.Location = new System.Drawing.Point(143, 386);
            this.chkIVHilfsmittel.Name = "chkIVHilfsmittel";
            this.chkIVHilfsmittel.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkIVHilfsmittel.Properties.Appearance.Options.UseBackColor = true;
            this.chkIVHilfsmittel.Properties.Caption = " .";
            this.chkIVHilfsmittel.Size = new System.Drawing.Size(25, 19);
            this.chkIVHilfsmittel.TabIndex = 18;
            // 
            // lblMedizinischeMassnahmeIV
            // 
            this.lblMedizinischeMassnahmeIV.Location = new System.Drawing.Point(9, 357);
            this.lblMedizinischeMassnahmeIV.Name = "lblMedizinischeMassnahmeIV";
            this.lblMedizinischeMassnahmeIV.Size = new System.Drawing.Size(128, 24);
            this.lblMedizinischeMassnahmeIV.TabIndex = 15;
            this.lblMedizinischeMassnahmeIV.Text = "Medizin. Massnahme IV";
            this.lblMedizinischeMassnahmeIV.UseCompatibleTextRendering = true;
            // 
            // lblIVHilfsmittel
            // 
            this.lblIVHilfsmittel.Location = new System.Drawing.Point(9, 383);
            this.lblIVHilfsmittel.Name = "lblIVHilfsmittel";
            this.lblIVHilfsmittel.Size = new System.Drawing.Size(128, 24);
            this.lblIVHilfsmittel.TabIndex = 17;
            this.lblIVHilfsmittel.Text = "IV-Hilfsmittel";
            this.lblIVHilfsmittel.UseCompatibleTextRendering = true;
            // 
            // chkBeruflicheMassnahmeIV
            // 
            this.chkBeruflicheMassnahmeIV.DataMember = "BeruflicheMassnahmeIV";
            this.chkBeruflicheMassnahmeIV.DataSource = this.qryBaPerson;
            this.chkBeruflicheMassnahmeIV.Location = new System.Drawing.Point(143, 336);
            this.chkBeruflicheMassnahmeIV.Name = "chkBeruflicheMassnahmeIV";
            this.chkBeruflicheMassnahmeIV.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkBeruflicheMassnahmeIV.Properties.Appearance.Options.UseBackColor = true;
            this.chkBeruflicheMassnahmeIV.Properties.Caption = " .";
            this.chkBeruflicheMassnahmeIV.Size = new System.Drawing.Size(25, 19);
            this.chkBeruflicheMassnahmeIV.TabIndex = 14;
            // 
            // lblBeruflicheMassnahmenIV
            // 
            this.lblBeruflicheMassnahmenIV.Location = new System.Drawing.Point(9, 333);
            this.lblBeruflicheMassnahmenIV.Name = "lblBeruflicheMassnahmenIV";
            this.lblBeruflicheMassnahmenIV.Size = new System.Drawing.Size(128, 24);
            this.lblBeruflicheMassnahmenIV.TabIndex = 13;
            this.lblBeruflicheMassnahmenIV.Text = "Berufl. Massnahme IV";
            this.lblBeruflicheMassnahmenIV.UseCompatibleTextRendering = true;
            // 
            // chkIVTaggeld
            // 
            this.chkIVTaggeld.DataMember = "IVTaggeld";
            this.chkIVTaggeld.DataSource = this.qryBaPerson;
            this.chkIVTaggeld.Location = new System.Drawing.Point(143, 311);
            this.chkIVTaggeld.Name = "chkIVTaggeld";
            this.chkIVTaggeld.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkIVTaggeld.Properties.Appearance.Options.UseBackColor = true;
            this.chkIVTaggeld.Properties.Caption = " .";
            this.chkIVTaggeld.Size = new System.Drawing.Size(25, 19);
            this.chkIVTaggeld.TabIndex = 12;
            // 
            // lblIVTaggeld
            // 
            this.lblIVTaggeld.Location = new System.Drawing.Point(9, 308);
            this.lblIVTaggeld.Name = "lblIVTaggeld";
            this.lblIVTaggeld.Size = new System.Drawing.Size(128, 24);
            this.lblIVTaggeld.TabIndex = 11;
            this.lblIVTaggeld.Text = "IV-Taggeld";
            this.lblIVTaggeld.UseCompatibleTextRendering = true;
            // 
            // edtIntensivPflegeZuschlag
            // 
            this.edtIntensivPflegeZuschlag.DataMember = "IntensivPflegeZuschlagCode";
            this.edtIntensivPflegeZuschlag.DataSource = this.qryBaPerson;
            this.edtIntensivPflegeZuschlag.Location = new System.Drawing.Point(140, 283);
            this.edtIntensivPflegeZuschlag.LOVName = "BaIntensivpflegeZuschlag";
            this.edtIntensivPflegeZuschlag.Name = "edtIntensivPflegeZuschlag";
            this.edtIntensivPflegeZuschlag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIntensivPflegeZuschlag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIntensivPflegeZuschlag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIntensivPflegeZuschlag.Properties.Appearance.Options.UseBackColor = true;
            this.edtIntensivPflegeZuschlag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIntensivPflegeZuschlag.Properties.Appearance.Options.UseFont = true;
            this.edtIntensivPflegeZuschlag.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtIntensivPflegeZuschlag.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtIntensivPflegeZuschlag.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtIntensivPflegeZuschlag.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtIntensivPflegeZuschlag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject20.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject20.Options.UseBackColor = true;
            this.edtIntensivPflegeZuschlag.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject20)});
            this.edtIntensivPflegeZuschlag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIntensivPflegeZuschlag.Properties.NullText = "";
            this.edtIntensivPflegeZuschlag.Properties.ShowFooter = false;
            this.edtIntensivPflegeZuschlag.Properties.ShowHeader = false;
            this.edtIntensivPflegeZuschlag.Size = new System.Drawing.Size(113, 24);
            this.edtIntensivPflegeZuschlag.TabIndex = 10;
            // 
            // lblIntensivPflegeZuschlag
            // 
            this.lblIntensivPflegeZuschlag.Location = new System.Drawing.Point(9, 281);
            this.lblIntensivPflegeZuschlag.Name = "lblIntensivPflegeZuschlag";
            this.lblIntensivPflegeZuschlag.Size = new System.Drawing.Size(128, 24);
            this.lblIntensivPflegeZuschlag.TabIndex = 9;
            this.lblIntensivPflegeZuschlag.Text = "Intensivpflegezuschlag";
            this.lblIntensivPflegeZuschlag.UseCompatibleTextRendering = true;
            // 
            // grpKantonaleZuschuesse
            // 
            this.grpKantonaleZuschuesse.Controls.Add(this.grdKZSZugeteilt);
            this.grpKantonaleZuschuesse.Controls.Add(this.btnKZSRemove);
            this.grpKantonaleZuschuesse.Controls.Add(this.btnKZSAdd);
            this.grpKantonaleZuschuesse.Controls.Add(this.grdKZSVerfuegbar);
            this.grpKantonaleZuschuesse.Controls.Add(this.edtKZSFilter);
            this.grpKantonaleZuschuesse.Controls.Add(this.lblKZSFilter);
            this.grpKantonaleZuschuesse.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grpKantonaleZuschuesse.Location = new System.Drawing.Point(298, 12);
            this.grpKantonaleZuschuesse.Name = "grpKantonaleZuschuesse";
            this.grpKantonaleZuschuesse.Size = new System.Drawing.Size(409, 205);
            this.grpKantonaleZuschuesse.TabIndex = 8;
            this.grpKantonaleZuschuesse.TabStop = false;
            this.grpKantonaleZuschuesse.Text = "Kantonale Zuschüsse";
            this.grpKantonaleZuschuesse.UseCompatibleTextRendering = true;
            // 
            // grdKZSZugeteilt
            // 
            this.grdKZSZugeteilt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.grdKZSZugeteilt.EmbeddedNavigator.Name = "";
            this.grdKZSZugeteilt.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdKZSZugeteilt.Location = new System.Drawing.Point(232, 19);
            this.grdKZSZugeteilt.MainView = this.grvKZSZugeteilt;
            this.grdKZSZugeteilt.Margin = new System.Windows.Forms.Padding(4);
            this.grdKZSZugeteilt.Name = "grdKZSZugeteilt";
            this.grdKZSZugeteilt.Size = new System.Drawing.Size(168, 176);
            this.grdKZSZugeteilt.TabIndex = 5;
            this.grdKZSZugeteilt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKZSZugeteilt});
            // 
            // grvKZSZugeteilt
            // 
            this.grvKZSZugeteilt.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvKZSZugeteilt.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKZSZugeteilt.Appearance.Empty.Options.UseBackColor = true;
            this.grvKZSZugeteilt.Appearance.Empty.Options.UseFont = true;
            this.grvKZSZugeteilt.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvKZSZugeteilt.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKZSZugeteilt.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvKZSZugeteilt.Appearance.EvenRow.Options.UseFont = true;
            this.grvKZSZugeteilt.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKZSZugeteilt.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKZSZugeteilt.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKZSZugeteilt.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKZSZugeteilt.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKZSZugeteilt.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKZSZugeteilt.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKZSZugeteilt.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKZSZugeteilt.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvKZSZugeteilt.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKZSZugeteilt.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKZSZugeteilt.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKZSZugeteilt.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKZSZugeteilt.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKZSZugeteilt.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKZSZugeteilt.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKZSZugeteilt.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKZSZugeteilt.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKZSZugeteilt.Appearance.GroupRow.Options.UseFont = true;
            this.grvKZSZugeteilt.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKZSZugeteilt.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKZSZugeteilt.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKZSZugeteilt.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKZSZugeteilt.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKZSZugeteilt.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKZSZugeteilt.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKZSZugeteilt.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvKZSZugeteilt.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKZSZugeteilt.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKZSZugeteilt.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKZSZugeteilt.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKZSZugeteilt.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKZSZugeteilt.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvKZSZugeteilt.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvKZSZugeteilt.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKZSZugeteilt.Appearance.OddRow.Options.UseFont = true;
            this.grvKZSZugeteilt.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKZSZugeteilt.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKZSZugeteilt.Appearance.Row.Options.UseBackColor = true;
            this.grvKZSZugeteilt.Appearance.Row.Options.UseFont = true;
            this.grvKZSZugeteilt.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvKZSZugeteilt.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKZSZugeteilt.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvKZSZugeteilt.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvKZSZugeteilt.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKZSZugeteilt.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvKZSZugeteilt.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvKZSZugeteilt.Appearance.VertLine.Options.UseBackColor = true;
            this.grvKZSZugeteilt.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKZSZugeteilt.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKZSZugtBaKantonalerZuschussID,
            this.colKZSZugtBaKantonalerZuschussBezeichung});
            this.grvKZSZugeteilt.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvKZSZugeteilt.GridControl = this.grdKZSZugeteilt;
            this.grvKZSZugeteilt.Name = "grvKZSZugeteilt";
            this.grvKZSZugeteilt.OptionsBehavior.Editable = false;
            this.grvKZSZugeteilt.OptionsCustomization.AllowFilter = false;
            this.grvKZSZugeteilt.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKZSZugeteilt.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKZSZugeteilt.OptionsNavigation.UseTabKey = false;
            this.grvKZSZugeteilt.OptionsView.ColumnAutoWidth = false;
            this.grvKZSZugeteilt.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvKZSZugeteilt.OptionsView.ShowGroupPanel = false;
            this.grvKZSZugeteilt.OptionsView.ShowIndicator = false;
            // 
            // colKZSZugtBaKantonalerZuschussID
            // 
            this.colKZSZugtBaKantonalerZuschussID.Caption = "-";
            this.colKZSZugtBaKantonalerZuschussID.FieldName = "BaKantonalerZuschussID";
            this.colKZSZugtBaKantonalerZuschussID.Name = "colKZSZugtBaKantonalerZuschussID";
            // 
            // colKZSZugtBaKantonalerZuschussBezeichung
            // 
            this.colKZSZugtBaKantonalerZuschussBezeichung.Caption = "Zugewiesen";
            this.colKZSZugtBaKantonalerZuschussBezeichung.FieldName = "MLBezeichnung";
            this.colKZSZugtBaKantonalerZuschussBezeichung.Name = "colKZSZugtBaKantonalerZuschussBezeichung";
            this.colKZSZugtBaKantonalerZuschussBezeichung.Visible = true;
            this.colKZSZugtBaKantonalerZuschussBezeichung.VisibleIndex = 0;
            this.colKZSZugtBaKantonalerZuschussBezeichung.Width = 137;
            // 
            // btnKZSRemove
            // 
            this.btnKZSRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKZSRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKZSRemove.IconID = 11;
            this.btnKZSRemove.Location = new System.Drawing.Point(190, 69);
            this.btnKZSRemove.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnKZSRemove.Name = "btnKZSRemove";
            this.btnKZSRemove.Size = new System.Drawing.Size(28, 24);
            this.btnKZSRemove.TabIndex = 4;
            this.btnKZSRemove.UseCompatibleTextRendering = true;
            this.btnKZSRemove.UseVisualStyleBackColor = false;
            this.btnKZSRemove.Click += new System.EventHandler(this.btnKZSRemove_Click);
            // 
            // btnKZSAdd
            // 
            this.btnKZSAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKZSAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKZSAdd.IconID = 13;
            this.btnKZSAdd.Location = new System.Drawing.Point(190, 39);
            this.btnKZSAdd.Margin = new System.Windows.Forms.Padding(10, 30, 10, 3);
            this.btnKZSAdd.Name = "btnKZSAdd";
            this.btnKZSAdd.Size = new System.Drawing.Size(28, 24);
            this.btnKZSAdd.TabIndex = 3;
            this.btnKZSAdd.UseCompatibleTextRendering = true;
            this.btnKZSAdd.UseVisualStyleBackColor = false;
            this.btnKZSAdd.Click += new System.EventHandler(this.btnKZSAdd_Click);
            // 
            // grdKZSVerfuegbar
            // 
            this.grdKZSVerfuegbar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.grdKZSVerfuegbar.EmbeddedNavigator.Name = "";
            this.grdKZSVerfuegbar.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdKZSVerfuegbar.Location = new System.Drawing.Point(9, 19);
            this.grdKZSVerfuegbar.MainView = this.grvKZSVerfuegbar;
            this.grdKZSVerfuegbar.Margin = new System.Windows.Forms.Padding(4);
            this.grdKZSVerfuegbar.Name = "grdKZSVerfuegbar";
            this.grdKZSVerfuegbar.Size = new System.Drawing.Size(167, 148);
            this.grdKZSVerfuegbar.TabIndex = 2;
            this.grdKZSVerfuegbar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKZSVerfuegbar});
            // 
            // grvKZSVerfuegbar
            // 
            this.grvKZSVerfuegbar.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvKZSVerfuegbar.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKZSVerfuegbar.Appearance.Empty.Options.UseBackColor = true;
            this.grvKZSVerfuegbar.Appearance.Empty.Options.UseFont = true;
            this.grvKZSVerfuegbar.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKZSVerfuegbar.Appearance.EvenRow.Options.UseFont = true;
            this.grvKZSVerfuegbar.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKZSVerfuegbar.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKZSVerfuegbar.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKZSVerfuegbar.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKZSVerfuegbar.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKZSVerfuegbar.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKZSVerfuegbar.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKZSVerfuegbar.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKZSVerfuegbar.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvKZSVerfuegbar.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKZSVerfuegbar.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKZSVerfuegbar.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKZSVerfuegbar.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKZSVerfuegbar.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKZSVerfuegbar.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKZSVerfuegbar.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKZSVerfuegbar.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKZSVerfuegbar.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKZSVerfuegbar.Appearance.GroupRow.Options.UseFont = true;
            this.grvKZSVerfuegbar.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKZSVerfuegbar.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKZSVerfuegbar.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKZSVerfuegbar.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKZSVerfuegbar.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKZSVerfuegbar.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKZSVerfuegbar.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKZSVerfuegbar.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvKZSVerfuegbar.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKZSVerfuegbar.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKZSVerfuegbar.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKZSVerfuegbar.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKZSVerfuegbar.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKZSVerfuegbar.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvKZSVerfuegbar.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvKZSVerfuegbar.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKZSVerfuegbar.Appearance.OddRow.Options.UseFont = true;
            this.grvKZSVerfuegbar.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKZSVerfuegbar.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKZSVerfuegbar.Appearance.Row.Options.UseBackColor = true;
            this.grvKZSVerfuegbar.Appearance.Row.Options.UseFont = true;
            this.grvKZSVerfuegbar.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKZSVerfuegbar.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKZSVerfuegbar.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvKZSVerfuegbar.Appearance.VertLine.Options.UseBackColor = true;
            this.grvKZSVerfuegbar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKZSVerfuegbar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKZSVerfBaKantonalerZuschussID,
            this.colKZSVerfBaKantonalerZuschussBezeichnung});
            this.grvKZSVerfuegbar.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvKZSVerfuegbar.GridControl = this.grdKZSVerfuegbar;
            this.grvKZSVerfuegbar.Name = "grvKZSVerfuegbar";
            this.grvKZSVerfuegbar.OptionsBehavior.Editable = false;
            this.grvKZSVerfuegbar.OptionsCustomization.AllowFilter = false;
            this.grvKZSVerfuegbar.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKZSVerfuegbar.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKZSVerfuegbar.OptionsNavigation.UseTabKey = false;
            this.grvKZSVerfuegbar.OptionsSelection.MultiSelect = true;
            this.grvKZSVerfuegbar.OptionsView.ColumnAutoWidth = false;
            this.grvKZSVerfuegbar.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvKZSVerfuegbar.OptionsView.ShowGroupPanel = false;
            this.grvKZSVerfuegbar.OptionsView.ShowIndicator = false;
            // 
            // colKZSVerfBaKantonalerZuschussID
            // 
            this.colKZSVerfBaKantonalerZuschussID.Caption = "-";
            this.colKZSVerfBaKantonalerZuschussID.FieldName = "BaKantonalerZuschussID";
            this.colKZSVerfBaKantonalerZuschussID.Name = "colKZSVerfBaKantonalerZuschussID";
            // 
            // colKZSVerfBaKantonalerZuschussBezeichnung
            // 
            this.colKZSVerfBaKantonalerZuschussBezeichnung.Caption = "Vorhanden";
            this.colKZSVerfBaKantonalerZuschussBezeichnung.FieldName = "MLBezeichnung";
            this.colKZSVerfBaKantonalerZuschussBezeichnung.Name = "colKZSVerfBaKantonalerZuschussBezeichnung";
            this.colKZSVerfBaKantonalerZuschussBezeichnung.Visible = true;
            this.colKZSVerfBaKantonalerZuschussBezeichnung.VisibleIndex = 0;
            this.colKZSVerfBaKantonalerZuschussBezeichnung.Width = 137;
            // 
            // edtKZSFilter
            // 
            this.edtKZSFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKZSFilter.Location = new System.Drawing.Point(70, 171);
            this.edtKZSFilter.Name = "edtKZSFilter";
            this.edtKZSFilter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKZSFilter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKZSFilter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKZSFilter.Properties.Appearance.Options.UseBackColor = true;
            this.edtKZSFilter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKZSFilter.Properties.Appearance.Options.UseFont = true;
            this.edtKZSFilter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKZSFilter.Size = new System.Drawing.Size(106, 24);
            this.edtKZSFilter.TabIndex = 1;
            this.edtKZSFilter.EditValueChanged += new System.EventHandler(this.edtKZSFilter_EditValueChanged);
            // 
            // lblKZSFilter
            // 
            this.lblKZSFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblKZSFilter.Location = new System.Drawing.Point(9, 171);
            this.lblKZSFilter.Name = "lblKZSFilter";
            this.lblKZSFilter.Size = new System.Drawing.Size(55, 24);
            this.lblKZSFilter.TabIndex = 0;
            this.lblKZSFilter.Text = "Filter";
            this.lblKZSFilter.UseCompatibleTextRendering = true;
            // 
            // grpHELB
            // 
            this.grpHELB.Controls.Add(this.chkHelbKeinAntrag);
            this.grpHELB.Controls.Add(this.lblHelbKeinAntrag);
            this.grpHELB.Controls.Add(this.lblHelbDatumEntscheid);
            this.grpHELB.Controls.Add(this.edtHelbDatumEntscheid);
            this.grpHELB.Controls.Add(this.edtHelbAbWann);
            this.grpHELB.Controls.Add(this.lblHelbAbWann);
            this.grpHELB.Controls.Add(this.edtHelpEntscheid);
            this.grpHELB.Controls.Add(this.lblHelbEntscheid);
            this.grpHELB.Controls.Add(this.edtHelbAnmeldung);
            this.grpHELB.Controls.Add(this.lblHelbAnmeldung);
            this.grpHELB.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grpHELB.Location = new System.Drawing.Point(9, 103);
            this.grpHELB.Name = "grpHELB";
            this.grpHELB.Size = new System.Drawing.Size(262, 168);
            this.grpHELB.TabIndex = 7;
            this.grpHELB.TabStop = false;
            this.grpHELB.Text = "HELB";
            this.grpHELB.UseCompatibleTextRendering = true;
            // 
            // chkHelbKeinAntrag
            // 
            this.chkHelbKeinAntrag.DataMember = "HELBKeinAntrag";
            this.chkHelbKeinAntrag.DataSource = this.qryBaPerson;
            this.chkHelbKeinAntrag.Location = new System.Drawing.Point(132, 19);
            this.chkHelbKeinAntrag.Name = "chkHelbKeinAntrag";
            this.chkHelbKeinAntrag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkHelbKeinAntrag.Properties.Appearance.Options.UseBackColor = true;
            this.chkHelbKeinAntrag.Properties.Caption = " .";
            this.chkHelbKeinAntrag.Size = new System.Drawing.Size(25, 19);
            this.chkHelbKeinAntrag.TabIndex = 1;
            this.chkHelbKeinAntrag.CheckedChanged += new System.EventHandler(this.chkHELBKeinAntrag_CheckedChanged);
            // 
            // lblHelbKeinAntrag
            // 
            this.lblHelbKeinAntrag.Location = new System.Drawing.Point(13, 16);
            this.lblHelbKeinAntrag.Name = "lblHelbKeinAntrag";
            this.lblHelbKeinAntrag.Size = new System.Drawing.Size(113, 24);
            this.lblHelbKeinAntrag.TabIndex = 0;
            this.lblHelbKeinAntrag.Text = "Kein Antrag";
            this.lblHelbKeinAntrag.UseCompatibleTextRendering = true;
            // 
            // lblHelbDatumEntscheid
            // 
            this.lblHelbDatumEntscheid.Location = new System.Drawing.Point(13, 74);
            this.lblHelbDatumEntscheid.Name = "lblHelbDatumEntscheid";
            this.lblHelbDatumEntscheid.Size = new System.Drawing.Size(113, 24);
            this.lblHelbDatumEntscheid.TabIndex = 4;
            this.lblHelbDatumEntscheid.Text = "Datum Entscheid";
            this.lblHelbDatumEntscheid.UseCompatibleTextRendering = true;
            // 
            // edtHelbDatumEntscheid
            // 
            this.edtHelbDatumEntscheid.DataMember = "HELBEntscheid";
            this.edtHelbDatumEntscheid.DataSource = this.qryBaPerson;
            this.edtHelbDatumEntscheid.EditValue = null;
            this.edtHelbDatumEntscheid.Location = new System.Drawing.Point(132, 74);
            this.edtHelbDatumEntscheid.Name = "edtHelbDatumEntscheid";
            this.edtHelbDatumEntscheid.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtHelbDatumEntscheid.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtHelbDatumEntscheid.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHelbDatumEntscheid.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHelbDatumEntscheid.Properties.Appearance.Options.UseBackColor = true;
            this.edtHelbDatumEntscheid.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHelbDatumEntscheid.Properties.Appearance.Options.UseFont = true;
            this.edtHelbDatumEntscheid.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject21.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject21.Options.UseBackColor = true;
            this.edtHelbDatumEntscheid.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtHelbDatumEntscheid.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject21)});
            this.edtHelbDatumEntscheid.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtHelbDatumEntscheid.Properties.ShowToday = false;
            this.edtHelbDatumEntscheid.Size = new System.Drawing.Size(112, 24);
            this.edtHelbDatumEntscheid.TabIndex = 5;
            // 
            // edtHelbAbWann
            // 
            this.edtHelbAbWann.DataMember = "HELBAb";
            this.edtHelbAbWann.DataSource = this.qryBaPerson;
            this.edtHelbAbWann.EditValue = null;
            this.edtHelbAbWann.Location = new System.Drawing.Point(132, 134);
            this.edtHelbAbWann.Name = "edtHelbAbWann";
            this.edtHelbAbWann.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtHelbAbWann.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtHelbAbWann.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHelbAbWann.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHelbAbWann.Properties.Appearance.Options.UseBackColor = true;
            this.edtHelbAbWann.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHelbAbWann.Properties.Appearance.Options.UseFont = true;
            this.edtHelbAbWann.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject22.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject22.Options.UseBackColor = true;
            this.edtHelbAbWann.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtHelbAbWann.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject22)});
            this.edtHelbAbWann.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtHelbAbWann.Properties.ShowToday = false;
            this.edtHelbAbWann.Size = new System.Drawing.Size(112, 24);
            this.edtHelbAbWann.TabIndex = 9;
            // 
            // lblHelbAbWann
            // 
            this.lblHelbAbWann.Location = new System.Drawing.Point(13, 135);
            this.lblHelbAbWann.Name = "lblHelbAbWann";
            this.lblHelbAbWann.Size = new System.Drawing.Size(113, 24);
            this.lblHelbAbWann.TabIndex = 8;
            this.lblHelbAbWann.Text = "Ab wann";
            this.lblHelbAbWann.UseCompatibleTextRendering = true;
            // 
            // edtHelpEntscheid
            // 
            this.edtHelpEntscheid.DataMember = "HELBEntscheidCode";
            this.edtHelpEntscheid.DataSource = this.qryBaPerson;
            this.edtHelpEntscheid.Location = new System.Drawing.Point(132, 104);
            this.edtHelpEntscheid.LOVName = "BaHELBEntscheid";
            this.edtHelpEntscheid.Name = "edtHelpEntscheid";
            this.edtHelpEntscheid.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtHelpEntscheid.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHelpEntscheid.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHelpEntscheid.Properties.Appearance.Options.UseBackColor = true;
            this.edtHelpEntscheid.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHelpEntscheid.Properties.Appearance.Options.UseFont = true;
            this.edtHelpEntscheid.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtHelpEntscheid.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtHelpEntscheid.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtHelpEntscheid.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtHelpEntscheid.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject23.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject23.Options.UseBackColor = true;
            this.edtHelpEntscheid.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject23)});
            this.edtHelpEntscheid.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtHelpEntscheid.Properties.NullText = "";
            this.edtHelpEntscheid.Properties.ShowFooter = false;
            this.edtHelpEntscheid.Properties.ShowHeader = false;
            this.edtHelpEntscheid.Size = new System.Drawing.Size(112, 24);
            this.edtHelpEntscheid.TabIndex = 7;
            // 
            // lblHelbEntscheid
            // 
            this.lblHelbEntscheid.Location = new System.Drawing.Point(13, 104);
            this.lblHelbEntscheid.Name = "lblHelbEntscheid";
            this.lblHelbEntscheid.Size = new System.Drawing.Size(113, 24);
            this.lblHelbEntscheid.TabIndex = 6;
            this.lblHelbEntscheid.Text = "Entscheid";
            this.lblHelbEntscheid.UseCompatibleTextRendering = true;
            // 
            // edtHelbAnmeldung
            // 
            this.edtHelbAnmeldung.DataMember = "HELBAnmeldung";
            this.edtHelbAnmeldung.DataSource = this.qryBaPerson;
            this.edtHelbAnmeldung.EditValue = null;
            this.edtHelbAnmeldung.Location = new System.Drawing.Point(132, 44);
            this.edtHelbAnmeldung.Name = "edtHelbAnmeldung";
            this.edtHelbAnmeldung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtHelbAnmeldung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtHelbAnmeldung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHelbAnmeldung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHelbAnmeldung.Properties.Appearance.Options.UseBackColor = true;
            this.edtHelbAnmeldung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHelbAnmeldung.Properties.Appearance.Options.UseFont = true;
            this.edtHelbAnmeldung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject24.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject24.Options.UseBackColor = true;
            this.edtHelbAnmeldung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtHelbAnmeldung.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject24)});
            this.edtHelbAnmeldung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtHelbAnmeldung.Properties.ShowToday = false;
            this.edtHelbAnmeldung.Size = new System.Drawing.Size(112, 24);
            this.edtHelbAnmeldung.TabIndex = 3;
            // 
            // lblHelbAnmeldung
            // 
            this.lblHelbAnmeldung.Location = new System.Drawing.Point(13, 44);
            this.lblHelbAnmeldung.Name = "lblHelbAnmeldung";
            this.lblHelbAnmeldung.Size = new System.Drawing.Size(113, 24);
            this.lblHelbAnmeldung.TabIndex = 2;
            this.lblHelbAnmeldung.Text = "Anmeldung";
            this.lblHelbAnmeldung.UseCompatibleTextRendering = true;
            // 
            // edtHilfslosenEntschaedigung
            // 
            this.edtHilfslosenEntschaedigung.DataMember = "HilfslosenEntschaedigungCode";
            this.edtHilfslosenEntschaedigung.DataSource = this.qryBaPerson;
            this.edtHilfslosenEntschaedigung.Location = new System.Drawing.Point(141, 72);
            this.edtHilfslosenEntschaedigung.LOVName = "BaHilfslosenEntschaedigung";
            this.edtHilfslosenEntschaedigung.Name = "edtHilfslosenEntschaedigung";
            this.edtHilfslosenEntschaedigung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtHilfslosenEntschaedigung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHilfslosenEntschaedigung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHilfslosenEntschaedigung.Properties.Appearance.Options.UseBackColor = true;
            this.edtHilfslosenEntschaedigung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHilfslosenEntschaedigung.Properties.Appearance.Options.UseFont = true;
            this.edtHilfslosenEntschaedigung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtHilfslosenEntschaedigung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtHilfslosenEntschaedigung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtHilfslosenEntschaedigung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtHilfslosenEntschaedigung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject25.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject25.Options.UseBackColor = true;
            this.edtHilfslosenEntschaedigung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject25)});
            this.edtHilfslosenEntschaedigung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtHilfslosenEntschaedigung.Properties.NullText = "";
            this.edtHilfslosenEntschaedigung.Properties.ShowFooter = false;
            this.edtHilfslosenEntschaedigung.Properties.ShowHeader = false;
            this.edtHilfslosenEntschaedigung.Size = new System.Drawing.Size(112, 24);
            this.edtHilfslosenEntschaedigung.TabIndex = 6;
            // 
            // lblHilfslosenentschaedigung
            // 
            this.lblHilfslosenentschaedigung.Location = new System.Drawing.Point(9, 72);
            this.lblHilfslosenentschaedigung.Name = "lblHilfslosenentschaedigung";
            this.lblHilfslosenentschaedigung.Size = new System.Drawing.Size(128, 24);
            this.lblHilfslosenentschaedigung.TabIndex = 5;
            this.lblHilfslosenentschaedigung.Text = "Hilflosenentschäd.";
            this.lblHilfslosenentschaedigung.UseCompatibleTextRendering = true;
            // 
            // lblIVGradProzent
            // 
            this.lblIVGradProzent.Location = new System.Drawing.Point(191, 42);
            this.lblIVGradProzent.Name = "lblIVGradProzent";
            this.lblIVGradProzent.Size = new System.Drawing.Size(16, 24);
            this.lblIVGradProzent.TabIndex = 4;
            this.lblIVGradProzent.Text = "%";
            this.lblIVGradProzent.UseCompatibleTextRendering = true;
            // 
            // edtIVGrad
            // 
            this.edtIVGrad.DataMember = "IVGrad";
            this.edtIVGrad.DataSource = this.qryBaPerson;
            this.edtIVGrad.Location = new System.Drawing.Point(140, 42);
            this.edtIVGrad.Name = "edtIVGrad";
            this.edtIVGrad.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtIVGrad.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIVGrad.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIVGrad.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIVGrad.Properties.Appearance.Options.UseBackColor = true;
            this.edtIVGrad.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIVGrad.Properties.Appearance.Options.UseFont = true;
            this.edtIVGrad.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtIVGrad.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIVGrad.Properties.DisplayFormat.FormatString = "F3";
            this.edtIVGrad.Properties.EditFormat.FormatString = "F3";
            this.edtIVGrad.Properties.Mask.EditMask = "###";
            this.edtIVGrad.Properties.Precision = 0;
            this.edtIVGrad.Size = new System.Drawing.Size(45, 24);
            this.edtIVGrad.TabIndex = 3;
            // 
            // lblIVGrad
            // 
            this.lblIVGrad.Location = new System.Drawing.Point(9, 40);
            this.lblIVGrad.Name = "lblIVGrad";
            this.lblIVGrad.Size = new System.Drawing.Size(128, 24);
            this.lblIVGrad.TabIndex = 2;
            this.lblIVGrad.Text = "IV-Grad";
            this.lblIVGrad.UseCompatibleTextRendering = true;
            // 
            // edtRentenstufe
            // 
            this.edtRentenstufe.AllowNull = false;
            this.edtRentenstufe.DataMember = "RentenstufeCode";
            this.edtRentenstufe.DataSource = this.qryBaPerson;
            this.edtRentenstufe.Location = new System.Drawing.Point(140, 12);
            this.edtRentenstufe.LOVName = "BaRentenstufe";
            this.edtRentenstufe.Name = "edtRentenstufe";
            this.edtRentenstufe.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtRentenstufe.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtRentenstufe.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtRentenstufe.Properties.Appearance.Options.UseBackColor = true;
            this.edtRentenstufe.Properties.Appearance.Options.UseBorderColor = true;
            this.edtRentenstufe.Properties.Appearance.Options.UseFont = true;
            this.edtRentenstufe.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtRentenstufe.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtRentenstufe.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtRentenstufe.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtRentenstufe.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject26.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject26.Options.UseBackColor = true;
            this.edtRentenstufe.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject26)});
            this.edtRentenstufe.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtRentenstufe.Properties.NullText = "";
            this.edtRentenstufe.Properties.ShowFooter = false;
            this.edtRentenstufe.Properties.ShowHeader = false;
            this.edtRentenstufe.Size = new System.Drawing.Size(113, 24);
            this.edtRentenstufe.TabIndex = 1;
            // 
            // lblRentenstufe
            // 
            this.lblRentenstufe.Location = new System.Drawing.Point(9, 12);
            this.lblRentenstufe.Name = "lblRentenstufe";
            this.lblRentenstufe.Size = new System.Drawing.Size(128, 24);
            this.lblRentenstufe.TabIndex = 0;
            this.lblRentenstufe.Text = "Rentenstufe";
            this.lblRentenstufe.UseCompatibleTextRendering = true;
            // 
            // tpgRechnungsadressen
            // 
            this.tpgRechnungsadressen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tpgRechnungsadressen.Controls.Add(this.grdRechnungsadressen);
            this.tpgRechnungsadressen.Controls.Add(this.panRechnungsadressenUnten);
            this.tpgRechnungsadressen.Location = new System.Drawing.Point(6, 32);
            this.tpgRechnungsadressen.Name = "tpgRechnungsadressen";
            this.tpgRechnungsadressen.Size = new System.Drawing.Size(710, 624);
            this.tpgRechnungsadressen.TabIndex = 0;
            this.tpgRechnungsadressen.Title = "&Rechnungsadressen";
            // 
            // grdRechnungsadressen
            // 
            this.grdRechnungsadressen.DataSource = this.qryRechnungsadressen;
            this.grdRechnungsadressen.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdRechnungsadressen.EmbeddedNavigator.Name = "";
            this.grdRechnungsadressen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdRechnungsadressen.Location = new System.Drawing.Point(0, 0);
            this.grdRechnungsadressen.MainView = this.grvRechnungsadressen;
            this.grdRechnungsadressen.Name = "grdRechnungsadressen";
            this.grdRechnungsadressen.Size = new System.Drawing.Size(710, 417);
            this.grdRechnungsadressen.TabIndex = 1;
            this.grdRechnungsadressen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvRechnungsadressen});
            // 
            // qryRechnungsadressen
            // 
            this.qryRechnungsadressen.CanDelete = true;
            this.qryRechnungsadressen.CanInsert = true;
            this.qryRechnungsadressen.CanUpdate = true;
            this.qryRechnungsadressen.HostControl = this;
            this.qryRechnungsadressen.TableName = "BaRechnungsadresse";
            this.qryRechnungsadressen.AfterInsert += new System.EventHandler(this.qryRechnungsadressen_AfterInsert);
            this.qryRechnungsadressen.AfterPost += new System.EventHandler(this.qryRechnungsadressen_AfterPost);
            this.qryRechnungsadressen.BeforePost += new System.EventHandler(this.qryRechnungsadressen_BeforePost);
            // 
            // grvRechnungsadressen
            // 
            this.grvRechnungsadressen.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvRechnungsadressen.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRechnungsadressen.Appearance.Empty.Options.UseBackColor = true;
            this.grvRechnungsadressen.Appearance.Empty.Options.UseFont = true;
            this.grvRechnungsadressen.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRechnungsadressen.Appearance.EvenRow.Options.UseFont = true;
            this.grvRechnungsadressen.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvRechnungsadressen.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRechnungsadressen.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvRechnungsadressen.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvRechnungsadressen.Appearance.FocusedCell.Options.UseFont = true;
            this.grvRechnungsadressen.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvRechnungsadressen.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvRechnungsadressen.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRechnungsadressen.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvRechnungsadressen.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvRechnungsadressen.Appearance.FocusedRow.Options.UseFont = true;
            this.grvRechnungsadressen.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvRechnungsadressen.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvRechnungsadressen.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvRechnungsadressen.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvRechnungsadressen.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvRechnungsadressen.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvRechnungsadressen.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvRechnungsadressen.Appearance.GroupRow.Options.UseFont = true;
            this.grvRechnungsadressen.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvRechnungsadressen.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvRechnungsadressen.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvRechnungsadressen.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvRechnungsadressen.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvRechnungsadressen.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvRechnungsadressen.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvRechnungsadressen.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvRechnungsadressen.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRechnungsadressen.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvRechnungsadressen.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvRechnungsadressen.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvRechnungsadressen.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvRechnungsadressen.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvRechnungsadressen.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvRechnungsadressen.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRechnungsadressen.Appearance.OddRow.Options.UseFont = true;
            this.grvRechnungsadressen.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvRechnungsadressen.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRechnungsadressen.Appearance.Row.Options.UseBackColor = true;
            this.grvRechnungsadressen.Appearance.Row.Options.UseFont = true;
            this.grvRechnungsadressen.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRechnungsadressen.Appearance.SelectedRow.Options.UseFont = true;
            this.grvRechnungsadressen.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvRechnungsadressen.Appearance.VertLine.Options.UseBackColor = true;
            this.grvRechnungsadressen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvRechnungsadressen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDienstleistung,
            this.colNameVorname,
            this.colZusatz,
            this.colStrasseNr,
            this.colPostfach,
            this.colPLZOrt});
            this.grvRechnungsadressen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvRechnungsadressen.GridControl = this.grdRechnungsadressen;
            this.grvRechnungsadressen.Name = "grvRechnungsadressen";
            this.grvRechnungsadressen.OptionsBehavior.Editable = false;
            this.grvRechnungsadressen.OptionsCustomization.AllowFilter = false;
            this.grvRechnungsadressen.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvRechnungsadressen.OptionsNavigation.AutoFocusNewRow = true;
            this.grvRechnungsadressen.OptionsNavigation.UseTabKey = false;
            this.grvRechnungsadressen.OptionsView.ColumnAutoWidth = false;
            this.grvRechnungsadressen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvRechnungsadressen.OptionsView.ShowGroupPanel = false;
            this.grvRechnungsadressen.OptionsView.ShowIndicator = false;
            // 
            // colDienstleistung
            // 
            this.colDienstleistung.Caption = "Dienstleistung";
            this.colDienstleistung.FieldName = "Dienstleistung";
            this.colDienstleistung.Name = "colDienstleistung";
            this.colDienstleistung.Visible = true;
            this.colDienstleistung.VisibleIndex = 0;
            this.colDienstleistung.Width = 130;
            // 
            // colNameVorname
            // 
            this.colNameVorname.Caption = "Name / Vorname";
            this.colNameVorname.FieldName = "AdresseName";
            this.colNameVorname.Name = "colNameVorname";
            this.colNameVorname.Visible = true;
            this.colNameVorname.VisibleIndex = 1;
            this.colNameVorname.Width = 160;
            // 
            // colZusatz
            // 
            this.colZusatz.Caption = "Zusatz";
            this.colZusatz.FieldName = "AdresseZusatz";
            this.colZusatz.Name = "colZusatz";
            this.colZusatz.Visible = true;
            this.colZusatz.VisibleIndex = 2;
            this.colZusatz.Width = 110;
            // 
            // colStrasseNr
            // 
            this.colStrasseNr.Caption = "Strasse / Nr.";
            this.colStrasseNr.FieldName = "StrasseNr";
            this.colStrasseNr.Name = "colStrasseNr";
            this.colStrasseNr.Visible = true;
            this.colStrasseNr.VisibleIndex = 3;
            this.colStrasseNr.Width = 160;
            // 
            // colPostfach
            // 
            this.colPostfach.Caption = "Postfach";
            this.colPostfach.FieldName = "AdressePostfach";
            this.colPostfach.Name = "colPostfach";
            this.colPostfach.Visible = true;
            this.colPostfach.VisibleIndex = 4;
            this.colPostfach.Width = 60;
            // 
            // colPLZOrt
            // 
            this.colPLZOrt.Caption = "PLZ / Ort";
            this.colPLZOrt.FieldName = "PLZOrt";
            this.colPLZOrt.Name = "colPLZOrt";
            this.colPLZOrt.Visible = true;
            this.colPLZOrt.VisibleIndex = 5;
            this.colPLZOrt.Width = 160;
            // 
            // panRechnungsadressenUnten
            // 
            this.panRechnungsadressenUnten.Controls.Add(this.memRechnungsadresseBemerkungen);
            this.panRechnungsadressenUnten.Controls.Add(this.lblRechnungsadresseBemerkungen);
            this.panRechnungsadressenUnten.Controls.Add(this.edtRechnungsadresseLand);
            this.panRechnungsadressenUnten.Controls.Add(this.lblRechnungsadresseLand);
            this.panRechnungsadressenUnten.Controls.Add(this.edtRechnungsadresseBezirk);
            this.panRechnungsadressenUnten.Controls.Add(this.lblRechnungsadresseBezirk);
            this.panRechnungsadressenUnten.Controls.Add(this.edtRechnungsadresseKanton);
            this.panRechnungsadressenUnten.Controls.Add(this.edtRechnungsadresseOrt);
            this.panRechnungsadressenUnten.Controls.Add(this.edtRechnungsadressePLZ);
            this.panRechnungsadressenUnten.Controls.Add(this.lblRechnungsadressePLZOrtKt);
            this.panRechnungsadressenUnten.Controls.Add(this.edtRechnungsadressePostfach);
            this.panRechnungsadressenUnten.Controls.Add(this.lblRechnungsadressePostfach);
            this.panRechnungsadressenUnten.Controls.Add(this.edtRechnungsadresseHausNr);
            this.panRechnungsadressenUnten.Controls.Add(this.edtRechnungsadresseStrasse);
            this.panRechnungsadressenUnten.Controls.Add(this.lblRechnungsadresseStrasseNr);
            this.panRechnungsadressenUnten.Controls.Add(this.edtRechnungsadresseZusatz);
            this.panRechnungsadressenUnten.Controls.Add(this.lblRechnungsadresseZusatz);
            this.panRechnungsadressenUnten.Controls.Add(this.edtRechnungsadresseVornameName);
            this.panRechnungsadressenUnten.Controls.Add(this.lblRechnungsadresseNameVorname);
            this.panRechnungsadressenUnten.Controls.Add(this.edtRechnungsadresseDL);
            this.panRechnungsadressenUnten.Controls.Add(this.lblRechnungsadresseDL);
            this.panRechnungsadressenUnten.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panRechnungsadressenUnten.Location = new System.Drawing.Point(0, 417);
            this.panRechnungsadressenUnten.Name = "panRechnungsadressenUnten";
            this.panRechnungsadressenUnten.Size = new System.Drawing.Size(710, 207);
            this.panRechnungsadressenUnten.TabIndex = 0;
            // 
            // memRechnungsadresseBemerkungen
            // 
            this.memRechnungsadresseBemerkungen.DataMember = "Bemerkungen";
            this.memRechnungsadresseBemerkungen.DataSource = this.qryRechnungsadressen;
            this.memRechnungsadresseBemerkungen.Location = new System.Drawing.Point(405, 114);
            this.memRechnungsadresseBemerkungen.Name = "memRechnungsadresseBemerkungen";
            this.memRechnungsadresseBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memRechnungsadresseBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memRechnungsadresseBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memRechnungsadresseBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.memRechnungsadresseBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.memRechnungsadresseBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.memRechnungsadresseBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memRechnungsadresseBemerkungen.Size = new System.Drawing.Size(294, 83);
            this.memRechnungsadresseBemerkungen.TabIndex = 20;
            // 
            // lblRechnungsadresseBemerkungen
            // 
            this.lblRechnungsadresseBemerkungen.Location = new System.Drawing.Point(405, 81);
            this.lblRechnungsadresseBemerkungen.Name = "lblRechnungsadresseBemerkungen";
            this.lblRechnungsadresseBemerkungen.Size = new System.Drawing.Size(128, 24);
            this.lblRechnungsadresseBemerkungen.TabIndex = 19;
            this.lblRechnungsadresseBemerkungen.Text = "Bemerkungen";
            this.lblRechnungsadresseBemerkungen.UseCompatibleTextRendering = true;
            // 
            // edtRechnungsadresseLand
            // 
            this.edtRechnungsadresseLand.DataMember = "AdresseLandCode";
            this.edtRechnungsadresseLand.DataSource = this.qryRechnungsadressen;
            this.edtRechnungsadresseLand.Location = new System.Drawing.Point(118, 173);
            this.edtRechnungsadresseLand.Name = "edtRechnungsadresseLand";
            this.edtRechnungsadresseLand.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtRechnungsadresseLand.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtRechnungsadresseLand.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtRechnungsadresseLand.Properties.Appearance.Options.UseBackColor = true;
            this.edtRechnungsadresseLand.Properties.Appearance.Options.UseBorderColor = true;
            this.edtRechnungsadresseLand.Properties.Appearance.Options.UseFont = true;
            this.edtRechnungsadresseLand.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtRechnungsadresseLand.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtRechnungsadresseLand.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtRechnungsadresseLand.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtRechnungsadresseLand.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject27.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject27.Options.UseBackColor = true;
            this.edtRechnungsadresseLand.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject27)});
            this.edtRechnungsadresseLand.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtRechnungsadresseLand.Properties.NullText = "";
            this.edtRechnungsadresseLand.Properties.ShowFooter = false;
            this.edtRechnungsadresseLand.Properties.ShowHeader = false;
            this.edtRechnungsadresseLand.Properties.SortColumnIndex = 1;
            this.edtRechnungsadresseLand.Size = new System.Drawing.Size(270, 24);
            this.edtRechnungsadresseLand.TabIndex = 18;
            // 
            // lblRechnungsadresseLand
            // 
            this.lblRechnungsadresseLand.Location = new System.Drawing.Point(12, 173);
            this.lblRechnungsadresseLand.Name = "lblRechnungsadresseLand";
            this.lblRechnungsadresseLand.Size = new System.Drawing.Size(100, 24);
            this.lblRechnungsadresseLand.TabIndex = 17;
            this.lblRechnungsadresseLand.Text = "Land";
            this.lblRechnungsadresseLand.UseCompatibleTextRendering = true;
            // 
            // edtRechnungsadresseBezirk
            // 
            this.edtRechnungsadresseBezirk.DataMember = "AdresseBezirk";
            this.edtRechnungsadresseBezirk.DataSource = this.qryRechnungsadressen;
            this.edtRechnungsadresseBezirk.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtRechnungsadresseBezirk.Location = new System.Drawing.Point(118, 150);
            this.edtRechnungsadresseBezirk.Name = "edtRechnungsadresseBezirk";
            this.edtRechnungsadresseBezirk.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtRechnungsadresseBezirk.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtRechnungsadresseBezirk.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtRechnungsadresseBezirk.Properties.Appearance.Options.UseBackColor = true;
            this.edtRechnungsadresseBezirk.Properties.Appearance.Options.UseBorderColor = true;
            this.edtRechnungsadresseBezirk.Properties.Appearance.Options.UseFont = true;
            this.edtRechnungsadresseBezirk.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtRechnungsadresseBezirk.Properties.ReadOnly = true;
            this.edtRechnungsadresseBezirk.Size = new System.Drawing.Size(270, 24);
            this.edtRechnungsadresseBezirk.TabIndex = 16;
            this.edtRechnungsadresseBezirk.TabStop = false;
            // 
            // lblRechnungsadresseBezirk
            // 
            this.lblRechnungsadresseBezirk.Location = new System.Drawing.Point(11, 149);
            this.lblRechnungsadresseBezirk.Name = "lblRechnungsadresseBezirk";
            this.lblRechnungsadresseBezirk.Size = new System.Drawing.Size(100, 24);
            this.lblRechnungsadresseBezirk.TabIndex = 15;
            this.lblRechnungsadresseBezirk.Text = "Bezirk";
            this.lblRechnungsadresseBezirk.UseCompatibleTextRendering = true;
            // 
            // edtRechnungsadresseKanton
            // 
            this.edtRechnungsadresseKanton.DataMember = "AdresseKanton";
            this.edtRechnungsadresseKanton.DataSource = this.qryRechnungsadressen;
            this.edtRechnungsadresseKanton.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtRechnungsadresseKanton.Location = new System.Drawing.Point(357, 127);
            this.edtRechnungsadresseKanton.Name = "edtRechnungsadresseKanton";
            this.edtRechnungsadresseKanton.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtRechnungsadresseKanton.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtRechnungsadresseKanton.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtRechnungsadresseKanton.Properties.Appearance.Options.UseBackColor = true;
            this.edtRechnungsadresseKanton.Properties.Appearance.Options.UseBorderColor = true;
            this.edtRechnungsadresseKanton.Properties.Appearance.Options.UseFont = true;
            this.edtRechnungsadresseKanton.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtRechnungsadresseKanton.Properties.ReadOnly = true;
            this.edtRechnungsadresseKanton.Size = new System.Drawing.Size(31, 24);
            this.edtRechnungsadresseKanton.TabIndex = 14;
            // 
            // edtRechnungsadresseOrt
            // 
            this.edtRechnungsadresseOrt.DataMember = "AdresseOrt";
            this.edtRechnungsadresseOrt.DataSource = this.qryRechnungsadressen;
            this.edtRechnungsadresseOrt.Location = new System.Drawing.Point(162, 127);
            this.edtRechnungsadresseOrt.Name = "edtRechnungsadresseOrt";
            this.edtRechnungsadresseOrt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtRechnungsadresseOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtRechnungsadresseOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtRechnungsadresseOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtRechnungsadresseOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtRechnungsadresseOrt.Properties.Appearance.Options.UseFont = true;
            this.edtRechnungsadresseOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtRechnungsadresseOrt.Size = new System.Drawing.Size(196, 24);
            this.edtRechnungsadresseOrt.TabIndex = 13;
            this.edtRechnungsadresseOrt.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtRechnungsadresseOrt_UserModifiedFld);
            // 
            // edtRechnungsadressePLZ
            // 
            this.edtRechnungsadressePLZ.DataMember = "AdressePLZ";
            this.edtRechnungsadressePLZ.DataSource = this.qryRechnungsadressen;
            this.edtRechnungsadressePLZ.Location = new System.Drawing.Point(118, 127);
            this.edtRechnungsadressePLZ.Name = "edtRechnungsadressePLZ";
            this.edtRechnungsadressePLZ.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtRechnungsadressePLZ.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtRechnungsadressePLZ.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtRechnungsadressePLZ.Properties.Appearance.Options.UseBackColor = true;
            this.edtRechnungsadressePLZ.Properties.Appearance.Options.UseBorderColor = true;
            this.edtRechnungsadressePLZ.Properties.Appearance.Options.UseFont = true;
            this.edtRechnungsadressePLZ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtRechnungsadressePLZ.Size = new System.Drawing.Size(45, 24);
            this.edtRechnungsadressePLZ.TabIndex = 12;
            this.edtRechnungsadressePLZ.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtRechnungsadressePLZ_UserModifiedFld);
            // 
            // lblRechnungsadressePLZOrtKt
            // 
            this.lblRechnungsadressePLZOrtKt.Location = new System.Drawing.Point(12, 127);
            this.lblRechnungsadressePLZOrtKt.Name = "lblRechnungsadressePLZOrtKt";
            this.lblRechnungsadressePLZOrtKt.Size = new System.Drawing.Size(100, 24);
            this.lblRechnungsadressePLZOrtKt.TabIndex = 11;
            this.lblRechnungsadressePLZOrtKt.Text = "PLZ / Ort / Kt.";
            this.lblRechnungsadressePLZOrtKt.UseCompatibleTextRendering = true;
            // 
            // edtRechnungsadressePostfach
            // 
            this.edtRechnungsadressePostfach.DataMember = "AdressePostfach";
            this.edtRechnungsadressePostfach.DataSource = this.qryRechnungsadressen;
            this.edtRechnungsadressePostfach.Location = new System.Drawing.Point(118, 104);
            this.edtRechnungsadressePostfach.Name = "edtRechnungsadressePostfach";
            this.edtRechnungsadressePostfach.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtRechnungsadressePostfach.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtRechnungsadressePostfach.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtRechnungsadressePostfach.Properties.Appearance.Options.UseBackColor = true;
            this.edtRechnungsadressePostfach.Properties.Appearance.Options.UseBorderColor = true;
            this.edtRechnungsadressePostfach.Properties.Appearance.Options.UseFont = true;
            this.edtRechnungsadressePostfach.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtRechnungsadressePostfach.Size = new System.Drawing.Size(270, 24);
            this.edtRechnungsadressePostfach.TabIndex = 10;
            // 
            // lblRechnungsadressePostfach
            // 
            this.lblRechnungsadressePostfach.Location = new System.Drawing.Point(12, 104);
            this.lblRechnungsadressePostfach.Name = "lblRechnungsadressePostfach";
            this.lblRechnungsadressePostfach.Size = new System.Drawing.Size(100, 24);
            this.lblRechnungsadressePostfach.TabIndex = 9;
            this.lblRechnungsadressePostfach.Text = "Postfach";
            this.lblRechnungsadressePostfach.UseCompatibleTextRendering = true;
            // 
            // edtRechnungsadresseHausNr
            // 
            this.edtRechnungsadresseHausNr.DataMember = "AdresseHausNr";
            this.edtRechnungsadresseHausNr.DataSource = this.qryRechnungsadressen;
            this.edtRechnungsadresseHausNr.Location = new System.Drawing.Point(339, 81);
            this.edtRechnungsadresseHausNr.Name = "edtRechnungsadresseHausNr";
            this.edtRechnungsadresseHausNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtRechnungsadresseHausNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtRechnungsadresseHausNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtRechnungsadresseHausNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtRechnungsadresseHausNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtRechnungsadresseHausNr.Properties.Appearance.Options.UseFont = true;
            this.edtRechnungsadresseHausNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtRechnungsadresseHausNr.Size = new System.Drawing.Size(49, 24);
            this.edtRechnungsadresseHausNr.TabIndex = 8;
            // 
            // edtRechnungsadresseStrasse
            // 
            this.edtRechnungsadresseStrasse.DataMember = "AdresseStrasse";
            this.edtRechnungsadresseStrasse.DataSource = this.qryRechnungsadressen;
            this.edtRechnungsadresseStrasse.Location = new System.Drawing.Point(118, 81);
            this.edtRechnungsadresseStrasse.Name = "edtRechnungsadresseStrasse";
            this.edtRechnungsadresseStrasse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtRechnungsadresseStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtRechnungsadresseStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtRechnungsadresseStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtRechnungsadresseStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtRechnungsadresseStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtRechnungsadresseStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtRechnungsadresseStrasse.Size = new System.Drawing.Size(222, 24);
            this.edtRechnungsadresseStrasse.TabIndex = 7;
            // 
            // lblRechnungsadresseStrasseNr
            // 
            this.lblRechnungsadresseStrasseNr.Location = new System.Drawing.Point(12, 81);
            this.lblRechnungsadresseStrasseNr.Name = "lblRechnungsadresseStrasseNr";
            this.lblRechnungsadresseStrasseNr.Size = new System.Drawing.Size(100, 24);
            this.lblRechnungsadresseStrasseNr.TabIndex = 6;
            this.lblRechnungsadresseStrasseNr.Text = "Strasse / Nr.";
            this.lblRechnungsadresseStrasseNr.UseCompatibleTextRendering = true;
            // 
            // edtRechnungsadresseZusatz
            // 
            this.edtRechnungsadresseZusatz.DataMember = "AdresseZusatz";
            this.edtRechnungsadresseZusatz.DataSource = this.qryRechnungsadressen;
            this.edtRechnungsadresseZusatz.Location = new System.Drawing.Point(118, 58);
            this.edtRechnungsadresseZusatz.Name = "edtRechnungsadresseZusatz";
            this.edtRechnungsadresseZusatz.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtRechnungsadresseZusatz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtRechnungsadresseZusatz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtRechnungsadresseZusatz.Properties.Appearance.Options.UseBackColor = true;
            this.edtRechnungsadresseZusatz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtRechnungsadresseZusatz.Properties.Appearance.Options.UseFont = true;
            this.edtRechnungsadresseZusatz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtRechnungsadresseZusatz.Size = new System.Drawing.Size(270, 24);
            this.edtRechnungsadresseZusatz.TabIndex = 5;
            // 
            // lblRechnungsadresseZusatz
            // 
            this.lblRechnungsadresseZusatz.Location = new System.Drawing.Point(12, 58);
            this.lblRechnungsadresseZusatz.Name = "lblRechnungsadresseZusatz";
            this.lblRechnungsadresseZusatz.Size = new System.Drawing.Size(100, 24);
            this.lblRechnungsadresseZusatz.TabIndex = 4;
            this.lblRechnungsadresseZusatz.Text = "Zusatz";
            this.lblRechnungsadresseZusatz.UseCompatibleTextRendering = true;
            // 
            // edtRechnungsadresseVornameName
            // 
            this.edtRechnungsadresseVornameName.DataMember = "AdresseName";
            this.edtRechnungsadresseVornameName.DataSource = this.qryRechnungsadressen;
            this.edtRechnungsadresseVornameName.Location = new System.Drawing.Point(118, 35);
            this.edtRechnungsadresseVornameName.Name = "edtRechnungsadresseVornameName";
            this.edtRechnungsadresseVornameName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtRechnungsadresseVornameName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtRechnungsadresseVornameName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtRechnungsadresseVornameName.Properties.Appearance.Options.UseBackColor = true;
            this.edtRechnungsadresseVornameName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtRechnungsadresseVornameName.Properties.Appearance.Options.UseFont = true;
            this.edtRechnungsadresseVornameName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtRechnungsadresseVornameName.Size = new System.Drawing.Size(270, 24);
            this.edtRechnungsadresseVornameName.TabIndex = 3;
            // 
            // lblRechnungsadresseNameVorname
            // 
            this.lblRechnungsadresseNameVorname.Location = new System.Drawing.Point(12, 35);
            this.lblRechnungsadresseNameVorname.Name = "lblRechnungsadresseNameVorname";
            this.lblRechnungsadresseNameVorname.Size = new System.Drawing.Size(100, 24);
            this.lblRechnungsadresseNameVorname.TabIndex = 2;
            this.lblRechnungsadresseNameVorname.Text = "Name / Vorname ";
            this.lblRechnungsadresseNameVorname.UseCompatibleTextRendering = true;
            // 
            // edtRechnungsadresseDL
            // 
            this.edtRechnungsadresseDL.AllowNull = false;
            this.edtRechnungsadresseDL.DataMember = "DienstleistungCode";
            this.edtRechnungsadresseDL.DataSource = this.qryRechnungsadressen;
            this.edtRechnungsadresseDL.Location = new System.Drawing.Point(118, 6);
            this.edtRechnungsadresseDL.LOVName = "BaRechnungsadresseModule";
            this.edtRechnungsadresseDL.Name = "edtRechnungsadresseDL";
            this.edtRechnungsadresseDL.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtRechnungsadresseDL.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtRechnungsadresseDL.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtRechnungsadresseDL.Properties.Appearance.Options.UseBackColor = true;
            this.edtRechnungsadresseDL.Properties.Appearance.Options.UseBorderColor = true;
            this.edtRechnungsadresseDL.Properties.Appearance.Options.UseFont = true;
            this.edtRechnungsadresseDL.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtRechnungsadresseDL.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtRechnungsadresseDL.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtRechnungsadresseDL.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtRechnungsadresseDL.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject28.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject28.Options.UseBackColor = true;
            this.edtRechnungsadresseDL.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject28)});
            this.edtRechnungsadresseDL.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtRechnungsadresseDL.Properties.NullText = "";
            this.edtRechnungsadresseDL.Properties.ShowFooter = false;
            this.edtRechnungsadresseDL.Properties.ShowHeader = false;
            this.edtRechnungsadresseDL.Size = new System.Drawing.Size(270, 24);
            this.edtRechnungsadresseDL.TabIndex = 1;
            // 
            // lblRechnungsadresseDL
            // 
            this.lblRechnungsadresseDL.Location = new System.Drawing.Point(12, 6);
            this.lblRechnungsadresseDL.Name = "lblRechnungsadresseDL";
            this.lblRechnungsadresseDL.Size = new System.Drawing.Size(100, 24);
            this.lblRechnungsadresseDL.TabIndex = 0;
            this.lblRechnungsadresseDL.Text = "Dienstleistung";
            this.lblRechnungsadresseDL.UseCompatibleTextRendering = true;
            // 
            // tpgKurz
            // 
            this.tpgKurz.Controls.Add(this.edtKurzAnrede);
            this.tpgKurz.Controls.Add(this.chkKurzManuelleAnrede);
            this.tpgKurz.Controls.Add(this.lblKurzBriefanrede);
            this.tpgKurz.Controls.Add(this.edtKurzBriefanrede);
            this.tpgKurz.Controls.Add(this.lblKurzAnrede);
            this.tpgKurz.Controls.Add(this.chkKurzKeinSerienbrief);
            this.tpgKurz.Controls.Add(this.memKurzBemerkungen);
            this.tpgKurz.Controls.Add(this.lblKurzBemerkungen);
            this.tpgKurz.Controls.Add(this.chkKurzGleicherHaushalt);
            this.tpgKurz.Controls.Add(this.edtKurzBeziehung);
            this.tpgKurz.Controls.Add(this.lblKurzBeziehung);
            this.tpgKurz.Controls.Add(this.edtKurzSprache);
            this.tpgKurz.Controls.Add(this.lblKurzSprache);
            this.tpgKurz.Controls.Add(this.edtKurzGeschlechtCode);
            this.tpgKurz.Controls.Add(this.lblKurzGeschlecht);
            this.tpgKurz.Controls.Add(this.edtKurzSterbedatum);
            this.tpgKurz.Controls.Add(this.lblKurzTod);
            this.tpgKurz.Controls.Add(this.edtKurzGeburtsdatum);
            this.tpgKurz.Controls.Add(this.lblKurzGeburt);
            this.tpgKurz.Controls.Add(this.edtKurzVersichertenNummer);
            this.tpgKurz.Controls.Add(this.lblKurzVersichertenNummer);
            this.tpgKurz.Controls.Add(this.edtKurzPersonenNr);
            this.tpgKurz.Controls.Add(this.lblKurzPersonenNr);
            this.tpgKurz.Controls.Add(this.grpKurzKontakt);
            this.tpgKurz.Controls.Add(this.grpKurzWohnsitz);
            this.tpgKurz.Controls.Add(this.edtKurzVorname);
            this.tpgKurz.Controls.Add(this.edtKurzName);
            this.tpgKurz.Controls.Add(this.lblKurzNameVorname);
            this.tpgKurz.Controls.Add(this.edtKurzTitel);
            this.tpgKurz.Controls.Add(this.lblKurzTitel);
            this.tpgKurz.Location = new System.Drawing.Point(6, 32);
            this.tpgKurz.Name = "tpgKurz";
            this.tpgKurz.Size = new System.Drawing.Size(710, 624);
            this.tpgKurz.TabIndex = 0;
            this.tpgKurz.Title = "Bezugsperson";
            // 
            // edtKurzAnrede
            // 
            this.edtKurzAnrede.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKurzAnrede.DataMember = "Anrede";
            this.edtKurzAnrede.DataSource = this.qryBaPerson;
            this.edtKurzAnrede.Location = new System.Drawing.Point(119, 53);
            this.edtKurzAnrede.Name = "edtKurzAnrede";
            this.edtKurzAnrede.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKurzAnrede.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKurzAnrede.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKurzAnrede.Properties.Appearance.Options.UseBackColor = true;
            this.edtKurzAnrede.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKurzAnrede.Properties.Appearance.Options.UseFont = true;
            this.edtKurzAnrede.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKurzAnrede.Properties.Name = "kissTextEdit1.Properties";
            this.edtKurzAnrede.Size = new System.Drawing.Size(161, 24);
            this.edtKurzAnrede.TabIndex = 4;
            // 
            // chkKurzManuelleAnrede
            // 
            this.chkKurzManuelleAnrede.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkKurzManuelleAnrede.DataMember = "ManuelleAnrede";
            this.chkKurzManuelleAnrede.DataSource = this.qryBaPerson;
            this.chkKurzManuelleAnrede.Location = new System.Drawing.Point(286, 55);
            this.chkKurzManuelleAnrede.Name = "chkKurzManuelleAnrede";
            this.chkKurzManuelleAnrede.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkKurzManuelleAnrede.Properties.Appearance.Options.UseBackColor = true;
            this.chkKurzManuelleAnrede.Properties.Caption = "Manuelle Anrede";
            this.chkKurzManuelleAnrede.Size = new System.Drawing.Size(119, 19);
            this.chkKurzManuelleAnrede.TabIndex = 5;
            this.chkKurzManuelleAnrede.CheckedChanged += new System.EventHandler(this.chkKurzManuelleAnrede_CheckedChanged);
            // 
            // lblKurzBriefanrede
            // 
            this.lblKurzBriefanrede.Location = new System.Drawing.Point(5, 76);
            this.lblKurzBriefanrede.Name = "lblKurzBriefanrede";
            this.lblKurzBriefanrede.Size = new System.Drawing.Size(108, 24);
            this.lblKurzBriefanrede.TabIndex = 6;
            this.lblKurzBriefanrede.Text = "Briefanrede";
            this.lblKurzBriefanrede.UseCompatibleTextRendering = true;
            // 
            // edtKurzBriefanrede
            // 
            this.edtKurzBriefanrede.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKurzBriefanrede.DataMember = "Briefanrede";
            this.edtKurzBriefanrede.DataSource = this.qryBaPerson;
            this.edtKurzBriefanrede.Location = new System.Drawing.Point(119, 76);
            this.edtKurzBriefanrede.Name = "edtKurzBriefanrede";
            this.edtKurzBriefanrede.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKurzBriefanrede.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKurzBriefanrede.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKurzBriefanrede.Properties.Appearance.Options.UseBackColor = true;
            this.edtKurzBriefanrede.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKurzBriefanrede.Properties.Appearance.Options.UseFont = true;
            this.edtKurzBriefanrede.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKurzBriefanrede.Size = new System.Drawing.Size(286, 24);
            this.edtKurzBriefanrede.TabIndex = 7;
            // 
            // lblKurzAnrede
            // 
            this.lblKurzAnrede.Location = new System.Drawing.Point(5, 53);
            this.lblKurzAnrede.Name = "lblKurzAnrede";
            this.lblKurzAnrede.Size = new System.Drawing.Size(108, 24);
            this.lblKurzAnrede.TabIndex = 3;
            this.lblKurzAnrede.Text = "Anrede";
            this.lblKurzAnrede.UseCompatibleTextRendering = true;
            // 
            // chkKurzKeinSerienbrief
            // 
            this.chkKurzKeinSerienbrief.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkKurzKeinSerienbrief.DataMember = "KeinSerienbrief";
            this.chkKurzKeinSerienbrief.DataSource = this.qryBaPerson;
            this.chkKurzKeinSerienbrief.Location = new System.Drawing.Point(119, 5);
            this.chkKurzKeinSerienbrief.Name = "chkKurzKeinSerienbrief";
            this.chkKurzKeinSerienbrief.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkKurzKeinSerienbrief.Properties.Appearance.Options.UseBackColor = true;
            this.chkKurzKeinSerienbrief.Properties.Caption = "Kein Serienbrief";
            this.chkKurzKeinSerienbrief.Size = new System.Drawing.Size(286, 19);
            this.chkKurzKeinSerienbrief.TabIndex = 0;
            // 
            // memKurzBemerkungen
            // 
            this.memKurzBemerkungen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memKurzBemerkungen.BackColor = System.Drawing.Color.White;
            this.memKurzBemerkungen.DataMember = "Bemerkung";
            this.memKurzBemerkungen.DataSource = this.qryBaPerson;
            this.memKurzBemerkungen.Font = new System.Drawing.Font("Arial", 10F);
            this.memKurzBemerkungen.Location = new System.Drawing.Point(119, 464);
            this.memKurzBemerkungen.Margin = new System.Windows.Forms.Padding(9, 3, 9, 9);
            this.memKurzBemerkungen.Name = "memKurzBemerkungen";
            this.memKurzBemerkungen.Size = new System.Drawing.Size(588, 157);
            this.memKurzBemerkungen.TabIndex = 31;
            // 
            // lblKurzBemerkungen
            // 
            this.lblKurzBemerkungen.Location = new System.Drawing.Point(5, 464);
            this.lblKurzBemerkungen.Name = "lblKurzBemerkungen";
            this.lblKurzBemerkungen.Size = new System.Drawing.Size(108, 24);
            this.lblKurzBemerkungen.TabIndex = 30;
            this.lblKurzBemerkungen.Text = "Bemerkungen";
            this.lblKurzBemerkungen.UseCompatibleTextRendering = true;
            // 
            // chkKurzGleicherHaushalt
            // 
            this.chkKurzGleicherHaushalt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkKurzGleicherHaushalt.DataMember = "ImGleichenHaushalt";
            this.chkKurzGleicherHaushalt.DataSource = this.qryPersonRelation;
            this.chkKurzGleicherHaushalt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.chkKurzGleicherHaushalt.Location = new System.Drawing.Point(427, 364);
            this.chkKurzGleicherHaushalt.Name = "chkKurzGleicherHaushalt";
            this.chkKurzGleicherHaushalt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkKurzGleicherHaushalt.Properties.Appearance.Options.UseBackColor = true;
            this.chkKurzGleicherHaushalt.Properties.Caption = "Gleicher Haushalt";
            this.chkKurzGleicherHaushalt.Properties.ReadOnly = true;
            this.chkKurzGleicherHaushalt.Size = new System.Drawing.Size(274, 19);
            this.chkKurzGleicherHaushalt.TabIndex = 29;
            // 
            // qryPersonRelation
            // 
            this.qryPersonRelation.CanUpdate = true;
            this.qryPersonRelation.HostControl = this;
            this.qryPersonRelation.TableName = "BaPerson_Relation";
            this.qryPersonRelation.BeforePost += new System.EventHandler(this.qryPersonRelation_BeforePost);
            // 
            // edtKurzBeziehung
            // 
            this.edtKurzBeziehung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKurzBeziehung.DataMember = "RelationID";
            this.edtKurzBeziehung.DataSource = this.qryPersonRelation;
            this.edtKurzBeziehung.Location = new System.Drawing.Point(427, 331);
            this.edtKurzBeziehung.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.edtKurzBeziehung.Name = "edtKurzBeziehung";
            this.edtKurzBeziehung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKurzBeziehung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKurzBeziehung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKurzBeziehung.Properties.Appearance.Options.UseBackColor = true;
            this.edtKurzBeziehung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKurzBeziehung.Properties.Appearance.Options.UseFont = true;
            this.edtKurzBeziehung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKurzBeziehung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKurzBeziehung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKurzBeziehung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKurzBeziehung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject29.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject29.Options.UseBackColor = true;
            this.edtKurzBeziehung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject29)});
            this.edtKurzBeziehung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKurzBeziehung.Properties.NullText = "";
            this.edtKurzBeziehung.Properties.ShowFooter = false;
            this.edtKurzBeziehung.Properties.ShowHeader = false;
            this.edtKurzBeziehung.Size = new System.Drawing.Size(274, 24);
            this.edtKurzBeziehung.TabIndex = 28;
            // 
            // lblKurzBeziehung
            // 
            this.lblKurzBeziehung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKurzBeziehung.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblKurzBeziehung.Location = new System.Drawing.Point(427, 309);
            this.lblKurzBeziehung.Name = "lblKurzBeziehung";
            this.lblKurzBeziehung.Size = new System.Drawing.Size(274, 16);
            this.lblKurzBeziehung.TabIndex = 27;
            this.lblKurzBeziehung.Text = "Beziehung zur Hauptperson";
            this.lblKurzBeziehung.UseCompatibleTextRendering = true;
            // 
            // edtKurzSprache
            // 
            this.edtKurzSprache.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKurzSprache.DataMember = "SprachCode";
            this.edtKurzSprache.DataSource = this.qryBaPerson;
            this.edtKurzSprache.Location = new System.Drawing.Point(523, 197);
            this.edtKurzSprache.LOVName = "BaSprache";
            this.edtKurzSprache.Name = "edtKurzSprache";
            this.edtKurzSprache.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKurzSprache.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKurzSprache.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKurzSprache.Properties.Appearance.Options.UseBackColor = true;
            this.edtKurzSprache.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKurzSprache.Properties.Appearance.Options.UseFont = true;
            this.edtKurzSprache.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKurzSprache.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKurzSprache.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKurzSprache.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKurzSprache.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject30.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject30.Options.UseBackColor = true;
            this.edtKurzSprache.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject30)});
            this.edtKurzSprache.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKurzSprache.Properties.NullText = "";
            this.edtKurzSprache.Properties.ShowFooter = false;
            this.edtKurzSprache.Properties.ShowHeader = false;
            this.edtKurzSprache.Size = new System.Drawing.Size(178, 24);
            this.edtKurzSprache.TabIndex = 26;
            // 
            // lblKurzSprache
            // 
            this.lblKurzSprache.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKurzSprache.Location = new System.Drawing.Point(427, 197);
            this.lblKurzSprache.Name = "lblKurzSprache";
            this.lblKurzSprache.Size = new System.Drawing.Size(90, 24);
            this.lblKurzSprache.TabIndex = 25;
            this.lblKurzSprache.Text = "Sprache";
            this.lblKurzSprache.UseCompatibleTextRendering = true;
            // 
            // edtKurzGeschlechtCode
            // 
            this.edtKurzGeschlechtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKurzGeschlechtCode.DataMember = "GeschlechtCode";
            this.edtKurzGeschlechtCode.DataSource = this.qryBaPerson;
            this.edtKurzGeschlechtCode.Location = new System.Drawing.Point(523, 167);
            this.edtKurzGeschlechtCode.LOVName = "Geschlecht";
            this.edtKurzGeschlechtCode.Name = "edtKurzGeschlechtCode";
            this.edtKurzGeschlechtCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKurzGeschlechtCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKurzGeschlechtCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKurzGeschlechtCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtKurzGeschlechtCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKurzGeschlechtCode.Properties.Appearance.Options.UseFont = true;
            this.edtKurzGeschlechtCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKurzGeschlechtCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKurzGeschlechtCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKurzGeschlechtCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKurzGeschlechtCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject31.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject31.Options.UseBackColor = true;
            this.edtKurzGeschlechtCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject31)});
            this.edtKurzGeschlechtCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKurzGeschlechtCode.Properties.NullText = "";
            this.edtKurzGeschlechtCode.Properties.ShowFooter = false;
            this.edtKurzGeschlechtCode.Properties.ShowHeader = false;
            this.edtKurzGeschlechtCode.Size = new System.Drawing.Size(178, 24);
            this.edtKurzGeschlechtCode.TabIndex = 24;
            this.edtKurzGeschlechtCode.EditValueChanged += new System.EventHandler(this.edtKurzGeschlechtCode_EditValueChanged);
            // 
            // lblKurzGeschlecht
            // 
            this.lblKurzGeschlecht.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKurzGeschlecht.Location = new System.Drawing.Point(427, 167);
            this.lblKurzGeschlecht.Name = "lblKurzGeschlecht";
            this.lblKurzGeschlecht.Size = new System.Drawing.Size(90, 24);
            this.lblKurzGeschlecht.TabIndex = 23;
            this.lblKurzGeschlecht.Text = "Geschlecht";
            this.lblKurzGeschlecht.UseCompatibleTextRendering = true;
            // 
            // edtKurzSterbedatum
            // 
            this.edtKurzSterbedatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKurzSterbedatum.DataMember = "Sterbedatum";
            this.edtKurzSterbedatum.DataSource = this.qryBaPerson;
            this.edtKurzSterbedatum.EditValue = null;
            this.edtKurzSterbedatum.Location = new System.Drawing.Point(523, 137);
            this.edtKurzSterbedatum.Name = "edtKurzSterbedatum";
            this.edtKurzSterbedatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKurzSterbedatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKurzSterbedatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKurzSterbedatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKurzSterbedatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtKurzSterbedatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKurzSterbedatum.Properties.Appearance.Options.UseFont = true;
            this.edtKurzSterbedatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject32.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject32.Options.UseBackColor = true;
            this.edtKurzSterbedatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtKurzSterbedatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject32)});
            this.edtKurzSterbedatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKurzSterbedatum.Properties.ShowToday = false;
            this.edtKurzSterbedatum.Size = new System.Drawing.Size(95, 24);
            this.edtKurzSterbedatum.TabIndex = 22;
            this.edtKurzSterbedatum.EditValueChanged += new System.EventHandler(this.edtKurzSterbedatum_EditValueChanged);
            // 
            // lblKurzTod
            // 
            this.lblKurzTod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKurzTod.Location = new System.Drawing.Point(427, 137);
            this.lblKurzTod.Name = "lblKurzTod";
            this.lblKurzTod.Size = new System.Drawing.Size(90, 24);
            this.lblKurzTod.TabIndex = 21;
            this.lblKurzTod.Text = "Tod";
            this.lblKurzTod.UseCompatibleTextRendering = true;
            // 
            // edtKurzGeburtsdatum
            // 
            this.edtKurzGeburtsdatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKurzGeburtsdatum.DataMember = "Geburtsdatum";
            this.edtKurzGeburtsdatum.DataSource = this.qryBaPerson;
            this.edtKurzGeburtsdatum.EditValue = null;
            this.edtKurzGeburtsdatum.Location = new System.Drawing.Point(523, 114);
            this.edtKurzGeburtsdatum.Name = "edtKurzGeburtsdatum";
            this.edtKurzGeburtsdatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKurzGeburtsdatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKurzGeburtsdatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKurzGeburtsdatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKurzGeburtsdatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtKurzGeburtsdatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKurzGeburtsdatum.Properties.Appearance.Options.UseFont = true;
            this.edtKurzGeburtsdatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject33.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject33.Options.UseBackColor = true;
            this.edtKurzGeburtsdatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtKurzGeburtsdatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject33)});
            this.edtKurzGeburtsdatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKurzGeburtsdatum.Properties.ShowToday = false;
            this.edtKurzGeburtsdatum.Size = new System.Drawing.Size(95, 24);
            this.edtKurzGeburtsdatum.TabIndex = 20;
            this.edtKurzGeburtsdatum.EditValueChanged += new System.EventHandler(this.edtKurzGeburtsdatum_EditValueChanged);
            // 
            // lblKurzGeburt
            // 
            this.lblKurzGeburt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKurzGeburt.Location = new System.Drawing.Point(427, 114);
            this.lblKurzGeburt.Name = "lblKurzGeburt";
            this.lblKurzGeburt.Size = new System.Drawing.Size(90, 24);
            this.lblKurzGeburt.TabIndex = 19;
            this.lblKurzGeburt.Text = "Geburt";
            this.lblKurzGeburt.UseCompatibleTextRendering = true;
            // 
            // edtKurzVersichertenNummer
            // 
            this.edtKurzVersichertenNummer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKurzVersichertenNummer.DataMember = "VersichertenNummer";
            this.edtKurzVersichertenNummer.DataSource = this.qryBaPerson;
            this.edtKurzVersichertenNummer.Location = new System.Drawing.Point(523, 61);
            this.edtKurzVersichertenNummer.Name = "edtKurzVersichertenNummer";
            this.edtKurzVersichertenNummer.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKurzVersichertenNummer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKurzVersichertenNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKurzVersichertenNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKurzVersichertenNummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtKurzVersichertenNummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKurzVersichertenNummer.Properties.Appearance.Options.UseFont = true;
            this.edtKurzVersichertenNummer.Properties.Appearance.Options.UseTextOptions = true;
            this.edtKurzVersichertenNummer.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.edtKurzVersichertenNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKurzVersichertenNummer.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKurzVersichertenNummer.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None);
            this.edtKurzVersichertenNummer.Properties.DisplayFormat.FormatString = "000\\.0000\\.0000\\.00";
            this.edtKurzVersichertenNummer.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtKurzVersichertenNummer.Properties.EditFormat.FormatString = "000\\.0000\\.0000\\.00";
            this.edtKurzVersichertenNummer.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtKurzVersichertenNummer.Properties.Mask.EditMask = "000\\.0000\\.0000\\.00";
            this.edtKurzVersichertenNummer.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.edtKurzVersichertenNummer.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.edtKurzVersichertenNummer.Properties.MaxLength = 18;
            this.edtKurzVersichertenNummer.Properties.Precision = 0;
            this.edtKurzVersichertenNummer.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.edtKurzVersichertenNummer.Size = new System.Drawing.Size(178, 24);
            this.edtKurzVersichertenNummer.TabIndex = 18;
            // 
            // lblKurzVersichertenNummer
            // 
            this.lblKurzVersichertenNummer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKurzVersichertenNummer.Location = new System.Drawing.Point(427, 61);
            this.lblKurzVersichertenNummer.Name = "lblKurzVersichertenNummer";
            this.lblKurzVersichertenNummer.Size = new System.Drawing.Size(90, 24);
            this.lblKurzVersichertenNummer.TabIndex = 17;
            this.lblKurzVersichertenNummer.Text = "Vers.-Nr.";
            this.lblKurzVersichertenNummer.UseCompatibleTextRendering = true;
            // 
            // edtKurzPersonenNr
            // 
            this.edtKurzPersonenNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKurzPersonenNr.DataMember = "BaPersonIDVISNumber";
            this.edtKurzPersonenNr.DataSource = this.qryBaPerson;
            this.edtKurzPersonenNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKurzPersonenNr.Location = new System.Drawing.Point(523, 31);
            this.edtKurzPersonenNr.Name = "edtKurzPersonenNr";
            this.edtKurzPersonenNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKurzPersonenNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKurzPersonenNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKurzPersonenNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtKurzPersonenNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKurzPersonenNr.Properties.Appearance.Options.UseFont = true;
            this.edtKurzPersonenNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKurzPersonenNr.Properties.ReadOnly = true;
            this.edtKurzPersonenNr.Size = new System.Drawing.Size(178, 24);
            this.edtKurzPersonenNr.TabIndex = 14;
            this.edtKurzPersonenNr.TabStop = false;
            // 
            // lblKurzPersonenNr
            // 
            this.lblKurzPersonenNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKurzPersonenNr.Location = new System.Drawing.Point(425, 30);
            this.lblKurzPersonenNr.Name = "lblKurzPersonenNr";
            this.lblKurzPersonenNr.Size = new System.Drawing.Size(92, 24);
            this.lblKurzPersonenNr.TabIndex = 13;
            this.lblKurzPersonenNr.Text = "Personen-Nr.";
            this.lblKurzPersonenNr.UseCompatibleTextRendering = true;
            // 
            // grpKurzKontakt
            // 
            this.grpKurzKontakt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpKurzKontakt.Controls.Add(this.chkBPZeigeTelMobil);
            this.grpKurzKontakt.Controls.Add(this.chkBPZeigeTelGeschaeft);
            this.grpKurzKontakt.Controls.Add(this.chkBPZeigeTelPrivat);
            this.grpKurzKontakt.Controls.Add(this.edtKurzKontaktEmail);
            this.grpKurzKontakt.Controls.Add(this.lblKurzKontaktEmail);
            this.grpKurzKontakt.Controls.Add(this.edtKurzKontaktFax);
            this.grpKurzKontakt.Controls.Add(this.lblKurzKontaktFax);
            this.grpKurzKontakt.Controls.Add(this.edtKurzKontaktTelM);
            this.grpKurzKontakt.Controls.Add(this.lblKurzKontaktTelM);
            this.grpKurzKontakt.Controls.Add(this.edtKurzKontaktTelG);
            this.grpKurzKontakt.Controls.Add(this.lblKurzKontaktTelG);
            this.grpKurzKontakt.Controls.Add(this.edtKurzKontaktTelP);
            this.grpKurzKontakt.Controls.Add(this.lblKurzKontaktTelP);
            this.grpKurzKontakt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grpKurzKontakt.Location = new System.Drawing.Point(5, 309);
            this.grpKurzKontakt.Name = "grpKurzKontakt";
            this.grpKurzKontakt.Size = new System.Drawing.Size(400, 149);
            this.grpKurzKontakt.TabIndex = 12;
            this.grpKurzKontakt.TabStop = false;
            this.grpKurzKontakt.Text = "Kontakt";
            this.grpKurzKontakt.UseCompatibleTextRendering = true;
            // 
            // chkBPZeigeTelMobil
            // 
            this.chkBPZeigeTelMobil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBPZeigeTelMobil.DataMember = "ZeigeTelMobil";
            this.chkBPZeigeTelMobil.DataSource = this.qryBaPerson;
            this.chkBPZeigeTelMobil.Location = new System.Drawing.Point(366, 66);
            this.chkBPZeigeTelMobil.Name = "chkBPZeigeTelMobil";
            this.chkBPZeigeTelMobil.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkBPZeigeTelMobil.Properties.Appearance.Options.UseBackColor = true;
            this.chkBPZeigeTelMobil.Properties.Caption = " .";
            this.chkBPZeigeTelMobil.Size = new System.Drawing.Size(25, 19);
            this.chkBPZeigeTelMobil.TabIndex = 8;
            // 
            // chkBPZeigeTelGeschaeft
            // 
            this.chkBPZeigeTelGeschaeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBPZeigeTelGeschaeft.DataMember = "ZeigeTelGeschaeft";
            this.chkBPZeigeTelGeschaeft.DataSource = this.qryBaPerson;
            this.chkBPZeigeTelGeschaeft.Location = new System.Drawing.Point(366, 43);
            this.chkBPZeigeTelGeschaeft.Name = "chkBPZeigeTelGeschaeft";
            this.chkBPZeigeTelGeschaeft.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkBPZeigeTelGeschaeft.Properties.Appearance.Options.UseBackColor = true;
            this.chkBPZeigeTelGeschaeft.Properties.Caption = " .";
            this.chkBPZeigeTelGeschaeft.Size = new System.Drawing.Size(25, 19);
            this.chkBPZeigeTelGeschaeft.TabIndex = 5;
            // 
            // chkBPZeigeTelPrivat
            // 
            this.chkBPZeigeTelPrivat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBPZeigeTelPrivat.DataMember = "ZeigeTelPrivat";
            this.chkBPZeigeTelPrivat.DataSource = this.qryBaPerson;
            this.chkBPZeigeTelPrivat.Location = new System.Drawing.Point(366, 19);
            this.chkBPZeigeTelPrivat.Name = "chkBPZeigeTelPrivat";
            this.chkBPZeigeTelPrivat.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkBPZeigeTelPrivat.Properties.Appearance.Options.UseBackColor = true;
            this.chkBPZeigeTelPrivat.Properties.Caption = " .";
            this.chkBPZeigeTelPrivat.Size = new System.Drawing.Size(25, 19);
            this.chkBPZeigeTelPrivat.TabIndex = 2;
            // 
            // edtKurzKontaktEmail
            // 
            this.edtKurzKontaktEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKurzKontaktEmail.DataMember = "EMail";
            this.edtKurzKontaktEmail.DataSource = this.qryBaPerson;
            this.edtKurzKontaktEmail.Location = new System.Drawing.Point(114, 115);
            this.edtKurzKontaktEmail.Name = "edtKurzKontaktEmail";
            this.edtKurzKontaktEmail.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKurzKontaktEmail.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKurzKontaktEmail.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKurzKontaktEmail.Properties.Appearance.Options.UseBackColor = true;
            this.edtKurzKontaktEmail.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKurzKontaktEmail.Properties.Appearance.Options.UseFont = true;
            this.edtKurzKontaktEmail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKurzKontaktEmail.Size = new System.Drawing.Size(277, 24);
            this.edtKurzKontaktEmail.TabIndex = 12;
            // 
            // lblKurzKontaktEmail
            // 
            this.lblKurzKontaktEmail.Location = new System.Drawing.Point(7, 115);
            this.lblKurzKontaktEmail.Name = "lblKurzKontaktEmail";
            this.lblKurzKontaktEmail.Size = new System.Drawing.Size(101, 24);
            this.lblKurzKontaktEmail.TabIndex = 11;
            this.lblKurzKontaktEmail.Text = "E-Mail";
            this.lblKurzKontaktEmail.UseCompatibleTextRendering = true;
            // 
            // edtKurzKontaktFax
            // 
            this.edtKurzKontaktFax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKurzKontaktFax.DataMember = "Fax";
            this.edtKurzKontaktFax.DataSource = this.qryBaPerson;
            this.edtKurzKontaktFax.Location = new System.Drawing.Point(114, 92);
            this.edtKurzKontaktFax.Name = "edtKurzKontaktFax";
            this.edtKurzKontaktFax.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKurzKontaktFax.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKurzKontaktFax.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKurzKontaktFax.Properties.Appearance.Options.UseBackColor = true;
            this.edtKurzKontaktFax.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKurzKontaktFax.Properties.Appearance.Options.UseFont = true;
            this.edtKurzKontaktFax.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKurzKontaktFax.Size = new System.Drawing.Size(277, 24);
            this.edtKurzKontaktFax.TabIndex = 10;
            // 
            // lblKurzKontaktFax
            // 
            this.lblKurzKontaktFax.Location = new System.Drawing.Point(7, 92);
            this.lblKurzKontaktFax.Name = "lblKurzKontaktFax";
            this.lblKurzKontaktFax.Size = new System.Drawing.Size(101, 24);
            this.lblKurzKontaktFax.TabIndex = 9;
            this.lblKurzKontaktFax.Text = "Fax";
            this.lblKurzKontaktFax.UseCompatibleTextRendering = true;
            // 
            // edtKurzKontaktTelM
            // 
            this.edtKurzKontaktTelM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKurzKontaktTelM.DataMember = "MobilTel";
            this.edtKurzKontaktTelM.DataSource = this.qryBaPerson;
            this.edtKurzKontaktTelM.Location = new System.Drawing.Point(114, 62);
            this.edtKurzKontaktTelM.Name = "edtKurzKontaktTelM";
            this.edtKurzKontaktTelM.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKurzKontaktTelM.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKurzKontaktTelM.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKurzKontaktTelM.Properties.Appearance.Options.UseBackColor = true;
            this.edtKurzKontaktTelM.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKurzKontaktTelM.Properties.Appearance.Options.UseFont = true;
            this.edtKurzKontaktTelM.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKurzKontaktTelM.Size = new System.Drawing.Size(246, 24);
            this.edtKurzKontaktTelM.TabIndex = 7;
            // 
            // lblKurzKontaktTelM
            // 
            this.lblKurzKontaktTelM.Location = new System.Drawing.Point(7, 62);
            this.lblKurzKontaktTelM.Name = "lblKurzKontaktTelM";
            this.lblKurzKontaktTelM.Size = new System.Drawing.Size(101, 24);
            this.lblKurzKontaktTelM.TabIndex = 6;
            this.lblKurzKontaktTelM.Text = "Telefon mobil";
            this.lblKurzKontaktTelM.UseCompatibleTextRendering = true;
            // 
            // edtKurzKontaktTelG
            // 
            this.edtKurzKontaktTelG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKurzKontaktTelG.DataMember = "Telefon_G";
            this.edtKurzKontaktTelG.DataSource = this.qryBaPerson;
            this.edtKurzKontaktTelG.Location = new System.Drawing.Point(114, 39);
            this.edtKurzKontaktTelG.Name = "edtKurzKontaktTelG";
            this.edtKurzKontaktTelG.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKurzKontaktTelG.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKurzKontaktTelG.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKurzKontaktTelG.Properties.Appearance.Options.UseBackColor = true;
            this.edtKurzKontaktTelG.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKurzKontaktTelG.Properties.Appearance.Options.UseFont = true;
            this.edtKurzKontaktTelG.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKurzKontaktTelG.Size = new System.Drawing.Size(246, 24);
            this.edtKurzKontaktTelG.TabIndex = 4;
            // 
            // lblKurzKontaktTelG
            // 
            this.lblKurzKontaktTelG.Location = new System.Drawing.Point(7, 39);
            this.lblKurzKontaktTelG.Name = "lblKurzKontaktTelG";
            this.lblKurzKontaktTelG.Size = new System.Drawing.Size(101, 24);
            this.lblKurzKontaktTelG.TabIndex = 3;
            this.lblKurzKontaktTelG.Text = "Telefon gesch.";
            this.lblKurzKontaktTelG.UseCompatibleTextRendering = true;
            // 
            // edtKurzKontaktTelP
            // 
            this.edtKurzKontaktTelP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKurzKontaktTelP.DataMember = "Telefon_P";
            this.edtKurzKontaktTelP.DataSource = this.qryBaPerson;
            this.edtKurzKontaktTelP.Location = new System.Drawing.Point(114, 16);
            this.edtKurzKontaktTelP.Name = "edtKurzKontaktTelP";
            this.edtKurzKontaktTelP.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKurzKontaktTelP.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKurzKontaktTelP.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKurzKontaktTelP.Properties.Appearance.Options.UseBackColor = true;
            this.edtKurzKontaktTelP.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKurzKontaktTelP.Properties.Appearance.Options.UseFont = true;
            this.edtKurzKontaktTelP.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKurzKontaktTelP.Size = new System.Drawing.Size(246, 24);
            this.edtKurzKontaktTelP.TabIndex = 1;
            // 
            // lblKurzKontaktTelP
            // 
            this.lblKurzKontaktTelP.Location = new System.Drawing.Point(7, 16);
            this.lblKurzKontaktTelP.Name = "lblKurzKontaktTelP";
            this.lblKurzKontaktTelP.Size = new System.Drawing.Size(101, 24);
            this.lblKurzKontaktTelP.TabIndex = 0;
            this.lblKurzKontaktTelP.Text = "Telefon privat";
            this.lblKurzKontaktTelP.UseCompatibleTextRendering = true;
            // 
            // grpKurzWohnsitz
            // 
            this.grpKurzWohnsitz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpKurzWohnsitz.Controls.Add(this.chkKurzPostfachOhneNr);
            this.grpKurzWohnsitz.Controls.Add(this.edtKurzAdresseLand);
            this.grpKurzWohnsitz.Controls.Add(this.lblKurzAdresseLand);
            this.grpKurzWohnsitz.Controls.Add(this.edtKurzAdresseBezirk);
            this.grpKurzWohnsitz.Controls.Add(this.lblKurzAdresseBezirk);
            this.grpKurzWohnsitz.Controls.Add(this.edtKurzAdresseKt);
            this.grpKurzWohnsitz.Controls.Add(this.edtKurzAdresseOrt);
            this.grpKurzWohnsitz.Controls.Add(this.edtKurzAdressePLZ);
            this.grpKurzWohnsitz.Controls.Add(this.lblKurzAdressePLZOrtKt);
            this.grpKurzWohnsitz.Controls.Add(this.edtKurzAdressePostfach);
            this.grpKurzWohnsitz.Controls.Add(this.lblKurzAdressePostfach);
            this.grpKurzWohnsitz.Controls.Add(this.edtKurzAdresseHausNr);
            this.grpKurzWohnsitz.Controls.Add(this.edtKurzAdresseStrasse);
            this.grpKurzWohnsitz.Controls.Add(this.lblKurzAdresseStrasseNr);
            this.grpKurzWohnsitz.Controls.Add(this.edtKurzAdresseZusatz);
            this.grpKurzWohnsitz.Controls.Add(this.lblKurzAdresseZusatz);
            this.grpKurzWohnsitz.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grpKurzWohnsitz.Location = new System.Drawing.Point(5, 136);
            this.grpKurzWohnsitz.Name = "grpKurzWohnsitz";
            this.grpKurzWohnsitz.Size = new System.Drawing.Size(400, 167);
            this.grpKurzWohnsitz.TabIndex = 11;
            this.grpKurzWohnsitz.TabStop = false;
            this.grpKurzWohnsitz.Text = "Adresse";
            this.grpKurzWohnsitz.UseCompatibleTextRendering = true;
            // 
            // chkKurzPostfachOhneNr
            // 
            this.chkKurzPostfachOhneNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkKurzPostfachOhneNr.DataMember = "PostfachOhneNr";
            this.chkKurzPostfachOhneNr.DataSource = this.qryBaAdresseBezugsperson;
            this.chkKurzPostfachOhneNr.Location = new System.Drawing.Point(315, 67);
            this.chkKurzPostfachOhneNr.Name = "chkKurzPostfachOhneNr";
            this.chkKurzPostfachOhneNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkKurzPostfachOhneNr.Properties.Appearance.Options.UseBackColor = true;
            this.chkKurzPostfachOhneNr.Properties.Caption = "ohne Nr.";
            this.chkKurzPostfachOhneNr.Size = new System.Drawing.Size(76, 19);
            this.chkKurzPostfachOhneNr.TabIndex = 7;
            this.chkKurzPostfachOhneNr.CheckedChanged += new System.EventHandler(this.chkKurzPostfachOhneNr_CheckedChanged);
            // 
            // qryBaAdresseBezugsperson
            // 
            this.qryBaAdresseBezugsperson.HostControl = this;
            this.qryBaAdresseBezugsperson.TableName = "BaAdresse";
            this.qryBaAdresseBezugsperson.AfterFill += new System.EventHandler(this.qryBaAdresseBezugsperson_AfterFill);
            this.qryBaAdresseBezugsperson.AfterInsert += new System.EventHandler(this.qryBaAdresseBezugsperson_AfterInsert);
            this.qryBaAdresseBezugsperson.BeforePost += new System.EventHandler(this.qryBaAdresseBezugsperson_BeforePost);
            // 
            // edtKurzAdresseLand
            // 
            this.edtKurzAdresseLand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKurzAdresseLand.DataMember = "BaLandID";
            this.edtKurzAdresseLand.DataSource = this.qryBaAdresseBezugsperson;
            this.edtKurzAdresseLand.Location = new System.Drawing.Point(114, 133);
            this.edtKurzAdresseLand.Name = "edtKurzAdresseLand";
            this.edtKurzAdresseLand.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKurzAdresseLand.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKurzAdresseLand.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKurzAdresseLand.Properties.Appearance.Options.UseBackColor = true;
            this.edtKurzAdresseLand.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKurzAdresseLand.Properties.Appearance.Options.UseFont = true;
            this.edtKurzAdresseLand.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKurzAdresseLand.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKurzAdresseLand.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKurzAdresseLand.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKurzAdresseLand.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject34.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject34.Options.UseBackColor = true;
            this.edtKurzAdresseLand.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject34)});
            this.edtKurzAdresseLand.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKurzAdresseLand.Properties.NullText = "";
            this.edtKurzAdresseLand.Properties.ShowFooter = false;
            this.edtKurzAdresseLand.Properties.ShowHeader = false;
            this.edtKurzAdresseLand.Size = new System.Drawing.Size(277, 24);
            this.edtKurzAdresseLand.TabIndex = 15;
            // 
            // lblKurzAdresseLand
            // 
            this.lblKurzAdresseLand.Location = new System.Drawing.Point(12, 133);
            this.lblKurzAdresseLand.Name = "lblKurzAdresseLand";
            this.lblKurzAdresseLand.Size = new System.Drawing.Size(96, 24);
            this.lblKurzAdresseLand.TabIndex = 14;
            this.lblKurzAdresseLand.Text = "Land";
            this.lblKurzAdresseLand.UseCompatibleTextRendering = true;
            // 
            // edtKurzAdresseBezirk
            // 
            this.edtKurzAdresseBezirk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKurzAdresseBezirk.DataMember = "Bezirk";
            this.edtKurzAdresseBezirk.DataSource = this.qryBaAdresseBezugsperson;
            this.edtKurzAdresseBezirk.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKurzAdresseBezirk.Location = new System.Drawing.Point(114, 110);
            this.edtKurzAdresseBezirk.Name = "edtKurzAdresseBezirk";
            this.edtKurzAdresseBezirk.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKurzAdresseBezirk.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKurzAdresseBezirk.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKurzAdresseBezirk.Properties.Appearance.Options.UseBackColor = true;
            this.edtKurzAdresseBezirk.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKurzAdresseBezirk.Properties.Appearance.Options.UseFont = true;
            this.edtKurzAdresseBezirk.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKurzAdresseBezirk.Properties.ReadOnly = true;
            this.edtKurzAdresseBezirk.Size = new System.Drawing.Size(277, 24);
            this.edtKurzAdresseBezirk.TabIndex = 13;
            this.edtKurzAdresseBezirk.TabStop = false;
            // 
            // lblKurzAdresseBezirk
            // 
            this.lblKurzAdresseBezirk.Location = new System.Drawing.Point(12, 109);
            this.lblKurzAdresseBezirk.Name = "lblKurzAdresseBezirk";
            this.lblKurzAdresseBezirk.Size = new System.Drawing.Size(96, 24);
            this.lblKurzAdresseBezirk.TabIndex = 12;
            this.lblKurzAdresseBezirk.Text = "Bezirk";
            this.lblKurzAdresseBezirk.UseCompatibleTextRendering = true;
            // 
            // edtKurzAdresseKt
            // 
            this.edtKurzAdresseKt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKurzAdresseKt.DataMember = "Kanton";
            this.edtKurzAdresseKt.DataSource = this.qryBaAdresseBezugsperson;
            this.edtKurzAdresseKt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKurzAdresseKt.Location = new System.Drawing.Point(360, 87);
            this.edtKurzAdresseKt.Name = "edtKurzAdresseKt";
            this.edtKurzAdresseKt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKurzAdresseKt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKurzAdresseKt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKurzAdresseKt.Properties.Appearance.Options.UseBackColor = true;
            this.edtKurzAdresseKt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKurzAdresseKt.Properties.Appearance.Options.UseFont = true;
            this.edtKurzAdresseKt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKurzAdresseKt.Properties.ReadOnly = true;
            this.edtKurzAdresseKt.Size = new System.Drawing.Size(31, 24);
            this.edtKurzAdresseKt.TabIndex = 11;
            this.edtKurzAdresseKt.TabStop = false;
            // 
            // edtKurzAdresseOrt
            // 
            this.edtKurzAdresseOrt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKurzAdresseOrt.DataMember = "Ort";
            this.edtKurzAdresseOrt.DataSource = this.qryBaAdresseBezugsperson;
            this.edtKurzAdresseOrt.Location = new System.Drawing.Point(157, 87);
            this.edtKurzAdresseOrt.Name = "edtKurzAdresseOrt";
            this.edtKurzAdresseOrt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKurzAdresseOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKurzAdresseOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKurzAdresseOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtKurzAdresseOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKurzAdresseOrt.Properties.Appearance.Options.UseFont = true;
            this.edtKurzAdresseOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKurzAdresseOrt.Size = new System.Drawing.Size(204, 24);
            this.edtKurzAdresseOrt.TabIndex = 10;
            this.edtKurzAdresseOrt.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKurzAdresseOrt_UserModifiedFld);
            // 
            // edtKurzAdressePLZ
            // 
            this.edtKurzAdressePLZ.DataMember = "PLZ";
            this.edtKurzAdressePLZ.DataSource = this.qryBaAdresseBezugsperson;
            this.edtKurzAdressePLZ.Location = new System.Drawing.Point(114, 87);
            this.edtKurzAdressePLZ.Name = "edtKurzAdressePLZ";
            this.edtKurzAdressePLZ.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKurzAdressePLZ.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKurzAdressePLZ.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKurzAdressePLZ.Properties.Appearance.Options.UseBackColor = true;
            this.edtKurzAdressePLZ.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKurzAdressePLZ.Properties.Appearance.Options.UseFont = true;
            this.edtKurzAdressePLZ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKurzAdressePLZ.Size = new System.Drawing.Size(45, 24);
            this.edtKurzAdressePLZ.TabIndex = 9;
            this.edtKurzAdressePLZ.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKurzAdressePLZ_UserModifiedFld);
            // 
            // lblKurzAdressePLZOrtKt
            // 
            this.lblKurzAdressePLZOrtKt.Location = new System.Drawing.Point(12, 85);
            this.lblKurzAdressePLZOrtKt.Name = "lblKurzAdressePLZOrtKt";
            this.lblKurzAdressePLZOrtKt.Size = new System.Drawing.Size(96, 24);
            this.lblKurzAdressePLZOrtKt.TabIndex = 8;
            this.lblKurzAdressePLZOrtKt.Text = "PLZ / Ort / Kt.";
            this.lblKurzAdressePLZOrtKt.UseCompatibleTextRendering = true;
            // 
            // edtKurzAdressePostfach
            // 
            this.edtKurzAdressePostfach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKurzAdressePostfach.DataMember = "Postfach";
            this.edtKurzAdressePostfach.DataSource = this.qryBaAdresseBezugsperson;
            this.edtKurzAdressePostfach.Location = new System.Drawing.Point(114, 64);
            this.edtKurzAdressePostfach.Name = "edtKurzAdressePostfach";
            this.edtKurzAdressePostfach.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKurzAdressePostfach.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKurzAdressePostfach.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKurzAdressePostfach.Properties.Appearance.Options.UseBackColor = true;
            this.edtKurzAdressePostfach.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKurzAdressePostfach.Properties.Appearance.Options.UseFont = true;
            this.edtKurzAdressePostfach.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKurzAdressePostfach.Size = new System.Drawing.Size(195, 24);
            this.edtKurzAdressePostfach.TabIndex = 6;
            // 
            // lblKurzAdressePostfach
            // 
            this.lblKurzAdressePostfach.Location = new System.Drawing.Point(12, 64);
            this.lblKurzAdressePostfach.Name = "lblKurzAdressePostfach";
            this.lblKurzAdressePostfach.Size = new System.Drawing.Size(96, 24);
            this.lblKurzAdressePostfach.TabIndex = 5;
            this.lblKurzAdressePostfach.Text = "Postfach";
            this.lblKurzAdressePostfach.UseCompatibleTextRendering = true;
            // 
            // edtKurzAdresseHausNr
            // 
            this.edtKurzAdresseHausNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKurzAdresseHausNr.DataMember = "HausNr";
            this.edtKurzAdresseHausNr.DataSource = this.qryBaAdresseBezugsperson;
            this.edtKurzAdresseHausNr.Location = new System.Drawing.Point(342, 41);
            this.edtKurzAdresseHausNr.Name = "edtKurzAdresseHausNr";
            this.edtKurzAdresseHausNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKurzAdresseHausNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKurzAdresseHausNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKurzAdresseHausNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtKurzAdresseHausNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKurzAdresseHausNr.Properties.Appearance.Options.UseFont = true;
            this.edtKurzAdresseHausNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKurzAdresseHausNr.Size = new System.Drawing.Size(49, 24);
            this.edtKurzAdresseHausNr.TabIndex = 4;
            // 
            // edtKurzAdresseStrasse
            // 
            this.edtKurzAdresseStrasse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKurzAdresseStrasse.DataMember = "Strasse";
            this.edtKurzAdresseStrasse.DataSource = this.qryBaAdresseBezugsperson;
            this.edtKurzAdresseStrasse.Location = new System.Drawing.Point(114, 41);
            this.edtKurzAdresseStrasse.Name = "edtKurzAdresseStrasse";
            this.edtKurzAdresseStrasse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKurzAdresseStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKurzAdresseStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKurzAdresseStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtKurzAdresseStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKurzAdresseStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtKurzAdresseStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKurzAdresseStrasse.Size = new System.Drawing.Size(229, 24);
            this.edtKurzAdresseStrasse.TabIndex = 3;
            // 
            // lblKurzAdresseStrasseNr
            // 
            this.lblKurzAdresseStrasseNr.Location = new System.Drawing.Point(12, 41);
            this.lblKurzAdresseStrasseNr.Name = "lblKurzAdresseStrasseNr";
            this.lblKurzAdresseStrasseNr.Size = new System.Drawing.Size(96, 24);
            this.lblKurzAdresseStrasseNr.TabIndex = 2;
            this.lblKurzAdresseStrasseNr.Text = "Strasse / Nr.";
            this.lblKurzAdresseStrasseNr.UseCompatibleTextRendering = true;
            // 
            // edtKurzAdresseZusatz
            // 
            this.edtKurzAdresseZusatz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKurzAdresseZusatz.DataMember = "Zusatz";
            this.edtKurzAdresseZusatz.DataSource = this.qryBaAdresseBezugsperson;
            this.edtKurzAdresseZusatz.Location = new System.Drawing.Point(114, 18);
            this.edtKurzAdresseZusatz.Name = "edtKurzAdresseZusatz";
            this.edtKurzAdresseZusatz.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKurzAdresseZusatz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKurzAdresseZusatz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKurzAdresseZusatz.Properties.Appearance.Options.UseBackColor = true;
            this.edtKurzAdresseZusatz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKurzAdresseZusatz.Properties.Appearance.Options.UseFont = true;
            this.edtKurzAdresseZusatz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKurzAdresseZusatz.Size = new System.Drawing.Size(277, 24);
            this.edtKurzAdresseZusatz.TabIndex = 1;
            // 
            // lblKurzAdresseZusatz
            // 
            this.lblKurzAdresseZusatz.Location = new System.Drawing.Point(12, 18);
            this.lblKurzAdresseZusatz.Name = "lblKurzAdresseZusatz";
            this.lblKurzAdresseZusatz.Size = new System.Drawing.Size(96, 24);
            this.lblKurzAdresseZusatz.TabIndex = 0;
            this.lblKurzAdresseZusatz.Text = "Zusatz";
            this.lblKurzAdresseZusatz.UseCompatibleTextRendering = true;
            // 
            // edtKurzVorname
            // 
            this.edtKurzVorname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKurzVorname.DataMember = "Vorname";
            this.edtKurzVorname.DataSource = this.qryBaPerson;
            this.edtKurzVorname.Location = new System.Drawing.Point(291, 106);
            this.edtKurzVorname.Name = "edtKurzVorname";
            this.edtKurzVorname.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKurzVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKurzVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKurzVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtKurzVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKurzVorname.Properties.Appearance.Options.UseFont = true;
            this.edtKurzVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKurzVorname.Size = new System.Drawing.Size(114, 24);
            this.edtKurzVorname.TabIndex = 10;
            // 
            // edtKurzName
            // 
            this.edtKurzName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKurzName.DataMember = "Name";
            this.edtKurzName.DataSource = this.qryBaPerson;
            this.edtKurzName.Location = new System.Drawing.Point(119, 106);
            this.edtKurzName.Name = "edtKurzName";
            this.edtKurzName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKurzName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKurzName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKurzName.Properties.Appearance.Options.UseBackColor = true;
            this.edtKurzName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKurzName.Properties.Appearance.Options.UseFont = true;
            this.edtKurzName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKurzName.Size = new System.Drawing.Size(173, 24);
            this.edtKurzName.TabIndex = 9;
            // 
            // lblKurzNameVorname
            // 
            this.lblKurzNameVorname.Location = new System.Drawing.Point(5, 106);
            this.lblKurzNameVorname.Name = "lblKurzNameVorname";
            this.lblKurzNameVorname.Size = new System.Drawing.Size(108, 24);
            this.lblKurzNameVorname.TabIndex = 8;
            this.lblKurzNameVorname.Text = "Name / Vorname";
            this.lblKurzNameVorname.UseCompatibleTextRendering = true;
            // 
            // edtKurzTitel
            // 
            this.edtKurzTitel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKurzTitel.DataMember = "Titel";
            this.edtKurzTitel.DataSource = this.qryBaPerson;
            this.edtKurzTitel.Location = new System.Drawing.Point(119, 30);
            this.edtKurzTitel.Name = "edtKurzTitel";
            this.edtKurzTitel.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKurzTitel.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKurzTitel.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKurzTitel.Properties.Appearance.Options.UseBackColor = true;
            this.edtKurzTitel.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKurzTitel.Properties.Appearance.Options.UseFont = true;
            this.edtKurzTitel.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKurzTitel.Size = new System.Drawing.Size(161, 24);
            this.edtKurzTitel.TabIndex = 2;
            // 
            // lblKurzTitel
            // 
            this.lblKurzTitel.Location = new System.Drawing.Point(5, 30);
            this.lblKurzTitel.Name = "lblKurzTitel";
            this.lblKurzTitel.Size = new System.Drawing.Size(108, 24);
            this.lblKurzTitel.TabIndex = 1;
            this.lblKurzTitel.Text = "Titel";
            this.lblKurzTitel.UseCompatibleTextRendering = true;
            // 
            // qryRelationFemale
            // 
            this.qryRelationFemale.HostControl = this;
            // 
            // qryRelationGeneric
            // 
            this.qryRelationGeneric.HostControl = this;
            // 
            // qryRelationMale
            // 
            this.qryRelationMale.HostControl = this;
            // 
            // CtlBaStammdaten
            // 
            this.ActiveSQLQuery = this.qryBaPerson;
            this.Controls.Add(this.pnlTab);
            this.Controls.Add(this.panTitel);
            this.Name = "CtlBaStammdaten";
            this.Size = new System.Drawing.Size(722, 692);
            this.Load += new System.EventHandler(this.CtlBaStammdaten_Load);
            this.panTitel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkZeigeDetails.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeigeDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            this.pnlTab.ResumeLayout(false);
            this.tabStammdaten.ResumeLayout(false);
            this.tpgPersonalien.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonDebitorNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonDebitorNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonAnrede.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPersonManuelleAnrede.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonBriefanrede)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonBriefanrede.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonAnrede)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPersonKeinSerienbrief.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWichtigerHinweis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonalienBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWichtigerHinweis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWichtigerHinweis)).EndInit();
            this.grpIVBerechtigung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtIVBerechtigungAktuellerStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIVBerechtigungAktuellerStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIVBerechtigungAktuellerStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVormundPI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVormundMassnahmenCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVormundMassnahmenCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVormundschaftlicheMassnahmen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErwerbssituationCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErwerbssituationCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErwerbssituation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusbildungCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusbildungCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusbildung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkInCHSeitGeburt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInCHSeit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInCHSeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuslaenderStatusCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuslaenderStatusCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuslStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKorrespondenzSpracheCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKorrespondenzSpracheCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSprachCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSprachCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKorrespondenzSprache)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSprache)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonKlientenkontoNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonKlientenkontoNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKontoFuehrung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMehrfachbehinderungBSV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBSVBehinderungsartCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBSVBehinderungsartCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBSVBehinderungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBehinderungsart2Code.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBehinderungsart2Code)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBehinderungsart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHauptBehinderungsartCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHauptBehinderungsartCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHauptbehinderungsArt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHeimatGemeinde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHeimatGemeinde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaetCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaetCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZivilstandCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZivilstandCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZivilstand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlechtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlechtCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeschlecht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSterbedatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsdatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersicherungsNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersicherungsNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFruehererName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFruehererName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTitel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLaufendeVollmachtErlaubnis.Properties)).EndInit();
            this.tpgAdresse.ResumeLayout(false);
            this.panTblAdresseBottom.ResumeLayout(false);
            this.grpAdresseBemerkungen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memBemerkungenAdresse.Properties)).EndInit();
            this.grpWohnsitzDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkEigenerMietvertrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMietdepotProInfirmis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsituationStatusCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsituationStatusCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseWohnstatus)).EndInit();
            this.tpgKontaktBankPost.ResumeLayout(false);
            this.grpBankPostZahlungsverbindungen.ResumeLayout(false);
            this.panKontakt.ResumeLayout(false);
            this.grpKontakt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtEMail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkZeigeTelMobil.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMobilTel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefonMobil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkZeigeTelGeschaeft.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefon_G.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefonGeschaeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkZeigeTelPrivat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefon_P.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefonPrivat)).EndInit();
            this.tpgSozialversicherung.ResumeLayout(false);
            this.grpAssistenz.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblAssistenzbeitrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVerfuegung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAssistenzbeitrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblABeitragAb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIvVerfuegteAssistenzberatung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVerfuegung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIvVerfuegteAssistenzberatung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtABeitragAb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIvVerfuegteAssistenzberatungStunden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWitwenWitwerWaisenrente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkWittwenWittwerWaisenrente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memBemerkungenSV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSozialversicherungBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memAndereSVLeistungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAndereSVLeistungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKTG.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKTG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkALK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblALK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSozialhilfe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSozialhilfe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUVGTaggeld.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUVGTaggeld)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUVGRente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUVGRente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBVGRente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBVGRente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkErgaenzungsLeistungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErgaenzungsleistungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMedizinischeMassnahmeIV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIVHilfsmittel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMedizinischeMassnahmeIV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIVHilfsmittel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBeruflicheMassnahmeIV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeruflicheMassnahmenIV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIVTaggeld.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIVTaggeld)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIntensivPflegeZuschlag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIntensivPflegeZuschlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIntensivPflegeZuschlag)).EndInit();
            this.grpKantonaleZuschuesse.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdKZSZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKZSZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKZSVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKZSVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKZSFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKZSFilter)).EndInit();
            this.grpHELB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkHelbKeinAntrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHelbKeinAntrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHelbDatumEntscheid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHelbDatumEntscheid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHelbAbWann.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHelbAbWann)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHelpEntscheid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHelpEntscheid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHelbEntscheid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHelbAnmeldung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHelbAnmeldung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHilfslosenEntschaedigung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHilfslosenEntschaedigung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHilfslosenentschaedigung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIVGradProzent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIVGrad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIVGrad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRentenstufe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRentenstufe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRentenstufe)).EndInit();
            this.tpgRechnungsadressen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRechnungsadressen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryRechnungsadressen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRechnungsadressen)).EndInit();
            this.panRechnungsadressenUnten.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memRechnungsadresseBemerkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechnungsadresseBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungsadresseLand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungsadresseLand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechnungsadresseLand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungsadresseBezirk.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechnungsadresseBezirk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungsadresseKanton.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungsadresseOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungsadressePLZ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechnungsadressePLZOrtKt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungsadressePostfach.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechnungsadressePostfach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungsadresseHausNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungsadresseStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechnungsadresseStrasseNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungsadresseZusatz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechnungsadresseZusatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungsadresseVornameName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechnungsadresseNameVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungsadresseDL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungsadresseDL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechnungsadresseDL)).EndInit();
            this.tpgKurz.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzAnrede.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKurzManuelleAnrede.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzBriefanrede)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzBriefanrede.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzAnrede)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKurzKeinSerienbrief.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKurzGleicherHaushalt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPersonRelation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzBeziehung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzBeziehung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzBeziehung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzSprache.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzSprache)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzSprache)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzGeschlechtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzGeschlechtCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzGeschlecht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzSterbedatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzTod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzGeburtsdatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzGeburt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzVersichertenNummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzVersichertenNummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzPersonenNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzPersonenNr)).EndInit();
            this.grpKurzKontakt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkBPZeigeTelMobil.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBPZeigeTelGeschaeft.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBPZeigeTelPrivat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzKontaktEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzKontaktEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzKontaktFax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzKontaktFax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzKontaktTelM.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzKontaktTelM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzKontaktTelG.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzKontaktTelG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzKontaktTelP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzKontaktTelP)).EndInit();
            this.grpKurzWohnsitz.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkKurzPostfachOhneNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaAdresseBezugsperson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzAdresseLand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzAdresseLand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzAdresseLand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzAdresseBezirk.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzAdresseBezirk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzAdresseKt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzAdresseOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzAdressePLZ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzAdressePLZOrtKt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzAdressePostfach.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzAdressePostfach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzAdresseHausNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzAdresseStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzAdresseStrasseNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzAdresseZusatz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzAdresseZusatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzNameVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurzTitel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryRelationFemale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryRelationGeneric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryRelationMale)).EndInit();
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

        private KissCheckEdit chkHelbKeinAntrag;
        private KissLabel lblHelbKeinAntrag;
        private KissCheckEdit chkWittwenWittwerWaisenrente;
        private KissLabel lblWitwenWitwerWaisenrente;
        private KissCheckEdit edtAssistenzbeitrag;
        private KissLabel lblAssistenzbeitrag;
        private KissCalcEdit edtIvVerfuegteAssistenzberatung;
        private KissLabel lblIvVerfuegteAssistenzberatung;
        private KissLabel lblIvVerfuegteAssistenzberatungStunden;
        private KissLabel lblDatumVerfuegung;
        private KissLabel lblABeitragAb;
        private KissDateEdit edtDatumVerfuegung;
        private KissDateEdit edtABeitragAb;
        private KissGroupBox grpAssistenz;
        private KissCalcEdit edtPersonDebitorNr;
        private KissLabel lblPersonDebitorNr;
    }
}
