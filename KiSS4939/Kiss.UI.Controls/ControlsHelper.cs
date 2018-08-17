using System;
using System.Runtime.InteropServices;
using System.Windows;

namespace Kiss.UI.Controls
{
    public class ControlsHelper
    {
        #region DllImport

        [DllImport("user32.dll")]
        internal static extern int GetWindowLong(IntPtr hwnd, int index);

        [DllImport("user32.dll")]
        internal static extern int SetWindowLong(IntPtr hwnd, int index, int value);

        #endregion

        #region Fields

        #region Private Constant/Read-Only Fields

        private const int GWL_STYLE = -16;

        #endregion

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Extension method which allows to hide the Window's Minimize and Maximize buttons.
        /// This method makes sure, the necessary code is invoked after the window is initialized,
        /// so you can simply invoke the method after the constructor.
        /// </summary>
        /// <param name="window"></param>
        public static void HideMinimizeAndMaximizeButtons(Window window)
        {
            window.SourceInitialized += (sender, eventArgs) =>
            {
                var hwnd = new System.Windows.Interop.WindowInteropHelper(window).Handle;
                long value = GetWindowLong(hwnd, GWL_STYLE);

                SetWindowLong(hwnd, GWL_STYLE, (int)(value & -131073 & -65537));
            };
        }

        #endregion

        #endregion
    }
}