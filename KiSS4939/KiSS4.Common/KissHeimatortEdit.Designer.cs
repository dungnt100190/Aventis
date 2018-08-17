using KiSS4.Gui;

namespace KiSS4.Common
{
    partial class KissHeimatortEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KissHeimatortEdit));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnHeimatorte = new KiSS4.Gui.KissButton();
            this.edtHeimatort = new KiSS4.Gui.KissButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHeimatort.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHeimatorte
            // 
            this.btnHeimatorte.Enabled = false;
            this.btnHeimatorte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHeimatorte.Image = ((System.Drawing.Image)(resources.GetObject("btnHeimatorte.Image")));
            this.btnHeimatorte.Location = new System.Drawing.Point(0, 0);
            this.btnHeimatorte.Margin = new System.Windows.Forms.Padding(0);
            this.btnHeimatorte.Name = "btnHeimatorte";
            this.btnHeimatorte.Size = new System.Drawing.Size(20, 24);
            this.btnHeimatorte.TabIndex = 583;
            this.btnHeimatorte.UseCompatibleTextRendering = true;
            this.btnHeimatorte.UseVisualStyleBackColor = false;
            this.btnHeimatorte.Click += new System.EventHandler(this.btnHeimatorte_Click);
            // 
            // edtHeimatort
            // 
            this.edtHeimatort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtHeimatort.EditValue = "";
            this.edtHeimatort.Location = new System.Drawing.Point(23, 0);
            this.edtHeimatort.Margin = new System.Windows.Forms.Padding(0);
            this.edtHeimatort.Name = "edtHeimatort";
            this.edtHeimatort.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtHeimatort.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHeimatort.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHeimatort.Properties.Appearance.Options.UseBackColor = true;
            this.edtHeimatort.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHeimatort.Properties.Appearance.Options.UseFont = true;
            this.edtHeimatort.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtHeimatort.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtHeimatort.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtHeimatort.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtHeimatort.Size = new System.Drawing.Size(169, 24);
            this.edtHeimatort.TabIndex = 582;
            this.edtHeimatort.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtHeimatort_UserModifiedFld);
            this.edtHeimatort.EditValueChanged += new System.EventHandler(this.edtHeimatort_EditValueChanged);
            // 
            // KissHeimatortEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnHeimatorte);
            this.Controls.Add(this.edtHeimatort);
            this.Name = "KissHeimatortEdit";
            this.Size = new System.Drawing.Size(192, 24);
            ((System.ComponentModel.ISupportInitialize)(this.edtHeimatort.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KissButton btnHeimatorte;
        private KissButtonEdit edtHeimatort;
    }
}
