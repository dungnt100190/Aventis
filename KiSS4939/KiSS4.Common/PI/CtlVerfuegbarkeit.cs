using System;

using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Common.PI
{
    /// <summary>
    /// Control, used for managing availability of users BW/ED in addition to CtlMitarbeiter
    /// </summary>
    public class CtlVerfuegbarkeit : KiSS4.Common.KissSearchUserControl
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Fields

        private int? _defaultSearchModule = null; // store the default search module (only if restricted rights)
        private bool _hasBwRights;
        private bool _hasEdRights;
        private KiSS4.Gui.KissButton btnMitarbeiterdaten;
        private KiSS4.Gui.KissCheckEdit chkDiAbend;
        private KiSS4.Gui.KissCheckEdit chkDiMorgen;
        private KiSS4.Gui.KissCheckEdit chkDiNachmittag;
        private KiSS4.Gui.KissCheckEdit chkDiNacht;
        private KiSS4.Gui.KissCheckEdit chkDoAbend;
        private KiSS4.Gui.KissCheckEdit chkDoMorgen;
        private KiSS4.Gui.KissCheckEdit chkDoNachmittag;
        private KiSS4.Gui.KissCheckEdit chkDoNacht;
        private KiSS4.Gui.KissCheckEdit chkFrAbend;
        private KiSS4.Gui.KissCheckEdit chkFrMorgen;
        private KiSS4.Gui.KissCheckEdit chkFrNachmittag;
        private KiSS4.Gui.KissCheckEdit chkFrNacht;
        private KiSS4.Gui.KissCheckEdit chkGrundangabenGruppen;
        private KiSS4.Gui.KissCheckEdit chkGrundangabenKeineFrequenz;
        private KiSS4.Gui.KissCheckEdit chkGrundangabenMobilitaetEigenesFahrzeug;
        private KiSS4.Gui.KissCheckEdit chkGrundangabenMobilitaetFahrausweis;
        private KiSS4.Gui.KissCheckEdit chkMiAbend;
        private KiSS4.Gui.KissCheckEdit chkMiMorgen;
        private KiSS4.Gui.KissCheckEdit chkMiNachmittag;
        private KiSS4.Gui.KissCheckEdit chkMiNacht;
        private KiSS4.Gui.KissCheckEdit chkMoAbend;
        private KiSS4.Gui.KissCheckEdit chkMoMorgen;
        private KiSS4.Gui.KissCheckEdit chkMoNachmittag;
        private KiSS4.Gui.KissCheckEdit chkMoNacht;
        private KiSS4.Gui.KissCheckEdit chkSaAbend;
        private KiSS4.Gui.KissCheckEdit chkSaMorgen;
        private KiSS4.Gui.KissCheckEdit chkSaNachmittag;
        private KiSS4.Gui.KissCheckEdit chkSaNacht;
        private KiSS4.Gui.KissCheckEdit chkSoAbend;
        private KiSS4.Gui.KissCheckEdit chkSoMorgen;
        private KiSS4.Gui.KissCheckEdit chkSoNachmittag;
        private KiSS4.Gui.KissCheckEdit chkSoNacht;
        private KiSS4.Gui.KissCheckEdit chkSucheEigenesFahrzeug;
        private KiSS4.Gui.KissCheckEdit chkSucheNurAktive;
        private DevExpress.XtraGrid.Columns.GridColumn colAdresse;
        private DevExpress.XtraGrid.Columns.GridColumn colAnrede;
        private DevExpress.XtraGrid.Columns.GridColumn colBereitschaftMitarbeitInGruppen;
        private DevExpress.XtraGrid.Columns.GridColumn colBezirk;
        private DevExpress.XtraGrid.Columns.GridColumn colBwAktiv;
        private DevExpress.XtraGrid.Columns.GridColumn colDienstagAbend;
        private DevExpress.XtraGrid.Columns.GridColumn colDienstagMorgen;
        private DevExpress.XtraGrid.Columns.GridColumn colDienstagNachmittag;
        private DevExpress.XtraGrid.Columns.GridColumn colDienstagNacht;
        private DevExpress.XtraGrid.Columns.GridColumn colDonnerstagAbend;
        private DevExpress.XtraGrid.Columns.GridColumn colDonnerstagMorgen;
        private DevExpress.XtraGrid.Columns.GridColumn colDonnerstagNachmittag;
        private DevExpress.XtraGrid.Columns.GridColumn colDonnerstagNacht;
        private DevExpress.XtraGrid.Columns.GridColumn colEdAktiv;
        private DevExpress.XtraGrid.Columns.GridColumn colEigenesFahrzeug;
        private DevExpress.XtraGrid.Columns.GridColumn colEinsatzregionen;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colFreitagAbend;
        private DevExpress.XtraGrid.Columns.GridColumn colFreitagMorgen;
        private DevExpress.XtraGrid.Columns.GridColumn colFreitagNachmittag;
        private DevExpress.XtraGrid.Columns.GridColumn colFreitagNacht;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colIsBwMitarbeiter;
        private DevExpress.XtraGrid.Columns.GridColumn colIsEdMitarbeiter;
        private DevExpress.XtraGrid.Columns.GridColumn colMittwochAbend;
        private DevExpress.XtraGrid.Columns.GridColumn colMittwochMorgen;
        private DevExpress.XtraGrid.Columns.GridColumn colMittwochNachmittag;
        private DevExpress.XtraGrid.Columns.GridColumn colMittwochNacht;
        private DevExpress.XtraGrid.Columns.GridColumn colMontagAbend;
        private DevExpress.XtraGrid.Columns.GridColumn colMontagMorgen;
        private DevExpress.XtraGrid.Columns.GridColumn colMontagNachmittag;
        private DevExpress.XtraGrid.Columns.GridColumn colMontagNacht;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colPLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colSamstagAbend;
        private DevExpress.XtraGrid.Columns.GridColumn colSamstagMorgen;
        private DevExpress.XtraGrid.Columns.GridColumn colSamstagNachmittag;
        private DevExpress.XtraGrid.Columns.GridColumn colSamstagNacht;
        private DevExpress.XtraGrid.Columns.GridColumn colSonntagAbend;
        private DevExpress.XtraGrid.Columns.GridColumn colSonntagMorgen;
        private DevExpress.XtraGrid.Columns.GridColumn colSonntagNachmittag;
        private DevExpress.XtraGrid.Columns.GridColumn colSonntagNacht;
        private DevExpress.XtraGrid.Columns.GridColumn colTelefon;
        private DevExpress.XtraGrid.Columns.GridColumn colTypBW;
        private DevExpress.XtraGrid.Columns.GridColumn colTypED;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colZeitNichtDefiniert;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissMemoEdit edtArbeitswocheDienstag;
        private KiSS4.Gui.KissMemoEdit edtArbeitswocheDonnerstag;
        private KiSS4.Gui.KissMemoEdit edtArbeitswocheFreitag;
        private KiSS4.Gui.KissMemoEdit edtArbeitswocheMittwoch;
        private KiSS4.Gui.KissMemoEdit edtArbeitswocheMontag;
        private KiSS4.Gui.KissCheckedLookupEdit edtEinsatzorteOrte;
        private KiSS4.Gui.KissCheckedLookupEdit edtEinsatzorteRegionen;
        private KiSS4.Gui.KissMemoEdit edtGrundangabenBemerkungen;
        private KiSS4.Gui.KissCheckedLookupEdit edtGrundangabenFrequenz;
        private KiSS4.Gui.KissTextEdit edtGrundangabenMitarbeiter;
        private KiSS4.Gui.KissTextEdit edtGrundangabenMobilitaetBemerkungen;
        private KiSS4.Gui.KissTextEdit edtGrundangabenTelefon;
        private KissTextEdit edtGrundangabenTypBW;
        private KiSS4.Gui.KissTextEdit edtGrundangabenTypED;
        private KiSS4.Gui.KissLookUpEdit edtSucheEinsatzregion;
        private KissLookUpEdit edtSucheModul;
        private KiSS4.Gui.KissTextEdit edtSucheName;
        private KiSS4.Gui.KissTextEdit edtSucheOrt;
        private KissLookUpEdit edtSucheTypBW;
        private KiSS4.Gui.KissLookUpEdit edtSucheTypED;
        private KiSS4.Gui.KissMemoEdit edtWochenendeSamstag;
        private KiSS4.Gui.KissMemoEdit edtWochenendeSonntag;
        private KiSS4.Gui.KissGrid grdEdVerfuegbarkeit;
        private KiSS4.Gui.KissGroupBox grpArbeitswocheDienstag;
        private KiSS4.Gui.KissGroupBox grpArbeitswocheDonnerstag;
        private KiSS4.Gui.KissGroupBox grpArbeitswocheFreitag;
        private KiSS4.Gui.KissGroupBox grpArbeitswocheMittwoch;
        private KiSS4.Gui.KissGroupBox grpArbeitswocheMontag;
        private KiSS4.Gui.KissGroupBox grpWochenendeSamstag;
        private KiSS4.Gui.KissGroupBox grpWochenendeSonntag;
        private DevExpress.XtraGrid.Views.Grid.GridView grvEdVerfuegbarkeit;
        private KissMemoEdit kissMemoEdit2;
        private KissMemoEdit kissMemoEdit3;
        private KissLabel lblAktuelleBegleitungen;
        private KissLabel lblEhemaligeBegleitungen;
        private KiSS4.Gui.KissLabel lblEinsatzorteOrte;
        private KiSS4.Gui.KissLabel lblEinsatzorteRegionen;
        private KiSS4.Gui.KissLabel lblGrundangabenBemerkungen;
        private KiSS4.Gui.KissLabel lblGrundangabenFrequenz;
        private KiSS4.Gui.KissLabel lblGrundangabenGruppen;
        private KiSS4.Gui.KissLabel lblGrundangabenMitarbeiter;
        private KiSS4.Gui.KissLabel lblGrundangabenMobilitaet;
        private KiSS4.Gui.KissLabel lblGrundangabenTelefon;
        private KissLabel lblGrundangabenTypBW;
        private KiSS4.Gui.KissLabel lblGrundangabenTypED;
        private KiSS4.Gui.KissLabel lblSucheEinsatzregion;
        private KissLabel lblSucheModul;
        private KiSS4.Gui.KissLabel lblSucheName;
        private KiSS4.Gui.KissLabel lblSucheOrt;
        private KissLabel lblSucheTypBW;
        private KiSS4.Gui.KissLabel lblSucheTypED;
        private KiSS4.DB.SqlQuery qryDienstag;
        private KiSS4.DB.SqlQuery qryDonnerstag;
        private KiSS4.DB.SqlQuery qryEdVerfuegbarkeit;
        private KiSS4.DB.SqlQuery qryFreitag;
        private KiSS4.DB.SqlQuery qryMittwoch;
        private KiSS4.DB.SqlQuery qryMontag;
        private KiSS4.DB.SqlQuery qrySamstag;
        private KiSS4.DB.SqlQuery qrySonntag;
        private KiSS4.Gui.KissTabControlEx tabVerfuegbarkeit;
        private System.Windows.Forms.TableLayoutPanel tblEinsatzplanung;
        private SharpLibrary.WinControls.TabPageEx tpgArbeitswoche;
        private SharpLibrary.WinControls.TabPageEx tpgEinsatzorte;
        private SharpLibrary.WinControls.TabPageEx tpgEinsatzplanung;
        private SharpLibrary.WinControls.TabPageEx tpgGrundangaben;
        private SharpLibrary.WinControls.TabPageEx tpgWochenende;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlVerfuegbarkeit"/> class.
        /// </summary>
        public CtlVerfuegbarkeit()
        {
            this.InitializeComponent();

            // setup daily-queries (do before SetupRights and Init!)
            this.SetupSQLDailyQuery(qryMontag, 1);
            this.SetupSQLDailyQuery(qryDienstag, 2);
            this.SetupSQLDailyQuery(qryMittwoch, 3);
            this.SetupSQLDailyQuery(qryDonnerstag, 4);
            this.SetupSQLDailyQuery(qryFreitag, 5);
            this.SetupSQLDailyQuery(qrySamstag, 6);
            this.SetupSQLDailyQuery(qrySonntag, 7);

            // setup rights (do before init!)
            this.SetupRights();

            // init gui
            this.Init();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlVerfuegbarkeit));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdEdVerfuegbarkeit = new KiSS4.Gui.KissGrid();
            this.qryEdVerfuegbarkeit = new KiSS4.DB.SqlQuery(this.components);
            this.grvEdVerfuegbarkeit = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIsBwMitarbeiter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBwAktiv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsEdMitarbeiter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEdAktiv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBezirk = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelefon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTypBW = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTypED = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinsatzregionen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEigenesFahrzeug = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBereitschaftMitarbeitInGruppen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZeitNichtDefiniert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMontagMorgen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMontagNachmittag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMontagAbend = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMontagNacht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDienstagMorgen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDienstagNachmittag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDienstagAbend = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDienstagNacht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMittwochMorgen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMittwochNachmittag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMittwochAbend = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMittwochNacht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDonnerstagMorgen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDonnerstagNachmittag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDonnerstagAbend = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDonnerstagNacht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFreitagMorgen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFreitagNachmittag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFreitagAbend = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFreitagNacht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSamstagMorgen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSamstagNachmittag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSamstagAbend = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSamstagNacht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSonntagMorgen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSonntagNachmittag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSonntagAbend = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSonntagNacht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnrede = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdresse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblSucheName = new KiSS4.Gui.KissLabel();
            this.edtSucheName = new KiSS4.Gui.KissTextEdit();
            this.lblSucheTypED = new KiSS4.Gui.KissLabel();
            this.edtSucheTypED = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheOrt = new KiSS4.Gui.KissLabel();
            this.edtSucheOrt = new KiSS4.Gui.KissTextEdit();
            this.lblSucheEinsatzregion = new KiSS4.Gui.KissLabel();
            this.edtSucheEinsatzregion = new KiSS4.Gui.KissLookUpEdit();
            this.chkSucheEigenesFahrzeug = new KiSS4.Gui.KissCheckEdit();
            this.chkSucheNurAktive = new KiSS4.Gui.KissCheckEdit();
            this.tabVerfuegbarkeit = new KiSS4.Gui.KissTabControlEx();
            this.tpgGrundangaben = new SharpLibrary.WinControls.TabPageEx();
            this.lblGrundangabenTypBW = new KiSS4.Gui.KissLabel();
            this.edtGrundangabenTypBW = new KiSS4.Gui.KissTextEdit();
            this.edtGrundangabenBemerkungen = new KiSS4.Gui.KissMemoEdit();
            this.lblGrundangabenBemerkungen = new KiSS4.Gui.KissLabel();
            this.chkGrundangabenGruppen = new KiSS4.Gui.KissCheckEdit();
            this.lblGrundangabenGruppen = new KiSS4.Gui.KissLabel();
            this.chkGrundangabenKeineFrequenz = new KiSS4.Gui.KissCheckEdit();
            this.edtGrundangabenFrequenz = new KiSS4.Gui.KissCheckedLookupEdit();
            this.lblGrundangabenFrequenz = new KiSS4.Gui.KissLabel();
            this.edtGrundangabenTypED = new KiSS4.Gui.KissTextEdit();
            this.lblGrundangabenTypED = new KiSS4.Gui.KissLabel();
            this.edtGrundangabenMobilitaetBemerkungen = new KiSS4.Gui.KissTextEdit();
            this.chkGrundangabenMobilitaetEigenesFahrzeug = new KiSS4.Gui.KissCheckEdit();
            this.chkGrundangabenMobilitaetFahrausweis = new KiSS4.Gui.KissCheckEdit();
            this.lblGrundangabenMobilitaet = new KiSS4.Gui.KissLabel();
            this.edtGrundangabenTelefon = new KiSS4.Gui.KissTextEdit();
            this.lblGrundangabenTelefon = new KiSS4.Gui.KissLabel();
            this.edtGrundangabenMitarbeiter = new KiSS4.Gui.KissTextEdit();
            this.lblGrundangabenMitarbeiter = new KiSS4.Gui.KissLabel();
            this.tpgEinsatzorte = new SharpLibrary.WinControls.TabPageEx();
            this.edtEinsatzorteRegionen = new KiSS4.Gui.KissCheckedLookupEdit();
            this.lblEinsatzorteRegionen = new KiSS4.Gui.KissLabel();
            this.edtEinsatzorteOrte = new KiSS4.Gui.KissCheckedLookupEdit();
            this.lblEinsatzorteOrte = new KiSS4.Gui.KissLabel();
            this.tpgArbeitswoche = new SharpLibrary.WinControls.TabPageEx();
            this.edtArbeitswocheFreitag = new KiSS4.Gui.KissMemoEdit();
            this.qryFreitag = new KiSS4.DB.SqlQuery(this.components);
            this.grpArbeitswocheFreitag = new KiSS4.Gui.KissGroupBox();
            this.chkFrNacht = new KiSS4.Gui.KissCheckEdit();
            this.chkFrAbend = new KiSS4.Gui.KissCheckEdit();
            this.chkFrNachmittag = new KiSS4.Gui.KissCheckEdit();
            this.chkFrMorgen = new KiSS4.Gui.KissCheckEdit();
            this.edtArbeitswocheDonnerstag = new KiSS4.Gui.KissMemoEdit();
            this.qryDonnerstag = new KiSS4.DB.SqlQuery(this.components);
            this.grpArbeitswocheDonnerstag = new KiSS4.Gui.KissGroupBox();
            this.chkDoNacht = new KiSS4.Gui.KissCheckEdit();
            this.chkDoAbend = new KiSS4.Gui.KissCheckEdit();
            this.chkDoNachmittag = new KiSS4.Gui.KissCheckEdit();
            this.chkDoMorgen = new KiSS4.Gui.KissCheckEdit();
            this.edtArbeitswocheMittwoch = new KiSS4.Gui.KissMemoEdit();
            this.qryMittwoch = new KiSS4.DB.SqlQuery(this.components);
            this.grpArbeitswocheMittwoch = new KiSS4.Gui.KissGroupBox();
            this.chkMiNacht = new KiSS4.Gui.KissCheckEdit();
            this.chkMiAbend = new KiSS4.Gui.KissCheckEdit();
            this.chkMiNachmittag = new KiSS4.Gui.KissCheckEdit();
            this.chkMiMorgen = new KiSS4.Gui.KissCheckEdit();
            this.edtArbeitswocheDienstag = new KiSS4.Gui.KissMemoEdit();
            this.qryDienstag = new KiSS4.DB.SqlQuery(this.components);
            this.grpArbeitswocheDienstag = new KiSS4.Gui.KissGroupBox();
            this.chkDiNacht = new KiSS4.Gui.KissCheckEdit();
            this.chkDiAbend = new KiSS4.Gui.KissCheckEdit();
            this.chkDiNachmittag = new KiSS4.Gui.KissCheckEdit();
            this.chkDiMorgen = new KiSS4.Gui.KissCheckEdit();
            this.grpArbeitswocheMontag = new KiSS4.Gui.KissGroupBox();
            this.chkMoNacht = new KiSS4.Gui.KissCheckEdit();
            this.qryMontag = new KiSS4.DB.SqlQuery(this.components);
            this.chkMoAbend = new KiSS4.Gui.KissCheckEdit();
            this.chkMoNachmittag = new KiSS4.Gui.KissCheckEdit();
            this.chkMoMorgen = new KiSS4.Gui.KissCheckEdit();
            this.edtArbeitswocheMontag = new KiSS4.Gui.KissMemoEdit();
            this.tpgWochenende = new SharpLibrary.WinControls.TabPageEx();
            this.edtWochenendeSonntag = new KiSS4.Gui.KissMemoEdit();
            this.qrySonntag = new KiSS4.DB.SqlQuery(this.components);
            this.grpWochenendeSonntag = new KiSS4.Gui.KissGroupBox();
            this.chkSoNacht = new KiSS4.Gui.KissCheckEdit();
            this.chkSoAbend = new KiSS4.Gui.KissCheckEdit();
            this.chkSoNachmittag = new KiSS4.Gui.KissCheckEdit();
            this.chkSoMorgen = new KiSS4.Gui.KissCheckEdit();
            this.edtWochenendeSamstag = new KiSS4.Gui.KissMemoEdit();
            this.qrySamstag = new KiSS4.DB.SqlQuery(this.components);
            this.grpWochenendeSamstag = new KiSS4.Gui.KissGroupBox();
            this.chkSaNacht = new KiSS4.Gui.KissCheckEdit();
            this.chkSaAbend = new KiSS4.Gui.KissCheckEdit();
            this.chkSaNachmittag = new KiSS4.Gui.KissCheckEdit();
            this.chkSaMorgen = new KiSS4.Gui.KissCheckEdit();
            this.tpgEinsatzplanung = new SharpLibrary.WinControls.TabPageEx();
            this.tblEinsatzplanung = new System.Windows.Forms.TableLayoutPanel();
            this.lblAktuelleBegleitungen = new KiSS4.Gui.KissLabel();
            this.lblEhemaligeBegleitungen = new KiSS4.Gui.KissLabel();
            this.kissMemoEdit2 = new KiSS4.Gui.KissMemoEdit();
            this.kissMemoEdit3 = new KiSS4.Gui.KissMemoEdit();
            this.btnMitarbeiterdaten = new KiSS4.Gui.KissButton();
            this.edtSucheModul = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheModul = new KiSS4.Gui.KissLabel();
            this.edtSucheTypBW = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheTypBW = new KiSS4.Gui.KissLabel();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEdVerfuegbarkeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryEdVerfuegbarkeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEdVerfuegbarkeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheTypED)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTypED)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTypED.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheEinsatzregion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheEinsatzregion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheEinsatzregion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheEigenesFahrzeug.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheNurAktive.Properties)).BeginInit();
            this.tabVerfuegbarkeit.SuspendLayout();
            this.tpgGrundangaben.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundangabenTypBW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundangabenTypBW.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundangabenBemerkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundangabenBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGrundangabenGruppen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundangabenGruppen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGrundangabenKeineFrequenz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundangabenFrequenz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundangabenFrequenz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundangabenTypED.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundangabenTypED)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundangabenMobilitaetBemerkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGrundangabenMobilitaetEigenesFahrzeug.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGrundangabenMobilitaetFahrausweis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundangabenMobilitaet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundangabenTelefon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundangabenTelefon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundangabenMitarbeiter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundangabenMitarbeiter)).BeginInit();
            this.tpgEinsatzorte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzorteRegionen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzorteRegionen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzorteOrte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzorteOrte)).BeginInit();
            this.tpgArbeitswoche.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtArbeitswocheFreitag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFreitag)).BeginInit();
            this.grpArbeitswocheFreitag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkFrNacht.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFrAbend.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFrNachmittag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFrMorgen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtArbeitswocheDonnerstag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryDonnerstag)).BeginInit();
            this.grpArbeitswocheDonnerstag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkDoNacht.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDoAbend.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDoNachmittag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDoMorgen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtArbeitswocheMittwoch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryMittwoch)).BeginInit();
            this.grpArbeitswocheMittwoch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkMiNacht.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMiAbend.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMiNachmittag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMiMorgen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtArbeitswocheDienstag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryDienstag)).BeginInit();
            this.grpArbeitswocheDienstag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkDiNacht.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDiAbend.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDiNachmittag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDiMorgen.Properties)).BeginInit();
            this.grpArbeitswocheMontag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkMoNacht.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryMontag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMoAbend.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMoNachmittag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMoMorgen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtArbeitswocheMontag.Properties)).BeginInit();
            this.tpgWochenende.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtWochenendeSonntag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrySonntag)).BeginInit();
            this.grpWochenendeSonntag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSoNacht.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSoAbend.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSoNachmittag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSoMorgen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWochenendeSamstag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrySamstag)).BeginInit();
            this.grpWochenendeSamstag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSaNacht.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSaAbend.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSaNachmittag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSaMorgen.Properties)).BeginInit();
            this.tpgEinsatzplanung.SuspendLayout();
            this.tblEinsatzplanung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblAktuelleBegleitungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEhemaligeBegleitungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissMemoEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissMemoEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheModul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheModul.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheModul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTypBW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTypBW.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheTypBW)).BeginInit();
            this.SuspendLayout();
            //
            // searchTitle
            //
            this.searchTitle.Size = new System.Drawing.Size(776, 24);
            //
            // tabControlSearch
            //
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.Size = new System.Drawing.Size(800, 264);
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.grdEdVerfuegbarkeit);
            this.tpgListe.Size = new System.Drawing.Size(788, 226);
            this.tpgListe.Title = "Liste";
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.lblSucheTypBW);
            this.tpgSuchen.Controls.Add(this.edtSucheTypBW);
            this.tpgSuchen.Controls.Add(this.lblSucheModul);
            this.tpgSuchen.Controls.Add(this.edtSucheModul);
            this.tpgSuchen.Controls.Add(this.chkSucheNurAktive);
            this.tpgSuchen.Controls.Add(this.chkSucheEigenesFahrzeug);
            this.tpgSuchen.Controls.Add(this.edtSucheEinsatzregion);
            this.tpgSuchen.Controls.Add(this.lblSucheEinsatzregion);
            this.tpgSuchen.Controls.Add(this.edtSucheOrt);
            this.tpgSuchen.Controls.Add(this.lblSucheOrt);
            this.tpgSuchen.Controls.Add(this.edtSucheTypED);
            this.tpgSuchen.Controls.Add(this.lblSucheTypED);
            this.tpgSuchen.Controls.Add(this.edtSucheName);
            this.tpgSuchen.Controls.Add(this.lblSucheName);
            this.tpgSuchen.Size = new System.Drawing.Size(788, 226);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheTypED, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheTypED, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheOrt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheOrt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheEinsatzregion, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheEinsatzregion, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkSucheEigenesFahrzeug, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkSucheNurAktive, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheModul, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheModul, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheTypBW, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheTypBW, 0);
            //
            // grdEdVerfuegbarkeit
            //
            this.grdEdVerfuegbarkeit.DataSource = this.qryEdVerfuegbarkeit;
            this.grdEdVerfuegbarkeit.Dock = System.Windows.Forms.DockStyle.Fill;
            //
            //
            //
            this.grdEdVerfuegbarkeit.EmbeddedNavigator.Name = "";
            this.grdEdVerfuegbarkeit.EmbeddedNavigator.TextStringFormat = "Enregistrement {0} de {1}";
            this.grdEdVerfuegbarkeit.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdEdVerfuegbarkeit.Location = new System.Drawing.Point(0, 0);
            this.grdEdVerfuegbarkeit.MainView = this.grvEdVerfuegbarkeit;
            this.grdEdVerfuegbarkeit.Name = "grdEdVerfuegbarkeit";
            this.grdEdVerfuegbarkeit.Size = new System.Drawing.Size(788, 226);
            this.grdEdVerfuegbarkeit.TabIndex = 0;
            this.grdEdVerfuegbarkeit.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvEdVerfuegbarkeit});
            //
            // qryEdVerfuegbarkeit
            //
            this.qryEdVerfuegbarkeit.HostControl = this;
            this.qryEdVerfuegbarkeit.SelectStatement = resources.GetString("qryEdVerfuegbarkeit.SelectStatement");
            this.qryEdVerfuegbarkeit.TableName = "EdVerfuegbarkeit";
            this.qryEdVerfuegbarkeit.AfterFill += new System.EventHandler(this.qryEdVerfuegbarkeit_AfterFill);
            this.qryEdVerfuegbarkeit.PositionChanged += new System.EventHandler(this.qryEdVerfuegbarkeit_PositionChanged);
            this.qryEdVerfuegbarkeit.PositionChanging += new System.EventHandler(this.qryEdVerfuegbarkeit_PositionChanging);
            //
            // grvEdVerfuegbarkeit
            //
            this.grvEdVerfuegbarkeit.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvEdVerfuegbarkeit.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEdVerfuegbarkeit.Appearance.Empty.Options.UseBackColor = true;
            this.grvEdVerfuegbarkeit.Appearance.Empty.Options.UseFont = true;
            this.grvEdVerfuegbarkeit.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEdVerfuegbarkeit.Appearance.EvenRow.Options.UseFont = true;
            this.grvEdVerfuegbarkeit.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvEdVerfuegbarkeit.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEdVerfuegbarkeit.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvEdVerfuegbarkeit.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvEdVerfuegbarkeit.Appearance.FocusedCell.Options.UseFont = true;
            this.grvEdVerfuegbarkeit.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvEdVerfuegbarkeit.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvEdVerfuegbarkeit.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEdVerfuegbarkeit.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvEdVerfuegbarkeit.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvEdVerfuegbarkeit.Appearance.FocusedRow.Options.UseFont = true;
            this.grvEdVerfuegbarkeit.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvEdVerfuegbarkeit.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvEdVerfuegbarkeit.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvEdVerfuegbarkeit.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvEdVerfuegbarkeit.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvEdVerfuegbarkeit.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvEdVerfuegbarkeit.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvEdVerfuegbarkeit.Appearance.GroupRow.Options.UseFont = true;
            this.grvEdVerfuegbarkeit.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvEdVerfuegbarkeit.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvEdVerfuegbarkeit.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvEdVerfuegbarkeit.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvEdVerfuegbarkeit.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvEdVerfuegbarkeit.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvEdVerfuegbarkeit.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvEdVerfuegbarkeit.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvEdVerfuegbarkeit.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEdVerfuegbarkeit.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvEdVerfuegbarkeit.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvEdVerfuegbarkeit.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvEdVerfuegbarkeit.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvEdVerfuegbarkeit.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvEdVerfuegbarkeit.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvEdVerfuegbarkeit.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEdVerfuegbarkeit.Appearance.OddRow.Options.UseFont = true;
            this.grvEdVerfuegbarkeit.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvEdVerfuegbarkeit.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEdVerfuegbarkeit.Appearance.Row.Options.UseBackColor = true;
            this.grvEdVerfuegbarkeit.Appearance.Row.Options.UseFont = true;
            this.grvEdVerfuegbarkeit.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEdVerfuegbarkeit.Appearance.SelectedRow.Options.UseFont = true;
            this.grvEdVerfuegbarkeit.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvEdVerfuegbarkeit.Appearance.VertLine.Options.UseBackColor = true;
            this.grvEdVerfuegbarkeit.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvEdVerfuegbarkeit.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIsBwMitarbeiter,
            this.colBwAktiv,
            this.colIsEdMitarbeiter,
            this.colEdAktiv,
            this.colName,
            this.colVorname,
            this.colGeburtsdatum,
            this.colPLZ,
            this.colOrt,
            this.colBezirk,
            this.colTelefon,
            this.colEmail,
            this.colTypBW,
            this.colTypED,
            this.colEinsatzregionen,
            this.colEigenesFahrzeug,
            this.colBereitschaftMitarbeitInGruppen,
            this.colZeitNichtDefiniert,
            this.colMontagMorgen,
            this.colMontagNachmittag,
            this.colMontagAbend,
            this.colMontagNacht,
            this.colDienstagMorgen,
            this.colDienstagNachmittag,
            this.colDienstagAbend,
            this.colDienstagNacht,
            this.colMittwochMorgen,
            this.colMittwochNachmittag,
            this.colMittwochAbend,
            this.colMittwochNacht,
            this.colDonnerstagMorgen,
            this.colDonnerstagNachmittag,
            this.colDonnerstagAbend,
            this.colDonnerstagNacht,
            this.colFreitagMorgen,
            this.colFreitagNachmittag,
            this.colFreitagAbend,
            this.colFreitagNacht,
            this.colSamstagMorgen,
            this.colSamstagNachmittag,
            this.colSamstagAbend,
            this.colSamstagNacht,
            this.colSonntagMorgen,
            this.colSonntagNachmittag,
            this.colSonntagAbend,
            this.colSonntagNacht,
            this.colAnrede,
            this.colAdresse});
            this.grvEdVerfuegbarkeit.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvEdVerfuegbarkeit.GridControl = this.grdEdVerfuegbarkeit;
            this.grvEdVerfuegbarkeit.Name = "grvEdVerfuegbarkeit";
            this.grvEdVerfuegbarkeit.OptionsBehavior.Editable = false;
            this.grvEdVerfuegbarkeit.OptionsCustomization.AllowFilter = false;
            this.grvEdVerfuegbarkeit.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvEdVerfuegbarkeit.OptionsNavigation.AutoFocusNewRow = true;
            this.grvEdVerfuegbarkeit.OptionsNavigation.UseTabKey = false;
            this.grvEdVerfuegbarkeit.OptionsView.ColumnAutoWidth = false;
            this.grvEdVerfuegbarkeit.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvEdVerfuegbarkeit.OptionsView.ShowGroupPanel = false;
            this.grvEdVerfuegbarkeit.OptionsView.ShowIndicator = false;
            //
            // colIsBwMitarbeiter
            //
            this.colIsBwMitarbeiter.Caption = "BW";
            this.colIsBwMitarbeiter.FieldName = "IsBWMitarbeiter";
            this.colIsBwMitarbeiter.Name = "colIsBwMitarbeiter";
            this.colIsBwMitarbeiter.Visible = true;
            this.colIsBwMitarbeiter.VisibleIndex = 0;
            this.colIsBwMitarbeiter.Width = 29;
            //
            // colBwAktiv
            //
            this.colBwAktiv.Caption = "Aktiv BW";
            this.colBwAktiv.FieldName = "BWAktiv";
            this.colBwAktiv.Name = "colBwAktiv";
            this.colBwAktiv.Visible = true;
            this.colBwAktiv.VisibleIndex = 1;
            this.colBwAktiv.Width = 60;
            //
            // colIsEdMitarbeiter
            //
            this.colIsEdMitarbeiter.Caption = "ED";
            this.colIsEdMitarbeiter.FieldName = "IsEDMitarbeiter";
            this.colIsEdMitarbeiter.Name = "colIsEdMitarbeiter";
            this.colIsEdMitarbeiter.Visible = true;
            this.colIsEdMitarbeiter.VisibleIndex = 2;
            this.colIsEdMitarbeiter.Width = 25;
            //
            // colEdAktiv
            //
            this.colEdAktiv.Caption = "Aktiv ED";
            this.colEdAktiv.FieldName = "EDAktiv";
            this.colEdAktiv.Name = "colEdAktiv";
            this.colEdAktiv.Visible = true;
            this.colEdAktiv.VisibleIndex = 3;
            this.colEdAktiv.Width = 56;
            //
            // colName
            //
            this.colName.Caption = "Name";
            this.colName.FieldName = "LastName";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 4;
            this.colName.Width = 146;
            //
            // colVorname
            //
            this.colVorname.Caption = "Vorname";
            this.colVorname.FieldName = "FirstName";
            this.colVorname.Name = "colVorname";
            this.colVorname.Visible = true;
            this.colVorname.VisibleIndex = 5;
            this.colVorname.Width = 150;
            //
            // colGeburtsdatum
            //
            this.colGeburtsdatum.Caption = "Geb.Datum";
            this.colGeburtsdatum.FieldName = "GebDatum";
            this.colGeburtsdatum.Name = "colGeburtsdatum";
            this.colGeburtsdatum.Visible = true;
            this.colGeburtsdatum.VisibleIndex = 6;
            //
            // colPLZ
            //
            this.colPLZ.Caption = "PLZ";
            this.colPLZ.FieldName = "PLZ";
            this.colPLZ.Name = "colPLZ";
            this.colPLZ.Visible = true;
            this.colPLZ.VisibleIndex = 8;
            this.colPLZ.Width = 63;
            //
            // colOrt
            //
            this.colOrt.Caption = "Ort";
            this.colOrt.FieldName = "Ort";
            this.colOrt.Name = "colOrt";
            this.colOrt.Visible = true;
            this.colOrt.VisibleIndex = 9;
            this.colOrt.Width = 130;
            //
            // colBezirk
            //
            this.colBezirk.Caption = "Bezirk";
            this.colBezirk.FieldName = "Bezirk";
            this.colBezirk.Name = "colBezirk";
            this.colBezirk.Visible = true;
            this.colBezirk.VisibleIndex = 10;
            this.colBezirk.Width = 117;
            //
            // colTelefon
            //
            this.colTelefon.Caption = "Telefon";
            this.colTelefon.FieldName = "Telefon";
            this.colTelefon.Name = "colTelefon";
            this.colTelefon.Visible = true;
            this.colTelefon.VisibleIndex = 11;
            this.colTelefon.Width = 109;
            //
            // colEmail
            //
            this.colEmail.Caption = "E-Mail";
            this.colEmail.FieldName = "EMail";
            this.colEmail.Name = "colEmail";
            this.colEmail.Visible = true;
            this.colEmail.VisibleIndex = 12;
            this.colEmail.Width = 129;
            //
            // colTypBW
            //
            this.colTypBW.Caption = "Typ BW";
            this.colTypBW.FieldName = "TypBW";
            this.colTypBW.Name = "colTypBW";
            this.colTypBW.Visible = true;
            this.colTypBW.VisibleIndex = 13;
            //
            // colTypED
            //
            this.colTypED.Caption = "Typ ED";
            this.colTypED.FieldName = "TypED";
            this.colTypED.Name = "colTypED";
            this.colTypED.Visible = true;
            this.colTypED.VisibleIndex = 14;
            //
            // colEinsatzregionen
            //
            this.colEinsatzregionen.Caption = "Einsatzregionen";
            this.colEinsatzregionen.FieldName = "Einsatzregion";
            this.colEinsatzregionen.Name = "colEinsatzregionen";
            this.colEinsatzregionen.Visible = true;
            this.colEinsatzregionen.VisibleIndex = 15;
            //
            // colEigenesFahrzeug
            //
            this.colEigenesFahrzeug.Caption = "Eigenes Fahrzeug";
            this.colEigenesFahrzeug.FieldName = "GrundangabenEigenesFahrzeug";
            this.colEigenesFahrzeug.Name = "colEigenesFahrzeug";
            this.colEigenesFahrzeug.Visible = true;
            this.colEigenesFahrzeug.VisibleIndex = 16;
            //
            // colBereitschaftMitarbeitInGruppen
            //
            this.colBereitschaftMitarbeitInGruppen.Caption = "Gruppen";
            this.colBereitschaftMitarbeitInGruppen.FieldName = "GrundangabenMitarbeitInGruppen";
            this.colBereitschaftMitarbeitInGruppen.Name = "colBereitschaftMitarbeitInGruppen";
            this.colBereitschaftMitarbeitInGruppen.Visible = true;
            this.colBereitschaftMitarbeitInGruppen.VisibleIndex = 17;
            //
            // colZeitNichtDefiniert
            //
            this.colZeitNichtDefiniert.Caption = "nichrt definiert";
            this.colZeitNichtDefiniert.FieldName = "GrundangabenKeineEinsatzzeitDefiniert";
            this.colZeitNichtDefiniert.Name = "colZeitNichtDefiniert";
            this.colZeitNichtDefiniert.Visible = true;
            this.colZeitNichtDefiniert.VisibleIndex = 18;
            //
            // colMontagMorgen
            //
            this.colMontagMorgen.Caption = "Mo. Morgen";
            this.colMontagMorgen.FieldName = "MoMorgen";
            this.colMontagMorgen.Name = "colMontagMorgen";
            this.colMontagMorgen.Visible = true;
            this.colMontagMorgen.VisibleIndex = 19;
            //
            // colMontagNachmittag
            //
            this.colMontagNachmittag.Caption = "Mo. Nachm.";
            this.colMontagNachmittag.FieldName = "MoNachmittag";
            this.colMontagNachmittag.Name = "colMontagNachmittag";
            this.colMontagNachmittag.Visible = true;
            this.colMontagNachmittag.VisibleIndex = 20;
            //
            // colMontagAbend
            //
            this.colMontagAbend.Caption = "Mo. Abend";
            this.colMontagAbend.FieldName = "MoAbend";
            this.colMontagAbend.Name = "colMontagAbend";
            this.colMontagAbend.Visible = true;
            this.colMontagAbend.VisibleIndex = 21;
            //
            // colMontagNacht
            //
            this.colMontagNacht.Caption = "Mo. Nacht";
            this.colMontagNacht.FieldName = "MoNacht";
            this.colMontagNacht.Name = "colMontagNacht";
            this.colMontagNacht.Visible = true;
            this.colMontagNacht.VisibleIndex = 22;
            //
            // colDienstagMorgen
            //
            this.colDienstagMorgen.Caption = "Di. Morgen";
            this.colDienstagMorgen.FieldName = "DiMorgen";
            this.colDienstagMorgen.Name = "colDienstagMorgen";
            this.colDienstagMorgen.Visible = true;
            this.colDienstagMorgen.VisibleIndex = 23;
            //
            // colDienstagNachmittag
            //
            this.colDienstagNachmittag.Caption = "Di. Nachm.";
            this.colDienstagNachmittag.FieldName = "DiNachmittag";
            this.colDienstagNachmittag.Name = "colDienstagNachmittag";
            this.colDienstagNachmittag.Visible = true;
            this.colDienstagNachmittag.VisibleIndex = 24;
            //
            // colDienstagAbend
            //
            this.colDienstagAbend.Caption = "Di. Abend";
            this.colDienstagAbend.FieldName = "DiAbend";
            this.colDienstagAbend.Name = "colDienstagAbend";
            this.colDienstagAbend.Visible = true;
            this.colDienstagAbend.VisibleIndex = 25;
            //
            // colDienstagNacht
            //
            this.colDienstagNacht.Caption = "Di. Nacht";
            this.colDienstagNacht.FieldName = "DiNacht";
            this.colDienstagNacht.Name = "colDienstagNacht";
            this.colDienstagNacht.Visible = true;
            this.colDienstagNacht.VisibleIndex = 26;
            //
            // colMittwochMorgen
            //
            this.colMittwochMorgen.Caption = "Mi. Morgen";
            this.colMittwochMorgen.FieldName = "MiMorgen";
            this.colMittwochMorgen.Name = "colMittwochMorgen";
            this.colMittwochMorgen.Visible = true;
            this.colMittwochMorgen.VisibleIndex = 27;
            //
            // colMittwochNachmittag
            //
            this.colMittwochNachmittag.Caption = "Mi. Nachm.";
            this.colMittwochNachmittag.FieldName = "MiNachmittag";
            this.colMittwochNachmittag.Name = "colMittwochNachmittag";
            this.colMittwochNachmittag.Visible = true;
            this.colMittwochNachmittag.VisibleIndex = 28;
            //
            // colMittwochAbend
            //
            this.colMittwochAbend.Caption = "Mi. Abend";
            this.colMittwochAbend.FieldName = "MiAbend";
            this.colMittwochAbend.Name = "colMittwochAbend";
            this.colMittwochAbend.Visible = true;
            this.colMittwochAbend.VisibleIndex = 29;
            //
            // colMittwochNacht
            //
            this.colMittwochNacht.Caption = "Mi. Nacht";
            this.colMittwochNacht.FieldName = "MiNacht";
            this.colMittwochNacht.Name = "colMittwochNacht";
            this.colMittwochNacht.Visible = true;
            this.colMittwochNacht.VisibleIndex = 30;
            //
            // colDonnerstagMorgen
            //
            this.colDonnerstagMorgen.Caption = "Do. Morgen";
            this.colDonnerstagMorgen.FieldName = "DoMorgen";
            this.colDonnerstagMorgen.Name = "colDonnerstagMorgen";
            this.colDonnerstagMorgen.Visible = true;
            this.colDonnerstagMorgen.VisibleIndex = 31;
            //
            // colDonnerstagNachmittag
            //
            this.colDonnerstagNachmittag.Caption = "Do. Nachm,";
            this.colDonnerstagNachmittag.FieldName = "DoNachmittag";
            this.colDonnerstagNachmittag.Name = "colDonnerstagNachmittag";
            this.colDonnerstagNachmittag.Visible = true;
            this.colDonnerstagNachmittag.VisibleIndex = 32;
            //
            // colDonnerstagAbend
            //
            this.colDonnerstagAbend.Caption = "Do. Abend";
            this.colDonnerstagAbend.FieldName = "DoAbend";
            this.colDonnerstagAbend.Name = "colDonnerstagAbend";
            this.colDonnerstagAbend.Visible = true;
            this.colDonnerstagAbend.VisibleIndex = 33;
            //
            // colDonnerstagNacht
            //
            this.colDonnerstagNacht.Caption = "Do. Nacht";
            this.colDonnerstagNacht.FieldName = "DoNacht";
            this.colDonnerstagNacht.Name = "colDonnerstagNacht";
            this.colDonnerstagNacht.Visible = true;
            this.colDonnerstagNacht.VisibleIndex = 34;
            //
            // colFreitagMorgen
            //
            this.colFreitagMorgen.Caption = "Fr. Morgen";
            this.colFreitagMorgen.FieldName = "FrMorgen";
            this.colFreitagMorgen.Name = "colFreitagMorgen";
            this.colFreitagMorgen.Visible = true;
            this.colFreitagMorgen.VisibleIndex = 35;
            //
            // colFreitagNachmittag
            //
            this.colFreitagNachmittag.Caption = "Fr. Nachm.";
            this.colFreitagNachmittag.FieldName = "FrNachmittag";
            this.colFreitagNachmittag.Name = "colFreitagNachmittag";
            this.colFreitagNachmittag.Visible = true;
            this.colFreitagNachmittag.VisibleIndex = 36;
            //
            // colFreitagAbend
            //
            this.colFreitagAbend.Caption = "Do. Abend";
            this.colFreitagAbend.FieldName = "FrAbend";
            this.colFreitagAbend.Name = "colFreitagAbend";
            this.colFreitagAbend.Visible = true;
            this.colFreitagAbend.VisibleIndex = 37;
            //
            // colFreitagNacht
            //
            this.colFreitagNacht.Caption = "Fr. Nacht";
            this.colFreitagNacht.FieldName = "FrNacht";
            this.colFreitagNacht.Name = "colFreitagNacht";
            this.colFreitagNacht.Visible = true;
            this.colFreitagNacht.VisibleIndex = 38;
            //
            // colSamstagMorgen
            //
            this.colSamstagMorgen.Caption = "Sa. Morgen";
            this.colSamstagMorgen.FieldName = "SaMorgen";
            this.colSamstagMorgen.Name = "colSamstagMorgen";
            this.colSamstagMorgen.Visible = true;
            this.colSamstagMorgen.VisibleIndex = 39;
            //
            // colSamstagNachmittag
            //
            this.colSamstagNachmittag.Caption = "Sa. Nachm.";
            this.colSamstagNachmittag.FieldName = "SaNachmittag";
            this.colSamstagNachmittag.Name = "colSamstagNachmittag";
            this.colSamstagNachmittag.Visible = true;
            this.colSamstagNachmittag.VisibleIndex = 40;
            //
            // colSamstagAbend
            //
            this.colSamstagAbend.Caption = "Sa. Abend";
            this.colSamstagAbend.FieldName = "SaAbend";
            this.colSamstagAbend.Name = "colSamstagAbend";
            this.colSamstagAbend.Visible = true;
            this.colSamstagAbend.VisibleIndex = 41;
            //
            // colSamstagNacht
            //
            this.colSamstagNacht.Caption = "Sa. Nacht";
            this.colSamstagNacht.FieldName = "SaNacht";
            this.colSamstagNacht.Name = "colSamstagNacht";
            this.colSamstagNacht.Visible = true;
            this.colSamstagNacht.VisibleIndex = 42;
            //
            // colSonntagMorgen
            //
            this.colSonntagMorgen.Caption = "So. Morgen";
            this.colSonntagMorgen.FieldName = "SoMorgen";
            this.colSonntagMorgen.Name = "colSonntagMorgen";
            this.colSonntagMorgen.Visible = true;
            this.colSonntagMorgen.VisibleIndex = 43;
            //
            // colSonntagNachmittag
            //
            this.colSonntagNachmittag.Caption = "So. Nachm.";
            this.colSonntagNachmittag.FieldName = "SoNachmittag";
            this.colSonntagNachmittag.Name = "colSonntagNachmittag";
            this.colSonntagNachmittag.Visible = true;
            this.colSonntagNachmittag.VisibleIndex = 44;
            //
            // colSonntagAbend
            //
            this.colSonntagAbend.Caption = "So. Abend";
            this.colSonntagAbend.FieldName = "SoAbend";
            this.colSonntagAbend.Name = "colSonntagAbend";
            this.colSonntagAbend.Visible = true;
            this.colSonntagAbend.VisibleIndex = 45;
            //
            // colSonntagNacht
            //
            this.colSonntagNacht.Caption = "So. Nacht";
            this.colSonntagNacht.FieldName = "SoNacht";
            this.colSonntagNacht.Name = "colSonntagNacht";
            this.colSonntagNacht.Visible = true;
            this.colSonntagNacht.VisibleIndex = 46;
            //
            // colAnrede
            //
            this.colAnrede.Caption = "Anrede";
            this.colAnrede.FieldName = "Anrede";
            this.colAnrede.Name = "colAnrede";
            this.colAnrede.Visible = true;
            this.colAnrede.VisibleIndex = 47;
            //
            // colAdresse
            //
            this.colAdresse.Caption = "Adresse";
            this.colAdresse.FieldName = "Adresse";
            this.colAdresse.Name = "colAdresse";
            this.colAdresse.Visible = true;
            this.colAdresse.VisibleIndex = 7;
            this.colAdresse.Width = 133;
            //
            // lblSucheName
            //
            this.lblSucheName.Location = new System.Drawing.Point(30, 40);
            this.lblSucheName.Name = "lblSucheName";
            this.lblSucheName.Size = new System.Drawing.Size(95, 24);
            this.lblSucheName.TabIndex = 1;
            this.lblSucheName.Text = "Name";
            this.lblSucheName.UseCompatibleTextRendering = true;
            //
            // edtSucheName
            //
            this.edtSucheName.Location = new System.Drawing.Point(131, 41);
            this.edtSucheName.Name = "edtSucheName";
            this.edtSucheName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheName.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheName.Properties.Appearance.Options.UseFont = true;
            this.edtSucheName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheName.Properties.Name = "editNameX.Properties";
            this.edtSucheName.Size = new System.Drawing.Size(223, 24);
            this.edtSucheName.TabIndex = 2;
            //
            // lblSucheTypED
            //
            this.lblSucheTypED.Location = new System.Drawing.Point(400, 70);
            this.lblSucheTypED.Name = "lblSucheTypED";
            this.lblSucheTypED.Size = new System.Drawing.Size(95, 24);
            this.lblSucheTypED.TabIndex = 11;
            this.lblSucheTypED.Text = "Typ ED";
            this.lblSucheTypED.UseCompatibleTextRendering = true;
            //
            // edtSucheTypED
            //
            this.edtSucheTypED.Location = new System.Drawing.Point(501, 70);
            this.edtSucheTypED.LOVName = "EdTyp";
            this.edtSucheTypED.Name = "edtSucheTypED";
            this.edtSucheTypED.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheTypED.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheTypED.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheTypED.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheTypED.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheTypED.Properties.Appearance.Options.UseFont = true;
            this.edtSucheTypED.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheTypED.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheTypED.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheTypED.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheTypED.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtSucheTypED.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtSucheTypED.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheTypED.Properties.NullText = "";
            this.edtSucheTypED.Properties.ShowFooter = false;
            this.edtSucheTypED.Properties.ShowHeader = false;
            this.edtSucheTypED.Size = new System.Drawing.Size(223, 24);
            this.edtSucheTypED.TabIndex = 12;
            //
            // lblSucheOrt
            //
            this.lblSucheOrt.Location = new System.Drawing.Point(30, 71);
            this.lblSucheOrt.Name = "lblSucheOrt";
            this.lblSucheOrt.Size = new System.Drawing.Size(95, 24);
            this.lblSucheOrt.TabIndex = 3;
            this.lblSucheOrt.Text = "Ort";
            this.lblSucheOrt.UseCompatibleTextRendering = true;
            //
            // edtSucheOrt
            //
            this.edtSucheOrt.Location = new System.Drawing.Point(131, 71);
            this.edtSucheOrt.Name = "edtSucheOrt";
            this.edtSucheOrt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheOrt.Properties.Appearance.Options.UseFont = true;
            this.edtSucheOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheOrt.Properties.Name = "editOrtX.Properties";
            this.edtSucheOrt.Size = new System.Drawing.Size(223, 24);
            this.edtSucheOrt.TabIndex = 4;
            //
            // lblSucheEinsatzregion
            //
            this.lblSucheEinsatzregion.Location = new System.Drawing.Point(30, 101);
            this.lblSucheEinsatzregion.Name = "lblSucheEinsatzregion";
            this.lblSucheEinsatzregion.Size = new System.Drawing.Size(95, 24);
            this.lblSucheEinsatzregion.TabIndex = 5;
            this.lblSucheEinsatzregion.Text = "Einsatzregion";
            this.lblSucheEinsatzregion.UseCompatibleTextRendering = true;
            //
            // edtSucheEinsatzregion
            //
            this.edtSucheEinsatzregion.Location = new System.Drawing.Point(131, 101);
            this.edtSucheEinsatzregion.Name = "edtSucheEinsatzregion";
            this.edtSucheEinsatzregion.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheEinsatzregion.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheEinsatzregion.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheEinsatzregion.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheEinsatzregion.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheEinsatzregion.Properties.Appearance.Options.UseFont = true;
            this.edtSucheEinsatzregion.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheEinsatzregion.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheEinsatzregion.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheEinsatzregion.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheEinsatzregion.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtSucheEinsatzregion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtSucheEinsatzregion.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheEinsatzregion.Properties.DisplayMember = "Text";
            this.edtSucheEinsatzregion.Properties.NullText = "";
            this.edtSucheEinsatzregion.Properties.ShowFooter = false;
            this.edtSucheEinsatzregion.Properties.ShowHeader = false;
            this.edtSucheEinsatzregion.Properties.ValueMember = "Code";
            this.edtSucheEinsatzregion.Size = new System.Drawing.Size(223, 24);
            this.edtSucheEinsatzregion.TabIndex = 6;
            //
            // chkSucheEigenesFahrzeug
            //
            this.chkSucheEigenesFahrzeug.EditValue = false;
            this.chkSucheEigenesFahrzeug.Location = new System.Drawing.Point(501, 125);
            this.chkSucheEigenesFahrzeug.Name = "chkSucheEigenesFahrzeug";
            this.chkSucheEigenesFahrzeug.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkSucheEigenesFahrzeug.Properties.Appearance.Options.UseBackColor = true;
            this.chkSucheEigenesFahrzeug.Properties.Caption = "Eigenes Fahrzeug";
            this.chkSucheEigenesFahrzeug.Size = new System.Drawing.Size(223, 19);
            this.chkSucheEigenesFahrzeug.TabIndex = 14;
            //
            // chkSucheNurAktive
            //
            this.chkSucheNurAktive.EditValue = true;
            this.chkSucheNurAktive.Location = new System.Drawing.Point(501, 100);
            this.chkSucheNurAktive.Name = "chkSucheNurAktive";
            this.chkSucheNurAktive.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkSucheNurAktive.Properties.Appearance.Options.UseBackColor = true;
            this.chkSucheNurAktive.Properties.Caption = "Nur Aktive";
            this.chkSucheNurAktive.Size = new System.Drawing.Size(223, 19);
            this.chkSucheNurAktive.TabIndex = 13;
            //
            // tabVerfuegbarkeit
            //
            this.tabVerfuegbarkeit.Controls.Add(this.tpgGrundangaben);
            this.tabVerfuegbarkeit.Controls.Add(this.tpgEinsatzorte);
            this.tabVerfuegbarkeit.Controls.Add(this.tpgArbeitswoche);
            this.tabVerfuegbarkeit.Controls.Add(this.tpgWochenende);
            this.tabVerfuegbarkeit.Controls.Add(this.tpgEinsatzplanung);
            this.tabVerfuegbarkeit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabVerfuegbarkeit.Location = new System.Drawing.Point(0, 264);
            this.tabVerfuegbarkeit.Name = "tabVerfuegbarkeit";
            this.tabVerfuegbarkeit.ShowFixedWidthTooltip = true;
            this.tabVerfuegbarkeit.Size = new System.Drawing.Size(800, 310);
            this.tabVerfuegbarkeit.TabIndex = 1;
            this.tabVerfuegbarkeit.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgGrundangaben,
            this.tpgEinsatzorte,
            this.tpgArbeitswoche,
            this.tpgWochenende,
            this.tpgEinsatzplanung});
            this.tabVerfuegbarkeit.TabsLineColor = System.Drawing.Color.Black;
            this.tabVerfuegbarkeit.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            //
            // tpgGrundangaben
            //
            this.tpgGrundangaben.Controls.Add(this.lblGrundangabenTypBW);
            this.tpgGrundangaben.Controls.Add(this.edtGrundangabenTypBW);
            this.tpgGrundangaben.Controls.Add(this.edtGrundangabenBemerkungen);
            this.tpgGrundangaben.Controls.Add(this.lblGrundangabenBemerkungen);
            this.tpgGrundangaben.Controls.Add(this.chkGrundangabenGruppen);
            this.tpgGrundangaben.Controls.Add(this.lblGrundangabenGruppen);
            this.tpgGrundangaben.Controls.Add(this.chkGrundangabenKeineFrequenz);
            this.tpgGrundangaben.Controls.Add(this.edtGrundangabenFrequenz);
            this.tpgGrundangaben.Controls.Add(this.lblGrundangabenFrequenz);
            this.tpgGrundangaben.Controls.Add(this.edtGrundangabenTypED);
            this.tpgGrundangaben.Controls.Add(this.lblGrundangabenTypED);
            this.tpgGrundangaben.Controls.Add(this.edtGrundangabenMobilitaetBemerkungen);
            this.tpgGrundangaben.Controls.Add(this.chkGrundangabenMobilitaetEigenesFahrzeug);
            this.tpgGrundangaben.Controls.Add(this.chkGrundangabenMobilitaetFahrausweis);
            this.tpgGrundangaben.Controls.Add(this.lblGrundangabenMobilitaet);
            this.tpgGrundangaben.Controls.Add(this.edtGrundangabenTelefon);
            this.tpgGrundangaben.Controls.Add(this.lblGrundangabenTelefon);
            this.tpgGrundangaben.Controls.Add(this.edtGrundangabenMitarbeiter);
            this.tpgGrundangaben.Controls.Add(this.lblGrundangabenMitarbeiter);
            this.tpgGrundangaben.Location = new System.Drawing.Point(6, 6);
            this.tpgGrundangaben.Name = "tpgGrundangaben";
            this.tpgGrundangaben.Size = new System.Drawing.Size(788, 272);
            this.tpgGrundangaben.TabIndex = 0;
            this.tpgGrundangaben.Title = "Grundangaben";
            //
            // lblGrundangabenTypBW
            //
            this.lblGrundangabenTypBW.Location = new System.Drawing.Point(9, 99);
            this.lblGrundangabenTypBW.Name = "lblGrundangabenTypBW";
            this.lblGrundangabenTypBW.Size = new System.Drawing.Size(100, 24);
            this.lblGrundangabenTypBW.TabIndex = 8;
            this.lblGrundangabenTypBW.Text = "Typ BW";
            //
            // edtGrundangabenTypBW
            //
            this.edtGrundangabenTypBW.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtGrundangabenTypBW.DataMember = "TypBW";
            this.edtGrundangabenTypBW.DataSource = this.qryEdVerfuegbarkeit;
            this.edtGrundangabenTypBW.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGrundangabenTypBW.Location = new System.Drawing.Point(115, 99);
            this.edtGrundangabenTypBW.Name = "edtGrundangabenTypBW";
            this.edtGrundangabenTypBW.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGrundangabenTypBW.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrundangabenTypBW.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrundangabenTypBW.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrundangabenTypBW.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrundangabenTypBW.Properties.Appearance.Options.UseFont = true;
            this.edtGrundangabenTypBW.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGrundangabenTypBW.Properties.ReadOnly = true;
            this.edtGrundangabenTypBW.Size = new System.Drawing.Size(664, 24);
            this.edtGrundangabenTypBW.TabIndex = 9;
            //
            // edtGrundangabenBemerkungen
            //
            this.edtGrundangabenBemerkungen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtGrundangabenBemerkungen.DataMember = "GrundangabenBemerkungen";
            this.edtGrundangabenBemerkungen.DataSource = this.qryEdVerfuegbarkeit;
            this.edtGrundangabenBemerkungen.Location = new System.Drawing.Point(115, 213);
            this.edtGrundangabenBemerkungen.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.edtGrundangabenBemerkungen.Name = "edtGrundangabenBemerkungen";
            this.edtGrundangabenBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGrundangabenBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrundangabenBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrundangabenBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrundangabenBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrundangabenBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.edtGrundangabenBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGrundangabenBemerkungen.Size = new System.Drawing.Size(664, 51);
            this.edtGrundangabenBemerkungen.TabIndex = 18;
            //
            // lblGrundangabenBemerkungen
            //
            this.lblGrundangabenBemerkungen.Location = new System.Drawing.Point(9, 213);
            this.lblGrundangabenBemerkungen.Name = "lblGrundangabenBemerkungen";
            this.lblGrundangabenBemerkungen.Size = new System.Drawing.Size(100, 23);
            this.lblGrundangabenBemerkungen.TabIndex = 17;
            this.lblGrundangabenBemerkungen.Text = "Bemerkungen";
            this.lblGrundangabenBemerkungen.UseCompatibleTextRendering = true;
            //
            // chkGrundangabenGruppen
            //
            this.chkGrundangabenGruppen.DataMember = "GrundangabenMitarbeitInGruppen";
            this.chkGrundangabenGruppen.DataSource = this.qryEdVerfuegbarkeit;
            this.chkGrundangabenGruppen.Location = new System.Drawing.Point(115, 188);
            this.chkGrundangabenGruppen.Name = "chkGrundangabenGruppen";
            this.chkGrundangabenGruppen.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkGrundangabenGruppen.Properties.Appearance.Options.UseBackColor = true;
            this.chkGrundangabenGruppen.Properties.Caption = "Bereitschaft zur Mithilfe in Gruppen";
            this.chkGrundangabenGruppen.Size = new System.Drawing.Size(404, 19);
            this.chkGrundangabenGruppen.TabIndex = 16;
            //
            // lblGrundangabenGruppen
            //
            this.lblGrundangabenGruppen.Location = new System.Drawing.Point(9, 186);
            this.lblGrundangabenGruppen.Name = "lblGrundangabenGruppen";
            this.lblGrundangabenGruppen.Size = new System.Drawing.Size(100, 23);
            this.lblGrundangabenGruppen.TabIndex = 15;
            this.lblGrundangabenGruppen.Text = "Gruppen";
            this.lblGrundangabenGruppen.UseCompatibleTextRendering = true;
            //
            // chkGrundangabenKeineFrequenz
            //
            this.chkGrundangabenKeineFrequenz.DataMember = "GrundangabenKeineEinsatzzeitDefiniert";
            this.chkGrundangabenKeineFrequenz.DataSource = this.qryEdVerfuegbarkeit;
            this.chkGrundangabenKeineFrequenz.Location = new System.Drawing.Point(574, 162);
            this.chkGrundangabenKeineFrequenz.Name = "chkGrundangabenKeineFrequenz";
            this.chkGrundangabenKeineFrequenz.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkGrundangabenKeineFrequenz.Properties.Appearance.Options.UseBackColor = true;
            this.chkGrundangabenKeineFrequenz.Properties.Caption = "Keine Einsatzzeiten definiert";
            this.chkGrundangabenKeineFrequenz.Size = new System.Drawing.Size(188, 19);
            this.chkGrundangabenKeineFrequenz.TabIndex = 14;
            this.chkGrundangabenKeineFrequenz.CheckedChanged += new System.EventHandler(this.chkGrundangabenKeineFrequenz_CheckedChanged);
            //
            // edtGrundangabenFrequenz
            //
            this.edtGrundangabenFrequenz.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.edtGrundangabenFrequenz.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrundangabenFrequenz.Appearance.Options.UseBackColor = true;
            this.edtGrundangabenFrequenz.Appearance.Options.UseBorderColor = true;
            this.edtGrundangabenFrequenz.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtGrundangabenFrequenz.CheckOnClick = true;
            this.edtGrundangabenFrequenz.DataMember = "GrundangabenFrequenzCodes";
            this.edtGrundangabenFrequenz.DataSource = this.qryEdVerfuegbarkeit;
            this.edtGrundangabenFrequenz.Location = new System.Drawing.Point(115, 162);
            this.edtGrundangabenFrequenz.LOVName = "EDFrequenz";
            this.edtGrundangabenFrequenz.MultiColumn = true;
            this.edtGrundangabenFrequenz.Name = "edtGrundangabenFrequenz";
            this.edtGrundangabenFrequenz.Size = new System.Drawing.Size(424, 20);
            this.edtGrundangabenFrequenz.TabIndex = 13;
            //
            // lblGrundangabenFrequenz
            //
            this.lblGrundangabenFrequenz.Location = new System.Drawing.Point(9, 159);
            this.lblGrundangabenFrequenz.Name = "lblGrundangabenFrequenz";
            this.lblGrundangabenFrequenz.Size = new System.Drawing.Size(100, 23);
            this.lblGrundangabenFrequenz.TabIndex = 12;
            this.lblGrundangabenFrequenz.Text = "Frequenz";
            this.lblGrundangabenFrequenz.UseCompatibleTextRendering = true;
            //
            // edtGrundangabenTypED
            //
            this.edtGrundangabenTypED.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtGrundangabenTypED.DataMember = "TypED";
            this.edtGrundangabenTypED.DataSource = this.qryEdVerfuegbarkeit;
            this.edtGrundangabenTypED.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGrundangabenTypED.Location = new System.Drawing.Point(115, 129);
            this.edtGrundangabenTypED.Name = "edtGrundangabenTypED";
            this.edtGrundangabenTypED.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGrundangabenTypED.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrundangabenTypED.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrundangabenTypED.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrundangabenTypED.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrundangabenTypED.Properties.Appearance.Options.UseFont = true;
            this.edtGrundangabenTypED.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGrundangabenTypED.Properties.ReadOnly = true;
            this.edtGrundangabenTypED.Size = new System.Drawing.Size(664, 24);
            this.edtGrundangabenTypED.TabIndex = 11;
            //
            // lblGrundangabenTypED
            //
            this.lblGrundangabenTypED.Location = new System.Drawing.Point(9, 129);
            this.lblGrundangabenTypED.Name = "lblGrundangabenTypED";
            this.lblGrundangabenTypED.Size = new System.Drawing.Size(100, 23);
            this.lblGrundangabenTypED.TabIndex = 10;
            this.lblGrundangabenTypED.Text = "Typ ED";
            this.lblGrundangabenTypED.UseCompatibleTextRendering = true;
            //
            // edtGrundangabenMobilitaetBemerkungen
            //
            this.edtGrundangabenMobilitaetBemerkungen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtGrundangabenMobilitaetBemerkungen.DataMember = "GrundangabenMobilitaetBemerkungen";
            this.edtGrundangabenMobilitaetBemerkungen.DataSource = this.qryEdVerfuegbarkeit;
            this.edtGrundangabenMobilitaetBemerkungen.Location = new System.Drawing.Point(359, 69);
            this.edtGrundangabenMobilitaetBemerkungen.Name = "edtGrundangabenMobilitaetBemerkungen";
            this.edtGrundangabenMobilitaetBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGrundangabenMobilitaetBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrundangabenMobilitaetBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrundangabenMobilitaetBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrundangabenMobilitaetBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrundangabenMobilitaetBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.edtGrundangabenMobilitaetBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGrundangabenMobilitaetBemerkungen.Size = new System.Drawing.Size(420, 24);
            this.edtGrundangabenMobilitaetBemerkungen.TabIndex = 7;
            //
            // chkGrundangabenMobilitaetEigenesFahrzeug
            //
            this.chkGrundangabenMobilitaetEigenesFahrzeug.DataMember = "GrundangabenEigenesFahrzeug";
            this.chkGrundangabenMobilitaetEigenesFahrzeug.DataSource = this.qryEdVerfuegbarkeit;
            this.chkGrundangabenMobilitaetEigenesFahrzeug.Location = new System.Drawing.Point(228, 72);
            this.chkGrundangabenMobilitaetEigenesFahrzeug.Name = "chkGrundangabenMobilitaetEigenesFahrzeug";
            this.chkGrundangabenMobilitaetEigenesFahrzeug.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkGrundangabenMobilitaetEigenesFahrzeug.Properties.Appearance.Options.UseBackColor = true;
            this.chkGrundangabenMobilitaetEigenesFahrzeug.Properties.Caption = "Eigenes Fahrzeug";
            this.chkGrundangabenMobilitaetEigenesFahrzeug.Size = new System.Drawing.Size(125, 19);
            this.chkGrundangabenMobilitaetEigenesFahrzeug.TabIndex = 6;
            //
            // chkGrundangabenMobilitaetFahrausweis
            //
            this.chkGrundangabenMobilitaetFahrausweis.DataMember = "GrundangabenFahrausweis";
            this.chkGrundangabenMobilitaetFahrausweis.DataSource = this.qryEdVerfuegbarkeit;
            this.chkGrundangabenMobilitaetFahrausweis.Location = new System.Drawing.Point(115, 72);
            this.chkGrundangabenMobilitaetFahrausweis.Name = "chkGrundangabenMobilitaetFahrausweis";
            this.chkGrundangabenMobilitaetFahrausweis.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkGrundangabenMobilitaetFahrausweis.Properties.Appearance.Options.UseBackColor = true;
            this.chkGrundangabenMobilitaetFahrausweis.Properties.Caption = "Fahrausweis";
            this.chkGrundangabenMobilitaetFahrausweis.Size = new System.Drawing.Size(107, 19);
            this.chkGrundangabenMobilitaetFahrausweis.TabIndex = 5;
            //
            // lblGrundangabenMobilitaet
            //
            this.lblGrundangabenMobilitaet.Location = new System.Drawing.Point(9, 69);
            this.lblGrundangabenMobilitaet.Name = "lblGrundangabenMobilitaet";
            this.lblGrundangabenMobilitaet.Size = new System.Drawing.Size(100, 23);
            this.lblGrundangabenMobilitaet.TabIndex = 4;
            this.lblGrundangabenMobilitaet.Text = "Mobilität";
            this.lblGrundangabenMobilitaet.UseCompatibleTextRendering = true;
            //
            // edtGrundangabenTelefon
            //
            this.edtGrundangabenTelefon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtGrundangabenTelefon.DataMember = "Telefon";
            this.edtGrundangabenTelefon.DataSource = this.qryEdVerfuegbarkeit;
            this.edtGrundangabenTelefon.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGrundangabenTelefon.Location = new System.Drawing.Point(115, 39);
            this.edtGrundangabenTelefon.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.edtGrundangabenTelefon.Name = "edtGrundangabenTelefon";
            this.edtGrundangabenTelefon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGrundangabenTelefon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrundangabenTelefon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrundangabenTelefon.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrundangabenTelefon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrundangabenTelefon.Properties.Appearance.Options.UseFont = true;
            this.edtGrundangabenTelefon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGrundangabenTelefon.Properties.ReadOnly = true;
            this.edtGrundangabenTelefon.Size = new System.Drawing.Size(664, 24);
            this.edtGrundangabenTelefon.TabIndex = 3;
            //
            // lblGrundangabenTelefon
            //
            this.lblGrundangabenTelefon.Location = new System.Drawing.Point(9, 39);
            this.lblGrundangabenTelefon.Name = "lblGrundangabenTelefon";
            this.lblGrundangabenTelefon.Size = new System.Drawing.Size(100, 23);
            this.lblGrundangabenTelefon.TabIndex = 2;
            this.lblGrundangabenTelefon.Text = "Telefon";
            this.lblGrundangabenTelefon.UseCompatibleTextRendering = true;
            //
            // edtGrundangabenMitarbeiter
            //
            this.edtGrundangabenMitarbeiter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtGrundangabenMitarbeiter.DataMember = "MitarbeiterIn";
            this.edtGrundangabenMitarbeiter.DataSource = this.qryEdVerfuegbarkeit;
            this.edtGrundangabenMitarbeiter.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGrundangabenMitarbeiter.Location = new System.Drawing.Point(115, 9);
            this.edtGrundangabenMitarbeiter.Name = "edtGrundangabenMitarbeiter";
            this.edtGrundangabenMitarbeiter.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGrundangabenMitarbeiter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrundangabenMitarbeiter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrundangabenMitarbeiter.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrundangabenMitarbeiter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrundangabenMitarbeiter.Properties.Appearance.Options.UseFont = true;
            this.edtGrundangabenMitarbeiter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGrundangabenMitarbeiter.Properties.ReadOnly = true;
            this.edtGrundangabenMitarbeiter.Size = new System.Drawing.Size(664, 24);
            this.edtGrundangabenMitarbeiter.TabIndex = 1;
            //
            // lblGrundangabenMitarbeiter
            //
            this.lblGrundangabenMitarbeiter.Location = new System.Drawing.Point(9, 9);
            this.lblGrundangabenMitarbeiter.Name = "lblGrundangabenMitarbeiter";
            this.lblGrundangabenMitarbeiter.Size = new System.Drawing.Size(100, 23);
            this.lblGrundangabenMitarbeiter.TabIndex = 0;
            this.lblGrundangabenMitarbeiter.Text = "Mitarbeiter/in";
            this.lblGrundangabenMitarbeiter.UseCompatibleTextRendering = true;
            //
            // tpgEinsatzorte
            //
            this.tpgEinsatzorte.Controls.Add(this.edtEinsatzorteRegionen);
            this.tpgEinsatzorte.Controls.Add(this.lblEinsatzorteRegionen);
            this.tpgEinsatzorte.Controls.Add(this.edtEinsatzorteOrte);
            this.tpgEinsatzorte.Controls.Add(this.lblEinsatzorteOrte);
            this.tpgEinsatzorte.Location = new System.Drawing.Point(6, 6);
            this.tpgEinsatzorte.Name = "tpgEinsatzorte";
            this.tpgEinsatzorte.Size = new System.Drawing.Size(788, 272);
            this.tpgEinsatzorte.TabIndex = 1;
            this.tpgEinsatzorte.Title = "Einsatzorte";
            //
            // edtEinsatzorteRegionen
            //
            this.edtEinsatzorteRegionen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtEinsatzorteRegionen.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.edtEinsatzorteRegionen.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinsatzorteRegionen.Appearance.Options.UseBackColor = true;
            this.edtEinsatzorteRegionen.Appearance.Options.UseBorderColor = true;
            this.edtEinsatzorteRegionen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtEinsatzorteRegionen.CheckOnClick = true;
            this.edtEinsatzorteRegionen.DataMember = "EinsatzorteRegionCodes";
            this.edtEinsatzorteRegionen.DataSource = this.qryEdVerfuegbarkeit;
            this.edtEinsatzorteRegionen.Location = new System.Drawing.Point(127, 55);
            this.edtEinsatzorteRegionen.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.edtEinsatzorteRegionen.MultiColumn = true;
            this.edtEinsatzorteRegionen.Name = "edtEinsatzorteRegionen";
            this.edtEinsatzorteRegionen.Size = new System.Drawing.Size(652, 208);
            this.edtEinsatzorteRegionen.TabIndex = 3;
            //
            // lblEinsatzorteRegionen
            //
            this.lblEinsatzorteRegionen.Location = new System.Drawing.Point(9, 55);
            this.lblEinsatzorteRegionen.Name = "lblEinsatzorteRegionen";
            this.lblEinsatzorteRegionen.Size = new System.Drawing.Size(112, 24);
            this.lblEinsatzorteRegionen.TabIndex = 2;
            this.lblEinsatzorteRegionen.Text = "Einsatzregionen";
            this.lblEinsatzorteRegionen.UseCompatibleTextRendering = true;
            //
            // edtEinsatzorteOrte
            //
            this.edtEinsatzorteOrte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtEinsatzorteOrte.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.edtEinsatzorteOrte.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinsatzorteOrte.Appearance.Options.UseBackColor = true;
            this.edtEinsatzorteOrte.Appearance.Options.UseBorderColor = true;
            this.edtEinsatzorteOrte.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtEinsatzorteOrte.CheckOnClick = true;
            this.edtEinsatzorteOrte.DataMember = "EinsatzorteOrtCodes";
            this.edtEinsatzorteOrte.DataSource = this.qryEdVerfuegbarkeit;
            this.edtEinsatzorteOrte.Location = new System.Drawing.Point(127, 9);
            this.edtEinsatzorteOrte.LOVName = "EdEinsatzort";
            this.edtEinsatzorteOrte.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.edtEinsatzorteOrte.Name = "edtEinsatzorteOrte";
            this.edtEinsatzorteOrte.Size = new System.Drawing.Size(652, 40);
            this.edtEinsatzorteOrte.TabIndex = 1;
            //
            // lblEinsatzorteOrte
            //
            this.lblEinsatzorteOrte.Location = new System.Drawing.Point(9, 9);
            this.lblEinsatzorteOrte.Name = "lblEinsatzorteOrte";
            this.lblEinsatzorteOrte.Size = new System.Drawing.Size(112, 24);
            this.lblEinsatzorteOrte.TabIndex = 0;
            this.lblEinsatzorteOrte.Text = "Einsatzorte";
            this.lblEinsatzorteOrte.UseCompatibleTextRendering = true;
            //
            // tpgArbeitswoche
            //
            this.tpgArbeitswoche.Controls.Add(this.edtArbeitswocheFreitag);
            this.tpgArbeitswoche.Controls.Add(this.grpArbeitswocheFreitag);
            this.tpgArbeitswoche.Controls.Add(this.edtArbeitswocheDonnerstag);
            this.tpgArbeitswoche.Controls.Add(this.grpArbeitswocheDonnerstag);
            this.tpgArbeitswoche.Controls.Add(this.edtArbeitswocheMittwoch);
            this.tpgArbeitswoche.Controls.Add(this.grpArbeitswocheMittwoch);
            this.tpgArbeitswoche.Controls.Add(this.edtArbeitswocheDienstag);
            this.tpgArbeitswoche.Controls.Add(this.grpArbeitswocheDienstag);
            this.tpgArbeitswoche.Controls.Add(this.grpArbeitswocheMontag);
            this.tpgArbeitswoche.Controls.Add(this.edtArbeitswocheMontag);
            this.tpgArbeitswoche.Location = new System.Drawing.Point(6, 6);
            this.tpgArbeitswoche.Name = "tpgArbeitswoche";
            this.tpgArbeitswoche.Size = new System.Drawing.Size(788, 272);
            this.tpgArbeitswoche.TabIndex = 0;
            this.tpgArbeitswoche.Title = "Arbeitswoche";
            //
            // edtArbeitswocheFreitag
            //
            this.edtArbeitswocheFreitag.DataMember = "Bemerkungen";
            this.edtArbeitswocheFreitag.DataSource = this.qryFreitag;
            this.edtArbeitswocheFreitag.Location = new System.Drawing.Point(625, 110);
            this.edtArbeitswocheFreitag.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.edtArbeitswocheFreitag.Name = "edtArbeitswocheFreitag";
            this.edtArbeitswocheFreitag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtArbeitswocheFreitag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtArbeitswocheFreitag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtArbeitswocheFreitag.Properties.Appearance.Options.UseBackColor = true;
            this.edtArbeitswocheFreitag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtArbeitswocheFreitag.Properties.Appearance.Options.UseFont = true;
            this.edtArbeitswocheFreitag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtArbeitswocheFreitag.Size = new System.Drawing.Size(148, 153);
            this.edtArbeitswocheFreitag.TabIndex = 8;
            //
            // qryFreitag
            //
            this.qryFreitag.HostControl = this;
            this.qryFreitag.TableName = "EdVerfuegbarkeit_ProTag";
            this.qryFreitag.ColumnChanging += new System.Data.DataColumnChangeEventHandler(this.qryFreitag_ColumnChanging);
            //
            // grpArbeitswocheFreitag
            //
            this.grpArbeitswocheFreitag.Controls.Add(this.chkFrNacht);
            this.grpArbeitswocheFreitag.Controls.Add(this.chkFrAbend);
            this.grpArbeitswocheFreitag.Controls.Add(this.chkFrNachmittag);
            this.grpArbeitswocheFreitag.Controls.Add(this.chkFrMorgen);
            this.grpArbeitswocheFreitag.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grpArbeitswocheFreitag.Location = new System.Drawing.Point(625, 9);
            this.grpArbeitswocheFreitag.Name = "grpArbeitswocheFreitag";
            this.grpArbeitswocheFreitag.Size = new System.Drawing.Size(148, 95);
            this.grpArbeitswocheFreitag.TabIndex = 7;
            this.grpArbeitswocheFreitag.TabStop = false;
            this.grpArbeitswocheFreitag.Text = "Freitag";
            this.grpArbeitswocheFreitag.UseCompatibleTextRendering = true;
            //
            // chkFrNacht
            //
            this.chkFrNacht.DataMember = "VerfuegbarNacht";
            this.chkFrNacht.DataSource = this.qryFreitag;
            this.chkFrNacht.Location = new System.Drawing.Point(6, 68);
            this.chkFrNacht.Name = "chkFrNacht";
            this.chkFrNacht.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkFrNacht.Properties.Appearance.Options.UseBackColor = true;
            this.chkFrNacht.Properties.Caption = "Nacht";
            this.chkFrNacht.Size = new System.Drawing.Size(125, 19);
            this.chkFrNacht.TabIndex = 3;
            this.chkFrNacht.CheckedChanged += new System.EventHandler(this.WeekdayCheckedChanged);
            //
            // chkFrAbend
            //
            this.chkFrAbend.DataMember = "VerfuegbarAbend";
            this.chkFrAbend.DataSource = this.qryFreitag;
            this.chkFrAbend.Location = new System.Drawing.Point(6, 52);
            this.chkFrAbend.Name = "chkFrAbend";
            this.chkFrAbend.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkFrAbend.Properties.Appearance.Options.UseBackColor = true;
            this.chkFrAbend.Properties.Caption = "Abend";
            this.chkFrAbend.Size = new System.Drawing.Size(125, 19);
            this.chkFrAbend.TabIndex = 2;
            this.chkFrAbend.CheckedChanged += new System.EventHandler(this.WeekdayCheckedChanged);
            //
            // chkFrNachmittag
            //
            this.chkFrNachmittag.DataMember = "VerfuegbarNachmittag";
            this.chkFrNachmittag.DataSource = this.qryFreitag;
            this.chkFrNachmittag.Location = new System.Drawing.Point(6, 36);
            this.chkFrNachmittag.Name = "chkFrNachmittag";
            this.chkFrNachmittag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkFrNachmittag.Properties.Appearance.Options.UseBackColor = true;
            this.chkFrNachmittag.Properties.Caption = "Nachmittag";
            this.chkFrNachmittag.Size = new System.Drawing.Size(125, 19);
            this.chkFrNachmittag.TabIndex = 1;
            this.chkFrNachmittag.CheckedChanged += new System.EventHandler(this.WeekdayCheckedChanged);
            //
            // chkFrMorgen
            //
            this.chkFrMorgen.DataMember = "VerfuegbarMorgen";
            this.chkFrMorgen.DataSource = this.qryFreitag;
            this.chkFrMorgen.Location = new System.Drawing.Point(6, 20);
            this.chkFrMorgen.Name = "chkFrMorgen";
            this.chkFrMorgen.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkFrMorgen.Properties.Appearance.Options.UseBackColor = true;
            this.chkFrMorgen.Properties.Caption = "Morgen";
            this.chkFrMorgen.Size = new System.Drawing.Size(125, 19);
            this.chkFrMorgen.TabIndex = 0;
            this.chkFrMorgen.CheckedChanged += new System.EventHandler(this.WeekdayCheckedChanged);
            //
            // edtArbeitswocheDonnerstag
            //
            this.edtArbeitswocheDonnerstag.DataMember = "Bemerkungen";
            this.edtArbeitswocheDonnerstag.DataSource = this.qryDonnerstag;
            this.edtArbeitswocheDonnerstag.Location = new System.Drawing.Point(471, 110);
            this.edtArbeitswocheDonnerstag.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.edtArbeitswocheDonnerstag.Name = "edtArbeitswocheDonnerstag";
            this.edtArbeitswocheDonnerstag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtArbeitswocheDonnerstag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtArbeitswocheDonnerstag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtArbeitswocheDonnerstag.Properties.Appearance.Options.UseBackColor = true;
            this.edtArbeitswocheDonnerstag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtArbeitswocheDonnerstag.Properties.Appearance.Options.UseFont = true;
            this.edtArbeitswocheDonnerstag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtArbeitswocheDonnerstag.Size = new System.Drawing.Size(148, 153);
            this.edtArbeitswocheDonnerstag.TabIndex = 6;
            //
            // qryDonnerstag
            //
            this.qryDonnerstag.HostControl = this;
            this.qryDonnerstag.TableName = "EdVerfuegbarkeit_ProTag";
            this.qryDonnerstag.ColumnChanging += new System.Data.DataColumnChangeEventHandler(this.qryDonnerstag_ColumnChanging);
            //
            // grpArbeitswocheDonnerstag
            //
            this.grpArbeitswocheDonnerstag.Controls.Add(this.chkDoNacht);
            this.grpArbeitswocheDonnerstag.Controls.Add(this.chkDoAbend);
            this.grpArbeitswocheDonnerstag.Controls.Add(this.chkDoNachmittag);
            this.grpArbeitswocheDonnerstag.Controls.Add(this.chkDoMorgen);
            this.grpArbeitswocheDonnerstag.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grpArbeitswocheDonnerstag.Location = new System.Drawing.Point(471, 9);
            this.grpArbeitswocheDonnerstag.Name = "grpArbeitswocheDonnerstag";
            this.grpArbeitswocheDonnerstag.Size = new System.Drawing.Size(148, 95);
            this.grpArbeitswocheDonnerstag.TabIndex = 5;
            this.grpArbeitswocheDonnerstag.TabStop = false;
            this.grpArbeitswocheDonnerstag.Text = "Donnerstag";
            this.grpArbeitswocheDonnerstag.UseCompatibleTextRendering = true;
            //
            // chkDoNacht
            //
            this.chkDoNacht.DataMember = "VerfuegbarNacht";
            this.chkDoNacht.DataSource = this.qryDonnerstag;
            this.chkDoNacht.Location = new System.Drawing.Point(6, 68);
            this.chkDoNacht.Name = "chkDoNacht";
            this.chkDoNacht.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkDoNacht.Properties.Appearance.Options.UseBackColor = true;
            this.chkDoNacht.Properties.Caption = "Nacht";
            this.chkDoNacht.Size = new System.Drawing.Size(125, 19);
            this.chkDoNacht.TabIndex = 3;
            this.chkDoNacht.CheckedChanged += new System.EventHandler(this.WeekdayCheckedChanged);
            //
            // chkDoAbend
            //
            this.chkDoAbend.DataMember = "VerfuegbarAbend";
            this.chkDoAbend.DataSource = this.qryDonnerstag;
            this.chkDoAbend.Location = new System.Drawing.Point(6, 52);
            this.chkDoAbend.Name = "chkDoAbend";
            this.chkDoAbend.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkDoAbend.Properties.Appearance.Options.UseBackColor = true;
            this.chkDoAbend.Properties.Caption = "Abend";
            this.chkDoAbend.Size = new System.Drawing.Size(125, 19);
            this.chkDoAbend.TabIndex = 2;
            this.chkDoAbend.CheckedChanged += new System.EventHandler(this.WeekdayCheckedChanged);
            //
            // chkDoNachmittag
            //
            this.chkDoNachmittag.DataMember = "VerfuegbarNachmittag";
            this.chkDoNachmittag.DataSource = this.qryDonnerstag;
            this.chkDoNachmittag.Location = new System.Drawing.Point(6, 36);
            this.chkDoNachmittag.Name = "chkDoNachmittag";
            this.chkDoNachmittag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkDoNachmittag.Properties.Appearance.Options.UseBackColor = true;
            this.chkDoNachmittag.Properties.Caption = "Nachmittag";
            this.chkDoNachmittag.Size = new System.Drawing.Size(125, 19);
            this.chkDoNachmittag.TabIndex = 1;
            this.chkDoNachmittag.CheckedChanged += new System.EventHandler(this.WeekdayCheckedChanged);
            //
            // chkDoMorgen
            //
            this.chkDoMorgen.DataMember = "VerfuegbarMorgen";
            this.chkDoMorgen.DataSource = this.qryDonnerstag;
            this.chkDoMorgen.Location = new System.Drawing.Point(6, 20);
            this.chkDoMorgen.Name = "chkDoMorgen";
            this.chkDoMorgen.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkDoMorgen.Properties.Appearance.Options.UseBackColor = true;
            this.chkDoMorgen.Properties.Caption = "Morgen";
            this.chkDoMorgen.Size = new System.Drawing.Size(125, 19);
            this.chkDoMorgen.TabIndex = 0;
            this.chkDoMorgen.CheckedChanged += new System.EventHandler(this.WeekdayCheckedChanged);
            //
            // edtArbeitswocheMittwoch
            //
            this.edtArbeitswocheMittwoch.DataMember = "Bemerkungen";
            this.edtArbeitswocheMittwoch.DataSource = this.qryMittwoch;
            this.edtArbeitswocheMittwoch.Location = new System.Drawing.Point(317, 110);
            this.edtArbeitswocheMittwoch.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.edtArbeitswocheMittwoch.Name = "edtArbeitswocheMittwoch";
            this.edtArbeitswocheMittwoch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtArbeitswocheMittwoch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtArbeitswocheMittwoch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtArbeitswocheMittwoch.Properties.Appearance.Options.UseBackColor = true;
            this.edtArbeitswocheMittwoch.Properties.Appearance.Options.UseBorderColor = true;
            this.edtArbeitswocheMittwoch.Properties.Appearance.Options.UseFont = true;
            this.edtArbeitswocheMittwoch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtArbeitswocheMittwoch.Size = new System.Drawing.Size(148, 153);
            this.edtArbeitswocheMittwoch.TabIndex = 4;
            //
            // qryMittwoch
            //
            this.qryMittwoch.HostControl = this;
            this.qryMittwoch.TableName = "EdVerfuegbarkeit_ProTag";
            this.qryMittwoch.ColumnChanging += new System.Data.DataColumnChangeEventHandler(this.qryMittwoch_ColumnChanging);
            //
            // grpArbeitswocheMittwoch
            //
            this.grpArbeitswocheMittwoch.Controls.Add(this.chkMiNacht);
            this.grpArbeitswocheMittwoch.Controls.Add(this.chkMiAbend);
            this.grpArbeitswocheMittwoch.Controls.Add(this.chkMiNachmittag);
            this.grpArbeitswocheMittwoch.Controls.Add(this.chkMiMorgen);
            this.grpArbeitswocheMittwoch.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grpArbeitswocheMittwoch.Location = new System.Drawing.Point(317, 9);
            this.grpArbeitswocheMittwoch.Name = "grpArbeitswocheMittwoch";
            this.grpArbeitswocheMittwoch.Size = new System.Drawing.Size(148, 95);
            this.grpArbeitswocheMittwoch.TabIndex = 3;
            this.grpArbeitswocheMittwoch.TabStop = false;
            this.grpArbeitswocheMittwoch.Text = "Mittwoch";
            this.grpArbeitswocheMittwoch.UseCompatibleTextRendering = true;
            //
            // chkMiNacht
            //
            this.chkMiNacht.DataMember = "VerfuegbarNacht";
            this.chkMiNacht.DataSource = this.qryMittwoch;
            this.chkMiNacht.Location = new System.Drawing.Point(6, 68);
            this.chkMiNacht.Name = "chkMiNacht";
            this.chkMiNacht.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkMiNacht.Properties.Appearance.Options.UseBackColor = true;
            this.chkMiNacht.Properties.Caption = "Nacht";
            this.chkMiNacht.Size = new System.Drawing.Size(125, 19);
            this.chkMiNacht.TabIndex = 3;
            this.chkMiNacht.CheckedChanged += new System.EventHandler(this.WeekdayCheckedChanged);
            //
            // chkMiAbend
            //
            this.chkMiAbend.DataMember = "VerfuegbarAbend";
            this.chkMiAbend.DataSource = this.qryMittwoch;
            this.chkMiAbend.Location = new System.Drawing.Point(6, 52);
            this.chkMiAbend.Name = "chkMiAbend";
            this.chkMiAbend.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkMiAbend.Properties.Appearance.Options.UseBackColor = true;
            this.chkMiAbend.Properties.Caption = "Abend";
            this.chkMiAbend.Size = new System.Drawing.Size(125, 19);
            this.chkMiAbend.TabIndex = 2;
            this.chkMiAbend.CheckedChanged += new System.EventHandler(this.WeekdayCheckedChanged);
            //
            // chkMiNachmittag
            //
            this.chkMiNachmittag.DataMember = "VerfuegbarNachmittag";
            this.chkMiNachmittag.DataSource = this.qryMittwoch;
            this.chkMiNachmittag.Location = new System.Drawing.Point(6, 36);
            this.chkMiNachmittag.Name = "chkMiNachmittag";
            this.chkMiNachmittag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkMiNachmittag.Properties.Appearance.Options.UseBackColor = true;
            this.chkMiNachmittag.Properties.Caption = "Nachmittag";
            this.chkMiNachmittag.Size = new System.Drawing.Size(125, 19);
            this.chkMiNachmittag.TabIndex = 1;
            this.chkMiNachmittag.CheckedChanged += new System.EventHandler(this.WeekdayCheckedChanged);
            //
            // chkMiMorgen
            //
            this.chkMiMorgen.DataMember = "VerfuegbarMorgen";
            this.chkMiMorgen.DataSource = this.qryMittwoch;
            this.chkMiMorgen.Location = new System.Drawing.Point(6, 20);
            this.chkMiMorgen.Name = "chkMiMorgen";
            this.chkMiMorgen.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkMiMorgen.Properties.Appearance.Options.UseBackColor = true;
            this.chkMiMorgen.Properties.Caption = "Morgen";
            this.chkMiMorgen.Size = new System.Drawing.Size(125, 19);
            this.chkMiMorgen.TabIndex = 0;
            this.chkMiMorgen.CheckedChanged += new System.EventHandler(this.WeekdayCheckedChanged);
            //
            // edtArbeitswocheDienstag
            //
            this.edtArbeitswocheDienstag.DataMember = "Bemerkungen";
            this.edtArbeitswocheDienstag.DataSource = this.qryDienstag;
            this.edtArbeitswocheDienstag.Location = new System.Drawing.Point(163, 110);
            this.edtArbeitswocheDienstag.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.edtArbeitswocheDienstag.Name = "edtArbeitswocheDienstag";
            this.edtArbeitswocheDienstag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtArbeitswocheDienstag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtArbeitswocheDienstag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtArbeitswocheDienstag.Properties.Appearance.Options.UseBackColor = true;
            this.edtArbeitswocheDienstag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtArbeitswocheDienstag.Properties.Appearance.Options.UseFont = true;
            this.edtArbeitswocheDienstag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtArbeitswocheDienstag.Size = new System.Drawing.Size(148, 153);
            this.edtArbeitswocheDienstag.TabIndex = 2;
            //
            // qryDienstag
            //
            this.qryDienstag.HostControl = this;
            this.qryDienstag.TableName = "EdVerfuegbarkeit_ProTag";
            this.qryDienstag.ColumnChanging += new System.Data.DataColumnChangeEventHandler(this.qryDienstag_ColumnChanging);
            //
            // grpArbeitswocheDienstag
            //
            this.grpArbeitswocheDienstag.Controls.Add(this.chkDiNacht);
            this.grpArbeitswocheDienstag.Controls.Add(this.chkDiAbend);
            this.grpArbeitswocheDienstag.Controls.Add(this.chkDiNachmittag);
            this.grpArbeitswocheDienstag.Controls.Add(this.chkDiMorgen);
            this.grpArbeitswocheDienstag.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grpArbeitswocheDienstag.Location = new System.Drawing.Point(163, 9);
            this.grpArbeitswocheDienstag.Name = "grpArbeitswocheDienstag";
            this.grpArbeitswocheDienstag.Size = new System.Drawing.Size(148, 95);
            this.grpArbeitswocheDienstag.TabIndex = 1;
            this.grpArbeitswocheDienstag.TabStop = false;
            this.grpArbeitswocheDienstag.Text = "Dienstag";
            this.grpArbeitswocheDienstag.UseCompatibleTextRendering = true;
            //
            // chkDiNacht
            //
            this.chkDiNacht.DataMember = "VerfuegbarNacht";
            this.chkDiNacht.DataSource = this.qryDienstag;
            this.chkDiNacht.Location = new System.Drawing.Point(6, 68);
            this.chkDiNacht.Name = "chkDiNacht";
            this.chkDiNacht.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkDiNacht.Properties.Appearance.Options.UseBackColor = true;
            this.chkDiNacht.Properties.Caption = "Nacht";
            this.chkDiNacht.Size = new System.Drawing.Size(125, 19);
            this.chkDiNacht.TabIndex = 3;
            this.chkDiNacht.CheckedChanged += new System.EventHandler(this.WeekdayCheckedChanged);
            //
            // chkDiAbend
            //
            this.chkDiAbend.DataMember = "VerfuegbarAbend";
            this.chkDiAbend.DataSource = this.qryDienstag;
            this.chkDiAbend.Location = new System.Drawing.Point(6, 52);
            this.chkDiAbend.Name = "chkDiAbend";
            this.chkDiAbend.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkDiAbend.Properties.Appearance.Options.UseBackColor = true;
            this.chkDiAbend.Properties.Caption = "Abend";
            this.chkDiAbend.Size = new System.Drawing.Size(125, 19);
            this.chkDiAbend.TabIndex = 2;
            this.chkDiAbend.CheckedChanged += new System.EventHandler(this.WeekdayCheckedChanged);
            //
            // chkDiNachmittag
            //
            this.chkDiNachmittag.DataMember = "VerfuegbarNachmittag";
            this.chkDiNachmittag.DataSource = this.qryDienstag;
            this.chkDiNachmittag.Location = new System.Drawing.Point(6, 36);
            this.chkDiNachmittag.Name = "chkDiNachmittag";
            this.chkDiNachmittag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkDiNachmittag.Properties.Appearance.Options.UseBackColor = true;
            this.chkDiNachmittag.Properties.Caption = "Nachmittag";
            this.chkDiNachmittag.Size = new System.Drawing.Size(125, 19);
            this.chkDiNachmittag.TabIndex = 1;
            this.chkDiNachmittag.CheckedChanged += new System.EventHandler(this.WeekdayCheckedChanged);
            //
            // chkDiMorgen
            //
            this.chkDiMorgen.DataMember = "VerfuegbarMorgen";
            this.chkDiMorgen.DataSource = this.qryDienstag;
            this.chkDiMorgen.Location = new System.Drawing.Point(6, 20);
            this.chkDiMorgen.Name = "chkDiMorgen";
            this.chkDiMorgen.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkDiMorgen.Properties.Appearance.Options.UseBackColor = true;
            this.chkDiMorgen.Properties.Caption = "Morgen";
            this.chkDiMorgen.Size = new System.Drawing.Size(125, 19);
            this.chkDiMorgen.TabIndex = 0;
            this.chkDiMorgen.CheckedChanged += new System.EventHandler(this.WeekdayCheckedChanged);
            //
            // grpArbeitswocheMontag
            //
            this.grpArbeitswocheMontag.Controls.Add(this.chkMoNacht);
            this.grpArbeitswocheMontag.Controls.Add(this.chkMoAbend);
            this.grpArbeitswocheMontag.Controls.Add(this.chkMoNachmittag);
            this.grpArbeitswocheMontag.Controls.Add(this.chkMoMorgen);
            this.grpArbeitswocheMontag.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grpArbeitswocheMontag.Location = new System.Drawing.Point(9, 9);
            this.grpArbeitswocheMontag.Name = "grpArbeitswocheMontag";
            this.grpArbeitswocheMontag.Size = new System.Drawing.Size(148, 95);
            this.grpArbeitswocheMontag.TabIndex = 0;
            this.grpArbeitswocheMontag.TabStop = false;
            this.grpArbeitswocheMontag.Text = "Montag";
            this.grpArbeitswocheMontag.UseCompatibleTextRendering = true;
            //
            // chkMoNacht
            //
            this.chkMoNacht.DataMember = "VerfuegbarNacht";
            this.chkMoNacht.DataSource = this.qryMontag;
            this.chkMoNacht.Location = new System.Drawing.Point(6, 68);
            this.chkMoNacht.Name = "chkMoNacht";
            this.chkMoNacht.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkMoNacht.Properties.Appearance.Options.UseBackColor = true;
            this.chkMoNacht.Properties.Caption = "Nacht";
            this.chkMoNacht.Size = new System.Drawing.Size(125, 19);
            this.chkMoNacht.TabIndex = 3;
            this.chkMoNacht.CheckedChanged += new System.EventHandler(this.WeekdayCheckedChanged);
            //
            // qryMontag
            //
            this.qryMontag.HostControl = this;
            this.qryMontag.TableName = "EdVerfuegbarkeit_ProTag";
            this.qryMontag.ColumnChanging += new System.Data.DataColumnChangeEventHandler(this.qryMontag_ColumnChanging);
            //
            // chkMoAbend
            //
            this.chkMoAbend.DataMember = "VerfuegbarAbend";
            this.chkMoAbend.DataSource = this.qryMontag;
            this.chkMoAbend.Location = new System.Drawing.Point(6, 52);
            this.chkMoAbend.Name = "chkMoAbend";
            this.chkMoAbend.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkMoAbend.Properties.Appearance.Options.UseBackColor = true;
            this.chkMoAbend.Properties.Caption = "Abend";
            this.chkMoAbend.Size = new System.Drawing.Size(125, 19);
            this.chkMoAbend.TabIndex = 2;
            this.chkMoAbend.CheckedChanged += new System.EventHandler(this.WeekdayCheckedChanged);
            //
            // chkMoNachmittag
            //
            this.chkMoNachmittag.DataMember = "VerfuegbarNachmittag";
            this.chkMoNachmittag.DataSource = this.qryMontag;
            this.chkMoNachmittag.Location = new System.Drawing.Point(6, 36);
            this.chkMoNachmittag.Name = "chkMoNachmittag";
            this.chkMoNachmittag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkMoNachmittag.Properties.Appearance.Options.UseBackColor = true;
            this.chkMoNachmittag.Properties.Caption = "Nachmittag";
            this.chkMoNachmittag.Size = new System.Drawing.Size(125, 19);
            this.chkMoNachmittag.TabIndex = 1;
            this.chkMoNachmittag.CheckedChanged += new System.EventHandler(this.WeekdayCheckedChanged);
            //
            // chkMoMorgen
            //
            this.chkMoMorgen.DataMember = "VerfuegbarMorgen";
            this.chkMoMorgen.DataSource = this.qryMontag;
            this.chkMoMorgen.Location = new System.Drawing.Point(6, 20);
            this.chkMoMorgen.Name = "chkMoMorgen";
            this.chkMoMorgen.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkMoMorgen.Properties.Appearance.Options.UseBackColor = true;
            this.chkMoMorgen.Properties.Caption = "Morgen";
            this.chkMoMorgen.Size = new System.Drawing.Size(125, 19);
            this.chkMoMorgen.TabIndex = 0;
            this.chkMoMorgen.CheckedChanged += new System.EventHandler(this.WeekdayCheckedChanged);
            //
            // edtArbeitswocheMontag
            //
            this.edtArbeitswocheMontag.DataMember = "Bemerkungen";
            this.edtArbeitswocheMontag.DataSource = this.qryMontag;
            this.edtArbeitswocheMontag.Location = new System.Drawing.Point(9, 110);
            this.edtArbeitswocheMontag.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.edtArbeitswocheMontag.Name = "edtArbeitswocheMontag";
            this.edtArbeitswocheMontag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtArbeitswocheMontag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtArbeitswocheMontag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtArbeitswocheMontag.Properties.Appearance.Options.UseBackColor = true;
            this.edtArbeitswocheMontag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtArbeitswocheMontag.Properties.Appearance.Options.UseFont = true;
            this.edtArbeitswocheMontag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtArbeitswocheMontag.Size = new System.Drawing.Size(148, 153);
            this.edtArbeitswocheMontag.TabIndex = 0;
            //
            // tpgWochenende
            //
            this.tpgWochenende.Controls.Add(this.edtWochenendeSonntag);
            this.tpgWochenende.Controls.Add(this.grpWochenendeSonntag);
            this.tpgWochenende.Controls.Add(this.edtWochenendeSamstag);
            this.tpgWochenende.Controls.Add(this.grpWochenendeSamstag);
            this.tpgWochenende.Location = new System.Drawing.Point(6, 6);
            this.tpgWochenende.Name = "tpgWochenende";
            this.tpgWochenende.Size = new System.Drawing.Size(788, 272);
            this.tpgWochenende.TabIndex = 3;
            this.tpgWochenende.Title = "Wochenende";
            //
            // edtWochenendeSonntag
            //
            this.edtWochenendeSonntag.DataMember = "Bemerkungen";
            this.edtWochenendeSonntag.DataSource = this.qrySonntag;
            this.edtWochenendeSonntag.Location = new System.Drawing.Point(163, 110);
            this.edtWochenendeSonntag.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.edtWochenendeSonntag.Name = "edtWochenendeSonntag";
            this.edtWochenendeSonntag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWochenendeSonntag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWochenendeSonntag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWochenendeSonntag.Properties.Appearance.Options.UseBackColor = true;
            this.edtWochenendeSonntag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWochenendeSonntag.Properties.Appearance.Options.UseFont = true;
            this.edtWochenendeSonntag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtWochenendeSonntag.Size = new System.Drawing.Size(148, 153);
            this.edtWochenendeSonntag.TabIndex = 3;
            //
            // qrySonntag
            //
            this.qrySonntag.HostControl = this;
            this.qrySonntag.TableName = "EdVerfuegbarkeit_ProTag";
            this.qrySonntag.ColumnChanging += new System.Data.DataColumnChangeEventHandler(this.qrySonntag_ColumnChanging);
            //
            // grpWochenendeSonntag
            //
            this.grpWochenendeSonntag.Controls.Add(this.chkSoNacht);
            this.grpWochenendeSonntag.Controls.Add(this.chkSoAbend);
            this.grpWochenendeSonntag.Controls.Add(this.chkSoNachmittag);
            this.grpWochenendeSonntag.Controls.Add(this.chkSoMorgen);
            this.grpWochenendeSonntag.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grpWochenendeSonntag.Location = new System.Drawing.Point(163, 9);
            this.grpWochenendeSonntag.Name = "grpWochenendeSonntag";
            this.grpWochenendeSonntag.Size = new System.Drawing.Size(148, 95);
            this.grpWochenendeSonntag.TabIndex = 2;
            this.grpWochenendeSonntag.TabStop = false;
            this.grpWochenendeSonntag.Text = "Sonntag";
            this.grpWochenendeSonntag.UseCompatibleTextRendering = true;
            //
            // chkSoNacht
            //
            this.chkSoNacht.DataMember = "VerfuegbarNacht";
            this.chkSoNacht.DataSource = this.qrySonntag;
            this.chkSoNacht.Location = new System.Drawing.Point(6, 68);
            this.chkSoNacht.Name = "chkSoNacht";
            this.chkSoNacht.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkSoNacht.Properties.Appearance.Options.UseBackColor = true;
            this.chkSoNacht.Properties.Caption = "Nacht";
            this.chkSoNacht.Size = new System.Drawing.Size(125, 19);
            this.chkSoNacht.TabIndex = 3;
            this.chkSoNacht.CheckedChanged += new System.EventHandler(this.WeekdayCheckedChanged);
            //
            // chkSoAbend
            //
            this.chkSoAbend.DataMember = "VerfuegbarAbend";
            this.chkSoAbend.DataSource = this.qrySonntag;
            this.chkSoAbend.Location = new System.Drawing.Point(6, 52);
            this.chkSoAbend.Name = "chkSoAbend";
            this.chkSoAbend.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkSoAbend.Properties.Appearance.Options.UseBackColor = true;
            this.chkSoAbend.Properties.Caption = "Abend";
            this.chkSoAbend.Size = new System.Drawing.Size(125, 19);
            this.chkSoAbend.TabIndex = 2;
            this.chkSoAbend.CheckedChanged += new System.EventHandler(this.WeekdayCheckedChanged);
            //
            // chkSoNachmittag
            //
            this.chkSoNachmittag.DataMember = "VerfuegbarNachmittag";
            this.chkSoNachmittag.DataSource = this.qrySonntag;
            this.chkSoNachmittag.Location = new System.Drawing.Point(6, 36);
            this.chkSoNachmittag.Name = "chkSoNachmittag";
            this.chkSoNachmittag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkSoNachmittag.Properties.Appearance.Options.UseBackColor = true;
            this.chkSoNachmittag.Properties.Caption = "Nachmittag";
            this.chkSoNachmittag.Size = new System.Drawing.Size(125, 19);
            this.chkSoNachmittag.TabIndex = 1;
            this.chkSoNachmittag.CheckedChanged += new System.EventHandler(this.WeekdayCheckedChanged);
            //
            // chkSoMorgen
            //
            this.chkSoMorgen.DataMember = "VerfuegbarMorgen";
            this.chkSoMorgen.DataSource = this.qrySonntag;
            this.chkSoMorgen.Location = new System.Drawing.Point(6, 20);
            this.chkSoMorgen.Name = "chkSoMorgen";
            this.chkSoMorgen.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkSoMorgen.Properties.Appearance.Options.UseBackColor = true;
            this.chkSoMorgen.Properties.Caption = "Morgen";
            this.chkSoMorgen.Size = new System.Drawing.Size(125, 19);
            this.chkSoMorgen.TabIndex = 0;
            this.chkSoMorgen.CheckedChanged += new System.EventHandler(this.WeekdayCheckedChanged);
            //
            // edtWochenendeSamstag
            //
            this.edtWochenendeSamstag.DataMember = "Bemerkungen";
            this.edtWochenendeSamstag.DataSource = this.qrySamstag;
            this.edtWochenendeSamstag.Location = new System.Drawing.Point(9, 110);
            this.edtWochenendeSamstag.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.edtWochenendeSamstag.Name = "edtWochenendeSamstag";
            this.edtWochenendeSamstag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWochenendeSamstag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWochenendeSamstag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWochenendeSamstag.Properties.Appearance.Options.UseBackColor = true;
            this.edtWochenendeSamstag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWochenendeSamstag.Properties.Appearance.Options.UseFont = true;
            this.edtWochenendeSamstag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtWochenendeSamstag.Size = new System.Drawing.Size(148, 153);
            this.edtWochenendeSamstag.TabIndex = 1;
            //
            // qrySamstag
            //
            this.qrySamstag.HostControl = this;
            this.qrySamstag.TableName = "EdVerfuegbarkeit_ProTag";
            this.qrySamstag.ColumnChanging += new System.Data.DataColumnChangeEventHandler(this.qrySamstag_ColumnChanging);
            //
            // grpWochenendeSamstag
            //
            this.grpWochenendeSamstag.Controls.Add(this.chkSaNacht);
            this.grpWochenendeSamstag.Controls.Add(this.chkSaAbend);
            this.grpWochenendeSamstag.Controls.Add(this.chkSaNachmittag);
            this.grpWochenendeSamstag.Controls.Add(this.chkSaMorgen);
            this.grpWochenendeSamstag.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grpWochenendeSamstag.Location = new System.Drawing.Point(9, 9);
            this.grpWochenendeSamstag.Name = "grpWochenendeSamstag";
            this.grpWochenendeSamstag.Size = new System.Drawing.Size(148, 95);
            this.grpWochenendeSamstag.TabIndex = 0;
            this.grpWochenendeSamstag.TabStop = false;
            this.grpWochenendeSamstag.Text = "Samstag";
            this.grpWochenendeSamstag.UseCompatibleTextRendering = true;
            //
            // chkSaNacht
            //
            this.chkSaNacht.DataMember = "VerfuegbarNacht";
            this.chkSaNacht.DataSource = this.qrySamstag;
            this.chkSaNacht.Location = new System.Drawing.Point(6, 68);
            this.chkSaNacht.Name = "chkSaNacht";
            this.chkSaNacht.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkSaNacht.Properties.Appearance.Options.UseBackColor = true;
            this.chkSaNacht.Properties.Caption = "Nacht";
            this.chkSaNacht.Size = new System.Drawing.Size(125, 19);
            this.chkSaNacht.TabIndex = 3;
            this.chkSaNacht.CheckedChanged += new System.EventHandler(this.WeekdayCheckedChanged);
            //
            // chkSaAbend
            //
            this.chkSaAbend.DataMember = "VerfuegbarAbend";
            this.chkSaAbend.DataSource = this.qrySamstag;
            this.chkSaAbend.Location = new System.Drawing.Point(6, 52);
            this.chkSaAbend.Name = "chkSaAbend";
            this.chkSaAbend.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkSaAbend.Properties.Appearance.Options.UseBackColor = true;
            this.chkSaAbend.Properties.Caption = "Abend";
            this.chkSaAbend.Size = new System.Drawing.Size(125, 19);
            this.chkSaAbend.TabIndex = 2;
            this.chkSaAbend.CheckedChanged += new System.EventHandler(this.WeekdayCheckedChanged);
            //
            // chkSaNachmittag
            //
            this.chkSaNachmittag.DataMember = "VerfuegbarNachmittag";
            this.chkSaNachmittag.DataSource = this.qrySamstag;
            this.chkSaNachmittag.Location = new System.Drawing.Point(6, 36);
            this.chkSaNachmittag.Name = "chkSaNachmittag";
            this.chkSaNachmittag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkSaNachmittag.Properties.Appearance.Options.UseBackColor = true;
            this.chkSaNachmittag.Properties.Caption = "Nachmittag";
            this.chkSaNachmittag.Size = new System.Drawing.Size(125, 19);
            this.chkSaNachmittag.TabIndex = 1;
            this.chkSaNachmittag.CheckedChanged += new System.EventHandler(this.WeekdayCheckedChanged);
            //
            // chkSaMorgen
            //
            this.chkSaMorgen.DataMember = "VerfuegbarMorgen";
            this.chkSaMorgen.DataSource = this.qrySamstag;
            this.chkSaMorgen.Location = new System.Drawing.Point(6, 20);
            this.chkSaMorgen.Name = "chkSaMorgen";
            this.chkSaMorgen.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkSaMorgen.Properties.Appearance.Options.UseBackColor = true;
            this.chkSaMorgen.Properties.Caption = "Morgen";
            this.chkSaMorgen.Size = new System.Drawing.Size(125, 19);
            this.chkSaMorgen.TabIndex = 0;
            this.chkSaMorgen.CheckedChanged += new System.EventHandler(this.WeekdayCheckedChanged);
            //
            // tpgEinsatzplanung
            //
            this.tpgEinsatzplanung.Controls.Add(this.tblEinsatzplanung);
            this.tpgEinsatzplanung.Location = new System.Drawing.Point(6, 6);
            this.tpgEinsatzplanung.Name = "tpgEinsatzplanung";
            this.tpgEinsatzplanung.Size = new System.Drawing.Size(788, 272);
            this.tpgEinsatzplanung.TabIndex = 4;
            this.tpgEinsatzplanung.Title = "Einsatzplanung";
            //
            // tblEinsatzplanung
            //
            this.tblEinsatzplanung.ColumnCount = 2;
            this.tblEinsatzplanung.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblEinsatzplanung.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblEinsatzplanung.Controls.Add(this.lblAktuelleBegleitungen, 0, 0);
            this.tblEinsatzplanung.Controls.Add(this.lblEhemaligeBegleitungen, 0, 1);
            this.tblEinsatzplanung.Controls.Add(this.kissMemoEdit2, 1, 0);
            this.tblEinsatzplanung.Controls.Add(this.kissMemoEdit3, 1, 1);
            this.tblEinsatzplanung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblEinsatzplanung.Location = new System.Drawing.Point(0, 0);
            this.tblEinsatzplanung.Name = "tblEinsatzplanung";
            this.tblEinsatzplanung.RowCount = 2;
            this.tblEinsatzplanung.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblEinsatzplanung.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblEinsatzplanung.Size = new System.Drawing.Size(788, 272);
            this.tblEinsatzplanung.TabIndex = 1;
            //
            // lblAktuelleBegleitungen
            //
            this.lblAktuelleBegleitungen.Location = new System.Drawing.Point(3, 3);
            this.lblAktuelleBegleitungen.Margin = new System.Windows.Forms.Padding(3);
            this.lblAktuelleBegleitungen.Name = "lblAktuelleBegleitungen";
            this.lblAktuelleBegleitungen.Size = new System.Drawing.Size(150, 24);
            this.lblAktuelleBegleitungen.TabIndex = 0;
            this.lblAktuelleBegleitungen.Text = "Aktuelle Begleitungen";
            //
            // lblEhemaligeBegleitungen
            //
            this.lblEhemaligeBegleitungen.Location = new System.Drawing.Point(3, 139);
            this.lblEhemaligeBegleitungen.Margin = new System.Windows.Forms.Padding(3);
            this.lblEhemaligeBegleitungen.Name = "lblEhemaligeBegleitungen";
            this.lblEhemaligeBegleitungen.Size = new System.Drawing.Size(150, 24);
            this.lblEhemaligeBegleitungen.TabIndex = 1;
            this.lblEhemaligeBegleitungen.Text = "Ehemalige Begleitungen";
            //
            // kissMemoEdit2
            //
            this.kissMemoEdit2.DataMember = "AktuelleBegleitungen";
            this.kissMemoEdit2.DataSource = this.qryEdVerfuegbarkeit;
            this.kissMemoEdit2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kissMemoEdit2.Location = new System.Drawing.Point(159, 3);
            this.kissMemoEdit2.Name = "kissMemoEdit2";
            this.kissMemoEdit2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.kissMemoEdit2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissMemoEdit2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissMemoEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.kissMemoEdit2.Properties.Appearance.Options.UseBorderColor = true;
            this.kissMemoEdit2.Properties.Appearance.Options.UseFont = true;
            this.kissMemoEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissMemoEdit2.Size = new System.Drawing.Size(626, 130);
            this.kissMemoEdit2.TabIndex = 2;
            //
            // kissMemoEdit3
            //
            this.kissMemoEdit3.DataMember = "EhemaligeBegleitungen";
            this.kissMemoEdit3.DataSource = this.qryEdVerfuegbarkeit;
            this.kissMemoEdit3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kissMemoEdit3.Location = new System.Drawing.Point(159, 139);
            this.kissMemoEdit3.Name = "kissMemoEdit3";
            this.kissMemoEdit3.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.kissMemoEdit3.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissMemoEdit3.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissMemoEdit3.Properties.Appearance.Options.UseBackColor = true;
            this.kissMemoEdit3.Properties.Appearance.Options.UseBorderColor = true;
            this.kissMemoEdit3.Properties.Appearance.Options.UseFont = true;
            this.kissMemoEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissMemoEdit3.Size = new System.Drawing.Size(626, 130);
            this.kissMemoEdit3.TabIndex = 3;
            //
            // btnMitarbeiterdaten
            //
            this.btnMitarbeiterdaten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMitarbeiterdaten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMitarbeiterdaten.Location = new System.Drawing.Point(664, 552);
            this.btnMitarbeiterdaten.Name = "btnMitarbeiterdaten";
            this.btnMitarbeiterdaten.Size = new System.Drawing.Size(131, 24);
            this.btnMitarbeiterdaten.TabIndex = 2;
            this.btnMitarbeiterdaten.Text = ">> &Mitarbeiterdaten";
            this.btnMitarbeiterdaten.UseCompatibleTextRendering = true;
            this.btnMitarbeiterdaten.UseVisualStyleBackColor = false;
            this.btnMitarbeiterdaten.Click += new System.EventHandler(this.btnMitarbeiterdaten_Click);
            //
            // edtSucheModul
            //
            this.edtSucheModul.Location = new System.Drawing.Point(131, 131);
            this.edtSucheModul.LOVFilter = "ModulID IN (5,6)";
            this.edtSucheModul.LOVFilterWhereAppend = true;
            this.edtSucheModul.LOVName = "Modul";
            this.edtSucheModul.Name = "edtSucheModul";
            this.edtSucheModul.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheModul.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheModul.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheModul.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheModul.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheModul.Properties.Appearance.Options.UseFont = true;
            this.edtSucheModul.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheModul.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheModul.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheModul.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheModul.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtSucheModul.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtSucheModul.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheModul.Properties.NullText = "";
            this.edtSucheModul.Properties.ShowFooter = false;
            this.edtSucheModul.Properties.ShowHeader = false;
            this.edtSucheModul.Size = new System.Drawing.Size(223, 24);
            this.edtSucheModul.TabIndex = 8;
            //
            // lblSucheModul
            //
            this.lblSucheModul.Location = new System.Drawing.Point(30, 131);
            this.lblSucheModul.Name = "lblSucheModul";
            this.lblSucheModul.Size = new System.Drawing.Size(95, 24);
            this.lblSucheModul.TabIndex = 7;
            this.lblSucheModul.Text = "Modul";
            this.lblSucheModul.UseCompatibleTextRendering = true;
            //
            // edtSucheTypBW
            //
            this.edtSucheTypBW.Location = new System.Drawing.Point(501, 40);
            this.edtSucheTypBW.LOVName = "BwTyp";
            this.edtSucheTypBW.Name = "edtSucheTypBW";
            this.edtSucheTypBW.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheTypBW.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheTypBW.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheTypBW.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheTypBW.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheTypBW.Properties.Appearance.Options.UseFont = true;
            this.edtSucheTypBW.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheTypBW.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheTypBW.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheTypBW.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheTypBW.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSucheTypBW.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSucheTypBW.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheTypBW.Properties.NullText = "";
            this.edtSucheTypBW.Properties.ShowFooter = false;
            this.edtSucheTypBW.Properties.ShowHeader = false;
            this.edtSucheTypBW.Size = new System.Drawing.Size(223, 24);
            this.edtSucheTypBW.TabIndex = 10;
            //
            // lblSucheTypBW
            //
            this.lblSucheTypBW.Location = new System.Drawing.Point(400, 40);
            this.lblSucheTypBW.Name = "lblSucheTypBW";
            this.lblSucheTypBW.Size = new System.Drawing.Size(95, 24);
            this.lblSucheTypBW.TabIndex = 9;
            this.lblSucheTypBW.Text = "Typ BW";
            //
            // CtlVerfuegbarkeit
            //
            this.ActiveSQLQuery = this.qryEdVerfuegbarkeit;
            this.Controls.Add(this.btnMitarbeiterdaten);
            this.Controls.Add(this.tabVerfuegbarkeit);
            this.Name = "CtlVerfuegbarkeit";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.Size = new System.Drawing.Size(800, 580);
            this.Load += new System.EventHandler(this.CtlVerfuegbarkeit_Load);
            this.Controls.SetChildIndex(this.tabVerfuegbarkeit, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.btnMitarbeiterdaten, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEdVerfuegbarkeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryEdVerfuegbarkeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEdVerfuegbarkeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheTypED)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTypED.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTypED)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheEinsatzregion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheEinsatzregion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheEinsatzregion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheEigenesFahrzeug.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheNurAktive.Properties)).EndInit();
            this.tabVerfuegbarkeit.ResumeLayout(false);
            this.tpgGrundangaben.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundangabenTypBW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundangabenTypBW.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundangabenBemerkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundangabenBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGrundangabenGruppen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundangabenGruppen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGrundangabenKeineFrequenz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundangabenFrequenz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundangabenFrequenz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundangabenTypED.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundangabenTypED)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundangabenMobilitaetBemerkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGrundangabenMobilitaetEigenesFahrzeug.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGrundangabenMobilitaetFahrausweis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundangabenMobilitaet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundangabenTelefon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundangabenTelefon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundangabenMitarbeiter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundangabenMitarbeiter)).EndInit();
            this.tpgEinsatzorte.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzorteRegionen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzorteRegionen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzorteOrte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzorteOrte)).EndInit();
            this.tpgArbeitswoche.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtArbeitswocheFreitag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFreitag)).EndInit();
            this.grpArbeitswocheFreitag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkFrNacht.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFrAbend.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFrNachmittag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFrMorgen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtArbeitswocheDonnerstag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryDonnerstag)).EndInit();
            this.grpArbeitswocheDonnerstag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkDoNacht.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDoAbend.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDoNachmittag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDoMorgen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtArbeitswocheMittwoch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryMittwoch)).EndInit();
            this.grpArbeitswocheMittwoch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkMiNacht.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMiAbend.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMiNachmittag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMiMorgen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtArbeitswocheDienstag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryDienstag)).EndInit();
            this.grpArbeitswocheDienstag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkDiNacht.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDiAbend.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDiNachmittag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDiMorgen.Properties)).EndInit();
            this.grpArbeitswocheMontag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkMoNacht.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryMontag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMoAbend.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMoNachmittag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMoMorgen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtArbeitswocheMontag.Properties)).EndInit();
            this.tpgWochenende.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtWochenendeSonntag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrySonntag)).EndInit();
            this.grpWochenendeSonntag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkSoNacht.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSoAbend.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSoNachmittag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSoMorgen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWochenendeSamstag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrySamstag)).EndInit();
            this.grpWochenendeSamstag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkSaNacht.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSaAbend.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSaNachmittag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSaMorgen.Properties)).EndInit();
            this.tpgEinsatzplanung.ResumeLayout(false);
            this.tblEinsatzplanung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblAktuelleBegleitungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEhemaligeBegleitungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissMemoEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissMemoEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheModul.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheModul)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheModul)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTypBW.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTypBW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheTypBW)).EndInit();
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

        private void btnMitarbeiterdaten_Click(object sender, System.EventArgs e)
        {
            // check if call is valid
            if (qryEdVerfuegbarkeit.Count < 1 || DBUtil.IsEmpty(qryEdVerfuegbarkeit["EdMitarbeiterID"]))
            {
                // do nothing
                return;
            }

            // jump to selected EdMitarbeiterID
            FormController.SendMessage(FrmMitarbeiterverwaltung.FormControllerTarget_Mitarbeiterverwaltung,
                                       "Action", CtlMitarbeiterverwaltung.FormControllerAction_JumpToMitarbeiter,
                                       "EdMitarbeiterID", qryEdVerfuegbarkeit["EdMitarbeiterID"]);
        }

        private void chkGrundangabenKeineFrequenz_CheckedChanged(object sender, System.EventArgs e)
        {
            // check if user interaction changed value
            if (!chkGrundangabenKeineFrequenz.UserModified)
            {
                // no user interaction, do not continue
                return;
            }

            // check if control is checked
            if (chkGrundangabenKeineFrequenz.Checked)
            {
                // check permission to be checked
                if (chkMoMorgen.Checked || chkMoNachmittag.Checked || chkMoAbend.Checked || chkMoNacht.Checked ||
                    chkDiMorgen.Checked || chkDiNachmittag.Checked || chkDiAbend.Checked || chkDiNacht.Checked ||
                    chkMiMorgen.Checked || chkMiNachmittag.Checked || chkMiAbend.Checked || chkMiNacht.Checked ||
                    chkDoMorgen.Checked || chkDoNachmittag.Checked || chkDoAbend.Checked || chkDoNacht.Checked ||
                    chkFrMorgen.Checked || chkFrNachmittag.Checked || chkFrAbend.Checked || chkFrNacht.Checked ||
                    chkSaMorgen.Checked || chkSaNachmittag.Checked || chkSaAbend.Checked || chkSaNacht.Checked ||
                    chkSoMorgen.Checked || chkSoNachmittag.Checked || chkSoAbend.Checked || chkSoNacht.Checked)
                {
                    // uncheck control again
                    chkGrundangabenKeineFrequenz.Checked = false;

                    // show information to user
                    KissMsg.ShowInfo(this.Name, "FrequencyCheckedValueIsNotAllowed", "Dieses Feld kann erst aktiviert werden, wenn alle Felder auf den Reitern 'Arbeitswoche' und 'Wochenende' abgewählt sind.");
                }
            }
        }

        private void CtlVerfuegbarkeit_Load(object sender, System.EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // start a new search
            this.NewSearch();
            this.tabControlSearch.SelectTab(this.tpgListe);

            // show first tab for details
            this.tabVerfuegbarkeit.SelectTab(this.tpgGrundangaben);

            // logging
            _logger.Debug("done");
        }

        private void qryDienstag_ColumnChanging(object sender, System.Data.DataColumnChangeEventArgs e)
        {
            this.DailyQueryColumnChanging();
        }

        private void qryDonnerstag_ColumnChanging(object sender, System.Data.DataColumnChangeEventArgs e)
        {
            this.DailyQueryColumnChanging();
        }

        private void qryEdVerfuegbarkeit_AfterFill(object sender, System.EventArgs e)
        {
            // after loading qryEdVerfuegbarkeit, we also fill data of given entry in daily-queries
            this.LoadQueries();
        }

        private void qryEdVerfuegbarkeit_PositionChanged(object sender, System.EventArgs e)
        {
            // after changed position within qryEdVerfuegbarkeit, we also fill data of given entry in daily-queries
            this.LoadQueries();
        }

        private void qryEdVerfuegbarkeit_PositionChanging(object sender, System.EventArgs e)
        {
            // if update is allowed, we need to save pending changes (mainly because of daily-queries)
            if (qryEdVerfuegbarkeit.CanUpdate)
            {
                // save all changes
                if (!this.OnSaveData())
                {
                    // cancel switching rows due to save-failure
                    throw new KissCancelException();
                }
            }
        }

        private void qryFreitag_ColumnChanging(object sender, System.Data.DataColumnChangeEventArgs e)
        {
            this.DailyQueryColumnChanging();
        }

        private void qryMittwoch_ColumnChanging(object sender, System.Data.DataColumnChangeEventArgs e)
        {
            this.DailyQueryColumnChanging();
        }

        private void qryMontag_ColumnChanging(object sender, System.Data.DataColumnChangeEventArgs e)
        {
            this.DailyQueryColumnChanging();
        }

        private void qrySamstag_ColumnChanging(object sender, System.Data.DataColumnChangeEventArgs e)
        {
            this.DailyQueryColumnChanging();
        }

        private void qrySonntag_ColumnChanging(object sender, System.Data.DataColumnChangeEventArgs e)
        {
            this.DailyQueryColumnChanging();
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Init the control
        /// </summary>
        public void Init()
        {
            // logging
            _logger.Debug("enter");

            // fill Einsatzregionen depending on session-user rights
            edtEinsatzorteRegionen.LookupSQL = String.Format(@"
                SELECT Code = EDR.EdEinsatzRegionID,
                       Text = dbo.fnGetMLTextByDefault(EDR.BezeichnungTID, {0}, EDR.Bezeichnung)
                FROM dbo.EdEinsatzRegion EDR WITH (READUNCOMMITTED)
                  INNER JOIN dbo.fnGetAllKGSOfUser({1}, 0, 0) KGS ON KGS.Code = EDR.OrgUnitID
                WHERE EDR.Aktiv = 1
                ORDER BY 2", Session.User.LanguageCode, Session.User.UserID);

            // init query for Einsatzregionen-search
            SqlQuery qryEDEinsatzregionen = DBUtil.OpenSQL(String.Format(@"
                SELECT Code = null,
                       Text = null

                UNION

                SELECT Code = EDR.EdEinsatzRegionID,
                       Text = dbo.fnGetMLTextByDefault(EDR.BezeichnungTID, {0}, EDR.Bezeichnung)
                FROM dbo.EdEinsatzRegion EDR WITH (READUNCOMMITTED)
                  INNER JOIN dbo.fnGetAllKGSOfUser({1}, 0, 0) KGS ON KGS.Code = EDR.OrgUnitID
                WHERE EDR.Aktiv = 1
                ORDER BY 2", Session.User.LanguageCode, Session.User.UserID));

            edtSucheEinsatzregion.LoadQuery(qryEDEinsatzregionen);
            edtSucheEinsatzregion.Properties.DropDownRows = 7;

            // logging
            _logger.Debug("done");
        }

        /// <summary>
        /// Refresh data
        /// </summary>
        public override void OnRefreshData()
        {
            // logging
            _logger.Debug("enter");

            // refresh main-data
            this.ActiveSQLQuery.Refresh();

            // refresh sub-data
            qryMontag.Refresh();
            qryDienstag.Refresh();
            qryMittwoch.Refresh();
            qryDonnerstag.Refresh();
            qryFreitag.Refresh();
            qrySamstag.Refresh();
            qrySonntag.Refresh();

            // logging
            _logger.Debug("done");
        }

        /// <summary>
        /// Save data
        /// </summary>
        /// <returns><c>True</c> on success, otherwise <c>False</c></returns>
        public override bool OnSaveData()
        {
            // logging
            _logger.Debug("enter");

            // first try to save main-data and then try to save sub-data
            bool success = this.ActiveSQLQuery.Post();
            success = success && qryMontag.Post() && qryDienstag.Post() && qryMittwoch.Post() && qryDonnerstag.Post() && qryFreitag.Post() && qrySamstag.Post() && qrySonntag.Post();

            try
            {
                // if successfully saved data, refresh display due to huge amount of columns to update otherwiese
                if (success)
                {
                    // refresh display from database
                    this.OnRefreshData();
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(this.Name, "ErrorOnRefreshData", "Es ist ein Fehler beim Aktualisieren der Daten aufgetreten, die Anzeige ist möglicherweise nicht korrekt.", ex);

                // logging
                _logger.Error("Error refreshing data occured.", ex);
                XLog.Create(this.GetType().FullName, LogLevel.ERROR, "Error refreshing data occured.", ex.Message);
            }

            // logging
            _logger.Debug("done");

            // return value
            return success;
        }

        /// <summary>
        /// Receive message from formcontroller
        /// </summary>
        /// <param name="param">The parameter containing the message</param>
        /// <returns><c>True</c> if message was successfully handled, otherwise <c>False</c></returns>
        public override bool ReceiveMessage(System.Collections.Specialized.HybridDictionary param)
        {
            // we need at least one parameter to know what to do
            if (param == null || param.Count < 1)
            {
                // by default, nothing to do
                return true;
            }

            // action depending
            switch (param["Action"] as String)
            {
                case "LoadEdVerfuegbarkeit":
                    // validate parameter
                    if (!param.Contains("EdMitarbeiterID"))
                    {
                        param["EdMitarbeiterID"] = -1;
                    }

                    // try to save pending changes
                    if (!this.OnSaveData())
                    {
                        // show error, save failed
                        KissMsg.ShowError(this.Name, "CouldNotJumpToEntry", "Es ist ein Fehler beim Speichern der angezeigten Daten aufgetreten. Auf den gewünschten Datensatz kann nicht gesprungen werden.");

                        // cancel
                        return false;
                    }

                    // try to locate entry
                    if (!qryEdVerfuegbarkeit.Find(String.Format("EdMitarbeiterID = {0}", param["EdMitarbeiterID"])))
                    {
                        // show info due to failure
                        KissMsg.ShowInfo(this.Name, "ReceiveMessageEdMitarbeiterNotFound_v02", "Die gewünschte Verfügbarkeit konnte nicht gefunden werden, die zugehörige Person ist möglicherweise inaktiv. Bitte suchen Sie den Eintrag manuell.");

                        // failed
                        return false;
                    }

                    // done
                    return true;
            }

            // did not understand message
            return false;
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Start e new search
        /// </summary>
        protected override void NewSearch()
        {
            // logging
            _logger.Debug("enter");

            // let base do stuff
            base.NewSearch();

            // set default values
            chkSucheNurAktive.Checked = true;

            // set default search (if defined)
            if (_defaultSearchModule.HasValue)
            {
                // apply default search value and lock control
                edtSucheModul.EditValue = _defaultSearchModule.Value;
                edtSucheModul.EditMode = EditModeType.ReadOnly;
            }

            // set focus
            edtSucheName.Focus();

            // logging
            _logger.Debug("done");
        }

        /// <summary>
        /// Run the defined search
        /// </summary>
        protected override void RunSearch()
        {
            // logging
            _logger.Debug("enter");

            // replace search parameters
            object[] parameters = new object[] { Session.User.LanguageCode, Session.User.UserID };
            this.kissSearch.SelectParameters = parameters;

            // let base do stuff
            base.RunSearch();

            // HACK: due to display-error in KissCheckedLookupEdit, we have to apply editvalue after search manually!
            if (qryEdVerfuegbarkeit.CanUpdate)
            {
                // tpg: Grundangaben
                if (!DBUtil.IsEmpty(qryEdVerfuegbarkeit["GrundangabenFrequenzCodes"]))
                {
                    edtGrundangabenFrequenz.EditValue = qryEdVerfuegbarkeit["GrundangabenFrequenzCodes"].ToString();
                }

                // tpg: Einsatzorte
                if (!DBUtil.IsEmpty(qryEdVerfuegbarkeit["EinsatzorteOrtCodes"]))
                {
                    edtEinsatzorteOrte.EditValue = qryEdVerfuegbarkeit["EinsatzorteOrtCodes"].ToString();
                }

                if (!DBUtil.IsEmpty(qryEdVerfuegbarkeit["EinsatzorteRegionCodes"]))
                {
                    edtEinsatzorteRegionen.EditValue = qryEdVerfuegbarkeit["EinsatzorteRegionCodes"].ToString();
                }
            }

            // logging
            _logger.Debug("done");
        }

        #endregion

        #region Private Methods

        private void DailyQueryColumnChanging()
        {
            qryEdVerfuegbarkeit.RowModified = true;
        }

        private void LoadQueries()
        {
            // logging
            _logger.Debug("enter");

            try
            {
                // get the values for all weekdays
                qryMontag.Fill(Convert.ToInt32(qryEdVerfuegbarkeit["EdVerfuegbarkeitID"]));
                qryMontag.EnableBoundFields();

                qryDienstag.Fill(Convert.ToInt32(qryEdVerfuegbarkeit["EdVerfuegbarkeitID"]));
                qryDienstag.EnableBoundFields();

                qryMittwoch.Fill(Convert.ToInt32(qryEdVerfuegbarkeit["EdVerfuegbarkeitID"]));
                qryMittwoch.EnableBoundFields();

                qryDonnerstag.Fill(Convert.ToInt32(qryEdVerfuegbarkeit["EdVerfuegbarkeitID"]));
                qryDonnerstag.EnableBoundFields();

                qryFreitag.Fill(Convert.ToInt32(qryEdVerfuegbarkeit["EdVerfuegbarkeitID"]));
                qryFreitag.EnableBoundFields();

                qrySamstag.Fill(Convert.ToInt32(qryEdVerfuegbarkeit["EdVerfuegbarkeitID"]));
                qrySamstag.EnableBoundFields();

                qrySonntag.Fill(Convert.ToInt32(qryEdVerfuegbarkeit["EdVerfuegbarkeitID"]));
                qrySonntag.EnableBoundFields();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(this.Name, "ErrorLoadingQueries", "Es ist ein Fehler beim Laden der Daten aufgetreten, die Anzeige ist möglicherweise nicht korrekt.", ex);

                // logging
                _logger.Error("Error loading data occured", ex);
                XLog.Create(this.GetType().FullName, LogLevel.ERROR, "Error loading data occured", ex.Message);
            }

            // logging
            _logger.Debug("done");
        }

        private void SetupRights()
        {
            // logging
            _logger.Debug("enter");

            // VARS
            bool isAdmin = Session.User.IsUserAdmin;
            bool canReadData = false;
            bool canUserInsert = false;
            bool canUserUpdate = false;
            bool canUserDelete = false;

            // set values
            Session.GetUserRight(this.Name, out canReadData, out canUserInsert, out canUserUpdate, out canUserDelete);

            if (!canReadData)
            {
                // no rights to view this control
                throw new UnauthorizedAccessException("No rights to view details of this control.");
            }

            // get special rights
            _hasBwRights = DBUtil.UserHasRight("VerwaltungBW");
            _hasEdRights = DBUtil.UserHasRight("VerwaltungED");

            // logger
            _logger.DebugFormat("isAdmin={0}, canReadData={1}, canUserInsert={2}, canUserUpdate={3}, canUserDelete={4}, _hasBwRights='{5}', _hasEdRights='{6}'",
                                isAdmin, canReadData, canUserInsert, canUserUpdate, canUserDelete, _hasBwRights, _hasEdRights);

            // no rights
            if (!isAdmin && !_hasEdRights && !_hasBwRights)
            {
                // no rights to view this control
                throw new UnauthorizedAccessException("No rights to view details of this control (no BW/ED specialrights).");
            }

            // only BwRights
            if (!isAdmin && !_hasEdRights && _hasBwRights)
            {
                // setup default search module
                _defaultSearchModule = Convert.ToInt32(BaUtils.ModulID.BegleitetesWohnen);

                // setup search-controls
                edtSucheModul.EditValue = _defaultSearchModule.Value;
                edtSucheModul.EditMode = EditModeType.ReadOnly;
                edtSucheTypED.EditMode = EditModeType.ReadOnly;

                // setup columns
                colEdAktiv.Visible = false;
                colIsEdMitarbeiter.Visible = false;
                colTypED.Visible = false;

                // setup controls
                edtGrundangabenTypED.DataMember = string.Empty;
            }
            // only EdRights
            else if (!isAdmin && _hasEdRights && !_hasBwRights)
            {
                // setup default search module
                _defaultSearchModule = Convert.ToInt32(BaUtils.ModulID.EntlastungsDienst);

                // setup search-controls
                edtSucheModul.EditValue = _defaultSearchModule.Value;
                edtSucheModul.EditMode = EditModeType.ReadOnly;
                edtSucheTypBW.EditMode = EditModeType.ReadOnly;

                // setup columns
                colBwAktiv.Visible = false;
                colIsBwMitarbeiter.Visible = false;
                colTypBW.Visible = false;

                // setup controls
                edtGrundangabenTypBW.DataMember = string.Empty;
            }

            // EdVerfuegbarkeit
            qryEdVerfuegbarkeit.CanInsert = false;
            qryEdVerfuegbarkeit.CanUpdate = isAdmin || canUserUpdate;
            qryEdVerfuegbarkeit.CanDelete = false;

            // FIELDS
            qryEdVerfuegbarkeit.EnableBoundFields();

            // EdVerfuegbarkeit_ProTag
            this.SetupRightsDailyQuery(qryMontag, (isAdmin || canUserUpdate));
            this.SetupRightsDailyQuery(qryDienstag, (isAdmin || canUserUpdate));
            this.SetupRightsDailyQuery(qryMittwoch, (isAdmin || canUserUpdate));
            this.SetupRightsDailyQuery(qryDonnerstag, (isAdmin || canUserUpdate));
            this.SetupRightsDailyQuery(qryFreitag, (isAdmin || canUserUpdate));
            this.SetupRightsDailyQuery(qrySamstag, (isAdmin || canUserUpdate));
            this.SetupRightsDailyQuery(qrySonntag, (isAdmin || canUserUpdate));

            // logging
            _logger.Debug("done");
        }

        private void SetupRightsDailyQuery(SqlQuery qry, Boolean canUpdate)
        {
            // set rights
            qry.CanInsert = false;
            qry.CanUpdate = canUpdate;
            qry.CanDelete = false;

            // enable fields
            qry.EnableBoundFields();
        }

        private void SetupSQLDailyQuery(SqlQuery qry, Int32 weekdayID)
        {
            // setup query for each daily-query depending on weekdayID
            // warning: there is the parameter EdVerfuegbarkeitID, do not use String.Format()!
            qry.SelectStatement = string.Format(@"
                SELECT EdVerfuegbarkeit_ProTagID,
                       EdVerfuegbarkeitID,
                       WochentagID,
                       VerfuegbarMorgen,
                       VerfuegbarNachmittag,
                       VerfuegbarAbend,
                       VerfuegbarNacht,
                       Bemerkungen,
                       Creator,
                       Created,
                       EdVerfuegbarkeit_ProTagTS
                FROM dbo.EdVerfuegbarkeit_ProTag WITH (READUNCOMMITTED)
                WHERE EdVerfuegbarkeitID = {{0}}
                  AND WochentagID = {0}", Convert.ToString(weekdayID));
        }

        private void WeekdayCheckedChanged(Object sender, System.EventArgs e)
        {
            // check if right control type
            if (sender is KissCheckEdit)
            {
                // check if user changed value
                if (!(sender as KissCheckEdit).UserModified)
                {
                    // no user interaction change, do not validate
                    return;
                }

                // check if given checkbox is checked but should not be checked
                if ((sender as KissCheckEdit).Checked && chkGrundangabenKeineFrequenz.Checked)
                {
                    // uncheck first again
                    (sender as KissCheckEdit).Checked = false;

                    // show information to user
                    KissMsg.ShowInfo(this.Name, "WeekdayCheckNotAllowed", "Dieses Feld kann erst aktiviert werden, wenn 'Keine Einsatzzeiten definiert' in den Grundangaben nicht gewählt ist.");
                }
            }
        }

        #endregion

        #endregion
    }
}