namespace KiSS4.Common
{
    partial class KissPLZOrt
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.EdtLand = new KiSS4.Gui.KissLookUpEdit();
            this.EdtOrt = new KiSS4.Gui.KissTextEdit();
            this.EdtKanton = new KiSS4.Gui.KissTextEdit();
            this.EdtPLZ = new KiSS4.Gui.KissTextEdit();
            this.EdtBezirk = new KiSS4.Gui.KissTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.EdtLand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EdtLand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EdtOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EdtKanton.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EdtPLZ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EdtBezirk.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // EdtLand
            //
            this.EdtLand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.EdtLand.FilterOnIsActive = true;
            this.EdtLand.Location = new System.Drawing.Point(0, 46);
            this.EdtLand.LOVName = "BaLand";
            this.EdtLand.Name = "EdtLand";
            this.EdtLand.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.EdtLand.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.EdtLand.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.EdtLand.Properties.Appearance.Options.UseBackColor = true;
            this.EdtLand.Properties.Appearance.Options.UseBorderColor = true;
            this.EdtLand.Properties.Appearance.Options.UseFont = true;
            this.EdtLand.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.EdtLand.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.EdtLand.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.EdtLand.Properties.AppearanceDropDown.Options.UseFont = true;
            this.EdtLand.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.EdtLand.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.EdtLand.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.EdtLand.Properties.NullText = "";
            this.EdtLand.Properties.ShowFooter = false;
            this.EdtLand.Properties.ShowHeader = false;
            this.EdtLand.Size = new System.Drawing.Size(270, 24);
            this.EdtLand.TabIndex = 4;
            this.EdtLand.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edt_UserModifiedFld);
            //
            // EdtOrt
            //
            this.EdtOrt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.EdtOrt.Location = new System.Drawing.Point(44, 0);
            this.EdtOrt.Name = "EdtOrt";
            this.EdtOrt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.EdtOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.EdtOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.EdtOrt.Properties.Appearance.Options.UseBackColor = true;
            this.EdtOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.EdtOrt.Properties.Appearance.Options.UseFont = true;
            this.EdtOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.EdtOrt.Size = new System.Drawing.Size(196, 24);
            this.EdtOrt.TabIndex = 1;
            this.EdtOrt.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edt_UserModifiedFld);
            this.EdtOrt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edt_KeyDown);
            //
            // EdtKanton
            //
            this.EdtKanton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EdtKanton.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.EdtKanton.Location = new System.Drawing.Point(239, 0);
            this.EdtKanton.Name = "EdtKanton";
            this.EdtKanton.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.EdtKanton.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.EdtKanton.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.EdtKanton.Properties.Appearance.Options.UseBackColor = true;
            this.EdtKanton.Properties.Appearance.Options.UseBorderColor = true;
            this.EdtKanton.Properties.Appearance.Options.UseFont = true;
            this.EdtKanton.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.EdtKanton.Properties.ReadOnly = true;
            this.EdtKanton.Size = new System.Drawing.Size(31, 24);
            this.EdtKanton.TabIndex = 2;
            this.EdtKanton.TabStop = false;
            //
            // EdtPLZ
            //
            this.EdtPLZ.Location = new System.Drawing.Point(0, 0);
            this.EdtPLZ.Name = "EdtPLZ";
            this.EdtPLZ.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.EdtPLZ.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.EdtPLZ.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.EdtPLZ.Properties.Appearance.Options.UseBackColor = true;
            this.EdtPLZ.Properties.Appearance.Options.UseBorderColor = true;
            this.EdtPLZ.Properties.Appearance.Options.UseFont = true;
            this.EdtPLZ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.EdtPLZ.Size = new System.Drawing.Size(45, 24);
            this.EdtPLZ.TabIndex = 0;
            this.EdtPLZ.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edt_UserModifiedFld);
            this.EdtPLZ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edt_KeyDown);
            //
            // EdtBezirk
            //
            this.EdtBezirk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.EdtBezirk.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.EdtBezirk.Location = new System.Drawing.Point(0, 23);
            this.EdtBezirk.Name = "EdtBezirk";
            this.EdtBezirk.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.EdtBezirk.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.EdtBezirk.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.EdtBezirk.Properties.Appearance.Options.UseBackColor = true;
            this.EdtBezirk.Properties.Appearance.Options.UseBorderColor = true;
            this.EdtBezirk.Properties.Appearance.Options.UseFont = true;
            this.EdtBezirk.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.EdtBezirk.Properties.ReadOnly = true;
            this.EdtBezirk.Size = new System.Drawing.Size(270, 24);
            this.EdtBezirk.TabIndex = 3;
            //
            // KissPLZOrt
            //
            this.Controls.Add(this.EdtBezirk);
            this.Controls.Add(this.EdtLand);
            this.Controls.Add(this.EdtOrt);
            this.Controls.Add(this.EdtKanton);
            this.Controls.Add(this.EdtPLZ);
            this.Name = "KissPLZOrt";
            this.Size = new System.Drawing.Size(270, 70);
            ((System.ComponentModel.ISupportInitialize)(this.EdtLand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EdtLand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EdtOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EdtKanton.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EdtPLZ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EdtBezirk.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        public KiSS4.Gui.KissTextEdit EdtBezirk;
        public KiSS4.Gui.KissTextEdit EdtKanton;
        public KiSS4.Gui.KissLookUpEdit EdtLand;
        public KiSS4.Gui.KissTextEdit EdtOrt;
        public KiSS4.Gui.KissTextEdit EdtPLZ;
    }
}
