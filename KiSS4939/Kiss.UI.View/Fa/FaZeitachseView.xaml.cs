using System;
using System.Windows;
using System.Windows.Threading;

using Kiss.UI.Controls;

namespace Kiss.UI.View.Fa
{
    /// <summary>
    /// Interaction logic for FaZeitachseView.xaml
    /// </summary>
    public partial class FaZeitachseView
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly DispatcherTimer _resizeTimer;

        #endregion

        #endregion

        #region Constructors

        public FaZeitachseView()
        {
            InitializeComponent();

            _resizeTimer = new DispatcherTimer();
            _resizeTimer.Interval = TimeSpan.FromMilliseconds(20);
            _resizeTimer.IsEnabled = false;
            _resizeTimer.Tick += ResizeTimer_Tick;
        }

        #endregion

        #region EventHandlers

        private void DateRangeSlider_PreviewSelectedRangeChanged(object sender, SelectedRangeChangedEventArgs e)
        {
            if (e.IsScrolling)
            {
                //TimelineControl.ScrollTo(DateRangeSlider.StartDate);
            }
            else
            {
                //Do nothing on Zoom
            }
        }

        private void DateRangeSlider_SelectedRangeChanged(object sender, SelectedRangeChangedEventArgs e)
        {
            if (e.IsScrolling)
            {
                SetScroll();
            }
            else
            {
                SetZoom();
            }
        }

        private void KissView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            _resizeTimer.Stop();
            _resizeTimer.Start();
        }

        private void ResizeTimer_Tick(object sender, EventArgs e)
        {
            _resizeTimer.Stop();
            SetZoom();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void RefreshData()
        {
            base.RefreshData();
            //TimelineControl.ScrollTo(DateRangeSlider.MinDate);
        }

        #endregion

        #region Private Methods

        private void SetScroll()
        {
            //TimelineControl.ScrollTo(DateRangeSlider.StartDate);
        }

        private void SetZoom()
        {
            //TimelineControl.SetZoom(DateRangeSlider.StartDate, DateRangeSlider.EndDate);
        }

        #endregion

        #endregion
    }
}