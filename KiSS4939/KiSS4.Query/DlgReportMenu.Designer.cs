namespace KiSS4.Query
{
    partial class DlgReportMenu
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
            this.components = new System.ComponentModel.Container();
            this.grdReportKontext = new KiSS4.Gui.KissGrid();
            this.qryMenu = new KiSS4.DB.SqlQuery(this.components);
            this.grvReportKontext = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colReport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnCancel = new KiSS4.Gui.KissButton();
            this.btnPrint = new KiSS4.Gui.KissButton();
            this.chkOffenhalten = new KiSS4.Gui.KissCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReportKontext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvReportKontext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOffenhalten.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdReportKontext
            // 
            this.grdReportKontext.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdReportKontext.DataSource = this.qryMenu;
            // 
            // 
            // 
            this.grdReportKontext.EmbeddedNavigator.Name = "";
            this.grdReportKontext.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdReportKontext.Location = new System.Drawing.Point(8, 8);
            this.grdReportKontext.MainView = this.grvReportKontext;
            this.grdReportKontext.Name = "grdReportKontext";
            this.grdReportKontext.Size = new System.Drawing.Size(322, 296);
            this.grdReportKontext.TabIndex = 0;
            this.grdReportKontext.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvReportKontext});
            this.grdReportKontext.DoubleClick += new System.EventHandler(this.grdReportKontext_DoubleClick);
            // 
            // qryMenu
            // 
            this.qryMenu.HostControl = this;
            this.qryMenu.IsIdentityInsert = false;
            // 
            // grvReportKontext
            // 
            this.grvReportKontext.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvReportKontext.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvReportKontext.Appearance.Empty.Options.UseBackColor = true;
            this.grvReportKontext.Appearance.Empty.Options.UseFont = true;
            this.grvReportKontext.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvReportKontext.Appearance.EvenRow.Options.UseFont = true;
            this.grvReportKontext.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvReportKontext.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvReportKontext.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvReportKontext.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvReportKontext.Appearance.FocusedCell.Options.UseFont = true;
            this.grvReportKontext.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvReportKontext.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvReportKontext.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvReportKontext.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvReportKontext.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvReportKontext.Appearance.FocusedRow.Options.UseFont = true;
            this.grvReportKontext.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvReportKontext.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvReportKontext.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvReportKontext.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvReportKontext.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvReportKontext.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvReportKontext.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvReportKontext.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvReportKontext.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvReportKontext.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvReportKontext.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvReportKontext.Appearance.GroupRow.Options.UseFont = true;
            this.grvReportKontext.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvReportKontext.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvReportKontext.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvReportKontext.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvReportKontext.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvReportKontext.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvReportKontext.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvReportKontext.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvReportKontext.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvReportKontext.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvReportKontext.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvReportKontext.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvReportKontext.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvReportKontext.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvReportKontext.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvReportKontext.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvReportKontext.Appearance.OddRow.Options.UseFont = true;
            this.grvReportKontext.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvReportKontext.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvReportKontext.Appearance.Row.Options.UseBackColor = true;
            this.grvReportKontext.Appearance.Row.Options.UseFont = true;
            this.grvReportKontext.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvReportKontext.Appearance.SelectedRow.Options.UseFont = true;
            this.grvReportKontext.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvReportKontext.Appearance.VertLine.Options.UseBackColor = true;
            this.grvReportKontext.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvReportKontext.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colReport});
            this.grvReportKontext.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvReportKontext.GridControl = this.grdReportKontext;
            this.grvReportKontext.Name = "grvReportKontext";
            this.grvReportKontext.OptionsBehavior.Editable = false;
            this.grvReportKontext.OptionsCustomization.AllowFilter = false;
            this.grvReportKontext.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvReportKontext.OptionsNavigation.AutoFocusNewRow = true;
            this.grvReportKontext.OptionsNavigation.UseTabKey = false;
            this.grvReportKontext.OptionsView.ColumnAutoWidth = false;
            this.grvReportKontext.OptionsView.ShowColumnHeaders = false;
            this.grvReportKontext.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvReportKontext.OptionsView.ShowGroupPanel = false;
            this.grvReportKontext.OptionsView.ShowIndicator = false;
            // 
            // colReport
            // 
            this.colReport.Caption = "Verfügbare Reports in diesem Kontext";
            this.colReport.FieldName = "UserText";
            this.colReport.Name = "colReport";
            this.colReport.Visible = true;
            this.colReport.VisibleIndex = 0;
            this.colReport.Width = 300;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(146, 312);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 24);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Abbruch";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Location = new System.Drawing.Point(242, 312);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(88, 24);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "Drucken";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // chkOffenhalten
            // 
            this.chkOffenhalten.EditValue = false;
            this.chkOffenhalten.Location = new System.Drawing.Point(8, 312);
            this.chkOffenhalten.Name = "chkOffenhalten";
            this.chkOffenhalten.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkOffenhalten.Properties.Appearance.Options.UseBackColor = true;
            this.chkOffenhalten.Properties.Caption = "Auswahl offenhalten";
            this.chkOffenhalten.Size = new System.Drawing.Size(128, 19);
            this.chkOffenhalten.TabIndex = 1;
            // 
            // DlgReportMenu
            // 
            this.AcceptButton = this.btnPrint;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(338, 344);
            this.Controls.Add(this.chkOffenhalten);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.grdReportKontext);
            this.Name = "DlgReportMenu";
            this.Text = "Report Auswahl";
            this.Print += new System.EventHandler(this.DlgReportMenu_Print);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.DlgReportMenu_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.grdReportKontext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvReportKontext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOffenhalten.Properties)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private KiSS4.Gui.KissGrid grdReportKontext;
        private DevExpress.XtraGrid.Views.Grid.GridView grvReportKontext;
        private DevExpress.XtraGrid.Columns.GridColumn colReport;
        private KiSS4.DB.SqlQuery qryMenu;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissButton btnCancel;
        private KiSS4.Gui.KissButton btnPrint;
        private KiSS4.Gui.KissCheckEdit chkOffenhalten;
    }
}
