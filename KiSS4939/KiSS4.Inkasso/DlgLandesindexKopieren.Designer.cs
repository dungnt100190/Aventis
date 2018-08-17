namespace KiSS4.Inkasso
{
    partial class DlgLandesindexKopieren
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgLandesindexKopieren));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnCopy = new KiSS4.Gui.KissButton();
            this.btnCancel = new KiSS4.Gui.KissButton();
            this.lblVorlageText = new KiSS4.Gui.KissLabel();
            this.lblVorlage = new KiSS4.Gui.KissLabel();
            this.edtNeuberechnung = new KiSS4.Gui.KissCheckEdit();
            this.edtMonatJahr = new KiSS4.Gui.KissDateEdit();
            this.lblHundert = new KiSS4.Gui.KissLabel();
            this.lblName = new KiSS4.Gui.KissLabel();
            this.edtName = new KiSS4.Gui.KissTextEdit();
            this.grpNeuberechnung = new KiSS4.Gui.KissGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorlageText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorlage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNeuberechnung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMonatJahr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHundert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).BeginInit();
            this.grpNeuberechnung.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Location = new System.Drawing.Point(219, 171);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(90, 24);
            this.btnCopy.TabIndex = 0;
            this.btnCopy.Text = "Erfassen";
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(123, 171);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 24);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblVorlageText
            // 
            this.lblVorlageText.Enabled = false;
            this.lblVorlageText.Location = new System.Drawing.Point(6, 42);
            this.lblVorlageText.Name = "lblVorlageText";
            this.lblVorlageText.Size = new System.Drawing.Size(50, 24);
            this.lblVorlageText.TabIndex = 2;
            this.lblVorlageText.Text = "Vorlage:";
            // 
            // lblVorlage
            // 
            this.lblVorlage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVorlage.Enabled = false;
            this.lblVorlage.Location = new System.Drawing.Point(62, 42);
            this.lblVorlage.Name = "lblVorlage";
            this.lblVorlage.Size = new System.Drawing.Size(229, 24);
            this.lblVorlage.TabIndex = 3;
            this.lblVorlage.Text = "...";
            // 
            // edtNeuberechnung
            // 
            this.edtNeuberechnung.EditValue = false;
            this.edtNeuberechnung.Location = new System.Drawing.Point(6, 20);
            this.edtNeuberechnung.Name = "edtNeuberechnung";
            this.edtNeuberechnung.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtNeuberechnung.Properties.Appearance.Options.UseBackColor = true;
            this.edtNeuberechnung.Properties.Caption = "aktivieren";
            this.edtNeuberechnung.Size = new System.Drawing.Size(75, 19);
            this.edtNeuberechnung.TabIndex = 4;
            this.edtNeuberechnung.CheckedChanged += new System.EventHandler(this.edtNeuberechnung_CheckedChanged);
            // 
            // edtMonatJahr
            // 
            this.edtMonatJahr.EditValue = new System.DateTime(2011, 6, 15, 13, 53, 17, 839);
            this.edtMonatJahr.Enabled = false;
            this.edtMonatJahr.Location = new System.Drawing.Point(6, 69);
            this.edtMonatJahr.Name = "edtMonatJahr";
            this.edtMonatJahr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtMonatJahr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMonatJahr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMonatJahr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMonatJahr.Properties.Appearance.Options.UseBackColor = true;
            this.edtMonatJahr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMonatJahr.Properties.Appearance.Options.UseFont = true;
            this.edtMonatJahr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtMonatJahr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtMonatJahr.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtMonatJahr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtMonatJahr.Properties.DisplayFormat.FormatString = "MM.yyyy";
            this.edtMonatJahr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtMonatJahr.Properties.EditFormat.FormatString = "y";
            this.edtMonatJahr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtMonatJahr.Properties.Mask.EditMask = "MM.yyyy";
            this.edtMonatJahr.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.edtMonatJahr.Properties.ShowToday = false;
            this.edtMonatJahr.Size = new System.Drawing.Size(90, 24);
            this.edtMonatJahr.TabIndex = 5;
            // 
            // lblHundert
            // 
            this.lblHundert.Enabled = false;
            this.lblHundert.Location = new System.Drawing.Point(102, 69);
            this.lblHundert.Name = "lblHundert";
            this.lblHundert.Size = new System.Drawing.Size(50, 24);
            this.lblHundert.TabIndex = 6;
            this.lblHundert.Text = "= 100%";
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(12, 12);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(105, 24);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Name:";
            // 
            // edtName
            // 
            this.edtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtName.Location = new System.Drawing.Point(123, 12);
            this.edtName.Name = "edtName";
            this.edtName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtName.Properties.Appearance.Options.UseBackColor = true;
            this.edtName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtName.Properties.Appearance.Options.UseFont = true;
            this.edtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtName.Size = new System.Drawing.Size(186, 24);
            this.edtName.TabIndex = 8;
            // 
            // grpNeuberechnung
            // 
            this.grpNeuberechnung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpNeuberechnung.Controls.Add(this.edtNeuberechnung);
            this.grpNeuberechnung.Controls.Add(this.lblVorlageText);
            this.grpNeuberechnung.Controls.Add(this.lblVorlage);
            this.grpNeuberechnung.Controls.Add(this.lblHundert);
            this.grpNeuberechnung.Controls.Add(this.edtMonatJahr);
            this.grpNeuberechnung.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpNeuberechnung.Location = new System.Drawing.Point(12, 54);
            this.grpNeuberechnung.Name = "grpNeuberechnung";
            this.grpNeuberechnung.Size = new System.Drawing.Size(297, 103);
            this.grpNeuberechnung.TabIndex = 9;
            this.grpNeuberechnung.TabStop = false;
            this.grpNeuberechnung.Text = "Neuberechnung";
            // 
            // DlgLandesindexKopieren
            // 
            this.AcceptButton = this.btnCopy;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(321, 207);
            this.Controls.Add(this.grpNeuberechnung);
            this.Controls.Add(this.edtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCopy);
            this.Name = "DlgLandesindexKopieren";
            this.Text = "Landesindex erfassen";
            ((System.ComponentModel.ISupportInitialize)(this.lblVorlageText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorlage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNeuberechnung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMonatJahr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHundert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).EndInit();
            this.grpNeuberechnung.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gui.KissButton btnCopy;
        private Gui.KissButton btnCancel;
        private Gui.KissLabel lblVorlageText;
        private Gui.KissLabel lblVorlage;
        private Gui.KissCheckEdit edtNeuberechnung;
        private Gui.KissDateEdit edtMonatJahr;
        private Gui.KissLabel lblHundert;
        private Gui.KissLabel lblName;
        private Gui.KissTextEdit edtName;
        private Gui.KissGroupBox grpNeuberechnung;

    }
}
