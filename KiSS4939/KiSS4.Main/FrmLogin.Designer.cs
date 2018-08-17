using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using KiSS4.Gui;

namespace KiSS4.Main
{
    partial class FrmLogin
    {
        #region Private Fields

        private KiSS4.Gui.KissButton btnCancel;
        private KiSS4.Gui.KissButton btnLogin;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissImageComboBoxEdit edtEnvironment;
        private KiSS4.Gui.KissTextEdit edtPassword;
        private KiSS4.Gui.KissTextEdit edtUser;
        private KissLabel lblEnvironment;
        private KissLabel lblPassword;

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.edtPassword = new KiSS4.Gui.KissTextEdit();
            this.edtUser = new KiSS4.Gui.KissTextEdit();
            this.edtEnvironment = new KiSS4.Gui.KissImageComboBoxEdit();
            this.lblEnvironment = new KiSS4.Gui.KissLabel();
            this.lblPassword = new KiSS4.Gui.KissLabel();
            this.btnLogin = new KiSS4.Gui.KissButton();
            this.btnCancel = new KiSS4.Gui.KissButton();
            this.edtFilterEnvironments = new KiSS4.Gui.KissTextEdit();
            this.btnClearFilterEnvironments = new KiSS4.Gui.KissButton();
            this.lblFilterEnvironments = new KiSS4.Gui.KissLabel();
            this.rgrAnmeldung = new KiSS4.Gui.KissRadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.edtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEnvironment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEnvironment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterEnvironments.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilterEnvironments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgrAnmeldung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgrAnmeldung.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // edtPassword
            // 
            this.edtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtPassword.Location = new System.Drawing.Point(160, 137);
            this.edtPassword.Name = "edtPassword";
            this.edtPassword.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPassword.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPassword.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPassword.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtPassword.Properties.Appearance.Options.UseBackColor = true;
            this.edtPassword.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPassword.Properties.Appearance.Options.UseFont = true;
            this.edtPassword.Properties.Appearance.Options.UseForeColor = true;
            this.edtPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPassword.Properties.PasswordChar = '*';
            this.edtPassword.Size = new System.Drawing.Size(187, 24);
            this.edtPassword.TabIndex = 3;
            // 
            // edtUser
            // 
            this.edtUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtUser.Location = new System.Drawing.Point(160, 107);
            this.edtUser.Name = "edtUser";
            this.edtUser.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUser.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUser.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUser.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtUser.Properties.Appearance.Options.UseBackColor = true;
            this.edtUser.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUser.Properties.Appearance.Options.UseFont = true;
            this.edtUser.Properties.Appearance.Options.UseForeColor = true;
            this.edtUser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtUser.Size = new System.Drawing.Size(187, 24);
            this.edtUser.TabIndex = 1;
            // 
            // edtEnvironment
            // 
            this.edtEnvironment.Location = new System.Drawing.Point(116, 25);
            this.edtEnvironment.Name = "edtEnvironment";
            this.edtEnvironment.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEnvironment.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEnvironment.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEnvironment.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtEnvironment.Properties.Appearance.Options.UseBackColor = true;
            this.edtEnvironment.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEnvironment.Properties.Appearance.Options.UseFont = true;
            this.edtEnvironment.Properties.Appearance.Options.UseForeColor = true;
            this.edtEnvironment.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtEnvironment.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtEnvironment.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtEnvironment.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtEnvironment.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEnvironment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtEnvironment.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEnvironment.Size = new System.Drawing.Size(292, 24);
            this.edtEnvironment.TabIndex = 9;
            this.edtEnvironment.EditValueChanged += new System.EventHandler(this.editEnvironment_EditValueChanged);
            // 
            // lblEnvironment
            // 
            this.lblEnvironment.Location = new System.Drawing.Point(16, 24);
            this.lblEnvironment.Name = "lblEnvironment";
            this.lblEnvironment.Size = new System.Drawing.Size(94, 24);
            this.lblEnvironment.TabIndex = 8;
            this.lblEnvironment.Text = "Umgebung";
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPassword.Location = new System.Drawing.Point(32, 137);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(122, 24);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Passwort";
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Location = new System.Drawing.Point(215, 187);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(88, 24);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Anmelden";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(320, 187);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 24);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Abbruch";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // edtFilterEnvironments
            // 
            this.edtFilterEnvironments.Location = new System.Drawing.Point(353, 55);
            this.edtFilterEnvironments.Name = "edtFilterEnvironments";
            this.edtFilterEnvironments.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFilterEnvironments.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFilterEnvironments.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFilterEnvironments.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtFilterEnvironments.Properties.Appearance.Options.UseBackColor = true;
            this.edtFilterEnvironments.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFilterEnvironments.Properties.Appearance.Options.UseFont = true;
            this.edtFilterEnvironments.Properties.Appearance.Options.UseForeColor = true;
            this.edtFilterEnvironments.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFilterEnvironments.Size = new System.Drawing.Size(25, 24);
            this.edtFilterEnvironments.TabIndex = 7;
            this.edtFilterEnvironments.Visible = false;
            this.edtFilterEnvironments.EditValueChanged += new System.EventHandler(this.edtFilterEnvironments_EditValueChanged);
            // 
            // btnClearFilterEnvironments
            // 
            this.btnClearFilterEnvironments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFilterEnvironments.Image = ((System.Drawing.Image)(resources.GetObject("btnClearFilterEnvironments.Image")));
            this.btnClearFilterEnvironments.Location = new System.Drawing.Point(384, 55);
            this.btnClearFilterEnvironments.Name = "btnClearFilterEnvironments";
            this.btnClearFilterEnvironments.Padding = new System.Windows.Forms.Padding(0, 0, 3, 2);
            this.btnClearFilterEnvironments.Size = new System.Drawing.Size(24, 24);
            this.btnClearFilterEnvironments.TabIndex = 10;
            this.btnClearFilterEnvironments.UseVisualStyleBackColor = false;
            this.btnClearFilterEnvironments.Visible = false;
            this.btnClearFilterEnvironments.Click += new System.EventHandler(this.btnClearFilterEnvironments_Click);
            // 
            // lblFilterEnvironments
            // 
            this.lblFilterEnvironments.Location = new System.Drawing.Point(318, 55);
            this.lblFilterEnvironments.Name = "lblFilterEnvironments";
            this.lblFilterEnvironments.Size = new System.Drawing.Size(29, 24);
            this.lblFilterEnvironments.TabIndex = 6;
            this.lblFilterEnvironments.Text = "Filter";
            this.lblFilterEnvironments.Visible = false;
            // 
            // rgrAnmeldung
            // 
            this.rgrAnmeldung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rgrAnmeldung.DataMember = "NichtErsch";
            this.rgrAnmeldung.EditValue = "";
            this.rgrAnmeldung.Location = new System.Drawing.Point(12, 73);
            this.rgrAnmeldung.LookupSQL = null;
            this.rgrAnmeldung.LOVFilter = null;
            this.rgrAnmeldung.LOVName = null;
            this.rgrAnmeldung.Name = "rgrAnmeldung";
            this.rgrAnmeldung.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgrAnmeldung.Properties.Appearance.Options.UseBackColor = true;
            this.rgrAnmeldung.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.rgrAnmeldung.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.rgrAnmeldung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgrAnmeldung.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "Windows Benutzer"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("0", "Benutzer/-in")});
            this.rgrAnmeldung.Size = new System.Drawing.Size(142, 67);
            this.rgrAnmeldung.TabIndex = 11;
            this.rgrAnmeldung.SelectedIndexChanged += new System.EventHandler(this.rgrAnmeldung_SelectedIndexChanged);
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(420, 223);
            this.Controls.Add(this.btnClearFilterEnvironments);
            this.Controls.Add(this.edtFilterEnvironments);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblFilterEnvironments);
            this.Controls.Add(this.lblEnvironment);
            this.Controls.Add(this.edtEnvironment);
            this.Controls.Add(this.edtUser);
            this.Controls.Add(this.edtPassword);
            this.Controls.Add(this.rgrAnmeldung);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Anmelden";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.edtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEnvironment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEnvironment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterEnvironments.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilterEnvironments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgrAnmeldung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgrAnmeldung)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region Dispose

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

        #endregion

        private KissTextEdit edtFilterEnvironments;
        private KissButton btnClearFilterEnvironments;
        private KissLabel lblFilterEnvironments;
        private KissRadioGroup rgrAnmeldung;
    }
}
