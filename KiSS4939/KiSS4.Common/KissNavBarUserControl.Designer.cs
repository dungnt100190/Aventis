namespace KiSS4.Common
{
    partial class KissNavBarUserControl
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
            this.panDetail = new System.Windows.Forms.Panel();
            this.picTitle = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panTitle = new System.Windows.Forms.Panel();
            this.splitterNavControl = new KiSS4.Gui.KissSplitter();
            this.navBar = new DevExpress.XtraNavBar.NavBarControl();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            this.panTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBar)).BeginInit();
            this.SuspendLayout();
            // 
            // panDetail
            // 
            this.panDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.panDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panDetail.Location = new System.Drawing.Point(173, 29);
            this.panDetail.Name = "panDetail";
            this.panDetail.Size = new System.Drawing.Size(728, 638);
            this.panDetail.TabIndex = 15;
            // 
            // picTitle
            // 
            this.picTitle.Location = new System.Drawing.Point(10, 2);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(24, 24);
            this.picTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTitle.TabIndex = 0;
            this.picTitle.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Location = new System.Drawing.Point(42, 2);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(524, 25);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Titel";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Visible = false;
            // 
            // panTitle
            // 
            this.panTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.panTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panTitle.Controls.Add(this.picTitle);
            this.panTitle.Controls.Add(this.lblTitle);
            this.panTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitle.Location = new System.Drawing.Point(173, 0);
            this.panTitle.Name = "panTitle";
            this.panTitle.Size = new System.Drawing.Size(728, 29);
            this.panTitle.TabIndex = 14;
            // 
            // splitterNavControl
            // 
            this.splitterNavControl.Location = new System.Drawing.Point(170, 0);
            this.splitterNavControl.Name = "splitterNavControl";
            this.splitterNavControl.Size = new System.Drawing.Size(3, 667);
            this.splitterNavControl.TabIndex = 13;
            this.splitterNavControl.TabStop = false;
            // 
            // navBar
            // 
            this.navBar.ActiveGroup = null;
            this.navBar.Appearance.Background.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.navBar.Appearance.Background.Options.UseBackColor = true;
            this.navBar.Appearance.GroupBackground.BackColor = System.Drawing.Color.Lavender;
            this.navBar.Appearance.GroupBackground.Options.UseBackColor = true;
            this.navBar.Appearance.GroupHeaderActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.navBar.Appearance.GroupHeaderActive.Options.UseFont = true;
            this.navBar.Appearance.GroupHeaderActive.Options.UseTextOptions = true;
            this.navBar.Appearance.GroupHeaderActive.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.navBar.Appearance.GroupHeaderHotTracked.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.navBar.Appearance.GroupHeaderHotTracked.Options.UseFont = true;
            this.navBar.Appearance.GroupHeaderHotTracked.Options.UseTextOptions = true;
            this.navBar.Appearance.GroupHeaderHotTracked.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.navBar.Appearance.GroupHeaderPressed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.navBar.Appearance.GroupHeaderPressed.Options.UseFont = true;
            this.navBar.Appearance.ItemDisabled.Options.UseTextOptions = true;
            this.navBar.Appearance.ItemDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.navBar.Appearance.ItemDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.navBar.Appearance.ItemHotTracked.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Underline);
            this.navBar.Appearance.ItemHotTracked.Options.UseFont = true;
            this.navBar.Appearance.ItemHotTracked.Options.UseTextOptions = true;
            this.navBar.Appearance.ItemHotTracked.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.navBar.Appearance.ItemHotTracked.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.navBar.Appearance.ItemPressed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Underline);
            this.navBar.Appearance.ItemPressed.Options.UseFont = true;
            this.navBar.Appearance.ItemPressed.Options.UseTextOptions = true;
            this.navBar.Appearance.ItemPressed.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.navBar.Appearance.ItemPressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.navBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBar.Location = new System.Drawing.Point(0, 0);
            this.navBar.Name = "navBar";
            this.navBar.Size = new System.Drawing.Size(170, 667);
            this.navBar.TabIndex = 12;
            this.navBar.View = new DevExpress.XtraNavBar.ViewInfo.AdvExplorerBarViewInfoRegistrator();
            this.navBar.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBar_LinkClicked);
            // 
            // KissNavBarUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panDetail);
            this.Controls.Add(this.panTitle);
            this.Controls.Add(this.splitterNavControl);
            this.Controls.Add(this.navBar);
            this.Name = "KissNavBarUserControl";
            this.Size = new System.Drawing.Size(901, 667);
            this.Load += new System.EventHandler(this.KissNavBarUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            this.panTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel panDetail;
        protected System.Windows.Forms.PictureBox picTitle;
        protected System.Windows.Forms.Label lblTitle;
        protected internal System.Windows.Forms.Panel panTitle;
        protected Gui.KissSplitter splitterNavControl;
        protected DevExpress.XtraNavBar.NavBarControl navBar;
    }
}
