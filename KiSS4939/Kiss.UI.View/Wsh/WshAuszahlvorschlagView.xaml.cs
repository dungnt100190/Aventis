using Kiss.Interfaces.ViewModel;
using Kiss.UI.ViewModel.Wsh;

namespace Kiss.UI.View.Wsh
{
    /// <summary>
    /// Interaction logic for WshAuszahlvorschlagView
    /// </summary>
    public partial class WshAuszahlvorschlagView
    {
        #region Constructors

        public WshAuszahlvorschlagView()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        #region Public Methods

        private WshAuszahlvorschlagVM _viewModel;
        /// <summary>
        /// Gets the ViewModel
        /// </summary>
        public WshAuszahlvorschlagVM ViewModel
        {
            get
            {
                return _viewModel ?? (_viewModel = FindResource("viewModel") as WshAuszahlvorschlagVM);
            }
        }

        public void InitViewAndViewModel(int faLeistungID)
        {
            ViewModel.Init(faLeistungID);
            wshAuszahlvorschlagControl1.Init();
        }

        #endregion

        #region Protected Methods

        #endregion

        #endregion
    }
}