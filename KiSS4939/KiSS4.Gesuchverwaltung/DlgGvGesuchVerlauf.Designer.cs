namespace KiSS4.Gesuchverwaltung
{
    partial class DlgGvGesuchVerlauf
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgGvGesuchVerlauf));
            this.btnClose = new KiSS4.Gui.KissButton();
            this.grdGvBewilligung = new KiSS4.Gui.KissGrid();
            this.qryGvBewilligung = new KiSS4.DB.SqlQuery();
            this.grvGvBewilligung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBewilligungCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBenutzer = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdGvBewilligung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryGvBewilligung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvGvBewilligung)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(448, 248);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 24);
            this.btnClose.TabIndex = 28;
            this.btnClose.Text = "Schliessen";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // grdGvBewilligung
            // 
            this.grdGvBewilligung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdGvBewilligung.DataSource = this.qryGvBewilligung;
            // 
            // 
            // 
            this.grdGvBewilligung.EmbeddedNavigator.Name = "";
            this.grdGvBewilligung.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdGvBewilligung.Location = new System.Drawing.Point(12, 12);
            this.grdGvBewilligung.MainView = this.grvGvBewilligung;
            this.grdGvBewilligung.Name = "grdGvBewilligung";
            this.grdGvBewilligung.Size = new System.Drawing.Size(556, 226);
            this.grdGvBewilligung.TabIndex = 29;
            this.grdGvBewilligung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvGvBewilligung});
            // 
            // qryGvBewilligung
            // 
            this.qryGvBewilligung.SelectStatement = resources.GetString("qryGvBewilligung.SelectStatement");
            // 
            // grvGvBewilligung
            // 
            this.grvGvBewilligung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvGvBewilligung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGvBewilligung.Appearance.Empty.Options.UseBackColor = true;
            this.grvGvBewilligung.Appearance.Empty.Options.UseFont = true;
            this.grvGvBewilligung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGvBewilligung.Appearance.EvenRow.Options.UseFont = true;
            this.grvGvBewilligung.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvGvBewilligung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGvBewilligung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvGvBewilligung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvGvBewilligung.Appearance.FocusedCell.Options.UseFont = true;
            this.grvGvBewilligung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvGvBewilligung.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvGvBewilligung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGvBewilligung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvGvBewilligung.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvGvBewilligung.Appearance.FocusedRow.Options.UseFont = true;
            this.grvGvBewilligung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvGvBewilligung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvGvBewilligung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvGvBewilligung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvGvBewilligung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvGvBewilligung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvGvBewilligung.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvGvBewilligung.Appearance.GroupRow.Options.UseFont = true;
            this.grvGvBewilligung.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvGvBewilligung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvGvBewilligung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvGvBewilligung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvGvBewilligung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvGvBewilligung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvGvBewilligung.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvGvBewilligung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvGvBewilligung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGvBewilligung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvGvBewilligung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvGvBewilligung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvGvBewilligung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvGvBewilligung.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvGvBewilligung.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvGvBewilligung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGvBewilligung.Appearance.OddRow.Options.UseFont = true;
            this.grvGvBewilligung.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvGvBewilligung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGvBewilligung.Appearance.Row.Options.UseBackColor = true;
            this.grvGvBewilligung.Appearance.Row.Options.UseFont = true;
            this.grvGvBewilligung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGvBewilligung.Appearance.SelectedRow.Options.UseFont = true;
            this.grvGvBewilligung.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvGvBewilligung.Appearance.VertLine.Options.UseBackColor = true;
            this.grvGvBewilligung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvGvBewilligung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatum,
            this.colBewilligungCode,
            this.colBenutzer});
            this.grvGvBewilligung.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvGvBewilligung.GridControl = this.grdGvBewilligung;
            this.grvGvBewilligung.Name = "grvGvBewilligung";
            this.grvGvBewilligung.OptionsBehavior.Editable = false;
            this.grvGvBewilligung.OptionsCustomization.AllowFilter = false;
            this.grvGvBewilligung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvGvBewilligung.OptionsNavigation.AutoFocusNewRow = true;
            this.grvGvBewilligung.OptionsNavigation.UseTabKey = false;
            this.grvGvBewilligung.OptionsView.ColumnAutoWidth = false;
            this.grvGvBewilligung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvGvBewilligung.OptionsView.ShowGroupPanel = false;
            this.grvGvBewilligung.OptionsView.ShowIndicator = false;
            // 
            // colDatum
            // 
            this.colDatum.Caption = "Datum";
            this.colDatum.FieldName = "Created";
            this.colDatum.Name = "colDatum";
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 0;
            this.colDatum.Width = 110;
            // 
            // colBewilligungCode
            // 
            this.colBewilligungCode.Caption = "Status";
            this.colBewilligungCode.FieldName = "GvBewilligungCode";
            this.colBewilligungCode.Name = "colBewilligungCode";
            this.colBewilligungCode.Visible = true;
            this.colBewilligungCode.VisibleIndex = 1;
            this.colBewilligungCode.Width = 152;
            // 
            // colBenutzer
            // 
            this.colBenutzer.Caption = "Benutzer";
            this.colBenutzer.FieldName = "Benutzer";
            this.colBenutzer.Name = "colBenutzer";
            this.colBenutzer.Visible = true;
            this.colBenutzer.VisibleIndex = 2;
            this.colBenutzer.Width = 110;
            // 
            // DlgGvGesuchVerlauf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(580, 284);
            this.Controls.Add(this.grdGvBewilligung);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "DlgGvGesuchVerlauf";
            this.Text = "Verlauf Gesuch";
            ((System.ComponentModel.ISupportInitialize)(this.grdGvBewilligung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryGvBewilligung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvGvBewilligung)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gui.KissButton btnClose;
        private Gui.KissGrid grdGvBewilligung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvGvBewilligung;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colBewilligungCode;
        private DevExpress.XtraGrid.Columns.GridColumn colBenutzer;
        private DB.SqlQuery qryGvBewilligung;
    }
}