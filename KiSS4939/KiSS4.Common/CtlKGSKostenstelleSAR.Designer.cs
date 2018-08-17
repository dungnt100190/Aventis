namespace KiSS4.Common
{
    partial class CtlKGSKostenstelleSAR
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.EdtSucheMitarbeiter = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheMitarbeiter = new KiSS4.Gui.KissLabel();
            this.EdtSucheKostenstelle = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheKostenstelle = new KiSS4.Gui.KissLabel();
            this.EdtSucheKGS = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheKGS = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.EdtSucheMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EdtSucheMitarbeiter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EdtSucheKostenstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EdtSucheKostenstelle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKostenstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EdtSucheKGS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EdtSucheKGS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKGS)).BeginInit();
            this.SuspendLayout();
            // 
            // EdtSucheMitarbeiter
            // 
            this.EdtSucheMitarbeiter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.EdtSucheMitarbeiter.Location = new System.Drawing.Point(139, 60);
            this.EdtSucheMitarbeiter.Name = "EdtSucheMitarbeiter";
            this.EdtSucheMitarbeiter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.EdtSucheMitarbeiter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.EdtSucheMitarbeiter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.EdtSucheMitarbeiter.Properties.Appearance.Options.UseBackColor = true;
            this.EdtSucheMitarbeiter.Properties.Appearance.Options.UseBorderColor = true;
            this.EdtSucheMitarbeiter.Properties.Appearance.Options.UseFont = true;
            this.EdtSucheMitarbeiter.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.EdtSucheMitarbeiter.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.EdtSucheMitarbeiter.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.EdtSucheMitarbeiter.Properties.AppearanceDropDown.Options.UseFont = true;
            this.EdtSucheMitarbeiter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.EdtSucheMitarbeiter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.EdtSucheMitarbeiter.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.EdtSucheMitarbeiter.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 5, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.EdtSucheMitarbeiter.Properties.DisplayMember = "Text";
            this.EdtSucheMitarbeiter.Properties.NullText = "";
            this.EdtSucheMitarbeiter.Properties.ShowFooter = false;
            this.EdtSucheMitarbeiter.Properties.ShowHeader = false;
            this.EdtSucheMitarbeiter.Properties.ValueMember = "Code";
            this.EdtSucheMitarbeiter.Size = new System.Drawing.Size(382, 24);
            this.EdtSucheMitarbeiter.TabIndex = 17;
            // 
            // lblSucheMitarbeiter
            // 
            this.lblSucheMitarbeiter.Location = new System.Drawing.Point(0, 60);
            this.lblSucheMitarbeiter.Name = "lblSucheMitarbeiter";
            this.lblSucheMitarbeiter.Size = new System.Drawing.Size(133, 24);
            this.lblSucheMitarbeiter.TabIndex = 16;
            this.lblSucheMitarbeiter.Text = "SAR Name, Vorname";
            this.lblSucheMitarbeiter.UseCompatibleTextRendering = true;
            // 
            // EdtSucheKostenstelle
            // 
            this.EdtSucheKostenstelle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.EdtSucheKostenstelle.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.EdtSucheKostenstelle.Location = new System.Drawing.Point(139, 30);
            this.EdtSucheKostenstelle.Name = "EdtSucheKostenstelle";
            this.EdtSucheKostenstelle.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.EdtSucheKostenstelle.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.EdtSucheKostenstelle.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.EdtSucheKostenstelle.Properties.Appearance.Options.UseBackColor = true;
            this.EdtSucheKostenstelle.Properties.Appearance.Options.UseBorderColor = true;
            this.EdtSucheKostenstelle.Properties.Appearance.Options.UseFont = true;
            this.EdtSucheKostenstelle.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.EdtSucheKostenstelle.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.EdtSucheKostenstelle.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.EdtSucheKostenstelle.Properties.AppearanceDropDown.Options.UseFont = true;
            this.EdtSucheKostenstelle.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.EdtSucheKostenstelle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.EdtSucheKostenstelle.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.EdtSucheKostenstelle.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 5, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.EdtSucheKostenstelle.Properties.DisplayMember = "Text";
            this.EdtSucheKostenstelle.Properties.NullText = "";
            this.EdtSucheKostenstelle.Properties.ReadOnly = true;
            this.EdtSucheKostenstelle.Properties.ShowFooter = false;
            this.EdtSucheKostenstelle.Properties.ShowHeader = false;
            this.EdtSucheKostenstelle.Properties.ValueMember = "Code";
            this.EdtSucheKostenstelle.Size = new System.Drawing.Size(382, 24);
            this.EdtSucheKostenstelle.TabIndex = 15;
            // 
            // lblSucheKostenstelle
            // 
            this.lblSucheKostenstelle.Location = new System.Drawing.Point(0, 30);
            this.lblSucheKostenstelle.Name = "lblSucheKostenstelle";
            this.lblSucheKostenstelle.Size = new System.Drawing.Size(133, 24);
            this.lblSucheKostenstelle.TabIndex = 14;
            this.lblSucheKostenstelle.Text = "Kostenstelle";
            this.lblSucheKostenstelle.UseCompatibleTextRendering = true;
            // 
            // EdtSucheKGS
            // 
            this.EdtSucheKGS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.EdtSucheKGS.Location = new System.Drawing.Point(139, 0);
            this.EdtSucheKGS.Name = "EdtSucheKGS";
            this.EdtSucheKGS.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.EdtSucheKGS.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.EdtSucheKGS.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.EdtSucheKGS.Properties.Appearance.Options.UseBackColor = true;
            this.EdtSucheKGS.Properties.Appearance.Options.UseBorderColor = true;
            this.EdtSucheKGS.Properties.Appearance.Options.UseFont = true;
            this.EdtSucheKGS.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.EdtSucheKGS.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.EdtSucheKGS.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.EdtSucheKGS.Properties.AppearanceDropDown.Options.UseFont = true;
            this.EdtSucheKGS.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.EdtSucheKGS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.EdtSucheKGS.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.EdtSucheKGS.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 5, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.EdtSucheKGS.Properties.DisplayMember = "Text";
            this.EdtSucheKGS.Properties.NullText = "";
            this.EdtSucheKGS.Properties.ShowFooter = false;
            this.EdtSucheKGS.Properties.ShowHeader = false;
            this.EdtSucheKGS.Properties.ValueMember = "Code";
            this.EdtSucheKGS.Size = new System.Drawing.Size(382, 24);
            this.EdtSucheKGS.TabIndex = 13;
            // 
            // lblSucheKGS
            // 
            this.lblSucheKGS.Location = new System.Drawing.Point(0, 0);
            this.lblSucheKGS.Name = "lblSucheKGS";
            this.lblSucheKGS.Size = new System.Drawing.Size(133, 24);
            this.lblSucheKGS.TabIndex = 12;
            this.lblSucheKGS.Text = "KGS";
            this.lblSucheKGS.UseCompatibleTextRendering = true;
            // 
            // CtlKGSKostenstelleSAR
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.EdtSucheMitarbeiter);
            this.Controls.Add(this.lblSucheMitarbeiter);
            this.Controls.Add(this.EdtSucheKostenstelle);
            this.Controls.Add(this.lblSucheKostenstelle);
            this.Controls.Add(this.EdtSucheKGS);
            this.Controls.Add(this.lblSucheKGS);
            this.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.Name = "CtlKGSKostenstelleSAR";
            this.Size = new System.Drawing.Size(521, 84);
            this.Load += new System.EventHandler(this.CtlKGSKostenstelleSAR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EdtSucheMitarbeiter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EdtSucheMitarbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMitarbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EdtSucheKostenstelle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EdtSucheKostenstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKostenstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EdtSucheKGS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EdtSucheKGS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKGS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gui.KissLabel lblSucheMitarbeiter;
        private Gui.KissLabel lblSucheKostenstelle;
        private Gui.KissLabel lblSucheKGS;
        public Gui.KissLookUpEdit EdtSucheMitarbeiter;
        public Gui.KissLookUpEdit EdtSucheKostenstelle;
        public Gui.KissLookUpEdit EdtSucheKGS;

    }
}
