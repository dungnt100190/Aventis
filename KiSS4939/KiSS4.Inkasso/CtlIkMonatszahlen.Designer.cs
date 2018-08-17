namespace KiSS4.Inkasso
{
    public partial class CtlIkMonatszahlen
    {
        private System.ComponentModel.IContainer components;
        
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
        
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlIkMonatszahlen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tabMonatszahlen = new KiSS4.Gui.KissTabControlEx();
            this.tbpEinmalig = new SharpLibrary.WinControls.TabPageEx();
            this.ctlIkMonatszahlenEinmalig = new KiSS4.Inkasso.CtlIkMonatszahlenEinmalig();
            this.tbpSaldoALBV = new SharpLibrary.WinControls.TabPageEx();
            this.ctlIkMonatszahlenSaldo = new KiSS4.Inkasso.CtlIkMonatszahlenSaldo();
            this.tbpVerrechnungskonto = new SharpLibrary.WinControls.TabPageEx();
            this.ctlIkMonatszahlenVerrechnung = new KiSS4.Inkasso.CtlIkMonatszahlenVerrechnung();
            this.tbpMonatsbudget = new SharpLibrary.WinControls.TabPageEx();
            this.btnCreate = new KiSS4.Gui.KissButton();
            this.edtUnterstuertzungsfall = new KiSS4.Gui.KissCheckEdit();
            this.qryMonatszahlen = new KiSS4.DB.SqlQuery(this.components);
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.kissCalcEdit2 = new KiSS4.Gui.KissCalcEdit();
            this.kissDateEdit1 = new KiSS4.Gui.KissDateEdit();
            this.memBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.kissCalcEdit1 = new KiSS4.Gui.KissCalcEdit();
            this.kissCalcEdit3 = new KiSS4.Gui.KissCalcEdit();
            this.grdMonatszahlen = new KiSS4.Gui.KissGrid();
            this.gvwMonatszahlen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMonatJahr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalAliment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colALBV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colALVermittelt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSozialhilfe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKinderzulage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colALBVVerrechnet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiffALBV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIndexVonDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIndexStandbeiBerechnung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonatErledigt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.tabMonatszahlen.SuspendLayout();
            this.tbpEinmalig.SuspendLayout();
            this.tbpSaldoALBV.SuspendLayout();
            this.tbpVerrechnungskonto.SuspendLayout();
            this.tbpMonatsbudget.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtUnterstuertzungsfall.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryMonatszahlen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissCalcEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissDateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissCalcEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissCalcEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMonatszahlen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwMonatszahlen)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            this.SuspendLayout();
            //
            // tabMonatszahlen
            //
            this.tabMonatszahlen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMonatszahlen.Controls.Add(this.tbpEinmalig);
            this.tabMonatszahlen.Controls.Add(this.tbpSaldoALBV);
            this.tabMonatszahlen.Controls.Add(this.tbpVerrechnungskonto);
            this.tabMonatszahlen.Controls.Add(this.tbpMonatsbudget);
            this.tabMonatszahlen.Location = new System.Drawing.Point(0, 27);
            this.tabMonatszahlen.Name = "tabMonatszahlen";
            this.tabMonatszahlen.ShowFixedWidthTooltip = true;
            this.tabMonatszahlen.Size = new System.Drawing.Size(715, 558);
            this.tabMonatszahlen.TabIndex = 0;
            this.tabMonatszahlen.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tbpMonatsbudget,
            this.tbpEinmalig,
            this.tbpVerrechnungskonto,
            this.tbpSaldoALBV});
            this.tabMonatszahlen.TabsLineColor = System.Drawing.Color.Black;
            this.tabMonatszahlen.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabMonatszahlen.Text = "kissTabControlEx1";
            this.tabMonatszahlen.SelectedTabChanging += new System.ComponentModel.CancelEventHandler(this.tabMonatszahlen_SelectedTabChanging);
            this.tabMonatszahlen.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabMonatszahlen_SelectedTabChanged);
            //
            // tbpEinmalig
            //
            this.tbpEinmalig.Controls.Add(this.ctlIkMonatszahlenEinmalig);
            this.tbpEinmalig.Location = new System.Drawing.Point(6, 6);
            this.tbpEinmalig.Name = "tbpEinmalig";
            this.tbpEinmalig.Size = new System.Drawing.Size(703, 520);
            this.tbpEinmalig.TabIndex = 5;
            this.tbpEinmalig.Title = "Einmalige Forderung";
            //
            // ctlIkMonatszahlenEinmalig
            //
            this.ctlIkMonatszahlenEinmalig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlIkMonatszahlenEinmalig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlIkMonatszahlenEinmalig.Location = new System.Drawing.Point(0, 0);
            this.ctlIkMonatszahlenEinmalig.Name = "ctlIkMonatszahlenEinmalig";
            this.ctlIkMonatszahlenEinmalig.Size = new System.Drawing.Size(703, 520);
            this.ctlIkMonatszahlenEinmalig.TabIndex = 0;
            //
            // tbpSaldoALBV
            //
            this.tbpSaldoALBV.Controls.Add(this.ctlIkMonatszahlenSaldo);
            this.tbpSaldoALBV.Location = new System.Drawing.Point(6, 6);
            this.tbpSaldoALBV.Name = "tbpSaldoALBV";
            this.tbpSaldoALBV.Size = new System.Drawing.Size(703, 520);
            this.tbpSaldoALBV.TabIndex = 4;
            this.tbpSaldoALBV.Title = "Saldo ALBV";
            //
            // ctlIkMonatszahlenSaldo
            //
            this.ctlIkMonatszahlenSaldo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlIkMonatszahlenSaldo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlIkMonatszahlenSaldo.Location = new System.Drawing.Point(0, 0);
            this.ctlIkMonatszahlenSaldo.Name = "ctlIkMonatszahlenSaldo";
            this.ctlIkMonatszahlenSaldo.Size = new System.Drawing.Size(703, 520);
            this.ctlIkMonatszahlenSaldo.TabIndex = 0;
            //
            // tbpVerrechnungskonto
            //
            this.tbpVerrechnungskonto.Controls.Add(this.ctlIkMonatszahlenVerrechnung);
            this.tbpVerrechnungskonto.Location = new System.Drawing.Point(6, 6);
            this.tbpVerrechnungskonto.Name = "tbpVerrechnungskonto";
            this.tbpVerrechnungskonto.Size = new System.Drawing.Size(703, 520);
            this.tbpVerrechnungskonto.TabIndex = 1;
            this.tbpVerrechnungskonto.Title = "Verrechnungskonto";
            //
            // ctlIkMonatszahlenVerrechnung
            //
            this.ctlIkMonatszahlenVerrechnung.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlIkMonatszahlenVerrechnung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlIkMonatszahlenVerrechnung.Location = new System.Drawing.Point(0, 0);
            this.ctlIkMonatszahlenVerrechnung.Name = "ctlIkMonatszahlenVerrechnung";
            this.ctlIkMonatszahlenVerrechnung.Size = new System.Drawing.Size(703, 520);
            this.ctlIkMonatszahlenVerrechnung.TabIndex = 0;
            //
            // tbpMonatsbudget
            //
            this.tbpMonatsbudget.Controls.Add(this.btnCreate);
            this.tbpMonatsbudget.Controls.Add(this.edtUnterstuertzungsfall);
            this.tbpMonatsbudget.Controls.Add(this.kissLabel4);
            this.tbpMonatsbudget.Controls.Add(this.kissLabel2);
            this.tbpMonatsbudget.Controls.Add(this.kissLabel3);
            this.tbpMonatsbudget.Controls.Add(this.kissLabel1);
            this.tbpMonatsbudget.Controls.Add(this.kissLabel5);
            this.tbpMonatsbudget.Controls.Add(this.kissCalcEdit2);
            this.tbpMonatsbudget.Controls.Add(this.kissDateEdit1);
            this.tbpMonatsbudget.Controls.Add(this.memBemerkung);
            this.tbpMonatsbudget.Controls.Add(this.kissCalcEdit1);
            this.tbpMonatsbudget.Controls.Add(this.kissCalcEdit3);
            this.tbpMonatsbudget.Controls.Add(this.grdMonatszahlen);
            this.tbpMonatsbudget.Location = new System.Drawing.Point(6, 6);
            this.tbpMonatsbudget.Name = "tbpMonatsbudget";
            this.tbpMonatsbudget.Size = new System.Drawing.Size(703, 520);
            this.tbpMonatsbudget.TabIndex = 0;
            this.tbpMonatsbudget.Title = "Monatsbudget";
            //
            // btnCreate
            //
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Location = new System.Drawing.Point(3, 4);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(179, 24);
            this.btnCreate.TabIndex = 29;
            this.btnCreate.Text = "Monatszahlen neu erstellen";
            this.btnCreate.UseCompatibleTextRendering = true;
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            //
            // edtUnterstuertzungsfall
            //
            this.edtUnterstuertzungsfall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtUnterstuertzungsfall.DataMember = "Unterstuetzungsfall";
            this.edtUnterstuertzungsfall.DataSource = this.qryMonatszahlen;
            this.edtUnterstuertzungsfall.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtUnterstuertzungsfall.Location = new System.Drawing.Point(444, 456);
            this.edtUnterstuertzungsfall.Name = "edtUnterstuertzungsfall";
            this.edtUnterstuertzungsfall.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtUnterstuertzungsfall.Properties.Appearance.Options.UseBackColor = true;
            this.edtUnterstuertzungsfall.Properties.Caption = "Unterstützungsfall";
            this.edtUnterstuertzungsfall.Properties.ReadOnly = true;
            this.edtUnterstuertzungsfall.Size = new System.Drawing.Size(151, 19);
            this.edtUnterstuertzungsfall.TabIndex = 26;
            //
            // qryMonatszahlen
            //
            this.qryMonatszahlen.CanUpdate = true;
            this.qryMonatszahlen.HostControl = this;
            this.qryMonatszahlen.SelectStatement = resources.GetString("qryMonatszahlen.SelectStatement");
            this.qryMonatszahlen.TableName = "IkPosition";
            this.qryMonatszahlen.BeforePost += new System.EventHandler(this.qryMonatszahlen_BeforePost);
            this.qryMonatszahlen.PositionChanged += new System.EventHandler(this.qryMonatszahlen_PositionChanged);
            this.qryMonatszahlen.AfterFill += new System.EventHandler(this.qryMonatszahlen_AfterFill);
            //
            // kissLabel4
            //
            this.kissLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel4.Location = new System.Drawing.Point(3, 381);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(82, 24);
            this.kissLabel4.TabIndex = 25;
            this.kissLabel4.Text = "Total Alimente";
            this.kissLabel4.UseCompatibleTextRendering = true;
            //
            // kissLabel2
            //
            this.kissLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel2.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissLabel2.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel2.Location = new System.Drawing.Point(444, 378);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(103, 26);
            this.kissLabel2.TabIndex = 23;
            this.kissLabel2.Text = "Monat/Jahr bei der Alim Berechnung";
            this.kissLabel2.UseCompatibleTextRendering = true;
            //
            // kissLabel3
            //
            this.kissLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel3.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissLabel3.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel3.Location = new System.Drawing.Point(444, 412);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(112, 28);
            this.kissLabel3.TabIndex = 21;
            this.kissLabel3.Text = "Punktestand bei der Alim  Berechnung";
            this.kissLabel3.UseCompatibleTextRendering = true;
            //
            // kissLabel1
            //
            this.kissLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel1.Location = new System.Drawing.Point(3, 421);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(66, 24);
            this.kissLabel1.TabIndex = 11;
            this.kissLabel1.Text = "Bemerkung";
            this.kissLabel1.UseCompatibleTextRendering = true;
            //
            // kissLabel5
            //
            this.kissLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel5.Location = new System.Drawing.Point(210, 380);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(70, 24);
            this.kissLabel5.TabIndex = 8;
            this.kissLabel5.Text = "Kinderzulagen";
            this.kissLabel5.UseCompatibleTextRendering = true;
            //
            // kissCalcEdit2
            //
            this.kissCalcEdit2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissCalcEdit2.DataMember = "IndexStandBeiBerechnung";
            this.kissCalcEdit2.DataSource = this.qryMonatszahlen;
            this.kissCalcEdit2.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissCalcEdit2.Location = new System.Drawing.Point(562, 416);
            this.kissCalcEdit2.Name = "kissCalcEdit2";
            this.kissCalcEdit2.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.kissCalcEdit2.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissCalcEdit2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissCalcEdit2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissCalcEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.kissCalcEdit2.Properties.Appearance.Options.UseBorderColor = true;
            this.kissCalcEdit2.Properties.Appearance.Options.UseFont = true;
            this.kissCalcEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissCalcEdit2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.kissCalcEdit2.Properties.DisplayFormat.FormatString = "n2";
            this.kissCalcEdit2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.kissCalcEdit2.Properties.EditFormat.FormatString = "n1";
            this.kissCalcEdit2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.kissCalcEdit2.Properties.Mask.EditMask = "n1";
            this.kissCalcEdit2.Properties.ReadOnly = true;
            this.kissCalcEdit2.Size = new System.Drawing.Size(94, 24);
            this.kissCalcEdit2.TabIndex = 5;
            //
            // kissDateEdit1
            //
            this.kissDateEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissDateEdit1.DataMember = "IndexStandDatum";
            this.kissDateEdit1.DataSource = this.qryMonatszahlen;
            this.kissDateEdit1.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissDateEdit1.EditValue = null;
            this.kissDateEdit1.Location = new System.Drawing.Point(562, 382);
            this.kissDateEdit1.Name = "kissDateEdit1";
            this.kissDateEdit1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.kissDateEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissDateEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissDateEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissDateEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.kissDateEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.kissDateEdit1.Properties.Appearance.Options.UseFont = true;
            this.kissDateEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.kissDateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("kissDateEdit1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.kissDateEdit1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.kissDateEdit1.Properties.DisplayFormat.FormatString = "MM.yyyy";
            this.kissDateEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.kissDateEdit1.Properties.EditFormat.FormatString = "MM.yyyy";
            this.kissDateEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.kissDateEdit1.Properties.Mask.EditMask = "MM.yyyy";
            this.kissDateEdit1.Properties.ReadOnly = true;
            this.kissDateEdit1.Properties.ShowToday = false;
            this.kissDateEdit1.Size = new System.Drawing.Size(94, 24);
            this.kissDateEdit1.TabIndex = 4;
            //
            // memBemerkung
            //
            this.memBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.memBemerkung.DataMember = "Bemerkung";
            this.memBemerkung.DataSource = this.qryMonatszahlen;
            this.memBemerkung.Location = new System.Drawing.Point(90, 416);
            this.memBemerkung.Name = "memBemerkung";
            this.memBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.memBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.memBemerkung.Properties.Appearance.Options.UseFont = true;
            this.memBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memBemerkung.Size = new System.Drawing.Size(291, 59);
            this.memBemerkung.TabIndex = 3;
            //
            // kissCalcEdit1
            //
            this.kissCalcEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissCalcEdit1.DataMember = "BetragKiZulage";
            this.kissCalcEdit1.DataSource = this.qryMonatszahlen;
            this.kissCalcEdit1.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissCalcEdit1.Location = new System.Drawing.Point(290, 381);
            this.kissCalcEdit1.Name = "kissCalcEdit1";
            this.kissCalcEdit1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.kissCalcEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissCalcEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissCalcEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissCalcEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.kissCalcEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.kissCalcEdit1.Properties.Appearance.Options.UseFont = true;
            this.kissCalcEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissCalcEdit1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.kissCalcEdit1.Properties.DisplayFormat.FormatString = "N2";
            this.kissCalcEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.kissCalcEdit1.Properties.EditFormat.FormatString = "N2";
            this.kissCalcEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.kissCalcEdit1.Properties.Mask.EditMask = "N2";
            this.kissCalcEdit1.Properties.ReadOnly = true;
            this.kissCalcEdit1.Size = new System.Drawing.Size(91, 24);
            this.kissCalcEdit1.TabIndex = 2;
            //
            // kissCalcEdit3
            //
            this.kissCalcEdit3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissCalcEdit3.DataMember = "TotalAliment";
            this.kissCalcEdit3.DataSource = this.qryMonatszahlen;
            this.kissCalcEdit3.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissCalcEdit3.Location = new System.Drawing.Point(91, 382);
            this.kissCalcEdit3.Name = "kissCalcEdit3";
            this.kissCalcEdit3.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.kissCalcEdit3.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissCalcEdit3.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissCalcEdit3.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissCalcEdit3.Properties.Appearance.Options.UseBackColor = true;
            this.kissCalcEdit3.Properties.Appearance.Options.UseBorderColor = true;
            this.kissCalcEdit3.Properties.Appearance.Options.UseFont = true;
            this.kissCalcEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissCalcEdit3.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.kissCalcEdit3.Properties.DisplayFormat.FormatString = "N2";
            this.kissCalcEdit3.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.kissCalcEdit3.Properties.EditFormat.FormatString = "N2";
            this.kissCalcEdit3.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.kissCalcEdit3.Properties.Mask.EditMask = "N2";
            this.kissCalcEdit3.Properties.ReadOnly = true;
            this.kissCalcEdit3.Size = new System.Drawing.Size(91, 24);
            this.kissCalcEdit3.TabIndex = 1;
            //
            // grdMonatszahlen
            //
            this.grdMonatszahlen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdMonatszahlen.DataSource = this.qryMonatszahlen;
            this.grdMonatszahlen.EmbeddedNavigator.Name = "";
            this.grdMonatszahlen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdMonatszahlen.Location = new System.Drawing.Point(3, 34);
            this.grdMonatszahlen.MainView = this.gvwMonatszahlen;
            this.grdMonatszahlen.Name = "grdMonatszahlen";
            this.grdMonatszahlen.Size = new System.Drawing.Size(697, 330);
            this.grdMonatszahlen.TabIndex = 0;
            this.grdMonatszahlen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwMonatszahlen});
            //
            // gvwMonatszahlen
            //
            this.gvwMonatszahlen.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gvwMonatszahlen.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwMonatszahlen.Appearance.Empty.Options.UseBackColor = true;
            this.gvwMonatszahlen.Appearance.Empty.Options.UseFont = true;
            this.gvwMonatszahlen.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.gvwMonatszahlen.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwMonatszahlen.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvwMonatszahlen.Appearance.EvenRow.Options.UseFont = true;
            this.gvwMonatszahlen.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvwMonatszahlen.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwMonatszahlen.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gvwMonatszahlen.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvwMonatszahlen.Appearance.FocusedCell.Options.UseFont = true;
            this.gvwMonatszahlen.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvwMonatszahlen.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvwMonatszahlen.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwMonatszahlen.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gvwMonatszahlen.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvwMonatszahlen.Appearance.FocusedRow.Options.UseFont = true;
            this.gvwMonatszahlen.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvwMonatszahlen.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gvwMonatszahlen.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gvwMonatszahlen.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gvwMonatszahlen.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvwMonatszahlen.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvwMonatszahlen.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvwMonatszahlen.Appearance.GroupRow.Options.UseFont = true;
            this.gvwMonatszahlen.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvwMonatszahlen.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gvwMonatszahlen.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gvwMonatszahlen.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvwMonatszahlen.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvwMonatszahlen.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gvwMonatszahlen.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvwMonatszahlen.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gvwMonatszahlen.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwMonatszahlen.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvwMonatszahlen.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvwMonatszahlen.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvwMonatszahlen.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvwMonatszahlen.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gvwMonatszahlen.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvwMonatszahlen.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwMonatszahlen.Appearance.OddRow.Options.UseFont = true;
            this.gvwMonatszahlen.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gvwMonatszahlen.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwMonatszahlen.Appearance.Row.Options.UseBackColor = true;
            this.gvwMonatszahlen.Appearance.Row.Options.UseFont = true;
            this.gvwMonatszahlen.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gvwMonatszahlen.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwMonatszahlen.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gvwMonatszahlen.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvwMonatszahlen.Appearance.SelectedRow.Options.UseFont = true;
            this.gvwMonatszahlen.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvwMonatszahlen.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gvwMonatszahlen.Appearance.VertLine.Options.UseBackColor = true;
            this.gvwMonatszahlen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gvwMonatszahlen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMonatJahr,
            this.colPerson,
            this.colTotalAliment,
            this.colALBV,
            this.colALVermittelt,
            this.colSozialhilfe,
            this.colKinderzulage,
            this.colALBVVerrechnet,
            this.colDiffALBV,
            this.colIndexVonDatum,
            this.colIndexStandbeiBerechnung,
            this.colMonatErledigt,
            this.colMonat});
            this.gvwMonatszahlen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gvwMonatszahlen.GridControl = this.grdMonatszahlen;
            this.gvwMonatszahlen.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", null, "")});
            this.gvwMonatszahlen.Name = "gvwMonatszahlen";
            this.gvwMonatszahlen.OptionsBehavior.Editable = false;
            this.gvwMonatszahlen.OptionsCustomization.AllowFilter = false;
            this.gvwMonatszahlen.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gvwMonatszahlen.OptionsNavigation.AutoFocusNewRow = true;
            this.gvwMonatszahlen.OptionsNavigation.UseTabKey = false;
            this.gvwMonatszahlen.OptionsView.ColumnAutoWidth = false;
            this.gvwMonatszahlen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvwMonatszahlen.OptionsView.ShowGroupPanel = false;
            this.gvwMonatszahlen.OptionsView.ShowIndicator = false;
            this.gvwMonatszahlen.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gvwMonatszahlen_CustomDrawCell);
            //
            // colMonatJahr
            //
            this.colMonatJahr.Caption = "Monat";
            this.colMonatJahr.DisplayFormat.FormatString = "yyyy.MM";
            this.colMonatJahr.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colMonatJahr.FieldName = "JahrMonat";
            this.colMonatJahr.Name = "colMonatJahr";
            this.colMonatJahr.OptionsColumn.AllowEdit = false;
            this.colMonatJahr.Visible = true;
            this.colMonatJahr.VisibleIndex = 0;
            this.colMonatJahr.Width = 65;
            //
            // colPerson
            //
            this.colPerson.Caption = " Person, Gläubiger";
            this.colPerson.FieldName = "Person";
            this.colPerson.Name = "colPerson";
            this.colPerson.OptionsColumn.AllowEdit = false;
            this.colPerson.Visible = true;
            this.colPerson.VisibleIndex = 1;
            this.colPerson.Width = 144;
            //
            // colTotalAliment
            //
            this.colTotalAliment.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalAliment.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colTotalAliment.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotalAliment.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colTotalAliment.Caption = "Aliment";
            this.colTotalAliment.DisplayFormat.FormatString = "N2";
            this.colTotalAliment.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalAliment.FieldName = "TotalAliment";
            this.colTotalAliment.Name = "colTotalAliment";
            this.colTotalAliment.Visible = true;
            this.colTotalAliment.VisibleIndex = 2;
            this.colTotalAliment.Width = 65;
            //
            // colALBV
            //
            this.colALBV.AppearanceCell.Options.UseTextOptions = true;
            this.colALBV.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colALBV.AppearanceHeader.Options.UseTextOptions = true;
            this.colALBV.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colALBV.Caption = "ALBV";
            this.colALBV.DisplayFormat.FormatString = "N2";
            this.colALBV.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colALBV.FieldName = "BetragALBV_Calc";
            this.colALBV.Name = "colALBV";
            this.colALBV.Visible = true;
            this.colALBV.VisibleIndex = 3;
            this.colALBV.Width = 65;
            //
            // colALVermittelt
            //
            this.colALVermittelt.AppearanceCell.Options.UseTextOptions = true;
            this.colALVermittelt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colALVermittelt.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
            this.colALVermittelt.AppearanceHeader.Options.UseFont = true;
            this.colALVermittelt.AppearanceHeader.Options.UseTextOptions = true;
            this.colALVermittelt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colALVermittelt.Caption = "Vermittelt ";
            this.colALVermittelt.DisplayFormat.FormatString = "N2";
            this.colALVermittelt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colALVermittelt.FieldName = "BetragVermittelt_Calc";
            this.colALVermittelt.Name = "colALVermittelt";
            this.colALVermittelt.Visible = true;
            this.colALVermittelt.VisibleIndex = 4;
            this.colALVermittelt.Width = 65;
            //
            // colSozialhilfe
            //
            this.colSozialhilfe.Caption = "SH";
            this.colSozialhilfe.DisplayFormat.FormatString = "N2";
            this.colSozialhilfe.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSozialhilfe.FieldName = "BetragSozialhilfe_Calc";
            this.colSozialhilfe.Name = "colSozialhilfe";
            this.colSozialhilfe.Visible = true;
            this.colSozialhilfe.VisibleIndex = 5;
            this.colSozialhilfe.Width = 65;
            //
            // colKinderzulage
            //
            this.colKinderzulage.AppearanceCell.Options.UseTextOptions = true;
            this.colKinderzulage.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colKinderzulage.AppearanceHeader.Options.UseTextOptions = true;
            this.colKinderzulage.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colKinderzulage.Caption = "Kinderzul.";
            this.colKinderzulage.DisplayFormat.FormatString = "N2";
            this.colKinderzulage.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colKinderzulage.FieldName = "BetragKiZulage";
            this.colKinderzulage.Name = "colKinderzulage";
            this.colKinderzulage.Visible = true;
            this.colKinderzulage.VisibleIndex = 6;
            this.colKinderzulage.Width = 65;
            //
            // colALBVVerrechnet
            //
            this.colALBVVerrechnet.AppearanceCell.Options.UseTextOptions = true;
            this.colALBVVerrechnet.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colALBVVerrechnet.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
            this.colALBVVerrechnet.AppearanceHeader.Options.UseFont = true;
            this.colALBVVerrechnet.AppearanceHeader.Options.UseTextOptions = true;
            this.colALBVVerrechnet.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colALBVVerrechnet.Caption = "Verrechnet";
            this.colALBVVerrechnet.DisplayFormat.FormatString = "N2";
            this.colALBVVerrechnet.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colALBVVerrechnet.FieldName = "BetragALBVverrechnung";
            this.colALBVVerrechnet.Name = "colALBVVerrechnet";
            this.colALBVVerrechnet.Visible = true;
            this.colALBVVerrechnet.VisibleIndex = 7;
            this.colALBVVerrechnet.Width = 65;
            //
            // colDiffALBV
            //
            this.colDiffALBV.AppearanceCell.Options.UseTextOptions = true;
            this.colDiffALBV.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colDiffALBV.AppearanceHeader.Options.UseTextOptions = true;
            this.colDiffALBV.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colDiffALBV.Caption = "Zahlung";
            this.colDiffALBV.DisplayFormat.FormatString = "N2";
            this.colDiffALBV.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDiffALBV.FieldName = "BetragDiffALBV_Calc";
            this.colDiffALBV.Name = "colDiffALBV";
            this.colDiffALBV.Visible = true;
            this.colDiffALBV.VisibleIndex = 8;
            this.colDiffALBV.Width = 65;
            //
            // colIndexVonDatum
            //
            this.colIndexVonDatum.AppearanceCell.Options.UseTextOptions = true;
            this.colIndexVonDatum.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colIndexVonDatum.AppearanceHeader.Options.UseTextOptions = true;
            this.colIndexVonDatum.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colIndexVonDatum.Caption = "Index ";
            this.colIndexVonDatum.DisplayFormat.FormatString = "MM.yyyy";
            this.colIndexVonDatum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colIndexVonDatum.FieldName = "IndexStandDatum";
            this.colIndexVonDatum.Name = "colIndexVonDatum";
            this.colIndexVonDatum.Visible = true;
            this.colIndexVonDatum.VisibleIndex = 9;
            this.colIndexVonDatum.Width = 62;
            //
            // colIndexStandbeiBerechnung
            //
            this.colIndexStandbeiBerechnung.Caption = "Punkte";
            this.colIndexStandbeiBerechnung.DisplayFormat.FormatString = "N2";
            this.colIndexStandbeiBerechnung.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colIndexStandbeiBerechnung.FieldName = "IndexStandBeiBerechnung";
            this.colIndexStandbeiBerechnung.Name = "colIndexStandbeiBerechnung";
            this.colIndexStandbeiBerechnung.Visible = true;
            this.colIndexStandbeiBerechnung.VisibleIndex = 10;
            this.colIndexStandbeiBerechnung.Width = 49;
            //
            // colMonatErledigt
            //
            this.colMonatErledigt.Caption = "erl";
            this.colMonatErledigt.FieldName = "ErledigterMonat";
            this.colMonatErledigt.Name = "colMonatErledigt";
            this.colMonatErledigt.Visible = true;
            this.colMonatErledigt.VisibleIndex = 11;
            this.colMonatErledigt.Width = 27;
            //
            // colMonat
            //
            this.colMonat.Caption = "Monat";
            this.colMonat.FieldName = "Monat";
            this.colMonat.Name = "colMonat";
            //
            // panel1
            //
            this.panel1.Controls.Add(this.picTitel);
            this.panel1.Controls.Add(this.lblTitel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(720, 24);
            this.panel1.TabIndex = 1;
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
            this.lblTitel.Text = "Monatszahlen ";
            this.lblTitel.UseCompatibleTextRendering = true;
            //
            // CtlIkMonatszahlen
            //
            this.ActiveSQLQuery = this.qryMonatszahlen;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabMonatszahlen);
            this.Name = "CtlIkMonatszahlen";
            this.Size = new System.Drawing.Size(720, 588);
            this.tabMonatszahlen.ResumeLayout(false);
            this.tbpEinmalig.ResumeLayout(false);
            this.tbpSaldoALBV.ResumeLayout(false);
            this.tbpVerrechnungskonto.ResumeLayout(false);
            this.tbpMonatsbudget.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtUnterstuertzungsfall.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryMonatszahlen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissCalcEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissDateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissCalcEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissCalcEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMonatszahlen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwMonatszahlen)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private KiSS4.Gui.KissButton btnCreate;
        private DevExpress.XtraGrid.Columns.GridColumn colALBV;
        private DevExpress.XtraGrid.Columns.GridColumn colALBVVerrechnet;
        private DevExpress.XtraGrid.Columns.GridColumn colALVermittelt;
        private DevExpress.XtraGrid.Columns.GridColumn colDiffALBV;
        private DevExpress.XtraGrid.Columns.GridColumn colIndexStandbeiBerechnung;
        private DevExpress.XtraGrid.Columns.GridColumn colIndexVonDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colKinderzulage;
        private DevExpress.XtraGrid.Columns.GridColumn colMonat;
        private DevExpress.XtraGrid.Columns.GridColumn colMonatErledigt;
        private DevExpress.XtraGrid.Columns.GridColumn colMonatJahr;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colSozialhilfe;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalAliment;
        private KiSS4.Inkasso.CtlIkMonatszahlenEinmalig ctlIkMonatszahlenEinmalig;
        private KiSS4.Inkasso.CtlIkMonatszahlenSaldo ctlIkMonatszahlenSaldo;
        private KiSS4.Inkasso.CtlIkMonatszahlenVerrechnung ctlIkMonatszahlenVerrechnung;
        private KiSS4.Gui.KissCheckEdit edtUnterstuertzungsfall;
        private KiSS4.Gui.KissGrid grdMonatszahlen;
        private DevExpress.XtraGrid.Views.Grid.GridView gvwMonatszahlen;
        private KiSS4.Gui.KissCalcEdit kissCalcEdit1;
        private KiSS4.Gui.KissCalcEdit kissCalcEdit2;
        private KiSS4.Gui.KissCalcEdit kissCalcEdit3;
        private KiSS4.Gui.KissDateEdit kissDateEdit1;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissLabel kissLabel3;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel kissLabel5;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissMemoEdit memBemerkung;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryMonatszahlen;
        private KiSS4.Gui.KissTabControlEx tabMonatszahlen;
        private SharpLibrary.WinControls.TabPageEx tbpEinmalig;
        private SharpLibrary.WinControls.TabPageEx tbpMonatsbudget;
        private SharpLibrary.WinControls.TabPageEx tbpSaldoALBV;
        private SharpLibrary.WinControls.TabPageEx tbpVerrechnungskonto;
    }
}