using System.Collections.Specialized;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS4.Gui;

namespace KiSS4.BDE
{
    /// <summary>
    /// Form, used for managing working time for users and administration of given entries
    /// </summary>
    public partial class FrmBDEZeiterfassung : KissChildForm
    {
        public FrmBDEZeiterfassung()
        {
            InitializeComponent();

            var ctlBDEZeiterfassung = new CtlBDEZeiterfassung { Dock = DockStyle.Fill };
            Controls.Add(ctlBDEZeiterfassung);
            ActiveControl = ctlBDEZeiterfassung;
        }

        public override bool ReceiveMessage(HybridDictionary parameters)
        {
            var iViewMessaging = ActiveControl as IViewMessaging;
            if (iViewMessaging != null)
            {
                return iViewMessaging.ReceiveMessage(parameters);
            }

            return false;
        }
    }
}