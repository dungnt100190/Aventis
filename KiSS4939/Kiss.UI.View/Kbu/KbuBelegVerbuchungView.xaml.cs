using System.IO;
using Kiss.Interfaces.ViewModel;
using Kiss.UI.ViewModel.Kbu;

namespace Kiss.UI.View.Kbu
{
    /// <summary>
    /// Interaction logic for KbuBelegVerbuchung
    /// </summary>
    public partial class KbuBelegVerbuchungView
    {
        #region Constructors

        public KbuBelegVerbuchungView()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void InitViewAndViewModel()
        {
            ((KbuBelegVerbuchungVM)ViewModel).Init();
        }

        protected override IViewModelCRUD GetViewModel()
        {
            return FindResource("viewModel") as IViewModelCRUD;
        }

        #endregion

        #endregion
    }
}