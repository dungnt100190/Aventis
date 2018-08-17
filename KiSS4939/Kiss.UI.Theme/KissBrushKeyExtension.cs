using DevExpress.Xpf.Utils.Themes;

namespace DevExpress.Xpf.Themes.Kiss
{
    #region Enumerations

    public enum KissBrushKeys
    {
        ButtonBorder,
        ButtonBackground,
        ButtonBackgroundMouseOver,
        ButtonBackgroundPressed,
        ButtonBackgroundToggled,
        CheckBoxBorderFocused,
        CheckBoxBorderHover,
        CheckBoxBackgroundHover,
        GoToFallBackground,
        GoToFallBorder,
        KissViewBackground,
        EditControlBackgroundNormal,
        EditControlBackgroundReadOnly,
        EditControlBackgroundRequired,
        EditControlBorder,
        EditControlBorderFocused,
        EditButtonBackgroundHover,
        EditButtonBackgroundPressed,
        EditButtonBorderHover,
        ListSelection,
        GridColumHeaderBackground,
        GridColumHeaderBackgroundPressed,
        GridRowIndicatorBackground,
        GridDataPresenterBackground,
        GroupBoxBorderBrush,
        GridGroupRowBackground,
    }

    #endregion

    public class KissBrushKeyExtension : ThemeKeyExtensionBase<KissBrushKeys>
    {
        #region Constructors

        public KissBrushKeyExtension()
        {
            IsThemeIndependent = true;
        }

        public KissBrushKeyExtension(KissBrushKeys resourceKey)
            : this()
        {
            ResourceKey = resourceKey;
        }

        #endregion
    }
}