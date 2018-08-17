namespace KiSS4.Query.PI
{
    partial class CtlQueryFaKeinFallverlauf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryFaKeinFallverlauf));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtSucheMitarbeiter = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheMitarbeiter = new KiSS4.Gui.KissLabel();
            this.edtSucheKostenstelle = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheKostenstelle = new KiSS4.Gui.KissLabel();
            this.edtSucheJahr = new KiSS4.Gui.KissCalcEdit();
            this.lblSucheJahr = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKostenstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKostenstelle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKostenstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheJahr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheJahr)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.SelectStatement = "SELECT [Error] = \'no statement yet, done in code\', \r\n       [BaPersonID$] = NULL";
            // 
            // xDocument
            // 
            this.xDocument.Location = new System.Drawing.Point(180, 397);
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
            this.xDocument.Size = new System.Drawing.Size(10, 24);
            this.xDocument.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = "BaPersonID$";
            this.ctlGotoFall.Size = new System.Drawing.Size(171, 24);
            // 
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtSucheMitarbeiter);
            this.tpgSuchen.Controls.Add(this.lblSucheMitarbeiter);
            this.tpgSuchen.Controls.Add(this.edtSucheKostenstelle);
            this.tpgSuchen.Controls.Add(this.lblSucheKostenstelle);
            this.tpgSuchen.Controls.Add(this.edtSucheJahr);
            this.tpgSuchen.Controls.Add(this.lblSucheJahr);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheJahr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheJahr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheKostenstelle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheKostenstelle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheMitarbeiter, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheMitarbeiter, 0);
            // 
            // edtSucheMitarbeiter
            // 
            this.edtSucheMitarbeiter.Location = new System.Drawing.Point(170, 100);
            this.edtSucheMitarbeiter.Name = "edtSucheMitarbeiter";
            this.edtSucheMitarbeiter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheMitarbeiter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheMitarbeiter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheMitarbeiter.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheMitarbeiter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheMitarbeiter.Properties.Appearance.Options.UseFont = true;
            this.edtSucheMitarbeiter.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheMitarbeiter.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheMitarbeiter.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheMitarbeiter.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheMitarbeiter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtSucheMitarbeiter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtSucheMitarbeiter.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheMitarbeiter.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 5, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtSucheMitarbeiter.Properties.DisplayMember = "Text";
            this.edtSucheMitarbeiter.Properties.NullText = "";
            this.edtSucheMitarbeiter.Properties.ShowFooter = false;
            this.edtSucheMitarbeiter.Properties.ShowHeader = false;
            this.edtSucheMitarbeiter.Properties.ValueMember = "Code";
            this.edtSucheMitarbeiter.Size = new System.Drawing.Size(244, 24);
            this.edtSucheMitarbeiter.TabIndex = 6;
            // 
            // lblSucheMitarbeiter
            // 
            this.lblSucheMitarbeiter.Location = new System.Drawing.Point(31, 100);
            this.lblSucheMitarbeiter.Name = "lblSucheMitarbeiter";
            this.lblSucheMitarbeiter.Size = new System.Drawing.Size(133, 24);
            this.lblSucheMitarbeiter.TabIndex = 5;
            this.lblSucheMitarbeiter.Text = "Mitarbeiter/in";
            this.lblSucheMitarbeiter.UseCompatibleTextRendering = true;
            // 
            // edtSucheKostenstelle
            // 
            this.edtSucheKostenstelle.Location = new System.Drawing.Point(170, 40);
            this.edtSucheKostenstelle.Name = "edtSucheKostenstelle";
            this.edtSucheKostenstelle.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheKostenstelle.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheKostenstelle.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheKostenstelle.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheKostenstelle.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheKostenstelle.Properties.Appearance.Options.UseFont = true;
            this.edtSucheKostenstelle.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheKostenstelle.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheKostenstelle.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheKostenstelle.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheKostenstelle.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtSucheKostenstelle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtSucheKostenstelle.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheKostenstelle.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 5, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtSucheKostenstelle.Properties.DisplayMember = "Text";
            this.edtSucheKostenstelle.Properties.NullText = "";
            this.edtSucheKostenstelle.Properties.ShowFooter = false;
            this.edtSucheKostenstelle.Properties.ShowHeader = false;
            this.edtSucheKostenstelle.Properties.ValueMember = "Code";
            this.edtSucheKostenstelle.Size = new System.Drawing.Size(244, 24);
            this.edtSucheKostenstelle.TabIndex = 2;
            // 
            // lblSucheKostenstelle
            // 
            this.lblSucheKostenstelle.Location = new System.Drawing.Point(31, 40);
            this.lblSucheKostenstelle.Name = "lblSucheKostenstelle";
            this.lblSucheKostenstelle.Size = new System.Drawing.Size(133, 24);
            this.lblSucheKostenstelle.TabIndex = 1;
            this.lblSucheKostenstelle.Text = "Kostenstelle";
            this.lblSucheKostenstelle.UseCompatibleTextRendering = true;
            // 
            // edtSucheJahr
            // 
            this.edtSucheJahr.Location = new System.Drawing.Point(170, 70);
            this.edtSucheJahr.Name = "edtSucheJahr";
            this.edtSucheJahr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheJahr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheJahr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheJahr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheJahr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheJahr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheJahr.Properties.Appearance.Options.UseFont = true;
            this.edtSucheJahr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheJahr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheJahr.Properties.DisplayFormat.FormatString = "0000";
            this.edtSucheJahr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSucheJahr.Properties.EditFormat.FormatString = "0000";
            this.edtSucheJahr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSucheJahr.Properties.Mask.EditMask = "0000";
            this.edtSucheJahr.Properties.MaxLength = 4;
            this.edtSucheJahr.Size = new System.Drawing.Size(60, 24);
            this.edtSucheJahr.TabIndex = 4;
            // 
            // lblSucheJahr
            // 
            this.lblSucheJahr.Location = new System.Drawing.Point(31, 70);
            this.lblSucheJahr.Name = "lblSucheJahr";
            this.lblSucheJahr.Size = new System.Drawing.Size(133, 24);
            this.lblSucheJahr.TabIndex = 3;
            this.lblSucheJahr.Text = "Jahr";
            this.lblSucheJahr.UseCompatibleTextRendering = true;
            // 
            // CtlQueryFaKeinFallverlauf
            // 

            this.Name = "CtlQueryFaKeinFallverlauf";
            this.Load += new System.EventHandler(this.CtlQueryFaKeinFallverlauf_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMitarbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKostenstelle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKostenstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKostenstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheJahr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheJahr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KiSS4.Gui.KissLookUpEdit edtSucheMitarbeiter;
        private KiSS4.Gui.KissLabel lblSucheMitarbeiter;
        private KiSS4.Gui.KissLookUpEdit edtSucheKostenstelle;
        private KiSS4.Gui.KissLabel lblSucheKostenstelle;
        private KiSS4.Gui.KissCalcEdit edtSucheJahr;
        private KiSS4.Gui.KissLabel lblSucheJahr;
    }
}
