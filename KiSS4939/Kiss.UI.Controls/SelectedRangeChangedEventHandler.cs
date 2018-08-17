using System.Windows;

namespace Kiss.UI.Controls
{
    #region Delegates

    /// <summary>
    /// Delegate for the RangeSelectionChanged event
    /// </summary>
    /// <param name="sender">The object raising the event</param>
    /// <param name="e">The event arguments</param>
    public delegate void SelectedRangeChangedEventHandler(object sender, SelectedRangeChangedEventArgs e);

    #endregion

    /// <summary>
    /// Event arguments for the Range slider RangeSelectionChanged event
    /// </summary>
    public class SelectedRangeChangedEventArgs : RoutedEventArgs
    {
        #region Constructors

        /// <summary>
        /// sets the range start and range stop for the event args
        /// </summary>
        /// <param name="newRangeStart">The new range start set</param>
        /// <param name="newRangeStop">The new range stop set</param>
        /// <param name="isScrolling">Flag whether the user has zoomed or just scrolled</param>
        internal SelectedRangeChangedEventArgs(long newRangeStart, long newRangeStop, bool isScrolling)
        {
            NewRangeStart = newRangeStart;
            NewRangeStop = newRangeStop;
            IsScrolling = isScrolling;
        }

        /// <summary>
        /// sets the range start and range stop for the event args by using the slider RangeStartSelected and RangeStopSelected properties
        /// </summary>
        /// <param name="slider">The slider to get the info from</param>
        /// <param name="isScrolling">Flag whether the user has zoomed or just scrolled</param>
        internal SelectedRangeChangedEventArgs(KissRangeSlider slider, bool isScrolling)
            : this(slider.SelectedRange.From, slider.SelectedRange.To, isScrolling)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// The new range start selected in the range slider
        /// </summary>
        public long NewRangeStart
        {
            get;
            set;
        }

        /// <summary>
        /// The new range stop selected in the range slider
        /// </summary>
        public long NewRangeStop
        {
            get;
            set;
        }

        /// <summary>
        /// The difference between Start/Stop stays the same, hence the user has just scrolled.
        /// </summary>
        public bool IsScrolling
        {
            get; 
            set;
        }

        #endregion
    }
}