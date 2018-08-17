using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS4.Fallfuehrung.ZH
{
    partial class CtlFaDokumente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFaDokumente));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject18 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject17 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject16 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject15 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject14 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject19 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject20 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject21 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdFaDokumente = new KiSS4.Gui.KissGrid();
            this.qryFaDokumente = new KiSS4.DB.SqlQuery(this.components);
            this.grvFaDokumente = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStichworte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaDokThemaCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbsender = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdressat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaDokVisumStatusCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaDokStatusCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErsteller = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErstellerOrgUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaDokVerwendungCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrifftPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSelected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.edtSucheDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtSucheDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtSucheAbsender = new KiSS4.Gui.KissTextEdit();
            this.edtSucheAdressat = new KiSS4.Gui.KissTextEdit();
            this.edtSucheStichwort = new KiSS4.Gui.KissTextEdit();
            this.edtSucheFaDokThemaCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtSucheBemerkung = new KiSS4.Gui.KissTextEdit();
            this.edtSucheFaDokVisumStatusCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtSucheFaDokStatusCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtSucheFaDokVerwendungCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtSucheBaPersonID = new KiSS4.Gui.KissLookUpEdit();
            this.edtSucheKlibuRelevant = new KiSS4.Gui.KissCheckEdit();
            this.edtSucheNichtKlibuRelevant = new KiSS4.Gui.KissCheckEdit();
            this.lblFaDokKorreSucheDatumVon = new KiSS4.Gui.KissLabel();
            this.lblFaDokKorreSucheAbsender = new KiSS4.Gui.KissLabel();
            this.lblFaDokKorreSucheAdressat = new KiSS4.Gui.KissLabel();
            this.lblFaDokKorreSucheStichwort = new KiSS4.Gui.KissLabel();
            this.lblFaDokKorreSucheDatumBis = new KiSS4.Gui.KissLabel();
            this.lblSucheThemen = new KiSS4.Gui.KissLabel();
            this.lblSucheVisumCode = new KiSS4.Gui.KissLabel();
            this.lblSucheDokStatus = new KiSS4.Gui.KissLabel();
            this.lblSucheVerwendung = new KiSS4.Gui.KissLabel();
            this.lblSucheBetrifftPerson = new KiSS4.Gui.KissLabel();
            this.lblSucheBemerkung = new KiSS4.Gui.KissLabel();
            this.tabDocument = new KiSS4.Gui.KissTabControlEx();
            this.tpgVisum = new SharpLibrary.WinControls.TabPageEx();
            this.grdXTask = new KiSS4.Gui.KissGrid();
            this.qryXTask = new KiSS4.DB.SqlQuery(this.components);
            this.grvXTask = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSender = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReceiver = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaskStatusCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPendenzBeantwortet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaskResponseCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPendenzAntwortText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaDokVisumStatusCode_Task = new DevExpress.XtraGrid.Columns.GridColumn();
            this.memBemerkungAnfrage = new KiSS4.Gui.KissMemoEdit();
            this.rgpAnfrage = new KiSS4.Gui.KissRadioGroup(this.components);
            this.memBemerkungAntwort = new KiSS4.Gui.KissMemoEdit();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.btnWiederrufen = new KiSS4.Gui.KissButton();
            this.btnAntworten = new KiSS4.Gui.KissButton();
            this.btnAnfrage = new KiSS4.Gui.KissButton();
            this.tpgDocument = new SharpLibrary.WinControls.TabPageEx();
            this.edtVisumStatusDatum = new KiSS4.Gui.KissTextEdit();
            this.edtFaDokVisumStatusCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtStatusLetztDatum = new KiSS4.Gui.KissTextEdit();
            this.edtFaDokStatusCode = new KiSS4.Gui.KissLookUpEdit();
            this.ctlErfassungMutation = new KiSS4.Common.CtlErfassungMutation();
            this.edtStatusSetUser = new KiSS4.Gui.KissTextEdit();
            this.lblStatusLetztDatum = new KiSS4.Gui.KissLabel();
            this.lblStatusSetUser = new KiSS4.Gui.KissLabel();
            this.lblFaDokStatusCode = new KiSS4.Gui.KissLabel();
            this.edtVisumPerson = new KiSS4.Gui.KissTextEdit();
            this.lblVisumPerson = new KiSS4.Gui.KissLabel();
            this.lblBaPersonID = new KiSS4.Gui.KissLabel();
            this.lblFaDokThemaCode = new KiSS4.Gui.KissLabel();
            this.lblVisumStatusDatum = new KiSS4.Gui.KissLabel();
            this.lblFaDokVisumStatusCode = new KiSS4.Gui.KissLabel();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.lblFaDokVerwendungCode = new KiSS4.Gui.KissLabel();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.docDokument = new KiSS4.Dokument.XDokument();
            this.edtBaPersonID = new KiSS4.Gui.KissLookUpEdit();
            this.edtFaDokThemaCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblAbsender = new KiSS4.Gui.KissLabel();
            this.edtStichwort = new KiSS4.Gui.KissTextEdit();
            this.lblAdressat = new KiSS4.Gui.KissLabel();
            this.edtAdressatFreitext = new KiSS4.Gui.KissTextEdit();
            this.lblStichwort = new KiSS4.Gui.KissLabel();
            this.edtAdressat = new KiSS4.Gui.KissButtonEdit();
            this.lblDatumErstellung = new KiSS4.Gui.KissLabel();
            this.edtAbsenderFreitext = new KiSS4.Gui.KissTextEdit();
            this.edtAbsender = new KiSS4.Gui.KissButtonEdit();
            this.chkNichtKlibuRelevant = new KiSS4.Gui.KissCheckEdit();
            this.lblDocumentID = new KiSS4.Gui.KissLabel();
            this.edtFaDokVerwendungCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtDatumErstellung = new KiSS4.Gui.KissDateEdit();
            this.btnBearbeiten = new KiSS4.Gui.KissButton();
            this.btnAktuell = new KiSS4.Gui.KissButton();
            this.btnHistorisieren = new KiSS4.Gui.KissButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHinweisDefaultSuche = new KiSS4.Gui.KissLabel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.colPendenzDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPendenzMitarbeiter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPendenzStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPendenzText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnAlle = new KiSS4.Gui.KissButton();
            this.btnKeine = new KiSS4.Gui.KissButton();
            this.edtInklIKAAuszuege = new KiSS4.Gui.KissCheckEdit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFaDokumente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaDokumente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFaDokumente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAbsender.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAdressat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStichwort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFaDokThemaCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFaDokThemaCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFaDokVisumStatusCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFaDokVisumStatusCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFaDokStatusCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFaDokStatusCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFaDokVerwendungCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFaDokVerwendungCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKlibuRelevant.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNichtKlibuRelevant.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaDokKorreSucheDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaDokKorreSucheAbsender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaDokKorreSucheAdressat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaDokKorreSucheStichwort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaDokKorreSucheDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheThemen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVisumCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDokStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVerwendung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBetrifftPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBemerkung)).BeginInit();
            this.tabDocument.SuspendLayout();
            this.tpgVisum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdXTask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXTask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvXTask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memBemerkungAnfrage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgpAnfrage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgpAnfrage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memBemerkungAntwort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            this.tpgDocument.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtVisumStatusDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokVisumStatusCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokVisumStatusCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusLetztDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokStatusCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokStatusCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusSetUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatusLetztDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatusSetUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaDokStatusCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVisumPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVisumPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaDokThemaCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVisumStatusDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaDokVisumStatusCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaDokVerwendungCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docDokument.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokThemaCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokThemaCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbsender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichwort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdressat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdressatFreitext.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichwort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdressat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumErstellung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbsenderFreitext.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbsender.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNichtKlibuRelevant.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDocumentID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokVerwendungCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokVerwendungCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumErstellung.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblHinweisDefaultSuche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInklIKAAuszuege.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(694, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSearch.Location = new System.Drawing.Point(0, 30);
            this.tabControlSearch.Size = new System.Drawing.Size(718, 311);
            this.tabControlSearch.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControlSearch_SelectedTabChanged);
            this.tabControlSearch.SelectedTabChanging += new System.ComponentModel.CancelEventHandler(this.tabControlSearch_SelectedTabChanging);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.btnAlle);
            this.tpgListe.Controls.Add(this.btnKeine);
            this.tpgListe.Controls.Add(this.grdFaDokumente);
            this.tpgListe.Controls.Add(this.btnBearbeiten);
            this.tpgListe.Controls.Add(this.btnAktuell);
            this.tpgListe.Controls.Add(this.btnHistorisieren);
            this.tpgListe.Size = new System.Drawing.Size(706, 273);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtInklIKAAuszuege);
            this.tpgSuchen.Controls.Add(this.lblSucheBemerkung);
            this.tpgSuchen.Controls.Add(this.lblSucheBetrifftPerson);
            this.tpgSuchen.Controls.Add(this.lblSucheVerwendung);
            this.tpgSuchen.Controls.Add(this.lblSucheDokStatus);
            this.tpgSuchen.Controls.Add(this.lblSucheVisumCode);
            this.tpgSuchen.Controls.Add(this.lblSucheThemen);
            this.tpgSuchen.Controls.Add(this.lblFaDokKorreSucheDatumBis);
            this.tpgSuchen.Controls.Add(this.lblFaDokKorreSucheStichwort);
            this.tpgSuchen.Controls.Add(this.lblFaDokKorreSucheAdressat);
            this.tpgSuchen.Controls.Add(this.lblFaDokKorreSucheAbsender);
            this.tpgSuchen.Controls.Add(this.lblFaDokKorreSucheDatumVon);
            this.tpgSuchen.Controls.Add(this.edtSucheNichtKlibuRelevant);
            this.tpgSuchen.Controls.Add(this.edtSucheKlibuRelevant);
            this.tpgSuchen.Controls.Add(this.edtSucheBaPersonID);
            this.tpgSuchen.Controls.Add(this.edtSucheFaDokVerwendungCode);
            this.tpgSuchen.Controls.Add(this.edtSucheFaDokStatusCode);
            this.tpgSuchen.Controls.Add(this.edtSucheFaDokVisumStatusCode);
            this.tpgSuchen.Controls.Add(this.edtSucheBemerkung);
            this.tpgSuchen.Controls.Add(this.edtSucheFaDokThemaCode);
            this.tpgSuchen.Controls.Add(this.edtSucheStichwort);
            this.tpgSuchen.Controls.Add(this.edtSucheAdressat);
            this.tpgSuchen.Controls.Add(this.edtSucheAbsender);
            this.tpgSuchen.Controls.Add(this.edtSucheDatumBis);
            this.tpgSuchen.Controls.Add(this.edtSucheDatumVon);
            this.tpgSuchen.Size = new System.Drawing.Size(706, 273);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheAbsender, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheAdressat, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheStichwort, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheFaDokThemaCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBemerkung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheFaDokVisumStatusCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheFaDokStatusCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheFaDokVerwendungCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBaPersonID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheKlibuRelevant, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheNichtKlibuRelevant, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblFaDokKorreSucheDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblFaDokKorreSucheAbsender, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblFaDokKorreSucheAdressat, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblFaDokKorreSucheStichwort, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblFaDokKorreSucheDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheThemen, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheVisumCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheDokStatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheVerwendung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBetrifftPerson, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBemerkung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtInklIKAAuszuege, 0);
            // 
            // grdFaDokumente
            // 
            this.grdFaDokumente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdFaDokumente.DataSource = this.qryFaDokumente;
            // 
            // 
            // 
            this.grdFaDokumente.EmbeddedNavigator.Name = "gridCtlKiSS3UserMask_Fa_Dok_Korrespondenz.EmbeddedNavigator";
            this.grdFaDokumente.Location = new System.Drawing.Point(0, -3);
            this.grdFaDokumente.MainView = this.grvFaDokumente;
            this.grdFaDokumente.Name = "grdFaDokumente";
            this.grdFaDokumente.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.grdFaDokumente.Size = new System.Drawing.Size(703, 242);
            this.grdFaDokumente.TabIndex = 0;
            this.grdFaDokumente.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvFaDokumente,
            this.gridView1});
            // 
            // qryFaDokumente
            // 
            this.qryFaDokumente.CanDelete = true;
            this.qryFaDokumente.CanInsert = true;
            this.qryFaDokumente.CanUpdate = true;
            this.qryFaDokumente.HostControl = this;
            this.qryFaDokumente.TableName = "FaDokumente";
            this.qryFaDokumente.AfterFill += new System.EventHandler(this.qryFaDokumente_AfterFill);
            this.qryFaDokumente.AfterInsert += new System.EventHandler(this.qryFaDokumente_AfterInsert);
            this.qryFaDokumente.BeforePost += new System.EventHandler(this.qryFaDokumente_BeforePost);
            this.qryFaDokumente.BeforeDeleteQuestion += new System.EventHandler(this.qryFaDokumente_BeforeDeleteQuestion);
            this.qryFaDokumente.PositionChanged += new System.EventHandler(this.qryFaDokumente_PositionChanged);
            // 
            // grvFaDokumente
            // 
            this.grvFaDokumente.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvFaDokumente.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaDokumente.Appearance.Empty.Options.UseBackColor = true;
            this.grvFaDokumente.Appearance.Empty.Options.UseFont = true;
            this.grvFaDokumente.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvFaDokumente.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaDokumente.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvFaDokumente.Appearance.EvenRow.Options.UseFont = true;
            this.grvFaDokumente.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFaDokumente.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaDokumente.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvFaDokumente.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvFaDokumente.Appearance.FocusedCell.Options.UseFont = true;
            this.grvFaDokumente.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvFaDokumente.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFaDokumente.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaDokumente.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvFaDokumente.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvFaDokumente.Appearance.FocusedRow.Options.UseFont = true;
            this.grvFaDokumente.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvFaDokumente.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFaDokumente.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvFaDokumente.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFaDokumente.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFaDokumente.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFaDokumente.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvFaDokumente.Appearance.GroupRow.Options.UseFont = true;
            this.grvFaDokumente.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvFaDokumente.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvFaDokumente.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvFaDokumente.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFaDokumente.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvFaDokumente.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvFaDokumente.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvFaDokumente.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvFaDokumente.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaDokumente.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFaDokumente.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvFaDokumente.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvFaDokumente.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvFaDokumente.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvFaDokumente.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvFaDokumente.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaDokumente.Appearance.OddRow.Options.UseFont = true;
            this.grvFaDokumente.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvFaDokumente.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaDokumente.Appearance.Row.Options.UseBackColor = true;
            this.grvFaDokumente.Appearance.Row.Options.UseFont = true;
            this.grvFaDokumente.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvFaDokumente.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaDokumente.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvFaDokumente.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvFaDokumente.Appearance.SelectedRow.Options.UseFont = true;
            this.grvFaDokumente.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvFaDokumente.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvFaDokumente.Appearance.VertLine.Options.UseBackColor = true;
            this.grvFaDokumente.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvFaDokumente.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatum,
            this.colStichworte,
            this.colFaDokThemaCode,
            this.colAbsender,
            this.colAdressat,
            this.colFaDokVisumStatusCode,
            this.colFaDokStatusCode,
            this.colErsteller,
            this.colErstellerOrgUnit,
            this.colFaDokVerwendungCode,
            this.colBetrifftPerson,
            this.colSelected});
            this.grvFaDokumente.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvFaDokumente.GridControl = this.grdFaDokumente;
            this.grvFaDokumente.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvFaDokumente.Name = "grvFaDokumente";
            this.grvFaDokumente.OptionsCustomization.AllowFilter = false;
            this.grvFaDokumente.OptionsFilter.AllowFilterEditor = false;
            this.grvFaDokumente.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvFaDokumente.OptionsMenu.EnableColumnMenu = false;
            this.grvFaDokumente.OptionsNavigation.AutoFocusNewRow = true;
            this.grvFaDokumente.OptionsNavigation.UseTabKey = false;
            this.grvFaDokumente.OptionsView.ColumnAutoWidth = false;
            this.grvFaDokumente.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvFaDokumente.OptionsView.ShowGroupPanel = false;
            this.grvFaDokumente.OptionsView.ShowIndicator = false;
            // 
            // colDatum
            // 
            this.colDatum.Caption = "Datum";
            this.colDatum.FieldName = "DatumErstellung";
            this.colDatum.Name = "colDatum";
            this.colDatum.OptionsColumn.AllowEdit = false;
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 1;
            this.colDatum.Width = 68;
            // 
            // colStichworte
            // 
            this.colStichworte.Caption = "Stichwort(e)";
            this.colStichworte.FieldName = "Stichwort";
            this.colStichworte.Name = "colStichworte";
            this.colStichworte.OptionsColumn.AllowEdit = false;
            this.colStichworte.Visible = true;
            this.colStichworte.VisibleIndex = 2;
            this.colStichworte.Width = 200;
            // 
            // colFaDokThemaCode
            // 
            this.colFaDokThemaCode.Caption = "Thema";
            this.colFaDokThemaCode.FieldName = "FaDokThemaCode";
            this.colFaDokThemaCode.Name = "colFaDokThemaCode";
            this.colFaDokThemaCode.OptionsColumn.AllowEdit = false;
            this.colFaDokThemaCode.Visible = true;
            this.colFaDokThemaCode.VisibleIndex = 3;
            this.colFaDokThemaCode.Width = 131;
            // 
            // colAbsender
            // 
            this.colAbsender.Caption = "Absender";
            this.colAbsender.FieldName = "AbsenderName";
            this.colAbsender.Name = "colAbsender";
            this.colAbsender.OptionsColumn.AllowEdit = false;
            this.colAbsender.Visible = true;
            this.colAbsender.VisibleIndex = 4;
            this.colAbsender.Width = 102;
            // 
            // colAdressat
            // 
            this.colAdressat.Caption = "Adressat";
            this.colAdressat.FieldName = "AdressatName";
            this.colAdressat.Name = "colAdressat";
            this.colAdressat.OptionsColumn.AllowEdit = false;
            this.colAdressat.Visible = true;
            this.colAdressat.VisibleIndex = 5;
            this.colAdressat.Width = 95;
            // 
            // colFaDokVisumStatusCode
            // 
            this.colFaDokVisumStatusCode.Caption = "Visum";
            this.colFaDokVisumStatusCode.FieldName = "FaDokVisumStatusCode";
            this.colFaDokVisumStatusCode.Name = "colFaDokVisumStatusCode";
            this.colFaDokVisumStatusCode.OptionsColumn.AllowEdit = false;
            this.colFaDokVisumStatusCode.Visible = true;
            this.colFaDokVisumStatusCode.VisibleIndex = 6;
            this.colFaDokVisumStatusCode.Width = 47;
            // 
            // colFaDokStatusCode
            // 
            this.colFaDokStatusCode.Caption = "Status";
            this.colFaDokStatusCode.FieldName = "FaDokStatusCode";
            this.colFaDokStatusCode.Name = "colFaDokStatusCode";
            this.colFaDokStatusCode.OptionsColumn.AllowEdit = false;
            this.colFaDokStatusCode.Visible = true;
            this.colFaDokStatusCode.VisibleIndex = 7;
            this.colFaDokStatusCode.Width = 48;
            // 
            // colErsteller
            // 
            this.colErsteller.Caption = "Erfasser";
            this.colErsteller.FieldName = "Ersteller";
            this.colErsteller.Name = "colErsteller";
            this.colErsteller.OptionsColumn.AllowEdit = false;
            this.colErsteller.Visible = true;
            this.colErsteller.VisibleIndex = 8;
            // 
            // colErstellerOrgUnit
            // 
            this.colErstellerOrgUnit.Caption = "Ersteller OE";
            this.colErstellerOrgUnit.FieldName = "ErstellerOrgUnit";
            this.colErstellerOrgUnit.Name = "colErstellerOrgUnit";
            this.colErstellerOrgUnit.OptionsColumn.AllowEdit = false;
            this.colErstellerOrgUnit.Visible = true;
            this.colErstellerOrgUnit.VisibleIndex = 9;
            // 
            // colFaDokVerwendungCode
            // 
            this.colFaDokVerwendungCode.Caption = "Post";
            this.colFaDokVerwendungCode.FieldName = "FaDokVerwendungCode";
            this.colFaDokVerwendungCode.Name = "colFaDokVerwendungCode";
            this.colFaDokVerwendungCode.OptionsColumn.AllowEdit = false;
            this.colFaDokVerwendungCode.Visible = true;
            this.colFaDokVerwendungCode.VisibleIndex = 10;
            this.colFaDokVerwendungCode.Width = 60;
            // 
            // colBetrifftPerson
            // 
            this.colBetrifftPerson.Caption = "betrifft Person";
            this.colBetrifftPerson.FieldName = "BaPersonID";
            this.colBetrifftPerson.Name = "colBetrifftPerson";
            this.colBetrifftPerson.OptionsColumn.AllowEdit = false;
            this.colBetrifftPerson.Visible = true;
            this.colBetrifftPerson.VisibleIndex = 11;
            this.colBetrifftPerson.Width = 200;
            // 
            // colSelected
            // 
            this.colSelected.Caption = "Sel.";
            this.colSelected.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colSelected.FieldName = "Selected";
            this.colSelected.Name = "colSelected";
            this.colSelected.Visible = true;
            this.colSelected.VisibleIndex = 0;
            this.colSelected.Width = 32;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdFaDokumente;
            this.gridView1.Name = "gridView1";
            // 
            // edtSucheDatumVon
            // 
            this.edtSucheDatumVon.EditValue = null;
            this.edtSucheDatumVon.Location = new System.Drawing.Point(87, 39);
            this.edtSucheDatumVon.Name = "edtSucheDatumVon";
            this.edtSucheDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject18.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject18.Options.UseBackColor = true;
            this.edtSucheDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject18)});
            this.edtSucheDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheDatumVon.Properties.ShowToday = false;
            this.edtSucheDatumVon.Size = new System.Drawing.Size(116, 24);
            this.edtSucheDatumVon.TabIndex = 0;
            // 
            // edtSucheDatumBis
            // 
            this.edtSucheDatumBis.EditValue = null;
            this.edtSucheDatumBis.Location = new System.Drawing.Point(299, 39);
            this.edtSucheDatumBis.Name = "edtSucheDatumBis";
            this.edtSucheDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject17.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject17.Options.UseBackColor = true;
            this.edtSucheDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject17)});
            this.edtSucheDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheDatumBis.Properties.ShowToday = false;
            this.edtSucheDatumBis.Size = new System.Drawing.Size(104, 24);
            this.edtSucheDatumBis.TabIndex = 1;
            // 
            // edtSucheAbsender
            // 
            this.edtSucheAbsender.Location = new System.Drawing.Point(87, 69);
            this.edtSucheAbsender.Name = "edtSucheAbsender";
            this.edtSucheAbsender.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheAbsender.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheAbsender.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheAbsender.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheAbsender.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheAbsender.Properties.Appearance.Options.UseFont = true;
            this.edtSucheAbsender.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheAbsender.Size = new System.Drawing.Size(316, 24);
            this.edtSucheAbsender.TabIndex = 2;
            // 
            // edtSucheAdressat
            // 
            this.edtSucheAdressat.Location = new System.Drawing.Point(87, 99);
            this.edtSucheAdressat.Name = "edtSucheAdressat";
            this.edtSucheAdressat.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheAdressat.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheAdressat.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheAdressat.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheAdressat.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheAdressat.Properties.Appearance.Options.UseFont = true;
            this.edtSucheAdressat.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheAdressat.Size = new System.Drawing.Size(316, 24);
            this.edtSucheAdressat.TabIndex = 3;
            // 
            // edtSucheStichwort
            // 
            this.edtSucheStichwort.Location = new System.Drawing.Point(87, 129);
            this.edtSucheStichwort.Name = "edtSucheStichwort";
            this.edtSucheStichwort.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheStichwort.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheStichwort.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheStichwort.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheStichwort.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheStichwort.Properties.Appearance.Options.UseFont = true;
            this.edtSucheStichwort.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheStichwort.Size = new System.Drawing.Size(316, 24);
            this.edtSucheStichwort.TabIndex = 4;
            // 
            // edtSucheFaDokThemaCode
            // 
            this.edtSucheFaDokThemaCode.Location = new System.Drawing.Point(87, 159);
            this.edtSucheFaDokThemaCode.LOVFilter = "F";
            this.edtSucheFaDokThemaCode.LOVName = "FaDokThema";
            this.edtSucheFaDokThemaCode.Name = "edtSucheFaDokThemaCode";
            this.edtSucheFaDokThemaCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheFaDokThemaCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheFaDokThemaCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheFaDokThemaCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheFaDokThemaCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheFaDokThemaCode.Properties.Appearance.Options.UseFont = true;
            this.edtSucheFaDokThemaCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheFaDokThemaCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheFaDokThemaCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheFaDokThemaCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheFaDokThemaCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject16.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject16.Options.UseBackColor = true;
            this.edtSucheFaDokThemaCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject16)});
            this.edtSucheFaDokThemaCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheFaDokThemaCode.Properties.NullText = "";
            this.edtSucheFaDokThemaCode.Properties.ShowFooter = false;
            this.edtSucheFaDokThemaCode.Properties.ShowHeader = false;
            this.edtSucheFaDokThemaCode.Size = new System.Drawing.Size(316, 24);
            this.edtSucheFaDokThemaCode.TabIndex = 5;
            // 
            // edtSucheBemerkung
            // 
            this.edtSucheBemerkung.Location = new System.Drawing.Point(87, 189);
            this.edtSucheBemerkung.Name = "edtSucheBemerkung";
            this.edtSucheBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheBemerkung.Size = new System.Drawing.Size(316, 24);
            this.edtSucheBemerkung.TabIndex = 6;
            // 
            // edtSucheFaDokVisumStatusCode
            // 
            this.edtSucheFaDokVisumStatusCode.Location = new System.Drawing.Point(523, 39);
            this.edtSucheFaDokVisumStatusCode.LOVName = "FaDokVisumStatus";
            this.edtSucheFaDokVisumStatusCode.Name = "edtSucheFaDokVisumStatusCode";
            this.edtSucheFaDokVisumStatusCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheFaDokVisumStatusCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheFaDokVisumStatusCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheFaDokVisumStatusCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheFaDokVisumStatusCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheFaDokVisumStatusCode.Properties.Appearance.Options.UseFont = true;
            this.edtSucheFaDokVisumStatusCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheFaDokVisumStatusCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheFaDokVisumStatusCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheFaDokVisumStatusCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheFaDokVisumStatusCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject15.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject15.Options.UseBackColor = true;
            this.edtSucheFaDokVisumStatusCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject15)});
            this.edtSucheFaDokVisumStatusCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheFaDokVisumStatusCode.Properties.NullText = "";
            this.edtSucheFaDokVisumStatusCode.Properties.ShowFooter = false;
            this.edtSucheFaDokVisumStatusCode.Properties.ShowHeader = false;
            this.edtSucheFaDokVisumStatusCode.Size = new System.Drawing.Size(172, 24);
            this.edtSucheFaDokVisumStatusCode.TabIndex = 7;
            // 
            // edtSucheFaDokStatusCode
            // 
            this.edtSucheFaDokStatusCode.Location = new System.Drawing.Point(523, 69);
            this.edtSucheFaDokStatusCode.LOVName = "FaDokStatus";
            this.edtSucheFaDokStatusCode.Name = "edtSucheFaDokStatusCode";
            this.edtSucheFaDokStatusCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheFaDokStatusCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheFaDokStatusCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheFaDokStatusCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheFaDokStatusCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheFaDokStatusCode.Properties.Appearance.Options.UseFont = true;
            this.edtSucheFaDokStatusCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheFaDokStatusCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheFaDokStatusCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheFaDokStatusCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheFaDokStatusCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject14.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject14.Options.UseBackColor = true;
            this.edtSucheFaDokStatusCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject14)});
            this.edtSucheFaDokStatusCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheFaDokStatusCode.Properties.NullText = "";
            this.edtSucheFaDokStatusCode.Properties.ShowFooter = false;
            this.edtSucheFaDokStatusCode.Properties.ShowHeader = false;
            this.edtSucheFaDokStatusCode.Size = new System.Drawing.Size(172, 24);
            this.edtSucheFaDokStatusCode.TabIndex = 8;
            // 
            // edtSucheFaDokVerwendungCode
            // 
            this.edtSucheFaDokVerwendungCode.Location = new System.Drawing.Point(523, 99);
            this.edtSucheFaDokVerwendungCode.LOVName = "FaDokVerwendung";
            this.edtSucheFaDokVerwendungCode.Name = "edtSucheFaDokVerwendungCode";
            this.edtSucheFaDokVerwendungCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheFaDokVerwendungCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheFaDokVerwendungCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheFaDokVerwendungCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheFaDokVerwendungCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheFaDokVerwendungCode.Properties.Appearance.Options.UseFont = true;
            this.edtSucheFaDokVerwendungCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheFaDokVerwendungCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheFaDokVerwendungCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheFaDokVerwendungCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheFaDokVerwendungCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject13.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject13.Options.UseBackColor = true;
            this.edtSucheFaDokVerwendungCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13)});
            this.edtSucheFaDokVerwendungCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheFaDokVerwendungCode.Properties.NullText = "";
            this.edtSucheFaDokVerwendungCode.Properties.ShowFooter = false;
            this.edtSucheFaDokVerwendungCode.Properties.ShowHeader = false;
            this.edtSucheFaDokVerwendungCode.Size = new System.Drawing.Size(172, 24);
            this.edtSucheFaDokVerwendungCode.TabIndex = 9;
            // 
            // edtSucheBaPersonID
            // 
            this.edtSucheBaPersonID.Location = new System.Drawing.Point(523, 129);
            this.edtSucheBaPersonID.Name = "edtSucheBaPersonID";
            this.edtSucheBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBaPersonID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheBaPersonID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBaPersonID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheBaPersonID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.edtSucheBaPersonID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.edtSucheBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheBaPersonID.Properties.NullText = "";
            this.edtSucheBaPersonID.Properties.ShowFooter = false;
            this.edtSucheBaPersonID.Properties.ShowHeader = false;
            this.edtSucheBaPersonID.Size = new System.Drawing.Size(172, 24);
            this.edtSucheBaPersonID.TabIndex = 10;
            // 
            // edtSucheKlibuRelevant
            // 
            this.edtSucheKlibuRelevant.EditValue = true;
            this.edtSucheKlibuRelevant.Location = new System.Drawing.Point(523, 163);
            this.edtSucheKlibuRelevant.Name = "edtSucheKlibuRelevant";
            this.edtSucheKlibuRelevant.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtSucheKlibuRelevant.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheKlibuRelevant.Properties.Caption = "Klibu relevant";
            this.edtSucheKlibuRelevant.Size = new System.Drawing.Size(172, 19);
            this.edtSucheKlibuRelevant.TabIndex = 11;
            // 
            // edtSucheNichtKlibuRelevant
            // 
            this.edtSucheNichtKlibuRelevant.EditValue = true;
            this.edtSucheNichtKlibuRelevant.Location = new System.Drawing.Point(523, 181);
            this.edtSucheNichtKlibuRelevant.Name = "edtSucheNichtKlibuRelevant";
            this.edtSucheNichtKlibuRelevant.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtSucheNichtKlibuRelevant.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheNichtKlibuRelevant.Properties.Caption = "nicht Klibu relevant";
            this.edtSucheNichtKlibuRelevant.Size = new System.Drawing.Size(183, 19);
            this.edtSucheNichtKlibuRelevant.TabIndex = 12;
            // 
            // lblFaDokKorreSucheDatumVon
            // 
            this.lblFaDokKorreSucheDatumVon.Location = new System.Drawing.Point(8, 39);
            this.lblFaDokKorreSucheDatumVon.Name = "lblFaDokKorreSucheDatumVon";
            this.lblFaDokKorreSucheDatumVon.Size = new System.Drawing.Size(72, 24);
            this.lblFaDokKorreSucheDatumVon.TabIndex = 13;
            this.lblFaDokKorreSucheDatumVon.Text = "Datum von";
            this.lblFaDokKorreSucheDatumVon.UseCompatibleTextRendering = true;
            // 
            // lblFaDokKorreSucheAbsender
            // 
            this.lblFaDokKorreSucheAbsender.Location = new System.Drawing.Point(8, 69);
            this.lblFaDokKorreSucheAbsender.Name = "lblFaDokKorreSucheAbsender";
            this.lblFaDokKorreSucheAbsender.Size = new System.Drawing.Size(72, 24);
            this.lblFaDokKorreSucheAbsender.TabIndex = 14;
            this.lblFaDokKorreSucheAbsender.Text = "Absender/in";
            this.lblFaDokKorreSucheAbsender.UseCompatibleTextRendering = true;
            // 
            // lblFaDokKorreSucheAdressat
            // 
            this.lblFaDokKorreSucheAdressat.Location = new System.Drawing.Point(8, 99);
            this.lblFaDokKorreSucheAdressat.Name = "lblFaDokKorreSucheAdressat";
            this.lblFaDokKorreSucheAdressat.Size = new System.Drawing.Size(72, 24);
            this.lblFaDokKorreSucheAdressat.TabIndex = 15;
            this.lblFaDokKorreSucheAdressat.Text = "Adressat/in";
            this.lblFaDokKorreSucheAdressat.UseCompatibleTextRendering = true;
            // 
            // lblFaDokKorreSucheStichwort
            // 
            this.lblFaDokKorreSucheStichwort.Location = new System.Drawing.Point(8, 129);
            this.lblFaDokKorreSucheStichwort.Name = "lblFaDokKorreSucheStichwort";
            this.lblFaDokKorreSucheStichwort.Size = new System.Drawing.Size(72, 24);
            this.lblFaDokKorreSucheStichwort.TabIndex = 17;
            this.lblFaDokKorreSucheStichwort.Text = "Stichwort(e)";
            this.lblFaDokKorreSucheStichwort.UseCompatibleTextRendering = true;
            // 
            // lblFaDokKorreSucheDatumBis
            // 
            this.lblFaDokKorreSucheDatumBis.Location = new System.Drawing.Point(270, 39);
            this.lblFaDokKorreSucheDatumBis.Name = "lblFaDokKorreSucheDatumBis";
            this.lblFaDokKorreSucheDatumBis.Size = new System.Drawing.Size(23, 24);
            this.lblFaDokKorreSucheDatumBis.TabIndex = 19;
            this.lblFaDokKorreSucheDatumBis.Text = "bis";
            this.lblFaDokKorreSucheDatumBis.UseCompatibleTextRendering = true;
            // 
            // lblSucheThemen
            // 
            this.lblSucheThemen.Location = new System.Drawing.Point(8, 159);
            this.lblSucheThemen.Name = "lblSucheThemen";
            this.lblSucheThemen.Size = new System.Drawing.Size(73, 24);
            this.lblSucheThemen.TabIndex = 25;
            this.lblSucheThemen.Text = "Thema";
            this.lblSucheThemen.UseCompatibleTextRendering = true;
            // 
            // lblSucheVisumCode
            // 
            this.lblSucheVisumCode.Location = new System.Drawing.Point(428, 39);
            this.lblSucheVisumCode.Name = "lblSucheVisumCode";
            this.lblSucheVisumCode.Size = new System.Drawing.Size(92, 24);
            this.lblSucheVisumCode.TabIndex = 27;
            this.lblSucheVisumCode.Text = "Visum Status";
            this.lblSucheVisumCode.UseCompatibleTextRendering = true;
            // 
            // lblSucheDokStatus
            // 
            this.lblSucheDokStatus.Location = new System.Drawing.Point(428, 69);
            this.lblSucheDokStatus.Name = "lblSucheDokStatus";
            this.lblSucheDokStatus.Size = new System.Drawing.Size(93, 24);
            this.lblSucheDokStatus.TabIndex = 28;
            this.lblSucheDokStatus.Text = "Dokumente Status";
            this.lblSucheDokStatus.UseCompatibleTextRendering = true;
            // 
            // lblSucheVerwendung
            // 
            this.lblSucheVerwendung.Location = new System.Drawing.Point(428, 99);
            this.lblSucheVerwendung.Name = "lblSucheVerwendung";
            this.lblSucheVerwendung.Size = new System.Drawing.Size(94, 24);
            this.lblSucheVerwendung.TabIndex = 29;
            this.lblSucheVerwendung.Text = "Ein/Aus/Intern";
            this.lblSucheVerwendung.UseCompatibleTextRendering = true;
            // 
            // lblSucheBetrifftPerson
            // 
            this.lblSucheBetrifftPerson.Location = new System.Drawing.Point(428, 129);
            this.lblSucheBetrifftPerson.Name = "lblSucheBetrifftPerson";
            this.lblSucheBetrifftPerson.Size = new System.Drawing.Size(92, 24);
            this.lblSucheBetrifftPerson.TabIndex = 30;
            this.lblSucheBetrifftPerson.Text = "betrifft Person";
            this.lblSucheBetrifftPerson.UseCompatibleTextRendering = true;
            // 
            // lblSucheBemerkung
            // 
            this.lblSucheBemerkung.Location = new System.Drawing.Point(8, 189);
            this.lblSucheBemerkung.Name = "lblSucheBemerkung";
            this.lblSucheBemerkung.Size = new System.Drawing.Size(73, 24);
            this.lblSucheBemerkung.TabIndex = 31;
            this.lblSucheBemerkung.Text = "Bemerkung";
            this.lblSucheBemerkung.UseCompatibleTextRendering = true;
            // 
            // tabDocument
            // 
            this.tabDocument.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabDocument.Controls.Add(this.tpgVisum);
            this.tabDocument.Controls.Add(this.tpgDocument);
            this.tabDocument.Location = new System.Drawing.Point(0, 347);
            this.tabDocument.Name = "tabDocument";
            this.tabDocument.ShowFixedWidthTooltip = true;
            this.tabDocument.Size = new System.Drawing.Size(721, 287);
            this.tabDocument.TabIndex = 1;
            this.tabDocument.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgDocument,
            this.tpgVisum});
            this.tabDocument.TabsLineColor = System.Drawing.Color.Black;
            this.tabDocument.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabDocument.Text = "kissTabControlEx1";
            this.tabDocument.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabDocument_SelectedTabChanged);
            this.tabDocument.SelectedTabChanging += new System.ComponentModel.CancelEventHandler(this.tabDocument_SelectedTabChanging);
            // 
            // tpgVisum
            // 
            this.tpgVisum.Controls.Add(this.grdXTask);
            this.tpgVisum.Controls.Add(this.memBemerkungAnfrage);
            this.tpgVisum.Controls.Add(this.rgpAnfrage);
            this.tpgVisum.Controls.Add(this.memBemerkungAntwort);
            this.tpgVisum.Controls.Add(this.kissLabel4);
            this.tpgVisum.Controls.Add(this.btnWiederrufen);
            this.tpgVisum.Controls.Add(this.btnAntworten);
            this.tpgVisum.Controls.Add(this.btnAnfrage);
            this.tpgVisum.Location = new System.Drawing.Point(6, 6);
            this.tpgVisum.Name = "tpgVisum";
            this.tpgVisum.Size = new System.Drawing.Size(709, 249);
            this.tpgVisum.TabIndex = 1;
            this.tpgVisum.Title = "Visum";
            // 
            // grdXTask
            // 
            this.grdXTask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdXTask.DataSource = this.qryXTask;
            // 
            // 
            // 
            this.grdXTask.EmbeddedNavigator.Name = "";
            this.grdXTask.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdXTask.Location = new System.Drawing.Point(4, 3);
            this.grdXTask.MainView = this.grvXTask;
            this.grdXTask.Name = "grdXTask";
            this.grdXTask.Size = new System.Drawing.Size(705, 182);
            this.grdXTask.TabIndex = 6;
            this.grdXTask.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvXTask});
            // 
            // qryXTask
            // 
            this.qryXTask.HostControl = this;
            this.qryXTask.SelectStatement = resources.GetString("qryXTask.SelectStatement");
            this.qryXTask.TableName = "XTask";
            this.qryXTask.AfterFill += new System.EventHandler(this.qryXTask_AfterFill);
            this.qryXTask.PositionChanged += new System.EventHandler(this.qryXTask_PositionChanged);
            // 
            // grvXTask
            // 
            this.grvXTask.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvXTask.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXTask.Appearance.Empty.Options.UseBackColor = true;
            this.grvXTask.Appearance.Empty.Options.UseFont = true;
            this.grvXTask.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXTask.Appearance.EvenRow.Options.UseFont = true;
            this.grvXTask.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvXTask.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXTask.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvXTask.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvXTask.Appearance.FocusedCell.Options.UseFont = true;
            this.grvXTask.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvXTask.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvXTask.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXTask.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvXTask.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvXTask.Appearance.FocusedRow.Options.UseFont = true;
            this.grvXTask.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvXTask.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvXTask.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvXTask.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvXTask.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvXTask.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvXTask.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvXTask.Appearance.GroupRow.Options.UseFont = true;
            this.grvXTask.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvXTask.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvXTask.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvXTask.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvXTask.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvXTask.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvXTask.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvXTask.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvXTask.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXTask.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvXTask.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvXTask.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvXTask.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvXTask.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvXTask.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvXTask.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXTask.Appearance.OddRow.Options.UseFont = true;
            this.grvXTask.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvXTask.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXTask.Appearance.Row.Options.UseBackColor = true;
            this.grvXTask.Appearance.Row.Options.UseFont = true;
            this.grvXTask.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXTask.Appearance.SelectedRow.Options.UseFont = true;
            this.grvXTask.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvXTask.Appearance.VertLine.Options.UseBackColor = true;
            this.grvXTask.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvXTask.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCreateDate,
            this.colSender,
            this.colReceiver,
            this.colTaskStatusCode,
            this.colPendenzBeantwortet,
            this.colTaskResponseCode,
            this.colPendenzAntwortText,
            this.colFaDokVisumStatusCode_Task});
            this.grvXTask.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvXTask.GridControl = this.grdXTask;
            this.grvXTask.Name = "grvXTask";
            this.grvXTask.OptionsBehavior.Editable = false;
            this.grvXTask.OptionsCustomization.AllowFilter = false;
            this.grvXTask.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvXTask.OptionsNavigation.AutoFocusNewRow = true;
            this.grvXTask.OptionsNavigation.UseTabKey = false;
            this.grvXTask.OptionsView.ColumnAutoWidth = false;
            this.grvXTask.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvXTask.OptionsView.ShowGroupPanel = false;
            this.grvXTask.OptionsView.ShowIndicator = false;
            // 
            // colCreateDate
            // 
            this.colCreateDate.Caption = "Angefragt";
            this.colCreateDate.FieldName = "CreateDate";
            this.colCreateDate.Name = "colCreateDate";
            this.colCreateDate.Visible = true;
            this.colCreateDate.VisibleIndex = 0;
            this.colCreateDate.Width = 70;
            // 
            // colSender
            // 
            this.colSender.Caption = "Absender";
            this.colSender.FieldName = "Sender";
            this.colSender.Name = "colSender";
            this.colSender.Visible = true;
            this.colSender.VisibleIndex = 1;
            this.colSender.Width = 83;
            // 
            // colReceiver
            // 
            this.colReceiver.Caption = "Empfänger";
            this.colReceiver.FieldName = "Receiver";
            this.colReceiver.Name = "colReceiver";
            this.colReceiver.Visible = true;
            this.colReceiver.VisibleIndex = 2;
            this.colReceiver.Width = 83;
            // 
            // colTaskStatusCode
            // 
            this.colTaskStatusCode.Caption = "Status";
            this.colTaskStatusCode.FieldName = "TaskStatusCode";
            this.colTaskStatusCode.Name = "colTaskStatusCode";
            this.colTaskStatusCode.Visible = true;
            this.colTaskStatusCode.VisibleIndex = 3;
            this.colTaskStatusCode.Width = 90;
            // 
            // colPendenzBeantwortet
            // 
            this.colPendenzBeantwortet.Caption = "Datum";
            this.colPendenzBeantwortet.FieldName = "Datum";
            this.colPendenzBeantwortet.Name = "colPendenzBeantwortet";
            this.colPendenzBeantwortet.Visible = true;
            this.colPendenzBeantwortet.VisibleIndex = 4;
            this.colPendenzBeantwortet.Width = 73;
            // 
            // colTaskResponseCode
            // 
            this.colTaskResponseCode.Caption = "Antwort";
            this.colTaskResponseCode.FieldName = "TaskResponseCode";
            this.colTaskResponseCode.Name = "colTaskResponseCode";
            this.colTaskResponseCode.Visible = true;
            this.colTaskResponseCode.VisibleIndex = 5;
            this.colTaskResponseCode.Width = 84;
            // 
            // colPendenzAntwortText
            // 
            this.colPendenzAntwortText.Caption = "Bemerkung (Antwort)";
            this.colPendenzAntwortText.FieldName = "ResponseText";
            this.colPendenzAntwortText.Name = "colPendenzAntwortText";
            this.colPendenzAntwortText.Visible = true;
            this.colPendenzAntwortText.VisibleIndex = 6;
            this.colPendenzAntwortText.Width = 131;
            // 
            // colFaDokVisumStatusCode_Task
            // 
            this.colFaDokVisumStatusCode_Task.Caption = "Dok. Visum";
            this.colFaDokVisumStatusCode_Task.FieldName = "FaDokVisumStatusCode";
            this.colFaDokVisumStatusCode_Task.Name = "colFaDokVisumStatusCode_Task";
            this.colFaDokVisumStatusCode_Task.Visible = true;
            this.colFaDokVisumStatusCode_Task.VisibleIndex = 7;
            this.colFaDokVisumStatusCode_Task.Width = 76;
            // 
            // memBemerkungAnfrage
            // 
            this.memBemerkungAnfrage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.memBemerkungAnfrage.DataMember = "TaskDescription";
            this.memBemerkungAnfrage.DataSource = this.qryXTask;
            this.memBemerkungAnfrage.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.memBemerkungAnfrage.Location = new System.Drawing.Point(393, 191);
            this.memBemerkungAnfrage.Name = "memBemerkungAnfrage";
            this.memBemerkungAnfrage.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.memBemerkungAnfrage.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memBemerkungAnfrage.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memBemerkungAnfrage.Properties.Appearance.Options.UseBackColor = true;
            this.memBemerkungAnfrage.Properties.Appearance.Options.UseBorderColor = true;
            this.memBemerkungAnfrage.Properties.Appearance.Options.UseFont = true;
            this.memBemerkungAnfrage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memBemerkungAnfrage.Properties.ReadOnly = true;
            this.memBemerkungAnfrage.Size = new System.Drawing.Size(316, 58);
            this.memBemerkungAnfrage.TabIndex = 5;
            // 
            // rgpAnfrage
            // 
            this.rgpAnfrage.EditValue = 0;
            this.rgpAnfrage.Location = new System.Drawing.Point(312, 206);
            this.rgpAnfrage.LookupSQL = null;
            this.rgpAnfrage.LOVFilter = null;
            this.rgpAnfrage.LOVName = null;
            this.rgpAnfrage.Name = "rgpAnfrage";
            this.rgpAnfrage.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgpAnfrage.Properties.Appearance.Options.UseBackColor = true;
            this.rgpAnfrage.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.rgpAnfrage.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.rgpAnfrage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgpAnfrage.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Anfrage"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Antwort")});
            this.rgpAnfrage.Size = new System.Drawing.Size(75, 49);
            this.rgpAnfrage.TabIndex = 4;
            this.rgpAnfrage.EditValueChanged += new System.EventHandler(this.rgpAnfrage_EditValueChanged);
            // 
            // memBemerkungAntwort
            // 
            this.memBemerkungAntwort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.memBemerkungAntwort.DataMember = "ResponseText";
            this.memBemerkungAntwort.DataSource = this.qryXTask;
            this.memBemerkungAntwort.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.memBemerkungAntwort.Location = new System.Drawing.Point(393, 191);
            this.memBemerkungAntwort.Name = "memBemerkungAntwort";
            this.memBemerkungAntwort.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.memBemerkungAntwort.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memBemerkungAntwort.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memBemerkungAntwort.Properties.Appearance.Options.UseBackColor = true;
            this.memBemerkungAntwort.Properties.Appearance.Options.UseBorderColor = true;
            this.memBemerkungAntwort.Properties.Appearance.Options.UseFont = true;
            this.memBemerkungAntwort.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memBemerkungAntwort.Properties.ReadOnly = true;
            this.memBemerkungAntwort.Size = new System.Drawing.Size(316, 58);
            this.memBemerkungAntwort.TabIndex = 3;
            // 
            // kissLabel4
            // 
            this.kissLabel4.Location = new System.Drawing.Point(312, 187);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(75, 24);
            this.kissLabel4.TabIndex = 3;
            this.kissLabel4.Text = "Bemerkungen";
            this.kissLabel4.UseCompatibleTextRendering = true;
            // 
            // btnWiederrufen
            // 
            this.btnWiederrufen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWiederrufen.Location = new System.Drawing.Point(4, 221);
            this.btnWiederrufen.Name = "btnWiederrufen";
            this.btnWiederrufen.Size = new System.Drawing.Size(114, 24);
            this.btnWiederrufen.TabIndex = 2;
            this.btnWiederrufen.Text = "Rückrufen ...";
            this.btnWiederrufen.UseCompatibleTextRendering = true;
            this.btnWiederrufen.UseVisualStyleBackColor = false;
            this.btnWiederrufen.Click += new System.EventHandler(this.btnWiederrufen_Click);
            // 
            // btnAntworten
            // 
            this.btnAntworten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAntworten.Location = new System.Drawing.Point(124, 191);
            this.btnAntworten.Name = "btnAntworten";
            this.btnAntworten.Size = new System.Drawing.Size(114, 24);
            this.btnAntworten.TabIndex = 1;
            this.btnAntworten.Text = "Antworten...";
            this.btnAntworten.UseCompatibleTextRendering = true;
            this.btnAntworten.UseVisualStyleBackColor = false;
            this.btnAntworten.Click += new System.EventHandler(this.btnAntworten_Click);
            // 
            // btnAnfrage
            // 
            this.btnAnfrage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnfrage.Location = new System.Drawing.Point(4, 191);
            this.btnAnfrage.Name = "btnAnfrage";
            this.btnAnfrage.Size = new System.Drawing.Size(114, 24);
            this.btnAnfrage.TabIndex = 0;
            this.btnAnfrage.Text = "Neue Anfrage...";
            this.btnAnfrage.UseCompatibleTextRendering = true;
            this.btnAnfrage.UseVisualStyleBackColor = false;
            this.btnAnfrage.Click += new System.EventHandler(this.btnAnfrage_Click);
            // 
            // tpgDocument
            // 
            this.tpgDocument.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tpgDocument.Controls.Add(this.edtVisumStatusDatum);
            this.tpgDocument.Controls.Add(this.edtFaDokVisumStatusCode);
            this.tpgDocument.Controls.Add(this.edtStatusLetztDatum);
            this.tpgDocument.Controls.Add(this.edtFaDokStatusCode);
            this.tpgDocument.Controls.Add(this.ctlErfassungMutation);
            this.tpgDocument.Controls.Add(this.edtStatusSetUser);
            this.tpgDocument.Controls.Add(this.lblStatusLetztDatum);
            this.tpgDocument.Controls.Add(this.lblStatusSetUser);
            this.tpgDocument.Controls.Add(this.lblFaDokStatusCode);
            this.tpgDocument.Controls.Add(this.edtVisumPerson);
            this.tpgDocument.Controls.Add(this.lblVisumPerson);
            this.tpgDocument.Controls.Add(this.lblBaPersonID);
            this.tpgDocument.Controls.Add(this.lblFaDokThemaCode);
            this.tpgDocument.Controls.Add(this.lblVisumStatusDatum);
            this.tpgDocument.Controls.Add(this.lblFaDokVisumStatusCode);
            this.tpgDocument.Controls.Add(this.lblBemerkung);
            this.tpgDocument.Controls.Add(this.lblFaDokVerwendungCode);
            this.tpgDocument.Controls.Add(this.edtBemerkung);
            this.tpgDocument.Controls.Add(this.docDokument);
            this.tpgDocument.Controls.Add(this.edtBaPersonID);
            this.tpgDocument.Controls.Add(this.edtFaDokThemaCode);
            this.tpgDocument.Controls.Add(this.lblAbsender);
            this.tpgDocument.Controls.Add(this.edtStichwort);
            this.tpgDocument.Controls.Add(this.lblAdressat);
            this.tpgDocument.Controls.Add(this.edtAdressatFreitext);
            this.tpgDocument.Controls.Add(this.lblStichwort);
            this.tpgDocument.Controls.Add(this.edtAdressat);
            this.tpgDocument.Controls.Add(this.lblDatumErstellung);
            this.tpgDocument.Controls.Add(this.edtAbsenderFreitext);
            this.tpgDocument.Controls.Add(this.edtAbsender);
            this.tpgDocument.Controls.Add(this.chkNichtKlibuRelevant);
            this.tpgDocument.Controls.Add(this.lblDocumentID);
            this.tpgDocument.Controls.Add(this.edtFaDokVerwendungCode);
            this.tpgDocument.Controls.Add(this.edtDatumErstellung);
            this.tpgDocument.Location = new System.Drawing.Point(6, 6);
            this.tpgDocument.Name = "tpgDocument";
            this.tpgDocument.Size = new System.Drawing.Size(709, 249);
            this.tpgDocument.TabIndex = 0;
            this.tpgDocument.Title = "Dokument";
            // 
            // edtVisumStatusDatum
            // 
            this.edtVisumStatusDatum.DataMember = "VisumStatusDatum";
            this.edtVisumStatusDatum.DataSource = this.qryFaDokumente;
            this.edtVisumStatusDatum.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVisumStatusDatum.Location = new System.Drawing.Point(586, 51);
            this.edtVisumStatusDatum.Name = "edtVisumStatusDatum";
            this.edtVisumStatusDatum.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVisumStatusDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVisumStatusDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVisumStatusDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtVisumStatusDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVisumStatusDatum.Properties.Appearance.Options.UseFont = true;
            this.edtVisumStatusDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVisumStatusDatum.Properties.DisplayFormat.FormatString = "d";
            this.edtVisumStatusDatum.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtVisumStatusDatum.Properties.ReadOnly = true;
            this.edtVisumStatusDatum.Size = new System.Drawing.Size(109, 24);
            this.edtVisumStatusDatum.TabIndex = 69;
            this.edtVisumStatusDatum.TabStop = false;
            // 
            // edtFaDokVisumStatusCode
            // 
            this.edtFaDokVisumStatusCode.DataMember = "FaDokVisumStatusCode";
            this.edtFaDokVisumStatusCode.DataSource = this.qryFaDokumente;
            this.edtFaDokVisumStatusCode.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtFaDokVisumStatusCode.Location = new System.Drawing.Point(586, 5);
            this.edtFaDokVisumStatusCode.LOVName = "FaDokVisumStatus";
            this.edtFaDokVisumStatusCode.Name = "edtFaDokVisumStatusCode";
            this.edtFaDokVisumStatusCode.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtFaDokVisumStatusCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaDokVisumStatusCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaDokVisumStatusCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaDokVisumStatusCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaDokVisumStatusCode.Properties.Appearance.Options.UseFont = true;
            this.edtFaDokVisumStatusCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtFaDokVisumStatusCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaDokVisumStatusCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtFaDokVisumStatusCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtFaDokVisumStatusCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFaDokVisumStatusCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFaDokVisumStatusCode.Properties.NullText = "";
            this.edtFaDokVisumStatusCode.Properties.ReadOnly = true;
            this.edtFaDokVisumStatusCode.Properties.ShowFooter = false;
            this.edtFaDokVisumStatusCode.Properties.ShowHeader = false;
            this.edtFaDokVisumStatusCode.Size = new System.Drawing.Size(109, 24);
            this.edtFaDokVisumStatusCode.TabIndex = 68;
            this.edtFaDokVisumStatusCode.TabStop = false;
            // 
            // edtStatusLetztDatum
            // 
            this.edtStatusLetztDatum.DataMember = "StatusLetztDatum";
            this.edtStatusLetztDatum.DataSource = this.qryFaDokumente;
            this.edtStatusLetztDatum.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtStatusLetztDatum.Location = new System.Drawing.Point(586, 140);
            this.edtStatusLetztDatum.Name = "edtStatusLetztDatum";
            this.edtStatusLetztDatum.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtStatusLetztDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStatusLetztDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStatusLetztDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtStatusLetztDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStatusLetztDatum.Properties.Appearance.Options.UseFont = true;
            this.edtStatusLetztDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStatusLetztDatum.Properties.DisplayFormat.FormatString = "d";
            this.edtStatusLetztDatum.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtStatusLetztDatum.Properties.ReadOnly = true;
            this.edtStatusLetztDatum.Size = new System.Drawing.Size(109, 24);
            this.edtStatusLetztDatum.TabIndex = 67;
            this.edtStatusLetztDatum.TabStop = false;
            // 
            // edtFaDokStatusCode
            // 
            this.edtFaDokStatusCode.DataMember = "FaDokStatusCode";
            this.edtFaDokStatusCode.DataSource = this.qryFaDokumente;
            this.edtFaDokStatusCode.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtFaDokStatusCode.Location = new System.Drawing.Point(586, 94);
            this.edtFaDokStatusCode.LOVName = "FaDokStatus";
            this.edtFaDokStatusCode.Name = "edtFaDokStatusCode";
            this.edtFaDokStatusCode.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtFaDokStatusCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaDokStatusCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaDokStatusCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaDokStatusCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaDokStatusCode.Properties.Appearance.Options.UseFont = true;
            this.edtFaDokStatusCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtFaDokStatusCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaDokStatusCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtFaDokStatusCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtFaDokStatusCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFaDokStatusCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFaDokStatusCode.Properties.NullText = "";
            this.edtFaDokStatusCode.Properties.ReadOnly = true;
            this.edtFaDokStatusCode.Properties.ShowFooter = false;
            this.edtFaDokStatusCode.Properties.ShowHeader = false;
            this.edtFaDokStatusCode.Size = new System.Drawing.Size(109, 24);
            this.edtFaDokStatusCode.TabIndex = 66;
            this.edtFaDokStatusCode.TabStop = false;
            // 
            // ctlErfassungMutation
            // 
            this.ctlErfassungMutation.ActiveSQLQuery = this.qryFaDokumente;
            this.ctlErfassungMutation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlErfassungMutation.LabelLength = 60;
            this.ctlErfassungMutation.Location = new System.Drawing.Point(523, 184);
            this.ctlErfassungMutation.Name = "ctlErfassungMutation";
            this.ctlErfassungMutation.Size = new System.Drawing.Size(222, 38);
            this.ctlErfassungMutation.TabIndex = 65;
            this.ctlErfassungMutation.TabStop = false;
            // 
            // edtStatusSetUser
            // 
            this.edtStatusSetUser.DataMember = "StatusLetztUserText";
            this.edtStatusSetUser.DataSource = this.qryFaDokumente;
            this.edtStatusSetUser.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtStatusSetUser.Location = new System.Drawing.Point(586, 117);
            this.edtStatusSetUser.Name = "edtStatusSetUser";
            this.edtStatusSetUser.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtStatusSetUser.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStatusSetUser.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStatusSetUser.Properties.Appearance.Options.UseBackColor = true;
            this.edtStatusSetUser.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStatusSetUser.Properties.Appearance.Options.UseFont = true;
            this.edtStatusSetUser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStatusSetUser.Properties.ReadOnly = true;
            this.edtStatusSetUser.Size = new System.Drawing.Size(109, 24);
            this.edtStatusSetUser.TabIndex = 63;
            this.edtStatusSetUser.TabStop = false;
            // 
            // lblStatusLetztDatum
            // 
            this.lblStatusLetztDatum.Location = new System.Drawing.Point(540, 140);
            this.lblStatusLetztDatum.Name = "lblStatusLetztDatum";
            this.lblStatusLetztDatum.Size = new System.Drawing.Size(40, 24);
            this.lblStatusLetztDatum.TabIndex = 62;
            this.lblStatusLetztDatum.Text = "am";
            this.lblStatusLetztDatum.UseCompatibleTextRendering = true;
            // 
            // lblStatusSetUser
            // 
            this.lblStatusSetUser.Location = new System.Drawing.Point(540, 117);
            this.lblStatusSetUser.Name = "lblStatusSetUser";
            this.lblStatusSetUser.Size = new System.Drawing.Size(37, 24);
            this.lblStatusSetUser.TabIndex = 61;
            this.lblStatusSetUser.Text = "MA";
            this.lblStatusSetUser.UseCompatibleTextRendering = true;
            // 
            // lblFaDokStatusCode
            // 
            this.lblFaDokStatusCode.Location = new System.Drawing.Point(540, 94);
            this.lblFaDokStatusCode.Name = "lblFaDokStatusCode";
            this.lblFaDokStatusCode.Size = new System.Drawing.Size(37, 24);
            this.lblFaDokStatusCode.TabIndex = 60;
            this.lblFaDokStatusCode.Text = "Status";
            this.lblFaDokStatusCode.UseCompatibleTextRendering = true;
            // 
            // edtVisumPerson
            // 
            this.edtVisumPerson.DataMember = "VisumStatusUserText";
            this.edtVisumPerson.DataSource = this.qryFaDokumente;
            this.edtVisumPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVisumPerson.Location = new System.Drawing.Point(586, 28);
            this.edtVisumPerson.Name = "edtVisumPerson";
            this.edtVisumPerson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVisumPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVisumPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVisumPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtVisumPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVisumPerson.Properties.Appearance.Options.UseFont = true;
            this.edtVisumPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVisumPerson.Properties.Name = "edtFaDokKorreStichwort.Properties";
            this.edtVisumPerson.Properties.ReadOnly = true;
            this.edtVisumPerson.Size = new System.Drawing.Size(109, 24);
            this.edtVisumPerson.TabIndex = 55;
            this.edtVisumPerson.TabStop = false;
            // 
            // lblVisumPerson
            // 
            this.lblVisumPerson.Location = new System.Drawing.Point(540, 28);
            this.lblVisumPerson.Name = "lblVisumPerson";
            this.lblVisumPerson.Size = new System.Drawing.Size(37, 24);
            this.lblVisumPerson.TabIndex = 53;
            this.lblVisumPerson.Text = "MA";
            this.lblVisumPerson.UseCompatibleTextRendering = true;
            // 
            // lblBaPersonID
            // 
            this.lblBaPersonID.Location = new System.Drawing.Point(5, 154);
            this.lblBaPersonID.Name = "lblBaPersonID";
            this.lblBaPersonID.Size = new System.Drawing.Size(82, 24);
            this.lblBaPersonID.TabIndex = 51;
            this.lblBaPersonID.Text = "betrifft Person";
            this.lblBaPersonID.UseCompatibleTextRendering = true;
            // 
            // lblFaDokThemaCode
            // 
            this.lblFaDokThemaCode.Location = new System.Drawing.Point(5, 124);
            this.lblFaDokThemaCode.Name = "lblFaDokThemaCode";
            this.lblFaDokThemaCode.Size = new System.Drawing.Size(72, 24);
            this.lblFaDokThemaCode.TabIndex = 49;
            this.lblFaDokThemaCode.Text = "Thema";
            this.lblFaDokThemaCode.UseCompatibleTextRendering = true;
            // 
            // lblVisumStatusDatum
            // 
            this.lblVisumStatusDatum.Location = new System.Drawing.Point(541, 51);
            this.lblVisumStatusDatum.Name = "lblVisumStatusDatum";
            this.lblVisumStatusDatum.Size = new System.Drawing.Size(33, 24);
            this.lblVisumStatusDatum.TabIndex = 44;
            this.lblVisumStatusDatum.Text = "am";
            this.lblVisumStatusDatum.UseCompatibleTextRendering = true;
            // 
            // lblFaDokVisumStatusCode
            // 
            this.lblFaDokVisumStatusCode.Location = new System.Drawing.Point(540, 5);
            this.lblFaDokVisumStatusCode.Name = "lblFaDokVisumStatusCode";
            this.lblFaDokVisumStatusCode.Size = new System.Drawing.Size(37, 24);
            this.lblFaDokVisumStatusCode.TabIndex = 44;
            this.lblFaDokVisumStatusCode.Text = "Visum";
            this.lblFaDokVisumStatusCode.UseCompatibleTextRendering = true;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.Location = new System.Drawing.Point(5, 184);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(64, 24);
            this.lblBemerkung.TabIndex = 42;
            this.lblBemerkung.Text = "Bemerkung";
            this.lblBemerkung.UseCompatibleTextRendering = true;
            // 
            // lblFaDokVerwendungCode
            // 
            this.lblFaDokVerwendungCode.Location = new System.Drawing.Point(207, 3);
            this.lblFaDokVerwendungCode.Name = "lblFaDokVerwendungCode";
            this.lblFaDokVerwendungCode.Size = new System.Drawing.Size(28, 24);
            this.lblFaDokVerwendungCode.TabIndex = 21;
            this.lblFaDokVerwendungCode.Text = "Post";
            this.lblFaDokVerwendungCode.UseCompatibleTextRendering = true;
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryFaDokumente;
            this.edtBemerkung.Location = new System.Drawing.Point(91, 184);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(426, 62);
            this.edtBemerkung.TabIndex = 11;
            // 
            // docDokument
            // 
            this.docDokument.Context = "FaDokumente";
            this.docDokument.DataMember = "DocumentID";
            this.docDokument.DataSource = this.qryFaDokumente;
            this.docDokument.Location = new System.Drawing.Point(389, 154);
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
            serializableAppearanceObject19.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject19.Options.UseBackColor = true;
            serializableAppearanceObject20.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject20.Options.UseBackColor = true;
            serializableAppearanceObject21.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject21.Options.UseBackColor = true;
            this.docDokument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docDokument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docDokument.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject19, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docDokument.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject20, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docDokument.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject21, "Dokument importieren")});
            this.docDokument.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docDokument.Properties.Name = "edtFaDokKorreDokument.Properties";
            this.docDokument.Properties.ReadOnly = true;
            this.docDokument.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docDokument.Size = new System.Drawing.Size(128, 24);
            this.docDokument.TabIndex = 10;
            this.docDokument.DocumentOpening += new System.ComponentModel.CancelEventHandler(this.docDokument_DocumentOpening);
            this.docDokument.DocumentSaved += new System.EventHandler(this.docDokument_DocumentSaved);
            // 
            // edtBaPersonID
            // 
            this.edtBaPersonID.DataMember = "BaPersonID";
            this.edtBaPersonID.DataSource = this.qryFaDokumente;
            this.edtBaPersonID.Location = new System.Drawing.Point(91, 154);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBaPersonID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtBaPersonID.Properties.DisplayMember = "Text";
            this.edtBaPersonID.Properties.Name = "editPerson.Properties";
            this.edtBaPersonID.Properties.NullText = "";
            this.edtBaPersonID.Properties.ShowFooter = false;
            this.edtBaPersonID.Properties.ShowHeader = false;
            this.edtBaPersonID.Properties.ValueMember = "Code";
            this.edtBaPersonID.Size = new System.Drawing.Size(239, 24);
            this.edtBaPersonID.TabIndex = 9;
            // 
            // edtFaDokThemaCode
            // 
            this.edtFaDokThemaCode.DataMember = "FaDokThemaCode";
            this.edtFaDokThemaCode.DataSource = this.qryFaDokumente;
            this.edtFaDokThemaCode.Location = new System.Drawing.Point(91, 124);
            this.edtFaDokThemaCode.LOVFilter = "F";
            this.edtFaDokThemaCode.LOVName = "FaDokThema";
            this.edtFaDokThemaCode.Name = "edtFaDokThemaCode";
            this.edtFaDokThemaCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaDokThemaCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaDokThemaCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaDokThemaCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaDokThemaCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaDokThemaCode.Properties.Appearance.Options.UseFont = true;
            this.edtFaDokThemaCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtFaDokThemaCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaDokThemaCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtFaDokThemaCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtFaDokThemaCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtFaDokThemaCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtFaDokThemaCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFaDokThemaCode.Properties.Name = "kissLookUpEdit2.Properties";
            this.edtFaDokThemaCode.Properties.NullText = "";
            this.edtFaDokThemaCode.Properties.ShowFooter = false;
            this.edtFaDokThemaCode.Properties.ShowHeader = false;
            this.edtFaDokThemaCode.Size = new System.Drawing.Size(426, 24);
            this.edtFaDokThemaCode.TabIndex = 8;
            // 
            // lblAbsender
            // 
            this.lblAbsender.Location = new System.Drawing.Point(5, 34);
            this.lblAbsender.Name = "lblAbsender";
            this.lblAbsender.Size = new System.Drawing.Size(64, 24);
            this.lblAbsender.TabIndex = 7;
            this.lblAbsender.Text = "Absender/in";
            this.lblAbsender.UseCompatibleTextRendering = true;
            // 
            // edtStichwort
            // 
            this.edtStichwort.DataMember = "Stichwort";
            this.edtStichwort.DataSource = this.qryFaDokumente;
            this.edtStichwort.Location = new System.Drawing.Point(91, 94);
            this.edtStichwort.Name = "edtStichwort";
            this.edtStichwort.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStichwort.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStichwort.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStichwort.Properties.Appearance.Options.UseBackColor = true;
            this.edtStichwort.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStichwort.Properties.Appearance.Options.UseFont = true;
            this.edtStichwort.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStichwort.Properties.Name = "edtFaDokKorreStichwort.Properties";
            this.edtStichwort.Size = new System.Drawing.Size(426, 24);
            this.edtStichwort.TabIndex = 7;
            // 
            // lblAdressat
            // 
            this.lblAdressat.Location = new System.Drawing.Point(5, 64);
            this.lblAdressat.Name = "lblAdressat";
            this.lblAdressat.Size = new System.Drawing.Size(64, 24);
            this.lblAdressat.TabIndex = 6;
            this.lblAdressat.Text = "Adressat/in";
            this.lblAdressat.UseCompatibleTextRendering = true;
            // 
            // edtAdressatFreitext
            // 
            this.edtAdressatFreitext.DataMember = "Adressat_Freitext";
            this.edtAdressatFreitext.DataSource = this.qryFaDokumente;
            this.edtAdressatFreitext.Location = new System.Drawing.Point(335, 64);
            this.edtAdressatFreitext.Name = "edtAdressatFreitext";
            this.edtAdressatFreitext.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAdressatFreitext.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdressatFreitext.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdressatFreitext.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdressatFreitext.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdressatFreitext.Properties.Appearance.Options.UseFont = true;
            this.edtAdressatFreitext.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdressatFreitext.Properties.Name = "edtFaDokKorreStichwort.Properties";
            this.edtAdressatFreitext.Size = new System.Drawing.Size(182, 24);
            this.edtAdressatFreitext.TabIndex = 6;
            // 
            // lblStichwort
            // 
            this.lblStichwort.Location = new System.Drawing.Point(5, 94);
            this.lblStichwort.Name = "lblStichwort";
            this.lblStichwort.Size = new System.Drawing.Size(72, 24);
            this.lblStichwort.TabIndex = 5;
            this.lblStichwort.Text = "Stichwort(e)";
            this.lblStichwort.UseCompatibleTextRendering = true;
            // 
            // edtAdressat
            // 
            this.edtAdressat.DataMember = "AdressatName";
            this.edtAdressat.DataSource = this.qryFaDokumente;
            this.edtAdressat.Location = new System.Drawing.Point(91, 64);
            this.edtAdressat.Name = "edtAdressat";
            this.edtAdressat.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAdressat.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdressat.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdressat.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdressat.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdressat.Properties.Appearance.Options.UseFont = true;
            this.edtAdressat.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtAdressat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtAdressat.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAdressat.Properties.Name = "edtFaDokKorreAddres.Properties";
            this.edtAdressat.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtAdressat.Size = new System.Drawing.Size(239, 24);
            this.edtAdressat.TabIndex = 5;
            this.edtAdressat.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtAdressat_UserModifiedFld);
            // 
            // lblDatumErstellung
            // 
            this.lblDatumErstellung.Location = new System.Drawing.Point(5, 4);
            this.lblDatumErstellung.Name = "lblDatumErstellung";
            this.lblDatumErstellung.Size = new System.Drawing.Size(80, 24);
            this.lblDatumErstellung.TabIndex = 4;
            this.lblDatumErstellung.Text = "Datum erstellt";
            this.lblDatumErstellung.UseCompatibleTextRendering = true;
            // 
            // edtAbsenderFreitext
            // 
            this.edtAbsenderFreitext.DataMember = "Absender_Freitext";
            this.edtAbsenderFreitext.DataSource = this.qryFaDokumente;
            this.edtAbsenderFreitext.Location = new System.Drawing.Point(335, 34);
            this.edtAbsenderFreitext.Name = "edtAbsenderFreitext";
            this.edtAbsenderFreitext.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAbsenderFreitext.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAbsenderFreitext.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbsenderFreitext.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbsenderFreitext.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAbsenderFreitext.Properties.Appearance.Options.UseFont = true;
            this.edtAbsenderFreitext.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAbsenderFreitext.Properties.Name = "edtFaDokKorreStichwort.Properties";
            this.edtAbsenderFreitext.Size = new System.Drawing.Size(182, 24);
            this.edtAbsenderFreitext.TabIndex = 4;
            // 
            // edtAbsender
            // 
            this.edtAbsender.DataMember = "AbsenderName";
            this.edtAbsender.DataSource = this.qryFaDokumente;
            this.edtAbsender.Location = new System.Drawing.Point(91, 34);
            this.edtAbsender.Name = "edtAbsender";
            this.edtAbsender.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAbsender.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAbsender.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbsender.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbsender.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAbsender.Properties.Appearance.Options.UseFont = true;
            this.edtAbsender.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtAbsender.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtAbsender.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAbsender.Properties.Name = "edtFaDokKorreAbsend.Properties";
            this.edtAbsender.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtAbsender.Size = new System.Drawing.Size(239, 24);
            this.edtAbsender.TabIndex = 3;
            this.edtAbsender.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtAbsender_UserModifiedFld);
            // 
            // chkNichtKlibuRelevant
            // 
            this.chkNichtKlibuRelevant.DataMember = "NichtKlibuRelevant";
            this.chkNichtKlibuRelevant.DataSource = this.qryFaDokumente;
            this.chkNichtKlibuRelevant.Location = new System.Drawing.Point(396, 8);
            this.chkNichtKlibuRelevant.Name = "chkNichtKlibuRelevant";
            this.chkNichtKlibuRelevant.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkNichtKlibuRelevant.Properties.Appearance.Options.UseBackColor = true;
            this.chkNichtKlibuRelevant.Properties.Caption = "nicht Klibu relevant";
            this.chkNichtKlibuRelevant.Size = new System.Drawing.Size(121, 19);
            this.chkNichtKlibuRelevant.TabIndex = 2;
            this.chkNichtKlibuRelevant.CheckedChanged += new System.EventHandler(this.chkNichtKlibuRelevant_CheckedChanged);
            this.chkNichtKlibuRelevant.CheckStateChanged += new System.EventHandler(this.chkNichtKlibuRelevant_CheckStateChanged);
            this.chkNichtKlibuRelevant.EditValueChanged += new System.EventHandler(this.chkNichtKlibuRelevant_EditValueChanged);
            this.chkNichtKlibuRelevant.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.chkNichtKlibuRelevant_EditValueChanging);
            // 
            // lblDocumentID
            // 
            this.lblDocumentID.Location = new System.Drawing.Point(334, 154);
            this.lblDocumentID.Name = "lblDocumentID";
            this.lblDocumentID.Size = new System.Drawing.Size(54, 24);
            this.lblDocumentID.TabIndex = 1;
            this.lblDocumentID.Text = "Dokument";
            this.lblDocumentID.UseCompatibleTextRendering = true;
            // 
            // edtFaDokVerwendungCode
            // 
            this.edtFaDokVerwendungCode.AllowNull = false;
            this.edtFaDokVerwendungCode.DataMember = "FaDokVerwendungCode";
            this.edtFaDokVerwendungCode.DataSource = this.qryFaDokumente;
            this.edtFaDokVerwendungCode.Location = new System.Drawing.Point(239, 4);
            this.edtFaDokVerwendungCode.LOVName = "FaDokVerwendung";
            this.edtFaDokVerwendungCode.Name = "edtFaDokVerwendungCode";
            this.edtFaDokVerwendungCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaDokVerwendungCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaDokVerwendungCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaDokVerwendungCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaDokVerwendungCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaDokVerwendungCode.Properties.Appearance.Options.UseFont = true;
            this.edtFaDokVerwendungCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtFaDokVerwendungCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaDokVerwendungCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtFaDokVerwendungCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtFaDokVerwendungCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtFaDokVerwendungCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtFaDokVerwendungCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFaDokVerwendungCode.Properties.NullText = "";
            this.edtFaDokVerwendungCode.Properties.ShowFooter = false;
            this.edtFaDokVerwendungCode.Properties.ShowHeader = false;
            this.edtFaDokVerwendungCode.Size = new System.Drawing.Size(91, 24);
            this.edtFaDokVerwendungCode.TabIndex = 1;
            // 
            // edtDatumErstellung
            // 
            this.edtDatumErstellung.DataMember = "DatumErstellung";
            this.edtDatumErstellung.DataSource = this.qryFaDokumente;
            this.edtDatumErstellung.EditValue = ((object)(resources.GetObject("edtDatumErstellung.EditValue")));
            this.edtDatumErstellung.Location = new System.Drawing.Point(91, 4);
            this.edtDatumErstellung.Name = "edtDatumErstellung";
            this.edtDatumErstellung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumErstellung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumErstellung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumErstellung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumErstellung.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumErstellung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumErstellung.Properties.Appearance.Options.UseFont = true;
            this.edtDatumErstellung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtDatumErstellung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumErstellung.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtDatumErstellung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumErstellung.Properties.Name = "edtFaDokKorreDatum.Properties";
            this.edtDatumErstellung.Properties.ShowToday = false;
            this.edtDatumErstellung.Size = new System.Drawing.Size(94, 24);
            this.edtDatumErstellung.TabIndex = 0;
            // 
            // btnBearbeiten
            // 
            this.btnBearbeiten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBearbeiten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBearbeiten.Location = new System.Drawing.Point(367, 245);
            this.btnBearbeiten.Name = "btnBearbeiten";
            this.btnBearbeiten.Size = new System.Drawing.Size(109, 24);
            this.btnBearbeiten.TabIndex = 3;
            this.btnBearbeiten.Text = "in Bearbeitung";
            this.btnBearbeiten.UseCompatibleTextRendering = true;
            this.btnBearbeiten.UseVisualStyleBackColor = false;
            this.btnBearbeiten.Click += new System.EventHandler(this.btnBearbeiten_Click);
            // 
            // btnAktuell
            // 
            this.btnAktuell.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAktuell.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAktuell.Location = new System.Drawing.Point(482, 245);
            this.btnAktuell.Name = "btnAktuell";
            this.btnAktuell.Size = new System.Drawing.Size(109, 24);
            this.btnAktuell.TabIndex = 4;
            this.btnAktuell.Text = "Aktuell";
            this.btnAktuell.UseCompatibleTextRendering = true;
            this.btnAktuell.UseVisualStyleBackColor = false;
            this.btnAktuell.Click += new System.EventHandler(this.btnAktuell_Click);
            // 
            // btnHistorisieren
            // 
            this.btnHistorisieren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistorisieren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorisieren.Location = new System.Drawing.Point(597, 245);
            this.btnHistorisieren.Name = "btnHistorisieren";
            this.btnHistorisieren.Size = new System.Drawing.Size(109, 24);
            this.btnHistorisieren.TabIndex = 5;
            this.btnHistorisieren.Text = "Historisieren";
            this.btnHistorisieren.UseCompatibleTextRendering = true;
            this.btnHistorisieren.UseVisualStyleBackColor = false;
            this.btnHistorisieren.Click += new System.EventHandler(this.btnHistorisieren_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblHinweisDefaultSuche);
            this.panel1.Controls.Add(this.picTitel);
            this.panel1.Controls.Add(this.lblTitel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(721, 24);
            this.panel1.TabIndex = 106;
            // 
            // lblHinweisDefaultSuche
            // 
            this.lblHinweisDefaultSuche.Location = new System.Drawing.Point(316, 0);
            this.lblHinweisDefaultSuche.Name = "lblHinweisDefaultSuche";
            this.lblHinweisDefaultSuche.Size = new System.Drawing.Size(399, 24);
            this.lblHinweisDefaultSuche.TabIndex = 6;
            this.lblHinweisDefaultSuche.Text = "Standardeinstellung: Anzeige Dokumente der letzten 12 Monate";
            this.lblHinweisDefaultSuche.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblHinweisDefaultSuche.Visible = false;
            // 
            // picTitel
            // 
            this.picTitel.Location = new System.Drawing.Point(5, 5);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 293;
            this.picTitel.TabStop = false;
            // 
            // lblTitel
            // 
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(25, 5);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(542, 15);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Dokumente";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // colPendenzDatum
            // 
            this.colPendenzDatum.Caption = "Datum";
            this.colPendenzDatum.Name = "colPendenzDatum";
            this.colPendenzDatum.Visible = true;
            this.colPendenzDatum.VisibleIndex = 0;
            this.colPendenzDatum.Width = 76;
            // 
            // colPendenzMitarbeiter
            // 
            this.colPendenzMitarbeiter.Caption = "Mitarbeiter";
            this.colPendenzMitarbeiter.Name = "colPendenzMitarbeiter";
            this.colPendenzMitarbeiter.Visible = true;
            this.colPendenzMitarbeiter.VisibleIndex = 2;
            this.colPendenzMitarbeiter.Width = 181;
            // 
            // colPendenzStatus
            // 
            this.colPendenzStatus.Caption = "Status";
            this.colPendenzStatus.Name = "colPendenzStatus";
            this.colPendenzStatus.Visible = true;
            this.colPendenzStatus.VisibleIndex = 1;
            this.colPendenzStatus.Width = 105;
            // 
            // colPendenzText
            // 
            this.colPendenzText.Caption = "Text";
            this.colPendenzText.FieldName = "Text";
            this.colPendenzText.Name = "colPendenzText";
            this.colPendenzText.Visible = true;
            this.colPendenzText.VisibleIndex = 3;
            // 
            // gridView2
            // 
            this.gridView2.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView2.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.Empty.Options.UseBackColor = true;
            this.gridView2.Appearance.Empty.Options.UseFont = true;
            this.gridView2.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.EvenRow.Options.UseFont = true;
            this.gridView2.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView2.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView2.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView2.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView2.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView2.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView2.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView2.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView2.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView2.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView2.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView2.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupRow.Options.UseFont = true;
            this.gridView2.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView2.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView2.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView2.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView2.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView2.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView2.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView2.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView2.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView2.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView2.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.OddRow.Options.UseFont = true;
            this.gridView2.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.Row.Options.UseBackColor = true;
            this.gridView2.Appearance.Row.Options.UseFont = true;
            this.gridView2.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView2.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView2.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsCustomization.AllowFilter = false;
            this.gridView2.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView2.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView2.OptionsNavigation.UseTabKey = false;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowIndicator = false;
            // 
            // btnAlle
            // 
            this.btnAlle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAlle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlle.Location = new System.Drawing.Point(6, 245);
            this.btnAlle.Name = "btnAlle";
            this.btnAlle.Size = new System.Drawing.Size(52, 24);
            this.btnAlle.TabIndex = 1;
            this.btnAlle.Text = "Alle";
            this.btnAlle.UseCompatibleTextRendering = true;
            this.btnAlle.UseVisualStyleBackColor = false;
            this.btnAlle.Click += new System.EventHandler(this.btnAlle_Click);
            // 
            // btnKeine
            // 
            this.btnKeine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnKeine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeine.Location = new System.Drawing.Point(64, 245);
            this.btnKeine.Name = "btnKeine";
            this.btnKeine.Size = new System.Drawing.Size(52, 24);
            this.btnKeine.TabIndex = 2;
            this.btnKeine.Text = "Keine";
            this.btnKeine.UseCompatibleTextRendering = true;
            this.btnKeine.UseVisualStyleBackColor = false;
            this.btnKeine.Click += new System.EventHandler(this.btnKeine_Click);
            // 
            // edtInklIKAAuszuege
            // 
            this.edtInklIKAAuszuege.EditValue = false;
            this.edtInklIKAAuszuege.Location = new System.Drawing.Point(523, 204);
            this.edtInklIKAAuszuege.Name = "edtInklIKAAuszuege";
            this.edtInklIKAAuszuege.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtInklIKAAuszuege.Properties.Appearance.Options.UseBackColor = true;
            this.edtInklIKAAuszuege.Properties.Caption = "inkl. IK-Auszüge";
            this.edtInklIKAAuszuege.Size = new System.Drawing.Size(183, 19);
            this.edtInklIKAAuszuege.TabIndex = 32;
            // 
            // CtlFaDokumente
            // 
            this.ActiveSQLQuery = this.qryFaDokumente;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabDocument);
            this.Name = "CtlFaDokumente";
            this.Size = new System.Drawing.Size(721, 637);
            this.Load += new System.EventHandler(this.CtlFaDokumente_Load);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.tabDocument, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFaDokumente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaDokumente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFaDokumente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAbsender.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAdressat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStichwort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFaDokThemaCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFaDokThemaCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFaDokVisumStatusCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFaDokVisumStatusCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFaDokStatusCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFaDokStatusCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFaDokVerwendungCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFaDokVerwendungCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKlibuRelevant.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNichtKlibuRelevant.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaDokKorreSucheDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaDokKorreSucheAbsender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaDokKorreSucheAdressat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaDokKorreSucheStichwort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaDokKorreSucheDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheThemen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVisumCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDokStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVerwendung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBetrifftPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBemerkung)).EndInit();
            this.tabDocument.ResumeLayout(false);
            this.tpgVisum.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdXTask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXTask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvXTask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memBemerkungAnfrage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgpAnfrage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgpAnfrage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memBemerkungAntwort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            this.tpgDocument.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtVisumStatusDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokVisumStatusCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokVisumStatusCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusLetztDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokStatusCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokStatusCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusSetUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatusLetztDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatusSetUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaDokStatusCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVisumPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVisumPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaDokThemaCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVisumStatusDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaDokVisumStatusCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaDokVerwendungCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docDokument.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokThemaCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokThemaCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbsender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichwort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdressat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdressatFreitext.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichwort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdressat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumErstellung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbsenderFreitext.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbsender.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNichtKlibuRelevant.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDocumentID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokVerwendungCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokVerwendungCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumErstellung.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblHinweisDefaultSuche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInklIKAAuszuege.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissButton btnAktuell;
        private KiSS4.Gui.KissButton btnAlle;
        private KiSS4.Gui.KissButton btnAnfrage;
        private KiSS4.Gui.KissButton btnAntworten;
        private KiSS4.Gui.KissButton btnBearbeiten;
        private KiSS4.Gui.KissButton btnHistorisieren;
        private KiSS4.Gui.KissButton btnKeine;
        private KiSS4.Gui.KissButton btnWiederrufen;
        private KiSS4.Gui.KissCheckEdit chkNichtKlibuRelevant;
        private DevExpress.XtraGrid.Columns.GridColumn colAbsender;
        private DevExpress.XtraGrid.Columns.GridColumn colAdressat;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrifftPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colErsteller;
        private DevExpress.XtraGrid.Columns.GridColumn colErstellerOrgUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colFaDokStatusCode;
        private DevExpress.XtraGrid.Columns.GridColumn colFaDokThemaCode;
        private DevExpress.XtraGrid.Columns.GridColumn colFaDokVerwendungCode;
        private DevExpress.XtraGrid.Columns.GridColumn colFaDokVisumStatusCode;
        private DevExpress.XtraGrid.Columns.GridColumn colFaDokVisumStatusCode_Task;
        private DevExpress.XtraGrid.Columns.GridColumn colPendenzAntwortText;
        private DevExpress.XtraGrid.Columns.GridColumn colPendenzBeantwortet;
        private DevExpress.XtraGrid.Columns.GridColumn colPendenzDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colPendenzMitarbeiter;
        private DevExpress.XtraGrid.Columns.GridColumn colPendenzStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colPendenzText;
        private DevExpress.XtraGrid.Columns.GridColumn colReceiver;
        private DevExpress.XtraGrid.Columns.GridColumn colSelected;
        private DevExpress.XtraGrid.Columns.GridColumn colSender;
        private DevExpress.XtraGrid.Columns.GridColumn colStichworte;
        private DevExpress.XtraGrid.Columns.GridColumn colTaskResponseCode;
        private DevExpress.XtraGrid.Columns.GridColumn colTaskStatusCode;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Common.CtlErfassungMutation ctlErfassungMutation;
        private KiSS4.Dokument.XDokument docDokument;
        private KiSS4.Gui.KissButtonEdit edtAbsender;
        private KiSS4.Gui.KissTextEdit edtAbsenderFreitext;
        private KiSS4.Gui.KissButtonEdit edtAdressat;
        private KiSS4.Gui.KissTextEdit edtAdressatFreitext;
        private KiSS4.Gui.KissLookUpEdit edtBaPersonID;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private KiSS4.Gui.KissDateEdit edtDatumErstellung;
        private KiSS4.Gui.KissLookUpEdit edtFaDokStatusCode;
        private KiSS4.Gui.KissLookUpEdit edtFaDokThemaCode;
        private KiSS4.Gui.KissLookUpEdit edtFaDokVerwendungCode;
        private KiSS4.Gui.KissLookUpEdit edtFaDokVisumStatusCode;
        private KiSS4.Gui.KissCheckEdit edtInklIKAAuszuege;
        private KiSS4.Gui.KissTextEdit edtStatusLetztDatum;
        private KiSS4.Gui.KissTextEdit edtStatusSetUser;
        private KiSS4.Gui.KissTextEdit edtStichwort;
        private KiSS4.Gui.KissTextEdit edtSucheAbsender;
        private KiSS4.Gui.KissTextEdit edtSucheAdressat;
        private KiSS4.Gui.KissLookUpEdit edtSucheBaPersonID;
        private KiSS4.Gui.KissTextEdit edtSucheBemerkung;
        private KiSS4.Gui.KissDateEdit edtSucheDatumBis;
        private KiSS4.Gui.KissDateEdit edtSucheDatumVon;
        private KiSS4.Gui.KissLookUpEdit edtSucheFaDokStatusCode;
        private KiSS4.Gui.KissLookUpEdit edtSucheFaDokThemaCode;
        private KiSS4.Gui.KissLookUpEdit edtSucheFaDokVerwendungCode;
        private KiSS4.Gui.KissLookUpEdit edtSucheFaDokVisumStatusCode;
        private KiSS4.Gui.KissCheckEdit edtSucheKlibuRelevant;
        private KiSS4.Gui.KissCheckEdit edtSucheNichtKlibuRelevant;
        private KiSS4.Gui.KissTextEdit edtSucheStichwort;
        private KiSS4.Gui.KissTextEdit edtVisumPerson;
        private KiSS4.Gui.KissTextEdit edtVisumStatusDatum;
        private KiSS4.Gui.KissGrid grdFaDokumente;
        private KiSS4.Gui.KissGrid grdXTask;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView grvFaDokumente;
        private DevExpress.XtraGrid.Views.Grid.GridView grvXTask;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel lblAbsender;
        private KiSS4.Gui.KissLabel lblAdressat;
        private KiSS4.Gui.KissLabel lblBaPersonID;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblDatumErstellung;
        private KiSS4.Gui.KissLabel lblDocumentID;
        private KiSS4.Gui.KissLabel lblFaDokKorreSucheAbsender;
        private KiSS4.Gui.KissLabel lblFaDokKorreSucheAdressat;
        private KiSS4.Gui.KissLabel lblFaDokKorreSucheDatumBis;
        private KiSS4.Gui.KissLabel lblFaDokKorreSucheDatumVon;
        private KiSS4.Gui.KissLabel lblFaDokKorreSucheStichwort;
        private KiSS4.Gui.KissLabel lblFaDokStatusCode;
        private KiSS4.Gui.KissLabel lblFaDokThemaCode;
        private KiSS4.Gui.KissLabel lblFaDokVerwendungCode;
        private KiSS4.Gui.KissLabel lblFaDokVisumStatusCode;
        private KiSS4.Gui.KissLabel lblStatusLetztDatum;
        private KiSS4.Gui.KissLabel lblStatusSetUser;
        private KiSS4.Gui.KissLabel lblStichwort;
        private KiSS4.Gui.KissLabel lblSucheBemerkung;
        private KiSS4.Gui.KissLabel lblSucheBetrifftPerson;
        private KiSS4.Gui.KissLabel lblSucheDokStatus;
        private KiSS4.Gui.KissLabel lblSucheThemen;
        private KiSS4.Gui.KissLabel lblSucheVerwendung;
        private KiSS4.Gui.KissLabel lblSucheVisumCode;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblVisumPerson;
        private KiSS4.Gui.KissLabel lblVisumStatusDatum;
        private KiSS4.Gui.KissMemoEdit memBemerkungAnfrage;
        private KiSS4.Gui.KissMemoEdit memBemerkungAntwort;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryFaDokumente;
        private KiSS4.DB.SqlQuery qryXTask;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private KiSS4.Gui.KissRadioGroup rgpAnfrage;
        private KiSS4.Gui.KissTabControlEx tabDocument;
        private SharpLibrary.WinControls.TabPageEx tpgDocument;
        private SharpLibrary.WinControls.TabPageEx tpgVisum;
        private Gui.KissLabel lblHinweisDefaultSuche;
    }
}
