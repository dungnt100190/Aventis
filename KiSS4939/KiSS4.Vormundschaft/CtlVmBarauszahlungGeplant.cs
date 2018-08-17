using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Dokument;
using KiSS4.Gui;

namespace KiSS4.Vormundschaft
{
    #region Enumerations

    /// <summary>
    /// Enum für die Spalte FbBarauszahlungZyklus.DauerTypCode
    /// </summary>
    public enum DauerTyp
    {
        Tag = 1,
        Monat = 2
    }

    // TODO Kiss.VM.BL (VmBarauszahlung), Kiss.Fibu.BL (FbBarzahlung) oder KiSS.DBScheme (LOV)
    /// <summary>
    /// LOV FbBarauszahlungPeriodizitaet
    /// </summary>
    public enum FbBarauszahlungPeriodizitaet
    {
        Jaehrlich = 1,
        Halbjaehrlich = 2,
        Vierteljaehrlich = 3,
        Zweimonatlich = 4,
        Monatlich = 5,
        ZweiMalProMonat = 6,
        VierzehnTaeglich = 7,
        Woechentlich = 8,
        Einmalig = 9
    }

    /// <summary>
    /// LOV FbBarauszahlungStatus
    /// </summary>
    public enum FbBarauszahlungStatus
    {
        KeinePeriodeVorhanden = 1,
        KeineAuszahlungenVorhanden = 2,
        AuszahlungenVorhanden = 3
    }

    /// <summary>
    /// LOV FbBuchungStatus
    /// </summary>
    public enum FbBuchungStatus
    {
        KeinePeriodeVorhanden = 1,
        NochNichtFaellig = 2,
        Freigegeben = 3,
        Ausbezahlt = 4,
        Verfallen = 5,
        HabenKontoNichtGueltig = 6
    }

    /// <summary>
    /// LOV Geschlecht
    /// </summary>
    public enum Geschlecht
    {
        Maenlich = 1,
        Weiblich = 2
    }

    /// <summary>
    /// LOV Wochentag
    /// </summary>
    public enum Wochentag
    {
        Montag = 1,
        Dienstag = 2,
        Mittwoch = 3,
        Donnerstag = 4,
        Freitag = 5,
        Samstag = 6,
        Sonntag = 7
    }

    #endregion

    /// <summary>
    /// Summary description for CtlVmBarauszahlungGeplant.
    /// </summary>
    public class CtlVmBarauszahlungGeplant : KissSearchUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        // Field name from the query qryFbBarauszahlungAuftrag that are not in the table
        private const string QBAA_BA_PERSON_ID_MANDANT = "BaPersonID_Mandant";

        private const string QBAA_CREATOR_NAME = "CreatorName";
        private const string QBAA_FB_BARAUSZAHLUNG_STATUS_CODE = "FbBarauszahlungStatusCode";
        private const string QBAA_HABEN_KTO_NR_NAME = "HabenKtoName";
        private const string QBAA_LETZTE_AUSZAHLUNG = "LetzteAuszahlung";
        private const string QBAA_MODIFIER_NAME = "ModifierName";
        private const string QBAA_NAME_MANDANT = "NameMandant";
        private const string QBAA_PLZ_ORT_MANDANT = "PLZOrtMandant";
        private const string QBAA_SOLL_KTO_NR_NAME = "SollKtoName";

        // Field name from the query qryPerson
        private const string QPRS_PLZ_ORT = "PLZOrt";

        #endregion

        #region Private Fields

