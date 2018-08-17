namespace KiSS4.Common
{
    /// <summary>
    /// Summary description for DlgBelegLeser.
    /// </summary>
    public class DlgBelegLeser : KiSS4.Gui.KissDialog
    {
        private KiSS4.Gui.KissButton btnAbbrechen;

        private KiSS4.Gui.KissButton btnNeueBuchung;

        private KiSS4.Gui.KissButton btnUeberschreiben;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        private System.Windows.Forms.Label lblFrage;
        private Status result = Status.Cancel;

        public DlgBelegLeser()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        public enum Status
        {
            Ueberschreiben,
            Neu,
            Cancel
        }

        public Status Result
        {
            get { return this.result; }
        }

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnUeberschreiben = new KiSS4.Gui.KissButton();
            this.btnNeueBuchung = new KiSS4.Gui.KissButton();
            this.btnAbbrechen = new KiSS4.Gui.KissButton();
            this.lblFrage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // btnUeberschreiben
            //
            this.btnUeberschreiben.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUeberschreiben.Location = new System.Drawing.Point(4, 56);
            this.btnUeberschreiben.Name = "btnUeberschreiben";
            this.btnUeberschreiben.Size = new System.Drawing.Size(104, 24);
            this.btnUeberschreiben.TabIndex = 0;
            this.btnUeberschreiben.Text = "Überschreiben";
            this.btnUeberschreiben.Click += new System.EventHandler(this.btnUeberschreiben_Click);
            //
            // btnNeueBuchung
            //
            this.btnNeueBuchung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNeueBuchung.Location = new System.Drawing.Point(116, 56);
            this.btnNeueBuchung.Name = "btnNeueBuchung";
            this.btnNeueBuchung.Size = new System.Drawing.Size(104, 24);
            this.btnNeueBuchung.TabIndex = 1;
            this.btnNeueBuchung.Text = "Neue Buchung";
            this.btnNeueBuchung.Click += new System.EventHandler(this.btnNeueBuchung_Click);
            //
            // btnAbbrechen
            //
            this.btnAbbrechen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbbrechen.Location = new System.Drawing.Point(232, 56);
            this.btnAbbrechen.Name = "btnAbbrechen";
            this.btnAbbrechen.Size = new System.Drawing.Size(104, 24);
            this.btnAbbrechen.TabIndex = 2;
            this.btnAbbrechen.Text = "Abbrechen";
            this.btnAbbrechen.Click += new System.EventHandler(this.btnAbbrechen_Click);
            //
            // lblFrage
            //
            this.lblFrage.Location = new System.Drawing.Point(4, 8);
            this.lblFrage.Name = "lblFrage";
            this.lblFrage.Size = new System.Drawing.Size(332, 36);
            this.lblFrage.TabIndex = 3;
            this.lblFrage.Text = "Wollen Sie den aktuellen Zahlungsweg überschreiben ?";
            //
            // DlgBelegLeser
            //
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(340, 88);
            this.Controls.Add(this.lblFrage);
            this.Controls.Add(this.btnAbbrechen);
            this.Controls.Add(this.btnNeueBuchung);
            this.Controls.Add(this.btnUeberschreiben);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DlgBelegLeser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frage";
            this.ResumeLayout(false);
        }

        #endregion

        private void btnAbbrechen_Click(object sender, System.EventArgs e)
        {
            this.result = Status.Cancel;
            this.Close();
        }

        private void btnNeueBuchung_Click(object sender, System.EventArgs e)
        {
            this.result = Status.Neu;
            this.Close();
        }

        private void btnUeberschreiben_Click(object sender, System.EventArgs e)
        {
            this.result = Status.Ueberschreiben;
            this.Close();
        }
    }
}