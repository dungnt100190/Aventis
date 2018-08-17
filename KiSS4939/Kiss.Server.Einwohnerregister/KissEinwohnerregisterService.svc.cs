using System;
using System.Configuration;
using System.Linq;
using System.Reflection;

using Kiss.BusinessLogic.Ba;
using Kiss.BusinessLogic.Log;
using Kiss.BusinessLogic.Sys;
using Kiss.DbContext.DTO.Ba;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using Kiss.Server.Einwohnerregister.Properties;

using log4net.Config;

namespace Kiss.Server.Einwohnerregister
{
    public class KissEinwohnerregisterService : IKissEinwohnerregisterService
    {
        private readonly ServiceCallService _logServiceCallService;
        private readonly IEinwohnerregisterService _wsEinwohnerregisterService;

        public KissEinwohnerregisterService()
        {
            // Initialize IoC Container
            Container.LoadAppConfiguration();

            // Initialize log4net
            XmlConfigurator.Configure();

            InitializeDatabase();

            _logServiceCallService = Container.Resolve<ServiceCallService>();
            _wsEinwohnerregisterService = Container.Resolve<IEinwohnerregisterService>();

            // TODO DEBUG
            SslCertificateValidator.IsValidating = false;
        }

        public ServiceResult<BaEinwohnerregisterPersonAnfrageDTO> GetPersonDetails(string dbName, string pid, int xUserId, string machineName)
        {
            Logger.LogMessage(xUserId, "GetPersonDetails, PID: {0}, DB: {1}", pid, dbName);

            var dbNameResult = CheckDbName(dbName);
            if (!dbNameResult.IsOk)
            {
                return new ServiceResult<BaEinwohnerregisterPersonAnfrageDTO>(dbNameResult);
            }

            var logServiceCallEntity = _logServiceCallService.SaveServiceCall(
                                                    xUserId,
                                                    machineName,
                                                    typeof(KissEinwohnerregisterService).Name,
                                                    MethodBase.GetCurrentMethod().Name,
                                                    string.Format("PID: {0}, DB: {1}", pid, dbName));

            try
            {
                var result = _wsEinwohnerregisterService.GetPersonDetails(pid, xUserId);

                if (result.IsOk)
                {
                    _logServiceCallService.UpdateServiceCall(
                        logServiceCallEntity,
                        DateTime.Now,
                        ServiceResultType.Ok,
                        null);
                }
                else
                {
                    _logServiceCallService.UpdateServiceCall(
                        logServiceCallEntity,
                        DateTime.Now,
                        ServiceResultType.Error,
                        result.GetTechnicalDetails());
                }

                return result;
            }
            catch (Exception ex)
            {
                Logger.LogError(xUserId, ex, "PersonDetails");

                _logServiceCallService.UpdateServiceCall(
                    logServiceCallEntity,
                    DateTime.Now,
                    ServiceResultType.Error,
                    ex.ToString());

                return new ServiceResult<BaEinwohnerregisterPersonAnfrageDTO>(ex);
            }
        }

        /// <summary>
        /// Version, Servername und DB-Name bekommen
        /// </summary>
        /// <returns>Returns a String like "4.7.09.100, DB SZHM9301\SOZ_KISS_D\KiSS_ZH_DEV_R4709"</returns>
        public string GetServerVersion()
        {
            Logger.LogMessage(null, "GetServerVersion");
            var logServiceCallEntity = _logServiceCallService.SaveServiceCall(
                null,
                Environment.MachineName,
                typeof(KissEinwohnerregisterService).Name,
                MethodBase.GetCurrentMethod().Name,
                null);

            var sessionService = Container.Resolve<ISessionService>();
            var version = string.Format("{0} , DB {1}\\{2}", Assembly.GetExecutingAssembly().GetName().Version, sessionService.ServerName, sessionService.DatabaseName);

            _logServiceCallService.UpdateServiceCall(
                logServiceCallEntity,
                DateTime.Now,
                ServiceResultType.Ok,
                string.Format("ServerVersion: {0}", version)
                );

            return version;
        }

