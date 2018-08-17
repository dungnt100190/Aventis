using System;
using System.Collections.Specialized;
using System.Windows.Forms;

using Kiss.Interfaces.UI;

using KiSS4.Gui;

namespace KiSS4.Klientenbuchhaltung
{
    public partial class FrmKbKlientenbuchhaltung : KissChildForm, IContainerForm
    {
        private readonly CtlKbKlientenbuchhaltung _ctlKbKlientenbuchhaltung;

        public FrmKbKlientenbuchhaltung()
        {
            InitializeComponent();

            _ctlKbKlientenbuchhaltung = new CtlKbKlientenbuchhaltung { Dock = DockStyle.Fill };
            _ctlKbKlientenbuchhaltung.TextChanged += CtlKbKlientenbuchhaltung_TextChanged;
            Controls.Add(_ctlKbKlientenbuchhaltung);
            ActiveControl = _ctlKbKlientenbuchhaltung;
        }

        private void CtlKbKlientenbuchhaltung_TextChanged(object sender, EventArgs e)
        {
            Text = _ctlKbKlientenbuchhaltung.Text;
        }

        public override bool ReceiveMessage(HybridDictionary parameters)
        {
            return _ctlKbKlientenbuchhaltung.ReceiveMessage(parameters);
        }

        public override object ReturnMessage(HybridDictionary parameters)
        {
            return _ctlKbKlientenbuchhaltung.ReturnMessage(parameters);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            _ctlKbKlientenbuchhaltung.OnParentFormShown();
        }
    }
}