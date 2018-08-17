using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Xml.Linq;
using Kiss.BusinessLogic.Ba;
using Kiss.BusinessLogic.Log;
using Kiss.DbContext;
using Kiss.DbContext.DTO.Ba;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using Kiss.Server.Einwohnerregister.OmegaAdresseHistService;
using Kiss.Server.Einwohnerregister.OmegaAnfrageSimpleService;
using Kiss.Server.Einwohnerregister.OmegaDeRegistService;
using Kiss.Server.Einwohnerregister.OmegaRegistService;
using Kiss.Server.Einwohnerregister.OmegaSucheService;

namespace Kiss.Server.Einwohnerregister.Omega
{
    public class OmegaService : EinwohnerregisterService
    {
        internal const string END_USER_ID = "kisssrv";
        internal const string END_USER_NAME = "KiSS Server";
        internal const string RECIPIENT_ID = "KISS";
        private readonly ServiceProcessErrorService _serviceProcessErrorService = Container.Resolve<ServiceProcessErrorService>();
        private readonly ISessionService _sessionService = Container.Resolve<ISessionService>();

        public override ServiceResult<BaEinwohnerregisterPersonAnfrageDTO> GetPersonDetails(string pid, int xUserId)
        {
            var configDto = _baEinwohnerregisterService.GetConfigDTO();
            var anfrageEndpoint = GetEndpoint(configDto.AnfrageWebserviceUrl);
            var adresseEndpoint = GetEndpoint(configDto.AdresseHistWebserviceUrl);
            var binding = GetBinding(configDto.SucheWebserviceUrl, configDto.EinwohnerregisterWebservicesProxy);

            var user = _xUserService.GetEntityById(xUserId);

            BaEinwohnerregisterPersonAnfrageDTO anfrageDto;
            dataRequestResponse personAnfrageResponse;

            try
            {
                // Person
                var personAnfrageService = new PersonAnfrageService();
                var anfrageClient = new SI_O101_L_Anfrage_sync_obClient(binding, anfrageEndpoint);
                SetClientCredentials(anfrageClient, configDto);
                anfrageClient.Open();

                var personInput = personAnfrageService.CreatePersonInputLightDTO(
                    pid,
                    user.LogonName,
                    user.LastNameFirstName,
                    configDto.EinwohnerregisterWebservicesUsername);

                personAnfrageResponse = anfrageClient.SI_O101_L_Anfrage_sync_ob(personInput);
                anfrageClient.Close();

                anfrageDto = personAnfrageService.CreatePersonAnfrageDTO(personAnfrageResponse);
            }
            catch (Exception ex)
            {
                ServiceResult<BaEinwohnerregisterPersonAnfrageDTO> result;
                var faultInfo = HandleFaultException(ref ex);

                if (faultInfo != null && faultInfo.Contains("Person nicht gefunden"))
                {
                    result = new ServiceResult<BaEinwohnerregisterPersonAnfrageDTO>(
                        ServiceResultType.Warning,
                        "Person mit PID {0} in Omega nicht gefunden.",
                        null, null, pid);
                }
                else
                {
                    result = new ServiceResult<BaEinwohnerregisterPersonAnfrageDTO>(ex, null, "Fehler bei der Abfrage der Personendaten.");
                }

                _serviceProcessErrorService.CreateProcessError(
                    result,
                    GetType().Name,
                    MethodBase.GetCurrentMethod().Name,
                    faultInfo,
                    xUserId,
                    null,
                    pid);
                return result;
            }

            try
            {
                // Adresse
                var adresseHistService = new AdresseHistService();
                var adresseClient = new SI_O103_histAdr_sync_obClient(binding, adresseEndpoint);
                SetClientCredentials(adresseClient, configDto);
                adresseClient.Open();

                var adresseInput = adresseHistService.CreateAdresseInputDTO(
                    personAnfrageResponse,
                    user.LogonName,
                    user.LastNameFirstName,
                    configDto.EinwohnerregisterWebservicesUsername);
                var adresseOutput = adresseClient.SI_O103_S05b_histAdr_sync_ob(adresseInput);
                adresseClient.Close();

                var adressen = adresseHistService.GetHistAdressen(adresseOutput);

                if (adressen.Length > 0)
                {
                    anfrageDto.Adressen = adressen;
                }

                return new ServiceResult<BaEinwohnerregisterPersonAnfrageDTO>(anfrageDto);
            }
            catch (Exception ex)
            {
                var faultInfo = HandleFaultException(ref ex);
                var result = new ServiceResult<BaEinwohnerregisterPersonAnfrageDTO>(ex, null, "Fehler bei der Abfrage der Adressdaten") { Result = anfrageDto };
                _serviceProcessErrorService.CreateProcessError(
                    result,
                    GetType().Name,
                    MethodBase.GetCurrentMethod().Name,
                    faultInfo,
                    xUserId,
                    null,
                    pid);
                return result;
            }
        }

