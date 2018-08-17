using Kiss.Interfaces.ViewModel;
using Kiss.UI.ViewModel.Wsh;

namespace Kiss.UI.View.Wsh
{
    /// <summary>
    /// Interaction logic for WshLeistungView
    /// </summary>
    public partial class WshLeistungView
    {
        #region Constructors

        public WshLeistungView()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void InitViewAndViewModel()
        {
            
        }

        public void InitViewAndViewModel(int leistungId)
        {
            ((WshLeistungVM)ViewModel).Init(leistungId);
        }

        #endregion

        #region Protected Methods

        protected override IViewModelCRUD GetViewModel()
        {
            return FindResource("viewModel") as IViewModelCRUD;
        }

        #endregion

        #endregion
    }
}