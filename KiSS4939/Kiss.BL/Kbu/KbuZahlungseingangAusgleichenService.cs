using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

using Kiss.BL.Wsh;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Model;
using Kiss.Model.DTO.Kbu;

namespace Kiss.BL.Kbu
{
    /// <summary>
    /// Service to balance a KbuZahlungseingang
    /// </summary>
    public class KbuZahlungseingangAusgleichenService : ServiceBase
    {
        #region Constructors

        private KbuZahlungseingangAusgleichenService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Gleicht einen KbuZahlungseingang aus, d.h. erstellt den Eintrag in KbuBeleg und die n Einträge in KbuBelegPosition.
        /// Wenn der Betrag komplett ausgeglichen ist, so wird zudem auf dem Zahlungseingang das Flag Ausgeglichen=True gesetzt.
        /// </summary>
        /// <param name="unitOfWork">Das UnitOfWork, welches verwendet werden soll</param>
        /// <param name="kbuZahlungseingang">Die Entität des Zahlungseingangs, welcher ausgeglichen werden soll</param>
        /// <param name="kbuErwarteteEinnahmenDTO">Die Liste der Einnahmen, welche für den Ausgleich verwendet werden soll</param>
        /// <returns>Das Service-Resultat des Ausgleich-Vorgangs</returns>
        public KissServiceResult Ausgleichen(
            IUnitOfWork unitOfWork,
            KbuZahlungseingang kbuZahlungseingang,
            IList<KbuErwarteteEinnahmeDTO> kbuErwarteteEinnahmenDTO)
        {
            // init
            var serviceResult = KissServiceResult.Ok();
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            // validate
            serviceResult += ValidateBeforeAusgleich(kbuZahlungseingang, kbuErwarteteEinnahmenDTO);

            if (!serviceResult)
            {
                return serviceResult;
            }

            // do Ausgleich
            using (var ts = new TransactionScope())
            {
                // create KbuBeleg and KbuBelegPosition, fill KbuBelegDebitor
                serviceResult += CreateBelegUndPositionen(unitOfWork, kbuZahlungseingang, kbuErwarteteEinnahmenDTO);

                if (!serviceResult.IsOk)
                {
                    return serviceResult;
                }

                // handle KbuZahlungseingang.Ausgeglichen
                serviceResult += CheckAndUpdateKbuZahlungseingang(unitOfWork, kbuZahlungseingang);

                if (!serviceResult.IsOk)
                {
                    return serviceResult;
                }

                // success
                ts.Complete();
            }

            return serviceResult;
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Setzt das Flag KbuZahlungseingang.Ausgeglichen in Abhängigkeit der Einträge in KbuBelegPosition.
        /// </summary>
        /// <param name="unitOfWork">Das UnitOfWork, welches verwendet werden soll (darf nicht null sein!)</param>
        /// <param name="kbuZahlungseingang">Die Entität des Zahlungseingangs, welcher ausgeglichen werden soll</param>
        /// <returns>Das Service-Resultat des Ausgleich-Vorgangs</returns>
        private static KissServiceResult CheckAndUpdateKbuZahlungseingang(IUnitOfWork unitOfWork, KbuZahlungseingang kbuZahlungseingang)
        {
            if (!kbuZahlungseingang.Betrag.HasValue)
            {
                throw new ArgumentOutOfRangeException("kbuZahlungseingang", "The KbuZahlungseingang.Betrag is required and must contain a value.");
            }

            // init
            var kbuZahlungseingangService = Container.Resolve<KbuZahlungseingangService>();
            var repository = UnitOfWork.GetRepository<KbuBelegPosition>(unitOfWork);

            // check if Ausgeglichen: SUM(KbuBelegPosition) for KbuBeleg.KbuZahlungseingangID = kbuZahlungseingang.KbuZahlungseingangID
            // a) == kbuZahlungseingang.Betrag --> kbuZahlungseingang.Ausgeglichen = true
            // b) < kbuZahlungseingang.Betrag --> kbuZahlungseingang.Ausgeglichen = false
            // c) > kbuZahlungseingangBetrag --> ERROR
            var sumBetrag = repository
                .Include(belegPos => belegPos.KbuBeleg)
                .Where(belegPos => belegPos.KbuBeleg.KbuZahlungseingangID == kbuZahlungseingang.KbuZahlungseingangID)
                .Where(belegPos => !belegPos.HauptPosition) // TODO: ok?
                .Sum(belegPos => belegPos.BetragBrutto);

            if (kbuZahlungseingang.Betrag.Value.Equals(sumBetrag))
            {
                kbuZahlungseingang.Ausgeglichen = true;
            }
            else if (kbuZahlungseingang.Betrag.Value > sumBetrag)
            {
                kbuZahlungseingang.Ausgeglichen = false;
            }
            else
            {
                return new KissServiceResult(KissServiceResult.ResultType.Error, string.Format("Die Summe der KbuBelegPositionen ({0}) übersteigt den Betrag des KbuZahlungseingangs ({1}).", sumBetrag, kbuZahlungseingang.Betrag.Value));
            }

            return kbuZahlungseingangService.SaveData(unitOfWork, kbuZahlungseingang);
        }

        /// <summary>
        /// Gleicht einen KbuZahlungseingang aus, d.h. erstellt den Eintrag in KbuBeleg und 
        /// die n Einträge in KbuBelegPosition, sowie KbuBelegDebitor.
        /// </summary>
        /// <param name="unitOfWork">Das UnitOfWork, welches verwendet werden soll (darf nicht null sein!)</param>
        /// <param name="kbuZahlungseingang">Die Entität des Zahlungseingangs, welcher ausgeglichen werden soll</param>
        /// <param name="kbuErwarteteEinnahmenDTO">Die Liste der Einnahmen, welche für den Ausgleich verwendet werden soll</param>
        /// <returns>Das Service-Resultat des Erstell-Vorgangs</returns>
        private static KissServiceResult CreateBelegUndPositionen(
            IUnitOfWork unitOfWork,
            KbuZahlungseingang kbuZahlungseingang,
            IList<KbuErwarteteEinnahmeDTO> kbuErwarteteEinnahmenDTO)
        {
            // init
            var serviceResult = KissServiceResult.Ok();
            var kbuBelegService = Container.Resolve<KbuBelegService>();
            var kbuBelegPositionService = Container.Resolve<KbuBelegPositionService>();
            var wshPositionService = Container.Resolve<WshPositionService>();
            var kbuKontoService = Container.Resolve<KbuKontoService>();

            // Beleg erstellen
            KbuBeleg kbuBeleg;
            kbuBelegService.NewData(out kbuBeleg);

            kbuBeleg.KbuZahlungseingangID = kbuZahlungseingang.KbuZahlungseingangID;
            kbuBeleg.KbuBelegartCode = Convert.ToInt32(LOVsGenerated.KbuBelegart.Einzahlung);
            kbuBeleg.KbuBelegKreisCode = Convert.ToInt32(LOVsGenerated.KbuBelegKreis.EinzahlungenKISS);
            kbuBeleg.KbuBelegstatusCode = Convert.ToInt32(LOVsGenerated.KbuBelegstatus.Freigegeben);
            kbuBeleg.KbuProzessartCode = Convert.ToInt32(LOVsGenerated.KbuProzessart.WSH); // TODO: hier braucht es evtl. noch etwas Dynamik...
            kbuBeleg.BelegDatum = DateTime.Now;
            kbuBeleg.ValutaDatum = kbuZahlungseingang.DatumZahlungseingang;
            kbuBeleg.Text = ""; // TODO: needs to be the text from GUI

            serviceResult += kbuBelegService.SaveData(unitOfWork, kbuBeleg);

            if (!serviceResult.IsOk)
            {
                return serviceResult;
            }

            // HauptPosition erstellen
            KbuBelegPosition hauptPosition;
            kbuBelegPositionService.NewData(out hauptPosition);

            string zahlstapelPrefix = kbuZahlungseingang.SstZahlungseingangSingleItem.PAYMENT_LOT.Substring(0, 2);
            var klaerfallKonto = kbuKontoService.GetKlaerfallKonto(unitOfWork, zahlstapelPrefix);

            hauptPosition.KbuBelegID = kbuBeleg.KbuBelegID;
            hauptPosition.KbuKontoID = klaerfallKonto.KbuKontoID;
            hauptPosition.WshPositionID = null;
            hauptPosition.BaPersonID = null;
            hauptPosition.PositionImBeleg = 1;
            hauptPosition.SollHaben = Constant.KBUBELEGPOSITION_SOLL;
            hauptPosition.Text = string.Format("Klärfall {0} - {1}", kbuZahlungseingang.SstZahlungseingangSingleItem.PAYMENT_LOT, kbuZahlungseingang.SstZahlungseingangSingleItem.PAYMENT_LOT_POS);
            hauptPosition.BetragNetto = hauptPosition.BetragBrutto = kbuZahlungseingang.Betrag.Value;
            hauptPosition.Weiterverrechenbar = false;
            hauptPosition.Quoting = false;
            hauptPosition.HauptPosition = true;

            serviceResult += kbuBelegPositionService.SaveData(unitOfWork, hauptPosition);

            // BelegPositionen erstellen
            int positionImBeleg = 2;
            foreach (var ausgleich in kbuErwarteteEinnahmenDTO)
            {
                var wshPosition = GetWshPosition(unitOfWork, wshPositionService, ausgleich.WshPositionID);

                if (wshPosition == null)
                {
                    serviceResult += new KissServiceResult(KissServiceResult.ResultType.Error, string.Format("Für die WshPositionID ({0}) wurde keine gültige WshPosition gefunden.", ausgleich.WshPositionID));
                    return serviceResult;
                }

                KbuBelegPosition kbuBelegPosition;
                kbuBelegPositionService.NewData(out kbuBelegPosition);

                // TODO: check if ok
                kbuBelegPosition.KbuBelegID = kbuBeleg.KbuBelegID;
                kbuBelegPosition.KbuKontoID = wshPosition.KbuKontoID;
                kbuBelegPosition.WshPositionID = wshPosition.WshPositionID;
                kbuBelegPosition.FaLeistungID = wshPosition.FaLeistungID;
                kbuBelegPosition.BaPersonID = wshPosition.BaPersonID;
                kbuBelegPosition.PositionImBeleg = positionImBeleg++;
                kbuBelegPosition.SollHaben = Constant.KBUBELEGPOSITION_HABEN;
                kbuBelegPosition.Text = wshPosition.Text;
                kbuBelegPosition.BetragNetto = kbuBelegPosition.BetragBrutto = ausgleich.BetragAuszugleichen;
                kbuBelegPosition.Weiterverrechenbar = false;
                kbuBelegPosition.Quoting = false;
                kbuBelegPosition.HauptPosition = false;

                serviceResult += kbuBelegPositionService.SaveData(unitOfWork, kbuBelegPosition);

                if (!serviceResult.IsOk)
                {
                    return serviceResult;
                }
            }

            // BelegDebitor erstellen
            serviceResult += CreateDebitor(unitOfWork, kbuZahlungseingang, kbuBeleg.KbuBelegID);

            return serviceResult;
        }

        /// <summary>
        /// Erstellt einen Debitor zum Beleg.
        /// </summary>
        private static KissServiceResult CreateDebitor(IUnitOfWork unitOfWork, KbuZahlungseingang kbuZahlungseingang, int kbuBelegId)
        {
            KbuBelegDebitorService debitorService = Container.Resolve<KbuBelegDebitorService>();
            KbuBelegDebitor debitor;
            debitorService.NewData(out debitor);

            //BaInstitutionID oder BaPersonID setzen.
            if (kbuZahlungseingang.BaInstitutionDebitor != null)
            {
                debitor.BaInstitution = kbuZahlungseingang.BaInstitutionDebitor;
            }
            else if (kbuZahlungseingang.BaPersonDebitor != null)
            {
                debitor.BaPerson = kbuZahlungseingang.BaPersonDebitor;
            }

            //Belegid setzen.
            debitor.KbuBelegID = kbuBelegId;

            return debitorService.SaveData(unitOfWork, debitor);
        }

        private static WshPosition GetWshPosition(IUnitOfWork unitOfWork, WshPositionService wshPositionService, int? wshPositionID)
        {
            if (!wshPositionID.HasValue)
            {
                throw new ArgumentOutOfRangeException("wshPositionID", "The wshPositionID is required and must contain a value.");
            }

            return wshPositionService.GetById(unitOfWork, wshPositionID.Value);
        }

        /// <summary>
        /// Valdidiert die Daten, ob ein Zahlungseingang ausgeglichen werden kann.
        /// Die Validierung wird im KissServiceResult abgelegt.
        /// </summary>
        /// <param name="kbuZahlungseingang">Die Entität des Zahlungseingangs, welcher ausgeglichen werden soll</param>
        /// <param name="kbuErwarteteEinnahmenDTO">Die Liste der Einnahmen, welche für den Ausgleich verwendet werden soll</param>
        /// <returns>Das Service-Resultat des Validierungsvorgangs</returns>
        private static KissServiceResult ValidateBeforeAusgleich(
            KbuZahlungseingang kbuZahlungseingang,
            IList<KbuErwarteteEinnahmeDTO> kbuErwarteteEinnahmenDTO)
        {
            // Zahlunseingang
            if (kbuZahlungseingang.Ausgeglichen)
            {
                return new KissServiceResult(KissServiceResult.ResultType.Error, "Der Zahlungseingang wurde bereits ausgeglichen.");
            }

            if (!kbuZahlungseingang.Betrag.HasValue || kbuZahlungseingang.Betrag.Value.Equals(0))
            {
                return new KissServiceResult(KissServiceResult.ResultType.Error, "Der Betrag des Zahlungseingangs darf nicht leer oder 0.00 sein.");
            }

            // ErwarteteEinnahmen
            if (kbuErwarteteEinnahmenDTO.Count < 1)
            {
                return new KissServiceResult(KissServiceResult.ResultType.Error, "Es muss mindestens ein Ausgleichseintrag vorhanden sein.");
            }

            foreach (var entity in kbuErwarteteEinnahmenDTO)
            {
                if (entity == null)
                {
                    return new KissServiceResult(KissServiceResult.ResultType.Error, "Es wurde ein leerer Ausgleichseintrag übergeben.");
                }

                if (!entity.WshPositionID.HasValue || entity.WshPositionID < 1)
                {
                    return new KissServiceResult(KissServiceResult.ResultType.Error, "Es wurde ein ungültiger Ausgleichseintrag übergeben (WshPositionID).");
                }
            }

            // valid
            return KissServiceResult.Ok();
        }

        #endregion

        #endregion
    }
}