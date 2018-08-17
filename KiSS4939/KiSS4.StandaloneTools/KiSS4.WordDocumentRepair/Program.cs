using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace KiSS4.WordDocumentRepair
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ApplicationExit += Application_ApplicationExit;

            Application.Run(new WordDocumentRepairForm());

        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            XDokumentHelper.QuitApplications();
        }
    }
}