        /// <summary>
        /// Person in Omega Abmelden (deRegistrieren)
        /// </summary>
        public override ServiceResult PersonAbmelden(BaEinwohnerregisterPersonStatusDTO dto)
        {
            var configDto = _baEinwohnerregisterService.GetConfigDTO();
            var endpoint = GetEndpoint(configDto.DeRegistWebserviceUrl);
            var binding = GetBinding(configDto.DeRegistWebserviceUrl, configDto.EinwohnerregisterWebservicesProxy);

            var client = new SI_O13_deRegist_sync_obClient(binding, endpoint);
            SetClientCredentials(client, configDto);
            client.Open();

            try
            {
                // Deregistration auf Omega
                var resultInfo = client.SI_O13_deRegist_sync_ob(
                    new deregistrationRequest
                    {
                        deregistrationHeader = new deregistrationRequestDeregistrationHeader
                        {
                            enduserId = END_USER_ID,
                            enduserName = END_USER_NAME,
                            techuserId = configDto.EinwohnerregisterWebservicesUsername
                        },
                        deregistrationBody = new deregistrationRequestDeregistrationBody
                        {
                            recipientId = RECIPIENT_ID,
                            Items = new object[] { new deregistrationPersonType { personId = dto.EinwohnerregisterId } }
                        }
                    });

                if (resultInfo.Length == 0)
                {
                    var error = ServiceResult.Error("Received no result from Omega.");
                    _serviceProcessErrorService.CreateProcessError(
                        error,
                        GetType().Name,
                        MethodBase.GetCurrentMethod().Name,
                        "Fehler beim Abmelden einer Person",
                        _sessionService.AuthenticatedUser.UserID,
                        dto.BaPersonId,
                        dto.EinwohnerregisterId);
                    return error;
                }

                var result = resultInfo.First();

                if (result.code == "S")
                {
                    // Person aus Status-Tabelle löschen und Log-Eintrag erstellen
                    var service = Container.Resolve<BaEinwohnerregisterService>();
                    var serviceResult = service.ProcessPersonAbmeldung(dto);

                    if (!serviceResult.IsOk)
                    {
                        _log.Error(serviceResult.ToString());
                        return new ServiceResult(serviceResult);
                    }
                }
                else
                {
                    var error = ServiceResult.Error("Omega result code: {0}, Message: {1}", result.code, result.textEnglish);
                    _serviceProcessErrorService.CreateProcessError(
                        error,
                        GetType().Name,
                        MethodBase.GetCurrentMethod().Name,
                        "Fehler beim Abmelden einer Person",
                        _sessionService.AuthenticatedUser.UserID,
                        dto.BaPersonId,
                        dto.EinwohnerregisterId);
                    return error;
                }
            }
            catch (Exception ex)
            {
                var faultInfo = HandleFaultException(ref ex);
                var result = new ServiceResult(ex, null, "Fehler beim Webservice-Aufruf");
                _serviceProcessErrorService.CreateProcessError(
                    result,
                    GetType().Name,
                    MethodBase.GetCurrentMethod().Name,
                    faultInfo,
                    null,
                    dto.BaPersonId,
                    dto.EinwohnerregisterId);
                return result;
            }
            finally
            {
                client.Close();
            }

            return ServiceResult.Ok();
        }

