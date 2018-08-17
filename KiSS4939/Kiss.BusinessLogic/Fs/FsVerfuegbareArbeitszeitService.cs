using System;
using System.Collections.Generic;
using System.Linq;
using Kiss.DataAccess.Interfaces;
using Kiss.DbContext;
using Kiss.DbContext.DTO.Fs;
using Kiss.Infrastructure;
using Kiss.Interfaces.BL;

namespace Kiss.BusinessLogic.Fs
{
    /// <summary>
    /// Service to manage an FsReduktionMitarbeiter
    /// </summary>
    public class FsVerfuegbareArbeitszeitService : ServiceCRUD<FsReduktionMitarbeiter>
    {
        #region Constructors

        private FsVerfuegbareArbeitszeitService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Gets the time available for "Fallarbeit".
        /// </summary>
        /// <param name="timePeriod">Beliebige Zeitperiode</param>
        /// <param name="userID">Id des users.</param>
        /// <returns>Für Fallarbeit verfügbare Zeit</returns>
        public decimal GetMitarbeiterArbeitszeit(TimePeriod timePeriod, int? userID)
        {
            using (var unitOfWork = (IKissUnitOfWork)CreateNewUnitOfWork())
            {
                return GetMitarbeiterArbeitszeit(unitOfWork, timePeriod, userID);
            }
        }

        /// <summary>
        /// Gets the time available for "Fallarbeit".
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="timePeriod">Beliebige Zeitperiode</param>
        /// <param name="userID">Id des users.</param>
        /// <returns>Für Fallarbeit verfügbare Zeit</returns>
        internal decimal GetMitarbeiterArbeitszeit(IKissUnitOfWork unitOfWork, TimePeriod timePeriod, int? userID)
        {
            var result = 0m;

            var month = new MonthYear(timePeriod.From);
            var monthTo = new MonthYear(timePeriod.To);
            while (month <= monthTo)
            {
                var reduktionMonth = new TimePeriod(month.Year, month.Month);
                var overlappingPeriod = reduktionMonth * timePeriod;
                if (overlappingPeriod.HasValue)
                {
                    var overlapping = (decimal)overlappingPeriod.Value.TimeSpan.Days / reduktionMonth.TimeSpan.Days;
                    var first = GetMitarbeiterArbeitszeit(unitOfWork, month, userID).FirstOrDefault();

                    //DTO kann null sein weil: User kann gesperrt sein. User ist in keiner XOrgUnit.
                    if (first != null)
                    {
                        result += first.VerfuegbareArbeitszeit * overlapping;
                    }
                }
                month++;
            }
            return result;

            //// ToDo: Ist wohl aufwändig -> auslagern und separat aufrufen, wo benötigt
            //var reduktionMitarbeiterService = Container.Resolve<FsReduktionMitarbeiterService>();
            //return reduktionMitarbeiterService.AreEntriesGenerated(unitOfWork, userID, timePeriod);
        }

        /// <summary>
        /// Gets a list of users with their individual FsReduktionMitarbeiter.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="month"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public KissServiceResult GetMitarbeiterArbeitszeit(out List<FsMitarbeiterArbeitszeitDTO> result, MonthYear month, int? userID)
        {
            using (var unitOfWork = (IKissUnitOfWork)CreateNewUnitOfWork())
            {
                result = GetMitarbeiterArbeitszeit(unitOfWork, month, userID);
                return KissServiceResult.Ok();
            }
        }

        /// <summary>
        /// Gets a list of users with their individual FsReduktionMitarbeiter.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="month"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        internal List<FsMitarbeiterArbeitszeitDTO> GetMitarbeiterArbeitszeit(IKissUnitOfWork unitOfWork, MonthYear month, int? userID)
        {
            var timePeriod = new TimePeriod(month);
            return unitOfWork.XUser.GetMitarbeiterArbeitszeit(month, userID)
                                   .Select(tmp => new FsMitarbeiterArbeitszeitDTO
                                                      {
                                                          User = tmp.User,
                                                          Reduktionen = new ObservableDictionary<int, FsReduktionMitarbeiter>
                                                                            (
                                                                               tmp.Reduktionen.ToDictionary(fm => fm.FsReduktionID, fm => fm)
                                                                            ),
                                                          ReduktionenZeitraum = tmp.Reduktionen.ToDictionary(red => red.FsReduktionID,
                                                                                                             red => new FsReduktionMitarbeiterZeitraumDTO
                                                                                                                        {
                                                                                                                            ReduktionID = red.FsReduktionID,
                                                                                                                            UserID = red.UserID,
                                                                                                                            StundenProMonat = 1
                                                                                                                        }),
                                                          Zeitraum = timePeriod,
                                                          BruttoArbeitszeit = CalculateBruttoArbeitszeit(tmp.Sollstunden, tmp.Pensen, timePeriod),
                                                          JobPercentage = tmp.Pensen
                                                                             .Select(p => p.PensumProzent)
                                                                             .FirstOrDefault(), // approximation
                                                          OrgUnitName = tmp.OrgName
                                                      })
                   .ToList();
        }

