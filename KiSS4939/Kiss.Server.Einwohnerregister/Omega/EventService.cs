using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;

using Kiss.BusinessLogic.Ba;
using Kiss.BusinessLogic.Log;
using Kiss.DataAccess.Interfaces;
using Kiss.DbContext;
using Kiss.DbContext.Constant;
using Kiss.DbContext.DTO.Ba;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;

using IUnitOfWorkFactory = Kiss.DataAccess.Interfaces.IUnitOfWorkFactory;

namespace Kiss.Server.Einwohnerregister.Omega
{
    public class EventService
    {
        private readonly BaEinwohnerregisterService _baEinwohnerregisterService;
        private readonly ServiceProcessErrorService _serviceProcessErrorService;

        public EventService(ServiceProcessErrorService serviceProcessErrorService, BaEinwohnerregisterService baEinwohnerregisterService)
        {
            _serviceProcessErrorService = serviceProcessErrorService;
            _baEinwohnerregisterService = baEinwohnerregisterService;
        }

        private IUnitOfWorkFactory UnitOfWorkFactory
        {
            get { return Container.Resolve<IUnitOfWorkFactory>(); }
        }

        public ServiceResult<BaEinwohnerregisterEmpfangeneEreignisseRohdaten> DownloadAndSaveEvent(string xmlFileName, WebClient downloadClient, BaEinwohnerregisterConfigDTO config)
        {
            var ftpUrl = config.FtpUrl.TrimEnd('/');
            var fileUrl = ftpUrl + "/" + xmlFileName;

            BaEinwohnerregisterEmpfangeneEreignisseRohdaten rohdaten;

            try
            {
                Logger.LogMessage(null, "Downloading event file: {0}", fileUrl);
                var data = downloadClient.DownloadData(fileUrl);

                var eventDoc = Encoding.UTF8.GetString(data);
                rohdaten = new BaEinwohnerregisterEmpfangeneEreignisseRohdaten
                {
                    Xml = eventDoc,
                    BaEinwohnerregisterEmpfangeneEreignisseRohdatenStatusCode = (int)LOVsGenerated.BaEinwohnerregisterEmpfangeneEreignisseRohdatenStatus.Pendent
                };

                using (var unitOfWork = (IKissUnitOfWork)UnitOfWorkFactory.Create())
                {
                    unitOfWork.BaEinwohnerregisterEmpfangeneEreignisseRohdaten.InsertOrUpdateEntity(rohdaten);
                    unitOfWork.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(null, ex, "Could not download the event file '{0}'", fileUrl);
                var result = ServiceResult.Error(ex);
                _serviceProcessErrorService.CreateProcessError(
                    result,
                    GetType().Name,
                    MethodBase.GetCurrentMethod().Name,
                    string.Format("Fehler beim Download der Event-Datei '{0}'.", fileUrl));
                return new ServiceResult<BaEinwohnerregisterEmpfangeneEreignisseRohdaten>(result);
            }

            // Event nur löschen, wenn Configwert gesetzt (sollte auf INT stets false sein..)
            if (config.DeleteEventFiles)
            {
                try
                {
                    var deleteRequest = GetFtpRequest(fileUrl, WebRequestMethods.Ftp.DeleteFile, config);

                    var response = (FtpWebResponse)deleteRequest.GetResponse();
                    var statusCode = response.StatusCode;
                    response.Close();

                    if (statusCode != FtpStatusCode.FileActionOK)
                    {
                        var result = ServiceResult.Error("Die Event-Datei '{0}' konnte nicht gelöscht werden.", fileUrl);
                        _serviceProcessErrorService.CreateProcessError(
                            result,
                            GetType().Name,
                            MethodBase.GetCurrentMethod().Name,
                            string.Format("Die Event-Datei '{0}' konnte nicht gelöscht werden.", fileUrl));
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError(null, ex, "Could not delete the event file '{0}'", fileUrl);
                    var result = ServiceResult.Error(ex);
                    _serviceProcessErrorService.CreateProcessError(
                        result,
                        GetType().Name,
                        MethodBase.GetCurrentMethod().Name,
                        string.Format("Fehler beim Löschen der Event-Datei '{0}'.", fileUrl));
                    return new ServiceResult<BaEinwohnerregisterEmpfangeneEreignisseRohdaten>(result);
                }
            }

            return new ServiceResult<BaEinwohnerregisterEmpfangeneEreignisseRohdaten>(rohdaten);
        }

        public List<string> GetEventFtpFileNames(BaEinwohnerregisterConfigDTO config)
        {
            var ftpUrl = config.FtpUrl;
            ftpUrl = ftpUrl.TrimEnd('/') + "/";
            var listFilesRequest = GetFtpRequest(ftpUrl, WebRequestMethods.Ftp.ListDirectory, config);

            var fileNames = new List<string>();

            using (var listFilesResponse = (FtpWebResponse)listFilesRequest.GetResponse())
            {
                var listFilesResponseStream = listFilesResponse.GetResponseStream();
                using (var reader = new StreamReader(listFilesResponseStream))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (!string.IsNullOrWhiteSpace(line) && line.ToLower().EndsWith(".xml"))
                        {
                            fileNames.Add(line);
                        }
                    }
                }
            }

            return fileNames;
        }

