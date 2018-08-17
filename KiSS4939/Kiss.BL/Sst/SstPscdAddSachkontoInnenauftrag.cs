using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.BL.Kbu;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Model;

namespace Kiss.BL.Sst
{
    class SstPscdAddSachkontoInnenauftrag : IKbuBelegVerbuchenPlugin
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly List<KbuKonto> _konti;
        private readonly List<SstPscdSachkontoInnenauftrag> _sachkontoInnenauftrag;

        #endregion

        #endregion

        #region Constructors

        public SstPscdAddSachkontoInnenauftrag()
        {
            var service = Container.Resolve<SstPscdSachkontoInnenauftragService>();
            _sachkontoInnenauftrag = service.GetAll(null);

            var kontoService = Container.Resolve<KbuKontoService>();
            _konti = kontoService.SearchKonto(null, LOVsGenerated.KbuKontoklasse.Aufwand).ToList();
            _konti.AddRange(kontoService.SearchKonto(null, LOVsGenerated.KbuKontoklasse.Ertrag));
            _konti.AddRange(kontoService.SearchKonto(null, LOVsGenerated.KbuKontoklasse.Aktiven));
            _konti.AddRange(kontoService.SearchKonto(null, LOVsGenerated.KbuKontoklasse.Passiven));
        }

        #endregion

        #region Methods

        #region Public Methods

        public KissServiceResult ValidateBeleg(IUnitOfWork unitOfWork, KbuBeleg beleg, DateTime valutaDatum)
        {
            var result = KissServiceResult.Ok();
            var belegpositionen = GetBelegpositionen(unitOfWork, beleg);
            foreach (var kbuBelegPosition in belegpositionen)
            {
                var kbuKontoID = kbuBelegPosition.KbuKontoID;
                var attribute = _sachkontoInnenauftrag.SingleOrDefault(x => x.KbuKontoID == kbuKontoID);
                var kontoNr = GetKontoNr(kbuKontoID);
                if (attribute == null)
                {
                    result += new KissServiceResult(KissServiceResult.ResultType.Error, "SstPscdAddSachkontoInnenauftrag", "Konfigurationsfehler: Sachkonto/Innenauftrag sind für Konto {0} nicht definiert", kontoNr);
                }
                else
                {
                    bool ertragOhneGeldfluss = GetErtragOhneGeldfluss(kbuBelegPosition);
                    var sachkonto = GetSachkonto(attribute, ertragOhneGeldfluss);
                    var innenauftrag = GetInnenauftrag(attribute, ertragOhneGeldfluss);
                    if (string.IsNullOrEmpty(sachkonto))
                    {
                        result += new KissServiceResult(KissServiceResult.ResultType.Error, "SstPscdAddSachkontoInnenauftrag", "Konfigurationsfehler: Sachkonto ist für Konto {0} nicht definiert", kontoNr);
                    }
                    if (string.IsNullOrEmpty(innenauftrag) && !kbuBelegPosition.HauptPosition)
                    {
                        // Bei Klärfallkonti (Hauptposition bei Einzahlungsverbuchungen) muss kein Innenauftrag angegeben werden
                        // Bei Auszahlungen wird die Hauptposition gar nicht an PSCD geliefert
                        result += new KissServiceResult(KissServiceResult.ResultType.Error, "SstPscdAddSachkontoInnenauftrag", "Konfigurationsfehler: Innenauftrag ist für Konto {0} nicht definiert", kontoNr);
                    }
                }
            }
            return result;
        }

        public void VerbucheBeleg(IUnitOfWork unitOfWork, KbuBeleg beleg, DateTime valutaDatum)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var result = KissServiceResult.Ok();
            var service = Container.Resolve<SstPscdBelegPositionService>();
            var belegpositionen = GetBelegpositionen(unitOfWork, beleg);
            foreach (var kbuBelegPosition in belegpositionen)
            {
                var kbuKontoID = kbuBelegPosition.KbuKontoID;
                var attribute = _sachkontoInnenauftrag.Single(x => x.KbuKontoID == kbuKontoID);
                bool ertragOhneGeldfluss = GetErtragOhneGeldfluss(kbuBelegPosition);
                var sachkonto = GetSachkonto(attribute, ertragOhneGeldfluss);
                var innenauftrag = GetInnenauftrag(attribute, ertragOhneGeldfluss);
                result += service.Insert(unitOfWork, kbuBelegPosition.KbuBelegPositionID, sachkonto, innenauftrag);
            }
            if (result.IsError)
            {
                throw new Exception(result.ToString());
            }
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Gibt true zurück, wenn es sich bei der Budgetposition um eine Ertragsverbuchung ohne Geldfluss handelt
        /// </summary>
        /// <param name="kbuBelegPosition"></param>
        /// <returns></returns>
        private static bool GetErtragOhneGeldfluss(KbuBelegPosition kbuBelegPosition)
        {
            return kbuBelegPosition.KbuBeleg.KbuBelegartCode == (int)LOVsGenerated.KbuBelegart.Auszahlung &&
                   !kbuBelegPosition.HauptPosition &&
                   kbuBelegPosition.SollHaben == "H";
        }

        private static IEnumerable<KbuBelegPosition> GetBelegpositionen(IUnitOfWork unitOfWork, KbuBeleg beleg)
        {
            if (beleg.KbuBelegPosition != null && beleg.KbuBelegPosition.Count > 0)
            {
                return beleg.KbuBelegPosition.Where(pos => pos.PositionImBeleg > 0);
            }
            var positionenService = Container.Resolve<KbuBelegPositionService>();
            return positionenService.GetByBelegId(unitOfWork, beleg.KbuBelegID).Where(pos => pos.PositionImBeleg > 0);
        }

        private static string GetInnenauftrag(SstPscdSachkontoInnenauftrag attribute, bool ertragOhneGeldfluss)
        {
            return ertragOhneGeldfluss ? attribute.InnenauftragErtragOhneGeldfluss : attribute.Innenauftrag;
        }

        private static string GetSachkonto(SstPscdSachkontoInnenauftrag attribute, bool ertragOhneGeldfluss)
        {
            return ertragOhneGeldfluss ? attribute.SachkontoErtragOhneGeldfluss : attribute.Sachkonto;
        }

        #endregion

        #region Private Methods

        private string GetKontoNr(int kbuKontoID)
        {
            var konto = _konti.SingleOrDefault(x => x.KbuKontoID == kbuKontoID);
            return konto != null ? konto.KontoNr : string.Empty;
        }

        #endregion

        #endregion
    }
}