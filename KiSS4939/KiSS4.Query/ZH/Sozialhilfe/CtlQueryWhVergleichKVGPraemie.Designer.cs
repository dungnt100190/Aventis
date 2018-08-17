using KiSS4.Gui;

namespace KiSS4.Query.ZH
{
    partial class CtlQueryWhVergleichKVGPraemie
    {
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

        #region Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryWhVergleichKVGPraemie));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grvDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDetailKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailErfassung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailBetragEffektiv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailDiff = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailVerwVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailVerwBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnMonatsbudget = new KiSS4.Gui.KissButton();
            this.edtKlient = new KiSS4.Gui.KissButtonEdit();
            this.edtFallNr = new KiSS4.Gui.KissCalcEdit();
            this.lblKlient = new KiSS4.Gui.KissLabel();
            this.lblMonatsbudgetVon = new KiSS4.Gui.KissLabel();
            this.lblMonatsbudgetBis = new KiSS4.Gui.KissLabel();
            this.ctlOrgUnitTeamUser = new KiSS4.Common.ZH.CtlOrgUnitTeamUser();
            this.lblFallNr = new KiSS4.Gui.KissLabel();
            this.lblPersonenNr = new KiSS4.Gui.KissLabel();
            this.edtPersonenNr = new KiSS4.Gui.KissCalcEdit();
            this.colBuchungsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaFallNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTeam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grvMain = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKvgPraemieModulB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKvgPraemieMonatsbudget = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDifferenz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnzPos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKreditor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHinweis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grvQuery2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFallNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMonatsbudgetVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMonatsbudgetBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFallNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonenNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonenNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.FillTimeOut = 400;
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            this.qryQuery.AfterFill += new System.EventHandler(this.qryQuery_AfterFill);
            this.qryQuery.ColumnChanged += new System.Data.DataColumnChangeEventHandler(this.qryQuery_ColumnChanged);
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
            gridLevelNode1.LevelTemplate = this.grvDetail;
            gridLevelNode1.RelationName = "Level1";
            this.grdQuery1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdQuery1.MainView = this.grvMain;
            this.grdQuery1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDetail,
            this.grvMain,
            this.grvQuery2});
            // 
            // xDocument
            // 
            this.xDocument.Location = new System.Drawing.Point(302, 3359);
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = "BaPersonID";
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(752, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.SelectedTabIndex = 1;
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.btnMonatsbudget);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Controls.SetChildIndex(this.grdQuery1, 0);
            this.tpgListe.Controls.SetChildIndex(this.xDocument, 0);
            this.tpgListe.Controls.SetChildIndex(this.ctlGotoFall, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnMonatsbudget, 0);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtDatumBis);
            this.tpgSuchen.Controls.Add(this.edtDatumVon);
            this.tpgSuchen.Controls.Add(this.edtPersonenNr);
            this.tpgSuchen.Controls.Add(this.lblPersonenNr);
            this.tpgSuchen.Controls.Add(this.lblFallNr);
            this.tpgSuchen.Controls.Add(this.ctlOrgUnitTeamUser);
            this.tpgSuchen.Controls.Add(this.lblMonatsbudgetBis);
            this.tpgSuchen.Controls.Add(this.lblMonatsbudgetVon);
            this.tpgSuchen.Controls.Add(this.lblKlient);
            this.tpgSuchen.Controls.Add(this.edtFallNr);
            this.tpgSuchen.Controls.Add(this.edtKlient);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.edtKlient, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFallNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblKlient, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblMonatsbudgetVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblMonatsbudgetBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.ctlOrgUnitTeamUser, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblFallNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblPersonenNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtPersonenNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumBis, 0);
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
            this.colDetailErfassung.Caption = "Fälligkeit / ZE";
            this.colDetailErfassung.FieldName = "FaellikeitsDatum";
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
            this.colDetailDiff.FieldName = "Diff";
            this.colDetailDiff.Name = "colDetailDiff";
            this.colDetailDiff.Visible = true;
            this.colDetailDiff.VisibleIndex = 4;
            // 
            // colDetailVerwVon
            // 
            this.colDetailVerwVon.Caption = "Verw. von";
            this.colDetailVerwVon.FieldName = "DatumVon";
            this.colDetailVerwVon.Name = "colDetailVerwVon";
            this.colDetailVerwVon.Visible = true;
            this.colDetailVerwVon.VisibleIndex = 5;
            this.colDetailVerwVon.Width = 85;
            // 
            // colDetailVerwBis
            // 
            this.colDetailVerwBis.Caption = "Verw. bis";
            this.colDetailVerwBis.FieldName = "DatumBis";
            this.colDetailVerwBis.Name = "colDetailVerwBis";
            this.colDetailVerwBis.Visible = true;
            this.colDetailVerwBis.VisibleIndex = 6;
            // 
            // btnMonatsbudget
            // 
            this.btnMonatsbudget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMonatsbudget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonatsbudget.Location = new System.Drawing.Point(167, 398);
            this.btnMonatsbudget.Name = "btnMonatsbudget";
            this.btnMonatsbudget.Size = new System.Drawing.Size(129, 24);
            this.btnMonatsbudget.TabIndex = 419;
            this.btnMonatsbudget.Text = "> Monatsbudget";
            this.btnMonatsbudget.UseCompatibleTextRendering = true;
            this.btnMonatsbudget.UseVisualStyleBackColor = false;
            this.btnMonatsbudget.Click += new System.EventHandler(this.btnMonatsbudget_Click);
            // 
            // edtKlient
            // 
            this.edtKlient.Location = new System.Drawing.Point(126, 122);
            this.edtKlient.LookupSQL = resources.GetString("edtKlient.LookupSQL");
            this.edtKlient.Name = "edtKlient";
            this.edtKlient.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKlient.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKlient.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKlient.Properties.Appearance.Options.UseBackColor = true;
            this.edtKlient.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKlient.Properties.Appearance.Options.UseFont = true;
            this.edtKlient.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtKlient.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtKlient.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKlient.Properties.Name = "kissButtonEdit1.Properties";
            this.edtKlient.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtKlient.Size = new System.Drawing.Size(260, 24);
            this.edtKlient.TabIndex = 3;
            // 
            // edtFallNr
            // 
            this.edtFallNr.Location = new System.Drawing.Point(126, 182);
            this.edtFallNr.Name = "edtFallNr";
            this.edtFallNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtFallNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFallNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFallNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFallNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtFallNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFallNr.Properties.Appearance.Options.UseFont = true;
            this.edtFallNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFallNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFallNr.Properties.DisplayFormat.FormatString = "N0";
            this.edtFallNr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtFallNr.Properties.EditFormat.FormatString = "N0";
            this.edtFallNr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtFallNr.Size = new System.Drawing.Size(260, 24);
            this.edtFallNr.TabIndex = 7;
            // 
            // lblKlient
            // 
            this.lblKlient.Location = new System.Drawing.Point(14, 121);
            this.lblKlient.Name = "lblKlient";
            this.lblKlient.Size = new System.Drawing.Size(106, 24);
            this.lblKlient.TabIndex = 2;
            this.lblKlient.Text = "Klient";
            this.lblKlient.UseCompatibleTextRendering = true;
            // 
            // lblMonatsbudgetVon
            // 
            this.lblMonatsbudgetVon.Location = new System.Drawing.Point(13, 214);
            this.lblMonatsbudgetVon.Name = "lblMonatsbudgetVon";
            this.lblMonatsbudgetVon.Size = new System.Drawing.Size(107, 24);
            this.lblMonatsbudgetVon.TabIndex = 8;
            this.lblMonatsbudgetVon.Text = "Monatsbudget von";
            this.lblMonatsbudgetVon.UseCompatibleTextRendering = true;
            // 
            // lblMonatsbudgetBis
            // 
            this.lblMonatsbudgetBis.Location = new System.Drawing.Point(246, 214);
            this.lblMonatsbudgetBis.Name = "lblMonatsbudgetBis";
            this.lblMonatsbudgetBis.Size = new System.Drawing.Size(32, 24);
            this.lblMonatsbudgetBis.TabIndex = 10;
            this.lblMonatsbudgetBis.Text = "bis";
            this.lblMonatsbudgetBis.UseCompatibleTextRendering = true;
            // 
            // ctlOrgUnitTeamUser
            // 
            this.ctlOrgUnitTeamUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlOrgUnitTeamUser.LableWidth = 113;
            this.ctlOrgUnitTeamUser.Location = new System.Drawing.Point(14, 32);
            this.ctlOrgUnitTeamUser.Name = "ctlOrgUnitTeamUser";
            this.ctlOrgUnitTeamUser.SetUserOnNewSearch = false;
            this.ctlOrgUnitTeamUser.ShowUser = true;
            this.ctlOrgUnitTeamUser.Size = new System.Drawing.Size(373, 84);
            this.ctlOrgUnitTeamUser.TabIndex = 1;
            // 
            // lblFallNr
            // 
            this.lblFallNr.Location = new System.Drawing.Point(13, 182);
            this.lblFallNr.Name = "lblFallNr";
            this.lblFallNr.Size = new System.Drawing.Size(107, 24);
            this.lblFallNr.TabIndex = 6;
            this.lblFallNr.Text = "Fall-Nr.";
            this.lblFallNr.UseCompatibleTextRendering = true;
            // 
            // lblPersonenNr
            // 
            this.lblPersonenNr.Location = new System.Drawing.Point(13, 152);
            this.lblPersonenNr.Name = "lblPersonenNr";
            this.lblPersonenNr.Size = new System.Drawing.Size(107, 24);
            this.lblPersonenNr.TabIndex = 4;
            this.lblPersonenNr.Text = "Pers.-Nr.";
            this.lblPersonenNr.UseCompatibleTextRendering = true;
            // 
            // edtPersonenNr
            // 
            this.edtPersonenNr.Location = new System.Drawing.Point(126, 152);
            this.edtPersonenNr.Name = "edtPersonenNr";
            this.edtPersonenNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtPersonenNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPersonenNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPersonenNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPersonenNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtPersonenNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPersonenNr.Properties.Appearance.Options.UseFont = true;
            this.edtPersonenNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPersonenNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPersonenNr.Properties.DisplayFormat.FormatString = "N0";
            this.edtPersonenNr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtPersonenNr.Properties.EditFormat.FormatString = "N0";
            this.edtPersonenNr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtPersonenNr.Size = new System.Drawing.Size(261, 24);
            this.edtPersonenNr.TabIndex = 5;
            // 
            // colBuchungsdatum
            // 
            this.colBuchungsdatum.Caption = "Budget";
            this.colBuchungsdatum.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colBuchungsdatum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colBuchungsdatum.FieldName = "Budget";
            this.colBuchungsdatum.Name = "colBuchungsdatum";
            this.colBuchungsdatum.Visible = true;
            this.colBuchungsdatum.VisibleIndex = 2;
            this.colBuchungsdatum.Width = 60;
            // 
            // colDatumBis
            // 
            this.colDatumBis.Caption = "Verw. Periode bis";
            this.colDatumBis.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colDatumBis.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDatumBis.FieldName = "VerwPeriodeBis";
            this.colDatumBis.Name = "colDatumBis";
            this.colDatumBis.Visible = true;
            this.colDatumBis.VisibleIndex = 10;
            // 
            // colDatumVon
            // 
            this.colDatumVon.Caption = "Verw. Periode von";
            this.colDatumVon.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colDatumVon.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDatumVon.FieldName = "VerwPeriodeVon";
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.Visible = true;
            this.colDatumVon.VisibleIndex = 9;
            // 
            // colFaFallNr
            // 
            this.colFaFallNr.Caption = "Fall-Nr.";
            this.colFaFallNr.FieldName = "FaFallID";
            this.colFaFallNr.Name = "colFaFallNr";
            this.colFaFallNr.Visible = true;
            this.colFaFallNr.VisibleIndex = 0;
            this.colFaFallNr.Width = 60;
            // 
            // colName
            // 
            this.colName.Caption = "Klient/in";
            this.colName.FieldName = "KlientIn";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 152;
            // 
            // colSA
            // 
            this.colSA.Caption = "SA";
            this.colSA.FieldName = "SA";
            this.colSA.Name = "colSA";
            this.colSA.Visible = true;
            this.colSA.VisibleIndex = 11;
            // 
            // colSZ
            // 
            this.colSZ.Caption = "SZ";
            this.colSZ.FieldName = "SZ";
            this.colSZ.Name = "colSZ";
            this.colSZ.Visible = true;
            this.colSZ.VisibleIndex = 13;
            // 
            // colTeam
            // 
            this.colTeam.Caption = "Team";
            this.colTeam.FieldName = "Team";
            this.colTeam.Name = "colTeam";
            this.colTeam.Visible = true;
            this.colTeam.VisibleIndex = 12;
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
            this.colFaFallNr,
            this.colName,
            this.colBuchungsdatum,
            this.colKvgPraemieModulB,
            this.colKvgPraemieMonatsbudget,
            this.colDifferenz,
            this.colAnzPos,
            this.colKreditor,
            this.colM,
            this.colDatumVon,
            this.colDatumBis,
            this.colSA,
            this.colTeam,
            this.colSZ,
            this.colHinweis});
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
            // 
            // colKvgPraemieModulB
            // 
            this.colKvgPraemieModulB.Caption = "KVG-Prämie, Modul B";
            this.colKvgPraemieModulB.FieldName = "KvgModulB";
            this.colKvgPraemieModulB.Name = "colKvgPraemieModulB";
            this.colKvgPraemieModulB.Visible = true;
            this.colKvgPraemieModulB.VisibleIndex = 3;
            // 
            // colKvgPraemieMonatsbudget
            // 
            this.colKvgPraemieMonatsbudget.Caption = "KVG-Prämie, Monatsbudget";
            this.colKvgPraemieMonatsbudget.FieldName = "KvgMonatsbudget";
            this.colKvgPraemieMonatsbudget.Name = "colKvgPraemieMonatsbudget";
            this.colKvgPraemieMonatsbudget.Visible = true;
            this.colKvgPraemieMonatsbudget.VisibleIndex = 4;
            // 
            // colDifferenz
            // 
            this.colDifferenz.Caption = "Differenz";
            this.colDifferenz.FieldName = "Differenz";
            this.colDifferenz.Name = "colDifferenz";
            this.colDifferenz.Visible = true;
            this.colDifferenz.VisibleIndex = 5;
            // 
            // colAnzPos
            // 
            this.colAnzPos.Caption = "Anzahl Positionen";
            this.colAnzPos.FieldName = "AnzPos";
            this.colAnzPos.Name = "colAnzPos";
            this.colAnzPos.Visible = true;
            this.colAnzPos.VisibleIndex = 6;
            // 
            // colKreditor
            // 
            this.colKreditor.Caption = "Kreditor";
            this.colKreditor.FieldName = "Kreditor";
            this.colKreditor.Name = "colKreditor";
            this.colKreditor.Visible = true;
            this.colKreditor.VisibleIndex = 7;
            // 
            // colM
            // 
            this.colM.Caption = "M";
            this.colM.FieldName = "M";
            this.colM.Name = "colM";
            this.colM.Visible = true;
            this.colM.VisibleIndex = 8;
            // 
            // colHinweis
            // 
            this.colHinweis.Caption = "Hinweis";
            this.colHinweis.FieldName = "Hinweis";
            this.colHinweis.Name = "colHinweis";
            this.colHinweis.Visible = true;
            this.colHinweis.VisibleIndex = 14;
            // 
            // grvQuery2
            // 
            this.grvQuery2.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvQuery2.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery2.Appearance.Empty.Options.UseBackColor = true;
            this.grvQuery2.Appearance.Empty.Options.UseFont = true;
            this.grvQuery2.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvQuery2.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery2.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvQuery2.Appearance.EvenRow.Options.UseFont = true;
            this.grvQuery2.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery2.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery2.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvQuery2.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvQuery2.Appearance.FocusedCell.Options.UseFont = true;
            this.grvQuery2.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvQuery2.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery2.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery2.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvQuery2.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvQuery2.Appearance.FocusedRow.Options.UseFont = true;
            this.grvQuery2.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvQuery2.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery2.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvQuery2.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery2.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery2.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery2.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvQuery2.Appearance.GroupRow.Options.UseFont = true;
            this.grvQuery2.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvQuery2.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvQuery2.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvQuery2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery2.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvQuery2.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvQuery2.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvQuery2.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvQuery2.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery2.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery2.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvQuery2.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvQuery2.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvQuery2.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery2.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvQuery2.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvQuery2.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery2.Appearance.OddRow.Options.UseBackColor = true;
            this.grvQuery2.Appearance.OddRow.Options.UseFont = true;
            this.grvQuery2.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvQuery2.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery2.Appearance.Row.Options.UseBackColor = true;
            this.grvQuery2.Appearance.Row.Options.UseFont = true;
            this.grvQuery2.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvQuery2.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery2.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvQuery2.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvQuery2.Appearance.SelectedRow.Options.UseFont = true;
            this.grvQuery2.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvQuery2.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery2.Appearance.VertLine.Options.UseBackColor = true;
            this.grvQuery2.GridControl = this.grdQuery1;
            this.grvQuery2.Name = "grvQuery2";
            this.grvQuery2.OptionsBehavior.Editable = false;
            this.grvQuery2.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvQuery2.OptionsNavigation.AutoFocusNewRow = true;
            this.grvQuery2.OptionsNavigation.UseTabKey = false;
            this.grvQuery2.OptionsPrint.AutoWidth = false;
            this.grvQuery2.OptionsPrint.ExpandAllDetails = true;
            this.grvQuery2.OptionsPrint.UsePrintStyles = true;
            this.grvQuery2.OptionsView.ColumnAutoWidth = false;
            this.grvQuery2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvQuery2.OptionsView.ShowGroupPanel = false;
            this.grvQuery2.OptionsView.ShowIndicator = false;
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(126, 214);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.DisplayFormat.FormatString = "MM.yyyy";
            this.edtDatumVon.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtDatumVon.Properties.EditFormat.FormatString = "MM.yyyy";
            this.edtDatumVon.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtDatumVon.Properties.Mask.EditMask = "MM.yyyy";
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 9;
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(287, 214);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.DisplayFormat.FormatString = "MM.yyyy";
            this.edtDatumBis.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtDatumBis.Properties.EditFormat.FormatString = "MM.yyyy";
            this.edtDatumBis.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtDatumBis.Properties.Mask.EditMask = "MM.yyyy";
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 11;
            // 
            // CtlQueryWhVergleichKVGPraemie
            // 
            this.Name = "CtlQueryWhVergleichKVGPraemie";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFallNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMonatsbudgetVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMonatsbudgetBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFallNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonenNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonenNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView grvMain;
        private DevExpress.XtraGrid.Columns.GridColumn colFaFallNr;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colSA;
        private DevExpress.XtraGrid.Columns.GridColumn colTeam;
        private DevExpress.XtraGrid.Columns.GridColumn colSZ;
        private DevExpress.XtraGrid.Views.Grid.GridView grvQuery2;
        private KiSS4.Gui.KissButton btnMonatsbudget;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissCalcEdit edtPersonenNr;
        private KiSS4.Gui.KissLabel lblPersonenNr;
        private KiSS4.Gui.KissLabel lblFallNr;
        private KiSS4.Common.ZH.CtlOrgUnitTeamUser ctlOrgUnitTeamUser;
        private KiSS4.Gui.KissLabel lblMonatsbudgetBis;
        private KiSS4.Gui.KissLabel lblMonatsbudgetVon;
        private KiSS4.Gui.KissLabel lblKlient;
        private KiSS4.Gui.KissCalcEdit edtFallNr;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailVerwVon;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailVerwBis;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailErfassung;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailBetragEffektiv;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailDiff;
        private KiSS4.Gui.KissButtonEdit edtKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colKvgPraemieModulB;
        private DevExpress.XtraGrid.Columns.GridColumn colKvgPraemieMonatsbudget;
        private DevExpress.XtraGrid.Columns.GridColumn colDifferenz;
        private DevExpress.XtraGrid.Columns.GridColumn colKreditor;
        private DevExpress.XtraGrid.Columns.GridColumn colM;
        private DevExpress.XtraGrid.Columns.GridColumn colHinweis;
        private DevExpress.XtraGrid.Columns.GridColumn colAnzPos;
        private KissDateEdit edtDatumBis;
        private KissDateEdit edtDatumVon;
    }
}