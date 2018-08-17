using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using Kiss.BusinessLogic.EinwohnerregisterService;
using Kiss.BusinessLogic.Helper;
using Kiss.BusinessLogic.LocalResources.Sst;
using Kiss.BusinessLogic.Log;
using Kiss.BusinessLogic.Sys;
using Kiss.BusinessLogic.Sys.NodeEnumeration;
using Kiss.DataAccess.Interfaces;
using Kiss.DbContext;
using Kiss.DbContext.DTO.Ba;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using log4net;

namespace Kiss.BusinessLogic.Ba
{
    public class BaEinwohnerregisterService : Service
    {
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly ServiceProcessErrorService _serviceProcessErrorService = Container.Resolve<ServiceProcessErrorService>();

        private readonly ISessionService _sessionService = Container.Resolve<ISessionService>();

        public BaEinwohnerregisterConfigDTO GetConfigDTO()
        {
            var configService = Container.Resolve<XConfigService>();

            var kissWebserviceUrl = configService.GetConfigValue(ConfigNodes.System_Schnittstellen_Einwohnerregister_KissWebserviceUrl);
            var kissValidateCertificate = configService.GetConfigValue(ConfigNodes.System_Schnittstellen_Einwohnerregister_KissWebserviceValidateCertificate);
            var kissWebserviceProxy = configService.GetConfigValue(ConfigNodes.System_Schnittstellen_Einwohnerregister_KissWebserviceProxy);
            var webservicesProxy = configService.GetConfigValue(ConfigNodes.System_Schnittstellen_Einwohnerregister_EinwohnerregisterWebservicesProxy);
            var webservicesUsername = configService.GetConfigValue(ConfigNodes.System_Schnittstellen_Einwohnerregister_EinwohnerregisterWebservicesUsername);
            var webservicesPassword = configService.GetConfigValue(ConfigNodes.System_Schnittstellen_Einwohnerregister_EinwohnerregisterWebservicesPassword);
            var adresseHistWebserviceUrl = configService.GetConfigValue(ConfigNodes.System_Schnittstellen_Einwohnerregister_AdresseHistWebserviceUrl);
            var anfrageWebserviceUrl = configService.GetConfigValue(ConfigNodes.System_Schnittstellen_Einwohnerregister_AnfrageWebserviceUrl);
            var deRegistWebserviceUrl = configService.GetConfigValue(ConfigNodes.System_Schnittstellen_Einwohnerregister_DeRegistWebserviceUrl);
            var registWebserviceUrl = configService.GetConfigValue(ConfigNodes.System_Schnittstellen_Einwohnerregister_RegistWebserviceUrl);
            var sucheWebserviceUrl = configService.GetConfigValue(ConfigNodes.System_Schnittstellen_Einwohnerregister_SucheWebserviceUrl);
            var ftpUrl = configService.GetConfigValue(ConfigNodes.System_Schnittstellen_Omega_FtpUrl);
            var ftpUser = configService.GetConfigValue(ConfigNodes.System_Schnittstellen_Omega_FtpUser);
            var ftpPassword = configService.GetConfigValue(ConfigNodes.System_Schnittstellen_Omega_FtpPassword);
            var deleteEventFiles = configService.GetConfigValue(ConfigNodes.System_Schnittstellen_Omega_DeleteEventFiles);

            return new BaEinwohnerregisterConfigDTO
            {
                AdresseHistWebserviceUrl = adresseHistWebserviceUrl,
                AnfrageWebserviceUrl = anfrageWebserviceUrl,
                DeRegistWebserviceUrl = deRegistWebserviceUrl,
                EinwohnerregisterWebservicesPassword = webservicesPassword,
                EinwohnerregisterWebservicesProxy = webservicesProxy,
                EinwohnerregisterWebservicesUsername = webservicesUsername,
                KissWebserviceProxy = kissWebserviceProxy,
                KissWebserviceUrl = kissWebserviceUrl,
                RegistWebserviceUrl = registWebserviceUrl,
                SucheWebserviceUrl = sucheWebserviceUrl,
                ValidateCertificate = kissValidateCertificate,
                FtpUrl = ftpUrl,
                FtpUser = ftpUser,
                FtpPassword = ftpPassword,
                DeleteEventFiles = deleteEventFiles
            };
        }

