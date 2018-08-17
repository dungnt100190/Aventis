using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Kiss.BL.Fs.Validation;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.Database;
using Kiss.Model;
using Kiss.Model.DTO.Fs;
using KiSS.Common.Exceptions;

namespace Kiss.BL.Fs
{
    /// <summary>
    /// Service to manage an FsReduktionMitarbeiter
    /// </summary>
    public class FsVerfuegbareArbeitszeitService : ServiceCRUDBase<FsReduktionMitarbeiter>
    {
        #region Constructors

        private FsVerfuegbareArbeitszeitService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Lädt einen Datensatz aufgrund der ID.
        /// </summary>
        /// <param name="unitOfWork">Die UnitOfWork.</param>
        /// <param name="id">Die ID des Datensatzes.</param>
        /// <returns>Der Datensatz mit der angegebenen ID.</returns>
        public override FsReduktionMitarbeiter GetById(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<FsReduktionMitarbeiter>(unitOfWork);

            var returnValue = repository
                .Where(redMa => redMa.FsReduktionMitarbeiterID == id)
                .SingleOrDefault();

            if (returnValue == null)
            {
                throw new EntityNotFoundException("no entity of 'FsReduktionMitarbeiter' found with id: " + id);
            }

            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        /// <summary>
        /// Gets the time available for "Fallarbeit".
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="result">Für Fallarbeit verfügbare Zeit</param>
        /// <param name="timePeriod">Beliebige Zeitperiode</param>
        /// <param name="userID">Id des users.</param>
        /// <returns></returns>
        public KissServiceResult GetMitarbeiterArbeitszeit(IUnitOfWork unitOfWork, out decimal result, TimePeriod timePeriod, int? userID)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            result = 0;

            var month = new MonthYear(timePeriod.From);
            var monthTo = new MonthYear(timePeriod.To);
            List<FsMitarbeiterArbeitszeitDTO> list;
            while (month <= monthTo)
            {
                var reduktionMonth = new TimePeriod(month.Year, month.Month);
                TimePeriod? overlappingPeriod = reduktionMonth * timePeriod;
                if (overlappingPeriod.HasValue)
                {
                    decimal overlapping = (decimal)overlappingPeriod.Value.TimeSpan.Days / reduktionMonth.TimeSpan.Days;
                    KissServiceResult serviceResult = GetMitarbeiterArbeitszeit(unitOfWork, out list, month, userID);

                    if (!serviceResult.IsOk)
                    {
                        return serviceResult;
                    }

                    FsMitarbeiterArbeitszeitDTO dto = list.FirstOrDefault();

                    if (dto != null) //DTO kann null sein weil: User kann gesperrt sein. User ist in keiner XOrgUnit.
                    {
                        result += dto.VerfuegbareArbeitszeit * overlapping;
                    }
                }
                month++;
            }
            var reduktionMitarbeiterService = Container.Resolve<FsReduktionMitarbeiterService>();
            return reduktionMitarbeiterService.AreEntriesGenerated(unitOfWork, userID, timePeriod);
        }

        /// <summary>
        /// Gets a list of users with their individual FsReduktionMitarbeiter.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="result"></param>
        /// <param name="month"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public KissServiceResult GetMitarbeiterArbeitszeit(IUnitOfWork unitOfWork,
            out List<FsMitarbeiterArbeitszeitDTO> result,
            MonthYear month,
            int? userID)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            IRepository<XUser> repositoryUser = UnitOfWork.GetRepository<XUser>(unitOfWork);
            IRepository<XOrgUnit_User> repositoryOrgUnitUser = UnitOfWork.GetRepository<XOrgUnit_User>(unitOfWork);
            IRepository<XOrgUnit> repositoryOrgUnit = UnitOfWork.GetRepository<XOrgUnit>(unitOfWork);
            var timePeriod = new TimePeriod(month);