        public IList<BaEinwohnerregisterEmpfangeneEreignisseRohdaten> GetFailedOrPendingRohdaten(int packetSize, bool includeFailedEvents)
        {
            using (var unitOfWork = (IKissUnitOfWork)UnitOfWorkFactory.Create())
            {
                return unitOfWork.BaEinwohnerregisterEmpfangeneEreignisseRohdaten.GetFailedOrPending(packetSize, includeFailedEvents).ToList();
            }
        }

        public int GetFailedOrPendingRohdatenCount(bool includeFailedEvents)
        {
            using (var unitOfWork = (IKissUnitOfWork)UnitOfWorkFactory.Create())
            {
                return unitOfWork.BaEinwohnerregisterEmpfangeneEreignisseRohdaten.GetFailedOrPendingCount(includeFailedEvents);
            }
        }

        public IServiceResult ImportPerson(string personId, IList<BaEinwohnerregisterEmpfangeneEreignisse> ereignisList)
        {
            int? baPersonId = null;

            try
            {
                using (var unitOfWork = (IKissUnitOfWork)UnitOfWorkFactory.Create())
                {
                    var baPerson = unitOfWork.BaPerson.GetByEinwohnerregisterId(personId);

                    // Person nicht importieren falls sie im KiSS nicht vorhanden ist.
                    if (baPerson == null)
                    {
                        var result = ServiceResult.Warning("Die Person mit PID '{0}' wurde in KiSS noch nicht importiert.", personId);
                        _serviceProcessErrorService.CreateProcessError(
                            result,
                            GetType().Name,
                            MethodBase.GetCurrentMethod().Name,
                            "Die Person wurde in KiSS noch nicht importiert.",
                            null,
                            null,
                            personId);
                        return result;
                    }

                    baPersonId = baPerson.BaPersonID;

                    // Person nicht importieren falls keine aktive Leistung für diese Person gefunden werden kann
                    var faLeistungListe = unitOfWork.FaLeistung.GetFaLeistungProUserByBaPersonId(baPersonId.Value);
                    if (!faLeistungListe.Any())
                    {
                        var result = ServiceResult.Warning("Die Person mit ID '{0}' hat im KiSS keine aktive Leistung.", baPersonId);
                        _serviceProcessErrorService.CreateProcessError(
                            result,
                            GetType().Name,
                            MethodBase.GetCurrentMethod().Name,
                            "Die Person hat im KiSS keine aktive Leistung.",
                            null,
                            null,
                            personId);
                        return result;
                    }

                    // Person vom Einwohnerregister holen
                    var personDetailResult = _baEinwohnerregisterService.GetPersonDetails(personId);
                    if (!personDetailResult.IsOk)
                    {
                        _serviceProcessErrorService.CreateProcessError(
                            personDetailResult,
                            GetType().Name,
                            MethodBase.GetCurrentMethod().Name,
                            "Fehler beim Webservice-Aufruf",
                            null,
                            baPersonId,
                            personId);

                        // Nur abbrechen, wenn kein Resultat vorhanden ist
                        if (personDetailResult.Result == null)
                        {
                            return personDetailResult;
                        }
                    }

                    // Person importieren
                    //TODO Vergleich vorher/nachher besser und schöner machen
                    IDictionary<string, string> changes;
                    var importResult = _baEinwohnerregisterService.ImportPerson(baPerson, personDetailResult.Result, out changes);
                    if (importResult.IsError)
                    {
                        _serviceProcessErrorService.CreateProcessError(
                            importResult,
                            GetType().Name,
                            MethodBase.GetCurrentMethod().Name,
                            "Fehler beim Import.",
                            null,
                            baPersonId,
                            personId);
                        return importResult;
                    }

                    // Pendenz erstellen
                    var taskDescription = string.Join(Environment.NewLine, ereignisList.GroupBy(x => x.Message).Select(grp => grp.First()).Select(x => x.Message));
                    taskDescription = string.Format("{0}{1}{2}", taskDescription, Environment.NewLine, string.Join(Environment.NewLine, changes.Select(x => x.Value)));
                    if (taskDescription.Length > 2500)
                    {
                        // TaskDescription ist auf der DB VARCHAR(2500)
                        Logger.LogWarning(null, "TaskDescription ist zu lang");
                        Logger.LogMessage(null, "taskDescription = {0}", taskDescription);
                        taskDescription = taskDescription.Substring(0, 2500 - 5) + Environment.NewLine + "...";
                    }

                    // pro User eine Pendenz erstellen
                    foreach (var leistung in faLeistungListe)
                    {
                        var faLeistungId = leistung != null ? (int?)leistung.FaLeistungID : null;
                        var receiverId = leistung != null ? (int?)leistung.UserID : null;

                        var xTask = new XTask
                        {
                            BaPersonID = baPerson.BaPersonID,
                            FaLeistungID = faLeistungId,
                            ReceiverID = receiverId,
                            TaskReceiverCode = (int)LOVsGenerated.TaskReceiver.Person,
                            CreateDate = DateTime.Today,
                            ExpirationDate = ereignisList.Where(x => x.EventDate.HasValue).Max(x => x.EventDate) ?? DateTime.Today,
                            Subject = "Mutationsmeldung aus Omega",
                            TaskStatusCode = (int)LOVsGenerated.TaskStatus.Pendent,
                            TaskSenderCode = (int)LOVsGenerated.TaskSender.Einwohnerregister,
                            TaskTypeCode = (int)LOVsGenerated.TaskType.EinwohnerregisterDatenMeldung,
                            TaskDescription = taskDescription
                        };

                        unitOfWork.XTask.InsertOrUpdateEntity(xTask);
                    }

                    unitOfWork.SaveChanges();

                    importResult.Add(personDetailResult);
                    return importResult;
                }
            }
            catch (Exception ex)
            {
                if (ex is DbEntityValidationException)
                {
                    var dbEx = (DbEntityValidationException)ex;
                    // Retrieve the error messages as a list of strings.
                    var errorMessages = dbEx.EntityValidationErrors
                            .SelectMany(x => x.ValidationErrors)
                            .Select(x => x.ErrorMessage);

                    // Join the list to a single string.
                    var fullErrorMessage = string.Join("; ", errorMessages);

                    // Combine the original exception message with the new one.
                    var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                    // Throw a new DbEntityValidationException with the improved exception message.
                    ex = new DbEntityValidationException(exceptionMessage, dbEx.EntityValidationErrors);
                }

                var result = ServiceResult.Error(ex);
                _serviceProcessErrorService.CreateProcessError(
                    result,
                    GetType().Name,
                    MethodBase.GetCurrentMethod().Name,
                    "Die Person konnte nicht importiert werden",
                    null,
                    baPersonId,
                    personId);
                return result;
            }
        }

