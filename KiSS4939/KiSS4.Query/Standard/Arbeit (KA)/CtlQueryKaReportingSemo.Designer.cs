namespace KiSS4.Query
{
    partial class CtlQueryKaReportingSemo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryKaReportingSemo));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtZusatz = new KiSS4.Gui.KissLookUpEdit();
            this.edtApvNummer = new KiSS4.Gui.KissLookUpEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.lblZusatz = new KiSS4.Gui.KissLabel();
            this.lblApvNummer = new KiSS4.Gui.KissLabel();
            this.lblDatumBis = new KiSS4.Gui.KissLabel();
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtApvNummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtApvNummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblApvNummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
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
            this.xDocument.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = "BaPersonID$";
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControlSearch_SelectedTabChanged);
            // 
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtZusatz);
            this.tpgSuchen.Controls.Add(this.edtApvNummer);
            this.tpgSuchen.Controls.Add(this.edtDatumBis);
            this.tpgSuchen.Controls.Add(this.edtDatumVon);
            this.tpgSuchen.Controls.Add(this.lblZusatz);
            this.tpgSuchen.Controls.Add(this.lblApvNummer);
            this.tpgSuchen.Controls.Add(this.lblDatumBis);
            this.tpgSuchen.Controls.Add(this.lblDatumVon);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblApvNummer, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZusatz, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtApvNummer, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtZusatz, 0);
            // 
            // edtZusatz
            // 
            this.edtZusatz.Location = new System.Drawing.Point(114, 100);
            this.edtZusatz.LOVName = "KaAPVZusatz";
            this.edtZusatz.Name = "edtZusatz";
            this.edtZusatz.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZusatz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZusatz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZusatz.Properties.Appearance.Options.UseBackColor = true;
            this.edtZusatz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZusatz.Properties.Appearance.Options.UseFont = true;
            this.edtZusatz.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtZusatz.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtZusatz.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtZusatz.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtZusatz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtZusatz.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtZusatz.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZusatz.Properties.NullText = "";
            this.edtZusatz.Properties.ShowFooter = false;
            this.edtZusatz.Properties.ShowHeader = false;
            this.edtZusatz.Size = new System.Drawing.Size(250, 24);
            this.edtZusatz.TabIndex = 8;
            // 
            // edtApvNummer
            // 
            this.edtApvNummer.Location = new System.Drawing.Point(114, 70);
            this.edtApvNummer.LOVName = "KaAPV";
            this.edtApvNummer.Name = "edtApvNummer";
            this.edtApvNummer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtApvNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtApvNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtApvNummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtApvNummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtApvNummer.Properties.Appearance.Options.UseFont = true;
            this.edtApvNummer.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtApvNummer.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtApvNummer.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtApvNummer.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtApvNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtApvNummer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtApvNummer.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtApvNummer.Properties.NullText = "";
            this.edtApvNummer.Properties.ShowFooter = false;
            this.edtApvNummer.Properties.ShowHeader = false;
            this.edtApvNummer.Size = new System.Drawing.Size(250, 24);
            this.edtApvNummer.TabIndex = 6;
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtDatumBis.EditValue = "";
            this.edtDatumBis.Location = new System.Drawing.Point(264, 40);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 4;
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtDatumVon.EditValue = "";
            this.edtDatumVon.Location = new System.Drawing.Point(114, 40);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 2;
            // 
            // lblZusatz
            // 
            this.lblZusatz.Location = new System.Drawing.Point(8, 100);
            this.lblZusatz.Name = "lblZusatz";
            this.lblZusatz.Size = new System.Drawing.Size(100, 24);
            this.lblZusatz.TabIndex = 7;
            this.lblZusatz.Text = "Zusatz";
            this.lblZusatz.UseCompatibleTextRendering = true;
            // 
            // lblApvNummer
            // 
            this.lblApvNummer.Location = new System.Drawing.Point(8, 70);
            this.lblApvNummer.Name = "lblApvNummer";
            this.lblApvNummer.Size = new System.Drawing.Size(100, 24);
            this.lblApvNummer.TabIndex = 5;
            this.lblApvNummer.Text = "APV-Nummer";
            this.lblApvNummer.UseCompatibleTextRendering = true;
            // 
            // lblDatumBis
            // 
            this.lblDatumBis.Location = new System.Drawing.Point(228, 40);
            this.lblDatumBis.Name = "lblDatumBis";
            this.lblDatumBis.Size = new System.Drawing.Size(30, 24);
            this.lblDatumBis.TabIndex = 3;
            this.lblDatumBis.Text = "bis";
            this.lblDatumBis.UseCompatibleTextRendering = true;
            // 
            // lblDatumVon
            // 
            this.lblDatumVon.Location = new System.Drawing.Point(8, 40);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(100, 24);
            this.lblDatumVon.TabIndex = 1;
            this.lblDatumVon.Text = "Datum von";
            this.lblDatumVon.UseCompatibleTextRendering = true;
            // 
            // CtlQueryKaReportingSemo
            // 
            this.Name = "CtlQueryKaReportingSemo";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtApvNummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtApvNummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblApvNummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Gui.KissLookUpEdit edtZusatz;
        private Gui.KissLookUpEdit edtApvNummer;
        private Gui.KissDateEdit edtDatumBis;
        private Gui.KissDateEdit edtDatumVon;
        private Gui.KissLabel lblZusatz;
        private Gui.KissLabel lblApvNummer;
        private Gui.KissLabel lblDatumBis;
        private Gui.KissLabel lblDatumVon;

    }
}
