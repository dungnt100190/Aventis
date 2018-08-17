namespace KiSS4.Arbeit
{
    partial class CtlKaQJPZBerichte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKaQJPZBerichte));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.picTitle = new System.Windows.Forms.PictureBox();
            this.lblTitel = new System.Windows.Forms.Label();
            this.grdIntakegespraeche = new KiSS4.Gui.KissGrid();
            this.qryKaQJPZBericht = new KiSS4.DB.SqlQuery(this.components);
            this.grvIntakegespraech = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBericht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtPraesenz = new KiSS4.Gui.KissLookUpEdit();
            this.lblBericht = new KiSS4.Gui.KissLabel();
            this.lblDatum = new KiSS4.Gui.KissLabel();
            this.edtDatum = new KiSS4.Gui.KissDateEdit();
            this.edtDocument = new KiSS4.Dokument.XDokument();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIntakegespraeche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKaQJPZBericht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvIntakegespraech)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPraesenz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPraesenz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBericht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDocument.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // picTitle
            // 
            this.picTitle.Image = ((System.Drawing.Image)(resources.GetObject("picTitle.Image")));
            this.picTitle.Location = new System.Drawing.Point(10, 9);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(25, 20);
            this.picTitle.TabIndex = 23;
            this.picTitle.TabStop = false;
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblTitel.ForeColor = System.Drawing.Color.Black;
            this.lblTitel.Location = new System.Drawing.Point(35, 10);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(31, 15);
            this.lblTitel.TabIndex = 24;
            this.lblTitel.Text = "Titel";
            // 
            // grdIntakegespraeche
            // 
            this.grdIntakegespraeche.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdIntakegespraeche.DataSource = this.qryKaQJPZBericht;
            // 
            // 
            // 
            this.grdIntakegespraeche.EmbeddedNavigator.Name = "";
            this.grdIntakegespraeche.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdIntakegespraeche.Location = new System.Drawing.Point(10, 40);
            this.grdIntakegespraeche.MainView = this.grvIntakegespraech;
            this.grdIntakegespraeche.Name = "grdIntakegespraeche";
            this.grdIntakegespraeche.Size = new System.Drawing.Size(893, 375);
            this.grdIntakegespraeche.TabIndex = 32;
            this.grdIntakegespraeche.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvIntakegespraech});
            // 
            // qryKaQJPZBericht
            // 
            this.qryKaQJPZBericht.CanDelete = true;
            this.qryKaQJPZBericht.CanInsert = true;
            this.qryKaQJPZBericht.CanUpdate = true;
            this.qryKaQJPZBericht.HostControl = this;
            this.qryKaQJPZBericht.IsIdentityInsert = false;
            this.qryKaQJPZBericht.SelectStatement = resources.GetString("qryKaQJPZBericht.SelectStatement");
            this.qryKaQJPZBericht.TableName = "KaQJPZBericht";
            this.qryKaQJPZBericht.AfterInsert += new System.EventHandler(this.qryKaQJPZBericht_AfterInsert);
            // 
            // grvIntakegespraech
            // 
            this.grvIntakegespraech.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvIntakegespraech.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvIntakegespraech.Appearance.Empty.Options.UseBackColor = true;
            this.grvIntakegespraech.Appearance.Empty.Options.UseFont = true;
            this.grvIntakegespraech.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvIntakegespraech.Appearance.EvenRow.Options.UseFont = true;
            this.grvIntakegespraech.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvIntakegespraech.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvIntakegespraech.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvIntakegespraech.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvIntakegespraech.Appearance.FocusedCell.Options.UseFont = true;
            this.grvIntakegespraech.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvIntakegespraech.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvIntakegespraech.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvIntakegespraech.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvIntakegespraech.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvIntakegespraech.Appearance.FocusedRow.Options.UseFont = true;
            this.grvIntakegespraech.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvIntakegespraech.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvIntakegespraech.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvIntakegespraech.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvIntakegespraech.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvIntakegespraech.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvIntakegespraech.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvIntakegespraech.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvIntakegespraech.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvIntakegespraech.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvIntakegespraech.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvIntakegespraech.Appearance.GroupRow.Options.UseFont = true;
            this.grvIntakegespraech.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvIntakegespraech.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvIntakegespraech.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvIntakegespraech.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvIntakegespraech.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvIntakegespraech.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvIntakegespraech.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvIntakegespraech.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvIntakegespraech.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvIntakegespraech.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvIntakegespraech.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvIntakegespraech.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvIntakegespraech.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvIntakegespraech.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvIntakegespraech.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvIntakegespraech.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvIntakegespraech.Appearance.OddRow.Options.UseFont = true;
            this.grvIntakegespraech.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvIntakegespraech.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvIntakegespraech.Appearance.Row.Options.UseBackColor = true;
            this.grvIntakegespraech.Appearance.Row.Options.UseFont = true;
            this.grvIntakegespraech.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvIntakegespraech.Appearance.SelectedRow.Options.UseFont = true;
            this.grvIntakegespraech.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvIntakegespraech.Appearance.VertLine.Options.UseBackColor = true;
            this.grvIntakegespraech.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvIntakegespraech.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatum,
            this.colBericht});
            this.grvIntakegespraech.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvIntakegespraech.GridControl = this.grdIntakegespraeche;
            this.grvIntakegespraech.Name = "grvIntakegespraech";
            this.grvIntakegespraech.OptionsBehavior.Editable = false;
            this.grvIntakegespraech.OptionsCustomization.AllowFilter = false;
            this.grvIntakegespraech.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvIntakegespraech.OptionsNavigation.AutoFocusNewRow = true;
            this.grvIntakegespraech.OptionsNavigation.UseTabKey = false;
            this.grvIntakegespraech.OptionsView.ColumnAutoWidth = false;
            this.grvIntakegespraech.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvIntakegespraech.OptionsView.ShowGroupPanel = false;
            this.grvIntakegespraech.OptionsView.ShowIndicator = false;
            // 
            // colDatum
            // 
            this.colDatum.Caption = "Datum";
            this.colDatum.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.colDatum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDatum.FieldName = "Datum";
            this.colDatum.Name = "colDatum";
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 0;
            this.colDatum.Width = 98;
            // 
            // colBericht
            // 
            this.colBericht.Caption = "Bericht";
            this.colBericht.FieldName = "KaQJPZBerichtTypCode";
            this.colBericht.Name = "colBericht";
            this.colBericht.Visible = true;
            this.colBericht.VisibleIndex = 1;
            this.colBericht.Width = 150;
            // 
            // edtPraesenz
            // 
            this.edtPraesenz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtPraesenz.DataMember = "KaQJPZBerichtTypCode";
            this.edtPraesenz.DataSource = this.qryKaQJPZBericht;
            this.edtPraesenz.Location = new System.Drawing.Point(204, 421);
            this.edtPraesenz.LOVName = "KaQJPZBerichtTyp";
            this.edtPraesenz.Name = "edtPraesenz";
            this.edtPraesenz.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPraesenz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPraesenz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPraesenz.Properties.Appearance.Options.UseBackColor = true;
            this.edtPraesenz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPraesenz.Properties.Appearance.Options.UseFont = true;
            this.edtPraesenz.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtPraesenz.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtPraesenz.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtPraesenz.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtPraesenz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtPraesenz.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtPraesenz.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPraesenz.Properties.NullText = "";
            this.edtPraesenz.Properties.ShowFooter = false;
            this.edtPraesenz.Properties.ShowHeader = false;
            this.edtPraesenz.Size = new System.Drawing.Size(208, 24);
            this.edtPraesenz.TabIndex = 39;
            // 
            // lblBericht
            // 
            this.lblBericht.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBericht.Location = new System.Drawing.Point(157, 421);
            this.lblBericht.Name = "lblBericht";
            this.lblBericht.Size = new System.Drawing.Size(41, 24);
            this.lblBericht.TabIndex = 38;
            this.lblBericht.Text = "Bericht";
            // 
            // lblDatum
            // 
            this.lblDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDatum.Location = new System.Drawing.Point(10, 421);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(40, 24);
            this.lblDatum.TabIndex = 36;
            this.lblDatum.Text = "Datum";
            // 
            // edtDatum
            // 
            this.edtDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDatum.DataMember = "Datum";
            this.edtDatum.DataSource = this.qryKaQJPZBericht;
            this.edtDatum.EditValue = null;
            this.edtDatum.Location = new System.Drawing.Point(52, 421);
            this.edtDatum.Name = "edtDatum";
            this.edtDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatum.Properties.Appearance.Options.UseFont = true;
            this.edtDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatum.Properties.ShowToday = false;
            this.edtDatum.Size = new System.Drawing.Size(100, 24);
            this.edtDatum.TabIndex = 37;
            // 
            // edtDocument
            // 
            this.edtDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDocument.Context = "KaQJPZBericht";
            this.edtDocument.DataMember = "DocumentID";
            this.edtDocument.DataSource = this.qryKaQJPZBericht;
            this.edtDocument.Location = new System.Drawing.Point(417, 421);
            this.edtDocument.Name = "edtDocument";
            this.edtDocument.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDocument.Properties.Appearance.Options.UseBackColor = true;
            this.edtDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDocument.Properties.Appearance.Options.UseFont = true;
            this.edtDocument.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDocument.Properties.AppearanceDisabled.Options.UseFont = true;
            this.edtDocument.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocument.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocument.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocument.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "Dokument importieren")});
            this.edtDocument.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDocument.Properties.ReadOnly = true;
            this.edtDocument.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtDocument.Size = new System.Drawing.Size(136, 24);
            this.edtDocument.TabIndex = 40;
            // 
            // CtlKaQJPZBerichte
            // 
            this.ActiveSQLQuery = this.qryKaQJPZBericht;
            this.AutoScroll = true;
            this.Controls.Add(this.edtDocument);
            this.Controls.Add(this.edtPraesenz);
            this.Controls.Add(this.lblBericht);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.edtDatum);
            this.Controls.Add(this.grdIntakegespraeche);
            this.Controls.Add(this.picTitle);
            this.Controls.Add(this.lblTitel);
            this.Name = "CtlKaQJPZBerichte";
            this.Size = new System.Drawing.Size(906, 451);
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIntakegespraeche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKaQJPZBericht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvIntakegespraech)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPraesenz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPraesenz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBericht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDocument.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitel;
        private System.Windows.Forms.PictureBox picTitle;
        private Gui.KissGrid grdIntakegespraeche;
        private DevExpress.XtraGrid.Views.Grid.GridView grvIntakegespraech;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colBericht;
        private Gui.KissLookUpEdit edtPraesenz;
        private Gui.KissLabel lblBericht;
        private Gui.KissLabel lblDatum;
        private Gui.KissDateEdit edtDatum;
        private Dokument.XDokument edtDocument;
        private DB.SqlQuery qryKaQJPZBericht;
    }
}