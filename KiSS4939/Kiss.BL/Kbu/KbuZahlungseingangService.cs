using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Kiss.BL.Kbu.Validation;

using KiSS.Common.Exceptions;

using Kiss.Interfaces.BL;
using Kiss.Model;
using Kiss.Model.DTO.Kbu;

namespace Kiss.BL.Kbu
{
    /// <summary>
    /// Service to manage a KbuZahlungseingang.
    /// </summary>
    public class KbuZahlungseingangService : ServiceCRUDBase<KbuZahlungseingang>
    {
        #region Constructors

        private KbuZahlungseingangService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        public override KbuZahlungseingang GetById(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<KbuZahlungseingang>(unitOfWork);

            var returnValue = repository
                .Where(entity => entity.KbuZahlungseingangID == id)
                .SingleOrDefault();

            if (returnValue == null)
            {
                throw new EntityNotFoundException("no entity of 'KbuZahlungseingang' found with id: " + id);
            }

            //SetEntityValidator(returnValue);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        /// <summary>
        /// Suche nach Zahlungseingang
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="fulltextFilter">Filter auf Zahlstapel, Betrag, Klient oder Mitteilung</param>
        /// <param name="zeTeamCode">Filter nach Code des ZahlungseingangTeams</param>
        /// <param name="nurOffeneZe">Zeige nur offene Zahlungseingänge</param>
        /// <param name="nurNichtZugeordnet">Zeige nur nicht zugeordnete Zahlungseingänge</param>
        /// <returns>Zahlungseingänge, welche auf die gegebenen Filterkriterien passen</returns>
        public ObservableCollection<KbuZahlungseingang> SearchZahlungseingang(
            IUnitOfWork unitOfWork,
            string fulltextFilter,
            int? zeTeamCode,
            bool nurOffeneZe,
            bool nurNichtZugeordnet)
        {
            // TODO: Filter zeTeamCode = "Nicht Zugeordnet" --> null ?

            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            List<KbuZahlungseingang> result;

            var repositoryFall = UnitOfWork.GetRepository<FaFall>(unitOfWork);

            var repositoryZe = UnitOfWork.GetRepository<KbuZahlungseingang>(unitOfWork);
            var repositorySst = UnitOfWork.GetRepository<SstZahlungseingang>(unitOfWork);

            var queryZahlungseingang = repositoryZe
                .Where(ze => !zeTeamCode.HasValue || ze.KbuZahlungseingangTeamCode == zeTeamCode.Value)
                .Where(ze => !nurOffeneZe || !ze.Ausgeglichen)
                .Where(ze => !nurNichtZugeordnet || !ze.FaFallID.HasValue || !ze.KbuZahlungseingangTeamCode.HasValue)
                .Include(ze => ze.SstZahlungseingang)
                .Include(ze => ze.BaInstitutionDebitor)
                .Include(ze => ze.FaFall.SubInclude(fa => fa.BaPerson))
                .OrderBy(ze => ze.DatumZahlungseingang);

            if (string.IsNullOrEmpty(fulltextFilter))
            {
                result = queryZahlungseingang.ToList();
            }
            else
            {
                //Filter auf Zahlstapel, Betrag, Klient oder Mitteilung
                //-----------------------------------------------------

                //Zahlstapel
                var resultZahlstapel = repositorySst
                    .Where(sstZe => sstZe.PAYMENT_LOT.Contains(fulltextFilter))
                    .Include(sstZe => sstZe.KbuZahlungseingang)
                    .Where(sstZe => !zeTeamCode.HasValue || sstZe.KbuZahlungseingang.KbuZahlungseingangTeamCode == zeTeamCode.Value)
                    .Where(sstZe => !nurOffeneZe || !sstZe.KbuZahlungseingang.Ausgeglichen)
                    .Where(sstZe => !nurNichtZugeordnet || !sstZe.KbuZahlungseingang.FaFallID.HasValue || !sstZe.KbuZahlungseingang.KbuZahlungseingangTeamCode.HasValue)
                    .Select(sstZe => sstZe.KbuZahlungseingang)
                    .Include(ze => ze.SstZahlungseingang)
                    .Include(ze => ze.BaInstitutionDebitor)
                    .Include(ze => ze.FaFall.SubInclude(fa => fa.BaPerson))
                    .OrderBy(ze => ze.DatumZahlungseingang);

                //Betrag
                var resultBetrag = queryZahlungseingang.Where(ze => 1 == -1); //use an empty resultset in case we can't filter on betrag
                decimal filterBetrag;
                if(decimal.TryParse(fulltextFilter, out filterBetrag))
                {
                    resultBetrag = queryZahlungseingang.Where(ze => ze.Betrag == filterBetrag);
                }

                //Klient
                var resultKlient = queryZahlungseingang
                    .Where(ze => ze.FaFall != null)
                    .Select(ze => ze.FaFall.BaPerson)
                    .WhereNameVornameContains(fulltextFilter)
                    .SelectMany(p => p.FaFall)
                    .SelectMany(f => f.KbuZahlungseingang);

                //Mitteilung
                var resultMitteilung = queryZahlungseingang.Where(ze => !string.IsNullOrEmpty(ze.Mitteilung) && ze.Mitteilung.Contains(fulltextFilter));

                result = resultZahlstapel
                    .Union(resultBetrag)
                    .Union(resultKlient)
                    .Union(resultMitteilung)
                    .ToList();
            }

            result.ForEach(SetEntityValidator); 
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return new ObservableCollection<KbuZahlungseingang>(result);
        }

        public override KissServiceResult ValidateInMemory(KbuZahlungseingang dataToValidate)
        {
            var serviceResult = KbuZahlungseingangValidator.ValidateEntity(dataToValidate);

            return serviceResult + base.ValidateInMemory(dataToValidate);
        }

        #endregion

        #endregion
    }
}