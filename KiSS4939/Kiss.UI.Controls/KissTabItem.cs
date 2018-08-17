using System.Windows;
using System.Windows.Controls;

namespace Kiss.UI.Controls
{
    public class KissTabItem : TabItem
    {
        #region Constructors

        static KissTabItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(KissTabItem), new FrameworkPropertyMetadata(typeof(KissTabItem)));
        }

        #endregion
    }
}