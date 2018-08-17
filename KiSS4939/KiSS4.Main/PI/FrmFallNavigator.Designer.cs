namespace KiSS4.Main.PI
{
    partial class FrmFallNavigator
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
            this.ctlFallNavigator = new KiSS4.Main.PI.CtlFallNavigator();
            this.SuspendLayout();
            // 
            // ctlFallNavigator
            // 
            this.ctlFallNavigator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlFallNavigator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlFallNavigator.Location = new System.Drawing.Point(0, 0);
            this.ctlFallNavigator.Name = "ctlFallNavigator";
            this.ctlFallNavigator.Size = new System.Drawing.Size(717, 500);
            this.ctlFallNavigator.TabIndex = 0;
            // 
            // FrmFallNavigator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 500);
            this.Controls.Add(this.ctlFallNavigator);
            this.Name = "FrmFallNavigator";
            this.Text = "Fall-Navigator";
            this.ResumeLayout(false);

        }

        #endregion

        private CtlFallNavigator ctlFallNavigator;
    }
}
