namespace KiSS4.Query
{
    partial class CtlQueryKaQJIntakeGespraech
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryKaQJIntakeGespraech));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblDatumvon = new KiSS4.Gui.KissLabel();
            this.lblbis = new KiSS4.Gui.KissLabel();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.colAnzahl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBezeichnung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdViewIntakeGespraech = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumvon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewIntakeGespraech)).BeginInit();
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
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            this.xDocument.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = "BaPersonID$";
            this.ctlGotoFall.Location = new System.Drawing.Point(3, 395);
            this.ctlGotoFall.Size = new System.Drawing.Size(158, 27);
            // 
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtDatumBis);
            this.tpgSuchen.Controls.Add(this.edtDatumVon);
            this.tpgSuchen.Controls.Add(this.lblbis);
            this.tpgSuchen.Controls.Add(this.lblDatumvon);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.TabIndex = 2;
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblDatumvon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblbis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumBis, 0);
            // 
            // lblDatumvon
            // 
            this.lblDatumvon.Location = new System.Drawing.Point(8, 55);
            this.lblDatumvon.Name = "lblDatumvon";
            this.lblDatumvon.Size = new System.Drawing.Size(75, 24);
            this.lblDatumvon.TabIndex = 1;
            this.lblDatumvon.Text = "Datum von";
            this.lblDatumvon.UseCompatibleTextRendering = true;
            // 
            // lblbis
            // 
            this.lblbis.Location = new System.Drawing.Point(200, 55);
            this.lblbis.Name = "lblbis";
            this.lblbis.Size = new System.Drawing.Size(30, 24);
            this.lblbis.TabIndex = 3;
            this.lblbis.Text = "bis";
            this.lblbis.UseCompatibleTextRendering = true;
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.EditValue = "";
            this.edtDatumVon.Location = new System.Drawing.Point(89, 55);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 2;
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.EditValue = "";
            this.edtDatumBis.Location = new System.Drawing.Point(236, 55);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 4;
            // 
            // colAnzahl
            // 
            this.colAnzahl.Name = "colAnzahl";
            // 
            // colBezeichnung
            // 
            this.colBezeichnung.Name = "colBezeichnung";
            // 
            // grdViewIntakeGespraech
            // 
            this.grdViewIntakeGespraech.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grdViewIntakeGespraech.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grdViewIntakeGespraech.Appearance.Empty.Options.UseBackColor = true;
            this.grdViewIntakeGespraech.Appearance.Empty.Options.UseFont = true;
            this.grdViewIntakeGespraech.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grdViewIntakeGespraech.Appearance.EvenRow.Options.UseFont = true;
            this.grdViewIntakeGespraech.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grdViewIntakeGespraech.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grdViewIntakeGespraech.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grdViewIntakeGespraech.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grdViewIntakeGespraech.Appearance.FocusedCell.Options.UseFont = true;
            this.grdViewIntakeGespraech.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grdViewIntakeGespraech.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grdViewIntakeGespraech.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grdViewIntakeGespraech.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grdViewIntakeGespraech.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grdViewIntakeGespraech.Appearance.FocusedRow.Options.UseFont = true;
            this.grdViewIntakeGespraech.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grdViewIntakeGespraech.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grdViewIntakeGespraech.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grdViewIntakeGespraech.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grdViewIntakeGespraech.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grdViewIntakeGespraech.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grdViewIntakeGespraech.Appearance.GroupRow.Options.UseBackColor = true;
            this.grdViewIntakeGespraech.Appearance.GroupRow.Options.UseFont = true;
            this.grdViewIntakeGespraech.Appearance.GroupRow.Options.UseForeColor = true;
            this.grdViewIntakeGespraech.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grdViewIntakeGespraech.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grdViewIntakeGespraech.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grdViewIntakeGespraech.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grdViewIntakeGespraech.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grdViewIntakeGespraech.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdViewIntakeGespraech.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grdViewIntakeGespraech.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grdViewIntakeGespraech.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grdViewIntakeGespraech.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grdViewIntakeGespraech.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grdViewIntakeGespraech.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grdViewIntakeGespraech.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grdViewIntakeGespraech.Appearance.HorzLine.Options.UseBackColor = true;
            this.grdViewIntakeGespraech.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grdViewIntakeGespraech.Appearance.OddRow.Options.UseFont = true;
            this.grdViewIntakeGespraech.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grdViewIntakeGespraech.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grdViewIntakeGespraech.Appearance.Row.Options.UseBackColor = true;
            this.grdViewIntakeGespraech.Appearance.Row.Options.UseFont = true;
            this.grdViewIntakeGespraech.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grdViewIntakeGespraech.Appearance.SelectedRow.Options.UseFont = true;
            this.grdViewIntakeGespraech.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grdViewIntakeGespraech.Appearance.VertLine.Options.UseBackColor = true;
            this.grdViewIntakeGespraech.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grdViewIntakeGespraech.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grdViewIntakeGespraech.GridControl = this.grdQuery1;
            this.grdViewIntakeGespraech.Name = "grdViewIntakeGespraech";
            this.grdViewIntakeGespraech.OptionsBehavior.Editable = false;
            this.grdViewIntakeGespraech.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grdViewIntakeGespraech.OptionsNavigation.AutoFocusNewRow = true;
            this.grdViewIntakeGespraech.OptionsNavigation.UseTabKey = false;
            this.grdViewIntakeGespraech.OptionsView.ColumnAutoWidth = false;
            this.grdViewIntakeGespraech.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grdViewIntakeGespraech.OptionsView.ShowGroupPanel = false;
            this.grdViewIntakeGespraech.OptionsView.ShowIndicator = false;
            // 
            // CtlQueryKaQJIntakeGespraech
            // 
            this.Name = "CtlQueryKaQJIntakeGespraech";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumvon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewIntakeGespraech)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn colAnzahl;
        private DevExpress.XtraGrid.Columns.GridColumn colBezeichnung;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private DevExpress.XtraGrid.Views.Grid.GridView grdViewIntakeGespraech;
        private KiSS4.Gui.KissLabel lblDatumvon;
        private KiSS4.Gui.KissLabel lblbis;
    }
}
