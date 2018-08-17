namespace KiSS4.Administration
{
    partial class CtlAdBgKostenartWhGefKategorie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlAdBgKostenartWhGefKategorie));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryQuery = new KiSS4.DB.SqlQuery();
            this.qryBgKostenart_WhGefKategorie = new KiSS4.DB.SqlQuery();
            this.edtKostenartX = new KiSS4.Gui.KissButtonEdit();
            this.lblKostenartX = new KiSS4.Gui.KissLabel();
            this.edtGefKategorieX = new KiSS4.Gui.KissButtonEdit();
            this.lblGefKategorieX = new KiSS4.Gui.KissLabel();
            this.panDetail = new System.Windows.Forms.Panel();
            this.edtGefKategorie = new KiSS4.Gui.KissButtonEdit();
            this.edtInkassoprovision = new KiSS4.Gui.KissCheckEdit();
            this.lblGefKategorie = new KiSS4.Gui.KissLabel();
            this.edtKostenart = new KiSS4.Gui.KissTextEdit();
            this.lblKostenart = new KiSS4.Gui.KissLabel();
            this.edtBgKostenartID = new KiSS4.Gui.KissCalcEdit();
            this.lblBgKostenartID = new KiSS4.Gui.KissLabel();
            this.grdQuery = new KiSS4.Gui.KissGrid();
            this.grvQuery = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBgKostenartID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKontoNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErfolgAktuellerKontoplan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErfolgLetzterKontoplan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGefKategorieTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGefKategorie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlbv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.checkEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colZuDe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInkassoprovision = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreated = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModifier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModified = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBgKostenartWhGefKategorieID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWhGefKategorieID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWhGefKategorieCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWhGefKategorieTypCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgKostenart_WhGefKategorie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenartX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenartX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGefKategorieX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGefKategorieX)).BeginInit();
            this.panDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtGefKategorie.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoprovision.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGefKategorie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKostenartID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgKostenartID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(780, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSearch.Size = new System.Drawing.Size(804, 494);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdQuery);
            this.tpgListe.Size = new System.Drawing.Size(792, 456);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtGefKategorieX);
            this.tpgSuchen.Controls.Add(this.lblGefKategorieX);
            this.tpgSuchen.Controls.Add(this.edtKostenartX);
            this.tpgSuchen.Controls.Add(this.lblKostenartX);
            this.tpgSuchen.Size = new System.Drawing.Size(792, 456);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblKostenartX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtKostenartX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblGefKategorieX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtGefKategorieX, 0);
            // 
            // qryQuery
            // 
            this.qryQuery.CanUpdate = true;
            this.qryQuery.HostControl = this;
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            this.qryQuery.BeforePost += new System.EventHandler(this.qryQuery_BeforePost);
            this.qryQuery.PositionChanged += new System.EventHandler(this.qryQuery_PositionChanged);
            // 
            // qryBgKostenart_WhGefKategorie
            // 
            this.qryBgKostenart_WhGefKategorie.CanDelete = true;
            this.qryBgKostenart_WhGefKategorie.CanInsert = true;
            this.qryBgKostenart_WhGefKategorie.CanUpdate = true;
            this.qryBgKostenart_WhGefKategorie.DeleteQuestion = "";
            this.qryBgKostenart_WhGefKategorie.HostControl = this;
            this.qryBgKostenart_WhGefKategorie.SelectStatement = resources.GetString("qryBgKostenart_WhGefKategorie.SelectStatement");
            this.qryBgKostenart_WhGefKategorie.TableName = "BgKostenart_WhGefKategorie";
            // 
            // edtKostenartX
            // 
            this.edtKostenartX.Location = new System.Drawing.Point(135, 40);
            this.edtKostenartX.Name = "edtKostenartX";
            this.edtKostenartX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKostenartX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKostenartX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostenartX.Properties.Appearance.Options.UseBackColor = true;
            this.edtKostenartX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKostenartX.Properties.Appearance.Options.UseFont = true;
            this.edtKostenartX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtKostenartX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtKostenartX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKostenartX.Size = new System.Drawing.Size(277, 24);
            this.edtKostenartX.TabIndex = 23;
            this.edtKostenartX.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKostenartX_UserModifiedFld);
            // 
            // lblKostenartX
            // 
            this.lblKostenartX.Location = new System.Drawing.Point(30, 40);
            this.lblKostenartX.Name = "lblKostenartX";
            this.lblKostenartX.Size = new System.Drawing.Size(99, 24);
            this.lblKostenartX.TabIndex = 22;
            this.lblKostenartX.Text = "Kostenart";
            this.lblKostenartX.UseCompatibleTextRendering = true;
            // 
            // edtGefKategorieX
            // 
            this.edtGefKategorieX.Location = new System.Drawing.Point(135, 70);
            this.edtGefKategorieX.Name = "edtGefKategorieX";
            this.edtGefKategorieX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGefKategorieX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGefKategorieX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGefKategorieX.Properties.Appearance.Options.UseBackColor = true;
            this.edtGefKategorieX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGefKategorieX.Properties.Appearance.Options.UseFont = true;
            this.edtGefKategorieX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtGefKategorieX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtGefKategorieX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGefKategorieX.Size = new System.Drawing.Size(277, 24);
            this.edtGefKategorieX.TabIndex = 25;
            this.edtGefKategorieX.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtGefKategorieX_UserModifiedFld);
            // 
            // lblGefKategorieX
            // 
            this.lblGefKategorieX.Location = new System.Drawing.Point(30, 70);
            this.lblGefKategorieX.Name = "lblGefKategorieX";
            this.lblGefKategorieX.Size = new System.Drawing.Size(99, 24);
            this.lblGefKategorieX.TabIndex = 24;
            this.lblGefKategorieX.Text = "GEF-Kategorie";
            this.lblGefKategorieX.UseCompatibleTextRendering = true;
            // 
            // panDetail
            // 
            this.panDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panDetail.Controls.Add(this.edtGefKategorie);
            this.panDetail.Controls.Add(this.edtInkassoprovision);
            this.panDetail.Controls.Add(this.lblGefKategorie);
            this.panDetail.Controls.Add(this.edtKostenart);
            this.panDetail.Controls.Add(this.lblKostenart);
            this.panDetail.Controls.Add(this.edtBgKostenartID);
            this.panDetail.Controls.Add(this.lblBgKostenartID);
            this.panDetail.Location = new System.Drawing.Point(3, 503);
            this.panDetail.Name = "panDetail";
            this.panDetail.Size = new System.Drawing.Size(804, 129);
            this.panDetail.TabIndex = 23;
            // 
            // edtGefKategorie
            // 
            this.edtGefKategorie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtGefKategorie.DataMember = "WhGefKategorie";
            this.edtGefKategorie.DataSource = this.qryQuery;
            this.edtGefKategorie.Location = new System.Drawing.Point(110, 70);
            this.edtGefKategorie.Name = "edtGefKategorie";
            this.edtGefKategorie.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGefKategorie.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGefKategorie.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGefKategorie.Properties.Appearance.Options.UseBackColor = true;
            this.edtGefKategorie.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGefKategorie.Properties.Appearance.Options.UseFont = true;
            this.edtGefKategorie.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtGefKategorie.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtGefKategorie.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGefKategorie.Size = new System.Drawing.Size(525, 24);
            this.edtGefKategorie.TabIndex = 36;
            this.edtGefKategorie.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtGefKategorie_UserModifiedFld);
            // 
            // edtInkassoprovision
            // 
            this.edtInkassoprovision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtInkassoprovision.DataMember = "IsInkassoprovision";
            this.edtInkassoprovision.DataSource = this.qryQuery;
            this.edtInkassoprovision.Location = new System.Drawing.Point(110, 100);
            this.edtInkassoprovision.Name = "edtInkassoprovision";
            this.edtInkassoprovision.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtInkassoprovision.Properties.Appearance.Options.UseBackColor = true;
            this.edtInkassoprovision.Properties.Caption = "Inkassoprovision";
            this.edtInkassoprovision.Size = new System.Drawing.Size(184, 19);
            this.edtInkassoprovision.TabIndex = 35;
            this.edtInkassoprovision.CheckedChanged += new System.EventHandler(this.edtInkassoprovision_CheckedChanged);
            // 
            // lblGefKategorie
            // 
            this.lblGefKategorie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGefKategorie.Location = new System.Drawing.Point(5, 69);
            this.lblGefKategorie.Name = "lblGefKategorie";
            this.lblGefKategorie.Size = new System.Drawing.Size(99, 24);
            this.lblGefKategorie.TabIndex = 34;
            this.lblGefKategorie.Text = "GEF-Kategorie";
            this.lblGefKategorie.UseCompatibleTextRendering = true;
            // 
            // edtKostenart
            // 
            this.edtKostenart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtKostenart.DataMember = "Kostenart";
            this.edtKostenart.DataSource = this.qryQuery;
            this.edtKostenart.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKostenart.Location = new System.Drawing.Point(110, 39);
            this.edtKostenart.Name = "edtKostenart";
            this.edtKostenart.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKostenart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKostenart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostenart.Properties.Appearance.Options.UseBackColor = true;
            this.edtKostenart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKostenart.Properties.Appearance.Options.UseFont = true;
            this.edtKostenart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKostenart.Properties.ReadOnly = true;
            this.edtKostenart.Size = new System.Drawing.Size(525, 24);
            this.edtKostenart.TabIndex = 33;
            // 
            // lblKostenart
            // 
            this.lblKostenart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblKostenart.Location = new System.Drawing.Point(5, 39);
            this.lblKostenart.Name = "lblKostenart";
            this.lblKostenart.Size = new System.Drawing.Size(99, 24);
            this.lblKostenart.TabIndex = 32;
            this.lblKostenart.Text = "Kostenart";
            this.lblKostenart.UseCompatibleTextRendering = true;
            // 
            // edtBgKostenartID
            // 
            this.edtBgKostenartID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBgKostenartID.DataMember = "BgKostenartID";
            this.edtBgKostenartID.DataSource = this.qryQuery;
            this.edtBgKostenartID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBgKostenartID.Location = new System.Drawing.Point(110, 9);
            this.edtBgKostenartID.Name = "edtBgKostenartID";
            this.edtBgKostenartID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBgKostenartID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBgKostenartID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgKostenartID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgKostenartID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgKostenartID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgKostenartID.Properties.Appearance.Options.UseFont = true;
            this.edtBgKostenartID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBgKostenartID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgKostenartID.Properties.ReadOnly = true;
            this.edtBgKostenartID.Size = new System.Drawing.Size(48, 24);
            this.edtBgKostenartID.TabIndex = 31;
            // 
            // lblBgKostenartID
            // 
            this.lblBgKostenartID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBgKostenartID.Location = new System.Drawing.Point(5, 9);
            this.lblBgKostenartID.Name = "lblBgKostenartID";
            this.lblBgKostenartID.Size = new System.Drawing.Size(99, 24);
            this.lblBgKostenartID.TabIndex = 30;
            this.lblBgKostenartID.Text = "KOA-ID";
            this.lblBgKostenartID.UseCompatibleTextRendering = true;
            // 
            // grdQuery
            // 
            this.grdQuery.DataSource = this.qryQuery;
            this.grdQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdQuery.EmbeddedNavigator.Name = "";
            this.grdQuery.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdQuery.Location = new System.Drawing.Point(0, 0);
            this.grdQuery.MainView = this.grvQuery;
            this.grdQuery.Name = "grdQuery";
            this.grdQuery.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.checkEdit});
            this.grdQuery.Size = new System.Drawing.Size(792, 456);
            this.grdQuery.TabIndex = 0;
            this.grdQuery.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvQuery});
            // 
            // grvQuery
            // 
            this.grvQuery.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvQuery.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery.Appearance.Empty.Options.UseBackColor = true;
            this.grvQuery.Appearance.Empty.Options.UseFont = true;
            this.grvQuery.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery.Appearance.EvenRow.Options.UseFont = true;
            this.grvQuery.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvQuery.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvQuery.Appearance.FocusedCell.Options.UseFont = true;
            this.grvQuery.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvQuery.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvQuery.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvQuery.Appearance.FocusedRow.Options.UseFont = true;
            this.grvQuery.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvQuery.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvQuery.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvQuery.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvQuery.Appearance.GroupRow.Options.UseFont = true;
            this.grvQuery.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvQuery.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvQuery.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvQuery.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvQuery.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvQuery.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvQuery.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvQuery.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvQuery.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvQuery.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvQuery.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvQuery.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvQuery.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery.Appearance.OddRow.Options.UseFont = true;
            this.grvQuery.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvQuery.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery.Appearance.Row.Options.UseBackColor = true;
            this.grvQuery.Appearance.Row.Options.UseFont = true;
            this.grvQuery.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery.Appearance.SelectedRow.Options.UseFont = true;
            this.grvQuery.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery.Appearance.VertLine.Options.UseBackColor = true;
            this.grvQuery.BestFitMaxRowCount = 10;
            this.grvQuery.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvQuery.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBgKostenartID,
            this.colKontoNr,
            this.colName,
            this.colErfolgAktuellerKontoplan,
            this.colErfolgLetzterKontoplan,
            this.colGefKategorieTyp,
            this.colGefKategorie,
            this.colAlbv,
            this.colZuDe,
            this.colInkassoprovision,
            this.colCreator,
            this.colCreated,
            this.colModifier,
            this.colModified,
            this.colBgKostenartWhGefKategorieID,
            this.colWhGefKategorieID,
            this.colWhGefKategorieCode,
            this.colWhGefKategorieTypCode});
            this.grvQuery.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvQuery.GridControl = this.grdQuery;
            this.grvQuery.Name = "grvQuery";
            this.grvQuery.OptionsBehavior.Editable = false;
            this.grvQuery.OptionsCustomization.AllowFilter = false;
            this.grvQuery.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvQuery.OptionsNavigation.AutoFocusNewRow = true;
            this.grvQuery.OptionsNavigation.UseTabKey = false;
            this.grvQuery.OptionsView.ColumnAutoWidth = false;
            this.grvQuery.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvQuery.OptionsView.ShowGroupPanel = false;
            this.grvQuery.OptionsView.ShowIndicator = false;
            // 
            // colBgKostenartID
            // 
            this.colBgKostenartID.Caption = "KOA-ID";
            this.colBgKostenartID.FieldName = "BgKostenartID";
            this.colBgKostenartID.Name = "colBgKostenartID";
            this.colBgKostenartID.Visible = true;
            this.colBgKostenartID.VisibleIndex = 0;
            // 
            // colKontoNr
            // 
            this.colKontoNr.Caption = "Konto-Nr";
            this.colKontoNr.FieldName = "KontoNr";
            this.colKontoNr.Name = "colKontoNr";
            this.colKontoNr.Visible = true;
            this.colKontoNr.VisibleIndex = 1;
            // 
            // colName
            // 
            this.colName.Caption = "Kostenart";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            // 
            // colErfolgAktuellerKontoplan
            // 
            this.colErfolgAktuellerKontoplan.Caption = "Erfolg aktueller Kontoplan";
            this.colErfolgAktuellerKontoplan.FieldName = "ErfolgAktuellerKontoplan";
            this.colErfolgAktuellerKontoplan.Name = "colErfolgAktuellerKontoplan";
            this.colErfolgAktuellerKontoplan.Visible = true;
            this.colErfolgAktuellerKontoplan.VisibleIndex = 3;
            // 
            // colErfolgLetzterKontoplan
            // 
            this.colErfolgLetzterKontoplan.Caption = "Erfolg letzter Kontoplan";
            this.colErfolgLetzterKontoplan.FieldName = "ErfolgLetzterKontoplan";
            this.colErfolgLetzterKontoplan.Name = "colErfolgLetzterKontoplan";
            this.colErfolgLetzterKontoplan.Visible = true;
            this.colErfolgLetzterKontoplan.VisibleIndex = 4;
            // 
            // colGefKategorieTyp
            // 
            this.colGefKategorieTyp.Caption = "GEF-Kategorie-Typ";
            this.colGefKategorieTyp.FieldName = "WhGefKategorieTyp";
            this.colGefKategorieTyp.Name = "colGefKategorieTyp";
            this.colGefKategorieTyp.Visible = true;
            this.colGefKategorieTyp.VisibleIndex = 5;
            // 
            // colGefKategorie
            // 
            this.colGefKategorie.Caption = "GEF-Kategorie";
            this.colGefKategorie.FieldName = "WhGefKategorie";
            this.colGefKategorie.Name = "colGefKategorie";
            this.colGefKategorie.Visible = true;
            this.colGefKategorie.VisibleIndex = 6;
            // 
            // colAlbv
            // 
            this.colAlbv.Caption = "ALBV";
            this.colAlbv.ColumnEdit = this.checkEdit;
            this.colAlbv.FieldName = "IsALBV";
            this.colAlbv.Name = "colAlbv";
            this.colAlbv.Visible = true;
            this.colAlbv.VisibleIndex = 7;
            // 
            // checkEdit
            // 
            this.checkEdit.AutoHeight = false;
            this.checkEdit.Name = "checkEdit";
            this.checkEdit.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.checkEdit.ReadOnly = true;
            // 
            // colZuDe
            // 
            this.colZuDe.Caption = "ZuDe";
            this.colZuDe.ColumnEdit = this.checkEdit;
            this.colZuDe.FieldName = "IsZuDe";
            this.colZuDe.Name = "colZuDe";
            this.colZuDe.Visible = true;
            this.colZuDe.VisibleIndex = 8;
            // 
            // colInkassoprovision
            // 
            this.colInkassoprovision.Caption = "Inkassoprovision";
            this.colInkassoprovision.ColumnEdit = this.checkEdit;
            this.colInkassoprovision.FieldName = "IsInkassoprovision";
            this.colInkassoprovision.Name = "colInkassoprovision";
            this.colInkassoprovision.Visible = true;
            this.colInkassoprovision.VisibleIndex = 9;
            // 
            // colCreator
            // 
            this.colCreator.Caption = "Erfasst von";
            this.colCreator.FieldName = "Creator";
            this.colCreator.Name = "colCreator";
            this.colCreator.Visible = true;
            this.colCreator.VisibleIndex = 10;
            // 
            // colCreated
            // 
            this.colCreated.Caption = "Erfasst am";
            this.colCreated.FieldName = "Created";
            this.colCreated.Name = "colCreated";
            this.colCreated.Visible = true;
            this.colCreated.VisibleIndex = 11;
            // 
            // colModifier
            // 
            this.colModifier.Caption = "Mutiert von";
            this.colModifier.FieldName = "Modifier";
            this.colModifier.Name = "colModifier";
            this.colModifier.Visible = true;
            this.colModifier.VisibleIndex = 12;
            // 
            // colModified
            // 
            this.colModified.Caption = "Mutiert am";
            this.colModified.FieldName = "Modified";
            this.colModified.Name = "colModified";
            this.colModified.Visible = true;
            this.colModified.VisibleIndex = 13;
            // 
            // colBgKostenartWhGefKategorieID
            // 
            this.colBgKostenartWhGefKategorieID.Caption = "BgKostenart_WhGefKategorieID";
            this.colBgKostenartWhGefKategorieID.FieldName = "BgKostenart_WhGefKategorieID";
            this.colBgKostenartWhGefKategorieID.Name = "colBgKostenartWhGefKategorieID";
            // 
            // colWhGefKategorieID
            // 
            this.colWhGefKategorieID.Caption = "WhGefKategorieID";
            this.colWhGefKategorieID.FieldName = "WhGefKategorieID";
            this.colWhGefKategorieID.Name = "colWhGefKategorieID";
            // 
            // colWhGefKategorieCode
            // 
            this.colWhGefKategorieCode.Caption = "WhGefKategorieCode";
            this.colWhGefKategorieCode.FieldName = "WhGefKategorieCode";
            this.colWhGefKategorieCode.Name = "colWhGefKategorieCode";
            // 
            // colWhGefKategorieTypCode
            // 
            this.colWhGefKategorieTypCode.Caption = "WhGefKategorieTypCode";
            this.colWhGefKategorieTypCode.FieldName = "WhGefKategorieTypCode";
            this.colWhGefKategorieTypCode.Name = "colWhGefKategorieTypCode";
            // 
            // CtlAdBgKostenartWhGefKategorie
            // 
            this.ActiveSQLQuery = this.qryQuery;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(400, 400);
            this.Controls.Add(this.panDetail);
            this.Name = "CtlAdBgKostenartWhGefKategorie";
            this.Size = new System.Drawing.Size(810, 635);
            this.Load += new System.EventHandler(this.CtlAdBgKostenartWhGefKategorie_Load);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.panDetail, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgKostenart_WhGefKategorie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenartX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenartX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGefKategorieX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGefKategorieX)).EndInit();
            this.panDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtGefKategorie.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoprovision.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGefKategorie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKostenartID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgKostenartID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.DB.SqlQuery qryBgKostenart_WhGefKategorie;
        private KiSS4.Gui.KissButtonEdit edtKostenartX;
        private KiSS4.Gui.KissLabel lblKostenartX;
        private KiSS4.Gui.KissButtonEdit edtGefKategorieX;
        private KiSS4.Gui.KissLabel lblGefKategorieX;
        private System.Windows.Forms.Panel panDetail;
        private KiSS4.Gui.KissButtonEdit edtGefKategorie;
        private KiSS4.Gui.KissCheckEdit edtInkassoprovision;
        private KiSS4.Gui.KissLabel lblGefKategorie;
        private KiSS4.Gui.KissTextEdit edtKostenart;
        private KiSS4.Gui.KissLabel lblKostenart;
        private KiSS4.Gui.KissCalcEdit edtBgKostenartID;
        private KiSS4.Gui.KissLabel lblBgKostenartID;
        private KiSS4.DB.SqlQuery qryQuery;
        private Gui.KissGrid grdQuery;
        private DevExpress.XtraGrid.Views.Grid.GridView grvQuery;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colKontoNr;
        private DevExpress.XtraGrid.Columns.GridColumn colGefKategorie;
        private DevExpress.XtraGrid.Columns.GridColumn colAlbv;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit checkEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colZuDe;
        private DevExpress.XtraGrid.Columns.GridColumn colInkassoprovision;
        private DevExpress.XtraGrid.Columns.GridColumn colGefKategorieTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colCreator;
        private DevExpress.XtraGrid.Columns.GridColumn colCreated;
        private DevExpress.XtraGrid.Columns.GridColumn colModifier;
        private DevExpress.XtraGrid.Columns.GridColumn colModified;
        private DevExpress.XtraGrid.Columns.GridColumn colBgKostenartID;
        private DevExpress.XtraGrid.Columns.GridColumn colBgKostenartWhGefKategorieID;
        private DevExpress.XtraGrid.Columns.GridColumn colWhGefKategorieID;
        private DevExpress.XtraGrid.Columns.GridColumn colWhGefKategorieCode;
        private DevExpress.XtraGrid.Columns.GridColumn colWhGefKategorieTypCode;
        private DevExpress.XtraGrid.Columns.GridColumn colErfolgAktuellerKontoplan;
        private DevExpress.XtraGrid.Columns.GridColumn colErfolgLetzterKontoplan;
    }
}
