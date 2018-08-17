namespace KiSS4.Vormundschaft
{
    partial class CtlVmBarauszahlungErfolgt
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlVmBarauszahlungErfolgt));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panTitle = new System.Windows.Forms.Panel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.grdFbErfolgteBarauszahlungen = new KiSS4.Gui.KissGrid();
            this.qryVmErfolgteBA = new KiSS4.DB.SqlQuery(this.components);
            this.grvFbErfolgteBarauszahlungen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBewilligtDurch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtSucheBetragVon = new KiSS4.Gui.KissTextEdit();
            this.edtSucheBetragBis = new KiSS4.Gui.KissTextEdit();
            this.edtSucheText = new KiSS4.Gui.KissTextEdit();
            this.edtSucheDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtSucheDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblSucheBetragVon = new KiSS4.Gui.KissLabel();
            this.lblSucheBetragBis = new KiSS4.Gui.KissLabel();
            this.lblSucheDatumVon = new KiSS4.Gui.KissLabel();
            this.lblSucheDatumBis = new KiSS4.Gui.KissLabel();
            this.lblSucheText = new KiSS4.Gui.KissLabel();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            this.panTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFbErfolgteBarauszahlungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVmErfolgteBA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFbErfolgteBarauszahlungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBetragVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBetragBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBetragVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBetragBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheText)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(776, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 35);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(800, 465);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdFbErfolgteBarauszahlungen);
            this.tpgListe.Size = new System.Drawing.Size(788, 427);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.lblSucheBetragVon);
            this.tpgSuchen.Controls.Add(this.lblSucheDatumBis);
            this.tpgSuchen.Controls.Add(this.lblSucheText);
            this.tpgSuchen.Controls.Add(this.lblSucheBetragBis);
            this.tpgSuchen.Controls.Add(this.lblSucheDatumVon);
            this.tpgSuchen.Controls.Add(this.edtSucheDatumBis);
            this.tpgSuchen.Controls.Add(this.edtSucheText);
            this.tpgSuchen.Controls.Add(this.edtSucheDatumVon);
            this.tpgSuchen.Controls.Add(this.edtSucheBetragBis);
            this.tpgSuchen.Controls.Add(this.edtSucheBetragVon);
            this.tpgSuchen.Size = new System.Drawing.Size(788, 427);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBetragVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBetragBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheText, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBetragBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheText, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBetragVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            // 
            // panTitle
            // 
            this.panTitle.Controls.Add(this.picTitel);
            this.panTitle.Controls.Add(this.lblTitel);
            this.panTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitle.Location = new System.Drawing.Point(0, 0);
            this.panTitle.Name = "panTitle";
            this.panTitle.Size = new System.Drawing.Size(800, 35);
            this.panTitle.TabIndex = 1;
            // 
            // picTitel
            // 
            this.picTitel.Location = new System.Drawing.Point(6, 11);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 364;
            this.picTitel.TabStop = false;
            // 
            // lblTitel
            // 
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(26, 11);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(542, 19);
            this.lblTitel.TabIndex = 363;
            this.lblTitel.Text = "Erfolgte Barauszahlungen";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // grdFbErfolgteBarauszahlungen
            // 
            this.grdFbErfolgteBarauszahlungen.DataSource = this.qryVmErfolgteBA;
            this.grdFbErfolgteBarauszahlungen.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdFbErfolgteBarauszahlungen.EmbeddedNavigator.Name = "";
            this.grdFbErfolgteBarauszahlungen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdFbErfolgteBarauszahlungen.Location = new System.Drawing.Point(0, 0);
            this.grdFbErfolgteBarauszahlungen.MainView = this.grvFbErfolgteBarauszahlungen;
            this.grdFbErfolgteBarauszahlungen.Name = "grdFbErfolgteBarauszahlungen";
            this.grdFbErfolgteBarauszahlungen.Size = new System.Drawing.Size(788, 427);
            this.grdFbErfolgteBarauszahlungen.TabIndex = 0;
            this.grdFbErfolgteBarauszahlungen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvFbErfolgteBarauszahlungen});
            // 
            // qryVmErfolgteBA
            // 
            this.qryVmErfolgteBA.HostControl = this;
            // 
            // grvFbErfolgteBarauszahlungen
            // 
            this.grvFbErfolgteBarauszahlungen.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvFbErfolgteBarauszahlungen.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbErfolgteBarauszahlungen.Appearance.Empty.Options.UseBackColor = true;
            this.grvFbErfolgteBarauszahlungen.Appearance.Empty.Options.UseFont = true;
            this.grvFbErfolgteBarauszahlungen.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbErfolgteBarauszahlungen.Appearance.EvenRow.Options.UseFont = true;
            this.grvFbErfolgteBarauszahlungen.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFbErfolgteBarauszahlungen.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbErfolgteBarauszahlungen.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvFbErfolgteBarauszahlungen.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvFbErfolgteBarauszahlungen.Appearance.FocusedCell.Options.UseFont = true;
            this.grvFbErfolgteBarauszahlungen.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvFbErfolgteBarauszahlungen.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFbErfolgteBarauszahlungen.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbErfolgteBarauszahlungen.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvFbErfolgteBarauszahlungen.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvFbErfolgteBarauszahlungen.Appearance.FocusedRow.Options.UseFont = true;
            this.grvFbErfolgteBarauszahlungen.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvFbErfolgteBarauszahlungen.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFbErfolgteBarauszahlungen.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvFbErfolgteBarauszahlungen.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFbErfolgteBarauszahlungen.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbErfolgteBarauszahlungen.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFbErfolgteBarauszahlungen.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvFbErfolgteBarauszahlungen.Appearance.GroupRow.Options.UseFont = true;
            this.grvFbErfolgteBarauszahlungen.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvFbErfolgteBarauszahlungen.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvFbErfolgteBarauszahlungen.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvFbErfolgteBarauszahlungen.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbErfolgteBarauszahlungen.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvFbErfolgteBarauszahlungen.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvFbErfolgteBarauszahlungen.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvFbErfolgteBarauszahlungen.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvFbErfolgteBarauszahlungen.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbErfolgteBarauszahlungen.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFbErfolgteBarauszahlungen.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvFbErfolgteBarauszahlungen.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvFbErfolgteBarauszahlungen.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvFbErfolgteBarauszahlungen.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvFbErfolgteBarauszahlungen.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvFbErfolgteBarauszahlungen.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbErfolgteBarauszahlungen.Appearance.OddRow.Options.UseFont = true;
            this.grvFbErfolgteBarauszahlungen.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvFbErfolgteBarauszahlungen.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbErfolgteBarauszahlungen.Appearance.Row.Options.UseBackColor = true;
            this.grvFbErfolgteBarauszahlungen.Appearance.Row.Options.UseFont = true;
            this.grvFbErfolgteBarauszahlungen.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbErfolgteBarauszahlungen.Appearance.SelectedRow.Options.UseFont = true;
            this.grvFbErfolgteBarauszahlungen.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvFbErfolgteBarauszahlungen.Appearance.VertLine.Options.UseBackColor = true;
            this.grvFbErfolgteBarauszahlungen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvFbErfolgteBarauszahlungen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatum,
            this.colText,
            this.colBewilligtDurch,
            this.colBetrag});
            this.grvFbErfolgteBarauszahlungen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvFbErfolgteBarauszahlungen.GridControl = this.grdFbErfolgteBarauszahlungen;
            this.grvFbErfolgteBarauszahlungen.Name = "grvFbErfolgteBarauszahlungen";
            this.grvFbErfolgteBarauszahlungen.OptionsBehavior.Editable = false;
            this.grvFbErfolgteBarauszahlungen.OptionsCustomization.AllowFilter = false;
            this.grvFbErfolgteBarauszahlungen.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvFbErfolgteBarauszahlungen.OptionsNavigation.AutoFocusNewRow = true;
            this.grvFbErfolgteBarauszahlungen.OptionsNavigation.UseTabKey = false;
            this.grvFbErfolgteBarauszahlungen.OptionsView.ColumnAutoWidth = false;
            this.grvFbErfolgteBarauszahlungen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvFbErfolgteBarauszahlungen.OptionsView.ShowGroupPanel = false;
            this.grvFbErfolgteBarauszahlungen.OptionsView.ShowIndicator = false;
            // 
            // colDatum
            // 
            this.colDatum.Caption = "Datum";
            this.colDatum.Name = "colDatum";
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 0;
            this.colDatum.Width = 82;
            // 
            // colText
            // 
            this.colText.Caption = "Text";
            this.colText.Name = "colText";
            this.colText.Visible = true;
            this.colText.VisibleIndex = 1;
            this.colText.Width = 201;
            // 
            // colBewilligtDurch
            // 
            this.colBewilligtDurch.Caption = "Bewilligt durch";
            this.colBewilligtDurch.Name = "colBewilligtDurch";
            this.colBewilligtDurch.Visible = true;
            this.colBewilligtDurch.VisibleIndex = 2;
            this.colBewilligtDurch.Width = 123;
            // 
            // colBetrag
            // 
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 3;
            this.colBetrag.Width = 138;
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.DisplayFormat.FormatString = "n2";
            // 
            // edtSucheBetragVon
            // 
            this.edtSucheBetragVon.Location = new System.Drawing.Point(116, 40);
            this.edtSucheBetragVon.Name = "edtSucheBetragVon";
            this.edtSucheBetragVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBetragVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBetragVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBetragVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBetragVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBetragVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBetragVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheBetragVon.Size = new System.Drawing.Size(120, 24);
            this.edtSucheBetragVon.TabIndex = 1;
            // 
            // edtSucheBetragBis
            // 
            this.edtSucheBetragBis.Location = new System.Drawing.Point(366, 40);
            this.edtSucheBetragBis.Name = "edtSucheBetragBis";
            this.edtSucheBetragBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBetragBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBetragBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBetragBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBetragBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBetragBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBetragBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheBetragBis.Size = new System.Drawing.Size(120, 24);
            this.edtSucheBetragBis.TabIndex = 2;
            // 
            // edtSucheText
            // 
            this.edtSucheText.Location = new System.Drawing.Point(116, 100);
            this.edtSucheText.Name = "edtSucheText";
            this.edtSucheText.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheText.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheText.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheText.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheText.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheText.Properties.Appearance.Options.UseFont = true;
            this.edtSucheText.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheText.Size = new System.Drawing.Size(370, 24);
            this.edtSucheText.TabIndex = 5;
            // 
            // edtSucheDatumVon
            // 
            this.edtSucheDatumVon.EditValue = null;
            this.edtSucheDatumVon.Location = new System.Drawing.Point(116, 70);
            this.edtSucheDatumVon.Name = "edtSucheDatumVon";
            this.edtSucheDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtSucheDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtSucheDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheDatumVon.Properties.ShowToday = false;
            this.edtSucheDatumVon.Size = new System.Drawing.Size(120, 24);
            this.edtSucheDatumVon.TabIndex = 3;
            // 
            // edtSucheDatumBis
            // 
            this.edtSucheDatumBis.EditValue = null;
            this.edtSucheDatumBis.Location = new System.Drawing.Point(366, 70);
            this.edtSucheDatumBis.Name = "edtSucheDatumBis";
            this.edtSucheDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSucheDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSucheDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheDatumBis.Properties.ShowToday = false;
            this.edtSucheDatumBis.Size = new System.Drawing.Size(120, 24);
            this.edtSucheDatumBis.TabIndex = 4;
            // 
            // lblSucheBetragVon
            // 
            this.lblSucheBetragVon.Location = new System.Drawing.Point(30, 40);
            this.lblSucheBetragVon.Name = "lblSucheBetragVon";
            this.lblSucheBetragVon.Size = new System.Drawing.Size(80, 24);
            this.lblSucheBetragVon.TabIndex = 6;
            this.lblSucheBetragVon.Text = "Betrag von";
            // 
            // lblSucheBetragBis
            // 
            this.lblSucheBetragBis.Location = new System.Drawing.Point(280, 40);
            this.lblSucheBetragBis.Name = "lblSucheBetragBis";
            this.lblSucheBetragBis.Size = new System.Drawing.Size(80, 24);
            this.lblSucheBetragBis.TabIndex = 7;
            this.lblSucheBetragBis.Text = "Betrag bis";
            // 
            // lblSucheDatumVon
            // 
            this.lblSucheDatumVon.Location = new System.Drawing.Point(30, 70);
            this.lblSucheDatumVon.Name = "lblSucheDatumVon";
            this.lblSucheDatumVon.Size = new System.Drawing.Size(80, 24);
            this.lblSucheDatumVon.TabIndex = 8;
            this.lblSucheDatumVon.Text = "Datum von";
            // 
            // lblSucheDatumBis
            // 
            this.lblSucheDatumBis.Location = new System.Drawing.Point(280, 70);
            this.lblSucheDatumBis.Name = "lblSucheDatumBis";
            this.lblSucheDatumBis.Size = new System.Drawing.Size(80, 24);
            this.lblSucheDatumBis.TabIndex = 9;
            this.lblSucheDatumBis.Text = "Datum bis";
            // 
            // lblSucheText
            // 
            this.lblSucheText.Location = new System.Drawing.Point(30, 100);
            this.lblSucheText.Name = "lblSucheText";
            this.lblSucheText.Size = new System.Drawing.Size(80, 24);
            this.lblSucheText.TabIndex = 10;
            this.lblSucheText.Text = "Text";
            // 
            // CtlVmBarauszahlungErfolgt
            // 
            this.ActiveSQLQuery = this.qryVmErfolgteBA;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.panTitle);
            this.Name = "CtlVmBarauszahlungErfolgt";
            this.Load += new System.EventHandler(this.CtlVmBarauszahlungErfolgt_Load);
            this.Controls.SetChildIndex(this.panTitle, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            this.panTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFbErfolgteBarauszahlungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVmErfolgteBA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFbErfolgteBarauszahlungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBetragVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBetragBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBetragVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBetragBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheText)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panTitle;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissGrid grdFbErfolgteBarauszahlungen;
        private DevExpress.XtraGrid.Views.Grid.GridView grvFbErfolgteBarauszahlungen;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colText;
        private DevExpress.XtraGrid.Columns.GridColumn colBewilligtDurch;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private KiSS4.Gui.KissTextEdit edtSucheBetragBis;
        private KiSS4.Gui.KissTextEdit edtSucheBetragVon;
        private KiSS4.Gui.KissLabel lblSucheBetragVon;
        private KiSS4.Gui.KissLabel lblSucheText;
        private KiSS4.Gui.KissLabel lblSucheDatumBis;
        private KiSS4.Gui.KissLabel lblSucheBetragBis;
        private KiSS4.Gui.KissLabel lblSucheDatumVon;
        private KiSS4.Gui.KissDateEdit edtSucheDatumBis;
        private KiSS4.Gui.KissDateEdit edtSucheDatumVon;
        private KiSS4.Gui.KissTextEdit edtSucheText;
        private KiSS4.DB.SqlQuery qryVmErfolgteBA;
    }
}
