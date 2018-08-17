namespace KiSS4.Messages
{
    partial class DlgButtons
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgButtons));
            this.picQuestion = new System.Windows.Forms.PictureBox();
            this.txtQuestion = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picQuestion)).BeginInit();
            this.SuspendLayout();
            //
            // picQuestion
            //
            this.picQuestion.Image = ((System.Drawing.Image)(resources.GetObject("picQuestion.Image")));
            this.picQuestion.Location = new System.Drawing.Point(12, 12);
            this.picQuestion.Name = "picQuestion";
            this.picQuestion.Size = new System.Drawing.Size(32, 32);
            this.picQuestion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picQuestion.TabIndex = 5;
            this.picQuestion.TabStop = false;
            //
            // txtQuestion
            //
            this.txtQuestion.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtQuestion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtQuestion.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtQuestion.Location = new System.Drawing.Point(60, 18);
            this.txtQuestion.Multiline = true;
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.ReadOnly = true;
            this.txtQuestion.Size = new System.Drawing.Size(232, 32);
            this.txtQuestion.TabIndex = 7;
            this.txtQuestion.TabStop = false;
            //
            // DlgButtons
            //
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(314, 94);
            this.Controls.Add(this.txtQuestion);
            this.Controls.Add(this.picQuestion);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(320, 120);
            this.Name = "DlgButtons";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "-1";
            this.Text = "KiSS";
            this.Load += new System.EventHandler(this.DlgButtons_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DlgButtons_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.picQuestion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnDefaultButton = null;
        private System.Windows.Forms.PictureBox picQuestion;
        private System.Windows.Forms.TextBox txtQuestion;
    }
}
