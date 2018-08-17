using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Kiss.Interfaces.UI;

using KiSS4.Gui;

namespace KiSS4.Common.PI
{
    public partial class FrmMitarbeiterverwaltung : KissChildForm, IContainerForm
    {
        #region Public Constant/Read-Only Fields

        /// Get the name of the form "Mitarbeiterverwaltung BW/ED" used for FormController
        /// </summary>
        public const string FormControllerTarget_Mitarbeiterverwaltung = "FrmMitarbeiterverwaltung";

        #endregion

        private CtlMitarbeiterverwaltung _ctlMitarbeiterverwaltung;

        public FrmMitarbeiterverwaltung()
        {
            InitializeComponent();

            _ctlMitarbeiterverwaltung = new CtlMitarbeiterverwaltung { Dock = DockStyle.Fill };
            Controls.Add(_ctlMitarbeiterverwaltung);
            ActiveControl = _ctlMitarbeiterverwaltung;
        }

        public override bool ReceiveMessage(System.Collections.Specialized.HybridDictionary param)
        {
            return _ctlMitarbeiterverwaltung.ReceiveMessage(param);
        }
    }
}