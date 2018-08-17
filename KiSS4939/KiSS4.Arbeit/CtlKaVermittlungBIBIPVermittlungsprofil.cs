using System;
using System.Drawing;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    public class CtlKaVermittlungBIBIPVermittlungsprofil : KiSS4.Gui.KissUserControl
    {
        #region Fields

        #region Private Fields

        private int baPersonID = -1;
        private KiSS4.Gui.KissButton btnEinsatzplatzSuchen;
        private KiSS4.Dokument.KissDocumentButton btnVermittlungsgespraech;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissLookUpEdit edtAeussereErscheinung;
        private KissTextEdit edtAktuelleTaetigkeit;
        private KiSS4.Gui.KissCheckEdit edtAmTelefonVerstaendigen;
        private KiSS4.Gui.KissMemoEdit edtArbeitgebietBemerkungen;
        private KiSS4.Gui.KissLookUpEdit edtAusbildung;
        private KiSS4.Gui.KissMemoEdit edtBemerkungen;
        private KiSS4.Gui.KissTextEdit edtBesondereWuensche;
        private KiSS4.Gui.KissCheckedLookupEdit edtBranchen;
        private KiSS4.Gui.KissLookUpEdit edtDeutschMuendlich;
        private KiSS4.Gui.KissLookUpEdit edtDeutschSchriftlich;
        private KissMemoEdit edtEinschraenkungDI;
        private KissMemoEdit edtEinschraenkungDO;
        private KiSS4.Gui.KissTextEdit edtEinschraenkungen;
        private KissMemoEdit edtEinschraenkungFR;
        private KissMemoEdit edtEinschraenkungMI;
        private KissMemoEdit edtEinschraenkungMO;
        private KissMemoEdit edtEinschraenkungSA;
        private KissMemoEdit edtEinschraenkungSO;
        private KissLookUpEdit edtFuehrerausweis;
        private KiSS4.Gui.KissLookUpEdit edtGesundheitKoerperlich;
        private KiSS4.Gui.KissCheckedLookupEdit edtKaBetriebe;
        private KissLookUpEdit edtKaLaufendeBetreibungen;
        private KissLookUpEdit edtKaLohnabtretungSD;
        private KissLookUpEdit edtKaNachtarbeitCode;
        private KissLookUpEdit edtKaSchweizerdeutsch;
        private KissLookUpEdit edtKaVerfuegbarkeit;
        private KiSS4.Gui.KissLookUpEdit edtMotivation;
        private KissLookUpEdit edtPCKenntnisse;
        private KiSS4.Gui.KissCalcEdit edtPensum;
        private KiSS4.Gui.KissLookUpEdit edtSucht;
        private KiSS4.Gui.KissLookUpEdit edtSuchtart;
        private KiSS4.Gui.KissLookUpEdit edtVermittelbarkeit;
        private KiSS4.Gui.KissTextEdit edtVermittelbarkeitDetails;
        private KiSS4.Gui.KissLookUpEdit edtZuverlaessigkeit;
        private int faLeistungID = -1;
        private System.Windows.Forms.PictureBox imageTitle;
        private KiSS4.Gui.KissLabel lbDetails;
        private KissLabel lbEinschraenkungMI;
        private KissLabel lbEinschraenkungMO;
        private KissLabel lblAktuelleTaetigkeit;
        private KiSS4.Gui.KissLabel lblAusbildung;
        private KiSS4.Gui.KissLabel lbläussereErscheinung;
        private KiSS4.Gui.KissLabel lblBemerkungen;
        private KiSS4.Gui.KissLabel lblBemerkungen1;
        private KiSS4.Gui.KissLabel lblbesondereWünsche;
        private KiSS4.Gui.KissLabel lblBranche;
        private KiSS4.Gui.KissLabel lblDiverses;
        private KiSS4.Gui.KissLabel lblEinsatzpensum;
        private KissLabel lblEinschraenkungDI;
        private KissLabel lblEinschraenkungDO;
        private KissLabel lblEinschraenkungFR;
        private KissLabel lblEinschraenkungSA;
        private KissLabel lblEinschraenkungSO;
        private KiSS4.Gui.KissLabel lblEinschränkungen;
        private KissLabel lblFuehrerausweis;
        private KiSS4.Gui.KissLabel lblGesundheit;
        private KiSS4.Gui.KissLabel lblKABetriebe;
        private KissLabel lblKaLohnabtretungSD;
        private KissLabel lblKaNachtarbeit;
        private KissLabel lblKaSchweizerdeutsch;
        private KissLabel lblLaufendeBetreibungen;
        private KiSS4.Gui.KissLabel lblMotivation;
        private KiSS4.Gui.KissLabel lblmündlich;
        private KissLabel lblPCKenntnisse;
        private KiSS4.Gui.KissLabel lblProzent;
        private KiSS4.Gui.KissLabel lblschriftlich;
        private KiSS4.Gui.KissLabel lblSucht;
        private KiSS4.Gui.KissLabel lblSuchtart;
        private KiSS4.Gui.KissLabel lblTitelGesundheit;
        private KiSS4.Gui.KissLabel lblTitelVermittelbarkeit;
        private KiSS4.Gui.KissLabel lblTitle;
        private KissLabel lblVerfuegbarkeit;
        private KiSS4.Gui.KissLabel lblVermittelbarkeit;
        private KiSS4.Gui.KissLabel lblVerständigungDeutsch;
        private KiSS4.Gui.KissLabel lblZuverlässigkeit;
        private bool MayClose = false;
        private bool MayDel = false;
        private bool MayIns = false;
        private bool MayRead = false;
        private bool MayReopen = false;
        private bool MayUpd = false;
        private System.Windows.Forms.TableLayoutPanel panVerfuegbarkeit;
        private System.Windows.Forms.Panel pnTitle;
        private KiSS4.DB.SqlQuery qryBIBIPVermittlung;
        private KiSS4.Gui.KissTabControlEx tabVermittlungsprofil;
        private SharpLibrary.WinControls.TabPageEx tpgArbeitsgebiet;
        private KissLookUpEdit edtDummy;
        private SharpLibrary.WinControls.TabPageEx tpgPersoenlichesProfil;

        #endregion

        #endregion

        #region Constructors

        public CtlKaVermittlungBIBIPVermittlungsprofil()
        {
            this.InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKaVermittlungBIBIPVermittlungsprofil));
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
            this.pnTitle = new System.Windows.Forms.Panel();
            this.imageTitle = new System.Windows.Forms.PictureBox();
            this.btnVermittlungsgespraech = new KiSS4.Dokument.KissDocumentButton();
            this.lblTitle = new KiSS4.Gui.KissLabel();
            this.tabVermittlungsprofil = new KiSS4.Gui.KissTabControlEx();
            this.tpgPersoenlichesProfil = new SharpLibrary.WinControls.TabPageEx();
            this.edtDummy = new KiSS4.Gui.KissLookUpEdit();
            this.edtPCKenntnisse = new KiSS4.Gui.KissLookUpEdit();
            this.qryBIBIPVermittlung = new KiSS4.DB.SqlQuery(this.components);
            this.lblPCKenntnisse = new KiSS4.Gui.KissLabel();
            this.edtFuehrerausweis = new KiSS4.Gui.KissLookUpEdit();
            this.lblFuehrerausweis = new KiSS4.Gui.KissLabel();
            this.lblLaufendeBetreibungen = new KiSS4.Gui.KissLabel();
            this.edtKaLaufendeBetreibungen = new KiSS4.Gui.KissLookUpEdit();
            this.edtKaLohnabtretungSD = new KiSS4.Gui.KissLookUpEdit();
            this.lblKaLohnabtretungSD = new KiSS4.Gui.KissLabel();
            this.lblKaSchweizerdeutsch = new KiSS4.Gui.KissLabel();
            this.edtKaSchweizerdeutsch = new KiSS4.Gui.KissLookUpEdit();
            this.edtBemerkungen = new KiSS4.Gui.KissMemoEdit();
            this.lblBemerkungen = new KiSS4.Gui.KissLabel();
            this.edtAeussereErscheinung = new KiSS4.Gui.KissLookUpEdit();
            this.lbläussereErscheinung = new KiSS4.Gui.KissLabel();
            this.edtMotivation = new KiSS4.Gui.KissLookUpEdit();
            this.lblMotivation = new KiSS4.Gui.KissLabel();
            this.edtZuverlaessigkeit = new KiSS4.Gui.KissLookUpEdit();
            this.lblZuverlässigkeit = new KiSS4.Gui.KissLabel();
            this.lblDiverses = new KiSS4.Gui.KissLabel();
            this.edtEinschraenkungen = new KiSS4.Gui.KissTextEdit();
            this.lblEinschränkungen = new KiSS4.Gui.KissLabel();
            this.edtGesundheitKoerperlich = new KiSS4.Gui.KissLookUpEdit();
            this.lblGesundheit = new KiSS4.Gui.KissLabel();
            this.edtSuchtart = new KiSS4.Gui.KissLookUpEdit();
            this.lblSuchtart = new KiSS4.Gui.KissLabel();
            this.edtSucht = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucht = new KiSS4.Gui.KissLabel();
            this.lblTitelGesundheit = new KiSS4.Gui.KissLabel();
            this.edtVermittelbarkeitDetails = new KiSS4.Gui.KissTextEdit();
            this.lbDetails = new KiSS4.Gui.KissLabel();
            this.edtVermittelbarkeit = new KiSS4.Gui.KissLookUpEdit();
            this.lblVermittelbarkeit = new KiSS4.Gui.KissLabel();
            this.lblTitelVermittelbarkeit = new KiSS4.Gui.KissLabel();
            this.edtDeutschSchriftlich = new KiSS4.Gui.KissLookUpEdit();
            this.lblschriftlich = new KiSS4.Gui.KissLabel();
            this.edtAmTelefonVerstaendigen = new KiSS4.Gui.KissCheckEdit();
            this.edtDeutschMuendlich = new KiSS4.Gui.KissLookUpEdit();
            this.lblmündlich = new KiSS4.Gui.KissLabel();
            this.lblVerständigungDeutsch = new KiSS4.Gui.KissLabel();
            this.tpgArbeitsgebiet = new SharpLibrary.WinControls.TabPageEx();
            this.lblVerfuegbarkeit = new KiSS4.Gui.KissLabel();
            this.edtKaVerfuegbarkeit = new KiSS4.Gui.KissLookUpEdit();
            this.edtKaNachtarbeitCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblKaNachtarbeit = new KiSS4.Gui.KissLabel();
            this.panVerfuegbarkeit = new System.Windows.Forms.TableLayoutPanel();
            this.edtEinschraenkungSA = new KiSS4.Gui.KissMemoEdit();
            this.edtEinschraenkungSO = new KiSS4.Gui.KissMemoEdit();
            this.lblEinschraenkungSO = new KiSS4.Gui.KissLabel();
            this.lblEinschraenkungSA = new KiSS4.Gui.KissLabel();
            this.lblEinschraenkungDO = new KiSS4.Gui.KissLabel();
            this.edtEinschraenkungDI = new KiSS4.Gui.KissMemoEdit();
            this.lblEinschraenkungDI = new KiSS4.Gui.KissLabel();
            this.edtEinschraenkungMO = new KiSS4.Gui.KissMemoEdit();
            this.lbEinschraenkungMI = new KiSS4.Gui.KissLabel();
            this.edtEinschraenkungMI = new KiSS4.Gui.KissMemoEdit();
            this.lbEinschraenkungMO = new KiSS4.Gui.KissLabel();
            this.edtEinschraenkungDO = new KiSS4.Gui.KissMemoEdit();
            this.edtEinschraenkungFR = new KiSS4.Gui.KissMemoEdit();
            this.lblEinschraenkungFR = new KiSS4.Gui.KissLabel();
            this.edtAktuelleTaetigkeit = new KiSS4.Gui.KissTextEdit();
            this.lblAktuelleTaetigkeit = new KiSS4.Gui.KissLabel();
            this.lblBemerkungen1 = new KiSS4.Gui.KissLabel();
            this.lblAusbildung = new KiSS4.Gui.KissLabel();
            this.lblbesondereWünsche = new KiSS4.Gui.KissLabel();
            this.lblKABetriebe = new KiSS4.Gui.KissLabel();
            this.lblBranche = new KiSS4.Gui.KissLabel();
            this.lblProzent = new KiSS4.Gui.KissLabel();
            this.lblEinsatzpensum = new KiSS4.Gui.KissLabel();
            this.btnEinsatzplatzSuchen = new KiSS4.Gui.KissButton();
            this.edtArbeitgebietBemerkungen = new KiSS4.Gui.KissMemoEdit();
            this.edtAusbildung = new KiSS4.Gui.KissLookUpEdit();
            this.edtBesondereWuensche = new KiSS4.Gui.KissTextEdit();
            this.edtKaBetriebe = new KiSS4.Gui.KissCheckedLookupEdit();
            this.edtBranchen = new KiSS4.Gui.KissCheckedLookupEdit();
            this.edtPensum = new KiSS4.Gui.KissCalcEdit();
            this.pnTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            this.tabVermittlungsprofil.SuspendLayout();
            this.tpgPersoenlichesProfil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtDummy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDummy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPCKenntnisse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPCKenntnisse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBIBIPVermittlung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPCKenntnisse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFuehrerausweis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFuehrerausweis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFuehrerausweis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLaufendeBetreibungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKaLaufendeBetreibungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKaLaufendeBetreibungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKaLohnabtretungSD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKaLohnabtretungSD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKaLohnabtretungSD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKaSchweizerdeutsch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKaSchweizerdeutsch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKaSchweizerdeutsch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAeussereErscheinung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAeussereErscheinung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbläussereErscheinung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMotivation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMotivation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMotivation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZuverlaessigkeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZuverlaessigkeit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZuverlässigkeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDiverses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinschraenkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinschränkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGesundheitKoerperlich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGesundheitKoerperlich.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGesundheit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchtart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchtart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchtart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucht.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelGesundheit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVermittelbarkeitDetails.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVermittelbarkeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVermittelbarkeit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVermittelbarkeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelVermittelbarkeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDeutschSchriftlich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDeutschSchriftlich.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblschriftlich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAmTelefonVerstaendigen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDeutschMuendlich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDeutschMuendlich.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblmündlich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerständigungDeutsch)).BeginInit();
            this.tpgArbeitsgebiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerfuegbarkeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKaVerfuegbarkeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKaVerfuegbarkeit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKaNachtarbeitCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKaNachtarbeitCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKaNachtarbeit)).BeginInit();
            this.panVerfuegbarkeit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinschraenkungSA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinschraenkungSO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinschraenkungSO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinschraenkungSA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinschraenkungDO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinschraenkungDI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinschraenkungDI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinschraenkungMO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbEinschraenkungMI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinschraenkungMI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbEinschraenkungMO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinschraenkungDO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinschraenkungFR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinschraenkungFR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAktuelleTaetigkeit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAktuelleTaetigkeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusbildung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbesondereWünsche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKABetriebe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBranche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProzent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzpensum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtArbeitgebietBemerkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusbildung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusbildung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBesondereWuensche.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKaBetriebe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBranchen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPensum.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnTitle
            // 
            this.pnTitle.Controls.Add(this.imageTitle);
            this.pnTitle.Controls.Add(this.btnVermittlungsgespraech);
            this.pnTitle.Controls.Add(this.lblTitle);
            this.pnTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTitle.Location = new System.Drawing.Point(0, 0);
            this.pnTitle.Name = "pnTitle";
            this.pnTitle.Size = new System.Drawing.Size(914, 40);
            this.pnTitle.TabIndex = 0;
            // 
            // imageTitle
            // 
            this.imageTitle.Location = new System.Drawing.Point(10, 9);
            this.imageTitle.Name = "imageTitle";
            this.imageTitle.Size = new System.Drawing.Size(25, 20);
            this.imageTitle.TabIndex = 1;
            this.imageTitle.TabStop = false;
            // 
            // btnVermittlungsgespraech
            // 
            this.btnVermittlungsgespraech.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVermittlungsgespraech.Context = "KaVermProfilBIBIPVermGespraech";
            this.btnVermittlungsgespraech.DocumentFormat = KiSS4.Dokument.DlgNewDocument.DocumentAccessModes.All;
            this.btnVermittlungsgespraech.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVermittlungsgespraech.Image = ((System.Drawing.Image)(resources.GetObject("btnVermittlungsgespraech.Image")));
            this.btnVermittlungsgespraech.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVermittlungsgespraech.Location = new System.Drawing.Point(743, 6);
            this.btnVermittlungsgespraech.Name = "btnVermittlungsgespraech";
            this.btnVermittlungsgespraech.Size = new System.Drawing.Size(159, 24);
            this.btnVermittlungsgespraech.TabIndex = 1;
            this.btnVermittlungsgespraech.Text = "Vermittlungsgespräch";
            this.btnVermittlungsgespraech.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVermittlungsgespraech.UseCompatibleTextRendering = true;
            this.btnVermittlungsgespraech.UseVisualStyleBackColor = false;
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
            this.tabVermittlungsprofil.Size = new System.Drawing.Size(914, 715);
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
            this.tpgPersoenlichesProfil.Controls.Add(this.edtDummy);
            this.tpgPersoenlichesProfil.Controls.Add(this.edtPCKenntnisse);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblPCKenntnisse);
            this.tpgPersoenlichesProfil.Controls.Add(this.edtFuehrerausweis);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblFuehrerausweis);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblLaufendeBetreibungen);
            this.tpgPersoenlichesProfil.Controls.Add(this.edtKaLaufendeBetreibungen);
            this.tpgPersoenlichesProfil.Controls.Add(this.edtKaLohnabtretungSD);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblKaLohnabtretungSD);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblKaSchweizerdeutsch);
            this.tpgPersoenlichesProfil.Controls.Add(this.edtKaSchweizerdeutsch);
            this.tpgPersoenlichesProfil.Controls.Add(this.edtBemerkungen);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblBemerkungen);
            this.tpgPersoenlichesProfil.Controls.Add(this.edtAeussereErscheinung);
            this.tpgPersoenlichesProfil.Controls.Add(this.lbläussereErscheinung);
            this.tpgPersoenlichesProfil.Controls.Add(this.edtMotivation);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblMotivation);
            this.tpgPersoenlichesProfil.Controls.Add(this.edtZuverlaessigkeit);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblZuverlässigkeit);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblDiverses);
            this.tpgPersoenlichesProfil.Controls.Add(this.edtEinschraenkungen);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblEinschränkungen);
            this.tpgPersoenlichesProfil.Controls.Add(this.edtGesundheitKoerperlich);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblGesundheit);
            this.tpgPersoenlichesProfil.Controls.Add(this.edtSuchtart);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblSuchtart);
            this.tpgPersoenlichesProfil.Controls.Add(this.edtSucht);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblSucht);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblTitelGesundheit);
            this.tpgPersoenlichesProfil.Controls.Add(this.edtVermittelbarkeitDetails);
            this.tpgPersoenlichesProfil.Controls.Add(this.lbDetails);
            this.tpgPersoenlichesProfil.Controls.Add(this.edtVermittelbarkeit);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblVermittelbarkeit);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblTitelVermittelbarkeit);
            this.tpgPersoenlichesProfil.Controls.Add(this.edtDeutschSchriftlich);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblschriftlich);
            this.tpgPersoenlichesProfil.Controls.Add(this.edtAmTelefonVerstaendigen);
            this.tpgPersoenlichesProfil.Controls.Add(this.edtDeutschMuendlich);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblmündlich);
            this.tpgPersoenlichesProfil.Controls.Add(this.lblVerständigungDeutsch);
            this.tpgPersoenlichesProfil.Location = new System.Drawing.Point(6, 32);
            this.tpgPersoenlichesProfil.Name = "tpgPersoenlichesProfil";
            this.tpgPersoenlichesProfil.Size = new System.Drawing.Size(902, 677);
            this.tpgPersoenlichesProfil.TabIndex = 0;
            this.tpgPersoenlichesProfil.Title = "Persönliches Profil";
            // 
            // edtDummy
            // 
            this.edtDummy.DataMember = "Dummy";
            this.edtDummy.Location = new System.Drawing.Point(662, 650);
            this.edtDummy.LOVName = "JaNeinBedingt";
            this.edtDummy.Name = "edtDummy";
            this.edtDummy.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDummy.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDummy.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDummy.Properties.Appearance.Options.UseBackColor = true;
            this.edtDummy.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDummy.Properties.Appearance.Options.UseFont = true;
            this.edtDummy.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtDummy.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtDummy.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtDummy.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtDummy.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtDummy.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtDummy.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDummy.Properties.NullText = "";
            this.edtDummy.Properties.ShowFooter = false;
            this.edtDummy.Properties.ShowHeader = false;
            this.edtDummy.Size = new System.Drawing.Size(234, 24);
            this.edtDummy.TabIndex = 38;
            this.edtDummy.Visible = false;
            // 
            // edtPCKenntnisse
            // 
            this.edtPCKenntnisse.DataMember = "PCKenntnisseCode";
            this.edtPCKenntnisse.DataSource = this.qryBIBIPVermittlung;
            this.edtPCKenntnisse.Location = new System.Drawing.Point(171, 471);
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
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtPCKenntnisse.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtPCKenntnisse.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPCKenntnisse.Properties.NullText = "";
            this.edtPCKenntnisse.Properties.ShowFooter = false;
            this.edtPCKenntnisse.Properties.ShowHeader = false;
            this.edtPCKenntnisse.Size = new System.Drawing.Size(160, 24);
            this.edtPCKenntnisse.TabIndex = 19;
            // 
            // qryBIBIPVermittlung
            // 
            this.qryBIBIPVermittlung.CanUpdate = true;
            this.qryBIBIPVermittlung.HostControl = this;
            this.qryBIBIPVermittlung.IsIdentityInsert = false;
            this.qryBIBIPVermittlung.SelectStatement = resources.GetString("qryBIBIPVermittlung.SelectStatement");
            this.qryBIBIPVermittlung.TableName = "KaVermittlungProfil";
            // 
            // lblPCKenntnisse
            // 
            this.lblPCKenntnisse.Location = new System.Drawing.Point(10, 471);
            this.lblPCKenntnisse.Name = "lblPCKenntnisse";
            this.lblPCKenntnisse.Size = new System.Drawing.Size(155, 24);
            this.lblPCKenntnisse.TabIndex = 37;
            this.lblPCKenntnisse.Text = "PC-Kenntnisse";
            this.lblPCKenntnisse.UseCompatibleTextRendering = true;
            // 
            // edtFuehrerausweis
            // 
            this.edtFuehrerausweis.DataMember = "FuehrerausweisKategorieCode";
            this.edtFuehrerausweis.DataSource = this.qryBIBIPVermittlung;
            this.edtFuehrerausweis.Location = new System.Drawing.Point(171, 443);
            this.edtFuehrerausweis.LOVName = "KaFuehrerausweisKategorie";
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
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtFuehrerausweis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtFuehrerausweis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFuehrerausweis.Properties.NullText = "";
            this.edtFuehrerausweis.Properties.ShowFooter = false;
            this.edtFuehrerausweis.Properties.ShowHeader = false;
            this.edtFuehrerausweis.Size = new System.Drawing.Size(160, 24);
            this.edtFuehrerausweis.TabIndex = 17;
            // 
            // lblFuehrerausweis
            // 
            this.lblFuehrerausweis.Location = new System.Drawing.Point(10, 443);
            this.lblFuehrerausweis.Name = "lblFuehrerausweis";
            this.lblFuehrerausweis.Size = new System.Drawing.Size(155, 24);
            this.lblFuehrerausweis.TabIndex = 35;
            this.lblFuehrerausweis.Text = "Führerausweis";
            this.lblFuehrerausweis.UseCompatibleTextRendering = true;
            // 
            // lblLaufendeBetreibungen
            // 
            this.lblLaufendeBetreibungen.Location = new System.Drawing.Point(10, 415);
            this.lblLaufendeBetreibungen.Name = "lblLaufendeBetreibungen";
            this.lblLaufendeBetreibungen.Size = new System.Drawing.Size(155, 24);
            this.lblLaufendeBetreibungen.TabIndex = 34;
            this.lblLaufendeBetreibungen.Text = "Laufende Betreibungen";
            this.lblLaufendeBetreibungen.UseCompatibleTextRendering = true;
            // 
            // edtKaLaufendeBetreibungen
            // 
            this.edtKaLaufendeBetreibungen.DataMember = "KaLaufendeBetreibungenCode";
            this.edtKaLaufendeBetreibungen.DataSource = this.qryBIBIPVermittlung;
            this.edtKaLaufendeBetreibungen.Location = new System.Drawing.Point(171, 415);
            this.edtKaLaufendeBetreibungen.LOVName = "JaNein";
            this.edtKaLaufendeBetreibungen.Name = "edtKaLaufendeBetreibungen";
            this.edtKaLaufendeBetreibungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKaLaufendeBetreibungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKaLaufendeBetreibungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKaLaufendeBetreibungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtKaLaufendeBetreibungen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKaLaufendeBetreibungen.Properties.Appearance.Options.UseFont = true;
            this.edtKaLaufendeBetreibungen.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKaLaufendeBetreibungen.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKaLaufendeBetreibungen.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKaLaufendeBetreibungen.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKaLaufendeBetreibungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtKaLaufendeBetreibungen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtKaLaufendeBetreibungen.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKaLaufendeBetreibungen.Properties.NullText = "";
            this.edtKaLaufendeBetreibungen.Properties.ShowFooter = false;
            this.edtKaLaufendeBetreibungen.Properties.ShowHeader = false;
            this.edtKaLaufendeBetreibungen.Size = new System.Drawing.Size(160, 24);
            this.edtKaLaufendeBetreibungen.TabIndex = 16;
            // 
            // edtKaLohnabtretungSD
            // 
            this.edtKaLohnabtretungSD.DataMember = "KaLohnabtretungSDCode";
            this.edtKaLohnabtretungSD.DataSource = this.qryBIBIPVermittlung;
            this.edtKaLohnabtretungSD.Location = new System.Drawing.Point(171, 387);
            this.edtKaLohnabtretungSD.LOVName = "JaNein";
            this.edtKaLohnabtretungSD.Name = "edtKaLohnabtretungSD";
            this.edtKaLohnabtretungSD.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKaLohnabtretungSD.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKaLohnabtretungSD.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKaLohnabtretungSD.Properties.Appearance.Options.UseBackColor = true;
            this.edtKaLohnabtretungSD.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKaLohnabtretungSD.Properties.Appearance.Options.UseFont = true;
            this.edtKaLohnabtretungSD.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKaLohnabtretungSD.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKaLohnabtretungSD.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKaLohnabtretungSD.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKaLohnabtretungSD.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtKaLohnabtretungSD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtKaLohnabtretungSD.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKaLohnabtretungSD.Properties.NullText = "";
            this.edtKaLohnabtretungSD.Properties.ShowFooter = false;
            this.edtKaLohnabtretungSD.Properties.ShowHeader = false;
            this.edtKaLohnabtretungSD.Size = new System.Drawing.Size(160, 24);
            this.edtKaLohnabtretungSD.TabIndex = 15;
            // 
            // lblKaLohnabtretungSD
            // 
            this.lblKaLohnabtretungSD.Location = new System.Drawing.Point(10, 387);
            this.lblKaLohnabtretungSD.Name = "lblKaLohnabtretungSD";
            this.lblKaLohnabtretungSD.Size = new System.Drawing.Size(155, 24);
            this.lblKaLohnabtretungSD.TabIndex = 31;
            this.lblKaLohnabtretungSD.Text = "Lohnabtretung SD";
            this.lblKaLohnabtretungSD.UseCompatibleTextRendering = true;
            // 
            // lblKaSchweizerdeutsch
            // 
            this.lblKaSchweizerdeutsch.Location = new System.Drawing.Point(10, 79);
            this.lblKaSchweizerdeutsch.Name = "lblKaSchweizerdeutsch";
            this.lblKaSchweizerdeutsch.Size = new System.Drawing.Size(155, 24);
            this.lblKaSchweizerdeutsch.TabIndex = 30;
            this.lblKaSchweizerdeutsch.Text = "Schweizerdeutsch";
            this.lblKaSchweizerdeutsch.UseCompatibleTextRendering = true;
            // 
            // edtKaSchweizerdeutsch
            // 
            this.edtKaSchweizerdeutsch.DataMember = "KaSchweizerdeutschCode";
            this.edtKaSchweizerdeutsch.DataSource = this.qryBIBIPVermittlung;
            this.edtKaSchweizerdeutsch.Location = new System.Drawing.Point(171, 79);
            this.edtKaSchweizerdeutsch.LOVName = "KaSchweizerdeutsch";
            this.edtKaSchweizerdeutsch.Name = "edtKaSchweizerdeutsch";
            this.edtKaSchweizerdeutsch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKaSchweizerdeutsch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKaSchweizerdeutsch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKaSchweizerdeutsch.Properties.Appearance.Options.UseBackColor = true;
            this.edtKaSchweizerdeutsch.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKaSchweizerdeutsch.Properties.Appearance.Options.UseFont = true;
            this.edtKaSchweizerdeutsch.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKaSchweizerdeutsch.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKaSchweizerdeutsch.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKaSchweizerdeutsch.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKaSchweizerdeutsch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtKaSchweizerdeutsch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtKaSchweizerdeutsch.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKaSchweizerdeutsch.Properties.NullText = "";
            this.edtKaSchweizerdeutsch.Properties.ShowFooter = false;
            this.edtKaSchweizerdeutsch.Properties.ShowHeader = false;
            this.edtKaSchweizerdeutsch.Size = new System.Drawing.Size(308, 24);
            this.edtKaSchweizerdeutsch.TabIndex = 5;
            // 
            // edtBemerkungen
            // 
            this.edtBemerkungen.DataMember = "Bemerkungen";
            this.edtBemerkungen.DataSource = this.qryBIBIPVermittlung;
            this.edtBemerkungen.Location = new System.Drawing.Point(171, 499);
            this.edtBemerkungen.Name = "edtBemerkungen";
            this.edtBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkungen.Size = new System.Drawing.Size(509, 88);
            this.edtBemerkungen.TabIndex = 20;
            // 
            // lblBemerkungen
            // 
            this.lblBemerkungen.Location = new System.Drawing.Point(10, 499);
            this.lblBemerkungen.Name = "lblBemerkungen";
            this.lblBemerkungen.Size = new System.Drawing.Size(155, 24);
            this.lblBemerkungen.TabIndex = 27;
            this.lblBemerkungen.Text = "Bemerkungen";
            this.lblBemerkungen.UseCompatibleTextRendering = true;
            // 
            // edtAeussereErscheinung
            // 
            this.edtAeussereErscheinung.DataMember = "AeussereErscheinungCode";
            this.edtAeussereErscheinung.DataSource = this.qryBIBIPVermittlung;
            this.edtAeussereErscheinung.Location = new System.Drawing.Point(171, 359);
            this.edtAeussereErscheinung.LOVName = "KaVermittlungBIBIPAeussereErscheinung";
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
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtAeussereErscheinung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtAeussereErscheinung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAeussereErscheinung.Properties.NullText = "";
            this.edtAeussereErscheinung.Properties.ShowFooter = false;
            this.edtAeussereErscheinung.Properties.ShowHeader = false;
            this.edtAeussereErscheinung.Size = new System.Drawing.Size(160, 24);
            this.edtAeussereErscheinung.TabIndex = 14;
            // 
            // lbläussereErscheinung
            // 
            this.lbläussereErscheinung.Location = new System.Drawing.Point(10, 359);
            this.lbläussereErscheinung.Name = "lbläussereErscheinung";
            this.lbläussereErscheinung.Size = new System.Drawing.Size(155, 24);
            this.lbläussereErscheinung.TabIndex = 25;
            this.lbläussereErscheinung.Text = "Äussere Erscheinung";
            this.lbläussereErscheinung.UseCompatibleTextRendering = true;
            // 
            // edtMotivation
            // 
            this.edtMotivation.DataMember = "MotivationBIBIPSICode";
            this.edtMotivation.DataSource = this.qryBIBIPVermittlung;
            this.edtMotivation.Location = new System.Drawing.Point(446, 331);
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
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtMotivation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtMotivation.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtMotivation.Properties.NullText = "";
            this.edtMotivation.Properties.ShowFooter = false;
            this.edtMotivation.Properties.ShowHeader = false;
            this.edtMotivation.Size = new System.Drawing.Size(234, 24);
            this.edtMotivation.TabIndex = 13;
            // 
            // lblMotivation
            // 
            this.lblMotivation.Location = new System.Drawing.Point(367, 331);
            this.lblMotivation.Name = "lblMotivation";
            this.lblMotivation.Size = new System.Drawing.Size(73, 24);
            this.lblMotivation.TabIndex = 23;
            this.lblMotivation.Text = "Motivation";
            this.lblMotivation.UseCompatibleTextRendering = true;
            // 
            // edtZuverlaessigkeit
            // 
            this.edtZuverlaessigkeit.DataMember = "ZuverlaessigkeitCode";
            this.edtZuverlaessigkeit.DataSource = this.qryBIBIPVermittlung;
            this.edtZuverlaessigkeit.Location = new System.Drawing.Point(171, 331);
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
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtZuverlaessigkeit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtZuverlaessigkeit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZuverlaessigkeit.Properties.NullText = "";
            this.edtZuverlaessigkeit.Properties.ShowFooter = false;
            this.edtZuverlaessigkeit.Properties.ShowHeader = false;
            this.edtZuverlaessigkeit.Size = new System.Drawing.Size(160, 24);
            this.edtZuverlaessigkeit.TabIndex = 12;
            // 
            // lblZuverlässigkeit
            // 
            this.lblZuverlässigkeit.Location = new System.Drawing.Point(10, 331);
            this.lblZuverlässigkeit.Name = "lblZuverlässigkeit";
            this.lblZuverlässigkeit.Size = new System.Drawing.Size(155, 24);
            this.lblZuverlässigkeit.TabIndex = 21;
            this.lblZuverlässigkeit.Text = "Zuverlässigkeit";
            this.lblZuverlässigkeit.UseCompatibleTextRendering = true;
            // 
            // lblDiverses
            // 
            this.lblDiverses.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblDiverses.Location = new System.Drawing.Point(10, 306);
            this.lblDiverses.Name = "lblDiverses";
            this.lblDiverses.Size = new System.Drawing.Size(100, 16);
            this.lblDiverses.TabIndex = 20;
            this.lblDiverses.Text = "Diverses";
            this.lblDiverses.UseCompatibleTextRendering = true;
            // 
            // edtEinschraenkungen
            // 
            this.edtEinschraenkungen.DataMember = "GesundheitEinschraenkungen";
            this.edtEinschraenkungen.DataSource = this.qryBIBIPVermittlung;
            this.edtEinschraenkungen.Location = new System.Drawing.Point(171, 270);
            this.edtEinschraenkungen.Name = "edtEinschraenkungen";
            this.edtEinschraenkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinschraenkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinschraenkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinschraenkungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinschraenkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinschraenkungen.Properties.Appearance.Options.UseFont = true;
            this.edtEinschraenkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEinschraenkungen.Size = new System.Drawing.Size(509, 24);
            this.edtEinschraenkungen.TabIndex = 11;
            // 
            // lblEinschränkungen
            // 
            this.lblEinschränkungen.Location = new System.Drawing.Point(10, 270);
            this.lblEinschränkungen.Name = "lblEinschränkungen";
            this.lblEinschränkungen.Size = new System.Drawing.Size(160, 24);
            this.lblEinschränkungen.TabIndex = 18;
            this.lblEinschränkungen.Text = "Einschränkungen";
            this.lblEinschränkungen.UseCompatibleTextRendering = true;
            // 
            // edtGesundheitKoerperlich
            // 
            this.edtGesundheitKoerperlich.DataMember = "GesundheitCode";
            this.edtGesundheitKoerperlich.DataSource = this.qryBIBIPVermittlung;
            this.edtGesundheitKoerperlich.Location = new System.Drawing.Point(171, 242);
            this.edtGesundheitKoerperlich.LOVName = "KaVermittlungBIBIPGesundheit";
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
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtGesundheitKoerperlich.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtGesundheitKoerperlich.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGesundheitKoerperlich.Properties.NullText = "";
            this.edtGesundheitKoerperlich.Properties.ShowFooter = false;
            this.edtGesundheitKoerperlich.Properties.ShowHeader = false;
            this.edtGesundheitKoerperlich.Size = new System.Drawing.Size(160, 24);
            this.edtGesundheitKoerperlich.TabIndex = 10;
            // 
            // lblGesundheit
            // 
            this.lblGesundheit.Location = new System.Drawing.Point(10, 242);
            this.lblGesundheit.Name = "lblGesundheit";
            this.lblGesundheit.Size = new System.Drawing.Size(155, 24);
            this.lblGesundheit.TabIndex = 16;
            this.lblGesundheit.Text = "Gesundheit";
            this.lblGesundheit.UseCompatibleTextRendering = true;
            // 
            // edtSuchtart
            // 
            this.edtSuchtart.DataMember = "SuchtartCode";
            this.edtSuchtart.DataSource = this.qryBIBIPVermittlung;
            this.edtSuchtart.Location = new System.Drawing.Point(446, 214);
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
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtSuchtart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.edtSuchtart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSuchtart.Properties.NullText = "";
            this.edtSuchtart.Properties.ShowFooter = false;
            this.edtSuchtart.Properties.ShowHeader = false;
            this.edtSuchtart.Size = new System.Drawing.Size(234, 24);
            this.edtSuchtart.TabIndex = 9;
            // 
            // lblSuchtart
            // 
            this.lblSuchtart.Location = new System.Drawing.Point(367, 214);
            this.lblSuchtart.Name = "lblSuchtart";
            this.lblSuchtart.Size = new System.Drawing.Size(69, 24);
            this.lblSuchtart.TabIndex = 14;
            this.lblSuchtart.Text = "Suchtart";
            this.lblSuchtart.UseCompatibleTextRendering = true;
            // 
            // edtSucht
            // 
            this.edtSucht.DataMember = "SuchtCode";
            this.edtSucht.DataSource = this.qryBIBIPVermittlung;
            this.edtSucht.Location = new System.Drawing.Point(171, 214);
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
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.edtSucht.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.edtSucht.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucht.Properties.NullText = "";
            this.edtSucht.Properties.ShowFooter = false;
            this.edtSucht.Properties.ShowHeader = false;
            this.edtSucht.Size = new System.Drawing.Size(160, 24);
            this.edtSucht.TabIndex = 8;
            // 
            // lblSucht
            // 
            this.lblSucht.Location = new System.Drawing.Point(10, 214);
            this.lblSucht.Name = "lblSucht";
            this.lblSucht.Size = new System.Drawing.Size(155, 24);
            this.lblSucht.TabIndex = 12;
            this.lblSucht.Text = "Sucht";
            this.lblSucht.UseCompatibleTextRendering = true;
            // 
            // lblTitelGesundheit
            // 
            this.lblTitelGesundheit.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblTitelGesundheit.Location = new System.Drawing.Point(10, 193);
            this.lblTitelGesundheit.Name = "lblTitelGesundheit";
            this.lblTitelGesundheit.Size = new System.Drawing.Size(100, 16);
            this.lblTitelGesundheit.TabIndex = 11;
            this.lblTitelGesundheit.Text = "Gesundheit";
            this.lblTitelGesundheit.UseCompatibleTextRendering = true;
            // 
            // edtVermittelbarkeitDetails
            // 
            this.edtVermittelbarkeitDetails.DataMember = "VermittelbarkeitBemerkung";
            this.edtVermittelbarkeitDetails.DataSource = this.qryBIBIPVermittlung;
            this.edtVermittelbarkeitDetails.Location = new System.Drawing.Point(171, 160);
            this.edtVermittelbarkeitDetails.Name = "edtVermittelbarkeitDetails";
            this.edtVermittelbarkeitDetails.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVermittelbarkeitDetails.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVermittelbarkeitDetails.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVermittelbarkeitDetails.Properties.Appearance.Options.UseBackColor = true;
            this.edtVermittelbarkeitDetails.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVermittelbarkeitDetails.Properties.Appearance.Options.UseFont = true;
            this.edtVermittelbarkeitDetails.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVermittelbarkeitDetails.Size = new System.Drawing.Size(509, 24);
            this.edtVermittelbarkeitDetails.TabIndex = 7;
            // 
            // lbDetails
            // 
            this.lbDetails.Location = new System.Drawing.Point(10, 160);
            this.lbDetails.Name = "lbDetails";
            this.lbDetails.Size = new System.Drawing.Size(155, 24);
            this.lbDetails.TabIndex = 9;
            this.lbDetails.Text = "Details";
            this.lbDetails.UseCompatibleTextRendering = true;
            // 
            // edtVermittelbarkeit
            // 
            this.edtVermittelbarkeit.DataMember = "VermittelbarkeitBIBIPCode";
            this.edtVermittelbarkeit.DataSource = this.qryBIBIPVermittlung;
            this.edtVermittelbarkeit.Location = new System.Drawing.Point(171, 131);
            this.edtVermittelbarkeit.LOVName = "KaVermittlungBIBIPVermittelbarkeit";
            this.edtVermittelbarkeit.Name = "edtVermittelbarkeit";
            this.edtVermittelbarkeit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVermittelbarkeit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVermittelbarkeit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVermittelbarkeit.Properties.Appearance.Options.UseBackColor = true;
            this.edtVermittelbarkeit.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVermittelbarkeit.Properties.Appearance.Options.UseFont = true;
            this.edtVermittelbarkeit.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtVermittelbarkeit.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtVermittelbarkeit.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtVermittelbarkeit.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtVermittelbarkeit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject13.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject13.Options.UseBackColor = true;
            this.edtVermittelbarkeit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13)});
            this.edtVermittelbarkeit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVermittelbarkeit.Properties.NullText = "";
            this.edtVermittelbarkeit.Properties.ShowFooter = false;
            this.edtVermittelbarkeit.Properties.ShowHeader = false;
            this.edtVermittelbarkeit.Size = new System.Drawing.Size(160, 24);
            this.edtVermittelbarkeit.TabIndex = 6;
            // 
            // lblVermittelbarkeit
            // 
            this.lblVermittelbarkeit.Location = new System.Drawing.Point(10, 131);
            this.lblVermittelbarkeit.Name = "lblVermittelbarkeit";
            this.lblVermittelbarkeit.Size = new System.Drawing.Size(155, 24);
            this.lblVermittelbarkeit.TabIndex = 7;
            this.lblVermittelbarkeit.Text = "Vermittelbarkeit";
            this.lblVermittelbarkeit.UseCompatibleTextRendering = true;
            // 
            // lblTitelVermittelbarkeit
            // 
            this.lblTitelVermittelbarkeit.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblTitelVermittelbarkeit.Location = new System.Drawing.Point(10, 112);
            this.lblTitelVermittelbarkeit.Name = "lblTitelVermittelbarkeit";
            this.lblTitelVermittelbarkeit.Size = new System.Drawing.Size(119, 16);
            this.lblTitelVermittelbarkeit.TabIndex = 6;
            this.lblTitelVermittelbarkeit.Text = "Vermittelbarkeit";
            this.lblTitelVermittelbarkeit.UseCompatibleTextRendering = true;
            // 
            // edtDeutschSchriftlich
            // 
            this.edtDeutschSchriftlich.DataMember = "DeutschSchriftlichCode";
            this.edtDeutschSchriftlich.DataSource = this.qryBIBIPVermittlung;
            this.edtDeutschSchriftlich.Location = new System.Drawing.Point(171, 51);
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
            serializableAppearanceObject14.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject14.Options.UseBackColor = true;
            this.edtDeutschSchriftlich.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject14)});
            this.edtDeutschSchriftlich.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDeutschSchriftlich.Properties.NullText = "";
            this.edtDeutschSchriftlich.Properties.ShowFooter = false;
            this.edtDeutschSchriftlich.Properties.ShowHeader = false;
            this.edtDeutschSchriftlich.Size = new System.Drawing.Size(160, 24);
            this.edtDeutschSchriftlich.TabIndex = 4;
            // 
            // lblschriftlich
            // 
            this.lblschriftlich.Location = new System.Drawing.Point(10, 51);
            this.lblschriftlich.Name = "lblschriftlich";
            this.lblschriftlich.Size = new System.Drawing.Size(155, 24);
            this.lblschriftlich.TabIndex = 4;
            this.lblschriftlich.Text = "Schriftlich";
            this.lblschriftlich.UseCompatibleTextRendering = true;
            // 
            // edtAmTelefonVerstaendigen
            // 
            this.edtAmTelefonVerstaendigen.DataMember = "KannSichAmTelVerstaendigen";
            this.edtAmTelefonVerstaendigen.DataSource = this.qryBIBIPVermittlung;
            this.edtAmTelefonVerstaendigen.Location = new System.Drawing.Point(348, 25);
            this.edtAmTelefonVerstaendigen.Name = "edtAmTelefonVerstaendigen";
            this.edtAmTelefonVerstaendigen.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAmTelefonVerstaendigen.Properties.Appearance.Options.UseBackColor = true;
            this.edtAmTelefonVerstaendigen.Properties.Caption = "kann sich am Telefon verständigen";
            this.edtAmTelefonVerstaendigen.Size = new System.Drawing.Size(191, 19);
            this.edtAmTelefonVerstaendigen.TabIndex = 3;
            // 
            // edtDeutschMuendlich
            // 
            this.edtDeutschMuendlich.DataMember = "DeutschMuendlichCode";
            this.edtDeutschMuendlich.DataSource = this.qryBIBIPVermittlung;
            this.edtDeutschMuendlich.Location = new System.Drawing.Point(171, 22);
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
            serializableAppearanceObject15.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject15.Options.UseBackColor = true;
            this.edtDeutschMuendlich.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject15)});
            this.edtDeutschMuendlich.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDeutschMuendlich.Properties.NullText = "";
            this.edtDeutschMuendlich.Properties.ShowFooter = false;
            this.edtDeutschMuendlich.Properties.ShowHeader = false;
            this.edtDeutschMuendlich.Size = new System.Drawing.Size(160, 24);
            this.edtDeutschMuendlich.TabIndex = 2;
            // 
            // lblmündlich
            // 
            this.lblmündlich.Location = new System.Drawing.Point(10, 25);
            this.lblmündlich.Name = "lblmündlich";
            this.lblmündlich.Size = new System.Drawing.Size(155, 24);
            this.lblmündlich.TabIndex = 1;
            this.lblmündlich.Text = "Mündlich";
            this.lblmündlich.UseCompatibleTextRendering = true;
            // 
            // lblVerständigungDeutsch
            // 
            this.lblVerständigungDeutsch.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblVerständigungDeutsch.Location = new System.Drawing.Point(10, 4);
            this.lblVerständigungDeutsch.Name = "lblVerständigungDeutsch";
            this.lblVerständigungDeutsch.Size = new System.Drawing.Size(160, 16);
            this.lblVerständigungDeutsch.TabIndex = 0;
            this.lblVerständigungDeutsch.Text = "Verständigung Deutsch";
            this.lblVerständigungDeutsch.UseCompatibleTextRendering = true;
            // 
            // tpgArbeitsgebiet
            // 
            this.tpgArbeitsgebiet.Controls.Add(this.lblVerfuegbarkeit);
            this.tpgArbeitsgebiet.Controls.Add(this.edtKaVerfuegbarkeit);
            this.tpgArbeitsgebiet.Controls.Add(this.edtKaNachtarbeitCode);
            this.tpgArbeitsgebiet.Controls.Add(this.lblKaNachtarbeit);
            this.tpgArbeitsgebiet.Controls.Add(this.panVerfuegbarkeit);
            this.tpgArbeitsgebiet.Controls.Add(this.edtAktuelleTaetigkeit);
            this.tpgArbeitsgebiet.Controls.Add(this.lblAktuelleTaetigkeit);
            this.tpgArbeitsgebiet.Controls.Add(this.lblBemerkungen1);
            this.tpgArbeitsgebiet.Controls.Add(this.lblAusbildung);
            this.tpgArbeitsgebiet.Controls.Add(this.lblbesondereWünsche);
            this.tpgArbeitsgebiet.Controls.Add(this.lblKABetriebe);
            this.tpgArbeitsgebiet.Controls.Add(this.lblBranche);
            this.tpgArbeitsgebiet.Controls.Add(this.lblProzent);
            this.tpgArbeitsgebiet.Controls.Add(this.lblEinsatzpensum);
            this.tpgArbeitsgebiet.Controls.Add(this.btnEinsatzplatzSuchen);
            this.tpgArbeitsgebiet.Controls.Add(this.edtArbeitgebietBemerkungen);
            this.tpgArbeitsgebiet.Controls.Add(this.edtAusbildung);
            this.tpgArbeitsgebiet.Controls.Add(this.edtBesondereWuensche);
            this.tpgArbeitsgebiet.Controls.Add(this.edtKaBetriebe);
            this.tpgArbeitsgebiet.Controls.Add(this.edtBranchen);
            this.tpgArbeitsgebiet.Controls.Add(this.edtPensum);
            this.tpgArbeitsgebiet.Location = new System.Drawing.Point(6, 32);
            this.tpgArbeitsgebiet.Name = "tpgArbeitsgebiet";
            this.tpgArbeitsgebiet.Size = new System.Drawing.Size(902, 677);
            this.tpgArbeitsgebiet.TabIndex = 0;
            this.tpgArbeitsgebiet.Title = "Arbeitsgebiet";
            // 
            // lblVerfuegbarkeit
            // 
            this.lblVerfuegbarkeit.Location = new System.Drawing.Point(10, 252);
            this.lblVerfuegbarkeit.Name = "lblVerfuegbarkeit";
            this.lblVerfuegbarkeit.Size = new System.Drawing.Size(136, 24);
            this.lblVerfuegbarkeit.TabIndex = 27;
            this.lblVerfuegbarkeit.Text = "Verfügbarkeit";
            this.lblVerfuegbarkeit.UseCompatibleTextRendering = true;
            // 
            // edtKaVerfuegbarkeit
            // 
            this.edtKaVerfuegbarkeit.DataMember = "KaVerfuegbarkeitCode";
            this.edtKaVerfuegbarkeit.DataSource = this.qryBIBIPVermittlung;
            this.edtKaVerfuegbarkeit.Location = new System.Drawing.Point(152, 252);
            this.edtKaVerfuegbarkeit.LOVName = "KaVerfuegbarkeit";
            this.edtKaVerfuegbarkeit.Name = "edtKaVerfuegbarkeit";
            this.edtKaVerfuegbarkeit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKaVerfuegbarkeit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKaVerfuegbarkeit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKaVerfuegbarkeit.Properties.Appearance.Options.UseBackColor = true;
            this.edtKaVerfuegbarkeit.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKaVerfuegbarkeit.Properties.Appearance.Options.UseFont = true;
            this.edtKaVerfuegbarkeit.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKaVerfuegbarkeit.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKaVerfuegbarkeit.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKaVerfuegbarkeit.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKaVerfuegbarkeit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject16.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject16.Options.UseBackColor = true;
            this.edtKaVerfuegbarkeit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject16)});
            this.edtKaVerfuegbarkeit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKaVerfuegbarkeit.Properties.NullText = "";
            this.edtKaVerfuegbarkeit.Properties.ShowFooter = false;
            this.edtKaVerfuegbarkeit.Properties.ShowHeader = false;
            this.edtKaVerfuegbarkeit.Size = new System.Drawing.Size(200, 24);
            this.edtKaVerfuegbarkeit.TabIndex = 27;
            this.edtKaVerfuegbarkeit.EditValueChanged += new System.EventHandler(this.edtKaVerfuegbarkeit_EditValueChanged);
            // 
            // edtKaNachtarbeitCode
            // 
            this.edtKaNachtarbeitCode.DataMember = "KaNachtarbeitCode";
            this.edtKaNachtarbeitCode.DataSource = this.qryBIBIPVermittlung;
            this.edtKaNachtarbeitCode.Location = new System.Drawing.Point(152, 384);
            this.edtKaNachtarbeitCode.LOVName = "JaNein";
            this.edtKaNachtarbeitCode.Name = "edtKaNachtarbeitCode";
            this.edtKaNachtarbeitCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKaNachtarbeitCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKaNachtarbeitCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKaNachtarbeitCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtKaNachtarbeitCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKaNachtarbeitCode.Properties.Appearance.Options.UseFont = true;
            this.edtKaNachtarbeitCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKaNachtarbeitCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKaNachtarbeitCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKaNachtarbeitCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKaNachtarbeitCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject17.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject17.Options.UseBackColor = true;
            this.edtKaNachtarbeitCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject17)});
            this.edtKaNachtarbeitCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKaNachtarbeitCode.Properties.NullText = "";
            this.edtKaNachtarbeitCode.Properties.ShowFooter = false;
            this.edtKaNachtarbeitCode.Properties.ShowHeader = false;
            this.edtKaNachtarbeitCode.Size = new System.Drawing.Size(200, 24);
            this.edtKaNachtarbeitCode.TabIndex = 35;
            // 
            // lblKaNachtarbeit
            // 
            this.lblKaNachtarbeit.Location = new System.Drawing.Point(9, 385);
            this.lblKaNachtarbeit.Name = "lblKaNachtarbeit";
            this.lblKaNachtarbeit.Size = new System.Drawing.Size(137, 24);
            this.lblKaNachtarbeit.TabIndex = 24;
            this.lblKaNachtarbeit.Text = "Nachtarbeit";
            this.lblKaNachtarbeit.UseCompatibleTextRendering = true;
            // 
            // panVerfuegbarkeit
            // 
            this.panVerfuegbarkeit.ColumnCount = 7;
            this.panVerfuegbarkeit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panVerfuegbarkeit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panVerfuegbarkeit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panVerfuegbarkeit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panVerfuegbarkeit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panVerfuegbarkeit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panVerfuegbarkeit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panVerfuegbarkeit.Controls.Add(this.edtEinschraenkungSA, 5, 1);
            this.panVerfuegbarkeit.Controls.Add(this.edtEinschraenkungSO, 6, 1);
            this.panVerfuegbarkeit.Controls.Add(this.lblEinschraenkungSO, 6, 0);
            this.panVerfuegbarkeit.Controls.Add(this.lblEinschraenkungSA, 5, 0);
            this.panVerfuegbarkeit.Controls.Add(this.lblEinschraenkungDO, 3, 0);
            this.panVerfuegbarkeit.Controls.Add(this.edtEinschraenkungDI, 1, 1);
            this.panVerfuegbarkeit.Controls.Add(this.lblEinschraenkungDI, 1, 0);
            this.panVerfuegbarkeit.Controls.Add(this.edtEinschraenkungMO, 0, 1);
            this.panVerfuegbarkeit.Controls.Add(this.lbEinschraenkungMI, 2, 0);
            this.panVerfuegbarkeit.Controls.Add(this.edtEinschraenkungMI, 2, 1);
            this.panVerfuegbarkeit.Controls.Add(this.lbEinschraenkungMO, 0, 0);
            this.panVerfuegbarkeit.Controls.Add(this.edtEinschraenkungDO, 3, 1);
            this.panVerfuegbarkeit.Controls.Add(this.edtEinschraenkungFR, 4, 1);
            this.panVerfuegbarkeit.Controls.Add(this.lblEinschraenkungFR, 4, 0);
            this.panVerfuegbarkeit.Location = new System.Drawing.Point(149, 280);
            this.panVerfuegbarkeit.Name = "panVerfuegbarkeit";
            this.panVerfuegbarkeit.RowCount = 2;
            this.panVerfuegbarkeit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26F));
            this.panVerfuegbarkeit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74F));
            this.panVerfuegbarkeit.Size = new System.Drawing.Size(742, 100);
            this.panVerfuegbarkeit.TabIndex = 28;
            // 
            // edtEinschraenkungSA
            // 
            this.edtEinschraenkungSA.DataMember = "EinschraenkungSA";
            this.edtEinschraenkungSA.DataSource = this.qryBIBIPVermittlung;
            this.edtEinschraenkungSA.Location = new System.Drawing.Point(533, 29);
            this.edtEinschraenkungSA.Name = "edtEinschraenkungSA";
            this.edtEinschraenkungSA.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinschraenkungSA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinschraenkungSA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinschraenkungSA.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinschraenkungSA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinschraenkungSA.Properties.Appearance.Options.UseFont = true;
            this.edtEinschraenkungSA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEinschraenkungSA.Size = new System.Drawing.Size(100, 68);
            this.edtEinschraenkungSA.TabIndex = 33;
            // 
            // edtEinschraenkungSO
            // 
            this.edtEinschraenkungSO.DataMember = "EinschraenkungSO";
            this.edtEinschraenkungSO.DataSource = this.qryBIBIPVermittlung;
            this.edtEinschraenkungSO.Location = new System.Drawing.Point(639, 29);
            this.edtEinschraenkungSO.Name = "edtEinschraenkungSO";
            this.edtEinschraenkungSO.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinschraenkungSO.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinschraenkungSO.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinschraenkungSO.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinschraenkungSO.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinschraenkungSO.Properties.Appearance.Options.UseFont = true;
            this.edtEinschraenkungSO.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEinschraenkungSO.Size = new System.Drawing.Size(100, 68);
            this.edtEinschraenkungSO.TabIndex = 34;
            // 
            // lblEinschraenkungSO
            // 
            this.lblEinschraenkungSO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblEinschraenkungSO.Location = new System.Drawing.Point(680, 0);
            this.lblEinschraenkungSO.Name = "lblEinschraenkungSO";
            this.lblEinschraenkungSO.Size = new System.Drawing.Size(18, 24);
            this.lblEinschraenkungSO.TabIndex = 32;
            this.lblEinschraenkungSO.Text = "SO";
            this.lblEinschraenkungSO.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblEinschraenkungSA
            // 
            this.lblEinschraenkungSA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblEinschraenkungSA.Location = new System.Drawing.Point(573, 0);
            this.lblEinschraenkungSA.Name = "lblEinschraenkungSA";
            this.lblEinschraenkungSA.Size = new System.Drawing.Size(19, 24);
            this.lblEinschraenkungSA.TabIndex = 31;
            this.lblEinschraenkungSA.Text = "SA";
            this.lblEinschraenkungSA.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblEinschraenkungDO
            // 
            this.lblEinschraenkungDO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblEinschraenkungDO.Location = new System.Drawing.Point(360, 0);
            this.lblEinschraenkungDO.Name = "lblEinschraenkungDO";
            this.lblEinschraenkungDO.Size = new System.Drawing.Size(22, 24);
            this.lblEinschraenkungDO.TabIndex = 27;
            this.lblEinschraenkungDO.Text = "DO";
            this.lblEinschraenkungDO.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // edtEinschraenkungDI
            // 
            this.edtEinschraenkungDI.DataMember = "EinschraenkungDI";
            this.edtEinschraenkungDI.DataSource = this.qryBIBIPVermittlung;
            this.edtEinschraenkungDI.Location = new System.Drawing.Point(109, 29);
            this.edtEinschraenkungDI.Name = "edtEinschraenkungDI";
            this.edtEinschraenkungDI.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinschraenkungDI.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinschraenkungDI.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinschraenkungDI.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinschraenkungDI.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinschraenkungDI.Properties.Appearance.Options.UseFont = true;
            this.edtEinschraenkungDI.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEinschraenkungDI.Size = new System.Drawing.Size(100, 68);
            this.edtEinschraenkungDI.TabIndex = 29;
            // 
            // lblEinschraenkungDI
            // 
            this.lblEinschraenkungDI.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblEinschraenkungDI.Location = new System.Drawing.Point(151, 0);
            this.lblEinschraenkungDI.Name = "lblEinschraenkungDI";
            this.lblEinschraenkungDI.Size = new System.Drawing.Size(16, 24);
            this.lblEinschraenkungDI.TabIndex = 2;
            this.lblEinschraenkungDI.Text = "DI";
            this.lblEinschraenkungDI.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // edtEinschraenkungMO
            // 
            this.edtEinschraenkungMO.DataMember = "EinschraenkungMO";
            this.edtEinschraenkungMO.DataSource = this.qryBIBIPVermittlung;
            this.edtEinschraenkungMO.Location = new System.Drawing.Point(3, 29);
            this.edtEinschraenkungMO.Name = "edtEinschraenkungMO";
            this.edtEinschraenkungMO.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinschraenkungMO.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinschraenkungMO.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinschraenkungMO.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinschraenkungMO.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinschraenkungMO.Properties.Appearance.Options.UseFont = true;
            this.edtEinschraenkungMO.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEinschraenkungMO.Size = new System.Drawing.Size(100, 68);
            this.edtEinschraenkungMO.TabIndex = 28;
            // 
            // lbEinschraenkungMI
            // 
            this.lbEinschraenkungMI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbEinschraenkungMI.Location = new System.Drawing.Point(256, 0);
            this.lbEinschraenkungMI.Name = "lbEinschraenkungMI";
            this.lbEinschraenkungMI.Size = new System.Drawing.Size(17, 24);
            this.lbEinschraenkungMI.TabIndex = 24;
            this.lbEinschraenkungMI.Text = "MI";
            this.lbEinschraenkungMI.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // edtEinschraenkungMI
            // 
            this.edtEinschraenkungMI.DataMember = "EinschraenkungMI";
            this.edtEinschraenkungMI.DataSource = this.qryBIBIPVermittlung;
            this.edtEinschraenkungMI.Location = new System.Drawing.Point(215, 29);
            this.edtEinschraenkungMI.Name = "edtEinschraenkungMI";
            this.edtEinschraenkungMI.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinschraenkungMI.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinschraenkungMI.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinschraenkungMI.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinschraenkungMI.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinschraenkungMI.Properties.Appearance.Options.UseFont = true;
            this.edtEinschraenkungMI.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEinschraenkungMI.Size = new System.Drawing.Size(100, 68);
            this.edtEinschraenkungMI.TabIndex = 30;
            // 
            // lbEinschraenkungMO
            // 
            this.lbEinschraenkungMO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbEinschraenkungMO.Location = new System.Drawing.Point(42, 0);
            this.lbEinschraenkungMO.Name = "lbEinschraenkungMO";
            this.lbEinschraenkungMO.Size = new System.Drawing.Size(21, 24);
            this.lbEinschraenkungMO.TabIndex = 0;
            this.lbEinschraenkungMO.Text = "MO";
            // 
            // edtEinschraenkungDO
            // 
            this.edtEinschraenkungDO.DataMember = "EinschraenkungDO";
            this.edtEinschraenkungDO.DataSource = this.qryBIBIPVermittlung;
            this.edtEinschraenkungDO.Location = new System.Drawing.Point(321, 29);
            this.edtEinschraenkungDO.Name = "edtEinschraenkungDO";
            this.edtEinschraenkungDO.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinschraenkungDO.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinschraenkungDO.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinschraenkungDO.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinschraenkungDO.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinschraenkungDO.Properties.Appearance.Options.UseFont = true;
            this.edtEinschraenkungDO.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEinschraenkungDO.Size = new System.Drawing.Size(100, 68);
            this.edtEinschraenkungDO.TabIndex = 31;
            // 
            // edtEinschraenkungFR
            // 
            this.edtEinschraenkungFR.DataMember = "EinschraenkungFR";
            this.edtEinschraenkungFR.DataSource = this.qryBIBIPVermittlung;
            this.edtEinschraenkungFR.Location = new System.Drawing.Point(427, 29);
            this.edtEinschraenkungFR.Name = "edtEinschraenkungFR";
            this.edtEinschraenkungFR.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinschraenkungFR.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinschraenkungFR.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinschraenkungFR.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinschraenkungFR.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinschraenkungFR.Properties.Appearance.Options.UseFont = true;
            this.edtEinschraenkungFR.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEinschraenkungFR.Size = new System.Drawing.Size(100, 68);
            this.edtEinschraenkungFR.TabIndex = 32;
            // 
            // lblEinschraenkungFR
            // 
            this.lblEinschraenkungFR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblEinschraenkungFR.Location = new System.Drawing.Point(466, 0);
            this.lblEinschraenkungFR.Name = "lblEinschraenkungFR";
            this.lblEinschraenkungFR.Size = new System.Drawing.Size(21, 24);
            this.lblEinschraenkungFR.TabIndex = 29;
            this.lblEinschraenkungFR.Text = "FR";
            this.lblEinschraenkungFR.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // edtAktuelleTaetigkeit
            // 
            this.edtAktuelleTaetigkeit.DataMember = "AktuelleTaetigkeit";
            this.edtAktuelleTaetigkeit.DataSource = this.qryBIBIPVermittlung;
            this.edtAktuelleTaetigkeit.Location = new System.Drawing.Point(152, 221);
            this.edtAktuelleTaetigkeit.Name = "edtAktuelleTaetigkeit";
            this.edtAktuelleTaetigkeit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAktuelleTaetigkeit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAktuelleTaetigkeit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAktuelleTaetigkeit.Properties.Appearance.Options.UseBackColor = true;
            this.edtAktuelleTaetigkeit.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAktuelleTaetigkeit.Properties.Appearance.Options.UseFont = true;
            this.edtAktuelleTaetigkeit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAktuelleTaetigkeit.Size = new System.Drawing.Size(375, 24);
            this.edtAktuelleTaetigkeit.TabIndex = 26;
            // 
            // lblAktuelleTaetigkeit
            // 
            this.lblAktuelleTaetigkeit.AutoSize = true;
            this.lblAktuelleTaetigkeit.Location = new System.Drawing.Point(9, 219);
            this.lblAktuelleTaetigkeit.Name = "lblAktuelleTaetigkeit";
            this.lblAktuelleTaetigkeit.Size = new System.Drawing.Size(120, 43);
            this.lblAktuelleTaetigkeit.TabIndex = 20;
            this.lblAktuelleTaetigkeit.Text = "Aktuelle Tätigkeit inkl.\r\nBildung/Praktika\r\n ";
            this.lblAktuelleTaetigkeit.UseCompatibleTextRendering = true;
            // 
            // lblBemerkungen1
            // 
            this.lblBemerkungen1.Location = new System.Drawing.Point(9, 414);
            this.lblBemerkungen1.Name = "lblBemerkungen1";
            this.lblBemerkungen1.Size = new System.Drawing.Size(137, 24);
            this.lblBemerkungen1.TabIndex = 19;
            this.lblBemerkungen1.Text = "Bemerkungen";
            this.lblBemerkungen1.UseCompatibleTextRendering = true;
            // 
            // lblAusbildung
            // 
            this.lblAusbildung.Location = new System.Drawing.Point(10, 44);
            this.lblAusbildung.Name = "lblAusbildung";
            this.lblAusbildung.Size = new System.Drawing.Size(137, 24);
            this.lblAusbildung.TabIndex = 18;
            this.lblAusbildung.Text = "Ausbildung";
            this.lblAusbildung.UseCompatibleTextRendering = true;
            // 
            // lblbesondereWünsche
            // 
            this.lblbesondereWünsche.Location = new System.Drawing.Point(9, 192);
            this.lblbesondereWünsche.Name = "lblbesondereWünsche";
            this.lblbesondereWünsche.Size = new System.Drawing.Size(137, 24);
            this.lblbesondereWünsche.TabIndex = 14;
            this.lblbesondereWünsche.Text = "Besondere Wünsche";
            this.lblbesondereWünsche.UseCompatibleTextRendering = true;
            // 
            // lblKABetriebe
            // 
            this.lblKABetriebe.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblKABetriebe.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblKABetriebe.Location = new System.Drawing.Point(437, 76);
            this.lblKABetriebe.Name = "lblKABetriebe";
            this.lblKABetriebe.Size = new System.Drawing.Size(100, 18);
            this.lblKABetriebe.TabIndex = 13;
            this.lblKABetriebe.Text = "KA-Betriebe";
            this.lblKABetriebe.UseCompatibleTextRendering = true;
            // 
            // lblBranche
            // 
            this.lblBranche.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblBranche.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblBranche.Location = new System.Drawing.Point(10, 76);
            this.lblBranche.Name = "lblBranche";
            this.lblBranche.Size = new System.Drawing.Size(87, 18);
            this.lblBranche.TabIndex = 12;
            this.lblBranche.Text = "Branchen";
            this.lblBranche.UseCompatibleTextRendering = true;
            // 
            // lblProzent
            // 
            this.lblProzent.Location = new System.Drawing.Point(207, 14);
            this.lblProzent.Name = "lblProzent";
            this.lblProzent.Size = new System.Drawing.Size(17, 24);
            this.lblProzent.TabIndex = 11;
            this.lblProzent.Text = "%";
            this.lblProzent.UseCompatibleTextRendering = true;
            // 
            // lblEinsatzpensum
            // 
            this.lblEinsatzpensum.Location = new System.Drawing.Point(10, 14);
            this.lblEinsatzpensum.Name = "lblEinsatzpensum";
            this.lblEinsatzpensum.Size = new System.Drawing.Size(136, 24);
            this.lblEinsatzpensum.TabIndex = 10;
            this.lblEinsatzpensum.Text = "Einsatzpensum";
            this.lblEinsatzpensum.UseCompatibleTextRendering = true;
            // 
            // btnEinsatzplatzSuchen
            // 
            this.btnEinsatzplatzSuchen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEinsatzplatzSuchen.Location = new System.Drawing.Point(152, 501);
            this.btnEinsatzplatzSuchen.Name = "btnEinsatzplatzSuchen";
            this.btnEinsatzplatzSuchen.Size = new System.Drawing.Size(140, 24);
            this.btnEinsatzplatzSuchen.TabIndex = 37;
            this.btnEinsatzplatzSuchen.Text = "Einsatzplatz suchen";
            this.btnEinsatzplatzSuchen.UseCompatibleTextRendering = true;
            this.btnEinsatzplatzSuchen.UseVisualStyleBackColor = false;
            this.btnEinsatzplatzSuchen.Click += new System.EventHandler(this.btnEinsatzplatzSuchen_Click);
            // 
            // edtArbeitgebietBemerkungen
            // 
            this.edtArbeitgebietBemerkungen.DataMember = "ArbeitsgebietBemerkungen";
            this.edtArbeitgebietBemerkungen.DataSource = this.qryBIBIPVermittlung;
            this.edtArbeitgebietBemerkungen.Location = new System.Drawing.Point(152, 414);
            this.edtArbeitgebietBemerkungen.Name = "edtArbeitgebietBemerkungen";
            this.edtArbeitgebietBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtArbeitgebietBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtArbeitgebietBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtArbeitgebietBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtArbeitgebietBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtArbeitgebietBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.edtArbeitgebietBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtArbeitgebietBemerkungen.Size = new System.Drawing.Size(537, 80);
            this.edtArbeitgebietBemerkungen.TabIndex = 36;
            // 
            // edtAusbildung
            // 
            this.edtAusbildung.DataMember = "AusbildungCode";
            this.edtAusbildung.DataSource = this.qryBIBIPVermittlung;
            this.edtAusbildung.Location = new System.Drawing.Point(152, 44);
            this.edtAusbildung.LOVFilter = "Code in (4,5,6)";
            this.edtAusbildung.LOVFilterWhereAppend = true;
            this.edtAusbildung.LOVName = "KaAusbildung";
            this.edtAusbildung.Name = "edtAusbildung";
            this.edtAusbildung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAusbildung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAusbildung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAusbildung.Properties.Appearance.Options.UseBackColor = true;
            this.edtAusbildung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAusbildung.Properties.Appearance.Options.UseFont = true;
            this.edtAusbildung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAusbildung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAusbildung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAusbildung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAusbildung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject18.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject18.Options.UseBackColor = true;
            this.edtAusbildung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject18)});
            this.edtAusbildung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAusbildung.Properties.NullText = "";
            this.edtAusbildung.Properties.ShowFooter = false;
            this.edtAusbildung.Properties.ShowHeader = false;
            this.edtAusbildung.Size = new System.Drawing.Size(285, 24);
            this.edtAusbildung.TabIndex = 22;
            // 
            // edtBesondereWuensche
            // 
            this.edtBesondereWuensche.DataMember = "BesondereWuensche";
            this.edtBesondereWuensche.DataSource = this.qryBIBIPVermittlung;
            this.edtBesondereWuensche.Location = new System.Drawing.Point(152, 191);
            this.edtBesondereWuensche.Name = "edtBesondereWuensche";
            this.edtBesondereWuensche.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBesondereWuensche.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBesondereWuensche.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBesondereWuensche.Properties.Appearance.Options.UseBackColor = true;
            this.edtBesondereWuensche.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBesondereWuensche.Properties.Appearance.Options.UseFont = true;
            this.edtBesondereWuensche.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBesondereWuensche.Size = new System.Drawing.Size(375, 24);
            this.edtBesondereWuensche.TabIndex = 25;
            // 
            // edtKaBetriebe
            // 
            this.edtKaBetriebe.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKaBetriebe.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKaBetriebe.Appearance.Options.UseBackColor = true;
            this.edtKaBetriebe.Appearance.Options.UseBorderColor = true;
            this.edtKaBetriebe.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtKaBetriebe.CheckOnClick = true;
            this.edtKaBetriebe.DataMember = "KaBetriebCodes";
            this.edtKaBetriebe.DataSource = this.qryBIBIPVermittlung;
            this.edtKaBetriebe.Location = new System.Drawing.Point(437, 97);
            this.edtKaBetriebe.LOVName = "KaVermittlungKaBetriebe";
            this.edtKaBetriebe.Name = "edtKaBetriebe";
            this.edtKaBetriebe.Size = new System.Drawing.Size(110, 74);
            this.edtKaBetriebe.TabIndex = 24;
            // 
            // edtBranchen
            // 
            this.edtBranchen.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBranchen.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBranchen.Appearance.Options.UseBackColor = true;
            this.edtBranchen.Appearance.Options.UseBorderColor = true;
            this.edtBranchen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtBranchen.CheckOnClick = true;
            this.edtBranchen.DataMember = "BrancheCodes";
            this.edtBranchen.DataSource = this.qryBIBIPVermittlung;
            this.edtBranchen.Location = new System.Drawing.Point(10, 97);
            this.edtBranchen.LOVName = "KaBranche";
            this.edtBranchen.MultiColumn = true;
            this.edtBranchen.Name = "edtBranchen";
            this.edtBranchen.Size = new System.Drawing.Size(404, 88);
            this.edtBranchen.TabIndex = 23;
            // 
            // edtPensum
            // 
            this.edtPensum.DataMember = "Einsatzpensum";
            this.edtPensum.DataSource = this.qryBIBIPVermittlung;
            this.edtPensum.Location = new System.Drawing.Point(152, 14);
            this.edtPensum.Name = "edtPensum";
            this.edtPensum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtPensum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPensum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPensum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPensum.Properties.Appearance.Options.UseBackColor = true;
            this.edtPensum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPensum.Properties.Appearance.Options.UseFont = true;
            this.edtPensum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPensum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPensum.Size = new System.Drawing.Size(50, 24);
            this.edtPensum.TabIndex = 21;
            this.edtPensum.Leave += new System.EventHandler(this.checkPensum);
            // 
            // CtlKaVermittlungBIBIPVermittlungsprofil
            // 
            this.ActiveSQLQuery = this.qryBIBIPVermittlung;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(900, 750);
            this.Controls.Add(this.tabVermittlungsprofil);
            this.Controls.Add(this.pnTitle);
            this.Name = "CtlKaVermittlungBIBIPVermittlungsprofil";
            this.Size = new System.Drawing.Size(914, 755);
            this.pnTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            this.tabVermittlungsprofil.ResumeLayout(false);
            this.tpgPersoenlichesProfil.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtDummy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDummy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPCKenntnisse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPCKenntnisse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBIBIPVermittlung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPCKenntnisse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFuehrerausweis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFuehrerausweis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFuehrerausweis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLaufendeBetreibungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKaLaufendeBetreibungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKaLaufendeBetreibungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKaLohnabtretungSD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKaLohnabtretungSD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKaLohnabtretungSD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKaSchweizerdeutsch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKaSchweizerdeutsch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKaSchweizerdeutsch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAeussereErscheinung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAeussereErscheinung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbläussereErscheinung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMotivation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMotivation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMotivation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZuverlaessigkeit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZuverlaessigkeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZuverlässigkeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDiverses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinschraenkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinschränkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGesundheitKoerperlich.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGesundheitKoerperlich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGesundheit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchtart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchtart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchtart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucht.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelGesundheit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVermittelbarkeitDetails.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVermittelbarkeit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVermittelbarkeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVermittelbarkeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelVermittelbarkeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDeutschSchriftlich.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDeutschSchriftlich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblschriftlich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAmTelefonVerstaendigen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDeutschMuendlich.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDeutschMuendlich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblmündlich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerständigungDeutsch)).EndInit();
            this.tpgArbeitsgebiet.ResumeLayout(false);
            this.tpgArbeitsgebiet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerfuegbarkeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKaVerfuegbarkeit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKaVerfuegbarkeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKaNachtarbeitCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKaNachtarbeitCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKaNachtarbeit)).EndInit();
            this.panVerfuegbarkeit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtEinschraenkungSA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinschraenkungSO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinschraenkungSO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinschraenkungSA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinschraenkungDO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinschraenkungDI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinschraenkungDI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinschraenkungMO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbEinschraenkungMI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinschraenkungMI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbEinschraenkungMO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinschraenkungDO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinschraenkungFR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinschraenkungFR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAktuelleTaetigkeit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAktuelleTaetigkeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusbildung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbesondereWünsche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKABetriebe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBranche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProzent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzpensum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtArbeitgebietBemerkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusbildung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusbildung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBesondereWuensche.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKaBetriebe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBranchen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPensum.Properties)).EndInit();
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

        #region EventHandlers

        private void btnEinsatzplatzSuchen_Click(object sender, System.EventArgs e)
        {
            FormController.OpenForm("FrmKaEinsatzorte");
            if (qryBIBIPVermittlung.Count > 0)
                FormController.SendMessage("FrmKaEinsatzorte", "Action", "JumpToEPSuchen", "BrancheCodes", qryBIBIPVermittlung["BrancheCodes"]);
            else
                FormController.SendMessage("FrmKaEinsatzorte", "Action", "JumpToEPSuchen");
        }

        private void edtKaVerfuegbarkeit_EditValueChanged(object sender, EventArgs e)
        {
            bool isVerfugbarkeitEingeschankt = !Convert.IsDBNull(edtKaVerfuegbarkeit.EditValue) && (int)edtKaVerfuegbarkeit.EditValue == 2; //2: eingeschränkt

            setEditModeToPanVerfugbarkeit(isVerfugbarkeitEingeschankt);
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string FieldName)
        {
            switch (FieldName.ToUpper())
            {
                case "FALEISTUNGID":
                    return faLeistungID;

                case "BAPERSONID":
                    return (int)DBUtil.ExecuteScalarSQL("select BaPersonID from FaLeistung where FaLeistungID = {0}", faLeistungID);

                case "KAVERMITTLUNGPROFILID":
                    return qryBIBIPVermittlung["KaVermittlungProfilID"];

                case "OWNERUSERID":
                    return (int)DBUtil.ExecuteScalarSQL("select UserID from FaLeistung where FaLeistungID = {0}", faLeistungID);
            }

            return base.GetContextValue(FieldName);
        }

        // ComponentName: qryBIBIPVermittlung
        public void Init(string maskName, Image maskImage, int FaLeistungID, int BaPersonID)
        {
            this.lblTitle.Text = maskName;
            this.imageTitle.Image = maskImage;
            this.faLeistungID = FaLeistungID;
            this.baPersonID = BaPersonID;

            tabVermittlungsprofil.SelectedTabIndex = 0;
            DBUtil.GetFallRights(this.faLeistungID, out MayRead, out MayIns, out MayUpd, out MayDel, out MayClose, out MayReopen);

            if (!VermittlungExists() && DBUtil.UserHasRight("CtlKaVermittlungBIBIPVermittlungsprofil", "UI") && (MayUpd || MayIns))
            {
                DBUtil.ExecSQL(@"
                  INSERT INTO dbo.KaVermittlungProfil (FaLeistungID, SichtbarSDFlag, Creator, Created, Modifier, Modified)
                  VALUES ({0}, {1}, {2}, GETDATE(), {2}, GETDATE())",
                  faLeistungID, KaUtil.IsVisibleSD(baPersonID),
                  DBUtil.GetDBRowCreatorModifier());
            }

            qryBIBIPVermittlung.Fill(faLeistungID, Session.User.IsUserKA ? 0 : 1);

            ControlsEnableDisable();
        }

        #endregion

        #region Private Methods

        private void checkPensum(object sender, System.EventArgs e)
        {
            if (!DBUtil.IsEmpty(((KiSS4.Gui.KissCalcEdit)sender).EditValue))
            {
                if (Convert.ToInt32(((KiSS4.Gui.KissCalcEdit)sender).EditValue) > 100)
                {
                    KissMsg.ShowInfo("CtlKaVermittlungBIBIPVermittlungsprofil", "PensumZuGross", "Pensum darf nicht höher sein als 100%!");
                    ((KiSS4.Gui.KissCalcEdit)sender).Focus();
                }
            }
        }

        private void ControlsEnableDisable()
        {
            btnEinsatzplatzSuchen.Enabled = (DBUtil.UserHasRight("CtlKaVermittlungBIBIPVermittlungsprofil", "UI") && (MayUpd || MayIns));

            if (KaUtil.GetSichtbarSDFlag(this.baPersonID) == 1)
            {
                qryBIBIPVermittlung.EnableBoundFields(false);
                btnVermittlungsgespraech.Enabled = false;
                btnEinsatzplatzSuchen.Enabled = false;
            }
        }

        private void setEditModeToPanVerfugbarkeit(bool editierbar)
        {
            var editModeWoche = editierbar ? EditModeType.Normal : EditModeType.ReadOnly;

            edtEinschraenkungMO.EditMode = editModeWoche;
            edtEinschraenkungDI.EditMode = editModeWoche;
            edtEinschraenkungMI.EditMode = editModeWoche;
            edtEinschraenkungDO.EditMode = editModeWoche;
            edtEinschraenkungFR.EditMode = editModeWoche;
            edtEinschraenkungSA.EditMode = editModeWoche;
            edtEinschraenkungSO.EditMode = editModeWoche;
        }

        private bool VermittlungExists()
        {
            bool rslt = false;

            rslt = Convert.ToInt32(
                DBUtil.ExecuteScalarSQL(@"select count(*) from KaVermittlungProfil where FaLeistungID = {0}",
                this.faLeistungID)
                ) > 0;

            return rslt;
        }

        #endregion

        #endregion
    }
}