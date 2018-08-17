namespace KiSS4.Arbeit
{
    public partial class CtlKaVermittlungSIVermittlungsprofil
    {
        #region Fields

        #region Private Fields

        private KiSS4.Gui.KissButton btnEinsatzplatzSuchen;
        private KiSS4.Dokument.KissDocumentButton btnVermittlungsgespraech;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissLookUpEdit edtAeussereErscheinung;
        private KiSS4.Gui.KissCheckEdit edtAmTelefonVerstaendigen;
        private KiSS4.Gui.KissMemoEdit edtArbeitgebietBemerkungen;
        private KiSS4.Gui.KissCheckedLookupEdit edtArbeitszeiten;
        private KiSS4.Gui.KissMemoEdit edtBemerkungen;
        private KiSS4.Gui.KissCheckedLookupEdit edtBranchen;
        private KiSS4.Gui.KissDateEdit edtDatumGespraech;
        private KiSS4.Gui.KissLookUpEdit edtDeutschMuendlich;
        private KiSS4.Gui.KissLookUpEdit edtDeutschSchriftlich;
        private KiSS4.Gui.KissCheckedLookupEdit edtEinsatzbereich;
        private KiSS4.Gui.KissLookUpEdit edtFuehrerausweis;
        private KiSS4.Gui.KissLookUpEdit edtFuehrerausweisKategorie;
        private KiSS4.Gui.KissButtonEdit edtGepraechsfuehrer;
        private KiSS4.Gui.KissLookUpEdit edtGesundheitKoerperlich;
        private KiSS4.Gui.KissLookUpEdit edtGesundheitPsychisch;
        private KiSS4.Gui.KissCheckEdit edtInfoSDErfolgt;
        private KiSS4.Gui.KissCheckedLookupEdit edtKaBetriebe;
        private KiSS4.Gui.KissLookUpEdit edtKinderbetreuung;
        private KiSS4.Gui.KissLookUpEdit edtMotivation;
        private KiSS4.Gui.KissLookUpEdit edtPCKenntnisse;
        private KiSS4.Gui.KissCalcEdit edtPensumBis;
        private KiSS4.Gui.KissCalcEdit edtPensumVon;
        private KiSS4.Gui.KissLookUpEdit edtSprachstandermittlung;
        private KiSS4.Gui.KissLookUpEdit edtSucht;
        private KiSS4.Gui.KissLookUpEdit edtSuchtart;
        private KiSS4.Gui.KissLookUpEdit edtTherapie;
        private KiSS4.Gui.KissLookUpEdit edtZuverlaessigkeit;
        private System.Windows.Forms.PictureBox imageTitle;
        private KiSS4.Gui.KissLookUpEdit kissLookUpEdit1;
        private KiSS4.Gui.KissLabel lblAeussereErscheinung;
        private KiSS4.Gui.KissLabel lblArbeitszeiten;
        private KiSS4.Gui.KissLabel lblBemerkungen;
        private KiSS4.Gui.KissLabel lblBemerkungenArbeitsgebiet;
        private KiSS4.Gui.KissLabel lblBesondereFaehigkeiten;
        private KiSS4.Gui.KissLabel lblBesondereWuensche;
        private KiSS4.Gui.KissLabel lblBis;
        private KiSS4.Gui.KissLabel lblDatumGespräch;
        private KiSS4.Gui.KissLabel lblDiverses;
        private KiSS4.Gui.KissLabel lblEinsatzpensumVon;
        private KiSS4.Gui.KissLabel lblGesundheitBemerkung;
        private KiSS4.Gui.KissLabel lblFührerausweis;
        private KiSS4.Gui.KissLabel lblGespraech;
        private KiSS4.Gui.KissLabel lblGesprächsfuehrerIn;
        private KiSS4.Gui.KissLabel lblGesundheit;
        private KiSS4.Gui.KissLabel lblGesundheitkörperlich;
        private KiSS4.Gui.KissLabel lblGesundheitpsychisch;
        private KiSS4.Gui.KissLabel lblKategorie;
        private KiSS4.Gui.KissLabel lblKinderbetreuungGeregelt;
        private KiSS4.Gui.KissLabel lblMotivation;
        private KiSS4.Gui.KissLabel lblMuendlich;
        private KiSS4.Gui.KissLabel lblPCKenntnisse;
        private KiSS4.Gui.KissLabel lblProzent;
        private KiSS4.Gui.KissLabel lblResultatSprachstandermittlung;
        private KiSS4.Gui.KissLabel lblSucht;
        private KiSS4.Gui.KissLabel lblSuchtart;
        private KiSS4.Gui.KissLabel lblTitle;
        private KiSS4.Gui.KissLabel lblVermittelbarkeit;
        private KiSS4.Gui.KissLabel lblVerstaendigungDeutsch;
        private KiSS4.Gui.KissLabel lblZuverlaessigkeit;
        private KiSS4.Gui.KissLabel lblinTherapie;
        private KiSS4.Gui.KissLabel lblschriftlich;
        private System.Windows.Forms.Panel pnTitle;
        private KiSS4.DB.SqlQuery qrySIVermittlung;
        private KiSS4.Gui.KissTabControlEx tabVermittlungsprofil;
        private SharpLibrary.WinControls.TabPageEx tpgArbeitsgebiet;
        private SharpLibrary.WinControls.TabPageEx tpgPersoenlichesProfil;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKaVermittlungSIVermittlungsprofil));
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
            this.pnTitle = new System.Windows.Forms.Panel();
            this.btnVermittlungsgespraech = new KiSS4.Dokument.KissDocumentButton();
            this.imageTitle = new System.Windows.Forms.PictureBox();
            this.lblTitle = new KiSS4.Gui.KissLabel();
            this.tabVermittlungsprofil = new KiSS4.Gui.KissTabControlEx();
            this.tpgPersoenlichesProfil = new SharpLibrary.WinControls.TabPageEx();
            this.edtModivationBewertung = new KiSS4.Gui.KissLookUpEdit();
            this.qrySIVermittlung = new KiSS4.DB.SqlQuery(this.components);
            this.edtZuverlaessigkeitBewertung = new KiSS4.Gui.KissLookUpEdit();
            this.edtGesundheitPsychischBewertung = new KiSS4.Gui.KissLookUpEdit();
            this.edtGesundheitKoerperlichBewertung = new KiSS4.Gui.KissLookUpEdit();
            this.edtGesundheitBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.kissLookUpEdit1 = new KiSS4.Gui.KissLookUpEdit();
            this.lblVermittelbarkeit = new KiSS4.Gui.KissLabel();
            this.edtInfoSDErfolgt = new KiSS4.Gui.KissCheckEdit();
            this.edtBemerkungen = new KiSS4.Gui.KissMemoEdit();
            this.lblBemerkungen = new KiSS4.Gui.KissLabel();
            this.edtKinderbetreuung = new KiSS4.Gui.KissLookUpEdit();
            this.lblKinderbetreuungGeregelt = new KiSS4.Gui.KissLabel();
            this.edtMotivation = new KiSS4.Gui.KissLookUpEdit();
            this.lblMotivation = new KiSS4.Gui.KissLabel();
            this.edtZuverlaessigkeit = new KiSS4.Gui.KissLookUpEdit();
            this.lblZuverlaessigkeit = new KiSS4.Gui.KissLabel();
            this.edtAeussereErscheinung = new KiSS4.Gui.KissLookUpEdit();
            this.lblAeussereErscheinung = new KiSS4.Gui.KissLabel();
            this.lblDiverses = new KiSS4.Gui.KissLabel();
            this.edtSuchtart = new KiSS4.Gui.KissLookUpEdit();
            this.lblSuchtart = new KiSS4.Gui.KissLabel();
            this.edtSucht = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucht = new KiSS4.Gui.KissLabel();
            this.edtTherapie = new KiSS4.Gui.KissLookUpEdit();
            this.lblinTherapie = new KiSS4.Gui.KissLabel();
            this.edtGesundheitPsychisch = new KiSS4.Gui.KissLookUpEdit();
            this.lblGesundheitpsychisch = new KiSS4.Gui.KissLabel();
            this.lblGesundheitBemerkung = new KiSS4.Gui.KissLabel();
            this.edtGesundheitKoerperlich = new KiSS4.Gui.KissLookUpEdit();
            this.lblGesundheitkörperlich = new KiSS4.Gui.KissLabel();
            this.lblGesundheit = new KiSS4.Gui.KissLabel();
            this.edtSprachstandermittlung = new KiSS4.Gui.KissLookUpEdit();
            this.lblResultatSprachstandermittlung = new KiSS4.Gui.KissLabel();
            this.edtDeutschSchriftlich = new KiSS4.Gui.KissLookUpEdit();
            this.lblschriftlich = new KiSS4.Gui.KissLabel();
            this.edtAmTelefonVerstaendigen = new KiSS4.Gui.KissCheckEdit();
            this.edtDeutschMuendlich = new KiSS4.Gui.KissLookUpEdit();
            this.lblMuendlich = new KiSS4.Gui.KissLabel();
            this.lblVerstaendigungDeutsch = new KiSS4.Gui.KissLabel();
            this.edtGepraechsfuehrer = new KiSS4.Gui.KissButtonEdit();
            this.lblGesprächsfuehrerIn = new KiSS4.Gui.KissLabel();
            this.edtDatumGespraech = new KiSS4.Gui.KissDateEdit();
            this.lblDatumGespräch = new KiSS4.Gui.KissLabel();
            this.lblGespraech = new KiSS4.Gui.KissLabel();
            this.tpgArbeitsgebiet = new SharpLibrary.WinControls.TabPageEx();
            this.edtIstAngemeldet = new KiSS4.Gui.KissCheckEdit();
            this.lblIstAngemeldet = new KiSS4.Gui.KissLabel();
            this.edtBesondereWuensche = new KiSS4.Gui.KissMemoEdit();
            this.edtBesondereFaehigkeiten = new KiSS4.Gui.KissMemoEdit();
            this.grpEinsatzbereiche = new KiSS4.Gui.KissGroupBox();
            this.edtEinsatzbereich = new KiSS4.Gui.KissCheckedLookupEdit();
            this.grpKABetriebe = new KiSS4.Gui.KissGroupBox();
            this.edtKaBetriebe = new KiSS4.Gui.KissCheckedLookupEdit();
            this.grpBranchen = new KiSS4.Gui.KissGroupBox();
            this.edtBranchen = new KiSS4.Gui.KissCheckedLookupEdit();
            this.lblBemerkungenArbeitsgebiet = new KiSS4.Gui.KissLabel();
            this.lblArbeitszeiten = new KiSS4.Gui.KissLabel();
            this.lblPCKenntnisse = new KiSS4.Gui.KissLabel();
            this.lblKategorie = new KiSS4.Gui.KissLabel();
            this.lblFührerausweis = new KiSS4.Gui.KissLabel();
            this.lblBesondereFaehigkeiten = new KiSS4.Gui.KissLabel();
            this.lblBesondereWuensche = new KiSS4.Gui.KissLabel();
            this.lblProzent = new KiSS4.Gui.KissLabel();
            this.lblBis = new KiSS4.Gui.KissLabel();
            this.lblEinsatzpensumVon = new KiSS4.Gui.KissLabel();
            this.btnEinsatzplatzSuchen = new KiSS4.Gui.KissButton();
            this.edtArbeitgebietBemerkungen = new KiSS4.Gui.KissMemoEdit();
            this.edtArbeitszeiten = new KiSS4.Gui.KissCheckedLookupEdit();
            this.edtPCKenntnisse = new KiSS4.Gui.KissLookUpEdit();
            this.edtFuehrerausweisKategorie = new KiSS4.Gui.KissLookUpEdit();
            this.edtFuehrerausweis = new KiSS4.Gui.KissLookUpEdit();
            this.edtPensumBis = new KiSS4.Gui.KissCalcEdit();
            this.edtPensumVon = new KiSS4.Gui.KissCalcEdit();
            this.pnTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            this.tabVermittlungsprofil.SuspendLayout();
            this.tpgPersoenlichesProfil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtModivationBewertung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModivationBewertung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrySIVermittlung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZuverlaessigkeitBewertung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZuverlaessigkeitBewertung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGesundheitPsychischBewertung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGesundheitPsychischBewertung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGesundheitKoerperlichBewertung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGesundheitKoerperlichBewertung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGesundheitBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVermittelbarkeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInfoSDErfolgt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKinderbetreuung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKinderbetreuung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKinderbetreuungGeregelt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMotivation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMotivation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMotivation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZuverlaessigkeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZuverlaessigkeit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZuverlaessigkeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAeussereErscheinung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAeussereErscheinung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAeussereErscheinung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDiverses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchtart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchtart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchtart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucht.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTherapie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTherapie.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblinTherapie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGesundheitPsychisch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGesundheitPsychisch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGesundheitpsychisch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGesundheitBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGesundheitKoerperlich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGesundheitKoerperlich.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGesundheitkörperlich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGesundheit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSprachstandermittlung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSprachstandermittlung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblResultatSprachstandermittlung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDeutschSchriftlich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDeutschSchriftlich.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblschriftlich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAmTelefonVerstaendigen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDeutschMuendlich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDeutschMuendlich.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMuendlich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerstaendigungDeutsch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGepraechsfuehrer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGesprächsfuehrerIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumGespraech.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumGespräch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGespraech)).BeginInit();
            this.tpgArbeitsgebiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtIstAngemeldet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIstAngemeldet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBesondereWuensche.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBesondereFaehigkeiten.Properties)).BeginInit();
            this.grpEinsatzbereiche.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzbereich)).BeginInit();
            this.grpKABetriebe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtKaBetriebe)).BeginInit();
            this.grpBranchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtBranchen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungenArbeitsgebiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblArbeitszeiten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPCKenntnisse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKategorie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFührerausweis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBesondereFaehigkeiten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBesondereWuensche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProzent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzpensumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtArbeitgebietBemerkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtArbeitszeiten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPCKenntnisse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPCKenntnisse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFuehrerausweisKategorie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFuehrerausweisKategorie.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFuehrerausweis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFuehrerausweis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPensumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPensumVon.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnTitle
            // 
            this.pnTitle.Controls.Add(this.btnVermittlungsgespraech);
            this.pnTitle.Controls.Add(this.imageTitle);
            this.pnTitle.Controls.Add(this.lblTitle);
            this.pnTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTitle.Location = new System.Drawing.Point(0, 0);
            this.pnTitle.Name = "pnTitle";
            this.pnTitle.Size = new System.Drawing.Size(740, 40);
            this.pnTitle.TabIndex = 0;
            // 
            // btnVermittlungsgespraech
            // 
            this.btnVermittlungsgespraech.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVermittlungsgespraech.Context = "KaVermProfilSIVermGespraech";
            this.btnVermittlungsgespraech.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVermittlungsgespraech.Image = ((System.Drawing.Image)(resources.GetObject("btnVermittlungsgespraech.Image")));
            this.btnVermittlungsgespraech.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVermittlungsgespraech.Location = new System.Drawing.Point(575, 10);
            this.btnVermittlungsgespraech.Name = "btnVermittlungsgespraech";
            this.btnVermittlungsgespraech.Size = new System.Drawing.Size(159, 24);
            this.btnVermittlungsgespraech.TabIndex = 1;
            this.btnVermittlungsgespraech.Text = "Vermittlungsgespräch";
            this.btnVermittlungsgespraech.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVermittlungsgespraech.UseCompatibleTextRendering = true;
            this.btnVermittlungsgespraech.UseVisualStyleBackColor = false;
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
            this.lblTitle.Text = "Vermittlungsprofil";
            this.lblTitle.UseCompatibleTextRendering = true;
            // 
            // tabVermittlungsprofil
            // 
            this.tabVermittlungsprofil.Controls.Add(this.tpgPersoenlichesProfil);
            this.tabVermittlungsprofil.Controls.Add(this.tpgArbeitsgebiet);
            this.tabVermittlungsprofil.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabVermittlungsprofil.Location = new System.Drawing.Point(0, 40);
            this.tabVermittlungsprofil.Name = "tabVermittlungsprofil";
            this.tabVermittlungsprofil.ShowFixedWidthTooltip = true;
            this.tabVermittlungsprofil.Size = new System.Drawing.Size(740, 650);
            this.tabVermittlungsprofil.TabIndex = 1;
            this.tabVermittlungsprofil.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgPersoenlichesProfil,
            this.tpgArbeitsgebiet});
            this.tabVermittlungsprofil.TabsLineColor = System.Drawing.Color.Black;
            this.tabVermittlungsprofil.TabsLocation = SharpLibrary.WinControls.TabsLocation.Top;
            this.tabVermittlungsprofil.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            // 
            // tpgPersoenlichesProfil
            // 
            this.tpgPersoenlichesProfil.Controls.Add(this.edtModivationBewertung);
            this.tpgPersoenlichesProfil.Controls.Add(this.edtZuverlaessigkeitBewertung);
            this.tpgPersoenlichesProfil.Controls.Add(this.edtGesundheitPsychischBewertung);
            this.tpgPersoenlichesProfil.Controls.Add(this.edtGesundheitKoerperlichBewertung);
            this.tpgPersoenlichesProfil.Controls.Add(this.edtGesundheitBemerkung);
            this.tpgPersoenlichesProfil.Controls.Add(this.kissLookUpEdit1);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblVermittelbarkeit);
            this.tpgPersoenlichesProfil.Controls.Add(this.edtInfoSDErfolgt);
            this.tpgPersoenlichesProfil.Controls.Add(this.edtBemerkungen);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblBemerkungen);
            this.tpgPersoenlichesProfil.Controls.Add(this.edtKinderbetreuung);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblKinderbetreuungGeregelt);
            this.tpgPersoenlichesProfil.Controls.Add(this.edtMotivation);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblMotivation);
            this.tpgPersoenlichesProfil.Controls.Add(this.edtZuverlaessigkeit);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblZuverlaessigkeit);
            this.tpgPersoenlichesProfil.Controls.Add(this.edtAeussereErscheinung);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblAeussereErscheinung);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblDiverses);
            this.tpgPersoenlichesProfil.Controls.Add(this.edtSuchtart);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblSuchtart);
            this.tpgPersoenlichesProfil.Controls.Add(this.edtSucht);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblSucht);
            this.tpgPersoenlichesProfil.Controls.Add(this.edtTherapie);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblinTherapie);
            this.tpgPersoenlichesProfil.Controls.Add(this.edtGesundheitPsychisch);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblGesundheitpsychisch);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblGesundheitBemerkung);
            this.tpgPersoenlichesProfil.Controls.Add(this.edtGesundheitKoerperlich);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblGesundheitkörperlich);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblGesundheit);
            this.tpgPersoenlichesProfil.Controls.Add(this.edtSprachstandermittlung);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblResultatSprachstandermittlung);
            this.tpgPersoenlichesProfil.Controls.Add(this.edtDeutschSchriftlich);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblschriftlich);
            this.tpgPersoenlichesProfil.Controls.Add(this.edtAmTelefonVerstaendigen);
            this.tpgPersoenlichesProfil.Controls.Add(this.edtDeutschMuendlich);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblMuendlich);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblVerstaendigungDeutsch);
            this.tpgPersoenlichesProfil.Controls.Add(this.edtGepraechsfuehrer);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblGesprächsfuehrerIn);
            this.tpgPersoenlichesProfil.Controls.Add(this.edtDatumGespraech);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblDatumGespräch);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblGespraech);
            this.tpgPersoenlichesProfil.Location = new System.Drawing.Point(6, 32);
            this.tpgPersoenlichesProfil.Name = "tpgPersoenlichesProfil";
            this.tpgPersoenlichesProfil.Size = new System.Drawing.Size(728, 612);
            this.tpgPersoenlichesProfil.TabIndex = 0;
            this.tpgPersoenlichesProfil.Title = "Persönliches Profil";
            // 
            // edtModivationBewertung
            // 
            this.edtModivationBewertung.AllowNull = false;
            this.edtModivationBewertung.DataMember = "MotivationBIBIPSIBewertung";
            this.edtModivationBewertung.DataSource = this.qrySIVermittlung;
            this.edtModivationBewertung.Location = new System.Drawing.Point(663, 395);
            this.edtModivationBewertung.Name = "edtModivationBewertung";
            this.edtModivationBewertung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtModivationBewertung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtModivationBewertung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtModivationBewertung.Properties.Appearance.Options.UseBackColor = true;
            this.edtModivationBewertung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtModivationBewertung.Properties.Appearance.Options.UseFont = true;
            this.edtModivationBewertung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtModivationBewertung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtModivationBewertung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtModivationBewertung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtModivationBewertung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtModivationBewertung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtModivationBewertung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtModivationBewertung.Properties.NullText = "";
            this.edtModivationBewertung.Properties.ShowFooter = false;
            this.edtModivationBewertung.Properties.ShowHeader = false;
            this.edtModivationBewertung.Size = new System.Drawing.Size(54, 24);
            this.edtModivationBewertung.TabIndex = 38;
            // 
            // qrySIVermittlung
            // 
            this.qrySIVermittlung.CanUpdate = true;
            this.qrySIVermittlung.HostControl = this;
            this.qrySIVermittlung.SelectStatement = resources.GetString("qrySIVermittlung.SelectStatement");
            this.qrySIVermittlung.TableName = "KaVermittlungProfil";
            // 
            // edtZuverlaessigkeitBewertung
            // 
            this.edtZuverlaessigkeitBewertung.AllowNull = false;
            this.edtZuverlaessigkeitBewertung.DataMember = "ZuverlaessigkeitBewertung";
            this.edtZuverlaessigkeitBewertung.DataSource = this.qrySIVermittlung;
            this.edtZuverlaessigkeitBewertung.Location = new System.Drawing.Point(323, 455);
            this.edtZuverlaessigkeitBewertung.Name = "edtZuverlaessigkeitBewertung";
            this.edtZuverlaessigkeitBewertung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZuverlaessigkeitBewertung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZuverlaessigkeitBewertung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZuverlaessigkeitBewertung.Properties.Appearance.Options.UseBackColor = true;
            this.edtZuverlaessigkeitBewertung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZuverlaessigkeitBewertung.Properties.Appearance.Options.UseFont = true;
            this.edtZuverlaessigkeitBewertung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtZuverlaessigkeitBewertung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtZuverlaessigkeitBewertung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtZuverlaessigkeitBewertung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtZuverlaessigkeitBewertung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtZuverlaessigkeitBewertung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtZuverlaessigkeitBewertung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZuverlaessigkeitBewertung.Properties.NullText = "";
            this.edtZuverlaessigkeitBewertung.Properties.ShowFooter = false;
            this.edtZuverlaessigkeitBewertung.Properties.ShowHeader = false;
            this.edtZuverlaessigkeitBewertung.Size = new System.Drawing.Size(54, 24);
            this.edtZuverlaessigkeitBewertung.TabIndex = 35;
            // 
            // edtGesundheitPsychischBewertung
            // 
            this.edtGesundheitPsychischBewertung.AllowNull = false;
            this.edtGesundheitPsychischBewertung.DataMember = "GesundheitPsychischBewertung";
            this.edtGesundheitPsychischBewertung.DataSource = this.qrySIVermittlung;
            this.edtGesundheitPsychischBewertung.Location = new System.Drawing.Point(323, 222);
            this.edtGesundheitPsychischBewertung.Name = "edtGesundheitPsychischBewertung";
            this.edtGesundheitPsychischBewertung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGesundheitPsychischBewertung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGesundheitPsychischBewertung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGesundheitPsychischBewertung.Properties.Appearance.Options.UseBackColor = true;
            this.edtGesundheitPsychischBewertung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGesundheitPsychischBewertung.Properties.Appearance.Options.UseFont = true;
            this.edtGesundheitPsychischBewertung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtGesundheitPsychischBewertung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtGesundheitPsychischBewertung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtGesundheitPsychischBewertung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtGesundheitPsychischBewertung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtGesundheitPsychischBewertung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtGesundheitPsychischBewertung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGesundheitPsychischBewertung.Properties.NullText = "";
            this.edtGesundheitPsychischBewertung.Properties.ShowFooter = false;
            this.edtGesundheitPsychischBewertung.Properties.ShowHeader = false;
            this.edtGesundheitPsychischBewertung.Size = new System.Drawing.Size(54, 24);
            this.edtGesundheitPsychischBewertung.TabIndex = 19;
            // 
            // edtGesundheitKoerperlichBewertung
            // 
            this.edtGesundheitKoerperlichBewertung.AllowNull = false;
            this.edtGesundheitKoerperlichBewertung.DataMember = "GesundheitKoerperlichBewertung";
            this.edtGesundheitKoerperlichBewertung.DataSource = this.qrySIVermittlung;
            this.edtGesundheitKoerperlichBewertung.Location = new System.Drawing.Point(323, 192);
            this.edtGesundheitKoerperlichBewertung.Name = "edtGesundheitKoerperlichBewertung";
            this.edtGesundheitKoerperlichBewertung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGesundheitKoerperlichBewertung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGesundheitKoerperlichBewertung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGesundheitKoerperlichBewertung.Properties.Appearance.Options.UseBackColor = true;
            this.edtGesundheitKoerperlichBewertung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGesundheitKoerperlichBewertung.Properties.Appearance.Options.UseFont = true;
            this.edtGesundheitKoerperlichBewertung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtGesundheitKoerperlichBewertung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtGesundheitKoerperlichBewertung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtGesundheitKoerperlichBewertung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtGesundheitKoerperlichBewertung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtGesundheitKoerperlichBewertung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtGesundheitKoerperlichBewertung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGesundheitKoerperlichBewertung.Properties.NullText = "";
            this.edtGesundheitKoerperlichBewertung.Properties.ShowFooter = false;
            this.edtGesundheitKoerperlichBewertung.Properties.ShowHeader = false;
            this.edtGesundheitKoerperlichBewertung.Size = new System.Drawing.Size(54, 24);
            this.edtGesundheitKoerperlichBewertung.TabIndex = 16;
            // 
            // edtGesundheitBemerkung
            // 
            this.edtGesundheitBemerkung.DataMember = "GesundheitBemerkung";
            this.edtGesundheitBemerkung.DataSource = this.qrySIVermittlung;
            this.edtGesundheitBemerkung.Location = new System.Drawing.Point(137, 282);
            this.edtGesundheitBemerkung.Name = "edtGesundheitBemerkung";
            this.edtGesundheitBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGesundheitBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGesundheitBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGesundheitBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtGesundheitBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGesundheitBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtGesundheitBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGesundheitBemerkung.Size = new System.Drawing.Size(580, 88);
            this.edtGesundheitBemerkung.TabIndex = 27;
            // 
            // kissLookUpEdit1
            // 
            this.kissLookUpEdit1.DataMember = "VermittelbarkeitSICode";
            this.kissLookUpEdit1.DataSource = this.qrySIVermittlung;
            this.kissLookUpEdit1.Location = new System.Drawing.Point(137, 425);
            this.kissLookUpEdit1.LOVName = "KaVermittlungSiVermittelbarkeit";
            this.kissLookUpEdit1.Name = "kissLookUpEdit1";
            this.kissLookUpEdit1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.kissLookUpEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissLookUpEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissLookUpEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.kissLookUpEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.kissLookUpEdit1.Properties.Appearance.Options.UseFont = true;
            this.kissLookUpEdit1.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.kissLookUpEdit1.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissLookUpEdit1.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.kissLookUpEdit1.Properties.AppearanceDropDown.Options.UseFont = true;
            this.kissLookUpEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.kissLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.kissLookUpEdit1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.kissLookUpEdit1.Properties.NullText = "";
            this.kissLookUpEdit1.Properties.ShowFooter = false;
            this.kissLookUpEdit1.Properties.ShowHeader = false;
            this.kissLookUpEdit1.Size = new System.Drawing.Size(240, 24);
            this.kissLookUpEdit1.TabIndex = 32;
            // 
            // lblVermittelbarkeit
            // 
            this.lblVermittelbarkeit.Location = new System.Drawing.Point(10, 425);
            this.lblVermittelbarkeit.Name = "lblVermittelbarkeit";
            this.lblVermittelbarkeit.Size = new System.Drawing.Size(121, 24);
            this.lblVermittelbarkeit.TabIndex = 31;
            this.lblVermittelbarkeit.Text = "Vermittelbarkeit";
            this.lblVermittelbarkeit.UseCompatibleTextRendering = true;
            // 
            // edtInfoSDErfolgt
            // 
            this.edtInfoSDErfolgt.DataMember = "InfoAnSDErfolgt";
            this.edtInfoSDErfolgt.DataSource = this.qrySIVermittlung;
            this.edtInfoSDErfolgt.Location = new System.Drawing.Point(137, 577);
            this.edtInfoSDErfolgt.Name = "edtInfoSDErfolgt";
            this.edtInfoSDErfolgt.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtInfoSDErfolgt.Properties.Appearance.Options.UseBackColor = true;
            this.edtInfoSDErfolgt.Properties.Caption = "Info an SD erfolgt";
            this.edtInfoSDErfolgt.Size = new System.Drawing.Size(116, 19);
            this.edtInfoSDErfolgt.TabIndex = 43;
            // 
            // edtBemerkungen
            // 
            this.edtBemerkungen.DataMember = "Bemerkungen";
            this.edtBemerkungen.DataSource = this.qrySIVermittlung;
            this.edtBemerkungen.Location = new System.Drawing.Point(137, 485);
            this.edtBemerkungen.Name = "edtBemerkungen";
            this.edtBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkungen.Size = new System.Drawing.Size(580, 88);
            this.edtBemerkungen.TabIndex = 42;
            // 
            // lblBemerkungen
            // 
            this.lblBemerkungen.Location = new System.Drawing.Point(10, 485);
            this.lblBemerkungen.Name = "lblBemerkungen";
            this.lblBemerkungen.Size = new System.Drawing.Size(121, 24);
            this.lblBemerkungen.TabIndex = 41;
            this.lblBemerkungen.Text = "Bemerkungen";
            this.lblBemerkungen.UseCompatibleTextRendering = true;
            // 
            // edtKinderbetreuung
            // 
            this.edtKinderbetreuung.DataMember = "Kinderbetreuung";
            this.edtKinderbetreuung.DataSource = this.qrySIVermittlung;
            this.edtKinderbetreuung.Location = new System.Drawing.Point(477, 425);
            this.edtKinderbetreuung.LOVName = "KaVermittlungSIKinderbetreuung";
            this.edtKinderbetreuung.Name = "edtKinderbetreuung";
            this.edtKinderbetreuung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKinderbetreuung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKinderbetreuung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKinderbetreuung.Properties.Appearance.Options.UseBackColor = true;
            this.edtKinderbetreuung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKinderbetreuung.Properties.Appearance.Options.UseFont = true;
            this.edtKinderbetreuung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKinderbetreuung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKinderbetreuung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKinderbetreuung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKinderbetreuung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtKinderbetreuung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtKinderbetreuung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKinderbetreuung.Properties.NullText = "";
            this.edtKinderbetreuung.Properties.ShowFooter = false;
            this.edtKinderbetreuung.Properties.ShowHeader = false;
            this.edtKinderbetreuung.Size = new System.Drawing.Size(240, 24);
            this.edtKinderbetreuung.TabIndex = 40;
            // 
            // lblKinderbetreuungGeregelt
            // 
            this.lblKinderbetreuungGeregelt.Location = new System.Drawing.Point(386, 425);
            this.lblKinderbetreuungGeregelt.Name = "lblKinderbetreuungGeregelt";
            this.lblKinderbetreuungGeregelt.Size = new System.Drawing.Size(96, 24);
            this.lblKinderbetreuungGeregelt.TabIndex = 39;
            this.lblKinderbetreuungGeregelt.Text = "Kinderbetreuung";
            this.lblKinderbetreuungGeregelt.UseCompatibleTextRendering = true;
            // 
            // edtMotivation
            // 
            this.edtMotivation.DataMember = "MotivationBIBIPSICode";
            this.edtMotivation.DataSource = this.qrySIVermittlung;
            this.edtMotivation.Location = new System.Drawing.Point(477, 395);
            this.edtMotivation.LOVName = "JaNeinBedingt";
            this.edtMotivation.Name = "edtMotivation";
            this.edtMotivation.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMotivation.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMotivation.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMotivation.Properties.Appearance.Options.UseBackColor = true;
            this.edtMotivation.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMotivation.Properties.Appearance.Options.UseFont = true;
            this.edtMotivation.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtMotivation.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtMotivation.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtMotivation.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtMotivation.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtMotivation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtMotivation.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtMotivation.Properties.NullText = "";
            this.edtMotivation.Properties.ShowFooter = false;
            this.edtMotivation.Properties.ShowHeader = false;
            this.edtMotivation.Size = new System.Drawing.Size(180, 24);
            this.edtMotivation.TabIndex = 37;
            // 
            // lblMotivation
            // 
            this.lblMotivation.Location = new System.Drawing.Point(386, 395);
            this.lblMotivation.Name = "lblMotivation";
            this.lblMotivation.Size = new System.Drawing.Size(85, 24);
            this.lblMotivation.TabIndex = 36;
            this.lblMotivation.Text = "Motivation";
            this.lblMotivation.UseCompatibleTextRendering = true;
            // 
            // edtZuverlaessigkeit
            // 
            this.edtZuverlaessigkeit.DataMember = "ZuverlaessigkeitCode";
            this.edtZuverlaessigkeit.DataSource = this.qrySIVermittlung;
            this.edtZuverlaessigkeit.Location = new System.Drawing.Point(137, 455);
            this.edtZuverlaessigkeit.LOVName = "JaNeinBedingt";
            this.edtZuverlaessigkeit.Name = "edtZuverlaessigkeit";
            this.edtZuverlaessigkeit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZuverlaessigkeit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZuverlaessigkeit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZuverlaessigkeit.Properties.Appearance.Options.UseBackColor = true;
            this.edtZuverlaessigkeit.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZuverlaessigkeit.Properties.Appearance.Options.UseFont = true;
            this.edtZuverlaessigkeit.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtZuverlaessigkeit.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtZuverlaessigkeit.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtZuverlaessigkeit.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtZuverlaessigkeit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtZuverlaessigkeit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtZuverlaessigkeit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZuverlaessigkeit.Properties.NullText = "";
            this.edtZuverlaessigkeit.Properties.ShowFooter = false;
            this.edtZuverlaessigkeit.Properties.ShowHeader = false;
            this.edtZuverlaessigkeit.Size = new System.Drawing.Size(180, 24);
            this.edtZuverlaessigkeit.TabIndex = 34;
            // 
            // lblZuverlaessigkeit
            // 
            this.lblZuverlaessigkeit.Location = new System.Drawing.Point(10, 455);
            this.lblZuverlaessigkeit.Name = "lblZuverlaessigkeit";
            this.lblZuverlaessigkeit.Size = new System.Drawing.Size(121, 24);
            this.lblZuverlaessigkeit.TabIndex = 33;
            this.lblZuverlaessigkeit.Text = "Zuverlässigkeit";
            this.lblZuverlaessigkeit.UseCompatibleTextRendering = true;
            // 
            // edtAeussereErscheinung
            // 
            this.edtAeussereErscheinung.DataMember = "AeussereErscheinungCode";
            this.edtAeussereErscheinung.DataSource = this.qrySIVermittlung;
            this.edtAeussereErscheinung.Location = new System.Drawing.Point(137, 395);
            this.edtAeussereErscheinung.LOVName = "KaVermittlungSiAeussereErscheinung";
            this.edtAeussereErscheinung.Name = "edtAeussereErscheinung";
            this.edtAeussereErscheinung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAeussereErscheinung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAeussereErscheinung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAeussereErscheinung.Properties.Appearance.Options.UseBackColor = true;
            this.edtAeussereErscheinung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAeussereErscheinung.Properties.Appearance.Options.UseFont = true;
            this.edtAeussereErscheinung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAeussereErscheinung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAeussereErscheinung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAeussereErscheinung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAeussereErscheinung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtAeussereErscheinung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtAeussereErscheinung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAeussereErscheinung.Properties.NullText = "";
            this.edtAeussereErscheinung.Properties.ShowFooter = false;
            this.edtAeussereErscheinung.Properties.ShowHeader = false;
            this.edtAeussereErscheinung.Size = new System.Drawing.Size(240, 24);
            this.edtAeussereErscheinung.TabIndex = 30;
            // 
            // lblAeussereErscheinung
            // 
            this.lblAeussereErscheinung.Location = new System.Drawing.Point(10, 395);
            this.lblAeussereErscheinung.Name = "lblAeussereErscheinung";
            this.lblAeussereErscheinung.Size = new System.Drawing.Size(121, 24);
            this.lblAeussereErscheinung.TabIndex = 29;
            this.lblAeussereErscheinung.Text = "Äussere Erscheinung";
            this.lblAeussereErscheinung.UseCompatibleTextRendering = true;
            // 
            // lblDiverses
            // 
            this.lblDiverses.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblDiverses.Location = new System.Drawing.Point(10, 375);
            this.lblDiverses.Name = "lblDiverses";
            this.lblDiverses.Size = new System.Drawing.Size(100, 16);
            this.lblDiverses.TabIndex = 28;
            this.lblDiverses.Text = "Diverses";
            this.lblDiverses.UseCompatibleTextRendering = true;
            // 
            // edtSuchtart
            // 
            this.edtSuchtart.DataMember = "SuchtartCode";
            this.edtSuchtart.DataSource = this.qrySIVermittlung;
            this.edtSuchtart.Location = new System.Drawing.Point(477, 222);
            this.edtSuchtart.LOVName = "KaVermittlungSuchtart";
            this.edtSuchtart.Name = "edtSuchtart";
            this.edtSuchtart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSuchtart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSuchtart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSuchtart.Properties.Appearance.Options.UseBackColor = true;
            this.edtSuchtart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSuchtart.Properties.Appearance.Options.UseFont = true;
            this.edtSuchtart.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSuchtart.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSuchtart.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSuchtart.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSuchtart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtSuchtart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtSuchtart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSuchtart.Properties.NullText = "";
            this.edtSuchtart.Properties.ShowFooter = false;
            this.edtSuchtart.Properties.ShowHeader = false;
            this.edtSuchtart.Size = new System.Drawing.Size(240, 24);
            this.edtSuchtart.TabIndex = 25;
            // 
            // lblSuchtart
            // 
            this.lblSuchtart.Location = new System.Drawing.Point(386, 222);
            this.lblSuchtart.Name = "lblSuchtart";
            this.lblSuchtart.Size = new System.Drawing.Size(85, 24);
            this.lblSuchtart.TabIndex = 24;
            this.lblSuchtart.Text = "Suchtart";
            this.lblSuchtart.UseCompatibleTextRendering = true;
            // 
            // edtSucht
            // 
            this.edtSucht.DataMember = "SuchtCode";
            this.edtSucht.DataSource = this.qrySIVermittlung;
            this.edtSucht.Location = new System.Drawing.Point(477, 192);
            this.edtSucht.LOVName = "JaNeinUnklar";
            this.edtSucht.Name = "edtSucht";
            this.edtSucht.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucht.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucht.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucht.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucht.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucht.Properties.Appearance.Options.UseFont = true;
            this.edtSucht.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucht.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucht.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucht.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucht.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtSucht.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.edtSucht.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucht.Properties.NullText = "";
            this.edtSucht.Properties.ShowFooter = false;
            this.edtSucht.Properties.ShowHeader = false;
            this.edtSucht.Size = new System.Drawing.Size(68, 24);
            this.edtSucht.TabIndex = 23;
            // 
            // lblSucht
            // 
            this.lblSucht.Location = new System.Drawing.Point(385, 192);
            this.lblSucht.Name = "lblSucht";
            this.lblSucht.Size = new System.Drawing.Size(121, 24);
            this.lblSucht.TabIndex = 22;
            this.lblSucht.Text = "Sucht";
            this.lblSucht.UseCompatibleTextRendering = true;
            // 
            // edtTherapie
            // 
            this.edtTherapie.DataMember = "TherpieCode";
            this.edtTherapie.DataSource = this.qrySIVermittlung;
            this.edtTherapie.Location = new System.Drawing.Point(137, 252);
            this.edtTherapie.LOVName = "JaNein";
            this.edtTherapie.Name = "edtTherapie";
            this.edtTherapie.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTherapie.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTherapie.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTherapie.Properties.Appearance.Options.UseBackColor = true;
            this.edtTherapie.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTherapie.Properties.Appearance.Options.UseFont = true;
            this.edtTherapie.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtTherapie.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtTherapie.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtTherapie.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtTherapie.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.edtTherapie.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.edtTherapie.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTherapie.Properties.NullText = "";
            this.edtTherapie.Properties.ShowFooter = false;
            this.edtTherapie.Properties.ShowHeader = false;
            this.edtTherapie.Size = new System.Drawing.Size(240, 24);
            this.edtTherapie.TabIndex = 21;
            // 
            // lblinTherapie
            // 
            this.lblinTherapie.Location = new System.Drawing.Point(10, 250);
            this.lblinTherapie.Name = "lblinTherapie";
            this.lblinTherapie.Size = new System.Drawing.Size(108, 24);
            this.lblinTherapie.TabIndex = 20;
            this.lblinTherapie.Text = "Therapie";
            this.lblinTherapie.UseCompatibleTextRendering = true;
            // 
            // edtGesundheitPsychisch
            // 
            this.edtGesundheitPsychisch.DataMember = "GesundheitPsychischCode";
            this.edtGesundheitPsychisch.DataSource = this.qrySIVermittlung;
            this.edtGesundheitPsychisch.Location = new System.Drawing.Point(137, 222);
            this.edtGesundheitPsychisch.LOVName = "KaVermittlungSiGesundheit";
            this.edtGesundheitPsychisch.Name = "edtGesundheitPsychisch";
            this.edtGesundheitPsychisch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGesundheitPsychisch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGesundheitPsychisch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGesundheitPsychisch.Properties.Appearance.Options.UseBackColor = true;
            this.edtGesundheitPsychisch.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGesundheitPsychisch.Properties.Appearance.Options.UseFont = true;
            this.edtGesundheitPsychisch.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtGesundheitPsychisch.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtGesundheitPsychisch.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtGesundheitPsychisch.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtGesundheitPsychisch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject13.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject13.Options.UseBackColor = true;
            this.edtGesundheitPsychisch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13)});
            this.edtGesundheitPsychisch.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGesundheitPsychisch.Properties.NullText = "";
            this.edtGesundheitPsychisch.Properties.ShowFooter = false;
            this.edtGesundheitPsychisch.Properties.ShowHeader = false;
            this.edtGesundheitPsychisch.Size = new System.Drawing.Size(180, 24);
            this.edtGesundheitPsychisch.TabIndex = 18;
            // 
            // lblGesundheitpsychisch
            // 
            this.lblGesundheitpsychisch.Location = new System.Drawing.Point(10, 222);
            this.lblGesundheitpsychisch.Name = "lblGesundheitpsychisch";
            this.lblGesundheitpsychisch.Size = new System.Drawing.Size(121, 24);
            this.lblGesundheitpsychisch.TabIndex = 17;
            this.lblGesundheitpsychisch.Text = "psychisch";
            this.lblGesundheitpsychisch.UseCompatibleTextRendering = true;
            // 
            // lblGesundheitBemerkung
            // 
            this.lblGesundheitBemerkung.Location = new System.Drawing.Point(10, 282);
            this.lblGesundheitBemerkung.Name = "lblGesundheitBemerkung";
            this.lblGesundheitBemerkung.Size = new System.Drawing.Size(121, 24);
            this.lblGesundheitBemerkung.TabIndex = 26;
            this.lblGesundheitBemerkung.Text = "Bemerkungen";
            this.lblGesundheitBemerkung.UseCompatibleTextRendering = true;
            // 
            // edtGesundheitKoerperlich
            // 
            this.edtGesundheitKoerperlich.DataMember = "GesundheitKoerperlichCode";
            this.edtGesundheitKoerperlich.DataSource = this.qrySIVermittlung;
            this.edtGesundheitKoerperlich.Location = new System.Drawing.Point(137, 192);
            this.edtGesundheitKoerperlich.LOVName = "KaVermittlungSiGesundheit";
            this.edtGesundheitKoerperlich.Name = "edtGesundheitKoerperlich";
            this.edtGesundheitKoerperlich.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGesundheitKoerperlich.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGesundheitKoerperlich.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGesundheitKoerperlich.Properties.Appearance.Options.UseBackColor = true;
            this.edtGesundheitKoerperlich.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGesundheitKoerperlich.Properties.Appearance.Options.UseFont = true;
            this.edtGesundheitKoerperlich.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtGesundheitKoerperlich.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtGesundheitKoerperlich.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtGesundheitKoerperlich.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtGesundheitKoerperlich.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject14.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject14.Options.UseBackColor = true;
            this.edtGesundheitKoerperlich.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject14)});
            this.edtGesundheitKoerperlich.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGesundheitKoerperlich.Properties.NullText = "";
            this.edtGesundheitKoerperlich.Properties.ShowFooter = false;
            this.edtGesundheitKoerperlich.Properties.ShowHeader = false;
            this.edtGesundheitKoerperlich.Size = new System.Drawing.Size(180, 24);
            this.edtGesundheitKoerperlich.TabIndex = 15;
            // 
            // lblGesundheitkörperlich
            // 
            this.lblGesundheitkörperlich.Location = new System.Drawing.Point(10, 192);
            this.lblGesundheitkörperlich.Name = "lblGesundheitkörperlich";
            this.lblGesundheitkörperlich.Size = new System.Drawing.Size(121, 24);
            this.lblGesundheitkörperlich.TabIndex = 14;
            this.lblGesundheitkörperlich.Text = "körperlich";
            this.lblGesundheitkörperlich.UseCompatibleTextRendering = true;
            // 
            // lblGesundheit
            // 
            this.lblGesundheit.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblGesundheit.Location = new System.Drawing.Point(10, 173);
            this.lblGesundheit.Name = "lblGesundheit";
            this.lblGesundheit.Size = new System.Drawing.Size(100, 16);
            this.lblGesundheit.TabIndex = 13;
            this.lblGesundheit.Text = "Gesundheit";
            this.lblGesundheit.UseCompatibleTextRendering = true;
            // 
            // edtSprachstandermittlung
            // 
            this.edtSprachstandermittlung.DataMember = "Sprachstandermittlung";
            this.edtSprachstandermittlung.DataSource = this.qrySIVermittlung;
            this.edtSprachstandermittlung.Location = new System.Drawing.Point(137, 138);
            this.edtSprachstandermittlung.LOVName = "KaVermittlungSprachstandermittlung";
            this.edtSprachstandermittlung.Name = "edtSprachstandermittlung";
            this.edtSprachstandermittlung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSprachstandermittlung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSprachstandermittlung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSprachstandermittlung.Properties.Appearance.Options.UseBackColor = true;
            this.edtSprachstandermittlung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSprachstandermittlung.Properties.Appearance.Options.UseFont = true;
            this.edtSprachstandermittlung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSprachstandermittlung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSprachstandermittlung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSprachstandermittlung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSprachstandermittlung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject15.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject15.Options.UseBackColor = true;
            this.edtSprachstandermittlung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject15)});
            this.edtSprachstandermittlung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSprachstandermittlung.Properties.NullText = "";
            this.edtSprachstandermittlung.Properties.ShowFooter = false;
            this.edtSprachstandermittlung.Properties.ShowHeader = false;
            this.edtSprachstandermittlung.Size = new System.Drawing.Size(240, 24);
            this.edtSprachstandermittlung.TabIndex = 12;
            // 
            // lblResultatSprachstandermittlung
            // 
            this.lblResultatSprachstandermittlung.Location = new System.Drawing.Point(10, 138);
            this.lblResultatSprachstandermittlung.Name = "lblResultatSprachstandermittlung";
            this.lblResultatSprachstandermittlung.Size = new System.Drawing.Size(121, 24);
            this.lblResultatSprachstandermittlung.TabIndex = 11;
            this.lblResultatSprachstandermittlung.Text = "Sprachstandermittlung";
            this.lblResultatSprachstandermittlung.UseCompatibleTextRendering = true;
            // 
            // edtDeutschSchriftlich
            // 
            this.edtDeutschSchriftlich.DataMember = "DeutschSchriftlichCode";
            this.edtDeutschSchriftlich.DataSource = this.qrySIVermittlung;
            this.edtDeutschSchriftlich.Location = new System.Drawing.Point(137, 108);
            this.edtDeutschSchriftlich.LOVName = "KaDeutschkenntnisse";
            this.edtDeutschSchriftlich.Name = "edtDeutschSchriftlich";
            this.edtDeutschSchriftlich.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDeutschSchriftlich.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDeutschSchriftlich.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDeutschSchriftlich.Properties.Appearance.Options.UseBackColor = true;
            this.edtDeutschSchriftlich.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDeutschSchriftlich.Properties.Appearance.Options.UseFont = true;
            this.edtDeutschSchriftlich.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtDeutschSchriftlich.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtDeutschSchriftlich.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtDeutschSchriftlich.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtDeutschSchriftlich.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject16.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject16.Options.UseBackColor = true;
            this.edtDeutschSchriftlich.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject16)});
            this.edtDeutschSchriftlich.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDeutschSchriftlich.Properties.NullText = "";
            this.edtDeutschSchriftlich.Properties.ShowFooter = false;
            this.edtDeutschSchriftlich.Properties.ShowHeader = false;
            this.edtDeutschSchriftlich.Size = new System.Drawing.Size(240, 24);
            this.edtDeutschSchriftlich.TabIndex = 10;
            // 
            // lblschriftlich
            // 
            this.lblschriftlich.Location = new System.Drawing.Point(10, 108);
            this.lblschriftlich.Name = "lblschriftlich";
            this.lblschriftlich.Size = new System.Drawing.Size(121, 24);
            this.lblschriftlich.TabIndex = 9;
            this.lblschriftlich.Text = "schriftlich";
            this.lblschriftlich.UseCompatibleTextRendering = true;
            // 
            // edtAmTelefonVerstaendigen
            // 
            this.edtAmTelefonVerstaendigen.DataMember = "KannSichAmTelVerstaendigen";
            this.edtAmTelefonVerstaendigen.DataSource = this.qrySIVermittlung;
            this.edtAmTelefonVerstaendigen.Location = new System.Drawing.Point(389, 82);
            this.edtAmTelefonVerstaendigen.Name = "edtAmTelefonVerstaendigen";
            this.edtAmTelefonVerstaendigen.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtAmTelefonVerstaendigen.Properties.Appearance.Options.UseBackColor = true;
            this.edtAmTelefonVerstaendigen.Properties.Caption = "kann sich am Telefon verständigen";
            this.edtAmTelefonVerstaendigen.Size = new System.Drawing.Size(191, 19);
            this.edtAmTelefonVerstaendigen.TabIndex = 8;
            // 
            // edtDeutschMuendlich
            // 
            this.edtDeutschMuendlich.DataMember = "DeutschMuendlichCode";
            this.edtDeutschMuendlich.DataSource = this.qrySIVermittlung;
            this.edtDeutschMuendlich.Location = new System.Drawing.Point(137, 78);
            this.edtDeutschMuendlich.LOVName = "KaDeutschkenntnisse";
            this.edtDeutschMuendlich.Name = "edtDeutschMuendlich";
            this.edtDeutschMuendlich.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDeutschMuendlich.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDeutschMuendlich.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDeutschMuendlich.Properties.Appearance.Options.UseBackColor = true;
            this.edtDeutschMuendlich.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDeutschMuendlich.Properties.Appearance.Options.UseFont = true;
            this.edtDeutschMuendlich.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtDeutschMuendlich.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtDeutschMuendlich.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtDeutschMuendlich.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtDeutschMuendlich.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject17.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject17.Options.UseBackColor = true;
            this.edtDeutschMuendlich.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject17)});
            this.edtDeutschMuendlich.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDeutschMuendlich.Properties.NullText = "";
            this.edtDeutschMuendlich.Properties.ShowFooter = false;
            this.edtDeutschMuendlich.Properties.ShowHeader = false;
            this.edtDeutschMuendlich.Size = new System.Drawing.Size(240, 24);
            this.edtDeutschMuendlich.TabIndex = 7;
            // 
            // lblMuendlich
            // 
            this.lblMuendlich.Location = new System.Drawing.Point(10, 78);
            this.lblMuendlich.Name = "lblMuendlich";
            this.lblMuendlich.Size = new System.Drawing.Size(121, 24);
            this.lblMuendlich.TabIndex = 6;
            this.lblMuendlich.Text = "mündlich";
            this.lblMuendlich.UseCompatibleTextRendering = true;
            // 
            // lblVerstaendigungDeutsch
            // 
            this.lblVerstaendigungDeutsch.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblVerstaendigungDeutsch.Location = new System.Drawing.Point(10, 58);
            this.lblVerstaendigungDeutsch.Name = "lblVerstaendigungDeutsch";
            this.lblVerstaendigungDeutsch.Size = new System.Drawing.Size(160, 16);
            this.lblVerstaendigungDeutsch.TabIndex = 5;
            this.lblVerstaendigungDeutsch.Text = "Verständigung Deutsch";
            this.lblVerstaendigungDeutsch.UseCompatibleTextRendering = true;
            // 
            // edtGepraechsfuehrer
            // 
            this.edtGepraechsfuehrer.DataMember = "SIGespraechfuehrerin";
            this.edtGepraechsfuehrer.DataSource = this.qrySIVermittlung;
            this.edtGepraechsfuehrer.Location = new System.Drawing.Point(350, 22);
            this.edtGepraechsfuehrer.Name = "edtGepraechsfuehrer";
            this.edtGepraechsfuehrer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGepraechsfuehrer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGepraechsfuehrer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGepraechsfuehrer.Properties.Appearance.Options.UseBackColor = true;
            this.edtGepraechsfuehrer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGepraechsfuehrer.Properties.Appearance.Options.UseFont = true;
            this.edtGepraechsfuehrer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject18.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject18.Options.UseBackColor = true;
            this.edtGepraechsfuehrer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject18)});
            this.edtGepraechsfuehrer.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGepraechsfuehrer.Size = new System.Drawing.Size(307, 24);
            this.edtGepraechsfuehrer.TabIndex = 4;
            this.edtGepraechsfuehrer.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtGepraechsfuehrer_UserModifiedFld);
            // 
            // lblGesprächsfuehrerIn
            // 
            this.lblGesprächsfuehrerIn.Location = new System.Drawing.Point(238, 22);
            this.lblGesprächsfuehrerIn.Name = "lblGesprächsfuehrerIn";
            this.lblGesprächsfuehrerIn.Size = new System.Drawing.Size(106, 24);
            this.lblGesprächsfuehrerIn.TabIndex = 3;
            this.lblGesprächsfuehrerIn.Text = "GesprächsführerIn";
            this.lblGesprächsfuehrerIn.UseCompatibleTextRendering = true;
            // 
            // edtDatumGespraech
            // 
            this.edtDatumGespraech.DataMember = "SIGespraech";
            this.edtDatumGespraech.DataSource = this.qrySIVermittlung;
            this.edtDatumGespraech.EditValue = null;
            this.edtDatumGespraech.Location = new System.Drawing.Point(137, 22);
            this.edtDatumGespraech.Name = "edtDatumGespraech";
            this.edtDatumGespraech.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumGespraech.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumGespraech.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumGespraech.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumGespraech.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumGespraech.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumGespraech.Properties.Appearance.Options.UseFont = true;
            this.edtDatumGespraech.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject19.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject19.Options.UseBackColor = true;
            this.edtDatumGespraech.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumGespraech.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject19)});
            this.edtDatumGespraech.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumGespraech.Properties.ShowToday = false;
            this.edtDatumGespraech.Size = new System.Drawing.Size(90, 24);
            this.edtDatumGespraech.TabIndex = 2;
            // 
            // lblDatumGespräch
            // 
            this.lblDatumGespräch.Location = new System.Drawing.Point(10, 22);
            this.lblDatumGespräch.Name = "lblDatumGespräch";
            this.lblDatumGespräch.Size = new System.Drawing.Size(121, 24);
            this.lblDatumGespräch.TabIndex = 1;
            this.lblDatumGespräch.Text = "Datum";
            this.lblDatumGespräch.UseCompatibleTextRendering = true;
            // 
            // lblGespraech
            // 
            this.lblGespraech.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblGespraech.Location = new System.Drawing.Point(10, 5);
            this.lblGespraech.Name = "lblGespraech";
            this.lblGespraech.Size = new System.Drawing.Size(100, 16);
            this.lblGespraech.TabIndex = 0;
            this.lblGespraech.Text = "Gespräch";
            this.lblGespraech.UseCompatibleTextRendering = true;
            // 
            // tpgArbeitsgebiet
            // 
            this.tpgArbeitsgebiet.Controls.Add(this.edtIstAngemeldet);
            this.tpgArbeitsgebiet.Controls.Add(this.lblIstAngemeldet);
            this.tpgArbeitsgebiet.Controls.Add(this.edtBesondereWuensche);
            this.tpgArbeitsgebiet.Controls.Add(this.edtBesondereFaehigkeiten);
            this.tpgArbeitsgebiet.Controls.Add(this.grpEinsatzbereiche);
            this.tpgArbeitsgebiet.Controls.Add(this.grpKABetriebe);
            this.tpgArbeitsgebiet.Controls.Add(this.grpBranchen);
            this.tpgArbeitsgebiet.Controls.Add(this.lblBemerkungenArbeitsgebiet);
            this.tpgArbeitsgebiet.Controls.Add(this.lblArbeitszeiten);
            this.tpgArbeitsgebiet.Controls.Add(this.lblPCKenntnisse);
            this.tpgArbeitsgebiet.Controls.Add(this.lblKategorie);
            this.tpgArbeitsgebiet.Controls.Add(this.lblFührerausweis);
            this.tpgArbeitsgebiet.Controls.Add(this.lblBesondereFaehigkeiten);
            this.tpgArbeitsgebiet.Controls.Add(this.lblBesondereWuensche);
            this.tpgArbeitsgebiet.Controls.Add(this.lblProzent);
            this.tpgArbeitsgebiet.Controls.Add(this.lblBis);
            this.tpgArbeitsgebiet.Controls.Add(this.lblEinsatzpensumVon);
            this.tpgArbeitsgebiet.Controls.Add(this.btnEinsatzplatzSuchen);
            this.tpgArbeitsgebiet.Controls.Add(this.edtArbeitgebietBemerkungen);
            this.tpgArbeitsgebiet.Controls.Add(this.edtArbeitszeiten);
            this.tpgArbeitsgebiet.Controls.Add(this.edtPCKenntnisse);
            this.tpgArbeitsgebiet.Controls.Add(this.edtFuehrerausweisKategorie);
            this.tpgArbeitsgebiet.Controls.Add(this.edtFuehrerausweis);
            this.tpgArbeitsgebiet.Controls.Add(this.edtPensumBis);
            this.tpgArbeitsgebiet.Controls.Add(this.edtPensumVon);
            this.tpgArbeitsgebiet.Location = new System.Drawing.Point(6, 32);
            this.tpgArbeitsgebiet.Name = "tpgArbeitsgebiet";
            this.tpgArbeitsgebiet.Size = new System.Drawing.Size(728, 612);
            this.tpgArbeitsgebiet.TabIndex = 0;
            this.tpgArbeitsgebiet.Title = "Arbeitsgebiet";
            // 
            // edtIstAngemeldet
            // 
            this.edtIstAngemeldet.DataMember = "IstAngemeldet";
            this.edtIstAngemeldet.DataSource = this.qrySIVermittlung;
            this.edtIstAngemeldet.Location = new System.Drawing.Point(130, 333);
            this.edtIstAngemeldet.Name = "edtIstAngemeldet";
            this.edtIstAngemeldet.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtIstAngemeldet.Properties.Appearance.Options.UseBackColor = true;
            this.edtIstAngemeldet.Properties.Caption = "Für andere berufliche, gesundheitliche oder soziale Integrationsmassnahmen- und/o" +
                "der Abklärungen angemeldet";
            this.edtIstAngemeldet.Size = new System.Drawing.Size(594, 19);
            this.edtIstAngemeldet.TabIndex = 12;
            // 
            // lblIstAngemeldet
            // 
            this.lblIstAngemeldet.Location = new System.Drawing.Point(150, 344);
            this.lblIstAngemeldet.Name = "lblIstAngemeldet";
            this.lblIstAngemeldet.Size = new System.Drawing.Size(574, 24);
            this.lblIstAngemeldet.TabIndex = 13;
            this.lblIstAngemeldet.Text = " – IV, etcetera, Taglöhnerprojekt, Freiwilligenarbeit, etc. (siehe auch Bemerkung" +
                "en)";
            // 
            // edtBesondereWuensche
            // 
            this.edtBesondereWuensche.DataMember = "BesondereWuensche";
            this.edtBesondereWuensche.DataSource = this.qrySIVermittlung;
            this.edtBesondereWuensche.Location = new System.Drawing.Point(130, 161);
            this.edtBesondereWuensche.Name = "edtBesondereWuensche";
            this.edtBesondereWuensche.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBesondereWuensche.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBesondereWuensche.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBesondereWuensche.Properties.Appearance.Options.UseBackColor = true;
            this.edtBesondereWuensche.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBesondereWuensche.Properties.Appearance.Options.UseFont = true;
            this.edtBesondereWuensche.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBesondereWuensche.Size = new System.Drawing.Size(594, 80);
            this.edtBesondereWuensche.TabIndex = 9;
            // 
            // edtBesondereFaehigkeiten
            // 
            this.edtBesondereFaehigkeiten.DataMember = "BesondereFaehigkeiten";
            this.edtBesondereFaehigkeiten.DataSource = this.qrySIVermittlung;
            this.edtBesondereFaehigkeiten.Location = new System.Drawing.Point(130, 247);
            this.edtBesondereFaehigkeiten.Name = "edtBesondereFaehigkeiten";
            this.edtBesondereFaehigkeiten.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBesondereFaehigkeiten.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBesondereFaehigkeiten.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBesondereFaehigkeiten.Properties.Appearance.Options.UseBackColor = true;
            this.edtBesondereFaehigkeiten.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBesondereFaehigkeiten.Properties.Appearance.Options.UseFont = true;
            this.edtBesondereFaehigkeiten.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBesondereFaehigkeiten.Size = new System.Drawing.Size(594, 80);
            this.edtBesondereFaehigkeiten.TabIndex = 11;
            // 
            // grpEinsatzbereiche
            // 
            this.grpEinsatzbereiche.Controls.Add(this.edtEinsatzbereich);
            this.grpEinsatzbereiche.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpEinsatzbereiche.Location = new System.Drawing.Point(601, 43);
            this.grpEinsatzbereiche.Name = "grpEinsatzbereiche";
            this.grpEinsatzbereiche.Size = new System.Drawing.Size(123, 112);
            this.grpEinsatzbereiche.TabIndex = 7;
            this.grpEinsatzbereiche.TabStop = false;
            this.grpEinsatzbereiche.Text = "Einsatzbereiche";
            // 
            // edtEinsatzbereich
            // 
            this.edtEinsatzbereich.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtEinsatzbereich.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.edtEinsatzbereich.Appearance.Options.UseBackColor = true;
            this.edtEinsatzbereich.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtEinsatzbereich.CheckOnClick = true;
            this.edtEinsatzbereich.DataMember = "EinsatzbereichCodes";
            this.edtEinsatzbereich.DataSource = this.qrySIVermittlung;
            this.edtEinsatzbereich.Location = new System.Drawing.Point(6, 20);
            this.edtEinsatzbereich.LOVName = "KaVermittlungEinsatzbereich";
            this.edtEinsatzbereich.Name = "edtEinsatzbereich";
            this.edtEinsatzbereich.Size = new System.Drawing.Size(111, 86);
            this.edtEinsatzbereich.TabIndex = 0;
            // 
            // grpKABetriebe
            // 
            this.grpKABetriebe.Controls.Add(this.edtKaBetriebe);
            this.grpKABetriebe.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpKABetriebe.Location = new System.Drawing.Point(435, 43);
            this.grpKABetriebe.Name = "grpKABetriebe";
            this.grpKABetriebe.Size = new System.Drawing.Size(160, 112);
            this.grpKABetriebe.TabIndex = 6;
            this.grpKABetriebe.TabStop = false;
            this.grpKABetriebe.Text = "KA-Betriebe";
            // 
            // edtKaBetriebe
            // 
            this.edtKaBetriebe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKaBetriebe.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.edtKaBetriebe.Appearance.Options.UseBackColor = true;
            this.edtKaBetriebe.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtKaBetriebe.CheckOnClick = true;
            this.edtKaBetriebe.DataMember = "KaBetriebCodes";
            this.edtKaBetriebe.DataSource = this.qrySIVermittlung;
            this.edtKaBetriebe.Location = new System.Drawing.Point(6, 20);
            this.edtKaBetriebe.LOVName = "KaVermittlungKaBetriebe";
            this.edtKaBetriebe.Name = "edtKaBetriebe";
            this.edtKaBetriebe.Size = new System.Drawing.Size(148, 86);
            this.edtKaBetriebe.TabIndex = 0;
            // 
            // grpBranchen
            // 
            this.grpBranchen.Controls.Add(this.edtBranchen);
            this.grpBranchen.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpBranchen.Location = new System.Drawing.Point(9, 43);
            this.grpBranchen.Name = "grpBranchen";
            this.grpBranchen.Size = new System.Drawing.Size(420, 112);
            this.grpBranchen.TabIndex = 5;
            this.grpBranchen.TabStop = false;
            this.grpBranchen.Text = "Branchen";
            // 
            // edtBranchen
            // 
            this.edtBranchen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBranchen.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.edtBranchen.Appearance.Options.UseBackColor = true;
            this.edtBranchen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtBranchen.CheckOnClick = true;
            this.edtBranchen.DataMember = "BrancheCodes";
            this.edtBranchen.DataSource = this.qrySIVermittlung;
            this.edtBranchen.Location = new System.Drawing.Point(9, 20);
            this.edtBranchen.LOVName = "KaBranche";
            this.edtBranchen.MultiColumn = true;
            this.edtBranchen.Name = "edtBranchen";
            this.edtBranchen.Size = new System.Drawing.Size(405, 86);
            this.edtBranchen.TabIndex = 0;
            // 
            // lblBemerkungenArbeitsgebiet
            // 
            this.lblBemerkungenArbeitsgebiet.Location = new System.Drawing.Point(9, 491);
            this.lblBemerkungenArbeitsgebiet.Name = "lblBemerkungenArbeitsgebiet";
            this.lblBemerkungenArbeitsgebiet.Size = new System.Drawing.Size(80, 24);
            this.lblBemerkungenArbeitsgebiet.TabIndex = 22;
            this.lblBemerkungenArbeitsgebiet.Text = "Bemerkungen";
            this.lblBemerkungenArbeitsgebiet.UseCompatibleTextRendering = true;
            // 
            // lblArbeitszeiten
            // 
            this.lblArbeitszeiten.Location = new System.Drawing.Point(9, 431);
            this.lblArbeitszeiten.Name = "lblArbeitszeiten";
            this.lblArbeitszeiten.Size = new System.Drawing.Size(80, 24);
            this.lblArbeitszeiten.TabIndex = 20;
            this.lblArbeitszeiten.Text = "Arbeitszeiten";
            this.lblArbeitszeiten.UseCompatibleTextRendering = true;
            // 
            // lblPCKenntnisse
            // 
            this.lblPCKenntnisse.Location = new System.Drawing.Point(9, 401);
            this.lblPCKenntnisse.Name = "lblPCKenntnisse";
            this.lblPCKenntnisse.Size = new System.Drawing.Size(80, 24);
            this.lblPCKenntnisse.TabIndex = 18;
            this.lblPCKenntnisse.Text = "PC-Kenntnisse";
            this.lblPCKenntnisse.UseCompatibleTextRendering = true;
            // 
            // lblKategorie
            // 
            this.lblKategorie.Location = new System.Drawing.Point(208, 371);
            this.lblKategorie.Name = "lblKategorie";
            this.lblKategorie.Size = new System.Drawing.Size(58, 24);
            this.lblKategorie.TabIndex = 16;
            this.lblKategorie.Text = "Kategorie";
            this.lblKategorie.UseCompatibleTextRendering = true;
            // 
            // lblFührerausweis
            // 
            this.lblFührerausweis.Location = new System.Drawing.Point(9, 370);
            this.lblFührerausweis.Name = "lblFührerausweis";
            this.lblFührerausweis.Size = new System.Drawing.Size(80, 24);
            this.lblFührerausweis.TabIndex = 14;
            this.lblFührerausweis.Text = "Führerausweis";
            this.lblFührerausweis.UseCompatibleTextRendering = true;
            // 
            // lblBesondereFaehigkeiten
            // 
            this.lblBesondereFaehigkeiten.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblBesondereFaehigkeiten.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblBesondereFaehigkeiten.Location = new System.Drawing.Point(9, 247);
            this.lblBesondereFaehigkeiten.Name = "lblBesondereFaehigkeiten";
            this.lblBesondereFaehigkeiten.Size = new System.Drawing.Size(115, 35);
            this.lblBesondereFaehigkeiten.TabIndex = 10;
            this.lblBesondereFaehigkeiten.Text = "Besondere Fähigkeiten";
            this.lblBesondereFaehigkeiten.UseCompatibleTextRendering = true;
            // 
            // lblBesondereWuensche
            // 
            this.lblBesondereWuensche.Location = new System.Drawing.Point(9, 161);
            this.lblBesondereWuensche.Name = "lblBesondereWuensche";
            this.lblBesondereWuensche.Size = new System.Drawing.Size(115, 24);
            this.lblBesondereWuensche.TabIndex = 8;
            this.lblBesondereWuensche.Text = "Besondere Wünsche";
            this.lblBesondereWuensche.UseCompatibleTextRendering = true;
            // 
            // lblProzent
            // 
            this.lblProzent.Location = new System.Drawing.Point(268, 12);
            this.lblProzent.Name = "lblProzent";
            this.lblProzent.Size = new System.Drawing.Size(13, 24);
            this.lblProzent.TabIndex = 4;
            this.lblProzent.Text = "%";
            this.lblProzent.UseCompatibleTextRendering = true;
            // 
            // lblBis
            // 
            this.lblBis.Location = new System.Drawing.Point(174, 13);
            this.lblBis.Name = "lblBis";
            this.lblBis.Size = new System.Drawing.Size(40, 24);
            this.lblBis.TabIndex = 2;
            this.lblBis.Text = "%    bis";
            this.lblBis.UseCompatibleTextRendering = true;
            // 
            // lblEinsatzpensumVon
            // 
            this.lblEinsatzpensumVon.Location = new System.Drawing.Point(9, 13);
            this.lblEinsatzpensumVon.Name = "lblEinsatzpensumVon";
            this.lblEinsatzpensumVon.Size = new System.Drawing.Size(115, 24);
            this.lblEinsatzpensumVon.TabIndex = 0;
            this.lblEinsatzpensumVon.Text = "Einsatzpensum von";
            this.lblEinsatzpensumVon.UseCompatibleTextRendering = true;
            // 
            // btnEinsatzplatzSuchen
            // 
            this.btnEinsatzplatzSuchen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEinsatzplatzSuchen.Location = new System.Drawing.Point(130, 580);
            this.btnEinsatzplatzSuchen.Name = "btnEinsatzplatzSuchen";
            this.btnEinsatzplatzSuchen.Size = new System.Drawing.Size(140, 24);
            this.btnEinsatzplatzSuchen.TabIndex = 24;
            this.btnEinsatzplatzSuchen.Text = "Einsatzplatz suchen";
            this.btnEinsatzplatzSuchen.UseCompatibleTextRendering = true;
            this.btnEinsatzplatzSuchen.UseVisualStyleBackColor = false;
            this.btnEinsatzplatzSuchen.Click += new System.EventHandler(this.btnEinsatzplatzSuchen_Click);
            // 
            // edtArbeitgebietBemerkungen
            // 
            this.edtArbeitgebietBemerkungen.DataMember = "ArbeitsgebietBemerkungen";
            this.edtArbeitgebietBemerkungen.DataSource = this.qrySIVermittlung;
            this.edtArbeitgebietBemerkungen.Location = new System.Drawing.Point(130, 494);
            this.edtArbeitgebietBemerkungen.Name = "edtArbeitgebietBemerkungen";
            this.edtArbeitgebietBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtArbeitgebietBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtArbeitgebietBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtArbeitgebietBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtArbeitgebietBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtArbeitgebietBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.edtArbeitgebietBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtArbeitgebietBemerkungen.Size = new System.Drawing.Size(594, 80);
            this.edtArbeitgebietBemerkungen.TabIndex = 23;
            // 
            // edtArbeitszeiten
            // 
            this.edtArbeitszeiten.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.edtArbeitszeiten.Appearance.Options.UseBackColor = true;
            this.edtArbeitszeiten.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtArbeitszeiten.CheckOnClick = true;
            this.edtArbeitszeiten.DataMember = "ArbeitszeitenCodes";
            this.edtArbeitszeiten.DataSource = this.qrySIVermittlung;
            this.edtArbeitszeiten.Location = new System.Drawing.Point(130, 431);
            this.edtArbeitszeiten.LOVName = "KaVermittlungSiArbeitszeit";
            this.edtArbeitszeiten.MultiColumn = true;
            this.edtArbeitszeiten.Name = "edtArbeitszeiten";
            this.edtArbeitszeiten.Size = new System.Drawing.Size(236, 57);
            this.edtArbeitszeiten.TabIndex = 21;
            // 
            // edtPCKenntnisse
            // 
            this.edtPCKenntnisse.DataMember = "PCKenntnisseCode";
            this.edtPCKenntnisse.DataSource = this.qrySIVermittlung;
            this.edtPCKenntnisse.Location = new System.Drawing.Point(130, 401);
            this.edtPCKenntnisse.LOVName = "JaNein";
            this.edtPCKenntnisse.Name = "edtPCKenntnisse";
            this.edtPCKenntnisse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPCKenntnisse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPCKenntnisse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPCKenntnisse.Properties.Appearance.Options.UseBackColor = true;
            this.edtPCKenntnisse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPCKenntnisse.Properties.Appearance.Options.UseFont = true;
            this.edtPCKenntnisse.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtPCKenntnisse.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtPCKenntnisse.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtPCKenntnisse.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtPCKenntnisse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject20.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject20.Options.UseBackColor = true;
            this.edtPCKenntnisse.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject20)});
            this.edtPCKenntnisse.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPCKenntnisse.Properties.NullText = "";
            this.edtPCKenntnisse.Properties.ShowFooter = false;
            this.edtPCKenntnisse.Properties.ShowHeader = false;
            this.edtPCKenntnisse.Size = new System.Drawing.Size(60, 24);
            this.edtPCKenntnisse.TabIndex = 19;
            // 
            // edtFuehrerausweisKategorie
            // 
            this.edtFuehrerausweisKategorie.DataMember = "FuehrerausweisKategorieCode";
            this.edtFuehrerausweisKategorie.DataSource = this.qrySIVermittlung;
            this.edtFuehrerausweisKategorie.Location = new System.Drawing.Point(272, 370);
            this.edtFuehrerausweisKategorie.LOVFilter = "706";
            this.edtFuehrerausweisKategorie.LOVName = "KaFuehrerausweisKategorie";
            this.edtFuehrerausweisKategorie.Name = "edtFuehrerausweisKategorie";
            this.edtFuehrerausweisKategorie.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFuehrerausweisKategorie.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFuehrerausweisKategorie.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFuehrerausweisKategorie.Properties.Appearance.Options.UseBackColor = true;
            this.edtFuehrerausweisKategorie.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFuehrerausweisKategorie.Properties.Appearance.Options.UseFont = true;
            this.edtFuehrerausweisKategorie.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtFuehrerausweisKategorie.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtFuehrerausweisKategorie.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtFuehrerausweisKategorie.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtFuehrerausweisKategorie.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject21.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject21.Options.UseBackColor = true;
            this.edtFuehrerausweisKategorie.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject21)});
            this.edtFuehrerausweisKategorie.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFuehrerausweisKategorie.Properties.NullText = "";
            this.edtFuehrerausweisKategorie.Properties.ShowFooter = false;
            this.edtFuehrerausweisKategorie.Properties.ShowHeader = false;
            this.edtFuehrerausweisKategorie.Size = new System.Drawing.Size(221, 24);
            this.edtFuehrerausweisKategorie.TabIndex = 17;
            // 
            // edtFuehrerausweis
            // 
            this.edtFuehrerausweis.DataMember = "FuehrerausweisCode";
            this.edtFuehrerausweis.DataSource = this.qrySIVermittlung;
            this.edtFuehrerausweis.Location = new System.Drawing.Point(130, 371);
            this.edtFuehrerausweis.LOVName = "JaNein";
            this.edtFuehrerausweis.Name = "edtFuehrerausweis";
            this.edtFuehrerausweis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFuehrerausweis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFuehrerausweis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFuehrerausweis.Properties.Appearance.Options.UseBackColor = true;
            this.edtFuehrerausweis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFuehrerausweis.Properties.Appearance.Options.UseFont = true;
            this.edtFuehrerausweis.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtFuehrerausweis.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtFuehrerausweis.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtFuehrerausweis.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtFuehrerausweis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject22.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject22.Options.UseBackColor = true;
            this.edtFuehrerausweis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject22)});
            this.edtFuehrerausweis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFuehrerausweis.Properties.NullText = "";
            this.edtFuehrerausweis.Properties.ShowFooter = false;
            this.edtFuehrerausweis.Properties.ShowHeader = false;
            this.edtFuehrerausweis.Size = new System.Drawing.Size(60, 24);
            this.edtFuehrerausweis.TabIndex = 15;
            // 
            // edtPensumBis
            // 
            this.edtPensumBis.DataMember = "EinsatzpensumBis";
            this.edtPensumBis.DataSource = this.qrySIVermittlung;
            this.edtPensumBis.Location = new System.Drawing.Point(223, 13);
            this.edtPensumBis.Name = "edtPensumBis";
            this.edtPensumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtPensumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPensumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPensumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPensumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtPensumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPensumBis.Properties.Appearance.Options.UseFont = true;
            this.edtPensumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPensumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPensumBis.Size = new System.Drawing.Size(40, 24);
            this.edtPensumBis.TabIndex = 3;
            this.edtPensumBis.Leave += new System.EventHandler(this.CheckPensum);
            // 
            // edtPensumVon
            // 
            this.edtPensumVon.DataMember = "EinsatzpensumVon";
            this.edtPensumVon.DataSource = this.qrySIVermittlung;
            this.edtPensumVon.Location = new System.Drawing.Point(130, 13);
            this.edtPensumVon.Name = "edtPensumVon";
            this.edtPensumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtPensumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPensumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPensumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPensumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtPensumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPensumVon.Properties.Appearance.Options.UseFont = true;
            this.edtPensumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPensumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPensumVon.Size = new System.Drawing.Size(40, 24);
            this.edtPensumVon.TabIndex = 1;
            this.edtPensumVon.Leave += new System.EventHandler(this.CheckPensum);
            // 
            // CtlKaVermittlungSIVermittlungsprofil
            // 
            this.ActiveSQLQuery = this.qrySIVermittlung;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(740, 690);
            this.Controls.Add(this.tabVermittlungsprofil);
            this.Controls.Add(this.pnTitle);
            this.Name = "CtlKaVermittlungSIVermittlungsprofil";
            this.Size = new System.Drawing.Size(740, 690);
            this.Load += new System.EventHandler(this.CtlKaVermittlungSIVermittlungsprofil_Load);
            this.pnTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            this.tabVermittlungsprofil.ResumeLayout(false);
            this.tpgPersoenlichesProfil.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtModivationBewertung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModivationBewertung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrySIVermittlung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZuverlaessigkeitBewertung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZuverlaessigkeitBewertung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGesundheitPsychischBewertung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGesundheitPsychischBewertung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGesundheitKoerperlichBewertung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGesundheitKoerperlichBewertung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGesundheitBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVermittelbarkeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInfoSDErfolgt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKinderbetreuung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKinderbetreuung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKinderbetreuungGeregelt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMotivation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMotivation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMotivation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZuverlaessigkeit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZuverlaessigkeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZuverlaessigkeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAeussereErscheinung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAeussereErscheinung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAeussereErscheinung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDiverses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchtart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchtart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchtart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucht.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTherapie.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTherapie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblinTherapie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGesundheitPsychisch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGesundheitPsychisch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGesundheitpsychisch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGesundheitBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGesundheitKoerperlich.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGesundheitKoerperlich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGesundheitkörperlich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGesundheit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSprachstandermittlung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSprachstandermittlung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblResultatSprachstandermittlung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDeutschSchriftlich.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDeutschSchriftlich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblschriftlich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAmTelefonVerstaendigen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDeutschMuendlich.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDeutschMuendlich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMuendlich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerstaendigungDeutsch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGepraechsfuehrer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGesprächsfuehrerIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumGespraech.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumGespräch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGespraech)).EndInit();
            this.tpgArbeitsgebiet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtIstAngemeldet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIstAngemeldet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBesondereWuensche.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBesondereFaehigkeiten.Properties)).EndInit();
            this.grpEinsatzbereiche.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzbereich)).EndInit();
            this.grpKABetriebe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtKaBetriebe)).EndInit();
            this.grpBranchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtBranchen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungenArbeitsgebiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblArbeitszeiten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPCKenntnisse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKategorie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFührerausweis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBesondereFaehigkeiten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBesondereWuensche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProzent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzpensumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtArbeitgebietBemerkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtArbeitszeiten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPCKenntnisse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPCKenntnisse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFuehrerausweisKategorie.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFuehrerausweisKategorie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFuehrerausweis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFuehrerausweis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPensumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPensumVon.Properties)).EndInit();
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

        private Gui.KissMemoEdit edtGesundheitBemerkung;
        private Gui.KissLookUpEdit edtZuverlaessigkeitBewertung;
        private Gui.KissLookUpEdit edtGesundheitPsychischBewertung;
        private Gui.KissLookUpEdit edtGesundheitKoerperlichBewertung;
        private Gui.KissLookUpEdit edtModivationBewertung;
        private Gui.KissGroupBox grpBranchen;
        private Gui.KissGroupBox grpEinsatzbereiche;
        private Gui.KissGroupBox grpKABetriebe;
        private Gui.KissMemoEdit edtBesondereWuensche;
        private Gui.KissMemoEdit edtBesondereFaehigkeiten;
        private Gui.KissCheckEdit edtIstAngemeldet;
        private Gui.KissLabel lblIstAngemeldet;
    }
}