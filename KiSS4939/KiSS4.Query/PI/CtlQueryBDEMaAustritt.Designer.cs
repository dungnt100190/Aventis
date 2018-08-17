namespace KiSS4.Query.PI
{
    partial class CtlQueryBDEMaAustritt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryBDEMaAustritt));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblAustrittsdatumVon = new KiSS4.Gui.KissLabel();
            this.edtAustrittsdatumVon = new KiSS4.Gui.KissDateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblAustrittsdatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAustrittsdatumVon.Properties)).BeginInit();
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
            this.ctlGotoFall.Visible = false;
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
            this.tpgSuchen.Controls.Add(this.lblAustrittsdatumVon);
            this.tpgSuchen.Controls.Add(this.edtAustrittsdatumVon);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAustrittsdatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblAustrittsdatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            // 
            // lblAustrittsdatumVon
            // 
            this.lblAustrittsdatumVon.Location = new System.Drawing.Point(31, 40);
            this.lblAustrittsdatumVon.Name = "lblAustrittsdatumVon";
            this.lblAustrittsdatumVon.Size = new System.Drawing.Size(125, 24);
            this.lblAustrittsdatumVon.TabIndex = 1;
            this.lblAustrittsdatumVon.Text = "Austrittsdatum von:";
            // 
            // edtAustrittsdatumVon
            // 
            this.edtAustrittsdatumVon.EditValue = null;
            this.edtAustrittsdatumVon.Location = new System.Drawing.Point(162, 40);
            this.edtAustrittsdatumVon.Name = "edtAustrittsdatumVon";
            this.edtAustrittsdatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAustrittsdatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAustrittsdatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAustrittsdatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAustrittsdatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtAustrittsdatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAustrittsdatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtAustrittsdatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtAustrittsdatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtAustrittsdatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtAustrittsdatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAustrittsdatumVon.Properties.ShowToday = false;
            this.edtAustrittsdatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtAustrittsdatumVon.TabIndex = 2;
            // 
            // CtlQueryBDEMaAustritt
            // 

            this.Name = "CtlQueryBDEMaAustritt";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblAustrittsdatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAustrittsdatumVon.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Gui.KissLabel lblAustrittsdatumVon;
        private Gui.KissDateEdit edtAustrittsdatumVon;
    }
}
