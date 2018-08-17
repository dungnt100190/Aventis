using System.Windows;
using System.Windows.Controls;

namespace Kiss.UI.Controls
{
    public class KissLabel : Label
    {
        #region Constructors

        static KissLabel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(KissLabel), new FrameworkPropertyMetadata(typeof(KissLabel)));
        }

        #endregion
    }
}