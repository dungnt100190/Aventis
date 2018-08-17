
namespace KiSS4.Klientenbuchhaltung
{
    public class FrmKbAuswKlientenkonto : KiSS4.Gui.KissChildForm
    {
        #region Fields

        private System.ComponentModel.IContainer components;
        private KiSS4.Klientenbuchhaltung.CtlQueryKbKlientenkonto ctlQueryKbKlientenkonto1;

        #endregion

        #region Constructors

        public FrmKbAuswKlientenkonto()
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
            this.ctlQueryKbKlientenkonto1 = new KiSS4.Klientenbuchhaltung.CtlQueryKbKlientenkonto();
            this.SuspendLayout();
            // 
            // ctlQueryKbKlientenkonto1
            // 
            this.ctlQueryKbKlientenkonto1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlQueryKbKlientenkonto1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlQueryKbKlientenkonto1.Location = new System.Drawing.Point(0, 0);
            this.ctlQueryKbKlientenkonto1.Name = "ctlQueryKbKlientenkonto1";
            this.ctlQueryKbKlientenkonto1.Size = new System.Drawing.Size(811, 589);
            this.ctlQueryKbKlientenkonto1.TabIndex = 0;
            // 
            // FrmKbAuswKlientenkonto
            // 
            this.ClientSize = new System.Drawing.Size(811, 589);
            this.Controls.Add(this.ctlQueryKbKlientenkonto1);
            this.Name = "FrmKbAuswKlientenkonto";
            this.Text = "Kontenabfrage aus KiSS";
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