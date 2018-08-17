using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms.Integration;
using System.Windows.Interop;

using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.UI;
using Kiss.UI.Controls;
using Kiss.UI.Controls.Helper;

namespace Kiss.UI.View
{
    public class ViewHelper : ControlsHelper
    {
        #region DllImport

        [DllImport("user32.dll")]
        private static extern uint GetDoubleClickTime();

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Schliesst den Dialog. Diese Funktion wird oft
        /// vom ViewModel vom Dialog selber aufgerufen.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="dialogResult">Bestimmt den Rückgabewert von ViewHelper.OpenModalWpfDialog</param>
        public static void CloseDialog(FrameworkElement element, bool? dialogResult)
        {
            while (true)
            {
                if (element is Window)
                {
                    var window = (Window)element;
                    window.DialogResult = dialogResult;
                    window.Close();
                    return;
                }

                element = (FrameworkElement)element.Parent;
            }
        }

        /// <summary>
        /// Look for the most inner control which is visible and which implements IKissDataNavigator
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static IKissDataNavigator FindWPFChildNavigator(Control parent)
        {
            foreach (var obj in LogicalTreeHelper.GetChildren(parent))
            {
                var control = obj as Control;

                if (control == null)
                {
                    continue;
                }

                if (!control.IsVisible)
                {
                    continue; // We don't care about invisible controls
                }

                // First check the leafs: Recursive Call
                var navigator = FindWPFChildNavigator(control);

                if (navigator != null)
                {
                    return navigator; // Return the found Navigator
                }

                // Then try the control itself
                navigator = control as IKissDataNavigator;

                if (navigator != null)
                {
                    // We found a visible Navigator
                    return navigator;
                }
            }

            return null;
        }

