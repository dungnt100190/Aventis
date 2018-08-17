namespace KiSS4.Query
{
    partial class CtlQueryKaSerienbrief
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryKaSerienbrief));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtStatus = new KiSS4.Gui.KissLookUpEdit();
            this.lblStatus = new KiSS4.Gui.KissLabel();
            this.lblLeistung = new KiSS4.Gui.KissLabel();
            this.edtLeistung = new KiSS4.Gui.KissLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLeistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLeistung.Properties)).BeginInit();
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
            // 
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.lblLeistung);
            this.tpgSuchen.Controls.Add(this.edtLeistung);
            this.tpgSuchen.Controls.Add(this.lblStatus);
            this.tpgSuchen.Controls.Add(this.edtStatus);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.edtStatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblStatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtLeistung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblLeistung, 0);
            // 
            // edtStatus
            // 
            this.edtStatus.Location = new System.Drawing.Point(134, 55);
            this.edtStatus.Name = "edtStatus";
            this.edtStatus.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStatus.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStatus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStatus.Properties.Appearance.Options.UseBackColor = true;
            this.edtStatus.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStatus.Properties.Appearance.Options.UseFont = true;
            this.edtStatus.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtStatus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtStatus.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtStatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtStatus.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStatus.Properties.NullText = "";
            this.edtStatus.Properties.ShowFooter = false;
            this.edtStatus.Properties.ShowHeader = false;
            this.edtStatus.Size = new System.Drawing.Size(334, 24);
            this.edtStatus.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(5, 55);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(100, 24);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Status heute";
            // 
            // lblLeistung
            // 
            this.lblLeistung.Location = new System.Drawing.Point(5, 85);
            this.lblLeistung.Name = "lblLeistung";
            this.lblLeistung.Size = new System.Drawing.Size(100, 24);
            this.lblLeistung.TabIndex = 4;
            this.lblLeistung.Text = "KA Leistung";
            // 
            // edtLeistung
            // 
            this.edtLeistung.Location = new System.Drawing.Point(134, 85);
            this.edtLeistung.Name = "edtLeistung";
            this.edtLeistung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtLeistung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLeistung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLeistung.Properties.Appearance.Options.UseBackColor = true;
            this.edtLeistung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLeistung.Properties.Appearance.Options.UseFont = true;
            this.edtLeistung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtLeistung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtLeistung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtLeistung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtLeistung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtLeistung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtLeistung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtLeistung.Properties.NullText = "";
            this.edtLeistung.Properties.ShowFooter = false;
            this.edtLeistung.Properties.ShowHeader = false;
            this.edtLeistung.Size = new System.Drawing.Size(334, 24);
            this.edtLeistung.TabIndex = 3;
            // 
            // CtlQueryKaSerienbrief
            // 
            this.Name = "CtlQueryKaSerienbrief";
            this.Load += new System.EventHandler(this.CtlQueryKaSerienbrief_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLeistung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLeistung)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Gui.KissLabel lblLeistung;
        private Gui.KissLookUpEdit edtLeistung;
        private Gui.KissLabel lblStatus;
        private Gui.KissLookUpEdit edtStatus;
    }
}
