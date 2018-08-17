using Kiss.UI.ViewModel;

namespace Kiss.UI.View.Fs
{
    /// <summary>
    /// Interaction logic for FsAbfrageAuslastungGesamtView
    /// </summary>
    public partial class FsAbfrageAuslastungGesamtView
    {
        #region Constructors

        public FsAbfrageAuslastungGesamtView()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void InitViewAndViewModel()
        {
        }

        #endregion

        #region Protected Methods

        protected override ViewModelSearchListBase GetViewModelSearchList()
        {
            return TryFindResource("viewModel") as ViewModelSearchListBase;
        }

        #endregion

        #endregion
    }
}