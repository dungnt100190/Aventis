using System;
using System.Collections.Generic;
using System.Linq;
using Kiss.DataAccess.Fs;
using Kiss.DataAccess.Interfaces;
using Kiss.DbContext.DTO;
using Kiss.DbContext.DTO.Fs;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;

namespace Kiss.BusinessLogic.Fs
{
    public class FsDienstleistungAuswertungService : Service
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const decimal DAYS_PER_MONTH = (decimal)(365.25 / 12.0);

        #endregion

        #endregion

        #region Constructors

        private FsDienstleistungAuswertungService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Abfrage Auslastung MA.
        ///
        /// Sucht nach allen Phasen. Ist die Userid in den Suchparemetern angegeben, werden nur die
        /// Phasen dieses Benutzers berücksichtigt.
        ///
        /// Gibt es pro Phase eine zeitliche Überschneidung
        /// mit den Suchparemetern (Suche von, Suche bis), wird die Phase berücksichtigt.
        ///
        /// Phasen ohne DLP (Zugewiesen oder Bedarf) werden ebenfalls berücksichtigt.
        ///
        /// Danach wird geprüft, wie mancher Tag in der Schnittmenge der beiden Intervalle
        ///  (Zeitraum Suchparameter und Zeitraum Phase)
        /// vorhanden ist.
        ///
        /// Entsprechend wird die Aufwandsumme pro zugewiesener Dienstleistung
        /// (zugewiesen zu dem Dienstleistungspaket der Phase)
        /// berechnet. Für die Anzahl Tage im Monat wird ein Durchschnittswert
        /// (365.25 / 12) verwendet.
        ///
        /// Hat eine Phase kein Abschlussdatum und das Datum "PhaseVon + Laufzeit eines ihr zugewiesenen DLPs"
        /// ist kleiner als das Such-Enddatum, dann wird das Datum der Max. Laufzeit zur Berechnung verwendet
        /// und das "Abgelaufen"-Flag gesetzt.
        /// </summary>
        /// <param name="searchParams">Enthält die Suchparemeter</param>
        /// <returns>Liste mit DTOs</returns>
        public IList<FsDienstleistungAuswertungDTO> RunQuery(FsDienstleistungAuswSearchParamDTO searchParams)
        {
            return FindData(searchParams);
        }

        public IServiceResult<IEnumerable<FsDienstleistungAuswertungGesamtDTO>> RunQuery(DateRangeSearchParamDTO searchParams)
        {
            var result = new ServiceResult<IEnumerable<FsDienstleistungAuswertungGesamtDTO>>(ServiceResultType.Ok);

            var datumVon = searchParams.DatumVon;
            var datumBis = searchParams.DatumBis;

            if (datumVon > datumBis)
            {
                result.AddEntry(ServiceResultType.Error, "Das VON-Datum darf nicht grösser als das BIS-Datum sein.");
                return result;
            }

            var fsVerfuegbareArbeitszeitService = Container.Resolve<FsVerfuegbareArbeitszeitService>();
            using (var unitOfWork = (IKissUnitOfWork)CreateNewUnitOfWork())
            {
                var timePeriod = new TimePeriod(searchParams.DatumVon, searchParams.DatumBis);

                result.Result = (from auswertung in unitOfWork.FaPhase.GetPhasenDienstleistungAuswertung(searchParams.DatumVon, searchParams.DatumBis)
                                 let data = FindData(unitOfWork, auswertung.UserId, searchParams.DatumVon, searchParams.DatumBis)
                                 select new FsDienstleistungAuswertungGesamtDTO
                                            {
                                                UserId = auswertung.UserId,
                                                Mitarbeiter = auswertung.Mitarbeiter,
                                                Team = auswertung.Team,
                                                AnzahlDlpBedarf = auswertung.AnzahlDlpBedarf,
                                                AnzahlDlpZugewiesen = auswertung.AnzahlDlpZugewiesen,
                                                AnzahlPhasenBeratung = auswertung.AnzahlPhasenBeratung,
                                                AnzahlPhasenIntake = auswertung.AnzahlPhasenIntake,
                                                StdBedarf = data.Sum(x => x.StundenBedarf),
                                                StdFallarbeit = fsVerfuegbareArbeitszeitService.GetMitarbeiterArbeitszeit(unitOfWork, timePeriod, auswertung.UserId),
                                                StdZugewiesen = data.Sum(x => x.StundenZugewiesen),
                                            }).ToList();
            }

            return result;
        }

        public KissServiceResult RunQuery(FsDienstleistungAuswSearchParamDTO searchParams, out IEnumerable<FsDienstleistungAuswertungDTO> result)
        {
            result = null;
            var validationResult = new KissServiceResult(ServiceResultType.Ok);

            if (searchParams.DatumVon > searchParams.DatumBis)
            {
                validationResult += new KissServiceResult(ServiceResultType.Error, "Das VON-Datum darf nicht grösser als das BIS-Datum sein.");
            }

            if (validationResult.IsOk)
            {
                result = FindData(searchParams);
            }

            return validationResult;
        }

        #endregion

        #region Private Methods

        private DateTime AddMonths(DateTime date, decimal months)
        {
            var result = date;

            var nMonths = (int)Math.Truncate(months);
            result = result.AddMonths(nMonths);

            var nDays = (int)((months - nMonths) * DAYS_PER_MONTH);

            // Subtract 1 (i.e. 01.01. + 3.0 Months => 31.03. and not 01.04.)
            return result.AddDays(nDays - 1);
        }

