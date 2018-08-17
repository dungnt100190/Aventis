namespace KiSS4.Administration
{
    partial class CtlUser
    {
        private System.ComponentModel.IContainer components = null;

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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlUser));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdUser = new KiSS4.Gui.KissGrid();
            this.qryUser = new KiSS4.DB.SqlQuery(this.components);
            this.grvUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersonalNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogonName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsUserAdmin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsUserBIAGAdmin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsLocked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrgUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserStandardKST = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserStandardKostenart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserStandardKTR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserWeitereKTR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblSucheNr = new KiSS4.Gui.KissLabel();
            this.edtSucheUserID = new KiSS4.Gui.KissCalcEdit();
            this.lblSuchePersNr = new KiSS4.Gui.KissLabel();
            this.edtSuchePersNr = new KiSS4.Gui.KissCalcEdit();
            this.lblSucheLogon = new KiSS4.Gui.KissLabel();
            this.edtSucheLogon = new KiSS4.Gui.KissTextEdit();
            this.lblSucheName = new KiSS4.Gui.KissLabel();
            this.edtSucheName = new KiSS4.Gui.KissTextEdit();
            this.lblSucheVorname = new KiSS4.Gui.KissLabel();
            this.edtSucheVorname = new KiSS4.Gui.KissTextEdit();
            this.lblSucheAbteilung = new KiSS4.Gui.KissLabel();
            this.edtSucheAbteilung = new KiSS4.Gui.KissTextEdit();
            this.chkSucheNurAdmin = new KiSS4.Gui.KissCheckEdit();
            this.chkSucheNurNichtGesperrt = new KiSS4.Gui.KissCheckEdit();
            this.splitter = new KiSS4.Gui.KissSplitterCollapsible();
            this.tabUser = new KiSS4.Gui.KissTabControlEx();
            this.tpgRollen = new SharpLibrary.WinControls.TabPageEx();
            this.panRollenTable = new System.Windows.Forms.TableLayoutPanel();
            this.grdZugeteilt = new KiSS4.Gui.KissGrid();
            this.qryZugeteilt = new KiSS4.DB.SqlQuery(this.components);
            this.grvZugeteilt = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBenutzergruppenZugeteilteGruppen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panRollenAvailable = new System.Windows.Forms.Panel();
            this.grdVerfuegbar = new KiSS4.Gui.KissGrid();
            this.qryVerfuegbar = new KiSS4.DB.SqlQuery(this.components);
            this.grvVerfuegbar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBenutzergruppenVerfuegbareGruppe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserGroupID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panRollenAvailableFilter = new System.Windows.Forms.Panel();
            this.lblFilter = new KiSS4.Gui.KissLabel();
            this.edtFilter = new KiSS4.Gui.KissTextEdit();
            this.panRollenAvailableAddRemove = new System.Windows.Forms.Panel();
            this.btnRemoveAll = new KiSS4.Gui.KissButton();
            this.btnAdd = new KiSS4.Gui.KissButton();
            this.btnAddAll = new KiSS4.Gui.KissButton();
            this.btnRemove = new KiSS4.Gui.KissButton();
            this.tpgBenutzerIn = new SharpLibrary.WinControls.TabPageEx();
            this.edtQualifikation = new KiSS4.Gui.KissLookUpEdit();
            this.edtFunktionsbezeichnung = new KiSS4.Gui.KissLookUpEdit();
            this.lblQualifikation = new KiSS4.Gui.KissLabel();
            this.lblFunktionsbezeichnung = new KiSS4.Gui.KissLabel();
            this.edtGrantPermGroupID = new KiSS4.Gui.KissLookUpEdit();
            this.lblGrantPermGroupID = new KiSS4.Gui.KissLabel();
            this.edtPermissionGroupID = new KiSS4.Gui.KissLookUpEdit();
            this.lblPermissionGroupID = new KiSS4.Gui.KissLabel();
            this.edtModulCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblModulCode = new KiSS4.Gui.KissLabel();
            this.edtIsMandatsTraeger = new KiSS4.Gui.KissCheckEdit();
            this.edtUserProfil = new KiSS4.Gui.KissLookUpEdit();
            this.lblUserProfile = new KiSS4.Gui.KissLabel();
            this.memBemerkungen = new KiSS4.Gui.KissMemoEdit();
            this.lblBemerkungen = new KiSS4.Gui.KissLabel();
            this.edtEmail = new KiSS4.Gui.KissTextEdit();
            this.lblEmail = new KiSS4.Gui.KissLabel();
            this.edtPhone = new KiSS4.Gui.KissTextEdit();
            this.lblTelefon = new KiSS4.Gui.KissLabel();
            this.edtLanguageCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblSprache = new KiSS4.Gui.KissLabel();
            this.edtGenderCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblGeschlecht = new KiSS4.Gui.KissLabel();
            this.chkIsLocked = new KiSS4.Gui.KissCheckEdit();
            this.chkUserIsUserBIAGAdmin = new KiSS4.Gui.KissCheckEdit();
            this.chkUserSystemadministration = new KiSS4.Gui.KissCheckEdit();
            this.edtPasswordRetype = new KiSS4.Gui.KissTextEdit();
            this.lblPWKontrolle = new KiSS4.Gui.KissLabel();
            this.edtPassword = new KiSS4.Gui.KissTextEdit();
            this.lblPasswort = new KiSS4.Gui.KissLabel();
            this.edtShortName = new KiSS4.Gui.KissTextEdit();
            this.lblKurzzeichen = new KiSS4.Gui.KissLabel();
            this.edtLogonName = new KiSS4.Gui.KissTextEdit();
            this.lblLogon = new KiSS4.Gui.KissLabel();
            this.edtFirstName = new KiSS4.Gui.KissTextEdit();
            this.lblVorname = new KiSS4.Gui.KissLabel();
            this.edtLastName = new KiSS4.Gui.KissTextEdit();
            this.lblName = new KiSS4.Gui.KissLabel();
            this.edtPersonalNr = new KiSS4.Gui.KissCalcEdit();
            this.lblPersonalNr = new KiSS4.Gui.KissLabel();
            this.edtUserID = new KiSS4.Gui.KissCalcEdit();
            this.lblUserID = new KiSS4.Gui.KissLabel();
            this.tpgBaAdresse = new SharpLibrary.WinControls.TabPageEx();
            this.edtPLZWohnsitz = new KiSS4.Common.KissPLZOrt();
            this.qryBaAdresse = new KiSS4.DB.SqlQuery(this.components);
            this.chkPostfachOhneNummer = new KiSS4.Gui.KissCheckEdit();
            this.edtXUserPhonePrivat = new KiSS4.Gui.KissTextEdit();
            this.edtXUSerPhoneMobile = new KiSS4.Gui.KissTextEdit();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.edtXUserFax = new KiSS4.Gui.KissTextEdit();
            this.lblGrunddatenFax = new KiSS4.Gui.KissLabel();
            this.edtXUserPhoneGesch = new KiSS4.Gui.KissTextEdit();
            this.lblGrunddatenTelefonMobil = new KiSS4.Gui.KissLabel();
            this.lblGrunddatenTelefon = new KiSS4.Gui.KissLabel();
            this.edtXUserEmail = new KiSS4.Gui.KissTextEdit();
            this.lblGrunddatenEmail = new KiSS4.Gui.KissLabel();
            this.lblGrunddatenAdresseLand = new KiSS4.Gui.KissLabel();
            this.lblGrunddatenAdresseBezirk = new KiSS4.Gui.KissLabel();
            this.lblGrunddatenAdressePLZOrtKt = new KiSS4.Gui.KissLabel();
            this.edtAdressePostfach = new KiSS4.Gui.KissTextEdit();
            this.lblGrunddatenAdressePostfach = new KiSS4.Gui.KissLabel();
            this.edtAdresseHausNr = new KiSS4.Gui.KissTextEdit();
            this.edtAdresseStrasse = new KiSS4.Gui.KissTextEdit();
            this.lblGrunddatenAdresseStrasseNr = new KiSS4.Gui.KissLabel();
            this.edtAdresseZusatz = new KiSS4.Gui.KissTextEdit();
            this.lblGrunddatenAdresseZusatz = new KiSS4.Gui.KissLabel();
            this.tpgBenutzerrechte = new SharpLibrary.WinControls.TabPageEx();
            this.grdRechte = new KiSS4.Gui.KissGrid();
            this.qryUserRight = new KiSS4.DB.SqlQuery(this.components);
            this.grvRechte = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRecht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRechtE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRechtM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRechtL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpgAbteilungen = new SharpLibrary.WinControls.TabPageEx();
            this.grdAbteilungen = new KiSS4.Gui.KissGrid();
            this.qryAbteilung = new KiSS4.DB.SqlQuery(this.components);
            this.grvAbteilungen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAbteilung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFunktion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMayInsert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMayUpdate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMayDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpgPersonaldaten = new SharpLibrary.WinControls.TabPageEx();
            this.edtPersonaldatenWeitereKTR = new KiSS4.Gui.KissTextEdit();
            this.lblPersonaldatenWeitereKTR = new KiSS4.Gui.KissLabel();
            this.edtKeinExport = new KiSS4.Gui.KissCheckEdit();
            this.btnGotoBDEErfassung = new KiSS4.Gui.KissButton();
            this.btnPersonaldatenWerteAendern = new KiSS4.Gui.KissButton();
            this.grpPersonaldatenAktuell = new KiSS4.Gui.KissGroupBox();
            this.lblPersonaldatenAusbezUeberstunden = new KiSS4.Gui.KissLabel();
            this.lblPersonaldatenAusbezUeberstundenLbl = new KiSS4.Gui.KissLabel();
            this.lblPersonaldatenFerienZugabenKuerzungen = new KiSS4.Gui.KissLabel();
            this.lblPersonaldatenFerienZugabenKuerzungenLbl = new KiSS4.Gui.KissLabel();
            this.lblPersonaldatenFerienanspruch = new KiSS4.Gui.KissLabel();
            this.lblPersonaldatenFerienanspruchLbl = new KiSS4.Gui.KissLabel();
            this.lblPersonaldatenSollProMonat = new KiSS4.Gui.KissLabel();
            this.lblPersonaldatenSollProMonatLbl = new KiSS4.Gui.KissLabel();
            this.lblPersonaldatenSollProTag = new KiSS4.Gui.KissLabel();
            this.lblPersonaldatenSollProTagLbl = new KiSS4.Gui.KissLabel();
            this.lblPersonaldatenPensum = new KiSS4.Gui.KissLabel();
            this.lblPersonaldatenPensumLbl = new KiSS4.Gui.KissLabel();
            this.lblPersonaldatenAktuellerMonat = new KiSS4.Gui.KissLabel();
            this.edtPersonaldatenLohntyp = new KiSS4.Gui.KissLookUpEdit();
            this.lblPersonaldatenLohntyp = new KiSS4.Gui.KissLabel();
            this.edtPersonaldatenStdKTR = new KiSS4.Gui.KissCalcEdit();
            this.lblPersonaldatenStdKTR = new KiSS4.Gui.KissLabel();
            this.edtPersonaldatenStdKA = new KiSS4.Gui.KissCalcEdit();
            this.lblPersonaldatenStdKA = new KiSS4.Gui.KissLabel();
            this.edtPersonaldatenStdKST = new KiSS4.Gui.KissTextEdit();
            this.lblPersonaldatenStdKS = new KiSS4.Gui.KissLabel();
            this.edtPersonaldatenAustritt = new KiSS4.Gui.KissDateEdit();
            this.lblPersonaldatenAustritt = new KiSS4.Gui.KissLabel();
            this.edtPersonaldatenEintritt = new KiSS4.Gui.KissDateEdit();
            this.lblPersonaldatenEintritt = new KiSS4.Gui.KissLabel();
            this.tpgStundenansatz = new SharpLibrary.WinControls.TabPageEx();
            this.edtStundenansatz20 = new KiSS4.Gui.KissMoneyEdit();
            this.qryXUserStundenansatz = new KiSS4.DB.SqlQuery(this.components);
            this.edtStundenansatz10 = new KiSS4.Gui.KissMoneyEdit();
            this.edtStundenansatz19 = new KiSS4.Gui.KissMoneyEdit();
            this.edtStundenansatz9 = new KiSS4.Gui.KissMoneyEdit();
            this.edtStundenansatz18 = new KiSS4.Gui.KissMoneyEdit();
            this.edtStundenansatz8 = new KiSS4.Gui.KissMoneyEdit();
            this.edtStundenansatz17 = new KiSS4.Gui.KissMoneyEdit();
            this.edtStundenansatz7 = new KiSS4.Gui.KissMoneyEdit();
            this.edtStundenansatz16 = new KiSS4.Gui.KissMoneyEdit();
            this.edtStundenansatz6 = new KiSS4.Gui.KissMoneyEdit();
            this.edtStundenansatz15 = new KiSS4.Gui.KissMoneyEdit();
            this.edtStundenansatz5 = new KiSS4.Gui.KissMoneyEdit();
            this.edtStundenansatz14 = new KiSS4.Gui.KissMoneyEdit();
            this.edtStundenansatz4 = new KiSS4.Gui.KissMoneyEdit();
            this.edtStundenansatz13 = new KiSS4.Gui.KissMoneyEdit();
            this.edtStundenansatz3 = new KiSS4.Gui.KissMoneyEdit();
            this.edtStundenansatz12 = new KiSS4.Gui.KissMoneyEdit();
            this.edtStundenansatz2 = new KiSS4.Gui.KissMoneyEdit();
            this.edtStundenansatz11 = new KiSS4.Gui.KissMoneyEdit();
            this.edtStundenansatz1 = new KiSS4.Gui.KissMoneyEdit();
            this.lblStundenansatz20 = new KiSS4.Gui.KissLabel();
            this.lblStundenansatz10 = new KiSS4.Gui.KissLabel();
            this.lblStundenansatz19 = new KiSS4.Gui.KissLabel();
            this.lblStundenansatz9 = new KiSS4.Gui.KissLabel();
            this.lblStundenansatz18 = new KiSS4.Gui.KissLabel();
            this.lblStundenansatz8 = new KiSS4.Gui.KissLabel();
            this.lblStundenansatz17 = new KiSS4.Gui.KissLabel();
            this.lblStundenansatz7 = new KiSS4.Gui.KissLabel();
            this.lblStundenansatz16 = new KiSS4.Gui.KissLabel();
            this.lblStundenansatz6 = new KiSS4.Gui.KissLabel();
            this.lblStundenansatz15 = new KiSS4.Gui.KissLabel();
            this.lblStundenansatz5 = new KiSS4.Gui.KissLabel();
            this.lblStundenansatz14 = new KiSS4.Gui.KissLabel();
            this.lblStundenansatz4 = new KiSS4.Gui.KissLabel();
            this.lblStundenansatz13 = new KiSS4.Gui.KissLabel();
            this.lblStundenansatz3 = new KiSS4.Gui.KissLabel();
            this.lblStundenansatz12 = new KiSS4.Gui.KissLabel();
            this.lblStundenansatz2 = new KiSS4.Gui.KissLabel();
            this.lblStundenansatz11 = new KiSS4.Gui.KissLabel();
            this.lblStundenansatz1 = new KiSS4.Gui.KissLabel();
            this.tpgSollProJahr = new SharpLibrary.WinControls.TabPageEx();
            this.grpSollProJahr = new KiSS4.Gui.KissGroupBox();
            this.lblSollProJahrDezember = new KiSS4.Gui.KissLabel();
            this.lblSollProJahrDezemberLbl = new KiSS4.Gui.KissLabel();
            this.lblSollProJahrNovember = new KiSS4.Gui.KissLabel();
            this.lblSollProJahrNovemberLbl = new KiSS4.Gui.KissLabel();
            this.lblSollProJahrOktober = new KiSS4.Gui.KissLabel();
            this.lblSollProJahrOktoberLbl = new KiSS4.Gui.KissLabel();
            this.lblSollProJahrSeptember = new KiSS4.Gui.KissLabel();
            this.lblSollProJahrSeptemberLbl = new KiSS4.Gui.KissLabel();
            this.lblSollProJahrAugust = new KiSS4.Gui.KissLabel();
            this.lblSollProJahrAugustLbl = new KiSS4.Gui.KissLabel();
            this.lblSollProJahrJuli = new KiSS4.Gui.KissLabel();
            this.lblSollProJahrJuliLbl = new KiSS4.Gui.KissLabel();
            this.lblSollProJahrJuni = new KiSS4.Gui.KissLabel();
            this.lblSollProJahrJuniLbl = new KiSS4.Gui.KissLabel();
            this.lblSollProJahrMai = new KiSS4.Gui.KissLabel();
            this.lblSollProJahrMaiLbl = new KiSS4.Gui.KissLabel();
            this.lblSollProJahrApril = new KiSS4.Gui.KissLabel();
            this.lblSollProJahrAprilLbl = new KiSS4.Gui.KissLabel();
            this.lblSollProJahrMaerz = new KiSS4.Gui.KissLabel();
            this.lblSollProJahrMaerzLbl = new KiSS4.Gui.KissLabel();
            this.lblSollProJahrFebruar = new KiSS4.Gui.KissLabel();
            this.lblSollProJahrFebruarLbl = new KiSS4.Gui.KissLabel();
            this.lblSollProJahrJanuar = new KiSS4.Gui.KissLabel();
            this.lblSollProJahrJanuarLbl = new KiSS4.Gui.KissLabel();
            this.edtSollProJahrJahr = new KiSS4.Gui.KissLookUpEdit();
            this.lblSollProJahrJahr = new KiSS4.Gui.KissLabel();
            this.tpgTexte = new SharpLibrary.WinControls.TabPageEx();
            this.lblText2 = new KiSS4.Gui.KissLabel();
            this.lblText1 = new KiSS4.Gui.KissLabel();
            this.edtText2 = new KiSS4.Gui.KissRTFEdit();
            this.edtText1 = new KiSS4.Gui.KissRTFEdit();
            this.tpgArbeitszeit = new SharpLibrary.WinControls.TabPageEx();
            this.kissLabel25 = new KiSS4.Gui.KissLabel();
            this.kissLabel24 = new KiSS4.Gui.KissLabel();
            this.edtJobPercentage = new KiSS4.Gui.KissCalcEdit();
            this.edtHoursPerYearForCaseMgmt = new KiSS4.Gui.KissCalcEdit();
            this.lblJobPercentage = new KiSS4.Gui.KissLabel();
            this.lblHoursPerYearForCaseMgmt = new KiSS4.Gui.KissLabel();
            this.qryBDEData = new KiSS4.DB.SqlQuery(this.components);
            this.qryBDESollProJahr = new KiSS4.DB.SqlQuery(this.components);
            this.chkSucheNurBIAGAdmin = new KiSS4.Gui.KissCheckEdit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchePersNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchePersNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheLogon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheLogon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheAbteilung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAbteilung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheNurAdmin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheNurNichtGesperrt.Properties)).BeginInit();
            this.tabUser.SuspendLayout();
            this.tpgRollen.SuspendLayout();
            this.panRollenTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZugeteilt)).BeginInit();
            this.panRollenAvailable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVerfuegbar)).BeginInit();
            this.panRollenAvailableFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).BeginInit();
            this.panRollenAvailableAddRemove.SuspendLayout();
            this.tpgBenutzerIn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtQualifikation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtQualifikation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFunktionsbezeichnung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFunktionsbezeichnung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblQualifikation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFunktionsbezeichnung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrantPermGroupID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrantPermGroupID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrantPermGroupID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPermissionGroupID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPermissionGroupID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPermissionGroupID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModulCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIsMandatsTraeger.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserProfil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserProfil.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memBemerkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLanguageCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLanguageCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSprache)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGenderCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGenderCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeschlecht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsLocked.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUserIsUserBIAGAdmin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUserSystemadministration.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPasswordRetype.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPWKontrolle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPasswort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtShortName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzzeichen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLogonName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLogon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFirstName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLastName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonalNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonalNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserID)).BeginInit();
            this.tpgBaAdresse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaAdresse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPostfachOhneNummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtXUserPhonePrivat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtXUSerPhoneMobile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtXUserFax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenFax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtXUserPhoneGesch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenTelefonMobil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenTelefon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtXUserEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenAdresseLand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenAdresseBezirk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenAdressePLZOrtKt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdressePostfach.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenAdressePostfach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseHausNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenAdresseStrasseNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseZusatz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenAdresseZusatz)).BeginInit();
            this.tpgBenutzerrechte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRechte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUserRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRechte)).BeginInit();
            this.tpgAbteilungen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAbteilungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAbteilung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAbteilungen)).BeginInit();
            this.tpgPersonaldaten.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonaldatenWeitereKTR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenWeitereKTR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKeinExport.Properties)).BeginInit();
            this.grpPersonaldatenAktuell.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenAusbezUeberstunden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenAusbezUeberstundenLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenFerienZugabenKuerzungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenFerienZugabenKuerzungenLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenFerienanspruch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenFerienanspruchLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenSollProMonat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenSollProMonatLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenSollProTag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenSollProTagLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenPensum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenPensumLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenAktuellerMonat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonaldatenLohntyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonaldatenLohntyp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenLohntyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonaldatenStdKTR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenStdKTR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonaldatenStdKA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenStdKA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonaldatenStdKST.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenStdKS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonaldatenAustritt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenAustritt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonaldatenEintritt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenEintritt)).BeginInit();
            this.tpgStundenansatz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz20.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXUserStundenansatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz10.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz19.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz9.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz18.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz8.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz17.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz7.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz16.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz6.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz15.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz14.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz13.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz12.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz11.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz1)).BeginInit();
            this.tpgSollProJahr.SuspendLayout();
            this.grpSollProJahr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrDezember)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrDezemberLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrNovember)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrNovemberLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrOktober)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrOktoberLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrSeptember)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrSeptemberLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrAugust)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrAugustLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrJuli)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrJuliLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrJuni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrJuniLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrMai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrMaiLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrApril)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrAprilLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrMaerz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrMaerzLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrFebruar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrFebruarLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrJanuar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrJanuarLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollProJahrJahr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollProJahrJahr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrJahr)).BeginInit();
            this.tpgTexte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblText2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblText1)).BeginInit();
            this.tpgArbeitszeit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJobPercentage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHoursPerYearForCaseMgmt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJobPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHoursPerYearForCaseMgmt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBDEData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBDESollProJahr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheNurBIAGAdmin.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.ForeColor = System.Drawing.Color.Black;
            this.searchTitle.Size = new System.Drawing.Size(826, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.ForeColor = System.Drawing.SystemColors.Control;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(850, 201);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdUser);
            this.tpgListe.Size = new System.Drawing.Size(838, 163);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.chkSucheNurNichtGesperrt);
            this.tpgSuchen.Controls.Add(this.chkSucheNurBIAGAdmin);
            this.tpgSuchen.Controls.Add(this.chkSucheNurAdmin);
            this.tpgSuchen.Controls.Add(this.edtSucheAbteilung);
            this.tpgSuchen.Controls.Add(this.lblSucheAbteilung);
            this.tpgSuchen.Controls.Add(this.edtSucheVorname);
            this.tpgSuchen.Controls.Add(this.lblSucheVorname);
            this.tpgSuchen.Controls.Add(this.edtSucheName);
            this.tpgSuchen.Controls.Add(this.lblSucheName);
            this.tpgSuchen.Controls.Add(this.edtSucheLogon);
            this.tpgSuchen.Controls.Add(this.lblSucheLogon);
            this.tpgSuchen.Controls.Add(this.edtSuchePersNr);
            this.tpgSuchen.Controls.Add(this.lblSuchePersNr);
            this.tpgSuchen.Controls.Add(this.edtSucheUserID);
            this.tpgSuchen.Controls.Add(this.lblSucheNr);
            this.tpgSuchen.Size = new System.Drawing.Size(838, 163);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheUserID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSuchePersNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSuchePersNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheLogon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheLogon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheVorname, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheVorname, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheAbteilung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheAbteilung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkSucheNurAdmin, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkSucheNurBIAGAdmin, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkSucheNurNichtGesperrt, 0);
            // 
            // grdUser
            // 
            this.grdUser.DataSource = this.qryUser;
            this.grdUser.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdUser.EmbeddedNavigator.Name = "";
            this.grdUser.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdUser.Location = new System.Drawing.Point(0, 0);
            this.grdUser.MainView = this.grvUser;
            this.grdUser.Name = "grdUser";
            this.grdUser.Size = new System.Drawing.Size(838, 163);
            this.grdUser.TabIndex = 0;
            this.grdUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvUser});
            // 
            // qryUser
            // 
            this.qryUser.AutoApplyUserRights = false;
            this.qryUser.HostControl = this;
            this.qryUser.TableName = "XUser";
            this.qryUser.AfterFill += new System.EventHandler(this.qryUser_AfterFill);
            this.qryUser.AfterInsert += new System.EventHandler(this.qryUser_AfterInsert);
            this.qryUser.BeforePost += new System.EventHandler(this.qryUser_BeforePost);
            this.qryUser.AfterPost += new System.EventHandler(this.qryUser_AfterPost);
            this.qryUser.BeforeDelete += new System.EventHandler(this.qryUser_BeforeDelete);
            this.qryUser.PositionChanging += new System.EventHandler(this.qryUser_PositionChanging);
            this.qryUser.PositionChanged += new System.EventHandler(this.qryUser_PositionChanged);
            // 
            // grvUser
            // 
            this.grvUser.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvUser.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUser.Appearance.Empty.Options.UseBackColor = true;
            this.grvUser.Appearance.Empty.Options.UseFont = true;
            this.grvUser.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUser.Appearance.EvenRow.Options.UseFont = true;
            this.grvUser.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvUser.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUser.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvUser.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvUser.Appearance.FocusedCell.Options.UseFont = true;
            this.grvUser.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvUser.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvUser.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUser.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvUser.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvUser.Appearance.FocusedRow.Options.UseFont = true;
            this.grvUser.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvUser.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvUser.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvUser.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvUser.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvUser.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvUser.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvUser.Appearance.GroupRow.Options.UseFont = true;
            this.grvUser.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvUser.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvUser.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvUser.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvUser.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvUser.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvUser.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvUser.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvUser.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUser.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvUser.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvUser.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvUser.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvUser.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvUser.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvUser.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUser.Appearance.OddRow.Options.UseFont = true;
            this.grvUser.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvUser.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUser.Appearance.Row.Options.UseBackColor = true;
            this.grvUser.Appearance.Row.Options.UseFont = true;
            this.grvUser.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUser.Appearance.SelectedRow.Options.UseFont = true;
            this.grvUser.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvUser.Appearance.VertLine.Options.UseBackColor = true;
            this.grvUser.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUserID,
            this.colPersonalNr,
            this.colLogonName,
            this.colLastName,
            this.colFirstName,
            this.colIsUserAdmin,
            this.colIsUserBIAGAdmin,
            this.colIsLocked,
            this.colOrgUnit,
            this.colUserStandardKST,
            this.colUserStandardKostenart,
            this.colUserStandardKTR,
            this.colUserWeitereKTR});
            this.grvUser.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvUser.GridControl = this.grdUser;
            this.grvUser.Name = "grvUser";
            this.grvUser.OptionsBehavior.Editable = false;
            this.grvUser.OptionsCustomization.AllowFilter = false;
            this.grvUser.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvUser.OptionsNavigation.AutoFocusNewRow = true;
            this.grvUser.OptionsNavigation.UseTabKey = false;
            this.grvUser.OptionsView.ColumnAutoWidth = false;
            this.grvUser.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvUser.OptionsView.ShowGroupPanel = false;
            this.grvUser.OptionsView.ShowIndicator = false;
            // 
            // colUserID
            // 
            this.colUserID.Caption = "Nr.";
            this.colUserID.Name = "colUserID";
            this.colUserID.Visible = true;
            this.colUserID.VisibleIndex = 0;
            this.colUserID.Width = 60;
            // 
            // colPersonalNr
            // 
            this.colPersonalNr.Caption = "Pers-Nr.";
            this.colPersonalNr.Name = "colPersonalNr";
            this.colPersonalNr.Visible = true;
            this.colPersonalNr.VisibleIndex = 1;
            this.colPersonalNr.Width = 60;
            // 
            // colLogonName
            // 
            this.colLogonName.Caption = "Logon";
            this.colLogonName.Name = "colLogonName";
            this.colLogonName.Visible = true;
            this.colLogonName.VisibleIndex = 2;
            this.colLogonName.Width = 150;
            // 
            // colLastName
            // 
            this.colLastName.Caption = "Name";
            this.colLastName.Name = "colLastName";
            this.colLastName.Visible = true;
            this.colLastName.VisibleIndex = 3;
            this.colLastName.Width = 150;
            // 
            // colFirstName
            // 
            this.colFirstName.Caption = "Vorname";
            this.colFirstName.Name = "colFirstName";
            this.colFirstName.Visible = true;
            this.colFirstName.VisibleIndex = 4;
            this.colFirstName.Width = 150;
            // 
            // colIsUserAdmin
            // 
            this.colIsUserAdmin.Caption = "Admin";
            this.colIsUserAdmin.Name = "colIsUserAdmin";
            this.colIsUserAdmin.Visible = true;
            this.colIsUserAdmin.VisibleIndex = 6;
            this.colIsUserAdmin.Width = 50;
            // 
            // colIsUserBIAGAdmin
            // 
            this.colIsUserBIAGAdmin.Caption = "BIAG Admin";
            this.colIsUserBIAGAdmin.Name = "colIsUserBIAGAdmin";
            this.colIsUserBIAGAdmin.Visible = true;
            this.colIsUserBIAGAdmin.VisibleIndex = 7;
            // 
            // colIsLocked
            // 
            this.colIsLocked.Caption = "Gesp.";
            this.colIsLocked.Name = "colIsLocked";
            this.colIsLocked.Visible = true;
            this.colIsLocked.VisibleIndex = 5;
            this.colIsLocked.Width = 50;
            // 
            // colOrgUnit
            // 
            this.colOrgUnit.Caption = "Abteilung";
            this.colOrgUnit.Name = "colOrgUnit";
            this.colOrgUnit.Visible = true;
            this.colOrgUnit.VisibleIndex = 8;
            this.colOrgUnit.Width = 200;
            // 
            // colUserStandardKST
            // 
            this.colUserStandardKST.Caption = "Standard-Kostenstelle";
            this.colUserStandardKST.Name = "colUserStandardKST";
            this.colUserStandardKST.Visible = true;
            this.colUserStandardKST.VisibleIndex = 9;
            this.colUserStandardKST.Width = 150;
            // 
            // colUserStandardKostenart
            // 
            this.colUserStandardKostenart.Caption = "Standard-Kostenart";
            this.colUserStandardKostenart.Name = "colUserStandardKostenart";
            this.colUserStandardKostenart.Visible = true;
            this.colUserStandardKostenart.VisibleIndex = 10;
            this.colUserStandardKostenart.Width = 150;
            // 
            // colUserStandardKTR
            // 
            this.colUserStandardKTR.Caption = "Standard-Kostenträger";
            this.colUserStandardKTR.Name = "colUserStandardKTR";
            this.colUserStandardKTR.Visible = true;
            this.colUserStandardKTR.VisibleIndex = 11;
            this.colUserStandardKTR.Width = 150;
            // 
            // colUserWeitereKTR
            // 
            this.colUserWeitereKTR.Caption = "weitere Kostenträger";
            this.colUserWeitereKTR.Name = "colUserWeitereKTR";
            this.colUserWeitereKTR.Visible = true;
            this.colUserWeitereKTR.VisibleIndex = 12;
            this.colUserWeitereKTR.Width = 150;
            // 
            // lblSucheNr
            // 
            this.lblSucheNr.ForeColor = System.Drawing.Color.Black;
            this.lblSucheNr.Location = new System.Drawing.Point(30, 40);
            this.lblSucheNr.Name = "lblSucheNr";
            this.lblSucheNr.Size = new System.Drawing.Size(84, 24);
            this.lblSucheNr.TabIndex = 0;
            this.lblSucheNr.Text = "Nr.";
            this.lblSucheNr.UseCompatibleTextRendering = true;
            // 
            // edtSucheUserID
            // 
            this.edtSucheUserID.Location = new System.Drawing.Point(120, 40);
            this.edtSucheUserID.Name = "edtSucheUserID";
            this.edtSucheUserID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheUserID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheUserID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheUserID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheUserID.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtSucheUserID.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheUserID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheUserID.Properties.Appearance.Options.UseFont = true;
            this.edtSucheUserID.Properties.Appearance.Options.UseForeColor = true;
            this.edtSucheUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheUserID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheUserID.Size = new System.Drawing.Size(112, 24);
            this.edtSucheUserID.TabIndex = 1;
            // 
            // lblSuchePersNr
            // 
            this.lblSuchePersNr.ForeColor = System.Drawing.Color.Black;
            this.lblSuchePersNr.Location = new System.Drawing.Point(30, 63);
            this.lblSuchePersNr.Name = "lblSuchePersNr";
            this.lblSuchePersNr.Size = new System.Drawing.Size(84, 24);
            this.lblSuchePersNr.TabIndex = 2;
            this.lblSuchePersNr.Text = "Personal-Nr.";
            this.lblSuchePersNr.UseCompatibleTextRendering = true;
            // 
            // edtSuchePersNr
            // 
            this.edtSuchePersNr.Location = new System.Drawing.Point(120, 63);
            this.edtSuchePersNr.Name = "edtSuchePersNr";
            this.edtSuchePersNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSuchePersNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSuchePersNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSuchePersNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSuchePersNr.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtSuchePersNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSuchePersNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSuchePersNr.Properties.Appearance.Options.UseFont = true;
            this.edtSuchePersNr.Properties.Appearance.Options.UseForeColor = true;
            this.edtSuchePersNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSuchePersNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSuchePersNr.Size = new System.Drawing.Size(112, 24);
            this.edtSuchePersNr.TabIndex = 3;
            // 
            // lblSucheLogon
            // 
            this.lblSucheLogon.ForeColor = System.Drawing.Color.Black;
            this.lblSucheLogon.Location = new System.Drawing.Point(30, 93);
            this.lblSucheLogon.Name = "lblSucheLogon";
            this.lblSucheLogon.Size = new System.Drawing.Size(84, 24);
            this.lblSucheLogon.TabIndex = 4;
            this.lblSucheLogon.Text = "Logon";
            this.lblSucheLogon.UseCompatibleTextRendering = true;
            // 
            // edtSucheLogon
            // 
            this.edtSucheLogon.Location = new System.Drawing.Point(120, 93);
            this.edtSucheLogon.Name = "edtSucheLogon";
            this.edtSucheLogon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheLogon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheLogon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheLogon.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtSucheLogon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheLogon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheLogon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheLogon.Properties.Appearance.Options.UseForeColor = true;
            this.edtSucheLogon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheLogon.Size = new System.Drawing.Size(112, 24);
            this.edtSucheLogon.TabIndex = 5;
            // 
            // lblSucheName
            // 
            this.lblSucheName.ForeColor = System.Drawing.Color.Black;
            this.lblSucheName.Location = new System.Drawing.Point(30, 123);
            this.lblSucheName.Name = "lblSucheName";
            this.lblSucheName.Size = new System.Drawing.Size(84, 24);
            this.lblSucheName.TabIndex = 6;
            this.lblSucheName.Text = "Name";
            this.lblSucheName.UseCompatibleTextRendering = true;
            // 
            // edtSucheName
            // 
            this.edtSucheName.Location = new System.Drawing.Point(120, 123);
            this.edtSucheName.Name = "edtSucheName";
            this.edtSucheName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheName.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtSucheName.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheName.Properties.Appearance.Options.UseFont = true;
            this.edtSucheName.Properties.Appearance.Options.UseForeColor = true;
            this.edtSucheName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheName.Size = new System.Drawing.Size(173, 24);
            this.edtSucheName.TabIndex = 7;
            // 
            // lblSucheVorname
            // 
            this.lblSucheVorname.ForeColor = System.Drawing.Color.Black;
            this.lblSucheVorname.Location = new System.Drawing.Point(30, 146);
            this.lblSucheVorname.Name = "lblSucheVorname";
            this.lblSucheVorname.Size = new System.Drawing.Size(84, 24);
            this.lblSucheVorname.TabIndex = 8;
            this.lblSucheVorname.Text = "Vorname";
            this.lblSucheVorname.UseCompatibleTextRendering = true;
            // 
            // edtSucheVorname
            // 
            this.edtSucheVorname.Location = new System.Drawing.Point(120, 146);
            this.edtSucheVorname.Name = "edtSucheVorname";
            this.edtSucheVorname.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheVorname.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtSucheVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheVorname.Properties.Appearance.Options.UseFont = true;
            this.edtSucheVorname.Properties.Appearance.Options.UseForeColor = true;
            this.edtSucheVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheVorname.Size = new System.Drawing.Size(173, 24);
            this.edtSucheVorname.TabIndex = 9;
            // 
            // lblSucheAbteilung
            // 
            this.lblSucheAbteilung.ForeColor = System.Drawing.Color.Black;
            this.lblSucheAbteilung.Location = new System.Drawing.Point(30, 176);
            this.lblSucheAbteilung.Name = "lblSucheAbteilung";
            this.lblSucheAbteilung.Size = new System.Drawing.Size(84, 24);
            this.lblSucheAbteilung.TabIndex = 11;
            this.lblSucheAbteilung.Text = "Abteilung";
            this.lblSucheAbteilung.UseCompatibleTextRendering = true;
            // 
            // edtSucheAbteilung
            // 
            this.edtSucheAbteilung.Location = new System.Drawing.Point(120, 176);
            this.edtSucheAbteilung.Name = "edtSucheAbteilung";
            this.edtSucheAbteilung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheAbteilung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheAbteilung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheAbteilung.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtSucheAbteilung.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheAbteilung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheAbteilung.Properties.Appearance.Options.UseFont = true;
            this.edtSucheAbteilung.Properties.Appearance.Options.UseForeColor = true;
            this.edtSucheAbteilung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheAbteilung.Size = new System.Drawing.Size(173, 24);
            this.edtSucheAbteilung.TabIndex = 12;
            // 
            // chkSucheNurAdmin
            // 
            this.chkSucheNurAdmin.EditValue = false;
            this.chkSucheNurAdmin.Location = new System.Drawing.Point(321, 150);
            this.chkSucheNurAdmin.Name = "chkSucheNurAdmin";
            this.chkSucheNurAdmin.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkSucheNurAdmin.Properties.Appearance.Options.UseBackColor = true;
            this.chkSucheNurAdmin.Properties.Caption = "Nur Administratoren";
            this.chkSucheNurAdmin.Size = new System.Drawing.Size(173, 19);
            this.chkSucheNurAdmin.TabIndex = 11;
            // 
            // chkSucheNurNichtGesperrt
            // 
            this.chkSucheNurNichtGesperrt.EditValue = false;
            this.chkSucheNurNichtGesperrt.Location = new System.Drawing.Point(321, 125);
            this.chkSucheNurNichtGesperrt.Name = "chkSucheNurNichtGesperrt";
            this.chkSucheNurNichtGesperrt.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkSucheNurNichtGesperrt.Properties.Appearance.Options.UseBackColor = true;
            this.chkSucheNurNichtGesperrt.Properties.Caption = "Nur aktive Benutzer";
            this.chkSucheNurNichtGesperrt.Size = new System.Drawing.Size(173, 19);
            this.chkSucheNurNichtGesperrt.TabIndex = 10;
            // 
            // splitter
            // 
            this.splitter.AnimationDelay = 20;
            this.splitter.AnimationStep = 20;
            this.splitter.BorderStyle3D = System.Windows.Forms.Border3DStyle.Etched;
            this.splitter.ControlToHide = this.tabUser;
            this.splitter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter.ExpandParentForm = false;
            this.splitter.Location = new System.Drawing.Point(0, 201);
            this.splitter.Name = "splitter";
            this.splitter.TabIndex = 0;
            this.splitter.TabStop = false;
            this.splitter.UseAnimations = false;
            this.splitter.VisualStyle = KiSS4.Gui.VisualStyles.Mozilla;
            // 
            // tabUser
            // 
            this.tabUser.Controls.Add(this.tpgRollen);
            this.tabUser.Controls.Add(this.tpgBenutzerIn);
            this.tabUser.Controls.Add(this.tpgBaAdresse);
            this.tabUser.Controls.Add(this.tpgBenutzerrechte);
            this.tabUser.Controls.Add(this.tpgAbteilungen);
            this.tabUser.Controls.Add(this.tpgPersonaldaten);
            this.tabUser.Controls.Add(this.tpgStundenansatz);
            this.tabUser.Controls.Add(this.tpgSollProJahr);
            this.tabUser.Controls.Add(this.tpgTexte);
            this.tabUser.Controls.Add(this.tpgArbeitszeit);
            this.tabUser.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabUser.Location = new System.Drawing.Point(0, 209);
            this.tabUser.Name = "tabUser";
            this.tabUser.SelectedTabIndex = 5;
            this.tabUser.ShowFixedWidthTooltip = true;
            this.tabUser.Size = new System.Drawing.Size(850, 341);
            this.tabUser.TabIndex = 2;
            this.tabUser.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgBenutzerIn,
            this.tpgBaAdresse,
            this.tpgRollen,
            this.tpgBenutzerrechte,
            this.tpgAbteilungen,
            this.tpgPersonaldaten,
            this.tpgStundenansatz,
            this.tpgSollProJahr,
            this.tpgTexte,
            this.tpgArbeitszeit});
            this.tabUser.TabsLineColor = System.Drawing.Color.Black;
            this.tabUser.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabUser.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabUser_SelectedTabChanged);
            // 
            // tpgRollen
            // 
            this.tpgRollen.Controls.Add(this.panRollenTable);
            this.tpgRollen.Location = new System.Drawing.Point(6, 6);
            this.tpgRollen.Name = "tpgRollen";
            this.tpgRollen.Padding = new System.Windows.Forms.Padding(1);
            this.tpgRollen.Size = new System.Drawing.Size(838, 303);
            this.tpgRollen.TabIndex = 1;
            this.tpgRollen.Title = "Rollen";
            // 
            // panRollenTable
            // 
            this.panRollenTable.ColumnCount = 3;
            this.panRollenTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panRollenTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.panRollenTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panRollenTable.Controls.Add(this.grdZugeteilt, 2, 0);
            this.panRollenTable.Controls.Add(this.panRollenAvailable, 0, 0);
            this.panRollenTable.Controls.Add(this.panRollenAvailableAddRemove, 1, 0);
            this.panRollenTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panRollenTable.Location = new System.Drawing.Point(1, 1);
            this.panRollenTable.Name = "panRollenTable";
            this.panRollenTable.RowCount = 1;
            this.panRollenTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panRollenTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panRollenTable.Size = new System.Drawing.Size(836, 301);
            this.panRollenTable.TabIndex = 0;
            this.panRollenTable.TabStop = true;
            // 
            // grdZugeteilt
            // 
            this.grdZugeteilt.DataSource = this.qryZugeteilt;
            this.grdZugeteilt.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdZugeteilt.EmbeddedNavigator.Name = "";
            this.grdZugeteilt.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdZugeteilt.Location = new System.Drawing.Point(452, 4);
            this.grdZugeteilt.MainView = this.grvZugeteilt;
            this.grdZugeteilt.Margin = new System.Windows.Forms.Padding(4);
            this.grdZugeteilt.Name = "grdZugeteilt";
            this.grdZugeteilt.Size = new System.Drawing.Size(380, 293);
            this.grdZugeteilt.TabIndex = 3;
            this.grdZugeteilt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvZugeteilt});
            this.grdZugeteilt.DoubleClick += new System.EventHandler(this.grdZugeteilt_DoubleClick);
            // 
            // qryZugeteilt
            // 
            this.qryZugeteilt.AutoApplyUserRights = false;
            this.qryZugeteilt.HostControl = this;
            this.qryZugeteilt.TableName = "XUser_UserGroup";
            // 
            // grvZugeteilt
            // 
            this.grvZugeteilt.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvZugeteilt.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.Empty.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.Empty.Options.UseFont = true;
            this.grvZugeteilt.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.EvenRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvZugeteilt.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvZugeteilt.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.FocusedCell.Options.UseFont = true;
            this.grvZugeteilt.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvZugeteilt.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvZugeteilt.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvZugeteilt.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.FocusedRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvZugeteilt.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZugeteilt.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZugeteilt.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvZugeteilt.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZugeteilt.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.GroupRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvZugeteilt.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvZugeteilt.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvZugeteilt.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvZugeteilt.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvZugeteilt.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvZugeteilt.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvZugeteilt.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZugeteilt.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvZugeteilt.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvZugeteilt.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.OddRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvZugeteilt.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.Row.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.Row.Options.UseFont = true;
            this.grvZugeteilt.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.SelectedRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvZugeteilt.Appearance.VertLine.Options.UseBackColor = true;
            this.grvZugeteilt.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvZugeteilt.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBenutzergruppenZugeteilteGruppen});
            this.grvZugeteilt.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvZugeteilt.GridControl = this.grdZugeteilt;
            this.grvZugeteilt.Name = "grvZugeteilt";
            this.grvZugeteilt.OptionsBehavior.Editable = false;
            this.grvZugeteilt.OptionsCustomization.AllowFilter = false;
            this.grvZugeteilt.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvZugeteilt.OptionsNavigation.AutoFocusNewRow = true;
            this.grvZugeteilt.OptionsNavigation.UseTabKey = false;
            this.grvZugeteilt.OptionsView.ColumnAutoWidth = false;
            this.grvZugeteilt.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvZugeteilt.OptionsView.ShowGroupPanel = false;
            this.grvZugeteilt.OptionsView.ShowIndicator = false;
            // 
            // colBenutzergruppenZugeteilteGruppen
            // 
            this.colBenutzergruppenZugeteilteGruppen.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBenutzergruppenZugeteilteGruppen.AppearanceCell.Options.UseBackColor = true;
            this.colBenutzergruppenZugeteilteGruppen.Caption = "Zugeteilte Rollen";
            this.colBenutzergruppenZugeteilteGruppen.FieldName = "UserGroupName";
            this.colBenutzergruppenZugeteilteGruppen.Name = "colBenutzergruppenZugeteilteGruppen";
            this.colBenutzergruppenZugeteilteGruppen.OptionsColumn.AllowEdit = false;
            this.colBenutzergruppenZugeteilteGruppen.Visible = true;
            this.colBenutzergruppenZugeteilteGruppen.VisibleIndex = 0;
            this.colBenutzergruppenZugeteilteGruppen.Width = 285;
            // 
            // panRollenAvailable
            // 
            this.panRollenAvailable.Controls.Add(this.grdVerfuegbar);
            this.panRollenAvailable.Controls.Add(this.panRollenAvailableFilter);
            this.panRollenAvailable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panRollenAvailable.Location = new System.Drawing.Point(3, 3);
            this.panRollenAvailable.Name = "panRollenAvailable";
            this.panRollenAvailable.Size = new System.Drawing.Size(382, 295);
            this.panRollenAvailable.TabIndex = 1;
            this.panRollenAvailable.TabStop = true;
            // 
            // grdVerfuegbar
            // 
            this.grdVerfuegbar.DataSource = this.qryVerfuegbar;
            this.grdVerfuegbar.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdVerfuegbar.EmbeddedNavigator.Name = "";
            this.grdVerfuegbar.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdVerfuegbar.Location = new System.Drawing.Point(0, 0);
            this.grdVerfuegbar.MainView = this.grvVerfuegbar;
            this.grdVerfuegbar.Margin = new System.Windows.Forms.Padding(4);
            this.grdVerfuegbar.Name = "grdVerfuegbar";
            this.grdVerfuegbar.Size = new System.Drawing.Size(382, 261);
            this.grdVerfuegbar.TabIndex = 0;
            this.grdVerfuegbar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVerfuegbar});
            this.grdVerfuegbar.DoubleClick += new System.EventHandler(this.grdVerfuegbar_DoubleClick);
            // 
            // qryVerfuegbar
            // 
            this.qryVerfuegbar.AutoApplyUserRights = false;
            this.qryVerfuegbar.HostControl = this;
            // 
            // grvVerfuegbar
            // 
            this.grvVerfuegbar.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvVerfuegbar.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.Empty.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.Empty.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.EvenRow.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVerfuegbar.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvVerfuegbar.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.FocusedCell.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvVerfuegbar.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVerfuegbar.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvVerfuegbar.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.FocusedRow.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvVerfuegbar.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVerfuegbar.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVerfuegbar.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVerfuegbar.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVerfuegbar.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.GroupRow.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvVerfuegbar.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvVerfuegbar.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvVerfuegbar.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVerfuegbar.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvVerfuegbar.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvVerfuegbar.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVerfuegbar.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvVerfuegbar.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvVerfuegbar.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.OddRow.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvVerfuegbar.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.Row.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.Row.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.SelectedRow.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvVerfuegbar.Appearance.VertLine.Options.UseBackColor = true;
            this.grvVerfuegbar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvVerfuegbar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBenutzergruppenVerfuegbareGruppe,
            this.colUserGroupID});
            this.grvVerfuegbar.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvVerfuegbar.GridControl = this.grdVerfuegbar;
            this.grvVerfuegbar.Name = "grvVerfuegbar";
            this.grvVerfuegbar.OptionsBehavior.Editable = false;
            this.grvVerfuegbar.OptionsCustomization.AllowFilter = false;
            this.grvVerfuegbar.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvVerfuegbar.OptionsNavigation.AutoFocusNewRow = true;
            this.grvVerfuegbar.OptionsNavigation.UseTabKey = false;
            this.grvVerfuegbar.OptionsSelection.MultiSelect = true;
            this.grvVerfuegbar.OptionsView.ColumnAutoWidth = false;
            this.grvVerfuegbar.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvVerfuegbar.OptionsView.ShowGroupPanel = false;
            this.grvVerfuegbar.OptionsView.ShowIndicator = false;
            // 
            // colBenutzergruppenVerfuegbareGruppe
            // 
            this.colBenutzergruppenVerfuegbareGruppe.Caption = "Verfügbare Rollen";
            this.colBenutzergruppenVerfuegbareGruppe.FieldName = "UserGroupName";
            this.colBenutzergruppenVerfuegbareGruppe.Name = "colBenutzergruppenVerfuegbareGruppe";
            this.colBenutzergruppenVerfuegbareGruppe.Visible = true;
            this.colBenutzergruppenVerfuegbareGruppe.VisibleIndex = 0;
            this.colBenutzergruppenVerfuegbareGruppe.Width = 285;
            // 
            // colUserGroupID
            // 
            this.colUserGroupID.Caption = "-";
            this.colUserGroupID.FieldName = "UserGroupID";
            this.colUserGroupID.Name = "colUserGroupID";
            // 
            // panRollenAvailableFilter
            // 
            this.panRollenAvailableFilter.Controls.Add(this.lblFilter);
            this.panRollenAvailableFilter.Controls.Add(this.edtFilter);
            this.panRollenAvailableFilter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panRollenAvailableFilter.Location = new System.Drawing.Point(0, 261);
            this.panRollenAvailableFilter.Name = "panRollenAvailableFilter";
            this.panRollenAvailableFilter.Size = new System.Drawing.Size(382, 34);
            this.panRollenAvailableFilter.TabIndex = 1;
            this.panRollenAvailableFilter.TabStop = true;
            // 
            // lblFilter
            // 
            this.lblFilter.Location = new System.Drawing.Point(3, 5);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(54, 24);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "Filter";
            this.lblFilter.UseCompatibleTextRendering = true;
            // 
            // edtFilter
            // 
            this.edtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFilter.Location = new System.Drawing.Point(63, 5);
            this.edtFilter.Name = "edtFilter";
            this.edtFilter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFilter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFilter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFilter.Properties.Appearance.Options.UseBackColor = true;
            this.edtFilter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFilter.Properties.Appearance.Options.UseFont = true;
            this.edtFilter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFilter.Size = new System.Drawing.Size(319, 24);
            this.edtFilter.TabIndex = 1;
            this.edtFilter.EditValueChanged += new System.EventHandler(this.edtFilter_EditValueChanged);
            // 
            // panRollenAvailableAddRemove
            // 
            this.panRollenAvailableAddRemove.Controls.Add(this.btnRemoveAll);
            this.panRollenAvailableAddRemove.Controls.Add(this.btnAdd);
            this.panRollenAvailableAddRemove.Controls.Add(this.btnAddAll);
            this.panRollenAvailableAddRemove.Controls.Add(this.btnRemove);
            this.panRollenAvailableAddRemove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panRollenAvailableAddRemove.Location = new System.Drawing.Point(388, 0);
            this.panRollenAvailableAddRemove.Margin = new System.Windows.Forms.Padding(0);
            this.panRollenAvailableAddRemove.Name = "panRollenAvailableAddRemove";
            this.panRollenAvailableAddRemove.Size = new System.Drawing.Size(60, 301);
            this.panRollenAvailableAddRemove.TabIndex = 2;
            this.panRollenAvailableAddRemove.TabStop = true;
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAll.IconID = 12;
            this.btnRemoveAll.Location = new System.Drawing.Point(16, 120);
            this.btnRemoveAll.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(28, 24);
            this.btnRemoveAll.TabIndex = 3;
            this.btnRemoveAll.UseCompatibleTextRendering = true;
            this.btnRemoveAll.UseVisualStyleBackColor = false;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.IconID = 13;
            this.btnAdd.Location = new System.Drawing.Point(16, 30);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(10, 30, 10, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(28, 24);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.UseCompatibleTextRendering = true;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAddAll
            // 
            this.btnAddAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAll.IconID = 14;
            this.btnAddAll.Location = new System.Drawing.Point(16, 90);
            this.btnAddAll.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(28, 24);
            this.btnAddAll.TabIndex = 2;
            this.btnAddAll.UseCompatibleTextRendering = true;
            this.btnAddAll.UseVisualStyleBackColor = false;
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.IconID = 11;
            this.btnRemove.Location = new System.Drawing.Point(16, 60);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(28, 24);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.UseCompatibleTextRendering = true;
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // tpgBenutzerIn
            // 
            this.tpgBenutzerIn.AutoScroll = true;
            this.tpgBenutzerIn.AutoScrollMinSize = new System.Drawing.Size(738, 303);
            this.tpgBenutzerIn.Controls.Add(this.edtQualifikation);
            this.tpgBenutzerIn.Controls.Add(this.edtFunktionsbezeichnung);
            this.tpgBenutzerIn.Controls.Add(this.lblQualifikation);
            this.tpgBenutzerIn.Controls.Add(this.lblFunktionsbezeichnung);
            this.tpgBenutzerIn.Controls.Add(this.edtGrantPermGroupID);
            this.tpgBenutzerIn.Controls.Add(this.lblGrantPermGroupID);
            this.tpgBenutzerIn.Controls.Add(this.edtPermissionGroupID);
            this.tpgBenutzerIn.Controls.Add(this.lblPermissionGroupID);
            this.tpgBenutzerIn.Controls.Add(this.edtModulCode);
            this.tpgBenutzerIn.Controls.Add(this.lblModulCode);
            this.tpgBenutzerIn.Controls.Add(this.edtIsMandatsTraeger);
            this.tpgBenutzerIn.Controls.Add(this.edtUserProfil);
            this.tpgBenutzerIn.Controls.Add(this.lblUserProfile);
            this.tpgBenutzerIn.Controls.Add(this.memBemerkungen);
            this.tpgBenutzerIn.Controls.Add(this.lblBemerkungen);
            this.tpgBenutzerIn.Controls.Add(this.edtEmail);
            this.tpgBenutzerIn.Controls.Add(this.lblEmail);
            this.tpgBenutzerIn.Controls.Add(this.edtPhone);
            this.tpgBenutzerIn.Controls.Add(this.lblTelefon);
            this.tpgBenutzerIn.Controls.Add(this.edtLanguageCode);
            this.tpgBenutzerIn.Controls.Add(this.lblSprache);
            this.tpgBenutzerIn.Controls.Add(this.edtGenderCode);
            this.tpgBenutzerIn.Controls.Add(this.lblGeschlecht);
            this.tpgBenutzerIn.Controls.Add(this.chkIsLocked);
            this.tpgBenutzerIn.Controls.Add(this.chkUserIsUserBIAGAdmin);
            this.tpgBenutzerIn.Controls.Add(this.chkUserSystemadministration);
            this.tpgBenutzerIn.Controls.Add(this.edtPasswordRetype);
            this.tpgBenutzerIn.Controls.Add(this.lblPWKontrolle);
            this.tpgBenutzerIn.Controls.Add(this.edtPassword);
            this.tpgBenutzerIn.Controls.Add(this.lblPasswort);
            this.tpgBenutzerIn.Controls.Add(this.edtShortName);
            this.tpgBenutzerIn.Controls.Add(this.lblKurzzeichen);
            this.tpgBenutzerIn.Controls.Add(this.edtLogonName);
            this.tpgBenutzerIn.Controls.Add(this.lblLogon);
            this.tpgBenutzerIn.Controls.Add(this.edtFirstName);
            this.tpgBenutzerIn.Controls.Add(this.lblVorname);
            this.tpgBenutzerIn.Controls.Add(this.edtLastName);
            this.tpgBenutzerIn.Controls.Add(this.lblName);
            this.tpgBenutzerIn.Controls.Add(this.edtPersonalNr);
            this.tpgBenutzerIn.Controls.Add(this.lblPersonalNr);
            this.tpgBenutzerIn.Controls.Add(this.edtUserID);
            this.tpgBenutzerIn.Controls.Add(this.lblUserID);
            this.tpgBenutzerIn.Location = new System.Drawing.Point(6, 6);
            this.tpgBenutzerIn.Name = "tpgBenutzerIn";
            this.tpgBenutzerIn.Size = new System.Drawing.Size(838, 303);
            this.tpgBenutzerIn.TabIndex = 0;
            this.tpgBenutzerIn.Title = "Benutzer/in";
            // 
            // edtQualifikation
            // 
            this.edtQualifikation.DataSource = this.qryUser;
            this.edtQualifikation.Location = new System.Drawing.Point(91, 276);
            this.edtQualifikation.LOVName = "QualificationTitle";
            this.edtQualifikation.LOVOrderByColumn = KiSS4.DB.DBUtil.LOVOrderByColumnEnum.Text;
            this.edtQualifikation.Name = "edtQualifikation";
            this.edtQualifikation.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtQualifikation.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtQualifikation.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtQualifikation.Properties.Appearance.Options.UseBackColor = true;
            this.edtQualifikation.Properties.Appearance.Options.UseBorderColor = true;
            this.edtQualifikation.Properties.Appearance.Options.UseFont = true;
            this.edtQualifikation.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtQualifikation.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtQualifikation.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtQualifikation.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtQualifikation.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtQualifikation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtQualifikation.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtQualifikation.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PermissionGroupName")});
            this.edtQualifikation.Properties.DisplayMember = "PermissionGroupName";
            this.edtQualifikation.Properties.NullText = "";
            this.edtQualifikation.Properties.ShowFooter = false;
            this.edtQualifikation.Properties.ShowHeader = false;
            this.edtQualifikation.Properties.ValueMember = "PermissionGroupID";
            this.edtQualifikation.Size = new System.Drawing.Size(244, 24);
            this.edtQualifikation.TabIndex = 17;
            // 
            // edtFunktionsbezeichnung
            // 
            this.edtFunktionsbezeichnung.DataSource = this.qryUser;
            this.edtFunktionsbezeichnung.Location = new System.Drawing.Point(91, 250);
            this.edtFunktionsbezeichnung.LOVName = "RoleTitle";
            this.edtFunktionsbezeichnung.LOVOrderByColumn = KiSS4.DB.DBUtil.LOVOrderByColumnEnum.Text;
            this.edtFunktionsbezeichnung.Name = "edtFunktionsbezeichnung";
            this.edtFunktionsbezeichnung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFunktionsbezeichnung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFunktionsbezeichnung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFunktionsbezeichnung.Properties.Appearance.Options.UseBackColor = true;
            this.edtFunktionsbezeichnung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFunktionsbezeichnung.Properties.Appearance.Options.UseFont = true;
            this.edtFunktionsbezeichnung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtFunktionsbezeichnung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtFunktionsbezeichnung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtFunktionsbezeichnung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtFunktionsbezeichnung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtFunktionsbezeichnung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtFunktionsbezeichnung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFunktionsbezeichnung.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PermissionGroupName")});
            this.edtFunktionsbezeichnung.Properties.DisplayMember = "PermissionGroupName";
            this.edtFunktionsbezeichnung.Properties.NullText = "";
            this.edtFunktionsbezeichnung.Properties.ShowFooter = false;
            this.edtFunktionsbezeichnung.Properties.ShowHeader = false;
            this.edtFunktionsbezeichnung.Properties.ValueMember = "PermissionGroupID";
            this.edtFunktionsbezeichnung.Size = new System.Drawing.Size(244, 24);
            this.edtFunktionsbezeichnung.TabIndex = 16;
            // 
            // lblQualifikation
            // 
            this.lblQualifikation.Location = new System.Drawing.Point(6, 273);
            this.lblQualifikation.Name = "lblQualifikation";
            this.lblQualifikation.Size = new System.Drawing.Size(79, 24);
            this.lblQualifikation.TabIndex = 39;
            this.lblQualifikation.Text = "Qualifikation";
            this.lblQualifikation.UseCompatibleTextRendering = true;
            // 
            // lblFunktionsbezeichnung
            // 
            this.lblFunktionsbezeichnung.Location = new System.Drawing.Point(6, 249);
            this.lblFunktionsbezeichnung.Name = "lblFunktionsbezeichnung";
            this.lblFunktionsbezeichnung.Size = new System.Drawing.Size(79, 24);
            this.lblFunktionsbezeichnung.TabIndex = 38;
            this.lblFunktionsbezeichnung.Text = "Funkt.";
            this.lblFunktionsbezeichnung.UseCompatibleTextRendering = true;
            // 
            // edtGrantPermGroupID
            // 
            this.edtGrantPermGroupID.DataSource = this.qryUser;
            this.edtGrantPermGroupID.Location = new System.Drawing.Point(471, 223);
            this.edtGrantPermGroupID.Name = "edtGrantPermGroupID";
            this.edtGrantPermGroupID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGrantPermGroupID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrantPermGroupID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrantPermGroupID.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrantPermGroupID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrantPermGroupID.Properties.Appearance.Options.UseFont = true;
            this.edtGrantPermGroupID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtGrantPermGroupID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrantPermGroupID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtGrantPermGroupID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtGrantPermGroupID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtGrantPermGroupID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtGrantPermGroupID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGrantPermGroupID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PermissionGroupName")});
            this.edtGrantPermGroupID.Properties.DisplayMember = "PermissionGroupName";
            this.edtGrantPermGroupID.Properties.NullText = "";
            this.edtGrantPermGroupID.Properties.ShowFooter = false;
            this.edtGrantPermGroupID.Properties.ShowHeader = false;
            this.edtGrantPermGroupID.Properties.ValueMember = "PermissionGroupID";
            this.edtGrantPermGroupID.Size = new System.Drawing.Size(246, 24);
            this.edtGrantPermGroupID.TabIndex = 33;
            // 
            // lblGrantPermGroupID
            // 
            this.lblGrantPermGroupID.Location = new System.Drawing.Point(363, 223);
            this.lblGrantPermGroupID.Name = "lblGrantPermGroupID";
            this.lblGrantPermGroupID.Size = new System.Drawing.Size(102, 24);
            this.lblGrantPermGroupID.TabIndex = 32;
            this.lblGrantPermGroupID.Text = "Fremdkompetenz";
            // 
            // edtPermissionGroupID
            // 
            this.edtPermissionGroupID.DataSource = this.qryUser;
            this.edtPermissionGroupID.Location = new System.Drawing.Point(471, 200);
            this.edtPermissionGroupID.Name = "edtPermissionGroupID";
            this.edtPermissionGroupID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPermissionGroupID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPermissionGroupID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPermissionGroupID.Properties.Appearance.Options.UseBackColor = true;
            this.edtPermissionGroupID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPermissionGroupID.Properties.Appearance.Options.UseFont = true;
            this.edtPermissionGroupID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtPermissionGroupID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtPermissionGroupID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtPermissionGroupID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtPermissionGroupID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtPermissionGroupID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtPermissionGroupID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPermissionGroupID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PermissionGroupName")});
            this.edtPermissionGroupID.Properties.DisplayMember = "PermissionGroupName";
            this.edtPermissionGroupID.Properties.NullText = "";
            this.edtPermissionGroupID.Properties.ShowFooter = false;
            this.edtPermissionGroupID.Properties.ShowHeader = false;
            this.edtPermissionGroupID.Properties.ValueMember = "PermissionGroupID";
            this.edtPermissionGroupID.Size = new System.Drawing.Size(246, 24);
            this.edtPermissionGroupID.TabIndex = 31;
            // 
            // lblPermissionGroupID
            // 
            this.lblPermissionGroupID.Location = new System.Drawing.Point(363, 199);
            this.lblPermissionGroupID.Name = "lblPermissionGroupID";
            this.lblPermissionGroupID.Size = new System.Drawing.Size(102, 24);
            this.lblPermissionGroupID.TabIndex = 30;
            this.lblPermissionGroupID.Text = "Eigenkompetenz";
            // 
            // edtModulCode
            // 
            this.edtModulCode.DataSource = this.qryUser;
            this.edtModulCode.Location = new System.Drawing.Point(471, 253);
            this.edtModulCode.LOVFilter = "ModulTree = 1";
            this.edtModulCode.LOVFilterWhereAppend = true;
            this.edtModulCode.LOVName = "Modul";
            this.edtModulCode.Name = "edtModulCode";
            this.edtModulCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtModulCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtModulCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtModulCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtModulCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtModulCode.Properties.Appearance.Options.UseFont = true;
            this.edtModulCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtModulCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtModulCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtModulCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtModulCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtModulCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtModulCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtModulCode.Properties.NullText = "";
            this.edtModulCode.Properties.ShowFooter = false;
            this.edtModulCode.Properties.ShowHeader = false;
            this.edtModulCode.Size = new System.Drawing.Size(246, 24);
            this.edtModulCode.TabIndex = 35;
            // 
            // lblModulCode
            // 
            this.lblModulCode.Location = new System.Drawing.Point(363, 252);
            this.lblModulCode.Name = "lblModulCode";
            this.lblModulCode.Size = new System.Drawing.Size(102, 24);
            this.lblModulCode.TabIndex = 34;
            this.lblModulCode.Text = "Modul";
            // 
            // edtIsMandatsTraeger
            // 
            this.edtIsMandatsTraeger.DataMember = "IsMandatsTraeger";
            this.edtIsMandatsTraeger.DataSource = this.qryUser;
            this.edtIsMandatsTraeger.Location = new System.Drawing.Point(217, 171);
            this.edtIsMandatsTraeger.Name = "edtIsMandatsTraeger";
            this.edtIsMandatsTraeger.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtIsMandatsTraeger.Properties.Appearance.Options.UseBackColor = true;
            this.edtIsMandatsTraeger.Properties.Caption = "Mandatsträger";
            this.edtIsMandatsTraeger.Size = new System.Drawing.Size(132, 19);
            this.edtIsMandatsTraeger.TabIndex = 13;
            // 
            // edtUserProfil
            // 
            this.edtUserProfil.DataSource = this.qryUser;
            this.edtUserProfil.Location = new System.Drawing.Point(471, 276);
            this.edtUserProfil.Name = "edtUserProfil";
            this.edtUserProfil.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserProfil.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserProfil.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserProfil.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserProfil.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserProfil.Properties.Appearance.Options.UseFont = true;
            this.edtUserProfil.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtUserProfil.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserProfil.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtUserProfil.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtUserProfil.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtUserProfil.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtUserProfil.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserProfil.Properties.NullText = "";
            this.edtUserProfil.Properties.ShowFooter = false;
            this.edtUserProfil.Properties.ShowHeader = false;
            this.edtUserProfil.Size = new System.Drawing.Size(246, 24);
            this.edtUserProfil.TabIndex = 37;
            // 
            // lblUserProfile
            // 
            this.lblUserProfile.Location = new System.Drawing.Point(363, 276);
            this.lblUserProfile.Name = "lblUserProfile";
            this.lblUserProfile.Size = new System.Drawing.Size(102, 24);
            this.lblUserProfile.TabIndex = 36;
            this.lblUserProfile.Text = "Userprofil";
            this.lblUserProfile.UseCompatibleTextRendering = true;
            // 
            // memBemerkungen
            // 
            this.memBemerkungen.DataSource = this.qryUser;
            this.memBemerkungen.EditValue = "";
            this.memBemerkungen.Location = new System.Drawing.Point(471, 141);
            this.memBemerkungen.Name = "memBemerkungen";
            this.memBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.memBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.memBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.memBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memBemerkungen.Size = new System.Drawing.Size(246, 53);
            this.memBemerkungen.TabIndex = 29;
            // 
            // lblBemerkungen
            // 
            this.lblBemerkungen.Location = new System.Drawing.Point(366, 141);
            this.lblBemerkungen.Name = "lblBemerkungen";
            this.lblBemerkungen.Size = new System.Drawing.Size(99, 24);
            this.lblBemerkungen.TabIndex = 28;
            this.lblBemerkungen.Text = "Bemerkungen";
            this.lblBemerkungen.UseCompatibleTextRendering = true;
            // 
            // edtEmail
            // 
            this.edtEmail.DataSource = this.qryUser;
            this.edtEmail.Location = new System.Drawing.Point(471, 111);
            this.edtEmail.Name = "edtEmail";
            this.edtEmail.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEmail.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEmail.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEmail.Properties.Appearance.Options.UseBackColor = true;
            this.edtEmail.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEmail.Properties.Appearance.Options.UseFont = true;
            this.edtEmail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEmail.Size = new System.Drawing.Size(246, 24);
            this.edtEmail.TabIndex = 27;
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(366, 111);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(99, 24);
            this.lblEmail.TabIndex = 26;
            this.lblEmail.Text = "E-Mail";
            this.lblEmail.UseCompatibleTextRendering = true;
            // 
            // edtPhone
            // 
            this.edtPhone.DataSource = this.qryUser;
            this.edtPhone.Location = new System.Drawing.Point(471, 88);
            this.edtPhone.Name = "edtPhone";
            this.edtPhone.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPhone.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPhone.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPhone.Properties.Appearance.Options.UseBackColor = true;
            this.edtPhone.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPhone.Properties.Appearance.Options.UseFont = true;
            this.edtPhone.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPhone.Size = new System.Drawing.Size(246, 24);
            this.edtPhone.TabIndex = 25;
            // 
            // lblTelefon
            // 
            this.lblTelefon.Location = new System.Drawing.Point(365, 88);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new System.Drawing.Size(100, 24);
            this.lblTelefon.TabIndex = 24;
            this.lblTelefon.Text = "Telefon";
            this.lblTelefon.UseCompatibleTextRendering = true;
            // 
            // edtLanguageCode
            // 
            this.edtLanguageCode.DataSource = this.qryUser;
            this.edtLanguageCode.Location = new System.Drawing.Point(471, 58);
            this.edtLanguageCode.LOVName = "Sprache";
            this.edtLanguageCode.Name = "edtLanguageCode";
            this.edtLanguageCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtLanguageCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLanguageCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLanguageCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtLanguageCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLanguageCode.Properties.Appearance.Options.UseFont = true;
            this.edtLanguageCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtLanguageCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtLanguageCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtLanguageCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtLanguageCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtLanguageCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtLanguageCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtLanguageCode.Properties.NullText = "";
            this.edtLanguageCode.Properties.ShowFooter = false;
            this.edtLanguageCode.Properties.ShowHeader = false;
            this.edtLanguageCode.Size = new System.Drawing.Size(246, 24);
            this.edtLanguageCode.TabIndex = 23;
            // 
            // lblSprache
            // 
            this.lblSprache.Location = new System.Drawing.Point(366, 57);
            this.lblSprache.Name = "lblSprache";
            this.lblSprache.Size = new System.Drawing.Size(99, 24);
            this.lblSprache.TabIndex = 22;
            this.lblSprache.Text = "Sprache";
            this.lblSprache.UseCompatibleTextRendering = true;
            // 
            // edtGenderCode
            // 
            this.edtGenderCode.DataSource = this.qryUser;
            this.edtGenderCode.Location = new System.Drawing.Point(471, 35);
            this.edtGenderCode.LOVName = "Geschlecht";
            this.edtGenderCode.Name = "edtGenderCode";
            this.edtGenderCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGenderCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGenderCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGenderCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtGenderCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGenderCode.Properties.Appearance.Options.UseFont = true;
            this.edtGenderCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtGenderCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtGenderCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtGenderCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtGenderCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtGenderCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtGenderCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGenderCode.Properties.NullText = "";
            this.edtGenderCode.Properties.ShowFooter = false;
            this.edtGenderCode.Properties.ShowHeader = false;
            this.edtGenderCode.Size = new System.Drawing.Size(246, 24);
            this.edtGenderCode.TabIndex = 21;
            // 
            // lblGeschlecht
            // 
            this.lblGeschlecht.Location = new System.Drawing.Point(366, 35);
            this.lblGeschlecht.Name = "lblGeschlecht";
            this.lblGeschlecht.Size = new System.Drawing.Size(99, 24);
            this.lblGeschlecht.TabIndex = 20;
            this.lblGeschlecht.Text = "Geschlecht";
            this.lblGeschlecht.UseCompatibleTextRendering = true;
            // 
            // chkIsLocked
            // 
            this.chkIsLocked.DataSource = this.qryUser;
            this.chkIsLocked.EditValue = false;
            this.chkIsLocked.Location = new System.Drawing.Point(91, 10);
            this.chkIsLocked.Name = "chkIsLocked";
            this.chkIsLocked.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkIsLocked.Properties.Appearance.Options.UseBackColor = true;
            this.chkIsLocked.Properties.Caption = "Gesperrt";
            this.chkIsLocked.Size = new System.Drawing.Size(97, 19);
            this.chkIsLocked.TabIndex = 0;
            // 
            // chkUserIsUserBIAGAdmin
            // 
            this.chkUserIsUserBIAGAdmin.DataSource = this.qryUser;
            this.chkUserIsUserBIAGAdmin.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.chkUserIsUserBIAGAdmin.EditValue = false;
            this.chkUserIsUserBIAGAdmin.Location = new System.Drawing.Point(623, 10);
            this.chkUserIsUserBIAGAdmin.Name = "chkUserIsUserBIAGAdmin";
            this.chkUserIsUserBIAGAdmin.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkUserIsUserBIAGAdmin.Properties.Appearance.Options.UseBackColor = true;
            this.chkUserIsUserBIAGAdmin.Properties.Caption = "BIAG Admin";
            this.chkUserIsUserBIAGAdmin.Properties.ReadOnly = true;
            this.chkUserIsUserBIAGAdmin.Size = new System.Drawing.Size(94, 19);
            this.chkUserIsUserBIAGAdmin.TabIndex = 19;
            // 
            // chkUserSystemadministration
            // 
            this.chkUserSystemadministration.DataSource = this.qryUser;
            this.chkUserSystemadministration.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.chkUserSystemadministration.EditValue = false;
            this.chkUserSystemadministration.Location = new System.Drawing.Point(470, 10);
            this.chkUserSystemadministration.Name = "chkUserSystemadministration";
            this.chkUserSystemadministration.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkUserSystemadministration.Properties.Appearance.Options.UseBackColor = true;
            this.chkUserSystemadministration.Properties.Caption = "Systemadministration";
            this.chkUserSystemadministration.Properties.ReadOnly = true;
            this.chkUserSystemadministration.Size = new System.Drawing.Size(147, 19);
            this.chkUserSystemadministration.TabIndex = 18;
            // 
            // edtPasswordRetype
            // 
            this.edtPasswordRetype.DataSource = this.qryUser;
            this.edtPasswordRetype.Location = new System.Drawing.Point(91, 224);
            this.edtPasswordRetype.Name = "edtPasswordRetype";
            this.edtPasswordRetype.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPasswordRetype.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPasswordRetype.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPasswordRetype.Properties.Appearance.Options.UseBackColor = true;
            this.edtPasswordRetype.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPasswordRetype.Properties.Appearance.Options.UseFont = true;
            this.edtPasswordRetype.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPasswordRetype.Properties.PasswordChar = '*';
            this.edtPasswordRetype.Size = new System.Drawing.Size(244, 24);
            this.edtPasswordRetype.TabIndex = 15;
            // 
            // lblPWKontrolle
            // 
            this.lblPWKontrolle.Location = new System.Drawing.Point(6, 225);
            this.lblPWKontrolle.Name = "lblPWKontrolle";
            this.lblPWKontrolle.Size = new System.Drawing.Size(79, 24);
            this.lblPWKontrolle.TabIndex = 15;
            this.lblPWKontrolle.Text = "PW Kontrolle";
            this.lblPWKontrolle.UseCompatibleTextRendering = true;
            // 
            // edtPassword
            // 
            this.edtPassword.DataSource = this.qryUser;
            this.edtPassword.Location = new System.Drawing.Point(91, 201);
            this.edtPassword.Name = "edtPassword";
            this.edtPassword.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPassword.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPassword.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPassword.Properties.Appearance.Options.UseBackColor = true;
            this.edtPassword.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPassword.Properties.Appearance.Options.UseFont = true;
            this.edtPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPassword.Properties.PasswordChar = '*';
            this.edtPassword.Size = new System.Drawing.Size(244, 24);
            this.edtPassword.TabIndex = 14;
            this.edtPassword.Modified += new System.EventHandler(this.edtPassword_Modified);
            // 
            // lblPasswort
            // 
            this.lblPasswort.Location = new System.Drawing.Point(6, 201);
            this.lblPasswort.Name = "lblPasswort";
            this.lblPasswort.Size = new System.Drawing.Size(79, 24);
            this.lblPasswort.TabIndex = 13;
            this.lblPasswort.Text = "Passwort";
            this.lblPasswort.UseCompatibleTextRendering = true;
            // 
            // edtShortName
            // 
            this.edtShortName.DataSource = this.qryUser;
            this.edtShortName.Location = new System.Drawing.Point(91, 171);
            this.edtShortName.Name = "edtShortName";
            this.edtShortName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtShortName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtShortName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtShortName.Properties.Appearance.Options.UseBackColor = true;
            this.edtShortName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtShortName.Properties.Appearance.Options.UseFont = true;
            this.edtShortName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtShortName.Size = new System.Drawing.Size(120, 24);
            this.edtShortName.TabIndex = 12;
            // 
            // lblKurzzeichen
            // 
            this.lblKurzzeichen.Location = new System.Drawing.Point(6, 171);
            this.lblKurzzeichen.Name = "lblKurzzeichen";
            this.lblKurzzeichen.Size = new System.Drawing.Size(79, 24);
            this.lblKurzzeichen.TabIndex = 11;
            this.lblKurzzeichen.Text = "Kurzzeichen";
            this.lblKurzzeichen.UseCompatibleTextRendering = true;
            // 
            // edtLogonName
            // 
            this.edtLogonName.DataSource = this.qryUser;
            this.edtLogonName.Location = new System.Drawing.Point(91, 141);
            this.edtLogonName.Name = "edtLogonName";
            this.edtLogonName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtLogonName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLogonName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLogonName.Properties.Appearance.Options.UseBackColor = true;
            this.edtLogonName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLogonName.Properties.Appearance.Options.UseFont = true;
            this.edtLogonName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtLogonName.Size = new System.Drawing.Size(244, 24);
            this.edtLogonName.TabIndex = 10;
            // 
            // lblLogon
            // 
            this.lblLogon.Location = new System.Drawing.Point(6, 141);
            this.lblLogon.Name = "lblLogon";
            this.lblLogon.Size = new System.Drawing.Size(79, 24);
            this.lblLogon.TabIndex = 9;
            this.lblLogon.Text = "Logon";
            this.lblLogon.UseCompatibleTextRendering = true;
            // 
            // edtFirstName
            // 
            this.edtFirstName.DataSource = this.qryUser;
            this.edtFirstName.Location = new System.Drawing.Point(91, 111);
            this.edtFirstName.Name = "edtFirstName";
            this.edtFirstName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFirstName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFirstName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFirstName.Properties.Appearance.Options.UseBackColor = true;
            this.edtFirstName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFirstName.Properties.Appearance.Options.UseFont = true;
            this.edtFirstName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFirstName.Size = new System.Drawing.Size(244, 24);
            this.edtFirstName.TabIndex = 8;
            // 
            // lblVorname
            // 
            this.lblVorname.Location = new System.Drawing.Point(6, 111);
            this.lblVorname.Name = "lblVorname";
            this.lblVorname.Size = new System.Drawing.Size(79, 24);
            this.lblVorname.TabIndex = 7;
            this.lblVorname.Text = "Vorname";
            this.lblVorname.UseCompatibleTextRendering = true;
            // 
            // edtLastName
            // 
            this.edtLastName.DataSource = this.qryUser;
            this.edtLastName.Location = new System.Drawing.Point(91, 88);
            this.edtLastName.Name = "edtLastName";
            this.edtLastName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtLastName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLastName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLastName.Properties.Appearance.Options.UseBackColor = true;
            this.edtLastName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLastName.Properties.Appearance.Options.UseFont = true;
            this.edtLastName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtLastName.Size = new System.Drawing.Size(244, 24);
            this.edtLastName.TabIndex = 6;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(6, 88);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(79, 24);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Name";
            this.lblName.UseCompatibleTextRendering = true;
            // 
            // edtPersonalNr
            // 
            this.edtPersonalNr.DataSource = this.qryUser;
            this.edtPersonalNr.Location = new System.Drawing.Point(91, 58);
            this.edtPersonalNr.Name = "edtPersonalNr";
            this.edtPersonalNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtPersonalNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPersonalNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPersonalNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPersonalNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtPersonalNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPersonalNr.Properties.Appearance.Options.UseFont = true;
            this.edtPersonalNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPersonalNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPersonalNr.Size = new System.Drawing.Size(120, 24);
            this.edtPersonalNr.TabIndex = 4;
            // 
            // lblPersonalNr
            // 
            this.lblPersonalNr.Location = new System.Drawing.Point(6, 57);
            this.lblPersonalNr.Name = "lblPersonalNr";
            this.lblPersonalNr.Size = new System.Drawing.Size(79, 24);
            this.lblPersonalNr.TabIndex = 3;
            this.lblPersonalNr.Text = "Personal-Nr.";
            this.lblPersonalNr.UseCompatibleTextRendering = true;
            // 
            // edtUserID
            // 
            this.edtUserID.DataSource = this.qryUser;
            this.edtUserID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtUserID.Location = new System.Drawing.Point(91, 35);
            this.edtUserID.Name = "edtUserID";
            this.edtUserID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtUserID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtUserID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserID.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserID.Properties.Appearance.Options.UseFont = true;
            this.edtUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtUserID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserID.Properties.ReadOnly = true;
            this.edtUserID.Size = new System.Drawing.Size(120, 24);
            this.edtUserID.TabIndex = 2;
            // 
            // lblUserID
            // 
            this.lblUserID.Location = new System.Drawing.Point(6, 35);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(79, 24);
            this.lblUserID.TabIndex = 1;
            this.lblUserID.Text = "Nr.";
            this.lblUserID.UseCompatibleTextRendering = true;
            // 
            // tpgBaAdresse
            // 
            this.tpgBaAdresse.Controls.Add(this.edtPLZWohnsitz);
            this.tpgBaAdresse.Controls.Add(this.chkPostfachOhneNummer);
            this.tpgBaAdresse.Controls.Add(this.edtXUserPhonePrivat);
            this.tpgBaAdresse.Controls.Add(this.edtXUSerPhoneMobile);
            this.tpgBaAdresse.Controls.Add(this.kissLabel1);
            this.tpgBaAdresse.Controls.Add(this.edtXUserFax);
            this.tpgBaAdresse.Controls.Add(this.lblGrunddatenFax);
            this.tpgBaAdresse.Controls.Add(this.edtXUserPhoneGesch);
            this.tpgBaAdresse.Controls.Add(this.lblGrunddatenTelefonMobil);
            this.tpgBaAdresse.Controls.Add(this.lblGrunddatenTelefon);
            this.tpgBaAdresse.Controls.Add(this.edtXUserEmail);
            this.tpgBaAdresse.Controls.Add(this.lblGrunddatenEmail);
            this.tpgBaAdresse.Controls.Add(this.lblGrunddatenAdresseLand);
            this.tpgBaAdresse.Controls.Add(this.lblGrunddatenAdresseBezirk);
            this.tpgBaAdresse.Controls.Add(this.lblGrunddatenAdressePLZOrtKt);
            this.tpgBaAdresse.Controls.Add(this.edtAdressePostfach);
            this.tpgBaAdresse.Controls.Add(this.lblGrunddatenAdressePostfach);
            this.tpgBaAdresse.Controls.Add(this.edtAdresseHausNr);
            this.tpgBaAdresse.Controls.Add(this.edtAdresseStrasse);
            this.tpgBaAdresse.Controls.Add(this.lblGrunddatenAdresseStrasseNr);
            this.tpgBaAdresse.Controls.Add(this.edtAdresseZusatz);
            this.tpgBaAdresse.Controls.Add(this.lblGrunddatenAdresseZusatz);
            this.tpgBaAdresse.Location = new System.Drawing.Point(6, 6);
            this.tpgBaAdresse.Name = "tpgBaAdresse";
            this.tpgBaAdresse.Size = new System.Drawing.Size(838, 303);
            this.tpgBaAdresse.TabIndex = 0;
            this.tpgBaAdresse.Title = "Adresse / Kontakt";
            // 
            // edtPLZWohnsitz
            // 
            this.edtPLZWohnsitz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPLZWohnsitz.DataMember = "OrtschaftCode";
            this.edtPLZWohnsitz.DataSource = this.qryBaAdresse;
            this.edtPLZWohnsitz.Location = new System.Drawing.Point(91, 79);
            this.edtPLZWohnsitz.Name = "edtPLZWohnsitz";
            this.edtPLZWohnsitz.ShowBezirk = true;
            this.edtPLZWohnsitz.Size = new System.Drawing.Size(241, 70);
            this.edtPLZWohnsitz.TabIndex = 9;
            // 
            // qryBaAdresse
            // 
            this.qryBaAdresse.HostControl = this;
            this.qryBaAdresse.TableName = "BaAdresse";
            this.qryBaAdresse.BeforePost += new System.EventHandler(this.qryBaAdresse_BeforePost);
            // 
            // chkPostfachOhneNummer
            // 
            this.chkPostfachOhneNummer.DataMember = "PostfachOhneNr";
            this.chkPostfachOhneNummer.DataSource = this.qryBaAdresse;
            this.chkPostfachOhneNummer.Location = new System.Drawing.Point(260, 60);
            this.chkPostfachOhneNummer.Name = "chkPostfachOhneNummer";
            this.chkPostfachOhneNummer.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkPostfachOhneNummer.Properties.Appearance.Options.UseBackColor = true;
            this.chkPostfachOhneNummer.Properties.Caption = "ohne Nr.";
            this.chkPostfachOhneNummer.Size = new System.Drawing.Size(72, 19);
            this.chkPostfachOhneNummer.TabIndex = 7;
            // 
            // edtXUserPhonePrivat
            // 
            this.edtXUserPhonePrivat.DataMember = "PhonePrivat";
            this.edtXUserPhonePrivat.DataSource = this.qryUser;
            this.edtXUserPhonePrivat.Location = new System.Drawing.Point(471, 10);
            this.edtXUserPhonePrivat.Name = "edtXUserPhonePrivat";
            this.edtXUserPhonePrivat.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtXUserPhonePrivat.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtXUserPhonePrivat.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtXUserPhonePrivat.Properties.Appearance.Options.UseBackColor = true;
            this.edtXUserPhonePrivat.Properties.Appearance.Options.UseBorderColor = true;
            this.edtXUserPhonePrivat.Properties.Appearance.Options.UseFont = true;
            this.edtXUserPhonePrivat.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtXUserPhonePrivat.Properties.MaxLength = 255;
            this.edtXUserPhonePrivat.Size = new System.Drawing.Size(246, 24);
            this.edtXUserPhonePrivat.TabIndex = 13;
            // 
            // edtXUSerPhoneMobile
            // 
            this.edtXUSerPhoneMobile.DataMember = "PhoneMobile";
            this.edtXUSerPhoneMobile.DataSource = this.qryUser;
            this.edtXUSerPhoneMobile.Location = new System.Drawing.Point(471, 56);
            this.edtXUSerPhoneMobile.Name = "edtXUSerPhoneMobile";
            this.edtXUSerPhoneMobile.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtXUSerPhoneMobile.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtXUSerPhoneMobile.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtXUSerPhoneMobile.Properties.Appearance.Options.UseBackColor = true;
            this.edtXUSerPhoneMobile.Properties.Appearance.Options.UseBorderColor = true;
            this.edtXUSerPhoneMobile.Properties.Appearance.Options.UseFont = true;
            this.edtXUSerPhoneMobile.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtXUSerPhoneMobile.Properties.MaxLength = 255;
            this.edtXUSerPhoneMobile.Size = new System.Drawing.Size(246, 24);
            this.edtXUSerPhoneMobile.TabIndex = 17;
            // 
            // kissLabel1
            // 
            this.kissLabel1.Location = new System.Drawing.Point(366, 56);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(99, 24);
            this.kissLabel1.TabIndex = 16;
            this.kissLabel1.Text = "Telefon mobil";
            this.kissLabel1.UseCompatibleTextRendering = true;
            // 
            // edtXUserFax
            // 
            this.edtXUserFax.DataMember = "Fax";
            this.edtXUserFax.DataSource = this.qryUser;
            this.edtXUserFax.Location = new System.Drawing.Point(471, 102);
            this.edtXUserFax.Name = "edtXUserFax";
            this.edtXUserFax.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtXUserFax.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtXUserFax.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtXUserFax.Properties.Appearance.Options.UseBackColor = true;
            this.edtXUserFax.Properties.Appearance.Options.UseBorderColor = true;
            this.edtXUserFax.Properties.Appearance.Options.UseFont = true;
            this.edtXUserFax.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtXUserFax.Properties.MaxLength = 255;
            this.edtXUserFax.Size = new System.Drawing.Size(246, 24);
            this.edtXUserFax.TabIndex = 19;
            // 
            // lblGrunddatenFax
            // 
            this.lblGrunddatenFax.Location = new System.Drawing.Point(366, 102);
            this.lblGrunddatenFax.Name = "lblGrunddatenFax";
            this.lblGrunddatenFax.Size = new System.Drawing.Size(99, 24);
            this.lblGrunddatenFax.TabIndex = 18;
            this.lblGrunddatenFax.Text = "Fax";
            this.lblGrunddatenFax.UseCompatibleTextRendering = true;
            // 
            // edtXUserPhoneGesch
            // 
            this.edtXUserPhoneGesch.DataMember = "PhoneOffice";
            this.edtXUserPhoneGesch.DataSource = this.qryUser;
            this.edtXUserPhoneGesch.Location = new System.Drawing.Point(471, 33);
            this.edtXUserPhoneGesch.Name = "edtXUserPhoneGesch";
            this.edtXUserPhoneGesch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtXUserPhoneGesch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtXUserPhoneGesch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtXUserPhoneGesch.Properties.Appearance.Options.UseBackColor = true;
            this.edtXUserPhoneGesch.Properties.Appearance.Options.UseBorderColor = true;
            this.edtXUserPhoneGesch.Properties.Appearance.Options.UseFont = true;
            this.edtXUserPhoneGesch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtXUserPhoneGesch.Properties.MaxLength = 255;
            this.edtXUserPhoneGesch.Size = new System.Drawing.Size(246, 24);
            this.edtXUserPhoneGesch.TabIndex = 15;
            // 
            // lblGrunddatenTelefonMobil
            // 
            this.lblGrunddatenTelefonMobil.Location = new System.Drawing.Point(366, 33);
            this.lblGrunddatenTelefonMobil.Name = "lblGrunddatenTelefonMobil";
            this.lblGrunddatenTelefonMobil.Size = new System.Drawing.Size(99, 24);
            this.lblGrunddatenTelefonMobil.TabIndex = 14;
            this.lblGrunddatenTelefonMobil.Text = "Telefon gesch.";
            this.lblGrunddatenTelefonMobil.UseCompatibleTextRendering = true;
            // 
            // lblGrunddatenTelefon
            // 
            this.lblGrunddatenTelefon.Location = new System.Drawing.Point(366, 10);
            this.lblGrunddatenTelefon.Name = "lblGrunddatenTelefon";
            this.lblGrunddatenTelefon.Size = new System.Drawing.Size(99, 24);
            this.lblGrunddatenTelefon.TabIndex = 12;
            this.lblGrunddatenTelefon.Text = "Telefon privat";
            this.lblGrunddatenTelefon.UseCompatibleTextRendering = true;
            // 
            // edtXUserEmail
            // 
            this.edtXUserEmail.DataMember = "Email";
            this.edtXUserEmail.DataSource = this.qryUser;
            this.edtXUserEmail.Location = new System.Drawing.Point(471, 125);
            this.edtXUserEmail.Name = "edtXUserEmail";
            this.edtXUserEmail.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtXUserEmail.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtXUserEmail.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtXUserEmail.Properties.Appearance.Options.UseBackColor = true;
            this.edtXUserEmail.Properties.Appearance.Options.UseBorderColor = true;
            this.edtXUserEmail.Properties.Appearance.Options.UseFont = true;
            this.edtXUserEmail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtXUserEmail.Size = new System.Drawing.Size(246, 24);
            this.edtXUserEmail.TabIndex = 21;
            // 
            // lblGrunddatenEmail
            // 
            this.lblGrunddatenEmail.Location = new System.Drawing.Point(366, 125);
            this.lblGrunddatenEmail.Name = "lblGrunddatenEmail";
            this.lblGrunddatenEmail.Size = new System.Drawing.Size(99, 24);
            this.lblGrunddatenEmail.TabIndex = 20;
            this.lblGrunddatenEmail.Text = "E-Mail";
            this.lblGrunddatenEmail.UseCompatibleTextRendering = true;
            // 
            // lblGrunddatenAdresseLand
            // 
            this.lblGrunddatenAdresseLand.Location = new System.Drawing.Point(9, 125);
            this.lblGrunddatenAdresseLand.Name = "lblGrunddatenAdresseLand";
            this.lblGrunddatenAdresseLand.Size = new System.Drawing.Size(79, 24);
            this.lblGrunddatenAdresseLand.TabIndex = 11;
            this.lblGrunddatenAdresseLand.Text = "Land";
            this.lblGrunddatenAdresseLand.UseCompatibleTextRendering = true;
            // 
            // lblGrunddatenAdresseBezirk
            // 
            this.lblGrunddatenAdresseBezirk.Location = new System.Drawing.Point(9, 102);
            this.lblGrunddatenAdresseBezirk.Name = "lblGrunddatenAdresseBezirk";
            this.lblGrunddatenAdresseBezirk.Size = new System.Drawing.Size(79, 24);
            this.lblGrunddatenAdresseBezirk.TabIndex = 10;
            this.lblGrunddatenAdresseBezirk.Text = "Bezirk";
            this.lblGrunddatenAdresseBezirk.UseCompatibleTextRendering = true;
            // 
            // lblGrunddatenAdressePLZOrtKt
            // 
            this.lblGrunddatenAdressePLZOrtKt.Location = new System.Drawing.Point(9, 79);
            this.lblGrunddatenAdressePLZOrtKt.Name = "lblGrunddatenAdressePLZOrtKt";
            this.lblGrunddatenAdressePLZOrtKt.Size = new System.Drawing.Size(79, 24);
            this.lblGrunddatenAdressePLZOrtKt.TabIndex = 8;
            this.lblGrunddatenAdressePLZOrtKt.Text = "PLZ / Ort / Kt.";
            this.lblGrunddatenAdressePLZOrtKt.UseCompatibleTextRendering = true;
            // 
            // edtAdressePostfach
            // 
            this.edtAdressePostfach.DataMember = "Postfach";
            this.edtAdressePostfach.DataSource = this.qryBaAdresse;
            this.edtAdressePostfach.Location = new System.Drawing.Point(91, 56);
            this.edtAdressePostfach.Name = "edtAdressePostfach";
            this.edtAdressePostfach.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAdressePostfach.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdressePostfach.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdressePostfach.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdressePostfach.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdressePostfach.Properties.Appearance.Options.UseFont = true;
            this.edtAdressePostfach.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdressePostfach.Properties.MaxLength = 255;
            this.edtAdressePostfach.Size = new System.Drawing.Size(163, 24);
            this.edtAdressePostfach.TabIndex = 6;
            // 
            // lblGrunddatenAdressePostfach
            // 
            this.lblGrunddatenAdressePostfach.Location = new System.Drawing.Point(9, 56);
            this.lblGrunddatenAdressePostfach.Name = "lblGrunddatenAdressePostfach";
            this.lblGrunddatenAdressePostfach.Size = new System.Drawing.Size(79, 24);
            this.lblGrunddatenAdressePostfach.TabIndex = 5;
            this.lblGrunddatenAdressePostfach.Text = "Postfach";
            this.lblGrunddatenAdressePostfach.UseCompatibleTextRendering = true;
            // 
            // edtAdresseHausNr
            // 
            this.edtAdresseHausNr.DataMember = "HausNr";
            this.edtAdresseHausNr.DataSource = this.qryBaAdresse;
            this.edtAdresseHausNr.Location = new System.Drawing.Point(286, 33);
            this.edtAdresseHausNr.Name = "edtAdresseHausNr";
            this.edtAdresseHausNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAdresseHausNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdresseHausNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdresseHausNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdresseHausNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdresseHausNr.Properties.Appearance.Options.UseFont = true;
            this.edtAdresseHausNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdresseHausNr.Properties.MaxLength = 255;
            this.edtAdresseHausNr.Size = new System.Drawing.Size(49, 24);
            this.edtAdresseHausNr.TabIndex = 4;
            // 
            // edtAdresseStrasse
            // 
            this.edtAdresseStrasse.DataMember = "Strasse";
            this.edtAdresseStrasse.DataSource = this.qryBaAdresse;
            this.edtAdresseStrasse.Location = new System.Drawing.Point(91, 33);
            this.edtAdresseStrasse.Name = "edtAdresseStrasse";
            this.edtAdresseStrasse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAdresseStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdresseStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdresseStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdresseStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdresseStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtAdresseStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdresseStrasse.Properties.MaxLength = 255;
            this.edtAdresseStrasse.Size = new System.Drawing.Size(196, 24);
            this.edtAdresseStrasse.TabIndex = 3;
            // 
            // lblGrunddatenAdresseStrasseNr
            // 
            this.lblGrunddatenAdresseStrasseNr.Location = new System.Drawing.Point(9, 33);
            this.lblGrunddatenAdresseStrasseNr.Name = "lblGrunddatenAdresseStrasseNr";
            this.lblGrunddatenAdresseStrasseNr.Size = new System.Drawing.Size(79, 24);
            this.lblGrunddatenAdresseStrasseNr.TabIndex = 2;
            this.lblGrunddatenAdresseStrasseNr.Text = "Strasse / Nr.";
            this.lblGrunddatenAdresseStrasseNr.UseCompatibleTextRendering = true;
            // 
            // edtAdresseZusatz
            // 
            this.edtAdresseZusatz.DataMember = "Zusatz";
            this.edtAdresseZusatz.DataSource = this.qryBaAdresse;
            this.edtAdresseZusatz.Location = new System.Drawing.Point(91, 10);
            this.edtAdresseZusatz.Name = "edtAdresseZusatz";
            this.edtAdresseZusatz.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAdresseZusatz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdresseZusatz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdresseZusatz.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdresseZusatz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdresseZusatz.Properties.Appearance.Options.UseFont = true;
            this.edtAdresseZusatz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdresseZusatz.Properties.MaxLength = 255;
            this.edtAdresseZusatz.Size = new System.Drawing.Size(244, 24);
            this.edtAdresseZusatz.TabIndex = 1;
            // 
            // lblGrunddatenAdresseZusatz
            // 
            this.lblGrunddatenAdresseZusatz.Location = new System.Drawing.Point(9, 10);
            this.lblGrunddatenAdresseZusatz.Name = "lblGrunddatenAdresseZusatz";
            this.lblGrunddatenAdresseZusatz.Size = new System.Drawing.Size(79, 24);
            this.lblGrunddatenAdresseZusatz.TabIndex = 0;
            this.lblGrunddatenAdresseZusatz.Text = "Zusatz";
            this.lblGrunddatenAdresseZusatz.UseCompatibleTextRendering = true;
            // 
            // tpgBenutzerrechte
            // 
            this.tpgBenutzerrechte.Controls.Add(this.grdRechte);
            this.tpgBenutzerrechte.Location = new System.Drawing.Point(6, 6);
            this.tpgBenutzerrechte.Name = "tpgBenutzerrechte";
            this.tpgBenutzerrechte.Padding = new System.Windows.Forms.Padding(4);
            this.tpgBenutzerrechte.Size = new System.Drawing.Size(838, 303);
            this.tpgBenutzerrechte.TabIndex = 2;
            this.tpgBenutzerrechte.Title = "Benutzerrechte";
            // 
            // grdRechte
            // 
            this.grdRechte.DataSource = this.qryUserRight;
            this.grdRechte.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdRechte.EmbeddedNavigator.Name = "";
            this.grdRechte.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdRechte.Location = new System.Drawing.Point(4, 4);
            this.grdRechte.MainView = this.grvRechte;
            this.grdRechte.Margin = new System.Windows.Forms.Padding(4);
            this.grdRechte.Name = "grdRechte";
            this.grdRechte.Size = new System.Drawing.Size(830, 295);
            this.grdRechte.TabIndex = 0;
            this.grdRechte.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvRechte});
            // 
            // qryUserRight
            // 
            this.qryUserRight.AutoApplyUserRights = false;
            // 
            // grvRechte
            // 
            this.grvRechte.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvRechte.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRechte.Appearance.Empty.Options.UseBackColor = true;
            this.grvRechte.Appearance.Empty.Options.UseFont = true;
            this.grvRechte.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRechte.Appearance.EvenRow.Options.UseFont = true;
            this.grvRechte.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvRechte.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRechte.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvRechte.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvRechte.Appearance.FocusedCell.Options.UseFont = true;
            this.grvRechte.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvRechte.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvRechte.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRechte.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvRechte.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvRechte.Appearance.FocusedRow.Options.UseFont = true;
            this.grvRechte.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvRechte.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvRechte.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvRechte.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvRechte.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvRechte.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvRechte.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvRechte.Appearance.GroupRow.Options.UseFont = true;
            this.grvRechte.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvRechte.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvRechte.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvRechte.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvRechte.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvRechte.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvRechte.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvRechte.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvRechte.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRechte.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvRechte.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvRechte.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvRechte.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvRechte.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvRechte.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvRechte.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRechte.Appearance.OddRow.Options.UseFont = true;
            this.grvRechte.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvRechte.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRechte.Appearance.Row.Options.UseBackColor = true;
            this.grvRechte.Appearance.Row.Options.UseFont = true;
            this.grvRechte.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRechte.Appearance.SelectedRow.Options.UseFont = true;
            this.grvRechte.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvRechte.Appearance.VertLine.Options.UseBackColor = true;
            this.grvRechte.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvRechte.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRecht,
            this.colRechtE,
            this.colRechtM,
            this.colRechtL});
            this.grvRechte.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvRechte.GridControl = this.grdRechte;
            this.grvRechte.Name = "grvRechte";
            this.grvRechte.OptionsBehavior.Editable = false;
            this.grvRechte.OptionsCustomization.AllowFilter = false;
            this.grvRechte.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvRechte.OptionsNavigation.AutoFocusNewRow = true;
            this.grvRechte.OptionsNavigation.UseTabKey = false;
            this.grvRechte.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvRechte.OptionsView.ShowGroupPanel = false;
            this.grvRechte.OptionsView.ShowIndicator = false;
            // 
            // colRecht
            // 
            this.colRecht.Caption = "Recht";
            this.colRecht.FieldName = "UserText";
            this.colRecht.Name = "colRecht";
            this.colRecht.Visible = true;
            this.colRecht.VisibleIndex = 0;
            this.colRecht.Width = 500;
            // 
            // colRechtE
            // 
            this.colRechtE.Caption = "E";
            this.colRechtE.FieldName = "MayInsert";
            this.colRechtE.Name = "colRechtE";
            this.colRechtE.OptionsColumn.AllowSize = false;
            this.colRechtE.OptionsColumn.FixedWidth = true;
            this.colRechtE.Visible = true;
            this.colRechtE.VisibleIndex = 1;
            this.colRechtE.Width = 20;
            // 
            // colRechtM
            // 
            this.colRechtM.Caption = "M";
            this.colRechtM.FieldName = "MayUpdate";
            this.colRechtM.Name = "colRechtM";
            this.colRechtM.OptionsColumn.AllowSize = false;
            this.colRechtM.OptionsColumn.FixedWidth = true;
            this.colRechtM.Visible = true;
            this.colRechtM.VisibleIndex = 2;
            this.colRechtM.Width = 20;
            // 
            // colRechtL
            // 
            this.colRechtL.Caption = "L";
            this.colRechtL.FieldName = "MayDelete";
            this.colRechtL.Name = "colRechtL";
            this.colRechtL.OptionsColumn.AllowSize = false;
            this.colRechtL.OptionsColumn.FixedWidth = true;
            this.colRechtL.Visible = true;
            this.colRechtL.VisibleIndex = 3;
            this.colRechtL.Width = 20;
            // 
            // tpgAbteilungen
            // 
            this.tpgAbteilungen.Controls.Add(this.grdAbteilungen);
            this.tpgAbteilungen.Location = new System.Drawing.Point(6, 6);
            this.tpgAbteilungen.Name = "tpgAbteilungen";
            this.tpgAbteilungen.Padding = new System.Windows.Forms.Padding(4);
            this.tpgAbteilungen.Size = new System.Drawing.Size(838, 303);
            this.tpgAbteilungen.TabIndex = 3;
            this.tpgAbteilungen.Title = "Abteilungen";
            // 
            // grdAbteilungen
            // 
            this.grdAbteilungen.DataSource = this.qryAbteilung;
            this.grdAbteilungen.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdAbteilungen.EmbeddedNavigator.Name = "";
            this.grdAbteilungen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdAbteilungen.Location = new System.Drawing.Point(4, 4);
            this.grdAbteilungen.MainView = this.grvAbteilungen;
            this.grdAbteilungen.Margin = new System.Windows.Forms.Padding(4);
            this.grdAbteilungen.MaximumSize = new System.Drawing.Size(700, 0);
            this.grdAbteilungen.Name = "grdAbteilungen";
            this.grdAbteilungen.Size = new System.Drawing.Size(700, 295);
            this.grdAbteilungen.TabIndex = 0;
            this.grdAbteilungen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAbteilungen});
            // 
            // qryAbteilung
            // 
            this.qryAbteilung.AutoApplyUserRights = false;
            this.qryAbteilung.HostControl = this;
            // 
            // grvAbteilungen
            // 
            this.grvAbteilungen.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvAbteilungen.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbteilungen.Appearance.Empty.Options.UseBackColor = true;
            this.grvAbteilungen.Appearance.Empty.Options.UseFont = true;
            this.grvAbteilungen.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbteilungen.Appearance.EvenRow.Options.UseFont = true;
            this.grvAbteilungen.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvAbteilungen.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbteilungen.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvAbteilungen.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvAbteilungen.Appearance.FocusedCell.Options.UseFont = true;
            this.grvAbteilungen.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvAbteilungen.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvAbteilungen.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbteilungen.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvAbteilungen.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvAbteilungen.Appearance.FocusedRow.Options.UseFont = true;
            this.grvAbteilungen.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvAbteilungen.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvAbteilungen.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvAbteilungen.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvAbteilungen.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbteilungen.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvAbteilungen.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvAbteilungen.Appearance.GroupRow.Options.UseFont = true;
            this.grvAbteilungen.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvAbteilungen.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvAbteilungen.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvAbteilungen.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbteilungen.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvAbteilungen.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvAbteilungen.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvAbteilungen.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvAbteilungen.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbteilungen.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvAbteilungen.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvAbteilungen.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvAbteilungen.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvAbteilungen.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvAbteilungen.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvAbteilungen.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbteilungen.Appearance.OddRow.Options.UseFont = true;
            this.grvAbteilungen.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvAbteilungen.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbteilungen.Appearance.Row.Options.UseBackColor = true;
            this.grvAbteilungen.Appearance.Row.Options.UseFont = true;
            this.grvAbteilungen.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbteilungen.Appearance.SelectedRow.Options.UseFont = true;
            this.grvAbteilungen.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvAbteilungen.Appearance.VertLine.Options.UseBackColor = true;
            this.grvAbteilungen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvAbteilungen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAbteilung,
            this.colFunktion,
            this.colMayInsert,
            this.colMayUpdate,
            this.colMayDelete});
            this.grvAbteilungen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvAbteilungen.GridControl = this.grdAbteilungen;
            this.grvAbteilungen.Name = "grvAbteilungen";
            this.grvAbteilungen.OptionsBehavior.Editable = false;
            this.grvAbteilungen.OptionsCustomization.AllowFilter = false;
            this.grvAbteilungen.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvAbteilungen.OptionsNavigation.AutoFocusNewRow = true;
            this.grvAbteilungen.OptionsNavigation.UseTabKey = false;
            this.grvAbteilungen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvAbteilungen.OptionsView.ShowGroupPanel = false;
            this.grvAbteilungen.OptionsView.ShowIndicator = false;
            // 
            // colAbteilung
            // 
            this.colAbteilung.Caption = "Abteilung";
            this.colAbteilung.FieldName = "Abteilung";
            this.colAbteilung.Name = "colAbteilung";
            this.colAbteilung.Visible = true;
            this.colAbteilung.VisibleIndex = 0;
            this.colAbteilung.Width = 400;
            // 
            // colFunktion
            // 
            this.colFunktion.Caption = "Funktion";
            this.colFunktion.FieldName = "Funktion";
            this.colFunktion.Name = "colFunktion";
            this.colFunktion.Visible = true;
            this.colFunktion.VisibleIndex = 1;
            this.colFunktion.Width = 100;
            // 
            // colMayInsert
            // 
            this.colMayInsert.Caption = "E";
            this.colMayInsert.FieldName = "MayInsert";
            this.colMayInsert.Name = "colMayInsert";
            this.colMayInsert.OptionsColumn.AllowSize = false;
            this.colMayInsert.OptionsColumn.FixedWidth = true;
            this.colMayInsert.Visible = true;
            this.colMayInsert.VisibleIndex = 2;
            this.colMayInsert.Width = 20;
            // 
            // colMayUpdate
            // 
            this.colMayUpdate.Caption = "M";
            this.colMayUpdate.FieldName = "MayUpdate";
            this.colMayUpdate.Name = "colMayUpdate";
            this.colMayUpdate.OptionsColumn.AllowSize = false;
            this.colMayUpdate.OptionsColumn.FixedWidth = true;
            this.colMayUpdate.Visible = true;
            this.colMayUpdate.VisibleIndex = 3;
            this.colMayUpdate.Width = 20;
            // 
            // colMayDelete
            // 
            this.colMayDelete.Caption = "L";
            this.colMayDelete.FieldName = "MayDelete";
            this.colMayDelete.Name = "colMayDelete";
            this.colMayDelete.OptionsColumn.AllowSize = false;
            this.colMayDelete.OptionsColumn.FixedWidth = true;
            this.colMayDelete.Visible = true;
            this.colMayDelete.VisibleIndex = 4;
            this.colMayDelete.Width = 20;
            // 
            // tpgPersonaldaten
            // 
            this.tpgPersonaldaten.Controls.Add(this.edtPersonaldatenWeitereKTR);
            this.tpgPersonaldaten.Controls.Add(this.lblPersonaldatenWeitereKTR);
            this.tpgPersonaldaten.Controls.Add(this.edtKeinExport);
            this.tpgPersonaldaten.Controls.Add(this.btnGotoBDEErfassung);
            this.tpgPersonaldaten.Controls.Add(this.btnPersonaldatenWerteAendern);
            this.tpgPersonaldaten.Controls.Add(this.grpPersonaldatenAktuell);
            this.tpgPersonaldaten.Controls.Add(this.edtPersonaldatenLohntyp);
            this.tpgPersonaldaten.Controls.Add(this.lblPersonaldatenLohntyp);
            this.tpgPersonaldaten.Controls.Add(this.edtPersonaldatenStdKTR);
            this.tpgPersonaldaten.Controls.Add(this.lblPersonaldatenStdKTR);
            this.tpgPersonaldaten.Controls.Add(this.edtPersonaldatenStdKA);
            this.tpgPersonaldaten.Controls.Add(this.lblPersonaldatenStdKA);
            this.tpgPersonaldaten.Controls.Add(this.edtPersonaldatenStdKST);
            this.tpgPersonaldaten.Controls.Add(this.lblPersonaldatenStdKS);
            this.tpgPersonaldaten.Controls.Add(this.edtPersonaldatenAustritt);
            this.tpgPersonaldaten.Controls.Add(this.lblPersonaldatenAustritt);
            this.tpgPersonaldaten.Controls.Add(this.edtPersonaldatenEintritt);
            this.tpgPersonaldaten.Controls.Add(this.lblPersonaldatenEintritt);
            this.tpgPersonaldaten.Location = new System.Drawing.Point(6, 6);
            this.tpgPersonaldaten.Name = "tpgPersonaldaten";
            this.tpgPersonaldaten.Size = new System.Drawing.Size(838, 303);
            this.tpgPersonaldaten.TabIndex = 4;
            this.tpgPersonaldaten.Title = "Personaldaten";
            // 
            // edtPersonaldatenWeitereKTR
            // 
            this.edtPersonaldatenWeitereKTR.DataSource = this.qryUser;
            this.edtPersonaldatenWeitereKTR.Location = new System.Drawing.Point(167, 131);
            this.edtPersonaldatenWeitereKTR.Name = "edtPersonaldatenWeitereKTR";
            this.edtPersonaldatenWeitereKTR.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPersonaldatenWeitereKTR.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPersonaldatenWeitereKTR.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPersonaldatenWeitereKTR.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtPersonaldatenWeitereKTR.Properties.Appearance.Options.UseBackColor = true;
            this.edtPersonaldatenWeitereKTR.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPersonaldatenWeitereKTR.Properties.Appearance.Options.UseFont = true;
            this.edtPersonaldatenWeitereKTR.Properties.Appearance.Options.UseForeColor = true;
            this.edtPersonaldatenWeitereKTR.Properties.Appearance.Options.UseTextOptions = true;
            this.edtPersonaldatenWeitereKTR.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtPersonaldatenWeitereKTR.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPersonaldatenWeitereKTR.Size = new System.Drawing.Size(206, 24);
            this.edtPersonaldatenWeitereKTR.TabIndex = 11;
            // 
            // lblPersonaldatenWeitereKTR
            // 
            this.lblPersonaldatenWeitereKTR.Location = new System.Drawing.Point(9, 130);
            this.lblPersonaldatenWeitereKTR.Name = "lblPersonaldatenWeitereKTR";
            this.lblPersonaldatenWeitereKTR.Size = new System.Drawing.Size(152, 24);
            this.lblPersonaldatenWeitereKTR.TabIndex = 10;
            this.lblPersonaldatenWeitereKTR.Text = "Weitere Kostenträger";
            this.lblPersonaldatenWeitereKTR.UseCompatibleTextRendering = true;
            // 
            // edtKeinExport
            // 
            this.edtKeinExport.DataSource = this.qryUser;
            this.edtKeinExport.EditValue = false;
            this.edtKeinExport.Location = new System.Drawing.Point(167, 191);
            this.edtKeinExport.Name = "edtKeinExport";
            this.edtKeinExport.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtKeinExport.Properties.Appearance.Options.UseBackColor = true;
            this.edtKeinExport.Properties.Caption = "Kein Schnittstellen-Export";
            this.edtKeinExport.Size = new System.Drawing.Size(206, 19);
            this.edtKeinExport.TabIndex = 14;
            // 
            // btnGotoBDEErfassung
            // 
            this.btnGotoBDEErfassung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGotoBDEErfassung.Location = new System.Drawing.Point(600, 222);
            this.btnGotoBDEErfassung.Name = "btnGotoBDEErfassung";
            this.btnGotoBDEErfassung.Size = new System.Drawing.Size(128, 24);
            this.btnGotoBDEErfassung.TabIndex = 19;
            this.btnGotoBDEErfassung.Text = "Leistungserfassung";
            this.btnGotoBDEErfassung.UseCompatibleTextRendering = true;
            this.btnGotoBDEErfassung.UseVisualStyleBackColor = false;
            this.btnGotoBDEErfassung.Click += new System.EventHandler(this.btnGotoBDEErfassung_Click);
            // 
            // btnPersonaldatenWerteAendern
            // 
            this.btnPersonaldatenWerteAendern.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPersonaldatenWerteAendern.Location = new System.Drawing.Point(498, 222);
            this.btnPersonaldatenWerteAendern.Name = "btnPersonaldatenWerteAendern";
            this.btnPersonaldatenWerteAendern.Size = new System.Drawing.Size(96, 24);
            this.btnPersonaldatenWerteAendern.TabIndex = 18;
            this.btnPersonaldatenWerteAendern.Text = "Werte ändern";
            this.btnPersonaldatenWerteAendern.UseCompatibleTextRendering = true;
            this.btnPersonaldatenWerteAendern.UseVisualStyleBackColor = false;
            this.btnPersonaldatenWerteAendern.Click += new System.EventHandler(this.btnPersonaldatenWerteAendern_Click);
            // 
            // grpPersonaldatenAktuell
            // 
            this.grpPersonaldatenAktuell.Controls.Add(this.lblPersonaldatenAusbezUeberstunden);
            this.grpPersonaldatenAktuell.Controls.Add(this.lblPersonaldatenAusbezUeberstundenLbl);
            this.grpPersonaldatenAktuell.Controls.Add(this.lblPersonaldatenFerienZugabenKuerzungen);
            this.grpPersonaldatenAktuell.Controls.Add(this.lblPersonaldatenFerienZugabenKuerzungenLbl);
            this.grpPersonaldatenAktuell.Controls.Add(this.lblPersonaldatenFerienanspruch);
            this.grpPersonaldatenAktuell.Controls.Add(this.lblPersonaldatenFerienanspruchLbl);
            this.grpPersonaldatenAktuell.Controls.Add(this.lblPersonaldatenSollProMonat);
            this.grpPersonaldatenAktuell.Controls.Add(this.lblPersonaldatenSollProMonatLbl);
            this.grpPersonaldatenAktuell.Controls.Add(this.lblPersonaldatenSollProTag);
            this.grpPersonaldatenAktuell.Controls.Add(this.lblPersonaldatenSollProTagLbl);
            this.grpPersonaldatenAktuell.Controls.Add(this.lblPersonaldatenPensum);
            this.grpPersonaldatenAktuell.Controls.Add(this.lblPersonaldatenPensumLbl);
            this.grpPersonaldatenAktuell.Controls.Add(this.lblPersonaldatenAktuellerMonat);
            this.grpPersonaldatenAktuell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpPersonaldatenAktuell.Location = new System.Drawing.Point(408, 10);
            this.grpPersonaldatenAktuell.Name = "grpPersonaldatenAktuell";
            this.grpPersonaldatenAktuell.Size = new System.Drawing.Size(320, 206);
            this.grpPersonaldatenAktuell.TabIndex = 17;
            this.grpPersonaldatenAktuell.TabStop = false;
            this.grpPersonaldatenAktuell.Text = "Aktuell erfasste Personaldaten";
            this.grpPersonaldatenAktuell.UseCompatibleTextRendering = true;
            // 
            // lblPersonaldatenAusbezUeberstunden
            // 
            this.lblPersonaldatenAusbezUeberstunden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPersonaldatenAusbezUeberstunden.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblPersonaldatenAusbezUeberstunden.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblPersonaldatenAusbezUeberstunden.Location = new System.Drawing.Point(220, 169);
            this.lblPersonaldatenAusbezUeberstunden.Name = "lblPersonaldatenAusbezUeberstunden";
            this.lblPersonaldatenAusbezUeberstunden.Size = new System.Drawing.Size(87, 24);
            this.lblPersonaldatenAusbezUeberstunden.TabIndex = 12;
            this.lblPersonaldatenAusbezUeberstunden.Text = "0.00 Std.";
            this.lblPersonaldatenAusbezUeberstunden.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPersonaldatenAusbezUeberstunden.UseCompatibleTextRendering = true;
            // 
            // lblPersonaldatenAusbezUeberstundenLbl
            // 
            this.lblPersonaldatenAusbezUeberstundenLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPersonaldatenAusbezUeberstundenLbl.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblPersonaldatenAusbezUeberstundenLbl.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblPersonaldatenAusbezUeberstundenLbl.Location = new System.Drawing.Point(12, 169);
            this.lblPersonaldatenAusbezUeberstundenLbl.Name = "lblPersonaldatenAusbezUeberstundenLbl";
            this.lblPersonaldatenAusbezUeberstundenLbl.Size = new System.Drawing.Size(202, 24);
            this.lblPersonaldatenAusbezUeberstundenLbl.TabIndex = 11;
            this.lblPersonaldatenAusbezUeberstundenLbl.Text = "Ausbezahlte Überstunden";
            this.lblPersonaldatenAusbezUeberstundenLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPersonaldatenAusbezUeberstundenLbl.UseCompatibleTextRendering = true;
            // 
            // lblPersonaldatenFerienZugabenKuerzungen
            // 
            this.lblPersonaldatenFerienZugabenKuerzungen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPersonaldatenFerienZugabenKuerzungen.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblPersonaldatenFerienZugabenKuerzungen.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblPersonaldatenFerienZugabenKuerzungen.Location = new System.Drawing.Point(220, 145);
            this.lblPersonaldatenFerienZugabenKuerzungen.Name = "lblPersonaldatenFerienZugabenKuerzungen";
            this.lblPersonaldatenFerienZugabenKuerzungen.Size = new System.Drawing.Size(87, 24);
            this.lblPersonaldatenFerienZugabenKuerzungen.TabIndex = 10;
            this.lblPersonaldatenFerienZugabenKuerzungen.Text = "0.00 Std.";
            this.lblPersonaldatenFerienZugabenKuerzungen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPersonaldatenFerienZugabenKuerzungen.UseCompatibleTextRendering = true;
            // 
            // lblPersonaldatenFerienZugabenKuerzungenLbl
            // 
            this.lblPersonaldatenFerienZugabenKuerzungenLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPersonaldatenFerienZugabenKuerzungenLbl.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblPersonaldatenFerienZugabenKuerzungenLbl.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblPersonaldatenFerienZugabenKuerzungenLbl.Location = new System.Drawing.Point(12, 145);
            this.lblPersonaldatenFerienZugabenKuerzungenLbl.Name = "lblPersonaldatenFerienZugabenKuerzungenLbl";
            this.lblPersonaldatenFerienZugabenKuerzungenLbl.Size = new System.Drawing.Size(202, 24);
            this.lblPersonaldatenFerienZugabenKuerzungenLbl.TabIndex = 9;
            this.lblPersonaldatenFerienZugabenKuerzungenLbl.Text = "Ferien Zugaben/Kürzungen";
            this.lblPersonaldatenFerienZugabenKuerzungenLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPersonaldatenFerienZugabenKuerzungenLbl.UseCompatibleTextRendering = true;
            // 
            // lblPersonaldatenFerienanspruch
            // 
            this.lblPersonaldatenFerienanspruch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPersonaldatenFerienanspruch.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblPersonaldatenFerienanspruch.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblPersonaldatenFerienanspruch.Location = new System.Drawing.Point(220, 121);
            this.lblPersonaldatenFerienanspruch.Name = "lblPersonaldatenFerienanspruch";
            this.lblPersonaldatenFerienanspruch.Size = new System.Drawing.Size(87, 24);
            this.lblPersonaldatenFerienanspruch.TabIndex = 8;
            this.lblPersonaldatenFerienanspruch.Text = "0.00 Std.";
            this.lblPersonaldatenFerienanspruch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPersonaldatenFerienanspruch.UseCompatibleTextRendering = true;
            // 
            // lblPersonaldatenFerienanspruchLbl
            // 
            this.lblPersonaldatenFerienanspruchLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPersonaldatenFerienanspruchLbl.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblPersonaldatenFerienanspruchLbl.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblPersonaldatenFerienanspruchLbl.Location = new System.Drawing.Point(12, 121);
            this.lblPersonaldatenFerienanspruchLbl.Name = "lblPersonaldatenFerienanspruchLbl";
            this.lblPersonaldatenFerienanspruchLbl.Size = new System.Drawing.Size(202, 24);
            this.lblPersonaldatenFerienanspruchLbl.TabIndex = 7;
            this.lblPersonaldatenFerienanspruchLbl.Text = "Ferien Anspruch pro Jahr";
            this.lblPersonaldatenFerienanspruchLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPersonaldatenFerienanspruchLbl.UseCompatibleTextRendering = true;
            // 
            // lblPersonaldatenSollProMonat
            // 
            this.lblPersonaldatenSollProMonat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPersonaldatenSollProMonat.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblPersonaldatenSollProMonat.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblPersonaldatenSollProMonat.Location = new System.Drawing.Point(220, 97);
            this.lblPersonaldatenSollProMonat.Name = "lblPersonaldatenSollProMonat";
            this.lblPersonaldatenSollProMonat.Size = new System.Drawing.Size(87, 24);
            this.lblPersonaldatenSollProMonat.TabIndex = 6;
            this.lblPersonaldatenSollProMonat.Text = "0.00 Std.";
            this.lblPersonaldatenSollProMonat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPersonaldatenSollProMonat.UseCompatibleTextRendering = true;
            // 
            // lblPersonaldatenSollProMonatLbl
            // 
            this.lblPersonaldatenSollProMonatLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPersonaldatenSollProMonatLbl.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblPersonaldatenSollProMonatLbl.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblPersonaldatenSollProMonatLbl.Location = new System.Drawing.Point(12, 97);
            this.lblPersonaldatenSollProMonatLbl.Name = "lblPersonaldatenSollProMonatLbl";
            this.lblPersonaldatenSollProMonatLbl.Size = new System.Drawing.Size(202, 24);
            this.lblPersonaldatenSollProMonatLbl.TabIndex = 5;
            this.lblPersonaldatenSollProMonatLbl.Text = "SOLL-Zeit aktueller Monat";
            this.lblPersonaldatenSollProMonatLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPersonaldatenSollProMonatLbl.UseCompatibleTextRendering = true;
            // 
            // lblPersonaldatenSollProTag
            // 
            this.lblPersonaldatenSollProTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPersonaldatenSollProTag.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblPersonaldatenSollProTag.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblPersonaldatenSollProTag.Location = new System.Drawing.Point(220, 73);
            this.lblPersonaldatenSollProTag.Name = "lblPersonaldatenSollProTag";
            this.lblPersonaldatenSollProTag.Size = new System.Drawing.Size(87, 24);
            this.lblPersonaldatenSollProTag.TabIndex = 4;
            this.lblPersonaldatenSollProTag.Text = "0.00 Std.";
            this.lblPersonaldatenSollProTag.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPersonaldatenSollProTag.UseCompatibleTextRendering = true;
            // 
            // lblPersonaldatenSollProTagLbl
            // 
            this.lblPersonaldatenSollProTagLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPersonaldatenSollProTagLbl.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblPersonaldatenSollProTagLbl.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblPersonaldatenSollProTagLbl.Location = new System.Drawing.Point(12, 73);
            this.lblPersonaldatenSollProTagLbl.Name = "lblPersonaldatenSollProTagLbl";
            this.lblPersonaldatenSollProTagLbl.Size = new System.Drawing.Size(202, 24);
            this.lblPersonaldatenSollProTagLbl.TabIndex = 3;
            this.lblPersonaldatenSollProTagLbl.Text = "SOLL-Arbeitszeit pro Tag";
            this.lblPersonaldatenSollProTagLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPersonaldatenSollProTagLbl.UseCompatibleTextRendering = true;
            // 
            // lblPersonaldatenPensum
            // 
            this.lblPersonaldatenPensum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPersonaldatenPensum.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblPersonaldatenPensum.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblPersonaldatenPensum.Location = new System.Drawing.Point(220, 49);
            this.lblPersonaldatenPensum.Name = "lblPersonaldatenPensum";
            this.lblPersonaldatenPensum.Size = new System.Drawing.Size(87, 24);
            this.lblPersonaldatenPensum.TabIndex = 2;
            this.lblPersonaldatenPensum.Text = "000 %";
            this.lblPersonaldatenPensum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPersonaldatenPensum.UseCompatibleTextRendering = true;
            // 
            // lblPersonaldatenPensumLbl
            // 
            this.lblPersonaldatenPensumLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPersonaldatenPensumLbl.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblPersonaldatenPensumLbl.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblPersonaldatenPensumLbl.Location = new System.Drawing.Point(12, 49);
            this.lblPersonaldatenPensumLbl.Name = "lblPersonaldatenPensumLbl";
            this.lblPersonaldatenPensumLbl.Size = new System.Drawing.Size(202, 24);
            this.lblPersonaldatenPensumLbl.TabIndex = 1;
            this.lblPersonaldatenPensumLbl.Text = "Beschäftigungsgrad";
            this.lblPersonaldatenPensumLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPersonaldatenPensumLbl.UseCompatibleTextRendering = true;
            // 
            // lblPersonaldatenAktuellerMonat
            // 
            this.lblPersonaldatenAktuellerMonat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPersonaldatenAktuellerMonat.Font = new System.Drawing.Font("Arial", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel);
            this.lblPersonaldatenAktuellerMonat.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblPersonaldatenAktuellerMonat.Location = new System.Drawing.Point(12, 18);
            this.lblPersonaldatenAktuellerMonat.Name = "lblPersonaldatenAktuellerMonat";
            this.lblPersonaldatenAktuellerMonat.Size = new System.Drawing.Size(295, 24);
            this.lblPersonaldatenAktuellerMonat.TabIndex = 0;
            this.lblPersonaldatenAktuellerMonat.Text = "<mmmm yyyy>";
            this.lblPersonaldatenAktuellerMonat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPersonaldatenAktuellerMonat.UseCompatibleTextRendering = true;
            // 
            // edtPersonaldatenLohntyp
            // 
            this.edtPersonaldatenLohntyp.DataSource = this.qryUser;
            this.edtPersonaldatenLohntyp.Location = new System.Drawing.Point(167, 161);
            this.edtPersonaldatenLohntyp.LOVName = "BenutzerLohnTyp";
            this.edtPersonaldatenLohntyp.Name = "edtPersonaldatenLohntyp";
            this.edtPersonaldatenLohntyp.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPersonaldatenLohntyp.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPersonaldatenLohntyp.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPersonaldatenLohntyp.Properties.Appearance.Options.UseBackColor = true;
            this.edtPersonaldatenLohntyp.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPersonaldatenLohntyp.Properties.Appearance.Options.UseFont = true;
            this.edtPersonaldatenLohntyp.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtPersonaldatenLohntyp.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtPersonaldatenLohntyp.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtPersonaldatenLohntyp.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtPersonaldatenLohntyp.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtPersonaldatenLohntyp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtPersonaldatenLohntyp.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPersonaldatenLohntyp.Properties.NullText = "";
            this.edtPersonaldatenLohntyp.Properties.ShowFooter = false;
            this.edtPersonaldatenLohntyp.Properties.ShowHeader = false;
            this.edtPersonaldatenLohntyp.Size = new System.Drawing.Size(206, 24);
            this.edtPersonaldatenLohntyp.TabIndex = 13;
            // 
            // lblPersonaldatenLohntyp
            // 
            this.lblPersonaldatenLohntyp.Location = new System.Drawing.Point(9, 161);
            this.lblPersonaldatenLohntyp.Name = "lblPersonaldatenLohntyp";
            this.lblPersonaldatenLohntyp.Size = new System.Drawing.Size(152, 24);
            this.lblPersonaldatenLohntyp.TabIndex = 12;
            this.lblPersonaldatenLohntyp.Text = "Lohntyp";
            this.lblPersonaldatenLohntyp.UseCompatibleTextRendering = true;
            // 
            // edtPersonaldatenStdKTR
            // 
            this.edtPersonaldatenStdKTR.DataSource = this.qryUser;
            this.edtPersonaldatenStdKTR.Location = new System.Drawing.Point(167, 109);
            this.edtPersonaldatenStdKTR.Name = "edtPersonaldatenStdKTR";
            this.edtPersonaldatenStdKTR.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtPersonaldatenStdKTR.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPersonaldatenStdKTR.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPersonaldatenStdKTR.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPersonaldatenStdKTR.Properties.Appearance.Options.UseBackColor = true;
            this.edtPersonaldatenStdKTR.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPersonaldatenStdKTR.Properties.Appearance.Options.UseFont = true;
            this.edtPersonaldatenStdKTR.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPersonaldatenStdKTR.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPersonaldatenStdKTR.Size = new System.Drawing.Size(206, 24);
            this.edtPersonaldatenStdKTR.TabIndex = 9;
            // 
            // lblPersonaldatenStdKTR
            // 
            this.lblPersonaldatenStdKTR.Location = new System.Drawing.Point(9, 108);
            this.lblPersonaldatenStdKTR.Name = "lblPersonaldatenStdKTR";
            this.lblPersonaldatenStdKTR.Size = new System.Drawing.Size(152, 24);
            this.lblPersonaldatenStdKTR.TabIndex = 8;
            this.lblPersonaldatenStdKTR.Text = "Standard-Kostenträger";
            this.lblPersonaldatenStdKTR.UseCompatibleTextRendering = true;
            // 
            // edtPersonaldatenStdKA
            // 
            this.edtPersonaldatenStdKA.DataSource = this.qryUser;
            this.edtPersonaldatenStdKA.Location = new System.Drawing.Point(167, 86);
            this.edtPersonaldatenStdKA.Name = "edtPersonaldatenStdKA";
            this.edtPersonaldatenStdKA.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtPersonaldatenStdKA.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPersonaldatenStdKA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPersonaldatenStdKA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPersonaldatenStdKA.Properties.Appearance.Options.UseBackColor = true;
            this.edtPersonaldatenStdKA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPersonaldatenStdKA.Properties.Appearance.Options.UseFont = true;
            this.edtPersonaldatenStdKA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPersonaldatenStdKA.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPersonaldatenStdKA.Size = new System.Drawing.Size(206, 24);
            this.edtPersonaldatenStdKA.TabIndex = 7;
            // 
            // lblPersonaldatenStdKA
            // 
            this.lblPersonaldatenStdKA.Location = new System.Drawing.Point(9, 86);
            this.lblPersonaldatenStdKA.Name = "lblPersonaldatenStdKA";
            this.lblPersonaldatenStdKA.Size = new System.Drawing.Size(152, 24);
            this.lblPersonaldatenStdKA.TabIndex = 6;
            this.lblPersonaldatenStdKA.Text = "Standard-Kostenart";
            this.lblPersonaldatenStdKA.UseCompatibleTextRendering = true;
            // 
            // edtPersonaldatenStdKST
            // 
            this.edtPersonaldatenStdKST.DataSource = this.qryUser;
            this.edtPersonaldatenStdKST.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPersonaldatenStdKST.Location = new System.Drawing.Point(167, 63);
            this.edtPersonaldatenStdKST.Name = "edtPersonaldatenStdKST";
            this.edtPersonaldatenStdKST.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPersonaldatenStdKST.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPersonaldatenStdKST.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPersonaldatenStdKST.Properties.Appearance.Options.UseBackColor = true;
            this.edtPersonaldatenStdKST.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPersonaldatenStdKST.Properties.Appearance.Options.UseFont = true;
            this.edtPersonaldatenStdKST.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPersonaldatenStdKST.Properties.ReadOnly = true;
            this.edtPersonaldatenStdKST.Size = new System.Drawing.Size(206, 24);
            this.edtPersonaldatenStdKST.TabIndex = 5;
            // 
            // lblPersonaldatenStdKS
            // 
            this.lblPersonaldatenStdKS.Location = new System.Drawing.Point(9, 63);
            this.lblPersonaldatenStdKS.Name = "lblPersonaldatenStdKS";
            this.lblPersonaldatenStdKS.Size = new System.Drawing.Size(152, 24);
            this.lblPersonaldatenStdKS.TabIndex = 4;
            this.lblPersonaldatenStdKS.Text = "Standard-Kostenstelle";
            this.lblPersonaldatenStdKS.UseCompatibleTextRendering = true;
            // 
            // edtPersonaldatenAustritt
            // 
            this.edtPersonaldatenAustritt.DataSource = this.qryUser;
            this.edtPersonaldatenAustritt.EditValue = null;
            this.edtPersonaldatenAustritt.Location = new System.Drawing.Point(167, 33);
            this.edtPersonaldatenAustritt.Name = "edtPersonaldatenAustritt";
            this.edtPersonaldatenAustritt.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtPersonaldatenAustritt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPersonaldatenAustritt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPersonaldatenAustritt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPersonaldatenAustritt.Properties.Appearance.Options.UseBackColor = true;
            this.edtPersonaldatenAustritt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPersonaldatenAustritt.Properties.Appearance.Options.UseFont = true;
            this.edtPersonaldatenAustritt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtPersonaldatenAustritt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtPersonaldatenAustritt.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtPersonaldatenAustritt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPersonaldatenAustritt.Properties.ShowToday = false;
            this.edtPersonaldatenAustritt.Size = new System.Drawing.Size(100, 24);
            this.edtPersonaldatenAustritt.TabIndex = 3;
            // 
            // lblPersonaldatenAustritt
            // 
            this.lblPersonaldatenAustritt.Location = new System.Drawing.Point(9, 33);
            this.lblPersonaldatenAustritt.Name = "lblPersonaldatenAustritt";
            this.lblPersonaldatenAustritt.Size = new System.Drawing.Size(152, 24);
            this.lblPersonaldatenAustritt.TabIndex = 2;
            this.lblPersonaldatenAustritt.Text = "Austrittsdatum";
            this.lblPersonaldatenAustritt.UseCompatibleTextRendering = true;
            // 
            // edtPersonaldatenEintritt
            // 
            this.edtPersonaldatenEintritt.DataSource = this.qryUser;
            this.edtPersonaldatenEintritt.EditValue = null;
            this.edtPersonaldatenEintritt.Location = new System.Drawing.Point(167, 10);
            this.edtPersonaldatenEintritt.Name = "edtPersonaldatenEintritt";
            this.edtPersonaldatenEintritt.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtPersonaldatenEintritt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPersonaldatenEintritt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPersonaldatenEintritt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPersonaldatenEintritt.Properties.Appearance.Options.UseBackColor = true;
            this.edtPersonaldatenEintritt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPersonaldatenEintritt.Properties.Appearance.Options.UseFont = true;
            this.edtPersonaldatenEintritt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtPersonaldatenEintritt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtPersonaldatenEintritt.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.edtPersonaldatenEintritt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPersonaldatenEintritt.Properties.ShowToday = false;
            this.edtPersonaldatenEintritt.Size = new System.Drawing.Size(100, 24);
            this.edtPersonaldatenEintritt.TabIndex = 1;
            // 
            // lblPersonaldatenEintritt
            // 
            this.lblPersonaldatenEintritt.Location = new System.Drawing.Point(9, 10);
            this.lblPersonaldatenEintritt.Name = "lblPersonaldatenEintritt";
            this.lblPersonaldatenEintritt.Size = new System.Drawing.Size(152, 24);
            this.lblPersonaldatenEintritt.TabIndex = 0;
            this.lblPersonaldatenEintritt.Text = "Eintrittsdatum";
            this.lblPersonaldatenEintritt.UseCompatibleTextRendering = true;
            // 
            // tpgStundenansatz
            // 
            this.tpgStundenansatz.Controls.Add(this.edtStundenansatz20);
            this.tpgStundenansatz.Controls.Add(this.edtStundenansatz10);
            this.tpgStundenansatz.Controls.Add(this.edtStundenansatz19);
            this.tpgStundenansatz.Controls.Add(this.edtStundenansatz9);
            this.tpgStundenansatz.Controls.Add(this.edtStundenansatz18);
            this.tpgStundenansatz.Controls.Add(this.edtStundenansatz8);
            this.tpgStundenansatz.Controls.Add(this.edtStundenansatz17);
            this.tpgStundenansatz.Controls.Add(this.edtStundenansatz7);
            this.tpgStundenansatz.Controls.Add(this.edtStundenansatz16);
            this.tpgStundenansatz.Controls.Add(this.edtStundenansatz6);
            this.tpgStundenansatz.Controls.Add(this.edtStundenansatz15);
            this.tpgStundenansatz.Controls.Add(this.edtStundenansatz5);
            this.tpgStundenansatz.Controls.Add(this.edtStundenansatz14);
            this.tpgStundenansatz.Controls.Add(this.edtStundenansatz4);
            this.tpgStundenansatz.Controls.Add(this.edtStundenansatz13);
            this.tpgStundenansatz.Controls.Add(this.edtStundenansatz3);
            this.tpgStundenansatz.Controls.Add(this.edtStundenansatz12);
            this.tpgStundenansatz.Controls.Add(this.edtStundenansatz2);
            this.tpgStundenansatz.Controls.Add(this.edtStundenansatz11);
            this.tpgStundenansatz.Controls.Add(this.edtStundenansatz1);
            this.tpgStundenansatz.Controls.Add(this.lblStundenansatz20);
            this.tpgStundenansatz.Controls.Add(this.lblStundenansatz10);
            this.tpgStundenansatz.Controls.Add(this.lblStundenansatz19);
            this.tpgStundenansatz.Controls.Add(this.lblStundenansatz9);
            this.tpgStundenansatz.Controls.Add(this.lblStundenansatz18);
            this.tpgStundenansatz.Controls.Add(this.lblStundenansatz8);
            this.tpgStundenansatz.Controls.Add(this.lblStundenansatz17);
            this.tpgStundenansatz.Controls.Add(this.lblStundenansatz7);
            this.tpgStundenansatz.Controls.Add(this.lblStundenansatz16);
            this.tpgStundenansatz.Controls.Add(this.lblStundenansatz6);
            this.tpgStundenansatz.Controls.Add(this.lblStundenansatz15);
            this.tpgStundenansatz.Controls.Add(this.lblStundenansatz5);
            this.tpgStundenansatz.Controls.Add(this.lblStundenansatz14);
            this.tpgStundenansatz.Controls.Add(this.lblStundenansatz4);
            this.tpgStundenansatz.Controls.Add(this.lblStundenansatz13);
            this.tpgStundenansatz.Controls.Add(this.lblStundenansatz3);
            this.tpgStundenansatz.Controls.Add(this.lblStundenansatz12);
            this.tpgStundenansatz.Controls.Add(this.lblStundenansatz2);
            this.tpgStundenansatz.Controls.Add(this.lblStundenansatz11);
            this.tpgStundenansatz.Controls.Add(this.lblStundenansatz1);
            this.tpgStundenansatz.Location = new System.Drawing.Point(6, 6);
            this.tpgStundenansatz.Name = "tpgStundenansatz";
            this.tpgStundenansatz.Size = new System.Drawing.Size(838, 303);
            this.tpgStundenansatz.TabIndex = 8;
            this.tpgStundenansatz.Title = "Stundenansatz";
            // 
            // edtStundenansatz20
            // 
            this.edtStundenansatz20.DataSource = this.qryXUserStundenansatz;
            this.edtStundenansatz20.Location = new System.Drawing.Point(462, 280);
            this.edtStundenansatz20.Name = "edtStundenansatz20";
            this.edtStundenansatz20.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtStundenansatz20.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStundenansatz20.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStundenansatz20.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStundenansatz20.Properties.Appearance.Options.UseBackColor = true;
            this.edtStundenansatz20.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStundenansatz20.Properties.Appearance.Options.UseFont = true;
            this.edtStundenansatz20.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStundenansatz20.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStundenansatz20.Properties.DisplayFormat.FormatString = "n2";
            this.edtStundenansatz20.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz20.Properties.EditFormat.FormatString = "n2";
            this.edtStundenansatz20.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz20.Properties.Mask.EditMask = "n2";
            this.edtStundenansatz20.Size = new System.Drawing.Size(100, 24);
            this.edtStundenansatz20.TabIndex = 39;
            // 
            // qryXUserStundenansatz
            // 
            this.qryXUserStundenansatz.CanDelete = true;
            this.qryXUserStundenansatz.CanInsert = true;
            this.qryXUserStundenansatz.CanUpdate = true;
            this.qryXUserStundenansatz.HostControl = this;
            this.qryXUserStundenansatz.TableName = "XUserStundenansatz";
            this.qryXUserStundenansatz.AfterInsert += new System.EventHandler(this.qryXUserStundenansatz_AfterInsert);
            this.qryXUserStundenansatz.BeforePost += new System.EventHandler(this.qryXUserStundenansatz_BeforePost);
            // 
            // edtStundenansatz10
            // 
            this.edtStundenansatz10.DataSource = this.qryXUserStundenansatz;
            this.edtStundenansatz10.Location = new System.Drawing.Point(165, 280);
            this.edtStundenansatz10.Name = "edtStundenansatz10";
            this.edtStundenansatz10.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtStundenansatz10.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStundenansatz10.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStundenansatz10.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStundenansatz10.Properties.Appearance.Options.UseBackColor = true;
            this.edtStundenansatz10.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStundenansatz10.Properties.Appearance.Options.UseFont = true;
            this.edtStundenansatz10.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStundenansatz10.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStundenansatz10.Properties.DisplayFormat.FormatString = "n2";
            this.edtStundenansatz10.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz10.Properties.EditFormat.FormatString = "n2";
            this.edtStundenansatz10.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz10.Properties.Mask.EditMask = "n2";
            this.edtStundenansatz10.Size = new System.Drawing.Size(100, 24);
            this.edtStundenansatz10.TabIndex = 19;
            // 
            // edtStundenansatz19
            // 
            this.edtStundenansatz19.DataSource = this.qryXUserStundenansatz;
            this.edtStundenansatz19.Location = new System.Drawing.Point(462, 250);
            this.edtStundenansatz19.Name = "edtStundenansatz19";
            this.edtStundenansatz19.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtStundenansatz19.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStundenansatz19.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStundenansatz19.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStundenansatz19.Properties.Appearance.Options.UseBackColor = true;
            this.edtStundenansatz19.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStundenansatz19.Properties.Appearance.Options.UseFont = true;
            this.edtStundenansatz19.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStundenansatz19.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStundenansatz19.Properties.DisplayFormat.FormatString = "n2";
            this.edtStundenansatz19.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz19.Properties.EditFormat.FormatString = "n2";
            this.edtStundenansatz19.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz19.Properties.Mask.EditMask = "n2";
            this.edtStundenansatz19.Size = new System.Drawing.Size(100, 24);
            this.edtStundenansatz19.TabIndex = 37;
            // 
            // edtStundenansatz9
            // 
            this.edtStundenansatz9.DataSource = this.qryXUserStundenansatz;
            this.edtStundenansatz9.Location = new System.Drawing.Point(165, 250);
            this.edtStundenansatz9.Name = "edtStundenansatz9";
            this.edtStundenansatz9.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtStundenansatz9.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStundenansatz9.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStundenansatz9.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStundenansatz9.Properties.Appearance.Options.UseBackColor = true;
            this.edtStundenansatz9.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStundenansatz9.Properties.Appearance.Options.UseFont = true;
            this.edtStundenansatz9.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStundenansatz9.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStundenansatz9.Properties.DisplayFormat.FormatString = "n2";
            this.edtStundenansatz9.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz9.Properties.EditFormat.FormatString = "n2";
            this.edtStundenansatz9.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz9.Properties.Mask.EditMask = "n2";
            this.edtStundenansatz9.Size = new System.Drawing.Size(100, 24);
            this.edtStundenansatz9.TabIndex = 17;
            // 
            // edtStundenansatz18
            // 
            this.edtStundenansatz18.DataSource = this.qryXUserStundenansatz;
            this.edtStundenansatz18.Location = new System.Drawing.Point(462, 220);
            this.edtStundenansatz18.Name = "edtStundenansatz18";
            this.edtStundenansatz18.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtStundenansatz18.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStundenansatz18.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStundenansatz18.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStundenansatz18.Properties.Appearance.Options.UseBackColor = true;
            this.edtStundenansatz18.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStundenansatz18.Properties.Appearance.Options.UseFont = true;
            this.edtStundenansatz18.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStundenansatz18.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStundenansatz18.Properties.DisplayFormat.FormatString = "n2";
            this.edtStundenansatz18.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz18.Properties.EditFormat.FormatString = "n2";
            this.edtStundenansatz18.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz18.Properties.Mask.EditMask = "n2";
            this.edtStundenansatz18.Size = new System.Drawing.Size(100, 24);
            this.edtStundenansatz18.TabIndex = 35;
            // 
            // edtStundenansatz8
            // 
            this.edtStundenansatz8.DataSource = this.qryXUserStundenansatz;
            this.edtStundenansatz8.Location = new System.Drawing.Point(165, 220);
            this.edtStundenansatz8.Name = "edtStundenansatz8";
            this.edtStundenansatz8.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtStundenansatz8.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStundenansatz8.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStundenansatz8.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStundenansatz8.Properties.Appearance.Options.UseBackColor = true;
            this.edtStundenansatz8.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStundenansatz8.Properties.Appearance.Options.UseFont = true;
            this.edtStundenansatz8.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStundenansatz8.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStundenansatz8.Properties.DisplayFormat.FormatString = "n2";
            this.edtStundenansatz8.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz8.Properties.EditFormat.FormatString = "n2";
            this.edtStundenansatz8.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz8.Properties.Mask.EditMask = "n2";
            this.edtStundenansatz8.Size = new System.Drawing.Size(100, 24);
            this.edtStundenansatz8.TabIndex = 15;
            // 
            // edtStundenansatz17
            // 
            this.edtStundenansatz17.DataSource = this.qryXUserStundenansatz;
            this.edtStundenansatz17.Location = new System.Drawing.Point(462, 190);
            this.edtStundenansatz17.Name = "edtStundenansatz17";
            this.edtStundenansatz17.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtStundenansatz17.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStundenansatz17.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStundenansatz17.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStundenansatz17.Properties.Appearance.Options.UseBackColor = true;
            this.edtStundenansatz17.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStundenansatz17.Properties.Appearance.Options.UseFont = true;
            this.edtStundenansatz17.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStundenansatz17.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStundenansatz17.Properties.DisplayFormat.FormatString = "n2";
            this.edtStundenansatz17.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz17.Properties.EditFormat.FormatString = "n2";
            this.edtStundenansatz17.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz17.Properties.Mask.EditMask = "n2";
            this.edtStundenansatz17.Size = new System.Drawing.Size(100, 24);
            this.edtStundenansatz17.TabIndex = 33;
            // 
            // edtStundenansatz7
            // 
            this.edtStundenansatz7.DataSource = this.qryXUserStundenansatz;
            this.edtStundenansatz7.Location = new System.Drawing.Point(165, 190);
            this.edtStundenansatz7.Name = "edtStundenansatz7";
            this.edtStundenansatz7.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtStundenansatz7.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStundenansatz7.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStundenansatz7.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStundenansatz7.Properties.Appearance.Options.UseBackColor = true;
            this.edtStundenansatz7.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStundenansatz7.Properties.Appearance.Options.UseFont = true;
            this.edtStundenansatz7.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStundenansatz7.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStundenansatz7.Properties.DisplayFormat.FormatString = "n2";
            this.edtStundenansatz7.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz7.Properties.EditFormat.FormatString = "n2";
            this.edtStundenansatz7.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz7.Properties.Mask.EditMask = "n2";
            this.edtStundenansatz7.Size = new System.Drawing.Size(100, 24);
            this.edtStundenansatz7.TabIndex = 13;
            // 
            // edtStundenansatz16
            // 
            this.edtStundenansatz16.DataSource = this.qryXUserStundenansatz;
            this.edtStundenansatz16.Location = new System.Drawing.Point(462, 160);
            this.edtStundenansatz16.Name = "edtStundenansatz16";
            this.edtStundenansatz16.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtStundenansatz16.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStundenansatz16.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStundenansatz16.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStundenansatz16.Properties.Appearance.Options.UseBackColor = true;
            this.edtStundenansatz16.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStundenansatz16.Properties.Appearance.Options.UseFont = true;
            this.edtStundenansatz16.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStundenansatz16.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStundenansatz16.Properties.DisplayFormat.FormatString = "n2";
            this.edtStundenansatz16.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz16.Properties.EditFormat.FormatString = "n2";
            this.edtStundenansatz16.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz16.Properties.Mask.EditMask = "n2";
            this.edtStundenansatz16.Size = new System.Drawing.Size(100, 24);
            this.edtStundenansatz16.TabIndex = 31;
            // 
            // edtStundenansatz6
            // 
            this.edtStundenansatz6.DataSource = this.qryXUserStundenansatz;
            this.edtStundenansatz6.Location = new System.Drawing.Point(165, 160);
            this.edtStundenansatz6.Name = "edtStundenansatz6";
            this.edtStundenansatz6.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtStundenansatz6.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStundenansatz6.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStundenansatz6.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStundenansatz6.Properties.Appearance.Options.UseBackColor = true;
            this.edtStundenansatz6.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStundenansatz6.Properties.Appearance.Options.UseFont = true;
            this.edtStundenansatz6.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStundenansatz6.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStundenansatz6.Properties.DisplayFormat.FormatString = "n2";
            this.edtStundenansatz6.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz6.Properties.EditFormat.FormatString = "n2";
            this.edtStundenansatz6.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz6.Properties.Mask.EditMask = "n2";
            this.edtStundenansatz6.Size = new System.Drawing.Size(100, 24);
            this.edtStundenansatz6.TabIndex = 11;
            // 
            // edtStundenansatz15
            // 
            this.edtStundenansatz15.DataSource = this.qryXUserStundenansatz;
            this.edtStundenansatz15.Location = new System.Drawing.Point(462, 130);
            this.edtStundenansatz15.Name = "edtStundenansatz15";
            this.edtStundenansatz15.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtStundenansatz15.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStundenansatz15.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStundenansatz15.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStundenansatz15.Properties.Appearance.Options.UseBackColor = true;
            this.edtStundenansatz15.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStundenansatz15.Properties.Appearance.Options.UseFont = true;
            this.edtStundenansatz15.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStundenansatz15.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStundenansatz15.Properties.DisplayFormat.FormatString = "n2";
            this.edtStundenansatz15.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz15.Properties.EditFormat.FormatString = "n2";
            this.edtStundenansatz15.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz15.Properties.Mask.EditMask = "n2";
            this.edtStundenansatz15.Size = new System.Drawing.Size(100, 24);
            this.edtStundenansatz15.TabIndex = 29;
            // 
            // edtStundenansatz5
            // 
            this.edtStundenansatz5.DataSource = this.qryXUserStundenansatz;
            this.edtStundenansatz5.Location = new System.Drawing.Point(165, 130);
            this.edtStundenansatz5.Name = "edtStundenansatz5";
            this.edtStundenansatz5.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtStundenansatz5.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStundenansatz5.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStundenansatz5.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStundenansatz5.Properties.Appearance.Options.UseBackColor = true;
            this.edtStundenansatz5.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStundenansatz5.Properties.Appearance.Options.UseFont = true;
            this.edtStundenansatz5.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStundenansatz5.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStundenansatz5.Properties.DisplayFormat.FormatString = "n2";
            this.edtStundenansatz5.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz5.Properties.EditFormat.FormatString = "n2";
            this.edtStundenansatz5.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz5.Properties.Mask.EditMask = "n2";
            this.edtStundenansatz5.Size = new System.Drawing.Size(100, 24);
            this.edtStundenansatz5.TabIndex = 9;
            // 
            // edtStundenansatz14
            // 
            this.edtStundenansatz14.DataSource = this.qryXUserStundenansatz;
            this.edtStundenansatz14.Location = new System.Drawing.Point(462, 100);
            this.edtStundenansatz14.Name = "edtStundenansatz14";
            this.edtStundenansatz14.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtStundenansatz14.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStundenansatz14.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStundenansatz14.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStundenansatz14.Properties.Appearance.Options.UseBackColor = true;
            this.edtStundenansatz14.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStundenansatz14.Properties.Appearance.Options.UseFont = true;
            this.edtStundenansatz14.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStundenansatz14.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStundenansatz14.Properties.DisplayFormat.FormatString = "n2";
            this.edtStundenansatz14.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz14.Properties.EditFormat.FormatString = "n2";
            this.edtStundenansatz14.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz14.Properties.Mask.EditMask = "n2";
            this.edtStundenansatz14.Size = new System.Drawing.Size(100, 24);
            this.edtStundenansatz14.TabIndex = 27;
            // 
            // edtStundenansatz4
            // 
            this.edtStundenansatz4.DataSource = this.qryXUserStundenansatz;
            this.edtStundenansatz4.Location = new System.Drawing.Point(165, 100);
            this.edtStundenansatz4.Name = "edtStundenansatz4";
            this.edtStundenansatz4.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtStundenansatz4.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStundenansatz4.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStundenansatz4.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStundenansatz4.Properties.Appearance.Options.UseBackColor = true;
            this.edtStundenansatz4.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStundenansatz4.Properties.Appearance.Options.UseFont = true;
            this.edtStundenansatz4.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStundenansatz4.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStundenansatz4.Properties.DisplayFormat.FormatString = "n2";
            this.edtStundenansatz4.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz4.Properties.EditFormat.FormatString = "n2";
            this.edtStundenansatz4.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz4.Properties.Mask.EditMask = "n2";
            this.edtStundenansatz4.Size = new System.Drawing.Size(100, 24);
            this.edtStundenansatz4.TabIndex = 7;
            // 
            // edtStundenansatz13
            // 
            this.edtStundenansatz13.DataSource = this.qryXUserStundenansatz;
            this.edtStundenansatz13.Location = new System.Drawing.Point(462, 70);
            this.edtStundenansatz13.Name = "edtStundenansatz13";
            this.edtStundenansatz13.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtStundenansatz13.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStundenansatz13.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStundenansatz13.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStundenansatz13.Properties.Appearance.Options.UseBackColor = true;
            this.edtStundenansatz13.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStundenansatz13.Properties.Appearance.Options.UseFont = true;
            this.edtStundenansatz13.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStundenansatz13.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStundenansatz13.Properties.DisplayFormat.FormatString = "n2";
            this.edtStundenansatz13.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz13.Properties.EditFormat.FormatString = "n2";
            this.edtStundenansatz13.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz13.Properties.Mask.EditMask = "n2";
            this.edtStundenansatz13.Size = new System.Drawing.Size(100, 24);
            this.edtStundenansatz13.TabIndex = 25;
            // 
            // edtStundenansatz3
            // 
            this.edtStundenansatz3.DataSource = this.qryXUserStundenansatz;
            this.edtStundenansatz3.Location = new System.Drawing.Point(165, 70);
            this.edtStundenansatz3.Name = "edtStundenansatz3";
            this.edtStundenansatz3.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtStundenansatz3.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStundenansatz3.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStundenansatz3.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStundenansatz3.Properties.Appearance.Options.UseBackColor = true;
            this.edtStundenansatz3.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStundenansatz3.Properties.Appearance.Options.UseFont = true;
            this.edtStundenansatz3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStundenansatz3.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStundenansatz3.Properties.DisplayFormat.FormatString = "n2";
            this.edtStundenansatz3.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz3.Properties.EditFormat.FormatString = "n2";
            this.edtStundenansatz3.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz3.Properties.Mask.EditMask = "n2";
            this.edtStundenansatz3.Size = new System.Drawing.Size(100, 24);
            this.edtStundenansatz3.TabIndex = 5;
            // 
            // edtStundenansatz12
            // 
            this.edtStundenansatz12.DataSource = this.qryXUserStundenansatz;
            this.edtStundenansatz12.Location = new System.Drawing.Point(462, 40);
            this.edtStundenansatz12.Name = "edtStundenansatz12";
            this.edtStundenansatz12.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtStundenansatz12.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStundenansatz12.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStundenansatz12.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStundenansatz12.Properties.Appearance.Options.UseBackColor = true;
            this.edtStundenansatz12.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStundenansatz12.Properties.Appearance.Options.UseFont = true;
            this.edtStundenansatz12.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStundenansatz12.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStundenansatz12.Properties.DisplayFormat.FormatString = "n2";
            this.edtStundenansatz12.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz12.Properties.EditFormat.FormatString = "n2";
            this.edtStundenansatz12.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz12.Properties.Mask.EditMask = "n2";
            this.edtStundenansatz12.Size = new System.Drawing.Size(100, 24);
            this.edtStundenansatz12.TabIndex = 23;
            // 
            // edtStundenansatz2
            // 
            this.edtStundenansatz2.DataSource = this.qryXUserStundenansatz;
            this.edtStundenansatz2.Location = new System.Drawing.Point(165, 40);
            this.edtStundenansatz2.Name = "edtStundenansatz2";
            this.edtStundenansatz2.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtStundenansatz2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStundenansatz2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStundenansatz2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStundenansatz2.Properties.Appearance.Options.UseBackColor = true;
            this.edtStundenansatz2.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStundenansatz2.Properties.Appearance.Options.UseFont = true;
            this.edtStundenansatz2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStundenansatz2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStundenansatz2.Properties.DisplayFormat.FormatString = "n2";
            this.edtStundenansatz2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz2.Properties.EditFormat.FormatString = "n2";
            this.edtStundenansatz2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz2.Properties.Mask.EditMask = "n2";
            this.edtStundenansatz2.Size = new System.Drawing.Size(100, 24);
            this.edtStundenansatz2.TabIndex = 3;
            // 
            // edtStundenansatz11
            // 
            this.edtStundenansatz11.DataSource = this.qryXUserStundenansatz;
            this.edtStundenansatz11.Location = new System.Drawing.Point(462, 10);
            this.edtStundenansatz11.Name = "edtStundenansatz11";
            this.edtStundenansatz11.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtStundenansatz11.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStundenansatz11.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStundenansatz11.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStundenansatz11.Properties.Appearance.Options.UseBackColor = true;
            this.edtStundenansatz11.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStundenansatz11.Properties.Appearance.Options.UseFont = true;
            this.edtStundenansatz11.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStundenansatz11.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStundenansatz11.Properties.DisplayFormat.FormatString = "n2";
            this.edtStundenansatz11.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz11.Properties.EditFormat.FormatString = "n2";
            this.edtStundenansatz11.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz11.Properties.Mask.EditMask = "n2";
            this.edtStundenansatz11.Size = new System.Drawing.Size(100, 24);
            this.edtStundenansatz11.TabIndex = 21;
            // 
            // edtStundenansatz1
            // 
            this.edtStundenansatz1.DataSource = this.qryXUserStundenansatz;
            this.edtStundenansatz1.Location = new System.Drawing.Point(165, 10);
            this.edtStundenansatz1.Name = "edtStundenansatz1";
            this.edtStundenansatz1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtStundenansatz1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStundenansatz1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStundenansatz1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStundenansatz1.Properties.Appearance.Options.UseBackColor = true;
            this.edtStundenansatz1.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStundenansatz1.Properties.Appearance.Options.UseFont = true;
            this.edtStundenansatz1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStundenansatz1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStundenansatz1.Properties.DisplayFormat.FormatString = "n2";
            this.edtStundenansatz1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz1.Properties.EditFormat.FormatString = "n2";
            this.edtStundenansatz1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStundenansatz1.Properties.Mask.EditMask = "n2";
            this.edtStundenansatz1.Size = new System.Drawing.Size(100, 24);
            this.edtStundenansatz1.TabIndex = 1;
            // 
            // lblStundenansatz20
            // 
            this.lblStundenansatz20.Location = new System.Drawing.Point(306, 280);
            this.lblStundenansatz20.Name = "lblStundenansatz20";
            this.lblStundenansatz20.Size = new System.Drawing.Size(150, 24);
            this.lblStundenansatz20.TabIndex = 38;
            this.lblStundenansatz20.Text = "Stundenansatz Lohnart 20";
            // 
            // lblStundenansatz10
            // 
            this.lblStundenansatz10.Location = new System.Drawing.Point(9, 280);
            this.lblStundenansatz10.Name = "lblStundenansatz10";
            this.lblStundenansatz10.Size = new System.Drawing.Size(150, 24);
            this.lblStundenansatz10.TabIndex = 18;
            this.lblStundenansatz10.Text = "Stundenansatz Lohnart 10";
            // 
            // lblStundenansatz19
            // 
            this.lblStundenansatz19.Location = new System.Drawing.Point(306, 250);
            this.lblStundenansatz19.Name = "lblStundenansatz19";
            this.lblStundenansatz19.Size = new System.Drawing.Size(150, 24);
            this.lblStundenansatz19.TabIndex = 36;
            this.lblStundenansatz19.Text = "Stundenansatz Lohnart 19";
            // 
            // lblStundenansatz9
            // 
            this.lblStundenansatz9.Location = new System.Drawing.Point(9, 250);
            this.lblStundenansatz9.Name = "lblStundenansatz9";
            this.lblStundenansatz9.Size = new System.Drawing.Size(150, 24);
            this.lblStundenansatz9.TabIndex = 16;
            this.lblStundenansatz9.Text = "Stundenansatz Lohnart 9";
            // 
            // lblStundenansatz18
            // 
            this.lblStundenansatz18.Location = new System.Drawing.Point(306, 220);
            this.lblStundenansatz18.Name = "lblStundenansatz18";
            this.lblStundenansatz18.Size = new System.Drawing.Size(150, 24);
            this.lblStundenansatz18.TabIndex = 34;
            this.lblStundenansatz18.Text = "Stundenansatz Lohnart 18";
            // 
            // lblStundenansatz8
            // 
            this.lblStundenansatz8.Location = new System.Drawing.Point(9, 220);
            this.lblStundenansatz8.Name = "lblStundenansatz8";
            this.lblStundenansatz8.Size = new System.Drawing.Size(150, 24);
            this.lblStundenansatz8.TabIndex = 14;
            this.lblStundenansatz8.Text = "Stundenansatz Lohnart 8";
            // 
            // lblStundenansatz17
            // 
            this.lblStundenansatz17.Location = new System.Drawing.Point(306, 190);
            this.lblStundenansatz17.Name = "lblStundenansatz17";
            this.lblStundenansatz17.Size = new System.Drawing.Size(150, 24);
            this.lblStundenansatz17.TabIndex = 32;
            this.lblStundenansatz17.Text = "Stundenansatz Lohnart 17";
            // 
            // lblStundenansatz7
            // 
            this.lblStundenansatz7.Location = new System.Drawing.Point(9, 190);
            this.lblStundenansatz7.Name = "lblStundenansatz7";
            this.lblStundenansatz7.Size = new System.Drawing.Size(150, 24);
            this.lblStundenansatz7.TabIndex = 12;
            this.lblStundenansatz7.Text = "Stundenansatz Lohnart 7";
            // 
            // lblStundenansatz16
            // 
            this.lblStundenansatz16.Location = new System.Drawing.Point(306, 160);
            this.lblStundenansatz16.Name = "lblStundenansatz16";
            this.lblStundenansatz16.Size = new System.Drawing.Size(150, 24);
            this.lblStundenansatz16.TabIndex = 30;
            this.lblStundenansatz16.Text = "Stundenansatz Lohnart 16";
            // 
            // lblStundenansatz6
            // 
            this.lblStundenansatz6.Location = new System.Drawing.Point(9, 160);
            this.lblStundenansatz6.Name = "lblStundenansatz6";
            this.lblStundenansatz6.Size = new System.Drawing.Size(150, 24);
            this.lblStundenansatz6.TabIndex = 10;
            this.lblStundenansatz6.Text = "Stundenansatz Lohnart 6";
            // 
            // lblStundenansatz15
            // 
            this.lblStundenansatz15.Location = new System.Drawing.Point(306, 130);
            this.lblStundenansatz15.Name = "lblStundenansatz15";
            this.lblStundenansatz15.Size = new System.Drawing.Size(150, 24);
            this.lblStundenansatz15.TabIndex = 28;
            this.lblStundenansatz15.Text = "Stundenansatz Lohnart 15";
            // 
            // lblStundenansatz5
            // 
            this.lblStundenansatz5.Location = new System.Drawing.Point(9, 130);
            this.lblStundenansatz5.Name = "lblStundenansatz5";
            this.lblStundenansatz5.Size = new System.Drawing.Size(150, 24);
            this.lblStundenansatz5.TabIndex = 8;
            this.lblStundenansatz5.Text = "Stundenansatz Lohnart 5";
            // 
            // lblStundenansatz14
            // 
            this.lblStundenansatz14.Location = new System.Drawing.Point(306, 100);
            this.lblStundenansatz14.Name = "lblStundenansatz14";
            this.lblStundenansatz14.Size = new System.Drawing.Size(150, 24);
            this.lblStundenansatz14.TabIndex = 26;
            this.lblStundenansatz14.Text = "Stundenansatz Lohnart 14";
            // 
            // lblStundenansatz4
            // 
            this.lblStundenansatz4.Location = new System.Drawing.Point(9, 100);
            this.lblStundenansatz4.Name = "lblStundenansatz4";
            this.lblStundenansatz4.Size = new System.Drawing.Size(150, 24);
            this.lblStundenansatz4.TabIndex = 6;
            this.lblStundenansatz4.Text = "Stundenansatz Lohnart 4";
            // 
            // lblStundenansatz13
            // 
            this.lblStundenansatz13.Location = new System.Drawing.Point(306, 70);
            this.lblStundenansatz13.Name = "lblStundenansatz13";
            this.lblStundenansatz13.Size = new System.Drawing.Size(150, 24);
            this.lblStundenansatz13.TabIndex = 24;
            this.lblStundenansatz13.Text = "Stundenansatz Lohnart 13";
            // 
            // lblStundenansatz3
            // 
            this.lblStundenansatz3.Location = new System.Drawing.Point(9, 70);
            this.lblStundenansatz3.Name = "lblStundenansatz3";
            this.lblStundenansatz3.Size = new System.Drawing.Size(150, 24);
            this.lblStundenansatz3.TabIndex = 4;
            this.lblStundenansatz3.Text = "Stundenansatz Lohnart 3";
            // 
            // lblStundenansatz12
            // 
            this.lblStundenansatz12.Location = new System.Drawing.Point(306, 40);
            this.lblStundenansatz12.Name = "lblStundenansatz12";
            this.lblStundenansatz12.Size = new System.Drawing.Size(150, 24);
            this.lblStundenansatz12.TabIndex = 22;
            this.lblStundenansatz12.Text = "Stundenansatz Lohnart 12";
            // 
            // lblStundenansatz2
            // 
            this.lblStundenansatz2.Location = new System.Drawing.Point(9, 40);
            this.lblStundenansatz2.Name = "lblStundenansatz2";
            this.lblStundenansatz2.Size = new System.Drawing.Size(150, 24);
            this.lblStundenansatz2.TabIndex = 2;
            this.lblStundenansatz2.Text = "Stundenansatz Lohnart 2";
            // 
            // lblStundenansatz11
            // 
            this.lblStundenansatz11.Location = new System.Drawing.Point(306, 10);
            this.lblStundenansatz11.Name = "lblStundenansatz11";
            this.lblStundenansatz11.Size = new System.Drawing.Size(150, 24);
            this.lblStundenansatz11.TabIndex = 20;
            this.lblStundenansatz11.Text = "Stundenansatz Lohnart 11";
            // 
            // lblStundenansatz1
            // 
            this.lblStundenansatz1.Location = new System.Drawing.Point(9, 10);
            this.lblStundenansatz1.Name = "lblStundenansatz1";
            this.lblStundenansatz1.Size = new System.Drawing.Size(150, 24);
            this.lblStundenansatz1.TabIndex = 0;
            this.lblStundenansatz1.Text = "Stundenansatz Lohnart 1";
            // 
            // tpgSollProJahr
            // 
            this.tpgSollProJahr.Controls.Add(this.grpSollProJahr);
            this.tpgSollProJahr.Controls.Add(this.edtSollProJahrJahr);
            this.tpgSollProJahr.Controls.Add(this.lblSollProJahrJahr);
            this.tpgSollProJahr.Location = new System.Drawing.Point(6, 6);
            this.tpgSollProJahr.Name = "tpgSollProJahr";
            this.tpgSollProJahr.Size = new System.Drawing.Size(838, 303);
            this.tpgSollProJahr.TabIndex = 5;
            this.tpgSollProJahr.Title = "Sollstunden pro Jahr";
            // 
            // grpSollProJahr
            // 
            this.grpSollProJahr.Controls.Add(this.lblSollProJahrDezember);
            this.grpSollProJahr.Controls.Add(this.lblSollProJahrDezemberLbl);
            this.grpSollProJahr.Controls.Add(this.lblSollProJahrNovember);
            this.grpSollProJahr.Controls.Add(this.lblSollProJahrNovemberLbl);
            this.grpSollProJahr.Controls.Add(this.lblSollProJahrOktober);
            this.grpSollProJahr.Controls.Add(this.lblSollProJahrOktoberLbl);
            this.grpSollProJahr.Controls.Add(this.lblSollProJahrSeptember);
            this.grpSollProJahr.Controls.Add(this.lblSollProJahrSeptemberLbl);
            this.grpSollProJahr.Controls.Add(this.lblSollProJahrAugust);
            this.grpSollProJahr.Controls.Add(this.lblSollProJahrAugustLbl);
            this.grpSollProJahr.Controls.Add(this.lblSollProJahrJuli);
            this.grpSollProJahr.Controls.Add(this.lblSollProJahrJuliLbl);
            this.grpSollProJahr.Controls.Add(this.lblSollProJahrJuni);
            this.grpSollProJahr.Controls.Add(this.lblSollProJahrJuniLbl);
            this.grpSollProJahr.Controls.Add(this.lblSollProJahrMai);
            this.grpSollProJahr.Controls.Add(this.lblSollProJahrMaiLbl);
            this.grpSollProJahr.Controls.Add(this.lblSollProJahrApril);
            this.grpSollProJahr.Controls.Add(this.lblSollProJahrAprilLbl);
            this.grpSollProJahr.Controls.Add(this.lblSollProJahrMaerz);
            this.grpSollProJahr.Controls.Add(this.lblSollProJahrMaerzLbl);
            this.grpSollProJahr.Controls.Add(this.lblSollProJahrFebruar);
            this.grpSollProJahr.Controls.Add(this.lblSollProJahrFebruarLbl);
            this.grpSollProJahr.Controls.Add(this.lblSollProJahrJanuar);
            this.grpSollProJahr.Controls.Add(this.lblSollProJahrJanuarLbl);
            this.grpSollProJahr.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpSollProJahr.Location = new System.Drawing.Point(9, 40);
            this.grpSollProJahr.Name = "grpSollProJahr";
            this.grpSollProJahr.Size = new System.Drawing.Size(421, 173);
            this.grpSollProJahr.TabIndex = 2;
            this.grpSollProJahr.TabStop = false;
            this.grpSollProJahr.UseCompatibleTextRendering = true;
            // 
            // lblSollProJahrDezember
            // 
            this.lblSollProJahrDezember.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblSollProJahrDezember.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSollProJahrDezember.Location = new System.Drawing.Point(319, 138);
            this.lblSollProJahrDezember.Name = "lblSollProJahrDezember";
            this.lblSollProJahrDezember.Size = new System.Drawing.Size(87, 24);
            this.lblSollProJahrDezember.TabIndex = 23;
            this.lblSollProJahrDezember.Text = "0.00 Std.";
            this.lblSollProJahrDezember.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSollProJahrDezember.UseCompatibleTextRendering = true;
            // 
            // lblSollProJahrDezemberLbl
            // 
            this.lblSollProJahrDezemberLbl.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblSollProJahrDezemberLbl.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSollProJahrDezemberLbl.Location = new System.Drawing.Point(231, 138);
            this.lblSollProJahrDezemberLbl.Name = "lblSollProJahrDezemberLbl";
            this.lblSollProJahrDezemberLbl.Size = new System.Drawing.Size(82, 24);
            this.lblSollProJahrDezemberLbl.TabIndex = 22;
            this.lblSollProJahrDezemberLbl.Text = "Dezember";
            this.lblSollProJahrDezemberLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSollProJahrDezemberLbl.UseCompatibleTextRendering = true;
            // 
            // lblSollProJahrNovember
            // 
            this.lblSollProJahrNovember.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblSollProJahrNovember.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSollProJahrNovember.Location = new System.Drawing.Point(319, 114);
            this.lblSollProJahrNovember.Name = "lblSollProJahrNovember";
            this.lblSollProJahrNovember.Size = new System.Drawing.Size(87, 24);
            this.lblSollProJahrNovember.TabIndex = 21;
            this.lblSollProJahrNovember.Text = "0.00 Std.";
            this.lblSollProJahrNovember.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSollProJahrNovember.UseCompatibleTextRendering = true;
            // 
            // lblSollProJahrNovemberLbl
            // 
            this.lblSollProJahrNovemberLbl.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblSollProJahrNovemberLbl.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSollProJahrNovemberLbl.Location = new System.Drawing.Point(231, 114);
            this.lblSollProJahrNovemberLbl.Name = "lblSollProJahrNovemberLbl";
            this.lblSollProJahrNovemberLbl.Size = new System.Drawing.Size(82, 24);
            this.lblSollProJahrNovemberLbl.TabIndex = 20;
            this.lblSollProJahrNovemberLbl.Text = "November";
            this.lblSollProJahrNovemberLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSollProJahrNovemberLbl.UseCompatibleTextRendering = true;
            // 
            // lblSollProJahrOktober
            // 
            this.lblSollProJahrOktober.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblSollProJahrOktober.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSollProJahrOktober.Location = new System.Drawing.Point(319, 90);
            this.lblSollProJahrOktober.Name = "lblSollProJahrOktober";
            this.lblSollProJahrOktober.Size = new System.Drawing.Size(87, 24);
            this.lblSollProJahrOktober.TabIndex = 19;
            this.lblSollProJahrOktober.Text = "0.00 Std.";
            this.lblSollProJahrOktober.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSollProJahrOktober.UseCompatibleTextRendering = true;
            // 
            // lblSollProJahrOktoberLbl
            // 
            this.lblSollProJahrOktoberLbl.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblSollProJahrOktoberLbl.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSollProJahrOktoberLbl.Location = new System.Drawing.Point(231, 90);
            this.lblSollProJahrOktoberLbl.Name = "lblSollProJahrOktoberLbl";
            this.lblSollProJahrOktoberLbl.Size = new System.Drawing.Size(82, 24);
            this.lblSollProJahrOktoberLbl.TabIndex = 18;
            this.lblSollProJahrOktoberLbl.Text = "Oktober";
            this.lblSollProJahrOktoberLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSollProJahrOktoberLbl.UseCompatibleTextRendering = true;
            // 
            // lblSollProJahrSeptember
            // 
            this.lblSollProJahrSeptember.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblSollProJahrSeptember.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSollProJahrSeptember.Location = new System.Drawing.Point(319, 66);
            this.lblSollProJahrSeptember.Name = "lblSollProJahrSeptember";
            this.lblSollProJahrSeptember.Size = new System.Drawing.Size(87, 24);
            this.lblSollProJahrSeptember.TabIndex = 17;
            this.lblSollProJahrSeptember.Text = "0.00 Std.";
            this.lblSollProJahrSeptember.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSollProJahrSeptember.UseCompatibleTextRendering = true;
            // 
            // lblSollProJahrSeptemberLbl
            // 
            this.lblSollProJahrSeptemberLbl.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblSollProJahrSeptemberLbl.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSollProJahrSeptemberLbl.Location = new System.Drawing.Point(231, 66);
            this.lblSollProJahrSeptemberLbl.Name = "lblSollProJahrSeptemberLbl";
            this.lblSollProJahrSeptemberLbl.Size = new System.Drawing.Size(82, 24);
            this.lblSollProJahrSeptemberLbl.TabIndex = 16;
            this.lblSollProJahrSeptemberLbl.Text = "September";
            this.lblSollProJahrSeptemberLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSollProJahrSeptemberLbl.UseCompatibleTextRendering = true;
            // 
            // lblSollProJahrAugust
            // 
            this.lblSollProJahrAugust.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblSollProJahrAugust.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSollProJahrAugust.Location = new System.Drawing.Point(319, 42);
            this.lblSollProJahrAugust.Name = "lblSollProJahrAugust";
            this.lblSollProJahrAugust.Size = new System.Drawing.Size(87, 24);
            this.lblSollProJahrAugust.TabIndex = 15;
            this.lblSollProJahrAugust.Text = "0.00 Std.";
            this.lblSollProJahrAugust.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSollProJahrAugust.UseCompatibleTextRendering = true;
            // 
            // lblSollProJahrAugustLbl
            // 
            this.lblSollProJahrAugustLbl.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblSollProJahrAugustLbl.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSollProJahrAugustLbl.Location = new System.Drawing.Point(231, 42);
            this.lblSollProJahrAugustLbl.Name = "lblSollProJahrAugustLbl";
            this.lblSollProJahrAugustLbl.Size = new System.Drawing.Size(82, 24);
            this.lblSollProJahrAugustLbl.TabIndex = 14;
            this.lblSollProJahrAugustLbl.Text = "August";
            this.lblSollProJahrAugustLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSollProJahrAugustLbl.UseCompatibleTextRendering = true;
            // 
            // lblSollProJahrJuli
            // 
            this.lblSollProJahrJuli.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblSollProJahrJuli.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSollProJahrJuli.Location = new System.Drawing.Point(319, 17);
            this.lblSollProJahrJuli.Name = "lblSollProJahrJuli";
            this.lblSollProJahrJuli.Size = new System.Drawing.Size(87, 24);
            this.lblSollProJahrJuli.TabIndex = 13;
            this.lblSollProJahrJuli.Text = "0.00 Std.";
            this.lblSollProJahrJuli.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSollProJahrJuli.UseCompatibleTextRendering = true;
            // 
            // lblSollProJahrJuliLbl
            // 
            this.lblSollProJahrJuliLbl.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblSollProJahrJuliLbl.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSollProJahrJuliLbl.Location = new System.Drawing.Point(231, 18);
            this.lblSollProJahrJuliLbl.Name = "lblSollProJahrJuliLbl";
            this.lblSollProJahrJuliLbl.Size = new System.Drawing.Size(82, 24);
            this.lblSollProJahrJuliLbl.TabIndex = 12;
            this.lblSollProJahrJuliLbl.Text = "Juli";
            this.lblSollProJahrJuliLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSollProJahrJuliLbl.UseCompatibleTextRendering = true;
            // 
            // lblSollProJahrJuni
            // 
            this.lblSollProJahrJuni.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblSollProJahrJuni.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSollProJahrJuni.Location = new System.Drawing.Point(100, 138);
            this.lblSollProJahrJuni.Name = "lblSollProJahrJuni";
            this.lblSollProJahrJuni.Size = new System.Drawing.Size(87, 24);
            this.lblSollProJahrJuni.TabIndex = 11;
            this.lblSollProJahrJuni.Text = "0.00 Std.";
            this.lblSollProJahrJuni.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSollProJahrJuni.UseCompatibleTextRendering = true;
            // 
            // lblSollProJahrJuniLbl
            // 
            this.lblSollProJahrJuniLbl.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblSollProJahrJuniLbl.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSollProJahrJuniLbl.Location = new System.Drawing.Point(12, 138);
            this.lblSollProJahrJuniLbl.Name = "lblSollProJahrJuniLbl";
            this.lblSollProJahrJuniLbl.Size = new System.Drawing.Size(82, 24);
            this.lblSollProJahrJuniLbl.TabIndex = 10;
            this.lblSollProJahrJuniLbl.Text = "Juni";
            this.lblSollProJahrJuniLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSollProJahrJuniLbl.UseCompatibleTextRendering = true;
            // 
            // lblSollProJahrMai
            // 
            this.lblSollProJahrMai.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblSollProJahrMai.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSollProJahrMai.Location = new System.Drawing.Point(100, 114);
            this.lblSollProJahrMai.Name = "lblSollProJahrMai";
            this.lblSollProJahrMai.Size = new System.Drawing.Size(87, 24);
            this.lblSollProJahrMai.TabIndex = 9;
            this.lblSollProJahrMai.Text = "0.00 Std.";
            this.lblSollProJahrMai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSollProJahrMai.UseCompatibleTextRendering = true;
            // 
            // lblSollProJahrMaiLbl
            // 
            this.lblSollProJahrMaiLbl.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblSollProJahrMaiLbl.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSollProJahrMaiLbl.Location = new System.Drawing.Point(12, 114);
            this.lblSollProJahrMaiLbl.Name = "lblSollProJahrMaiLbl";
            this.lblSollProJahrMaiLbl.Size = new System.Drawing.Size(82, 24);
            this.lblSollProJahrMaiLbl.TabIndex = 8;
            this.lblSollProJahrMaiLbl.Text = "Mai";
            this.lblSollProJahrMaiLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSollProJahrMaiLbl.UseCompatibleTextRendering = true;
            // 
            // lblSollProJahrApril
            // 
            this.lblSollProJahrApril.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblSollProJahrApril.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSollProJahrApril.Location = new System.Drawing.Point(100, 90);
            this.lblSollProJahrApril.Name = "lblSollProJahrApril";
            this.lblSollProJahrApril.Size = new System.Drawing.Size(87, 24);
            this.lblSollProJahrApril.TabIndex = 7;
            this.lblSollProJahrApril.Text = "0.00 Std.";
            this.lblSollProJahrApril.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSollProJahrApril.UseCompatibleTextRendering = true;
            // 
            // lblSollProJahrAprilLbl
            // 
            this.lblSollProJahrAprilLbl.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblSollProJahrAprilLbl.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSollProJahrAprilLbl.Location = new System.Drawing.Point(12, 90);
            this.lblSollProJahrAprilLbl.Name = "lblSollProJahrAprilLbl";
            this.lblSollProJahrAprilLbl.Size = new System.Drawing.Size(82, 24);
            this.lblSollProJahrAprilLbl.TabIndex = 6;
            this.lblSollProJahrAprilLbl.Text = "April";
            this.lblSollProJahrAprilLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSollProJahrAprilLbl.UseCompatibleTextRendering = true;
            // 
            // lblSollProJahrMaerz
            // 
            this.lblSollProJahrMaerz.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblSollProJahrMaerz.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSollProJahrMaerz.Location = new System.Drawing.Point(100, 66);
            this.lblSollProJahrMaerz.Name = "lblSollProJahrMaerz";
            this.lblSollProJahrMaerz.Size = new System.Drawing.Size(87, 24);
            this.lblSollProJahrMaerz.TabIndex = 5;
            this.lblSollProJahrMaerz.Text = "0.00 Std.";
            this.lblSollProJahrMaerz.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSollProJahrMaerz.UseCompatibleTextRendering = true;
            // 
            // lblSollProJahrMaerzLbl
            // 
            this.lblSollProJahrMaerzLbl.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblSollProJahrMaerzLbl.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSollProJahrMaerzLbl.Location = new System.Drawing.Point(12, 66);
            this.lblSollProJahrMaerzLbl.Name = "lblSollProJahrMaerzLbl";
            this.lblSollProJahrMaerzLbl.Size = new System.Drawing.Size(82, 24);
            this.lblSollProJahrMaerzLbl.TabIndex = 4;
            this.lblSollProJahrMaerzLbl.Text = "März";
            this.lblSollProJahrMaerzLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSollProJahrMaerzLbl.UseCompatibleTextRendering = true;
            // 
            // lblSollProJahrFebruar
            // 
            this.lblSollProJahrFebruar.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblSollProJahrFebruar.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSollProJahrFebruar.Location = new System.Drawing.Point(100, 42);
            this.lblSollProJahrFebruar.Name = "lblSollProJahrFebruar";
            this.lblSollProJahrFebruar.Size = new System.Drawing.Size(87, 24);
            this.lblSollProJahrFebruar.TabIndex = 3;
            this.lblSollProJahrFebruar.Text = "0.00 Std.";
            this.lblSollProJahrFebruar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSollProJahrFebruar.UseCompatibleTextRendering = true;
            // 
            // lblSollProJahrFebruarLbl
            // 
            this.lblSollProJahrFebruarLbl.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblSollProJahrFebruarLbl.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSollProJahrFebruarLbl.Location = new System.Drawing.Point(12, 42);
            this.lblSollProJahrFebruarLbl.Name = "lblSollProJahrFebruarLbl";
            this.lblSollProJahrFebruarLbl.Size = new System.Drawing.Size(82, 24);
            this.lblSollProJahrFebruarLbl.TabIndex = 2;
            this.lblSollProJahrFebruarLbl.Text = "Februar";
            this.lblSollProJahrFebruarLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSollProJahrFebruarLbl.UseCompatibleTextRendering = true;
            // 
            // lblSollProJahrJanuar
            // 
            this.lblSollProJahrJanuar.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblSollProJahrJanuar.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSollProJahrJanuar.Location = new System.Drawing.Point(100, 17);
            this.lblSollProJahrJanuar.Name = "lblSollProJahrJanuar";
            this.lblSollProJahrJanuar.Size = new System.Drawing.Size(87, 24);
            this.lblSollProJahrJanuar.TabIndex = 1;
            this.lblSollProJahrJanuar.Text = "0.00 Std.";
            this.lblSollProJahrJanuar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSollProJahrJanuar.UseCompatibleTextRendering = true;
            // 
            // lblSollProJahrJanuarLbl
            // 
            this.lblSollProJahrJanuarLbl.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblSollProJahrJanuarLbl.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSollProJahrJanuarLbl.Location = new System.Drawing.Point(12, 18);
            this.lblSollProJahrJanuarLbl.Name = "lblSollProJahrJanuarLbl";
            this.lblSollProJahrJanuarLbl.Size = new System.Drawing.Size(82, 24);
            this.lblSollProJahrJanuarLbl.TabIndex = 0;
            this.lblSollProJahrJanuarLbl.Text = "Januar";
            this.lblSollProJahrJanuarLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSollProJahrJanuarLbl.UseCompatibleTextRendering = true;
            // 
            // edtSollProJahrJahr
            // 
            this.edtSollProJahrJahr.AllowNull = false;
            this.edtSollProJahrJahr.Location = new System.Drawing.Point(86, 10);
            this.edtSollProJahrJahr.LOVName = "BDESollstundenProJahrJahre";
            this.edtSollProJahrJahr.Name = "edtSollProJahrJahr";
            this.edtSollProJahrJahr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSollProJahrJahr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSollProJahrJahr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSollProJahrJahr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSollProJahrJahr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSollProJahrJahr.Properties.Appearance.Options.UseFont = true;
            this.edtSollProJahrJahr.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSollProJahrJahr.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSollProJahrJahr.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSollProJahrJahr.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSollProJahrJahr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.edtSollProJahrJahr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.edtSollProJahrJahr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSollProJahrJahr.Properties.NullText = "";
            this.edtSollProJahrJahr.Properties.ShowFooter = false;
            this.edtSollProJahrJahr.Properties.ShowHeader = false;
            this.edtSollProJahrJahr.Size = new System.Drawing.Size(77, 24);
            this.edtSollProJahrJahr.TabIndex = 1;
            this.edtSollProJahrJahr.EditValueChanged += new System.EventHandler(this.edtSollProJahrJahr_EditValueChanged);
            // 
            // lblSollProJahrJahr
            // 
            this.lblSollProJahrJahr.Location = new System.Drawing.Point(9, 10);
            this.lblSollProJahrJahr.Name = "lblSollProJahrJahr";
            this.lblSollProJahrJahr.Size = new System.Drawing.Size(71, 24);
            this.lblSollProJahrJahr.TabIndex = 0;
            this.lblSollProJahrJahr.Text = "Jahr";
            this.lblSollProJahrJahr.UseCompatibleTextRendering = true;
            // 
            // tpgTexte
            // 
            this.tpgTexte.Controls.Add(this.lblText2);
            this.tpgTexte.Controls.Add(this.lblText1);
            this.tpgTexte.Controls.Add(this.edtText2);
            this.tpgTexte.Controls.Add(this.edtText1);
            this.tpgTexte.Location = new System.Drawing.Point(6, 6);
            this.tpgTexte.Name = "tpgTexte";
            this.tpgTexte.Size = new System.Drawing.Size(838, 303);
            this.tpgTexte.TabIndex = 6;
            this.tpgTexte.Title = "Texte";
            // 
            // lblText2
            // 
            this.lblText2.Location = new System.Drawing.Point(9, 114);
            this.lblText2.Name = "lblText2";
            this.lblText2.Size = new System.Drawing.Size(42, 24);
            this.lblText2.TabIndex = 86;
            this.lblText2.Text = "Text 2";
            // 
            // lblText1
            // 
            this.lblText1.Location = new System.Drawing.Point(9, 9);
            this.lblText1.Name = "lblText1";
            this.lblText1.Size = new System.Drawing.Size(42, 24);
            this.lblText1.TabIndex = 85;
            this.lblText1.Text = "Text 1";
            // 
            // edtText2
            // 
            this.edtText2.BackColor = System.Drawing.Color.White;
            this.edtText2.DataMember = "Text2";
            this.edtText2.DataSource = this.qryUser;
            this.edtText2.Font = new System.Drawing.Font("Arial", 10F);
            this.edtText2.Location = new System.Drawing.Point(56, 116);
            this.edtText2.Name = "edtText2";
            this.edtText2.Size = new System.Drawing.Size(560, 90);
            this.edtText2.TabIndex = 84;
            // 
            // edtText1
            // 
            this.edtText1.BackColor = System.Drawing.Color.White;
            this.edtText1.DataMember = "Text1";
            this.edtText1.DataSource = this.qryUser;
            this.edtText1.Font = new System.Drawing.Font("Arial", 10F);
            this.edtText1.Location = new System.Drawing.Point(57, 9);
            this.edtText1.Name = "edtText1";
            this.edtText1.Size = new System.Drawing.Size(560, 90);
            this.edtText1.TabIndex = 83;
            // 
            // tpgArbeitszeit
            // 
            this.tpgArbeitszeit.Controls.Add(this.kissLabel25);
            this.tpgArbeitszeit.Controls.Add(this.kissLabel24);
            this.tpgArbeitszeit.Controls.Add(this.edtJobPercentage);
            this.tpgArbeitszeit.Controls.Add(this.edtHoursPerYearForCaseMgmt);
            this.tpgArbeitszeit.Controls.Add(this.lblJobPercentage);
            this.tpgArbeitszeit.Controls.Add(this.lblHoursPerYearForCaseMgmt);
            this.tpgArbeitszeit.Location = new System.Drawing.Point(6, 6);
            this.tpgArbeitszeit.Name = "tpgArbeitszeit";
            this.tpgArbeitszeit.Size = new System.Drawing.Size(838, 303);
            this.tpgArbeitszeit.TabIndex = 7;
            this.tpgArbeitszeit.Title = "Arbeitszeit";
            // 
            // kissLabel25
            // 
            this.kissLabel25.Location = new System.Drawing.Point(245, 39);
            this.kissLabel25.Name = "kissLabel25";
            this.kissLabel25.Size = new System.Drawing.Size(36, 24);
            this.kissLabel25.TabIndex = 103;
            this.kissLabel25.Text = "Std.";
            // 
            // kissLabel24
            // 
            this.kissLabel24.Location = new System.Drawing.Point(245, 9);
            this.kissLabel24.Name = "kissLabel24";
            this.kissLabel24.Size = new System.Drawing.Size(36, 24);
            this.kissLabel24.TabIndex = 101;
            this.kissLabel24.Text = "%";
            // 
            // edtJobPercentage
            // 
            this.edtJobPercentage.DataMember = "JobPercentage";
            this.edtJobPercentage.DataSource = this.qryUser;
            this.edtJobPercentage.Location = new System.Drawing.Point(183, 9);
            this.edtJobPercentage.Name = "edtJobPercentage";
            this.edtJobPercentage.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtJobPercentage.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtJobPercentage.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtJobPercentage.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtJobPercentage.Properties.Appearance.Options.UseBackColor = true;
            this.edtJobPercentage.Properties.Appearance.Options.UseBorderColor = true;
            this.edtJobPercentage.Properties.Appearance.Options.UseFont = true;
            this.edtJobPercentage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtJobPercentage.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtJobPercentage.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtJobPercentage.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtJobPercentage.Size = new System.Drawing.Size(56, 24);
            this.edtJobPercentage.TabIndex = 100;
            // 
            // edtHoursPerYearForCaseMgmt
            // 
            this.edtHoursPerYearForCaseMgmt.DataMember = "HoursPerYearForCaseMgmt";
            this.edtHoursPerYearForCaseMgmt.DataSource = this.qryUser;
            this.edtHoursPerYearForCaseMgmt.Location = new System.Drawing.Point(183, 39);
            this.edtHoursPerYearForCaseMgmt.Name = "edtHoursPerYearForCaseMgmt";
            this.edtHoursPerYearForCaseMgmt.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtHoursPerYearForCaseMgmt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtHoursPerYearForCaseMgmt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHoursPerYearForCaseMgmt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHoursPerYearForCaseMgmt.Properties.Appearance.Options.UseBackColor = true;
            this.edtHoursPerYearForCaseMgmt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHoursPerYearForCaseMgmt.Properties.Appearance.Options.UseFont = true;
            this.edtHoursPerYearForCaseMgmt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHoursPerYearForCaseMgmt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtHoursPerYearForCaseMgmt.Properties.DisplayFormat.FormatString = "n0";
            this.edtHoursPerYearForCaseMgmt.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtHoursPerYearForCaseMgmt.Properties.EditFormat.FormatString = "n0";
            this.edtHoursPerYearForCaseMgmt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtHoursPerYearForCaseMgmt.Size = new System.Drawing.Size(56, 24);
            this.edtHoursPerYearForCaseMgmt.TabIndex = 102;
            // 
            // lblJobPercentage
            // 
            this.lblJobPercentage.Location = new System.Drawing.Point(9, 9);
            this.lblJobPercentage.Name = "lblJobPercentage";
            this.lblJobPercentage.Size = new System.Drawing.Size(168, 24);
            this.lblJobPercentage.TabIndex = 99;
            this.lblJobPercentage.Text = "Anstellungsprozente";
            // 
            // lblHoursPerYearForCaseMgmt
            // 
            this.lblHoursPerYearForCaseMgmt.Location = new System.Drawing.Point(9, 39);
            this.lblHoursPerYearForCaseMgmt.Name = "lblHoursPerYearForCaseMgmt";
            this.lblHoursPerYearForCaseMgmt.Size = new System.Drawing.Size(168, 24);
            this.lblHoursPerYearForCaseMgmt.TabIndex = 98;
            this.lblHoursPerYearForCaseMgmt.Text = "Jahresarbeitszeit für Fallarbeit";
            // 
            // qryBDEData
            // 
            this.qryBDEData.AutoApplyUserRights = false;
            this.qryBDEData.HostControl = this;
            // 
            // qryBDESollProJahr
            // 
            this.qryBDESollProJahr.AutoApplyUserRights = false;
            this.qryBDESollProJahr.HostControl = this;
            // 
            // chkSucheNurBIAGAdmin
            // 
            this.chkSucheNurBIAGAdmin.EditValue = false;
            this.chkSucheNurBIAGAdmin.Location = new System.Drawing.Point(321, 175);
            this.chkSucheNurBIAGAdmin.Name = "chkSucheNurBIAGAdmin";
            this.chkSucheNurBIAGAdmin.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkSucheNurBIAGAdmin.Properties.Appearance.Options.UseBackColor = true;
            this.chkSucheNurBIAGAdmin.Properties.Caption = "Nur BIAG Administratoren";
            this.chkSucheNurBIAGAdmin.Size = new System.Drawing.Size(173, 19);
            this.chkSucheNurBIAGAdmin.TabIndex = 15;
            // 
            // CtlUser
            // 
            this.ActiveSQLQuery = this.qryUser;
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.tabUser);
            this.Name = "CtlUser";
            this.Size = new System.Drawing.Size(850, 550);
            this.Load += new System.EventHandler(this.CtlUser_Load);
            this.Controls.SetChildIndex(this.tabUser, 0);
            this.Controls.SetChildIndex(this.splitter, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchePersNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchePersNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheLogon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheLogon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheAbteilung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAbteilung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheNurAdmin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheNurNichtGesperrt.Properties)).EndInit();
            this.tabUser.ResumeLayout(false);
            this.tpgRollen.ResumeLayout(false);
            this.panRollenTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZugeteilt)).EndInit();
            this.panRollenAvailable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVerfuegbar)).EndInit();
            this.panRollenAvailableFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).EndInit();
            this.panRollenAvailableAddRemove.ResumeLayout(false);
            this.tpgBenutzerIn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtQualifikation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtQualifikation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFunktionsbezeichnung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFunktionsbezeichnung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblQualifikation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFunktionsbezeichnung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrantPermGroupID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrantPermGroupID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrantPermGroupID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPermissionGroupID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPermissionGroupID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPermissionGroupID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModulCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIsMandatsTraeger.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserProfil.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserProfil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memBemerkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLanguageCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLanguageCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSprache)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGenderCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGenderCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeschlecht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsLocked.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUserIsUserBIAGAdmin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUserSystemadministration.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPasswordRetype.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPWKontrolle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPasswort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtShortName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzzeichen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLogonName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLogon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFirstName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLastName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonalNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonalNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserID)).EndInit();
            this.tpgBaAdresse.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qryBaAdresse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPostfachOhneNummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtXUserPhonePrivat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtXUSerPhoneMobile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtXUserFax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenFax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtXUserPhoneGesch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenTelefonMobil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenTelefon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtXUserEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenAdresseLand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenAdresseBezirk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenAdressePLZOrtKt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdressePostfach.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenAdressePostfach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseHausNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenAdresseStrasseNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseZusatz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenAdresseZusatz)).EndInit();
            this.tpgBenutzerrechte.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRechte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUserRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRechte)).EndInit();
            this.tpgAbteilungen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAbteilungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAbteilung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAbteilungen)).EndInit();
            this.tpgPersonaldaten.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonaldatenWeitereKTR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenWeitereKTR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKeinExport.Properties)).EndInit();
            this.grpPersonaldatenAktuell.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenAusbezUeberstunden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenAusbezUeberstundenLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenFerienZugabenKuerzungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenFerienZugabenKuerzungenLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenFerienanspruch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenFerienanspruchLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenSollProMonat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenSollProMonatLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenSollProTag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenSollProTagLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenPensum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenPensumLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenAktuellerMonat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonaldatenLohntyp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonaldatenLohntyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenLohntyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonaldatenStdKTR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenStdKTR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonaldatenStdKA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenStdKA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonaldatenStdKST.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenStdKS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonaldatenAustritt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenAustritt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonaldatenEintritt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonaldatenEintritt)).EndInit();
            this.tpgStundenansatz.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz20.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXUserStundenansatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz10.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz19.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz9.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz18.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz8.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz17.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz7.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz16.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz6.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz15.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz14.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz13.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz12.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz11.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenansatz1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenansatz1)).EndInit();
            this.tpgSollProJahr.ResumeLayout(false);
            this.grpSollProJahr.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrDezember)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrDezemberLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrNovember)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrNovemberLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrOktober)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrOktoberLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrSeptember)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrSeptemberLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrAugust)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrAugustLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrJuli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrJuliLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrJuni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrJuniLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrMai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrMaiLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrApril)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrAprilLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrMaerz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrMaerzLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrFebruar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrFebruarLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrJanuar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrJanuarLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollProJahrJahr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollProJahrJahr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollProJahrJahr)).EndInit();
            this.tpgTexte.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblText2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblText1)).EndInit();
            this.tpgArbeitszeit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJobPercentage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHoursPerYearForCaseMgmt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJobPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHoursPerYearForCaseMgmt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBDEData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBDESollProJahr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheNurBIAGAdmin.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissButton btnAdd;
        private KiSS4.Gui.KissButton btnAddAll;
        private KiSS4.Gui.KissButton btnGotoBDEErfassung;
        private KiSS4.Gui.KissButton btnPersonaldatenWerteAendern;
        private KiSS4.Gui.KissButton btnRemove;
        private KiSS4.Gui.KissButton btnRemoveAll;
        private KiSS4.Gui.KissCheckEdit chkIsLocked;
        private KiSS4.Gui.KissCheckEdit chkSucheNurAdmin;
        private KiSS4.Gui.KissCheckEdit chkSucheNurBIAGAdmin;
        private KiSS4.Gui.KissCheckEdit chkSucheNurNichtGesperrt;
        private KiSS4.Gui.KissCheckEdit chkUserIsUserBIAGAdmin;
        private KiSS4.Gui.KissCheckEdit chkUserSystemadministration;
        private DevExpress.XtraGrid.Columns.GridColumn colAbteilung;
        private DevExpress.XtraGrid.Columns.GridColumn colBenutzergruppenVerfuegbareGruppe;
        private DevExpress.XtraGrid.Columns.GridColumn colBenutzergruppenZugeteilteGruppen;
        private DevExpress.XtraGrid.Columns.GridColumn colFirstName;
        private DevExpress.XtraGrid.Columns.GridColumn colFunktion;
        private DevExpress.XtraGrid.Columns.GridColumn colIsLocked;
        private DevExpress.XtraGrid.Columns.GridColumn colIsUserAdmin;
        private DevExpress.XtraGrid.Columns.GridColumn colIsUserBIAGAdmin;
        private DevExpress.XtraGrid.Columns.GridColumn colLastName;
        private DevExpress.XtraGrid.Columns.GridColumn colLogonName;
        private DevExpress.XtraGrid.Columns.GridColumn colMayDelete;
        private DevExpress.XtraGrid.Columns.GridColumn colMayInsert;
        private DevExpress.XtraGrid.Columns.GridColumn colMayUpdate;
        private DevExpress.XtraGrid.Columns.GridColumn colOrgUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonalNr;
        private DevExpress.XtraGrid.Columns.GridColumn colRecht;
        private DevExpress.XtraGrid.Columns.GridColumn colRechtE;
        private DevExpress.XtraGrid.Columns.GridColumn colRechtL;
        private DevExpress.XtraGrid.Columns.GridColumn colRechtM;
        private DevExpress.XtraGrid.Columns.GridColumn colUserGroupID;
        private DevExpress.XtraGrid.Columns.GridColumn colUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colUserStandardKST;
        private DevExpress.XtraGrid.Columns.GridColumn colUserStandardKTR;
        private KiSS4.Gui.KissTextEdit edtEmail;
        private KiSS4.Gui.KissTextEdit edtFilter;
        private KiSS4.Gui.KissTextEdit edtFirstName;
        private KiSS4.Gui.KissLookUpEdit edtGenderCode;
        private KiSS4.Gui.KissLookUpEdit edtLanguageCode;
        private KiSS4.Gui.KissTextEdit edtLastName;
        private KiSS4.Gui.KissTextEdit edtLogonName;
        private KiSS4.Gui.KissTextEdit edtPassword;
        private KiSS4.Gui.KissTextEdit edtPasswordRetype;
        private KiSS4.Gui.KissCalcEdit edtPersonalNr;
        private KiSS4.Gui.KissDateEdit edtPersonaldatenAustritt;
        private KiSS4.Gui.KissDateEdit edtPersonaldatenEintritt;
        private KiSS4.Gui.KissLookUpEdit edtPersonaldatenLohntyp;
        private KiSS4.Gui.KissCalcEdit edtPersonaldatenStdKA;
        private KiSS4.Gui.KissTextEdit edtPersonaldatenStdKST;
        private KiSS4.Gui.KissCalcEdit edtPersonaldatenStdKTR;
        private KiSS4.Gui.KissTextEdit edtPhone;
        private KiSS4.Gui.KissTextEdit edtShortName;
        private KiSS4.Gui.KissLookUpEdit edtSollProJahrJahr;
        private KiSS4.Gui.KissTextEdit edtSucheAbteilung;
        private KiSS4.Gui.KissTextEdit edtSucheLogon;
        private KiSS4.Gui.KissTextEdit edtSucheName;
        private KiSS4.Gui.KissCalcEdit edtSuchePersNr;
        private KiSS4.Gui.KissCalcEdit edtSucheUserID;
        private KiSS4.Gui.KissTextEdit edtSucheVorname;
        private KiSS4.Gui.KissCalcEdit edtUserID;
        private KiSS4.Gui.KissLookUpEdit edtUserProfil;
        private KiSS4.Gui.KissGrid grdAbteilungen;
        private KiSS4.Gui.KissGrid grdRechte;
        private KiSS4.Gui.KissGrid grdUser;
        private KiSS4.Gui.KissGrid grdVerfuegbar;
        private KiSS4.Gui.KissGrid grdZugeteilt;
        private KiSS4.Gui.KissGroupBox grpPersonaldatenAktuell;
        private KiSS4.Gui.KissGroupBox grpSollProJahr;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAbteilungen;
        private DevExpress.XtraGrid.Views.Grid.GridView grvRechte;
        private DevExpress.XtraGrid.Views.Grid.GridView grvUser;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVerfuegbar;
        private DevExpress.XtraGrid.Views.Grid.GridView grvZugeteilt;
        private KiSS4.Gui.KissLabel lblBemerkungen;
        private KiSS4.Gui.KissLabel lblEmail;
        private KiSS4.Gui.KissLabel lblFilter;
        private KiSS4.Gui.KissLabel lblGeschlecht;
        private KiSS4.Gui.KissLabel lblKurzzeichen;
        private KiSS4.Gui.KissLabel lblLogon;
        private KiSS4.Gui.KissLabel lblName;
        private KiSS4.Gui.KissLabel lblPWKontrolle;
        private KiSS4.Gui.KissLabel lblPasswort;
        private KiSS4.Gui.KissLabel lblPersonalNr;
        private KiSS4.Gui.KissLabel lblPersonaldatenAktuellerMonat;
        private KiSS4.Gui.KissLabel lblPersonaldatenAusbezUeberstunden;
        private KiSS4.Gui.KissLabel lblPersonaldatenAusbezUeberstundenLbl;
        private KiSS4.Gui.KissLabel lblPersonaldatenAustritt;
        private KiSS4.Gui.KissLabel lblPersonaldatenEintritt;
        private KiSS4.Gui.KissLabel lblPersonaldatenFerienZugabenKuerzungen;
        private KiSS4.Gui.KissLabel lblPersonaldatenFerienZugabenKuerzungenLbl;
        private KiSS4.Gui.KissLabel lblPersonaldatenFerienanspruch;
        private KiSS4.Gui.KissLabel lblPersonaldatenFerienanspruchLbl;
        private KiSS4.Gui.KissLabel lblPersonaldatenLohntyp;
        private KiSS4.Gui.KissLabel lblPersonaldatenPensum;
        private KiSS4.Gui.KissLabel lblPersonaldatenPensumLbl;
        private KiSS4.Gui.KissLabel lblPersonaldatenSollProMonat;
        private KiSS4.Gui.KissLabel lblPersonaldatenSollProMonatLbl;
        private KiSS4.Gui.KissLabel lblPersonaldatenSollProTag;
        private KiSS4.Gui.KissLabel lblPersonaldatenSollProTagLbl;
        private KiSS4.Gui.KissLabel lblPersonaldatenStdKA;
        private KiSS4.Gui.KissLabel lblPersonaldatenStdKS;
        private KiSS4.Gui.KissLabel lblPersonaldatenStdKTR;
        private KiSS4.Gui.KissLabel lblSollProJahrApril;
        private KiSS4.Gui.KissLabel lblSollProJahrAprilLbl;
        private KiSS4.Gui.KissLabel lblSollProJahrAugust;
        private KiSS4.Gui.KissLabel lblSollProJahrAugustLbl;
        private KiSS4.Gui.KissLabel lblSollProJahrDezember;
        private KiSS4.Gui.KissLabel lblSollProJahrDezemberLbl;
        private KiSS4.Gui.KissLabel lblSollProJahrFebruar;
        private KiSS4.Gui.KissLabel lblSollProJahrFebruarLbl;
        private KiSS4.Gui.KissLabel lblSollProJahrJahr;
        private KiSS4.Gui.KissLabel lblSollProJahrJanuar;
        private KiSS4.Gui.KissLabel lblSollProJahrJanuarLbl;
        private KiSS4.Gui.KissLabel lblSollProJahrJuli;
        private KiSS4.Gui.KissLabel lblSollProJahrJuliLbl;
        private KiSS4.Gui.KissLabel lblSollProJahrJuni;
        private KiSS4.Gui.KissLabel lblSollProJahrJuniLbl;
        private KiSS4.Gui.KissLabel lblSollProJahrMaerz;
        private KiSS4.Gui.KissLabel lblSollProJahrMaerzLbl;
        private KiSS4.Gui.KissLabel lblSollProJahrMai;
        private KiSS4.Gui.KissLabel lblSollProJahrMaiLbl;
        private KiSS4.Gui.KissLabel lblSollProJahrNovember;
        private KiSS4.Gui.KissLabel lblSollProJahrNovemberLbl;
        private KiSS4.Gui.KissLabel lblSollProJahrOktober;
        private KiSS4.Gui.KissLabel lblSollProJahrOktoberLbl;
        private KiSS4.Gui.KissLabel lblSollProJahrSeptember;
        private KiSS4.Gui.KissLabel lblSollProJahrSeptemberLbl;
        private KiSS4.Gui.KissLabel lblSprache;
        private KiSS4.Gui.KissLabel lblSucheAbteilung;
        private KiSS4.Gui.KissLabel lblSucheLogon;
        private KiSS4.Gui.KissLabel lblSucheName;
        private KiSS4.Gui.KissLabel lblSucheNr;
        private KiSS4.Gui.KissLabel lblSuchePersNr;
        private KiSS4.Gui.KissLabel lblSucheVorname;
        private KiSS4.Gui.KissLabel lblTelefon;
        private KiSS4.Gui.KissLabel lblUserID;
        private KiSS4.Gui.KissLabel lblUserProfile;
        private KiSS4.Gui.KissLabel lblVorname;
        private KiSS4.Gui.KissMemoEdit memBemerkungen;
        private System.Windows.Forms.Panel panRollenAvailable;
        private System.Windows.Forms.Panel panRollenAvailableAddRemove;
        private System.Windows.Forms.Panel panRollenAvailableFilter;
        private System.Windows.Forms.TableLayoutPanel panRollenTable;
        private KiSS4.DB.SqlQuery qryAbteilung;
        private KiSS4.DB.SqlQuery qryBDEData;
        private KiSS4.DB.SqlQuery qryBDESollProJahr;
        private KiSS4.DB.SqlQuery qryUser;
        private KiSS4.DB.SqlQuery qryUserRight;
        private KiSS4.DB.SqlQuery qryVerfuegbar;
        private KiSS4.DB.SqlQuery qryZugeteilt;
        private KiSS4.Gui.KissSplitterCollapsible splitter;
        private KiSS4.Gui.KissTabControlEx tabUser;
        private SharpLibrary.WinControls.TabPageEx tpgAbteilungen;
        private SharpLibrary.WinControls.TabPageEx tpgBenutzerIn;
        private SharpLibrary.WinControls.TabPageEx tpgBenutzerrechte;
        private SharpLibrary.WinControls.TabPageEx tpgPersonaldaten;
        private SharpLibrary.WinControls.TabPageEx tpgRollen;
        private SharpLibrary.WinControls.TabPageEx tpgSollProJahr;
        private SharpLibrary.WinControls.TabPageEx tpgTexte;
        private SharpLibrary.WinControls.TabPageEx tpgArbeitszeit;
        private KiSS4.Gui.KissLabel lblText2;
        private KiSS4.Gui.KissLabel lblText1;
        private KiSS4.Gui.KissRTFEdit edtText2;
        private KiSS4.Gui.KissRTFEdit edtText1;
        private KiSS4.Gui.KissLabel kissLabel25;
        private KiSS4.Gui.KissLabel kissLabel24;
        private KiSS4.Gui.KissCalcEdit edtJobPercentage;
        private KiSS4.Gui.KissCalcEdit edtHoursPerYearForCaseMgmt;
        private KiSS4.Gui.KissLabel lblJobPercentage;
        private KiSS4.Gui.KissLabel lblHoursPerYearForCaseMgmt;
        private KiSS4.Gui.KissCheckEdit edtIsMandatsTraeger;
        private KiSS4.Gui.KissLookUpEdit edtModulCode;
        private KiSS4.Gui.KissLabel lblModulCode;
        private KiSS4.Gui.KissLookUpEdit edtGrantPermGroupID;
        private KiSS4.Gui.KissLabel lblGrantPermGroupID;
        private KiSS4.Gui.KissLookUpEdit edtPermissionGroupID;
        private KiSS4.Gui.KissLabel lblPermissionGroupID;
        private SharpLibrary.WinControls.TabPageEx tpgBaAdresse;
        private KiSS4.Gui.KissTextEdit edtXUserFax;
        private KiSS4.Gui.KissLabel lblGrunddatenFax;
        private KiSS4.Gui.KissTextEdit edtXUserPhoneGesch;
        private KiSS4.Gui.KissLabel lblGrunddatenTelefonMobil;
        private KiSS4.Gui.KissLabel lblGrunddatenTelefon;
        private KiSS4.Gui.KissTextEdit edtXUserEmail;
        private KiSS4.Gui.KissLabel lblGrunddatenEmail;
        private KiSS4.Gui.KissTextEdit edtAdressePostfach;
        private KiSS4.Gui.KissLabel lblGrunddatenAdressePostfach;
        private KiSS4.Gui.KissTextEdit edtAdresseHausNr;
        private KiSS4.Gui.KissTextEdit edtAdresseStrasse;
        private KiSS4.Gui.KissLabel lblGrunddatenAdresseStrasseNr;
        private KiSS4.Gui.KissTextEdit edtAdresseZusatz;
        private KiSS4.Gui.KissLabel lblGrunddatenAdresseZusatz;
        private KiSS4.Gui.KissTextEdit edtXUserPhonePrivat;
        private KiSS4.Gui.KissTextEdit edtXUSerPhoneMobile;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissCheckEdit chkPostfachOhneNummer;
        private KiSS4.DB.SqlQuery qryBaAdresse;
        private KiSS4.Common.KissPLZOrt edtPLZWohnsitz;
        private KiSS4.Gui.KissLabel lblGrunddatenAdresseLand;
        private KiSS4.Gui.KissLabel lblGrunddatenAdresseBezirk;
        private KiSS4.Gui.KissLabel lblGrunddatenAdressePLZOrtKt;
        private KiSS4.Gui.KissLookUpEdit edtQualifikation;
        private KiSS4.Gui.KissLookUpEdit edtFunktionsbezeichnung;
        private KiSS4.Gui.KissLabel lblQualifikation;
        private KiSS4.Gui.KissLabel lblFunktionsbezeichnung;
        private KiSS4.Gui.KissCheckEdit edtKeinExport;
        private SharpLibrary.WinControls.TabPageEx tpgStundenansatz;
        private KiSS4.Gui.KissLabel lblStundenansatz1;
        private KiSS4.Gui.KissMoneyEdit edtStundenansatz20;
        private KiSS4.Gui.KissMoneyEdit edtStundenansatz10;
        private KiSS4.Gui.KissMoneyEdit edtStundenansatz19;
        private KiSS4.Gui.KissMoneyEdit edtStundenansatz9;
        private KiSS4.Gui.KissMoneyEdit edtStundenansatz18;
        private KiSS4.Gui.KissMoneyEdit edtStundenansatz8;
        private KiSS4.Gui.KissMoneyEdit edtStundenansatz17;
        private KiSS4.Gui.KissMoneyEdit edtStundenansatz7;
        private KiSS4.Gui.KissMoneyEdit edtStundenansatz16;
        private KiSS4.Gui.KissMoneyEdit edtStundenansatz6;
        private KiSS4.Gui.KissMoneyEdit edtStundenansatz15;
        private KiSS4.Gui.KissMoneyEdit edtStundenansatz5;
        private KiSS4.Gui.KissMoneyEdit edtStundenansatz14;
        private KiSS4.Gui.KissMoneyEdit edtStundenansatz4;
        private KiSS4.Gui.KissMoneyEdit edtStundenansatz13;
        private KiSS4.Gui.KissMoneyEdit edtStundenansatz3;
        private KiSS4.Gui.KissMoneyEdit edtStundenansatz12;
        private KiSS4.Gui.KissMoneyEdit edtStundenansatz2;
        private KiSS4.Gui.KissMoneyEdit edtStundenansatz11;
        private KiSS4.Gui.KissMoneyEdit edtStundenansatz1;
        private KiSS4.Gui.KissLabel lblStundenansatz20;
        private KiSS4.Gui.KissLabel lblStundenansatz10;
        private KiSS4.Gui.KissLabel lblStundenansatz19;
        private KiSS4.Gui.KissLabel lblStundenansatz9;
        private KiSS4.Gui.KissLabel lblStundenansatz18;
        private KiSS4.Gui.KissLabel lblStundenansatz8;
        private KiSS4.Gui.KissLabel lblStundenansatz17;
        private KiSS4.Gui.KissLabel lblStundenansatz7;
        private KiSS4.Gui.KissLabel lblStundenansatz16;
        private KiSS4.Gui.KissLabel lblStundenansatz6;
        private KiSS4.Gui.KissLabel lblStundenansatz15;
        private KiSS4.Gui.KissLabel lblStundenansatz5;
        private KiSS4.Gui.KissLabel lblStundenansatz14;
        private KiSS4.Gui.KissLabel lblStundenansatz4;
        private KiSS4.Gui.KissLabel lblStundenansatz13;
        private KiSS4.Gui.KissLabel lblStundenansatz3;
        private KiSS4.Gui.KissLabel lblStundenansatz12;
        private KiSS4.Gui.KissLabel lblStundenansatz2;
        private KiSS4.Gui.KissLabel lblStundenansatz11;
        private KiSS4.DB.SqlQuery qryXUserStundenansatz;
        private Gui.KissTextEdit edtPersonaldatenWeitereKTR;
        private Gui.KissLabel lblPersonaldatenWeitereKTR;
        private DevExpress.XtraGrid.Columns.GridColumn colUserWeitereKTR;
        private DevExpress.XtraGrid.Columns.GridColumn colUserStandardKostenart;
    }
}
