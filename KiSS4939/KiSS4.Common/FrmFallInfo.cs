using System.Windows.Forms;

using KiSS4.Gui;

namespace KiSS4.Common
{
    /// <summary>
    /// Formular für fall Info.
    /// </summary>
    public partial class FrmFallInfo : KissForm
    {
        private CtlFallInfo _ctlFallInfo;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmFallInfo"/> class.
        /// </summary>
        /// <param name="baPersonId">The ba person ID.</param>
        /// <param name="dummy">Obsolet, es gibt aber noch dynamische Aufrufe mit diesem Parameter.</param>
        public FrmFallInfo(int baPersonId, bool dummy)
        {
            InitializeComponent();
            AddCtlFallInfoToControls(new CtlFallInfo(baPersonId, dummy));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmFallInfo"/> class.
        /// </summary>
        /// <param name="faLeistungId">The fa leistung ID.</param>
        public FrmFallInfo(int faLeistungId)
        {
            InitializeComponent();

            AddCtlFallInfoToControls(new CtlFallInfo(faLeistungId));
        }

        private void AddCtlFallInfoToControls(CtlFallInfo newctlFallInfo)
        {
            _ctlFallInfo = newctlFallInfo;
            _ctlFallInfo.Dock = DockStyle.Fill;

            Controls.Add(_ctlFallInfo);
            ActiveControl = _ctlFallInfo;
        }
    }
}