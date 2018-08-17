using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.BL.Kbu;
using Kiss.BL.KissSystem;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Model;
using Kiss.Model.DTO.Wsh;

namespace Kiss.BL.Wsh
{
    /// <summary>
    /// Service für den Grundbudget. 
    /// </summary>
    public class WshGrundbudgetVorschlagService : ServiceBase
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string GBL_PRO_PERSON = @"System\Sozialhilfe\SKOS2005\GBL_PerPerson";
        private const string SKOS2005 = @"System\Sozialhilfe\SKOS2005\GBL\{0}";

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public IQueryable<WshGrundbudgetPosition> GetBerechneteGblPositionQueryable(IUnitOfWork unitOfWork, int faLeistungId)
        {
            var kontoService = Container.Resolve<KbuKontoService>();
            KbuKonto gblKonto = kontoService.GetGblKonto(unitOfWork);
            return GetBerechnetePositionQueryable(unitOfWork, faLeistungId, gblKonto.KbuKontoID);
        }

        /// <summary>
        /// Liefert ein IQueryable von aktiven berechneten WshGrundbudgetPositionen.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="faLeistungId"></param>
        /// <param name="kbuKontoId"></param>
        /// <returns></returns>
        public IQueryable<WshGrundbudgetPosition> GetBerechnetePositionQueryable(IUnitOfWork unitOfWork, int faLeistungId, int kbuKontoId)
        {
            var repositoryPos = UnitOfWork.GetRepository<WshGrundbudgetPosition>(unitOfWork);
            return from x in repositoryPos
                   where x.FaLeistungID == faLeistungId
                   where x.Berechnet
                   where x.DatumBis == null || x.DatumBis >= DateTime.Today
                   where x.KbuKontoID == kbuKontoId
                   select x;
        }

        /// <summary>
        /// Erstellt den Vorschlag für das Grundbudget anhand bereits vorhandener Daten.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="faLeistungId"></param>
        /// <returns></returns>
        public IList<WshGrundbudgetVorschlagDTO> GetGrundbudgetVorschlag(IUnitOfWork unitOfWork, int faLeistungId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            IList<WshGrundbudgetVorschlagDTO> result = new List<WshGrundbudgetVorschlagDTO>();
            AddGBL(unitOfWork, faLeistungId, result);
            return result;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Erstellt den Vorschlag für GBL.
        /// Falls im Grundbudget bereits ein GBL vorhanden ist,
        /// dann wird kein Vorschlag für GBL erstellt.
        /// 
        /// Haushaltsgrösse(x): Anzahl Personen, die zum Zeitpunkt x im Haushalt leben.
        /// Unterstützungseinheitgrösse(x): Anzahl Personen, die im Haushalt zum Zeitpunkt x unterstützt werden.
        /// SkosFormel(x): Siehe Tabelle B.2.2. Skos 2005. X ist eine ganze Zahl und  ist eine Anzahl Personen.
        /// Round(decimal x): Rundungsfunktion auf 5 Rappen, auf oder abrunden.
        /// GblBetrag  = Round( SkosFormel(Haushaltsgrösse(Today)) * Unterstützungseinheitgrösse(Today) / Haushaltsgrösse(Today) )
        /// 
        /// </summary>
        /// <param name="unitOfwork"></param>
        /// <param name="faLeistungID"></param>
        /// <param name="list"></param>
        private void AddGBL(IUnitOfWork unitOfwork, int faLeistungID, IList<WshGrundbudgetVorschlagDTO> list)
        {
            //Konto für den GBL holen
            var kontoService = Container.Resolve<KbuKontoService>();
            KbuKonto gblKonto = kontoService.GetGblKonto(unitOfwork);

            //Prüfen, ob schon ein GBL da ist
            var queryGbl = GetBerechnetePositionQueryable(unitOfwork, faLeistungID, gblKonto.KbuKontoID);

            //Überprüfen, ob bereits ein GBL vorhanden ist.
            //Wenn ja, erstellen wir keinen Vorschlag.
            if (queryGbl.Any())
            {
                return;
            }

            //Anzahl Personen im Haushalt evaluieren.
            WshHaushaltPersonService haushaltService = Container.Resolve<WshHaushaltPersonService>();
            int hgAnzahlPersonen = haushaltService.GetHaushaltsGroesse(unitOfwork, faLeistungID);
            int ueAnzahlPersonen = haushaltService.GetUnterstuetzungsEinheitsGroesse(unitOfwork, faLeistungID);

            //Wenn Haushlatsgrösse null ist, machen wir kein GBL Vorschlag.
            if (hgAnzahlPersonen == 0)
            {
                return;
            }

            double factor = ueAnzahlPersonen / (double)hgAnzahlPersonen;

            WshGrundbudgetVorschlagDTO gbl = new WshGrundbudgetVorschlagDTO();
            decimal ausgaben = (decimal)((double)GblBetragBerechnen(unitOfwork, hgAnzahlPersonen) * factor);

            //Betrag Runden
            ausgaben = Container.Resolve<KbuGeldbetragRundungsService>().GeldbetragRunden(ausgaben);

            //0er Positionen sind nicht zugelassen.
            if (ausgaben == 0)
            {
                return;
            }

            gbl.Ausgaben = ausgaben;
            gbl.KontoNr = gblKonto.KontoNr;
            gbl.KontoText = gblKonto.Name;
            gbl.KontoID = gblKonto.KbuKontoID;
            gbl.BaPersonID = null; //Ist für UE
            gbl.Betrifft = "UE";
            gbl.Text = "";

            list.Add(gbl);
        }

        /// <summary>
        /// Berechnet den GBL anhand der Haushaltsgrösse.
        /// Siehe Konfigurationswerte 
        /// System\Sozialhilfe\SKOS2005\GBL\1 bis 7
        /// System\Sozialhilfe\SKOS2005\GBL_PerPerson
        /// 
        /// Für 0 Personen: 0.0 sFr.
        /// Für 1 bis 7 Personen, gemäss Konfigurationswerte 
        ///  System\Sozialhilfe\SKOS2005\GBL\1 bis 7
        /// Ab 8 Personen: Wie 7 Personen, dann für jede weitere Person der Betrag (GBL_PerPerson).
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="anzahlPersonenImHaushalt"></param>
        /// <returns></returns>
        private decimal GblBetragBerechnen(IUnitOfWork unitOfWork, int anzahlPersonenImHaushalt)
        {
            XConfigService configService = Container.Resolve<XConfigService>();

            //Über sechs Personen im Haushalt
            if (anzahlPersonenImHaushalt >= 7)
            {

                decimal betrag = configService.GetConfigValue<decimal>(unitOfWork, string.Format(SKOS2005, "7"));

                int uebrigePersonen = anzahlPersonenImHaushalt - 7;
                if (uebrigePersonen > 0)
                {
                    decimal betragProZusaetzlichePerson = configService.GetConfigValue<decimal>(unitOfWork, GBL_PRO_PERSON);
                    betrag += betragProZusaetzlichePerson * uebrigePersonen;
                }
                return betrag;

            }

            //Zwischen 1 und sechs Personen
            if (anzahlPersonenImHaushalt > 0)
            {
                return configService.GetConfigValue<decimal>(unitOfWork, string.Format(SKOS2005, anzahlPersonenImHaushalt));
            }

            //Keine Person im Haushalt.
            return 0;
        }

        #endregion

        #endregion
    }
}