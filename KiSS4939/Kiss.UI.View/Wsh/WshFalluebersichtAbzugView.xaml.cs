using Kiss.Interfaces.ViewModel;
using Kiss.UI.ViewModel.Wsh;

namespace Kiss.UI.View.Wsh
{
    /// <summary>
    /// Interaction logic for WshFalluebersichtAbzugView
    /// </summary>
    public partial class WshFalluebersichtAbzugView
    {

        #region Constructors

        public WshFalluebersichtAbzugView()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        #region Public Methods

        
        public void InitViewAndViewModel(int faLeistungId)
        {
            ((WshFalluebersichtAbzugVM)ViewModel).Init(faLeistungId);
        }

        #endregion
        
        #region Protected Methods

        protected override IViewModelCRUD GetViewModel()
        {
            return FindResource("viewModel") as IViewModelCRUD;
        }

        #endregion

       

        #endregion

        private void btnGotoGrundbudget_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ((WshFalluebersichtAbzugVM)ViewModel).GoToGrundbudgetCommand.Execute(null);
            ViewHelper.CloseDialog(this, null);
        }

        private void btnSchliessen_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ViewHelper.CloseDialog(this, null);
        }
    }
}