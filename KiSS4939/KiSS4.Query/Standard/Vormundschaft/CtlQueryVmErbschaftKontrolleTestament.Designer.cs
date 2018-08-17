namespace KiSS4.Query
{
    partial class CtlQueryVmErbschaftKontrolleTestament
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryVmErbschaftKontrolleTestament));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.edtVorname = new KiSS4.Gui.KissTextEdit();
            this.edtNachname = new KiSS4.Gui.KissTextEdit();
            this.lblName = new KiSS4.Gui.KissLabel();
            this.edtFallNr = new KiSS4.Gui.KissTextEdit();
            this.lblFallNr = new KiSS4.Gui.KissLabel();
            this.lblJahr = new KiSS4.Gui.KissLabel();
            this.edtJahr = new KiSS4.Gui.KissTextEdit();
            this.edtUser = new KiSS4.Gui.KissButtonEdit();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.lblGeburtsdatum = new KiSS4.Gui.KissLabel();
            this.edtGeburtsdatum = new KiSS4.Gui.KissDateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNachname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFallNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFallNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJahr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJahr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsdatum.Properties)).BeginInit();
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
            this.tpgSuchen.Controls.Add(this.kissLabel1);
            this.tpgSuchen.Controls.Add(this.lblFallNr);
            this.tpgSuchen.Controls.Add(this.edtGeburtsdatum);
            this.tpgSuchen.Controls.Add(this.edtJahr);
            this.tpgSuchen.Controls.Add(this.lblGeburtsdatum);
            this.tpgSuchen.Controls.Add(this.kissLabel2);
            this.tpgSuchen.Controls.Add(this.lblJahr);
            this.tpgSuchen.Controls.Add(this.edtUser);
            this.tpgSuchen.Controls.Add(this.edtFallNr);
            this.tpgSuchen.Controls.Add(this.lblName);
            this.tpgSuchen.Controls.Add(this.edtNachname);
            this.tpgSuchen.Controls.Add(this.edtVorname);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.edtVorname, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNachname, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFallNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUser, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblJahr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel2, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblGeburtsdatum, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtJahr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtGeburtsdatum, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblFallNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel1, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            // 
            // kissLabel1
            // 
            this.kissLabel1.Location = new System.Drawing.Point(10, 40);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(100, 23);
            this.kissLabel1.TabIndex = 1;
            this.kissLabel1.Text = "Vorname";
            // 
            // edtVorname
            // 
            this.edtVorname.Location = new System.Drawing.Point(150, 40);
            this.edtVorname.Name = "edtVorname";
            this.edtVorname.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVorname.Properties.Appearance.Options.UseFont = true;
            this.edtVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVorname.Size = new System.Drawing.Size(150, 24);
            this.edtVorname.TabIndex = 2;
            // 
            // edtNachname
            // 
            this.edtNachname.Location = new System.Drawing.Point(150, 70);
            this.edtNachname.Name = "edtNachname";
            this.edtNachname.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNachname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNachname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNachname.Properties.Appearance.Options.UseBackColor = true;
            this.edtNachname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNachname.Properties.Appearance.Options.UseFont = true;
            this.edtNachname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNachname.Size = new System.Drawing.Size(150, 24);
            this.edtNachname.TabIndex = 4;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(10, 70);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 23);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Name";
            // 
            // edtFallNr
            // 
            this.edtFallNr.Location = new System.Drawing.Point(150, 100);
            this.edtFallNr.Name = "edtFallNr";
            this.edtFallNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFallNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFallNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFallNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtFallNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFallNr.Properties.Appearance.Options.UseFont = true;
            this.edtFallNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFallNr.Size = new System.Drawing.Size(100, 24);
            this.edtFallNr.TabIndex = 6;
            // 
            // lblFallNr
            // 
            this.lblFallNr.Location = new System.Drawing.Point(10, 100);
            this.lblFallNr.Name = "lblFallNr";
            this.lblFallNr.Size = new System.Drawing.Size(100, 23);
            this.lblFallNr.TabIndex = 5;
            this.lblFallNr.Text = "Fallnummer";
            // 
            // lblJahr
            // 
            this.lblJahr.Location = new System.Drawing.Point(10, 130);
            this.lblJahr.Name = "lblJahr";
            this.lblJahr.Size = new System.Drawing.Size(100, 23);
            this.lblJahr.TabIndex = 7;
            this.lblJahr.Text = "Jahr";
            // 
            // edtJahr
            // 
            this.edtJahr.Location = new System.Drawing.Point(150, 130);
            this.edtJahr.Name = "edtJahr";
            this.edtJahr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtJahr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtJahr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtJahr.Properties.Appearance.Options.UseBackColor = true;
            this.edtJahr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtJahr.Properties.Appearance.Options.UseFont = true;
            this.edtJahr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtJahr.Size = new System.Drawing.Size(100, 24);
            this.edtJahr.TabIndex = 8;
            // 
            // edtUser
            // 
            this.edtUser.Location = new System.Drawing.Point(150, 160);
            this.edtUser.Name = "edtUser";
            this.edtUser.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUser.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUser.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUser.Properties.Appearance.Options.UseBackColor = true;
            this.edtUser.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUser.Properties.Appearance.Options.UseFont = true;
            this.edtUser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtUser.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUser.Size = new System.Drawing.Size(200, 24);
            this.edtUser.TabIndex = 10;
            this.edtUser.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtUser_UserModifiedFld);
            // 
            // kissLabel2
            // 
            this.kissLabel2.Location = new System.Drawing.Point(10, 160);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(100, 23);
            this.kissLabel2.TabIndex = 9;
            this.kissLabel2.Text = "Sachbearbeitung";
            // 
            // lblGeburtsdatum
            // 
            this.lblGeburtsdatum.Location = new System.Drawing.Point(10, 190);
            this.lblGeburtsdatum.Name = "lblGeburtsdatum";
            this.lblGeburtsdatum.Size = new System.Drawing.Size(100, 23);
            this.lblGeburtsdatum.TabIndex = 11;
            this.lblGeburtsdatum.Text = "Geburtsdatum";
            // 
            // edtGeburtsdatum
            // 
            this.edtGeburtsdatum.EditValue = null;
            this.edtGeburtsdatum.Location = new System.Drawing.Point(150, 190);
            this.edtGeburtsdatum.Name = "edtGeburtsdatum";
            this.edtGeburtsdatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGeburtsdatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGeburtsdatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeburtsdatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeburtsdatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeburtsdatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeburtsdatum.Properties.Appearance.Options.UseFont = true;
            this.edtGeburtsdatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtGeburtsdatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGeburtsdatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtGeburtsdatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeburtsdatum.Properties.ShowToday = false;
            this.edtGeburtsdatum.Size = new System.Drawing.Size(100, 24);
            this.edtGeburtsdatum.TabIndex = 12;
            // 
            // CtlQueryVmErbschaftKontrolleTestament
            // 

            this.Name = "CtlQueryVmErbschaftKontrolleTestament";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNachname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFallNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFallNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJahr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJahr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsdatum.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissTextEdit edtVorname;
        private KiSS4.Gui.KissLabel lblName;
        private KiSS4.Gui.KissTextEdit edtNachname;
        private KiSS4.Gui.KissLabel lblFallNr;
        private KiSS4.Gui.KissTextEdit edtFallNr;
        private KiSS4.Gui.KissTextEdit edtJahr;
        private KiSS4.Gui.KissLabel lblJahr;
        private KiSS4.Gui.KissButtonEdit edtUser;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissLabel lblGeburtsdatum;
        private KiSS4.Gui.KissDateEdit edtGeburtsdatum;
    }
}
