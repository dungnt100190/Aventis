using System.Windows;
using System.Windows.Media.Animation;
using DevExpress.Xpf.Themes.Kiss;
using Kiss.Interfaces.ViewModel;

namespace Kiss.UI.Controls
{
    /// <summary>
    /// Interaction logic for KissSearchControl.xaml
    /// </summary>
    public partial class KissSearchControl
    {
        #region Enumerations

        /// <summary>
        /// The possible search panel states
        /// </summary>
        public enum SearchPanelState
        {
            /// <summary>
            /// The search controls are hidden and the searching panel is minimized
            /// </summary>
            Collapsed,

            /// <summary>
            /// Teh search controls are shown and the searching panel is maximized
            /// </summary>
            Expanded
        }

        #endregion

        #region Fields

        #region Public Static Fields

        // Using a DependencyProperty as the backing store for MinimizeSearchPanelOnSearch.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinimizeSearchPanelOnSearchProperty =
            DependencyProperty.Register("MinimizeSearchPanelOnSearch", typeof(bool), typeof(KissSearchControl), new UIPropertyMetadata(true));
        public static readonly DependencyProperty SearchParamsDtoProperty =
            DependencyProperty.Register("SearchParamsDto", typeof(object), typeof(KissSearchControl), new UIPropertyMetadata(null));

        // Using a DependencyProperty as the backing store for SearchListVM.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(IViewModelSearch), typeof(KissSearchControl), new UIPropertyMetadata(null));

        #endregion

        #endregion

        #region Constructors

        public KissSearchControl()
        {
            InitializeComponent();
            KissTheme.Enable(this);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get the current search panel state
        /// </summary>
        public SearchPanelState CurrentSearchPanelState
        {
            get
            {
                if (toggleButton.IsChecked ?? false)
                {
                    return SearchPanelState.Expanded;
                }

                return SearchPanelState.Collapsed;
            }
        }

        public bool MinimizeSearchPanelOnSearch
        {
            get { return (bool)GetValue(MinimizeSearchPanelOnSearchProperty); }
            set { SetValue(MinimizeSearchPanelOnSearchProperty, value); }
        }

        public object ResultContent
        {
            get { return resultContent.Content; }
            set { resultContent.Content = value; }
        }

        public object SearchPanelContent
        {
            get { return searchContent.Content; }
            set { searchContent.Content = value; }
        }

        public object SearchParamsDto
        {
            get { return GetValue(SearchParamsDtoProperty); }
            set { SetValue(SearchParamsDtoProperty, value); }
        }

        public IViewModelSearch ViewModel
        {
            get { return (IViewModelSearch)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        #endregion

        #region EventHandlers

        private void gridSearchContent_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // HACK: das müsste mit XAML möglich sein  (statt manuell)
            var storyboard = Resources["OnChecked1"] as Storyboard;

            if (storyboard == null)
            {
                return;
            }

            var animation = storyboard.Children[0] as DoubleAnimationUsingKeyFrames;

            if (animation != null)
            {
                var maximizedKeyFrame = animation.KeyFrames[0];
                maximizedKeyFrame.Value = gridSearchContent.ActualHeight;
            }

            if (toggleButton.IsChecked == true)
            {
                storyboard.Begin();
            }
        }

        #endregion
    }
}