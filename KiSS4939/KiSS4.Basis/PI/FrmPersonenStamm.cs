using System;

namespace KiSS4.Basis.PI
{
    public class FrmPersonenStamm : KiSS4.Gui.KissChildForm
    {
        #region Fields

        private System.ComponentModel.IContainer components;
        private KiSS4.Basis.PI.CtlPersonenStamm ctlPersonenStamm;

        #endregion

        #region Constructors

        public FrmPersonenStamm()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ctlPersonenStamm = new KiSS4.Basis.PI.CtlPersonenStamm();
            this.SuspendLayout();
            //
            // ctlPersonenStamm
            //
            this.ctlPersonenStamm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlPersonenStamm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlPersonenStamm.Location = new System.Drawing.Point(0, 0);
            this.ctlPersonenStamm.Name = "ctlPersonenStamm";
            this.ctlPersonenStamm.Size = new System.Drawing.Size(842, 651);
            this.ctlPersonenStamm.TabIndex = 0;
            //
            // FrmPersonenStamm
            //
            this.ClientSize = new System.Drawing.Size(842, 651);
            this.Controls.Add(this.ctlPersonenStamm);
            this.Name = "FrmPersonenStamm";
            this.Text = "Personen-Stamm";
            this.Shown += new System.EventHandler(this.FrmPersonenStamm_Shown);
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

        #region Private Methods

        private void FrmPersonenStamm_Shown(object sender, EventArgs e)
        {
            // set focus
            ctlPersonenStamm.SetSearchFocus();
        }

        #endregion
    }
}