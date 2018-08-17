namespace KiSS4.Fibu
{
    partial class CtlFibuDauerauftrag
    {
        private System.ComponentModel.IContainer components;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFibuDauerauftrag));
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
            this.gridViewMasks = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colItemMandant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeleg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoll = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHaben = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.qryFbDauerauftrag = new KiSS4.DB.SqlQuery(this.components);
            this.xTabControl2 = new KiSS4.Gui.KissTabControlEx();
            this.tabDauerauftrag = new SharpLibrary.WinControls.TabPageEx();
            this.chkVorWochenende = new KiSS4.Gui.KissCheckEdit();
            this.panMonatstag = new System.Windows.Forms.Panel();
            this.edtMonatstag2 = new KiSS4.Gui.KissCalcEdit();
            this.lblMonatstag = new KiSS4.Gui.KissLabel();
            this.edtMonatstag1 = new KiSS4.Gui.KissCalcEdit();
            this.panWochentagListe = new System.Windows.Forms.Panel();
            this.lblWochentag = new KiSS4.Gui.KissLabel();
            this.edtWochentag = new KiSS4.Gui.KissLookUpEdit();
            this.edtDummyTabCorrection = new KiSS4.Gui.KissLookUpEdit();
            this.lblDauerauftrag = new KiSS4.Gui.KissTextEdit();
            this.lblDANr = new KiSS4.Gui.KissLabel();
            this.lblDokument = new KiSS4.Gui.KissLabel();
            this.edtDauerauftrag = new KiSS4.Dokument.XDokument();
            this.edtText = new KiSS4.Gui.KissTextEdit();
            this.lblText = new KiSS4.Gui.KissLabel();
            this.edtSollKontoNr = new KiSS4.Gui.KissButtonEdit();
            this.edtHabenName = new KiSS4.Gui.KissTextEdit();
            this.editSollName = new KiSS4.Gui.KissTextEdit();
            this.edtHabenKontoNr = new KiSS4.Gui.KissButtonEdit();
            this.edtPeriodizitaetCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblGueltigBis = new KiSS4.Gui.KissLabel();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblPeriodizitaet = new KiSS4.Gui.KissLabel();
            this.lblGueltigVon = new KiSS4.Gui.KissLabel();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtMandant = new KiSS4.Gui.KissButtonEdit();
            this.lblMandantNr = new KiSS4.Gui.KissTextEdit();
            this.edtBetrag = new KiSS4.Gui.KissCalcEdit();
            this.lblPlzOrt = new KiSS4.Gui.KissTextEdit();
            this.lblBetrag = new KiSS4.Gui.KissLabel();
            this.lblHaben = new KiSS4.Gui.KissLabel();
            this.lblSoll = new KiSS4.Gui.KissLabel();
            this.lblMandant = new KiSS4.Gui.KissLabel();
            this.tabKreditor = new SharpLibrary.WinControls.TabPageEx();
            this.ctlFibuZahlungsWeg = new KiSS4.Fibu.CtlFibuZahlungsWeg();
            this.lblKreditor = new KiSS4.Gui.KissLabel();
            this.grdFbDauerauftrag = new KiSS4.Gui.KissGrid();
            this.grvFbDauerauftrag = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colListeMandant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListeSoll = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListeHaben = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListeText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListeBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListePeriodizitaet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListeStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListeLetzteAusfuehrung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListeTeam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtNurAktiveX = new KiSS4.Gui.KissCheckEdit();
            this.kissSearchTitel1 = new KiSS4.Gui.KissSearchTitel();
            this.edtTeamX = new KiSS4.Gui.KissLookUpEdit();
            this.editTeam = new KiSS4.Gui.KissLookUpEdit();
            this.lblSuchenTeam = new KiSS4.Gui.KissLabel();
            this.edtDatumVonX = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBisX = new KiSS4.Gui.KissDateEdit();
            this.lblSuchenPeriodizitaet = new KiSS4.Gui.KissLabel();
            this.lblSuchenText = new KiSS4.Gui.KissLabel();
            this.edtTextX = new KiSS4.Gui.KissButtonEdit();
            this.edtHabenX = new KiSS4.Gui.KissCalcEdit();
            this.edtSollX = new KiSS4.Gui.KissCalcEdit();
            this.edtPeriodizitaetX = new KiSS4.Gui.KissLookUpEdit();
            this.lblSuchenDatumBis = new KiSS4.Gui.KissLabel();
            this.lblSuchenDatumVon = new KiSS4.Gui.KissLabel();
            this.edtMandantX = new KiSS4.Gui.KissButtonEdit();
            this.lblSuchenHaben = new KiSS4.Gui.KissLabel();
            this.lblSuchenSoll = new KiSS4.Gui.KissLabel();
            this.lblSuchenMandant = new KiSS4.Gui.KissLabel();
            this.panDauerauftraegeAusfuehren = new System.Windows.Forms.Panel();
            this.btnDaAusfuehren = new KiSS4.Gui.KissButton();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMasks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFbDauerauftrag)).BeginInit();
            this.xTabControl2.SuspendLayout();
            this.tabDauerauftrag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkVorWochenende.Properties)).BeginInit();
            this.panMonatstag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtMonatstag2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMonatstag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMonatstag1.Properties)).BeginInit();
            this.panWochentagListe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblWochentag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWochentag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWochentag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDummyTabCorrection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDummyTabCorrection.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDauerauftrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDANr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDauerauftrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollKontoNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHabenName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editSollName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHabenKontoNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPeriodizitaetCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPeriodizitaetCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGueltigBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPeriodizitaet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGueltigVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMandant.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandantNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPlzOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHaben)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandant)).BeginInit();
            this.tabKreditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFbDauerauftrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFbDauerauftrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurAktiveX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTeamX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTeamX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTeam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTeam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenTeam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVonX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBisX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenPeriodizitaet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTextX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHabenX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPeriodizitaetX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPeriodizitaetX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMandantX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenHaben)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenSoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenMandant)).BeginInit();
            this.panDauerauftraegeAusfuehren.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(708, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSearch.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(866, 261);
            this.tabControlSearch.TabIndex = 333;
            this.tabControlSearch.TabStop = false;
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdFbDauerauftrag);
            this.tpgListe.Size = new System.Drawing.Size(854, 223);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtNurAktiveX);
            this.tpgSuchen.Controls.Add(this.kissSearchTitel1);
            this.tpgSuchen.Controls.Add(this.edtTeamX);
            this.tpgSuchen.Controls.Add(this.editTeam);
            this.tpgSuchen.Controls.Add(this.lblSuchenTeam);
            this.tpgSuchen.Controls.Add(this.edtDatumVonX);
            this.tpgSuchen.Controls.Add(this.edtDatumBisX);
            this.tpgSuchen.Controls.Add(this.lblSuchenPeriodizitaet);
            this.tpgSuchen.Controls.Add(this.lblSuchenText);
            this.tpgSuchen.Controls.Add(this.edtTextX);
            this.tpgSuchen.Controls.Add(this.edtHabenX);
            this.tpgSuchen.Controls.Add(this.edtSollX);
            this.tpgSuchen.Controls.Add(this.edtPeriodizitaetX);
            this.tpgSuchen.Controls.Add(this.lblSuchenDatumBis);
            this.tpgSuchen.Controls.Add(this.lblSuchenDatumVon);
            this.tpgSuchen.Controls.Add(this.edtMandantX);
            this.tpgSuchen.Controls.Add(this.lblSuchenHaben);
            this.tpgSuchen.Controls.Add(this.lblSuchenSoll);
            this.tpgSuchen.Controls.Add(this.lblSuchenMandant);
            this.tpgSuchen.Size = new System.Drawing.Size(854, 223);
            this.tpgSuchen.Title = "Suchen";
            this.tpgSuchen.Controls.SetChildIndex(this.lblSuchenMandant, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSuchenSoll, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSuchenHaben, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtMandantX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSuchenDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSuchenDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtPeriodizitaetX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSollX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtHabenX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtTextX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSuchenText, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSuchenPeriodizitaet, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumBisX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumVonX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSuchenTeam, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.editTeam, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtTeamX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissSearchTitel1, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNurAktiveX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            // 
            // gridViewMasks
            // 
            this.gridViewMasks.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colItemMandant,
            this.colBeleg,
            this.colDatum,
            this.colSoll,
            this.colHaben,
            this.colText,
            this.colBetrag});
            this.gridViewMasks.Name = "gridViewMasks";
            this.gridViewMasks.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridViewMasks.OptionsBehavior.Editable = false;
            this.gridViewMasks.OptionsCustomization.AllowFilter = false;
            this.gridViewMasks.OptionsCustomization.AllowGroup = false;
            this.gridViewMasks.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewMasks.OptionsNavigation.AutoMoveRowFocus = false;
            this.gridViewMasks.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewMasks.OptionsNavigation.UseTabKey = false;
            this.gridViewMasks.OptionsPrint.AutoWidth = false;
            this.gridViewMasks.OptionsPrint.UsePrintStyles = true;
            this.gridViewMasks.OptionsView.ColumnAutoWidth = false;
            this.gridViewMasks.OptionsView.ShowDetailButtons = false;
            this.gridViewMasks.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridViewMasks.OptionsView.ShowGroupPanel = false;
            this.gridViewMasks.OptionsView.ShowIndicator = false;
            this.gridViewMasks.ViewStyles.AddReplace("FocusedCell", "FocusedRow");
            this.gridViewMasks.ViewStyles.AddReplace("SelectedRow", "Row");
            this.gridViewMasks.ViewStyles.AddReplace("HideSelectionRow", "SelectedRow");
            // 
            // colItemMandant
            // 
            this.colItemMandant.Caption = "Mandant";
            this.colItemMandant.FieldName = "Mandant";
            this.colItemMandant.Name = "colItemMandant";
            this.colItemMandant.Visible = true;
            this.colItemMandant.VisibleIndex = 0;
            this.colItemMandant.Width = 147;
            // 
            // colBeleg
            // 
            this.colBeleg.Caption = "Beleg";
            this.colBeleg.FieldName = "BelegNr";
            this.colBeleg.Name = "colBeleg";
            this.colBeleg.Visible = true;
            this.colBeleg.VisibleIndex = 1;
            this.colBeleg.Width = 70;
            // 
            // colDatum
            // 
            this.colDatum.Caption = "Datum";
            this.colDatum.FieldName = "DatumBuchung";
            this.colDatum.Name = "colDatum";
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 2;
            this.colDatum.Width = 92;
            // 
            // colSoll
            // 
            this.colSoll.Caption = "Soll";
            this.colSoll.FieldName = "KontoNrS";
            this.colSoll.Name = "colSoll";
            this.colSoll.Visible = true;
            this.colSoll.VisibleIndex = 3;
            this.colSoll.Width = 56;
            // 
            // colHaben
            // 
            this.colHaben.Caption = "Haben";
            this.colHaben.FieldName = "KontoNrH";
            this.colHaben.Name = "colHaben";
            this.colHaben.Visible = true;
            this.colHaben.VisibleIndex = 4;
            this.colHaben.Width = 57;
            // 
            // colText
            // 
            this.colText.Caption = "Text";
            this.colText.FieldName = "Text";
            this.colText.Name = "colText";
            this.colText.Visible = true;
            this.colText.VisibleIndex = 5;
            this.colText.Width = 230;
            // 
            // colBetrag
            // 
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "N";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 6;
            this.colBetrag.Width = 109;
            // 
            // qryFbDauerauftrag
            // 
            this.qryFbDauerauftrag.CanDelete = true;
            this.qryFbDauerauftrag.CanInsert = true;
            this.qryFbDauerauftrag.CanUpdate = true;
            this.qryFbDauerauftrag.HostControl = this;
            this.qryFbDauerauftrag.SelectStatement = resources.GetString("qryFbDauerauftrag.SelectStatement");
            this.qryFbDauerauftrag.TableName = "FbDauerauftrag";
            this.qryFbDauerauftrag.AfterInsert += new System.EventHandler(this.qryFbDauerauftrag_AfterInsert);
            this.qryFbDauerauftrag.AfterPost += new System.EventHandler(this.qryFbDauerauftrag_AfterPost);
            this.qryFbDauerauftrag.BeforePost += new System.EventHandler(this.qryFbDauerauftrag_BeforePost);
            this.qryFbDauerauftrag.PositionChanged += new System.EventHandler(this.qryFbDauerauftrag_PositionChanged);
            // 
            // xTabControl2
            // 
            this.xTabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xTabControl2.Controls.Add(this.tabDauerauftrag);
            this.xTabControl2.Controls.Add(this.tabKreditor);
            this.xTabControl2.Cursor = System.Windows.Forms.Cursors.Default;
            this.xTabControl2.Location = new System.Drawing.Point(0, 261);
            this.xTabControl2.Name = "xTabControl2";
            this.xTabControl2.ShowFixedWidthTooltip = true;
            this.xTabControl2.Size = new System.Drawing.Size(866, 268);
            this.xTabControl2.TabIndex = 334;
            this.xTabControl2.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tabDauerauftrag,
            this.tabKreditor});
            this.xTabControl2.TabsLineColor = System.Drawing.Color.Black;
            this.xTabControl2.TabsLocation = SharpLibrary.WinControls.TabsLocation.Top;
            this.xTabControl2.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.xTabControl2.TabStop = false;
            this.xTabControl2.Text = "xTabControl2";
            // 
            // tabDauerauftrag
            // 
            this.tabDauerauftrag.Controls.Add(this.chkVorWochenende);
            this.tabDauerauftrag.Controls.Add(this.panMonatstag);
            this.tabDauerauftrag.Controls.Add(this.panWochentagListe);
            this.tabDauerauftrag.Controls.Add(this.edtDummyTabCorrection);
            this.tabDauerauftrag.Controls.Add(this.lblDauerauftrag);
            this.tabDauerauftrag.Controls.Add(this.lblDANr);
            this.tabDauerauftrag.Controls.Add(this.lblDokument);
            this.tabDauerauftrag.Controls.Add(this.edtDauerauftrag);
            this.tabDauerauftrag.Controls.Add(this.edtText);
            this.tabDauerauftrag.Controls.Add(this.lblText);
            this.tabDauerauftrag.Controls.Add(this.edtSollKontoNr);
            this.tabDauerauftrag.Controls.Add(this.edtHabenName);
            this.tabDauerauftrag.Controls.Add(this.editSollName);
            this.tabDauerauftrag.Controls.Add(this.edtHabenKontoNr);
            this.tabDauerauftrag.Controls.Add(this.edtPeriodizitaetCode);
            this.tabDauerauftrag.Controls.Add(this.lblGueltigBis);
            this.tabDauerauftrag.Controls.Add(this.edtDatumBis);
            this.tabDauerauftrag.Controls.Add(this.lblPeriodizitaet);
            this.tabDauerauftrag.Controls.Add(this.lblGueltigVon);
            this.tabDauerauftrag.Controls.Add(this.edtDatumVon);
            this.tabDauerauftrag.Controls.Add(this.edtMandant);
            this.tabDauerauftrag.Controls.Add(this.lblMandantNr);
            this.tabDauerauftrag.Controls.Add(this.edtBetrag);
            this.tabDauerauftrag.Controls.Add(this.lblPlzOrt);
            this.tabDauerauftrag.Controls.Add(this.lblBetrag);
            this.tabDauerauftrag.Controls.Add(this.lblHaben);
            this.tabDauerauftrag.Controls.Add(this.lblSoll);
            this.tabDauerauftrag.Controls.Add(this.lblMandant);
            this.tabDauerauftrag.Location = new System.Drawing.Point(6, 32);
            this.tabDauerauftrag.Name = "tabDauerauftrag";
            this.tabDauerauftrag.Size = new System.Drawing.Size(854, 230);
            this.tabDauerauftrag.TabIndex = 0;
            this.tabDauerauftrag.Title = "Dauerauftrag";
            // 
            // chkVorWochenende
            // 
            this.chkVorWochenende.DataMember = "VorWochenende";
            this.chkVorWochenende.DataSource = this.qryFbDauerauftrag;
            this.chkVorWochenende.Location = new System.Drawing.Point(611, 140);
            this.chkVorWochenende.Name = "chkVorWochenende";
            this.chkVorWochenende.Properties.Caption = "Vor Wochenende";
            this.chkVorWochenende.Size = new System.Drawing.Size(133, 19);
            this.chkVorWochenende.TabIndex = 24;
            // 
            // panMonatstag
            // 
            this.panMonatstag.Controls.Add(this.edtMonatstag2);
            this.panMonatstag.Controls.Add(this.lblMonatstag);
            this.panMonatstag.Controls.Add(this.edtMonatstag1);
            this.panMonatstag.Location = new System.Drawing.Point(528, 106);
            this.panMonatstag.Name = "panMonatstag";
            this.panMonatstag.Size = new System.Drawing.Size(286, 25);
            this.panMonatstag.TabIndex = 23;
            this.panMonatstag.Visible = false;
            // 
            // edtMonatstag2
            // 
            this.edtMonatstag2.DataMember = "Monatstag2";
            this.edtMonatstag2.DataSource = this.qryFbDauerauftrag;
            this.edtMonatstag2.Location = new System.Drawing.Point(155, 0);
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
            // 
            // lblMonatstag
            // 
            this.lblMonatstag.ForeColor = System.Drawing.Color.Black;
            this.lblMonatstag.Location = new System.Drawing.Point(-3, 0);
            this.lblMonatstag.Name = "lblMonatstag";
            this.lblMonatstag.Size = new System.Drawing.Size(80, 24);
            this.lblMonatstag.TabIndex = 0;
            this.lblMonatstag.Text = "Monatstag(e)";
            // 
            // edtMonatstag1
            // 
            this.edtMonatstag1.DataMember = "Monatstag1";
            this.edtMonatstag1.DataSource = this.qryFbDauerauftrag;
            this.edtMonatstag1.Location = new System.Drawing.Point(83, 0);
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
            // 
            // panWochentagListe
            // 
            this.panWochentagListe.Controls.Add(this.lblWochentag);
            this.panWochentagListe.Controls.Add(this.edtWochentag);
            this.panWochentagListe.Location = new System.Drawing.Point(528, 106);
            this.panWochentagListe.Name = "panWochentagListe";
            this.panWochentagListe.Size = new System.Drawing.Size(286, 25);
            this.panWochentagListe.TabIndex = 23;
            this.panWochentagListe.Visible = false;
            // 
            // lblWochentag
            // 
            this.lblWochentag.ForeColor = System.Drawing.Color.Black;
            this.lblWochentag.Location = new System.Drawing.Point(0, 0);
            this.lblWochentag.Name = "lblWochentag";
            this.lblWochentag.Size = new System.Drawing.Size(80, 24);
            this.lblWochentag.TabIndex = 0;
            this.lblWochentag.Text = "Wochentag";
            // 
            // edtWochentag
            // 
            this.edtWochentag.AllowNull = false;
            this.edtWochentag.DataMember = "WochentagCode";
            this.edtWochentag.DataSource = this.qryFbDauerauftrag;
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
            this.edtWochentag.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
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
            this.edtWochentag.Size = new System.Drawing.Size(133, 24);
            this.edtWochentag.TabIndex = 1;
            // 
            // edtDummyTabCorrection
            // 
            this.edtDummyTabCorrection.Enabled = false;
            this.edtDummyTabCorrection.Location = new System.Drawing.Point(405, 136);
            this.edtDummyTabCorrection.Name = "edtDummyTabCorrection";
            this.edtDummyTabCorrection.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDummyTabCorrection.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDummyTabCorrection.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDummyTabCorrection.Properties.Appearance.Options.UseBackColor = true;
            this.edtDummyTabCorrection.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDummyTabCorrection.Properties.Appearance.Options.UseFont = true;
            this.edtDummyTabCorrection.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtDummyTabCorrection.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtDummyTabCorrection.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtDummyTabCorrection.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtDummyTabCorrection.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtDummyTabCorrection.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtDummyTabCorrection.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDummyTabCorrection.Properties.NullText = "";
            this.edtDummyTabCorrection.Properties.ShowFooter = false;
            this.edtDummyTabCorrection.Properties.ShowHeader = false;
            this.edtDummyTabCorrection.Size = new System.Drawing.Size(100, 24);
            this.edtDummyTabCorrection.TabIndex = 14;
            this.edtDummyTabCorrection.TabStop = false;
            this.edtDummyTabCorrection.Visible = false;
            // 
            // lblDauerauftrag
            // 
            this.lblDauerauftrag.DataMember = "FbDauerauftragID";
            this.lblDauerauftrag.DataSource = this.qryFbDauerauftrag;
            this.lblDauerauftrag.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.lblDauerauftrag.Location = new System.Drawing.Point(97, 16);
            this.lblDauerauftrag.Name = "lblDauerauftrag";
            this.lblDauerauftrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblDauerauftrag.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblDauerauftrag.Properties.Appearance.Options.UseFont = true;
            this.lblDauerauftrag.Properties.Appearance.Options.UseForeColor = true;
            this.lblDauerauftrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.lblDauerauftrag.Properties.ReadOnly = true;
            this.lblDauerauftrag.Size = new System.Drawing.Size(104, 24);
            this.lblDauerauftrag.TabIndex = 1;
            this.lblDauerauftrag.TabStop = false;
            // 
            // lblDANr
            // 
            this.lblDANr.ForeColor = System.Drawing.Color.Black;
            this.lblDANr.Location = new System.Drawing.Point(12, 16);
            this.lblDANr.Name = "lblDANr";
            this.lblDANr.Size = new System.Drawing.Size(79, 24);
            this.lblDANr.TabIndex = 0;
            this.lblDANr.Text = "DA-Nr";
            // 
            // lblDokument
            // 
            this.lblDokument.Location = new System.Drawing.Point(528, 166);
            this.lblDokument.Name = "lblDokument";
            this.lblDokument.Size = new System.Drawing.Size(80, 24);
            this.lblDokument.TabIndex = 25;
            this.lblDokument.Text = "Dokument";
            // 
            // edtDauerauftrag
            // 
            this.edtDauerauftrag.Context = "FbDauerauftrag";
            this.edtDauerauftrag.DataMember = "DauerauftragDokID";
            this.edtDauerauftrag.DataSource = this.qryFbDauerauftrag;
            this.edtDauerauftrag.Location = new System.Drawing.Point(612, 166);
            this.edtDauerauftrag.Name = "edtDauerauftrag";
            this.edtDauerauftrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDauerauftrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDauerauftrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDauerauftrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtDauerauftrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDauerauftrag.Properties.Appearance.Options.UseFont = true;
            this.edtDauerauftrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtDauerauftrag.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDauerauftrag.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDauerauftrag.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDauerauftrag.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDauerauftrag.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "Dokument importieren")});
            this.edtDauerauftrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDauerauftrag.Properties.ReadOnly = true;
            this.edtDauerauftrag.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtDauerauftrag.Size = new System.Drawing.Size(132, 24);
            this.edtDauerauftrag.TabIndex = 26;
            // 
            // edtText
            // 
            this.edtText.DataMember = "Text";
            this.edtText.DataSource = this.qryFbDauerauftrag;
            this.edtText.Location = new System.Drawing.Point(97, 166);
            this.edtText.Name = "edtText";
            this.edtText.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtText.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtText.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtText.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtText.Properties.Appearance.Options.UseBackColor = true;
            this.edtText.Properties.Appearance.Options.UseBorderColor = true;
            this.edtText.Properties.Appearance.Options.UseFont = true;
            this.edtText.Properties.Appearance.Options.UseForeColor = true;
            this.edtText.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtText.Size = new System.Drawing.Size(409, 24);
            this.edtText.TabIndex = 16;
            // 
            // lblText
            // 
            this.lblText.ForeColor = System.Drawing.Color.Black;
            this.lblText.Location = new System.Drawing.Point(12, 166);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(79, 24);
            this.lblText.TabIndex = 15;
            this.lblText.Text = "Buchungstext";
            // 
            // edtSollKontoNr
            // 
            this.edtSollKontoNr.DataMember = "SollKtoNr";
            this.edtSollKontoNr.DataSource = this.qryFbDauerauftrag;
            this.edtSollKontoNr.Location = new System.Drawing.Point(97, 76);
            this.edtSollKontoNr.Name = "edtSollKontoNr";
            this.edtSollKontoNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSollKontoNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSollKontoNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSollKontoNr.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtSollKontoNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSollKontoNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSollKontoNr.Properties.Appearance.Options.UseFont = true;
            this.edtSollKontoNr.Properties.Appearance.Options.UseForeColor = true;
            this.edtSollKontoNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtSollKontoNr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtSollKontoNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSollKontoNr.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSollKontoNr.Size = new System.Drawing.Size(90, 24);
            this.edtSollKontoNr.TabIndex = 7;
            this.edtSollKontoNr.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSollKontoNr_UserModifiedFld);
            // 
            // edtHabenName
            // 
            this.edtHabenName.DataMember = "HabenKtoName";
            this.edtHabenName.DataSource = this.qryFbDauerauftrag;
            this.edtHabenName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtHabenName.Location = new System.Drawing.Point(193, 106);
            this.edtHabenName.Name = "edtHabenName";
            this.edtHabenName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHabenName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHabenName.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtHabenName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHabenName.Properties.Appearance.Options.UseFont = true;
            this.edtHabenName.Properties.Appearance.Options.UseForeColor = true;
            this.edtHabenName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHabenName.Properties.ReadOnly = true;
            this.edtHabenName.Size = new System.Drawing.Size(312, 24);
            this.edtHabenName.TabIndex = 11;
            this.edtHabenName.TabStop = false;
            // 
            // editSollName
            // 
            this.editSollName.DataMember = "SollKtoName";
            this.editSollName.DataSource = this.qryFbDauerauftrag;
            this.editSollName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editSollName.Location = new System.Drawing.Point(193, 76);
            this.editSollName.Name = "editSollName";
            this.editSollName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editSollName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editSollName.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.editSollName.Properties.Appearance.Options.UseBorderColor = true;
            this.editSollName.Properties.Appearance.Options.UseFont = true;
            this.editSollName.Properties.Appearance.Options.UseForeColor = true;
            this.editSollName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editSollName.Properties.ReadOnly = true;
            this.editSollName.Size = new System.Drawing.Size(312, 24);
            this.editSollName.TabIndex = 8;
            this.editSollName.TabStop = false;
            // 
            // edtHabenKontoNr
            // 
            this.edtHabenKontoNr.DataMember = "HabenKtoNr";
            this.edtHabenKontoNr.DataSource = this.qryFbDauerauftrag;
            this.edtHabenKontoNr.Location = new System.Drawing.Point(97, 106);
            this.edtHabenKontoNr.Name = "edtHabenKontoNr";
            this.edtHabenKontoNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtHabenKontoNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHabenKontoNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHabenKontoNr.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtHabenKontoNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtHabenKontoNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHabenKontoNr.Properties.Appearance.Options.UseFont = true;
            this.edtHabenKontoNr.Properties.Appearance.Options.UseForeColor = true;
            this.edtHabenKontoNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtHabenKontoNr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtHabenKontoNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtHabenKontoNr.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtHabenKontoNr.Size = new System.Drawing.Size(90, 24);
            this.edtHabenKontoNr.TabIndex = 10;
            this.edtHabenKontoNr.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtHabenKontoNr_UserModifiedFld);
            // 
            // edtPeriodizitaetCode
            // 
            this.edtPeriodizitaetCode.DataMember = "PeriodizitaetCode";
            this.edtPeriodizitaetCode.DataSource = this.qryFbDauerauftrag;
            this.edtPeriodizitaetCode.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPeriodizitaetCode.Location = new System.Drawing.Point(612, 76);
            this.edtPeriodizitaetCode.LOVName = "ZahlungsPeriode";
            this.edtPeriodizitaetCode.Name = "edtPeriodizitaetCode";
            this.edtPeriodizitaetCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPeriodizitaetCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPeriodizitaetCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPeriodizitaetCode.Properties.Appearance.Options.UseFont = true;
            this.edtPeriodizitaetCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtPeriodizitaetCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtPeriodizitaetCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtPeriodizitaetCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtPeriodizitaetCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPeriodizitaetCode.Properties.NullText = "";
            this.edtPeriodizitaetCode.Properties.ReadOnly = true;
            this.edtPeriodizitaetCode.Properties.ShowFooter = false;
            this.edtPeriodizitaetCode.Properties.ShowHeader = false;
            this.edtPeriodizitaetCode.Size = new System.Drawing.Size(132, 24);
            this.edtPeriodizitaetCode.TabIndex = 22;
            this.edtPeriodizitaetCode.EditValueChanged += new System.EventHandler(this.cboPeriodizitaet_EditValueChanged);
            // 
            // lblGueltigBis
            // 
            this.lblGueltigBis.ForeColor = System.Drawing.Color.Black;
            this.lblGueltigBis.Location = new System.Drawing.Point(528, 46);
            this.lblGueltigBis.Name = "lblGueltigBis";
            this.lblGueltigBis.Size = new System.Drawing.Size(80, 24);
            this.lblGueltigBis.TabIndex = 19;
            this.lblGueltigBis.Text = "Gültig bis";
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.DataMember = "DatumBis";
            this.edtDatumBis.DataSource = this.qryFbDauerauftrag;
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(612, 46);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(132, 24);
            this.edtDatumBis.TabIndex = 20;
            // 
            // lblPeriodizitaet
            // 
            this.lblPeriodizitaet.ForeColor = System.Drawing.Color.Black;
            this.lblPeriodizitaet.Location = new System.Drawing.Point(528, 76);
            this.lblPeriodizitaet.Name = "lblPeriodizitaet";
            this.lblPeriodizitaet.Size = new System.Drawing.Size(80, 24);
            this.lblPeriodizitaet.TabIndex = 21;
            this.lblPeriodizitaet.Text = "Periodizität";
            // 
            // lblGueltigVon
            // 
            this.lblGueltigVon.ForeColor = System.Drawing.Color.Black;
            this.lblGueltigVon.Location = new System.Drawing.Point(528, 16);
            this.lblGueltigVon.Name = "lblGueltigVon";
            this.lblGueltigVon.Size = new System.Drawing.Size(80, 24);
            this.lblGueltigVon.TabIndex = 17;
            this.lblGueltigVon.Text = "Gültig von";
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.DataMember = "DatumVon";
            this.edtDatumVon.DataSource = this.qryFbDauerauftrag;
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(612, 16);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(132, 24);
            this.edtDatumVon.TabIndex = 18;
            // 
            // edtMandant
            // 
            this.edtMandant.DataMember = "Mandant";
            this.edtMandant.DataSource = this.qryFbDauerauftrag;
            this.edtMandant.Location = new System.Drawing.Point(97, 46);
            this.edtMandant.Name = "edtMandant";
            this.edtMandant.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMandant.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMandant.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMandant.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtMandant.Properties.Appearance.Options.UseBackColor = true;
            this.edtMandant.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMandant.Properties.Appearance.Options.UseFont = true;
            this.edtMandant.Properties.Appearance.Options.UseForeColor = true;
            this.edtMandant.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.edtMandant.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.edtMandant.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtMandant.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtMandant.Size = new System.Drawing.Size(205, 24);
            this.edtMandant.TabIndex = 3;
            this.edtMandant.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtMandant_UserModifiedFld);
            // 
            // lblMandantNr
            // 
            this.lblMandantNr.DataMember = "BaPersonID";
            this.lblMandantNr.DataSource = this.qryFbDauerauftrag;
            this.lblMandantNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.lblMandantNr.Location = new System.Drawing.Point(306, 46);
            this.lblMandantNr.Name = "lblMandantNr";
            this.lblMandantNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.lblMandantNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblMandantNr.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblMandantNr.Properties.Appearance.Options.UseBorderColor = true;
            this.lblMandantNr.Properties.Appearance.Options.UseFont = true;
            this.lblMandantNr.Properties.Appearance.Options.UseForeColor = true;
            this.lblMandantNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.lblMandantNr.Properties.ReadOnly = true;
            this.lblMandantNr.Size = new System.Drawing.Size(57, 24);
            this.lblMandantNr.TabIndex = 4;
            this.lblMandantNr.TabStop = false;
            // 
            // edtBetrag
            // 
            this.edtBetrag.DataMember = "Betrag";
            this.edtBetrag.DataSource = this.qryFbDauerauftrag;
            this.edtBetrag.Location = new System.Drawing.Point(97, 136);
            this.edtBetrag.Name = "edtBetrag";
            this.edtBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBetrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
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
            this.edtBetrag.TabIndex = 13;
            // 
            // lblPlzOrt
            // 
            this.lblPlzOrt.DataMember = "PlzOrt";
            this.lblPlzOrt.DataSource = this.qryFbDauerauftrag;
            this.lblPlzOrt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.lblPlzOrt.Location = new System.Drawing.Point(366, 46);
            this.lblPlzOrt.Name = "lblPlzOrt";
            this.lblPlzOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.lblPlzOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblPlzOrt.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblPlzOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.lblPlzOrt.Properties.Appearance.Options.UseFont = true;
            this.lblPlzOrt.Properties.Appearance.Options.UseForeColor = true;
            this.lblPlzOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.lblPlzOrt.Properties.ReadOnly = true;
            this.lblPlzOrt.Size = new System.Drawing.Size(140, 24);
            this.lblPlzOrt.TabIndex = 5;
            this.lblPlzOrt.TabStop = false;
            // 
            // lblBetrag
            // 
            this.lblBetrag.ForeColor = System.Drawing.Color.Black;
            this.lblBetrag.Location = new System.Drawing.Point(12, 136);
            this.lblBetrag.Name = "lblBetrag";
            this.lblBetrag.Size = new System.Drawing.Size(79, 24);
            this.lblBetrag.TabIndex = 12;
            this.lblBetrag.Text = "Betrag CHF";
            // 
            // lblHaben
            // 
            this.lblHaben.ForeColor = System.Drawing.Color.Black;
            this.lblHaben.Location = new System.Drawing.Point(12, 106);
            this.lblHaben.Name = "lblHaben";
            this.lblHaben.Size = new System.Drawing.Size(79, 24);
            this.lblHaben.TabIndex = 9;
            this.lblHaben.Text = "Haben";
            // 
            // lblSoll
            // 
            this.lblSoll.ForeColor = System.Drawing.Color.Black;
            this.lblSoll.Location = new System.Drawing.Point(12, 76);
            this.lblSoll.Name = "lblSoll";
            this.lblSoll.Size = new System.Drawing.Size(79, 24);
            this.lblSoll.TabIndex = 6;
            this.lblSoll.Text = "Soll";
            // 
            // lblMandant
            // 
            this.lblMandant.ForeColor = System.Drawing.Color.Black;
            this.lblMandant.Location = new System.Drawing.Point(12, 46);
            this.lblMandant.Name = "lblMandant";
            this.lblMandant.Size = new System.Drawing.Size(79, 24);
            this.lblMandant.TabIndex = 2;
            this.lblMandant.Text = "Mandant";
            // 
            // tabKreditor
            // 
            this.tabKreditor.Controls.Add(this.ctlFibuZahlungsWeg);
            this.tabKreditor.Controls.Add(this.lblKreditor);
            this.tabKreditor.Location = new System.Drawing.Point(6, 32);
            this.tabKreditor.Name = "tabKreditor";
            this.tabKreditor.Size = new System.Drawing.Size(854, 230);
            this.tabKreditor.TabIndex = 1;
            this.tabKreditor.Title = "Kreditor";
            // 
            // ctlFibuZahlungsWeg
            // 
            this.ctlFibuZahlungsWeg.BuchungStatus = KiSS4.Fibu.BuchungDTAStatus.Unbekannt;
            this.ctlFibuZahlungsWeg.DataSource = null;
            this.ctlFibuZahlungsWeg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlFibuZahlungsWeg.FbBuchungId = 0;
            this.ctlFibuZahlungsWeg.FbDauerAuftragId = 0;
            this.ctlFibuZahlungsWeg.FbZahlungsWegId = ((object)(resources.GetObject("ctlFibuZahlungsWeg.FbZahlungsWegId")));
            this.ctlFibuZahlungsWeg.Location = new System.Drawing.Point(0, 0);
            this.ctlFibuZahlungsWeg.Name = "ctlFibuZahlungsWeg";
            this.ctlFibuZahlungsWeg.Size = new System.Drawing.Size(854, 230);
            this.ctlFibuZahlungsWeg.TabIndex = 298;
            this.ctlFibuZahlungsWeg.Typ = KiSS4.Fibu.CtlFibuZahlungsWeg.ControlTyp.DauerAuftrag;
            this.ctlFibuZahlungsWeg.ZahlungsArtCode = KiSS4.Common.ZahlungsArt.Unbekannt;
            // 
            // lblKreditor
            // 
            this.lblKreditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblKreditor.ForeColor = System.Drawing.Color.Black;
            this.lblKreditor.Location = new System.Drawing.Point(15, 25299);
            this.lblKreditor.Name = "lblKreditor";
            this.lblKreditor.Size = new System.Drawing.Size(68, 24);
            this.lblKreditor.TabIndex = 297;
            this.lblKreditor.Text = "Kreditor";
            // 
            // grdFbDauerauftrag
            // 
            this.grdFbDauerauftrag.DataSource = this.qryFbDauerauftrag;
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
            this.grdFbDauerauftrag.Size = new System.Drawing.Size(854, 223);
            this.grdFbDauerauftrag.TabIndex = 30;
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
            this.colListeMandant,
            this.colListeSoll,
            this.colListeHaben,
            this.colListeText,
            this.colListeBetrag,
            this.colListePeriodizitaet,
            this.colListeStatus,
            this.colListeLetzteAusfuehrung,
            this.colListeTeam});
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
            // colListeMandant
            // 
            this.colListeMandant.Caption = "Mandant";
            this.colListeMandant.FieldName = "Mandant";
            this.colListeMandant.Name = "colListeMandant";
            this.colListeMandant.Visible = true;
            this.colListeMandant.VisibleIndex = 0;
            this.colListeMandant.Width = 126;
            // 
            // colListeSoll
            // 
            this.colListeSoll.Caption = "Soll";
            this.colListeSoll.FieldName = "SollKtoNr";
            this.colListeSoll.Name = "colListeSoll";
            this.colListeSoll.Visible = true;
            this.colListeSoll.VisibleIndex = 1;
            this.colListeSoll.Width = 48;
            // 
            // colListeHaben
            // 
            this.colListeHaben.Caption = "Haben";
            this.colListeHaben.FieldName = "HabenKtoNr";
            this.colListeHaben.Name = "colListeHaben";
            this.colListeHaben.Visible = true;
            this.colListeHaben.VisibleIndex = 2;
            this.colListeHaben.Width = 48;
            // 
            // colListeText
            // 
            this.colListeText.Caption = "Text";
            this.colListeText.FieldName = "Text";
            this.colListeText.Name = "colListeText";
            this.colListeText.Visible = true;
            this.colListeText.VisibleIndex = 3;
            this.colListeText.Width = 171;
            // 
            // colListeBetrag
            // 
            this.colListeBetrag.Caption = "Betrag";
            this.colListeBetrag.DisplayFormat.FormatString = "N";
            this.colListeBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colListeBetrag.FieldName = "Betrag";
            this.colListeBetrag.Name = "colListeBetrag";
            this.colListeBetrag.Visible = true;
            this.colListeBetrag.VisibleIndex = 4;
            this.colListeBetrag.Width = 63;
            // 
            // colListePeriodizitaet
            // 
            this.colListePeriodizitaet.Caption = "Periodizität";
            this.colListePeriodizitaet.FieldName = "AuftragPeriodizitaet";
            this.colListePeriodizitaet.Name = "colListePeriodizitaet";
            this.colListePeriodizitaet.Visible = true;
            this.colListePeriodizitaet.VisibleIndex = 5;
            this.colListePeriodizitaet.Width = 105;
            // 
            // colListeStatus
            // 
            this.colListeStatus.Caption = "Status";
            this.colListeStatus.FieldName = "AuftragStatus";
            this.colListeStatus.Name = "colListeStatus";
            this.colListeStatus.Visible = true;
            this.colListeStatus.VisibleIndex = 6;
            this.colListeStatus.Width = 91;
            // 
            // colListeLetzteAusfuehrung
            // 
            this.colListeLetzteAusfuehrung.Caption = "Letzte Ausf.";
            this.colListeLetzteAusfuehrung.FieldName = "LetzteAusfuehrung";
            this.colListeLetzteAusfuehrung.Name = "colListeLetzteAusfuehrung";
            this.colListeLetzteAusfuehrung.Visible = true;
            this.colListeLetzteAusfuehrung.VisibleIndex = 7;
            this.colListeLetzteAusfuehrung.Width = 82;
            // 
            // colListeTeam
            // 
            this.colListeTeam.Caption = "Team";
            this.colListeTeam.FieldName = "FbTeamID";
            this.colListeTeam.Name = "colListeTeam";
            this.colListeTeam.Visible = true;
            this.colListeTeam.VisibleIndex = 8;
            this.colListeTeam.Width = 70;
            // 
            // edtNurAktiveX
            // 
            this.edtNurAktiveX.EditValue = true;
            this.edtNurAktiveX.Location = new System.Drawing.Point(97, 160);
            this.edtNurAktiveX.Name = "edtNurAktiveX";
            this.edtNurAktiveX.Properties.Caption = "nur aktive";
            this.edtNurAktiveX.Size = new System.Drawing.Size(75, 19);
            this.edtNurAktiveX.TabIndex = 4;
            // 
            // kissSearchTitel1
            // 
            this.kissSearchTitel1.Location = new System.Drawing.Point(15, 5);
            this.kissSearchTitel1.Name = "kissSearchTitel1";
            this.kissSearchTitel1.Size = new System.Drawing.Size(200, 24);
            this.kissSearchTitel1.TabIndex = 334;
            // 
            // edtTeamX
            // 
            this.edtTeamX.Location = new System.Drawing.Point(483, 125);
            this.edtTeamX.Name = "edtTeamX";
            this.edtTeamX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTeamX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTeamX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTeamX.Properties.Appearance.Options.UseBackColor = true;
            this.edtTeamX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTeamX.Properties.Appearance.Options.UseFont = true;
            this.edtTeamX.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtTeamX.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtTeamX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject13.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject13.Options.UseBackColor = true;
            this.edtTeamX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13)});
            this.edtTeamX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTeamX.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtTeamX.Properties.DisplayMember = "Text";
            this.edtTeamX.Properties.NullText = "";
            this.edtTeamX.Properties.ShowFooter = false;
            this.edtTeamX.Properties.ShowHeader = false;
            this.edtTeamX.Properties.ValueMember = "Code";
            this.edtTeamX.Size = new System.Drawing.Size(206, 24);
            this.edtTeamX.TabIndex = 8;
            // 
            // editTeam
            // 
            this.editTeam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.editTeam.Location = new System.Drawing.Point(13389, 2692);
            this.editTeam.Name = "editTeam";
            this.editTeam.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editTeam.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editTeam.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editTeam.Properties.Appearance.Options.UseBackColor = true;
            this.editTeam.Properties.Appearance.Options.UseBorderColor = true;
            this.editTeam.Properties.Appearance.Options.UseFont = true;
            this.editTeam.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.editTeam.Properties.AppearanceDropDown.Options.UseFont = true;
            this.editTeam.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject14.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject14.Options.UseBackColor = true;
            this.editTeam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject14)});
            this.editTeam.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editTeam.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name")});
            this.editTeam.Properties.DisplayMember = "Name";
            this.editTeam.Properties.NullText = "";
            this.editTeam.Properties.ShowFooter = false;
            this.editTeam.Properties.ShowHeader = false;
            this.editTeam.Properties.ValueMember = "FbTeamID";
            this.editTeam.Size = new System.Drawing.Size(265, 24);
            this.editTeam.TabIndex = 7;
            // 
            // lblSuchenTeam
            // 
            this.lblSuchenTeam.ForeColor = System.Drawing.Color.Black;
            this.lblSuchenTeam.Location = new System.Drawing.Point(396, 125);
            this.lblSuchenTeam.Name = "lblSuchenTeam";
            this.lblSuchenTeam.Size = new System.Drawing.Size(80, 24);
            this.lblSuchenTeam.TabIndex = 333;
            this.lblSuchenTeam.Text = "Team";
            // 
            // edtDatumVonX
            // 
            this.edtDatumVonX.EditValue = null;
            this.edtDatumVonX.Location = new System.Drawing.Point(483, 35);
            this.edtDatumVonX.Name = "edtDatumVonX";
            this.edtDatumVonX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVonX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVonX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVonX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVonX.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtDatumVonX.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVonX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVonX.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVonX.Properties.Appearance.Options.UseForeColor = true;
            this.edtDatumVonX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject15.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject15.Options.UseBackColor = true;
            this.edtDatumVonX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVonX.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject15)});
            this.edtDatumVonX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVonX.Properties.ShowToday = false;
            this.edtDatumVonX.Size = new System.Drawing.Size(132, 24);
            this.edtDatumVonX.TabIndex = 5;
            // 
            // edtDatumBisX
            // 
            this.edtDatumBisX.EditValue = "";
            this.edtDatumBisX.Location = new System.Drawing.Point(483, 65);
            this.edtDatumBisX.Name = "edtDatumBisX";
            this.edtDatumBisX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBisX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBisX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBisX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBisX.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtDatumBisX.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBisX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBisX.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBisX.Properties.Appearance.Options.UseForeColor = true;
            this.edtDatumBisX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject16.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject16.Options.UseBackColor = true;
            this.edtDatumBisX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBisX.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject16)});
            this.edtDatumBisX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBisX.Properties.ShowToday = false;
            this.edtDatumBisX.Size = new System.Drawing.Size(132, 24);
            this.edtDatumBisX.TabIndex = 6;
            // 
            // lblSuchenPeriodizitaet
            // 
            this.lblSuchenPeriodizitaet.ForeColor = System.Drawing.Color.Black;
            this.lblSuchenPeriodizitaet.Location = new System.Drawing.Point(396, 95);
            this.lblSuchenPeriodizitaet.Name = "lblSuchenPeriodizitaet";
            this.lblSuchenPeriodizitaet.Size = new System.Drawing.Size(70, 24);
            this.lblSuchenPeriodizitaet.TabIndex = 331;
            this.lblSuchenPeriodizitaet.Text = "Periodizität";
            // 
            // lblSuchenText
            // 
            this.lblSuchenText.Location = new System.Drawing.Point(12, 65);
            this.lblSuchenText.Name = "lblSuchenText";
            this.lblSuchenText.Size = new System.Drawing.Size(60, 24);
            this.lblSuchenText.TabIndex = 330;
            this.lblSuchenText.Text = "Text";
            // 
            // edtTextX
            // 
            this.edtTextX.Location = new System.Drawing.Point(99, 65);
            this.edtTextX.Name = "edtTextX";
            this.edtTextX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTextX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTextX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTextX.Properties.Appearance.Options.UseBackColor = true;
            this.edtTextX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTextX.Properties.Appearance.Options.UseFont = true;
            this.edtTextX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTextX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTextX.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtTextX.Size = new System.Drawing.Size(258, 24);
            this.edtTextX.TabIndex = 1;
            // 
            // edtHabenX
            // 
            this.edtHabenX.Location = new System.Drawing.Point(99, 125);
            this.edtHabenX.Name = "edtHabenX";
            this.edtHabenX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtHabenX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtHabenX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHabenX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHabenX.Properties.Appearance.Options.UseBackColor = true;
            this.edtHabenX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHabenX.Properties.Appearance.Options.UseFont = true;
            this.edtHabenX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHabenX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtHabenX.Size = new System.Drawing.Size(90, 24);
            this.edtHabenX.TabIndex = 3;
            // 
            // edtSollX
            // 
            this.edtSollX.Location = new System.Drawing.Point(99, 95);
            this.edtSollX.Name = "edtSollX";
            this.edtSollX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSollX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSollX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSollX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSollX.Properties.Appearance.Options.UseBackColor = true;
            this.edtSollX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSollX.Properties.Appearance.Options.UseFont = true;
            this.edtSollX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSollX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSollX.Size = new System.Drawing.Size(90, 24);
            this.edtSollX.TabIndex = 2;
            // 
            // edtPeriodizitaetX
            // 
            this.edtPeriodizitaetX.Location = new System.Drawing.Point(483, 95);
            this.edtPeriodizitaetX.LOVName = "ZahlungsPeriode";
            this.edtPeriodizitaetX.Name = "edtPeriodizitaetX";
            this.edtPeriodizitaetX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPeriodizitaetX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPeriodizitaetX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPeriodizitaetX.Properties.Appearance.Options.UseBackColor = true;
            this.edtPeriodizitaetX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPeriodizitaetX.Properties.Appearance.Options.UseFont = true;
            this.edtPeriodizitaetX.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtPeriodizitaetX.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtPeriodizitaetX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject17.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject17.Options.UseBackColor = true;
            this.edtPeriodizitaetX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject17)});
            this.edtPeriodizitaetX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPeriodizitaetX.Properties.NullText = "";
            this.edtPeriodizitaetX.Properties.ShowFooter = false;
            this.edtPeriodizitaetX.Properties.ShowHeader = false;
            this.edtPeriodizitaetX.Size = new System.Drawing.Size(132, 24);
            this.edtPeriodizitaetX.TabIndex = 7;
            // 
            // lblSuchenDatumBis
            // 
            this.lblSuchenDatumBis.ForeColor = System.Drawing.Color.Black;
            this.lblSuchenDatumBis.Location = new System.Drawing.Point(396, 65);
            this.lblSuchenDatumBis.Name = "lblSuchenDatumBis";
            this.lblSuchenDatumBis.Size = new System.Drawing.Size(70, 24);
            this.lblSuchenDatumBis.TabIndex = 328;
            this.lblSuchenDatumBis.Text = "Gültig bis";
            // 
            // lblSuchenDatumVon
            // 
            this.lblSuchenDatumVon.ForeColor = System.Drawing.Color.Black;
            this.lblSuchenDatumVon.Location = new System.Drawing.Point(396, 35);
            this.lblSuchenDatumVon.Name = "lblSuchenDatumVon";
            this.lblSuchenDatumVon.Size = new System.Drawing.Size(70, 24);
            this.lblSuchenDatumVon.TabIndex = 327;
            this.lblSuchenDatumVon.Text = "Gültig von";
            // 
            // edtMandantX
            // 
            this.edtMandantX.Location = new System.Drawing.Point(99, 35);
            this.edtMandantX.Name = "edtMandantX";
            this.edtMandantX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMandantX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMandantX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMandantX.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtMandantX.Properties.Appearance.Options.UseBackColor = true;
            this.edtMandantX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMandantX.Properties.Appearance.Options.UseFont = true;
            this.edtMandantX.Properties.Appearance.Options.UseForeColor = true;
            this.edtMandantX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject18.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject18.Options.UseBackColor = true;
            this.edtMandantX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject18)});
            this.edtMandantX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtMandantX.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtMandantX.Size = new System.Drawing.Size(258, 24);
            this.edtMandantX.TabIndex = 0;
            this.edtMandantX.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtMandantX_UserModifiedFld);
            // 
            // lblSuchenHaben
            // 
            this.lblSuchenHaben.ForeColor = System.Drawing.Color.Black;
            this.lblSuchenHaben.Location = new System.Drawing.Point(12, 125);
            this.lblSuchenHaben.Name = "lblSuchenHaben";
            this.lblSuchenHaben.Size = new System.Drawing.Size(48, 24);
            this.lblSuchenHaben.TabIndex = 326;
            this.lblSuchenHaben.Text = "Haben";
            // 
            // lblSuchenSoll
            // 
            this.lblSuchenSoll.ForeColor = System.Drawing.Color.Black;
            this.lblSuchenSoll.Location = new System.Drawing.Point(12, 95);
            this.lblSuchenSoll.Name = "lblSuchenSoll";
            this.lblSuchenSoll.Size = new System.Drawing.Size(31, 24);
            this.lblSuchenSoll.TabIndex = 325;
            this.lblSuchenSoll.Text = "Soll";
            // 
            // lblSuchenMandant
            // 
            this.lblSuchenMandant.ForeColor = System.Drawing.Color.Black;
            this.lblSuchenMandant.Location = new System.Drawing.Point(12, 35);
            this.lblSuchenMandant.Name = "lblSuchenMandant";
            this.lblSuchenMandant.Size = new System.Drawing.Size(63, 24);
            this.lblSuchenMandant.TabIndex = 324;
            this.lblSuchenMandant.Text = "Mandant";
            // 
            // panDauerauftraegeAusfuehren
            // 
            this.panDauerauftraegeAusfuehren.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panDauerauftraegeAusfuehren.Controls.Add(this.btnDaAusfuehren);
            this.panDauerauftraegeAusfuehren.Location = new System.Drawing.Point(0, 529);
            this.panDauerauftraegeAusfuehren.Name = "panDauerauftraegeAusfuehren";
            this.panDauerauftraegeAusfuehren.Size = new System.Drawing.Size(866, 30);
            this.panDauerauftraegeAusfuehren.TabIndex = 292;
            // 
            // btnDaAusfuehren
            // 
            this.btnDaAusfuehren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDaAusfuehren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDaAusfuehren.Location = new System.Drawing.Point(534, 3);
            this.btnDaAusfuehren.Name = "btnDaAusfuehren";
            this.btnDaAusfuehren.Size = new System.Drawing.Size(326, 24);
            this.btnDaAusfuehren.TabIndex = 10;
            this.btnDaAusfuehren.Text = "Alle Daueraufträge ausführen (max einmal täglich!)";
            this.btnDaAusfuehren.UseVisualStyleBackColor = false;
            this.btnDaAusfuehren.Click += new System.EventHandler(this.btnDaAusfuehren_Click);
            // 
            // CtlFibuDauerauftrag
            // 
            this.ActiveSQLQuery = this.qryFbDauerauftrag;
            this.AutoRefresh = false;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(840, 500);
            this.Controls.Add(this.xTabControl2);
            this.Controls.Add(this.panDauerauftraegeAusfuehren);
            this.Name = "CtlFibuDauerauftrag";
            this.Size = new System.Drawing.Size(866, 559);
            this.Load += new System.EventHandler(this.CtlFibuDauerauftrag_Load);
            this.Enter += new System.EventHandler(this.CtlFibuDauerauftrag_Enter);
            this.Controls.SetChildIndex(this.panDauerauftraegeAusfuehren, 0);
            this.Controls.SetChildIndex(this.xTabControl2, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMasks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFbDauerauftrag)).EndInit();
            this.xTabControl2.ResumeLayout(false);
            this.tabDauerauftrag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkVorWochenende.Properties)).EndInit();
            this.panMonatstag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtMonatstag2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMonatstag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMonatstag1.Properties)).EndInit();
            this.panWochentagListe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblWochentag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWochentag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWochentag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDummyTabCorrection.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDummyTabCorrection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDauerauftrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDANr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDauerauftrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollKontoNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHabenName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editSollName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHabenKontoNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPeriodizitaetCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPeriodizitaetCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGueltigBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPeriodizitaet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGueltigVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMandant.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandantNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPlzOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHaben)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandant)).EndInit();
            this.tabKreditor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFbDauerauftrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFbDauerauftrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurAktiveX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTeamX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTeamX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTeam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTeam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenTeam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVonX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBisX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenPeriodizitaet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTextX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHabenX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPeriodizitaetX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPeriodizitaetX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMandantX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenHaben)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenSoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchenMandant)).EndInit();
            this.panDauerauftraegeAusfuehren.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal KiSS4.Fibu.CtlFibuZahlungsWeg ctlFibuZahlungsWeg;
        private KiSS4.Gui.KissButton btnDaAusfuehren;
        private KiSS4.Gui.KissCheckEdit chkVorWochenende;
        private DevExpress.XtraGrid.Columns.GridColumn colBeleg;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colHaben;
        private DevExpress.XtraGrid.Columns.GridColumn colItemMandant;
        private DevExpress.XtraGrid.Columns.GridColumn colListeBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colListeHaben;
        private DevExpress.XtraGrid.Columns.GridColumn colListeLetzteAusfuehrung;
        private DevExpress.XtraGrid.Columns.GridColumn colListeMandant;
        private DevExpress.XtraGrid.Columns.GridColumn colListePeriodizitaet;
        private DevExpress.XtraGrid.Columns.GridColumn colListeSoll;
        private DevExpress.XtraGrid.Columns.GridColumn colListeStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colListeTeam;
        private DevExpress.XtraGrid.Columns.GridColumn colListeText;
        private DevExpress.XtraGrid.Columns.GridColumn colSoll;
        private DevExpress.XtraGrid.Columns.GridColumn colText;
        private KiSS4.Gui.KissTextEdit editSollName;
        private KiSS4.Gui.KissLookUpEdit editTeam;
        private KiSS4.Gui.KissCalcEdit edtBetrag;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumBisX;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissDateEdit edtDatumVonX;
        private KiSS4.Dokument.XDokument edtDauerauftrag;
        private KiSS4.Gui.KissLookUpEdit edtDummyTabCorrection;
        private KiSS4.Gui.KissButtonEdit edtHabenKontoNr;
        private KiSS4.Gui.KissTextEdit edtHabenName;
        private KiSS4.Gui.KissCalcEdit edtHabenX;
        private KiSS4.Gui.KissButtonEdit edtMandant;
        private KiSS4.Gui.KissButtonEdit edtMandantX;
        private KiSS4.Gui.KissCalcEdit edtMonatstag1;
        private KiSS4.Gui.KissCalcEdit edtMonatstag2;
        private KiSS4.Gui.KissCheckEdit edtNurAktiveX;
        private KiSS4.Gui.KissLookUpEdit edtPeriodizitaetCode;
        private KiSS4.Gui.KissLookUpEdit edtPeriodizitaetX;
        private KiSS4.Gui.KissButtonEdit edtSollKontoNr;
        private KiSS4.Gui.KissCalcEdit edtSollX;
        private KiSS4.Gui.KissLookUpEdit edtTeamX;
        private KiSS4.Gui.KissTextEdit edtText;
        private KiSS4.Gui.KissButtonEdit edtTextX;
        private KiSS4.Gui.KissLookUpEdit edtWochentag;
        private KiSS4.Gui.KissGrid grdFbDauerauftrag;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMasks;
        private DevExpress.XtraGrid.Views.Grid.GridView grvFbDauerauftrag;
        private KiSS4.Gui.KissSearchTitel kissSearchTitel1;
        private KiSS4.Gui.KissLabel lblBetrag;
        private KiSS4.Gui.KissLabel lblDANr;
        private KiSS4.Gui.KissTextEdit lblDauerauftrag;
        private KiSS4.Gui.KissLabel lblDokument;
        private KiSS4.Gui.KissLabel lblGueltigBis;
        private KiSS4.Gui.KissLabel lblGueltigVon;
        private KiSS4.Gui.KissLabel lblHaben;
        private KiSS4.Gui.KissLabel lblKreditor;
        private KiSS4.Gui.KissLabel lblMandant;
        private KiSS4.Gui.KissTextEdit lblMandantNr;
        private KiSS4.Gui.KissLabel lblMonatstag;
        private KiSS4.Gui.KissLabel lblPeriodizitaet;
        private KiSS4.Gui.KissTextEdit lblPlzOrt;
        private KiSS4.Gui.KissLabel lblSoll;
        private KiSS4.Gui.KissLabel lblSuchenDatumBis;
        private KiSS4.Gui.KissLabel lblSuchenDatumVon;
        private KiSS4.Gui.KissLabel lblSuchenHaben;
        private KiSS4.Gui.KissLabel lblSuchenMandant;
        private KiSS4.Gui.KissLabel lblSuchenPeriodizitaet;
        private KiSS4.Gui.KissLabel lblSuchenSoll;
        private KiSS4.Gui.KissLabel lblSuchenTeam;
        private KiSS4.Gui.KissLabel lblSuchenText;
        private KiSS4.Gui.KissLabel lblText;
        private KiSS4.Gui.KissLabel lblWochentag;
        private System.Windows.Forms.Panel panDauerauftraegeAusfuehren;
        private System.Windows.Forms.Panel panMonatstag;
        private System.Windows.Forms.Panel panWochentagListe;
        private KiSS4.DB.SqlQuery qryFbDauerauftrag;
        private SharpLibrary.WinControls.TabPageEx tabDauerauftrag;
        private SharpLibrary.WinControls.TabPageEx tabKreditor;
        private KiSS4.Gui.KissTabControlEx xTabControl2;
    }
}
