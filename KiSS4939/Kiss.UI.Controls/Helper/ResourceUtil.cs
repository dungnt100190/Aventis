using System;
using System.ComponentModel;
using System.Windows;

namespace Kiss.UI.Controls.Helper
{
    public static class ResourceUtil
    {
        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Adds all global static resources to the specified element's local resources.
        /// </summary>
        /// <param name="ctl">The element to add the resources to.</param>
        public static void CreateStaticResources(FrameworkElement ctl)
        {
            ctl.Resources.MergedDictionaries.Add(
                (ResourceDictionary)Application.LoadComponent(new Uri("/DevExpress.Xpf.Themes.Kiss.v14.1;component/Themes/Constants.xaml", UriKind.Relative)));

            ctl.Resources.MergedDictionaries.Add(
                (ResourceDictionary)Application.LoadComponent(new Uri("/Kiss.UI.Controls;component/GlobalResources.xaml", UriKind.Relative)));

            ctl.Resources.MergedDictionaries.Add(
                (ResourceDictionary)Application.LoadComponent(new Uri("/Kiss.UI.Controls;component/Themes/Generic.xaml", UriKind.Relative)));
        }

        /// <summary>
        /// Adds all global static resources to the specified element's local resources (only when in design mode).
        /// </summary>
        /// <param name="ctl">The element to add the resources to.</param>
        public static void CreateStaticResourcesForDesigner(FrameworkElement ctl)
        {
            if (!DesignerProperties.GetIsInDesignMode(ctl))
            {
                return;
            }

            CreateStaticResources(ctl);
        }

        #endregion

        #endregion
    }
}