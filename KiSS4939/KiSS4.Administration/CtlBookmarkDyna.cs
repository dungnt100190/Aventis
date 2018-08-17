using KiSS4.DB;

namespace KiSS4.Administration
{
	public class CtlBookmarkDyna : KiSS4.Gui.KissUserControl
	{
		private DevExpress.XtraGrid.Views.Grid.GridView grvDynaField;
		private KiSS4.Gui.KissLabel lblModulCode;
		private KiSS4.Gui.KissLabel lblMaskName;
		private DevExpress.XtraGrid.Columns.GridColumn colModulCode;
		private DevExpress.XtraGrid.Columns.GridColumn colMaskName;
		private KiSS4.Gui.KissLabel lblFieldName;
		private KiSS4.DB.SqlQuery qryDynaField;
		private DevExpress.XtraGrid.Columns.GridColumn colFieldName;
		private KiSS4.Gui.KissTextEdit edtMaskName;
		private KiSS4.Gui.KissLookUpEdit edtModulCode;
		private KiSS4.Gui.KissTextEdit edtFieldName;
		private KiSS4.Gui.KissGrid grdDynaField;
		private KiSS4.Gui.KissLabel lblLOVName;
		private KiSS4.Gui.KissLabel lblTabName;
		private KiSS4.Gui.KissLookUpEdit edtFieldCode;
		private KiSS4.Gui.KissLabel lblFieldCode;
		private KiSS4.Gui.KissTextEdit edtLOVName;
		private KiSS4.Gui.KissTextEdit edtTabName;
		private DevExpress.XtraGrid.Columns.GridColumn colFieldCode;
		private DevExpress.XtraGrid.Columns.GridColumn colLOVName;
		private DevExpress.XtraGrid.Columns.GridColumn colTabName;
		private System.ComponentModel.IContainer components = null;

