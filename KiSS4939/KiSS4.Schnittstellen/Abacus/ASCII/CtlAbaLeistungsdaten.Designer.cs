namespace KiSS4.Schnittstellen.Abacus.ASCII
{
    partial class CtlAbaLeistungsdaten
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlAbaLeistungsdaten));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.components = new System.ComponentModel.Container();
            this.grpEinstellungen = new KiSS4.Gui.KissGroupBox();
            this.btnStornoExport = new KiSS4.Gui.KissButton();
            this.edtGeschaeftsbereich = new KiSS4.Gui.KissLookUpEdit();
            this.lblGeschaeftsbereich = new KiSS4.Gui.KissLabel();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.lblMonat = new KiSS4.Gui.KissLabel();
            this.panButtons = new System.Windows.Forms.Panel();
            this.btnDatenExport = new KiSS4.Gui.KissButton();
            this.btnGotoBDEErfassung = new KiSS4.Gui.KissButton();
            this.btnDatenPruefen = new KiSS4.Gui.KissButton();
            this.lblStatusBar = new KiSS4.Gui.KissLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblInfoDatenNochZuKorrigieren = new KiSS4.Gui.KissLabel();
            this.grdNichtVisiert = new KiSS4.Gui.KissGrid();
            this.qryValidiertNicht = new KiSS4.DB.SqlQuery();
            this.grvNichtVisiert = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMANr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrgUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLohntyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFreigabe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlausibilisierungsfehler = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerbuchtStundenlohn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPeriode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.qryLeistungExport = new KiSS4.DB.SqlQuery();
            this.grpEinstellungen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschaeftsbereich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschaeftsbereich.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeschaeftsbereich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMonat)).BeginInit();
            this.panButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatusBar)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblInfoDatenNochZuKorrigieren)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNichtVisiert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryValidiertNicht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvNichtVisiert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryLeistungExport)).BeginInit();
            this.SuspendLayout();
            // 
            // grpEinstellungen
            // 
            this.grpEinstellungen.Controls.Add(this.btnStornoExport);
            this.grpEinstellungen.Controls.Add(this.edtGeschaeftsbereich);
            this.grpEinstellungen.Controls.Add(this.lblGeschaeftsbereich);
            this.grpEinstellungen.Controls.Add(this.edtDatumBis);
            this.grpEinstellungen.Controls.Add(this.edtDatumVon);
            this.grpEinstellungen.Controls.Add(this.lblMonat);
            this.grpEinstellungen.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpEinstellungen.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpEinstellungen.Location = new System.Drawing.Point(0, 0);
            this.grpEinstellungen.Name = "grpEinstellungen";
            this.grpEinstellungen.Size = new System.Drawing.Size(800, 89);
            this.grpEinstellungen.TabIndex = 0;
            this.grpEinstellungen.TabStop = false;
            this.grpEinstellungen.Text = "Einstellungen";
            this.grpEinstellungen.UseCompatibleTextRendering = true;
            // 
            // btnStornoExport
            // 
            this.btnStornoExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStornoExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStornoExport.Location = new System.Drawing.Point(664, 20);
            this.btnStornoExport.Name = "btnStornoExport";
            this.btnStornoExport.Size = new System.Drawing.Size(124, 24);
            this.btnStornoExport.TabIndex = 5;
            this.btnStornoExport.Text = "Export &stornieren";
            this.btnStornoExport.UseCompatibleTextRendering = true;
            this.btnStornoExport.UseVisualStyleBackColor = false;
            this.btnStornoExport.Click += new System.EventHandler(this.btnStornoExport_Click);
            // 
            // edtGeschaeftsbereich
            // 
            this.edtGeschaeftsbereich.Location = new System.Drawing.Point(137, 50);
            this.edtGeschaeftsbereich.Name = "edtGeschaeftsbereich";
            this.edtGeschaeftsbereich.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGeschaeftsbereich.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeschaeftsbereich.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeschaeftsbereich.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeschaeftsbereich.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeschaeftsbereich.Properties.Appearance.Options.UseFont = true;
            this.edtGeschaeftsbereich.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtGeschaeftsbereich.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeschaeftsbereich.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtGeschaeftsbereich.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtGeschaeftsbereich.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtGeschaeftsbereich.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtGeschaeftsbereich.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeschaeftsbereich.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 5, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtGeschaeftsbereich.Properties.DisplayMember = "Text";
            this.edtGeschaeftsbereich.Properties.NullText = "";
            this.edtGeschaeftsbereich.Properties.ShowFooter = false;
            this.edtGeschaeftsbereich.Properties.ShowHeader = false;
            this.edtGeschaeftsbereich.Properties.ValueMember = "Code";
            this.edtGeschaeftsbereich.Size = new System.Drawing.Size(217, 24);
            this.edtGeschaeftsbereich.TabIndex = 4;
            this.edtGeschaeftsbereich.EditValueChanged += new System.EventHandler(this.edtGeschaeftsbereich_EditValueChanged);
            // 
            // lblGeschaeftsbereich
            // 
            this.lblGeschaeftsbereich.Location = new System.Drawing.Point(10, 50);
            this.lblGeschaeftsbereich.Name = "lblGeschaeftsbereich";
            this.lblGeschaeftsbereich.Size = new System.Drawing.Size(121, 24);
            this.lblGeschaeftsbereich.TabIndex = 3;
            this.lblGeschaeftsbereich.Text = "Geschäftsbereich";
            this.lblGeschaeftsbereich.UseCompatibleTextRendering = true;
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(360, 20);
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
            this.edtDatumBis.Properties.ReadOnly = true;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(119, 24);
            this.edtDatumBis.TabIndex = 2;
            this.edtDatumBis.Visible = false;
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(137, 20);
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
            this.edtDatumVon.Properties.DisplayFormat.FormatString = "y";
            this.edtDatumVon.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtDatumVon.Properties.EditFormat.FormatString = "y";
            this.edtDatumVon.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtDatumVon.Properties.Mask.EditMask = "y";
            this.edtDatumVon.Properties.ReadOnly = true;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(217, 24);
            this.edtDatumVon.TabIndex = 1;
            // 
            // lblMonat
            // 
            this.lblMonat.Location = new System.Drawing.Point(10, 20);
            this.lblMonat.Name = "lblMonat";
            this.lblMonat.Size = new System.Drawing.Size(121, 24);
            this.lblMonat.TabIndex = 0;
            this.lblMonat.Text = "Monat";
            this.lblMonat.UseCompatibleTextRendering = true;
            // 
            // panButtons
            // 
            this.panButtons.Controls.Add(this.btnDatenExport);
            this.panButtons.Controls.Add(this.btnGotoBDEErfassung);
            this.panButtons.Controls.Add(this.btnDatenPruefen);
            this.panButtons.Controls.Add(this.lblStatusBar);
            this.panButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panButtons.Location = new System.Drawing.Point(0, 538);
            this.panButtons.Name = "panButtons";
            this.panButtons.Size = new System.Drawing.Size(800, 62);
            this.panButtons.TabIndex = 1;
            // 
            // btnDatenExport
            // 
            this.btnDatenExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatenExport.Location = new System.Drawing.Point(160, 10);
            this.btnDatenExport.Name = "btnDatenExport";
            this.btnDatenExport.Size = new System.Drawing.Size(144, 24);
            this.btnDatenExport.TabIndex = 2;
            this.btnDatenExport.Text = "&Daten exportieren...";
            this.btnDatenExport.UseCompatibleTextRendering = true;
            this.btnDatenExport.UseVisualStyleBackColor = false;
            this.btnDatenExport.Click += new System.EventHandler(this.btnDatenExport_Click);
            // 
            // btnGotoBDEErfassung
            // 
            this.btnGotoBDEErfassung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGotoBDEErfassung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGotoBDEErfassung.Location = new System.Drawing.Point(623, 10);
            this.btnGotoBDEErfassung.Name = "btnGotoBDEErfassung";
            this.btnGotoBDEErfassung.Size = new System.Drawing.Size(165, 24);
            this.btnGotoBDEErfassung.TabIndex = 1;
            this.btnGotoBDEErfassung.Text = "&Leistungserfassung";
            this.btnGotoBDEErfassung.UseCompatibleTextRendering = true;
            this.btnGotoBDEErfassung.UseVisualStyleBackColor = false;
            this.btnGotoBDEErfassung.Click += new System.EventHandler(this.btnGotoBDEErfassung_Click);
            // 
            // btnDatenPruefen
            // 
            this.btnDatenPruefen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatenPruefen.Location = new System.Drawing.Point(10, 10);
            this.btnDatenPruefen.Name = "btnDatenPruefen";
            this.btnDatenPruefen.Size = new System.Drawing.Size(144, 24);
            this.btnDatenPruefen.TabIndex = 0;
            this.btnDatenPruefen.Text = "Daten &prüfen";
            this.btnDatenPruefen.UseCompatibleTextRendering = true;
            this.btnDatenPruefen.UseVisualStyleBackColor = false;
            this.btnDatenPruefen.Click += new System.EventHandler(this.btnVerbuchtPruefen_Click);
            // 
            // lblStatusBar
            // 
            this.lblStatusBar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatusBar.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblStatusBar.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblStatusBar.Location = new System.Drawing.Point(0, 44);
            this.lblStatusBar.Name = "lblStatusBar";
            this.lblStatusBar.Size = new System.Drawing.Size(800, 18);
            this.lblStatusBar.TabIndex = 3;
            this.lblStatusBar.Text = "Status: -";
            this.lblStatusBar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStatusBar.UseCompatibleTextRendering = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblInfoDatenNochZuKorrigieren);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 89);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 30);
            this.panel1.TabIndex = 2;
            // 
            // lblInfoDatenNochZuKorrigieren
            // 
            this.lblInfoDatenNochZuKorrigieren.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfoDatenNochZuKorrigieren.Location = new System.Drawing.Point(3, 3);
            this.lblInfoDatenNochZuKorrigieren.Name = "lblInfoDatenNochZuKorrigieren";
            this.lblInfoDatenNochZuKorrigieren.Size = new System.Drawing.Size(794, 24);
            this.lblInfoDatenNochZuKorrigieren.TabIndex = 0;
            this.lblInfoDatenNochZuKorrigieren.Text = "Noch zu korrigierende Leistungen je Mitarbeiter/in und gewähltem Geschäftsbereich" +
                " (via Stundenlohn-Schnittstelle):";
            this.lblInfoDatenNochZuKorrigieren.UseCompatibleTextRendering = true;
            // 
            // grdNichtVisiert
            // 
            this.grdNichtVisiert.DataSource = this.qryValidiertNicht;
            this.grdNichtVisiert.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdNichtVisiert.EmbeddedNavigator.Name = "";
            this.grdNichtVisiert.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdNichtVisiert.Location = new System.Drawing.Point(0, 119);
            this.grdNichtVisiert.MainView = this.grvNichtVisiert;
            this.grdNichtVisiert.Name = "grdNichtVisiert";
            this.grdNichtVisiert.Size = new System.Drawing.Size(800, 419);
            this.grdNichtVisiert.TabIndex = 3;
            this.grdNichtVisiert.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvNichtVisiert});
            // 
            // qryValidiertNicht
            // 
            this.qryValidiertNicht.FillTimeOut = 300;
            this.qryValidiertNicht.HostControl = this;
            this.qryValidiertNicht.SelectStatement = resources.GetString("qryValidiertNicht.SelectStatement");
            // 
            // grvNichtVisiert
            // 
            this.grvNichtVisiert.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvNichtVisiert.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvNichtVisiert.Appearance.Empty.Options.UseBackColor = true;
            this.grvNichtVisiert.Appearance.Empty.Options.UseFont = true;
            this.grvNichtVisiert.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvNichtVisiert.Appearance.EvenRow.Options.UseFont = true;
            this.grvNichtVisiert.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvNichtVisiert.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvNichtVisiert.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvNichtVisiert.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvNichtVisiert.Appearance.FocusedCell.Options.UseFont = true;
            this.grvNichtVisiert.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvNichtVisiert.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvNichtVisiert.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvNichtVisiert.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvNichtVisiert.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvNichtVisiert.Appearance.FocusedRow.Options.UseFont = true;
            this.grvNichtVisiert.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvNichtVisiert.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvNichtVisiert.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvNichtVisiert.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvNichtVisiert.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvNichtVisiert.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvNichtVisiert.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvNichtVisiert.Appearance.GroupRow.Options.UseFont = true;
            this.grvNichtVisiert.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvNichtVisiert.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvNichtVisiert.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvNichtVisiert.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvNichtVisiert.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvNichtVisiert.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvNichtVisiert.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvNichtVisiert.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvNichtVisiert.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvNichtVisiert.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvNichtVisiert.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvNichtVisiert.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvNichtVisiert.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvNichtVisiert.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvNichtVisiert.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvNichtVisiert.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvNichtVisiert.Appearance.OddRow.Options.UseFont = true;
            this.grvNichtVisiert.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvNichtVisiert.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvNichtVisiert.Appearance.Row.Options.UseBackColor = true;
            this.grvNichtVisiert.Appearance.Row.Options.UseFont = true;
            this.grvNichtVisiert.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvNichtVisiert.Appearance.SelectedRow.Options.UseFont = true;
            this.grvNichtVisiert.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvNichtVisiert.Appearance.VertLine.Options.UseBackColor = true;
            this.grvNichtVisiert.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvNichtVisiert.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUserID,
            this.colMANr,
            this.colLastName,
            this.colFirstName,
            this.colOrgUnit,
            this.colLohntyp,
            this.colFreigabe,
            this.colPlausibilisierungsfehler,
            this.colVerbuchtStundenlohn,
            this.colPeriode});
            this.grvNichtVisiert.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvNichtVisiert.GridControl = this.grdNichtVisiert;
            this.grvNichtVisiert.Name = "grvNichtVisiert";
            this.grvNichtVisiert.OptionsBehavior.Editable = false;
            this.grvNichtVisiert.OptionsCustomization.AllowFilter = false;
            this.grvNichtVisiert.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvNichtVisiert.OptionsNavigation.AutoFocusNewRow = true;
            this.grvNichtVisiert.OptionsNavigation.UseTabKey = false;
            this.grvNichtVisiert.OptionsView.ColumnAutoWidth = false;
            this.grvNichtVisiert.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvNichtVisiert.OptionsView.ShowGroupPanel = false;
            this.grvNichtVisiert.OptionsView.ShowIndicator = false;
            // 
            // colUserID
            // 
            this.colUserID.Caption = "ID";
            this.colUserID.FieldName = "UserID";
            this.colUserID.Name = "colUserID";
            this.colUserID.Visible = true;
            this.colUserID.VisibleIndex = 0;
            this.colUserID.Width = 50;
            // 
            // colMANr
            // 
            this.colMANr.Caption = "MA-Nr.";
            this.colMANr.FieldName = "MANr";
            this.colMANr.Name = "colMANr";
            this.colMANr.Visible = true;
            this.colMANr.VisibleIndex = 1;
            this.colMANr.Width = 50;
            // 
            // colLastName
            // 
            this.colLastName.Caption = "Name";
            this.colLastName.FieldName = "LastName";
            this.colLastName.Name = "colLastName";
            this.colLastName.Visible = true;
            this.colLastName.VisibleIndex = 2;
            this.colLastName.Width = 100;
            // 
            // colFirstName
            // 
            this.colFirstName.Caption = "Vorname";
            this.colFirstName.FieldName = "FirstName";
            this.colFirstName.Name = "colFirstName";
            this.colFirstName.Visible = true;
            this.colFirstName.VisibleIndex = 3;
            this.colFirstName.Width = 100;
            // 
            // colOrgUnit
            // 
            this.colOrgUnit.Caption = "Abteilung";
            this.colOrgUnit.FieldName = "OrgUnit";
            this.colOrgUnit.Name = "colOrgUnit";
            this.colOrgUnit.Visible = true;
            this.colOrgUnit.VisibleIndex = 4;
            this.colOrgUnit.Width = 120;
            // 
            // colLohntyp
            // 
            this.colLohntyp.Caption = "Lohntyp";
            this.colLohntyp.FieldName = "Lohntyp";
            this.colLohntyp.Name = "colLohntyp";
            this.colLohntyp.Visible = true;
            this.colLohntyp.VisibleIndex = 5;
            this.colLohntyp.Width = 100;
            // 
            // colFreigabe
            // 
            this.colFreigabe.Caption = "Freigabe";
            this.colFreigabe.FieldName = "Freigabe";
            this.colFreigabe.Name = "colFreigabe";
            this.colFreigabe.Visible = true;
            this.colFreigabe.VisibleIndex = 6;
            this.colFreigabe.Width = 70;
            // 
            // colPlausibilisierungsfehler
            // 
            this.colPlausibilisierungsfehler.Caption = "Nötige Korr.";
            this.colPlausibilisierungsfehler.FieldName = "Plausibilisierungsfehler";
            this.colPlausibilisierungsfehler.Name = "colPlausibilisierungsfehler";
            this.colPlausibilisierungsfehler.Visible = true;
            this.colPlausibilisierungsfehler.VisibleIndex = 7;
            this.colPlausibilisierungsfehler.Width = 70;
            // 
            // colVerbuchtStundenlohn
            // 
            this.colVerbuchtStundenlohn.Caption = "Verbucht (Std.)";
            this.colVerbuchtStundenlohn.FieldName = "Verbucht";
            this.colVerbuchtStundenlohn.Name = "colVerbuchtStundenlohn";
            this.colVerbuchtStundenlohn.Visible = true;
            this.colVerbuchtStundenlohn.VisibleIndex = 8;
            this.colVerbuchtStundenlohn.Width = 110;
            // 
            // colPeriode
            // 
            this.colPeriode.Caption = "Periode";
            this.colPeriode.FieldName = "Periode";
            this.colPeriode.Name = "colPeriode";
            this.colPeriode.Visible = true;
            this.colPeriode.VisibleIndex = 9;
            this.colPeriode.Width = 120;
            // 
            // qryLeistungExport
            // 
            this.qryLeistungExport.FillTimeOut = 300;
            this.qryLeistungExport.HostControl = this;
            this.qryLeistungExport.SelectStatement = "SELECT * \r\nFROM dbo.fnABAGetLeistungsdaten({0}, {1}, {2}, {3})\r\nORDER BY [Name], " +
                "[Vorname]";
            // 
            // CtlAbaLeistungsdaten
            // 
            this.ActiveSQLQuery = this.qryValidiertNicht;
            this.Controls.Add(this.grdNichtVisiert);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grpEinstellungen);
            this.Controls.Add(this.panButtons);
            this.Name = "CtlAbaLeistungsdaten";
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.CtlAbaLeistungsdaten_Load);
            this.grpEinstellungen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschaeftsbereich.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschaeftsbereich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeschaeftsbereich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMonat)).EndInit();
            this.panButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblStatusBar)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblInfoDatenNochZuKorrigieren)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNichtVisiert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryValidiertNicht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvNichtVisiert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryLeistungExport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissButton btnDatenExport;
        private KiSS4.Gui.KissButton btnGotoBDEErfassung;
        private KiSS4.Gui.KissButton btnStornoExport;
        private KiSS4.Gui.KissButton btnDatenPruefen;
        private DevExpress.XtraGrid.Columns.GridColumn colFirstName;
        private DevExpress.XtraGrid.Columns.GridColumn colFreigabe;
        private DevExpress.XtraGrid.Columns.GridColumn colLastName;
        private DevExpress.XtraGrid.Columns.GridColumn colLohntyp;
        private DevExpress.XtraGrid.Columns.GridColumn colMANr;
        private DevExpress.XtraGrid.Columns.GridColumn colOrgUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colPeriode;
        private DevExpress.XtraGrid.Columns.GridColumn colUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colVerbuchtStundenlohn;
        private DevExpress.XtraGrid.Columns.GridColumn colPlausibilisierungsfehler;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissLookUpEdit edtGeschaeftsbereich;
        private KiSS4.Gui.KissGrid grdNichtVisiert;
        private KiSS4.Gui.KissGroupBox grpEinstellungen;
        private DevExpress.XtraGrid.Views.Grid.GridView grvNichtVisiert;
        private KiSS4.Gui.KissLabel lblGeschaeftsbereich;
        private KiSS4.Gui.KissLabel lblInfoDatenNochZuKorrigieren;
        private KiSS4.Gui.KissLabel lblMonat;
        private KiSS4.Gui.KissLabel lblStatusBar;
        private System.Windows.Forms.Panel panButtons;
        private System.Windows.Forms.Panel panel1;
        private KiSS4.DB.SqlQuery qryLeistungExport;
        private KiSS4.DB.SqlQuery qryValidiertNicht;
    }
}