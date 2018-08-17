namespace KiSS4.Basis.ZH
{
    public partial class CtlBaPersonArbeit
    {
        #region Private Fields
        private DevExpress.XtraGrid.Columns.GridColumn colArbeitgeber;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colPensum;
        private DevExpress.XtraGrid.Columns.GridColumn colTyp;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissButtonEdit dlgArbeitgeber;
        private KiSS4.Gui.KissMemoEdit edtAdresse;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissCalcEdit edtPensum;
        private KiSS4.Gui.KissLookUpEdit edtTypCode;
        private KiSS4.Gui.KissGrid grdBaArbeitIntegration;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBaArbeitIntegration;
        private KiSS4.Gui.KissLabel kissLabel57;
        private KiSS4.Gui.KissLabel kissLabel59;
        private KiSS4.Gui.KissLabel kissLabel61;
        private KiSS4.Gui.KissLabel lblTitle;
        private KiSS4.Gui.KissLabel lblAdresse;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblDatumVon;
        private KiSS4.Gui.KissLabel lblHinweis;
        private KiSS4.Gui.KissLabel lblInstitutionName;
        private KiSS4.Gui.KissLabel lblPensum;
        private KiSS4.Gui.KissLabel lblTypCode;
        private KiSS4.Gui.KissMemoEdit memBemerkung;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;

        public KiSS4.DB.SqlQuery qryBaArbeit;

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBaPersonArbeit));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdBaArbeitIntegration = new KiSS4.Gui.KissGrid();
            this.qryBaArbeit = new KiSS4.DB.SqlQuery(this.components);
            this.grvBaArbeitIntegration = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArbeitgeber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPensum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtTypCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtPensum = new KiSS4.Gui.KissCalcEdit();
            this.memBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.dlgArbeitgeber = new KiSS4.Gui.KissButtonEdit();
            this.edtAdresse = new KiSS4.Gui.KissMemoEdit();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.lblTitle = new KiSS4.Gui.KissLabel();
            this.lblPensum = new KiSS4.Gui.KissLabel();
            this.kissLabel57 = new KiSS4.Gui.KissLabel();
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            this.kissLabel59 = new KiSS4.Gui.KissLabel();
            this.kissLabel61 = new KiSS4.Gui.KissLabel();
            this.lblTypCode = new KiSS4.Gui.KissLabel();
            this.lblInstitutionName = new KiSS4.Gui.KissLabel();
            this.lblAdresse = new KiSS4.Gui.KissLabel();
            this.lblHinweis = new KiSS4.Gui.KissLabel();
            this.edtGrundTeilzeit = new KiSS4.Gui.KissLookUpEdit();
            this.lblGrundTeilzeit = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaArbeitIntegration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaArbeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaArbeitIntegration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTypCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTypCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPensum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dlgArbeitgeber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPensum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel57)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel59)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel61)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTypCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInstitutionName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHinweis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundTeilzeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundTeilzeit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundTeilzeit)).BeginInit();
            this.SuspendLayout();
            // 
            // grdBaArbeitIntegration
            // 
            this.grdBaArbeitIntegration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdBaArbeitIntegration.DataSource = this.qryBaArbeit;
            // 
            // 
            // 
            this.grdBaArbeitIntegration.EmbeddedNavigator.Name = "kissGrid2.EmbeddedNavigator";
            this.grdBaArbeitIntegration.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBaArbeitIntegration.Location = new System.Drawing.Point(3, 26);
            this.grdBaArbeitIntegration.MainView = this.grvBaArbeitIntegration;
            this.grdBaArbeitIntegration.Name = "grdBaArbeitIntegration";
            this.grdBaArbeitIntegration.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.grdBaArbeitIntegration.Size = new System.Drawing.Size(700, 174);
            this.grdBaArbeitIntegration.TabIndex = 1;
            this.grdBaArbeitIntegration.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBaArbeitIntegration});
            // 
            // qryBaArbeit
            // 
            this.qryBaArbeit.CanDelete = true;
            this.qryBaArbeit.CanInsert = true;
            this.qryBaArbeit.CanUpdate = true;
            this.qryBaArbeit.HostControl = this;
            this.qryBaArbeit.SelectStatement = resources.GetString("qryBaArbeit.SelectStatement");
            this.qryBaArbeit.TableName = "BaArbeit";
            this.qryBaArbeit.AfterInsert += new System.EventHandler(this.qryBaArbeit_AfterInsert);
            this.qryBaArbeit.BeforePost += new System.EventHandler(this.qryBaArbeit_BeforePost);
            // 
            // grvBaArbeitIntegration
            // 
            this.grvBaArbeitIntegration.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBaArbeitIntegration.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaArbeitIntegration.Appearance.Empty.Options.UseBackColor = true;
            this.grvBaArbeitIntegration.Appearance.Empty.Options.UseFont = true;
            this.grvBaArbeitIntegration.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaArbeitIntegration.Appearance.EvenRow.Options.UseFont = true;
            this.grvBaArbeitIntegration.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaArbeitIntegration.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaArbeitIntegration.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBaArbeitIntegration.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBaArbeitIntegration.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBaArbeitIntegration.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBaArbeitIntegration.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaArbeitIntegration.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaArbeitIntegration.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBaArbeitIntegration.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBaArbeitIntegration.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBaArbeitIntegration.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBaArbeitIntegration.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaArbeitIntegration.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBaArbeitIntegration.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaArbeitIntegration.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaArbeitIntegration.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaArbeitIntegration.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBaArbeitIntegration.Appearance.GroupRow.Options.UseFont = true;
            this.grvBaArbeitIntegration.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBaArbeitIntegration.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBaArbeitIntegration.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBaArbeitIntegration.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaArbeitIntegration.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBaArbeitIntegration.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBaArbeitIntegration.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBaArbeitIntegration.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBaArbeitIntegration.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaArbeitIntegration.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaArbeitIntegration.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBaArbeitIntegration.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBaArbeitIntegration.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBaArbeitIntegration.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaArbeitIntegration.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBaArbeitIntegration.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaArbeitIntegration.Appearance.OddRow.Options.UseFont = true;
            this.grvBaArbeitIntegration.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBaArbeitIntegration.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaArbeitIntegration.Appearance.Row.Options.UseBackColor = true;
            this.grvBaArbeitIntegration.Appearance.Row.Options.UseFont = true;
            this.grvBaArbeitIntegration.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaArbeitIntegration.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBaArbeitIntegration.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaArbeitIntegration.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBaArbeitIntegration.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBaArbeitIntegration.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatumVon,
            this.colDatumBis,
            this.colArbeitgeber,
            this.colTyp,
            this.colPensum});
            this.grvBaArbeitIntegration.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBaArbeitIntegration.GridControl = this.grdBaArbeitIntegration;
            this.grvBaArbeitIntegration.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvBaArbeitIntegration.Name = "grvBaArbeitIntegration";
            this.grvBaArbeitIntegration.OptionsBehavior.Editable = false;
            this.grvBaArbeitIntegration.OptionsCustomization.AllowFilter = false;
            this.grvBaArbeitIntegration.OptionsFilter.AllowFilterEditor = false;
            this.grvBaArbeitIntegration.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBaArbeitIntegration.OptionsMenu.EnableColumnMenu = false;
            this.grvBaArbeitIntegration.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBaArbeitIntegration.OptionsNavigation.UseTabKey = false;
            this.grvBaArbeitIntegration.OptionsView.ColumnAutoWidth = false;
            this.grvBaArbeitIntegration.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBaArbeitIntegration.OptionsView.ShowGroupPanel = false;
            this.grvBaArbeitIntegration.OptionsView.ShowIndicator = false;
            // 
            // colDatumVon
            // 
            this.colDatumVon.Caption = "von";
            this.colDatumVon.FieldName = "DatumVon";
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.Visible = true;
            this.colDatumVon.VisibleIndex = 0;
            this.colDatumVon.Width = 81;
            // 
            // colDatumBis
            // 
            this.colDatumBis.Caption = "bis";
            this.colDatumBis.FieldName = "DatumBis";
            this.colDatumBis.Name = "colDatumBis";
            this.colDatumBis.Visible = true;
            this.colDatumBis.VisibleIndex = 1;
            this.colDatumBis.Width = 83;
            // 
            // colArbeitgeber
            // 
            this.colArbeitgeber.Caption = "Arbeitgeber/Anbieter";
            this.colArbeitgeber.FieldName = "Arbeitgeber";
            this.colArbeitgeber.Name = "colArbeitgeber";
            this.colArbeitgeber.Visible = true;
            this.colArbeitgeber.VisibleIndex = 2;
            this.colArbeitgeber.Width = 274;
            // 
            // colTyp
            // 
            this.colTyp.Caption = "Typ";
            this.colTyp.FieldName = "TypCode";
            this.colTyp.Name = "colTyp";
            this.colTyp.Visible = true;
            this.colTyp.VisibleIndex = 3;
            this.colTyp.Width = 182;
            // 
            // colPensum
            // 
            this.colPensum.AppearanceCell.Options.UseTextOptions = true;
            this.colPensum.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colPensum.AppearanceHeader.Options.UseTextOptions = true;
            this.colPensum.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colPensum.Caption = "%";
            this.colPensum.FieldName = "Pensum";
            this.colPensum.Name = "colPensum";
            this.colPensum.Visible = true;
            this.colPensum.VisibleIndex = 4;
            this.colPensum.Width = 38;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDatumVon.DataMember = "DatumVon";
            this.edtDatumVon.DataSource = this.qryBaArbeit;
            this.edtDatumVon.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(89, 206);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.Name = "kissDateEdit3.Properties";
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 3;
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDatumBis.DataMember = "DatumBis";
            this.edtDatumBis.DataSource = this.qryBaArbeit;
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(226, 206);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.Name = "kissDateEdit4.Properties";
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 5;
            // 
            // edtTypCode
            // 
            this.edtTypCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtTypCode.DataMember = "TypCode";
            this.edtTypCode.DataSource = this.qryBaArbeit;
            this.edtTypCode.Location = new System.Drawing.Point(89, 236);
            this.edtTypCode.LOVName = "BaArbeitTyp";
            this.edtTypCode.Name = "edtTypCode";
            this.edtTypCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTypCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTypCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTypCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtTypCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTypCode.Properties.Appearance.Options.UseFont = true;
            this.edtTypCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtTypCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtTypCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtTypCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtTypCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtTypCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtTypCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTypCode.Properties.NullText = "";
            this.edtTypCode.Properties.ShowFooter = false;
            this.edtTypCode.Properties.ShowHeader = false;
            this.edtTypCode.Size = new System.Drawing.Size(237, 24);
            this.edtTypCode.TabIndex = 7;
            // 
            // edtPensum
            // 
            this.edtPensum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtPensum.DataMember = "Pensum";
            this.edtPensum.DataSource = this.qryBaArbeit;
            this.edtPensum.Location = new System.Drawing.Point(89, 266);
            this.edtPensum.Name = "edtPensum";
            this.edtPensum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtPensum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPensum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPensum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPensum.Properties.Appearance.Options.UseBackColor = true;
            this.edtPensum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPensum.Properties.Appearance.Options.UseFont = true;
            this.edtPensum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPensum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPensum.Properties.Mask.EditMask = "d3";
            this.edtPensum.Properties.Name = "kissCalcEdit4.Properties";
            this.edtPensum.Properties.Precision = 3;
            this.edtPensum.Size = new System.Drawing.Size(40, 24);
            this.edtPensum.TabIndex = 9;
            this.edtPensum.EditValueChanged += new System.EventHandler(this.edtPensum_EditValueChanged);
            // 
            // memBemerkung
            // 
            this.memBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.memBemerkung.DataMember = "Bemerkung";
            this.memBemerkung.DataSource = this.qryBaArbeit;
            this.memBemerkung.Location = new System.Drawing.Point(89, 326);
            this.memBemerkung.Name = "memBemerkung";
            this.memBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.memBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.memBemerkung.Properties.Appearance.Options.UseFont = true;
            this.memBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memBemerkung.Properties.MaxLength = 300;
            this.memBemerkung.Properties.Name = "kissMemoEdit2.Properties";
            this.memBemerkung.Size = new System.Drawing.Size(237, 64);
            this.memBemerkung.TabIndex = 14;
            // 
            // dlgArbeitgeber
            // 
            this.dlgArbeitgeber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dlgArbeitgeber.DataMember = "InstitutionName";
            this.dlgArbeitgeber.DataSource = this.qryBaArbeit;
            this.dlgArbeitgeber.Location = new System.Drawing.Point(428, 236);
            this.dlgArbeitgeber.Name = "dlgArbeitgeber";
            this.dlgArbeitgeber.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.dlgArbeitgeber.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.dlgArbeitgeber.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.dlgArbeitgeber.Properties.Appearance.Options.UseBackColor = true;
            this.dlgArbeitgeber.Properties.Appearance.Options.UseBorderColor = true;
            this.dlgArbeitgeber.Properties.Appearance.Options.UseFont = true;
            this.dlgArbeitgeber.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.dlgArbeitgeber.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.dlgArbeitgeber.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dlgArbeitgeber.Properties.Name = "kissButtonEdit2.Properties";
            this.dlgArbeitgeber.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.dlgArbeitgeber.Size = new System.Drawing.Size(275, 24);
            this.dlgArbeitgeber.TabIndex = 17;
            this.dlgArbeitgeber.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.dlgArbeitgeber_UserModifiedFld);
            // 
            // edtAdresse
            // 
            this.edtAdresse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAdresse.DataMember = "Adresse";
            this.edtAdresse.DataSource = this.qryBaArbeit;
            this.edtAdresse.Location = new System.Drawing.Point(428, 266);
            this.edtAdresse.Name = "edtAdresse";
            this.edtAdresse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAdresse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdresse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdresse.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdresse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdresse.Properties.Appearance.Options.UseFont = true;
            this.edtAdresse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdresse.Size = new System.Drawing.Size(275, 64);
            this.edtAdresse.TabIndex = 19;
            this.edtAdresse.EditValueChanged += new System.EventHandler(this.edtAdresse_EditValueChanged);
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBemerkung.Location = new System.Drawing.Point(3, 326);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(80, 24);
            this.lblBemerkung.TabIndex = 13;
            this.lblBemerkung.Text = "Bemerkung";
            // 
            // lblTitle
            // 
            this.lblTitle.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblTitle.Location = new System.Drawing.Point(0, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(195, 16);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Arbeitssituation";
            // 
            // lblPensum
            // 
            this.lblPensum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPensum.Location = new System.Drawing.Point(3, 266);
            this.lblPensum.Name = "lblPensum";
            this.lblPensum.Size = new System.Drawing.Size(80, 24);
            this.lblPensum.TabIndex = 8;
            this.lblPensum.Text = "Pensum";
            // 
            // kissLabel57
            // 
            this.kissLabel57.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel57.Location = new System.Drawing.Point(135, 266);
            this.kissLabel57.Name = "kissLabel57";
            this.kissLabel57.Size = new System.Drawing.Size(20, 24);
            this.kissLabel57.TabIndex = 10;
            this.kissLabel57.Text = "%";
            this.kissLabel57.UseCompatibleTextRendering = true;
            // 
            // lblDatumVon
            // 
            this.lblDatumVon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDatumVon.Location = new System.Drawing.Point(3, 206);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(80, 24);
            this.lblDatumVon.TabIndex = 2;
            this.lblDatumVon.Text = "Datum von";
            // 
            // kissLabel59
            // 
            this.kissLabel59.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel59.Location = new System.Drawing.Point(195, 206);
            this.kissLabel59.Name = "kissLabel59";
            this.kissLabel59.Size = new System.Drawing.Size(25, 24);
            this.kissLabel59.TabIndex = 4;
            this.kissLabel59.Text = "bis";
            this.kissLabel59.UseCompatibleTextRendering = true;
            // 
            // kissLabel61
            // 
            this.kissLabel61.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel61.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel61.Location = new System.Drawing.Point(336, 210);
            this.kissLabel61.Name = "kissLabel61";
            this.kissLabel61.Size = new System.Drawing.Size(239, 16);
            this.kissLabel61.TabIndex = 15;
            this.kissLabel61.Text = "Arbeitgeber / Anbieter";
            // 
            // lblTypCode
            // 
            this.lblTypCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTypCode.Location = new System.Drawing.Point(3, 236);
            this.lblTypCode.Name = "lblTypCode";
            this.lblTypCode.Size = new System.Drawing.Size(80, 24);
            this.lblTypCode.TabIndex = 6;
            this.lblTypCode.Text = "Typ";
            // 
            // lblInstitutionName
            // 
            this.lblInstitutionName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInstitutionName.Location = new System.Drawing.Point(337, 236);
            this.lblInstitutionName.Name = "lblInstitutionName";
            this.lblInstitutionName.Size = new System.Drawing.Size(85, 24);
            this.lblInstitutionName.TabIndex = 16;
            this.lblInstitutionName.Text = "aus Inst. Stamm";
            // 
            // lblAdresse
            // 
            this.lblAdresse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAdresse.Location = new System.Drawing.Point(337, 266);
            this.lblAdresse.Name = "lblAdresse";
            this.lblAdresse.Size = new System.Drawing.Size(85, 24);
            this.lblAdresse.TabIndex = 18;
            this.lblAdresse.Text = "Name/Adresse";
            // 
            // lblHinweis
            // 
            this.lblHinweis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblHinweis.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblHinweis.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblHinweis.Location = new System.Drawing.Point(340, 333);
            this.lblHinweis.Name = "lblHinweis";
            this.lblHinweis.Size = new System.Drawing.Size(268, 40);
            this.lblHinweis.TabIndex = 20;
            this.lblHinweis.Text = "Bei Lohnabtretung muss der Arbeitgeber aus dem Institutionenstamm gewählt werden." +
    "";
            // 
            // edtGrundTeilzeit
            // 
            this.edtGrundTeilzeit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtGrundTeilzeit.DataMember = "BaGrundTeilzeitCode";
            this.edtGrundTeilzeit.DataSource = this.qryBaArbeit;
            this.edtGrundTeilzeit.Location = new System.Drawing.Point(89, 296);
            this.edtGrundTeilzeit.LOVName = "BaGrundTeilzeit";
            this.edtGrundTeilzeit.Name = "edtGrundTeilzeit";
            this.edtGrundTeilzeit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGrundTeilzeit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrundTeilzeit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrundTeilzeit.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrundTeilzeit.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrundTeilzeit.Properties.Appearance.Options.UseFont = true;
            this.edtGrundTeilzeit.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtGrundTeilzeit.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrundTeilzeit.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtGrundTeilzeit.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtGrundTeilzeit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtGrundTeilzeit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtGrundTeilzeit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGrundTeilzeit.Properties.NullText = "";
            this.edtGrundTeilzeit.Properties.ShowFooter = false;
            this.edtGrundTeilzeit.Properties.ShowHeader = false;
            this.edtGrundTeilzeit.Size = new System.Drawing.Size(237, 24);
            this.edtGrundTeilzeit.TabIndex = 12;
            // 
            // lblGrundTeilzeit
            // 
            this.lblGrundTeilzeit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGrundTeilzeit.Location = new System.Drawing.Point(3, 296);
            this.lblGrundTeilzeit.Name = "lblGrundTeilzeit";
            this.lblGrundTeilzeit.Size = new System.Drawing.Size(80, 24);
            this.lblGrundTeilzeit.TabIndex = 11;
            this.lblGrundTeilzeit.Text = "Grund Teilzeit";
            // 
            // CtlBaPersonArbeit
            // 
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(706, 287);
            this.Controls.Add(this.lblGrundTeilzeit);
            this.Controls.Add(this.edtGrundTeilzeit);
            this.Controls.Add(this.lblHinweis);
            this.Controls.Add(this.lblAdresse);
            this.Controls.Add(this.lblInstitutionName);
            this.Controls.Add(this.lblTypCode);
            this.Controls.Add(this.kissLabel61);
            this.Controls.Add(this.kissLabel59);
            this.Controls.Add(this.lblDatumVon);
            this.Controls.Add(this.kissLabel57);
            this.Controls.Add(this.lblPensum);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.edtAdresse);
            this.Controls.Add(this.dlgArbeitgeber);
            this.Controls.Add(this.memBemerkung);
            this.Controls.Add(this.edtPensum);
            this.Controls.Add(this.edtTypCode);
            this.Controls.Add(this.edtDatumBis);
            this.Controls.Add(this.edtDatumVon);
            this.Controls.Add(this.grdBaArbeitIntegration);
            this.Name = "CtlBaPersonArbeit";
            this.Size = new System.Drawing.Size(706, 398);
            this.AddData += new System.EventHandler(this.CtlBaPersonArbeit_AddData);
            this.DeleteData += new System.EventHandler(this.CtlBaPersonArbeit_DeleteData);
            this.MoveFirst += new System.EventHandler(this.CtlBaPersonArbeit_MoveFirst);
            this.MoveLast += new System.EventHandler(this.CtlBaPersonArbeit_MoveLast);
            this.MoveNext += new System.EventHandler(this.CtlBaPersonArbeit_MoveNext);
            this.MovePrevious += new System.EventHandler(this.CtlBaPersonArbeit_MovePrevious);
            this.RefreshData += new System.EventHandler(this.CtlBaPersonArbeit_RefreshData);
            this.SaveData += new System.EventHandler(this.CtlBaPersonArbeit_SaveData);
            this.UndoDataChanges += new System.EventHandler(this.CtlBaPersonArbeit_UndoDataChanges);
            this.Load += new System.EventHandler(this.CtlBaPersonArbeit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdBaArbeitIntegration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaArbeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaArbeitIntegration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTypCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTypCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPensum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dlgArbeitgeber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPensum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel57)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel59)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel61)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTypCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInstitutionName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHinweis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundTeilzeit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundTeilzeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundTeilzeit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

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

        private Gui.KissLabel lblGrundTeilzeit;
        private Gui.KissLookUpEdit edtGrundTeilzeit;
    }
}