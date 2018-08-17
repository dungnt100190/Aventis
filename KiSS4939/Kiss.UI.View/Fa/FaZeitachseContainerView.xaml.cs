using Kiss.UI.ViewModel;
using Kiss.UI.ViewModel.Fa;

namespace Kiss.UI.View.Fa
{
    /// <summary>
    /// Interaction logic for FaZeitachseContainerView.xaml
    /// </summary>
    public partial class FaZeitachseContainerView
    {
        #region Constructors

        public FaZeitachseContainerView()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        protected new FaZeitachseContainerVM ViewModel
        {
            get { return GetViewModelSearchList() as FaZeitachseContainerVM; }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void InitViewAndViewModel(int baPersonID)
        {
            ViewModel.Init(baPersonID);
        }

        public override void RefreshData()
        {
            base.RefreshData();
            ViewModel.Search(null);
            ZeitachseView.RefreshData();
        }

        #endregion

        #region Protected Methods

        protected override ViewModelSearchListBase GetViewModelSearchList()
        {
            return FindResource("viewModel") as ViewModelSearchListBase;
        }

        #endregion

        #endregion
    }
}