using System.Windows.Forms;

using KiSS4.Gui;

namespace KiSS4.Pendenzen
{
    /// <summary>
    /// Form, used for Pendenzenverwaltung
    /// </summary>
    public partial class FrmPendenzenVerwaltung : KissChildForm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmPendenzenVerwaltung"/> class.
        /// </summary>
        public FrmPendenzenVerwaltung()
        {
            InitializeComponent();

            var ctlPendenzenVerwaltung = new CtlFrmPendenzenVerwaltung { Dock = DockStyle.Fill };
            Controls.Add(ctlPendenzenVerwaltung);
            ActiveControl = ctlPendenzenVerwaltung;
        }
    }
}