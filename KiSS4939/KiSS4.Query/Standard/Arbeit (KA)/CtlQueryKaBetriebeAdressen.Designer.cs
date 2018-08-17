namespace KiSS4.Query
{
    partial class CtlQueryKaBetriebeAdressen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryKaBetriebeAdressen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtSucheStatus = new KiSS4.Gui.KissLookUpEdit();
            this.lblSuchStatus = new KiSS4.Gui.KissLabel();
            this.lblSuchCharakter = new KiSS4.Gui.KissLabel();
            this.edtSucheCharakter = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheEinsatzplatz = new KiSS4.Gui.KissLabel();
            this.edtSucheEinsatzplatz = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheProgramm = new KiSS4.Gui.KissLabel();
            this.edtSucheProgramm = new KiSS4.Gui.KissLookUpEdit();
            this.btnGeheZuBetrieb = new KiSS4.Gui.KissButton();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchCharakter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheCharakter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheCharakter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheEinsatzplatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheEinsatzplatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheEinsatzplatz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheProgramm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheProgramm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheProgramm.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.ctlGotoFall.Location = new System.Drawing.Point(306, 397);
            this.ctlGotoFall.Visible = false;
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.SelectedTabIndex = 1;
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.btnGeheZuBetrieb);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Controls.SetChildIndex(this.btnGeheZuBetrieb, 0);
            this.tpgListe.Controls.SetChildIndex(this.ctlGotoFall, 0);
            this.tpgListe.Controls.SetChildIndex(this.xDocument, 0);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.lblSucheProgramm);
            this.tpgSuchen.Controls.Add(this.edtSucheProgramm);
            this.tpgSuchen.Controls.Add(this.lblSucheEinsatzplatz);
            this.tpgSuchen.Controls.Add(this.edtSucheEinsatzplatz);
            this.tpgSuchen.Controls.Add(this.lblSuchCharakter);
            this.tpgSuchen.Controls.Add(this.edtSucheCharakter);
            this.tpgSuchen.Controls.Add(this.lblSuchStatus);
            this.tpgSuchen.Controls.Add(this.edtSucheStatus);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheStatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSuchStatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheCharakter, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSuchCharakter, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheEinsatzplatz, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheEinsatzplatz, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheProgramm, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheProgramm, 0);
            // 
            // edtSucheStatus
            // 
            this.edtSucheStatus.Location = new System.Drawing.Point(126, 40);
            this.edtSucheStatus.Name = "edtSucheStatus";
            this.edtSucheStatus.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheStatus.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheStatus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheStatus.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheStatus.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheStatus.Properties.Appearance.Options.UseFont = true;
            this.edtSucheStatus.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheStatus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheStatus.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheStatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtSucheStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtSucheStatus.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheStatus.Properties.NullText = "";
            this.edtSucheStatus.Properties.ShowFooter = false;
            this.edtSucheStatus.Properties.ShowHeader = false;
            this.edtSucheStatus.Size = new System.Drawing.Size(216, 24);
            this.edtSucheStatus.TabIndex = 1;
            // 
            // lblSuchStatus
            // 
            this.lblSuchStatus.Location = new System.Drawing.Point(30, 40);
            this.lblSuchStatus.Name = "lblSuchStatus";
            this.lblSuchStatus.Size = new System.Drawing.Size(90, 24);
            this.lblSuchStatus.TabIndex = 2;
            this.lblSuchStatus.Text = "Status";
            // 
            // lblSuchCharakter
            // 
            this.lblSuchCharakter.Location = new System.Drawing.Point(30, 70);
            this.lblSuchCharakter.Name = "lblSuchCharakter";
            this.lblSuchCharakter.Size = new System.Drawing.Size(90, 24);
            this.lblSuchCharakter.TabIndex = 4;
            this.lblSuchCharakter.Text = "Charakter";
            // 
            // edtSucheCharakter
            // 
            this.edtSucheCharakter.Location = new System.Drawing.Point(126, 70);
            this.edtSucheCharakter.LOVName = "KaBetriebCharakter";
            this.edtSucheCharakter.Name = "edtSucheCharakter";
            this.edtSucheCharakter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheCharakter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheCharakter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheCharakter.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheCharakter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheCharakter.Properties.Appearance.Options.UseFont = true;
            this.edtSucheCharakter.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheCharakter.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheCharakter.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheCharakter.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheCharakter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtSucheCharakter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtSucheCharakter.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheCharakter.Properties.NullText = "";
            this.edtSucheCharakter.Properties.ShowFooter = false;
            this.edtSucheCharakter.Properties.ShowHeader = false;
            this.edtSucheCharakter.Size = new System.Drawing.Size(216, 24);
            this.edtSucheCharakter.TabIndex = 3;
            // 
            // lblSucheEinsatzplatz
            // 
            this.lblSucheEinsatzplatz.Location = new System.Drawing.Point(30, 100);
            this.lblSucheEinsatzplatz.Name = "lblSucheEinsatzplatz";
            this.lblSucheEinsatzplatz.Size = new System.Drawing.Size(90, 24);
            this.lblSucheEinsatzplatz.TabIndex = 6;
            this.lblSucheEinsatzplatz.Text = "Einsatzplatz";
            // 
            // edtSucheEinsatzplatz
            // 
            this.edtSucheEinsatzplatz.Location = new System.Drawing.Point(126, 100);
            this.edtSucheEinsatzplatz.Name = "edtSucheEinsatzplatz";
            this.edtSucheEinsatzplatz.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheEinsatzplatz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheEinsatzplatz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheEinsatzplatz.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheEinsatzplatz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheEinsatzplatz.Properties.Appearance.Options.UseFont = true;
            this.edtSucheEinsatzplatz.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheEinsatzplatz.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheEinsatzplatz.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheEinsatzplatz.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheEinsatzplatz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtSucheEinsatzplatz.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtSucheEinsatzplatz.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheEinsatzplatz.Properties.NullText = "";
            this.edtSucheEinsatzplatz.Properties.ShowFooter = false;
            this.edtSucheEinsatzplatz.Properties.ShowHeader = false;
            this.edtSucheEinsatzplatz.Size = new System.Drawing.Size(216, 24);
            this.edtSucheEinsatzplatz.TabIndex = 5;
            this.edtSucheEinsatzplatz.EditValueChanged += new System.EventHandler(this.edtSucheEinsatzplatz_EditValueChanged);
            // 
            // lblSucheProgramm
            // 
            this.lblSucheProgramm.Location = new System.Drawing.Point(30, 130);
            this.lblSucheProgramm.Name = "lblSucheProgramm";
            this.lblSucheProgramm.Size = new System.Drawing.Size(90, 24);
            this.lblSucheProgramm.TabIndex = 8;
            this.lblSucheProgramm.Text = "KA Programm";
            // 
            // edtSucheProgramm
            // 
            this.edtSucheProgramm.Location = new System.Drawing.Point(126, 130);
            this.edtSucheProgramm.LOVName = "KaVermittlungProgramm";
            this.edtSucheProgramm.Name = "edtSucheProgramm";
            this.edtSucheProgramm.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheProgramm.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheProgramm.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheProgramm.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheProgramm.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheProgramm.Properties.Appearance.Options.UseFont = true;
            this.edtSucheProgramm.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheProgramm.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheProgramm.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheProgramm.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheProgramm.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtSucheProgramm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtSucheProgramm.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheProgramm.Properties.NullText = "";
            this.edtSucheProgramm.Properties.ShowFooter = false;
            this.edtSucheProgramm.Properties.ShowHeader = false;
            this.edtSucheProgramm.Size = new System.Drawing.Size(216, 24);
            this.edtSucheProgramm.TabIndex = 7;
            // 
            // btnGeheZuBetrieb
            // 
            this.btnGeheZuBetrieb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGeheZuBetrieb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeheZuBetrieb.IconID = 212;
            this.btnGeheZuBetrieb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGeheZuBetrieb.Location = new System.Drawing.Point(3, 398);
            this.btnGeheZuBetrieb.Name = "btnGeheZuBetrieb";
            this.btnGeheZuBetrieb.Size = new System.Drawing.Size(99, 24);
            this.btnGeheZuBetrieb.TabIndex = 3;
            this.btnGeheZuBetrieb.Text = "Betriebinfo";
            this.btnGeheZuBetrieb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGeheZuBetrieb.UseVisualStyleBackColor = false;
            this.btnGeheZuBetrieb.Click += new System.EventHandler(this.btnGeheZuBetrieb_Click);
            // 
            // CtlQueryKaBetriebeAdressen
            // 

            this.Name = "CtlQueryKaBetriebeAdressen";
            this.Load += new System.EventHandler(this.CtlQueryKaBetriebeAdressen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchCharakter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheCharakter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheCharakter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheEinsatzplatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheEinsatzplatz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheEinsatzplatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheProgramm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheProgramm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheProgramm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private KiSS4.Gui.KissLabel lblSucheProgramm;
        private KiSS4.Gui.KissLookUpEdit edtSucheProgramm;
        private KiSS4.Gui.KissLabel lblSucheEinsatzplatz;
        private KiSS4.Gui.KissLookUpEdit edtSucheEinsatzplatz;
        private KiSS4.Gui.KissLabel lblSuchCharakter;
        private KiSS4.Gui.KissLookUpEdit edtSucheCharakter;
        private KiSS4.Gui.KissLabel lblSuchStatus;
        private KiSS4.Gui.KissLookUpEdit edtSucheStatus;
        private KiSS4.Gui.KissButton btnGeheZuBetrieb;
    }
}
