namespace KiSS4.Sozialhilfe.ZH
{
    partial class DlgPositionBewilligungAnfragen
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
            this.lblSammelposition = new KiSS4.Gui.KissLabel();
            this.btnDetails = new KiSS4.Gui.KissButton();
            ((System.ComponentModel.ISupportInitialize)(this.lblSammelposition)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSammelposition
            // 
            this.lblSammelposition.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblSammelposition.ForeColor = System.Drawing.Color.Red;
            this.lblSammelposition.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSammelposition.Location = new System.Drawing.Point(244, 13);
            this.lblSammelposition.Name = "lblSammelposition";
            this.lblSammelposition.Size = new System.Drawing.Size(293, 63);
            this.lblSammelposition.TabIndex = 16;
            this.lblSammelposition.Text = "Sammelposition";
            this.lblSammelposition.UseCompatibleTextRendering = true;
            this.lblSammelposition.Visible = false;
            // 
            // btnDetails
            // 
            this.btnDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetails.Location = new System.Drawing.Point(554, 9);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(90, 24);
            this.btnDetails.TabIndex = 17;
            this.btnDetails.Text = "Details";
            this.btnDetails.UseCompatibleTextRendering = true;
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Visible = false;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // DlgPositionBewilligungAnfragen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(656, 298);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.lblSammelposition);
            this.Name = "DlgPositionBewilligungAnfragen";
            this.Controls.SetChildIndex(this.lblSammelposition, 0);
            this.Controls.SetChildIndex(this.btnDetails, 0);
            ((System.ComponentModel.ISupportInitialize)(this.lblSammelposition)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gui.KissLabel lblSammelposition;
        private Gui.KissButton btnDetails;
    }
}
