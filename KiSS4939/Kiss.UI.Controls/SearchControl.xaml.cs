using System.Windows;
using System.Windows.Media.Animation;
using DevExpress.Xpf.Themes.Kiss;

using Kiss.Infrastructure;
using Kiss.UI.Controls.Helper;

namespace Kiss.UI.Controls
{
    /// <summary>
    /// Interaction logic for SearchControl.xaml
    /// </summary>
    public partial class SearchControl
    {
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

        public static readonly DependencyProperty IsBusyPanelActiveProperty =
            DependencyProperty.Register(PropertyName.GetPropertyName<SearchControl>(x => x.IsBusyPanelActive), typeof(bool), typeof(SearchControl), new UIPropertyMetadata(true));

        public static readonly DependencyProperty MinimizeSearchPanelOnSearchProperty =
            DependencyProperty.Register(PropertyName.GetPropertyName<SearchControl>(x => x.MinimizeSearchPanelOnSearch), typeof(bool), typeof(SearchControl), new UIPropertyMetadata(true));

        public static readonly DependencyProperty SearchParamsDtoProperty =
            DependencyProperty.Register(PropertyName.GetPropertyName<SearchControl>(x => x.SearchParamsDto), typeof(object), typeof(SearchControl), new UIPropertyMetadata(null));

        public SearchControl()
        {
            InitializeComponent();
            KissTheme.Enable(this);
            ResourceUtil.CreateStaticResourcesForDesigner(this);
        }

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

        public bool IsBusyPanelActive
        {
            get { return (bool)GetValue(IsBusyPanelActiveProperty); }
            set { SetValue(IsBusyPanelActiveProperty, value); }
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
            set
            {
                searchContent.Content = value;
                KissTheme.Enable(searchContent.Content as DependencyObject);
            }
        }

        public object SearchParamsDto
        {
            get { return GetValue(SearchParamsDtoProperty); }
            set { SetValue(SearchParamsDtoProperty, value); }
        }

        private void BottomBarMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            toggleButton.IsChecked = !toggleButton.IsChecked;
        }

        private void gridSearchContent_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // HACK: das müsste mit XAML möglich sein  (statt manuell)
            var storyboard = Resources["MaximizeSearchPanel"] as Storyboard;

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
    }
}