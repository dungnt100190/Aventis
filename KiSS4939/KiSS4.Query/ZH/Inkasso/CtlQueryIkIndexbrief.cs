using System;
using System.Data;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query.ZH
{
    public class CtlQueryIkIndexbrief : KissQueryControl
    {
        #region Fields

        #region Private Fields

        private int _filterUserID = 0;
        private string _filterUserText = "";
        private DateTime _oldDate = DateTime.Today;
        private int _oldIndexArt = 1;
        private int _oldYear = DateTime.Today.Year;
        private KiSS4.Gui.KissButton btnCreate;
        private KiSS4.Gui.KissButton btnUndo;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumPer;
        private DevExpress.XtraGrid.Columns.GridColumn colFalltraegerFallNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colFalltraegerName;
        private DevExpress.XtraGrid.Columns.GridColumn colFalltraegerPersonenNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colFalltraegerVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colFalltraeger_FallNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colFalltraeger_Name;
        private DevExpress.XtraGrid.Columns.GridColumn colFalltraeger_PersonenNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colFalltraeger_Vorname;
        private DevExpress.XtraGrid.Columns.GridColumn colFrdrgBetragBasis;
        private DevExpress.XtraGrid.Columns.GridColumn colFrdrgDatumAb;
        private DevExpress.XtraGrid.Columns.GridColumn colFrdrgForderungstitel;
        private DevExpress.XtraGrid.Columns.GridColumn colFrdrgGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colFrdrgGueltigbis;
        private DevExpress.XtraGrid.Columns.GridColumn colFrdrgVornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colFrdrg_BetragBasis;
        private DevExpress.XtraGrid.Columns.GridColumn colFrdrg_DatumAb;
        private DevExpress.XtraGrid.Columns.GridColumn colFrdrg_Forderungstitel;
        private DevExpress.XtraGrid.Columns.GridColumn colFrdrg_Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colFrdrg_Gueltigbis;
        private DevExpress.XtraGrid.Columns.GridColumn colFrdrg_VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb01BetragBasis;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb01BetragBerechnet;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb01BetragKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb01Forderungstitel;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb01Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb01IndexPunkte;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb01Teuerungseinsprache;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb01VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb01_BetragBasis;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb01_BetragBerechnet;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb01_BetragKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb01_Forderungstitel;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb01_Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb01_IndexPunkte;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb01_Teuerungseinsprache;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb01_VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb02BetragBasis;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb02BetragBerechnet;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb02BetragKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb02Forderungstitel;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb02Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb02IndexPunkte;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb02Teuerungseinsprache;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb02VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb02_BetragBasis;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb02_BetragBerechnet;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb02_BetragKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb02_Forderungstitel;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb02_Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb02_IndexPunkte;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb02_Teuerungseinsprache;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb02_VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb03BetragBasis;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb03BetragBerechnet;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb03BetragKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb03Forderungstitel;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb03Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb03IndexPunkte;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb03Teuerungseinsprache;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb03VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb03_BetragBasis;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb03_BetragBerechnet;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb03_BetragKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb03_Forderungstitel;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb03_Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb03_IndexPunkte;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb03_Teuerungseinsprache;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb03_VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb04BetragBasis;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb04BetragBerechnet;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb04BetragKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb04Forderungstitel;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb04Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb04IndexPunkte;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb04Teuerungseinsprache;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb04VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb04_BetragBasis;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb04_BetragBerechnet;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb04_BetragKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb04_Forderungstitel;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb04_Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb04_IndexPunkte;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb04_Teuerungseinsprache;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb04_VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb05BetragBasis;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb05BetragBerechnet;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb05BetragKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb05Forderungstitel;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb05Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb05IndexPunkte;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb05Teuerungseinsprache;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb05VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb05_BetragBasis;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb05_BetragBerechnet;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb05_BetragKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb05_Forderungstitel;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb05_Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb05_IndexPunkte;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb05_Teuerungseinsprache;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb05_VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb06BetragBasis;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb06BetragBerechnet;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb06BetragKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb06Forderungstitel;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb06Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb06IndexPunkte;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb06Teuerungseinsprache;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb06VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb06_BetragBasis;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb06_BetragBerechnet;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb06_BetragKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb06_Forderungstitel;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb06_Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb06_IndexPunkte;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb06_Teuerungseinsprache;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb06_VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb07BetragBasis;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb07BetragBerechnet;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb07BetragKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb07Forderungstitel;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb07Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb07IndexPunkte;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb07Teuerungseinsprache;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb07VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb07_BetragBasis;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb07_BetragBerechnet;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb07_BetragKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb07_Forderungstitel;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb07_Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb07_IndexPunkte;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb07_Teuerungseinsprache;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb07_VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb08BetragBasis;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb08BetragBerechnet;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb08BetragKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb08Forderungstitel;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb08Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb08IndexPunkte;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb08Teuerungseinsprache;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb08VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb08_BetragBasis;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb08_BetragBerechnet;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb08_BetragKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb08_Forderungstitel;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb08_Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb08_IndexPunkte;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb08_Teuerungseinsprache;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb08_VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb09BetragBasis;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb09BetragBerechnet;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb09BetragKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb09Forderungstitel;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb09Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb09IndexPunkte;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb09Teuerungseinsprache;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb09VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb09_BetragBasis;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb09_BetragBerechnet;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb09_BetragKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb09_Forderungstitel;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb09_Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb09_IndexPunkte;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb09_Teuerungseinsprache;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb09_VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb10BetragBasis;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb10BetragBerechnet;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb10BetragKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb10Forderungstitel;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb10Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb10IndexPunkte;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb10Teuerungseinsprache;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb10VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb10_BetragBasis;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb10_BetragBerechnet;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb10_BetragKiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb10_Forderungstitel;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb10_Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb10_IndexPunkte;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb10_Teuerungseinsprache;
        private DevExpress.XtraGrid.Columns.GridColumn colGlb10_VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colKopieAn;
        private DevExpress.XtraGrid.Columns.GridColumn colKopieAnQT;
        private DevExpress.XtraGrid.Columns.GridColumn colKopieAnSZ;
        private DevExpress.XtraGrid.Columns.GridColumn colKopieAn_QT;
        private DevExpress.XtraGrid.Columns.GridColumn colKopieAn_SZ;
        private DevExpress.XtraGrid.Columns.GridColumn colLaufendesJahr;
        private DevExpress.XtraGrid.Columns.GridColumn colRTDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colRTIndexPunkte;
        private DevExpress.XtraGrid.Columns.GridColumn colRTIndexStand;
        private DevExpress.XtraGrid.Columns.GridColumn colRTIndexTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colRTInfo;
        private DevExpress.XtraGrid.Columns.GridColumn colRTTeuerungseinsprache;
        private DevExpress.XtraGrid.Columns.GridColumn colRTTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colRT_Datum;
        private DevExpress.XtraGrid.Columns.GridColumn colRT_IndexPunkte;
        private DevExpress.XtraGrid.Columns.GridColumn colRT_IndexStand;
        private DevExpress.XtraGrid.Columns.GridColumn colRT_IndexTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colRT_Info;
        private DevExpress.XtraGrid.Columns.GridColumn colRT_Teuerungseinsprache;
        private DevExpress.XtraGrid.Columns.GridColumn colRT_Typ;
        private DevExpress.XtraGrid.Columns.GridColumn colSBDisplayname;
        private DevExpress.XtraGrid.Columns.GridColumn colSBLogonName;
        private DevExpress.XtraGrid.Columns.GridColumn colSBVornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colSB_Displayname;
        private DevExpress.XtraGrid.Columns.GridColumn colSB_LogonName;
        private DevExpress.XtraGrid.Columns.GridColumn colSB_VornameName;
        private DevExpress.XtraGrid.Columns.GridColumn colSchuldnerAnrede;
        private DevExpress.XtraGrid.Columns.GridColumn colSchuldnerName;
        private DevExpress.XtraGrid.Columns.GridColumn colSchuldnerOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colSchuldnerPLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colSchuldnerPersonenNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colSchuldnerPostfach;
        private DevExpress.XtraGrid.Columns.GridColumn colSchuldnerStrasse;
        private DevExpress.XtraGrid.Columns.GridColumn colSchuldnerVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colSchuldnerZusatz;
        private DevExpress.XtraGrid.Columns.GridColumn colSchuldner_Anrede;
        private DevExpress.XtraGrid.Columns.GridColumn colSchuldner_Name;
        private DevExpress.XtraGrid.Columns.GridColumn colSchuldner_Ort;
        private DevExpress.XtraGrid.Columns.GridColumn colSchuldner_PLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colSchuldner_PersonenNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colSchuldner_Postfach;
        private DevExpress.XtraGrid.Columns.GridColumn colSchuldner_Strasse;
        private DevExpress.XtraGrid.Columns.GridColumn colSchuldner_Vorname;
        private DevExpress.XtraGrid.Columns.GridColumn colSchuldner_Zusatz;
        private DevExpress.XtraGrid.Columns.GridColumn colSummeBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colSumme_Betrag;
        private DevExpress.XtraGrid.Columns.GridColumn colVorhergehendesJahr;
        private KiSS4.Gui.KissDateEdit edtDatumPer;
        private KiSS4.Gui.KissLookUpEdit edtIndexart;
        private KiSS4.Gui.KissLabel edtSachbearbeiter;
        private KiSS4.Gui.KissButtonEdit edtUser;
        private KiSS4.Gui.KissComboBox edtYear;
        private KiSS4.Gui.KissCheckEdit edtchkDelete;
        private DevExpress.XtraGrid.Views.Grid.GridView gvwQuery;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissLabel kissLabel3;
        private KiSS4.Gui.KissLabel lblCount;

        #endregion

        #endregion

        #region Constructors

        public CtlQueryIkIndexbrief()
        {
            InitializeComponent();
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryIkIndexbrief));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnCreate = new KiSS4.Gui.KissButton();
            this.btnUndo = new KiSS4.Gui.KissButton();
            this.lblCount = new KiSS4.Gui.KissLabel();
            this.edtSachbearbeiter = new KiSS4.Gui.KissLabel();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.edtUser = new KiSS4.Gui.KissButtonEdit();
            this.edtIndexart = new KiSS4.Gui.KissLookUpEdit();
            this.edtDatumPer = new KiSS4.Gui.KissDateEdit();
            this.edtYear = new KiSS4.Gui.KissComboBox();
            this.edtchkDelete = new KiSS4.Gui.KissCheckEdit();
            this.colDatumPer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFalltraeger_FallNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFalltraeger_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFalltraeger_PersonenNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFalltraeger_Vorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFalltraegerFallNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFalltraegerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFalltraegerPersonenNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFalltraegerVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFrdrg_BetragBasis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFrdrg_DatumAb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFrdrg_Forderungstitel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFrdrg_Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFrdrg_Gueltigbis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFrdrg_VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFrdrgBetragBasis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFrdrgDatumAb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFrdrgForderungstitel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFrdrgGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFrdrgGueltigbis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFrdrgVornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb01_BetragBasis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb01_BetragBerechnet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb01_BetragKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb01_Forderungstitel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb01_Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb01_IndexPunkte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb01_Teuerungseinsprache = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb01_VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb01BetragBasis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb01BetragBerechnet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb01BetragKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb01Forderungstitel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb01Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb01IndexPunkte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb01Teuerungseinsprache = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb01VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb02_BetragBasis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb02_BetragBerechnet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb02_BetragKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb02_Forderungstitel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb02_Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb02_IndexPunkte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb02_Teuerungseinsprache = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb02_VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb02BetragBasis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb02BetragBerechnet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb02BetragKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb02Forderungstitel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb02Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb02IndexPunkte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb02Teuerungseinsprache = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb02VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb03_BetragBasis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb03_BetragBerechnet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb03_BetragKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb03_Forderungstitel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb03_Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb03_IndexPunkte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb03_Teuerungseinsprache = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb03_VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb03BetragBasis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb03BetragBerechnet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb03BetragKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb03Forderungstitel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb03Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb03IndexPunkte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb03Teuerungseinsprache = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb03VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb04_BetragBasis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb04_BetragBerechnet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb04_BetragKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb04_Forderungstitel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb04_Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb04_IndexPunkte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb04_Teuerungseinsprache = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb04_VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb04BetragBasis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb04BetragBerechnet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb04BetragKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb04Forderungstitel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb04Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb04IndexPunkte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb04Teuerungseinsprache = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb04VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb05_BetragBasis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb05_BetragBerechnet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb05_BetragKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb05_Forderungstitel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb05_Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb05_IndexPunkte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb05_Teuerungseinsprache = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb05_VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb05BetragBasis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb05BetragBerechnet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb05BetragKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb05Forderungstitel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb05Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb05IndexPunkte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb05Teuerungseinsprache = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb05VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb06_BetragBasis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb06_BetragBerechnet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb06_BetragKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb06_Forderungstitel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb06_Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb06_IndexPunkte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb06_Teuerungseinsprache = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb06_VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb06BetragBasis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb06BetragBerechnet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb06BetragKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb06Forderungstitel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb06Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb06IndexPunkte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb06Teuerungseinsprache = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb06VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb07_BetragBasis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb07_BetragBerechnet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb07_BetragKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb07_Forderungstitel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb07_Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb07_IndexPunkte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb07_Teuerungseinsprache = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb07_VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb07BetragBasis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb07BetragBerechnet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb07BetragKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb07Forderungstitel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb07Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb07IndexPunkte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb07Teuerungseinsprache = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb07VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb08_BetragBasis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb08_BetragBerechnet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb08_BetragKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb08_Forderungstitel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb08_Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb08_IndexPunkte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb08_Teuerungseinsprache = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb08_VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb08BetragBasis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb08BetragBerechnet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb08BetragKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb08Forderungstitel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb08Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb08IndexPunkte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb08Teuerungseinsprache = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb08VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb09_BetragBasis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb09_BetragBerechnet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb09_BetragKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb09_Forderungstitel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb09_Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb09_IndexPunkte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb09_Teuerungseinsprache = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb09_VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb09BetragBasis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb09BetragBerechnet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb09BetragKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb09Forderungstitel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb09Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb09IndexPunkte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb09Teuerungseinsprache = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb09VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb10_BetragBasis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb10_BetragBerechnet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb10_BetragKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb10_Forderungstitel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb10_Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb10_IndexPunkte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb10_Teuerungseinsprache = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb10_VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb10BetragBasis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb10BetragBerechnet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb10BetragKiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb10Forderungstitel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb10Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb10IndexPunkte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb10Teuerungseinsprache = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlb10VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKopieAn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKopieAn_QT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKopieAn_SZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKopieAnQT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKopieAnSZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLaufendesJahr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRT_Datum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRT_IndexPunkte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRT_IndexStand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRT_IndexTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRT_Info = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRT_Teuerungseinsprache = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRT_Typ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRTDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRTIndexPunkte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRTIndexStand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRTIndexTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRTInfo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRTTeuerungseinsprache = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRTTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSB_Displayname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSB_LogonName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSB_VornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSBDisplayname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSBLogonName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSBVornameName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchuldner_Anrede = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchuldner_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchuldner_Ort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchuldner_PersonenNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchuldner_PLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchuldner_Postfach = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchuldner_Strasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchuldner_Vorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchuldner_Zusatz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchuldnerAnrede = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchuldnerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchuldnerOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchuldnerPersonenNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchuldnerPLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchuldnerPostfach = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchuldnerStrasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchuldnerVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchuldnerZusatz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSumme_Betrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSummeBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorhergehendesJahr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvwQuery = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSachbearbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIndexart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIndexart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumPer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtchkDelete.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwQuery)).BeginInit();
            this.SuspendLayout();
            //
            // qryQuery
            //
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            this.qryQuery.AfterFill += new System.EventHandler(this.qryQuery_AfterFill);
            //
            // xDocument
            //
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.xDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("xDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "Dokument öffnen")});
            //
            // ctlGotoFall
            //
            this.ctlGotoFall.DataMember = "Falltraeger_PersonenNummer";
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.lblCount);
            this.tpgListe.Controls.Add(this.btnUndo);
            this.tpgListe.Controls.Add(this.btnCreate);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Controls.SetChildIndex(this.ctlGotoFall, 0);
            this.tpgListe.Controls.SetChildIndex(this.xDocument, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnCreate, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnUndo, 0);
            this.tpgListe.Controls.SetChildIndex(this.lblCount, 0);
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.edtchkDelete);
            this.tpgSuchen.Controls.Add(this.edtYear);
            this.tpgSuchen.Controls.Add(this.edtDatumPer);
            this.tpgSuchen.Controls.Add(this.edtIndexart);
            this.tpgSuchen.Controls.Add(this.edtUser);
            this.tpgSuchen.Controls.Add(this.kissLabel3);
            this.tpgSuchen.Controls.Add(this.kissLabel2);
            this.tpgSuchen.Controls.Add(this.kissLabel1);
            this.tpgSuchen.Controls.Add(this.edtSachbearbeiter);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSachbearbeiter, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel1, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel2, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel3, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUser, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtIndexart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumPer, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtYear, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtchkDelete, 0);
            //
            // btnCreate
            //
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Location = new System.Drawing.Point(319, 398);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(190, 24);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "Neue Forderungen erstellen";
            this.btnCreate.UseCompatibleTextRendering = true;
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            //
            // btnUndo
            //
            this.btnUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUndo.Location = new System.Drawing.Point(515, 398);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(90, 24);
            this.btnUndo.TabIndex = 4;
            this.btnUndo.Text = "Alle löschen";
            this.btnUndo.UseCompatibleTextRendering = true;
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Visible = false;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            //
            // lblCount
            //
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCount.Location = new System.Drawing.Point(611, 398);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(158, 24);
            this.lblCount.TabIndex = 5;
            this.lblCount.Text = "kissLabel4";
            this.lblCount.UseCompatibleTextRendering = true;
            //
            // edtSachbearbeiter
            //
            this.edtSachbearbeiter.Location = new System.Drawing.Point(30, 40);
            this.edtSachbearbeiter.Name = "edtSachbearbeiter";
            this.edtSachbearbeiter.Size = new System.Drawing.Size(130, 24);
            this.edtSachbearbeiter.TabIndex = 1;
            this.edtSachbearbeiter.Text = "Sachbearbeiter/in";
            this.edtSachbearbeiter.UseCompatibleTextRendering = true;
            //
            // kissLabel1
            //
            this.kissLabel1.Location = new System.Drawing.Point(30, 70);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(130, 24);
            this.kissLabel1.TabIndex = 3;
            this.kissLabel1.Text = "Indexart";
            this.kissLabel1.UseCompatibleTextRendering = true;
            //
            // kissLabel2
            //
            this.kissLabel2.Location = new System.Drawing.Point(30, 100);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(130, 24);
            this.kissLabel2.TabIndex = 5;
            this.kissLabel2.Text = "Suche im Jahr";
            this.kissLabel2.UseCompatibleTextRendering = true;
            //
            // kissLabel3
            //
            this.kissLabel3.Location = new System.Drawing.Point(30, 130);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(130, 24);
            this.kissLabel3.TabIndex = 7;
            this.kissLabel3.Text = "Neue Forderung per";
            this.kissLabel3.UseCompatibleTextRendering = true;
            //
            // edtUser
            //
            this.edtUser.Location = new System.Drawing.Point(166, 40);
            this.edtUser.Name = "edtUser";
            this.edtUser.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUser.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUser.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUser.Properties.Appearance.Options.UseBackColor = true;
            this.edtUser.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUser.Properties.Appearance.Options.UseFont = true;
            this.edtUser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtUser.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUser.Size = new System.Drawing.Size(400, 24);
            this.edtUser.TabIndex = 2;
            this.edtUser.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtUser_UserModifiedFld);
            //
            // edtIndexart
            //
            this.edtIndexart.Location = new System.Drawing.Point(166, 70);
            this.edtIndexart.LOVFilter = "code in (1,2,3)";
            this.edtIndexart.LOVFilterWhereAppend = true;
            this.edtIndexart.LOVName = "IkAnpassungsRegel";
            this.edtIndexart.Name = "edtIndexart";
            this.edtIndexart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIndexart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIndexart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIndexart.Properties.Appearance.Options.UseBackColor = true;
            this.edtIndexart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIndexart.Properties.Appearance.Options.UseFont = true;
            this.edtIndexart.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtIndexart.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtIndexart.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtIndexart.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtIndexart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtIndexart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtIndexart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIndexart.Properties.NullText = "";
            this.edtIndexart.Properties.ShowFooter = false;
            this.edtIndexart.Properties.ShowHeader = false;
            this.edtIndexart.Size = new System.Drawing.Size(400, 24);
            this.edtIndexart.TabIndex = 4;
            //
            // edtDatumPer
            //
            this.edtDatumPer.EditValue = null;
            this.edtDatumPer.Location = new System.Drawing.Point(166, 130);
            this.edtDatumPer.Name = "edtDatumPer";
            this.edtDatumPer.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumPer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumPer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumPer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumPer.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumPer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumPer.Properties.Appearance.Options.UseFont = true;
            this.edtDatumPer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtDatumPer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumPer.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtDatumPer.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumPer.Properties.ShowToday = false;
            this.edtDatumPer.Size = new System.Drawing.Size(100, 24);
            this.edtDatumPer.TabIndex = 8;
            //
            // edtYear
            //
            this.edtYear.Location = new System.Drawing.Point(166, 100);
            this.edtYear.Name = "edtYear";
            this.edtYear.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtYear.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtYear.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtYear.Properties.Appearance.Options.UseBackColor = true;
            this.edtYear.Properties.Appearance.Options.UseBorderColor = true;
            this.edtYear.Properties.Appearance.Options.UseFont = true;
            this.edtYear.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtYear.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtYear.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtYear.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtYear.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtYear.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtYear.Size = new System.Drawing.Size(100, 24);
            this.edtYear.TabIndex = 6;
            //
            // edtchkDelete
            //
            this.edtchkDelete.EditValue = false;
            this.edtchkDelete.Location = new System.Drawing.Point(166, 169);
            this.edtchkDelete.Name = "edtchkDelete";
            this.edtchkDelete.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtchkDelete.Properties.Appearance.Options.UseBackColor = true;
            this.edtchkDelete.Properties.Caption = "Forderungen löschen";
            this.edtchkDelete.Size = new System.Drawing.Size(228, 19);
            this.edtchkDelete.TabIndex = 9;
            //
            // colDatumPer
            //
            this.colDatumPer.Caption = "DatumPer";
            this.colDatumPer.FieldName = "DatumPer";
            this.colDatumPer.Name = "colDatumPer";
            this.colDatumPer.Visible = true;
            this.colDatumPer.VisibleIndex = 102;
            //
            // colFalltraeger_FallNummer
            //
            this.colFalltraeger_FallNummer.Caption = "Falltraeger_FallNummer";
            this.colFalltraeger_FallNummer.FieldName = "Falltraeger_FallNummer";
            this.colFalltraeger_FallNummer.Name = "colFalltraeger_FallNummer";
            this.colFalltraeger_FallNummer.Visible = true;
            this.colFalltraeger_FallNummer.VisibleIndex = 12;
            //
            // colFalltraeger_Name
            //
            this.colFalltraeger_Name.Caption = "Falltraeger_Name";
            this.colFalltraeger_Name.FieldName = "Falltraeger_Name";
            this.colFalltraeger_Name.Name = "colFalltraeger_Name";
            this.colFalltraeger_Name.Visible = true;
            this.colFalltraeger_Name.VisibleIndex = 9;
            //
            // colFalltraeger_PersonenNummer
            //
            this.colFalltraeger_PersonenNummer.Caption = "Falltraeger_PersonenNummer";
            this.colFalltraeger_PersonenNummer.FieldName = "Falltraeger_PersonenNummer";
            this.colFalltraeger_PersonenNummer.Name = "colFalltraeger_PersonenNummer";
            this.colFalltraeger_PersonenNummer.Visible = true;
            this.colFalltraeger_PersonenNummer.VisibleIndex = 11;
            //
            // colFalltraeger_Vorname
            //
            this.colFalltraeger_Vorname.Caption = "Falltraeger_Vorname";
            this.colFalltraeger_Vorname.FieldName = "Falltraeger_Vorname";
            this.colFalltraeger_Vorname.Name = "colFalltraeger_Vorname";
            this.colFalltraeger_Vorname.Visible = true;
            this.colFalltraeger_Vorname.VisibleIndex = 10;
            //
            // colFalltraegerFallNummer
            //
            this.colFalltraegerFallNummer.Name = "colFalltraegerFallNummer";
            //
            // colFalltraegerName
            //
            this.colFalltraegerName.Name = "colFalltraegerName";
            //
            // colFalltraegerPersonenNummer
            //
            this.colFalltraegerPersonenNummer.Name = "colFalltraegerPersonenNummer";
            //
            // colFalltraegerVorname
            //
            this.colFalltraegerVorname.Name = "colFalltraegerVorname";
            //
            // colFrdrg_BetragBasis
            //
            this.colFrdrg_BetragBasis.Caption = "Betrag";
            this.colFrdrg_BetragBasis.DisplayFormat.FormatString = "N2";
            this.colFrdrg_BetragBasis.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colFrdrg_BetragBasis.FieldName = "Frdrg_BetragBasis";
            this.colFrdrg_BetragBasis.Name = "colFrdrg_BetragBasis";
            this.colFrdrg_BetragBasis.Visible = true;
            this.colFrdrg_BetragBasis.VisibleIndex = 106;
            //
            // colFrdrg_DatumAb
            //
            this.colFrdrg_DatumAb.Caption = "Datum Ab";
            this.colFrdrg_DatumAb.FieldName = "Frdrg_DatumAb";
            this.colFrdrg_DatumAb.Name = "colFrdrg_DatumAb";
            this.colFrdrg_DatumAb.Visible = true;
            this.colFrdrg_DatumAb.VisibleIndex = 107;
            //
            // colFrdrg_Forderungstitel
            //
            this.colFrdrg_Forderungstitel.Caption = "Forderungstitel";
            this.colFrdrg_Forderungstitel.FieldName = "Frdrg_Forderungstitel";
            this.colFrdrg_Forderungstitel.Name = "colFrdrg_Forderungstitel";
            this.colFrdrg_Forderungstitel.Visible = true;
            this.colFrdrg_Forderungstitel.VisibleIndex = 105;
            //
            // colFrdrg_Geburtsdatum
            //
            this.colFrdrg_Geburtsdatum.Caption = "Geburtsdatum";
            this.colFrdrg_Geburtsdatum.FieldName = "Frdrg_Geburtsdatum";
            this.colFrdrg_Geburtsdatum.Name = "colFrdrg_Geburtsdatum";
            this.colFrdrg_Geburtsdatum.Visible = true;
            this.colFrdrg_Geburtsdatum.VisibleIndex = 104;
            //
            // colFrdrg_Gueltigbis
            //
            this.colFrdrg_Gueltigbis.Caption = "Gueltig Bis";
            this.colFrdrg_Gueltigbis.FieldName = "Frdrg_Gueltigbis";
            this.colFrdrg_Gueltigbis.Name = "colFrdrg_Gueltigbis";
            this.colFrdrg_Gueltigbis.Visible = true;
            this.colFrdrg_Gueltigbis.VisibleIndex = 108;
            //
            // colFrdrg_VornameName
            //
            this.colFrdrg_VornameName.Caption = "Gläubiger";
            this.colFrdrg_VornameName.FieldName = "Frdrg_VornameName";
            this.colFrdrg_VornameName.Name = "colFrdrg_VornameName";
            this.colFrdrg_VornameName.Visible = true;
            this.colFrdrg_VornameName.VisibleIndex = 103;
            //
            // colFrdrgBetragBasis
            //
            this.colFrdrgBetragBasis.Name = "colFrdrgBetragBasis";
            //
            // colFrdrgDatumAb
            //
            this.colFrdrgDatumAb.Name = "colFrdrgDatumAb";
            //
            // colFrdrgForderungstitel
            //
            this.colFrdrgForderungstitel.Name = "colFrdrgForderungstitel";
            //
            // colFrdrgGeburtsdatum
            //
            this.colFrdrgGeburtsdatum.Name = "colFrdrgGeburtsdatum";
            //
            // colFrdrgGueltigbis
            //
            this.colFrdrgGueltigbis.Name = "colFrdrgGueltigbis";
            //
            // colFrdrgVornameName
            //
            this.colFrdrgVornameName.Name = "colFrdrgVornameName";
            //
            // colGlb01_BetragBasis
            //
            this.colGlb01_BetragBasis.Caption = "Glb01_BetragBasis";
            this.colGlb01_BetragBasis.DisplayFormat.FormatString = "N2";
            this.colGlb01_BetragBasis.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGlb01_BetragBasis.FieldName = "Glb01_BetragBasis";
            this.colGlb01_BetragBasis.Name = "colGlb01_BetragBasis";
            this.colGlb01_BetragBasis.Visible = true;
            this.colGlb01_BetragBasis.VisibleIndex = 23;
            //
            // colGlb01_BetragBerechnet
            //
            this.colGlb01_BetragBerechnet.Caption = "Glb01_BetragBerechnet";
            this.colGlb01_BetragBerechnet.DisplayFormat.FormatString = "N2";
            this.colGlb01_BetragBerechnet.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGlb01_BetragBerechnet.FieldName = "Glb01_BetragBerechnet";
            this.colGlb01_BetragBerechnet.Name = "colGlb01_BetragBerechnet";
            this.colGlb01_BetragBerechnet.Visible = true;
            this.colGlb01_BetragBerechnet.VisibleIndex = 24;
            //
            // colGlb01_BetragKiZu
            //
            this.colGlb01_BetragKiZu.Caption = "Glb01_BetragKiZu";
            this.colGlb01_BetragKiZu.DisplayFormat.FormatString = "N2";
            this.colGlb01_BetragKiZu.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGlb01_BetragKiZu.FieldName = "Glb01_BetragKiZu";
            this.colGlb01_BetragKiZu.Name = "colGlb01_BetragKiZu";
            this.colGlb01_BetragKiZu.Visible = true;
            this.colGlb01_BetragKiZu.VisibleIndex = 25;
            //
            // colGlb01_Forderungstitel
            //
            this.colGlb01_Forderungstitel.Caption = "Glb01_Forderungstitel";
            this.colGlb01_Forderungstitel.FieldName = "Glb01_Forderungstitel";
            this.colGlb01_Forderungstitel.Name = "colGlb01_Forderungstitel";
            this.colGlb01_Forderungstitel.Visible = true;
            this.colGlb01_Forderungstitel.VisibleIndex = 22;
            //
            // colGlb01_Geburtsdatum
            //
            this.colGlb01_Geburtsdatum.Caption = "Glb01_Geburtsdatum";
            this.colGlb01_Geburtsdatum.FieldName = "Glb01_Geburtsdatum";
            this.colGlb01_Geburtsdatum.Name = "colGlb01_Geburtsdatum";
            this.colGlb01_Geburtsdatum.Visible = true;
            this.colGlb01_Geburtsdatum.VisibleIndex = 21;
            //
            // colGlb01_IndexPunkte
            //
            this.colGlb01_IndexPunkte.Caption = "Glb01_IndexPunkte";
            this.colGlb01_IndexPunkte.FieldName = "Glb01_IndexPunkte";
            this.colGlb01_IndexPunkte.Name = "colGlb01_IndexPunkte";
            this.colGlb01_IndexPunkte.Visible = true;
            this.colGlb01_IndexPunkte.VisibleIndex = 27;
            //
            // colGlb01_Teuerungseinsprache
            //
            this.colGlb01_Teuerungseinsprache.Caption = "Glb01_Teuerungseinsprache";
            this.colGlb01_Teuerungseinsprache.FieldName = "Glb01_Teuerungseinsprache";
            this.colGlb01_Teuerungseinsprache.Name = "colGlb01_Teuerungseinsprache";
            this.colGlb01_Teuerungseinsprache.Visible = true;
            this.colGlb01_Teuerungseinsprache.VisibleIndex = 26;
            //
            // colGlb01_VornameName
            //
            this.colGlb01_VornameName.Caption = "Glb01_VornameName";
            this.colGlb01_VornameName.FieldName = "Glb01_VornameName";
            this.colGlb01_VornameName.Name = "colGlb01_VornameName";
            this.colGlb01_VornameName.Visible = true;
            this.colGlb01_VornameName.VisibleIndex = 20;
            //
            // colGlb01BetragBasis
            //
            this.colGlb01BetragBasis.Name = "colGlb01BetragBasis";
            //
            // colGlb01BetragBerechnet
            //
            this.colGlb01BetragBerechnet.Name = "colGlb01BetragBerechnet";
            //
            // colGlb01BetragKiZu
            //
            this.colGlb01BetragKiZu.Name = "colGlb01BetragKiZu";
            //
            // colGlb01Forderungstitel
            //
            this.colGlb01Forderungstitel.Name = "colGlb01Forderungstitel";
            //
            // colGlb01Geburtsdatum
            //
            this.colGlb01Geburtsdatum.Name = "colGlb01Geburtsdatum";
            //
            // colGlb01IndexPunkte
            //
            this.colGlb01IndexPunkte.Name = "colGlb01IndexPunkte";
            //
            // colGlb01Teuerungseinsprache
            //
            this.colGlb01Teuerungseinsprache.Name = "colGlb01Teuerungseinsprache";
            //
            // colGlb01VornameName
            //
            this.colGlb01VornameName.Name = "colGlb01VornameName";
            //
            // colGlb02_BetragBasis
            //
            this.colGlb02_BetragBasis.Caption = "Glb02_BetragBasis";
            this.colGlb02_BetragBasis.DisplayFormat.FormatString = "N2";
            this.colGlb02_BetragBasis.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGlb02_BetragBasis.FieldName = "Glb02_BetragBasis";
            this.colGlb02_BetragBasis.Name = "colGlb02_BetragBasis";
            this.colGlb02_BetragBasis.Visible = true;
            this.colGlb02_BetragBasis.VisibleIndex = 31;
            //
            // colGlb02_BetragBerechnet
            //
            this.colGlb02_BetragBerechnet.Caption = "Glb02_BetragBerechnet";
            this.colGlb02_BetragBerechnet.DisplayFormat.FormatString = "N2";
            this.colGlb02_BetragBerechnet.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGlb02_BetragBerechnet.FieldName = "Glb02_BetragBerechnet";
            this.colGlb02_BetragBerechnet.Name = "colGlb02_BetragBerechnet";
            this.colGlb02_BetragBerechnet.Visible = true;
            this.colGlb02_BetragBerechnet.VisibleIndex = 32;
            //
            // colGlb02_BetragKiZu
            //
            this.colGlb02_BetragKiZu.Caption = "Glb02_BetragKiZu";
            this.colGlb02_BetragKiZu.DisplayFormat.FormatString = "N2";
            this.colGlb02_BetragKiZu.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGlb02_BetragKiZu.FieldName = "Glb02_BetragKiZu";
            this.colGlb02_BetragKiZu.Name = "colGlb02_BetragKiZu";
            this.colGlb02_BetragKiZu.Visible = true;
            this.colGlb02_BetragKiZu.VisibleIndex = 33;
            //
            // colGlb02_Forderungstitel
            //
            this.colGlb02_Forderungstitel.Caption = "Glb02_Forderungstitel";
            this.colGlb02_Forderungstitel.FieldName = "Glb02_Forderungstitel";
            this.colGlb02_Forderungstitel.Name = "colGlb02_Forderungstitel";
            this.colGlb02_Forderungstitel.Visible = true;
            this.colGlb02_Forderungstitel.VisibleIndex = 30;
            //
            // colGlb02_Geburtsdatum
            //
            this.colGlb02_Geburtsdatum.Caption = "Glb02_Geburtsdatum";
            this.colGlb02_Geburtsdatum.FieldName = "Glb02_Geburtsdatum";
            this.colGlb02_Geburtsdatum.Name = "colGlb02_Geburtsdatum";
            this.colGlb02_Geburtsdatum.Visible = true;
            this.colGlb02_Geburtsdatum.VisibleIndex = 29;
            //
            // colGlb02_IndexPunkte
            //
            this.colGlb02_IndexPunkte.Caption = "Glb02_IndexPunkte";
            this.colGlb02_IndexPunkte.FieldName = "Glb02_IndexPunkte";
            this.colGlb02_IndexPunkte.Name = "colGlb02_IndexPunkte";
            this.colGlb02_IndexPunkte.Visible = true;
            this.colGlb02_IndexPunkte.VisibleIndex = 35;
            //
            // colGlb02_Teuerungseinsprache
            //
            this.colGlb02_Teuerungseinsprache.Caption = "Glb02_Teuerungseinsprache";
            this.colGlb02_Teuerungseinsprache.FieldName = "Glb02_Teuerungseinsprache";
            this.colGlb02_Teuerungseinsprache.Name = "colGlb02_Teuerungseinsprache";
            this.colGlb02_Teuerungseinsprache.Visible = true;
            this.colGlb02_Teuerungseinsprache.VisibleIndex = 34;
            //
            // colGlb02_VornameName
            //
            this.colGlb02_VornameName.Caption = "Glb02_VornameName";
            this.colGlb02_VornameName.FieldName = "Glb02_VornameName";
            this.colGlb02_VornameName.Name = "colGlb02_VornameName";
            this.colGlb02_VornameName.Visible = true;
            this.colGlb02_VornameName.VisibleIndex = 28;
            //
            // colGlb02BetragBasis
            //
            this.colGlb02BetragBasis.Name = "colGlb02BetragBasis";
            //
            // colGlb02BetragBerechnet
            //
            this.colGlb02BetragBerechnet.Name = "colGlb02BetragBerechnet";
            //
            // colGlb02BetragKiZu
            //
            this.colGlb02BetragKiZu.Name = "colGlb02BetragKiZu";
            //
            // colGlb02Forderungstitel
            //
            this.colGlb02Forderungstitel.Name = "colGlb02Forderungstitel";
            //
            // colGlb02Geburtsdatum
            //
            this.colGlb02Geburtsdatum.Name = "colGlb02Geburtsdatum";
            //
            // colGlb02IndexPunkte
            //
            this.colGlb02IndexPunkte.Name = "colGlb02IndexPunkte";
            //
            // colGlb02Teuerungseinsprache
            //
            this.colGlb02Teuerungseinsprache.Name = "colGlb02Teuerungseinsprache";
            //
            // colGlb02VornameName
            //
            this.colGlb02VornameName.Name = "colGlb02VornameName";
            //
            // colGlb03_BetragBasis
            //
            this.colGlb03_BetragBasis.Caption = "Glb03_BetragBasis";
            this.colGlb03_BetragBasis.DisplayFormat.FormatString = "N2";
            this.colGlb03_BetragBasis.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGlb03_BetragBasis.FieldName = "Glb03_BetragBasis";
            this.colGlb03_BetragBasis.Name = "colGlb03_BetragBasis";
            this.colGlb03_BetragBasis.Visible = true;
            this.colGlb03_BetragBasis.VisibleIndex = 39;
            //
            // colGlb03_BetragBerechnet
            //
            this.colGlb03_BetragBerechnet.Caption = "Glb03_BetragBerechnet";
            this.colGlb03_BetragBerechnet.DisplayFormat.FormatString = "N2";
            this.colGlb03_BetragBerechnet.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGlb03_BetragBerechnet.FieldName = "Glb03_BetragBerechnet";
            this.colGlb03_BetragBerechnet.Name = "colGlb03_BetragBerechnet";
            this.colGlb03_BetragBerechnet.Visible = true;
            this.colGlb03_BetragBerechnet.VisibleIndex = 40;
            //
            // colGlb03_BetragKiZu
            //
            this.colGlb03_BetragKiZu.Caption = "Glb03_BetragKiZu";
            this.colGlb03_BetragKiZu.DisplayFormat.FormatString = "N2";
            this.colGlb03_BetragKiZu.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGlb03_BetragKiZu.FieldName = "Glb03_BetragKiZu";
            this.colGlb03_BetragKiZu.Name = "colGlb03_BetragKiZu";
            this.colGlb03_BetragKiZu.Visible = true;
            this.colGlb03_BetragKiZu.VisibleIndex = 41;
            //
            // colGlb03_Forderungstitel
            //
            this.colGlb03_Forderungstitel.Caption = "Glb03_Forderungstitel";
            this.colGlb03_Forderungstitel.FieldName = "Glb03_Forderungstitel";
            this.colGlb03_Forderungstitel.Name = "colGlb03_Forderungstitel";
            this.colGlb03_Forderungstitel.Visible = true;
            this.colGlb03_Forderungstitel.VisibleIndex = 38;
            //
            // colGlb03_Geburtsdatum
            //
            this.colGlb03_Geburtsdatum.Caption = "Glb03_Geburtsdatum";
            this.colGlb03_Geburtsdatum.FieldName = "Glb03_Geburtsdatum";
            this.colGlb03_Geburtsdatum.Name = "colGlb03_Geburtsdatum";
            this.colGlb03_Geburtsdatum.Visible = true;
            this.colGlb03_Geburtsdatum.VisibleIndex = 37;
            //
            // colGlb03_IndexPunkte
            //
            this.colGlb03_IndexPunkte.Caption = "Glb03_IndexPunkte";
            this.colGlb03_IndexPunkte.FieldName = "Glb03_IndexPunkte";
            this.colGlb03_IndexPunkte.Name = "colGlb03_IndexPunkte";
            this.colGlb03_IndexPunkte.Visible = true;
            this.colGlb03_IndexPunkte.VisibleIndex = 43;
            //
            // colGlb03_Teuerungseinsprache
            //
            this.colGlb03_Teuerungseinsprache.Caption = "Glb03_Teuerungseinsprache";
            this.colGlb03_Teuerungseinsprache.FieldName = "Glb03_Teuerungseinsprache";
            this.colGlb03_Teuerungseinsprache.Name = "colGlb03_Teuerungseinsprache";
            this.colGlb03_Teuerungseinsprache.Visible = true;
            this.colGlb03_Teuerungseinsprache.VisibleIndex = 42;
            //
            // colGlb03_VornameName
            //
            this.colGlb03_VornameName.Caption = "Glb03_VornameName";
            this.colGlb03_VornameName.FieldName = "Glb03_VornameName";
            this.colGlb03_VornameName.Name = "colGlb03_VornameName";
            this.colGlb03_VornameName.Visible = true;
            this.colGlb03_VornameName.VisibleIndex = 36;
            //
            // colGlb03BetragBasis
            //
            this.colGlb03BetragBasis.Name = "colGlb03BetragBasis";
            //
            // colGlb03BetragBerechnet
            //
            this.colGlb03BetragBerechnet.Name = "colGlb03BetragBerechnet";
            //
            // colGlb03BetragKiZu
            //
            this.colGlb03BetragKiZu.Name = "colGlb03BetragKiZu";
            //
            // colGlb03Forderungstitel
            //
            this.colGlb03Forderungstitel.Name = "colGlb03Forderungstitel";
            //
            // colGlb03Geburtsdatum
            //
            this.colGlb03Geburtsdatum.Name = "colGlb03Geburtsdatum";
            //
            // colGlb03IndexPunkte
            //
            this.colGlb03IndexPunkte.Name = "colGlb03IndexPunkte";
            //
            // colGlb03Teuerungseinsprache
            //
            this.colGlb03Teuerungseinsprache.Name = "colGlb03Teuerungseinsprache";
            //
            // colGlb03VornameName
            //
            this.colGlb03VornameName.Name = "colGlb03VornameName";
            //
            // colGlb04_BetragBasis
            //
            this.colGlb04_BetragBasis.Caption = "Glb04_BetragBasis";
            this.colGlb04_BetragBasis.DisplayFormat.FormatString = "N2";
            this.colGlb04_BetragBasis.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGlb04_BetragBasis.FieldName = "Glb04_BetragBasis";
            this.colGlb04_BetragBasis.Name = "colGlb04_BetragBasis";
            this.colGlb04_BetragBasis.Visible = true;
            this.colGlb04_BetragBasis.VisibleIndex = 47;
            //
            // colGlb04_BetragBerechnet
            //
            this.colGlb04_BetragBerechnet.Caption = "Glb04_BetragBerechnet";
            this.colGlb04_BetragBerechnet.DisplayFormat.FormatString = "N2";
            this.colGlb04_BetragBerechnet.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGlb04_BetragBerechnet.FieldName = "Glb04_BetragBerechnet";
            this.colGlb04_BetragBerechnet.Name = "colGlb04_BetragBerechnet";
            this.colGlb04_BetragBerechnet.Visible = true;
            this.colGlb04_BetragBerechnet.VisibleIndex = 48;
            //
            // colGlb04_BetragKiZu
            //
            this.colGlb04_BetragKiZu.Caption = "Glb04_BetragKiZu";
            this.colGlb04_BetragKiZu.DisplayFormat.FormatString = "N2";
            this.colGlb04_BetragKiZu.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGlb04_BetragKiZu.FieldName = "Glb04_BetragKiZu";
            this.colGlb04_BetragKiZu.Name = "colGlb04_BetragKiZu";
            this.colGlb04_BetragKiZu.Visible = true;
            this.colGlb04_BetragKiZu.VisibleIndex = 49;
            //
            // colGlb04_Forderungstitel
            //
            this.colGlb04_Forderungstitel.Caption = "Glb04_Forderungstitel";
            this.colGlb04_Forderungstitel.FieldName = "Glb04_Forderungstitel";
            this.colGlb04_Forderungstitel.Name = "colGlb04_Forderungstitel";
            this.colGlb04_Forderungstitel.Visible = true;
            this.colGlb04_Forderungstitel.VisibleIndex = 46;
            //
            // colGlb04_Geburtsdatum
            //
            this.colGlb04_Geburtsdatum.Caption = "Glb04_Geburtsdatum";
            this.colGlb04_Geburtsdatum.FieldName = "Glb04_Geburtsdatum";
            this.colGlb04_Geburtsdatum.Name = "colGlb04_Geburtsdatum";
            this.colGlb04_Geburtsdatum.Visible = true;
            this.colGlb04_Geburtsdatum.VisibleIndex = 45;
            //
            // colGlb04_IndexPunkte
            //
            this.colGlb04_IndexPunkte.Caption = "Glb04_IndexPunkte";
            this.colGlb04_IndexPunkte.FieldName = "Glb04_IndexPunkte";
            this.colGlb04_IndexPunkte.Name = "colGlb04_IndexPunkte";
            this.colGlb04_IndexPunkte.Visible = true;
            this.colGlb04_IndexPunkte.VisibleIndex = 51;
            //
            // colGlb04_Teuerungseinsprache
            //
            this.colGlb04_Teuerungseinsprache.Caption = "Glb04_Teuerungseinsprache";
            this.colGlb04_Teuerungseinsprache.FieldName = "Glb04_Teuerungseinsprache";
            this.colGlb04_Teuerungseinsprache.Name = "colGlb04_Teuerungseinsprache";
            this.colGlb04_Teuerungseinsprache.Visible = true;
            this.colGlb04_Teuerungseinsprache.VisibleIndex = 50;
            //
            // colGlb04_VornameName
            //
            this.colGlb04_VornameName.Caption = "Glb04_VornameName";
            this.colGlb04_VornameName.FieldName = "Glb04_VornameName";
            this.colGlb04_VornameName.Name = "colGlb04_VornameName";
            this.colGlb04_VornameName.Visible = true;
            this.colGlb04_VornameName.VisibleIndex = 44;
            //
            // colGlb04BetragBasis
            //
            this.colGlb04BetragBasis.Name = "colGlb04BetragBasis";
            //
            // colGlb04BetragBerechnet
            //
            this.colGlb04BetragBerechnet.Name = "colGlb04BetragBerechnet";
            //
            // colGlb04BetragKiZu
            //
            this.colGlb04BetragKiZu.Name = "colGlb04BetragKiZu";
            //
            // colGlb04Forderungstitel
            //
            this.colGlb04Forderungstitel.Name = "colGlb04Forderungstitel";
            //
            // colGlb04Geburtsdatum
            //
            this.colGlb04Geburtsdatum.Name = "colGlb04Geburtsdatum";
            //
            // colGlb04IndexPunkte
            //
            this.colGlb04IndexPunkte.Name = "colGlb04IndexPunkte";
            //
            // colGlb04Teuerungseinsprache
            //
            this.colGlb04Teuerungseinsprache.Name = "colGlb04Teuerungseinsprache";
            //
            // colGlb04VornameName
            //
            this.colGlb04VornameName.Name = "colGlb04VornameName";
            //
            // colGlb05_BetragBasis
            //
            this.colGlb05_BetragBasis.Caption = "Glb05_BetragBasis";
            this.colGlb05_BetragBasis.DisplayFormat.FormatString = "N2";
            this.colGlb05_BetragBasis.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGlb05_BetragBasis.FieldName = "Glb05_BetragBasis";
            this.colGlb05_BetragBasis.Name = "colGlb05_BetragBasis";
            this.colGlb05_BetragBasis.Visible = true;
            this.colGlb05_BetragBasis.VisibleIndex = 55;
            //
            // colGlb05_BetragBerechnet
            //
            this.colGlb05_BetragBerechnet.Caption = "Glb05_BetragBerechnet";
            this.colGlb05_BetragBerechnet.DisplayFormat.FormatString = "N2";
            this.colGlb05_BetragBerechnet.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGlb05_BetragBerechnet.FieldName = "Glb05_BetragBerechnet";
            this.colGlb05_BetragBerechnet.Name = "colGlb05_BetragBerechnet";
            this.colGlb05_BetragBerechnet.Visible = true;
            this.colGlb05_BetragBerechnet.VisibleIndex = 56;
            //
            // colGlb05_BetragKiZu
            //
            this.colGlb05_BetragKiZu.Caption = "Glb05_BetragKiZu";
            this.colGlb05_BetragKiZu.DisplayFormat.FormatString = "N2";
            this.colGlb05_BetragKiZu.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGlb05_BetragKiZu.FieldName = "Glb05_BetragKiZu";
            this.colGlb05_BetragKiZu.Name = "colGlb05_BetragKiZu";
            this.colGlb05_BetragKiZu.Visible = true;
            this.colGlb05_BetragKiZu.VisibleIndex = 57;
            //
            // colGlb05_Forderungstitel
            //
            this.colGlb05_Forderungstitel.Caption = "Glb05_Forderungstitel";
            this.colGlb05_Forderungstitel.FieldName = "Glb05_Forderungstitel";
            this.colGlb05_Forderungstitel.Name = "colGlb05_Forderungstitel";
            this.colGlb05_Forderungstitel.Visible = true;
            this.colGlb05_Forderungstitel.VisibleIndex = 54;
            //
            // colGlb05_Geburtsdatum
            //
            this.colGlb05_Geburtsdatum.Caption = "Glb05_Geburtsdatum";
            this.colGlb05_Geburtsdatum.FieldName = "Glb05_Geburtsdatum";
            this.colGlb05_Geburtsdatum.Name = "colGlb05_Geburtsdatum";
            this.colGlb05_Geburtsdatum.Visible = true;
            this.colGlb05_Geburtsdatum.VisibleIndex = 53;
            //
            // colGlb05_IndexPunkte
            //
            this.colGlb05_IndexPunkte.Caption = "Glb05_IndexPunkte";
            this.colGlb05_IndexPunkte.FieldName = "Glb05_IndexPunkte";
            this.colGlb05_IndexPunkte.Name = "colGlb05_IndexPunkte";
            this.colGlb05_IndexPunkte.Visible = true;
            this.colGlb05_IndexPunkte.VisibleIndex = 59;
            //
            // colGlb05_Teuerungseinsprache
            //
            this.colGlb05_Teuerungseinsprache.Caption = "Glb05_Teuerungseinsprache";
            this.colGlb05_Teuerungseinsprache.FieldName = "Glb05_Teuerungseinsprache";
            this.colGlb05_Teuerungseinsprache.Name = "colGlb05_Teuerungseinsprache";
            this.colGlb05_Teuerungseinsprache.Visible = true;
            this.colGlb05_Teuerungseinsprache.VisibleIndex = 58;
            //
            // colGlb05_VornameName
            //
            this.colGlb05_VornameName.Caption = "Glb05_VornameName";
            this.colGlb05_VornameName.FieldName = "Glb05_VornameName";
            this.colGlb05_VornameName.Name = "colGlb05_VornameName";
            this.colGlb05_VornameName.Visible = true;
            this.colGlb05_VornameName.VisibleIndex = 52;
            //
            // colGlb05BetragBasis
            //
            this.colGlb05BetragBasis.Name = "colGlb05BetragBasis";
            //
            // colGlb05BetragBerechnet
            //
            this.colGlb05BetragBerechnet.Name = "colGlb05BetragBerechnet";
            //
            // colGlb05BetragKiZu
            //
            this.colGlb05BetragKiZu.Name = "colGlb05BetragKiZu";
            //
            // colGlb05Forderungstitel
            //
            this.colGlb05Forderungstitel.Name = "colGlb05Forderungstitel";
            //
            // colGlb05Geburtsdatum
            //
            this.colGlb05Geburtsdatum.Name = "colGlb05Geburtsdatum";
            //
            // colGlb05IndexPunkte
            //
            this.colGlb05IndexPunkte.Name = "colGlb05IndexPunkte";
            //
            // colGlb05Teuerungseinsprache
            //
            this.colGlb05Teuerungseinsprache.Name = "colGlb05Teuerungseinsprache";
            //
            // colGlb05VornameName
            //
            this.colGlb05VornameName.Name = "colGlb05VornameName";
            //
            // colGlb06_BetragBasis
            //
            this.colGlb06_BetragBasis.Caption = "Glb06_BetragBasis";
            this.colGlb06_BetragBasis.DisplayFormat.FormatString = "N2";
            this.colGlb06_BetragBasis.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGlb06_BetragBasis.FieldName = "Glb06_BetragBasis";
            this.colGlb06_BetragBasis.Name = "colGlb06_BetragBasis";
            this.colGlb06_BetragBasis.Visible = true;
            this.colGlb06_BetragBasis.VisibleIndex = 63;
            //
            // colGlb06_BetragBerechnet
            //
            this.colGlb06_BetragBerechnet.Caption = "Glb06_BetragBerechnet";
            this.colGlb06_BetragBerechnet.DisplayFormat.FormatString = "N2";
            this.colGlb06_BetragBerechnet.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGlb06_BetragBerechnet.FieldName = "Glb06_BetragBerechnet";
            this.colGlb06_BetragBerechnet.Name = "colGlb06_BetragBerechnet";
            this.colGlb06_BetragBerechnet.Visible = true;
            this.colGlb06_BetragBerechnet.VisibleIndex = 64;
            //
            // colGlb06_BetragKiZu
            //
            this.colGlb06_BetragKiZu.Caption = "Glb06_BetragKiZu";
            this.colGlb06_BetragKiZu.DisplayFormat.FormatString = "N2";
            this.colGlb06_BetragKiZu.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGlb06_BetragKiZu.FieldName = "Glb06_BetragKiZu";
            this.colGlb06_BetragKiZu.Name = "colGlb06_BetragKiZu";
            this.colGlb06_BetragKiZu.Visible = true;
            this.colGlb06_BetragKiZu.VisibleIndex = 65;
            //
            // colGlb06_Forderungstitel
            //
            this.colGlb06_Forderungstitel.Caption = "Glb06_Forderungstitel";
            this.colGlb06_Forderungstitel.FieldName = "Glb06_Forderungstitel";
            this.colGlb06_Forderungstitel.Name = "colGlb06_Forderungstitel";
            this.colGlb06_Forderungstitel.Visible = true;
            this.colGlb06_Forderungstitel.VisibleIndex = 62;
            //
            // colGlb06_Geburtsdatum
            //
            this.colGlb06_Geburtsdatum.Caption = "Glb06_Geburtsdatum";
            this.colGlb06_Geburtsdatum.FieldName = "Glb06_Geburtsdatum";
            this.colGlb06_Geburtsdatum.Name = "colGlb06_Geburtsdatum";
            this.colGlb06_Geburtsdatum.Visible = true;
            this.colGlb06_Geburtsdatum.VisibleIndex = 61;
            //
            // colGlb06_IndexPunkte
            //
            this.colGlb06_IndexPunkte.Caption = "Glb06_IndexPunkte";
            this.colGlb06_IndexPunkte.FieldName = "Glb06_IndexPunkte";
            this.colGlb06_IndexPunkte.Name = "colGlb06_IndexPunkte";
            this.colGlb06_IndexPunkte.Visible = true;
            this.colGlb06_IndexPunkte.VisibleIndex = 67;
            //
            // colGlb06_Teuerungseinsprache
            //
            this.colGlb06_Teuerungseinsprache.Caption = "Glb06_Teuerungseinsprache";
            this.colGlb06_Teuerungseinsprache.FieldName = "Glb06_Teuerungseinsprache";
            this.colGlb06_Teuerungseinsprache.Name = "colGlb06_Teuerungseinsprache";
            this.colGlb06_Teuerungseinsprache.Visible = true;
            this.colGlb06_Teuerungseinsprache.VisibleIndex = 66;
            //
            // colGlb06_VornameName
            //
            this.colGlb06_VornameName.Caption = "Glb06_VornameName";
            this.colGlb06_VornameName.FieldName = "Glb06_VornameName";
            this.colGlb06_VornameName.Name = "colGlb06_VornameName";
            this.colGlb06_VornameName.Visible = true;
            this.colGlb06_VornameName.VisibleIndex = 60;
            //
            // colGlb06BetragBasis
            //
            this.colGlb06BetragBasis.Name = "colGlb06BetragBasis";
            //
            // colGlb06BetragBerechnet
            //
            this.colGlb06BetragBerechnet.Name = "colGlb06BetragBerechnet";
            //
            // colGlb06BetragKiZu
            //
            this.colGlb06BetragKiZu.Name = "colGlb06BetragKiZu";
            //
            // colGlb06Forderungstitel
            //
            this.colGlb06Forderungstitel.Name = "colGlb06Forderungstitel";
            //
            // colGlb06Geburtsdatum
            //
            this.colGlb06Geburtsdatum.Name = "colGlb06Geburtsdatum";
            //
            // colGlb06IndexPunkte
            //
            this.colGlb06IndexPunkte.Name = "colGlb06IndexPunkte";
            //
            // colGlb06Teuerungseinsprache
            //
            this.colGlb06Teuerungseinsprache.Name = "colGlb06Teuerungseinsprache";
            //
            // colGlb06VornameName
            //
            this.colGlb06VornameName.Name = "colGlb06VornameName";
            //
            // colGlb07_BetragBasis
            //
            this.colGlb07_BetragBasis.Caption = "Glb07_BetragBasis";
            this.colGlb07_BetragBasis.DisplayFormat.FormatString = "N2";
            this.colGlb07_BetragBasis.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGlb07_BetragBasis.FieldName = "Glb07_BetragBasis";
            this.colGlb07_BetragBasis.Name = "colGlb07_BetragBasis";
            this.colGlb07_BetragBasis.Visible = true;
            this.colGlb07_BetragBasis.VisibleIndex = 71;
            //
            // colGlb07_BetragBerechnet
            //
            this.colGlb07_BetragBerechnet.Caption = "Glb07_BetragBerechnet";
            this.colGlb07_BetragBerechnet.DisplayFormat.FormatString = "N2";
            this.colGlb07_BetragBerechnet.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGlb07_BetragBerechnet.FieldName = "Glb07_BetragBerechnet";
            this.colGlb07_BetragBerechnet.Name = "colGlb07_BetragBerechnet";
            this.colGlb07_BetragBerechnet.Visible = true;
            this.colGlb07_BetragBerechnet.VisibleIndex = 72;
            //
            // colGlb07_BetragKiZu
            //
            this.colGlb07_BetragKiZu.Caption = "Glb07_BetragKiZu";
            this.colGlb07_BetragKiZu.DisplayFormat.FormatString = "N2";
            this.colGlb07_BetragKiZu.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGlb07_BetragKiZu.FieldName = "Glb07_BetragKiZu";
            this.colGlb07_BetragKiZu.Name = "colGlb07_BetragKiZu";
            this.colGlb07_BetragKiZu.Visible = true;
            this.colGlb07_BetragKiZu.VisibleIndex = 73;
            //
            // colGlb07_Forderungstitel
            //
            this.colGlb07_Forderungstitel.Caption = "Glb07_Forderungstitel";
            this.colGlb07_Forderungstitel.FieldName = "Glb07_Forderungstitel";
            this.colGlb07_Forderungstitel.Name = "colGlb07_Forderungstitel";
            this.colGlb07_Forderungstitel.Visible = true;
            this.colGlb07_Forderungstitel.VisibleIndex = 70;
            //
            // colGlb07_Geburtsdatum
            //
            this.colGlb07_Geburtsdatum.Caption = "Glb07_Geburtsdatum";
            this.colGlb07_Geburtsdatum.FieldName = "Glb07_Geburtsdatum";
            this.colGlb07_Geburtsdatum.Name = "colGlb07_Geburtsdatum";
            this.colGlb07_Geburtsdatum.Visible = true;
            this.colGlb07_Geburtsdatum.VisibleIndex = 69;
            //
            // colGlb07_IndexPunkte
            //
            this.colGlb07_IndexPunkte.Caption = "Glb07_IndexPunkte";
            this.colGlb07_IndexPunkte.FieldName = "Glb07_IndexPunkte";
            this.colGlb07_IndexPunkte.Name = "colGlb07_IndexPunkte";
            this.colGlb07_IndexPunkte.Visible = true;
            this.colGlb07_IndexPunkte.VisibleIndex = 75;
            //
            // colGlb07_Teuerungseinsprache
            //
            this.colGlb07_Teuerungseinsprache.Caption = "Glb07_Teuerungseinsprache";
            this.colGlb07_Teuerungseinsprache.FieldName = "Glb07_Teuerungseinsprache";
            this.colGlb07_Teuerungseinsprache.Name = "colGlb07_Teuerungseinsprache";
            this.colGlb07_Teuerungseinsprache.Visible = true;
            this.colGlb07_Teuerungseinsprache.VisibleIndex = 74;
            //
            // colGlb07_VornameName
            //
            this.colGlb07_VornameName.Caption = "Glb07_VornameName";
            this.colGlb07_VornameName.FieldName = "Glb07_VornameName";
            this.colGlb07_VornameName.Name = "colGlb07_VornameName";
            this.colGlb07_VornameName.Visible = true;
            this.colGlb07_VornameName.VisibleIndex = 68;
            //
            // colGlb07BetragBasis
            //
            this.colGlb07BetragBasis.Name = "colGlb07BetragBasis";
            //
            // colGlb07BetragBerechnet
            //
            this.colGlb07BetragBerechnet.Name = "colGlb07BetragBerechnet";
            //
            // colGlb07BetragKiZu
            //
            this.colGlb07BetragKiZu.Name = "colGlb07BetragKiZu";
            //
            // colGlb07Forderungstitel
            //
            this.colGlb07Forderungstitel.Name = "colGlb07Forderungstitel";
            //
            // colGlb07Geburtsdatum
            //
            this.colGlb07Geburtsdatum.Name = "colGlb07Geburtsdatum";
            //
            // colGlb07IndexPunkte
            //
            this.colGlb07IndexPunkte.Name = "colGlb07IndexPunkte";
            //
            // colGlb07Teuerungseinsprache
            //
            this.colGlb07Teuerungseinsprache.Name = "colGlb07Teuerungseinsprache";
            //
            // colGlb07VornameName
            //
            this.colGlb07VornameName.Name = "colGlb07VornameName";
            //
            // colGlb08_BetragBasis
            //
            this.colGlb08_BetragBasis.Caption = "Glb08_BetragBasis";
            this.colGlb08_BetragBasis.DisplayFormat.FormatString = "N2";
            this.colGlb08_BetragBasis.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGlb08_BetragBasis.FieldName = "Glb08_BetragBasis";
            this.colGlb08_BetragBasis.Name = "colGlb08_BetragBasis";
            this.colGlb08_BetragBasis.Visible = true;
            this.colGlb08_BetragBasis.VisibleIndex = 79;
            //
            // colGlb08_BetragBerechnet
            //
            this.colGlb08_BetragBerechnet.Caption = "Glb08_BetragBerechnet";
            this.colGlb08_BetragBerechnet.DisplayFormat.FormatString = "N2";
            this.colGlb08_BetragBerechnet.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGlb08_BetragBerechnet.FieldName = "Glb08_BetragBerechnet";
            this.colGlb08_BetragBerechnet.Name = "colGlb08_BetragBerechnet";
            this.colGlb08_BetragBerechnet.Visible = true;
            this.colGlb08_BetragBerechnet.VisibleIndex = 80;
            //
            // colGlb08_BetragKiZu
            //
            this.colGlb08_BetragKiZu.Caption = "Glb08_BetragKiZu";
            this.colGlb08_BetragKiZu.DisplayFormat.FormatString = "N2";
            this.colGlb08_BetragKiZu.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGlb08_BetragKiZu.FieldName = "Glb08_BetragKiZu";
            this.colGlb08_BetragKiZu.Name = "colGlb08_BetragKiZu";
            this.colGlb08_BetragKiZu.Visible = true;
            this.colGlb08_BetragKiZu.VisibleIndex = 81;
            //
            // colGlb08_Forderungstitel
            //
            this.colGlb08_Forderungstitel.Caption = "Glb08_Forderungstitel";
            this.colGlb08_Forderungstitel.FieldName = "Glb08_Forderungstitel";
            this.colGlb08_Forderungstitel.Name = "colGlb08_Forderungstitel";
            this.colGlb08_Forderungstitel.Visible = true;
            this.colGlb08_Forderungstitel.VisibleIndex = 78;
            //
            // colGlb08_Geburtsdatum
            //
            this.colGlb08_Geburtsdatum.Caption = "Glb08_Geburtsdatum";
            this.colGlb08_Geburtsdatum.FieldName = "Glb08_Geburtsdatum";
            this.colGlb08_Geburtsdatum.Name = "colGlb08_Geburtsdatum";
            this.colGlb08_Geburtsdatum.Visible = true;
            this.colGlb08_Geburtsdatum.VisibleIndex = 77;
            //
            // colGlb08_IndexPunkte
            //
            this.colGlb08_IndexPunkte.Caption = "Glb08_IndexPunkte";
            this.colGlb08_IndexPunkte.FieldName = "Glb08_IndexPunkte";
            this.colGlb08_IndexPunkte.Name = "colGlb08_IndexPunkte";
            this.colGlb08_IndexPunkte.Visible = true;
            this.colGlb08_IndexPunkte.VisibleIndex = 83;
            //
            // colGlb08_Teuerungseinsprache
            //
            this.colGlb08_Teuerungseinsprache.Caption = "Glb08_Teuerungseinsprache";
            this.colGlb08_Teuerungseinsprache.FieldName = "Glb08_Teuerungseinsprache";
            this.colGlb08_Teuerungseinsprache.Name = "colGlb08_Teuerungseinsprache";
            this.colGlb08_Teuerungseinsprache.Visible = true;
            this.colGlb08_Teuerungseinsprache.VisibleIndex = 82;
            //
            // colGlb08_VornameName
            //
            this.colGlb08_VornameName.Caption = "Glb08_VornameName";
            this.colGlb08_VornameName.FieldName = "Glb08_VornameName";
            this.colGlb08_VornameName.Name = "colGlb08_VornameName";
            this.colGlb08_VornameName.Visible = true;
            this.colGlb08_VornameName.VisibleIndex = 76;
            //
            // colGlb08BetragBasis
            //
            this.colGlb08BetragBasis.Name = "colGlb08BetragBasis";
            //
            // colGlb08BetragBerechnet
            //
            this.colGlb08BetragBerechnet.Name = "colGlb08BetragBerechnet";
            //
            // colGlb08BetragKiZu
            //
            this.colGlb08BetragKiZu.Name = "colGlb08BetragKiZu";
            //
            // colGlb08Forderungstitel
            //
            this.colGlb08Forderungstitel.Name = "colGlb08Forderungstitel";
            //
            // colGlb08Geburtsdatum
            //
            this.colGlb08Geburtsdatum.Name = "colGlb08Geburtsdatum";
            //
            // colGlb08IndexPunkte
            //
            this.colGlb08IndexPunkte.Name = "colGlb08IndexPunkte";
            //
            // colGlb08Teuerungseinsprache
            //
            this.colGlb08Teuerungseinsprache.Name = "colGlb08Teuerungseinsprache";
            //
            // colGlb08VornameName
            //
            this.colGlb08VornameName.Name = "colGlb08VornameName";
            //
            // colGlb09_BetragBasis
            //
            this.colGlb09_BetragBasis.Caption = "Glb09_BetragBasis";
            this.colGlb09_BetragBasis.DisplayFormat.FormatString = "N2";
            this.colGlb09_BetragBasis.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGlb09_BetragBasis.FieldName = "Glb09_BetragBasis";
            this.colGlb09_BetragBasis.Name = "colGlb09_BetragBasis";
            this.colGlb09_BetragBasis.Visible = true;
            this.colGlb09_BetragBasis.VisibleIndex = 87;
            //
            // colGlb09_BetragBerechnet
            //
            this.colGlb09_BetragBerechnet.Caption = "Glb09_BetragBerechnet";
            this.colGlb09_BetragBerechnet.DisplayFormat.FormatString = "N2";
            this.colGlb09_BetragBerechnet.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGlb09_BetragBerechnet.FieldName = "Glb09_BetragBerechnet";
            this.colGlb09_BetragBerechnet.Name = "colGlb09_BetragBerechnet";
            this.colGlb09_BetragBerechnet.Visible = true;
            this.colGlb09_BetragBerechnet.VisibleIndex = 88;
            //
            // colGlb09_BetragKiZu
            //
            this.colGlb09_BetragKiZu.Caption = "Glb09_BetragKiZu";
            this.colGlb09_BetragKiZu.DisplayFormat.FormatString = "N2";
            this.colGlb09_BetragKiZu.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGlb09_BetragKiZu.FieldName = "Glb09_BetragKiZu";
            this.colGlb09_BetragKiZu.Name = "colGlb09_BetragKiZu";
            this.colGlb09_BetragKiZu.Visible = true;
            this.colGlb09_BetragKiZu.VisibleIndex = 89;
            //
            // colGlb09_Forderungstitel
            //
            this.colGlb09_Forderungstitel.Caption = "Glb09_Forderungstitel";
            this.colGlb09_Forderungstitel.FieldName = "Glb09_Forderungstitel";
            this.colGlb09_Forderungstitel.Name = "colGlb09_Forderungstitel";
            this.colGlb09_Forderungstitel.Visible = true;
            this.colGlb09_Forderungstitel.VisibleIndex = 86;
            //
            // colGlb09_Geburtsdatum
            //
            this.colGlb09_Geburtsdatum.Caption = "Glb09_Geburtsdatum";
            this.colGlb09_Geburtsdatum.FieldName = "Glb09_Geburtsdatum";
            this.colGlb09_Geburtsdatum.Name = "colGlb09_Geburtsdatum";
            this.colGlb09_Geburtsdatum.Visible = true;
            this.colGlb09_Geburtsdatum.VisibleIndex = 85;
            //
            // colGlb09_IndexPunkte
            //
            this.colGlb09_IndexPunkte.Caption = "Glb09_IndexPunkte";
            this.colGlb09_IndexPunkte.FieldName = "Glb09_IndexPunkte";
            this.colGlb09_IndexPunkte.Name = "colGlb09_IndexPunkte";
            this.colGlb09_IndexPunkte.Visible = true;
            this.colGlb09_IndexPunkte.VisibleIndex = 91;
            //
            // colGlb09_Teuerungseinsprache
            //
            this.colGlb09_Teuerungseinsprache.Caption = "Glb09_Teuerungseinsprache";
            this.colGlb09_Teuerungseinsprache.FieldName = "Glb09_Teuerungseinsprache";
            this.colGlb09_Teuerungseinsprache.Name = "colGlb09_Teuerungseinsprache";
            this.colGlb09_Teuerungseinsprache.Visible = true;
            this.colGlb09_Teuerungseinsprache.VisibleIndex = 90;
            //
            // colGlb09_VornameName
            //
            this.colGlb09_VornameName.Caption = "Glb09_VornameName";
            this.colGlb09_VornameName.FieldName = "Glb09_VornameName";
            this.colGlb09_VornameName.Name = "colGlb09_VornameName";
            this.colGlb09_VornameName.Visible = true;
            this.colGlb09_VornameName.VisibleIndex = 84;
            //
            // colGlb09BetragBasis
            //
            this.colGlb09BetragBasis.Name = "colGlb09BetragBasis";
            //
            // colGlb09BetragBerechnet
            //
            this.colGlb09BetragBerechnet.Name = "colGlb09BetragBerechnet";
            //
            // colGlb09BetragKiZu
            //
            this.colGlb09BetragKiZu.Name = "colGlb09BetragKiZu";
            //
            // colGlb09Forderungstitel
            //
            this.colGlb09Forderungstitel.Name = "colGlb09Forderungstitel";
            //
            // colGlb09Geburtsdatum
            //
            this.colGlb09Geburtsdatum.Name = "colGlb09Geburtsdatum";
            //
            // colGlb09IndexPunkte
            //
            this.colGlb09IndexPunkte.Name = "colGlb09IndexPunkte";
            //
            // colGlb09Teuerungseinsprache
            //
            this.colGlb09Teuerungseinsprache.Name = "colGlb09Teuerungseinsprache";
            //
            // colGlb09VornameName
            //
            this.colGlb09VornameName.Name = "colGlb09VornameName";
            //
            // colGlb10_BetragBasis
            //
            this.colGlb10_BetragBasis.Caption = "Glb10_BetragBasis";
            this.colGlb10_BetragBasis.DisplayFormat.FormatString = "N2";
            this.colGlb10_BetragBasis.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGlb10_BetragBasis.FieldName = "Glb10_BetragBasis";
            this.colGlb10_BetragBasis.Name = "colGlb10_BetragBasis";
            this.colGlb10_BetragBasis.Visible = true;
            this.colGlb10_BetragBasis.VisibleIndex = 95;
            //
            // colGlb10_BetragBerechnet
            //
            this.colGlb10_BetragBerechnet.Caption = "Glb10_BetragBerechnet";
            this.colGlb10_BetragBerechnet.DisplayFormat.FormatString = "N2";
            this.colGlb10_BetragBerechnet.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGlb10_BetragBerechnet.FieldName = "Glb10_BetragBerechnet";
            this.colGlb10_BetragBerechnet.Name = "colGlb10_BetragBerechnet";
            this.colGlb10_BetragBerechnet.Visible = true;
            this.colGlb10_BetragBerechnet.VisibleIndex = 96;
            //
            // colGlb10_BetragKiZu
            //
            this.colGlb10_BetragKiZu.Caption = "Glb10_BetragKiZu";
            this.colGlb10_BetragKiZu.DisplayFormat.FormatString = "N2";
            this.colGlb10_BetragKiZu.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGlb10_BetragKiZu.FieldName = "Glb10_BetragKiZu";
            this.colGlb10_BetragKiZu.Name = "colGlb10_BetragKiZu";
            this.colGlb10_BetragKiZu.Visible = true;
            this.colGlb10_BetragKiZu.VisibleIndex = 97;
            //
            // colGlb10_Forderungstitel
            //
            this.colGlb10_Forderungstitel.Caption = "Glb10_Forderungstitel";
            this.colGlb10_Forderungstitel.FieldName = "Glb10_Forderungstitel";
            this.colGlb10_Forderungstitel.Name = "colGlb10_Forderungstitel";
            this.colGlb10_Forderungstitel.Visible = true;
            this.colGlb10_Forderungstitel.VisibleIndex = 94;
            //
            // colGlb10_Geburtsdatum
            //
            this.colGlb10_Geburtsdatum.Caption = "Glb10_Geburtsdatum";
            this.colGlb10_Geburtsdatum.FieldName = "Glb10_Geburtsdatum";
            this.colGlb10_Geburtsdatum.Name = "colGlb10_Geburtsdatum";
            this.colGlb10_Geburtsdatum.Visible = true;
            this.colGlb10_Geburtsdatum.VisibleIndex = 93;
            //
            // colGlb10_IndexPunkte
            //
            this.colGlb10_IndexPunkte.Caption = "Glb10_IndexPunkte";
            this.colGlb10_IndexPunkte.FieldName = "Glb10_IndexPunkte";
            this.colGlb10_IndexPunkte.Name = "colGlb10_IndexPunkte";
            this.colGlb10_IndexPunkte.Visible = true;
            this.colGlb10_IndexPunkte.VisibleIndex = 99;
            //
            // colGlb10_Teuerungseinsprache
            //
            this.colGlb10_Teuerungseinsprache.Caption = "Glb10_Teuerungseinsprache";
            this.colGlb10_Teuerungseinsprache.FieldName = "Glb10_Teuerungseinsprache";
            this.colGlb10_Teuerungseinsprache.Name = "colGlb10_Teuerungseinsprache";
            this.colGlb10_Teuerungseinsprache.Visible = true;
            this.colGlb10_Teuerungseinsprache.VisibleIndex = 98;
            //
            // colGlb10_VornameName
            //
            this.colGlb10_VornameName.Caption = "Glb10_VornameName";
            this.colGlb10_VornameName.FieldName = "Glb10_VornameName";
            this.colGlb10_VornameName.Name = "colGlb10_VornameName";
            this.colGlb10_VornameName.Visible = true;
            this.colGlb10_VornameName.VisibleIndex = 92;
            //
            // colGlb10BetragBasis
            //
            this.colGlb10BetragBasis.Name = "colGlb10BetragBasis";
            //
            // colGlb10BetragBerechnet
            //
            this.colGlb10BetragBerechnet.Name = "colGlb10BetragBerechnet";
            //
            // colGlb10BetragKiZu
            //
            this.colGlb10BetragKiZu.Name = "colGlb10BetragKiZu";
            //
            // colGlb10Forderungstitel
            //
            this.colGlb10Forderungstitel.Name = "colGlb10Forderungstitel";
            //
            // colGlb10Geburtsdatum
            //
            this.colGlb10Geburtsdatum.Name = "colGlb10Geburtsdatum";
            //
            // colGlb10IndexPunkte
            //
            this.colGlb10IndexPunkte.Name = "colGlb10IndexPunkte";
            //
            // colGlb10Teuerungseinsprache
            //
            this.colGlb10Teuerungseinsprache.Name = "colGlb10Teuerungseinsprache";
            //
            // colGlb10VornameName
            //
            this.colGlb10VornameName.Name = "colGlb10VornameName";
            //
            // colKopieAn
            //
            this.colKopieAn.Caption = "KopieAn";
            this.colKopieAn.FieldName = "KopieAn";
            this.colKopieAn.Name = "colKopieAn";
            this.colKopieAn.Visible = true;
            this.colKopieAn.VisibleIndex = 112;
            //
            // colKopieAn_QT
            //
            this.colKopieAn_QT.Caption = "KopieAn_QT";
            this.colKopieAn_QT.FieldName = "KopieAn_QT";
            this.colKopieAn_QT.Name = "colKopieAn_QT";
            this.colKopieAn_QT.Visible = true;
            this.colKopieAn_QT.VisibleIndex = 114;
            //
            // colKopieAn_SZ
            //
            this.colKopieAn_SZ.Caption = "KopieAn_SZ";
            this.colKopieAn_SZ.FieldName = "KopieAn_SZ";
            this.colKopieAn_SZ.Name = "colKopieAn_SZ";
            this.colKopieAn_SZ.Visible = true;
            this.colKopieAn_SZ.VisibleIndex = 113;
            //
            // colKopieAnQT
            //
            this.colKopieAnQT.Name = "colKopieAnQT";
            //
            // colKopieAnSZ
            //
            this.colKopieAnSZ.Name = "colKopieAnSZ";
            //
            // colLaufendesJahr
            //
            this.colLaufendesJahr.Caption = "LaufendesJahr";
            this.colLaufendesJahr.FieldName = "LaufendesJahr";
            this.colLaufendesJahr.Name = "colLaufendesJahr";
            this.colLaufendesJahr.Visible = true;
            this.colLaufendesJahr.VisibleIndex = 100;
            //
            // colRT_Datum
            //
            this.colRT_Datum.Caption = "RT_Datum";
            this.colRT_Datum.FieldName = "RT_Datum";
            this.colRT_Datum.Name = "colRT_Datum";
            this.colRT_Datum.Visible = true;
            this.colRT_Datum.VisibleIndex = 16;
            //
            // colRT_IndexPunkte
            //
            this.colRT_IndexPunkte.Caption = "RT_IndexPunkte";
            this.colRT_IndexPunkte.DisplayFormat.FormatString = "N2";
            this.colRT_IndexPunkte.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRT_IndexPunkte.FieldName = "RT_IndexPunkte";
            this.colRT_IndexPunkte.Name = "colRT_IndexPunkte";
            this.colRT_IndexPunkte.Visible = true;
            this.colRT_IndexPunkte.VisibleIndex = 19;
            //
            // colRT_IndexStand
            //
            this.colRT_IndexStand.Caption = "RT_IndexStand";
            this.colRT_IndexStand.FieldName = "RT_IndexStand";
            this.colRT_IndexStand.Name = "colRT_IndexStand";
            this.colRT_IndexStand.Visible = true;
            this.colRT_IndexStand.VisibleIndex = 18;
            //
            // colRT_IndexTyp
            //
            this.colRT_IndexTyp.Caption = "RT_IndexTyp";
            this.colRT_IndexTyp.FieldName = "RT_IndexTyp";
            this.colRT_IndexTyp.Name = "colRT_IndexTyp";
            this.colRT_IndexTyp.Visible = true;
            this.colRT_IndexTyp.VisibleIndex = 15;
            //
            // colRT_Info
            //
            this.colRT_Info.Caption = "RT_Info";
            this.colRT_Info.FieldName = "RT_Info";
            this.colRT_Info.Name = "colRT_Info";
            this.colRT_Info.Visible = true;
            this.colRT_Info.VisibleIndex = 14;
            //
            // colRT_Teuerungseinsprache
            //
            this.colRT_Teuerungseinsprache.Caption = "RT_Teuerungseinsprache";
            this.colRT_Teuerungseinsprache.FieldName = "RT_Teuerungseinsprache";
            this.colRT_Teuerungseinsprache.Name = "colRT_Teuerungseinsprache";
            this.colRT_Teuerungseinsprache.Visible = true;
            this.colRT_Teuerungseinsprache.VisibleIndex = 17;
            //
            // colRT_Typ
            //
            this.colRT_Typ.Caption = "RT_Typ";
            this.colRT_Typ.FieldName = "RT_Typ";
            this.colRT_Typ.Name = "colRT_Typ";
            this.colRT_Typ.Visible = true;
            this.colRT_Typ.VisibleIndex = 13;
            //
            // colRTDatum
            //
            this.colRTDatum.Name = "colRTDatum";
            //
            // colRTIndexPunkte
            //
            this.colRTIndexPunkte.Name = "colRTIndexPunkte";
            //
            // colRTIndexStand
            //
            this.colRTIndexStand.Name = "colRTIndexStand";
            //
            // colRTIndexTyp
            //
            this.colRTIndexTyp.Name = "colRTIndexTyp";
            //
            // colRTInfo
            //
            this.colRTInfo.Name = "colRTInfo";
            //
            // colRTTeuerungseinsprache
            //
            this.colRTTeuerungseinsprache.Name = "colRTTeuerungseinsprache";
            //
            // colRTTyp
            //
            this.colRTTyp.Name = "colRTTyp";
            //
            // colSB_Displayname
            //
            this.colSB_Displayname.Caption = "SB_Displayname";
            this.colSB_Displayname.FieldName = "SB_Displayname";
            this.colSB_Displayname.Name = "colSB_Displayname";
            this.colSB_Displayname.Visible = true;
            this.colSB_Displayname.VisibleIndex = 111;
            //
            // colSB_LogonName
            //
            this.colSB_LogonName.Caption = "SB_LogonName";
            this.colSB_LogonName.FieldName = "SB_LogonName";
            this.colSB_LogonName.Name = "colSB_LogonName";
            this.colSB_LogonName.Visible = true;
            this.colSB_LogonName.VisibleIndex = 109;
            //
            // colSB_VornameName
            //
            this.colSB_VornameName.Caption = "SB_VornameName";
            this.colSB_VornameName.FieldName = "SB_VornameName";
            this.colSB_VornameName.Name = "colSB_VornameName";
            this.colSB_VornameName.Visible = true;
            this.colSB_VornameName.VisibleIndex = 110;
            //
            // colSBDisplayname
            //
            this.colSBDisplayname.Name = "colSBDisplayname";
            //
            // colSBLogonName
            //
            this.colSBLogonName.Name = "colSBLogonName";
            //
            // colSBVornameName
            //
            this.colSBVornameName.Name = "colSBVornameName";
            //
            // colSchuldner_Anrede
            //
            this.colSchuldner_Anrede.Caption = "Schuldner_Anrede";
            this.colSchuldner_Anrede.FieldName = "Schuldner_Anrede";
            this.colSchuldner_Anrede.Name = "colSchuldner_Anrede";
            this.colSchuldner_Anrede.Visible = true;
            this.colSchuldner_Anrede.VisibleIndex = 0;
            //
            // colSchuldner_Name
            //
            this.colSchuldner_Name.Caption = "Schuldner_Name";
            this.colSchuldner_Name.FieldName = "Schuldner_Name";
            this.colSchuldner_Name.Name = "colSchuldner_Name";
            this.colSchuldner_Name.Visible = true;
            this.colSchuldner_Name.VisibleIndex = 1;
            //
            // colSchuldner_Ort
            //
            this.colSchuldner_Ort.Caption = "Schuldner_Ort";
            this.colSchuldner_Ort.FieldName = "Schuldner_Ort";
            this.colSchuldner_Ort.Name = "colSchuldner_Ort";
            this.colSchuldner_Ort.Visible = true;
            this.colSchuldner_Ort.VisibleIndex = 7;
            //
            // colSchuldner_PersonenNummer
            //
            this.colSchuldner_PersonenNummer.Caption = "Schuldner_PersonenNummer";
            this.colSchuldner_PersonenNummer.FieldName = "Schuldner_PersonenNummer";
            this.colSchuldner_PersonenNummer.Name = "colSchuldner_PersonenNummer";
            this.colSchuldner_PersonenNummer.Visible = true;
            this.colSchuldner_PersonenNummer.VisibleIndex = 8;
            //
            // colSchuldner_PLZ
            //
            this.colSchuldner_PLZ.Caption = "Schuldner_PLZ";
            this.colSchuldner_PLZ.FieldName = "Schuldner_PLZ";
            this.colSchuldner_PLZ.Name = "colSchuldner_PLZ";
            this.colSchuldner_PLZ.Visible = true;
            this.colSchuldner_PLZ.VisibleIndex = 6;
            //
            // colSchuldner_Postfach
            //
            this.colSchuldner_Postfach.Caption = "Schuldner_Postfach";
            this.colSchuldner_Postfach.FieldName = "Schuldner_Postfach";
            this.colSchuldner_Postfach.Name = "colSchuldner_Postfach";
            this.colSchuldner_Postfach.Visible = true;
            this.colSchuldner_Postfach.VisibleIndex = 5;
            //
            // colSchuldner_Strasse
            //
            this.colSchuldner_Strasse.Caption = "Schuldner_Strasse";
            this.colSchuldner_Strasse.FieldName = "Schuldner_Strasse";
            this.colSchuldner_Strasse.Name = "colSchuldner_Strasse";
            this.colSchuldner_Strasse.Visible = true;
            this.colSchuldner_Strasse.VisibleIndex = 4;
            //
            // colSchuldner_Vorname
            //
            this.colSchuldner_Vorname.Caption = "Schuldner_Vorname";
            this.colSchuldner_Vorname.FieldName = "Schuldner_Vorname";
            this.colSchuldner_Vorname.Name = "colSchuldner_Vorname";
            this.colSchuldner_Vorname.Visible = true;
            this.colSchuldner_Vorname.VisibleIndex = 2;
            //
            // colSchuldner_Zusatz
            //
            this.colSchuldner_Zusatz.Caption = "Schuldner_Zusatz";
            this.colSchuldner_Zusatz.FieldName = "Schuldner_Zusatz";
            this.colSchuldner_Zusatz.Name = "colSchuldner_Zusatz";
            this.colSchuldner_Zusatz.Visible = true;
            this.colSchuldner_Zusatz.VisibleIndex = 3;
            //
            // colSchuldnerAnrede
            //
            this.colSchuldnerAnrede.Name = "colSchuldnerAnrede";
            //
            // colSchuldnerName
            //
            this.colSchuldnerName.Name = "colSchuldnerName";
            //
            // colSchuldnerOrt
            //
            this.colSchuldnerOrt.Name = "colSchuldnerOrt";
            //
            // colSchuldnerPersonenNummer
            //
            this.colSchuldnerPersonenNummer.Name = "colSchuldnerPersonenNummer";
            //
            // colSchuldnerPLZ
            //
            this.colSchuldnerPLZ.Name = "colSchuldnerPLZ";
            //
            // colSchuldnerPostfach
            //
            this.colSchuldnerPostfach.Name = "colSchuldnerPostfach";
            //
            // colSchuldnerStrasse
            //
            this.colSchuldnerStrasse.Name = "colSchuldnerStrasse";
            //
            // colSchuldnerVorname
            //
            this.colSchuldnerVorname.Name = "colSchuldnerVorname";
            //
            // colSchuldnerZusatz
            //
            this.colSchuldnerZusatz.Name = "colSchuldnerZusatz";
            //
            // colSumme_Betrag
            //
            this.colSumme_Betrag.Caption = "Summe_Betrag";
            this.colSumme_Betrag.FieldName = "Summe_Betrag";
            this.colSumme_Betrag.Name = "colSumme_Betrag";
            this.colSumme_Betrag.Visible = true;
            this.colSumme_Betrag.VisibleIndex = 115;
            //
            // colSummeBetrag
            //
            this.colSummeBetrag.Name = "colSummeBetrag";
            //
            // colVorhergehendesJahr
            //
            this.colVorhergehendesJahr.Caption = "VorhergehendesJahr";
            this.colVorhergehendesJahr.FieldName = "VorhergehendesJahr";
            this.colVorhergehendesJahr.Name = "colVorhergehendesJahr";
            this.colVorhergehendesJahr.Visible = true;
            this.colVorhergehendesJahr.VisibleIndex = 101;
            //
            // gvwQuery
            //
            this.gvwQuery.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gvwQuery.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwQuery.Appearance.Empty.Options.UseBackColor = true;
            this.gvwQuery.Appearance.Empty.Options.UseFont = true;
            this.gvwQuery.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwQuery.Appearance.EvenRow.Options.UseFont = true;
            this.gvwQuery.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvwQuery.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwQuery.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gvwQuery.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvwQuery.Appearance.FocusedCell.Options.UseFont = true;
            this.gvwQuery.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvwQuery.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvwQuery.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwQuery.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gvwQuery.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvwQuery.Appearance.FocusedRow.Options.UseFont = true;
            this.gvwQuery.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvwQuery.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gvwQuery.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gvwQuery.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gvwQuery.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvwQuery.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvwQuery.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvwQuery.Appearance.GroupRow.Options.UseFont = true;
            this.gvwQuery.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvwQuery.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gvwQuery.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gvwQuery.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvwQuery.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvwQuery.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gvwQuery.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvwQuery.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gvwQuery.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwQuery.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvwQuery.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvwQuery.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvwQuery.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvwQuery.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gvwQuery.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvwQuery.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwQuery.Appearance.OddRow.Options.UseFont = true;
            this.gvwQuery.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gvwQuery.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwQuery.Appearance.Row.Options.UseBackColor = true;
            this.gvwQuery.Appearance.Row.Options.UseFont = true;
            this.gvwQuery.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwQuery.Appearance.SelectedRow.Options.UseFont = true;
            this.gvwQuery.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gvwQuery.Appearance.VertLine.Options.UseBackColor = true;
            this.gvwQuery.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gvwQuery.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSchuldner_Anrede,
            this.colSchuldner_Name,
            this.colSchuldner_Vorname,
            this.colSchuldner_Zusatz,
            this.colSchuldner_Strasse,
            this.colSchuldner_Postfach,
            this.colSchuldner_PLZ,
            this.colSchuldner_Ort,
            this.colSchuldner_PersonenNummer,
            this.colFalltraeger_Name,
            this.colFalltraeger_Vorname,
            this.colFalltraeger_PersonenNummer,
            this.colFalltraeger_FallNummer,
            this.colRT_Typ,
            this.colRT_Info,
            this.colRT_IndexTyp,
            this.colRT_Datum,
            this.colRT_Teuerungseinsprache,
            this.colRT_IndexStand,
            this.colRT_IndexPunkte,
            this.colGlb01_VornameName,
            this.colGlb01_Geburtsdatum,
            this.colGlb01_Forderungstitel,
            this.colGlb01_BetragBasis,
            this.colGlb01_BetragBerechnet,
            this.colGlb01_BetragKiZu,
            this.colGlb01_Teuerungseinsprache,
            this.colGlb01_IndexPunkte,
            this.colGlb02_VornameName,
            this.colGlb02_Geburtsdatum,
            this.colGlb02_Forderungstitel,
            this.colGlb02_BetragBasis,
            this.colGlb02_BetragBerechnet,
            this.colGlb02_BetragKiZu,
            this.colGlb02_Teuerungseinsprache,
            this.colGlb02_IndexPunkte,
            this.colGlb03_VornameName,
            this.colGlb03_Geburtsdatum,
            this.colGlb03_Forderungstitel,
            this.colGlb03_BetragBasis,
            this.colGlb03_BetragBerechnet,
            this.colGlb03_BetragKiZu,
            this.colGlb03_Teuerungseinsprache,
            this.colGlb03_IndexPunkte,
            this.colGlb04_VornameName,
            this.colGlb04_Geburtsdatum,
            this.colGlb04_Forderungstitel,
            this.colGlb04_BetragBasis,
            this.colGlb04_BetragBerechnet,
            this.colGlb04_BetragKiZu,
            this.colGlb04_Teuerungseinsprache,
            this.colGlb04_IndexPunkte,
            this.colGlb05_VornameName,
            this.colGlb05_Geburtsdatum,
            this.colGlb05_Forderungstitel,
            this.colGlb05_BetragBasis,
            this.colGlb05_BetragBerechnet,
            this.colGlb05_BetragKiZu,
            this.colGlb05_Teuerungseinsprache,
            this.colGlb05_IndexPunkte,
            this.colGlb06_VornameName,
            this.colGlb06_Geburtsdatum,
            this.colGlb06_Forderungstitel,
            this.colGlb06_BetragBasis,
            this.colGlb06_BetragBerechnet,
            this.colGlb06_BetragKiZu,
            this.colGlb06_Teuerungseinsprache,
            this.colGlb06_IndexPunkte,
            this.colGlb07_VornameName,
            this.colGlb07_Geburtsdatum,
            this.colGlb07_Forderungstitel,
            this.colGlb07_BetragBasis,
            this.colGlb07_BetragBerechnet,
            this.colGlb07_BetragKiZu,
            this.colGlb07_Teuerungseinsprache,
            this.colGlb07_IndexPunkte,
            this.colGlb08_VornameName,
            this.colGlb08_Geburtsdatum,
            this.colGlb08_Forderungstitel,
            this.colGlb08_BetragBasis,
            this.colGlb08_BetragBerechnet,
            this.colGlb08_BetragKiZu,
            this.colGlb08_Teuerungseinsprache,
            this.colGlb08_IndexPunkte,
            this.colGlb09_VornameName,
            this.colGlb09_Geburtsdatum,
            this.colGlb09_Forderungstitel,
            this.colGlb09_BetragBasis,
            this.colGlb09_BetragBerechnet,
            this.colGlb09_BetragKiZu,
            this.colGlb09_Teuerungseinsprache,
            this.colGlb09_IndexPunkte,
            this.colGlb10_VornameName,
            this.colGlb10_Geburtsdatum,
            this.colGlb10_Forderungstitel,
            this.colGlb10_BetragBasis,
            this.colGlb10_BetragBerechnet,
            this.colGlb10_BetragKiZu,
            this.colGlb10_Teuerungseinsprache,
            this.colGlb10_IndexPunkte,
            this.colLaufendesJahr,
            this.colVorhergehendesJahr,
            this.colDatumPer,
            this.colFrdrg_VornameName,
            this.colFrdrg_Geburtsdatum,
            this.colFrdrg_Forderungstitel,
            this.colFrdrg_BetragBasis,
            this.colFrdrg_DatumAb,
            this.colFrdrg_Gueltigbis,
            this.colSB_LogonName,
            this.colSB_VornameName,
            this.colSB_Displayname,
            this.colKopieAn,
            this.colKopieAn_SZ,
            this.colKopieAn_QT,
            this.colSumme_Betrag});
            this.gvwQuery.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gvwQuery.GridControl = this.grdQuery1;
            this.gvwQuery.Name = "gvwQuery";
            this.gvwQuery.OptionsBehavior.Editable = false;
            this.gvwQuery.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gvwQuery.OptionsNavigation.AutoFocusNewRow = true;
            this.gvwQuery.OptionsNavigation.UseTabKey = false;
            this.gvwQuery.OptionsView.ColumnAutoWidth = false;
            this.gvwQuery.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvwQuery.OptionsView.ShowGroupPanel = false;
            this.gvwQuery.OptionsView.ShowIndicator = false;
            //
            // CtlQueryIkIndexbrief
            //
            this.Name = "CtlQueryIkIndexbrief";
            this.Load += new System.EventHandler(this.CtlQueryIkIndexbrief_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSachbearbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIndexart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIndexart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumPer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtchkDelete.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwQuery)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        #region EventHandlers

        private void CtlQueryIkIndexbrief_Load(object sender, EventArgs e)
        {
            // Auswahl Jahre füllen
            var aYear = DateTime.Today.Year;

            for (var i = aYear; i > aYear - 10; i--)
            {
                edtYear.Properties.Items.Add(i);
            }

            _filterUserID = Session.User.UserID;

            var qry = DBUtil.OpenSQL(@"
                SELECT DisplayText
                FROM dbo.vwUser
                WHERE UserID = {0};", Session.User.UserID);

            edtIndexart.EditValue = 1;
            edtUser.LookupID = _filterUserID;
            edtUser.EditValue = Utils.ConvertToString(qry["DisplayText"]);
            edtYear.EditValue = DateTime.Today.Year;
            edtDatumPer.EditValue = DateTime.Parse("01/01/" + DateTime.Today.AddYears(1).Year);
            tabControlSearch.SelectedTabIndex = 1;
            lblCount.Text = "";
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var hasValueForEveryLandesindex = Convert.ToBoolean(DBUtil.ExecuteScalarSQLThrowingException(@"
              DECLARE @CountIkLandesindex INT;
              DECLARE @CountIkLandesindexWert INT;

              SELECT @CountIkLandesindex = COUNT(1)
              FROM dbo.IkLandesindex WITH (READUNCOMMITTED);

              SELECT @CountIkLandesindexWert = COUNT(1)
              FROM dbo.IkLandesindexWert WITH (READUNCOMMITTED)
              WHERE Jahr = {0}
                AND Monat = 11;

              SELECT CASE
                       WHEN @CountIkLandesindex <> @CountIkLandesindexWert THEN 0       -- not all indexes have a value for month and year
                       ELSE 1                                                           -- all indexes have a value for month and year
                     END;", edtDatumPer.DateTime.Year - 1));

            if (!hasValueForEveryLandesindex)
            {
                KissMsg.ShowInfo(Name,
                                 "NotAllIndexesHaveValueForNov",
                                 "Für den November {0} konnte nicht für alle Indextypen ein Index gefunden werden.\r\nErfassen Sie zuerst alle Indexzahlen.",
                                 edtDatumPer.DateTime.Year - 1);

                return;
            }

            var tmpMsg = "";
            var success = 0;
            var nullForderungen = 0;
            var forderungenDanach = 0;
            var forderungenBereitsErstellt = 0;
            var datumGueltigBisGesetzt = 0;
            var teuerungseinsprache = 0;
            var total = 0;
            var actNumber = 0;

            foreach (DataRow row in qryQuery.DataTable.Rows)
            {
                for (var i = 1; i < 11; i++)
                {
                    var fieldName = i.ToString();

                    if (fieldName.Length == 1)
                    {
                        fieldName = "0" + fieldName;
                    }

                    var fieldNameTe = "Glb" + fieldName + "_Teuerungseinsprache";
                    fieldName = "Glb" + fieldName + "_IkForderungID";

                    if (DBUtil.IsEmpty(row[fieldName]))
                    {
                        continue;
                    }

                    total += 1;

                    if (Utils.ConvertToString(row[fieldNameTe]) == "Ja")
                    {
                        teuerungseinsprache += 1;
                    }
                    else
                    {
                        int result;

                        try
                        {
                            var qryExec = DBUtil.OpenSQL(@"
                                DECLARE @Res INT;
                                EXEC @Res = dbo.spIkForderung_Insert_Index {0}, {1};
                                SELECT Result = @Res;", row[fieldName], edtDatumPer.DateTime);

                            result = Utils.ConvertToInt(qryExec["Result"]);

                            if (result != 1)
                            {
                                switch (result)
                                {
                                    case 2:
                                        nullForderungen += 1;
                                        break;

                                    case 3:
                                        forderungenDanach += 1;
                                        break;

                                    case 4:
                                        forderungenBereitsErstellt += 1;
                                        break;

                                    case 5:
                                        datumGueltigBisGesetzt += 1;
                                        break;

                                    case 6:
                                        teuerungseinsprache += 1;
                                        break;

                                    case -1:
                                        tmpMsg = string.Format(
                                            "Der Aufruf-Parameter @IkForderungID ist ungültig (IkForderungID = {0}).",
                                            Utils.ConvertToInt(row[fieldName]).ToString());
                                        break;

                                    case -2:
                                        tmpMsg = string.Format(
                                            "Der Index für die neue Forderung konnte nicht ermittelt werden (IkForderungID = {0}).",
                                            Utils.ConvertToInt(row[fieldName]).ToString());
                                        break;

                                    default:
                                        tmpMsg = string.Format(
                                            "Unbekannter Fehler beim Kopieren der Forderung (IkForderungID = {0}).",
                                            Utils.ConvertToInt(row[fieldName]).ToString());
                                        break;
                                }
                            }
                            else
                            {
                                success += 1;
                            }

                            if (tmpMsg != "")
                            {
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            tmpMsg = ex.Message;
                            result = -1;
                            break;
                        }
                    }
                }

                // Monatszahlen neu generieren
                DBUtil.ExecSQL(@"
                    EXEC dbo.spIkMonatszahlen_DetailAll {0}, 1;", Utils.ConvertToInt(row["FaLeistungID"]));

                actNumber += 1;
                lblCount.Text = string.Format("Zeile {0} von {1}", actNumber, qryQuery.Count);
                lblCount.Refresh();

                if (tmpMsg != "")
                {
                    break;
                }
            }

            var msg = "";

            if (success > 0)
            {
                msg = string.Format("Es wurde(n) {0} neue Forderung(en) erstellt (Total {1}).", success, total);
            }

            if (nullForderungen > 0)
            {
                AppendNewLineToStringIfNotEmpty(ref msg);
                msg = msg + string.Format("{0} Forderung(en) wurden übersprungen, weil eine Null-Forderung verarbeitet wurde.", nullForderungen);
            }

            if (forderungenDanach > 0)
            {
                AppendNewLineToStringIfNotEmpty(ref msg);
                msg = msg + string.Format("{0} Forderung(en) wurden übersprungen, weil eine Null-Forderung vor der neuen Forderung existiert.", forderungenDanach);
            }

            if (forderungenBereitsErstellt > 0)
            {
                AppendNewLineToStringIfNotEmpty(ref msg);
                msg = msg + string.Format("{0} bereits vorhandene Forderung(en) wurden übersprungen.", forderungenBereitsErstellt);
            }

            if (datumGueltigBisGesetzt > 0)
            {
                AppendNewLineToStringIfNotEmpty(ref msg);
                msg = msg + string.Format("{0} Forderung(en) wurden übersprungen, weil das Datum GültigBis vor dem neuen Anpassungsdatum liegt.", datumGueltigBisGesetzt);
            }

            if (teuerungseinsprache > 0)
            {
                AppendNewLineToStringIfNotEmpty(ref msg);
                msg = msg + string.Format("{0} Forderung(en) wurden übersprungen, weil eine Teuerungseinsprache vorliegt.", teuerungseinsprache);
            }

            if (tmpMsg != "")
            {
                if (msg != "")
                {
                    msg = msg + "\r\n\r\n";
                }

                msg = msg + "Die Verarbeitung wurde abgebrochen: Letzte Fehlermeldung:\r\n";
                msg = msg + tmpMsg;
            }

            KissMsg.ShowInfo(msg);

            // Daten neu anzeigen
            qryQuery.Refresh();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            // Kontrollabfrage
            if (!KissMsg.ShowQuestion(string.Format(
              "Es existieren {0} Forderungen, welche gelöscht werden.\r\n" +
              "Wollen Sie alle diese Forderungen wirklich löschen?",
              qryQuery.Count)))
            {
                return;
            }

            // Löschen
            var deleted = 0;
            var errors = 0;
            var actNumber = 0;

            foreach (DataRow row in qryQuery.DataTable.Rows)
            {
                var qry = DBUtil.OpenSQL(@"
                    EXEC dbo.spIkForderung_Delete_Check {0};", row["Frdrg_IkForderungID"]);

                var anzVerbucht = Utils.ConvertToInt(qry["AnzahlVerbucht"]);

                if (anzVerbucht == 0)
                {
                    DBUtil.ExecSQL(@"
                        DELETE dbo.IkForderung
                        WHERE IkForderungID = {0};", row["Frdrg_IkForderungID"]);

                    deleted += 1;

                    // Monatszahlen neu generieren
                    DBUtil.ExecSQL(@"
                        EXEC dbo.spIkMonatszahlen_DetailAll {0}, 1;", row["FaLeistungID"]);
                }
                else
                {
                    errors += 1;
                }

                actNumber += 1;
                lblCount.Text = string.Format("Zeile {0} von {1}", actNumber, qryQuery.Count);
                lblCount.Refresh();
            }

            // Rückmeldung ausgeben
            var msg = "";

            if (deleted > 0)
            {
                msg = string.Format("Es wurde(n) {0} Forderung(en) gelöscht.", deleted);
            }

            if (errors > 0)
            {
                if (msg != "")
                {
                    msg = msg + "\r\n";
                }

                msg = msg + string.Format("{0} Forderung(en) konnten nicht gelöscht werden (bereits verbucht).", errors);
            }

            KissMsg.ShowInfo(msg);

            // Daten neu anzeigen
            qryQuery.Refresh();
        }

        private void edtUser_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var searchString = edtUser.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "";
                }
                else
                {
                    _filterUserID = 0;
                    edtUser.LookupID = 0;
                    edtUser.EditValue = "";
                    edtUser.ToolTip = "";
                    return;
                }
            }

            var dlg = new KissLookupDialog();

            e.Cancel = !dlg.SearchData(@"
              SELECT UserID$                  = UserID,
                     DisplayText$             = DisplayText,
                     [Kürzel]                 = LogonName,
                     [Mitarbeiter/in]         = NameVorname,
                     [Org.Einheit]            = OrgUnit,
                     LogonNameVornameOrgUnit$ = LogonNameVornameOrgUnit
              FROM dbo.vwUser WITH (READUNCOMMITTED)
              WHERE (DisplayText LIKE '%' + {0} + '%' OR {0} IS NULL)
                AND UserID IN (SELECT DISTINCT UserID
                               FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                               WHERE ModulID IN (3, 4))
              ORDER BY NameVorname;", searchString, e.ButtonClicked, null, null, null);

            if (e.Cancel)
            {
                return;
            }

            _filterUserID = Utils.ConvertToInt(dlg[0]);
            edtUser.LookupID = _filterUserID;
            edtUser.EditValue = Utils.ConvertToString(dlg[1]);
            edtUser.ToolTip = Utils.ConvertToString(dlg[1]);
        }

        private void qryQuery_AfterFill(object sender, EventArgs e)
        {
            if (qryQuery.Count != 0)
            {
                return;
            }

            btnCreate.Enabled = false;
            btnUndo.Enabled = false;
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            // Alte Suchwerte speichern
            edtIndexart.EditValue = _oldIndexArt;
            edtYear.EditValue = _oldYear;
            edtDatumPer.EditValue = _oldDate;
            edtUser.LookupID = _filterUserID;
            edtUser.EditValue = _filterUserText;
            edtUser.ToolTip = _filterUserText;
            base.NewSearch();
        }

        protected override void RunSearch()
        {
            if (DBUtil.IsEmpty(edtYear.EditValue))
            {
                KissMsg.ShowInfo("Wählen Sie zuerst ein Jahr aus.");
                throw new KissCancelException();
            }

            if (DBUtil.IsEmpty(edtDatumPer.EditValue))
            {
                KissMsg.ShowInfo("Erfassen Sie zuerst das Datum 'Neue Forderung Per'.");
                throw new KissCancelException();
            }

            if (edtDatumPer.DateTime.Year != Utils.ConvertToInt(edtYear.EditValue) + 1)
            {
                KissMsg.ShowInfo("Das Datum 'Neue Forderung Per' muss im folgenden Jahr der Suche liegen.");
                throw new KissCancelException();
            }

            // Alte Suchwerte speichern
            _oldIndexArt = Utils.ConvertToInt(edtIndexart.EditValue);
            _oldYear = Utils.ConvertToInt(edtYear.EditValue);
            _oldDate = edtDatumPer.DateTime;
            _filterUserText = Utils.ConvertToString(edtUser.EditValue);
            lblCount.Text = "";

            // Fixe Parameter
            var parameters = new object[] {
                _oldYear,
                _oldDate,
                _oldIndexArt,
                _filterUserID,
                edtchkDelete.Checked};

            kissSearch.SelectParameters = parameters;
            base.RunSearch();

            // Alte Suchwerte speichern
            btnCreate.Visible = !edtchkDelete.Checked;
            btnCreate.Enabled = (_oldIndexArt == 1);
            btnUndo.Visible = edtchkDelete.Checked;
            btnUndo.Enabled = (_oldIndexArt == 1);

            // Notwendige Spalten anzeigen
            var idx = 22;

            if (edtchkDelete.Checked)
            {
                colFrdrg_VornameName.VisibleIndex = idx;
                idx += 1;
                colFrdrg_Geburtsdatum.VisibleIndex = idx;
                idx += 1;
                colFrdrg_Forderungstitel.VisibleIndex = idx;
                idx += 1;
                colFrdrg_BetragBasis.VisibleIndex = idx;
                idx += 1;
                colFrdrg_DatumAb.VisibleIndex = idx;
                idx += 1;
                colFrdrg_Gueltigbis.VisibleIndex = idx;
            }
            else
            {
                colFrdrg_VornameName.VisibleIndex = -1;
                colFrdrg_Geburtsdatum.VisibleIndex = -1;
                colFrdrg_Forderungstitel.VisibleIndex = -1;
                colFrdrg_BetragBasis.VisibleIndex = -1;
                colFrdrg_DatumAb.VisibleIndex = -1;
                colFrdrg_Gueltigbis.VisibleIndex = -1;
            }

            idx = 22;

            if (!edtchkDelete.Checked)
            {
                colGlb01_VornameName.VisibleIndex = idx;
                idx += 1;
                colGlb01_Geburtsdatum.VisibleIndex = idx;
                idx += 1;
                colGlb01_Forderungstitel.VisibleIndex = idx;
                idx += 1;
                colGlb01_BetragBasis.VisibleIndex = idx;
                idx += 1;
                colGlb01_BetragBerechnet.VisibleIndex = idx;
                idx += 1;
                colGlb01_BetragKiZu.VisibleIndex = idx;
                idx += 1;
                colGlb01_Teuerungseinsprache.VisibleIndex = idx;
                idx += 1;
                colGlb01_IndexPunkte.VisibleIndex = idx;
                idx += 1;

                colGlb02_VornameName.VisibleIndex = idx;
                idx += 1;
                colGlb02_Geburtsdatum.VisibleIndex = idx;
                idx += 1;
                colGlb02_Forderungstitel.VisibleIndex = idx;
                idx += 1;
                colGlb02_BetragBasis.VisibleIndex = idx;
                idx += 1;
                colGlb02_BetragBerechnet.VisibleIndex = idx;
                idx += 1;
                colGlb02_BetragKiZu.VisibleIndex = idx;
                idx += 1;
                colGlb02_Teuerungseinsprache.VisibleIndex = idx;
                idx += 1;
                colGlb02_IndexPunkte.VisibleIndex = idx;
                idx += 1;

                colGlb03_VornameName.VisibleIndex = idx;
                idx += 1;
                colGlb03_Geburtsdatum.VisibleIndex = idx;
                idx += 1;
                colGlb03_Forderungstitel.VisibleIndex = idx;
                idx += 1;
                colGlb03_BetragBasis.VisibleIndex = idx;
                idx += 1;
                colGlb03_BetragBerechnet.VisibleIndex = idx;
                idx += 1;
                colGlb03_BetragKiZu.VisibleIndex = idx;
                idx += 1;
                colGlb03_Teuerungseinsprache.VisibleIndex = idx;
                idx += 1;
                colGlb03_IndexPunkte.VisibleIndex = idx;
                idx += 1;

                colGlb04_VornameName.VisibleIndex = idx;
                idx += 1;
                colGlb04_Geburtsdatum.VisibleIndex = idx;
                idx += 1;
                colGlb04_Forderungstitel.VisibleIndex = idx;
                idx += 1;
                colGlb04_BetragBasis.VisibleIndex = idx;
                idx += 1;
                colGlb04_BetragBerechnet.VisibleIndex = idx;
                idx += 1;
                colGlb04_BetragKiZu.VisibleIndex = idx;
                idx += 1;
                colGlb04_Teuerungseinsprache.VisibleIndex = idx;
                idx += 1;
                colGlb04_IndexPunkte.VisibleIndex = idx;
                idx += 1;

                colGlb05_VornameName.VisibleIndex = idx;
                idx += 1;
                colGlb05_Geburtsdatum.VisibleIndex = idx;
                idx += 1;
                colGlb05_Forderungstitel.VisibleIndex = idx;
                idx += 1;
                colGlb05_BetragBasis.VisibleIndex = idx;
                idx += 1;
                colGlb05_BetragBerechnet.VisibleIndex = idx;
                idx += 1;
                colGlb05_BetragKiZu.VisibleIndex = idx;
                idx += 1;
                colGlb05_Teuerungseinsprache.VisibleIndex = idx;
                idx += 1;
                colGlb05_IndexPunkte.VisibleIndex = idx;
                idx += 1;

                colGlb06_VornameName.VisibleIndex = idx;
                idx += 1;
                colGlb06_Geburtsdatum.VisibleIndex = idx;
                idx += 1;
                colGlb06_Forderungstitel.VisibleIndex = idx;
                idx += 1;
                colGlb06_BetragBasis.VisibleIndex = idx;
                idx += 1;
                colGlb06_BetragBerechnet.VisibleIndex = idx;
                idx += 1;
                colGlb06_BetragKiZu.VisibleIndex = idx;
                idx += 1;
                colGlb06_Teuerungseinsprache.VisibleIndex = idx;
                idx += 1;
                colGlb06_IndexPunkte.VisibleIndex = idx;
                idx += 1;

                colGlb07_VornameName.VisibleIndex = idx;
                idx += 1;
                colGlb07_Geburtsdatum.VisibleIndex = idx;
                idx += 1;
                colGlb07_Forderungstitel.VisibleIndex = idx;
                idx += 1;
                colGlb07_BetragBasis.VisibleIndex = idx;
                idx += 1;
                colGlb07_BetragBerechnet.VisibleIndex = idx;
                idx += 1;
                colGlb07_BetragKiZu.VisibleIndex = idx;
                idx += 1;
                colGlb07_Teuerungseinsprache.VisibleIndex = idx;
                idx += 1;
                colGlb07_IndexPunkte.VisibleIndex = idx;
                idx += 1;

                colGlb08_VornameName.VisibleIndex = idx;
                idx += 1;
                colGlb08_Geburtsdatum.VisibleIndex = idx;
                idx += 1;
                colGlb08_Forderungstitel.VisibleIndex = idx;
                idx += 1;
                colGlb08_BetragBasis.VisibleIndex = idx;
                idx += 1;
                colGlb08_BetragBerechnet.VisibleIndex = idx;
                idx += 1;
                colGlb08_BetragKiZu.VisibleIndex = idx;
                idx += 1;
                colGlb08_Teuerungseinsprache.VisibleIndex = idx;
                idx += 1;
                colGlb08_IndexPunkte.VisibleIndex = idx;
                idx += 1;

                colGlb09_VornameName.VisibleIndex = idx;
                idx += 1;
                colGlb09_Geburtsdatum.VisibleIndex = idx;
                idx += 1;
                colGlb09_Forderungstitel.VisibleIndex = idx;
                idx += 1;
                colGlb09_BetragBasis.VisibleIndex = idx;
                idx += 1;
                colGlb09_BetragBerechnet.VisibleIndex = idx;
                idx += 1;
                colGlb09_BetragKiZu.VisibleIndex = idx;
                idx += 1;
                colGlb09_Teuerungseinsprache.VisibleIndex = idx;
                idx += 1;
                colGlb09_IndexPunkte.VisibleIndex = idx;
                idx += 1;

                colGlb10_VornameName.VisibleIndex = idx;
                idx += 1;
                colGlb10_Geburtsdatum.VisibleIndex = idx;
                idx += 1;
                colGlb10_Forderungstitel.VisibleIndex = idx;
                idx += 1;
                colGlb10_BetragBasis.VisibleIndex = idx;
                idx += 1;
                colGlb10_BetragBerechnet.VisibleIndex = idx;
                idx += 1;
                colGlb10_BetragKiZu.VisibleIndex = idx;
                idx += 1;
                colGlb10_Teuerungseinsprache.VisibleIndex = idx;
                idx += 1;
                colGlb10_IndexPunkte.VisibleIndex = idx;
                idx += 1;

                colLaufendesJahr.VisibleIndex = idx;
                idx += 1;
                colVorhergehendesJahr.VisibleIndex = idx;
                idx += 1;
                colDatumPer.VisibleIndex = idx;
                idx += 1;
            }
            else
            {
                colGlb01_VornameName.VisibleIndex = -1;
                colGlb01_Geburtsdatum.VisibleIndex = -1;
                colGlb01_Forderungstitel.VisibleIndex = -1;
                colGlb01_BetragBasis.VisibleIndex = -1;
                colGlb01_BetragBerechnet.VisibleIndex = -1;
                colGlb01_BetragKiZu.VisibleIndex = -1;
                colGlb01_Teuerungseinsprache.VisibleIndex = -1;
                colGlb01_IndexPunkte.VisibleIndex = -1;

                colGlb02_VornameName.VisibleIndex = -1;
                colGlb02_Geburtsdatum.VisibleIndex = -1;
                colGlb02_Forderungstitel.VisibleIndex = -1;
                colGlb02_BetragBasis.VisibleIndex = -1;
                colGlb02_BetragBerechnet.VisibleIndex = -1;
                colGlb02_BetragKiZu.VisibleIndex = -1;
                colGlb02_Teuerungseinsprache.VisibleIndex = -1;
                colGlb02_IndexPunkte.VisibleIndex = -1;

                colGlb03_VornameName.VisibleIndex = -1;
                colGlb03_Geburtsdatum.VisibleIndex = -1;
                colGlb03_Forderungstitel.VisibleIndex = -1;
                colGlb03_BetragBasis.VisibleIndex = -1;
                colGlb03_BetragBerechnet.VisibleIndex = -1;
                colGlb03_BetragKiZu.VisibleIndex = -1;
                colGlb03_Teuerungseinsprache.VisibleIndex = -1;
                colGlb03_IndexPunkte.VisibleIndex = -1;

                colGlb04_VornameName.VisibleIndex = -1;
                colGlb04_Geburtsdatum.VisibleIndex = -1;
                colGlb04_Forderungstitel.VisibleIndex = -1;
                colGlb04_BetragBasis.VisibleIndex = -1;
                colGlb04_BetragBerechnet.VisibleIndex = -1;
                colGlb04_BetragKiZu.VisibleIndex = -1;
                colGlb04_Teuerungseinsprache.VisibleIndex = -1;
                colGlb04_IndexPunkte.VisibleIndex = -1;

                colGlb05_VornameName.VisibleIndex = -1;
                colGlb05_Geburtsdatum.VisibleIndex = -1;
                colGlb05_Forderungstitel.VisibleIndex = -1;
                colGlb05_BetragBasis.VisibleIndex = -1;
                colGlb05_BetragBerechnet.VisibleIndex = -1;
                colGlb05_BetragKiZu.VisibleIndex = -1;
                colGlb05_Teuerungseinsprache.VisibleIndex = -1;
                colGlb05_IndexPunkte.VisibleIndex = -1;

                colGlb06_VornameName.VisibleIndex = -1;
                colGlb06_Geburtsdatum.VisibleIndex = -1;
                colGlb06_Forderungstitel.VisibleIndex = -1;
                colGlb06_BetragBasis.VisibleIndex = -1;
                colGlb06_BetragBerechnet.VisibleIndex = -1;
                colGlb06_BetragKiZu.VisibleIndex = -1;
                colGlb06_Teuerungseinsprache.VisibleIndex = -1;
                colGlb06_IndexPunkte.VisibleIndex = -1;

                colGlb07_VornameName.VisibleIndex = -1;
                colGlb07_Geburtsdatum.VisibleIndex = -1;
                colGlb07_Forderungstitel.VisibleIndex = -1;
                colGlb07_BetragBasis.VisibleIndex = -1;
                colGlb07_BetragBerechnet.VisibleIndex = -1;
                colGlb07_BetragKiZu.VisibleIndex = -1;
                colGlb07_Teuerungseinsprache.VisibleIndex = -1;
                colGlb07_IndexPunkte.VisibleIndex = -1;

                colGlb08_VornameName.VisibleIndex = -1;
                colGlb08_Geburtsdatum.VisibleIndex = -1;
                colGlb08_Forderungstitel.VisibleIndex = -1;
                colGlb08_BetragBasis.VisibleIndex = -1;
                colGlb08_BetragBerechnet.VisibleIndex = -1;
                colGlb08_BetragKiZu.VisibleIndex = -1;
                colGlb08_Teuerungseinsprache.VisibleIndex = -1;
                colGlb08_IndexPunkte.VisibleIndex = -1;

                colGlb09_VornameName.VisibleIndex = -1;
                colGlb09_Geburtsdatum.VisibleIndex = -1;
                colGlb09_Forderungstitel.VisibleIndex = -1;
                colGlb09_BetragBasis.VisibleIndex = -1;
                colGlb09_BetragBerechnet.VisibleIndex = -1;
                colGlb09_BetragKiZu.VisibleIndex = -1;
                colGlb09_Teuerungseinsprache.VisibleIndex = -1;
                colGlb09_IndexPunkte.VisibleIndex = -1;

                colGlb10_VornameName.VisibleIndex = -1;
                colGlb10_Geburtsdatum.VisibleIndex = -1;
                colGlb10_Forderungstitel.VisibleIndex = -1;
                colGlb10_BetragBasis.VisibleIndex = -1;
                colGlb10_BetragBerechnet.VisibleIndex = -1;
                colGlb10_BetragKiZu.VisibleIndex = -1;
                colGlb10_Teuerungseinsprache.VisibleIndex = -1;
                colGlb10_IndexPunkte.VisibleIndex = -1;

                colLaufendesJahr.VisibleIndex = -1;
                colVorhergehendesJahr.VisibleIndex = -1;
                colDatumPer.VisibleIndex = -1;
            }

            colSB_LogonName.VisibleIndex = idx;
            idx += 1;
            colSB_VornameName.VisibleIndex = idx;
            idx += 1;
            colSB_Displayname.VisibleIndex = idx;
            idx += 1;

            colKopieAn.VisibleIndex = idx;
            idx += 1;
            colKopieAn_SZ.VisibleIndex = idx;
            idx += 1;
            colKopieAn_QT.VisibleIndex = idx;
            idx += 1;

            if (!edtchkDelete.Checked)
            {
                colSumme_Betrag.VisibleIndex = idx;
            }
            else
            {
                colSumme_Betrag.VisibleIndex = -1;
            }
        }

        #endregion

        #region Private Static Methods

        private static void AppendNewLineToStringIfNotEmpty(ref string message)
        {
            if (message != "")
            {
                message = message + "\r\n";
            }
        }

        #endregion

        #endregion
    }
}