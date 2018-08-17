using KiSS4.Gui;

namespace KiSS4.Common
{
    /// <summary>
    /// Summary description for DlgAuswahl.
    /// </summary>
    public class DlgPasswort : KiSS4.Gui.KissDialog
    {
        #region Fields

        #region Private Fields

        private KissButton btnCancel;
        private KissButton btnOK;
        private System.ComponentModel.IContainer components = null;
        private KissTextEdit edtPassword;
        private KissLabel lblPassordTitle;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DlgAuswahl"/> class.
        /// </summary>
        public DlgPasswort()
        {
            InitializeComponent();
        }

        public DlgPasswort(string dialogCaption, string title)
        {
            InitializeComponent();

            this.Text = dialogCaption;
            lblPassordTitle.Text = title;
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancel = new KiSS4.Gui.KissButton();
            this.btnOK = new KiSS4.Gui.KissButton();
            this.edtPassword = new KiSS4.Gui.KissTextEdit();
            this.lblPassordTitle = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.edtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPassordTitle)).BeginInit();
            this.SuspendLayout();
            //
            // btnCancel
            //
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(266, 80);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(73, 24);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseCompatibleTextRendering = true;
            this.btnCancel.UseVisualStyleBackColor = false;
            //
            // btnOK
            //
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(187, 80);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(73, 24);
            this.btnOK.TabIndex = 18;
            this.btnOK.Text = "OK";
            this.btnOK.UseCompatibleTextRendering = true;
            this.btnOK.UseVisualStyleBackColor = false;
            //
            // edtPassword
            //
            this.edtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtPassword.EditValue = "";
            this.edtPassword.Location = new System.Drawing.Point(12, 41);
            this.edtPassword.Name = "edtPassword";
            this.edtPassword.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPassword.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPassword.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPassword.Properties.Appearance.Options.UseBackColor = true;
            this.edtPassword.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPassword.Properties.Appearance.Options.UseFont = true;
            this.edtPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPassword.Properties.MaxLength = 45;
            this.edtPassword.Properties.Name = "kissTextEdit5.Properties";
            this.edtPassword.Size = new System.Drawing.Size(327, 24);
            this.edtPassword.TabIndex = 19;
            //
            // lblPassordTitle
            //
            this.lblPassordTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPassordTitle.Location = new System.Drawing.Point(12, 9);
            this.lblPassordTitle.Name = "lblPassordTitle";
            this.lblPassordTitle.Size = new System.Drawing.Size(327, 24);
            this.lblPassordTitle.TabIndex = 411;
            this.lblPassordTitle.Text = "Bitte geben Sie ein neues Passwort ein:";
            this.lblPassordTitle.UseCompatibleTextRendering = true;
            //
            // DlgPasswort
            //
            this.ClientSize = new System.Drawing.Size(351, 116);
            this.Controls.Add(this.lblPassordTitle);
            this.Controls.Add(this.edtPassword);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "DlgPasswort";
            this.Text = "Passwort";
            ((System.ComponentModel.ISupportInitialize)(this.edtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPassordTitle)).EndInit();
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

        #region Properties

        public string Password
        {
            get
            {
                return edtPassword.EditValue.ToString();
            }
        }

        #endregion
    }
}