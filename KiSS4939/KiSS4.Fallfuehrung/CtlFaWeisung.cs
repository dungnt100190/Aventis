using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.UI;
using KiSS.FA.BL;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Dokument;
using KiSS4.Gui;

namespace KiSS4.Fallfuehrung
{
    /// <summary>
    /// Maske um die Weisungen zu handeln
    /// </summary>
    public class CtlFaWeisung : KissSearchUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        // Context für die Dokumenten
        private const string CONTEXT_DOC = "FaWeisung";

        private const int KUERZUNG_GB_MIN = 0;

        // Feldname von der FaWeisungProtokoll Tabelle
        private const string PRO_AKTION = "Aktion";

        private const string PRO_BEMERKUNG = "Bemerkung";

        private const string PRO_CREATED = "Created";

        private const string PRO_CREATOR = "Creator";

        private const string PRO_FA_WEISUNG_ID = "FaWeisungID";

        private const string PRO_FA_WEISUNG_PROTOKOLL_ID = "FaWeisungProtokollID";

        private const string PRO_MODIFIED = "Modified";

        private const string PRO_MODIFIER = "Modifier";

        private const string PRO_TERMIN = "Termin";

        private const string PRO_VERANTWORTLICH = "Verantwortlich";

        // Feldname von der FaWeisung_BaPerson Tabelle
        private const string PRS_BA_PERSON_ID = "BaPersonID";

        private const string PRS_FA_WEISUNG_BA_PERSON_ID = "FaWeisung_BaPersonID";

        private const string PRS_FA_WEISUNG_ID = "FaWeisungID";

        // Feldname von qryWeisung
        private const string QWEI_CREATOR_NAME = "CreatorName";

        private const string QWEI_KONSEQUENZ_TEXT_ANGEDROHT = "KonsequenzTextAngedroht";

        private const string QWEI_STATUS_TEXT = "StatusText";

        private const string QWEI_VERANTWORTLICH = "Verantwortlich";

        private const string QWEI_WEISUNG_ERFUELLT_LOV = "WeisungErfuelltLOV";

        private const string QWEI_WEISUNG_ERFUELLT_TEXT = "WeisungErfuelltText";

        // Feldname von qryWorkflow
        private const string QWFL_AKTION_TEXT = "AktionText";

        private const string QWFL_NEUER_STATUS_TEXT = "NeuerStatusText";

        // Feldname von der XTask Tabelle
        private const string TSK_BA_PERSON_ID = "BaPersonID";

        private const string TSK_CREATE_DATE = "CreateDate";

        private const string TSK_DONE_DATE = "DoneDate";

        private const string TSK_EXPIRATION_DATE = "ExpirationDate";

        private const string TSK_FA_FALL_ID = "FaFallID";

        private const string TSK_FA_LEISTUNG_ID = "FaLeistungID";

        private const string TSK_JUMP_TO_PATH = "JumpToPath";

        private const string TSK_RECEIVER_ID = "ReceiverID";

        private const string TSK_RESPONSE_TEXT = "ResponseText";

        private const string TSK_SENDER_ID = "SenderID";

        private const string TSK_START_DATE = "StartDate";

        private const string TSK_SUBJECT = "Subject";

        private const string TSK_TASK_DESCRIPTION = "TaskDescription";

        private const string TSK_TASK_RECEIVER_CODE = "TaskReceiverCode";

        private const string TSK_TASK_RESPONSE_CODE = "TaskResponseCode";

        private const string TSK_TASK_SENDER_CODE = "TaskSenderCode";

        private const string TSK_TASK_STATUS_CODE = "TaskStatusCode";

        private const string TSK_TASK_TYPE_CODE = "TaskTypeCode";

        private const string TSK_XTASK_ID = "XTaskID";

        // Feldname von der FaWeisung Tabelle
        private const string WEI_AUFLAGE = "Auflage";

        private const string WEI_AUSGANSLAGE = "Ausganslage";

        private const string WEI_BETREFF = "Betreff";

        private const string WEI_CAN_DELETE = "CanDelete";

        private const string WEI_CREATED = "Created";

        private const string WEI_CREATOR = "Creator";

        private const string WEI_DATUM_VERFUEGUNG = "DatumVerfuegung";

        private const string WEI_FA_LEISTUNG_ID = "FaLeistungID";

        private const string WEI_FA_WEISUNG_ID = "FaWeisungID";

        private const string WEI_KONSEQUENZ_CODE_ANGEDROHT = "KonsequenzCodeAngedroht";

        private const string WEI_KONSEQUENZ_CODE_VERFUEGT = "KonsequenzCodeVerfuegt";

        private const string WEI_KONSEQUENZ_DATUM_BIS = "KonsequenzDatumBis";

        private const string WEI_KONSEQUENZ_DATUM_VON = "KonsequenzDatumVon";

        private const string WEI_KUERZUNG_DATUM_BIS = "KuerzungDatumBis";

        private const string WEI_KUERZUNG_DATUM_VON = "KuerzungDatumVon";

        private const string WEI_KUERZUNG_GB_ANGEDROHT = "KuerzungGBAngedroht";

        private const string WEI_KUERZUNG_GB_VERFUEGT = "KuerzungGBVerfuegt";

        private const string WEI_MODIFIED = "Modified";

        private const string WEI_MODIFIER = "Modifier";

        private const string WEI_STATUS_CODE = "StatusCode";

        private const string WEI_TERMIN_MAHNUNG_1 = "TerminMahnung1";

        private const string WEI_TERMIN_MAHNUNG_2 = "TerminMahnung2";

        private const string WEI_TERMIN_MAHNUNG_3 = "TerminMahnung3";

        private const string WEI_TERMIN_WEISUNG = "TerminWeisung";

        private const string WEI_USER_ID_CREATOR = "UserID_Creator";

        private const string WEI_USER_ID_VERANTWORTLICH_RD = "UserID_VerantwortlichRD";

        private const string WEI_USER_ID_VERANTWORTLICH_SAR = "UserID_VerantwortlichSAR";

        private const string WEI_WEISUNG_ERFUELLT = "WeisungErfuellt";

        private const string WEI_WEISUNG_VERSCHOBEN = "WeisungVerschoben";

        private const string WEI_WEISUNGSART_CODE = "WeisungsartCode";

        private const string WEI_XDOCUMENT_ID_MAHNUNG_1 = "XDocumentID_Mahnung1";

        private const string WEI_XDOCUMENT_ID_MAHNUNG_2 = "XDocumentID_Mahnung2";

        private const string WEI_XDOCUMENT_ID_MAHNUNG_3 = "XDocumentID_Mahnung3";

        private const string WEI_XDOCUMENT_ID_VERFUEGUNG = "XDocumentID_Verfuegung";

        private const string WEI_XDOCUMENT_ID_WEISUNG = "XDocumentID_Weisung";

        private const string WEI_XTASK_ID_SAR = "XTaskID_SAR";

        // Feldname von der FaWeisungWorkflow Tabelle
        private const string WFL_AKTION = "Aktion";

        private const string WFL_AKTION_TID = "AktionTID";

        private const string WFL_FA_WEISUNG_WORKFLOW_ID = "FaWeisungWorkflowID";

        private const string WFL_NAECHSTER_TERMIN_ANPASSEN = "NaechsterTerminAnpassen";

        private const string WFL_NAECHSTER_TERMIN_CODE = "NaechsterTerminCode";

        private const string WFL_NEUER_STATUS_CODE = "NeuerStatusCode";

        private const string WFL_PENDENZ_RD = "PendenzRD";

        private const string WFL_PENDENZ_SAR = "PendenzSAR";

        private const string WFL_SAR_PENDENZ_ANPASSEN = "SARPendenzAnpassen";

        private const string WFL_STATUS_CODE = "StatusCode";

        private const string WFL_TERMIN_MUSS = "TerminMuss";

        private const string WFL_WEISUNG_ERFUELLT = "WeisungErfuellt";

        private const string WFL_XTASK_TEMPLATE_ID_RD = "XTaskTemplateID_RD";

        private const string WFL_XTASK_TEMPLATE_ID_SAR = "XTaskTemplateID_SAR";

        private const string WFL_ZUSTAENDIG_CODE = "ZustaendigCode";

        // Min und Max Werte für Kürzungen
        private readonly int KUERZUNG_GB_MAX = DBUtil.GetConfigInt(@"System\Sozialhilfe\KuerzungMaxProzentsatz", 0);

        #endregion

        #region Private Fields

        private List<FaWeisungStatusFeld> _activeFieldList;
        private bool _aktionAusloesen;
        private int _BaPersonID;
        private List<int> _betroffenepersonenliste;
        private Dictionary<string, Control> _controlList;
        private int _FaFallID;
        private int _FaLeistungID;
        private bool _naechterTerminHasChanged;
        private bool _needSilentPost;
        private SqlQuery _qryEmptyUser;
        private SqlQuery _qryErstellerVerantwortlich;
        private SqlQuery _qryRDVerantwortlich;
        private KissButton btnAktionAusloesen;
        private bool canDelete;
        private bool canInsert;
        private bool canUpdate;
        private DevExpress.XtraGrid.Columns.GridColumn colAktion;
        private DevExpress.XtraGrid.Columns.GridColumn colBearbeiter;
        private DevExpress.XtraGrid.Columns.GridColumn colBemerkung;
        private DevExpress.XtraGrid.Columns.GridColumn colBetreff;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumErstellt;
        private DevExpress.XtraGrid.Columns.GridColumn colKonsequenzAngedroht;
        private DevExpress.XtraGrid.Columns.GridColumn colNaechsteAktion;
        private DevExpress.XtraGrid.Columns.GridColumn colNaechsterTermin;
        private DevExpress.XtraGrid.Columns.GridColumn colProVerantwortlich;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colTerminDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colVerantwortlich;
        private DevExpress.XtraGrid.Columns.GridColumn colWeisungErfuellt;
        private System.ComponentModel.IContainer components;
        private XDokument docDatumVerfuegung;
        private XDokument docTermin;
        private XDokument docTerminMahnung1;
        private XDokument docTerminMahnung2;
        private XDokument docTerminMahnung3;
        private KissLookUpEdit edtAngedrohteKonsequenz;
        private KissTextEdit edtAngedrohteKuerzungGB;
        private KissMemoEdit edtAuflagentext;
        private KissMemoEdit edtAusgangslage;
        private KissMemoEdit edtBemerkung;
        private KissTextEdit edtBetreff;
        private KissTextEdit edtBetreffSearch;
        private KissCheckedLookupEdit edtBetroffenePersonen;
        private KissDateEdit edtCreatedBisSearch;
        private KissDateEdit edtCreatedVonSearch;
        private KissDateEdit edtDatumVerfuegung;
        private KissTextEdit edtErsteller;
        private KissDateEdit edtErstelltAm;
        private KissLookUpEdit edtKonsequentSearch;
        private KissLookUpEdit edtKonsequenz;
        private KissDateEdit edtKonsequenzBis;
        private KissDateEdit edtKonsequenzVon;
        private KissDateEdit edtKuerzungBis;
        private KissTextEdit edtKuerzungGB;
        private KissDateEdit edtKuerzungVon;
        private KissDateEdit edtNaechsterTermin;
        private KissLookUpEdit edtStatusSearch;
        private KissDateEdit edtTermin;
        private KissDateEdit edtTerminBisSearch;
        private KissDateEdit edtTerminMahnung1;
        private KissDateEdit edtTerminMahnung2;
        private KissDateEdit edtTerminMahnung3;
        private KissDateEdit edtTerminVonSearch;
        private KissLookUpEdit edtVerantwortlich;
        private KissButtonEdit edtVerantwortlichSearch;
        private KissLookUpEdit edtWeisungErfuellt;
        private KissLookUpEdit edtWeisungErfuelltSearch;
        private KissLookUpEdit edtWeisungsart;
        private KissLookUpEdit edtWeisungsartSearch;
        private KissGrid grdAktion;
        private KissGrid grdProtokoll;
        private KissGrid grdWeisungen;
        private KissGroupBox grpAktion;
        private KissGroupBox grpKuerzung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAktion;
        private DevExpress.XtraGrid.Views.Grid.GridView grvProtokoll;
        private DevExpress.XtraGrid.Views.Grid.GridView grvWeisungen;
        private KissLookUpEdit kissLookUpEdit_toAllowTabOrder;
        private KissLabel lblAngedrohteKonsequenz;
        private KissLabel lblAngedrohteKuerzungGB;
        private KissLabel lblAuflagentext;
        private KissLabel lblAusgangslage;
        private KissLabel lblBemerkung;
        private KissLabel lblBetreff;
        private KissLabel lblBetreffSearch;
        private KissLabel lblBetroffenePersonen;
        private KissLabel lblCreatedBisSearch;
        private KissLabel lblCreatedVonSearch;
        private KissLabel lblDatumVerfuegung;
        private KissLabel lblDatumVerfuegungDoc;
        private KissLabel lblErsteller;
        private KissLabel lblErstelltAm;
        private KissLabel lblKonsequentSearch;
        private KissLabel lblKonsequenz;
        private KissLabel lblKonsequenzBis;
        private KissLabel lblKonsequenzVon;
        private KissLabel lblKuerzungBis;
        private KissLabel lblKuerzungGB;
        private KissLabel lblKuerzungVon;
        private KissLabel lblNaechsteAktion;
        private KissLabel lblNaechsterTermin;
        private KissLabel lblStatusSearch;
        private KissLabel lblTermin;
        private KissLabel lblTerminBisSearch;
        private KissLabel lblTerminDoc;
        private KissLabel lblTerminMahnung1;
        private KissLabel lblTerminMahnung1Doc;
        private KissLabel lblTerminMahnung2;
        private KissLabel lblTerminMahnung2Doc;
        private KissLabel lblTerminMahnung3;
        private KissLabel lblTerminMahnung3Doc;
        private KissLabel lblTerminVon;
        private KissLabel lblTitel;
        private KissLabel lblVerantwortlichSearch;
        private KissLabel lblVeranwortlich;
        private KissLabel lblWeisungErfuellt;
        private KissLabel lblWeisungErfuelltSearch;
        private KissLabel lblWeisungsart;
        private KissLabel lblWeisungsartSearch;
        private TableLayoutPanel panAktion;
        private Panel panAuflage;
        private Panel panAusgangslage;
        private Panel panBemerkung;
        private Panel panBetroffenePersonen;
        private Panel panDocument;
        private Panel panEdtBetreff;
        private Panel panLblBetreff;
        private Panel panNaechsteAktion;
        private Panel panNaechsterTermin;
        private TableLayoutPanel panWeisung;
        private System.Windows.Forms.PictureBox picTitel;
        private SqlQuery qryBetroffenePerson;
        private SqlQuery qryProtokoll;
        private SqlQuery qryWeisung;
        private SqlQuery qryWorkflow;
        private SqlQuery qryXTask;
        private KissScrollablePanel ScrollPanelWeisung;
        private SharpLibrary.WinControls.TabPageEx tpgProtokoll;
        private SharpLibrary.WinControls.TabPageEx tpgWeisung;

        #endregion

        #endregion

        #region Constructors

