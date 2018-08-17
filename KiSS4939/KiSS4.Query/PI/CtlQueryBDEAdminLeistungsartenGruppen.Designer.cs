namespace KiSS4.Query.PI
{
    partial class CtlQueryBDEAdminLeistungsartenGruppen
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colGruppe;
        private DevExpress.XtraGrid.Columns.GridColumn colLeistungsart;
        private DevExpress.XtraGrid.Columns.GridColumn colStandardKTR;
        private KiSS4.Gui.KissTextEdit edtSucheGruppe;
        private KiSS4.Gui.KissTextEdit edtSucheLeistungsart;
        private KiSS4.Gui.KissTextEdit edtSucheStandardKTR;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel lblSucheGruppe;
        private KiSS4.Gui.KissLabel lblSucheLeistungsart;
        private KiSS4.Gui.KissLabel lblSucheStandardKTR;

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryBDEAdminLeistungsartenGruppen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblSucheStandardKTR = new KiSS4.Gui.KissLabel();
            this.edtSucheStandardKTR = new KiSS4.Gui.KissTextEdit();
            this.lblSucheLeistungsart = new KiSS4.Gui.KissLabel();
            this.edtSucheLeistungsart = new KiSS4.Gui.KissTextEdit();
            this.lblSucheGruppe = new KiSS4.Gui.KissLabel();
            this.edtSucheGruppe = new KiSS4.Gui.KissTextEdit();
            this.colGruppe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLeistungsart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStandardKTR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheStandardKTR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStandardKTR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheLeistungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheLeistungsart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGruppe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGruppe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            // 
            // xDocument
            // 
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Location = new System.Drawing.Point(187, 398);
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.xDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("xDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument öffnen")});
            this.xDocument.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = null;
            this.ctlGotoFall.Size = new System.Drawing.Size(178, 24);
            this.ctlGotoFall.Visible = false;
            // 
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtSucheGruppe);
            this.tpgSuchen.Controls.Add(this.lblSucheGruppe);
            this.tpgSuchen.Controls.Add(this.edtSucheLeistungsart);
            this.tpgSuchen.Controls.Add(this.lblSucheLeistungsart);
            this.tpgSuchen.Controls.Add(this.edtSucheStandardKTR);
            this.tpgSuchen.Controls.Add(this.lblSucheStandardKTR);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheStandardKTR, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheStandardKTR, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheLeistungsart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheLeistungsart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheGruppe, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheGruppe, 0);
            // 
            // lblSucheStandardKTR
            // 
            this.lblSucheStandardKTR.Location = new System.Drawing.Point(31, 40);
            this.lblSucheStandardKTR.Name = "lblSucheStandardKTR";
            this.lblSucheStandardKTR.Size = new System.Drawing.Size(100, 23);
            this.lblSucheStandardKTR.TabIndex = 1;
            this.lblSucheStandardKTR.Text = "Standard KTR";
            this.lblSucheStandardKTR.UseCompatibleTextRendering = true;
            // 
            // edtSucheStandardKTR
            // 
            this.edtSucheStandardKTR.Location = new System.Drawing.Point(137, 40);
            this.edtSucheStandardKTR.Name = "edtSucheStandardKTR";
            this.edtSucheStandardKTR.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheStandardKTR.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheStandardKTR.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheStandardKTR.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheStandardKTR.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheStandardKTR.Properties.Appearance.Options.UseFont = true;
            this.edtSucheStandardKTR.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheStandardKTR.Size = new System.Drawing.Size(177, 24);
            this.edtSucheStandardKTR.TabIndex = 2;
            // 
            // lblSucheLeistungsart
            // 
            this.lblSucheLeistungsart.Location = new System.Drawing.Point(31, 70);
            this.lblSucheLeistungsart.Name = "lblSucheLeistungsart";
            this.lblSucheLeistungsart.Size = new System.Drawing.Size(100, 23);
            this.lblSucheLeistungsart.TabIndex = 3;
            this.lblSucheLeistungsart.Text = "Leistungsart";
            this.lblSucheLeistungsart.UseCompatibleTextRendering = true;
            // 
            // edtSucheLeistungsart
            // 
            this.edtSucheLeistungsart.Location = new System.Drawing.Point(137, 70);
            this.edtSucheLeistungsart.Name = "edtSucheLeistungsart";
            this.edtSucheLeistungsart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheLeistungsart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheLeistungsart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheLeistungsart.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheLeistungsart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheLeistungsart.Properties.Appearance.Options.UseFont = true;
            this.edtSucheLeistungsart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheLeistungsart.Size = new System.Drawing.Size(177, 24);
            this.edtSucheLeistungsart.TabIndex = 4;
            // 
            // lblSucheGruppe
            // 
            this.lblSucheGruppe.Location = new System.Drawing.Point(31, 100);
            this.lblSucheGruppe.Name = "lblSucheGruppe";
            this.lblSucheGruppe.Size = new System.Drawing.Size(100, 23);
            this.lblSucheGruppe.TabIndex = 5;
            this.lblSucheGruppe.Text = "Gruppe";
            this.lblSucheGruppe.UseCompatibleTextRendering = true;
            // 
            // edtSucheGruppe
            // 
            this.edtSucheGruppe.Location = new System.Drawing.Point(137, 100);
            this.edtSucheGruppe.Name = "edtSucheGruppe";
            this.edtSucheGruppe.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheGruppe.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheGruppe.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheGruppe.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheGruppe.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheGruppe.Properties.Appearance.Options.UseFont = true;
            this.edtSucheGruppe.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheGruppe.Size = new System.Drawing.Size(177, 24);
            this.edtSucheGruppe.TabIndex = 6;
            // 
            // colGruppe
            // 
            this.colGruppe.Name = "colGruppe";
            // 
            // colLeistungsart
            // 
            this.colLeistungsart.Name = "colLeistungsart";
            // 
            // colStandardKTR
            // 
            this.colStandardKTR.Name = "colStandardKTR";
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
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
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
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.grdQuery1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // CtlQueryBDEAdminLeistungsartenGruppen
            // 
            this.Name = "CtlQueryBDEAdminLeistungsartenGruppen";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheStandardKTR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStandardKTR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheLeistungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheLeistungsart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGruppe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGruppe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
