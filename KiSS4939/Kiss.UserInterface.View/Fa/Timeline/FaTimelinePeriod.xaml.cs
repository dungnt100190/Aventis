using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Kiss.UserInterface.ViewModel.Fa;


namespace Kiss.UserInterface.View.Fa.Timeline
{
    /// <summary>
    /// Represents an event on a timeline axis (swimm lane).
    /// </summary>
    public partial class FaTimelinePeriod
    {
        #region Constructors

        /// <summary>
        /// Initialize the object
        /// </summary>
        public FaTimelinePeriod()
        {
            InitializeComponent();
        }



        public Thickness TextPadding
        {
            get { return (Thickness)GetValue(TextPaddingProperty); }
            set { SetValue(TextPaddingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextPadding.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextPaddingProperty =
            DependencyProperty.Register("TextPadding", typeof(Thickness), typeof(FaTimelinePeriod), new UIPropertyMetadata(new Thickness(), TextPaddingPropertyChanged));

        private static void TextPaddingPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var instance = (FaTimelinePeriod)dependencyObject;
            instance.OuterBorder.Padding = (Thickness)e.NewValue;
        }

        #endregion

        #region EventHandlers

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
        //    if (_timelinePeriod.HasJumpToPath && e.ClickCount > 1)
        //    {
        //        FaTimelineUtility.ExecuteJumpToPath(_timelinePeriod.JumpToPath);
        //    }
        }

        #endregion
    }
}