        /// <summary>
        /// Generische Methode um die SollListe der BaPerson (Tabelle BaPerson) mit der IstListe der Personen (Tablle BaEinWohner...Status) zu vergleichen und aktualisieren.
        /// Jede neue oder entfernte Person verursacht einen Eintrag in der log Tabelle (log.BaEinwocherAnAb...)
        /// Jede An/Abmeldung wird durch das Service and das FremdSystem gemeldet.
        /// </summary>
        public string PersonenAnAbmelden(string dbName)
        {
            Logger.LogMessage(null, "PersonenAnAbmelden");

            var dbNameResult = CheckDbName(dbName);
            if (!dbNameResult.IsOk)
            {
                return dbNameResult.ToString();
            }

            var logServiceCallEntity = _logServiceCallService.SaveServiceCall(
                                                    null,
                                                    Environment.MachineName,
                                                    typeof(KissEinwohnerregisterService).Name,
                                                    MethodBase.GetCurrentMethod().Name,
                                                    string.Format("DB={0}", dbName));

            try
            {
                var service = Container.Resolve<BaEinwohnerregisterService>();
                var dtoResult = service.GetStatusDTOList();

                if (!dtoResult.IsOk)
                {
                    _logServiceCallService.UpdateServiceCall(
                        logServiceCallEntity,
                        DateTime.Now,
                        ServiceResultType.Error,
                        dtoResult.GetTechnicalDetails() //RAT : Perhaps result.GetWarningsAndErrors() better
                        );

                    return dtoResult.GetWarningsAndErrors();
                }

                var anmeldenList = dtoResult.Result.Where(x => x.Anmelden).ToList();
                var abmeldenList = dtoResult.Result.Where(x => !x.Anmelden).ToList();

                var serviceResult = ServiceResult.Ok();

                foreach (var dto in anmeldenList)
                {
                    serviceResult += _wsEinwohnerregisterService.PersonAnmelden(dto);
                }

                foreach (var dto in abmeldenList)
                {
                    serviceResult += _wsEinwohnerregisterService.PersonAbmelden(dto);
                }

                //Log Result
                if (serviceResult.IsOk())
                {
                    _logServiceCallService.UpdateServiceCall(
                        logServiceCallEntity,
                        DateTime.Now,
                        ServiceResultType.Ok,
                        String.Format("Anzahl An/Abmeldung: {0}/{1}", anmeldenList.Count, abmeldenList.Count)
                        );
                    return null;
                }

                _logServiceCallService.UpdateServiceCall(
                    logServiceCallEntity,
                    DateTime.Now,
                    ServiceResultType.Error,
                    serviceResult.GetTechnicalDetails() //RAT : Perhaps result.GetWarningsAndErrors() better
                    );
                return serviceResult.GetWarningsAndErrors();
            }
            catch (Exception ex)
            {
                _logServiceCallService.UpdateServiceCall(
                    logServiceCallEntity,
                    DateTime.Now,
                    ServiceResultType.Error,
                    ex.ToString());

                Logger.LogError(null, ex, "PersonAnAbMelden");
                return ex.ToString();
            }
        }

        public ServiceResult<BaEinwohnerregisterPersonResultDTO[]> PersonSuchen(string dbName, BaEinwohnerregisterPersonSucheDTO dto, int xUserId, string machineName)
        {
            Logger.LogMessage(xUserId, "PersonSuchen");

            var dbNameResult = CheckDbName(dbName);
            if (!dbNameResult.IsOk)
            {
                return new ServiceResult<BaEinwohnerregisterPersonResultDTO[]>(dbNameResult);
            }

            var logServiceCallEntity = _logServiceCallService.SaveServiceCall(
                                                    xUserId,
                                                    machineName,
                                                    typeof(KissEinwohnerregisterService).Name,
                                                    MethodBase.GetCurrentMethod().Name,
                                                    dto);

            try
            {
                var result = _wsEinwohnerregisterService.PersonSuchen(dto, xUserId);

                if (result.IsOk)
                {
                    Logger.LogMessage(xUserId, "{0} persons found.", result.Result.Length);

                    _logServiceCallService.UpdateServiceCall(
                        logServiceCallEntity,
                        DateTime.Now,
                        ServiceResultType.Ok,
                        string.Format("Anzahl Personen gefunden : {0}", result.Result.Length));
                }
                else if (result.IsWarning)
                {
                    Logger.LogWarning(xUserId, result.ToString());

                    _logServiceCallService.UpdateServiceCall(
                        logServiceCallEntity,
                        DateTime.Now,
                        ServiceResultType.Warning,
                        result.GetTechnicalDetails()); //RAT : Perhaps result.GetWarningsAndErrors() better
                }
                else
                {
                    _logServiceCallService.UpdateServiceCall(
                        logServiceCallEntity,
                        DateTime.Now,
                        ServiceResultType.Error,
                        result.GetTechnicalDetails()); //RAT : Perhaps result.GetWarningsAndErrors() better

                    Logger.LogError(xUserId, null, result.GetTechnicalDetails());
                }

                return new ServiceResult<BaEinwohnerregisterPersonResultDTO[]>(result);
            }
            catch (Exception ex)
            {
                Logger.LogError(xUserId, ex, "PersonSuchen");

                _logServiceCallService.UpdateServiceCall(
                    logServiceCallEntity,
                    DateTime.Now,
                    ServiceResultType.Error,
                    ex.ToString());

                return new ServiceResult<BaEinwohnerregisterPersonResultDTO[]>(ex);
            }
        }