        /// <summary>
        /// Person in Omega Anmelden (Registrieren)
        /// </summary>
        public override ServiceResult PersonAnmelden(BaEinwohnerregisterPersonStatusDTO dto)
        {
            var configDto = _baEinwohnerregisterService.GetConfigDTO();
            var endpoint = GetEndpoint(configDto.RegistWebserviceUrl);
            var binding = GetBinding(configDto.RegistWebserviceUrl, configDto.EinwohnerregisterWebservicesProxy);

            var client = new SI_O13_Regist_sync_obClient(binding, endpoint);
            SetClientCredentials(client, configDto);
            client.Open();

            try
            {
                // Registration auf Omega
                var resultInfo = client.SI_O13_Regist_sync_ob(
                    new registrationRequest
                    {
                        registrationHeader = new registrationRequestRegistrationHeader
                        {
                            enduserId = END_USER_ID,
                            enduserName = END_USER_NAME,
                            techuserId = configDto.EinwohnerregisterWebservicesUsername
                        },
                        registrationBody = new registrationRequestRegistrationBody
                        {
                            recipientId = RECIPIENT_ID,
                            Items = new object[] { new registrationPersonType { personId = dto.EinwohnerregisterId } }
                        }
                    });

                if (resultInfo.Length == 0)
                {
                    var error = ServiceResult.Error("Received no result from Omega.");
                    _serviceProcessErrorService.CreateProcessError(
                        error,
                        GetType().Name,
                        MethodBase.GetCurrentMethod().Name,
                        "Fehler beim Anmelden einer Person",
                        _sessionService.AuthenticatedUser.UserID,
                        dto.BaPersonId,
                        dto.EinwohnerregisterId);
                    return error;
                }

                var result = resultInfo.First();

                if (result.code == "S")
                {
                    // Person in Status-Tabelle einfügen und Log-Eintrag erstellen
                    var service = Container.Resolve<BaEinwohnerregisterService>();
                    var serviceResult = service.ProcessPersonAnmeldung(dto);

                    if (!serviceResult.IsOk)
                    {
                        _log.Error(serviceResult.ToString());
                        return new ServiceResult(serviceResult);
                    }
                }
                else
                {
                    var error = ServiceResult.Error("Omega result code: {0}, Message: {1}", result.code, !string.IsNullOrEmpty(result.textGerman) ? result.textGerman : result.textEnglish);
                    _serviceProcessErrorService.CreateProcessError(
                        error,
                        GetType().Name,
                        MethodBase.GetCurrentMethod().Name,
                        "Fehler beim Anmelden einer Person",
                        _sessionService.AuthenticatedUser.UserID,
                        dto.BaPersonId,
                        dto.EinwohnerregisterId);
                    return error;
                }
            }
            catch (Exception ex)
            {
                var faultInfo = HandleFaultException(ref ex);
                var result = new ServiceResult(ex, null, "Fehler beim Webservice-Aufruf");
                _serviceProcessErrorService.CreateProcessError(
                    result,
                    GetType().Name,
                    MethodBase.GetCurrentMethod().Name,
                    faultInfo,
                    null,
                    dto.BaPersonId,
                    dto.EinwohnerregisterId);
                return result;
            }
            finally
            {
                client.Close();
            }

            return ServiceResult.Ok();
        }

