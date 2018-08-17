using System.Windows.Forms;
using KiSS4.Common;
using KiSS4.Gui;

namespace KiSS4.Sozialhilfe
{
    public partial class FrmWhAuszahlungen : KissChildForm
    {
        public FrmWhAuszahlungen()
        {
            InitializeComponent();

            // register BelegLeser
            new Belegleser(this);

            var ctl = new CtlWhAuszahlungen { Dock = DockStyle.Fill };
            Controls.Add(ctl);
            ActiveControl = ctl;
        }
    }
}