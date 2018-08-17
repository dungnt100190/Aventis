namespace KiSS4.Klientenbuchhaltung
{
    partial class CtlKbKostenstelle
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
            this.grdKbKostenstelle = new KiSS4.Gui.KissGrid();
            this.gvBaBank = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAktiv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdKbKostenstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBaBank)).BeginInit();
            this.SuspendLayout();
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdKbKostenstelle);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Title = "Suche";
            // 
            // grdKbKostenstelle
            // 
            this.grdKbKostenstelle.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdKbKostenstelle.EmbeddedNavigator.Name = "grid.EmbeddedNavigator";
            this.grdKbKostenstelle.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdKbKostenstelle.Location = new System.Drawing.Point(0, 0);
            this.grdKbKostenstelle.MainView = this.gvBaBank;
            this.grdKbKostenstelle.Name = "grdKbKostenstelle";
            this.grdKbKostenstelle.Size = new System.Drawing.Size(782, 223);
            this.grdKbKostenstelle.TabIndex = 7;
            this.grdKbKostenstelle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvBaBank});
            // 
            // gvBaBank
            // 
            this.gvBaBank.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gvBaBank.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvBaBank.Appearance.Empty.Options.UseBackColor = true;
            this.gvBaBank.Appearance.Empty.Options.UseFont = true;
            this.gvBaBank.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.gvBaBank.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvBaBank.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvBaBank.Appearance.EvenRow.Options.UseFont = true;
            this.gvBaBank.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvBaBank.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvBaBank.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gvBaBank.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvBaBank.Appearance.FocusedCell.Options.UseFont = true;
            this.gvBaBank.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvBaBank.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvBaBank.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvBaBank.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gvBaBank.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvBaBank.Appearance.FocusedRow.Options.UseFont = true;
            this.gvBaBank.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvBaBank.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gvBaBank.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gvBaBank.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gvBaBank.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvBaBank.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvBaBank.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvBaBank.Appearance.GroupRow.Options.UseFont = true;
            this.gvBaBank.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvBaBank.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gvBaBank.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gvBaBank.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvBaBank.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvBaBank.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gvBaBank.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvBaBank.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gvBaBank.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvBaBank.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvBaBank.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvBaBank.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvBaBank.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvBaBank.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gvBaBank.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvBaBank.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvBaBank.Appearance.OddRow.Options.UseFont = true;
            this.gvBaBank.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gvBaBank.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvBaBank.Appearance.Row.Options.UseBackColor = true;
            this.gvBaBank.Appearance.Row.Options.UseFont = true;
            this.gvBaBank.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gvBaBank.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvBaBank.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gvBaBank.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvBaBank.Appearance.SelectedRow.Options.UseFont = true;
            this.gvBaBank.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvBaBank.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gvBaBank.Appearance.VertLine.Options.UseBackColor = true;
            this.gvBaBank.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gvBaBank.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNr,
            this.colAktiv,
            this.colName});
            this.gvBaBank.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gvBaBank.GridControl = this.grdKbKostenstelle;
            this.gvBaBank.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.gvBaBank.Name = "gvBaBank";
            this.gvBaBank.OptionsBehavior.Editable = false;
            this.gvBaBank.OptionsCustomization.AllowFilter = false;
            this.gvBaBank.OptionsFilter.AllowFilterEditor = false;
            this.gvBaBank.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gvBaBank.OptionsMenu.EnableColumnMenu = false;
            this.gvBaBank.OptionsNavigation.AutoFocusNewRow = true;
            this.gvBaBank.OptionsNavigation.UseTabKey = false;
            this.gvBaBank.OptionsView.ColumnAutoWidth = false;
            this.gvBaBank.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvBaBank.OptionsView.ShowGroupPanel = false;
            this.gvBaBank.OptionsView.ShowIndicator = false;
            // 
            // colNr
            // 
            this.colNr.Caption = "Nr.";
            this.colNr.FieldName = "Nr";
            this.colNr.Name = "colNr";
            this.colNr.Visible = true;
            this.colNr.VisibleIndex = 0;
            this.colNr.Width = 222;
            // 
            // colAktiv
            // 
            this.colAktiv.Caption = "Aktiv";
            this.colAktiv.FieldName = "Aktiv";
            this.colAktiv.Name = "colAktiv";
            this.colAktiv.Visible = true;
            this.colAktiv.VisibleIndex = 2;
            this.colAktiv.Width = 80;
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 238;
            // 
            // CtlKbKostenstelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "CtlKbKostenstelle";
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdKbKostenstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBaBank)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissGrid grdKbKostenstelle;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBaBank;
        private DevExpress.XtraGrid.Columns.GridColumn colNr;
        private DevExpress.XtraGrid.Columns.GridColumn colAktiv;
        private DevExpress.XtraGrid.Columns.GridColumn colName;


    }
}
