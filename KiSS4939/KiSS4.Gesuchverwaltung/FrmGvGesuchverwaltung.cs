using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KiSS4.Common;

namespace KiSS4.Gesuchverwaltung
{
    class FrmGvGesuchverwaltung : KiSS4.Gui.KissChildForm
    {
        #region Fields

        private System.ComponentModel.IContainer components;
        private KiSS4.Gesuchverwaltung.CtlGvGesuchverwaltung ctlGvGesuchverwaltung;

        #endregion

        #region Constructors

        public FrmGvGesuchverwaltung()
        {
            this.InitializeComponent();
            
        }

        #endregion

        #region Windows Form Designer generated code

        public override bool ReceiveMessage(System.Collections.Specialized.HybridDictionary param)
        {
            return ctlGvGesuchverwaltung.ReceiveMessage(param);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ctlGvGesuchverwaltung = new KiSS4.Gesuchverwaltung.CtlGvGesuchverwaltung();
            this.SuspendLayout();

            this.ctlGvGesuchverwaltung.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlGvGesuchverwaltung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlGvGesuchverwaltung.Location = new System.Drawing.Point(0, 0);
            this.ctlGvGesuchverwaltung.Name = "ctlGvGesuchverwaltung";
            this.ctlGvGesuchverwaltung.Size = new System.Drawing.Size(842, 651);
            this.ctlGvGesuchverwaltung.TabIndex = 0;
            
            this.ClientSize = new System.Drawing.Size(811, 589);
            this.Controls.Add(this.ctlGvGesuchverwaltung);
            this.Name = "FrmGvGesuchverwaltung";
            this.Text = "Gesuchverwaltung";
            this.ResumeLayout(false);
        }

        #endregion

        #region Dispose

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if ((components != null))
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}
