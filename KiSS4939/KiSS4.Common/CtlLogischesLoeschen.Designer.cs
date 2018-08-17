namespace KiSS4.Common
{
    partial class CtlLogischesLoeschen
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
            this.btnRestoreDocument = new KiSS4.Gui.KissButton();
            this.ctlCreatorModifier = new KiSS4.Common.CtlCreationModification();
            this.SuspendLayout();
            // 
            // btnRestoreDocument
            // 
            this.btnRestoreDocument.Enabled = false;
            this.btnRestoreDocument.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestoreDocument.Location = new System.Drawing.Point(294, 14);
            this.btnRestoreDocument.Name = "btnRestoreDocument";
            this.btnRestoreDocument.Size = new System.Drawing.Size(228, 24);
            this.btnRestoreDocument.TabIndex = 80;
            this.btnRestoreDocument.Text = "gelöschter Datensatz wiederherstellen";
            this.btnRestoreDocument.UseVisualStyleBackColor = false;
            this.btnRestoreDocument.Click += new System.EventHandler(this.btnRestoreDocument_Click);
            // 
            // ctlCreatorModifier
            // 
            this.ctlCreatorModifier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlCreatorModifier.Location = new System.Drawing.Point(3, 14);
            this.ctlCreatorModifier.Name = "ctlCreatorModifier";
            this.ctlCreatorModifier.Size = new System.Drawing.Size(322, 38);
            this.ctlCreatorModifier.TabIndex = 81;
            // 
            // CtlLogischesLoeschen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRestoreDocument);
            this.Controls.Add(this.ctlCreatorModifier);
            this.Name = "CtlLogischesLoeschen";
            this.Size = new System.Drawing.Size(606, 58);
            this.ResumeLayout(false);

        }

        #endregion

        private Gui.KissButton btnRestoreDocument;
        private CtlCreationModification ctlCreatorModifier;
    }
}
