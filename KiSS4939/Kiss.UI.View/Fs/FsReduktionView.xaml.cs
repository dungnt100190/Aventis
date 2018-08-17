using Kiss.UI.ViewModel.Fs;

namespace Kiss.UI.View.Fs
{
    /// <summary>
    /// Interaction logic for FsReduktionView.xaml
    /// </summary>
    public partial class FsReduktionView
    {
        #region Constructors

        public FsReduktionView()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void InitViewAndViewModel()
        {
            ((FsReduktionVM)ViewModel).Init();
        }

        #endregion

        #endregion
    }
}