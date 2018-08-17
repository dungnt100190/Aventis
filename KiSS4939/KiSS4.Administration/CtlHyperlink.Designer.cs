namespace KiSS4.Administration
{
    partial class CtlHyperlink
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridVorlagen = new KiSS4.Gui.KissGrid();
            this.qryHyperlink = new KiSS4.DB.SqlQuery();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHyperlink = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblLinkName = new KiSS4.Gui.KissLabel();
            this.editHyperlinkName = new KiSS4.Gui.KissTextEdit();
            this.lblLink = new KiSS4.Gui.KissLabel();
            this.editHyperlink = new KiSS4.Gui.KissTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVorlagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryHyperlink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLinkName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editHyperlinkName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editHyperlink.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridVorlagen
            // 
            this.gridVorlagen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridVorlagen.DataSource = this.qryHyperlink;
            // 
            // 
            // 
            this.gridVorlagen.EmbeddedNavigator.Name = "";
            this.gridVorlagen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.gridVorlagen.Location = new System.Drawing.Point(5, 10);
            this.gridVorlagen.MainView = this.gridView1;
            this.gridVorlagen.Name = "gridVorlagen";
            this.gridVorlagen.Size = new System.Drawing.Size(812, 368);
            this.gridVorlagen.TabIndex = 0;
            this.gridVorlagen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // qryHyperlink
            // 
            this.qryHyperlink.CanDelete = true;
            this.qryHyperlink.CanInsert = true;
            this.qryHyperlink.CanUpdate = true;
            this.qryHyperlink.HostControl = this;
            this.qryHyperlink.TableName = "XHyperlink";
            this.qryHyperlink.BeforePost += new System.EventHandler(this.qryTemplate_BeforePost);
            this.qryHyperlink.BeforeDelete += new System.EventHandler(this.qryTemplate_BeforeDelete);
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
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colHyperlink});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.gridVorlagen;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // colName
            // 
            this.colName.AppearanceCell.Options.UseTextOptions = true;
            this.colName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 334;
            // 
            // colHyperlink
            // 
            this.colHyperlink.Caption = "Hyperlink";
            this.colHyperlink.FieldName = "Hyperlink";
            this.colHyperlink.Name = "colHyperlink";
            this.colHyperlink.Visible = true;
            this.colHyperlink.VisibleIndex = 1;
            this.colHyperlink.Width = 427;
            // 
            // lblLinkName
            // 
            this.lblLinkName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLinkName.Location = new System.Drawing.Point(5, 389);
            this.lblLinkName.Name = "lblLinkName";
            this.lblLinkName.Size = new System.Drawing.Size(100, 24);
            this.lblLinkName.TabIndex = 1;
            this.lblLinkName.Text = "Name des Links";
            // 
            // editHyperlinkName
            // 
            this.editHyperlinkName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.editHyperlinkName.DataMember = "Name";
            this.editHyperlinkName.DataSource = this.qryHyperlink;
            this.editHyperlinkName.Location = new System.Drawing.Point(110, 389);
            this.editHyperlinkName.Name = "editHyperlinkName";
            this.editHyperlinkName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editHyperlinkName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editHyperlinkName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editHyperlinkName.Properties.Appearance.Options.UseBackColor = true;
            this.editHyperlinkName.Properties.Appearance.Options.UseBorderColor = true;
            this.editHyperlinkName.Properties.Appearance.Options.UseFont = true;
            this.editHyperlinkName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editHyperlinkName.Size = new System.Drawing.Size(707, 24);
            this.editHyperlinkName.TabIndex = 2;
            // 
            // lblLink
            // 
            this.lblLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLink.Location = new System.Drawing.Point(5, 422);
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(100, 24);
            this.lblLink.TabIndex = 3;
            this.lblLink.Text = "Link";
            // 
            // editHyperlink
            // 
            this.editHyperlink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.editHyperlink.DataMember = "Hyperlink";
            this.editHyperlink.DataSource = this.qryHyperlink;
            this.editHyperlink.Location = new System.Drawing.Point(110, 422);
            this.editHyperlink.Name = "editHyperlink";
            this.editHyperlink.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editHyperlink.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editHyperlink.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editHyperlink.Properties.Appearance.Options.UseBackColor = true;
            this.editHyperlink.Properties.Appearance.Options.UseBorderColor = true;
            this.editHyperlink.Properties.Appearance.Options.UseFont = true;
            this.editHyperlink.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editHyperlink.Size = new System.Drawing.Size(707, 24);
            this.editHyperlink.TabIndex = 4;
            // 
            // CtlHyperlink
            // 
            this.ActiveSQLQuery = this.qryHyperlink;
            this.Controls.Add(this.lblLink);
            this.Controls.Add(this.editHyperlink);
            this.Controls.Add(this.editHyperlinkName);
            this.Controls.Add(this.lblLinkName);
            this.Controls.Add(this.gridVorlagen);
            this.Name = "CtlHyperlink";
            this.Size = new System.Drawing.Size(826, 462);
            this.Load += new System.EventHandler(this.CtlHyperlink_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridVorlagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryHyperlink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLinkName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editHyperlinkName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editHyperlink.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel lblLinkName;
        private KiSS4.DB.SqlQuery qryHyperlink;
        private DevExpress.XtraGrid.Columns.GridColumn colHyperlink;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private KiSS4.Gui.KissGrid gridVorlagen;
        private KiSS4.Gui.KissTextEdit editHyperlinkName;
        private KiSS4.Gui.KissLabel lblLink;
        private KiSS4.Gui.KissTextEdit editHyperlink;
        private System.ComponentModel.IContainer components = null;
    }
}
