using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using Kiss.BL.Kbu;
using Kiss.Infrastructure;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.BL;
using Kiss.Model;
using Kiss.Model.DTO.Kbu;

using KiSS.Common.Exceptions;

namespace Kiss.BL.Wsh
{
    /// <summary>
    /// Service to manage an TEntity
    /// </summary>
    public class WshKbuKontoService : ServiceCRUDBase<KbuKonto>
    {
        #region Methods

        #region Public Methods

        /// <summary>
        /// Lädt einen Datensatz aufgrund der ID.
        /// </summary>
        /// <param name="unitOfWork">Die UnitOfWork.</param>
        /// <param name="id">Die ID des Datensatzes.</param>
        /// <returns>Der Datensatz mit der angegebenen ID.</returns>
        public override KbuKonto GetById(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<KbuKonto>(unitOfWork);

            var returnValue = repository
                .Where(konto => konto.KbuKontoID == id)
                .SingleOrDefault();

            if (returnValue == null)
            {
                throw new EntityNotFoundException("no entity of 'KbuKonto' found with id: " + id);
            }

            SetEntityValidator(returnValue);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        /// <summary>
        /// Berechnet den SysEditMode für das Feld Betrifft-Person einer Budgetposition
        /// (Monat- oder Grundbudget).
        /// 
        /// - in den Budgets für die Position eine Person ausgewählt werden muss. (zwingend)
        /// - keine Person ausgewählt werden darf (gesperrt, UE immer)
        /// - eine Person oder UE ausgewählt werden darf.
        /// - Quoting ist stärker als SysEditMode_Betrifft Person.       
        /// - Zwingend ist stärker als Gesperrt.
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="kbuKontoId"></param>
        /// <param name="datumVon"></param>
        /// <param name="datumBis"></param>
        /// <returns></returns>
        public LOVsGenerated.SysEditMode GetSysEditModeBetrifftPerson(IUnitOfWork unitOfWork, int kbuKontoId, DateTime? datumVon, DateTime? datumBis)
        {
            //Bei KontoID 0 geben wir freiwillig zurück
            if (kbuKontoId <= 0)
            {
                return LOVsGenerated.SysEditMode.Normal;
            }

            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            //Konto Suchen
            var repository = UnitOfWork.GetRepository<KbuKonto>(unitOfWork);
            var konto = repository.Where(x => x.KbuKontoID == kbuKontoId).Include(x => x.WshKontoAttribut).Single();

            //Quoting ist die stärkste Regel
            if (!konto.Quoting)
            {
                return LOVsGenerated.SysEditMode.Required;
            }

            var wshKontoAttribut = konto.WshKontoAttribut.SingleOrDefault();
            if (wshKontoAttribut != null && Enum.IsDefined(typeof(LOVsGenerated.SysEditMode), wshKontoAttribut.SysEditModeCode_BetrifftPerson))
            {
                return (LOVsGenerated.SysEditMode)wshKontoAttribut.SysEditModeCode_BetrifftPerson;
            }
            return LOVsGenerated.SysEditMode.Normal;
        }

        /// <summary>
        /// Überprüft, ob für den aktuellen User die Kombination 
        /// KbuKonto und WshKategorie für eine Position zugelassen ist.
        /// </summary>
        /// <param name="unitOfWork">null übergeben.</param>
        /// <param name="validationDTO"></param>
        /// <returns></returns>
        public KissServiceResult IsValidKbuKontoWshKategorieKombination(IUnitOfWork unitOfWork, KbuKontoValidationDTO validationDTO)
        {
            var validationResult = KissServiceResult.Ok();

            //Falls der Knopf neue Ausgabe im Monatsbudget gedrückt wird,
            //ist noch kein Konto ausgewählt. Leider kommt er trotzdem in die Speichern-Routine.
            //Wir werten das nun als gültige Kombination.
            if(validationDTO.KbuKontoID <= 0)
            {
                return validationResult;
            }

            unitOfWork = UnitOfWork.GetNew; //Hack. Wenn objekt schon im Kontext ist, kann repository.ApplyChanges nicht ausgeführt werden (Exception).
            var repository = UnitOfWork.GetRepository<KbuKonto>(unitOfWork);

            //Spezialrecht auflösen.
            var hatSpezialrecht = KbuKontoService.HatSpezialrechtMultifunktionalesVorzeichen(unitOfWork);

            var result = (from x in repository
                          let kontoKategorie = x.WshKategorie_KbuKonto.FirstOrDefault(y => y.WshKategorieID == validationDTO.WshKategorieID)
                          where x.KbuKontoID == validationDTO.KbuKontoID
                          select new
                          {
                              Konto = x,
                              KontoAttribut = x.WshKontoAttribut.FirstOrDefault(),
                              WshKategorie_KbuKonto = kontoKategorie,
                          }).Single();

            //Überprüfen, ob es die Kombination gibt.
            if (result.WshKategorie_KbuKonto == null)
            {
                string message = "Die KOA {0} kann für die Kategorie {1} nicht ausgewählt werden.";
                return new KissServiceResult(KissServiceResult.ResultType.Error, string.Format(message, result.Konto.KontoNr, (LOVsGenerated.WshKategorie)validationDTO.WshKategorieID));
            }

            //Ist Spezialrecht nötig?
            if (result.WshKategorie_KbuKonto.NurMitSpezialrecht && !hatSpezialrecht)
            {
                string message = "Die KOA {0} kann für die Kategorie {1} nur mit Spezialrecht ausgewählt werden.";
                return new KissServiceResult(KissServiceResult.ResultType.Error, string.Format(message, result.Konto.KontoNr, (LOVsGenerated.WshKategorie)validationDTO.WshKategorieID));
            }

            //WshKontoAttribute prüfen.
            if (result.KontoAttribut == null)
            {
                string message = "Für die KOA {0} existiert keine Konfiguration.";
                return new KissServiceResult(KissServiceResult.ResultType.Error, string.Format(message, result.Konto.KontoNr));
            }

            //Bei nicht gequoteten Kontos muss eine Person ausgewählt werden.
            if (!result.Konto.Quoting && !validationDTO.PersonAusgewaehlt)
            {
                string message = "Bei der nicht gequoteten KOA {0} muss eine Person ausgewählt werden";
                validationResult += new KissServiceResult(KissServiceResult.ResultType.Error, string.Format(message, result.Konto.KontoNr));
            }


            if (validationDTO.Grundbudget && !result.KontoAttribut.IstGrundbudgetAktiv)
            {
                string message = "Die KOA {0} kann im Grundbudget nicht verwendet werden";
                validationResult += new KissServiceResult(KissServiceResult.ResultType.Error, string.Format(message, result.Konto.KontoNr));
            }

            if (validationDTO.Monatsbudget && !result.KontoAttribut.IstMonatsbudgetAktiv)
            {
                string message = "Die KOA {0} kann im Monatsbudget nicht verwendet werden";
                validationResult += new KissServiceResult(KissServiceResult.ResultType.Error, string.Format(message, result.Konto.KontoNr));
            }

            if (validationDTO.LeistungWsh && !result.KontoAttribut.IstLeistungWsh)
            {
                string message = "Die KOA {0} kann in WSH Leistungen nicht verwendet werden";
                validationResult += new KissServiceResult(KissServiceResult.ResultType.Error, string.Format(message, result.Konto.KontoNr));
            }

            if (validationDTO.LeistungWshStationaer && !result.KontoAttribut.IstLeistungWshStationaer)
            {
                string message = "Die KOA {0} kann in WSH Leistungen nicht verwendet werden";
                validationResult += new KissServiceResult(KissServiceResult.ResultType.Error, string.Format(message, result.Konto.KontoNr));
            }

            if (result.Konto.Quoting && result.KontoAttribut.SysEditModeCode_BetrifftPerson == (int)LOVsGenerated.SysEditMode.Required && !validationDTO.PersonAusgewaehlt)
            {
                string message = "Bei der KOA {0} muss eine Person ausgewählt werden";
                validationResult += new KissServiceResult(KissServiceResult.ResultType.Error, string.Format(message, result.Konto.KontoNr));
            }

            if (result.Konto.Quoting && result.KontoAttribut.SysEditModeCode_BetrifftPerson == (int)LOVsGenerated.SysEditMode.ReadOnly && validationDTO.PersonAusgewaehlt)
            {
                string message = "Bei der KOA {0} darf keine Person ausgewählt werden";
                validationResult += new KissServiceResult(KissServiceResult.ResultType.Error, string.Format(message, result.Konto.KontoNr));
            }

            return validationResult;
        }

        /// <summary>
        /// Suche nach Konto. Das Resultat ist anhand der Konfiguration eingeschränkt:
        /// - WshKontoAttribut
        /// - WshKategorie_KbuKonto
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="searchParam"></param>
        /// <returns></returns>
        public IList<KbuKonto> SearchKonto(IUnitOfWork unitOfWork, KbuKontoSearchDTO searchParam)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<KbuKonto>(unitOfWork);

            //Spezialrecht auflösen.
            bool hatSpezialrecht = KbuKontoService.HatSpezialrechtMultifunktionalesVorzeichen(unitOfWork);

            int kbuKontoKlasseCodeAufwand = (int) LOVsGenerated.KbuKontoklasse.Aufwand;
            int kbuKontoKlasseCodeErtrag = (int) LOVsGenerated.KbuKontoklasse.Ertrag;

            IQueryable<KbuKonto> query = from x in repository
                                         let kontoKategorie = x.WshKategorie_KbuKonto.Where(k => k.WshKategorieID == (int)searchParam.WshKategorie).FirstOrDefault()
                                         let kontoAttribut = x.WshKontoAttribut.FirstOrDefault()
                                         where kontoAttribut != null
                                         where kontoKategorie != null

                                         //Einschränkungen auf WshKontoAttribut
                                         where !searchParam.Grundbudget || kontoAttribut.IstGrundbudgetAktiv
                                         where !searchParam.Monatsbudget || kontoAttribut.IstMonatsbudgetAktiv
                                         where !searchParam.LeistungWsh || kontoAttribut.IstLeistungWsh
                                         where !searchParam.LeistungWshStationaer || kontoAttribut.IstLeistungWshStationaer

                                         //Einschränkung auf KbuKonto_KbuKontoTyp
                                         where !searchParam.ZulageOderGBL || x.KbuKonto_KbuKontoTyp.Any(kt => kt.KbuKontoTypCode == (int)LOVsGenerated.KbuKontoTyp.Zulagen
                                                                                                            || kt.KbuKontoTypCode == (int)LOVsGenerated.KbuKontoTyp.GBL)

                                         //KbuKontoKlasse
                                         where x.KbuKontoklasseCode == kbuKontoKlasseCodeAufwand || x.KbuKontoklasseCode == kbuKontoKlasseCodeErtrag                              

                                         //Einschränkungen auf WshKategorie_KbuKonto
                                         where !kontoKategorie.NurMitSpezialrecht || hatSpezialrecht                                         

                                         select x;

            //SearchString analysiren
            if (!(string.IsNullOrEmpty(searchParam.SearchString) || "*" == searchParam.SearchString))
            {
                Regex regex = new Regex(@"\d+");
                MatchCollection mc = regex.Matches(searchParam.SearchString);
                if (mc.Count == 0)
                {
                    query = query.Where(x => x.Name.Contains(searchParam.SearchString));
                }
                else
                {
                    string kontonr = mc[0].Value;
                    query = query.Where(x => x.KontoNr.StartsWith(kontonr));
                }
            }

            var result = query.ToList();
            result.ForEach(SetEntityValidator);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return result;
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Stellt fest, ob es eine Intervallüberlappung gibt.
        /// </summary>
        /// <param name="von1"></param>
        /// <param name="bis1"></param>
        /// <param name="von2"></param>
        /// <param name="bis2"></param>
        /// <returns></returns>
        private static bool IntervalIsOverlapping(DateTime von1, DateTime? bis1, DateTime von2, DateTime? bis2)
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

        #endregion

        #endregion
    }
}