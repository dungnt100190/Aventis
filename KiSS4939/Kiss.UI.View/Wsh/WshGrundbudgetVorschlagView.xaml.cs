using Kiss.Interfaces.ViewModel;
using Kiss.UI.ViewModel.Wsh;

namespace Kiss.UI.View.Wsh
{
    /// <summary>
    /// Interaction logic for WshGrundbudgetVorschlagView
    /// </summary>
    public partial class WshGrundbudgetVorschlagView
    {
        #region Constructors

        public WshGrundbudgetVorschlagView()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        #region Public Methods

        private WshGrundbudgetVorschlagVM _viewModel;
        /// <summary>
        /// Gets the ViewModel
        /// </summary>
        public WshGrundbudgetVorschlagVM ViewModel
        {
            get
            {
                return _viewModel ?? (_viewModel = FindResource("viewModel") as WshGrundbudgetVorschlagVM);
            }
        }

        public void InitViewAndViewModel(int faLeistungID)
        {
            ViewModel.Init(faLeistungID);
            wshGrundbudgetVorschlagControl1.Init();
        }


        #endregion

        #region Protected Methods

        /*
        protected override IViewModelCRUD GetViewModel()
        {
            return FindResource("viewModel") as IViewModelCRUD;
        }
        */

        #endregion

        #endregion
    }
}