        private int _BaPersonID;
        private Dictionary<string, Control> _controlList;
        private int _countRemoveZyklusFieldsEvents;
        private int _FaLeistungID;
        private bool _leistungIsActive;
        private Dictionary<Wochentag, KissCheckEdit> _wochentagList;
        private KissButton btnAuftragKopieren;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungstext;
        private DevExpress.XtraGrid.Columns.GridColumn colCreator;
        private DevExpress.XtraGrid.Columns.GridColumn colLetzteAuszahlung;
        private DevExpress.XtraGrid.Columns.GridColumn colPeriodizitaet;
        private DevExpress.XtraGrid.Columns.GridColumn colSollKontoNr;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private System.ComponentModel.IContainer components = null;
        private KissCalcEdit edtBetrag;
        private KissTextEdit edtBuchungstext;
        private KissTextEdit edtCreator;
        private KissDateEdit edtDatumBis;
        private KissDateEdit edtDatumVon;
        private KissCheckEdit edtDienstag;
        private KiSS4.Dokument.XDokument edtDocument;
        private KissCheckEdit edtDonnerstag;
        private KissCheckEdit edtFreitag;
        private KissTextEdit edtHabenKontoName;
        private KissButtonEdit edtHabenKontoNr;
        private KissTextEdit edtMandant;
        private KissTextEdit edtMandantNr;
        private KissTextEdit edtMandantPlzOrt;
        private KissCheckEdit edtMittwoch;
        private KissTextEdit edtModifier;
        private KissCalcEdit edtMonatstag1;
        private KissCalcEdit edtMonatstag2;
        private KissCheckEdit edtMontag;
        private KissCalcEdit edtNachbezug;
        private KissLookUpEdit edtPeriodizitaet;
        private KiSS4.Gui.KissCalcEdit edtSearchBetragBis;
        private KiSS4.Gui.KissCalcEdit edtSearchBetragVon;
        private KiSS4.Gui.KissDateEdit edtSearchDatumBis;
        private KiSS4.Gui.KissDateEdit edtSearchDatumVon;
        private KiSS4.Gui.KissCheckEdit edtSearchNurAktive;
        private KissLookUpEdit edtSearchPeriodizitaet;
        private KissTextEdit edtSollKontoName;
        private KissButtonEdit edtSollKontoNr;
        private KissCalcEdit edtVorbezug;
        private KissLookUpEdit edtWochentag;
        private KiSS4.Gui.KissGrid grdFbDauerauftrag;
        private DevExpress.XtraGrid.Views.Grid.GridView grvFbDauerauftrag;
        private KiSS4.Gui.KissSearchTitel kissSearchTitel1;
        private KissLabel lblAuftragId;
        private KissLabel lblBetrag;
        private KissLabel lblBuchungstext;
        private KissLabel lblCreator;
        private KissLabel lblDatumBis;
        private KissLabel lblDatumVon;
        private KissLabel lblDocument;
        private KissLabel lblHaben;
        private KissLabel lblMandant;
        private KissLabel lblModifier;
        private KissLabel lblMonatstag;
        private KissLabel lblNachbezug;
        private KissLabel lblPeriodizitaet;
        private KissLabel lblSaldo;
        private KiSS4.Gui.KissLabel lblSearchBetragBis;
        private KiSS4.Gui.KissLabel lblSearchBetragVon;
        private KiSS4.Gui.KissLabel lblSearchDatumBis;
        private KiSS4.Gui.KissLabel lblSearchDatumVon;
        private KiSS4.Gui.KissLabel lblSearchPeriodizitaet;
        private KissLabel lblSoll;
        private KissLabel lblTitel;
        private KissLabel lblVorbezug;
        private KissLabel lblWochentag;
        private KissLabel lblWochentage;
        private bool mayUpdate;
        private Panel panDetail;
        private Panel panMonatstag;
        private Panel panWochentag;
        private Panel panWochentagListe;
        private PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryFbBarauszahlungAuftrag;
        private SqlQuery qryFbBarauszahlungZyklus;
        private SqlQuery qryKonto;
        private SqlQuery qryPeriode;
        private SqlQuery qryPerson;
        private SqlQuery qrySaldoKasse;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlVmBarauszahlungGeplant"/> class.
        /// </summary>
        public CtlVmBarauszahlungGeplant()
        {
            InitializeComponent();

            SetupControlList();

            SqlQuery qryPeriodizitaet = DBUtil.OpenSQL("SELECT Code, Text FROM XLOVCode WHERE LOVName = 'FbBarauszahlungPeriodizitaet'");
            this.colPeriodizitaet.ColumnEdit = this.grdFbDauerauftrag.GetLOVLookUpEdit(qryPeriodizitaet, "Code", "Text");

            SqlQuery qryStatus = DBUtil.OpenSQL("SELECT Code, Text FROM XLOVCode WHERE LOVName = 'FbBarauszahlungStatus'");
            this.colStatus.ColumnEdit = this.grdFbDauerauftrag.GetLOVLookUpEdit(qryStatus, "Code", "Text");

            bool dummy;
            Session.GetUserRight(this.Name, out dummy, out dummy, out mayUpdate, out dummy);
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlVmBarauszahlungGeplant));
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
            this.components = new System.ComponentModel.Container();
            this.qryFbBarauszahlungAuftrag = new KiSS4.DB.SqlQuery();
            this.grdFbDauerauftrag = new KiSS4.Gui.KissGrid();
            this.grvFbDauerauftrag = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSollKontoNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPeriodizitaet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLetzteAuszahlung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtSearchNurAktive = new KiSS4.Gui.KissCheckEdit();
            this.kissSearchTitel1 = new KiSS4.Gui.KissSearchTitel();
            this.edtSearchDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtSearchDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblSearchPeriodizitaet = new KiSS4.Gui.KissLabel();
            this.edtSearchBetragBis = new KiSS4.Gui.KissCalcEdit();
            this.edtSearchBetragVon = new KiSS4.Gui.KissCalcEdit();
            this.lblSearchDatumBis = new KiSS4.Gui.KissLabel();
            this.lblSearchDatumVon = new KiSS4.Gui.KissLabel();
            this.lblSearchBetragBis = new KiSS4.Gui.KissLabel();
            this.lblSearchBetragVon = new KiSS4.Gui.KissLabel();
            this.panDetail = new System.Windows.Forms.Panel();
            this.btnAuftragKopieren = new KiSS4.Gui.KissButton();
            this.lblAuftragId = new KiSS4.Gui.KissLabel();
            this.panWochentag = new System.Windows.Forms.Panel();
            this.edtDienstag = new KiSS4.Gui.KissCheckEdit();
            this.edtMittwoch = new KiSS4.Gui.KissCheckEdit();
            this.edtDonnerstag = new KiSS4.Gui.KissCheckEdit();
            this.edtFreitag = new KiSS4.Gui.KissCheckEdit();
            this.edtMontag = new KiSS4.Gui.KissCheckEdit();
            this.lblWochentage = new KiSS4.Gui.KissLabel();
            this.panWochentagListe = new System.Windows.Forms.Panel();
            this.lblWochentag = new KiSS4.Gui.KissLabel();
            this.edtWochentag = new KiSS4.Gui.KissLookUpEdit();
            this.edtMandant = new KiSS4.Gui.KissTextEdit();
            this.lblNachbezug = new KiSS4.Gui.KissLabel();
            this.edtNachbezug = new KiSS4.Gui.KissCalcEdit();
            this.panMonatstag = new System.Windows.Forms.Panel();
            this.edtMonatstag2 = new KiSS4.Gui.KissCalcEdit();
            this.qryFbBarauszahlungZyklus = new KiSS4.DB.SqlQuery();
            this.lblMonatstag = new KiSS4.Gui.KissLabel();
            this.edtMonatstag1 = new KiSS4.Gui.KissCalcEdit();
            this.lblVorbezug = new KiSS4.Gui.KissLabel();
            this.edtVorbezug = new KiSS4.Gui.KissCalcEdit();
            this.edtModifier = new KiSS4.Gui.KissTextEdit();
            this.lblModifier = new KiSS4.Gui.KissLabel();
            this.edtCreator = new KiSS4.Gui.KissTextEdit();
            this.lblCreator = new KiSS4.Gui.KissLabel();
            this.lblDocument = new KiSS4.Gui.KissLabel();
            this.edtDocument = new KiSS4.Dokument.XDokument();
            this.edtBuchungstext = new KiSS4.Gui.KissTextEdit();
            this.lblBuchungstext = new KiSS4.Gui.KissLabel();
            this.edtSollKontoNr = new KiSS4.Gui.KissButtonEdit();
            this.edtHabenKontoName = new KiSS4.Gui.KissTextEdit();
            this.edtSollKontoName = new KiSS4.Gui.KissTextEdit();
            this.edtHabenKontoNr = new KiSS4.Gui.KissButtonEdit();
            this.edtPeriodizitaet = new KiSS4.Gui.KissLookUpEdit();
            this.lblDatumBis = new KiSS4.Gui.KissLabel();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblPeriodizitaet = new KiSS4.Gui.KissLabel();
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtMandantNr = new KiSS4.Gui.KissTextEdit();
            this.edtBetrag = new KiSS4.Gui.KissCalcEdit();
            this.edtMandantPlzOrt = new KiSS4.Gui.KissTextEdit();
            this.lblBetrag = new KiSS4.Gui.KissLabel();
            this.lblHaben = new KiSS4.Gui.KissLabel();
            this.lblSoll = new KiSS4.Gui.KissLabel();
            this.lblMandant = new KiSS4.Gui.KissLabel();
            this.lblSaldo = new KiSS4.Gui.KissLabel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.edtSearchPeriodizitaet = new KiSS4.Gui.KissLookUpEdit();
            this.qryPerson = new KiSS4.DB.SqlQuery();
            this.qrySaldoKasse = new KiSS4.DB.SqlQuery();
            this.qryPeriode = new KiSS4.DB.SqlQuery();
            this.qryKonto = new KiSS4.DB.SqlQuery();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryFbBarauszahlungAuftrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFbDauerauftrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFbDauerauftrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchNurAktive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchPeriodizitaet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchBetragBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchBetragVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchBetragBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchBetragVon)).BeginInit();
            this.panDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuftragId)).BeginInit();
            this.panWochentag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtDienstag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMittwoch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDonnerstag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFreitag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMontag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWochentage)).BeginInit();
            this.panWochentagListe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblWochentag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWochentag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWochentag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMandant.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNachbezug)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNachbezug.Properties)).BeginInit();
            this.panMonatstag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtMonatstag2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFbBarauszahlungZyklus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMonatstag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMonatstag1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorbezug)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorbezug.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModifier.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModifier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCreator.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCreator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDocument.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollKontoNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHabenKontoName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollKontoName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHabenKontoNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPeriodizitaet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPeriodizitaet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPeriodizitaet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMandantNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMandantPlzOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHaben)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSaldo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchPeriodizitaet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchPeriodizitaet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrySaldoKasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPeriode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKonto)).BeginInit();
            this.SuspendLayout();
            //
            // searchTitle
            //
            this.searchTitle.Size = new System.Drawing.Size(825, 24);
            //
            // tabControlSearch
            //
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSearch.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabControlSearch.Location = new System.Drawing.Point(3, 33);
            this.tabControlSearch.Size = new System.Drawing.Size(849, 322);
            this.tabControlSearch.TabStop = false;
            this.tabControlSearch.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControlSearch_SelectedTabChanged);
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.grdFbDauerauftrag);
            this.tpgListe.Size = new System.Drawing.Size(837, 284);
            this.tpgListe.Title = "Liste";
            //
            // tpgSuchen
            //
            this.tpgSuchen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.tpgSuchen.Controls.Add(this.edtSearchPeriodizitaet);
            this.tpgSuchen.Controls.Add(this.edtSearchNurAktive);
            this.tpgSuchen.Controls.Add(this.kissSearchTitel1);
            this.tpgSuchen.Controls.Add(this.edtSearchDatumBis);
            this.tpgSuchen.Controls.Add(this.edtSearchDatumVon);
            this.tpgSuchen.Controls.Add(this.lblSearchPeriodizitaet);
            this.tpgSuchen.Controls.Add(this.edtSearchBetragVon);
            this.tpgSuchen.Controls.Add(this.edtSearchBetragBis);
            this.tpgSuchen.Controls.Add(this.lblSearchDatumBis);
            this.tpgSuchen.Controls.Add(this.lblSearchBetragVon);
            this.tpgSuchen.Controls.Add(this.lblSearchDatumVon);
            this.tpgSuchen.Controls.Add(this.lblSearchBetragBis);
            this.tpgSuchen.Size = new System.Drawing.Size(837, 284);
            this.tpgSuchen.TabIndex = 0;
            this.tpgSuchen.Title = "Suchen";
            this.tpgSuchen.Controls.SetChildIndex(this.lblSearchBetragBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSearchDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSearchBetragVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSearchDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSearchBetragBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSearchBetragVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSearchPeriodizitaet, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSearchDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSearchDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissSearchTitel1, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSearchNurAktive, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSearchPeriodizitaet, 0);
            //
            // qryFbBarauszahlungAuftrag
            //
            this.qryFbBarauszahlungAuftrag.CanDelete = true;
            this.qryFbBarauszahlungAuftrag.CanInsert = true;
            this.qryFbBarauszahlungAuftrag.CanUpdate = true;
            this.qryFbBarauszahlungAuftrag.HostControl = this;
            this.qryFbBarauszahlungAuftrag.SelectStatement = resources.GetString("qryFbBarauszahlungAuftrag.SelectStatement");
            this.qryFbBarauszahlungAuftrag.TableName = "FbBarauszahlungAuftrag";
            this.qryFbBarauszahlungAuftrag.BeforeInsert += new System.EventHandler(this.qryFbBarauszahlungAuftrag_BeforeInsert);
            this.qryFbBarauszahlungAuftrag.AfterInsert += new System.EventHandler(this.qryFbBarauszahlungAuftrag_AfterInsert);
            this.qryFbBarauszahlungAuftrag.BeforePost += new System.EventHandler(this.qryFbBarauszahlungAuftrag_BeforePost);
            this.qryFbBarauszahlungAuftrag.AfterPost += new System.EventHandler(this.qryFbBarauszahlungAuftrag_AfterPost);
            this.qryFbBarauszahlungAuftrag.BeforeDeleteQuestion += new System.EventHandler(this.qryFbBarauszahlungAuftrag_BeforeDeleteQuestion);
            this.qryFbBarauszahlungAuftrag.BeforeDelete += new System.EventHandler(this.qryFbBarauszahlungAuftrag_BeforeDelete);
            this.qryFbBarauszahlungAuftrag.AfterDelete += new System.EventHandler(this.qryFbBarauszahlungAuftrag_AfterDelete);
            this.qryFbBarauszahlungAuftrag.PositionChanging += new System.EventHandler(this.qryFbBarauszahlungAuftrag_PositionChanging);
            this.qryFbBarauszahlungAuftrag.PositionChanged += new System.EventHandler(this.qryFbBarauszahlungAuftrag_PositionChanged);
            //
            // grdFbDauerauftrag
            //
            this.grdFbDauerauftrag.DataSource = this.qryFbBarauszahlungAuftrag;
            this.grdFbDauerauftrag.Dock = System.Windows.Forms.DockStyle.Fill;
            //
            //
            //
            this.grdFbDauerauftrag.EmbeddedNavigator.Name = "";
            this.grdFbDauerauftrag.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdFbDauerauftrag.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdFbDauerauftrag.Location = new System.Drawing.Point(0, 0);
            this.grdFbDauerauftrag.MainView = this.grvFbDauerauftrag;
            this.grdFbDauerauftrag.Name = "grdFbDauerauftrag";
            this.grdFbDauerauftrag.Size = new System.Drawing.Size(837, 284);
            this.grdFbDauerauftrag.TabIndex = 0;
            this.grdFbDauerauftrag.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvFbDauerauftrag});
            //
            // grvFbDauerauftrag
            //
            this.grvFbDauerauftrag.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvFbDauerauftrag.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbDauerauftrag.Appearance.Empty.Options.UseBackColor = true;
            this.grvFbDauerauftrag.Appearance.Empty.Options.UseFont = true;
            this.grvFbDauerauftrag.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvFbDauerauftrag.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbDauerauftrag.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvFbDauerauftrag.Appearance.EvenRow.Options.UseFont = true;
            this.grvFbDauerauftrag.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFbDauerauftrag.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbDauerauftrag.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvFbDauerauftrag.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvFbDauerauftrag.Appearance.FocusedCell.Options.UseFont = true;
            this.grvFbDauerauftrag.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvFbDauerauftrag.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFbDauerauftrag.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbDauerauftrag.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvFbDauerauftrag.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvFbDauerauftrag.Appearance.FocusedRow.Options.UseFont = true;
            this.grvFbDauerauftrag.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvFbDauerauftrag.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFbDauerauftrag.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvFbDauerauftrag.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFbDauerauftrag.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFbDauerauftrag.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFbDauerauftrag.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvFbDauerauftrag.Appearance.GroupRow.Options.UseFont = true;
            this.grvFbDauerauftrag.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvFbDauerauftrag.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvFbDauerauftrag.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvFbDauerauftrag.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFbDauerauftrag.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvFbDauerauftrag.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvFbDauerauftrag.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvFbDauerauftrag.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvFbDauerauftrag.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbDauerauftrag.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFbDauerauftrag.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvFbDauerauftrag.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvFbDauerauftrag.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvFbDauerauftrag.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvFbDauerauftrag.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvFbDauerauftrag.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvFbDauerauftrag.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbDauerauftrag.Appearance.OddRow.Options.UseBackColor = true;
            this.grvFbDauerauftrag.Appearance.OddRow.Options.UseFont = true;
            this.grvFbDauerauftrag.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvFbDauerauftrag.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbDauerauftrag.Appearance.Row.Options.UseBackColor = true;
            this.grvFbDauerauftrag.Appearance.Row.Options.UseFont = true;
            this.grvFbDauerauftrag.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvFbDauerauftrag.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbDauerauftrag.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvFbDauerauftrag.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvFbDauerauftrag.Appearance.SelectedRow.Options.UseFont = true;
            this.grvFbDauerauftrag.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvFbDauerauftrag.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvFbDauerauftrag.Appearance.VertLine.Options.UseBackColor = true;
            this.grvFbDauerauftrag.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvFbDauerauftrag.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSollKontoNr,
            this.colBuchungstext,
            this.colBetrag,
            this.colPeriodizitaet,
            this.colStatus,
            this.colLetzteAuszahlung,
            this.colCreator});
            this.grvFbDauerauftrag.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvFbDauerauftrag.GridControl = this.grdFbDauerauftrag;
            this.grvFbDauerauftrag.Name = "grvFbDauerauftrag";
            this.grvFbDauerauftrag.OptionsBehavior.AutoSelectAllInEditor = false;
            this.grvFbDauerauftrag.OptionsBehavior.Editable = false;
            this.grvFbDauerauftrag.OptionsCustomization.AllowFilter = false;
            this.grvFbDauerauftrag.OptionsCustomization.AllowGroup = false;
            this.grvFbDauerauftrag.OptionsFilter.AllowFilterEditor = false;
            this.grvFbDauerauftrag.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvFbDauerauftrag.OptionsMenu.EnableColumnMenu = false;
            this.grvFbDauerauftrag.OptionsNavigation.AutoFocusNewRow = true;
            this.grvFbDauerauftrag.OptionsNavigation.AutoMoveRowFocus = false;
            this.grvFbDauerauftrag.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvFbDauerauftrag.OptionsNavigation.UseTabKey = false;
            this.grvFbDauerauftrag.OptionsPrint.AutoWidth = false;
            this.grvFbDauerauftrag.OptionsPrint.UsePrintStyles = true;
            this.grvFbDauerauftrag.OptionsView.ColumnAutoWidth = false;
            this.grvFbDauerauftrag.OptionsView.ShowDetailButtons = false;
            this.grvFbDauerauftrag.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvFbDauerauftrag.OptionsView.ShowGroupPanel = false;
            this.grvFbDauerauftrag.OptionsView.ShowIndicator = false;
            //
            // colSollKontoNr
            //
            this.colSollKontoNr.Caption = "Soll";
            this.colSollKontoNr.Name = "colSollKontoNr";
            this.colSollKontoNr.OptionsColumn.AllowSize = false;
            this.colSollKontoNr.OptionsColumn.FixedWidth = true;
            this.colSollKontoNr.Visible = true;
            this.colSollKontoNr.VisibleIndex = 0;
            this.colSollKontoNr.Width = 50;
            //
            // colBuchungstext
            //
            this.colBuchungstext.Caption = "Text";
            this.colBuchungstext.Name = "colBuchungstext";
            this.colBuchungstext.Visible = true;
            this.colBuchungstext.VisibleIndex = 1;
            //
            // colBetrag
            //
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "N";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.OptionsColumn.FixedWidth = true;
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 2;
            //
            // colPeriodizitaet
            //
            this.colPeriodizitaet.Caption = "Periodizität";
            this.colPeriodizitaet.Name = "colPeriodizitaet";
            this.colPeriodizitaet.OptionsColumn.FixedWidth = true;
            this.colPeriodizitaet.Visible = true;
            this.colPeriodizitaet.VisibleIndex = 3;
            this.colPeriodizitaet.Width = 110;
            //
            // colStatus
            //
            this.colStatus.Caption = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.OptionsColumn.FixedWidth = true;
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 4;
            this.colStatus.Width = 200;
            //
            // colLetzteAuszahlung
            //
            this.colLetzteAuszahlung.Caption = "Letzte Auszahlung";
            this.colLetzteAuszahlung.Name = "colLetzteAuszahlung";
            this.colLetzteAuszahlung.OptionsColumn.FixedWidth = true;
            this.colLetzteAuszahlung.Visible = true;
            this.colLetzteAuszahlung.VisibleIndex = 5;
            this.colLetzteAuszahlung.Width = 115;
            //
            // colCreator
            //
            this.colCreator.Caption = "Erfasst von";
            this.colCreator.Name = "colCreator";
            this.colCreator.Visible = true;
            this.colCreator.VisibleIndex = 6;
            //
            // edtSearchNurAktive
            //
            this.edtSearchNurAktive.EditValue = true;
            this.edtSearchNurAktive.Location = new System.Drawing.Point(117, 130);
            this.edtSearchNurAktive.Name = "edtSearchNurAktive";
            this.edtSearchNurAktive.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtSearchNurAktive.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchNurAktive.Properties.Caption = "nur aktive";
            this.edtSearchNurAktive.Size = new System.Drawing.Size(75, 19);
            this.edtSearchNurAktive.TabIndex = 12;
            //
            // kissSearchTitel1
            //
            this.kissSearchTitel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissSearchTitel1.Location = new System.Drawing.Point(15, 5);
            this.kissSearchTitel1.Name = "kissSearchTitel1";
            this.kissSearchTitel1.Size = new System.Drawing.Size(200, 24);
            this.kissSearchTitel1.TabIndex = 1;
            //
            // edtSearchDatumVon
            //
            this.edtSearchDatumVon.EditValue = null;
            this.edtSearchDatumVon.Location = new System.Drawing.Point(117, 70);
            this.edtSearchDatumVon.Name = "edtSearchDatumVon";
            this.edtSearchDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSearchDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSearchDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSearchDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchDatumVon.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtSearchDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSearchDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtSearchDatumVon.Properties.Appearance.Options.UseForeColor = true;
            this.edtSearchDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject13.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject13.Options.UseBackColor = true;
            this.edtSearchDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSearchDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13)});
            this.edtSearchDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSearchDatumVon.Properties.ShowToday = false;
            this.edtSearchDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtSearchDatumVon.TabIndex = 7;
            //
            // edtSearchDatumBis
            //
            this.edtSearchDatumBis.EditValue = "";
            this.edtSearchDatumBis.Location = new System.Drawing.Point(250, 70);
            this.edtSearchDatumBis.Name = "edtSearchDatumBis";
            this.edtSearchDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSearchDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSearchDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSearchDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchDatumBis.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtSearchDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSearchDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtSearchDatumBis.Properties.Appearance.Options.UseForeColor = true;
            this.edtSearchDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.edtSearchDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSearchDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.edtSearchDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSearchDatumBis.Properties.ShowToday = false;
            this.edtSearchDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtSearchDatumBis.TabIndex = 9;
            //
            // lblSearchPeriodizitaet
            //
            this.lblSearchPeriodizitaet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lblSearchPeriodizitaet.ForeColor = System.Drawing.Color.Black;
            this.lblSearchPeriodizitaet.Location = new System.Drawing.Point(30, 100);
            this.lblSearchPeriodizitaet.Name = "lblSearchPeriodizitaet";
            this.lblSearchPeriodizitaet.Size = new System.Drawing.Size(70, 24);
            this.lblSearchPeriodizitaet.TabIndex = 10;
            this.lblSearchPeriodizitaet.Text = "Periodizität";
            //
            // edtSearchBetragBis
            //
            this.edtSearchBetragBis.Location = new System.Drawing.Point(250, 41);
            this.edtSearchBetragBis.Name = "edtSearchBetragBis";
            this.edtSearchBetragBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSearchBetragBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSearchBetragBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSearchBetragBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchBetragBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchBetragBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSearchBetragBis.Properties.Appearance.Options.UseFont = true;
            this.edtSearchBetragBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSearchBetragBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSearchBetragBis.Size = new System.Drawing.Size(100, 24);
            this.edtSearchBetragBis.TabIndex = 5;
            //
            // edtSearchBetragVon
            //
            this.edtSearchBetragVon.Location = new System.Drawing.Point(117, 41);
            this.edtSearchBetragVon.Name = "edtSearchBetragVon";
            this.edtSearchBetragVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSearchBetragVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSearchBetragVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSearchBetragVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchBetragVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchBetragVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSearchBetragVon.Properties.Appearance.Options.UseFont = true;
            this.edtSearchBetragVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSearchBetragVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSearchBetragVon.Size = new System.Drawing.Size(100, 24);
            this.edtSearchBetragVon.TabIndex = 3;
            //
            // lblSearchDatumBis
            //
            this.lblSearchDatumBis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lblSearchDatumBis.ForeColor = System.Drawing.Color.Black;
            this.lblSearchDatumBis.Location = new System.Drawing.Point(223, 70);
            this.lblSearchDatumBis.Name = "lblSearchDatumBis";
            this.lblSearchDatumBis.Size = new System.Drawing.Size(20, 24);
            this.lblSearchDatumBis.TabIndex = 8;
            this.lblSearchDatumBis.Text = "bis";
            //
            // lblSearchDatumVon
            //
            this.lblSearchDatumVon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lblSearchDatumVon.ForeColor = System.Drawing.Color.Black;
            this.lblSearchDatumVon.Location = new System.Drawing.Point(30, 70);
            this.lblSearchDatumVon.Name = "lblSearchDatumVon";
            this.lblSearchDatumVon.Size = new System.Drawing.Size(70, 24);
            this.lblSearchDatumVon.TabIndex = 6;
            this.lblSearchDatumVon.Text = "Gültig von";
            //
            // lblSearchBetragBis
            //
            this.lblSearchBetragBis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lblSearchBetragBis.ForeColor = System.Drawing.Color.Black;
            this.lblSearchBetragBis.Location = new System.Drawing.Point(223, 41);
            this.lblSearchBetragBis.Name = "lblSearchBetragBis";
            this.lblSearchBetragBis.Size = new System.Drawing.Size(20, 24);
            this.lblSearchBetragBis.TabIndex = 4;
            this.lblSearchBetragBis.Text = "bis";
            //
            // lblSearchBetragVon
            //
            this.lblSearchBetragVon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lblSearchBetragVon.ForeColor = System.Drawing.Color.Black;
            this.lblSearchBetragVon.Location = new System.Drawing.Point(30, 40);
            this.lblSearchBetragVon.Name = "lblSearchBetragVon";
            this.lblSearchBetragVon.Size = new System.Drawing.Size(81, 24);
            this.lblSearchBetragVon.TabIndex = 2;
            this.lblSearchBetragVon.Text = "Betrag von";
            //
            // panDetail
            //
            this.panDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panDetail.Controls.Add(this.btnAuftragKopieren);
            this.panDetail.Controls.Add(this.lblAuftragId);
            this.panDetail.Controls.Add(this.panWochentag);
            this.panDetail.Controls.Add(this.panWochentagListe);
            this.panDetail.Controls.Add(this.edtMandant);
            this.panDetail.Controls.Add(this.lblNachbezug);
            this.panDetail.Controls.Add(this.edtNachbezug);
            this.panDetail.Controls.Add(this.panMonatstag);
            this.panDetail.Controls.Add(this.lblVorbezug);
            this.panDetail.Controls.Add(this.edtVorbezug);
            this.panDetail.Controls.Add(this.edtModifier);
            this.panDetail.Controls.Add(this.lblModifier);
            this.panDetail.Controls.Add(this.edtCreator);
            this.panDetail.Controls.Add(this.lblCreator);
            this.panDetail.Controls.Add(this.lblDocument);
            this.panDetail.Controls.Add(this.edtDocument);
            this.panDetail.Controls.Add(this.edtBuchungstext);
            this.panDetail.Controls.Add(this.lblBuchungstext);
            this.panDetail.Controls.Add(this.edtSollKontoNr);
            this.panDetail.Controls.Add(this.edtHabenKontoName);
            this.panDetail.Controls.Add(this.edtSollKontoName);
            this.panDetail.Controls.Add(this.edtHabenKontoNr);
            this.panDetail.Controls.Add(this.edtPeriodizitaet);
            this.panDetail.Controls.Add(this.lblDatumBis);
            this.panDetail.Controls.Add(this.edtDatumBis);
            this.panDetail.Controls.Add(this.lblPeriodizitaet);
            this.panDetail.Controls.Add(this.lblDatumVon);
            this.panDetail.Controls.Add(this.edtDatumVon);
            this.panDetail.Controls.Add(this.edtMandantNr);
            this.panDetail.Controls.Add(this.edtBetrag);
            this.panDetail.Controls.Add(this.edtMandantPlzOrt);
            this.panDetail.Controls.Add(this.lblBetrag);
            this.panDetail.Controls.Add(this.lblHaben);
            this.panDetail.Controls.Add(this.lblSoll);
            this.panDetail.Controls.Add(this.lblMandant);
            this.panDetail.Location = new System.Drawing.Point(3, 361);
            this.panDetail.Name = "panDetail";
            this.panDetail.Size = new System.Drawing.Size(849, 205);
            this.panDetail.TabIndex = 0;
            this.panDetail.Visible = false;
            //
            // btnAuftragKopieren
            //
            this.btnAuftragKopieren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuftragKopieren.Location = new System.Drawing.Point(726, 5);
            this.btnAuftragKopieren.Name = "btnAuftragKopieren";
            this.btnAuftragKopieren.Size = new System.Drawing.Size(111, 24);
            this.btnAuftragKopieren.TabIndex = 34;
            this.btnAuftragKopieren.Text = "Auftrag kopieren";
            this.btnAuftragKopieren.UseVisualStyleBackColor = false;
            this.btnAuftragKopieren.Click += new System.EventHandler(this.btnAuftragKopieren_Click);
            //
            // lblAuftragId
            //
            this.lblAuftragId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAuftragId.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblAuftragId.Location = new System.Drawing.Point(761, 173);
            this.lblAuftragId.Name = "lblAuftragId";
            this.lblAuftragId.Size = new System.Drawing.Size(82, 24);
            this.lblAuftragId.TabIndex = 33;
            this.lblAuftragId.Text = "ID: ";
            this.lblAuftragId.TextAlign = System.Drawing.ContentAlignment.TopRight;
            //
            // panWochentag
            //
            this.panWochentag.Controls.Add(this.edtDienstag);
            this.panWochentag.Controls.Add(this.edtMittwoch);
            this.panWochentag.Controls.Add(this.edtDonnerstag);
            this.panWochentag.Controls.Add(this.edtFreitag);
            this.panWochentag.Controls.Add(this.edtMontag);
            this.panWochentag.Controls.Add(this.lblWochentage);
            this.panWochentag.Location = new System.Drawing.Point(522, 89);
            this.panWochentag.Name = "panWochentag";
            this.panWochentag.Size = new System.Drawing.Size(315, 25);
            this.panWochentag.TabIndex = 25;
            this.panWochentag.Visible = false;
            //
            // edtDienstag
            //
            this.edtDienstag.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtDienstag.EditValue = false;
            this.edtDienstag.Location = new System.Drawing.Point(122, 3);
            this.edtDienstag.Name = "edtDienstag";
            this.edtDienstag.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtDienstag.Properties.Appearance.Options.UseBackColor = true;
            this.edtDienstag.Properties.Caption = "Di";
            this.edtDienstag.Size = new System.Drawing.Size(35, 19);
            this.edtDienstag.TabIndex = 2;
            this.edtDienstag.CheckedChanged += new System.EventHandler(this.edtDienstag_CheckedChanged);
            //
            // edtMittwoch
            //
            this.edtMittwoch.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtMittwoch.EditValue = false;
            this.edtMittwoch.Location = new System.Drawing.Point(163, 3);
            this.edtMittwoch.Name = "edtMittwoch";
            this.edtMittwoch.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtMittwoch.Properties.Appearance.Options.UseBackColor = true;
            this.edtMittwoch.Properties.Caption = "Mi";
            this.edtMittwoch.Size = new System.Drawing.Size(35, 19);
            this.edtMittwoch.TabIndex = 3;
            this.edtMittwoch.CheckedChanged += new System.EventHandler(this.edtMittwoch_CheckedChanged);
            //
            // edtDonnerstag
            //
            this.edtDonnerstag.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtDonnerstag.EditValue = false;
            this.edtDonnerstag.Location = new System.Drawing.Point(204, 3);
            this.edtDonnerstag.Name = "edtDonnerstag";
            this.edtDonnerstag.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtDonnerstag.Properties.Appearance.Options.UseBackColor = true;
            this.edtDonnerstag.Properties.Caption = "Do";
            this.edtDonnerstag.Size = new System.Drawing.Size(35, 19);
            this.edtDonnerstag.TabIndex = 4;
            this.edtDonnerstag.CheckedChanged += new System.EventHandler(this.edtDonnerstag_CheckedChanged);
            //
            // edtFreitag
            //
            this.edtFreitag.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtFreitag.EditValue = false;
            this.edtFreitag.Location = new System.Drawing.Point(245, 3);
            this.edtFreitag.Name = "edtFreitag";
            this.edtFreitag.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtFreitag.Properties.Appearance.Options.UseBackColor = true;
            this.edtFreitag.Properties.Caption = "Fr";
            this.edtFreitag.Size = new System.Drawing.Size(35, 19);
            this.edtFreitag.TabIndex = 5;
            this.edtFreitag.CheckedChanged += new System.EventHandler(this.edtFreitag_CheckedChanged);
            //
            // edtMontag
            //
            this.edtMontag.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtMontag.EditValue = false;
            this.edtMontag.Location = new System.Drawing.Point(81, 3);
            this.edtMontag.Name = "edtMontag";
            this.edtMontag.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtMontag.Properties.Appearance.Options.UseBackColor = true;
            this.edtMontag.Properties.Caption = "Mo";
            this.edtMontag.Size = new System.Drawing.Size(35, 19);
            this.edtMontag.TabIndex = 1;
            this.edtMontag.CheckedChanged += new System.EventHandler(this.edtMontag_CheckedChanged);
            //
            // lblWochentage
            //
            this.lblWochentage.ForeColor = System.Drawing.Color.Black;
            this.lblWochentage.Location = new System.Drawing.Point(-1, 0);
            this.lblWochentage.Name = "lblWochentage";
            this.lblWochentage.Size = new System.Drawing.Size(80, 24);
            this.lblWochentage.TabIndex = 0;
            this.lblWochentage.Text = "Wochentag(e)";
            //
            // panWochentagListe
            //
            this.panWochentagListe.Controls.Add(this.lblWochentag);
            this.panWochentagListe.Controls.Add(this.edtWochentag);
            this.panWochentagListe.Location = new System.Drawing.Point(522, 89);
            this.panWochentagListe.Name = "panWochentagListe";
            this.panWochentagListe.Size = new System.Drawing.Size(315, 25);
            this.panWochentagListe.TabIndex = 26;
            this.panWochentagListe.Visible = false;
            //
            // lblWochentag
            //
            this.lblWochentag.ForeColor = System.Drawing.Color.Black;
            this.lblWochentag.Location = new System.Drawing.Point(-1, 0);
            this.lblWochentag.Name = "lblWochentag";
            this.lblWochentag.Size = new System.Drawing.Size(80, 24);
            this.lblWochentag.TabIndex = 0;
            this.lblWochentag.Text = "Wochentag";
            //
            // edtWochentag
            //
            this.edtWochentag.AllowNull = false;
            this.edtWochentag.Location = new System.Drawing.Point(83, 0);
            this.edtWochentag.LOVFilter = "Code IN (1, 2, 3, 4, 5)";
            this.edtWochentag.LOVFilterWhereAppend = true;
            this.edtWochentag.LOVName = "Wochentag";
            this.edtWochentag.Name = "edtWochentag";
            this.edtWochentag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWochentag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWochentag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWochentag.Properties.Appearance.Options.UseBackColor = true;
            this.edtWochentag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWochentag.Properties.Appearance.Options.UseFont = true;
            this.edtWochentag.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtWochentag.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtWochentag.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtWochentag.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtWochentag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtWochentag.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtWochentag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtWochentag.Properties.NullText = "";
            this.edtWochentag.Properties.ShowFooter = false;
            this.edtWochentag.Properties.ShowHeader = false;
            this.edtWochentag.Size = new System.Drawing.Size(232, 24);
            this.edtWochentag.TabIndex = 24;
            this.edtWochentag.EditValueChanged += new System.EventHandler(this.edtWochentag_EditValueChanged);
            //
            // edtMandant
            //
            this.edtMandant.DataSource = this.qryFbBarauszahlungAuftrag;
            this.edtMandant.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtMandant.Location = new System.Drawing.Point(90, 61);
            this.edtMandant.Name = "edtMandant";
            this.edtMandant.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtMandant.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMandant.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMandant.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtMandant.Properties.Appearance.Options.UseBackColor = true;
            this.edtMandant.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMandant.Properties.Appearance.Options.UseFont = true;
            this.edtMandant.Properties.Appearance.Options.UseForeColor = true;
            this.edtMandant.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMandant.Properties.ReadOnly = true;
            this.edtMandant.Size = new System.Drawing.Size(206, 24);
            this.edtMandant.TabIndex = 5;
            //
            // lblNachbezug
            //
            this.lblNachbezug.ForeColor = System.Drawing.Color.Black;
            this.lblNachbezug.Location = new System.Drawing.Point(521, 145);
            this.lblNachbezug.Name = "lblNachbezug";
            this.lblNachbezug.Size = new System.Drawing.Size(72, 24);
            this.lblNachbezug.TabIndex = 28;
            this.lblNachbezug.Text = "Nachbezug";
            //
            // edtNachbezug
            //
            this.edtNachbezug.DataSource = this.qryFbBarauszahlungAuftrag;
            this.edtNachbezug.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtNachbezug.Location = new System.Drawing.Point(605, 145);
            this.edtNachbezug.Name = "edtNachbezug";
            this.edtNachbezug.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtNachbezug.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtNachbezug.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNachbezug.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNachbezug.Properties.Appearance.Options.UseBackColor = true;
            this.edtNachbezug.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNachbezug.Properties.Appearance.Options.UseFont = true;
            this.edtNachbezug.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNachbezug.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNachbezug.Properties.Mask.EditMask = "###0";
            this.edtNachbezug.Size = new System.Drawing.Size(60, 24);
            this.edtNachbezug.TabIndex = 29;
            //
            // panMonatstag
            //
            this.panMonatstag.Controls.Add(this.edtMonatstag2);
            this.panMonatstag.Controls.Add(this.lblMonatstag);
            this.panMonatstag.Controls.Add(this.edtMonatstag1);
            this.panMonatstag.Location = new System.Drawing.Point(524, 89);
            this.panMonatstag.Name = "panMonatstag";
            this.panMonatstag.Size = new System.Drawing.Size(313, 25);
            this.panMonatstag.TabIndex = 24;
            this.panMonatstag.Visible = false;
            //
            // edtMonatstag2
            //
            this.edtMonatstag2.DataSource = this.qryFbBarauszahlungZyklus;
            this.edtMonatstag2.Location = new System.Drawing.Point(153, 0);
            this.edtMonatstag2.Name = "edtMonatstag2";
            this.edtMonatstag2.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtMonatstag2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMonatstag2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMonatstag2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMonatstag2.Properties.Appearance.Options.UseBackColor = true;
            this.edtMonatstag2.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMonatstag2.Properties.Appearance.Options.UseFont = true;
            this.edtMonatstag2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMonatstag2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtMonatstag2.Size = new System.Drawing.Size(60, 24);
            this.edtMonatstag2.TabIndex = 2;
            this.edtMonatstag2.EditValueChanged += new System.EventHandler(this.edtMonatstag2_EditValueChanged);
            //
            // qryFbBarauszahlungZyklus
            //
            this.qryFbBarauszahlungZyklus.CanDelete = true;
            this.qryFbBarauszahlungZyklus.CanInsert = true;
            this.qryFbBarauszahlungZyklus.CanUpdate = true;
            this.qryFbBarauszahlungZyklus.HostControl = this;
            this.qryFbBarauszahlungZyklus.SelectStatement = resources.GetString("qryFbBarauszahlungZyklus.SelectStatement");
            this.qryFbBarauszahlungZyklus.TableName = "FbBarauszahlungZyklus";
            //
            // lblMonatstag
            //
            this.lblMonatstag.ForeColor = System.Drawing.Color.Black;
            this.lblMonatstag.Location = new System.Drawing.Point(-3, 0);
            this.lblMonatstag.Name = "lblMonatstag";
            this.lblMonatstag.Size = new System.Drawing.Size(72, 24);
            this.lblMonatstag.TabIndex = 0;
            this.lblMonatstag.Text = "Monatstag(e)";
            //
            // edtMonatstag1
            //
            this.edtMonatstag1.DataSource = this.qryFbBarauszahlungZyklus;
            this.edtMonatstag1.Location = new System.Drawing.Point(81, 0);
            this.edtMonatstag1.Name = "edtMonatstag1";
            this.edtMonatstag1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtMonatstag1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMonatstag1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMonatstag1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMonatstag1.Properties.Appearance.Options.UseBackColor = true;
            this.edtMonatstag1.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMonatstag1.Properties.Appearance.Options.UseFont = true;
            this.edtMonatstag1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMonatstag1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtMonatstag1.Size = new System.Drawing.Size(60, 24);
            this.edtMonatstag1.TabIndex = 1;
            this.edtMonatstag1.EditValueChanged += new System.EventHandler(this.edtMonatstag1_EditValueChanged);
            //
            // lblVorbezug
            //
            this.lblVorbezug.ForeColor = System.Drawing.Color.Black;
            this.lblVorbezug.Location = new System.Drawing.Point(521, 117);
            this.lblVorbezug.Name = "lblVorbezug";
            this.lblVorbezug.Size = new System.Drawing.Size(72, 24);
            this.lblVorbezug.TabIndex = 26;
            this.lblVorbezug.Text = "Vorbezug";
            //
            // edtVorbezug
            //
            this.edtVorbezug.DataSource = this.qryFbBarauszahlungAuftrag;
            this.edtVorbezug.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtVorbezug.Location = new System.Drawing.Point(605, 117);
            this.edtVorbezug.Name = "edtVorbezug";
            this.edtVorbezug.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVorbezug.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtVorbezug.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVorbezug.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVorbezug.Properties.Appearance.Options.UseBackColor = true;
            this.edtVorbezug.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVorbezug.Properties.Appearance.Options.UseFont = true;
            this.edtVorbezug.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVorbezug.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVorbezug.Properties.Mask.EditMask = "###0";
            this.edtVorbezug.Size = new System.Drawing.Size(60, 24);
            this.edtVorbezug.TabIndex = 27;
            //
            // edtModifier
            //
            this.edtModifier.DataSource = this.qryFbBarauszahlungAuftrag;
            this.edtModifier.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtModifier.Location = new System.Drawing.Point(90, 33);
            this.edtModifier.Name = "edtModifier";
            this.edtModifier.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtModifier.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtModifier.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtModifier.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtModifier.Properties.Appearance.Options.UseBackColor = true;
            this.edtModifier.Properties.Appearance.Options.UseBorderColor = true;
            this.edtModifier.Properties.Appearance.Options.UseFont = true;
            this.edtModifier.Properties.Appearance.Options.UseForeColor = true;
            this.edtModifier.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtModifier.Properties.ReadOnly = true;
            this.edtModifier.Size = new System.Drawing.Size(206, 24);
            this.edtModifier.TabIndex = 3;
            //
            // lblModifier
            //
            this.lblModifier.ForeColor = System.Drawing.Color.Black;
            this.lblModifier.Location = new System.Drawing.Point(5, 33);
            this.lblModifier.Name = "lblModifier";
            this.lblModifier.Size = new System.Drawing.Size(77, 24);
            this.lblModifier.TabIndex = 2;
            this.lblModifier.Text = "Geändert von";
            //
            // edtCreator
            //
            this.edtCreator.DataSource = this.qryFbBarauszahlungAuftrag;
            this.edtCreator.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtCreator.Location = new System.Drawing.Point(90, 5);
            this.edtCreator.Name = "edtCreator";
            this.edtCreator.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtCreator.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtCreator.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtCreator.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtCreator.Properties.Appearance.Options.UseBackColor = true;
            this.edtCreator.Properties.Appearance.Options.UseBorderColor = true;
            this.edtCreator.Properties.Appearance.Options.UseFont = true;
            this.edtCreator.Properties.Appearance.Options.UseForeColor = true;
            this.edtCreator.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtCreator.Properties.ReadOnly = true;
            this.edtCreator.Size = new System.Drawing.Size(206, 24);
            this.edtCreator.TabIndex = 1;
            //
            // lblCreator
            //
            this.lblCreator.ForeColor = System.Drawing.Color.Black;
            this.lblCreator.Location = new System.Drawing.Point(5, 5);
            this.lblCreator.Name = "lblCreator";
            this.lblCreator.Size = new System.Drawing.Size(79, 24);
            this.lblCreator.TabIndex = 0;
            this.lblCreator.Text = "Erfasst von";
            //
            // lblDocument
            //
            this.lblDocument.Location = new System.Drawing.Point(521, 173);
            this.lblDocument.Name = "lblDocument";
            this.lblDocument.Size = new System.Drawing.Size(66, 24);
            this.lblDocument.TabIndex = 30;
            this.lblDocument.Text = "Dokument";
            //
            // edtDocument
            //
            this.edtDocument.AllowDrop = true;
            this.edtDocument.Context = "FbDauerauftrag";
            this.edtDocument.DataSource = this.qryFbBarauszahlungAuftrag;
            this.edtDocument.EditValue = "";
            this.edtDocument.Location = new System.Drawing.Point(605, 173);
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocument.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocument.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "Dokument importieren")});
            this.edtDocument.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDocument.Properties.ReadOnly = true;
            this.edtDocument.Size = new System.Drawing.Size(132, 24);
            this.edtDocument.TabIndex = 31;
            //
            // edtBuchungstext
            //
            this.edtBuchungstext.DataSource = this.qryFbBarauszahlungAuftrag;
            this.edtBuchungstext.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtBuchungstext.Location = new System.Drawing.Point(90, 173);
            this.edtBuchungstext.Name = "edtBuchungstext";
            this.edtBuchungstext.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtBuchungstext.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchungstext.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchungstext.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtBuchungstext.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchungstext.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchungstext.Properties.Appearance.Options.UseFont = true;
            this.edtBuchungstext.Properties.Appearance.Options.UseForeColor = true;
            this.edtBuchungstext.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBuchungstext.Size = new System.Drawing.Size(409, 24);
            this.edtBuchungstext.TabIndex = 17;
            //
            // lblBuchungstext
            //
            this.lblBuchungstext.ForeColor = System.Drawing.Color.Black;
            this.lblBuchungstext.Location = new System.Drawing.Point(5, 173);
            this.lblBuchungstext.Name = "lblBuchungstext";
            this.lblBuchungstext.Size = new System.Drawing.Size(79, 24);
            this.lblBuchungstext.TabIndex = 16;
            this.lblBuchungstext.Text = "Buchungstext";
            //
            // edtSollKontoNr
            //
            this.edtSollKontoNr.DataSource = this.qryFbBarauszahlungAuftrag;
            this.edtSollKontoNr.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtSollKontoNr.Location = new System.Drawing.Point(90, 89);
            this.edtSollKontoNr.Name = "edtSollKontoNr";
            this.edtSollKontoNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtSollKontoNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSollKontoNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSollKontoNr.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtSollKontoNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSollKontoNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSollKontoNr.Properties.Appearance.Options.UseFont = true;
            this.edtSollKontoNr.Properties.Appearance.Options.UseForeColor = true;
            this.edtSollKontoNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtSollKontoNr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtSollKontoNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSollKontoNr.Size = new System.Drawing.Size(90, 24);
            this.edtSollKontoNr.TabIndex = 9;
            this.edtSollKontoNr.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSollKontoNr_UserModifiedFld);
            //
            // edtHabenKontoName
            //
            this.edtHabenKontoName.DataSource = this.qryFbBarauszahlungAuftrag;
            this.edtHabenKontoName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtHabenKontoName.Location = new System.Drawing.Point(186, 117);
            this.edtHabenKontoName.Name = "edtHabenKontoName";
            this.edtHabenKontoName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtHabenKontoName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHabenKontoName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHabenKontoName.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtHabenKontoName.Properties.Appearance.Options.UseBackColor = true;
            this.edtHabenKontoName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHabenKontoName.Properties.Appearance.Options.UseFont = true;
            this.edtHabenKontoName.Properties.Appearance.Options.UseForeColor = true;
            this.edtHabenKontoName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHabenKontoName.Properties.ReadOnly = true;
            this.edtHabenKontoName.Size = new System.Drawing.Size(312, 24);
            this.edtHabenKontoName.TabIndex = 13;
            this.edtHabenKontoName.TabStop = false;
            //
            // edtSollKontoName
            //
            this.edtSollKontoName.DataSource = this.qryFbBarauszahlungAuftrag;
            this.edtSollKontoName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtSollKontoName.Location = new System.Drawing.Point(186, 89);
            this.edtSollKontoName.Name = "edtSollKontoName";
            this.edtSollKontoName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSollKontoName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSollKontoName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSollKontoName.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtSollKontoName.Properties.Appearance.Options.UseBackColor = true;
            this.edtSollKontoName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSollKontoName.Properties.Appearance.Options.UseFont = true;
            this.edtSollKontoName.Properties.Appearance.Options.UseForeColor = true;
            this.edtSollKontoName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSollKontoName.Properties.ReadOnly = true;
            this.edtSollKontoName.Size = new System.Drawing.Size(312, 24);
            this.edtSollKontoName.TabIndex = 10;
            this.edtSollKontoName.TabStop = false;
            //
            // edtHabenKontoNr
            //
            this.edtHabenKontoNr.DataSource = this.qryFbBarauszahlungAuftrag;
            this.edtHabenKontoNr.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtHabenKontoNr.Location = new System.Drawing.Point(90, 117);
            this.edtHabenKontoNr.Name = "edtHabenKontoNr";
            this.edtHabenKontoNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtHabenKontoNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHabenKontoNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHabenKontoNr.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtHabenKontoNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtHabenKontoNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHabenKontoNr.Properties.Appearance.Options.UseFont = true;
            this.edtHabenKontoNr.Properties.Appearance.Options.UseForeColor = true;
            this.edtHabenKontoNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtHabenKontoNr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtHabenKontoNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtHabenKontoNr.Size = new System.Drawing.Size(90, 24);
            this.edtHabenKontoNr.TabIndex = 12;
            this.edtHabenKontoNr.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtHabenKontoNr_UserModifiedFld);
            //
            // edtPeriodizitaet
            //
            this.edtPeriodizitaet.AllowNull = false;
            this.edtPeriodizitaet.DataSource = this.qryFbBarauszahlungAuftrag;
            this.edtPeriodizitaet.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtPeriodizitaet.Location = new System.Drawing.Point(605, 33);
            this.edtPeriodizitaet.LOVName = "FbBarauszahlungPeriodizitaet";
            this.edtPeriodizitaet.Name = "edtPeriodizitaet";
            this.edtPeriodizitaet.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtPeriodizitaet.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPeriodizitaet.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPeriodizitaet.Properties.Appearance.Options.UseBackColor = true;
            this.edtPeriodizitaet.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPeriodizitaet.Properties.Appearance.Options.UseFont = true;
            this.edtPeriodizitaet.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtPeriodizitaet.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtPeriodizitaet.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtPeriodizitaet.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtPeriodizitaet.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtPeriodizitaet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtPeriodizitaet.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPeriodizitaet.Properties.NullText = "";
            this.edtPeriodizitaet.Properties.ShowFooter = false;
            this.edtPeriodizitaet.Properties.ShowHeader = false;
            this.edtPeriodizitaet.Size = new System.Drawing.Size(232, 24);
            this.edtPeriodizitaet.TabIndex = 19;
            this.edtPeriodizitaet.EditValueChanged += new System.EventHandler(this.edtPeriodizitaet_EditValueChanged);
            //
            // lblDatumBis
            //
            this.lblDatumBis.ForeColor = System.Drawing.Color.Black;
            this.lblDatumBis.Location = new System.Drawing.Point(711, 61);
            this.lblDatumBis.Name = "lblDatumBis";
            this.lblDatumBis.Size = new System.Drawing.Size(20, 24);
            this.lblDatumBis.TabIndex = 22;
            this.lblDatumBis.Text = "bis";
            //
            // edtDatumBis
            //
            this.edtDatumBis.DataSource = this.qryFbBarauszahlungAuftrag;
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(737, 61);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 23;
            //
            // lblPeriodizitaet
            //
            this.lblPeriodizitaet.ForeColor = System.Drawing.Color.Black;
            this.lblPeriodizitaet.Location = new System.Drawing.Point(521, 33);
            this.lblPeriodizitaet.Name = "lblPeriodizitaet";
            this.lblPeriodizitaet.Size = new System.Drawing.Size(80, 24);
            this.lblPeriodizitaet.TabIndex = 18;
            this.lblPeriodizitaet.Text = "Periodizität";
            //
            // lblDatumVon
            //
            this.lblDatumVon.ForeColor = System.Drawing.Color.Black;
            this.lblDatumVon.Location = new System.Drawing.Point(521, 61);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(70, 24);
            this.lblDatumVon.TabIndex = 20;
            this.lblDatumVon.Text = "Gültig von";
            //
            // edtDatumVon
            //
            this.edtDatumVon.DataSource = this.qryFbBarauszahlungAuftrag;
            this.edtDatumVon.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(605, 61);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 21;
            this.edtDatumVon.EditValueChanged += new System.EventHandler(this.edtDatumVon_EditValueChanged);
            //
            // edtMandantNr
            //
            this.edtMandantNr.DataSource = this.qryFbBarauszahlungAuftrag;
            this.edtMandantNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtMandantNr.Location = new System.Drawing.Point(299, 61);
            this.edtMandantNr.Name = "edtMandantNr";
            this.edtMandantNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtMandantNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMandantNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMandantNr.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtMandantNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtMandantNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMandantNr.Properties.Appearance.Options.UseFont = true;
            this.edtMandantNr.Properties.Appearance.Options.UseForeColor = true;
            this.edtMandantNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMandantNr.Properties.ReadOnly = true;
            this.edtMandantNr.Size = new System.Drawing.Size(57, 24);
            this.edtMandantNr.TabIndex = 6;
            this.edtMandantNr.TabStop = false;
            //
            // edtBetrag
            //
            this.edtBetrag.DataSource = this.qryFbBarauszahlungAuftrag;
            this.edtBetrag.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtBetrag.Location = new System.Drawing.Point(90, 145);
            this.edtBetrag.Name = "edtBetrag";
            this.edtBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBetrag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetrag.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtBetrag.Properties.Appearance.Options.UseForeColor = true;
            this.edtBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetrag.Properties.DisplayFormat.FormatString = "n2";
            this.edtBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Properties.EditFormat.FormatString = "n2";
            this.edtBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Size = new System.Drawing.Size(132, 24);
            this.edtBetrag.TabIndex = 15;
            //
            // edtMandantPlzOrt
            //
            this.edtMandantPlzOrt.DataSource = this.qryFbBarauszahlungAuftrag;
            this.edtMandantPlzOrt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtMandantPlzOrt.Location = new System.Drawing.Point(359, 61);
            this.edtMandantPlzOrt.Name = "edtMandantPlzOrt";
            this.edtMandantPlzOrt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtMandantPlzOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMandantPlzOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMandantPlzOrt.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtMandantPlzOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtMandantPlzOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMandantPlzOrt.Properties.Appearance.Options.UseFont = true;
            this.edtMandantPlzOrt.Properties.Appearance.Options.UseForeColor = true;
            this.edtMandantPlzOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMandantPlzOrt.Properties.ReadOnly = true;
            this.edtMandantPlzOrt.Size = new System.Drawing.Size(139, 24);
            this.edtMandantPlzOrt.TabIndex = 7;
            this.edtMandantPlzOrt.TabStop = false;
            //
            // lblBetrag
            //
            this.lblBetrag.ForeColor = System.Drawing.Color.Black;
            this.lblBetrag.Location = new System.Drawing.Point(5, 145);
            this.lblBetrag.Name = "lblBetrag";
            this.lblBetrag.Size = new System.Drawing.Size(79, 24);
            this.lblBetrag.TabIndex = 14;
            this.lblBetrag.Text = "Betrag CHF";
            //
            // lblHaben
            //
            this.lblHaben.ForeColor = System.Drawing.Color.Black;
            this.lblHaben.Location = new System.Drawing.Point(5, 117);
            this.lblHaben.Name = "lblHaben";
            this.lblHaben.Size = new System.Drawing.Size(79, 24);
            this.lblHaben.TabIndex = 11;
            this.lblHaben.Text = "Haben";
            //
            // lblSoll
            //
            this.lblSoll.ForeColor = System.Drawing.Color.Black;
            this.lblSoll.Location = new System.Drawing.Point(5, 86);
            this.lblSoll.Name = "lblSoll";
            this.lblSoll.Size = new System.Drawing.Size(79, 24);
            this.lblSoll.TabIndex = 8;
            this.lblSoll.Text = "Soll";
            //
            // lblMandant
            //
            this.lblMandant.ForeColor = System.Drawing.Color.Black;
            this.lblMandant.Location = new System.Drawing.Point(5, 61);
            this.lblMandant.Name = "lblMandant";
            this.lblMandant.Size = new System.Drawing.Size(79, 24);
            this.lblMandant.TabIndex = 4;
            this.lblMandant.Text = "Mandant";
            //
            // lblSaldo
            //
            this.lblSaldo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSaldo.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblSaldo.Location = new System.Drawing.Point(524, 334);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(325, 16);
            this.lblSaldo.TabIndex = 360;
            this.lblSaldo.Text = "Saldo";
            this.lblSaldo.Visible = false;
            //
            // picTitel
            //
            this.picTitel.Location = new System.Drawing.Point(6, 11);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 362;
            this.picTitel.TabStop = false;
            //
            // lblTitel
            //
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(26, 11);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(542, 19);
            this.lblTitel.TabIndex = 361;
            this.lblTitel.Text = "Geplante Barauszahlungen";
            this.lblTitel.UseCompatibleTextRendering = true;
            //
            // edtSearchPeriodizitaet
            //
            this.edtSearchPeriodizitaet.DataSource = this.qryFbBarauszahlungAuftrag;
            this.edtSearchPeriodizitaet.Location = new System.Drawing.Point(117, 100);
            this.edtSearchPeriodizitaet.LOVName = "FbBarauszahlungPeriodizitaet";
            this.edtSearchPeriodizitaet.Name = "edtSearchPeriodizitaet";
            this.edtSearchPeriodizitaet.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSearchPeriodizitaet.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSearchPeriodizitaet.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchPeriodizitaet.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchPeriodizitaet.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSearchPeriodizitaet.Properties.Appearance.Options.UseFont = true;
            this.edtSearchPeriodizitaet.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSearchPeriodizitaet.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchPeriodizitaet.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSearchPeriodizitaet.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSearchPeriodizitaet.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtSearchPeriodizitaet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.edtSearchPeriodizitaet.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSearchPeriodizitaet.Properties.NullText = "";
            this.edtSearchPeriodizitaet.Properties.ShowFooter = false;
            this.edtSearchPeriodizitaet.Properties.ShowHeader = false;
            this.edtSearchPeriodizitaet.Size = new System.Drawing.Size(233, 24);
            this.edtSearchPeriodizitaet.TabIndex = 24;
            //
            // qryPerson
            //
            this.qryPerson.HostControl = this;
            this.qryPerson.SelectStatement = "SELECT  BaPersonID,\r\n        NameVorname,\r\n        GeschlechtCode,\r\n        PLZOr" +
                "t = ISNULL(WohnsitzPLZ + \' \' , \'\') + ISNULL(WohnsitzOrt, \'\')\r\nFROM vwPerson\r\nWHE" +
                "RE BaPersonID = {0}";
            //
            // qrySaldoKasse
            //
            this.qrySaldoKasse.HostControl = this;
            this.qrySaldoKasse.SelectStatement = resources.GetString("qrySaldoKasse.SelectStatement");
            //
            // qryPeriode
            //
            this.qryPeriode.HostControl = this;
            this.qryPeriode.SelectStatement = resources.GetString("qryPeriode.SelectStatement");
            //
            // qryKonto
            //
            this.qryKonto.HostControl = this;
            this.qryKonto.SelectStatement = resources.GetString("qryKonto.SelectStatement");
            //
            // CtlVmBarauszahlungGeplant
            //
            this.ActiveSQLQuery = this.qryFbBarauszahlungAuftrag;
            this.AutoRefresh = false;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(855, 569);

            this.Controls.Add(this.picTitel);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.lblSaldo);
            this.Controls.Add(this.panDetail);
            this.Name = "CtlVmBarauszahlungGeplant";
            this.Size = new System.Drawing.Size(855, 569);
            this.Load += new System.EventHandler(this.CtlVmBarauszahlungGeplant_Load);
            this.Controls.SetChildIndex(this.panDetail, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.lblSaldo, 0);
            this.Controls.SetChildIndex(this.lblTitel, 0);
            this.Controls.SetChildIndex(this.picTitel, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qryFbBarauszahlungAuftrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFbDauerauftrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFbDauerauftrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchNurAktive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchPeriodizitaet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchBetragBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchBetragVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchBetragBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchBetragVon)).EndInit();
            this.panDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblAuftragId)).EndInit();
            this.panWochentag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtDienstag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMittwoch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDonnerstag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFreitag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMontag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWochentage)).EndInit();
            this.panWochentagListe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblWochentag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWochentag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWochentag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMandant.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNachbezug)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNachbezug.Properties)).EndInit();
            this.panMonatstag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtMonatstag2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFbBarauszahlungZyklus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMonatstag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMonatstag1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorbezug)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorbezug.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModifier.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModifier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCreator.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCreator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDocument.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollKontoNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHabenKontoName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollKontoName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHabenKontoNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPeriodizitaet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPeriodizitaet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPeriodizitaet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMandantNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMandantPlzOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHaben)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSaldo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchPeriodizitaet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchPeriodizitaet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrySaldoKasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPeriode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKonto)).EndInit();
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

        #region Properties

        private bool AuszahlungenVorhanden
        {
            get { return (bool)qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.AuszahlungenVorhanden]; }
        }

        #endregion

        #region EventHandlers

        private void btnAuftragKopieren_Click(object sender, EventArgs e)
        {
            if (!qryFbBarauszahlungAuftrag.CanInsert)
            {
                KissMsg.ShowInfo(Name, "AuftragKopierenCanInsertFalse", "Diese Funktionalität steht aufgrund fehlender Benutzerrechte nicht zur Verfügung.");
                return;
            }

            var datumBis = qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.DatumBis] as DateTime?;

            if ((!datumBis.HasValue || datumBis.Value > DateTime.Today) && edtDatumBis.EditMode != EditModeType.ReadOnly)
            {
                //Frage ob alter Auftrag abgeschhlossen werden soll
                bool abschliessen = KissMsg.ShowQuestion(Name, "AuftragAbschliessenJaNein", "Soll der ursprüngliche Barauszahlungsauftrag abgeschlossen werden?", true);

                if (abschliessen)
                {
                    if (AuszahlungenVorhanden)
                    {
                        qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.DatumBis] = qryFbBarauszahlungAuftrag[QBAA_LETZTE_AUSZAHLUNG];
                    }
                    else
                    {
                        qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.DatumBis] = DateTime.Today;
                    }

                    if (!qryFbBarauszahlungAuftrag.Post())
                    {
                        return;
                    }
                }
            }

            // Daten aus den periodizitätscontrols zwischenspeichern
            IList<DevExpress.XtraEditors.BaseEdit> controls = new List<DevExpress.XtraEditors.BaseEdit>();
            controls.Add(edtWochentag);
            controls.Add(edtMonatstag1);
            controls.Add(edtMonatstag2);
            controls.Add(edtMontag);
            controls.Add(edtDienstag);
            controls.Add(edtMittwoch);
            controls.Add(edtDonnerstag);
            controls.Add(edtFreitag);

            var zwischenspeicher = new Dictionary<string, object>();

            foreach (var ctl in controls)
            {
                if (ctl is DevExpress.XtraEditors.BaseEdit && !string.IsNullOrEmpty(ctl.Name))
                {
                    zwischenspeicher.Add(ctl.Name, ((DevExpress.XtraEditors.BaseEdit)ctl).EditValue);
                }
            }

            controls.Clear();

            // Daten aus aktuellem Auftrag zwischenspeichern und im neuen Eintrag kopieren
            DataRow originalRow = qryFbBarauszahlungAuftrag.Row;

            qryFbBarauszahlungAuftrag.Insert();

            qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.Betrag] = originalRow[DBO.FbBarauszahlungAuftrag.Betrag];
            qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.SollKtoNr] = originalRow[DBO.FbBarauszahlungAuftrag.SollKtoNr];
            qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.HabenKtoNr] = originalRow[DBO.FbBarauszahlungAuftrag.HabenKtoNr];
            qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.Buchungstext] = originalRow[DBO.FbBarauszahlungAuftrag.Buchungstext];
            qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.FbBarauszahlungPeriodizitaetCode] = originalRow[DBO.FbBarauszahlungAuftrag.FbBarauszahlungPeriodizitaetCode];
            qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.Vorbezug] = originalRow[DBO.FbBarauszahlungAuftrag.Vorbezug];
            qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.Nachbezug] = originalRow[DBO.FbBarauszahlungAuftrag.Nachbezug];
            qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.DatumVon] = DateTime.Today;

            controls.Add(edtWochentag);
            controls.Add(edtMonatstag1);
            controls.Add(edtMonatstag2);
            controls.Add(edtMontag);
            controls.Add(edtDienstag);
            controls.Add(edtMittwoch);
            controls.Add(edtDonnerstag);
            controls.Add(edtFreitag);

            // Zwischengespeicherte Daten in neuen Eintrag kopieren
            foreach (Control ctl in controls)
            {
                if (ctl is DevExpress.XtraEditors.BaseEdit)
                {
                    string tempName = string.Empty;

                    foreach (KeyValuePair<string, object> keyValuePair in zwischenspeicher)
                    {
                        if (ctl.Name.Equals(keyValuePair.Key) && ctl is DevExpress.XtraEditors.BaseEdit)
                        {
                            if (((IKissEditable)ctl).EditMode != EditModeType.ReadOnly && ctl.Visible == true)
                            {
                                ((DevExpress.XtraEditors.BaseEdit)ctl).EditValue = keyValuePair.Value;
                            }

                            tempName = ctl.Name;
                            break;
                        }
                    }

                    if (!string.IsNullOrEmpty(tempName))
                    {
                        zwischenspeicher.Remove(tempName);
                    }
                }
            }
        }

        private void CtlVmBarauszahlungGeplant_Load(object sender, EventArgs e)
        {
            this.kissSearch.SelectParameters = new object[] { _FaLeistungID };
            SetupDataMembers();
            SetupFieldNames();
            SetupTags();

            _countRemoveZyklusFieldsEvents = 0;
            this.edtDatumVon.EditValueChanged -= new System.EventHandler(this.edtDatumVon_EditValueChanged);
            this.edtPeriodizitaet.EditValueChanged -= new System.EventHandler(this.edtPeriodizitaet_EditValueChanged);

            _leistungIsActive = LeistungIsActive(_FaLeistungID);
            if (_leistungIsActive)
            {
                edtSearchNurAktive.Checked = true;
            }
            else
            {
                edtSearchNurAktive.Checked = false;
            }

            this.kissSearch.OnRunSearch();

            if (!_leistungIsActive)
            {
                qryFbBarauszahlungAuftrag.CanDelete = false;
                qryFbBarauszahlungAuftrag.CanInsert = false;
                qryFbBarauszahlungAuftrag.CanUpdate = false;
            }

            // doesn't work if it's set in the designer!
            grvFbDauerauftrag.OptionsView.ColumnAutoWidth = true;
        }

        private void edtDatumVon_EditValueChanged(object sender, EventArgs e)
        {
            if (!qryFbBarauszahlungAuftrag.IsEmpty)
            {
                SetMonatstag();
            }
        }

        private void edtDienstag_CheckedChanged(object sender, EventArgs e)
        {
            qryFbBarauszahlungAuftrag.RowModified = true;
        }

        private void edtDonnerstag_CheckedChanged(object sender, EventArgs e)
        {
            qryFbBarauszahlungAuftrag.RowModified = true;
        }

        private void edtFreitag_CheckedChanged(object sender, EventArgs e)
        {
            qryFbBarauszahlungAuftrag.RowModified = true;
        }

        private void edtHabenKontoNr_UserModifiedFld(Object sender, UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();

            e.Cancel = !dlg.PeriodenKontoSuchen(
                edtHabenKontoNr.Text,
                this.edtMandantNr.Text,
                DateTime.Now,
                e.ButtonClicked);

            if (!e.Cancel)
            {
                qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.HabenKtoNr] = dlg["KontoNr"];
                qryFbBarauszahlungAuftrag[QBAA_HABEN_KTO_NR_NAME] = dlg["KontoName"];
            }
        }

        private void edtMittwoch_CheckedChanged(object sender, EventArgs e)
        {
            qryFbBarauszahlungAuftrag.RowModified = true;
        }

        private void edtMonatstag1_EditValueChanged(object sender, EventArgs e)
        {
            qryFbBarauszahlungAuftrag.RowModified = true;
        }

        private void edtMonatstag2_EditValueChanged(object sender, EventArgs e)
        {
            qryFbBarauszahlungAuftrag.RowModified = true;
        }

        private void edtMontag_CheckedChanged(object sender, EventArgs e)
        {
            qryFbBarauszahlungAuftrag.RowModified = true;
        }

        private void edtPeriodizitaet_EditValueChanged(object sender, EventArgs e)
        {
            if (this.edtPeriodizitaet.EditValue != DBNull.Value)
            {
                ResetZyklusFields();
                FbBarauszahlungPeriodizitaet periodizitaet = (FbBarauszahlungPeriodizitaet)Enum.Parse(typeof(FbBarauszahlungPeriodizitaet), edtPeriodizitaet.EditValue.ToString(), true);
                SelectPeriodizitaetFields(periodizitaet);
                SetDefaultValues(periodizitaet);
            }
        }

        private void edtSollKontoNr_UserModifiedFld(Object sender, UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();

            e.Cancel = !dlg.PeriodenKontoSuchen(
                edtSollKontoNr.Text,
                this.edtMandantNr.Text,
                DateTime.Now,
                e.ButtonClicked);
            if (!e.Cancel)
            {
                qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.SollKtoNr] = dlg["KontoNr"];
                qryFbBarauszahlungAuftrag[QBAA_SOLL_KTO_NR_NAME] = dlg["KontoName"];
            }
        }

        private void edtWochentag_EditValueChanged(object sender, EventArgs e)
        {
            qryFbBarauszahlungAuftrag.RowModified = true;
        }

        private void qryFbBarauszahlungAuftrag_AfterDelete(object sender, EventArgs e)
        {
            ShowInfoBudgetAktualisieren();
        }

        private void qryFbBarauszahlungAuftrag_AfterInsert(Object sender, EventArgs e)
        {
            edtMonatstag1.EditMode = EditModeType.Normal;
            edtMonatstag2.EditMode = EditModeType.Normal;
            edtWochentag.EditMode = EditModeType.Normal;

            InitQueryFields();

            edtSollKontoNr.Focus();
            qryFbBarauszahlungAuftrag.RowModified = true;
        }

        private void qryFbBarauszahlungAuftrag_AfterPost(object sender, EventArgs e)
        {
            ShowInfoBudgetAktualisieren();
            if (!(bool)qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.AuszahlungenVorhanden])
            {
                SetZyklus();
            }
        }

        private void qryFbBarauszahlungAuftrag_BeforeDelete(object sender, EventArgs e)
        {
            // delete Zyklus
            SqlQuery qry = new SqlQuery();
            bool result = qry.Fill(string.Format("DELETE FbBarauszahlungZyklus WHERE FbBarauszahlungAuftragID = {0}", qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.FbBarauszahlungAuftragID]));
        }

        private void qryFbBarauszahlungAuftrag_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            if ((bool)qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.AuszahlungenVorhanden])
            {
                // show message
                KissMsg.ShowInfo(this.Name, "AuszahlungenVorhanden", "Die geplante Barauszahlung kann nicht gelöscht werden, weil bereits eine Auszahlung erfolgte!");

                // cancel
                throw new KissCancelException();
            }
        }

        private void qryFbBarauszahlungAuftrag_BeforeInsert(object sender, EventArgs e)
        {
            qryPeriode.Fill(_BaPersonID, DateTime.Now);
            if (qryPeriode.IsEmpty)
            {
                throw new KissInfoException(KissMsg.GetMLMessage(this.Name, "KeinePeriodeInfo", "Es existiert keine aktive Periode für den Mandanten."));
            }
        }

        private void qryFbBarauszahlungAuftrag_BeforePost(Object sender, EventArgs e)
        {
            if (!qryFbBarauszahlungAuftrag.IsSilentPostingFromXDocument)
            {
                CheckNotNullFields();
                CheckValue();
                if (qryPeriode.IsEmpty)
                {
                    qryFbBarauszahlungAuftrag[QBAA_FB_BARAUSZAHLUNG_STATUS_CODE] = FbBarauszahlungStatus.KeinePeriodeVorhanden;
                }
                else if ((bool)qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.AuszahlungenVorhanden])
                {
                    qryFbBarauszahlungAuftrag[QBAA_FB_BARAUSZAHLUNG_STATUS_CODE] = FbBarauszahlungStatus.AuszahlungenVorhanden;
                }
                else
                {
                    qryFbBarauszahlungAuftrag[QBAA_FB_BARAUSZAHLUNG_STATUS_CODE] = FbBarauszahlungStatus.KeineAuszahlungenVorhanden;
                }

                SetAuftragModifier();
            }
        }

        private void qryFbBarauszahlungAuftrag_PositionChanged(object sender, EventArgs e)
        {
            _countRemoveZyklusFieldsEvents = 0;
            if (qryFbBarauszahlungAuftrag.IsFilling)
            {
                return;
            }

            if (qryFbBarauszahlungAuftrag.IsEmpty)
            {
                lblSaldo.Visible = false;
                panDetail.Visible = false;
                ResetZyklusFields();
                SetEditModeAllReadOnly();
                grvFbDauerauftrag.Focus();
                SetAuftragKopierenEnable(false);
            }
            else
            {
                lblSaldo.Visible = true;

                panDetail.Visible = true;

                GetSaldoKasse();

                FbBarauszahlungPeriodizitaet periodizitaet;

                if (qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.FbBarauszahlungPeriodizitaetCode] == DBNull.Value)
                {
                    periodizitaet = FbBarauszahlungPeriodizitaet.Jaehrlich;
                }
                else
                {
                    periodizitaet = (FbBarauszahlungPeriodizitaet)qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.FbBarauszahlungPeriodizitaetCode];
                }

                SetEditMode(periodizitaet, AuszahlungenVorhanden);

                GetZyklus(periodizitaet);
                lblAuftragId.Text = string.Format("ID: {0}", qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.FbBarauszahlungAuftragID]);
            }

            edtDatumVon.EditValueChanged += new System.EventHandler(this.edtDatumVon_EditValueChanged);
            edtPeriodizitaet.EditValueChanged += new System.EventHandler(this.edtPeriodizitaet_EditValueChanged);
        }

        private void qryFbBarauszahlungAuftrag_PositionChanging(object sender, EventArgs e)
        {
            this.edtDatumVon.EditValueChanged -= new System.EventHandler(this.edtDatumVon_EditValueChanged);
            this.edtPeriodizitaet.EditValueChanged -= new System.EventHandler(this.edtPeriodizitaet_EditValueChanged);
        }

        private void tabControlSearch_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            if (tabControlSearch.SelectedTab == tpgListe && !qryFbBarauszahlungAuftrag.IsEmpty)
            {
                panDetail.Visible = true;
            }
            else
            {
                panDetail.Visible = false;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Init(string titleName, Image titleImage, int faLeistungID, int baPersonID)
        {
            this.picTitel.Image = titleImage;
            _FaLeistungID = faLeistungID;
            _BaPersonID = baPersonID;
        }

        public override bool ReceiveMessage(HybridDictionary parameters)
        {
            var result = base.ReceiveMessage(parameters);
            if (!result)
            {
                NewSearch();
                edtSearchNurAktive.Checked = false;
                OnSearch();

                result = base.ReceiveMessage(parameters);
            }

            return result;
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();
            edtSearchNurAktive.Checked = true;
            edtSearchBetragVon.Focus();
        }

        #endregion

        #region Private Methods

        private void AddZyklusFieldsEvents()
        {
            if (_countRemoveZyklusFieldsEvents <= 1)
            {
                this.edtMonatstag1.EditValueChanged += new System.EventHandler(this.edtMonatstag1_EditValueChanged);
                this.edtMonatstag2.EditValueChanged += new System.EventHandler(this.edtMonatstag2_EditValueChanged);
                this.edtWochentag.EditValueChanged += new System.EventHandler(this.edtWochentag_EditValueChanged);
                this.edtMontag.CheckedChanged += new System.EventHandler(this.edtMontag_CheckedChanged);
                this.edtDienstag.CheckedChanged += new System.EventHandler(this.edtDienstag_CheckedChanged);
                this.edtMittwoch.CheckedChanged += new System.EventHandler(this.edtMittwoch_CheckedChanged);
                this.edtDonnerstag.CheckedChanged += new System.EventHandler(this.edtDonnerstag_CheckedChanged);
                this.edtFreitag.CheckedChanged += new System.EventHandler(this.edtFreitag_CheckedChanged);
            }
            _countRemoveZyklusFieldsEvents--;
        }

        private void CheckNotNullFields()
        {
            // CheckNotNullField for Controls that have their EditMode == Required
            foreach (Control ctl in _controlList.Values)
            {
                if (typeof(IKissEditable).IsAssignableFrom(ctl.GetType()) && typeof(IKissBindableEdit).IsAssignableFrom(ctl.GetType()))
                {
                    if (((IKissEditable)ctl).EditMode == EditModeType.Required)
                    {
                        string text = ctl.Tag == null ? ctl.Name : ctl.Tag.ToString();
                        DBUtil.CheckNotNullField(((IKissBindableEdit)ctl), text);
                    }
                }
                else
                {
                    throw new KissErrorException("The control is not a IKissEditable object.");
                }
            }

            // Periodizität = Wöchentlich: mindestens einen Tag ist ausgewählt
            if ((FbBarauszahlungPeriodizitaet)qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.FbBarauszahlungPeriodizitaetCode] == FbBarauszahlungPeriodizitaet.Woechentlich &&
                !edtMontag.Checked && !edtDienstag.Checked && !edtMittwoch.Checked && !edtDonnerstag.Checked && !edtFreitag.Checked)
            {
                throw new KissInfoException(KissMsg.GetMLMessage("DBUtil",
                                                                 "FeldXYLeer",
                                                                 "Das Feld '{0}' darf nicht leer bleiben !",
                                                                 KissMsgCode.MsgInfo,
                                                                 lblWochentage.Text),
                                            edtMontag);
            }
        }

        private void CheckValue()
        {
            // Datum von < Datum bis
            if (qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.DatumBis] != DBNull.Value)
            {
                DateTime datumBis = Convert.ToDateTime(qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.DatumBis]);
                DateTime datumVon = Convert.ToDateTime(qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.DatumVon]);

                if (datumBis < datumVon)
                {
                    throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                     "BisDatNachVonDatError",
                                                                     "'Gültig bis' Datum muss nach dem 'Gültig von' Datum liegen.",
                                                                     KissMsgCode.Text),
                                                edtDatumBis);
                }
            }

            // Datum bis >= Letzte Auszahlung
            if (AuszahlungenVorhanden && qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.DatumBis] != DBNull.Value)
            {
                DateTime datumBis = Convert.ToDateTime(qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.DatumBis]);
                DateTime letzteAuszahlung = Convert.ToDateTime(qryFbBarauszahlungAuftrag[QBAA_LETZTE_AUSZAHLUNG]);

                if (datumBis < letzteAuszahlung)
                {
                    throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                     "BisDatVorLetztAuszahlError",
                                                                     "'Gültig bis' Datum muss nach dem Datum der letzten Auszahlung liegen.",
                                                                     KissMsgCode.Text),
                                                edtDatumBis);
                }
            }

            // Betrag > 0
            if (Utils.IsDecimal(qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.Betrag].ToString()))
            {
                decimal betrag = Convert.ToDecimal(qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.Betrag]);
                if (betrag <= 0)
                {
                    throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                     "BetragNichtPositivError",
                                                                     "Der Betrag muss grösser als 0.00 sein.",
                                                                     KissMsgCode.Text),
                                                edtBetrag);
                }
            }
            else
            {
                throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                 "BetragNichtNumerischError",
                                                                 "Der Betrag muss numerisch sein.",
                                                                 KissMsgCode.Text),
                                            edtBetrag);
            }

            // Vorbezug > 0
            if (!Utils.IsNatural(qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.Vorbezug].ToString()))
            {
                throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                 "VorNachbezugNichtPositivError",
                                                                 "Der {0} muss positiv sein.", lblVorbezug.Text),
                                            edtVorbezug);
            }

            // Nachbezug > 0
            if (!Utils.IsNatural(qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.Nachbezug].ToString()))
            {
                throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                 "VorNachbezugNichtPositivError",
                                                                 "Der {0} muss positiv sein.", lblNachbezug.Text),
                                            edtNachbezug);
            }

            // HabenKontoNr zwischen KasseKontoNrMin und KasseKontoNrMax
            int habenKontoNr = Convert.ToInt32(edtHabenKontoNr.EditValue.ToString());
            int habenKontoNrMin = DBUtil.GetConfigInt(@"System\Fibu\Barauszahlung\KasseKontoNrMin", 1000);
            int habenKontoNrMax = DBUtil.GetConfigInt(@"System\Fibu\Barauszahlung\KasseKontoNrMax", 1009);

            if (habenKontoNr < habenKontoNrMin || habenKontoNr > habenKontoNrMax)
            {
                throw new KissInfoException(string.Format(KissMsg.GetMLMessage(this.Name,
                                                                 "HabenKtoNrNichtGueltigError",
                                                                 "Die Kontonummer muss zwischen {0} und {1} sein.",
                                                                 KissMsgCode.Text),
                                                          habenKontoNrMin,
                                                          habenKontoNrMax),
                                            edtHabenKontoNr);
            }

            // HabenKontoNr gültig für Mandant
            DlgAuswahl dlg = new DlgAuswahl();

            bool successHaben = dlg.PeriodenKontoSuchen(edtHabenKontoNr.Text, this.edtMandantNr.Text, DateTime.Now, false, false);
            if (!successHaben)
            {
                throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                    "HabenKtoNichtVorhandenError",
                                                    "Das gewählte Haben-Konto ist in der aktuellen Periode des Mandanten nicht vorhanden."),
                                            edtHabenKontoNr);
            }

            // SollKontoNr gültig für Mandant
            bool successSoll = dlg.PeriodenKontoSuchen(edtSollKontoNr.Text, this.edtMandantNr.Text, DateTime.Now, false, false);
            if (!successSoll)
            {
                throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                    "SollKtoNichtVorhandenError",
                                                    "Das gewählte Soll-Konto ist in der aktuellen Periode des Mandanten nicht vorhanden."),
                                            edtSollKontoNr);
            }

            FbBarauszahlungPeriodizitaet periodizitaet = (FbBarauszahlungPeriodizitaet)edtPeriodizitaet.EditValue;

            // Monatstag zwischen 1 und 31
            if (periodizitaet != FbBarauszahlungPeriodizitaet.Woechentlich &&
                periodizitaet != FbBarauszahlungPeriodizitaet.VierzehnTaeglich &&
                periodizitaet != FbBarauszahlungPeriodizitaet.Einmalig)
            {
                CheckValueMonatstag(edtMonatstag1);
            }

            if (periodizitaet == FbBarauszahlungPeriodizitaet.ZweiMalProMonat)
            {
                CheckValueMonatstag(edtMonatstag2);
            }

            if (!AuszahlungenVorhanden)
            {
                // erster Stichtag > DatumBis
                CheckValueStartDatum();
            }
        }

        private void CheckValueMonatstag(KissCalcEdit edtMonatstag)
        {
            // Monatstag1 between 1 and 31
            if (!string.IsNullOrEmpty(edtMonatstag.EditValue.ToString()))
            {
                if (Utils.IsNumeric(edtMonatstag.EditValue.ToString()))
                {
                    int dayNr = Convert.ToInt32(edtMonatstag.EditValue.ToString());
                    if (dayNr < 1 || dayNr > 31)
                    {
                        throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                         "MonatstagNichtGueltigError",
                                                                         "Der Monatstag muss zwischen 1 und 31 sein.",
                                                                         KissMsgCode.Text),
                                                    edtMonatstag);
                    }
                }
                else
                {
                    throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                     "MonatstagNichtNumerischError",
                                                                     "Der Monatstag muss numerisch sein.",
                                                                     KissMsgCode.Text),
                                                edtMonatstag);
                }
            }
        }

        private void CheckValueStartDatum()
        {
            if (!DBUtil.IsEmpty(edtDatumBis.EditValue))
            {
                DateTime datumVon = Convert.ToDateTime(edtDatumVon.EditValue);
                DayOfWeek day;

                switch ((FbBarauszahlungPeriodizitaet)edtPeriodizitaet.EditValue)
                {
                    case FbBarauszahlungPeriodizitaet.Jaehrlich:
                    case FbBarauszahlungPeriodizitaet.Halbjaehrlich:
                    case FbBarauszahlungPeriodizitaet.Vierteljaehrlich:
                    case FbBarauszahlungPeriodizitaet.Zweimonatlich:
                    case FbBarauszahlungPeriodizitaet.Monatlich:
                    case FbBarauszahlungPeriodizitaet.Einmalig:
                        CheckValueStartDatum(GetNextDate(datumVon, Convert.ToInt32(edtMonatstag1.EditValue)), edtDatumBis);
                        break;

                    case FbBarauszahlungPeriodizitaet.ZweiMalProMonat:
                        CheckValueStartDatum(GetNextDate(datumVon, Convert.ToInt32(edtMonatstag1.EditValue)), edtDatumBis);
                        CheckValueStartDatum(GetNextDate(datumVon, Convert.ToInt32(edtMonatstag2.EditValue)), edtDatumBis);
                        break;

                    case FbBarauszahlungPeriodizitaet.VierzehnTaeglich:
                        day = GetDayOfWeek((Wochentag)edtWochentag.EditValue);
                        CheckValueStartDatum(Utils.GetDateNextDayOfWeek(datumVon, day), edtDatumBis);
                        break;

                    case FbBarauszahlungPeriodizitaet.Woechentlich:
                        foreach (KeyValuePair<Wochentag, KissCheckEdit> pair in _wochentagList)
                        {
                            if (pair.Value.Checked)
                            {
                                day = GetDayOfWeek(pair.Key);
                                CheckValueStartDatum(Utils.GetDateNextDayOfWeek(datumVon, day), edtDatumBis);
                            }
                        }
                        break;

                    default:
                        // --- ignore
                        break;
                }
            }
        }

        private void CheckValueStartDatum(DateTime startDatum, KissDateEdit edt)
        {
            if (startDatum > Convert.ToDateTime(edt.EditValue))
            {
                throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                 "EinstellungNichtGueltigError",
                                                                 "Mit den gewählten Einstellungen ist nicht für alle Termine eine Auszahlung möglich.",
                                                                 KissMsgCode.Text),
                                            edt);
            }
        }

        private void DeleteZyklus()
        {
            DBUtil.OpenSQL("DELETE FbBarauszahlungZyklus WHERE FbBarauszahlungAuftragID = {0}", (int)qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.FbBarauszahlungAuftragID]);
            qryFbBarauszahlungZyklus.DataTable.Clear();
        }

        /// <summary>
        /// Converts an Enum Wochentag to DayOfWeek
        /// </summary>
        /// <param name="wochentag">wochentag</param>
        /// <returns>day of week</returns>
        private DayOfWeek GetDayOfWeek(Wochentag wochentag)
        {
            switch (wochentag)
            {
                case Wochentag.Montag:
                    return DayOfWeek.Monday;

                case Wochentag.Dienstag:
                    return DayOfWeek.Tuesday;

                case Wochentag.Mittwoch:
                    return DayOfWeek.Wednesday;

                case Wochentag.Donnerstag:
                    return DayOfWeek.Thursday;

                case Wochentag.Freitag:
                    return DayOfWeek.Friday;

                case Wochentag.Samstag:
                    return DayOfWeek.Saturday;

                case Wochentag.Sonntag:
                    return DayOfWeek.Sunday;

                default:
                    return DayOfWeek.Monday;
            }
        }

        private DateTime GetNextDate(DateTime datumVon, int monatstag)
        {
            DateTime date = new DateTime(datumVon.Year, datumVon.Month, datumVon.Day);
            int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);

            if (monatstag > daysInMonth)
            {
                monatstag = daysInMonth;
            }
            if (monatstag < datumVon.Day)
            {
                date = date.AddMonths(1);
            }
            date = new DateTime(date.Year, date.Month, monatstag);

            return date;
        }

        private void GetSaldoKasse()
        {
            string saldoGruppe = DBUtil.GetConfigString(@"System\Fibu\Barauszahlung\SaldoGruppeName", "Kasse + PC");
            qryPeriode.Fill(_BaPersonID, DateTime.Now);
            if (!qryPeriode.IsEmpty)
            {
                int periodeID = (int)qryPeriode["FbPeriodeID"];
                qrySaldoKasse.Fill(periodeID, saldoGruppe);
                double saldo = Convert.ToDouble(qrySaldoKasse["Saldo"]);
                lblSaldo.Text = string.Format("Saldo {0}: {1}", saldoGruppe, saldo.ToString("N2"));
            }
            else
            {
                lblSaldo.Text = string.Format("Saldo {0}: -", saldoGruppe);
            }
        }

        private void GetZyklus(FbBarauszahlungPeriodizitaet periodizitaet)
        {
            RemoveZyklusFieldsEvents();
            ResetZyklusFields();
            qryFbBarauszahlungZyklus.Fill(qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.FbBarauszahlungAuftragID]);
            DateTime datumStart;

            switch (periodizitaet)
            {
                case FbBarauszahlungPeriodizitaet.Jaehrlich:
                case FbBarauszahlungPeriodizitaet.Halbjaehrlich:
                case FbBarauszahlungPeriodizitaet.Vierteljaehrlich:
                case FbBarauszahlungPeriodizitaet.Zweimonatlich:
                case FbBarauszahlungPeriodizitaet.Monatlich:
                case FbBarauszahlungPeriodizitaet.Einmalig:
                    if (qryFbBarauszahlungZyklus[DBO.FbBarauszahlungZyklus.DatumStart] != null
                        && DateTime.TryParse(Convert.ToString(qryFbBarauszahlungZyklus[DBO.FbBarauszahlungZyklus.DatumStart]), out datumStart))
                    {
                        edtMonatstag1.EditValue = datumStart.Day;
                    }
                    else
                    {
                        edtMonatstag1.EditValue = string.Empty;
                    }
                    break;

                case FbBarauszahlungPeriodizitaet.ZweiMalProMonat:
                    if (qryFbBarauszahlungZyklus[DBO.FbBarauszahlungZyklus.DatumStart] != null
                        && DateTime.TryParse(Convert.ToString(qryFbBarauszahlungZyklus[DBO.FbBarauszahlungZyklus.DatumStart]), out datumStart))
                    {
                        edtMonatstag1.EditValue = datumStart.Day;
                    }
                    else
                    {
                        edtMonatstag1.EditValue = string.Empty;
                    }
                    qryFbBarauszahlungZyklus.Next();
                    if (qryFbBarauszahlungZyklus[DBO.FbBarauszahlungZyklus.DatumStart] != null
                        && DateTime.TryParse(Convert.ToString(qryFbBarauszahlungZyklus[DBO.FbBarauszahlungZyklus.DatumStart]), out datumStart))
                    {
                        edtMonatstag2.EditValue = datumStart.Day;
                    }
                    else
                    {
                        edtMonatstag2.EditValue = string.Empty;
                    }
                    break;

                case FbBarauszahlungPeriodizitaet.VierzehnTaeglich:
                    edtWochentag.EditValue = qryFbBarauszahlungZyklus[DBO.FbBarauszahlungZyklus.WochentagCode];
                    break;

                case FbBarauszahlungPeriodizitaet.Woechentlich:
                    for (int i = 0; i < qryFbBarauszahlungZyklus.Count; i++)
                    {
                        Wochentag tag = (Wochentag)qryFbBarauszahlungZyklus[DBO.FbBarauszahlungZyklus.WochentagCode];
                        _wochentagList[tag].Checked = true;
                        int id = (int)qryFbBarauszahlungZyklus[DBO.FbBarauszahlungZyklus.FbBarauszahlungZyklusID];
                        qryFbBarauszahlungZyklus.Next();
                    }
                    break;

                default:
                    // --- ignore
                    break;
            }
            AddZyklusFieldsEvents();
        }

        private void InitQueryFields()
        {
            qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.FbBarauszahlungPeriodizitaetCode] = FbBarauszahlungPeriodizitaet.Einmalig;

            qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.FaLeistungID] = _FaLeistungID;

            // Erfasst und geändert von
            qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.UserID_Creator] = Session.User.UserID;
            qryFbBarauszahlungAuftrag[QBAA_CREATOR_NAME] = Session.User.LastFirstName;
            SetAuftragModifier();

            // Mandant
            qryPerson.Fill(_BaPersonID);
            qryFbBarauszahlungAuftrag[QBAA_BA_PERSON_ID_MANDANT] = _BaPersonID;
            qryFbBarauszahlungAuftrag[QBAA_NAME_MANDANT] = qryPerson[DBO.vwPerson.NameVorname];
            qryFbBarauszahlungAuftrag[QBAA_PLZ_ORT_MANDANT] = qryPerson[QPRS_PLZ_ORT];
            if (qryPerson[DBO.BaPerson.GeschlechtCode] != DBNull.Value)
            {
                if ((Geschlecht)qryPerson[DBO.BaPerson.GeschlechtCode] == Geschlecht.Maenlich)
                {
                    qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.Buchungstext] = DBUtil.GetConfigString(@"System\Fibu\Barauszahlung\BuchungstextMaennlich", "");
                }
                else
                {
                    qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.Buchungstext] = DBUtil.GetConfigString(@"System\Fibu\Barauszahlung\BuchungstextWeiblich", "");
                }
            }

            // Creator und Modifier
            qryFbBarauszahlungAuftrag.SetCreator();
            qryFbBarauszahlungAuftrag.SetModifierModified();

            // Kontonummern
            qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.SollKtoNr] = DBUtil.GetConfigString(@"System\Fibu\Barauszahlung\SollKontoNr", "");
            qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.HabenKtoNr] = DBUtil.GetConfigString(@"System\Fibu\Barauszahlung\HabenKontoNr", "");

            // Kontonamen suchen wenn eine Periode vorhanden ist und die Kontonummer in dieser Periode existiert
            qryPeriode.Fill(_BaPersonID, DateTime.Now);
            if (!qryPeriode.IsEmpty)
            {
                if (!string.IsNullOrEmpty(edtSollKontoNr.Text))
                {
                    qryKonto.Fill(_BaPersonID, DateTime.Now, edtSollKontoNr.Text);
                    if (qryKonto.Count == 1)
                    {
                        qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.SollKtoNr] = qryKonto["KontoNr"];
                        qryFbBarauszahlungAuftrag[QBAA_SOLL_KTO_NR_NAME] = qryKonto["KontoName"];
                    }
                }
                if (!string.IsNullOrEmpty(edtHabenKontoNr.Text))
                {
                    qryKonto.Fill(_BaPersonID, DateTime.Now, edtHabenKontoNr.Text);
                    if (qryKonto.Count == 1)
                    {
                        qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.HabenKtoNr] = qryKonto["KontoNr"];
                        qryFbBarauszahlungAuftrag[QBAA_HABEN_KTO_NR_NAME] = qryKonto["KontoName"];
                    }
                }
            }

            // Vor- / Nachbezug auf 0 setzen gemäss Mantis-Notiz 0024841 vom 10.03.2010
            qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.Vorbezug] = 0;
            qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.Nachbezug] = 0;
        }

        private void InsertZyklus(DateTime datumVon, DauerTyp dauerTyp, int dauerNaechsteZahlung, Wochentag? wochentag, int? monatstag)
        {
            qryFbBarauszahlungZyklus.Insert();
            qryFbBarauszahlungZyklus.SetCreator();
            qryFbBarauszahlungZyklus.SetModifierModified();

            qryFbBarauszahlungZyklus[DBO.FbBarauszahlungZyklus.FbBarauszahlungAuftragID] = qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.FbBarauszahlungAuftragID];
            qryFbBarauszahlungZyklus[DBO.FbBarauszahlungZyklus.DauerNaechsteZahlung] = dauerNaechsteZahlung;
            qryFbBarauszahlungZyklus[DBO.FbBarauszahlungZyklus.DauerTypCode] = (int)dauerTyp;
            DateTime datumStart = new DateTime();
            switch (dauerTyp)
            {
                case DauerTyp.Tag:
                    qryFbBarauszahlungZyklus[DBO.FbBarauszahlungZyklus.WochentagCode] = (Wochentag)wochentag;
                    DayOfWeek day = GetDayOfWeek((Wochentag)wochentag);
                    datumStart = Utils.GetDateNextDayOfWeek(datumVon, day);
                    break;

                case DauerTyp.Monat:
                    datumStart = GetNextDate(datumVon, (int)monatstag);
                    break;
            }
            qryFbBarauszahlungZyklus[DBO.FbBarauszahlungZyklus.DatumStart] = datumStart;

            if (!qryFbBarauszahlungZyklus.Post())
            {
                throw new KissCancelException();
            }
        }

        private void InsertZyklusMonat(int dauerNaechsteZahlung, int tag)
        {
            InsertZyklus((DateTime)edtDatumVon.EditValue, DauerTyp.Monat, dauerNaechsteZahlung, null, tag);
        }

        private void InsertZyklusTag(int dauerNaechsteZahlung, Wochentag tag)
        {
            InsertZyklus((DateTime)edtDatumVon.EditValue, DauerTyp.Tag, dauerNaechsteZahlung, tag, null);
        }

        private void InsertZyklusWoechentlich(Wochentag tag)
        {
            InsertZyklusTag(7, tag);
        }

        private bool LeistungIsActive(int _FaLeistungID)
        {
            SqlQuery qryLeistung = DBUtil.OpenSQL("SELECT TOP 1 DatumBis FROM FaLeistung WHERE FaLeistungID = {0}", _FaLeistungID);

            return qryLeistung["DatumBis"] == DBNull.Value;
        }

        private bool NeedMonatstag(FbBarauszahlungPeriodizitaet fbBarauszahlungPeriodizitaet)
        {
            switch (fbBarauszahlungPeriodizitaet)
            {
                case FbBarauszahlungPeriodizitaet.Einmalig:
                case FbBarauszahlungPeriodizitaet.Halbjaehrlich:
                case FbBarauszahlungPeriodizitaet.Jaehrlich:
                case FbBarauszahlungPeriodizitaet.Monatlich:
                case FbBarauszahlungPeriodizitaet.Vierteljaehrlich:
                case FbBarauszahlungPeriodizitaet.Zweimonatlich:
                    return true;

                default:
                    return false;
            }
        }

        private void RemoveZyklusFieldsEvents()
        {
            _countRemoveZyklusFieldsEvents++;
            this.edtMonatstag1.EditValueChanged -= new System.EventHandler(this.edtMonatstag1_EditValueChanged);
            this.edtMonatstag2.EditValueChanged -= new System.EventHandler(this.edtMonatstag2_EditValueChanged);
            this.edtWochentag.EditValueChanged -= new System.EventHandler(this.edtWochentag_EditValueChanged);
            this.edtMontag.CheckedChanged -= new System.EventHandler(this.edtMontag_CheckedChanged);
            this.edtDienstag.CheckedChanged -= new System.EventHandler(this.edtDienstag_CheckedChanged);
            this.edtMittwoch.CheckedChanged -= new System.EventHandler(this.edtMittwoch_CheckedChanged);
            this.edtDonnerstag.CheckedChanged -= new System.EventHandler(this.edtDonnerstag_CheckedChanged);
            this.edtFreitag.CheckedChanged -= new System.EventHandler(this.edtFreitag_CheckedChanged);
        }

        private void ResetEditModePeriodizitaet()
        {
            edtMonatstag1.EditMode = EditModeType.Normal;
            edtMonatstag2.EditMode = EditModeType.Normal;
            edtWochentag.EditMode = EditModeType.Normal;
            edtVorbezug.EditMode = EditModeType.Required;
            edtDatumBis.EditMode = EditModeType.Normal;
        }

        private void ResetZyklusFields()
        {
            RemoveZyklusFieldsEvents();
            edtMonatstag2.EditValue = "";
            edtWochentag.ItemIndex = 0;

            foreach (KissCheckEdit edit in _wochentagList.Values)
            {
                edit.Checked = false;
            }
            AddZyklusFieldsEvents();
        }

        private void SelectPeriodizitaetFields(FbBarauszahlungPeriodizitaet periodizitaet)
        {
            ResetEditModePeriodizitaet();

            switch (periodizitaet)
            {
                case FbBarauszahlungPeriodizitaet.Jaehrlich:
                case FbBarauszahlungPeriodizitaet.Halbjaehrlich:
                case FbBarauszahlungPeriodizitaet.Vierteljaehrlich:
                case FbBarauszahlungPeriodizitaet.Zweimonatlich:
                case FbBarauszahlungPeriodizitaet.Monatlich:
                    panMonatstag.Visible = true;
                    panWochentag.Visible = false;
                    panWochentagListe.Visible = false;
                    edtMonatstag1.EditMode = EditModeType.Required;
                    edtMonatstag2.EditMode = EditModeType.ReadOnly;
                    break;

                case FbBarauszahlungPeriodizitaet.Einmalig:
                    panMonatstag.Visible = true;
                    panWochentag.Visible = false;
                    panWochentagListe.Visible = false;
                    edtMonatstag1.EditMode = EditModeType.ReadOnly;
                    edtMonatstag2.EditMode = EditModeType.ReadOnly;
                    edtVorbezug.EditMode = EditModeType.ReadOnly;
                    edtDatumBis.EditMode = EditModeType.ReadOnly;
                    break;

                case FbBarauszahlungPeriodizitaet.ZweiMalProMonat:
                    panMonatstag.Visible = true;
                    panWochentag.Visible = false;
                    panWochentagListe.Visible = false;
                    edtMonatstag1.EditMode = EditModeType.Required;
                    edtMonatstag2.EditMode = EditModeType.Required;
                    break;

                case FbBarauszahlungPeriodizitaet.VierzehnTaeglich:
                    panMonatstag.Visible = false;
                    panWochentag.Visible = false;
                    panWochentagListe.Visible = true;
                    edtWochentag.EditMode = EditModeType.Required;
                    RemoveZyklusFieldsEvents();
                    edtWochentag.ItemIndex = 0;
                    AddZyklusFieldsEvents();
                    break;

                case FbBarauszahlungPeriodizitaet.Woechentlich:
                    panMonatstag.Visible = false;
                    panWochentag.Visible = true;
                    panWochentagListe.Visible = false;
                    break;

                default:
                    // --- ignore
                    break;
            }
        }

        private void SetAuftragKopierenEnable(bool enable)
        {
            btnAuftragKopieren.Enabled = enable;
        }

        private void SetAuftragModifier()
        {
            qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.UserID_Modifier] = Session.User.UserID;
            qryFbBarauszahlungAuftrag[QBAA_MODIFIER_NAME] = Session.User.LastFirstName;
        }

        private void SetDefaultValues(FbBarauszahlungPeriodizitaet periodizitaet)
        {
            switch (periodizitaet)
            {
                case FbBarauszahlungPeriodizitaet.Jaehrlich:
                case FbBarauszahlungPeriodizitaet.Halbjaehrlich:
                case FbBarauszahlungPeriodizitaet.Vierteljaehrlich:
                case FbBarauszahlungPeriodizitaet.Zweimonatlich:
                case FbBarauszahlungPeriodizitaet.Monatlich:
                    break;

                case FbBarauszahlungPeriodizitaet.Einmalig:
                    edtMonatstag1.EditValue = DBNull.Value;
                    edtVorbezug.EditValue = 0;
                    edtDatumBis.EditValue = null;
                    break;

                case FbBarauszahlungPeriodizitaet.ZweiMalProMonat:
                    break;

                case FbBarauszahlungPeriodizitaet.VierzehnTaeglich:
                    break;

                case FbBarauszahlungPeriodizitaet.Woechentlich:
                    break;

                default:
                    // --- ignore
                    break;
            }
        }

        private void SetEditMode(FbBarauszahlungPeriodizitaet periodizitaet, bool auszahlungenVorhanden)
        {
            if (_leistungIsActive && mayUpdate)
            {
                edtSollKontoNr.EditMode = EditModeType.Required;
                edtBuchungstext.EditMode = EditModeType.Required;
                edtDatumBis.EditMode = EditModeType.Normal;
                SetAuftragKopierenEnable(true);

                if (auszahlungenVorhanden)
                {
                    SelectPeriodizitaetFields(periodizitaet);
                    SetEditModeRequiredFields(EditModeType.ReadOnly);
                    SetEditModeNormalFields(EditModeType.ReadOnly);
                }
                else
                {
                    SetEditModeRequiredFields(EditModeType.Required);
                    SetEditModeNormalFields(EditModeType.Normal);

                    SelectPeriodizitaetFields(periodizitaet);
                }
            }
            else
            {
                SelectPeriodizitaetFields(periodizitaet);
                SetEditModeAllReadOnly();
            }
        }

        private void SetEditModeAllReadOnly()
        {
            edtSollKontoNr.EditMode = EditModeType.ReadOnly;
            edtBuchungstext.EditMode = EditModeType.ReadOnly;
            edtDatumBis.EditMode = EditModeType.ReadOnly;

            SetEditModeRequiredFields(EditModeType.ReadOnly);
            SetEditModeNormalFields(EditModeType.ReadOnly);
            SetAuftragKopierenEnable(false);
        }

        private void SetEditModeNormalFields(EditModeType editModeType)
        {
            edtDocument.EditMode = editModeType;
        }

        private void SetEditModeRequiredFields(EditModeType editModeType)
        {
            edtBetrag.EditMode = editModeType;
            edtDatumVon.EditMode = editModeType;

            foreach (KissCheckEdit edit in _wochentagList.Values)
            {
                edit.EditMode = editModeType;
            }

            edtHabenKontoNr.EditMode = editModeType;
            edtMonatstag1.EditMode = editModeType;
            edtMonatstag2.EditMode = editModeType;
            edtNachbezug.EditMode = editModeType;
            edtPeriodizitaet.EditMode = editModeType;
            edtVorbezug.EditMode = editModeType;
            edtWochentag.EditMode = editModeType;
        }

        private void SetMonatstag()
        {
            if ((edtMonatstag1.EditMode != EditModeType.ReadOnly && NeedMonatstag((FbBarauszahlungPeriodizitaet)qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.FbBarauszahlungPeriodizitaetCode]))
                || (FbBarauszahlungPeriodizitaet)qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.FbBarauszahlungPeriodizitaetCode] == FbBarauszahlungPeriodizitaet.Einmalig)
            {
                edtMonatstag1.EditValue = ((DateTime)edtDatumVon.EditValue).Day;
            }
        }

        /// <summary>
        /// Liste von Controls die je nach Status aktiviert sein müssen.
        /// </summary>
        private void SetupControlList()
        {
            _controlList = new Dictionary<string, Control>();
            _controlList.Add(edtBetrag.Name, edtBetrag);
            _controlList.Add(edtSollKontoNr.Name, edtSollKontoNr);
            _controlList.Add(edtHabenKontoNr.Name, edtHabenKontoNr);
            _controlList.Add(edtBuchungstext.Name, edtBuchungstext);
            _controlList.Add(edtDatumVon.Name, edtDatumVon);
            _controlList.Add(edtPeriodizitaet.Name, edtPeriodizitaet);
            _controlList.Add(edtMonatstag1.Name, edtMonatstag1);
            _controlList.Add(edtMonatstag2.Name, edtMonatstag2);
            _controlList.Add(edtWochentag.Name, edtWochentag);
            _controlList.Add(edtVorbezug.Name, edtVorbezug);
            _controlList.Add(edtNachbezug.Name, edtNachbezug);

            _wochentagList = new Dictionary<Wochentag, KissCheckEdit>();
            _wochentagList.Add(Wochentag.Montag, edtMontag);
            _wochentagList.Add(Wochentag.Dienstag, edtDienstag);
            _wochentagList.Add(Wochentag.Mittwoch, edtMittwoch);
            _wochentagList.Add(Wochentag.Donnerstag, edtDonnerstag);
            _wochentagList.Add(Wochentag.Freitag, edtFreitag);
        }

        /// <summary>
        /// DataMember von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupDataMembers()
        {
            edtBetrag.DataMember = DBO.FbBarauszahlungAuftrag.Betrag;
            edtBuchungstext.DataMember = DBO.FbBarauszahlungAuftrag.Buchungstext;
            edtCreator.DataMember = QBAA_CREATOR_NAME;
            edtDatumBis.DataMember = DBO.FbBarauszahlungAuftrag.DatumBis;
            edtDatumVon.DataMember = DBO.FbBarauszahlungAuftrag.DatumVon;
            edtDocument.DataMember = DBO.FbBarauszahlungAuftrag.XDocumentID;
            edtHabenKontoName.DataMember = QBAA_HABEN_KTO_NR_NAME;
            edtHabenKontoNr.DataMember = DBO.FbBarauszahlungAuftrag.HabenKtoNr;
            edtMandant.DataMember = QBAA_NAME_MANDANT;
            edtMandantNr.DataMember = QBAA_BA_PERSON_ID_MANDANT;
            edtMandantPlzOrt.DataMember = QBAA_PLZ_ORT_MANDANT;
            edtModifier.DataMember = QBAA_MODIFIER_NAME;
            edtNachbezug.DataMember = DBO.FbBarauszahlungAuftrag.Nachbezug;
            edtPeriodizitaet.DataMember = DBO.FbBarauszahlungAuftrag.FbBarauszahlungPeriodizitaetCode;
            edtSollKontoName.DataMember = QBAA_SOLL_KTO_NR_NAME;
            edtSollKontoNr.DataMember = DBO.FbBarauszahlungAuftrag.SollKtoNr;
            edtVorbezug.DataMember = DBO.FbBarauszahlungAuftrag.Vorbezug;
        }

        /// <summary>
        /// FieldName für die Kolonen von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupFieldNames()
        {
            colBetrag.FieldName = DBO.FbBarauszahlungAuftrag.Betrag;
            colBuchungstext.FieldName = DBO.FbBarauszahlungAuftrag.Buchungstext;
            colCreator.FieldName = QBAA_CREATOR_NAME;
            colLetzteAuszahlung.FieldName = QBAA_LETZTE_AUSZAHLUNG;
            colPeriodizitaet.FieldName = DBO.FbBarauszahlungAuftrag.FbBarauszahlungPeriodizitaetCode;
            colSollKontoNr.FieldName = DBO.FbBarauszahlungAuftrag.SollKtoNr;
            colStatus.FieldName = QBAA_FB_BARAUSZAHLUNG_STATUS_CODE;
        }

        /// <summary>
        /// Tag benutzen um ein klaren Text anzuzeigen für die Mussfelder.
        /// </summary>
        private void SetupTags()
        {
            edtBetrag.Tag = lblBetrag.Text;
            edtSollKontoNr.Tag = lblSoll.Text;
            edtHabenKontoNr.Tag = lblHaben.Text;
            edtBuchungstext.Tag = lblBuchungstext.Text;
            edtDatumVon.Tag = lblDatumVon.Text;
            edtPeriodizitaet.Tag = lblPeriodizitaet.Text;
            edtMonatstag1.Tag = lblMonatstag.Text;
            edtMonatstag2.Tag = lblMonatstag.Text;
            edtWochentag.Tag = lblWochentag.Text;
            edtMontag.Tag = lblWochentage.Text;
            edtDienstag.Tag = lblWochentage.Text;
            edtMittwoch.Tag = lblWochentage.Text;
            edtDonnerstag.Tag = lblWochentage.Text;
            edtFreitag.Tag = lblWochentage.Text;
            edtNachbezug.Tag = lblNachbezug.Text;
            edtVorbezug.Tag = lblVorbezug.Text;
        }

        private void SetZyklus()
        {
            DeleteZyklus();

            switch ((FbBarauszahlungPeriodizitaet)qryFbBarauszahlungAuftrag[DBO.FbBarauszahlungAuftrag.FbBarauszahlungPeriodizitaetCode])
            {
                case FbBarauszahlungPeriodizitaet.Jaehrlich:
                    InsertZyklusMonat(12, Convert.ToInt32(edtMonatstag1.EditValue));
                    break;

                case FbBarauszahlungPeriodizitaet.Halbjaehrlich:
                    InsertZyklusMonat(6, Convert.ToInt32(edtMonatstag1.EditValue));
                    break;

                case FbBarauszahlungPeriodizitaet.Vierteljaehrlich:
                    InsertZyklusMonat(3, Convert.ToInt32(edtMonatstag1.EditValue));
                    break;

                case FbBarauszahlungPeriodizitaet.Zweimonatlich:
                    InsertZyklusMonat(2, Convert.ToInt32(edtMonatstag1.EditValue));
                    break;

                case FbBarauszahlungPeriodizitaet.Monatlich:
                    InsertZyklusMonat(1, Convert.ToInt32(edtMonatstag1.EditValue));
                    break;

                case FbBarauszahlungPeriodizitaet.Einmalig:
                    InsertZyklusMonat(0, edtDatumVon.DateTime.Day);
                    break;

                case FbBarauszahlungPeriodizitaet.ZweiMalProMonat:
                    InsertZyklusMonat(1, Convert.ToInt32(edtMonatstag1.EditValue));
                    InsertZyklusMonat(1, Convert.ToInt32(edtMonatstag2.EditValue));
                    break;

                case FbBarauszahlungPeriodizitaet.VierzehnTaeglich:
                    InsertZyklusTag(14, (Wochentag)edtWochentag.EditValue);
                    edtWochentag.EditValue = qryFbBarauszahlungZyklus[DBO.FbBarauszahlungZyklus.WochentagCode];
                    break;

                case FbBarauszahlungPeriodizitaet.Woechentlich:
                    foreach (KeyValuePair<Wochentag, KissCheckEdit> pair in _wochentagList)
                    {
                        if (pair.Value.Checked)
                        {
                            InsertZyklusWoechentlich(pair.Key);
                        }
                    }

                    break;

                default:
                    // --- ignore
                    break;
            }
        }

        private void ShowInfoBudgetAktualisieren()
        {
            string meldungAnzeigenString = DBUtil.GetConfigString(@"System\Fibu\Barauszahlung\InfomeldungAenderungBudget", "true");

            if (Convert.ToBoolean(meldungAnzeigenString))
            {
                KissMsg.ShowInfo(Name, "KlientenbudgetAktualisierenInfo", "Bitte Änderungen im Budget vornehmen.");
            }
        }

        #endregion

        #endregion
    }
}