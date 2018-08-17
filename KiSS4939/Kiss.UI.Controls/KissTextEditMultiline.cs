using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Kiss.UI.Controls
{
    public class KissTextEditMultiline : KissTextEdit
    {
        static KissTextEditMultiline()
        {
            VerticalScrollBarVisibilityProperty.OverrideMetadata(typeof(KissTextEditMultiline), new FrameworkPropertyMetadata(ScrollBarVisibility.Auto));
            TextWrappingProperty.OverrideMetadata(typeof(KissTextEditMultiline), new FrameworkPropertyMetadata(TextWrapping.Wrap));
            AcceptsReturnProperty.OverrideMetadata(typeof(KissTextEditMultiline), new FrameworkPropertyMetadata(true));
        }
    }
}