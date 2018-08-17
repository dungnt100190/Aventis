using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;

using log4net;
using log4net.Config;

namespace Kiss.Update
{
    public partial class App
    {
        #region Fields

        #region Private Static Fields

        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #endregion

        #region Constructors

        public App()
        {
            DispatcherUnhandledException += App_DispatcherUnhandledException;
            XmlConfigurator.Configure();
        }

        #endregion

        #region EventHandlers

        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            _log.Error("Unhandled exception", e.Exception);
            MessageBox.Show("Ein unbekannter Fehler ist aufgetreten.", "Fehler beim Update von KiSS");
            e.Handled = true;
            Shutdown(-2);
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void OnStartup(StartupEventArgs e)
        {
            if (e.Args.Length >= 2)
            {
                var source = e.Args[0];
                var destination = e.Args[1];
                var mainFileName = (e.Args.Length == 3) ? e.Args[2] : Constants.KISS_MAIN_FILE_NAME;
                base.OnStartup(e);

                // perform update from args[0] to the local directory
                var window = new MainWindow(source, destination, mainFileName);
                window.ShowDialog();

                // start KiSS after the window closes
                new Process
                {
                    StartInfo = new ProcessStartInfo(Path.Combine(destination, mainFileName), "/" + Constants.ARG_NO_UPDATE)
                }.Start();
            }
            else
            {
                Shutdown(-1);
            }
        }

        #endregion

        #endregion
    }
}