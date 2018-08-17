using Kiss.UI.ViewModel.Fs;

namespace Kiss.UI.View.Fs
{
    /// <summary>
    /// Interaction logic for FaDienstleistungView.xaml
    /// </summary>
    public partial class FsDienstleistungView
    {
        #region Constructors

        public FsDienstleistungView()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void InitViewAndViewModel()
        {
            ((FsDienstleistungVM)ViewModel).Init(GetType().FullName);
        }

        #endregion

        #endregion
    }
}