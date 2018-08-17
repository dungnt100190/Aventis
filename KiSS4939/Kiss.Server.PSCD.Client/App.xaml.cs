using System.Windows;

using log4net.Config;

namespace Kiss.Server.PSCD.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        #region Methods

        #region Protected Methods

        /// <summary>
        /// This is our main entry point (similar to Program.Main()-method).
        /// </summary>
        /// <param name="e">Event arguments containing an array of parameters passed to the application.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Configure log4net
            XmlConfigurator.Configure();

            int exitCode = 0;

            // Start
            if (e.Args.Length == 0)
            {
                new MainWindow().ShowDialog();
            }
            else
            {
                exitCode = new MainConsole(e.Args).Run();
            }

            Shutdown(exitCode);
        }

        #endregion

        #endregion
    }
}