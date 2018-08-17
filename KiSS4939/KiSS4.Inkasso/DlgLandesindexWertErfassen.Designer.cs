namespace KiSS4.Inkasso
{
    partial class DlgLandesindexWertErfassen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgLandesindexWertErfassen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdValues = new KiSS4.Gui.KissGrid();
            this.qryLandesindex = new KiSS4.DB.SqlQuery();
            this.grvValues = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIndexName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIndexValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtColWert = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.btnSave = new KiSS4.Gui.KissButton();
            this.btnCancel = new KiSS4.Gui.KissButton();
            this.edtMonatJahr = new KiSS4.Gui.KissDateEdit();
            this.lblMonat = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grdValues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryLandesindex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvValues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtColWert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMonatJahr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMonat)).BeginInit();
            this.SuspendLayout();
            // 
            // grdValues
            // 
            this.grdValues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdValues.DataSource = this.qryLandesindex;
            // 
            // 
            // 
            this.grdValues.EmbeddedNavigator.Name = "";
            this.grdValues.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdValues.Location = new System.Drawing.Point(12, 42);
            this.grdValues.MainView = this.grvValues;
            this.grdValues.Name = "grdValues";
            this.grdValues.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.edtColWert});
            this.grdValues.Size = new System.Drawing.Size(270, 188);
            this.grdValues.TabIndex = 0;
            this.grdValues.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvValues});
            // 
            // qryLandesindex
            // 
            this.qryLandesindex.CanUpdate = true;
            this.qryLandesindex.HostControl = this;
            this.qryLandesindex.SelectStatement = "SELECT IkLandesindexID = LIN.IkLandesindexID,\r\n       Name            = LIN.Name," +
    "\r\n       Value           = CONVERT(MONEY, NULL)\r\nFROM dbo.IkLandesindex LIN WITH" +
    "(READUNCOMMITTED);";
            this.qryLandesindex.BeforePost += new System.EventHandler(this.qryLandesindex_BeforePost);
            // 
            // grvValues
            // 
            this.grvValues.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvValues.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvValues.Appearance.Empty.Options.UseBackColor = true;
            this.grvValues.Appearance.Empty.Options.UseFont = true;
            this.grvValues.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvValues.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvValues.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvValues.Appearance.EvenRow.Options.UseFont = true;
            this.grvValues.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.grvValues.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvValues.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvValues.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvValues.Appearance.FocusedCell.Options.UseFont = true;
            this.grvValues.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvValues.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvValues.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvValues.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.grvValues.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvValues.Appearance.FocusedRow.Options.UseFont = true;
            this.grvValues.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvValues.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvValues.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvValues.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvValues.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvValues.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvValues.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvValues.Appearance.GroupRow.Options.UseFont = true;
            this.grvValues.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvValues.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvValues.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvValues.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvValues.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvValues.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvValues.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvValues.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvValues.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvValues.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvValues.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvValues.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvValues.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvValues.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.grvValues.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvValues.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvValues.Appearance.OddRow.Options.UseFont = true;
            this.grvValues.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.grvValues.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvValues.Appearance.Row.Options.UseBackColor = true;
            this.grvValues.Appearance.Row.Options.UseFont = true;
            this.grvValues.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvValues.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvValues.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvValues.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvValues.Appearance.SelectedRow.Options.UseFont = true;
            this.grvValues.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvValues.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.grvValues.Appearance.VertLine.Options.UseBackColor = true;
            this.grvValues.BestFitMaxRowCount = 1000;
            this.grvValues.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvValues.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIndexName,
            this.colIndexValue});
            this.grvValues.GridControl = this.grdValues;
            this.grvValues.Name = "grvValues";
            this.grvValues.OptionsCustomization.AllowFilter = false;
            this.grvValues.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvValues.OptionsNavigation.AutoFocusNewRow = true;
            this.grvValues.OptionsView.ColumnAutoWidth = false;
            this.grvValues.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvValues.OptionsView.ShowGroupPanel = false;
            // 
            // colIndexName
            // 
            this.colIndexName.Caption = "Index-Name";
            this.colIndexName.FieldName = "Name";
            this.colIndexName.Name = "colIndexName";
            this.colIndexName.OptionsColumn.AllowEdit = false;
            this.colIndexName.OptionsColumn.AllowFocus = false;
            this.colIndexName.OptionsColumn.ReadOnly = true;
            this.colIndexName.Visible = true;
            this.colIndexName.VisibleIndex = 0;
            this.colIndexName.Width = 100;
            // 
            // colIndexValue
            // 
            this.colIndexValue.Caption = "Wert";
            this.colIndexValue.ColumnEdit = this.edtColWert;
            this.colIndexValue.DisplayFormat.FormatString = "f";
            this.colIndexValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colIndexValue.FieldName = "Value";
            this.colIndexValue.Name = "colIndexValue";
            this.colIndexValue.Visible = true;
            this.colIndexValue.VisibleIndex = 1;
            // 
            // edtColWert
            // 
            this.edtColWert.AutoHeight = false;
            this.edtColWert.Mask.EditMask = "f";
            this.edtColWert.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.edtColWert.Mask.UseMaskAsDisplayFormat = true;
            this.edtColWert.Name = "edtColWert";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(192, 236);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 24);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Speichern";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(96, 236);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 24);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // edtMonatJahr
            // 
            this.edtMonatJahr.EditValue = new System.DateTime(2011, 6, 15, 17, 1, 11, 64);
            this.edtMonatJahr.Location = new System.Drawing.Point(118, 12);
            this.edtMonatJahr.Name = "edtMonatJahr";
            this.edtMonatJahr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtMonatJahr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMonatJahr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMonatJahr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMonatJahr.Properties.Appearance.Options.UseBackColor = true;
            this.edtMonatJahr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMonatJahr.Properties.Appearance.Options.UseFont = true;
            this.edtMonatJahr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtMonatJahr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtMonatJahr.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtMonatJahr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtMonatJahr.Properties.DisplayFormat.FormatString = "MM.yyyy";
            this.edtMonatJahr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtMonatJahr.Properties.EditFormat.FormatString = "MM.yyyy";
            this.edtMonatJahr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtMonatJahr.Properties.Mask.EditMask = "MM.yyyy";
            this.edtMonatJahr.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.edtMonatJahr.Properties.ShowToday = false;
            this.edtMonatJahr.Size = new System.Drawing.Size(90, 24);
            this.edtMonatJahr.TabIndex = 3;
            // 
            // lblMonat
            // 
            this.lblMonat.Location = new System.Drawing.Point(12, 12);
            this.lblMonat.Name = "lblMonat";
            this.lblMonat.Size = new System.Drawing.Size(100, 23);
            this.lblMonat.TabIndex = 4;
            this.lblMonat.Text = "Monat/Jahr";
            // 
            // DlgLandesindexWertErfassen
            // 
            this.AcceptButton = this.btnSave;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(294, 272);
            this.Controls.Add(this.lblMonat);
            this.Controls.Add(this.edtMonatJahr);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grdValues);
            this.Name = "DlgLandesindexWertErfassen";
            this.Text = "Indexwerte erfassen";
            this.Load += new System.EventHandler(this.DlgLandesindexWertErfassen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdValues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryLandesindex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvValues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtColWert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMonatJahr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMonat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gui.KissGrid grdValues;
        private Gui.KissButton btnSave;
        private Gui.KissButton btnCancel;
        private Gui.KissDateEdit edtMonatJahr;
        private Gui.KissLabel lblMonat;
        private DevExpress.XtraGrid.Views.Grid.GridView grvValues;
        private DevExpress.XtraGrid.Columns.GridColumn colIndexName;
        private DevExpress.XtraGrid.Columns.GridColumn colIndexValue;
        private DB.SqlQuery qryLandesindex;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit edtColWert;
    }
}
