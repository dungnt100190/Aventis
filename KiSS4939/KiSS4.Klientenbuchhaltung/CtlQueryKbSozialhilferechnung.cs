using System;
using System.Data;

using KiSS4.Common;
using KiSS4.Gui;

namespace KiSS4.Klientenbuchhaltung
{
    /// <summary>
    /// Query, used for getting different views for Sozialhilferechnung
    /// </summary>
    public class CtlQueryKbSozialhilferechnung : KiSS4.Common.KissQueryControl
    {
        #region Fields

        #region Private Fields

        private int _kbPeriodeID;
        private DevExpress.XtraGrid.Columns.GridColumn col4aAnzahlDosssiers;
        private DevExpress.XtraGrid.Columns.GridColumn col4aAnzahlPersonen;
        private DevExpress.XtraGrid.Columns.GridColumn col4aAufwand;
        private DevExpress.XtraGrid.Columns.GridColumn col4aDatumVonBis;
        private DevExpress.XtraGrid.Columns.GridColumn col4aErtraegeInkassoprivileg;
        private DevExpress.XtraGrid.Columns.GridColumn col4aErtrag;
        private DevExpress.XtraGrid.Columns.GridColumn col4aGemeinde;
        private DevExpress.XtraGrid.Columns.GridColumn col4aPersonalien;
        private DevExpress.XtraGrid.Columns.GridColumn col4aUebrigeErtraege;
        private DevExpress.XtraGrid.Columns.GridColumn col4bAnzahlDossiers;
        private DevExpress.XtraGrid.Columns.GridColumn col4bAnzahlPersonen;
        private DevExpress.XtraGrid.Columns.GridColumn col4bAufwand;
        private DevExpress.XtraGrid.Columns.GridColumn col4bDatumVonBis;
        private DevExpress.XtraGrid.Columns.GridColumn col4bErtraegeInkassoprivileg;
        private DevExpress.XtraGrid.Columns.GridColumn col4bErtrag;
        private DevExpress.XtraGrid.Columns.GridColumn col4bGemeinde;
        private DevExpress.XtraGrid.Columns.GridColumn col4bPersonalien;
        private DevExpress.XtraGrid.Columns.GridColumn col4bUebrigeErtraege;
        private DevExpress.XtraGrid.Columns.GridColumn col4cAnzahlDossiers;
        private DevExpress.XtraGrid.Columns.GridColumn col4cAnzahlPersonen;
        private DevExpress.XtraGrid.Columns.GridColumn col4cAufwand;
        private DevExpress.XtraGrid.Columns.GridColumn col4cDatumVonBis;
        private DevExpress.XtraGrid.Columns.GridColumn col4cErtraegeHeimatliche;
        private DevExpress.XtraGrid.Columns.GridColumn col4cErtraegeInkassoprivileg;
        private DevExpress.XtraGrid.Columns.GridColumn col4cErtrag;
        private DevExpress.XtraGrid.Columns.GridColumn col4cGemeinde;
        private DevExpress.XtraGrid.Columns.GridColumn col4cPersonalien;
        private DevExpress.XtraGrid.Columns.GridColumn col4cUebrigeErtraege;
        private DevExpress.XtraGrid.Columns.GridColumn col4dAnzahlDossiers;
        private DevExpress.XtraGrid.Columns.GridColumn col4dAnzahlPersonen;
        private DevExpress.XtraGrid.Columns.GridColumn col4dAufwand;
        private DevExpress.XtraGrid.Columns.GridColumn col4dDatumVonBis;
        private DevExpress.XtraGrid.Columns.GridColumn col4dErtraegeHeimatliche;
        private DevExpress.XtraGrid.Columns.GridColumn col4dErtraegeInkassoprivileg;
        private DevExpress.XtraGrid.Columns.GridColumn col4dErtrag;
        private DevExpress.XtraGrid.Columns.GridColumn col4dGemeinde;
        private DevExpress.XtraGrid.Columns.GridColumn col4dPersonalien;
        private DevExpress.XtraGrid.Columns.GridColumn col4dUebrigeErtraege;
        private DevExpress.XtraGrid.Columns.GridColumn col5AnzahlDossiers;
        private DevExpress.XtraGrid.Columns.GridColumn col5AnzahlPersonen;
        private DevExpress.XtraGrid.Columns.GridColumn col5Aufwand;
        private DevExpress.XtraGrid.Columns.GridColumn col5DatumVonBis;
        private DevExpress.XtraGrid.Columns.GridColumn col5ErtraegeInkassoprivileg;
        private DevExpress.XtraGrid.Columns.GridColumn col5Ertrag;
        private DevExpress.XtraGrid.Columns.GridColumn col5Gemeinde;
        private DevExpress.XtraGrid.Columns.GridColumn col5NameHeim;
        private DevExpress.XtraGrid.Columns.GridColumn col5Personalien;
        private DevExpress.XtraGrid.Columns.GridColumn col5UebrigeErtraege;
        private DevExpress.XtraGrid.Columns.GridColumn col6aAnzahlDossiers;
        private DevExpress.XtraGrid.Columns.GridColumn col6aAnzahlPersonen;
        private DevExpress.XtraGrid.Columns.GridColumn col6aAufwand;
        private DevExpress.XtraGrid.Columns.GridColumn col6aDatumVonBis;
        private DevExpress.XtraGrid.Columns.GridColumn col6aErtraegeInkassoprivileg;
        private DevExpress.XtraGrid.Columns.GridColumn col6aErtrag;
        private DevExpress.XtraGrid.Columns.GridColumn col6aGemeinde;
        private DevExpress.XtraGrid.Columns.GridColumn col6aNameHeim;
        private DevExpress.XtraGrid.Columns.GridColumn col6aPersonalien;
        private DevExpress.XtraGrid.Columns.GridColumn col6aUebrigeErtraege;
        private DevExpress.XtraGrid.Columns.GridColumn col7aBevorschussung;
        private DevExpress.XtraGrid.Columns.GridColumn col7aDatumVonBis;
        private DevExpress.XtraGrid.Columns.GridColumn col7aGemeinde;
        private DevExpress.XtraGrid.Columns.GridColumn col7aInkassikosten;
        private DevExpress.XtraGrid.Columns.GridColumn col7aMonatlichAlimente;
        private DevExpress.XtraGrid.Columns.GridColumn col7aNetto;
        private DevExpress.XtraGrid.Columns.GridColumn col7aPersonalien;
        private DevExpress.XtraGrid.Columns.GridColumn col7aRueckerstattung;
        private DevExpress.XtraGrid.Columns.GridColumn colAnzahlDossiers;
        private DevExpress.XtraGrid.Columns.GridColumn colAnzahlPersonen;
        private DevExpress.XtraGrid.Columns.GridColumn colAufwand;
        private DevExpress.XtraGrid.Columns.GridColumn colBaWVCode;
        private DevExpress.XtraGrid.Columns.GridColumn colBevorschussung;
        private DevExpress.XtraGrid.Columns.GridColumn colBezugsgrsse;
        private DevExpress.XtraGrid.Columns.GridColumn colErtrag;
        private DevExpress.XtraGrid.Columns.GridColumn colErtrgeHeimatliche;
        private DevExpress.XtraGrid.Columns.GridColumn colErtrgeInkassoprivileg;
        private DevExpress.XtraGrid.Columns.GridColumn colInkassikosten;
        private DevExpress.XtraGrid.Columns.GridColumn colListeAnzahlDossiers;
        private DevExpress.XtraGrid.Columns.GridColumn colListeAnzahlPersonen;
        private DevExpress.XtraGrid.Columns.GridColumn colListeAufwand;
        private DevExpress.XtraGrid.Columns.GridColumn colListeBevorschussung;
        private DevExpress.XtraGrid.Columns.GridColumn colListeBezugsgroesse;
        private DevExpress.XtraGrid.Columns.GridColumn colListeDatumVonBis;
        private DevExpress.XtraGrid.Columns.GridColumn colListeErtraegeHeimatliche;
        private DevExpress.XtraGrid.Columns.GridColumn colListeErtraegeInkassoprivileg;
        private DevExpress.XtraGrid.Columns.GridColumn colListeErtrag;
        private DevExpress.XtraGrid.Columns.GridColumn colListeGemeinde;
        private DevExpress.XtraGrid.Columns.GridColumn colListeInkassikosten;
        private DevExpress.XtraGrid.Columns.GridColumn colListeMonatlichAlimente;
        private DevExpress.XtraGrid.Columns.GridColumn colListeNetto;
        private DevExpress.XtraGrid.Columns.GridColumn colListePersonalien;
        private DevExpress.XtraGrid.Columns.GridColumn colListeRueckerstattung;
        private DevExpress.XtraGrid.Columns.GridColumn colListeUebrigeErtraege;
        private DevExpress.XtraGrid.Columns.GridColumn colMonatlichAlimente;
        private DevExpress.XtraGrid.Columns.GridColumn colNetto;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonalien;
        private DevExpress.XtraGrid.Columns.GridColumn colRckerstattung;
        private DevExpress.XtraGrid.Columns.GridColumn colbrigeErtrge;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissDateEdit edtDatumBisX;
        private KiSS4.Gui.KissDateEdit edtDatumVonX;
        private KissCheckEdit edtNurOhneGemeindeX;
        private KissLookUpEdit edtZustaendigeGemeindeX;
        private KiSS4.Gui.KissGrid grdAnhang4a;
        private KiSS4.Gui.KissGrid grdAnhang4b;
        private KiSS4.Gui.KissGrid grdAnhang4c;
        private KiSS4.Gui.KissGrid grdAnhang4d;
        private KiSS4.Gui.KissGrid grdAnhang5;
        private KiSS4.Gui.KissGrid grdAnhang6a;
        private KiSS4.Gui.KissGrid grdAnhang7a;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAnhang4a;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAnhang4b;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAnhang4c;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAnhang4d;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAnhang5;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAnhang6a;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAnhang7a;
        private KiSS4.Gui.KissLabel lblDatumBisX;
        private KiSS4.Gui.KissLabel lblDatumVonX;
        private KissLabel lblZustaendigeGemeindeX;
        private System.Windows.Forms.Panel panBottomDockSpacer;
        private SharpLibrary.WinControls.TabPageEx tabPageEx1;
        private SharpLibrary.WinControls.TabPageEx tabPageEx2;
        private SharpLibrary.WinControls.TabPageEx tpgAnhang4a;
        private SharpLibrary.WinControls.TabPageEx tpgAnhang4b;
        private SharpLibrary.WinControls.TabPageEx tpgAnhang4c;
        private SharpLibrary.WinControls.TabPageEx tpgAnhang4d;
        private SharpLibrary.WinControls.TabPageEx tpgAnhang5;
        private SharpLibrary.WinControls.TabPageEx tpgAnhang6a;
        private SharpLibrary.WinControls.TabPageEx tpgAnhang7a;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlQueryKbSozialhilferechnung"/> class.
        /// </summary>
        public CtlQueryKbSozialhilferechnung()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryKbSozialhilferechnung));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.components = new System.ComponentModel.Container();
            this.edtDatumVonX = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBisX = new KiSS4.Gui.KissDateEdit();
            this.lblDatumVonX = new KiSS4.Gui.KissLabel();
            this.lblDatumBisX = new KiSS4.Gui.KissLabel();
            this.tpgAnhang4a = new SharpLibrary.WinControls.TabPageEx();
            this.grdAnhang4a = new KiSS4.Gui.KissGrid();
            this.grvAnhang4a = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col4aPersonalien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4aAnzahlDosssiers = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4aAnzahlPersonen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4aAufwand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4aErtrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4aErtraegeInkassoprivileg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4aUebrigeErtraege = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4aDatumVonBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4aGemeinde = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpgAnhang4b = new SharpLibrary.WinControls.TabPageEx();
            this.grdAnhang4b = new KiSS4.Gui.KissGrid();
            this.grvAnhang4b = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col4bPersonalien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4bAnzahlDossiers = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4bAnzahlPersonen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4bAufwand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4bErtrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4bErtraegeInkassoprivileg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4bUebrigeErtraege = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4bDatumVonBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4bGemeinde = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpgAnhang4c = new SharpLibrary.WinControls.TabPageEx();
            this.grdAnhang4c = new KiSS4.Gui.KissGrid();
            this.grvAnhang4c = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col4cPersonalien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4cAnzahlDossiers = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4cAnzahlPersonen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4cAufwand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4cErtrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4cErtraegeInkassoprivileg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4cErtraegeHeimatliche = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4cUebrigeErtraege = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4cDatumVonBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4cGemeinde = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpgAnhang4d = new SharpLibrary.WinControls.TabPageEx();
            this.grdAnhang4d = new KiSS4.Gui.KissGrid();
            this.grvAnhang4d = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col4dPersonalien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4dAnzahlDossiers = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4dAnzahlPersonen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4dAufwand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4dErtrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4dErtraegeInkassoprivileg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4dErtraegeHeimatliche = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4dUebrigeErtraege = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4dDatumVonBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4dGemeinde = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpgAnhang7a = new SharpLibrary.WinControls.TabPageEx();
            this.grdAnhang7a = new KiSS4.Gui.KissGrid();
            this.grvAnhang7a = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col7aPersonalien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col7aMonatlichAlimente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col7aBevorschussung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col7aInkassikosten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col7aRueckerstattung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col7aNetto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col7aDatumVonBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col7aGemeinde = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnzahlDossiers = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnzahlPersonen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAufwand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaWVCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBevorschussung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBezugsgrsse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbrigeErtrge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErtrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErtrgeHeimatliche = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErtrgeInkassoprivileg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInkassikosten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListeAnzahlDossiers = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListeAnzahlPersonen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListeAufwand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListeBevorschussung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListeBezugsgroesse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListeErtraegeHeimatliche = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListeErtraegeInkassoprivileg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListeErtrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListeInkassikosten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListeMonatlichAlimente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListeNetto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListePersonalien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListeRueckerstattung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListeUebrigeErtraege = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonatlichAlimente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNetto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersonalien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRckerstattung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabPageEx1 = new SharpLibrary.WinControls.TabPageEx();
            this.tabPageEx2 = new SharpLibrary.WinControls.TabPageEx();
            this.colListeDatumVonBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpgAnhang5 = new SharpLibrary.WinControls.TabPageEx();
            this.grdAnhang5 = new KiSS4.Gui.KissGrid();
            this.grvAnhang5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col5Personalien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col5AnzahlDossiers = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col5AnzahlPersonen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col5Aufwand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col5Ertrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col5ErtraegeInkassoprivileg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col5UebrigeErtraege = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col5NameHeim = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col5DatumVonBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col5Gemeinde = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpgAnhang6a = new SharpLibrary.WinControls.TabPageEx();
            this.grdAnhang6a = new KiSS4.Gui.KissGrid();
            this.grvAnhang6a = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col6aPersonalien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col6aAnzahlDossiers = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col6aAnzahlPersonen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col6aAufwand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col6aErtrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col6aErtraegeInkassoprivileg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col6aUebrigeErtraege = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col6aNameHeim = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col6aDatumVonBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col6aGemeinde = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblZustaendigeGemeindeX = new KiSS4.Gui.KissLabel();
            this.edtZustaendigeGemeindeX = new KiSS4.Gui.KissLookUpEdit();
            this.edtNurOhneGemeindeX = new KiSS4.Gui.KissCheckEdit();
            this.colListeGemeinde = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panBottomDockSpacer = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVonX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBisX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVonX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBisX)).BeginInit();
            this.tpgAnhang4a.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAnhang4a)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAnhang4a)).BeginInit();
            this.tpgAnhang4b.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAnhang4b)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAnhang4b)).BeginInit();
            this.tpgAnhang4c.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAnhang4c)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAnhang4c)).BeginInit();
            this.tpgAnhang4d.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAnhang4d)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAnhang4d)).BeginInit();
            this.tpgAnhang7a.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAnhang7a)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAnhang7a)).BeginInit();
            this.tpgAnhang5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAnhang5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAnhang5)).BeginInit();
            this.tpgAnhang6a.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAnhang6a)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAnhang6a)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustaendigeGemeindeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigeGemeindeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigeGemeindeX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurOhneGemeindeX.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.AfterFill += new System.EventHandler(this.qryQuery_AfterFill);
            // 
            // grvQuery1
            // 
            this.grvQuery1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvQuery1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.Empty.Options.UseBackColor = true;
            this.grvQuery1.Appearance.Empty.Options.UseFont = true;
            this.grvQuery1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvQuery1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.EvenRow.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvQuery1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvQuery1.Appearance.FocusedCell.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvQuery1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvQuery1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.FocusedRow.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvQuery1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseFont = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvQuery1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvQuery1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvQuery1.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvQuery1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvQuery1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery1.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvQuery1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvQuery1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.OddRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.OddRow.Options.UseFont = true;
            this.grvQuery1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvQuery1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.Row.Options.UseBackColor = true;
            this.grvQuery1.Appearance.Row.Options.UseFont = true;
            this.grvQuery1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvQuery1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvQuery1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.SelectedRow.Options.UseFont = true;
            this.grvQuery1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery1.Appearance.VertLine.Options.UseBackColor = true;
            this.grvQuery1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colListePersonalien,
            this.colListeBezugsgroesse,
            this.colListeAnzahlDossiers,
            this.colListeAnzahlPersonen,
            this.colListeAufwand,
            this.colListeErtrag,
            this.colListeErtraegeInkassoprivileg,
            this.colListeUebrigeErtraege,
            this.colListeErtraegeHeimatliche,
            this.colListeMonatlichAlimente,
            this.colListeBevorschussung,
            this.colListeInkassikosten,
            this.colListeRueckerstattung,
            this.colListeNetto,
            this.colListeDatumVonBis,
            this.colListeGemeinde});
            this.grvQuery1.OptionsBehavior.Editable = false;
            this.grvQuery1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvQuery1.OptionsNavigation.AutoFocusNewRow = true;
            this.grvQuery1.OptionsNavigation.UseTabKey = false;
            this.grvQuery1.OptionsPrint.AutoWidth = false;
            this.grvQuery1.OptionsPrint.ExpandAllDetails = true;
            this.grvQuery1.OptionsPrint.UsePrintStyles = true;
            this.grvQuery1.OptionsView.ColumnAutoWidth = false;
            this.grvQuery1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvQuery1.OptionsView.ShowFooter = true;
            this.grvQuery1.OptionsView.ShowGroupedColumns = true;
            this.grvQuery1.OptionsView.ShowGroupPanel = false;
            this.grvQuery1.OptionsView.ShowIndicator = false;
            // 
            // grdQuery1
            // 
            this.grdQuery1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.grdQuery1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdQuery1.EmbeddedNavigator.Name = "";
            this.grdQuery1.Location = new System.Drawing.Point(6, 6);
            this.grdQuery1.Size = new System.Drawing.Size(760, 382);
            // 
            // xDocument
            // 
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Location = new System.Drawing.Point(170, 581);
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.xDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("xDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument öffnen")});
            this.xDocument.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.ActiveSQLQuery = this.qryQuery;
            this.ctlGotoFall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.ctlGotoFall.DataMember = "BaPersonID$";
            this.ctlGotoFall.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctlGotoFall.Location = new System.Drawing.Point(6, 394);
            this.ctlGotoFall.Size = new System.Drawing.Size(760, 24);
            this.ctlGotoFall.TabIndex = 2;
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Controls.Add(this.tpgAnhang4a);
            this.tabControlSearch.Controls.Add(this.tpgAnhang4b);
            this.tabControlSearch.Controls.Add(this.tpgAnhang4c);
            this.tabControlSearch.Controls.Add(this.tpgAnhang4d);
            this.tabControlSearch.Controls.Add(this.tpgAnhang5);
            this.tabControlSearch.Controls.Add(this.tpgAnhang6a);
            this.tabControlSearch.Controls.Add(this.tpgAnhang7a);
            this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgAnhang4a,
            this.tpgAnhang4b,
            this.tpgAnhang4c,
            this.tpgAnhang4d,
            this.tpgAnhang5,
            this.tpgAnhang6a,
            this.tpgAnhang7a});
            this.tabControlSearch.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControlSearch_SelectedTabChanged);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgAnhang7a, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgAnhang6a, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgAnhang5, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgAnhang4d, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgAnhang4c, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgAnhang4b, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgAnhang4a, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgSuchen, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe, 0);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.panBottomDockSpacer);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Padding = new System.Windows.Forms.Padding(6);
            this.tpgListe.TabIndex = 1;
            this.tpgListe.Controls.SetChildIndex(this.ctlGotoFall, 0);
            this.tpgListe.Controls.SetChildIndex(this.panBottomDockSpacer, 0);
            this.tpgListe.Controls.SetChildIndex(this.xDocument, 0);
            this.tpgListe.Controls.SetChildIndex(this.grdQuery1, 0);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtNurOhneGemeindeX);
            this.tpgSuchen.Controls.Add(this.lblZustaendigeGemeindeX);
            this.tpgSuchen.Controls.Add(this.edtZustaendigeGemeindeX);
            this.tpgSuchen.Controls.Add(this.lblDatumBisX);
            this.tpgSuchen.Controls.Add(this.lblDatumVonX);
            this.tpgSuchen.Controls.Add(this.edtDatumBisX);
            this.tpgSuchen.Controls.Add(this.edtDatumVonX);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumVonX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumBisX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblDatumVonX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblDatumBisX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtZustaendigeGemeindeX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZustaendigeGemeindeX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNurOhneGemeindeX, 0);
            // 
            // edtDatumVonX
            // 
            this.edtDatumVonX.EditValue = null;
            this.edtDatumVonX.Location = new System.Drawing.Point(116, 56);
            this.edtDatumVonX.Name = "edtDatumVonX";
            this.edtDatumVonX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVonX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVonX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVonX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVonX.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVonX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVonX.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVonX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtDatumVonX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVonX.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtDatumVonX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVonX.Properties.ShowToday = false;
            this.edtDatumVonX.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVonX.TabIndex = 1;
            // 
            // edtDatumBisX
            // 
            this.edtDatumBisX.EditValue = null;
            this.edtDatumBisX.Location = new System.Drawing.Point(256, 56);
            this.edtDatumBisX.Name = "edtDatumBisX";
            this.edtDatumBisX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBisX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBisX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBisX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBisX.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBisX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBisX.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBisX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtDatumBisX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBisX.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtDatumBisX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBisX.Properties.ShowToday = false;
            this.edtDatumBisX.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBisX.TabIndex = 2;
            // 
            // lblDatumVonX
            // 
            this.lblDatumVonX.Location = new System.Drawing.Point(8, 56);
            this.lblDatumVonX.Name = "lblDatumVonX";
            this.lblDatumVonX.Size = new System.Drawing.Size(102, 24);
            this.lblDatumVonX.TabIndex = 3;
            this.lblDatumVonX.Text = "Beleg-Datum von";
            this.lblDatumVonX.UseCompatibleTextRendering = true;
            // 
            // lblDatumBisX
            // 
            this.lblDatumBisX.Location = new System.Drawing.Point(222, 56);
            this.lblDatumBisX.Name = "lblDatumBisX";
            this.lblDatumBisX.Size = new System.Drawing.Size(28, 24);
            this.lblDatumBisX.TabIndex = 4;
            this.lblDatumBisX.Text = "bis";
            this.lblDatumBisX.UseCompatibleTextRendering = true;
            // 
            // tpgAnhang4a
            // 
            this.tpgAnhang4a.Controls.Add(this.grdAnhang4a);
            this.tpgAnhang4a.Location = new System.Drawing.Point(6, 6);
            this.tpgAnhang4a.Name = "tpgAnhang4a";
            this.tpgAnhang4a.Padding = new System.Windows.Forms.Padding(6);
            this.tpgAnhang4a.Size = new System.Drawing.Size(772, 424);
            this.tpgAnhang4a.TabIndex = 2;
            this.tpgAnhang4a.Title = "4a - Berner";
            // 
            // grdAnhang4a
            // 
            this.grdAnhang4a.DataSource = this.qryQuery;
            this.grdAnhang4a.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAnhang4a.EmbeddedNavigator.Name = "";
            this.grdAnhang4a.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdAnhang4a.Location = new System.Drawing.Point(6, 6);
            this.grdAnhang4a.MainView = this.grvAnhang4a;
            this.grdAnhang4a.Name = "grdAnhang4a";
            this.grdAnhang4a.Size = new System.Drawing.Size(760, 412);
            this.grdAnhang4a.TabIndex = 1;
            this.grdAnhang4a.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAnhang4a});
            // 
            // grvAnhang4a
            // 
            this.grvAnhang4a.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvAnhang4a.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang4a.Appearance.Empty.Options.UseBackColor = true;
            this.grvAnhang4a.Appearance.Empty.Options.UseFont = true;
            this.grvAnhang4a.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang4a.Appearance.EvenRow.Options.UseFont = true;
            this.grvAnhang4a.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvAnhang4a.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang4a.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvAnhang4a.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvAnhang4a.Appearance.FocusedCell.Options.UseFont = true;
            this.grvAnhang4a.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvAnhang4a.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvAnhang4a.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang4a.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvAnhang4a.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvAnhang4a.Appearance.FocusedRow.Options.UseFont = true;
            this.grvAnhang4a.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvAnhang4a.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvAnhang4a.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvAnhang4a.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvAnhang4a.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvAnhang4a.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvAnhang4a.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvAnhang4a.Appearance.GroupRow.Options.UseFont = true;
            this.grvAnhang4a.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvAnhang4a.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvAnhang4a.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvAnhang4a.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvAnhang4a.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvAnhang4a.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvAnhang4a.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvAnhang4a.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvAnhang4a.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang4a.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvAnhang4a.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvAnhang4a.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvAnhang4a.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvAnhang4a.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvAnhang4a.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvAnhang4a.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang4a.Appearance.OddRow.Options.UseFont = true;
            this.grvAnhang4a.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvAnhang4a.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang4a.Appearance.Row.Options.UseBackColor = true;
            this.grvAnhang4a.Appearance.Row.Options.UseFont = true;
            this.grvAnhang4a.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang4a.Appearance.SelectedRow.Options.UseFont = true;
            this.grvAnhang4a.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvAnhang4a.Appearance.VertLine.Options.UseBackColor = true;
            this.grvAnhang4a.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvAnhang4a.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col4aPersonalien,
            this.col4aAnzahlDosssiers,
            this.col4aAnzahlPersonen,
            this.col4aAufwand,
            this.col4aErtrag,
            this.col4aErtraegeInkassoprivileg,
            this.col4aUebrigeErtraege,
            this.col4aDatumVonBis,
            this.col4aGemeinde});
            this.grvAnhang4a.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvAnhang4a.GridControl = this.grdAnhang4a;
            this.grvAnhang4a.Name = "grvAnhang4a";
            this.grvAnhang4a.OptionsBehavior.Editable = false;
            this.grvAnhang4a.OptionsCustomization.AllowFilter = false;
            this.grvAnhang4a.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvAnhang4a.OptionsNavigation.AutoFocusNewRow = true;
            this.grvAnhang4a.OptionsNavigation.UseTabKey = false;
            this.grvAnhang4a.OptionsView.ColumnAutoWidth = false;
            this.grvAnhang4a.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvAnhang4a.OptionsView.ShowFooter = true;
            this.grvAnhang4a.OptionsView.ShowGroupedColumns = true;
            this.grvAnhang4a.OptionsView.ShowGroupPanel = false;
            this.grvAnhang4a.OptionsView.ShowIndicator = false;
            // 
            // col4aPersonalien
            // 
            this.col4aPersonalien.Caption = "Personalien";
            this.col4aPersonalien.FieldName = "Personalien";
            this.col4aPersonalien.Name = "col4aPersonalien";
            this.col4aPersonalien.Visible = true;
            this.col4aPersonalien.VisibleIndex = 0;
            // 
            // col4aAnzahlDosssiers
            // 
            this.col4aAnzahlDosssiers.Caption = "Anzahl Dossiers";
            this.col4aAnzahlDosssiers.FieldName = "AnzahlDossiers";
            this.col4aAnzahlDosssiers.Name = "col4aAnzahlDosssiers";
            this.col4aAnzahlDosssiers.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col4aAnzahlDosssiers.Visible = true;
            this.col4aAnzahlDosssiers.VisibleIndex = 1;
            // 
            // col4aAnzahlPersonen
            // 
            this.col4aAnzahlPersonen.Caption = "Anzahl Personen";
            this.col4aAnzahlPersonen.FieldName = "AnzahlPersonen";
            this.col4aAnzahlPersonen.Name = "col4aAnzahlPersonen";
            this.col4aAnzahlPersonen.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col4aAnzahlPersonen.Visible = true;
            this.col4aAnzahlPersonen.VisibleIndex = 2;
            // 
            // col4aAufwand
            // 
            this.col4aAufwand.Caption = "Aufwand";
            this.col4aAufwand.FieldName = "AufwandSHR";
            this.col4aAufwand.Name = "col4aAufwand";
            this.col4aAufwand.SummaryItem.DisplayFormat = "{0:n2}";
            this.col4aAufwand.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col4aAufwand.Visible = true;
            this.col4aAufwand.VisibleIndex = 3;
            // 
            // col4aErtrag
            // 
            this.col4aErtrag.Caption = "Ertrag";
            this.col4aErtrag.FieldName = "ErtragSHRInkassoUebrig";
            this.col4aErtrag.Name = "col4aErtrag";
            this.col4aErtrag.SummaryItem.DisplayFormat = "{0:n2}";
            this.col4aErtrag.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col4aErtrag.Visible = true;
            this.col4aErtrag.VisibleIndex = 4;
            // 
            // col4aErtraegeInkassoprivileg
            // 
            this.col4aErtraegeInkassoprivileg.Caption = "Erträge Inkassoprivileg";
            this.col4aErtraegeInkassoprivileg.FieldName = "ErtraegeSHRInkassoprivileg";
            this.col4aErtraegeInkassoprivileg.Name = "col4aErtraegeInkassoprivileg";
            this.col4aErtraegeInkassoprivileg.SummaryItem.DisplayFormat = "{0:n2}";
            this.col4aErtraegeInkassoprivileg.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col4aErtraegeInkassoprivileg.Visible = true;
            this.col4aErtraegeInkassoprivileg.VisibleIndex = 5;
            // 
            // col4aUebrigeErtraege
            // 
            this.col4aUebrigeErtraege.Caption = "Übrige Erträge";
            this.col4aUebrigeErtraege.FieldName = "UebrigeErtraegeSHR";
            this.col4aUebrigeErtraege.Name = "col4aUebrigeErtraege";
            this.col4aUebrigeErtraege.SummaryItem.DisplayFormat = "{0:n2}";
            this.col4aUebrigeErtraege.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col4aUebrigeErtraege.Visible = true;
            this.col4aUebrigeErtraege.VisibleIndex = 6;
            // 
            // col4aDatumVonBis
            // 
            this.col4aDatumVonBis.Caption = "Beleg-Datum";
            this.col4aDatumVonBis.FieldName = "DatumVonBis";
            this.col4aDatumVonBis.Name = "col4aDatumVonBis";
            this.col4aDatumVonBis.Visible = true;
            this.col4aDatumVonBis.VisibleIndex = 7;
            // 
            // col4aGemeinde
            // 
            this.col4aGemeinde.Caption = "Gemeinde";
            this.col4aGemeinde.FieldName = "Gemeinde";
            this.col4aGemeinde.Name = "col4aGemeinde";
            this.col4aGemeinde.Visible = true;
            this.col4aGemeinde.VisibleIndex = 8;
            this.col4aGemeinde.Width = 100;
            // 
            // tpgAnhang4b
            // 
            this.tpgAnhang4b.Controls.Add(this.grdAnhang4b);
            this.tpgAnhang4b.Location = new System.Drawing.Point(6, 6);
            this.tpgAnhang4b.Name = "tpgAnhang4b";
            this.tpgAnhang4b.Padding = new System.Windows.Forms.Padding(6);
            this.tpgAnhang4b.Size = new System.Drawing.Size(772, 424);
            this.tpgAnhang4b.TabIndex = 3;
            this.tpgAnhang4b.Title = "4b – Ausserkantonale <2";
            // 
            // grdAnhang4b
            // 
            this.grdAnhang4b.DataSource = this.qryQuery;
            this.grdAnhang4b.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAnhang4b.EmbeddedNavigator.Name = "";
            this.grdAnhang4b.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdAnhang4b.Location = new System.Drawing.Point(6, 6);
            this.grdAnhang4b.MainView = this.grvAnhang4b;
            this.grdAnhang4b.Name = "grdAnhang4b";
            this.grdAnhang4b.Size = new System.Drawing.Size(760, 412);
            this.grdAnhang4b.TabIndex = 0;
            this.grdAnhang4b.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAnhang4b});
            // 
            // grvAnhang4b
            // 
            this.grvAnhang4b.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvAnhang4b.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang4b.Appearance.Empty.Options.UseBackColor = true;
            this.grvAnhang4b.Appearance.Empty.Options.UseFont = true;
            this.grvAnhang4b.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang4b.Appearance.EvenRow.Options.UseFont = true;
            this.grvAnhang4b.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvAnhang4b.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang4b.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvAnhang4b.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvAnhang4b.Appearance.FocusedCell.Options.UseFont = true;
            this.grvAnhang4b.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvAnhang4b.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvAnhang4b.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang4b.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvAnhang4b.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvAnhang4b.Appearance.FocusedRow.Options.UseFont = true;
            this.grvAnhang4b.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvAnhang4b.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvAnhang4b.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvAnhang4b.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvAnhang4b.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvAnhang4b.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvAnhang4b.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvAnhang4b.Appearance.GroupRow.Options.UseFont = true;
            this.grvAnhang4b.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvAnhang4b.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvAnhang4b.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvAnhang4b.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvAnhang4b.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvAnhang4b.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvAnhang4b.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvAnhang4b.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvAnhang4b.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang4b.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvAnhang4b.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvAnhang4b.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvAnhang4b.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvAnhang4b.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvAnhang4b.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvAnhang4b.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang4b.Appearance.OddRow.Options.UseFont = true;
            this.grvAnhang4b.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvAnhang4b.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang4b.Appearance.Row.Options.UseBackColor = true;
            this.grvAnhang4b.Appearance.Row.Options.UseFont = true;
            this.grvAnhang4b.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang4b.Appearance.SelectedRow.Options.UseFont = true;
            this.grvAnhang4b.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvAnhang4b.Appearance.VertLine.Options.UseBackColor = true;
            this.grvAnhang4b.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvAnhang4b.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col4bPersonalien,
            this.col4bAnzahlDossiers,
            this.col4bAnzahlPersonen,
            this.col4bAufwand,
            this.col4bErtrag,
            this.col4bErtraegeInkassoprivileg,
            this.col4bUebrigeErtraege,
            this.col4bDatumVonBis,
            this.col4bGemeinde});
            this.grvAnhang4b.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvAnhang4b.GridControl = this.grdAnhang4b;
            this.grvAnhang4b.Name = "grvAnhang4b";
            this.grvAnhang4b.OptionsBehavior.Editable = false;
            this.grvAnhang4b.OptionsCustomization.AllowFilter = false;
            this.grvAnhang4b.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvAnhang4b.OptionsNavigation.AutoFocusNewRow = true;
            this.grvAnhang4b.OptionsNavigation.UseTabKey = false;
            this.grvAnhang4b.OptionsView.ColumnAutoWidth = false;
            this.grvAnhang4b.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvAnhang4b.OptionsView.ShowFooter = true;
            this.grvAnhang4b.OptionsView.ShowGroupedColumns = true;
            this.grvAnhang4b.OptionsView.ShowGroupPanel = false;
            this.grvAnhang4b.OptionsView.ShowIndicator = false;
            // 
            // col4bPersonalien
            // 
            this.col4bPersonalien.Caption = "Personalien";
            this.col4bPersonalien.FieldName = "Personalien";
            this.col4bPersonalien.Name = "col4bPersonalien";
            this.col4bPersonalien.Visible = true;
            this.col4bPersonalien.VisibleIndex = 0;
            // 
            // col4bAnzahlDossiers
            // 
            this.col4bAnzahlDossiers.Caption = "Anzahl Dossiers";
            this.col4bAnzahlDossiers.FieldName = "AnzahlDossiers";
            this.col4bAnzahlDossiers.Name = "col4bAnzahlDossiers";
            this.col4bAnzahlDossiers.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col4bAnzahlDossiers.Visible = true;
            this.col4bAnzahlDossiers.VisibleIndex = 1;
            // 
            // col4bAnzahlPersonen
            // 
            this.col4bAnzahlPersonen.Caption = "Anzahl Personen";
            this.col4bAnzahlPersonen.FieldName = "AnzahlPersonen";
            this.col4bAnzahlPersonen.Name = "col4bAnzahlPersonen";
            this.col4bAnzahlPersonen.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col4bAnzahlPersonen.Visible = true;
            this.col4bAnzahlPersonen.VisibleIndex = 2;
            // 
            // col4bAufwand
            // 
            this.col4bAufwand.Caption = "Aufwand";
            this.col4bAufwand.FieldName = "AufwandSHR";
            this.col4bAufwand.Name = "col4bAufwand";
            this.col4bAufwand.SummaryItem.DisplayFormat = "{0:n2}";
            this.col4bAufwand.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col4bAufwand.Visible = true;
            this.col4bAufwand.VisibleIndex = 3;
            // 
            // col4bErtrag
            // 
            this.col4bErtrag.Caption = "Ertrag";
            this.col4bErtrag.FieldName = "ErtragSHRInkassoUebrig";
            this.col4bErtrag.Name = "col4bErtrag";
            this.col4bErtrag.SummaryItem.DisplayFormat = "{0:n2}";
            this.col4bErtrag.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col4bErtrag.Visible = true;
            this.col4bErtrag.VisibleIndex = 4;
            // 
            // col4bErtraegeInkassoprivileg
            // 
            this.col4bErtraegeInkassoprivileg.Caption = "Erträge Inkassoprivileg";
            this.col4bErtraegeInkassoprivileg.FieldName = "ErtraegeSHRInkassoprivileg";
            this.col4bErtraegeInkassoprivileg.Name = "col4bErtraegeInkassoprivileg";
            this.col4bErtraegeInkassoprivileg.SummaryItem.DisplayFormat = "{0:n2}";
            this.col4bErtraegeInkassoprivileg.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col4bErtraegeInkassoprivileg.Visible = true;
            this.col4bErtraegeInkassoprivileg.VisibleIndex = 5;
            // 
            // col4bUebrigeErtraege
            // 
            this.col4bUebrigeErtraege.Caption = "Übrige Erträge";
            this.col4bUebrigeErtraege.FieldName = "UebrigeErtraegeSHR";
            this.col4bUebrigeErtraege.Name = "col4bUebrigeErtraege";
            this.col4bUebrigeErtraege.SummaryItem.DisplayFormat = "{0:n2}";
            this.col4bUebrigeErtraege.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col4bUebrigeErtraege.Visible = true;
            this.col4bUebrigeErtraege.VisibleIndex = 6;
            // 
            // col4bDatumVonBis
            // 
            this.col4bDatumVonBis.Caption = "Beleg-Datum";
            this.col4bDatumVonBis.FieldName = "DatumVonBis";
            this.col4bDatumVonBis.Name = "col4bDatumVonBis";
            this.col4bDatumVonBis.Visible = true;
            this.col4bDatumVonBis.VisibleIndex = 7;
            // 
            // col4bGemeinde
            // 
            this.col4bGemeinde.Caption = "Gemeinde";
            this.col4bGemeinde.FieldName = "Gemeinde";
            this.col4bGemeinde.Name = "col4bGemeinde";
            this.col4bGemeinde.Visible = true;
            this.col4bGemeinde.VisibleIndex = 8;
            this.col4bGemeinde.Width = 100;
            // 
            // tpgAnhang4c
            // 
            this.tpgAnhang4c.Controls.Add(this.grdAnhang4c);
            this.tpgAnhang4c.Location = new System.Drawing.Point(6, 6);
            this.tpgAnhang4c.Name = "tpgAnhang4c";
            this.tpgAnhang4c.Padding = new System.Windows.Forms.Padding(6);
            this.tpgAnhang4c.Size = new System.Drawing.Size(772, 424);
            this.tpgAnhang4c.TabIndex = 4;
            this.tpgAnhang4c.Title = "4c – Ausserkantonale >2";
            // 
            // grdAnhang4c
            // 
            this.grdAnhang4c.DataSource = this.qryQuery;
            this.grdAnhang4c.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAnhang4c.EmbeddedNavigator.Name = "";
            this.grdAnhang4c.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdAnhang4c.Location = new System.Drawing.Point(6, 6);
            this.grdAnhang4c.MainView = this.grvAnhang4c;
            this.grdAnhang4c.Name = "grdAnhang4c";
            this.grdAnhang4c.Size = new System.Drawing.Size(760, 412);
            this.grdAnhang4c.TabIndex = 0;
            this.grdAnhang4c.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAnhang4c});
            // 
            // grvAnhang4c
            // 
            this.grvAnhang4c.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvAnhang4c.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang4c.Appearance.Empty.Options.UseBackColor = true;
            this.grvAnhang4c.Appearance.Empty.Options.UseFont = true;
            this.grvAnhang4c.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang4c.Appearance.EvenRow.Options.UseFont = true;
            this.grvAnhang4c.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvAnhang4c.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang4c.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvAnhang4c.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvAnhang4c.Appearance.FocusedCell.Options.UseFont = true;
            this.grvAnhang4c.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvAnhang4c.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvAnhang4c.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang4c.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvAnhang4c.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvAnhang4c.Appearance.FocusedRow.Options.UseFont = true;
            this.grvAnhang4c.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvAnhang4c.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvAnhang4c.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvAnhang4c.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvAnhang4c.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvAnhang4c.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvAnhang4c.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvAnhang4c.Appearance.GroupRow.Options.UseFont = true;
            this.grvAnhang4c.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvAnhang4c.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvAnhang4c.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvAnhang4c.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvAnhang4c.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvAnhang4c.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvAnhang4c.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvAnhang4c.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvAnhang4c.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang4c.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvAnhang4c.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvAnhang4c.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvAnhang4c.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvAnhang4c.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvAnhang4c.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvAnhang4c.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang4c.Appearance.OddRow.Options.UseFont = true;
            this.grvAnhang4c.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvAnhang4c.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang4c.Appearance.Row.Options.UseBackColor = true;
            this.grvAnhang4c.Appearance.Row.Options.UseFont = true;
            this.grvAnhang4c.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang4c.Appearance.SelectedRow.Options.UseFont = true;
            this.grvAnhang4c.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvAnhang4c.Appearance.VertLine.Options.UseBackColor = true;
            this.grvAnhang4c.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvAnhang4c.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col4cPersonalien,
            this.col4cAnzahlDossiers,
            this.col4cAnzahlPersonen,
            this.col4cAufwand,
            this.col4cErtrag,
            this.col4cErtraegeInkassoprivileg,
            this.col4cErtraegeHeimatliche,
            this.col4cUebrigeErtraege,
            this.col4cDatumVonBis,
            this.col4cGemeinde});
            this.grvAnhang4c.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvAnhang4c.GridControl = this.grdAnhang4c;
            this.grvAnhang4c.Name = "grvAnhang4c";
            this.grvAnhang4c.OptionsBehavior.Editable = false;
            this.grvAnhang4c.OptionsCustomization.AllowFilter = false;
            this.grvAnhang4c.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvAnhang4c.OptionsNavigation.AutoFocusNewRow = true;
            this.grvAnhang4c.OptionsNavigation.UseTabKey = false;
            this.grvAnhang4c.OptionsView.ColumnAutoWidth = false;
            this.grvAnhang4c.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvAnhang4c.OptionsView.ShowFooter = true;
            this.grvAnhang4c.OptionsView.ShowGroupedColumns = true;
            this.grvAnhang4c.OptionsView.ShowGroupPanel = false;
            this.grvAnhang4c.OptionsView.ShowIndicator = false;
            // 
            // col4cPersonalien
            // 
            this.col4cPersonalien.Caption = "Personalien";
            this.col4cPersonalien.FieldName = "Personalien";
            this.col4cPersonalien.Name = "col4cPersonalien";
            this.col4cPersonalien.Visible = true;
            this.col4cPersonalien.VisibleIndex = 0;
            this.col4cPersonalien.Width = 95;
            // 
            // col4cAnzahlDossiers
            // 
            this.col4cAnzahlDossiers.Caption = "Anzahl Dossiers";
            this.col4cAnzahlDossiers.FieldName = "AnzahlDossiers";
            this.col4cAnzahlDossiers.Name = "col4cAnzahlDossiers";
            this.col4cAnzahlDossiers.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col4cAnzahlDossiers.Visible = true;
            this.col4cAnzahlDossiers.VisibleIndex = 1;
            this.col4cAnzahlDossiers.Width = 102;
            // 
            // col4cAnzahlPersonen
            // 
            this.col4cAnzahlPersonen.Caption = "Anzahl Personen";
            this.col4cAnzahlPersonen.FieldName = "AnzahlPersonen";
            this.col4cAnzahlPersonen.Name = "col4cAnzahlPersonen";
            this.col4cAnzahlPersonen.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col4cAnzahlPersonen.Visible = true;
            this.col4cAnzahlPersonen.VisibleIndex = 2;
            this.col4cAnzahlPersonen.Width = 106;
            // 
            // col4cAufwand
            // 
            this.col4cAufwand.Caption = "Aufwand";
            this.col4cAufwand.FieldName = "AufwandSHR";
            this.col4cAufwand.Name = "col4cAufwand";
            this.col4cAufwand.SummaryItem.DisplayFormat = "{0:n2}";
            this.col4cAufwand.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col4cAufwand.Visible = true;
            this.col4cAufwand.VisibleIndex = 3;
            this.col4cAufwand.Width = 61;
            // 
            // col4cErtrag
            // 
            this.col4cErtrag.Caption = "Ertrag";
            this.col4cErtrag.FieldName = "ErtragSHR";
            this.col4cErtrag.Name = "col4cErtrag";
            this.col4cErtrag.SummaryItem.DisplayFormat = "{0:n2}";
            this.col4cErtrag.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col4cErtrag.Visible = true;
            this.col4cErtrag.VisibleIndex = 4;
            this.col4cErtrag.Width = 45;
            // 
            // col4cErtraegeInkassoprivileg
            // 
            this.col4cErtraegeInkassoprivileg.Caption = "Erträge Inkassoprivileg";
            this.col4cErtraegeInkassoprivileg.FieldName = "ErtraegeSHRInkassoprivileg";
            this.col4cErtraegeInkassoprivileg.Name = "col4cErtraegeInkassoprivileg";
            this.col4cErtraegeInkassoprivileg.SummaryItem.DisplayFormat = "{0:n2}";
            this.col4cErtraegeInkassoprivileg.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col4cErtraegeInkassoprivileg.Visible = true;
            this.col4cErtraegeInkassoprivileg.VisibleIndex = 5;
            this.col4cErtraegeInkassoprivileg.Width = 140;
            // 
            // col4cErtraegeHeimatliche
            // 
            this.col4cErtraegeHeimatliche.Caption = "Erträge Heimatliche";
            this.col4cErtraegeHeimatliche.FieldName = "ErtraegeSHRHeimatliche";
            this.col4cErtraegeHeimatliche.Name = "col4cErtraegeHeimatliche";
            this.col4cErtraegeHeimatliche.SummaryItem.DisplayFormat = "{0:n2}";
            this.col4cErtraegeHeimatliche.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col4cErtraegeHeimatliche.Visible = true;
            this.col4cErtraegeHeimatliche.VisibleIndex = 6;
            this.col4cErtraegeHeimatliche.Width = 119;
            // 
            // col4cUebrigeErtraege
            // 
            this.col4cUebrigeErtraege.Caption = "Übrige Erträge";
            this.col4cUebrigeErtraege.FieldName = "UebrigeErtraegeSHR";
            this.col4cUebrigeErtraege.Name = "col4cUebrigeErtraege";
            this.col4cUebrigeErtraege.SummaryItem.DisplayFormat = "{0:n2}";
            this.col4cUebrigeErtraege.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col4cUebrigeErtraege.Visible = true;
            this.col4cUebrigeErtraege.VisibleIndex = 7;
            this.col4cUebrigeErtraege.Width = 91;
            // 
            // col4cDatumVonBis
            // 
            this.col4cDatumVonBis.Caption = "Beleg-Datum";
            this.col4cDatumVonBis.FieldName = "DatumVonBis";
            this.col4cDatumVonBis.Name = "col4cDatumVonBis";
            this.col4cDatumVonBis.Visible = true;
            this.col4cDatumVonBis.VisibleIndex = 8;
            // 
            // col4cGemeinde
            // 
            this.col4cGemeinde.Caption = "Gemeinde";
            this.col4cGemeinde.FieldName = "Gemeinde";
            this.col4cGemeinde.Name = "col4cGemeinde";
            this.col4cGemeinde.Visible = true;
            this.col4cGemeinde.VisibleIndex = 9;
            this.col4cGemeinde.Width = 100;
            // 
            // tpgAnhang4d
            // 
            this.tpgAnhang4d.Controls.Add(this.grdAnhang4d);
            this.tpgAnhang4d.Location = new System.Drawing.Point(6, 6);
            this.tpgAnhang4d.Name = "tpgAnhang4d";
            this.tpgAnhang4d.Padding = new System.Windows.Forms.Padding(6);
            this.tpgAnhang4d.Size = new System.Drawing.Size(772, 424);
            this.tpgAnhang4d.TabIndex = 5;
            this.tpgAnhang4d.Title = "4d - Ausländer";
            // 
            // grdAnhang4d
            // 
            this.grdAnhang4d.DataSource = this.qryQuery;
            this.grdAnhang4d.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAnhang4d.EmbeddedNavigator.Name = "";
            this.grdAnhang4d.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdAnhang4d.Location = new System.Drawing.Point(6, 6);
            this.grdAnhang4d.MainView = this.grvAnhang4d;
            this.grdAnhang4d.Name = "grdAnhang4d";
            this.grdAnhang4d.Size = new System.Drawing.Size(760, 412);
            this.grdAnhang4d.TabIndex = 0;
            this.grdAnhang4d.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAnhang4d});
            // 
            // grvAnhang4d
            // 
            this.grvAnhang4d.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvAnhang4d.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang4d.Appearance.Empty.Options.UseBackColor = true;
            this.grvAnhang4d.Appearance.Empty.Options.UseFont = true;
            this.grvAnhang4d.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang4d.Appearance.EvenRow.Options.UseFont = true;
            this.grvAnhang4d.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvAnhang4d.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang4d.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvAnhang4d.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvAnhang4d.Appearance.FocusedCell.Options.UseFont = true;
            this.grvAnhang4d.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvAnhang4d.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvAnhang4d.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang4d.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvAnhang4d.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvAnhang4d.Appearance.FocusedRow.Options.UseFont = true;
            this.grvAnhang4d.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvAnhang4d.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvAnhang4d.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvAnhang4d.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvAnhang4d.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvAnhang4d.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvAnhang4d.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvAnhang4d.Appearance.GroupRow.Options.UseFont = true;
            this.grvAnhang4d.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvAnhang4d.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvAnhang4d.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvAnhang4d.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvAnhang4d.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvAnhang4d.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvAnhang4d.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvAnhang4d.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvAnhang4d.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang4d.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvAnhang4d.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvAnhang4d.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvAnhang4d.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvAnhang4d.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvAnhang4d.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvAnhang4d.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang4d.Appearance.OddRow.Options.UseFont = true;
            this.grvAnhang4d.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvAnhang4d.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang4d.Appearance.Row.Options.UseBackColor = true;
            this.grvAnhang4d.Appearance.Row.Options.UseFont = true;
            this.grvAnhang4d.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang4d.Appearance.SelectedRow.Options.UseFont = true;
            this.grvAnhang4d.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvAnhang4d.Appearance.VertLine.Options.UseBackColor = true;
            this.grvAnhang4d.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvAnhang4d.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col4dPersonalien,
            this.col4dAnzahlDossiers,
            this.col4dAnzahlPersonen,
            this.col4dAufwand,
            this.col4dErtrag,
            this.col4dErtraegeInkassoprivileg,
            this.col4dErtraegeHeimatliche,
            this.col4dUebrigeErtraege,
            this.col4dDatumVonBis,
            this.col4dGemeinde});
            this.grvAnhang4d.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvAnhang4d.GridControl = this.grdAnhang4d;
            this.grvAnhang4d.Name = "grvAnhang4d";
            this.grvAnhang4d.OptionsBehavior.Editable = false;
            this.grvAnhang4d.OptionsCustomization.AllowFilter = false;
            this.grvAnhang4d.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvAnhang4d.OptionsNavigation.AutoFocusNewRow = true;
            this.grvAnhang4d.OptionsNavigation.UseTabKey = false;
            this.grvAnhang4d.OptionsView.ColumnAutoWidth = false;
            this.grvAnhang4d.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvAnhang4d.OptionsView.ShowFooter = true;
            this.grvAnhang4d.OptionsView.ShowGroupedColumns = true;
            this.grvAnhang4d.OptionsView.ShowGroupPanel = false;
            this.grvAnhang4d.OptionsView.ShowIndicator = false;
            // 
            // col4dPersonalien
            // 
            this.col4dPersonalien.Caption = "Personalien";
            this.col4dPersonalien.FieldName = "Personalien";
            this.col4dPersonalien.Name = "col4dPersonalien";
            this.col4dPersonalien.Visible = true;
            this.col4dPersonalien.VisibleIndex = 0;
            this.col4dPersonalien.Width = 78;
            // 
            // col4dAnzahlDossiers
            // 
            this.col4dAnzahlDossiers.Caption = "Anzahl Dossiers";
            this.col4dAnzahlDossiers.FieldName = "AnzahlDossiers";
            this.col4dAnzahlDossiers.Name = "col4dAnzahlDossiers";
            this.col4dAnzahlDossiers.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col4dAnzahlDossiers.Visible = true;
            this.col4dAnzahlDossiers.VisibleIndex = 1;
            this.col4dAnzahlDossiers.Width = 102;
            // 
            // col4dAnzahlPersonen
            // 
            this.col4dAnzahlPersonen.Caption = "Anzahl Personen";
            this.col4dAnzahlPersonen.FieldName = "AnzahlPersonen";
            this.col4dAnzahlPersonen.Name = "col4dAnzahlPersonen";
            this.col4dAnzahlPersonen.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col4dAnzahlPersonen.Visible = true;
            this.col4dAnzahlPersonen.VisibleIndex = 2;
            this.col4dAnzahlPersonen.Width = 106;
            // 
            // col4dAufwand
            // 
            this.col4dAufwand.Caption = "Aufwand";
            this.col4dAufwand.FieldName = "AufwandSHR";
            this.col4dAufwand.Name = "col4dAufwand";
            this.col4dAufwand.SummaryItem.DisplayFormat = "{0:n2}";
            this.col4dAufwand.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col4dAufwand.Visible = true;
            this.col4dAufwand.VisibleIndex = 3;
            // 
            // col4dErtrag
            // 
            this.col4dErtrag.Caption = "Ertrag";
            this.col4dErtrag.FieldName = "ErtragSHR";
            this.col4dErtrag.Name = "col4dErtrag";
            this.col4dErtrag.SummaryItem.DisplayFormat = "{0:n2}";
            this.col4dErtrag.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col4dErtrag.Visible = true;
            this.col4dErtrag.VisibleIndex = 4;
            // 
            // col4dErtraegeInkassoprivileg
            // 
            this.col4dErtraegeInkassoprivileg.Caption = "Erträge Inkassoprivileg";
            this.col4dErtraegeInkassoprivileg.FieldName = "ErtraegeSHRInkassoprivileg";
            this.col4dErtraegeInkassoprivileg.Name = "col4dErtraegeInkassoprivileg";
            this.col4dErtraegeInkassoprivileg.SummaryItem.DisplayFormat = "{0:n2}";
            this.col4dErtraegeInkassoprivileg.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col4dErtraegeInkassoprivileg.Visible = true;
            this.col4dErtraegeInkassoprivileg.VisibleIndex = 5;
            this.col4dErtraegeInkassoprivileg.Width = 140;
            // 
            // col4dErtraegeHeimatliche
            // 
            this.col4dErtraegeHeimatliche.Caption = "Erträge Heimatliche";
            this.col4dErtraegeHeimatliche.FieldName = "ErtraegeSHRHeimatliche";
            this.col4dErtraegeHeimatliche.Name = "col4dErtraegeHeimatliche";
            this.col4dErtraegeHeimatliche.SummaryItem.DisplayFormat = "{0:n2}";
            this.col4dErtraegeHeimatliche.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col4dErtraegeHeimatliche.Visible = true;
            this.col4dErtraegeHeimatliche.VisibleIndex = 6;
            this.col4dErtraegeHeimatliche.Width = 119;
            // 
            // col4dUebrigeErtraege
            // 
            this.col4dUebrigeErtraege.Caption = "Übrige Erträge";
            this.col4dUebrigeErtraege.FieldName = "UebrigeErtraegeSHR";
            this.col4dUebrigeErtraege.Name = "col4dUebrigeErtraege";
            this.col4dUebrigeErtraege.SummaryItem.DisplayFormat = "{0:n2}";
            this.col4dUebrigeErtraege.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col4dUebrigeErtraege.Visible = true;
            this.col4dUebrigeErtraege.VisibleIndex = 7;
            this.col4dUebrigeErtraege.Width = 100;
            // 
            // col4dDatumVonBis
            // 
            this.col4dDatumVonBis.Caption = "Beleg-Datum";
            this.col4dDatumVonBis.FieldName = "DatumVonBis";
            this.col4dDatumVonBis.Name = "col4dDatumVonBis";
            this.col4dDatumVonBis.Visible = true;
            this.col4dDatumVonBis.VisibleIndex = 8;
            // 
            // col4dGemeinde
            // 
            this.col4dGemeinde.Caption = "Gemeinde";
            this.col4dGemeinde.FieldName = "Gemeinde";
            this.col4dGemeinde.Name = "col4dGemeinde";
            this.col4dGemeinde.Visible = true;
            this.col4dGemeinde.VisibleIndex = 9;
            this.col4dGemeinde.Width = 100;
            // 
            // tpgAnhang7a
            // 
            this.tpgAnhang7a.Controls.Add(this.grdAnhang7a);
            this.tpgAnhang7a.Location = new System.Drawing.Point(6, 6);
            this.tpgAnhang7a.Name = "tpgAnhang7a";
            this.tpgAnhang7a.Padding = new System.Windows.Forms.Padding(6);
            this.tpgAnhang7a.Size = new System.Drawing.Size(772, 424);
            this.tpgAnhang7a.TabIndex = 6;
            this.tpgAnhang7a.Title = "7a - ALBV";
            // 
            // grdAnhang7a
            // 
            this.grdAnhang7a.DataSource = this.qryQuery;
            this.grdAnhang7a.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAnhang7a.EmbeddedNavigator.Name = "";
            this.grdAnhang7a.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdAnhang7a.Location = new System.Drawing.Point(6, 6);
            this.grdAnhang7a.MainView = this.grvAnhang7a;
            this.grdAnhang7a.Name = "grdAnhang7a";
            this.grdAnhang7a.Size = new System.Drawing.Size(760, 412);
            this.grdAnhang7a.TabIndex = 0;
            this.grdAnhang7a.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAnhang7a});
            // 
            // grvAnhang7a
            // 
            this.grvAnhang7a.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvAnhang7a.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang7a.Appearance.Empty.Options.UseBackColor = true;
            this.grvAnhang7a.Appearance.Empty.Options.UseFont = true;
            this.grvAnhang7a.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang7a.Appearance.EvenRow.Options.UseFont = true;
            this.grvAnhang7a.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvAnhang7a.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang7a.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvAnhang7a.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvAnhang7a.Appearance.FocusedCell.Options.UseFont = true;
            this.grvAnhang7a.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvAnhang7a.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvAnhang7a.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang7a.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvAnhang7a.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvAnhang7a.Appearance.FocusedRow.Options.UseFont = true;
            this.grvAnhang7a.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvAnhang7a.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvAnhang7a.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvAnhang7a.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvAnhang7a.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvAnhang7a.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvAnhang7a.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvAnhang7a.Appearance.GroupRow.Options.UseFont = true;
            this.grvAnhang7a.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvAnhang7a.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvAnhang7a.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvAnhang7a.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvAnhang7a.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvAnhang7a.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvAnhang7a.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvAnhang7a.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvAnhang7a.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang7a.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvAnhang7a.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvAnhang7a.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvAnhang7a.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvAnhang7a.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvAnhang7a.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvAnhang7a.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang7a.Appearance.OddRow.Options.UseFont = true;
            this.grvAnhang7a.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvAnhang7a.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang7a.Appearance.Row.Options.UseBackColor = true;
            this.grvAnhang7a.Appearance.Row.Options.UseFont = true;
            this.grvAnhang7a.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang7a.Appearance.SelectedRow.Options.UseFont = true;
            this.grvAnhang7a.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvAnhang7a.Appearance.VertLine.Options.UseBackColor = true;
            this.grvAnhang7a.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvAnhang7a.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col7aPersonalien,
            this.col7aMonatlichAlimente,
            this.col7aBevorschussung,
            this.col7aInkassikosten,
            this.col7aRueckerstattung,
            this.col7aNetto,
            this.col7aDatumVonBis,
            this.col7aGemeinde});
            this.grvAnhang7a.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvAnhang7a.GridControl = this.grdAnhang7a;
            this.grvAnhang7a.Name = "grvAnhang7a";
            this.grvAnhang7a.OptionsBehavior.Editable = false;
            this.grvAnhang7a.OptionsCustomization.AllowFilter = false;
            this.grvAnhang7a.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvAnhang7a.OptionsNavigation.AutoFocusNewRow = true;
            this.grvAnhang7a.OptionsNavigation.UseTabKey = false;
            this.grvAnhang7a.OptionsView.ColumnAutoWidth = false;
            this.grvAnhang7a.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvAnhang7a.OptionsView.ShowFooter = true;
            this.grvAnhang7a.OptionsView.ShowGroupedColumns = true;
            this.grvAnhang7a.OptionsView.ShowGroupPanel = false;
            this.grvAnhang7a.OptionsView.ShowIndicator = false;
            // 
            // col7aPersonalien
            // 
            this.col7aPersonalien.Caption = "Personalien";
            this.col7aPersonalien.FieldName = "Personalien";
            this.col7aPersonalien.Name = "col7aPersonalien";
            this.col7aPersonalien.Visible = true;
            this.col7aPersonalien.VisibleIndex = 0;
            this.col7aPersonalien.Width = 125;
            // 
            // col7aMonatlichAlimente
            // 
            this.col7aMonatlichAlimente.Caption = "Monatlich Alimente";
            this.col7aMonatlichAlimente.FieldName = "MonatlichAlimente";
            this.col7aMonatlichAlimente.Name = "col7aMonatlichAlimente";
            this.col7aMonatlichAlimente.SummaryItem.DisplayFormat = "{0:n2}";
            this.col7aMonatlichAlimente.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col7aMonatlichAlimente.Visible = true;
            this.col7aMonatlichAlimente.VisibleIndex = 1;
            this.col7aMonatlichAlimente.Width = 124;
            // 
            // col7aBevorschussung
            // 
            this.col7aBevorschussung.Caption = "Bevorschussung";
            this.col7aBevorschussung.FieldName = "Bevorschussung";
            this.col7aBevorschussung.Name = "col7aBevorschussung";
            this.col7aBevorschussung.SummaryItem.DisplayFormat = "{0:n2}";
            this.col7aBevorschussung.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col7aBevorschussung.Visible = true;
            this.col7aBevorschussung.VisibleIndex = 2;
            this.col7aBevorschussung.Width = 113;
            // 
            // col7aInkassikosten
            // 
            this.col7aInkassikosten.Caption = "Inkassikosten";
            this.col7aInkassikosten.FieldName = "Inkassikosten";
            this.col7aInkassikosten.Name = "col7aInkassikosten";
            this.col7aInkassikosten.SummaryItem.DisplayFormat = "{0:n2}";
            this.col7aInkassikosten.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col7aInkassikosten.Visible = true;
            this.col7aInkassikosten.VisibleIndex = 3;
            this.col7aInkassikosten.Width = 104;
            // 
            // col7aRueckerstattung
            // 
            this.col7aRueckerstattung.Caption = "Rückerstattung";
            this.col7aRueckerstattung.FieldName = "Rueckerstattung";
            this.col7aRueckerstattung.Name = "col7aRueckerstattung";
            this.col7aRueckerstattung.SummaryItem.DisplayFormat = "{0:n2}";
            this.col7aRueckerstattung.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col7aRueckerstattung.Visible = true;
            this.col7aRueckerstattung.VisibleIndex = 4;
            this.col7aRueckerstattung.Width = 102;
            // 
            // col7aNetto
            // 
            this.col7aNetto.Caption = "Netto";
            this.col7aNetto.FieldName = "Netto";
            this.col7aNetto.Name = "col7aNetto";
            this.col7aNetto.SummaryItem.DisplayFormat = "{0:n2}";
            this.col7aNetto.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col7aNetto.Visible = true;
            this.col7aNetto.VisibleIndex = 5;
            // 
            // col7aDatumVonBis
            // 
            this.col7aDatumVonBis.Caption = "Beleg-Datum";
            this.col7aDatumVonBis.FieldName = "DatumVonBis";
            this.col7aDatumVonBis.Name = "col7aDatumVonBis";
            this.col7aDatumVonBis.Visible = true;
            this.col7aDatumVonBis.VisibleIndex = 6;
            // 
            // col7aGemeinde
            // 
            this.col7aGemeinde.Caption = "Gemeinde";
            this.col7aGemeinde.FieldName = "Gemeinde";
            this.col7aGemeinde.Name = "col7aGemeinde";
            this.col7aGemeinde.Visible = true;
            this.col7aGemeinde.VisibleIndex = 7;
            this.col7aGemeinde.Width = 100;
            // 
            // colAnzahlDossiers
            // 
            this.colAnzahlDossiers.Name = "colAnzahlDossiers";
            // 
            // colAnzahlPersonen
            // 
            this.colAnzahlPersonen.Name = "colAnzahlPersonen";
            // 
            // colAufwand
            // 
            this.colAufwand.Name = "colAufwand";
            // 
            // colBaWVCode
            // 
            this.colBaWVCode.Name = "colBaWVCode";
            // 
            // colBevorschussung
            // 
            this.colBevorschussung.Name = "colBevorschussung";
            // 
            // colBezugsgrsse
            // 
            this.colBezugsgrsse.Name = "colBezugsgrsse";
            // 
            // colbrigeErtrge
            // 
            this.colbrigeErtrge.Name = "colbrigeErtrge";
            // 
            // colErtrag
            // 
            this.colErtrag.Name = "colErtrag";
            // 
            // colErtrgeHeimatliche
            // 
            this.colErtrgeHeimatliche.Name = "colErtrgeHeimatliche";
            // 
            // colErtrgeInkassoprivileg
            // 
            this.colErtrgeInkassoprivileg.Name = "colErtrgeInkassoprivileg";
            // 
            // colInkassikosten
            // 
            this.colInkassikosten.Name = "colInkassikosten";
            // 
            // colListeAnzahlDossiers
            // 
            this.colListeAnzahlDossiers.Caption = "Anzahl Dossiers";
            this.colListeAnzahlDossiers.FieldName = "AnzahlDossiers";
            this.colListeAnzahlDossiers.Name = "colListeAnzahlDossiers";
            this.colListeAnzahlDossiers.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colListeAnzahlDossiers.Visible = true;
            this.colListeAnzahlDossiers.VisibleIndex = 2;
            // 
            // colListeAnzahlPersonen
            // 
            this.colListeAnzahlPersonen.Caption = "Anzahl Personen";
            this.colListeAnzahlPersonen.FieldName = "AnzahlPersonen";
            this.colListeAnzahlPersonen.Name = "colListeAnzahlPersonen";
            this.colListeAnzahlPersonen.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colListeAnzahlPersonen.Visible = true;
            this.colListeAnzahlPersonen.VisibleIndex = 3;
            // 
            // colListeAufwand
            // 
            this.colListeAufwand.Caption = "Aufwand";
            this.colListeAufwand.FieldName = "Aufwand";
            this.colListeAufwand.Name = "colListeAufwand";
            this.colListeAufwand.SummaryItem.DisplayFormat = "{0:n2}";
            this.colListeAufwand.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colListeAufwand.Visible = true;
            this.colListeAufwand.VisibleIndex = 4;
            // 
            // colListeBevorschussung
            // 
            this.colListeBevorschussung.Caption = "Bevorschussung";
            this.colListeBevorschussung.FieldName = "Bevorschussung";
            this.colListeBevorschussung.Name = "colListeBevorschussung";
            this.colListeBevorschussung.SummaryItem.DisplayFormat = "{0:n2}";
            this.colListeBevorschussung.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colListeBevorschussung.Visible = true;
            this.colListeBevorschussung.VisibleIndex = 10;
            // 
            // colListeBezugsgroesse
            // 
            this.colListeBezugsgroesse.Caption = "Bezugsgrösse";
            this.colListeBezugsgroesse.FieldName = "Bezugsgroesse";
            this.colListeBezugsgroesse.Name = "colListeBezugsgroesse";
            this.colListeBezugsgroesse.Visible = true;
            this.colListeBezugsgroesse.VisibleIndex = 1;
            // 
            // colListeErtraegeHeimatliche
            // 
            this.colListeErtraegeHeimatliche.Caption = "Erträge Heimatliche";
            this.colListeErtraegeHeimatliche.FieldName = "ErtraegeHeimatliche";
            this.colListeErtraegeHeimatliche.Name = "colListeErtraegeHeimatliche";
            this.colListeErtraegeHeimatliche.SummaryItem.DisplayFormat = "{0:n2}";
            this.colListeErtraegeHeimatliche.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colListeErtraegeHeimatliche.Visible = true;
            this.colListeErtraegeHeimatliche.VisibleIndex = 8;
            // 
            // colListeErtraegeInkassoprivileg
            // 
            this.colListeErtraegeInkassoprivileg.Caption = "Erträge Inkassoprivileg";
            this.colListeErtraegeInkassoprivileg.FieldName = "ErtraegeInkassoprivileg";
            this.colListeErtraegeInkassoprivileg.Name = "colListeErtraegeInkassoprivileg";
            this.colListeErtraegeInkassoprivileg.SummaryItem.DisplayFormat = "{0:n2}";
            this.colListeErtraegeInkassoprivileg.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colListeErtraegeInkassoprivileg.Visible = true;
            this.colListeErtraegeInkassoprivileg.VisibleIndex = 6;
            // 
            // colListeErtrag
            // 
            this.colListeErtrag.Caption = "Ertrag";
            this.colListeErtrag.FieldName = "Ertrag";
            this.colListeErtrag.Name = "colListeErtrag";
            this.colListeErtrag.SummaryItem.DisplayFormat = "{0:n2}";
            this.colListeErtrag.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colListeErtrag.Visible = true;
            this.colListeErtrag.VisibleIndex = 5;
            // 
            // colListeInkassikosten
            // 
            this.colListeInkassikosten.Caption = "Inkassikosten";
            this.colListeInkassikosten.FieldName = "Inkassikosten";
            this.colListeInkassikosten.Name = "colListeInkassikosten";
            this.colListeInkassikosten.SummaryItem.DisplayFormat = "{0:n2}";
            this.colListeInkassikosten.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colListeInkassikosten.Visible = true;
            this.colListeInkassikosten.VisibleIndex = 11;
            // 
            // colListeMonatlichAlimente
            // 
            this.colListeMonatlichAlimente.Caption = "Monatlich Alimente";
            this.colListeMonatlichAlimente.FieldName = "MonatlichAlimente";
            this.colListeMonatlichAlimente.Name = "colListeMonatlichAlimente";
            this.colListeMonatlichAlimente.SummaryItem.DisplayFormat = "{0:n2}";
            this.colListeMonatlichAlimente.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colListeMonatlichAlimente.Visible = true;
            this.colListeMonatlichAlimente.VisibleIndex = 9;
            // 
            // colListeNetto
            // 
            this.colListeNetto.Caption = "Netto";
            this.colListeNetto.FieldName = "Netto";
            this.colListeNetto.Name = "colListeNetto";
            this.colListeNetto.SummaryItem.DisplayFormat = "{0:n2}";
            this.colListeNetto.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colListeNetto.Visible = true;
            this.colListeNetto.VisibleIndex = 13;
            // 
            // colListePersonalien
            // 
            this.colListePersonalien.Caption = "Personalien";
            this.colListePersonalien.FieldName = "Personalien";
            this.colListePersonalien.Name = "colListePersonalien";
            this.colListePersonalien.Visible = true;
            this.colListePersonalien.VisibleIndex = 0;
            // 
            // colListeRueckerstattung
            // 
            this.colListeRueckerstattung.Caption = "Rückerstattung";
            this.colListeRueckerstattung.FieldName = "Rueckerstattung";
            this.colListeRueckerstattung.Name = "colListeRueckerstattung";
            this.colListeRueckerstattung.SummaryItem.DisplayFormat = "{0:n2}";
            this.colListeRueckerstattung.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colListeRueckerstattung.Visible = true;
            this.colListeRueckerstattung.VisibleIndex = 12;
            // 
            // colListeUebrigeErtraege
            // 
            this.colListeUebrigeErtraege.Caption = "Übrige Erträge";
            this.colListeUebrigeErtraege.FieldName = "UebrigeErtraege";
            this.colListeUebrigeErtraege.Name = "colListeUebrigeErtraege";
            this.colListeUebrigeErtraege.SummaryItem.DisplayFormat = "{0:n2}";
            this.colListeUebrigeErtraege.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colListeUebrigeErtraege.Visible = true;
            this.colListeUebrigeErtraege.VisibleIndex = 7;
            // 
            // colMonatlichAlimente
            // 
            this.colMonatlichAlimente.Name = "colMonatlichAlimente";
            // 
            // colNetto
            // 
            this.colNetto.Name = "colNetto";
            // 
            // colPersonalien
            // 
            this.colPersonalien.Name = "colPersonalien";
            // 
            // colRckerstattung
            // 
            this.colRckerstattung.Name = "colRckerstattung";
            // 
            // tabPageEx1
            // 
            this.tabPageEx1.Location = new System.Drawing.Point(0, 0);
            this.tabPageEx1.Name = "tabPageEx1";
            this.tabPageEx1.Size = new System.Drawing.Size(150, 150);
            this.tabPageEx1.TabIndex = 0;
            this.tabPageEx1.Title = "tabPageEx1";
            // 
            // tabPageEx2
            // 
            this.tabPageEx2.Location = new System.Drawing.Point(0, 0);
            this.tabPageEx2.Name = "tabPageEx2";
            this.tabPageEx2.Size = new System.Drawing.Size(150, 150);
            this.tabPageEx2.TabIndex = 0;
            this.tabPageEx2.Title = "tabPageEx2";
            // 
            // colListeDatumVonBis
            // 
            this.colListeDatumVonBis.Caption = "Beleg-Datum";
            this.colListeDatumVonBis.FieldName = "DatumVonBis";
            this.colListeDatumVonBis.Name = "colListeDatumVonBis";
            this.colListeDatumVonBis.Visible = true;
            this.colListeDatumVonBis.VisibleIndex = 14;
            // 
            // tpgAnhang5
            // 
            this.tpgAnhang5.Controls.Add(this.grdAnhang5);
            this.tpgAnhang5.Location = new System.Drawing.Point(6, 6);
            this.tpgAnhang5.Name = "tpgAnhang5";
            this.tpgAnhang5.Padding = new System.Windows.Forms.Padding(6);
            this.tpgAnhang5.Size = new System.Drawing.Size(772, 424);
            this.tpgAnhang5.TabIndex = 7;
            this.tpgAnhang5.Title = "5 - Zuschüsse Heim";
            // 
            // grdAnhang5
            // 
            this.grdAnhang5.DataSource = this.qryQuery;
            this.grdAnhang5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAnhang5.EmbeddedNavigator.Name = "";
            this.grdAnhang5.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdAnhang5.Location = new System.Drawing.Point(6, 6);
            this.grdAnhang5.MainView = this.grvAnhang5;
            this.grdAnhang5.Name = "grdAnhang5";
            this.grdAnhang5.Size = new System.Drawing.Size(760, 412);
            this.grdAnhang5.TabIndex = 1;
            this.grdAnhang5.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAnhang5});
            // 
            // grvAnhang5
            // 
            this.grvAnhang5.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvAnhang5.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang5.Appearance.Empty.Options.UseBackColor = true;
            this.grvAnhang5.Appearance.Empty.Options.UseFont = true;
            this.grvAnhang5.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang5.Appearance.EvenRow.Options.UseFont = true;
            this.grvAnhang5.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvAnhang5.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang5.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvAnhang5.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvAnhang5.Appearance.FocusedCell.Options.UseFont = true;
            this.grvAnhang5.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvAnhang5.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvAnhang5.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang5.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvAnhang5.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvAnhang5.Appearance.FocusedRow.Options.UseFont = true;
            this.grvAnhang5.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvAnhang5.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvAnhang5.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvAnhang5.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvAnhang5.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvAnhang5.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvAnhang5.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvAnhang5.Appearance.GroupRow.Options.UseFont = true;
            this.grvAnhang5.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvAnhang5.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvAnhang5.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvAnhang5.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvAnhang5.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvAnhang5.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvAnhang5.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvAnhang5.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvAnhang5.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang5.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvAnhang5.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvAnhang5.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvAnhang5.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvAnhang5.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvAnhang5.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvAnhang5.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang5.Appearance.OddRow.Options.UseFont = true;
            this.grvAnhang5.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvAnhang5.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang5.Appearance.Row.Options.UseBackColor = true;
            this.grvAnhang5.Appearance.Row.Options.UseFont = true;
            this.grvAnhang5.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang5.Appearance.SelectedRow.Options.UseFont = true;
            this.grvAnhang5.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvAnhang5.Appearance.VertLine.Options.UseBackColor = true;
            this.grvAnhang5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvAnhang5.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col5Personalien,
            this.col5AnzahlDossiers,
            this.col5AnzahlPersonen,
            this.col5Aufwand,
            this.col5Ertrag,
            this.col5ErtraegeInkassoprivileg,
            this.col5UebrigeErtraege,
            this.col5NameHeim,
            this.col5DatumVonBis,
            this.col5Gemeinde});
            this.grvAnhang5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvAnhang5.GridControl = this.grdAnhang5;
            this.grvAnhang5.Name = "grvAnhang5";
            this.grvAnhang5.OptionsBehavior.Editable = false;
            this.grvAnhang5.OptionsCustomization.AllowFilter = false;
            this.grvAnhang5.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvAnhang5.OptionsNavigation.AutoFocusNewRow = true;
            this.grvAnhang5.OptionsNavigation.UseTabKey = false;
            this.grvAnhang5.OptionsView.ColumnAutoWidth = false;
            this.grvAnhang5.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvAnhang5.OptionsView.ShowFooter = true;
            this.grvAnhang5.OptionsView.ShowGroupedColumns = true;
            this.grvAnhang5.OptionsView.ShowGroupPanel = false;
            this.grvAnhang5.OptionsView.ShowIndicator = false;
            // 
            // col5Personalien
            // 
            this.col5Personalien.Caption = "Personalien";
            this.col5Personalien.FieldName = "Personalien";
            this.col5Personalien.Name = "col5Personalien";
            this.col5Personalien.Visible = true;
            this.col5Personalien.VisibleIndex = 0;
            this.col5Personalien.Width = 78;
            // 
            // col5AnzahlDossiers
            // 
            this.col5AnzahlDossiers.Caption = "Anzahl Dossiers";
            this.col5AnzahlDossiers.FieldName = "AnzahlDossiers";
            this.col5AnzahlDossiers.Name = "col5AnzahlDossiers";
            this.col5AnzahlDossiers.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col5AnzahlDossiers.Visible = true;
            this.col5AnzahlDossiers.VisibleIndex = 1;
            this.col5AnzahlDossiers.Width = 102;
            // 
            // col5AnzahlPersonen
            // 
            this.col5AnzahlPersonen.Caption = "Anzahl Personen";
            this.col5AnzahlPersonen.FieldName = "AnzahlPersonen";
            this.col5AnzahlPersonen.Name = "col5AnzahlPersonen";
            this.col5AnzahlPersonen.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col5AnzahlPersonen.Visible = true;
            this.col5AnzahlPersonen.VisibleIndex = 2;
            this.col5AnzahlPersonen.Width = 106;
            // 
            // col5Aufwand
            // 
            this.col5Aufwand.Caption = "Aufwand";
            this.col5Aufwand.FieldName = "AufwandSHR";
            this.col5Aufwand.Name = "col5Aufwand";
            this.col5Aufwand.SummaryItem.DisplayFormat = "{0:n2}";
            this.col5Aufwand.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col5Aufwand.Visible = true;
            this.col5Aufwand.VisibleIndex = 3;
            // 
            // col5Ertrag
            // 
            this.col5Ertrag.Caption = "Ertrag";
            this.col5Ertrag.FieldName = "ErtragSHRInkassoUebrig";
            this.col5Ertrag.Name = "col5Ertrag";
            this.col5Ertrag.SummaryItem.DisplayFormat = "{0:n2}";
            this.col5Ertrag.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col5Ertrag.Visible = true;
            this.col5Ertrag.VisibleIndex = 4;
            // 
            // col5ErtraegeInkassoprivileg
            // 
            this.col5ErtraegeInkassoprivileg.Caption = "Erträge Inkassoprivileg";
            this.col5ErtraegeInkassoprivileg.FieldName = "ErtraegeSHRInkassoprivileg";
            this.col5ErtraegeInkassoprivileg.Name = "col5ErtraegeInkassoprivileg";
            this.col5ErtraegeInkassoprivileg.SummaryItem.DisplayFormat = "{0:n2}";
            this.col5ErtraegeInkassoprivileg.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col5ErtraegeInkassoprivileg.Visible = true;
            this.col5ErtraegeInkassoprivileg.VisibleIndex = 5;
            this.col5ErtraegeInkassoprivileg.Width = 140;
            // 
            // col5UebrigeErtraege
            // 
            this.col5UebrigeErtraege.Caption = "Übrige Erträge";
            this.col5UebrigeErtraege.FieldName = "UebrigeErtraegeSHR";
            this.col5UebrigeErtraege.Name = "col5UebrigeErtraege";
            this.col5UebrigeErtraege.SummaryItem.DisplayFormat = "{0:n2}";
            this.col5UebrigeErtraege.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col5UebrigeErtraege.Visible = true;
            this.col5UebrigeErtraege.VisibleIndex = 7;
            this.col5UebrigeErtraege.Width = 100;
            // 
            // col5NameHeim
            // 
            this.col5NameHeim.Caption = "Name des Heims";
            this.col5NameHeim.FieldName = "NameHeim";
            this.col5NameHeim.Name = "col5NameHeim";
            this.col5NameHeim.SummaryItem.DisplayFormat = "{0:n2}";
            this.col5NameHeim.SummaryItem.FieldName = "ErtraegeSHRHeimatliche";
            this.col5NameHeim.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col5NameHeim.Visible = true;
            this.col5NameHeim.VisibleIndex = 6;
            this.col5NameHeim.Width = 119;
            // 
            // col5DatumVonBis
            // 
            this.col5DatumVonBis.Caption = "Beleg-Datum";
            this.col5DatumVonBis.FieldName = "DatumVonBis";
            this.col5DatumVonBis.Name = "col5DatumVonBis";
            // 
            // col5Gemeinde
            // 
            this.col5Gemeinde.Caption = "Gemeinde";
            this.col5Gemeinde.FieldName = "Gemeinde";
            this.col5Gemeinde.Name = "col5Gemeinde";
            this.col5Gemeinde.Visible = true;
            this.col5Gemeinde.VisibleIndex = 8;
            this.col5Gemeinde.Width = 100;
            // 
            // tpgAnhang6a
            // 
            this.tpgAnhang6a.Controls.Add(this.grdAnhang6a);
            this.tpgAnhang6a.Location = new System.Drawing.Point(6, 6);
            this.tpgAnhang6a.Name = "tpgAnhang6a";
            this.tpgAnhang6a.Padding = new System.Windows.Forms.Padding(6);
            this.tpgAnhang6a.Size = new System.Drawing.Size(772, 424);
            this.tpgAnhang6a.TabIndex = 8;
            this.tpgAnhang6a.Title = "6a - Zuschüsse nicht Heim";
            // 
            // grdAnhang6a
            // 
            this.grdAnhang6a.DataSource = this.qryQuery;
            this.grdAnhang6a.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAnhang6a.EmbeddedNavigator.Name = "";
            this.grdAnhang6a.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdAnhang6a.Location = new System.Drawing.Point(6, 6);
            this.grdAnhang6a.MainView = this.grvAnhang6a;
            this.grdAnhang6a.Name = "grdAnhang6a";
            this.grdAnhang6a.Size = new System.Drawing.Size(760, 412);
            this.grdAnhang6a.TabIndex = 2;
            this.grdAnhang6a.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAnhang6a});
            // 
            // grvAnhang6a
            // 
            this.grvAnhang6a.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvAnhang6a.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang6a.Appearance.Empty.Options.UseBackColor = true;
            this.grvAnhang6a.Appearance.Empty.Options.UseFont = true;
            this.grvAnhang6a.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang6a.Appearance.EvenRow.Options.UseFont = true;
            this.grvAnhang6a.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvAnhang6a.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang6a.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvAnhang6a.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvAnhang6a.Appearance.FocusedCell.Options.UseFont = true;
            this.grvAnhang6a.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvAnhang6a.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvAnhang6a.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang6a.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvAnhang6a.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvAnhang6a.Appearance.FocusedRow.Options.UseFont = true;
            this.grvAnhang6a.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvAnhang6a.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvAnhang6a.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvAnhang6a.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvAnhang6a.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvAnhang6a.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvAnhang6a.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvAnhang6a.Appearance.GroupRow.Options.UseFont = true;
            this.grvAnhang6a.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvAnhang6a.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvAnhang6a.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvAnhang6a.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvAnhang6a.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvAnhang6a.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvAnhang6a.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvAnhang6a.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvAnhang6a.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang6a.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvAnhang6a.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvAnhang6a.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvAnhang6a.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvAnhang6a.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvAnhang6a.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvAnhang6a.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang6a.Appearance.OddRow.Options.UseFont = true;
            this.grvAnhang6a.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvAnhang6a.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang6a.Appearance.Row.Options.UseBackColor = true;
            this.grvAnhang6a.Appearance.Row.Options.UseFont = true;
            this.grvAnhang6a.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAnhang6a.Appearance.SelectedRow.Options.UseFont = true;
            this.grvAnhang6a.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvAnhang6a.Appearance.VertLine.Options.UseBackColor = true;
            this.grvAnhang6a.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvAnhang6a.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col6aPersonalien,
            this.col6aAnzahlDossiers,
            this.col6aAnzahlPersonen,
            this.col6aAufwand,
            this.col6aErtrag,
            this.col6aErtraegeInkassoprivileg,
            this.col6aUebrigeErtraege,
            this.col6aNameHeim,
            this.col6aDatumVonBis,
            this.col6aGemeinde});
            this.grvAnhang6a.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvAnhang6a.GridControl = this.grdAnhang6a;
            this.grvAnhang6a.Name = "grvAnhang6a";
            this.grvAnhang6a.OptionsBehavior.Editable = false;
            this.grvAnhang6a.OptionsCustomization.AllowFilter = false;
            this.grvAnhang6a.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvAnhang6a.OptionsNavigation.AutoFocusNewRow = true;
            this.grvAnhang6a.OptionsNavigation.UseTabKey = false;
            this.grvAnhang6a.OptionsView.ColumnAutoWidth = false;
            this.grvAnhang6a.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvAnhang6a.OptionsView.ShowFooter = true;
            this.grvAnhang6a.OptionsView.ShowGroupedColumns = true;
            this.grvAnhang6a.OptionsView.ShowGroupPanel = false;
            this.grvAnhang6a.OptionsView.ShowIndicator = false;
            // 
            // col6aPersonalien
            // 
            this.col6aPersonalien.Caption = "Personalien";
            this.col6aPersonalien.FieldName = "Personalien";
            this.col6aPersonalien.Name = "col6aPersonalien";
            this.col6aPersonalien.Visible = true;
            this.col6aPersonalien.VisibleIndex = 0;
            this.col6aPersonalien.Width = 78;
            // 
            // col6aAnzahlDossiers
            // 
            this.col6aAnzahlDossiers.Caption = "Anzahl Dossiers";
            this.col6aAnzahlDossiers.FieldName = "AnzahlDossiers";
            this.col6aAnzahlDossiers.Name = "col6aAnzahlDossiers";
            this.col6aAnzahlDossiers.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col6aAnzahlDossiers.Visible = true;
            this.col6aAnzahlDossiers.VisibleIndex = 1;
            this.col6aAnzahlDossiers.Width = 102;
            // 
            // col6aAnzahlPersonen
            // 
            this.col6aAnzahlPersonen.Caption = "Anzahl Personen";
            this.col6aAnzahlPersonen.FieldName = "AnzahlPersonen";
            this.col6aAnzahlPersonen.Name = "col6aAnzahlPersonen";
            this.col6aAnzahlPersonen.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col6aAnzahlPersonen.Visible = true;
            this.col6aAnzahlPersonen.VisibleIndex = 2;
            this.col6aAnzahlPersonen.Width = 106;
            // 
            // col6aAufwand
            // 
            this.col6aAufwand.Caption = "Aufwand";
            this.col6aAufwand.FieldName = "AufwandSHR";
            this.col6aAufwand.Name = "col6aAufwand";
            this.col6aAufwand.SummaryItem.DisplayFormat = "{0:n2}";
            this.col6aAufwand.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col6aAufwand.Visible = true;
            this.col6aAufwand.VisibleIndex = 3;
            // 
            // col6aErtrag
            // 
            this.col6aErtrag.Caption = "Ertrag";
            this.col6aErtrag.FieldName = "ErtragSHRInkassoUebrig";
            this.col6aErtrag.Name = "col6aErtrag";
            this.col6aErtrag.SummaryItem.DisplayFormat = "{0:n2}";
            this.col6aErtrag.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col6aErtrag.Visible = true;
            this.col6aErtrag.VisibleIndex = 4;
            // 
            // col6aErtraegeInkassoprivileg
            // 
            this.col6aErtraegeInkassoprivileg.Caption = "Erträge Inkassoprivileg";
            this.col6aErtraegeInkassoprivileg.FieldName = "ErtraegeSHRInkassoprivileg";
            this.col6aErtraegeInkassoprivileg.Name = "col6aErtraegeInkassoprivileg";
            this.col6aErtraegeInkassoprivileg.SummaryItem.DisplayFormat = "{0:n2}";
            this.col6aErtraegeInkassoprivileg.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col6aErtraegeInkassoprivileg.Visible = true;
            this.col6aErtraegeInkassoprivileg.VisibleIndex = 5;
            this.col6aErtraegeInkassoprivileg.Width = 140;
            // 
            // col6aUebrigeErtraege
            // 
            this.col6aUebrigeErtraege.Caption = "Übrige Erträge";
            this.col6aUebrigeErtraege.FieldName = "UebrigeErtraegeSHR";
            this.col6aUebrigeErtraege.Name = "col6aUebrigeErtraege";
            this.col6aUebrigeErtraege.SummaryItem.DisplayFormat = "{0:n2}";
            this.col6aUebrigeErtraege.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col6aUebrigeErtraege.Visible = true;
            this.col6aUebrigeErtraege.VisibleIndex = 7;
            this.col6aUebrigeErtraege.Width = 100;
            // 
            // col6aNameHeim
            // 
            this.col6aNameHeim.Caption = "Name des Heims";
            this.col6aNameHeim.FieldName = "NameHeim";
            this.col6aNameHeim.Name = "col6aNameHeim";
            this.col6aNameHeim.SummaryItem.DisplayFormat = "{0:n2}";
            this.col6aNameHeim.SummaryItem.FieldName = "ErtraegeSHRHeimatliche";
            this.col6aNameHeim.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col6aNameHeim.Visible = true;
            this.col6aNameHeim.VisibleIndex = 6;
            this.col6aNameHeim.Width = 119;
            // 
            // col6aDatumVonBis
            // 
            this.col6aDatumVonBis.Caption = "Beleg-Datum";
            this.col6aDatumVonBis.FieldName = "DatumVonBis";
            this.col6aDatumVonBis.Name = "col6aDatumVonBis";
            // 
            // col6aGemeinde
            // 
            this.col6aGemeinde.Caption = "Gemeinde";
            this.col6aGemeinde.FieldName = "Gemeinde";
            this.col6aGemeinde.Name = "col6aGemeinde";
            this.col6aGemeinde.Visible = true;
            this.col6aGemeinde.VisibleIndex = 8;
            this.col6aGemeinde.Width = 100;
            // 
            // lblZustaendigeGemeindeX
            // 
            this.lblZustaendigeGemeindeX.Location = new System.Drawing.Point(8, 86);
            this.lblZustaendigeGemeindeX.Name = "lblZustaendigeGemeindeX";
            this.lblZustaendigeGemeindeX.Size = new System.Drawing.Size(89, 24);
            this.lblZustaendigeGemeindeX.TabIndex = 57;
            this.lblZustaendigeGemeindeX.Text = "zust. Gemeinde";
            this.lblZustaendigeGemeindeX.UseCompatibleTextRendering = true;
            // 
            // edtZustaendigeGemeindeX
            // 
            this.edtZustaendigeGemeindeX.Location = new System.Drawing.Point(116, 86);
            this.edtZustaendigeGemeindeX.LOVName = "GemeindeSozialdienst";
            this.edtZustaendigeGemeindeX.Name = "edtZustaendigeGemeindeX";
            this.edtZustaendigeGemeindeX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZustaendigeGemeindeX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZustaendigeGemeindeX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZustaendigeGemeindeX.Properties.Appearance.Options.UseBackColor = true;
            this.edtZustaendigeGemeindeX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZustaendigeGemeindeX.Properties.Appearance.Options.UseFont = true;
            this.edtZustaendigeGemeindeX.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtZustaendigeGemeindeX.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtZustaendigeGemeindeX.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtZustaendigeGemeindeX.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtZustaendigeGemeindeX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtZustaendigeGemeindeX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtZustaendigeGemeindeX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZustaendigeGemeindeX.Properties.NullText = "";
            this.edtZustaendigeGemeindeX.Properties.ShowFooter = false;
            this.edtZustaendigeGemeindeX.Properties.ShowHeader = false;
            this.edtZustaendigeGemeindeX.Size = new System.Drawing.Size(240, 24);
            this.edtZustaendigeGemeindeX.TabIndex = 56;
            // 
            // edtNurOhneGemeindeX
            // 
            this.edtNurOhneGemeindeX.EditValue = false;
            this.edtNurOhneGemeindeX.Location = new System.Drawing.Point(116, 116);
            this.edtNurOhneGemeindeX.Name = "edtNurOhneGemeindeX";
            this.edtNurOhneGemeindeX.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtNurOhneGemeindeX.Properties.Appearance.Options.UseBackColor = true;
            this.edtNurOhneGemeindeX.Properties.Caption = "nur ohne zust. Gemeinde";
            this.edtNurOhneGemeindeX.Size = new System.Drawing.Size(240, 19);
            this.edtNurOhneGemeindeX.TabIndex = 59;
            // 
            // colListeGemeinde
            // 
            this.colListeGemeinde.Caption = "Gemeinde";
            this.colListeGemeinde.FieldName = "Gemeinde";
            this.colListeGemeinde.Name = "colListeGemeinde";
            this.colListeGemeinde.Visible = true;
            this.colListeGemeinde.VisibleIndex = 15;
            this.colListeGemeinde.Width = 100;
            // 
            // panBottomDockSpacer
            // 
            this.panBottomDockSpacer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panBottomDockSpacer.Location = new System.Drawing.Point(6, 388);
            this.panBottomDockSpacer.Name = "panBottomDockSpacer";
            this.panBottomDockSpacer.Size = new System.Drawing.Size(760, 6);
            this.panBottomDockSpacer.TabIndex = 1;
            // 
            // CtlQueryKbSozialhilferechnung
            // 
            this.Name = "CtlQueryKbSozialhilferechnung";
            this.Load += new System.EventHandler(this.CtlQueryKbSozialhilferechnung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVonX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBisX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVonX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBisX)).EndInit();
            this.tpgAnhang4a.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAnhang4a)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAnhang4a)).EndInit();
            this.tpgAnhang4b.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAnhang4b)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAnhang4b)).EndInit();
            this.tpgAnhang4c.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAnhang4c)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAnhang4c)).EndInit();
            this.tpgAnhang4d.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAnhang4d)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAnhang4d)).EndInit();
            this.tpgAnhang7a.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAnhang7a)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAnhang7a)).EndInit();
            this.tpgAnhang5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAnhang5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAnhang5)).EndInit();
            this.tpgAnhang6a.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAnhang6a)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAnhang6a)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustaendigeGemeindeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigeGemeindeX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigeGemeindeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurOhneGemeindeX.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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

        private void CtlQueryKbSozialhilferechnung_Load(object sender, System.EventArgs e)
        {
            qryQuery.SelectStatement = KliBuUtil.SELECT_SOZIALHILFERECHNUNG;

            try
            {
                this._kbPeriodeID = Convert.ToInt32(FormController.GetMessage("FrmKbKlientenbuchhaltung", false, "Action", "KbPeriodeID"));
            }
            catch
            {
                this._kbPeriodeID = 0;
            }

            kissSearch.SelectParameters = new object[] { _kbPeriodeID, KiSS4.DB.Session.User.LanguageCode };
        }

        private void qryQuery_AfterFill(object sender, System.EventArgs e)
        {
            foreach (DataRow row in qryQuery.DataTable.Rows)
            {
                decimal netto = (decimal)0.0;
                netto += (decimal)row["Bevorschussung"] + (decimal)row["Inkassikosten"] - (decimal)row["Rueckerstattung"];
                row["Netto"] = netto;
            }

            qryQuery.DataTable.AcceptChanges();
            qryQuery.RowModified = false;

            grdQuery1.DataSource = qryQuery;
            grdAnhang7a.DataSource = qryQuery;
        }

        private void tabControlSearch_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            if (this.tabControlSearch.SelectedTab == tpgListe)
            {
                qryQuery.DataTable.DefaultView.RowFilter = null;
            }
            if (this.tabControlSearch.SelectedTab == tpgAnhang4a)
            {
                qryQuery.DataTable.DefaultView.RowFilter = string.Format("BaWVCode$ = 1");
            }
            else if (this.tabControlSearch.SelectedTab == tpgAnhang4b)
            {
                qryQuery.DataTable.DefaultView.RowFilter = string.Format("BaWVCode$ = 22");
            }
            else if (this.tabControlSearch.SelectedTab == tpgAnhang4c)
            {
                qryQuery.DataTable.DefaultView.RowFilter = string.Format("BaWVCode$ = 21");
            }
            else if (this.tabControlSearch.SelectedTab == tpgAnhang4d)
            {
                qryQuery.DataTable.DefaultView.RowFilter = string.Format("BaWVCode$ IN (31,32,33)");
            }
            else if (this.tabControlSearch.SelectedTab == tpgAnhang5)
            {
                qryQuery.DataTable.DefaultView.RowFilter = string.Format("BaWVCode$ = 50");
            }
            else if (this.tabControlSearch.SelectedTab == tpgAnhang6a)
            {
                qryQuery.DataTable.DefaultView.RowFilter = string.Format("BaWVCode$ = 51");
            }
            else if (this.tabControlSearch.SelectedTab == tpgAnhang7a)
            {
                qryQuery.DataTable.DefaultView.RowFilter = string.Format("BaWVCode$ = 9999");
            }
        }

        #endregion
    }
}