        public ServiceResult<BaEinwohnerregisterEmpfangeneEreignisse> ParseRohdatenXml(BaEinwohnerregisterEmpfangeneEreignisseRohdaten rohdaten)
        {
            try
            {
                var result = new BaEinwohnerregisterEmpfangeneEreignisse { BaEinwohnerregisterEmpfangeneEreignisseRohdaten = rohdaten };

                //XNamespace ech0020 = "http://www.ech.ch/xmlns/eCH-0020/2";
                //XNamespace ech0078 = "http://www.ech.ch/xmlns/eCH-0078/2";
                XNamespace ezh0020 = "http://www.zuerich.ch/xmlns/eZH-0020/3";
                XNamespace ech0044 = "http://www.ech.ch/xmlns/eCH-0044/1";
                var eventDoc = System.Xml.Linq.XDocument.Parse(rohdaten.Xml);
                var delivery = eventDoc.Root;

                var deliveryHeader = delivery.Element(ezh0020 + "deliveryHeader");
                ParseDeliveryHeader(result, deliveryHeader);

                var eventElement = delivery.Elements().Skip(1).First();
                ParseEventElement(eventElement, result);

                var eventPersonElement = eventElement.Elements().First();
                var personIdentificationElement = eventPersonElement.Elements().First();

                var personId = personIdentificationElement
                    .Element(ech0044 + "localPersonId")
                    .Element(ech0044 + "personId")
                    .Value;

                result.FremdsystemID = personId;

                using (var unitOfWork = (IKissUnitOfWork)UnitOfWorkFactory.Create())
                {
                    unitOfWork.BaEinwohnerregisterEmpfangeneEreignisse.InsertOrUpdateEntity(result);
                    unitOfWork.SaveChanges();
                }

                return new ServiceResult<BaEinwohnerregisterEmpfangeneEreignisse>(result);
            }
            catch (Exception ex)
            {
                var result = new ServiceResult<BaEinwohnerregisterEmpfangeneEreignisse>(ex);
                _serviceProcessErrorService.CreateProcessError(
                    result,
                    GetType().Name,
                    MethodBase.GetCurrentMethod().Name,
                    string.Format("Rohdaten ID {0} konnten nicht verarbeitet werden.", rohdaten.BaEinwohnerregisterEmpfangeneEreignisseRohdatenID));
                return result;
            }
        }

