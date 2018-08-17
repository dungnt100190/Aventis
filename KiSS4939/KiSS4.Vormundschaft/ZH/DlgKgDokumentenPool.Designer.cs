namespace KiSS4.Vormundschaft.ZH
{
    partial class DlgKgDokumentenPool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgKgDokumentenPool));
            this.toolTip1 = new System.Windows.Forms.ToolTip();
            this.qryDokumente = new KiSS4.DB.SqlQuery();
            this.btnClose = new KiSS4.Gui.KissButton();
            this.ctlDokPool = new KiSS4.Vormundschaft.ZH.CtlKgDokumentenPool();
            ((System.ComponentModel.ISupportInitialize)(this.qryDokumente)).BeginInit();
            this.SuspendLayout();
            // 
            // qryDokumente
            // 
            this.qryDokumente.CanInsert = true;
            this.qryDokumente.CanUpdate = true;
            this.qryDokumente.SelectStatement = resources.GetString("qryDokumente.SelectStatement");
            this.qryDokumente.TableName = "KgBewilligung";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(746, 441);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 24);
            this.btnClose.TabIndex = 345;
            this.btnClose.Text = "Schliessen";
            this.btnClose.UseCompatibleTextRendering = true;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // ctlDokPool
            // 
            this.ctlDokPool.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlDokPool.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlDokPool.Location = new System.Drawing.Point(2, 2);
            this.ctlDokPool.Name = "ctlDokPool";
            this.ctlDokPool.Size = new System.Drawing.Size(838, 417);
            this.ctlDokPool.TabIndex = 346;
            this.ctlDokPool.CloseEvent += new System.EventHandler(this.ctlDokPool_CloseEvent);
            // 
            // DlgKgDokumentenPool
            // 
            this.ActiveSQLQuery = this.qryDokumente;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 474);
            this.Controls.Add(this.ctlDokPool);
            this.Controls.Add(this.btnClose);
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "DlgKgDokumentenPool";
            this.Text = "ZKB Dokumente zuordnen";
            ((System.ComponentModel.ISupportInitialize)(this.qryDokumente)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private DB.SqlQuery qryDokumente;
        private CtlKgDokumentenPool ctlDokPool;
        private Gui.KissButton btnClose;
    }
}