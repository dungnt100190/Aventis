namespace KiSS4.Sozialhilfe
{
    partial class CtlWhASVSErfassung
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlWhASVSErfassung));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pnTitle = new System.Windows.Forms.Panel();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.imgTitel = new System.Windows.Forms.PictureBox();
            this.pnlFill = new System.Windows.Forms.Panel();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.qryASVS = new KiSS4.DB.SqlQuery(this.components);
            this.edtWiderruf = new KiSS4.Gui.KissCheckEdit();
            this.edtBaPersonID = new KiSS4.Gui.KissLookUpEdit();
            this.lblBis = new KiSS4.Gui.KissLabel();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.btnKopieren = new KiSS4.Gui.KissButton();
            this.grdASVSEintrag = new KiSS4.Gui.KissGrid();
            this.grvASVSEinheit = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNameVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumSent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWiderruf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colDatumWiderrufenSent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.qryBaPerson = new KiSS4.DB.SqlQuery(this.components);
            this.pnTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTitel)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryASVS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWiderruf.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdASVSEintrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvASVSEinheit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).BeginInit();
            this.SuspendLayout();
            // 
            // pnTitle
            // 
            this.pnTitle.Controls.Add(this.lblTitel);
            this.pnTitle.Controls.Add(this.imgTitel);
            this.pnTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTitle.Location = new System.Drawing.Point(0, 0);
            this.pnTitle.Name = "pnTitle";
            this.pnTitle.Size = new System.Drawing.Size(1072, 40);
            this.pnTitle.TabIndex = 1;
            // 
            // lblTitel
            // 
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(35, 10);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(183, 20);
            this.lblTitel.TabIndex = 1;
            this.lblTitel.Text = "ASV-Datenerfassung";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // imgTitel
            // 
            this.imgTitel.Location = new System.Drawing.Point(10, 9);
            this.imgTitel.Name = "imgTitel";
            this.imgTitel.Size = new System.Drawing.Size(25, 20);
            this.imgTitel.TabIndex = 1;
            this.imgTitel.TabStop = false;
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.edtBemerkung);
            this.pnlFill.Controls.Add(this.edtWiderruf);
            this.pnlFill.Controls.Add(this.edtBaPersonID);
            this.pnlFill.Controls.Add(this.lblBis);
            this.pnlFill.Controls.Add(this.edtDatumBis);
            this.pnlFill.Controls.Add(this.edtDatumVon);
            this.pnlFill.Controls.Add(this.btnKopieren);
            this.pnlFill.Controls.Add(this.grdASVSEintrag);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(0, 40);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(1072, 652);
            this.pnlFill.TabIndex = 3;
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryASVS;
            this.edtBemerkung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBemerkung.Location = new System.Drawing.Point(10, 587);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Properties.ReadOnly = true;
            this.edtBemerkung.Size = new System.Drawing.Size(512, 46);
            this.edtBemerkung.TabIndex = 133;
            // 
            // qryASVS
            // 
            this.qryASVS.CanDelete = true;
            this.qryASVS.CanInsert = true;
            this.qryASVS.CanUpdate = true;
            this.qryASVS.HostControl = this;
            this.qryASVS.SelectStatement = resources.GetString("qryASVS.SelectStatement");
            this.qryASVS.TableName = "WhASVSEintrag";
            this.qryASVS.AfterInsert += new System.EventHandler(this.qryASVS_AfterInsert);
            this.qryASVS.BeforePost += new System.EventHandler(this.qryASVS_BeforePost);
            this.qryASVS.BeforeDelete += new System.EventHandler(this.qryASVS_BeforeDelete);
            this.qryASVS.PositionChanged += new System.EventHandler(this.qryASVS_PositionChanged);
            // 
            // edtWiderruf
            // 
            this.edtWiderruf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtWiderruf.DataMember = "Widerrufen";
            this.edtWiderruf.DataSource = this.qryASVS;
            this.edtWiderruf.Location = new System.Drawing.Point(547, 557);
            this.edtWiderruf.Name = "edtWiderruf";
            this.edtWiderruf.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtWiderruf.Properties.Appearance.Options.UseBackColor = true;
            this.edtWiderruf.Properties.Caption = "Eintrag widerrufen";
            this.edtWiderruf.Size = new System.Drawing.Size(120, 19);
            this.edtWiderruf.TabIndex = 132;
            this.edtWiderruf.EditValueChanged += new System.EventHandler(this.edtWiderruf_EditValueChanged);
            // 
            // edtBaPersonID
            // 
            this.edtBaPersonID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBaPersonID.DataMember = "BaPersonID";
            this.edtBaPersonID.DataSource = this.qryASVS;
            this.edtBaPersonID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBaPersonID.Location = new System.Drawing.Point(10, 553);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBaPersonID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NameVorname", "Name", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtBaPersonID.Properties.DisplayMember = "NameVorname";
            this.edtBaPersonID.Properties.NullText = "";
            this.edtBaPersonID.Properties.ReadOnly = true;
            this.edtBaPersonID.Properties.ShowFooter = false;
            this.edtBaPersonID.Properties.ShowHeader = false;
            this.edtBaPersonID.Properties.ValueMember = "BaPersonID";
            this.edtBaPersonID.Size = new System.Drawing.Size(250, 24);
            this.edtBaPersonID.TabIndex = 131;
            // 
            // lblBis
            // 
            this.lblBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBis.Location = new System.Drawing.Point(403, 553);
            this.lblBis.Name = "lblBis";
            this.lblBis.Size = new System.Drawing.Size(17, 24);
            this.lblBis.TabIndex = 117;
            this.lblBis.Text = "bis";
            this.lblBis.UseCompatibleTextRendering = true;
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDatumBis.DataMember = "DatumBis";
            this.edtDatumBis.DataSource = this.qryASVS;
            this.edtDatumBis.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(422, 553);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.Name = "kissDateEdit9.Properties";
            this.edtDatumBis.Properties.ReadOnly = true;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 116;
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDatumVon.DataMember = "DatumVon";
            this.edtDatumVon.DataSource = this.qryASVS;
            this.edtDatumVon.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(297, 553);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.Name = "kissDateEdit8.Properties";
            this.edtDatumVon.Properties.ReadOnly = true;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 115;
            // 
            // btnKopieren
            // 
            this.btnKopieren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnKopieren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKopieren.Location = new System.Drawing.Point(683, 557);
            this.btnKopieren.Name = "btnKopieren";
            this.btnKopieren.Size = new System.Drawing.Size(108, 24);
            this.btnKopieren.TabIndex = 4;
            this.btnKopieren.Text = "Eintrag kopieren";
            this.btnKopieren.UseCompatibleTextRendering = true;
            this.btnKopieren.UseVisualStyleBackColor = false;
            this.btnKopieren.Click += new System.EventHandler(this.btnKopieren_Click);
            // 
            // grdASVSEintrag
            // 
            this.grdASVSEintrag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdASVSEintrag.DataSource = this.qryASVS;
            // 
            // 
            // 
            this.grdASVSEintrag.EmbeddedNavigator.Name = "";
            this.grdASVSEintrag.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdASVSEintrag.Location = new System.Drawing.Point(3, 6);
            this.grdASVSEintrag.MainView = this.grvASVSEinheit;
            this.grdASVSEintrag.Name = "grdASVSEintrag";
            this.grdASVSEintrag.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemGridLookUpEdit1,
            this.repositoryItemCheckEdit1});
            this.grdASVSEintrag.Size = new System.Drawing.Size(1065, 517);
            this.grdASVSEintrag.TabIndex = 0;
            this.grdASVSEintrag.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvASVSEinheit});
            // 
            // grvASVSEinheit
            // 
            this.grvASVSEinheit.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvASVSEinheit.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvASVSEinheit.Appearance.Empty.Options.UseBackColor = true;
            this.grvASVSEinheit.Appearance.Empty.Options.UseFont = true;
            this.grvASVSEinheit.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvASVSEinheit.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvASVSEinheit.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvASVSEinheit.Appearance.EvenRow.Options.UseFont = true;
            this.grvASVSEinheit.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvASVSEinheit.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvASVSEinheit.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvASVSEinheit.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvASVSEinheit.Appearance.FocusedCell.Options.UseFont = true;
            this.grvASVSEinheit.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvASVSEinheit.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvASVSEinheit.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvASVSEinheit.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvASVSEinheit.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvASVSEinheit.Appearance.FocusedRow.Options.UseFont = true;
            this.grvASVSEinheit.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvASVSEinheit.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvASVSEinheit.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvASVSEinheit.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvASVSEinheit.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvASVSEinheit.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvASVSEinheit.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvASVSEinheit.Appearance.GroupRow.Options.UseFont = true;
            this.grvASVSEinheit.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvASVSEinheit.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvASVSEinheit.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvASVSEinheit.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvASVSEinheit.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvASVSEinheit.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvASVSEinheit.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvASVSEinheit.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvASVSEinheit.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvASVSEinheit.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvASVSEinheit.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvASVSEinheit.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvASVSEinheit.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvASVSEinheit.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvASVSEinheit.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvASVSEinheit.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvASVSEinheit.Appearance.OddRow.Options.UseFont = true;
            this.grvASVSEinheit.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvASVSEinheit.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvASVSEinheit.Appearance.Row.Options.UseBackColor = true;
            this.grvASVSEinheit.Appearance.Row.Options.UseFont = true;
            this.grvASVSEinheit.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvASVSEinheit.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvASVSEinheit.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvASVSEinheit.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvASVSEinheit.Appearance.SelectedRow.Options.UseFont = true;
            this.grvASVSEinheit.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvASVSEinheit.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvASVSEinheit.Appearance.VertLine.Options.UseBackColor = true;
            this.grvASVSEinheit.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvASVSEinheit.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNameVorname,
            this.colDatumVon,
            this.colDatumBis,
            this.colDatumSent,
            this.colWiderruf,
            this.colDatumWiderrufenSent});
            this.grvASVSEinheit.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvASVSEinheit.GridControl = this.grdASVSEintrag;
            this.grvASVSEinheit.Name = "grvASVSEinheit";
            this.grvASVSEinheit.OptionsBehavior.Editable = false;
            this.grvASVSEinheit.OptionsCustomization.AllowFilter = false;
            this.grvASVSEinheit.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvASVSEinheit.OptionsNavigation.AutoFocusNewRow = true;
            this.grvASVSEinheit.OptionsNavigation.UseTabKey = false;
            this.grvASVSEinheit.OptionsSelection.MultiSelect = true;
            this.grvASVSEinheit.OptionsView.ColumnAutoWidth = false;
            this.grvASVSEinheit.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvASVSEinheit.OptionsView.ShowGroupPanel = false;
            this.grvASVSEinheit.OptionsView.ShowIndicator = false;
            this.grvASVSEinheit.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.grvASVSEinheit_SelectionChanged);
            this.grvASVSEinheit.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.grvASVSEinheit_BeforeLeaveRow);
            // 
            // colNameVorname
            // 
            this.colNameVorname.Caption = "Person";
            this.colNameVorname.FieldName = "NameVorname";
            this.colNameVorname.Name = "colNameVorname";
            this.colNameVorname.Visible = true;
            this.colNameVorname.VisibleIndex = 0;
            this.colNameVorname.Width = 167;
            // 
            // colDatumVon
            // 
            this.colDatumVon.Caption = "Datum Von";
            this.colDatumVon.FieldName = "DatumVon";
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.Visible = true;
            this.colDatumVon.VisibleIndex = 1;
            this.colDatumVon.Width = 80;
            // 
            // colDatumBis
            // 
            this.colDatumBis.Caption = "Datum Bis";
            this.colDatumBis.FieldName = "DatumBis";
            this.colDatumBis.Name = "colDatumBis";
            this.colDatumBis.Visible = true;
            this.colDatumBis.VisibleIndex = 2;
            this.colDatumBis.Width = 102;
            // 
            // colDatumSent
            // 
            this.colDatumSent.Caption = "Übertragungsdatum";
            this.colDatumSent.FieldName = "DatumExport";
            this.colDatumSent.Name = "colDatumSent";
            this.colDatumSent.Visible = true;
            this.colDatumSent.VisibleIndex = 3;
            this.colDatumSent.Width = 145;
            // 
            // colWiderruf
            // 
            this.colWiderruf.Caption = "Widerrufen";
            this.colWiderruf.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colWiderruf.FieldName = "Widerrufen";
            this.colWiderruf.Name = "colWiderruf";
            this.colWiderruf.ToolTip = "Widerrufen";
            this.colWiderruf.Visible = true;
            this.colWiderruf.VisibleIndex = 4;
            this.colWiderruf.Width = 58;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // colDatumWiderrufenSent
            // 
            this.colDatumWiderrufenSent.Caption = "Widerruf übertragen";
            this.colDatumWiderrufenSent.FieldName = "ExportDatumWiderruf";
            this.colDatumWiderrufenSent.Name = "colDatumWiderrufenSent";
            this.colDatumWiderrufenSent.Visible = true;
            this.colDatumWiderrufenSent.VisibleIndex = 5;
            this.colDatumWiderrufenSent.Width = 168;
            // 
            // repositoryItemGridLookUpEdit1
            // 
            this.repositoryItemGridLookUpEdit1.AutoHeight = false;
            this.repositoryItemGridLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1";
            this.repositoryItemGridLookUpEdit1.View = this.gridView1;
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // qryBaPerson
            // 
            this.qryBaPerson.SelectStatement = resources.GetString("qryBaPerson.SelectStatement");
            // 
            // CtlWhASVSErfassung
            // 
            this.ActiveSQLQuery = this.qryASVS;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnTitle);
            this.Name = "CtlWhASVSErfassung";
            this.Size = new System.Drawing.Size(1072, 692);
            this.Enter += new System.EventHandler(this.CtlWhASVSErfassung_Enter);
            this.pnTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTitel)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryASVS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWiderruf.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdASVSEintrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvASVSEinheit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnTitle;
        private KiSS4.Gui.KissLabel lblTitel;
        private System.Windows.Forms.PictureBox imgTitel;
        private System.Windows.Forms.Panel pnlFill;
        private KiSS4.Gui.KissGrid grdASVSEintrag;
        private DevExpress.XtraGrid.Views.Grid.GridView grvASVSEinheit;
        private DevExpress.XtraGrid.Columns.GridColumn colNameVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumSent;
        private DevExpress.XtraGrid.Columns.GridColumn colWiderruf;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumWiderrufenSent;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissButton btnKopieren;
        private KiSS4.Gui.KissLabel lblBis;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissLookUpEdit edtBaPersonID;
        private KiSS4.DB.SqlQuery qryASVS;
        private KiSS4.Gui.KissCheckEdit edtWiderruf;
        private KiSS4.DB.SqlQuery qryBaPerson;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private Gui.KissMemoEdit edtBemerkung;

    }
}
