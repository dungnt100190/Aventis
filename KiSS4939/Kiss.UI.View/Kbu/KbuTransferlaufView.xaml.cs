using DevExpress.Xpf.Grid;

using Kiss.Interfaces.ViewModel;
using Kiss.UI.ViewModel.Kbu;

namespace Kiss.UI.View.Kbu
{
    /// <summary>
    /// Interaction logic for KbuTransferlaufView
    /// </summary>
    public partial class KbuTransferlaufView
    {
        #region Constructors

        public KbuTransferlaufView()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void InitViewAndViewModel()
        {
            var viewModel = (KbuTransferlaufVM)FindResource("viewModel");
            viewModel.Init();
        }

        #endregion
    

        #endregion
    }
}