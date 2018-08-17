using DevExpress.Xpf.Utils.Themes;

namespace Kiss.UI.Controls
{
    public enum ControlResourceKeys
    {
        InlineButtonStyle
    }

    public class ControlResourceKeyExtension : ThemeKeyExtensionBase<ControlResourceKeys>
    {
        public ControlResourceKeyExtension()
        {
            IsThemeIndependent = true;
        }

        public ControlResourceKeyExtension(ControlResourceKeys resourceKey)
            : this()
        {
            ResourceKey = resourceKey;
        }
    }
}