        public override ServiceResult<BaEinwohnerregisterPersonResultDTO[]> PersonSuchen(BaEinwohnerregisterPersonSucheDTO personSucheDto, int xUserId)
        {
            var configDto = _baEinwohnerregisterService.GetConfigDTO();
            var endpoint = GetEndpoint(configDto.SucheWebserviceUrl);
            var binding = GetBinding(configDto.SucheWebserviceUrl, configDto.EinwohnerregisterWebservicesProxy);

            var client = new SI_O102_Suche_sync_obClient(binding, endpoint);
            SetClientCredentials(client, configDto);
            client.Open();

            try
            {
                var user = _xUserService.GetEntityById(xUserId);
                var personSucheService = new PersonSucheService();

                var input = personSucheService.CreateSearchInputDTO(
                    personSucheDto,
                    user.LogonName,
                    user.LastNameFirstName,
                    configDto.EinwohnerregisterWebservicesUsername);
                var output = client.SI_O102_Suche_sync_ob(input);

                if (output.persons == null)
                {
                    return ServiceResult<BaEinwohnerregisterPersonResultDTO[]>.Warning("Keine Person gefunden.");
                }

                var result = output.persons.Select(personSucheService.CreateSearchResultDTO).ToArray();
                return new ServiceResult<BaEinwohnerregisterPersonResultDTO[]>(result);
            }
            catch (Exception ex)
            {
                var faultInfo = HandleFaultException(ref ex);
                var result = new ServiceResult<BaEinwohnerregisterPersonResultDTO[]>(ex, null, "Fehler beim Webservice-Aufruf");
                _serviceProcessErrorService.CreateProcessError(
                    result,
                    GetType().Name,
                    MethodBase.GetCurrentMethod().Name,
                    faultInfo,
                    xUserId,
                    null,
                    personSucheDto.PID);
                return result;
            }
            finally
            {
                client.Close();
            }
        }

