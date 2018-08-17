namespace KiSS4.Basis.ZH
{
    public partial class CtlBaPersonErsatzeinkommen
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colBaErsatzeinkommenCode;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumAbgelehnt;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumAnspruchAb;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumAntrag;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumBeendet;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissLookUpEdit edtBaErsatzeinkommenCode;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private KiSS4.Gui.KissCalcEdit edtBetrag;
        private KiSS4.Gui.KissCalcEdit edtBetragALBV;
        private KiSS4.Gui.KissDateEdit edtDatumAbgelehnt;
        private KiSS4.Gui.KissDateEdit edtDatumAnspruchAb;
        private KiSS4.Gui.KissDateEdit edtDatumAntrag;
        private KiSS4.Gui.KissDateEdit edtDatumBeendet;
        private KiSS4.Gui.KissGrid grdBaErsatzeinkommen;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBaErsatzeinkommen;
        private KiSS4.Gui.KissLabel lblBaErsatzeinkommenCode;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblBetrag;
        private KiSS4.Gui.KissLabel lblBetragALBV;
        private KiSS4.Gui.KissLabel lblCHF;
        private KiSS4.Gui.KissLabel lblCHFMonat;
        private KiSS4.Gui.KissLabel lblDatumAbgelehnt;
        private KiSS4.Gui.KissLabel lblDatumAnspruchAb;
        private KiSS4.Gui.KissLabel lblDatumAntrag;
        private KiSS4.Gui.KissLabel lblDatumBeendet;
        private KiSS4.DB.SqlQuery qryBaErsatzeinkommen;

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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBaPersonErsatzeinkommen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdBaErsatzeinkommen = new KiSS4.Gui.KissGrid();
            this.qryBaErsatzeinkommen = new KiSS4.DB.SqlQuery(this.components);
            this.grvBaErsatzeinkommen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBaErsatzeinkommenCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumAntrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumAbgelehnt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumAnspruchAb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumBeendet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtBaErsatzeinkommenCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblBaErsatzeinkommenCode = new KiSS4.Gui.KissLabel();
            this.edtDatumAntrag = new KiSS4.Gui.KissDateEdit();
            this.edtDatumAbgelehnt = new KiSS4.Gui.KissDateEdit();
            this.edtDatumAnspruchAb = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBeendet = new KiSS4.Gui.KissDateEdit();
            this.lblDatumAntrag = new KiSS4.Gui.KissLabel();
            this.edtBetrag = new KiSS4.Gui.KissCalcEdit();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.lblDatumAnspruchAb = new KiSS4.Gui.KissLabel();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.lblBetrag = new KiSS4.Gui.KissLabel();
            this.lblCHFMonat = new KiSS4.Gui.KissLabel();
            this.lblDatumAbgelehnt = new KiSS4.Gui.KissLabel();
            this.lblDatumBeendet = new KiSS4.Gui.KissLabel();
            this.edtBetragALBV = new KiSS4.Gui.KissCalcEdit();
            this.lblBetragALBV = new KiSS4.Gui.KissLabel();
            this.lblCHF = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaErsatzeinkommen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaErsatzeinkommen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaErsatzeinkommen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaErsatzeinkommenCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaErsatzeinkommenCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaErsatzeinkommenCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumAntrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumAbgelehnt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumAnspruchAb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBeendet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumAntrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumAnspruchAb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHFMonat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumAbgelehnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBeendet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetragALBV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetragALBV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHF)).BeginInit();
            this.SuspendLayout();
            // 
            // grdBaErsatzeinkommen
            // 
            this.grdBaErsatzeinkommen.DataSource = this.qryBaErsatzeinkommen;
            // 
            // 
            // 
            this.grdBaErsatzeinkommen.EmbeddedNavigator.Name = "gridCtlKiSS3UserMask_Vm_Massnahme_MF_Verwaltung_SozialVers.EmbeddedNavigator";
            this.grdBaErsatzeinkommen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBaErsatzeinkommen.Location = new System.Drawing.Point(5, 5);
            this.grdBaErsatzeinkommen.MainView = this.grvBaErsatzeinkommen;
            this.grdBaErsatzeinkommen.Name = "grdBaErsatzeinkommen";
            this.grdBaErsatzeinkommen.Size = new System.Drawing.Size(675, 292);
            this.grdBaErsatzeinkommen.TabIndex = 0;
            this.grdBaErsatzeinkommen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBaErsatzeinkommen});
            // 
            // qryBaErsatzeinkommen
            // 
            this.qryBaErsatzeinkommen.CanDelete = true;
            this.qryBaErsatzeinkommen.CanInsert = true;
            this.qryBaErsatzeinkommen.CanUpdate = true;
            this.qryBaErsatzeinkommen.HostControl = this;
            this.qryBaErsatzeinkommen.SelectStatement = "SELECT *\r\nFROM BaErsatzeinkommen \r\nWHERE BaPersonID = {0}";
            this.qryBaErsatzeinkommen.TableName = "BaErsatzeinkommen";
            this.qryBaErsatzeinkommen.AfterFill += new System.EventHandler(this.qryBaErsatzeinkommen_AfterFill);
            this.qryBaErsatzeinkommen.AfterInsert += new System.EventHandler(this.qryBaErsatzeinkommen_AfterInsert);
            this.qryBaErsatzeinkommen.BeforePost += new System.EventHandler(this.qryBaErsatzeinkommen_BeforePost);
            this.qryBaErsatzeinkommen.PositionChanged += new System.EventHandler(this.qryBaErsatzeinkommen_PositionChanged);
            // 
            // grvBaErsatzeinkommen
            // 
            this.grvBaErsatzeinkommen.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBaErsatzeinkommen.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaErsatzeinkommen.Appearance.Empty.Options.UseBackColor = true;
            this.grvBaErsatzeinkommen.Appearance.Empty.Options.UseFont = true;
            this.grvBaErsatzeinkommen.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaErsatzeinkommen.Appearance.EvenRow.Options.UseFont = true;
            this.grvBaErsatzeinkommen.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaErsatzeinkommen.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaErsatzeinkommen.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBaErsatzeinkommen.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBaErsatzeinkommen.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBaErsatzeinkommen.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBaErsatzeinkommen.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaErsatzeinkommen.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaErsatzeinkommen.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBaErsatzeinkommen.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBaErsatzeinkommen.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBaErsatzeinkommen.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBaErsatzeinkommen.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaErsatzeinkommen.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBaErsatzeinkommen.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaErsatzeinkommen.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaErsatzeinkommen.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaErsatzeinkommen.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBaErsatzeinkommen.Appearance.GroupRow.Options.UseFont = true;
            this.grvBaErsatzeinkommen.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBaErsatzeinkommen.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBaErsatzeinkommen.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBaErsatzeinkommen.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaErsatzeinkommen.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBaErsatzeinkommen.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBaErsatzeinkommen.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBaErsatzeinkommen.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBaErsatzeinkommen.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaErsatzeinkommen.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaErsatzeinkommen.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBaErsatzeinkommen.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBaErsatzeinkommen.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBaErsatzeinkommen.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaErsatzeinkommen.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBaErsatzeinkommen.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaErsatzeinkommen.Appearance.OddRow.Options.UseFont = true;
            this.grvBaErsatzeinkommen.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBaErsatzeinkommen.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaErsatzeinkommen.Appearance.Row.Options.UseBackColor = true;
            this.grvBaErsatzeinkommen.Appearance.Row.Options.UseFont = true;
            this.grvBaErsatzeinkommen.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaErsatzeinkommen.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBaErsatzeinkommen.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaErsatzeinkommen.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBaErsatzeinkommen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBaErsatzeinkommen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBaErsatzeinkommenCode,
            this.colDatumAntrag,
            this.colDatumAbgelehnt,
            this.colDatumAnspruchAb,
            this.colDatumBeendet,
            this.colBetrag});
            this.grvBaErsatzeinkommen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBaErsatzeinkommen.GridControl = this.grdBaErsatzeinkommen;
            this.grvBaErsatzeinkommen.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvBaErsatzeinkommen.Name = "grvBaErsatzeinkommen";
            this.grvBaErsatzeinkommen.OptionsBehavior.Editable = false;
            this.grvBaErsatzeinkommen.OptionsCustomization.AllowFilter = false;
            this.grvBaErsatzeinkommen.OptionsFilter.AllowFilterEditor = false;
            this.grvBaErsatzeinkommen.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBaErsatzeinkommen.OptionsMenu.EnableColumnMenu = false;
            this.grvBaErsatzeinkommen.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBaErsatzeinkommen.OptionsNavigation.UseTabKey = false;
            this.grvBaErsatzeinkommen.OptionsView.ColumnAutoWidth = false;
            this.grvBaErsatzeinkommen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBaErsatzeinkommen.OptionsView.ShowGroupPanel = false;
            this.grvBaErsatzeinkommen.OptionsView.ShowIndicator = false;
            // 
            // colBaErsatzeinkommenCode
            // 
            this.colBaErsatzeinkommenCode.Caption = "Art";
            this.colBaErsatzeinkommenCode.FieldName = "BaErsatzeinkommenCode";
            this.colBaErsatzeinkommenCode.Name = "colBaErsatzeinkommenCode";
            this.colBaErsatzeinkommenCode.Visible = true;
            this.colBaErsatzeinkommenCode.VisibleIndex = 0;
            this.colBaErsatzeinkommenCode.Width = 258;
            // 
            // colDatumAntrag
            // 
            this.colDatumAntrag.Caption = "beantragt";
            this.colDatumAntrag.FieldName = "DatumAntrag";
            this.colDatumAntrag.Name = "colDatumAntrag";
            this.colDatumAntrag.Visible = true;
            this.colDatumAntrag.VisibleIndex = 1;
            this.colDatumAntrag.Width = 80;
            // 
            // colDatumAbgelehnt
            // 
            this.colDatumAbgelehnt.Caption = "abgelehnt";
            this.colDatumAbgelehnt.FieldName = "DatumAbgelehnt";
            this.colDatumAbgelehnt.Name = "colDatumAbgelehnt";
            this.colDatumAbgelehnt.Visible = true;
            this.colDatumAbgelehnt.VisibleIndex = 2;
            this.colDatumAbgelehnt.Width = 80;
            // 
            // colDatumAnspruchAb
            // 
            this.colDatumAnspruchAb.Caption = "Anspruch ab";
            this.colDatumAnspruchAb.FieldName = "DatumAnspruchAb";
            this.colDatumAnspruchAb.Name = "colDatumAnspruchAb";
            this.colDatumAnspruchAb.Visible = true;
            this.colDatumAnspruchAb.VisibleIndex = 3;
            this.colDatumAnspruchAb.Width = 80;
            // 
            // colDatumBeendet
            // 
            this.colDatumBeendet.Caption = "Beendet";
            this.colDatumBeendet.FieldName = "DatumBeendet";
            this.colDatumBeendet.Name = "colDatumBeendet";
            this.colDatumBeendet.Visible = true;
            this.colDatumBeendet.VisibleIndex = 4;
            this.colDatumBeendet.Width = 80;
            // 
            // colBetrag
            // 
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "n2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 5;
            this.colBetrag.Width = 80;
            // 
            // edtBaErsatzeinkommenCode
            // 
            this.edtBaErsatzeinkommenCode.DataMember = "BaErsatzeinkommenCode";
            this.edtBaErsatzeinkommenCode.DataSource = this.qryBaErsatzeinkommen;
            this.edtBaErsatzeinkommenCode.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtBaErsatzeinkommenCode.Location = new System.Drawing.Point(106, 314);
            this.edtBaErsatzeinkommenCode.LOVName = "BaErsatzeinkommen";
            this.edtBaErsatzeinkommenCode.Name = "edtBaErsatzeinkommenCode";
            this.edtBaErsatzeinkommenCode.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtBaErsatzeinkommenCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaErsatzeinkommenCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaErsatzeinkommenCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaErsatzeinkommenCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaErsatzeinkommenCode.Properties.Appearance.Options.UseFont = true;
            this.edtBaErsatzeinkommenCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBaErsatzeinkommenCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaErsatzeinkommenCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBaErsatzeinkommenCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBaErsatzeinkommenCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtBaErsatzeinkommenCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtBaErsatzeinkommenCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaErsatzeinkommenCode.Properties.Name = "edtVmMfSozialversBezeichnung.Properties";
            this.edtBaErsatzeinkommenCode.Properties.NullText = "";
            this.edtBaErsatzeinkommenCode.Properties.ShowFooter = false;
            this.edtBaErsatzeinkommenCode.Properties.ShowHeader = false;
            this.edtBaErsatzeinkommenCode.Size = new System.Drawing.Size(357, 24);
            this.edtBaErsatzeinkommenCode.TabIndex = 1;
            this.edtBaErsatzeinkommenCode.EditValueChanged += new System.EventHandler(this.edtBaErsatzeinkommenCode_EditValueChanged);
            // 
            // lblBaErsatzeinkommenCode
            // 
            this.lblBaErsatzeinkommenCode.Location = new System.Drawing.Point(10, 314);
            this.lblBaErsatzeinkommenCode.Name = "lblBaErsatzeinkommenCode";
            this.lblBaErsatzeinkommenCode.Size = new System.Drawing.Size(90, 24);
            this.lblBaErsatzeinkommenCode.TabIndex = 1;
            this.lblBaErsatzeinkommenCode.Text = "Art";
            this.lblBaErsatzeinkommenCode.UseCompatibleTextRendering = true;
            // 
            // edtDatumAntrag
            // 
            this.edtDatumAntrag.DataMember = "DatumAntrag";
            this.edtDatumAntrag.DataSource = this.qryBaErsatzeinkommen;
            this.edtDatumAntrag.EditMode = Kiss.Interfaces.UI.EditModeType.Optional;
            this.edtDatumAntrag.EditValue = null;
            this.edtDatumAntrag.Location = new System.Drawing.Point(106, 344);
            this.edtDatumAntrag.Name = "edtDatumAntrag";
            this.edtDatumAntrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumAntrag.Properties.Appearance.BackColor = System.Drawing.Color.LightCyan;
            this.edtDatumAntrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumAntrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumAntrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumAntrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumAntrag.Properties.Appearance.Options.UseFont = true;
            this.edtDatumAntrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtDatumAntrag.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumAntrag.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtDatumAntrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumAntrag.Properties.Name = "edtVmMfSozialversEingereicht.Properties";
            this.edtDatumAntrag.Properties.ShowToday = false;
            this.edtDatumAntrag.Size = new System.Drawing.Size(100, 24);
            this.edtDatumAntrag.TabIndex = 2;
            // 
            // edtDatumAbgelehnt
            // 
            this.edtDatumAbgelehnt.DataMember = "DatumAbgelehnt";
            this.edtDatumAbgelehnt.DataSource = this.qryBaErsatzeinkommen;
            this.edtDatumAbgelehnt.EditMode = Kiss.Interfaces.UI.EditModeType.Optional;
            this.edtDatumAbgelehnt.EditValue = null;
            this.edtDatumAbgelehnt.Location = new System.Drawing.Point(363, 344);
            this.edtDatumAbgelehnt.Name = "edtDatumAbgelehnt";
            this.edtDatumAbgelehnt.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumAbgelehnt.Properties.Appearance.BackColor = System.Drawing.Color.LightCyan;
            this.edtDatumAbgelehnt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumAbgelehnt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumAbgelehnt.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumAbgelehnt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumAbgelehnt.Properties.Appearance.Options.UseFont = true;
            this.edtDatumAbgelehnt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtDatumAbgelehnt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumAbgelehnt.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtDatumAbgelehnt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumAbgelehnt.Properties.ShowToday = false;
            this.edtDatumAbgelehnt.Size = new System.Drawing.Size(100, 24);
            this.edtDatumAbgelehnt.TabIndex = 3;
            // 
            // edtDatumAnspruchAb
            // 
            this.edtDatumAnspruchAb.DataMember = "DatumAnspruchAb";
            this.edtDatumAnspruchAb.DataSource = this.qryBaErsatzeinkommen;
            this.edtDatumAnspruchAb.EditValue = null;
            this.edtDatumAnspruchAb.Location = new System.Drawing.Point(106, 374);
            this.edtDatumAnspruchAb.Name = "edtDatumAnspruchAb";
            this.edtDatumAnspruchAb.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumAnspruchAb.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumAnspruchAb.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumAnspruchAb.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumAnspruchAb.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumAnspruchAb.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumAnspruchAb.Properties.Appearance.Options.UseFont = true;
            this.edtDatumAnspruchAb.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtDatumAnspruchAb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumAnspruchAb.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtDatumAnspruchAb.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumAnspruchAb.Properties.Name = "edtVmMfSozialversVerfügungvom.Properties";
            this.edtDatumAnspruchAb.Properties.ShowToday = false;
            this.edtDatumAnspruchAb.Size = new System.Drawing.Size(100, 24);
            this.edtDatumAnspruchAb.TabIndex = 4;
            // 
            // edtDatumBeendet
            // 
            this.edtDatumBeendet.DataMember = "DatumBeendet";
            this.edtDatumBeendet.DataSource = this.qryBaErsatzeinkommen;
            this.edtDatumBeendet.EditValue = null;
            this.edtDatumBeendet.Location = new System.Drawing.Point(363, 374);
            this.edtDatumBeendet.Name = "edtDatumBeendet";
            this.edtDatumBeendet.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBeendet.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBeendet.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBeendet.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBeendet.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBeendet.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBeendet.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBeendet.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtDatumBeendet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBeendet.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtDatumBeendet.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBeendet.Properties.ShowToday = false;
            this.edtDatumBeendet.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBeendet.TabIndex = 5;
            // 
            // lblDatumAntrag
            // 
            this.lblDatumAntrag.Location = new System.Drawing.Point(10, 344);
            this.lblDatumAntrag.Name = "lblDatumAntrag";
            this.lblDatumAntrag.Size = new System.Drawing.Size(90, 24);
            this.lblDatumAntrag.TabIndex = 5;
            this.lblDatumAntrag.Text = "beantragt am";
            this.lblDatumAntrag.UseCompatibleTextRendering = true;
            // 
            // edtBetrag
            // 
            this.edtBetrag.DataMember = "Betrag";
            this.edtBetrag.DataSource = this.qryBaErsatzeinkommen;
            this.edtBetrag.Location = new System.Drawing.Point(106, 404);
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
            this.edtBetrag.Properties.DisplayFormat.FormatString = "n2";
            this.edtBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Properties.EditFormat.FormatString = "n2";
            this.edtBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Properties.Mask.EditMask = "n2";
            this.edtBetrag.Properties.Name = "edtVmMfSozialversVerfügungsbetrag.Properties";
            this.edtBetrag.Size = new System.Drawing.Size(100, 24);
            this.edtBetrag.TabIndex = 6;
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryBaErsatzeinkommen;
            this.edtBemerkung.Location = new System.Drawing.Point(106, 434);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Properties.MaxLength = 300;
            this.edtBemerkung.Size = new System.Drawing.Size(574, 52);
            this.edtBemerkung.TabIndex = 7;
            // 
            // lblDatumAnspruchAb
            // 
            this.lblDatumAnspruchAb.Location = new System.Drawing.Point(10, 374);
            this.lblDatumAnspruchAb.Name = "lblDatumAnspruchAb";
            this.lblDatumAnspruchAb.Size = new System.Drawing.Size(90, 24);
            this.lblDatumAnspruchAb.TabIndex = 7;
            this.lblDatumAnspruchAb.Text = "Anspruch ab";
            this.lblDatumAnspruchAb.UseCompatibleTextRendering = true;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.Location = new System.Drawing.Point(10, 434);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(90, 24);
            this.lblBemerkung.TabIndex = 11;
            this.lblBemerkung.Text = "Bemerkung";
            this.lblBemerkung.UseCompatibleTextRendering = true;
            // 
            // lblBetrag
            // 
            this.lblBetrag.Location = new System.Drawing.Point(10, 404);
            this.lblBetrag.Name = "lblBetrag";
            this.lblBetrag.Size = new System.Drawing.Size(90, 24);
            this.lblBetrag.TabIndex = 15;
            this.lblBetrag.Text = "Betrag";
            this.lblBetrag.UseCompatibleTextRendering = true;
            // 
            // lblCHFMonat
            // 
            this.lblCHFMonat.Location = new System.Drawing.Point(208, 404);
            this.lblCHFMonat.Name = "lblCHFMonat";
            this.lblCHFMonat.Size = new System.Drawing.Size(68, 24);
            this.lblCHFMonat.TabIndex = 101;
            this.lblCHFMonat.Text = "CHF/Monat";
            this.lblCHFMonat.UseCompatibleTextRendering = true;
            // 
            // lblDatumAbgelehnt
            // 
            this.lblDatumAbgelehnt.Location = new System.Drawing.Point(283, 344);
            this.lblDatumAbgelehnt.Name = "lblDatumAbgelehnt";
            this.lblDatumAbgelehnt.Size = new System.Drawing.Size(74, 24);
            this.lblDatumAbgelehnt.TabIndex = 102;
            this.lblDatumAbgelehnt.Text = "abgelehnt am";
            this.lblDatumAbgelehnt.UseCompatibleTextRendering = true;
            // 
            // lblDatumBeendet
            // 
            this.lblDatumBeendet.Location = new System.Drawing.Point(283, 374);
            this.lblDatumBeendet.Name = "lblDatumBeendet";
            this.lblDatumBeendet.Size = new System.Drawing.Size(74, 24);
            this.lblDatumBeendet.TabIndex = 103;
            this.lblDatumBeendet.Text = "Anspruch bis";
            this.lblDatumBeendet.UseCompatibleTextRendering = true;
            // 
            // edtBetragALBV
            // 
            this.edtBetragALBV.DataMember = "BetragALBV";
            this.edtBetragALBV.DataSource = this.qryBaErsatzeinkommen;
            this.edtBetragALBV.Location = new System.Drawing.Point(362, 404);
            this.edtBetragALBV.Name = "edtBetragALBV";
            this.edtBetragALBV.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBetragALBV.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBetragALBV.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetragALBV.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetragALBV.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetragALBV.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetragALBV.Properties.Appearance.Options.UseFont = true;
            this.edtBetragALBV.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetragALBV.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetragALBV.Properties.DisplayFormat.FormatString = "n2";
            this.edtBetragALBV.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetragALBV.Properties.EditFormat.FormatString = "n2";
            this.edtBetragALBV.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetragALBV.Properties.Mask.EditMask = "n2";
            this.edtBetragALBV.Properties.Name = "edtVmMfSozialversVerfügungsbetrag.Properties";
            this.edtBetragALBV.Size = new System.Drawing.Size(100, 24);
            this.edtBetragALBV.TabIndex = 104;
            // 
            // lblBetragALBV
            // 
            this.lblBetragALBV.Location = new System.Drawing.Point(283, 404);
            this.lblBetragALBV.Name = "lblBetragALBV";
            this.lblBetragALBV.Size = new System.Drawing.Size(74, 24);
            this.lblBetragALBV.TabIndex = 105;
            this.lblBetragALBV.Text = "davon ALBV";
            this.lblBetragALBV.UseCompatibleTextRendering = true;
            // 
            // lblCHF
            // 
            this.lblCHF.Location = new System.Drawing.Point(468, 404);
            this.lblCHF.Name = "lblCHF";
            this.lblCHF.Size = new System.Drawing.Size(32, 24);
            this.lblCHF.TabIndex = 107;
            this.lblCHF.Text = "CHF";
            this.lblCHF.UseCompatibleTextRendering = true;
            // 
            // CtlBaPersonErsatzeinkommen
            // 
            this.ActiveSQLQuery = this.qryBaErsatzeinkommen;
            this.Controls.Add(this.lblCHF);
            this.Controls.Add(this.lblBetragALBV);
            this.Controls.Add(this.edtBetragALBV);
            this.Controls.Add(this.lblDatumBeendet);
            this.Controls.Add(this.lblDatumAbgelehnt);
            this.Controls.Add(this.lblCHFMonat);
            this.Controls.Add(this.lblBetrag);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.lblDatumAnspruchAb);
            this.Controls.Add(this.edtBemerkung);
            this.Controls.Add(this.edtBetrag);
            this.Controls.Add(this.lblDatumAntrag);
            this.Controls.Add(this.edtDatumBeendet);
            this.Controls.Add(this.edtDatumAnspruchAb);
            this.Controls.Add(this.edtDatumAbgelehnt);
            this.Controls.Add(this.edtDatumAntrag);
            this.Controls.Add(this.lblBaErsatzeinkommenCode);
            this.Controls.Add(this.edtBaErsatzeinkommenCode);
            this.Controls.Add(this.grdBaErsatzeinkommen);
            this.Name = "CtlBaPersonErsatzeinkommen";
            this.Size = new System.Drawing.Size(683, 496);
            ((System.ComponentModel.ISupportInitialize)(this.grdBaErsatzeinkommen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaErsatzeinkommen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaErsatzeinkommen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaErsatzeinkommenCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaErsatzeinkommenCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaErsatzeinkommenCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumAntrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumAbgelehnt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumAnspruchAb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBeendet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumAntrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumAnspruchAb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHFMonat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumAbgelehnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBeendet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetragALBV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetragALBV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHF)).EndInit();
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
   }
}