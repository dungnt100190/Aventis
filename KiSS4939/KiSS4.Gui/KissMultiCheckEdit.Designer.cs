namespace KiSS4.Gui
{
    partial class KissMultiCheckEdit
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
            this.edtCheckedLookup = new KiSS4.Gui.KissCheckedLookupEdit();
            this.chkEnableCheckedLookup = new KiSS4.Gui.KissCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCheckedLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEnableCheckedLookup.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // edtCheckedLookup
            // 
            this.edtCheckedLookup.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtCheckedLookup.Appearance.Options.UseBackColor = true;
            this.edtCheckedLookup.CheckOnClick = true;
            this.edtCheckedLookup.Location = new System.Drawing.Point(13, 22);
            this.edtCheckedLookup.Name = "edtCheckedLookup";
            this.edtCheckedLookup.Size = new System.Drawing.Size(184, 178);
            this.edtCheckedLookup.TabIndex = 32;
            this.edtCheckedLookup.EditValueChanged += new System.EventHandler(this.edtCheckedLookup_EditValueChanged);
            // 
            // chkEnableCheckedLookup
            // 
            this.chkEnableCheckedLookup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkEnableCheckedLookup.EditValue = false;
            this.chkEnableCheckedLookup.Location = new System.Drawing.Point(3, 3);
            this.chkEnableCheckedLookup.Name = "chkEnableCheckedLookup";
            this.chkEnableCheckedLookup.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkEnableCheckedLookup.Properties.Appearance.Options.UseBackColor = true;
            this.chkEnableCheckedLookup.Properties.Caption = "";
            this.chkEnableCheckedLookup.Size = new System.Drawing.Size(275, 19);
            this.chkEnableCheckedLookup.TabIndex = 31;
            this.chkEnableCheckedLookup.CheckedChanged += new System.EventHandler(this.chkEnableCheckedLookup_CheckedChanged);
            // 
            // KissMultiCheckEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.edtCheckedLookup);
            this.Controls.Add(this.chkEnableCheckedLookup);
            this.Name = "KissMultiCheckEdit";
            this.Size = new System.Drawing.Size(281, 248);
            ((System.ComponentModel.ISupportInitialize)(this.edtCheckedLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEnableCheckedLookup.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KissCheckedLookupEdit edtCheckedLookup;
        private KissCheckEdit chkEnableCheckedLookup;
    }
}
