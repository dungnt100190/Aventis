namespace KiSS4.Query
{
    public partial class CtlQueryWhZahlungseingaenge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryWhZahlungseingaenge));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grvDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDetailKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailErfassung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailBetragEffektiv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailDiff = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailVerwVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailVerwBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnMonatsbudget = new KiSS4.Gui.KissButton();
            this.edtBaPerson = new KiSS4.Gui.KissButtonEdit();
            this.lblBaPerson = new KiSS4.Gui.KissLabel();
            this.lblZEDatum = new KiSS4.Gui.KissLabel();
            this.lblZEDatumBis = new KiSS4.Gui.KissLabel();
            this.edtZEDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtZEDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblFalltraeger = new KiSS4.Gui.KissLabel();
            this.edtAktiveS = new KiSS4.Gui.KissCheckEdit();
            this.edtInaktiveS = new KiSS4.Gui.KissCheckEdit();
            this.lblKOA = new KiSS4.Gui.KissLabel();
            this.grdVerfuegbar = new KiSS4.Gui.KissGrid();
            this.grvVerfugbar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.qryVerfuegbar = new KiSS4.DB.SqlQuery(this.components);
            this.grdZugeteilt = new KiSS4.Gui.KissGrid();
            this.grvZugeteilt = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.qryZugeteilt = new KiSS4.DB.SqlQuery(this.components);
            this.edtFilterVerfuegbar = new KiSS4.Gui.KissTextEdit();
            this.edtFilterZugeteilt = new KiSS4.Gui.KissTextEdit();
            this.btnAdd = new KiSS4.Gui.KissButton();
            this.btnRemove = new KiSS4.Gui.KissButton();
            this.btnAddAll = new KiSS4.Gui.KissButton();
            this.btnRemoveAll = new KiSS4.Gui.KissButton();
            this.lblFilterVerfuegbar = new KiSS4.Gui.KissLabel();
            this.lblKOALeer = new KiSS4.Gui.KissLabel();
            this.lblFilterZugeteilt = new KiSS4.Gui.KissLabel();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetragEffektiv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErfassung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerwBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerwVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiff = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaFallID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKOA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSektion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grvMain = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBelegNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBemerkungSaldierung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaldiert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblSuchNachS = new KiSS4.Gui.KissLabel();
            this.lblSAR = new KiSS4.Gui.KissLabel();
            this.lblSektion = new KiSS4.Gui.KissLabel();
            this.edtUserID = new KiSS4.Gui.KissButtonEdit();
            this.edtOrgUnitID = new KiSS4.Gui.KissLookUpEdit();
            this.panelDetail = new System.Windows.Forms.Panel();
            this.edtBemerkungSaldierung = new KiSS4.Gui.KissMemoEdit();
            this.lblBemerkungSaldierung = new KiSS4.Gui.KissLabel();
            this.edtSaldiert = new KiSS4.Gui.KissCheckEdit();
            this.lblVerwPerVon = new KiSS4.Gui.KissLabel();
            this.edtPeriodeVon = new KiSS4.Gui.KissDateEdit();
            this.edtPeriodeBis = new KiSS4.Gui.KissDateEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtFoderungsTyp = new KiSS4.Gui.KissRadioGroup(this.components);
            this.lblForderungen = new KiSS4.Gui.KissLabel();
            this.edtSaldierungSuche = new KiSS4.Gui.KissRadioGroup(this.components);
            this.edtFalltraeger = new KiSS4.Gui.KissButtonEdit();
            this.lblForderungDatum = new KiSS4.Gui.KissLabel();
            this.edtForderungDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtForderungDatumVon = new KiSS4.Gui.KissDateEdit();
            this.lblForderungDatumBis = new KiSS4.Gui.KissLabel();
            this.edtBudgetVon = new KiSS4.Gui.KissDateEdit();
            this.lblBudgetBis = new KiSS4.Gui.KissLabel();
            this.edtBudgetBis = new KiSS4.Gui.KissDateEdit();
            this.lblBudget = new KiSS4.Gui.KissLabel();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZEDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZEDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZEDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZEDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFalltraeger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAktiveS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInaktiveS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKOA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVerfugbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterVerfuegbar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterZugeteilt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilterVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKOALeer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilterZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchNachS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSektion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnitID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnitID.Properties)).BeginInit();
            this.panelDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkungSaldierung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungSaldierung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSaldiert.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwPerVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPeriodeVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPeriodeBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFoderungsTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFoderungsTyp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblForderungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSaldierungSuche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSaldierungSuche.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFalltraeger.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblForderungDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtForderungDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtForderungDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblForderungDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBudgetVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBudgetBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBudgetBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.CanUpdate = true;
            this.qryQuery.FillTimeOut = 400;
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            this.qryQuery.TableName = "BgPosition";
            this.qryQuery.AfterFill += new System.EventHandler(this.qryQuery_AfterFill);
            this.qryQuery.ColumnChanged += new System.Data.DataColumnChangeEventHandler(this.qryQuery_ColumnChanged);
            this.qryQuery.PositionChanged += new System.EventHandler(this.qryQuery_PositionChanged);
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
            this.grvQuery1.OptionsBehavior.Editable = false;
            this.grvQuery1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvQuery1.OptionsNavigation.AutoFocusNewRow = true;
            this.grvQuery1.OptionsNavigation.UseTabKey = false;
            this.grvQuery1.OptionsPrint.AutoWidth = false;
            this.grvQuery1.OptionsPrint.ExpandAllDetails = true;
            this.grvQuery1.OptionsPrint.UsePrintStyles = true;
            this.grvQuery1.OptionsView.ColumnAutoWidth = false;
            this.grvQuery1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvQuery1.OptionsView.ShowGroupPanel = false;
            this.grvQuery1.OptionsView.ShowIndicator = false;
            // 
            // grdQuery1
            // 
            // 
            // 
            // 
            this.grdQuery1.EmbeddedNavigator.Name = "";
            this.grdQuery1.Size = new System.Drawing.Size(766, 393);
            this.grdQuery1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDetail,
            this.grvMain});
            // 
            // xDocument
            // 
            this.xDocument.Location = new System.Drawing.Point(302, 3462);
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = "BaPersonID_Fall";
            this.ctlGotoFall.Location = new System.Drawing.Point(3, 399);
            this.ctlGotoFall.Size = new System.Drawing.Size(158, 27);
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(752, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Size = new System.Drawing.Size(784, 464);
            this.tabControlSearch.TabIndex = 5;
            this.tabControlSearch.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControlSearch_SelectedTabChanged);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.btnMonatsbudget);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Size = new System.Drawing.Size(772, 426);
            this.tpgListe.Controls.SetChildIndex(this.grdQuery1, 0);
            this.tpgListe.Controls.SetChildIndex(this.xDocument, 0);
            this.tpgListe.Controls.SetChildIndex(this.ctlGotoFall, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnMonatsbudget, 0);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.kissLabel1);
            this.tpgSuchen.Controls.Add(this.lblBudget);
            this.tpgSuchen.Controls.Add(this.edtBudgetBis);
            this.tpgSuchen.Controls.Add(this.lblBudgetBis);
            this.tpgSuchen.Controls.Add(this.edtBudgetVon);
            this.tpgSuchen.Controls.Add(this.edtForderungDatumBis);
            this.tpgSuchen.Controls.Add(this.edtForderungDatumVon);
            this.tpgSuchen.Controls.Add(this.lblForderungDatumBis);
            this.tpgSuchen.Controls.Add(this.lblForderungDatum);
            this.tpgSuchen.Controls.Add(this.edtFalltraeger);
            this.tpgSuchen.Controls.Add(this.edtSaldierungSuche);
            this.tpgSuchen.Controls.Add(this.lblForderungen);
            this.tpgSuchen.Controls.Add(this.edtFoderungsTyp);
            this.tpgSuchen.Controls.Add(this.edtPeriodeBis);
            this.tpgSuchen.Controls.Add(this.edtPeriodeVon);
            this.tpgSuchen.Controls.Add(this.lblVerwPerVon);
            this.tpgSuchen.Controls.Add(this.lblSAR);
            this.tpgSuchen.Controls.Add(this.lblSektion);
            this.tpgSuchen.Controls.Add(this.edtUserID);
            this.tpgSuchen.Controls.Add(this.edtOrgUnitID);
            this.tpgSuchen.Controls.Add(this.lblFilterZugeteilt);
            this.tpgSuchen.Controls.Add(this.lblKOALeer);
            this.tpgSuchen.Controls.Add(this.lblFilterVerfuegbar);
            this.tpgSuchen.Controls.Add(this.btnRemoveAll);
            this.tpgSuchen.Controls.Add(this.btnAddAll);
            this.tpgSuchen.Controls.Add(this.btnRemove);
            this.tpgSuchen.Controls.Add(this.btnAdd);
            this.tpgSuchen.Controls.Add(this.edtFilterZugeteilt);
            this.tpgSuchen.Controls.Add(this.edtFilterVerfuegbar);
            this.tpgSuchen.Controls.Add(this.grdZugeteilt);
            this.tpgSuchen.Controls.Add(this.grdVerfuegbar);
            this.tpgSuchen.Controls.Add(this.lblKOA);
            this.tpgSuchen.Controls.Add(this.edtInaktiveS);
            this.tpgSuchen.Controls.Add(this.edtAktiveS);
            this.tpgSuchen.Controls.Add(this.lblFalltraeger);
            this.tpgSuchen.Controls.Add(this.edtZEDatumBis);
            this.tpgSuchen.Controls.Add(this.edtZEDatumVon);
            this.tpgSuchen.Controls.Add(this.lblZEDatumBis);
            this.tpgSuchen.Controls.Add(this.lblZEDatum);
            this.tpgSuchen.Controls.Add(this.lblBaPerson);
            this.tpgSuchen.Controls.Add(this.edtBaPerson);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Size = new System.Drawing.Size(772, 426);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBaPerson, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBaPerson, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZEDatum, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZEDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtZEDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtZEDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblFalltraeger, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAktiveS, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtInaktiveS, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblKOA, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.grdVerfuegbar, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.grdZugeteilt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFilterVerfuegbar, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFilterZugeteilt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.btnAdd, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.btnRemove, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.btnAddAll, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.btnRemoveAll, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblFilterVerfuegbar, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblKOALeer, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblFilterZugeteilt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtOrgUnitID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUserID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSektion, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSAR, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblVerwPerVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtPeriodeVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtPeriodeBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFoderungsTyp, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblForderungen, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSaldierungSuche, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFalltraeger, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblForderungDatum, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblForderungDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtForderungDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtForderungDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBudgetVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBudgetBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBudgetBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBudget, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel1, 0);
            // 
            // grvDetail
            // 
            this.grvDetail.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvDetail.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDetail.Appearance.Empty.Options.UseBackColor = true;
            this.grvDetail.Appearance.Empty.Options.UseFont = true;
            this.grvDetail.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDetail.Appearance.EvenRow.Options.UseFont = true;
            this.grvDetail.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvDetail.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDetail.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvDetail.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvDetail.Appearance.FocusedCell.Options.UseFont = true;
            this.grvDetail.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvDetail.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvDetail.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDetail.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvDetail.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvDetail.Appearance.FocusedRow.Options.UseFont = true;
            this.grvDetail.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvDetail.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvDetail.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvDetail.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvDetail.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvDetail.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvDetail.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvDetail.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvDetail.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvDetail.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDetail.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvDetail.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvDetail.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvDetail.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvDetail.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvDetail.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvDetail.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDetail.Appearance.OddRow.Options.UseFont = true;
            this.grvDetail.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvDetail.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDetail.Appearance.Row.Options.UseBackColor = true;
            this.grvDetail.Appearance.Row.Options.UseFont = true;
            this.grvDetail.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDetail.Appearance.SelectedRow.Options.UseFont = true;
            this.grvDetail.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvDetail.Appearance.VertLine.Options.UseBackColor = true;
            this.grvDetail.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDetailKlient,
            this.colDetailErfassung,
            this.colDetailBetrag,
            this.colDetailBetragEffektiv,
            this.colDetailDiff,
            this.colDetailVerwVon,
            this.colDetailVerwBis});
            this.grvDetail.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvDetail.GridControl = this.grdQuery1;
            this.grvDetail.Name = "grvDetail";
            this.grvDetail.OptionsBehavior.Editable = false;
            this.grvDetail.OptionsDetail.ShowDetailTabs = false;
            this.grvDetail.OptionsView.ColumnAutoWidth = false;
            this.grvDetail.OptionsView.ShowGroupPanel = false;
            // 
            // colDetailKlient
            // 
            this.colDetailKlient.Caption = "Klient/in";
            this.colDetailKlient.FieldName = "DisplayText";
            this.colDetailKlient.Name = "colDetailKlient";
            this.colDetailKlient.Visible = true;
            this.colDetailKlient.VisibleIndex = 0;
            this.colDetailKlient.Width = 264;
            // 
            // colDetailErfassung
            // 
            this.colDetailErfassung.Caption = "Belegdatum ZE";
            this.colDetailErfassung.FieldName = "BelegDatum";
            this.colDetailErfassung.Name = "colDetailErfassung";
            this.colDetailErfassung.Visible = true;
            this.colDetailErfassung.VisibleIndex = 1;
            this.colDetailErfassung.Width = 107;
            // 
            // colDetailBetrag
            // 
            this.colDetailBetrag.AppearanceCell.Options.UseTextOptions = true;
            this.colDetailBetrag.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colDetailBetrag.Caption = "Soll";
            this.colDetailBetrag.DisplayFormat.FormatString = "n2";
            this.colDetailBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDetailBetrag.FieldName = "Betrag";
            this.colDetailBetrag.Name = "colDetailBetrag";
            this.colDetailBetrag.Visible = true;
            this.colDetailBetrag.VisibleIndex = 2;
            // 
            // colDetailBetragEffektiv
            // 
            this.colDetailBetragEffektiv.AppearanceCell.Options.UseTextOptions = true;
            this.colDetailBetragEffektiv.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colDetailBetragEffektiv.Caption = "Summe ZE";
            this.colDetailBetragEffektiv.DisplayFormat.FormatString = "n2";
            this.colDetailBetragEffektiv.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDetailBetragEffektiv.FieldName = "BetragEffektiv";
            this.colDetailBetragEffektiv.Name = "colDetailBetragEffektiv";
            this.colDetailBetragEffektiv.Visible = true;
            this.colDetailBetragEffektiv.VisibleIndex = 3;
            this.colDetailBetragEffektiv.Width = 80;
            // 
            // colDetailDiff
            // 
            this.colDetailDiff.AppearanceCell.Options.UseTextOptions = true;
            this.colDetailDiff.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colDetailDiff.Caption = "Diff.";
            this.colDetailDiff.DisplayFormat.FormatString = "n2";
            this.colDetailDiff.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDetailDiff.FieldName = "Diff";
            this.colDetailDiff.Name = "colDetailDiff";
            this.colDetailDiff.Visible = true;
            this.colDetailDiff.VisibleIndex = 4;
            // 
            // colDetailVerwVon
            // 
            this.colDetailVerwVon.Caption = "Verw. von";
            this.colDetailVerwVon.FieldName = "VerwPeriodeVon";
            this.colDetailVerwVon.Name = "colDetailVerwVon";
            this.colDetailVerwVon.Visible = true;
            this.colDetailVerwVon.VisibleIndex = 5;
            this.colDetailVerwVon.Width = 85;
            // 
            // colDetailVerwBis
            // 
            this.colDetailVerwBis.Caption = "Verw. bis";
            this.colDetailVerwBis.FieldName = "VerwPeriodeBis";
            this.colDetailVerwBis.Name = "colDetailVerwBis";
            this.colDetailVerwBis.Visible = true;
            this.colDetailVerwBis.VisibleIndex = 6;
            // 
            // btnMonatsbudget
            // 
            this.btnMonatsbudget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMonatsbudget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonatsbudget.Location = new System.Drawing.Point(167, 399);
            this.btnMonatsbudget.Name = "btnMonatsbudget";
            this.btnMonatsbudget.Size = new System.Drawing.Size(129, 24);
            this.btnMonatsbudget.TabIndex = 419;
            this.btnMonatsbudget.Text = "> Monatsbudget";
            this.btnMonatsbudget.UseCompatibleTextRendering = true;
            this.btnMonatsbudget.UseVisualStyleBackColor = false;
            this.btnMonatsbudget.Click += new System.EventHandler(this.btnMonatsbudget_Click);
            // 
            // edtBaPerson
            // 
            this.edtBaPerson.Location = new System.Drawing.Point(150, 95);
            this.edtBaPerson.Name = "edtBaPerson";
            this.edtBaPerson.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPerson.Properties.Appearance.Options.UseFont = true;
            this.edtBaPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject13.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject13.Options.UseBackColor = true;
            this.edtBaPerson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13)});
            this.edtBaPerson.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPerson.Properties.Name = "kissButtonEdit1.Properties";
            this.edtBaPerson.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtBaPerson.Size = new System.Drawing.Size(257, 24);
            this.edtBaPerson.TabIndex = 6;
            this.edtBaPerson.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtBaPerson_UserModifiedFld);
            // 
            // lblBaPerson
            // 
            this.lblBaPerson.Location = new System.Drawing.Point(10, 95);
            this.lblBaPerson.Name = "lblBaPerson";
            this.lblBaPerson.Size = new System.Drawing.Size(113, 24);
            this.lblBaPerson.TabIndex = 5;
            this.lblBaPerson.Text = "Person";
            this.lblBaPerson.UseCompatibleTextRendering = true;
            // 
            // lblZEDatum
            // 
            this.lblZEDatum.Location = new System.Drawing.Point(10, 155);
            this.lblZEDatum.Name = "lblZEDatum";
            this.lblZEDatum.Size = new System.Drawing.Size(113, 24);
            this.lblZEDatum.TabIndex = 9;
            this.lblZEDatum.Text = "ZE (Belegdatum)";
            this.lblZEDatum.UseCompatibleTextRendering = true;
            // 
            // lblZEDatumBis
            // 
            this.lblZEDatumBis.Location = new System.Drawing.Point(264, 155);
            this.lblZEDatumBis.Name = "lblZEDatumBis";
            this.lblZEDatumBis.Size = new System.Drawing.Size(23, 24);
            this.lblZEDatumBis.TabIndex = 11;
            this.lblZEDatumBis.Text = "bis";
            this.lblZEDatumBis.UseCompatibleTextRendering = true;
            // 
            // edtZEDatumVon
            // 
            this.edtZEDatumVon.EditValue = null;
            this.edtZEDatumVon.Location = new System.Drawing.Point(150, 155);
            this.edtZEDatumVon.Name = "edtZEDatumVon";
            this.edtZEDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtZEDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZEDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZEDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZEDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtZEDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZEDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtZEDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.edtZEDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtZEDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.edtZEDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZEDatumVon.Properties.ShowToday = false;
            this.edtZEDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtZEDatumVon.TabIndex = 10;
            this.edtZEDatumVon.Validated += new System.EventHandler(this.edtDatumVon_Validated);
            // 
            // edtZEDatumBis
            // 
            this.edtZEDatumBis.EditValue = null;
            this.edtZEDatumBis.Location = new System.Drawing.Point(307, 154);
            this.edtZEDatumBis.Name = "edtZEDatumBis";
            this.edtZEDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtZEDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZEDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZEDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZEDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtZEDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZEDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtZEDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtZEDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtZEDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.edtZEDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZEDatumBis.Properties.ShowToday = false;
            this.edtZEDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtZEDatumBis.TabIndex = 12;
            this.edtZEDatumBis.Validated += new System.EventHandler(this.edtDatumBis_Validated);
            // 
            // lblFalltraeger
            // 
            this.lblFalltraeger.Location = new System.Drawing.Point(10, 125);
            this.lblFalltraeger.Name = "lblFalltraeger";
            this.lblFalltraeger.Size = new System.Drawing.Size(113, 24);
            this.lblFalltraeger.TabIndex = 7;
            this.lblFalltraeger.Text = "Fallträger";
            this.lblFalltraeger.UseCompatibleTextRendering = true;
            // 
            // edtAktiveS
            // 
            this.edtAktiveS.EditValue = false;
            this.edtAktiveS.Location = new System.Drawing.Point(502, 189);
            this.edtAktiveS.Name = "edtAktiveS";
            this.edtAktiveS.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAktiveS.Properties.Appearance.Options.UseBackColor = true;
            this.edtAktiveS.Properties.Caption = "nur aktive S";
            this.edtAktiveS.Size = new System.Drawing.Size(92, 19);
            this.edtAktiveS.TabIndex = 20;
            this.edtAktiveS.CheckedChanged += new System.EventHandler(this.edtAktiveW_CheckedChanged);
            // 
            // edtInaktiveS
            // 
            this.edtInaktiveS.EditValue = false;
            this.edtInaktiveS.Location = new System.Drawing.Point(600, 189);
            this.edtInaktiveS.Name = "edtInaktiveS";
            this.edtInaktiveS.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtInaktiveS.Properties.Appearance.Options.UseBackColor = true;
            this.edtInaktiveS.Properties.Caption = "nur inaktive S";
            this.edtInaktiveS.Size = new System.Drawing.Size(92, 19);
            this.edtInaktiveS.TabIndex = 21;
            this.edtInaktiveS.CheckedChanged += new System.EventHandler(this.edtInaktiveW_CheckedChanged);
            // 
            // lblKOA
            // 
            this.lblKOA.Location = new System.Drawing.Point(10, 243);
            this.lblKOA.Name = "lblKOA";
            this.lblKOA.Size = new System.Drawing.Size(113, 24);
            this.lblKOA.TabIndex = 23;
            this.lblKOA.Text = "Kostenarten";
            this.lblKOA.UseCompatibleTextRendering = true;
            // 
            // grdVerfuegbar
            // 
            // 
            // 
            // 
            this.grdVerfuegbar.EmbeddedNavigator.Name = "";
            this.grdVerfuegbar.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            gridLevelNode2.RelationName = "Level1";
            this.grdVerfuegbar.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.grdVerfuegbar.Location = new System.Drawing.Point(150, 243);
            this.grdVerfuegbar.MainView = this.grvVerfugbar;
            this.grdVerfuegbar.Name = "grdVerfuegbar";
            this.grdVerfuegbar.Size = new System.Drawing.Size(257, 138);
            this.grdVerfuegbar.TabIndex = 24;
            this.grdVerfuegbar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVerfugbar});
            this.grdVerfuegbar.DoubleClick += new System.EventHandler(this.grdVerfuegbar_DoubleClick);
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
            this.colUserText.Caption = "Verfügbare Kostenarten";
            this.colUserText.FieldName = "Name";
            this.colUserText.Name = "colUserText";
            this.colUserText.Visible = true;
            this.colUserText.VisibleIndex = 0;
            this.colUserText.Width = 234;
            // 
            // qryVerfuegbar
            // 
            this.qryVerfuegbar.AutoApplyUserRights = false;
            this.qryVerfuegbar.BatchUpdate = true;
            this.qryVerfuegbar.CanDelete = true;
            this.qryVerfuegbar.CanInsert = true;
            this.qryVerfuegbar.DeleteQuestion = null;
            this.qryVerfuegbar.HostControl = this;
            this.qryVerfuegbar.SelectStatement = "SELECT\r\n  KontoNr,\r\n  Name = ISNULL(KontoNr + \' \', \'\') + Name\r\nFROM dbo.BgKostena" +
    "rt WITH(READUNCOMMITTED)\r\nWHERE ModulId = 3\r\n  AND {0} = 1\r\n  AND KontoNr NOT LI" +
    "KE \'0%\'\r\nORDER BY KontoNr ASC;";
            // 
            // grdZugeteilt
            // 
            // 
            // 
            // 
            this.grdZugeteilt.EmbeddedNavigator.Name = "";
            this.grdZugeteilt.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdZugeteilt.Location = new System.Drawing.Point(460, 243);
            this.grdZugeteilt.MainView = this.grvZugeteilt;
            this.grdZugeteilt.Name = "grdZugeteilt";
            this.grdZugeteilt.Size = new System.Drawing.Size(257, 138);
            this.grdZugeteilt.TabIndex = 31;
            this.grdZugeteilt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvZugeteilt});
            this.grdZugeteilt.DoubleClick += new System.EventHandler(this.grdZugeteilt_DoubleClick);
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
            this.colUser.Caption = "Zugeteilte Kostenarten";
            this.colUser.FieldName = "Name";
            this.colUser.Name = "colUser";
            this.colUser.Visible = true;
            this.colUser.VisibleIndex = 0;
            this.colUser.Width = 234;
            // 
            // qryZugeteilt
            // 
            this.qryZugeteilt.AutoApplyUserRights = false;
            this.qryZugeteilt.BatchUpdate = true;
            this.qryZugeteilt.CanDelete = true;
            this.qryZugeteilt.CanInsert = true;
            this.qryZugeteilt.HostControl = this;
            this.qryZugeteilt.SelectStatement = "SELECT\r\n  KontoNr,\r\n  Name = ISNULL(KontoNr + \' \', \'\') + Name\r\nFROM dbo.BgKostena" +
    "rt WITH(READUNCOMMITTED)\r\nWHERE ModulId = 3\r\n  AND {0} = 1\r\n  AND KontoNr NOT LI" +
    "KE \'0%\'\r\nORDER BY KontoNr ASC;";
            // 
            // edtFilterVerfuegbar
            // 
            this.edtFilterVerfuegbar.AllowDrop = true;
            this.edtFilterVerfuegbar.Location = new System.Drawing.Point(191, 395);
            this.edtFilterVerfuegbar.Name = "edtFilterVerfuegbar";
            this.edtFilterVerfuegbar.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFilterVerfuegbar.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFilterVerfuegbar.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFilterVerfuegbar.Properties.Appearance.Options.UseBackColor = true;
            this.edtFilterVerfuegbar.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFilterVerfuegbar.Properties.Appearance.Options.UseFont = true;
            this.edtFilterVerfuegbar.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFilterVerfuegbar.Size = new System.Drawing.Size(216, 24);
            this.edtFilterVerfuegbar.TabIndex = 26;
            this.edtFilterVerfuegbar.EditValueChanged += new System.EventHandler(this.edtFilter_EditValueChanged);
            // 
            // edtFilterZugeteilt
            // 
            this.edtFilterZugeteilt.AllowDrop = true;
            this.edtFilterZugeteilt.Location = new System.Drawing.Point(501, 395);
            this.edtFilterZugeteilt.Name = "edtFilterZugeteilt";
            this.edtFilterZugeteilt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFilterZugeteilt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFilterZugeteilt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFilterZugeteilt.Properties.Appearance.Options.UseBackColor = true;
            this.edtFilterZugeteilt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFilterZugeteilt.Properties.Appearance.Options.UseFont = true;
            this.edtFilterZugeteilt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFilterZugeteilt.Size = new System.Drawing.Size(216, 24);
            this.edtFilterZugeteilt.TabIndex = 33;
            this.edtFilterZugeteilt.EditValueChanged += new System.EventHandler(this.edtFilter2_EditValueChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.IconID = 13;
            this.btnAdd.Location = new System.Drawing.Point(419, 255);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(28, 24);
            this.btnAdd.TabIndex = 27;
            this.btnAdd.UseCompatibleTextRendering = true;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.IconID = 11;
            this.btnRemove.Location = new System.Drawing.Point(419, 285);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(28, 24);
            this.btnRemove.TabIndex = 28;
            this.btnRemove.UseCompatibleTextRendering = true;
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAddAll
            // 
            this.btnAddAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAll.IconID = 14;
            this.btnAddAll.Location = new System.Drawing.Point(419, 315);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(28, 24);
            this.btnAddAll.TabIndex = 29;
            this.btnAddAll.UseCompatibleTextRendering = true;
            this.btnAddAll.UseVisualStyleBackColor = false;
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAll.IconID = 12;
            this.btnRemoveAll.Location = new System.Drawing.Point(419, 345);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(28, 24);
            this.btnRemoveAll.TabIndex = 30;
            this.btnRemoveAll.UseCompatibleTextRendering = true;
            this.btnRemoveAll.UseVisualStyleBackColor = false;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // lblFilterVerfuegbar
            // 
            this.lblFilterVerfuegbar.Location = new System.Drawing.Point(150, 395);
            this.lblFilterVerfuegbar.Name = "lblFilterVerfuegbar";
            this.lblFilterVerfuegbar.Size = new System.Drawing.Size(35, 24);
            this.lblFilterVerfuegbar.TabIndex = 25;
            this.lblFilterVerfuegbar.Text = "Filter";
            this.lblFilterVerfuegbar.UseCompatibleTextRendering = true;
            // 
            // lblKOALeer
            // 
            this.lblKOALeer.Location = new System.Drawing.Point(460, 211);
            this.lblKOALeer.Name = "lblKOALeer";
            this.lblKOALeer.Size = new System.Drawing.Size(144, 24);
            this.lblKOALeer.TabIndex = 22;
            this.lblKOALeer.Text = "(leer = alle Kostenarten)";
            this.lblKOALeer.UseCompatibleTextRendering = true;
            // 
            // lblFilterZugeteilt
            // 
            this.lblFilterZugeteilt.Location = new System.Drawing.Point(460, 396);
            this.lblFilterZugeteilt.Name = "lblFilterZugeteilt";
            this.lblFilterZugeteilt.Size = new System.Drawing.Size(35, 24);
            this.lblFilterZugeteilt.TabIndex = 32;
            this.lblFilterZugeteilt.Text = "Filter";
            this.lblFilterZugeteilt.UseCompatibleTextRendering = true;
            // 
            // colBetrag
            // 
            this.colBetrag.AppearanceCell.Options.UseTextOptions = true;
            this.colBetrag.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colBetrag.Caption = "Soll";
            this.colBetrag.DisplayFormat.FormatString = "n2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.SummaryItem.DisplayFormat = "{0:n2}";
            this.colBetrag.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 3;
            // 
            // colBetragEffektiv
            // 
            this.colBetragEffektiv.AppearanceCell.Options.UseTextOptions = true;
            this.colBetragEffektiv.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colBetragEffektiv.Caption = "Summe ZE";
            this.colBetragEffektiv.DisplayFormat.FormatString = "n2";
            this.colBetragEffektiv.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetragEffektiv.FieldName = "BetragEffektiv";
            this.colBetragEffektiv.Name = "colBetragEffektiv";
            this.colBetragEffektiv.SummaryItem.DisplayFormat = "{0:n2}";
            this.colBetragEffektiv.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colBetragEffektiv.Visible = true;
            this.colBetragEffektiv.VisibleIndex = 4;
            // 
            // colErfassung
            // 
            this.colErfassung.Caption = "Belegdatum ZE";
            this.colErfassung.FieldName = "BelegDatum";
            this.colErfassung.Name = "colErfassung";
            this.colErfassung.Visible = true;
            this.colErfassung.VisibleIndex = 2;
            this.colErfassung.Width = 60;
            // 
            // colBuchungstext
            // 
            this.colBuchungstext.Caption = "Buchungstext";
            this.colBuchungstext.FieldName = "Buchungstext";
            this.colBuchungstext.Name = "colBuchungstext";
            this.colBuchungstext.Visible = true;
            this.colBuchungstext.VisibleIndex = 7;
            // 
            // colVerwBis
            // 
            this.colVerwBis.Caption = "Verw. bis";
            this.colVerwBis.FieldName = "VerwPeriodeBis";
            this.colVerwBis.Name = "colVerwBis";
            this.colVerwBis.Visible = true;
            this.colVerwBis.VisibleIndex = 9;
            // 
            // colVerwVon
            // 
            this.colVerwVon.Caption = "Verw. von";
            this.colVerwVon.FieldName = "VerwPeriodeVon";
            this.colVerwVon.Name = "colVerwVon";
            this.colVerwVon.Visible = true;
            this.colVerwVon.VisibleIndex = 8;
            // 
            // colDiff
            // 
            this.colDiff.AppearanceCell.Options.UseTextOptions = true;
            this.colDiff.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colDiff.Caption = "Diff.";
            this.colDiff.DisplayFormat.FormatString = "n2";
            this.colDiff.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDiff.FieldName = "Diff";
            this.colDiff.Name = "colDiff";
            this.colDiff.SummaryItem.DisplayFormat = "{0:n2}";
            this.colDiff.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colDiff.Visible = true;
            this.colDiff.VisibleIndex = 5;
            // 
            // colFaFallID
            // 
            this.colFaFallID.Caption = "Fall-Nr.";
            this.colFaFallID.FieldName = "FaFallID";
            this.colFaFallID.Name = "colFaFallID";
            this.colFaFallID.Visible = true;
            this.colFaFallID.VisibleIndex = 0;
            this.colFaFallID.Width = 60;
            // 
            // colKOA
            // 
            this.colKOA.Caption = "KOA";
            this.colKOA.FieldName = "KontoNr";
            this.colKOA.Name = "colKOA";
            this.colKOA.Visible = true;
            this.colKOA.VisibleIndex = 6;
            this.colKOA.Width = 42;
            // 
            // colName
            // 
            this.colName.Caption = "Klient/in";
            this.colName.FieldName = "DisplayText";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 152;
            // 
            // colSAR
            // 
            this.colSAR.Caption = "SAR";
            this.colSAR.FieldName = "SAR";
            this.colSAR.Name = "colSAR";
            this.colSAR.Visible = true;
            this.colSAR.VisibleIndex = 10;
            // 
            // colSektion
            // 
            this.colSektion.Caption = "Sektion";
            this.colSektion.FieldName = "Sektion";
            this.colSektion.Name = "colSektion";
            this.colSektion.Visible = true;
            this.colSektion.VisibleIndex = 11;
            // 
            // grvMain
            // 
            this.grvMain.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvMain.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMain.Appearance.Empty.Options.UseBackColor = true;
            this.grvMain.Appearance.Empty.Options.UseFont = true;
            this.grvMain.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMain.Appearance.EvenRow.Options.UseFont = true;
            this.grvMain.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvMain.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMain.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvMain.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvMain.Appearance.FocusedCell.Options.UseFont = true;
            this.grvMain.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvMain.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvMain.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMain.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvMain.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvMain.Appearance.FocusedRow.Options.UseFont = true;
            this.grvMain.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvMain.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvMain.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvMain.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvMain.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvMain.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvMain.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvMain.Appearance.GroupRow.Options.UseFont = true;
            this.grvMain.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvMain.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvMain.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvMain.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvMain.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvMain.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvMain.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvMain.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvMain.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMain.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvMain.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvMain.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvMain.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvMain.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvMain.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvMain.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMain.Appearance.OddRow.Options.UseFont = true;
            this.grvMain.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvMain.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMain.Appearance.Row.Options.UseBackColor = true;
            this.grvMain.Appearance.Row.Options.UseFont = true;
            this.grvMain.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMain.Appearance.SelectedRow.Options.UseFont = true;
            this.grvMain.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvMain.Appearance.VertLine.Options.UseBackColor = true;
            this.grvMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvMain.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFaFallID,
            this.colName,
            this.colErfassung,
            this.colBelegNr,
            this.colBetrag,
            this.colBetragEffektiv,
            this.colDiff,
            this.colKOA,
            this.colBuchungstext,
            this.colVerwVon,
            this.colVerwBis,
            this.colSAR,
            this.colSektion,
            this.colBemerkungSaldierung,
            this.colSaldiert});
            this.grvMain.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvMain.GridControl = this.grdQuery1;
            this.grvMain.Name = "grvMain";
            this.grvMain.OptionsBehavior.Editable = false;
            this.grvMain.OptionsDetail.ShowDetailTabs = false;
            this.grvMain.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvMain.OptionsNavigation.AutoFocusNewRow = true;
            this.grvMain.OptionsNavigation.UseTabKey = false;
            this.grvMain.OptionsView.ColumnAutoWidth = false;
            this.grvMain.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvMain.OptionsView.ShowGroupPanel = false;
            this.grvMain.OptionsView.ShowIndicator = false;
            this.grvMain.MasterRowExpanded += new DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventHandler(this.grvMain_MasterRowExpanded);
            // 
            // colBelegNr
            // 
            this.colBelegNr.Caption = "BelegNr";
            this.colBelegNr.FieldName = "BelegNr";
            this.colBelegNr.Name = "colBelegNr";
            // 
            // colBemerkungSaldierung
            // 
            this.colBemerkungSaldierung.Caption = "BemerkungSaldierung";
            this.colBemerkungSaldierung.FieldName = "BemerkungSaldierung";
            this.colBemerkungSaldierung.Name = "colBemerkungSaldierung";
            this.colBemerkungSaldierung.Visible = true;
            this.colBemerkungSaldierung.VisibleIndex = 12;
            // 
            // colSaldiert
            // 
            this.colSaldiert.Caption = "Saldiert";
            this.colSaldiert.FieldName = "Saldiert";
            this.colSaldiert.Name = "colSaldiert";
            this.colSaldiert.Visible = true;
            this.colSaldiert.VisibleIndex = 13;
            // 
            // lblSuchNachS
            // 
            this.lblSuchNachS.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblSuchNachS.Location = new System.Drawing.Point(260, 11);
            this.lblSuchNachS.Name = "lblSuchNachS";
            this.lblSuchNachS.Size = new System.Drawing.Size(149, 16);
            this.lblSuchNachS.TabIndex = 3;
            this.lblSuchNachS.Text = "Suche nach ...";
            this.lblSuchNachS.UseCompatibleTextRendering = true;
            // 
            // lblSAR
            // 
            this.lblSAR.Location = new System.Drawing.Point(10, 65);
            this.lblSAR.Name = "lblSAR";
            this.lblSAR.Size = new System.Drawing.Size(113, 24);
            this.lblSAR.TabIndex = 3;
            this.lblSAR.Text = "SAR";
            this.lblSAR.UseCompatibleTextRendering = true;
            // 
            // lblSektion
            // 
            this.lblSektion.Location = new System.Drawing.Point(10, 35);
            this.lblSektion.Name = "lblSektion";
            this.lblSektion.Size = new System.Drawing.Size(113, 24);
            this.lblSektion.TabIndex = 1;
            this.lblSektion.Text = "Sektion";
            this.lblSektion.UseCompatibleTextRendering = true;
            // 
            // edtUserID
            // 
            this.edtUserID.Location = new System.Drawing.Point(150, 65);
            this.edtUserID.Name = "edtUserID";
            this.edtUserID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserID.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserID.Properties.Appearance.Options.UseFont = true;
            this.edtUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtUserID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtUserID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserID.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtUserID.Size = new System.Drawing.Size(257, 24);
            this.edtUserID.TabIndex = 4;
            this.edtUserID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtUserID_UserModifiedFld);
            // 
            // edtOrgUnitID
            // 
            this.edtOrgUnitID.Location = new System.Drawing.Point(150, 35);
            this.edtOrgUnitID.Name = "edtOrgUnitID";
            this.edtOrgUnitID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtOrgUnitID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtOrgUnitID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrgUnitID.Properties.Appearance.Options.UseBackColor = true;
            this.edtOrgUnitID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtOrgUnitID.Properties.Appearance.Options.UseFont = true;
            this.edtOrgUnitID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtOrgUnitID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrgUnitID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtOrgUnitID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtOrgUnitID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtOrgUnitID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtOrgUnitID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtOrgUnitID.Properties.NullText = "";
            this.edtOrgUnitID.Properties.ShowFooter = false;
            this.edtOrgUnitID.Properties.ShowHeader = false;
            this.edtOrgUnitID.Size = new System.Drawing.Size(257, 24);
            this.edtOrgUnitID.TabIndex = 2;
            // 
            // panelDetail
            // 
            this.panelDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDetail.Controls.Add(this.edtBemerkungSaldierung);
            this.panelDetail.Controls.Add(this.lblBemerkungSaldierung);
            this.panelDetail.Controls.Add(this.edtSaldiert);
            this.panelDetail.Location = new System.Drawing.Point(8, 495);
            this.panelDetail.Name = "panelDetail";
            this.panelDetail.Size = new System.Drawing.Size(789, 140);
            this.panelDetail.TabIndex = 6;
            // 
            // edtBemerkungSaldierung
            // 
            this.edtBemerkungSaldierung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBemerkungSaldierung.DataSource = this.qryQuery;
            this.edtBemerkungSaldierung.Location = new System.Drawing.Point(9, 52);
            this.edtBemerkungSaldierung.Name = "edtBemerkungSaldierung";
            this.edtBemerkungSaldierung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkungSaldierung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkungSaldierung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkungSaldierung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkungSaldierung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkungSaldierung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkungSaldierung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkungSaldierung.Size = new System.Drawing.Size(772, 80);
            this.edtBemerkungSaldierung.TabIndex = 2;
            // 
            // lblBemerkungSaldierung
            // 
            this.lblBemerkungSaldierung.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBemerkungSaldierung.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblBemerkungSaldierung.Location = new System.Drawing.Point(9, 31);
            this.lblBemerkungSaldierung.Name = "lblBemerkungSaldierung";
            this.lblBemerkungSaldierung.Size = new System.Drawing.Size(174, 21);
            this.lblBemerkungSaldierung.TabIndex = 1;
            this.lblBemerkungSaldierung.Text = "Bemerkungen";
            // 
            // edtSaldiert
            // 
            this.edtSaldiert.DataSource = this.qryQuery;
            this.edtSaldiert.EditValue = false;
            this.edtSaldiert.Location = new System.Drawing.Point(9, 9);
            this.edtSaldiert.Name = "edtSaldiert";
            this.edtSaldiert.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSaldiert.Properties.Appearance.Options.UseBackColor = true;
            this.edtSaldiert.Properties.Caption = "saldiert";
            this.edtSaldiert.Size = new System.Drawing.Size(131, 19);
            this.edtSaldiert.TabIndex = 0;
            // 
            // lblVerwPerVon
            // 
            this.lblVerwPerVon.Location = new System.Drawing.Point(416, 35);
            this.lblVerwPerVon.Name = "lblVerwPerVon";
            this.lblVerwPerVon.Size = new System.Drawing.Size(87, 24);
            this.lblVerwPerVon.TabIndex = 13;
            this.lblVerwPerVon.Text = "Verw. Periode";
            // 
            // edtPeriodeVon
            // 
            this.edtPeriodeVon.EditValue = null;
            this.edtPeriodeVon.Location = new System.Drawing.Point(502, 35);
            this.edtPeriodeVon.Name = "edtPeriodeVon";
            this.edtPeriodeVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtPeriodeVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPeriodeVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPeriodeVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPeriodeVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtPeriodeVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPeriodeVon.Properties.Appearance.Options.UseFont = true;
            this.edtPeriodeVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtPeriodeVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtPeriodeVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtPeriodeVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPeriodeVon.Properties.ShowToday = false;
            this.edtPeriodeVon.Size = new System.Drawing.Size(100, 24);
            this.edtPeriodeVon.TabIndex = 14;
            // 
            // edtPeriodeBis
            // 
            this.edtPeriodeBis.EditValue = null;
            this.edtPeriodeBis.Location = new System.Drawing.Point(660, 35);
            this.edtPeriodeBis.Name = "edtPeriodeBis";
            this.edtPeriodeBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtPeriodeBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPeriodeBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPeriodeBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPeriodeBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtPeriodeBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPeriodeBis.Properties.Appearance.Options.UseFont = true;
            this.edtPeriodeBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtPeriodeBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtPeriodeBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtPeriodeBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPeriodeBis.Properties.ShowToday = false;
            this.edtPeriodeBis.Size = new System.Drawing.Size(100, 24);
            this.edtPeriodeBis.TabIndex = 16;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Sektion";
            this.gridColumn1.FieldName = "Sektion";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 12;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "SAR";
            this.gridColumn2.FieldName = "SAR";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 11;
            // 
            // edtFoderungsTyp
            // 
            this.edtFoderungsTyp.EditValue = null;
            this.edtFoderungsTyp.Location = new System.Drawing.Point(502, 95);
            this.edtFoderungsTyp.LookupSQL = null;
            this.edtFoderungsTyp.LOVFilter = null;
            this.edtFoderungsTyp.LOVName = null;
            this.edtFoderungsTyp.Name = "edtFoderungsTyp";
            this.edtFoderungsTyp.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtFoderungsTyp.Properties.Appearance.Options.UseBackColor = true;
            this.edtFoderungsTyp.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.edtFoderungsTyp.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.edtFoderungsTyp.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0D, "alle"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1D, "nur ausgeglichene"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2D, "nicht ausgeglichene"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(3D, "teilausgeglichene")});
            this.edtFoderungsTyp.Size = new System.Drawing.Size(126, 73);
            this.edtFoderungsTyp.TabIndex = 18;
            // 
            // lblForderungen
            // 
            this.lblForderungen.Location = new System.Drawing.Point(416, 95);
            this.lblForderungen.Name = "lblForderungen";
            this.lblForderungen.Size = new System.Drawing.Size(71, 24);
            this.lblForderungen.TabIndex = 17;
            this.lblForderungen.Text = "Forderung";
            // 
            // edtSaldierungSuche
            // 
            this.edtSaldierungSuche.EditValue = null;
            this.edtSaldierungSuche.Location = new System.Drawing.Point(634, 95);
            this.edtSaldierungSuche.LookupSQL = null;
            this.edtSaldierungSuche.LOVFilter = null;
            this.edtSaldierungSuche.LOVName = null;
            this.edtSaldierungSuche.Name = "edtSaldierungSuche";
            this.edtSaldierungSuche.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtSaldierungSuche.Properties.Appearance.Options.UseBackColor = true;
            this.edtSaldierungSuche.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.edtSaldierungSuche.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.edtSaldierungSuche.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0D, "alle"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1D, "nur saldierte"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2D, "nicht saldierte")});
            this.edtSaldierungSuche.Size = new System.Drawing.Size(126, 73);
            this.edtSaldierungSuche.TabIndex = 19;
            // 
            // edtFalltraeger
            // 
            this.edtFalltraeger.Location = new System.Drawing.Point(150, 125);
            this.edtFalltraeger.Name = "edtFalltraeger";
            this.edtFalltraeger.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFalltraeger.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFalltraeger.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFalltraeger.Properties.Appearance.Options.UseBackColor = true;
            this.edtFalltraeger.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFalltraeger.Properties.Appearance.Options.UseFont = true;
            this.edtFalltraeger.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtFalltraeger.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtFalltraeger.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFalltraeger.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtFalltraeger.Size = new System.Drawing.Size(257, 24);
            this.edtFalltraeger.TabIndex = 8;
            this.edtFalltraeger.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtFalltraeger_UserModifiedFld);
            // 
            // lblForderungDatum
            // 
            this.lblForderungDatum.Location = new System.Drawing.Point(10, 185);
            this.lblForderungDatum.Name = "lblForderungDatum";
            this.lblForderungDatum.Size = new System.Drawing.Size(134, 24);
            this.lblForderungDatum.TabIndex = 34;
            this.lblForderungDatum.Text = "Forderung (Valutadatum)";
            this.lblForderungDatum.UseCompatibleTextRendering = true;
            // 
            // edtForderungDatumBis
            // 
            this.edtForderungDatumBis.EditValue = null;
            this.edtForderungDatumBis.Location = new System.Drawing.Point(307, 184);
            this.edtForderungDatumBis.Name = "edtForderungDatumBis";
            this.edtForderungDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtForderungDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtForderungDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtForderungDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtForderungDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtForderungDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtForderungDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtForderungDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtForderungDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtForderungDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtForderungDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtForderungDatumBis.Properties.ShowToday = false;
            this.edtForderungDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtForderungDatumBis.TabIndex = 37;
            // 
            // edtForderungDatumVon
            // 
            this.edtForderungDatumVon.EditValue = null;
            this.edtForderungDatumVon.Location = new System.Drawing.Point(150, 185);
            this.edtForderungDatumVon.Name = "edtForderungDatumVon";
            this.edtForderungDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtForderungDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtForderungDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtForderungDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtForderungDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtForderungDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtForderungDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtForderungDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtForderungDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtForderungDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtForderungDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtForderungDatumVon.Properties.ShowToday = false;
            this.edtForderungDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtForderungDatumVon.TabIndex = 35;
            // 
            // lblForderungDatumBis
            // 
            this.lblForderungDatumBis.Location = new System.Drawing.Point(264, 185);
            this.lblForderungDatumBis.Name = "lblForderungDatumBis";
            this.lblForderungDatumBis.Size = new System.Drawing.Size(23, 24);
            this.lblForderungDatumBis.TabIndex = 36;
            this.lblForderungDatumBis.Text = "bis";
            this.lblForderungDatumBis.UseCompatibleTextRendering = true;
            // 
            // edtBudgetVon
            // 
            this.edtBudgetVon.EditValue = null;
            this.edtBudgetVon.Location = new System.Drawing.Point(502, 65);
            this.edtBudgetVon.Name = "edtBudgetVon";
            this.edtBudgetVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBudgetVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBudgetVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBudgetVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBudgetVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtBudgetVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBudgetVon.Properties.Appearance.Options.UseFont = true;
            this.edtBudgetVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtBudgetVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtBudgetVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtBudgetVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBudgetVon.Properties.DisplayFormat.FormatString = "MM.yyyy";
            this.edtBudgetVon.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtBudgetVon.Properties.EditFormat.FormatString = "MM.yyyy";
            this.edtBudgetVon.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtBudgetVon.Properties.Mask.EditMask = "MM.yyyy";
            this.edtBudgetVon.Properties.ShowToday = false;
            this.edtBudgetVon.Size = new System.Drawing.Size(100, 24);
            this.edtBudgetVon.TabIndex = 38;
            // 
            // lblBudgetBis
            // 
            this.lblBudgetBis.Location = new System.Drawing.Point(617, 65);
            this.lblBudgetBis.Name = "lblBudgetBis";
            this.lblBudgetBis.Size = new System.Drawing.Size(23, 24);
            this.lblBudgetBis.TabIndex = 39;
            this.lblBudgetBis.Text = "bis";
            this.lblBudgetBis.UseCompatibleTextRendering = true;
            // 
            // edtBudgetBis
            // 
            this.edtBudgetBis.EditValue = null;
            this.edtBudgetBis.Location = new System.Drawing.Point(660, 65);
            this.edtBudgetBis.Name = "edtBudgetBis";
            this.edtBudgetBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBudgetBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBudgetBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBudgetBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBudgetBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtBudgetBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBudgetBis.Properties.Appearance.Options.UseFont = true;
            this.edtBudgetBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtBudgetBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtBudgetBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtBudgetBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBudgetBis.Properties.DisplayFormat.FormatString = "MM.yyyy";
            this.edtBudgetBis.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtBudgetBis.Properties.EditFormat.FormatString = "MM.yyyy";
            this.edtBudgetBis.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtBudgetBis.Properties.Mask.EditMask = "MM.yyyy";
            this.edtBudgetBis.Properties.ShowToday = false;
            this.edtBudgetBis.Size = new System.Drawing.Size(100, 24);
            this.edtBudgetBis.TabIndex = 40;
            // 
            // lblBudget
            // 
            this.lblBudget.Location = new System.Drawing.Point(416, 65);
            this.lblBudget.Name = "lblBudget";
            this.lblBudget.Size = new System.Drawing.Size(71, 24);
            this.lblBudget.TabIndex = 41;
            this.lblBudget.Text = "Budget";
            // 
            // kissLabel1
            // 
            this.kissLabel1.Location = new System.Drawing.Point(617, 35);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(23, 24);
            this.kissLabel1.TabIndex = 42;
            this.kissLabel1.Text = "bis";
            this.kissLabel1.UseCompatibleTextRendering = true;
            // 
            // CtlQueryWhZahlungseingaenge
            // 
            this.Controls.Add(this.panelDetail);
            this.Controls.Add(this.lblSuchNachS);
            this.Name = "CtlQueryWhZahlungseingaenge";
            this.Size = new System.Drawing.Size(800, 638);
            this.Load += new System.EventHandler(this.CtlQueryWhZahlungseingaenge_Load);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.lblSuchNachS, 0);
            this.Controls.SetChildIndex(this.panelDetail, 0);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZEDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZEDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZEDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZEDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFalltraeger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAktiveS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInaktiveS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKOA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVerfugbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterVerfuegbar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterZugeteilt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilterVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKOALeer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilterZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchNachS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSektion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnitID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnitID)).EndInit();
            this.panelDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkungSaldierung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungSaldierung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSaldiert.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwPerVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPeriodeVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPeriodeBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFoderungsTyp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFoderungsTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblForderungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSaldierungSuche.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSaldierungSuche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFalltraeger.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblForderungDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtForderungDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtForderungDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblForderungDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBudgetVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBudgetBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBudgetBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KiSS4.Gui.KissButton btnAdd;
        private KiSS4.Gui.KissButton btnAddAll;
        private KiSS4.Gui.KissButton btnMonatsbudget;
        private KiSS4.Gui.KissButton btnRemove;
        private KiSS4.Gui.KissButton btnRemoveAll;
        private DevExpress.XtraGrid.Columns.GridColumn colBelegNr;
        private DevExpress.XtraGrid.Columns.GridColumn colBemerkungSaldierung;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBetragEffektiv;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungstext;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailBetragEffektiv;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailDiff;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailErfassung;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailVerwBis;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailVerwVon;
        private DevExpress.XtraGrid.Columns.GridColumn colDiff;
        private DevExpress.XtraGrid.Columns.GridColumn colErfassung;
        private DevExpress.XtraGrid.Columns.GridColumn colFaFallID;
        private DevExpress.XtraGrid.Columns.GridColumn colKOA;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colSAR;
        private DevExpress.XtraGrid.Columns.GridColumn colSaldiert;
        private DevExpress.XtraGrid.Columns.GridColumn colSektion;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
        private DevExpress.XtraGrid.Columns.GridColumn colUserText;
        private DevExpress.XtraGrid.Columns.GridColumn colVerwBis;
        private DevExpress.XtraGrid.Columns.GridColumn colVerwVon;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissCheckEdit edtAktiveS;
        private KiSS4.Gui.KissMemoEdit edtBemerkungSaldierung;
        private KiSS4.Gui.KissDateEdit edtZEDatumBis;
        private KiSS4.Gui.KissDateEdit edtZEDatumVon;
        private KiSS4.Gui.KissTextEdit edtFilterVerfuegbar;
        private KiSS4.Gui.KissTextEdit edtFilterZugeteilt;
        private KiSS4.Gui.KissRadioGroup edtFoderungsTyp;
        private KiSS4.Gui.KissCheckEdit edtInaktiveS;
        private KiSS4.Gui.KissLookUpEdit edtOrgUnitID;
        private KiSS4.Gui.KissDateEdit edtPeriodeBis;
        private KiSS4.Gui.KissDateEdit edtPeriodeVon;
        private KiSS4.Gui.KissCheckEdit edtSaldiert;
        private KiSS4.Gui.KissButtonEdit edtUserID;
        private KiSS4.Gui.KissButtonEdit edtBaPerson;
        private KiSS4.Gui.KissGrid grdVerfuegbar;
        private KiSS4.Gui.KissGrid grdZugeteilt;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView grvMain;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVerfugbar;
        private DevExpress.XtraGrid.Views.Grid.GridView grvZugeteilt;
        private KiSS4.Gui.KissLabel lblBemerkungSaldierung;
        private KiSS4.Gui.KissLabel lblZEDatumBis;
        private KiSS4.Gui.KissLabel lblZEDatum;
        private KiSS4.Gui.KissLabel lblFalltraeger;
        private KiSS4.Gui.KissLabel lblFilterVerfuegbar;
        private KiSS4.Gui.KissLabel lblFilterZugeteilt;
        private KiSS4.Gui.KissLabel lblForderungen;
        private KiSS4.Gui.KissLabel lblKOA;
        private KiSS4.Gui.KissLabel lblKOALeer;
        private KiSS4.Gui.KissLabel lblSAR;
        private KiSS4.Gui.KissLabel lblSektion;
        private KiSS4.Gui.KissLabel lblSuchNachS;
        private KiSS4.Gui.KissLabel lblVerwPerVon;
        private KiSS4.Gui.KissLabel lblBaPerson;
        private System.Windows.Forms.Panel panelDetail;
        private KiSS4.DB.SqlQuery qryVerfuegbar;
        private KiSS4.DB.SqlQuery qryZugeteilt;
        private Gui.KissRadioGroup edtSaldierungSuche;
        private Gui.KissButtonEdit edtFalltraeger;
        private Gui.KissDateEdit edtForderungDatumBis;
        private Gui.KissDateEdit edtForderungDatumVon;
        private Gui.KissLabel lblForderungDatumBis;
        private Gui.KissLabel lblForderungDatum;
        private Gui.KissLabel kissLabel1;
        private Gui.KissLabel lblBudget;
        private Gui.KissDateEdit edtBudgetBis;
        private Gui.KissLabel lblBudgetBis;
        private Gui.KissDateEdit edtBudgetVon;
    }
}