using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Kiss.BL.Kbu;
using Kiss.Infrastructure;
using Kiss.Infrastructure.Constant;
using Kiss.Infrastructure.Utils;
using Kiss.Interfaces;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.Database;
using Kiss.Interfaces.IoC;
using Kiss.Model;

namespace Kiss.BL.Wsh
{
    /// <summary>
    ///  Service zum Übertragen des Grundbudgets in das 
    ///  Monatsbudget. 
    /// </summary>
    public class WshGrundbudgetUebertragenService : ServiceBase
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly List<string> _zuUebertragenPropertyNames = new List<string>();

        private const string Q_GRAUE_POSITIONEN_LOESCHEN = "WshGrundbudgetUebertragenService.GrauePositionenLoeschen";

        #endregion

        #endregion

        #region Constructors

        private WshGrundbudgetUebertragenService()
        {
            var gbp = new WshGrundbudgetPosition();
            _zuUebertragenPropertyNames.Add(PropertyName.GetPropertyName(() => gbp.KbuKontoID));
            _zuUebertragenPropertyNames.Add(PropertyName.GetPropertyName(() => gbp.Text));
            _zuUebertragenPropertyNames.Add(PropertyName.GetPropertyName(() => gbp.BaPersonID));
            _zuUebertragenPropertyNames.Add(PropertyName.GetPropertyName(() => gbp.BetragMonatlich));
            _zuUebertragenPropertyNames.Add(PropertyName.GetPropertyName(() => gbp.BetragTotal));
            _zuUebertragenPropertyNames.Add(PropertyName.GetPropertyName(() => gbp.KbuAuszahlungArtCode));
            _zuUebertragenPropertyNames.Add(PropertyName.GetPropertyName(() => gbp.WshPeriodizitaetCode));
            _zuUebertragenPropertyNames.Add(PropertyName.GetPropertyName(() => gbp.FaelligAm));
            _zuUebertragenPropertyNames.Add(PropertyName.GetPropertyName(() => gbp.Bemerkung));
            _zuUebertragenPropertyNames.Add(PropertyName.GetPropertyName(() => gbp.VerwaltungSD));
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Berechnet das Valutadatum einer Monatsbudgetposition aufgrund dessen MonatVon und der Grundbudgetposition
        /// </summary>
        /// <param name="grundbudgetFaelligAm"></param>
        /// <param name="grundbudgetDatumVon"></param>
        /// <param name="monatsbudgetMonatVon"></param>
        /// <returns></returns>
        public static DateTime? CalculateMonthFaelligAm(DateTime? grundbudgetFaelligAm, DateTime grundbudgetDatumVon, DateTime monatsbudgetMonatVon)
        {
            if (!grundbudgetFaelligAm.HasValue)
            {
                return null;
            }

            var gbMonatVon = new MonthYear(grundbudgetDatumVon);
            var mbMonatVon = new MonthYear(monatsbudgetMonatVon);
            var monthsToAdd = MonthYear.GetMonthDiff(gbMonatVon, mbMonatVon);

            return grundbudgetFaelligAm.Value.AddMonths(monthsToAdd);
        }

        /// <summary>
        /// Berechnet den Betrag der Monatsposition.
        /// GBL wird taggenau berechnet, alle anderen Positionen nicht.
        /// </summary>
        /// <param name="grundbudgetPosition"></param>
        /// <param name="budgetMonat"></param>
        /// <returns></returns>
        public static decimal PositionsBetragBerechnen(WshGrundbudgetPosition grundbudgetPosition, DateTime budgetMonat)
        {
            int gblKbuKontoTypCode = 1; //LOVsGenerated.KbuKontoTyp
            if (grundbudgetPosition.KbuKonto.KbuKonto_KbuKontoTyp.Count() > 0)
            {
                if (grundbudgetPosition.KbuKonto.KbuKonto_KbuKontoTyp.Any(x => x.KbuKontoTypCode == gblKbuKontoTypCode)
                    && grundbudgetPosition.Berechnet)
                {
                    DateTime leistungVon = grundbudgetPosition.FaLeistung.DatumVon;
                    var rundungsService = Container.Resolve<KbuGeldbetragRundungsService>();

                    if (leistungVon.Month == budgetMonat.Month && leistungVon.Year == budgetMonat.Year)
                    {
                        DateTime lastDayOfMonth = LastDayOfMonth(budgetMonat);
                        int days = (lastDayOfMonth - leistungVon).Days + 1;
                        int daysInMonth = DateTime.DaysInMonth(budgetMonat.Year, budgetMonat.Month);
                        double factor = (days) / ((double)daysInMonth);
                        double resultDouble = factor * ((double)grundbudgetPosition.BetragMonatlich);
                        decimal result = rundungsService.GeldbetragRunden((decimal)resultDouble);
                        return result;
                    }
                }
            }

            return grundbudgetPosition.BetragMonatlich;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// GBL Betrag vom entsprechenden Monatsbudget anpassen, wenn sich das Datum der Leistung geändert hat.
        /// Ebenfalls wird die VerwendungsperiodeVon auf das Datum der Leistung gesetzt.
        /// Das Datum LeistungVon kann nur innerhalb eines Monates geschoben werden,
        /// darum ist die Anpassung einfach.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="faLeistungID"></param>
        /// <param name="leistungVon"></param>
        /// <returns></returns>
        public KissServiceResult GblAnLeistungAnpassen(IUnitOfWork unitOfWork, int faLeistungID, DateTime leistungVon)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            //Position finden.
            IRepository<WshPosition> repositoryPosition = UnitOfWork.GetRepository<WshPosition>(unitOfWork);
            IQueryable<WshPosition> query = from x in repositoryPosition
                                                .Include(x => x.WshGrundbudgetPosition)
                                                .Include(x => x.WshGrundbudgetPosition.KbuKonto)
                                                .Include(x => x.WshGrundbudgetPosition.KbuKonto.SubInclude(y => y.KbuKonto_KbuKontoTyp))
                                                .Include(x => x.FaLeistung)
                                                .Include(x => x.KbuKonto)
                                                .Include(x => x.KbuKonto.KbuKonto_KbuKontoTyp)
                                            where x.FaLeistungID == faLeistungID
                                            where x.MonatVon <= leistungVon
                                            where x.MonatBis >= leistungVon
                                            where
                                                x.KbuKonto.KbuKonto_KbuKontoTyp.Any(
                                                    y => y.KbuKontoTypCode == (int)LOVsGenerated.KbuKontoTyp.GBL)
                                            where x.WshGrundbudgetPosition != null && x.WshGrundbudgetPosition.Berechnet
                                            select x;

            WshPosition position = query.FirstOrDefault();
            if (position != null)
            {
                var budgetMonat = new DateTime(leistungVon.Year, leistungVon.Month, 1);
                position.Betrag = PositionsBetragBerechnen(position.WshGrundbudgetPosition, budgetMonat);
                position.VerwPeriodeVon = leistungVon;
                repositoryPosition.ApplyChanges(position);
                unitOfWork.SaveChanges();
            }

            return KissServiceResult.Ok();
        }

        /// <summary>
        /// Überträgt eine GrundbudgetPosition in die Monatsbudgets.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="wshGrundBudgetPositionID"></param>
        /// <param name="date">
        ///   Ab diesem Datum werden Grundbudgetpositionen erstellt. 
        ///   - diesen Monat nur GBL
        ///   - nächste zwei Monate         
        /// </param>
        /// <param name="modifiedProperties"></param>
        /// <param name="questionsAndAnswers"></param>
        /// <returns></returns>
        public KissServiceResult PositionInMonatsbudgetUebertragen(
            IUnitOfWork unitOfWork,
            int wshGrundBudgetPositionID,
            DateTime date,
            List<PropertyInfo> modifiedProperties,
            Dictionary<string, QuestionAnswerOption> questionsAndAnswers
            )
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            KissServiceResult result = KissServiceResult.Ok();

            //Existiernede Monatspositionen anpassen. Es werden nur graue Positionen angepasst.
            //Graue Positionen haben keine Verknüpfung mit einer Belegposition.
            IRepository<WshPosition> repositoryPos = UnitOfWork.GetRepository<WshPosition>(unitOfWork);
            var existierendeMonatspositionen = repositoryPos
                .Include(x => x.WshPositionKreditor)
                .Include(x => x.WshPositionDebitor)
                .Include(x => x.KbuBelegPosition)
                .Include(x => x.WshKategorie)
                .Where(x => x.WshGrundbudgetPositionID == wshGrundBudgetPositionID)
                .ToList();

            IRepository<WshGrundbudgetPosition> repositoryGrundPos = UnitOfWork.GetRepository<WshGrundbudgetPosition>(unitOfWork);
            WshGrundbudgetPosition grundbudgetPosition = repositoryGrundPos
                .Include(x => x.WshGrundbudgetPositionKreditor)
                .Include(x => x.WshGrundbudgetPositionDebitor)
                .Include(x => x.KbuKonto)
                .Include(x => x.KbuKonto.KbuKonto_KbuKontoTyp)
                .Include(x => x.FaLeistung)
                .Include(x => x.WshKategorie)
                .Where(x => x.WshGrundbudgetPositionID == wshGrundBudgetPositionID)
                .First();

            foreach (WshPosition wshPosition in existierendeMonatspositionen)
            {
                //Nur graue Belege anpassen. Graue Abzüge mit Betrag 0 nicht anpassen.
                if (wshPosition.KbuBelegPosition.Count == 0)
                {
                    result += MonatsPositionAnpassen(unitOfWork, grundbudgetPosition, wshPosition, date, modifiedProperties, questionsAndAnswers);
                }
            }

            //Noch nicht erstellte Positionen erstellen
            List<DateTime> dateList = CalcWshPositionsMonthYearDates(unitOfWork, grundbudgetPosition, date, grundbudgetPosition.FaLeistung.DatumBis);
            foreach (DateTime monat in dateList)
            {
                //Püfen, ob Position bereits erstellt worden ist.
                //Wenn nicht, erstellen wird die MonatsbudgetPosition.
                if (existierendeMonatspositionen
                        .Where(x => x.MonatVon <= monat && x.MonatBis >= monat)
                        .Select(x => x)
                        .Count() == 0)
                {
                    WshPosition wshPosition;
                    result += CreateMonatsPosition(unitOfWork, monat, grundbudgetPosition, out wshPosition);
                    existierendeMonatspositionen.Add(wshPosition);
                }
            }

            // Bei Abzügen Positionen löschen, die über den Totalbetrag hinaus gehen.
            if (grundbudgetPosition.WshKategorie.IstAbzug)
            {
                var positionAbzutDtoService = Container.Resolve<WshPositionAbzugDTOService>();

                // Alle Positionen holen (und Saldo berechnen).
                var positionen = positionAbzutDtoService.GetByWshGrundbudgetPositionId(
                    unitOfWork, grundbudgetPosition.WshGrundbudgetPositionID, grundbudgetPosition.BetragTotal)
                    .OrderByDescending(x => x.WshPosition.MonatVon);

                foreach (var wshPositionAbzugDTO in positionen)
                {
                    if (wshPositionAbzugDTO.Saldo < 0)
                    {
                        if ((wshPositionAbzugDTO.Saldo + wshPositionAbzugDTO.WshPosition.Betrag) <= 0)
                        {
                            // Positionen löschen
                            positionAbzutDtoService.DeleteData(unitOfWork, wshPositionAbzugDTO);
                        }
                        else
                        {
                            // Betrag der Position anpassen
                            wshPositionAbzugDTO.WshPosition.Betrag = wshPositionAbzugDTO.Saldo + wshPositionAbzugDTO.WshPosition.Betrag;
                            positionAbzutDtoService.SaveData(unitOfWork, wshPositionAbzugDTO);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return result;
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Anzahl Monate, die zusätuzlich zum aktuellen Monat übertragen werden sollen.
        /// TODO: In Anzahl Tagen, nicht in Anzahl Monaten.
        /// </summary>
        /// <returns></returns>
        private static int AnzahlMonateBudgetUebertragen(IUnitOfWork unitOfWork)
        {
            //Konfigurationswert auslesen.
            //XConfigService configService = Container.Resolve<XConfigService>();
            //return configService.GetConfigValue<int>(unitOfWork, "BlaBlaBla");
            return 3;
        }

        private static TimePeriod CalculateVerwendungsperiode(WshPosition wshPosition)
        {
            try
            {
                var splittingart = GetSplittingart(wshPosition);
                if (splittingart == LOVsGenerated.WshSplittingart.Entscheid)
                {
                    var datumEntscheid = GetDatumEntscheid(wshPosition);
                    if (datumEntscheid.HasValue)
                    {
                        return new TimePeriod(datumEntscheid.Value, datumEntscheid.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                // ToDo: Log
                System.Diagnostics.Trace.TraceError(ex.Message);
            }

            // default: Verwendungsperiode = MonatVon - MonatBis
            return new TimePeriod(wshPosition.MonatVon, wshPosition.MonatBis);
        }

        private static DateTime? GetDatumEntscheid(WshPosition wshPosition)
        {
            var grundbudgetPosition = wshPosition.WshGrundbudgetPosition;
            if (grundbudgetPosition == null && wshPosition.WshGrundbudgetPositionID.HasValue)
            {
                var grundbudgetService = Container.Resolve<WshGrundbudgetPositionDTOService>();
                grundbudgetPosition = grundbudgetService.GetById(null, wshPosition.WshGrundbudgetPositionID.Value);
            }

            if (grundbudgetPosition == null)
            {
                // ToDo: Log
                System.Diagnostics.Trace.TraceWarning("Keine Grundbudgetposition bestimmbar für WshPosition mit ID {0}", wshPosition.WshPositionID);
                return null;
            }

            return grundbudgetPosition.DatumEntscheid;
        }

        private static object GetGrundbudgetEntity(WshGrundbudgetPosition wshGrundbudgetPosition, PropertyInfo wshGrundbudgetProperty)
        {
            if (wshGrundbudgetProperty.DeclaringType == typeof(WshGrundbudgetPosition))
            {
                return wshGrundbudgetPosition;
            }

            if (wshGrundbudgetProperty.DeclaringType == typeof(WshGrundbudgetPositionKreditor))
            {
                return wshGrundbudgetPosition.WshGrundbudgetPositionKreditor.Single();
            }

            if (wshGrundbudgetProperty.DeclaringType == typeof(WshGrundbudgetPositionDebitor))
            {
                return wshGrundbudgetPosition.WshGrundbudgetPositionDebitor.Single();
            }

            throw new Exception(string.Format("Grundbudget-Typ {0} wird nicht unterstützt", wshGrundbudgetProperty.DeclaringType));
        }

        private static object GetMonatsbudgetEntity(WshPosition wshPosition, PropertyInfo wshGrundbudgetProperty)
        {
            if (wshGrundbudgetProperty.DeclaringType == typeof(WshGrundbudgetPosition))
            {
                return wshPosition;
            }

            if (wshGrundbudgetProperty.DeclaringType == typeof(WshGrundbudgetPositionKreditor))
            {
                return wshPosition.WshPositionKreditor.Single();
            }

            if (wshGrundbudgetProperty.DeclaringType == typeof(WshGrundbudgetPositionDebitor))
            {
                return wshPosition.WshPositionDebitor.Single();
            }

            throw new Exception(string.Format("Grundbudget-Typ {0} wird nicht unterstützt", wshGrundbudgetProperty.DeclaringType));
        }

        private static PropertyInfo GetMonatsbudgetProperty(PropertyInfo wshGrundbudgetProperty)
        {
            Type monatsbudgetType = GetMonatsbudgetType(wshGrundbudgetProperty.DeclaringType);
            // die zu übertragenen Felder heissen in WshGrundbudgetPosition und WshPoition gleich
            PropertyInfo wshPositionProperty = monatsbudgetType.GetProperty(wshGrundbudgetProperty.Name);
            if (wshPositionProperty == null)
            {
                throw new Exception(string.Format("Typ {0} hat kein Property mit Namen {1}", monatsbudgetType.Name, wshGrundbudgetProperty.Name));
            }

            return wshPositionProperty;
        }

        /// <summary>
        /// Zuordnung der Entitäten von Grundbudget zu Monatsbudget
        ///  WshGrundbudgetPosition         -> WshPosition
        ///  WshGrundbudgetPositionKreditor -> WshPositionKreditor
        ///  WshGrundbudgetPositionDebitor  -> WshPositionDebitor
        /// </summary>
        /// <param name="grundbudgetType"></param>
        /// <returns></returns>
        private static Type GetMonatsbudgetType(Type grundbudgetType)
        {
            if (grundbudgetType == typeof(WshGrundbudgetPosition))
            {
                return typeof(WshPosition);
            }

            if (grundbudgetType == typeof(WshGrundbudgetPositionKreditor))
            {
                return typeof(WshPositionKreditor);
            }

            if (grundbudgetType == typeof(WshGrundbudgetPositionDebitor))
            {
                return typeof(WshPositionDebitor);
            }

            throw new Exception(string.Format("Kein Monatsbudget-Typ gefunden für Grundbudget-Typ {0}", grundbudgetType.Name));
        }

        private static LOVsGenerated.WshSplittingart GetSplittingart(WshPosition wshPosition)
        {
            var konto = wshPosition.KbuKonto;
            if (konto == null)
            {
                var kontoSvc = Container.Resolve<KbuKontoService>();
                konto = kontoSvc.GetById(null, wshPosition.KbuKontoID);
            }

            if (konto == null)
            {
                throw new ArgumentException("Monatsbudgetposition hat kein Konto definiert");
            }

            LOVsGenerated.WshSplittingart splittingart;
            if (!Utils.TryConvertCodeToEnumMember(konto.WshSplittingartCode, out splittingart))
            {
                throw new ArgumentException(string.Format("Konto {0} hat keine Splittingart definiert", konto.DisplayedName));
            }

            return splittingart;
        }

        /// <summary>
        /// Letzter Tag im Monat.
        /// </summary>
        /// <param name="aDayInMonth"></param>
        /// <returns></returns>
        private static DateTime LastDayOfMonth(DateTime aDayInMonth)
        {
            return new DateTime(aDayInMonth.Year, aDayInMonth.Month, 1).AddMonths(1).AddDays(-1);
        }

        /// <summary>
        /// Überträgt die Daten von dem Kreditor Grundbudget
        /// in den Kreditor Monatsbudget. 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="grundBudgetKreditor"></param>
        /// <param name="kreditor"></param>
        /// <returns></returns>        
        private static KissServiceResult UpdateKreditor(
            IUnitOfWork unitOfWork,
            WshGrundbudgetPositionKreditor grundBudgetKreditor,
            WshPositionKreditor kreditor)
        {
            kreditor.BaZahlungsweg = grundBudgetKreditor.BaZahlungsweg;
            kreditor.BaZahlungswegID = grundBudgetKreditor.BaZahlungswegID;
            kreditor.ReferenzNummer = grundBudgetKreditor.ReferenzNummer;
            kreditor.MitteilungZeile1 = grundBudgetKreditor.MitteilungZeile1;
            kreditor.MitteilungZeile2 = grundBudgetKreditor.MitteilungZeile2;
            kreditor.MitteilungZeile3 = grundBudgetKreditor.MitteilungZeile3;
            kreditor.MitteilungZeile4 = grundBudgetKreditor.MitteilungZeile4;

            var kreditorService = Container.Resolve<WshPositionKreditorService>();
            return kreditorService.SaveData(unitOfWork, kreditor);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Berechnet eine Liste von Monaten für die Positionen
        /// im Monatsbudget.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="grundPos"></param>
        /// <param name="datumVon"></param>
        /// <param name="datumBis"></param>
        /// <returns></returns>
        private List<DateTime> CalcWshPositionsMonthYearDates(
            IUnitOfWork unitOfWork,
            WshGrundbudgetPosition grundPos,
            DateTime datumVon,
            DateTime? datumBis)
        {
            var listOfDates = new List<DateTime>();

            var dateIterator = new DateTime(datumVon.Year, datumVon.Month, 1);
            DateTime dateTodayPlusM = DateTime.Today.AddMonths(AnzahlMonateBudgetUebertragen(unitOfWork));
            var dateLast = new DateTime(dateTodayPlusM.Year, dateTodayPlusM.Month, 1);

            if (datumBis.HasValue && datumBis.Value < dateTodayPlusM)
            {
                dateLast = new DateTime(datumBis.Value.Year, datumBis.Value.Month, 1);
            }

            while (dateIterator <= dateLast)
            {
                if (grundPos.DatumVon <= dateIterator && (!grundPos.DatumBis.HasValue || grundPos.DatumBis.Value >= dateIterator))
                {
                    listOfDates.Add(dateIterator);
                }

                dateIterator = dateIterator.AddMonths(1);
            }

            return listOfDates;
        }

        /// <summary>
        /// Erstellt einen Debitor für die Monatsbudget-Position.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="debitor"></param>
        /// <param name="wshPosition"></param>
        /// <returns></returns>
        private KissServiceResult CreateDebitorDerMonatsPosition(IUnitOfWork unitOfWork,
            WshGrundbudgetPositionDebitor debitor,
            WshPosition wshPosition)
        {
            KissServiceResult result = KissServiceResult.Ok();

            var service = Container.Resolve<WshPositionDebitorService>();
            WshPositionDebitor wshPositionDebitor;
            result += service.NewData(out wshPositionDebitor);

            wshPositionDebitor.BaInstitution = debitor.BaInstitution;
            wshPositionDebitor.BaInstitutionID = debitor.BaInstitutionID;
            wshPositionDebitor.BaPerson = debitor.BaPerson;
            wshPositionDebitor.BaPersonID = debitor.BaPersonID;
            wshPositionDebitor.WshPosition = wshPosition;
            wshPositionDebitor.WshPositionID = wshPosition.WshPositionID;

            result += service.SaveData(unitOfWork, wshPositionDebitor);

            return result;
        }

        /// <summary>
        /// Erstellt einen Kreditor für die Monatsbudget-Position.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="wshGrundbudgetPositionKreditor"></param>
        /// <param name="wshPosition"></param>
        /// <returns></returns>
        private KissServiceResult CreateKreditorDerMonatsPosition(IUnitOfWork unitOfWork,
            WshGrundbudgetPositionKreditor wshGrundbudgetPositionKreditor,
            WshPosition wshPosition)
        {
            KissServiceResult result = KissServiceResult.Ok();
            var kreditorService = Container.Resolve<WshPositionKreditorService>();

            WshPositionKreditor wshPositionKreditor;

            result += kreditorService.NewData(out wshPositionKreditor);
            wshPositionKreditor.WshPosition = wshPosition;
            wshPositionKreditor.WshPositionID = wshPosition.WshPositionID;

            result += UpdateKreditor(unitOfWork, wshGrundbudgetPositionKreditor, wshPositionKreditor);

            return result;
        }

        /// <summary>
        /// Erstellt eine Monatsbudgetposition
        /// inklusive Kreditor oder Debitor.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="budgetMonat"></param>
        /// <param name="grundbudgetPosition"></param>
        /// <param name="wshPosition"></param>
        /// <returns></returns>
        private KissServiceResult CreateMonatsPosition(IUnitOfWork unitOfWork,
            DateTime budgetMonat,
            WshGrundbudgetPosition grundbudgetPosition,
            out WshPosition wshPosition)
        {
            KissServiceResult result = KissServiceResult.Ok();

            var posService = Container.Resolve<WshPositionService>();
            posService.NewData(out wshPosition);

            wshPosition.WshGrundbudgetPosition = grundbudgetPosition;
            wshPosition.WshGrundbudgetPositionID = grundbudgetPosition.WshGrundbudgetPositionID;
            wshPosition.FaLeistung = grundbudgetPosition.FaLeistung;
            wshPosition.FaLeistungID = grundbudgetPosition.FaLeistungID;
            wshPosition.BaPerson = grundbudgetPosition.BaPerson;
            wshPosition.BaPersonID = grundbudgetPosition.BaPersonID;
            wshPosition.KbuKonto = grundbudgetPosition.KbuKonto;
            wshPosition.KbuKontoID = grundbudgetPosition.KbuKontoID;
            wshPosition.BaInstitution = grundbudgetPosition.BaInstitution;
            wshPosition.BaInstitutionID = grundbudgetPosition.BaInstitutionID;
            wshPosition.WshKategorie = grundbudgetPosition.WshKategorie;
            wshPosition.WshKategorieID = grundbudgetPosition.WshKategorieID;
            wshPosition.WshBewilligungStatusCode = grundbudgetPosition.WshBewilligungStatusCode;
            wshPosition.KbuAuszahlungArtCode = grundbudgetPosition.KbuAuszahlungArtCode;
            wshPosition.VerwaltungSD = grundbudgetPosition.VerwaltungSD;
            wshPosition.Text = grundbudgetPosition.Text;
            wshPosition.Bemerkung = grundbudgetPosition.Bemerkung;
            wshPosition.WshPeriodizitaetCode = grundbudgetPosition.WshPeriodizitaetCode;
            wshPosition.BetragTotal = grundbudgetPosition.BetragTotal;

            //Betrag berechnen
            //Für GBL wird der Betrag taggenau berechnet.
            wshPosition.Betrag = PositionsBetragBerechnen(grundbudgetPosition, budgetMonat);

            //Bei Periodizität "Quartal" und "Semester" wird "MonatVon" und "MonatBis" anders berechnet.
            if (grundbudgetPosition.WshPeriodizitaetCode.HasValue &&
                (grundbudgetPosition.WshPeriodizitaetCode.Value == (int)LOVsGenerated.WshPeriodizitaet.Quartal
                 || grundbudgetPosition.WshPeriodizitaetCode.Value == (int)LOVsGenerated.WshPeriodizitaet.Semester))
            {
                //Monat von
                wshPosition.MonatVon = budgetMonat;

                //Monat bis Quartal
                if (grundbudgetPosition.WshPeriodizitaetCode.Value == (int)LOVsGenerated.WshPeriodizitaet.Quartal)
                {
                    wshPosition.MonatBis = LastDayOfMonth(budgetMonat.AddMonths(2));
                }

                //Monat bis Semester
                if (grundbudgetPosition.WshPeriodizitaetCode.Value == (int)LOVsGenerated.WshPeriodizitaet.Semester)
                {
                    wshPosition.MonatBis = LastDayOfMonth(budgetMonat.AddMonths(5));
                }

                wshPosition.Betrag = 0;
            }
            //Bei allen anderen dauert es genau ein Monat.
            else
            {
                wshPosition.MonatVon = budgetMonat;
                wshPosition.MonatBis = LastDayOfMonth(budgetMonat);
            }

            //Grundbudgetposition ist berechnet. In diesem Fall ist Verwendungsperiode Von früstens ab dem Leistungsdatum.
            if (grundbudgetPosition.Berechnet &&
                grundbudgetPosition.KbuKonto.KbuKonto_KbuKontoTyp.Any(x => x.KbuKontoTypCode == (int)LOVsGenerated.KbuKontoTyp.GBL)
                && wshPosition.MonatVon < grundbudgetPosition.FaLeistung.DatumVon)
            {
                wshPosition.VerwPeriodeVon = grundbudgetPosition.FaLeistung.DatumVon;
                wshPosition.VerwPeriodeBis = wshPosition.MonatBis;
            }
            else
            {
                var verwendungsperiode = CalculateVerwendungsperiode(wshPosition);
                wshPosition.VerwPeriodeVon = verwendungsperiode.From;
                wshPosition.VerwPeriodeBis = verwendungsperiode.To;
            }

            wshPosition.FaelligAm = CalculateMonthFaelligAm(grundbudgetPosition.FaelligAm, grundbudgetPosition.DatumVon, wshPosition.MonatVon);

            //Warum wird hier nicht die Save Methode vom Service aufgerufen?
            //Da sonst die Validierung fehl schlägt, weil für Auszahlungen ein Kreditor vorhanden sein muss.
            //In dem Fall hier erstellen wir den Kreditor erst später.
            IRepository<WshPosition> repositoryPosition = UnitOfWork.GetRepository<WshPosition>(unitOfWork);
            repositoryPosition.ApplyChanges(wshPosition);
            unitOfWork.SaveChanges();

            //Im Falle einer Ausgabe einen Kreditor anlegen.
            if (grundbudgetPosition.WshGrundbudgetPositionKreditor.Count > 0)
            {
                result += CreateKreditorDerMonatsPosition(unitOfWork, grundbudgetPosition.WshGrundbudgetPositionKreditor.Single(), wshPosition);
            }

            //Im Falle einer Einname einen Debitor anlegen.
            if (grundbudgetPosition.WshGrundbudgetPositionDebitor.Count > 0)
            {
                result += CreateDebitorDerMonatsPosition(unitOfWork, grundbudgetPosition.WshGrundbudgetPositionDebitor.Single(), wshPosition);
            }

            return result;
        }

        /// <summary>
        /// Stellt fest, ob es eine Intervallüberlappung gibt.
        /// </summary>
        /// <param name="von1"></param>
        /// <param name="bis1"></param>
        /// <param name="von2"></param>
        /// <param name="bis2"></param>
        /// <returns></returns>
        private bool IntervalIsOverlapping(DateTime von1, DateTime? bis1, DateTime von2, DateTime? bis2)
        {
            //Monatspositionen, die von Grundbudgetpositionen erzeugt worden sind, haben immer einen
            //Wert in MonatVon und MonatBis (Mussfeld).
            var period1 = new TimePeriod(von1, bis1);
            var period2 = new TimePeriod(von2, bis2);

            if (period1.IsOverlapping(period2))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Aktualisiert eine Position im Monatsbudget anhand der Position im Grundbudget.
        /// Geschäftsregel aus User-Story 7472-018 und nach Besprechung mit Marcel Weber.
        /// - Graue Monatspositionen der Vergangenheit werden gelöscht.
        /// - Graue Monatspositionen, die keine Zeitüberschneidung mit dem DatumVon, DatumBis der
        ///   Grundbudgetposition haben, werden gelöscht. 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="grundPos"></param>
        /// <param name="pos">Graue Monatsbudgetposition</param>
        /// <param name="referenzDatum"></param>
        /// <param name="modifiedProperties"></param>
        /// <param name="questionsAndAnswers"></param>
        /// <returns></returns>
        private KissServiceResult MonatsPositionAnpassen(IUnitOfWork unitOfWork,
            WshGrundbudgetPosition grundPos,
            WshPosition pos,
            DateTime referenzDatum,
            List<PropertyInfo> modifiedProperties,
            Dictionary<string, QuestionAnswerOption> questionsAndAnswers
            )
        {
            var result = KissServiceResult.Ok();

            var istNullBetragAbzug = pos.WshKategorie.IstAbzug && pos.Betrag == 0;

            //Positionen löschen
            if ((pos.MonatBis < referenzDatum) //Graue Position der Vergangenheit.
                || !(IntervalIsOverlapping(pos.MonatVon, pos.MonatBis, grundPos.DatumVon, grundPos.DatumBis)))
            //Graue Positionen ausserhalb der Gültigkeit der Grundbudgetposition
            {
                //Hat Benutzer Löschung der grauen Positionen bestätigt?
                if (!questionsAndAnswers.ContainsKey(Q_GRAUE_POSITIONEN_LOESCHEN))
                {
                    //Benutzer soll Löschung der grauen Positionen bestätigen
                    result += new KissServiceResult(
                        Q_GRAUE_POSITIONEN_LOESCHEN,
                        "Es gibt graue Positionen, welche aufgrund der Datumsänderung ungültig werden. Sollen diese Positionen gelöscht werden?",
                        new List<QuestionAnswerOption> { new QuestionAnswerOption(true, "Ja"), new QuestionAnswerOption(false, "Nein") });
                    return result;
                }

                if ((bool?)(questionsAndAnswers[Q_GRAUE_POSITIONEN_LOESCHEN].Tag) ?? false)
                {
                    var monatsPositionService = Container.Resolve<WshPositionService>();
                    result += monatsPositionService.DeleteData(unitOfWork, pos);

                    return result; //wenn wir die Position gelöscht haben, müssen wir nicht noch Felder anpassen
                }

                return KissServiceResult.Error(
                    new Exception("Datumsänderung kann nicht durchgeführt werden ohne die ungültigen Positionen zu löschen."));
            }

            //Felder anpassen
            if (modifiedProperties != null && modifiedProperties.Count > 0)
            {
                var gbFaelligAmProperty = PropertyName.GetPropertyInfo(() => new WshGrundbudgetPosition().FaelligAm);
                var gbBetragMonatlichProperty = PropertyName.GetPropertyInfo(() => new WshGrundbudgetPosition().BetragMonatlich);

                foreach (var property in modifiedProperties.Where(p => _zuUebertragenPropertyNames.Contains(p.Name)))
                {
                    // Spezialfall: FälligAm wird auf Monatsbudget angepasst
                    if (property == gbFaelligAmProperty)
                    {
                        pos.FaelligAm = CalculateMonthFaelligAm(grundPos.FaelligAm, grundPos.DatumVon, pos.MonatVon);
                    }
                    // Spezialfall 2: GB.BetragMonatlich wird auf MB.Betrag gemappt und mit einer Funktion berechnet
                    else if (property == gbBetragMonatlichProperty)
                    {
                        if (!istNullBetragAbzug)
                        {
                            pos.Betrag = PositionsBetragBerechnen(grundPos, pos.MonatVon);
                        }
                    }
                    else
                    {
                        var wshPositionProperty = GetMonatsbudgetProperty(property);
                        var grundbudgetEntity = GetGrundbudgetEntity(grundPos, property);
                        var monatsbudgetEntity = GetMonatsbudgetEntity(pos, property);
                        wshPositionProperty.SetValue(monatsbudgetEntity, property.GetValue(grundbudgetEntity, null), null);
                    }
                }
            }

            // Bei Abzügen soll der Betrag neu berechnet werden, wenn das MonatlichWiederholend-Flag gesetzt ist.
            if (grundPos.WshKategorie.IstAbzug && !istNullBetragAbzug)
            {
                pos.Betrag = PositionsBetragBerechnen(grundPos, pos.MonatVon);
            }

            var repositoryPosition = UnitOfWork.GetRepository<WshPosition>(unitOfWork);
            repositoryPosition.ApplyChanges(pos);
            unitOfWork.SaveChanges();

            return result;
        }

        #endregion

        #endregion
    }
}