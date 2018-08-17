using Kiss.UI.ViewModel.Fa;

namespace Kiss.UI.View.Fa
{
    /// <summary>
    /// Interaction logic for FaKategorisierungView
    /// </summary>
    public partial class FaKategorisierungView
    {
        #region Constructors

        public FaKategorisierungView()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void InitViewAndViewModel(int baPersonID)
        {
            ((FaKategorisierungVM)ViewModel).Init(baPersonID);
        }

        #endregion

        #endregion
    }
}