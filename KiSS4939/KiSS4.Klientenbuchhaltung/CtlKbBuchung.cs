using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using SharpLibrary.WinControls;
using System;
using System.Data;
using System.Windows.Forms;

namespace KiSS4.Klientenbuchhaltung
{
    /// <summary>
    /// Control, used for manually CRUD bookings
    /// </summary>
    public class CtlKbBuchung : KiSS4.Common.KissSearchUserControl, IBelegleser
    {
        #region Enumerations

        private enum Kontoart
        {
            Normal = 1,
            Vermoegensveraenderung = 10,
            Debitor = 20,
            Kreditor = 30
        }

        #endregion

        #region Fields

        #region Private Constant/Read-Only Fields

        /// <summary>
        /// KbBelegKreisCode for manual bookings
        /// </summary>
        private const int BELEGKREIS_MANUELLEBUCHUNG = 10;

        private const string CLASSNAME = "CtlKbBuchung";

        #endregion

        #region Private Fields

        private bool _emptySearch = false; // new search without default values

        /// <summary>
        /// Query für Institution, welche als Debitor amten können.
        /// </summary>
        private string _institutionStatement = @"
            SELECT BaInstitutionID,
                   Name,
                   Telefon,
                   Fax,
                   EMail,
                   Aktiv,
                   Debitor,
                   Kreditor
            FROM dbo.BaInstitution WITH (READUNCOMMITTED)
            WHERE Debitor = 1
              AND Name LIKE '%' + {0} + '%';";

        /// <summary>
        /// Der aktuelle Mandant.
        /// </summary>
        private int _kbMandantID;

        /// <summary>
        /// Die Periode auf die sich alles bezieht.
        /// </summary>
        private int _kbPeriodeID;

