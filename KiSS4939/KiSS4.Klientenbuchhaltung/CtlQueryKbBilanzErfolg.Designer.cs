namespace KiSS4.Klientenbuchhaltung
{
    partial class CtlQueryKbBilanzErfolg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryKbBilanzErfolg));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.components = new System.ComponentModel.Container();
            this.treUebersicht = new KiSS4.Gui.KissTree();
            this.colUebersichtKonto = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colVorsaldo = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colUebersichtUmsatz = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSaldo = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colUebersichtTotal = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.qryBilanzErfolg = new KiSS4.DB.SqlQuery();
            this.imgListIcons = new System.Windows.Forms.ImageList();
            this.btnUebersichtExpand = new KiSS4.Gui.KissButton();
            this.btnUebersichtCollapse = new KiSS4.Gui.KissButton();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblSucheDatumVon = new KiSS4.Gui.KissLabel();
            this.lblSucheDatumBis = new KiSS4.Gui.KissLabel();
            this.panUebersichtButtons = new System.Windows.Forms.Panel();
            this.edtNurMitBuchungen = new KiSS4.Gui.KissCheckEdit();
            this.edtOhneKtoGruppen = new KiSS4.Gui.KissCheckEdit();
            this.tpgBilanz = new SharpLibrary.WinControls.TabPageEx();
            this.treBilanz = new KiSS4.Gui.KissTree();
            this.colBilanzKonto = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colBilanzBestandPerVon = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colBilanzZuwachs = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colBilanzAbgang = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colBilanzBestandPerBis = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.panBilanzButtons = new System.Windows.Forms.Panel();
            this.btnBilanzExpand = new KiSS4.Gui.KissButton();
            this.btnBilanzCollapse = new KiSS4.Gui.KissButton();
            this.tpgErfolg = new SharpLibrary.WinControls.TabPageEx();
            this.treErfolg = new KiSS4.Gui.KissTree();
            this.colErfolgKonto = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colErfolgAufwand = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colErfolgErtrag = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.panErfolgButtons = new System.Windows.Forms.Panel();
            this.btnErfolgExpand = new KiSS4.Gui.KissButton();
            this.btnErfolgCollapse = new KiSS4.Gui.KissButton();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treUebersicht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBilanzErfolg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumBis)).BeginInit();
            this.panUebersichtButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurMitBuchungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOhneKtoGruppen.Properties)).BeginInit();
            this.tpgBilanz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treBilanz)).BeginInit();
            this.panBilanzButtons.SuspendLayout();
            this.tpgErfolg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treErfolg)).BeginInit();
            this.panErfolgButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(817, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Controls.Add(this.tpgBilanz);
            this.tabControlSearch.Controls.Add(this.tpgErfolg);
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.SelectedTabIndex = 3;
            this.tabControlSearch.Size = new System.Drawing.Size(841, 411);
            this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgBilanz,
            this.tpgErfolg});
            this.tabControlSearch.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControlSearch_SelectedTabChanged);
            this.tabControlSearch.SelectedTabChanging += new System.ComponentModel.CancelEventHandler(this.tabControlSearch_SelectedTabChanging);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgSuchen, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgErfolg, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgBilanz, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe, 0);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.treUebersicht);
            this.tpgListe.Controls.Add(this.panUebersichtButtons);
            this.tpgListe.Size = new System.Drawing.Size(829, 373);
            this.tpgListe.Title = "Ü&bersicht";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtOhneKtoGruppen);
            this.tpgSuchen.Controls.Add(this.edtNurMitBuchungen);
            this.tpgSuchen.Controls.Add(this.lblSucheDatumBis);
            this.tpgSuchen.Controls.Add(this.lblSucheDatumVon);
            this.tpgSuchen.Controls.Add(this.edtDatumBis);
            this.tpgSuchen.Controls.Add(this.edtDatumVon);
            this.tpgSuchen.Size = new System.Drawing.Size(829, 373);
            this.tpgSuchen.TabIndex = 3;
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNurMitBuchungen, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtOhneKtoGruppen, 0);
            // 
            // treUebersicht
            // 
            this.treUebersicht.AllowSortTree = true;
            this.treUebersicht.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.treUebersicht.Appearance.Empty.ForeColor = System.Drawing.Color.White;
            this.treUebersicht.Appearance.Empty.Options.UseBackColor = true;
            this.treUebersicht.Appearance.Empty.Options.UseForeColor = true;
            this.treUebersicht.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(236)))), ((int)(((byte)(215)))));
            this.treUebersicht.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.treUebersicht.Appearance.EvenRow.Options.UseBackColor = true;
            this.treUebersicht.Appearance.EvenRow.Options.UseForeColor = true;
            this.treUebersicht.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
            this.treUebersicht.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.treUebersicht.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treUebersicht.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treUebersicht.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.treUebersicht.Appearance.FocusedRow.Options.UseForeColor = true;
            this.treUebersicht.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treUebersicht.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treUebersicht.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.treUebersicht.Appearance.FooterPanel.Options.UseBackColor = true;
            this.treUebersicht.Appearance.FooterPanel.Options.UseFont = true;
            this.treUebersicht.Appearance.FooterPanel.Options.UseForeColor = true;
            this.treUebersicht.Appearance.GroupButton.BackColor = System.Drawing.Color.Transparent;
            this.treUebersicht.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.treUebersicht.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.treUebersicht.Appearance.GroupButton.Options.UseBackColor = true;
            this.treUebersicht.Appearance.GroupButton.Options.UseFont = true;
            this.treUebersicht.Appearance.GroupButton.Options.UseForeColor = true;
            this.treUebersicht.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(226)))), ((int)(((byte)(184)))));
            this.treUebersicht.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.treUebersicht.Appearance.GroupFooter.Options.UseBackColor = true;
            this.treUebersicht.Appearance.GroupFooter.Options.UseForeColor = true;
            this.treUebersicht.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.treUebersicht.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.treUebersicht.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.treUebersicht.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.treUebersicht.Appearance.HeaderPanel.Options.UseFont = true;
            this.treUebersicht.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.treUebersicht.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.treUebersicht.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treUebersicht.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.treUebersicht.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treUebersicht.Appearance.HideSelectionRow.Options.UseFont = true;
            this.treUebersicht.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.treUebersicht.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treUebersicht.Appearance.HorzLine.ForeColor = System.Drawing.Color.Red;
            this.treUebersicht.Appearance.HorzLine.Options.UseBackColor = true;
            this.treUebersicht.Appearance.HorzLine.Options.UseForeColor = true;
            this.treUebersicht.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.treUebersicht.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treUebersicht.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.treUebersicht.Appearance.OddRow.Options.UseBackColor = true;
            this.treUebersicht.Appearance.OddRow.Options.UseFont = true;
            this.treUebersicht.Appearance.OddRow.Options.UseForeColor = true;
            this.treUebersicht.Appearance.Preview.BackColor = System.Drawing.Color.White;
            this.treUebersicht.Appearance.Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treUebersicht.Appearance.Preview.ForeColor = System.Drawing.Color.Maroon;
            this.treUebersicht.Appearance.Preview.Options.UseBackColor = true;
            this.treUebersicht.Appearance.Preview.Options.UseFont = true;
            this.treUebersicht.Appearance.Preview.Options.UseForeColor = true;
            this.treUebersicht.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.treUebersicht.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treUebersicht.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.treUebersicht.Appearance.Row.Options.UseBackColor = true;
            this.treUebersicht.Appearance.Row.Options.UseFont = true;
            this.treUebersicht.Appearance.Row.Options.UseForeColor = true;
            this.treUebersicht.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.treUebersicht.Appearance.SelectedRow.Options.UseForeColor = true;
            this.treUebersicht.Appearance.TreeLine.BackColor = System.Drawing.Color.Gray;
            this.treUebersicht.Appearance.TreeLine.Options.UseBackColor = true;
            this.treUebersicht.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treUebersicht.Appearance.VertLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(166)))), ((int)(((byte)(70)))));
            this.treUebersicht.Appearance.VertLine.Options.UseBackColor = true;
            this.treUebersicht.Appearance.VertLine.Options.UseForeColor = true;
            this.treUebersicht.Appearance.VertLine.Options.UseTextOptions = true;
            this.treUebersicht.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.treUebersicht.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colUebersichtKonto,
            this.colVorsaldo,
            this.colUebersichtUmsatz,
            this.colSaldo,
            this.colUebersichtTotal});
            this.treUebersicht.DataSource = this.qryBilanzErfolg;
            this.treUebersicht.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treUebersicht.ImageIndexFieldName = "IconIndex";
            this.treUebersicht.KeyFieldName = "KbKontoID";
            this.treUebersicht.Location = new System.Drawing.Point(0, 0);
            this.treUebersicht.Name = "treUebersicht";
            this.treUebersicht.OptionsBehavior.AutoSelectAllInEditor = false;
            this.treUebersicht.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treUebersicht.OptionsBehavior.Editable = false;
            this.treUebersicht.OptionsBehavior.KeepSelectedOnClick = false;
            this.treUebersicht.OptionsBehavior.MoveOnEdit = false;
            this.treUebersicht.OptionsMenu.EnableColumnMenu = false;
            this.treUebersicht.OptionsMenu.EnableFooterMenu = false;
            this.treUebersicht.OptionsPrint.PrintPreview = true;
            this.treUebersicht.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treUebersicht.OptionsView.AutoWidth = false;
            this.treUebersicht.OptionsView.EnableAppearanceEvenRow = true;
            this.treUebersicht.OptionsView.EnableAppearanceOddRow = true;
            this.treUebersicht.OptionsView.ShowIndicator = false;
            this.treUebersicht.ParentFieldName = "GruppeKontoID";
            this.treUebersicht.SelectImageList = this.imgListIcons;
            this.treUebersicht.Size = new System.Drawing.Size(787, 373);
            this.treUebersicht.TabIndex = 0;
            // 
            // colUebersichtKonto
            // 
            this.colUebersichtKonto.Caption = "Konto";
            this.colUebersichtKonto.FieldName = "Konto";
            this.colUebersichtKonto.MinWidth = 27;
            this.colUebersichtKonto.Name = "colUebersichtKonto";
            this.colUebersichtKonto.OptionsColumn.AllowSort = false;
            this.colUebersichtKonto.VisibleIndex = 0;
            this.colUebersichtKonto.Width = 325;
            // 
            // colVorsaldo
            // 
            this.colVorsaldo.AppearanceCell.Options.UseTextOptions = true;
            this.colVorsaldo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colVorsaldo.Caption = "Vorsaldo";
            this.colVorsaldo.FieldName = "Vorsaldo";
            this.colVorsaldo.Format.FormatString = "#,##0.00";
            this.colVorsaldo.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colVorsaldo.Name = "colVorsaldo";
            this.colVorsaldo.OptionsColumn.AllowSort = false;
            this.colVorsaldo.Width = 80;
            // 
            // colUebersichtUmsatz
            // 
            this.colUebersichtUmsatz.Caption = "Umsatz";
            this.colUebersichtUmsatz.FieldName = "Umsatz";
            this.colUebersichtUmsatz.Format.FormatString = "#,##0.00";
            this.colUebersichtUmsatz.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUebersichtUmsatz.Name = "colUebersichtUmsatz";
            this.colUebersichtUmsatz.OptionsColumn.AllowSort = false;
            this.colUebersichtUmsatz.VisibleIndex = 1;
            this.colUebersichtUmsatz.Width = 80;
            // 
            // colSaldo
            // 
            this.colSaldo.Caption = "Saldo";
            this.colSaldo.FieldName = "Saldo";
            this.colSaldo.Format.FormatString = "#,##0.00";
            this.colSaldo.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaldo.Name = "colSaldo";
            this.colSaldo.OptionsColumn.AllowSort = false;
            this.colSaldo.Width = 80;
            // 
            // colUebersichtTotal
            // 
            this.colUebersichtTotal.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colUebersichtTotal.AppearanceCell.Options.UseFont = true;
            this.colUebersichtTotal.Caption = "Total";
            this.colUebersichtTotal.FieldName = "Total";
            this.colUebersichtTotal.Format.FormatString = "#,##0.00";
            this.colUebersichtTotal.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUebersichtTotal.Name = "colUebersichtTotal";
            this.colUebersichtTotal.OptionsColumn.AllowSort = false;
            this.colUebersichtTotal.VisibleIndex = 2;
            this.colUebersichtTotal.Width = 90;
            // 
            // qryBilanzErfolg
            // 
            this.qryBilanzErfolg.FillTimeOut = 300;
            this.qryBilanzErfolg.HostControl = this;
            this.qryBilanzErfolg.SelectStatement = "SELECT 1 WHERE 1 = 0";
            // 
            // imgListIcons
            // 
            this.imgListIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListIcons.ImageStream")));
            this.imgListIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListIcons.Images.SetKeyName(0, "");
            this.imgListIcons.Images.SetKeyName(1, "");
            // 
            // btnUebersichtExpand
            // 
            this.btnUebersichtExpand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUebersichtExpand.Image = ((System.Drawing.Image)(resources.GetObject("btnUebersichtExpand.Image")));
            this.btnUebersichtExpand.Location = new System.Drawing.Point(9, 9);
            this.btnUebersichtExpand.Margin = new System.Windows.Forms.Padding(9, 9, 9, 3);
            this.btnUebersichtExpand.Name = "btnUebersichtExpand";
            this.btnUebersichtExpand.Size = new System.Drawing.Size(24, 24);
            this.btnUebersichtExpand.TabIndex = 0;
            this.btnUebersichtExpand.UseCompatibleTextRendering = true;
            this.btnUebersichtExpand.UseVisualStyleBackColor = false;
            this.btnUebersichtExpand.Click += new System.EventHandler(this.btnUebersichtExpand_Click);
            // 
            // btnUebersichtCollapse
            // 
            this.btnUebersichtCollapse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUebersichtCollapse.Image = ((System.Drawing.Image)(resources.GetObject("btnUebersichtCollapse.Image")));
            this.btnUebersichtCollapse.Location = new System.Drawing.Point(9, 39);
            this.btnUebersichtCollapse.Name = "btnUebersichtCollapse";
            this.btnUebersichtCollapse.Size = new System.Drawing.Size(24, 24);
            this.btnUebersichtCollapse.TabIndex = 1;
            this.btnUebersichtCollapse.UseCompatibleTextRendering = true;
            this.btnUebersichtCollapse.UseVisualStyleBackColor = false;
            this.btnUebersichtCollapse.Click += new System.EventHandler(this.btnUebersichtCollapse_Click);
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(105, 40);
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
            this.edtDatumVon.Properties.Name = "editPerDatum.Properties";
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(95, 24);
            this.edtDatumVon.TabIndex = 2;
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(236, 40);
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
            this.edtDatumBis.Properties.Name = "editPerDatum.Properties";
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(95, 24);
            this.edtDatumBis.TabIndex = 4;
            // 
            // lblSucheDatumVon
            // 
            this.lblSucheDatumVon.Location = new System.Drawing.Point(30, 40);
            this.lblSucheDatumVon.Name = "lblSucheDatumVon";
            this.lblSucheDatumVon.Size = new System.Drawing.Size(69, 24);
            this.lblSucheDatumVon.TabIndex = 1;
            this.lblSucheDatumVon.Text = "Datum von";
            this.lblSucheDatumVon.UseCompatibleTextRendering = true;
            // 
            // lblSucheDatumBis
            // 
            this.lblSucheDatumBis.Location = new System.Drawing.Point(206, 40);
            this.lblSucheDatumBis.Name = "lblSucheDatumBis";
            this.lblSucheDatumBis.Size = new System.Drawing.Size(24, 24);
            this.lblSucheDatumBis.TabIndex = 3;
            this.lblSucheDatumBis.Text = "bis";
            this.lblSucheDatumBis.UseCompatibleTextRendering = true;
            // 
            // panUebersichtButtons
            // 
            this.panUebersichtButtons.Controls.Add(this.btnUebersichtExpand);
            this.panUebersichtButtons.Controls.Add(this.btnUebersichtCollapse);
            this.panUebersichtButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.panUebersichtButtons.Location = new System.Drawing.Point(787, 0);
            this.panUebersichtButtons.Name = "panUebersichtButtons";
            this.panUebersichtButtons.Size = new System.Drawing.Size(42, 373);
            this.panUebersichtButtons.TabIndex = 1;
            // 
            // edtNurMitBuchungen
            // 
            this.edtNurMitBuchungen.EditValue = false;
            this.edtNurMitBuchungen.Location = new System.Drawing.Point(105, 70);
            this.edtNurMitBuchungen.Name = "edtNurMitBuchungen";
            this.edtNurMitBuchungen.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtNurMitBuchungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtNurMitBuchungen.Properties.Caption = "Nur Konti mit Buchungen";
            this.edtNurMitBuchungen.Size = new System.Drawing.Size(226, 19);
            this.edtNurMitBuchungen.TabIndex = 5;
            // 
            // edtOhneKtoGruppen
            // 
            this.edtOhneKtoGruppen.EditValue = false;
            this.edtOhneKtoGruppen.Location = new System.Drawing.Point(105, 95);
            this.edtOhneKtoGruppen.Name = "edtOhneKtoGruppen";
            this.edtOhneKtoGruppen.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtOhneKtoGruppen.Properties.Appearance.Options.UseBackColor = true;
            this.edtOhneKtoGruppen.Properties.Caption = "Ohne Kontogruppen";
            this.edtOhneKtoGruppen.Size = new System.Drawing.Size(226, 19);
            this.edtOhneKtoGruppen.TabIndex = 6;
            // 
            // tpgBilanz
            // 
            this.tpgBilanz.Controls.Add(this.treBilanz);
            this.tpgBilanz.Controls.Add(this.panBilanzButtons);
            this.tpgBilanz.Location = new System.Drawing.Point(6, 6);
            this.tpgBilanz.Name = "tpgBilanz";
            this.tpgBilanz.Size = new System.Drawing.Size(829, 373);
            this.tpgBilanz.TabIndex = 1;
            this.tpgBilanz.Title = "&Bilanz";
            // 
            // treBilanz
            // 
            this.treBilanz.AllowSortTree = true;
            this.treBilanz.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.treBilanz.Appearance.Empty.ForeColor = System.Drawing.Color.White;
            this.treBilanz.Appearance.Empty.Options.UseBackColor = true;
            this.treBilanz.Appearance.Empty.Options.UseForeColor = true;
            this.treBilanz.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(236)))), ((int)(((byte)(215)))));
            this.treBilanz.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.treBilanz.Appearance.EvenRow.Options.UseBackColor = true;
            this.treBilanz.Appearance.EvenRow.Options.UseForeColor = true;
            this.treBilanz.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
            this.treBilanz.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.treBilanz.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treBilanz.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treBilanz.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.treBilanz.Appearance.FocusedRow.Options.UseForeColor = true;
            this.treBilanz.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treBilanz.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treBilanz.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.treBilanz.Appearance.FooterPanel.Options.UseBackColor = true;
            this.treBilanz.Appearance.FooterPanel.Options.UseFont = true;
            this.treBilanz.Appearance.FooterPanel.Options.UseForeColor = true;
            this.treBilanz.Appearance.GroupButton.BackColor = System.Drawing.Color.Transparent;
            this.treBilanz.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.treBilanz.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.treBilanz.Appearance.GroupButton.Options.UseBackColor = true;
            this.treBilanz.Appearance.GroupButton.Options.UseFont = true;
            this.treBilanz.Appearance.GroupButton.Options.UseForeColor = true;
            this.treBilanz.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(226)))), ((int)(((byte)(184)))));
            this.treBilanz.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.treBilanz.Appearance.GroupFooter.Options.UseBackColor = true;
            this.treBilanz.Appearance.GroupFooter.Options.UseForeColor = true;
            this.treBilanz.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.treBilanz.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.treBilanz.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.treBilanz.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.treBilanz.Appearance.HeaderPanel.Options.UseFont = true;
            this.treBilanz.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.treBilanz.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.treBilanz.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treBilanz.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.treBilanz.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treBilanz.Appearance.HideSelectionRow.Options.UseFont = true;
            this.treBilanz.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.treBilanz.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treBilanz.Appearance.HorzLine.ForeColor = System.Drawing.Color.Red;
            this.treBilanz.Appearance.HorzLine.Options.UseBackColor = true;
            this.treBilanz.Appearance.HorzLine.Options.UseForeColor = true;
            this.treBilanz.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.treBilanz.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treBilanz.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.treBilanz.Appearance.OddRow.Options.UseBackColor = true;
            this.treBilanz.Appearance.OddRow.Options.UseFont = true;
            this.treBilanz.Appearance.OddRow.Options.UseForeColor = true;
            this.treBilanz.Appearance.Preview.BackColor = System.Drawing.Color.White;
            this.treBilanz.Appearance.Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treBilanz.Appearance.Preview.ForeColor = System.Drawing.Color.Maroon;
            this.treBilanz.Appearance.Preview.Options.UseBackColor = true;
            this.treBilanz.Appearance.Preview.Options.UseFont = true;
            this.treBilanz.Appearance.Preview.Options.UseForeColor = true;
            this.treBilanz.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.treBilanz.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treBilanz.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.treBilanz.Appearance.Row.Options.UseBackColor = true;
            this.treBilanz.Appearance.Row.Options.UseFont = true;
            this.treBilanz.Appearance.Row.Options.UseForeColor = true;
            this.treBilanz.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.treBilanz.Appearance.SelectedRow.Options.UseForeColor = true;
            this.treBilanz.Appearance.TreeLine.BackColor = System.Drawing.Color.Gray;
            this.treBilanz.Appearance.TreeLine.Options.UseBackColor = true;
            this.treBilanz.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treBilanz.Appearance.VertLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(166)))), ((int)(((byte)(70)))));
            this.treBilanz.Appearance.VertLine.Options.UseBackColor = true;
            this.treBilanz.Appearance.VertLine.Options.UseForeColor = true;
            this.treBilanz.Appearance.VertLine.Options.UseTextOptions = true;
            this.treBilanz.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.treBilanz.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colBilanzKonto,
            this.colBilanzBestandPerVon,
            this.colBilanzZuwachs,
            this.colBilanzAbgang,
            this.colBilanzBestandPerBis});
            this.treBilanz.DataSource = this.qryBilanzErfolg;
            this.treBilanz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treBilanz.ImageIndexFieldName = "IconIndex";
            this.treBilanz.KeyFieldName = "KbKontoID";
            this.treBilanz.Location = new System.Drawing.Point(0, 0);
            this.treBilanz.Name = "treBilanz";
            this.treBilanz.OptionsBehavior.AutoSelectAllInEditor = false;
            this.treBilanz.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treBilanz.OptionsBehavior.Editable = false;
            this.treBilanz.OptionsBehavior.KeepSelectedOnClick = false;
            this.treBilanz.OptionsBehavior.MoveOnEdit = false;
            this.treBilanz.OptionsMenu.EnableColumnMenu = false;
            this.treBilanz.OptionsMenu.EnableFooterMenu = false;
            this.treBilanz.OptionsPrint.PrintPreview = true;
            this.treBilanz.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treBilanz.OptionsView.AutoWidth = false;
            this.treBilanz.OptionsView.EnableAppearanceEvenRow = true;
            this.treBilanz.OptionsView.EnableAppearanceOddRow = true;
            this.treBilanz.OptionsView.ShowIndicator = false;
            this.treBilanz.ParentFieldName = "GruppeKontoID";
            this.treBilanz.SelectImageList = this.imgListIcons;
            this.treBilanz.Size = new System.Drawing.Size(787, 373);
            this.treBilanz.TabIndex = 2;
            // 
            // colBilanzKonto
            // 
            this.colBilanzKonto.Caption = "Konto";
            this.colBilanzKonto.FieldName = "Konto";
            this.colBilanzKonto.MinWidth = 27;
            this.colBilanzKonto.Name = "colBilanzKonto";
            this.colBilanzKonto.OptionsColumn.AllowSort = false;
            this.colBilanzKonto.VisibleIndex = 0;
            this.colBilanzKonto.Width = 325;
            // 
            // colBilanzBestandPerVon
            // 
            this.colBilanzBestandPerVon.Caption = "Bestand per {DatumVon}";
            this.colBilanzBestandPerVon.FieldName = "Anfangsbestand";
            this.colBilanzBestandPerVon.Format.FormatString = "#,##0.00";
            this.colBilanzBestandPerVon.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBilanzBestandPerVon.Name = "colBilanzBestandPerVon";
            this.colBilanzBestandPerVon.OptionsColumn.AllowSort = false;
            this.colBilanzBestandPerVon.VisibleIndex = 1;
            this.colBilanzBestandPerVon.Width = 150;
            // 
            // colBilanzZuwachs
            // 
            this.colBilanzZuwachs.Caption = "Zuwachs";
            this.colBilanzZuwachs.FieldName = "Zuwachs";
            this.colBilanzZuwachs.Format.FormatString = "#,##0.00";
            this.colBilanzZuwachs.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBilanzZuwachs.Name = "colBilanzZuwachs";
            this.colBilanzZuwachs.OptionsColumn.AllowSort = false;
            this.colBilanzZuwachs.VisibleIndex = 2;
            this.colBilanzZuwachs.Width = 90;
            // 
            // colBilanzAbgang
            // 
            this.colBilanzAbgang.Caption = "Abgang";
            this.colBilanzAbgang.FieldName = "Abgang";
            this.colBilanzAbgang.Format.FormatString = "#,##0.00";
            this.colBilanzAbgang.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBilanzAbgang.Name = "colBilanzAbgang";
            this.colBilanzAbgang.OptionsColumn.AllowSort = false;
            this.colBilanzAbgang.VisibleIndex = 3;
            this.colBilanzAbgang.Width = 90;
            // 
            // colBilanzBestandPerBis
            // 
            this.colBilanzBestandPerBis.Caption = "Bestand per {DatumBis}";
            this.colBilanzBestandPerBis.FieldName = "Endbestand";
            this.colBilanzBestandPerBis.Format.FormatString = "#,##0.00";
            this.colBilanzBestandPerBis.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBilanzBestandPerBis.Name = "colBilanzBestandPerBis";
            this.colBilanzBestandPerBis.OptionsColumn.AllowSort = false;
            this.colBilanzBestandPerBis.VisibleIndex = 4;
            this.colBilanzBestandPerBis.Width = 150;
            // 
            // panBilanzButtons
            // 
            this.panBilanzButtons.Controls.Add(this.btnBilanzExpand);
            this.panBilanzButtons.Controls.Add(this.btnBilanzCollapse);
            this.panBilanzButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.panBilanzButtons.Location = new System.Drawing.Point(787, 0);
            this.panBilanzButtons.Name = "panBilanzButtons";
            this.panBilanzButtons.Size = new System.Drawing.Size(42, 373);
            this.panBilanzButtons.TabIndex = 3;
            // 
            // btnBilanzExpand
            // 
            this.btnBilanzExpand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBilanzExpand.Image = ((System.Drawing.Image)(resources.GetObject("btnBilanzExpand.Image")));
            this.btnBilanzExpand.Location = new System.Drawing.Point(9, 9);
            this.btnBilanzExpand.Margin = new System.Windows.Forms.Padding(9, 9, 9, 3);
            this.btnBilanzExpand.Name = "btnBilanzExpand";
            this.btnBilanzExpand.Size = new System.Drawing.Size(24, 24);
            this.btnBilanzExpand.TabIndex = 0;
            this.btnBilanzExpand.UseCompatibleTextRendering = true;
            this.btnBilanzExpand.UseVisualStyleBackColor = false;
            this.btnBilanzExpand.Click += new System.EventHandler(this.btnBilanzExpand_Click);
            // 
            // btnBilanzCollapse
            // 
            this.btnBilanzCollapse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBilanzCollapse.Image = ((System.Drawing.Image)(resources.GetObject("btnBilanzCollapse.Image")));
            this.btnBilanzCollapse.Location = new System.Drawing.Point(9, 39);
            this.btnBilanzCollapse.Name = "btnBilanzCollapse";
            this.btnBilanzCollapse.Size = new System.Drawing.Size(24, 24);
            this.btnBilanzCollapse.TabIndex = 1;
            this.btnBilanzCollapse.UseCompatibleTextRendering = true;
            this.btnBilanzCollapse.UseVisualStyleBackColor = false;
            this.btnBilanzCollapse.Click += new System.EventHandler(this.btnBilanzCollapse_Click);
            // 
            // tpgErfolg
            // 
            this.tpgErfolg.Controls.Add(this.treErfolg);
            this.tpgErfolg.Controls.Add(this.panErfolgButtons);
            this.tpgErfolg.Location = new System.Drawing.Point(6, 6);
            this.tpgErfolg.Name = "tpgErfolg";
            this.tpgErfolg.Size = new System.Drawing.Size(829, 373);
            this.tpgErfolg.TabIndex = 2;
            this.tpgErfolg.Title = "&Erfolg";
            // 
            // treErfolg
            // 
            this.treErfolg.AllowSortTree = true;
            this.treErfolg.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.treErfolg.Appearance.Empty.ForeColor = System.Drawing.Color.White;
            this.treErfolg.Appearance.Empty.Options.UseBackColor = true;
            this.treErfolg.Appearance.Empty.Options.UseForeColor = true;
            this.treErfolg.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(236)))), ((int)(((byte)(215)))));
            this.treErfolg.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.treErfolg.Appearance.EvenRow.Options.UseBackColor = true;
            this.treErfolg.Appearance.EvenRow.Options.UseForeColor = true;
            this.treErfolg.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
            this.treErfolg.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.treErfolg.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treErfolg.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treErfolg.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.treErfolg.Appearance.FocusedRow.Options.UseForeColor = true;
            this.treErfolg.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treErfolg.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treErfolg.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.treErfolg.Appearance.FooterPanel.Options.UseBackColor = true;
            this.treErfolg.Appearance.FooterPanel.Options.UseFont = true;
            this.treErfolg.Appearance.FooterPanel.Options.UseForeColor = true;
            this.treErfolg.Appearance.GroupButton.BackColor = System.Drawing.Color.Transparent;
            this.treErfolg.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.treErfolg.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.treErfolg.Appearance.GroupButton.Options.UseBackColor = true;
            this.treErfolg.Appearance.GroupButton.Options.UseFont = true;
            this.treErfolg.Appearance.GroupButton.Options.UseForeColor = true;
            this.treErfolg.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(226)))), ((int)(((byte)(184)))));
            this.treErfolg.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.treErfolg.Appearance.GroupFooter.Options.UseBackColor = true;
            this.treErfolg.Appearance.GroupFooter.Options.UseForeColor = true;
            this.treErfolg.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.treErfolg.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.treErfolg.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.treErfolg.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.treErfolg.Appearance.HeaderPanel.Options.UseFont = true;
            this.treErfolg.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.treErfolg.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.treErfolg.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treErfolg.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.treErfolg.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treErfolg.Appearance.HideSelectionRow.Options.UseFont = true;
            this.treErfolg.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.treErfolg.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treErfolg.Appearance.HorzLine.ForeColor = System.Drawing.Color.Red;
            this.treErfolg.Appearance.HorzLine.Options.UseBackColor = true;
            this.treErfolg.Appearance.HorzLine.Options.UseForeColor = true;
            this.treErfolg.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.treErfolg.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treErfolg.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.treErfolg.Appearance.OddRow.Options.UseBackColor = true;
            this.treErfolg.Appearance.OddRow.Options.UseFont = true;
            this.treErfolg.Appearance.OddRow.Options.UseForeColor = true;
            this.treErfolg.Appearance.Preview.BackColor = System.Drawing.Color.White;
            this.treErfolg.Appearance.Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treErfolg.Appearance.Preview.ForeColor = System.Drawing.Color.Maroon;
            this.treErfolg.Appearance.Preview.Options.UseBackColor = true;
            this.treErfolg.Appearance.Preview.Options.UseFont = true;
            this.treErfolg.Appearance.Preview.Options.UseForeColor = true;
            this.treErfolg.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.treErfolg.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treErfolg.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.treErfolg.Appearance.Row.Options.UseBackColor = true;
            this.treErfolg.Appearance.Row.Options.UseFont = true;
            this.treErfolg.Appearance.Row.Options.UseForeColor = true;
            this.treErfolg.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.treErfolg.Appearance.SelectedRow.Options.UseForeColor = true;
            this.treErfolg.Appearance.TreeLine.BackColor = System.Drawing.Color.Gray;
            this.treErfolg.Appearance.TreeLine.Options.UseBackColor = true;
            this.treErfolg.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treErfolg.Appearance.VertLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(166)))), ((int)(((byte)(70)))));
            this.treErfolg.Appearance.VertLine.Options.UseBackColor = true;
            this.treErfolg.Appearance.VertLine.Options.UseForeColor = true;
            this.treErfolg.Appearance.VertLine.Options.UseTextOptions = true;
            this.treErfolg.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.treErfolg.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colErfolgKonto,
            this.colErfolgAufwand,
            this.colErfolgErtrag});
            this.treErfolg.DataSource = this.qryBilanzErfolg;
            this.treErfolg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treErfolg.ImageIndexFieldName = "IconIndex";
            this.treErfolg.KeyFieldName = "KbKontoID";
            this.treErfolg.Location = new System.Drawing.Point(0, 0);
            this.treErfolg.Name = "treErfolg";
            this.treErfolg.OptionsBehavior.AutoSelectAllInEditor = false;
            this.treErfolg.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treErfolg.OptionsBehavior.Editable = false;
            this.treErfolg.OptionsBehavior.KeepSelectedOnClick = false;
            this.treErfolg.OptionsBehavior.MoveOnEdit = false;
            this.treErfolg.OptionsMenu.EnableColumnMenu = false;
            this.treErfolg.OptionsMenu.EnableFooterMenu = false;
            this.treErfolg.OptionsPrint.PrintPreview = true;
            this.treErfolg.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treErfolg.OptionsView.AutoWidth = false;
            this.treErfolg.OptionsView.EnableAppearanceEvenRow = true;
            this.treErfolg.OptionsView.EnableAppearanceOddRow = true;
            this.treErfolg.OptionsView.ShowIndicator = false;
            this.treErfolg.ParentFieldName = "GruppeKontoID";
            this.treErfolg.SelectImageList = this.imgListIcons;
            this.treErfolg.Size = new System.Drawing.Size(787, 373);
            this.treErfolg.TabIndex = 4;
            // 
            // colErfolgKonto
            // 
            this.colErfolgKonto.Caption = "Konto";
            this.colErfolgKonto.FieldName = "Konto";
            this.colErfolgKonto.MinWidth = 27;
            this.colErfolgKonto.Name = "colErfolgKonto";
            this.colErfolgKonto.OptionsColumn.AllowSort = false;
            this.colErfolgKonto.VisibleIndex = 0;
            this.colErfolgKonto.Width = 325;
            // 
            // colErfolgAufwand
            // 
            this.colErfolgAufwand.Caption = "Aufwand";
            this.colErfolgAufwand.FieldName = "Aufwand";
            this.colErfolgAufwand.Format.FormatString = "#,##0.00";
            this.colErfolgAufwand.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colErfolgAufwand.Name = "colErfolgAufwand";
            this.colErfolgAufwand.OptionsColumn.AllowSort = false;
            this.colErfolgAufwand.VisibleIndex = 1;
            this.colErfolgAufwand.Width = 90;
            // 
            // colErfolgErtrag
            // 
            this.colErfolgErtrag.Caption = "Ertrag";
            this.colErfolgErtrag.FieldName = "Ertrag";
            this.colErfolgErtrag.Format.FormatString = "#,##0.00";
            this.colErfolgErtrag.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colErfolgErtrag.Name = "colErfolgErtrag";
            this.colErfolgErtrag.OptionsColumn.AllowSort = false;
            this.colErfolgErtrag.VisibleIndex = 2;
            this.colErfolgErtrag.Width = 90;
            // 
            // panErfolgButtons
            // 
            this.panErfolgButtons.Controls.Add(this.btnErfolgExpand);
            this.panErfolgButtons.Controls.Add(this.btnErfolgCollapse);
            this.panErfolgButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.panErfolgButtons.Location = new System.Drawing.Point(787, 0);
            this.panErfolgButtons.Name = "panErfolgButtons";
            this.panErfolgButtons.Size = new System.Drawing.Size(42, 373);
            this.panErfolgButtons.TabIndex = 5;
            // 
            // btnErfolgExpand
            // 
            this.btnErfolgExpand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnErfolgExpand.Image = ((System.Drawing.Image)(resources.GetObject("btnErfolgExpand.Image")));
            this.btnErfolgExpand.Location = new System.Drawing.Point(9, 9);
            this.btnErfolgExpand.Margin = new System.Windows.Forms.Padding(9, 9, 9, 3);
            this.btnErfolgExpand.Name = "btnErfolgExpand";
            this.btnErfolgExpand.Size = new System.Drawing.Size(24, 24);
            this.btnErfolgExpand.TabIndex = 0;
            this.btnErfolgExpand.UseCompatibleTextRendering = true;
            this.btnErfolgExpand.UseVisualStyleBackColor = false;
            this.btnErfolgExpand.Click += new System.EventHandler(this.btnErfolgExpand_Click);
            // 
            // btnErfolgCollapse
            // 
            this.btnErfolgCollapse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnErfolgCollapse.Image = ((System.Drawing.Image)(resources.GetObject("btnErfolgCollapse.Image")));
            this.btnErfolgCollapse.Location = new System.Drawing.Point(9, 39);
            this.btnErfolgCollapse.Name = "btnErfolgCollapse";
            this.btnErfolgCollapse.Size = new System.Drawing.Size(24, 24);
            this.btnErfolgCollapse.TabIndex = 1;
            this.btnErfolgCollapse.UseCompatibleTextRendering = true;
            this.btnErfolgCollapse.UseVisualStyleBackColor = false;
            this.btnErfolgCollapse.Click += new System.EventHandler(this.btnErfolgCollapse_Click);
            // 
            // CtlQueryKbBilanzErfolg
            // 
            this.ActiveSQLQuery = this.qryBilanzErfolg;
            this.Name = "CtlQueryKbBilanzErfolg";
            this.Size = new System.Drawing.Size(841, 411);
            this.Load += new System.EventHandler(this.CtlQueryKbBilanzErfolg_Load);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treUebersicht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBilanzErfolg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumBis)).EndInit();
            this.panUebersichtButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtNurMitBuchungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOhneKtoGruppen.Properties)).EndInit();
            this.tpgBilanz.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treBilanz)).EndInit();
            this.panBilanzButtons.ResumeLayout(false);
            this.tpgErfolg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treErfolg)).EndInit();
            this.panErfolgButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panUebersichtButtons;
        private Gui.KissCheckEdit edtNurMitBuchungen;
        private Gui.KissCheckEdit edtOhneKtoGruppen;
        private SharpLibrary.WinControls.TabPageEx tpgBilanz;
        private SharpLibrary.WinControls.TabPageEx tpgErfolg;
        private Gui.KissTree treBilanz;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colBilanzKonto;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colBilanzBestandPerVon;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colBilanzZuwachs;
        private System.Windows.Forms.Panel panBilanzButtons;
        private Gui.KissButton btnBilanzExpand;
        private Gui.KissButton btnBilanzCollapse;
        private Gui.KissTree treErfolg;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colErfolgKonto;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colErfolgAufwand;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colErfolgErtrag;
        private System.Windows.Forms.Panel panErfolgButtons;
        private Gui.KissButton btnErfolgExpand;
        private Gui.KissButton btnErfolgCollapse;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colBilanzAbgang;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colBilanzBestandPerBis;
        private KiSS4.Gui.KissButton btnUebersichtCollapse;
        private KiSS4.Gui.KissButton btnUebersichtExpand;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colUebersichtKonto;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSaldo;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colUebersichtTotal;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colUebersichtUmsatz;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colVorsaldo;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private System.Windows.Forms.ImageList imgListIcons;
        private KiSS4.Gui.KissLabel lblSucheDatumVon;
        private KiSS4.Gui.KissLabel lblSucheDatumBis;
        private KiSS4.DB.SqlQuery qryBilanzErfolg;
        private KiSS4.Gui.KissTree treUebersicht;
    }
}
