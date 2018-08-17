using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS4.Gui
{
    partial class KissMemoEditML
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(KissMemoEditML));
            this.edtMemoEdit = new KiSS4.Gui.KissMemoEdit();
            this.cmdOpenDialog = new KiSS4.Gui.KissButton();
            this.chkWriteLock = new KiSS4.Gui.KissCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMemoEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkWriteLock.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // edtMemoEdit
            //
            this.edtMemoEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.edtMemoEdit.Location = new System.Drawing.Point(0, 0);
            this.edtMemoEdit.Name = "edtMemoEdit";
            //
            // edtMemoEdit.Properties
            //
            this.edtMemoEdit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMemoEdit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMemoEdit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMemoEdit.Properties.Appearance.Options.UseBackColor = true;
            this.edtMemoEdit.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMemoEdit.Properties.Appearance.Options.UseFont = true;
            this.edtMemoEdit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMemoEdit.Size = new System.Drawing.Size(336, 112);
            this.edtMemoEdit.TabIndex = 0;
            this.edtMemoEdit.EditValueChanged += new System.EventHandler(this.edtMemoEdit_EditValueChanged);
            //
            // cmdOpenDialog
            //
            this.cmdOpenDialog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOpenDialog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOpenDialog.Image = ((System.Drawing.Image)(resources.GetObject("cmdOpenDialog.Image")));
            this.cmdOpenDialog.Location = new System.Drawing.Point(336, 0);
            this.cmdOpenDialog.Name = "cmdOpenDialog";
            this.cmdOpenDialog.Size = new System.Drawing.Size(24, 24);
            this.cmdOpenDialog.TabIndex = 1;
            this.cmdOpenDialog.Click += new System.EventHandler(this.cmdOpenDialog_Click);
            //
            // chkWriteLock
            //
            this.chkWriteLock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.chkWriteLock.EditValue = false;
            this.chkWriteLock.Location = new System.Drawing.Point(-2, 114);
            this.chkWriteLock.Name = "chkWriteLock";
            //
            // chkWriteLock.Properties
            //
            this.chkWriteLock.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkWriteLock.Properties.Appearance.Options.UseBackColor = true;
            this.chkWriteLock.Properties.Caption = "Schreibschutz";
            this.chkWriteLock.Size = new System.Drawing.Size(336, 19);
            this.chkWriteLock.TabIndex = 2;
            this.chkWriteLock.CheckedChanged += new System.EventHandler(this.chkWriteLock_CheckedChanged);
            //
            // KissMemoEditML
            //
            this.Controls.Add(this.chkWriteLock);
            this.Controls.Add(this.cmdOpenDialog);
            this.Controls.Add(this.edtMemoEdit);
            this.Name = "KissMemoEditML";
            this.Size = new System.Drawing.Size(360, 136);
            ((System.ComponentModel.ISupportInitialize)(this.edtMemoEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkWriteLock.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private KiSS4.Gui.KissMemoEdit edtMemoEdit;
        private KiSS4.Gui.KissCheckEdit chkWriteLock;
        private KiSS4.Gui.KissButton cmdOpenDialog;
    }
}