        private KiSS4.Gui.KissGroupBox boxZugehoerigeBelegNr;
        private KissButton btnClearSearch;
        private KiSS4.Gui.KissButton btnUpdateZahlinfo;
        private KissButton btnVerbuchen;
        private DevExpress.XtraGrid.Columns.GridColumn colBelegNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colKbBuchungStatusCode;
        private DevExpress.XtraGrid.Columns.GridColumn colKostenartBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colKostenartBuchungstext;
        private DevExpress.XtraGrid.Columns.GridColumn colKostenartKonto;
        private DevExpress.XtraGrid.Columns.GridColumn colKostenartKostenstelle;
        private DevExpress.XtraGrid.Columns.GridColumn collHaben;
        private DevExpress.XtraGrid.Columns.GridColumn colSoll;
        private DevExpress.XtraGrid.Columns.GridColumn colText;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Common.CtlErfassungMutation ctlErfassungMutation;
        private KissDateEdit edtBelegDatumBisX;
        private KissDateEdit edtBelegDatumVonX;
        private KiSS4.Gui.KissCalcEdit edtBelegNummerBisX;
        private KiSS4.Gui.KissCalcEdit edtBelegNummerVonX;
        private KiSS4.Gui.KissCalcEdit edtBetragBisX;
        private KiSS4.Gui.KissCalcEdit edtBetragVonX;
        private KiSS4.Gui.KissCalcEdit edtBuchenBelegNr;
        private KiSS4.Gui.KissCalcEdit edtBuchenBetrag;
        private KiSS4.Gui.KissCalcEdit edtBuchenBgBudgetID;
        private KiSS4.Gui.KissDateEdit edtBuchenDatum;
        private KiSS4.Gui.KissButtonEdit edtBuchenHaben;
        private KiSS4.Gui.KissCalcEdit edtBuchenHabenSaldo;
        private KiSS4.Gui.KissIntEdit edtBuchenKbBuchungID;
        private KiSS4.Gui.KissButtonEdit edtBuchenSoll;
        private KiSS4.Gui.KissCalcEdit edtBuchenSollSaldo;
        private KiSS4.Gui.KissLookUpEdit edtBuchenStatus;
        private KiSS4.Gui.KissTextEdit edtBuchenText;
        private KiSS4.Gui.KissLookUpEdit edtBuchenTyp;
        private KiSS4.Gui.KissButtonEdit edtDebitor;
        private KiSS4.Gui.KissCalcEdit edtDifferenz;
        private KiSS4.Gui.KissButtonEdit edtErfasserX;
        private KiSS4.Gui.KissDateEdit edtErstelltDatumBisX;
        private KiSS4.Gui.KissDateEdit edtErstelltDatumVonX;
        private KiSS4.Gui.KissTextEdit edtHabenBisX;
        private KiSS4.Gui.KissTextEdit edtHabenVonX;
        private KiSS4.Gui.KissButtonEdit edtKostenart;
        private KiSS4.Gui.KissCalcEdit edtKostenartBetrag;
        private KiSS4.Gui.KissCalcEdit edtKostenartBuchungsBetrag;
        private KiSS4.Gui.KissTextEdit edtKostenartBuchungstext;
        private KiSS4.Gui.KissButtonEdit edtKostenartKostenstelle;
        private KiSS4.Gui.KissDateEdit edtKostenartVerwPeriodeBis;
        private KiSS4.Gui.KissDateEdit edtKostenartVerwPeriodeVon;
        private KiSS4.Gui.KissButtonEdit edtKreditor;
        private KiSS4.Gui.KissTextEdit edtKreditorBankIBAN;
        private KiSS4.Gui.KissTextEdit edtKreditorBankKontoNr;
        private KiSS4.Gui.KissTextEdit edtKreditorBankName;
        private KiSS4.Gui.KissTextEdit edtKreditorBeguenstigtName;
        private KiSS4.Gui.KissTextEdit edtKreditorBeguenstigtName2;
        private KiSS4.Gui.KissTextEdit edtKreditorBeguenstigtOrt;
        private KiSS4.Gui.KissTextEdit edtKreditorBeguenstigtPLZ;
        private KiSS4.Gui.KissTextEdit edtKreditorBeguenstigtStrasse;
        private KiSS4.Gui.KissLookUpEdit edtKreditorEinzahlungsscheinCode;
        private KiSS4.Gui.KissTextEdit edtKreditorLinie;
        private KiSS4.Gui.KissTextEdit edtKreditorMitteilungZeile1;
        private KiSS4.Gui.KissTextEdit edtKreditorMitteilungZeile2;
        private KiSS4.Gui.KissTextEdit edtKreditorMitteilungZeile3;
        private KiSS4.Gui.KissTextEdit edtKreditorMitteilungZeile4;
        private KiSS4.Gui.KissTextEdit edtKreditorPCKontoNrFormat;
        private KiSS4.Common.KissReferenzNrEdit edtKreditorReferenzNummer;
        private KiSS4.Gui.KissCalcEdit edtNeubuchungBelegNr;
        private KiSS4.Gui.KissCalcEdit edtOriginalBelegNr;
        private KiSS4.Gui.KissTextEdit edtSollBisX;
        private KiSS4.Gui.KissTextEdit edtSollVonX;
        private KiSS4.Gui.KissImageComboBoxEdit edtStatusX;
        private KiSS4.Gui.KissCalcEdit edtStornoBelegNr;
        private KiSS4.Gui.KissTextEdit edtTextX;
        private KiSS4.Gui.KissCalcEdit edtTotal;
        private KiSS4.Gui.KissLookUpEdit edtTypX;
        private KiSS4.Gui.KissDateEdit edtValutaDatum;
        private KiSS4.Gui.KissDateEdit edtValutaDatumBisX;
        private KiSS4.Gui.KissDateEdit edtValutaDatumVonX;
        private KiSS4.Gui.KissGrid grdBuchungen;
        private KiSS4.Gui.KissGrid grdKostenart;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBuchungen;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKostenart;
        private KiSS4.Gui.KissLabel lblBankName;
        private KissLabel lblBelegDatumX;
        private KiSS4.Gui.KissLabel lblBelegNr;
        private KiSS4.Gui.KissLabel lblBelegX;
        private KiSS4.Gui.KissLabel lblBetrag;
        private KiSS4.Gui.KissLabel lblBetragX;
        private KiSS4.Gui.KissLabel lblBis1X;
        private KissLabel lblBis2X;
        private KiSS4.Gui.KissLabel lblBis3X;
        private KiSS4.Gui.KissLabel lblBis4X;
        private KiSS4.Gui.KissLabel lblBis5X;
        private KiSS4.Gui.KissLabel lblBis6X;
        private KiSS4.Gui.KissLabel lblBis7X;
        private KiSS4.Gui.KissLabel lblBuchenBgBudgetID;
        private KiSS4.Gui.KissLabel lblBuchenBudgetMonatJahr;
        private KiSS4.Gui.KissLabel lblBuchenKbBuchungID;
        private KiSS4.Gui.KissLabel lblBuchenStatus;
        private KiSS4.Gui.KissLabel lblBuchenStorno2;
        private KiSS4.Gui.KissLabel lblBuchenValuta;
        private KiSS4.Gui.KissLabel lblDatum;
        private KiSS4.Gui.KissLabel lblDebitor;
        private KiSS4.Gui.KissLabel lblDetails;
        private KiSS4.Gui.KissLabel lblErfasserX;
        private KiSS4.Gui.KissLabel lblErstelltX;
        private KiSS4.Gui.KissLabel lblHaben;
        private KiSS4.Gui.KissLabel lblHabenX;
        private KiSS4.Gui.KissLabel lblKostenartBetrag;
        private KiSS4.Gui.KissLabel lblKostenartBuchungsbetrag;
        private KiSS4.Gui.KissLabel lblKostenartBuchungstext;
        private KiSS4.Gui.KissLabel lblKostenartDifferenz;
        private KiSS4.Gui.KissLabel lblKostenartKonto;
        private KiSS4.Gui.KissLabel lblKostenartKostenstelle;
        private KiSS4.Gui.KissLabel lblKostenartTotal;
        private KiSS4.Gui.KissLabel lblKostenartVerwPeriodeBis;
        private KiSS4.Gui.KissLabel lblKostenartVerwPeriodeVon;
        private KiSS4.Gui.KissLabel lblKostenartZusammenfassung;
        private KiSS4.Gui.KissLabel lblKostenartZusammenfassungtotal;
        private KiSS4.Gui.KissLabel lblKreditor;
        private KiSS4.Gui.KissLabel lblKreditorBankIBAN;
        private KiSS4.Gui.KissLabel lblKreditorBankKontoNr;
        private KiSS4.Gui.KissLabel lblKreditorBankName;
        private KiSS4.Gui.KissLabel lblKreditorBeguenstigtName;
        private KiSS4.Gui.KissLabel lblKreditorBeguenstigtName2;
        private KiSS4.Gui.KissLabel lblKreditorBeguenstigtPLZOrt;
        private KiSS4.Gui.KissLabel lblKreditorBeguenstigtStrasseNr;
        private KiSS4.Gui.KissLabel lblKreditorReferenzNummer;
        private KiSS4.Gui.KissLabel lblMitteilung;
        private KiSS4.Gui.KissLabel lblOriginalBelegNr;
        private KissLabel lblRowCount;
        private KiSS4.Gui.KissLabel lblSoll;
        private KiSS4.Gui.KissLabel lblSollX;
        private KiSS4.Gui.KissLabel lblStatusX;
        private KiSS4.Gui.KissLabel lblStornoBelegNr;
        private KiSS4.Gui.KissLabel lblText;
        private KiSS4.Gui.KissLabel lblTextX;
        private KiSS4.Gui.KissLabel lblTyp;
        private KiSS4.Gui.KissLabel lblTypX;
        private KiSS4.Gui.KissLabel lblValutaX;
        private KiSS4.Gui.KissLabel lblZahlinfo;
        private KiSS4.Gui.KissScrollablePanel panDetails;
        private Panel panSetStatus;
        private Panel panSetStatusBorder;
        private KiSS4.DB.SqlQuery qryHabenSaldo;
        private KiSS4.DB.SqlQuery qryKbBuchung;
        private KiSS4.DB.SqlQuery qryKontoart;
        private KiSS4.DB.SqlQuery qryKostenart;
        private KiSS4.DB.SqlQuery qrySollSaldo;
        private KiSS4.DB.SqlQuery qryTotal;
        private KiSS4.DB.SqlQuery qryZugehoerigeBelegNr;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repStatusImg;
        private KiSS4.Gui.KissTabControlEx tabBuchen;
        private SharpLibrary.WinControls.TabPageEx tpgBuchenDetails;
        private SharpLibrary.WinControls.TabPageEx tpgDebitor;
        private SharpLibrary.WinControls.TabPageEx tpgKostenarten;
        private SharpLibrary.WinControls.TabPageEx tpgKreditor;
        private ToolTip ttpControls;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlKbBuchung"/> class.
        /// </summary>
        public CtlKbBuchung()
        {
            // init components
            this.InitializeComponent();

            // setup row count label with default text
            UpdateRowCount();

            // setup controls for multilanguage handling
            SetupControlsML();
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKbBuchung));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject22 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject21 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject20 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject19 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject18 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject17 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject14 = new DevExpress.Utils.SerializableAppearanceObject();
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject15 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject16 = new DevExpress.Utils.SerializableAppearanceObject();
            this.components = new System.ComponentModel.Container();
            this.grdBuchungen = new KiSS4.Gui.KissGrid();
            this.qryKbBuchung = new KiSS4.DB.SqlQuery();
            this.grvBuchungen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBelegNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoll = new DevExpress.XtraGrid.Columns.GridColumn();
            this.collHaben = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKbBuchungStatusCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repStatusImg = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colBuchungTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblErstelltX = new KiSS4.Gui.KissLabel();
            this.edtErstelltDatumVonX = new KiSS4.Gui.KissDateEdit();
            this.lblBis3X = new KiSS4.Gui.KissLabel();
            this.edtErstelltDatumBisX = new KiSS4.Gui.KissDateEdit();
            this.lblValutaX = new KiSS4.Gui.KissLabel();
            this.edtValutaDatumVonX = new KiSS4.Gui.KissDateEdit();
            this.lblBis4X = new KiSS4.Gui.KissLabel();
            this.edtValutaDatumBisX = new KiSS4.Gui.KissDateEdit();
            this.lblBelegX = new KiSS4.Gui.KissLabel();
            this.edtBelegNummerVonX = new KiSS4.Gui.KissCalcEdit();
            this.lblBis1X = new KiSS4.Gui.KissLabel();
            this.edtBelegNummerBisX = new KiSS4.Gui.KissCalcEdit();
            this.lblSollX = new KiSS4.Gui.KissLabel();
            this.edtSollVonX = new KiSS4.Gui.KissTextEdit();
            this.lblBis6X = new KiSS4.Gui.KissLabel();
            this.edtSollBisX = new KiSS4.Gui.KissTextEdit();
            this.lblHabenX = new KiSS4.Gui.KissLabel();
            this.edtHabenVonX = new KiSS4.Gui.KissTextEdit();
            this.lblBis7X = new KiSS4.Gui.KissLabel();
            this.edtHabenBisX = new KiSS4.Gui.KissTextEdit();
            this.lblBetragX = new KiSS4.Gui.KissLabel();
            this.edtBetragVonX = new KiSS4.Gui.KissCalcEdit();
            this.lblBis5X = new KiSS4.Gui.KissLabel();
            this.edtBetragBisX = new KiSS4.Gui.KissCalcEdit();
            this.lblTextX = new KiSS4.Gui.KissLabel();
            this.edtTextX = new KiSS4.Gui.KissTextEdit();
            this.lblStatusX = new KiSS4.Gui.KissLabel();
            this.edtStatusX = new KiSS4.Gui.KissImageComboBoxEdit();
            this.lblTypX = new KiSS4.Gui.KissLabel();
            this.edtTypX = new KiSS4.Gui.KissLookUpEdit();
            this.lblErfasserX = new KiSS4.Gui.KissLabel();
            this.edtErfasserX = new KiSS4.Gui.KissButtonEdit();
            this.panDetails = new KiSS4.Gui.KissScrollablePanel();
            this.tabBuchen = new KiSS4.Gui.KissTabControlEx();
            this.tpgDebitor = new SharpLibrary.WinControls.TabPageEx();
            this.edtDebitor = new KiSS4.Gui.KissButtonEdit();
            this.lblDebitor = new KiSS4.Gui.KissLabel();
            this.tpgKreditor = new SharpLibrary.WinControls.TabPageEx();
            this.edtKreditorLinie = new KiSS4.Gui.KissTextEdit();
            this.edtKreditorBankIBAN = new KiSS4.Gui.KissTextEdit();
            this.lblKreditorBankIBAN = new KiSS4.Gui.KissLabel();
            this.edtKreditorBankKontoNr = new KiSS4.Gui.KissTextEdit();
            this.lblKreditorBankKontoNr = new KiSS4.Gui.KissLabel();
            this.edtKreditorPCKontoNrFormat = new KiSS4.Gui.KissTextEdit();
            this.lblKreditorBankName = new KiSS4.Gui.KissLabel();
            this.edtKreditorBankName = new KiSS4.Gui.KissTextEdit();
            this.lblBankName = new KiSS4.Gui.KissLabel();
            this.btnUpdateZahlinfo = new KiSS4.Gui.KissButton();
            this.lblZahlinfo = new KiSS4.Gui.KissLabel();
            this.edtKreditorBeguenstigtOrt = new KiSS4.Gui.KissTextEdit();
            this.edtKreditorBeguenstigtPLZ = new KiSS4.Gui.KissTextEdit();
            this.lblKreditorBeguenstigtPLZOrt = new KiSS4.Gui.KissLabel();
            this.edtKreditorBeguenstigtStrasse = new KiSS4.Gui.KissTextEdit();
            this.lblKreditorBeguenstigtStrasseNr = new KiSS4.Gui.KissLabel();
            this.edtKreditorBeguenstigtName2 = new KiSS4.Gui.KissTextEdit();
            this.lblKreditorBeguenstigtName2 = new KiSS4.Gui.KissLabel();
            this.edtKreditorBeguenstigtName = new KiSS4.Gui.KissTextEdit();
            this.lblKreditorBeguenstigtName = new KiSS4.Gui.KissLabel();
            this.lblDetails = new KiSS4.Gui.KissLabel();
            this.edtKreditorEinzahlungsscheinCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtKreditorReferenzNummer = new KiSS4.Common.KissReferenzNrEdit();
            this.lblKreditorReferenzNummer = new KiSS4.Gui.KissLabel();
            this.edtKreditorMitteilungZeile4 = new KiSS4.Gui.KissTextEdit();
            this.edtKreditorMitteilungZeile3 = new KiSS4.Gui.KissTextEdit();
            this.edtKreditorMitteilungZeile2 = new KiSS4.Gui.KissTextEdit();
            this.edtKreditorMitteilungZeile1 = new KiSS4.Gui.KissTextEdit();
            this.lblMitteilung = new KiSS4.Gui.KissLabel();
            this.edtKreditor = new KiSS4.Gui.KissButtonEdit();
            this.lblKreditor = new KiSS4.Gui.KissLabel();
            this.tpgKostenarten = new SharpLibrary.WinControls.TabPageEx();
            this.edtDifferenz = new KiSS4.Gui.KissCalcEdit();
            this.lblKostenartDifferenz = new KiSS4.Gui.KissLabel();
            this.edtTotal = new KiSS4.Gui.KissCalcEdit();
            this.lblKostenartTotal = new KiSS4.Gui.KissLabel();
            this.edtKostenartBuchungsBetrag = new KiSS4.Gui.KissCalcEdit();
            this.lblKostenartBuchungsbetrag = new KiSS4.Gui.KissLabel();
            this.lblKostenartZusammenfassungtotal = new KiSS4.Gui.KissLabel();
            this.qryTotal = new KiSS4.DB.SqlQuery();
            this.lblKostenartZusammenfassung = new KiSS4.Gui.KissLabel();
            this.edtKostenartVerwPeriodeBis = new KiSS4.Gui.KissDateEdit();
            this.qryKostenart = new KiSS4.DB.SqlQuery();
            this.lblKostenartVerwPeriodeBis = new KiSS4.Gui.KissLabel();
            this.edtKostenartVerwPeriodeVon = new KiSS4.Gui.KissDateEdit();
            this.lblKostenartVerwPeriodeVon = new KiSS4.Gui.KissLabel();
            this.edtKostenartBuchungstext = new KiSS4.Gui.KissTextEdit();
            this.lblKostenartBuchungstext = new KiSS4.Gui.KissLabel();
            this.edtKostenart = new KiSS4.Gui.KissButtonEdit();
            this.lblKostenartKonto = new KiSS4.Gui.KissLabel();
            this.edtKostenartBetrag = new KiSS4.Gui.KissCalcEdit();
            this.lblKostenartBetrag = new KiSS4.Gui.KissLabel();
            this.edtKostenartKostenstelle = new KiSS4.Gui.KissButtonEdit();
            this.lblKostenartKostenstelle = new KiSS4.Gui.KissLabel();
            this.grdKostenart = new KiSS4.Gui.KissGrid();
            this.grvKostenart = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKostenartKonto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKostenartKostenstelle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKostenartBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKostenartBuchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpgBuchenDetails = new SharpLibrary.WinControls.TabPageEx();
            this.panSetStatus = new System.Windows.Forms.Panel();
            this.panSetStatusBorder = new System.Windows.Forms.Panel();
            this.btnVerbuchen = new KiSS4.Gui.KissButton();
            this.ctlErfassungMutation = new KiSS4.Common.CtlErfassungMutation();
            this.boxZugehoerigeBelegNr = new KiSS4.Gui.KissGroupBox();
            this.edtNeubuchungBelegNr = new KiSS4.Gui.KissCalcEdit();
            this.qryZugehoerigeBelegNr = new KiSS4.DB.SqlQuery();
            this.lblBuchenStorno2 = new KiSS4.Gui.KissLabel();
            this.edtStornoBelegNr = new KiSS4.Gui.KissCalcEdit();
            this.lblStornoBelegNr = new KiSS4.Gui.KissLabel();
            this.edtOriginalBelegNr = new KiSS4.Gui.KissCalcEdit();
            this.lblOriginalBelegNr = new KiSS4.Gui.KissLabel();
            this.edtBuchenKbBuchungID = new KiSS4.Gui.KissIntEdit();
            this.lblBuchenKbBuchungID = new KiSS4.Gui.KissLabel();
            this.edtBuchenBgBudgetID = new KiSS4.Gui.KissCalcEdit();
            this.lblBuchenBudgetMonatJahr = new KiSS4.Gui.KissLabel();
            this.lblBuchenBgBudgetID = new KiSS4.Gui.KissLabel();
            this.edtBuchenStatus = new KiSS4.Gui.KissLookUpEdit();
            this.lblBuchenStatus = new KiSS4.Gui.KissLabel();
            this.edtBuchenText = new KiSS4.Gui.KissTextEdit();
            this.lblText = new KiSS4.Gui.KissLabel();
            this.edtBuchenTyp = new KiSS4.Gui.KissLookUpEdit();
            this.lblTyp = new KiSS4.Gui.KissLabel();
            this.edtBuchenBelegNr = new KiSS4.Gui.KissCalcEdit();
            this.lblBelegNr = new KiSS4.Gui.KissLabel();
            this.edtBuchenBetrag = new KiSS4.Gui.KissCalcEdit();
            this.lblBetrag = new KiSS4.Gui.KissLabel();
            this.edtBuchenHabenSaldo = new KiSS4.Gui.KissCalcEdit();
            this.qryHabenSaldo = new KiSS4.DB.SqlQuery();
            this.edtBuchenHaben = new KiSS4.Gui.KissButtonEdit();
            this.lblHaben = new KiSS4.Gui.KissLabel();
            this.edtBuchenSollSaldo = new KiSS4.Gui.KissCalcEdit();
            this.qrySollSaldo = new KiSS4.DB.SqlQuery();
            this.edtBuchenSoll = new KiSS4.Gui.KissButtonEdit();
            this.lblSoll = new KiSS4.Gui.KissLabel();
            this.edtValutaDatum = new KiSS4.Gui.KissDateEdit();
            this.lblBuchenValuta = new KiSS4.Gui.KissLabel();
            this.edtBuchenDatum = new KiSS4.Gui.KissDateEdit();
            this.lblDatum = new KiSS4.Gui.KissLabel();
            this.qryKontoart = new KiSS4.DB.SqlQuery();
            this.lblRowCount = new KiSS4.Gui.KissLabel();
            this.ttpControls = new System.Windows.Forms.ToolTip();
            this.btnClearSearch = new KiSS4.Gui.KissButton();
            this.edtBelegDatumBisX = new KiSS4.Gui.KissDateEdit();
            this.lblBis2X = new KiSS4.Gui.KissLabel();
            this.edtBelegDatumVonX = new KiSS4.Gui.KissDateEdit();
            this.lblBelegDatumX = new KiSS4.Gui.KissLabel();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBuchungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKbBuchung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBuchungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repStatusImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErstelltX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErstelltDatumVonX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis3X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErstelltDatumBisX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValutaX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValutaDatumVonX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis4X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValutaDatumBisX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegNummerVonX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis1X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegNummerBisX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollVonX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis6X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollBisX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHabenX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHabenVonX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis7X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHabenBisX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetragX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetragVonX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis5X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetragBisX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTextX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTextX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatusX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTypX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTypX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTypX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfasserX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfasserX.Properties)).BeginInit();
            this.panDetails.SuspendLayout();
            this.tabBuchen.SuspendLayout();
            this.tpgDebitor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtDebitor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDebitor)).BeginInit();
            this.tpgKreditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditorLinie.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditorBankIBAN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditorBankIBAN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditorBankKontoNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditorBankKontoNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditorPCKontoNrFormat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditorBankName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditorBankName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBankName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlinfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditorBeguenstigtOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditorBeguenstigtPLZ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditorBeguenstigtPLZOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditorBeguenstigtStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditorBeguenstigtStrasseNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditorBeguenstigtName2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditorBeguenstigtName2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditorBeguenstigtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditorBeguenstigtName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditorEinzahlungsscheinCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditorEinzahlungsscheinCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditorReferenzNummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditorReferenzNummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditorMitteilungZeile4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditorMitteilungZeile3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditorMitteilungZeile2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditorMitteilungZeile1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMitteilung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditor)).BeginInit();
            this.tpgKostenarten.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtDifferenz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenartDifferenz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenartTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenartBuchungsBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenartBuchungsbetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenartZusammenfassungtotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenartZusammenfassung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenartVerwPeriodeBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKostenart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenartVerwPeriodeBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenartVerwPeriodeVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenartVerwPeriodeVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenartBuchungstext.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenartBuchungstext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenartKonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenartBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenartBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenartKostenstelle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenartKostenstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKostenart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKostenart)).BeginInit();
            this.tpgBuchenDetails.SuspendLayout();
            this.panSetStatus.SuspendLayout();
            this.boxZugehoerigeBelegNr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtNeubuchungBelegNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugehoerigeBelegNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchenStorno2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStornoBelegNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStornoBelegNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOriginalBelegNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOriginalBelegNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchenKbBuchungID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchenKbBuchungID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchenBgBudgetID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchenBudgetMonatJahr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchenBgBudgetID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchenStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchenStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchenStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchenText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchenTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchenTyp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchenBelegNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchenBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchenHabenSaldo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryHabenSaldo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchenHaben.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHaben)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchenSollSaldo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrySollSaldo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchenSoll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValutaDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchenValuta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchenDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKontoart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRowCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegDatumBisX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis2X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegDatumVonX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegDatumX)).BeginInit();
            this.SuspendLayout();
            //
            // searchTitle
            //
            this.searchTitle.Location = new System.Drawing.Point(8, 6);
            this.searchTitle.Size = new System.Drawing.Size(720, 24);
            //
            // tabControlSearch
            //
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(744, 268);
            this.tabControlSearch.Text = "kissTabControlEx1";
            this.tabControlSearch.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControlSearch_SelectedTabChanged);
            this.tabControlSearch.SelectedTabChanging += new System.ComponentModel.CancelEventHandler(this.tabControlSearch_SelectedTabChanging);
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.grdBuchungen);
            this.tpgListe.Size = new System.Drawing.Size(732, 230);
            this.tpgListe.Title = "Liste";
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.edtBelegDatumBisX);
            this.tpgSuchen.Controls.Add(this.lblBis2X);
            this.tpgSuchen.Controls.Add(this.edtBelegDatumVonX);
            this.tpgSuchen.Controls.Add(this.lblBelegDatumX);
            this.tpgSuchen.Controls.Add(this.btnClearSearch);
            this.tpgSuchen.Controls.Add(this.edtErfasserX);
            this.tpgSuchen.Controls.Add(this.lblErfasserX);
            this.tpgSuchen.Controls.Add(this.edtTypX);
            this.tpgSuchen.Controls.Add(this.lblTypX);
            this.tpgSuchen.Controls.Add(this.edtStatusX);
            this.tpgSuchen.Controls.Add(this.lblStatusX);
            this.tpgSuchen.Controls.Add(this.edtTextX);
            this.tpgSuchen.Controls.Add(this.lblTextX);
            this.tpgSuchen.Controls.Add(this.edtBetragBisX);
            this.tpgSuchen.Controls.Add(this.lblBis5X);
            this.tpgSuchen.Controls.Add(this.edtBetragVonX);
            this.tpgSuchen.Controls.Add(this.lblBetragX);
            this.tpgSuchen.Controls.Add(this.edtHabenBisX);
            this.tpgSuchen.Controls.Add(this.lblBis7X);
            this.tpgSuchen.Controls.Add(this.edtHabenVonX);
            this.tpgSuchen.Controls.Add(this.lblHabenX);
            this.tpgSuchen.Controls.Add(this.edtSollBisX);
            this.tpgSuchen.Controls.Add(this.lblBis6X);
            this.tpgSuchen.Controls.Add(this.edtSollVonX);
            this.tpgSuchen.Controls.Add(this.lblSollX);
            this.tpgSuchen.Controls.Add(this.edtBelegNummerBisX);
            this.tpgSuchen.Controls.Add(this.lblBis1X);
            this.tpgSuchen.Controls.Add(this.edtBelegNummerVonX);
            this.tpgSuchen.Controls.Add(this.lblBelegX);
            this.tpgSuchen.Controls.Add(this.edtValutaDatumBisX);
            this.tpgSuchen.Controls.Add(this.lblBis4X);
            this.tpgSuchen.Controls.Add(this.edtValutaDatumVonX);
            this.tpgSuchen.Controls.Add(this.lblValutaX);
            this.tpgSuchen.Controls.Add(this.edtErstelltDatumBisX);
            this.tpgSuchen.Controls.Add(this.lblBis3X);
            this.tpgSuchen.Controls.Add(this.edtErstelltDatumVonX);
            this.tpgSuchen.Controls.Add(this.lblErstelltX);
            this.tpgSuchen.Size = new System.Drawing.Size(732, 230);
            this.tpgSuchen.TabIndex = 0;
            this.tpgSuchen.Title = "Suchen";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblErstelltX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtErstelltDatumVonX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBis3X, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtErstelltDatumBisX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblValutaX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtValutaDatumVonX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBis4X, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtValutaDatumBisX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBelegX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBelegNummerVonX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBis1X, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBelegNummerBisX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSollX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSollVonX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBis6X, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSollBisX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblHabenX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtHabenVonX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBis7X, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtHabenBisX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBetragX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBetragVonX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBis5X, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBetragBisX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblTextX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtTextX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblStatusX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtStatusX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblTypX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtTypX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblErfasserX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtErfasserX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.btnClearSearch, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBelegDatumX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBelegDatumVonX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBis2X, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBelegDatumBisX, 0);
            //
            // grdBuchungen
            //
            this.grdBuchungen.DataSource = this.qryKbBuchung;
            this.grdBuchungen.Dock = System.Windows.Forms.DockStyle.Fill;
            //
            //
            //
            this.grdBuchungen.EmbeddedNavigator.Name = "";
            this.grdBuchungen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBuchungen.Location = new System.Drawing.Point(0, 0);
            this.grdBuchungen.MainView = this.grvBuchungen;
            this.grdBuchungen.Name = "grdBuchungen";
            this.grdBuchungen.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repStatusImg});
            this.grdBuchungen.Size = new System.Drawing.Size(732, 230);
            this.grdBuchungen.TabIndex = 0;
            this.grdBuchungen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBuchungen});
            //
            // qryKbBuchung
            //
            this.qryKbBuchung.CanDelete = true;
            this.qryKbBuchung.CanInsert = true;
            this.qryKbBuchung.CanUpdate = true;
            this.qryKbBuchung.HostControl = this;
            this.qryKbBuchung.SelectStatement = resources.GetString("qryKbBuchung.SelectStatement");
            this.qryKbBuchung.TableName = "KbBuchung";
            this.qryKbBuchung.AfterFill += new System.EventHandler(this.qryKbBuchung_AfterFill);
            this.qryKbBuchung.AfterInsert += new System.EventHandler(this.qryKbBuchung_AfterInsert);
            this.qryKbBuchung.BeforePost += new System.EventHandler(this.qryKbBuchung_BeforePost);
            this.qryKbBuchung.AfterPost += new System.EventHandler(this.qryKbBuchung_AfterPost);
            this.qryKbBuchung.BeforeDeleteQuestion += new System.EventHandler(this.qryKbBuchung_BeforeDeleteQuestion);
            this.qryKbBuchung.BeforeDelete += new System.EventHandler(this.qryKbBuchung_BeforeDelete);
            this.qryKbBuchung.AfterDelete += new System.EventHandler(this.qryKbBuchung_AfterDelete);
            this.qryKbBuchung.DeleteError += new System.UnhandledExceptionEventHandler(this.qryKbBuchung_DeleteError);
            this.qryKbBuchung.PositionChanged += new System.EventHandler(this.qryKbBuchung_PositionChanged);
            //
            // grvBuchungen
            //
            this.grvBuchungen.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBuchungen.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBuchungen.Appearance.Empty.Options.UseBackColor = true;
            this.grvBuchungen.Appearance.Empty.Options.UseFont = true;
            this.grvBuchungen.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBuchungen.Appearance.EvenRow.Options.UseFont = true;
            this.grvBuchungen.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBuchungen.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBuchungen.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBuchungen.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBuchungen.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBuchungen.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBuchungen.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBuchungen.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBuchungen.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBuchungen.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBuchungen.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBuchungen.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBuchungen.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBuchungen.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBuchungen.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBuchungen.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBuchungen.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBuchungen.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBuchungen.Appearance.GroupRow.Options.UseFont = true;
            this.grvBuchungen.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBuchungen.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBuchungen.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBuchungen.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBuchungen.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBuchungen.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBuchungen.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBuchungen.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBuchungen.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBuchungen.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBuchungen.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBuchungen.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBuchungen.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBuchungen.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBuchungen.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBuchungen.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBuchungen.Appearance.OddRow.Options.UseFont = true;
            this.grvBuchungen.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBuchungen.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBuchungen.Appearance.Row.Options.UseBackColor = true;
            this.grvBuchungen.Appearance.Row.Options.UseFont = true;
            this.grvBuchungen.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBuchungen.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBuchungen.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBuchungen.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBuchungen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBuchungen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatum,
            this.colBelegNummer,
            this.colText,
            this.colBetrag,
            this.colSoll,
            this.collHaben,
            this.colKbBuchungStatusCode,
            this.colBuchungTyp});
            this.grvBuchungen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBuchungen.GridControl = this.grdBuchungen;
            this.grvBuchungen.Name = "grvBuchungen";
            this.grvBuchungen.OptionsBehavior.Editable = false;
            this.grvBuchungen.OptionsCustomization.AllowFilter = false;
            this.grvBuchungen.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBuchungen.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBuchungen.OptionsNavigation.UseTabKey = false;
            this.grvBuchungen.OptionsView.ColumnAutoWidth = false;
            this.grvBuchungen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBuchungen.OptionsView.ShowGroupPanel = false;
            this.grvBuchungen.OptionsView.ShowIndicator = false;
            //
            // colDatum
            //
            this.colDatum.Caption = "Beleg Datum";
            this.colDatum.FieldName = "BelegDatum";
            this.colDatum.Name = "colDatum";
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 0;
            this.colDatum.Width = 85;
            //
            // colBelegNummer
            //
            this.colBelegNummer.Caption = "Beleg-Nr.";
            this.colBelegNummer.FieldName = "BelegNr";
            this.colBelegNummer.Name = "colBelegNummer";
            this.colBelegNummer.Visible = true;
            this.colBelegNummer.VisibleIndex = 1;
            this.colBelegNummer.Width = 85;
            //
            // colText
            //
            this.colText.Caption = "Buchungstext";
            this.colText.FieldName = "Text";
            this.colText.Name = "colText";
            this.colText.Visible = true;
            this.colText.VisibleIndex = 2;
            this.colText.Width = 200;
            //
            // colBetrag
            //
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "N2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 3;
            this.colBetrag.Width = 95;
            //
            // colSoll
            //
            this.colSoll.Caption = "Soll";
            this.colSoll.FieldName = "SollKtoName";
            this.colSoll.Name = "colSoll";
            this.colSoll.Visible = true;
            this.colSoll.VisibleIndex = 4;
            this.colSoll.Width = 100;
            //
            // collHaben
            //
            this.collHaben.Caption = "Haben";
            this.collHaben.FieldName = "HabenKtoName";
            this.collHaben.Name = "collHaben";
            this.collHaben.Visible = true;
            this.collHaben.VisibleIndex = 5;
            this.collHaben.Width = 100;
            //
            // colKbBuchungStatusCode
            //
            this.colKbBuchungStatusCode.Caption = "Status";
            this.colKbBuchungStatusCode.ColumnEdit = this.repStatusImg;
            this.colKbBuchungStatusCode.FieldName = "KbBuchungStatusCode";
            this.colKbBuchungStatusCode.Name = "colKbBuchungStatusCode";
            this.colKbBuchungStatusCode.Visible = true;
            this.colKbBuchungStatusCode.VisibleIndex = 6;
            this.colKbBuchungStatusCode.Width = 50;
            //
            // repStatusImg
            //
            this.repStatusImg.AutoHeight = false;
            this.repStatusImg.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repStatusImg.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repStatusImg.Name = "repStatusImg";
            //
            // colBuchungTyp
            //
            this.colBuchungTyp.Caption = "Buchung Typ";
            this.colBuchungTyp.FieldName = "KbBuchungTypCode";
            this.colBuchungTyp.Name = "colBuchungTyp";
            //
            // lblErstelltX
            //
            this.lblErstelltX.Location = new System.Drawing.Point(30, 91);
            this.lblErstelltX.Name = "lblErstelltX";
            this.lblErstelltX.Size = new System.Drawing.Size(62, 24);
            this.lblErstelltX.TabIndex = 9;
            this.lblErstelltX.Text = "Erstellt";
            this.lblErstelltX.UseCompatibleTextRendering = true;
            //
            // edtErstelltDatumVonX
            //
            this.edtErstelltDatumVonX.EditValue = null;
            this.edtErstelltDatumVonX.Location = new System.Drawing.Point(98, 91);
            this.edtErstelltDatumVonX.Name = "edtErstelltDatumVonX";
            this.edtErstelltDatumVonX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtErstelltDatumVonX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErstelltDatumVonX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErstelltDatumVonX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErstelltDatumVonX.Properties.Appearance.Options.UseBackColor = true;
            this.edtErstelltDatumVonX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErstelltDatumVonX.Properties.Appearance.Options.UseFont = true;
            this.edtErstelltDatumVonX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject22.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject22.Options.UseBackColor = true;
            this.edtErstelltDatumVonX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtErstelltDatumVonX.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject22)});
            this.edtErstelltDatumVonX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErstelltDatumVonX.Properties.ShowToday = false;
            this.edtErstelltDatumVonX.Size = new System.Drawing.Size(100, 24);
            this.edtErstelltDatumVonX.TabIndex = 10;
            //
            // lblBis3X
            //
            this.lblBis3X.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblBis3X.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblBis3X.Location = new System.Drawing.Point(198, 91);
            this.lblBis3X.Name = "lblBis3X";
            this.lblBis3X.Size = new System.Drawing.Size(25, 24);
            this.lblBis3X.TabIndex = 11;
            this.lblBis3X.Text = "-";
            this.lblBis3X.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBis3X.UseCompatibleTextRendering = true;
            //
            // edtErstelltDatumBisX
            //
            this.edtErstelltDatumBisX.EditValue = null;
            this.edtErstelltDatumBisX.Location = new System.Drawing.Point(223, 91);
            this.edtErstelltDatumBisX.Name = "edtErstelltDatumBisX";
            this.edtErstelltDatumBisX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtErstelltDatumBisX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErstelltDatumBisX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErstelltDatumBisX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErstelltDatumBisX.Properties.Appearance.Options.UseBackColor = true;
            this.edtErstelltDatumBisX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErstelltDatumBisX.Properties.Appearance.Options.UseFont = true;
            this.edtErstelltDatumBisX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject21.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject21.Options.UseBackColor = true;
            this.edtErstelltDatumBisX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtErstelltDatumBisX.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject21)});
            this.edtErstelltDatumBisX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErstelltDatumBisX.Properties.ShowToday = false;
            this.edtErstelltDatumBisX.Size = new System.Drawing.Size(100, 24);
            this.edtErstelltDatumBisX.TabIndex = 12;
            //
            // lblValutaX
            //
            this.lblValutaX.Location = new System.Drawing.Point(30, 120);
            this.lblValutaX.Name = "lblValutaX";
            this.lblValutaX.Size = new System.Drawing.Size(62, 24);
            this.lblValutaX.TabIndex = 13;
            this.lblValutaX.Text = "Valuta";
            this.lblValutaX.UseCompatibleTextRendering = true;
            //
            // edtValutaDatumVonX
            //
            this.edtValutaDatumVonX.EditValue = null;
            this.edtValutaDatumVonX.Location = new System.Drawing.Point(98, 120);
            this.edtValutaDatumVonX.Name = "edtValutaDatumVonX";
            this.edtValutaDatumVonX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtValutaDatumVonX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtValutaDatumVonX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtValutaDatumVonX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtValutaDatumVonX.Properties.Appearance.Options.UseBackColor = true;
            this.edtValutaDatumVonX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtValutaDatumVonX.Properties.Appearance.Options.UseFont = true;
            this.edtValutaDatumVonX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject20.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject20.Options.UseBackColor = true;
            this.edtValutaDatumVonX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtValutaDatumVonX.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject20)});
            this.edtValutaDatumVonX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtValutaDatumVonX.Properties.ShowToday = false;
            this.edtValutaDatumVonX.Size = new System.Drawing.Size(100, 24);
            this.edtValutaDatumVonX.TabIndex = 14;
            //
            // lblBis4X
            //
            this.lblBis4X.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblBis4X.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblBis4X.Location = new System.Drawing.Point(198, 120);
            this.lblBis4X.Name = "lblBis4X";
            this.lblBis4X.Size = new System.Drawing.Size(25, 24);
            this.lblBis4X.TabIndex = 15;
            this.lblBis4X.Text = "-";
            this.lblBis4X.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBis4X.UseCompatibleTextRendering = true;
            //
            // edtValutaDatumBisX
            //
            this.edtValutaDatumBisX.EditValue = null;
            this.edtValutaDatumBisX.Location = new System.Drawing.Point(223, 120);
            this.edtValutaDatumBisX.Name = "edtValutaDatumBisX";
            this.edtValutaDatumBisX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtValutaDatumBisX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtValutaDatumBisX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtValutaDatumBisX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtValutaDatumBisX.Properties.Appearance.Options.UseBackColor = true;
            this.edtValutaDatumBisX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtValutaDatumBisX.Properties.Appearance.Options.UseFont = true;
            this.edtValutaDatumBisX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject19.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject19.Options.UseBackColor = true;
            this.edtValutaDatumBisX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtValutaDatumBisX.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject19)});
            this.edtValutaDatumBisX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtValutaDatumBisX.Properties.ShowToday = false;
            this.edtValutaDatumBisX.Size = new System.Drawing.Size(100, 24);
            this.edtValutaDatumBisX.TabIndex = 16;
            //
            // lblBelegX
            //
            this.lblBelegX.Location = new System.Drawing.Point(30, 33);
            this.lblBelegX.Name = "lblBelegX";
            this.lblBelegX.Size = new System.Drawing.Size(62, 24);
            this.lblBelegX.TabIndex = 1;
            this.lblBelegX.Text = "Beleg-Nr.";
            this.lblBelegX.UseCompatibleTextRendering = true;
            //
            // edtBelegNummerVonX
            //
            this.edtBelegNummerVonX.EditValue = "";
            this.edtBelegNummerVonX.Location = new System.Drawing.Point(98, 33);
            this.edtBelegNummerVonX.Name = "edtBelegNummerVonX";
            this.edtBelegNummerVonX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBelegNummerVonX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBelegNummerVonX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBelegNummerVonX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBelegNummerVonX.Properties.Appearance.Options.UseBackColor = true;
            this.edtBelegNummerVonX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBelegNummerVonX.Properties.Appearance.Options.UseFont = true;
            this.edtBelegNummerVonX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBelegNummerVonX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBelegNummerVonX.Size = new System.Drawing.Size(100, 24);
            this.edtBelegNummerVonX.TabIndex = 2;
            //
            // lblBis1X
            //
            this.lblBis1X.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblBis1X.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblBis1X.Location = new System.Drawing.Point(198, 33);
            this.lblBis1X.Name = "lblBis1X";
            this.lblBis1X.Size = new System.Drawing.Size(25, 24);
            this.lblBis1X.TabIndex = 3;
            this.lblBis1X.Text = "-";
            this.lblBis1X.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBis1X.UseCompatibleTextRendering = true;
            //
            // edtBelegNummerBisX
            //
            this.edtBelegNummerBisX.Location = new System.Drawing.Point(223, 33);
            this.edtBelegNummerBisX.Name = "edtBelegNummerBisX";
            this.edtBelegNummerBisX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBelegNummerBisX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBelegNummerBisX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBelegNummerBisX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBelegNummerBisX.Properties.Appearance.Options.UseBackColor = true;
            this.edtBelegNummerBisX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBelegNummerBisX.Properties.Appearance.Options.UseFont = true;
            this.edtBelegNummerBisX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBelegNummerBisX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBelegNummerBisX.Size = new System.Drawing.Size(100, 24);
            this.edtBelegNummerBisX.TabIndex = 4;
            //
            // lblSollX
            //
            this.lblSollX.Location = new System.Drawing.Point(356, 121);
            this.lblSollX.Name = "lblSollX";
            this.lblSollX.Size = new System.Drawing.Size(62, 24);
            this.lblSollX.TabIndex = 29;
            this.lblSollX.Text = "Soll";
            this.lblSollX.UseCompatibleTextRendering = true;
            //
            // edtSollVonX
            //
            this.edtSollVonX.Location = new System.Drawing.Point(421, 120);
            this.edtSollVonX.Name = "edtSollVonX";
            this.edtSollVonX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSollVonX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSollVonX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSollVonX.Properties.Appearance.Options.UseBackColor = true;
            this.edtSollVonX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSollVonX.Properties.Appearance.Options.UseFont = true;
            this.edtSollVonX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSollVonX.Size = new System.Drawing.Size(106, 24);
            this.edtSollVonX.TabIndex = 30;
            //
            // lblBis6X
            //
            this.lblBis6X.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblBis6X.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblBis6X.Location = new System.Drawing.Point(527, 120);
            this.lblBis6X.Name = "lblBis6X";
            this.lblBis6X.Size = new System.Drawing.Size(25, 24);
            this.lblBis6X.TabIndex = 31;
            this.lblBis6X.Text = "-";
            this.lblBis6X.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBis6X.UseCompatibleTextRendering = true;
            //
            // edtSollBisX
            //
            this.edtSollBisX.Location = new System.Drawing.Point(554, 120);
            this.edtSollBisX.Name = "edtSollBisX";
            this.edtSollBisX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSollBisX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSollBisX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSollBisX.Properties.Appearance.Options.UseBackColor = true;
            this.edtSollBisX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSollBisX.Properties.Appearance.Options.UseFont = true;
            this.edtSollBisX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSollBisX.Size = new System.Drawing.Size(106, 24);
            this.edtSollBisX.TabIndex = 32;
            //
            // lblHabenX
            //
            this.lblHabenX.Location = new System.Drawing.Point(356, 148);
            this.lblHabenX.Name = "lblHabenX";
            this.lblHabenX.Size = new System.Drawing.Size(62, 24);
            this.lblHabenX.TabIndex = 33;
            this.lblHabenX.Text = "Haben";
            this.lblHabenX.UseCompatibleTextRendering = true;
            //
            // edtHabenVonX
            //
            this.edtHabenVonX.Location = new System.Drawing.Point(421, 149);
            this.edtHabenVonX.Name = "edtHabenVonX";
            this.edtHabenVonX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtHabenVonX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHabenVonX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHabenVonX.Properties.Appearance.Options.UseBackColor = true;
            this.edtHabenVonX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHabenVonX.Properties.Appearance.Options.UseFont = true;
            this.edtHabenVonX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHabenVonX.Size = new System.Drawing.Size(106, 24);
            this.edtHabenVonX.TabIndex = 34;
            //
            // lblBis7X
            //
            this.lblBis7X.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblBis7X.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblBis7X.Location = new System.Drawing.Point(527, 149);
            this.lblBis7X.Name = "lblBis7X";
            this.lblBis7X.Size = new System.Drawing.Size(25, 24);
            this.lblBis7X.TabIndex = 35;
            this.lblBis7X.Text = "-";
            this.lblBis7X.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBis7X.UseCompatibleTextRendering = true;
            //
            // edtHabenBisX
            //
            this.edtHabenBisX.Location = new System.Drawing.Point(554, 149);
            this.edtHabenBisX.Name = "edtHabenBisX";
            this.edtHabenBisX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtHabenBisX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHabenBisX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHabenBisX.Properties.Appearance.Options.UseBackColor = true;
            this.edtHabenBisX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHabenBisX.Properties.Appearance.Options.UseFont = true;
            this.edtHabenBisX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHabenBisX.Size = new System.Drawing.Size(106, 24);
            this.edtHabenBisX.TabIndex = 36;
            //
            // lblBetragX
            //
            this.lblBetragX.Location = new System.Drawing.Point(30, 148);
            this.lblBetragX.Name = "lblBetragX";
            this.lblBetragX.Size = new System.Drawing.Size(62, 24);
            this.lblBetragX.TabIndex = 17;
            this.lblBetragX.Text = "Betrag";
            this.lblBetragX.UseCompatibleTextRendering = true;
            //
            // edtBetragVonX
            //
            this.edtBetragVonX.Location = new System.Drawing.Point(98, 149);
            this.edtBetragVonX.Name = "edtBetragVonX";
            this.edtBetragVonX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBetragVonX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBetragVonX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetragVonX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetragVonX.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetragVonX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetragVonX.Properties.Appearance.Options.UseFont = true;
            this.edtBetragVonX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetragVonX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetragVonX.Properties.DisplayFormat.FormatString = "n2";
            this.edtBetragVonX.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetragVonX.Properties.EditFormat.FormatString = "n2";
            this.edtBetragVonX.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetragVonX.Size = new System.Drawing.Size(100, 24);
            this.edtBetragVonX.TabIndex = 18;
            //
            // lblBis5X
            //
            this.lblBis5X.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblBis5X.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblBis5X.Location = new System.Drawing.Point(198, 149);
            this.lblBis5X.Name = "lblBis5X";
            this.lblBis5X.Size = new System.Drawing.Size(25, 24);
            this.lblBis5X.TabIndex = 19;
            this.lblBis5X.Text = "-";
            this.lblBis5X.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBis5X.UseCompatibleTextRendering = true;
            //
            // edtBetragBisX
            //
            this.edtBetragBisX.Location = new System.Drawing.Point(223, 149);
            this.edtBetragBisX.Name = "edtBetragBisX";
            this.edtBetragBisX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBetragBisX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBetragBisX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetragBisX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetragBisX.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetragBisX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetragBisX.Properties.Appearance.Options.UseFont = true;
            this.edtBetragBisX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetragBisX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetragBisX.Properties.DisplayFormat.FormatString = "n2";
            this.edtBetragBisX.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetragBisX.Properties.EditFormat.FormatString = "n2";
            this.edtBetragBisX.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetragBisX.Size = new System.Drawing.Size(100, 24);
            this.edtBetragBisX.TabIndex = 20;
            //
            // lblTextX
            //
            this.lblTextX.Location = new System.Drawing.Point(356, 33);
            this.lblTextX.Name = "lblTextX";
            this.lblTextX.Size = new System.Drawing.Size(59, 24);
            this.lblTextX.TabIndex = 23;
            this.lblTextX.Text = "Text";
            this.lblTextX.UseCompatibleTextRendering = true;
            //
            // edtTextX
            //
            this.edtTextX.Location = new System.Drawing.Point(421, 33);
            this.edtTextX.Name = "edtTextX";
            this.edtTextX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTextX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTextX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTextX.Properties.Appearance.Options.UseBackColor = true;
            this.edtTextX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTextX.Properties.Appearance.Options.UseFont = true;
            this.edtTextX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTextX.Size = new System.Drawing.Size(239, 24);
            this.edtTextX.TabIndex = 24;
            //
            // lblStatusX
            //
            this.lblStatusX.Location = new System.Drawing.Point(356, 62);
            this.lblStatusX.Name = "lblStatusX";
            this.lblStatusX.Size = new System.Drawing.Size(59, 24);
            this.lblStatusX.TabIndex = 25;
            this.lblStatusX.Text = "Status";
            this.lblStatusX.UseCompatibleTextRendering = true;
            //
            // edtStatusX
            //
            this.edtStatusX.Location = new System.Drawing.Point(421, 62);
            this.edtStatusX.Name = "edtStatusX";
            this.edtStatusX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStatusX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStatusX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStatusX.Properties.Appearance.Options.UseBackColor = true;
            this.edtStatusX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStatusX.Properties.Appearance.Options.UseFont = true;
            this.edtStatusX.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtStatusX.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtStatusX.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtStatusX.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtStatusX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStatusX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtStatusX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStatusX.Size = new System.Drawing.Size(239, 24);
            this.edtStatusX.TabIndex = 26;
            //
            // lblTypX
            //
            this.lblTypX.Location = new System.Drawing.Point(356, 91);
            this.lblTypX.Name = "lblTypX";
            this.lblTypX.Size = new System.Drawing.Size(59, 24);
            this.lblTypX.TabIndex = 27;
            this.lblTypX.Text = "Typ";
            this.lblTypX.UseCompatibleTextRendering = true;
            //
            // edtTypX
            //
            this.edtTypX.Location = new System.Drawing.Point(421, 91);
            this.edtTypX.LOVName = "KbBuchungTyp";
            this.edtTypX.Name = "edtTypX";
            this.edtTypX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTypX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTypX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTypX.Properties.Appearance.Options.UseBackColor = true;
            this.edtTypX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTypX.Properties.Appearance.Options.UseFont = true;
            this.edtTypX.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtTypX.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtTypX.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtTypX.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtTypX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject18.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject18.Options.UseBackColor = true;
            this.edtTypX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject18)});
            this.edtTypX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTypX.Properties.NullText = "";
            this.edtTypX.Properties.ShowFooter = false;
            this.edtTypX.Properties.ShowHeader = false;
            this.edtTypX.Size = new System.Drawing.Size(239, 24);
            this.edtTypX.TabIndex = 28;
            //
            // lblErfasserX
            //
            this.lblErfasserX.Location = new System.Drawing.Point(30, 178);
            this.lblErfasserX.Name = "lblErfasserX";
            this.lblErfasserX.Size = new System.Drawing.Size(59, 24);
            this.lblErfasserX.TabIndex = 21;
            this.lblErfasserX.Text = "Erfasser";
            this.lblErfasserX.UseCompatibleTextRendering = true;
            //
            // edtErfasserX
            //
            this.edtErfasserX.Location = new System.Drawing.Point(98, 178);
            this.edtErfasserX.Name = "edtErfasserX";
            this.edtErfasserX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErfasserX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErfasserX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErfasserX.Properties.Appearance.Options.UseBackColor = true;
            this.edtErfasserX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErfasserX.Properties.Appearance.Options.UseFont = true;
            this.edtErfasserX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject17.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject17.Options.UseBackColor = true;
            this.edtErfasserX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject17)});
            this.edtErfasserX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErfasserX.Size = new System.Drawing.Size(225, 24);
            this.edtErfasserX.TabIndex = 22;
            this.edtErfasserX.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtErfasserX_UserModifiedFld);
            //
            // panDetails
            //
            this.panDetails.AutoScrollMargin = new System.Drawing.Size(6, 6);
            this.panDetails.Controls.Add(this.tabBuchen);
            this.panDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panDetails.Location = new System.Drawing.Point(0, 268);
            this.panDetails.Name = "panDetails";
            this.panDetails.Size = new System.Drawing.Size(744, 382);
            this.panDetails.TabIndex = 2;
            //
            // tabBuchen
            //
            this.tabBuchen.Controls.Add(this.tpgDebitor);
            this.tabBuchen.Controls.Add(this.tpgKreditor);
            this.tabBuchen.Controls.Add(this.tpgKostenarten);
            this.tabBuchen.Controls.Add(this.tpgBuchenDetails);
            this.tabBuchen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabBuchen.Location = new System.Drawing.Point(0, 0);
            this.tabBuchen.Name = "tabBuchen";
            this.tabBuchen.SelectedTabIndex = 1;
            this.tabBuchen.ShowFixedWidthTooltip = true;
            this.tabBuchen.Size = new System.Drawing.Size(744, 382);
            this.tabBuchen.TabIndex = 0;
            this.tabBuchen.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgBuchenDetails,
            this.tpgKostenarten,
            this.tpgKreditor,
            this.tpgDebitor});
            this.tabBuchen.TabsLineColor = System.Drawing.Color.Black;
            this.tabBuchen.TabsLocation = SharpLibrary.WinControls.TabsLocation.Top;
            this.tabBuchen.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabBuchen.Text = "kissTabControlEx1";
            this.tabBuchen.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabBuchen_SelectedTabChanged);
            this.tabBuchen.SelectedTabChanging += new System.ComponentModel.CancelEventHandler(this.tabBuchen_SelectedTabChanging);
            //
            // tpgDebitor
            //
            this.tpgDebitor.Controls.Add(this.edtDebitor);
            this.tpgDebitor.Controls.Add(this.lblDebitor);
            this.tpgDebitor.Location = new System.Drawing.Point(6, 32);
            this.tpgDebitor.Name = "tpgDebitor";
            this.tpgDebitor.Size = new System.Drawing.Size(732, 344);
            this.tpgDebitor.TabIndex = 3;
            this.tpgDebitor.Title = "Debitor";
            //
            // edtDebitor
            //
            this.edtDebitor.DataMember = "Schuldner_BaInstitutionID";
            this.edtDebitor.DataSource = this.qryKbBuchung;
            this.edtDebitor.Location = new System.Drawing.Point(74, 9);
            this.edtDebitor.Name = "edtDebitor";
            this.edtDebitor.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDebitor.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDebitor.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDebitor.Properties.Appearance.Options.UseBackColor = true;
            this.edtDebitor.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDebitor.Properties.Appearance.Options.UseFont = true;
            this.edtDebitor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject14.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject14.Options.UseBackColor = true;
            this.edtDebitor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject14)});
            this.edtDebitor.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDebitor.Size = new System.Drawing.Size(263, 24);
            this.edtDebitor.TabIndex = 1;
            this.edtDebitor.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtDebitor_UserModifiedFld);
            //
            // lblDebitor
            //
            this.lblDebitor.Location = new System.Drawing.Point(9, 9);
            this.lblDebitor.Name = "lblDebitor";
            this.lblDebitor.Size = new System.Drawing.Size(59, 24);
            this.lblDebitor.TabIndex = 0;
            this.lblDebitor.Text = "Debitor";
            this.lblDebitor.UseCompatibleTextRendering = true;
            //
            // tpgKreditor
            //
            this.tpgKreditor.Controls.Add(this.edtKreditorLinie);
            this.tpgKreditor.Controls.Add(this.edtKreditorBankIBAN);
            this.tpgKreditor.Controls.Add(this.lblKreditorBankIBAN);
            this.tpgKreditor.Controls.Add(this.edtKreditorBankKontoNr);
            this.tpgKreditor.Controls.Add(this.lblKreditorBankKontoNr);
            this.tpgKreditor.Controls.Add(this.edtKreditorPCKontoNrFormat);
            this.tpgKreditor.Controls.Add(this.lblKreditorBankName);
            this.tpgKreditor.Controls.Add(this.edtKreditorBankName);
            this.tpgKreditor.Controls.Add(this.lblBankName);
            this.tpgKreditor.Controls.Add(this.btnUpdateZahlinfo);
            this.tpgKreditor.Controls.Add(this.lblZahlinfo);
            this.tpgKreditor.Controls.Add(this.edtKreditorBeguenstigtOrt);
            this.tpgKreditor.Controls.Add(this.edtKreditorBeguenstigtPLZ);
            this.tpgKreditor.Controls.Add(this.lblKreditorBeguenstigtPLZOrt);
            this.tpgKreditor.Controls.Add(this.edtKreditorBeguenstigtStrasse);
            this.tpgKreditor.Controls.Add(this.lblKreditorBeguenstigtStrasseNr);
            this.tpgKreditor.Controls.Add(this.edtKreditorBeguenstigtName2);
            this.tpgKreditor.Controls.Add(this.lblKreditorBeguenstigtName2);
            this.tpgKreditor.Controls.Add(this.edtKreditorBeguenstigtName);
            this.tpgKreditor.Controls.Add(this.lblKreditorBeguenstigtName);
            this.tpgKreditor.Controls.Add(this.lblDetails);
            this.tpgKreditor.Controls.Add(this.edtKreditorEinzahlungsscheinCode);
            this.tpgKreditor.Controls.Add(this.edtKreditorReferenzNummer);
            this.tpgKreditor.Controls.Add(this.lblKreditorReferenzNummer);
            this.tpgKreditor.Controls.Add(this.edtKreditorMitteilungZeile4);
            this.tpgKreditor.Controls.Add(this.edtKreditorMitteilungZeile3);
            this.tpgKreditor.Controls.Add(this.edtKreditorMitteilungZeile2);
            this.tpgKreditor.Controls.Add(this.edtKreditorMitteilungZeile1);
            this.tpgKreditor.Controls.Add(this.lblMitteilung);
            this.tpgKreditor.Controls.Add(this.edtKreditor);
            this.tpgKreditor.Controls.Add(this.lblKreditor);
            this.tpgKreditor.Location = new System.Drawing.Point(6, 32);
            this.tpgKreditor.Name = "tpgKreditor";
            this.tpgKreditor.Size = new System.Drawing.Size(732, 344);
            this.tpgKreditor.TabIndex = 2;
            this.tpgKreditor.Title = "Kreditor";
            //
            // edtKreditorLinie
            //
            this.edtKreditorLinie.DataMember = "KreditorLinie";
            this.edtKreditorLinie.DataSource = this.qryKbBuchung;
            this.edtKreditorLinie.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKreditorLinie.Location = new System.Drawing.Point(87, -27);
            this.edtKreditorLinie.Name = "edtKreditorLinie";
            this.edtKreditorLinie.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKreditorLinie.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKreditorLinie.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKreditorLinie.Properties.Appearance.Options.UseBackColor = true;
            this.edtKreditorLinie.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKreditorLinie.Properties.Appearance.Options.UseFont = true;
            this.edtKreditorLinie.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKreditorLinie.Properties.Name = "editText.Properties";
            this.edtKreditorLinie.Properties.ReadOnly = true;
            this.edtKreditorLinie.Size = new System.Drawing.Size(270, 24);
            this.edtKreditorLinie.TabIndex = 290;
            //
            // edtKreditorBankIBAN
            //
            this.edtKreditorBankIBAN.DataMember = "IBAN";
            this.edtKreditorBankIBAN.DataSource = this.qryKbBuchung;
            this.edtKreditorBankIBAN.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKreditorBankIBAN.Location = new System.Drawing.Point(449, 310);
            this.edtKreditorBankIBAN.Name = "edtKreditorBankIBAN";
            this.edtKreditorBankIBAN.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKreditorBankIBAN.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKreditorBankIBAN.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKreditorBankIBAN.Properties.Appearance.Options.UseBackColor = true;
            this.edtKreditorBankIBAN.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKreditorBankIBAN.Properties.Appearance.Options.UseFont = true;
            this.edtKreditorBankIBAN.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKreditorBankIBAN.Properties.MaxLength = 35;
            this.edtKreditorBankIBAN.Properties.ReadOnly = true;
            this.edtKreditorBankIBAN.Size = new System.Drawing.Size(263, 24);
            this.edtKreditorBankIBAN.TabIndex = 29;
            //
            // lblKreditorBankIBAN
            //
            this.lblKreditorBankIBAN.Location = new System.Drawing.Point(380, 310);
            this.lblKreditorBankIBAN.Name = "lblKreditorBankIBAN";
            this.lblKreditorBankIBAN.Size = new System.Drawing.Size(34, 24);
            this.lblKreditorBankIBAN.TabIndex = 28;
            this.lblKreditorBankIBAN.Text = "IBAN";
            this.lblKreditorBankIBAN.UseCompatibleTextRendering = true;
            //
            // edtKreditorBankKontoNr
            //
            this.edtKreditorBankKontoNr.DataMember = "BankKontoNr";
            this.edtKreditorBankKontoNr.DataSource = this.qryKbBuchung;
            this.edtKreditorBankKontoNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKreditorBankKontoNr.Location = new System.Drawing.Point(449, 280);
            this.edtKreditorBankKontoNr.Name = "edtKreditorBankKontoNr";
            this.edtKreditorBankKontoNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKreditorBankKontoNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKreditorBankKontoNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKreditorBankKontoNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtKreditorBankKontoNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKreditorBankKontoNr.Properties.Appearance.Options.UseFont = true;
            this.edtKreditorBankKontoNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKreditorBankKontoNr.Properties.MaxLength = 35;
            this.edtKreditorBankKontoNr.Properties.ReadOnly = true;
            this.edtKreditorBankKontoNr.Size = new System.Drawing.Size(263, 24);
            this.edtKreditorBankKontoNr.TabIndex = 27;
            //
            // lblKreditorBankKontoNr
            //
            this.lblKreditorBankKontoNr.Location = new System.Drawing.Point(380, 280);
            this.lblKreditorBankKontoNr.Name = "lblKreditorBankKontoNr";
            this.lblKreditorBankKontoNr.Size = new System.Drawing.Size(63, 24);
            this.lblKreditorBankKontoNr.TabIndex = 26;
            this.lblKreditorBankKontoNr.Text = "Bank-Konto";
            this.lblKreditorBankKontoNr.UseCompatibleTextRendering = true;
            //
            // edtKreditorPCKontoNrFormat
            //
            this.edtKreditorPCKontoNrFormat.DataMember = "PCKontoNrFormat";
            this.edtKreditorPCKontoNrFormat.DataSource = this.qryKbBuchung;
            this.edtKreditorPCKontoNrFormat.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKreditorPCKontoNrFormat.Location = new System.Drawing.Point(449, 250);
            this.edtKreditorPCKontoNrFormat.Name = "edtKreditorPCKontoNrFormat";
            this.edtKreditorPCKontoNrFormat.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKreditorPCKontoNrFormat.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKreditorPCKontoNrFormat.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKreditorPCKontoNrFormat.Properties.Appearance.Options.UseBackColor = true;
            this.edtKreditorPCKontoNrFormat.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKreditorPCKontoNrFormat.Properties.Appearance.Options.UseFont = true;
            this.edtKreditorPCKontoNrFormat.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKreditorPCKontoNrFormat.Properties.MaxLength = 35;
            this.edtKreditorPCKontoNrFormat.Properties.ReadOnly = true;
            this.edtKreditorPCKontoNrFormat.Size = new System.Drawing.Size(263, 24);
            this.edtKreditorPCKontoNrFormat.TabIndex = 25;
            //
            // lblKreditorBankName
            //
            this.lblKreditorBankName.Location = new System.Drawing.Point(380, 250);
            this.lblKreditorBankName.Name = "lblKreditorBankName";
            this.lblKreditorBankName.Size = new System.Drawing.Size(63, 24);
            this.lblKreditorBankName.TabIndex = 24;
            this.lblKreditorBankName.Text = "PC-Konto";
            this.lblKreditorBankName.UseCompatibleTextRendering = true;
            //
            // edtKreditorBankName
            //
            this.edtKreditorBankName.DataMember = "BankName";
            this.edtKreditorBankName.DataSource = this.qryKbBuchung;
            this.edtKreditorBankName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKreditorBankName.Location = new System.Drawing.Point(449, 220);
            this.edtKreditorBankName.Name = "edtKreditorBankName";
            this.edtKreditorBankName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKreditorBankName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKreditorBankName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKreditorBankName.Properties.Appearance.Options.UseBackColor = true;
            this.edtKreditorBankName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKreditorBankName.Properties.Appearance.Options.UseFont = true;
            this.edtKreditorBankName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKreditorBankName.Properties.MaxLength = 35;
            this.edtKreditorBankName.Properties.ReadOnly = true;
            this.edtKreditorBankName.Size = new System.Drawing.Size(263, 24);
            this.edtKreditorBankName.TabIndex = 23;
            //
            // lblBankName
            //
            this.lblBankName.Location = new System.Drawing.Point(380, 220);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Size = new System.Drawing.Size(34, 24);
            this.lblBankName.TabIndex = 22;
            this.lblBankName.Text = "Name";
            this.lblBankName.UseCompatibleTextRendering = true;
            //
            // btnUpdateZahlinfo
            //
            this.btnUpdateZahlinfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateZahlinfo.Location = new System.Drawing.Point(450, 190);
            this.btnUpdateZahlinfo.Name = "btnUpdateZahlinfo";
            this.btnUpdateZahlinfo.Size = new System.Drawing.Size(136, 24);
            this.btnUpdateZahlinfo.TabIndex = 21;
            this.btnUpdateZahlinfo.Text = "&Zahlinfo aktualisieren";
            this.btnUpdateZahlinfo.UseCompatibleTextRendering = true;
            this.btnUpdateZahlinfo.UseVisualStyleBackColor = false;
            this.btnUpdateZahlinfo.Click += new System.EventHandler(this.btnUpdateZahlinfo_Click);
            //
            // lblZahlinfo
            //
            this.lblZahlinfo.Location = new System.Drawing.Point(380, 190);
            this.lblZahlinfo.Name = "lblZahlinfo";
            this.lblZahlinfo.Size = new System.Drawing.Size(63, 24);
            this.lblZahlinfo.TabIndex = 20;
            this.lblZahlinfo.Text = "ZahlInfo";
            this.lblZahlinfo.UseCompatibleTextRendering = true;
            //
            // edtKreditorBeguenstigtOrt
            //
            this.edtKreditorBeguenstigtOrt.DataMember = "BeguenstigtOrt";
            this.edtKreditorBeguenstigtOrt.DataSource = this.qryKbBuchung;
            this.edtKreditorBeguenstigtOrt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKreditorBeguenstigtOrt.Location = new System.Drawing.Point(520, 130);
            this.edtKreditorBeguenstigtOrt.Name = "edtKreditorBeguenstigtOrt";
            this.edtKreditorBeguenstigtOrt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKreditorBeguenstigtOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKreditorBeguenstigtOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKreditorBeguenstigtOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtKreditorBeguenstigtOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKreditorBeguenstigtOrt.Properties.Appearance.Options.UseFont = true;
            this.edtKreditorBeguenstigtOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKreditorBeguenstigtOrt.Properties.MaxLength = 35;
            this.edtKreditorBeguenstigtOrt.Properties.ReadOnly = true;
            this.edtKreditorBeguenstigtOrt.Size = new System.Drawing.Size(193, 24);
            this.edtKreditorBeguenstigtOrt.TabIndex = 19;
            //
            // edtKreditorBeguenstigtPLZ
            //
            this.edtKreditorBeguenstigtPLZ.DataMember = "BeguenstigtPLZ";
            this.edtKreditorBeguenstigtPLZ.DataSource = this.qryKbBuchung;
            this.edtKreditorBeguenstigtPLZ.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKreditorBeguenstigtPLZ.Location = new System.Drawing.Point(450, 130);
            this.edtKreditorBeguenstigtPLZ.Name = "edtKreditorBeguenstigtPLZ";
            this.edtKreditorBeguenstigtPLZ.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKreditorBeguenstigtPLZ.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKreditorBeguenstigtPLZ.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKreditorBeguenstigtPLZ.Properties.Appearance.Options.UseBackColor = true;
            this.edtKreditorBeguenstigtPLZ.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKreditorBeguenstigtPLZ.Properties.Appearance.Options.UseFont = true;
            this.edtKreditorBeguenstigtPLZ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKreditorBeguenstigtPLZ.Properties.MaxLength = 35;
            this.edtKreditorBeguenstigtPLZ.Properties.ReadOnly = true;
            this.edtKreditorBeguenstigtPLZ.Size = new System.Drawing.Size(70, 24);
            this.edtKreditorBeguenstigtPLZ.TabIndex = 18;
            //
            // lblKreditorBeguenstigtPLZOrt
            //
            this.lblKreditorBeguenstigtPLZOrt.Location = new System.Drawing.Point(380, 130);
            this.lblKreditorBeguenstigtPLZOrt.Name = "lblKreditorBeguenstigtPLZOrt";
            this.lblKreditorBeguenstigtPLZOrt.Size = new System.Drawing.Size(63, 24);
            this.lblKreditorBeguenstigtPLZOrt.TabIndex = 17;
            this.lblKreditorBeguenstigtPLZOrt.Text = "PLZ / Ort";
            this.lblKreditorBeguenstigtPLZOrt.UseCompatibleTextRendering = true;
            //
            // edtKreditorBeguenstigtStrasse
            //
            this.edtKreditorBeguenstigtStrasse.DataMember = "BeguenstigtStrasse";
            this.edtKreditorBeguenstigtStrasse.DataSource = this.qryKbBuchung;
            this.edtKreditorBeguenstigtStrasse.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKreditorBeguenstigtStrasse.Location = new System.Drawing.Point(450, 100);
            this.edtKreditorBeguenstigtStrasse.Name = "edtKreditorBeguenstigtStrasse";
            this.edtKreditorBeguenstigtStrasse.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKreditorBeguenstigtStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKreditorBeguenstigtStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKreditorBeguenstigtStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtKreditorBeguenstigtStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKreditorBeguenstigtStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtKreditorBeguenstigtStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKreditorBeguenstigtStrasse.Properties.MaxLength = 35;
            this.edtKreditorBeguenstigtStrasse.Properties.ReadOnly = true;
            this.edtKreditorBeguenstigtStrasse.Size = new System.Drawing.Size(263, 24);
            this.edtKreditorBeguenstigtStrasse.TabIndex = 16;
            //
            // lblKreditorBeguenstigtStrasseNr
            //
            this.lblKreditorBeguenstigtStrasseNr.Location = new System.Drawing.Point(380, 100);
            this.lblKreditorBeguenstigtStrasseNr.Name = "lblKreditorBeguenstigtStrasseNr";
            this.lblKreditorBeguenstigtStrasseNr.Size = new System.Drawing.Size(63, 24);
            this.lblKreditorBeguenstigtStrasseNr.TabIndex = 15;
            this.lblKreditorBeguenstigtStrasseNr.Text = "Strasse / Nr";
            this.lblKreditorBeguenstigtStrasseNr.UseCompatibleTextRendering = true;
            //
            // edtKreditorBeguenstigtName2
            //
            this.edtKreditorBeguenstigtName2.DataMember = "BeguenstigtName2";
            this.edtKreditorBeguenstigtName2.DataSource = this.qryKbBuchung;
            this.edtKreditorBeguenstigtName2.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKreditorBeguenstigtName2.Location = new System.Drawing.Point(450, 70);
            this.edtKreditorBeguenstigtName2.Name = "edtKreditorBeguenstigtName2";
            this.edtKreditorBeguenstigtName2.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKreditorBeguenstigtName2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKreditorBeguenstigtName2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKreditorBeguenstigtName2.Properties.Appearance.Options.UseBackColor = true;
            this.edtKreditorBeguenstigtName2.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKreditorBeguenstigtName2.Properties.Appearance.Options.UseFont = true;
            this.edtKreditorBeguenstigtName2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKreditorBeguenstigtName2.Properties.MaxLength = 35;
            this.edtKreditorBeguenstigtName2.Properties.ReadOnly = true;
            this.edtKreditorBeguenstigtName2.Size = new System.Drawing.Size(263, 24);
            this.edtKreditorBeguenstigtName2.TabIndex = 14;
            //
            // lblKreditorBeguenstigtName2
            //
            this.lblKreditorBeguenstigtName2.Location = new System.Drawing.Point(380, 70);
            this.lblKreditorBeguenstigtName2.Name = "lblKreditorBeguenstigtName2";
            this.lblKreditorBeguenstigtName2.Size = new System.Drawing.Size(63, 24);
            this.lblKreditorBeguenstigtName2.TabIndex = 13;
            this.lblKreditorBeguenstigtName2.Text = "Zusatz";
            this.lblKreditorBeguenstigtName2.UseCompatibleTextRendering = true;
            //
            // edtKreditorBeguenstigtName
            //
            this.edtKreditorBeguenstigtName.DataMember = "BeguenstigtName";
            this.edtKreditorBeguenstigtName.DataSource = this.qryKbBuchung;
            this.edtKreditorBeguenstigtName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKreditorBeguenstigtName.Location = new System.Drawing.Point(450, 40);
            this.edtKreditorBeguenstigtName.Name = "edtKreditorBeguenstigtName";
            this.edtKreditorBeguenstigtName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKreditorBeguenstigtName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKreditorBeguenstigtName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKreditorBeguenstigtName.Properties.Appearance.Options.UseBackColor = true;
            this.edtKreditorBeguenstigtName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKreditorBeguenstigtName.Properties.Appearance.Options.UseFont = true;
            this.edtKreditorBeguenstigtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKreditorBeguenstigtName.Properties.MaxLength = 35;
            this.edtKreditorBeguenstigtName.Properties.ReadOnly = true;
            this.edtKreditorBeguenstigtName.Size = new System.Drawing.Size(263, 24);
            this.edtKreditorBeguenstigtName.TabIndex = 12;
            //
            // lblKreditorBeguenstigtName
            //
            this.lblKreditorBeguenstigtName.Location = new System.Drawing.Point(380, 40);
            this.lblKreditorBeguenstigtName.Name = "lblKreditorBeguenstigtName";
            this.lblKreditorBeguenstigtName.Size = new System.Drawing.Size(63, 24);
            this.lblKreditorBeguenstigtName.TabIndex = 11;
            this.lblKreditorBeguenstigtName.Text = "Name";
            this.lblKreditorBeguenstigtName.UseCompatibleTextRendering = true;
            //
            // lblDetails
            //
            this.lblDetails.Location = new System.Drawing.Point(380, 10);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(63, 24);
            this.lblDetails.TabIndex = 10;
            this.lblDetails.Text = "Details";
            this.lblDetails.UseCompatibleTextRendering = true;
            //
            // edtKreditorEinzahlungsscheinCode
            //
            this.edtKreditorEinzahlungsscheinCode.DataMember = "EinzahlungsscheinCode";
            this.edtKreditorEinzahlungsscheinCode.DataSource = this.qryKbBuchung;
            this.edtKreditorEinzahlungsscheinCode.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKreditorEinzahlungsscheinCode.Location = new System.Drawing.Point(75, 310);
            this.edtKreditorEinzahlungsscheinCode.LOVName = "BgEinzahlungsschein";
            this.edtKreditorEinzahlungsscheinCode.Name = "edtKreditorEinzahlungsscheinCode";
            this.edtKreditorEinzahlungsscheinCode.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKreditorEinzahlungsscheinCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKreditorEinzahlungsscheinCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKreditorEinzahlungsscheinCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtKreditorEinzahlungsscheinCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKreditorEinzahlungsscheinCode.Properties.Appearance.Options.UseFont = true;
            this.edtKreditorEinzahlungsscheinCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKreditorEinzahlungsscheinCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKreditorEinzahlungsscheinCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKreditorEinzahlungsscheinCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKreditorEinzahlungsscheinCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtKreditorEinzahlungsscheinCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtKreditorEinzahlungsscheinCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKreditorEinzahlungsscheinCode.Properties.NullText = "";
            this.edtKreditorEinzahlungsscheinCode.Properties.ReadOnly = true;
            this.edtKreditorEinzahlungsscheinCode.Properties.ShowFooter = false;
            this.edtKreditorEinzahlungsscheinCode.Properties.ShowHeader = false;
            this.edtKreditorEinzahlungsscheinCode.Size = new System.Drawing.Size(263, 24);
            this.edtKreditorEinzahlungsscheinCode.TabIndex = 9;
            //
            // edtKreditorReferenzNummer
            //
            this.edtKreditorReferenzNummer.DataMember = "ReferenzNummer";
            this.edtKreditorReferenzNummer.DataSource = this.qryKbBuchung;
            this.edtKreditorReferenzNummer.Location = new System.Drawing.Point(75, 190);
            this.edtKreditorReferenzNummer.Name = "edtKreditorReferenzNummer";
            this.edtKreditorReferenzNummer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKreditorReferenzNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKreditorReferenzNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKreditorReferenzNummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtKreditorReferenzNummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKreditorReferenzNummer.Properties.Appearance.Options.UseFont = true;
            this.edtKreditorReferenzNummer.Properties.Appearance.Options.UseTextOptions = true;
            this.edtKreditorReferenzNummer.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtKreditorReferenzNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKreditorReferenzNummer.Size = new System.Drawing.Size(263, 24);
            this.edtKreditorReferenzNummer.TabIndex = 8;
            //
            // lblKreditorReferenzNummer
            //
            this.lblKreditorReferenzNummer.Location = new System.Drawing.Point(10, 190);
            this.lblKreditorReferenzNummer.Name = "lblKreditorReferenzNummer";
            this.lblKreditorReferenzNummer.Size = new System.Drawing.Size(59, 24);
            this.lblKreditorReferenzNummer.TabIndex = 7;
            this.lblKreditorReferenzNummer.Text = "Referenz";
            this.lblKreditorReferenzNummer.UseCompatibleTextRendering = true;
            //
            // edtKreditorMitteilungZeile4
            //
            this.edtKreditorMitteilungZeile4.DataMember = "MitteilungZeile4";
            this.edtKreditorMitteilungZeile4.DataSource = this.qryKbBuchung;
            this.edtKreditorMitteilungZeile4.Location = new System.Drawing.Point(75, 160);
            this.edtKreditorMitteilungZeile4.Name = "edtKreditorMitteilungZeile4";
            this.edtKreditorMitteilungZeile4.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKreditorMitteilungZeile4.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKreditorMitteilungZeile4.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKreditorMitteilungZeile4.Properties.Appearance.Options.UseBackColor = true;
            this.edtKreditorMitteilungZeile4.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKreditorMitteilungZeile4.Properties.Appearance.Options.UseFont = true;
            this.edtKreditorMitteilungZeile4.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKreditorMitteilungZeile4.Properties.MaxLength = 35;
            this.edtKreditorMitteilungZeile4.Size = new System.Drawing.Size(263, 24);
            this.edtKreditorMitteilungZeile4.TabIndex = 6;
            //
            // edtKreditorMitteilungZeile3
            //
            this.edtKreditorMitteilungZeile3.DataMember = "MitteilungZeile3";
            this.edtKreditorMitteilungZeile3.DataSource = this.qryKbBuchung;
            this.edtKreditorMitteilungZeile3.Location = new System.Drawing.Point(75, 130);
            this.edtKreditorMitteilungZeile3.Name = "edtKreditorMitteilungZeile3";
            this.edtKreditorMitteilungZeile3.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKreditorMitteilungZeile3.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKreditorMitteilungZeile3.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKreditorMitteilungZeile3.Properties.Appearance.Options.UseBackColor = true;
            this.edtKreditorMitteilungZeile3.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKreditorMitteilungZeile3.Properties.Appearance.Options.UseFont = true;
            this.edtKreditorMitteilungZeile3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKreditorMitteilungZeile3.Properties.MaxLength = 35;
            this.edtKreditorMitteilungZeile3.Size = new System.Drawing.Size(263, 24);
            this.edtKreditorMitteilungZeile3.TabIndex = 5;
            //
            // edtKreditorMitteilungZeile2
            //
            this.edtKreditorMitteilungZeile2.DataMember = "MitteilungZeile2";
            this.edtKreditorMitteilungZeile2.DataSource = this.qryKbBuchung;
            this.edtKreditorMitteilungZeile2.Location = new System.Drawing.Point(75, 100);
            this.edtKreditorMitteilungZeile2.Name = "edtKreditorMitteilungZeile2";
            this.edtKreditorMitteilungZeile2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKreditorMitteilungZeile2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKreditorMitteilungZeile2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKreditorMitteilungZeile2.Properties.Appearance.Options.UseBackColor = true;
            this.edtKreditorMitteilungZeile2.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKreditorMitteilungZeile2.Properties.Appearance.Options.UseFont = true;
            this.edtKreditorMitteilungZeile2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKreditorMitteilungZeile2.Properties.MaxLength = 35;
            this.edtKreditorMitteilungZeile2.Size = new System.Drawing.Size(263, 24);
            this.edtKreditorMitteilungZeile2.TabIndex = 4;
            //
            // edtKreditorMitteilungZeile1
            //
            this.edtKreditorMitteilungZeile1.DataMember = "MitteilungZeile1";
            this.edtKreditorMitteilungZeile1.DataSource = this.qryKbBuchung;
            this.edtKreditorMitteilungZeile1.Location = new System.Drawing.Point(75, 70);
            this.edtKreditorMitteilungZeile1.Name = "edtKreditorMitteilungZeile1";
            this.edtKreditorMitteilungZeile1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKreditorMitteilungZeile1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKreditorMitteilungZeile1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKreditorMitteilungZeile1.Properties.Appearance.Options.UseBackColor = true;
            this.edtKreditorMitteilungZeile1.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKreditorMitteilungZeile1.Properties.Appearance.Options.UseFont = true;
            this.edtKreditorMitteilungZeile1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKreditorMitteilungZeile1.Properties.MaxLength = 35;
            this.edtKreditorMitteilungZeile1.Size = new System.Drawing.Size(263, 24);
            this.edtKreditorMitteilungZeile1.TabIndex = 3;
            //
            // lblMitteilung
            //
            this.lblMitteilung.Location = new System.Drawing.Point(10, 70);
            this.lblMitteilung.Name = "lblMitteilung";
            this.lblMitteilung.Size = new System.Drawing.Size(59, 24);
            this.lblMitteilung.TabIndex = 2;
            this.lblMitteilung.Text = "Mitteilung";
            this.lblMitteilung.UseCompatibleTextRendering = true;
            //
            // edtKreditor
            //
            this.edtKreditor.DataMember = "BeguenstigtName";
            this.edtKreditor.DataSource = this.qryKbBuchung;
            this.edtKreditor.Location = new System.Drawing.Point(75, 40);
            this.edtKreditor.Name = "edtKreditor";
            this.edtKreditor.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKreditor.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKreditor.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKreditor.Properties.Appearance.Options.UseBackColor = true;
            this.edtKreditor.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKreditor.Properties.Appearance.Options.UseFont = true;
            this.edtKreditor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtKreditor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtKreditor.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKreditor.SearchStringMinLength = 3;
            this.edtKreditor.Size = new System.Drawing.Size(263, 24);
            this.edtKreditor.TabIndex = 1;
            this.edtKreditor.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKreditor_UserModifiedFld);
            //
            // lblKreditor
            //
            this.lblKreditor.Location = new System.Drawing.Point(10, 40);
            this.lblKreditor.Name = "lblKreditor";
            this.lblKreditor.Size = new System.Drawing.Size(59, 24);
            this.lblKreditor.TabIndex = 0;
            this.lblKreditor.Text = "Kreditor";
            this.lblKreditor.UseCompatibleTextRendering = true;
            //
            // tpgKostenarten
            //
            this.tpgKostenarten.Controls.Add(this.edtDifferenz);
            this.tpgKostenarten.Controls.Add(this.lblKostenartDifferenz);
            this.tpgKostenarten.Controls.Add(this.edtTotal);
            this.tpgKostenarten.Controls.Add(this.lblKostenartTotal);
            this.tpgKostenarten.Controls.Add(this.edtKostenartBuchungsBetrag);
            this.tpgKostenarten.Controls.Add(this.lblKostenartBuchungsbetrag);
            this.tpgKostenarten.Controls.Add(this.lblKostenartZusammenfassungtotal);
            this.tpgKostenarten.Controls.Add(this.lblKostenartZusammenfassung);
            this.tpgKostenarten.Controls.Add(this.edtKostenartVerwPeriodeBis);
            this.tpgKostenarten.Controls.Add(this.lblKostenartVerwPeriodeBis);
            this.tpgKostenarten.Controls.Add(this.edtKostenartVerwPeriodeVon);
            this.tpgKostenarten.Controls.Add(this.lblKostenartVerwPeriodeVon);
            this.tpgKostenarten.Controls.Add(this.edtKostenartBuchungstext);
            this.tpgKostenarten.Controls.Add(this.lblKostenartBuchungstext);
            this.tpgKostenarten.Controls.Add(this.edtKostenart);
            this.tpgKostenarten.Controls.Add(this.lblKostenartKonto);
            this.tpgKostenarten.Controls.Add(this.edtKostenartBetrag);
            this.tpgKostenarten.Controls.Add(this.lblKostenartBetrag);
            this.tpgKostenarten.Controls.Add(this.edtKostenartKostenstelle);
            this.tpgKostenarten.Controls.Add(this.lblKostenartKostenstelle);
            this.tpgKostenarten.Controls.Add(this.grdKostenart);
            this.tpgKostenarten.Location = new System.Drawing.Point(6, 32);
            this.tpgKostenarten.Name = "tpgKostenarten";
            this.tpgKostenarten.Size = new System.Drawing.Size(732, 344);
            this.tpgKostenarten.TabIndex = 1;
            this.tpgKostenarten.Title = "Kostenarten";
            //
            // edtDifferenz
            //
            this.edtDifferenz.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtDifferenz.EditValue = 0;
            this.edtDifferenz.Location = new System.Drawing.Point(577, 310);
            this.edtDifferenz.Name = "edtDifferenz";
            this.edtDifferenz.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDifferenz.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtDifferenz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDifferenz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDifferenz.Properties.Appearance.Options.UseBackColor = true;
            this.edtDifferenz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDifferenz.Properties.Appearance.Options.UseFont = true;
            this.edtDifferenz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDifferenz.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDifferenz.Properties.DisplayFormat.FormatString = "N2";
            this.edtDifferenz.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtDifferenz.Properties.EditFormat.FormatString = "N2";
            this.edtDifferenz.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtDifferenz.Properties.Mask.EditMask = "N2";
            this.edtDifferenz.Properties.Name = "editBetrag.Properties";
            this.edtDifferenz.Properties.Precision = 2;
            this.edtDifferenz.Properties.ReadOnly = true;
            this.edtDifferenz.Size = new System.Drawing.Size(127, 24);
            this.edtDifferenz.TabIndex = 20;
            //
            // lblKostenartDifferenz
            //
            this.lblKostenartDifferenz.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblKostenartDifferenz.Location = new System.Drawing.Point(456, 310);
            this.lblKostenartDifferenz.Name = "lblKostenartDifferenz";
            this.lblKostenartDifferenz.Size = new System.Drawing.Size(77, 16);
            this.lblKostenartDifferenz.TabIndex = 19;
            this.lblKostenartDifferenz.Text = "Differenz";
            this.lblKostenartDifferenz.UseCompatibleTextRendering = true;
            //
            // edtTotal
            //
            this.edtTotal.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtTotal.EditValue = 0;
            this.edtTotal.Location = new System.Drawing.Point(577, 280);
            this.edtTotal.Name = "edtTotal";
            this.edtTotal.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtTotal.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtTotal.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTotal.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTotal.Properties.Appearance.Options.UseBackColor = true;
            this.edtTotal.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTotal.Properties.Appearance.Options.UseFont = true;
            this.edtTotal.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTotal.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTotal.Properties.DisplayFormat.FormatString = "N2";
            this.edtTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtTotal.Properties.EditFormat.FormatString = "N2";
            this.edtTotal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtTotal.Properties.Mask.EditMask = "N2";
            this.edtTotal.Properties.Name = "editBetrag.Properties";
            this.edtTotal.Properties.Precision = 2;
            this.edtTotal.Properties.ReadOnly = true;
            this.edtTotal.Size = new System.Drawing.Size(127, 24);
            this.edtTotal.TabIndex = 18;
            //
            // lblKostenartTotal
            //
            this.lblKostenartTotal.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblKostenartTotal.Location = new System.Drawing.Point(456, 280);
            this.lblKostenartTotal.Name = "lblKostenartTotal";
            this.lblKostenartTotal.Size = new System.Drawing.Size(77, 16);
            this.lblKostenartTotal.TabIndex = 17;
            this.lblKostenartTotal.Text = "Total";
            this.lblKostenartTotal.UseCompatibleTextRendering = true;
            //
            // edtKostenartBuchungsBetrag
            //
            this.edtKostenartBuchungsBetrag.DataMember = "Betrag";
            this.edtKostenartBuchungsBetrag.DataSource = this.qryKbBuchung;
            this.edtKostenartBuchungsBetrag.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKostenartBuchungsBetrag.Location = new System.Drawing.Point(577, 250);
            this.edtKostenartBuchungsBetrag.Name = "edtKostenartBuchungsBetrag";
            this.edtKostenartBuchungsBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKostenartBuchungsBetrag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKostenartBuchungsBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKostenartBuchungsBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostenartBuchungsBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtKostenartBuchungsBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKostenartBuchungsBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtKostenartBuchungsBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKostenartBuchungsBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKostenartBuchungsBetrag.Properties.DisplayFormat.FormatString = "N2";
            this.edtKostenartBuchungsBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtKostenartBuchungsBetrag.Properties.EditFormat.FormatString = "N2";
            this.edtKostenartBuchungsBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtKostenartBuchungsBetrag.Properties.Mask.EditMask = "N2";
            this.edtKostenartBuchungsBetrag.Properties.Name = "editBetrag.Properties";
            this.edtKostenartBuchungsBetrag.Properties.Precision = 2;
            this.edtKostenartBuchungsBetrag.Properties.ReadOnly = true;
            this.edtKostenartBuchungsBetrag.Size = new System.Drawing.Size(127, 24);
            this.edtKostenartBuchungsBetrag.TabIndex = 16;
            //
            // lblKostenartBuchungsbetrag
            //
            this.lblKostenartBuchungsbetrag.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblKostenartBuchungsbetrag.Location = new System.Drawing.Point(456, 250);
            this.lblKostenartBuchungsbetrag.Name = "lblKostenartBuchungsbetrag";
            this.lblKostenartBuchungsbetrag.Size = new System.Drawing.Size(119, 18);
            this.lblKostenartBuchungsbetrag.TabIndex = 15;
            this.lblKostenartBuchungsbetrag.Text = "Buchungsbetrag";
            this.lblKostenartBuchungsbetrag.UseCompatibleTextRendering = true;
            //
            // lblKostenartZusammenfassungtotal
            //
            this.lblKostenartZusammenfassungtotal.DataMember = "Total";
            this.lblKostenartZusammenfassungtotal.DataSource = this.qryTotal;
            this.lblKostenartZusammenfassungtotal.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblKostenartZusammenfassungtotal.Location = new System.Drawing.Point(631, 220);
            this.lblKostenartZusammenfassungtotal.Name = "lblKostenartZusammenfassungtotal";
            this.lblKostenartZusammenfassungtotal.Size = new System.Drawing.Size(73, 18);
            this.lblKostenartZusammenfassungtotal.TabIndex = 14;
            this.lblKostenartZusammenfassungtotal.UseCompatibleTextRendering = true;
            this.lblKostenartZusammenfassungtotal.Visible = false;
            //
            // qryTotal
            //
            this.qryTotal.HostControl = this;
            this.qryTotal.SelectStatement = "SELECT Anzahl = COUNT(1),\r\n       Total = ISNULL(SUM(Betrag), 0)\r\nFROM dbo.KbBuch" +
                "ungKostenart WITH (READUNCOMMITTED)\r\nWHERE KbBuchungID = {0}";
            //
            // lblKostenartZusammenfassung
            //
            this.lblKostenartZusammenfassung.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblKostenartZusammenfassung.Location = new System.Drawing.Point(456, 219);
            this.lblKostenartZusammenfassung.Name = "lblKostenartZusammenfassung";
            this.lblKostenartZusammenfassung.Size = new System.Drawing.Size(149, 18);
            this.lblKostenartZusammenfassung.TabIndex = 13;
            this.lblKostenartZusammenfassung.Text = "Zusammenfassung";
            this.lblKostenartZusammenfassung.UseCompatibleTextRendering = true;
            //
            // edtKostenartVerwPeriodeBis
            //
            this.edtKostenartVerwPeriodeBis.DataMember = "VerwPeriodeBis";
            this.edtKostenartVerwPeriodeBis.DataSource = this.qryKostenart;
            this.edtKostenartVerwPeriodeBis.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKostenartVerwPeriodeBis.EditValue = null;
            this.edtKostenartVerwPeriodeBis.Location = new System.Drawing.Point(284, 320);
            this.edtKostenartVerwPeriodeBis.Name = "edtKostenartVerwPeriodeBis";
            this.edtKostenartVerwPeriodeBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKostenartVerwPeriodeBis.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKostenartVerwPeriodeBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKostenartVerwPeriodeBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostenartVerwPeriodeBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtKostenartVerwPeriodeBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKostenartVerwPeriodeBis.Properties.Appearance.Options.UseFont = true;
            this.edtKostenartVerwPeriodeBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtKostenartVerwPeriodeBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtKostenartVerwPeriodeBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtKostenartVerwPeriodeBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKostenartVerwPeriodeBis.Properties.ReadOnly = true;
            this.edtKostenartVerwPeriodeBis.Properties.ShowToday = false;
            this.edtKostenartVerwPeriodeBis.Size = new System.Drawing.Size(100, 24);
            this.edtKostenartVerwPeriodeBis.TabIndex = 12;
            //
            // qryKostenart
            //
            this.qryKostenart.CanDelete = true;
            this.qryKostenart.CanInsert = true;
            this.qryKostenart.CanUpdate = true;
            this.qryKostenart.HostControl = this;
            this.qryKostenart.SelectStatement = resources.GetString("qryKostenart.SelectStatement");
            this.qryKostenart.TableName = "KbBuchungKostenart";
            this.qryKostenart.BeforeInsert += new System.EventHandler(this.qryKostenart_BeforeInsert);
            this.qryKostenart.AfterInsert += new System.EventHandler(this.qryKostenart_AfterInsert);
            this.qryKostenart.BeforePost += new System.EventHandler(this.qryKostenart_BeforePost);
            this.qryKostenart.AfterPost += new System.EventHandler(this.qryKostenart_AfterPost);
            this.qryKostenart.BeforeDelete += new System.EventHandler(this.qryKostenart_BeforeDelete);
            this.qryKostenart.AfterDelete += new System.EventHandler(this.qryKostenart_AfterDelete);
            this.qryKostenart.PositionChanged += new System.EventHandler(this.qryKostenart_PositionChanged);
            //
            // lblKostenartVerwPeriodeBis
            //
            this.lblKostenartVerwPeriodeBis.Location = new System.Drawing.Point(239, 320);
            this.lblKostenartVerwPeriodeBis.Name = "lblKostenartVerwPeriodeBis";
            this.lblKostenartVerwPeriodeBis.Size = new System.Drawing.Size(39, 24);
            this.lblKostenartVerwPeriodeBis.TabIndex = 11;
            this.lblKostenartVerwPeriodeBis.Text = "bis";
            this.lblKostenartVerwPeriodeBis.UseCompatibleTextRendering = true;
            //
            // edtKostenartVerwPeriodeVon
            //
            this.edtKostenartVerwPeriodeVon.DataMember = "VerwPeriodeVon";
            this.edtKostenartVerwPeriodeVon.DataSource = this.qryKostenart;
            this.edtKostenartVerwPeriodeVon.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKostenartVerwPeriodeVon.EditValue = null;
            this.edtKostenartVerwPeriodeVon.Location = new System.Drawing.Point(133, 320);
            this.edtKostenartVerwPeriodeVon.Name = "edtKostenartVerwPeriodeVon";
            this.edtKostenartVerwPeriodeVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKostenartVerwPeriodeVon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKostenartVerwPeriodeVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKostenartVerwPeriodeVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostenartVerwPeriodeVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtKostenartVerwPeriodeVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKostenartVerwPeriodeVon.Properties.Appearance.Options.UseFont = true;
            this.edtKostenartVerwPeriodeVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtKostenartVerwPeriodeVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtKostenartVerwPeriodeVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtKostenartVerwPeriodeVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKostenartVerwPeriodeVon.Properties.ReadOnly = true;
            this.edtKostenartVerwPeriodeVon.Properties.ShowToday = false;
            this.edtKostenartVerwPeriodeVon.Size = new System.Drawing.Size(100, 24);
            this.edtKostenartVerwPeriodeVon.TabIndex = 10;
            //
            // lblKostenartVerwPeriodeVon
            //
            this.lblKostenartVerwPeriodeVon.Location = new System.Drawing.Point(6, 320);
            this.lblKostenartVerwPeriodeVon.Name = "lblKostenartVerwPeriodeVon";
            this.lblKostenartVerwPeriodeVon.Size = new System.Drawing.Size(121, 24);
            this.lblKostenartVerwPeriodeVon.TabIndex = 9;
            this.lblKostenartVerwPeriodeVon.Text = "Verwendungsperiode";
            this.lblKostenartVerwPeriodeVon.UseCompatibleTextRendering = true;
            //
            // edtKostenartBuchungstext
            //
            this.edtKostenartBuchungstext.DataMember = "Buchungstext";
            this.edtKostenartBuchungstext.DataSource = this.qryKostenart;
            this.edtKostenartBuchungstext.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKostenartBuchungstext.Location = new System.Drawing.Point(133, 290);
            this.edtKostenartBuchungstext.Name = "edtKostenartBuchungstext";
            this.edtKostenartBuchungstext.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKostenartBuchungstext.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKostenartBuchungstext.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostenartBuchungstext.Properties.Appearance.Options.UseBackColor = true;
            this.edtKostenartBuchungstext.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKostenartBuchungstext.Properties.Appearance.Options.UseFont = true;
            this.edtKostenartBuchungstext.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKostenartBuchungstext.Properties.ReadOnly = true;
            this.edtKostenartBuchungstext.Size = new System.Drawing.Size(251, 24);
            this.edtKostenartBuchungstext.TabIndex = 8;
            //
            // lblKostenartBuchungstext
            //
            this.lblKostenartBuchungstext.Location = new System.Drawing.Point(6, 290);
            this.lblKostenartBuchungstext.Name = "lblKostenartBuchungstext";
            this.lblKostenartBuchungstext.Size = new System.Drawing.Size(121, 24);
            this.lblKostenartBuchungstext.TabIndex = 7;
            this.lblKostenartBuchungstext.Text = "Text";
            this.lblKostenartBuchungstext.UseCompatibleTextRendering = true;
            //
            // edtKostenart
            //
            this.edtKostenart.DataMember = "KontoName";
            this.edtKostenart.DataSource = this.qryKostenart;
            this.edtKostenart.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKostenart.Location = new System.Drawing.Point(133, 260);
            this.edtKostenart.Name = "edtKostenart";
            this.edtKostenart.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKostenart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKostenart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostenart.Properties.Appearance.Options.UseBackColor = true;
            this.edtKostenart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKostenart.Properties.Appearance.Options.UseFont = true;
            this.edtKostenart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtKostenart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtKostenart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKostenart.Properties.ReadOnly = true;
            this.edtKostenart.Size = new System.Drawing.Size(251, 24);
            this.edtKostenart.TabIndex = 6;
            this.edtKostenart.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKostenart_UserModifiedFld);
            //
            // lblKostenartKonto
            //
            this.lblKostenartKonto.Location = new System.Drawing.Point(6, 260);
            this.lblKostenartKonto.Name = "lblKostenartKonto";
            this.lblKostenartKonto.Size = new System.Drawing.Size(121, 24);
            this.lblKostenartKonto.TabIndex = 5;
            this.lblKostenartKonto.Text = "Kostenart";
            this.lblKostenartKonto.UseCompatibleTextRendering = true;
            //
            // edtKostenartBetrag
            //
            this.edtKostenartBetrag.DataMember = "Betrag";
            this.edtKostenartBetrag.DataSource = this.qryKostenart;
            this.edtKostenartBetrag.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKostenartBetrag.Location = new System.Drawing.Point(133, 230);
            this.edtKostenartBetrag.Name = "edtKostenartBetrag";
            this.edtKostenartBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKostenartBetrag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKostenartBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKostenartBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostenartBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtKostenartBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKostenartBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtKostenartBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKostenartBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKostenartBetrag.Properties.DisplayFormat.FormatString = "N2";
            this.edtKostenartBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtKostenartBetrag.Properties.EditFormat.FormatString = "N2";
            this.edtKostenartBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtKostenartBetrag.Properties.Mask.EditMask = "N2";
            this.edtKostenartBetrag.Properties.Name = "editBetrag.Properties";
            this.edtKostenartBetrag.Properties.ReadOnly = true;
            this.edtKostenartBetrag.Size = new System.Drawing.Size(251, 24);
            this.edtKostenartBetrag.TabIndex = 4;
            //
            // lblKostenartBetrag
            //
            this.lblKostenartBetrag.Location = new System.Drawing.Point(6, 230);
            this.lblKostenartBetrag.Name = "lblKostenartBetrag";
            this.lblKostenartBetrag.Size = new System.Drawing.Size(121, 24);
            this.lblKostenartBetrag.TabIndex = 3;
            this.lblKostenartBetrag.Text = "Betrag";
            this.lblKostenartBetrag.UseCompatibleTextRendering = true;
            //
            // edtKostenartKostenstelle
            //
            this.edtKostenartKostenstelle.DataMember = "BaPerson";
            this.edtKostenartKostenstelle.DataSource = this.qryKostenart;
            this.edtKostenartKostenstelle.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKostenartKostenstelle.Location = new System.Drawing.Point(133, 200);
            this.edtKostenartKostenstelle.Name = "edtKostenartKostenstelle";
            this.edtKostenartKostenstelle.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKostenartKostenstelle.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKostenartKostenstelle.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostenartKostenstelle.Properties.Appearance.Options.UseBackColor = true;
            this.edtKostenartKostenstelle.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKostenartKostenstelle.Properties.Appearance.Options.UseFont = true;
            this.edtKostenartKostenstelle.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtKostenartKostenstelle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtKostenartKostenstelle.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKostenartKostenstelle.Properties.ReadOnly = true;
            this.edtKostenartKostenstelle.Size = new System.Drawing.Size(251, 24);
            this.edtKostenartKostenstelle.TabIndex = 2;
            this.edtKostenartKostenstelle.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKostenartKostenstelle_UserModifiedFld);
            //
            // lblKostenartKostenstelle
            //
            this.lblKostenartKostenstelle.Location = new System.Drawing.Point(6, 200);
            this.lblKostenartKostenstelle.Name = "lblKostenartKostenstelle";
            this.lblKostenartKostenstelle.Size = new System.Drawing.Size(121, 24);
            this.lblKostenartKostenstelle.TabIndex = 1;
            this.lblKostenartKostenstelle.Text = "Kostenstelle";
            this.lblKostenartKostenstelle.UseCompatibleTextRendering = true;
            //
            // grdKostenart
            //
            this.grdKostenart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdKostenart.DataSource = this.qryKostenart;
            //
            //
            //
            this.grdKostenart.EmbeddedNavigator.Name = "";
            this.grdKostenart.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdKostenart.Location = new System.Drawing.Point(3, 3);
            this.grdKostenart.MainView = this.grvKostenart;
            this.grdKostenart.Name = "grdKostenart";
            this.grdKostenart.Size = new System.Drawing.Size(726, 191);
            this.grdKostenart.TabIndex = 0;
            this.grdKostenart.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKostenart});
            //
            // grvKostenart
            //
            this.grvKostenart.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvKostenart.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKostenart.Appearance.Empty.Options.UseBackColor = true;
            this.grvKostenart.Appearance.Empty.Options.UseFont = true;
            this.grvKostenart.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvKostenart.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKostenart.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvKostenart.Appearance.EvenRow.Options.UseFont = true;
            this.grvKostenart.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKostenart.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKostenart.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKostenart.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKostenart.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKostenart.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKostenart.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKostenart.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKostenart.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvKostenart.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKostenart.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKostenart.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKostenart.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKostenart.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKostenart.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKostenart.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKostenart.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKostenart.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKostenart.Appearance.GroupRow.Options.UseFont = true;
            this.grvKostenart.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKostenart.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKostenart.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKostenart.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKostenart.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKostenart.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKostenart.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKostenart.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvKostenart.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKostenart.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKostenart.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKostenart.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKostenart.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKostenart.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvKostenart.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvKostenart.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKostenart.Appearance.OddRow.Options.UseFont = true;
            this.grvKostenart.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKostenart.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKostenart.Appearance.Row.Options.UseBackColor = true;
            this.grvKostenart.Appearance.Row.Options.UseFont = true;
            this.grvKostenart.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvKostenart.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKostenart.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvKostenart.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvKostenart.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKostenart.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvKostenart.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvKostenart.Appearance.VertLine.Options.UseBackColor = true;
            this.grvKostenart.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKostenart.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKostenartKonto,
            this.colKostenartKostenstelle,
            this.colKostenartBetrag,
            this.colKostenartBuchungstext});
            this.grvKostenart.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvKostenart.GridControl = this.grdKostenart;
            this.grvKostenart.Name = "grvKostenart";
            this.grvKostenart.OptionsBehavior.Editable = false;
            this.grvKostenart.OptionsCustomization.AllowFilter = false;
            this.grvKostenart.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKostenart.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKostenart.OptionsNavigation.UseTabKey = false;
            this.grvKostenart.OptionsView.ColumnAutoWidth = false;
            this.grvKostenart.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvKostenart.OptionsView.ShowGroupPanel = false;
            this.grvKostenart.OptionsView.ShowIndicator = false;
            //
            // colKostenartKonto
            //
            this.colKostenartKonto.Caption = "Konto";
            this.colKostenartKonto.FieldName = "KontoNr";
            this.colKostenartKonto.Name = "colKostenartKonto";
            this.colKostenartKonto.Visible = true;
            this.colKostenartKonto.VisibleIndex = 0;
            this.colKostenartKonto.Width = 92;
            //
            // colKostenartKostenstelle
            //
            this.colKostenartKostenstelle.Caption = "Kostenstelle";
            this.colKostenartKostenstelle.FieldName = "BaPerson";
            this.colKostenartKostenstelle.Name = "colKostenartKostenstelle";
            this.colKostenartKostenstelle.Visible = true;
            this.colKostenartKostenstelle.VisibleIndex = 1;
            this.colKostenartKostenstelle.Width = 138;
            //
            // colKostenartBetrag
            //
            this.colKostenartBetrag.Caption = "Betrag";
            this.colKostenartBetrag.DisplayFormat.FormatString = "N2";
            this.colKostenartBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colKostenartBetrag.FieldName = "Betrag";
            this.colKostenartBetrag.Name = "colKostenartBetrag";
            this.colKostenartBetrag.Visible = true;
            this.colKostenartBetrag.VisibleIndex = 2;
            this.colKostenartBetrag.Width = 192;
            //
            // colKostenartBuchungstext
            //
            this.colKostenartBuchungstext.Caption = "Buchungstext";
            this.colKostenartBuchungstext.FieldName = "Buchungstext";
            this.colKostenartBuchungstext.Name = "colKostenartBuchungstext";
            this.colKostenartBuchungstext.Visible = true;
            this.colKostenartBuchungstext.VisibleIndex = 3;
            this.colKostenartBuchungstext.Width = 480;
            //
            // tpgBuchenDetails
            //
            this.tpgBuchenDetails.Controls.Add(this.panSetStatus);
            this.tpgBuchenDetails.Controls.Add(this.ctlErfassungMutation);
            this.tpgBuchenDetails.Controls.Add(this.boxZugehoerigeBelegNr);
            this.tpgBuchenDetails.Controls.Add(this.edtBuchenKbBuchungID);
            this.tpgBuchenDetails.Controls.Add(this.lblBuchenKbBuchungID);
            this.tpgBuchenDetails.Controls.Add(this.edtBuchenBgBudgetID);
            this.tpgBuchenDetails.Controls.Add(this.lblBuchenBudgetMonatJahr);
            this.tpgBuchenDetails.Controls.Add(this.lblBuchenBgBudgetID);
            this.tpgBuchenDetails.Controls.Add(this.edtBuchenStatus);
            this.tpgBuchenDetails.Controls.Add(this.lblBuchenStatus);
            this.tpgBuchenDetails.Controls.Add(this.edtBuchenText);
            this.tpgBuchenDetails.Controls.Add(this.lblText);
            this.tpgBuchenDetails.Controls.Add(this.edtBuchenTyp);
            this.tpgBuchenDetails.Controls.Add(this.lblTyp);
            this.tpgBuchenDetails.Controls.Add(this.edtBuchenBelegNr);
            this.tpgBuchenDetails.Controls.Add(this.lblBelegNr);
            this.tpgBuchenDetails.Controls.Add(this.edtBuchenBetrag);
            this.tpgBuchenDetails.Controls.Add(this.lblBetrag);
            this.tpgBuchenDetails.Controls.Add(this.edtBuchenHabenSaldo);
            this.tpgBuchenDetails.Controls.Add(this.edtBuchenHaben);
            this.tpgBuchenDetails.Controls.Add(this.lblHaben);
            this.tpgBuchenDetails.Controls.Add(this.edtBuchenSollSaldo);
            this.tpgBuchenDetails.Controls.Add(this.edtBuchenSoll);
            this.tpgBuchenDetails.Controls.Add(this.lblSoll);
            this.tpgBuchenDetails.Controls.Add(this.edtValutaDatum);
            this.tpgBuchenDetails.Controls.Add(this.lblBuchenValuta);
            this.tpgBuchenDetails.Controls.Add(this.edtBuchenDatum);
            this.tpgBuchenDetails.Controls.Add(this.lblDatum);
            this.tpgBuchenDetails.Location = new System.Drawing.Point(6, 32);
            this.tpgBuchenDetails.Name = "tpgBuchenDetails";
            this.tpgBuchenDetails.Size = new System.Drawing.Size(732, 344);
            this.tpgBuchenDetails.TabIndex = 0;
            this.tpgBuchenDetails.Title = "Buchen";
            //
            // panSetStatus
            //
            this.panSetStatus.Controls.Add(this.panSetStatusBorder);
            this.panSetStatus.Controls.Add(this.btnVerbuchen);
            this.panSetStatus.Dock = System.Windows.Forms.DockStyle.Right;
            this.panSetStatus.Location = new System.Drawing.Point(697, 0);
            this.panSetStatus.Name = "panSetStatus";
            this.panSetStatus.Size = new System.Drawing.Size(35, 344);
            this.panSetStatus.TabIndex = 27;
            //
            // panSetStatusBorder
            //
            this.panSetStatusBorder.BackColor = System.Drawing.Color.Black;
            this.panSetStatusBorder.Dock = System.Windows.Forms.DockStyle.Left;
            this.panSetStatusBorder.Location = new System.Drawing.Point(0, 0);
            this.panSetStatusBorder.Name = "panSetStatusBorder";
            this.panSetStatusBorder.Size = new System.Drawing.Size(1, 344);
            this.panSetStatusBorder.TabIndex = 2;
            //
            // btnVerbuchen
            //
            this.btnVerbuchen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerbuchen.Location = new System.Drawing.Point(6, 9);
            this.btnVerbuchen.Name = "btnVerbuchen";
            this.btnVerbuchen.Padding = new System.Windows.Forms.Padding(0, 0, 2, 1);
            this.btnVerbuchen.Size = new System.Drawing.Size(24, 24);
            this.btnVerbuchen.TabIndex = 0;
            this.btnVerbuchen.Text = "V";
            this.btnVerbuchen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerbuchen.UseVisualStyleBackColor = false;
            this.btnVerbuchen.Click += new System.EventHandler(this.btnVerbuchen_Click);
            //
            // ctlErfassungMutation
            //
            this.ctlErfassungMutation.ActiveSQLQuery = this.qryKbBuchung;
            this.ctlErfassungMutation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlErfassungMutation.Location = new System.Drawing.Point(90, 279);
            this.ctlErfassungMutation.Name = "ctlErfassungMutation";
            this.ctlErfassungMutation.Size = new System.Drawing.Size(271, 40);
            this.ctlErfassungMutation.TabIndex = 20;
            this.ctlErfassungMutation.TabStop = false;
            //
            // boxZugehoerigeBelegNr
            //
            this.boxZugehoerigeBelegNr.Controls.Add(this.edtNeubuchungBelegNr);
            this.boxZugehoerigeBelegNr.Controls.Add(this.lblBuchenStorno2);
            this.boxZugehoerigeBelegNr.Controls.Add(this.edtStornoBelegNr);
            this.boxZugehoerigeBelegNr.Controls.Add(this.lblStornoBelegNr);
            this.boxZugehoerigeBelegNr.Controls.Add(this.edtOriginalBelegNr);
            this.boxZugehoerigeBelegNr.Controls.Add(this.lblOriginalBelegNr);
            this.boxZugehoerigeBelegNr.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.boxZugehoerigeBelegNr.Location = new System.Drawing.Point(390, 9);
            this.boxZugehoerigeBelegNr.Name = "boxZugehoerigeBelegNr";
            this.boxZugehoerigeBelegNr.Size = new System.Drawing.Size(252, 114);
            this.boxZugehoerigeBelegNr.TabIndex = 21;
            this.boxZugehoerigeBelegNr.TabStop = false;
            this.boxZugehoerigeBelegNr.Text = "Zugehörige Beleg-Nr.";
            this.boxZugehoerigeBelegNr.UseCompatibleTextRendering = true;
            //
            // edtNeubuchungBelegNr
            //
            this.edtNeubuchungBelegNr.DataMember = "NeubuchungBelegNr";
            this.edtNeubuchungBelegNr.DataSource = this.qryZugehoerigeBelegNr;
            this.edtNeubuchungBelegNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtNeubuchungBelegNr.Location = new System.Drawing.Point(126, 81);
            this.edtNeubuchungBelegNr.Name = "edtNeubuchungBelegNr";
            this.edtNeubuchungBelegNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtNeubuchungBelegNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtNeubuchungBelegNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNeubuchungBelegNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNeubuchungBelegNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtNeubuchungBelegNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNeubuchungBelegNr.Properties.Appearance.Options.UseFont = true;
            this.edtNeubuchungBelegNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNeubuchungBelegNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNeubuchungBelegNr.Properties.Name = "editBelegNr.Properties";
            this.edtNeubuchungBelegNr.Properties.ReadOnly = true;
            this.edtNeubuchungBelegNr.Size = new System.Drawing.Size(115, 24);
            this.edtNeubuchungBelegNr.TabIndex = 5;
            //
            // qryZugehoerigeBelegNr
            //
            this.qryZugehoerigeBelegNr.HostControl = this;
            this.qryZugehoerigeBelegNr.SelectStatement = "SELECT *\r\nFROM dbo.fnKbGetZugehoerigeBelegNr({0})";
            //
            // lblBuchenStorno2
            //
            this.lblBuchenStorno2.Location = new System.Drawing.Point(16, 81);
            this.lblBuchenStorno2.Name = "lblBuchenStorno2";
            this.lblBuchenStorno2.Size = new System.Drawing.Size(104, 24);
            this.lblBuchenStorno2.TabIndex = 4;
            this.lblBuchenStorno2.Text = "Neubuchung";
            this.lblBuchenStorno2.UseCompatibleTextRendering = true;
            //
            // edtStornoBelegNr
            //
            this.edtStornoBelegNr.DataMember = "StornoBelegNr";
            this.edtStornoBelegNr.DataSource = this.qryZugehoerigeBelegNr;
            this.edtStornoBelegNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtStornoBelegNr.Location = new System.Drawing.Point(126, 51);
            this.edtStornoBelegNr.Name = "edtStornoBelegNr";
            this.edtStornoBelegNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtStornoBelegNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtStornoBelegNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStornoBelegNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStornoBelegNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtStornoBelegNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStornoBelegNr.Properties.Appearance.Options.UseFont = true;
            this.edtStornoBelegNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStornoBelegNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStornoBelegNr.Properties.Name = "editBelegNr.Properties";
            this.edtStornoBelegNr.Properties.ReadOnly = true;
            this.edtStornoBelegNr.Size = new System.Drawing.Size(115, 24);
            this.edtStornoBelegNr.TabIndex = 3;
            //
            // lblStornoBelegNr
            //
            this.lblStornoBelegNr.Location = new System.Drawing.Point(16, 51);
            this.lblStornoBelegNr.Name = "lblStornoBelegNr";
            this.lblStornoBelegNr.Size = new System.Drawing.Size(104, 24);
            this.lblStornoBelegNr.TabIndex = 2;
            this.lblStornoBelegNr.Text = "Stornobuchung";
            this.lblStornoBelegNr.UseCompatibleTextRendering = true;
            //
            // edtOriginalBelegNr
            //
            this.edtOriginalBelegNr.DataMember = "OriginalBelegNr";
            this.edtOriginalBelegNr.DataSource = this.qryZugehoerigeBelegNr;
            this.edtOriginalBelegNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtOriginalBelegNr.Location = new System.Drawing.Point(126, 21);
            this.edtOriginalBelegNr.Name = "edtOriginalBelegNr";
            this.edtOriginalBelegNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtOriginalBelegNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtOriginalBelegNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtOriginalBelegNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtOriginalBelegNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtOriginalBelegNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtOriginalBelegNr.Properties.Appearance.Options.UseFont = true;
            this.edtOriginalBelegNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtOriginalBelegNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtOriginalBelegNr.Properties.Name = "editBelegNr.Properties";
            this.edtOriginalBelegNr.Properties.ReadOnly = true;
            this.edtOriginalBelegNr.Size = new System.Drawing.Size(115, 24);
            this.edtOriginalBelegNr.TabIndex = 1;
            //
            // lblOriginalBelegNr
            //
            this.lblOriginalBelegNr.Location = new System.Drawing.Point(16, 21);
            this.lblOriginalBelegNr.Name = "lblOriginalBelegNr";
            this.lblOriginalBelegNr.Size = new System.Drawing.Size(104, 24);
            this.lblOriginalBelegNr.TabIndex = 0;
            this.lblOriginalBelegNr.Text = "Originalbuchung";
            this.lblOriginalBelegNr.UseCompatibleTextRendering = true;
            //
            // edtBuchenKbBuchungID
            //
            this.edtBuchenKbBuchungID.DataMember = "KbBuchungID";
            this.edtBuchenKbBuchungID.DataSource = this.qryKbBuchung;
            this.edtBuchenKbBuchungID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBuchenKbBuchungID.Location = new System.Drawing.Point(516, 129);
            this.edtBuchenKbBuchungID.Name = "edtBuchenKbBuchungID";
            this.edtBuchenKbBuchungID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBuchenKbBuchungID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBuchenKbBuchungID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchenKbBuchungID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchenKbBuchungID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchenKbBuchungID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchenKbBuchungID.Properties.Appearance.Options.UseFont = true;
            this.edtBuchenKbBuchungID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBuchenKbBuchungID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBuchenKbBuchungID.Properties.DisplayFormat.FormatString = "################################";
            this.edtBuchenKbBuchungID.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBuchenKbBuchungID.Properties.EditFormat.FormatString = "################################";
            this.edtBuchenKbBuchungID.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBuchenKbBuchungID.Properties.Mask.EditMask = "################################";
            this.edtBuchenKbBuchungID.Properties.ReadOnly = true;
            this.edtBuchenKbBuchungID.Size = new System.Drawing.Size(115, 24);
            this.edtBuchenKbBuchungID.TabIndex = 23;
            //
            // lblBuchenKbBuchungID
            //
            this.lblBuchenKbBuchungID.Location = new System.Drawing.Point(406, 129);
            this.lblBuchenKbBuchungID.Name = "lblBuchenKbBuchungID";
            this.lblBuchenKbBuchungID.Size = new System.Drawing.Size(104, 24);
            this.lblBuchenKbBuchungID.TabIndex = 22;
            this.lblBuchenKbBuchungID.Text = "Beleg-ID";
            this.lblBuchenKbBuchungID.UseCompatibleTextRendering = true;
            //
            // edtBuchenBgBudgetID
            //
            this.edtBuchenBgBudgetID.DataMember = "BgBudgetID";
            this.edtBuchenBgBudgetID.DataSource = this.qryKbBuchung;
            this.edtBuchenBgBudgetID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBuchenBgBudgetID.Location = new System.Drawing.Point(516, 159);
            this.edtBuchenBgBudgetID.Name = "edtBuchenBgBudgetID";
            this.edtBuchenBgBudgetID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBuchenBgBudgetID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBuchenBgBudgetID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchenBgBudgetID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchenBgBudgetID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchenBgBudgetID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchenBgBudgetID.Properties.Appearance.Options.UseFont = true;
            this.edtBuchenBgBudgetID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBuchenBgBudgetID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBuchenBgBudgetID.Properties.ReadOnly = true;
            this.edtBuchenBgBudgetID.Size = new System.Drawing.Size(115, 24);
            this.edtBuchenBgBudgetID.TabIndex = 25;
            //
            // lblBuchenBudgetMonatJahr
            //
            this.lblBuchenBudgetMonatJahr.DataMember = "BudgetMonatJahr";
            this.lblBuchenBudgetMonatJahr.DataSource = this.qryKbBuchung;
            this.lblBuchenBudgetMonatJahr.Location = new System.Drawing.Point(516, 186);
            this.lblBuchenBudgetMonatJahr.Name = "lblBuchenBudgetMonatJahr";
            this.lblBuchenBudgetMonatJahr.Size = new System.Drawing.Size(115, 24);
            this.lblBuchenBudgetMonatJahr.TabIndex = 26;
            this.lblBuchenBudgetMonatJahr.UseCompatibleTextRendering = true;
            //
            // lblBuchenBgBudgetID
            //
            this.lblBuchenBgBudgetID.Location = new System.Drawing.Point(406, 159);
            this.lblBuchenBgBudgetID.Name = "lblBuchenBgBudgetID";
            this.lblBuchenBgBudgetID.Size = new System.Drawing.Size(104, 24);
            this.lblBuchenBgBudgetID.TabIndex = 24;
            this.lblBuchenBgBudgetID.Text = "Budget-Nr.";
            this.lblBuchenBgBudgetID.UseCompatibleTextRendering = true;
            //
            // edtBuchenStatus
            //
            this.edtBuchenStatus.AllowNull = false;
            this.edtBuchenStatus.DataMember = "KbBuchungStatusCode";
            this.edtBuchenStatus.DataSource = this.qryKbBuchung;
            this.edtBuchenStatus.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBuchenStatus.Location = new System.Drawing.Point(90, 249);
            this.edtBuchenStatus.LOVName = "KbBuchungsStatus";
            this.edtBuchenStatus.Name = "edtBuchenStatus";
            this.edtBuchenStatus.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBuchenStatus.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchenStatus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchenStatus.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchenStatus.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchenStatus.Properties.Appearance.Options.UseFont = true;
            this.edtBuchenStatus.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBuchenStatus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchenStatus.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBuchenStatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBuchenStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtBuchenStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtBuchenStatus.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBuchenStatus.Properties.NullText = "";
            this.edtBuchenStatus.Properties.ReadOnly = true;
            this.edtBuchenStatus.Properties.ShowFooter = false;
            this.edtBuchenStatus.Properties.ShowHeader = false;
            this.edtBuchenStatus.Size = new System.Drawing.Size(271, 24);
            this.edtBuchenStatus.TabIndex = 19;
            //
            // lblBuchenStatus
            //
            this.lblBuchenStatus.Location = new System.Drawing.Point(9, 249);
            this.lblBuchenStatus.Name = "lblBuchenStatus";
            this.lblBuchenStatus.Size = new System.Drawing.Size(75, 24);
            this.lblBuchenStatus.TabIndex = 18;
            this.lblBuchenStatus.Text = "Status";
            this.lblBuchenStatus.UseCompatibleTextRendering = true;
            //
            // edtBuchenText
            //
            this.edtBuchenText.DataMember = "Text";
            this.edtBuchenText.DataSource = this.qryKbBuchung;
            this.edtBuchenText.Location = new System.Drawing.Point(90, 219);
            this.edtBuchenText.Name = "edtBuchenText";
            this.edtBuchenText.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBuchenText.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchenText.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchenText.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchenText.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchenText.Properties.Appearance.Options.UseFont = true;
            this.edtBuchenText.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBuchenText.Properties.MaxLength = 120;
            this.edtBuchenText.Properties.Name = "editText.Properties";
            this.edtBuchenText.Size = new System.Drawing.Size(271, 24);
            this.edtBuchenText.TabIndex = 17;
            //
            // lblText
            //
            this.lblText.Location = new System.Drawing.Point(9, 219);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(75, 24);
            this.lblText.TabIndex = 16;
            this.lblText.Text = "Text";
            this.lblText.UseCompatibleTextRendering = true;
            //
            // edtBuchenTyp
            //
            this.edtBuchenTyp.AllowNull = false;
            this.edtBuchenTyp.DataMember = "KbBuchungTypCode";
            this.edtBuchenTyp.DataSource = this.qryKbBuchung;
            this.edtBuchenTyp.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBuchenTyp.Location = new System.Drawing.Point(90, 189);
            this.edtBuchenTyp.LOVName = "KbBuchungTyp";
            this.edtBuchenTyp.Name = "edtBuchenTyp";
            this.edtBuchenTyp.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBuchenTyp.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchenTyp.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchenTyp.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchenTyp.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchenTyp.Properties.Appearance.Options.UseFont = true;
            this.edtBuchenTyp.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBuchenTyp.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchenTyp.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBuchenTyp.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBuchenTyp.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtBuchenTyp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtBuchenTyp.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBuchenTyp.Properties.NullText = "";
            this.edtBuchenTyp.Properties.ReadOnly = true;
            this.edtBuchenTyp.Properties.ShowFooter = false;
            this.edtBuchenTyp.Properties.ShowHeader = false;
            this.edtBuchenTyp.Size = new System.Drawing.Size(271, 24);
            this.edtBuchenTyp.TabIndex = 15;
            //
            // lblTyp
            //
            this.lblTyp.Location = new System.Drawing.Point(9, 189);
            this.lblTyp.Name = "lblTyp";
            this.lblTyp.Size = new System.Drawing.Size(75, 24);
            this.lblTyp.TabIndex = 14;
            this.lblTyp.Text = "Typ";
            this.lblTyp.UseCompatibleTextRendering = true;
            //
            // edtBuchenBelegNr
            //
            this.edtBuchenBelegNr.DataMember = "BelegNr";
            this.edtBuchenBelegNr.DataSource = this.qryKbBuchung;
            this.edtBuchenBelegNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBuchenBelegNr.Location = new System.Drawing.Point(90, 159);
            this.edtBuchenBelegNr.Name = "edtBuchenBelegNr";
            this.edtBuchenBelegNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBuchenBelegNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBuchenBelegNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchenBelegNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchenBelegNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchenBelegNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchenBelegNr.Properties.Appearance.Options.UseFont = true;
            this.edtBuchenBelegNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBuchenBelegNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBuchenBelegNr.Properties.Name = "editBelegNr.Properties";
            this.edtBuchenBelegNr.Properties.ReadOnly = true;
            this.edtBuchenBelegNr.Size = new System.Drawing.Size(122, 24);
            this.edtBuchenBelegNr.TabIndex = 13;
            //
            // lblBelegNr
            //
            this.lblBelegNr.Location = new System.Drawing.Point(9, 159);
            this.lblBelegNr.Name = "lblBelegNr";
            this.lblBelegNr.Size = new System.Drawing.Size(75, 24);
            this.lblBelegNr.TabIndex = 12;
            this.lblBelegNr.Text = "Beleg-Nr.";
            this.lblBelegNr.UseCompatibleTextRendering = true;
            //
            // edtBuchenBetrag
            //
            this.edtBuchenBetrag.DataMember = "Betrag";
            this.edtBuchenBetrag.DataSource = this.qryKbBuchung;
            this.edtBuchenBetrag.Location = new System.Drawing.Point(90, 129);
            this.edtBuchenBetrag.Name = "edtBuchenBetrag";
            this.edtBuchenBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBuchenBetrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBuchenBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchenBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchenBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchenBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchenBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtBuchenBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBuchenBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBuchenBetrag.Properties.DisplayFormat.FormatString = "N2";
            this.edtBuchenBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBuchenBetrag.Properties.EditFormat.FormatString = "N2";
            this.edtBuchenBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBuchenBetrag.Properties.Mask.EditMask = "N2";
            this.edtBuchenBetrag.Size = new System.Drawing.Size(122, 24);
            this.edtBuchenBetrag.TabIndex = 11;
            //
            // lblBetrag
            //
            this.lblBetrag.Location = new System.Drawing.Point(9, 129);
            this.lblBetrag.Name = "lblBetrag";
            this.lblBetrag.Size = new System.Drawing.Size(75, 24);
            this.lblBetrag.TabIndex = 10;
            this.lblBetrag.Text = "Betrag CHF";
            this.lblBetrag.UseCompatibleTextRendering = true;
            //
            // edtBuchenHabenSaldo
            //
            this.edtBuchenHabenSaldo.DataMember = "Vorsaldo";
            this.edtBuchenHabenSaldo.DataSource = this.qryHabenSaldo;
            this.edtBuchenHabenSaldo.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBuchenHabenSaldo.Location = new System.Drawing.Point(276, 99);
            this.edtBuchenHabenSaldo.Name = "edtBuchenHabenSaldo";
            this.edtBuchenHabenSaldo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBuchenHabenSaldo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBuchenHabenSaldo.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchenHabenSaldo.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchenHabenSaldo.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchenHabenSaldo.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchenHabenSaldo.Properties.Appearance.Options.UseFont = true;
            this.edtBuchenHabenSaldo.Properties.Appearance.Options.UseTextOptions = true;
            this.edtBuchenHabenSaldo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtBuchenHabenSaldo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBuchenHabenSaldo.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBuchenHabenSaldo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBuchenHabenSaldo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBuchenHabenSaldo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.edtBuchenHabenSaldo.Properties.Name = "editBetrag.Properties";
            this.edtBuchenHabenSaldo.Properties.Precision = 2;
            this.edtBuchenHabenSaldo.Properties.ReadOnly = true;
            this.edtBuchenHabenSaldo.Size = new System.Drawing.Size(85, 24);
            this.edtBuchenHabenSaldo.TabIndex = 9;
            this.edtBuchenHabenSaldo.Visible = false;
            //
            // qryHabenSaldo
            //
            this.qryHabenSaldo.HostControl = this;
            this.qryHabenSaldo.SelectStatement = "SELECT Vorsaldo,\r\n       KbKontoartCodes\r\nFROM dbo.KbKonto WITH (READUNCOMMITTED)" +
                "\r\nWHERE KbPeriodeID = {0} AND \r\n      KontoNr = {1}";
            //
            // edtBuchenHaben
            //
            this.edtBuchenHaben.DataMember = "HabenKtoNr";
            this.edtBuchenHaben.DataSource = this.qryKbBuchung;
            this.edtBuchenHaben.Location = new System.Drawing.Point(90, 99);
            this.edtBuchenHaben.Name = "edtBuchenHaben";
            this.edtBuchenHaben.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBuchenHaben.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchenHaben.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchenHaben.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchenHaben.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchenHaben.Properties.Appearance.Options.UseFont = true;
            this.edtBuchenHaben.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtBuchenHaben.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtBuchenHaben.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBuchenHaben.Size = new System.Drawing.Size(180, 24);
            this.edtBuchenHaben.TabIndex = 8;
            this.edtBuchenHaben.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtBuchenHaben_UserModifiedFld);
            //
            // lblHaben
            //
            this.lblHaben.Location = new System.Drawing.Point(9, 99);
            this.lblHaben.Name = "lblHaben";
            this.lblHaben.Size = new System.Drawing.Size(75, 24);
            this.lblHaben.TabIndex = 7;
            this.lblHaben.Text = "Haben";
            this.lblHaben.UseCompatibleTextRendering = true;
            //
            // edtBuchenSollSaldo
            //
            this.edtBuchenSollSaldo.DataMember = "Vorsaldo";
            this.edtBuchenSollSaldo.DataSource = this.qrySollSaldo;
            this.edtBuchenSollSaldo.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBuchenSollSaldo.Location = new System.Drawing.Point(276, 69);
            this.edtBuchenSollSaldo.Name = "edtBuchenSollSaldo";
            this.edtBuchenSollSaldo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBuchenSollSaldo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBuchenSollSaldo.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchenSollSaldo.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchenSollSaldo.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchenSollSaldo.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchenSollSaldo.Properties.Appearance.Options.UseFont = true;
            this.edtBuchenSollSaldo.Properties.Appearance.Options.UseTextOptions = true;
            this.edtBuchenSollSaldo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtBuchenSollSaldo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBuchenSollSaldo.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBuchenSollSaldo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBuchenSollSaldo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBuchenSollSaldo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.edtBuchenSollSaldo.Properties.Name = "editBetrag.Properties";
            this.edtBuchenSollSaldo.Properties.Precision = 2;
            this.edtBuchenSollSaldo.Properties.ReadOnly = true;
            this.edtBuchenSollSaldo.Size = new System.Drawing.Size(85, 24);
            this.edtBuchenSollSaldo.TabIndex = 6;
            this.edtBuchenSollSaldo.Visible = false;
            //
            // qrySollSaldo
            //
            this.qrySollSaldo.HostControl = this;
            this.qrySollSaldo.SelectStatement = "SELECT Vorsaldo,\r\n       KbKontoartCodes\r\nFROM dbo.KbKonto WITH (READUNCOMMITTED)" +
                "\r\nWHERE KbPeriodeID = {0} AND \r\n      KontoNr = {1}";
            //
            // edtBuchenSoll
            //
            this.edtBuchenSoll.DataMember = "SollKtoNr";
            this.edtBuchenSoll.DataSource = this.qryKbBuchung;
            this.edtBuchenSoll.Location = new System.Drawing.Point(90, 69);
            this.edtBuchenSoll.Name = "edtBuchenSoll";
            this.edtBuchenSoll.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBuchenSoll.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchenSoll.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchenSoll.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchenSoll.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchenSoll.Properties.Appearance.Options.UseFont = true;
            this.edtBuchenSoll.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtBuchenSoll.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtBuchenSoll.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBuchenSoll.Size = new System.Drawing.Size(180, 24);
            this.edtBuchenSoll.TabIndex = 5;
            this.edtBuchenSoll.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtBuchenSoll_UserModifiedFld);
            //
            // lblSoll
            //
            this.lblSoll.Location = new System.Drawing.Point(9, 69);
            this.lblSoll.Name = "lblSoll";
            this.lblSoll.Size = new System.Drawing.Size(75, 24);
            this.lblSoll.TabIndex = 4;
            this.lblSoll.Text = "Soll";
            this.lblSoll.UseCompatibleTextRendering = true;
            //
            // edtValutaDatum
            //
            this.edtValutaDatum.DataMember = "ValutaDatum";
            this.edtValutaDatum.DataSource = this.qryKbBuchung;
            this.edtValutaDatum.EditValue = null;
            this.edtValutaDatum.Location = new System.Drawing.Point(90, 39);
            this.edtValutaDatum.Name = "edtValutaDatum";
            this.edtValutaDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtValutaDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtValutaDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtValutaDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtValutaDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtValutaDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtValutaDatum.Properties.Appearance.Options.UseFont = true;
            this.edtValutaDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtValutaDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtValutaDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.edtValutaDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtValutaDatum.Properties.ShowToday = false;
            this.edtValutaDatum.Size = new System.Drawing.Size(95, 24);
            this.edtValutaDatum.TabIndex = 3;
            //
            // lblBuchenValuta
            //
            this.lblBuchenValuta.Location = new System.Drawing.Point(9, 39);
            this.lblBuchenValuta.Name = "lblBuchenValuta";
            this.lblBuchenValuta.Size = new System.Drawing.Size(75, 24);
            this.lblBuchenValuta.TabIndex = 2;
            this.lblBuchenValuta.Text = "Valuta";
            this.lblBuchenValuta.UseCompatibleTextRendering = true;
            //
            // edtBuchenDatum
            //
            this.edtBuchenDatum.DataMember = "BelegDatum";
            this.edtBuchenDatum.DataSource = this.qryKbBuchung;
            this.edtBuchenDatum.EditValue = null;
            this.edtBuchenDatum.Location = new System.Drawing.Point(90, 9);
            this.edtBuchenDatum.Name = "edtBuchenDatum";
            this.edtBuchenDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBuchenDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBuchenDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchenDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchenDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchenDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchenDatum.Properties.Appearance.Options.UseFont = true;
            this.edtBuchenDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.edtBuchenDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtBuchenDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.edtBuchenDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBuchenDatum.Properties.ShowToday = false;
            this.edtBuchenDatum.Size = new System.Drawing.Size(95, 24);
            this.edtBuchenDatum.TabIndex = 1;
            //
            // lblDatum
            //
            this.lblDatum.Location = new System.Drawing.Point(9, 9);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(75, 24);
            this.lblDatum.TabIndex = 0;
            this.lblDatum.Text = "Beleg Datum";
            this.lblDatum.UseCompatibleTextRendering = true;
            //
            // qryKontoart
            //
            this.qryKontoart.HostControl = this;
            this.qryKontoart.SelectStatement = resources.GetString("qryKontoart.SelectStatement");
            //
            // lblRowCount
            //
            this.lblRowCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRowCount.Location = new System.Drawing.Point(505, 242);
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Size = new System.Drawing.Size(233, 24);
            this.lblRowCount.TabIndex = 1;
            this.lblRowCount.Text = "Anzahl Buchungen: <Count>";
            this.lblRowCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblRowCount.UseCompatibleTextRendering = true;
            //
            // btnClearSearch
            //
            this.btnClearSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearSearch.IconID = 4;
            this.btnClearSearch.Location = new System.Drawing.Point(636, 178);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(24, 24);
            this.btnClearSearch.TabIndex = 37;
            this.btnClearSearch.UseVisualStyleBackColor = false;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            //
            // edtBelegDatumBisX
            //
            this.edtBelegDatumBisX.EditValue = null;
            this.edtBelegDatumBisX.Location = new System.Drawing.Point(223, 62);
            this.edtBelegDatumBisX.Name = "edtBelegDatumBisX";
            this.edtBelegDatumBisX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBelegDatumBisX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBelegDatumBisX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBelegDatumBisX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBelegDatumBisX.Properties.Appearance.Options.UseBackColor = true;
            this.edtBelegDatumBisX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBelegDatumBisX.Properties.Appearance.Options.UseFont = true;
            this.edtBelegDatumBisX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject15.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject15.Options.UseBackColor = true;
            this.edtBelegDatumBisX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtBelegDatumBisX.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject15)});
            this.edtBelegDatumBisX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBelegDatumBisX.Properties.ShowToday = false;
            this.edtBelegDatumBisX.Size = new System.Drawing.Size(100, 24);
            this.edtBelegDatumBisX.TabIndex = 8;
            //
            // lblBis2X
            //
            this.lblBis2X.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblBis2X.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblBis2X.Location = new System.Drawing.Point(198, 62);
            this.lblBis2X.Name = "lblBis2X";
            this.lblBis2X.Size = new System.Drawing.Size(25, 24);
            this.lblBis2X.TabIndex = 7;
            this.lblBis2X.Text = "-";
            this.lblBis2X.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBis2X.UseCompatibleTextRendering = true;
            //
            // edtBelegDatumVonX
            //
            this.edtBelegDatumVonX.EditValue = null;
            this.edtBelegDatumVonX.Location = new System.Drawing.Point(98, 62);
            this.edtBelegDatumVonX.Name = "edtBelegDatumVonX";
            this.edtBelegDatumVonX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBelegDatumVonX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBelegDatumVonX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBelegDatumVonX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBelegDatumVonX.Properties.Appearance.Options.UseBackColor = true;
            this.edtBelegDatumVonX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBelegDatumVonX.Properties.Appearance.Options.UseFont = true;
            this.edtBelegDatumVonX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject16.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject16.Options.UseBackColor = true;
            this.edtBelegDatumVonX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtBelegDatumVonX.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject16)});
            this.edtBelegDatumVonX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBelegDatumVonX.Properties.ShowToday = false;
            this.edtBelegDatumVonX.Size = new System.Drawing.Size(100, 24);
            this.edtBelegDatumVonX.TabIndex = 6;
            //
            // lblBelegDatumX
            //
            this.lblBelegDatumX.Location = new System.Drawing.Point(30, 62);
            this.lblBelegDatumX.Name = "lblBelegDatumX";
            this.lblBelegDatumX.Size = new System.Drawing.Size(62, 24);
            this.lblBelegDatumX.TabIndex = 5;
            this.lblBelegDatumX.Text = "Beleg";
            this.lblBelegDatumX.UseCompatibleTextRendering = true;
            //
            // CtlKbBuchung
            //
            this.ActiveSQLQuery = this.qryKbBuchung;
            this.Controls.Add(this.lblRowCount);
            this.Controls.Add(this.panDetails);
            this.Name = "CtlKbBuchung";
            this.Size = new System.Drawing.Size(744, 650);
            this.Load += new System.EventHandler(this.CtlKbBuchung_Load);
            this.Controls.SetChildIndex(this.panDetails, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.lblRowCount, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBuchungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKbBuchung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBuchungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repStatusImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErstelltX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErstelltDatumVonX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis3X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErstelltDatumBisX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValutaX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValutaDatumVonX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis4X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValutaDatumBisX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegNummerVonX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis1X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegNummerBisX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollVonX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis6X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollBisX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHabenX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHabenVonX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis7X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHabenBisX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetragX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetragVonX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis5X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetragBisX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTextX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTextX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatusX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTypX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTypX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTypX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfasserX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfasserX.Properties)).EndInit();
            this.panDetails.ResumeLayout(false);
            this.tabBuchen.ResumeLayout(false);
            this.tpgDebitor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtDebitor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDebitor)).EndInit();
            this.tpgKreditor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditorLinie.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditorBankIBAN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditorBankIBAN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditorBankKontoNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditorBankKontoNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditorPCKontoNrFormat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditorBankName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditorBankName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBankName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlinfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditorBeguenstigtOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditorBeguenstigtPLZ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditorBeguenstigtPLZOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditorBeguenstigtStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditorBeguenstigtStrasseNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditorBeguenstigtName2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditorBeguenstigtName2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditorBeguenstigtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditorBeguenstigtName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditorEinzahlungsscheinCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditorEinzahlungsscheinCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditorReferenzNummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditorReferenzNummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditorMitteilungZeile4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditorMitteilungZeile3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditorMitteilungZeile2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditorMitteilungZeile1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMitteilung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditor)).EndInit();
            this.tpgKostenarten.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtDifferenz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenartDifferenz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenartTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenartBuchungsBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenartBuchungsbetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenartZusammenfassungtotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenartZusammenfassung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenartVerwPeriodeBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKostenart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenartVerwPeriodeBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenartVerwPeriodeVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenartVerwPeriodeVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenartBuchungstext.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenartBuchungstext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenartKonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenartBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenartBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenartKostenstelle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenartKostenstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKostenart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKostenart)).EndInit();
            this.tpgBuchenDetails.ResumeLayout(false);
            this.panSetStatus.ResumeLayout(false);
            this.boxZugehoerigeBelegNr.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtNeubuchungBelegNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugehoerigeBelegNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchenStorno2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStornoBelegNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStornoBelegNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOriginalBelegNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOriginalBelegNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchenKbBuchungID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchenKbBuchungID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchenBgBudgetID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchenBudgetMonatJahr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchenBgBudgetID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchenStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchenStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchenStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchenText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchenTyp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchenTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchenBelegNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchenBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchenHabenSaldo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryHabenSaldo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchenHaben.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHaben)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchenSollSaldo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrySollSaldo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchenSoll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValutaDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchenValuta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchenDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKontoart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRowCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegDatumBisX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis2X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegDatumVonX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegDatumX)).EndInit();
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

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // set flag
                _emptySearch = true;

                // do new search
                OnNewSearch();
            }
            finally
            {
                // reset flag
                _emptySearch = false;
            }
        }

        private void btnUpdateZahlinfo_Click(object sender, System.EventArgs e)
        {
            DBUtil.ExecuteScalarSQLThrowingException(@"
                EXEC dbo.spKbUpdateKbBuchungZahlInfo {0}, {1};",
                qryKbBuchung[DBO.KbBuchung.KbBuchungID],
                Session.User.UserID);

            qryKbBuchung.Refresh();
        }

        private void btnVerbuchen_Click(object sender, EventArgs e)
        {
            // set cursor
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // do it
                BookBooking();
            }
            catch (KissInfoException ex)
            {
                // show info message
                ex.ShowMessage();
            }
            catch (Exception ex)
            {
                // show error
                KissMsg.ShowError(this.Name, "ErrorBtnVerbuchen", "Es ist ein Fehler beim Verbuchen der Buchung aufgetreten.", ex);
            }
            finally
            {
                // handle button verbuchen
                EnableBtnVerbuchen();

                // reset cursor
                Cursor.Current = Cursors.Default;
            }
        }

        private void CtlKbBuchung_Load(object sender, System.EventArgs e)
        {
            try
            {
                _kbPeriodeID = Convert.ToInt32(FormController.GetMessage("FrmKbKlientenbuchhaltung", false, "Action", "KbPeriodeID"));
                _kbMandantID = Convert.ToInt32(FormController.GetMessage("FrmKbKlientenbuchhaltung", false, "Action", "KbMandantID"));
            }
            catch (Exception ex)
            {
                // set static vars (debug only?)
                _kbPeriodeID = 30;
                _kbMandantID = 1;

                // show error
                KissMsg.ShowError(this.Name, "ErrorInClassLoad_v01", "Es ist ein Fehler beim Laden der Maske aufgetreten.", ex);
            }

            // --- set initial active query
            this.ActiveSQLQuery = this.qryKbBuchung;
            kissSearch.SelectParameters = new object[] { _kbPeriodeID };

            // --- Buchungsstatus laden
            repStatusImg.SmallImages = KissImageList.SmallImageList;
            SqlQuery qryStatus = DBUtil.OpenSQL(@"
                SELECT *
                FROM dbo.XLOVCode WITH (READUNCOMMITTED)
                WHERE LOVName = 'KbBuchungsStatus'
                ORDER BY SortKey;");

            foreach (DataRow row in qryStatus.DataTable.Rows)
            {
                repStatusImg.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(
                    Convert.ToString(row["Text"]),
                    Convert.ToInt32(row["Code"]),
                    KissImageList.GetImageIndex(Convert.ToInt32(row["Value1"]))));
            }

            // Dasselbe für edtStatusX
            edtStatusX.Properties.SmallImages = KissImageList.SmallImageList;
            edtStatusX.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", null, -1));

            foreach (DevExpress.XtraEditors.Controls.ImageComboBoxItem item in repStatusImg.Items)
            {
                edtStatusX.Properties.Items.Add(item);
            }

            // start and run new search
            NewSearch();
            tabControlSearch.SelectTab(tpgListe);

            // setup tabpages
            tabBuchen.SelectTab(tpgBuchenDetails);
            ShowDetailsTabControl();

            // set focus
            grdBuchungen.Focus();
        }

        private void edtBuchenHaben_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.KbKontoSuchen(edtBuchenHaben.Text, _kbPeriodeID, e.ButtonClicked);

            if (!e.Cancel)
            {
                qryKbBuchung[DBO.KbBuchung.HabenKtoNr] = dlg["KontoNr"];

                if (DBUtil.IsEmpty(qryKbBuchung[DBO.KbBuchung.HabenKtoNr]))
                {
                    qryKbBuchung["HabenKtoName"] = "Div.";
                    qryKbBuchung["HabenKtoNameLong"] = "Diverse";
                }
                else
                {
                    qryKbBuchung["HabenKtoName"] = qryKbBuchung[DBO.KbBuchung.HabenKtoNr];
                    qryKbBuchung["HabenKtoNameLong"] = qryKbBuchung[DBO.KbBuchung.HabenKtoNr];
                }

                qryHabenSaldo.Fill(_kbPeriodeID, dlg["KontoNr"]);
                edtBuchenHaben.Text = Utils.ConvertToString(dlg["KontoNr"]);
            }

            EnableDebitorAndKreditor();
            EnableKostenart();
        }

        private void edtBuchenSoll_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.KbKontoSuchen(edtBuchenSoll.Text, _kbPeriodeID, e.ButtonClicked);

            if (!e.Cancel)
            {
                qryKbBuchung[DBO.KbBuchung.SollKtoNr] = dlg["KontoNr"];

                if (DBUtil.IsEmpty(qryKbBuchung[DBO.KbBuchung.SollKtoNr]))
                {
                    qryKbBuchung["SollKtoName"] = "Div.";
                    qryKbBuchung["SollKtoNameLong"] = "Diverse";
                }
                else
                {
                    qryKbBuchung["SollKtoName"] = qryKbBuchung[DBO.KbBuchung.SollKtoNr];
                    qryKbBuchung["SollKtoNameLong"] = qryKbBuchung[DBO.KbBuchung.SollKtoNr];
                }

                qrySollSaldo.Fill(_kbPeriodeID, dlg["KontoNr"]);
                edtBuchenSoll.Text = Utils.ConvertToString(dlg["KontoNr"]);
            }

            EnableDebitorAndKreditor();
            EnableKostenart();
        }

        private void edtDebitor_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string searchString = edtDebitor.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                qryKbBuchung[DBO.KbBuchung.Schuldner_BaInstitutionID] = null;
                return;
            }

            KissLookupDialog dlg = new KissLookupDialog();

            e.Cancel = !dlg.SearchData(_institutionStatement, searchString, true);

            if (!e.Cancel)
            {
                qryKbBuchung[DBO.KbBuchung.Schuldner_BaInstitutionID] = dlg["BaInstitutionID"];
            }
        }

        private void edtErfasserX_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(edtErfasserX.Text, e.ButtonClicked);

            if (!e.Cancel)
            {
                edtErfasserX.EditValue = dlg["Name"];
                edtErfasserX.LookupID = dlg["UserID"];
            }
        }

        private void edtKostenart_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();

            e.Cancel = !dlg.SucheKostenart(_kbPeriodeID, edtKostenart.Text);

            if (!e.Cancel)
            {
                qryKostenart[DBO.KbBuchungKostenart.KontoNr] = dlg["KontoNr"];
                qryKostenart[DBO.KbBuchungKostenart.BgKostenartID] = dlg["BgKostenartID"];
                qryKostenart["KontoName"] = dlg["Name"];

                // apply copy of BgSplittingArtCode, Weiterverrechenbar and Quoting
                qryKostenart[DBO.KbBuchungKostenart.BgSplittingArtCode] = dlg["BgSplittingArtCode"];
                qryKostenart[DBO.KbBuchungKostenart.Weiterverrechenbar] = dlg["Weiterverrechenbar"];
                qryKostenart[DBO.KbBuchungKostenart.Quoting] = dlg["Quoting"];
            }
        }

        private void edtKostenartKostenstelle_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahlKbKostenstelle dlg = new DlgAuswahlKbKostenstelle();

            dlg.SucheKostenstelle(edtKostenartKostenstelle.Text);

            e.Cancel = dlg.ShowDialog() != DialogResult.OK;

            if (!e.Cancel)
            {
                qryKostenart[DBO.KbBuchungKostenart.KbKostenstelleID] = dlg["KbKostenStelleID"];
                qryKostenart[DBO.KbBuchungKostenart.BaPersonID] = dlg["PersonID"];

                qryKostenart["BaPerson"] = DBUtil.ExecuteScalarSQL(@"
                    SELECT dbo.fnKbGetKostenstelle({0});", qryKostenart[DBO.KbBuchungKostenart.BaPersonID]);
            }
        }

        private void edtKreditor_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahlBaZahlungsweg dlg = new DlgAuswahlBaZahlungsweg();

            dlg.SucheBaZahlungsweg(edtKreditor.Text);

            e.Cancel = dlg.ShowDialog() != DialogResult.OK;

            if (!e.Cancel)
            {
                System.Diagnostics.Debug.WriteLine("SucheBaZahlungsweg == OK");

                qryKbBuchung[DBO.KbBuchung.BaZahlungswegID] = dlg["BaZahlungswegID"];
                qryKbBuchung[DBO.KbBuchung.PCKontoNr] = dlg["PostKontoNummer"];
                qryKbBuchung[DBO.KbBuchung.BankKontoNr] = dlg["BankKontoNummer"];
                qryKbBuchung[DBO.KbBuchung.IBAN] = dlg["IBANNummer"];
                qryKbBuchung[DBO.KbBuchung.BaBankID] = dlg["BaBankID"];
                qryKbBuchung[DBO.KbBuchung.BankBCN] = dlg["BankClearingNr"];
                qryKbBuchung[DBO.KbBuchung.BankName] = dlg["BankName"];
                qryKbBuchung[DBO.KbBuchung.BankStrasse] = dlg["BankStrasse"];
                qryKbBuchung["BankPlz"] = dlg["BankPLZ"];
                qryKbBuchung[DBO.KbBuchung.BankOrt] = dlg["BankOrt"];

                qryKbBuchung["PCKontoNrFormat"] = dlg["PC"];

                qryKbBuchung[DBO.KbBuchung.BeguenstigtName] = dlg["BeguenstigtName"]; //dlg["Kreditor"];
                qryKbBuchung[DBO.KbBuchung.BeguenstigtName2] = dlg["BeguenstigtName2"];
                qryKbBuchung[DBO.KbBuchung.BeguenstigtStrasse] = dlg["BeguenstigtStrasseHausNr"];
                qryKbBuchung[DBO.KbBuchung.BeguenstigtPLZ] = dlg["BeguenstigtPLZ"];
                qryKbBuchung[DBO.KbBuchung.BeguenstigtOrt] = dlg["BeguenstigtOrt"];

                System.Diagnostics.Debug.WriteLine("EinzahlungsscheinCode = " + Utils.ConvertToInt(dlg["EinzahlungsscheinCode"]).ToString());
                qryKbBuchung[DBO.KbBuchung.EinzahlungsscheinCode] = dlg["EinzahlungsscheinCode"];

                // --- lösche die felder welche abhängig sind von rot/orange
                qryKbBuchung[DBO.KbBuchung.MitteilungZeile1] = string.Empty;
                qryKbBuchung[DBO.KbBuchung.MitteilungZeile2] = string.Empty;
                qryKbBuchung[DBO.KbBuchung.MitteilungZeile3] = string.Empty;
                qryKbBuchung[DBO.KbBuchung.MitteilungZeile4] = string.Empty;

                if (Utils.ConvertToInt(dlg["EinzahlungsscheinCode"]) == 1)
                {
                    qryKbBuchung[DBO.KbBuchung.ReferenzNummer] = dlg["ReferenzNummer"];
                }
                else
                {
                    qryKbBuchung[DBO.KbBuchung.ReferenzNummer] = string.Empty;
                }

                UpdateEditModes();
            }
        }

        private void qryKbBuchung_AfterDelete(object sender, EventArgs e)
        {
            //Das Löschen hat geklappt. Transaktion committen.
            Session.Commit();
        }

        private void qryKbBuchung_AfterFill(object sender, EventArgs e)
        {
            UpdateRowCount();

            // select last record
            qryKbBuchung.Last();
        }

        private void qryKbBuchung_AfterInsert(object sender, System.EventArgs e)
        {
            qryKbBuchung[DBO.KbBuchung.KbBuchungTypCode] = 2;
            qryKbBuchung[DBO.KbBuchung.KbBuchungStatusCode] = 2;        // by default, entry is Freigegeben
            qryKbBuchung[lblBuchenBudgetMonatJahr.DataMember] = "-";
            edtBuchenTyp.EditMode = EditModeType.ReadOnly;
            edtBuchenDatum.Focus();

            // update enabled states of controls
            UpdateControlsAndStates();
        }

        private void qryKbBuchung_AfterPost(object sender, System.EventArgs e)
        {
            // refresh grid
            grdBuchungen.Refresh();

            // update enabled states of controls
            UpdateControlsAndStates();

            // --- falls es ein divers konto gibt müssen die kostenarten gesetzt werden.
            if (IsDivers())
            {
                if (Utils.ConvertToInt(qryTotal["Anzahl"]) == 0)
                {
                    KissMsg.ShowInfo(this.Name, "DiversKonto", "Bitte fügen Sie Kostenarten zu dieser Buchung hinzu.");
                }
            }
        }

        private void qryKbBuchung_BeforeDelete(object sender, System.EventArgs e)
        {
            //Transaktion muss geöffnet werden, damit wir die Kostenarten nur löschen, wenn die zugehörige
            //Buchung auch gelöscht wird.
            Session.BeginTransaction();
            try
            {
                // (re)check concurrency
                CheckConcurrency();

                // delete all KbBuchungKostenart entries for given KbBuchungID
                DeleteKostenarten(Utils.ConvertToInt(qryKbBuchung[DBO.KbBuchung.KbBuchungID], -1));

                // recycle BelegNr
                int? belegNr = qryKbBuchung[DBO.KbBuchung.BelegNr] as int?;
                int? buchungTypCode = qryKbBuchung[DBO.KbBuchung.KbBuchungTypCode] as int?;
                // nur manuelle Buchungen können gelöscht werden. Siehe qryKbBuchung_BeforeDeleteQuestion
                if (belegNr.HasValue && buchungTypCode.HasValue && buchungTypCode.Value == 2)
                {
                    DBUtil.ExecSQLThrowingException(@"
                        EXEC spKbRecycleBelegNr {0}, 10, NULL, {1};", // 10 = Belegkreis 'Manuelle Buchung'
                        qryKbBuchung[DBO.KbBuchung.KbPeriodeID],
                        belegNr
                    );
                }
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
                throw new KissCancelException();
            }
        }

        private void qryKbBuchung_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            // check concurrency
            CheckConcurrency();

            // Es können nur manuelle Buchungen gelöscht werden
            if (Utils.ConvertToInt(qryKbBuchung[DBO.KbBuchung.KbBuchungTypCode], -1) != 2)
            {
                KissMsg.ShowInfo(
                    Name,
                    "NurManuelleBuchungLoeschbar",
                    "Es können nur manuelle Buchungen gelöscht werden.");
                throw new KissCancelException();
            }
        }

        private void qryKbBuchung_BeforePost(object sender, System.EventArgs e)
        {
            // check if BelegNr has changed (security, this should never occure)
            if (qryKbBuchung.Row.RowState == DataRowState.Modified && qryKbBuchung.ColumnModified(DBO.KbBuchung.BelegNr))
            {
                // logging
                XLog.Create(this.GetType().FullName, LogLevel.ERROR, "Modified BelegNr, property should be readonly.");

                // cancel post
                throw new KissErrorException(KissMsg.GetMLMessage(this.Name,
                                                                  "BeforePostCannotChangeBelegNr",
                                                                  "Die Beleg-Nr. darf nicht verändert werden, bitte Änderungen rückgängig machen."));
            }

            // validate must fields
            DBUtil.CheckNotNullField(edtBuchenBetrag, lblBetrag.Text);
            DBUtil.CheckNotNullField(edtBuchenText, lblText.Text);

            // validate ReferenzNummer
            if (!CheckReferenznummer())
            {
                edtKreditorReferenzNummer.Focus();
                throw new KissCancelException();
            }

            if (!CheckBuchenDatum())
            {
                throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                 "InvalidBuchenDatum_v02",
                                                                 "Das Buchungsdatum ist leer oder ungültig. Möglicherweise ist die Periode nicht aktiv.",
                                                                 KissMsgCode.MsgInfo),
                                            this.edtBuchenDatum);
            }

            EnableDebitorAndKreditor();

            if (edtValutaDatum.EditMode == EditModeType.Required)
            {
                DBUtil.CheckNotNullField(edtValutaDatum, lblBuchenValuta.Text);
            }

            // --- es muss mindestens ein konto gesetzt sein
            if (IsDivers())
            {
                // --- falls beide null sind
                if (string.IsNullOrEmpty(edtBuchenSoll.Text) && string.IsNullOrEmpty(edtBuchenHaben.Text))
                {
                    throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                     "KeinKontoGesetzt_v01",
                                                                     "Es muss mindestens das Soll oder das Haben Konto angegeben werden.",
                                                                     KissMsgCode.MsgInfo));
                }
            }

            qryKbBuchung[DBO.KbBuchung.KbBuchungTypCode] = 2;     // manuell
            qryKbBuchung[DBO.KbBuchung.KbPeriodeID] = _kbPeriodeID;

            if (Utils.ConvertToInt(qryKbBuchung[DBO.KbBuchung.KbBuchungStatusCode]) == 0)
            {
                qryKbBuchung[DBO.KbBuchung.KbBuchungStatusCode] = 13;  // verbucht
            }

            if (IsKreditorSpecified())
            {
                qryKbBuchung[DBO.KbBuchung.KbAuszahlungsArtCode] = 101; // elektronisch
            }
            else
            {
                qryKbBuchung[DBO.KbBuchung.KbAuszahlungsArtCode] = DBNull.Value;
            }

            // check concurrency
            CheckConcurrency();

            // set modification information
            ctlErfassungMutation.SetFields();

            CheckKontoNrIsNotKostenart();
        }

        private void qryKbBuchung_DeleteError(object sender, UnhandledExceptionEventArgs e)
        {
            //Das Delete ist fehlgeschlagen, Transaktion rollbacken.
            if (Session.Transaction != null)
            {
                // rollback changes
                Session.Rollback();
            }

            RefreshStates(true);
        }

        private void qryKbBuchung_PositionChanged(object sender, System.EventArgs e)
        {
            RefreshStates(true);
        }

        private void qryKostenart_AfterDelete(object sender, System.EventArgs e)
        {
            CalculateTotal();
        }

        private void qryKostenart_AfterInsert(object sender, System.EventArgs e)
        {
            edtKostenartKostenstelle.Focus();
        }

        private void qryKostenart_AfterPost(object sender, System.EventArgs e)
        {
            CalculateTotal();
            qryKbBuchung.Post();
        }

        private void qryKostenart_BeforeDelete(object sender, EventArgs e)
        {
            if (IsBuchungReadonly())
            {
                //Zurzeit werden in SqlQuery.OnBeforeDelete() sämtliche Exceptions geschluckt. Deshalb muss die Fehlermeldung hier
                //mittels KissMsg angezeigt werden. Sollte dies mal refactored werden, so dass auftretende KissCancelExceptions
                //nicht mehr geschluckt und angezeigt werden, muss dieses KissMsg.ShowInfo entfernt werden.
                KissMsg.ShowInfo(this.Name,
                                 "BuchungIsReadOnlyErrorDelete",
                                 "Kostenart löschen nicht möglich. Es wurde keine editierbare Buchung ausgewählt.");

                throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                 "BuchungIsReadOnlyErrorDelete",
                                                                 "Kostenart löschen nicht möglich. Es wurde keine editierbare Buchung ausgewählt.",
                                                                 KissMsgCode.MsgInfo));
            }
        }

        private void qryKostenart_BeforeInsert(object sender, System.EventArgs e)
        {
            if (!IsDivers())
            {
                throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                 "BuchungIsDiversError",
                                                                 "Es kann nicht auf eine Kostenart gebucht werden, da Soll- und Haben-Konto ausgewählt sind.",
                                                                 KissMsgCode.MsgInfo));
            }

            if (IsBuchungReadonly())
            {
                throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                 "BuchungIsReadOnlyError",
                                                                 "Kostenart hinzufügen nicht möglich. Es wurde keine editierbare Buchung ausgewählt.",
                                                                 KissMsgCode.MsgInfo));
            }

            SetKostenartEditModeForced(EditModeType.Normal);
        }

        private void qryKostenart_BeforePost(object sender, System.EventArgs e)
        {
            // validate VerwPeriodeVon/Bis
            DBUtil.CheckNotNullField(edtKostenartVerwPeriodeVon, "Verwendungsperiode von");
            DBUtil.CheckNotNullField(edtKostenartVerwPeriodeBis, "Verwendungsperiode bis");

            // check date order
            if (Convert.ToDateTime(edtKostenartVerwPeriodeVon.EditValue) > Convert.ToDateTime(edtKostenartVerwPeriodeBis.EditValue))
            {
                // invalid range
                edtKostenartVerwPeriodeVon.Focus();
                KissMsg.ShowInfo(this.Name, "InvalidDateOrderVerwPeriode", "Das Datum 'bis' der Verwendungsperiode darf nicht kleiner als das Datum 'von' sein.");
                throw new KissCancelException();
            }

            // --- Überprüfe muss-feld
            if (string.IsNullOrEmpty(edtKostenartKostenstelle.Text))
            {
                KissMsg.ShowInfo(this.Name, "edtKostenartKostenstelle", "Es muss eine Kostenstelle angegeben werden. Die Daten werden nicht gespeichert.");
                edtKostenartKostenstelle.Focus();
                throw new KissCancelException();
            }

            // --- Überprüfe muss-feld
            if (string.IsNullOrEmpty(edtKostenartBetrag.Text))
            {
                KissMsg.ShowInfo(this.Name, "edtKostenartBetrag", "Es muss ein Betrag angegeben werden. Die Daten werden nicht gespeichert.");
                edtKostenartBetrag.Focus();
                throw new KissCancelException();
            }

            // --- Überprüfe muss-feld
            if (string.IsNullOrEmpty(edtKostenart.Text))
            {
                KissMsg.ShowInfo(this.Name, "KeineKostenart", "Es muss eine Kostenart angegeben werden. Die Daten werden nicht gespeichert.");
                edtKostenart.Focus();
                throw new KissCancelException();
            }

            qryKostenart[DBO.KbBuchungKostenart.KbBuchungID] = qryKbBuchung[DBO.KbBuchung.KbBuchungID];
            CalculateTotal();
        }

        private void qryKostenart_PositionChanged(object sender, System.EventArgs e)
        {
            CalculateTotal();
        }

        private void tabBuchen_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            SetActiveSQLQuery();
        }

        private void tabBuchen_SelectedTabChanging(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // --- SelectedTabIndex contains the Tab where i came from!
            switch (tabBuchen.SelectedTabIndex)
            {
                case 0:
                case 2: //Ticket 4068; es muss beim wechsel des Kreditoren Tabs geprüft werden ob Referenznr. vorhanden ist. Sonst endlosloop
                    if (!qryKbBuchung.Post())
                    {
                        e.Cancel = true;
                    }

                    break;

                case 1:
                    break;

                default:
                    break;
            }
        }

        private void tabControlSearch_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            ShowDetailsTabControl();
        }

        private void tabControlSearch_SelectedTabChanging(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("tabControlSearch.SelectedTabChanging");

            tabBuchen.SelectedTabIndex = 0;
            SetActiveSQLQuery();
        }

        #endregion

        #region Methods

        #region Public Methods

        void IBelegleser.ProcessBelegleser(Belegleser beleg)
        {
            if (IsBuchungReadonly() || !IsKreditorSpecified())
            {
                return;
            }

            DlgAuswahlBaZahlungsweg dlg = new DlgAuswahlBaZahlungsweg();
            dlg.SucheBaZahlungsweg(beleg);

            switch (dlg.Count)
            {
                case 0:
                    KissMsg.ShowInfo(this.Name, "KeinKreditorEintrag", "Keine zutreffenden Kreditor-Einträge im Institutionenstamm gefunden!");
                    return;

                case 1:
                    qryKbBuchung[DBO.KbBuchung.BaZahlungswegID] = dlg["BaZahlungswegID"];
                    qryKbBuchung[DBO.KbBuchung.PCKontoNr] = dlg["PostKontoNummer"];
                    qryKbBuchung["PcKontoNrFormat"] = dlg["PC"];
                    qryKbBuchung[DBO.KbBuchung.BankKontoNr] = dlg["BankKontoNummer"];
                    qryKbBuchung[DBO.KbBuchung.IBAN] = dlg["IBANNummer"];
                    qryKbBuchung[DBO.KbBuchung.BaBankID] = dlg["BaBankID"];
                    qryKbBuchung[DBO.KbBuchung.BankBCN] = dlg["BankClearingNr"];
                    qryKbBuchung[DBO.KbBuchung.BankName] = dlg["BankName"];
                    qryKbBuchung[DBO.KbBuchung.BankStrasse] = dlg["BankStrasse"];
                    qryKbBuchung["BankPlz"] = dlg["BankPLZ"];
                    qryKbBuchung[DBO.KbBuchung.BankOrt] = dlg["BankOrt"];

                    qryKbBuchung[DBO.KbBuchung.BeguenstigtName] = dlg["BeguenstigtName"];
                    qryKbBuchung[DBO.KbBuchung.BeguenstigtName2] = dlg["BeguenstigtName2"];
                    qryKbBuchung[DBO.KbBuchung.BeguenstigtStrasse] = dlg["BeguenstigtStrasseHausNr"];
                    //NOT SUPPORTED ANYMORE qryKbBuchung["BeguenstigtHausNr"] = dlg["HausNr"];
                    //NOT SUPPORTED ANYMORE qryKbBuchung["BeguenstigtPostfach"] = dlg["Postfach"];
                    qryKbBuchung[DBO.KbBuchung.BeguenstigtPLZ] = dlg["BeguenstigtPLZ"];
                    qryKbBuchung[DBO.KbBuchung.BeguenstigtOrt] = dlg["BeguenstigtOrt"];
                    //NOT SUPPORTED ANYMORE qryKbBuchung["BeguenstigtLandCode"] = dlg["LandCode"];

                    qryKbBuchung[DBO.KbBuchung.EinzahlungsscheinCode] = dlg["EinzahlungsscheinCode"];

                    qryKbBuchung[DBO.KbBuchung.Betrag] = beleg.Betrag;
                    qryKbBuchung[DBO.KbBuchung.ReferenzNummer] = beleg.ReferenzNummer;
                    qryKbBuchung.RefreshDisplay();
                    break;

                default:
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        goto case 1;
                    }

                    break;
            }
        }

        /// <summary>
        /// Translates the components of the instance
        /// </summary>
        public override void Translate()
        {
            // first, let base do stuff
            base.Translate();

            // setup controls for multilanguage handling
            SetupControlsML();
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            // let base do stuff
            base.NewSearch();

            // check if need to apply default values
            if (!_emptySearch)
            {
                // apply default search settings
                edtErstelltDatumVonX.EditValue = DateTime.Today.AddDays(-1);
                edtErfasserX.EditValue = string.Format("{0}, {1}", Session.User.LastName, Session.User.FirstName);
                edtErfasserX.LookupID = Session.User.UserID;
            }

            // set focus
            edtErstelltDatumVonX.Focus();
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Validates BelegNr for given KbPeriodeID
        /// </summary>
        /// <param name="kbPeriodeID">The id of KbPeriode</param>
        /// <param name="belegNr">The BelegNr to validate within KbPeriode</param>
        /// <returns><c>True</c> if BelegNr is valid, otherwise <c>False</c></returns>
        private static bool CheckBelegNummer(int kbPeriodeID, int belegNr)
        {
            if (kbPeriodeID < 1 || belegNr < 1)
            {
                return false;
            }

            return Convert.ToBoolean(DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT dbo.fnKbCheckBelegNr ({0}, {1}, NULL, {2}, NULL);", kbPeriodeID,
                                                                         BELEGKREIS_MANUELLEBUCHUNG, // lov KbBelegkreis
                                                                         belegNr));
        }

        /// <summary>
        /// Get integer value from code object
        /// </summary>
        /// <param name="code">The code to parse as integer</param>
        /// <returns>Integer value of code or 0 if code could not be parsed</returns>
        private static int GetCode(object code)
        {
            try
            {
                return Convert.ToInt32(code);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Get new BelegNr for bookings. This call should always be done within an open transaction.
        /// </summary>
        /// <param name="kbMandantID">The id of the KbMandant</param>
        /// <param name="kbBelegKreisCode">The code-id of the entry within KbBelegKreis</param>
        /// <param name="belegDatum">The date for getting the KbPeriodeID</param>
        /// <returns>A valid BelegNr for the given parameters</returns>
        /// <exception cref="KissCancelException">Thrown in case of validation error</exception>
        private static int GetNewBelegNr(int kbMandantID, int kbBelegKreisCode, DateTime belegDatum)
        {
            // init vars
            object newBelegNrObj = null;
            int newBelegNr = -1;

            // get current KbPeriodeID for given parameters
            int kbPeriodeID = Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT ISNULL(dbo.fnKbGetPeriodeIDByDate({0}, {1}, NULL, 1), -1);", kbMandantID, belegDatum));

            // validate current mandant-id
            if (kbMandantID < 1)
            {
                // invalid BgPositionID
                throw new KissCancelException(KissMsg.GetMLMessage(CLASSNAME,
                                                                   "BelegNrInvalidMandantID",
                                                                   "Die aktuelle Mandant-ID ist ungültig."));
            }

            // validate current belegKreis
            if (kbBelegKreisCode < 1)
            {
                // invalid BgPositionID
                throw new KissCancelException(KissMsg.GetMLMessage(CLASSNAME,
                                                                   "BelegNrInvalidBelegKreis",
                                                                   "Der aktuelle Belegkreis ist ungültig."));
            }

            // validate current BgBudgetID
            if (belegDatum == null)
            {
                // invalid BgBudgetID
                throw new KissCancelException(KissMsg.GetMLMessage(CLASSNAME,
                                                                   "BelegNrInvalidBelegDatum",
                                                                   "Das aktuelle Belegdatum ist ungültig."));
            }

            // validate PeriodeID
            if (kbPeriodeID < 0)
            {
                // invalid KbPeriodeID
                throw new KissCancelException(KissMsg.GetMLMessage(CLASSNAME,
                                                                   "BelegNrCouldNotGetKbPeriodeID",
                                                                   "Es konnte keine gültige KbPeriodeID anhand der Mandant-ID und Belegdatums gefunden werden."));
            }

            // get unique record number
            newBelegNrObj = DBUtil.ExecuteScalarSQLThrowingException(@"
                EXEC dbo.spKbGetBelegNr {0}, {1}, NULL, 0;", kbPeriodeID, kbBelegKreisCode);

            // validate content of new BelegNr
            if (newBelegNrObj == null || !(newBelegNrObj is int) || Convert.ToInt32(newBelegNrObj) < 1)
            {
                // invalid new record number (empty/not int/out of scope)
                throw new KissCancelException(KissMsg.GetMLMessage(CLASSNAME,
                                                                   "InvalidNewRecordNumberValue",
                                                                   "Die automatisch generierte BelegNr. hat einen ungültigen Wert."));
            }

            // set number
            newBelegNr = Convert.ToInt32(newBelegNrObj);

            // validate new record number for security purpose
            if (!CheckBelegNummer(kbPeriodeID, newBelegNr))
            {
                // invalid new record number (duplicate)
                throw new KissCancelException(KissMsg.GetMLMessage(CLASSNAME,
                                                                   "InvalidNewRecordNumberUnique",
                                                                   "Die automatisch generierte BelegNr. ('{0}') existiert bereits und kann für die Periode ('{1}') nicht nochmals verwendet werden.",
                                                                   newBelegNr,
                                                                   kbPeriodeID));
            }

            // if we are here, the new BelegNr is valid
            return newBelegNr;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Book current selected entry (Buchung verbuchen)
        /// </summary>
        private void BookBooking()
        {
            // validate first
            ValidateKontoKostenarten();

            if (!CanBookBooking())
            {
                throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                 "CannotBookEntryPreRequirements",
                                                                 "Die Buchung kann nicht verbucht werden, da nicht alle Vorbedingungen erfüllt sind."));
            }

            // save data on query to ensure proper state
            if (!qryKbBuchung.Post())
            {
                throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                 "CannotBookEntrySaveChanges",
                                                                 "Die Buchung kann nicht verbucht werden, da die Änderungen an der aktuellen Buchung können nicht gespeichert werden können."));
            }

            // do it in transaction
            Session.BeginTransaction();

            try
            {
                // check concurrency
                CheckConcurrency();

                // get vars
                int kbBuchungID = Convert.ToInt32(qryKbBuchung[DBO.KbBuchung.KbBuchungID]);
                DateTime belegDatum = Convert.ToDateTime(qryKbBuchung[DBO.KbBuchung.BelegDatum]);
                int kbPeriodeID = Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                    SELECT ISNULL(dbo.fnKbGetPeriodeIDByDate({0}, {1}, NULL, 1), -1);", _kbMandantID, belegDatum));
                int kbBelegKreisID = Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                    SELECT KbBelegKreisID
                    FROM KbBelegKreis
                    WHERE KbPeriodeID = {0} AND KbBelegKreisCode = {1}", kbPeriodeID, BELEGKREIS_MANUELLEBUCHUNG));

                // get new BelegNr
                int newBelegNr = GetNewBelegNr(_kbMandantID, BELEGKREIS_MANUELLEBUCHUNG, belegDatum);

                // update BelegNr on KbBuchung depending on BgPositionID and new number
                int rowCountBuc = Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                    UPDATE dbo.KbBuchung
                    SET BelegNr             = {0},
                        KbBuchungStatusCode = 13,   -- Verbucht
                        KbBelegKreisID      = {2}
                    WHERE BelegNr IS NULL           -- security (do never overwrite an existing BelegNr)
                      AND KbBuchungStatusCode = 2   -- Freigegeben
                      AND KbBuchungID = {1};

                    SELECT @@ROWCOUNT;", newBelegNr, kbBuchungID, kbBelegKreisID));

                // validate
                if (rowCountBuc < 1)
                {
                    throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                     "BookingNoEntryUpdated",
                                                                     "Es wurde keine Buchung zum Verbuchen gefunden."));
                }

                // finally, update data to prevent refresh from database
                qryKbBuchung[DBO.KbBuchung.KbBuchungStatusCode] = 13; // verbucht
                qryKbBuchung[DBO.KbBuchung.BelegNr] = newBelegNr;
                qryKbBuchung[DBO.KbBuchung.KbBuchungTS] = (Byte[])DBUtil.ExecuteScalarSQLThrowingException(@"
                    SELECT KbBuchungTS
                    FROM dbo.KbBuchung
                    WHERE KbBuchungID = {0};", kbBuchungID);

                // accept changes
                qryKbBuchung.Row.AcceptChanges();
                qryKbBuchung.RowModified = false;

                // do commit
                Session.Commit();

                // update enabled states of controls
                UpdateControlsAndStates();
                qryKbBuchung.RefreshDisplay();
                qryZugehoerigeBelegNr.Refresh();
            }
            catch (Exception ex)
            {
                if (Session.Transaction != null)
                {
                    // rollback changes
                    Session.Rollback();
                }

                // undo changes on current row!
                qryKbBuchung.Row.RejectChanges();
                qryKbBuchung.RefreshDisplay();

                // create new message
                throw new KissInfoException(
                    KissMsg.GetMLMessage(
                        Name,
                        "ErrorBookingEntry",
                        "Es ist ein Fehler beim Verbuchen der Buchung aufgetreten:\r\n\r\n{0}",
                        ex.Message),
                    ex);
            }
        }

        /// <summary>
        /// Berechnet das Total aller Kostenarten der aktuelle Buchung.
        /// </summary>
        private Decimal CalculateTotal()
        {
            qryTotal.Fill(qryKbBuchung[DBO.KbBuchung.KbBuchungID]);

            decimal total = Utils.ConvertToDecimal(qryTotal["Total"]);
            edtTotal.EditValue = total;

            decimal differenz = Utils.ConvertToDecimal(qryKbBuchung[DBO.KbBuchung.Betrag]) - total;
            edtDifferenz.EditValue = differenz;

            if (differenz == 0)
            {
                edtDifferenz.ForeColor = System.Drawing.Color.Black;
            }
            else if (differenz < 0)
            {
                edtDifferenz.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                edtDifferenz.ForeColor = System.Drawing.Color.Green;
            }

            return total;
        }

        /// <summary>
        /// Check if position can be booked by button "Verbuchen"
        /// </summary>
        /// <returns><c>True</c> if position can be booked, otherwise <c>False</c></returns>
        private bool CanBookBooking()
        {
            // validate query state
            if (qryKbBuchung.IsEmpty || !qryKbBuchung.CanUpdate)
            {
                // no data
                return false;
            }

            // get some values
            int status = GetCode(qryKbBuchung[DBO.KbBuchung.KbBuchungStatusCode]);

            // requires: 2=freigegeben, belegNr is empty, belegDatum is not empty
            if (status != 2 ||
                !DBUtil.IsEmpty(qryKbBuchung[DBO.KbBuchung.BelegNr]) ||
                DBUtil.IsEmpty(qryKbBuchung[DBO.KbBuchung.BelegDatum]))
            {
                // we are missing some data
                return false;
            }

            // if we are here, the position can be released
            return true;
        }

        private bool CheckBuchenDatum()
        {
            return Convert.ToBoolean(DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT dbo.fnKbCheckBelegDatum ({0}, {1});", _kbPeriodeID, qryKbBuchung[DBO.KbBuchung.BelegDatum]));
        }

        /// <summary>
        /// Check concurrency for datamodifications by other users
        /// </summary>
        /// <exception cref="DBConcurrencyException">Thrown if concurrency problems were detected</exception>
        private void CheckConcurrency()
        {
            if (!CheckConcurrencyTS())
            {
                // logging
                XLog.Create(this.GetType().FullName, LogLevel.INFO, "Concurrency error prevented, throwing error to user.");

                // throw error
                throw new DBConcurrencyException(KissMsg.GetMLMessage(this.Name,
                                                                      "CheckConcurrencyError",
                                                                      "Es ist eine Parallelitätsverletzung aufgetreten. Wahrscheinlich wurden die Daten inzwischen bereits verändert oder gelöscht. Bitte aktualisieren Sie die Ansicht zuerst."));
            }
        }

        /// <summary>
        /// Check concurrency for datamodifications by other users validating various TS columns
        /// </summary>
        /// <returns><c>True</c> if data seems to be valid, otherwise <c>False</c></returns>
        private bool CheckConcurrencyTS()
        {
            // validate
            if (qryKbBuchung.IsEmpty || qryKbBuchung.Row.RowState == DataRowState.Added)
            {
                // no data or new entry, do not check concurrency
                return true;
            }

            // check BgPositionTS (only if not new entry!)
            if (!CheckConcurrencyTS(DBO.KbBuchung.DBOName, DBO.KbBuchung.KbBuchungTS))
            {
                // invalid
                return false;
            }

            // if we are here, everything is ok
            return true;
        }

        private bool CheckConcurrencyTS(string tableName, string columnName)
        {
            if (!DBUtil.IsEmpty(qryKbBuchung[columnName]))
            {
                // check if timestamp within table still exists (unique within database)
                return Convert.ToBoolean(DBUtil.ExecuteScalarSQLThrowingException(@"
                    IF (EXISTS (SELECT TOP 1 1
                                FROM dbo." + tableName + @" WITH (READUNCOMMITTED)
                                WHERE " + columnName + @" = {0}))
                    BEGIN
                      SELECT 1;  -- valid;
                    END
                    ELSE
                    BEGIN
                      SELECT 0;  -- invalid
                    END;", qryKbBuchung[columnName]));
            }

            // no timestamp, expected value for given row!
            return false;
        }

        private void CheckKontoNrIsNotKostenart()
        {
            CheckKontoNrIsNotKostenart(edtBuchenSoll);
            CheckKontoNrIsNotKostenart(edtBuchenHaben);
        }

        private void CheckKontoNrIsNotKostenart(KissButtonEdit edtKonto)
        {
            if (edtKonto.EditValue != null && IsKostenartKontoNr(edtKonto.EditValue.ToString()))
            {
                ShowInfoIsKostenartKontoNr();
                edtKonto.Focus();
            }
        }

        /// <summary>
        /// Überprüft die angegebene Referenznummer auf Korrektheit. Die Länge kann nicht
        /// überprüft werde, da unbekannt ist, welches Format verwendet wird.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private bool CheckReferenznummer()
        {
            bool result = true;
            string value = edtKreditorReferenzNummer.Text;

            // --- ok, falls kein kreditor angegeben
            if (!IsKreditorSpecified())
            {
                return true;
            }

            // --- ok, falls kein oranger Einzahlungsschein
            int einzahlungsscheinCode = Utils.ConvertToInt(qryKbBuchung[DBO.KbBuchung.EinzahlungsscheinCode]);

            if (einzahlungsscheinCode != 1) // 1: orange
            {
                return true;
            }

            // --- falls gesetzt
            if (string.IsNullOrEmpty(value))
            {
                // --- falls ein Kreditor gesetzt ist
                if (!string.IsNullOrEmpty(edtKreditor.Text))
                {
                    DBUtil.CheckNotNullField(edtKreditorReferenzNummer, lblKreditorReferenzNummer.Text);
                }
                else
                {
                    result = true;
                }
            }
            else
            {
                return edtKreditorReferenzNummer.ValidateReferenzNummer(qryKbBuchung[DBO.KbBuchung.PCKontoNr].ToString());
            }

            return result;
        }

        /// <summary>
        /// Determines whether the specified account list contains account.
        /// </summary>
        /// <param name="accountList">The account list.</param>
        /// <param name="account">The account.</param>
        /// <returns>
        /// 	<c>true</c> if the specified account list contains account; otherwise, <c>false</c>.
        /// </returns>
        private bool ContainsAccount(string accountList, string account)
        {
            bool result = false;
            string[] items = accountList.Split(',');

            foreach (string a in items)
            {
                if (a.Trim().Equals(account))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        private void DeleteKostenarten(int kbBuchungID)
        {
            DBUtil.ExecSQLThrowingException(@"
                DELETE
                FROM dbo.KbBuchungKostenart
                WHERE KbBuchungID = {0};", kbBuchungID);
        }

        /// <summary>
        /// Enable or disable button Verbuchen depending on current states
        /// </summary>
        private void EnableBtnVerbuchen()
        {
            // handle button Freigeben
            btnVerbuchen.Enabled = CanBookBooking();
        }

        private void EnableDebitorAndKreditor()
        {
            //System.Diagnostics.Debug.WriteLine("EnableDebitorAndKreditor : " + kbPeriodeID.ToString() + "," + edtBuchenSoll.Text + "," + edtBuchenHaben.Text);
            qryKontoart.Fill(_kbPeriodeID, edtBuchenSoll.Text, edtBuchenHaben.Text);

            bool isKreditorEnabled = IsKreditorSpecified();

            EnableDisableTabPage(tpgDebitor, IsDebitorSpecified());
            EnableDisableTabPage(tpgKreditor, isKreditorEnabled);

            if (edtValutaDatum.EditMode != EditModeType.ReadOnly)
            {
                edtValutaDatum.EditMode = isKreditorEnabled ? EditModeType.Required : EditModeType.Normal;
            }
        }

        /// <summary>
        /// Enable or disable tabpage - if tabpage gets disabled, the focus will switch to first tabpage
        /// </summary>
        /// <param name="tpg">The tabpage to handle</param>
        /// <param name="enabled"><c>True</c> if tabpage is enabled, otherwise <c>False</c></param>
        private void EnableDisableTabPage(TabPageEx tpg, bool enabled)
        {
            // enable or disable tabpage
            tpg.Enabled = enabled;

            // check if need to switch tabpage
            if (!enabled && tpg.Parent is KissTabControlEx && ((KissTabControlEx)tpg.Parent).IsTabSelected(tpg))
            {
                // select first tabpage
                ((KissTabControlEx)tpg.Parent).SelectedTabIndex = 0;
            }
        }

        private void EnableKostenart()
        {
            // init flag
            bool isEnabled = false;

            // set flags
            if (string.IsNullOrEmpty(edtBuchenHaben.Text) || string.IsNullOrEmpty(edtBuchenSoll.Text))
            {
                isEnabled = true;
            }
            else if (IsAusgleichsbuchung())
            {
                // see: #3536: in this case, the tpg is enabled, too
                isEnabled = true;

                // prevent any changes in query
                // (see any call of EnableKostenart() for proper right setting > this is kind of a hack here
                //  as it depends on proper order of method calls > see: qryKbBuchung_PositionChanged(...) and SetQueryEditMode(...))
                qryKostenart.CanInsert = false;
                qryKostenart.CanUpdate = false;
                qryKostenart.CanDelete = false;
            }

            // enabled or disable tpg KOA
            EnableDisableTabPage(tpgKostenarten, isEnabled);
        }

        private int GetEinzahlungsscheinCode()
        {
            return Utils.ConvertToInt(qryKbBuchung[DBO.KbBuchung.EinzahlungsscheinCode]);
        }

        private int GetKbBuchungStatusCode()
        {
            return Utils.ConvertToInt(qryKbBuchung[DBO.KbBuchung.KbBuchungStatusCode]);
        }

        /// <summary>
        /// Determine if current entry in qryKbBuchung is Ausgleichsbuchung
        /// </summary>
        /// <returns><c>True</c> if entry is Ausgleichsbuchung, otherwise <c>False</c></returns>
        private bool IsAusgleichsbuchung()
        {
            // check
            if (!qryKostenart.IsEmpty && Utils.ConvertToInt(qryKbBuchung[DBO.KbBuchung.KbBuchungTypCode]) == 4)
            {
                // KbBuchungTyp = 4 >> Ausgleich
                return true;
            }

            // cannot check or no Ausgleich
            return false;
        }

        ///<summary>
        /// Überprüft ob eine Buchung editierbar ist.
        ///</summary>
        private bool IsBuchungReadonly()
        {
            int buchungTypCode = Utils.ConvertToInt(qryKbBuchung[DBO.KbBuchung.KbBuchungTypCode]);

            // --- enable/disable the editable controls
            switch (buchungTypCode)
            {
                case 1: // Budget
                case 3: // Automatisch
                case 4: // Ausgleich
                    // can never edit booking
                    return true;

                case 2: //Manuell
                default:
                    int buchungStatus = Utils.ConvertToInt(qryKbBuchung[DBO.KbBuchung.KbBuchungStatusCode]);

                    if (buchungStatus == 2 ||       // freigegeben
                        buchungStatus == 13 ||      // verbucht
                        buchungStatus == 5)         // fehlerhaft
                    {
                        // can edit booking
                        return false;
                    }

                    // cannot edit booking
                    return true;
            }
        }

        ///<summary>
        /// Ueberprueft ob eines der spezifierten Konten ein Debitorenkonto ist.
        ///</summary>
        private bool IsDebitorSpecified()
        {
            bool isDebitor = false;
            string sollKontoartCodes = Utils.ConvertToString(qryKontoart["SollKontoartCode"]);
            string habenKontoartCodes = Utils.ConvertToString(qryKontoart["HabenKontoartCode"]);

            if (IsKontoart(sollKontoartCodes, Kontoart.Debitor) ||
                IsKontoart(habenKontoartCodes, Kontoart.Debitor))
            {
                System.Diagnostics.Debug.WriteLine("is Debitor account");
                isDebitor = true;
            }

            return isDebitor;
        }

        ///<summary>
        /// Überprüft ob es sich um eine 'Divers'-Buchung handelt. Eine Buchung
        /// ist divers wenn entweder das SOLL- oder das Habenkonto nicht spezifiziert
        /// sind.
        ///</summary>
        private bool IsDivers()
        {
            return (string.IsNullOrEmpty(edtBuchenSoll.Text) || string.IsNullOrEmpty(edtBuchenHaben.Text));
        }

        ///<summary>
        /// Überprüft ob die spezifizierte kontoart in der kontoListe enthalten ist.
        ///</summary>
        private bool IsKontoart(string kontoListe, Kontoart kontoart)
        {
            return ContainsAccount(kontoListe, ((int)kontoart).ToString());
        }

        private bool IsKostenartKontoNr(string kontoNr)
        {
            return (int)DBUtil.ExecuteScalarSQLThrowingException(@"
                IF EXISTS(SELECT TOP 1 1 FROM dbo.BgKostenart WITH (READUNCOMMITTED) WHERE KontoNr = {0})
                BEGIN
                  SELECT 1;
                END
                ELSE
                BEGIN
                  SELECT 0;
                END;"
                , kontoNr) == 1;
        }

        ///<summary>
        /// Ueberprueft ob eines der spezifierten Konten ein Kreditorenkonto ist.
        ///</summary>
        private bool IsKreditorSpecified()
        {
            bool isKreditor = false;
            string sollKontoartCodes = Utils.ConvertToString(qryKontoart["SollKontoartCode"]);
            string habenKontoartCodes = Utils.ConvertToString(qryKontoart["HabenKontoartCode"]);

            if (IsKontoart(sollKontoartCodes, Kontoart.Kreditor) ||
                IsKontoart(habenKontoartCodes, Kontoart.Kreditor))
            {
                System.Diagnostics.Debug.WriteLine("is Kreditor account");
                isKreditor = true;
            }

            return isKreditor;
        }

        private void RefreshStates(bool reloadPendingData)
        {
            try
            {
                int buchungTypCode = Utils.ConvertToInt(qryKbBuchung[DBO.KbBuchung.KbBuchungTypCode]);

                // aktualisiere kostenarten
                UpdateQueryKostenart();

                if (reloadPendingData)
                {
                    // --- setze den BuchungsTypCode
                    qrySollSaldo.Fill(_kbPeriodeID, qryKbBuchung[DBO.KbBuchung.SollKtoNr]);
                    qryHabenSaldo.Fill(_kbPeriodeID, qryKbBuchung[DBO.KbBuchung.HabenKtoNr]);
                }

                // setzte zugehörige BelegNr
                qryZugehoerigeBelegNr.Fill(qryKbBuchung[DBO.KbBuchung.KbBuchungID]);

                CalculateTotal();
                EnableKostenart();

                ctlErfassungMutation.ShowInfo();
            }
            finally
            {
                // update enabled states of controls
                UpdateControlsAndStates();
            }
        }

        private void SetActiveSQLQuery()
        {
            switch (tabBuchen.SelectedTab.Name)
            {
                case "tpgBuchenDetails":
                case "tpgKreditor":
                case "tpgDebitor":
                    this.ActiveSQLQuery = this.qryKbBuchung;
                    kissSearch.SelectParameters = new object[] { _kbPeriodeID };
                    break;

                case "tpgKostenarten":
                    this.ActiveSQLQuery = this.qryKostenart;
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Sets the edit mode for input fields and queries.
        /// </summary>
        private void SetAllEditModes(EditModeType editModeType)
        {
            SetBuchenEditMode(editModeType);
            SetDebitorEditMode(editModeType);
            SetKreditorEditMode(editModeType);
            SetKostenartEditMode(editModeType);

            SetQueryEditMode(editModeType);
            EnableDebitorAndKreditor();
        }

        /// <summary>
        /// Sets the edit mode for input fields.
        /// </summary>
        private void SetBuchenEditMode(EditModeType editModeType)
        {
            edtBuchenText.EditMode = editModeType;
            edtBuchenDatum.EditMode = editModeType;
            edtValutaDatum.EditMode = editModeType;
            edtBuchenBetrag.EditMode = editModeType;

            SetBuchenKontiEditMode(editModeType);
        }

        /// <summary>
        /// Sets the edit mode for input fields.
        /// </summary>
        /// <remarks>
        /// falls es schon kostenarten gibt, darf das 'diverse'-konto nicht verändert
        /// werden
        /// </remarks>
        private void SetBuchenKontiEditMode(EditModeType editModeType)
        {
            edtBuchenSoll.EditMode = editModeType;
            edtBuchenHaben.EditMode = editModeType;

            // --- falls es schon kostenarten gibt, darf das 'diverse'-konto nicht verändert
            //     werden
            if (!IsBuchungReadonly() && Utils.ConvertToInt(qryTotal["Anzahl"]) > 0)
            {
                System.Diagnostics.Debug.WriteLine("SetBuchenKontiEditMode #: " + Utils.ConvertToInt(qryTotal["Anzahl"]).ToString());

                if (string.IsNullOrEmpty(edtBuchenSoll.Text))
                {
                    edtBuchenSoll.EditMode = EditModeType.ReadOnly;
                }

                if (string.IsNullOrEmpty(edtBuchenHaben.Text))
                {
                    edtBuchenHaben.EditMode = EditModeType.ReadOnly;
                }
            }
        }

        /// <summary>
        /// Sets the edit mode for input fields.
        /// </summary>
        private void SetDebitorEditMode(EditModeType editModeType)
        {
            edtDebitor.EditMode = editModeType;
        }

        /// <summary>
        /// Sets the edit mode for input fields.
        /// </summary>
        private void SetKostenartEditMode(EditModeType editModeType)
        {
            if (Utils.ConvertToInt(qryTotal["Anzahl"]) == 0)
            {
                editModeType = EditModeType.ReadOnly;
            }

            SetKostenartEditModeForced(editModeType);
        }

        /// <summary>
        /// Sets the edit mode for input fields.
        /// </summary>
        private void SetKostenartEditModeForced(EditModeType editModeType)
        {
            edtKostenartBetrag.EditMode = editModeType;
            edtKostenart.EditMode = editModeType;
            edtKostenartBuchungstext.EditMode = editModeType;
            edtKostenartKostenstelle.EditMode = editModeType;
            edtKostenartVerwPeriodeVon.EditMode = editModeType;
            edtKostenartVerwPeriodeBis.EditMode = editModeType;
        }

        /// <summary>
        /// Sets the edit mode for input fields.
        /// </summary>
        private void SetKreditorEditMode(EditModeType editModeType)
        {
            edtKreditor.EditMode = editModeType;
            edtKreditorReferenzNummer.EditMode = editModeType;
            edtKreditorMitteilungZeile1.EditMode = editModeType;
            edtKreditorMitteilungZeile2.EditMode = editModeType;
            edtKreditorMitteilungZeile3.EditMode = editModeType;
            edtKreditorMitteilungZeile4.EditMode = editModeType;

            btnUpdateZahlinfo.Enabled = false;

            if (GetKbBuchungStatusCode() == 5) //ZahlauftragFehlerhaft
            {
                btnUpdateZahlinfo.Enabled = true;
            }

            if (!IsBuchungReadonly())
            {
                switch (GetEinzahlungsscheinCode())
                {
                    case 1: // Oranger Einzahlungsschein
                        edtKreditorMitteilungZeile1.EditMode = EditModeType.ReadOnly;
                        edtKreditorMitteilungZeile2.EditMode = EditModeType.ReadOnly;
                        edtKreditorMitteilungZeile3.EditMode = EditModeType.ReadOnly;
                        edtKreditorMitteilungZeile4.EditMode = EditModeType.ReadOnly;
                        break;

                    case 2: // Roter Einzahlungsschein Post
                    case 3: // Bankzahlung Schweiz
                    case 4: // Bankzahlung Ausland
                    case 5: // Roter Einzahlungsschein Bank
                    case 6: // Postmandat
                    default:
                        edtKreditorReferenzNummer.EditMode = EditModeType.ReadOnly;
                        break;
                }
            }
        }

        /// <summary>
        /// Sets the edit mode qryKbBuchung and qryKostenart
        /// </summary>
        private void SetQueryEditMode(EditModeType editModeType)
        {
            // KbBuchung.Delete
            qryKbBuchung.CanDelete = ((editModeType != EditModeType.ReadOnly) && DBUtil.IsEmpty(qryKbBuchung[DBO.KbBuchung.BelegNr]))
                                      || DBUtil.UserHasRight("CtlKbBuchung_BuchungLoeschen");

            // KbBuchungKostenart.Insert/Update/Delete
            qryKostenart.CanDelete = qryKbBuchung.CanDelete;
            qryKostenart.CanInsert = !IsAusgleichsbuchung();
            qryKostenart.CanUpdate = !IsAusgleichsbuchung();
        }

        /// <summary>
        /// Setup controls for multilanguage handling
        /// </summary>
        private void SetupControlsML()
        {
            // setup buttons texts (no text allowed)
            btnVerbuchen.Text = "";
            btnClearSearch.Text = "";

            // setup button icons
            btnVerbuchen.Image = KissImageList.GetSmallImage("BuchungStatus_13_verbucht");

            // Tooltips setzen
            ttpControls = new System.Windows.Forms.ToolTip();
            ttpControls.SetToolTip(btnVerbuchen, KissMsg.GetMLMessage(this.Name, "TtpBtnVerbuchen_v01", "Buchung verbuchen"));
            ttpControls.SetToolTip(btnClearSearch, KissMsg.GetMLMessage(this.Name, "TtpBtnClearSearch", "Suchfelder leeren"));
            ttpControls.SetToolTip(lblBuchenBudgetMonatJahr, KissMsg.GetMLMessage(this.Name, "TtpLblBudgetMMYYYY", "Budget Monat und Jahr"));
        }

        private void ShowDetailsTabControl()
        {
            switch (tabControlSearch.SelectedTabIndex)
            {
                case 0:
                    tabBuchen.Visible = true;
                    break;

                case 1:
                    tabBuchen.Visible = false;
                    break;

                default:
                    break;
            }
        }

        private void ShowInfoIsKostenartKontoNr()
        {
            KissMsg.ShowInfo(this.Name, "IsKostenartKontoNr", "Kontonummer von Kostenarten sollte im Kostenartenregister erfasst werden.");
        }

        /// <summary>
        /// Update enabled states of controls
        /// </summary>
        private void UpdateControlsAndStates()
        {
            // setup edit mode
            UpdateEditModes();

            // handle button Verbuchen
            EnableBtnVerbuchen();
        }

        /// <summary>
        /// Sets the edit mode for input fields.
        /// </summary>
        private void UpdateEditModes()
        {
            qryTotal.Fill(qryKbBuchung[DBO.KbBuchung.KbBuchungID]);

            if (IsBuchungReadonly())
            {
                SetAllEditModes(EditModeType.ReadOnly);
            }
            else
            {
                SetAllEditModes(EditModeType.Normal);

                if (!IsDivers())
                {
                    SetKostenartEditMode(EditModeType.ReadOnly);
                }
            }
        }

        private void UpdateQueries()
        {
            kissSearch.SelectParameters = new object[] { _kbPeriodeID };
            UpdateQueryKostenart();
            qryTotal.Fill(Utils.ConvertToInt(qryKbBuchung[DBO.KbBuchung.KbBuchungID]));
        }

        private void UpdateQueryKostenart()
        {
            qryKostenart.Fill(Utils.ConvertToInt(qryKbBuchung[DBO.KbBuchung.KbBuchungID]));
        }

        /// <summary>
        /// Update row count label
        /// </summary>
        private void UpdateRowCount()
        {
            lblRowCount.Text = string.Format("{0}: {1}", KissMsg.GetMLMessage(this.Name, "AmountRowCount", "Anzahl Buchungen"), qryKbBuchung.Count);
        }

        private void ValidateKontoKostenarten()
        {
            int errorCode = (int)DBUtil.ExecuteScalarSQL("SELECT dbo.fnKbCKKbBuchungIntegrity({0}, {1}, {2}, {3}, {4})",
                qryKbBuchung[DBO.KbBuchung.KbBuchungID],
                13, //neuer KbBuchungStatusCode: verbucht
                qryKbBuchung[DBO.KbBuchung.Betrag],
                qryKbBuchung[DBO.KbBuchung.SollKtoNr],
                qryKbBuchung[DBO.KbBuchung.HabenKtoNr]);

            switch (errorCode)
            {
                case 1:
                    //parameter validation: KbBuchungID is null
                    throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                     "BookingValidation_Parameter",
                                                                     "Die Buchung kann nicht verbucht werden, sie muss zuerst in der Datenbank gespeichert werden."));
                case 2:
                    //SOLL + HABEN have value, and also KbBuchungKostenart exists
                    throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                     "BookingValidation_Kostenarten",
                                                                     "Die Buchung kann nicht verbucht werden.\r\nHat die Buchung sowohl ein Soll- als auch ein Haben-Konto, dürfen keine Kostenarten erfasst werden."));
                case 3:
                    //only SOLL or only HABEN, and no KbBuchungKostenart exists
                    throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                     "BookingValidation_KeineKostenarten",
                                                                     "Die Buchung kann nicht verbucht werden.\r\nHat die Buchung nur ein Soll- oder ein Haben-Konto, müssen Kostenarten erfasst werden."));
                case 4:
                    //neither SOLL, nor HABEN has a value
                    //only SOLL or only HABEN, and no KbBuchungKostenart exists
                    throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                     "BookingValidation_SollOderHaben",
                                                                     "Die Buchung kann nicht verbucht werden.\r\nEine Buchung muss mindestens ein Soll- oder ein Haben-Konto haben."));
                case 5:
                    //Difference between KbBuchung.Betrag and SUM(KbBuchungKostenart.Betrag)
                    throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                     "BookingValidation_BetragDifferenz",
                                                                     "Die Buchung kann nicht verbucht werden.\r\nDie Summe der Beträge der Kostenarten entspricht nicht dem Betrag der Buchung."));
            }
        }

        #endregion

        #endregion
    }
}