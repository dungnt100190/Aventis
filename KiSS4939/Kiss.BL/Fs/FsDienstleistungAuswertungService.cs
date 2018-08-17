using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using Kiss.Model;
using Kiss.Model.DTO;
using Kiss.Model.DTO.Fs;

namespace Kiss.BL.Fs
{
    public class FsDienstleistungAuswertungService : ServiceBase
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const decimal DAYS_PER_MONTH = (decimal)(365.25 / 12.0);
        private readonly FsVerfuegbareArbeitszeitService _fsVerfuegbareArbeitszeitService;

        #endregion

        #endregion

        #region Constructors

        private FsDienstleistungAuswertungService()
        {
            _fsVerfuegbareArbeitszeitService = Container.Resolve<FsVerfuegbareArbeitszeitService>();
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

        public KissServiceResult RunQuery(DateRangeSearchParamDTO searchParams, out IList<FsDienstleistungAuswertungGesamtDTO> resultDtos)
        {
            var result = KissServiceResult.Ok();
            resultDtos = new List<FsDienstleistungAuswertungGesamtDTO>();

            var datumVon = searchParams.DatumVon;
            var datumBis = searchParams.DatumBis;

            if (datumVon > datumBis)
            {
                result += new KissServiceResult(ServiceResultType.Error, "Das VON-Datum darf nicht grösser als das BIS-Datum sein.");
                return result;
            }

            var unitOfWork = UnitOfWork.GetNew;
            var xUser = UnitOfWork.GetRepository<XUser>(unitOfWork);
            var faPhase = UnitOfWork.GetRepository<FaPhase>(unitOfWork);
            var xOrgUnit = UnitOfWork.GetRepository<XOrgUnit>(unitOfWork);
            var xOrgUnitUser = UnitOfWork.GetRepository<XOrgUnit_User>(unitOfWork);

            var phasen = from phase in faPhase
                         where phase.DatumVon <= datumBis
                         where phase.DatumBis == null || phase.DatumBis >= datumVon
                         select phase;

            // Team bestimmen
            var dtos = from user in xUser
                       join orgUnitUser in xOrgUnitUser on user.UserID equals orgUnitUser.UserID
                       join orgUnit in xOrgUnit on orgUnitUser.OrgUnitID equals orgUnit.OrgUnitID
                       let anzahlIntake = phasen.Count(x => x.UserID == user.UserID && x.FaPhaseCode == 1)
                       let anzahlBeratung = phasen.Count(x => x.UserID == user.UserID && x.FaPhaseCode == 2)
                       where orgUnitUser.OrgUnitMemberCode == 2 // Mitglied
                       where (anzahlIntake > 0 || anzahlBeratung > 0)
                       select new
                              {
                                  User = user,
                                  AnzahlDlpBedarf = phasen.Count(x => x.UserID == user.UserID && x.FsDienstleistungspaketID_Bedarf != null),
                                  AnzahlDlpZugewiesen = phasen.Count(x => x.UserID == user.UserID && x.FsDienstleistungspaketID_Zugewiesen != null),
                                  AnzahlPhasenIntake = anzahlIntake,
                                  AnzahlPhasenBeratung = anzahlBeratung,
                                  Team = orgUnit.ItemName,
                              };

            var timePeriod = new TimePeriod(searchParams.DatumVon, searchParams.DatumBis);

            foreach (var item in dtos)
            {
                var userId = item.User.UserID;
                var data = FindData(userId, searchParams.DatumVon, searchParams.DatumBis);

                decimal stdFallarbeit;
                result += _fsVerfuegbareArbeitszeitService.GetMitarbeiterArbeitszeit(unitOfWork, out stdFallarbeit, timePeriod, userId);

                var dto = new FsDienstleistungAuswertungGesamtDTO
                          {
                              AnzahlDlpBedarf = item.AnzahlDlpBedarf,
                              AnzahlDlpZugewiesen = item.AnzahlDlpZugewiesen,
                              AnzahlPhasenBeratung = item.AnzahlPhasenBeratung,
                              AnzahlPhasenIntake = item.AnzahlPhasenIntake,
                              Mitarbeiter = item.User.LastNameFirstName,
                              StdBedarf = data.Sum(x => x.StundenBedarf),
                              StdFallarbeit = stdFallarbeit,
                              StdZugewiesen = data.Sum(x => x.StundenZugewiesen),
                              Team = item.Team,
                              UserId = userId
                          };

                resultDtos.Add(dto);
            }

            return result;
        }

        public KissServiceResult RunQuery(FsDienstleistungAuswSearchParamDTO searchParams, out IList<FsDienstleistungAuswertungDTO> result)
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
            return FindData(searchParams.UserID, searchParams.DatumVon, searchParams.DatumBis);
        }

        private IList<FsDienstleistungAuswertungDTO> FindData(int? userId, DateTime datumVon, DateTime datumBis)
        {
            var unitOfWork = UnitOfWork.GetNew;
            var faPhasen = UnitOfWork.GetRepository<FaPhase>(unitOfWork);
            var fsDlps = UnitOfWork.GetRepository<FsDienstleistungspaket>(unitOfWork);

            var dlpSum = (from dlp in fsDlps
                          let dl = dlp.FsDienstleistung_FsDienstleistungspaket.Select(x => x.FsDienstleistung)
                          select new DlpSum
                          {
                              FsDienstleistungspaketID = dlp.FsDienstleistungspaketID,
                              Name = dlp.Name,
                              Laufzeit = dlp.MaximaleLaufzeit,
                              Sum = dl.Count() == 0 ? 0 : dl.Sum(x => x.StandardAufwand),
                          }).ToList();

            var phasen = from phase in faPhasen
                         where phase.DatumVon <= datumBis
                         where phase.DatumBis == null || phase.DatumBis >= datumVon
                         where phase.UserID == userId || userId == null
                         select new
                         {
                             phase.FaPhaseID,
                             phase.FaLeistung.BaPersonID,
                             phase.DatumVon,
                             phase.DatumBis,
                             BaPersonVorname = phase.FaLeistung.BaPerson.Vorname,
                             BaPersonName = phase.FaLeistung.BaPerson.Name,
                             phase.FsDienstleistungspaketID_Zugewiesen,
                             phase.FsDienstleistungspaketID_Bedarf,
                         };

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

    internal class DlpSum
    {
        #region Properties

        public int FsDienstleistungspaketID
        {
            get;
            set;
        }

        public decimal? Laufzeit
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public decimal Sum
        {
            get;
            set;
        }

        #endregion
    }
}