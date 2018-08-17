using Kiss.UI.ViewModel.Fs;

namespace Kiss.UI.View.Fs
{
    /// <summary>
    /// Interaction logic for FsDienstleistungspaketView.xaml
    /// </summary>
    public partial class FsDienstleistungspaketView
    {
        #region Constructors

        public FsDienstleistungspaketView()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Initialize the view model and the view
        /// </summary>
        public override void InitViewAndViewModel()
        {
            // init view model
            ((FsDienstleistungspaketVM)ViewModel).Init();
        }

        #endregion

        #endregion
    }
}