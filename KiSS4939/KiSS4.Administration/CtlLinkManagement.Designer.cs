namespace KiSS4.Administration
{
    partial class CtlLinkManagement
    {
        private System.ComponentModel.IContainer components = null;

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

        private void InitializeComponent()
        {
            this.panTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // panDetail
            // 
            this.panDetail.Location = new System.Drawing.Point(173, 31);
            this.panDetail.Size = new System.Drawing.Size(819, 612);
            // 
            // panTitle
            // 
            this.panTitle.Size = new System.Drawing.Size(819, 31);
            // 
            // splitterNavControl
            // 
            this.splitterNavControl.Size = new System.Drawing.Size(3, 643);
            // 
            // FrmLinkManagement
            // 
            this.ClientSize = new System.Drawing.Size(992, 643);
            this.Name = "FrmLinkManagement";
            this.panTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

    }
}
