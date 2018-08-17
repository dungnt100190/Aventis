namespace KiSS4.Sostat
{
    partial class CtlQueryBFSGemeinde : KiSS4.Common.KissQueryControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryBFSGemeinde));
            this.lblGemeindeName = new KiSS4.Gui.KissLabel();
            this.edtGemeindeName = new KiSS4.Gui.KissTextEdit();
            this.edtPLZ = new KiSS4.Gui.KissCalcEdit();
            this.lblPLZ = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblGemeindeName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGemeindeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPLZ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPLZ)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            this.qryQuery.TableName = "BaGemeinde";
            // 
            // xDocument
            // 
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
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
            this.tpgSuchen.Controls.Add(this.lblPLZ);
            this.tpgSuchen.Controls.Add(this.lblGemeindeName);
            this.tpgSuchen.Controls.Add(this.edtPLZ);
            this.tpgSuchen.Controls.Add(this.edtGemeindeName);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.edtGemeindeName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtPLZ, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblGemeindeName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblPLZ, 0);
            // 
            // lblGemeindeName
            // 
            this.lblGemeindeName.Location = new System.Drawing.Point(13, 52);
            this.lblGemeindeName.Name = "lblGemeindeName";
            this.lblGemeindeName.Size = new System.Drawing.Size(83, 24);
            this.lblGemeindeName.TabIndex = 1;
            this.lblGemeindeName.Text = "Gemeinde";
            // 
            // edtGemeindeName
            // 
            this.edtGemeindeName.Location = new System.Drawing.Point(119, 52);
            this.edtGemeindeName.Name = "edtGemeindeName";
            this.edtGemeindeName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGemeindeName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGemeindeName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGemeindeName.Properties.Appearance.Options.UseBackColor = true;
            this.edtGemeindeName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGemeindeName.Properties.Appearance.Options.UseFont = true;
            this.edtGemeindeName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGemeindeName.Size = new System.Drawing.Size(192, 24);
            this.edtGemeindeName.TabIndex = 2;
            // 
            // edtPLZ
            // 
            this.edtPLZ.Location = new System.Drawing.Point(119, 82);
            this.edtPLZ.Name = "edtPLZ";
            this.edtPLZ.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtPLZ.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPLZ.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPLZ.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPLZ.Properties.Appearance.Options.UseBackColor = true;
            this.edtPLZ.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPLZ.Properties.Appearance.Options.UseFont = true;
            this.edtPLZ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPLZ.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPLZ.Size = new System.Drawing.Size(100, 24);
            this.edtPLZ.TabIndex = 3;
            // 
            // lblPLZ
            // 
            this.lblPLZ.Location = new System.Drawing.Point(13, 82);
            this.lblPLZ.Name = "lblPLZ";
            this.lblPLZ.Size = new System.Drawing.Size(83, 24);
            this.lblPLZ.TabIndex = 4;
            this.lblPLZ.Text = "PLZ";
            // 
            // CtlQueryBFSGemeinde
            // 

            this.Name = "CtlQueryBFSGemeinde";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblGemeindeName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGemeindeName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPLZ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPLZ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KiSS4.Gui.KissLabel lblPLZ;
        private KiSS4.Gui.KissLabel lblGemeindeName;
        private KiSS4.Gui.KissCalcEdit edtPLZ;
        private KiSS4.Gui.KissTextEdit edtGemeindeName;
    }
}
