using System;
using System.Configuration;
using System.Reflection;

using Kiss.BusinessLogic.Sys;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using log4net;
using log4net.Config;

namespace Kiss.Server.Iban
{
    public class KissIbanService : IKissIbanService
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(KissIbanService));

        public KissIbanService()
        {
            // Initialize IoC Container
            Container.LoadAppConfiguration();

            // Initialize log4net
            XmlConfigurator.Configure();

            InitializeDatabase();
        }

        public string ConvertToIban(string kontoNr, string clearingNr)
        {
            var ibanConverterService = Container.Resolve<IbanConverterService>();
            var result = ibanConverterService.ConvertToIbanWeb(kontoNr, clearingNr);

            if (result.IsOk && !string.IsNullOrEmpty(result.Result))
            {
                return result.Result;
            }

            _log.Error(result);
            return null;
        }

        /// <summary>
        /// Version, Servername und DB-Name bekommen
        /// </summary>
        /// <returns>Returns a String like "4.7.09.100, DB SZHM9301\SOZ_KISS_D\KiSS_ZH_DEV_R4709"</returns>
        public string GetServerVersion()
        {
            var sessionService = Container.Resolve<ISessionService>();
            var version = string.Format("{0} , DB {1}\\{2}", Assembly.GetExecutingAssembly().GetName().Version, sessionService.ServerName, sessionService.DatabaseName);
            return version;
        }

        public string TestIbanWebservice(string kontoNr = null, string clearingNr = null)
        {
            kontoNr = kontoNr ?? ConfigurationManager.AppSettings.Get("TestKontoNr");
            clearingNr = clearingNr ?? ConfigurationManager.AppSettings.Get("TestClearingNr");

            var ibanConverterService = Container.Resolve<IbanConverterService>();
            var result = ibanConverterService.ConvertToIbanWeb(kontoNr, clearingNr);

            if (!result.IsOk || string.IsNullOrEmpty(result.Result))
            {
                _log.Error(result.Result);
                return result.Result ?? result.GetTechnicalDetails();
            }

            return null;
        }

        private void InitializeDatabase()
        {
            try
            {
                var sessionService = Container.Resolve<ISessionService>();
                var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                sessionService.Open(connectionString, null, false);

                var configService = Container.Resolve<XConfigService>();
                configService.ReloadCache();
            }
            catch (Exception ex)
            {
                _log.ErrorFormat(ex.Message);
                throw;
            }
        }
    }
}