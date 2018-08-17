using System.ServiceProcess;

namespace Kiss.Server.PSCD.WindowsService
{
    static class Program
    {
        #region Methods

        #region Private Static Methods

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            var servicesToRun = new ServiceBase[]
            {
                new KbuTransferlaufWindowsService()
            };
            ServiceBase.Run(servicesToRun);
        }

        #endregion

        #endregion
    }
}