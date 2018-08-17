namespace KiSS4.Administration
{
    partial class CtlStdZahlungsmodi
    {
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
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
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdZahlungsmodus = new KiSS4.Gui.KissGrid();
            this.qryZahlungsmodus = new KiSS4.DB.SqlQuery(this.components);
            this.grvZahlungsmodus = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colZahlungsmodus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZahlungsartCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblZahlungsartCode = new KiSS4.Gui.KissLabel();
            this.edtZahlungsartCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtZahlungsmodus = new KiSS4.Gui.KissTextEdit();
            this.lblZahlungsmodus = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grdZahlungsmodus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZahlungsmodus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZahlungsmodus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungsartCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungsartCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungsartCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungsmodus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungsmodus)).BeginInit();
            this.SuspendLayout();
            // 
            // grdZahlungsmodus
            // 
            this.grdZahlungsmodus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdZahlungsmodus.DataSource = this.qryZahlungsmodus;
            this.grdZahlungsmodus.EmbeddedNavigator.Name = "";
            this.grdZahlungsmodus.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdZahlungsmodus.Location = new System.Drawing.Point(6, 12);
            this.grdZahlungsmodus.MainView = this.grvZahlungsmodus;
            this.grdZahlungsmodus.Name = "grdZahlungsmodus";
            this.grdZahlungsmodus.Size = new System.Drawing.Size(735, 225);
            this.grdZahlungsmodus.TabIndex = 0;
            this.grdZahlungsmodus.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvZahlungsmodus});
            // 
            // qryZahlungsmodus
            // 
            this.qryZahlungsmodus.CanDelete = true;
            this.qryZahlungsmodus.CanInsert = true;
            this.qryZahlungsmodus.CanUpdate = true;
            this.qryZahlungsmodus.HostControl = this;
            this.qryZahlungsmodus.TableName = "XConfig";
            this.qryZahlungsmodus.BeforePost += new System.EventHandler(this.qryZahlungsmodus_BeforePost);
            this.qryZahlungsmodus.AfterFill += new System.EventHandler(this.qryZahlungsmodus_AfterFill);
            this.qryZahlungsmodus.AfterInsert += new System.EventHandler(this.qryZahlungsmodus_AfterInsert);
            // 
            // grvZahlungsmodus
            // 
            this.grvZahlungsmodus.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvZahlungsmodus.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungsmodus.Appearance.Empty.Options.UseBackColor = true;
            this.grvZahlungsmodus.Appearance.Empty.Options.UseFont = true;
            this.grvZahlungsmodus.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungsmodus.Appearance.EvenRow.Options.UseFont = true;
            this.grvZahlungsmodus.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvZahlungsmodus.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungsmodus.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvZahlungsmodus.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvZahlungsmodus.Appearance.FocusedCell.Options.UseFont = true;
            this.grvZahlungsmodus.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvZahlungsmodus.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvZahlungsmodus.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungsmodus.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvZahlungsmodus.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvZahlungsmodus.Appearance.FocusedRow.Options.UseFont = true;
            this.grvZahlungsmodus.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvZahlungsmodus.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZahlungsmodus.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvZahlungsmodus.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZahlungsmodus.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvZahlungsmodus.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZahlungsmodus.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvZahlungsmodus.Appearance.GroupRow.Options.UseFont = true;
            this.grvZahlungsmodus.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvZahlungsmodus.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvZahlungsmodus.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvZahlungsmodus.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvZahlungsmodus.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvZahlungsmodus.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvZahlungsmodus.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvZahlungsmodus.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvZahlungsmodus.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungsmodus.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZahlungsmodus.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvZahlungsmodus.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvZahlungsmodus.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvZahlungsmodus.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvZahlungsmodus.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvZahlungsmodus.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungsmodus.Appearance.OddRow.Options.UseFont = true;
            this.grvZahlungsmodus.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvZahlungsmodus.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungsmodus.Appearance.Row.Options.UseBackColor = true;
            this.grvZahlungsmodus.Appearance.Row.Options.UseFont = true;
            this.grvZahlungsmodus.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungsmodus.Appearance.SelectedRow.Options.UseFont = true;
            this.grvZahlungsmodus.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvZahlungsmodus.Appearance.VertLine.Options.UseBackColor = true;
            this.grvZahlungsmodus.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvZahlungsmodus.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colZahlungsmodus,
            this.colZahlungsartCode});
            this.grvZahlungsmodus.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvZahlungsmodus.GridControl = this.grdZahlungsmodus;
            this.grvZahlungsmodus.Name = "grvZahlungsmodus";
            this.grvZahlungsmodus.OptionsBehavior.Editable = false;
            this.grvZahlungsmodus.OptionsCustomization.AllowFilter = false;
            this.grvZahlungsmodus.OptionsFilter.AllowFilterEditor = false;
            this.grvZahlungsmodus.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvZahlungsmodus.OptionsNavigation.AutoFocusNewRow = true;
            this.grvZahlungsmodus.OptionsNavigation.UseTabKey = false;
            this.grvZahlungsmodus.OptionsView.ColumnAutoWidth = false;
            this.grvZahlungsmodus.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvZahlungsmodus.OptionsView.ShowGroupPanel = false;
            this.grvZahlungsmodus.OptionsView.ShowIndicator = false;
            // 
            // colZahlungsmodus
            // 
            this.colZahlungsmodus.Caption = "Zahlungsmodus";
            this.colZahlungsmodus.FieldName = "Zahlungsmodus";
            this.colZahlungsmodus.Name = "colZahlungsmodus";
            this.colZahlungsmodus.Visible = true;
            this.colZahlungsmodus.VisibleIndex = 0;
            this.colZahlungsmodus.Width = 394;
            // 
            // colZahlungsartCode
            // 
            this.colZahlungsartCode.AppearanceCell.Options.UseTextOptions = true;
            this.colZahlungsartCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colZahlungsartCode.Caption = "Zahlungsart";
            this.colZahlungsartCode.FieldName = "ZahlungsartCode";
            this.colZahlungsartCode.Name = "colZahlungsartCode";
            this.colZahlungsartCode.Visible = true;
            this.colZahlungsartCode.VisibleIndex = 1;
            this.colZahlungsartCode.Width = 313;
            // 
            // lblZahlungsartCode
            // 
            this.lblZahlungsartCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblZahlungsartCode.Location = new System.Drawing.Point(5, 285);
            this.lblZahlungsartCode.Name = "lblZahlungsartCode";
            this.lblZahlungsartCode.Size = new System.Drawing.Size(86, 24);
            this.lblZahlungsartCode.TabIndex = 11;
            this.lblZahlungsartCode.Text = "Zahlungsart";
            // 
            // edtZahlungsartCode
            // 
            this.edtZahlungsartCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtZahlungsartCode.DataMember = "ZahlungsartCode";
            this.edtZahlungsartCode.DataSource = this.qryZahlungsmodus;
            this.edtZahlungsartCode.Location = new System.Drawing.Point(101, 285);
            this.edtZahlungsartCode.LOVName = "KbAuszahlungsArt";
            this.edtZahlungsartCode.Name = "edtZahlungsartCode";
            this.edtZahlungsartCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZahlungsartCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZahlungsartCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZahlungsartCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtZahlungsartCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZahlungsartCode.Properties.Appearance.Options.UseFont = true;
            this.edtZahlungsartCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtZahlungsartCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtZahlungsartCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtZahlungsartCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtZahlungsartCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtZahlungsartCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtZahlungsartCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZahlungsartCode.Properties.NullText = "";
            this.edtZahlungsartCode.Properties.ShowFooter = false;
            this.edtZahlungsartCode.Properties.ShowHeader = false;
            this.edtZahlungsartCode.Size = new System.Drawing.Size(389, 24);
            this.edtZahlungsartCode.TabIndex = 2;
            // 
            // edtZahlungsmodus
            // 
            this.edtZahlungsmodus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtZahlungsmodus.DataMember = "Zahlungsmodus";
            this.edtZahlungsmodus.DataSource = this.qryZahlungsmodus;
            this.edtZahlungsmodus.Location = new System.Drawing.Point(101, 255);
            this.edtZahlungsmodus.Name = "edtZahlungsmodus";
            this.edtZahlungsmodus.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZahlungsmodus.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZahlungsmodus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZahlungsmodus.Properties.Appearance.Options.UseBackColor = true;
            this.edtZahlungsmodus.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZahlungsmodus.Properties.Appearance.Options.UseFont = true;
            this.edtZahlungsmodus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZahlungsmodus.Size = new System.Drawing.Size(389, 24);
            this.edtZahlungsmodus.TabIndex = 1;
            // 
            // lblZahlungsmodus
            // 
            this.lblZahlungsmodus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblZahlungsmodus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lblZahlungsmodus.Location = new System.Drawing.Point(5, 255);
            this.lblZahlungsmodus.Name = "lblZahlungsmodus";
            this.lblZahlungsmodus.Size = new System.Drawing.Size(88, 24);
            this.lblZahlungsmodus.TabIndex = 3;
            this.lblZahlungsmodus.Text = "Zahlungsmodus";
            // 
            // CtlStdZahlungsmodi
            // 
            this.ActiveSQLQuery = this.qryZahlungsmodus;
            this.Controls.Add(this.edtZahlungsartCode);
            this.Controls.Add(this.lblZahlungsartCode);
            this.Controls.Add(this.edtZahlungsmodus);
            this.Controls.Add(this.lblZahlungsmodus);
            this.Controls.Add(this.grdZahlungsmodus);
            this.Name = "CtlStdZahlungsmodi";
            this.Size = new System.Drawing.Size(752, 332);
            this.Load += new System.EventHandler(this.CtlUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdZahlungsmodus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZahlungsmodus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZahlungsmodus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungsartCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungsartCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungsartCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungsmodus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungsmodus)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView grvZahlungsmodus;
        private KiSS4.Gui.KissGrid grdZahlungsmodus;
        private KiSS4.Gui.KissLabel lblZahlungsartCode;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.DB.SqlQuery qryZahlungsmodus;
        private DevExpress.XtraGrid.Columns.GridColumn colZahlungsmodus;
        private DevExpress.XtraGrid.Columns.GridColumn colZahlungsartCode;
        private KiSS4.Gui.KissLabel lblZahlungsmodus;
        private KiSS4.Gui.KissLookUpEdit edtZahlungsartCode;
        private KiSS4.Gui.KissTextEdit edtZahlungsmodus;
    }
}
