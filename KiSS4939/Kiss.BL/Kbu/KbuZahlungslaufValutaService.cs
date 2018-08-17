using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.BL;
using Kiss.Model;

namespace Kiss.BL.Kbu
{
    /// <summary>
    /// Service to manage a TEntity.
    /// </summary>
    public class KbuZahlungslaufValutaService : ServiceBase
    {
        #region Methods

        #region Public Static Methods

        public static bool IsWshPeriodizitaetCalculated(LOVsGenerated.WshPeriodizitaet wshPeriodizitaet)
        {
            return wshPeriodizitaet == LOVsGenerated.WshPeriodizitaet._1xProMonat ||
                   wshPeriodizitaet == LOVsGenerated.WshPeriodizitaet._2xProMonat ||
                   wshPeriodizitaet == LOVsGenerated.WshPeriodizitaet.Woechentlich ||
                   wshPeriodizitaet == LOVsGenerated.WshPeriodizitaet.Wochentage ||
                   wshPeriodizitaet == LOVsGenerated.WshPeriodizitaet._14Taeglich;
        }

        #endregion

        #region Public Methods

        public DateTime? GetNextValutaDatum(IUnitOfWork unitOfWork, LOVsGenerated.WshPeriodizitaet periodizitaet, int jahr, int monat)
        {
            var list = GetValutaDatum(unitOfWork, periodizitaet, jahr, monat);
            return list.Count > 0 ? (DateTime?)list[0] : null;
        }

        public List<DateTime> GetValutaDatum(IUnitOfWork unitOfWork, LOVsGenerated.WshPeriodizitaet periodizitaet, int jahr, int monat)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<KbZahlungslaufValuta>(unitOfWork);

            var kbZahlungslaufValutaMonat = repository.Where(x => x.Jahr == jahr && x.Monat == monat).SingleOrDefault();

            if (kbZahlungslaufValutaMonat == null)
            {
                return new List<DateTime>();
            }

            var datumList = new List<DateTime?>();

            switch (periodizitaet)
            {
                case LOVsGenerated.WshPeriodizitaet._1xProMonat:
                    datumList.Add(kbZahlungslaufValutaMonat.DatMonatlich);
                    break;

                case LOVsGenerated.WshPeriodizitaet._2xProMonat:
                    datumList.Add(kbZahlungslaufValutaMonat.DatTeil1);
                    datumList.Add(kbZahlungslaufValutaMonat.DatTeil2);
                    break;

                case LOVsGenerated.WshPeriodizitaet.Woechentlich:
                    datumList.Add(kbZahlungslaufValutaMonat.DatWoche1);
                    datumList.Add(kbZahlungslaufValutaMonat.DatWoche2);
                    datumList.Add(kbZahlungslaufValutaMonat.DatWoche3);
                    datumList.Add(kbZahlungslaufValutaMonat.DatWoche4);
                    datumList.Add(kbZahlungslaufValutaMonat.DatWoche5);
                    break;

                case LOVsGenerated.WshPeriodizitaet._14Taeglich:
                    datumList.Add(kbZahlungslaufValutaMonat.Dat14Tage1);
                    datumList.Add(kbZahlungslaufValutaMonat.Dat14Tage2);
                    datumList.Add(kbZahlungslaufValutaMonat.Dat14Tage3);
                    break;

                case LOVsGenerated.WshPeriodizitaet.Wochentage:
                    for (var d = new DateTime(jahr, monat, 1); d < new DateTime(jahr, monat + 1, 1); d = d.AddDays(1))
                    {
                        var dayOfWeek = d.DayOfWeek;

                        if (dayOfWeek == DayOfWeek.Monday || dayOfWeek == DayOfWeek.Tuesday || dayOfWeek == DayOfWeek.Wednesday || dayOfWeek == DayOfWeek.Thursday || dayOfWeek == DayOfWeek.Friday)
                        {
                            datumList.Add(d);
                        }
                    }
                    break;

                case LOVsGenerated.WshPeriodizitaet.Valuta:
                case LOVsGenerated.WshPeriodizitaet.Quartal:
                case LOVsGenerated.WshPeriodizitaet.Semester:
                    break;
            }

            return datumList.Where(d => d.HasValue).Cast<DateTime>().ToList();
        }

        #endregion

        #endregion
    }
}