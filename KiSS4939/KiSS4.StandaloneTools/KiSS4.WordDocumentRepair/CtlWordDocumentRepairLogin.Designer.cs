namespace KiSS4.WordDocumentRepair
{
    partial class CtlWordDocumentRepairLogin
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
            this.ctlWordDocumentRepair = new KiSS4.WordDocumentRepair.CtlWordDocumentRepair();
            this.lblLoginStatus = new KiSS4.Gui.KissLabel();
            this.btnLogin = new KiSS4.Gui.KissButton();
            this.grpLogin = new KiSS4.Gui.KissGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.lblLoginStatus)).BeginInit();
            this.grpLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctlWordDocumentRepair
            // 
            this.ctlWordDocumentRepair.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlWordDocumentRepair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlWordDocumentRepair.Location = new System.Drawing.Point(4, 94);
            this.ctlWordDocumentRepair.MinimumSize = new System.Drawing.Size(430, 339);
            this.ctlWordDocumentRepair.Name = "ctlWordDocumentRepair";
            this.ctlWordDocumentRepair.Size = new System.Drawing.Size(628, 355);
            this.ctlWordDocumentRepair.TabIndex = 1;
            // 
            // lblLoginStatus
            // 
            this.lblLoginStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLoginStatus.Location = new System.Drawing.Point(6, 21);
            this.lblLoginStatus.Name = "lblLoginStatus";
            this.lblLoginStatus.Size = new System.Drawing.Size(612, 24);
            this.lblLoginStatus.TabIndex = 0;
            this.lblLoginStatus.Text = "lblLoginStatus";
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Location = new System.Drawing.Point(528, 55);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(90, 24);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // grpLogin
            // 
            this.grpLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpLogin.Controls.Add(this.lblLoginStatus);
            this.grpLogin.Controls.Add(this.btnLogin);
            this.grpLogin.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpLogin.Location = new System.Drawing.Point(0, 3);
            this.grpLogin.Name = "grpLogin";
            this.grpLogin.Size = new System.Drawing.Size(624, 85);
            this.grpLogin.TabIndex = 2;
            this.grpLogin.TabStop = false;
            this.grpLogin.Text = "Login";
            // 
            // CtlWordDocumentRepairLogin
            // 
            this.Controls.Add(this.grpLogin);
            this.Controls.Add(this.ctlWordDocumentRepair);
            this.Name = "CtlWordDocumentRepairLogin";
            this.Size = new System.Drawing.Size(635, 451);
            ((System.ComponentModel.ISupportInitialize)(this.lblLoginStatus)).EndInit();
            this.grpLogin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CtlWordDocumentRepair ctlWordDocumentRepair;
        private Gui.KissLabel lblLoginStatus;
        private Gui.KissButton btnLogin;
        private Gui.KissGroupBox grpLogin;
    }
}
