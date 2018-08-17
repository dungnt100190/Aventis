using System.ServiceModel;
using System.ServiceProcess;

namespace Kiss.Server.PSCD.WindowsService
{
    public class KbuTransferlaufWindowsService : ServiceBase
    {
        #region Fields

        #region Private Fields

        private ServiceHost _serviceHost;

        #endregion

        #endregion

        #region Constructors

        public KbuTransferlaufWindowsService()
        {
            // Name the Windows Service
            ServiceName = "Kiss.Server.PSCD.WindowsService";
        }

        #endregion

        #region Methods

        #region Protected Methods

        // Start the Windows service.
        protected override void OnStart(string[] args)
        {
            if (_serviceHost != null)
            {
                _serviceHost.Close();
            }

            // Create a ServiceHost for the CalculatorService type and
            // provide the base address.
            _serviceHost = new ServiceHost(typeof(KbuTransferlaufWebService));

            // Open the ServiceHostBase to create listeners and start
            // listening for messages.
            _serviceHost.Open();
        }

        protected override void OnStop()
        {
            if (_serviceHost != null)
            {
                _serviceHost.Close();
                _serviceHost = null;
            }
        }

        #endregion

        #endregion
    }
}