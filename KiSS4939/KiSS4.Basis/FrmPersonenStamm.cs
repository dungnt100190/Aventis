using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using KiSS4.Gui;

namespace KiSS4.Basis
{
    public partial class FrmPersonenStamm : KissChildForm
    {
        private readonly CtlPersonenStamm _ctlPersonenStamm;

        public FrmPersonenStamm()
        {
            InitializeComponent();

            _ctlPersonenStamm = new CtlPersonenStamm { Dock = DockStyle.Fill };
            Controls.Add(_ctlPersonenStamm);
            ActiveControl = _ctlPersonenStamm;
        }

        public override bool ReceiveMessage(HybridDictionary parameters)
        {
            return _ctlPersonenStamm.ReceiveMessage(parameters);
        }

        public override object ReturnMessage(HybridDictionary parameters)
        {
            return _ctlPersonenStamm.ReturnMessage(parameters);
        }
    }
}