        public IServiceResult<BaEinwohnerregisterPersonAnfrageDTO> GetPersonDetails(string pid)
        {
            try
            {
                var configDto = GetConfigDTO();
                var validationResult = ValidateConfigValues(configDto);

                if (!validationResult.IsOk)
                {
                    return new ServiceResult<BaEinwohnerregisterPersonAnfrageDTO>(validationResult);
                }

                var sessionService = Container.Resolve<ISessionService>();

                var client = GetWebserviceClient(configDto);
                var serviceResult = client.GetPersonDetails(
                    sessionService.DatabaseName,
                    pid,
                    sessionService.AuthenticatedUser.UserID,
                    Environment.MachineName);
                client.Close();

                return serviceResult;
            }
            catch (Exception ex)
            {
                return new ServiceResult<BaEinwohnerregisterPersonAnfrageDTO>(ex);
            }
        }

        public IServiceResult<List<BaEinwohnerregisterPersonStatusDTO>> GetStatusDTOList()
        {
            try
            {
                using (var unitOfWork = (IKissUnitOfWork)CreateNewUnitOfWork())
                {
                    var list = unitOfWork.BaEinwohnerregisterPersonStatus.GetStatusDTOList();
                    return new ServiceResult<List<BaEinwohnerregisterPersonStatusDTO>>(list);
                }
            }
            catch (Exception ex)
            {
                return ServiceResult<List<BaEinwohnerregisterPersonStatusDTO>>.Error(ex);
            }
        }

