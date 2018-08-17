namespace KiSS4.Klientenbuchhaltung
{
    partial class CtlQueryKontiOhneBgKostenart
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryKontiOhneBgKostenart));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtSearchDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtSearchDatumBis = new KiSS4.Gui.KissDateEdit();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.edtSucheKonto = new KiSS4.Gui.KissButtonEdit();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKonto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.AfterFill += new System.EventHandler(this.qryQuery_AfterFill);
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
            this.tpgSuchen.Controls.Add(this.kissLabel3);
            this.tpgSuchen.Controls.Add(this.kissLabel1);
            this.tpgSuchen.Controls.Add(this.edtSearchDatumVon);
            this.tpgSuchen.Controls.Add(this.edtSucheKonto);
            this.tpgSuchen.Controls.Add(this.kissLabel2);
            this.tpgSuchen.Controls.Add(this.edtSearchDatumBis);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSearchDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel2, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheKonto, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSearchDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel1, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel3, 0);
            // 
            // edtSearchDatumVon
            // 
            this.edtSearchDatumVon.EditValue = null;
            this.edtSearchDatumVon.Location = new System.Drawing.Point(135, 40);
            this.edtSearchDatumVon.Name = "edtSearchDatumVon";
            this.edtSearchDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSearchDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSearchDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSearchDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSearchDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtSearchDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtSearchDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSearchDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtSearchDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSearchDatumVon.Properties.ShowToday = false;
            this.edtSearchDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtSearchDatumVon.TabIndex = 1;
            // 
            // edtSearchDatumBis
            // 
            this.edtSearchDatumBis.EditValue = null;
            this.edtSearchDatumBis.Location = new System.Drawing.Point(270, 40);
            this.edtSearchDatumBis.Name = "edtSearchDatumBis";
            this.edtSearchDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSearchDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSearchDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSearchDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSearchDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtSearchDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtSearchDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSearchDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtSearchDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSearchDatumBis.Properties.ShowToday = false;
            this.edtSearchDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtSearchDatumBis.TabIndex = 2;
            // 
            // kissLabel1
            // 
            this.kissLabel1.Location = new System.Drawing.Point(30, 40);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(99, 24);
            this.kissLabel1.TabIndex = 3;
            this.kissLabel1.Text = "Beleg Datum von";
            // 
            // kissLabel2
            // 
            this.kissLabel2.Location = new System.Drawing.Point(241, 40);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(23, 24);
            this.kissLabel2.TabIndex = 4;
            this.kissLabel2.Text = "bis";
            // 
            // edtSucheKonto
            // 
            this.edtSucheKonto.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtSucheKonto.Location = new System.Drawing.Point(135, 70);
            this.edtSucheKonto.Name = "edtSucheKonto";
            this.edtSucheKonto.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtSucheKonto.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheKonto.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheKonto.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheKonto.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheKonto.Properties.Appearance.Options.UseFont = true;
            this.edtSucheKonto.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtSucheKonto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtSucheKonto.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheKonto.Size = new System.Drawing.Size(235, 24);
            this.edtSucheKonto.TabIndex = 5;
            this.edtSucheKonto.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheKonto_UserModifiedFld);
            // 
            // kissLabel3
            // 
            this.kissLabel3.Location = new System.Drawing.Point(30, 70);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(99, 24);
            this.kissLabel3.TabIndex = 6;
            this.kissLabel3.Text = "Konto";
            // 
            // CtlQueryKontiOhneBgKostenart
            // 

            this.Name = "CtlQueryKontiOhneBgKostenart";
            this.Load += new System.EventHandler(this.CtlQueryKontiOhneBgKostenart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKonto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        

        #endregion

        private Gui.KissLabel kissLabel2;
        private Gui.KissLabel kissLabel1;
        private Gui.KissDateEdit edtSearchDatumBis;
        private Gui.KissDateEdit edtSearchDatumVon;
        private Gui.KissLabel kissLabel3;
        private Gui.KissButtonEdit edtSucheKonto;
    }
}
