namespace KiSS4.Query.ZH
{
    public partial class CtlQueryKbAbstimmungProLA
    {
        #region Fields

        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel lblBerichtsperiodeVon;

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryKbAbstimmungProLA));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblBerichtsperiodeVon = new KiSS4.Gui.KissLabel();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblBerichtsperiodeBis = new KiSS4.Gui.KissLabel();
            this.tpgBelege = new SharpLibrary.WinControls.TabPageEx();
            this.lblSuchkriterienInfoBelege = new System.Windows.Forms.Label();
            this.grdBelege = new KiSS4.Gui.KissGrid();
            this.grvTotal = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pklSucheLeistungsarten = new KiSS4.Gui.KissPickList();
            this.qrySucheLeistungsartenVerfuegbar = new KiSS4.DB.SqlQuery(this.components);
            this.qrySucheLeistungsartenZugeteilt = new KiSS4.DB.SqlQuery(this.components);
            this.lblLeistungsarten = new KiSS4.Gui.KissLabel();
            this.ttpSuchkriterienInfo = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblBerichtsperiodeVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBerichtsperiodeBis)).BeginInit();
            this.tpgBelege.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBelege)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrySucheLeistungsartenVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrySucheLeistungsartenZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistungsarten)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.FillTimeOut = 1800;
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            this.qryQuery.AfterFill += new System.EventHandler(this.qryQuery_AfterFill);
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
            this.grvQuery1.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvQuery1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupFooter.Options.UseBorderColor = true;
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
            this.grvQuery1.OptionsView.ShowFooter = true;
            this.grvQuery1.OptionsView.ShowGroupPanel = false;
            this.grvQuery1.OptionsView.ShowIndicator = false;
            // 
            // grdQuery1
            // 
            // 
            // 
            // 
            this.grdQuery1.EmbeddedNavigator.Name = "";
            this.grdQuery1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // xDocument
            // 
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            this.xDocument.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = "BaPersonID$";
            this.ctlGotoFall.Visible = false;
            // 
            // lblSuchkriterienInfo
            // 
            this.lblSuchkriterienInfo.Location = new System.Drawing.Point(3, 398);
            this.lblSuchkriterienInfo.Size = new System.Drawing.Size(766, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Controls.Add(this.tpgBelege);
            this.tabControlSearch.SelectedTabIndex = 2;
            this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgBelege});
            this.tabControlSearch.Controls.SetChildIndex(this.tpgSuchen, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgBelege, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe, 0);
            // 
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Title = "Total";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.lblLeistungsarten);
            this.tpgSuchen.Controls.Add(this.pklSucheLeistungsarten);
            this.tpgSuchen.Controls.Add(this.edtDatumVon);
            this.tpgSuchen.Controls.Add(this.edtDatumBis);
            this.tpgSuchen.Controls.Add(this.lblBerichtsperiodeBis);
            this.tpgSuchen.Controls.Add(this.lblBerichtsperiodeVon);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBerichtsperiodeVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBerichtsperiodeBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.pklSucheLeistungsarten, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblLeistungsarten, 0);
            // 
            // lblBerichtsperiodeVon
            // 
            this.lblBerichtsperiodeVon.Location = new System.Drawing.Point(21, 48);
            this.lblBerichtsperiodeVon.Name = "lblBerichtsperiodeVon";
            this.lblBerichtsperiodeVon.Size = new System.Drawing.Size(130, 24);
            this.lblBerichtsperiodeVon.TabIndex = 6;
            this.lblBerichtsperiodeVon.Text = "Berichtsperiode von";
            this.lblBerichtsperiodeVon.UseCompatibleTextRendering = true;
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
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
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
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.grdQuery1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(157, 48);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 29;
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(292, 48);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 30;
            // 
            // lblBerichtsperiodeBis
            // 
            this.lblBerichtsperiodeBis.Location = new System.Drawing.Point(263, 48);
            this.lblBerichtsperiodeBis.Name = "lblBerichtsperiodeBis";
            this.lblBerichtsperiodeBis.Size = new System.Drawing.Size(23, 24);
            this.lblBerichtsperiodeBis.TabIndex = 27;
            this.lblBerichtsperiodeBis.Text = "bis";
            this.lblBerichtsperiodeBis.UseCompatibleTextRendering = true;
            // 
            // tpgBelege
            // 
            this.tpgBelege.Controls.Add(this.lblSuchkriterienInfoBelege);
            this.tpgBelege.Controls.Add(this.grdBelege);
            this.tpgBelege.Location = new System.Drawing.Point(6, 6);
            this.tpgBelege.Name = "tpgBelege";
            this.tpgBelege.Size = new System.Drawing.Size(772, 424);
            this.tpgBelege.TabIndex = 1;
            this.tpgBelege.Title = "Liste";
            // 
            // lblSuchkriterienInfoBelege
            // 
            this.lblSuchkriterienInfoBelege.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSuchkriterienInfoBelege.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblSuchkriterienInfoBelege.Location = new System.Drawing.Point(3, 398);
            this.lblSuchkriterienInfoBelege.Name = "lblSuchkriterienInfoBelege";
            this.lblSuchkriterienInfoBelege.Size = new System.Drawing.Size(766, 24);
            this.lblSuchkriterienInfoBelege.TabIndex = 7;
            this.lblSuchkriterienInfoBelege.Text = "Nam:aaaa, Vor:aaadflkjfs, Geb:01.01.2014, bis:01.12.2014, AHV:1122.323.3.34";
            // 
            // grdBelege
            // 
            this.grdBelege.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBelege.ColumnFilterActivated = true;
            // 
            // 
            // 
            this.grdBelege.EmbeddedNavigator.Name = "";
            this.grdBelege.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBelege.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdBelege.Location = new System.Drawing.Point(3, 0);
            this.grdBelege.MainView = this.grvTotal;
            this.grdBelege.Name = "grdBelege";
            this.grdBelege.Size = new System.Drawing.Size(766, 392);
            this.grdBelege.TabIndex = 1;
            this.grdBelege.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTotal});
            // 
            // grvTotal
            // 
            this.grvTotal.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvTotal.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTotal.Appearance.Empty.Options.UseBackColor = true;
            this.grvTotal.Appearance.Empty.Options.UseFont = true;
            this.grvTotal.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvTotal.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTotal.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvTotal.Appearance.EvenRow.Options.UseFont = true;
            this.grvTotal.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvTotal.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTotal.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvTotal.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvTotal.Appearance.FocusedCell.Options.UseFont = true;
            this.grvTotal.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvTotal.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvTotal.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTotal.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvTotal.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvTotal.Appearance.FocusedRow.Options.UseFont = true;
            this.grvTotal.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvTotal.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvTotal.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvTotal.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvTotal.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvTotal.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvTotal.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvTotal.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvTotal.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvTotal.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvTotal.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvTotal.Appearance.GroupRow.Options.UseFont = true;
            this.grvTotal.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvTotal.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvTotal.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvTotal.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvTotal.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvTotal.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvTotal.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvTotal.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvTotal.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTotal.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvTotal.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvTotal.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvTotal.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvTotal.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvTotal.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvTotal.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvTotal.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTotal.Appearance.OddRow.Options.UseBackColor = true;
            this.grvTotal.Appearance.OddRow.Options.UseFont = true;
            this.grvTotal.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvTotal.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTotal.Appearance.Row.Options.UseBackColor = true;
            this.grvTotal.Appearance.Row.Options.UseFont = true;
            this.grvTotal.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvTotal.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTotal.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvTotal.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvTotal.Appearance.SelectedRow.Options.UseFont = true;
            this.grvTotal.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvTotal.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvTotal.Appearance.VertLine.Options.UseBackColor = true;
            this.grvTotal.BestFitMaxRowCount = 50;
            this.grvTotal.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvTotal.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvTotal.GridControl = this.grdBelege;
            this.grvTotal.Name = "grvTotal";
            this.grvTotal.OptionsBehavior.Editable = false;
            this.grvTotal.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvTotal.OptionsNavigation.AutoFocusNewRow = true;
            this.grvTotal.OptionsNavigation.UseTabKey = false;
            this.grvTotal.OptionsPrint.AutoWidth = false;
            this.grvTotal.OptionsPrint.ExpandAllDetails = true;
            this.grvTotal.OptionsPrint.UsePrintStyles = true;
            this.grvTotal.OptionsView.ColumnAutoWidth = false;
            this.grvTotal.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvTotal.OptionsView.ShowGroupPanel = false;
            this.grvTotal.OptionsView.ShowIndicator = false;
            // 
            // pklSucheLeistungsarten
            // 
            this.pklSucheLeistungsarten.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.pklSucheLeistungsarten.ColumnIDName = "BgKostenartID";
            this.pklSucheLeistungsarten.ColumnValueName = "KontoNr";
            this.pklSucheLeistungsarten.DataSourceOfSourceGrid = this.qrySucheLeistungsartenVerfuegbar;
            this.pklSucheLeistungsarten.DataSourceOfTargetGrid = this.qrySucheLeistungsartenZugeteilt;
            this.pklSucheLeistungsarten.FilterColumnName = "Name";
            this.pklSucheLeistungsarten.Location = new System.Drawing.Point(154, 75);
            this.pklSucheLeistungsarten.Margin = new System.Windows.Forms.Padding(0);
            this.pklSucheLeistungsarten.Name = "pklSucheLeistungsarten";
            this.pklSucheLeistungsarten.Size = new System.Drawing.Size(573, 251);
            this.pklSucheLeistungsarten.TabIndex = 31;
            this.pklSucheLeistungsarten.TargetFilterVisible = false;
            // 
            // qrySucheLeistungsartenVerfuegbar
            // 
            this.qrySucheLeistungsartenVerfuegbar.AutoApplyUserRights = false;
            this.qrySucheLeistungsartenVerfuegbar.CanDelete = true;
            this.qrySucheLeistungsartenVerfuegbar.CanInsert = true;
            this.qrySucheLeistungsartenVerfuegbar.CanUpdate = true;
            this.qrySucheLeistungsartenVerfuegbar.DeleteQuestion = null;
            this.qrySucheLeistungsartenVerfuegbar.HostControl = this.pklSucheLeistungsarten;
            this.qrySucheLeistungsartenVerfuegbar.SelectStatement = "SELECT BgKostenartID,\r\n       KontoNr,\r\n       Name = KontoNr + \' \' + Name\r\nFROM " +
    "dbo.BgKostenart\r\nORDER BY 3;\r\n";
            // 
            // qrySucheLeistungsartenZugeteilt
            // 
            this.qrySucheLeistungsartenZugeteilt.AutoApplyUserRights = false;
            this.qrySucheLeistungsartenZugeteilt.BatchUpdate = true;
            this.qrySucheLeistungsartenZugeteilt.CanDelete = true;
            this.qrySucheLeistungsartenZugeteilt.CanInsert = true;
            this.qrySucheLeistungsartenZugeteilt.CanUpdate = true;
            this.qrySucheLeistungsartenZugeteilt.DeleteQuestion = null;
            this.qrySucheLeistungsartenZugeteilt.HostControl = this.pklSucheLeistungsarten;
            this.qrySucheLeistungsartenZugeteilt.SelectStatement = "SELECT BgKostenartID,\r\n       KontoNr,\r\n       Name = KontoNr + \' \' + Name\r\nFROM " +
    "dbo.BgKostenart\r\nWHERE 0 = 1 --wir wollen initial keine Daten\r\nORDER BY 3;\r\n\r\n";
            // 
            // lblLeistungsarten
            // 
            this.lblLeistungsarten.Location = new System.Drawing.Point(21, 75);
            this.lblLeistungsarten.Name = "lblLeistungsarten";
            this.lblLeistungsarten.Size = new System.Drawing.Size(130, 24);
            this.lblLeistungsarten.TabIndex = 32;
            this.lblLeistungsarten.Text = "Leistungsarten";
            this.lblLeistungsarten.UseCompatibleTextRendering = true;
            // 
            // CtlQueryKbAbstimmungProLA
            // 
            this.Name = "CtlQueryKbAbstimmungProLA";
            this.Load += new System.EventHandler(this.CtlQueryKbAbstimmungProLA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblBerichtsperiodeVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBerichtsperiodeBis)).EndInit();
            this.tpgBelege.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBelege)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrySucheLeistungsartenVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrySucheLeistungsartenZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistungsarten)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Gui.KissDateEdit edtDatumVon;
        private Gui.KissDateEdit edtDatumBis;
        private Gui.KissLabel lblBerichtsperiodeBis;
        private SharpLibrary.WinControls.TabPageEx tpgBelege;
        protected Gui.KissGrid grdBelege;
        protected DevExpress.XtraGrid.Views.Grid.GridView grvTotal;
        private System.ComponentModel.IContainer components;
        private Gui.KissLabel lblLeistungsarten;
        private Gui.KissPickList pklSucheLeistungsarten;
        private DB.SqlQuery qrySucheLeistungsartenVerfuegbar;
        private DB.SqlQuery qrySucheLeistungsartenZugeteilt;
        protected System.Windows.Forms.Label lblSuchkriterienInfoBelege;
        private System.Windows.Forms.ToolTip ttpSuchkriterienInfo;
    }
}