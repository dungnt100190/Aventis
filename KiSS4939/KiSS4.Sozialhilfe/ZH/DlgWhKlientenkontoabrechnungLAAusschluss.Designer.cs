namespace KiSS4.Sozialhilfe.ZH
{
    partial class DlgWhKlientenkontoabrechnungLAAusschluss
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgWhKlientenkontoabrechnungLAAusschluss));
            this.btnZuweisen = new KiSS4.Gui.KissButton();
            this.btnAbbrechen = new KiSS4.Gui.KissButton();
            this.lblTitle = new KiSS4.Gui.KissLabel();
            this.pklInstTypen = new KiSS4.Gui.KissPickList();
            this.qryVerfuegbar = new KiSS4.DB.SqlQuery(this.components);
            this.qryZugeteilt = new KiSS4.DB.SqlQuery(this.components);
            this.lblName = new KiSS4.Gui.KissLabel();
            this.qryGueltigkeitsBereich = new KiSS4.DB.SqlQuery(this.components);
            this.grdGueltigkeitsBereich = new KiSS4.Gui.KissGrid();
            this.grvGueltigkeitsBereich = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAusgeschlosseneLAs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblInfo = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryGueltigkeitsBereich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGueltigkeitsBereich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvGueltigkeitsBereich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnZuweisen
            // 
            this.btnZuweisen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZuweisen.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnZuweisen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZuweisen.Location = new System.Drawing.Point(377, 450);
            this.btnZuweisen.Name = "btnZuweisen";
            this.btnZuweisen.Size = new System.Drawing.Size(134, 24);
            this.btnZuweisen.TabIndex = 16;
            this.btnZuweisen.Text = "Auswahl zuweisen";
            this.btnZuweisen.UseCompatibleTextRendering = true;
            this.btnZuweisen.UseVisualStyleBackColor = false;
            this.btnZuweisen.Click += new System.EventHandler(this.btnAnfragen_Click);
            // 
            // btnAbbrechen
            // 
            this.btnAbbrechen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbbrechen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAbbrechen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbbrechen.Location = new System.Drawing.Point(517, 450);
            this.btnAbbrechen.Name = "btnAbbrechen";
            this.btnAbbrechen.Size = new System.Drawing.Size(90, 24);
            this.btnAbbrechen.TabIndex = 15;
            this.btnAbbrechen.Text = "Abbrechen";
            this.btnAbbrechen.UseCompatibleTextRendering = true;
            this.btnAbbrechen.UseVisualStyleBackColor = true;
            this.btnAbbrechen.Click += new System.EventHandler(this.btnAbbrechen_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(77, 16);
            this.lblTitle.TabIndex = 17;
            this.lblTitle.Text = "Person:";
            this.lblTitle.UseCompatibleTextRendering = true;
            // 
            // pklInstTypen
            // 
            this.pklInstTypen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pklInstTypen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.pklInstTypen.ColumnIDName = "BgKostenartID";
            this.pklInstTypen.DataSourceOfSourceGrid = this.qryVerfuegbar;
            this.pklInstTypen.DataSourceOfTargetGrid = this.qryZugeteilt;
            this.pklInstTypen.FilterColumnName = "Name";
            this.pklInstTypen.Location = new System.Drawing.Point(12, 47);
            this.pklInstTypen.Name = "pklInstTypen";
            this.pklInstTypen.Size = new System.Drawing.Size(593, 265);
            this.pklInstTypen.TabIndex = 18;
            this.pklInstTypen.TargetFilterVisible = true;
            // 
            // qryVerfuegbar
            // 
            this.qryVerfuegbar.AutoApplyUserRights = false;
            this.qryVerfuegbar.BatchUpdate = true;
            this.qryVerfuegbar.CanDelete = true;
            this.qryVerfuegbar.CanInsert = true;
            this.qryVerfuegbar.DeleteQuestion = null;
            this.qryVerfuegbar.HostControl = this.pklInstTypen;
            this.qryVerfuegbar.SelectStatement = resources.GetString("qryVerfuegbar.SelectStatement");
            // 
            // qryZugeteilt
            // 
            this.qryZugeteilt.AutoApplyUserRights = false;
            this.qryZugeteilt.BatchUpdate = true;
            this.qryZugeteilt.CanDelete = true;
            this.qryZugeteilt.CanInsert = true;
            this.qryZugeteilt.DeleteQuestion = null;
            this.qryZugeteilt.HostControl = this.pklInstTypen;
            this.qryZugeteilt.SelectStatement = resources.GetString("qryZugeteilt.SelectStatement");
            this.qryZugeteilt.AfterFill += new System.EventHandler(this.qryZugeteilt_AfterFill);
            // 
            // lblName
            // 
            this.lblName.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblName.Location = new System.Drawing.Point(95, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(306, 16);
            this.lblName.TabIndex = 19;
            this.lblName.Text = "Name";
            this.lblName.UseCompatibleTextRendering = true;
            // 
            // qryGueltigkeitsBereich
            // 
            this.qryGueltigkeitsBereich.AutoApplyUserRights = false;
            this.qryGueltigkeitsBereich.BatchUpdate = true;
            this.qryGueltigkeitsBereich.DeleteQuestion = null;
            this.qryGueltigkeitsBereich.HostControl = this.pklInstTypen;
            this.qryGueltigkeitsBereich.SelectStatement = resources.GetString("qryGueltigkeitsBereich.SelectStatement");
            // 
            // grdGueltigkeitsBereich
            // 
            this.grdGueltigkeitsBereich.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdGueltigkeitsBereich.DataSource = this.qryGueltigkeitsBereich;
            // 
            // 
            // 
            this.grdGueltigkeitsBereich.EmbeddedNavigator.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.grdGueltigkeitsBereich.EmbeddedNavigator.Name = "";
            this.grdGueltigkeitsBereich.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdGueltigkeitsBereich.Location = new System.Drawing.Point(12, 353);
            this.grdGueltigkeitsBereich.MainView = this.grvGueltigkeitsBereich;
            this.grdGueltigkeitsBereich.Name = "grdGueltigkeitsBereich";
            this.grdGueltigkeitsBereich.Size = new System.Drawing.Size(593, 90);
            this.grdGueltigkeitsBereich.TabIndex = 20;
            this.grdGueltigkeitsBereich.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvGueltigkeitsBereich});
            // 
            // grvGueltigkeitsBereich
            // 
            this.grvGueltigkeitsBereich.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvGueltigkeitsBereich.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGueltigkeitsBereich.Appearance.Empty.Options.UseBackColor = true;
            this.grvGueltigkeitsBereich.Appearance.Empty.Options.UseFont = true;
            this.grvGueltigkeitsBereich.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGueltigkeitsBereich.Appearance.EvenRow.Options.UseFont = true;
            this.grvGueltigkeitsBereich.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvGueltigkeitsBereich.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGueltigkeitsBereich.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvGueltigkeitsBereich.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvGueltigkeitsBereich.Appearance.FocusedCell.Options.UseFont = true;
            this.grvGueltigkeitsBereich.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvGueltigkeitsBereich.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvGueltigkeitsBereich.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGueltigkeitsBereich.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvGueltigkeitsBereich.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvGueltigkeitsBereich.Appearance.FocusedRow.Options.UseFont = true;
            this.grvGueltigkeitsBereich.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvGueltigkeitsBereich.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvGueltigkeitsBereich.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvGueltigkeitsBereich.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvGueltigkeitsBereich.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvGueltigkeitsBereich.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvGueltigkeitsBereich.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvGueltigkeitsBereich.Appearance.GroupRow.Options.UseFont = true;
            this.grvGueltigkeitsBereich.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvGueltigkeitsBereich.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvGueltigkeitsBereich.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvGueltigkeitsBereich.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvGueltigkeitsBereich.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvGueltigkeitsBereich.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvGueltigkeitsBereich.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvGueltigkeitsBereich.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvGueltigkeitsBereich.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGueltigkeitsBereich.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvGueltigkeitsBereich.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvGueltigkeitsBereich.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvGueltigkeitsBereich.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvGueltigkeitsBereich.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvGueltigkeitsBereich.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvGueltigkeitsBereich.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGueltigkeitsBereich.Appearance.OddRow.Options.UseFont = true;
            this.grvGueltigkeitsBereich.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvGueltigkeitsBereich.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGueltigkeitsBereich.Appearance.Row.Options.UseBackColor = true;
            this.grvGueltigkeitsBereich.Appearance.Row.Options.UseFont = true;
            this.grvGueltigkeitsBereich.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGueltigkeitsBereich.Appearance.SelectedRow.Options.UseFont = true;
            this.grvGueltigkeitsBereich.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvGueltigkeitsBereich.Appearance.VertLine.Options.UseBackColor = true;
            this.grvGueltigkeitsBereich.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvGueltigkeitsBereich.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatumVon,
            this.colAusgeschlosseneLAs});
            this.grvGueltigkeitsBereich.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvGueltigkeitsBereich.GridControl = this.grdGueltigkeitsBereich;
            this.grvGueltigkeitsBereich.Name = "grvGueltigkeitsBereich";
            this.grvGueltigkeitsBereich.OptionsBehavior.Editable = false;
            this.grvGueltigkeitsBereich.OptionsCustomization.AllowColumnMoving = false;
            this.grvGueltigkeitsBereich.OptionsCustomization.AllowFilter = false;
            this.grvGueltigkeitsBereich.OptionsCustomization.AllowGroup = false;
            this.grvGueltigkeitsBereich.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvGueltigkeitsBereich.OptionsNavigation.AutoFocusNewRow = true;
            this.grvGueltigkeitsBereich.OptionsNavigation.UseTabKey = false;
            this.grvGueltigkeitsBereich.OptionsView.ColumnAutoWidth = false;
            this.grvGueltigkeitsBereich.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvGueltigkeitsBereich.OptionsView.ShowGroupPanel = false;
            this.grvGueltigkeitsBereich.OptionsView.ShowIndicator = false;
            // 
            // colDatumVon
            // 
            this.colDatumVon.Caption = "Datum von";
            this.colDatumVon.FieldName = "DatumVon";
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.SummaryItem.DisplayFormat = "Total";
            this.colDatumVon.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.colDatumVon.Visible = true;
            this.colDatumVon.VisibleIndex = 0;
            // 
            // colAusgeschlosseneLAs
            // 
            this.colAusgeschlosseneLAs.Caption = "LAs";
            this.colAusgeschlosseneLAs.DisplayFormat.FormatString = "n2";
            this.colAusgeschlosseneLAs.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAusgeschlosseneLAs.FieldName = "AusgeschlosseneLAs";
            this.colAusgeschlosseneLAs.Name = "colAusgeschlosseneLAs";
            this.colAusgeschlosseneLAs.SummaryItem.DisplayFormat = "{0:n2}";
            this.colAusgeschlosseneLAs.SummaryItem.FieldName = "Betrag";
            this.colAusgeschlosseneLAs.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colAusgeschlosseneLAs.Visible = true;
            this.colAusgeschlosseneLAs.VisibleIndex = 1;
            this.colAusgeschlosseneLAs.Width = 474;
            // 
            // lblInfo
            // 
            this.lblInfo.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblInfo.Location = new System.Drawing.Point(12, 324);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(593, 16);
            this.lblInfo.TabIndex = 21;
            this.lblInfo.Text = "Standardmässig sind folgende LA\'s manuell auszuschliessen";
            this.lblInfo.UseCompatibleTextRendering = true;
            // 
            // DlgWhKlientenkontoabrechnungLAAusschluss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 486);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.grdGueltigkeitsBereich);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pklInstTypen);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnZuweisen);
            this.Controls.Add(this.btnAbbrechen);
            this.MinimumSize = new System.Drawing.Size(625, 458);
            this.Name = "DlgWhKlientenkontoabrechnungLAAusschluss";
            this.Text = "Zusätzliche Leistungsarten";
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryGueltigkeitsBereich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGueltigkeitsBereich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvGueltigkeitsBereich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissButton btnZuweisen;
        private KiSS4.Gui.KissButton btnAbbrechen;
        private KiSS4.Gui.KissLabel lblTitle;
        private KiSS4.Gui.KissPickList pklInstTypen;
        private KiSS4.DB.SqlQuery qryVerfuegbar;
        private KiSS4.DB.SqlQuery qryZugeteilt;
        private KiSS4.Gui.KissLabel lblName;
        private DB.SqlQuery qryGueltigkeitsBereich;
        private Gui.KissGrid grdGueltigkeitsBereich;
        private DevExpress.XtraGrid.Views.Grid.GridView grvGueltigkeitsBereich;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colAusgeschlosseneLAs;
        private Gui.KissLabel lblInfo;
    }
}