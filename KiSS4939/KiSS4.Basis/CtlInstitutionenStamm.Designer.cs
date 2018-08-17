using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS4.Basis
{
    partial class CtlInstitutionenStamm
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
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject17 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlInstitutionenStamm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
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
            this.grdBaInstitution = new KiSS4.Gui.KissGrid();
            this.qryBaInstitution = new KiSS4.DB.SqlQuery(this.components);
            this.grvBaInstitution = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbteilung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTitel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInstitutionVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZusatz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPostfach = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelefon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEMail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAktiv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBemerkungen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.edtSucheKeinSerienbrief = new KiSS4.Gui.KissCheckEdit();
            this.lblSucheId = new KiSS4.Gui.KissLabel();
            this.chkSucheAuchKontakte = new KiSS4.Gui.KissCheckEdit();
            this.pnlSucheInstTypen = new System.Windows.Forms.Panel();
            this.pklSucheInstTypen = new KiSS4.Gui.KissPickList();
            this.chkSucheInstitutionenMitAllenTypen = new KiSS4.Gui.KissCheckEdit();
            this.chkSucheNurAktive = new KiSS4.Gui.KissCheckEdit();
            this.edtSucheBaInstitutionId = new KiSS4.Gui.KissIntEdit();
            this.lblSucheOrgEinheit = new KiSS4.Gui.KissLabel();
            this.edtSucheOrgEinheit = new KiSS4.Gui.KissLookUpEdit();
            this.lblInstitutionNrX = new KiSS4.Gui.KissLabel();
            this.kissSearchTitel1 = new KiSS4.Gui.KissSearchTitel();
            this.lblTelefonX = new KiSS4.Gui.KissLabel();
            this.lblSucheBemerkung = new KiSS4.Gui.KissLabel();
            this.lblEMailX = new KiSS4.Gui.KissLabel();
            this.lblPLZOrtX = new KiSS4.Gui.KissLabel();
            this.lblNameX = new KiSS4.Gui.KissLabel();
            this.edtTelefonX = new KiSS4.Gui.KissTextEdit();
            this.edtSucheBemerkung = new KiSS4.Gui.KissTextEdit();
            this.edtEMailX = new KiSS4.Gui.KissTextEdit();
            this.edtInstitutionNrX = new KiSS4.Gui.KissTextEdit();
            this.edtOrtX = new KiSS4.Gui.KissTextEdit();
            this.edtPLZX = new KiSS4.Gui.KissTextEdit();
            this.edtNameX = new KiSS4.Gui.KissTextEdit();
            this.lblAnzDatensaetze = new System.Windows.Forms.Label();
            this.lblRowCount = new System.Windows.Forms.Label();
            this.qryBaAdresse = new KiSS4.DB.SqlQuery(this.components);
            this.qryBaInstitutionKontakt = new KiSS4.DB.SqlQuery(this.components);
            this.tabPageEx1 = new SharpLibrary.WinControls.TabPageEx();
            this.tabPageEx2 = new SharpLibrary.WinControls.TabPageEx();
            this.qryInstTypen = new KiSS4.DB.SqlQuery(this.components);
            this.pklInstTypen = new KiSS4.Gui.KissPickList();
            this.qryZugeordneteInstTypen = new KiSS4.DB.SqlQuery(this.components);
            this.qrySucheInstTypen = new KiSS4.DB.SqlQuery(this.components);
            this.qrySucheSelectedInstTypen = new KiSS4.DB.SqlQuery(this.components);
            this.tbpTypisierung = new SharpLibrary.WinControls.TabPageEx();
            this.panTypen = new System.Windows.Forms.Panel();
            this.tbpZahlweg = new SharpLibrary.WinControls.TabPageEx();
            this.ctlZahlungsweg = new KiSS4.Basis.CtlBaZahlungsweg();
            this.tbpKontakt = new SharpLibrary.WinControls.TabPageEx();
            this.grdKontakt = new KiSS4.Gui.KissGrid();
            this.grvKontakt = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKontaktName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKontaktVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKontaktTelefon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKontaktEMail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKontaktAktiv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panDetailsKontakt = new System.Windows.Forms.Panel();
            this.lblKontaktPersonName = new KiSS4.Gui.KissLabel();
            this.chkKontaktAktiv = new KiSS4.Gui.KissCheckEdit();
            this.edtKontaktName = new KiSS4.Gui.KissTextEdit();
            this.edtKontaktGeschlecht = new KiSS4.Gui.KissLookUpEdit();
            this.edtKontaktVorname = new KiSS4.Gui.KissTextEdit();
            this.chkKontaktManuelleAnrede = new KiSS4.Gui.KissCheckEdit();
            this.edtKontaktTelefon = new KiSS4.Gui.KissTextEdit();
            this.edtKontaktBriefanrede = new KiSS4.Gui.KissTextEdit();
            this.edtKontaktFax = new KiSS4.Gui.KissTextEdit();
            this.edtKontaktTitel = new KiSS4.Gui.KissTextEdit();
            this.edtKontaktEMail = new KiSS4.Gui.KissTextEdit();
            this.lblKontaktAnrede = new KiSS4.Gui.KissLabel();
            this.edtKontaktBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.lblKontaktTitel = new KiSS4.Gui.KissLabel();
            this.lblKontaktPersonVorname = new KiSS4.Gui.KissLabel();
            this.lblKontaktBriefanrede = new KiSS4.Gui.KissLabel();
            this.lblKontaktGeschlecht = new KiSS4.Gui.KissLabel();
            this.edtKontaktAnrede = new KiSS4.Gui.KissTextEdit();
            this.lblKontaktEMail = new KiSS4.Gui.KissLabel();
            this.lblKontaktSprache = new KiSS4.Gui.KissLabel();
            this.lblKontaktFax = new KiSS4.Gui.KissLabel();
            this.edtKontaktSprachCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblKontaktTelefon = new KiSS4.Gui.KissLabel();
            this.lblKontaktBemerkung = new KiSS4.Gui.KissLabel();
            this.tbpInstitution = new SharpLibrary.WinControls.TabPageEx();
            this.panDetails = new System.Windows.Forms.Panel();
            this.edtVersichertennummer = new KiSS4.Gui.KissVersichertenNrEdit();
            this.edtGeburtsdatum = new KiSS4.Gui.KissDateEdit();
            this.lblVersichertennummer = new KiSS4.Gui.KissLabel();
            this.lblGeburtsdatum = new KiSS4.Gui.KissLabel();
            this.edtPLZOrt = new KiSS4.Common.KissPLZOrt();
            this.chkKeinSerienbrief = new KiSS4.Gui.KissCheckEdit();
            this.edtGeschlecht = new KiSS4.Gui.KissLookUpEdit();
            this.edtVorname = new KiSS4.Gui.KissTextEdit();
            this.chkManuelleAnrede = new KiSS4.Gui.KissCheckEdit();
            this.edtInstName = new KiSS4.Gui.KissMemoEdit();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.edtBriefanrede = new KiSS4.Gui.KissTextEdit();
            this.edtTitel = new KiSS4.Gui.KissTextEdit();
            this.edtAbteilung = new KiSS4.Gui.KissLookUpEdit();
            this.lblAbteilung = new KiSS4.Gui.KissLabel();
            this.chkPostfachOhneNr = new KiSS4.Gui.KissCheckEdit();
            this.lblLand = new KiSS4.Gui.KissLabel();
            this.lblBezirk = new KiSS4.Gui.KissLabel();
            this.lblPLZOrtKt = new KiSS4.Gui.KissLabel();
            this.rgrItemTyp = new KiSS4.Gui.KissRadioGroup(this.components);
            this.edtKreditor = new KiSS4.Gui.KissCheckEdit();
            this.edtDebitor = new KiSS4.Gui.KissCheckEdit();
            this.lblInstNr = new KiSS4.Gui.KissLabel();
            this.edtInstitutionNr = new KiSS4.Gui.KissTextEdit();
            this.lblHomepage = new KiSS4.Gui.KissLabel();
            this.lblAnrede = new KiSS4.Gui.KissLabel();
            this.lblVorname = new KiSS4.Gui.KissLabel();
            this.lblName = new KiSS4.Gui.KissLabel();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.lblSprachCode = new KiSS4.Gui.KissLabel();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.lblBriefanrede = new KiSS4.Gui.KissLabel();
            this.lblGeschlecht = new KiSS4.Gui.KissLabel();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.lblTelefon3 = new KiSS4.Gui.KissLabel();
            this.lblFax = new KiSS4.Gui.KissLabel();
            this.lblEMail = new KiSS4.Gui.KissLabel();
            this.lblZusatz = new KiSS4.Gui.KissLabel();
            this.lblPostfach = new KiSS4.Gui.KissLabel();
            this.lblStrasseNr = new KiSS4.Gui.KissLabel();
            this.btnDatenblatt = new KiSS4.Dokument.KissDocumentButton();
            this.edtSprachCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtHomepage = new KiSS4.Gui.KissTextEdit();
            this.edtEMail = new KiSS4.Gui.KissTextEdit();
            this.edtFax = new KiSS4.Gui.KissTextEdit();
            this.edtTelefon1 = new KiSS4.Gui.KissTextEdit();
            this.edtTelefon2 = new KiSS4.Gui.KissTextEdit();
            this.edtTelefon3 = new KiSS4.Gui.KissTextEdit();
            this.edtAktiv = new KiSS4.Gui.KissCheckEdit();
            this.edtPostfach = new KiSS4.Gui.KissTextEdit();
            this.edtHausNr = new KiSS4.Gui.KissTextEdit();
            this.edtStrasse = new KiSS4.Gui.KissTextEdit();
            this.edtAdressZusatz = new KiSS4.Gui.KissTextEdit();
            this.edtPersonName = new KiSS4.Gui.KissTextEdit();
            this.edtAnrede = new KiSS4.Gui.KissTextEdit();
            this.tabInstitution = new KiSS4.Gui.KissTabControlEx();
            this.tbpDokumente = new SharpLibrary.WinControls.TabPageEx();
            this.tblDokumente = new System.Windows.Forms.TableLayoutPanel();
            this.lblDokumentDatum = new KiSS4.Gui.KissLabel();
            this.lblDokumentKontaktart = new KiSS4.Gui.KissLabel();
            this.lblDokumentDienstleistung = new KiSS4.Gui.KissLabel();
            this.lblDokumentStichwort = new KiSS4.Gui.KissLabel();
            this.lblDokumentDauer = new KiSS4.Gui.KissLabel();
            this.lblDokumentInhalt = new KiSS4.Gui.KissLabel();
            this.edtDokumentDatum = new KiSS4.Gui.KissDateEdit();
            this.edtDokumentKontaktart = new KiSS4.Gui.KissLookUpEdit();
            this.edtDokumentDienstleistung = new KiSS4.Gui.KissLookUpEdit();
            this.edtDokumentStichwort = new KiSS4.Gui.KissTextEdit();
            this.edtDokumentDauer = new KiSS4.Gui.KissLookUpEdit();
            this.edtDokumentInhalt = new KiSS4.Gui.KissMemoEdit();
            this.lblDokument = new KiSS4.Gui.KissLabel();
            this.lblDokumentVerfasser = new KiSS4.Gui.KissLabel();
            this.lblDokumentAdressat = new KiSS4.Gui.KissLabel();
            this.docDokument = new KiSS4.Dokument.XDokument();
            this.edtDokumentVerfasser = new KiSS4.Common.KissMitarbeiterButtonEdit(this.components);
            this.edtDokumentAdressat = new KiSS4.Common.KissAdressatButtonEdit(this.components);
            this.grdDokumente = new KiSS4.Gui.KissGrid();
            this.qryDokumente = new KiSS4.DB.SqlQuery(this.components);
            this.grvDokumente = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDokumenteDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDokumenteKontaktart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDokumenteDienstleistung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDokumenteStichwort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDokumenteVerfasser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDokumenteAdressat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDokumenteAufwand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splDetailListe = new KiSS4.Gui.KissSplitterCollapsible();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaInstitution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaInstitution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaInstitution)).BeginInit();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKeinSerienbrief.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheAuchKontakte.Properties)).BeginInit();
            this.pnlSucheInstTypen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheInstitutionenMitAllenTypen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheNurAktive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBaInstitutionId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheOrgEinheit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheOrgEinheit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheOrgEinheit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInstitutionNrX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefonX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEMailX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPLZOrtX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefonX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEMailX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInstitutionNrX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrtX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPLZX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaAdresse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaInstitutionKontakt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryInstTypen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeordneteInstTypen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrySucheInstTypen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrySucheSelectedInstTypen)).BeginInit();
            this.tbpTypisierung.SuspendLayout();
            this.panTypen.SuspendLayout();
            this.tbpZahlweg.SuspendLayout();
            this.tbpKontakt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdKontakt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKontakt)).BeginInit();
            this.panDetailsKontakt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktPersonName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKontaktAktiv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktGeschlecht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktGeschlecht.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKontaktManuelleAnrede.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktTelefon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktBriefanrede.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktFax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktTitel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktEMail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktAnrede)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktPersonVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktBriefanrede)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktGeschlecht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktAnrede.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktEMail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktSprache)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktFax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktSprachCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktSprachCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktTelefon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktBemerkung)).BeginInit();
            this.tbpInstitution.SuspendLayout();
            this.panDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersichertennummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsdatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersichertennummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKeinSerienbrief.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlecht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlecht.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkManuelleAnrede.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInstName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBriefanrede.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTitel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbteilung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbteilung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbteilung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPostfachOhneNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBezirk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPLZOrtKt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgrItemTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgrItemTyp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDebitor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInstNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInstitutionNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHomepage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnrede)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSprachCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBriefanrede)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeschlecht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefon3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEMail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPostfach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasseNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSprachCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSprachCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHomepage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEMail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefon1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefon2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefon3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAktiv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPostfach.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHausNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdressZusatz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnrede.Properties)).BeginInit();
            this.tabInstitution.SuspendLayout();
            this.tbpDokumente.SuspendLayout();
            this.tblDokumente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokumentDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokumentKontaktart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokumentDienstleistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokumentStichwort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokumentDauer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokumentInhalt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentKontaktart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentKontaktart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentDienstleistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentDienstleistung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentStichwort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentDauer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentDauer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentInhalt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokumentVerfasser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokumentAdressat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docDokument.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentVerfasser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentAdressat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDokumente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryDokumente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDokumente)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Location = new System.Drawing.Point(2, 2);
            this.searchTitle.Size = new System.Drawing.Size(1062, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(1086, 284);
            this.tabControlSearch.SizeChanged += new System.EventHandler(this.tabControlSearch_SizeChanged);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdBaInstitution);
            this.tpgListe.Size = new System.Drawing.Size(1074, 246);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.pnlSearch);
            this.tpgSuchen.Size = new System.Drawing.Size(1074, 246);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.pnlSearch, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            // 
            // grdBaInstitution
            // 
            this.grdBaInstitution.DataSource = this.qryBaInstitution;
            this.grdBaInstitution.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdBaInstitution.EmbeddedNavigator.Name = "gridList.EmbeddedNavigator";
            this.grdBaInstitution.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBaInstitution.Location = new System.Drawing.Point(0, 0);
            this.grdBaInstitution.MainView = this.grvBaInstitution;
            this.grdBaInstitution.Name = "grdBaInstitution";
            this.grdBaInstitution.Size = new System.Drawing.Size(1074, 246);
            this.grdBaInstitution.TabIndex = 0;
            this.grdBaInstitution.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBaInstitution});
            // 
            // qryBaInstitution
            // 
            this.qryBaInstitution.CanDelete = true;
            this.qryBaInstitution.CanInsert = true;
            this.qryBaInstitution.CanUpdate = true;
            this.qryBaInstitution.HostControl = this;
            this.qryBaInstitution.SelectStatement = resources.GetString("qryBaInstitution.SelectStatement");
            this.qryBaInstitution.TableName = "BaInstitution";
            this.qryBaInstitution.AfterDelete += new System.EventHandler(this.qryBaInstitution_AfterDelete);
            this.qryBaInstitution.AfterFill += new System.EventHandler(this.qryBaInstitution_AfterFill);
            this.qryBaInstitution.AfterInsert += new System.EventHandler(this.qryBaInstitution_AfterInsert);
            this.qryBaInstitution.AfterPost += new System.EventHandler(this.qryBaInstitution_AfterPost);
            this.qryBaInstitution.BeforeDelete += new System.EventHandler(this.qryBaInstitution_BeforeDelete);
            this.qryBaInstitution.BeforeDeleteQuestion += new System.EventHandler(this.qryBaInstitution_BeforeDeleteQuestion);
            this.qryBaInstitution.BeforePost += new System.EventHandler(this.qryBaInstitution_BeforePost);
            this.qryBaInstitution.PositionChanged += new System.EventHandler(this.qryBaInstitution_PositionChanged);
            this.qryBaInstitution.PositionChanging += new System.EventHandler(this.qryBaInstitution_PositionChanging);
            this.qryBaInstitution.PostCompleted += new System.EventHandler(this.qryBaInstitution_PostCompleted);
            // 
            // grvBaInstitution
            // 
            this.grvBaInstitution.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBaInstitution.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaInstitution.Appearance.Empty.Options.UseBackColor = true;
            this.grvBaInstitution.Appearance.Empty.Options.UseFont = true;
            this.grvBaInstitution.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaInstitution.Appearance.EvenRow.Options.UseFont = true;
            this.grvBaInstitution.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaInstitution.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaInstitution.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBaInstitution.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBaInstitution.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBaInstitution.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBaInstitution.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaInstitution.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaInstitution.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBaInstitution.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBaInstitution.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBaInstitution.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBaInstitution.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaInstitution.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBaInstitution.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaInstitution.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaInstitution.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaInstitution.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBaInstitution.Appearance.GroupRow.Options.UseFont = true;
            this.grvBaInstitution.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBaInstitution.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBaInstitution.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBaInstitution.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaInstitution.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBaInstitution.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBaInstitution.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBaInstitution.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBaInstitution.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaInstitution.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaInstitution.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBaInstitution.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBaInstitution.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBaInstitution.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaInstitution.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBaInstitution.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaInstitution.Appearance.OddRow.Options.UseFont = true;
            this.grvBaInstitution.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBaInstitution.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaInstitution.Appearance.Row.Options.UseBackColor = true;
            this.grvBaInstitution.Appearance.Row.Options.UseFont = true;
            this.grvBaInstitution.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaInstitution.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBaInstitution.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaInstitution.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBaInstitution.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBaInstitution.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNr,
            this.colAbteilung,
            this.colTitel,
            this.colName,
            this.colInstitutionVorname,
            this.colZusatz,
            this.colStrasse,
            this.colPostfach,
            this.colPLZ,
            this.colOrt,
            this.colLand,
            this.colTelefon,
            this.colFax,
            this.colEMail,
            this.colTyp,
            this.colAktiv,
            this.colBemerkungen,
            this.colArt});
            this.grvBaInstitution.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBaInstitution.GridControl = this.grdBaInstitution;
            this.grvBaInstitution.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvBaInstitution.Name = "grvBaInstitution";
            this.grvBaInstitution.OptionsBehavior.Editable = false;
            this.grvBaInstitution.OptionsCustomization.AllowFilter = false;
            this.grvBaInstitution.OptionsFilter.AllowFilterEditor = false;
            this.grvBaInstitution.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBaInstitution.OptionsMenu.EnableColumnMenu = false;
            this.grvBaInstitution.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBaInstitution.OptionsNavigation.UseTabKey = false;
            this.grvBaInstitution.OptionsView.ColumnAutoWidth = false;
            this.grvBaInstitution.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBaInstitution.OptionsView.ShowGroupPanel = false;
            this.grvBaInstitution.OptionsView.ShowIndicator = false;
            // 
            // colNr
            // 
            this.colNr.Caption = "ID";
            this.colNr.FieldName = "BaInstitutionID";
            this.colNr.Name = "colNr";
            this.colNr.Visible = true;
            this.colNr.VisibleIndex = 0;
            this.colNr.Width = 63;
            // 
            // colAbteilung
            // 
            this.colAbteilung.Caption = "Abteilung";
            this.colAbteilung.Name = "colAbteilung";
            this.colAbteilung.Visible = true;
            this.colAbteilung.VisibleIndex = 1;
            // 
            // colTitel
            // 
            this.colTitel.Caption = "Titel";
            this.colTitel.Name = "colTitel";
            this.colTitel.Visible = true;
            this.colTitel.VisibleIndex = 2;
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 3;
            this.colName.Width = 190;
            // 
            // colInstitutionVorname
            // 
            this.colInstitutionVorname.Caption = "Vorname";
            this.colInstitutionVorname.FieldName = "Vorname";
            this.colInstitutionVorname.Name = "colInstitutionVorname";
            this.colInstitutionVorname.Visible = true;
            this.colInstitutionVorname.VisibleIndex = 4;
            this.colInstitutionVorname.Width = 150;
            // 
            // colZusatz
            // 
            this.colZusatz.Caption = "Zusatz";
            this.colZusatz.Name = "colZusatz";
            this.colZusatz.Visible = true;
            this.colZusatz.VisibleIndex = 5;
            // 
            // colStrasse
            // 
            this.colStrasse.Caption = "Strasse";
            this.colStrasse.FieldName = "StrasseNr";
            this.colStrasse.Name = "colStrasse";
            this.colStrasse.Visible = true;
            this.colStrasse.VisibleIndex = 6;
            this.colStrasse.Width = 160;
            // 
            // colPostfach
            // 
            this.colPostfach.Caption = "Postfach";
            this.colPostfach.Name = "colPostfach";
            this.colPostfach.Visible = true;
            this.colPostfach.VisibleIndex = 7;
            // 
            // colPLZ
            // 
            this.colPLZ.Caption = "PLZ";
            this.colPLZ.Name = "colPLZ";
            this.colPLZ.Visible = true;
            this.colPLZ.VisibleIndex = 8;
            // 
            // colOrt
            // 
            this.colOrt.Caption = "Ort";
            this.colOrt.FieldName = "PLZOrt";
            this.colOrt.Name = "colOrt";
            this.colOrt.Visible = true;
            this.colOrt.VisibleIndex = 9;
            this.colOrt.Width = 140;
            // 
            // colLand
            // 
            this.colLand.Caption = "Land";
            this.colLand.Name = "colLand";
            this.colLand.Visible = true;
            this.colLand.VisibleIndex = 10;
            // 
            // colTelefon
            // 
            this.colTelefon.Caption = "Telefon";
            this.colTelefon.Name = "colTelefon";
            this.colTelefon.Visible = true;
            this.colTelefon.VisibleIndex = 11;
            // 
            // colFax
            // 
            this.colFax.Caption = "Fax";
            this.colFax.Name = "colFax";
            this.colFax.Visible = true;
            this.colFax.VisibleIndex = 12;
            // 
            // colEMail
            // 
            this.colEMail.Caption = "E-Mail";
            this.colEMail.Name = "colEMail";
            this.colEMail.Visible = true;
            this.colEMail.VisibleIndex = 13;
            // 
            // colTyp
            // 
            this.colTyp.Caption = "Typisierung";
            this.colTyp.Name = "colTyp";
            this.colTyp.Visible = true;
            this.colTyp.VisibleIndex = 14;
            this.colTyp.Width = 149;
            // 
            // colAktiv
            // 
            this.colAktiv.Caption = "Aktiv";
            this.colAktiv.Name = "colAktiv";
            this.colAktiv.Visible = true;
            this.colAktiv.VisibleIndex = 15;
            // 
            // colBemerkungen
            // 
            this.colBemerkungen.Caption = "Bemerkungen";
            this.colBemerkungen.Name = "colBemerkungen";
            this.colBemerkungen.Visible = true;
            this.colBemerkungen.VisibleIndex = 16;
            // 
            // colArt
            // 
            this.colArt.Caption = "Art";
            this.colArt.Name = "colArt";
            this.colArt.Visible = true;
            this.colArt.VisibleIndex = 17;
            // 
            // pnlSearch
            // 
            this.pnlSearch.AutoScroll = true;
            this.pnlSearch.AutoScrollMinSize = new System.Drawing.Size(960, 240);
            this.pnlSearch.Controls.Add(this.edtSucheKeinSerienbrief);
            this.pnlSearch.Controls.Add(this.lblSucheId);
            this.pnlSearch.Controls.Add(this.chkSucheAuchKontakte);
            this.pnlSearch.Controls.Add(this.pnlSucheInstTypen);
            this.pnlSearch.Controls.Add(this.chkSucheInstitutionenMitAllenTypen);
            this.pnlSearch.Controls.Add(this.chkSucheNurAktive);
            this.pnlSearch.Controls.Add(this.edtSucheBaInstitutionId);
            this.pnlSearch.Controls.Add(this.lblSucheOrgEinheit);
            this.pnlSearch.Controls.Add(this.edtSucheOrgEinheit);
            this.pnlSearch.Controls.Add(this.lblInstitutionNrX);
            this.pnlSearch.Controls.Add(this.kissSearchTitel1);
            this.pnlSearch.Controls.Add(this.lblTelefonX);
            this.pnlSearch.Controls.Add(this.lblSucheBemerkung);
            this.pnlSearch.Controls.Add(this.lblEMailX);
            this.pnlSearch.Controls.Add(this.lblPLZOrtX);
            this.pnlSearch.Controls.Add(this.lblNameX);
            this.pnlSearch.Controls.Add(this.edtTelefonX);
            this.pnlSearch.Controls.Add(this.edtSucheBemerkung);
            this.pnlSearch.Controls.Add(this.edtEMailX);
            this.pnlSearch.Controls.Add(this.edtInstitutionNrX);
            this.pnlSearch.Controls.Add(this.edtOrtX);
            this.pnlSearch.Controls.Add(this.edtPLZX);
            this.pnlSearch.Controls.Add(this.edtNameX);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1074, 246);
            this.pnlSearch.TabIndex = 0;
            // 
            // edtSucheKeinSerienbrief
            // 
            this.edtSucheKeinSerienbrief.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSucheKeinSerienbrief.EditValue = false;
            this.edtSucheKeinSerienbrief.Location = new System.Drawing.Point(707, 217);
            this.edtSucheKeinSerienbrief.Name = "edtSucheKeinSerienbrief";
            this.edtSucheKeinSerienbrief.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSucheKeinSerienbrief.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheKeinSerienbrief.Properties.Caption = "Nur Institutionen mit Serienbrief";
            this.edtSucheKeinSerienbrief.Size = new System.Drawing.Size(268, 19);
            this.edtSucheKeinSerienbrief.TabIndex = 21;
            // 
            // lblSucheId
            // 
            this.lblSucheId.Location = new System.Drawing.Point(252, 32);
            this.lblSucheId.Name = "lblSucheId";
            this.lblSucheId.Size = new System.Drawing.Size(20, 24);
            this.lblSucheId.TabIndex = 3;
            this.lblSucheId.Text = "ID";
            this.lblSucheId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSucheId.UseCompatibleTextRendering = true;
            // 
            // chkSucheAuchKontakte
            // 
            this.chkSucheAuchKontakte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkSucheAuchKontakte.EditValue = false;
            this.chkSucheAuchKontakte.Location = new System.Drawing.Point(433, 215);
            this.chkSucheAuchKontakte.Name = "chkSucheAuchKontakte";
            this.chkSucheAuchKontakte.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkSucheAuchKontakte.Properties.Appearance.Options.UseBackColor = true;
            this.chkSucheAuchKontakte.Properties.Caption = "Auch in Kontakten suchen";
            this.chkSucheAuchKontakte.Size = new System.Drawing.Size(268, 19);
            this.chkSucheAuchKontakte.TabIndex = 20;
            // 
            // pnlSucheInstTypen
            // 
            this.pnlSucheInstTypen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSucheInstTypen.Controls.Add(this.pklSucheInstTypen);
            this.pnlSucheInstTypen.Location = new System.Drawing.Point(430, 32);
            this.pnlSucheInstTypen.MaximumSize = new System.Drawing.Size(559, 750);
            this.pnlSucheInstTypen.MinimumSize = new System.Drawing.Size(450, 129);
            this.pnlSucheInstTypen.Name = "pnlSucheInstTypen";
            this.pnlSucheInstTypen.Size = new System.Drawing.Size(559, 129);
            this.pnlSucheInstTypen.TabIndex = 1;
            // 
            // pklSucheInstTypen
            // 
            this.pklSucheInstTypen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.pklSucheInstTypen.ColumnIDName = null;
            this.pklSucheInstTypen.DataSourceOfSourceGrid = null;
            this.pklSucheInstTypen.DataSourceOfTargetGrid = null;
            this.pklSucheInstTypen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pklSucheInstTypen.FilterColumnName = null;
            this.pklSucheInstTypen.Location = new System.Drawing.Point(0, 0);
            this.pklSucheInstTypen.Name = "pklSucheInstTypen";
            this.pklSucheInstTypen.Size = new System.Drawing.Size(559, 129);
            this.pklSucheInstTypen.TabIndex = 0;
            this.pklSucheInstTypen.TargetFilterVisible = false;
            // 
            // chkSucheInstitutionenMitAllenTypen
            // 
            this.chkSucheInstitutionenMitAllenTypen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkSucheInstitutionenMitAllenTypen.EditValue = false;
            this.chkSucheInstitutionenMitAllenTypen.Location = new System.Drawing.Point(433, 165);
            this.chkSucheInstitutionenMitAllenTypen.Name = "chkSucheInstitutionenMitAllenTypen";
            this.chkSucheInstitutionenMitAllenTypen.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkSucheInstitutionenMitAllenTypen.Properties.Appearance.Options.UseBackColor = true;
            this.chkSucheInstitutionenMitAllenTypen.Properties.Caption = "Nur Institutionen mit allen gewählten Typen";
            this.chkSucheInstitutionenMitAllenTypen.Size = new System.Drawing.Size(268, 19);
            this.chkSucheInstitutionenMitAllenTypen.TabIndex = 18;
            // 
            // chkSucheNurAktive
            // 
            this.chkSucheNurAktive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkSucheNurAktive.EditValue = true;
            this.chkSucheNurAktive.Location = new System.Drawing.Point(433, 190);
            this.chkSucheNurAktive.Name = "chkSucheNurAktive";
            this.chkSucheNurAktive.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkSucheNurAktive.Properties.Appearance.Options.UseBackColor = true;
            this.chkSucheNurAktive.Properties.Caption = "Nur aktive Institutionen und Kontaktpersonen";
            this.chkSucheNurAktive.Size = new System.Drawing.Size(268, 19);
            this.chkSucheNurAktive.TabIndex = 19;
            // 
            // edtSucheBaInstitutionId
            // 
            this.edtSucheBaInstitutionId.Location = new System.Drawing.Point(278, 32);
            this.edtSucheBaInstitutionId.Name = "edtSucheBaInstitutionId";
            this.edtSucheBaInstitutionId.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheBaInstitutionId.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBaInstitutionId.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBaInstitutionId.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBaInstitutionId.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBaInstitutionId.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBaInstitutionId.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBaInstitutionId.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheBaInstitutionId.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheBaInstitutionId.Properties.DisplayFormat.FormatString = "################################";
            this.edtSucheBaInstitutionId.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSucheBaInstitutionId.Properties.EditFormat.FormatString = "################################";
            this.edtSucheBaInstitutionId.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSucheBaInstitutionId.Properties.Mask.EditMask = "################################";
            this.edtSucheBaInstitutionId.Size = new System.Drawing.Size(100, 24);
            this.edtSucheBaInstitutionId.TabIndex = 4;
            this.edtSucheBaInstitutionId.TabStop = false;
            // 
            // lblSucheOrgEinheit
            // 
            this.lblSucheOrgEinheit.Location = new System.Drawing.Point(30, 64);
            this.lblSucheOrgEinheit.Name = "lblSucheOrgEinheit";
            this.lblSucheOrgEinheit.Size = new System.Drawing.Size(100, 23);
            this.lblSucheOrgEinheit.TabIndex = 5;
            this.lblSucheOrgEinheit.Text = "Org. Einheit";
            this.lblSucheOrgEinheit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // edtSucheOrgEinheit
            // 
            this.edtSucheOrgEinheit.Location = new System.Drawing.Point(136, 64);
            this.edtSucheOrgEinheit.Name = "edtSucheOrgEinheit";
            this.edtSucheOrgEinheit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheOrgEinheit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheOrgEinheit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheOrgEinheit.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheOrgEinheit.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheOrgEinheit.Properties.Appearance.Options.UseFont = true;
            this.edtSucheOrgEinheit.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheOrgEinheit.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheOrgEinheit.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheOrgEinheit.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheOrgEinheit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject17.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject17.Options.UseBackColor = true;
            this.edtSucheOrgEinheit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject17)});
            this.edtSucheOrgEinheit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheOrgEinheit.Properties.NullText = "";
            this.edtSucheOrgEinheit.Properties.ShowFooter = false;
            this.edtSucheOrgEinheit.Properties.ShowHeader = false;
            this.edtSucheOrgEinheit.Size = new System.Drawing.Size(242, 24);
            this.edtSucheOrgEinheit.TabIndex = 6;
            // 
            // lblInstitutionNrX
            // 
            this.lblInstitutionNrX.Location = new System.Drawing.Point(30, 33);
            this.lblInstitutionNrX.Name = "lblInstitutionNrX";
            this.lblInstitutionNrX.Size = new System.Drawing.Size(100, 24);
            this.lblInstitutionNrX.TabIndex = 1;
            this.lblInstitutionNrX.Text = "Institution-Nr.";
            this.lblInstitutionNrX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInstitutionNrX.UseCompatibleTextRendering = true;
            // 
            // kissSearchTitel1
            // 
            this.kissSearchTitel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissSearchTitel1.Location = new System.Drawing.Point(9, 4);
            this.kissSearchTitel1.Name = "kissSearchTitel1";
            this.kissSearchTitel1.Size = new System.Drawing.Size(200, 24);
            this.kissSearchTitel1.TabIndex = 0;
            // 
            // lblTelefonX
            // 
            this.lblTelefonX.Location = new System.Drawing.Point(30, 154);
            this.lblTelefonX.Name = "lblTelefonX";
            this.lblTelefonX.Size = new System.Drawing.Size(100, 24);
            this.lblTelefonX.TabIndex = 12;
            this.lblTelefonX.Text = "Telefon";
            this.lblTelefonX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTelefonX.UseCompatibleTextRendering = true;
            // 
            // lblSucheBemerkung
            // 
            this.lblSucheBemerkung.Location = new System.Drawing.Point(30, 214);
            this.lblSucheBemerkung.Name = "lblSucheBemerkung";
            this.lblSucheBemerkung.Size = new System.Drawing.Size(100, 24);
            this.lblSucheBemerkung.TabIndex = 16;
            this.lblSucheBemerkung.Text = "Bemerkung";
            this.lblSucheBemerkung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSucheBemerkung.UseCompatibleTextRendering = true;
            // 
            // lblEMailX
            // 
            this.lblEMailX.Location = new System.Drawing.Point(30, 184);
            this.lblEMailX.Name = "lblEMailX";
            this.lblEMailX.Size = new System.Drawing.Size(100, 24);
            this.lblEMailX.TabIndex = 14;
            this.lblEMailX.Text = "E-Mail";
            this.lblEMailX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEMailX.UseCompatibleTextRendering = true;
            // 
            // lblPLZOrtX
            // 
            this.lblPLZOrtX.Location = new System.Drawing.Point(30, 124);
            this.lblPLZOrtX.Name = "lblPLZOrtX";
            this.lblPLZOrtX.Size = new System.Drawing.Size(100, 24);
            this.lblPLZOrtX.TabIndex = 9;
            this.lblPLZOrtX.Text = "PLZ / Ort";
            this.lblPLZOrtX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPLZOrtX.UseCompatibleTextRendering = true;
            // 
            // lblNameX
            // 
            this.lblNameX.Location = new System.Drawing.Point(30, 94);
            this.lblNameX.Name = "lblNameX";
            this.lblNameX.Size = new System.Drawing.Size(100, 24);
            this.lblNameX.TabIndex = 7;
            this.lblNameX.Text = "Name";
            this.lblNameX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNameX.UseCompatibleTextRendering = true;
            // 
            // edtTelefonX
            // 
            this.edtTelefonX.Location = new System.Drawing.Point(136, 154);
            this.edtTelefonX.Name = "edtTelefonX";
            this.edtTelefonX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTelefonX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTelefonX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTelefonX.Properties.Appearance.Options.UseBackColor = true;
            this.edtTelefonX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTelefonX.Properties.Appearance.Options.UseFont = true;
            this.edtTelefonX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTelefonX.Properties.Name = "editTelefonX.Properties";
            this.edtTelefonX.Size = new System.Drawing.Size(242, 24);
            this.edtTelefonX.TabIndex = 13;
            // 
            // edtSucheBemerkung
            // 
            this.edtSucheBemerkung.Location = new System.Drawing.Point(136, 214);
            this.edtSucheBemerkung.Name = "edtSucheBemerkung";
            this.edtSucheBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheBemerkung.Properties.Name = "editEMailX.Properties";
            this.edtSucheBemerkung.Size = new System.Drawing.Size(242, 24);
            this.edtSucheBemerkung.TabIndex = 17;
            // 
            // edtEMailX
            // 
            this.edtEMailX.Location = new System.Drawing.Point(136, 184);
            this.edtEMailX.Name = "edtEMailX";
            this.edtEMailX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEMailX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEMailX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEMailX.Properties.Appearance.Options.UseBackColor = true;
            this.edtEMailX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEMailX.Properties.Appearance.Options.UseFont = true;
            this.edtEMailX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEMailX.Properties.Name = "editEMailX.Properties";
            this.edtEMailX.Size = new System.Drawing.Size(242, 24);
            this.edtEMailX.TabIndex = 15;
            // 
            // edtInstitutionNrX
            // 
            this.edtInstitutionNrX.Location = new System.Drawing.Point(136, 33);
            this.edtInstitutionNrX.Name = "edtInstitutionNrX";
            this.edtInstitutionNrX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtInstitutionNrX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtInstitutionNrX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtInstitutionNrX.Properties.Appearance.Options.UseBackColor = true;
            this.edtInstitutionNrX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtInstitutionNrX.Properties.Appearance.Options.UseFont = true;
            this.edtInstitutionNrX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtInstitutionNrX.Size = new System.Drawing.Size(75, 24);
            this.edtInstitutionNrX.TabIndex = 2;
            // 
            // edtOrtX
            // 
            this.edtOrtX.Location = new System.Drawing.Point(191, 124);
            this.edtOrtX.Name = "edtOrtX";
            this.edtOrtX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtOrtX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtOrtX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrtX.Properties.Appearance.Options.UseBackColor = true;
            this.edtOrtX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtOrtX.Properties.Appearance.Options.UseFont = true;
            this.edtOrtX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtOrtX.Properties.Name = "editOrtX.Properties";
            this.edtOrtX.Size = new System.Drawing.Size(187, 24);
            this.edtOrtX.TabIndex = 11;
            // 
            // edtPLZX
            // 
            this.edtPLZX.Location = new System.Drawing.Point(136, 124);
            this.edtPLZX.Name = "edtPLZX";
            this.edtPLZX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPLZX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPLZX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPLZX.Properties.Appearance.Options.UseBackColor = true;
            this.edtPLZX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPLZX.Properties.Appearance.Options.UseFont = true;
            this.edtPLZX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPLZX.Properties.Name = "editPLZX.Properties";
            this.edtPLZX.Size = new System.Drawing.Size(56, 24);
            this.edtPLZX.TabIndex = 10;
            // 
            // edtNameX
            // 
            this.edtNameX.Location = new System.Drawing.Point(136, 94);
            this.edtNameX.Name = "edtNameX";
            this.edtNameX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNameX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameX.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameX.Properties.Appearance.Options.UseFont = true;
            this.edtNameX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNameX.Properties.Name = "editNameX.Properties";
            this.edtNameX.Size = new System.Drawing.Size(242, 24);
            this.edtNameX.TabIndex = 8;
            // 
            // lblAnzDatensaetze
            // 
            this.lblAnzDatensaetze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAnzDatensaetze.BackColor = System.Drawing.Color.Transparent;
            this.lblAnzDatensaetze.Location = new System.Drawing.Point(896, 268);
            this.lblAnzDatensaetze.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.lblAnzDatensaetze.Name = "lblAnzDatensaetze";
            this.lblAnzDatensaetze.Size = new System.Drawing.Size(138, 16);
            this.lblAnzDatensaetze.TabIndex = 570;
            this.lblAnzDatensaetze.Text = "Anzahl Datensätze:";
            this.lblAnzDatensaetze.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblAnzDatensaetze.UseCompatibleTextRendering = true;
            // 
            // lblRowCount
            // 
            this.lblRowCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRowCount.Location = new System.Drawing.Point(1037, 268);
            this.lblRowCount.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Size = new System.Drawing.Size(38, 16);
            this.lblRowCount.TabIndex = 571;
            this.lblRowCount.Text = "0";
            this.lblRowCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblRowCount.UseCompatibleTextRendering = true;
            // 
            // qryBaAdresse
            // 
            this.qryBaAdresse.CanUpdate = true;
            this.qryBaAdresse.HostControl = this;
            this.qryBaAdresse.MasterQuery = this.qryBaInstitution;
            this.qryBaAdresse.SelectStatement = resources.GetString("qryBaAdresse.SelectStatement");
            this.qryBaAdresse.TableName = "BaAdresse";
            this.qryBaAdresse.AfterFill += new System.EventHandler(this.qryBaAdresse_AfterFill);
            this.qryBaAdresse.AfterInsert += new System.EventHandler(this.qryBaAdresse_AfterInsert);
            this.qryBaAdresse.BeforePost += new System.EventHandler(this.qryBaAdresse_BeforePost);
            // 
            // qryBaInstitutionKontakt
            // 
            this.qryBaInstitutionKontakt.CanDelete = true;
            this.qryBaInstitutionKontakt.CanInsert = true;
            this.qryBaInstitutionKontakt.CanUpdate = true;
            this.qryBaInstitutionKontakt.HostControl = this;
            this.qryBaInstitutionKontakt.MasterQuery = this.qryBaInstitution;
            this.qryBaInstitutionKontakt.SelectStatement = resources.GetString("qryBaInstitutionKontakt.SelectStatement");
            this.qryBaInstitutionKontakt.TableName = "BaInstitutionKontakt";
            this.qryBaInstitutionKontakt.AfterInsert += new System.EventHandler(this.qryBaInstitutionKontakt_AfterInsert);
            this.qryBaInstitutionKontakt.BeforeDeleteQuestion += new System.EventHandler(this.qryBaInstitutionKontakt_BeforeDeleteQuestion);
            this.qryBaInstitutionKontakt.BeforePost += new System.EventHandler(this.qryBaInstitutionKontakt_BeforePost);
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
            // qryInstTypen
            // 
            this.qryInstTypen.HostControl = this.pklInstTypen;
            this.qryInstTypen.SelectStatement = resources.GetString("qryInstTypen.SelectStatement");
            // 
            // pklInstTypen
            // 
            this.pklInstTypen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.pklInstTypen.ColumnIDName = null;
            this.pklInstTypen.DataSourceOfSourceGrid = null;
            this.pklInstTypen.DataSourceOfTargetGrid = null;
            this.pklInstTypen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pklInstTypen.FilterColumnName = null;
            this.pklInstTypen.Location = new System.Drawing.Point(0, 0);
            this.pklInstTypen.Name = "pklInstTypen";
            this.pklInstTypen.Size = new System.Drawing.Size(968, 294);
            this.pklInstTypen.TabIndex = 0;
            this.pklInstTypen.TargetFilterVisible = false;
            // 
            // qryZugeordneteInstTypen
            // 
            this.qryZugeordneteInstTypen.HostControl = this.pklInstTypen;
            this.qryZugeordneteInstTypen.MasterQuery = this.qryBaInstitution;
            this.qryZugeordneteInstTypen.SelectStatement = resources.GetString("qryZugeordneteInstTypen.SelectStatement");
            this.qryZugeordneteInstTypen.TableName = "BaInstitution_BaInstitutionTyp";
            this.qryZugeordneteInstTypen.AfterInsert += new System.EventHandler(this.qryZugeordneteInstTypen_AfterInsert);
            this.qryZugeordneteInstTypen.BeforePost += new System.EventHandler(this.qryZugeordneteInstTypen_BeforePost);
            // 
            // qrySucheInstTypen
            // 
            this.qrySucheInstTypen.HostControl = this.pklSucheInstTypen;
            this.qrySucheInstTypen.SelectStatement = resources.GetString("qrySucheInstTypen.SelectStatement");
            // 
            // qrySucheSelectedInstTypen
            // 
            this.qrySucheSelectedInstTypen.AutoApplyUserRights = false;
            this.qrySucheSelectedInstTypen.BatchUpdate = true;
            this.qrySucheSelectedInstTypen.CanDelete = true;
            this.qrySucheSelectedInstTypen.CanInsert = true;
            this.qrySucheSelectedInstTypen.CanUpdate = true;
            this.qrySucheSelectedInstTypen.DeleteQuestion = "";
            this.qrySucheSelectedInstTypen.HostControl = this.pklSucheInstTypen;
            // 
            // tbpTypisierung
            // 
            this.tbpTypisierung.AutoScroll = true;
            this.tbpTypisierung.AutoScrollMinSize = new System.Drawing.Size(450, 150);
            this.tbpTypisierung.Controls.Add(this.panTypen);
            this.tbpTypisierung.Location = new System.Drawing.Point(6, 32);
            this.tbpTypisierung.Name = "tbpTypisierung";
            this.tbpTypisierung.Size = new System.Drawing.Size(1074, 316);
            this.tbpTypisierung.TabIndex = 3;
            this.tbpTypisierung.Title = "Typisierung";
            // 
            // panTypen
            // 
            this.panTypen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panTypen.Controls.Add(this.pklInstTypen);
            this.panTypen.Location = new System.Drawing.Point(12, 9);
            this.panTypen.Margin = new System.Windows.Forms.Padding(9);
            this.panTypen.MaximumSize = new System.Drawing.Size(968, 750);
            this.panTypen.MinimumSize = new System.Drawing.Size(450, 100);
            this.panTypen.Name = "panTypen";
            this.panTypen.Size = new System.Drawing.Size(968, 294);
            this.panTypen.TabIndex = 0;
            // 
            // tbpZahlweg
            // 
            this.tbpZahlweg.AutoScroll = true;
            this.tbpZahlweg.AutoScrollMinSize = new System.Drawing.Size(700, 305);
            this.tbpZahlweg.Controls.Add(this.ctlZahlungsweg);
            this.tbpZahlweg.Location = new System.Drawing.Point(6, 32);
            this.tbpZahlweg.Name = "tbpZahlweg";
            this.tbpZahlweg.Size = new System.Drawing.Size(1074, 316);
            this.tbpZahlweg.TabIndex = 1;
            this.tbpZahlweg.Title = "Zahlungsverbindung";
            // 
            // ctlZahlungsweg
            // 
            this.ctlZahlungsweg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlZahlungsweg.BaInstitutionID = 0;
            this.ctlZahlungsweg.BaPersonID = 1;
            this.ctlZahlungsweg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlZahlungsweg.Location = new System.Drawing.Point(0, 0);
            this.ctlZahlungsweg.Name = "ctlZahlungsweg";
            this.ctlZahlungsweg.Size = new System.Drawing.Size(1074, 316);
            this.ctlZahlungsweg.TabIndex = 1;
            // 
            // tbpKontakt
            // 
            this.tbpKontakt.AutoScroll = true;
            this.tbpKontakt.AutoScrollMinSize = new System.Drawing.Size(980, 0);
            this.tbpKontakt.Controls.Add(this.grdKontakt);
            this.tbpKontakt.Controls.Add(this.panDetailsKontakt);
            this.tbpKontakt.Location = new System.Drawing.Point(6, 32);
            this.tbpKontakt.Name = "tbpKontakt";
            this.tbpKontakt.Size = new System.Drawing.Size(1074, 316);
            this.tbpKontakt.TabIndex = 2;
            this.tbpKontakt.Title = "Kontakt";
            // 
            // grdKontakt
            // 
            this.grdKontakt.DataSource = this.qryBaInstitutionKontakt;
            this.grdKontakt.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdKontakt.EmbeddedNavigator.Name = "gridList.EmbeddedNavigator";
            this.grdKontakt.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdKontakt.Location = new System.Drawing.Point(0, 0);
            this.grdKontakt.MainView = this.grvKontakt;
            this.grdKontakt.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.grdKontakt.Name = "grdKontakt";
            this.grdKontakt.Size = new System.Drawing.Size(1074, 116);
            this.grdKontakt.TabIndex = 0;
            this.grdKontakt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKontakt});
            // 
            // grvKontakt
            // 
            this.grvKontakt.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvKontakt.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontakt.Appearance.Empty.Options.UseBackColor = true;
            this.grvKontakt.Appearance.Empty.Options.UseFont = true;
            this.grvKontakt.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontakt.Appearance.EvenRow.Options.UseFont = true;
            this.grvKontakt.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKontakt.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontakt.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKontakt.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKontakt.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKontakt.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKontakt.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKontakt.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontakt.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvKontakt.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKontakt.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKontakt.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKontakt.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKontakt.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKontakt.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKontakt.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKontakt.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKontakt.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKontakt.Appearance.GroupRow.Options.UseFont = true;
            this.grvKontakt.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKontakt.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKontakt.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKontakt.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKontakt.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKontakt.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKontakt.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKontakt.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvKontakt.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontakt.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKontakt.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKontakt.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKontakt.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKontakt.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvKontakt.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvKontakt.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontakt.Appearance.OddRow.Options.UseFont = true;
            this.grvKontakt.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKontakt.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontakt.Appearance.Row.Options.UseBackColor = true;
            this.grvKontakt.Appearance.Row.Options.UseFont = true;
            this.grvKontakt.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontakt.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKontakt.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvKontakt.Appearance.VertLine.Options.UseBackColor = true;
            this.grvKontakt.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKontakt.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKontaktName,
            this.colKontaktVorname,
            this.colKontaktTelefon,
            this.colKontaktEMail,
            this.colKontaktAktiv});
            this.grvKontakt.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvKontakt.GridControl = this.grdKontakt;
            this.grvKontakt.Name = "grvKontakt";
            this.grvKontakt.OptionsBehavior.Editable = false;
            this.grvKontakt.OptionsCustomization.AllowFilter = false;
            this.grvKontakt.OptionsCustomization.AllowGroup = false;
            this.grvKontakt.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKontakt.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKontakt.OptionsNavigation.UseTabKey = false;
            this.grvKontakt.OptionsView.ColumnAutoWidth = false;
            this.grvKontakt.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvKontakt.OptionsView.ShowGroupPanel = false;
            this.grvKontakt.OptionsView.ShowIndicator = false;
            // 
            // colKontaktName
            // 
            this.colKontaktName.Caption = "Name";
            this.colKontaktName.Name = "colKontaktName";
            this.colKontaktName.Visible = true;
            this.colKontaktName.VisibleIndex = 0;
            this.colKontaktName.Width = 200;
            // 
            // colKontaktVorname
            // 
            this.colKontaktVorname.Caption = "Vorname";
            this.colKontaktVorname.Name = "colKontaktVorname";
            this.colKontaktVorname.Visible = true;
            this.colKontaktVorname.VisibleIndex = 1;
            this.colKontaktVorname.Width = 200;
            // 
            // colKontaktTelefon
            // 
            this.colKontaktTelefon.Caption = "Telefon";
            this.colKontaktTelefon.Name = "colKontaktTelefon";
            this.colKontaktTelefon.Visible = true;
            this.colKontaktTelefon.VisibleIndex = 2;
            this.colKontaktTelefon.Width = 200;
            // 
            // colKontaktEMail
            // 
            this.colKontaktEMail.Caption = "E-Mail";
            this.colKontaktEMail.Name = "colKontaktEMail";
            this.colKontaktEMail.Visible = true;
            this.colKontaktEMail.VisibleIndex = 3;
            this.colKontaktEMail.Width = 200;
            // 
            // colKontaktAktiv
            // 
            this.colKontaktAktiv.Caption = "Aktiv";
            this.colKontaktAktiv.FieldName = "Aktiv";
            this.colKontaktAktiv.Name = "colKontaktAktiv";
            this.colKontaktAktiv.Visible = true;
            this.colKontaktAktiv.VisibleIndex = 4;
            this.colKontaktAktiv.Width = 60;
            // 
            // panDetailsKontakt
            // 
            this.panDetailsKontakt.Controls.Add(this.lblKontaktPersonName);
            this.panDetailsKontakt.Controls.Add(this.chkKontaktAktiv);
            this.panDetailsKontakt.Controls.Add(this.edtKontaktName);
            this.panDetailsKontakt.Controls.Add(this.edtKontaktGeschlecht);
            this.panDetailsKontakt.Controls.Add(this.edtKontaktVorname);
            this.panDetailsKontakt.Controls.Add(this.chkKontaktManuelleAnrede);
            this.panDetailsKontakt.Controls.Add(this.edtKontaktTelefon);
            this.panDetailsKontakt.Controls.Add(this.edtKontaktBriefanrede);
            this.panDetailsKontakt.Controls.Add(this.edtKontaktFax);
            this.panDetailsKontakt.Controls.Add(this.edtKontaktTitel);
            this.panDetailsKontakt.Controls.Add(this.edtKontaktEMail);
            this.panDetailsKontakt.Controls.Add(this.lblKontaktAnrede);
            this.panDetailsKontakt.Controls.Add(this.edtKontaktBemerkung);
            this.panDetailsKontakt.Controls.Add(this.lblKontaktTitel);
            this.panDetailsKontakt.Controls.Add(this.lblKontaktPersonVorname);
            this.panDetailsKontakt.Controls.Add(this.lblKontaktBriefanrede);
            this.panDetailsKontakt.Controls.Add(this.lblKontaktGeschlecht);
            this.panDetailsKontakt.Controls.Add(this.edtKontaktAnrede);
            this.panDetailsKontakt.Controls.Add(this.lblKontaktEMail);
            this.panDetailsKontakt.Controls.Add(this.lblKontaktSprache);
            this.panDetailsKontakt.Controls.Add(this.lblKontaktFax);
            this.panDetailsKontakt.Controls.Add(this.edtKontaktSprachCode);
            this.panDetailsKontakt.Controls.Add(this.lblKontaktTelefon);
            this.panDetailsKontakt.Controls.Add(this.lblKontaktBemerkung);
            this.panDetailsKontakt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panDetailsKontakt.Location = new System.Drawing.Point(0, 116);
            this.panDetailsKontakt.Name = "panDetailsKontakt";
            this.panDetailsKontakt.Size = new System.Drawing.Size(1074, 200);
            this.panDetailsKontakt.TabIndex = 1;
            // 
            // lblKontaktPersonName
            // 
            this.lblKontaktPersonName.Location = new System.Drawing.Point(12, 30);
            this.lblKontaktPersonName.Name = "lblKontaktPersonName";
            this.lblKontaktPersonName.Size = new System.Drawing.Size(70, 24);
            this.lblKontaktPersonName.TabIndex = 0;
            this.lblKontaktPersonName.Text = "Name";
            this.lblKontaktPersonName.UseCompatibleTextRendering = true;
            // 
            // chkKontaktAktiv
            // 
            this.chkKontaktAktiv.EditValue = false;
            this.chkKontaktAktiv.Location = new System.Drawing.Point(901, 6);
            this.chkKontaktAktiv.Name = "chkKontaktAktiv";
            this.chkKontaktAktiv.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkKontaktAktiv.Properties.Appearance.Options.UseBackColor = true;
            this.chkKontaktAktiv.Properties.Caption = "Aktiv";
            this.chkKontaktAktiv.Size = new System.Drawing.Size(80, 19);
            this.chkKontaktAktiv.TabIndex = 23;
            // 
            // edtKontaktName
            // 
            this.edtKontaktName.DataMember = "Name";
            this.edtKontaktName.DataSource = this.qryBaInstitutionKontakt;
            this.edtKontaktName.Location = new System.Drawing.Point(86, 30);
            this.edtKontaktName.Name = "edtKontaktName";
            this.edtKontaktName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktName.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktName.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontaktName.Properties.Name = "editName.Properties";
            this.edtKontaktName.Size = new System.Drawing.Size(238, 24);
            this.edtKontaktName.TabIndex = 1;
            // 
            // edtKontaktGeschlecht
            // 
            this.edtKontaktGeschlecht.Location = new System.Drawing.Point(86, 83);
            this.edtKontaktGeschlecht.LOVName = "Geschlecht";
            this.edtKontaktGeschlecht.Name = "edtKontaktGeschlecht";
            this.edtKontaktGeschlecht.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktGeschlecht.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktGeschlecht.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktGeschlecht.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktGeschlecht.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktGeschlecht.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktGeschlecht.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKontaktGeschlecht.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktGeschlecht.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKontaktGeschlecht.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKontaktGeschlecht.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtKontaktGeschlecht.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtKontaktGeschlecht.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKontaktGeschlecht.Properties.NullText = "";
            this.edtKontaktGeschlecht.Properties.ShowFooter = false;
            this.edtKontaktGeschlecht.Properties.ShowHeader = false;
            this.edtKontaktGeschlecht.Size = new System.Drawing.Size(238, 24);
            this.edtKontaktGeschlecht.TabIndex = 5;
            this.edtKontaktGeschlecht.EditValueChanged += new System.EventHandler(this.edtKontaktGeschlecht_EditValueChanged);
            // 
            // edtKontaktVorname
            // 
            this.edtKontaktVorname.DataMember = "Vorname";
            this.edtKontaktVorname.DataSource = this.qryBaInstitutionKontakt;
            this.edtKontaktVorname.Location = new System.Drawing.Point(86, 53);
            this.edtKontaktVorname.Name = "edtKontaktVorname";
            this.edtKontaktVorname.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktVorname.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontaktVorname.Properties.Name = "editName.Properties";
            this.edtKontaktVorname.Size = new System.Drawing.Size(238, 24);
            this.edtKontaktVorname.TabIndex = 3;
            // 
            // chkKontaktManuelleAnrede
            // 
            this.chkKontaktManuelleAnrede.EditValue = false;
            this.chkKontaktManuelleAnrede.Location = new System.Drawing.Point(581, 51);
            this.chkKontaktManuelleAnrede.Name = "chkKontaktManuelleAnrede";
            this.chkKontaktManuelleAnrede.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkKontaktManuelleAnrede.Properties.Appearance.Options.UseBackColor = true;
            this.chkKontaktManuelleAnrede.Properties.Caption = "Manuelle Anrede";
            this.chkKontaktManuelleAnrede.Size = new System.Drawing.Size(119, 19);
            this.chkKontaktManuelleAnrede.TabIndex = 8;
            this.chkKontaktManuelleAnrede.CheckedChanged += new System.EventHandler(this.chkKontaktManuelleAnrede_CheckedChanged);
            // 
            // edtKontaktTelefon
            // 
            this.edtKontaktTelefon.DataMember = "Telefon";
            this.edtKontaktTelefon.DataSource = this.qryBaInstitutionKontakt;
            this.edtKontaktTelefon.Location = new System.Drawing.Point(786, 30);
            this.edtKontaktTelefon.Name = "edtKontaktTelefon";
            this.edtKontaktTelefon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktTelefon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktTelefon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktTelefon.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktTelefon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktTelefon.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktTelefon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontaktTelefon.Properties.Name = "kissTextEdit20.Properties";
            this.edtKontaktTelefon.Size = new System.Drawing.Size(195, 24);
            this.edtKontaktTelefon.TabIndex = 14;
            // 
            // edtKontaktBriefanrede
            // 
            this.edtKontaktBriefanrede.Location = new System.Drawing.Point(427, 76);
            this.edtKontaktBriefanrede.Name = "edtKontaktBriefanrede";
            this.edtKontaktBriefanrede.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktBriefanrede.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktBriefanrede.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktBriefanrede.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktBriefanrede.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktBriefanrede.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktBriefanrede.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontaktBriefanrede.Size = new System.Drawing.Size(273, 24);
            this.edtKontaktBriefanrede.TabIndex = 12;
            // 
            // edtKontaktFax
            // 
            this.edtKontaktFax.DataMember = "Fax";
            this.edtKontaktFax.DataSource = this.qryBaInstitutionKontakt;
            this.edtKontaktFax.Location = new System.Drawing.Point(786, 53);
            this.edtKontaktFax.Name = "edtKontaktFax";
            this.edtKontaktFax.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktFax.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktFax.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktFax.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktFax.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktFax.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktFax.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontaktFax.Properties.Name = "kissTextEdit19.Properties";
            this.edtKontaktFax.Size = new System.Drawing.Size(195, 24);
            this.edtKontaktFax.TabIndex = 16;
            // 
            // edtKontaktTitel
            // 
            this.edtKontaktTitel.Location = new System.Drawing.Point(427, 30);
            this.edtKontaktTitel.Name = "edtKontaktTitel";
            this.edtKontaktTitel.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktTitel.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktTitel.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktTitel.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktTitel.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktTitel.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktTitel.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontaktTitel.Size = new System.Drawing.Size(114, 24);
            this.edtKontaktTitel.TabIndex = 7;
            // 
            // edtKontaktEMail
            // 
            this.edtKontaktEMail.DataMember = "EMail";
            this.edtKontaktEMail.DataSource = this.qryBaInstitutionKontakt;
            this.edtKontaktEMail.Location = new System.Drawing.Point(786, 76);
            this.edtKontaktEMail.Name = "edtKontaktEMail";
            this.edtKontaktEMail.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktEMail.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktEMail.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktEMail.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktEMail.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktEMail.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktEMail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontaktEMail.Properties.Name = "kissTextEdit18.Properties";
            this.edtKontaktEMail.Size = new System.Drawing.Size(195, 24);
            this.edtKontaktEMail.TabIndex = 18;
            // 
            // lblKontaktAnrede
            // 
            this.lblKontaktAnrede.Location = new System.Drawing.Point(358, 53);
            this.lblKontaktAnrede.Name = "lblKontaktAnrede";
            this.lblKontaktAnrede.Size = new System.Drawing.Size(63, 24);
            this.lblKontaktAnrede.TabIndex = 9;
            this.lblKontaktAnrede.Text = "Anrede";
            this.lblKontaktAnrede.UseCompatibleTextRendering = true;
            // 
            // edtKontaktBemerkung
            // 
            this.edtKontaktBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.edtKontaktBemerkung.DataMember = "Bemerkung";
            this.edtKontaktBemerkung.DataSource = this.qryBaInstitutionKontakt;
            this.edtKontaktBemerkung.Location = new System.Drawing.Point(86, 136);
            this.edtKontaktBemerkung.Margin = new System.Windows.Forms.Padding(3, 3, 9, 9);
            this.edtKontaktBemerkung.Name = "edtKontaktBemerkung";
            this.edtKontaktBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontaktBemerkung.Size = new System.Drawing.Size(895, 55);
            this.edtKontaktBemerkung.TabIndex = 22;
            // 
            // lblKontaktTitel
            // 
            this.lblKontaktTitel.Location = new System.Drawing.Point(358, 30);
            this.lblKontaktTitel.Name = "lblKontaktTitel";
            this.lblKontaktTitel.Size = new System.Drawing.Size(63, 24);
            this.lblKontaktTitel.TabIndex = 6;
            this.lblKontaktTitel.Text = "Titel";
            this.lblKontaktTitel.UseCompatibleTextRendering = true;
            // 
            // lblKontaktPersonVorname
            // 
            this.lblKontaktPersonVorname.Location = new System.Drawing.Point(12, 53);
            this.lblKontaktPersonVorname.Name = "lblKontaktPersonVorname";
            this.lblKontaktPersonVorname.Size = new System.Drawing.Size(70, 24);
            this.lblKontaktPersonVorname.TabIndex = 2;
            this.lblKontaktPersonVorname.Text = "Vorname";
            this.lblKontaktPersonVorname.UseCompatibleTextRendering = true;
            // 
            // lblKontaktBriefanrede
            // 
            this.lblKontaktBriefanrede.Location = new System.Drawing.Point(358, 76);
            this.lblKontaktBriefanrede.Name = "lblKontaktBriefanrede";
            this.lblKontaktBriefanrede.Size = new System.Drawing.Size(63, 24);
            this.lblKontaktBriefanrede.TabIndex = 11;
            this.lblKontaktBriefanrede.Text = "Briefanrede";
            this.lblKontaktBriefanrede.UseCompatibleTextRendering = true;
            // 
            // lblKontaktGeschlecht
            // 
            this.lblKontaktGeschlecht.Location = new System.Drawing.Point(12, 83);
            this.lblKontaktGeschlecht.Name = "lblKontaktGeschlecht";
            this.lblKontaktGeschlecht.Size = new System.Drawing.Size(70, 24);
            this.lblKontaktGeschlecht.TabIndex = 4;
            this.lblKontaktGeschlecht.Text = "Geschlecht";
            this.lblKontaktGeschlecht.UseCompatibleTextRendering = true;
            // 
            // edtKontaktAnrede
            // 
            this.edtKontaktAnrede.DataSource = this.qryBaInstitution;
            this.edtKontaktAnrede.Location = new System.Drawing.Point(427, 53);
            this.edtKontaktAnrede.Name = "edtKontaktAnrede";
            this.edtKontaktAnrede.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktAnrede.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktAnrede.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktAnrede.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktAnrede.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktAnrede.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktAnrede.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontaktAnrede.Properties.Name = "kissTextEdit1.Properties";
            this.edtKontaktAnrede.Size = new System.Drawing.Size(114, 24);
            this.edtKontaktAnrede.TabIndex = 10;
            // 
            // lblKontaktEMail
            // 
            this.lblKontaktEMail.Location = new System.Drawing.Point(727, 76);
            this.lblKontaktEMail.Name = "lblKontaktEMail";
            this.lblKontaktEMail.Size = new System.Drawing.Size(53, 24);
            this.lblKontaktEMail.TabIndex = 17;
            this.lblKontaktEMail.Text = "E-Mail";
            this.lblKontaktEMail.UseCompatibleTextRendering = true;
            // 
            // lblKontaktSprache
            // 
            this.lblKontaktSprache.Location = new System.Drawing.Point(727, 106);
            this.lblKontaktSprache.Name = "lblKontaktSprache";
            this.lblKontaktSprache.Size = new System.Drawing.Size(52, 24);
            this.lblKontaktSprache.TabIndex = 19;
            this.lblKontaktSprache.Text = "Sprache";
            this.lblKontaktSprache.UseCompatibleTextRendering = true;
            // 
            // lblKontaktFax
            // 
            this.lblKontaktFax.Location = new System.Drawing.Point(727, 53);
            this.lblKontaktFax.Name = "lblKontaktFax";
            this.lblKontaktFax.Size = new System.Drawing.Size(53, 24);
            this.lblKontaktFax.TabIndex = 15;
            this.lblKontaktFax.Text = "Fax";
            this.lblKontaktFax.UseCompatibleTextRendering = true;
            // 
            // edtKontaktSprachCode
            // 
            this.edtKontaktSprachCode.DataMember = "SprachCode";
            this.edtKontaktSprachCode.DataSource = this.qryBaInstitutionKontakt;
            this.edtKontaktSprachCode.Location = new System.Drawing.Point(786, 106);
            this.edtKontaktSprachCode.LOVName = "Sprache";
            this.edtKontaktSprachCode.Name = "edtKontaktSprachCode";
            this.edtKontaktSprachCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktSprachCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktSprachCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktSprachCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktSprachCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktSprachCode.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktSprachCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKontaktSprachCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktSprachCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKontaktSprachCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKontaktSprachCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtKontaktSprachCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtKontaktSprachCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKontaktSprachCode.Properties.Name = "kissLookUpEdit6.Properties";
            this.edtKontaktSprachCode.Properties.NullText = "";
            this.edtKontaktSprachCode.Properties.ShowFooter = false;
            this.edtKontaktSprachCode.Properties.ShowHeader = false;
            this.edtKontaktSprachCode.Size = new System.Drawing.Size(195, 24);
            this.edtKontaktSprachCode.TabIndex = 20;
            // 
            // lblKontaktTelefon
            // 
            this.lblKontaktTelefon.Location = new System.Drawing.Point(727, 30);
            this.lblKontaktTelefon.Name = "lblKontaktTelefon";
            this.lblKontaktTelefon.Size = new System.Drawing.Size(53, 24);
            this.lblKontaktTelefon.TabIndex = 13;
            this.lblKontaktTelefon.Text = "Telefon";
            this.lblKontaktTelefon.UseCompatibleTextRendering = true;
            // 
            // lblKontaktBemerkung
            // 
            this.lblKontaktBemerkung.Location = new System.Drawing.Point(12, 136);
            this.lblKontaktBemerkung.Name = "lblKontaktBemerkung";
            this.lblKontaktBemerkung.Size = new System.Drawing.Size(70, 24);
            this.lblKontaktBemerkung.TabIndex = 21;
            this.lblKontaktBemerkung.Text = "Bemerkung";
            this.lblKontaktBemerkung.UseCompatibleTextRendering = true;
            // 
            // tbpInstitution
            // 
            this.tbpInstitution.Controls.Add(this.panDetails);
            this.tbpInstitution.Location = new System.Drawing.Point(6, 32);
            this.tbpInstitution.Name = "tbpInstitution";
            this.tbpInstitution.Size = new System.Drawing.Size(1074, 316);
            this.tbpInstitution.TabIndex = 0;
            this.tbpInstitution.Title = "Institution";
            // 
            // panDetails
            // 
            this.panDetails.AutoScroll = true;
            this.panDetails.AutoScrollMinSize = new System.Drawing.Size(980, 300);
            this.panDetails.Controls.Add(this.edtVersichertennummer);
            this.panDetails.Controls.Add(this.edtGeburtsdatum);
            this.panDetails.Controls.Add(this.lblVersichertennummer);
            this.panDetails.Controls.Add(this.lblGeburtsdatum);
            this.panDetails.Controls.Add(this.edtPLZOrt);
            this.panDetails.Controls.Add(this.chkKeinSerienbrief);
            this.panDetails.Controls.Add(this.edtGeschlecht);
            this.panDetails.Controls.Add(this.edtVorname);
            this.panDetails.Controls.Add(this.chkManuelleAnrede);
            this.panDetails.Controls.Add(this.edtInstName);
            this.panDetails.Controls.Add(this.edtBemerkung);
            this.panDetails.Controls.Add(this.edtBriefanrede);
            this.panDetails.Controls.Add(this.edtTitel);
            this.panDetails.Controls.Add(this.edtAbteilung);
            this.panDetails.Controls.Add(this.lblAbteilung);
            this.panDetails.Controls.Add(this.chkPostfachOhneNr);
            this.panDetails.Controls.Add(this.lblLand);
            this.panDetails.Controls.Add(this.lblBezirk);
            this.panDetails.Controls.Add(this.lblPLZOrtKt);
            this.panDetails.Controls.Add(this.rgrItemTyp);
            this.panDetails.Controls.Add(this.edtKreditor);
            this.panDetails.Controls.Add(this.edtDebitor);
            this.panDetails.Controls.Add(this.lblInstNr);
            this.panDetails.Controls.Add(this.edtInstitutionNr);
            this.panDetails.Controls.Add(this.lblHomepage);
            this.panDetails.Controls.Add(this.lblAnrede);
            this.panDetails.Controls.Add(this.lblVorname);
            this.panDetails.Controls.Add(this.lblName);
            this.panDetails.Controls.Add(this.lblBemerkung);
            this.panDetails.Controls.Add(this.lblSprachCode);
            this.panDetails.Controls.Add(this.lblTitel);
            this.panDetails.Controls.Add(this.lblBriefanrede);
            this.panDetails.Controls.Add(this.lblGeschlecht);
            this.panDetails.Controls.Add(this.kissLabel2);
            this.panDetails.Controls.Add(this.kissLabel1);
            this.panDetails.Controls.Add(this.lblTelefon3);
            this.panDetails.Controls.Add(this.lblFax);
            this.panDetails.Controls.Add(this.lblEMail);
            this.panDetails.Controls.Add(this.lblZusatz);
            this.panDetails.Controls.Add(this.lblPostfach);
            this.panDetails.Controls.Add(this.lblStrasseNr);
            this.panDetails.Controls.Add(this.btnDatenblatt);
            this.panDetails.Controls.Add(this.edtSprachCode);
            this.panDetails.Controls.Add(this.edtHomepage);
            this.panDetails.Controls.Add(this.edtEMail);
            this.panDetails.Controls.Add(this.edtFax);
            this.panDetails.Controls.Add(this.edtTelefon1);
            this.panDetails.Controls.Add(this.edtTelefon2);
            this.panDetails.Controls.Add(this.edtTelefon3);
            this.panDetails.Controls.Add(this.edtAktiv);
            this.panDetails.Controls.Add(this.edtPostfach);
            this.panDetails.Controls.Add(this.edtHausNr);
            this.panDetails.Controls.Add(this.edtStrasse);
            this.panDetails.Controls.Add(this.edtAdressZusatz);
            this.panDetails.Controls.Add(this.edtPersonName);
            this.panDetails.Controls.Add(this.edtAnrede);
            this.panDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panDetails.Location = new System.Drawing.Point(0, 0);
            this.panDetails.Name = "panDetails";
            this.panDetails.Size = new System.Drawing.Size(1074, 316);
            this.panDetails.TabIndex = 0;
            // 
            // edtVersichertennummer
            // 
            this.edtVersichertennummer.Location = new System.Drawing.Point(788, 83);
            this.edtVersichertennummer.Name = "edtVersichertennummer";
            this.edtVersichertennummer.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVersichertennummer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVersichertennummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVersichertennummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVersichertennummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtVersichertennummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVersichertennummer.Properties.Appearance.Options.UseFont = true;
            this.edtVersichertennummer.Properties.Appearance.Options.UseTextOptions = true;
            this.edtVersichertennummer.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.edtVersichertennummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVersichertennummer.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVersichertennummer.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None);
            this.edtVersichertennummer.Properties.DisplayFormat.FormatString = "000\\.0000\\.0000\\.00";
            this.edtVersichertennummer.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtVersichertennummer.Properties.EditFormat.FormatString = "000\\.0000\\.0000\\.00";
            this.edtVersichertennummer.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtVersichertennummer.Properties.Mask.EditMask = "000\\.0000\\.0000\\.00";
            this.edtVersichertennummer.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.edtVersichertennummer.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.edtVersichertennummer.Properties.MaxLength = 13;
            this.edtVersichertennummer.Properties.Precision = 0;
            this.edtVersichertennummer.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.edtVersichertennummer.Size = new System.Drawing.Size(150, 24);
            this.edtVersichertennummer.TabIndex = 22;
            // 
            // edtGeburtsdatum
            // 
            this.edtGeburtsdatum.EditValue = null;
            this.edtGeburtsdatum.Location = new System.Drawing.Point(788, 53);
            this.edtGeburtsdatum.Name = "edtGeburtsdatum";
            this.edtGeburtsdatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGeburtsdatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGeburtsdatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeburtsdatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeburtsdatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeburtsdatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeburtsdatum.Properties.Appearance.Options.UseFont = true;
            this.edtGeburtsdatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtGeburtsdatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGeburtsdatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtGeburtsdatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeburtsdatum.Properties.ShowToday = false;
            this.edtGeburtsdatum.Size = new System.Drawing.Size(100, 24);
            this.edtGeburtsdatum.TabIndex = 21;
            // 
            // lblVersichertennummer
            // 
            this.lblVersichertennummer.Location = new System.Drawing.Point(698, 83);
            this.lblVersichertennummer.Name = "lblVersichertennummer";
            this.lblVersichertennummer.Size = new System.Drawing.Size(84, 24);
            this.lblVersichertennummer.TabIndex = 592;
            this.lblVersichertennummer.Text = "Versichertennr.";
            // 
            // lblGeburtsdatum
            // 
            this.lblGeburtsdatum.Location = new System.Drawing.Point(698, 53);
            this.lblGeburtsdatum.Name = "lblGeburtsdatum";
            this.lblGeburtsdatum.Size = new System.Drawing.Size(84, 24);
            this.lblGeburtsdatum.TabIndex = 591;
            this.lblGeburtsdatum.Text = "Geburtsdatum";
            // 
            // edtPLZOrt
            // 
            this.edtPLZOrt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPLZOrt.DataMember = "OrtschaftCode";
            this.edtPLZOrt.DataMemberBaGemeindeID = null;
            this.edtPLZOrt.DataSource = this.qryBaAdresse;
            this.edtPLZOrt.Location = new System.Drawing.Point(94, 182);
            this.edtPLZOrt.Name = "edtPLZOrt";
            this.edtPLZOrt.ShowBezirk = true;
            this.edtPLZOrt.Size = new System.Drawing.Size(270, 70);
            this.edtPLZOrt.TabIndex = 10;
            // 
            // chkKeinSerienbrief
            // 
            this.chkKeinSerienbrief.EditValue = false;
            this.chkKeinSerienbrief.Location = new System.Drawing.Point(788, 207);
            this.chkKeinSerienbrief.Name = "chkKeinSerienbrief";
            this.chkKeinSerienbrief.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkKeinSerienbrief.Properties.Appearance.Options.UseBackColor = true;
            this.chkKeinSerienbrief.Properties.Caption = "Kein Serienbrief";
            this.chkKeinSerienbrief.Size = new System.Drawing.Size(238, 19);
            this.chkKeinSerienbrief.TabIndex = 26;
            // 
            // edtGeschlecht
            // 
            this.edtGeschlecht.Location = new System.Drawing.Point(94, 83);
            this.edtGeschlecht.LOVName = "Geschlecht";
            this.edtGeschlecht.Name = "edtGeschlecht";
            this.edtGeschlecht.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
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
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtGeschlecht.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtGeschlecht.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeschlecht.Properties.NullText = "";
            this.edtGeschlecht.Properties.ShowFooter = false;
            this.edtGeschlecht.Properties.ShowHeader = false;
            this.edtGeschlecht.Size = new System.Drawing.Size(196, 24);
            this.edtGeschlecht.TabIndex = 4;
            this.edtGeschlecht.EditValueChanged += new System.EventHandler(this.edtGeschlecht_EditValueChanged);
            // 
            // edtVorname
            // 
            this.edtVorname.Location = new System.Drawing.Point(94, 53);
            this.edtVorname.Name = "edtVorname";
            this.edtVorname.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVorname.Properties.Appearance.Options.UseFont = true;
            this.edtVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVorname.Size = new System.Drawing.Size(270, 24);
            this.edtVorname.TabIndex = 3;
            // 
            // chkManuelleAnrede
            // 
            this.chkManuelleAnrede.EditValue = false;
            this.chkManuelleAnrede.Location = new System.Drawing.Point(565, 55);
            this.chkManuelleAnrede.Name = "chkManuelleAnrede";
            this.chkManuelleAnrede.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkManuelleAnrede.Properties.Appearance.Options.UseBackColor = true;
            this.chkManuelleAnrede.Properties.Caption = "Manuelle Anrede";
            this.chkManuelleAnrede.Size = new System.Drawing.Size(115, 19);
            this.chkManuelleAnrede.TabIndex = 12;
            this.chkManuelleAnrede.CheckedChanged += new System.EventHandler(this.chkManuelleAnrede_CheckedChanged);
            // 
            // edtInstName
            // 
            this.edtInstName.DataMember = "Name";
            this.edtInstName.DataSource = this.qryBaInstitution;
            this.edtInstName.DoubleClickOpenDialog = false;
            this.edtInstName.Location = new System.Drawing.Point(94, 30);
            this.edtInstName.Name = "edtInstName";
            this.edtInstName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtInstName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtInstName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtInstName.Properties.Appearance.Options.UseBackColor = true;
            this.edtInstName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtInstName.Properties.Appearance.Options.UseFont = true;
            this.edtInstName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtInstName.Properties.LinesCount = 2;
            this.edtInstName.Size = new System.Drawing.Size(270, 47);
            this.edtInstName.TabIndex = 1;
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBemerkung.Location = new System.Drawing.Point(94, 258);
            this.edtBemerkung.Margin = new System.Windows.Forms.Padding(3, 3, 9, 9);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(912, 49);
            this.edtBemerkung.TabIndex = 29;
            // 
            // edtBriefanrede
            // 
            this.edtBriefanrede.Location = new System.Drawing.Point(449, 76);
            this.edtBriefanrede.Name = "edtBriefanrede";
            this.edtBriefanrede.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBriefanrede.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBriefanrede.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBriefanrede.Properties.Appearance.Options.UseBackColor = true;
            this.edtBriefanrede.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBriefanrede.Properties.Appearance.Options.UseFont = true;
            this.edtBriefanrede.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBriefanrede.Size = new System.Drawing.Size(231, 24);
            this.edtBriefanrede.TabIndex = 14;
            // 
            // edtTitel
            // 
            this.edtTitel.Location = new System.Drawing.Point(449, 30);
            this.edtTitel.Name = "edtTitel";
            this.edtTitel.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTitel.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTitel.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTitel.Properties.Appearance.Options.UseBackColor = true;
            this.edtTitel.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTitel.Properties.Appearance.Options.UseFont = true;
            this.edtTitel.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTitel.Size = new System.Drawing.Size(114, 24);
            this.edtTitel.TabIndex = 11;
            // 
            // edtAbteilung
            // 
            this.edtAbteilung.AllowNull = false;
            this.edtAbteilung.DataSource = this.qryBaInstitution;
            this.edtAbteilung.Location = new System.Drawing.Point(788, 173);
            this.edtAbteilung.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.edtAbteilung.Name = "edtAbteilung";
            this.edtAbteilung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAbteilung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAbteilung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbteilung.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbteilung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAbteilung.Properties.Appearance.Options.UseFont = true;
            this.edtAbteilung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAbteilung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbteilung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAbteilung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAbteilung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtAbteilung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtAbteilung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAbteilung.Properties.Name = "kissLookUpEdit6.Properties";
            this.edtAbteilung.Properties.NullText = "";
            this.edtAbteilung.Properties.ShowFooter = false;
            this.edtAbteilung.Properties.ShowHeader = false;
            this.edtAbteilung.Size = new System.Drawing.Size(218, 24);
            this.edtAbteilung.TabIndex = 25;
            // 
            // lblAbteilung
            // 
            this.lblAbteilung.Location = new System.Drawing.Point(698, 173);
            this.lblAbteilung.Name = "lblAbteilung";
            this.lblAbteilung.Size = new System.Drawing.Size(84, 24);
            this.lblAbteilung.TabIndex = 590;
            this.lblAbteilung.Text = "Abteilung";
            // 
            // chkPostfachOhneNr
            // 
            this.chkPostfachOhneNr.EditValue = false;
            this.chkPostfachOhneNr.Location = new System.Drawing.Point(297, 162);
            this.chkPostfachOhneNr.Name = "chkPostfachOhneNr";
            this.chkPostfachOhneNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkPostfachOhneNr.Properties.Appearance.Options.UseBackColor = true;
            this.chkPostfachOhneNr.Properties.Caption = "ohne Nr.";
            this.chkPostfachOhneNr.Size = new System.Drawing.Size(75, 19);
            this.chkPostfachOhneNr.TabIndex = 9;
            this.chkPostfachOhneNr.CheckedChanged += new System.EventHandler(this.chkPostfachOhneNr_CheckedChanged);
            // 
            // lblLand
            // 
            this.lblLand.Location = new System.Drawing.Point(9, 228);
            this.lblLand.Name = "lblLand";
            this.lblLand.Size = new System.Drawing.Size(79, 24);
            this.lblLand.TabIndex = 587;
            this.lblLand.Text = "Land";
            this.lblLand.UseCompatibleTextRendering = true;
            // 
            // lblBezirk
            // 
            this.lblBezirk.Location = new System.Drawing.Point(9, 205);
            this.lblBezirk.Name = "lblBezirk";
            this.lblBezirk.Size = new System.Drawing.Size(79, 24);
            this.lblBezirk.TabIndex = 585;
            this.lblBezirk.Text = "Bezirk";
            this.lblBezirk.UseCompatibleTextRendering = true;
            // 
            // lblPLZOrtKt
            // 
            this.lblPLZOrtKt.Location = new System.Drawing.Point(9, 182);
            this.lblPLZOrtKt.Name = "lblPLZOrtKt";
            this.lblPLZOrtKt.Size = new System.Drawing.Size(79, 24);
            this.lblPLZOrtKt.TabIndex = 581;
            this.lblPLZOrtKt.Text = "PLZ / Ort / Kt.";
            this.lblPLZOrtKt.UseCompatibleTextRendering = true;
            // 
            // rgrItemTyp
            // 
            this.rgrItemTyp.EditValue = null;
            this.rgrItemTyp.Location = new System.Drawing.Point(94, 2);
            this.rgrItemTyp.LookupSQL = null;
            this.rgrItemTyp.LOVFilter = null;
            this.rgrItemTyp.LOVName = null;
            this.rgrItemTyp.Name = "rgrItemTyp";
            this.rgrItemTyp.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgrItemTyp.Properties.Appearance.Options.UseBackColor = true;
            this.rgrItemTyp.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.rgrItemTyp.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.rgrItemTyp.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgrItemTyp.Size = new System.Drawing.Size(270, 25);
            this.rgrItemTyp.TabIndex = 0;
            this.rgrItemTyp.EditValueChanged += new System.EventHandler(this.rgrItemTyp_EditValueChanged);
            // 
            // edtKreditor
            // 
            this.edtKreditor.DataMember = "Kreditor";
            this.edtKreditor.DataSource = this.qryBaInstitution;
            this.edtKreditor.Location = new System.Drawing.Point(892, 232);
            this.edtKreditor.Name = "edtKreditor";
            this.edtKreditor.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKreditor.Properties.Appearance.Options.UseBackColor = true;
            this.edtKreditor.Properties.Caption = "Kreditor";
            this.edtKreditor.Size = new System.Drawing.Size(75, 19);
            this.edtKreditor.TabIndex = 28;
            // 
            // edtDebitor
            // 
            this.edtDebitor.DataMember = "Debitor";
            this.edtDebitor.DataSource = this.qryBaInstitution;
            this.edtDebitor.Location = new System.Drawing.Point(788, 232);
            this.edtDebitor.Name = "edtDebitor";
            this.edtDebitor.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtDebitor.Properties.Appearance.Options.UseBackColor = true;
            this.edtDebitor.Properties.Caption = "Debitor";
            this.edtDebitor.Size = new System.Drawing.Size(75, 19);
            this.edtDebitor.TabIndex = 27;
            // 
            // lblInstNr
            // 
            this.lblInstNr.Location = new System.Drawing.Point(698, 113);
            this.lblInstNr.Name = "lblInstNr";
            this.lblInstNr.Size = new System.Drawing.Size(84, 24);
            this.lblInstNr.TabIndex = 579;
            this.lblInstNr.Text = "Inst.-Nr.";
            // 
            // edtInstitutionNr
            // 
            this.edtInstitutionNr.DataMember = "InstitutionNr";
            this.edtInstitutionNr.DataSource = this.qryBaInstitution;
            this.edtInstitutionNr.Location = new System.Drawing.Point(788, 113);
            this.edtInstitutionNr.Name = "edtInstitutionNr";
            this.edtInstitutionNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtInstitutionNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtInstitutionNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtInstitutionNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtInstitutionNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtInstitutionNr.Properties.Appearance.Options.UseFont = true;
            this.edtInstitutionNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtInstitutionNr.Properties.Name = "kissTextEdit20.Properties";
            this.edtInstitutionNr.Size = new System.Drawing.Size(150, 24);
            this.edtInstitutionNr.TabIndex = 23;
            // 
            // lblHomepage
            // 
            this.lblHomepage.Location = new System.Drawing.Point(380, 228);
            this.lblHomepage.Name = "lblHomepage";
            this.lblHomepage.Size = new System.Drawing.Size(63, 24);
            this.lblHomepage.TabIndex = 577;
            this.lblHomepage.Text = "WWW";
            this.lblHomepage.UseCompatibleTextRendering = true;
            // 
            // lblAnrede
            // 
            this.lblAnrede.Location = new System.Drawing.Point(380, 53);
            this.lblAnrede.Name = "lblAnrede";
            this.lblAnrede.Size = new System.Drawing.Size(63, 24);
            this.lblAnrede.TabIndex = 575;
            this.lblAnrede.Text = "Anrede";
            this.lblAnrede.UseCompatibleTextRendering = true;
            // 
            // lblVorname
            // 
            this.lblVorname.Location = new System.Drawing.Point(9, 53);
            this.lblVorname.Name = "lblVorname";
            this.lblVorname.Size = new System.Drawing.Size(79, 24);
            this.lblVorname.TabIndex = 568;
            this.lblVorname.Text = "Vorname";
            this.lblVorname.UseCompatibleTextRendering = true;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(9, 30);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(79, 24);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name";
            this.lblName.UseCompatibleTextRendering = true;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.Location = new System.Drawing.Point(9, 258);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(83, 24);
            this.lblBemerkung.TabIndex = 566;
            this.lblBemerkung.Text = "Bemerkung";
            this.lblBemerkung.UseCompatibleTextRendering = true;
            // 
            // lblSprachCode
            // 
            this.lblSprachCode.Location = new System.Drawing.Point(698, 143);
            this.lblSprachCode.Name = "lblSprachCode";
            this.lblSprachCode.Size = new System.Drawing.Size(84, 24);
            this.lblSprachCode.TabIndex = 565;
            this.lblSprachCode.Text = "Sprache";
            // 
            // lblTitel
            // 
            this.lblTitel.Location = new System.Drawing.Point(380, 30);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(63, 24);
            this.lblTitel.TabIndex = 564;
            this.lblTitel.Text = "Titel";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // lblBriefanrede
            // 
            this.lblBriefanrede.Location = new System.Drawing.Point(380, 76);
            this.lblBriefanrede.Name = "lblBriefanrede";
            this.lblBriefanrede.Size = new System.Drawing.Size(63, 24);
            this.lblBriefanrede.TabIndex = 564;
            this.lblBriefanrede.Text = "Briefanrede";
            this.lblBriefanrede.UseCompatibleTextRendering = true;
            // 
            // lblGeschlecht
            // 
            this.lblGeschlecht.Location = new System.Drawing.Point(9, 83);
            this.lblGeschlecht.Name = "lblGeschlecht";
            this.lblGeschlecht.Size = new System.Drawing.Size(79, 24);
            this.lblGeschlecht.TabIndex = 564;
            this.lblGeschlecht.Text = "Geschlecht";
            this.lblGeschlecht.UseCompatibleTextRendering = true;
            // 
            // kissLabel2
            // 
            this.kissLabel2.Location = new System.Drawing.Point(380, 113);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(63, 24);
            this.kissLabel2.TabIndex = 564;
            this.kissLabel2.Text = "Telefon 1";
            this.kissLabel2.UseCompatibleTextRendering = true;
            // 
            // kissLabel1
            // 
            this.kissLabel1.Location = new System.Drawing.Point(380, 136);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(63, 24);
            this.kissLabel1.TabIndex = 564;
            this.kissLabel1.Text = "Telefon 2";
            this.kissLabel1.UseCompatibleTextRendering = true;
            // 
            // lblTelefon3
            // 
            this.lblTelefon3.Location = new System.Drawing.Point(380, 159);
            this.lblTelefon3.Name = "lblTelefon3";
            this.lblTelefon3.Size = new System.Drawing.Size(63, 24);
            this.lblTelefon3.TabIndex = 564;
            this.lblTelefon3.Text = "Telefon 3";
            this.lblTelefon3.UseCompatibleTextRendering = true;
            // 
            // lblFax
            // 
            this.lblFax.Location = new System.Drawing.Point(380, 182);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(63, 24);
            this.lblFax.TabIndex = 563;
            this.lblFax.Text = "Fax";
            this.lblFax.UseCompatibleTextRendering = true;
            // 
            // lblEMail
            // 
            this.lblEMail.Location = new System.Drawing.Point(380, 205);
            this.lblEMail.Name = "lblEMail";
            this.lblEMail.Size = new System.Drawing.Size(63, 24);
            this.lblEMail.TabIndex = 562;
            this.lblEMail.Text = "E-Mail";
            this.lblEMail.UseCompatibleTextRendering = true;
            // 
            // lblZusatz
            // 
            this.lblZusatz.Location = new System.Drawing.Point(9, 113);
            this.lblZusatz.Name = "lblZusatz";
            this.lblZusatz.Size = new System.Drawing.Size(83, 24);
            this.lblZusatz.TabIndex = 561;
            this.lblZusatz.Text = "Zusatz";
            this.lblZusatz.UseCompatibleTextRendering = true;
            // 
            // lblPostfach
            // 
            this.lblPostfach.Location = new System.Drawing.Point(9, 159);
            this.lblPostfach.Name = "lblPostfach";
            this.lblPostfach.Size = new System.Drawing.Size(83, 24);
            this.lblPostfach.TabIndex = 560;
            this.lblPostfach.Text = "Postfach";
            this.lblPostfach.UseCompatibleTextRendering = true;
            // 
            // lblStrasseNr
            // 
            this.lblStrasseNr.Location = new System.Drawing.Point(9, 136);
            this.lblStrasseNr.Name = "lblStrasseNr";
            this.lblStrasseNr.Size = new System.Drawing.Size(83, 24);
            this.lblStrasseNr.TabIndex = 557;
            this.lblStrasseNr.Text = "Strasse / Nr";
            this.lblStrasseNr.UseCompatibleTextRendering = true;
            // 
            // btnDatenblatt
            // 
            this.btnDatenblatt.Context = "BA_InstitutionFachperson";
            this.btnDatenblatt.DocumentFormat = KiSS4.Dokument.DlgNewDocument.DocumentAccessModes.All;
            this.btnDatenblatt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatenblatt.Image = ((System.Drawing.Image)(resources.GetObject("btnDatenblatt.Image")));
            this.btnDatenblatt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDatenblatt.Location = new System.Drawing.Point(916, 6);
            this.btnDatenblatt.Name = "btnDatenblatt";
            this.btnDatenblatt.Size = new System.Drawing.Size(90, 24);
            this.btnDatenblatt.TabIndex = 31;
            this.btnDatenblatt.Text = "Datenblatt";
            this.btnDatenblatt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDatenblatt.UseCompatibleTextRendering = true;
            this.btnDatenblatt.UseVisualStyleBackColor = false;
            // 
            // edtSprachCode
            // 
            this.edtSprachCode.DataMember = "SprachCode";
            this.edtSprachCode.DataSource = this.qryBaInstitution;
            this.edtSprachCode.Location = new System.Drawing.Point(788, 143);
            this.edtSprachCode.LOVName = "Sprache";
            this.edtSprachCode.Name = "edtSprachCode";
            this.edtSprachCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSprachCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSprachCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSprachCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtSprachCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSprachCode.Properties.Appearance.Options.UseFont = true;
            this.edtSprachCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSprachCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSprachCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSprachCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSprachCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtSprachCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtSprachCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSprachCode.Properties.Name = "kissLookUpEdit6.Properties";
            this.edtSprachCode.Properties.NullText = "";
            this.edtSprachCode.Properties.ShowFooter = false;
            this.edtSprachCode.Properties.ShowHeader = false;
            this.edtSprachCode.Size = new System.Drawing.Size(150, 24);
            this.edtSprachCode.TabIndex = 24;
            // 
            // edtHomepage
            // 
            this.edtHomepage.DataMember = "Homepage";
            this.edtHomepage.DataSource = this.qryBaInstitution;
            this.edtHomepage.Location = new System.Drawing.Point(449, 228);
            this.edtHomepage.Name = "edtHomepage";
            this.edtHomepage.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtHomepage.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHomepage.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHomepage.Properties.Appearance.Options.UseBackColor = true;
            this.edtHomepage.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHomepage.Properties.Appearance.Options.UseFont = true;
            this.edtHomepage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHomepage.Properties.Name = "kissTextEdit2.Properties";
            this.edtHomepage.Size = new System.Drawing.Size(231, 24);
            this.edtHomepage.TabIndex = 20;
            // 
            // edtEMail
            // 
            this.edtEMail.DataMember = "EMail";
            this.edtEMail.DataSource = this.qryBaInstitution;
            this.edtEMail.Location = new System.Drawing.Point(449, 205);
            this.edtEMail.Name = "edtEMail";
            this.edtEMail.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEMail.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEMail.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEMail.Properties.Appearance.Options.UseBackColor = true;
            this.edtEMail.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEMail.Properties.Appearance.Options.UseFont = true;
            this.edtEMail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEMail.Properties.Name = "kissTextEdit18.Properties";
            this.edtEMail.Size = new System.Drawing.Size(231, 24);
            this.edtEMail.TabIndex = 19;
            // 
            // edtFax
            // 
            this.edtFax.DataMember = "Fax";
            this.edtFax.DataSource = this.qryBaInstitution;
            this.edtFax.Location = new System.Drawing.Point(449, 182);
            this.edtFax.Name = "edtFax";
            this.edtFax.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFax.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFax.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFax.Properties.Appearance.Options.UseBackColor = true;
            this.edtFax.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFax.Properties.Appearance.Options.UseFont = true;
            this.edtFax.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFax.Properties.Name = "kissTextEdit19.Properties";
            this.edtFax.Size = new System.Drawing.Size(231, 24);
            this.edtFax.TabIndex = 18;
            // 
            // edtTelefon1
            // 
            this.edtTelefon1.DataMember = "Telefon";
            this.edtTelefon1.Location = new System.Drawing.Point(449, 113);
            this.edtTelefon1.Name = "edtTelefon1";
            this.edtTelefon1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTelefon1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTelefon1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTelefon1.Properties.Appearance.Options.UseBackColor = true;
            this.edtTelefon1.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTelefon1.Properties.Appearance.Options.UseFont = true;
            this.edtTelefon1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTelefon1.Properties.Name = "kissTextEdit20.Properties";
            this.edtTelefon1.Size = new System.Drawing.Size(231, 24);
            this.edtTelefon1.TabIndex = 15;
            // 
            // edtTelefon2
            // 
            this.edtTelefon2.DataMember = "Telefon";
            this.edtTelefon2.Location = new System.Drawing.Point(449, 136);
            this.edtTelefon2.Name = "edtTelefon2";
            this.edtTelefon2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTelefon2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTelefon2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTelefon2.Properties.Appearance.Options.UseBackColor = true;
            this.edtTelefon2.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTelefon2.Properties.Appearance.Options.UseFont = true;
            this.edtTelefon2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTelefon2.Properties.Name = "kissTextEdit20.Properties";
            this.edtTelefon2.Size = new System.Drawing.Size(231, 24);
            this.edtTelefon2.TabIndex = 16;
            // 
            // edtTelefon3
            // 
            this.edtTelefon3.DataMember = "Telefon";
            this.edtTelefon3.DataSource = this.qryBaInstitution;
            this.edtTelefon3.Location = new System.Drawing.Point(449, 159);
            this.edtTelefon3.Name = "edtTelefon3";
            this.edtTelefon3.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTelefon3.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTelefon3.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTelefon3.Properties.Appearance.Options.UseBackColor = true;
            this.edtTelefon3.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTelefon3.Properties.Appearance.Options.UseFont = true;
            this.edtTelefon3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTelefon3.Properties.Name = "kissTextEdit20.Properties";
            this.edtTelefon3.Size = new System.Drawing.Size(231, 24);
            this.edtTelefon3.TabIndex = 17;
            // 
            // edtAktiv
            // 
            this.edtAktiv.DataMember = "Aktiv";
            this.edtAktiv.DataSource = this.qryBaInstitution;
            this.edtAktiv.Location = new System.Drawing.Point(810, 10);
            this.edtAktiv.Name = "edtAktiv";
            this.edtAktiv.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAktiv.Properties.Appearance.Options.UseBackColor = true;
            this.edtAktiv.Properties.Caption = "Aktiv";
            this.edtAktiv.Properties.Name = "chkBxActiv.Properties";
            this.edtAktiv.Size = new System.Drawing.Size(72, 19);
            this.edtAktiv.TabIndex = 30;
            // 
            // edtPostfach
            // 
            this.edtPostfach.DataMember = "Postfach";
            this.edtPostfach.DataSource = this.qryBaAdresse;
            this.edtPostfach.Location = new System.Drawing.Point(94, 159);
            this.edtPostfach.Name = "edtPostfach";
            this.edtPostfach.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPostfach.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPostfach.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPostfach.Properties.Appearance.Options.UseBackColor = true;
            this.edtPostfach.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPostfach.Properties.Appearance.Options.UseFont = true;
            this.edtPostfach.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPostfach.Properties.Name = "kissTextEdit10.Properties";
            this.edtPostfach.Size = new System.Drawing.Size(196, 24);
            this.edtPostfach.TabIndex = 8;
            // 
            // edtHausNr
            // 
            this.edtHausNr.DataMember = "HausNr";
            this.edtHausNr.DataSource = this.qryBaAdresse;
            this.edtHausNr.Location = new System.Drawing.Point(315, 136);
            this.edtHausNr.Name = "edtHausNr";
            this.edtHausNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtHausNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHausNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHausNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtHausNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHausNr.Properties.Appearance.Options.UseFont = true;
            this.edtHausNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHausNr.Properties.Name = "kissTextEdit11.Properties";
            this.edtHausNr.Size = new System.Drawing.Size(49, 24);
            this.edtHausNr.TabIndex = 7;
            // 
            // edtStrasse
            // 
            this.edtStrasse.DataMember = "Strasse";
            this.edtStrasse.DataSource = this.qryBaAdresse;
            this.edtStrasse.Location = new System.Drawing.Point(94, 136);
            this.edtStrasse.Name = "edtStrasse";
            this.edtStrasse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStrasse.Properties.Name = "kissTextEdit17.Properties";
            this.edtStrasse.Size = new System.Drawing.Size(222, 24);
            this.edtStrasse.TabIndex = 6;
            // 
            // edtAdressZusatz
            // 
            this.edtAdressZusatz.DataMember = "Zusatz";
            this.edtAdressZusatz.DataSource = this.qryBaAdresse;
            this.edtAdressZusatz.Location = new System.Drawing.Point(94, 113);
            this.edtAdressZusatz.Name = "edtAdressZusatz";
            this.edtAdressZusatz.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAdressZusatz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdressZusatz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdressZusatz.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdressZusatz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdressZusatz.Properties.Appearance.Options.UseFont = true;
            this.edtAdressZusatz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdressZusatz.Properties.Name = "kissTextEdit12.Properties";
            this.edtAdressZusatz.Size = new System.Drawing.Size(270, 24);
            this.edtAdressZusatz.TabIndex = 5;
            // 
            // edtPersonName
            // 
            this.edtPersonName.DataMember = "Name";
            this.edtPersonName.DataSource = this.qryBaInstitution;
            this.edtPersonName.Location = new System.Drawing.Point(94, 30);
            this.edtPersonName.Name = "edtPersonName";
            this.edtPersonName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPersonName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPersonName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPersonName.Properties.Appearance.Options.UseBackColor = true;
            this.edtPersonName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPersonName.Properties.Appearance.Options.UseFont = true;
            this.edtPersonName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPersonName.Properties.Name = "editName.Properties";
            this.edtPersonName.Size = new System.Drawing.Size(270, 24);
            this.edtPersonName.TabIndex = 2;
            // 
            // edtAnrede
            // 
            this.edtAnrede.DataSource = this.qryBaInstitution;
            this.edtAnrede.Location = new System.Drawing.Point(449, 53);
            this.edtAnrede.Name = "edtAnrede";
            this.edtAnrede.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAnrede.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAnrede.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnrede.Properties.Appearance.Options.UseBackColor = true;
            this.edtAnrede.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAnrede.Properties.Appearance.Options.UseFont = true;
            this.edtAnrede.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAnrede.Properties.Name = "kissTextEdit1.Properties";
            this.edtAnrede.Size = new System.Drawing.Size(114, 24);
            this.edtAnrede.TabIndex = 13;
            // 
            // tabInstitution
            // 
            this.tabInstitution.Controls.Add(this.tbpInstitution);
            this.tabInstitution.Controls.Add(this.tbpKontakt);
            this.tabInstitution.Controls.Add(this.tbpZahlweg);
            this.tabInstitution.Controls.Add(this.tbpTypisierung);
            this.tabInstitution.Controls.Add(this.tbpDokumente);
            this.tabInstitution.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabInstitution.Location = new System.Drawing.Point(0, 292);
            this.tabInstitution.Name = "tabInstitution";
            this.tabInstitution.ShowFixedWidthTooltip = true;
            this.tabInstitution.ShowIconOnContainingData = true;
            this.tabInstitution.Size = new System.Drawing.Size(1086, 354);
            this.tabInstitution.TabIndex = 0;
            this.tabInstitution.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tbpInstitution,
            this.tbpKontakt,
            this.tbpZahlweg,
            this.tbpTypisierung,
            this.tbpDokumente});
            this.tabInstitution.TabsLineColor = System.Drawing.Color.Black;
            this.tabInstitution.TabsLocation = SharpLibrary.WinControls.TabsLocation.Top;
            this.tabInstitution.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabInstitution.Text = "kissTabControlEx1";
            this.tabInstitution.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabInstitution_SelectedTabChanged);
            // 
            // tbpDokumente
            // 
            this.tbpDokumente.Controls.Add(this.tblDokumente);
            this.tbpDokumente.Controls.Add(this.grdDokumente);
            this.tbpDokumente.Location = new System.Drawing.Point(6, 32);
            this.tbpDokumente.Name = "tbpDokumente";
            this.tbpDokumente.Size = new System.Drawing.Size(1074, 316);
            this.tbpDokumente.TabIndex = 4;
            this.tbpDokumente.Title = "Dokumente";
            // 
            // tblDokumente
            // 
            this.tblDokumente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblDokumente.ColumnCount = 5;
            this.tblDokumente.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tblDokumente.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblDokumente.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tblDokumente.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tblDokumente.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblDokumente.Controls.Add(this.lblDokumentDatum, 0, 0);
            this.tblDokumente.Controls.Add(this.lblDokumentKontaktart, 0, 1);
            this.tblDokumente.Controls.Add(this.lblDokumentDienstleistung, 0, 2);
            this.tblDokumente.Controls.Add(this.lblDokumentStichwort, 0, 3);
            this.tblDokumente.Controls.Add(this.lblDokumentDauer, 0, 4);
            this.tblDokumente.Controls.Add(this.lblDokumentInhalt, 0, 5);
            this.tblDokumente.Controls.Add(this.edtDokumentDatum, 1, 0);
            this.tblDokumente.Controls.Add(this.edtDokumentKontaktart, 1, 1);
            this.tblDokumente.Controls.Add(this.edtDokumentDienstleistung, 1, 2);
            this.tblDokumente.Controls.Add(this.edtDokumentStichwort, 1, 3);
            this.tblDokumente.Controls.Add(this.edtDokumentDauer, 1, 4);
            this.tblDokumente.Controls.Add(this.edtDokumentInhalt, 1, 5);
            this.tblDokumente.Controls.Add(this.lblDokument, 3, 0);
            this.tblDokumente.Controls.Add(this.lblDokumentVerfasser, 3, 1);
            this.tblDokumente.Controls.Add(this.lblDokumentAdressat, 3, 2);
            this.tblDokumente.Controls.Add(this.docDokument, 4, 0);
            this.tblDokumente.Controls.Add(this.edtDokumentVerfasser, 4, 1);
            this.tblDokumente.Controls.Add(this.edtDokumentAdressat, 4, 2);
            this.tblDokumente.Location = new System.Drawing.Point(3, 112);
            this.tblDokumente.Name = "tblDokumente";
            this.tblDokumente.RowCount = 6;
            this.tblDokumente.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblDokumente.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblDokumente.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblDokumente.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblDokumente.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblDokumente.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tblDokumente.Size = new System.Drawing.Size(1068, 201);
            this.tblDokumente.TabIndex = 2;
            // 
            // lblDokumentDatum
            // 
            this.lblDokumentDatum.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDokumentDatum.Location = new System.Drawing.Point(3, 3);
            this.lblDokumentDatum.Margin = new System.Windows.Forms.Padding(3);
            this.lblDokumentDatum.Name = "lblDokumentDatum";
            this.lblDokumentDatum.Size = new System.Drawing.Size(119, 24);
            this.lblDokumentDatum.TabIndex = 0;
            this.lblDokumentDatum.Text = "Datum";
            // 
            // lblDokumentKontaktart
            // 
            this.lblDokumentKontaktart.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDokumentKontaktart.Location = new System.Drawing.Point(3, 33);
            this.lblDokumentKontaktart.Margin = new System.Windows.Forms.Padding(3);
            this.lblDokumentKontaktart.Name = "lblDokumentKontaktart";
            this.lblDokumentKontaktart.Size = new System.Drawing.Size(119, 24);
            this.lblDokumentKontaktart.TabIndex = 1;
            this.lblDokumentKontaktart.Text = "Kontaktart";
            // 
            // lblDokumentDienstleistung
            // 
            this.lblDokumentDienstleistung.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDokumentDienstleistung.Location = new System.Drawing.Point(3, 63);
            this.lblDokumentDienstleistung.Margin = new System.Windows.Forms.Padding(3);
            this.lblDokumentDienstleistung.Name = "lblDokumentDienstleistung";
            this.lblDokumentDienstleistung.Size = new System.Drawing.Size(119, 24);
            this.lblDokumentDienstleistung.TabIndex = 2;
            this.lblDokumentDienstleistung.Text = "Dienstleistung";
            // 
            // lblDokumentStichwort
            // 
            this.lblDokumentStichwort.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDokumentStichwort.Location = new System.Drawing.Point(3, 93);
            this.lblDokumentStichwort.Margin = new System.Windows.Forms.Padding(3);
            this.lblDokumentStichwort.Name = "lblDokumentStichwort";
            this.lblDokumentStichwort.Size = new System.Drawing.Size(119, 24);
            this.lblDokumentStichwort.TabIndex = 3;
            this.lblDokumentStichwort.Text = "Stichwort/Titel";
            // 
            // lblDokumentDauer
            // 
            this.lblDokumentDauer.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDokumentDauer.Location = new System.Drawing.Point(3, 123);
            this.lblDokumentDauer.Margin = new System.Windows.Forms.Padding(3);
            this.lblDokumentDauer.Name = "lblDokumentDauer";
            this.lblDokumentDauer.Size = new System.Drawing.Size(119, 24);
            this.lblDokumentDauer.TabIndex = 4;
            this.lblDokumentDauer.Text = "Dauer/Aufwand";
            // 
            // lblDokumentInhalt
            // 
            this.lblDokumentInhalt.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDokumentInhalt.Location = new System.Drawing.Point(3, 153);
            this.lblDokumentInhalt.Margin = new System.Windows.Forms.Padding(3);
            this.lblDokumentInhalt.Name = "lblDokumentInhalt";
            this.lblDokumentInhalt.Size = new System.Drawing.Size(119, 24);
            this.lblDokumentInhalt.TabIndex = 5;
            this.lblDokumentInhalt.Text = "Inhalt Besprechung";
            // 
            // edtDokumentDatum
            // 
            this.edtDokumentDatum.EditValue = null;
            this.edtDokumentDatum.Location = new System.Drawing.Point(128, 3);
            this.edtDokumentDatum.Name = "edtDokumentDatum";
            this.edtDokumentDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDokumentDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDokumentDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDokumentDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDokumentDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtDokumentDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDokumentDatum.Properties.Appearance.Options.UseFont = true;
            this.edtDokumentDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtDokumentDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDokumentDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtDokumentDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDokumentDatum.Properties.ShowToday = false;
            this.edtDokumentDatum.Size = new System.Drawing.Size(100, 24);
            this.edtDokumentDatum.TabIndex = 6;
            // 
            // edtDokumentKontaktart
            // 
            this.edtDokumentKontaktart.Dock = System.Windows.Forms.DockStyle.Top;
            this.edtDokumentKontaktart.Location = new System.Drawing.Point(128, 33);
            this.edtDokumentKontaktart.LOVName = "BaInstitutionDokumentKontaktart";
            this.edtDokumentKontaktart.Name = "edtDokumentKontaktart";
            this.edtDokumentKontaktart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDokumentKontaktart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDokumentKontaktart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDokumentKontaktart.Properties.Appearance.Options.UseBackColor = true;
            this.edtDokumentKontaktart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDokumentKontaktart.Properties.Appearance.Options.UseFont = true;
            this.edtDokumentKontaktart.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtDokumentKontaktart.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtDokumentKontaktart.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtDokumentKontaktart.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtDokumentKontaktart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtDokumentKontaktart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtDokumentKontaktart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDokumentKontaktart.Properties.NullText = "";
            this.edtDokumentKontaktart.Properties.ShowFooter = false;
            this.edtDokumentKontaktart.Properties.ShowHeader = false;
            this.edtDokumentKontaktart.Size = new System.Drawing.Size(353, 24);
            this.edtDokumentKontaktart.TabIndex = 7;
            // 
            // edtDokumentDienstleistung
            // 
            this.edtDokumentDienstleistung.Dock = System.Windows.Forms.DockStyle.Top;
            this.edtDokumentDienstleistung.Location = new System.Drawing.Point(128, 63);
            this.edtDokumentDienstleistung.LOVName = "BaInstitutionDokumentDienstleistung";
            this.edtDokumentDienstleistung.Name = "edtDokumentDienstleistung";
            this.edtDokumentDienstleistung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDokumentDienstleistung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDokumentDienstleistung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDokumentDienstleistung.Properties.Appearance.Options.UseBackColor = true;
            this.edtDokumentDienstleistung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDokumentDienstleistung.Properties.Appearance.Options.UseFont = true;
            this.edtDokumentDienstleistung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtDokumentDienstleistung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtDokumentDienstleistung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtDokumentDienstleistung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtDokumentDienstleistung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtDokumentDienstleistung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtDokumentDienstleistung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDokumentDienstleistung.Properties.NullText = "";
            this.edtDokumentDienstleistung.Properties.ShowFooter = false;
            this.edtDokumentDienstleistung.Properties.ShowHeader = false;
            this.edtDokumentDienstleistung.Size = new System.Drawing.Size(353, 24);
            this.edtDokumentDienstleistung.TabIndex = 8;
            // 
            // edtDokumentStichwort
            // 
            this.edtDokumentStichwort.Dock = System.Windows.Forms.DockStyle.Top;
            this.edtDokumentStichwort.Location = new System.Drawing.Point(128, 93);
            this.edtDokumentStichwort.Name = "edtDokumentStichwort";
            this.edtDokumentStichwort.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDokumentStichwort.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDokumentStichwort.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDokumentStichwort.Properties.Appearance.Options.UseBackColor = true;
            this.edtDokumentStichwort.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDokumentStichwort.Properties.Appearance.Options.UseFont = true;
            this.edtDokumentStichwort.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDokumentStichwort.Size = new System.Drawing.Size(353, 24);
            this.edtDokumentStichwort.TabIndex = 9;
            // 
            // edtDokumentDauer
            // 
            this.edtDokumentDauer.Dock = System.Windows.Forms.DockStyle.Top;
            this.edtDokumentDauer.Location = new System.Drawing.Point(128, 123);
            this.edtDokumentDauer.LOVName = "FaDauer";
            this.edtDokumentDauer.Name = "edtDokumentDauer";
            this.edtDokumentDauer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDokumentDauer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDokumentDauer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDokumentDauer.Properties.Appearance.Options.UseBackColor = true;
            this.edtDokumentDauer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDokumentDauer.Properties.Appearance.Options.UseFont = true;
            this.edtDokumentDauer.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtDokumentDauer.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtDokumentDauer.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtDokumentDauer.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtDokumentDauer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtDokumentDauer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtDokumentDauer.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDokumentDauer.Properties.NullText = "";
            this.edtDokumentDauer.Properties.ShowFooter = false;
            this.edtDokumentDauer.Properties.ShowHeader = false;
            this.edtDokumentDauer.Size = new System.Drawing.Size(353, 24);
            this.edtDokumentDauer.TabIndex = 10;
            // 
            // edtDokumentInhalt
            // 
            this.tblDokumente.SetColumnSpan(this.edtDokumentInhalt, 4);
            this.edtDokumentInhalt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtDokumentInhalt.Location = new System.Drawing.Point(128, 153);
            this.edtDokumentInhalt.Name = "edtDokumentInhalt";
            this.edtDokumentInhalt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDokumentInhalt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDokumentInhalt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDokumentInhalt.Properties.Appearance.Options.UseBackColor = true;
            this.edtDokumentInhalt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDokumentInhalt.Properties.Appearance.Options.UseFont = true;
            this.edtDokumentInhalt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDokumentInhalt.Size = new System.Drawing.Size(937, 45);
            this.edtDokumentInhalt.TabIndex = 11;
            // 
            // lblDokument
            // 
            this.lblDokument.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDokument.Location = new System.Drawing.Point(587, 3);
            this.lblDokument.Margin = new System.Windows.Forms.Padding(3);
            this.lblDokument.Name = "lblDokument";
            this.lblDokument.Size = new System.Drawing.Size(119, 24);
            this.lblDokument.TabIndex = 12;
            this.lblDokument.Text = "Dokument";
            // 
            // lblDokumentVerfasser
            // 
            this.lblDokumentVerfasser.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDokumentVerfasser.Location = new System.Drawing.Point(587, 33);
            this.lblDokumentVerfasser.Margin = new System.Windows.Forms.Padding(3);
            this.lblDokumentVerfasser.Name = "lblDokumentVerfasser";
            this.lblDokumentVerfasser.Size = new System.Drawing.Size(119, 24);
            this.lblDokumentVerfasser.TabIndex = 13;
            this.lblDokumentVerfasser.Text = "VerfasserIn";
            // 
            // lblDokumentAdressat
            // 
            this.lblDokumentAdressat.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDokumentAdressat.Location = new System.Drawing.Point(587, 63);
            this.lblDokumentAdressat.Margin = new System.Windows.Forms.Padding(3);
            this.lblDokumentAdressat.Name = "lblDokumentAdressat";
            this.lblDokumentAdressat.Size = new System.Drawing.Size(119, 24);
            this.lblDokumentAdressat.TabIndex = 14;
            this.lblDokumentAdressat.Text = "AdressatIn";
            // 
            // docDokument
            // 
            this.docDokument.Context = "BA_InstitutionDokumente";
            this.docDokument.EditValue = "";
            this.docDokument.Location = new System.Drawing.Point(712, 3);
            this.docDokument.Name = "docDokument";
            this.docDokument.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docDokument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docDokument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docDokument.Properties.Appearance.Options.UseBackColor = true;
            this.docDokument.Properties.Appearance.Options.UseBorderColor = true;
            this.docDokument.Properties.Appearance.Options.UseFont = true;
            this.docDokument.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            serializableAppearanceObject13.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject13.Options.UseBackColor = true;
            serializableAppearanceObject14.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject14.Options.UseBackColor = true;
            this.docDokument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docDokument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docDokument.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docDokument.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docDokument.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject14, "Dokument importieren")});
            this.docDokument.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docDokument.Properties.ReadOnly = true;
            this.docDokument.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docDokument.Size = new System.Drawing.Size(125, 24);
            this.docDokument.TabIndex = 15;
            // 
            // edtDokumentVerfasser
            // 
            this.edtDokumentVerfasser.Dock = System.Windows.Forms.DockStyle.Top;
            this.edtDokumentVerfasser.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtDokumentVerfasser.Location = new System.Drawing.Point(712, 33);
            this.edtDokumentVerfasser.Name = "edtDokumentVerfasser";
            this.edtDokumentVerfasser.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtDokumentVerfasser.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDokumentVerfasser.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDokumentVerfasser.Properties.Appearance.Options.UseBackColor = true;
            this.edtDokumentVerfasser.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDokumentVerfasser.Properties.Appearance.Options.UseFont = true;
            this.edtDokumentVerfasser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject15.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject15.Options.UseBackColor = true;
            this.edtDokumentVerfasser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject15)});
            this.edtDokumentVerfasser.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDokumentVerfasser.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtDokumentVerfasser.Size = new System.Drawing.Size(353, 24);
            this.edtDokumentVerfasser.TabIndex = 16;
            // 
            // edtDokumentAdressat
            // 
            this.edtDokumentAdressat.DataMemberVmPriMa = null;
            this.edtDokumentAdressat.Dock = System.Windows.Forms.DockStyle.Top;
            this.edtDokumentAdressat.Location = new System.Drawing.Point(712, 63);
            this.edtDokumentAdressat.Name = "edtDokumentAdressat";
            this.edtDokumentAdressat.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDokumentAdressat.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDokumentAdressat.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDokumentAdressat.Properties.Appearance.Options.UseBackColor = true;
            this.edtDokumentAdressat.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDokumentAdressat.Properties.Appearance.Options.UseFont = true;
            this.edtDokumentAdressat.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject16.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject16.Options.UseBackColor = true;
            this.edtDokumentAdressat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject16)});
            this.edtDokumentAdressat.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDokumentAdressat.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtDokumentAdressat.Size = new System.Drawing.Size(353, 24);
            this.edtDokumentAdressat.TabIndex = 17;
            // 
            // grdDokumente
            // 
            this.grdDokumente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDokumente.DataSource = this.qryDokumente;
            // 
            // 
            // 
            this.grdDokumente.EmbeddedNavigator.Name = "";
            this.grdDokumente.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdDokumente.Location = new System.Drawing.Point(3, 3);
            this.grdDokumente.MainView = this.grvDokumente;
            this.grdDokumente.Name = "grdDokumente";
            this.grdDokumente.SelectLastPosition = true;
            this.grdDokumente.Size = new System.Drawing.Size(1068, 103);
            this.grdDokumente.TabIndex = 1;
            this.grdDokumente.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDokumente});
            // 
            // qryDokumente
            // 
            this.qryDokumente.CanDelete = true;
            this.qryDokumente.CanInsert = true;
            this.qryDokumente.CanUpdate = true;
            this.qryDokumente.HostControl = this;
            this.qryDokumente.MasterQuery = this.qryBaInstitution;
            this.qryDokumente.SelectStatement = resources.GetString("qryDokumente.SelectStatement");
            this.qryDokumente.TableName = "BaInstitutionDokument";
            this.qryDokumente.AfterFill += new System.EventHandler(this.qryDokumente_AfterFill);
            this.qryDokumente.AfterInsert += new System.EventHandler(this.qryDokumente_AfterInsert);
            this.qryDokumente.BeforePost += new System.EventHandler(this.qryDokumente_BeforePost);
            // 
            // grvDokumente
            // 
            this.grvDokumente.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvDokumente.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDokumente.Appearance.Empty.Options.UseBackColor = true;
            this.grvDokumente.Appearance.Empty.Options.UseFont = true;
            this.grvDokumente.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDokumente.Appearance.EvenRow.Options.UseFont = true;
            this.grvDokumente.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvDokumente.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDokumente.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvDokumente.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvDokumente.Appearance.FocusedCell.Options.UseFont = true;
            this.grvDokumente.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvDokumente.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvDokumente.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDokumente.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvDokumente.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvDokumente.Appearance.FocusedRow.Options.UseFont = true;
            this.grvDokumente.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvDokumente.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvDokumente.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvDokumente.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvDokumente.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvDokumente.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvDokumente.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvDokumente.Appearance.GroupRow.Options.UseFont = true;
            this.grvDokumente.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvDokumente.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvDokumente.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvDokumente.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvDokumente.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvDokumente.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvDokumente.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvDokumente.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvDokumente.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDokumente.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvDokumente.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvDokumente.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvDokumente.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvDokumente.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvDokumente.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvDokumente.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDokumente.Appearance.OddRow.Options.UseFont = true;
            this.grvDokumente.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvDokumente.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDokumente.Appearance.Row.Options.UseBackColor = true;
            this.grvDokumente.Appearance.Row.Options.UseFont = true;
            this.grvDokumente.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDokumente.Appearance.SelectedRow.Options.UseFont = true;
            this.grvDokumente.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvDokumente.Appearance.VertLine.Options.UseBackColor = true;
            this.grvDokumente.BestFitMaxRowCount = 1000;
            this.grvDokumente.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvDokumente.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDokumenteDatum,
            this.colDokumenteKontaktart,
            this.colDokumenteDienstleistung,
            this.colDokumenteStichwort,
            this.colDokumenteVerfasser,
            this.colDokumenteAdressat,
            this.colDokumenteAufwand});
            this.grvDokumente.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvDokumente.GridControl = this.grdDokumente;
            this.grvDokumente.Name = "grvDokumente";
            this.grvDokumente.OptionsBehavior.Editable = false;
            this.grvDokumente.OptionsCustomization.AllowFilter = false;
            this.grvDokumente.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvDokumente.OptionsNavigation.AutoFocusNewRow = true;
            this.grvDokumente.OptionsNavigation.UseTabKey = false;
            this.grvDokumente.OptionsView.ColumnAutoWidth = false;
            this.grvDokumente.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvDokumente.OptionsView.ShowGroupPanel = false;
            this.grvDokumente.OptionsView.ShowIndicator = false;
            // 
            // colDokumenteDatum
            // 
            this.colDokumenteDatum.Caption = "Datum";
            this.colDokumenteDatum.Name = "colDokumenteDatum";
            this.colDokumenteDatum.Visible = true;
            this.colDokumenteDatum.VisibleIndex = 0;
            // 
            // colDokumenteKontaktart
            // 
            this.colDokumenteKontaktart.Caption = "Kontaktart";
            this.colDokumenteKontaktart.Name = "colDokumenteKontaktart";
            this.colDokumenteKontaktart.Visible = true;
            this.colDokumenteKontaktart.VisibleIndex = 1;
            // 
            // colDokumenteDienstleistung
            // 
            this.colDokumenteDienstleistung.Caption = "Dienstleistung";
            this.colDokumenteDienstleistung.Name = "colDokumenteDienstleistung";
            this.colDokumenteDienstleistung.Visible = true;
            this.colDokumenteDienstleistung.VisibleIndex = 2;
            // 
            // colDokumenteStichwort
            // 
            this.colDokumenteStichwort.Caption = "Stichwort";
            this.colDokumenteStichwort.Name = "colDokumenteStichwort";
            this.colDokumenteStichwort.Visible = true;
            this.colDokumenteStichwort.VisibleIndex = 3;
            // 
            // colDokumenteVerfasser
            // 
            this.colDokumenteVerfasser.Caption = "VerfasserIn";
            this.colDokumenteVerfasser.Name = "colDokumenteVerfasser";
            this.colDokumenteVerfasser.Visible = true;
            this.colDokumenteVerfasser.VisibleIndex = 4;
            // 
            // colDokumenteAdressat
            // 
            this.colDokumenteAdressat.Caption = "AdressatIn";
            this.colDokumenteAdressat.Name = "colDokumenteAdressat";
            this.colDokumenteAdressat.Visible = true;
            this.colDokumenteAdressat.VisibleIndex = 5;
            // 
            // colDokumenteAufwand
            // 
            this.colDokumenteAufwand.Caption = "Aufwand";
            this.colDokumenteAufwand.Name = "colDokumenteAufwand";
            this.colDokumenteAufwand.Visible = true;
            this.colDokumenteAufwand.VisibleIndex = 6;
            // 
            // splDetailListe
            // 
            this.splDetailListe.AnimationDelay = 1;
            this.splDetailListe.AnimationStep = 20;
            this.splDetailListe.BorderStyle3D = System.Windows.Forms.Border3DStyle.Etched;
            this.splDetailListe.ControlToHide = this.tabInstitution;
            this.splDetailListe.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splDetailListe.ExpandParentForm = false;
            this.splDetailListe.Location = new System.Drawing.Point(0, 284);
            this.splDetailListe.Name = "splDetailListe";
            this.splDetailListe.TabIndex = 572;
            this.splDetailListe.TabStop = false;
            this.splDetailListe.UseAnimations = false;
            this.splDetailListe.VisualStyle = KiSS4.Gui.VisualStyles.Mozilla;
            // 
            // CtlInstitutionenStamm
            // 
            this.ActiveSQLQuery = this.qryBaInstitution;
            this.Controls.Add(this.lblAnzDatensaetze);
            this.Controls.Add(this.lblRowCount);
            this.Controls.Add(this.splDetailListe);
            this.Controls.Add(this.tabInstitution);
            this.Name = "CtlInstitutionenStamm";
            this.Size = new System.Drawing.Size(1086, 646);
            this.Load += new System.EventHandler(this.CtlInstitutionenStamm_Load);
            this.Controls.SetChildIndex(this.tabInstitution, 0);
            this.Controls.SetChildIndex(this.splDetailListe, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.lblRowCount, 0);
            this.Controls.SetChildIndex(this.lblAnzDatensaetze, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBaInstitution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaInstitution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaInstitution)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKeinSerienbrief.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheAuchKontakte.Properties)).EndInit();
            this.pnlSucheInstTypen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheInstitutionenMitAllenTypen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheNurAktive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBaInstitutionId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheOrgEinheit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheOrgEinheit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheOrgEinheit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInstitutionNrX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefonX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEMailX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPLZOrtX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefonX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEMailX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInstitutionNrX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrtX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPLZX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaAdresse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaInstitutionKontakt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryInstTypen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeordneteInstTypen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrySucheInstTypen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrySucheSelectedInstTypen)).EndInit();
            this.tbpTypisierung.ResumeLayout(false);
            this.panTypen.ResumeLayout(false);
            this.tbpZahlweg.ResumeLayout(false);
            this.tbpKontakt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdKontakt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKontakt)).EndInit();
            this.panDetailsKontakt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktPersonName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKontaktAktiv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktGeschlecht.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktGeschlecht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKontaktManuelleAnrede.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktTelefon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktBriefanrede.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktFax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktTitel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktEMail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktAnrede)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktPersonVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktBriefanrede)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktGeschlecht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktAnrede.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktEMail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktSprache)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktFax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktSprachCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktSprachCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktTelefon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktBemerkung)).EndInit();
            this.tbpInstitution.ResumeLayout(false);
            this.panDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtVersichertennummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsdatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersichertennummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKeinSerienbrief.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlecht.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlecht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkManuelleAnrede.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInstName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBriefanrede.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTitel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbteilung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbteilung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbteilung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPostfachOhneNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBezirk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPLZOrtKt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgrItemTyp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgrItemTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDebitor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInstNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInstitutionNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHomepage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnrede)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSprachCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBriefanrede)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeschlecht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefon3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEMail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPostfach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasseNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSprachCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSprachCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHomepage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEMail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefon1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefon2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefon3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAktiv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPostfach.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHausNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdressZusatz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnrede.Properties)).EndInit();
            this.tabInstitution.ResumeLayout(false);
            this.tbpDokumente.ResumeLayout(false);
            this.tblDokumente.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblDokumentDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokumentKontaktart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokumentDienstleistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokumentStichwort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokumentDauer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokumentInhalt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentKontaktart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentKontaktart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentDienstleistung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentDienstleistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentStichwort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentDauer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentDauer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentInhalt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokumentVerfasser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokumentAdressat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docDokument.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentVerfasser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentAdressat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDokumente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryDokumente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDokumente)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Dokument.KissDocumentButton btnDatenblatt;
        private KiSS4.Gui.KissCheckEdit chkKeinSerienbrief;
        private KiSS4.Gui.KissCheckEdit chkKontaktAktiv;
        private KiSS4.Gui.KissCheckEdit chkKontaktManuelleAnrede;
        private KiSS4.Gui.KissCheckEdit chkManuelleAnrede;
        private KiSS4.Gui.KissCheckEdit chkPostfachOhneNr;
        private KiSS4.Gui.KissCheckEdit chkSucheAuchKontakte;
        private KiSS4.Gui.KissCheckEdit chkSucheInstitutionenMitAllenTypen;
        private KiSS4.Gui.KissCheckEdit chkSucheNurAktive;
        private DevExpress.XtraGrid.Columns.GridColumn colAbteilung;
        private DevExpress.XtraGrid.Columns.GridColumn colAktiv;
        private DevExpress.XtraGrid.Columns.GridColumn colBemerkungen;
        private DevExpress.XtraGrid.Columns.GridColumn colEMail;
        private DevExpress.XtraGrid.Columns.GridColumn colFax;
        private DevExpress.XtraGrid.Columns.GridColumn colInstitutionVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colKontaktAktiv;
        private DevExpress.XtraGrid.Columns.GridColumn colKontaktEMail;
        private DevExpress.XtraGrid.Columns.GridColumn colKontaktName;
        private DevExpress.XtraGrid.Columns.GridColumn colKontaktTelefon;
        private DevExpress.XtraGrid.Columns.GridColumn colKontaktVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colLand;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colNr;
        private DevExpress.XtraGrid.Columns.GridColumn colOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colPLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colPostfach;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasse;
        private DevExpress.XtraGrid.Columns.GridColumn colTelefon;
        private DevExpress.XtraGrid.Columns.GridColumn colTitel;
        private DevExpress.XtraGrid.Columns.GridColumn colTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colZusatz;
        private System.ComponentModel.IContainer components;
        private CtlBaZahlungsweg ctlZahlungsweg;
        private KiSS4.Gui.KissLookUpEdit edtAbteilung;
        private KiSS4.Gui.KissTextEdit edtAdressZusatz;
        private KiSS4.Gui.KissCheckEdit edtAktiv;
        private KiSS4.Gui.KissTextEdit edtAnrede;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private KiSS4.Gui.KissTextEdit edtBriefanrede;
        private KiSS4.Gui.KissCheckEdit edtDebitor;
        private KiSS4.Gui.KissTextEdit edtEMail;
        private KiSS4.Gui.KissTextEdit edtEMailX;
        private KiSS4.Gui.KissTextEdit edtFax;
        private KiSS4.Gui.KissLookUpEdit edtGeschlecht;
        private KiSS4.Gui.KissTextEdit edtHausNr;
        private KiSS4.Gui.KissTextEdit edtHomepage;
        private KiSS4.Gui.KissMemoEdit edtInstName;
        private KiSS4.Gui.KissTextEdit edtInstitutionNr;
        private KiSS4.Gui.KissTextEdit edtInstitutionNrX;
        private KiSS4.Gui.KissTextEdit edtKontaktAnrede;
        private KiSS4.Gui.KissMemoEdit edtKontaktBemerkung;
        private KiSS4.Gui.KissTextEdit edtKontaktBriefanrede;
        private KiSS4.Gui.KissTextEdit edtKontaktEMail;
        private KiSS4.Gui.KissTextEdit edtKontaktFax;
        private KiSS4.Gui.KissLookUpEdit edtKontaktGeschlecht;
        private KiSS4.Gui.KissTextEdit edtKontaktName;
        private KiSS4.Gui.KissLookUpEdit edtKontaktSprachCode;
        private KiSS4.Gui.KissTextEdit edtKontaktTelefon;
        private KiSS4.Gui.KissTextEdit edtKontaktTitel;
        private KiSS4.Gui.KissTextEdit edtKontaktVorname;
        private KiSS4.Gui.KissCheckEdit edtKreditor;
        private KiSS4.Gui.KissTextEdit edtNameX;
        private KiSS4.Gui.KissTextEdit edtOrtX;
        private KiSS4.Common.KissPLZOrt edtPLZOrt;
        private KiSS4.Gui.KissTextEdit edtPLZX;
        private KiSS4.Gui.KissTextEdit edtPersonName;
        private KiSS4.Gui.KissTextEdit edtPostfach;
        private KiSS4.Gui.KissLookUpEdit edtSprachCode;
        private KiSS4.Gui.KissTextEdit edtStrasse;
        private KiSS4.Gui.KissIntEdit edtSucheBaInstitutionId;
        private KiSS4.Gui.KissTextEdit edtSucheBemerkung;
        private KiSS4.Gui.KissCheckEdit edtSucheKeinSerienbrief;
        private KiSS4.Gui.KissLookUpEdit edtSucheOrgEinheit;
        private KiSS4.Gui.KissTextEdit edtTelefon1;
        private KiSS4.Gui.KissTextEdit edtTelefon2;
        private KiSS4.Gui.KissTextEdit edtTelefon3;
        private KiSS4.Gui.KissTextEdit edtTelefonX;
        private KiSS4.Gui.KissTextEdit edtTitel;
        private KiSS4.Gui.KissTextEdit edtVorname;
        private KiSS4.Gui.KissGrid grdBaInstitution;
        private KiSS4.Gui.KissGrid grdKontakt;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBaInstitution;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKontakt;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissSearchTitel kissSearchTitel1;
        private KiSS4.Gui.KissLabel lblAbteilung;
        private KiSS4.Gui.KissLabel lblAnrede;
        private System.Windows.Forms.Label lblAnzDatensaetze;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblBezirk;
        private KiSS4.Gui.KissLabel lblBriefanrede;
        private KiSS4.Gui.KissLabel lblEMail;
        private KiSS4.Gui.KissLabel lblEMailX;
        private KiSS4.Gui.KissLabel lblFax;
        private KiSS4.Gui.KissLabel lblGeschlecht;
        private KiSS4.Gui.KissLabel lblHomepage;
        private KiSS4.Gui.KissLabel lblInstNr;
        private KiSS4.Gui.KissLabel lblInstitutionNrX;
        private KiSS4.Gui.KissLabel lblKontaktAnrede;
        private KiSS4.Gui.KissLabel lblKontaktBemerkung;
        private KiSS4.Gui.KissLabel lblKontaktBriefanrede;
        private KiSS4.Gui.KissLabel lblKontaktEMail;
        private KiSS4.Gui.KissLabel lblKontaktFax;
        private KiSS4.Gui.KissLabel lblKontaktGeschlecht;
        private KiSS4.Gui.KissLabel lblKontaktPersonName;
        private KiSS4.Gui.KissLabel lblKontaktPersonVorname;
        private KiSS4.Gui.KissLabel lblKontaktSprache;
        private KiSS4.Gui.KissLabel lblKontaktTelefon;
        private KiSS4.Gui.KissLabel lblKontaktTitel;
        private KiSS4.Gui.KissLabel lblLand;
        private KiSS4.Gui.KissLabel lblName;
        private KiSS4.Gui.KissLabel lblNameX;
        private KiSS4.Gui.KissLabel lblPLZOrtKt;
        private KiSS4.Gui.KissLabel lblPLZOrtX;
        private KiSS4.Gui.KissLabel lblPostfach;
        private System.Windows.Forms.Label lblRowCount;
        private KiSS4.Gui.KissLabel lblSprachCode;
        private KiSS4.Gui.KissLabel lblStrasseNr;
        private KiSS4.Gui.KissLabel lblSucheBemerkung;
        private KiSS4.Gui.KissLabel lblSucheId;
        private KiSS4.Gui.KissLabel lblSucheOrgEinheit;
        private KiSS4.Gui.KissLabel lblTelefon3;
        private KiSS4.Gui.KissLabel lblTelefonX;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblVorname;
        private KiSS4.Gui.KissLabel lblZusatz;
        private System.Windows.Forms.Panel panDetails;
        private System.Windows.Forms.Panel panDetailsKontakt;
        private System.Windows.Forms.Panel panTypen;
        private KiSS4.Gui.KissPickList pklInstTypen;
        private KiSS4.Gui.KissPickList pklSucheInstTypen;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Panel pnlSucheInstTypen;
        private KiSS4.DB.SqlQuery qryBaAdresse;
        private KiSS4.DB.SqlQuery qryBaInstitution;
        private KiSS4.DB.SqlQuery qryBaInstitutionKontakt;
        private KiSS4.DB.SqlQuery qryInstTypen;
        private KiSS4.DB.SqlQuery qrySucheInstTypen;
        private KiSS4.DB.SqlQuery qrySucheSelectedInstTypen;
        private KiSS4.DB.SqlQuery qryZugeordneteInstTypen;
        private KiSS4.Gui.KissRadioGroup rgrItemTyp;
        private KiSS4.Gui.KissSplitterCollapsible splDetailListe;
        private KiSS4.Gui.KissTabControlEx tabInstitution;
        private SharpLibrary.WinControls.TabPageEx tabPageEx1;
        private SharpLibrary.WinControls.TabPageEx tabPageEx2;
        private SharpLibrary.WinControls.TabPageEx tbpInstitution;
        private SharpLibrary.WinControls.TabPageEx tbpKontakt;
        private SharpLibrary.WinControls.TabPageEx tbpTypisierung;
        private SharpLibrary.WinControls.TabPageEx tbpZahlweg;
        private Gui.KissVersichertenNrEdit edtVersichertennummer;
        private Gui.KissDateEdit edtGeburtsdatum;
        private Gui.KissLabel lblVersichertennummer;
        private Gui.KissLabel lblGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colArt;
        private SharpLibrary.WinControls.TabPageEx tbpDokumente;
        private System.Windows.Forms.TableLayoutPanel tblDokumente;
        private Gui.KissLabel lblDokumentDatum;
        private Gui.KissLabel lblDokumentKontaktart;
        private Gui.KissLabel lblDokumentDienstleistung;
        private Gui.KissLabel lblDokumentStichwort;
        private Gui.KissLabel lblDokumentDauer;
        private Gui.KissLabel lblDokumentInhalt;
        private Gui.KissDateEdit edtDokumentDatum;
        private Gui.KissLookUpEdit edtDokumentKontaktart;
        private Gui.KissLookUpEdit edtDokumentDienstleistung;
        private Gui.KissTextEdit edtDokumentStichwort;
        private Gui.KissLookUpEdit edtDokumentDauer;
        private Gui.KissMemoEdit edtDokumentInhalt;
        private Gui.KissLabel lblDokument;
        private Gui.KissLabel lblDokumentVerfasser;
        private Gui.KissLabel lblDokumentAdressat;
        private Dokument.XDokument docDokument;
        private Common.KissMitarbeiterButtonEdit edtDokumentVerfasser;
        private Common.KissAdressatButtonEdit edtDokumentAdressat;
        private Gui.KissGrid grdDokumente;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDokumente;
        private DevExpress.XtraGrid.Columns.GridColumn colDokumenteDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colDokumenteKontaktart;
        private DevExpress.XtraGrid.Columns.GridColumn colDokumenteDienstleistung;
        private DevExpress.XtraGrid.Columns.GridColumn colDokumenteStichwort;
        private DevExpress.XtraGrid.Columns.GridColumn colDokumenteVerfasser;
        private DevExpress.XtraGrid.Columns.GridColumn colDokumenteAdressat;
        private DevExpress.XtraGrid.Columns.GridColumn colDokumenteAufwand;
        private DB.SqlQuery qryDokumente;
    }
}
