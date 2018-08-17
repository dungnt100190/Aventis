namespace KiSS4.Query.ZH
{
    partial class CtlQueryWhRechnungsnummer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryWhRechnungsnummer));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grvPositionDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDetailVerwPeriodeVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailVerwPeriodeBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailBudget = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailKontoNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailBuchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailKreditor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colDetailEffektiv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtSucheRechnungsnummer = new KiSS4.Gui.KissTextEdit();
            this.lblRechnungsnummer = new KiSS4.Gui.KissLabel();
            this.grvQuery = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRechnungsnummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaFallID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerwPeriodeVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerwPeriodeBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBudget = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKontoNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDokument = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKreditor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEffektiv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusImage = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.grdDocuments = new KiSS4.Gui.KissGrid();
            this.grvDocuments = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStichwort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErstellungsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLetzteSpeicherung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.qryDocuments = new KiSS4.DB.SqlQuery(this.components);
            this.btnBudgetPosition = new KiSS4.Gui.KissButton();
            this.lblDokumente = new KiSS4.Gui.KissLabel();
            this.edtSucheRechnungDatum = new KiSS4.Gui.KissDateEdit();
            this.lblRechnungDatum = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvPositionDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheRechnungsnummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechnungsnummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colStatusImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDocuments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDocuments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryDocuments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokumente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheRechnungDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechnungDatum)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            this.qryQuery.TableName = "BgPosition";
            this.qryQuery.AfterFill += new System.EventHandler(this.qryQuery_AfterFill);
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
            gridLevelNode1.LevelTemplate = this.grvPositionDetail;
            gridLevelNode1.RelationName = "PositionDetail";
            this.grdQuery1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdQuery1.MainView = this.grvQuery;
            this.grdQuery1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.colStatusImage,
            this.repositoryItemImageComboBox1});
            this.grdQuery1.Size = new System.Drawing.Size(766, 263);
            this.grdQuery1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPositionDetail,
            this.grvQuery});
            this.grdQuery1.ViewRegistered += new DevExpress.XtraGrid.ViewOperationEventHandler(this.grdQuery1_ViewRegistered);
            // 
            // xDocument
            // 
            this.xDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.xDocument.DataMember = "DocumentID";
            this.xDocument.DataSource = this.qryDocuments;
            this.xDocument.EditValue = null;
            this.xDocument.Location = new System.Drawing.Point(633, 397);
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = "BaPersonID_FAL";
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdDocuments);
            this.tpgListe.Controls.Add(this.lblDokumente);
            this.tpgListe.Controls.Add(this.btnBudgetPosition);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Controls.SetChildIndex(this.btnBudgetPosition, 0);
            this.tpgListe.Controls.SetChildIndex(this.lblDokumente, 0);
            this.tpgListe.Controls.SetChildIndex(this.xDocument, 0);
            this.tpgListe.Controls.SetChildIndex(this.grdDocuments, 0);
            this.tpgListe.Controls.SetChildIndex(this.grdQuery1, 0);
            this.tpgListe.Controls.SetChildIndex(this.ctlGotoFall, 0);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.lblRechnungDatum);
            this.tpgSuchen.Controls.Add(this.edtSucheRechnungDatum);
            this.tpgSuchen.Controls.Add(this.lblRechnungsnummer);
            this.tpgSuchen.Controls.Add(this.edtSucheRechnungsnummer);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheRechnungsnummer, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblRechnungsnummer, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheRechnungDatum, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblRechnungDatum, 0);
            // 
            // grvPositionDetail
            // 
            this.grvPositionDetail.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.grvPositionDetail.Appearance.Empty.Options.UseBackColor = true;
            this.grvPositionDetail.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvPositionDetail.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPositionDetail.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvPositionDetail.Appearance.EvenRow.Options.UseFont = true;
            this.grvPositionDetail.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvPositionDetail.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPositionDetail.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvPositionDetail.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvPositionDetail.Appearance.FocusedCell.Options.UseFont = true;
            this.grvPositionDetail.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvPositionDetail.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPositionDetail.Appearance.FocusedRow.Options.UseFont = true;
            this.grvPositionDetail.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvPositionDetail.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvPositionDetail.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvPositionDetail.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvPositionDetail.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvPositionDetail.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvPositionDetail.Appearance.GroupRow.Options.UseFont = true;
            this.grvPositionDetail.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvPositionDetail.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvPositionDetail.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvPositionDetail.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvPositionDetail.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvPositionDetail.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvPositionDetail.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvPositionDetail.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvPositionDetail.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPositionDetail.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvPositionDetail.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvPositionDetail.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvPositionDetail.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvPositionDetail.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvPositionDetail.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPositionDetail.Appearance.OddRow.Options.UseBackColor = true;
            this.grvPositionDetail.Appearance.OddRow.Options.UseFont = true;
            this.grvPositionDetail.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvPositionDetail.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPositionDetail.Appearance.Row.Options.UseBackColor = true;
            this.grvPositionDetail.Appearance.Row.Options.UseFont = true;
            this.grvPositionDetail.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvPositionDetail.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPositionDetail.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvPositionDetail.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvPositionDetail.Appearance.SelectedRow.Options.UseFont = true;
            this.grvPositionDetail.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvPositionDetail.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvPositionDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDetailVerwPeriodeVon,
            this.colDetailVerwPeriodeBis,
            this.colDetailBudget,
            this.colDetailKontoNr,
            this.colDetailBuchungstext,
            this.colDetailPerson,
            this.colDetailBetrag,
            this.colDetailKreditor,
            this.colDetailStatus,
            this.colDetailEffektiv});
            this.grvPositionDetail.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvPositionDetail.GridControl = this.grdQuery1;
            this.grvPositionDetail.Name = "grvPositionDetail";
            this.grvPositionDetail.OptionsBehavior.Editable = false;
            this.grvPositionDetail.OptionsCustomization.AllowFilter = false;
            this.grvPositionDetail.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvPositionDetail.OptionsNavigation.AutoFocusNewRow = true;
            this.grvPositionDetail.OptionsNavigation.UseTabKey = false;
            this.grvPositionDetail.OptionsView.ColumnAutoWidth = false;
            this.grvPositionDetail.OptionsView.ShowGroupPanel = false;
            this.grvPositionDetail.OptionsView.ShowIndicator = false;
            // 
            // colDetailVerwPeriodeVon
            // 
            this.colDetailVerwPeriodeVon.Caption = "Verw. von";
            this.colDetailVerwPeriodeVon.FieldName = "VerwPeriodeVon";
            this.colDetailVerwPeriodeVon.Name = "colDetailVerwPeriodeVon";
            this.colDetailVerwPeriodeVon.Visible = true;
            this.colDetailVerwPeriodeVon.VisibleIndex = 0;
            // 
            // colDetailVerwPeriodeBis
            // 
            this.colDetailVerwPeriodeBis.Caption = "Verw. bis";
            this.colDetailVerwPeriodeBis.FieldName = "VerwPeriodeBis";
            this.colDetailVerwPeriodeBis.Name = "colDetailVerwPeriodeBis";
            this.colDetailVerwPeriodeBis.Visible = true;
            this.colDetailVerwPeriodeBis.VisibleIndex = 1;
            // 
            // colDetailBudget
            // 
            this.colDetailBudget.Caption = "Budget";
            this.colDetailBudget.FieldName = "Budget";
            this.colDetailBudget.Name = "colDetailBudget";
            this.colDetailBudget.Visible = true;
            this.colDetailBudget.VisibleIndex = 2;
            // 
            // colDetailKontoNr
            // 
            this.colDetailKontoNr.Caption = "LA";
            this.colDetailKontoNr.FieldName = "KontoNr";
            this.colDetailKontoNr.Name = "colDetailKontoNr";
            this.colDetailKontoNr.Visible = true;
            this.colDetailKontoNr.VisibleIndex = 3;
            // 
            // colDetailBuchungstext
            // 
            this.colDetailBuchungstext.Caption = "Buchungstext";
            this.colDetailBuchungstext.FieldName = "Buchungstext";
            this.colDetailBuchungstext.Name = "colDetailBuchungstext";
            this.colDetailBuchungstext.Visible = true;
            this.colDetailBuchungstext.VisibleIndex = 4;
            // 
            // colDetailPerson
            // 
            this.colDetailPerson.Caption = "Betroffene Person";
            this.colDetailPerson.FieldName = "Person";
            this.colDetailPerson.Name = "colDetailPerson";
            this.colDetailPerson.Visible = true;
            this.colDetailPerson.VisibleIndex = 5;
            // 
            // colDetailBetrag
            // 
            this.colDetailBetrag.Caption = "Betrag";
            this.colDetailBetrag.DisplayFormat.FormatString = "N2";
            this.colDetailBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDetailBetrag.FieldName = "Betrag";
            this.colDetailBetrag.Name = "colDetailBetrag";
            this.colDetailBetrag.Visible = true;
            this.colDetailBetrag.VisibleIndex = 6;
            // 
            // colDetailKreditor
            // 
            this.colDetailKreditor.Caption = "Kreditor";
            this.colDetailKreditor.FieldName = "Kreditor";
            this.colDetailKreditor.Name = "colDetailKreditor";
            this.colDetailKreditor.Visible = true;
            this.colDetailKreditor.VisibleIndex = 7;
            // 
            // colDetailStatus
            // 
            this.colDetailStatus.Caption = "Stat";
            this.colDetailStatus.ColumnEdit = this.repositoryItemImageComboBox1;
            this.colDetailStatus.FieldName = "Status";
            this.colDetailStatus.Name = "colDetailStatus";
            this.colDetailStatus.Visible = true;
            this.colDetailStatus.VisibleIndex = 8;
            this.colDetailStatus.Width = 31;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // colDetailEffektiv
            // 
            this.colDetailEffektiv.Caption = "Effektiv";
            this.colDetailEffektiv.FieldName = "Effektiv";
            this.colDetailEffektiv.Name = "colDetailEffektiv";
            this.colDetailEffektiv.Visible = true;
            this.colDetailEffektiv.VisibleIndex = 9;
            // 
            // edtSucheRechnungsnummer
            // 
            this.edtSucheRechnungsnummer.Location = new System.Drawing.Point(141, 50);
            this.edtSucheRechnungsnummer.Name = "edtSucheRechnungsnummer";
            this.edtSucheRechnungsnummer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheRechnungsnummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheRechnungsnummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheRechnungsnummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheRechnungsnummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheRechnungsnummer.Properties.Appearance.Options.UseFont = true;
            this.edtSucheRechnungsnummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheRechnungsnummer.Size = new System.Drawing.Size(150, 24);
            this.edtSucheRechnungsnummer.TabIndex = 1;
            // 
            // lblRechnungsnummer
            // 
            this.lblRechnungsnummer.Location = new System.Drawing.Point(10, 50);
            this.lblRechnungsnummer.Name = "lblRechnungsnummer";
            this.lblRechnungsnummer.Size = new System.Drawing.Size(125, 24);
            this.lblRechnungsnummer.TabIndex = 2;
            this.lblRechnungsnummer.Text = "Rechnungsnummer";
            // 
            // grvQuery
            // 
            this.grvQuery.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvQuery.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery.Appearance.Empty.Options.UseBackColor = true;
            this.grvQuery.Appearance.Empty.Options.UseFont = true;
            this.grvQuery.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvQuery.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvQuery.Appearance.EvenRow.Options.UseFont = true;
            this.grvQuery.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvQuery.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvQuery.Appearance.FocusedCell.Options.UseFont = true;
            this.grvQuery.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvQuery.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvQuery.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvQuery.Appearance.FocusedRow.Options.UseFont = true;
            this.grvQuery.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvQuery.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvQuery.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvQuery.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvQuery.Appearance.GroupRow.Options.UseFont = true;
            this.grvQuery.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvQuery.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvQuery.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvQuery.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvQuery.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvQuery.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvQuery.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvQuery.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvQuery.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvQuery.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvQuery.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvQuery.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvQuery.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvQuery.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery.Appearance.OddRow.Options.UseBackColor = true;
            this.grvQuery.Appearance.OddRow.Options.UseFont = true;
            this.grvQuery.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvQuery.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery.Appearance.Row.Options.UseBackColor = true;
            this.grvQuery.Appearance.Row.Options.UseFont = true;
            this.grvQuery.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvQuery.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvQuery.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvQuery.Appearance.SelectedRow.Options.UseFont = true;
            this.grvQuery.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvQuery.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery.Appearance.VertLine.Options.UseBackColor = true;
            this.grvQuery.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvQuery.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRechnungsnummer,
            this.colFaFallID,
            this.colKlient,
            this.colVerwPeriodeVon,
            this.colVerwPeriodeBis,
            this.colBudget,
            this.colKontoNr,
            this.colBuchungstext,
            this.colPerson,
            this.colBetrag,
            this.colDokument,
            this.colKreditor,
            this.colStatus,
            this.colEffektiv});
            this.grvQuery.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvQuery.GridControl = this.grdQuery1;
            this.grvQuery.Name = "grvQuery";
            this.grvQuery.OptionsBehavior.Editable = false;
            this.grvQuery.OptionsDetail.ShowDetailTabs = false;
            this.grvQuery.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvQuery.OptionsNavigation.AutoFocusNewRow = true;
            this.grvQuery.OptionsNavigation.UseTabKey = false;
            this.grvQuery.OptionsView.ColumnAutoWidth = false;
            this.grvQuery.OptionsView.ShowChildrenInGroupPanel = true;
            this.grvQuery.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvQuery.OptionsView.ShowFooter = true;
            this.grvQuery.OptionsView.ShowGroupPanel = false;
            this.grvQuery.OptionsView.ShowIndicator = false;
            // 
            // colRechnungsnummer
            // 
            this.colRechnungsnummer.Caption = "Rg.Nr.";
            this.colRechnungsnummer.FieldName = "Rechnungsnummer";
            this.colRechnungsnummer.Name = "colRechnungsnummer";
            this.colRechnungsnummer.Visible = true;
            this.colRechnungsnummer.VisibleIndex = 0;
            // 
            // colFaFallID
            // 
            this.colFaFallID.Caption = "Fall-Nr.";
            this.colFaFallID.FieldName = "FaFallID";
            this.colFaFallID.Name = "colFaFallID";
            this.colFaFallID.Visible = true;
            this.colFaFallID.VisibleIndex = 1;
            // 
            // colKlient
            // 
            this.colKlient.Caption = "Klient/in";
            this.colKlient.FieldName = "Klient";
            this.colKlient.Name = "colKlient";
            this.colKlient.Visible = true;
            this.colKlient.VisibleIndex = 2;
            // 
            // colVerwPeriodeVon
            // 
            this.colVerwPeriodeVon.Caption = "Verw. von";
            this.colVerwPeriodeVon.FieldName = "VerwPeriodeVon";
            this.colVerwPeriodeVon.Name = "colVerwPeriodeVon";
            this.colVerwPeriodeVon.Visible = true;
            this.colVerwPeriodeVon.VisibleIndex = 3;
            // 
            // colVerwPeriodeBis
            // 
            this.colVerwPeriodeBis.Caption = "Verw. bis";
            this.colVerwPeriodeBis.FieldName = "VerwPeriodeBis";
            this.colVerwPeriodeBis.Name = "colVerwPeriodeBis";
            this.colVerwPeriodeBis.Visible = true;
            this.colVerwPeriodeBis.VisibleIndex = 4;
            // 
            // colBudget
            // 
            this.colBudget.Caption = "Budget";
            this.colBudget.FieldName = "Budget";
            this.colBudget.Name = "colBudget";
            this.colBudget.Visible = true;
            this.colBudget.VisibleIndex = 5;
            // 
            // colKontoNr
            // 
            this.colKontoNr.Caption = "LA";
            this.colKontoNr.FieldName = "KontoNr";
            this.colKontoNr.Name = "colKontoNr";
            this.colKontoNr.Visible = true;
            this.colKontoNr.VisibleIndex = 6;
            // 
            // colBuchungstext
            // 
            this.colBuchungstext.Caption = "Buchungstext";
            this.colBuchungstext.FieldName = "Buchungstext";
            this.colBuchungstext.Name = "colBuchungstext";
            this.colBuchungstext.Visible = true;
            this.colBuchungstext.VisibleIndex = 7;
            // 
            // colPerson
            // 
            this.colPerson.Caption = "Betroffene Person";
            this.colPerson.FieldName = "Person";
            this.colPerson.Name = "colPerson";
            this.colPerson.Visible = true;
            this.colPerson.VisibleIndex = 8;
            // 
            // colBetrag
            // 
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 9;
            // 
            // colDokument
            // 
            this.colDokument.Caption = "Dok";
            this.colDokument.FieldName = "Dokument";
            this.colDokument.Name = "colDokument";
            this.colDokument.Visible = true;
            this.colDokument.VisibleIndex = 10;
            // 
            // colKreditor
            // 
            this.colKreditor.Caption = "Kreditor";
            this.colKreditor.FieldName = "Kreditor";
            this.colKreditor.Name = "colKreditor";
            this.colKreditor.Visible = true;
            this.colKreditor.VisibleIndex = 11;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Stat";
            this.colStatus.ColumnEdit = this.repositoryItemImageComboBox1;
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 12;
            this.colStatus.Width = 31;
            // 
            // colEffektiv
            // 
            this.colEffektiv.Caption = "Effektiv";
            this.colEffektiv.FieldName = "Effektiv";
            this.colEffektiv.Name = "colEffektiv";
            this.colEffektiv.Visible = true;
            this.colEffektiv.VisibleIndex = 13;
            // 
            // colStatusImage
            // 
            this.colStatusImage.AutoHeight = false;
            this.colStatusImage.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colStatusImage.Name = "colStatusImage";
            // 
            // grdDocuments
            // 
            this.grdDocuments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.grdDocuments.EmbeddedNavigator.Name = "";
            this.grdDocuments.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdDocuments.Location = new System.Drawing.Point(3, 292);
            this.grdDocuments.MainView = this.grvDocuments;
            this.grdDocuments.Name = "grdDocuments";
            this.grdDocuments.Size = new System.Drawing.Size(766, 100);
            this.grdDocuments.TabIndex = 3;
            this.grdDocuments.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDocuments});
            this.grdDocuments.DoubleClick += new System.EventHandler(this.grdDocuments_DoubleClick);
            // 
            // grvDocuments
            // 
            this.grvDocuments.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvDocuments.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDocuments.Appearance.Empty.Options.UseBackColor = true;
            this.grvDocuments.Appearance.Empty.Options.UseFont = true;
            this.grvDocuments.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDocuments.Appearance.EvenRow.Options.UseFont = true;
            this.grvDocuments.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvDocuments.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDocuments.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvDocuments.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvDocuments.Appearance.FocusedCell.Options.UseFont = true;
            this.grvDocuments.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvDocuments.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvDocuments.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDocuments.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvDocuments.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvDocuments.Appearance.FocusedRow.Options.UseFont = true;
            this.grvDocuments.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvDocuments.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvDocuments.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvDocuments.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvDocuments.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvDocuments.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvDocuments.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvDocuments.Appearance.GroupRow.Options.UseFont = true;
            this.grvDocuments.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvDocuments.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvDocuments.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvDocuments.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvDocuments.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvDocuments.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvDocuments.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvDocuments.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvDocuments.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDocuments.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvDocuments.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvDocuments.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvDocuments.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvDocuments.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvDocuments.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvDocuments.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDocuments.Appearance.OddRow.Options.UseFont = true;
            this.grvDocuments.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvDocuments.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDocuments.Appearance.Row.Options.UseBackColor = true;
            this.grvDocuments.Appearance.Row.Options.UseFont = true;
            this.grvDocuments.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDocuments.Appearance.SelectedRow.Options.UseFont = true;
            this.grvDocuments.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvDocuments.Appearance.VertLine.Options.UseBackColor = true;
            this.grvDocuments.BestFitMaxRowCount = 1000;
            this.grvDocuments.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvDocuments.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTyp,
            this.colStichwort,
            this.colErstellungsdatum,
            this.colLetzteSpeicherung});
            this.grvDocuments.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvDocuments.GridControl = this.grdDocuments;
            this.grvDocuments.Name = "grvDocuments";
            this.grvDocuments.OptionsBehavior.Editable = false;
            this.grvDocuments.OptionsCustomization.AllowFilter = false;
            this.grvDocuments.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvDocuments.OptionsNavigation.AutoFocusNewRow = true;
            this.grvDocuments.OptionsNavigation.UseTabKey = false;
            this.grvDocuments.OptionsView.ColumnAutoWidth = false;
            this.grvDocuments.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvDocuments.OptionsView.ShowGroupPanel = false;
            this.grvDocuments.OptionsView.ShowIndicator = false;
            // 
            // colTyp
            // 
            this.colTyp.Caption = "Typ";
            this.colTyp.FieldName = "BgDokumentTypCode";
            this.colTyp.Name = "colTyp";
            this.colTyp.Visible = true;
            this.colTyp.VisibleIndex = 0;
            // 
            // colStichwort
            // 
            this.colStichwort.Caption = "Stichwort";
            this.colStichwort.FieldName = "Stichwort";
            this.colStichwort.Name = "colStichwort";
            this.colStichwort.Visible = true;
            this.colStichwort.VisibleIndex = 1;
            // 
            // colErstellungsdatum
            // 
            this.colErstellungsdatum.Caption = "Erstellungsdatum";
            this.colErstellungsdatum.FieldName = "DateCreation";
            this.colErstellungsdatum.Name = "colErstellungsdatum";
            this.colErstellungsdatum.Visible = true;
            this.colErstellungsdatum.VisibleIndex = 2;
            // 
            // colLetzteSpeicherung
            // 
            this.colLetzteSpeicherung.Caption = "Letzte Speicherung";
            this.colLetzteSpeicherung.FieldName = "DateLastSave";
            this.colLetzteSpeicherung.Name = "colLetzteSpeicherung";
            this.colLetzteSpeicherung.Visible = true;
            this.colLetzteSpeicherung.VisibleIndex = 3;
            // 
            // qryDocuments
            // 
            this.qryDocuments.HostControl = this.tpgListe;
            this.qryDocuments.SelectStatement = resources.GetString("qryDocuments.SelectStatement");
            this.qryDocuments.TableName = "BgDokument";
            this.qryDocuments.AfterFill += new System.EventHandler(this.qryDocuments_AfterFill);
            // 
            // btnBudgetPosition
            // 
            this.btnBudgetPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBudgetPosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBudgetPosition.Location = new System.Drawing.Point(167, 398);
            this.btnBudgetPosition.Name = "btnBudgetPosition";
            this.btnBudgetPosition.Size = new System.Drawing.Size(90, 24);
            this.btnBudgetPosition.TabIndex = 4;
            this.btnBudgetPosition.Text = "> Budget";
            this.btnBudgetPosition.UseVisualStyleBackColor = false;
            this.btnBudgetPosition.Click += new System.EventHandler(this.btnBudgetPosition_Click);
            // 
            // lblDokumente
            // 
            this.lblDokumente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDokumente.Location = new System.Drawing.Point(3, 266);
            this.lblDokumente.Name = "lblDokumente";
            this.lblDokumente.Size = new System.Drawing.Size(100, 23);
            this.lblDokumente.TabIndex = 5;
            this.lblDokumente.Text = "Dokumente";
            // 
            // edtSucheRechnungDatum
            // 
            this.edtSucheRechnungDatum.EditValue = null;
            this.edtSucheRechnungDatum.Location = new System.Drawing.Point(141, 81);
            this.edtSucheRechnungDatum.Name = "edtSucheRechnungDatum";
            this.edtSucheRechnungDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheRechnungDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheRechnungDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheRechnungDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheRechnungDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheRechnungDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheRechnungDatum.Properties.Appearance.Options.UseFont = true;
            this.edtSucheRechnungDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSucheRechnungDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheRechnungDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSucheRechnungDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheRechnungDatum.Properties.ShowToday = false;
            this.edtSucheRechnungDatum.Size = new System.Drawing.Size(100, 24);
            this.edtSucheRechnungDatum.TabIndex = 3;
            // 
            // lblRechnungDatum
            // 
            this.lblRechnungDatum.Location = new System.Drawing.Point(10, 81);
            this.lblRechnungDatum.Name = "lblRechnungDatum";
            this.lblRechnungDatum.Size = new System.Drawing.Size(125, 24);
            this.lblRechnungDatum.TabIndex = 4;
            this.lblRechnungDatum.Text = "Valutadatum von";
            // 
            // CtlQueryWhRechnungsnummer
            // 

            this.Name = "CtlQueryWhRechnungsnummer";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvPositionDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheRechnungsnummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechnungsnummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colStatusImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDocuments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDocuments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryDocuments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokumente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheRechnungDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechnungDatum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Gui.KissLabel lblRechnungsnummer;
        private Gui.KissTextEdit edtSucheRechnungsnummer;
        private DevExpress.XtraGrid.Views.Grid.GridView grvQuery;
        private DevExpress.XtraGrid.Columns.GridColumn colFaFallID;
        private DevExpress.XtraGrid.Columns.GridColumn colKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colVerwPeriodeVon;
        private DevExpress.XtraGrid.Columns.GridColumn colVerwPeriodeBis;
        private DevExpress.XtraGrid.Columns.GridColumn colBudget;
        private DevExpress.XtraGrid.Columns.GridColumn colKontoNr;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungstext;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colDokument;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox colStatusImage;
        private Gui.KissGrid grdDocuments;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDocuments;
        private DB.SqlQuery qryDocuments;
        private Gui.KissButton btnBudgetPosition;
        private DevExpress.XtraGrid.Columns.GridColumn colTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colStichwort;
        private DevExpress.XtraGrid.Columns.GridColumn colErstellungsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colLetzteSpeicherung;
        private Gui.KissLabel lblDokumente;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPositionDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailVerwPeriodeVon;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailVerwPeriodeBis;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailBudget;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailKontoNr;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailBuchungstext;
        private Gui.KissLabel lblRechnungDatum;
        private Gui.KissDateEdit edtSucheRechnungDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailKreditor;
        private DevExpress.XtraGrid.Columns.GridColumn colRechnungsnummer;
        private DevExpress.XtraGrid.Columns.GridColumn colKreditor;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraGrid.Columns.GridColumn colEffektiv;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailEffektiv;
    }
}
