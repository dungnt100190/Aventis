using System;
using System.Windows.Forms;

using Microsoft.VisualBasic.ApplicationServices;

namespace KiSS4.Main
{
    internal class SingleInstanceApplication : WindowsFormsApplicationBase
    {
        #region Constructors

        private SingleInstanceApplication()
        {
            IsSingleInstance = true;
        }

        #endregion

        #region Methods

        #region Public Static Methods

        public static void Run(Form frm, StartupNextInstanceEventHandler startupHandler)
        {
            SingleInstanceApplication app = new SingleInstanceApplication();
            app.MainForm = frm;
            app.StartupNextInstance += startupHandler;
            app.Run(Environment.GetCommandLineArgs());
        }

        #endregion

        #endregion
    }
}