        public CtlFaWeisung()
        {
            InitializeComponent();

            this.tabControlSearch.SelectedTabChanged -= new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControlSearch_SelectedTabChanged);
            tabControlSearch.TabPages.Remove(this.tpgSuchen);
            tabControlSearch.TabPages.Add(this.tpgSuchen);
            tabControlSearch.SelectTab(tpgListe);
            this.tabControlSearch.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControlSearch_SelectedTabChanged);

            SetupControlList();
        }

        #endregion

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFaWeisung));
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject46 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject45 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject44 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject43 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject41 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject42 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject40 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject39 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject38 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject37 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdWeisungen = new KiSS4.Gui.KissGrid();
            this.qryWeisung = new KiSS4.DB.SqlQuery(this.components);
            this.grvWeisungen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatumErstellt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetreff = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTerminDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKonsequenzAngedroht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWeisungErfuellt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerantwortlich = new DevExpress.XtraGrid.Columns.GridColumn();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.tpgWeisung = new SharpLibrary.WinControls.TabPageEx();
            this.ScrollPanelWeisung = new KiSS4.Gui.KissScrollablePanel();
            this.panWeisung = new System.Windows.Forms.TableLayoutPanel();
            this.panAuflage = new System.Windows.Forms.Panel();
            this.lblAuflagentext = new KiSS4.Gui.KissLabel();
            this.panAusgangslage = new System.Windows.Forms.Panel();
            this.lblAusgangslage = new KiSS4.Gui.KissLabel();
            this.grpAktion = new KiSS4.Gui.KissGroupBox();
            this.panAktion = new System.Windows.Forms.TableLayoutPanel();
            this.panNaechsterTermin = new System.Windows.Forms.Panel();
            this.btnAktionAusloesen = new KiSS4.Gui.KissButton();
            this.edtVerantwortlich = new KiSS4.Gui.KissLookUpEdit();
            this.lblVeranwortlich = new KiSS4.Gui.KissLabel();
            this.edtNaechsterTermin = new KiSS4.Gui.KissDateEdit();
            this.lblNaechsterTermin = new KiSS4.Gui.KissLabel();
            this.panBemerkung = new System.Windows.Forms.Panel();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.panNaechsteAktion = new System.Windows.Forms.Panel();
            this.grdAktion = new KiSS4.Gui.KissGrid();
            this.qryWorkflow = new KiSS4.DB.SqlQuery(this.components);
            this.grvAktion = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNaechsteAktion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblNaechsteAktion = new KiSS4.Gui.KissLabel();
            this.panDocument = new System.Windows.Forms.Panel();
            this.grpKuerzung = new KiSS4.Gui.KissGroupBox();
            this.lblKuerzungGB = new KiSS4.Gui.KissLabel();
            this.edtKuerzungGB = new KiSS4.Gui.KissTextEdit();
            this.lblKuerzungVon = new KiSS4.Gui.KissLabel();
            this.lblKonsequenzVon = new KiSS4.Gui.KissLabel();
            this.edtKuerzungVon = new KiSS4.Gui.KissDateEdit();
            this.edtKonsequenzVon = new KiSS4.Gui.KissDateEdit();
            this.lblKuerzungBis = new KiSS4.Gui.KissLabel();
            this.edtKuerzungBis = new KiSS4.Gui.KissDateEdit();
            this.lblKonsequenzBis = new KiSS4.Gui.KissLabel();
            this.edtKonsequenz = new KiSS4.Gui.KissLookUpEdit();
            this.edtKonsequenzBis = new KiSS4.Gui.KissDateEdit();
            this.lblKonsequenz = new KiSS4.Gui.KissLabel();
            this.edtWeisungErfuellt = new KiSS4.Gui.KissLookUpEdit();
            this.lblWeisungErfuellt = new KiSS4.Gui.KissLabel();
            this.docTermin = new KiSS4.Dokument.XDokument();
            this.lblDatumVerfuegungDoc = new KiSS4.Gui.KissLabel();
            this.lblAngedrohteKuerzungGB = new KiSS4.Gui.KissLabel();
            this.docDatumVerfuegung = new KiSS4.Dokument.XDokument();
            this.edtAngedrohteKuerzungGB = new KiSS4.Gui.KissTextEdit();
            this.edtDatumVerfuegung = new KiSS4.Gui.KissDateEdit();
            this.lblAngedrohteKonsequenz = new KiSS4.Gui.KissLabel();
            this.lblDatumVerfuegung = new KiSS4.Gui.KissLabel();
            this.edtAngedrohteKonsequenz = new KiSS4.Gui.KissLookUpEdit();
            this.lblTerminMahnung3Doc = new KiSS4.Gui.KissLabel();
            this.lblTermin = new KiSS4.Gui.KissLabel();
            this.docTerminMahnung3 = new KiSS4.Dokument.XDokument();
            this.edtTerminMahnung3 = new KiSS4.Gui.KissDateEdit();
            this.edtTermin = new KiSS4.Gui.KissDateEdit();
            this.lblTerminDoc = new KiSS4.Gui.KissLabel();
            this.lblTerminMahnung3 = new KiSS4.Gui.KissLabel();
            this.lblTerminMahnung1 = new KiSS4.Gui.KissLabel();
            this.lblTerminMahnung2Doc = new KiSS4.Gui.KissLabel();
            this.edtTerminMahnung1 = new KiSS4.Gui.KissDateEdit();
            this.docTerminMahnung2 = new KiSS4.Dokument.XDokument();
            this.docTerminMahnung1 = new KiSS4.Dokument.XDokument();
            this.edtTerminMahnung2 = new KiSS4.Gui.KissDateEdit();
            this.lblTerminMahnung1Doc = new KiSS4.Gui.KissLabel();
            this.lblTerminMahnung2 = new KiSS4.Gui.KissLabel();
            this.edtAuflagentext = new KiSS4.Gui.KissMemoEdit();
            this.edtAusgangslage = new KiSS4.Gui.KissMemoEdit();
            this.panBetroffenePersonen = new System.Windows.Forms.Panel();
            this.lblBetroffenePersonen = new KiSS4.Gui.KissLabel();
            this.edtBetroffenePersonen = new KiSS4.Gui.KissCheckedLookupEdit();
            this.panEdtBetreff = new System.Windows.Forms.Panel();
            this.lblErsteller = new KiSS4.Gui.KissLabel();
            this.edtWeisungsart = new KiSS4.Gui.KissLookUpEdit();
            this.edtBetreff = new KiSS4.Gui.KissTextEdit();
            this.edtErstelltAm = new KiSS4.Gui.KissDateEdit();
            this.edtErsteller = new KiSS4.Gui.KissTextEdit();
            this.panLblBetreff = new System.Windows.Forms.Panel();
            this.lblErstelltAm = new KiSS4.Gui.KissLabel();
            this.lblWeisungsart = new KiSS4.Gui.KissLabel();
            this.lblBetreff = new KiSS4.Gui.KissLabel();
            this.qryProtokoll = new KiSS4.DB.SqlQuery(this.components);
            this.tpgProtokoll = new SharpLibrary.WinControls.TabPageEx();
            this.grdProtokoll = new KiSS4.Gui.KissGrid();
            this.grvProtokoll = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBearbeiter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAktion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBemerkung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNaechsterTermin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProVerantwortlich = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblStatusSearch = new KiSS4.Gui.KissLabel();
            this.edtStatusSearch = new KiSS4.Gui.KissLookUpEdit();
            this.lblTerminVon = new KiSS4.Gui.KissLabel();
            this.edtTerminVonSearch = new KiSS4.Gui.KissDateEdit();
            this.edtTerminBisSearch = new KiSS4.Gui.KissDateEdit();
            this.lblTerminBisSearch = new KiSS4.Gui.KissLabel();
            this.lblVerantwortlichSearch = new KiSS4.Gui.KissLabel();
            this.edtVerantwortlichSearch = new KiSS4.Gui.KissButtonEdit();
            this.qryBetroffenePerson = new KiSS4.DB.SqlQuery(this.components);
            this.qryXTask = new KiSS4.DB.SqlQuery(this.components);
            this.lblCreatedBisSearch = new KiSS4.Gui.KissLabel();
            this.edtCreatedBisSearch = new KiSS4.Gui.KissDateEdit();
            this.edtCreatedVonSearch = new KiSS4.Gui.KissDateEdit();
            this.lblCreatedVonSearch = new KiSS4.Gui.KissLabel();
            this.edtBetreffSearch = new KiSS4.Gui.KissTextEdit();
            this.lblBetreffSearch = new KiSS4.Gui.KissLabel();
            this.lblWeisungsartSearch = new KiSS4.Gui.KissLabel();
            this.edtWeisungsartSearch = new KiSS4.Gui.KissLookUpEdit();
            this.lblKonsequentSearch = new KiSS4.Gui.KissLabel();
            this.edtKonsequentSearch = new KiSS4.Gui.KissLookUpEdit();
            this.edtWeisungErfuelltSearch = new KiSS4.Gui.KissLookUpEdit();
            this.lblWeisungErfuelltSearch = new KiSS4.Gui.KissLabel();
            this.kissLookUpEdit_toAllowTabOrder = new KiSS4.Gui.KissLookUpEdit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdWeisungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryWeisung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvWeisungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            this.tpgWeisung.SuspendLayout();
            this.ScrollPanelWeisung.SuspendLayout();
            this.panWeisung.SuspendLayout();
            this.panAuflage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuflagentext)).BeginInit();
            this.panAusgangslage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusgangslage)).BeginInit();
            this.grpAktion.SuspendLayout();
            this.panAktion.SuspendLayout();
            this.panNaechsterTermin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerantwortlich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerantwortlich.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVeranwortlich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNaechsterTermin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNaechsterTermin)).BeginInit();
            this.panBemerkung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            this.panNaechsteAktion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAktion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryWorkflow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAktion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNaechsteAktion)).BeginInit();
            this.panDocument.SuspendLayout();
            this.grpKuerzung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblKuerzungGB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKuerzungGB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKuerzungVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKonsequenzVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKuerzungVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKonsequenzVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKuerzungBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKuerzungBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKonsequenzBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKonsequenz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKonsequenz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKonsequenzBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKonsequenz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWeisungErfuellt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWeisungErfuellt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWeisungErfuellt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docTermin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVerfuegungDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAngedrohteKuerzungGB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docDatumVerfuegung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAngedrohteKuerzungGB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVerfuegung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAngedrohteKonsequenz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVerfuegung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAngedrohteKonsequenz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAngedrohteKonsequenz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTerminMahnung3Doc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTermin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docTerminMahnung3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTerminMahnung3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTermin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTerminDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTerminMahnung3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTerminMahnung1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTerminMahnung2Doc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTerminMahnung1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docTerminMahnung2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docTerminMahnung1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTerminMahnung2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTerminMahnung1Doc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTerminMahnung2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuflagentext.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusgangslage.Properties)).BeginInit();
            this.panBetroffenePersonen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetroffenePersonen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetroffenePersonen)).BeginInit();
            this.panEdtBetreff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblErsteller)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWeisungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWeisungsart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetreff.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErstelltAm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErsteller.Properties)).BeginInit();
            this.panLblBetreff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblErstelltAm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWeisungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetreff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryProtokoll)).BeginInit();
            this.tpgProtokoll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProtokoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProtokoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatusSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTerminVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTerminVonSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTerminBisSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTerminBisSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerantwortlichSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerantwortlichSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBetroffenePerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXTask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCreatedBisSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCreatedBisSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCreatedVonSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCreatedVonSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetreffSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetreffSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWeisungsartSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWeisungsartSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWeisungsartSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKonsequentSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKonsequentSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKonsequentSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWeisungErfuelltSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWeisungErfuelltSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWeisungErfuelltSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit_toAllowTabOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit_toAllowTabOrder.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // searchTitle
            //
            this.searchTitle.Size = new System.Drawing.Size(919, 24);
            //
            // tabControlSearch
            //
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSearch.Controls.Add(this.tpgWeisung);
            this.tabControlSearch.Controls.Add(this.tpgProtokoll);
            this.tabControlSearch.Location = new System.Drawing.Point(3, 33);
            this.tabControlSearch.Size = new System.Drawing.Size(872, 643);
            this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgWeisung,
            this.tpgProtokoll});
            this.tabControlSearch.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControlSearch_SelectedTabChanged);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgProtokoll, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgWeisung, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgSuchen, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe, 0);
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.grdWeisungen);
            this.tpgListe.Size = new System.Drawing.Size(860, 605);
            this.tpgListe.Title = "Liste";
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.kissLookUpEdit_toAllowTabOrder);
            this.tpgSuchen.Controls.Add(this.edtWeisungErfuelltSearch);
            this.tpgSuchen.Controls.Add(this.lblWeisungErfuelltSearch);
            this.tpgSuchen.Controls.Add(this.lblKonsequentSearch);
            this.tpgSuchen.Controls.Add(this.edtKonsequentSearch);
            this.tpgSuchen.Controls.Add(this.lblWeisungsartSearch);
            this.tpgSuchen.Controls.Add(this.edtWeisungsartSearch);
            this.tpgSuchen.Controls.Add(this.lblBetreffSearch);
            this.tpgSuchen.Controls.Add(this.edtBetreffSearch);
            this.tpgSuchen.Controls.Add(this.lblCreatedBisSearch);
            this.tpgSuchen.Controls.Add(this.edtCreatedBisSearch);
            this.tpgSuchen.Controls.Add(this.edtCreatedVonSearch);
            this.tpgSuchen.Controls.Add(this.lblCreatedVonSearch);
            this.tpgSuchen.Controls.Add(this.edtVerantwortlichSearch);
            this.tpgSuchen.Controls.Add(this.lblVerantwortlichSearch);
            this.tpgSuchen.Controls.Add(this.lblTerminBisSearch);
            this.tpgSuchen.Controls.Add(this.edtTerminBisSearch);
            this.tpgSuchen.Controls.Add(this.edtTerminVonSearch);
            this.tpgSuchen.Controls.Add(this.lblTerminVon);
            this.tpgSuchen.Controls.Add(this.edtStatusSearch);
            this.tpgSuchen.Controls.Add(this.lblStatusSearch);
            this.tpgSuchen.Size = new System.Drawing.Size(860, 605);
            this.tpgSuchen.TabIndex = 0;
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.lblStatusSearch, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtStatusSearch, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblTerminVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtTerminVonSearch, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtTerminBisSearch, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblTerminBisSearch, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblVerantwortlichSearch, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtVerantwortlichSearch, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblCreatedVonSearch, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtCreatedVonSearch, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtCreatedBisSearch, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblCreatedBisSearch, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBetreffSearch, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBetreffSearch, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtWeisungsartSearch, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblWeisungsartSearch, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtKonsequentSearch, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblKonsequentSearch, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblWeisungErfuelltSearch, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtWeisungErfuelltSearch, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLookUpEdit_toAllowTabOrder, 0);
            //
            // grdWeisungen
            //
            this.grdWeisungen.DataSource = this.qryWeisung;
            this.grdWeisungen.Dock = System.Windows.Forms.DockStyle.Fill;
            //
            //
            //
            this.grdWeisungen.EmbeddedNavigator.Name = "";
            this.grdWeisungen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdWeisungen.Location = new System.Drawing.Point(0, 0);
            this.grdWeisungen.MainView = this.grvWeisungen;
            this.grdWeisungen.Name = "grdWeisungen";
            this.grdWeisungen.Size = new System.Drawing.Size(860, 605);
            this.grdWeisungen.TabIndex = 0;
            this.grdWeisungen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvWeisungen});
            this.grdWeisungen.DoubleClick += new System.EventHandler(this.grdWeisungen_DoubleClick);
            //
            // qryWeisung
            //
            this.qryWeisung.HostControl = this;
            this.qryWeisung.SelectStatement = resources.GetString("qryWeisung.SelectStatement");
            this.qryWeisung.TableName = "FaWeisung";
            this.qryWeisung.AfterDelete += new System.EventHandler(this.qryWeisung_AfterDelete);
            this.qryWeisung.AfterInsert += new System.EventHandler(this.qryWeisung_AfterInsert);
            this.qryWeisung.AfterPost += new System.EventHandler(this.qryWeisung_AfterPost);
            this.qryWeisung.BeforePost += new System.EventHandler(this.qryWeisung_BeforePost);
            this.qryWeisung.PositionChanged += new System.EventHandler(this.qryWeisung_PositionChanged);
            //
            // grvWeisungen
            //
            this.grvWeisungen.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvWeisungen.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWeisungen.Appearance.Empty.Options.UseBackColor = true;
            this.grvWeisungen.Appearance.Empty.Options.UseFont = true;
            this.grvWeisungen.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvWeisungen.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWeisungen.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvWeisungen.Appearance.EvenRow.Options.UseFont = true;
            this.grvWeisungen.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvWeisungen.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWeisungen.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvWeisungen.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvWeisungen.Appearance.FocusedCell.Options.UseFont = true;
            this.grvWeisungen.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvWeisungen.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvWeisungen.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWeisungen.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvWeisungen.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvWeisungen.Appearance.FocusedRow.Options.UseFont = true;
            this.grvWeisungen.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvWeisungen.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvWeisungen.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvWeisungen.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvWeisungen.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvWeisungen.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvWeisungen.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvWeisungen.Appearance.GroupRow.Options.UseFont = true;
            this.grvWeisungen.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvWeisungen.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvWeisungen.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvWeisungen.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvWeisungen.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvWeisungen.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvWeisungen.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvWeisungen.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvWeisungen.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWeisungen.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvWeisungen.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvWeisungen.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvWeisungen.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvWeisungen.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvWeisungen.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvWeisungen.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWeisungen.Appearance.OddRow.Options.UseFont = true;
            this.grvWeisungen.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvWeisungen.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWeisungen.Appearance.Row.Options.UseBackColor = true;
            this.grvWeisungen.Appearance.Row.Options.UseFont = true;
            this.grvWeisungen.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvWeisungen.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWeisungen.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvWeisungen.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvWeisungen.Appearance.SelectedRow.Options.UseFont = true;
            this.grvWeisungen.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvWeisungen.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvWeisungen.Appearance.VertLine.Options.UseBackColor = true;
            this.grvWeisungen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvWeisungen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatumErstellt,
            this.colBetreff,
            this.colTerminDatum,
            this.colKonsequenzAngedroht,
            this.colStatus,
            this.colWeisungErfuellt,
            this.colVerantwortlich});
            this.grvWeisungen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvWeisungen.GridControl = this.grdWeisungen;
            this.grvWeisungen.Name = "grvWeisungen";
            this.grvWeisungen.OptionsBehavior.Editable = false;
            this.grvWeisungen.OptionsCustomization.AllowFilter = false;
            this.grvWeisungen.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvWeisungen.OptionsNavigation.AutoFocusNewRow = true;
            this.grvWeisungen.OptionsNavigation.UseTabKey = false;
            this.grvWeisungen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvWeisungen.OptionsView.ShowGroupPanel = false;
            this.grvWeisungen.OptionsView.ShowIndicator = false;
            //
            // colDatumErstellt
            //
            this.colDatumErstellt.Caption = "Erstellt";
            this.colDatumErstellt.Name = "colDatumErstellt";
            this.colDatumErstellt.OptionsColumn.AllowSize = false;
            this.colDatumErstellt.OptionsColumn.FixedWidth = true;
            this.colDatumErstellt.Visible = true;
            this.colDatumErstellt.VisibleIndex = 0;
            //
            // colBetreff
            //
            this.colBetreff.Caption = "Betreff";
            this.colBetreff.Name = "colBetreff";
            this.colBetreff.Visible = true;
            this.colBetreff.VisibleIndex = 1;
            this.colBetreff.Width = 150;
            //
            // colTerminDatum
            //
            this.colTerminDatum.Caption = "Termin";
            this.colTerminDatum.Name = "colTerminDatum";
            this.colTerminDatum.OptionsColumn.AllowSize = false;
            this.colTerminDatum.OptionsColumn.FixedWidth = true;
            this.colTerminDatum.Visible = true;
            this.colTerminDatum.VisibleIndex = 2;
            //
            // colKonsequenzAngedroht
            //
            this.colKonsequenzAngedroht.Caption = "angedrohte Konsequenz";
            this.colKonsequenzAngedroht.Name = "colKonsequenzAngedroht";
            this.colKonsequenzAngedroht.Visible = true;
            this.colKonsequenzAngedroht.VisibleIndex = 3;
            this.colKonsequenzAngedroht.Width = 200;
            //
            // colStatus
            //
            this.colStatus.Caption = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.OptionsColumn.AllowSize = false;
            this.colStatus.OptionsColumn.FixedWidth = true;
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 4;
            this.colStatus.Width = 126;
            //
            // colWeisungErfuellt
            //
            this.colWeisungErfuellt.Caption = "Weisung erfüllt";
            this.colWeisungErfuellt.Name = "colWeisungErfuellt";
            this.colWeisungErfuellt.OptionsColumn.AllowSize = false;
            this.colWeisungErfuellt.OptionsColumn.FixedWidth = true;
            this.colWeisungErfuellt.Visible = true;
            this.colWeisungErfuellt.VisibleIndex = 5;
            this.colWeisungErfuellt.Width = 110;
            //
            // colVerantwortlich
            //
            this.colVerantwortlich.Caption = "Verantwortlich";
            this.colVerantwortlich.Name = "colVerantwortlich";
            this.colVerantwortlich.Visible = true;
            this.colVerantwortlich.VisibleIndex = 6;
            this.colVerantwortlich.Width = 100;
            //
            // picTitel
            //
            this.picTitel.Location = new System.Drawing.Point(6, 11);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 295;
            this.picTitel.TabStop = false;
            //
            // lblTitel
            //
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(26, 11);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(542, 19);
            this.lblTitel.TabIndex = 294;
            this.lblTitel.Text = "Weisungen";
            this.lblTitel.UseCompatibleTextRendering = true;
            //
            // tpgWeisung
            //
            this.tpgWeisung.Controls.Add(this.ScrollPanelWeisung);
            this.tpgWeisung.Location = new System.Drawing.Point(6, 6);
            this.tpgWeisung.Name = "tpgWeisung";
            this.tpgWeisung.Size = new System.Drawing.Size(860, 605);
            this.tpgWeisung.TabIndex = 0;
            this.tpgWeisung.Title = "Weisung";
            //
            // ScrollPanelWeisung
            //
            this.ScrollPanelWeisung.AutoScrollMargin = new System.Drawing.Size(6, 6);
            this.ScrollPanelWeisung.Controls.Add(this.panWeisung);
            this.ScrollPanelWeisung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScrollPanelWeisung.Location = new System.Drawing.Point(0, 0);
            this.ScrollPanelWeisung.Name = "ScrollPanelWeisung";
            this.ScrollPanelWeisung.Size = new System.Drawing.Size(860, 605);
            this.ScrollPanelWeisung.TabIndex = 0;
            //
            // panWeisung
            //
            this.panWeisung.AutoScroll = true;
            this.panWeisung.AutoScrollMinSize = new System.Drawing.Size(720, 520);
            this.panWeisung.ColumnCount = 3;
            this.panWeisung.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 162F));
            this.panWeisung.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panWeisung.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.panWeisung.Controls.Add(this.panAuflage, 0, 2);
            this.panWeisung.Controls.Add(this.panAusgangslage, 0, 1);
            this.panWeisung.Controls.Add(this.grpAktion, 0, 4);
            this.panWeisung.Controls.Add(this.panDocument, 0, 3);
            this.panWeisung.Controls.Add(this.edtAuflagentext, 1, 2);
            this.panWeisung.Controls.Add(this.edtAusgangslage, 1, 1);
            this.panWeisung.Controls.Add(this.panBetroffenePersonen, 2, 0);
            this.panWeisung.Controls.Add(this.panEdtBetreff, 1, 0);
            this.panWeisung.Controls.Add(this.panLblBetreff, 0, 0);
            this.panWeisung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panWeisung.Location = new System.Drawing.Point(0, 0);
            this.panWeisung.Name = "panWeisung";
            this.panWeisung.RowCount = 5;
            this.panWeisung.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.panWeisung.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panWeisung.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panWeisung.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 265F));
            this.panWeisung.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.panWeisung.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panWeisung.Size = new System.Drawing.Size(860, 605);
            this.panWeisung.TabIndex = 1;
            //
            // panAuflage
            //
            this.panAuflage.Controls.Add(this.lblAuflagentext);
            this.panAuflage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panAuflage.Location = new System.Drawing.Point(3, 164);
            this.panAuflage.Name = "panAuflage";
            this.panAuflage.Size = new System.Drawing.Size(156, 72);
            this.panAuflage.TabIndex = 6;
            //
            // lblAuflagentext
            //
            this.lblAuflagentext.Location = new System.Drawing.Point(10, 0);
            this.lblAuflagentext.Name = "lblAuflagentext";
            this.lblAuflagentext.Size = new System.Drawing.Size(100, 24);
            this.lblAuflagentext.TabIndex = 0;
            this.lblAuflagentext.Text = "Auflagentext";
            //
            // panAusgangslage
            //
            this.panAusgangslage.Controls.Add(this.lblAusgangslage);
            this.panAusgangslage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panAusgangslage.Location = new System.Drawing.Point(3, 86);
            this.panAusgangslage.Name = "panAusgangslage";
            this.panAusgangslage.Size = new System.Drawing.Size(156, 72);
            this.panAusgangslage.TabIndex = 4;
            //
            // lblAusgangslage
            //
            this.lblAusgangslage.Location = new System.Drawing.Point(10, 0);
            this.lblAusgangslage.Name = "lblAusgangslage";
            this.lblAusgangslage.Size = new System.Drawing.Size(100, 24);
            this.lblAusgangslage.TabIndex = 0;
            this.lblAusgangslage.Text = "Ausgangslage";
            //
            // grpAktion
            //
            this.panWeisung.SetColumnSpan(this.grpAktion, 3);
            this.grpAktion.Controls.Add(this.panAktion);
            this.grpAktion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAktion.Font = new System.Drawing.Font("Arial", 1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpAktion.Location = new System.Drawing.Point(3, 507);
            this.grpAktion.MinimumSize = new System.Drawing.Size(700, 52);
            this.grpAktion.Name = "grpAktion";
            this.grpAktion.Size = new System.Drawing.Size(854, 95);
            this.grpAktion.TabIndex = 9;
            this.grpAktion.TabStop = false;
            //
            // panAktion
            //
            this.panAktion.ColumnCount = 3;
            this.panAktion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 270F));
            this.panAktion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panAktion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 290F));
            this.panAktion.Controls.Add(this.panNaechsterTermin, 0, 0);
            this.panAktion.Controls.Add(this.panBemerkung, 0, 0);
            this.panAktion.Controls.Add(this.panNaechsteAktion, 0, 0);
            this.panAktion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panAktion.Location = new System.Drawing.Point(3, 5);
            this.panAktion.Name = "panAktion";
            this.panAktion.RowCount = 1;
            this.panAktion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panAktion.Size = new System.Drawing.Size(848, 87);
            this.panAktion.TabIndex = 10;
            //
            // panNaechsterTermin
            //
            this.panNaechsterTermin.Controls.Add(this.btnAktionAusloesen);
            this.panNaechsterTermin.Controls.Add(this.edtVerantwortlich);
            this.panNaechsterTermin.Controls.Add(this.lblVeranwortlich);
            this.panNaechsterTermin.Controls.Add(this.edtNaechsterTermin);
            this.panNaechsterTermin.Controls.Add(this.lblNaechsterTermin);
            this.panNaechsterTermin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panNaechsterTermin.Location = new System.Drawing.Point(561, 3);
            this.panNaechsterTermin.Name = "panNaechsterTermin";
            this.panNaechsterTermin.Size = new System.Drawing.Size(284, 81);
            this.panNaechsterTermin.TabIndex = 13;
            //
            // btnAktionAusloesen
            //
            this.btnAktionAusloesen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAktionAusloesen.Location = new System.Drawing.Point(109, 52);
            this.btnAktionAusloesen.Name = "btnAktionAusloesen";
            this.btnAktionAusloesen.Size = new System.Drawing.Size(168, 24);
            this.btnAktionAusloesen.TabIndex = 4;
            this.btnAktionAusloesen.Text = "Aktion auslösen";
            this.btnAktionAusloesen.UseVisualStyleBackColor = false;
            this.btnAktionAusloesen.Click += new System.EventHandler(this.btnAktionAusloesen_Click);
            //
            // edtVerantwortlich
            //
            this.edtVerantwortlich.Location = new System.Drawing.Point(109, 26);
            this.edtVerantwortlich.Name = "edtVerantwortlich";
            this.edtVerantwortlich.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVerantwortlich.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVerantwortlich.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVerantwortlich.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerantwortlich.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVerantwortlich.Properties.Appearance.Options.UseFont = true;
            this.edtVerantwortlich.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVerantwortlich.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtVerantwortlich.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtVerantwortlich.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtVerantwortlich.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtVerantwortlich.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtVerantwortlich.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVerantwortlich.Properties.NullText = "";
            this.edtVerantwortlich.Properties.ShowFooter = false;
            this.edtVerantwortlich.Properties.ShowHeader = false;
            this.edtVerantwortlich.Size = new System.Drawing.Size(168, 24);
            this.edtVerantwortlich.TabIndex = 3;
            //
            // lblVeranwortlich
            //
            this.lblVeranwortlich.Location = new System.Drawing.Point(3, 26);
            this.lblVeranwortlich.Name = "lblVeranwortlich";
            this.lblVeranwortlich.Size = new System.Drawing.Size(100, 23);
            this.lblVeranwortlich.TabIndex = 2;
            this.lblVeranwortlich.Text = "Verantwortlich";
            //
            // edtNaechsterTermin
            //
            this.edtNaechsterTermin.EditValue = null;
            this.edtNaechsterTermin.Location = new System.Drawing.Point(109, 0);
            this.edtNaechsterTermin.Name = "edtNaechsterTermin";
            this.edtNaechsterTermin.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtNaechsterTermin.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNaechsterTermin.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNaechsterTermin.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNaechsterTermin.Properties.Appearance.Options.UseBackColor = true;
            this.edtNaechsterTermin.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNaechsterTermin.Properties.Appearance.Options.UseFont = true;
            this.edtNaechsterTermin.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtNaechsterTermin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtNaechsterTermin.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtNaechsterTermin.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNaechsterTermin.Properties.ShowToday = false;
            this.edtNaechsterTermin.Size = new System.Drawing.Size(100, 24);
            this.edtNaechsterTermin.TabIndex = 1;
            this.edtNaechsterTermin.EditValueChanged += new System.EventHandler(this.edtNaechsterTermin_EditValueChanged);
            //
            // lblNaechsterTermin
            //
            this.lblNaechsterTermin.Location = new System.Drawing.Point(3, 1);
            this.lblNaechsterTermin.Name = "lblNaechsterTermin";
            this.lblNaechsterTermin.Size = new System.Drawing.Size(100, 23);
            this.lblNaechsterTermin.TabIndex = 0;
            this.lblNaechsterTermin.Text = "Nächster Termin";
            //
            // panBemerkung
            //
            this.panBemerkung.Controls.Add(this.edtBemerkung);
            this.panBemerkung.Controls.Add(this.lblBemerkung);
            this.panBemerkung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panBemerkung.Location = new System.Drawing.Point(273, 3);
            this.panBemerkung.Name = "panBemerkung";
            this.panBemerkung.Size = new System.Drawing.Size(282, 81);
            this.panBemerkung.TabIndex = 12;
            //
            // edtBemerkung
            //
            this.edtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBemerkung.Location = new System.Drawing.Point(72, 0);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(207, 78);
            this.edtBemerkung.TabIndex = 1;
            //
            // lblBemerkung
            //
            this.lblBemerkung.Location = new System.Drawing.Point(3, 0);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(63, 24);
            this.lblBemerkung.TabIndex = 0;
            this.lblBemerkung.Text = "Bemerkung";
            //
            // panNaechsteAktion
            //
            this.panNaechsteAktion.Controls.Add(this.grdAktion);
            this.panNaechsteAktion.Controls.Add(this.lblNaechsteAktion);
            this.panNaechsteAktion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panNaechsteAktion.Location = new System.Drawing.Point(3, 3);
            this.panNaechsteAktion.Name = "panNaechsteAktion";
            this.panNaechsteAktion.Size = new System.Drawing.Size(264, 81);
            this.panNaechsteAktion.TabIndex = 11;
            //
            // grdAktion
            //
            this.grdAktion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAktion.DataSource = this.qryWorkflow;
            //
            //
            //
            this.grdAktion.EmbeddedNavigator.Name = "";
            this.grdAktion.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdAktion.Location = new System.Drawing.Point(97, 4);
            this.grdAktion.MainView = this.grvAktion;
            this.grdAktion.Name = "grdAktion";
            this.grdAktion.Size = new System.Drawing.Size(162, 74);
            this.grdAktion.TabIndex = 1;
            this.grdAktion.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAktion});
            //
            // qryWorkflow
            //
            this.qryWorkflow.HostControl = this;
            this.qryWorkflow.SelectStatement = resources.GetString("qryWorkflow.SelectStatement");
            this.qryWorkflow.TableName = "FaWeisungWorkflow";
            this.qryWorkflow.PositionChanged += new System.EventHandler(this.qryWorkflow_PositionChanged);
            //
            // grvAktion
            //
            this.grvAktion.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvAktion.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAktion.Appearance.Empty.Options.UseBackColor = true;
            this.grvAktion.Appearance.Empty.Options.UseFont = true;
            this.grvAktion.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvAktion.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAktion.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvAktion.Appearance.EvenRow.Options.UseFont = true;
            this.grvAktion.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvAktion.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAktion.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvAktion.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvAktion.Appearance.FocusedCell.Options.UseFont = true;
            this.grvAktion.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvAktion.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvAktion.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAktion.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvAktion.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvAktion.Appearance.FocusedRow.Options.UseFont = true;
            this.grvAktion.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvAktion.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvAktion.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvAktion.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvAktion.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvAktion.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvAktion.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvAktion.Appearance.GroupRow.Options.UseFont = true;
            this.grvAktion.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvAktion.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvAktion.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvAktion.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvAktion.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvAktion.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvAktion.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvAktion.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvAktion.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAktion.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvAktion.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvAktion.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvAktion.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvAktion.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvAktion.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvAktion.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAktion.Appearance.OddRow.Options.UseFont = true;
            this.grvAktion.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvAktion.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAktion.Appearance.Row.Options.UseBackColor = true;
            this.grvAktion.Appearance.Row.Options.UseFont = true;
            this.grvAktion.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvAktion.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAktion.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvAktion.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvAktion.Appearance.SelectedRow.Options.UseFont = true;
            this.grvAktion.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvAktion.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvAktion.Appearance.VertLine.Options.UseBackColor = true;
            this.grvAktion.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvAktion.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNaechsteAktion});
            this.grvAktion.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvAktion.GridControl = this.grdAktion;
            this.grvAktion.Name = "grvAktion";
            this.grvAktion.OptionsBehavior.Editable = false;
            this.grvAktion.OptionsCustomization.AllowFilter = false;
            this.grvAktion.OptionsCustomization.AllowGroup = false;
            this.grvAktion.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvAktion.OptionsNavigation.AutoFocusNewRow = true;
            this.grvAktion.OptionsNavigation.UseTabKey = false;
            this.grvAktion.OptionsPrint.AutoWidth = false;
            this.grvAktion.OptionsPrint.PrintFooter = false;
            this.grvAktion.OptionsPrint.PrintGroupFooter = false;
            this.grvAktion.OptionsPrint.PrintHeader = false;
            this.grvAktion.OptionsPrint.PrintHorzLines = false;
            this.grvAktion.OptionsPrint.PrintVertLines = false;
            this.grvAktion.OptionsView.ShowColumnHeaders = false;
            this.grvAktion.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvAktion.OptionsView.ShowGroupPanel = false;
            this.grvAktion.OptionsView.ShowIndicator = false;
            this.grvAktion.OptionsView.ShowVertLines = false;
            //
            // colNaechsteAktion
            //
            this.colNaechsteAktion.Caption = "Nächste Aktion";
            this.colNaechsteAktion.Name = "colNaechsteAktion";
            this.colNaechsteAktion.Visible = true;
            this.colNaechsteAktion.VisibleIndex = 0;
            //
            // lblNaechsteAktion
            //
            this.lblNaechsteAktion.Location = new System.Drawing.Point(6, 4);
            this.lblNaechsteAktion.Name = "lblNaechsteAktion";
            this.lblNaechsteAktion.Size = new System.Drawing.Size(100, 23);
            this.lblNaechsteAktion.TabIndex = 0;
            this.lblNaechsteAktion.Text = "Nächste Aktion";
            //
            // panDocument
            //
            this.panDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panWeisung.SetColumnSpan(this.panDocument, 3);
            this.panDocument.Controls.Add(this.grpKuerzung);
            this.panDocument.Controls.Add(this.edtWeisungErfuellt);
            this.panDocument.Controls.Add(this.lblWeisungErfuellt);
            this.panDocument.Controls.Add(this.docTermin);
            this.panDocument.Controls.Add(this.lblDatumVerfuegungDoc);
            this.panDocument.Controls.Add(this.lblAngedrohteKuerzungGB);
            this.panDocument.Controls.Add(this.docDatumVerfuegung);
            this.panDocument.Controls.Add(this.edtAngedrohteKuerzungGB);
            this.panDocument.Controls.Add(this.edtDatumVerfuegung);
            this.panDocument.Controls.Add(this.lblAngedrohteKonsequenz);
            this.panDocument.Controls.Add(this.lblDatumVerfuegung);
            this.panDocument.Controls.Add(this.edtAngedrohteKonsequenz);
            this.panDocument.Controls.Add(this.lblTerminMahnung3Doc);
            this.panDocument.Controls.Add(this.lblTermin);
            this.panDocument.Controls.Add(this.docTerminMahnung3);
            this.panDocument.Controls.Add(this.edtTerminMahnung3);
            this.panDocument.Controls.Add(this.edtTermin);
            this.panDocument.Controls.Add(this.lblTerminDoc);
            this.panDocument.Controls.Add(this.lblTerminMahnung3);
            this.panDocument.Controls.Add(this.lblTerminMahnung1);
            this.panDocument.Controls.Add(this.lblTerminMahnung2Doc);
            this.panDocument.Controls.Add(this.edtTerminMahnung1);
            this.panDocument.Controls.Add(this.docTerminMahnung2);
            this.panDocument.Controls.Add(this.docTerminMahnung1);
            this.panDocument.Controls.Add(this.edtTerminMahnung2);
            this.panDocument.Controls.Add(this.lblTerminMahnung1Doc);
            this.panDocument.Controls.Add(this.lblTerminMahnung2);
            this.panDocument.Location = new System.Drawing.Point(3, 242);
            this.panDocument.Name = "panDocument";
            this.panDocument.Size = new System.Drawing.Size(854, 259);
            this.panDocument.TabIndex = 8;
            //
            // grpKuerzung
            //
            this.grpKuerzung.Controls.Add(this.lblKuerzungGB);
            this.grpKuerzung.Controls.Add(this.edtKuerzungGB);
            this.grpKuerzung.Controls.Add(this.lblKuerzungVon);
            this.grpKuerzung.Controls.Add(this.lblKonsequenzVon);
            this.grpKuerzung.Controls.Add(this.edtKuerzungVon);
            this.grpKuerzung.Controls.Add(this.edtKonsequenzVon);
            this.grpKuerzung.Controls.Add(this.lblKuerzungBis);
            this.grpKuerzung.Controls.Add(this.edtKuerzungBis);
            this.grpKuerzung.Controls.Add(this.lblKonsequenzBis);
            this.grpKuerzung.Controls.Add(this.edtKonsequenz);
            this.grpKuerzung.Controls.Add(this.edtKonsequenzBis);
            this.grpKuerzung.Controls.Add(this.lblKonsequenz);
            this.grpKuerzung.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpKuerzung.Location = new System.Drawing.Point(3, 148);
            this.grpKuerzung.Name = "grpKuerzung";
            this.grpKuerzung.Size = new System.Drawing.Size(684, 77);
            this.grpKuerzung.TabIndex = 24;
            this.grpKuerzung.TabStop = false;
            this.grpKuerzung.Text = "Sanktion für Nichteinhalten der Weisung";
            //
            // lblKuerzungGB
            //
            this.lblKuerzungGB.Location = new System.Drawing.Point(7, 18);
            this.lblKuerzungGB.Name = "lblKuerzungGB";
            this.lblKuerzungGB.Size = new System.Drawing.Size(100, 24);
            this.lblKuerzungGB.TabIndex = 0;
            this.lblKuerzungGB.Text = "Kürzung GB %";
            //
            // edtKuerzungGB
            //
            this.edtKuerzungGB.DataSource = this.qryWeisung;
            this.edtKuerzungGB.Location = new System.Drawing.Point(159, 18);
            this.edtKuerzungGB.Name = "edtKuerzungGB";
            this.edtKuerzungGB.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKuerzungGB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKuerzungGB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKuerzungGB.Properties.Appearance.Options.UseBackColor = true;
            this.edtKuerzungGB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKuerzungGB.Properties.Appearance.Options.UseFont = true;
            this.edtKuerzungGB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKuerzungGB.Size = new System.Drawing.Size(100, 24);
            this.edtKuerzungGB.TabIndex = 1;
            //
            // lblKuerzungVon
            //
            this.lblKuerzungVon.Location = new System.Drawing.Point(404, 18);
            this.lblKuerzungVon.Name = "lblKuerzungVon";
            this.lblKuerzungVon.Size = new System.Drawing.Size(27, 24);
            this.lblKuerzungVon.TabIndex = 2;
            this.lblKuerzungVon.Text = "von";
            //
            // lblKonsequenzVon
            //
            this.lblKonsequenzVon.Location = new System.Drawing.Point(404, 44);
            this.lblKonsequenzVon.Name = "lblKonsequenzVon";
            this.lblKonsequenzVon.Size = new System.Drawing.Size(27, 24);
            this.lblKonsequenzVon.TabIndex = 8;
            this.lblKonsequenzVon.Text = "von";
            //
            // edtKuerzungVon
            //
            this.edtKuerzungVon.DataSource = this.qryWeisung;
            this.edtKuerzungVon.EditValue = null;
            this.edtKuerzungVon.Location = new System.Drawing.Point(437, 18);
            this.edtKuerzungVon.Name = "edtKuerzungVon";
            this.edtKuerzungVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKuerzungVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKuerzungVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKuerzungVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKuerzungVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtKuerzungVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKuerzungVon.Properties.Appearance.Options.UseFont = true;
            this.edtKuerzungVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtKuerzungVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtKuerzungVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtKuerzungVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKuerzungVon.Properties.ShowToday = false;
            this.edtKuerzungVon.Size = new System.Drawing.Size(100, 24);
            this.edtKuerzungVon.TabIndex = 3;
            //
            // edtKonsequenzVon
            //
            this.edtKonsequenzVon.DataSource = this.qryWeisung;
            this.edtKonsequenzVon.EditValue = null;
            this.edtKonsequenzVon.Location = new System.Drawing.Point(437, 44);
            this.edtKonsequenzVon.Name = "edtKonsequenzVon";
            this.edtKonsequenzVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKonsequenzVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKonsequenzVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKonsequenzVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKonsequenzVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtKonsequenzVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKonsequenzVon.Properties.Appearance.Options.UseFont = true;
            this.edtKonsequenzVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtKonsequenzVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtKonsequenzVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtKonsequenzVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKonsequenzVon.Properties.ShowToday = false;
            this.edtKonsequenzVon.Size = new System.Drawing.Size(100, 24);
            this.edtKonsequenzVon.TabIndex = 9;
            //
            // lblKuerzungBis
            //
            this.lblKuerzungBis.Location = new System.Drawing.Point(543, 18);
            this.lblKuerzungBis.Name = "lblKuerzungBis";
            this.lblKuerzungBis.Size = new System.Drawing.Size(27, 24);
            this.lblKuerzungBis.TabIndex = 4;
            this.lblKuerzungBis.Text = "bis";
            //
            // edtKuerzungBis
            //
            this.edtKuerzungBis.DataSource = this.qryWeisung;
            this.edtKuerzungBis.EditValue = null;
            this.edtKuerzungBis.Location = new System.Drawing.Point(576, 18);
            this.edtKuerzungBis.Name = "edtKuerzungBis";
            this.edtKuerzungBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKuerzungBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKuerzungBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKuerzungBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKuerzungBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtKuerzungBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKuerzungBis.Properties.Appearance.Options.UseFont = true;
            this.edtKuerzungBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtKuerzungBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtKuerzungBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtKuerzungBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKuerzungBis.Properties.ShowToday = false;
            this.edtKuerzungBis.Size = new System.Drawing.Size(100, 24);
            this.edtKuerzungBis.TabIndex = 5;
            //
            // lblKonsequenzBis
            //
            this.lblKonsequenzBis.Location = new System.Drawing.Point(543, 44);
            this.lblKonsequenzBis.Name = "lblKonsequenzBis";
            this.lblKonsequenzBis.Size = new System.Drawing.Size(27, 24);
            this.lblKonsequenzBis.TabIndex = 10;
            this.lblKonsequenzBis.Text = "bis";
            //
            // edtKonsequenz
            //
            this.edtKonsequenz.AllowNull = false;
            this.edtKonsequenz.DataSource = this.qryWeisung;
            this.edtKonsequenz.Location = new System.Drawing.Point(159, 44);
            this.edtKonsequenz.LOVName = "FaWeisungKonsequenz";
            this.edtKonsequenz.Name = "edtKonsequenz";
            this.edtKonsequenz.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKonsequenz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKonsequenz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKonsequenz.Properties.Appearance.Options.UseBackColor = true;
            this.edtKonsequenz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKonsequenz.Properties.Appearance.Options.UseFont = true;
            this.edtKonsequenz.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKonsequenz.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKonsequenz.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKonsequenz.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKonsequenz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtKonsequenz.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtKonsequenz.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKonsequenz.Properties.NullText = "";
            this.edtKonsequenz.Properties.ShowFooter = false;
            this.edtKonsequenz.Properties.ShowHeader = false;
            this.edtKonsequenz.Size = new System.Drawing.Size(239, 24);
            this.edtKonsequenz.TabIndex = 7;
            //
            // edtKonsequenzBis
            //
            this.edtKonsequenzBis.DataSource = this.qryWeisung;
            this.edtKonsequenzBis.EditValue = null;
            this.edtKonsequenzBis.Location = new System.Drawing.Point(576, 44);
            this.edtKonsequenzBis.Name = "edtKonsequenzBis";
            this.edtKonsequenzBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKonsequenzBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKonsequenzBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKonsequenzBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKonsequenzBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtKonsequenzBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKonsequenzBis.Properties.Appearance.Options.UseFont = true;
            this.edtKonsequenzBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtKonsequenzBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtKonsequenzBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtKonsequenzBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKonsequenzBis.Properties.ShowToday = false;
            this.edtKonsequenzBis.Size = new System.Drawing.Size(100, 24);
            this.edtKonsequenzBis.TabIndex = 11;
            //
            // lblKonsequenz
            //
            this.lblKonsequenz.Location = new System.Drawing.Point(7, 44);
            this.lblKonsequenz.Name = "lblKonsequenz";
            this.lblKonsequenz.Size = new System.Drawing.Size(100, 24);
            this.lblKonsequenz.TabIndex = 6;
            this.lblKonsequenz.Text = "Konsequenz";
            //
            // edtWeisungErfuellt
            //
            this.edtWeisungErfuellt.AllowNull = false;
            this.edtWeisungErfuellt.DataSource = this.qryWeisung;
            this.edtWeisungErfuellt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtWeisungErfuellt.Location = new System.Drawing.Point(162, 231);
            this.edtWeisungErfuellt.LOVName = "JaNein";
            this.edtWeisungErfuellt.Name = "edtWeisungErfuellt";
            this.edtWeisungErfuellt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtWeisungErfuellt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWeisungErfuellt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWeisungErfuellt.Properties.Appearance.Options.UseBackColor = true;
            this.edtWeisungErfuellt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWeisungErfuellt.Properties.Appearance.Options.UseFont = true;
            this.edtWeisungErfuellt.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtWeisungErfuellt.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtWeisungErfuellt.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtWeisungErfuellt.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtWeisungErfuellt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtWeisungErfuellt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtWeisungErfuellt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtWeisungErfuellt.Properties.NullText = "";
            this.edtWeisungErfuellt.Properties.ReadOnly = true;
            this.edtWeisungErfuellt.Properties.ShowFooter = false;
            this.edtWeisungErfuellt.Properties.ShowHeader = false;
            this.edtWeisungErfuellt.Size = new System.Drawing.Size(100, 24);
            this.edtWeisungErfuellt.TabIndex = 26;
            //
            // lblWeisungErfuellt
            //
            this.lblWeisungErfuellt.Location = new System.Drawing.Point(10, 231);
            this.lblWeisungErfuellt.Name = "lblWeisungErfuellt";
            this.lblWeisungErfuellt.Size = new System.Drawing.Size(100, 23);
            this.lblWeisungErfuellt.TabIndex = 25;
            this.lblWeisungErfuellt.Text = "Weisung erfüllt";
            //
            // docTermin
            //
            this.docTermin.Context = null;
            this.docTermin.DataSource = this.qryWeisung;
            this.docTermin.EditValue = "";
            this.docTermin.Location = new System.Drawing.Point(351, 26);
            this.docTermin.Name = "docTermin";
            this.docTermin.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docTermin.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docTermin.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docTermin.Properties.Appearance.Options.UseBackColor = true;
            this.docTermin.Properties.Appearance.Options.UseBorderColor = true;
            this.docTermin.Properties.Appearance.Options.UseFont = true;
            this.docTermin.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.docTermin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docTermin.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docTermin.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docTermin.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docTermin.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12, "Dokument importieren")});
            this.docTermin.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docTermin.Properties.ReadOnly = true;
            this.docTermin.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docTermin.Size = new System.Drawing.Size(121, 24);
            this.docTermin.TabIndex = 7;
            //
            // lblDatumVerfuegungDoc
            //
            this.lblDatumVerfuegungDoc.Location = new System.Drawing.Point(269, 118);
            this.lblDatumVerfuegungDoc.Name = "lblDatumVerfuegungDoc";
            this.lblDatumVerfuegungDoc.Size = new System.Drawing.Size(65, 24);
            this.lblDatumVerfuegungDoc.TabIndex = 22;
            this.lblDatumVerfuegungDoc.Text = "Dokument";
            //
            // lblAngedrohteKuerzungGB
            //
            this.lblAngedrohteKuerzungGB.Location = new System.Drawing.Point(10, 0);
            this.lblAngedrohteKuerzungGB.Name = "lblAngedrohteKuerzungGB";
            this.lblAngedrohteKuerzungGB.Size = new System.Drawing.Size(150, 24);
            this.lblAngedrohteKuerzungGB.TabIndex = 0;
            this.lblAngedrohteKuerzungGB.Text = "angedrohte Kürzung GB %";
            //
            // docDatumVerfuegung
            //
            this.docDatumVerfuegung.Context = null;
            this.docDatumVerfuegung.DataSource = this.qryWeisung;
            this.docDatumVerfuegung.EditValue = "";
            this.docDatumVerfuegung.Location = new System.Drawing.Point(351, 118);
            this.docDatumVerfuegung.Name = "docDatumVerfuegung";
            this.docDatumVerfuegung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docDatumVerfuegung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docDatumVerfuegung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docDatumVerfuegung.Properties.Appearance.Options.UseBackColor = true;
            this.docDatumVerfuegung.Properties.Appearance.Options.UseBorderColor = true;
            this.docDatumVerfuegung.Properties.Appearance.Options.UseFont = true;
            this.docDatumVerfuegung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject13.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject13.Options.UseBackColor = true;
            serializableAppearanceObject14.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject14.Options.UseBackColor = true;
            serializableAppearanceObject15.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject15.Options.UseBackColor = true;
            serializableAppearanceObject16.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject16.Options.UseBackColor = true;
            this.docDatumVerfuegung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docDatumVerfuegung.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docDatumVerfuegung.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject14, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docDatumVerfuegung.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject15, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docDatumVerfuegung.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject16, "Dokument importieren")});
            this.docDatumVerfuegung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docDatumVerfuegung.Properties.ReadOnly = true;
            this.docDatumVerfuegung.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docDatumVerfuegung.Size = new System.Drawing.Size(121, 24);
            this.docDatumVerfuegung.TabIndex = 23;
            //
            // edtAngedrohteKuerzungGB
            //
            this.edtAngedrohteKuerzungGB.DataSource = this.qryWeisung;
            this.edtAngedrohteKuerzungGB.Location = new System.Drawing.Point(162, 0);
            this.edtAngedrohteKuerzungGB.Name = "edtAngedrohteKuerzungGB";
            this.edtAngedrohteKuerzungGB.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAngedrohteKuerzungGB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAngedrohteKuerzungGB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAngedrohteKuerzungGB.Properties.Appearance.Options.UseBackColor = true;
            this.edtAngedrohteKuerzungGB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAngedrohteKuerzungGB.Properties.Appearance.Options.UseFont = true;
            this.edtAngedrohteKuerzungGB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAngedrohteKuerzungGB.Size = new System.Drawing.Size(100, 24);
            this.edtAngedrohteKuerzungGB.TabIndex = 1;
            //
            // edtDatumVerfuegung
            //
            this.edtDatumVerfuegung.DataSource = this.qryWeisung;
            this.edtDatumVerfuegung.EditValue = null;
            this.edtDatumVerfuegung.Location = new System.Drawing.Point(162, 118);
            this.edtDatumVerfuegung.Name = "edtDatumVerfuegung";
            this.edtDatumVerfuegung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVerfuegung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVerfuegung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVerfuegung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVerfuegung.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVerfuegung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVerfuegung.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVerfuegung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject17.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject17.Options.UseBackColor = true;
            this.edtDatumVerfuegung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVerfuegung.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject17)});
            this.edtDatumVerfuegung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVerfuegung.Properties.ShowToday = false;
            this.edtDatumVerfuegung.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVerfuegung.TabIndex = 21;
            this.edtDatumVerfuegung.EditValueChanged += new System.EventHandler(this.edtDatumVerfuegung_EditValueChanged);
            //
            // lblAngedrohteKonsequenz
            //
            this.lblAngedrohteKonsequenz.Location = new System.Drawing.Point(269, 0);
            this.lblAngedrohteKonsequenz.Name = "lblAngedrohteKonsequenz";
            this.lblAngedrohteKonsequenz.Size = new System.Drawing.Size(76, 24);
            this.lblAngedrohteKonsequenz.TabIndex = 2;
            this.lblAngedrohteKonsequenz.Text = "Konsequenz";
            //
            // lblDatumVerfuegung
            //
            this.lblDatumVerfuegung.Location = new System.Drawing.Point(10, 119);
            this.lblDatumVerfuegung.Name = "lblDatumVerfuegung";
            this.lblDatumVerfuegung.Size = new System.Drawing.Size(100, 23);
            this.lblDatumVerfuegung.TabIndex = 20;
            this.lblDatumVerfuegung.Text = "Datum Verfügung";
            //
            // edtAngedrohteKonsequenz
            //
            this.edtAngedrohteKonsequenz.AllowNull = false;
            this.edtAngedrohteKonsequenz.DataSource = this.qryWeisung;
            this.edtAngedrohteKonsequenz.Location = new System.Drawing.Point(351, 0);
            this.edtAngedrohteKonsequenz.LOVName = "FaWeisungKonsequenz";
            this.edtAngedrohteKonsequenz.Name = "edtAngedrohteKonsequenz";
            this.edtAngedrohteKonsequenz.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAngedrohteKonsequenz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAngedrohteKonsequenz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAngedrohteKonsequenz.Properties.Appearance.Options.UseBackColor = true;
            this.edtAngedrohteKonsequenz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAngedrohteKonsequenz.Properties.Appearance.Options.UseFont = true;
            this.edtAngedrohteKonsequenz.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAngedrohteKonsequenz.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAngedrohteKonsequenz.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAngedrohteKonsequenz.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAngedrohteKonsequenz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject18.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject18.Options.UseBackColor = true;
            this.edtAngedrohteKonsequenz.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject18)});
            this.edtAngedrohteKonsequenz.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAngedrohteKonsequenz.Properties.NullText = "";
            this.edtAngedrohteKonsequenz.Properties.ShowFooter = false;
            this.edtAngedrohteKonsequenz.Properties.ShowHeader = false;
            this.edtAngedrohteKonsequenz.Size = new System.Drawing.Size(239, 24);
            this.edtAngedrohteKonsequenz.TabIndex = 3;
            //
            // lblTerminMahnung3Doc
            //
            this.lblTerminMahnung3Doc.Location = new System.Drawing.Point(269, 95);
            this.lblTerminMahnung3Doc.Name = "lblTerminMahnung3Doc";
            this.lblTerminMahnung3Doc.Size = new System.Drawing.Size(65, 24);
            this.lblTerminMahnung3Doc.TabIndex = 18;
            this.lblTerminMahnung3Doc.Text = "Dokument";
            //
            // lblTermin
            //
            this.lblTermin.Location = new System.Drawing.Point(10, 27);
            this.lblTermin.Name = "lblTermin";
            this.lblTermin.Size = new System.Drawing.Size(100, 23);
            this.lblTermin.TabIndex = 4;
            this.lblTermin.Text = "Termin";
            //
            // docTerminMahnung3
            //
            this.docTerminMahnung3.Context = null;
            this.docTerminMahnung3.DataSource = this.qryWeisung;
            this.docTerminMahnung3.EditValue = "";
            this.docTerminMahnung3.Location = new System.Drawing.Point(351, 95);
            this.docTerminMahnung3.Name = "docTerminMahnung3";
            this.docTerminMahnung3.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docTerminMahnung3.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docTerminMahnung3.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docTerminMahnung3.Properties.Appearance.Options.UseBackColor = true;
            this.docTerminMahnung3.Properties.Appearance.Options.UseBorderColor = true;
            this.docTerminMahnung3.Properties.Appearance.Options.UseFont = true;
            this.docTerminMahnung3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject19.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject19.Options.UseBackColor = true;
            serializableAppearanceObject20.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject20.Options.UseBackColor = true;
            serializableAppearanceObject21.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject21.Options.UseBackColor = true;
            serializableAppearanceObject22.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject22.Options.UseBackColor = true;
            this.docTerminMahnung3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docTerminMahnung3.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject19, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docTerminMahnung3.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject20, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docTerminMahnung3.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject21, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docTerminMahnung3.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject22, "Dokument importieren")});
            this.docTerminMahnung3.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docTerminMahnung3.Properties.ReadOnly = true;
            this.docTerminMahnung3.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docTerminMahnung3.Size = new System.Drawing.Size(121, 24);
            this.docTerminMahnung3.TabIndex = 19;
            //
            // edtTerminMahnung3
            //
            this.edtTerminMahnung3.DataSource = this.qryWeisung;
            this.edtTerminMahnung3.EditValue = null;
            this.edtTerminMahnung3.Location = new System.Drawing.Point(162, 95);
            this.edtTerminMahnung3.Name = "edtTerminMahnung3";
            this.edtTerminMahnung3.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtTerminMahnung3.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTerminMahnung3.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTerminMahnung3.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTerminMahnung3.Properties.Appearance.Options.UseBackColor = true;
            this.edtTerminMahnung3.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTerminMahnung3.Properties.Appearance.Options.UseFont = true;
            this.edtTerminMahnung3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject23.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject23.Options.UseBackColor = true;
            this.edtTerminMahnung3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtTerminMahnung3.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject23)});
            this.edtTerminMahnung3.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTerminMahnung3.Properties.ShowToday = false;
            this.edtTerminMahnung3.Size = new System.Drawing.Size(100, 24);
            this.edtTerminMahnung3.TabIndex = 17;
            this.edtTerminMahnung3.EditValueChanged += new System.EventHandler(this.edtTerminMahnung3_EditValueChanged);
            //
            // edtTermin
            //
            this.edtTermin.DataSource = this.qryWeisung;
            this.edtTermin.EditValue = null;
            this.edtTermin.Location = new System.Drawing.Point(162, 26);
            this.edtTermin.Name = "edtTermin";
            this.edtTermin.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtTermin.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTermin.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTermin.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTermin.Properties.Appearance.Options.UseBackColor = true;
            this.edtTermin.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTermin.Properties.Appearance.Options.UseFont = true;
            this.edtTermin.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject24.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject24.Options.UseBackColor = true;
            this.edtTermin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtTermin.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject24)});
            this.edtTermin.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTermin.Properties.ShowToday = false;
            this.edtTermin.Size = new System.Drawing.Size(100, 24);
            this.edtTermin.TabIndex = 5;
            this.edtTermin.EditValueChanged += new System.EventHandler(this.edtTermin_EditValueChanged);
            //
            // lblTerminDoc
            //
            this.lblTerminDoc.Location = new System.Drawing.Point(269, 27);
            this.lblTerminDoc.Name = "lblTerminDoc";
            this.lblTerminDoc.Size = new System.Drawing.Size(65, 24);
            this.lblTerminDoc.TabIndex = 6;
            this.lblTerminDoc.Text = "Dokument";
            //
            // lblTerminMahnung3
            //
            this.lblTerminMahnung3.Location = new System.Drawing.Point(10, 95);
            this.lblTerminMahnung3.Name = "lblTerminMahnung3";
            this.lblTerminMahnung3.Size = new System.Drawing.Size(110, 24);
            this.lblTerminMahnung3.TabIndex = 16;
            this.lblTerminMahnung3.Text = "Termin 3. Mahnung";
            //
            // lblTerminMahnung1
            //
            this.lblTerminMahnung1.Location = new System.Drawing.Point(10, 49);
            this.lblTerminMahnung1.Name = "lblTerminMahnung1";
            this.lblTerminMahnung1.Size = new System.Drawing.Size(110, 24);
            this.lblTerminMahnung1.TabIndex = 8;
            this.lblTerminMahnung1.Text = "Termin 1. Mahnung";
            //
            // lblTerminMahnung2Doc
            //
            this.lblTerminMahnung2Doc.Location = new System.Drawing.Point(269, 72);
            this.lblTerminMahnung2Doc.Name = "lblTerminMahnung2Doc";
            this.lblTerminMahnung2Doc.Size = new System.Drawing.Size(65, 24);
            this.lblTerminMahnung2Doc.TabIndex = 14;
            this.lblTerminMahnung2Doc.Text = "Dokument";
            //
            // edtTerminMahnung1
            //
            this.edtTerminMahnung1.DataSource = this.qryWeisung;
            this.edtTerminMahnung1.EditValue = null;
            this.edtTerminMahnung1.Location = new System.Drawing.Point(162, 49);
            this.edtTerminMahnung1.Name = "edtTerminMahnung1";
            this.edtTerminMahnung1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtTerminMahnung1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTerminMahnung1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTerminMahnung1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTerminMahnung1.Properties.Appearance.Options.UseBackColor = true;
            this.edtTerminMahnung1.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTerminMahnung1.Properties.Appearance.Options.UseFont = true;
            this.edtTerminMahnung1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject25.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject25.Options.UseBackColor = true;
            this.edtTerminMahnung1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtTerminMahnung1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject25)});
            this.edtTerminMahnung1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTerminMahnung1.Properties.ShowToday = false;
            this.edtTerminMahnung1.Size = new System.Drawing.Size(100, 24);
            this.edtTerminMahnung1.TabIndex = 9;
            this.edtTerminMahnung1.EditValueChanged += new System.EventHandler(this.edtTerminMahnung1_EditValueChanged);
            //
            // docTerminMahnung2
            //
            this.docTerminMahnung2.Context = null;
            this.docTerminMahnung2.DataSource = this.qryWeisung;
            this.docTerminMahnung2.EditValue = "";
            this.docTerminMahnung2.Location = new System.Drawing.Point(351, 72);
            this.docTerminMahnung2.Name = "docTerminMahnung2";
            this.docTerminMahnung2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docTerminMahnung2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docTerminMahnung2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docTerminMahnung2.Properties.Appearance.Options.UseBackColor = true;
            this.docTerminMahnung2.Properties.Appearance.Options.UseBorderColor = true;
            this.docTerminMahnung2.Properties.Appearance.Options.UseFont = true;
            this.docTerminMahnung2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject26.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject26.Options.UseBackColor = true;
            serializableAppearanceObject27.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject27.Options.UseBackColor = true;
            serializableAppearanceObject28.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject28.Options.UseBackColor = true;
            serializableAppearanceObject29.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject29.Options.UseBackColor = true;
            this.docTerminMahnung2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docTerminMahnung2.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject26, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docTerminMahnung2.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject27, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docTerminMahnung2.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject28, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docTerminMahnung2.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject29, "Dokument importieren")});
            this.docTerminMahnung2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docTerminMahnung2.Properties.ReadOnly = true;
            this.docTerminMahnung2.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docTerminMahnung2.Size = new System.Drawing.Size(121, 24);
            this.docTerminMahnung2.TabIndex = 15;
            //
            // docTerminMahnung1
            //
            this.docTerminMahnung1.Context = null;
            this.docTerminMahnung1.DataSource = this.qryWeisung;
            this.docTerminMahnung1.EditValue = "";
            this.docTerminMahnung1.Location = new System.Drawing.Point(351, 49);
            this.docTerminMahnung1.Name = "docTerminMahnung1";
            this.docTerminMahnung1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docTerminMahnung1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docTerminMahnung1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docTerminMahnung1.Properties.Appearance.Options.UseBackColor = true;
            this.docTerminMahnung1.Properties.Appearance.Options.UseBorderColor = true;
            this.docTerminMahnung1.Properties.Appearance.Options.UseFont = true;
            this.docTerminMahnung1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject30.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject30.Options.UseBackColor = true;
            serializableAppearanceObject31.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject31.Options.UseBackColor = true;
            serializableAppearanceObject32.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject32.Options.UseBackColor = true;
            serializableAppearanceObject33.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject33.Options.UseBackColor = true;
            this.docTerminMahnung1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docTerminMahnung1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject30, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docTerminMahnung1.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject31, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docTerminMahnung1.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject32, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docTerminMahnung1.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject33, "Dokument importieren")});
            this.docTerminMahnung1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docTerminMahnung1.Properties.ReadOnly = true;
            this.docTerminMahnung1.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docTerminMahnung1.Size = new System.Drawing.Size(121, 24);
            this.docTerminMahnung1.TabIndex = 11;
            //
            // edtTerminMahnung2
            //
            this.edtTerminMahnung2.DataSource = this.qryWeisung;
            this.edtTerminMahnung2.EditValue = null;
            this.edtTerminMahnung2.Location = new System.Drawing.Point(162, 72);
            this.edtTerminMahnung2.Name = "edtTerminMahnung2";
            this.edtTerminMahnung2.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtTerminMahnung2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTerminMahnung2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTerminMahnung2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTerminMahnung2.Properties.Appearance.Options.UseBackColor = true;
            this.edtTerminMahnung2.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTerminMahnung2.Properties.Appearance.Options.UseFont = true;
            this.edtTerminMahnung2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject34.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject34.Options.UseBackColor = true;
            this.edtTerminMahnung2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtTerminMahnung2.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject34)});
            this.edtTerminMahnung2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTerminMahnung2.Properties.ShowToday = false;
            this.edtTerminMahnung2.Size = new System.Drawing.Size(100, 24);
            this.edtTerminMahnung2.TabIndex = 13;
            this.edtTerminMahnung2.EditValueChanged += new System.EventHandler(this.edtTerminMahnung2_EditValueChanged);
            //
            // lblTerminMahnung1Doc
            //
            this.lblTerminMahnung1Doc.Location = new System.Drawing.Point(269, 49);
            this.lblTerminMahnung1Doc.Name = "lblTerminMahnung1Doc";
            this.lblTerminMahnung1Doc.Size = new System.Drawing.Size(65, 24);
            this.lblTerminMahnung1Doc.TabIndex = 10;
            this.lblTerminMahnung1Doc.Text = "Dokument";
            //
            // lblTerminMahnung2
            //
            this.lblTerminMahnung2.Location = new System.Drawing.Point(10, 72);
            this.lblTerminMahnung2.Name = "lblTerminMahnung2";
            this.lblTerminMahnung2.Size = new System.Drawing.Size(110, 24);
            this.lblTerminMahnung2.TabIndex = 12;
            this.lblTerminMahnung2.Text = "Termin 2. Mahnung";
            //
            // edtAuflagentext
            //
            this.edtAuflagentext.DataSource = this.qryWeisung;
            this.edtAuflagentext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtAuflagentext.Location = new System.Drawing.Point(165, 164);
            this.edtAuflagentext.MinimumSize = new System.Drawing.Size(200, 25);
            this.edtAuflagentext.Name = "edtAuflagentext";
            this.edtAuflagentext.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAuflagentext.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAuflagentext.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuflagentext.Properties.Appearance.Options.UseBackColor = true;
            this.edtAuflagentext.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAuflagentext.Properties.Appearance.Options.UseFont = true;
            this.edtAuflagentext.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAuflagentext.Size = new System.Drawing.Size(482, 72);
            this.edtAuflagentext.TabIndex = 7;
            //
            // edtAusgangslage
            //
            this.edtAusgangslage.DataSource = this.qryWeisung;
            this.edtAusgangslage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtAusgangslage.Location = new System.Drawing.Point(165, 86);
            this.edtAusgangslage.MinimumSize = new System.Drawing.Size(200, 25);
            this.edtAusgangslage.Name = "edtAusgangslage";
            this.edtAusgangslage.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAusgangslage.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAusgangslage.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAusgangslage.Properties.Appearance.Options.UseBackColor = true;
            this.edtAusgangslage.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAusgangslage.Properties.Appearance.Options.UseFont = true;
            this.edtAusgangslage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAusgangslage.Size = new System.Drawing.Size(482, 72);
            this.edtAusgangslage.TabIndex = 5;
            //
            // panBetroffenePersonen
            //
            this.panBetroffenePersonen.Controls.Add(this.lblBetroffenePersonen);
            this.panBetroffenePersonen.Controls.Add(this.edtBetroffenePersonen);
            this.panBetroffenePersonen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panBetroffenePersonen.Location = new System.Drawing.Point(653, 3);
            this.panBetroffenePersonen.Name = "panBetroffenePersonen";
            this.panWeisung.SetRowSpan(this.panBetroffenePersonen, 3);
            this.panBetroffenePersonen.Size = new System.Drawing.Size(204, 233);
            this.panBetroffenePersonen.TabIndex = 3;
            //
            // lblBetroffenePersonen
            //
            this.lblBetroffenePersonen.Location = new System.Drawing.Point(0, -1);
            this.lblBetroffenePersonen.Name = "lblBetroffenePersonen";
            this.lblBetroffenePersonen.Size = new System.Drawing.Size(205, 24);
            this.lblBetroffenePersonen.TabIndex = 0;
            this.lblBetroffenePersonen.Text = "Betroffene Personen";
            //
            // edtBetroffenePersonen
            //
            this.edtBetroffenePersonen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBetroffenePersonen.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBetroffenePersonen.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetroffenePersonen.Appearance.Options.UseBackColor = true;
            this.edtBetroffenePersonen.Appearance.Options.UseBorderColor = true;
            this.edtBetroffenePersonen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtBetroffenePersonen.CheckOnClick = true;
            this.edtBetroffenePersonen.Location = new System.Drawing.Point(3, 25);
            this.edtBetroffenePersonen.Name = "edtBetroffenePersonen";
            this.edtBetroffenePersonen.Size = new System.Drawing.Size(198, 205);
            this.edtBetroffenePersonen.TabIndex = 1;
            this.edtBetroffenePersonen.EditValueChanged += new System.EventHandler(this.edtBetroffenepersonen_EditValueChanged);
            //
            // panEdtBetreff
            //
            this.panEdtBetreff.Controls.Add(this.lblErsteller);
            this.panEdtBetreff.Controls.Add(this.edtWeisungsart);
            this.panEdtBetreff.Controls.Add(this.edtBetreff);
            this.panEdtBetreff.Controls.Add(this.edtErstelltAm);
            this.panEdtBetreff.Controls.Add(this.edtErsteller);
            this.panEdtBetreff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panEdtBetreff.Location = new System.Drawing.Point(165, 3);
            this.panEdtBetreff.MinimumSize = new System.Drawing.Size(350, 77);
            this.panEdtBetreff.Name = "panEdtBetreff";
            this.panEdtBetreff.Size = new System.Drawing.Size(482, 77);
            this.panEdtBetreff.TabIndex = 2;
            //
            // lblErsteller
            //
            this.lblErsteller.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblErsteller.Location = new System.Drawing.Point(236, -1);
            this.lblErsteller.Name = "lblErsteller";
            this.lblErsteller.Size = new System.Drawing.Size(49, 24);
            this.lblErsteller.TabIndex = 1;
            this.lblErsteller.Text = "Ersteller";
            //
            // edtWeisungsart
            //
            this.edtWeisungsart.AllowNull = false;
            this.edtWeisungsart.DataSource = this.qryWeisung;
            this.edtWeisungsart.Location = new System.Drawing.Point(0, 52);
            this.edtWeisungsart.LOVName = "FaWeisungsart";
            this.edtWeisungsart.Name = "edtWeisungsart";
            this.edtWeisungsart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWeisungsart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWeisungsart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWeisungsart.Properties.Appearance.Options.UseBackColor = true;
            this.edtWeisungsart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWeisungsart.Properties.Appearance.Options.UseFont = true;
            this.edtWeisungsart.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtWeisungsart.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtWeisungsart.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtWeisungsart.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtWeisungsart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject35.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject35.Options.UseBackColor = true;
            this.edtWeisungsart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject35)});
            this.edtWeisungsart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtWeisungsart.Properties.NullText = "";
            this.edtWeisungsart.Properties.ShowFooter = false;
            this.edtWeisungsart.Properties.ShowHeader = false;
            this.edtWeisungsart.Size = new System.Drawing.Size(100, 24);
            this.edtWeisungsart.TabIndex = 4;
            this.edtWeisungsart.EditValueChanged += new System.EventHandler(this.edtWeisungsart_EditValueChanged);
            //
            // edtBetreff
            //
            this.edtBetreff.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBetreff.DataSource = this.qryWeisung;
            this.edtBetreff.Location = new System.Drawing.Point(0, 26);
            this.edtBetreff.Name = "edtBetreff";
            this.edtBetreff.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBetreff.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetreff.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetreff.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetreff.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetreff.Properties.Appearance.Options.UseFont = true;
            this.edtBetreff.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetreff.Size = new System.Drawing.Size(479, 24);
            this.edtBetreff.TabIndex = 3;
            //
            // edtErstelltAm
            //
            this.edtErstelltAm.DataSource = this.qryWeisung;
            this.edtErstelltAm.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtErstelltAm.EditValue = null;
            this.edtErstelltAm.Location = new System.Drawing.Point(0, 0);
            this.edtErstelltAm.Name = "edtErstelltAm";
            this.edtErstelltAm.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtErstelltAm.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtErstelltAm.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErstelltAm.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErstelltAm.Properties.Appearance.Options.UseBackColor = true;
            this.edtErstelltAm.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErstelltAm.Properties.Appearance.Options.UseFont = true;
            this.edtErstelltAm.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject36.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject36.Options.UseBackColor = true;
            this.edtErstelltAm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtErstelltAm.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject36)});
            this.edtErstelltAm.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErstelltAm.Properties.ReadOnly = true;
            this.edtErstelltAm.Properties.ShowToday = false;
            this.edtErstelltAm.Size = new System.Drawing.Size(100, 24);
            this.edtErstelltAm.TabIndex = 0;
            //
            // edtErsteller
            //
            this.edtErsteller.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtErsteller.DataSource = this.qryWeisung;
            this.edtErsteller.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtErsteller.Location = new System.Drawing.Point(291, 0);
            this.edtErsteller.Name = "edtErsteller";
            this.edtErsteller.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtErsteller.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErsteller.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErsteller.Properties.Appearance.Options.UseBackColor = true;
            this.edtErsteller.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErsteller.Properties.Appearance.Options.UseFont = true;
            this.edtErsteller.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtErsteller.Properties.ReadOnly = true;
            this.edtErsteller.Size = new System.Drawing.Size(188, 24);
            this.edtErsteller.TabIndex = 2;
            //
            // panLblBetreff
            //
            this.panLblBetreff.Controls.Add(this.lblErstelltAm);
            this.panLblBetreff.Controls.Add(this.lblWeisungsart);
            this.panLblBetreff.Controls.Add(this.lblBetreff);
            this.panLblBetreff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panLblBetreff.Location = new System.Drawing.Point(3, 3);
            this.panLblBetreff.Name = "panLblBetreff";
            this.panLblBetreff.Size = new System.Drawing.Size(156, 77);
            this.panLblBetreff.TabIndex = 1;
            //
            // lblErstelltAm
            //
            this.lblErstelltAm.Location = new System.Drawing.Point(10, 0);
            this.lblErstelltAm.Name = "lblErstelltAm";
            this.lblErstelltAm.Size = new System.Drawing.Size(100, 23);
            this.lblErstelltAm.TabIndex = 0;
            this.lblErstelltAm.Text = "Erstellt am";
            //
            // lblWeisungsart
            //
            this.lblWeisungsart.Location = new System.Drawing.Point(10, 52);
            this.lblWeisungsart.Name = "lblWeisungsart";
            this.lblWeisungsart.Size = new System.Drawing.Size(100, 23);
            this.lblWeisungsart.TabIndex = 2;
            this.lblWeisungsart.Text = "Weisungsart";
            //
            // lblBetreff
            //
            this.lblBetreff.Location = new System.Drawing.Point(10, 26);
            this.lblBetreff.Name = "lblBetreff";
            this.lblBetreff.Size = new System.Drawing.Size(100, 23);
            this.lblBetreff.TabIndex = 1;
            this.lblBetreff.Text = "Betreff";
            //
            // qryProtokoll
            //
            this.qryProtokoll.CanInsert = true;
            this.qryProtokoll.CanUpdate = true;
            this.qryProtokoll.HostControl = this;
            this.qryProtokoll.SelectStatement = resources.GetString("qryProtokoll.SelectStatement");
            this.qryProtokoll.TableName = "FaWeisungProtokoll";
            //
            // tpgProtokoll
            //
            this.tpgProtokoll.Controls.Add(this.grdProtokoll);
            this.tpgProtokoll.Location = new System.Drawing.Point(6, 6);
            this.tpgProtokoll.Name = "tpgProtokoll";
            this.tpgProtokoll.Size = new System.Drawing.Size(860, 605);
            this.tpgProtokoll.TabIndex = 3;
            this.tpgProtokoll.Title = "Protokoll";
            //
            // grdProtokoll
            //
            this.grdProtokoll.DataSource = this.qryProtokoll;
            this.grdProtokoll.Dock = System.Windows.Forms.DockStyle.Fill;
            //
            //
            //
            this.grdProtokoll.EmbeddedNavigator.Name = "";
            this.grdProtokoll.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdProtokoll.Location = new System.Drawing.Point(0, 0);
            this.grdProtokoll.MainView = this.grvProtokoll;
            this.grdProtokoll.Name = "grdProtokoll";
            this.grdProtokoll.Size = new System.Drawing.Size(860, 605);
            this.grdProtokoll.TabIndex = 0;
            this.grdProtokoll.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvProtokoll});
            //
            // grvProtokoll
            //
            this.grvProtokoll.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvProtokoll.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProtokoll.Appearance.Empty.Options.UseBackColor = true;
            this.grvProtokoll.Appearance.Empty.Options.UseFont = true;
            this.grvProtokoll.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvProtokoll.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProtokoll.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvProtokoll.Appearance.EvenRow.Options.UseFont = true;
            this.grvProtokoll.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvProtokoll.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProtokoll.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvProtokoll.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvProtokoll.Appearance.FocusedCell.Options.UseFont = true;
            this.grvProtokoll.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvProtokoll.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvProtokoll.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProtokoll.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvProtokoll.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvProtokoll.Appearance.FocusedRow.Options.UseFont = true;
            this.grvProtokoll.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvProtokoll.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvProtokoll.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvProtokoll.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvProtokoll.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvProtokoll.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvProtokoll.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvProtokoll.Appearance.GroupRow.Options.UseFont = true;
            this.grvProtokoll.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvProtokoll.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvProtokoll.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvProtokoll.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvProtokoll.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvProtokoll.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvProtokoll.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvProtokoll.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvProtokoll.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProtokoll.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvProtokoll.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvProtokoll.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvProtokoll.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvProtokoll.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvProtokoll.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvProtokoll.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProtokoll.Appearance.OddRow.Options.UseFont = true;
            this.grvProtokoll.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvProtokoll.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProtokoll.Appearance.Row.Options.UseBackColor = true;
            this.grvProtokoll.Appearance.Row.Options.UseFont = true;
            this.grvProtokoll.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvProtokoll.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProtokoll.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvProtokoll.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvProtokoll.Appearance.SelectedRow.Options.UseFont = true;
            this.grvProtokoll.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvProtokoll.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvProtokoll.Appearance.VertLine.Options.UseBackColor = true;
            this.grvProtokoll.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvProtokoll.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatum,
            this.colBearbeiter,
            this.colAktion,
            this.colBemerkung,
            this.colNaechsterTermin,
            this.colProVerantwortlich});
            this.grvProtokoll.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvProtokoll.GridControl = this.grdProtokoll;
            this.grvProtokoll.Name = "grvProtokoll";
            this.grvProtokoll.OptionsBehavior.Editable = false;
            this.grvProtokoll.OptionsCustomization.AllowFilter = false;
            this.grvProtokoll.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvProtokoll.OptionsNavigation.AutoFocusNewRow = true;
            this.grvProtokoll.OptionsNavigation.UseTabKey = false;
            this.grvProtokoll.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvProtokoll.OptionsView.ShowGroupPanel = false;
            this.grvProtokoll.OptionsView.ShowIndicator = false;
            //
            // colDatum
            //
            this.colDatum.Caption = "Datum";
            this.colDatum.Name = "colDatum";
            this.colDatum.OptionsColumn.AllowSize = false;
            this.colDatum.OptionsColumn.FixedWidth = true;
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 0;
            //
            // colBearbeiter
            //
            this.colBearbeiter.Caption = "Bearbeiter";
            this.colBearbeiter.Name = "colBearbeiter";
            this.colBearbeiter.Visible = true;
            this.colBearbeiter.VisibleIndex = 1;
            this.colBearbeiter.Width = 178;
            //
            // colAktion
            //
            this.colAktion.Caption = "Aktion";
            this.colAktion.Name = "colAktion";
            this.colAktion.Visible = true;
            this.colAktion.VisibleIndex = 2;
            this.colAktion.Width = 178;
            //
            // colBemerkung
            //
            this.colBemerkung.Caption = "Bemerkung";
            this.colBemerkung.Name = "colBemerkung";
            this.colBemerkung.Visible = true;
            this.colBemerkung.VisibleIndex = 3;
            this.colBemerkung.Width = 178;
            //
            // colNaechsterTermin
            //
            this.colNaechsterTermin.Caption = "Nächster Termin";
            this.colNaechsterTermin.Name = "colNaechsterTermin";
            this.colNaechsterTermin.OptionsColumn.AllowSize = false;
            this.colNaechsterTermin.OptionsColumn.FixedWidth = true;
            this.colNaechsterTermin.Visible = true;
            this.colNaechsterTermin.VisibleIndex = 4;
            this.colNaechsterTermin.Width = 105;
            //
            // colProVerantwortlich
            //
            this.colProVerantwortlich.Caption = "Verantwortlich";
            this.colProVerantwortlich.Name = "colProVerantwortlich";
            this.colProVerantwortlich.Visible = true;
            this.colProVerantwortlich.VisibleIndex = 5;
            this.colProVerantwortlich.Width = 150;
            //
            // lblStatusSearch
            //
            this.lblStatusSearch.Location = new System.Drawing.Point(30, 70);
            this.lblStatusSearch.Name = "lblStatusSearch";
            this.lblStatusSearch.Size = new System.Drawing.Size(129, 24);
            this.lblStatusSearch.TabIndex = 5;
            this.lblStatusSearch.Text = "Status";
            //
            // edtStatusSearch
            //
            this.edtStatusSearch.Location = new System.Drawing.Point(165, 70);
            this.edtStatusSearch.LOVName = "FaWeisungStatus";
            this.edtStatusSearch.Name = "edtStatusSearch";
            this.edtStatusSearch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStatusSearch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStatusSearch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStatusSearch.Properties.Appearance.Options.UseBackColor = true;
            this.edtStatusSearch.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStatusSearch.Properties.Appearance.Options.UseFont = true;
            this.edtStatusSearch.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtStatusSearch.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtStatusSearch.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtStatusSearch.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtStatusSearch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject46.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject46.Options.UseBackColor = true;
            this.edtStatusSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject46)});
            this.edtStatusSearch.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStatusSearch.Properties.NullText = "";
            this.edtStatusSearch.Properties.ShowFooter = false;
            this.edtStatusSearch.Properties.ShowHeader = false;
            this.edtStatusSearch.Size = new System.Drawing.Size(233, 24);
            this.edtStatusSearch.TabIndex = 6;
            //
            // lblTerminVon
            //
            this.lblTerminVon.Location = new System.Drawing.Point(30, 101);
            this.lblTerminVon.Name = "lblTerminVon";
            this.lblTerminVon.Size = new System.Drawing.Size(129, 24);
            this.lblTerminVon.TabIndex = 7;
            this.lblTerminVon.Text = "Termin von";
            //
            // edtTerminVonSearch
            //
            this.edtTerminVonSearch.EditValue = null;
            this.edtTerminVonSearch.Location = new System.Drawing.Point(165, 101);
            this.edtTerminVonSearch.Name = "edtTerminVonSearch";
            this.edtTerminVonSearch.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtTerminVonSearch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTerminVonSearch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTerminVonSearch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTerminVonSearch.Properties.Appearance.Options.UseBackColor = true;
            this.edtTerminVonSearch.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTerminVonSearch.Properties.Appearance.Options.UseFont = true;
            this.edtTerminVonSearch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject45.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject45.Options.UseBackColor = true;
            this.edtTerminVonSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtTerminVonSearch.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject45)});
            this.edtTerminVonSearch.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTerminVonSearch.Properties.ShowToday = false;
            this.edtTerminVonSearch.Size = new System.Drawing.Size(100, 24);
            this.edtTerminVonSearch.TabIndex = 8;
            //
            // edtTerminBisSearch
            //
            this.edtTerminBisSearch.EditValue = null;
            this.edtTerminBisSearch.Location = new System.Drawing.Point(298, 101);
            this.edtTerminBisSearch.Name = "edtTerminBisSearch";
            this.edtTerminBisSearch.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtTerminBisSearch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTerminBisSearch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTerminBisSearch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTerminBisSearch.Properties.Appearance.Options.UseBackColor = true;
            this.edtTerminBisSearch.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTerminBisSearch.Properties.Appearance.Options.UseFont = true;
            this.edtTerminBisSearch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject44.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject44.Options.UseBackColor = true;
            this.edtTerminBisSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtTerminBisSearch.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject44)});
            this.edtTerminBisSearch.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTerminBisSearch.Properties.ShowToday = false;
            this.edtTerminBisSearch.Size = new System.Drawing.Size(100, 24);
            this.edtTerminBisSearch.TabIndex = 10;
            //
            // lblTerminBisSearch
            //
            this.lblTerminBisSearch.Location = new System.Drawing.Point(271, 100);
            this.lblTerminBisSearch.Name = "lblTerminBisSearch";
            this.lblTerminBisSearch.Size = new System.Drawing.Size(25, 24);
            this.lblTerminBisSearch.TabIndex = 9;
            this.lblTerminBisSearch.Text = "bis";
            //
            // lblVerantwortlichSearch
            //
            this.lblVerantwortlichSearch.Location = new System.Drawing.Point(30, 132);
            this.lblVerantwortlichSearch.Name = "lblVerantwortlichSearch";
            this.lblVerantwortlichSearch.Size = new System.Drawing.Size(129, 24);
            this.lblVerantwortlichSearch.TabIndex = 11;
            this.lblVerantwortlichSearch.Text = "Verantwortliche Person";
            //
            // edtVerantwortlichSearch
            //
            this.edtVerantwortlichSearch.Location = new System.Drawing.Point(165, 132);
            this.edtVerantwortlichSearch.Name = "edtVerantwortlichSearch";
            this.edtVerantwortlichSearch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVerantwortlichSearch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVerantwortlichSearch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVerantwortlichSearch.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerantwortlichSearch.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVerantwortlichSearch.Properties.Appearance.Options.UseFont = true;
            this.edtVerantwortlichSearch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject43.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject43.Options.UseBackColor = true;
            this.edtVerantwortlichSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject43)});
            this.edtVerantwortlichSearch.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVerantwortlichSearch.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtVerantwortlichSearch.Size = new System.Drawing.Size(233, 24);
            this.edtVerantwortlichSearch.TabIndex = 12;
            this.edtVerantwortlichSearch.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtVerantwortlichSearch_UserModifiedFld);
            //
            // qryBetroffenePerson
            //
            this.qryBetroffenePerson.HostControl = this.tpgSuchen;
            this.qryBetroffenePerson.SelectStatement = "SELECT\r\n  FaWeisung_BaPersonID,\r\n  FaWeisungID,\r\n  BaPersonID\r\nFROM FaWeisung_BaP" +
    "erson\r\nWHERE FaWeisungID = {0}";
            this.qryBetroffenePerson.TableName = "FaWeisung_BaPerson";
            //
            // qryXTask
            //
            this.qryXTask.CanInsert = true;
            this.qryXTask.CanUpdate = true;
            this.qryXTask.HostControl = this;
            this.qryXTask.SelectStatement = resources.GetString("qryXTask.SelectStatement");
            this.qryXTask.TableName = "XTask";
            //
            // lblCreatedBisSearch
            //
            this.lblCreatedBisSearch.Location = new System.Drawing.Point(271, 40);
            this.lblCreatedBisSearch.Name = "lblCreatedBisSearch";
            this.lblCreatedBisSearch.Size = new System.Drawing.Size(25, 24);
            this.lblCreatedBisSearch.TabIndex = 3;
            this.lblCreatedBisSearch.Text = "bis";
            //
            // edtCreatedBisSearch
            //
            this.edtCreatedBisSearch.EditValue = null;
            this.edtCreatedBisSearch.Location = new System.Drawing.Point(298, 40);
            this.edtCreatedBisSearch.Name = "edtCreatedBisSearch";
            this.edtCreatedBisSearch.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtCreatedBisSearch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtCreatedBisSearch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtCreatedBisSearch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtCreatedBisSearch.Properties.Appearance.Options.UseBackColor = true;
            this.edtCreatedBisSearch.Properties.Appearance.Options.UseBorderColor = true;
            this.edtCreatedBisSearch.Properties.Appearance.Options.UseFont = true;
            this.edtCreatedBisSearch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject41.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject41.Options.UseBackColor = true;
            this.edtCreatedBisSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtCreatedBisSearch.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject41)});
            this.edtCreatedBisSearch.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtCreatedBisSearch.Properties.ShowToday = false;
            this.edtCreatedBisSearch.Size = new System.Drawing.Size(100, 24);
            this.edtCreatedBisSearch.TabIndex = 4;
            //
            // edtCreatedVonSearch
            //
            this.edtCreatedVonSearch.EditValue = null;
            this.edtCreatedVonSearch.Location = new System.Drawing.Point(165, 40);
            this.edtCreatedVonSearch.Name = "edtCreatedVonSearch";
            this.edtCreatedVonSearch.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtCreatedVonSearch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtCreatedVonSearch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtCreatedVonSearch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtCreatedVonSearch.Properties.Appearance.Options.UseBackColor = true;
            this.edtCreatedVonSearch.Properties.Appearance.Options.UseBorderColor = true;
            this.edtCreatedVonSearch.Properties.Appearance.Options.UseFont = true;
            this.edtCreatedVonSearch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject42.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject42.Options.UseBackColor = true;
            this.edtCreatedVonSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtCreatedVonSearch.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject42)});
            this.edtCreatedVonSearch.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtCreatedVonSearch.Properties.ShowToday = false;
            this.edtCreatedVonSearch.Size = new System.Drawing.Size(100, 24);
            this.edtCreatedVonSearch.TabIndex = 2;
            //
            // lblCreatedVonSearch
            //
            this.lblCreatedVonSearch.Location = new System.Drawing.Point(30, 40);
            this.lblCreatedVonSearch.Name = "lblCreatedVonSearch";
            this.lblCreatedVonSearch.Size = new System.Drawing.Size(129, 24);
            this.lblCreatedVonSearch.TabIndex = 1;
            this.lblCreatedVonSearch.Text = "Erstelldatum von";
            //
            // edtBetreffSearch
            //
            this.edtBetreffSearch.Location = new System.Drawing.Point(165, 192);
            this.edtBetreffSearch.Name = "edtBetreffSearch";
            this.edtBetreffSearch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBetreffSearch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetreffSearch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetreffSearch.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetreffSearch.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetreffSearch.Properties.Appearance.Options.UseFont = true;
            this.edtBetreffSearch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetreffSearch.Size = new System.Drawing.Size(233, 24);
            this.edtBetreffSearch.TabIndex = 16;
            //
            // lblBetreffSearch
            //
            this.lblBetreffSearch.Location = new System.Drawing.Point(30, 192);
            this.lblBetreffSearch.Name = "lblBetreffSearch";
            this.lblBetreffSearch.Size = new System.Drawing.Size(129, 24);
            this.lblBetreffSearch.TabIndex = 15;
            this.lblBetreffSearch.Text = "Betreff";
            //
            // lblWeisungsartSearch
            //
            this.lblWeisungsartSearch.Location = new System.Drawing.Point(30, 162);
            this.lblWeisungsartSearch.Name = "lblWeisungsartSearch";
            this.lblWeisungsartSearch.Size = new System.Drawing.Size(129, 24);
            this.lblWeisungsartSearch.TabIndex = 13;
            this.lblWeisungsartSearch.Text = "Weisungsart";
            //
            // edtWeisungsartSearch
            //
            this.edtWeisungsartSearch.DataSource = this.qryWeisung;
            this.edtWeisungsartSearch.Location = new System.Drawing.Point(165, 162);
            this.edtWeisungsartSearch.LOVName = "FaWeisungsart";
            this.edtWeisungsartSearch.Name = "edtWeisungsartSearch";
            this.edtWeisungsartSearch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWeisungsartSearch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWeisungsartSearch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWeisungsartSearch.Properties.Appearance.Options.UseBackColor = true;
            this.edtWeisungsartSearch.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWeisungsartSearch.Properties.Appearance.Options.UseFont = true;
            this.edtWeisungsartSearch.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtWeisungsartSearch.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtWeisungsartSearch.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtWeisungsartSearch.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtWeisungsartSearch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject40.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject40.Options.UseBackColor = true;
            this.edtWeisungsartSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject40)});
            this.edtWeisungsartSearch.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtWeisungsartSearch.Properties.NullText = "";
            this.edtWeisungsartSearch.Properties.ShowFooter = false;
            this.edtWeisungsartSearch.Properties.ShowHeader = false;
            this.edtWeisungsartSearch.Size = new System.Drawing.Size(100, 24);
            this.edtWeisungsartSearch.TabIndex = 14;
            //
            // lblKonsequentSearch
            //
            this.lblKonsequentSearch.Location = new System.Drawing.Point(30, 222);
            this.lblKonsequentSearch.Name = "lblKonsequentSearch";
            this.lblKonsequentSearch.Size = new System.Drawing.Size(129, 24);
            this.lblKonsequentSearch.TabIndex = 17;
            this.lblKonsequentSearch.Text = "Konsequenz";
            //
            // edtKonsequentSearch
            //
            this.edtKonsequentSearch.DataSource = this.qryWeisung;
            this.edtKonsequentSearch.Location = new System.Drawing.Point(165, 222);
            this.edtKonsequentSearch.LOVName = "FaWeisungKonsequenz";
            this.edtKonsequentSearch.Name = "edtKonsequentSearch";
            this.edtKonsequentSearch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKonsequentSearch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKonsequentSearch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKonsequentSearch.Properties.Appearance.Options.UseBackColor = true;
            this.edtKonsequentSearch.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKonsequentSearch.Properties.Appearance.Options.UseFont = true;
            this.edtKonsequentSearch.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKonsequentSearch.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKonsequentSearch.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKonsequentSearch.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKonsequentSearch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject39.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject39.Options.UseBackColor = true;
            this.edtKonsequentSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject39)});
            this.edtKonsequentSearch.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKonsequentSearch.Properties.NullText = "";
            this.edtKonsequentSearch.Properties.ShowFooter = false;
            this.edtKonsequentSearch.Properties.ShowHeader = false;
            this.edtKonsequentSearch.Size = new System.Drawing.Size(239, 24);
            this.edtKonsequentSearch.TabIndex = 18;
            //
            // edtWeisungErfuelltSearch
            //
            this.edtWeisungErfuelltSearch.DataSource = this.qryWeisung;
            this.edtWeisungErfuelltSearch.Location = new System.Drawing.Point(165, 252);
            this.edtWeisungErfuelltSearch.LOVName = "JaNein";
            this.edtWeisungErfuelltSearch.Name = "edtWeisungErfuelltSearch";
            this.edtWeisungErfuelltSearch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWeisungErfuelltSearch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWeisungErfuelltSearch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWeisungErfuelltSearch.Properties.Appearance.Options.UseBackColor = true;
            this.edtWeisungErfuelltSearch.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWeisungErfuelltSearch.Properties.Appearance.Options.UseFont = true;
            this.edtWeisungErfuelltSearch.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtWeisungErfuelltSearch.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtWeisungErfuelltSearch.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtWeisungErfuelltSearch.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtWeisungErfuelltSearch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject38.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject38.Options.UseBackColor = true;
            this.edtWeisungErfuelltSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject38)});
            this.edtWeisungErfuelltSearch.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtWeisungErfuelltSearch.Properties.NullText = "";
            this.edtWeisungErfuelltSearch.Properties.ShowFooter = false;
            this.edtWeisungErfuelltSearch.Properties.ShowHeader = false;
            this.edtWeisungErfuelltSearch.Size = new System.Drawing.Size(100, 24);
            this.edtWeisungErfuelltSearch.TabIndex = 20;
            //
            // lblWeisungErfuelltSearch
            //
            this.lblWeisungErfuelltSearch.Location = new System.Drawing.Point(30, 252);
            this.lblWeisungErfuelltSearch.Name = "lblWeisungErfuelltSearch";
            this.lblWeisungErfuelltSearch.Size = new System.Drawing.Size(100, 23);
            this.lblWeisungErfuelltSearch.TabIndex = 19;
            this.lblWeisungErfuelltSearch.Text = "Weisung erfüllt";
            //
            // kissLookUpEdit_toAllowTabOrder
            //
            this.kissLookUpEdit_toAllowTabOrder.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissLookUpEdit_toAllowTabOrder.Enabled = false;
            this.kissLookUpEdit_toAllowTabOrder.Location = new System.Drawing.Point(738, 8);
            this.kissLookUpEdit_toAllowTabOrder.Name = "kissLookUpEdit_toAllowTabOrder";
            this.kissLookUpEdit_toAllowTabOrder.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissLookUpEdit_toAllowTabOrder.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissLookUpEdit_toAllowTabOrder.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissLookUpEdit_toAllowTabOrder.Properties.Appearance.Options.UseBackColor = true;
            this.kissLookUpEdit_toAllowTabOrder.Properties.Appearance.Options.UseBorderColor = true;
            this.kissLookUpEdit_toAllowTabOrder.Properties.Appearance.Options.UseFont = true;
            this.kissLookUpEdit_toAllowTabOrder.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissLookUpEdit_toAllowTabOrder.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissLookUpEdit_toAllowTabOrder.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.kissLookUpEdit_toAllowTabOrder.Properties.AppearanceDropDown.Options.UseFont = true;
            this.kissLookUpEdit_toAllowTabOrder.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject37.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject37.Options.UseBackColor = true;
            this.kissLookUpEdit_toAllowTabOrder.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject37)});
            this.kissLookUpEdit_toAllowTabOrder.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.kissLookUpEdit_toAllowTabOrder.Properties.NullText = "";
            this.kissLookUpEdit_toAllowTabOrder.Properties.ReadOnly = true;
            this.kissLookUpEdit_toAllowTabOrder.Properties.ShowFooter = false;
            this.kissLookUpEdit_toAllowTabOrder.Properties.ShowHeader = false;
            this.kissLookUpEdit_toAllowTabOrder.Size = new System.Drawing.Size(100, 24);
            this.kissLookUpEdit_toAllowTabOrder.TabIndex = 22;
            this.kissLookUpEdit_toAllowTabOrder.Visible = false;
            //
            // CtlFaWeisung
            //
            this.ActiveSQLQuery = this.qryWeisung;
            this.Controls.Add(this.picTitel);
            this.Controls.Add(this.lblTitel);
            this.Name = "CtlFaWeisung";
            this.Size = new System.Drawing.Size(878, 679);
            this.Load += new System.EventHandler(this.CtlFaWeisung_Load);
            this.Controls.SetChildIndex(this.lblTitel, 0);
            this.Controls.SetChildIndex(this.picTitel, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdWeisungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryWeisung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvWeisungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            this.tpgWeisung.ResumeLayout(false);
            this.ScrollPanelWeisung.ResumeLayout(false);
            this.panWeisung.ResumeLayout(false);
            this.panAuflage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblAuflagentext)).EndInit();
            this.panAusgangslage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblAusgangslage)).EndInit();
            this.grpAktion.ResumeLayout(false);
            this.panAktion.ResumeLayout(false);
            this.panNaechsterTermin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtVerantwortlich.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerantwortlich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVeranwortlich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNaechsterTermin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNaechsterTermin)).EndInit();
            this.panBemerkung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            this.panNaechsteAktion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAktion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryWorkflow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAktion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNaechsteAktion)).EndInit();
            this.panDocument.ResumeLayout(false);
            this.grpKuerzung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblKuerzungGB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKuerzungGB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKuerzungVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKonsequenzVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKuerzungVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKonsequenzVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKuerzungBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKuerzungBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKonsequenzBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKonsequenz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKonsequenz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKonsequenzBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKonsequenz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWeisungErfuellt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWeisungErfuellt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWeisungErfuellt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docTermin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVerfuegungDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAngedrohteKuerzungGB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docDatumVerfuegung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAngedrohteKuerzungGB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVerfuegung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAngedrohteKonsequenz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVerfuegung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAngedrohteKonsequenz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAngedrohteKonsequenz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTerminMahnung3Doc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTermin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docTerminMahnung3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTerminMahnung3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTermin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTerminDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTerminMahnung3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTerminMahnung1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTerminMahnung2Doc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTerminMahnung1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docTerminMahnung2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docTerminMahnung1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTerminMahnung2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTerminMahnung1Doc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTerminMahnung2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuflagentext.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusgangslage.Properties)).EndInit();
            this.panBetroffenePersonen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblBetroffenePersonen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetroffenePersonen)).EndInit();
            this.panEdtBetreff.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblErsteller)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWeisungsart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWeisungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetreff.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErstelltAm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErsteller.Properties)).EndInit();
            this.panLblBetreff.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblErstelltAm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWeisungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetreff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryProtokoll)).EndInit();
            this.tpgProtokoll.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdProtokoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProtokoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatusSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTerminVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTerminVonSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTerminBisSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTerminBisSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerantwortlichSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerantwortlichSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBetroffenePerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXTask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCreatedBisSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCreatedBisSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCreatedVonSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCreatedVonSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetreffSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetreffSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWeisungsartSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWeisungsartSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWeisungsartSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKonsequentSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKonsequentSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKonsequentSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWeisungErfuelltSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWeisungErfuelltSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWeisungErfuelltSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit_toAllowTabOrder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLookUpEdit_toAllowTabOrder)).EndInit();
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

        #region EventHandlers

        private void btnAktionAusloesen_Click(object sender, EventArgs e)
        {
            qryWeisung.RowModified = true;
            _aktionAusloesen = true;
            qryWeisung.Post();
        }

        private void CtlFaWeisung_Load(object sender, EventArgs e)
        {
            this.kissSearch.SelectParameters = new object[] { _FaLeistungID, Session.User.LanguageCode };

            qryWeisung.CanInsert = true;
            qryWeisung.CanDelete = true;
            qryWeisung.CanUpdate = true;
            qryWeisung.ApplyUserRights();
            canInsert = qryWeisung.CanInsert;
            canUpdate = qryWeisung.CanUpdate;
            canDelete = qryWeisung.CanDelete;

            SetupDataMembers();
            SetupFieldNames();
            SetupContext();
            SetupTags();

            SetDropDownSQL();

            LoadBetroffenepersonen();

            _naechterTerminHasChanged = false;

            qryWeisung.Fill(_FaLeistungID, Session.User.LanguageCode);
            qryProtokoll.Fill(qryWeisung[WEI_FA_WEISUNG_ID]);
        }

        private void edtBetroffenepersonen_EditValueChanged(object sender, EventArgs e)
        {
            qryWeisung.RowModified = true;
        }

        private void edtDatumVerfuegung_EditValueChanged(object sender, EventArgs e)
        {
            GetNaechterTermin();
        }

        private void edtNaechsterTermin_EditValueChanged(object sender, EventArgs e)
        {
            _naechterTerminHasChanged = true;
        }

        private void edtTermin_EditValueChanged(object sender, EventArgs e)
        {
            GetNaechterTermin();
        }

        private void edtTerminMahnung1_EditValueChanged(object sender, EventArgs e)
        {
            GetNaechterTermin();
        }

        private void edtTerminMahnung2_EditValueChanged(object sender, EventArgs e)
        {
            GetNaechterTermin();
        }

        private void edtTerminMahnung3_EditValueChanged(object sender, EventArgs e)
        {
            GetNaechterTermin();
        }

        private void edtVerantwortlichSearch_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            if (string.IsNullOrEmpty(edtVerantwortlichSearch.Text))
            {
                edtVerantwortlichSearch.Text = "*";
            }
            e.Cancel = !dlg.MitarbeiterSuchen(edtVerantwortlichSearch.Text, e.ButtonClicked);
        }

        private void edtWeisungsart_EditValueChanged(object sender, EventArgs e)
        {
            if (!qryWeisung.IsEmpty && !qryWeisung.IsInserting && !qryWeisung.IsFilling)
            {
                SetEditMode((FaWeisung.Weisungsart)edtWeisungsart.EditValue);
            }
        }

        private void grdWeisungen_DoubleClick(object sender, EventArgs e)
        {
            tabControlSearch.SelectTab(tpgWeisung);
        }

        private void qryWeisung_AfterDelete(object sender, EventArgs e)
        {
            if (qryWeisung.IsEmpty)
            {
                qryWeisung.Fill(_FaLeistungID);
                qryProtokoll.Fill(qryWeisung[WEI_FA_WEISUNG_ID]);
                qryWorkflow.DataTable.Rows.Clear();
            }
        }

        private void qryWeisung_AfterInsert(object sender, EventArgs e)
        {
            qryWeisung[WEI_FA_LEISTUNG_ID] = _FaLeistungID;
            qryWeisung[WEI_USER_ID_CREATOR] = Session.User.UserID;
            qryWeisung[QWEI_CREATOR_NAME] = Session.User.LastName + (Session.User.FirstName == "" ? "" : ", ") + Session.User.FirstName;
            qryWeisung[QWEI_VERANTWORTLICH] = Session.User.LastName + (Session.User.FirstName == "" ? "" : ", ") + Session.User.FirstName;
            qryWeisung[WEI_STATUS_CODE] = LOVsGenerated.FaWeisungStatus.WeisungBearbeiten;
            qryWeisung[QWEI_STATUS_TEXT] = qryWorkflow[QWFL_NEUER_STATUS_TEXT];
            qryWeisung[WEI_WEISUNG_ERFUELLT] = false;
            qryWeisung[QWEI_WEISUNG_ERFUELLT_LOV] = 0;
            qryWeisung[WEI_WEISUNGSART_CODE] = FaWeisung.Weisungsart.Schriftlich;
            qryWeisung[WEI_KUERZUNG_GB_ANGEDROHT] = KUERZUNG_GB_MIN;
            qryWeisung[WEI_KUERZUNG_GB_VERFUEGT] = KUERZUNG_GB_MIN;
            qryWeisung[WEI_USER_ID_VERANTWORTLICH_SAR] = Session.User.UserID;
            qryWeisung.SetCreator();
            qryWeisung.SetModifierModified();

            qryWeisung.RowModified = true;
            qryProtokoll.Fill(qryWeisung[WEI_FA_WEISUNG_ID]);

            tabControlSearch.SelectTab(tpgWeisung);
            edtBetreff.Focus();
        }

        private void qryWeisung_AfterPost(object sender, EventArgs e)
        {
            // HACK: Post is called from the XDocument, save the query but don't go further in the workflow.
            if (!qryWeisung.IsSilentPostingFromXDocument)
            {
                if (_needSilentPost)
                {
                    qryWeisung.Post();
                    _needSilentPost = false;
                }
                else
                {
                    if (qryProtokoll.IsEmpty)
                    {
                        ProtokollierenInit();
                    }

                    UpdateBetroffenepersonen();

                    if (_aktionAusloesen)
                    {
                        _naechterTerminHasChanged = false;
                        _aktionAusloesen = false;

                        Protokollieren();
                        qryWorkflow.Fill(qryWeisung[WEI_STATUS_CODE], Session.User.LanguageCode);
                        ResetField();
                        ActivateFields((LOVsGenerated.FaWeisungStatus)qryWeisung[WEI_STATUS_CODE], (FaWeisung.Weisungsart)qryWeisung[WEI_WEISUNGSART_CODE]);

                        if ((LOVsGenerated.FaWeisungStatus)qryWeisung[WEI_STATUS_CODE] != LOVsGenerated.FaWeisungStatus.Fertig)
                        {
                            GetNaechterTermin();
                        }
                    }
                }
            }
        }

        private void qryWeisung_BeforePost(object sender, EventArgs e)
        {
            // HACK: Post is called from the XDokument.OnClickButton method.
            _needSilentPost = NeedSilentPost();

            // Mussfeldern prüfen wenn die aktion ausgelöst wird
            if (_aktionAusloesen)
            {
                try
                {
                    CheckNotNullField();
                }
                catch (Exception ex)
                {
                    _aktionAusloesen = false;
                    throw ex;
                }
            }
            else
            {
                // sonst nur Mussfelder von der DB prüfen
                DBUtil.CheckNotNullField(edtBetreff, lblBetreff.Text);
                DBUtil.CheckNotNullField(edtWeisungsart, lblWeisungsart.Text);
            }

            //Constraint-Verletzung?
            CheckValue();

            if (!qryWeisung.IsSilentPostingFromXDocument && !_needSilentPost)
            {
                if (_aktionAusloesen)
                {
                    SetQueryFieldBeforePost();
                    SetPendenz();
                }
                UpdateListe();
            }
            edtBetreff.Focus();
        }

        private void qryWeisung_PositionChanged(object sender, EventArgs e)
        {
            _naechterTerminHasChanged = false;
            if (qryWeisung.IsEmpty)
            {
                tabControlSearch.SelectTab(tpgListe);
                qryWorkflow.Fill(DBNull.Value, Session.User.LanguageCode);
                qryBetroffenePerson.Fill(DBNull.Value);
                SetFieldsReadOnly();
                ResetField();
                ResetVerantwortlich();
                btnAktionAusloesen.Enabled = false;
            }
            else
            {
                ResetField();
                ResetVerantwortlich();
                qryWeisung.CanDelete = canDelete && (bool)qryWeisung[WEI_CAN_DELETE];
                qryWeisung.CanUpdate = canUpdate && !(bool)qryWeisung[WEI_WEISUNG_ERFUELLT];
                ActivateFields((LOVsGenerated.FaWeisungStatus)qryWeisung[WEI_STATUS_CODE], (FaWeisung.Weisungsart)qryWeisung[WEI_WEISUNGSART_CODE]);
                qryWorkflow.Fill(qryWeisung[WEI_STATUS_CODE], Session.User.LanguageCode);
                SelectBetroffenepersonen();
                if (qryWeisung[WEI_KONSEQUENZ_CODE_ANGEDROHT] == null)
                {
                    edtKonsequenz.ItemIndex = 0;
                }
                if (qryWeisung[WEI_KONSEQUENZ_CODE_VERFUEGT] == null)
                {
                    edtAngedrohteKonsequenz.ItemIndex = 0;
                }
            }
        }

        private void qryWorkflow_PositionChanged(object sender, EventArgs e)
        {
            if (!qryWeisung.IsEmpty)
            {
                GetNaechterTermin();
                LoadVerantwortlichDropDown();
            }
        }

        private void tabControlSearch_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            if (tabControlSearch.SelectedTab == tpgSuchen)
            {
                CanEdit(false);
                edtCreatedVonSearch.Focus();
            }
            else if (tabControlSearch.SelectedTab == tpgProtokoll)
            {
                qryProtokoll.Fill(qryWeisung[WEI_FA_WEISUNG_ID]);
                CanEdit(false);
            }
            else
            {
                CanEdit(true);
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Get specific value for given context
        /// </summary>
        /// <param name="fieldName">The name of the context used for getting value</param>
        /// <returns>The value fo given context</returns>
        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "BAPERSONID":
                case "ADRESSATID":
                    return _BaPersonID;

                case "FALEISTUNGID":
                    return _FaLeistungID;

                case "FAWEISUNGID":
                    return qryWeisung[WEI_FA_WEISUNG_ID];

                case "OWNERUSERID":
                    return Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                        SELECT UserID
                        FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                        WHERE FaLeistungID = {0}", _FaLeistungID));
            }

            return base.GetContextValue(fieldName);
        }

        public void Init(string titleName, Image titleImage, int faLeistungID, int faFallID, int baPersonID)
        {
            this.lblTitel.Text = titleName;
            this.picTitel.Image = titleImage;
            _FaLeistungID = faLeistungID;
            _FaFallID = faFallID;
            _BaPersonID = baPersonID;
        }

        public override bool ReceiveMessage(System.Collections.Specialized.HybridDictionary parameters)
        {
            bool baseResult = base.ReceiveMessage(parameters);
            if ((int?)qryWeisung[WEI_FA_WEISUNG_ID] == (int?)parameters["FaWeisungID"])
            {
                tabControlSearch.SelectTab(tpgWeisung);
            }
            else
            {
                qryWeisung.Position = 0;
                tabControlSearch.SelectTab(tpgListe);
            }
            return baseResult;
        }

        #endregion

        #region Private Methods

        private void ActivateFields(LOVsGenerated.FaWeisungStatus status, FaWeisung.Weisungsart weisungsart)
        {
            SetActiveFields(status);

            SetFieldsReadOnly();

            foreach (FaWeisungStatusFeld field in _activeFieldList)
            {
                string fieldName = field.Feldname;
                if (_controlList.ContainsKey(fieldName))
                {
                    Control ctl = _controlList[fieldName];
                    if (typeof(IKissEditable).IsAssignableFrom(ctl.GetType()))
                    {
                        if (!canUpdate)
                        {
                            ((IKissEditable)ctl).EditMode = EditModeType.ReadOnly;
                        }
                        else
                        {
                            if (field.MussFeld)
                            {
                                ((IKissEditable)ctl).EditMode = EditModeType.Required;
                            }
                            else
                            {
                                ((IKissEditable)ctl).EditMode = EditModeType.Normal;
                            }
                        }
                    }
                    else
                    {
                        throw new KissErrorException("The control is not a IKissEditable object.");
                    }
                }
            }

            SetEditMode(weisungsart);

            if (status != LOVsGenerated.FaWeisungStatus.Fertig)
            {
                if (!canUpdate)
                {
                    edtBemerkung.EditMode = EditModeType.ReadOnly;
                    edtVerantwortlich.EditMode = EditModeType.ReadOnly;
                    edtNaechsterTermin.EditMode = EditModeType.ReadOnly;
                    btnAktionAusloesen.Enabled = false;
                }
                else
                {
                    edtBemerkung.EditMode = EditModeType.Normal;
                    edtVerantwortlich.EditMode = EditModeType.Required;
                    btnAktionAusloesen.Enabled = true;
                }
            }
            else
            {
                btnAktionAusloesen.Enabled = false;
            }
        }

        private void CanEdit(bool canEdit)
        {
            //Operationen nur zulassen, wenn der Benutzer das Recht dazu hat
            bool canInsert = this.canInsert && canEdit;
            bool canUpdate = this.canUpdate && canEdit;
            bool canDelete = this.canDelete && canEdit;

            qryWeisung.CanInsert = canInsert;
            qryWeisung.CanUpdate = canUpdate;
            if (qryWeisung.IsEmpty)
            {
                qryWeisung.CanDelete = canDelete;
            }
            else
            {
                qryWeisung.CanDelete = canDelete && (bool)qryWeisung[WEI_CAN_DELETE];
            }

            qryProtokoll.CanInsert = canInsert;
            qryProtokoll.CanUpdate = canUpdate;
            qryProtokoll.CanDelete = false;

            qryBetroffenePerson.CanInsert = canInsert;
            qryBetroffenePerson.CanUpdate = canUpdate;
            qryBetroffenePerson.CanDelete = canDelete && qryWeisung.CanDelete;

            grdAktion.Enabled = canUpdate;
            btnAktionAusloesen.Enabled = canUpdate;
        }

        private void CheckNotNullField()
        {
            DBUtil.CheckNotNullField(edtBetreff, lblBetreff.Text);
            DBUtil.CheckNotNullField(edtWeisungsart, lblWeisungsart.Text);

            // CheckNotNullField for Controls that have their EditMode == Required
            foreach (Control ctl in _controlList.Values)
            {
                if (typeof(IKissEditable).IsAssignableFrom(ctl.GetType()) && typeof(IKissBindableEdit).IsAssignableFrom(ctl.GetType()))
                {
                    if (((IKissEditable)ctl).EditMode == EditModeType.Required)
                    {
                        // HACK: don't check the XDokument field if it's required and the document needs to post the query
                        if (!(qryWeisung.IsSilentPostingFromXDocument && typeof(XDokument).IsAssignableFrom(ctl.GetType())))
                        {
                            string text = ctl.Tag == null ? ctl.Name : ctl.Tag.ToString();
                            DBUtil.CheckNotNullField(((IKissBindableEdit)ctl), text);
                        }
                    }
                }
                else
                {
                    throw new KissErrorException("The control is not a IKissEditable object.");
                }
            }
        }

        private void CheckValue()
        {
            if (edtKuerzungGB.EditMode != EditModeType.ReadOnly)
            {
                CheckValueBetween(edtKuerzungGB, KUERZUNG_GB_MIN, KUERZUNG_GB_MAX);
            }
            if (edtAngedrohteKuerzungGB.EditMode != EditModeType.ReadOnly)
            {
                CheckValueBetween(edtAngedrohteKuerzungGB, KUERZUNG_GB_MIN, KUERZUNG_GB_MAX);
            }
        }

        private void CheckValueBetween(BaseEdit control, int min, int max)
        {
            if (control.EditValue == null || control.EditValue == DBNull.Value)
            {
                control.EditValue = min;
            }
            else if ((int)control.EditValue < min || (int)control.EditValue > max)
            {
                control.Focus();
                throw new KissInfoException(KissMsg.GetMLMessage("CtlFaWeisung", "ValueRangeBetween", "Der Wert muss zwischen {0} und {1} sein.", min, max));
            }
        }

        private SqlQuery GetAllUserDropDownSQL()
        {
            return DBUtil.OpenSQL(@"
                SELECT
                  UserID      = USR.UserID,
                  NameVorname = USR.NameVorname
                FROM vwUser USR
                WHERE USR.IsLocked  = 0
                ORDER BY USR.NameVorname");
        }

        private void GetNaechterTermin()
        {
            if (qryWorkflow[WFL_NAECHSTER_TERMIN_CODE] == null)
            {
                return;
            }
            this.edtNaechsterTermin.EditValueChanged -= new System.EventHandler(this.edtNaechsterTermin_EditValueChanged);

            if (!_naechterTerminHasChanged)
            {
                switch ((FaWeisung.Termin)qryWorkflow[WFL_NAECHSTER_TERMIN_CODE])
                {
                    case FaWeisung.Termin.Keine:
                        if ((bool)qryWorkflow[WFL_TERMIN_MUSS])
                        {
                            edtNaechsterTermin.EditValue = DateTime.Today.AddDays(DBUtil.GetConfigInt(@"System\Fallfuehrung\Weisung\AnzahlTageInVoraus", 0));
                        }
                        else
                        {
                            edtNaechsterTermin.EditValue = "";
                        }
                        break;

                    case FaWeisung.Termin.Weisung:
                        edtNaechsterTermin.EditValue = edtTermin.EditValue;
                        break;

                    case FaWeisung.Termin.Mahnung1:
                        edtNaechsterTermin.EditValue = edtTerminMahnung1.EditValue;
                        break;

                    case FaWeisung.Termin.Mahnung2:
                        edtNaechsterTermin.EditValue = edtTerminMahnung2.EditValue;
                        break;

                    case FaWeisung.Termin.Mahnung3:
                        edtNaechsterTermin.EditValue = edtTerminMahnung3.EditValue;
                        break;

                    case FaWeisung.Termin.Verfuegung:
                        edtNaechsterTermin.EditValue = edtDatumVerfuegung.EditValue;
                        break;
                }
            }
            if ((bool)qryWorkflow[WFL_TERMIN_MUSS])
            {
                edtNaechsterTermin.EditMode = EditModeType.Required;
            }
            else
            {
                edtNaechsterTermin.EditMode = EditModeType.Normal;
            }

            this.edtNaechsterTermin.EditValueChanged += new System.EventHandler(this.edtNaechsterTermin_EditValueChanged);
        }

        private void LoadBetroffenepersonen()
        {
            edtBetroffenePersonen.LookupSQL = string.Format(@"
                DECLARE @FaLeistungID INT
                SET @FaLeistungID = {0}

                SELECT
                  Code   = PRS.BaPersonID,
                  [Text] = PRS.NameVorname
                FROM dbo.FaLeistung      LEI
                  LEFT JOIN dbo.vwPerson PRS ON PRS.BaPersonID = LEI.BaPersonID
                WHERE FaLeistungID = @FaLeistungID

                UNION

                SELECT
                  Code   = CASE WHEN LEI.BaPersonID = REL.BaPersonID_1 THEN P2.BaPersonID
                             ELSE P1.BaPersonID
                           END,
                  [Text] = CASE WHEN LEI.BaPersonID = REL.BaPersonID_1 THEN P2.NameVorname
                             ELSE P1.NameVorname
                           END
                FROM dbo.FaLeistung               LEI
                  LEFT JOIN dbo.BaPerson_Relation REL ON REL.BaPersonID_1 = LEI.BaPersonID OR REL.BaPersonID_2 = LEI.BaPersonID
                  LEFT JOIN dbo.vwPerson          P1  ON P1.BaPersonID = REL.BaPersonID_1
                  LEFT JOIN dbo.vwPerson          P2  ON P2.BaPersonID = REL.BaPersonID_2
                WHERE LEI.FaLeistungID = @FaLeistungID"
                , _FaLeistungID);
        }

        private void LoadVerantwortlichDropDown()
        {
            if (qryWorkflow.IsEmpty)
            {
                LoadVerantwortlichDropDown(FaWeisung.Zustaendig.Niemand);
            }
            else
            {
                LoadVerantwortlichDropDown((FaWeisung.Zustaendig)qryWorkflow[WFL_ZUSTAENDIG_CODE]);
            }
        }

        private void LoadVerantwortlichDropDown(FaWeisung.Zustaendig zustaendig)
        {
            switch (zustaendig)
            {
                case FaWeisung.Zustaendig.Niemand:
                    LoadVerantwortlichDropDown(_qryErstellerVerantwortlich, qryWeisung[WEI_USER_ID_VERANTWORTLICH_SAR] as int?, (int)qryWeisung[WEI_USER_ID_CREATOR]);
                    break;

                case FaWeisung.Zustaendig.Ersteller:
                    LoadVerantwortlichDropDown(_qryErstellerVerantwortlich, qryWeisung[WEI_USER_ID_VERANTWORTLICH_SAR] as int?, (int)qryWeisung[WEI_USER_ID_CREATOR]);
                    break;

                case FaWeisung.Zustaendig.RD:
                    LoadVerantwortlichDropDown(_qryRDVerantwortlich, qryWeisung[WEI_USER_ID_VERANTWORTLICH_RD] as int?, Session.User.RechtsdienstUserID);
                    break;
            }
        }

        private void LoadVerantwortlichDropDown(SqlQuery qry, int? userID, int defaultUserID)
        {
            edtVerantwortlich.LoadQuery(qry, "UserID", "NameVorname");
            if (userID == null)
            {
                edtVerantwortlich.EditValue = defaultUserID;
            }
            else
            {
                edtVerantwortlich.EditValue = userID;
            }
            bool userIsInList = qry.DataTable.Select("UserID = " + edtVerantwortlich.EditValue.ToString()).Count() > 0;
            if (!userIsInList)
            {
                edtVerantwortlich.EditValue = null;
            }
        }

        private bool NeedSilentPost()
        {
            return DBNull.Value == qryWeisung[WEI_FA_WEISUNG_ID] &&
                ((bool)qryWorkflow[WFL_PENDENZ_SAR] ||
                 (bool)qryWorkflow[WFL_SAR_PENDENZ_ANPASSEN] ||
                 (bool)qryWorkflow[WFL_PENDENZ_RD]);
        }

        private void Protokollieren()
        {
            if (qryProtokoll.IsEmpty)
            {
                ProtokollierenInit();
            }
            Protokollieren(qryWorkflow[QWFL_AKTION_TEXT].ToString());
        }

        /// <summary>
        /// Um eine Aktion auf der Weisung zu protokollieren. Macht ein neuen Eintrag in der FaWeisungProtokoll Tabelle.
        /// </summary>
        /// <param name="action">Die Aktion zu protokollieren</param>
        private void Protokollieren(string action)
        {
            Protokollieren(action, edtVerantwortlich.Text);
        }

        private void Protokollieren(string action, string verantwortlich)
        {
            qryProtokoll.Insert();
            qryProtokoll.SetCreator();
            qryProtokoll.SetModifierModified();
            qryProtokoll[PRO_FA_WEISUNG_ID] = qryWeisung[WEI_FA_WEISUNG_ID];
            qryProtokoll[PRO_AKTION] = action;
            qryProtokoll[PRO_BEMERKUNG] = edtBemerkung.EditValue;
            qryProtokoll[PRO_TERMIN] = edtNaechsterTermin.EditValue;
            qryProtokoll[PRO_VERANTWORTLICH] = verantwortlich;
            if (!qryProtokoll.Post())
            {
                throw new KissCancelException();
            }
        }

        private void ProtokollierenInit()
        {
            SqlQuery qryWorkflowInit = DBUtil.OpenSQL(qryWorkflow.SelectStatement, LOVsGenerated.FaWeisungStatus.Init, Session.User.LanguageCode);
            Protokollieren(qryWorkflowInit[QWFL_AKTION_TEXT].ToString(), edtErsteller.Text);
        }

        private void ResetField()
        {
            edtBemerkung.EditValue = null;
            this.edtNaechsterTermin.EditValueChanged -= new System.EventHandler(this.edtNaechsterTermin_EditValueChanged);
            edtNaechsterTermin.EditValue = null;
            this.edtNaechsterTermin.EditValueChanged += new System.EventHandler(this.edtNaechsterTermin_EditValueChanged);
        }

        private void ResetVerantwortlich()
        {
            edtVerantwortlich.LoadQuery(_qryEmptyUser, "UserID", "NameVorname");
            edtVerantwortlich.EditValue = 0;
        }

        private void SelectBetroffenepersonen()
        {
            string betroffenepersonen = "";
            _betroffenepersonenliste = new List<int>();

            if (qryWeisung[WEI_FA_WEISUNG_ID] == DBNull.Value)
            {
                // bei neue Weisung der Fallträger auswählen
                betroffenepersonen = _BaPersonID.ToString();
            }
            else
            {
                // sonst betroffenepersonen aus der Tabelle lesen
                qryBetroffenePerson.Fill(qryWeisung[WEI_FA_WEISUNG_ID]);

                for (int i = 0; i < qryBetroffenePerson.Count; i++)
                {
                    _betroffenepersonenliste.Add((int)qryBetroffenePerson[PRS_BA_PERSON_ID]);
                    if (betroffenepersonen != "")
                    {
                        betroffenepersonen += ",";
                    }
                    betroffenepersonen += qryBetroffenePerson[PRS_BA_PERSON_ID];
                    qryBetroffenePerson.Next();
                }
            }

            this.edtBetroffenePersonen.EditValueChanged -= new System.EventHandler(this.edtBetroffenepersonen_EditValueChanged);
            edtBetroffenePersonen.EditValue = betroffenepersonen;
            this.edtBetroffenePersonen.EditValueChanged += new System.EventHandler(this.edtBetroffenepersonen_EditValueChanged);
        }

        private void SetActiveFields(LOVsGenerated.FaWeisungStatus status)
        {
            _activeFieldList = FaWeisung.FaWeisungAktiveFelder
                                        .Where(f => f.Status == status)
                                        .ToList();
        }

        private void SetDropDownSQL()
        {
            _qryEmptyUser = DBUtil.OpenSQL("SELECT UserID = 0, NameVorname = ''");

            // alle XUser
            _qryErstellerVerantwortlich = GetAllUserDropDownSQL();

            // alle XUser von der RD Abteilung. Wenn es diese Abteilung nicht gibt, alle XUser anzeigen.
            string RDAbteilung = DBUtil.GetConfigString(@"System\Fallfuehrung\Rechtsdienstabteilung", null);
            if (RDAbteilung == null || RDAbteilung == "")
            {
                _qryRDVerantwortlich = GetAllUserDropDownSQL();
            }
            else
            {
                // OrgUnitID der Rechtsdienstabteilung suchen
                string[] abteilungen = RDAbteilung.Split('\\');
                string sql;
                sql = string.Format(@"
                    SELECT TOP 1 OrgUnitID
                    FROM XOrgUnit
                    WHERE ItemName = '{0}'
                      AND ParentID IS NULL"
                    , abteilungen[0]);
                for (int i = 1; i < abteilungen.Length; i++)
                {
                    sql = string.Format(@"
                        SELECT TOP 1 OrgUnitID
                        FROM XOrgUnit
                        WHERE ItemName = '{0}'
                          AND ParentID = ({1})"
                        , abteilungen[i]
                        , sql);
                }
                // Mitglieder der Abteilung suchen
                sql = string.Format(@"
                    SELECT
                      UserID      = USR.UserID,
                      NameVorname = USR.NameVorname
                    FROM XOrgUnit_User OUU
                      LEFT JOIN vwUser USR ON USR.UserID = OUU.UserID
                    WHERE OUU.OrgUnitID = ({0})
                      AND USR.IsLocked = 0
                    ORDER BY USR.NameVorname"
                    , sql);
                _qryRDVerantwortlich = DBUtil.OpenSQL(sql);
                if (_qryRDVerantwortlich.Count == 0)
                {
                    _qryRDVerantwortlich = GetAllUserDropDownSQL();
                }
            }
        }

        private void SetEditMode(FaWeisung.Weisungsart weisungsart)
        {
            if (weisungsart == FaWeisung.Weisungsart.Schriftlich)
            {
                docTermin.EditMode = SetEditModeIfNotReadonly(docTermin.EditMode, EditModeType.Required);
                edtAusgangslage.EditMode = SetEditModeIfNotReadonly(edtAusgangslage.EditMode, EditModeType.Normal);
                edtAuflagentext.EditMode = SetEditModeIfNotReadonly(edtAuflagentext.EditMode, EditModeType.Normal);
            }
            else
            {
                docTermin.EditMode = SetEditModeIfNotReadonly(docTermin.EditMode, EditModeType.Normal);
                edtAusgangslage.EditMode = SetEditModeIfNotReadonly(edtAusgangslage.EditMode, EditModeType.Required);
                edtAuflagentext.EditMode = SetEditModeIfNotReadonly(edtAuflagentext.EditMode, EditModeType.Required);
            }
        }

        private EditModeType SetEditModeIfNotReadonly(EditModeType editMode, EditModeType newEditMode)
        {
            if (editMode == EditModeType.ReadOnly)
            {
                return editMode;
            }
            else
            {
                return newEditMode;
            }
        }

        /// <summary>
        /// Sets all fields form the _controlList ReadOnly the XConfig value (System\Fallfuehrung\Weisung\AlleFelderSichtbar) is set to false.
        /// </summary>
        private void SetFieldsReadOnly()
        {
            if (!DBUtil.GetConfigBool(@"System\Fallfuehrung\Weisung\AlleFelderSichtbar", false))
            {
                foreach (KeyValuePair<string, Control> keyPair in _controlList)
                {
                    Control ctl = keyPair.Value;
                    if (typeof(IKissEditable).IsAssignableFrom(ctl.GetType()))
                    {
                        ((IKissEditable)ctl).EditMode = EditModeType.ReadOnly;
                    }
                    else
                    {
                        throw new KissErrorException("The control is not a IKissEditable object.");
                    }
                }
            }
        }

        private void SetNaechsterTermin(FaWeisung.Termin termin)
        {
            switch (termin)
            {
                case FaWeisung.Termin.Weisung:
                    qryWeisung[WEI_TERMIN_WEISUNG] = edtNaechsterTermin.EditValue;
                    qryWeisung[WEI_WEISUNG_VERSCHOBEN] = true;
                    break;

                case FaWeisung.Termin.Mahnung1:
                    qryWeisung[WEI_TERMIN_MAHNUNG_1] = edtNaechsterTermin.EditValue;
                    break;

                case FaWeisung.Termin.Mahnung2:
                    qryWeisung[WEI_TERMIN_MAHNUNG_2] = edtNaechsterTermin.EditValue;
                    break;

                case FaWeisung.Termin.Mahnung3:
                    qryWeisung[WEI_TERMIN_MAHNUNG_3] = edtNaechsterTermin.EditValue;
                    break;

                case FaWeisung.Termin.Verfuegung:
                    qryWeisung[WEI_DATUM_VERFUEGUNG] = edtNaechsterTermin.EditValue;
                    break;
            }
        }

        private void SetPendenz()
        {
            if ((bool)qryWorkflow[WFL_PENDENZ_SAR] || (bool)qryWorkflow[WFL_SAR_PENDENZ_ANPASSEN])
            {
                SetPendenzAnSAR();
            }
            if ((bool)qryWorkflow[WFL_PENDENZ_RD])
            {
                SetPendenzAnRD();
            }
        }

        private void SetPendenz(int xTaskTemplateID, int? xTaskID, bool sarPendenzAnpassen, int recieverUserID, DateTime termin, LOVsGenerated.FaWeisungStatus status, LOVsGenerated.FaWeisungStatus neuerStatus, int weisungID, string weisungBetreff)
        {
            SqlQuery qryXTaskTemplate = DBUtil.OpenSQL(@"SELECT  TaskTypeCode,
                                                                 TaskStatusCode,
                                                                 TaskSubject = ISNULL(dbo.fnGetMLText(TaskSubjectTID, {1}), TaskSubject),
                                                                 TaskDescription = ISNULL(dbo.fnGetMLText(TaskDescriptionTID, {1}), TaskDescription)
                                                         FROM XTaskTemplate
                                                         WHERE XTaskTemplateID = {0}"
                                                       , xTaskTemplateID
                                                       , Session.User.LanguageCode);

            qryXTask.Fill(xTaskID);
            if (qryXTask.IsEmpty || !sarPendenzAnpassen)
            {
                qryXTask.Insert();
            }
            qryXTask[TSK_CREATE_DATE] = DateTime.Now;
            qryXTask[TSK_EXPIRATION_DATE] = termin;
            qryXTask[TSK_FA_LEISTUNG_ID] = _FaLeistungID;
            qryXTask[TSK_RECEIVER_ID] = recieverUserID;
            qryXTask[TSK_SENDER_ID] = Session.User.UserID;
            qryXTask[TSK_SUBJECT] = string.Format("{0} ({1})", qryXTaskTemplate["TaskSubject"], weisungBetreff);
            qryXTask[TSK_TASK_DESCRIPTION] = qryXTaskTemplate["TaskDescription"];
            qryXTask[TSK_TASK_RECEIVER_CODE] = 1; // Person enum?
            qryXTask[TSK_TASK_SENDER_CODE] = 1; // Person enum?
            qryXTask[TSK_TASK_STATUS_CODE] = qryXTaskTemplate["TaskStatusCode"];
            qryXTask[TSK_TASK_TYPE_CODE] = qryXTaskTemplate["TaskTypeCode"];
            qryXTask[TSK_JUMP_TO_PATH] = string.Format("ActiveSQLQuery.Find=FaWeisungID = {3};BaPersonID={0};ModulID=2;TreeNodeID=CtlFaBeratungsperiode{1}/20003/CtlFaWeisung;FaLeistungID={1};FaFallID={2};ClassName=FrmFall;FaWeisungID={3}", _BaPersonID, _FaLeistungID, _FaFallID, weisungID);
            qryXTask[TSK_BA_PERSON_ID] = edtBetroffenePersonen.EditValue.ToString().Split(',')[0];

            if (!qryXTask.Post())
            {
                throw new KissCancelException();
            }
        }

        private void SetPendenzAnRD()
        {
            int xTaskTemplateID;
            int? xTaskID;
            bool sarPendenzAnpassen;
            int recieverUserID;
            DateTime termin;
            LOVsGenerated.FaWeisungStatus status;
            LOVsGenerated.FaWeisungStatus neuerStatus;
            int weisungID;
            string weisungBetreff;

            xTaskTemplateID = (int)qryWorkflow[WFL_XTASK_TEMPLATE_ID_RD];
            xTaskID = null;
            sarPendenzAnpassen = false;
            recieverUserID = (int)qryWeisung[WEI_USER_ID_VERANTWORTLICH_RD];
            termin = edtNaechsterTermin.EditValue == DBNull.Value ? DateTime.Today.AddDays(DBUtil.GetConfigInt(@"System\Fallfuehrung\Weisung\AnzahlTageInVoraus", 0)) : (DateTime)edtNaechsterTermin.EditValue;
            status = (LOVsGenerated.FaWeisungStatus)qryWorkflow[WFL_STATUS_CODE];
            neuerStatus = (LOVsGenerated.FaWeisungStatus)qryWorkflow[WFL_NEUER_STATUS_CODE];
            weisungID = (int)qryWeisung[WEI_FA_WEISUNG_ID];
            weisungBetreff = qryWeisung[WEI_BETREFF].ToString();

            SetPendenz(xTaskTemplateID, xTaskID, sarPendenzAnpassen, recieverUserID, termin, status, neuerStatus, weisungID, weisungBetreff);
        }

        private void SetPendenzAnSAR()
        {
            int xTaskTemplateID;
            int? xTaskID;
            bool sarPendenzAnpassen;
            int recieverUserID;
            DateTime termin;
            LOVsGenerated.FaWeisungStatus status;
            LOVsGenerated.FaWeisungStatus neuerStatus;
            int weisungID;
            string weisungBetreff;

            xTaskTemplateID = (int)qryWorkflow[WFL_XTASK_TEMPLATE_ID_SAR];
            xTaskID = qryWeisung[WEI_XTASK_ID_SAR] as int?;
            sarPendenzAnpassen = (bool)qryWorkflow[WFL_SAR_PENDENZ_ANPASSEN];
            recieverUserID = (int)qryWeisung[WEI_USER_ID_VERANTWORTLICH_SAR];
            termin = edtNaechsterTermin.EditValue == DBNull.Value ? DateTime.Today.AddDays(3) : (DateTime)edtNaechsterTermin.EditValue;
            status = (LOVsGenerated.FaWeisungStatus)qryWorkflow[WFL_STATUS_CODE];
            neuerStatus = (LOVsGenerated.FaWeisungStatus)qryWorkflow[WFL_NEUER_STATUS_CODE];
            weisungID = (int)qryWeisung[WEI_FA_WEISUNG_ID];
            weisungBetreff = qryWeisung[WEI_BETREFF].ToString();

            SetPendenz(xTaskTemplateID, xTaskID, sarPendenzAnpassen, recieverUserID, termin, status, neuerStatus, weisungID, weisungBetreff);
            if (sarPendenzAnpassen)
            {
                qryWeisung[WEI_XTASK_ID_SAR] = qryXTask[TSK_XTASK_ID];
            }
        }

        private void SetQueryFieldBeforePost()
        {
            qryWeisung.SetModifierModified();
            qryWeisung[WEI_STATUS_CODE] = qryWorkflow[WFL_NEUER_STATUS_CODE];
            qryWeisung[QWEI_STATUS_TEXT] = qryWorkflow[QWFL_NEUER_STATUS_TEXT];
            qryWeisung[QWEI_VERANTWORTLICH] = edtVerantwortlich.Text;

            if ((bool)qryWorkflow[WFL_NAECHSTER_TERMIN_ANPASSEN])
            {
                SetNaechsterTermin((FaWeisung.Termin)qryWorkflow[WFL_NAECHSTER_TERMIN_CODE]);
            }

            if ((LOVsGenerated.FaWeisungStatus)qryWorkflow[WFL_NEUER_STATUS_CODE] == LOVsGenerated.FaWeisungStatus.Fertig)
            {
                qryWeisung[WEI_WEISUNG_ERFUELLT] = qryWorkflow[WFL_WEISUNG_ERFUELLT];
                qryWeisung[QWEI_WEISUNG_ERFUELLT_LOV] = (bool)qryWeisung[WEI_WEISUNG_ERFUELLT] ? 1 : 0;
            }

            // versendete Weisungen können nicht mehr gelöscht sein
            if ((LOVsGenerated.FaWeisungStatus)qryWorkflow[WFL_NEUER_STATUS_CODE] == LOVsGenerated.FaWeisungStatus.WeisungPruefen)
            {
                qryWeisung[WEI_CAN_DELETE] = false;
                qryWeisung.CanDelete = false;
            }

            switch ((FaWeisung.Zustaendig)qryWorkflow[WFL_ZUSTAENDIG_CODE])
            {
                case FaWeisung.Zustaendig.RD:
                    qryWeisung[WEI_USER_ID_VERANTWORTLICH_RD] = edtVerantwortlich.EditValue;
                    break;

                case FaWeisung.Zustaendig.Ersteller:
                    qryWeisung[WEI_USER_ID_VERANTWORTLICH_SAR] = edtVerantwortlich.EditValue;
                    break;
            }
        }

        /// <summary>
        /// Context von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupContext()
        {
            this.docTermin.Context = CONTEXT_DOC;
            this.docTerminMahnung1.Context = CONTEXT_DOC;
            this.docTerminMahnung2.Context = CONTEXT_DOC;
            this.docTerminMahnung3.Context = CONTEXT_DOC;
            this.docDatumVerfuegung.Context = CONTEXT_DOC;
        }

        /// <summary>
        /// Liste von Controls die je nach Status aktiviert sein müssen.
        /// </summary>
        private void SetupControlList()
        {
            _controlList = new Dictionary<string, Control>();
            _controlList.Add(edtBetreff.Name, edtBetreff);
            _controlList.Add(edtWeisungsart.Name, edtWeisungsart);
            _controlList.Add(edtBetroffenePersonen.Name, edtBetroffenePersonen);
            _controlList.Add(edtAusgangslage.Name, edtAusgangslage);
            _controlList.Add(edtAuflagentext.Name, edtAuflagentext);
            _controlList.Add(edtAngedrohteKuerzungGB.Name, edtAngedrohteKuerzungGB);
            _controlList.Add(edtAngedrohteKonsequenz.Name, edtAngedrohteKonsequenz);
            _controlList.Add(edtTermin.Name, edtTermin);
            _controlList.Add(docTermin.Name, docTermin);
            _controlList.Add(edtTerminMahnung1.Name, edtTerminMahnung1);
            _controlList.Add(docTerminMahnung1.Name, docTerminMahnung1);
            _controlList.Add(edtTerminMahnung2.Name, edtTerminMahnung2);
            _controlList.Add(docTerminMahnung2.Name, docTerminMahnung2);
            _controlList.Add(edtTerminMahnung3.Name, edtTerminMahnung3);
            _controlList.Add(docTerminMahnung3.Name, docTerminMahnung3);
            _controlList.Add(edtDatumVerfuegung.Name, edtDatumVerfuegung);
            _controlList.Add(docDatumVerfuegung.Name, docDatumVerfuegung);
            _controlList.Add(edtKuerzungGB.Name, edtKuerzungGB);
            _controlList.Add(edtKuerzungVon.Name, edtKuerzungVon);
            _controlList.Add(edtKuerzungBis.Name, edtKuerzungBis);
            _controlList.Add(edtKonsequenz.Name, edtKonsequenz);
            _controlList.Add(edtKonsequenzVon.Name, edtKonsequenzVon);
            _controlList.Add(edtKonsequenzBis.Name, edtKonsequenzBis);
            _controlList.Add(edtBemerkung.Name, edtBemerkung);
            _controlList.Add(edtNaechsterTermin.Name, edtNaechsterTermin);
            _controlList.Add(edtVerantwortlich.Name, edtVerantwortlich);
        }

        /// <summary>
        /// DataMember von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupDataMembers()
        {
            this.edtErsteller.DataMember = QWEI_CREATOR_NAME;
            this.edtKonsequenzVon.DataMember = WEI_KONSEQUENZ_DATUM_VON;
            this.edtKuerzungGB.DataMember = WEI_KUERZUNG_GB_VERFUEGT;
            this.edtKuerzungVon.DataMember = WEI_KUERZUNG_DATUM_VON;
            this.edtKuerzungBis.DataMember = WEI_KUERZUNG_DATUM_BIS;
            this.edtKonsequenzBis.DataMember = WEI_KONSEQUENZ_DATUM_BIS;
            this.edtWeisungErfuellt.DataMember = QWEI_WEISUNG_ERFUELLT_LOV;
            this.edtKonsequenz.DataMember = WEI_KONSEQUENZ_CODE_VERFUEGT;
            this.docTermin.DataMember = WEI_XDOCUMENT_ID_WEISUNG;
            this.docDatumVerfuegung.DataMember = WEI_XDOCUMENT_ID_VERFUEGUNG;
            this.edtDatumVerfuegung.DataMember = WEI_DATUM_VERFUEGUNG;
            this.docTerminMahnung3.DataMember = WEI_XDOCUMENT_ID_MAHNUNG_3;
            this.edtTerminMahnung3.DataMember = WEI_TERMIN_MAHNUNG_3;
            this.docTerminMahnung2.DataMember = WEI_XDOCUMENT_ID_MAHNUNG_2;
            this.edtTerminMahnung2.DataMember = WEI_TERMIN_MAHNUNG_2;
            this.docTerminMahnung1.DataMember = WEI_XDOCUMENT_ID_MAHNUNG_1;
            this.edtTerminMahnung1.DataMember = WEI_TERMIN_MAHNUNG_1;
            this.edtTermin.DataMember = WEI_TERMIN_WEISUNG;
            this.edtAngedrohteKonsequenz.DataMember = WEI_KONSEQUENZ_CODE_ANGEDROHT;
            this.edtAngedrohteKuerzungGB.DataMember = WEI_KUERZUNG_GB_ANGEDROHT;
            this.edtAuflagentext.DataMember = WEI_AUFLAGE;
            this.edtAusgangslage.DataMember = WEI_AUSGANSLAGE;
            this.edtErstelltAm.DataMember = WEI_CREATED;
            this.edtBetreff.DataMember = WEI_BETREFF;
            this.edtWeisungsart.DataMember = WEI_WEISUNGSART_CODE;
        }

        /// <summary>
        /// FieldName für die Kolonen von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupFieldNames()
        {
            // grvWeisungen
            this.colDatumErstellt.FieldName = WEI_CREATED;
            this.colBetreff.FieldName = WEI_BETREFF;
            this.colTerminDatum.FieldName = WEI_TERMIN_WEISUNG;
            this.colKonsequenzAngedroht.FieldName = QWEI_KONSEQUENZ_TEXT_ANGEDROHT;
            this.colStatus.FieldName = QWEI_STATUS_TEXT;
            this.colVerantwortlich.FieldName = QWEI_VERANTWORTLICH;
            this.colWeisungErfuellt.FieldName = QWEI_WEISUNG_ERFUELLT_TEXT;
            // grvAktion
            this.colNaechsteAktion.FieldName = QWFL_AKTION_TEXT;
            // grvProtokoll
            this.colDatum.FieldName = PRO_CREATED;
            this.colBearbeiter.FieldName = PRO_CREATOR;
            this.colAktion.FieldName = PRO_AKTION;
            this.colBemerkung.FieldName = PRO_BEMERKUNG;
            this.colNaechsterTermin.FieldName = PRO_TERMIN;
            this.colProVerantwortlich.FieldName = PRO_VERANTWORTLICH;
        }

        /// <summary>
        /// Tag benutzen um ein klaren Text anzuzeigen für die Mussfelder.
        /// </summary>
        private void SetupTags()
        {
            edtErsteller.Tag = lblErsteller.Text;
            edtKonsequenzVon.Tag = lblKonsequenzVon.Text;
            edtKuerzungGB.Tag = lblKuerzungGB.Text;
            edtKuerzungVon.Tag = lblKuerzungVon.Text;
            edtKuerzungBis.Tag = lblKuerzungBis.Text;
            edtKonsequenzBis.Tag = lblKonsequenzBis.Text;
            edtWeisungErfuellt.Tag = lblWeisungErfuellt.Text;
            edtKonsequenz.Tag = lblKonsequenz.Text;
            docTermin.Tag = lblTerminDoc.Text;
            docDatumVerfuegung.Tag = lblDatumVerfuegungDoc.Text;
            edtDatumVerfuegung.Tag = lblDatumVerfuegung.Text;
            docTerminMahnung3.Tag = lblTerminMahnung3Doc.Text;
            edtTerminMahnung3.Tag = lblTerminMahnung3.Text;
            docTerminMahnung2.Tag = lblTerminMahnung2Doc.Text;
            edtTerminMahnung2.Tag = lblTerminMahnung2.Text;
            docTerminMahnung1.Tag = lblTerminMahnung1Doc.Text;
            edtTerminMahnung1.Tag = lblTerminMahnung1.Text;
            edtTermin.Tag = lblTermin.Text;
            edtAngedrohteKonsequenz.Tag = lblAngedrohteKonsequenz.Text;
            edtAngedrohteKuerzungGB.Tag = lblAngedrohteKuerzungGB.Text;
            edtAuflagentext.Tag = lblAuflagentext.Text;
            edtAusgangslage.Tag = lblAusgangslage.Text;
            edtErstelltAm.Tag = lblErstelltAm.Text;
            edtBetreff.Tag = lblBetreff.Text;
            edtWeisungsart.Tag = lblWeisungsart.Text;
            edtNaechsterTermin.Tag = lblNaechsterTermin.Text;
            edtVerantwortlich.Tag = lblVeranwortlich.Text;
        }

        private void UpdateBetroffenepersonen()
        {
            List<int> betroffenepersonenlisteNeu = Utils.GetListOfInt(edtBetroffenePersonen.EditValue);
            int faWeisungID = Convert.ToInt32(qryWeisung[WEI_FA_WEISUNG_ID]);

            // Neue Person hinzufügen
            foreach (int personID in betroffenepersonenlisteNeu)
            {
                if (!_betroffenepersonenliste.Contains(personID))
                {
                    if (qryBetroffenePerson.DataTable.Columns.Count == 0)
                    {
                        qryBetroffenePerson.Fill(faWeisungID);
                    }
                    qryBetroffenePerson.Insert();
                    qryBetroffenePerson[PRS_FA_WEISUNG_ID] = faWeisungID;
                    qryBetroffenePerson[PRS_BA_PERSON_ID] = personID;
                    if (!qryBetroffenePerson.Post())
                    {
                        throw new KissCancelException();
                    }
                }
            }

            // Alte Person löschen
            string sql = "";
            foreach (int personID in _betroffenepersonenliste)
            {
                if (!betroffenepersonenlisteNeu.Contains(personID))
                {
                    sql += string.Format("DELETE FaWeisung_BaPerson WHERE FaWeisungID = {0} AND BaPersonID = {1}\n", faWeisungID, personID);
                }
            }
            if (sql != "")
            {
                SqlQuery qry = DBUtil.OpenSQL(sql);
            }

            _betroffenepersonenliste = betroffenepersonenlisteNeu;
        }

        private void UpdateListe()
        {
            qryWeisung[QWEI_KONSEQUENZ_TEXT_ANGEDROHT] = edtAngedrohteKonsequenz.Text;
        }

        #endregion

        #endregion
    }
}