        public ServiceResult ProcessAndImportEventRohdaten(IList<BaEinwohnerregisterEmpfangeneEreignisseRohdaten> rohdatenList)
        {
            var serviceResult = ServiceResult.Ok();

            // Personen-IDs von allen Meldungen holen und mit den zugehörigen Meldungen in einem Dictionary speichern
            var personIdList = new Dictionary<string, List<BaEinwohnerregisterEmpfangeneEreignisse>>();

            foreach (var rohdaten in rohdatenList)
            {
                var parseXmlResult = ParseRohdatenXml(rohdaten);
                if (parseXmlResult.IsOk)
                {
                    var pid = parseXmlResult.Result.FremdsystemID;
                    if (!personIdList.ContainsKey(pid))
                    {
                        personIdList.Add(pid, new List<BaEinwohnerregisterEmpfangeneEreignisse>());
                    }

                    personIdList[pid].Add(parseXmlResult.Result);
                }
                else
                {
                    SetStatus(LOVsGenerated.BaEinwohnerregisterEmpfangeneEreignisseRohdatenStatus.Ignoriert, rohdaten);
                }

                serviceResult += parseXmlResult;
            }

            // Personen importieren
            foreach (var personIdEreignis in personIdList)
            {
                var importResult = ImportPerson(personIdEreignis.Key, personIdEreignis.Value);

                serviceResult += importResult;

                // Status auf Rohdaten-Einträgen aktualisieren
                var status = LOVsGenerated.BaEinwohnerregisterEmpfangeneEreignisseRohdatenStatus.ImportErfolgreich;
                if (importResult.IsWarning)
                {
                    status = LOVsGenerated.BaEinwohnerregisterEmpfangeneEreignisseRohdatenStatus.Ignoriert;
                }
                else if (importResult.IsError)
                {
                    status = LOVsGenerated.BaEinwohnerregisterEmpfangeneEreignisseRohdatenStatus.ImportFehlerhaft;
                }

                var rohdaten = personIdEreignis.Value.Select(x => x.BaEinwohnerregisterEmpfangeneEreignisseRohdaten).ToArray();
                var statusResult = SetStatus(status, rohdaten);

                serviceResult += statusResult;
            }

            return serviceResult;
        }

