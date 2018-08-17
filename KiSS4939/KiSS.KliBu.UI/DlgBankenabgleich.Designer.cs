namespace KiSS.KliBu.UI
{
    partial class DlgBankenabgleich
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgBankenabgleich));
            this.btnOK = new KiSS4.Gui.KissButton();
            this.btnUpdate = new KiSS4.Gui.KissButton();
            this.panUserControl = new System.Windows.Forms.Panel();
            this.grdBaBank = new KiSS4.Gui.KissGrid();
            this.qryBaBank = new KiSS4.DB.SqlQuery(this.components);
            this.grvBaBank = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClearingNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFilialeNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPcKontoNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHauptsitzBCL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClearingNrNeu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZusatz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLandCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGueltigAb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblLastUpdate = new KiSS4.Gui.KissLabel();
            this.panUserControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLastUpdate)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(594, 434);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(96, 24);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Location = new System.Drawing.Point(12, 434);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(173, 24);
            this.btnUpdate.TabIndex = 318;
            this.btnUpdate.Text = "Bankenstamm aktualisieren";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // panUserControl
            // 
            this.panUserControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panUserControl.Controls.Add(this.grdBaBank);
            this.panUserControl.Location = new System.Drawing.Point(12, 12);
            this.panUserControl.Name = "panUserControl";
            this.panUserControl.Size = new System.Drawing.Size(678, 416);
            this.panUserControl.TabIndex = 319;
            // 
            // grdBaBank
            // 
            this.grdBaBank.DataSource = this.qryBaBank;
            this.grdBaBank.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdBaBank.EmbeddedNavigator.Name = "grid.EmbeddedNavigator";
            this.grdBaBank.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBaBank.Location = new System.Drawing.Point(0, 0);
            this.grdBaBank.MainView = this.grvBaBank;
            this.grdBaBank.Name = "grdBaBank";
            this.grdBaBank.Size = new System.Drawing.Size(678, 416);
            this.grdBaBank.TabIndex = 7;
            this.grdBaBank.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBaBank});
            // 
            // qryBaBank
            // 
            this.qryBaBank.HostControl = this;
            this.qryBaBank.SelectStatement = resources.GetString("qryBaBank.SelectStatement");
            // 
            // grvBaBank
            // 
            this.grvBaBank.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBaBank.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaBank.Appearance.Empty.Options.UseBackColor = true;
            this.grvBaBank.Appearance.Empty.Options.UseFont = true;
            this.grvBaBank.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvBaBank.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaBank.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvBaBank.Appearance.EvenRow.Options.UseFont = true;
            this.grvBaBank.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaBank.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaBank.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBaBank.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBaBank.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBaBank.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBaBank.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaBank.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaBank.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBaBank.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBaBank.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBaBank.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBaBank.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaBank.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBaBank.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaBank.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaBank.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaBank.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBaBank.Appearance.GroupRow.Options.UseFont = true;
            this.grvBaBank.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBaBank.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBaBank.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBaBank.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaBank.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBaBank.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBaBank.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBaBank.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBaBank.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaBank.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaBank.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBaBank.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBaBank.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBaBank.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaBank.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBaBank.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaBank.Appearance.OddRow.Options.UseFont = true;
            this.grvBaBank.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBaBank.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaBank.Appearance.Row.Options.UseBackColor = true;
            this.grvBaBank.Appearance.Row.Options.UseFont = true;
            this.grvBaBank.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvBaBank.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaBank.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvBaBank.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvBaBank.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBaBank.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvBaBank.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaBank.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBaBank.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBaBank.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatum,
            this.colName,
            this.colClearingNr,
            this.colFilialeNr,
            this.colPcKontoNr,
            this.colHauptsitzBCL,
            this.colClearingNrNeu,
            this.colStrasse,
            this.colPLZ,
            this.colOrt,
            this.colZusatz,
            this.colLandCode,
            this.colGueltigAb});
            this.grvBaBank.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBaBank.GridControl = this.grdBaBank;
            this.grvBaBank.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvBaBank.Name = "grvBaBank";
            this.grvBaBank.OptionsBehavior.Editable = false;
            this.grvBaBank.OptionsCustomization.AllowFilter = false;
            this.grvBaBank.OptionsFilter.AllowFilterEditor = false;
            this.grvBaBank.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBaBank.OptionsMenu.EnableColumnMenu = false;
            this.grvBaBank.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBaBank.OptionsNavigation.UseTabKey = false;
            this.grvBaBank.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBaBank.OptionsView.ShowGroupPanel = false;
            this.grvBaBank.OptionsView.ShowIndicator = false;
            // 
            // colDatum
            // 
            this.colDatum.Caption = "Erstelldatum";
            this.colDatum.Name = "colDatum";
            this.colDatum.OptionsColumn.FixedWidth = true;
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 0;
            this.colDatum.Width = 80;
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 222;
            // 
            // colClearingNr
            // 
            this.colClearingNr.Caption = "ClearingNr";
            this.colClearingNr.Name = "colClearingNr";
            this.colClearingNr.OptionsColumn.FixedWidth = true;
            this.colClearingNr.Visible = true;
            this.colClearingNr.VisibleIndex = 2;
            // 
            // colFilialeNr
            // 
            this.colFilialeNr.Caption = "FilialeNr";
            this.colFilialeNr.Name = "colFilialeNr";
            this.colFilialeNr.OptionsColumn.FixedWidth = true;
            this.colFilialeNr.Visible = true;
            this.colFilialeNr.VisibleIndex = 3;
            // 
            // colPcKontoNr
            // 
            this.colPcKontoNr.Caption = "PostKonto Nr";
            this.colPcKontoNr.Name = "colPcKontoNr";
            this.colPcKontoNr.OptionsColumn.FixedWidth = true;
            this.colPcKontoNr.Visible = true;
            this.colPcKontoNr.VisibleIndex = 6;
            this.colPcKontoNr.Width = 95;
            // 
            // colHauptsitzBCL
            // 
            this.colHauptsitzBCL.Caption = "Hauptsitz ClearingNr";
            this.colHauptsitzBCL.Name = "colHauptsitzBCL";
            this.colHauptsitzBCL.OptionsColumn.FixedWidth = true;
            this.colHauptsitzBCL.Visible = true;
            this.colHauptsitzBCL.VisibleIndex = 5;
            // 
            // colClearingNrNeu
            // 
            this.colClearingNrNeu.Caption = "ClearingNr neu";
            this.colClearingNrNeu.Name = "colClearingNrNeu";
            this.colClearingNrNeu.OptionsColumn.FixedWidth = true;
            this.colClearingNrNeu.Visible = true;
            this.colClearingNrNeu.VisibleIndex = 4;
            this.colClearingNrNeu.Width = 95;
            // 
            // colStrasse
            // 
            this.colStrasse.Caption = "Strasse";
            this.colStrasse.Name = "colStrasse";
            this.colStrasse.Visible = true;
            this.colStrasse.VisibleIndex = 7;
            this.colStrasse.Width = 170;
            // 
            // colPLZ
            // 
            this.colPLZ.Caption = "PLZ";
            this.colPLZ.Name = "colPLZ";
            this.colPLZ.OptionsColumn.FixedWidth = true;
            this.colPLZ.Visible = true;
            this.colPLZ.VisibleIndex = 8;
            this.colPLZ.Width = 74;
            // 
            // colOrt
            // 
            this.colOrt.Caption = "Ort";
            this.colOrt.Name = "colOrt";
            this.colOrt.Visible = true;
            this.colOrt.VisibleIndex = 9;
            this.colOrt.Width = 139;
            // 
            // colZusatz
            // 
            this.colZusatz.Caption = "Zusatz";
            this.colZusatz.Name = "colZusatz";
            this.colZusatz.Visible = true;
            this.colZusatz.VisibleIndex = 10;
            // 
            // colLandCode
            // 
            this.colLandCode.Caption = "Landcode";
            this.colLandCode.Name = "colLandCode";
            this.colLandCode.OptionsColumn.FixedWidth = true;
            this.colLandCode.Visible = true;
            this.colLandCode.VisibleIndex = 11;
            // 
            // colGueltigAb
            // 
            this.colGueltigAb.Caption = "Gültig ab";
            this.colGueltigAb.Name = "colGueltigAb";
            this.colGueltigAb.OptionsColumn.FixedWidth = true;
            this.colGueltigAb.Visible = true;
            this.colGueltigAb.VisibleIndex = 12;
            // 
            // lblLastUpdate
            // 
            this.lblLastUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLastUpdate.Location = new System.Drawing.Point(191, 434);
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new System.Drawing.Size(352, 24);
            this.lblLastUpdate.TabIndex = 324;
            this.lblLastUpdate.Text = "letzte Aktualisierung am";
            this.lblLastUpdate.UseCompatibleTextRendering = true;
            // 
            // DlgBankenabgleich
            // 
            this.ActiveSQLQuery = this.qryBaBank;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 470);
            this.Controls.Add(this.lblLastUpdate);
            this.Controls.Add(this.panUserControl);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "DlgBankenabgleich";
            this.Text = "Bankenstamm-History";
            this.Load += new System.EventHandler(this.DlgBankenabgleich_Load);
            this.panUserControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBaBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLastUpdate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissButton btnOK;
        private KiSS4.Gui.KissButton btnUpdate;
        private System.Windows.Forms.Panel panUserControl;
        private KiSS4.Gui.KissGrid grdBaBank;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBaBank;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasse;
        private DevExpress.XtraGrid.Columns.GridColumn colPcKontoNr;
        private DevExpress.XtraGrid.Columns.GridColumn colPLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colClearingNrNeu;
        private DevExpress.XtraGrid.Columns.GridColumn colClearingNr;
        private DevExpress.XtraGrid.Columns.GridColumn colFilialeNr;
        private DevExpress.XtraGrid.Columns.GridColumn colHauptsitzBCL;
        private DevExpress.XtraGrid.Columns.GridColumn colZusatz;
        private DevExpress.XtraGrid.Columns.GridColumn colLandCode;
        private DevExpress.XtraGrid.Columns.GridColumn colGueltigAb;
        private KiSS4.DB.SqlQuery qryBaBank;
        private KiSS4.Gui.KissLabel lblLastUpdate;

    }
}