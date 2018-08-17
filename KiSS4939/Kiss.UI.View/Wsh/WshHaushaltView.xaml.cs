using Kiss.Interfaces.ViewModel;
using Kiss.UI.ViewModel.Wsh;

namespace Kiss.UI.View.Wsh
{
    /// <summary>
    /// Interaction logic for WshHaushaltView
    /// </summary>
    public partial class WshHaushaltView
    {
        #region Constructors

        public WshHaushaltView()
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
            ((WshHaushaltVM)ViewModel).Init(leistungId);
        }

        public override bool AddData()
        {
            var result = base.AddData();

            //TODO: Workaround für Focus, bis wir eine generelle Lösung haben
            cboPerson.Focus();

            return result;
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