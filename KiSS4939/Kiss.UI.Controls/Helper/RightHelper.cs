using System.Windows;

namespace Kiss.UI.Controls.Helper
{
    /// <summary>
    /// Helper Class for Rights and Authorization
    /// </summary>
    public class RightHelper
    {
        #region Fields

        #region Public Static Fields

        /// <summary>
        /// Attached Property which inherits its value to all children of the node on which it is used.
        /// Bind this to the HasMaskRight in the ViewModel of the View.
        /// </summary>
        public static readonly DependencyProperty MaskRightProperty = 
            DependencyProperty.RegisterAttached("MaskRight", typeof(bool), typeof(RightHelper),
                                                new FrameworkPropertyMetadata(true,
                                                                              FrameworkPropertyMetadataOptions.Inherits));

        #endregion

        #endregion

        #region Methods

        #region Public Static Methods

        public static bool GetMaskRight(UIElement element)
        {
            return (bool)element.GetValue(MaskRightProperty);
        }

        public static void SetMaskRight(UIElement element, bool value)
        {
            element.SetValue(MaskRightProperty, value);
        }

        #endregion

        #endregion
    }
}