		public CtlBookmarkDyna()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdDynaField = new KiSS4.Gui.KissGrid();
            this.qryDynaField = new KiSS4.DB.SqlQuery(this.components);
            this.grvDynaField = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colModulCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaskName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFieldName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFieldCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLOVName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTabName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblModulCode = new KiSS4.Gui.KissLabel();
            this.lblMaskName = new KiSS4.Gui.KissLabel();
            this.edtMaskName = new KiSS4.Gui.KissTextEdit();
            this.edtModulCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblFieldName = new KiSS4.Gui.KissLabel();
            this.edtFieldName = new KiSS4.Gui.KissTextEdit();
            this.lblLOVName = new KiSS4.Gui.KissLabel();
            this.lblTabName = new KiSS4.Gui.KissLabel();
            this.edtFieldCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblFieldCode = new KiSS4.Gui.KissLabel();
            this.edtLOVName = new KiSS4.Gui.KissTextEdit();
            this.edtTabName = new KiSS4.Gui.KissTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDynaField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryDynaField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDynaField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModulCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMaskName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMaskName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFieldName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFieldName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLOVName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTabName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFieldCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFieldCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFieldCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLOVName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTabName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDynaField
            // 
            this.grdDynaField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDynaField.DataSource = this.qryDynaField;
            this.grdDynaField.EmbeddedNavigator.Name = "";
            this.grdDynaField.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdDynaField.Location = new System.Drawing.Point(5, 10);
            this.grdDynaField.MainView = this.grvDynaField;
            this.grdDynaField.Name = "grdDynaField";
            this.grdDynaField.Size = new System.Drawing.Size(816, 373);
            this.grdDynaField.TabIndex = 0;
            this.grdDynaField.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDynaField});
            // 
            // qryDynaField
            // 
            this.qryDynaField.CanUpdate = true;
            this.qryDynaField.HostControl = this;
            this.qryDynaField.TableName = "DynaField";
            // 
            // grvDynaField
            // 
            this.grvDynaField.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvDynaField.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDynaField.Appearance.Empty.Options.UseBackColor = true;
            this.grvDynaField.Appearance.Empty.Options.UseFont = true;
            this.grvDynaField.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDynaField.Appearance.EvenRow.Options.UseFont = true;
            this.grvDynaField.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvDynaField.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDynaField.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvDynaField.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvDynaField.Appearance.FocusedCell.Options.UseFont = true;
            this.grvDynaField.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvDynaField.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvDynaField.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDynaField.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvDynaField.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvDynaField.Appearance.FocusedRow.Options.UseFont = true;
            this.grvDynaField.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvDynaField.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvDynaField.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvDynaField.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvDynaField.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvDynaField.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvDynaField.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvDynaField.Appearance.GroupRow.Options.UseFont = true;
            this.grvDynaField.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvDynaField.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvDynaField.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvDynaField.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvDynaField.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvDynaField.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvDynaField.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvDynaField.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvDynaField.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDynaField.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvDynaField.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvDynaField.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvDynaField.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvDynaField.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvDynaField.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvDynaField.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDynaField.Appearance.OddRow.Options.UseFont = true;
            this.grvDynaField.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvDynaField.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDynaField.Appearance.Row.Options.UseBackColor = true;
            this.grvDynaField.Appearance.Row.Options.UseFont = true;
            this.grvDynaField.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDynaField.Appearance.SelectedRow.Options.UseFont = true;
            this.grvDynaField.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvDynaField.Appearance.VertLine.Options.UseBackColor = true;
            this.grvDynaField.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvDynaField.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colModulCode,
            this.colMaskName,
            this.colFieldName,
            this.colFieldCode,
            this.colLOVName,
            this.colTabName});
            this.grvDynaField.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvDynaField.GridControl = this.grdDynaField;
            this.grvDynaField.Name = "grvDynaField";
            this.grvDynaField.OptionsBehavior.Editable = false;
            this.grvDynaField.OptionsCustomization.AllowFilter = false;
            this.grvDynaField.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvDynaField.OptionsNavigation.AutoFocusNewRow = true;
            this.grvDynaField.OptionsNavigation.UseTabKey = false;
            this.grvDynaField.OptionsView.ColumnAutoWidth = false;
            this.grvDynaField.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvDynaField.OptionsView.ShowGroupPanel = false;
            this.grvDynaField.OptionsView.ShowIndicator = false;
            // 
            // colModulCode
            // 
            this.colModulCode.Caption = "Modul";
            this.colModulCode.FieldName = "ModulID";
            this.colModulCode.Name = "colModulCode";
            this.colModulCode.Visible = true;
            this.colModulCode.VisibleIndex = 0;
            this.colModulCode.Width = 101;
            // 
            // colMaskName
            // 
            this.colMaskName.Caption = "Maske";
            this.colMaskName.FieldName = "DisplayText";
            this.colMaskName.Name = "colMaskName";
            this.colMaskName.Visible = true;
            this.colMaskName.VisibleIndex = 1;
            this.colMaskName.Width = 172;
            // 
            // colFieldName
            // 
            this.colFieldName.AppearanceCell.Options.UseTextOptions = true;
            this.colFieldName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colFieldName.Caption = "Textmarke";
            this.colFieldName.FieldName = "FieldName";
            this.colFieldName.Name = "colFieldName";
            this.colFieldName.Visible = true;
            this.colFieldName.VisibleIndex = 2;
            this.colFieldName.Width = 236;
            // 
            // colFieldCode
            // 
            this.colFieldCode.Caption = "FeldTyp";
            this.colFieldCode.FieldName = "FieldCode";
            this.colFieldCode.Name = "colFieldCode";
            this.colFieldCode.Visible = true;
            this.colFieldCode.VisibleIndex = 3;
            this.colFieldCode.Width = 122;
            // 
            // colLOVName
            // 
            this.colLOVName.Caption = "Werteliste";
            this.colLOVName.FieldName = "LOVName";
            this.colLOVName.Name = "colLOVName";
            this.colLOVName.Visible = true;
            this.colLOVName.VisibleIndex = 4;
            this.colLOVName.Width = 87;
            // 
            // colTabName
            // 
            this.colTabName.Caption = "Register";
            this.colTabName.FieldName = "TabName";
            this.colTabName.Name = "colTabName";
            this.colTabName.Visible = true;
            this.colTabName.VisibleIndex = 5;
            // 
            // lblModulCode
            // 
            this.lblModulCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblModulCode.Location = new System.Drawing.Point(5, 393);
            this.lblModulCode.Name = "lblModulCode";
            this.lblModulCode.Size = new System.Drawing.Size(44, 24);
            this.lblModulCode.TabIndex = 3;
            this.lblModulCode.Text = "Modul";
            // 
            // lblMaskName
            // 
            this.lblMaskName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMaskName.Location = new System.Drawing.Point(5, 423);
            this.lblMaskName.Name = "lblMaskName";
            this.lblMaskName.Size = new System.Drawing.Size(42, 24);
            this.lblMaskName.TabIndex = 6;
            this.lblMaskName.Text = "Maske";
            // 
            // edtMaskName
            // 
            this.edtMaskName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtMaskName.DataMember = "DisplayText";
            this.edtMaskName.DataSource = this.qryDynaField;
            this.edtMaskName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtMaskName.Location = new System.Drawing.Point(70, 423);
            this.edtMaskName.Name = "edtMaskName";
            this.edtMaskName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtMaskName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMaskName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMaskName.Properties.Appearance.Options.UseBackColor = true;
            this.edtMaskName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMaskName.Properties.Appearance.Options.UseFont = true;
            this.edtMaskName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMaskName.Properties.ReadOnly = true;
            this.edtMaskName.Size = new System.Drawing.Size(280, 24);
            this.edtMaskName.TabIndex = 2;
            // 
            // edtModulCode
            // 
            this.edtModulCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.edtModulCode.DataMember = "ModulID";
            this.edtModulCode.DataSource = this.qryDynaField;
            this.edtModulCode.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtModulCode.Location = new System.Drawing.Point(70, 393);
            this.edtModulCode.LOVName = "Modul";
            this.edtModulCode.Name = "edtModulCode";
            this.edtModulCode.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtModulCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtModulCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtModulCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtModulCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtModulCode.Properties.Appearance.Options.UseFont = true;
            this.edtModulCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtModulCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtModulCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtModulCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtModulCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtModulCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtModulCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtModulCode.Properties.NullText = "";
            this.edtModulCode.Properties.ReadOnly = true;
            this.edtModulCode.Properties.ShowFooter = false;
            this.edtModulCode.Properties.ShowHeader = false;
            this.edtModulCode.Size = new System.Drawing.Size(160, 24);
            this.edtModulCode.TabIndex = 1;
            // 
            // lblFieldName
            // 
            this.lblFieldName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFieldName.Location = new System.Drawing.Point(5, 453);
            this.lblFieldName.Name = "lblFieldName";
            this.lblFieldName.Size = new System.Drawing.Size(58, 24);
            this.lblFieldName.TabIndex = 7;
            this.lblFieldName.Text = "Textmarke";
            // 
            // edtFieldName
            // 
            this.edtFieldName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtFieldName.DataMember = "FieldName";
            this.edtFieldName.DataSource = this.qryDynaField;
            this.edtFieldName.Location = new System.Drawing.Point(70, 453);
            this.edtFieldName.Name = "edtFieldName";
            this.edtFieldName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFieldName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFieldName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFieldName.Properties.Appearance.Options.UseBackColor = true;
            this.edtFieldName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFieldName.Properties.Appearance.Options.UseFont = true;
            this.edtFieldName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFieldName.Size = new System.Drawing.Size(280, 24);
            this.edtFieldName.TabIndex = 3;
            // 
            // lblLOVName
            // 
            this.lblLOVName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLOVName.ForeColor = System.Drawing.Color.Black;
            this.lblLOVName.Location = new System.Drawing.Point(369, 424);
            this.lblLOVName.Name = "lblLOVName";
            this.lblLOVName.Size = new System.Drawing.Size(46, 24);
            this.lblLOVName.TabIndex = 44;
            this.lblLOVName.Text = "Wertliste";
            // 
            // lblTabName
            // 
            this.lblTabName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTabName.ForeColor = System.Drawing.Color.Black;
            this.lblTabName.Location = new System.Drawing.Point(369, 454);
            this.lblTabName.Name = "lblTabName";
            this.lblTabName.Size = new System.Drawing.Size(58, 24);
            this.lblTabName.TabIndex = 43;
            this.lblTabName.Text = "Register";
            // 
            // edtFieldCode
            // 
            this.edtFieldCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtFieldCode.DataMember = "FieldCode";
            this.edtFieldCode.DataSource = this.qryDynaField;
            this.edtFieldCode.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtFieldCode.Location = new System.Drawing.Point(429, 394);
            this.edtFieldCode.LOVName = "EigenesFeld";
            this.edtFieldCode.Name = "edtFieldCode";
            this.edtFieldCode.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtFieldCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFieldCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFieldCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtFieldCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFieldCode.Properties.Appearance.Options.UseFont = true;
            this.edtFieldCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtFieldCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtFieldCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtFieldCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtFieldCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtFieldCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtFieldCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFieldCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 170, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtFieldCode.Properties.DisplayMember = "Text";
            this.edtFieldCode.Properties.NullText = "";
            this.edtFieldCode.Properties.PopupWidth = 170;
            this.edtFieldCode.Properties.ReadOnly = true;
            this.edtFieldCode.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.edtFieldCode.Properties.ShowFooter = false;
            this.edtFieldCode.Properties.ShowHeader = false;
            this.edtFieldCode.Properties.ValueMember = "Code";
            this.edtFieldCode.Size = new System.Drawing.Size(201, 24);
            this.edtFieldCode.TabIndex = 4;
            // 
            // lblFieldCode
            // 
            this.lblFieldCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFieldCode.ForeColor = System.Drawing.Color.Black;
            this.lblFieldCode.Location = new System.Drawing.Point(369, 394);
            this.lblFieldCode.Name = "lblFieldCode";
            this.lblFieldCode.Size = new System.Drawing.Size(54, 24);
            this.lblFieldCode.TabIndex = 42;
            this.lblFieldCode.Text = "Feld-Typ";
            // 
            // edtLOVName
            // 
            this.edtLOVName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtLOVName.DataMember = "LOVName";
            this.edtLOVName.DataSource = this.qryDynaField;
            this.edtLOVName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtLOVName.Location = new System.Drawing.Point(429, 423);
            this.edtLOVName.Name = "edtLOVName";
            this.edtLOVName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtLOVName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLOVName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLOVName.Properties.Appearance.Options.UseBackColor = true;
            this.edtLOVName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLOVName.Properties.Appearance.Options.UseFont = true;
            this.edtLOVName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtLOVName.Properties.ReadOnly = true;
            this.edtLOVName.Size = new System.Drawing.Size(284, 24);
            this.edtLOVName.TabIndex = 5;
            // 
            // edtTabName
            // 
            this.edtTabName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtTabName.DataMember = "TabName";
            this.edtTabName.DataSource = this.qryDynaField;
            this.edtTabName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtTabName.Location = new System.Drawing.Point(429, 453);
            this.edtTabName.Name = "edtTabName";
            this.edtTabName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtTabName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTabName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTabName.Properties.Appearance.Options.UseBackColor = true;
            this.edtTabName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTabName.Properties.Appearance.Options.UseFont = true;
            this.edtTabName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTabName.Properties.ReadOnly = true;
            this.edtTabName.Size = new System.Drawing.Size(284, 24);
            this.edtTabName.TabIndex = 6;
            // 
            // CtlBookmarkDyna
            // 
            this.ActiveSQLQuery = this.qryDynaField;
            this.Controls.Add(this.edtTabName);
            this.Controls.Add(this.edtLOVName);
            this.Controls.Add(this.lblLOVName);
            this.Controls.Add(this.lblTabName);
            this.Controls.Add(this.edtFieldCode);
            this.Controls.Add(this.lblFieldCode);
            this.Controls.Add(this.edtFieldName);
            this.Controls.Add(this.lblFieldName);
            this.Controls.Add(this.edtModulCode);
            this.Controls.Add(this.edtMaskName);
            this.Controls.Add(this.lblMaskName);
            this.Controls.Add(this.lblModulCode);
            this.Controls.Add(this.grdDynaField);
            this.Name = "CtlBookmarkDyna";
            this.Size = new System.Drawing.Size(826, 499);
            this.Load += new System.EventHandler(this.CtlUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDynaField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryDynaField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDynaField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModulCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMaskName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMaskName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFieldName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFieldName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLOVName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTabName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFieldCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFieldCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFieldCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLOVName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTabName.Properties)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void CtlUser_Load(object sender, System.EventArgs e)
		{
			this.colModulCode.ColumnEdit = this.grdDynaField.GetLOVLookUpEdit("Modul") ;
			this.colFieldCode.ColumnEdit = this.grdDynaField.GetLOVLookUpEdit("EigenesFeld") ;

			qryDynaField.Fill(string.Format(@"
				SELECT MSK.ModulID, 
				  DisplayText = {0}, 
				  FLD.FieldName,
                  FLD.FieldCode,
                  FLD.LOVName,
                  FLD.TabName
				FROM DynaMask           MSK
                  INNER JOIN DynaField  FLD ON FLD.MaskName = MSK.MaskName
				WHERE LEN(IsNull(FLD.FieldName, '')) > 1 
				ORDER BY MSK.ModulID, MSK.DisplayText, FLD.FieldName", CtlUserGroup.sqlUserText_DynaMask));
		}

		private void qryTemplate_BeforePost(object sender, System.EventArgs e)
		{
			DBUtil.CheckNotNullField(edtFieldName, lblFieldName.Text);
		}
	}
}

