using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS4.Sozialhilfe.ZH
{
    partial class FrmWhSollstellungen
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject18 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject17 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject16 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject15 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject14 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWhSollstellungen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdSollstellung = new KiSS4.Gui.KissGrid();
            this.qryBgPosition = new KiSS4.DB.SqlQuery(this.components);
            this.grvSollstellung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colValuta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKOA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDebitor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPSCDBelegNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colSelektion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.edtSucheErfassungMA = new KiSS4.Gui.KissButtonEdit();
            this.edtSucheErfassungVon = new KiSS4.Gui.KissDateEdit();
            this.lblSucheErfassung = new KiSS4.Gui.KissLabel();
            this.edtSucheErfassungBis = new KiSS4.Gui.KissDateEdit();
            this.edtSucheFallNr = new KiSS4.Gui.KissCalcEdit();
            this.lblSucheValutaVon = new KiSS4.Gui.KissLabel();
            this.edtSucheFaelligAmVon = new KiSS4.Gui.KissDateEdit();
            this.edtSucheFaelligAmBis = new KiSS4.Gui.KissDateEdit();
            this.lblSucheMitarbeiter = new KiSS4.Gui.KissLabel();
            this.edtSucheStatus = new KiSS4.Gui.KissImageComboBoxEdit();
            this.lblSucheValutaBis = new KiSS4.Gui.KissLabel();
            this.edtInklNichtAbgetreteneEinnahmen = new KiSS4.Gui.KissCheckEdit();
            this.edtSucheName = new KiSS4.Gui.KissTextEdit();
            this.edtSucheVorname = new KiSS4.Gui.KissTextEdit();
            this.lblSucheStatus = new KiSS4.Gui.KissLabel();
            this.edtSucheZIPNr = new KiSS4.Gui.KissCalcEdit();
            this.edtSuchePNr = new KiSS4.Gui.KissCalcEdit();
            this.lblSucheDatumVon = new KiSS4.Gui.KissLabel();
            this.edtSucheAHVNr = new KiSS4.Gui.KissTextEdit();
            this.lblSucheDatumBis = new KiSS4.Gui.KissLabel();
            this.edtSucheKlient = new KiSS4.Gui.KissButtonEdit();
            this.edtKeepValues = new KiSS4.Gui.KissCheckEdit();
            this.edtSucheSelectTop = new KiSS4.Gui.KissCalcEdit();
            this.edtFilter = new KiSS4.Gui.KissTextEdit();
            this.grdVerfuegbar = new KiSS4.Gui.KissGrid();
            this.qryVerfuegbar = new KiSS4.DB.SqlQuery(this.components);
            this.grvVerfugbar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.btnAdd = new KiSS4.Gui.KissButton();
            this.btnRemove = new KiSS4.Gui.KissButton();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.btnAddAll = new KiSS4.Gui.KissButton();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.btnRemoveAll = new KiSS4.Gui.KissButton();
            this.grdZugeteilt = new KiSS4.Gui.KissGrid();
            this.qryZugeteilt = new KiSS4.DB.SqlQuery(this.components);
            this.grvZugeteilt = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.edtFilter2 = new KiSS4.Gui.KissTextEdit();
            this.kissLabel6 = new KiSS4.Gui.KissLabel();
            this.kissLabel9 = new KiSS4.Gui.KissLabel();
            this.kissLabel10 = new KiSS4.Gui.KissLabel();
            this.lblLeistungsart = new KiSS4.Gui.KissLabel();
            this.kissLabel13 = new KiSS4.Gui.KissLabel();
            this.kissLabel12 = new KiSS4.Gui.KissLabel();
            this.kissLabel11 = new KiSS4.Gui.KissLabel();
            this.edtLAList = new KiSS4.Gui.KissTextEdit();
            this.lblWhSucheKlientX = new KiSS4.Gui.KissLabel();
            this.btnTransfer = new KiSS4.Gui.KissButton();
            this.btnKeine = new KiSS4.Gui.KissButton();
            this.btnAlle = new KiSS4.Gui.KissButton();
            this.tabBgPosition = new KiSS4.Gui.KissTabControlEx();
            this.tpgDokumente = new SharpLibrary.WinControls.TabPageEx();
            this.edtDocument = new KiSS4.Dokument.XDokument();
            this.qryBgDokumente = new KiSS4.DB.SqlQuery(this.components);
            this.lblDokument = new KiSS4.Gui.KissLabel();
            this.edtStichwort = new KiSS4.Gui.KissTextEdit();
            this.lblStichwort = new KiSS4.Gui.KissLabel();
            this.edtDokumentTyp = new KiSS4.Gui.KissLookUpEdit();
            this.lblDokumentTyp = new KiSS4.Gui.KissLabel();
            this.grdDoc = new KiSS4.Gui.KissGrid();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDocTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStichwort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateCreation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateLastSave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpgEinzelzahlung = new SharpLibrary.WinControls.TabPageEx();
            this.btnDocument = new KiSS4.Gui.KissButton();
            this.lblBetragEff = new KiSS4.Gui.KissLabel();
            this.edtVerwaltungSD = new KiSS4.Gui.KissCheckEdit();
            this.edtKlientID = new KiSS4.Gui.KissTextEdit();
            this.edtFallNr = new KiSS4.Gui.KissCalcEdit();
            this.lblFallNr = new KiSS4.Gui.KissLabel();
            this.ctlErfassungMutation1 = new KiSS4.Common.CtlErfassungMutation();
            this.edtBgSplittingCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblBgSplittingCode = new KiSS4.Gui.KissLabel();
            this.lblVerwPeriodeStrich = new KiSS4.Gui.KissLabel();
            this.lblVerwPeriode = new KiSS4.Gui.KissLabel();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.edtZusatzInfo = new KiSS4.Gui.KissMemoEdit();
            this.lblDebitor = new KiSS4.Gui.KissLabel();
            this.lblValutaDatum = new KiSS4.Gui.KissLabel();
            this.lblMonatsbudget = new KiSS4.Gui.KissLabel();
            this.lblBaPersonID = new KiSS4.Gui.KissLabel();
            this.btnPositionGrau = new KiSS4.Gui.KissButton();
            this.lblBetrag = new KiSS4.Gui.KissLabel();
            this.btnPositionGruen = new KiSS4.Gui.KissButton();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.btnMonatsbudget = new KiSS4.Gui.KissButton();
            this.lblBuchungstext = new KiSS4.Gui.KissLabel();
            this.edtDebitor = new KiSS4.Gui.KissButtonEdit();
            this.edtFaelligAm = new KiSS4.Gui.KissDateEdit();
            this.lblKostenart = new KiSS4.Gui.KissLabel();
            this.grdMonatsbudget = new KiSS4.Gui.KissGrid();
            this.qryMonatsbudget = new KiSS4.DB.SqlQuery(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMonat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJahr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAktiv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtVerwPeriodeBis = new KiSS4.Gui.KissDateEdit();
            this.edtVerwPeriodeVon = new KiSS4.Gui.KissDateEdit();
            this.edtBaPersonID = new KiSS4.Gui.KissLookUpEdit();
            this.edtBetrag = new KiSS4.Gui.KissCalcEdit();
            this.lblKlient = new KiSS4.Gui.KissLabel();
            this.edtBuchungstext = new KiSS4.Gui.KissTextEdit();
            this.edtKostenart = new KiSS4.Gui.KissButtonEdit();
            this.edtKlient = new KiSS4.Gui.KissButtonEdit();
            this.kissLabel15 = new KiSS4.Gui.KissLabel();
            this.kissLabel14 = new KiSS4.Gui.KissLabel();
            this.edtTotal = new KiSS4.Gui.KissCalcEdit();
            this.edtAnzahl = new KiSS4.Gui.KissCalcEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRowCount = new System.Windows.Forms.Label();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSollstellung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSollstellung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheErfassungMA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheErfassungVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheErfassung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheErfassungBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFallNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheValutaVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFaelligAmVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFaelligAmBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheValutaBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInklNichtAbgetreteneEinnahmen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheZIPNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchePNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAHVNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKlient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKeepValues.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheSelectTop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVerfugbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLAList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWhSucheKlientX)).BeginInit();
            this.tabBgPosition.SuspendLayout();
            this.tpgDokumente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtDocument.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgDokumente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichwort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichwort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentTyp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokumentTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.tpgEinzelzahlung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetragEff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwaltungSD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlientID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFallNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFallNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSplittingCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSplittingCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgSplittingCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwPeriodeStrich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwPeriode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDebitor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValutaDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMonatsbudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDebitor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaelligAm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMonatsbudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryMonatsbudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwPeriodeBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwPeriodeVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnzahl.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Location = new System.Drawing.Point(-4, -3);
            this.searchTitle.Size = new System.Drawing.Size(859, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSearch.InvalidateOnPropertyChanged = false;
            this.tabControlSearch.Location = new System.Drawing.Point(5, 4);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(883, 341);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdSollstellung);
            this.tpgListe.Size = new System.Drawing.Size(871, 303);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.lblWhSucheKlientX);
            this.tpgSuchen.Controls.Add(this.edtLAList);
            this.tpgSuchen.Controls.Add(this.kissLabel11);
            this.tpgSuchen.Controls.Add(this.kissLabel12);
            this.tpgSuchen.Controls.Add(this.kissLabel13);
            this.tpgSuchen.Controls.Add(this.lblLeistungsart);
            this.tpgSuchen.Controls.Add(this.kissLabel10);
            this.tpgSuchen.Controls.Add(this.kissLabel9);
            this.tpgSuchen.Controls.Add(this.kissLabel6);
            this.tpgSuchen.Controls.Add(this.edtFilter2);
            this.tpgSuchen.Controls.Add(this.kissLabel4);
            this.tpgSuchen.Controls.Add(this.grdZugeteilt);
            this.tpgSuchen.Controls.Add(this.btnRemoveAll);
            this.tpgSuchen.Controls.Add(this.kissLabel3);
            this.tpgSuchen.Controls.Add(this.btnAddAll);
            this.tpgSuchen.Controls.Add(this.kissLabel2);
            this.tpgSuchen.Controls.Add(this.btnRemove);
            this.tpgSuchen.Controls.Add(this.btnAdd);
            this.tpgSuchen.Controls.Add(this.kissLabel1);
            this.tpgSuchen.Controls.Add(this.grdVerfuegbar);
            this.tpgSuchen.Controls.Add(this.edtFilter);
            this.tpgSuchen.Controls.Add(this.edtSucheSelectTop);
            this.tpgSuchen.Controls.Add(this.edtKeepValues);
            this.tpgSuchen.Controls.Add(this.edtSucheKlient);
            this.tpgSuchen.Controls.Add(this.lblSucheDatumBis);
            this.tpgSuchen.Controls.Add(this.edtSucheAHVNr);
            this.tpgSuchen.Controls.Add(this.lblSucheDatumVon);
            this.tpgSuchen.Controls.Add(this.edtSuchePNr);
            this.tpgSuchen.Controls.Add(this.edtSucheZIPNr);
            this.tpgSuchen.Controls.Add(this.lblSucheStatus);
            this.tpgSuchen.Controls.Add(this.edtSucheVorname);
            this.tpgSuchen.Controls.Add(this.edtSucheName);
            this.tpgSuchen.Controls.Add(this.edtInklNichtAbgetreteneEinnahmen);
            this.tpgSuchen.Controls.Add(this.lblSucheValutaBis);
            this.tpgSuchen.Controls.Add(this.edtSucheStatus);
            this.tpgSuchen.Controls.Add(this.lblSucheMitarbeiter);
            this.tpgSuchen.Controls.Add(this.edtSucheFaelligAmBis);
            this.tpgSuchen.Controls.Add(this.edtSucheFaelligAmVon);
            this.tpgSuchen.Controls.Add(this.lblSucheValutaVon);
            this.tpgSuchen.Controls.Add(this.edtSucheFallNr);
            this.tpgSuchen.Controls.Add(this.edtSucheErfassungBis);
            this.tpgSuchen.Controls.Add(this.lblSucheErfassung);
            this.tpgSuchen.Controls.Add(this.edtSucheErfassungVon);
            this.tpgSuchen.Controls.Add(this.edtSucheErfassungMA);
            this.tpgSuchen.Size = new System.Drawing.Size(871, 303);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheErfassungMA, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheErfassungVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheErfassung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheErfassungBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheFallNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheValutaVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheFaelligAmVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheFaelligAmBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheMitarbeiter, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheStatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheValutaBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtInklNichtAbgetreteneEinnahmen, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheVorname, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheStatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheZIPNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSuchePNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheAHVNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheKlient, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtKeepValues, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheSelectTop, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFilter, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.grdVerfuegbar, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel1, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.btnAdd, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.btnRemove, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel2, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.btnAddAll, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel3, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.btnRemoveAll, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.grdZugeteilt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel4, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFilter2, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel6, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel9, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel10, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblLeistungsart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel13, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel12, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel11, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtLAList, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblWhSucheKlientX, 0);
            // 
            // grdSollstellung
            // 
            this.grdSollstellung.DataSource = this.qryBgPosition;
            this.grdSollstellung.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdSollstellung.EmbeddedNavigator.Name = "";
            this.grdSollstellung.Location = new System.Drawing.Point(0, 0);
            this.grdSollstellung.MainView = this.grvSollstellung;
            this.grdSollstellung.Name = "grdSollstellung";
            this.grdSollstellung.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox2,
            this.repositoryItemCheckEdit1,
            this.repositoryItemTextEdit1});
            this.grdSollstellung.Size = new System.Drawing.Size(871, 303);
            this.grdSollstellung.TabIndex = 0;
            this.grdSollstellung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvSollstellung});
            this.grdSollstellung.Click += new System.EventHandler(this.grdSollstellung_Click);
            // 
            // qryBgPosition
            // 
            this.qryBgPosition.CanDelete = true;
            this.qryBgPosition.CanInsert = true;
            this.qryBgPosition.CanUpdate = true;
            this.qryBgPosition.DeleteQuestion = "Soll die Position gelöscht werden ?";
            this.qryBgPosition.FillTimeOut = 120;
            this.qryBgPosition.HostControl = this;
            this.qryBgPosition.SelectStatement = resources.GetString("qryBgPosition.SelectStatement");
            this.qryBgPosition.TableName = "BgPosition";
            this.qryBgPosition.AfterFill += new System.EventHandler(this.qryBgPosition_AfterFill);
            this.qryBgPosition.AfterInsert += new System.EventHandler(this.qryBgPosition_AfterInsert);
            this.qryBgPosition.BeforePost += new System.EventHandler(this.qryBgPosition_BeforePost);
            this.qryBgPosition.BeforeDeleteQuestion += new System.EventHandler(this.qryBgPosition_BeforeDeleteQuestion);
            this.qryBgPosition.BeforeDelete += new System.EventHandler(this.qryBgPosition_BeforeDelete);
            this.qryBgPosition.PositionChanged += new System.EventHandler(this.qryBgPosition_PositionChanged);
            // 
            // grvSollstellung
            // 
            this.grvSollstellung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvSollstellung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSollstellung.Appearance.Empty.Options.UseBackColor = true;
            this.grvSollstellung.Appearance.Empty.Options.UseFont = true;
            this.grvSollstellung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSollstellung.Appearance.EvenRow.Options.UseFont = true;
            this.grvSollstellung.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvSollstellung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSollstellung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvSollstellung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvSollstellung.Appearance.FocusedCell.Options.UseFont = true;
            this.grvSollstellung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvSollstellung.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvSollstellung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSollstellung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvSollstellung.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvSollstellung.Appearance.FocusedRow.Options.UseFont = true;
            this.grvSollstellung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvSollstellung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvSollstellung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvSollstellung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvSollstellung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvSollstellung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvSollstellung.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvSollstellung.Appearance.GroupRow.Options.UseFont = true;
            this.grvSollstellung.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvSollstellung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvSollstellung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvSollstellung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvSollstellung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvSollstellung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvSollstellung.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvSollstellung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvSollstellung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSollstellung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvSollstellung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvSollstellung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvSollstellung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvSollstellung.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvSollstellung.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvSollstellung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSollstellung.Appearance.OddRow.Options.UseFont = true;
            this.grvSollstellung.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvSollstellung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSollstellung.Appearance.Row.Options.UseBackColor = true;
            this.grvSollstellung.Appearance.Row.Options.UseFont = true;
            this.grvSollstellung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSollstellung.Appearance.SelectedRow.Options.UseFont = true;
            this.grvSollstellung.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvSollstellung.Appearance.VertLine.Options.UseBackColor = true;
            this.grvSollstellung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvSollstellung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colValuta,
            this.colTage,
            this.colKlient,
            this.colKOA,
            this.colBuchungstext,
            this.colBetrag,
            this.colDebitor,
            this.colDoc,
            this.colS,
            this.colM,
            this.colPSCDBelegNr,
            this.colPosStatus,
            this.colSelektion});
            this.grvSollstellung.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvSollstellung.GridControl = this.grdSollstellung;
            this.grvSollstellung.Name = "grvSollstellung";
            this.grvSollstellung.OptionsCustomization.AllowFilter = false;
            this.grvSollstellung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvSollstellung.OptionsNavigation.AutoFocusNewRow = true;
            this.grvSollstellung.OptionsNavigation.UseTabKey = false;
            this.grvSollstellung.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvSollstellung.OptionsView.ColumnAutoWidth = false;
            this.grvSollstellung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvSollstellung.OptionsView.ShowGroupPanel = false;
            this.grvSollstellung.OptionsView.ShowIndicator = false;
            // 
            // colValuta
            // 
            this.colValuta.Caption = "Fällig am";
            this.colValuta.FieldName = "FaelligAm";
            this.colValuta.Name = "colValuta";
            this.colValuta.OptionsColumn.AllowEdit = false;
            this.colValuta.Visible = true;
            this.colValuta.VisibleIndex = 0;
            // 
            // colTage
            // 
            this.colTage.Caption = "Tage";
            this.colTage.FieldName = "Tage";
            this.colTage.Name = "colTage";
            this.colTage.OptionsColumn.AllowEdit = false;
            this.colTage.Visible = true;
            this.colTage.VisibleIndex = 1;
            this.colTage.Width = 41;
            // 
            // colKlient
            // 
            this.colKlient.Caption = "Klient/in";
            this.colKlient.FieldName = "Klient";
            this.colKlient.Name = "colKlient";
            this.colKlient.OptionsColumn.AllowEdit = false;
            this.colKlient.Visible = true;
            this.colKlient.VisibleIndex = 2;
            this.colKlient.Width = 119;
            // 
            // colKOA
            // 
            this.colKOA.Caption = "LA";
            this.colKOA.FieldName = "KOA";
            this.colKOA.Name = "colKOA";
            this.colKOA.OptionsColumn.AllowEdit = false;
            this.colKOA.Visible = true;
            this.colKOA.VisibleIndex = 3;
            this.colKOA.Width = 40;
            // 
            // colBuchungstext
            // 
            this.colBuchungstext.Caption = "Buchungstext";
            this.colBuchungstext.FieldName = "Buchungstext";
            this.colBuchungstext.Name = "colBuchungstext";
            this.colBuchungstext.OptionsColumn.AllowEdit = false;
            this.colBuchungstext.Visible = true;
            this.colBuchungstext.VisibleIndex = 4;
            this.colBuchungstext.Width = 150;
            // 
            // colBetrag
            // 
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "n2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.OptionsColumn.AllowEdit = false;
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 5;
            // 
            // colDebitor
            // 
            this.colDebitor.Caption = "Debitor";
            this.colDebitor.FieldName = "Debitor";
            this.colDebitor.Name = "colDebitor";
            this.colDebitor.OptionsColumn.AllowEdit = false;
            this.colDebitor.Visible = true;
            this.colDebitor.VisibleIndex = 6;
            this.colDebitor.Width = 124;
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
            this.colDoc.VisibleIndex = 7;
            this.colDoc.Width = 32;
            // 
            // colS
            // 
            this.colS.Caption = "S";
            this.colS.FieldName = "S";
            this.colS.Name = "colS";
            this.colS.OptionsColumn.AllowEdit = false;
            this.colS.Visible = true;
            this.colS.VisibleIndex = 8;
            this.colS.Width = 20;
            // 
            // colM
            // 
            this.colM.Caption = "M";
            this.colM.FieldName = "M";
            this.colM.Name = "colM";
            this.colM.OptionsColumn.AllowEdit = false;
            this.colM.Visible = true;
            this.colM.VisibleIndex = 9;
            this.colM.Width = 20;
            // 
            // colPSCDBelegNr
            // 
            this.colPSCDBelegNr.Caption = "PSCD Beleg";
            this.colPSCDBelegNr.FieldName = "PSCDBelegNr";
            this.colPSCDBelegNr.Name = "colPSCDBelegNr";
            this.colPSCDBelegNr.OptionsColumn.AllowEdit = false;
            this.colPSCDBelegNr.Visible = true;
            this.colPSCDBelegNr.VisibleIndex = 10;
            this.colPSCDBelegNr.Width = 85;
            // 
            // colPosStatus
            // 
            this.colPosStatus.Caption = "Stat.";
            this.colPosStatus.ColumnEdit = this.repositoryItemImageComboBox2;
            this.colPosStatus.FieldName = "Status";
            this.colPosStatus.Name = "colPosStatus";
            this.colPosStatus.OptionsColumn.AllowEdit = false;
            this.colPosStatus.Visible = true;
            this.colPosStatus.VisibleIndex = 11;
            this.colPosStatus.Width = 35;
            // 
            // repositoryItemImageComboBox2
            // 
            this.repositoryItemImageComboBox2.AutoHeight = false;
            this.repositoryItemImageComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox2.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
            // 
            // colSelektion
            // 
            this.colSelektion.Caption = "Sel.";
            this.colSelektion.FieldName = "Sel";
            this.colSelektion.Name = "colSelektion";
            this.colSelektion.Visible = true;
            this.colSelektion.VisibleIndex = 12;
            this.colSelektion.Width = 30;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AllowFocused = false;
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            this.repositoryItemTextEdit1.ReadOnly = true;
            // 
            // edtSucheErfassungMA
            // 
            this.edtSucheErfassungMA.Location = new System.Drawing.Point(107, 22);
            this.edtSucheErfassungMA.Name = "edtSucheErfassungMA";
            this.edtSucheErfassungMA.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheErfassungMA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheErfassungMA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheErfassungMA.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheErfassungMA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheErfassungMA.Properties.Appearance.Options.UseFont = true;
            this.edtSucheErfassungMA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject18.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject18.Options.UseBackColor = true;
            this.edtSucheErfassungMA.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject18)});
            this.edtSucheErfassungMA.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheErfassungMA.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSucheErfassungMA.Size = new System.Drawing.Size(100, 24);
            this.edtSucheErfassungMA.TabIndex = 0;
            this.edtSucheErfassungMA.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheErfassungMA_UserModifiedFld);
            // 
            // edtSucheErfassungVon
            // 
            this.edtSucheErfassungVon.EditValue = null;
            this.edtSucheErfassungVon.Location = new System.Drawing.Point(213, 22);
            this.edtSucheErfassungVon.Name = "edtSucheErfassungVon";
            this.edtSucheErfassungVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheErfassungVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheErfassungVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheErfassungVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheErfassungVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheErfassungVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheErfassungVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheErfassungVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject17.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject17.Options.UseBackColor = true;
            this.edtSucheErfassungVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheErfassungVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject17)});
            this.edtSucheErfassungVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheErfassungVon.Properties.ShowToday = false;
            this.edtSucheErfassungVon.Size = new System.Drawing.Size(100, 24);
            this.edtSucheErfassungVon.TabIndex = 1;
            // 
            // lblSucheErfassung
            // 
            this.lblSucheErfassung.Location = new System.Drawing.Point(8, 22);
            this.lblSucheErfassung.Name = "lblSucheErfassung";
            this.lblSucheErfassung.Size = new System.Drawing.Size(93, 24);
            this.lblSucheErfassung.TabIndex = 1;
            this.lblSucheErfassung.Text = "Erfassung";
            this.lblSucheErfassung.UseCompatibleTextRendering = true;
            // 
            // edtSucheErfassungBis
            // 
            this.edtSucheErfassungBis.EditValue = null;
            this.edtSucheErfassungBis.Location = new System.Drawing.Point(319, 22);
            this.edtSucheErfassungBis.Name = "edtSucheErfassungBis";
            this.edtSucheErfassungBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheErfassungBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheErfassungBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheErfassungBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheErfassungBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheErfassungBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheErfassungBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheErfassungBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject16.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject16.Options.UseBackColor = true;
            this.edtSucheErfassungBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheErfassungBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject16)});
            this.edtSucheErfassungBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheErfassungBis.Properties.ShowToday = false;
            this.edtSucheErfassungBis.Size = new System.Drawing.Size(100, 24);
            this.edtSucheErfassungBis.TabIndex = 2;
            // 
            // edtSucheFallNr
            // 
            this.edtSucheFallNr.Location = new System.Drawing.Point(107, 52);
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
            this.edtSucheFallNr.TabIndex = 3;
            // 
            // lblSucheValutaVon
            // 
            this.lblSucheValutaVon.Location = new System.Drawing.Point(8, 82);
            this.lblSucheValutaVon.Name = "lblSucheValutaVon";
            this.lblSucheValutaVon.Size = new System.Drawing.Size(72, 24);
            this.lblSucheValutaVon.TabIndex = 3;
            this.lblSucheValutaVon.Text = "Fällig am";
            this.lblSucheValutaVon.UseCompatibleTextRendering = true;
            // 
            // edtSucheFaelligAmVon
            // 
            this.edtSucheFaelligAmVon.EditValue = null;
            this.edtSucheFaelligAmVon.Location = new System.Drawing.Point(107, 82);
            this.edtSucheFaelligAmVon.Name = "edtSucheFaelligAmVon";
            this.edtSucheFaelligAmVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheFaelligAmVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheFaelligAmVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheFaelligAmVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheFaelligAmVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheFaelligAmVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheFaelligAmVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheFaelligAmVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject15.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject15.Options.UseBackColor = true;
            this.edtSucheFaelligAmVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheFaelligAmVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject15)});
            this.edtSucheFaelligAmVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheFaelligAmVon.Properties.ShowToday = false;
            this.edtSucheFaelligAmVon.Size = new System.Drawing.Size(100, 24);
            this.edtSucheFaelligAmVon.TabIndex = 4;
            // 
            // edtSucheFaelligAmBis
            // 
            this.edtSucheFaelligAmBis.EditValue = null;
            this.edtSucheFaelligAmBis.Location = new System.Drawing.Point(263, 82);
            this.edtSucheFaelligAmBis.Name = "edtSucheFaelligAmBis";
            this.edtSucheFaelligAmBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheFaelligAmBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheFaelligAmBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheFaelligAmBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheFaelligAmBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheFaelligAmBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheFaelligAmBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheFaelligAmBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject14.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject14.Options.UseBackColor = true;
            this.edtSucheFaelligAmBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheFaelligAmBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject14)});
            this.edtSucheFaelligAmBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheFaelligAmBis.Properties.ShowToday = false;
            this.edtSucheFaelligAmBis.Size = new System.Drawing.Size(100, 24);
            this.edtSucheFaelligAmBis.TabIndex = 5;
            // 
            // lblSucheMitarbeiter
            // 
            this.lblSucheMitarbeiter.Location = new System.Drawing.Point(107, -6);
            this.lblSucheMitarbeiter.Name = "lblSucheMitarbeiter";
            this.lblSucheMitarbeiter.Size = new System.Drawing.Size(90, 24);
            this.lblSucheMitarbeiter.TabIndex = 5;
            this.lblSucheMitarbeiter.Text = "Mitarbeiter/in";
            this.lblSucheMitarbeiter.UseCompatibleTextRendering = true;
            // 
            // edtSucheStatus
            // 
            this.edtSucheStatus.Location = new System.Drawing.Point(107, 112);
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
            this.edtSucheStatus.Size = new System.Drawing.Size(256, 24);
            this.edtSucheStatus.TabIndex = 6;
            // 
            // lblSucheValutaBis
            // 
            this.lblSucheValutaBis.Location = new System.Drawing.Point(224, 82);
            this.lblSucheValutaBis.Name = "lblSucheValutaBis";
            this.lblSucheValutaBis.Size = new System.Drawing.Size(27, 24);
            this.lblSucheValutaBis.TabIndex = 6;
            this.lblSucheValutaBis.Text = "bis";
            this.lblSucheValutaBis.UseCompatibleTextRendering = true;
            // 
            // edtInklNichtAbgetreteneEinnahmen
            // 
            this.edtInklNichtAbgetreteneEinnahmen.EditValue = false;
            this.edtInklNichtAbgetreteneEinnahmen.Location = new System.Drawing.Point(104, 141);
            this.edtInklNichtAbgetreteneEinnahmen.Name = "edtInklNichtAbgetreteneEinnahmen";
            this.edtInklNichtAbgetreteneEinnahmen.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtInklNichtAbgetreteneEinnahmen.Properties.Appearance.Options.UseBackColor = true;
            this.edtInklNichtAbgetreteneEinnahmen.Properties.Caption = "inkl. nicht abgetretene Einnahmen";
            this.edtInklNichtAbgetreteneEinnahmen.Size = new System.Drawing.Size(204, 19);
            this.edtInklNichtAbgetreteneEinnahmen.TabIndex = 7;
            // 
            // edtSucheName
            // 
            this.edtSucheName.Location = new System.Drawing.Point(544, 5);
            this.edtSucheName.Name = "edtSucheName";
            this.edtSucheName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheName.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheName.Properties.Appearance.Options.UseFont = true;
            this.edtSucheName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheName.Size = new System.Drawing.Size(174, 24);
            this.edtSucheName.TabIndex = 8;
            // 
            // edtSucheVorname
            // 
            this.edtSucheVorname.Location = new System.Drawing.Point(544, 35);
            this.edtSucheVorname.Name = "edtSucheVorname";
            this.edtSucheVorname.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheVorname.Properties.Appearance.Options.UseFont = true;
            this.edtSucheVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheVorname.Size = new System.Drawing.Size(174, 24);
            this.edtSucheVorname.TabIndex = 9;
            // 
            // lblSucheStatus
            // 
            this.lblSucheStatus.Location = new System.Drawing.Point(8, 112);
            this.lblSucheStatus.Name = "lblSucheStatus";
            this.lblSucheStatus.Size = new System.Drawing.Size(72, 24);
            this.lblSucheStatus.TabIndex = 9;
            this.lblSucheStatus.Text = "Status";
            this.lblSucheStatus.UseCompatibleTextRendering = true;
            // 
            // edtSucheZIPNr
            // 
            this.edtSucheZIPNr.Location = new System.Drawing.Point(544, 65);
            this.edtSucheZIPNr.Name = "edtSucheZIPNr";
            this.edtSucheZIPNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheZIPNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheZIPNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheZIPNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheZIPNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheZIPNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheZIPNr.Properties.Appearance.Options.UseFont = true;
            this.edtSucheZIPNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheZIPNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheZIPNr.Size = new System.Drawing.Size(110, 24);
            this.edtSucheZIPNr.TabIndex = 10;
            // 
            // edtSuchePNr
            // 
            this.edtSuchePNr.Location = new System.Drawing.Point(544, 95);
            this.edtSuchePNr.Name = "edtSuchePNr";
            this.edtSuchePNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSuchePNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSuchePNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSuchePNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSuchePNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSuchePNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSuchePNr.Properties.Appearance.Options.UseFont = true;
            this.edtSuchePNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSuchePNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSuchePNr.Size = new System.Drawing.Size(110, 24);
            this.edtSuchePNr.TabIndex = 11;
            // 
            // lblSucheDatumVon
            // 
            this.lblSucheDatumVon.Location = new System.Drawing.Point(213, -5);
            this.lblSucheDatumVon.Name = "lblSucheDatumVon";
            this.lblSucheDatumVon.Size = new System.Drawing.Size(82, 24);
            this.lblSucheDatumVon.TabIndex = 11;
            this.lblSucheDatumVon.Text = "Datum von";
            this.lblSucheDatumVon.UseCompatibleTextRendering = true;
            // 
            // edtSucheAHVNr
            // 
            this.edtSucheAHVNr.Location = new System.Drawing.Point(749, 95);
            this.edtSucheAHVNr.Name = "edtSucheAHVNr";
            this.edtSucheAHVNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheAHVNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheAHVNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheAHVNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheAHVNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheAHVNr.Properties.Appearance.Options.UseFont = true;
            this.edtSucheAHVNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheAHVNr.Size = new System.Drawing.Size(111, 24);
            this.edtSucheAHVNr.TabIndex = 12;
            // 
            // lblSucheDatumBis
            // 
            this.lblSucheDatumBis.Location = new System.Drawing.Point(319, -5);
            this.lblSucheDatumBis.Name = "lblSucheDatumBis";
            this.lblSucheDatumBis.Size = new System.Drawing.Size(82, 24);
            this.lblSucheDatumBis.TabIndex = 12;
            this.lblSucheDatumBis.Text = "Datum bis";
            this.lblSucheDatumBis.UseCompatibleTextRendering = true;
            // 
            // edtSucheKlient
            // 
            this.edtSucheKlient.Location = new System.Drawing.Point(544, 125);
            this.edtSucheKlient.LookupSQL = resources.GetString("edtSucheKlient.LookupSQL");
            this.edtSucheKlient.Name = "edtSucheKlient";
            this.edtSucheKlient.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheKlient.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheKlient.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheKlient.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheKlient.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheKlient.Properties.Appearance.Options.UseFont = true;
            this.edtSucheKlient.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject13.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject13.Options.UseBackColor = true;
            this.edtSucheKlient.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13)});
            this.edtSucheKlient.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheKlient.Properties.Name = "kissButtonEdit1.Properties";
            this.edtSucheKlient.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSucheKlient.Size = new System.Drawing.Size(257, 24);
            this.edtSucheKlient.TabIndex = 13;
            this.edtSucheKlient.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheKlient_UserModifiedFld);
            // 
            // edtKeepValues
            // 
            this.edtKeepValues.EditValue = true;
            this.edtKeepValues.Location = new System.Drawing.Point(747, 56);
            this.edtKeepValues.Name = "edtKeepValues";
            this.edtKeepValues.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtKeepValues.Properties.Appearance.Options.UseBackColor = true;
            this.edtKeepValues.Properties.Caption = "Suchwerte erhalten";
            this.edtKeepValues.Size = new System.Drawing.Size(122, 19);
            this.edtKeepValues.TabIndex = 14;
            // 
            // edtSucheSelectTop
            // 
            this.edtSucheSelectTop.Location = new System.Drawing.Point(749, 24);
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
            this.edtSucheSelectTop.Size = new System.Drawing.Size(99, 24);
            this.edtSucheSelectTop.TabIndex = 14;
            // 
            // edtFilter
            // 
            this.edtFilter.Location = new System.Drawing.Point(10, 228);
            this.edtFilter.Name = "edtFilter";
            this.edtFilter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFilter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFilter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFilter.Properties.Appearance.Options.UseBackColor = true;
            this.edtFilter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFilter.Properties.Appearance.Options.UseFont = true;
            this.edtFilter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFilter.Size = new System.Drawing.Size(86, 24);
            this.edtFilter.TabIndex = 15;
            this.edtFilter.EditValueChanged += new System.EventHandler(this.edtFilter_EditValueChanged);
            // 
            // grdVerfuegbar
            // 
            this.grdVerfuegbar.DataSource = this.qryVerfuegbar;
            // 
            // 
            // 
            this.grdVerfuegbar.EmbeddedNavigator.Name = "";
            this.grdVerfuegbar.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            gridLevelNode1.RelationName = "Level1";
            this.grdVerfuegbar.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdVerfuegbar.Location = new System.Drawing.Point(107, 164);
            this.grdVerfuegbar.MainView = this.grvVerfugbar;
            this.grdVerfuegbar.Name = "grdVerfuegbar";
            this.grdVerfuegbar.Size = new System.Drawing.Size(257, 142);
            this.grdVerfuegbar.TabIndex = 16;
            this.grdVerfuegbar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVerfugbar});
            // 
            // qryVerfuegbar
            // 
            this.qryVerfuegbar.AutoApplyUserRights = false;
            this.qryVerfuegbar.BatchUpdate = true;
            this.qryVerfuegbar.CanDelete = true;
            this.qryVerfuegbar.CanInsert = true;
            this.qryVerfuegbar.DeleteQuestion = null;
            this.qryVerfuegbar.HostControl = this;
            this.qryVerfuegbar.SelectStatement = resources.GetString("qryVerfuegbar.SelectStatement");
            // 
            // grvVerfugbar
            // 
            this.grvVerfugbar.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvVerfugbar.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfugbar.Appearance.Empty.Options.UseBackColor = true;
            this.grvVerfugbar.Appearance.Empty.Options.UseFont = true;
            this.grvVerfugbar.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfugbar.Appearance.EvenRow.Options.UseFont = true;
            this.grvVerfugbar.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVerfugbar.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfugbar.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvVerfugbar.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvVerfugbar.Appearance.FocusedCell.Options.UseFont = true;
            this.grvVerfugbar.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvVerfugbar.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVerfugbar.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfugbar.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvVerfugbar.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvVerfugbar.Appearance.FocusedRow.Options.UseFont = true;
            this.grvVerfugbar.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvVerfugbar.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVerfugbar.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvVerfugbar.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVerfugbar.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVerfugbar.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVerfugbar.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvVerfugbar.Appearance.GroupRow.Options.UseFont = true;
            this.grvVerfugbar.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvVerfugbar.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvVerfugbar.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvVerfugbar.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVerfugbar.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvVerfugbar.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvVerfugbar.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvVerfugbar.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvVerfugbar.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfugbar.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVerfugbar.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvVerfugbar.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvVerfugbar.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvVerfugbar.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvVerfugbar.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvVerfugbar.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfugbar.Appearance.OddRow.Options.UseFont = true;
            this.grvVerfugbar.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvVerfugbar.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfugbar.Appearance.Row.Options.UseBackColor = true;
            this.grvVerfugbar.Appearance.Row.Options.UseFont = true;
            this.grvVerfugbar.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfugbar.Appearance.SelectedRow.Options.UseFont = true;
            this.grvVerfugbar.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvVerfugbar.Appearance.VertLine.Options.UseBackColor = true;
            this.grvVerfugbar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvVerfugbar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUserText});
            this.grvVerfugbar.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvVerfugbar.GridControl = this.grdVerfuegbar;
            this.grvVerfugbar.Name = "grvVerfugbar";
            this.grvVerfugbar.OptionsBehavior.Editable = false;
            this.grvVerfugbar.OptionsCustomization.AllowFilter = false;
            this.grvVerfugbar.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvVerfugbar.OptionsNavigation.AutoFocusNewRow = true;
            this.grvVerfugbar.OptionsNavigation.UseTabKey = false;
            this.grvVerfugbar.OptionsView.ColumnAutoWidth = false;
            this.grvVerfugbar.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvVerfugbar.OptionsView.ShowGroupPanel = false;
            this.grvVerfugbar.OptionsView.ShowIndicator = false;
            // 
            // colUserText
            // 
            this.colUserText.Caption = "Verfügbare Leistungsart";
            this.colUserText.FieldName = "Name";
            this.colUserText.Name = "colUserText";
            this.colUserText.Visible = true;
            this.colUserText.VisibleIndex = 0;
            this.colUserText.Width = 234;
            // 
            // kissLabel1
            // 
            this.kissLabel1.Location = new System.Drawing.Point(8, 52);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(51, 24);
            this.kissLabel1.TabIndex = 16;
            this.kissLabel1.Text = "Fall-Nr.";
            this.kissLabel1.UseCompatibleTextRendering = true;
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.IconID = 13;
            this.btnAdd.Location = new System.Drawing.Point(378, 187);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(28, 24);
            this.btnAdd.TabIndex = 17;
            this.btnAdd.UseCompatibleTextRendering = true;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.IconID = 11;
            this.btnRemove.Location = new System.Drawing.Point(378, 217);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(28, 24);
            this.btnRemove.TabIndex = 18;
            this.btnRemove.UseCompatibleTextRendering = true;
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // kissLabel2
            // 
            this.kissLabel2.Location = new System.Drawing.Point(749, 0);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(88, 24);
            this.kissLabel2.TabIndex = 18;
            this.kissLabel2.Text = "max. Datensätze";
            this.kissLabel2.UseCompatibleTextRendering = true;
            // 
            // btnAddAll
            // 
            this.btnAddAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAll.IconID = 14;
            this.btnAddAll.Location = new System.Drawing.Point(378, 247);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(28, 24);
            this.btnAddAll.TabIndex = 19;
            this.btnAddAll.UseCompatibleTextRendering = true;
            this.btnAddAll.UseVisualStyleBackColor = false;
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            // 
            // kissLabel3
            // 
            this.kissLabel3.Location = new System.Drawing.Point(449, 5);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(90, 24);
            this.kissLabel3.TabIndex = 19;
            this.kissLabel3.Text = "Name";
            this.kissLabel3.UseCompatibleTextRendering = true;
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAll.IconID = 12;
            this.btnRemoveAll.Location = new System.Drawing.Point(378, 277);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(28, 24);
            this.btnRemoveAll.TabIndex = 20;
            this.btnRemoveAll.UseCompatibleTextRendering = true;
            this.btnRemoveAll.UseVisualStyleBackColor = false;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // grdZugeteilt
            // 
            this.grdZugeteilt.DataSource = this.qryZugeteilt;
            // 
            // 
            // 
            this.grdZugeteilt.EmbeddedNavigator.Name = "";
            this.grdZugeteilt.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdZugeteilt.Location = new System.Drawing.Point(421, 164);
            this.grdZugeteilt.MainView = this.grvZugeteilt;
            this.grdZugeteilt.Name = "grdZugeteilt";
            this.grdZugeteilt.Size = new System.Drawing.Size(257, 142);
            this.grdZugeteilt.TabIndex = 21;
            this.grdZugeteilt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvZugeteilt});
            // 
            // qryZugeteilt
            // 
            this.qryZugeteilt.AutoApplyUserRights = false;
            this.qryZugeteilt.BatchUpdate = true;
            this.qryZugeteilt.CanDelete = true;
            this.qryZugeteilt.CanInsert = true;
            this.qryZugeteilt.HostControl = this;
            this.qryZugeteilt.SelectStatement = resources.GetString("qryZugeteilt.SelectStatement");
            // 
            // grvZugeteilt
            // 
            this.grvZugeteilt.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvZugeteilt.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.Empty.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.Empty.Options.UseFont = true;
            this.grvZugeteilt.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvZugeteilt.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.EvenRow.Options.UseBackColor = true;
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
            this.grvZugeteilt.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvZugeteilt.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvZugeteilt.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.SelectedRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvZugeteilt.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvZugeteilt.Appearance.VertLine.Options.UseBackColor = true;
            this.grvZugeteilt.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvZugeteilt.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUser});
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
            // colUser
            // 
            this.colUser.Caption = "Zugeteilte Leistungsart";
            this.colUser.FieldName = "Name";
            this.colUser.Name = "colUser";
            this.colUser.Visible = true;
            this.colUser.VisibleIndex = 0;
            this.colUser.Width = 234;
            // 
            // kissLabel4
            // 
            this.kissLabel4.Location = new System.Drawing.Point(449, 35);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(90, 24);
            this.kissLabel4.TabIndex = 21;
            this.kissLabel4.Text = "Vorname";
            this.kissLabel4.UseCompatibleTextRendering = true;
            // 
            // edtFilter2
            // 
            this.edtFilter2.Location = new System.Drawing.Point(684, 228);
            this.edtFilter2.Name = "edtFilter2";
            this.edtFilter2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFilter2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFilter2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFilter2.Properties.Appearance.Options.UseBackColor = true;
            this.edtFilter2.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFilter2.Properties.Appearance.Options.UseFont = true;
            this.edtFilter2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFilter2.Size = new System.Drawing.Size(100, 24);
            this.edtFilter2.TabIndex = 22;
            this.edtFilter2.EditValueChanged += new System.EventHandler(this.edtFilter2_EditValueChanged);
            // 
            // kissLabel6
            // 
            this.kissLabel6.Location = new System.Drawing.Point(449, 65);
            this.kissLabel6.Name = "kissLabel6";
            this.kissLabel6.Size = new System.Drawing.Size(90, 24);
            this.kissLabel6.TabIndex = 23;
            this.kissLabel6.Text = "PID";
            this.kissLabel6.UseCompatibleTextRendering = true;
            // 
            // kissLabel9
            // 
            this.kissLabel9.Location = new System.Drawing.Point(449, 95);
            this.kissLabel9.Name = "kissLabel9";
            this.kissLabel9.Size = new System.Drawing.Size(90, 24);
            this.kissLabel9.TabIndex = 25;
            this.kissLabel9.Text = "P-Nr.";
            this.kissLabel9.UseCompatibleTextRendering = true;
            // 
            // kissLabel10
            // 
            this.kissLabel10.Location = new System.Drawing.Point(697, 95);
            this.kissLabel10.Name = "kissLabel10";
            this.kissLabel10.Size = new System.Drawing.Size(46, 24);
            this.kissLabel10.TabIndex = 28;
            this.kissLabel10.Text = "AHV-Nr.";
            this.kissLabel10.UseCompatibleTextRendering = true;
            // 
            // lblLeistungsart
            // 
            this.lblLeistungsart.Location = new System.Drawing.Point(8, 164);
            this.lblLeistungsart.Name = "lblLeistungsart";
            this.lblLeistungsart.Size = new System.Drawing.Size(93, 24);
            this.lblLeistungsart.TabIndex = 31;
            this.lblLeistungsart.Text = "Leistungsarten";
            this.lblLeistungsart.UseCompatibleTextRendering = true;
            // 
            // kissLabel13
            // 
            this.kissLabel13.Location = new System.Drawing.Point(8, 204);
            this.kissLabel13.Name = "kissLabel13";
            this.kissLabel13.Size = new System.Drawing.Size(35, 24);
            this.kissLabel13.TabIndex = 40;
            this.kissLabel13.Text = "Filter";
            this.kissLabel13.UseCompatibleTextRendering = true;
            // 
            // kissLabel12
            // 
            this.kissLabel12.Location = new System.Drawing.Point(685, 164);
            this.kissLabel12.Name = "kissLabel12";
            this.kissLabel12.Size = new System.Drawing.Size(90, 24);
            this.kissLabel12.TabIndex = 41;
            this.kissLabel12.Text = "(leer = alle LA)";
            this.kissLabel12.UseCompatibleTextRendering = true;
            // 
            // kissLabel11
            // 
            this.kissLabel11.Location = new System.Drawing.Point(684, 204);
            this.kissLabel11.Name = "kissLabel11";
            this.kissLabel11.Size = new System.Drawing.Size(35, 24);
            this.kissLabel11.TabIndex = 42;
            this.kissLabel11.Text = "Filter";
            this.kissLabel11.UseCompatibleTextRendering = true;
            // 
            // edtLAList
            // 
            this.edtLAList.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtLAList.Location = new System.Drawing.Point(685, 277);
            this.edtLAList.Name = "edtLAList";
            this.edtLAList.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtLAList.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLAList.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLAList.Properties.Appearance.Options.UseBackColor = true;
            this.edtLAList.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLAList.Properties.Appearance.Options.UseFont = true;
            this.edtLAList.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtLAList.Properties.ReadOnly = true;
            this.edtLAList.Size = new System.Drawing.Size(19, 24);
            this.edtLAList.TabIndex = 43;
            this.edtLAList.Visible = false;
            // 
            // lblWhSucheKlientX
            // 
            this.lblWhSucheKlientX.Location = new System.Drawing.Point(449, 125);
            this.lblWhSucheKlientX.Name = "lblWhSucheKlientX";
            this.lblWhSucheKlientX.Size = new System.Drawing.Size(70, 24);
            this.lblWhSucheKlientX.TabIndex = 45;
            this.lblWhSucheKlientX.Text = "Klient";
            this.lblWhSucheKlientX.UseCompatibleTextRendering = true;
            // 
            // btnTransfer
            // 
            this.btnTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransfer.Location = new System.Drawing.Point(764, 321);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(124, 24);
            this.btnTransfer.TabIndex = 1;
            this.btnTransfer.Text = "Transfer zu PSCD";
            this.btnTransfer.UseCompatibleTextRendering = true;
            this.btnTransfer.UseVisualStyleBackColor = false;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // btnKeine
            // 
            this.btnKeine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKeine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeine.Location = new System.Drawing.Point(710, 321);
            this.btnKeine.Name = "btnKeine";
            this.btnKeine.Size = new System.Drawing.Size(48, 24);
            this.btnKeine.TabIndex = 2;
            this.btnKeine.Text = "Keine";
            this.btnKeine.UseCompatibleTextRendering = true;
            this.btnKeine.UseVisualStyleBackColor = false;
            this.btnKeine.Click += new System.EventHandler(this.btnKeine_Click);
            // 
            // btnAlle
            // 
            this.btnAlle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlle.Location = new System.Drawing.Point(656, 321);
            this.btnAlle.Name = "btnAlle";
            this.btnAlle.Size = new System.Drawing.Size(48, 24);
            this.btnAlle.TabIndex = 3;
            this.btnAlle.Text = "Alle";
            this.btnAlle.UseCompatibleTextRendering = true;
            this.btnAlle.UseVisualStyleBackColor = false;
            this.btnAlle.Click += new System.EventHandler(this.btnAlle_Click);
            // 
            // tabBgPosition
            // 
            this.tabBgPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabBgPosition.Controls.Add(this.tpgDokumente);
            this.tabBgPosition.Controls.Add(this.tpgEinzelzahlung);
            this.tabBgPosition.Location = new System.Drawing.Point(5, 348);
            this.tabBgPosition.Name = "tabBgPosition";
            this.tabBgPosition.SelectedTabIndex = 1;
            this.tabBgPosition.ShowFixedWidthTooltip = true;
            this.tabBgPosition.Size = new System.Drawing.Size(883, 324);
            this.tabBgPosition.TabIndex = 4;
            this.tabBgPosition.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgEinzelzahlung,
            this.tpgDokumente});
            this.tabBgPosition.TabsLineColor = System.Drawing.Color.Black;
            this.tabBgPosition.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabBgPosition.Text = "kissTabControlEx1";
            // 
            // tpgDokumente
            // 
            this.tpgDokumente.Controls.Add(this.edtDocument);
            this.tpgDokumente.Controls.Add(this.lblDokument);
            this.tpgDokumente.Controls.Add(this.edtStichwort);
            this.tpgDokumente.Controls.Add(this.lblStichwort);
            this.tpgDokumente.Controls.Add(this.edtDokumentTyp);
            this.tpgDokumente.Controls.Add(this.lblDokumentTyp);
            this.tpgDokumente.Controls.Add(this.grdDoc);
            this.tpgDokumente.Location = new System.Drawing.Point(6, 6);
            this.tpgDokumente.Margin = new System.Windows.Forms.Padding(9);
            this.tpgDokumente.Name = "tpgDokumente";
            this.tpgDokumente.Size = new System.Drawing.Size(871, 286);
            this.tpgDokumente.TabIndex = 1;
            this.tpgDokumente.Title = "Dokumente";
            // 
            // edtDocument
            // 
            this.edtDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDocument.CanDeleteDocument = false;
            this.edtDocument.Context = "FaDokumente";
            this.edtDocument.DataMember = "DocumentID";
            this.edtDocument.DataSource = this.qryBgDokumente;
            this.edtDocument.Location = new System.Drawing.Point(751, 256);
            this.edtDocument.Name = "edtDocument";
            this.edtDocument.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDocument.Properties.Appearance.Options.UseBackColor = true;
            this.edtDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDocument.Properties.Appearance.Options.UseFont = true;
            this.edtDocument.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocument.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocument.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocument.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "Dokument importieren")});
            this.edtDocument.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDocument.Properties.ReadOnly = true;
            this.edtDocument.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtDocument.Size = new System.Drawing.Size(117, 24);
            this.edtDocument.TabIndex = 6;
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
            this.qryBgDokumente.BeforeInsert += new System.EventHandler(this.qryBgDokumente_BeforeInsert);
            this.qryBgDokumente.AfterInsert += new System.EventHandler(this.qryBgDokumente_AfterInsert);
            this.qryBgDokumente.BeforePost += new System.EventHandler(this.qryBgDokumente_BeforePost);
            this.qryBgDokumente.AfterDelete += new System.EventHandler(this.qryBgDokumente_AfterDelete);
            this.qryBgDokumente.ColumnChanged += new System.Data.DataColumnChangeEventHandler(this.qryBgDokumente_ColumnChanged);
            // 
            // lblDokument
            // 
            this.lblDokument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDokument.Location = new System.Drawing.Point(686, 256);
            this.lblDokument.Name = "lblDokument";
            this.lblDokument.Size = new System.Drawing.Size(59, 24);
            this.lblDokument.TabIndex = 5;
            this.lblDokument.Text = "Dokument";
            this.lblDokument.UseCompatibleTextRendering = true;
            // 
            // edtStichwort
            // 
            this.edtStichwort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtStichwort.DataMember = "Stichwort";
            this.edtStichwort.DataSource = this.qryBgDokumente;
            this.edtStichwort.Location = new System.Drawing.Point(240, 256);
            this.edtStichwort.Name = "edtStichwort";
            this.edtStichwort.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStichwort.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStichwort.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStichwort.Properties.Appearance.Options.UseBackColor = true;
            this.edtStichwort.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStichwort.Properties.Appearance.Options.UseFont = true;
            this.edtStichwort.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStichwort.Size = new System.Drawing.Size(440, 24);
            this.edtStichwort.TabIndex = 4;
            // 
            // lblStichwort
            // 
            this.lblStichwort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStichwort.Location = new System.Drawing.Point(179, 256);
            this.lblStichwort.Name = "lblStichwort";
            this.lblStichwort.Size = new System.Drawing.Size(55, 24);
            this.lblStichwort.TabIndex = 3;
            this.lblStichwort.Text = "Stichwort";
            this.lblStichwort.UseCompatibleTextRendering = true;
            // 
            // edtDokumentTyp
            // 
            this.edtDokumentTyp.AllowNull = false;
            this.edtDokumentTyp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDokumentTyp.DataMember = "BgDokumentTypCode";
            this.edtDokumentTyp.DataSource = this.qryBgDokumente;
            this.edtDokumentTyp.Location = new System.Drawing.Point(39, 256);
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
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtDokumentTyp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtDokumentTyp.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDokumentTyp.Properties.NullText = "";
            this.edtDokumentTyp.Properties.ShowFooter = false;
            this.edtDokumentTyp.Properties.ShowHeader = false;
            this.edtDokumentTyp.Size = new System.Drawing.Size(134, 24);
            this.edtDokumentTyp.TabIndex = 2;
            // 
            // lblDokumentTyp
            // 
            this.lblDokumentTyp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDokumentTyp.Location = new System.Drawing.Point(3, 256);
            this.lblDokumentTyp.Name = "lblDokumentTyp";
            this.lblDokumentTyp.Size = new System.Drawing.Size(30, 24);
            this.lblDokumentTyp.TabIndex = 1;
            this.lblDokumentTyp.Text = "Typ";
            this.lblDokumentTyp.UseCompatibleTextRendering = true;
            // 
            // grdDoc
            // 
            this.grdDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDoc.DataSource = this.qryBgDokumente;
            // 
            // 
            // 
            this.grdDoc.EmbeddedNavigator.Name = "";
            this.grdDoc.Location = new System.Drawing.Point(3, 3);
            this.grdDoc.MainView = this.gridView1;
            this.grdDoc.Name = "grdDoc";
            this.grdDoc.Size = new System.Drawing.Size(865, 247);
            this.grdDoc.TabIndex = 0;
            this.grdDoc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.Empty.Options.UseFont = true;
            this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.EvenRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.OddRow.Options.UseFont = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDocTyp,
            this.colStichwort,
            this.colDateCreation,
            this.colDateLastSave});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.grdDoc;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
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
            // tpgEinzelzahlung
            // 
            this.tpgEinzelzahlung.Controls.Add(this.btnDocument);
            this.tpgEinzelzahlung.Controls.Add(this.lblBetragEff);
            this.tpgEinzelzahlung.Controls.Add(this.edtVerwaltungSD);
            this.tpgEinzelzahlung.Controls.Add(this.edtKlientID);
            this.tpgEinzelzahlung.Controls.Add(this.edtFallNr);
            this.tpgEinzelzahlung.Controls.Add(this.lblFallNr);
            this.tpgEinzelzahlung.Controls.Add(this.ctlErfassungMutation1);
            this.tpgEinzelzahlung.Controls.Add(this.edtBgSplittingCode);
            this.tpgEinzelzahlung.Controls.Add(this.lblBgSplittingCode);
            this.tpgEinzelzahlung.Controls.Add(this.lblVerwPeriodeStrich);
            this.tpgEinzelzahlung.Controls.Add(this.lblVerwPeriode);
            this.tpgEinzelzahlung.Controls.Add(this.lblBemerkung);
            this.tpgEinzelzahlung.Controls.Add(this.edtZusatzInfo);
            this.tpgEinzelzahlung.Controls.Add(this.lblDebitor);
            this.tpgEinzelzahlung.Controls.Add(this.lblValutaDatum);
            this.tpgEinzelzahlung.Controls.Add(this.lblMonatsbudget);
            this.tpgEinzelzahlung.Controls.Add(this.lblBaPersonID);
            this.tpgEinzelzahlung.Controls.Add(this.btnPositionGrau);
            this.tpgEinzelzahlung.Controls.Add(this.lblBetrag);
            this.tpgEinzelzahlung.Controls.Add(this.btnPositionGruen);
            this.tpgEinzelzahlung.Controls.Add(this.edtBemerkung);
            this.tpgEinzelzahlung.Controls.Add(this.btnMonatsbudget);
            this.tpgEinzelzahlung.Controls.Add(this.lblBuchungstext);
            this.tpgEinzelzahlung.Controls.Add(this.edtDebitor);
            this.tpgEinzelzahlung.Controls.Add(this.edtFaelligAm);
            this.tpgEinzelzahlung.Controls.Add(this.lblKostenart);
            this.tpgEinzelzahlung.Controls.Add(this.grdMonatsbudget);
            this.tpgEinzelzahlung.Controls.Add(this.edtVerwPeriodeBis);
            this.tpgEinzelzahlung.Controls.Add(this.edtVerwPeriodeVon);
            this.tpgEinzelzahlung.Controls.Add(this.edtBaPersonID);
            this.tpgEinzelzahlung.Controls.Add(this.edtBetrag);
            this.tpgEinzelzahlung.Controls.Add(this.lblKlient);
            this.tpgEinzelzahlung.Controls.Add(this.edtBuchungstext);
            this.tpgEinzelzahlung.Controls.Add(this.edtKostenart);
            this.tpgEinzelzahlung.Controls.Add(this.edtKlient);
            this.tpgEinzelzahlung.Location = new System.Drawing.Point(6, 6);
            this.tpgEinzelzahlung.Margin = new System.Windows.Forms.Padding(9);
            this.tpgEinzelzahlung.Name = "tpgEinzelzahlung";
            this.tpgEinzelzahlung.Size = new System.Drawing.Size(871, 286);
            this.tpgEinzelzahlung.TabIndex = 0;
            this.tpgEinzelzahlung.Title = "Sollstellung";
            // 
            // btnDocument
            // 
            this.btnDocument.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDocument.Location = new System.Drawing.Point(771, 5);
            this.btnDocument.Name = "btnDocument";
            this.btnDocument.Size = new System.Drawing.Size(24, 24);
            this.btnDocument.TabIndex = 582;
            this.btnDocument.UseCompatibleTextRendering = true;
            this.btnDocument.UseVisualStyleBackColor = false;
            this.btnDocument.Click += new System.EventHandler(this.btnDocument_Click);
            // 
            // lblBetragEff
            // 
            this.lblBetragEff.DataMember = "EffektivText";
            this.lblBetragEff.DataSource = this.qryBgPosition;
            this.lblBetragEff.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblBetragEff.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblBetragEff.Location = new System.Drawing.Point(206, 90);
            this.lblBetragEff.Name = "lblBetragEff";
            this.lblBetragEff.Size = new System.Drawing.Size(211, 16);
            this.lblBetragEff.TabIndex = 410;
            this.lblBetragEff.UseCompatibleTextRendering = true;
            // 
            // edtVerwaltungSD
            // 
            this.edtVerwaltungSD.DataMember = "VerwaltungSD";
            this.edtVerwaltungSD.DataSource = this.qryBgPosition;
            this.edtVerwaltungSD.Location = new System.Drawing.Point(528, 145);
            this.edtVerwaltungSD.Name = "edtVerwaltungSD";
            this.edtVerwaltungSD.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtVerwaltungSD.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerwaltungSD.Properties.Caption = "Ermächtigung - Einnahmen an SoD";
            this.edtVerwaltungSD.Size = new System.Drawing.Size(213, 19);
            this.edtVerwaltungSD.TabIndex = 409;
            // 
            // edtKlientID
            // 
            this.edtKlientID.DataMember = "KlientID";
            this.edtKlientID.DataSource = this.qryBgPosition;
            this.edtKlientID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKlientID.Location = new System.Drawing.Point(353, 4);
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
            this.edtKlientID.TabIndex = 404;
            // 
            // edtFallNr
            // 
            this.edtFallNr.DataMember = "FaFallID";
            this.edtFallNr.DataSource = this.qryBgPosition;
            this.edtFallNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtFallNr.Location = new System.Drawing.Point(528, 222);
            this.edtFallNr.Name = "edtFallNr";
            this.edtFallNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtFallNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtFallNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFallNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFallNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtFallNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFallNr.Properties.Appearance.Options.UseFont = true;
            this.edtFallNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFallNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFallNr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtFallNr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtFallNr.Properties.ReadOnly = true;
            this.edtFallNr.Size = new System.Drawing.Size(90, 24);
            this.edtFallNr.TabIndex = 49;
            // 
            // lblFallNr
            // 
            this.lblFallNr.Location = new System.Drawing.Point(438, 222);
            this.lblFallNr.Name = "lblFallNr";
            this.lblFallNr.Size = new System.Drawing.Size(38, 24);
            this.lblFallNr.TabIndex = 48;
            this.lblFallNr.Text = "Fall-Nr.";
            this.lblFallNr.UseCompatibleTextRendering = true;
            // 
            // ctlErfassungMutation1
            // 
            this.ctlErfassungMutation1.ActiveSQLQuery = this.qryBgPosition;
            this.ctlErfassungMutation1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlErfassungMutation1.LabelLength = 60;
            this.ctlErfassungMutation1.Location = new System.Drawing.Point(528, 249);
            this.ctlErfassungMutation1.Name = "ctlErfassungMutation1";
            this.ctlErfassungMutation1.Size = new System.Drawing.Size(243, 38);
            this.ctlErfassungMutation1.TabIndex = 47;
            // 
            // edtBgSplittingCode
            // 
            this.edtBgSplittingCode.AllowNull = false;
            this.edtBgSplittingCode.DataMember = "BgSplittingartCode";
            this.edtBgSplittingCode.DataSource = this.qryBgPosition;
            this.edtBgSplittingCode.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBgSplittingCode.Location = new System.Drawing.Point(333, 146);
            this.edtBgSplittingCode.LOVName = "BgSplittingart";
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
            this.edtBgSplittingCode.Size = new System.Drawing.Size(85, 24);
            this.edtBgSplittingCode.TabIndex = 42;
            this.edtBgSplittingCode.TabStop = false;
            // 
            // lblBgSplittingCode
            // 
            this.lblBgSplittingCode.Location = new System.Drawing.Point(302, 146);
            this.lblBgSplittingCode.Name = "lblBgSplittingCode";
            this.lblBgSplittingCode.Size = new System.Drawing.Size(37, 24);
            this.lblBgSplittingCode.TabIndex = 41;
            this.lblBgSplittingCode.Text = "Split.";
            this.lblBgSplittingCode.UseCompatibleTextRendering = true;
            // 
            // lblVerwPeriodeStrich
            // 
            this.lblVerwPeriodeStrich.Location = new System.Drawing.Point(195, 146);
            this.lblVerwPeriodeStrich.Name = "lblVerwPeriodeStrich";
            this.lblVerwPeriodeStrich.Size = new System.Drawing.Size(7, 24);
            this.lblVerwPeriodeStrich.TabIndex = 39;
            this.lblVerwPeriodeStrich.Text = "-";
            this.lblVerwPeriodeStrich.UseCompatibleTextRendering = true;
            // 
            // lblVerwPeriode
            // 
            this.lblVerwPeriode.Location = new System.Drawing.Point(6, 146);
            this.lblVerwPeriode.Name = "lblVerwPeriode";
            this.lblVerwPeriode.Size = new System.Drawing.Size(86, 24);
            this.lblVerwPeriode.TabIndex = 37;
            this.lblVerwPeriode.Text = "Verwendungsp.";
            this.lblVerwPeriode.UseCompatibleTextRendering = true;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.Location = new System.Drawing.Point(437, 176);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(86, 24);
            this.lblBemerkung.TabIndex = 35;
            this.lblBemerkung.Text = "Bemerkung";
            this.lblBemerkung.UseCompatibleTextRendering = true;
            // 
            // edtZusatzInfo
            // 
            this.edtZusatzInfo.DataMember = "ZusatzInfo";
            this.edtZusatzInfo.DataSource = this.qryBgPosition;
            this.edtZusatzInfo.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtZusatzInfo.Location = new System.Drawing.Point(530, 57);
            this.edtZusatzInfo.Name = "edtZusatzInfo";
            this.edtZusatzInfo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtZusatzInfo.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZusatzInfo.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZusatzInfo.Properties.Appearance.Options.UseBackColor = true;
            this.edtZusatzInfo.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZusatzInfo.Properties.Appearance.Options.UseFont = true;
            this.edtZusatzInfo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZusatzInfo.Properties.ReadOnly = true;
            this.edtZusatzInfo.Size = new System.Drawing.Size(265, 76);
            this.edtZusatzInfo.TabIndex = 28;
            // 
            // lblDebitor
            // 
            this.lblDebitor.Location = new System.Drawing.Point(438, 34);
            this.lblDebitor.Name = "lblDebitor";
            this.lblDebitor.Size = new System.Drawing.Size(86, 24);
            this.lblDebitor.TabIndex = 26;
            this.lblDebitor.Text = "Debitor";
            this.lblDebitor.UseCompatibleTextRendering = true;
            // 
            // lblValutaDatum
            // 
            this.lblValutaDatum.Location = new System.Drawing.Point(438, 4);
            this.lblValutaDatum.Name = "lblValutaDatum";
            this.lblValutaDatum.Size = new System.Drawing.Size(86, 24);
            this.lblValutaDatum.TabIndex = 22;
            this.lblValutaDatum.Text = "Fällig am";
            this.lblValutaDatum.UseCompatibleTextRendering = true;
            // 
            // lblMonatsbudget
            // 
            this.lblMonatsbudget.Location = new System.Drawing.Point(9, 176);
            this.lblMonatsbudget.Name = "lblMonatsbudget";
            this.lblMonatsbudget.Size = new System.Drawing.Size(90, 24);
            this.lblMonatsbudget.TabIndex = 19;
            this.lblMonatsbudget.Text = "Monatsbudgets";
            this.lblMonatsbudget.UseCompatibleTextRendering = true;
            // 
            // lblBaPersonID
            // 
            this.lblBaPersonID.Location = new System.Drawing.Point(6, 116);
            this.lblBaPersonID.Name = "lblBaPersonID";
            this.lblBaPersonID.Size = new System.Drawing.Size(90, 24);
            this.lblBaPersonID.TabIndex = 15;
            this.lblBaPersonID.Text = "Betrifft Person";
            this.lblBaPersonID.UseCompatibleTextRendering = true;
            // 
            // btnPositionGrau
            // 
            this.btnPositionGrau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPositionGrau.IconID = 1351;
            this.btnPositionGrau.Location = new System.Drawing.Point(469, 86);
            this.btnPositionGrau.Name = "btnPositionGrau";
            this.btnPositionGrau.Size = new System.Drawing.Size(25, 24);
            this.btnPositionGrau.TabIndex = 12;
            this.btnPositionGrau.UseCompatibleTextRendering = true;
            this.btnPositionGrau.UseVisualStyleBackColor = false;
            this.btnPositionGrau.Visible = false;
            this.btnPositionGrau.Click += new System.EventHandler(this.btnPositionGrau_Click);
            // 
            // lblBetrag
            // 
            this.lblBetrag.Location = new System.Drawing.Point(6, 86);
            this.lblBetrag.Name = "lblBetrag";
            this.lblBetrag.Size = new System.Drawing.Size(90, 24);
            this.lblBetrag.TabIndex = 11;
            this.lblBetrag.Text = "Betrag CHF";
            this.lblBetrag.UseCompatibleTextRendering = true;
            // 
            // btnPositionGruen
            // 
            this.btnPositionGruen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPositionGruen.IconID = 1352;
            this.btnPositionGruen.Location = new System.Drawing.Point(438, 86);
            this.btnPositionGruen.Name = "btnPositionGruen";
            this.btnPositionGruen.Size = new System.Drawing.Size(25, 24);
            this.btnPositionGruen.TabIndex = 11;
            this.btnPositionGruen.UseCompatibleTextRendering = true;
            this.btnPositionGruen.UseVisualStyleBackColor = false;
            this.btnPositionGruen.Visible = false;
            this.btnPositionGruen.Click += new System.EventHandler(this.btnPositionGruen_Click);
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryBgPosition;
            this.edtBemerkung.Location = new System.Drawing.Point(529, 176);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(266, 41);
            this.edtBemerkung.TabIndex = 10;
            // 
            // btnMonatsbudget
            // 
            this.btnMonatsbudget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonatsbudget.Location = new System.Drawing.Point(10, 205);
            this.btnMonatsbudget.Name = "btnMonatsbudget";
            this.btnMonatsbudget.Size = new System.Drawing.Size(76, 24);
            this.btnMonatsbudget.TabIndex = 10;
            this.btnMonatsbudget.Text = "> Budget";
            this.btnMonatsbudget.UseCompatibleTextRendering = true;
            this.btnMonatsbudget.UseVisualStyleBackColor = false;
            this.btnMonatsbudget.Click += new System.EventHandler(this.btnMonatsbudget_Click);
            // 
            // lblBuchungstext
            // 
            this.lblBuchungstext.Location = new System.Drawing.Point(6, 56);
            this.lblBuchungstext.Name = "lblBuchungstext";
            this.lblBuchungstext.Size = new System.Drawing.Size(90, 24);
            this.lblBuchungstext.TabIndex = 9;
            this.lblBuchungstext.Text = "Buchungstext";
            this.lblBuchungstext.UseCompatibleTextRendering = true;
            // 
            // edtDebitor
            // 
            this.edtDebitor.DataMember = "Debitor";
            this.edtDebitor.DataSource = this.qryBgPosition;
            this.edtDebitor.Location = new System.Drawing.Point(530, 34);
            this.edtDebitor.Name = "edtDebitor";
            this.edtDebitor.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDebitor.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDebitor.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDebitor.Properties.Appearance.Options.UseBackColor = true;
            this.edtDebitor.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDebitor.Properties.Appearance.Options.UseFont = true;
            this.edtDebitor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtDebitor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtDebitor.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDebitor.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtDebitor.Size = new System.Drawing.Size(265, 24);
            this.edtDebitor.TabIndex = 9;
            this.edtDebitor.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtDebitor_UserModifiedFld);
            // 
            // edtFaelligAm
            // 
            this.edtFaelligAm.DataMember = "FaelligAm";
            this.edtFaelligAm.DataSource = this.qryBgPosition;
            this.edtFaelligAm.EditValue = null;
            this.edtFaelligAm.Location = new System.Drawing.Point(530, 4);
            this.edtFaelligAm.Name = "edtFaelligAm";
            this.edtFaelligAm.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtFaelligAm.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaelligAm.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaelligAm.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaelligAm.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaelligAm.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaelligAm.Properties.Appearance.Options.UseFont = true;
            this.edtFaelligAm.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtFaelligAm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtFaelligAm.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtFaelligAm.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFaelligAm.Properties.ShowToday = false;
            this.edtFaelligAm.Size = new System.Drawing.Size(90, 24);
            this.edtFaelligAm.TabIndex = 8;
            // 
            // lblKostenart
            // 
            this.lblKostenart.Location = new System.Drawing.Point(6, 34);
            this.lblKostenart.Name = "lblKostenart";
            this.lblKostenart.Size = new System.Drawing.Size(90, 24);
            this.lblKostenart.TabIndex = 7;
            this.lblKostenart.Text = "LA/Positionsart";
            this.lblKostenart.UseCompatibleTextRendering = true;
            // 
            // grdMonatsbudget
            // 
            this.grdMonatsbudget.DataSource = this.qryMonatsbudget;
            // 
            // 
            // 
            this.grdMonatsbudget.EmbeddedNavigator.Name = "gridPeriode.EmbeddedNavigator";
            this.grdMonatsbudget.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdMonatsbudget.Location = new System.Drawing.Point(101, 176);
            this.grdMonatsbudget.MainView = this.gridView2;
            this.grdMonatsbudget.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.grdMonatsbudget.Name = "grdMonatsbudget";
            this.grdMonatsbudget.Size = new System.Drawing.Size(265, 110);
            this.grdMonatsbudget.TabIndex = 7;
            this.grdMonatsbudget.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // qryMonatsbudget
            // 
            this.qryMonatsbudget.BatchUpdate = true;
            this.qryMonatsbudget.HostControl = this;
            this.qryMonatsbudget.SelectStatement = resources.GetString("qryMonatsbudget.SelectStatement");
            this.qryMonatsbudget.PositionChanged += new System.EventHandler(this.qryMonatsbudget_PositionChanged);
            // 
            // gridView2
            // 
            this.gridView2.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView2.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.Empty.Options.UseBackColor = true;
            this.gridView2.Appearance.Empty.Options.UseFont = true;
            this.gridView2.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.gridView2.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.EvenRow.Options.UseBackColor = true;
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
            this.gridView2.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView2.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView2.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupRow.Options.UseFont = true;
            this.gridView2.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView2.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView2.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
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
            this.gridView2.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gridView2.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView2.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView2.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView2.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView2.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMonat,
            this.colJahr,
            this.colStatus,
            this.colAktiv});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView2.GridControl = this.grdMonatsbudget;
            this.gridView2.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsCustomization.AllowFilter = false;
            this.gridView2.OptionsFilter.AllowFilterEditor = false;
            this.gridView2.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView2.OptionsMenu.EnableColumnMenu = false;
            this.gridView2.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView2.OptionsNavigation.UseTabKey = false;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowIndicator = false;
            // 
            // colMonat
            // 
            this.colMonat.Caption = "Monat";
            this.colMonat.FieldName = "MonatText";
            this.colMonat.Name = "colMonat";
            this.colMonat.Visible = true;
            this.colMonat.VisibleIndex = 0;
            this.colMonat.Width = 90;
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
            // colAktiv
            // 
            this.colAktiv.Caption = "L aktiv";
            this.colAktiv.FieldName = "aktiv";
            this.colAktiv.Name = "colAktiv";
            this.colAktiv.Visible = true;
            this.colAktiv.VisibleIndex = 3;
            this.colAktiv.Width = 46;
            // 
            // edtVerwPeriodeBis
            // 
            this.edtVerwPeriodeBis.DataMember = "VerwPeriodeBis";
            this.edtVerwPeriodeBis.DataSource = this.qryBgPosition;
            this.edtVerwPeriodeBis.EditValue = null;
            this.edtVerwPeriodeBis.Location = new System.Drawing.Point(206, 146);
            this.edtVerwPeriodeBis.Name = "edtVerwPeriodeBis";
            this.edtVerwPeriodeBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVerwPeriodeBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVerwPeriodeBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVerwPeriodeBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVerwPeriodeBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerwPeriodeBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVerwPeriodeBis.Properties.Appearance.Options.UseFont = true;
            this.edtVerwPeriodeBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtVerwPeriodeBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVerwPeriodeBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtVerwPeriodeBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVerwPeriodeBis.Properties.ShowToday = false;
            this.edtVerwPeriodeBis.Size = new System.Drawing.Size(90, 24);
            this.edtVerwPeriodeBis.TabIndex = 6;
            // 
            // edtVerwPeriodeVon
            // 
            this.edtVerwPeriodeVon.DataMember = "VerwPeriodeVon";
            this.edtVerwPeriodeVon.DataSource = this.qryBgPosition;
            this.edtVerwPeriodeVon.EditValue = null;
            this.edtVerwPeriodeVon.Location = new System.Drawing.Point(102, 146);
            this.edtVerwPeriodeVon.Name = "edtVerwPeriodeVon";
            this.edtVerwPeriodeVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVerwPeriodeVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVerwPeriodeVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVerwPeriodeVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVerwPeriodeVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerwPeriodeVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVerwPeriodeVon.Properties.Appearance.Options.UseFont = true;
            this.edtVerwPeriodeVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtVerwPeriodeVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVerwPeriodeVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtVerwPeriodeVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVerwPeriodeVon.Properties.ShowToday = false;
            this.edtVerwPeriodeVon.Size = new System.Drawing.Size(90, 24);
            this.edtVerwPeriodeVon.TabIndex = 5;
            // 
            // edtBaPersonID
            // 
            this.edtBaPersonID.DataMember = "BaPersonID";
            this.edtBaPersonID.DataSource = this.qryBgPosition;
            this.edtBaPersonID.Location = new System.Drawing.Point(101, 116);
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
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NameVorname")});
            this.edtBaPersonID.Properties.DisplayMember = "NameVorname";
            this.edtBaPersonID.Properties.NullText = "";
            this.edtBaPersonID.Properties.ShowFooter = false;
            this.edtBaPersonID.Properties.ShowHeader = false;
            this.edtBaPersonID.Properties.ValueMember = "BaPersonID";
            this.edtBaPersonID.Size = new System.Drawing.Size(317, 24);
            this.edtBaPersonID.TabIndex = 4;
            // 
            // edtBetrag
            // 
            this.edtBetrag.DataMember = "Betrag";
            this.edtBetrag.DataSource = this.qryBgPosition;
            this.edtBetrag.Location = new System.Drawing.Point(101, 86);
            this.edtBetrag.Name = "edtBetrag";
            this.edtBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBetrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Size = new System.Drawing.Size(100, 24);
            this.edtBetrag.TabIndex = 3;
            // 
            // lblKlient
            // 
            this.lblKlient.Location = new System.Drawing.Point(6, 5);
            this.lblKlient.Name = "lblKlient";
            this.lblKlient.Size = new System.Drawing.Size(90, 24);
            this.lblKlient.TabIndex = 2;
            this.lblKlient.Text = "Klient/in";
            this.lblKlient.UseCompatibleTextRendering = true;
            // 
            // edtBuchungstext
            // 
            this.edtBuchungstext.DataMember = "Buchungstext";
            this.edtBuchungstext.DataSource = this.qryBgPosition;
            this.edtBuchungstext.Location = new System.Drawing.Point(101, 56);
            this.edtBuchungstext.Name = "edtBuchungstext";
            this.edtBuchungstext.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBuchungstext.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchungstext.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchungstext.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchungstext.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchungstext.Properties.Appearance.Options.UseFont = true;
            this.edtBuchungstext.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBuchungstext.Size = new System.Drawing.Size(317, 24);
            this.edtBuchungstext.TabIndex = 2;
            // 
            // edtKostenart
            // 
            this.edtKostenart.DataMember = "Kostenart";
            this.edtKostenart.DataSource = this.qryBgPosition;
            this.edtKostenart.Location = new System.Drawing.Point(101, 34);
            this.edtKostenart.Name = "edtKostenart";
            this.edtKostenart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKostenart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKostenart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostenart.Properties.Appearance.Options.UseBackColor = true;
            this.edtKostenart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKostenart.Properties.Appearance.Options.UseFont = true;
            this.edtKostenart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtKostenart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.edtKostenart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKostenart.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtKostenart.Size = new System.Drawing.Size(317, 24);
            this.edtKostenart.TabIndex = 1;
            this.edtKostenart.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKostenart_UserModifiedFld);
            // 
            // edtKlient
            // 
            this.edtKlient.DataMember = "Klient";
            this.edtKlient.DataSource = this.qryBgPosition;
            this.edtKlient.Location = new System.Drawing.Point(102, 4);
            this.edtKlient.LookupSQL = "select null";
            this.edtKlient.Name = "edtKlient";
            this.edtKlient.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKlient.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKlient.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKlient.Properties.Appearance.Options.UseBackColor = true;
            this.edtKlient.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKlient.Properties.Appearance.Options.UseFont = true;
            this.edtKlient.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.edtKlient.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.edtKlient.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKlient.Properties.Name = "editMandant.Properties";
            this.edtKlient.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtKlient.Size = new System.Drawing.Size(253, 24);
            this.edtKlient.TabIndex = 0;
            this.edtKlient.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKlient_UserModifiedFld);
            // 
            // kissLabel15
            // 
            this.kissLabel15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kissLabel15.Location = new System.Drawing.Point(311, 321);
            this.kissLabel15.Name = "kissLabel15";
            this.kissLabel15.Size = new System.Drawing.Size(75, 24);
            this.kissLabel15.TabIndex = 297;
            this.kissLabel15.Text = "Anzahl Belege";
            this.kissLabel15.UseCompatibleTextRendering = true;
            // 
            // kissLabel14
            // 
            this.kissLabel14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kissLabel14.Location = new System.Drawing.Point(471, 321);
            this.kissLabel14.Name = "kissLabel14";
            this.kissLabel14.Size = new System.Drawing.Size(68, 24);
            this.kissLabel14.TabIndex = 298;
            this.kissLabel14.Text = "Betragstotal";
            this.kissLabel14.UseCompatibleTextRendering = true;
            // 
            // edtTotal
            // 
            this.edtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtTotal.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtTotal.Location = new System.Drawing.Point(544, 321);
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
            this.edtTotal.Properties.DisplayFormat.FormatString = "n2";
            this.edtTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtTotal.Properties.ReadOnly = true;
            this.edtTotal.Size = new System.Drawing.Size(100, 24);
            this.edtTotal.TabIndex = 299;
            // 
            // edtAnzahl
            // 
            this.edtAnzahl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAnzahl.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAnzahl.Location = new System.Drawing.Point(392, 321);
            this.edtAnzahl.Name = "edtAnzahl";
            this.edtAnzahl.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAnzahl.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAnzahl.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAnzahl.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnzahl.Properties.Appearance.Options.UseBackColor = true;
            this.edtAnzahl.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAnzahl.Properties.Appearance.Options.UseFont = true;
            this.edtAnzahl.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAnzahl.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAnzahl.Properties.DisplayFormat.FormatString = "n0";
            this.edtAnzahl.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtAnzahl.Properties.ReadOnly = true;
            this.edtAnzahl.Size = new System.Drawing.Size(73, 24);
            this.edtAnzahl.TabIndex = 300;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.Location = new System.Drawing.Point(109, 327);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 18);
            this.label1.TabIndex = 572;
            this.label1.Text = "Anzahl Datensätze:";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // lblRowCount
            // 
            this.lblRowCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRowCount.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblRowCount.Location = new System.Drawing.Point(216, 327);
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Size = new System.Drawing.Size(72, 15);
            this.lblRowCount.TabIndex = 573;
            this.lblRowCount.Text = "0";
            this.lblRowCount.UseCompatibleTextRendering = true;
            // 
            // FrmWhSollstellungen
            // 
            this.ActiveSQLQuery = this.qryBgPosition;
            this.ClientSize = new System.Drawing.Size(892, 670);
            this.Controls.Add(this.lblRowCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.edtAnzahl);
            this.Controls.Add(this.edtTotal);
            this.Controls.Add(this.kissLabel14);
            this.Controls.Add(this.kissLabel15);
            this.Controls.Add(this.tabBgPosition);
            this.Controls.Add(this.btnAlle);
            this.Controls.Add(this.btnKeine);
            this.Controls.Add(this.btnTransfer);
            this.Name = "FrmWhSollstellungen";
            this.Text = "WH Sollstellungen";
            this.Load += new System.EventHandler(this.FrmWhSollstellungen_Load);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.btnTransfer, 0);
            this.Controls.SetChildIndex(this.btnKeine, 0);
            this.Controls.SetChildIndex(this.btnAlle, 0);
            this.Controls.SetChildIndex(this.tabBgPosition, 0);
            this.Controls.SetChildIndex(this.kissLabel15, 0);
            this.Controls.SetChildIndex(this.kissLabel14, 0);
            this.Controls.SetChildIndex(this.edtTotal, 0);
            this.Controls.SetChildIndex(this.edtAnzahl, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblRowCount, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSollstellung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSollstellung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheErfassungMA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheErfassungVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheErfassung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheErfassungBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFallNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheValutaVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFaelligAmVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFaelligAmBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMitarbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheValutaBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInklNichtAbgetreteneEinnahmen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheZIPNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchePNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAHVNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKlient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKeepValues.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheSelectTop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVerfugbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLAList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWhSucheKlientX)).EndInit();
            this.tabBgPosition.ResumeLayout(false);
            this.tpgDokumente.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtDocument.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgDokumente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichwort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichwort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentTyp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokumentTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.tpgEinzelzahlung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblBetragEff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwaltungSD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlientID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFallNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFallNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSplittingCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSplittingCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgSplittingCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwPeriodeStrich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwPeriode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDebitor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValutaDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMonatsbudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDebitor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaelligAm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMonatsbudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryMonatsbudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwPeriodeBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwPeriodeVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnzahl.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissButton btnAdd;
        private KiSS4.Gui.KissButton btnAddAll;
        private KiSS4.Gui.KissButton btnAlle;
        private KiSS4.Gui.KissButton btnDocument;
        private KiSS4.Gui.KissButton btnKeine;
        private KiSS4.Gui.KissButton btnMonatsbudget;
        private KiSS4.Gui.KissButton btnPositionGrau;
        private KiSS4.Gui.KissButton btnPositionGruen;
        private KiSS4.Gui.KissButton btnRemove;
        private KiSS4.Gui.KissButton btnRemoveAll;
        private KiSS4.Gui.KissButton btnTransfer;
        private DevExpress.XtraGrid.Columns.GridColumn colAktiv;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungstext;
        private DevExpress.XtraGrid.Columns.GridColumn colDateCreation;
        private DevExpress.XtraGrid.Columns.GridColumn colDateLastSave;
        private DevExpress.XtraGrid.Columns.GridColumn colDebitor;
        private DevExpress.XtraGrid.Columns.GridColumn colDoc;
        private DevExpress.XtraGrid.Columns.GridColumn colDocTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colJahr;
        private DevExpress.XtraGrid.Columns.GridColumn colKOA;
        private DevExpress.XtraGrid.Columns.GridColumn colKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colM;
        private DevExpress.XtraGrid.Columns.GridColumn colMonat;
        private DevExpress.XtraGrid.Columns.GridColumn colPSCDBelegNr;
        private DevExpress.XtraGrid.Columns.GridColumn colPosStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colS;
        private DevExpress.XtraGrid.Columns.GridColumn colSelektion;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colStichwort;
        private DevExpress.XtraGrid.Columns.GridColumn colTage;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
        private DevExpress.XtraGrid.Columns.GridColumn colUserText;
        private DevExpress.XtraGrid.Columns.GridColumn colValuta;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Common.CtlErfassungMutation ctlErfassungMutation1;
        private KiSS4.Gui.KissCalcEdit edtAnzahl;
        private KiSS4.Gui.KissLookUpEdit edtBaPersonID;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private KiSS4.Gui.KissCalcEdit edtBetrag;
        private KiSS4.Gui.KissLookUpEdit edtBgSplittingCode;
        private KiSS4.Gui.KissTextEdit edtBuchungstext;
        private KiSS4.Gui.KissButtonEdit edtDebitor;
        private KiSS4.Dokument.XDokument edtDocument;
        private KiSS4.Gui.KissLookUpEdit edtDokumentTyp;
        private KiSS4.Gui.KissDateEdit edtFaelligAm;
        private KiSS4.Gui.KissCalcEdit edtFallNr;
        private KiSS4.Gui.KissTextEdit edtFilter;
        private KiSS4.Gui.KissTextEdit edtFilter2;
        private KiSS4.Gui.KissCheckEdit edtInklNichtAbgetreteneEinnahmen;
        private KiSS4.Gui.KissCheckEdit edtKeepValues;
        private KiSS4.Gui.KissButtonEdit edtKlient;
        private KiSS4.Gui.KissTextEdit edtKlientID;
        private KiSS4.Gui.KissButtonEdit edtKostenart;
        private KiSS4.Gui.KissTextEdit edtLAList;
        private KiSS4.Gui.KissTextEdit edtStichwort;
        private KiSS4.Gui.KissTextEdit edtSucheAHVNr;
        private KiSS4.Gui.KissDateEdit edtSucheErfassungBis;
        private KiSS4.Gui.KissButtonEdit edtSucheErfassungMA;
        private KiSS4.Gui.KissDateEdit edtSucheErfassungVon;
        private KiSS4.Gui.KissDateEdit edtSucheFaelligAmBis;
        private KiSS4.Gui.KissDateEdit edtSucheFaelligAmVon;
        private KiSS4.Gui.KissCalcEdit edtSucheFallNr;
        private KiSS4.Gui.KissButtonEdit edtSucheKlient;
        private KiSS4.Gui.KissTextEdit edtSucheName;
        private KiSS4.Gui.KissCalcEdit edtSuchePNr;
        private KiSS4.Gui.KissCalcEdit edtSucheSelectTop;
        private KiSS4.Gui.KissImageComboBoxEdit edtSucheStatus;
        private KiSS4.Gui.KissTextEdit edtSucheVorname;
        private KiSS4.Gui.KissCalcEdit edtSucheZIPNr;
        private KiSS4.Gui.KissCalcEdit edtTotal;
        private KiSS4.Gui.KissDateEdit edtVerwPeriodeBis;
        private KiSS4.Gui.KissDateEdit edtVerwPeriodeVon;
        private KiSS4.Gui.KissCheckEdit edtVerwaltungSD;
        private KiSS4.Gui.KissMemoEdit edtZusatzInfo;
        private KiSS4.Gui.KissGrid grdDoc;
        private KiSS4.Gui.KissGrid grdMonatsbudget;
        private KiSS4.Gui.KissGrid grdSollstellung;
        private KiSS4.Gui.KissGrid grdVerfuegbar;
        private KiSS4.Gui.KissGrid grdZugeteilt;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView grvSollstellung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVerfugbar;
        private DevExpress.XtraGrid.Views.Grid.GridView grvZugeteilt;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel kissLabel10;
        private KiSS4.Gui.KissLabel kissLabel11;
        private KiSS4.Gui.KissLabel kissLabel12;
        private KiSS4.Gui.KissLabel kissLabel13;
        private KiSS4.Gui.KissLabel kissLabel14;
        private KiSS4.Gui.KissLabel kissLabel15;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissLabel kissLabel3;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel kissLabel6;
        private KiSS4.Gui.KissLabel kissLabel9;
        private System.Windows.Forms.Label label1;
        private KiSS4.Gui.KissLabel lblBaPersonID;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblBetrag;
        private KiSS4.Gui.KissLabel lblBetragEff;
        private KiSS4.Gui.KissLabel lblBgSplittingCode;
        private KiSS4.Gui.KissLabel lblBuchungstext;
        private KiSS4.Gui.KissLabel lblDebitor;
        private KiSS4.Gui.KissLabel lblDokument;
        private KiSS4.Gui.KissLabel lblDokumentTyp;
        private KiSS4.Gui.KissLabel lblFallNr;
        private KiSS4.Gui.KissLabel lblKlient;
        private KiSS4.Gui.KissLabel lblKostenart;
        private KiSS4.Gui.KissLabel lblLeistungsart;
        private KiSS4.Gui.KissLabel lblMonatsbudget;
        private System.Windows.Forms.Label lblRowCount;
        private KiSS4.Gui.KissLabel lblStichwort;
        private KiSS4.Gui.KissLabel lblSucheDatumBis;
        private KiSS4.Gui.KissLabel lblSucheDatumVon;
        private KiSS4.Gui.KissLabel lblSucheErfassung;
        private KiSS4.Gui.KissLabel lblSucheMitarbeiter;
        private KiSS4.Gui.KissLabel lblSucheStatus;
        private KiSS4.Gui.KissLabel lblSucheValutaBis;
        private KiSS4.Gui.KissLabel lblSucheValutaVon;
        private KiSS4.Gui.KissLabel lblValutaDatum;
        private KiSS4.Gui.KissLabel lblVerwPeriode;
        private KiSS4.Gui.KissLabel lblVerwPeriodeStrich;
        private KiSS4.Gui.KissLabel lblWhSucheKlientX;
        private KiSS4.DB.SqlQuery qryBgDokumente;
        private KiSS4.DB.SqlQuery qryBgPosition;
        private KiSS4.DB.SqlQuery qryMonatsbudget;
        private KiSS4.DB.SqlQuery qryVerfuegbar;
        private KiSS4.DB.SqlQuery qryZugeteilt;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private KiSS4.Gui.KissTabControlEx tabBgPosition;
        private SharpLibrary.WinControls.TabPageEx tpgDokumente;
        private SharpLibrary.WinControls.TabPageEx tpgEinzelzahlung;
    }
}
