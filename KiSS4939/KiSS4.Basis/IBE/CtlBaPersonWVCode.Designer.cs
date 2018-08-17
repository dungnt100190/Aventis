namespace KiSS4.Basis.IBE
{
    partial class CtlBaPersonWVCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBaPersonWVCode));
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.grdBaWVCode = new KiSS4.Gui.KissGrid();
            this.ddlWVCode = new KiSS4.Gui.KissLookUpEdit();
            this.ddlBED = new KiSS4.Gui.KissLookUpEdit();
            this.ddlStatus = new KiSS4.Gui.KissLookUpEdit();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.edtSKZNummer = new KiSS4.Gui.KissTextEdit();
            this.edtRekurs = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblWVCode = new KiSS4.Gui.KissLabel();
            this.lblGueltigVon = new KiSS4.Gui.KissLabel();
            this.lblBis = new KiSS4.Gui.KissLabel();
            this.lblRekurs = new KiSS4.Gui.KissLabel();
            this.kissLabel90 = new KiSS4.Gui.KissLabel();
            this.lblBED = new KiSS4.Gui.KissLabel();
            this.lblStatus = new KiSS4.Gui.KissLabel();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.lblSKZNummer = new KiSS4.Gui.KissLabel();
            this.edtErledigt = new KiSS4.Gui.KissCheckEdit();
            this.lblVerfahren = new KiSS4.Gui.KissLabel();
            this.colBED = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSKZNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWVCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grvBaWVCode = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.qryBaWVCode = new KiSS4.DB.SqlQuery(this.components);
            this.qryStatus = new KiSS4.DB.SqlQuery(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaWVCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlWVCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlWVCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlBED)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlBED.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSKZNummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRekurs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWVCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGueltigVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRekurs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel90)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBED)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSKZNummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErledigt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerfahren)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaWVCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaWVCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryStatus)).BeginInit();
            this.SuspendLayout();
            //
            // edtDatumVon
            //
            this.edtDatumVon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDatumVon.DataMember = "DatumVon";
            this.edtDatumVon.DataSource = this.qryBaWVCode;
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(98, 432);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, null)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.Name = "kissDateEdit8.Properties";
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 0;
            //
            // grdBaWVCode
            //
            this.grdBaWVCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBaWVCode.DataSource = this.qryBaWVCode;
            this.grdBaWVCode.EmbeddedNavigator.Name = "kissGrid4.EmbeddedNavigator";
            this.grdBaWVCode.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBaWVCode.Location = new System.Drawing.Point(3, 25);
            this.grdBaWVCode.MainView = this.grvBaWVCode;
            this.grdBaWVCode.Name = "grdBaWVCode";
            this.grdBaWVCode.Size = new System.Drawing.Size(699, 374);
            this.grdBaWVCode.TabIndex = 0;
            this.grdBaWVCode.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                        this.grvBaWVCode});
            //
            // ddlWVCode
            //
            this.ddlWVCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ddlWVCode.DataMember = "WVCode";
            this.ddlWVCode.DataSource = this.qryBaWVCode;
            this.ddlWVCode.Location = new System.Drawing.Point(98, 462);
            this.ddlWVCode.Name = "ddlWVCode";
            this.ddlWVCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlWVCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlWVCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlWVCode.Properties.Appearance.Options.UseBackColor = true;
            this.ddlWVCode.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlWVCode.Properties.Appearance.Options.UseFont = true;
            this.ddlWVCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlWVCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlWVCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlWVCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlWVCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.ddlWVCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlWVCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlWVCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                        new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.ddlWVCode.Properties.DisplayMember = "Text";
            this.ddlWVCode.Properties.Name = "kissLookUpEdit5.Properties";
            this.ddlWVCode.Properties.NullText = "";
            this.ddlWVCode.Properties.ShowFooter = false;
            this.ddlWVCode.Properties.ShowHeader = false;
            this.ddlWVCode.Properties.ValueMember = "Code";
            this.ddlWVCode.Size = new System.Drawing.Size(308, 24);
            this.ddlWVCode.TabIndex = 1;
            this.ddlWVCode.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.ddlWVCode_CloseUp);
            this.ddlWVCode.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.ddlWVCode_EditValueChanging);
            //
            // ddlBED
            //
            this.ddlBED.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ddlBED.DataMember = "BaBedID";
            this.ddlBED.DataSource = this.qryBaWVCode;
            this.ddlBED.Location = new System.Drawing.Point(98, 492);
            this.ddlBED.Name = "ddlBED";
            this.ddlBED.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlBED.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlBED.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlBED.Properties.Appearance.Options.UseBackColor = true;
            this.ddlBED.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlBED.Properties.Appearance.Options.UseFont = true;
            this.ddlBED.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlBED.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlBED.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlBED.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlBED.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.ddlBED.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlBED.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlBED.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                        new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.ddlBED.Properties.DisplayMember = "Text";
            this.ddlBED.Properties.NullText = "";
            this.ddlBED.Properties.ShowFooter = false;
            this.ddlBED.Properties.ShowHeader = false;
            this.ddlBED.Properties.ValueMember = "Code";
            this.ddlBED.Size = new System.Drawing.Size(308, 24);
            this.ddlBED.TabIndex = 2;
            //
            // ddlStatus
            //
            this.ddlStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ddlStatus.DataMember = "StatusCode";
            this.ddlStatus.DataSource = this.qryBaWVCode;
            this.ddlStatus.Location = new System.Drawing.Point(486, 432);
            this.ddlStatus.LOVName = "BaWVStatus";
            this.ddlStatus.Name = "ddlStatus";
            this.ddlStatus.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlStatus.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlStatus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlStatus.Properties.Appearance.Options.UseBackColor = true;
            this.ddlStatus.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlStatus.Properties.Appearance.Options.UseFont = true;
            this.ddlStatus.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlStatus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlStatus.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlStatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.ddlStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlStatus.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlStatus.Properties.NullText = "";
            this.ddlStatus.Properties.ShowFooter = false;
            this.ddlStatus.Properties.ShowHeader = false;
            this.ddlStatus.Size = new System.Drawing.Size(100, 24);
            this.ddlStatus.TabIndex = 2;
            //
            // edtBemerkung
            //
            this.edtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryBaWVCode;
            this.edtBemerkung.Location = new System.Drawing.Point(486, 463);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(188, 51);
            this.edtBemerkung.TabIndex = 3;
            //
            // edtSKZNummer
            //
            this.edtSKZNummer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSKZNummer.DataMember = "SKZNummer";
            this.edtSKZNummer.DataSource = this.qryBaWVCode;
            this.edtSKZNummer.Location = new System.Drawing.Point(486, 520);
            this.edtSKZNummer.Name = "edtSKZNummer";
            this.edtSKZNummer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSKZNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSKZNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSKZNummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtSKZNummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSKZNummer.Properties.Appearance.Options.UseFont = true;
            this.edtSKZNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSKZNummer.Size = new System.Drawing.Size(188, 24);
            this.edtSKZNummer.TabIndex = 4;
            //
            // edtRekurs
            //
            this.edtRekurs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtRekurs.DataMember = "DatumRekurs";
            this.edtRekurs.DataSource = this.qryBaWVCode;
            this.edtRekurs.EditValue = null;
            this.edtRekurs.Location = new System.Drawing.Point(98, 522);
            this.edtRekurs.Name = "edtRekurs";
            this.edtRekurs.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtRekurs.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtRekurs.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtRekurs.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtRekurs.Properties.Appearance.Options.UseBackColor = true;
            this.edtRekurs.Properties.Appearance.Options.UseBorderColor = true;
            this.edtRekurs.Properties.Appearance.Options.UseFont = true;
            this.edtRekurs.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtRekurs.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, null)});
            this.edtRekurs.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtRekurs.Properties.Name = "kissDateEdit10.Properties";
            this.edtRekurs.Properties.ShowToday = false;
            this.edtRekurs.Size = new System.Drawing.Size(100, 24);
            this.edtRekurs.TabIndex = 5;
            //
            // edtDatumBis
            //
            this.edtDatumBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDatumBis.DataMember = "DatumBis";
            this.edtDatumBis.DataSource = this.qryBaWVCode;
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(240, 432);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, null)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.Name = "kissDateEdit9.Properties";
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 6;
            //
            // lblWVCode
            //
            this.lblWVCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWVCode.Location = new System.Drawing.Point(6, 462);
            this.lblWVCode.Name = "lblWVCode";
            this.lblWVCode.Size = new System.Drawing.Size(80, 24);
            this.lblWVCode.TabIndex = 96;
            this.lblWVCode.Text = "WV-Code";
            this.lblWVCode.UseCompatibleTextRendering = true;
            //
            // lblGueltigVon
            //
            this.lblGueltigVon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGueltigVon.Location = new System.Drawing.Point(6, 432);
            this.lblGueltigVon.Name = "lblGueltigVon";
            this.lblGueltigVon.Size = new System.Drawing.Size(72, 24);
            this.lblGueltigVon.TabIndex = 99;
            this.lblGueltigVon.Text = "Gültig ab";
            this.lblGueltigVon.UseCompatibleTextRendering = true;
            //
            // lblBis
            //
            this.lblBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBis.Location = new System.Drawing.Point(204, 432);
            this.lblBis.Name = "lblBis";
            this.lblBis.Size = new System.Drawing.Size(30, 24);
            this.lblBis.TabIndex = 101;
            this.lblBis.Text = "bis";
            this.lblBis.UseCompatibleTextRendering = true;
            //
            // lblRekurs
            //
            this.lblRekurs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRekurs.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblRekurs.Location = new System.Drawing.Point(6, 518);
            this.lblRekurs.Name = "lblRekurs";
            this.lblRekurs.Size = new System.Drawing.Size(86, 16);
            this.lblRekurs.TabIndex = 103;
            this.lblRekurs.Text = "Rekurshängiges ";
            this.lblRekurs.UseCompatibleTextRendering = true;
            //
            // kissLabel90
            //
            this.kissLabel90.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel90.Location = new System.Drawing.Point(3, 6);
            this.kissLabel90.Name = "kissLabel90";
            this.kissLabel90.Size = new System.Drawing.Size(100, 16);
            this.kissLabel90.TabIndex = 106;
            this.kissLabel90.Text = "WV-Code";
            this.kissLabel90.UseCompatibleTextRendering = true;
            //
            // lblBED
            //
            this.lblBED.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBED.Location = new System.Drawing.Point(6, 492);
            this.lblBED.Name = "lblBED";
            this.lblBED.Size = new System.Drawing.Size(72, 24);
            this.lblBED.TabIndex = 107;
            this.lblBED.Text = "BED";
            this.lblBED.UseCompatibleTextRendering = true;
            //
            // lblStatus
            //
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.Location = new System.Drawing.Point(411, 432);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(43, 24);
            this.lblStatus.TabIndex = 111;
            this.lblStatus.Text = "Status";
            this.lblStatus.UseCompatibleTextRendering = true;
            //
            // lblBemerkung
            //
            this.lblBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBemerkung.Location = new System.Drawing.Point(412, 462);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(61, 24);
            this.lblBemerkung.TabIndex = 113;
            this.lblBemerkung.Text = "Bemerkung";
            this.lblBemerkung.UseCompatibleTextRendering = true;
            //
            // lblSKZNummer
            //
            this.lblSKZNummer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSKZNummer.Location = new System.Drawing.Point(411, 522);
            this.lblSKZNummer.Name = "lblSKZNummer";
            this.lblSKZNummer.Size = new System.Drawing.Size(69, 24);
            this.lblSKZNummer.TabIndex = 115;
            this.lblSKZNummer.Text = "SKZ-Nummer";
            this.lblSKZNummer.UseCompatibleTextRendering = true;
            //
            // edtErledigt
            //
            this.edtErledigt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtErledigt.EditValue = false;
            this.edtErledigt.Location = new System.Drawing.Point(204, 524);
            this.edtErledigt.Name = "edtErledigt";
            this.edtErledigt.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtErledigt.Properties.Appearance.Options.UseBackColor = true;
            this.edtErledigt.Properties.Caption = "Rekurs abgeschlossen";
            this.edtErledigt.Size = new System.Drawing.Size(157, 19);
            this.edtErledigt.TabIndex = 118;
            //
            // lblVerfahren
            //
            this.lblVerfahren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVerfahren.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblVerfahren.Location = new System.Drawing.Point(6, 533);
            this.lblVerfahren.Name = "lblVerfahren";
            this.lblVerfahren.Size = new System.Drawing.Size(86, 23);
            this.lblVerfahren.TabIndex = 120;
            this.lblVerfahren.Text = "Verfahren";
            this.lblVerfahren.UseCompatibleTextRendering = true;
            //
            // colBED
            //
            this.colBED.Caption = "BED";
            this.colBED.FieldName = "BaBedID";
            this.colBED.Name = "colBED";
            this.colBED.Visible = true;
            this.colBED.VisibleIndex = 3;
            this.colBED.Width = 172;
            //
            // colDatumBis
            //
            this.colDatumBis.Caption = "bis";
            this.colDatumBis.FieldName = "DatumBis";
            this.colDatumBis.Name = "colDatumBis";
            this.colDatumBis.Visible = true;
            this.colDatumBis.VisibleIndex = 1;
            //
            // colDatumVon
            //
            this.colDatumVon.Caption = "ab";
            this.colDatumVon.FieldName = "DatumVon";
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.Visible = true;
            this.colDatumVon.VisibleIndex = 0;
            this.colDatumVon.Width = 83;
            //
            // colSKZNummer
            //
            this.colSKZNummer.Caption = "SKZ-Nummer";
            this.colSKZNummer.FieldName = "SKZNummer";
            this.colSKZNummer.Name = "colSKZNummer";
            this.colSKZNummer.Visible = true;
            this.colSKZNummer.VisibleIndex = 4;
            this.colSKZNummer.Width = 146;
            //
            // colStatus
            //
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "StatusCode";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 5;
            //
            // colWVCode
            //
            this.colWVCode.Caption = "WV-Code";
            this.colWVCode.FieldName = "WVCode";
            this.colWVCode.Name = "colWVCode";
            this.colWVCode.Visible = true;
            this.colWVCode.VisibleIndex = 2;
            this.colWVCode.Width = 145;
            //
            // grvBaWVCode
            //
            this.grvBaWVCode.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBaWVCode.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWVCode.Appearance.Empty.Options.UseBackColor = true;
            this.grvBaWVCode.Appearance.Empty.Options.UseFont = true;
            this.grvBaWVCode.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWVCode.Appearance.EvenRow.Options.UseFont = true;
            this.grvBaWVCode.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaWVCode.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWVCode.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBaWVCode.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBaWVCode.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBaWVCode.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBaWVCode.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaWVCode.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWVCode.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBaWVCode.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBaWVCode.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBaWVCode.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBaWVCode.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaWVCode.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBaWVCode.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaWVCode.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaWVCode.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaWVCode.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBaWVCode.Appearance.GroupRow.Options.UseFont = true;
            this.grvBaWVCode.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBaWVCode.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBaWVCode.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBaWVCode.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaWVCode.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBaWVCode.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBaWVCode.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBaWVCode.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBaWVCode.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWVCode.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaWVCode.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBaWVCode.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBaWVCode.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBaWVCode.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaWVCode.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBaWVCode.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWVCode.Appearance.OddRow.Options.UseFont = true;
            this.grvBaWVCode.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBaWVCode.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWVCode.Appearance.Row.Options.UseBackColor = true;
            this.grvBaWVCode.Appearance.Row.Options.UseFont = true;
            this.grvBaWVCode.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWVCode.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBaWVCode.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaWVCode.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBaWVCode.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBaWVCode.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                        this.colDatumVon,
                        this.colDatumBis,
                        this.colWVCode,
                        this.colBED,
                        this.colSKZNummer,
                        this.colStatus});
            this.grvBaWVCode.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBaWVCode.GridControl = this.grdBaWVCode;
            this.grvBaWVCode.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvBaWVCode.Name = "grvBaWVCode";
            this.grvBaWVCode.OptionsBehavior.Editable = false;
            this.grvBaWVCode.OptionsCustomization.AllowFilter = false;
            this.grvBaWVCode.OptionsFilter.AllowFilterEditor = false;
            this.grvBaWVCode.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBaWVCode.OptionsMenu.EnableColumnMenu = false;
            this.grvBaWVCode.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBaWVCode.OptionsNavigation.UseTabKey = false;
            this.grvBaWVCode.OptionsView.ColumnAutoWidth = false;
            this.grvBaWVCode.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBaWVCode.OptionsView.ShowGroupPanel = false;
            this.grvBaWVCode.OptionsView.ShowIndicator = false;
            //
            // qryBaWVCode
            //
            this.qryBaWVCode.CanDelete = true;
            this.qryBaWVCode.CanInsert = true;
            this.qryBaWVCode.CanUpdate = true;
            this.qryBaWVCode.HostControl = this;
            this.qryBaWVCode.SelectStatement = "SELECT *\r\nFROM BaWVCode\r\nWHERE BaPersonID = {0}";
            this.qryBaWVCode.TableName = "BaWVCode";
            this.qryBaWVCode.BeforePost += new System.EventHandler(this.qryBaWVCode_BeforePost);
            this.qryBaWVCode.PositionChanged += new System.EventHandler(this.qryBaWVCode_PositionChanged);
            this.qryBaWVCode.AfterInsert += new System.EventHandler(this.qryBaWVCode_AfterInsert);
            this.qryBaWVCode.BeforeInsert += new System.EventHandler(this.qryBaWVCode_BeforeInsert);
            this.qryBaWVCode.AfterPost += new System.EventHandler(this.qryBaWVCode_AfterPost);
            //
            // qryStatus
            //
            this.qryStatus.HostControl = this;
            this.qryStatus.SelectStatement = resources.GetString("qryStatus.SelectStatement");
            //
            // CtlBaPersonWVCode
            //
            this.ActiveSQLQuery = this.qryBaWVCode;
            this.Controls.Add(this.lblVerfahren);
            this.Controls.Add(this.edtErledigt);
            this.Controls.Add(this.lblSKZNummer);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblBED);
            this.Controls.Add(this.kissLabel90);
            this.Controls.Add(this.lblRekurs);
            this.Controls.Add(this.lblBis);
            this.Controls.Add(this.lblGueltigVon);
            this.Controls.Add(this.lblWVCode);
            this.Controls.Add(this.edtDatumBis);
            this.Controls.Add(this.edtRekurs);
            this.Controls.Add(this.edtSKZNummer);
            this.Controls.Add(this.edtBemerkung);
            this.Controls.Add(this.ddlStatus);
            this.Controls.Add(this.ddlBED);
            this.Controls.Add(this.ddlWVCode);
            this.Controls.Add(this.grdBaWVCode);
            this.Controls.Add(this.edtDatumVon);
            this.Name = "CtlBaPersonWVCode";
            this.Size = new System.Drawing.Size(705, 555);
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaWVCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlWVCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlWVCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlBED.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlBED)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSKZNummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRekurs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWVCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGueltigVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRekurs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel90)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBED)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSKZNummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErledigt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerfahren)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaWVCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaWVCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryStatus)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn colBED;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colSKZNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colWVCode;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissLookUpEdit ddlBED;
        private KiSS4.Gui.KissLookUpEdit ddlStatus;
        private KiSS4.Gui.KissLookUpEdit ddlWVCode;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissCheckEdit edtErledigt;
        private KiSS4.Gui.KissDateEdit edtRekurs;
        private KiSS4.Gui.KissTextEdit edtSKZNummer;
        private KiSS4.Gui.KissGrid grdBaWVCode;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBaWVCode;
        private KiSS4.Gui.KissLabel kissLabel90;
        private KiSS4.Gui.KissLabel lblBED;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblBis;
        private KiSS4.Gui.KissLabel lblGueltigVon;
        private KiSS4.Gui.KissLabel lblRekurs;
        private KiSS4.Gui.KissLabel lblSKZNummer;
        private KiSS4.Gui.KissLabel lblStatus;
        private KiSS4.Gui.KissLabel lblVerfahren;
        private KiSS4.Gui.KissLabel lblWVCode;
        private KiSS4.DB.SqlQuery qryBaWVCode;
        private KiSS4.DB.SqlQuery qryStatus;
    }
}
