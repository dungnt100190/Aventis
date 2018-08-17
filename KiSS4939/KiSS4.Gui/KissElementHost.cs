using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace KiSS4.Gui
{
    public class KissElementHost : ElementHost
    {
        #region DllImport

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        #endregion

        #region Methods

        #region Protected Methods

        protected override bool ProcessCmdKey(ref Message m, Keys keyData)
        {
            // ElementHost schickt alle Messages ans WPF-Control weiter,
            // wenn dieses also den Fokus hat, erhalten die WinForms-Parent-Controls die Messages nicht mehr
            // mittels SendMessage werden sie deswegen hier nach oben weitergeleitet
            bool processed = base.ProcessCmdKey(ref m, keyData);

            if (!processed)
            {
                SendMessage(Parent.Handle, m.Msg, m.WParam, m.LParam);
            }

            return processed;
        }

        #endregion

        #endregion
    }
}