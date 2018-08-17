namespace KiSS4.Administration.ZH
{
    partial class CtlKgKontoBuchungstext
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKgKontoBuchungstext));
            this.panDetails = new System.Windows.Forms.Panel();
            this.edtKontoNr = new KiSS4.Gui.KissButtonEdit();
            this.edtText = new KiSS4.Gui.KissTextEdit();
            this.edtDefault = new KiSS4.Gui.KissCheckEdit();
            this.lblText = new KiSS4.Gui.KissLabel();
            this.lblKontoNr = new KiSS4.Gui.KissLabel();
            this.panGrid = new System.Windows.Forms.Panel();
            this.grdKontoBuchungstext = new KiSS4.Gui.KissGrid();
            this.qryKgKontoBuchungstext = new KiSS4.DB.SqlQuery();
            this.grvKontobuchugnstext = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKontoNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDefault = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontoNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDefault.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontoNr)).BeginInit();
            this.panGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdKontoBuchungstext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKgKontoBuchungstext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKontobuchugnstext)).BeginInit();
            this.SuspendLayout();
            // 
            // panDetails
            // 
            this.panDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panDetails.Controls.Add(this.edtKontoNr);
            this.panDetails.Controls.Add(this.edtText);
            this.panDetails.Controls.Add(this.edtDefault);
            this.panDetails.Controls.Add(this.lblText);
            this.panDetails.Controls.Add(this.lblKontoNr);
            this.panDetails.Location = new System.Drawing.Point(0, 413);
            this.panDetails.Name = "panDetails";
            this.panDetails.Size = new System.Drawing.Size(772, 111);
            this.panDetails.TabIndex = 0;
            // 
            // edtKontoNr
            // 
            this.edtKontoNr.EditValue = "";
            this.edtKontoNr.Location = new System.Drawing.Point(114, 14);
            this.edtKontoNr.Name = "edtKontoNr";
            this.edtKontoNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontoNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontoNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontoNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontoNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontoNr.Properties.Appearance.Options.UseFont = true;
            this.edtKontoNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtKontoNr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtKontoNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKontoNr.Size = new System.Drawing.Size(213, 24);
            this.edtKontoNr.TabIndex = 1;
            this.edtKontoNr.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKontoNr_UserModifiedFld);
            // 
            // edtText
            // 
            this.edtText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtText.Location = new System.Drawing.Point(114, 44);
            this.edtText.Name = "edtText";
            this.edtText.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtText.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtText.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtText.Properties.Appearance.Options.UseBackColor = true;
            this.edtText.Properties.Appearance.Options.UseBorderColor = true;
            this.edtText.Properties.Appearance.Options.UseFont = true;
            this.edtText.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtText.Size = new System.Drawing.Size(655, 24);
            this.edtText.TabIndex = 3;
            // 
            // edtDefault
            // 
            this.edtDefault.EditValue = false;
            this.edtDefault.Location = new System.Drawing.Point(13, 73);
            this.edtDefault.Name = "edtDefault";
            this.edtDefault.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtDefault.Properties.Appearance.Options.UseBackColor = true;
            this.edtDefault.Properties.Caption = "Standardwert";
            this.edtDefault.Size = new System.Drawing.Size(161, 19);
            this.edtDefault.TabIndex = 4;
            // 
            // lblText
            // 
            this.lblText.Location = new System.Drawing.Point(13, 43);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(82, 24);
            this.lblText.TabIndex = 2;
            this.lblText.Text = "Text:";
            // 
            // lblKontoNr
            // 
            this.lblKontoNr.Location = new System.Drawing.Point(13, 13);
            this.lblKontoNr.Name = "lblKontoNr";
            this.lblKontoNr.Size = new System.Drawing.Size(100, 23);
            this.lblKontoNr.TabIndex = 0;
            this.lblKontoNr.Text = "Konto-Nr:";
            // 
            // panGrid
            // 
            this.panGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panGrid.Controls.Add(this.grdKontoBuchungstext);
            this.panGrid.Location = new System.Drawing.Point(0, 3);
            this.panGrid.Name = "panGrid";
            this.panGrid.Size = new System.Drawing.Size(775, 404);
            this.panGrid.TabIndex = 1;
            // 
            // grdKontoBuchungstext
            // 
            this.grdKontoBuchungstext.DataSource = this.qryKgKontoBuchungstext;
            this.grdKontoBuchungstext.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdKontoBuchungstext.EmbeddedNavigator.Name = "";
            this.grdKontoBuchungstext.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdKontoBuchungstext.Location = new System.Drawing.Point(0, 0);
            this.grdKontoBuchungstext.MainView = this.grvKontobuchugnstext;
            this.grdKontoBuchungstext.Name = "grdKontoBuchungstext";
            this.grdKontoBuchungstext.Size = new System.Drawing.Size(775, 404);
            this.grdKontoBuchungstext.TabIndex = 0;
            this.grdKontoBuchungstext.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKontobuchugnstext});
            // 
            // qryKgKontoBuchungstext
            // 
            this.qryKgKontoBuchungstext.CanDelete = true;
            this.qryKgKontoBuchungstext.CanInsert = true;
            this.qryKgKontoBuchungstext.CanUpdate = true;
            this.qryKgKontoBuchungstext.HostControl = this;
            this.qryKgKontoBuchungstext.SelectStatement = resources.GetString("qryKgKontoBuchungstext.SelectStatement");
            this.qryKgKontoBuchungstext.TableName = "KgKontoBuchungstext";
            this.qryKgKontoBuchungstext.BeforePost += new System.EventHandler(this.qryKgKontoBuchungstext_BeforePost);
            // 
            // grvKontobuchugnstext
            // 
            this.grvKontobuchugnstext.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvKontobuchugnstext.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontobuchugnstext.Appearance.Empty.Options.UseBackColor = true;
            this.grvKontobuchugnstext.Appearance.Empty.Options.UseFont = true;
            this.grvKontobuchugnstext.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontobuchugnstext.Appearance.EvenRow.Options.UseFont = true;
            this.grvKontobuchugnstext.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKontobuchugnstext.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontobuchugnstext.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKontobuchugnstext.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKontobuchugnstext.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKontobuchugnstext.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKontobuchugnstext.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKontobuchugnstext.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontobuchugnstext.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvKontobuchugnstext.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKontobuchugnstext.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKontobuchugnstext.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKontobuchugnstext.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKontobuchugnstext.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKontobuchugnstext.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKontobuchugnstext.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKontobuchugnstext.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKontobuchugnstext.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKontobuchugnstext.Appearance.GroupRow.Options.UseFont = true;
            this.grvKontobuchugnstext.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKontobuchugnstext.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKontobuchugnstext.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKontobuchugnstext.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKontobuchugnstext.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKontobuchugnstext.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKontobuchugnstext.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKontobuchugnstext.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvKontobuchugnstext.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontobuchugnstext.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKontobuchugnstext.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKontobuchugnstext.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKontobuchugnstext.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKontobuchugnstext.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvKontobuchugnstext.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvKontobuchugnstext.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontobuchugnstext.Appearance.OddRow.Options.UseFont = true;
            this.grvKontobuchugnstext.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKontobuchugnstext.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontobuchugnstext.Appearance.Row.Options.UseBackColor = true;
            this.grvKontobuchugnstext.Appearance.Row.Options.UseFont = true;
            this.grvKontobuchugnstext.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontobuchugnstext.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKontobuchugnstext.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvKontobuchugnstext.Appearance.VertLine.Options.UseBackColor = true;
            this.grvKontobuchugnstext.BestFitMaxRowCount = 1000;
            this.grvKontobuchugnstext.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKontobuchugnstext.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKontoNr,
            this.colBuchungstext,
            this.colDefault});
            this.grvKontobuchugnstext.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvKontobuchugnstext.GridControl = this.grdKontoBuchungstext;
            this.grvKontobuchugnstext.Name = "grvKontobuchugnstext";
            this.grvKontobuchugnstext.OptionsBehavior.Editable = false;
            this.grvKontobuchugnstext.OptionsCustomization.AllowFilter = false;
            this.grvKontobuchugnstext.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKontobuchugnstext.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKontobuchugnstext.OptionsNavigation.UseTabKey = false;
            this.grvKontobuchugnstext.OptionsView.ColumnAutoWidth = false;
            this.grvKontobuchugnstext.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvKontobuchugnstext.OptionsView.ShowGroupPanel = false;
            this.grvKontobuchugnstext.OptionsView.ShowIndicator = false;
            // 
            // colKontoNr
            // 
            this.colKontoNr.Caption = "Konto-Nr";
            this.colKontoNr.FieldName = "KontoNr";
            this.colKontoNr.Name = "colKontoNr";
            this.colKontoNr.Visible = true;
            this.colKontoNr.VisibleIndex = 0;
            this.colKontoNr.Width = 90;
            // 
            // colBuchungstext
            // 
            this.colBuchungstext.Caption = "Text";
            this.colBuchungstext.Name = "colBuchungstext";
            this.colBuchungstext.Visible = true;
            this.colBuchungstext.VisibleIndex = 1;
            this.colBuchungstext.Width = 550;
            // 
            // colDefault
            // 
            this.colDefault.Caption = "Standardwert";
            this.colDefault.Name = "colDefault";
            this.colDefault.Visible = true;
            this.colDefault.VisibleIndex = 2;
            this.colDefault.Width = 100;
            // 
            // CtlKgKontoBuchungstext
            // 
            this.ActiveSQLQuery = this.qryKgKontoBuchungstext;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panGrid);
            this.Controls.Add(this.panDetails);
            this.Name = "CtlKgKontoBuchungstext";
            this.Size = new System.Drawing.Size(775, 527);
            this.Load += new System.EventHandler(this.CtlKgKontoBuchungstext_Load);
            this.panDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtKontoNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDefault.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontoNr)).EndInit();
            this.panGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdKontoBuchungstext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKgKontoBuchungstext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKontobuchugnstext)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panDetails;
        private System.Windows.Forms.Panel panGrid;
        private DB.SqlQuery qryKgKontoBuchungstext;
        private Gui.KissLabel lblText;
        private Gui.KissLabel lblKontoNr;
        private Gui.KissCheckEdit edtDefault;
        private Gui.KissTextEdit edtText;
        private Gui.KissGrid grdKontoBuchungstext;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKontobuchugnstext;
        private DevExpress.XtraGrid.Columns.GridColumn colKontoNr;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungstext;
        private DevExpress.XtraGrid.Columns.GridColumn colDefault;
        private Gui.KissButtonEdit edtKontoNr;
    }
}