        public string ProcessEvents(string dbName, int? packetSize, bool includeFailedEvents = false)
        {
            if (packetSize.HasValue)
            {
                Logger.LogMessage(null, "ProcessEvents, DB: {0}, Packet size: {1}, Include failed events: {2}", dbName, packetSize.Value, includeFailedEvents);
            }
            else
            {
                packetSize = Settings.Default.DefaultEventPackageSize;
                Logger.LogMessage(null, "ProcessEvents, DB: {0}, Using default packet size: {1}, Include failed events: {2}", dbName, packetSize.Value, includeFailedEvents);
            }

            var dbNameResult = CheckDbName(dbName);
            if (!dbNameResult.IsOk)
            {
                Logger.LogError(null, null, "Wrong DB-Name: {0}", dbNameResult.ToString());
                return dbNameResult.ToString();
            }

            var logServiceCallEntity = _logServiceCallService.SaveServiceCall(
                                                    null,
                                                    null,
                                                    typeof(KissEinwohnerregisterService).Name,
                                                    MethodBase.GetCurrentMethod().Name,
                                                    string.Format("DB: {0}", dbName));

            try
            {
                var result = _wsEinwohnerregisterService.ProcessEvents(packetSize.Value, includeFailedEvents);

                if (!result.IsOk)
                {
                    var warningsAndErrors = result.GetWarningsAndErrors();
                    Logger.LogMessage(null, "ProcessEvents warnings and errors length: {0}", warningsAndErrors.Length);
                    if (warningsAndErrors.Length > 60000)
                    {
                        warningsAndErrors = string.Format("{0}...{1} -> siehe Service Error Log für weitere Fehlermeldungen.", warningsAndErrors.Substring(0, 60000), Environment.NewLine);
                    }

                    _logServiceCallService.UpdateServiceCall(
                        logServiceCallEntity,
                        DateTime.Now,
                        ServiceResultType.Error,
                        result.GetTechnicalDetails());
                    return warningsAndErrors;
                }

                _logServiceCallService.UpdateServiceCall(logServiceCallEntity, DateTime.Now, ServiceResultType.Ok, null);
            }
            catch (Exception ex)
            {
                Logger.LogError(null, ex, "ProcessEvents");

                _logServiceCallService.UpdateServiceCall(
                    logServiceCallEntity,
                    DateTime.Now,
                    ServiceResultType.Error,
                    ex.ToString());
                return ex.ToString();
            }

            return null;
        }

        private static ServiceResult CheckDbName(string dbName)
        {
            var result = ServiceResult.Ok();
            var sessionService = Container.Resolve<ISessionService>();

            if (string.IsNullOrEmpty(dbName))
            {
                result = ServiceResult.Error("Der Parameter 'dbName' ist für den Aufruf erforderlich.");
            }
            else if (string.IsNullOrEmpty(sessionService.DatabaseName))
            {
                result = ServiceResult.Error("Es besteht keine Verbindung zu einer Datenbank.");
            }
            else if (!string.Equals(sessionService.DatabaseName, dbName, StringComparison.CurrentCultureIgnoreCase))
            {
                result = ServiceResult.Error(
                    "Die Konfigurierte Datenbank unterscheidet sich von der Datenbank des Aufrufs! (Konfiguriert: {0}, Aufruf: {1}",
                    sessionService.DatabaseName,
                    dbName);
                return result;
            }

            if (!result.IsOk)
            {
                Logger.LogMessage(null, result.ToString());
            }

            return result;
        }

        private static void InitializeDatabase()
        {
            try
            {
                var sessionService = Container.Resolve<ISessionService>();

                if (sessionService.AuthenticatedUser == null)
                {
                    var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    sessionService.Open(connectionString, null, false);
                }

                var configService = Container.Resolve<XConfigService>();
                configService.ReloadCache();
            }
            catch (Exception ex)
            {
                Logger.LogError(null, ex, ex.Message);
                throw;
            }
        }
    }
}