        private IList<FsDienstleistungAuswertungDTO> FindData(FsDienstleistungAuswSearchParamDTO searchParams)
        {
            using (var unitOfWork = (IKissUnitOfWork)CreateNewUnitOfWork())
            {
                return FindData(unitOfWork, searchParams.UserID, searchParams.DatumVon, searchParams.DatumBis);
            }
        }

        private IList<FsDienstleistungAuswertungDTO> FindData(IKissUnitOfWork unitOfWork, int? userId, DateTime datumVon, DateTime datumBis)
        {
            var dlpSum = unitOfWork.FsDienstleistungspaket.GetDlpSum();

            var phasen = unitOfWork.FaPhase.GetPhasenOfUserInPeriod(userId, datumVon, datumBis);

            // Im dritten Schritt berechnen wir pro Phase die Summe der Dienstleistungen, die
            // dem Dienstleistungspaket der Phase zugeordnet sind.
            var result = new List<FsDienstleistungAuswertungDTO>();
            foreach (var phase in phasen)
            {
                var phaseLocal = phase;

                var dto = new FsDienstleistungAuswertungDTO();
                result.Add(dto);

                // Were in DTO abspitzen
                dto.PhaseVon = phase.DatumVon;
                dto.PhaseBis = phase.DatumBis;
                dto.KlientName = phase.BaPersonName + " " + phase.BaPersonVorname;
                dto.FaPhaseID = phase.FaPhaseID;
                dto.BaPersonId = phase.BaPersonID;

                // Info von Dienstleistungspaket holen

                // Wir berechnen die Anzahl Tage, welche sich in der Schnittmenge der beiden
                // Intervalle befinden (Zeitintervall Suche und Zeitintervall Phase).
                bool abgelaufenDlpZugewiesen;
                bool abgelaufenDlpBedarf;

                var dlpZugewiesen = dlpSum.Where(dlp => dlp.FsDienstleistungspaketID == phaseLocal.FsDienstleistungspaketID_Zugewiesen).SingleOrDefault() ?? new DlpSum();
                var tageZugewiesen = GetNumberOfDays(
                    datumVon,
                    datumBis,
                    phase.DatumVon,
                    phase.DatumBis,
                    dlpZugewiesen.Laufzeit,
                    out abgelaufenDlpZugewiesen);

                var dlpBedarf = dlpSum.Where(dlp => dlp.FsDienstleistungspaketID == phaseLocal.FsDienstleistungspaketID_Bedarf).SingleOrDefault() ?? new DlpSum();
                var tageBedarf = GetNumberOfDays(
                    datumVon,
                    datumBis,
                    phase.DatumVon,
                    phase.DatumBis,
                    dlpBedarf.Laufzeit,
                    out abgelaufenDlpBedarf);

                // Nun bilden wir die Summe
                dto.StundenZugewiesen = (dlpZugewiesen.Sum / DAYS_PER_MONTH) * tageZugewiesen;
                dto.StundenBedarf = (dlpBedarf.Sum / DAYS_PER_MONTH) * tageBedarf;

                // Abgelaufen-Flag setzen
                dto.AbgelaufenDlpZugewiesen = abgelaufenDlpZugewiesen;
                dto.AbgelaufenDlpBedarf = abgelaufenDlpBedarf;

                dto.BeschreibungDlpZugewiesen = dlpZugewiesen.Name;
                dto.BeschreibungDlpBedarf = dlpBedarf.Name;
            }

            return result;
        }

        /// <summary>
        /// Berechnet die Anzahl Tage, welche sich in der Schnittmenge der beiden Intervalle befinden und vor der maximalen DLP-Laufzeit liegen.
        /// </summary>
        /// <param name="queryVon">DatumVon von der Abfrage.</param>
        /// <param name="queryBis">DatumBis von der Abfrage.</param>
        /// <param name="phaseVon">DatumVon von der Phase.</param>
        /// <param name="phaseBis">DatumBis von der Phase. Kann null sein.</param>
        /// <param name="dlpLaufzeit">Die Laufzeit des DLPs in Monaten.</param>
        /// <param name="abgelaufen"><c>True</c>, wenn die Laufzeit des DLP als Enddatum der Berechnung verwendet wurde.</param>
        /// <returns></returns>
        private decimal GetNumberOfDays(
            DateTime queryVon,
            DateTime queryBis,
            DateTime phaseVon,
            DateTime? phaseBis,
            decimal? dlpLaufzeit,
            out bool abgelaufen)
        {
            abgelaufen = false;

            var von = queryVon.Date;
            var bis = queryBis.Date.AddDays(1);

            if (phaseVon > von)
            {
                von = phaseVon;
            }

            if (phaseBis != null && phaseBis < bis)
            {
                bis = phaseBis.Value;
            }
            else if (dlpLaufzeit != null)
            {
                // Laufzeit des DLPs miteinbeziehen
                var laufzeitBis = AddMonths(phaseVon, dlpLaufzeit.Value);

                // Wenn Laufzeit vor Suchdatum zu Ende, dann nur bis zu diesem Datum rechnen
                if (phaseBis == null && laufzeitBis < queryBis)
                {
                    bis = laufzeitBis.AddDays(1);
                    abgelaufen = true;
                }
            }

            var total = Convert.ToDecimal((bis.Date - von.Date).TotalDays);

            // Nur positive Anzahl
            return total < 0 ? 0 : total;
        }

        #endregion

        #endregion
    }
}