using KiSS4.Gui;

namespace KiSS4.Main.ZH
{
    public partial class CtlSuchePerson
    {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlSuchePerson));
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
            this.tabPerson = new KiSS4.Gui.KissTabControlEx();
            this.tbpVIS = new SharpLibrary.WinControls.TabPageEx();
            this.kissLabel42 = new KiSS4.Gui.KissLabel();
            this.kissLabel40 = new KiSS4.Gui.KissLabel();
            this.kissLabel39 = new KiSS4.Gui.KissLabel();
            this.kissLabel37 = new KiSS4.Gui.KissLabel();
            this.kissLabel67 = new KiSS4.Gui.KissLabel();
            this.ctlGotoFall1 = new KiSS4.Common.CtlGotoFall();
            this.kissLabel43 = new KiSS4.Gui.KissLabel();
            this.kissLabel49 = new KiSS4.Gui.KissLabel();
            this.kissLabel52 = new KiSS4.Gui.KissLabel();
            this.kissLabel53 = new KiSS4.Gui.KissLabel();
            this.kissLabel54 = new KiSS4.Gui.KissLabel();
            this.kissLabel55 = new KiSS4.Gui.KissLabel();
            this.kissLabel56 = new KiSS4.Gui.KissLabel();
            this.tabVISSearch = new KiSS4.Gui.KissTabControlEx();
            this.tpgVISSuchen = new SharpLibrary.WinControls.TabPageEx();
            this.kissLabel61 = new KiSS4.Gui.KissLabel();
            this.edtSucheVISFallNr = new KiSS4.Gui.KissCalcEdit();
            this.kissLabel62 = new KiSS4.Gui.KissLabel();
            this.edtSucheVISZIPNr = new KiSS4.Gui.KissCalcEdit();
            this.kissLabel63 = new KiSS4.Gui.KissLabel();
            this.edtSucheVISGeburtsdatum = new KiSS4.Gui.KissDateEdit();
            this.kissLabel64 = new KiSS4.Gui.KissLabel();
            this.kissLabel65 = new KiSS4.Gui.KissLabel();
            this.edtSucheVISVorname = new KiSS4.Gui.KissTextEdit();
            this.kissSearchTitel1 = new KiSS4.Gui.KissSearchTitel();
            this.kissLabel66 = new KiSS4.Gui.KissLabel();
            this.edtSucheVISNachname = new KiSS4.Gui.KissTextEdit();
            this.tpgVISListe = new SharpLibrary.WinControls.TabPageEx();
            this.grdVISMandant = new KiSS4.Gui.KissGrid();
            this.qryVISMandant = new KiSS4.DB.SqlQuery();
            this.grvVISMandant = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colVISFallNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZipInKiss = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemCheckEdit6 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grdVISMassnahme = new KiSS4.Gui.KissGrid();
            this.qryVISMassnahme = new KiSS4.DB.SqlQuery();
            this.grvVISMassnahme = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colVormschID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMassnahmeVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMassnahmeBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMassnahme = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMandatTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.kissTextEdit2 = new KiSS4.Gui.KissTextEdit();
            this.kissTextEdit5 = new KiSS4.Gui.KissTextEdit();
            this.kissTextEdit3 = new KiSS4.Gui.KissTextEdit();
            this.kissDateEdit1 = new KiSS4.Gui.KissDateEdit();
            this.kissTextEdit6 = new KiSS4.Gui.KissTextEdit();
            this.kissTextEdit8 = new KiSS4.Gui.KissTextEdit();
            this.kissTextEdit9 = new KiSS4.Gui.KissTextEdit();
            this.kissTextEdit4 = new KiSS4.Gui.KissTextEdit();
            this.kissTextEdit1 = new KiSS4.Gui.KissTextEdit();
            this.tpgPersonErfassen = new SharpLibrary.WinControls.TabPageEx();
            this.lblMeldungBerechnungsperson = new KiSS4.Gui.KissLabel();
            this.edtErfassenVersichertennummer = new KiSS4.Gui.KissVersichertenNrEdit();
            this.qryNeuePerson = new KiSS4.DB.SqlQuery();
            this.kissLabel44 = new KiSS4.Gui.KissLabel();
            this.edtPersonOhneLeistung = new KiSS4.Gui.KissCheckEdit();
            this.kissLabel36 = new KiSS4.Gui.KissLabel();
            this.kissLabel34 = new KiSS4.Gui.KissLabel();
            this.kissLabel33 = new KiSS4.Gui.KissLabel();
            this.edtErfassenNationalitaet = new KiSS4.Gui.KissLookUpEdit();
            this.kissLabel32 = new KiSS4.Gui.KissLabel();
            this.edtErfassenGeschlecht = new KiSS4.Gui.KissLookUpEdit();
            this.kissLabel31 = new KiSS4.Gui.KissLabel();
            this.edtErfassenGeburtsdatum = new KiSS4.Gui.KissDateEdit();
            this.kissLabel30 = new KiSS4.Gui.KissLabel();
            this.edtErfassenAHVNummer = new KiSS4.Gui.KissTextEdit();
            this.kissLabel29 = new KiSS4.Gui.KissLabel();
            this.edtErfassenVorname = new KiSS4.Gui.KissTextEdit();
            this.kissLabel28 = new KiSS4.Gui.KissLabel();
            this.edtErfassenName = new KiSS4.Gui.KissTextEdit();
            this.tpgPersonSuchen = new SharpLibrary.WinControls.TabPageEx();
            this.lblPID = new KiSS4.Gui.KissLabel();
            this.edtPID = new KiSS4.Gui.KissTextEdit();
            this.qryVwPerson = new KiSS4.DB.SqlQuery();
            this.kissLabel35 = new KiSS4.Gui.KissLabel();
            this.kissLabel26 = new KiSS4.Gui.KissLabel();
            this.ctlGotoFall = new KiSS4.Common.CtlGotoFall();
            this.kissLabel38 = new KiSS4.Gui.KissLabel();
            this.kissLabel25 = new KiSS4.Gui.KissLabel();
            this.kissLabel24 = new KiSS4.Gui.KissLabel();
            this.kissLabel23 = new KiSS4.Gui.KissLabel();
            this.kissLabel22 = new KiSS4.Gui.KissLabel();
            this.kissLabel21 = new KiSS4.Gui.KissLabel();
            this.btnKIS = new KiSS4.Gui.KissHyperlinkButton();
            this.kissLabel20 = new KiSS4.Gui.KissLabel();
            this.edtSozialraum = new KiSS4.Gui.KissButtonEdit();
            this.kissLabel19 = new KiSS4.Gui.KissLabel();
            this.edtZIPNr = new KiSS4.Gui.KissTextEdit();
            this.kissLabel18 = new KiSS4.Gui.KissLabel();
            this.edtWMALand = new KiSS4.Gui.KissLookUpEdit();
            this.edtWMAOrt = new KiSS4.Common.KissPLZOrt();
            this.edtWMAPostfach = new KiSS4.Gui.KissTextEdit();
            this.edtWMAStrasseHausNr = new KiSS4.Gui.KissTextEdit();
            this.edtWMAAdresszusatz = new KiSS4.Gui.KissTextEdit();
            this.edtEinwohnerregisterAktiv = new KiSS4.Gui.KissCheckEdit();
            this.edtBaPersonID = new KiSS4.Gui.KissTextEdit();
            this.kissLabel17 = new KiSS4.Gui.KissLabel();
            this.edtNationalitaet = new KiSS4.Gui.KissLookUpEdit();
            this.kissLabel16 = new KiSS4.Gui.KissLabel();
            this.edtGeschlecht = new KiSS4.Gui.KissLookUpEdit();
            this.kissLabel15 = new KiSS4.Gui.KissLabel();
            this.edtGeburtsdatum = new KiSS4.Gui.KissDateEdit();
            this.kissLabel14 = new KiSS4.Gui.KissLabel();
            this.edtAHVNummer = new KiSS4.Gui.KissTextEdit();
            this.kissLabel13 = new KiSS4.Gui.KissLabel();
            this.edtVersichertennummer = new KiSS4.Gui.KissTextEdit();
            this.kissLabel12 = new KiSS4.Gui.KissLabel();
            this.edtVorname = new KiSS4.Gui.KissTextEdit();
            this.kissLabel11 = new KiSS4.Gui.KissLabel();
            this.edtName = new KiSS4.Gui.KissTextEdit();
            this.tabSearch = new KiSS4.Gui.KissTabControlEx();
            this.tpgSuchen = new SharpLibrary.WinControls.TabPageEx();
            this.edtSucheGeschlecht = new KiSS4.Gui.KissLookUpEdit();
            this.kissLabel45 = new KiSS4.Gui.KissLabel();
            this.edtSuchePID = new KiSS4.Gui.KissTextEdit();
            this.lblSuchePID = new KiSS4.Gui.KissLabel();
            this.edtSucheAHV13 = new KiSS4.Gui.KissVersichertenNrEdit();
            this.edtSucheZemis = new KiSS4.Gui.KissTextEdit();
            this.kissLabel27 = new KiSS4.Gui.KissLabel();
            this.kissLabel10 = new KiSS4.Gui.KissLabel();
            this.edtSucheAuchAehnliche = new KiSS4.Gui.KissCheckEdit();
            this.edtSucheNurAktive = new KiSS4.Gui.KissCheckEdit();
            this.kissLabel9 = new KiSS4.Gui.KissLabel();
            this.kissLabel41 = new KiSS4.Gui.KissLabel();
            this.edtSucheAHV11 = new KiSS4.Gui.KissTextEdit();
            this.kissLabel7 = new KiSS4.Gui.KissLabel();
            this.edtSucheGebDatBis = new KiSS4.Gui.KissDateEdit();
            this.edtSucheGebDatVon = new KiSS4.Gui.KissDateEdit();
            this.edtSucheStrasse = new KiSS4.Gui.KissTextEdit();
            this.edtSearchInKiSS = new KiSS4.Gui.KissCheckEdit();
            this.edtSearchInOmega = new KiSS4.Gui.KissCheckEdit();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.edtSucheHausNr = new KiSS4.Gui.KissTextEdit();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.edtSucheVorname = new KiSS4.Gui.KissTextEdit();
            this.searchTitle = new KiSS4.Gui.KissSearchTitel();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.edtSucheNachname = new KiSS4.Gui.KissTextEdit();
            this.tpgListe = new SharpLibrary.WinControls.TabPageEx();
            this.grdVwPerson = new KiSS4.Gui.KissGrid();
            this.grvVwPerson = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFalltraeger = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeschlecht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVersichertenNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKiSS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colOmega = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinwohnerregisterAktiv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colEinwohnerregisterID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAHVNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.qryAdresse = new KiSS4.DB.SqlQuery();
            this.qryPraemienuebernahme = new KiSS4.DB.SqlQuery();
            this.qryPraemienverbilligung = new KiSS4.DB.SqlQuery();
            this.tabPerson.SuspendLayout();
            this.tbpVIS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel67)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel49)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel53)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel54)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel55)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel56)).BeginInit();
            this.tabVISSearch.SuspendLayout();
            this.tpgVISSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel61)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVISFallNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel62)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVISZIPNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel63)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVISGeburtsdatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel64)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel65)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVISVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel66)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVISNachname.Properties)).BeginInit();
            this.tpgVISListe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVISMandant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVISMandant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVISMandant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVISMassnahme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVISMassnahme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVISMassnahme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissDateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit6.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit8.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit9.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit1.Properties)).BeginInit();
            this.tpgPersonErfassen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblMeldungBerechnungsperson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassenVersichertennummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryNeuePerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonOhneLeistung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassenNationalitaet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassenNationalitaet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassenGeschlecht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassenGeschlecht.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassenGeburtsdatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassenAHVNummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassenVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassenName.Properties)).BeginInit();
            this.tpgPersonSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblPID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVwPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSozialraum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZIPNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWMALand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWMALand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWMAPostfach.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWMAStrasseHausNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWMAAdresszusatz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinwohnerregisterAktiv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlecht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlecht.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsdatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAHVNummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersichertennummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).BeginInit();
            this.tabSearch.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGeschlecht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGeschlecht.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchePID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchePID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAHV13.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheZemis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAuchAehnliche.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNurAktive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAHV11.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGebDatBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGebDatVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchInKiSS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchInOmega.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheHausNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNachname.Properties)).BeginInit();
            this.tpgListe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVwPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVwPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAdresse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPraemienuebernahme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPraemienverbilligung)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPerson
            // 
            this.tabPerson.Controls.Add(this.tbpVIS);
            this.tabPerson.Controls.Add(this.tpgPersonErfassen);
            this.tabPerson.Controls.Add(this.tpgPersonSuchen);
            this.tabPerson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPerson.Location = new System.Drawing.Point(0, 0);
            this.tabPerson.Name = "tabPerson";
            this.tabPerson.ShowFixedWidthTooltip = true;
            this.tabPerson.Size = new System.Drawing.Size(964, 618);
            this.tabPerson.TabIndex = 0;
            this.tabPerson.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgPersonSuchen,
            this.tbpVIS,
            this.tpgPersonErfassen});
            this.tabPerson.TabsLineColor = System.Drawing.Color.Black;
            this.tabPerson.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabPerson.Text = "kissTabControlEx2";
            // 
            // tbpVIS
            // 
            this.tbpVIS.Controls.Add(this.kissLabel42);
            this.tbpVIS.Controls.Add(this.kissLabel40);
            this.tbpVIS.Controls.Add(this.kissLabel39);
            this.tbpVIS.Controls.Add(this.kissLabel37);
            this.tbpVIS.Controls.Add(this.kissLabel67);
            this.tbpVIS.Controls.Add(this.ctlGotoFall1);
            this.tbpVIS.Controls.Add(this.kissLabel43);
            this.tbpVIS.Controls.Add(this.kissLabel49);
            this.tbpVIS.Controls.Add(this.kissLabel52);
            this.tbpVIS.Controls.Add(this.kissLabel53);
            this.tbpVIS.Controls.Add(this.kissLabel54);
            this.tbpVIS.Controls.Add(this.kissLabel55);
            this.tbpVIS.Controls.Add(this.kissLabel56);
            this.tbpVIS.Controls.Add(this.tabVISSearch);
            this.tbpVIS.Controls.Add(this.grdVISMassnahme);
            this.tbpVIS.Controls.Add(this.kissTextEdit2);
            this.tbpVIS.Controls.Add(this.kissTextEdit5);
            this.tbpVIS.Controls.Add(this.kissTextEdit3);
            this.tbpVIS.Controls.Add(this.kissDateEdit1);
            this.tbpVIS.Controls.Add(this.kissTextEdit6);
            this.tbpVIS.Controls.Add(this.kissTextEdit8);
            this.tbpVIS.Controls.Add(this.kissTextEdit9);
            this.tbpVIS.Controls.Add(this.kissTextEdit4);
            this.tbpVIS.Controls.Add(this.kissTextEdit1);
            this.tbpVIS.Location = new System.Drawing.Point(6, 6);
            this.tbpVIS.Name = "tbpVIS";
            this.tbpVIS.Size = new System.Drawing.Size(952, 580);
            this.tbpVIS.TabIndex = 2;
            this.tbpVIS.Title = "Person in VIS suchen";
            // 
            // kissLabel42
            // 
            this.kissLabel42.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel42.Location = new System.Drawing.Point(169, 378);
            this.kissLabel42.Name = "kissLabel42";
            this.kissLabel42.Size = new System.Drawing.Size(39, 24);
            this.kissLabel42.TabIndex = 86;
            this.kissLabel42.Text = "PID";
            this.kissLabel42.UseCompatibleTextRendering = true;
            // 
            // kissLabel40
            // 
            this.kissLabel40.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel40.Location = new System.Drawing.Point(8, 500);
            this.kissLabel40.Name = "kissLabel40";
            this.kissLabel40.Size = new System.Drawing.Size(64, 24);
            this.kissLabel40.TabIndex = 84;
            this.kissLabel40.Text = "Geschlecht";
            this.kissLabel40.UseCompatibleTextRendering = true;
            // 
            // kissLabel39
            // 
            this.kissLabel39.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel39.Location = new System.Drawing.Point(8, 546);
            this.kissLabel39.Name = "kissLabel39";
            this.kissLabel39.Size = new System.Drawing.Size(64, 24);
            this.kissLabel39.TabIndex = 82;
            this.kissLabel39.Text = "Ort";
            this.kissLabel39.UseCompatibleTextRendering = true;
            // 
            // kissLabel37
            // 
            this.kissLabel37.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel37.Location = new System.Drawing.Point(8, 378);
            this.kissLabel37.Name = "kissLabel37";
            this.kissLabel37.Size = new System.Drawing.Size(64, 24);
            this.kissLabel37.TabIndex = 80;
            this.kissLabel37.Text = "VIS FallNr.";
            this.kissLabel37.UseCompatibleTextRendering = true;
            // 
            // kissLabel67
            // 
            this.kissLabel67.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.kissLabel67.Location = new System.Drawing.Point(4, 9);
            this.kissLabel67.Name = "kissLabel67";
            this.kissLabel67.Size = new System.Drawing.Size(609, 16);
            this.kissLabel67.TabIndex = 77;
            this.kissLabel67.Text = "Person in VIS suchen";
            this.kissLabel67.UseCompatibleTextRendering = true;
            // 
            // ctlGotoFall1
            // 
            this.ctlGotoFall1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctlGotoFall1.DisplayModules = null;
            this.ctlGotoFall1.Location = new System.Drawing.Point(133, 325);
            this.ctlGotoFall1.Name = "ctlGotoFall1";
            this.ctlGotoFall1.Size = new System.Drawing.Size(106, 27);
            this.ctlGotoFall1.TabIndex = 73;
            this.ctlGotoFall1.Visible = false;
            // 
            // kissLabel43
            // 
            this.kissLabel43.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel43.Location = new System.Drawing.Point(8, 523);
            this.kissLabel43.Name = "kissLabel43";
            this.kissLabel43.Size = new System.Drawing.Size(64, 24);
            this.kissLabel43.TabIndex = 70;
            this.kissLabel43.Text = "Strasse";
            this.kissLabel43.UseCompatibleTextRendering = true;
            // 
            // kissLabel49
            // 
            this.kissLabel49.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel49.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel49.Location = new System.Drawing.Point(323, 356);
            this.kissLabel49.Name = "kissLabel49";
            this.kissLabel49.Size = new System.Drawing.Size(152, 16);
            this.kissLabel49.TabIndex = 61;
            this.kissLabel49.Text = "Massnahmen";
            this.kissLabel49.UseCompatibleTextRendering = true;
            // 
            // kissLabel52
            // 
            this.kissLabel52.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel52.Location = new System.Drawing.Point(8, 477);
            this.kissLabel52.Name = "kissLabel52";
            this.kissLabel52.Size = new System.Drawing.Size(64, 24);
            this.kissLabel52.TabIndex = 49;
            this.kissLabel52.Text = "Geburt";
            this.kissLabel52.UseCompatibleTextRendering = true;
            // 
            // kissLabel53
            // 
            this.kissLabel53.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel53.Location = new System.Drawing.Point(8, 454);
            this.kissLabel53.Name = "kissLabel53";
            this.kissLabel53.Size = new System.Drawing.Size(64, 24);
            this.kissLabel53.TabIndex = 47;
            this.kissLabel53.Text = "AHV-Nr";
            this.kissLabel53.UseCompatibleTextRendering = true;
            // 
            // kissLabel54
            // 
            this.kissLabel54.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel54.Location = new System.Drawing.Point(8, 431);
            this.kissLabel54.Name = "kissLabel54";
            this.kissLabel54.Size = new System.Drawing.Size(64, 24);
            this.kissLabel54.TabIndex = 45;
            this.kissLabel54.Text = "Vorname";
            this.kissLabel54.UseCompatibleTextRendering = true;
            // 
            // kissLabel55
            // 
            this.kissLabel55.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel55.Location = new System.Drawing.Point(8, 408);
            this.kissLabel55.Name = "kissLabel55";
            this.kissLabel55.Size = new System.Drawing.Size(64, 24);
            this.kissLabel55.TabIndex = 43;
            this.kissLabel55.Text = "Name";
            this.kissLabel55.UseCompatibleTextRendering = true;
            // 
            // kissLabel56
            // 
            this.kissLabel56.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel56.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel56.Location = new System.Drawing.Point(78, 356);
            this.kissLabel56.Name = "kissLabel56";
            this.kissLabel56.Size = new System.Drawing.Size(123, 21);
            this.kissLabel56.TabIndex = 41;
            this.kissLabel56.Text = "Person/Adresse";
            this.kissLabel56.UseCompatibleTextRendering = true;
            // 
            // tabVISSearch
            // 
            this.tabVISSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabVISSearch.Controls.Add(this.tpgVISSuchen);
            this.tabVISSearch.Controls.Add(this.tpgVISListe);
            this.tabVISSearch.Location = new System.Drawing.Point(3, 27);
            this.tabVISSearch.Name = "tabVISSearch";
            this.tabVISSearch.ShowFixedWidthTooltip = true;
            this.tabVISSearch.Size = new System.Drawing.Size(941, 321);
            this.tabVISSearch.TabIndex = 40;
            this.tabVISSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgVISListe,
            this.tpgVISSuchen});
            this.tabVISSearch.TabsLineColor = System.Drawing.Color.Black;
            this.tabVISSearch.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabVISSearch.Text = "kissTabControlEx3";
            this.tabVISSearch.SelectedTabChanging += new System.ComponentModel.CancelEventHandler(this.tabVISSearch_SelectedTabChanging);
            // 
            // tpgVISSuchen
            // 
            this.tpgVISSuchen.Controls.Add(this.kissLabel61);
            this.tpgVISSuchen.Controls.Add(this.edtSucheVISFallNr);
            this.tpgVISSuchen.Controls.Add(this.kissLabel62);
            this.tpgVISSuchen.Controls.Add(this.edtSucheVISZIPNr);
            this.tpgVISSuchen.Controls.Add(this.kissLabel63);
            this.tpgVISSuchen.Controls.Add(this.edtSucheVISGeburtsdatum);
            this.tpgVISSuchen.Controls.Add(this.kissLabel64);
            this.tpgVISSuchen.Controls.Add(this.kissLabel65);
            this.tpgVISSuchen.Controls.Add(this.edtSucheVISVorname);
            this.tpgVISSuchen.Controls.Add(this.kissSearchTitel1);
            this.tpgVISSuchen.Controls.Add(this.kissLabel66);
            this.tpgVISSuchen.Controls.Add(this.edtSucheVISNachname);
            this.tpgVISSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgVISSuchen.Name = "tpgVISSuchen";
            this.tpgVISSuchen.Size = new System.Drawing.Size(929, 283);
            this.tpgVISSuchen.TabIndex = 1;
            this.tpgVISSuchen.Title = "Suchen";
            // 
            // kissLabel61
            // 
            this.kissLabel61.Location = new System.Drawing.Point(8, 105);
            this.kissLabel61.Name = "kissLabel61";
            this.kissLabel61.Size = new System.Drawing.Size(72, 24);
            this.kissLabel61.TabIndex = 10;
            this.kissLabel61.Text = "Geburt";
            this.kissLabel61.UseCompatibleTextRendering = true;
            // 
            // edtSucheVISFallNr
            // 
            this.edtSucheVISFallNr.Location = new System.Drawing.Point(410, 73);
            this.edtSucheVISFallNr.Name = "edtSucheVISFallNr";
            this.edtSucheVISFallNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheVISFallNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheVISFallNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheVISFallNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheVISFallNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheVISFallNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheVISFallNr.Properties.Appearance.Options.UseFont = true;
            this.edtSucheVISFallNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheVISFallNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheVISFallNr.Size = new System.Drawing.Size(100, 24);
            this.edtSucheVISFallNr.TabIndex = 5;
            // 
            // kissLabel62
            // 
            this.kissLabel62.Location = new System.Drawing.Point(346, 73);
            this.kissLabel62.Name = "kissLabel62";
            this.kissLabel62.Size = new System.Drawing.Size(64, 24);
            this.kissLabel62.TabIndex = 4;
            this.kissLabel62.Text = "VIS FallNr.";
            this.kissLabel62.UseCompatibleTextRendering = true;
            // 
            // edtSucheVISZIPNr
            // 
            this.edtSucheVISZIPNr.Location = new System.Drawing.Point(410, 43);
            this.edtSucheVISZIPNr.Name = "edtSucheVISZIPNr";
            this.edtSucheVISZIPNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheVISZIPNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheVISZIPNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheVISZIPNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheVISZIPNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheVISZIPNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheVISZIPNr.Properties.Appearance.Options.UseFont = true;
            this.edtSucheVISZIPNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheVISZIPNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheVISZIPNr.Size = new System.Drawing.Size(100, 24);
            this.edtSucheVISZIPNr.TabIndex = 4;
            // 
            // kissLabel63
            // 
            this.kissLabel63.Location = new System.Drawing.Point(346, 43);
            this.kissLabel63.Name = "kissLabel63";
            this.kissLabel63.Size = new System.Drawing.Size(64, 24);
            this.kissLabel63.TabIndex = 3;
            this.kissLabel63.Text = "PID";
            this.kissLabel63.UseCompatibleTextRendering = true;
            // 
            // edtSucheVISGeburtsdatum
            // 
            this.edtSucheVISGeburtsdatum.EditValue = null;
            this.edtSucheVISGeburtsdatum.Location = new System.Drawing.Point(87, 105);
            this.edtSucheVISGeburtsdatum.Name = "edtSucheVISGeburtsdatum";
            this.edtSucheVISGeburtsdatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheVISGeburtsdatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheVISGeburtsdatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheVISGeburtsdatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheVISGeburtsdatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheVISGeburtsdatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheVISGeburtsdatum.Properties.Appearance.Options.UseFont = true;
            this.edtSucheVISGeburtsdatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject14.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject14.Options.UseBackColor = true;
            this.edtSucheVISGeburtsdatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheVISGeburtsdatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject14)});
            this.edtSucheVISGeburtsdatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheVISGeburtsdatum.Properties.Name = "kissDateEdit1.Properties";
            this.edtSucheVISGeburtsdatum.Properties.ShowToday = false;
            this.edtSucheVISGeburtsdatum.Size = new System.Drawing.Size(100, 24);
            this.edtSucheVISGeburtsdatum.TabIndex = 3;
            // 
            // kissLabel64
            // 
            this.kissLabel64.Location = new System.Drawing.Point(8, 75);
            this.kissLabel64.Name = "kissLabel64";
            this.kissLabel64.Size = new System.Drawing.Size(64, 24);
            this.kissLabel64.TabIndex = 2;
            this.kissLabel64.Text = "Vorname";
            this.kissLabel64.UseCompatibleTextRendering = true;
            // 
            // kissLabel65
            // 
            this.kissLabel65.Location = new System.Drawing.Point(8, 45);
            this.kissLabel65.Name = "kissLabel65";
            this.kissLabel65.Size = new System.Drawing.Size(64, 24);
            this.kissLabel65.TabIndex = 1;
            this.kissLabel65.Text = "Name";
            this.kissLabel65.UseCompatibleTextRendering = true;
            // 
            // edtSucheVISVorname
            // 
            this.edtSucheVISVorname.Location = new System.Drawing.Point(87, 75);
            this.edtSucheVISVorname.Name = "edtSucheVISVorname";
            this.edtSucheVISVorname.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheVISVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheVISVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheVISVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheVISVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheVISVorname.Properties.Appearance.Options.UseFont = true;
            this.edtSucheVISVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheVISVorname.Size = new System.Drawing.Size(232, 24);
            this.edtSucheVISVorname.TabIndex = 1;
            // 
            // kissSearchTitel1
            // 
            this.kissSearchTitel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissSearchTitel1.Location = new System.Drawing.Point(8, 3);
            this.kissSearchTitel1.Name = "kissSearchTitel1";
            this.kissSearchTitel1.Size = new System.Drawing.Size(846, 24);
            this.kissSearchTitel1.TabIndex = 0;
            // 
            // kissLabel66
            // 
            this.kissLabel66.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel66.Location = new System.Drawing.Point(24, 8);
            this.kissLabel66.Name = "kissLabel66";
            this.kissLabel66.Size = new System.Drawing.Size(100, 16);
            this.kissLabel66.TabIndex = 0;
            this.kissLabel66.Text = "Suchen";
            this.kissLabel66.UseCompatibleTextRendering = true;
            // 
            // edtSucheVISNachname
            // 
            this.edtSucheVISNachname.Location = new System.Drawing.Point(87, 45);
            this.edtSucheVISNachname.Name = "edtSucheVISNachname";
            this.edtSucheVISNachname.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheVISNachname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheVISNachname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheVISNachname.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheVISNachname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheVISNachname.Properties.Appearance.Options.UseFont = true;
            this.edtSucheVISNachname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheVISNachname.Properties.Name = "kissTextEdit1.Properties";
            this.edtSucheVISNachname.Size = new System.Drawing.Size(232, 24);
            this.edtSucheVISNachname.TabIndex = 0;
            // 
            // tpgVISListe
            // 
            this.tpgVISListe.Controls.Add(this.grdVISMandant);
            this.tpgVISListe.Location = new System.Drawing.Point(6, 6);
            this.tpgVISListe.Name = "tpgVISListe";
            this.tpgVISListe.Size = new System.Drawing.Size(929, 283);
            this.tpgVISListe.TabIndex = 0;
            this.tpgVISListe.Title = "Liste";
            // 
            // grdVISMandant
            // 
            this.grdVISMandant.DataSource = this.qryVISMandant;
            this.grdVISMandant.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdVISMandant.EmbeddedNavigator.Name = "kissGrid1.EmbeddedNavigator";
            this.grdVISMandant.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdVISMandant.Location = new System.Drawing.Point(0, 0);
            this.grdVISMandant.MainView = this.grvVISMandant;
            this.grdVISMandant.Name = "grdVISMandant";
            this.grdVISMandant.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit5,
            this.repositoryItemGridLookUpEdit2,
            this.repositoryItemCheckEdit6,
            this.repositoryItemCheckEdit4});
            this.grdVISMandant.ShowDefaultPopup = false;
            this.grdVISMandant.Size = new System.Drawing.Size(929, 283);
            this.grdVISMandant.TabIndex = 0;
            this.grdVISMandant.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVISMandant});
            // 
            // qryVISMandant
            // 
            this.qryVISMandant.HostControl = this;
            this.qryVISMandant.SelectStatement = "-- Statement wird im Code zusammengesetzt\r\n--------------------------------------" +
    "-------\r\n";
            this.qryVISMandant.AfterFill += new System.EventHandler(this.qryVISMandant_AfterFill);
            this.qryVISMandant.PositionChanged += new System.EventHandler(this.qryVISMandant_PositionChanged);
            // 
            // grvVISMandant
            // 
            this.grvVISMandant.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvVISMandant.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVISMandant.Appearance.Empty.Options.UseBackColor = true;
            this.grvVISMandant.Appearance.Empty.Options.UseFont = true;
            this.grvVISMandant.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVISMandant.Appearance.EvenRow.Options.UseFont = true;
            this.grvVISMandant.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVISMandant.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVISMandant.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvVISMandant.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvVISMandant.Appearance.FocusedCell.Options.UseFont = true;
            this.grvVISMandant.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvVISMandant.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVISMandant.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVISMandant.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvVISMandant.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvVISMandant.Appearance.FocusedRow.Options.UseFont = true;
            this.grvVISMandant.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvVISMandant.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVISMandant.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvVISMandant.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvVISMandant.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvVISMandant.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVISMandant.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvVISMandant.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVISMandant.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVISMandant.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVISMandant.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvVISMandant.Appearance.GroupRow.Options.UseFont = true;
            this.grvVISMandant.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvVISMandant.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvVISMandant.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvVISMandant.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVISMandant.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvVISMandant.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvVISMandant.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvVISMandant.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvVISMandant.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVISMandant.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVISMandant.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvVISMandant.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvVISMandant.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvVISMandant.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvVISMandant.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvVISMandant.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVISMandant.Appearance.OddRow.Options.UseFont = true;
            this.grvVISMandant.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvVISMandant.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVISMandant.Appearance.Row.Options.UseBackColor = true;
            this.grvVISMandant.Appearance.Row.Options.UseFont = true;
            this.grvVISMandant.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVISMandant.Appearance.SelectedRow.Options.UseFont = true;
            this.grvVISMandant.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvVISMandant.Appearance.VertLine.Options.UseBackColor = true;
            this.grvVISMandant.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvVISMandant.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colVISFallNr,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.colZipInKiss,
            this.gridColumn12});
            this.grvVISMandant.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvVISMandant.GridControl = this.grdVISMandant;
            this.grvVISMandant.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvVISMandant.Name = "grvVISMandant";
            this.grvVISMandant.OptionsBehavior.Editable = false;
            this.grvVISMandant.OptionsCustomization.AllowFilter = false;
            this.grvVISMandant.OptionsFilter.AllowFilterEditor = false;
            this.grvVISMandant.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvVISMandant.OptionsMenu.EnableColumnMenu = false;
            this.grvVISMandant.OptionsNavigation.AutoFocusNewRow = true;
            this.grvVISMandant.OptionsNavigation.UseTabKey = false;
            this.grvVISMandant.OptionsView.ColumnAutoWidth = false;
            this.grvVISMandant.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvVISMandant.OptionsView.ShowGroupPanel = false;
            this.grvVISMandant.OptionsView.ShowIndicator = false;
            // 
            // colVISFallNr
            // 
            this.colVISFallNr.Caption = "VIS FallNr.";
            this.colVISFallNr.FieldName = "VIS_FallNr";
            this.colVISFallNr.Name = "colVISFallNr";
            this.colVISFallNr.Visible = true;
            this.colVISFallNr.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Name";
            this.gridColumn2.FieldName = "Nachname";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 147;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Vorname";
            this.gridColumn3.FieldName = "Vorname";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 103;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Strasse";
            this.gridColumn4.FieldName = "Strasse";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 106;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Ort";
            this.gridColumn5.FieldName = "Ort";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 91;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "M/W";
            this.gridColumn6.FieldName = "Geschlecht";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 37;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Geburt";
            this.gridColumn7.FieldName = "Geburtsdatum";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 80;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "AHV-Nr";
            this.gridColumn8.FieldName = "AHVNummer";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            this.gridColumn8.Width = 82;
            // 
            // colZipInKiss
            // 
            this.colZipInKiss.Caption = "K-PID";
            this.colZipInKiss.ColumnEdit = this.repositoryItemCheckEdit5;
            this.colZipInKiss.FieldName = "ZipInKiss";
            this.colZipInKiss.Name = "colZipInKiss";
            this.colZipInKiss.Width = 50;
            // 
            // repositoryItemCheckEdit5
            // 
            this.repositoryItemCheckEdit5.AutoHeight = false;
            this.repositoryItemCheckEdit5.Name = "repositoryItemCheckEdit5";
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "PID";
            this.gridColumn12.FieldName = "ZIPNr";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 8;
            this.gridColumn12.Width = 80;
            // 
            // repositoryItemGridLookUpEdit2
            // 
            this.repositoryItemGridLookUpEdit2.AutoHeight = false;
            this.repositoryItemGridLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit2.Name = "repositoryItemGridLookUpEdit2";
            this.repositoryItemGridLookUpEdit2.View = this.gridView4;
            // 
            // gridView4
            // 
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            // 
            // repositoryItemCheckEdit6
            // 
            this.repositoryItemCheckEdit6.AutoHeight = false;
            this.repositoryItemCheckEdit6.Name = "repositoryItemCheckEdit6";
            this.repositoryItemCheckEdit6.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // repositoryItemCheckEdit4
            // 
            this.repositoryItemCheckEdit4.AutoHeight = false;
            this.repositoryItemCheckEdit4.Name = "repositoryItemCheckEdit4";
            this.repositoryItemCheckEdit4.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // grdVISMassnahme
            // 
            this.grdVISMassnahme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grdVISMassnahme.DataSource = this.qryVISMassnahme;
            // 
            // 
            // 
            this.grdVISMassnahme.EmbeddedNavigator.Name = "";
            this.grdVISMassnahme.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdVISMassnahme.Location = new System.Drawing.Point(323, 378);
            this.grdVISMassnahme.MainView = this.grvVISMassnahme;
            this.grdVISMassnahme.Name = "grdVISMassnahme";
            this.grdVISMassnahme.Size = new System.Drawing.Size(620, 192);
            this.grdVISMassnahme.TabIndex = 9;
            this.grdVISMassnahme.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVISMassnahme});
            // 
            // qryVISMassnahme
            // 
            this.qryVISMassnahme.HostControl = this;
            this.qryVISMassnahme.SelectStatement = resources.GetString("qryVISMassnahme.SelectStatement");
            // 
            // grvVISMassnahme
            // 
            this.grvVISMassnahme.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvVISMassnahme.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVISMassnahme.Appearance.Empty.Options.UseBackColor = true;
            this.grvVISMassnahme.Appearance.Empty.Options.UseFont = true;
            this.grvVISMassnahme.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVISMassnahme.Appearance.EvenRow.Options.UseFont = true;
            this.grvVISMassnahme.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVISMassnahme.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVISMassnahme.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvVISMassnahme.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvVISMassnahme.Appearance.FocusedCell.Options.UseFont = true;
            this.grvVISMassnahme.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvVISMassnahme.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVISMassnahme.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVISMassnahme.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvVISMassnahme.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvVISMassnahme.Appearance.FocusedRow.Options.UseFont = true;
            this.grvVISMassnahme.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvVISMassnahme.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVISMassnahme.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvVISMassnahme.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvVISMassnahme.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvVISMassnahme.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVISMassnahme.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvVISMassnahme.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVISMassnahme.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVISMassnahme.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVISMassnahme.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvVISMassnahme.Appearance.GroupRow.Options.UseFont = true;
            this.grvVISMassnahme.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvVISMassnahme.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvVISMassnahme.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvVISMassnahme.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVISMassnahme.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvVISMassnahme.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvVISMassnahme.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvVISMassnahme.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvVISMassnahme.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVISMassnahme.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVISMassnahme.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvVISMassnahme.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvVISMassnahme.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvVISMassnahme.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvVISMassnahme.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvVISMassnahme.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVISMassnahme.Appearance.OddRow.Options.UseFont = true;
            this.grvVISMassnahme.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvVISMassnahme.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVISMassnahme.Appearance.Row.Options.UseBackColor = true;
            this.grvVISMassnahme.Appearance.Row.Options.UseFont = true;
            this.grvVISMassnahme.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVISMassnahme.Appearance.SelectedRow.Options.UseFont = true;
            this.grvVISMassnahme.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvVISMassnahme.Appearance.VertLine.Options.UseBackColor = true;
            this.grvVISMassnahme.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvVISMassnahme.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colVormschID,
            this.colMassnahmeVon,
            this.colMassnahmeBis,
            this.colMassnahme,
            this.colMandatTyp,
            this.colMT});
            this.grvVISMassnahme.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvVISMassnahme.GridControl = this.grdVISMassnahme;
            this.grvVISMassnahme.Name = "grvVISMassnahme";
            this.grvVISMassnahme.OptionsBehavior.Editable = false;
            this.grvVISMassnahme.OptionsCustomization.AllowFilter = false;
            this.grvVISMassnahme.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvVISMassnahme.OptionsNavigation.AutoFocusNewRow = true;
            this.grvVISMassnahme.OptionsNavigation.UseTabKey = false;
            this.grvVISMassnahme.OptionsView.ColumnAutoWidth = false;
            this.grvVISMassnahme.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvVISMassnahme.OptionsView.ShowGroupPanel = false;
            this.grvVISMassnahme.OptionsView.ShowIndicator = false;
            // 
            // colVormschID
            // 
            this.colVormschID.Caption = "VormschID";
            this.colVormschID.FieldName = "VIS_VormschID";
            this.colVormschID.Name = "colVormschID";
            this.colVormschID.Visible = true;
            this.colVormschID.VisibleIndex = 0;
            this.colVormschID.Width = 74;
            // 
            // colMassnahmeVon
            // 
            this.colMassnahmeVon.Caption = "von";
            this.colMassnahmeVon.FieldName = "MassnahmeVon";
            this.colMassnahmeVon.Name = "colMassnahmeVon";
            this.colMassnahmeVon.Visible = true;
            this.colMassnahmeVon.VisibleIndex = 1;
            // 
            // colMassnahmeBis
            // 
            this.colMassnahmeBis.Caption = "bis";
            this.colMassnahmeBis.FieldName = "MassnahmeBis";
            this.colMassnahmeBis.Name = "colMassnahmeBis";
            this.colMassnahmeBis.Visible = true;
            this.colMassnahmeBis.VisibleIndex = 2;
            // 
            // colMassnahme
            // 
            this.colMassnahme.Caption = "ZGB";
            this.colMassnahme.FieldName = "Massnahme";
            this.colMassnahme.Name = "colMassnahme";
            this.colMassnahme.Visible = true;
            this.colMassnahme.VisibleIndex = 3;
            this.colMassnahme.Width = 144;
            // 
            // colMandatTyp
            // 
            this.colMandatTyp.Caption = "Typ";
            this.colMandatTyp.FieldName = "Behördliche Massnahme";
            this.colMandatTyp.Name = "colMandatTyp";
            this.colMandatTyp.Visible = true;
            this.colMandatTyp.VisibleIndex = 4;
            this.colMandatTyp.Width = 113;
            // 
            // colMT
            // 
            this.colMT.Caption = "Beist. oder Vorm.";
            this.colMT.FieldName = "MTName";
            this.colMT.Name = "colMT";
            this.colMT.Visible = true;
            this.colMT.VisibleIndex = 5;
            this.colMT.Width = 112;
            // 
            // kissTextEdit2
            // 
            this.kissTextEdit2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissTextEdit2.DataMember = "Ort";
            this.kissTextEdit2.DataSource = this.qryVISMandant;
            this.kissTextEdit2.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit2.Location = new System.Drawing.Point(78, 546);
            this.kissTextEdit2.Name = "kissTextEdit2";
            this.kissTextEdit2.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit2.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit2.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit2.Properties.Name = "kissTextEdit14.Properties";
            this.kissTextEdit2.Properties.ReadOnly = true;
            this.kissTextEdit2.Size = new System.Drawing.Size(224, 24);
            this.kissTextEdit2.TabIndex = 8;
            // 
            // kissTextEdit5
            // 
            this.kissTextEdit5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissTextEdit5.DataMember = "Strasse";
            this.kissTextEdit5.DataSource = this.qryVISMandant;
            this.kissTextEdit5.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit5.Location = new System.Drawing.Point(78, 523);
            this.kissTextEdit5.Name = "kissTextEdit5";
            this.kissTextEdit5.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit5.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit5.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit5.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit5.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit5.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit5.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit5.Properties.Name = "kissTextEdit14.Properties";
            this.kissTextEdit5.Properties.ReadOnly = true;
            this.kissTextEdit5.Size = new System.Drawing.Size(224, 24);
            this.kissTextEdit5.TabIndex = 7;
            // 
            // kissTextEdit3
            // 
            this.kissTextEdit3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissTextEdit3.DataMember = "Geschlecht";
            this.kissTextEdit3.DataSource = this.qryVISMandant;
            this.kissTextEdit3.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit3.Location = new System.Drawing.Point(78, 500);
            this.kissTextEdit3.Name = "kissTextEdit3";
            this.kissTextEdit3.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit3.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit3.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit3.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit3.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit3.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit3.Properties.Name = "kissTextEdit14.Properties";
            this.kissTextEdit3.Properties.ReadOnly = true;
            this.kissTextEdit3.Size = new System.Drawing.Size(224, 24);
            this.kissTextEdit3.TabIndex = 6;
            // 
            // kissDateEdit1
            // 
            this.kissDateEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissDateEdit1.DataMember = "Geburtsdatum";
            this.kissDateEdit1.DataSource = this.qryVISMandant;
            this.kissDateEdit1.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissDateEdit1.EditValue = null;
            this.kissDateEdit1.Location = new System.Drawing.Point(78, 477);
            this.kissDateEdit1.Name = "kissDateEdit1";
            this.kissDateEdit1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.kissDateEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissDateEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissDateEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissDateEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.kissDateEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.kissDateEdit1.Properties.Appearance.Options.UseFont = true;
            this.kissDateEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.kissDateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("kissDateEdit1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.kissDateEdit1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.kissDateEdit1.Properties.Name = "kissDateEdit3.Properties";
            this.kissDateEdit1.Properties.ReadOnly = true;
            this.kissDateEdit1.Properties.ShowToday = false;
            this.kissDateEdit1.Size = new System.Drawing.Size(224, 24);
            this.kissDateEdit1.TabIndex = 5;
            // 
            // kissTextEdit6
            // 
            this.kissTextEdit6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissTextEdit6.DataMember = "AHVNummer";
            this.kissTextEdit6.DataSource = this.qryVISMandant;
            this.kissTextEdit6.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit6.Location = new System.Drawing.Point(78, 454);
            this.kissTextEdit6.Name = "kissTextEdit6";
            this.kissTextEdit6.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit6.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit6.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit6.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit6.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit6.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit6.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit6.Properties.Name = "kissTextEdit8.Properties";
            this.kissTextEdit6.Properties.ReadOnly = true;
            this.kissTextEdit6.Size = new System.Drawing.Size(224, 24);
            this.kissTextEdit6.TabIndex = 4;
            // 
            // kissTextEdit8
            // 
            this.kissTextEdit8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissTextEdit8.DataMember = "Vorname";
            this.kissTextEdit8.DataSource = this.qryVISMandant;
            this.kissTextEdit8.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit8.Location = new System.Drawing.Point(78, 431);
            this.kissTextEdit8.Name = "kissTextEdit8";
            this.kissTextEdit8.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit8.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit8.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit8.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit8.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit8.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit8.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit8.Properties.Name = "kissTextEdit7.Properties";
            this.kissTextEdit8.Properties.ReadOnly = true;
            this.kissTextEdit8.Size = new System.Drawing.Size(224, 24);
            this.kissTextEdit8.TabIndex = 3;
            // 
            // kissTextEdit9
            // 
            this.kissTextEdit9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissTextEdit9.DataMember = "Nachname";
            this.kissTextEdit9.DataSource = this.qryVISMandant;
            this.kissTextEdit9.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit9.Location = new System.Drawing.Point(78, 408);
            this.kissTextEdit9.Name = "kissTextEdit9";
            this.kissTextEdit9.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit9.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit9.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit9.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit9.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit9.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit9.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit9.Properties.Name = "kissTextEdit6.Properties";
            this.kissTextEdit9.Properties.ReadOnly = true;
            this.kissTextEdit9.Size = new System.Drawing.Size(224, 24);
            this.kissTextEdit9.TabIndex = 2;
            // 
            // kissTextEdit4
            // 
            this.kissTextEdit4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissTextEdit4.DataMember = "ZIPNr";
            this.kissTextEdit4.DataSource = this.qryVISMandant;
            this.kissTextEdit4.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit4.Location = new System.Drawing.Point(214, 378);
            this.kissTextEdit4.Name = "kissTextEdit4";
            this.kissTextEdit4.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit4.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit4.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit4.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit4.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit4.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit4.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit4.Properties.Name = "kissTextEdit14.Properties";
            this.kissTextEdit4.Properties.ReadOnly = true;
            this.kissTextEdit4.Size = new System.Drawing.Size(88, 24);
            this.kissTextEdit4.TabIndex = 1;
            // 
            // kissTextEdit1
            // 
            this.kissTextEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissTextEdit1.DataMember = "VIS_FallNr";
            this.kissTextEdit1.DataSource = this.qryVISMandant;
            this.kissTextEdit1.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit1.Location = new System.Drawing.Point(78, 378);
            this.kissTextEdit1.Name = "kissTextEdit1";
            this.kissTextEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit1.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit1.Properties.Name = "kissTextEdit14.Properties";
            this.kissTextEdit1.Properties.ReadOnly = true;
            this.kissTextEdit1.Size = new System.Drawing.Size(84, 24);
            this.kissTextEdit1.TabIndex = 0;
            // 
            // tpgPersonErfassen
            // 
            this.tpgPersonErfassen.Controls.Add(this.lblMeldungBerechnungsperson);
            this.tpgPersonErfassen.Controls.Add(this.edtErfassenVersichertennummer);
            this.tpgPersonErfassen.Controls.Add(this.kissLabel44);
            this.tpgPersonErfassen.Controls.Add(this.edtPersonOhneLeistung);
            this.tpgPersonErfassen.Controls.Add(this.kissLabel36);
            this.tpgPersonErfassen.Controls.Add(this.kissLabel34);
            this.tpgPersonErfassen.Controls.Add(this.kissLabel33);
            this.tpgPersonErfassen.Controls.Add(this.edtErfassenNationalitaet);
            this.tpgPersonErfassen.Controls.Add(this.kissLabel32);
            this.tpgPersonErfassen.Controls.Add(this.edtErfassenGeschlecht);
            this.tpgPersonErfassen.Controls.Add(this.kissLabel31);
            this.tpgPersonErfassen.Controls.Add(this.edtErfassenGeburtsdatum);
            this.tpgPersonErfassen.Controls.Add(this.kissLabel30);
            this.tpgPersonErfassen.Controls.Add(this.edtErfassenAHVNummer);
            this.tpgPersonErfassen.Controls.Add(this.kissLabel29);
            this.tpgPersonErfassen.Controls.Add(this.edtErfassenVorname);
            this.tpgPersonErfassen.Controls.Add(this.kissLabel28);
            this.tpgPersonErfassen.Controls.Add(this.edtErfassenName);
            this.tpgPersonErfassen.Location = new System.Drawing.Point(6, 6);
            this.tpgPersonErfassen.Name = "tpgPersonErfassen";
            this.tpgPersonErfassen.Size = new System.Drawing.Size(952, 580);
            this.tpgPersonErfassen.TabIndex = 1;
            this.tpgPersonErfassen.Title = "Person neu erfassen";
            // 
            // lblMeldungBerechnungsperson
            // 
            this.lblMeldungBerechnungsperson.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblMeldungBerechnungsperson.ForeColor = System.Drawing.Color.Red;
            this.lblMeldungBerechnungsperson.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblMeldungBerechnungsperson.Location = new System.Drawing.Point(96, 323);
            this.lblMeldungBerechnungsperson.Name = "lblMeldungBerechnungsperson";
            this.lblMeldungBerechnungsperson.Size = new System.Drawing.Size(352, 59);
            this.lblMeldungBerechnungsperson.TabIndex = 20;
            this.lblMeldungBerechnungsperson.Text = "Die Maske ‚Person ohne PID neu erfassen‘ dient nicht zur Erfassung von Berechnung" +
    "spersonen. Bitte verwenden sie die regulär zur Verfügung gestellten Berechnungsp" +
    "ersonen.";
            this.lblMeldungBerechnungsperson.UseCompatibleTextRendering = true;
            // 
            // edtErfassenVersichertennummer
            // 
            this.edtErfassenVersichertennummer.DataMember = "Versichertennummer";
            this.edtErfassenVersichertennummer.DataSource = this.qryNeuePerson;
            this.edtErfassenVersichertennummer.Location = new System.Drawing.Point(96, 96);
            this.edtErfassenVersichertennummer.Name = "edtErfassenVersichertennummer";
            this.edtErfassenVersichertennummer.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtErfassenVersichertennummer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErfassenVersichertennummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErfassenVersichertennummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErfassenVersichertennummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtErfassenVersichertennummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErfassenVersichertennummer.Properties.Appearance.Options.UseFont = true;
            this.edtErfassenVersichertennummer.Properties.Appearance.Options.UseTextOptions = true;
            this.edtErfassenVersichertennummer.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.edtErfassenVersichertennummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtErfassenVersichertennummer.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErfassenVersichertennummer.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None);
            this.edtErfassenVersichertennummer.Properties.DisplayFormat.FormatString = "000\\.0000\\.0000\\.00";
            this.edtErfassenVersichertennummer.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtErfassenVersichertennummer.Properties.EditFormat.FormatString = "000\\.0000\\.0000\\.00";
            this.edtErfassenVersichertennummer.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtErfassenVersichertennummer.Properties.Mask.EditMask = "000\\.0000\\.0000\\.00";
            this.edtErfassenVersichertennummer.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.edtErfassenVersichertennummer.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.edtErfassenVersichertennummer.Properties.MaxLength = 13;
            this.edtErfassenVersichertennummer.Properties.Precision = 0;
            this.edtErfassenVersichertennummer.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.edtErfassenVersichertennummer.Size = new System.Drawing.Size(224, 24);
            this.edtErfassenVersichertennummer.TabIndex = 18;
            // 
            // qryNeuePerson
            // 
            this.qryNeuePerson.CanInsert = true;
            this.qryNeuePerson.HostControl = this;
            this.qryNeuePerson.TableName = "BaPerson";
            // 
            // kissLabel44
            // 
            this.kissLabel44.Location = new System.Drawing.Point(0, 96);
            this.kissLabel44.Name = "kissLabel44";
            this.kissLabel44.Size = new System.Drawing.Size(80, 24);
            this.kissLabel44.TabIndex = 17;
            this.kissLabel44.Text = "Versichertennr.";
            this.kissLabel44.UseCompatibleTextRendering = true;
            // 
            // edtPersonOhneLeistung
            // 
            this.edtPersonOhneLeistung.DataMember = "PersonOhneLeistung";
            this.edtPersonOhneLeistung.DataSource = this.qryNeuePerson;
            this.edtPersonOhneLeistung.Location = new System.Drawing.Point(93, 267);
            this.edtPersonOhneLeistung.Name = "edtPersonOhneLeistung";
            this.edtPersonOhneLeistung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPersonOhneLeistung.Properties.Appearance.Options.UseBackColor = true;
            this.edtPersonOhneLeistung.Properties.Caption = "Person ohne finanzielle Leistung";
            this.edtPersonOhneLeistung.Size = new System.Drawing.Size(192, 19);
            this.edtPersonOhneLeistung.TabIndex = 16;
            // 
            // kissLabel36
            // 
            this.kissLabel36.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissLabel36.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel36.Location = new System.Drawing.Point(354, 166);
            this.kissLabel36.Name = "kissLabel36";
            this.kissLabel36.Size = new System.Drawing.Size(184, 40);
            this.kissLabel36.TabIndex = 14;
            this.kissLabel36.Text = "Geburtsdatum und Geschlecht sind wichtig für die korrekte Darstellung im Sozialsy" +
    "stem.";
            this.kissLabel36.UseCompatibleTextRendering = true;
            // 
            // kissLabel34
            // 
            this.kissLabel34.Location = new System.Drawing.Point(0, 224);
            this.kissLabel34.Name = "kissLabel34";
            this.kissLabel34.Size = new System.Drawing.Size(72, 24);
            this.kissLabel34.TabIndex = 6;
            this.kissLabel34.Text = "Nationalität";
            this.kissLabel34.UseCompatibleTextRendering = true;
            // 
            // kissLabel33
            // 
            this.kissLabel33.Location = new System.Drawing.Point(0, 192);
            this.kissLabel33.Name = "kissLabel33";
            this.kissLabel33.Size = new System.Drawing.Size(72, 24);
            this.kissLabel33.TabIndex = 5;
            this.kissLabel33.Text = "Geschlecht";
            this.kissLabel33.UseCompatibleTextRendering = true;
            // 
            // edtErfassenNationalitaet
            // 
            this.edtErfassenNationalitaet.DataMember = "NationalitaetCode";
            this.edtErfassenNationalitaet.DataSource = this.qryNeuePerson;
            this.edtErfassenNationalitaet.Location = new System.Drawing.Point(96, 224);
            this.edtErfassenNationalitaet.LOVName = "BaLand";
            this.edtErfassenNationalitaet.Name = "edtErfassenNationalitaet";
            this.edtErfassenNationalitaet.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErfassenNationalitaet.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErfassenNationalitaet.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErfassenNationalitaet.Properties.Appearance.Options.UseBackColor = true;
            this.edtErfassenNationalitaet.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErfassenNationalitaet.Properties.Appearance.Options.UseFont = true;
            this.edtErfassenNationalitaet.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtErfassenNationalitaet.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtErfassenNationalitaet.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtErfassenNationalitaet.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtErfassenNationalitaet.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtErfassenNationalitaet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtErfassenNationalitaet.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErfassenNationalitaet.Properties.Name = "kissLookUpEdit7.Properties";
            this.edtErfassenNationalitaet.Properties.NullText = "";
            this.edtErfassenNationalitaet.Properties.ShowFooter = false;
            this.edtErfassenNationalitaet.Properties.ShowHeader = false;
            this.edtErfassenNationalitaet.Size = new System.Drawing.Size(224, 24);
            this.edtErfassenNationalitaet.TabIndex = 5;
            // 
            // kissLabel32
            // 
            this.kissLabel32.Location = new System.Drawing.Point(0, 160);
            this.kissLabel32.Name = "kissLabel32";
            this.kissLabel32.Size = new System.Drawing.Size(72, 24);
            this.kissLabel32.TabIndex = 4;
            this.kissLabel32.Text = "Geburt";
            this.kissLabel32.UseCompatibleTextRendering = true;
            // 
            // edtErfassenGeschlecht
            // 
            this.edtErfassenGeschlecht.DataMember = "GeschlechtCode";
            this.edtErfassenGeschlecht.DataSource = this.qryNeuePerson;
            this.edtErfassenGeschlecht.Location = new System.Drawing.Point(96, 192);
            this.edtErfassenGeschlecht.LOVName = "BaGeschlecht";
            this.edtErfassenGeschlecht.Name = "edtErfassenGeschlecht";
            this.edtErfassenGeschlecht.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErfassenGeschlecht.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErfassenGeschlecht.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErfassenGeschlecht.Properties.Appearance.Options.UseBackColor = true;
            this.edtErfassenGeschlecht.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErfassenGeschlecht.Properties.Appearance.Options.UseFont = true;
            this.edtErfassenGeschlecht.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtErfassenGeschlecht.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtErfassenGeschlecht.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtErfassenGeschlecht.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtErfassenGeschlecht.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtErfassenGeschlecht.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtErfassenGeschlecht.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErfassenGeschlecht.Properties.Name = "kissLookUpEdit6.Properties";
            this.edtErfassenGeschlecht.Properties.NullText = "";
            this.edtErfassenGeschlecht.Properties.ShowFooter = false;
            this.edtErfassenGeschlecht.Properties.ShowHeader = false;
            this.edtErfassenGeschlecht.Size = new System.Drawing.Size(224, 24);
            this.edtErfassenGeschlecht.TabIndex = 4;
            // 
            // kissLabel31
            // 
            this.kissLabel31.Location = new System.Drawing.Point(0, 128);
            this.kissLabel31.Name = "kissLabel31";
            this.kissLabel31.Size = new System.Drawing.Size(72, 24);
            this.kissLabel31.TabIndex = 3;
            this.kissLabel31.Text = "AHV-Nr";
            this.kissLabel31.UseCompatibleTextRendering = true;
            // 
            // edtErfassenGeburtsdatum
            // 
            this.edtErfassenGeburtsdatum.DataMember = "Geburtsdatum";
            this.edtErfassenGeburtsdatum.DataSource = this.qryNeuePerson;
            this.edtErfassenGeburtsdatum.EditValue = null;
            this.edtErfassenGeburtsdatum.Location = new System.Drawing.Point(96, 160);
            this.edtErfassenGeburtsdatum.Name = "edtErfassenGeburtsdatum";
            this.edtErfassenGeburtsdatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtErfassenGeburtsdatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErfassenGeburtsdatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErfassenGeburtsdatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErfassenGeburtsdatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtErfassenGeburtsdatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErfassenGeburtsdatum.Properties.Appearance.Options.UseFont = true;
            this.edtErfassenGeburtsdatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtErfassenGeburtsdatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtErfassenGeburtsdatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtErfassenGeburtsdatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErfassenGeburtsdatum.Properties.Name = "kissDateEdit4.Properties";
            this.edtErfassenGeburtsdatum.Properties.ShowToday = false;
            this.edtErfassenGeburtsdatum.Size = new System.Drawing.Size(224, 24);
            this.edtErfassenGeburtsdatum.TabIndex = 3;
            // 
            // kissLabel30
            // 
            this.kissLabel30.Location = new System.Drawing.Point(0, 64);
            this.kissLabel30.Name = "kissLabel30";
            this.kissLabel30.Size = new System.Drawing.Size(72, 24);
            this.kissLabel30.TabIndex = 2;
            this.kissLabel30.Text = "Vorname";
            this.kissLabel30.UseCompatibleTextRendering = true;
            // 
            // edtErfassenAHVNummer
            // 
            this.edtErfassenAHVNummer.DataMember = "AHVNummer";
            this.edtErfassenAHVNummer.DataSource = this.qryNeuePerson;
            this.edtErfassenAHVNummer.Location = new System.Drawing.Point(96, 128);
            this.edtErfassenAHVNummer.Name = "edtErfassenAHVNummer";
            this.edtErfassenAHVNummer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErfassenAHVNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErfassenAHVNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErfassenAHVNummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtErfassenAHVNummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErfassenAHVNummer.Properties.Appearance.Options.UseFont = true;
            this.edtErfassenAHVNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtErfassenAHVNummer.Properties.Name = "kissTextEdit17.Properties";
            this.edtErfassenAHVNummer.Size = new System.Drawing.Size(224, 24);
            this.edtErfassenAHVNummer.TabIndex = 2;
            // 
            // kissLabel29
            // 
            this.kissLabel29.Location = new System.Drawing.Point(0, 32);
            this.kissLabel29.Name = "kissLabel29";
            this.kissLabel29.Size = new System.Drawing.Size(72, 24);
            this.kissLabel29.TabIndex = 1;
            this.kissLabel29.Text = "Name";
            this.kissLabel29.UseCompatibleTextRendering = true;
            // 
            // edtErfassenVorname
            // 
            this.edtErfassenVorname.DataMember = "Vorname";
            this.edtErfassenVorname.DataSource = this.qryNeuePerson;
            this.edtErfassenVorname.Location = new System.Drawing.Point(96, 64);
            this.edtErfassenVorname.Name = "edtErfassenVorname";
            this.edtErfassenVorname.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErfassenVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErfassenVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErfassenVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtErfassenVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErfassenVorname.Properties.Appearance.Options.UseFont = true;
            this.edtErfassenVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtErfassenVorname.Properties.Name = "kissTextEdit16.Properties";
            this.edtErfassenVorname.Size = new System.Drawing.Size(224, 24);
            this.edtErfassenVorname.TabIndex = 1;
            // 
            // kissLabel28
            // 
            this.kissLabel28.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.kissLabel28.Location = new System.Drawing.Point(0, 0);
            this.kissLabel28.Name = "kissLabel28";
            this.kissLabel28.Size = new System.Drawing.Size(246, 24);
            this.kissLabel28.TabIndex = 0;
            this.kissLabel28.Text = "Person ohne PID neu erfassen";
            this.kissLabel28.UseCompatibleTextRendering = true;
            // 
            // edtErfassenName
            // 
            this.edtErfassenName.DataMember = "Name";
            this.edtErfassenName.DataSource = this.qryNeuePerson;
            this.edtErfassenName.Location = new System.Drawing.Point(96, 32);
            this.edtErfassenName.Name = "edtErfassenName";
            this.edtErfassenName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErfassenName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErfassenName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErfassenName.Properties.Appearance.Options.UseBackColor = true;
            this.edtErfassenName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErfassenName.Properties.Appearance.Options.UseFont = true;
            this.edtErfassenName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtErfassenName.Properties.Name = "kissTextEdit15.Properties";
            this.edtErfassenName.Size = new System.Drawing.Size(224, 24);
            this.edtErfassenName.TabIndex = 0;
            // 
            // tpgPersonSuchen
            // 
            this.tpgPersonSuchen.Controls.Add(this.lblPID);
            this.tpgPersonSuchen.Controls.Add(this.edtPID);
            this.tpgPersonSuchen.Controls.Add(this.kissLabel35);
            this.tpgPersonSuchen.Controls.Add(this.kissLabel26);
            this.tpgPersonSuchen.Controls.Add(this.ctlGotoFall);
            this.tpgPersonSuchen.Controls.Add(this.kissLabel38);
            this.tpgPersonSuchen.Controls.Add(this.kissLabel25);
            this.tpgPersonSuchen.Controls.Add(this.kissLabel24);
            this.tpgPersonSuchen.Controls.Add(this.kissLabel23);
            this.tpgPersonSuchen.Controls.Add(this.kissLabel22);
            this.tpgPersonSuchen.Controls.Add(this.kissLabel21);
            this.tpgPersonSuchen.Controls.Add(this.btnKIS);
            this.tpgPersonSuchen.Controls.Add(this.kissLabel20);
            this.tpgPersonSuchen.Controls.Add(this.edtSozialraum);
            this.tpgPersonSuchen.Controls.Add(this.kissLabel19);
            this.tpgPersonSuchen.Controls.Add(this.edtZIPNr);
            this.tpgPersonSuchen.Controls.Add(this.kissLabel18);
            this.tpgPersonSuchen.Controls.Add(this.edtWMALand);
            this.tpgPersonSuchen.Controls.Add(this.edtWMAOrt);
            this.tpgPersonSuchen.Controls.Add(this.edtWMAPostfach);
            this.tpgPersonSuchen.Controls.Add(this.edtWMAStrasseHausNr);
            this.tpgPersonSuchen.Controls.Add(this.edtWMAAdresszusatz);
            this.tpgPersonSuchen.Controls.Add(this.edtEinwohnerregisterAktiv);
            this.tpgPersonSuchen.Controls.Add(this.edtBaPersonID);
            this.tpgPersonSuchen.Controls.Add(this.kissLabel17);
            this.tpgPersonSuchen.Controls.Add(this.edtNationalitaet);
            this.tpgPersonSuchen.Controls.Add(this.kissLabel16);
            this.tpgPersonSuchen.Controls.Add(this.edtGeschlecht);
            this.tpgPersonSuchen.Controls.Add(this.kissLabel15);
            this.tpgPersonSuchen.Controls.Add(this.edtGeburtsdatum);
            this.tpgPersonSuchen.Controls.Add(this.kissLabel14);
            this.tpgPersonSuchen.Controls.Add(this.edtAHVNummer);
            this.tpgPersonSuchen.Controls.Add(this.kissLabel13);
            this.tpgPersonSuchen.Controls.Add(this.edtVersichertennummer);
            this.tpgPersonSuchen.Controls.Add(this.kissLabel12);
            this.tpgPersonSuchen.Controls.Add(this.edtVorname);
            this.tpgPersonSuchen.Controls.Add(this.kissLabel11);
            this.tpgPersonSuchen.Controls.Add(this.edtName);
            this.tpgPersonSuchen.Controls.Add(this.tabSearch);
            this.tpgPersonSuchen.Controls.Add(this.kissLabel1);
            this.tpgPersonSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgPersonSuchen.Name = "tpgPersonSuchen";
            this.tpgPersonSuchen.Size = new System.Drawing.Size(952, 580);
            this.tpgPersonSuchen.TabIndex = 0;
            this.tpgPersonSuchen.Title = "Person in Omega/KiSS suchen";
            // 
            // lblPID
            // 
            this.lblPID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPID.Location = new System.Drawing.Point(361, 495);
            this.lblPID.Name = "lblPID";
            this.lblPID.Size = new System.Drawing.Size(64, 24);
            this.lblPID.TabIndex = 33;
            this.lblPID.Text = "PID";
            this.lblPID.UseCompatibleTextRendering = true;
            // 
            // edtPID
            // 
            this.edtPID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtPID.DataMember = "EinwohnerregisterIDOhne0er";
            this.edtPID.DataSource = this.qryVwPerson;
            this.edtPID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPID.Location = new System.Drawing.Point(444, 495);
            this.edtPID.Name = "edtPID";
            this.edtPID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPID.Properties.Appearance.Options.UseBackColor = true;
            this.edtPID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPID.Properties.Appearance.Options.UseFont = true;
            this.edtPID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPID.Properties.Name = "kissTextEdit6.Properties";
            this.edtPID.Properties.ReadOnly = true;
            this.edtPID.Size = new System.Drawing.Size(264, 24);
            this.edtPID.TabIndex = 34;
            // 
            // qryVwPerson
            // 
            this.qryVwPerson.BatchUpdate = true;
            this.qryVwPerson.HostControl = this;
            this.qryVwPerson.SelectStatement = resources.GetString("qryVwPerson.SelectStatement");
            this.qryVwPerson.TableName = "vwPerson";
            this.qryVwPerson.PositionChanged += new System.EventHandler(this.qryVwPerson_PositionChanged);
            // 
            // kissLabel35
            // 
            this.kissLabel35.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel35.Location = new System.Drawing.Point(8, 426);
            this.kissLabel35.Name = "kissLabel35";
            this.kissLabel35.Size = new System.Drawing.Size(87, 24);
            this.kissLabel35.TabIndex = 9;
            this.kissLabel35.Text = "Versichertennr.";
            this.kissLabel35.UseCompatibleTextRendering = true;
            // 
            // kissLabel26
            // 
            this.kissLabel26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel26.Location = new System.Drawing.Point(210, 351);
            this.kissLabel26.Name = "kissLabel26";
            this.kissLabel26.Size = new System.Drawing.Size(37, 24);
            this.kissLabel26.TabIndex = 4;
            this.kissLabel26.Text = "Status";
            this.kissLabel26.UseCompatibleTextRendering = true;
            this.kissLabel26.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctlGotoFall.DisplayModules = null;
            this.ctlGotoFall.Location = new System.Drawing.Point(131, 324);
            this.ctlGotoFall.Name = "ctlGotoFall";
            this.ctlGotoFall.Size = new System.Drawing.Size(106, 27);
            this.ctlGotoFall.TabIndex = 2;
            // 
            // kissLabel38
            // 
            this.kissLabel38.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel38.Location = new System.Drawing.Point(361, 551);
            this.kissLabel38.Name = "kissLabel38";
            this.kissLabel38.Size = new System.Drawing.Size(64, 24);
            this.kissLabel38.TabIndex = 37;
            this.kissLabel38.Text = "Sozialraum";
            this.kissLabel38.UseCompatibleTextRendering = true;
            // 
            // kissLabel25
            // 
            this.kissLabel25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel25.Location = new System.Drawing.Point(361, 518);
            this.kissLabel25.Name = "kissLabel25";
            this.kissLabel25.Size = new System.Drawing.Size(64, 24);
            this.kissLabel25.TabIndex = 35;
            this.kissLabel25.Text = "PID";
            this.kissLabel25.UseCompatibleTextRendering = true;
            this.kissLabel25.Visible = false;
            // 
            // kissLabel24
            // 
            this.kissLabel24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel24.Location = new System.Drawing.Point(8, 549);
            this.kissLabel24.Name = "kissLabel24";
            this.kissLabel24.Size = new System.Drawing.Size(74, 24);
            this.kissLabel24.TabIndex = 19;
            this.kissLabel24.Text = "Personen-Nr.";
            this.kissLabel24.UseCompatibleTextRendering = true;
            // 
            // kissLabel23
            // 
            this.kissLabel23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel23.Location = new System.Drawing.Point(361, 472);
            this.kissLabel23.Name = "kissLabel23";
            this.kissLabel23.Size = new System.Drawing.Size(64, 24);
            this.kissLabel23.TabIndex = 31;
            this.kissLabel23.Text = "Land";
            this.kissLabel23.UseCompatibleTextRendering = true;
            // 
            // kissLabel22
            // 
            this.kissLabel22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel22.Location = new System.Drawing.Point(361, 449);
            this.kissLabel22.Name = "kissLabel22";
            this.kissLabel22.Size = new System.Drawing.Size(64, 24);
            this.kissLabel22.TabIndex = 29;
            this.kissLabel22.Text = "PLZ/Ort/Kt";
            this.kissLabel22.UseCompatibleTextRendering = true;
            // 
            // kissLabel21
            // 
            this.kissLabel21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel21.Location = new System.Drawing.Point(361, 426);
            this.kissLabel21.Name = "kissLabel21";
            this.kissLabel21.Size = new System.Drawing.Size(64, 24);
            this.kissLabel21.TabIndex = 27;
            this.kissLabel21.Text = "Postfach";
            this.kissLabel21.UseCompatibleTextRendering = true;
            // 
            // btnKIS
            // 
            this.btnKIS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKIS.BackColor = System.Drawing.Color.Bisque;
            this.btnKIS.ButtonStyle = KiSS4.Gui.ButtonStyleType.Custom;
            this.btnKIS.Context = "KIS Aufruf";
            this.btnKIS.Enabled = false;
            this.btnKIS.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnKIS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKIS.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Pixel);
            this.btnKIS.ForeColor = System.Drawing.Color.Blue;
            this.btnKIS.Location = new System.Drawing.Point(835, 351);
            this.btnKIS.Name = "btnKIS";
            this.btnKIS.Size = new System.Drawing.Size(90, 24);
            this.btnKIS.TabIndex = 39;
            this.btnKIS.Text = "KIS";
            this.btnKIS.URL = "http://www.kis.integ.sd.stzh.ch";
            this.btnKIS.UseCompatibleTextRendering = true;
            this.btnKIS.UseVisualStyleBackColor = false;
            // 
            // kissLabel20
            // 
            this.kissLabel20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel20.Location = new System.Drawing.Point(361, 403);
            this.kissLabel20.Name = "kissLabel20";
            this.kissLabel20.Size = new System.Drawing.Size(64, 24);
            this.kissLabel20.TabIndex = 25;
            this.kissLabel20.Text = "Strasse/Nr";
            this.kissLabel20.UseCompatibleTextRendering = true;
            // 
            // edtSozialraum
            // 
            this.edtSozialraum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSozialraum.DataMember = "OrgUnitID";
            this.edtSozialraum.DataSource = this.qryVwPerson;
            this.edtSozialraum.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtSozialraum.Location = new System.Drawing.Point(444, 549);
            this.edtSozialraum.LookupSQL = "/*\r\nSELECT OrgUnitID, ItemName\r\nFROM XOrgUnit\r\nWHERE ItemName LIKE {0} + \'%\'\r\n*/\r" +
    "\n----\r\nSELECT ItemName\r\nFROM XOrgUnit\r\nWHERE OrgUnitID = {0}";
            this.edtSozialraum.Name = "edtSozialraum";
            this.edtSozialraum.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSozialraum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSozialraum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSozialraum.Properties.Appearance.Options.UseBackColor = true;
            this.edtSozialraum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSozialraum.Properties.Appearance.Options.UseFont = true;
            this.edtSozialraum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtSozialraum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtSozialraum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSozialraum.Properties.ReadOnly = true;
            this.edtSozialraum.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSozialraum.Size = new System.Drawing.Size(264, 24);
            this.edtSozialraum.TabIndex = 38;
            // 
            // kissLabel19
            // 
            this.kissLabel19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel19.Location = new System.Drawing.Point(361, 380);
            this.kissLabel19.Name = "kissLabel19";
            this.kissLabel19.Size = new System.Drawing.Size(64, 24);
            this.kissLabel19.TabIndex = 23;
            this.kissLabel19.Text = "Zusatz";
            this.kissLabel19.UseCompatibleTextRendering = true;
            // 
            // edtZIPNr
            // 
            this.edtZIPNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtZIPNr.DataMember = "ZIPNr";
            this.edtZIPNr.DataSource = this.qryVwPerson;
            this.edtZIPNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtZIPNr.Location = new System.Drawing.Point(444, 518);
            this.edtZIPNr.Name = "edtZIPNr";
            this.edtZIPNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtZIPNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZIPNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZIPNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtZIPNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZIPNr.Properties.Appearance.Options.UseFont = true;
            this.edtZIPNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZIPNr.Properties.Name = "kissTextEdit12.Properties";
            this.edtZIPNr.Properties.ReadOnly = true;
            this.edtZIPNr.Size = new System.Drawing.Size(264, 24);
            this.edtZIPNr.TabIndex = 36;
            this.edtZIPNr.Visible = false;
            // 
            // kissLabel18
            // 
            this.kissLabel18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel18.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel18.Location = new System.Drawing.Point(444, 356);
            this.kissLabel18.Name = "kissLabel18";
            this.kissLabel18.Size = new System.Drawing.Size(152, 16);
            this.kissLabel18.TabIndex = 21;
            this.kissLabel18.Text = "zivilrechtliche Adresse";
            this.kissLabel18.UseCompatibleTextRendering = true;
            // 
            // edtWMALand
            // 
            this.edtWMALand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtWMALand.DataMember = "WohnsitzLandCode";
            this.edtWMALand.DataSource = this.qryVwPerson;
            this.edtWMALand.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtWMALand.Location = new System.Drawing.Point(444, 472);
            this.edtWMALand.LOVName = "BaLand";
            this.edtWMALand.Name = "edtWMALand";
            this.edtWMALand.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtWMALand.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWMALand.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWMALand.Properties.Appearance.Options.UseBackColor = true;
            this.edtWMALand.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWMALand.Properties.Appearance.Options.UseFont = true;
            this.edtWMALand.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtWMALand.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtWMALand.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtWMALand.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtWMALand.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtWMALand.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtWMALand.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtWMALand.Properties.Name = "kissLookUpEdit4.Properties";
            this.edtWMALand.Properties.NullText = "";
            this.edtWMALand.Properties.ReadOnly = true;
            this.edtWMALand.Properties.ShowFooter = false;
            this.edtWMALand.Properties.ShowHeader = false;
            this.edtWMALand.Size = new System.Drawing.Size(264, 24);
            this.edtWMALand.TabIndex = 32;
            // 
            // edtWMAOrt
            // 
            this.edtWMAOrt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtWMAOrt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtWMAOrt.DataMember = null;
            this.edtWMAOrt.DataMemberBaGemeindeID = null;
            this.edtWMAOrt.DataMemberKanton = "";
            this.edtWMAOrt.DataMemberLand = "";
            this.edtWMAOrt.DataMemberOrt = "WohnsitzOrt";
            this.edtWMAOrt.DataMemberPLZ = "WohnsitzPLZ";
            this.edtWMAOrt.DataSource = this.qryVwPerson;
            this.edtWMAOrt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtWMAOrt.Location = new System.Drawing.Point(444, 449);
            this.edtWMAOrt.Name = "edtWMAOrt";
            this.edtWMAOrt.ShowLand = false;
            this.edtWMAOrt.Size = new System.Drawing.Size(264, 24);
            this.edtWMAOrt.TabIndex = 30;
            // 
            // edtWMAPostfach
            // 
            this.edtWMAPostfach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtWMAPostfach.DataMember = "WohnsitzPostfach";
            this.edtWMAPostfach.DataSource = this.qryVwPerson;
            this.edtWMAPostfach.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtWMAPostfach.Location = new System.Drawing.Point(444, 426);
            this.edtWMAPostfach.Name = "edtWMAPostfach";
            this.edtWMAPostfach.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtWMAPostfach.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWMAPostfach.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWMAPostfach.Properties.Appearance.Options.UseBackColor = true;
            this.edtWMAPostfach.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWMAPostfach.Properties.Appearance.Options.UseFont = true;
            this.edtWMAPostfach.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtWMAPostfach.Properties.Name = "kissTextEdit11.Properties";
            this.edtWMAPostfach.Properties.ReadOnly = true;
            this.edtWMAPostfach.Size = new System.Drawing.Size(264, 24);
            this.edtWMAPostfach.TabIndex = 28;
            // 
            // edtWMAStrasseHausNr
            // 
            this.edtWMAStrasseHausNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtWMAStrasseHausNr.DataMember = "WohnsitzStrasseHausNr";
            this.edtWMAStrasseHausNr.DataSource = this.qryVwPerson;
            this.edtWMAStrasseHausNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtWMAStrasseHausNr.Location = new System.Drawing.Point(444, 403);
            this.edtWMAStrasseHausNr.Name = "edtWMAStrasseHausNr";
            this.edtWMAStrasseHausNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtWMAStrasseHausNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWMAStrasseHausNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWMAStrasseHausNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtWMAStrasseHausNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWMAStrasseHausNr.Properties.Appearance.Options.UseFont = true;
            this.edtWMAStrasseHausNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtWMAStrasseHausNr.Properties.Name = "kissTextEdit10.Properties";
            this.edtWMAStrasseHausNr.Properties.ReadOnly = true;
            this.edtWMAStrasseHausNr.Size = new System.Drawing.Size(264, 24);
            this.edtWMAStrasseHausNr.TabIndex = 26;
            // 
            // edtWMAAdresszusatz
            // 
            this.edtWMAAdresszusatz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtWMAAdresszusatz.DataMember = "WohnsitzAdressZusatz";
            this.edtWMAAdresszusatz.DataSource = this.qryVwPerson;
            this.edtWMAAdresszusatz.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtWMAAdresszusatz.Location = new System.Drawing.Point(444, 380);
            this.edtWMAAdresszusatz.Name = "edtWMAAdresszusatz";
            this.edtWMAAdresszusatz.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtWMAAdresszusatz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWMAAdresszusatz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWMAAdresszusatz.Properties.Appearance.Options.UseBackColor = true;
            this.edtWMAAdresszusatz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWMAAdresszusatz.Properties.Appearance.Options.UseFont = true;
            this.edtWMAAdresszusatz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtWMAAdresszusatz.Properties.Name = "kissTextEdit9.Properties";
            this.edtWMAAdresszusatz.Properties.ReadOnly = true;
            this.edtWMAAdresszusatz.Size = new System.Drawing.Size(264, 24);
            this.edtWMAAdresszusatz.TabIndex = 24;
            // 
            // edtEinwohnerregisterAktiv
            // 
            this.edtEinwohnerregisterAktiv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtEinwohnerregisterAktiv.DataMember = "EinwohnerregisterAktiv";
            this.edtEinwohnerregisterAktiv.DataSource = this.qryVwPerson;
            this.edtEinwohnerregisterAktiv.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtEinwohnerregisterAktiv.Location = new System.Drawing.Point(633, 355);
            this.edtEinwohnerregisterAktiv.Name = "edtEinwohnerregisterAktiv";
            this.edtEinwohnerregisterAktiv.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtEinwohnerregisterAktiv.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinwohnerregisterAktiv.Properties.Caption = "Einwohnerregister aktiv";
            this.edtEinwohnerregisterAktiv.Properties.Name = "kissCheckEdit5.Properties";
            this.edtEinwohnerregisterAktiv.Properties.ReadOnly = true;
            this.edtEinwohnerregisterAktiv.Size = new System.Drawing.Size(165, 19);
            this.edtEinwohnerregisterAktiv.TabIndex = 22;
            // 
            // edtBaPersonID
            // 
            this.edtBaPersonID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBaPersonID.DataMember = "BaPersonID";
            this.edtBaPersonID.DataSource = this.qryVwPerson;
            this.edtBaPersonID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBaPersonID.Location = new System.Drawing.Point(101, 549);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBaPersonID.Properties.Name = "kissTextEdit14.Properties";
            this.edtBaPersonID.Properties.ReadOnly = true;
            this.edtBaPersonID.Size = new System.Drawing.Size(224, 24);
            this.edtBaPersonID.TabIndex = 20;
            // 
            // kissLabel17
            // 
            this.kissLabel17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel17.Location = new System.Drawing.Point(8, 518);
            this.kissLabel17.Name = "kissLabel17";
            this.kissLabel17.Size = new System.Drawing.Size(64, 24);
            this.kissLabel17.TabIndex = 17;
            this.kissLabel17.Text = "Nationalität";
            this.kissLabel17.UseCompatibleTextRendering = true;
            // 
            // edtNationalitaet
            // 
            this.edtNationalitaet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtNationalitaet.DataMember = "NationalitaetCode";
            this.edtNationalitaet.DataSource = this.qryVwPerson;
            this.edtNationalitaet.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtNationalitaet.Location = new System.Drawing.Point(101, 518);
            this.edtNationalitaet.LOVName = "BaLand";
            this.edtNationalitaet.Name = "edtNationalitaet";
            this.edtNationalitaet.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtNationalitaet.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNationalitaet.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNationalitaet.Properties.Appearance.Options.UseBackColor = true;
            this.edtNationalitaet.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNationalitaet.Properties.Appearance.Options.UseFont = true;
            this.edtNationalitaet.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtNationalitaet.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtNationalitaet.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtNationalitaet.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtNationalitaet.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtNationalitaet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtNationalitaet.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNationalitaet.Properties.Name = "kissLookUpEdit3.Properties";
            this.edtNationalitaet.Properties.NullText = "";
            this.edtNationalitaet.Properties.ReadOnly = true;
            this.edtNationalitaet.Properties.ShowFooter = false;
            this.edtNationalitaet.Properties.ShowHeader = false;
            this.edtNationalitaet.Size = new System.Drawing.Size(224, 24);
            this.edtNationalitaet.TabIndex = 18;
            // 
            // kissLabel16
            // 
            this.kissLabel16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel16.Location = new System.Drawing.Point(8, 495);
            this.kissLabel16.Name = "kissLabel16";
            this.kissLabel16.Size = new System.Drawing.Size(64, 24);
            this.kissLabel16.TabIndex = 15;
            this.kissLabel16.Text = "Geschlecht";
            this.kissLabel16.UseCompatibleTextRendering = true;
            // 
            // edtGeschlecht
            // 
            this.edtGeschlecht.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtGeschlecht.DataMember = "GeschlechtCode";
            this.edtGeschlecht.DataSource = this.qryVwPerson;
            this.edtGeschlecht.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGeschlecht.Location = new System.Drawing.Point(101, 495);
            this.edtGeschlecht.LOVName = "BaGeschlecht";
            this.edtGeschlecht.Name = "edtGeschlecht";
            this.edtGeschlecht.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGeschlecht.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeschlecht.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeschlecht.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeschlecht.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeschlecht.Properties.Appearance.Options.UseFont = true;
            this.edtGeschlecht.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtGeschlecht.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeschlecht.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtGeschlecht.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtGeschlecht.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtGeschlecht.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtGeschlecht.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeschlecht.Properties.Name = "kissLookUpEdit2.Properties";
            this.edtGeschlecht.Properties.NullText = "";
            this.edtGeschlecht.Properties.ReadOnly = true;
            this.edtGeschlecht.Properties.ShowFooter = false;
            this.edtGeschlecht.Properties.ShowHeader = false;
            this.edtGeschlecht.Size = new System.Drawing.Size(224, 24);
            this.edtGeschlecht.TabIndex = 16;
            // 
            // kissLabel15
            // 
            this.kissLabel15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel15.Location = new System.Drawing.Point(8, 472);
            this.kissLabel15.Name = "kissLabel15";
            this.kissLabel15.Size = new System.Drawing.Size(64, 24);
            this.kissLabel15.TabIndex = 13;
            this.kissLabel15.Text = "Geburt";
            this.kissLabel15.UseCompatibleTextRendering = true;
            // 
            // edtGeburtsdatum
            // 
            this.edtGeburtsdatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtGeburtsdatum.DataMember = "Geburtsdatum";
            this.edtGeburtsdatum.DataSource = this.qryVwPerson;
            this.edtGeburtsdatum.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGeburtsdatum.EditValue = null;
            this.edtGeburtsdatum.Location = new System.Drawing.Point(101, 472);
            this.edtGeburtsdatum.Name = "edtGeburtsdatum";
            this.edtGeburtsdatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGeburtsdatum.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGeburtsdatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeburtsdatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeburtsdatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeburtsdatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeburtsdatum.Properties.Appearance.Options.UseFont = true;
            this.edtGeburtsdatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtGeburtsdatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGeburtsdatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtGeburtsdatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeburtsdatum.Properties.Name = "kissDateEdit3.Properties";
            this.edtGeburtsdatum.Properties.ReadOnly = true;
            this.edtGeburtsdatum.Properties.ShowToday = false;
            this.edtGeburtsdatum.Size = new System.Drawing.Size(224, 24);
            this.edtGeburtsdatum.TabIndex = 14;
            // 
            // kissLabel14
            // 
            this.kissLabel14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel14.Location = new System.Drawing.Point(8, 449);
            this.kissLabel14.Name = "kissLabel14";
            this.kissLabel14.Size = new System.Drawing.Size(64, 24);
            this.kissLabel14.TabIndex = 11;
            this.kissLabel14.Text = "AHV-Nr";
            this.kissLabel14.UseCompatibleTextRendering = true;
            // 
            // edtAHVNummer
            // 
            this.edtAHVNummer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAHVNummer.DataMember = "AHVNummer";
            this.edtAHVNummer.DataSource = this.qryVwPerson;
            this.edtAHVNummer.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAHVNummer.Location = new System.Drawing.Point(101, 449);
            this.edtAHVNummer.Name = "edtAHVNummer";
            this.edtAHVNummer.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAHVNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAHVNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAHVNummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtAHVNummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAHVNummer.Properties.Appearance.Options.UseFont = true;
            this.edtAHVNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAHVNummer.Properties.Name = "kissTextEdit8.Properties";
            this.edtAHVNummer.Properties.ReadOnly = true;
            this.edtAHVNummer.Size = new System.Drawing.Size(224, 24);
            this.edtAHVNummer.TabIndex = 12;
            // 
            // kissLabel13
            // 
            this.kissLabel13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel13.Location = new System.Drawing.Point(8, 403);
            this.kissLabel13.Name = "kissLabel13";
            this.kissLabel13.Size = new System.Drawing.Size(64, 24);
            this.kissLabel13.TabIndex = 7;
            this.kissLabel13.Text = "Vorname";
            this.kissLabel13.UseCompatibleTextRendering = true;
            // 
            // edtVersichertennummer
            // 
            this.edtVersichertennummer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtVersichertennummer.DataMember = "Versichertennummer";
            this.edtVersichertennummer.DataSource = this.qryVwPerson;
            this.edtVersichertennummer.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVersichertennummer.Location = new System.Drawing.Point(101, 426);
            this.edtVersichertennummer.Name = "edtVersichertennummer";
            this.edtVersichertennummer.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVersichertennummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVersichertennummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVersichertennummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtVersichertennummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVersichertennummer.Properties.Appearance.Options.UseFont = true;
            this.edtVersichertennummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVersichertennummer.Properties.ReadOnly = true;
            this.edtVersichertennummer.Size = new System.Drawing.Size(224, 24);
            this.edtVersichertennummer.TabIndex = 10;
            // 
            // kissLabel12
            // 
            this.kissLabel12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel12.Location = new System.Drawing.Point(8, 380);
            this.kissLabel12.Name = "kissLabel12";
            this.kissLabel12.Size = new System.Drawing.Size(64, 24);
            this.kissLabel12.TabIndex = 5;
            this.kissLabel12.Text = "Name";
            this.kissLabel12.UseCompatibleTextRendering = true;
            // 
            // edtVorname
            // 
            this.edtVorname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtVorname.DataMember = "Vorname";
            this.edtVorname.DataSource = this.qryVwPerson;
            this.edtVorname.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVorname.Location = new System.Drawing.Point(101, 403);
            this.edtVorname.Name = "edtVorname";
            this.edtVorname.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVorname.Properties.Appearance.Options.UseFont = true;
            this.edtVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVorname.Properties.Name = "kissTextEdit7.Properties";
            this.edtVorname.Properties.ReadOnly = true;
            this.edtVorname.Size = new System.Drawing.Size(224, 24);
            this.edtVorname.TabIndex = 8;
            // 
            // kissLabel11
            // 
            this.kissLabel11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel11.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel11.Location = new System.Drawing.Point(101, 356);
            this.kissLabel11.Name = "kissLabel11";
            this.kissLabel11.Size = new System.Drawing.Size(64, 16);
            this.kissLabel11.TabIndex = 3;
            this.kissLabel11.Text = "Person";
            this.kissLabel11.UseCompatibleTextRendering = true;
            // 
            // edtName
            // 
            this.edtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtName.DataMember = "Name";
            this.edtName.DataSource = this.qryVwPerson;
            this.edtName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtName.Location = new System.Drawing.Point(101, 380);
            this.edtName.Name = "edtName";
            this.edtName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtName.Properties.Appearance.Options.UseBackColor = true;
            this.edtName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtName.Properties.Appearance.Options.UseFont = true;
            this.edtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtName.Properties.Name = "kissTextEdit6.Properties";
            this.edtName.Properties.ReadOnly = true;
            this.edtName.Size = new System.Drawing.Size(224, 24);
            this.edtName.TabIndex = 6;
            // 
            // tabSearch
            // 
            this.tabSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSearch.Controls.Add(this.tpgSuchen);
            this.tabSearch.Controls.Add(this.tpgListe);
            this.tabSearch.Location = new System.Drawing.Point(3, 27);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.SelectedTabIndex = 1;
            this.tabSearch.ShowFixedWidthTooltip = true;
            this.tabSearch.Size = new System.Drawing.Size(946, 321);
            this.tabSearch.TabIndex = 1;
            this.tabSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgListe,
            this.tpgSuchen});
            this.tabSearch.TabsLineColor = System.Drawing.Color.Black;
            this.tabSearch.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabSearch.Text = "kissTabControlEx3";
            this.tabSearch.SelectedTabChanging += new System.ComponentModel.CancelEventHandler(this.tabSearch_SelectedTabChanging);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtSucheGeschlecht);
            this.tpgSuchen.Controls.Add(this.kissLabel45);
            this.tpgSuchen.Controls.Add(this.edtSuchePID);
            this.tpgSuchen.Controls.Add(this.lblSuchePID);
            this.tpgSuchen.Controls.Add(this.edtSucheAHV13);
            this.tpgSuchen.Controls.Add(this.edtSucheZemis);
            this.tpgSuchen.Controls.Add(this.kissLabel27);
            this.tpgSuchen.Controls.Add(this.kissLabel10);
            this.tpgSuchen.Controls.Add(this.edtSucheAuchAehnliche);
            this.tpgSuchen.Controls.Add(this.edtSucheNurAktive);
            this.tpgSuchen.Controls.Add(this.kissLabel9);
            this.tpgSuchen.Controls.Add(this.kissLabel41);
            this.tpgSuchen.Controls.Add(this.edtSucheAHV11);
            this.tpgSuchen.Controls.Add(this.kissLabel7);
            this.tpgSuchen.Controls.Add(this.edtSucheGebDatBis);
            this.tpgSuchen.Controls.Add(this.edtSucheGebDatVon);
            this.tpgSuchen.Controls.Add(this.edtSucheStrasse);
            this.tpgSuchen.Controls.Add(this.edtSearchInKiSS);
            this.tpgSuchen.Controls.Add(this.edtSearchInOmega);
            this.tpgSuchen.Controls.Add(this.kissLabel5);
            this.tpgSuchen.Controls.Add(this.edtSucheHausNr);
            this.tpgSuchen.Controls.Add(this.kissLabel4);
            this.tpgSuchen.Controls.Add(this.kissLabel3);
            this.tpgSuchen.Controls.Add(this.edtSucheVorname);
            this.tpgSuchen.Controls.Add(this.searchTitle);
            this.tpgSuchen.Controls.Add(this.kissLabel2);
            this.tpgSuchen.Controls.Add(this.edtSucheNachname);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Name = "tpgSuchen";
            this.tpgSuchen.Size = new System.Drawing.Size(934, 283);
            this.tpgSuchen.TabIndex = 0;
            this.tpgSuchen.Title = "Suchen";
            // 
            // edtSucheGeschlecht
            // 
            this.edtSucheGeschlecht.Location = new System.Drawing.Point(87, 162);
            this.edtSucheGeschlecht.LOVName = "BaGeschlecht";
            this.edtSucheGeschlecht.Name = "edtSucheGeschlecht";
            this.edtSucheGeschlecht.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheGeschlecht.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheGeschlecht.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheGeschlecht.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheGeschlecht.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheGeschlecht.Properties.Appearance.Options.UseFont = true;
            this.edtSucheGeschlecht.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheGeschlecht.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheGeschlecht.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheGeschlecht.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheGeschlecht.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtSucheGeschlecht.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtSucheGeschlecht.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheGeschlecht.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", null, 75)});
            this.edtSucheGeschlecht.Properties.Name = "editNationalitaetX.Properties";
            this.edtSucheGeschlecht.Properties.NullText = "";
            this.edtSucheGeschlecht.Properties.ShowFooter = false;
            this.edtSucheGeschlecht.Properties.ShowHeader = false;
            this.edtSucheGeschlecht.Size = new System.Drawing.Size(232, 24);
            this.edtSucheGeschlecht.TabIndex = 34;
            // 
            // kissLabel45
            // 
            this.kissLabel45.Location = new System.Drawing.Point(8, 164);
            this.kissLabel45.Name = "kissLabel45";
            this.kissLabel45.Size = new System.Drawing.Size(72, 24);
            this.kissLabel45.TabIndex = 33;
            this.kissLabel45.Text = "Geschlecht";
            this.kissLabel45.UseCompatibleTextRendering = true;
            // 
            // edtSuchePID
            // 
            this.edtSuchePID.Location = new System.Drawing.Point(87, 42);
            this.edtSuchePID.Name = "edtSuchePID";
            this.edtSuchePID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSuchePID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSuchePID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSuchePID.Properties.Appearance.Options.UseBackColor = true;
            this.edtSuchePID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSuchePID.Properties.Appearance.Options.UseFont = true;
            this.edtSuchePID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSuchePID.Properties.MaxLength = 10;
            this.edtSuchePID.Properties.Name = "kissTextEdit1.Properties";
            this.edtSuchePID.Size = new System.Drawing.Size(232, 24);
            this.edtSuchePID.TabIndex = 3;
            // 
            // lblSuchePID
            // 
            this.lblSuchePID.Location = new System.Drawing.Point(8, 42);
            this.lblSuchePID.Name = "lblSuchePID";
            this.lblSuchePID.Size = new System.Drawing.Size(72, 24);
            this.lblSuchePID.TabIndex = 2;
            this.lblSuchePID.Text = "PID";
            this.lblSuchePID.UseCompatibleTextRendering = true;
            // 
            // edtSucheAHV13
            // 
            this.edtSucheAHV13.Location = new System.Drawing.Point(441, 72);
            this.edtSucheAHV13.Name = "edtSucheAHV13";
            this.edtSucheAHV13.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheAHV13.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheAHV13.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheAHV13.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheAHV13.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheAHV13.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheAHV13.Properties.Appearance.Options.UseFont = true;
            this.edtSucheAHV13.Properties.Appearance.Options.UseTextOptions = true;
            this.edtSucheAHV13.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.edtSucheAHV13.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheAHV13.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheAHV13.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None);
            this.edtSucheAHV13.Properties.DisplayFormat.FormatString = "000\\.0000\\.0000\\.00";
            this.edtSucheAHV13.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSucheAHV13.Properties.EditFormat.FormatString = "000\\.0000\\.0000\\.00";
            this.edtSucheAHV13.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSucheAHV13.Properties.Mask.EditMask = "000\\.0000\\.0000\\.00";
            this.edtSucheAHV13.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.edtSucheAHV13.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.edtSucheAHV13.Properties.MaxLength = 13;
            this.edtSucheAHV13.Properties.Precision = 0;
            this.edtSucheAHV13.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.edtSucheAHV13.Size = new System.Drawing.Size(224, 24);
            this.edtSucheAHV13.TabIndex = 23;
            // 
            // edtSucheZemis
            // 
            this.edtSucheZemis.Location = new System.Drawing.Point(441, 132);
            this.edtSucheZemis.Name = "edtSucheZemis";
            this.edtSucheZemis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheZemis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheZemis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheZemis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheZemis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheZemis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheZemis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheZemis.Size = new System.Drawing.Size(224, 24);
            this.edtSucheZemis.TabIndex = 27;
            // 
            // kissLabel27
            // 
            this.kissLabel27.Location = new System.Drawing.Point(347, 72);
            this.kissLabel27.Name = "kissLabel27";
            this.kissLabel27.Size = new System.Drawing.Size(87, 24);
            this.kissLabel27.TabIndex = 22;
            this.kissLabel27.Text = "AHV13";
            this.kissLabel27.UseCompatibleTextRendering = true;
            // 
            // kissLabel10
            // 
            this.kissLabel10.Location = new System.Drawing.Point(549, 42);
            this.kissLabel10.Name = "kissLabel10";
            this.kissLabel10.Size = new System.Drawing.Size(8, 24);
            this.kissLabel10.TabIndex = 18;
            this.kissLabel10.Text = "-";
            this.kissLabel10.UseCompatibleTextRendering = true;
            // 
            // edtSucheAuchAehnliche
            // 
            this.edtSucheAuchAehnliche.EditValue = true;
            this.edtSucheAuchAehnliche.Location = new System.Drawing.Point(441, 190);
            this.edtSucheAuchAehnliche.Name = "edtSucheAuchAehnliche";
            this.edtSucheAuchAehnliche.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSucheAuchAehnliche.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheAuchAehnliche.Properties.Caption = "auch ähnliche Personen anzeigen";
            this.edtSucheAuchAehnliche.Properties.Name = "kissCheckEdit4.Properties";
            this.edtSucheAuchAehnliche.Size = new System.Drawing.Size(246, 19);
            this.edtSucheAuchAehnliche.TabIndex = 29;
            // 
            // edtSucheNurAktive
            // 
            this.edtSucheNurAktive.EditValue = "False";
            this.edtSucheNurAktive.Location = new System.Drawing.Point(441, 166);
            this.edtSucheNurAktive.Name = "edtSucheNurAktive";
            this.edtSucheNurAktive.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSucheNurAktive.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheNurAktive.Properties.Caption = "nur aktive Klient/innen";
            this.edtSucheNurAktive.Properties.Name = "kissCheckEdit3.Properties";
            this.edtSucheNurAktive.Size = new System.Drawing.Size(128, 19);
            this.edtSucheNurAktive.TabIndex = 28;
            // 
            // kissLabel9
            // 
            this.kissLabel9.Location = new System.Drawing.Point(347, 102);
            this.kissLabel9.Name = "kissLabel9";
            this.kissLabel9.Size = new System.Drawing.Size(88, 24);
            this.kissLabel9.TabIndex = 24;
            this.kissLabel9.Text = "AHV11";
            this.kissLabel9.UseCompatibleTextRendering = true;
            // 
            // kissLabel41
            // 
            this.kissLabel41.Location = new System.Drawing.Point(347, 134);
            this.kissLabel41.Name = "kissLabel41";
            this.kissLabel41.Size = new System.Drawing.Size(87, 24);
            this.kissLabel41.TabIndex = 26;
            this.kissLabel41.Text = "ZEMIS";
            this.kissLabel41.UseCompatibleTextRendering = true;
            // 
            // edtSucheAHV11
            // 
            this.edtSucheAHV11.Location = new System.Drawing.Point(441, 102);
            this.edtSucheAHV11.Name = "edtSucheAHV11";
            this.edtSucheAHV11.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheAHV11.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheAHV11.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheAHV11.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheAHV11.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheAHV11.Properties.Appearance.Options.UseFont = true;
            this.edtSucheAHV11.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheAHV11.Properties.Name = "kissTextEdit5.Properties";
            this.edtSucheAHV11.Size = new System.Drawing.Size(224, 24);
            this.edtSucheAHV11.TabIndex = 25;
            // 
            // kissLabel7
            // 
            this.kissLabel7.Location = new System.Drawing.Point(347, 42);
            this.kissLabel7.Name = "kissLabel7";
            this.kissLabel7.Size = new System.Drawing.Size(87, 24);
            this.kissLabel7.TabIndex = 16;
            this.kissLabel7.Text = "Geburt";
            this.kissLabel7.UseCompatibleTextRendering = true;
            // 
            // edtSucheGebDatBis
            // 
            this.edtSucheGebDatBis.EditValue = null;
            this.edtSucheGebDatBis.Location = new System.Drawing.Point(565, 42);
            this.edtSucheGebDatBis.Name = "edtSucheGebDatBis";
            this.edtSucheGebDatBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheGebDatBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheGebDatBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheGebDatBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheGebDatBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheGebDatBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheGebDatBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheGebDatBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtSucheGebDatBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheGebDatBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.edtSucheGebDatBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheGebDatBis.Properties.Name = "kissDateEdit2.Properties";
            this.edtSucheGebDatBis.Properties.ShowToday = false;
            this.edtSucheGebDatBis.Size = new System.Drawing.Size(100, 24);
            this.edtSucheGebDatBis.TabIndex = 19;
            // 
            // edtSucheGebDatVon
            // 
            this.edtSucheGebDatVon.EditValue = null;
            this.edtSucheGebDatVon.Location = new System.Drawing.Point(441, 42);
            this.edtSucheGebDatVon.Name = "edtSucheGebDatVon";
            this.edtSucheGebDatVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheGebDatVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheGebDatVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheGebDatVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheGebDatVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheGebDatVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheGebDatVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheGebDatVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.edtSucheGebDatVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheGebDatVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.edtSucheGebDatVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheGebDatVon.Properties.Name = "kissDateEdit1.Properties";
            this.edtSucheGebDatVon.Properties.ShowToday = false;
            this.edtSucheGebDatVon.Size = new System.Drawing.Size(100, 24);
            this.edtSucheGebDatVon.TabIndex = 17;
            // 
            // edtSucheStrasse
            // 
            this.edtSucheStrasse.Location = new System.Drawing.Point(87, 132);
            this.edtSucheStrasse.Name = "edtSucheStrasse";
            this.edtSucheStrasse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtSucheStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheStrasse.Properties.Name = "kissTextEdit3.Properties";
            this.edtSucheStrasse.Size = new System.Drawing.Size(178, 24);
            this.edtSucheStrasse.TabIndex = 15;
            // 
            // edtSearchInKiSS
            // 
            this.edtSearchInKiSS.EditValue = "False";
            this.edtSearchInKiSS.Location = new System.Drawing.Point(183, 192);
            this.edtSearchInKiSS.Name = "edtSearchInKiSS";
            this.edtSearchInKiSS.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSearchInKiSS.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchInKiSS.Properties.Caption = "KiSS";
            this.edtSearchInKiSS.Properties.Name = "kissCheckEdit2.Properties";
            this.edtSearchInKiSS.Size = new System.Drawing.Size(56, 19);
            this.edtSearchInKiSS.TabIndex = 14;
            // 
            // edtSearchInOmega
            // 
            this.edtSearchInOmega.EditValue = "False";
            this.edtSearchInOmega.Location = new System.Drawing.Point(87, 192);
            this.edtSearchInOmega.Name = "edtSearchInOmega";
            this.edtSearchInOmega.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSearchInOmega.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchInOmega.Properties.Caption = "Omega";
            this.edtSearchInOmega.Properties.Name = "kissCheckEdit1.Properties";
            this.edtSearchInOmega.Size = new System.Drawing.Size(56, 19);
            this.edtSearchInOmega.TabIndex = 13;
            // 
            // kissLabel5
            // 
            this.kissLabel5.Location = new System.Drawing.Point(8, 132);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(72, 24);
            this.kissLabel5.TabIndex = 8;
            this.kissLabel5.Text = "Strasse/Nr";
            this.kissLabel5.UseCompatibleTextRendering = true;
            // 
            // edtSucheHausNr
            // 
            this.edtSucheHausNr.Location = new System.Drawing.Point(271, 132);
            this.edtSucheHausNr.Name = "edtSucheHausNr";
            this.edtSucheHausNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheHausNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheHausNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheHausNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheHausNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheHausNr.Properties.Appearance.Options.UseFont = true;
            this.edtSucheHausNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheHausNr.Properties.Name = "kissTextEdit4.Properties";
            this.edtSucheHausNr.Size = new System.Drawing.Size(48, 24);
            this.edtSucheHausNr.TabIndex = 10;
            // 
            // kissLabel4
            // 
            this.kissLabel4.Location = new System.Drawing.Point(8, 102);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(72, 24);
            this.kissLabel4.TabIndex = 6;
            this.kissLabel4.Text = "Vorname";
            this.kissLabel4.UseCompatibleTextRendering = true;
            // 
            // kissLabel3
            // 
            this.kissLabel3.Location = new System.Drawing.Point(8, 72);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(72, 24);
            this.kissLabel3.TabIndex = 4;
            this.kissLabel3.Text = "Name";
            this.kissLabel3.UseCompatibleTextRendering = true;
            // 
            // edtSucheVorname
            // 
            this.edtSucheVorname.Location = new System.Drawing.Point(87, 102);
            this.edtSucheVorname.Name = "edtSucheVorname";
            this.edtSucheVorname.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheVorname.Properties.Appearance.Options.UseFont = true;
            this.edtSucheVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheVorname.Size = new System.Drawing.Size(232, 24);
            this.edtSucheVorname.TabIndex = 7;
            // 
            // searchTitle
            // 
            this.searchTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.searchTitle.Location = new System.Drawing.Point(8, 8);
            this.searchTitle.Name = "searchTitle";
            this.searchTitle.Size = new System.Drawing.Size(846, 24);
            this.searchTitle.TabIndex = 0;
            // 
            // kissLabel2
            // 
            this.kissLabel2.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel2.Location = new System.Drawing.Point(24, 8);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(100, 16);
            this.kissLabel2.TabIndex = 1;
            this.kissLabel2.Text = "Suchen";
            this.kissLabel2.UseCompatibleTextRendering = true;
            // 
            // edtSucheNachname
            // 
            this.edtSucheNachname.Location = new System.Drawing.Point(87, 72);
            this.edtSucheNachname.Name = "edtSucheNachname";
            this.edtSucheNachname.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheNachname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheNachname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheNachname.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheNachname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheNachname.Properties.Appearance.Options.UseFont = true;
            this.edtSucheNachname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheNachname.Properties.Name = "kissTextEdit1.Properties";
            this.edtSucheNachname.Size = new System.Drawing.Size(232, 24);
            this.edtSucheNachname.TabIndex = 5;
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdVwPerson);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Name = "tpgListe";
            this.tpgListe.Size = new System.Drawing.Size(934, 283);
            this.tpgListe.TabIndex = 0;
            this.tpgListe.Title = "Liste";
            // 
            // grdVwPerson
            // 
            this.grdVwPerson.DataSource = this.qryVwPerson;
            this.grdVwPerson.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdVwPerson.EmbeddedNavigator.Name = "kissGrid1.EmbeddedNavigator";
            this.grdVwPerson.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdVwPerson.Location = new System.Drawing.Point(0, 0);
            this.grdVwPerson.MainView = this.grvVwPerson;
            this.grdVwPerson.Name = "grdVwPerson";
            this.grdVwPerson.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemGridLookUpEdit1,
            this.repositoryItemCheckEdit2,
            this.repositoryItemCheckEdit3});
            this.grdVwPerson.ShowDefaultPopup = false;
            this.grdVwPerson.Size = new System.Drawing.Size(934, 283);
            this.grdVwPerson.TabIndex = 0;
            this.grdVwPerson.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVwPerson});
            // 
            // grvVwPerson
            // 
            this.grvVwPerson.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvVwPerson.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVwPerson.Appearance.Empty.Options.UseBackColor = true;
            this.grvVwPerson.Appearance.Empty.Options.UseFont = true;
            this.grvVwPerson.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVwPerson.Appearance.EvenRow.Options.UseFont = true;
            this.grvVwPerson.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVwPerson.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVwPerson.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvVwPerson.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvVwPerson.Appearance.FocusedCell.Options.UseFont = true;
            this.grvVwPerson.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvVwPerson.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVwPerson.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVwPerson.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvVwPerson.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvVwPerson.Appearance.FocusedRow.Options.UseFont = true;
            this.grvVwPerson.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvVwPerson.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVwPerson.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvVwPerson.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVwPerson.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVwPerson.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVwPerson.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvVwPerson.Appearance.GroupRow.Options.UseFont = true;
            this.grvVwPerson.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvVwPerson.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvVwPerson.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvVwPerson.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVwPerson.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvVwPerson.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvVwPerson.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvVwPerson.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvVwPerson.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVwPerson.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVwPerson.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvVwPerson.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvVwPerson.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvVwPerson.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvVwPerson.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvVwPerson.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVwPerson.Appearance.OddRow.Options.UseFont = true;
            this.grvVwPerson.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvVwPerson.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVwPerson.Appearance.Row.Options.UseBackColor = true;
            this.grvVwPerson.Appearance.Row.Options.UseFont = true;
            this.grvVwPerson.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVwPerson.Appearance.SelectedRow.Options.UseFont = true;
            this.grvVwPerson.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvVwPerson.Appearance.VertLine.Options.UseBackColor = true;
            this.grvVwPerson.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvVwPerson.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFalltraeger,
            this.colName,
            this.colVorname,
            this.colStrasse,
            this.colOrt,
            this.colGeschlecht,
            this.colGeburt,
            this.colVersichertenNr,
            this.colKiSS,
            this.colOmega,
            this.colEinwohnerregisterAktiv,
            this.colEinwohnerregisterID,
            this.colZIP,
            this.colAHVNr});
            this.grvVwPerson.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvVwPerson.GridControl = this.grdVwPerson;
            this.grvVwPerson.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvVwPerson.Name = "grvVwPerson";
            this.grvVwPerson.OptionsBehavior.Editable = false;
            this.grvVwPerson.OptionsCustomization.AllowFilter = false;
            this.grvVwPerson.OptionsFilter.AllowFilterEditor = false;
            this.grvVwPerson.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvVwPerson.OptionsMenu.EnableColumnMenu = false;
            this.grvVwPerson.OptionsNavigation.AutoFocusNewRow = true;
            this.grvVwPerson.OptionsNavigation.UseTabKey = false;
            this.grvVwPerson.OptionsView.ColumnAutoWidth = false;
            this.grvVwPerson.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvVwPerson.OptionsView.ShowGroupPanel = false;
            this.grvVwPerson.OptionsView.ShowIndicator = false;
            // 
            // colFalltraeger
            // 
            this.colFalltraeger.Caption = "FT";
            this.colFalltraeger.ColumnEdit = this.repositoryItemCheckEdit3;
            this.colFalltraeger.FieldName = "IsFT";
            this.colFalltraeger.Name = "colFalltraeger";
            this.colFalltraeger.Visible = true;
            this.colFalltraeger.VisibleIndex = 0;
            this.colFalltraeger.Width = 28;
            // 
            // repositoryItemCheckEdit3
            // 
            this.repositoryItemCheckEdit3.AutoHeight = false;
            this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
            this.repositoryItemCheckEdit3.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 150;
            // 
            // colVorname
            // 
            this.colVorname.Caption = "Vorname";
            this.colVorname.FieldName = "Vorname";
            this.colVorname.Name = "colVorname";
            this.colVorname.Visible = true;
            this.colVorname.VisibleIndex = 2;
            this.colVorname.Width = 116;
            // 
            // colStrasse
            // 
            this.colStrasse.Caption = "Strasse";
            this.colStrasse.FieldName = "WohnsitzStrasseHausNr";
            this.colStrasse.Name = "colStrasse";
            this.colStrasse.Visible = true;
            this.colStrasse.VisibleIndex = 3;
            this.colStrasse.Width = 118;
            // 
            // colOrt
            // 
            this.colOrt.Caption = "Ort";
            this.colOrt.FieldName = "WohnsitzPLZOrt";
            this.colOrt.Name = "colOrt";
            this.colOrt.Visible = true;
            this.colOrt.VisibleIndex = 4;
            this.colOrt.Width = 106;
            // 
            // colGeschlecht
            // 
            this.colGeschlecht.Caption = "m/w";
            this.colGeschlecht.FieldName = "GeschlechtCode";
            this.colGeschlecht.Name = "colGeschlecht";
            this.colGeschlecht.Visible = true;
            this.colGeschlecht.VisibleIndex = 5;
            this.colGeschlecht.Width = 35;
            // 
            // colGeburt
            // 
            this.colGeburt.Caption = "Geburt";
            this.colGeburt.FieldName = "Geburtsdatum";
            this.colGeburt.Name = "colGeburt";
            this.colGeburt.Visible = true;
            this.colGeburt.VisibleIndex = 6;
            this.colGeburt.Width = 80;
            // 
            // colVersichertenNr
            // 
            this.colVersichertenNr.Caption = "Versichertennr.";
            this.colVersichertenNr.FieldName = "Versichertennummer";
            this.colVersichertenNr.Name = "colVersichertenNr";
            this.colVersichertenNr.Visible = true;
            this.colVersichertenNr.VisibleIndex = 7;
            this.colVersichertenNr.Width = 113;
            // 
            // colKiSS
            // 
            this.colKiSS.Caption = "KiSS";
            this.colKiSS.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colKiSS.FieldName = "IsKiSSPerson";
            this.colKiSS.Name = "colKiSS";
            this.colKiSS.Visible = true;
            this.colKiSS.VisibleIndex = 8;
            this.colKiSS.Width = 35;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // colOmega
            // 
            this.colOmega.Caption = "Omega";
            this.colOmega.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colOmega.FieldName = "IsOmegaPerson";
            this.colOmega.Name = "colOmega";
            this.colOmega.Visible = true;
            this.colOmega.VisibleIndex = 9;
            this.colOmega.Width = 41;
            // 
            // colEinwohnerregisterAktiv
            // 
            this.colEinwohnerregisterAktiv.Caption = "Aktiv";
            this.colEinwohnerregisterAktiv.ColumnEdit = this.repositoryItemCheckEdit2;
            this.colEinwohnerregisterAktiv.FieldName = "EinwohnerregisterAktiv";
            this.colEinwohnerregisterAktiv.Name = "colEinwohnerregisterAktiv";
            this.colEinwohnerregisterAktiv.Visible = true;
            this.colEinwohnerregisterAktiv.VisibleIndex = 10;
            this.colEinwohnerregisterAktiv.Width = 40;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            this.repositoryItemCheckEdit2.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // colEinwohnerregisterID
            // 
            this.colEinwohnerregisterID.Caption = "PID";
            this.colEinwohnerregisterID.FieldName = "EinwohnerregisterIDOhne0er";
            this.colEinwohnerregisterID.Name = "colEinwohnerregisterID";
            this.colEinwohnerregisterID.Visible = true;
            this.colEinwohnerregisterID.VisibleIndex = 11;
            // 
            // colZIP
            // 
            this.colZIP.Caption = "ZIP";
            this.colZIP.FieldName = "ZIPNr";
            this.colZIP.Name = "colZIP";
            this.colZIP.Visible = false;
            this.colZIP.VisibleIndex = -1;
            // 
            // colAHVNr
            // 
            this.colAHVNr.Caption = "AHV-Nr";
            this.colAHVNr.FieldName = "AHVNummer";
            this.colAHVNr.Name = "colAHVNr";
            this.colAHVNr.Visible = true;
            this.colAHVNr.VisibleIndex = 13;
            this.colAHVNr.Width = 95;
            // 
            // repositoryItemGridLookUpEdit1
            // 
            this.repositoryItemGridLookUpEdit1.AutoHeight = false;
            this.repositoryItemGridLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1";
            this.repositoryItemGridLookUpEdit1.View = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // kissLabel1
            // 
            this.kissLabel1.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.kissLabel1.Location = new System.Drawing.Point(6, 8);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(609, 16);
            this.kissLabel1.TabIndex = 0;
            this.kissLabel1.Text = "Person in Omega/KiSS suchen";
            this.kissLabel1.UseCompatibleTextRendering = true;
            // 
            // qryAdresse
            // 
            this.qryAdresse.CanInsert = true;
            this.qryAdresse.HostControl = this;
            this.qryAdresse.SelectStatement = "SELECT TOP 0 *\r\nFROM BaAdresse";
            this.qryAdresse.TableName = "BaAdresse";
            // 
            // qryPraemienuebernahme
            // 
            this.qryPraemienuebernahme.CanInsert = true;
            this.qryPraemienuebernahme.HostControl = this;
            this.qryPraemienuebernahme.SelectStatement = "SELECT TOP 0 *\r\nFROM BaPraemienuebernahme";
            this.qryPraemienuebernahme.TableName = "BaPraemienuebernahme";
            // 
            // qryPraemienverbilligung
            // 
            this.qryPraemienverbilligung.CanInsert = true;
            this.qryPraemienverbilligung.HostControl = this;
            this.qryPraemienverbilligung.SelectStatement = "SELECT TOP 0 *\r\nFROM BaPraemienverbilligung";
            this.qryPraemienverbilligung.TableName = "BaPraemienverbilligung";
            // 
            // CtlSuchePerson
            // 
            this.ActiveSQLQuery = this.qryVwPerson;
            this.Controls.Add(this.tabPerson);
            this.Name = "CtlSuchePerson";
            this.Size = new System.Drawing.Size(964, 618);
            this.Load += new System.EventHandler(this.CtlSuchePerson_Load);
            this.tabPerson.ResumeLayout(false);
            this.tbpVIS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel67)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel49)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel54)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel55)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel56)).EndInit();
            this.tabVISSearch.ResumeLayout(false);
            this.tpgVISSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel61)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVISFallNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel62)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVISZIPNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel63)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVISGeburtsdatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel64)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel65)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVISVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel66)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVISNachname.Properties)).EndInit();
            this.tpgVISListe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdVISMandant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVISMandant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVISMandant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVISMassnahme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVISMassnahme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVISMassnahme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissDateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit6.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit8.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit9.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit1.Properties)).EndInit();
            this.tpgPersonErfassen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblMeldungBerechnungsperson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassenVersichertennummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryNeuePerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonOhneLeistung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassenNationalitaet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassenNationalitaet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassenGeschlecht.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassenGeschlecht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassenGeburtsdatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassenAHVNummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassenVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassenName.Properties)).EndInit();
            this.tpgPersonSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblPID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVwPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSozialraum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZIPNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWMALand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWMALand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWMAPostfach.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWMAStrasseHausNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWMAAdresszusatz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinwohnerregisterAktiv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlecht.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlecht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsdatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAHVNummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersichertennummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).EndInit();
            this.tabSearch.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGeschlecht.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGeschlecht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchePID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchePID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAHV13.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheZemis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAuchAehnliche.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNurAktive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAHV11.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGebDatBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGebDatVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchInKiSS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchInOmega.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheHausNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNachname.Properties)).EndInit();
            this.tpgListe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdVwPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVwPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAdresse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPraemienuebernahme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPraemienverbilligung)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected KissSearch kissSearch;
        protected KissSearch kissVISSearch;
        private KiSS4.Gui.KissHyperlinkButton btnKIS;
        private DevExpress.XtraGrid.Columns.GridColumn colAHVNr;
        private DevExpress.XtraGrid.Columns.GridColumn colOmega;
        private DevExpress.XtraGrid.Columns.GridColumn colEinwohnerregisterAktiv;
        private DevExpress.XtraGrid.Columns.GridColumn colFalltraeger;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburt;
        private DevExpress.XtraGrid.Columns.GridColumn colGeschlecht;
        private DevExpress.XtraGrid.Columns.GridColumn colKiSS;
        private DevExpress.XtraGrid.Columns.GridColumn colMandatTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colMassnahme;
        private DevExpress.XtraGrid.Columns.GridColumn colMassnahmeBis;
        private DevExpress.XtraGrid.Columns.GridColumn colMassnahmeVon;
        private DevExpress.XtraGrid.Columns.GridColumn colMT;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasse;
        private DevExpress.XtraGrid.Columns.GridColumn colVersichertenNr;
        private DevExpress.XtraGrid.Columns.GridColumn colVISFallNr;
        private DevExpress.XtraGrid.Columns.GridColumn colVormschID;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colZIP;
        private DevExpress.XtraGrid.Columns.GridColumn colZipInKiss;
        private System.ComponentModel.IContainer components;
        private KiSS4.Common.CtlGotoFall ctlGotoFall;
        private KiSS4.Common.CtlGotoFall ctlGotoFall1;
        private KiSS4.Gui.KissTextEdit edtAHVNummer;
        private KiSS4.Gui.KissCheckEdit edtEinwohnerregisterAktiv;
        private KiSS4.Gui.KissTextEdit edtBaPersonID;
        private KiSS4.Gui.KissTextEdit edtErfassenAHVNummer;
        private KiSS4.Gui.KissDateEdit edtErfassenGeburtsdatum;
        private KiSS4.Gui.KissLookUpEdit edtErfassenGeschlecht;
        private KiSS4.Gui.KissTextEdit edtErfassenName;
        private KiSS4.Gui.KissLookUpEdit edtErfassenNationalitaet;
        private KissVersichertenNrEdit edtErfassenVersichertennummer;
        private KiSS4.Gui.KissTextEdit edtErfassenVorname;
        private KiSS4.Gui.KissDateEdit edtGeburtsdatum;
        private KiSS4.Gui.KissLookUpEdit edtGeschlecht;
        private KiSS4.Gui.KissTextEdit edtName;
        private KiSS4.Gui.KissLookUpEdit edtNationalitaet;
        private KiSS4.Gui.KissCheckEdit edtPersonOhneLeistung;
        private KiSS4.Gui.KissCheckEdit edtSearchInOmega;
        private KiSS4.Gui.KissCheckEdit edtSearchInKiSS;
        private KiSS4.Gui.KissButtonEdit edtSozialraum;
        private KiSS4.Gui.KissTextEdit edtSucheAHV11;
        private KiSS4.Gui.KissCheckEdit edtSucheAuchAehnliche;
        private KiSS4.Gui.KissDateEdit edtSucheGebDatBis;
        private KiSS4.Gui.KissDateEdit edtSucheGebDatVon;
        private KiSS4.Gui.KissTextEdit edtSucheHausNr;
        private KiSS4.Gui.KissTextEdit edtSucheNachname;
        private KiSS4.Gui.KissCheckEdit edtSucheNurAktive;
        private KiSS4.Gui.KissTextEdit edtSucheStrasse;
        private KissVersichertenNrEdit edtSucheAHV13;
        private KiSS4.Gui.KissCalcEdit edtSucheVISFallNr;
        private KiSS4.Gui.KissDateEdit edtSucheVISGeburtsdatum;
        private KiSS4.Gui.KissTextEdit edtSucheVISNachname;
        private KiSS4.Gui.KissTextEdit edtSucheVISVorname;
        private KiSS4.Gui.KissCalcEdit edtSucheVISZIPNr;
        private KiSS4.Gui.KissTextEdit edtSucheVorname;
        private KiSS4.Gui.KissTextEdit edtSucheZemis;
        private KiSS4.Gui.KissTextEdit edtVersichertennummer;
        private KiSS4.Gui.KissTextEdit edtVorname;
        private KiSS4.Gui.KissTextEdit edtWMAAdresszusatz;
        private KiSS4.Gui.KissLookUpEdit edtWMALand;
        private KiSS4.Common.KissPLZOrt edtWMAOrt;
        private KiSS4.Gui.KissTextEdit edtWMAPostfach;
        private KiSS4.Gui.KissTextEdit edtWMAStrasseHausNr;
        private KiSS4.Gui.KissTextEdit edtZIPNr;
        private KiSS4.Gui.KissGrid grdVISMandant;
        private KiSS4.Gui.KissGrid grdVISMassnahme;
        private KiSS4.Gui.KissGrid grdVwPerson;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVISMandant;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVISMassnahme;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVwPerson;
        private KiSS4.Gui.KissDateEdit kissDateEdit1;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel kissLabel10;
        private KiSS4.Gui.KissLabel kissLabel11;
        private KiSS4.Gui.KissLabel kissLabel12;
        private KiSS4.Gui.KissLabel kissLabel13;
        private KiSS4.Gui.KissLabel kissLabel14;
        private KiSS4.Gui.KissLabel kissLabel15;
        private KiSS4.Gui.KissLabel kissLabel16;
        private KiSS4.Gui.KissLabel kissLabel17;
        private KiSS4.Gui.KissLabel kissLabel18;
        private KiSS4.Gui.KissLabel kissLabel19;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissLabel kissLabel20;
        private KiSS4.Gui.KissLabel kissLabel21;
        private KiSS4.Gui.KissLabel kissLabel22;
        private KiSS4.Gui.KissLabel kissLabel23;
        private KiSS4.Gui.KissLabel kissLabel24;
        private KiSS4.Gui.KissLabel kissLabel25;
        private KiSS4.Gui.KissLabel kissLabel26;
        private KiSS4.Gui.KissLabel kissLabel27;
        private KiSS4.Gui.KissLabel kissLabel28;
        private KiSS4.Gui.KissLabel kissLabel29;
        private KiSS4.Gui.KissLabel kissLabel3;
        private KiSS4.Gui.KissLabel kissLabel30;
        private KiSS4.Gui.KissLabel kissLabel31;
        private KiSS4.Gui.KissLabel kissLabel32;
        private KiSS4.Gui.KissLabel kissLabel33;
        private KiSS4.Gui.KissLabel kissLabel34;
        private KiSS4.Gui.KissLabel kissLabel35;
        private KiSS4.Gui.KissLabel kissLabel36;
        private KiSS4.Gui.KissLabel kissLabel37;
        private KiSS4.Gui.KissLabel kissLabel38;
        private KiSS4.Gui.KissLabel kissLabel39;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel kissLabel40;
        private KiSS4.Gui.KissLabel kissLabel41;
        private KiSS4.Gui.KissLabel kissLabel42;
        private KiSS4.Gui.KissLabel kissLabel43;
        private KissLabel kissLabel44;
        private KiSS4.Gui.KissLabel kissLabel49;
        private KiSS4.Gui.KissLabel kissLabel5;
        private KiSS4.Gui.KissLabel kissLabel52;
        private KiSS4.Gui.KissLabel kissLabel53;
        private KiSS4.Gui.KissLabel kissLabel54;
        private KiSS4.Gui.KissLabel kissLabel55;
        private KiSS4.Gui.KissLabel kissLabel56;
        private KiSS4.Gui.KissLabel kissLabel61;
        private KiSS4.Gui.KissLabel kissLabel62;
        private KiSS4.Gui.KissLabel kissLabel63;
        private KiSS4.Gui.KissLabel kissLabel64;
        private KiSS4.Gui.KissLabel kissLabel65;
        private KiSS4.Gui.KissLabel kissLabel66;
        private KiSS4.Gui.KissLabel kissLabel67;
        private KiSS4.Gui.KissLabel kissLabel7;
        private KiSS4.Gui.KissLabel kissLabel9;
        private KiSS4.Gui.KissSearchTitel kissSearchTitel1;
        private KiSS4.Gui.KissTextEdit kissTextEdit1;
        private KiSS4.Gui.KissTextEdit kissTextEdit2;
        private KiSS4.Gui.KissTextEdit kissTextEdit3;
        private KiSS4.Gui.KissTextEdit kissTextEdit4;
        private KiSS4.Gui.KissTextEdit kissTextEdit5;
        private KiSS4.Gui.KissTextEdit kissTextEdit6;
        private KiSS4.Gui.KissTextEdit kissTextEdit8;
        private KiSS4.Gui.KissTextEdit kissTextEdit9;
        private KiSS4.DB.SqlQuery qryAdresse;
        private KiSS4.DB.SqlQuery qryNeuePerson;
        private KiSS4.DB.SqlQuery qryPraemienuebernahme;
        private KiSS4.DB.SqlQuery qryPraemienverbilligung;
        private KiSS4.DB.SqlQuery qryVISMandant;
        private KiSS4.DB.SqlQuery qryVISMassnahme;
        private KiSS4.DB.SqlQuery qryVwPerson;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit4;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit5;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit6;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit2;
        private KiSS4.Gui.KissSearchTitel searchTitle;
        private KiSS4.Gui.KissTabControlEx tabPerson;
        private KiSS4.Gui.KissTabControlEx tabSearch;
        private KiSS4.Gui.KissTabControlEx tabVISSearch;
        private SharpLibrary.WinControls.TabPageEx tbpVIS;
        private SharpLibrary.WinControls.TabPageEx tpgListe;
        private SharpLibrary.WinControls.TabPageEx tpgPersonErfassen;
        private SharpLibrary.WinControls.TabPageEx tpgPersonSuchen;
        private SharpLibrary.WinControls.TabPageEx tpgSuchen;
        private SharpLibrary.WinControls.TabPageEx tpgVISListe;
        private SharpLibrary.WinControls.TabPageEx tpgVISSuchen;
        private KissLabel lblMeldungBerechnungsperson;
        private KissLabel lblPID;
        private KissTextEdit edtPID;
        private KissTextEdit edtSuchePID;
        private KissLabel lblSuchePID;
        private DevExpress.XtraGrid.Columns.GridColumn colEinwohnerregisterID;
        private KissLookUpEdit edtSucheGeschlecht;
        private KissLabel kissLabel45;
    }
}