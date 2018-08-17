namespace KiSS4.Inkasso
{
    partial class CtlIkKontoauszug
    {
        #region Dispose

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if ((components != null))
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlIkKontoauszug));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panTitle = new System.Windows.Forms.Panel();
            this.edtSaldovortrag = new KiSS4.Gui.KissCheckEdit();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.lblSchuldner = new KiSS4.Gui.KissLabel();
            this.lblBuchungenVon = new KiSS4.Gui.KissLabel();
            this.edtBuchungenVon = new KiSS4.Gui.KissDateEdit();
            this.lblBuchungenBis = new KiSS4.Gui.KissLabel();
            this.edtBuchungenBis = new KiSS4.Gui.KissDateEdit();
            this.lblGlaeubiger = new KiSS4.Gui.KissLabel();
            this.edtGlaeubiger = new KiSS4.Gui.KissLookUpEdit();
            this.qryGlaeubigerSuchen = new KiSS4.DB.SqlQuery(this.components);
            this.lblForderungsart = new KiSS4.Gui.KissLabel();
            this.edtForderungsart = new KiSS4.Gui.KissLookUpEdit();
            this.btnRefreshSearch = new KiSS4.Gui.KissButton();
            this.btnSearchAll = new KiSS4.Gui.KissButton();
            this.grdKontoauszug = new KiSS4.Gui.KissGrid();
            this.qryKontoauszug = new KiSS4.DB.SqlQuery(this.components);
            this.grvKontoauszug = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumForderung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlaeubiger = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBemerkung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoll = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHaben = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaldo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cedGlaeubiger = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.btnNeueZahlung = new KiSS4.Gui.KissButton();
            this.btnZahlungsdetail = new KiSS4.Gui.KissButton();
            this.lblSchuldnerPerson = new KiSS4.Gui.KissLabel();
            this.edtVerdichtet = new KiSS4.Gui.KissCheckEdit();
            this.panTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtSaldovortrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSchuldner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungenVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungenVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungenBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungenBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGlaeubiger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGlaeubiger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGlaeubiger.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryGlaeubigerSuchen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblForderungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtForderungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtForderungsart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKontoauszug)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKontoauszug)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKontoauszug)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cedGlaeubiger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSchuldnerPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerdichtet.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panTitle
            // 
            this.panTitle.Controls.Add(this.edtSaldovortrag);
            this.panTitle.Controls.Add(this.picTitel);
            this.panTitle.Controls.Add(this.lblTitel);
            this.panTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitle.Location = new System.Drawing.Point(0, 0);
            this.panTitle.Name = "panTitle";
            this.panTitle.Size = new System.Drawing.Size(718, 24);
            this.panTitle.TabIndex = 0;
            // 
            // edtSaldovortrag
            // 
            this.edtSaldovortrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtSaldovortrag.EditValue = true;
            this.edtSaldovortrag.Location = new System.Drawing.Point(616, 5);
            this.edtSaldovortrag.Name = "edtSaldovortrag";
            this.edtSaldovortrag.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtSaldovortrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtSaldovortrag.Properties.Caption = "Saldovortrag";
            this.edtSaldovortrag.Size = new System.Drawing.Size(90, 19);
            this.edtSaldovortrag.TabIndex = 18;
            // 
            // picTitel
            // 
            this.picTitel.Location = new System.Drawing.Point(5, 5);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 293;
            this.picTitel.TabStop = false;
            // 
            // lblTitel
            // 
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(25, 5);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(542, 15);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Kontoauszug";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // lblSchuldner
            // 
            this.lblSchuldner.Location = new System.Drawing.Point(5, 36);
            this.lblSchuldner.Name = "lblSchuldner";
            this.lblSchuldner.Size = new System.Drawing.Size(57, 24);
            this.lblSchuldner.TabIndex = 1;
            this.lblSchuldner.Text = "Schuldner";
            this.lblSchuldner.UseCompatibleTextRendering = true;
            // 
            // lblBuchungenVon
            // 
            this.lblBuchungenVon.Location = new System.Drawing.Point(278, 36);
            this.lblBuchungenVon.Name = "lblBuchungenVon";
            this.lblBuchungenVon.Size = new System.Drawing.Size(76, 24);
            this.lblBuchungenVon.TabIndex = 3;
            this.lblBuchungenVon.Text = "Datum von";
            this.lblBuchungenVon.UseCompatibleTextRendering = true;
            // 
            // edtBuchungenVon
            // 
            this.edtBuchungenVon.EditValue = null;
            this.edtBuchungenVon.Location = new System.Drawing.Point(361, 36);
            this.edtBuchungenVon.Name = "edtBuchungenVon";
            this.edtBuchungenVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBuchungenVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBuchungenVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchungenVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchungenVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchungenVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchungenVon.Properties.Appearance.Options.UseFont = true;
            this.edtBuchungenVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtBuchungenVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtBuchungenVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtBuchungenVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBuchungenVon.Properties.ShowToday = false;
            this.edtBuchungenVon.Size = new System.Drawing.Size(90, 24);
            this.edtBuchungenVon.TabIndex = 4;
            // 
            // lblBuchungenBis
            // 
            this.lblBuchungenBis.Location = new System.Drawing.Point(457, 36);
            this.lblBuchungenBis.Name = "lblBuchungenBis";
            this.lblBuchungenBis.Size = new System.Drawing.Size(16, 24);
            this.lblBuchungenBis.TabIndex = 5;
            this.lblBuchungenBis.Text = "bis";
            this.lblBuchungenBis.UseCompatibleTextRendering = true;
            // 
            // edtBuchungenBis
            // 
            this.edtBuchungenBis.EditValue = null;
            this.edtBuchungenBis.Location = new System.Drawing.Point(489, 36);
            this.edtBuchungenBis.Name = "edtBuchungenBis";
            this.edtBuchungenBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBuchungenBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBuchungenBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchungenBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchungenBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchungenBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchungenBis.Properties.Appearance.Options.UseFont = true;
            this.edtBuchungenBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtBuchungenBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtBuchungenBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtBuchungenBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBuchungenBis.Properties.ShowToday = false;
            this.edtBuchungenBis.Size = new System.Drawing.Size(90, 24);
            this.edtBuchungenBis.TabIndex = 6;
            // 
            // lblGlaeubiger
            // 
            this.lblGlaeubiger.Location = new System.Drawing.Point(5, 66);
            this.lblGlaeubiger.Name = "lblGlaeubiger";
            this.lblGlaeubiger.Size = new System.Drawing.Size(64, 24);
            this.lblGlaeubiger.TabIndex = 7;
            this.lblGlaeubiger.Text = "Gläubiger/in";
            this.lblGlaeubiger.UseCompatibleTextRendering = true;
            // 
            // edtGlaeubiger
            // 
            this.edtGlaeubiger.Location = new System.Drawing.Point(75, 66);
            this.edtGlaeubiger.Name = "edtGlaeubiger";
            this.edtGlaeubiger.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGlaeubiger.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGlaeubiger.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGlaeubiger.Properties.Appearance.Options.UseBackColor = true;
            this.edtGlaeubiger.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGlaeubiger.Properties.Appearance.Options.UseFont = true;
            this.edtGlaeubiger.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtGlaeubiger.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtGlaeubiger.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtGlaeubiger.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtGlaeubiger.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtGlaeubiger.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtGlaeubiger.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGlaeubiger.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Gläubiger", "Gläubiger", 100)});
            this.edtGlaeubiger.Properties.DataSource = this.qryGlaeubigerSuchen;
            this.edtGlaeubiger.Properties.DisplayMember = "Gläubiger";
            this.edtGlaeubiger.Properties.NullText = "";
            this.edtGlaeubiger.Properties.ShowFooter = false;
            this.edtGlaeubiger.Properties.ShowHeader = false;
            this.edtGlaeubiger.Properties.ValueMember = "BaPersonID";
            this.edtGlaeubiger.Size = new System.Drawing.Size(197, 24);
            this.edtGlaeubiger.TabIndex = 8;
            this.edtGlaeubiger.EditValueChanged += new System.EventHandler(this.edtGlaeubiger_EditValueChanged);
            // 
            // qryGlaeubigerSuchen
            // 
            this.qryGlaeubigerSuchen.FillTimeOut = 300;
            this.qryGlaeubigerSuchen.HostControl = this;
            this.qryGlaeubigerSuchen.IsIdentityInsert = false;
            this.qryGlaeubigerSuchen.SelectStatement = resources.GetString("qryGlaeubigerSuchen.SelectStatement");
            // 
            // lblForderungsart
            // 
            this.lblForderungsart.Location = new System.Drawing.Point(278, 66);
            this.lblForderungsart.Name = "lblForderungsart";
            this.lblForderungsart.Size = new System.Drawing.Size(76, 24);
            this.lblForderungsart.TabIndex = 9;
            this.lblForderungsart.Text = "Forderungsart";
            this.lblForderungsart.UseCompatibleTextRendering = true;
            // 
            // edtForderungsart
            // 
            this.edtForderungsart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtForderungsart.Location = new System.Drawing.Point(361, 66);
            this.edtForderungsart.LOVName = "IkForderungEinmalig";
            this.edtForderungsart.Name = "edtForderungsart";
            this.edtForderungsart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtForderungsart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtForderungsart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtForderungsart.Properties.Appearance.Options.UseBackColor = true;
            this.edtForderungsart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtForderungsart.Properties.Appearance.Options.UseFont = true;
            this.edtForderungsart.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtForderungsart.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtForderungsart.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtForderungsart.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtForderungsart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtForderungsart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtForderungsart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtForderungsart.Properties.DisplayMember = "Text";
            this.edtForderungsart.Properties.DropDownRows = 10;
            this.edtForderungsart.Properties.NullText = "";
            this.edtForderungsart.Properties.ShowFooter = false;
            this.edtForderungsart.Properties.ShowHeader = false;
            this.edtForderungsart.Properties.ValueMember = "Code";
            this.edtForderungsart.Size = new System.Drawing.Size(218, 24);
            this.edtForderungsart.TabIndex = 10;
            this.edtForderungsart.EditValueChanged += new System.EventHandler(this.edtForderungsart_EditValueChanged);
            // 
            // btnRefreshSearch
            // 
            this.btnRefreshSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshSearch.Location = new System.Drawing.Point(616, 36);
            this.btnRefreshSearch.Name = "btnRefreshSearch";
            this.btnRefreshSearch.Size = new System.Drawing.Size(90, 24);
            this.btnRefreshSearch.TabIndex = 11;
            this.btnRefreshSearch.Text = "Aktualisieren";
            this.btnRefreshSearch.UseCompatibleTextRendering = true;
            this.btnRefreshSearch.UseVisualStyleBackColor = true;
            this.btnRefreshSearch.Click += new System.EventHandler(this.btnRefreshSearch_Click);
            // 
            // btnSearchAll
            // 
            this.btnSearchAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchAll.Location = new System.Drawing.Point(616, 66);
            this.btnSearchAll.Name = "btnSearchAll";
            this.btnSearchAll.Size = new System.Drawing.Size(90, 24);
            this.btnSearchAll.TabIndex = 12;
            this.btnSearchAll.Text = "Alles";
            this.btnSearchAll.UseCompatibleTextRendering = true;
            this.btnSearchAll.UseVisualStyleBackColor = true;
            this.btnSearchAll.Click += new System.EventHandler(this.btnSearchAll_Click);
            // 
            // grdKontoauszug
            // 
            this.grdKontoauszug.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdKontoauszug.DataSource = this.qryKontoauszug;
            // 
            // 
            // 
            this.grdKontoauszug.EmbeddedNavigator.Name = "";
            this.grdKontoauszug.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdKontoauszug.Location = new System.Drawing.Point(5, 96);
            this.grdKontoauszug.MainView = this.grvKontoauszug;
            this.grdKontoauszug.Name = "grdKontoauszug";
            this.grdKontoauszug.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cedGlaeubiger});
            this.grdKontoauszug.Size = new System.Drawing.Size(701, 285);
            this.grdKontoauszug.TabIndex = 13;
            this.grdKontoauszug.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKontoauszug});
            // 
            // qryKontoauszug
            // 
            this.qryKontoauszug.FillTimeOut = 300;
            this.qryKontoauszug.HostControl = this;
            this.qryKontoauszug.IsIdentityInsert = false;
            this.qryKontoauszug.SelectStatement = resources.GetString("qryKontoauszug.SelectStatement");
            this.qryKontoauszug.TableName = "KbBuchung";
            this.qryKontoauszug.AfterFill += new System.EventHandler(this.qryKontoauszug_AfterFill);
            this.qryKontoauszug.PositionChanged += new System.EventHandler(this.qryKontoauszug_PositionChanged);
            // 
            // grvKontoauszug
            // 
            this.grvKontoauszug.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvKontoauszug.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontoauszug.Appearance.Empty.Options.UseBackColor = true;
            this.grvKontoauszug.Appearance.Empty.Options.UseFont = true;
            this.grvKontoauszug.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontoauszug.Appearance.EvenRow.Options.UseFont = true;
            this.grvKontoauszug.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKontoauszug.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontoauszug.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKontoauszug.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKontoauszug.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKontoauszug.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKontoauszug.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKontoauszug.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontoauszug.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvKontoauszug.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKontoauszug.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKontoauszug.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKontoauszug.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKontoauszug.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKontoauszug.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKontoauszug.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKontoauszug.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKontoauszug.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKontoauszug.Appearance.GroupRow.Options.UseFont = true;
            this.grvKontoauszug.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKontoauszug.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKontoauszug.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKontoauszug.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKontoauszug.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKontoauszug.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKontoauszug.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKontoauszug.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvKontoauszug.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontoauszug.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKontoauszug.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKontoauszug.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKontoauszug.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKontoauszug.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvKontoauszug.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvKontoauszug.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontoauszug.Appearance.OddRow.Options.UseFont = true;
            this.grvKontoauszug.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKontoauszug.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontoauszug.Appearance.Row.Options.UseBackColor = true;
            this.grvKontoauszug.Appearance.Row.Options.UseFont = true;
            this.grvKontoauszug.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontoauszug.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKontoauszug.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvKontoauszug.Appearance.VertLine.Options.UseBackColor = true;
            this.grvKontoauszug.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKontoauszug.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatum,
            this.colDatumForderung,
            this.colGlaeubiger,
            this.colBuText,
            this.colBemerkung,
            this.colSoll,
            this.colHaben,
            this.colSaldo});
            this.grvKontoauszug.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvKontoauszug.GridControl = this.grdKontoauszug;
            this.grvKontoauszug.Name = "grvKontoauszug";
            this.grvKontoauszug.OptionsBehavior.Editable = false;
            this.grvKontoauszug.OptionsCustomization.AllowFilter = false;
            this.grvKontoauszug.OptionsCustomization.AllowSort = false;
            this.grvKontoauszug.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKontoauszug.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKontoauszug.OptionsNavigation.UseTabKey = false;
            this.grvKontoauszug.OptionsView.ColumnAutoWidth = false;
            this.grvKontoauszug.OptionsView.RowAutoHeight = true;
            this.grvKontoauszug.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvKontoauszug.OptionsView.ShowFooter = true;
            this.grvKontoauszug.OptionsView.ShowGroupPanel = false;
            this.grvKontoauszug.OptionsView.ShowIndicator = false;
            this.grvKontoauszug.DoubleClick += new System.EventHandler(this.grvKontoauszug_DoubleClick);
            // 
            // colDatum
            // 
            this.colDatum.Caption = "Datum";
            this.colDatum.FieldName = "Datum";
            this.colDatum.Name = "colDatum";
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 0;
            this.colDatum.Width = 72;
            // 
            // colDatumForderung
            // 
            this.colDatumForderung.Caption = "Datum Forderung";
            this.colDatumForderung.FieldName = "DatumForderung";
            this.colDatumForderung.Name = "colDatumForderung";
            this.colDatumForderung.Visible = true;
            this.colDatumForderung.VisibleIndex = 1;
            // 
            // colGlaeubiger
            // 
            this.colGlaeubiger.Caption = "Gläubiger";
            this.colGlaeubiger.FieldName = "Glaeubiger";
            this.colGlaeubiger.Name = "colGlaeubiger";
            this.colGlaeubiger.Visible = true;
            this.colGlaeubiger.VisibleIndex = 2;
            this.colGlaeubiger.Width = 143;
            // 
            // colBuText
            // 
            this.colBuText.Caption = "Buchungstext";
            this.colBuText.FieldName = "Text";
            this.colBuText.Name = "colBuText";
            this.colBuText.Visible = true;
            this.colBuText.VisibleIndex = 3;
            this.colBuText.Width = 215;
            // 
            // colBemerkung
            // 
            this.colBemerkung.Caption = "Bemerkung";
            this.colBemerkung.FieldName = "Bemerkung";
            this.colBemerkung.Name = "colBemerkung";
            this.colBemerkung.Visible = true;
            this.colBemerkung.VisibleIndex = 4;
            // 
            // colSoll
            // 
            this.colSoll.Caption = "Soll";
            this.colSoll.DisplayFormat.FormatString = "n2";
            this.colSoll.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSoll.FieldName = "BetragSoll";
            this.colSoll.Name = "colSoll";
            this.colSoll.SummaryItem.DisplayFormat = "{0:n2}";
            this.colSoll.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colSoll.Visible = true;
            this.colSoll.VisibleIndex = 5;
            this.colSoll.Width = 73;
            // 
            // colHaben
            // 
            this.colHaben.Caption = "Haben";
            this.colHaben.DisplayFormat.FormatString = "n2";
            this.colHaben.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colHaben.FieldName = "BetragHaben";
            this.colHaben.Name = "colHaben";
            this.colHaben.SummaryItem.DisplayFormat = "{0:n2}";
            this.colHaben.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colHaben.Visible = true;
            this.colHaben.VisibleIndex = 6;
            // 
            // colSaldo
            // 
            this.colSaldo.Caption = "Saldo";
            this.colSaldo.DisplayFormat.FormatString = "n2";
            this.colSaldo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaldo.FieldName = "Saldo";
            this.colSaldo.Name = "colSaldo";
            this.colSaldo.Visible = true;
            this.colSaldo.VisibleIndex = 7;
            this.colSaldo.Width = 81;
            // 
            // cedGlaeubiger
            // 
            this.cedGlaeubiger.Name = "cedGlaeubiger";
            this.cedGlaeubiger.ReadOnly = true;
            this.cedGlaeubiger.ScrollBars = System.Windows.Forms.ScrollBars.None;
            // 
            // btnNeueZahlung
            // 
            this.btnNeueZahlung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNeueZahlung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNeueZahlung.Location = new System.Drawing.Point(5, 387);
            this.btnNeueZahlung.Name = "btnNeueZahlung";
            this.btnNeueZahlung.Size = new System.Drawing.Size(124, 24);
            this.btnNeueZahlung.TabIndex = 14;
            this.btnNeueZahlung.Text = "neue Zahlung";
            this.btnNeueZahlung.UseCompatibleTextRendering = true;
            this.btnNeueZahlung.UseVisualStyleBackColor = false;
            this.btnNeueZahlung.Click += new System.EventHandler(this.btnNeueZahlung_Click);
            // 
            // btnZahlungsdetail
            // 
            this.btnZahlungsdetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnZahlungsdetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZahlungsdetail.Location = new System.Drawing.Point(135, 387);
            this.btnZahlungsdetail.Name = "btnZahlungsdetail";
            this.btnZahlungsdetail.Size = new System.Drawing.Size(124, 24);
            this.btnZahlungsdetail.TabIndex = 15;
            this.btnZahlungsdetail.Text = "Zahlungsdetail";
            this.btnZahlungsdetail.UseCompatibleTextRendering = true;
            this.btnZahlungsdetail.UseVisualStyleBackColor = false;
            this.btnZahlungsdetail.Click += new System.EventHandler(this.btnZahlungsdetail_Click);
            // 
            // lblSchuldnerPerson
            // 
            this.lblSchuldnerPerson.DataMember = "Schuldner";
            this.lblSchuldnerPerson.DataSource = this.qryKontoauszug;
            this.lblSchuldnerPerson.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblSchuldnerPerson.Location = new System.Drawing.Point(75, 41);
            this.lblSchuldnerPerson.Name = "lblSchuldnerPerson";
            this.lblSchuldnerPerson.Size = new System.Drawing.Size(197, 16);
            this.lblSchuldnerPerson.TabIndex = 17;
            this.lblSchuldnerPerson.UseCompatibleTextRendering = true;
            // 
            // edtVerdichtet
            // 
            this.edtVerdichtet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtVerdichtet.EditValue = false;
            this.edtVerdichtet.Location = new System.Drawing.Point(526, 5);
            this.edtVerdichtet.Name = "edtVerdichtet";
            this.edtVerdichtet.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtVerdichtet.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerdichtet.Properties.Caption = "Verdichtet";
            this.edtVerdichtet.Size = new System.Drawing.Size(75, 19);
            this.edtVerdichtet.TabIndex = 294;
            // 
            // CtlIkKontoauszug
            // 
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(715, 300);
            this.Controls.Add(this.edtVerdichtet);
            this.Controls.Add(this.lblSchuldnerPerson);
            this.Controls.Add(this.btnZahlungsdetail);
            this.Controls.Add(this.btnNeueZahlung);
            this.Controls.Add(this.grdKontoauszug);
            this.Controls.Add(this.btnSearchAll);
            this.Controls.Add(this.btnRefreshSearch);
            this.Controls.Add(this.edtForderungsart);
            this.Controls.Add(this.lblForderungsart);
            this.Controls.Add(this.edtGlaeubiger);
            this.Controls.Add(this.lblGlaeubiger);
            this.Controls.Add(this.edtBuchungenBis);
            this.Controls.Add(this.lblBuchungenBis);
            this.Controls.Add(this.edtBuchungenVon);
            this.Controls.Add(this.lblBuchungenVon);
            this.Controls.Add(this.lblSchuldner);
            this.Controls.Add(this.panTitle);
            this.Name = "CtlIkKontoauszug";
            this.Size = new System.Drawing.Size(718, 421);
            this.panTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtSaldovortrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSchuldner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungenVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungenVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungenBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungenBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGlaeubiger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGlaeubiger.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGlaeubiger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryGlaeubigerSuchen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblForderungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtForderungsart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtForderungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKontoauszug)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKontoauszug)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKontoauszug)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cedGlaeubiger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSchuldnerPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerdichtet.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissButton btnNeueZahlung;
        private KiSS4.Gui.KissButton btnRefreshSearch;
        private KiSS4.Gui.KissButton btnSearchAll;
        private KiSS4.Gui.KissButton btnZahlungsdetail;
        private DevExpress.XtraGrid.Columns.GridColumn colBemerkung;
        private DevExpress.XtraGrid.Columns.GridColumn colBuText;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumForderung;
        private DevExpress.XtraGrid.Columns.GridColumn colGlaeubiger;
        private DevExpress.XtraGrid.Columns.GridColumn colHaben;
        private DevExpress.XtraGrid.Columns.GridColumn colSaldo;
        private DevExpress.XtraGrid.Columns.GridColumn colSoll;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissDateEdit edtBuchungenBis;
        private KiSS4.Gui.KissDateEdit edtBuchungenVon;
        private KiSS4.Gui.KissLookUpEdit edtForderungsart;
        private KiSS4.Gui.KissLookUpEdit edtGlaeubiger;
        private KiSS4.Gui.KissCheckEdit edtSaldovortrag;
        private KiSS4.Gui.KissGrid grdKontoauszug;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKontoauszug;
        private KiSS4.Gui.KissLabel lblBuchungenBis;
        private KiSS4.Gui.KissLabel lblBuchungenVon;
        private KiSS4.Gui.KissLabel lblForderungsart;
        private KiSS4.Gui.KissLabel lblGlaeubiger;
        private KiSS4.Gui.KissLabel lblSchuldner;
        private KiSS4.Gui.KissLabel lblSchuldnerPerson;
        private KiSS4.Gui.KissLabel lblTitel;
        private System.Windows.Forms.Panel panTitle;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryGlaeubigerSuchen;
        private KiSS4.Gui.KissCheckEdit edtVerdichtet;
        private KiSS4.DB.SqlQuery qryKontoauszug;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit cedGlaeubiger;
    }
}