        public IServiceResult<BaPerson> ImportPerson(BaPerson baPerson, BaEinwohnerregisterPersonAnfrageDTO personDto, out IDictionary<string, string> changes)
        {
            _log.DebugFormat("start ImportPerson");
            var changeHelper = new ChangesHelper();
            changes = changeHelper.Changes;
            var importProcessError = ServiceResult.Ok();

            try
            {
                using (var unitOfWork = (IKissUnitOfWork)CreateNewUnitOfWork())
                {
                    baPerson.EinwohnerregisterID = PreparePid(personDto.PID);
                    // HACK: PID als Zahl in ZIPNr speichern damit die Schnittstellen ohne Anpassungen weiterhin funktionieren (KIS, VIS, DWH, ...)
                    int zipNr;
                    var parsed = Int32.TryParse(personDto.PID.TrimStart('0'), out zipNr);
                    if (parsed)
                    {
                        baPerson.ZIPNr = zipNr;
                    }
                    else
                    {
                        importProcessError += ServiceResult.Error("Die PID konnte nicht als int umgewandelt werden (PID = {0}).", personDto.PID);
                    }

                    changeHelper.SetPropertyAndGetChanges(baPerson, p => p.PersonOhneLeistung, false, "Person ohne finanzielle Leistung");
                    changeHelper.SetPropertyAndGetChanges(baPerson, p => p.EinwohnerregisterAktiv, personDto.IsActive, "aktiv");

                    changeHelper.SetPropertyAndGetChanges(baPerson, p => p.Name, personDto.Name, "Name");
                    changeHelper.SetPropertyAndGetChanges(baPerson, p => p.Vorname, personDto.Vorname, "Vorname");
                    baPerson.Vorname2 = personDto.Rufname; // TODO ev. auch AndererName?
                    changeHelper.SetPropertyAndGetChanges(baPerson, p => p.AHVNummer, personDto.AHVNr, "AHVNr");
                    if (!string.IsNullOrEmpty(personDto.Versichertennummer))
                    {
                        changeHelper.SetPropertyAndGetChanges(baPerson, p => p.Versichertennummer, personDto.Versichertennummer, "Vers.-Nr");
                    }

                    changeHelper.SetPropertyAndGetChanges(baPerson, p => p.Geburtsdatum, personDto.Geburtsdatum, "Geburtsdatum");
                    changeHelper.SetPropertyAndGetChanges(baPerson, p => p.Sterbedatum, personDto.Todesdatum, "Todesdatum");
                    changeHelper.SetPropertyAndGetChangesTextFromLov(baPerson, p => p.GeschlechtCode, personDto.GeschlechtCode, "Geschlecht", "BaGeschlecht");
                    changeHelper.SetPropertyAndGetChangesTextFromLand(baPerson, p => p.NationalitaetCode, unitOfWork.BaLand.GetBaLandIdByIso2Code(personDto.NationLandIso2), "Nationalität");
                    changeHelper.SetPropertyAndGetChangesTextFromLov(baPerson, p => p.ZivilstandCode, personDto.ZivilstandCode, "Zivilstand", "BaZivilstand");
                    changeHelper.SetPropertyAndGetChanges(baPerson, p => p.ZivilstandDatum, personDto.ZivilstandDatum, "Zivilstanddatum");

                    if (!string.IsNullOrEmpty(personDto.ZEMISNr))
                    {
                        changeHelper.SetPropertyAndGetChanges(baPerson, p => p.ZEMISNummer, personDto.ZEMISNr, "ZEMIS-Nr");
                    }

                    if (!string.IsNullOrEmpty(personDto.ZARNr))
                    {
                        changeHelper.SetPropertyAndGetChanges(baPerson, p => p.ZARNummer, personDto.ZARNr, "ZAR-Nr");
                    }

                    if (!string.IsNullOrEmpty(personDto.ZhNr))
                    {
                        changeHelper.SetPropertyAndGetChanges(baPerson, p => p.KantonaleReferenznummer, personDto.ZhNr, "ZH-Nr");
                    }

                    // validate person
                    if (string.IsNullOrEmpty(personDto.Name))
                    {
                        importProcessError += ServiceResult.Error("Der Name aus dem Einwohnerregister ist leer.");
                    }

                    if (!string.IsNullOrEmpty(personDto.NationLandIso2) && !baPerson.NationalitaetCode.HasValue)
                    {
                        importProcessError += ServiceResult.Error("NationLandIso2 = {0} kann im KiSS (Tabelle BaLand.Iso2Code) nicht gefunden werden.", personDto.NationLandIso2);
                    }

                    // Zuzug
                    changeHelper.SetPropertyAndGetChanges(baPerson, p => p.ZuzugGdeDatum, personDto.ZuzugDatum, "Zuzugsdatum");
                    var zuzugBaGemeindeId = personDto.ZuzugOrtCode.HasValue
                            ? unitOfWork.BaGemeinde.GetBaGemeindeIdByBfsCode(personDto.ZuzugOrtCode.Value)
                            : null;
                    changeHelper.SetPropertyAndGetChangesTextFromGemeinde(baPerson, p => p.ZuzugGdeOrtCode, zuzugBaGemeindeId, "Zuzugsgemeinde");
                    var zuzugGdeKantonOld = baPerson.ZuzugGdeKanton;
                    changeHelper.SetPropertyAndGetChanges(baPerson, p => p.ZuzugGdeKanton, personDto.ZuzugKanton, "Zuzugskanton");
                    changeHelper.SetPropertyAndGetChangesTextFromLand(baPerson, p => p.ZuzugGdeLandCode, unitOfWork.BaLand.GetBaLandIdByIso2Code(personDto.ZuzugLandIso2), "Zuzugsland");
                    changeHelper.SetPropertyAndGetChanges(baPerson, p => p.ZuzugGdeOrt, personDto.ZuzugOrt, "Zuzugsort");
                    changeHelper.SetPropertyAndGetChanges(baPerson, p => p.ZuzugGdePLZ, personDto.ZuzugPlz, "Zuzug-PLZ");
                    if (string.IsNullOrEmpty(baPerson.ZuzugGdeKanton) && zuzugBaGemeindeId.HasValue)
                    {
                        baPerson.ZuzugGdeKanton = zuzugGdeKantonOld;
                        changeHelper.SetPropertyAndGetChanges(baPerson, p => p.ZuzugGdeKanton, unitOfWork.BaGemeinde.GetById(zuzugBaGemeindeId).Kanton, "Zuzugskanton");
                    }

                    if (personDto.ZuzugOrtCode.HasValue && !zuzugBaGemeindeId.HasValue)
                    {
                        importProcessError += ServiceResult.Error("ZuzugOrtCode = {0} der Adresse kann im KiSS (Tabelle BaGemeinde.BFSCode) nicht gefunden werden.", personDto.ZuzugOrtCode);
                    }

                    // Wegzug
                    changeHelper.SetPropertyAndGetChanges(baPerson, p => p.WegzugDatum, personDto.WegzugDatum, "Wegzugsdatum");
                    var wegzugBaGemeindeId = personDto.WegzugOrtCode.HasValue
                            ? unitOfWork.BaGemeinde.GetBaGemeindeIdByBfsCode(personDto.WegzugOrtCode.Value)
                            : null;
                    changeHelper.SetPropertyAndGetChangesTextFromGemeinde(baPerson, p => p.WegzugOrtCode, wegzugBaGemeindeId, "Wegzugsgemeinde");
                    changeHelper.SetPropertyAndGetChanges(baPerson, p => p.WegzugOrt, personDto.WegzugOrt, "Wegzugsort");
                    changeHelper.SetPropertyAndGetChanges(baPerson, p => p.WegzugPLZ, personDto.WegzugPlz, "Wegzug-PLZ");
                    changeHelper.SetPropertyAndGetChangesTextFromLand(baPerson, p => p.WegzugLandCode, unitOfWork.BaLand.GetBaLandIdByIso2Code(personDto.WegzugLandIso2), "Wegzugsland");
                    var wegzugKantonOld = baPerson.WegzugKanton;
                    changeHelper.SetPropertyAndGetChanges(baPerson, p => p.WegzugKanton, personDto.WegzugKanton, "Wegzugskanton");
                    if (string.IsNullOrEmpty(baPerson.WegzugKanton) && wegzugBaGemeindeId.HasValue)
                    {
                        baPerson.WegzugKanton = wegzugKantonOld;
                        changeHelper.SetPropertyAndGetChanges(baPerson, p => p.WegzugKanton, unitOfWork.BaGemeinde.GetById(wegzugBaGemeindeId).Kanton, "Wegzugskanton");
                    }

                    if (personDto.WegzugOrtCode.HasValue && !wegzugBaGemeindeId.HasValue)
                    {
                        importProcessError += ServiceResult.Error("WegzugOrtCode = {0} der Adresse kann im KiSS (Tabelle BaGemeinde.BFSCode) nicht gefunden werden.", personDto.ZuzugOrtCode);
                    }

                    // Heimatgemeinde
                    if (personDto.Heimatorte != null && personDto.Heimatorte.Any())
                    {
                        var baGemeindeIdsHeimatort = new List<int>();
                        foreach (var heimatort in personDto.Heimatorte)
                        {
                            int? baGemeindeID;
                            if (heimatort.BfsCode.HasValue)
                            {
                                baGemeindeID = unitOfWork.BaGemeinde.GetBaGemeindeIdByBfsCode(heimatort.BfsCode.Value);
                            }
                            else
                            {
                                baGemeindeID = unitOfWork.BaGemeinde.GetBaGemeindeIdByKantonAndName(heimatort.Kanton, heimatort.Heimatort);
                            }

                            if (baGemeindeID.HasValue)
                            {
                                baGemeindeIdsHeimatort.Add(baGemeindeID.Value);
                            }
                            else
                            {
                                // validieren
                                if (heimatort.BfsCode.HasValue)
                                {
                                    importProcessError += ServiceResult.Error("BfsCode = {0} der Heimatgemeinde kann im KiSS (Tabelle BaGemeinde.BFSCode) nicht gefunden werden.", heimatort.BfsCode);
                                }
                                else
                                {
                                    importProcessError += ServiceResult.Error("Kanton = {0} und Heimatort = {1} der Heimatgemeinde kann im KiSS (Tabelle BaGemeinde.Kanton und Name) nicht gefunden werden.", heimatort.Kanton, heimatort.Heimatort);
                                }
                            }
                        }

                        if (baGemeindeIdsHeimatort.Any())
                        {
                            changeHelper.SetPropertyAndGetChangesTextFromGemeindeHeimatort(baPerson, p => p.HeimatgemeindeCodes, string.Join(",", baGemeindeIdsHeimatort), "Heimatorte");

                            if (!baPerson.HeimatgemeindeCode.HasValue || !baGemeindeIdsHeimatort.Contains(baPerson.HeimatgemeindeCode.Value))
                            {
                                baPerson.HeimatgemeindeCode = baGemeindeIdsHeimatort.First();
                            }
                        }
                        else
                        {
                            changeHelper.SetPropertyAndGetChanges(baPerson, p => p.HeimatgemeindeCodes, null, "Heimatorte");
                            baPerson.HeimatgemeindeCode = null;
                        }
                    }

                    // AusländerStatus
                    if (personDto.AuslaenderStatusCode.HasValue)
                    {
                        changeHelper.SetPropertyAndGetChangesTextFromLov(baPerson, p => p.AuslaenderStatusCode, personDto.AuslaenderStatusCode, "Ausländerstatus", "BaAufenthaltsstatus");
                    }

                    if (personDto.AuslaenderStatusGueltigBis.HasValue)
                    {
                        changeHelper.SetPropertyAndGetChanges(baPerson, p => p.AuslaenderStatusGueltigBis, personDto.AuslaenderStatusGueltigBis, "Ausländerstatus bis");
                    }

                    // PersonSichtbarSDFlag = 1 setzen
                    baPerson.PersonSichtbarSDFlag = true;

                    // Insert or update person in KiSS
                    unitOfWork.BaPerson.InsertOrUpdateEntity(baPerson);

                    importProcessError += ImportPersonKrankenkassen(unitOfWork, baPerson.BaPersonID, personDto, changeHelper);

                    if (personDto.Adressen != null && personDto.Adressen.Length > 0)
                    {
                        // Adressen löschen
                        var adressen = unitOfWork.BaAdresse.GetByBaPersonId(baPerson.BaPersonID, true);
                        foreach (var baAdresse in adressen)
                        {
                            unitOfWork.BaAdresse.Remove(baAdresse);
                        }

                        // Adressen einfügen
                        foreach (var adresseDto in personDto.Adressen)
                        {
                            var baGemeindeId = adresseDto.OrtCode.HasValue
                                ? unitOfWork.BaGemeinde.GetBaGemeindeIdByBfsCode(adresseDto.OrtCode.Value)
                                : null;
                            var baLandId = unitOfWork.BaLand.GetBaLandIdByIso2Code(adresseDto.Land);

                            var baAdresse = new BaAdresse
                            {
                                BaPerson = baPerson,
                                DatumVon = adresseDto.DatumVon,
                                DatumBis = adresseDto.DatumBis,
                                AdresseCode = adresseDto.AdresseCode,
                                Zusatz = adresseDto.Zusatz,
                                Strasse = adresseDto.Strasse,
                                HausNr = adresseDto.HausNr,
                                Postfach = adresseDto.Postfach,
                                PostfachOhneNr = adresseDto.PostfachOhneNr,
                                PLZ = adresseDto.Plz,
                                Ort = adresseDto.Ort,
                                OrtschaftCode = baGemeindeId, // TODO BaPLZID, BaGemeindeID oder BFSCode?
                                Kanton = adresseDto.Kanton,
                                AusEinwohnerregister = true,
                                BaLandID = baLandId,
                                Gesperrt = adresseDto.Gesperrt,
                                StrasseCode = adresseDto.StrasseCode,
                                // TODO QuartierCode
                            };

                            // validate address
                            if (adresseDto.OrtCode.HasValue && !baGemeindeId.HasValue)
                            {
                                importProcessError +=
                                    ServiceResult.Error(
                                        "OrtCode = {0} der Adresse kann im KiSS (Tabelle BaGemeinde.BFSCode) nicht gefunden werden.",
                                        adresseDto.OrtCode);
                            }

                            if (!string.IsNullOrEmpty(adresseDto.Land) && !baLandId.HasValue)
                            {
                                importProcessError +=
                                    ServiceResult.Error(
                                        "Land = {0} der Adresse kann im KiSS (Tabelle BaLand.Iso2Code) nicht gefunden werden.",
                                        adresseDto.Land);
                            }

                            // Insert or update address in KiSS
                            unitOfWork.BaAdresse.InsertOrUpdateEntity(baAdresse);
                        }
                    }
                    else
                    {
                        importProcessError += ServiceResult.Error("Die Adressen konnten nicht geladen werden.");
                    }

                    if (!importProcessError.IsOk)
                    {
                        _serviceProcessErrorService.CreateProcessError(
                            importProcessError,
                            GetType().Name,
                            MethodBase.GetCurrentMethod().Name,
                            "Fehler beim Importieren der Person aus dem Einwohnerregister",
                            _sessionService.AuthenticatedUser.UserID,
                            baPerson.BaPersonID,
                            personDto.PID);
                    }

                    unitOfWork.SaveChanges();

                    return new ServiceResult<BaPerson>(baPerson);
                }
            }
            catch (DbEntityValidationException ex)
            {
                _log.Debug("Fehler beim Import einer Person", ex);
                return GetServiceResultForDbEntityValidationException(ex);
            }
            catch (Exception ex)
            {
                _log.Debug("Fehler beim Import einer Person", ex);
                return ServiceResult<BaPerson>.Error(ex);
            }
        }