            var query = from user in repositoryUser
                        join oUnitUser in repositoryOrgUnitUser on user.UserID equals oUnitUser.UserID
                        join oUnit in repositoryOrgUnit on oUnitUser.OrgUnitID equals oUnit.OrgUnitID
                        where (userID.HasValue && user.UserID == userID.Value)   //wenn eine UserID übergeben wurde, filtern auf diese UserID
                               || (!userID.HasValue && user.FaPhase.Any(p => p.DatumVon <= timePeriod.To && (!p.DatumBis.HasValue || p.DatumBis.Value >= timePeriod.From))) // wurde keine UserID übergeben, nur Benutzer anzeigen mit einer zugewiesenen Phase im Abfrage-Zeitraum
                        where user.IsLocked == false
                        where oUnitUser.OrgUnitMemberCode == 2
                        select new
                        {
                            User = user,
                            Reduktionen = user.FsReduktionMitarbeiter.Where(r => r.Jahr == month.Year && r.Monat == month.Month),
                            Sollstunden = user.BDESollStundenProJahr_XUser.Where(st => st.Jahr == month.Year),
                            Pensen = user.BDEPensum_XUser.Where(p => p.DatumVon <= timePeriod.From && (!p.DatumBis.HasValue || p.DatumBis.Value >= timePeriod.To)),
                            OrgName = oUnit.ItemName
                        };
            var resultTemp = query.ToList();

            result = resultTemp.Select(
                tmp => new FsMitarbeiterArbeitszeitDTO
                {
                    User = tmp.User,
                    Reduktionen = new ObservableDictionary<int, FsReduktionMitarbeiter>(
                           tmp.Reduktionen
                           .ToDictionary(fm => fm.FsReduktionID, fm => fm)),
                    ReduktionenZeitraum = GetReduktionenZeitraum(tmp.Reduktionen.ToList()),
                    Zeitraum = timePeriod,
                    BruttoArbeitszeit = CalculateBruttoArbeitszeit(tmp.Sollstunden.ToList(), tmp.Pensen, timePeriod),
                    JobPercentage = tmp.Pensen
                           .Select(p => p.PensumProzent)
                           .FirstOrDefault(), // approximation
                    OrgUnitName = tmp.OrgName
                }).ToList();

