namespace KiSS4.Vormundschaft
{
    partial class CtlVmBewertung
    {
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlVmBewertung));
            this.components = new System.ComponentModel.Container();
            this.lblTitel = new System.Windows.Forms.Label();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.ctlVmKriterien = new KiSS4.Vormundschaft.CtlVmKriterien();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblTitel.ForeColor = System.Drawing.Color.Black;
            this.lblTitel.Location = new System.Drawing.Point(35, 10);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(31, 15);
            this.lblTitel.TabIndex = 13;
            this.lblTitel.Text = "Titel";
            // 
            // picTitel
            // 
            this.picTitel.Image = ((System.Drawing.Image)(resources.GetObject("picTitel.Image")));
            this.picTitel.Location = new System.Drawing.Point(10, 9);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(25, 20);
            this.picTitel.TabIndex = 12;
            this.picTitel.TabStop = false;
            // 
            // ctlVmKriterien
            // 
            this.ctlVmKriterien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlVmKriterien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlVmKriterien.Location = new System.Drawing.Point(0, 30);
            this.ctlVmKriterien.Name = "ctlVmKriterien";
            this.ctlVmKriterien.Size = new System.Drawing.Size(668, 566);
            this.ctlVmKriterien.TabIndex = 681;
            // 
            // CtlVmBewertung
            // 
            
            this.Controls.Add(this.ctlVmKriterien);
            this.Controls.Add(this.picTitel);
            this.Controls.Add(this.lblTitel);
            this.Name = "CtlVmBewertung";
            this.Size = new System.Drawing.Size(677, 597);
            this.Load += new System.EventHandler(this.CtlVmBewertung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private CtlVmKriterien ctlVmKriterien;
        private System.Windows.Forms.Label lblTitel;
        private System.Windows.Forms.PictureBox picTitel;
    }
}