        //public ObservableCollection<FsReduktionMitarbeiter> GetReduktionMitarbeiter(IUnitOfWork unitOfWork, int year, int month)
        //{
        //    unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
        //    IRepository<FsReduktionMitarbeiter> repository = UnitOfWork.GetRepository<FsReduktionMitarbeiter>(unitOfWork);

        //    IQueryable<FsReduktionMitarbeiter> returnValue = repository
        //        .Where(fma => fma.Jahr == year && fma.Monat == month)
        //        .Select(dlInDlp => dlInDlp);

        //    unitOfWork.StartTrackingAndMarkAsUnchangedAll();

        //    return new ObservableCollection<FsReduktionMitarbeiter>(returnValue);
        //}

        //public override KissServiceResult ValidateInMemory(FsReduktionMitarbeiter dataToValidate)
        //{
        //    // validation: check if entity is consistent in itself
        //    var serviceResult = FsReduktionMitarbeiterValidator.ValidateEntity(dataToValidate);

        //    return serviceResult + base.ValidateInMemory(dataToValidate);
        //}

        #endregion

        #region Private Static Methods

        private static decimal CalculateHoursForTimeSpan(decimal sollstundenFuerMonat,
            int jahr,
            int monat,
            IEnumerable<BDEPensum_XUser> pensen,
            TimePeriod zeitraumAuswertung)
        {
            var zeitraumSollstunden = new TimePeriod(jahr, monat);
            var overlappingPeriod = zeitraumSollstunden * zeitraumAuswertung;
            if (!overlappingPeriod.HasValue)
            {
                return decimal.Zero;
            }
            var weightedDays = GetWeightedDays(overlappingPeriod.Value, pensen);

            return weightedDays * sollstundenFuerMonat / DateTime.DaysInMonth(jahr, monat);
        }

        private static decimal GetWeightedDays(TimePeriod overlappingPeriod, IEnumerable<BDEPensum_XUser> pensen)
        {
            if (pensen == null || pensen.Count() == 0)
            {
                return decimal.Zero;
            }
            decimal weightedDays = decimal.Zero;
            foreach (var pensum in pensen)
            {
                int overlappingDays = overlappingPeriod.GetOverlappingDays(new TimePeriod(pensum.DatumVon, pensum.DatumBis));
                weightedDays += overlappingDays * pensum.PensumProzent / 100m;
            }
            return weightedDays;
        }

        #endregion

        #region Private Methods

        private static decimal CalculateBruttoArbeitszeit(IEnumerable<BDESollStundenProJahr_XUser> sollstunden,
                                                          IEnumerable<BDEPensum_XUser> pensen,
                                                          TimePeriod zeitraum)
        {
            return sollstunden.Sum(bde => CalculateHoursForTimeSpan(bde, pensen, zeitraum));
        }

        private static decimal CalculateHoursForTimeSpan(BDESollStundenProJahr_XUser bde, IEnumerable<BDEPensum_XUser> pensen, TimePeriod zeitraumAuswertung)
        {
            var total = decimal.Zero;
            var pensenList = pensen.ToList();
            total += CalculateHoursForTimeSpan(bde.JanuarStd, bde.Jahr, 1, pensenList, zeitraumAuswertung);
            total += CalculateHoursForTimeSpan(bde.FebruarStd, bde.Jahr, 2, pensenList, zeitraumAuswertung);
            total += CalculateHoursForTimeSpan(bde.MaerzStd, bde.Jahr, 3, pensenList, zeitraumAuswertung);
            total += CalculateHoursForTimeSpan(bde.AprilStd, bde.Jahr, 4, pensenList, zeitraumAuswertung);
            total += CalculateHoursForTimeSpan(bde.MaiStd, bde.Jahr, 5, pensenList, zeitraumAuswertung);
            total += CalculateHoursForTimeSpan(bde.JuniStd, bde.Jahr, 6, pensenList, zeitraumAuswertung);
            total += CalculateHoursForTimeSpan(bde.JuliStd, bde.Jahr, 7, pensenList, zeitraumAuswertung);
            total += CalculateHoursForTimeSpan(bde.AugustStd, bde.Jahr, 8, pensenList, zeitraumAuswertung);
            total += CalculateHoursForTimeSpan(bde.SeptemberStd, bde.Jahr, 9, pensenList, zeitraumAuswertung);
            total += CalculateHoursForTimeSpan(bde.OktoberStd, bde.Jahr, 10, pensenList, zeitraumAuswertung);
            total += CalculateHoursForTimeSpan(bde.NovemberStd, bde.Jahr, 11, pensenList, zeitraumAuswertung);
            total += CalculateHoursForTimeSpan(bde.DezemberStd, bde.Jahr, 12, pensenList, zeitraumAuswertung);
            return total;
        }

        #endregion

        #endregion
    }
}