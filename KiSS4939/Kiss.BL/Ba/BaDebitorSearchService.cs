using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.Interfaces.BL;
using Kiss.Model;
using Kiss.Model.DTO.BA;

namespace Kiss.BL.Ba
{
    /// <summary>
    /// Service für Debitoren-Suche.
    /// </summary>
    public class BaDebitorSearchService : ServiceBase
    {
        #region Constructors

        private BaDebitorSearchService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Erstellt ein <see cref="BaDebitorDTO"/>-Object basierend auf einer BaInstitutionID.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="baInstitutionId"></param>
        /// <returns></returns>
        public BaDebitorDTO GetDebitorInstitution(IUnitOfWork unitOfWork, int baInstitutionId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            return GetInstitutionQuery(unitOfWork).SingleOrDefault(x => x.BaInstitutionId == baInstitutionId);
        }

        /// <summary>
        /// Erstellt ein <see cref="BaDebitorDTO"/>-Object basierend auf einer BaPersonID.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="baPersonId"></param>
        /// <returns></returns>
        public BaDebitorDTO GetDebitorPerson(IUnitOfWork unitOfWork, int baPersonId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            return GetPersonQuery(unitOfWork).SingleOrDefault(x => x.BaPersonId == baPersonId);
        }

        /// <summary>
        /// Sucht nach Debitoren (Personen, Institutionen).
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public List<BaDebitorDTO> SearchDebitor(IUnitOfWork unitOfWork, string searchString)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            // Prepare search string
            searchString = searchString.ToUpper();

            if (searchString == "*")
            {
                searchString = string.Empty;
            }

            var vorname = string.Empty;
            var nachname = searchString;
            var splitted = searchString.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            if (splitted.Count() == 2)
            {
                nachname = splitted[0];
                vorname = splitted[1];
            }

            // BaPerson
            var personDtoResult = from dto in GetPersonQuery(unitOfWork)
                                  where dto.Nachname.ToUpper().Contains(nachname) && dto.Vorname.ToUpper().Contains(vorname)
                                  select dto;

            // BaInstitution
            var institutionDtoResult = from dto in GetInstitutionQuery(unitOfWork)
                                       where dto.InstitutionName.ToUpper().Contains(searchString)
                                       select dto;

            // Union
            return personDtoResult.Union(institutionDtoResult).ToList();
        }

        /// <summary>
        /// Sucht nach Debitoren Institutionen
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public List<BaDebitorDTO> SearchDebitorInstitution(IUnitOfWork unitOfWork, string searchString)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            // Prepare search string
            searchString = searchString.ToUpper();

            if (searchString == "*")
            {
                searchString = string.Empty;
            }

            // BaInstitution
            var institutionDtoResult = from dto in GetInstitutionQuery(unitOfWork)
                                       where dto.InstitutionName.ToUpper().Contains(searchString) // ToDo: Suche nach Adresszusatz, sobald BaAdresse harmonisiert ist || (dto.Zusatz != null && dto.Zusatz.ToUpper().Contains(searchString))
                                       orderby dto.InstitutionName
                                       select dto;

            // Union
            return institutionDtoResult.ToList();
        }

        #endregion

        #region Private Methods

        private IQueryable<BaDebitorDTO> GetInstitutionQuery(IUnitOfWork unitOfWork)
        {
            var institutionen = UnitOfWork.GetRepository<BaInstitution>(unitOfWork);
            var adressen = UnitOfWork.GetRepository<BaAdresse>(unitOfWork);

            return from institution in institutionen
                   join adresse in adressen on institution.BaInstitutionID equals adresse.BaInstitutionID
                   where institution.Debitor
                   select new BaDebitorDTO
                   {
                       BaInstitution = institution,
                       BaInstitutionId = institution.BaInstitutionID,
                       BaPerson = null,
                       BaPersonId = null,
                       HausNr = adresse.HausNr,
                       InstitutionName = institution.Name,
                       Nachname = null,
                       Ort = adresse.Ort,
                       Plz = adresse.PLZ,
                       Strasse = adresse.Strasse,
                       TypeInt = (int)DebitorType.Institution,
                       Vorname = null
                   };
        }

        private IQueryable<BaDebitorDTO> GetPersonQuery(IUnitOfWork unitOfWork)
        {
            var personen = UnitOfWork.GetRepository<BaPerson>(unitOfWork);
            var adressen = UnitOfWork.GetRepository<BaAdresse>(unitOfWork);

            return from person in personen
                   join adresse in adressen on person.BaPersonID equals adresse.BaPersonID
                   where adresse.DatumVon <= DateTime.Today &&
                         (adresse.DatumBis == null || adresse.DatumBis >= DateTime.Today) && adresse.AdresseCode == 1
                   select new BaDebitorDTO
             {
                 BaInstitution = null,
                 BaInstitutionId = null,
                 BaPerson = person,
                 BaPersonId = person.BaPersonID,
                 HausNr = adresse.HausNr,
                 InstitutionName = null,
                 Nachname = person.Name,
                 Ort = adresse.Ort,
                 Plz = adresse.PLZ,
                 Strasse = adresse.Strasse,
                 TypeInt = (int)DebitorType.Person,
                 Vorname = person.Vorname
             };
        }

        #endregion

        #endregion
    }
}