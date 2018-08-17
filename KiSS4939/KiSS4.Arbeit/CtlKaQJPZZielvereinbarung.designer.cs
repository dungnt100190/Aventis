namespace KiSS4.Arbeit
{
    partial class CtlKaQJPZZielvereinbarung
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKaQJPZZielvereinbarung));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.picTitle = new System.Windows.Forms.PictureBox();
            this.lblTitel = new System.Windows.Forms.Label();
            this.grdZielvereinbarung = new KiSS4.Gui.KissGrid();
            this.qryZielvereinbarung = new KiSS4.DB.SqlQuery(this.components);
            this.gvZielvereinbarung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colZielDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVereinbartesZiel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colErreichenBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeurteilung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumBeurteilung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.datZielDatum = new KiSS4.Gui.KissDateEdit();
            this.lblZielDatum = new System.Windows.Forms.Label();
            this.memVereinbartesZiel = new KiSS4.Gui.KissMemoEdit();
            this.lblVereinbartesZiel = new KiSS4.Gui.KissLabel();
            this.memErreichenBis = new KiSS4.Gui.KissMemoEdit();
            this.lblErreichenBis = new KiSS4.Gui.KissLabel();
            this.memKritereinPruefen = new KiSS4.Gui.KissMemoEdit();
            this.lblKriterienPruefen = new KiSS4.Gui.KissLabel();
            this.rgBeurteilung = new KiSS4.Gui.KissRadioGroup(this.components);
            this.lblBeurteilung = new System.Windows.Forms.Label();
            this.docZielvereinbarung = new KiSS4.Dokument.XDokument();
            this.lblDatBeurteilung = new KiSS4.Gui.KissLabel();
            this.datBeurteilung = new KiSS4.Gui.KissDateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZielvereinbarung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZielvereinbarung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvZielvereinbarung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datZielDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memVereinbartesZiel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVereinbartesZiel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memErreichenBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErreichenBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memKritereinPruefen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKriterienPruefen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgBeurteilung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgBeurteilung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docZielvereinbarung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatBeurteilung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datBeurteilung.Properties)).BeginInit();
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
            // grdZielvereinbarung
            // 
            this.grdZielvereinbarung.DataSource = this.qryZielvereinbarung;
            // 
            // 
            // 
            this.grdZielvereinbarung.EmbeddedNavigator.Name = "";
            this.grdZielvereinbarung.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdZielvereinbarung.Location = new System.Drawing.Point(5, 45);
            this.grdZielvereinbarung.MainView = this.gvZielvereinbarung;
            this.grdZielvereinbarung.Name = "grdZielvereinbarung";
            this.grdZielvereinbarung.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemMemoEdit1});
            this.grdZielvereinbarung.Size = new System.Drawing.Size(750, 135);
            this.grdZielvereinbarung.TabIndex = 102;
            this.grdZielvereinbarung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvZielvereinbarung});
            // 
            // qryZielvereinbarung
            // 
            this.qryZielvereinbarung.CanDelete = true;
            this.qryZielvereinbarung.CanInsert = true;
            this.qryZielvereinbarung.CanUpdate = true;
            this.qryZielvereinbarung.HostControl = this;
            this.qryZielvereinbarung.IsIdentityInsert = false;
            this.qryZielvereinbarung.TableName = "KaQJPZZielvereinbarung";
            this.qryZielvereinbarung.AfterInsert += new System.EventHandler(this.qryZielvereinbarung_AfterInsert);
            this.qryZielvereinbarung.AfterPost += new System.EventHandler(this.qryZielvereinbarung_AfterPost);
            // 
            // gvZielvereinbarung
            // 
            this.gvZielvereinbarung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gvZielvereinbarung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvZielvereinbarung.Appearance.Empty.Options.UseBackColor = true;
            this.gvZielvereinbarung.Appearance.Empty.Options.UseFont = true;
            this.gvZielvereinbarung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvZielvereinbarung.Appearance.EvenRow.Options.UseFont = true;
            this.gvZielvereinbarung.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvZielvereinbarung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvZielvereinbarung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gvZielvereinbarung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvZielvereinbarung.Appearance.FocusedCell.Options.UseFont = true;
            this.gvZielvereinbarung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvZielvereinbarung.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvZielvereinbarung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvZielvereinbarung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gvZielvereinbarung.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvZielvereinbarung.Appearance.FocusedRow.Options.UseFont = true;
            this.gvZielvereinbarung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvZielvereinbarung.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.gvZielvereinbarung.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.gvZielvereinbarung.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gvZielvereinbarung.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gvZielvereinbarung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gvZielvereinbarung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gvZielvereinbarung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gvZielvereinbarung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvZielvereinbarung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvZielvereinbarung.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvZielvereinbarung.Appearance.GroupRow.Options.UseFont = true;
            this.gvZielvereinbarung.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvZielvereinbarung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gvZielvereinbarung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gvZielvereinbarung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvZielvereinbarung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvZielvereinbarung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gvZielvereinbarung.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvZielvereinbarung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gvZielvereinbarung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvZielvereinbarung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvZielvereinbarung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvZielvereinbarung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvZielvereinbarung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvZielvereinbarung.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gvZielvereinbarung.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvZielvereinbarung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvZielvereinbarung.Appearance.OddRow.Options.UseFont = true;
            this.gvZielvereinbarung.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gvZielvereinbarung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvZielvereinbarung.Appearance.Row.Options.UseBackColor = true;
            this.gvZielvereinbarung.Appearance.Row.Options.UseFont = true;
            this.gvZielvereinbarung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvZielvereinbarung.Appearance.SelectedRow.Options.UseFont = true;
            this.gvZielvereinbarung.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gvZielvereinbarung.Appearance.VertLine.Options.UseBackColor = true;
            this.gvZielvereinbarung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gvZielvereinbarung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colZielDatum,
            this.colVereinbartesZiel,
            this.colErreichenBis,
            this.colBeurteilung,
            this.colDatumBeurteilung});
            this.gvZielvereinbarung.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gvZielvereinbarung.GridControl = this.grdZielvereinbarung;
            this.gvZielvereinbarung.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.gvZielvereinbarung.Name = "gvZielvereinbarung";
            this.gvZielvereinbarung.OptionsBehavior.Editable = false;
            this.gvZielvereinbarung.OptionsCustomization.AllowFilter = false;
            this.gvZielvereinbarung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gvZielvereinbarung.OptionsNavigation.AutoFocusNewRow = true;
            this.gvZielvereinbarung.OptionsNavigation.UseTabKey = false;
            this.gvZielvereinbarung.OptionsView.ColumnAutoWidth = false;
            this.gvZielvereinbarung.OptionsView.RowAutoHeight = true;
            this.gvZielvereinbarung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvZielvereinbarung.OptionsView.ShowGroupPanel = false;
            this.gvZielvereinbarung.OptionsView.ShowIndicator = false;
            // 
            // colZielDatum
            // 
            this.colZielDatum.Caption = "Datum Ziel";
            this.colZielDatum.FieldName = "ZielDatum";
            this.colZielDatum.Name = "colZielDatum";
            this.colZielDatum.Visible = true;
            this.colZielDatum.VisibleIndex = 0;
            this.colZielDatum.Width = 80;
            // 
            // colVereinbartesZiel
            // 
            this.colVereinbartesZiel.Caption = "Ziel";
            this.colVereinbartesZiel.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colVereinbartesZiel.FieldName = "VereinbartesZiel";
            this.colVereinbartesZiel.Name = "colVereinbartesZiel";
            this.colVereinbartesZiel.Visible = true;
            this.colVereinbartesZiel.VisibleIndex = 1;
            this.colVereinbartesZiel.Width = 300;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            this.repositoryItemMemoEdit1.ReadOnly = true;
            // 
            // colErreichenBis
            // 
            this.colErreichenBis.Caption = "zu erreichen bis";
            this.colErreichenBis.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colErreichenBis.FieldName = "ErreichenBis";
            this.colErreichenBis.Name = "colErreichenBis";
            this.colErreichenBis.Visible = true;
            this.colErreichenBis.VisibleIndex = 2;
            this.colErreichenBis.Width = 170;
            // 
            // colBeurteilung
            // 
            this.colBeurteilung.Caption = "Beurteilung";
            this.colBeurteilung.FieldName = "Beurteilung";
            this.colBeurteilung.Name = "colBeurteilung";
            this.colBeurteilung.OptionsColumn.AllowEdit = false;
            this.colBeurteilung.OptionsColumn.ReadOnly = true;
            this.colBeurteilung.Visible = true;
            this.colBeurteilung.VisibleIndex = 3;
            this.colBeurteilung.Width = 100;
            // 
            // colDatumBeurteilung
            // 
            this.colDatumBeurteilung.Caption = "Datum Beurt.";
            this.colDatumBeurteilung.FieldName = "DatumBeurteilung";
            this.colDatumBeurteilung.Name = "colDatumBeurteilung";
            this.colDatumBeurteilung.Visible = true;
            this.colDatumBeurteilung.VisibleIndex = 4;
            this.colDatumBeurteilung.Width = 88;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // datZielDatum
            // 
            this.datZielDatum.DataMember = "ZielDatum";
            this.datZielDatum.DataSource = this.qryZielvereinbarung;
            this.datZielDatum.EditValue = null;
            this.datZielDatum.Location = new System.Drawing.Point(112, 190);
            this.datZielDatum.Name = "datZielDatum";
            this.datZielDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datZielDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.datZielDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datZielDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datZielDatum.Properties.Appearance.Options.UseBackColor = true;
            this.datZielDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.datZielDatum.Properties.Appearance.Options.UseFont = true;
            this.datZielDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.datZielDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datZielDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.datZielDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datZielDatum.Properties.ShowToday = false;
            this.datZielDatum.Size = new System.Drawing.Size(89, 24);
            this.datZielDatum.TabIndex = 0;
            // 
            // lblZielDatum
            // 
            this.lblZielDatum.Location = new System.Drawing.Point(5, 190);
            this.lblZielDatum.Name = "lblZielDatum";
            this.lblZielDatum.Size = new System.Drawing.Size(74, 24);
            this.lblZielDatum.TabIndex = 104;
            this.lblZielDatum.Text = "Datum Ziel";
            this.lblZielDatum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // memVereinbartesZiel
            // 
            this.memVereinbartesZiel.DataMember = "VereinbartesZiel";
            this.memVereinbartesZiel.DataSource = this.qryZielvereinbarung;
            this.memVereinbartesZiel.Location = new System.Drawing.Point(5, 250);
            this.memVereinbartesZiel.Name = "memVereinbartesZiel";
            this.memVereinbartesZiel.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memVereinbartesZiel.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memVereinbartesZiel.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memVereinbartesZiel.Properties.Appearance.Options.UseBackColor = true;
            this.memVereinbartesZiel.Properties.Appearance.Options.UseBorderColor = true;
            this.memVereinbartesZiel.Properties.Appearance.Options.UseFont = true;
            this.memVereinbartesZiel.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memVereinbartesZiel.Size = new System.Drawing.Size(300, 80);
            this.memVereinbartesZiel.TabIndex = 1;
            // 
            // lblVereinbartesZiel
            // 
            this.lblVereinbartesZiel.ForeColor = System.Drawing.Color.Black;
            this.lblVereinbartesZiel.Location = new System.Drawing.Point(5, 220);
            this.lblVereinbartesZiel.Name = "lblVereinbartesZiel";
            this.lblVereinbartesZiel.Size = new System.Drawing.Size(110, 24);
            this.lblVereinbartesZiel.TabIndex = 570;
            this.lblVereinbartesZiel.Text = "Vereinbartes Ziel";
            this.lblVereinbartesZiel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // memErreichenBis
            // 
            this.memErreichenBis.DataMember = "ErreichenBis";
            this.memErreichenBis.DataSource = this.qryZielvereinbarung;
            this.memErreichenBis.Location = new System.Drawing.Point(310, 250);
            this.memErreichenBis.Name = "memErreichenBis";
            this.memErreichenBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memErreichenBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memErreichenBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memErreichenBis.Properties.Appearance.Options.UseBackColor = true;
            this.memErreichenBis.Properties.Appearance.Options.UseBorderColor = true;
            this.memErreichenBis.Properties.Appearance.Options.UseFont = true;
            this.memErreichenBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memErreichenBis.Size = new System.Drawing.Size(160, 80);
            this.memErreichenBis.TabIndex = 2;
            // 
            // lblErreichenBis
            // 
            this.lblErreichenBis.ForeColor = System.Drawing.Color.Black;
            this.lblErreichenBis.Location = new System.Drawing.Point(310, 220);
            this.lblErreichenBis.Name = "lblErreichenBis";
            this.lblErreichenBis.Size = new System.Drawing.Size(110, 24);
            this.lblErreichenBis.TabIndex = 572;
            this.lblErreichenBis.Text = "zu erreichen bis";
            this.lblErreichenBis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // memKritereinPruefen
            // 
            this.memKritereinPruefen.DataMember = "KriterienPruefen";
            this.memKritereinPruefen.DataSource = this.qryZielvereinbarung;
            this.memKritereinPruefen.Location = new System.Drawing.Point(475, 250);
            this.memKritereinPruefen.Name = "memKritereinPruefen";
            this.memKritereinPruefen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memKritereinPruefen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memKritereinPruefen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memKritereinPruefen.Properties.Appearance.Options.UseBackColor = true;
            this.memKritereinPruefen.Properties.Appearance.Options.UseBorderColor = true;
            this.memKritereinPruefen.Properties.Appearance.Options.UseFont = true;
            this.memKritereinPruefen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memKritereinPruefen.Size = new System.Drawing.Size(275, 80);
            this.memKritereinPruefen.TabIndex = 3;
            // 
            // lblKriterienPruefen
            // 
            this.lblKriterienPruefen.ForeColor = System.Drawing.Color.Black;
            this.lblKriterienPruefen.Location = new System.Drawing.Point(475, 220);
            this.lblKriterienPruefen.Name = "lblKriterienPruefen";
            this.lblKriterienPruefen.Size = new System.Drawing.Size(130, 24);
            this.lblKriterienPruefen.TabIndex = 574;
            this.lblKriterienPruefen.Text = "Kriterien Überprüfung";
            this.lblKriterienPruefen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rgBeurteilung
            // 
            this.rgBeurteilung.DataMember = "BeurteilungID";
            this.rgBeurteilung.DataSource = this.qryZielvereinbarung;
            this.rgBeurteilung.EditValue = "";
            this.rgBeurteilung.Location = new System.Drawing.Point(5, 360);
            this.rgBeurteilung.LookupSQL = null;
            this.rgBeurteilung.LOVFilter = null;
            this.rgBeurteilung.LOVName = null;
            this.rgBeurteilung.Name = "rgBeurteilung";
            this.rgBeurteilung.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgBeurteilung.Properties.Appearance.Options.UseBackColor = true;
            this.rgBeurteilung.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.rgBeurteilung.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.rgBeurteilung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgBeurteilung.Properties.Columns = 1;
            this.rgBeurteilung.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "erreicht"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "teilweise erreicht"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(3, "nicht erreicht")});
            this.rgBeurteilung.Size = new System.Drawing.Size(135, 76);
            this.rgBeurteilung.TabIndex = 4;
            // 
            // lblBeurteilung
            // 
            this.lblBeurteilung.Location = new System.Drawing.Point(5, 340);
            this.lblBeurteilung.Name = "lblBeurteilung";
            this.lblBeurteilung.Size = new System.Drawing.Size(90, 24);
            this.lblBeurteilung.TabIndex = 576;
            this.lblBeurteilung.Text = "Beurteilung";
            this.lblBeurteilung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // docZielvereinbarung
            // 
            this.docZielvereinbarung.Context = "KaQJPZZielvereinbarung";
            this.docZielvereinbarung.DataMember = "ZielvereinbarungDokID";
            this.docZielvereinbarung.DataSource = this.qryZielvereinbarung;
            this.docZielvereinbarung.Location = new System.Drawing.Point(5, 497);
            this.docZielvereinbarung.Name = "docZielvereinbarung";
            this.docZielvereinbarung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docZielvereinbarung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docZielvereinbarung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docZielvereinbarung.Properties.Appearance.Options.UseBackColor = true;
            this.docZielvereinbarung.Properties.Appearance.Options.UseBorderColor = true;
            this.docZielvereinbarung.Properties.Appearance.Options.UseFont = true;
            this.docZielvereinbarung.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docZielvereinbarung.Properties.AppearanceDisabled.Options.UseFont = true;
            this.docZielvereinbarung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.docZielvereinbarung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docZielvereinbarung.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docZielvereinbarung.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docZielvereinbarung.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docZielvereinbarung.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "Dokument importieren")});
            this.docZielvereinbarung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docZielvereinbarung.Properties.ReadOnly = true;
            this.docZielvereinbarung.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docZielvereinbarung.Size = new System.Drawing.Size(136, 24);
            this.docZielvereinbarung.TabIndex = 5;
            // 
            // lblDatBeurteilung
            // 
            this.lblDatBeurteilung.Location = new System.Drawing.Point(5, 439);
            this.lblDatBeurteilung.Name = "lblDatBeurteilung";
            this.lblDatBeurteilung.Size = new System.Drawing.Size(101, 24);
            this.lblDatBeurteilung.TabIndex = 627;
            this.lblDatBeurteilung.Text = "Datum Beurteilung";
            // 
            // datBeurteilung
            // 
            this.datBeurteilung.DataMember = "DatumBeurteilung";
            this.datBeurteilung.DataSource = this.qryZielvereinbarung;
            this.datBeurteilung.EditValue = null;
            this.datBeurteilung.Location = new System.Drawing.Point(112, 439);
            this.datBeurteilung.Name = "datBeurteilung";
            this.datBeurteilung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datBeurteilung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.datBeurteilung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datBeurteilung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datBeurteilung.Properties.Appearance.Options.UseBackColor = true;
            this.datBeurteilung.Properties.Appearance.Options.UseBorderColor = true;
            this.datBeurteilung.Properties.Appearance.Options.UseFont = true;
            this.datBeurteilung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.datBeurteilung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datBeurteilung.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.datBeurteilung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datBeurteilung.Properties.ShowToday = false;
            this.datBeurteilung.Size = new System.Drawing.Size(89, 24);
            this.datBeurteilung.TabIndex = 626;
            // 
            // CtlKaQJPZZielvereinbarung
            // 
            this.ActiveSQLQuery = this.qryZielvereinbarung;
            this.AutoScroll = true;
            this.Controls.Add(this.rgBeurteilung);
            this.Controls.Add(this.lblDatBeurteilung);
            this.Controls.Add(this.datBeurteilung);
            this.Controls.Add(this.docZielvereinbarung);
            this.Controls.Add(this.lblBeurteilung);
            this.Controls.Add(this.memKritereinPruefen);
            this.Controls.Add(this.lblKriterienPruefen);
            this.Controls.Add(this.memErreichenBis);
            this.Controls.Add(this.lblErreichenBis);
            this.Controls.Add(this.memVereinbartesZiel);
            this.Controls.Add(this.lblVereinbartesZiel);
            this.Controls.Add(this.datZielDatum);
            this.Controls.Add(this.lblZielDatum);
            this.Controls.Add(this.grdZielvereinbarung);
            this.Controls.Add(this.picTitle);
            this.Controls.Add(this.lblTitel);
            this.Name = "CtlKaQJPZZielvereinbarung";
            this.Size = new System.Drawing.Size(765, 524);
            this.Load += new System.EventHandler(this.CtlKaQJPZZielvereinbarung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZielvereinbarung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZielvereinbarung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvZielvereinbarung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datZielDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memVereinbartesZiel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVereinbartesZiel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memErreichenBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErreichenBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memKritereinPruefen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKriterienPruefen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgBeurteilung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgBeurteilung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docZielvereinbarung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatBeurteilung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datBeurteilung.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitel;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colZielDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colVereinbartesZiel;
        private DevExpress.XtraGrid.Columns.GridColumn colBeurteilung;
        private DevExpress.XtraGrid.Columns.GridColumn colErreichenBis;
        private KiSS4.DB.SqlQuery qryZielvereinbarung;
        private System.Windows.Forms.Label lblZielDatum;
        private KiSS4.Gui.KissLabel lblVereinbartesZiel;
        private KiSS4.Gui.KissLabel lblErreichenBis;
        private KiSS4.Gui.KissLabel lblKriterienPruefen;
        private KiSS4.Gui.KissRadioGroup rgBeurteilung;
        private System.Windows.Forms.Label lblBeurteilung;
        private System.Windows.Forms.PictureBox picTitle;
        private KiSS4.Gui.KissGrid grdZielvereinbarung;
        private DevExpress.XtraGrid.Views.Grid.GridView gvZielvereinbarung;
        private KiSS4.Gui.KissDateEdit datZielDatum;
        private KiSS4.Gui.KissMemoEdit memVereinbartesZiel;
        private KiSS4.Gui.KissMemoEdit memErreichenBis;
        private KiSS4.Gui.KissMemoEdit memKritereinPruefen;
        private KiSS4.Dokument.XDokument docZielvereinbarung;
        private Gui.KissLabel lblDatBeurteilung;
        private Gui.KissDateEdit datBeurteilung;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumBeurteilung;
    }
}