        public IServiceResult ImportPersonKrankenkasse(int baPersonId, BaEinwohnerregisterPersonAnfrageDTO personDto, out IDictionary<string, string> changes)
        {
            _log.DebugFormat("start ImportPersonKrankenkasse");
            var changeHelper = new ChangesHelper();
            changes = changeHelper.Changes;
            var importProcessError = ServiceResult.Ok();

            try
            {
                using (var unitOfWork = (IKissUnitOfWork)CreateNewUnitOfWork())
                {
                    importProcessError += ImportPersonKrankenkassen(unitOfWork, baPersonId, personDto, changeHelper);

                    if (!importProcessError.IsOk)
                    {
                        _serviceProcessErrorService.CreateProcessError(
                            importProcessError,
                            GetType().Name,
                            MethodBase.GetCurrentMethod().Name,
                            "Fehler beim Importieren den Krankenkassen einer Person aus dem Einwohnerregister",
                            _sessionService.AuthenticatedUser.UserID,
                            baPersonId,
                            personDto.PID);
                    }

                    unitOfWork.SaveChanges();

                    return ServiceResult.Ok();
                }
            }
            catch (DbEntityValidationException ex)
            {
                _log.Debug("Fehler beim Import den Krankenkassen", ex);
                return GetServiceResultForDbEntityValidationException(ex);
            }
            catch (Exception ex)
            {
                _log.Debug("Fehler beim Import den Krankenkassen", ex);
                return ServiceResult<BaPerson>.Error(ex);
            }
        }