        /// <summary>
        /// Look for the most inner control which is visible and which implements IKissDataNavigator
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static IKissDataNavigator FindWinFormChildNavigator(System.Windows.Forms.Control parent)
        {
            foreach (System.Windows.Forms.Control control in parent.Controls)
            {
                if (!control.Visible)
                {
                    continue; // We don't care about invisible controls
                }

                // First check the leafs: Recursive Call
                var navigator = FindWinFormChildNavigator(control);

                if (navigator != null)
                {
                    return navigator; // Return the found Navigator
                }

                // Check if we have an embedded WPF-View
                var elementHost = control as ElementHost;

                if (elementHost != null && elementHost.Child is Control)
                {
                    // WPF-ElementHost found
                    navigator = elementHost.Child as IKissDataNavigator;

                    if (navigator != null)
                    {
                        // The Child-Class itself is a Navigator
                        return navigator;
                    }

                    // => Iterate recursively through all wpf controls on the ElementHost-Child
                    navigator = FindWPFChildNavigator(elementHost.Child as Control);

                    if (navigator != null)
                    {
                        return navigator; // Return the found Navigator
                    }
                }

                navigator = control as IKissDataNavigator;

                if (navigator != null)
                {
                    // We found a visible Navigator
                    return navigator;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets a KeyValuePair containing the name of the bound property as Key and the corresponding DependencyProperty as value.
        /// </summary>
        /// <param name="target">The target element.</param>
        public static KeyValuePair<string, DependencyProperty> GetBindingOfTarget(FrameworkElement target)
        {
            var localValueEnumerator = target.GetLocalValueEnumerator();

            while (localValueEnumerator.MoveNext())
            {
                var current = localValueEnumerator.Current;
                var binding = BindingOperations.GetBinding(target, current.Property);

                if (binding != null &&
                    binding.Path != null &&
                    !string.IsNullOrEmpty(binding.Path.Path))
                {
                    var path = binding.Path.Path;

                    if (path.Contains("."))
                    {
                        var i = path.LastIndexOf(".");
                        path = path.Substring(i + 1, path.Length - i - 1);
                    }

                    return new KeyValuePair<string, DependencyProperty>(path, current.Property);
                }
            }

            return new KeyValuePair<string, DependencyProperty>(null, null);
        }

        /// <summary>
        /// Gets a dictionary of unique bindings of all supplied controls.
        /// </summary>
        /// <remarks>
        /// If a duplicate binding exists, the corresponding dictionary entry is null.
        /// </remarks>
        /// <param name="childControls">A list of controls to get the bindings from.</param>
        public static Dictionary<string, DependencyProperty> GetBindingsOfControls(List<Control> childControls)
        {
            var bindingsOfControls = new Dictionary<string, DependencyProperty>();

            foreach (var bindingOfTarget in childControls
                     .Select(GetBindingOfTarget)
                     .Where(bindingOfTarget => !string.IsNullOrEmpty(bindingOfTarget.Key)))
            {
                if (bindingsOfControls.ContainsKey(bindingOfTarget.Key))
                {
                    bindingsOfControls[bindingOfTarget.Key] = null;
                }
                else
                {
                    bindingsOfControls.Add(bindingOfTarget.Key, bindingOfTarget.Value);
                }
            }

            return bindingsOfControls;
        }

        /// <summary>
        /// Gets all controls including controls of child-controls (recursive).
        /// </summary>
        /// <param name="parentControl">The control to get child-controls from.</param>
        /// <returns>All controls found within the ParentControl</returns>
        public static List<Control> GetChildControls(DependencyObject parentControl)
        {
            var controls = new List<Control>();

            foreach (var ctl in LogicalTreeHelper.GetChildren(parentControl))
            {
                if (ctl is Control)
                {
                    controls.Add(ctl as Control);
                }

                if (!(ctl is KissView) && ctl is DependencyObject)
                {
                    controls.AddRange(GetChildControls(ctl as DependencyObject));
                }
            }

            return controls;
        }

        /// <summary>
        /// Gets the time interval for a double click as configured in the system.
        /// </summary>
        /// <returns></returns>
        public static TimeSpan GetDoubleClickTimeSpan()
        {
            var millis = GetDoubleClickTime();
            return TimeSpan.FromMilliseconds(millis);
        }

        /// <summary>
        /// Opens a modal window with the caller as its parent. Since it would be confusing for the user if he minimized
        /// the modal dialog by hazard, the Maximize and Minimize buttons are hidden. However, the dialog is still resizable.
        /// </summary>
        /// <param name="content">The control to set as the window's content.</param>
        /// <param name="title">The title to set on the dialog</param>
        /// <param name="wpfParent">A WPF window to use as parent.</param>
        /// <param name="wfParent">A WinForms window to use as parent.</param>
        /// <param name="windowSize">optional: the size of the window</param>
        /// <returns>A value that signifies how a window was closed by the user.</returns>
        public static bool? OpenModalWpfDialog(
            FrameworkElement content,
            string title,
            Window wpfParent = null,
            System.Windows.Forms.IWin32Window wfParent = null,
            Size? windowSize = null)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content", "The content of the window cannot be null.");
            }

            // create the window
            var window = new KissDialog
            {
                Title = title,
                Content = content,
                Owner = wpfParent,
                WindowStartupLocation = wpfParent == null ? WindowStartupLocation.CenterScreen : WindowStartupLocation.CenterOwner,
            };

            HideMinimizeAndMaximizeButtons(window);

            ResourceUtil.CreateStaticResources(window);

            // wpf/winform interop (for setting the owner)
            if (window.Owner == null)
            {
                var helper = new WindowInteropHelper(window);

                if (wfParent != null)
                {
                    helper.Owner = wfParent.Handle;
                }
                else
                {
                    // try to get the main KiSS window
                    var main = Container.Resolve<System.Windows.Forms.IWin32Window>() as System.Windows.Forms.Form;

                    if (main != null)
                    {
                        helper.Owner = main.Handle;
                    }
                }
            }

            if (windowSize.HasValue)
            {
                window.Height = windowSize.Value.Height;
                window.Width = windowSize.Value.Width;
            }
            else
            {
                window.MinHeight = content.MinHeight + 40;
                window.MinWidth = content.MinWidth + 20;
                window.Height = content.Height + 40;
                window.Width = content.Width + 20;
            }

            return window.ShowDialog();
        }

        #endregion

        #endregion
    }
}