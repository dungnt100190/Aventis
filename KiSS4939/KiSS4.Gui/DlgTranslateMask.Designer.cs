using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS4.Gui
{
    partial class DlgTranslateMask
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
            this.btnClose = new KiSS4.Gui.KissButton();
            this.btnAutoTranslate = new KiSS4.Gui.KissButton();
            this.ctlTranslateMask = new KiSS4.Gui.CtlTranslateMask();
            this.panBottom = new System.Windows.Forms.Panel();
            this.panBottom.SuspendLayout();
            this.SuspendLayout();
            //
            // btnClose
            //
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(673, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 24);
            this.btnClose.TabIndex = 95;
            this.btnClose.Text = "Schliessen";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // btnAutoTranslate
            //
            this.btnAutoTranslate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAutoTranslate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoTranslate.Location = new System.Drawing.Point(544, 9);
            this.btnAutoTranslate.Name = "btnAutoTranslate";
            this.btnAutoTranslate.Size = new System.Drawing.Size(112, 24);
            this.btnAutoTranslate.TabIndex = 92;
            this.btnAutoTranslate.Text = "Autoübersetzung";
            this.btnAutoTranslate.UseVisualStyleBackColor = false;
            this.btnAutoTranslate.Click += new System.EventHandler(this.btnAutoTranslate_Click);
            //
            // ctlTranslateMask
            //
            this.ctlTranslateMask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlTranslateMask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlTranslateMask.Location = new System.Drawing.Point(0, 0);
            this.ctlTranslateMask.Maskname = null;
            this.ctlTranslateMask.Name = "ctlTranslateMask";
            this.ctlTranslateMask.Size = new System.Drawing.Size(794, 247);
            this.ctlTranslateMask.TabIndex = 0;
            //
            // panBottom
            //
            this.panBottom.Controls.Add(this.btnAutoTranslate);
            this.panBottom.Controls.Add(this.btnClose);
            this.panBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panBottom.Location = new System.Drawing.Point(0, 247);
            this.panBottom.Name = "panBottom";
            this.panBottom.Size = new System.Drawing.Size(794, 41);
            this.panBottom.TabIndex = 96;
            //
            // DlgTranslateMask
            //
            this.ClientSize = new System.Drawing.Size(794, 288);
            this.Controls.Add(this.ctlTranslateMask);
            this.Controls.Add(this.panBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "DlgTranslateMask";
            this.Text = "Übersetzung";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DlgTranslateMask_FormClosed);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.DlgTranslateMask_Closing);
            this.panBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private KiSS4.Gui.KissButton btnAutoTranslate;
        private KiSS4.Gui.KissButton btnClose;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.CtlTranslateMask ctlTranslateMask;
        private System.Windows.Forms.Panel panBottom;
    }
}
