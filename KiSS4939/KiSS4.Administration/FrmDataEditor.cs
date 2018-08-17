using System;
using System.Windows.Forms;

using KiSS4.Gui;

namespace KiSS4.Administration
{
    public partial class FrmDataEditor : KissChildForm
    {
        public FrmDataEditor()
        {
            InitializeComponent();

            var ctlDataEditor = new CtlDataEditor { Dock = DockStyle.Fill };
            Controls.Add(ctlDataEditor);
            ActiveControl = ctlDataEditor;
        }

        private void FrmDataEditor_VisibleChanged(object sender, EventArgs e)
        {
            // check if user has rights to see control
            if (!CtlDataEditor.HasUserAccessToForm())
            {
                Close();
            }
        }
    }
}