        public IServiceResult<BaEinwohnerregisterPersonResultDTO[]> PersonSuchen(BaEinwohnerregisterPersonSucheDTO personSucheDto)
        {
            try
            {
                var configDto = GetConfigDTO();
                var validationResult = ValidateConfigValues(configDto);

                if (!validationResult.IsOk)
                {
                    return new ServiceResult<BaEinwohnerregisterPersonResultDTO[]>(validationResult);
                }

                var sessionService = Container.Resolve<ISessionService>();

                var client = GetWebserviceClient(configDto);
                var result = client.PersonSuchen(
                    sessionService.DatabaseName,
                    personSucheDto,
                    sessionService.AuthenticatedUser.UserID,
                    Environment.MachineName);
                client.Close();

                return result;
            }
            catch (Exception ex)
            {
                return new ServiceResult<BaEinwohnerregisterPersonResultDTO[]>(ex);
            }
        }

        public string PreparePid(string pid)
        {
            return string.IsNullOrWhiteSpace(pid) ? null : pid.PadLeft(10, '0');
        }

        /// <summary>
        /// Löscht die Person aus der Status-Tabelle und erstellt einen Log-Eintrag.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public IServiceResult ProcessPersonAbmeldung(BaEinwohnerregisterPersonStatusDTO dto)
        {
            using (var unitOfWork = (IKissUnitOfWork)CreateNewUnitOfWork())
            {
                try
                {
                    var status = unitOfWork.BaEinwohnerregisterPersonStatus.GetByBaPersonId(dto.BaPersonId);
                    if (status != null)
                    {
                        unitOfWork.BaEinwohnerregisterPersonStatus.Remove(status);
                    }

                    var abmeldung = new BaEinwohnerregisterPersonAnAbmeldung
                    {
                        BaPersonID = dto.BaPersonId,
                        Datum = DateTime.Now,
                        FremdsystemID = dto.EinwohnerregisterId,
                        Status = 2 // Abmeldung
                    };
                    unitOfWork.BaEinwohnerregisterPersonAnAbmeldung.InsertOrUpdateEntity(abmeldung);
                    unitOfWork.SaveChanges();

                    return ServiceResult.Ok();
                }
                catch (Exception ex)
                {
                    _serviceProcessErrorService.CreateProcessError(
                        ServiceResult.Error("Die Person konnte nicht abgemeldet werden: {0}", ex.Message),
                        GetType().Name,
                        MethodBase.GetCurrentMethod().Name,
                        "Fehler beim Abmelden einer Person",
                        _sessionService.AuthenticatedUser.UserID,
                        dto.BaPersonId,
                        dto.EinwohnerregisterId);

                    return ServiceResult.Error(ex);
                }
            }
        }

