using System;
using System.Diagnostics;
using System.Text;

namespace KiSS4.Dokument.Utilities
{
    /// <summary>
    /// Provides utility functions to handle Windows.
    /// </summary>
    public static class WindowUtilities
    {
        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog logger =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Sets the window to foreground.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// TODO: Check if this works in Citrix Environments (e.g. Worb)
        public static void SetWindowToForeground(string filename)
        {
            try
            {
                IntPtr mainWindowHandle = IntPtr.Zero;

                foreach (Process process in Process.GetProcesses())
                {
                    mainWindowHandle = process.MainWindowHandle;
                    if (mainWindowHandle != IntPtr.Zero)
                    {
                        StringBuilder sb = new StringBuilder(256);
                        NativeMethods.GetWindowText(mainWindowHandle, sb, sb.Length);
                        String title = sb.ToString();

                        if (title.Length > 0)
                        {
                            if (title.IndexOf(filename) >= 0)
                            {
                                NativeMethods.BringWindowToTop(mainWindowHandle.ToInt32());
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Problemfall Worb unter Citrix Umgebung
                logger.Warn(ex.Message);
            }
        }
    }
}