            unitOfWork.StartTrackingAndMarkAsUnchangedAll();
            return KissServiceResult.Ok();
        }

        public ObservableCollection<FsReduktionMitarbeiter> GetReduktionMitarbeiter(IUnitOfWork unitOfWork, int year, int month)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            IRepository<FsReduktionMitarbeiter> repository = UnitOfWork.GetRepository<FsReduktionMitarbeiter>(unitOfWork);

            IQueryable<FsReduktionMitarbeiter> returnValue = repository
                .Where(fma => fma.Jahr == year && fma.Monat == month)
                .Select(dlInDlp => dlInDlp);

            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return new ObservableCollection<FsReduktionMitarbeiter>(returnValue);
        }

        public override KissServiceResult ValidateInMemory(FsReduktionMitarbeiter dataToValidate)
        {
            // validation: check if entity is consistent in itself
            var serviceResult = FsReduktionMitarbeiterValidator.ValidateEntity(dataToValidate);

            return serviceResult + base.ValidateInMemory(dataToValidate);
        }

        #endregion

        #region Private Static Methods

        private static decimal CalculateHoursForTimeSpan(decimal sollstundenFuerMonat,
            int jahr,
            int monat,
            IEnumerable<BDEPensum_XUser> pensen,
            TimePeriod zeitraumAuswertung)
        {
            var zeitraumSollstunden = new TimePeriod(jahr, monat);
            TimePeriod? overlappingPeriod = zeitraumSollstunden * zeitraumAuswertung;
            if (!overlappingPeriod.HasValue)
            {
                return decimal.Zero;
            }
            //int daysOverlapping = (lastOverlappingDay - firstOverlappingDay).Days + 1;
            decimal weightedDays = GetWeightedDays(overlappingPeriod.Value, pensen);
            //decimal hoursPerDay = sollstundenFuerMonat / DateTime.DaysInMonth(jahr, monat);

            return weightedDays * sollstundenFuerMonat / DateTime.DaysInMonth(jahr, monat);
        }

        private static decimal GetWeightedDays(TimePeriod overlappingPeriod, IEnumerable<BDEPensum_XUser> pensen)
        {
            if (pensen == null || pensen.Count() == 0)
            {
                return decimal.Zero;
            }
            decimal weightedDays = decimal.Zero;
            foreach (BDEPensum_XUser pensum in pensen)
            {
                int overlappingDays = overlappingPeriod.GetOverlappingDays(new TimePeriod(pensum.DatumVon, pensum.DatumBis));
                weightedDays += overlappingDays * pensum.PensumProzent / 100m;
            }
            return weightedDays;
        }

        #endregion

        #region Private Methods

        private decimal CalculateBruttoArbeitszeit(List<BDESollStundenProJahr_XUser> sollstunden,
            IEnumerable<BDEPensum_XUser> pensen,
            TimePeriod zeitraum)
        {
            return sollstunden.Sum(bde => CalculateHoursForTimeSpan(bde, pensen, zeitraum));
        }

        private decimal CalculateHoursForTimeSpan(BDESollStundenProJahr_XUser bde, IEnumerable<BDEPensum_XUser> pensen, TimePeriod zeitraumAuswertung)
        {
            decimal total = decimal.Zero;
            total += CalculateHoursForTimeSpan(bde.JanuarStd, bde.Jahr, 1, pensen, zeitraumAuswertung);
            total += CalculateHoursForTimeSpan(bde.FebruarStd, bde.Jahr, 2, pensen, zeitraumAuswertung);
            total += CalculateHoursForTimeSpan(bde.MaerzStd, bde.Jahr, 3, pensen, zeitraumAuswertung);
            total += CalculateHoursForTimeSpan(bde.AprilStd, bde.Jahr, 4, pensen, zeitraumAuswertung);
            total += CalculateHoursForTimeSpan(bde.MaiStd, bde.Jahr, 5, pensen, zeitraumAuswertung);
            total += CalculateHoursForTimeSpan(bde.JuniStd, bde.Jahr, 6, pensen, zeitraumAuswertung);
            total += CalculateHoursForTimeSpan(bde.JuliStd, bde.Jahr, 7, pensen, zeitraumAuswertung);
            total += CalculateHoursForTimeSpan(bde.AugustStd, bde.Jahr, 8, pensen, zeitraumAuswertung);
            total += CalculateHoursForTimeSpan(bde.SeptemberStd, bde.Jahr, 9, pensen, zeitraumAuswertung);
            total += CalculateHoursForTimeSpan(bde.OktoberStd, bde.Jahr, 10, pensen, zeitraumAuswertung);
            total += CalculateHoursForTimeSpan(bde.NovemberStd, bde.Jahr, 11, pensen, zeitraumAuswertung);
            total += CalculateHoursForTimeSpan(bde.DezemberStd, bde.Jahr, 12, pensen, zeitraumAuswertung);
            return total;
        }

        private IDictionary<int, FsReduktionMitarbeiterZeitraumDTO> GetReduktionenZeitraum(List<FsReduktionMitarbeiter> reduktionenMitarbeiter)
        {
            IDictionary<int, FsReduktionMitarbeiterZeitraumDTO> result = new Dictionary<int, FsReduktionMitarbeiterZeitraumDTO>();
            reduktionenMitarbeiter.ForEach(
                x => result.Add(
                    x.FsReduktionID,
                    new FsReduktionMitarbeiterZeitraumDTO
                    {
                        ReduktionID = x.FsReduktionID,
                        UserID = x.UserID,
                        StundenProMonat = 1
                    }));
            return result;
        }

        #endregion

        #endregion
    }
}