using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.BusinessLogic.Ba.DTO;
using Kiss.BusinessLogic.LocalResources.Ba;
using Kiss.BusinessLogic.Sys;
using Kiss.DbContext;
using Kiss.DbContext.Constant;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;

namespace Kiss.BusinessLogic.Ba
{
    public class BaAdressatService : Service
    {
        #region Methods

        #region Public Methods

        public BaAdressatDTO GetAdressat(int? baInstitutionId, int? baPersonId)
        {
            if (baInstitutionId.HasValue)
            {
                var baInstitutionService = Container.Resolve<BaInstitutionService>();
                var institution = baInstitutionService.GetEntityById(baInstitutionId.Value);
                return new BaAdressatDTO
                {
                    BaInstitutionId = institution.BaInstitutionID,
                    Name = institution.Name,
                    Vorname = institution.Vorname,
                    NameVorname = institution.NameVorname,
                };
            }

            if (baPersonId.HasValue)
            {
                var baPersonService = Container.Resolve<BaPersonService>();
                var person = baPersonService.GetEntityById(baPersonId.Value);
                return new BaAdressatDTO
                {
                    BaPersonId = person.BaPersonID,
                    Name = person.Name,
                    Vorname = person.Vorname,
                    NameVorname = person.LastNameFirstName,
                };
            }

            return null;
        }

        public IServiceResult<IList<BaAdressatDTO>> GetAdressatList(string searchString, int? baPersonIdFalltraeger, bool nurInstitutionen = false)
        {
            var baInstitutionService = Container.Resolve<BaInstitutionService>();
            var baPersonService = Container.Resolve<BaPersonService>();
            var baAdresseService = Container.Resolve<BaAdresseService>();

            List<BaAdressatDTO> adressate;
            if (searchString.Equals(Constant.POINT) && baPersonIdFalltraeger.HasValue)
            {
                adressate = baInstitutionService.GetAffectedInstitutions(baPersonIdFalltraeger.Value)
                    .Select(
                        ins => new BaAdressatDTO
                        {
                            Typ = BaAdresseRes.Institution,
                            BaInstitutionId = ins.BaInstitutionID,
                            Name = ins.Name,
                            Vorname = ins.Vorname,
                            NameVorname = ins.NameVorname,
                            Strasse = string.Empty,
                            HausNr = string.Empty,
                            Ort = string.Empty,
                            Plz = string.Empty
                        })
                    .Union(
                        baPersonService.GetAffectedPersons(baPersonIdFalltraeger.Value)
                            .Select(
                                per => new BaAdressatDTO
                                {
                                    Typ = BaAdresseRes.Person,
                                    BaPersonId = per.BaPersonID,
                                    Name = per.LastNameFirstName,
                                    Vorname = per.Vorname,
                                    NameVorname = per.LastNameFirstName,
                                    Strasse = string.Empty,
                                    HausNr = string.Empty,
                                    Ort = string.Empty,
                                    Plz = string.Empty
                                })).OrderBy(x => x.Name).ToList();
            }
            else
            {
                var adressatDtos = baInstitutionService.SearchInstitution(searchString)
                    .Select(
                        ins => new BaAdressatDTO
                        {
                            Typ = BaAdresseRes.Institution,
                            BaInstitutionId = ins.BaInstitutionID,
                            Name = ins.Name,
                            Vorname = ins.Vorname,
                            NameVorname = ins.NameVorname,
                            Strasse = string.Empty,
                            HausNr = string.Empty,
                            Ort = string.Empty,
                            Plz = string.Empty
                        });

                if (!nurInstitutionen)
                {
                    adressatDtos = adressatDtos.Union(
                        baPersonService.SearchPerson(searchString, false)
                            .Select(
                                per => new BaAdressatDTO
                                {
                                    Typ = BaAdresseRes.Person,
                                    BaPersonId = per.BaPersonID,
                                    Name = per.LastNameFirstName,
                                    Vorname = per.Vorname,
                                    NameVorname = per.LastNameFirstName,
                                    Strasse = string.Empty,
                                    HausNr = string.Empty,
                                    Ort = string.Empty,
                                    Plz = string.Empty
                                }));
                }

                adressate = adressatDtos.OrderBy(x => x.Name).ToList();
            }

            // adressen holen
            var baPersonIDs = adressate.Where(x => x.BaPersonId != null).Select(x => x.BaPersonId).ToList();
            var baInstitutionIDs = adressate.Where(x => x.BaInstitutionId != null).Select(x => x.BaInstitutionId).ToList();

            var baAdressenListeMitBaPersonIDs = baAdresseService.GetByListOfBapersonId(baPersonIDs);
            var baAdressenListeMitBaInstitutionIDs = baAdresseService.GetByListOfBaInstitutionIds(baInstitutionIDs);
            foreach (var adr in adressate)
            {
                if (adr.BaInstitutionId == null)
                {
                    var firstOrDefault = baAdressenListeMitBaPersonIDs.FirstOrDefault(x => x.BaPersonID == adr.BaPersonId);
                    if (firstOrDefault != null)
                    {
                        adr.Strasse = firstOrDefault.Strasse;
                        adr.HausNr = firstOrDefault.HausNr;
                        adr.Ort = firstOrDefault.Ort;
                        adr.Plz = firstOrDefault.PLZ;
                    }
                }
                else
                {
                    var firstOrDefault = baAdressenListeMitBaInstitutionIDs.FirstOrDefault(x => x.BaInstitutionID == adr.BaInstitutionId);
                    if (firstOrDefault != null)
                    {
                        adr.Strasse = firstOrDefault.Strasse;
                        adr.HausNr = firstOrDefault.HausNr;
                        adr.Ort = firstOrDefault.Ort;
                        adr.Plz = firstOrDefault.PLZ;
                    }
                }
            }

            return new ServiceResult<IList<BaAdressatDTO>>(adressate);
        }

        #endregion

        #endregion
    }
}