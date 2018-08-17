namespace KiSS4.Administration
{
    partial class CtlAdTranslateColumn
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlAdTranslateColumn));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdXTranslateColumn = new KiSS4.Gui.KissGrid();
            this.qryXTranslateColumn = new KiSS4.DB.SqlQuery(this.components);
            this.grvXTranslateColumn = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colXTranslateColumnTableName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colXTranslateColumnColumnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colXTranslateColumnTIDColumnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colXTranslateColumnDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grpTranslateColumn = new KiSS4.Gui.KissGroupBox();
            this.panTranslateColumnDetails = new System.Windows.Forms.Panel();
            this.edtDescription = new KiSS4.Gui.KissMemoEdit();
            this.edtTIDColumnName = new KiSS4.Gui.KissLookUpEdit();
            this.edtColumnName = new KiSS4.Gui.KissLookUpEdit();
            this.edtTableName = new KiSS4.Gui.KissLookUpEdit();
            this.lblDescription = new KiSS4.Gui.KissLabel();
            this.lblTIDColumnName = new KiSS4.Gui.KissLabel();
            this.lblTableName = new KiSS4.Gui.KissLabel();
            this.lblColumnName = new KiSS4.Gui.KissLabel();
            this.grpTranslation = new KiSS4.Gui.KissGroupBox();
            this.grdTranslation = new KiSS4.Gui.KissGrid();
            this.qryTranslation = new KiSS4.DB.SqlQuery(this.components);
            this.grvTranslation = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panTranslationDetails = new System.Windows.Forms.Panel();
            this.edtTranslation = new KiSS4.Gui.KissTextEditML();
            this.lblTranslation = new KiSS4.Gui.KissLabel();
            this.splitter = new KiSS4.Gui.KissSplitterCollapsible();
            this.panTranslation = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grdXTranslateColumn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXTranslateColumn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvXTranslateColumn)).BeginInit();
            this.grpTranslateColumn.SuspendLayout();
            this.panTranslateColumnDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTIDColumnName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTIDColumnName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtColumnName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtColumnName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTableName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTableName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTIDColumnName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTableName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblColumnName)).BeginInit();
            this.grpTranslation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTranslation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryTranslation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTranslation)).BeginInit();
            this.panTranslationDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtTranslation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTranslation)).BeginInit();
            this.panTranslation.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdXTranslateColumn
            // 
            this.grdXTranslateColumn.DataSource = this.qryXTranslateColumn;
            this.grdXTranslateColumn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdXTranslateColumn.EmbeddedNavigator.Name = "";
            this.grdXTranslateColumn.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdXTranslateColumn.Location = new System.Drawing.Point(3, 17);
            this.grdXTranslateColumn.MainView = this.grvXTranslateColumn;
            this.grdXTranslateColumn.Name = "grdXTranslateColumn";
            this.grdXTranslateColumn.Size = new System.Drawing.Size(794, 225);
            this.grdXTranslateColumn.TabIndex = 0;
            this.grdXTranslateColumn.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvXTranslateColumn});
            // 
            // qryXTranslateColumn
            // 
            this.qryXTranslateColumn.HostControl = this;
            this.qryXTranslateColumn.TableName = "XTranslateColumn";
            this.qryXTranslateColumn.BeforePost += new System.EventHandler(this.qryXTranslateColumn_BeforePost);
            this.qryXTranslateColumn.PositionChanged += new System.EventHandler(this.qryXTranslateColumn_PositionChanged);
            this.qryXTranslateColumn.AfterInsert += new System.EventHandler(this.qryXTranslateColumn_AfterInsert);
            this.qryXTranslateColumn.AfterPost += new System.EventHandler(this.qryXTranslateColumn_AfterPost);
            this.qryXTranslateColumn.PositionChanging += new System.EventHandler(this.qryXTranslateColumn_PositionChanging);
            // 
            // grvXTranslateColumn
            // 
            this.grvXTranslateColumn.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvXTranslateColumn.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXTranslateColumn.Appearance.Empty.Options.UseBackColor = true;
            this.grvXTranslateColumn.Appearance.Empty.Options.UseFont = true;
            this.grvXTranslateColumn.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXTranslateColumn.Appearance.EvenRow.Options.UseFont = true;
            this.grvXTranslateColumn.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvXTranslateColumn.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXTranslateColumn.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvXTranslateColumn.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvXTranslateColumn.Appearance.FocusedCell.Options.UseFont = true;
            this.grvXTranslateColumn.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvXTranslateColumn.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvXTranslateColumn.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXTranslateColumn.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvXTranslateColumn.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvXTranslateColumn.Appearance.FocusedRow.Options.UseFont = true;
            this.grvXTranslateColumn.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvXTranslateColumn.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvXTranslateColumn.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvXTranslateColumn.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvXTranslateColumn.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvXTranslateColumn.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvXTranslateColumn.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvXTranslateColumn.Appearance.GroupRow.Options.UseFont = true;
            this.grvXTranslateColumn.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvXTranslateColumn.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvXTranslateColumn.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvXTranslateColumn.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvXTranslateColumn.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvXTranslateColumn.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvXTranslateColumn.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvXTranslateColumn.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvXTranslateColumn.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXTranslateColumn.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvXTranslateColumn.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvXTranslateColumn.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvXTranslateColumn.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvXTranslateColumn.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvXTranslateColumn.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvXTranslateColumn.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXTranslateColumn.Appearance.OddRow.Options.UseFont = true;
            this.grvXTranslateColumn.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvXTranslateColumn.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXTranslateColumn.Appearance.Row.Options.UseBackColor = true;
            this.grvXTranslateColumn.Appearance.Row.Options.UseFont = true;
            this.grvXTranslateColumn.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXTranslateColumn.Appearance.SelectedRow.Options.UseFont = true;
            this.grvXTranslateColumn.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvXTranslateColumn.Appearance.VertLine.Options.UseBackColor = true;
            this.grvXTranslateColumn.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvXTranslateColumn.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colXTranslateColumnTableName,
            this.colXTranslateColumnColumnName,
            this.colXTranslateColumnTIDColumnName,
            this.colXTranslateColumnDescription});
            this.grvXTranslateColumn.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvXTranslateColumn.GridControl = this.grdXTranslateColumn;
            this.grvXTranslateColumn.Name = "grvXTranslateColumn";
            this.grvXTranslateColumn.OptionsBehavior.Editable = false;
            this.grvXTranslateColumn.OptionsCustomization.AllowFilter = false;
            this.grvXTranslateColumn.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvXTranslateColumn.OptionsNavigation.AutoFocusNewRow = true;
            this.grvXTranslateColumn.OptionsNavigation.UseTabKey = false;
            this.grvXTranslateColumn.OptionsView.ColumnAutoWidth = false;
            this.grvXTranslateColumn.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvXTranslateColumn.OptionsView.ShowGroupPanel = false;
            this.grvXTranslateColumn.OptionsView.ShowIndicator = false;
            // 
            // colXTranslateColumnTableName
            // 
            this.colXTranslateColumnTableName.Caption = "Tabelle";
            this.colXTranslateColumnTableName.FieldName = "TableName";
            this.colXTranslateColumnTableName.Name = "colXTranslateColumnTableName";
            this.colXTranslateColumnTableName.Visible = true;
            this.colXTranslateColumnTableName.VisibleIndex = 0;
            this.colXTranslateColumnTableName.Width = 200;
            // 
            // colXTranslateColumnColumnName
            // 
            this.colXTranslateColumnColumnName.Caption = "Standard-Text Spalte";
            this.colXTranslateColumnColumnName.FieldName = "ColumnName";
            this.colXTranslateColumnColumnName.Name = "colXTranslateColumnColumnName";
            this.colXTranslateColumnColumnName.Visible = true;
            this.colXTranslateColumnColumnName.VisibleIndex = 1;
            this.colXTranslateColumnColumnName.Width = 200;
            // 
            // colXTranslateColumnTIDColumnName
            // 
            this.colXTranslateColumnTIDColumnName.Caption = "TID Spalte";
            this.colXTranslateColumnTIDColumnName.FieldName = "TIDColumnName";
            this.colXTranslateColumnTIDColumnName.Name = "colXTranslateColumnTIDColumnName";
            this.colXTranslateColumnTIDColumnName.Visible = true;
            this.colXTranslateColumnTIDColumnName.VisibleIndex = 2;
            this.colXTranslateColumnTIDColumnName.Width = 200;
            // 
            // colXTranslateColumnDescription
            // 
            this.colXTranslateColumnDescription.Caption = "Beschreibung";
            this.colXTranslateColumnDescription.FieldName = "Description";
            this.colXTranslateColumnDescription.Name = "colXTranslateColumnDescription";
            this.colXTranslateColumnDescription.Visible = true;
            this.colXTranslateColumnDescription.VisibleIndex = 3;
            this.colXTranslateColumnDescription.Width = 300;
            // 
            // grpTranslateColumn
            // 
            this.grpTranslateColumn.Controls.Add(this.grdXTranslateColumn);
            this.grpTranslateColumn.Controls.Add(this.panTranslateColumnDetails);
            this.grpTranslateColumn.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTranslateColumn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTranslateColumn.Location = new System.Drawing.Point(0, 6);
            this.grpTranslateColumn.Name = "grpTranslateColumn";
            this.grpTranslateColumn.Size = new System.Drawing.Size(800, 350);
            this.grpTranslateColumn.TabIndex = 0;
            this.grpTranslateColumn.TabStop = false;
            this.grpTranslateColumn.Text = "Zu übersetzende Tabellen und Spalten";
            // 
            // panTranslateColumnDetails
            // 
            this.panTranslateColumnDetails.Controls.Add(this.edtDescription);
            this.panTranslateColumnDetails.Controls.Add(this.edtTIDColumnName);
            this.panTranslateColumnDetails.Controls.Add(this.edtColumnName);
            this.panTranslateColumnDetails.Controls.Add(this.edtTableName);
            this.panTranslateColumnDetails.Controls.Add(this.lblDescription);
            this.panTranslateColumnDetails.Controls.Add(this.lblTIDColumnName);
            this.panTranslateColumnDetails.Controls.Add(this.lblTableName);
            this.panTranslateColumnDetails.Controls.Add(this.lblColumnName);
            this.panTranslateColumnDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panTranslateColumnDetails.Location = new System.Drawing.Point(3, 242);
            this.panTranslateColumnDetails.Name = "panTranslateColumnDetails";
            this.panTranslateColumnDetails.Size = new System.Drawing.Size(794, 105);
            this.panTranslateColumnDetails.TabIndex = 1;
            // 
            // edtDescription
            // 
            this.edtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDescription.DataMember = "Description";
            this.edtDescription.DataSource = this.qryXTranslateColumn;
            this.edtDescription.Location = new System.Drawing.Point(419, 39);
            this.edtDescription.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.edtDescription.Name = "edtDescription";
            this.edtDescription.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDescription.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDescription.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDescription.Properties.Appearance.Options.UseBackColor = true;
            this.edtDescription.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDescription.Properties.Appearance.Options.UseFont = true;
            this.edtDescription.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDescription.Size = new System.Drawing.Size(366, 54);
            this.edtDescription.TabIndex = 7;
            // 
            // edtTIDColumnName
            // 
            this.edtTIDColumnName.DataMember = "TIDColumnName";
            this.edtTIDColumnName.DataSource = this.qryXTranslateColumn;
            this.edtTIDColumnName.Location = new System.Drawing.Point(147, 69);
            this.edtTIDColumnName.Name = "edtTIDColumnName";
            this.edtTIDColumnName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTIDColumnName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTIDColumnName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTIDColumnName.Properties.Appearance.Options.UseBackColor = true;
            this.edtTIDColumnName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTIDColumnName.Properties.Appearance.Options.UseFont = true;
            this.edtTIDColumnName.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtTIDColumnName.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtTIDColumnName.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtTIDColumnName.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtTIDColumnName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtTIDColumnName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtTIDColumnName.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTIDColumnName.Properties.NullText = "";
            this.edtTIDColumnName.Properties.ShowFooter = false;
            this.edtTIDColumnName.Properties.ShowHeader = false;
            this.edtTIDColumnName.Size = new System.Drawing.Size(243, 24);
            this.edtTIDColumnName.TabIndex = 5;
            // 
            // edtColumnName
            // 
            this.edtColumnName.DataMember = "ColumnName";
            this.edtColumnName.DataSource = this.qryXTranslateColumn;
            this.edtColumnName.Location = new System.Drawing.Point(147, 39);
            this.edtColumnName.Name = "edtColumnName";
            this.edtColumnName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtColumnName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtColumnName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtColumnName.Properties.Appearance.Options.UseBackColor = true;
            this.edtColumnName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtColumnName.Properties.Appearance.Options.UseFont = true;
            this.edtColumnName.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtColumnName.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtColumnName.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtColumnName.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtColumnName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtColumnName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtColumnName.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtColumnName.Properties.NullText = "";
            this.edtColumnName.Properties.ShowFooter = false;
            this.edtColumnName.Properties.ShowHeader = false;
            this.edtColumnName.Size = new System.Drawing.Size(243, 24);
            this.edtColumnName.TabIndex = 3;
            // 
            // edtTableName
            // 
            this.edtTableName.DataMember = "TableName";
            this.edtTableName.DataSource = this.qryXTranslateColumn;
            this.edtTableName.Location = new System.Drawing.Point(147, 9);
            this.edtTableName.Name = "edtTableName";
            this.edtTableName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTableName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTableName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTableName.Properties.Appearance.Options.UseBackColor = true;
            this.edtTableName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTableName.Properties.Appearance.Options.UseFont = true;
            this.edtTableName.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtTableName.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtTableName.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtTableName.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtTableName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtTableName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtTableName.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTableName.Properties.NullText = "";
            this.edtTableName.Properties.ShowFooter = false;
            this.edtTableName.Properties.ShowHeader = false;
            this.edtTableName.Size = new System.Drawing.Size(243, 24);
            this.edtTableName.TabIndex = 1;
            this.edtTableName.EditValueChanged += new System.EventHandler(this.edtTableName_EditValueChanged);
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(416, 10);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(113, 24);
            this.lblDescription.TabIndex = 6;
            this.lblDescription.Text = "Beschreibung";
            // 
            // lblTIDColumnName
            // 
            this.lblTIDColumnName.Location = new System.Drawing.Point(9, 69);
            this.lblTIDColumnName.Name = "lblTIDColumnName";
            this.lblTIDColumnName.Size = new System.Drawing.Size(132, 24);
            this.lblTIDColumnName.TabIndex = 4;
            this.lblTIDColumnName.Text = "TID Spalte";
            // 
            // lblTableName
            // 
            this.lblTableName.Location = new System.Drawing.Point(9, 9);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(132, 24);
            this.lblTableName.TabIndex = 0;
            this.lblTableName.Text = "Tabelle";
            // 
            // lblColumnName
            // 
            this.lblColumnName.Location = new System.Drawing.Point(9, 39);
            this.lblColumnName.Name = "lblColumnName";
            this.lblColumnName.Size = new System.Drawing.Size(132, 24);
            this.lblColumnName.TabIndex = 2;
            this.lblColumnName.Text = "Standard-Text Spalte";
            // 
            // grpTranslation
            // 
            this.grpTranslation.Controls.Add(this.grdTranslation);
            this.grpTranslation.Controls.Add(this.panTranslationDetails);
            this.grpTranslation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTranslation.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTranslation.Location = new System.Drawing.Point(0, 6);
            this.grpTranslation.Name = "grpTranslation";
            this.grpTranslation.Size = new System.Drawing.Size(800, 180);
            this.grpTranslation.TabIndex = 0;
            this.grpTranslation.TabStop = false;
            this.grpTranslation.Text = "Zugehörige Übersetzungen";
            // 
            // grdTranslation
            // 
            this.grdTranslation.DataSource = this.qryTranslation;
            this.grdTranslation.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdTranslation.EmbeddedNavigator.Name = "";
            this.grdTranslation.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdTranslation.Location = new System.Drawing.Point(3, 17);
            this.grdTranslation.MainView = this.grvTranslation;
            this.grdTranslation.Name = "grdTranslation";
            this.grdTranslation.Size = new System.Drawing.Size(794, 124);
            this.grdTranslation.TabIndex = 0;
            this.grdTranslation.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTranslation});
            // 
            // qryTranslation
            // 
            this.qryTranslation.HostControl = this;
            this.qryTranslation.PositionChanging += new System.EventHandler(this.qryTranslation_PositionChanging);
            // 
            // grvTranslation
            // 
            this.grvTranslation.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvTranslation.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTranslation.Appearance.Empty.Options.UseBackColor = true;
            this.grvTranslation.Appearance.Empty.Options.UseFont = true;
            this.grvTranslation.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTranslation.Appearance.EvenRow.Options.UseFont = true;
            this.grvTranslation.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvTranslation.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTranslation.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvTranslation.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvTranslation.Appearance.FocusedCell.Options.UseFont = true;
            this.grvTranslation.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvTranslation.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvTranslation.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTranslation.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvTranslation.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvTranslation.Appearance.FocusedRow.Options.UseFont = true;
            this.grvTranslation.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvTranslation.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvTranslation.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvTranslation.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvTranslation.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvTranslation.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvTranslation.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvTranslation.Appearance.GroupRow.Options.UseFont = true;
            this.grvTranslation.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvTranslation.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvTranslation.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvTranslation.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvTranslation.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvTranslation.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvTranslation.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvTranslation.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvTranslation.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTranslation.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvTranslation.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvTranslation.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvTranslation.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvTranslation.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvTranslation.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvTranslation.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTranslation.Appearance.OddRow.Options.UseFont = true;
            this.grvTranslation.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvTranslation.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTranslation.Appearance.Row.Options.UseBackColor = true;
            this.grvTranslation.Appearance.Row.Options.UseFont = true;
            this.grvTranslation.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTranslation.Appearance.SelectedRow.Options.UseFont = true;
            this.grvTranslation.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvTranslation.Appearance.VertLine.Options.UseBackColor = true;
            this.grvTranslation.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvTranslation.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvTranslation.GridControl = this.grdTranslation;
            this.grvTranslation.Name = "grvTranslation";
            this.grvTranslation.OptionsBehavior.Editable = false;
            this.grvTranslation.OptionsCustomization.AllowFilter = false;
            this.grvTranslation.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvTranslation.OptionsNavigation.AutoFocusNewRow = true;
            this.grvTranslation.OptionsNavigation.UseTabKey = false;
            this.grvTranslation.OptionsView.ColumnAutoWidth = false;
            this.grvTranslation.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvTranslation.OptionsView.ShowGroupPanel = false;
            this.grvTranslation.OptionsView.ShowIndicator = false;
            // 
            // panTranslationDetails
            // 
            this.panTranslationDetails.Controls.Add(this.edtTranslation);
            this.panTranslationDetails.Controls.Add(this.lblTranslation);
            this.panTranslationDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panTranslationDetails.Location = new System.Drawing.Point(3, 141);
            this.panTranslationDetails.Name = "panTranslationDetails";
            this.panTranslationDetails.Size = new System.Drawing.Size(794, 36);
            this.panTranslationDetails.TabIndex = 1;
            // 
            // edtTranslation
            // 
            this.edtTranslation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtTranslation.ApplyChangesToDefaultText = false;
            this.edtTranslation.DataMember = null;
            this.edtTranslation.DataMemberDefaultText = "";
            this.edtTranslation.DataMemberTID = "";
            this.edtTranslation.DataSource = this.qryTranslation;
            this.edtTranslation.Location = new System.Drawing.Point(147, 6);
            this.edtTranslation.Name = "edtTranslation";
            this.edtTranslation.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTranslation.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTranslation.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTranslation.Properties.Appearance.Options.UseBackColor = true;
            this.edtTranslation.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTranslation.Properties.Appearance.Options.UseFont = true;
            this.edtTranslation.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtTranslation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtTranslation.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtTranslation.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTranslation.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.edtTranslation.ShowOnlyDefaultLanguage = true;
            this.edtTranslation.Size = new System.Drawing.Size(638, 24);
            this.edtTranslation.TabIndex = 1;
            this.edtTranslation.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtTranslation_UserModifiedFld);
            // 
            // lblTranslation
            // 
            this.lblTranslation.Location = new System.Drawing.Point(12, 6);
            this.lblTranslation.Name = "lblTranslation";
            this.lblTranslation.Size = new System.Drawing.Size(129, 24);
            this.lblTranslation.TabIndex = 0;
            this.lblTranslation.Text = "Übersetzung";
            this.lblTranslation.UseCompatibleTextRendering = true;
            // 
            // splitter
            // 
            this.splitter.AnimationDelay = 20;
            this.splitter.AnimationStep = 20;
            this.splitter.BorderStyle3D = System.Windows.Forms.Border3DStyle.Etched;
            this.splitter.ControlToHide = this.grpTranslateColumn;
            this.splitter.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter.ExpandParentForm = false;
            this.splitter.Location = new System.Drawing.Point(0, 356);
            this.splitter.MinExtra = 150;
            this.splitter.MinSize = 100;
            this.splitter.Name = "splitter";
            this.splitter.TabIndex = 1;
            this.splitter.TabStop = false;
            this.splitter.UseAnimations = false;
            this.splitter.VisualStyle = KiSS4.Gui.VisualStyles.Mozilla;
            // 
            // panTranslation
            // 
            this.panTranslation.Controls.Add(this.grpTranslation);
            this.panTranslation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panTranslation.Location = new System.Drawing.Point(0, 364);
            this.panTranslation.Name = "panTranslation";
            this.panTranslation.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.panTranslation.Size = new System.Drawing.Size(800, 186);
            this.panTranslation.TabIndex = 2;
            // 
            // CtlAdTranslateColumn
            // 
            this.ActiveSQLQuery = this.qryXTranslateColumn;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.panTranslation);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.grpTranslateColumn);
            this.Name = "CtlAdTranslateColumn";
            this.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.Size = new System.Drawing.Size(800, 550);
            this.Load += new System.EventHandler(this.CtlAdTranslateColumn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdXTranslateColumn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXTranslateColumn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvXTranslateColumn)).EndInit();
            this.grpTranslateColumn.ResumeLayout(false);
            this.panTranslateColumnDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTIDColumnName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTIDColumnName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtColumnName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtColumnName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTableName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTableName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTIDColumnName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTableName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblColumnName)).EndInit();
            this.grpTranslation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTranslation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryTranslation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTranslation)).EndInit();
            this.panTranslationDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtTranslation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTranslation)).EndInit();
            this.panTranslation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissGrid grdXTranslateColumn;
        private KiSS4.DB.SqlQuery qryXTranslateColumn;
        private KiSS4.Gui.KissGroupBox grpTranslateColumn;
        private System.Windows.Forms.Panel panTranslateColumnDetails;
        private KiSS4.Gui.KissGroupBox grpTranslation;
        private KiSS4.Gui.KissGrid grdTranslation;
        private System.Windows.Forms.Panel panTranslationDetails;
        private KiSS4.Gui.KissSplitterCollapsible splitter;
        private KiSS4.DB.SqlQuery qryTranslation;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTranslation;
        private DevExpress.XtraGrid.Views.Grid.GridView grvXTranslateColumn;
        private KiSS4.Gui.KissLabel lblTableName;
        private KiSS4.Gui.KissLabel lblColumnName;
        private KiSS4.Gui.KissLabel lblDescription;
        private KiSS4.Gui.KissLabel lblTIDColumnName;
        private KiSS4.Gui.KissLookUpEdit edtTIDColumnName;
        private KiSS4.Gui.KissLookUpEdit edtColumnName;
        private KiSS4.Gui.KissLookUpEdit edtTableName;
        private KiSS4.Gui.KissMemoEdit edtDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colXTranslateColumnTableName;
        private DevExpress.XtraGrid.Columns.GridColumn colXTranslateColumnColumnName;
        private DevExpress.XtraGrid.Columns.GridColumn colXTranslateColumnTIDColumnName;
        private DevExpress.XtraGrid.Columns.GridColumn colXTranslateColumnDescription;
        private System.Windows.Forms.Panel panTranslation;
        private KiSS4.Gui.KissTextEditML edtTranslation;
        private KiSS4.Gui.KissLabel lblTranslation;
    }
}