        public override ServiceResult ProcessEvents(int packetSize, bool includeFailedEvents)
        {
            var eventService = new EventService(_serviceProcessErrorService, _baEinwohnerregisterService);

            var config = _baEinwohnerregisterService.GetConfigDTO();
            var ftpUrl = config.FtpUrl;
            var ftpUser = config.FtpUser;
            var ftpPassword = config.FtpPassword;

            if (string.IsNullOrWhiteSpace(ftpUrl))
            {
                return ServiceResult.Error("Es ist kein FTP-Server in der Konfiguration definiert.");
            }

            // Liste mit noch nicht verarbeiteten Ereignissen aus der DB holen und Stück für Stück abarbeiten
            // (packetSize limitiert die Anzahl gleichzeitig geladener Files).
            IList<BaEinwohnerregisterEmpfangeneEreignisseRohdaten> failedOrPendingRohdatenList;
            var serviceResult = ServiceResult.Ok();

            var totalCount = eventService.GetFailedOrPendingRohdatenCount(includeFailedEvents);
            var processedCount = 0;
            Logger.LogMessage(null, "Begin loading unprocessed event files from the database. Packet size: {0}, file count: {1}", packetSize, totalCount);
            while ((failedOrPendingRohdatenList = eventService.GetFailedOrPendingRohdaten(packetSize, includeFailedEvents)).Any())
            {
                var processResult = eventService.ProcessAndImportEventRohdaten(failedOrPendingRohdatenList);
                processedCount += failedOrPendingRohdatenList.Count;
                if (processResult.IsOk)
                {
                    Logger.LogMessage(null, "Successfully processed event files from the database ({0}/{1}).", processedCount, totalCount);
                }
                else
                {
                    Logger.LogError(null, null, "Processed event files from the database with errors ({0}/{1}): {2}", processedCount, totalCount, processResult);
                }
                serviceResult += processResult;
            }
            failedOrPendingRohdatenList.Clear();

            // Liste mit Dateinamen vom FTP holen und anschliessend die Events importieren
            List<string> xmlFileNames;

            try
            {
                Logger.LogMessage(null, "Begin downloading the list of event files from the FTP server ({0}).", config.FtpUrl);
                xmlFileNames = eventService.GetEventFtpFileNames(config);
                Logger.LogMessage(null, "Event file list successfully downloaded. Number of event files: {0}", xmlFileNames.Count);
            }
            catch (Exception ex)
            {
                Logger.LogError(null, ex, "Failed to download the event file list.");
                var result = ServiceResult.Error(ex);
                _serviceProcessErrorService.CreateProcessError(
                    result,
                    GetType().Name,
                    MethodBase.GetCurrentMethod().Name,
                    "Die Liste der Event-Dateien konnte nicht vom FTP-Server geladen werden.",
                    _sessionService.AuthenticatedUser.UserID);
                return result;
            }

            // Dateien herunterladen und in KiSS speichern
            var downloadResult = ServiceResult.Ok();
            var downloadedRohdatenList = new List<BaEinwohnerregisterEmpfangeneEreignisseRohdaten>();

            using (var downloadClient = new WebClient { Credentials = new NetworkCredential(ftpUser, ftpPassword) })
            {
                downloadClient.Proxy = null;

                totalCount = xmlFileNames.Count;
                processedCount = 0;
                int downloadedCount = 0;

                Logger.LogMessage(null, "Begin downloading the event files. Packet size: {0}, file count: {1}.", packetSize, totalCount);

                foreach (var xmlFileName in xmlFileNames)
                {
                    var rohdatenResult = eventService.DownloadAndSaveEvent(xmlFileName, downloadClient, config);

                    if (rohdatenResult.Result != null)
                    {
                        downloadedRohdatenList.Add(rohdatenResult.Result);
                    }

                    downloadedCount++;
                    downloadResult += rohdatenResult;

                    // wenn Paketgrösse erreicht ist, soll der Import durchgeführt werden. Danach wird die Liste geleert, um Memory zu sparen.
                    if (downloadedRohdatenList.Count >= packetSize || downloadedCount == totalCount)
                    {
                        var processResult = eventService.ProcessAndImportEventRohdaten(downloadedRohdatenList);
                        processedCount += downloadedRohdatenList.Count;
                        downloadedRohdatenList.Clear();

                        if (processResult.IsOk)
                        {
                            Logger.LogMessage(null, "Successfully processed event files from the FTP server ({0}/{1}).", processedCount, totalCount);
                        }
                        else
                        {
                            Logger.LogError(null, null, "Processed event files from the FTP server with errors ({0}/{1}): {2}", processedCount, totalCount, processResult);
                        }
                        serviceResult += processResult;
                    }
                }
            }

            if (!downloadResult.IsOk)
            {
                _serviceProcessErrorService.CreateProcessError(
                    downloadResult,
                    GetType().Name,
                    MethodBase.GetCurrentMethod().Name,
                    "Fehler beim Download der Event-Dateien.");
            }

            return serviceResult;
        }

        internal static string PreparePid(string pid)
        {
            return string.IsNullOrWhiteSpace(pid) ? null : pid.PadLeft(10, '0');
        }

        protected override Binding GetBinding(string uri, string proxy)
        {
            var binding = (BasicHttpBinding)base.GetBinding(uri, proxy);
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            binding.Security.Transport.Realm = "XISOAPApps";
            binding.ReceiveTimeout = TimeSpan.FromMinutes(5d);
            binding.SendTimeout = TimeSpan.FromMinutes(5d);
            return binding;
        }

        private string HandleFaultException(ref Exception ex)
        {
            try
            {
                string info;
                if (ex is FaultException)
                {
                    var fault = ((FaultException)ex).CreateMessageFault();
                    info = fault.GetDetail<XElement>().Value;
                    Logger.LogError(null, ex, info);
                    ex = new Exception(string.Format("Fehler beim Webservice-Aufruf: {0}", info), ex);
                }
                else
                {
                    info = ex.ToString();
                }
                return info;
            }
            catch (Exception exception)
            {
                return exception.ToString();
            }
        }
    }
}