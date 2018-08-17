using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace Kiss.Server.PSCD.WindowsService
{
    // Provide the ProjectInstaller class which allows
    // the service to be installed by the Installutil.exe tool
    [RunInstaller(true)]
    public class KbuTransferlaufWindowsServiceInstaller : Installer
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly ServiceProcessInstaller _process;
        private readonly ServiceInstaller _service;

        #endregion

        #endregion

        #region Constructors

        public KbuTransferlaufWindowsServiceInstaller()
        {
            _process = new ServiceProcessInstaller
            {
                Account = ServiceAccount.LocalSystem
            };
            _service = new ServiceInstaller
            {
                ServiceName = "Kiss.Server.PSCD.WindowsService",
                DisplayName= "Beleg-Transferlauf KiSS->PSCD",
                StartType = ServiceStartMode.Automatic,
                Description= "Bietet eine WCF-Schnittstelle an, um Belege von KiSS an PSCD zu übertragen"
            };
            Installers.Add(_process);
            Installers.Add(_service);
        }

        #endregion
    }
}