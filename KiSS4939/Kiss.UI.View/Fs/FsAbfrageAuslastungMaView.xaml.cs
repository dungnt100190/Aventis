using Kiss.UI.ViewModel;

namespace Kiss.UI.View.Fs
{
    public partial class FsAbfrageAuslastungMaView
    {
        #region Constructors

        public FsAbfrageAuslastungMaView()
        {
            InitializeComponent();
            gridSearchContent.SizeChanged += new System.Windows.SizeChangedEventHandler(gridSearchContent_SizeChanged);
        }

        #endregion

        #region EventHandlers

        void gridSearchContent_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
        {
            // HACK: das müsste mit XAML möglich sein  (statt manuell)
            maximizedKeyFrame.Value = gridSearchContent.ActualHeight;
            if (toggleButton.IsChecked == true)
            {
                OnChecked1_BeginStoryboard.Storyboard.Begin();
            }
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