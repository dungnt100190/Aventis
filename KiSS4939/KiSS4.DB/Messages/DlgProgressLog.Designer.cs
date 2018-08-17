namespace KiSS4.Messages
{
    partial class DlgProgressLog
    {
        #region Dispose

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgProgressLog));
            this.components = new System.ComponentModel.Container();
            this.btnCancelClose = new System.Windows.Forms.Button();
            this.picProgressLog = new System.Windows.Forms.PictureBox();
            this.lstProgressLog = new System.Windows.Forms.ListBox();
            this.btnClipboard = new System.Windows.Forms.Button();
            this.ttpProgress = new System.Windows.Forms.ToolTip();
            ((System.ComponentModel.ISupportInitialize)(this.picProgressLog)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelClose
            // 
            this.btnCancelClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelClose.Location = new System.Drawing.Point(427, 248);
            this.btnCancelClose.Name = "btnCancelClose";
            this.btnCancelClose.Size = new System.Drawing.Size(75, 23);
            this.btnCancelClose.TabIndex = 2;
            this.btnCancelClose.Text = "Abbruch";
            this.btnCancelClose.Click += new System.EventHandler(this.btnCancelClose_Click);
            // 
            // picProgressLog
            // 
            this.picProgressLog.Image = ((System.Drawing.Image)(resources.GetObject("picProgressLog.Image")));
            this.picProgressLog.Location = new System.Drawing.Point(12, 12);
            this.picProgressLog.Name = "picProgressLog";
            this.picProgressLog.Size = new System.Drawing.Size(44, 44);
            this.picProgressLog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picProgressLog.TabIndex = 5;
            this.picProgressLog.TabStop = false;
            // 
            // lstProgressLog
            // 
            this.lstProgressLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstProgressLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstProgressLog.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstProgressLog.HorizontalScrollbar = true;
            this.lstProgressLog.ItemHeight = 16;
            this.lstProgressLog.Location = new System.Drawing.Point(60, 12);
            this.lstProgressLog.Name = "lstProgressLog";
            this.lstProgressLog.Size = new System.Drawing.Size(442, 226);
            this.lstProgressLog.TabIndex = 0;
            this.lstProgressLog.SelectedIndexChanged += new System.EventHandler(this.lstProgressLog_SelectedIndexChanged);
            // 
            // btnClipboard
            // 
            this.btnClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClipboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClipboard.Location = new System.Drawing.Point(310, 248);
            this.btnClipboard.Name = "btnClipboard";
            this.btnClipboard.Size = new System.Drawing.Size(114, 23);
            this.btnClipboard.TabIndex = 1;
            this.btnClipboard.Text = "Zwischenablage";
            this.btnClipboard.Visible = false;
            this.btnClipboard.Click += new System.EventHandler(this.btnClipboard_Click);
            // 
            // DlgProgressLog
            // 
            this.AcceptButton = this.btnCancelClose;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancelClose;
            this.ClientSize = new System.Drawing.Size(514, 278);
            this.ControlBox = false;
            this.Controls.Add(this.btnClipboard);
            this.Controls.Add(this.lstProgressLog);
            this.Controls.Add(this.picProgressLog);
            this.Controls.Add(this.btnCancelClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgProgressLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fortschritt";
            this.Activated += new System.EventHandler(this.DlgProgressLog_Activated);
            this.Closed += new System.EventHandler(this.DlgProgressLog_Closed);
            ((System.ComponentModel.ISupportInitialize)(this.picProgressLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox picProgressLog;
        private System.Windows.Forms.ToolTip ttpProgress;
        private System.Windows.Forms.Button btnCancelClose;
        private System.Windows.Forms.Button btnClipboard;
        private System.Windows.Forms.ListBox lstProgressLog;
    }
}
