using System.Windows;
using DevExpress.Xpf.Core;

namespace DevExpress.Xpf.Themes.Kiss
{
    public static class KissTheme
    {
        #region Fields

        #region Private Static Fields

        private static readonly Theme _theme;

        #endregion

        #endregion

        #region Constructors

        static KissTheme()
        {
            var assembly = typeof(KissTheme).Assembly;
            _theme = new Theme("Kiss", assembly.FullName)
            {
                AssemblyName = assembly.FullName
            };
            Theme.RegisterTheme(_theme);
        }

        #endregion

        #region Properties

        public static Theme Theme
        {
            get { return _theme; }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Enables the KiSS-Theme for the specified dependency object.
        /// </summary>
        /// <param name="dependencyObject"></param>
        public static void Enable(DependencyObject dependencyObject)
        {
            ThemeManager.SetTheme(dependencyObject, _theme);
        }

        #endregion

        #endregion
    }
}