namespace KiSS4.WordDocumentRepair
{
    partial class WordDocumentRepairForm
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
            this.ctlWordDocumentRepairLogin1 = new KiSS4.WordDocumentRepair.CtlWordDocumentRepairLogin();
            this.SuspendLayout();
            // 
            // ctlWordDocumentRepairLogin1
            // 
            this.ctlWordDocumentRepairLogin1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlWordDocumentRepairLogin1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlWordDocumentRepairLogin1.Location = new System.Drawing.Point(0, 0);
            this.ctlWordDocumentRepairLogin1.MinimumSize = new System.Drawing.Size(610, 451);
            this.ctlWordDocumentRepairLogin1.Name = "ctlWordDocumentRepairLogin1";
            this.ctlWordDocumentRepairLogin1.Size = new System.Drawing.Size(652, 456);
            this.ctlWordDocumentRepairLogin1.TabIndex = 0;
            // 
            // WordDocumentRepairForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(653, 456);
            this.Controls.Add(this.ctlWordDocumentRepairLogin1);
            this.Name = "WordDocumentRepairForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private CtlWordDocumentRepairLogin ctlWordDocumentRepairLogin1;

    }
}