        /// <summary>
        /// Erstellt einen Status- und Logeintrag für die Person.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public IServiceResult ProcessPersonAnmeldung(BaEinwohnerregisterPersonStatusDTO dto)
        {
            using (var unitOfWork = (IKissUnitOfWork)CreateNewUnitOfWork())
            {
                try
                {
                    var status = unitOfWork.BaEinwohnerregisterPersonStatus.GetByBaPersonId(dto.BaPersonId);

                    if (status == null)
                    {
                        status = new BaEinwohnerregisterPersonStatus
                        {
                            BaPersonID = dto.BaPersonId
                        };
                        unitOfWork.BaEinwohnerregisterPersonStatus.InsertOrUpdateEntity(status);

                        var anmeldung = new BaEinwohnerregisterPersonAnAbmeldung
                        {
                            BaPersonID = dto.BaPersonId,
                            Datum = DateTime.Now,
                            FremdsystemID = dto.EinwohnerregisterId,
                            Status = 1 // Anmeldung
                        };
                        unitOfWork.BaEinwohnerregisterPersonAnAbmeldung.InsertOrUpdateEntity(anmeldung);
                        unitOfWork.SaveChanges();
                    }

                    return ServiceResult.Ok();
                }
                catch (Exception ex)
                {
                    _serviceProcessErrorService.CreateProcessError(
                        ServiceResult.Error("Die Person konnte nicht angemeldet werden: {0}", ex.Message),
                        GetType().Name,
                        MethodBase.GetCurrentMethod().Name,
                        "Fehler beim Anmelden einer Person",
                        _sessionService.AuthenticatedUser.UserID,
                        dto.BaPersonId,
                        dto.EinwohnerregisterId);

                    return ServiceResult.Error(ex);
                }
            }
        }

