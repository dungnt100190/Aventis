using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KiSS4.Schnittstellen.Newod
{
    public partial class CtlKiSSNewodManuellerImport
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.edtStart = new KiSS4.Gui.KissButton();
            this.edtCurrentTask = new KiSS4.Gui.KissLabel();
            this.edtFeedback = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.edtCurrentTask)).BeginInit();
            this.SuspendLayout();
            // 
            // edtStart
            // 
            this.edtStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.edtStart.Location = new System.Drawing.Point(3, 3);
            this.edtStart.Name = "edtStart";
            this.edtStart.Size = new System.Drawing.Size(701, 24);
            this.edtStart.TabIndex = 0;
            this.edtStart.Text = "Alle Basisdaten von Newod-Personen importieren";
            this.edtStart.UseVisualStyleBackColor = false;
            this.edtStart.Click += new System.EventHandler(this.edtStart_Click);
            // 
            // edtCurrentTask
            // 
            this.edtCurrentTask.Location = new System.Drawing.Point(3, 30);
            this.edtCurrentTask.Name = "edtCurrentTask";
            this.edtCurrentTask.Size = new System.Drawing.Size(43, 24);
            this.edtCurrentTask.TabIndex = 5;
            this.edtCurrentTask.Text = "Log:";
            // 
            // edtFeedback
            // 
            this.edtFeedback.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFeedback.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtFeedback.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edtFeedback.Location = new System.Drawing.Point(46, 33);
            this.edtFeedback.Multiline = true;
            this.edtFeedback.Name = "edtFeedback";
            this.edtFeedback.ReadOnly = true;
            this.edtFeedback.Size = new System.Drawing.Size(658, 400);
            this.edtFeedback.TabIndex = 6;
            // 
            // CtlKiSSNewodManuellerImport
            // 
            this.Controls.Add(this.edtFeedback);
            this.Controls.Add(this.edtCurrentTask);
            this.Controls.Add(this.edtStart);
            this.Name = "CtlKiSSNewodManuellerImport";
            this.Size = new System.Drawing.Size(707, 436);
            ((System.ComponentModel.ISupportInitialize)(this.edtCurrentTask)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private KiSS4.Gui.KissLabel edtCurrentTask;
        private TextBox edtFeedback;
        private KiSS4.Gui.KissButton edtStart;
    }
}