        public ServiceResult SetStatus(LOVsGenerated.BaEinwohnerregisterEmpfangeneEreignisseRohdatenStatus status, params BaEinwohnerregisterEmpfangeneEreignisseRohdaten[] rohdatenList)
        {
            try
            {
                using (var unitOfWork = (IKissUnitOfWork)UnitOfWorkFactory.Create())
                {
                    foreach (var rohdaten in rohdatenList)
                    {
                        rohdaten.BaEinwohnerregisterEmpfangeneEreignisseRohdatenStatusCode = (int)status;
                        unitOfWork.BaEinwohnerregisterEmpfangeneEreignisseRohdaten.InsertOrUpdateEntity(rohdaten);
                    }
                    unitOfWork.SaveChanges();
                    return ServiceResult.Ok();
                }
            }
            catch (Exception ex)
            {
                var ids = string.Join(",", rohdatenList.Select(roh => roh.BaEinwohnerregisterEmpfangeneEreignisseRohdatenID));
                var result = ServiceResult.Error(ex);
                _serviceProcessErrorService.CreateProcessError(
                    result,
                    GetType().Name,
                    MethodBase.GetCurrentMethod().Name,
                    string.Format("Der Status der Ereignis-Rohdaten mit ID(s) {0} konnte nicht gesetzt werden.", ids));
                return result;
            }
        }

        private static void ParseDeliveryHeader(BaEinwohnerregisterEmpfangeneEreignisse result, XElement deliveryHeader)
        {
            XNamespace ech0078 = "http://www.ech.ch/xmlns/eCH-0078/2";
            var eventDate = deliveryHeader.Element(ech0078 + "eventDate");
            if (eventDate != null)
            {
                result.EventDate = XmlConvert.ToDateTime(eventDate.Value, XmlDateTimeSerializationMode.Unspecified);
            }

            result.deliveryHeader = deliveryHeader.ToString();
        }

        private FtpWebRequest GetFtpRequest(string url, string method, BaEinwohnerregisterConfigDTO config)
        {
            var ftpRequest = (FtpWebRequest)WebRequest.Create(url);
            ftpRequest.Method = method;
            ftpRequest.Credentials = new NetworkCredential(config.FtpUser, config.FtpPassword);
            ftpRequest.Proxy = null;
            return ftpRequest;
        }

