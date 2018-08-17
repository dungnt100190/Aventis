namespace KiSS4.Basis.PI
{
    partial class DlgBaIVBerechtigung
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgBaIVBerechtigung));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.components = new System.ComponentModel.Container();
            this.panTopInfo = new System.Windows.Forms.Panel();
            this.lblBaPerson = new KiSS4.Gui.KissLabel();
            this.lblUserNameLbl = new KiSS4.Gui.KissLabel();
            this.panDetails = new System.Windows.Forms.Panel();
            this.btnCloseDialog = new KiSS4.Gui.KissButton();
            this.edtBemerkungen = new KiSS4.Gui.KissMemoEdit();
            this.qryBaIVBerechtigung = new KiSS4.DB.SqlQuery();
            this.lblBemerkungen = new KiSS4.Gui.KissLabel();
            this.edtIVBerechtigungCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblIVBerechtigungCode = new KiSS4.Gui.KissLabel();
            this.edtIVBerechtigungDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblIVBerechtigungDatumBis = new KiSS4.Gui.KissLabel();
            this.edtIVBerechtigungDatumVon = new KiSS4.Gui.KissDateEdit();
            this.lblIVBerechtigungDatumVon = new KiSS4.Gui.KissLabel();
            this.grdBaIVBerechtigung = new KiSS4.Gui.KissGrid();
            this.grvBaIVBerechtigung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIVBerechtigung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBemerkungen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panTopInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserNameLbl)).BeginInit();
            this.panDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaIVBerechtigung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIVBerechtigungCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIVBerechtigungCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIVBerechtigungCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIVBerechtigungDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIVBerechtigungDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIVBerechtigungDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIVBerechtigungDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaIVBerechtigung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaIVBerechtigung)).BeginInit();
            this.SuspendLayout();
            //
            // panTopInfo
            //
            this.panTopInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panTopInfo.Controls.Add(this.lblBaPerson);
            this.panTopInfo.Controls.Add(this.lblUserNameLbl);
            this.panTopInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTopInfo.Location = new System.Drawing.Point(0, 0);
            this.panTopInfo.Name = "panTopInfo";
            this.panTopInfo.Size = new System.Drawing.Size(642, 30);
            this.panTopInfo.TabIndex = 0;
            //
            // lblBaPerson
            //
            this.lblBaPerson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBaPerson.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblBaPerson.Location = new System.Drawing.Point(156, 7);
            this.lblBaPerson.Name = "lblBaPerson";
            this.lblBaPerson.Size = new System.Drawing.Size(472, 16);
            this.lblBaPerson.TabIndex = 1;
            this.lblBaPerson.Text = "<Name>, <Vorname> (Nr. <BaPersonID>)";
            this.lblBaPerson.UseCompatibleTextRendering = true;
            //
            // lblUserNameLbl
            //
            this.lblUserNameLbl.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblUserNameLbl.Location = new System.Drawing.Point(12, 7);
            this.lblUserNameLbl.Name = "lblUserNameLbl";
            this.lblUserNameLbl.Size = new System.Drawing.Size(138, 16);
            this.lblUserNameLbl.TabIndex = 0;
            this.lblUserNameLbl.Text = "Aktuelle Person:";
            this.lblUserNameLbl.UseCompatibleTextRendering = true;
            //
            // panDetails
            //
            this.panDetails.Controls.Add(this.btnCloseDialog);
            this.panDetails.Controls.Add(this.edtBemerkungen);
            this.panDetails.Controls.Add(this.lblBemerkungen);
            this.panDetails.Controls.Add(this.edtIVBerechtigungCode);
            this.panDetails.Controls.Add(this.lblIVBerechtigungCode);
            this.panDetails.Controls.Add(this.edtIVBerechtigungDatumBis);
            this.panDetails.Controls.Add(this.lblIVBerechtigungDatumBis);
            this.panDetails.Controls.Add(this.edtIVBerechtigungDatumVon);
            this.panDetails.Controls.Add(this.lblIVBerechtigungDatumVon);
            this.panDetails.Controls.Add(this.grdBaIVBerechtigung);
            this.panDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panDetails.Location = new System.Drawing.Point(0, 30);
            this.panDetails.Name = "panDetails";
            this.panDetails.Size = new System.Drawing.Size(642, 389);
            this.panDetails.TabIndex = 1;
            //
            // btnCloseDialog
            //
            this.btnCloseDialog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseDialog.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCloseDialog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseDialog.Location = new System.Drawing.Point(543, 355);
            this.btnCloseDialog.Name = "btnCloseDialog";
            this.btnCloseDialog.Size = new System.Drawing.Size(90, 24);
            this.btnCloseDialog.TabIndex = 9;
            this.btnCloseDialog.Text = "&Schliessen";
            this.btnCloseDialog.UseCompatibleTextRendering = true;
            this.btnCloseDialog.UseVisualStyleBackColor = true;
            this.btnCloseDialog.Click += new System.EventHandler(this.btnCloseDialog_Click);
            //
            // edtBemerkungen
            //
            this.edtBemerkungen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBemerkungen.DataMember = "Bemerkungen";
            this.edtBemerkungen.DataSource = this.qryBaIVBerechtigung;
            this.edtBemerkungen.Location = new System.Drawing.Point(139, 328);
            this.edtBemerkungen.Name = "edtBemerkungen";
            this.edtBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkungen.Size = new System.Drawing.Size(371, 51);
            this.edtBemerkungen.TabIndex = 8;
            //
            // qryBaIVBerechtigung
            //
            this.qryBaIVBerechtigung.HostControl = this;
            this.qryBaIVBerechtigung.TableName = "BaIVBerechtigung";
            this.qryBaIVBerechtigung.AfterInsert += new System.EventHandler(this.qryBaIVBerechtigung_AfterInsert);
            this.qryBaIVBerechtigung.BeforePost += new System.EventHandler(this.qryBaIVBerechtigung_BeforePost);
            this.qryBaIVBerechtigung.AfterPost += new System.EventHandler(this.qryBaIVBerechtigung_AfterPost);
            this.qryBaIVBerechtigung.PositionChanged += new System.EventHandler(this.qryBaIVBerechtigung_PositionChanged);
            //
            // lblBemerkungen
            //
            this.lblBemerkungen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBemerkungen.Location = new System.Drawing.Point(9, 328);
            this.lblBemerkungen.Name = "lblBemerkungen";
            this.lblBemerkungen.Size = new System.Drawing.Size(124, 24);
            this.lblBemerkungen.TabIndex = 7;
            this.lblBemerkungen.Text = "Bemerkungen";
            this.lblBemerkungen.UseCompatibleTextRendering = true;
            //
            // edtIVBerechtigungCode
            //
            this.edtIVBerechtigungCode.AllowNull = false;
            this.edtIVBerechtigungCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtIVBerechtigungCode.DataMember = "BaIVBerechtigungCode";
            this.edtIVBerechtigungCode.DataSource = this.qryBaIVBerechtigung;
            this.edtIVBerechtigungCode.Location = new System.Drawing.Point(139, 298);
            this.edtIVBerechtigungCode.LOVName = "BaIVBerechtigung";
            this.edtIVBerechtigungCode.Name = "edtIVBerechtigungCode";
            this.edtIVBerechtigungCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIVBerechtigungCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIVBerechtigungCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIVBerechtigungCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtIVBerechtigungCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIVBerechtigungCode.Properties.Appearance.Options.UseFont = true;
            this.edtIVBerechtigungCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtIVBerechtigungCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtIVBerechtigungCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtIVBerechtigungCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtIVBerechtigungCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtIVBerechtigungCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtIVBerechtigungCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIVBerechtigungCode.Properties.NullText = "";
            this.edtIVBerechtigungCode.Properties.ShowFooter = false;
            this.edtIVBerechtigungCode.Properties.ShowHeader = false;
            this.edtIVBerechtigungCode.Size = new System.Drawing.Size(371, 24);
            this.edtIVBerechtigungCode.TabIndex = 6;
            //
            // lblIVBerechtigungCode
            //
            this.lblIVBerechtigungCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblIVBerechtigungCode.Location = new System.Drawing.Point(9, 298);
            this.lblIVBerechtigungCode.Name = "lblIVBerechtigungCode";
            this.lblIVBerechtigungCode.Size = new System.Drawing.Size(124, 24);
            this.lblIVBerechtigungCode.TabIndex = 5;
            this.lblIVBerechtigungCode.Text = "IV-Berechtigung";
            this.lblIVBerechtigungCode.UseCompatibleTextRendering = true;
            //
            // edtIVBerechtigungDatumBis
            //
            this.edtIVBerechtigungDatumBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtIVBerechtigungDatumBis.DataMember = "DatumBis";
            this.edtIVBerechtigungDatumBis.DataSource = this.qryBaIVBerechtigung;
            this.edtIVBerechtigungDatumBis.EditValue = null;
            this.edtIVBerechtigungDatumBis.Location = new System.Drawing.Point(139, 268);
            this.edtIVBerechtigungDatumBis.Name = "edtIVBerechtigungDatumBis";
            this.edtIVBerechtigungDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtIVBerechtigungDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIVBerechtigungDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIVBerechtigungDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIVBerechtigungDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtIVBerechtigungDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIVBerechtigungDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtIVBerechtigungDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtIVBerechtigungDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtIVBerechtigungDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtIVBerechtigungDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIVBerechtigungDatumBis.Properties.ShowToday = false;
            this.edtIVBerechtigungDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtIVBerechtigungDatumBis.TabIndex = 4;
            //
            // lblIVBerechtigungDatumBis
            //
            this.lblIVBerechtigungDatumBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblIVBerechtigungDatumBis.Location = new System.Drawing.Point(9, 268);
            this.lblIVBerechtigungDatumBis.Name = "lblIVBerechtigungDatumBis";
            this.lblIVBerechtigungDatumBis.Size = new System.Drawing.Size(124, 24);
            this.lblIVBerechtigungDatumBis.TabIndex = 3;
            this.lblIVBerechtigungDatumBis.Text = "Gültig bis";
            this.lblIVBerechtigungDatumBis.UseCompatibleTextRendering = true;
            //
            // edtIVBerechtigungDatumVon
            //
            this.edtIVBerechtigungDatumVon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtIVBerechtigungDatumVon.DataMember = "DatumVon";
            this.edtIVBerechtigungDatumVon.DataSource = this.qryBaIVBerechtigung;
            this.edtIVBerechtigungDatumVon.EditValue = null;
            this.edtIVBerechtigungDatumVon.Location = new System.Drawing.Point(139, 238);
            this.edtIVBerechtigungDatumVon.Name = "edtIVBerechtigungDatumVon";
            this.edtIVBerechtigungDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtIVBerechtigungDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIVBerechtigungDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIVBerechtigungDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIVBerechtigungDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtIVBerechtigungDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIVBerechtigungDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtIVBerechtigungDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtIVBerechtigungDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtIVBerechtigungDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtIVBerechtigungDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIVBerechtigungDatumVon.Properties.ShowToday = false;
            this.edtIVBerechtigungDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtIVBerechtigungDatumVon.TabIndex = 2;
            //
            // lblIVBerechtigungDatumVon
            //
            this.lblIVBerechtigungDatumVon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblIVBerechtigungDatumVon.Location = new System.Drawing.Point(9, 238);
            this.lblIVBerechtigungDatumVon.Name = "lblIVBerechtigungDatumVon";
            this.lblIVBerechtigungDatumVon.Size = new System.Drawing.Size(124, 24);
            this.lblIVBerechtigungDatumVon.TabIndex = 1;
            this.lblIVBerechtigungDatumVon.Text = "Gültig ab";
            this.lblIVBerechtigungDatumVon.UseCompatibleTextRendering = true;
            //
            // grdBaIVBerechtigung
            //
            this.grdBaIVBerechtigung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBaIVBerechtigung.DataSource = this.qryBaIVBerechtigung;
            //
            //
            //
            this.grdBaIVBerechtigung.EmbeddedNavigator.Name = "";
            this.grdBaIVBerechtigung.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBaIVBerechtigung.Location = new System.Drawing.Point(9, 6);
            this.grdBaIVBerechtigung.MainView = this.grvBaIVBerechtigung;
            this.grdBaIVBerechtigung.Name = "grdBaIVBerechtigung";
            this.grdBaIVBerechtigung.Size = new System.Drawing.Size(624, 226);
            this.grdBaIVBerechtigung.TabIndex = 0;
            this.grdBaIVBerechtigung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBaIVBerechtigung});
            //
            // grvBaIVBerechtigung
            //
            this.grvBaIVBerechtigung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBaIVBerechtigung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaIVBerechtigung.Appearance.Empty.Options.UseBackColor = true;
            this.grvBaIVBerechtigung.Appearance.Empty.Options.UseFont = true;
            this.grvBaIVBerechtigung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaIVBerechtigung.Appearance.EvenRow.Options.UseFont = true;
            this.grvBaIVBerechtigung.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaIVBerechtigung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaIVBerechtigung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBaIVBerechtigung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBaIVBerechtigung.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBaIVBerechtigung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBaIVBerechtigung.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaIVBerechtigung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaIVBerechtigung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBaIVBerechtigung.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBaIVBerechtigung.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBaIVBerechtigung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBaIVBerechtigung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaIVBerechtigung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBaIVBerechtigung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaIVBerechtigung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaIVBerechtigung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaIVBerechtigung.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBaIVBerechtigung.Appearance.GroupRow.Options.UseFont = true;
            this.grvBaIVBerechtigung.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBaIVBerechtigung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBaIVBerechtigung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBaIVBerechtigung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaIVBerechtigung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBaIVBerechtigung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBaIVBerechtigung.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBaIVBerechtigung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBaIVBerechtigung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaIVBerechtigung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaIVBerechtigung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBaIVBerechtigung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBaIVBerechtigung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBaIVBerechtigung.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaIVBerechtigung.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBaIVBerechtigung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaIVBerechtigung.Appearance.OddRow.Options.UseFont = true;
            this.grvBaIVBerechtigung.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBaIVBerechtigung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaIVBerechtigung.Appearance.Row.Options.UseBackColor = true;
            this.grvBaIVBerechtigung.Appearance.Row.Options.UseFont = true;
            this.grvBaIVBerechtigung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaIVBerechtigung.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBaIVBerechtigung.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaIVBerechtigung.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBaIVBerechtigung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBaIVBerechtigung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatumVon,
            this.colDatumBis,
            this.colIVBerechtigung,
            this.colBemerkungen});
            this.grvBaIVBerechtigung.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBaIVBerechtigung.GridControl = this.grdBaIVBerechtigung;
            this.grvBaIVBerechtigung.Name = "grvBaIVBerechtigung";
            this.grvBaIVBerechtigung.OptionsBehavior.Editable = false;
            this.grvBaIVBerechtigung.OptionsCustomization.AllowFilter = false;
            this.grvBaIVBerechtigung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBaIVBerechtigung.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBaIVBerechtigung.OptionsNavigation.UseTabKey = false;
            this.grvBaIVBerechtigung.OptionsView.ColumnAutoWidth = false;
            this.grvBaIVBerechtigung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBaIVBerechtigung.OptionsView.ShowGroupPanel = false;
            this.grvBaIVBerechtigung.OptionsView.ShowIndicator = false;
            //
            // colDatumVon
            //
            this.colDatumVon.Caption = "Gültig ab";
            this.colDatumVon.FieldName = "DatumVon";
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.Visible = true;
            this.colDatumVon.VisibleIndex = 0;
            this.colDatumVon.Width = 80;
            //
            // colDatumBis
            //
            this.colDatumBis.Caption = "Gültig bis";
            this.colDatumBis.FieldName = "DatumBis";
            this.colDatumBis.Name = "colDatumBis";
            this.colDatumBis.Visible = true;
            this.colDatumBis.VisibleIndex = 1;
            this.colDatumBis.Width = 80;
            //
            // colIVBerechtigung
            //
            this.colIVBerechtigung.Caption = "IV-Berechtigung";
            this.colIVBerechtigung.FieldName = "BaIVBerechtigung";
            this.colIVBerechtigung.Name = "colIVBerechtigung";
            this.colIVBerechtigung.Visible = true;
            this.colIVBerechtigung.VisibleIndex = 2;
            this.colIVBerechtigung.Width = 180;
            //
            // colBemerkungen
            //
            this.colBemerkungen.Caption = "Bemerkungen";
            this.colBemerkungen.FieldName = "Bemerkungen";
            this.colBemerkungen.Name = "colBemerkungen";
            this.colBemerkungen.Visible = true;
            this.colBemerkungen.VisibleIndex = 3;
            this.colBemerkungen.Width = 250;
            //
            // DlgBaIVBerechtigung
            //
            this.AcceptButton = this.btnCloseDialog;
            this.ActiveSQLQuery = this.qryBaIVBerechtigung;
            this.CancelButton = this.btnCloseDialog;
            this.ClientSize = new System.Drawing.Size(642, 419);
            this.Controls.Add(this.panDetails);
            this.Controls.Add(this.panTopInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "DlgBaIVBerechtigung";
            this.Text = "IV-Berechtigung";
            this.Load += new System.EventHandler(this.DlgBaIVBerechtigung_Load);
            this.panTopInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserNameLbl)).EndInit();
            this.panDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaIVBerechtigung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIVBerechtigungCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIVBerechtigungCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIVBerechtigungCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIVBerechtigungDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIVBerechtigungDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIVBerechtigungDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIVBerechtigungDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaIVBerechtigung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaIVBerechtigung)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private KiSS4.Gui.KissButton btnCloseDialog;
        private DevExpress.XtraGrid.Columns.GridColumn colBemerkungen;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colIVBerechtigung;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissMemoEdit edtBemerkungen;
        private KiSS4.Gui.KissLookUpEdit edtIVBerechtigungCode;
        private KiSS4.Gui.KissDateEdit edtIVBerechtigungDatumBis;
        private KiSS4.Gui.KissDateEdit edtIVBerechtigungDatumVon;
        private KiSS4.Gui.KissGrid grdBaIVBerechtigung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBaIVBerechtigung;
        private KiSS4.Gui.KissLabel lblBaPerson;
        private KiSS4.Gui.KissLabel lblBemerkungen;
        private KiSS4.Gui.KissLabel lblIVBerechtigungCode;
        private KiSS4.Gui.KissLabel lblIVBerechtigungDatumBis;
        private KiSS4.Gui.KissLabel lblIVBerechtigungDatumVon;
        private KiSS4.Gui.KissLabel lblUserNameLbl;
        private System.Windows.Forms.Panel panDetails;
        private System.Windows.Forms.Panel panTopInfo;
        private KiSS4.DB.SqlQuery qryBaIVBerechtigung;
    }
}
