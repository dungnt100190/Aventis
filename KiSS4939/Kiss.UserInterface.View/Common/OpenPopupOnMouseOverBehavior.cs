using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Interactivity;

using Kiss.UI.Controls.Helper;

namespace Kiss.UserInterface.View.Common
{
    public class OpenPopupOnMouseOverBehavior : Behavior<Popup>
    {
        // Using a DependencyProperty as the backing store for PopupParent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PopupParentProperty =
            DependencyProperty.Register("PopupParent", typeof(UIElement), typeof(OpenPopupOnMouseOverBehavior), new UIPropertyMetadata(null));

        // Using a DependencyProperty as the backing store for PopupRootHorizontalOffset.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PopupRootHorizontalOffsetProperty =
            DependencyProperty.Register("PopupRootHorizontalOffset", typeof(double), typeof(OpenPopupOnMouseOverBehavior));

        private delegate void VoidDelegate();

        public FrameworkElement PopupParent
        {
            get { return (FrameworkElement)GetValue(PopupParentProperty); }
            set { SetValue(PopupParentProperty, value); }
        }

        public double PopupRootHorizontalOffset
        {
            get { return (double)GetValue(PopupRootHorizontalOffsetProperty); }
            set { SetValue(PopupRootHorizontalOffsetProperty, value); }
        }

        protected override void OnAttached()
        {
            AssociatedObject.MouseLeave += popup_MouseLeave;
            AssociatedObject.Opened += popup_Opened;

            var popupChild = AssociatedObject.Child as FrameworkElement;
            if (popupChild != null)
            {
                popupChild.SizeChanged += popupChild_SizeChanged;
            }

            PopupParent.MouseLeave += PopupParent_MouseLeave;
            PopupParent.MouseEnter += PopupParent_MouseEnter;
        }

        private void CloseBalloonDelayed()
        {
            VoidDelegate del = CloseBalloonIfMouseGone;
            // ToDo: async/await mit VS2012, Dispatcher & Delegate vermeiden
            Task.Delay(300).ContinueWith(task => Dispatcher.Invoke(del));
        }

        private void CloseBalloonIfMouseGone()
        {
            if (!AssociatedObject.IsMouseOver && !PopupParent.IsMouseOver)
            {
                AssociatedObject.IsOpen = false;
            }
        }

        private void popup_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            CloseBalloonDelayed();
        }

        private void popup_Opened(object sender, EventArgs e)
        {
            var popupChild = AssociatedObject.Child as FrameworkElement;
            if (popupChild != null)
            {
                AssociatedObject.HorizontalOffset = (-popupChild.ActualWidth + PopupParent.ActualWidth) * 0.5;
            }

            var gridPoint = PopupParent.PointToScreen(new Point(0, 0));
            var rectBalloonChild = PopupHelper.GetWindowRect(AssociatedObject.Child);

            var middleBalloon = rectBalloonChild.X + rectBalloonChild.Width * 0.5;
            var middleGrid = gridPoint.X + PopupParent.ActualWidth * 0.5;

            PopupRootHorizontalOffset = middleGrid - middleBalloon;
        }

        private void popupChild_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var content = (FrameworkElement)sender;
            AssociatedObject.HorizontalOffset = (-content.ActualWidth + PopupParent.ActualWidth) * 0.5;
        }

        private void PopupParent_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            AssociatedObject.IsOpen = true;
        }

        private void PopupParent_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            CloseBalloonDelayed();
        }
    }
}