        private void ParseEventElement(XElement eventElement, BaEinwohnerregisterEmpfangeneEreignisse result)
        {
            switch (eventElement.Name.LocalName)
            {
                case "absence":
                    result.absence = eventElement.ToString();
                    result.Message = "Abwesenheit";
                    break;

                case "acknowledgement":
                    result.acknowledgement = eventElement.ToString();
                    result.Message = "Anerkennung";
                    break;

                case "addressLock":
                    result.addressLock = eventElement.ToString();
                    result.Message = "Adresssperre";
                    break;

                case "adoption":
                    result.adoption = eventElement.ToString();
                    result.Message = "Adoption";
                    break;

                case "birth":
                    result.birth = eventElement.ToString();
                    result.Message = "Geburt";
                    break;

                case "care":
                    result.care = eventElement.ToString();
                    result.Message = "Änderung Sorgerecht";
                    break;

                case "changeCitizen":
                    result.changeCitizen = eventElement.ToString();
                    result.Message = "Änderung Bürgerrechte";
                    break;

                case "changeGardian":
                    result.changeGardian = eventElement.ToString();
                    result.Message = "Wechsel kindes- und erwachsenenschutzrechtliche Massnahme";
                    break;

                case "changeName":
                    result.changeName = eventElement.ToString();
                    result.Message = "Namensänderung";
                    break;

                case "changeNationality":
                    result.changeNationality = eventElement.ToString();
                    result.Message = "Wechsel Staatsangehörigkeit";
                    break;

                case "changeNestRegister":
                    result.changeNestRegister = eventElement.ToString();
                    result.Message = "NEST Registerdatenänderung";
                    break;

                case "changeNestTarget":
                    result.changeNestTarget = eventElement.ToString();
                    result.Message = "NEST Solldatenänderung";
                    break;

                case "changeOccupation":
                    result.changeOccupation = eventElement.ToString();
                    result.Message = "Arbeitgeberwechsel / Änderung der beruflichen Tätigkeit";
                    break;

                case "changeOKV":
                    result.changeOKV = eventElement.ToString();
                    result.Message = "OKV Datenänderung";
                    break;

                case "changeReligion":
                    result.changeReligion = eventElement.ToString();
                    result.Message = "Konfessionswechsel";
                    break;

                case "changeResidencePermit":
                    result.changeResidencePermit = eventElement.ToString();
                    result.Message = "Wechsel Ausländerkategorie";
                    break;

                case "changeResidenceType":
                    result.changeResidenceType = eventElement.ToString();
                    result.Message = "Umwandlung Meldeverhältnis";
                    break;

                case "changeSex":
                    result.changeSex = eventElement.ToString();
                    result.Message = "Geschlechtsänderung";
                    break;

                case "childRelationship":
                    result.childRelationship = eventElement.ToString();
                    result.Message = "Kindesverhältnis";
                    break;

                case "contact":
                    result.contact = eventElement.ToString();
                    result.Message = "Zustelladresse";
                    break;

                case "correctAbsence":
                    result.correctAbsence = eventElement.ToString();
                    result.Message = "Korrektur Abwesenheit";
                    break;

                case "correctAdditionalAddresses":
                    result.correctAdditionalAddresses = eventElement.ToString();
                    result.Message = "Korrektur zusätzliche Adressen";
                    break;

                case "correctAddress":
                    result.correctAddress = eventElement.ToString();
                    result.Message = "Korrektur Adressdaten";
                    break;

                case "correctCodes":
                    result.correctCodes = eventElement.ToString();
                    result.Message = "Korrektur Kodierungen";
                    break;

                case "correctContact":
                    result.correctContact = eventElement.ToString();
                    result.Message = "Korrektur Zustelladresse";
                    break;

                case "correctDateOfDeath":
                    result.correctDateOfDeath = eventElement.ToString();
                    result.Message = "Korrektur Todesangaben";
                    break;

                case "correctDateOfNameChange":
                    result.correctDateOfNameChange = eventElement.ToString();
                    result.Message = "Korrektur Rechtskraftsdatum Namensänderung";
                    break;

                case "correctDateOfNaturalization":
                    result.correctDateOfNaturalization = eventElement.ToString();
                    result.Message = "Korrektur Einbürgerungsdatum";
                    break;

                case "correctDMP":
                    result.correctDMP = eventElement.ToString();
                    result.Message = "Korrektur Drittmeldepflichtdaten";
                    break;

                case "correctIdentification":
                    result.correctIdentification = eventElement.ToString();
                    result.Message = "Korrektur Identifikatoren";
                    break;

                case "correctLanguageOfCorrespondance":
                    result.correctLanguageOfCorrespondance = eventElement.ToString();
                    result.Message = "Korrektur Korrespondenzsprache";
                    break;

                case "correctLiabilities":
                    result.correctLiabilities = eventElement.ToString();
                    result.Message = "Korrektur Pflichten";
                    break;

                case "correctMaritalData":
                    result.correctMaritalData = eventElement.ToString();
                    result.Message = "Korrektur Zivilstandinformationen";
                    break;

                case "correctName":
                    result.correctName = eventElement.ToString();
                    result.Message = "Korrektur Namensinformationen";
                    break;

                case "correctNationality":
                    result.correctNationality = eventElement.ToString();
                    result.Message = "Korrektur Staatsangehörigkeit";
                    break;

                case "correctOccupation":
                    result.correctOccupation = eventElement.ToString();
                    result.Message = "Korrektur Berufsdaten";
                    break;

                case "correctOrigin":
                    result.correctOrigin = eventElement.ToString();
                    result.Message = "Korrektur Bürgerrecht";
                    break;

                case "correctPerson":
                    result.correctPerson = eventElement.ToString();
                    result.Message = "Korrektur Person";
                    break;

                case "correctPlaceOfBirth":
                    result.correctPlaceOfBirth = eventElement.ToString();
                    result.Message = "Korrektur Geburtsort";
                    break;

                case "correctRelationship":
                    result.correctRelationship = eventElement.ToString();
                    result.Message = "Korrektur Beziehungsdaten";
                    break;

                case "correctReligion":
                    result.correctReligion = eventElement.ToString();
                    result.Message = "Korrektur Konfession";
                    break;

                case "correctReporting":
                    result.correctReporting = eventElement.ToString();
                    result.Message = "Korrektur Meldeverhältnis";
                    break;

                case "correctResidencePermit":
                    result.correctResidencePermit = eventElement.ToString();
                    result.Message = "Korrektur Ausländerkategorie";
                    break;

                case "dataRequest":
                    result.dataRequest = eventElement.ToString();
                    //result.Message = "";
                    break;

                case "death":
                    result.death = eventElement.ToString();
                    result.Message = "Tod";
                    break;

                case "deletePerson":
                    result.deletePerson = eventElement.ToString();
                    result.Message = "Person gelöscht";
                    break;

                case "divorce":
                    result.divorce = eventElement.ToString();
                    result.Message = "Scheidung";
                    break;

                case "gardianMeasure":
                    result.gardianMeasure = eventElement.ToString();
                    result.Message = "Kindes- und erwachsenenschutzrechtliche Massnahme";
                    break;

                case "maritalStatusPartner":
                    result.maritalStatusPartner = eventElement.ToString();
                    result.Message = "Zivilstandsänderung Partner/in";
                    break;

                case "marriage":
                    result.marriage = eventElement.ToString();
                    result.Message = "Eheschliessung";
                    break;

                case "missing":
                    result.missing = eventElement.ToString();
                    result.Message = "Verschollen";
                    break;

                case "move":
                    result.move = eventElement.ToString();
                    result.Message = "Umzug (innerhalb Gemeinde)";
                    break;

                case "moveIn":
                    result.moveIn = eventElement.ToString();
                    result.Message = "Zuzug";
                    break;

                case "moveOut":
                    result.moveOut = eventElement.ToString();
                    result.Message = "Wegzug";
                    break;

                case "naturalizeForeigner":
                    result.naturalizeForeigner = eventElement.ToString();
                    result.Message = "Einbürgerung Ausländer";
                    break;

                case "naturalizeSwiss":
                    result.naturalizeSwiss = eventElement.ToString();
                    result.Message = "Einbürgerung Schweizer in Gemeinde";
                    break;

                case "paperLock":
                    result.paperLock = eventElement.ToString();
                    result.Message = "Änderung Schriftensperre";
                    break;

                case "partnership":
                    result.partnership = eventElement.ToString();
                    result.Message = "Eintragung Partnerschaft";
                    break;

                case "renewPermit":
                    result.renewPermit = eventElement.ToString();
                    result.Message = "Antrag Verlängerung Ausländerbewilligung";
                    break;

                case "replacePerson":
                    result.replacePerson = eventElement.ToString();
                    result.Message = "Person ersetzt";
                    break;

                case "separation":
                    result.separation = eventElement.ToString();
                    result.Message = "Trennung";
                    break;

                case "undoAbsence":
                    result.undoAbsence = eventElement.ToString();
                    result.Message = "Abwesenheit beenden";
                    break;

                case "undoCitizen":
                    result.undoCitizen = eventElement.ToString();
                    result.Message = "Bürgerrechtsentlassung aus Gemeinde";
                    break;

                case "undoGardian":
                    result.undoGardian = eventElement.ToString();
                    result.Message = "Aufhebung kindes- und erwachenenschutzrechtliche Massnahme";
                    break;

                case "undoMarriage":
                    result.undoMarriage = eventElement.ToString();
                    result.Message = "Ungültigerklärung Ehe";
                    break;

                case "undoMissing":
                    result.undoMissing = eventElement.ToString();
                    result.Message = "Aufhebung Verschollenerklärung";
                    break;

                case "undoPartnership":
                    result.undoPartnership = eventElement.ToString();
                    result.Message = "Auflösung Partnerschaft";
                    break;

                case "undoSeparation":
                    result.undoSeparation = eventElement.ToString();
                    result.Message = "Aufhebung Trennung";
                    break;

                case "undoSwiss":
                    result.undoSwiss = eventElement.ToString();
                    result.Message = "Aberkennung Schweizer Bürgerrecht";
                    break;

                // baseDelivery, keyDelivery werden nicht behandelt
            }
        }
    }
}