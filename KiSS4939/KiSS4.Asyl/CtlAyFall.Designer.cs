namespace KiSS4.Asyl
{
    partial class CtlAyFall
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlAyFall));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdFaLeistung = new KiSS4.Gui.KissGrid();
            this.qryFaLeistung = new KiSS4.DB.SqlQuery();
            this.grvFaLeistung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGrundEroeffnen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGrundAbschluss = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBemerkung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.lblFaLeistung = new KiSS4.Gui.KissLabel();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblDatumBis = new KiSS4.Gui.KissLabel();
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            this.lblEroeffnungsGrundCode = new KiSS4.Gui.KissLabel();
            this.lblAbschlussGrundCode = new KiSS4.Gui.KissLabel();
            this.edtAbschlussGrundCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtEroeffnungsGrundCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.edtGemeindeCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblGemeindeCode = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grdFaLeistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLeistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFaLeistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaLeistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffnungsGrundCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussGrundCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrundCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrundCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungsGrundCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungsGrundCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGemeindeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGemeindeCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGemeindeCode)).BeginInit();
            this.SuspendLayout();
            // 
            // grdFaLeistung
            // 
            this.grdFaLeistung.DataSource = this.qryFaLeistung;
            // 
            // 
            // 
            this.grdFaLeistung.EmbeddedNavigator.Name = "";
            this.grdFaLeistung.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdFaLeistung.Location = new System.Drawing.Point(8, 248);
            this.grdFaLeistung.MainView = this.grvFaLeistung;
            this.grdFaLeistung.Name = "grdFaLeistung";
            this.grdFaLeistung.Size = new System.Drawing.Size(664, 232);
            this.grdFaLeistung.TabIndex = 11;
            this.grdFaLeistung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvFaLeistung});
            // 
            // qryFaLeistung
            // 
            this.qryFaLeistung.CanDelete = true;
            this.qryFaLeistung.CanInsert = true;
            this.qryFaLeistung.CanUpdate = true;
            this.qryFaLeistung.HostControl = this;
            this.qryFaLeistung.IsIdentityInsert = false;
            this.qryFaLeistung.SelectStatement = resources.GetString("qryFaLeistung.SelectStatement");
            this.qryFaLeistung.TableName = "FaLeistung";
            this.qryFaLeistung.AfterDelete += new System.EventHandler(this.qryFaLeistung_AfterDelete);
            this.qryFaLeistung.AfterInsert += new System.EventHandler(this.qryFaLeistung_AfterInsert);
            this.qryFaLeistung.AfterPost += new System.EventHandler(this.qryFaLeistung_AfterPost);
            this.qryFaLeistung.BeforeDeleteQuestion += new System.EventHandler(this.qryFaLeistung_BeforeDeleteQuestion);
            this.qryFaLeistung.BeforeInsert += new System.EventHandler(this.qryFaLeistung_BeforeInsert);
            this.qryFaLeistung.BeforePost += new System.EventHandler(this.qryFaLeistung_BeforePost);
            // 
            // grvFaLeistung
            // 
            this.grvFaLeistung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvFaLeistung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.Empty.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.Empty.Options.UseFont = true;
            this.grvFaLeistung.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvFaLeistung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.EvenRow.Options.UseFont = true;
            this.grvFaLeistung.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFaLeistung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvFaLeistung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.FocusedCell.Options.UseFont = true;
            this.grvFaLeistung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvFaLeistung.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFaLeistung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvFaLeistung.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.FocusedRow.Options.UseFont = true;
            this.grvFaLeistung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvFaLeistung.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFaLeistung.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvFaLeistung.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvFaLeistung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFaLeistung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFaLeistung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFaLeistung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFaLeistung.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.GroupRow.Options.UseFont = true;
            this.grvFaLeistung.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvFaLeistung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvFaLeistung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvFaLeistung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFaLeistung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvFaLeistung.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvFaLeistung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvFaLeistung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFaLeistung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvFaLeistung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvFaLeistung.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvFaLeistung.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvFaLeistung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.OddRow.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.OddRow.Options.UseFont = true;
            this.grvFaLeistung.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvFaLeistung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.Row.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.Row.Options.UseFont = true;
            this.grvFaLeistung.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvFaLeistung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvFaLeistung.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.SelectedRow.Options.UseFont = true;
            this.grvFaLeistung.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvFaLeistung.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvFaLeistung.Appearance.VertLine.Options.UseBackColor = true;
            this.grvFaLeistung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvFaLeistung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatumVon,
            this.colGrundEroeffnen,
            this.colDatumBis,
            this.colGrundAbschluss,
            this.colFP,
            this.colBemerkung});
            this.grvFaLeistung.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvFaLeistung.GridControl = this.grdFaLeistung;
            this.grvFaLeistung.Name = "grvFaLeistung";
            this.grvFaLeistung.OptionsBehavior.Editable = false;
            this.grvFaLeistung.OptionsCustomization.AllowFilter = false;
            this.grvFaLeistung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvFaLeistung.OptionsNavigation.AutoFocusNewRow = true;
            this.grvFaLeistung.OptionsNavigation.UseTabKey = false;
            this.grvFaLeistung.OptionsView.ColumnAutoWidth = false;
            this.grvFaLeistung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvFaLeistung.OptionsView.ShowGroupPanel = false;
            this.grvFaLeistung.OptionsView.ShowIndicator = false;
            // 
            // colDatumVon
            // 
            this.colDatumVon.Caption = "Eröffnet am";
            this.colDatumVon.FieldName = "DatumVon";
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.Visible = true;
            this.colDatumVon.VisibleIndex = 0;
            // 
            // colGrundEroeffnen
            // 
            this.colGrundEroeffnen.Caption = "Grund";
            this.colGrundEroeffnen.FieldName = "EroeffnungsGrundCode";
            this.colGrundEroeffnen.Name = "colGrundEroeffnen";
            this.colGrundEroeffnen.Visible = true;
            this.colGrundEroeffnen.VisibleIndex = 1;
            this.colGrundEroeffnen.Width = 97;
            // 
            // colDatumBis
            // 
            this.colDatumBis.Caption = "Abgeschlossen am";
            this.colDatumBis.FieldName = "DatumBis";
            this.colDatumBis.Name = "colDatumBis";
            this.colDatumBis.Visible = true;
            this.colDatumBis.VisibleIndex = 2;
            this.colDatumBis.Width = 115;
            // 
            // colGrundAbschluss
            // 
            this.colGrundAbschluss.Caption = "Grund";
            this.colGrundAbschluss.FieldName = "AbschlussGrundCode";
            this.colGrundAbschluss.Name = "colGrundAbschluss";
            this.colGrundAbschluss.Visible = true;
            this.colGrundAbschluss.VisibleIndex = 3;
            this.colGrundAbschluss.Width = 98;
            // 
            // colFP
            // 
            this.colFP.Caption = "Masterbudgets";
            this.colFP.FieldName = "FinanzPlaene";
            this.colFP.Name = "colFP";
            this.colFP.Visible = true;
            this.colFP.VisibleIndex = 4;
            this.colFP.Width = 125;
            // 
            // colBemerkung
            // 
            this.colBemerkung.Caption = "Bemerkungen";
            this.colBemerkung.FieldName = "Bemerkung";
            this.colBemerkung.Name = "colBemerkung";
            this.colBemerkung.Visible = true;
            this.colBemerkung.VisibleIndex = 5;
            this.colBemerkung.Width = 147;
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryFaLeistung;
            this.edtBemerkung.Location = new System.Drawing.Point(8, 128);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(664, 96);
            this.edtBemerkung.TabIndex = 9;
            // 
            // lblFaLeistung
            // 
            this.lblFaLeistung.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblFaLeistung.Location = new System.Drawing.Point(8, 232);
            this.lblFaLeistung.Name = "lblFaLeistung";
            this.lblFaLeistung.Size = new System.Drawing.Size(272, 16);
            this.lblFaLeistung.TabIndex = 10;
            this.lblFaLeistung.Text = "Übersicht über alle Asyl-Fälle dieser Person";
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.DataMember = "DatumVon";
            this.edtDatumVon.DataSource = this.qryFaLeistung;
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(8, 48);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(96, 24);
            this.edtDatumVon.TabIndex = 2;
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.DataMember = "DatumBis";
            this.edtDatumBis.DataSource = this.qryFaLeistung;
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(8, 96);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(96, 24);
            this.edtDatumBis.TabIndex = 6;
            // 
            // lblDatumBis
            // 
            this.lblDatumBis.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblDatumBis.Location = new System.Drawing.Point(8, 80);
            this.lblDatumBis.Name = "lblDatumBis";
            this.lblDatumBis.Size = new System.Drawing.Size(104, 16);
            this.lblDatumBis.TabIndex = 5;
            this.lblDatumBis.Text = "Abgeschlossen am";
            // 
            // lblDatumVon
            // 
            this.lblDatumVon.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblDatumVon.Location = new System.Drawing.Point(8, 32);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(104, 16);
            this.lblDatumVon.TabIndex = 1;
            this.lblDatumVon.Text = "Eröffnet am";
            // 
            // lblEroeffnungsGrundCode
            // 
            this.lblEroeffnungsGrundCode.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblEroeffnungsGrundCode.Location = new System.Drawing.Point(112, 32);
            this.lblEroeffnungsGrundCode.Name = "lblEroeffnungsGrundCode";
            this.lblEroeffnungsGrundCode.Size = new System.Drawing.Size(64, 16);
            this.lblEroeffnungsGrundCode.TabIndex = 3;
            this.lblEroeffnungsGrundCode.Text = "Grund";
            // 
            // lblAbschlussGrundCode
            // 
            this.lblAbschlussGrundCode.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblAbschlussGrundCode.Location = new System.Drawing.Point(112, 80);
            this.lblAbschlussGrundCode.Name = "lblAbschlussGrundCode";
            this.lblAbschlussGrundCode.Size = new System.Drawing.Size(64, 16);
            this.lblAbschlussGrundCode.TabIndex = 7;
            this.lblAbschlussGrundCode.Text = "Grund";
            // 
            // edtAbschlussGrundCode
            // 
            this.edtAbschlussGrundCode.DataMember = "AbschlussGrundCode";
            this.edtAbschlussGrundCode.DataSource = this.qryFaLeistung;
            this.edtAbschlussGrundCode.Location = new System.Drawing.Point(112, 96);
            this.edtAbschlussGrundCode.LOVName = "AyAbschlussgrund";
            this.edtAbschlussGrundCode.Name = "edtAbschlussGrundCode";
            this.edtAbschlussGrundCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAbschlussGrundCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAbschlussGrundCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbschlussGrundCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbschlussGrundCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAbschlussGrundCode.Properties.Appearance.Options.UseFont = true;
            this.edtAbschlussGrundCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAbschlussGrundCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbschlussGrundCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAbschlussGrundCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAbschlussGrundCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtAbschlussGrundCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtAbschlussGrundCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAbschlussGrundCode.Properties.DisplayMember = "Text";
            this.edtAbschlussGrundCode.Properties.NullText = "";
            this.edtAbschlussGrundCode.Properties.ShowFooter = false;
            this.edtAbschlussGrundCode.Properties.ShowHeader = false;
            this.edtAbschlussGrundCode.Properties.ValueMember = "Code";
            this.edtAbschlussGrundCode.Size = new System.Drawing.Size(560, 24);
            this.edtAbschlussGrundCode.TabIndex = 8;
            // 
            // edtEroeffnungsGrundCode
            // 
            this.edtEroeffnungsGrundCode.DataMember = "EroeffnungsGrundCode";
            this.edtEroeffnungsGrundCode.DataSource = this.qryFaLeistung;
            this.edtEroeffnungsGrundCode.Location = new System.Drawing.Point(112, 48);
            this.edtEroeffnungsGrundCode.LOVName = "AyEroeffnungsGrund";
            this.edtEroeffnungsGrundCode.Name = "edtEroeffnungsGrundCode";
            this.edtEroeffnungsGrundCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEroeffnungsGrundCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEroeffnungsGrundCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEroeffnungsGrundCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtEroeffnungsGrundCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEroeffnungsGrundCode.Properties.Appearance.Options.UseFont = true;
            this.edtEroeffnungsGrundCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtEroeffnungsGrundCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtEroeffnungsGrundCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtEroeffnungsGrundCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtEroeffnungsGrundCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtEroeffnungsGrundCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtEroeffnungsGrundCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEroeffnungsGrundCode.Properties.DisplayMember = "Text";
            this.edtEroeffnungsGrundCode.Properties.NullText = "";
            this.edtEroeffnungsGrundCode.Properties.ShowFooter = false;
            this.edtEroeffnungsGrundCode.Properties.ShowHeader = false;
            this.edtEroeffnungsGrundCode.Properties.ValueMember = "Code";
            this.edtEroeffnungsGrundCode.Size = new System.Drawing.Size(560, 24);
            this.edtEroeffnungsGrundCode.TabIndex = 4;
            // 
            // lblTitel
            // 
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(32, 8);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(640, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Asyl";
            // 
            // picTitel
            // 
            this.picTitel.Location = new System.Drawing.Point(8, 8);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 55;
            this.picTitel.TabStop = false;
            // 
            // edtGemeindeCode
            // 
            this.edtGemeindeCode.AllowNull = false;
            this.edtGemeindeCode.DataMember = "GemeindeCode";
            this.edtGemeindeCode.DataSource = this.qryFaLeistung;
            this.edtGemeindeCode.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtGemeindeCode.Location = new System.Drawing.Point(104, 496);
            this.edtGemeindeCode.LOVFilter = "(Value3 IS NULL OR \',\' + Value3 + \',\' LIKE \'%,A,%\')";
            this.edtGemeindeCode.LOVFilterWhereAppend = true;
            this.edtGemeindeCode.LOVName = "GemeindeSozialdienst";
            this.edtGemeindeCode.Name = "edtGemeindeCode";
            this.edtGemeindeCode.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtGemeindeCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGemeindeCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGemeindeCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtGemeindeCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGemeindeCode.Properties.Appearance.Options.UseFont = true;
            this.edtGemeindeCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtGemeindeCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtGemeindeCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtGemeindeCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtGemeindeCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtGemeindeCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtGemeindeCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGemeindeCode.Properties.NullText = "";
            this.edtGemeindeCode.Properties.ShowFooter = false;
            this.edtGemeindeCode.Properties.ShowHeader = false;
            this.edtGemeindeCode.Size = new System.Drawing.Size(280, 24);
            this.edtGemeindeCode.TabIndex = 504;
            // 
            // lblGemeindeCode
            // 
            this.lblGemeindeCode.ForeColor = System.Drawing.Color.Black;
            this.lblGemeindeCode.Location = new System.Drawing.Point(8, 496);
            this.lblGemeindeCode.Name = "lblGemeindeCode";
            this.lblGemeindeCode.Size = new System.Drawing.Size(126, 24);
            this.lblGemeindeCode.TabIndex = 505;
            this.lblGemeindeCode.Text = "zust. Gemeinde";
            // 
            // CtlAyFall
            // 
            this.ActiveSQLQuery = this.qryFaLeistung;
            this.Controls.Add(this.edtGemeindeCode);
            this.Controls.Add(this.lblGemeindeCode);
            this.Controls.Add(this.picTitel);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.edtEroeffnungsGrundCode);
            this.Controls.Add(this.edtAbschlussGrundCode);
            this.Controls.Add(this.lblAbschlussGrundCode);
            this.Controls.Add(this.lblEroeffnungsGrundCode);
            this.Controls.Add(this.lblDatumVon);
            this.Controls.Add(this.lblDatumBis);
            this.Controls.Add(this.edtDatumBis);
            this.Controls.Add(this.edtDatumVon);
            this.Controls.Add(this.lblFaLeistung);
            this.Controls.Add(this.edtBemerkung);
            this.Controls.Add(this.grdFaLeistung);
            this.Name = "CtlAyFall";
            this.Size = new System.Drawing.Size(680, 544);
            ((System.ComponentModel.ISupportInitialize)(this.grdFaLeistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLeistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFaLeistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaLeistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffnungsGrundCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussGrundCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrundCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrundCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungsGrundCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungsGrundCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGemeindeCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGemeindeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGemeindeCode)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblDatumBis;
        private KiSS4.Gui.KissLabel lblDatumVon;
        private KiSS4.Gui.KissLabel lblEroeffnungsGrundCode;
        private KiSS4.Gui.KissLabel lblAbschlussGrundCode;
        private KiSS4.Gui.KissLabel lblFaLeistung;
        private KiSS4.Gui.KissGrid grdFaLeistung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvFaLeistung;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colGrundEroeffnen;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colBemerkung;
        private DevExpress.XtraGrid.Columns.GridColumn colFP;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.Gui.KissLookUpEdit edtAbschlussGrundCode;
        private KiSS4.Gui.KissLookUpEdit edtEroeffnungsGrundCode;
        private DevExpress.XtraGrid.Columns.GridColumn colGrundAbschluss;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.DB.SqlQuery qryFaLeistung;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissLookUpEdit edtGemeindeCode;
        private KiSS4.Gui.KissLabel lblGemeindeCode;
    }
}
