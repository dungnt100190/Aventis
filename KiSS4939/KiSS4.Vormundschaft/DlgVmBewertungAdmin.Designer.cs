using System;

namespace KiSS4.Vormundschaft
{
    partial class DlgVmBewertungAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblJahr = new KiSS4.Gui.KissLabel();
            this.edtJahr = new KiSS4.Gui.KissCalcEdit();
            this.lblTagMonat = new KiSS4.Gui.KissLabel();
            this.btnCancel = new KiSS4.Gui.KissButton();
            this.btnCreate = new KiSS4.Gui.KissButton();
            this.edtBewertung = new KiSS4.Gui.KissLookUpEdit();
            this.btnDelete = new KiSS4.Gui.KissButton();
            this.lblTitle = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.lblJahr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJahr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTagMonat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBewertung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBewertung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // lblJahr
            // 
            this.lblJahr.Location = new System.Drawing.Point(221, 45);
            this.lblJahr.Name = "lblJahr";
            this.lblJahr.Size = new System.Drawing.Size(32, 24);
            this.lblJahr.TabIndex = 0;
            this.lblJahr.Text = "Jahr";
            // 
            // edtJahr
            // 
            this.edtJahr.Location = new System.Drawing.Point(259, 45);
            this.edtJahr.Name = "edtJahr";
            this.edtJahr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtJahr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtJahr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtJahr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtJahr.Properties.Appearance.Options.UseBackColor = true;
            this.edtJahr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtJahr.Properties.Appearance.Options.UseFont = true;
            this.edtJahr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtJahr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtJahr.Size = new System.Drawing.Size(64, 24);
            this.edtJahr.TabIndex = 1;
            // 
            // lblTagMonat
            // 
            this.lblTagMonat.Location = new System.Drawing.Point(53, 45);
            this.lblTagMonat.Name = "lblTagMonat";
            this.lblTagMonat.Size = new System.Drawing.Size(64, 24);
            this.lblTagMonat.TabIndex = 5;
            this.lblTagMonat.Text = "Tag/Monat";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(12, 93);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 24);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Abbruch";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnCreate
            // 
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Location = new System.Drawing.Point(118, 93);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(120, 24);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "Einträge erzeugen";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // edtBewertung
            // 
            this.edtBewertung.Location = new System.Drawing.Point(123, 45);
            this.edtBewertung.LOVName = "VmFallgewichtungStichtag";
            this.edtBewertung.Name = "edtBewertung";
            this.edtBewertung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBewertung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBewertung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBewertung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBewertung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBewertung.Properties.Appearance.Options.UseFont = true;
            this.edtBewertung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBewertung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBewertung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBewertung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBewertung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtBewertung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtBewertung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBewertung.Properties.NullText = "";
            this.edtBewertung.Properties.ShowFooter = false;
            this.edtBewertung.Properties.ShowHeader = false;
            this.edtBewertung.Size = new System.Drawing.Size(76, 24);
            this.edtBewertung.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(244, 93);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 24);
            this.btnDelete.TabIndex = 20;
            this.btnDelete.Text = "Einträge löschen";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTitle.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(352, 24);
            this.lblTitle.TabIndex = 21;
            this.lblTitle.Text = "Neue Bewertungseinträge für alle aktiven Fälle erzeugen/löschen";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DlgVmBewertungAdmin
            // 
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(376, 129);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.edtBewertung);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.edtJahr);
            this.Controls.Add(this.lblTagMonat);
            this.Controls.Add(this.lblJahr);
            this.Name = "DlgVmBewertungAdmin";
            this.Text = "VM Fallgewichtung Administration";
            this.Load += new System.EventHandler(this.DlgVmBewertungAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lblJahr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJahr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTagMonat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBewertung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBewertung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private KiSS4.Gui.KissLabel lblJahr;
        private KiSS4.Gui.KissLabel lblTagMonat;
        private KiSS4.Gui.KissButton btnCancel;
        private KiSS4.Gui.KissLookUpEdit edtBewertung;
        private KiSS4.Gui.KissCalcEdit edtJahr;
        private KiSS4.Gui.KissButton btnCreate;
        private KiSS4.Gui.KissButton btnDelete;
        private KiSS4.Gui.KissLabel lblTitle;
    }
}