namespace KiSS4.Vormundschaft.ZH
{
    partial class DlgKgDokumente
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
            this.toolTip1 = new System.Windows.Forms.ToolTip();
            this.btnOk = new KiSS4.Gui.KissButton();
            this.ctlDoks = new KiSS4.Vormundschaft.ZH.CtlKgDokumente();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(746, 441);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(90, 24);
            this.btnOk.TabIndex = 345;
            this.btnOk.Text = "Schliessen";
            this.btnOk.UseCompatibleTextRendering = true;
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // ctlDoks
            // 
            this.ctlDoks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlDoks.AutoRefresh = false;
            this.ctlDoks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlDoks.Location = new System.Drawing.Point(2, 2);
            this.ctlDoks.Name = "ctlDoks";
            this.ctlDoks.Size = new System.Drawing.Size(838, 417);
            this.ctlDoks.TabIndex = 346;
            // 
            // DlgKgDokumente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 474);
            this.Controls.Add(this.ctlDoks);
            this.Controls.Add(this.btnOk);
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "DlgKgDokumente";
            this.Text = "ZKB Dokumente zuordnen";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private CtlKgDokumente ctlDoks;
        private Gui.KissButton btnOk;
    }
}