        public IServiceResult ValidateAndGetImportPerson(string einwohnerregisterId, bool neueEinwohnerregisterId, int? baPersonId, out BaPerson baPerson, out BaEinwohnerregisterPersonAnfrageDTO personDto)
        {
            baPerson = null;
            personDto = null;

            einwohnerregisterId = PreparePid(einwohnerregisterId);

            using (var unitOfWork = (IKissUnitOfWork)CreateNewUnitOfWork())
            {
                var person = unitOfWork.BaPerson.GetByEinwohnerregisterId(einwohnerregisterId);

                if (person != null && neueEinwohnerregisterId)
                {
                    var result = ServiceResult.Warning("PID-Nummer {0} bereits bei Person {1} ({2}) vorhanden. Omega-Daten können nicht importiert werden. Bitte wenden Sie sich zwecks Datenbereingiung an den Servicedesk.", einwohnerregisterId, person.LastNameFirstName, person.BaPersonID);
                    _serviceProcessErrorService.CreateProcessError(
                    result,
                    GetType().Name,
                    MethodBase.GetCurrentMethod().Name,
                    "Die Person ist bereits im KiSS vorhanden",
                    _sessionService.AuthenticatedUser.UserID,
                    baPersonId,
                    einwohnerregisterId);
                    return result;
                }
            }

            var serviceResult = GetPersonDetails(einwohnerregisterId);
            personDto = serviceResult.Result;

            // Import auch durchführen, wenn ein Fehler aufgetreten ist (sofern ein Result vorhanden ist)
            if (personDto == null && !serviceResult.IsOk)
            {
                return serviceResult;
            }

            if (personDto == null)
            {
                var result = ServiceResult.Error("Die Person mit der Einwohnerregister-ID {0} wurde im Einwohnerregister nicht gefunden.", einwohnerregisterId);
                _serviceProcessErrorService.CreateProcessError(
                    result,
                    GetType().Name,
                    MethodBase.GetCurrentMethod().Name,
                    "Die Person ist im im Einwohnerregister nicht vorhanden",
                    _sessionService.AuthenticatedUser.UserID,
                    baPersonId,
                    einwohnerregisterId);
                return result;
            }

            using (var unitOfWork = (IKissUnitOfWork)CreateNewUnitOfWork())
            {
                if (baPersonId.HasValue)
                {
                    baPerson = unitOfWork.BaPerson.GetById(baPersonId.Value);

                    // Daten vergleichen
                    var gleicherName = Equals(baPerson.Name, personDto.Name);
                    var gleicherVorname = Equals(baPerson.Vorname, personDto.Vorname);
                    var gleichesGeburtsdatum = Equals(baPerson.Geburtsdatum, personDto.Geburtsdatum);

                    if (neueEinwohnerregisterId && (!gleicherName || !gleicherVorname || !gleichesGeburtsdatum))
                    {
                        var question = "Folgende Felder stimmen nicht überein:";

                        if (!gleicherName)
                        {
                            question += string.Format("{0} Name (KiSS: {1}, Einwohnerregister: {2})", Environment.NewLine, baPerson.Name, personDto.Name);
                        }
                        if (!gleicherVorname)
                        {
                            question += string.Format("{0} Vorname (KiSS: {1}, Einwohnerregister: {2})", Environment.NewLine, baPerson.Vorname, personDto.Vorname);
                        }
                        if (!gleichesGeburtsdatum)
                        {
                            question += string.Format("{0} Geburtsdatum (KiSS: {1:d}, Einwohnerregister: {2:d})", Environment.NewLine, baPerson.Geburtsdatum, personDto.Geburtsdatum);
                        }

                        question += Environment.NewLine + "Fortfahren?";
                        return new ServiceResult(ServiceResultType.Question, question);
                    }
                }
                else
                {
                    baPerson = new BaPerson();
                }
            }

            return serviceResult;
        }

        private static ServiceResult<BaPerson> GetServiceResultForDbEntityValidationException(DbEntityValidationException ex)
        {
            var serviceResult = ServiceResult<BaPerson>.Error(ex);
            foreach (var validationError in ex.EntityValidationErrors)
            {
                var error = string.Format(
                    "Die Entität vom Typ \"{0}\" mit Status \"{1}\" hat folgende Validierungsfehler:",
                    validationError.Entry.Entity.GetType().Name,
                    validationError.Entry.State);

                error = validationError.ValidationErrors.Aggregate(error, (current, ve) => current + string.Format("{0}- {1}", Environment.NewLine, ve.ErrorMessage));
                serviceResult.Add(ServiceResult.Error(error));
            }
            return serviceResult;
        }

