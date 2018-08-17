using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS4.Sozialhilfe
{
    partial class CtlWhAuszahlungen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlWhAuszahlungen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject25 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject24 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject23 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject22 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject21 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject20 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject19 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject18 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject17 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject26 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject27 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject28 = new DevExpress.Utils.SerializableAppearanceObject();
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
            this.grdEinzelzahlung = new KiSS4.Gui.KissGrid();
            this.qryBgPosition = new KiSS4.DB.SqlQuery();
            this.grvEinzelzahlung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValuta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKOA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHauptPos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKreditor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repStatusImg = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colSelektion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtSucheErfassungMA = new KiSS4.Gui.KissButtonEdit();
            this.edtSucheErfassungVon = new KiSS4.Gui.KissDateEdit();
            this.lblSucheErfassung = new KiSS4.Gui.KissLabel();
            this.edtSucheErfassungBis = new KiSS4.Gui.KissDateEdit();
            this.lblSucheMutation = new KiSS4.Gui.KissLabel();
            this.edtSucheMutationMA = new KiSS4.Gui.KissButtonEdit();
            this.lblSucheValutaVon = new KiSS4.Gui.KissLabel();
            this.edtSucheMutationVon = new KiSS4.Gui.KissDateEdit();
            this.edtSucheMutationBis = new KiSS4.Gui.KissDateEdit();
            this.lblSucheMitarbeiter = new KiSS4.Gui.KissLabel();
            this.edtSucheValutaVon = new KiSS4.Gui.KissDateEdit();
            this.lblSucheValutaBis = new KiSS4.Gui.KissLabel();
            this.edtSucheValutaBis = new KiSS4.Gui.KissDateEdit();
            this.edtSucheStatus = new KiSS4.Gui.KissImageComboBoxEdit();
            this.edtSucheBelegID = new KiSS4.Gui.KissCalcEdit();
            this.lblSucheStatus = new KiSS4.Gui.KissLabel();
            this.edtSucheFallNr = new KiSS4.Gui.KissCalcEdit();
            this.lblSucheDatumVon = new KiSS4.Gui.KissLabel();
            this.lblSucheDatumBis = new KiSS4.Gui.KissLabel();
            this.lblSucheBelegID = new KiSS4.Gui.KissLabel();
            this.lblSucheFallNr = new KiSS4.Gui.KissLabel();
            this.edtSucheSelectTop = new KiSS4.Gui.KissCalcEdit();
            this.lblSucheSelectTop = new KiSS4.Gui.KissLabel();
            this.tabBgPosition = new KiSS4.Gui.KissTabControlEx();
            this.tpgBewilligung = new SharpLibrary.WinControls.TabPageEx();
            this.grdBgBewilligung = new KiSS4.Gui.KissGrid();
            this.qryBgBewilligung = new KiSS4.DB.SqlQuery();
            this.grvBgBewilligung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBbwGrouper = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbsender = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpfaenger = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBgBewilligungCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBemerkungen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panBewilligungDetails = new System.Windows.Forms.Panel();
            this.lblBewilligungAbsender = new KiSS4.Gui.KissLabel();
            this.edtBewilligungBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.edtBewilligungAbsender = new KiSS4.Gui.KissTextEdit();
            this.lblBewilligungBemerkung = new KiSS4.Gui.KissLabel();
            this.lblBewilligungEmpfaenger = new KiSS4.Gui.KissLabel();
            this.edtBewilligungEmpfaenger = new KiSS4.Gui.KissTextEdit();
            this.tpgDokumente = new SharpLibrary.WinControls.TabPageEx();
            this.grdBgDokumente = new KiSS4.Gui.KissGrid();
            this.qryBgDokumente = new KiSS4.DB.SqlQuery();
            this.grvBgDokumente = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDocTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStichwort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateCreation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateLastSave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panDokumenteDetails = new System.Windows.Forms.Panel();
            this.lblDokumentTyp = new KiSS4.Gui.KissLabel();
            this.edtDocument = new KiSS4.Dokument.XDokument();
            this.edtDokumentTyp = new KiSS4.Gui.KissLookUpEdit();
            this.lblDokument = new KiSS4.Gui.KissLabel();
            this.lblStichwort = new KiSS4.Gui.KissLabel();
            this.edtStichwort = new KiSS4.Gui.KissTextEdit();
            this.tpgEinzelzahlung = new SharpLibrary.WinControls.TabPageEx();
            this.panSetStatus = new System.Windows.Forms.Panel();
            this.btnGraustellen = new KiSS4.Gui.KissButton();
            this.panSetStatusBorder = new System.Windows.Forms.Panel();
            this.btnFreigeben = new KiSS4.Gui.KissButton();
            this.btnWeitereKOA = new KiSS4.Gui.KissButton();
            this.btnPositionBewilligung = new KiSS4.Gui.KissButton();
            this.ctlErfassungMutation = new KiSS4.Common.CtlErfassungMutation();
            this.panNewItems = new System.Windows.Forms.Panel();
            this.panNewItemsBorder = new System.Windows.Forms.Panel();
            this.btnEinzelzahlung = new KiSS4.Gui.KissButton();
            this.btnZusatzleistung = new KiSS4.Gui.KissButton();
            this.edtBelegNr = new KiSS4.Gui.KissCalcEdit();
            this.lblBelegNr = new KiSS4.Gui.KissLabel();
            this.edtPositionID = new KiSS4.Gui.KissCalcEdit();
            this.lblPositionID = new KiSS4.Gui.KissLabel();
            this.edtBgSplittingCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblBgSplittingCode = new KiSS4.Gui.KissLabel();
            this.edtVerwPeriodeBis = new KiSS4.Gui.KissDateEdit();
            this.lblVerwPeriodeStrich = new KiSS4.Gui.KissLabel();
            this.edtVerwPeriodeVon = new KiSS4.Gui.KissDateEdit();
            this.lblVerwPeriode = new KiSS4.Gui.KissLabel();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.edtMitteilungZeile3 = new KiSS4.Gui.KissTextEdit();
            this.edtMitteilungZeile2 = new KiSS4.Gui.KissTextEdit();
            this.edtMitteilungZeile1 = new KiSS4.Gui.KissTextEdit();
            this.lblZahlungsgrund = new KiSS4.Gui.KissLabel();
            this.edtReferenzNummer = new KiSS4.Common.KissReferenzNrEdit();
            this.lblReferenzNummer = new KiSS4.Gui.KissLabel();
            this.edtZusatzInfo = new KiSS4.Gui.KissMemoEdit();
            this.edtKreditor = new KiSS4.Gui.KissButtonEdit();
            this.lblKreditor = new KiSS4.Gui.KissLabel();
            this.edtBelegDatum = new KiSS4.Gui.KissDateEdit();
            this.lblBelegDatum = new KiSS4.Gui.KissLabel();
            this.edtValutaDatum = new KiSS4.Gui.KissDateEdit();
            this.lblValutaDatum = new KiSS4.Gui.KissLabel();
            this.btnMonatsbudget = new KiSS4.Gui.KissButton();
            this.grdBgBudget = new KiSS4.Gui.KissGrid();
            this.qryBgBudget = new KiSS4.DB.SqlQuery();
            this.grvBgBudget = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMonat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJahr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnzEZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnzZL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAbgeschlossenAm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblMonatsbudget = new KiSS4.Gui.KissLabel();
            this.edtAuszahlungsart = new KiSS4.Gui.KissLookUpEdit();
            this.lblAuszahlungsart = new KiSS4.Gui.KissLabel();
            this.edtBgSpezkontoID = new KiSS4.Gui.KissLookUpEdit();
            this.lblBgSpezkontoID = new KiSS4.Gui.KissLabel();
            this.edtBaPersonID = new KiSS4.Gui.KissLookUpEdit();
            this.lblBaPersonID = new KiSS4.Gui.KissLabel();
            this.edtBetrag = new KiSS4.Gui.KissCalcEdit();
            this.lblBetrag = new KiSS4.Gui.KissLabel();
            this.edtBuchungstext = new KiSS4.Gui.KissTextEdit();
            this.lblBuchungstext = new KiSS4.Gui.KissLabel();
            this.edtKostenart = new KiSS4.Gui.KissButtonEdit();
            this.lblKostenart = new KiSS4.Gui.KissLabel();
            this.edtAdresse = new KiSS4.Gui.KissTextEdit();
            this.lblAdresse = new KiSS4.Gui.KissLabel();
            this.edtKlientID = new KiSS4.Gui.KissTextEdit();
            this.edtKlient = new KiSS4.Gui.KissButtonEdit();
            this.lblKlient = new KiSS4.Gui.KissLabel();
            this.edtKategorie = new KiSS4.Gui.KissLookUpEdit();
            this.lblKategorie = new KiSS4.Gui.KissLabel();
            this.splitter = new KiSS4.Gui.KissSplitterCollapsible();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEinzelzahlung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEinzelzahlung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repStatusImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheErfassungMA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheErfassungVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheErfassung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheErfassungBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMutation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMutationMA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheValutaVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMutationVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMutationBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheValutaVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheValutaBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheValutaBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBelegID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFallNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBelegID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheFallNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheSelectTop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheSelectTop)).BeginInit();
            this.tabBgPosition.SuspendLayout();
            this.tpgBewilligung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBgBewilligung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgBewilligung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgBewilligung)).BeginInit();
            this.panBewilligungDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblBewilligungAbsender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBewilligungBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBewilligungAbsender.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBewilligungBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBewilligungEmpfaenger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBewilligungEmpfaenger.Properties)).BeginInit();
            this.tpgDokumente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBgDokumente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgDokumente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgDokumente)).BeginInit();
            this.panDokumenteDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokumentTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDocument.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentTyp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichwort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichwort.Properties)).BeginInit();
            this.tpgEinzelzahlung.SuspendLayout();
            this.panSetStatus.SuspendLayout();
            this.panNewItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPositionID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPositionID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSplittingCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSplittingCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgSplittingCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwPeriodeBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwPeriodeStrich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwPeriodeVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwPeriode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilungZeile3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilungZeile2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilungZeile1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungsgrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtReferenzNummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReferenzNummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValutaDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValutaDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBgBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMonatsbudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuszahlungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuszahlungsart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuszahlungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSpezkontoID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSpezkontoID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgSpezkontoID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlientID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKategorie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKategorie.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKategorie)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(976, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.Size = new System.Drawing.Size(1002, 152);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdEinzelzahlung);
            this.tpgListe.Size = new System.Drawing.Size(990, 114);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.lblSucheSelectTop);
            this.tpgSuchen.Controls.Add(this.edtSucheSelectTop);
            this.tpgSuchen.Controls.Add(this.lblSucheFallNr);
            this.tpgSuchen.Controls.Add(this.lblSucheBelegID);
            this.tpgSuchen.Controls.Add(this.lblSucheDatumBis);
            this.tpgSuchen.Controls.Add(this.lblSucheDatumVon);
            this.tpgSuchen.Controls.Add(this.edtSucheFallNr);
            this.tpgSuchen.Controls.Add(this.lblSucheStatus);
            this.tpgSuchen.Controls.Add(this.edtSucheBelegID);
            this.tpgSuchen.Controls.Add(this.edtSucheStatus);
            this.tpgSuchen.Controls.Add(this.edtSucheValutaBis);
            this.tpgSuchen.Controls.Add(this.lblSucheValutaBis);
            this.tpgSuchen.Controls.Add(this.edtSucheValutaVon);
            this.tpgSuchen.Controls.Add(this.lblSucheMitarbeiter);
            this.tpgSuchen.Controls.Add(this.edtSucheMutationBis);
            this.tpgSuchen.Controls.Add(this.edtSucheMutationVon);
            this.tpgSuchen.Controls.Add(this.lblSucheValutaVon);
            this.tpgSuchen.Controls.Add(this.edtSucheMutationMA);
            this.tpgSuchen.Controls.Add(this.lblSucheMutation);
            this.tpgSuchen.Controls.Add(this.edtSucheErfassungBis);
            this.tpgSuchen.Controls.Add(this.lblSucheErfassung);
            this.tpgSuchen.Controls.Add(this.edtSucheErfassungVon);
            this.tpgSuchen.Controls.Add(this.edtSucheErfassungMA);
            this.tpgSuchen.Size = new System.Drawing.Size(990, 114);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheErfassungMA, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheErfassungVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheErfassung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheErfassungBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheMutation, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheMutationMA, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheValutaVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheMutationVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheMutationBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheMitarbeiter, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheValutaVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheValutaBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheValutaBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheStatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBelegID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheStatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheFallNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBelegID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheFallNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheSelectTop, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheSelectTop, 0);
            // 
            // grdEinzelzahlung
            // 
            this.grdEinzelzahlung.DataSource = this.qryBgPosition;
            this.grdEinzelzahlung.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdEinzelzahlung.EmbeddedNavigator.Name = "";
            this.grdEinzelzahlung.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdEinzelzahlung.Location = new System.Drawing.Point(0, 0);
            this.grdEinzelzahlung.MainView = this.grvEinzelzahlung;
            this.grdEinzelzahlung.Name = "grdEinzelzahlung";
            this.grdEinzelzahlung.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repStatusImg});
            this.grdEinzelzahlung.Size = new System.Drawing.Size(990, 114);
            this.grdEinzelzahlung.TabIndex = 0;
            this.grdEinzelzahlung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvEinzelzahlung});
            // 
            // qryBgPosition
            // 
            this.qryBgPosition.CanDelete = true;
            this.qryBgPosition.CanInsert = true;
            this.qryBgPosition.CanUpdate = true;
            this.qryBgPosition.DeleteQuestion = "Soll die Position gelöscht werden ?";
            this.qryBgPosition.HostControl = this;
            this.qryBgPosition.SelectStatement = resources.GetString("qryBgPosition.SelectStatement");
            this.qryBgPosition.TableName = "BgPosition";
            this.qryBgPosition.AfterInsert += new System.EventHandler(this.qryBgPosition_AfterInsert);
            this.qryBgPosition.AfterPost += new System.EventHandler(this.qryBgPosition_AfterPost);
            this.qryBgPosition.BeforeDelete += new System.EventHandler(this.qryBgPosition_BeforeDelete);
            this.qryBgPosition.BeforeDeleteQuestion += new System.EventHandler(this.qryBgPosition_BeforeDeleteQuestion);
            this.qryBgPosition.BeforeInsert += new System.EventHandler(this.qryBgPosition_BeforeInsert);
            this.qryBgPosition.BeforePost += new System.EventHandler(this.qryBgPosition_BeforePost);
            this.qryBgPosition.PositionChanged += new System.EventHandler(this.qryBgPosition_PositionChanged);
            // 
            // grvEinzelzahlung
            // 
            this.grvEinzelzahlung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvEinzelzahlung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinzelzahlung.Appearance.Empty.Options.UseBackColor = true;
            this.grvEinzelzahlung.Appearance.Empty.Options.UseFont = true;
            this.grvEinzelzahlung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinzelzahlung.Appearance.EvenRow.Options.UseFont = true;
            this.grvEinzelzahlung.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvEinzelzahlung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinzelzahlung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvEinzelzahlung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvEinzelzahlung.Appearance.FocusedCell.Options.UseFont = true;
            this.grvEinzelzahlung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvEinzelzahlung.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvEinzelzahlung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinzelzahlung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvEinzelzahlung.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvEinzelzahlung.Appearance.FocusedRow.Options.UseFont = true;
            this.grvEinzelzahlung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvEinzelzahlung.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvEinzelzahlung.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvEinzelzahlung.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvEinzelzahlung.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvEinzelzahlung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvEinzelzahlung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvEinzelzahlung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvEinzelzahlung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvEinzelzahlung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvEinzelzahlung.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvEinzelzahlung.Appearance.GroupRow.Options.UseFont = true;
            this.grvEinzelzahlung.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvEinzelzahlung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvEinzelzahlung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvEinzelzahlung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvEinzelzahlung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvEinzelzahlung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvEinzelzahlung.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvEinzelzahlung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvEinzelzahlung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinzelzahlung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvEinzelzahlung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvEinzelzahlung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvEinzelzahlung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvEinzelzahlung.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvEinzelzahlung.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvEinzelzahlung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinzelzahlung.Appearance.OddRow.Options.UseFont = true;
            this.grvEinzelzahlung.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvEinzelzahlung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinzelzahlung.Appearance.Row.Options.UseBackColor = true;
            this.grvEinzelzahlung.Appearance.Row.Options.UseFont = true;
            this.grvEinzelzahlung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinzelzahlung.Appearance.SelectedRow.Options.UseFont = true;
            this.grvEinzelzahlung.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvEinzelzahlung.Appearance.VertLine.Options.UseBackColor = true;
            this.grvEinzelzahlung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvEinzelzahlung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKat,
            this.colValuta,
            this.colKlient,
            this.colKOA,
            this.colBuchungstext,
            this.colBetrag,
            this.colHauptPos,
            this.colKreditor,
            this.colDoc,
            this.colMA,
            this.colPosStatus,
            this.colSelektion});
            this.grvEinzelzahlung.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvEinzelzahlung.GridControl = this.grdEinzelzahlung;
            this.grvEinzelzahlung.Name = "grvEinzelzahlung";
            this.grvEinzelzahlung.OptionsBehavior.Editable = false;
            this.grvEinzelzahlung.OptionsCustomization.AllowFilter = false;
            this.grvEinzelzahlung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvEinzelzahlung.OptionsNavigation.AutoFocusNewRow = true;
            this.grvEinzelzahlung.OptionsNavigation.UseTabKey = false;
            this.grvEinzelzahlung.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvEinzelzahlung.OptionsView.ColumnAutoWidth = false;
            this.grvEinzelzahlung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvEinzelzahlung.OptionsView.ShowGroupPanel = false;
            this.grvEinzelzahlung.OptionsView.ShowIndicator = false;
            // 
            // colKat
            // 
            this.colKat.AppearanceCell.Options.UseTextOptions = true;
            this.colKat.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKat.Caption = "Kat.";
            this.colKat.FieldName = "BgKategorieCode";
            this.colKat.Name = "colKat";
            this.colKat.OptionsColumn.AllowEdit = false;
            this.colKat.Visible = true;
            this.colKat.VisibleIndex = 0;
            this.colKat.Width = 35;
            // 
            // colValuta
            // 
            this.colValuta.Caption = "Valuta";
            this.colValuta.FieldName = "ValutaDatum";
            this.colValuta.Name = "colValuta";
            this.colValuta.OptionsColumn.AllowEdit = false;
            this.colValuta.Visible = true;
            this.colValuta.VisibleIndex = 1;
            // 
            // colKlient
            // 
            this.colKlient.Caption = "Klient/in";
            this.colKlient.FieldName = "Klient";
            this.colKlient.Name = "colKlient";
            this.colKlient.OptionsColumn.AllowEdit = false;
            this.colKlient.Visible = true;
            this.colKlient.VisibleIndex = 2;
            this.colKlient.Width = 200;
            // 
            // colKOA
            // 
            this.colKOA.Caption = "KoA";
            this.colKOA.FieldName = "KOA";
            this.colKOA.Name = "colKOA";
            this.colKOA.OptionsColumn.AllowEdit = false;
            this.colKOA.Visible = true;
            this.colKOA.VisibleIndex = 3;
            this.colKOA.Width = 50;
            // 
            // colBuchungstext
            // 
            this.colBuchungstext.Caption = "Buchungstext";
            this.colBuchungstext.FieldName = "Buchungstext";
            this.colBuchungstext.Name = "colBuchungstext";
            this.colBuchungstext.OptionsColumn.AllowEdit = false;
            this.colBuchungstext.Visible = true;
            this.colBuchungstext.VisibleIndex = 4;
            this.colBuchungstext.Width = 160;
            // 
            // colBetrag
            // 
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "n2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "BetragSpezial";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.OptionsColumn.AllowEdit = false;
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 5;
            // 
            // colHauptPos
            // 
            this.colHauptPos.AppearanceCell.Options.UseTextOptions = true;
            this.colHauptPos.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHauptPos.AppearanceHeader.Options.UseTextOptions = true;
            this.colHauptPos.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHauptPos.Caption = "*";
            this.colHauptPos.FieldName = "HauptPos";
            this.colHauptPos.Name = "colHauptPos";
            this.colHauptPos.OptionsColumn.AllowEdit = false;
            this.colHauptPos.Visible = true;
            this.colHauptPos.VisibleIndex = 6;
            this.colHauptPos.Width = 20;
            // 
            // colKreditor
            // 
            this.colKreditor.Caption = "Kreditor";
            this.colKreditor.FieldName = "Kreditor";
            this.colKreditor.Name = "colKreditor";
            this.colKreditor.OptionsColumn.AllowEdit = false;
            this.colKreditor.Visible = true;
            this.colKreditor.VisibleIndex = 7;
            this.colKreditor.Width = 160;
            // 
            // colDoc
            // 
            this.colDoc.AppearanceCell.Options.UseTextOptions = true;
            this.colDoc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDoc.Caption = "Dok";
            this.colDoc.FieldName = "Doc";
            this.colDoc.Name = "colDoc";
            this.colDoc.OptionsColumn.AllowEdit = false;
            this.colDoc.Visible = true;
            this.colDoc.VisibleIndex = 8;
            this.colDoc.Width = 35;
            // 
            // colMA
            // 
            this.colMA.Caption = "erfasst";
            this.colMA.FieldName = "MA";
            this.colMA.Name = "colMA";
            this.colMA.OptionsColumn.AllowEdit = false;
            this.colMA.Visible = true;
            this.colMA.VisibleIndex = 9;
            this.colMA.Width = 65;
            // 
            // colPosStatus
            // 
            this.colPosStatus.Caption = "Stat.";
            this.colPosStatus.ColumnEdit = this.repStatusImg;
            this.colPosStatus.FieldName = "Status";
            this.colPosStatus.Name = "colPosStatus";
            this.colPosStatus.OptionsColumn.AllowEdit = false;
            this.colPosStatus.Visible = true;
            this.colPosStatus.VisibleIndex = 10;
            this.colPosStatus.Width = 40;
            // 
            // repStatusImg
            // 
            this.repStatusImg.AutoHeight = false;
            this.repStatusImg.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repStatusImg.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repStatusImg.Name = "repStatusImg";
            // 
            // colSelektion
            // 
            this.colSelektion.Caption = "Sel.";
            this.colSelektion.FieldName = "Sel";
            this.colSelektion.Name = "colSelektion";
            this.colSelektion.Width = 35;
            // 
            // edtSucheErfassungMA
            // 
            this.edtSucheErfassungMA.Location = new System.Drawing.Point(129, 40);
            this.edtSucheErfassungMA.Name = "edtSucheErfassungMA";
            this.edtSucheErfassungMA.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheErfassungMA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheErfassungMA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheErfassungMA.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheErfassungMA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheErfassungMA.Properties.Appearance.Options.UseFont = true;
            this.edtSucheErfassungMA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject25.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject25.Options.UseBackColor = true;
            this.edtSucheErfassungMA.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject25)});
            this.edtSucheErfassungMA.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheErfassungMA.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSucheErfassungMA.Size = new System.Drawing.Size(123, 24);
            this.edtSucheErfassungMA.TabIndex = 5;
            this.edtSucheErfassungMA.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheErfassungMA_UserModifiedFld);
            // 
            // edtSucheErfassungVon
            // 
            this.edtSucheErfassungVon.EditValue = null;
            this.edtSucheErfassungVon.Location = new System.Drawing.Point(258, 40);
            this.edtSucheErfassungVon.Name = "edtSucheErfassungVon";
            this.edtSucheErfassungVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheErfassungVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheErfassungVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheErfassungVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheErfassungVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheErfassungVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheErfassungVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheErfassungVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject24.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject24.Options.UseBackColor = true;
            this.edtSucheErfassungVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheErfassungVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject24)});
            this.edtSucheErfassungVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheErfassungVon.Properties.ShowToday = false;
            this.edtSucheErfassungVon.Size = new System.Drawing.Size(90, 24);
            this.edtSucheErfassungVon.TabIndex = 6;
            // 
            // lblSucheErfassung
            // 
            this.lblSucheErfassung.Location = new System.Drawing.Point(30, 40);
            this.lblSucheErfassung.Name = "lblSucheErfassung";
            this.lblSucheErfassung.Size = new System.Drawing.Size(93, 24);
            this.lblSucheErfassung.TabIndex = 4;
            this.lblSucheErfassung.Text = "Erfassung";
            this.lblSucheErfassung.UseCompatibleTextRendering = true;
            // 
            // edtSucheErfassungBis
            // 
            this.edtSucheErfassungBis.EditValue = null;
            this.edtSucheErfassungBis.Location = new System.Drawing.Point(354, 40);
            this.edtSucheErfassungBis.Name = "edtSucheErfassungBis";
            this.edtSucheErfassungBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheErfassungBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheErfassungBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheErfassungBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheErfassungBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheErfassungBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheErfassungBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheErfassungBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject23.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject23.Options.UseBackColor = true;
            this.edtSucheErfassungBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheErfassungBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject23)});
            this.edtSucheErfassungBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheErfassungBis.Properties.ShowToday = false;
            this.edtSucheErfassungBis.Size = new System.Drawing.Size(90, 24);
            this.edtSucheErfassungBis.TabIndex = 7;
            // 
            // lblSucheMutation
            // 
            this.lblSucheMutation.Location = new System.Drawing.Point(30, 70);
            this.lblSucheMutation.Name = "lblSucheMutation";
            this.lblSucheMutation.Size = new System.Drawing.Size(93, 24);
            this.lblSucheMutation.TabIndex = 8;
            this.lblSucheMutation.Text = "Mutation";
            this.lblSucheMutation.UseCompatibleTextRendering = true;
            // 
            // edtSucheMutationMA
            // 
            this.edtSucheMutationMA.Location = new System.Drawing.Point(129, 70);
            this.edtSucheMutationMA.Name = "edtSucheMutationMA";
            this.edtSucheMutationMA.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheMutationMA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheMutationMA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheMutationMA.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheMutationMA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheMutationMA.Properties.Appearance.Options.UseFont = true;
            this.edtSucheMutationMA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject22.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject22.Options.UseBackColor = true;
            this.edtSucheMutationMA.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject22)});
            this.edtSucheMutationMA.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheMutationMA.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSucheMutationMA.Size = new System.Drawing.Size(123, 24);
            this.edtSucheMutationMA.TabIndex = 9;
            this.edtSucheMutationMA.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheMutationMA_UserModifiedFld);
            // 
            // lblSucheValutaVon
            // 
            this.lblSucheValutaVon.Location = new System.Drawing.Point(30, 100);
            this.lblSucheValutaVon.Name = "lblSucheValutaVon";
            this.lblSucheValutaVon.Size = new System.Drawing.Size(93, 24);
            this.lblSucheValutaVon.TabIndex = 12;
            this.lblSucheValutaVon.Text = "Valuta von";
            this.lblSucheValutaVon.UseCompatibleTextRendering = true;
            // 
            // edtSucheMutationVon
            // 
            this.edtSucheMutationVon.EditValue = null;
            this.edtSucheMutationVon.Location = new System.Drawing.Point(258, 70);
            this.edtSucheMutationVon.Name = "edtSucheMutationVon";
            this.edtSucheMutationVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheMutationVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheMutationVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheMutationVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheMutationVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheMutationVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheMutationVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheMutationVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject21.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject21.Options.UseBackColor = true;
            this.edtSucheMutationVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheMutationVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject21)});
            this.edtSucheMutationVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheMutationVon.Properties.ShowToday = false;
            this.edtSucheMutationVon.Size = new System.Drawing.Size(90, 24);
            this.edtSucheMutationVon.TabIndex = 10;
            // 
            // edtSucheMutationBis
            // 
            this.edtSucheMutationBis.EditValue = null;
            this.edtSucheMutationBis.Location = new System.Drawing.Point(354, 70);
            this.edtSucheMutationBis.Name = "edtSucheMutationBis";
            this.edtSucheMutationBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheMutationBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheMutationBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheMutationBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheMutationBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheMutationBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheMutationBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheMutationBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject20.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject20.Options.UseBackColor = true;
            this.edtSucheMutationBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheMutationBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject20)});
            this.edtSucheMutationBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheMutationBis.Properties.ShowToday = false;
            this.edtSucheMutationBis.Size = new System.Drawing.Size(90, 24);
            this.edtSucheMutationBis.TabIndex = 11;
            // 
            // lblSucheMitarbeiter
            // 
            this.lblSucheMitarbeiter.Location = new System.Drawing.Point(129, 13);
            this.lblSucheMitarbeiter.Name = "lblSucheMitarbeiter";
            this.lblSucheMitarbeiter.Size = new System.Drawing.Size(100, 24);
            this.lblSucheMitarbeiter.TabIndex = 1;
            this.lblSucheMitarbeiter.Text = "Mitarbeiter/in";
            this.lblSucheMitarbeiter.UseCompatibleTextRendering = true;
            // 
            // edtSucheValutaVon
            // 
            this.edtSucheValutaVon.EditValue = null;
            this.edtSucheValutaVon.Location = new System.Drawing.Point(129, 100);
            this.edtSucheValutaVon.Name = "edtSucheValutaVon";
            this.edtSucheValutaVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheValutaVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheValutaVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheValutaVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheValutaVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheValutaVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheValutaVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheValutaVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject19.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject19.Options.UseBackColor = true;
            this.edtSucheValutaVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheValutaVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject19)});
            this.edtSucheValutaVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheValutaVon.Properties.ShowToday = false;
            this.edtSucheValutaVon.Size = new System.Drawing.Size(90, 24);
            this.edtSucheValutaVon.TabIndex = 13;
            // 
            // lblSucheValutaBis
            // 
            this.lblSucheValutaBis.Location = new System.Drawing.Point(225, 100);
            this.lblSucheValutaBis.Name = "lblSucheValutaBis";
            this.lblSucheValutaBis.Size = new System.Drawing.Size(27, 24);
            this.lblSucheValutaBis.TabIndex = 14;
            this.lblSucheValutaBis.Text = "bis";
            this.lblSucheValutaBis.UseCompatibleTextRendering = true;
            // 
            // edtSucheValutaBis
            // 
            this.edtSucheValutaBis.EditValue = null;
            this.edtSucheValutaBis.Location = new System.Drawing.Point(258, 100);
            this.edtSucheValutaBis.Name = "edtSucheValutaBis";
            this.edtSucheValutaBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheValutaBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheValutaBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheValutaBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheValutaBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheValutaBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheValutaBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheValutaBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject18.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject18.Options.UseBackColor = true;
            this.edtSucheValutaBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheValutaBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject18)});
            this.edtSucheValutaBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheValutaBis.Properties.ShowToday = false;
            this.edtSucheValutaBis.Size = new System.Drawing.Size(90, 24);
            this.edtSucheValutaBis.TabIndex = 15;
            // 
            // edtSucheStatus
            // 
            this.edtSucheStatus.Location = new System.Drawing.Point(129, 130);
            this.edtSucheStatus.Name = "edtSucheStatus";
            this.edtSucheStatus.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheStatus.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheStatus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheStatus.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheStatus.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheStatus.Properties.Appearance.Options.UseFont = true;
            this.edtSucheStatus.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheStatus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheStatus.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheStatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtSucheStatus.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheStatus.Size = new System.Drawing.Size(315, 24);
            this.edtSucheStatus.TabIndex = 17;
            // 
            // edtSucheBelegID
            // 
            this.edtSucheBelegID.Location = new System.Drawing.Point(601, 40);
            this.edtSucheBelegID.Name = "edtSucheBelegID";
            this.edtSucheBelegID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheBelegID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBelegID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBelegID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBelegID.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBelegID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBelegID.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBelegID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheBelegID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheBelegID.Size = new System.Drawing.Size(100, 24);
            this.edtSucheBelegID.TabIndex = 19;
            // 
            // lblSucheStatus
            // 
            this.lblSucheStatus.Location = new System.Drawing.Point(30, 130);
            this.lblSucheStatus.Name = "lblSucheStatus";
            this.lblSucheStatus.Size = new System.Drawing.Size(93, 24);
            this.lblSucheStatus.TabIndex = 16;
            this.lblSucheStatus.Text = "Status";
            this.lblSucheStatus.UseCompatibleTextRendering = true;
            // 
            // edtSucheFallNr
            // 
            this.edtSucheFallNr.Location = new System.Drawing.Point(601, 70);
            this.edtSucheFallNr.Name = "edtSucheFallNr";
            this.edtSucheFallNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheFallNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheFallNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheFallNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheFallNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheFallNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheFallNr.Properties.Appearance.Options.UseFont = true;
            this.edtSucheFallNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheFallNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheFallNr.Size = new System.Drawing.Size(100, 24);
            this.edtSucheFallNr.TabIndex = 21;
            // 
            // lblSucheDatumVon
            // 
            this.lblSucheDatumVon.Location = new System.Drawing.Point(258, 13);
            this.lblSucheDatumVon.Name = "lblSucheDatumVon";
            this.lblSucheDatumVon.Size = new System.Drawing.Size(90, 24);
            this.lblSucheDatumVon.TabIndex = 2;
            this.lblSucheDatumVon.Text = "Datum von";
            this.lblSucheDatumVon.UseCompatibleTextRendering = true;
            // 
            // lblSucheDatumBis
            // 
            this.lblSucheDatumBis.Location = new System.Drawing.Point(354, 13);
            this.lblSucheDatumBis.Name = "lblSucheDatumBis";
            this.lblSucheDatumBis.Size = new System.Drawing.Size(90, 24);
            this.lblSucheDatumBis.TabIndex = 3;
            this.lblSucheDatumBis.Text = "Datum bis";
            this.lblSucheDatumBis.UseCompatibleTextRendering = true;
            // 
            // lblSucheBelegID
            // 
            this.lblSucheBelegID.Location = new System.Drawing.Point(497, 40);
            this.lblSucheBelegID.Name = "lblSucheBelegID";
            this.lblSucheBelegID.Size = new System.Drawing.Size(98, 24);
            this.lblSucheBelegID.TabIndex = 18;
            this.lblSucheBelegID.Text = "Beleg-ID";
            this.lblSucheBelegID.UseCompatibleTextRendering = true;
            // 
            // lblSucheFallNr
            // 
            this.lblSucheFallNr.Location = new System.Drawing.Point(497, 70);
            this.lblSucheFallNr.Name = "lblSucheFallNr";
            this.lblSucheFallNr.Size = new System.Drawing.Size(98, 24);
            this.lblSucheFallNr.TabIndex = 20;
            this.lblSucheFallNr.Text = "Fall-Nr.";
            this.lblSucheFallNr.UseCompatibleTextRendering = true;
            // 
            // edtSucheSelectTop
            // 
            this.edtSucheSelectTop.Location = new System.Drawing.Point(601, 130);
            this.edtSucheSelectTop.Name = "edtSucheSelectTop";
            this.edtSucheSelectTop.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheSelectTop.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheSelectTop.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheSelectTop.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheSelectTop.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheSelectTop.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheSelectTop.Properties.Appearance.Options.UseFont = true;
            this.edtSucheSelectTop.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheSelectTop.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheSelectTop.Size = new System.Drawing.Size(100, 24);
            this.edtSucheSelectTop.TabIndex = 23;
            // 
            // lblSucheSelectTop
            // 
            this.lblSucheSelectTop.Location = new System.Drawing.Point(497, 130);
            this.lblSucheSelectTop.Name = "lblSucheSelectTop";
            this.lblSucheSelectTop.Size = new System.Drawing.Size(98, 24);
            this.lblSucheSelectTop.TabIndex = 22;
            this.lblSucheSelectTop.Text = "Max. Datensätze";
            this.lblSucheSelectTop.UseCompatibleTextRendering = true;
            // 
            // tabBgPosition
            // 
            this.tabBgPosition.Controls.Add(this.tpgBewilligung);
            this.tabBgPosition.Controls.Add(this.tpgDokumente);
            this.tabBgPosition.Controls.Add(this.tpgEinzelzahlung);
            this.tabBgPosition.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabBgPosition.Location = new System.Drawing.Point(0, 160);
            this.tabBgPosition.Name = "tabBgPosition";
            this.tabBgPosition.ShowFixedWidthTooltip = true;
            this.tabBgPosition.Size = new System.Drawing.Size(1002, 429);
            this.tabBgPosition.TabIndex = 2;
            this.tabBgPosition.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgEinzelzahlung,
            this.tpgDokumente,
            this.tpgBewilligung});
            this.tabBgPosition.TabsLineColor = System.Drawing.Color.Black;
            this.tabBgPosition.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabBgPosition.Text = "kissTabControlEx1";
            // 
            // tpgBewilligung
            // 
            this.tpgBewilligung.Controls.Add(this.grdBgBewilligung);
            this.tpgBewilligung.Controls.Add(this.panBewilligungDetails);
            this.tpgBewilligung.Location = new System.Drawing.Point(6, 6);
            this.tpgBewilligung.Margin = new System.Windows.Forms.Padding(9);
            this.tpgBewilligung.Name = "tpgBewilligung";
            this.tpgBewilligung.Size = new System.Drawing.Size(990, 391);
            this.tpgBewilligung.TabIndex = 2;
            this.tpgBewilligung.Title = "Bewilligung";
            // 
            // grdBgBewilligung
            // 
            this.grdBgBewilligung.DataSource = this.qryBgBewilligung;
            this.grdBgBewilligung.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdBgBewilligung.EmbeddedNavigator.Name = "";
            this.grdBgBewilligung.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBgBewilligung.Location = new System.Drawing.Point(0, 0);
            this.grdBgBewilligung.MainView = this.grvBgBewilligung;
            this.grdBgBewilligung.Name = "grdBgBewilligung";
            this.grdBgBewilligung.Size = new System.Drawing.Size(990, 259);
            this.grdBgBewilligung.TabIndex = 0;
            this.grdBgBewilligung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBgBewilligung});
            // 
            // qryBgBewilligung
            // 
            this.qryBgBewilligung.HostControl = this;
            this.qryBgBewilligung.SelectStatement = resources.GetString("qryBgBewilligung.SelectStatement");
            // 
            // grvBgBewilligung
            // 
            this.grvBgBewilligung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBgBewilligung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgBewilligung.Appearance.Empty.Options.UseBackColor = true;
            this.grvBgBewilligung.Appearance.Empty.Options.UseFont = true;
            this.grvBgBewilligung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgBewilligung.Appearance.EvenRow.Options.UseFont = true;
            this.grvBgBewilligung.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBgBewilligung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgBewilligung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBgBewilligung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBgBewilligung.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBgBewilligung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBgBewilligung.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBgBewilligung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgBewilligung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBgBewilligung.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBgBewilligung.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBgBewilligung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBgBewilligung.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgBewilligung.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBgBewilligung.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvBgBewilligung.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvBgBewilligung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgBewilligung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBgBewilligung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgBewilligung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgBewilligung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBgBewilligung.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBgBewilligung.Appearance.GroupRow.Options.UseFont = true;
            this.grvBgBewilligung.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBgBewilligung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBgBewilligung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBgBewilligung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgBewilligung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBgBewilligung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBgBewilligung.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBgBewilligung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBgBewilligung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgBewilligung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBgBewilligung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBgBewilligung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBgBewilligung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBgBewilligung.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBgBewilligung.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBgBewilligung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgBewilligung.Appearance.OddRow.Options.UseFont = true;
            this.grvBgBewilligung.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBgBewilligung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgBewilligung.Appearance.Row.Options.UseBackColor = true;
            this.grvBgBewilligung.Appearance.Row.Options.UseFont = true;
            this.grvBgBewilligung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgBewilligung.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBgBewilligung.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBgBewilligung.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBgBewilligung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBgBewilligung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBbwGrouper,
            this.colDatum,
            this.colAbsender,
            this.colEmpfaenger,
            this.colBgBewilligungCode,
            this.colBemerkungen});
            this.grvBgBewilligung.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBgBewilligung.GridControl = this.grdBgBewilligung;
            this.grvBgBewilligung.GroupCount = 1;
            this.grvBgBewilligung.Name = "grvBgBewilligung";
            this.grvBgBewilligung.OptionsBehavior.Editable = false;
            this.grvBgBewilligung.OptionsCustomization.AllowFilter = false;
            this.grvBgBewilligung.OptionsFilter.AllowFilterEditor = false;
            this.grvBgBewilligung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBgBewilligung.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBgBewilligung.OptionsNavigation.UseTabKey = false;
            this.grvBgBewilligung.OptionsView.ColumnAutoWidth = false;
            this.grvBgBewilligung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBgBewilligung.OptionsView.ShowGroupPanel = false;
            this.grvBgBewilligung.OptionsView.ShowIndicator = false;
            this.grvBgBewilligung.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colBbwGrouper, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colBbwGrouper
            // 
            this.colBbwGrouper.Caption = "Beleg";
            this.colBbwGrouper.FieldName = "Grouper";
            this.colBbwGrouper.Name = "colBbwGrouper";
            this.colBbwGrouper.Visible = true;
            this.colBbwGrouper.VisibleIndex = 0;
            this.colBbwGrouper.Width = 100;
            // 
            // colDatum
            // 
            this.colDatum.Caption = "Datum";
            this.colDatum.FieldName = "Datum";
            this.colDatum.Name = "colDatum";
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 0;
            this.colDatum.Width = 102;
            // 
            // colAbsender
            // 
            this.colAbsender.Caption = "Absender";
            this.colAbsender.FieldName = "Absender";
            this.colAbsender.Name = "colAbsender";
            this.colAbsender.Visible = true;
            this.colAbsender.VisibleIndex = 1;
            this.colAbsender.Width = 137;
            // 
            // colEmpfaenger
            // 
            this.colEmpfaenger.Caption = "Empfänger";
            this.colEmpfaenger.FieldName = "Empfaenger";
            this.colEmpfaenger.Name = "colEmpfaenger";
            this.colEmpfaenger.Visible = true;
            this.colEmpfaenger.VisibleIndex = 2;
            this.colEmpfaenger.Width = 127;
            // 
            // colBgBewilligungCode
            // 
            this.colBgBewilligungCode.Caption = "Typ";
            this.colBgBewilligungCode.FieldName = "BgBewilligungCode";
            this.colBgBewilligungCode.Name = "colBgBewilligungCode";
            this.colBgBewilligungCode.Visible = true;
            this.colBgBewilligungCode.VisibleIndex = 3;
            this.colBgBewilligungCode.Width = 169;
            // 
            // colBemerkungen
            // 
            this.colBemerkungen.Caption = "Bemerkungen";
            this.colBemerkungen.FieldName = "Bemerkung";
            this.colBemerkungen.Name = "colBemerkungen";
            this.colBemerkungen.Visible = true;
            this.colBemerkungen.VisibleIndex = 4;
            this.colBemerkungen.Width = 232;
            // 
            // panBewilligungDetails
            // 
            this.panBewilligungDetails.Controls.Add(this.lblBewilligungAbsender);
            this.panBewilligungDetails.Controls.Add(this.edtBewilligungBemerkung);
            this.panBewilligungDetails.Controls.Add(this.edtBewilligungAbsender);
            this.panBewilligungDetails.Controls.Add(this.lblBewilligungBemerkung);
            this.panBewilligungDetails.Controls.Add(this.lblBewilligungEmpfaenger);
            this.panBewilligungDetails.Controls.Add(this.edtBewilligungEmpfaenger);
            this.panBewilligungDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panBewilligungDetails.Location = new System.Drawing.Point(0, 259);
            this.panBewilligungDetails.Name = "panBewilligungDetails";
            this.panBewilligungDetails.Size = new System.Drawing.Size(990, 132);
            this.panBewilligungDetails.TabIndex = 1;
            // 
            // lblBewilligungAbsender
            // 
            this.lblBewilligungAbsender.Location = new System.Drawing.Point(9, 9);
            this.lblBewilligungAbsender.Name = "lblBewilligungAbsender";
            this.lblBewilligungAbsender.Size = new System.Drawing.Size(72, 24);
            this.lblBewilligungAbsender.TabIndex = 0;
            this.lblBewilligungAbsender.Text = "Absender";
            this.lblBewilligungAbsender.UseCompatibleTextRendering = true;
            // 
            // edtBewilligungBemerkung
            // 
            this.edtBewilligungBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBewilligungBemerkung.DataMember = "Bemerkung";
            this.edtBewilligungBemerkung.DataSource = this.qryBgBewilligung;
            this.edtBewilligungBemerkung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBewilligungBemerkung.Location = new System.Drawing.Point(87, 69);
            this.edtBewilligungBemerkung.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.edtBewilligungBemerkung.Name = "edtBewilligungBemerkung";
            this.edtBewilligungBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBewilligungBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBewilligungBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBewilligungBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBewilligungBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBewilligungBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBewilligungBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBewilligungBemerkung.Properties.ReadOnly = true;
            this.edtBewilligungBemerkung.Size = new System.Drawing.Size(894, 54);
            this.edtBewilligungBemerkung.TabIndex = 5;
            // 
            // edtBewilligungAbsender
            // 
            this.edtBewilligungAbsender.DataMember = "AbsenderText";
            this.edtBewilligungAbsender.DataSource = this.qryBgBewilligung;
            this.edtBewilligungAbsender.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBewilligungAbsender.Location = new System.Drawing.Point(87, 9);
            this.edtBewilligungAbsender.Name = "edtBewilligungAbsender";
            this.edtBewilligungAbsender.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBewilligungAbsender.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBewilligungAbsender.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBewilligungAbsender.Properties.Appearance.Options.UseBackColor = true;
            this.edtBewilligungAbsender.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBewilligungAbsender.Properties.Appearance.Options.UseFont = true;
            this.edtBewilligungAbsender.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBewilligungAbsender.Properties.ReadOnly = true;
            this.edtBewilligungAbsender.Size = new System.Drawing.Size(383, 24);
            this.edtBewilligungAbsender.TabIndex = 1;
            // 
            // lblBewilligungBemerkung
            // 
            this.lblBewilligungBemerkung.Location = new System.Drawing.Point(9, 69);
            this.lblBewilligungBemerkung.Name = "lblBewilligungBemerkung";
            this.lblBewilligungBemerkung.Size = new System.Drawing.Size(72, 24);
            this.lblBewilligungBemerkung.TabIndex = 4;
            this.lblBewilligungBemerkung.Text = "Bemerkung";
            this.lblBewilligungBemerkung.UseCompatibleTextRendering = true;
            // 
            // lblBewilligungEmpfaenger
            // 
            this.lblBewilligungEmpfaenger.Location = new System.Drawing.Point(9, 39);
            this.lblBewilligungEmpfaenger.Name = "lblBewilligungEmpfaenger";
            this.lblBewilligungEmpfaenger.Size = new System.Drawing.Size(72, 24);
            this.lblBewilligungEmpfaenger.TabIndex = 2;
            this.lblBewilligungEmpfaenger.Text = "Empfänger";
            this.lblBewilligungEmpfaenger.UseCompatibleTextRendering = true;
            // 
            // edtBewilligungEmpfaenger
            // 
            this.edtBewilligungEmpfaenger.DataMember = "EmpfaengerText";
            this.edtBewilligungEmpfaenger.DataSource = this.qryBgBewilligung;
            this.edtBewilligungEmpfaenger.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBewilligungEmpfaenger.Location = new System.Drawing.Point(87, 39);
            this.edtBewilligungEmpfaenger.Name = "edtBewilligungEmpfaenger";
            this.edtBewilligungEmpfaenger.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBewilligungEmpfaenger.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBewilligungEmpfaenger.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBewilligungEmpfaenger.Properties.Appearance.Options.UseBackColor = true;
            this.edtBewilligungEmpfaenger.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBewilligungEmpfaenger.Properties.Appearance.Options.UseFont = true;
            this.edtBewilligungEmpfaenger.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBewilligungEmpfaenger.Properties.ReadOnly = true;
            this.edtBewilligungEmpfaenger.Size = new System.Drawing.Size(383, 24);
            this.edtBewilligungEmpfaenger.TabIndex = 3;
            // 
            // tpgDokumente
            // 
            this.tpgDokumente.Controls.Add(this.grdBgDokumente);
            this.tpgDokumente.Controls.Add(this.panDokumenteDetails);
            this.tpgDokumente.Location = new System.Drawing.Point(6, 6);
            this.tpgDokumente.Margin = new System.Windows.Forms.Padding(9);
            this.tpgDokumente.Name = "tpgDokumente";
            this.tpgDokumente.Size = new System.Drawing.Size(990, 391);
            this.tpgDokumente.TabIndex = 1;
            this.tpgDokumente.Title = "Dokumente";
            // 
            // grdBgDokumente
            // 
            this.grdBgDokumente.DataSource = this.qryBgDokumente;
            this.grdBgDokumente.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdBgDokumente.EmbeddedNavigator.Name = "";
            this.grdBgDokumente.Location = new System.Drawing.Point(0, 0);
            this.grdBgDokumente.MainView = this.grvBgDokumente;
            this.grdBgDokumente.Name = "grdBgDokumente";
            this.grdBgDokumente.Size = new System.Drawing.Size(990, 349);
            this.grdBgDokumente.TabIndex = 0;
            this.grdBgDokumente.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBgDokumente});
            // 
            // qryBgDokumente
            // 
            this.qryBgDokumente.CanDelete = true;
            this.qryBgDokumente.CanInsert = true;
            this.qryBgDokumente.CanUpdate = true;
            this.qryBgDokumente.DeleteQuestion = "Soll das Dokument gelöscht werden ?";
            this.qryBgDokumente.HostControl = this;
            this.qryBgDokumente.SelectStatement = resources.GetString("qryBgDokumente.SelectStatement");
            this.qryBgDokumente.TableName = "BgDokument";
            this.qryBgDokumente.AfterInsert += new System.EventHandler(this.qryBgDokumente_AfterInsert);
            this.qryBgDokumente.BeforePost += new System.EventHandler(this.qryBgDokumente_BeforePost);
            this.qryBgDokumente.ColumnChanged += new System.Data.DataColumnChangeEventHandler(this.qryBgDokumente_ColumnChanged);
            // 
            // grvBgDokumente
            // 
            this.grvBgDokumente.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBgDokumente.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgDokumente.Appearance.Empty.Options.UseBackColor = true;
            this.grvBgDokumente.Appearance.Empty.Options.UseFont = true;
            this.grvBgDokumente.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgDokumente.Appearance.EvenRow.Options.UseFont = true;
            this.grvBgDokumente.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBgDokumente.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgDokumente.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBgDokumente.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBgDokumente.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBgDokumente.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBgDokumente.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBgDokumente.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgDokumente.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBgDokumente.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBgDokumente.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBgDokumente.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBgDokumente.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgDokumente.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBgDokumente.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgDokumente.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgDokumente.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBgDokumente.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBgDokumente.Appearance.GroupRow.Options.UseFont = true;
            this.grvBgDokumente.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBgDokumente.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBgDokumente.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBgDokumente.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgDokumente.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBgDokumente.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBgDokumente.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBgDokumente.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBgDokumente.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgDokumente.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBgDokumente.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBgDokumente.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBgDokumente.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBgDokumente.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBgDokumente.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBgDokumente.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgDokumente.Appearance.OddRow.Options.UseFont = true;
            this.grvBgDokumente.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBgDokumente.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgDokumente.Appearance.Row.Options.UseBackColor = true;
            this.grvBgDokumente.Appearance.Row.Options.UseFont = true;
            this.grvBgDokumente.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgDokumente.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBgDokumente.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBgDokumente.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBgDokumente.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBgDokumente.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDocTyp,
            this.colStichwort,
            this.colDateCreation,
            this.colDateLastSave});
            this.grvBgDokumente.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBgDokumente.GridControl = this.grdBgDokumente;
            this.grvBgDokumente.Name = "grvBgDokumente";
            this.grvBgDokumente.OptionsBehavior.Editable = false;
            this.grvBgDokumente.OptionsCustomization.AllowFilter = false;
            this.grvBgDokumente.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBgDokumente.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBgDokumente.OptionsNavigation.UseTabKey = false;
            this.grvBgDokumente.OptionsView.ColumnAutoWidth = false;
            this.grvBgDokumente.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBgDokumente.OptionsView.ShowGroupPanel = false;
            this.grvBgDokumente.OptionsView.ShowIndicator = false;
            // 
            // colDocTyp
            // 
            this.colDocTyp.Caption = "Typ";
            this.colDocTyp.FieldName = "BgDokumentTypCode";
            this.colDocTyp.Name = "colDocTyp";
            this.colDocTyp.Visible = true;
            this.colDocTyp.VisibleIndex = 0;
            this.colDocTyp.Width = 123;
            // 
            // colStichwort
            // 
            this.colStichwort.Caption = "Stichwort";
            this.colStichwort.FieldName = "Stichwort";
            this.colStichwort.Name = "colStichwort";
            this.colStichwort.Visible = true;
            this.colStichwort.VisibleIndex = 1;
            this.colStichwort.Width = 382;
            // 
            // colDateCreation
            // 
            this.colDateCreation.Caption = "Erstellungsdatum";
            this.colDateCreation.FieldName = "DateCreation";
            this.colDateCreation.Name = "colDateCreation";
            this.colDateCreation.Visible = true;
            this.colDateCreation.VisibleIndex = 2;
            this.colDateCreation.Width = 110;
            // 
            // colDateLastSave
            // 
            this.colDateLastSave.Caption = "Letzte Speicherung";
            this.colDateLastSave.FieldName = "DateLastSave";
            this.colDateLastSave.Name = "colDateLastSave";
            this.colDateLastSave.Visible = true;
            this.colDateLastSave.VisibleIndex = 3;
            this.colDateLastSave.Width = 121;
            // 
            // panDokumenteDetails
            // 
            this.panDokumenteDetails.Controls.Add(this.lblDokumentTyp);
            this.panDokumenteDetails.Controls.Add(this.edtDocument);
            this.panDokumenteDetails.Controls.Add(this.edtDokumentTyp);
            this.panDokumenteDetails.Controls.Add(this.lblDokument);
            this.panDokumenteDetails.Controls.Add(this.lblStichwort);
            this.panDokumenteDetails.Controls.Add(this.edtStichwort);
            this.panDokumenteDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panDokumenteDetails.Location = new System.Drawing.Point(0, 349);
            this.panDokumenteDetails.Name = "panDokumenteDetails";
            this.panDokumenteDetails.Size = new System.Drawing.Size(990, 42);
            this.panDokumenteDetails.TabIndex = 1;
            // 
            // lblDokumentTyp
            // 
            this.lblDokumentTyp.Location = new System.Drawing.Point(9, 9);
            this.lblDokumentTyp.Name = "lblDokumentTyp";
            this.lblDokumentTyp.Size = new System.Drawing.Size(36, 24);
            this.lblDokumentTyp.TabIndex = 0;
            this.lblDokumentTyp.Text = "Typ";
            this.lblDokumentTyp.UseCompatibleTextRendering = true;
            // 
            // edtDocument
            // 
            this.edtDocument.Context = "FaDokumente";
            this.edtDocument.DataMember = "DocumentID";
            this.edtDocument.DataSource = this.qryBgDokumente;
            this.edtDocument.Location = new System.Drawing.Point(851, 9);
            this.edtDocument.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.edtDocument.Name = "edtDocument";
            this.edtDocument.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDocument.Properties.Appearance.Options.UseBackColor = true;
            this.edtDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDocument.Properties.Appearance.Options.UseFont = true;
            this.edtDocument.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject17.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject17.Options.UseBackColor = true;
            serializableAppearanceObject26.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject26.Options.UseBackColor = true;
            serializableAppearanceObject27.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject27.Options.UseBackColor = true;
            serializableAppearanceObject28.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject28.Options.UseBackColor = true;
            this.edtDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject17, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocument.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject26, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocument.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject27, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocument.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject28, "Dokument importieren")});
            this.edtDocument.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDocument.Properties.ReadOnly = true;
            this.edtDocument.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtDocument.Size = new System.Drawing.Size(117, 24);
            this.edtDocument.TabIndex = 5;
            this.edtDocument.DocumentDeleted += new System.EventHandler(this.edtDocument_DocumentDeleted);
            // 
            // edtDokumentTyp
            // 
            this.edtDokumentTyp.AllowNull = false;
            this.edtDokumentTyp.DataMember = "BgDokumentTypCode";
            this.edtDokumentTyp.DataSource = this.qryBgDokumente;
            this.edtDokumentTyp.Location = new System.Drawing.Point(51, 9);
            this.edtDokumentTyp.LOVName = "BgDokumentTyp";
            this.edtDokumentTyp.Name = "edtDokumentTyp";
            this.edtDokumentTyp.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDokumentTyp.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDokumentTyp.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDokumentTyp.Properties.Appearance.Options.UseBackColor = true;
            this.edtDokumentTyp.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDokumentTyp.Properties.Appearance.Options.UseFont = true;
            this.edtDokumentTyp.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtDokumentTyp.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtDokumentTyp.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtDokumentTyp.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtDokumentTyp.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtDokumentTyp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtDokumentTyp.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDokumentTyp.Properties.NullText = "";
            this.edtDokumentTyp.Properties.ShowFooter = false;
            this.edtDokumentTyp.Properties.ShowHeader = false;
            this.edtDokumentTyp.Size = new System.Drawing.Size(134, 24);
            this.edtDokumentTyp.TabIndex = 1;
            // 
            // lblDokument
            // 
            this.lblDokument.Location = new System.Drawing.Point(774, 9);
            this.lblDokument.Name = "lblDokument";
            this.lblDokument.Size = new System.Drawing.Size(71, 24);
            this.lblDokument.TabIndex = 4;
            this.lblDokument.Text = "Dokument";
            this.lblDokument.UseCompatibleTextRendering = true;
            // 
            // lblStichwort
            // 
            this.lblStichwort.Location = new System.Drawing.Point(191, 9);
            this.lblStichwort.Name = "lblStichwort";
            this.lblStichwort.Size = new System.Drawing.Size(66, 24);
            this.lblStichwort.TabIndex = 2;
            this.lblStichwort.Text = "Stichwort";
            this.lblStichwort.UseCompatibleTextRendering = true;
            // 
            // edtStichwort
            // 
            this.edtStichwort.DataMember = "Stichwort";
            this.edtStichwort.DataSource = this.qryBgDokumente;
            this.edtStichwort.Location = new System.Drawing.Point(263, 9);
            this.edtStichwort.Name = "edtStichwort";
            this.edtStichwort.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStichwort.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStichwort.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStichwort.Properties.Appearance.Options.UseBackColor = true;
            this.edtStichwort.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStichwort.Properties.Appearance.Options.UseFont = true;
            this.edtStichwort.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStichwort.Size = new System.Drawing.Size(505, 24);
            this.edtStichwort.TabIndex = 3;
            // 
            // tpgEinzelzahlung
            // 
            this.tpgEinzelzahlung.Controls.Add(this.panSetStatus);
            this.tpgEinzelzahlung.Controls.Add(this.btnWeitereKOA);
            this.tpgEinzelzahlung.Controls.Add(this.btnPositionBewilligung);
            this.tpgEinzelzahlung.Controls.Add(this.ctlErfassungMutation);
            this.tpgEinzelzahlung.Controls.Add(this.panNewItems);
            this.tpgEinzelzahlung.Controls.Add(this.edtBelegNr);
            this.tpgEinzelzahlung.Controls.Add(this.lblBelegNr);
            this.tpgEinzelzahlung.Controls.Add(this.edtPositionID);
            this.tpgEinzelzahlung.Controls.Add(this.lblPositionID);
            this.tpgEinzelzahlung.Controls.Add(this.edtBgSplittingCode);
            this.tpgEinzelzahlung.Controls.Add(this.lblBgSplittingCode);
            this.tpgEinzelzahlung.Controls.Add(this.edtVerwPeriodeBis);
            this.tpgEinzelzahlung.Controls.Add(this.lblVerwPeriodeStrich);
            this.tpgEinzelzahlung.Controls.Add(this.edtVerwPeriodeVon);
            this.tpgEinzelzahlung.Controls.Add(this.lblVerwPeriode);
            this.tpgEinzelzahlung.Controls.Add(this.edtBemerkung);
            this.tpgEinzelzahlung.Controls.Add(this.lblBemerkung);
            this.tpgEinzelzahlung.Controls.Add(this.edtMitteilungZeile3);
            this.tpgEinzelzahlung.Controls.Add(this.edtMitteilungZeile2);
            this.tpgEinzelzahlung.Controls.Add(this.edtMitteilungZeile1);
            this.tpgEinzelzahlung.Controls.Add(this.lblZahlungsgrund);
            this.tpgEinzelzahlung.Controls.Add(this.edtReferenzNummer);
            this.tpgEinzelzahlung.Controls.Add(this.lblReferenzNummer);
            this.tpgEinzelzahlung.Controls.Add(this.edtZusatzInfo);
            this.tpgEinzelzahlung.Controls.Add(this.edtKreditor);
            this.tpgEinzelzahlung.Controls.Add(this.lblKreditor);
            this.tpgEinzelzahlung.Controls.Add(this.edtBelegDatum);
            this.tpgEinzelzahlung.Controls.Add(this.lblBelegDatum);
            this.tpgEinzelzahlung.Controls.Add(this.edtValutaDatum);
            this.tpgEinzelzahlung.Controls.Add(this.lblValutaDatum);
            this.tpgEinzelzahlung.Controls.Add(this.btnMonatsbudget);
            this.tpgEinzelzahlung.Controls.Add(this.grdBgBudget);
            this.tpgEinzelzahlung.Controls.Add(this.lblMonatsbudget);
            this.tpgEinzelzahlung.Controls.Add(this.edtAuszahlungsart);
            this.tpgEinzelzahlung.Controls.Add(this.lblAuszahlungsart);
            this.tpgEinzelzahlung.Controls.Add(this.edtBgSpezkontoID);
            this.tpgEinzelzahlung.Controls.Add(this.lblBgSpezkontoID);
            this.tpgEinzelzahlung.Controls.Add(this.edtBaPersonID);
            this.tpgEinzelzahlung.Controls.Add(this.lblBaPersonID);
            this.tpgEinzelzahlung.Controls.Add(this.edtBetrag);
            this.tpgEinzelzahlung.Controls.Add(this.lblBetrag);
            this.tpgEinzelzahlung.Controls.Add(this.edtBuchungstext);
            this.tpgEinzelzahlung.Controls.Add(this.lblBuchungstext);
            this.tpgEinzelzahlung.Controls.Add(this.edtKostenart);
            this.tpgEinzelzahlung.Controls.Add(this.lblKostenart);
            this.tpgEinzelzahlung.Controls.Add(this.edtAdresse);
            this.tpgEinzelzahlung.Controls.Add(this.lblAdresse);
            this.tpgEinzelzahlung.Controls.Add(this.edtKlientID);
            this.tpgEinzelzahlung.Controls.Add(this.edtKlient);
            this.tpgEinzelzahlung.Controls.Add(this.lblKlient);
            this.tpgEinzelzahlung.Controls.Add(this.edtKategorie);
            this.tpgEinzelzahlung.Controls.Add(this.lblKategorie);
            this.tpgEinzelzahlung.Location = new System.Drawing.Point(6, 6);
            this.tpgEinzelzahlung.Margin = new System.Windows.Forms.Padding(9);
            this.tpgEinzelzahlung.Name = "tpgEinzelzahlung";
            this.tpgEinzelzahlung.Size = new System.Drawing.Size(990, 391);
            this.tpgEinzelzahlung.TabIndex = 0;
            this.tpgEinzelzahlung.Title = "Einzelzahlung";
            // 
            // panSetStatus
            // 
            this.panSetStatus.Controls.Add(this.btnGraustellen);
            this.panSetStatus.Controls.Add(this.panSetStatusBorder);
            this.panSetStatus.Controls.Add(this.btnFreigeben);
            this.panSetStatus.Location = new System.Drawing.Point(939, 0);
            this.panSetStatus.Name = "panSetStatus";
            this.panSetStatus.Size = new System.Drawing.Size(39, 391);
            this.panSetStatus.TabIndex = 51;
            // 
            // btnGraustellen
            // 
            this.btnGraustellen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGraustellen.Location = new System.Drawing.Point(6, 39);
            this.btnGraustellen.Name = "btnGraustellen";
            this.btnGraustellen.Padding = new System.Windows.Forms.Padding(0, 0, 2, 1);
            this.btnGraustellen.Size = new System.Drawing.Size(24, 24);
            this.btnGraustellen.TabIndex = 3;
            this.btnGraustellen.Text = "G";
            this.btnGraustellen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGraustellen.UseVisualStyleBackColor = false;
            this.btnGraustellen.Click += new System.EventHandler(this.btnGraustellen_Click);
            // 
            // panSetStatusBorder
            // 
            this.panSetStatusBorder.BackColor = System.Drawing.Color.Black;
            this.panSetStatusBorder.Dock = System.Windows.Forms.DockStyle.Left;
            this.panSetStatusBorder.Location = new System.Drawing.Point(0, 0);
            this.panSetStatusBorder.Name = "panSetStatusBorder";
            this.panSetStatusBorder.Size = new System.Drawing.Size(1, 391);
            this.panSetStatusBorder.TabIndex = 2;
            // 
            // btnFreigeben
            // 
            this.btnFreigeben.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFreigeben.Location = new System.Drawing.Point(6, 9);
            this.btnFreigeben.Name = "btnFreigeben";
            this.btnFreigeben.Padding = new System.Windows.Forms.Padding(0, 0, 2, 1);
            this.btnFreigeben.Size = new System.Drawing.Size(24, 24);
            this.btnFreigeben.TabIndex = 0;
            this.btnFreigeben.Text = "F";
            this.btnFreigeben.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFreigeben.UseVisualStyleBackColor = false;
            this.btnFreigeben.Click += new System.EventHandler(this.btnFreigeben_Click);
            // 
            // btnWeitereKOA
            // 
            this.btnWeitereKOA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWeitereKOA.Location = new System.Drawing.Point(423, 144);
            this.btnWeitereKOA.Name = "btnWeitereKOA";
            this.btnWeitereKOA.Size = new System.Drawing.Size(104, 24);
            this.btnWeitereKOA.TabIndex = 48;
            this.btnWeitereKOA.Text = "Weitere KoA...";
            this.btnWeitereKOA.UseCompatibleTextRendering = true;
            this.btnWeitereKOA.UseVisualStyleBackColor = false;
            this.btnWeitereKOA.Click += new System.EventHandler(this.btnWeitereKOA_Click);
            // 
            // btnPositionBewilligung
            // 
            this.btnPositionBewilligung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPositionBewilligung.Image = ((System.Drawing.Image)(resources.GetObject("btnPositionBewilligung.Image")));
            this.btnPositionBewilligung.Location = new System.Drawing.Point(246, 144);
            this.btnPositionBewilligung.Name = "btnPositionBewilligung";
            this.btnPositionBewilligung.Size = new System.Drawing.Size(24, 24);
            this.btnPositionBewilligung.TabIndex = 47;
            this.btnPositionBewilligung.UseCompatibleTextRendering = true;
            this.btnPositionBewilligung.UseVisualStyleBackColor = false;
            this.btnPositionBewilligung.Click += new System.EventHandler(this.btnPositionBewilligung_Click);
            // 
            // ctlErfassungMutation
            // 
            this.ctlErfassungMutation.ActiveSQLQuery = this.qryBgPosition;
            this.ctlErfassungMutation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctlErfassungMutation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlErfassungMutation.LabelLength = 60;
            this.ctlErfassungMutation.Location = new System.Drawing.Point(640, 345);
            this.ctlErfassungMutation.Name = "ctlErfassungMutation";
            this.ctlErfassungMutation.Size = new System.Drawing.Size(287, 40);
            this.ctlErfassungMutation.TabIndex = 46;
            // 
            // panNewItems
            // 
            this.panNewItems.Controls.Add(this.panNewItemsBorder);
            this.panNewItems.Controls.Add(this.btnEinzelzahlung);
            this.panNewItems.Controls.Add(this.btnZusatzleistung);
            this.panNewItems.Dock = System.Windows.Forms.DockStyle.Left;
            this.panNewItems.Location = new System.Drawing.Point(0, 0);
            this.panNewItems.Name = "panNewItems";
            this.panNewItems.Size = new System.Drawing.Size(35, 391);
            this.panNewItems.TabIndex = 50;
            // 
            // panNewItemsBorder
            // 
            this.panNewItemsBorder.BackColor = System.Drawing.Color.Black;
            this.panNewItemsBorder.Dock = System.Windows.Forms.DockStyle.Right;
            this.panNewItemsBorder.Location = new System.Drawing.Point(34, 0);
            this.panNewItemsBorder.Name = "panNewItemsBorder";
            this.panNewItemsBorder.Size = new System.Drawing.Size(1, 391);
            this.panNewItemsBorder.TabIndex = 2;
            // 
            // btnEinzelzahlung
            // 
            this.btnEinzelzahlung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEinzelzahlung.IconID = 1386;
            this.btnEinzelzahlung.Location = new System.Drawing.Point(5, 9);
            this.btnEinzelzahlung.Name = "btnEinzelzahlung";
            this.btnEinzelzahlung.Size = new System.Drawing.Size(24, 24);
            this.btnEinzelzahlung.TabIndex = 0;
            this.btnEinzelzahlung.Text = "E";
            this.btnEinzelzahlung.UseCompatibleTextRendering = true;
            this.btnEinzelzahlung.UseVisualStyleBackColor = false;
            this.btnEinzelzahlung.Click += new System.EventHandler(this.btnEinzelzahlung_Click);
            // 
            // btnZusatzleistung
            // 
            this.btnZusatzleistung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZusatzleistung.IconID = 1388;
            this.btnZusatzleistung.Location = new System.Drawing.Point(5, 39);
            this.btnZusatzleistung.Name = "btnZusatzleistung";
            this.btnZusatzleistung.Size = new System.Drawing.Size(24, 24);
            this.btnZusatzleistung.TabIndex = 1;
            this.btnZusatzleistung.Text = "Z";
            this.btnZusatzleistung.UseCompatibleTextRendering = true;
            this.btnZusatzleistung.UseVisualStyleBackColor = false;
            this.btnZusatzleistung.Click += new System.EventHandler(this.btnZusatzleistung_Click);
            // 
            // edtBelegNr
            // 
            this.edtBelegNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBelegNr.DataMember = "BelegNr";
            this.edtBelegNr.DataSource = this.qryBgPosition;
            this.edtBelegNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBelegNr.Location = new System.Drawing.Point(837, 315);
            this.edtBelegNr.Name = "edtBelegNr";
            this.edtBelegNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBelegNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBelegNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBelegNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBelegNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtBelegNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBelegNr.Properties.Appearance.Options.UseFont = true;
            this.edtBelegNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBelegNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBelegNr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBelegNr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBelegNr.Properties.ReadOnly = true;
            this.edtBelegNr.Size = new System.Drawing.Size(90, 24);
            this.edtBelegNr.TabIndex = 45;
            // 
            // lblBelegNr
            // 
            this.lblBelegNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBelegNr.Location = new System.Drawing.Point(764, 315);
            this.lblBelegNr.Name = "lblBelegNr";
            this.lblBelegNr.Size = new System.Drawing.Size(67, 24);
            this.lblBelegNr.TabIndex = 44;
            this.lblBelegNr.Text = "Beleg-Nr.";
            this.lblBelegNr.UseCompatibleTextRendering = true;
            // 
            // edtPositionID
            // 
            this.edtPositionID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtPositionID.DataMember = "BgPositionID";
            this.edtPositionID.DataSource = this.qryBgPosition;
            this.edtPositionID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPositionID.Location = new System.Drawing.Point(640, 315);
            this.edtPositionID.Name = "edtPositionID";
            this.edtPositionID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtPositionID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPositionID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPositionID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPositionID.Properties.Appearance.Options.UseBackColor = true;
            this.edtPositionID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPositionID.Properties.Appearance.Options.UseFont = true;
            this.edtPositionID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPositionID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPositionID.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtPositionID.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtPositionID.Properties.ReadOnly = true;
            this.edtPositionID.Size = new System.Drawing.Size(90, 24);
            this.edtPositionID.TabIndex = 43;
            // 
            // lblPositionID
            // 
            this.lblPositionID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPositionID.Location = new System.Drawing.Point(548, 315);
            this.lblPositionID.Name = "lblPositionID";
            this.lblPositionID.Size = new System.Drawing.Size(86, 24);
            this.lblPositionID.TabIndex = 42;
            this.lblPositionID.Text = "Position-ID";
            this.lblPositionID.UseCompatibleTextRendering = true;
            // 
            // edtBgSplittingCode
            // 
            this.edtBgSplittingCode.AllowNull = false;
            this.edtBgSplittingCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBgSplittingCode.DataMember = "BgSplittingartCode";
            this.edtBgSplittingCode.DataSource = this.qryBgPosition;
            this.edtBgSplittingCode.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBgSplittingCode.Location = new System.Drawing.Point(905, 285);
            this.edtBgSplittingCode.Name = "edtBgSplittingCode";
            this.edtBgSplittingCode.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBgSplittingCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgSplittingCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgSplittingCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgSplittingCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgSplittingCode.Properties.Appearance.Options.UseFont = true;
            this.edtBgSplittingCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgSplittingCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgSplittingCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgSplittingCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgSplittingCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBgSplittingCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgSplittingCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtBgSplittingCode.Properties.DisplayMember = "Text";
            this.edtBgSplittingCode.Properties.NullText = "";
            this.edtBgSplittingCode.Properties.ReadOnly = true;
            this.edtBgSplittingCode.Properties.ShowFooter = false;
            this.edtBgSplittingCode.Properties.ShowHeader = false;
            this.edtBgSplittingCode.Properties.ValueMember = "Code";
            this.edtBgSplittingCode.Size = new System.Drawing.Size(22, 24);
            this.edtBgSplittingCode.TabIndex = 41;
            this.edtBgSplittingCode.TabStop = false;
            // 
            // lblBgSplittingCode
            // 
            this.lblBgSplittingCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBgSplittingCode.Location = new System.Drawing.Point(862, 285);
            this.lblBgSplittingCode.Name = "lblBgSplittingCode";
            this.lblBgSplittingCode.Size = new System.Drawing.Size(37, 24);
            this.lblBgSplittingCode.TabIndex = 40;
            this.lblBgSplittingCode.Text = "Split.";
            this.lblBgSplittingCode.UseCompatibleTextRendering = true;
            // 
            // edtVerwPeriodeBis
            // 
            this.edtVerwPeriodeBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtVerwPeriodeBis.DataMember = "VerwPeriodeBis";
            this.edtVerwPeriodeBis.DataSource = this.qryBgPosition;
            this.edtVerwPeriodeBis.EditValue = null;
            this.edtVerwPeriodeBis.Location = new System.Drawing.Point(749, 285);
            this.edtVerwPeriodeBis.Name = "edtVerwPeriodeBis";
            this.edtVerwPeriodeBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVerwPeriodeBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVerwPeriodeBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVerwPeriodeBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVerwPeriodeBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerwPeriodeBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVerwPeriodeBis.Properties.Appearance.Options.UseFont = true;
            this.edtVerwPeriodeBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtVerwPeriodeBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVerwPeriodeBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtVerwPeriodeBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVerwPeriodeBis.Properties.ShowToday = false;
            this.edtVerwPeriodeBis.Size = new System.Drawing.Size(90, 24);
            this.edtVerwPeriodeBis.TabIndex = 39;
            // 
            // lblVerwPeriodeStrich
            // 
            this.lblVerwPeriodeStrich.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVerwPeriodeStrich.Location = new System.Drawing.Point(736, 285);
            this.lblVerwPeriodeStrich.Name = "lblVerwPeriodeStrich";
            this.lblVerwPeriodeStrich.Size = new System.Drawing.Size(7, 24);
            this.lblVerwPeriodeStrich.TabIndex = 38;
            this.lblVerwPeriodeStrich.Text = "-";
            this.lblVerwPeriodeStrich.UseCompatibleTextRendering = true;
            // 
            // edtVerwPeriodeVon
            // 
            this.edtVerwPeriodeVon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtVerwPeriodeVon.DataMember = "VerwPeriodeVon";
            this.edtVerwPeriodeVon.DataSource = this.qryBgPosition;
            this.edtVerwPeriodeVon.EditValue = null;
            this.edtVerwPeriodeVon.Location = new System.Drawing.Point(640, 285);
            this.edtVerwPeriodeVon.Name = "edtVerwPeriodeVon";
            this.edtVerwPeriodeVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVerwPeriodeVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVerwPeriodeVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVerwPeriodeVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVerwPeriodeVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerwPeriodeVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVerwPeriodeVon.Properties.Appearance.Options.UseFont = true;
            this.edtVerwPeriodeVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtVerwPeriodeVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVerwPeriodeVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtVerwPeriodeVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVerwPeriodeVon.Properties.ShowToday = false;
            this.edtVerwPeriodeVon.Size = new System.Drawing.Size(90, 24);
            this.edtVerwPeriodeVon.TabIndex = 37;
            // 
            // lblVerwPeriode
            // 
            this.lblVerwPeriode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVerwPeriode.Location = new System.Drawing.Point(548, 285);
            this.lblVerwPeriode.Name = "lblVerwPeriode";
            this.lblVerwPeriode.Size = new System.Drawing.Size(86, 24);
            this.lblVerwPeriode.TabIndex = 36;
            this.lblVerwPeriode.Text = "Verwendungsp.";
            this.lblVerwPeriode.UseCompatibleTextRendering = true;
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryBgPosition;
            this.edtBemerkung.Location = new System.Drawing.Point(640, 244);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(287, 35);
            this.edtBemerkung.TabIndex = 35;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBemerkung.Location = new System.Drawing.Point(548, 244);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(86, 24);
            this.lblBemerkung.TabIndex = 34;
            this.lblBemerkung.Text = "Bemerkung";
            this.lblBemerkung.UseCompatibleTextRendering = true;
            // 
            // edtMitteilungZeile3
            // 
            this.edtMitteilungZeile3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtMitteilungZeile3.DataMember = "MitteilungZeile3";
            this.edtMitteilungZeile3.DataSource = this.qryBgPosition;
            this.edtMitteilungZeile3.Location = new System.Drawing.Point(640, 214);
            this.edtMitteilungZeile3.Name = "edtMitteilungZeile3";
            this.edtMitteilungZeile3.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMitteilungZeile3.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMitteilungZeile3.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMitteilungZeile3.Properties.Appearance.Options.UseBackColor = true;
            this.edtMitteilungZeile3.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMitteilungZeile3.Properties.Appearance.Options.UseFont = true;
            this.edtMitteilungZeile3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMitteilungZeile3.Size = new System.Drawing.Size(287, 24);
            this.edtMitteilungZeile3.TabIndex = 33;
            // 
            // edtMitteilungZeile2
            // 
            this.edtMitteilungZeile2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtMitteilungZeile2.DataMember = "MitteilungZeile2";
            this.edtMitteilungZeile2.DataSource = this.qryBgPosition;
            this.edtMitteilungZeile2.Location = new System.Drawing.Point(640, 191);
            this.edtMitteilungZeile2.Name = "edtMitteilungZeile2";
            this.edtMitteilungZeile2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMitteilungZeile2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMitteilungZeile2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMitteilungZeile2.Properties.Appearance.Options.UseBackColor = true;
            this.edtMitteilungZeile2.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMitteilungZeile2.Properties.Appearance.Options.UseFont = true;
            this.edtMitteilungZeile2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMitteilungZeile2.Size = new System.Drawing.Size(287, 24);
            this.edtMitteilungZeile2.TabIndex = 32;
            // 
            // edtMitteilungZeile1
            // 
            this.edtMitteilungZeile1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtMitteilungZeile1.DataMember = "MitteilungZeile1";
            this.edtMitteilungZeile1.DataSource = this.qryBgPosition;
            this.edtMitteilungZeile1.Location = new System.Drawing.Point(640, 168);
            this.edtMitteilungZeile1.Name = "edtMitteilungZeile1";
            this.edtMitteilungZeile1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMitteilungZeile1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMitteilungZeile1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMitteilungZeile1.Properties.Appearance.Options.UseBackColor = true;
            this.edtMitteilungZeile1.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMitteilungZeile1.Properties.Appearance.Options.UseFont = true;
            this.edtMitteilungZeile1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMitteilungZeile1.Size = new System.Drawing.Size(287, 24);
            this.edtMitteilungZeile1.TabIndex = 31;
            // 
            // lblZahlungsgrund
            // 
            this.lblZahlungsgrund.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblZahlungsgrund.Location = new System.Drawing.Point(548, 166);
            this.lblZahlungsgrund.Name = "lblZahlungsgrund";
            this.lblZahlungsgrund.Size = new System.Drawing.Size(86, 24);
            this.lblZahlungsgrund.TabIndex = 30;
            this.lblZahlungsgrund.Text = "Mitteilung";
            this.lblZahlungsgrund.UseCompatibleTextRendering = true;
            // 
            // edtReferenzNummer
            // 
            this.edtReferenzNummer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtReferenzNummer.DataMember = "ReferenzNummer";
            this.edtReferenzNummer.DataSource = this.qryBgPosition;
            this.edtReferenzNummer.Location = new System.Drawing.Point(640, 138);
            this.edtReferenzNummer.Name = "edtReferenzNummer";
            this.edtReferenzNummer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtReferenzNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtReferenzNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtReferenzNummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtReferenzNummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtReferenzNummer.Properties.Appearance.Options.UseFont = true;
            this.edtReferenzNummer.Properties.Appearance.Options.UseTextOptions = true;
            this.edtReferenzNummer.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtReferenzNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtReferenzNummer.Size = new System.Drawing.Size(287, 24);
            this.edtReferenzNummer.TabIndex = 29;
            // 
            // lblReferenzNummer
            // 
            this.lblReferenzNummer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblReferenzNummer.Location = new System.Drawing.Point(548, 138);
            this.lblReferenzNummer.Name = "lblReferenzNummer";
            this.lblReferenzNummer.Size = new System.Drawing.Size(86, 24);
            this.lblReferenzNummer.TabIndex = 28;
            this.lblReferenzNummer.Text = "Ref-Nr.:";
            this.lblReferenzNummer.UseCompatibleTextRendering = true;
            // 
            // edtZusatzInfo
            // 
            this.edtZusatzInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.edtZusatzInfo.DataMember = "ZusatzInfo";
            this.edtZusatzInfo.DataSource = this.qryBgPosition;
            this.edtZusatzInfo.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtZusatzInfo.Location = new System.Drawing.Point(640, 62);
            this.edtZusatzInfo.Name = "edtZusatzInfo";
            this.edtZusatzInfo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtZusatzInfo.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZusatzInfo.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZusatzInfo.Properties.Appearance.Options.UseBackColor = true;
            this.edtZusatzInfo.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZusatzInfo.Properties.Appearance.Options.UseFont = true;
            this.edtZusatzInfo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZusatzInfo.Properties.ReadOnly = true;
            this.edtZusatzInfo.Size = new System.Drawing.Size(287, 77);
            this.edtZusatzInfo.TabIndex = 27;
            // 
            // edtKreditor
            // 
            this.edtKreditor.DataMember = "Kreditor";
            this.edtKreditor.DataSource = this.qryBgPosition;
            this.edtKreditor.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtKreditor.Location = new System.Drawing.Point(640, 39);
            this.edtKreditor.Name = "edtKreditor";
            this.edtKreditor.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtKreditor.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKreditor.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKreditor.Properties.Appearance.Options.UseBackColor = true;
            this.edtKreditor.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKreditor.Properties.Appearance.Options.UseFont = true;
            this.edtKreditor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtKreditor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtKreditor.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKreditor.SearchStringMinLength = 3;
            this.edtKreditor.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtKreditor.Size = new System.Drawing.Size(287, 24);
            this.edtKreditor.TabIndex = 26;
            this.edtKreditor.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKreditor_UserModifiedFld);
            // 
            // lblKreditor
            // 
            this.lblKreditor.Location = new System.Drawing.Point(548, 39);
            this.lblKreditor.Name = "lblKreditor";
            this.lblKreditor.Size = new System.Drawing.Size(86, 24);
            this.lblKreditor.TabIndex = 25;
            this.lblKreditor.Text = "Kreditor";
            this.lblKreditor.UseCompatibleTextRendering = true;
            // 
            // edtBelegDatum
            // 
            this.edtBelegDatum.DataMember = "BelegDatum";
            this.edtBelegDatum.DataSource = this.qryBgPosition;
            this.edtBelegDatum.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBelegDatum.EditValue = null;
            this.edtBelegDatum.Location = new System.Drawing.Point(837, 9);
            this.edtBelegDatum.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.edtBelegDatum.Name = "edtBelegDatum";
            this.edtBelegDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBelegDatum.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBelegDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBelegDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBelegDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtBelegDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBelegDatum.Properties.Appearance.Options.UseFont = true;
            this.edtBelegDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtBelegDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtBelegDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtBelegDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBelegDatum.Properties.ReadOnly = true;
            this.edtBelegDatum.Properties.ShowToday = false;
            this.edtBelegDatum.Size = new System.Drawing.Size(90, 24);
            this.edtBelegDatum.TabIndex = 24;
            // 
            // lblBelegDatum
            // 
            this.lblBelegDatum.Location = new System.Drawing.Point(758, 9);
            this.lblBelegDatum.Name = "lblBelegDatum";
            this.lblBelegDatum.Size = new System.Drawing.Size(73, 24);
            this.lblBelegDatum.TabIndex = 23;
            this.lblBelegDatum.Text = "Beleg Datum";
            this.lblBelegDatum.UseCompatibleTextRendering = true;
            // 
            // edtValutaDatum
            // 
            this.edtValutaDatum.DataMember = "ValutaDatum";
            this.edtValutaDatum.DataSource = this.qryBgPosition;
            this.edtValutaDatum.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtValutaDatum.EditValue = null;
            this.edtValutaDatum.Location = new System.Drawing.Point(640, 9);
            this.edtValutaDatum.Name = "edtValutaDatum";
            this.edtValutaDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtValutaDatum.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtValutaDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtValutaDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtValutaDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtValutaDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtValutaDatum.Properties.Appearance.Options.UseFont = true;
            this.edtValutaDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtValutaDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtValutaDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtValutaDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtValutaDatum.Properties.ShowToday = false;
            this.edtValutaDatum.Size = new System.Drawing.Size(90, 24);
            this.edtValutaDatum.TabIndex = 22;
            // 
            // lblValutaDatum
            // 
            this.lblValutaDatum.Location = new System.Drawing.Point(548, 9);
            this.lblValutaDatum.Name = "lblValutaDatum";
            this.lblValutaDatum.Size = new System.Drawing.Size(86, 24);
            this.lblValutaDatum.TabIndex = 21;
            this.lblValutaDatum.Text = "Valuta";
            this.lblValutaDatum.UseCompatibleTextRendering = true;
            // 
            // btnMonatsbudget
            // 
            this.btnMonatsbudget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonatsbudget.Location = new System.Drawing.Point(44, 291);
            this.btnMonatsbudget.Name = "btnMonatsbudget";
            this.btnMonatsbudget.Size = new System.Drawing.Size(90, 24);
            this.btnMonatsbudget.TabIndex = 49;
            this.btnMonatsbudget.Text = "> Budget";
            this.btnMonatsbudget.UseCompatibleTextRendering = true;
            this.btnMonatsbudget.UseVisualStyleBackColor = false;
            this.btnMonatsbudget.Click += new System.EventHandler(this.btnMonatsbudget_Click);
            // 
            // grdBgBudget
            // 
            this.grdBgBudget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdBgBudget.DataSource = this.qryBgBudget;
            // 
            // 
            // 
            this.grdBgBudget.EmbeddedNavigator.Name = "gridPeriode.EmbeddedNavigator";
            this.grdBgBudget.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBgBudget.Location = new System.Drawing.Point(140, 264);
            this.grdBgBudget.MainView = this.grvBgBudget;
            this.grdBgBudget.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.grdBgBudget.Name = "grdBgBudget";
            this.grdBgBudget.Size = new System.Drawing.Size(387, 121);
            this.grdBgBudget.TabIndex = 20;
            this.grdBgBudget.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBgBudget});
            // 
            // qryBgBudget
            // 
            this.qryBgBudget.BatchUpdate = true;
            this.qryBgBudget.HostControl = this;
            this.qryBgBudget.SelectStatement = resources.GetString("qryBgBudget.SelectStatement");
            this.qryBgBudget.PositionChanged += new System.EventHandler(this.qryBgBudget_PositionChanged);
            // 
            // grvBgBudget
            // 
            this.grvBgBudget.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBgBudget.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgBudget.Appearance.Empty.Options.UseBackColor = true;
            this.grvBgBudget.Appearance.Empty.Options.UseFont = true;
            this.grvBgBudget.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvBgBudget.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgBudget.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvBgBudget.Appearance.EvenRow.Options.UseFont = true;
            this.grvBgBudget.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBgBudget.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgBudget.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBgBudget.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBgBudget.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBgBudget.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBgBudget.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBgBudget.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgBudget.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBgBudget.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBgBudget.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBgBudget.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBgBudget.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgBudget.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBgBudget.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvBgBudget.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvBgBudget.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgBudget.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBgBudget.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgBudget.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgBudget.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBgBudget.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBgBudget.Appearance.GroupRow.Options.UseFont = true;
            this.grvBgBudget.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBgBudget.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBgBudget.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBgBudget.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgBudget.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBgBudget.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBgBudget.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBgBudget.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBgBudget.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgBudget.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBgBudget.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBgBudget.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBgBudget.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBgBudget.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBgBudget.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBgBudget.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgBudget.Appearance.OddRow.Options.UseFont = true;
            this.grvBgBudget.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBgBudget.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgBudget.Appearance.Row.Options.UseBackColor = true;
            this.grvBgBudget.Appearance.Row.Options.UseFont = true;
            this.grvBgBudget.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvBgBudget.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgBudget.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvBgBudget.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvBgBudget.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBgBudget.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvBgBudget.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBgBudget.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBgBudget.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBgBudget.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMonat,
            this.colJahr,
            this.colStatus,
            this.colAnzEZ,
            this.colAnzZL,
            this.colSAbgeschlossenAm});
            this.grvBgBudget.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBgBudget.GridControl = this.grdBgBudget;
            this.grvBgBudget.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvBgBudget.Name = "grvBgBudget";
            this.grvBgBudget.OptionsBehavior.Editable = false;
            this.grvBgBudget.OptionsCustomization.AllowFilter = false;
            this.grvBgBudget.OptionsFilter.AllowFilterEditor = false;
            this.grvBgBudget.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBgBudget.OptionsMenu.EnableColumnMenu = false;
            this.grvBgBudget.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBgBudget.OptionsNavigation.UseTabKey = false;
            this.grvBgBudget.OptionsView.ColumnAutoWidth = false;
            this.grvBgBudget.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBgBudget.OptionsView.ShowGroupPanel = false;
            this.grvBgBudget.OptionsView.ShowIndicator = false;
            // 
            // colMonat
            // 
            this.colMonat.Caption = "Monat";
            this.colMonat.FieldName = "MonatText";
            this.colMonat.Name = "colMonat";
            this.colMonat.Visible = true;
            this.colMonat.VisibleIndex = 0;
            this.colMonat.Width = 95;
            // 
            // colJahr
            // 
            this.colJahr.Caption = "Jahr";
            this.colJahr.FieldName = "Jahr";
            this.colJahr.Name = "colJahr";
            this.colJahr.Visible = true;
            this.colJahr.VisibleIndex = 1;
            this.colJahr.Width = 46;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Stat.";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 2;
            this.colStatus.Width = 35;
            // 
            // colAnzEZ
            // 
            this.colAnzEZ.Caption = "EZ";
            this.colAnzEZ.FieldName = "EZ";
            this.colAnzEZ.Name = "colAnzEZ";
            this.colAnzEZ.Visible = true;
            this.colAnzEZ.VisibleIndex = 3;
            this.colAnzEZ.Width = 31;
            // 
            // colAnzZL
            // 
            this.colAnzZL.Caption = "ZL";
            this.colAnzZL.FieldName = "ZL";
            this.colAnzZL.Name = "colAnzZL";
            this.colAnzZL.Visible = true;
            this.colAnzZL.VisibleIndex = 4;
            this.colAnzZL.Width = 31;
            // 
            // colSAbgeschlossenAm
            // 
            this.colSAbgeschlossenAm.Caption = "S abgeschlossen am";
            this.colSAbgeschlossenAm.FieldName = "DatumBis";
            this.colSAbgeschlossenAm.Name = "colSAbgeschlossenAm";
            this.colSAbgeschlossenAm.Visible = true;
            this.colSAbgeschlossenAm.VisibleIndex = 5;
            this.colSAbgeschlossenAm.Width = 125;
            // 
            // lblMonatsbudget
            // 
            this.lblMonatsbudget.Location = new System.Drawing.Point(44, 264);
            this.lblMonatsbudget.Name = "lblMonatsbudget";
            this.lblMonatsbudget.Size = new System.Drawing.Size(90, 24);
            this.lblMonatsbudget.TabIndex = 19;
            this.lblMonatsbudget.Text = "Monatsbudgets";
            this.lblMonatsbudget.UseCompatibleTextRendering = true;
            // 
            // edtAuszahlungsart
            // 
            this.edtAuszahlungsart.AllowNull = false;
            this.edtAuszahlungsart.DataMember = "KbAuszahlungsArtCode";
            this.edtAuszahlungsart.DataSource = this.qryBgPosition;
            this.edtAuszahlungsart.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtAuszahlungsart.Location = new System.Drawing.Point(140, 234);
            this.edtAuszahlungsart.LOVName = "KbAuszahlungsArt";
            this.edtAuszahlungsart.Name = "edtAuszahlungsart";
            this.edtAuszahlungsart.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtAuszahlungsart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAuszahlungsart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuszahlungsart.Properties.Appearance.Options.UseBackColor = true;
            this.edtAuszahlungsart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAuszahlungsart.Properties.Appearance.Options.UseFont = true;
            this.edtAuszahlungsart.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAuszahlungsart.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuszahlungsart.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAuszahlungsart.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAuszahlungsart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtAuszahlungsart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtAuszahlungsart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAuszahlungsart.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Typ", "Typ", 100),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("KOA", "KoA", 50),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "Text", 300),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Saldo", "Saldo", 50, DevExpress.Utils.FormatType.Numeric, "n2", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtAuszahlungsart.Properties.DisplayMember = "Text";
            this.edtAuszahlungsart.Properties.NullText = "";
            this.edtAuszahlungsart.Properties.ShowFooter = false;
            this.edtAuszahlungsart.Properties.ShowHeader = false;
            this.edtAuszahlungsart.Properties.ValueMember = "Code";
            this.edtAuszahlungsart.Size = new System.Drawing.Size(387, 24);
            this.edtAuszahlungsart.TabIndex = 18;
            this.edtAuszahlungsart.EditValueChanged += new System.EventHandler(this.edtAuszahlungsart_EditValueChanged);
            // 
            // lblAuszahlungsart
            // 
            this.lblAuszahlungsart.Location = new System.Drawing.Point(44, 234);
            this.lblAuszahlungsart.Name = "lblAuszahlungsart";
            this.lblAuszahlungsart.Size = new System.Drawing.Size(90, 24);
            this.lblAuszahlungsart.TabIndex = 17;
            this.lblAuszahlungsart.Text = "Auszahlungsart";
            this.lblAuszahlungsart.UseCompatibleTextRendering = true;
            // 
            // edtBgSpezkontoID
            // 
            this.edtBgSpezkontoID.DataMember = "BgSpezkontoID";
            this.edtBgSpezkontoID.DataSource = this.qryBgPosition;
            this.edtBgSpezkontoID.Location = new System.Drawing.Point(140, 204);
            this.edtBgSpezkontoID.Name = "edtBgSpezkontoID";
            this.edtBgSpezkontoID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBgSpezkontoID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgSpezkontoID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgSpezkontoID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgSpezkontoID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgSpezkontoID.Properties.Appearance.Options.UseFont = true;
            this.edtBgSpezkontoID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgSpezkontoID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgSpezkontoID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgSpezkontoID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgSpezkontoID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtBgSpezkontoID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtBgSpezkontoID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgSpezkontoID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Typ", "Typ", 100),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("KOA_S", "KoA S", 50),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("KOA_H", "KoA H", 50),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "Text", 300),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Saldo", "Saldo", 50, DevExpress.Utils.FormatType.Numeric, "n2", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtBgSpezkontoID.Properties.DisplayMember = "Text";
            this.edtBgSpezkontoID.Properties.NullText = "";
            this.edtBgSpezkontoID.Properties.PopupWidth = 600;
            this.edtBgSpezkontoID.Properties.ShowFooter = false;
            this.edtBgSpezkontoID.Properties.ShowHeader = false;
            this.edtBgSpezkontoID.Properties.ValueMember = "Code";
            this.edtBgSpezkontoID.Size = new System.Drawing.Size(387, 24);
            this.edtBgSpezkontoID.TabIndex = 16;
            this.edtBgSpezkontoID.EditValueChanged += new System.EventHandler(this.edtBgSpezkontoID_EditValueChanged);
            this.edtBgSpezkontoID.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.edtBgSpezkontoID_EditValueChanging);
            // 
            // lblBgSpezkontoID
            // 
            this.lblBgSpezkontoID.Location = new System.Drawing.Point(44, 204);
            this.lblBgSpezkontoID.Name = "lblBgSpezkontoID";
            this.lblBgSpezkontoID.Size = new System.Drawing.Size(90, 24);
            this.lblBgSpezkontoID.TabIndex = 15;
            this.lblBgSpezkontoID.Text = "Spezialkonto";
            this.lblBgSpezkontoID.UseCompatibleTextRendering = true;
            // 
            // edtBaPersonID
            // 
            this.edtBaPersonID.DataMember = "BaPersonID";
            this.edtBaPersonID.DataSource = this.qryBgPosition;
            this.edtBaPersonID.Location = new System.Drawing.Point(140, 174);
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
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NameVorname")});
            this.edtBaPersonID.Properties.DisplayMember = "NameVorname";
            this.edtBaPersonID.Properties.NullText = "";
            this.edtBaPersonID.Properties.ShowFooter = false;
            this.edtBaPersonID.Properties.ShowHeader = false;
            this.edtBaPersonID.Properties.ValueMember = "BaPersonID";
            this.edtBaPersonID.Size = new System.Drawing.Size(387, 24);
            this.edtBaPersonID.TabIndex = 14;
            // 
            // lblBaPersonID
            // 
            this.lblBaPersonID.Location = new System.Drawing.Point(44, 174);
            this.lblBaPersonID.Name = "lblBaPersonID";
            this.lblBaPersonID.Size = new System.Drawing.Size(90, 24);
            this.lblBaPersonID.TabIndex = 13;
            this.lblBaPersonID.Text = "Betrifft Person";
            this.lblBaPersonID.UseCompatibleTextRendering = true;
            // 
            // edtBetrag
            // 
            this.edtBetrag.DataMember = "BetragSpezial";
            this.edtBetrag.DataSource = this.qryBgPosition;
            this.edtBetrag.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtBetrag.Location = new System.Drawing.Point(140, 144);
            this.edtBetrag.Name = "edtBetrag";
            this.edtBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBetrag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetrag.Properties.DisplayFormat.FormatString = "n2";
            this.edtBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Properties.EditFormat.FormatString = "n2";
            this.edtBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Size = new System.Drawing.Size(100, 24);
            this.edtBetrag.TabIndex = 12;
            // 
            // lblBetrag
            // 
            this.lblBetrag.Location = new System.Drawing.Point(44, 144);
            this.lblBetrag.Name = "lblBetrag";
            this.lblBetrag.Size = new System.Drawing.Size(90, 24);
            this.lblBetrag.TabIndex = 11;
            this.lblBetrag.Text = "Betrag CHF";
            this.lblBetrag.UseCompatibleTextRendering = true;
            // 
            // edtBuchungstext
            // 
            this.edtBuchungstext.DataMember = "Buchungstext";
            this.edtBuchungstext.DataSource = this.qryBgPosition;
            this.edtBuchungstext.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtBuchungstext.Location = new System.Drawing.Point(140, 114);
            this.edtBuchungstext.Name = "edtBuchungstext";
            this.edtBuchungstext.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtBuchungstext.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchungstext.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchungstext.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchungstext.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchungstext.Properties.Appearance.Options.UseFont = true;
            this.edtBuchungstext.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBuchungstext.Size = new System.Drawing.Size(387, 24);
            this.edtBuchungstext.TabIndex = 10;
            this.edtBuchungstext.Enter += new System.EventHandler(this.edtBuchungstext_Enter);
            // 
            // lblBuchungstext
            // 
            this.lblBuchungstext.Location = new System.Drawing.Point(44, 114);
            this.lblBuchungstext.Name = "lblBuchungstext";
            this.lblBuchungstext.Size = new System.Drawing.Size(90, 24);
            this.lblBuchungstext.TabIndex = 9;
            this.lblBuchungstext.Text = "Buchungstext";
            this.lblBuchungstext.UseCompatibleTextRendering = true;
            // 
            // edtKostenart
            // 
            this.edtKostenart.DataMember = "Kostenart";
            this.edtKostenart.DataSource = this.qryBgPosition;
            this.edtKostenart.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtKostenart.Location = new System.Drawing.Point(140, 92);
            this.edtKostenart.Name = "edtKostenart";
            this.edtKostenart.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtKostenart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKostenart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostenart.Properties.Appearance.Options.UseBackColor = true;
            this.edtKostenart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKostenart.Properties.Appearance.Options.UseFont = true;
            this.edtKostenart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtKostenart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtKostenart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKostenart.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtKostenart.Size = new System.Drawing.Size(387, 24);
            this.edtKostenart.TabIndex = 8;
            this.edtKostenart.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKostenart_UserModifiedFld);
            // 
            // lblKostenart
            // 
            this.lblKostenart.Location = new System.Drawing.Point(44, 92);
            this.lblKostenart.Name = "lblKostenart";
            this.lblKostenart.Size = new System.Drawing.Size(90, 24);
            this.lblKostenart.TabIndex = 7;
            this.lblKostenart.Text = "KoA/Positionsart";
            this.lblKostenart.UseCompatibleTextRendering = true;
            // 
            // edtAdresse
            // 
            this.edtAdresse.DataMember = "Adresse";
            this.edtAdresse.DataSource = this.qryBgPosition;
            this.edtAdresse.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAdresse.Location = new System.Drawing.Point(140, 62);
            this.edtAdresse.Name = "edtAdresse";
            this.edtAdresse.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAdresse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdresse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdresse.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdresse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdresse.Properties.Appearance.Options.UseFont = true;
            this.edtAdresse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdresse.Properties.Name = "editPlzOrt.Properties";
            this.edtAdresse.Properties.ReadOnly = true;
            this.edtAdresse.Size = new System.Drawing.Size(387, 24);
            this.edtAdresse.TabIndex = 6;
            // 
            // lblAdresse
            // 
            this.lblAdresse.Location = new System.Drawing.Point(44, 62);
            this.lblAdresse.Name = "lblAdresse";
            this.lblAdresse.Size = new System.Drawing.Size(90, 24);
            this.lblAdresse.TabIndex = 5;
            this.lblAdresse.Text = "Adresse";
            this.lblAdresse.UseCompatibleTextRendering = true;
            // 
            // edtKlientID
            // 
            this.edtKlientID.DataMember = "KlientID";
            this.edtKlientID.DataSource = this.qryBgPosition;
            this.edtKlientID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKlientID.Location = new System.Drawing.Point(461, 39);
            this.edtKlientID.Name = "edtKlientID";
            this.edtKlientID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKlientID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKlientID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKlientID.Properties.Appearance.Options.UseBackColor = true;
            this.edtKlientID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKlientID.Properties.Appearance.Options.UseFont = true;
            this.edtKlientID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKlientID.Properties.Name = "editMandantNr.Properties";
            this.edtKlientID.Properties.ReadOnly = true;
            this.edtKlientID.Size = new System.Drawing.Size(66, 24);
            this.edtKlientID.TabIndex = 4;
            // 
            // edtKlient
            // 
            this.edtKlient.DataMember = "Klient";
            this.edtKlient.DataSource = this.qryBgPosition;
            this.edtKlient.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtKlient.Location = new System.Drawing.Point(140, 39);
            this.edtKlient.LookupSQL = "select null";
            this.edtKlient.Name = "edtKlient";
            this.edtKlient.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtKlient.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKlient.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKlient.Properties.Appearance.Options.UseBackColor = true;
            this.edtKlient.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKlient.Properties.Appearance.Options.UseFont = true;
            this.edtKlient.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtKlient.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.edtKlient.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKlient.Properties.Name = "editMandant.Properties";
            this.edtKlient.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtKlient.Size = new System.Drawing.Size(322, 24);
            this.edtKlient.TabIndex = 3;
            this.edtKlient.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKlient_UserModifiedFld);
            // 
            // lblKlient
            // 
            this.lblKlient.Location = new System.Drawing.Point(44, 39);
            this.lblKlient.Name = "lblKlient";
            this.lblKlient.Size = new System.Drawing.Size(90, 24);
            this.lblKlient.TabIndex = 2;
            this.lblKlient.Text = "Klient/in";
            this.lblKlient.UseCompatibleTextRendering = true;
            // 
            // edtKategorie
            // 
            this.edtKategorie.DataMember = "BgKategorieCode";
            this.edtKategorie.DataSource = this.qryBgPosition;
            this.edtKategorie.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKategorie.Location = new System.Drawing.Point(140, 9);
            this.edtKategorie.LOVName = "BgKategorie";
            this.edtKategorie.Name = "edtKategorie";
            this.edtKategorie.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKategorie.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKategorie.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKategorie.Properties.Appearance.Options.UseBackColor = true;
            this.edtKategorie.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKategorie.Properties.Appearance.Options.UseFont = true;
            this.edtKategorie.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKategorie.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKategorie.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKategorie.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKategorie.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.edtKategorie.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.edtKategorie.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKategorie.Properties.NullText = "";
            this.edtKategorie.Properties.ReadOnly = true;
            this.edtKategorie.Properties.ShowFooter = false;
            this.edtKategorie.Properties.ShowHeader = false;
            this.edtKategorie.Size = new System.Drawing.Size(387, 24);
            this.edtKategorie.TabIndex = 1;
            // 
            // lblKategorie
            // 
            this.lblKategorie.Location = new System.Drawing.Point(44, 9);
            this.lblKategorie.Name = "lblKategorie";
            this.lblKategorie.Size = new System.Drawing.Size(90, 24);
            this.lblKategorie.TabIndex = 0;
            this.lblKategorie.Text = "Kategorie";
            this.lblKategorie.UseCompatibleTextRendering = true;
            // 
            // splitter
            // 
            this.splitter.AnimationDelay = 20;
            this.splitter.AnimationStep = 20;
            this.splitter.BorderStyle3D = System.Windows.Forms.Border3DStyle.Etched;
            this.splitter.ControlToHide = this.tabBgPosition;
            this.splitter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter.ExpandParentForm = false;
            this.splitter.Location = new System.Drawing.Point(0, 152);
            this.splitter.MinExtra = 100;
            this.splitter.MinSize = 100;
            this.splitter.Name = "splitter";
            this.splitter.TabIndex = 1;
            this.splitter.TabStop = false;
            this.splitter.UseAnimations = false;
            this.splitter.VisualStyle = KiSS4.Gui.VisualStyles.Mozilla;
            // 
            // CtlWhAuszahlungen
            // 
            this.ActiveSQLQuery = this.qryBgPosition;
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.tabBgPosition);
            this.Name = "CtlWhAuszahlungen";
            this.Size = new System.Drawing.Size(1002, 589);
            this.Load += new System.EventHandler(this.CtlWhAuszahlungen_Load);
            this.Controls.SetChildIndex(this.tabBgPosition, 0);
            this.Controls.SetChildIndex(this.splitter, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEinzelzahlung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEinzelzahlung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repStatusImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheErfassungMA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheErfassungVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheErfassung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheErfassungBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMutation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMutationMA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheValutaVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMutationVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMutationBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMitarbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheValutaVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheValutaBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheValutaBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBelegID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFallNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBelegID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheFallNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheSelectTop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheSelectTop)).EndInit();
            this.tabBgPosition.ResumeLayout(false);
            this.tpgBewilligung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBgBewilligung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgBewilligung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgBewilligung)).EndInit();
            this.panBewilligungDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblBewilligungAbsender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBewilligungBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBewilligungAbsender.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBewilligungBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBewilligungEmpfaenger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBewilligungEmpfaenger.Properties)).EndInit();
            this.tpgDokumente.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBgDokumente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgDokumente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgDokumente)).EndInit();
            this.panDokumenteDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblDokumentTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDocument.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentTyp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichwort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichwort.Properties)).EndInit();
            this.tpgEinzelzahlung.ResumeLayout(false);
            this.panSetStatus.ResumeLayout(false);
            this.panNewItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPositionID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPositionID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSplittingCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSplittingCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgSplittingCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwPeriodeBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwPeriodeStrich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwPeriodeVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwPeriode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilungZeile3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilungZeile2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilungZeile1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungsgrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtReferenzNummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReferenzNummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValutaDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValutaDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBgBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMonatsbudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuszahlungsart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuszahlungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuszahlungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSpezkontoID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSpezkontoID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgSpezkontoID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlientID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKategorie.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKategorie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKategorie)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissButton btnEinzelzahlung;
        private KiSS4.Gui.KissButton btnFreigeben;
        private KiSS4.Gui.KissButton btnGraustellen;
        private KiSS4.Gui.KissButton btnMonatsbudget;
        private KiSS4.Gui.KissButton btnPositionBewilligung;
        private KiSS4.Gui.KissButton btnWeitereKOA;
        private KiSS4.Gui.KissButton btnZusatzleistung;
        private DevExpress.XtraGrid.Columns.GridColumn colAbsender;
        private DevExpress.XtraGrid.Columns.GridColumn colAnzEZ;
        private DevExpress.XtraGrid.Columns.GridColumn colAnzZL;
        private DevExpress.XtraGrid.Columns.GridColumn colBbwGrouper;
        private DevExpress.XtraGrid.Columns.GridColumn colBemerkungen;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBgBewilligungCode;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungstext;
        private DevExpress.XtraGrid.Columns.GridColumn colDateCreation;
        private DevExpress.XtraGrid.Columns.GridColumn colDateLastSave;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colDoc;
        private DevExpress.XtraGrid.Columns.GridColumn colDocTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpfaenger;
        private DevExpress.XtraGrid.Columns.GridColumn colHauptPos;
        private DevExpress.XtraGrid.Columns.GridColumn colJahr;
        private DevExpress.XtraGrid.Columns.GridColumn colKOA;
        private DevExpress.XtraGrid.Columns.GridColumn colKat;
        private DevExpress.XtraGrid.Columns.GridColumn colKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colKreditor;
        private DevExpress.XtraGrid.Columns.GridColumn colMA;
        private DevExpress.XtraGrid.Columns.GridColumn colMonat;
        private DevExpress.XtraGrid.Columns.GridColumn colPosStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colSelektion;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colStichwort;
        private DevExpress.XtraGrid.Columns.GridColumn colValuta;
        private System.ComponentModel.IContainer components;
        private KiSS4.Common.CtlErfassungMutation ctlErfassungMutation;
        private KiSS4.Gui.KissTextEdit edtAdresse;
        private KiSS4.Gui.KissLookUpEdit edtAuszahlungsart;
        private KiSS4.Gui.KissLookUpEdit edtBaPersonID;
        private KiSS4.Gui.KissDateEdit edtBelegDatum;
        private KiSS4.Gui.KissCalcEdit edtBelegNr;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private KiSS4.Gui.KissCalcEdit edtBetrag;
        private KiSS4.Gui.KissTextEdit edtBewilligungAbsender;
        private KiSS4.Gui.KissMemoEdit edtBewilligungBemerkung;
        private KiSS4.Gui.KissTextEdit edtBewilligungEmpfaenger;
        private KiSS4.Gui.KissLookUpEdit edtBgSpezkontoID;
        private KiSS4.Gui.KissLookUpEdit edtBgSplittingCode;
        private KiSS4.Gui.KissTextEdit edtBuchungstext;
        private KiSS4.Dokument.XDokument edtDocument;
        private KiSS4.Gui.KissLookUpEdit edtDokumentTyp;
        private KiSS4.Gui.KissLookUpEdit edtKategorie;
        private KiSS4.Gui.KissButtonEdit edtKlient;
        private KiSS4.Gui.KissTextEdit edtKlientID;
        private KiSS4.Gui.KissButtonEdit edtKostenart;
        private KiSS4.Gui.KissButtonEdit edtKreditor;
        private KiSS4.Gui.KissTextEdit edtMitteilungZeile1;
        private KiSS4.Gui.KissTextEdit edtMitteilungZeile2;
        private KiSS4.Gui.KissTextEdit edtMitteilungZeile3;
        private KiSS4.Gui.KissCalcEdit edtPositionID;
        private KiSS4.Common.KissReferenzNrEdit edtReferenzNummer;
        private KiSS4.Gui.KissTextEdit edtStichwort;
        private KiSS4.Gui.KissCalcEdit edtSucheBelegID;
        private KiSS4.Gui.KissDateEdit edtSucheErfassungBis;
        private KiSS4.Gui.KissButtonEdit edtSucheErfassungMA;
        private KiSS4.Gui.KissDateEdit edtSucheErfassungVon;
        private KiSS4.Gui.KissCalcEdit edtSucheFallNr;
        private KiSS4.Gui.KissDateEdit edtSucheMutationBis;
        private KiSS4.Gui.KissButtonEdit edtSucheMutationMA;
        private KiSS4.Gui.KissDateEdit edtSucheMutationVon;
        private KiSS4.Gui.KissCalcEdit edtSucheSelectTop;
        private KiSS4.Gui.KissImageComboBoxEdit edtSucheStatus;
        private KiSS4.Gui.KissDateEdit edtSucheValutaBis;
        private KiSS4.Gui.KissDateEdit edtSucheValutaVon;
        private KiSS4.Gui.KissDateEdit edtValutaDatum;
        private KiSS4.Gui.KissDateEdit edtVerwPeriodeBis;
        private KiSS4.Gui.KissDateEdit edtVerwPeriodeVon;
        private KiSS4.Gui.KissMemoEdit edtZusatzInfo;
        private KiSS4.Gui.KissGrid grdBgBewilligung;
        private KiSS4.Gui.KissGrid grdBgBudget;
        private KiSS4.Gui.KissGrid grdBgDokumente;
        private KiSS4.Gui.KissGrid grdEinzelzahlung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBgBewilligung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBgBudget;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBgDokumente;
        private DevExpress.XtraGrid.Views.Grid.GridView grvEinzelzahlung;
        private KiSS4.Gui.KissLabel lblAdresse;
        private KiSS4.Gui.KissLabel lblAuszahlungsart;
        private KiSS4.Gui.KissLabel lblBaPersonID;
        private KiSS4.Gui.KissLabel lblBelegDatum;
        private KiSS4.Gui.KissLabel lblBelegNr;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblBetrag;
        private KiSS4.Gui.KissLabel lblBewilligungAbsender;
        private KiSS4.Gui.KissLabel lblBewilligungBemerkung;
        private KiSS4.Gui.KissLabel lblBewilligungEmpfaenger;
        private KiSS4.Gui.KissLabel lblBgSpezkontoID;
        private KiSS4.Gui.KissLabel lblBgSplittingCode;
        private KiSS4.Gui.KissLabel lblBuchungstext;
        private KiSS4.Gui.KissLabel lblDokument;
        private KiSS4.Gui.KissLabel lblDokumentTyp;
        private KiSS4.Gui.KissLabel lblKategorie;
        private KiSS4.Gui.KissLabel lblKlient;
        private KiSS4.Gui.KissLabel lblKostenart;
        private KiSS4.Gui.KissLabel lblKreditor;
        private KiSS4.Gui.KissLabel lblMonatsbudget;
        private KiSS4.Gui.KissLabel lblPositionID;
        private KiSS4.Gui.KissLabel lblReferenzNummer;
        private KiSS4.Gui.KissLabel lblStichwort;
        private KiSS4.Gui.KissLabel lblSucheBelegID;
        private KiSS4.Gui.KissLabel lblSucheDatumBis;
        private KiSS4.Gui.KissLabel lblSucheDatumVon;
        private KiSS4.Gui.KissLabel lblSucheErfassung;
        private KiSS4.Gui.KissLabel lblSucheFallNr;
        private KiSS4.Gui.KissLabel lblSucheMitarbeiter;
        private KiSS4.Gui.KissLabel lblSucheMutation;
        private KiSS4.Gui.KissLabel lblSucheSelectTop;
        private KiSS4.Gui.KissLabel lblSucheStatus;
        private KiSS4.Gui.KissLabel lblSucheValutaBis;
        private KiSS4.Gui.KissLabel lblSucheValutaVon;
        private KiSS4.Gui.KissLabel lblValutaDatum;
        private KiSS4.Gui.KissLabel lblVerwPeriode;
        private KiSS4.Gui.KissLabel lblVerwPeriodeStrich;
        private KiSS4.Gui.KissLabel lblZahlungsgrund;
        private System.Windows.Forms.Panel panBewilligungDetails;
        private System.Windows.Forms.Panel panDokumenteDetails;
        private System.Windows.Forms.Panel panNewItems;
        private System.Windows.Forms.Panel panNewItemsBorder;
        private System.Windows.Forms.Panel panSetStatus;
        private System.Windows.Forms.Panel panSetStatusBorder;
        private KiSS4.DB.SqlQuery qryBgBewilligung;
        private KiSS4.DB.SqlQuery qryBgBudget;
        private KiSS4.DB.SqlQuery qryBgDokumente;
        private KiSS4.DB.SqlQuery qryBgPosition;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repStatusImg;
        private KiSS4.Gui.KissSplitterCollapsible splitter;
        private KiSS4.Gui.KissTabControlEx tabBgPosition;
        private SharpLibrary.WinControls.TabPageEx tpgBewilligung;
        private SharpLibrary.WinControls.TabPageEx tpgDokumente;
        private SharpLibrary.WinControls.TabPageEx tpgEinzelzahlung;
        private System.Windows.Forms.ToolTip ttpControls;
        private DevExpress.XtraGrid.Columns.GridColumn colSAbgeschlossenAm;
    }
}
