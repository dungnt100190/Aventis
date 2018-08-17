namespace KiSS4.Messages
{
    partial class DlgError
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgError));
            this.tabError = new SharpLibrary.WinControls.TabControlEx();
            this.tpgUser = new SharpLibrary.WinControls.TabPageEx();
            this.txtUserText = new System.Windows.Forms.TextBox();
            this.picError = new System.Windows.Forms.PictureBox();
            this.tpgTechnical = new SharpLibrary.WinControls.TabPageEx();
            this.txtTechnicalText = new System.Windows.Forms.TextBox();
            this.tpgSupport = new SharpLibrary.WinControls.TabPageEx();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabError.SuspendLayout();
            this.tpgUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).BeginInit();
            this.tpgTechnical.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabError
            // 
            this.tabError.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabError.BorderStyleEx = SharpLibrary.WinControls.BorderStyleEx.FixedSingle;
            this.tabError.Controls.Add(this.tpgUser);
            this.tabError.Controls.Add(this.tpgTechnical);
            this.tabError.Controls.Add(this.tpgSupport);
            this.tabError.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabError.FirstTabMargin = 0;
            this.tabError.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tabError.Location = new System.Drawing.Point(4, 2);
            this.tabError.Name = "tabError";
            this.tabError.ShowFixedWidthTooltip = true;
            this.tabError.Size = new System.Drawing.Size(496, 226);
            this.tabError.TabIndex = 0;
            this.tabError.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgUser,
            this.tpgTechnical,
            this.tpgSupport});
            this.tabError.TabsAreaBackColor = System.Drawing.Color.Empty;
            this.tabError.TabsFitting = SharpLibrary.WinControls.TabsFitting.ShrinkTabs;
            this.tabError.TabsLineColor = System.Drawing.Color.Black;
            this.tabError.TabsLocation = SharpLibrary.WinControls.TabsLocation.Top;
            this.tabError.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabError.TabStop = false;
            this.tabError.Text = "TabControleX1";
            // 
            // tpgUser
            // 
            this.tpgUser.Controls.Add(this.txtUserText);
            this.tpgUser.Controls.Add(this.picError);
            this.tpgUser.Location = new System.Drawing.Point(6, 32);
            this.tpgUser.Name = "tpgUser";
            this.tpgUser.Size = new System.Drawing.Size(484, 188);
            this.tpgUser.TabIndex = 0;
            this.tpgUser.Title = "Fehler";
            // 
            // txtUserText
            // 
            this.txtUserText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUserText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserText.Location = new System.Drawing.Point(60, 18);
            this.txtUserText.Multiline = true;
            this.txtUserText.Name = "txtUserText";
            this.txtUserText.ReadOnly = true;
            this.txtUserText.Size = new System.Drawing.Size(410, 160);
            this.txtUserText.TabIndex = 4;
            this.txtUserText.TabStop = false;
            this.txtUserText.Text = "UserText";
            // 
            // picError
            // 
            this.picError.Image = ((System.Drawing.Image)(resources.GetObject("picError.Image")));
            this.picError.Location = new System.Drawing.Point(12, 12);
            this.picError.Name = "picError";
            this.picError.Size = new System.Drawing.Size(32, 32);
            this.picError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picError.TabIndex = 0;
            this.picError.TabStop = false;
            // 
            // tpgTechnical
            // 
            this.tpgTechnical.Controls.Add(this.txtTechnicalText);
            this.tpgTechnical.Location = new System.Drawing.Point(6, 32);
            this.tpgTechnical.Name = "tpgTechnical";
            this.tpgTechnical.Size = new System.Drawing.Size(484, 188);
            this.tpgTechnical.TabIndex = 1;
            this.tpgTechnical.Title = "Technische Info";
            // 
            // txtTechnicalText
            // 
            this.txtTechnicalText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTechnicalText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTechnicalText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTechnicalText.Location = new System.Drawing.Point(12, 12);
            this.txtTechnicalText.Multiline = true;
            this.txtTechnicalText.Name = "txtTechnicalText";
            this.txtTechnicalText.ReadOnly = true;
            this.txtTechnicalText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTechnicalText.Size = new System.Drawing.Size(458, 166);
            this.txtTechnicalText.TabIndex = 5;
            this.txtTechnicalText.Text = "TechnicalText";
            // 
            // tpgSupport
            // 
            this.tpgSupport.Location = new System.Drawing.Point(6, 32);
            this.tpgSupport.Name = "tpgSupport";
            this.tpgSupport.Size = new System.Drawing.Size(484, 188);
            this.tpgSupport.TabIndex = 2;
            this.tpgSupport.Title = "Support";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(425, 234);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "&OK";
            // 
            // DlgError
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(504, 267);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabError);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgError";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fehlermeldung";
            this.Load += new System.EventHandler(this.DlgError_Load);
            this.tabError.ResumeLayout(false);
            this.tpgUser.ResumeLayout(false);
            this.tpgUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).EndInit();
            this.tpgTechnical.ResumeLayout(false);
            this.tpgTechnical.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.PictureBox picError;
        private SharpLibrary.WinControls.TabControlEx tabError;
        private SharpLibrary.WinControls.TabPageEx tpgSupport;
        private SharpLibrary.WinControls.TabPageEx tpgTechnical;
        private SharpLibrary.WinControls.TabPageEx tpgUser;
        private System.Windows.Forms.TextBox txtTechnicalText;
        private System.Windows.Forms.TextBox txtUserText;
    }
}
