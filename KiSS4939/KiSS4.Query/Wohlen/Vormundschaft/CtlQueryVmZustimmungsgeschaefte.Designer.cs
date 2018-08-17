namespace KiSS4.Query.WOH
{
    partial class CtlQueryVmZustimmungsgeschaefte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryVmZustimmungsgeschaefte));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtTitelCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtZustaendigeGemeindeCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtAntragUserID = new KiSS4.Common.KissMitarbeiterButtonEdit();
            this.edtAntragDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtAntragDatumVon = new KiSS4.Gui.KissDateEdit();
            this.lblAntragDatumBis = new KiSS4.Gui.KissLabel();
            this.lblAuftragDatumBis = new KiSS4.Gui.KissLabel();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.lblZustaendigeGemeinde = new KiSS4.Gui.KissLabel();
            this.lblAntragDurch = new KiSS4.Gui.KissLabel();
            this.lblAntragDatumVon = new KiSS4.Gui.KissLabel();
            this.edtAuftragDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblAuftragDatumVon = new KiSS4.Gui.KissLabel();
            this.edtAuftragDatumVon = new KiSS4.Gui.KissDateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtTitelCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTitelCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigeGemeindeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigeGemeindeCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAntragUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAntragDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAntragDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAntragDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuftragDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustaendigeGemeinde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAntragDurch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAntragDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuftragDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuftragDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuftragDatumVon.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            // 
            // xDocument
            // 
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.xDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("xDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument öffnen")});
            this.xDocument.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = "BaPersonID$";
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.SelectedTabIndex = 1;
            // 
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtTitelCode);
            this.tpgSuchen.Controls.Add(this.edtZustaendigeGemeindeCode);
            this.tpgSuchen.Controls.Add(this.edtAntragUserID);
            this.tpgSuchen.Controls.Add(this.edtAntragDatumBis);
            this.tpgSuchen.Controls.Add(this.edtAntragDatumVon);
            this.tpgSuchen.Controls.Add(this.lblAntragDatumBis);
            this.tpgSuchen.Controls.Add(this.lblAuftragDatumBis);
            this.tpgSuchen.Controls.Add(this.lblTitel);
            this.tpgSuchen.Controls.Add(this.lblZustaendigeGemeinde);
            this.tpgSuchen.Controls.Add(this.lblAntragDurch);
            this.tpgSuchen.Controls.Add(this.lblAntragDatumVon);
            this.tpgSuchen.Controls.Add(this.edtAuftragDatumBis);
            this.tpgSuchen.Controls.Add(this.lblAuftragDatumVon);
            this.tpgSuchen.Controls.Add(this.edtAuftragDatumVon);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAuftragDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblAuftragDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAuftragDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblAntragDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblAntragDurch, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZustaendigeGemeinde, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblTitel, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblAuftragDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblAntragDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAntragDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAntragDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAntragUserID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtZustaendigeGemeindeCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtTitelCode, 0);
            // 
            // edtTitelCode
            // 
            this.edtTitelCode.Location = new System.Drawing.Point(188, 209);
            this.edtTitelCode.LOVName = "VmMfZustTitel";
            this.edtTitelCode.Name = "edtTitelCode";
            this.edtTitelCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTitelCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTitelCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTitelCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtTitelCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTitelCode.Properties.Appearance.Options.UseFont = true;
            this.edtTitelCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtTitelCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtTitelCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtTitelCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtTitelCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtTitelCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtTitelCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTitelCode.Properties.NullText = "";
            this.edtTitelCode.Properties.ShowFooter = false;
            this.edtTitelCode.Properties.ShowHeader = false;
            this.edtTitelCode.Size = new System.Drawing.Size(234, 24);
            this.edtTitelCode.TabIndex = 52;
            // 
            // edtZustaendigeGemeindeCode
            // 
            this.edtZustaendigeGemeindeCode.Location = new System.Drawing.Point(188, 176);
            this.edtZustaendigeGemeindeCode.LOVName = "GemeindeSozialdienst";
            this.edtZustaendigeGemeindeCode.Name = "edtZustaendigeGemeindeCode";
            this.edtZustaendigeGemeindeCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZustaendigeGemeindeCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZustaendigeGemeindeCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZustaendigeGemeindeCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtZustaendigeGemeindeCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZustaendigeGemeindeCode.Properties.Appearance.Options.UseFont = true;
            this.edtZustaendigeGemeindeCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtZustaendigeGemeindeCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtZustaendigeGemeindeCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtZustaendigeGemeindeCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtZustaendigeGemeindeCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtZustaendigeGemeindeCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtZustaendigeGemeindeCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZustaendigeGemeindeCode.Properties.NullText = "";
            this.edtZustaendigeGemeindeCode.Properties.ShowFooter = false;
            this.edtZustaendigeGemeindeCode.Properties.ShowHeader = false;
            this.edtZustaendigeGemeindeCode.Size = new System.Drawing.Size(234, 24);
            this.edtZustaendigeGemeindeCode.TabIndex = 51;
            // 
            // edtAntragUserID
            // 
            this.edtAntragUserID.IsSearchField = true;
            this.edtAntragUserID.Location = new System.Drawing.Point(188, 143);
            this.edtAntragUserID.Name = "edtAntragUserID";
            this.edtAntragUserID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAntragUserID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAntragUserID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAntragUserID.Properties.Appearance.Options.UseBackColor = true;
            this.edtAntragUserID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAntragUserID.Properties.Appearance.Options.UseFont = true;
            this.edtAntragUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtAntragUserID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtAntragUserID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAntragUserID.Size = new System.Drawing.Size(234, 24);
            this.edtAntragUserID.TabIndex = 50;
            // 
            // edtAntragDatumBis
            // 
            this.edtAntragDatumBis.EditValue = null;
            this.edtAntragDatumBis.Location = new System.Drawing.Point(322, 110);
            this.edtAntragDatumBis.Name = "edtAntragDatumBis";
            this.edtAntragDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAntragDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAntragDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAntragDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAntragDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtAntragDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAntragDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtAntragDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtAntragDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtAntragDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtAntragDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAntragDatumBis.Properties.ShowToday = false;
            this.edtAntragDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtAntragDatumBis.TabIndex = 49;
            // 
            // edtAntragDatumVon
            // 
            this.edtAntragDatumVon.EditValue = null;
            this.edtAntragDatumVon.Location = new System.Drawing.Point(188, 110);
            this.edtAntragDatumVon.Name = "edtAntragDatumVon";
            this.edtAntragDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAntragDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAntragDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAntragDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAntragDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtAntragDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAntragDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtAntragDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtAntragDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtAntragDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtAntragDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAntragDatumVon.Properties.ShowToday = false;
            this.edtAntragDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtAntragDatumVon.TabIndex = 48;
            // 
            // lblAntragDatumBis
            // 
            this.lblAntragDatumBis.Location = new System.Drawing.Point(300, 110);
            this.lblAntragDatumBis.Name = "lblAntragDatumBis";
            this.lblAntragDatumBis.Size = new System.Drawing.Size(15, 24);
            this.lblAntragDatumBis.TabIndex = 46;
            this.lblAntragDatumBis.Text = "-";
            // 
            // lblAuftragDatumBis
            // 
            this.lblAuftragDatumBis.Location = new System.Drawing.Point(300, 77);
            this.lblAuftragDatumBis.Name = "lblAuftragDatumBis";
            this.lblAuftragDatumBis.Size = new System.Drawing.Size(15, 24);
            this.lblAuftragDatumBis.TabIndex = 47;
            this.lblAuftragDatumBis.Text = "-";
            // 
            // lblTitel
            // 
            this.lblTitel.Location = new System.Drawing.Point(8, 209);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(159, 24);
            this.lblTitel.TabIndex = 44;
            this.lblTitel.Text = "Titel";
            // 
            // lblZustaendigeGemeinde
            // 
            this.lblZustaendigeGemeinde.Location = new System.Drawing.Point(8, 176);
            this.lblZustaendigeGemeinde.Name = "lblZustaendigeGemeinde";
            this.lblZustaendigeGemeinde.Size = new System.Drawing.Size(159, 24);
            this.lblZustaendigeGemeinde.TabIndex = 43;
            this.lblZustaendigeGemeinde.Text = "Zuständige Gemeinde";
            // 
            // lblAntragDurch
            // 
            this.lblAntragDurch.Location = new System.Drawing.Point(8, 143);
            this.lblAntragDurch.Name = "lblAntragDurch";
            this.lblAntragDurch.Size = new System.Drawing.Size(159, 24);
            this.lblAntragDurch.TabIndex = 42;
            this.lblAntragDurch.Text = "Antrag durch";
            // 
            // lblAntragDatumVon
            // 
            this.lblAntragDatumVon.Location = new System.Drawing.Point(8, 110);
            this.lblAntragDatumVon.Name = "lblAntragDatumVon";
            this.lblAntragDatumVon.Size = new System.Drawing.Size(159, 24);
            this.lblAntragDatumVon.TabIndex = 41;
            this.lblAntragDatumVon.Text = "Antrag von";
            // 
            // edtAuftragDatumBis
            // 
            this.edtAuftragDatumBis.EditValue = null;
            this.edtAuftragDatumBis.Location = new System.Drawing.Point(322, 77);
            this.edtAuftragDatumBis.Name = "edtAuftragDatumBis";
            this.edtAuftragDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAuftragDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAuftragDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAuftragDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuftragDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtAuftragDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAuftragDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtAuftragDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtAuftragDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtAuftragDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtAuftragDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAuftragDatumBis.Properties.ShowToday = false;
            this.edtAuftragDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtAuftragDatumBis.TabIndex = 40;
            // 
            // lblAuftragDatumVon
            // 
            this.lblAuftragDatumVon.Location = new System.Drawing.Point(8, 77);
            this.lblAuftragDatumVon.Name = "lblAuftragDatumVon";
            this.lblAuftragDatumVon.Size = new System.Drawing.Size(159, 24);
            this.lblAuftragDatumVon.TabIndex = 38;
            this.lblAuftragDatumVon.Text = "Auftrag von";
            // 
            // edtAuftragDatumVon
            // 
            this.edtAuftragDatumVon.EditValue = null;
            this.edtAuftragDatumVon.Location = new System.Drawing.Point(188, 77);
            this.edtAuftragDatumVon.Name = "edtAuftragDatumVon";
            this.edtAuftragDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAuftragDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAuftragDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAuftragDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuftragDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtAuftragDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAuftragDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtAuftragDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtAuftragDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtAuftragDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtAuftragDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAuftragDatumVon.Properties.ShowToday = false;
            this.edtAuftragDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtAuftragDatumVon.TabIndex = 39;
            // 
            // CtlQueryVmZustimmungsgeschaefte
            // 

            this.Name = "CtlQueryVmZustimmungsgeschaefte";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtTitelCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTitelCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigeGemeindeCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigeGemeindeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAntragUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAntragDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAntragDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAntragDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuftragDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustaendigeGemeinde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAntragDurch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAntragDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuftragDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuftragDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuftragDatumVon.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Gui.KissLookUpEdit edtTitelCode;
        private Gui.KissLookUpEdit edtZustaendigeGemeindeCode;
        private Common.KissMitarbeiterButtonEdit edtAntragUserID;
        private Gui.KissDateEdit edtAntragDatumBis;
        private Gui.KissDateEdit edtAntragDatumVon;
        private Gui.KissLabel lblAntragDatumBis;
        private Gui.KissLabel lblAuftragDatumBis;
        private Gui.KissLabel lblTitel;
        private Gui.KissLabel lblZustaendigeGemeinde;
        private Gui.KissLabel lblAntragDurch;
        private Gui.KissLabel lblAntragDatumVon;
        private Gui.KissDateEdit edtAuftragDatumBis;
        private Gui.KissLabel lblAuftragDatumVon;
        private Gui.KissDateEdit edtAuftragDatumVon;
    }
}
