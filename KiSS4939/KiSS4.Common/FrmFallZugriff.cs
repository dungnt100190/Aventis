using System.Windows.Forms;

using KiSS4.Gui;

namespace KiSS4.Common
{
    /// <summary>
    /// Form, used for managing access on cases (owner and guestrights)
    /// </summary>
    public class FrmFallZugriff : KissForm
    {
        private CtlFrmFallZugriff _ctlFallZugriff;

        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmFallZugriff"/> class.
        /// </summary>
        /// <param name="faLeistungID">The id within table FaLeistung.</param>
        public FrmFallZugriff(int faLeistungID)
        {
            InitializeComponent();

            AddCtlToControls(new CtlFrmFallZugriff(faLeistungID));
        }

        private void AddCtlToControls(CtlFrmFallZugriff newctlFallZugriff)
        {
            _ctlFallZugriff = newctlFallZugriff;
            _ctlFallZugriff.Dock = DockStyle.Fill;
            Controls.Add(_ctlFallZugriff);
            ActiveControl = _ctlFallZugriff;
        }

        private void FrmFallZugriff_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = _ctlFallZugriff.ControlClosing();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SuspendLayout();
            //
            // FrmFallZugriff
            //
            this.ClientSize = new System.Drawing.Size(757, 383);
            this.Name = "FrmFallZugriff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fallzugriff";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FrmFallZugriff_FormClosing);
            this.ResumeLayout(false);
        }

        #endregion

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
    }
}