        private static KissEinwohnerregisterServiceClient GetWebserviceClient(BaEinwohnerregisterConfigDTO configDto)
        {
            var endpoint = new EndpointAddress(configDto.KissWebserviceUrl);
            var securityMode = configDto.KissWebserviceUrl.StartsWith("https") ? BasicHttpSecurityMode.Transport : BasicHttpSecurityMode.None;
            var binding = new BasicHttpBinding(securityMode);

            binding.MaxBufferSize = int.MaxValue;
            binding.MaxReceivedMessageSize = int.MaxValue;
            binding.ReaderQuotas.MaxBytesPerRead = int.MaxValue;
            binding.ReaderQuotas.MaxArrayLength = int.MaxValue;
            binding.ReaderQuotas.MaxDepth = 32;
            binding.ReaderQuotas.MaxStringContentLength = int.MaxValue;

            if (!string.IsNullOrWhiteSpace(configDto.KissWebserviceProxy))
            {
                binding.UseDefaultWebProxy = false;
                binding.ProxyAddress = new Uri(configDto.KissWebserviceProxy);
            }

            var client = new KissEinwohnerregisterServiceClient(binding, endpoint);
            client.Open();
            return client;
        }

        private static IServiceResult ImportPersonKrankenkassen(IKissUnitOfWork unitOfWork, int baPersonID, BaEinwohnerregisterPersonAnfrageDTO personDto, ChangesHelper changeHelper)
        {
            var result = ServiceResult.Ok();
            // Krankenkasse/Prämienverbilligung
            if (personDto.Krankenkassen != null && personDto.Krankenkassen.Any())
            {
                foreach (var krankenkasse in personDto.Krankenkassen)
                {
                    var praemienverbilligung = unitOfWork.BaPraemienverbilligung.GetByBaPersonIdJahrFolgenummer(baPersonID, krankenkasse.Jahr, krankenkasse.Folgenummer);
                    if (praemienverbilligung == null)
                    {
                        praemienverbilligung = new BaPraemienverbilligung
                        {
                            BaPersonID = baPersonID
                        };
                        changeHelper.SetPropertyAndGetChanges(praemienverbilligung, p => p.Jahr, krankenkasse.Jahr, "IPV Jahr");
                        changeHelper.SetPropertyAndGetChanges(praemienverbilligung, p => p.Folgenummer, krankenkasse.Folgenummer, "IPV Folgenummer");
                    }

                    changeHelper.SetPropertyAndGetChanges(praemienverbilligung, p => p.BetragAnspruch, krankenkasse.BetragAnspruch, "IPV Anspruch");
                    changeHelper.SetPropertyAndGetChanges(praemienverbilligung, p => p.BetragAuszahlung, krankenkasse.BetragAuszahlung, "IPV Auszahlung");
                    changeHelper.SetPropertyAndGetChanges(praemienverbilligung, p => p.LetzteMutation, krankenkasse.LetzteMutation, "IPV letzte Mutation");
                    if (praemienverbilligung.ZahlungAn_Krankenkassennummer != krankenkasse.KrankenkasseNummer)
                    {
                        changeHelper.SetPropertyAndGetChanges(praemienverbilligung, p => p.ZahlungAn, null, "IPV Zahlung an");
                        changeHelper.SetPropertyAndGetChanges(
                            praemienverbilligung, p => p.ZahlungAn_Krankenkassennummer, krankenkasse.KrankenkasseNummer, "IPV Zahlung an (Krankenkassennummer)");
                    }

                    // Insert or update praemienverbilligung in KiSS
                    unitOfWork.BaPraemienverbilligung.InsertOrUpdateEntity(praemienverbilligung);
                }
            }

            return result;
        }

        private static IServiceResult ValidateConfigValues(BaEinwohnerregisterConfigDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.KissWebserviceUrl))
            {
                return new ServiceResult(ServiceResultType.Error, SstEinwohnerregisterServiceRes.NoWebserviceUrl);
            }

            if (!Uri.IsWellFormedUriString(dto.KissWebserviceUrl, UriKind.RelativeOrAbsolute))
            {
                return new ServiceResult(ServiceResultType.Error, SstEinwohnerregisterServiceRes.InvalidWebserviceUrl, null, null, dto.KissWebserviceUrl);
            }

            return ServiceResult.Ok();
        }
    }
}