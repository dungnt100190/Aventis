using System.Drawing;

using KiSS4.Gui;

namespace KiSS4.Vormundschaft
{
    /// <summary>
    /// Summary description for CtlVmBewertung.
    /// </summary>
    public partial class CtlVmBewertung : KissUserControl
    {
        #region Constructors

        public CtlVmBewertung()
        {
            InitializeComponent();

            kissDataNavigator.PrefereDetailControl = true;
        }

        #endregion

        #region Properties

        public override KissUserControl DetailControl
        {
            get { return ctlVmKriterien; }
        }

        #endregion

        #region EventHandlers

        private void CtlVmBewertung_Load(object sender, System.EventArgs e)
        {
            ctlVmKriterien.SelectProperVmBewertungEntry();
            ActiveSQLQuery = ctlVmKriterien.ActiveSQLQuery;
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Init(string titleName, Image titleImage, int faLeistungID)
        {
            lblTitel.Text = titleName;
            picTitel.Image = titleImage;
            ctlVmKriterien.FaLeistungId = faLeistungID;
        }

        #endregion

        #endregion
    }
}