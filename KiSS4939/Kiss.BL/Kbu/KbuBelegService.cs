using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

using Kiss.BL.Kbu.Validation;
using Kiss.Infrastructure.Constant;
using Kiss.Infrastructure.Enumeration;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Model;
using Kiss.Model.DTO.Kbu;
using Kiss.Model.DTO.Wsh;
using KbuBelegKreditor = Kiss.Model.KbuBelegKreditor;

using KiSS.Common.Exceptions;

namespace Kiss.BL.Kbu
{
    /// <summary>
    /// Service to manage an TEntity
    /// </summary>
    public class KbuBelegService : ServiceCRUDBase<KbuBeleg>
    {
        #region Constructors

        private KbuBelegService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Erstellt einen Beleg für einen Zahlungseingang.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="zahlungseingang"></param>
        /// <param name="ausgeglicheneSollstellungen"></param>
        /// <param name="buchungsDatum"></param>
        /// <param name="ignoreWarnings">Der Beleg wird auch mit Warnungen grüngestellt, falls true</param>
        /// <param name="beleg">Erstelltes Beleg</param>
        /// <returns></returns>
        public KissServiceResult CreateBeleg(IUnitOfWork unitOfWork, KbuZahlungseingang zahlungseingang, List<KbuErwarteteEinnahmeDTO> ausgeglicheneSollstellungen, DateTime buchungsDatum, bool ignoreWarnings, out KbuBeleg beleg)
        {
            var serviceResult = KissServiceResult.Ok();
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            serviceResult = ValidateBeleg(unitOfWork, zahlungseingang, ausgeglicheneSollstellungen, ignoreWarnings, serviceResult);
            if (!serviceResult.IsOk)
            {
                beleg = null;
                return serviceResult;
            }
            if (serviceResult.IsWarning && !ignoreWarnings)
            {
                beleg = null;
                return serviceResult;
            }

            //Beleg anlegen.
            NewData(out beleg);

            beleg.BelegDatum = DateTime.Today;

            //Valutadatum - TODO: wass soll als Valutadatum genommen werden?
            beleg.ValutaDatum = buchungsDatum;

            beleg.KbuZahlungseingang = zahlungseingang;

            //Einzahlung von Debitorname + Valutadatum. TODO: was für ein Buchungstext?
            beleg.Text = string.Format("Einzahlung von {0} vom {1}", "???", "???");

            //Belegstatus auf "freigegeben" setzen.
            beleg.KbuBelegstatusCode = (int)LOVsGenerated.KbuBelegstatus.Freigegeben;

            //BelegArt: Einzahlung.
            beleg.KbuBelegartCode = (int)LOVsGenerated.KbuBelegart.Einzahlung;

            SaveData(unitOfWork, beleg);

            //Hauptposition anlegen.
            CreateBelegHauptPosition(unitOfWork, beleg, zahlungseingang);

            //Beleg Positionen anlegen.
            CreateBelegPositionen(unitOfWork, beleg, zahlungseingang, ausgeglicheneSollstellungen);

            //KbuBelegDebitor anlegen.
            CreateDebitor(unitOfWork, zahlungseingang, beleg.KbuBelegID);

            return serviceResult;
        }

        /// <summary>
        /// Erstellt einen Beleg für Auszalungen.
        /// DAS IST PART 1, DIE OMINÖSE GRÜNSTELLROUTINE.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="ignoreWarnings">Der Beleg wird auch mit Warnungen grüngestellt, falls true</param>
        /// <param name="belegDTO"></param>
        /// <param name="beleg">Erstelltes Beleg</param>
        /// <returns></returns>
        public KissServiceResult CreateBeleg(IUnitOfWork unitOfWork, WshAuszahlvorschlagBelegDTO belegDTO, bool ignoreWarnings, out KbuBeleg beleg)
        {
            var serviceResult = KissServiceResult.Ok();
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            serviceResult = ValidateBeleg(unitOfWork, belegDTO, ignoreWarnings, serviceResult);
            if (!serviceResult.IsOk)
            {
                beleg = null;
                return serviceResult;
            }
            if (serviceResult.IsWarning && !ignoreWarnings)
            {
                beleg = null;
                return serviceResult;
            }

            //Beleg anlegen.
            NewData(out beleg);

            //Was soll hier gesetz werden? -> Reto Fragen.
            //Wird zu BuchungsDatum umbenannt. #7483 (Kombibeleg).
            beleg.BelegDatum = DateTime.Today;

            //Valutadatum
            beleg.ValutaDatum = belegDTO.Valuta;

            //Auszahlung für Kreditorname + Valutadatum.
            beleg.Text = string.Format("Auszahlung für {0} {1}", belegDTO.Kreditor.Name, belegDTO.Valuta.ToString(Constant.DATETIME_FORMAT_DDMMYYYY));

            //Belegstatus auf "freigegeben" setzen.
            beleg.KbuBelegstatusCode = (int)LOVsGenerated.KbuBelegstatus.Freigegeben;

            //BelegArt, ist in dieser Methode eine Auszahlung.
            beleg.KbuBelegartCode = (int)LOVsGenerated.KbuBelegart.Auszahlung;

            SaveData(unitOfWork, beleg);

            //Beleg Positionen anlegen.
            CreateBelegPositionen(unitOfWork, beleg, belegDTO.BelegPositionen);

            //Hauptposition anlegen.
            CreateBelegHauptPositionAusgabe(unitOfWork, beleg, belegDTO.AuszahlbetragNetto);

            //Kreditor anlegen.            
            int? baZahlungswegId = null;
            if (belegDTO.Kreditor.BaZahlungsweg != null)
            {
                baZahlungswegId = belegDTO.Kreditor.BaZahlungsweg.BaZahlungswegID;
            }
            CreateKreditor(unitOfWork, baZahlungswegId, beleg);

            //Status setzen
            belegDTO.Status = WshAuszahlvorschlagStatus.Freigegeben;

            return serviceResult;
        }

        /// <summary>
        /// Erstellt Belege. Für jeden Beleg wird die Grünstellroutine aufgerufen.
        /// <see ></see>
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="belege"></param>
        /// <returns></returns>
        public KissServiceResult CreateBelege(IUnitOfWork unitOfWork, List<WshAuszahlvorschlagBelegDTO> belege)
        {
            List<KbuBeleg> belegeCreated;
            return CreateBelege(unitOfWork, belege, out belegeCreated);
        }

        public KissServiceResult CreateBelege(IUnitOfWork unitOfWork, List<WshAuszahlvorschlagBelegDTO> belege, out List<KbuBeleg> belegeCreated)
        {
            var serviceResult = KissServiceResult.Ok();
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            belegeCreated = new List<KbuBeleg>();

            foreach (var belegDTO in belege)
            {
                serviceResult = ValidateBeleg(unitOfWork, belegDTO, false, serviceResult);
            }

            if (!serviceResult.IsOk)
            {
                return serviceResult;
            }

            using (TransactionScope ts = new TransactionScope())
            {
                foreach (var belegDTO in belege)
                {
                    KbuBeleg beleg;
                    serviceResult = CreateBeleg(unitOfWork, belegDTO, false, out beleg);
                    if (!serviceResult.IsOk)
                    {
                        return serviceResult;
                    }
                    belegeCreated.Add(beleg);
                }
                ts.Complete();
            }
            if (serviceResult.IsError)
            {
                belegeCreated.Clear();
            }
            return serviceResult;
        }

        /// <summary>
        /// Erstellt Belege (Dauerauftrag).
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="faLeistungID"></param>
        /// <returns></returns>
        public KissServiceResult CreateBelegeFuerDauerauftrag(IUnitOfWork unitOfWork, int faLeistungID)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            //1. Validieren
            KissServiceResult result = ValidateGrundbudgetForDauerauftrag(unitOfWork, faLeistungID);
            if (!result.IsOk)
            {
                return result;
            }

            var repositoryPosition = UnitOfWork.GetRepository<WshPosition>(unitOfWork);

            int kategorieIdAusgabe = (int) LOVsGenerated.WshKategorie.Ausgabe;
            var query = from x in repositoryPosition
                                 .Include(x => x.WshPositionKreditor.SubInclude(y => y.BaZahlungsweg))
                        where x.KbuBelegPosition.Count() == 0
                        where x.FaLeistungID == faLeistungID
                        where x.DauerauftragAktiv
                        where x.WshKategorieID == kategorieIdAusgabe || x.VerwaltungSD == false //abgetretene Einnahmen ausblenden (Marcel Weber).
                        group x by x.MonatVon
                            into g
                            select g;

            //Positionen suchen
            using (TransactionScope ts = new TransactionScope())
            {
                foreach (var group in query)
                {
                    CreateBelegFuerDauerauftrag(unitOfWork, group.Key, group.ToList());
                }
                ts.Complete();
            }

            return KissServiceResult.Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="faLeistungId"></param>
        /// <returns></returns>
        public KissServiceResult DeleteFreigegebeneBelegeVonDauerauftrag(IUnitOfWork unitOfWork, int faLeistungId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repositoryKbuBelegPositionen = UnitOfWork.GetRepository<KbuBelegPosition>(unitOfWork);         

            int belegFreigegebenCode = (int) LOVsGenerated.KbuBelegstatus.Freigegeben;

            var query = from x in repositoryKbuBelegPositionen.Include(y => y.KbuBeleg)
                        where x.FaLeistungID == faLeistungId
                        where x.KbuBeleg.KbuBelegstatusCode == belegFreigegebenCode
                        where x.WshPosition.DauerauftragAktiv == true
                        select x;

            var listPositionen = query.ToList();
            var list = new List<KbuBeleg>();
            foreach (KbuBelegPosition belegPosition in listPositionen)
            {
                if(!list.Contains(belegPosition.KbuBeleg))
                {
                    list.Add(belegPosition.KbuBeleg);
                }
            }

            foreach (KbuBeleg beleg in list)
            {
               DeleteFreigegebenerBeleg(unitOfWork, beleg.KbuBelegID);
            }

            return KissServiceResult.Ok();
        }

        /// <summary>
        /// Lädt einen Datensatz aufgrund der ID.
        /// </summary>
        /// <param name="unitOfWork">Die UnitOfWork.</param>
        /// <param name="id">Die ID des Datensatzes.</param>
        /// <returns>Der Datensatz mit der angegebenen ID.</returns>
        public override KbuBeleg GetById(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<KbuBeleg>(unitOfWork);

            var returnValue = repository
                .Where(entity => entity.KbuBelegID == id)
                .SingleOrDefault();

            if (returnValue == null)
            {
                throw new EntityNotFoundException("no entity of 'KbBeleg' found with id: " + id);
            }

            //SetEntityValidator(returnValue);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        /// <summary>
        /// Lädt eine Liste von Belegen aufgrund deren IDs
        /// </summary>
        /// <param name="unitOfWork">Die UnitOfWork.</param>
        /// <param name="kbuBelegIDs">Die IDs der Belege</param>
        /// <returns>Die Belege mit den angegebenen IDs</returns>
        public IEnumerable<KbuBeleg> GetByIdsForPscdTransfer(IUnitOfWork unitOfWork, IList<int> kbuBelegIDs)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<KbuBeleg>(unitOfWork);

            var belege = repository
                .Where(entity => kbuBelegIDs.Contains(entity.KbuBelegID))
                .Include(beleg => beleg.KbuBelegPosition.SubInclude(pos => pos.KbuKonto))
                .Include(beleg => beleg.KbuBelegPosition.SubInclude(pos => pos.SstPscdBelegPosition))
                .Include(beleg => beleg.KbuBelegKreditor)
                .Include(beleg => beleg.KbuZahlungseingang.SubInclude(ze => ze.SstZahlungseingang))
                .ToList();

            belege.ForEach(SetEntityValidator);
            // ToDo: Validator setzen, falls DetailPositionen editiert werden sollen
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return belege;
        }

        /// <summary>
        /// Lädt eine Liste von Belegen aufgrund deren IDs
        /// </summary>
        /// <param name="unitOfWork">Die UnitOfWork.</param>
        /// <param name="kbuBelegIDs">Die IDs der Belege</param>
        /// <returns>Die Belege mit den angegebenen IDs</returns>
        public IEnumerable<KbuBeleg> GetByIdsWithDetailPositions(IUnitOfWork unitOfWork, IList<int> kbuBelegIDs)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<KbuBeleg>(unitOfWork);

            var belege = repository
                .Where(entity => kbuBelegIDs.Contains(entity.KbuBelegID))
                .Include(beleg => beleg.KbuBelegPosition.SubInclude(pos => pos.KbuKonto))
                .Include(beleg => beleg.KbuBelegKreditor)
                .ToList();

            belege.ForEach(SetEntityValidator);
            // ToDo: Validator setzen, falls DetailPositionen editiert werden sollen
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return belege;
        }

        public override KissServiceResult ValidateInMemory(KbuBeleg dataToValidate)
        {
            // validation: check if entity is consistent in itself
            var validator = new KbuBelegValidator();

            var serviceResult = new KissServiceResult(validator.Validate(dataToValidate));

            return serviceResult + base.ValidateInMemory(dataToValidate);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Erstellt einen Beleg für die Positionen.
        /// - Alle Positionen müssen denselben Zahlungsweg haben und elektornisch sein.
        /// - Alle Positionen müssen denselben Monat aufweisen.
        /// - Alle Positionen müssen 1XMal monatlich sein.
        /// </summary>
        /// <returns></returns>
        private KissServiceResult CreateBelegFuerDauerauftrag(IUnitOfWork unitOfWork, DateTime monat, List<WshPosition> positionen)
        {
            KbuBeleg beleg;

            //Beleg anlegen.
            NewData(out beleg);

            //Was soll hier gesetz werden? -> Reto Fragen.
            //Wird zu BuchungsDatum umbenannt. #7483 (Kombibeleg).
            beleg.BelegDatum = DateTime.Today;

            //Valutadatum
            var valutaService = Container.Resolve<KbuZahlungslaufValutaService>();
            beleg.ValutaDatum =
                valutaService.GetValutaDatum(unitOfWork, LOVsGenerated.WshPeriodizitaet._1xProMonat, monat.Year, monat.Month).Single();

            //Auszahlung für Kreditorname + Valutadatum.
            beleg.Text = "";

            //Belegstatus auf "freigegeben" setzen.
            beleg.KbuBelegstatusCode = (int)LOVsGenerated.KbuBelegstatus.Freigegeben;

            //BelegArt, ist in dieser Methode eine Auszahlung.
            beleg.KbuBelegartCode = (int)LOVsGenerated.KbuBelegart.Auszahlung;

            KissServiceResult result = SaveData(unitOfWork, beleg);

            //BelegPositionen erstellen
            int positionImBeleg = 1;
            foreach (var wshPosition in positionen)
            {
                bool ausgabe = false;
                if(wshPosition.WshKategorieID == (int) LOVsGenerated.WshKategorie.Ausgabe)
                {
                    ausgabe = true;
                }
                CreateBelegPosition(unitOfWork, beleg, wshPosition, positionImBeleg, ausgabe, wshPosition.Betrag);
            }

            //Hauptposition erstellen
            decimal betrag = SummeAusgabeBerechnen(beleg);
            CreateBelegHauptPositionAusgabe(unitOfWork, beleg, betrag);

            //Kreditor erstellen
            int idErstePosition = positionen[0].WshPositionID;
            var repositoryWshPositionKreditor = UnitOfWork.GetRepository<WshPositionKreditor>(unitOfWork);
            int? baZahlungswegId = repositoryWshPositionKreditor.Where(x => x.WshPositionID == idErstePosition).Select(x => x.BaZahlungswegID).SingleOrDefault();
            CreateKreditor(unitOfWork, baZahlungswegId, beleg);

            return result;
        }

        /// <summary>
        /// Kreiert die Hauptposition für den Beleg.
        /// </summary>
        private void CreateBelegHauptPosition(IUnitOfWork unitOfWork, KbuBeleg beleg, KbuZahlungseingang zahlungseingang)
        {
            KbuBelegPositionService belegPositionService = Container.Resolve<KbuBelegPositionService>();
            KbuBelegPosition belegPosition;
            belegPositionService.NewData(out belegPosition);

            //Mit KbuBeleg verknüpfen.
            belegPosition.KbuBeleg = beleg;

            //PositionImBeleg der Hauptposition ist 1
            belegPosition.PositionImBeleg = 1;

            //FaLeistung ist null.
            //belegPosition.FaLeistungID = zahlungseingang.FaLeistungID; //ToDo: abklären: entweder FaLeistung leer oder aus den Forderung ableiten. Könnte aber in Ausnahmen nicht eindeutig sein, daher eher sowieso leer lassen. Ist für Klientenkonto nicht relevant

            //Verknüpfung zur Position ist null.
            belegPosition.WshPosition = null;
            belegPosition.WshPositionID = null;

            //KbuKonto wird von der WshPosition übernommen.
            belegPosition.KbuKontoID = GetKlärfallKonto(unitOfWork, zahlungseingang);

            //BaPerson ist null. TODO: ist BaPersonID auf der Hauptposition null?
            belegPosition.BaPersonID = null;
            belegPosition.BaPerson = null;

            //Text wird vom Beleg übernommen
            belegPosition.Text = beleg.Text;

            //Hauptposition ist true
            belegPosition.HauptPosition = true;

            //Bei einer Einnahme wird die Hauptposition im Soll gebucht
            belegPosition.SollHaben = "S";
            belegPosition.BetragBrutto = zahlungseingang.Betrag.Value;

            //TODO: was für ein Wert erhält BetragNetto?
            belegPosition.BetragNetto = zahlungseingang.Betrag.Value;

            belegPositionService.SaveData(unitOfWork, belegPosition);
        }

        /// <summary>
        /// Kreiert die Hauptposition für den Beleg.
        /// </summary>
        private void CreateBelegHauptPositionAusgabe(IUnitOfWork unitOfWork, KbuBeleg beleg, decimal betragBrutto)
        {
            KbuBelegPositionService belegPositionService = Container.Resolve<KbuBelegPositionService>();
            KbuBelegPosition belegPosition;
            belegPositionService.NewData(out belegPosition);

            //Mit KbuBeleg verknüpfen.
            belegPosition.KbuBeleg = beleg;

            //PositionImBeleg der Hauptposition ist 0
            belegPosition.PositionImBeleg = 0;

            //FaLeistung ist null.
            belegPosition.FaLeistungID = null;
            belegPosition.FaLeistung = null;

            //Verknüpfug zur Position ist null.
            belegPosition.WshPosition = null;
            belegPosition.WshPositionID = null;

            //KbuKonto wird von der WshPosition übernommen.
            belegPosition.KbuKonto = GetKreditorKonto(unitOfWork);

            //BaPerson ist null
            belegPosition.BaPersonID = null;
            belegPosition.BaPerson = null;

            //Text wird von der WshPosition
            belegPosition.Text = beleg.Text;

            //Hauptposition ist true
            belegPosition.HauptPosition = true;

            // Ausgaben gehen ins Soll und Einnahmen gehen ins Haben
            belegPosition.SollHaben = "H";
            belegPosition.BetragBrutto = betragBrutto;

            //Einnahme Ausgabe Code. => Mit Marcel Weber klären.
            //Wird nicht in Sprint 6 umgesetzt.

            //Kommt später. Zur zeit ist 0 am wenigsten falsch.
            belegPosition.BetragNetto = 0;

            //Von KbuKonto holen. -> Neues Feld machen auf KbuKonto (nicht Sprint6)
            belegPosition.Weiterverrechenbar = false;

            //Von KbuKonto holen. (nicht Sprint 6).
            belegPosition.Quoting = false;

            belegPositionService.SaveData(unitOfWork, belegPosition);
        }

        private void CreateBelegPosition(IUnitOfWork unitOfWork, KbuBeleg beleg, WshPosition position, int positionImBeleg, bool ausgabe, decimal  betrag)
        {
            KbuBelegPositionService belegPositionService = Container.Resolve<KbuBelegPositionService>();

            KbuBelegPosition belegPosition;
            belegPositionService.NewData(out belegPosition);

            //Mit KbuBeleg verknüpfen.
            belegPosition.KbuBeleg = beleg;

            //FaLeistung wird von der WshPosition übernommen.
            belegPosition.FaLeistung = position.FaLeistung;
            belegPosition.FaLeistungID = position.FaLeistungID;

            //Verknüpfug zur Position.
            belegPosition.WshPosition = position;

            //KbuKonto wird von der WshPosition übernommen.
            belegPosition.KbuKonto = position.KbuKonto;
            belegPosition.KbuKontoID = position.KbuKontoID;

            //BaPerson wird von der WshPosition übernommen.
            belegPosition.BaPerson = position.BaPerson;
            belegPosition.BaPersonID = position.BaPersonID;

            //PositionImBeleg der Nicht-Hauptpositionen von 1 aufsteigend durchnummerieren
            belegPosition.PositionImBeleg = positionImBeleg;

            //Text wird von der WshPosition
            belegPosition.Text = position.Text;

            //Hauptposition ist false
            belegPosition.HauptPosition = false;

            // Ausgaben gehen ins Soll und Einnahmen gehen ins Haben
            if (ausgabe)
            {
                belegPosition.SollHaben = "S";
                belegPosition.BetragBrutto = betrag;
            }
            else
            {
                belegPosition.SollHaben = "H";
                belegPosition.BetragBrutto = betrag;
            }

            //Einnahme Ausgabe Code. => Mit Marcel Weber klären.
            //Wird nicht in Sprint 6 umgesetzt.

            //Kommt später. Zur zeit ist 0 am wenigsten falsch.
            belegPosition.BetragNetto = 0;

            //Von KbuKonto holen. -> Neues Feld machen auf KbuKonto (nicht Sprint6)
            belegPosition.Weiterverrechenbar = false;

            //Von KbuKonto holen. (nicht Sprint 6).
            belegPosition.Quoting = false;

            belegPositionService.SaveData(unitOfWork, belegPosition);
        }

        /// <summary>
        /// Erstellt eine einzelne BelegPositon Fuer den Dauerauftrag.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        private KissServiceResult CreateBelegPositionFuerDauerauftrag(IUnitOfWork unitOfWork, KbuBeleg beleg, WshPosition position)
        {
            return KissServiceResult.Ok();
        }

        private void CreateBelegPositionen(IUnitOfWork unitOfWork, KbuBeleg beleg, KbuZahlungseingang zahlungseingang, List<KbuErwarteteEinnahmeDTO> ausgeglicheneSollstellungen)
        {
            KbuBelegPositionService belegPositionService = Container.Resolve<KbuBelegPositionService>();
            int positionImBeleg = 2;
            foreach (var ausgeglicheneSollstellung in ausgeglicheneSollstellungen)
            {
                KbuBelegPosition belegPosition;
                belegPositionService.NewData(out belegPosition);

                //Mit KbuBeleg verknüpfen.
                belegPosition.KbuBeleg = beleg;

                //FaLeistung wird vom Zahlungseingang übernommen.
                //belegPosition.FaLeistungID = ausgeglicheneSollstellung.FaLeistungID; // ToDo: DTO erweitern

                //Verknüpfung zur Position.
                belegPosition.WshPositionID = ausgeglicheneSollstellung.WshPositionID;

                //KbuKonto wird von der ausgeglichenen Sollstellung.
                belegPosition.KbuKontoID = ausgeglicheneSollstellung.KbuKontoID;

                //BaPerson TODO: woher kommt BaPersonID der BelegPosition?
                belegPosition.BaPersonID = zahlungseingang.BaPersonID_Betrifft;

                //PositionImBeleg der Nicht-Hauptpositionen von 2 aufsteigend durchnummerieren (Hauptposition ist an position:1)
                belegPosition.PositionImBeleg = positionImBeleg++;

                //Text wird von der ausgeglichenen Sollstellung übernommen
                belegPosition.Text = ausgeglicheneSollstellung.Text;

                //Hauptposition ist false
                belegPosition.HauptPosition = false;

                //Einnahmen werden in den Belegpositionen im Haben gebucht
                belegPosition.SollHaben = "H";
                belegPosition.BetragBrutto = ausgeglicheneSollstellung.BetragAuszugleichen;

                //TODO: was für einen Wert bekommt BetragNetto?
                belegPosition.BetragNetto = 0;

                belegPositionService.SaveData(unitOfWork, belegPosition);
            }
        }

        /// <summary>
        /// Kreiert Belegpositionen zum Beleg.
        /// </summary>
        /// <param name="unitOfWork">Initialisiertes UnitOf Work, darf nicht null sein</param>
        /// <param name="beleg">Der Beleg</param>
        /// <param name="belege">Liste von Belegen</param>
        private void CreateBelegPositionen(IUnitOfWork unitOfWork, KbuBeleg beleg, List<WshAuszahlvorschlagBelegPositionDTO> belege)
        {
            int positionImBeleg = 1;
            foreach (var belegPositionDTO in belege)
            {
                //Positionen ohne Werte erstellen wir nicht.
                if (!(belegPositionDTO.Ausgabe.HasValue && belegPositionDTO.Ausgabe.Value != 0
                        || belegPositionDTO.Einnahme.HasValue && belegPositionDTO.Einnahme.Value != 0))
                {
                    continue;
                }

                bool ausgabe;
                decimal betrag;
                // Ausgaben gehen ins Soll und Einnahmen gehen ins Haben
                if (belegPositionDTO.Ausgabe.HasValue)
                {
                    ausgabe = true;
                    betrag = belegPositionDTO.Ausgabe.Value;
                }
                else
                {
                    ausgabe = false;
                    betrag = belegPositionDTO.Einnahme.Value;
                }

                CreateBelegPosition(unitOfWork, beleg, belegPositionDTO.WshPosition, positionImBeleg, ausgabe, betrag);

                positionImBeleg++;
            }
        }

        /// <summary>
        /// Erstellt einen Debitor zum Beleg.
        /// </summary>
        private void CreateDebitor(IUnitOfWork unitOfWork, KbuZahlungseingang zahlungseingang, int kbuBelegId)
        {
            KbuBelegDebitorService debitorService = Container.Resolve<KbuBelegDebitorService>();
            KbuBelegDebitor debitor;
            debitorService.NewData(out debitor);

            //BaInstitutionID oder BaPersonID setzen.
            if (zahlungseingang.BaInstitutionDebitor != null)
            {
                debitor.BaInstitution = zahlungseingang.BaInstitutionDebitor;
            }
            else if (zahlungseingang.BaPersonDebitor != null)
            {
                debitor.BaPerson = zahlungseingang.BaPersonDebitor;
            }

            //Belegid setzen.
            debitor.KbuBelegID = kbuBelegId;

            debitorService.SaveData(unitOfWork, debitor);
        }

        /// <summary>
        /// Erstellt einen Kreditor zum Beleg.
        /// </summary>
        /*
        private void CreateKreditor(IUnitOfWork unitOfWork, WshAuszahlvorschlagBelegDTO belegDTO, KbuBeleg kbuBeleg)
        {
            KbuBelegKreditorService kreditorService = Container.Resolve<KbuBelegKreditorService>();
            KbuBelegKreditor kreditor;
            kreditorService.NewData(out kreditor);

            //Zahlungsweg angeben.
            if (belegDTO.Kreditor.BaZahlungsweg != null)
            {
                kreditor.BaZahlungsweg = belegDTO.Kreditor.BaZahlungsweg;
            }

            //Belegid setzen.
            kreditor.KbuBeleg = kbuBeleg;

            kreditorService.SaveData(unitOfWork, kreditor);
        }*/

        /// <summary>
        /// Erstellt einen Kreditor zum Beleg.
        /// </summary>
        private void CreateKreditor(IUnitOfWork unitOfWork, int? baZahlungswegId, KbuBeleg kbuBeleg)
        {
            KbuBelegKreditorService kreditorService = Container.Resolve<KbuBelegKreditorService>();
            KbuBelegKreditor kreditor;
            kreditorService.NewData(out kreditor);

            //Zahlungsweg angeben.
            kreditor.BaZahlungswegID = baZahlungswegId;

            //Belegid setzen.
            kreditor.KbuBeleg = kbuBeleg;

            kreditorService.SaveData(unitOfWork, kreditor);
        }

        private void DeleteFreigegebenerBeleg(IUnitOfWork unitOfWork, int kbuBelegId)
        {
            var repositoryKbuBeleg = UnitOfWork.GetRepository<KbuBeleg>(unitOfWork);
            var repositoryKbuBelegPosition = UnitOfWork.GetRepository<KbuBelegPosition>(unitOfWork);
            var repositoryKbuBelegKreditor = UnitOfWork.GetRepository<KbuBelegKreditor>(unitOfWork);
            var beleg = repositoryKbuBeleg
                .Include(x => x.KbuBelegPosition)
                .Include(x => x.KbuBelegKreditor)
                .Where(x => x.KbuBelegID == kbuBelegId)
                .Single();

            if(beleg.KbuBelegstatusCode != (int) LOVsGenerated.KbuBelegstatus.Freigegeben)
            {
                throw new Exception("Nur freigegebene Belege können gelöscht werden.");
            }

            foreach (KbuBelegPosition pos in beleg.KbuBelegPosition.ToList())
            {
                pos.MarkAsDeleted();
                repositoryKbuBelegPosition.ApplyChanges(pos);
            }
            foreach (var belegKreditor in beleg.KbuBelegKreditor.ToList())
            {
                belegKreditor.MarkAsDeleted();
                repositoryKbuBelegKreditor.ApplyChanges(belegKreditor);
            }
            beleg.MarkAsDeleted();
            unitOfWork.SaveChanges();
        }

        private int GetKlärfallKonto(IUnitOfWork unitOfWork, KbuZahlungseingang zahlungseingang)
        {
            //In Abhängigkeit des Zahlstapel-Präfixes kann das Klärfall-Konto ermittelt werden
            //TODO: Klärfall-Konto in Abhängigkeit des Zahlstapel-Präfixes ermitteln
            return -1;
        }

        /// <summary>
        /// Hohlt das Kreditor-Konto. Von dem sollte es nur eins geben.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <returns></returns>
        private KbuKonto GetKreditorKonto(IUnitOfWork unitOfWork)
        {
            var repository = UnitOfWork.GetRepository<KbuKonto>(unitOfWork);
            return repository.Select(x => x).First();
        }

        /// <summary>
        /// Berechnet die Summe der Ausgabe.
        /// Ausgaben werden addiert, Einnahmen werden subtrahiert.
        /// </summary>
        /// <param name="beleg"></param>
        /// <returns></returns>
        private decimal SummeAusgabeBerechnen(KbuBeleg beleg)
        {
            decimal result = 0.0M;

            foreach (var belegPos in beleg.KbuBelegPosition)
            {
                if(belegPos.HauptPosition)
                {
                    continue;
                }
                if(belegPos.SollHaben == "S")
                {
                    result += belegPos.BetragBrutto;
                }
                else
                {
                    result -= belegPos.BetragNetto;
                }

            }

            return result;
        }

        /// <summary>
        /// Valdidiert die Daten, ob auch ein Beleg erstellt werden kann.
        /// Die Validierung wird im KissServiceResult abgelegt.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="zahlungseingang"></param>
        /// <param name="ausgeglicheneSollstellungen"></param>
        /// <param name="ignoreWarnings"></param>
        /// <param name="serviceResult"></param>
        /// <returns>Ein KissServiceResult mit den Validierungsfehlern</returns>
        private KissServiceResult ValidateBeleg(IUnitOfWork unitOfWork, KbuZahlungseingang zahlungseingang, List<KbuErwarteteEinnahmeDTO> ausgeglicheneSollstellungen, bool ignoreWarnings, KissServiceResult serviceResult)
        {
            //Mindestens eine Belegposition muss vorhanden sein.
            if (ausgeglicheneSollstellungen.Count == 0)
            {
                serviceResult += new KissServiceResult(KissServiceResult.ResultType.Error, "Mindestens eine ausgeglichene Sollstellung muss vorhanden sein.");
                return serviceResult;
            }

            //Betrag darf nicht null sein.
            //decimal betrag = 0;
            foreach (var ausgeglicheneSollstellung in ausgeglicheneSollstellungen)
            {
                if (ausgeglicheneSollstellung.BetragAuszugleichen == 0)
                {
                    serviceResult += new KissServiceResult(KissServiceResult.ResultType.Error, "Der Ausgleichsbetrag muss grösser als 0 sein.");
                    return serviceResult;
                }
            }

            if (zahlungseingang.BaInstitutionDebitor == null && zahlungseingang.BaPersonDebitor == null)
            {
                serviceResult += new KissServiceResult(KissServiceResult.ResultType.Error, "Es wurde kein Debitor ausgewählt.");
                return serviceResult;
            }

            return serviceResult;
        }

        /// <summary>
        /// Valdidiert die Daten, ob auch ein Beleg erstellt werden kann.
        /// Die Validierung wird im KissServiceResult abgelegt.
        /// </summary>
        /// <param name="belegDTO"></param>
        /// <param name="ignoreWarnings"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="serviceResult"></param>
        /// <returns>Ein KissServiceResult mit den Validierungsfehlern</returns>
        private KissServiceResult ValidateBeleg(IUnitOfWork unitOfWork, WshAuszahlvorschlagBelegDTO belegDTO, bool ignoreWarnings, KissServiceResult serviceResult)
        {
            //Mindestens eine Belegposition muss vorhanden sein.
            if (belegDTO.BelegPositionen.Count == 0)
            {
                serviceResult += new KissServiceResult(KissServiceResult.ResultType.Error, "Mindestens eine Belegposition muss vorhanden sein.");
                return serviceResult;
            }

            //Betrag darf nicht null sein.
            decimal betrag = 0;
            foreach (var belegPosition in belegDTO.BelegPositionen)
            {
                if (belegPosition.Ausgabe.HasValue)
                {
                    betrag += belegPosition.Ausgabe.Value;
                }
                if (belegPosition.Einnahme.HasValue)
                {
                    betrag -= belegPosition.Einnahme.Value;
                }
            }
            if (betrag == 0)
            {
                serviceResult += new KissServiceResult(KissServiceResult.ResultType.Error, "Der Auszahlbetrag muss grösser als 0 sein.");
                return serviceResult;
            }

            //Berechung Auszahlbetrag verifizieren.
            if (betrag != belegDTO.AuszahlbetragNetto)
            {
                serviceResult += new KissServiceResult(KissServiceResult.ResultType.Error, "Der Auszahlbetrag stimmt nicht mit der Summer der Belegpositionen überein.");
                return serviceResult;
            }

            //Prüfen, ob es zum ValutaDatum und zum Zahlungsweg bereits ein Beleg gibt.
            if (belegDTO.Kreditor.BaZahlungsweg != null && ignoreWarnings == false)
            {
                var repositoryBeleg = UnitOfWork.GetRepository<KbuBeleg>(unitOfWork);
                var queryBelegExists = from x in repositoryBeleg
                                       let firstKreditor = x.KbuBelegKreditor.FirstOrDefault()
                                       where x.ValutaDatum == belegDTO.Valuta
                                       where firstKreditor.BaZahlungswegID == belegDTO.Kreditor.BaZahlungsweg.BaZahlungswegID
                                       select new
                                       {
                                           x.ValutaDatum,
                                           Name =
                                           firstKreditor.BaZahlungsweg.BaPerson == null
                                               ? firstKreditor.BaZahlungsweg.BaInstitution == null ? ""
                                               //TODO BaInstitution Standard - ZH konsolidieren; InstitutionName <=> Name
                                                    : firstKreditor.BaZahlungsweg.BaInstitution.InstitutionName ?? firstKreditor.BaZahlungsweg.BaInstitution.Name
                                               : firstKreditor.BaZahlungsweg.BaPerson.Name + ", " + firstKreditor.BaZahlungsweg.BaPerson.Vorname
                                       };
                if (queryBelegExists.Count() > 0)
                {
                    var t = queryBelegExists.First();
                    var messageValuta = string.Format("Es existiert bereits ein Beleg mit Valutadatum {0}",
                                                      t.ValutaDatum.Value.ToShortDateString());
                    string messageEmpfaenger;
                    if (string.IsNullOrEmpty(t.Name))
                    {
                        messageEmpfaenger = "und dem gewählten Empfänger.";
                    }
                    else
                    {
                        messageEmpfaenger = string.Format("und Empfänger {0}", t.Name);
                    }

                    serviceResult += new KissServiceResult(
                        KissServiceResult.ResultType.Warning,
                        string.Format("{0} {1}", messageValuta, messageEmpfaenger));
                    return serviceResult;
                }
            }
            return serviceResult;
        }

        /// <summary>
        /// Überprüft, ob das Grundbudget für Dauerauftrag aktiviert werden darf.
        /// - Alle Grund-Budgetpositionen einer Leistung haben Auszahlungstermin 1 x Monatlich.
        /// - Alle Grund-Budgetpositionen einer Leistung haben Auszahlungsart Elektronisch.
        /// - Alle Grund-Budgetpositionen einer Leistung haben denselben Zahlungsweg.
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="faLeistungId"></param>
        /// <returns></returns>
        private KissServiceResult ValidateGrundbudgetForDauerauftrag(IUnitOfWork unitOfWork, int faLeistungId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repositoryGrundbudgePositionen = UnitOfWork.GetRepository<WshGrundbudgetPosition>(unitOfWork);
            var repositoryZahlungsweg = UnitOfWork.GetRepository<BaZahlungsweg>(unitOfWork);
            KissServiceResult result = KissServiceResult.Ok();
            int ausgabeCode = (int)LOVsGenerated.WshKategorie.Ausgabe;

            // 1xMonatlich
            int periodizitaetsCode1xMonatlich = (int)LOVsGenerated.WshPeriodizitaet._1xProMonat;
            var query = from x in repositoryGrundbudgePositionen
                        where x.WshPeriodizitaetCode != periodizitaetsCode1xMonatlich
                        where x.FaLeistungID == faLeistungId
                        where x.WshKategorieID == ausgabeCode
                        select x;
            if (query.Count() > 0)
            {
                result += new KissServiceResult(KissServiceResult.ResultType.Error, "Nicht alle Grundbudgetpositionen haben Termin 1x monatlich");
            }

            // Elektronisch
            int auszahlungArtCodeElektronisch = (int)LOVsGenerated.KbuAuszahlungArt.ElektronischeAuszahlung;
            query = from x in repositoryGrundbudgePositionen
                    where x.KbuAuszahlungArtCode != auszahlungArtCodeElektronisch
                    where x.FaLeistungID == faLeistungId
                    where x.WshKategorieID == ausgabeCode
                    select x;
            if (query.Count() > 0)
            {
                result += new KissServiceResult(KissServiceResult.ResultType.Error, "Nicht alle Grundbudgetpositionen haben Auszahlungsart elektronisch");
            }

            // Alle haben denselben Zahlungsweg.
            var queryZahlungsweg = from x in repositoryZahlungsweg
                                   where x.WshGrundbudgetPositionKreditor.Any(y => y.WshGrundbudgetPosition.FaLeistungID == faLeistungId)
                                   select x;
            int zahlungsWegCount = queryZahlungsweg.Count();
            if (zahlungsWegCount > 1)
            {
                result += new KissServiceResult(KissServiceResult.ResultType.Error, "Nicht alle Grundbudgetpositionen haben denselben Zahlungsweg");
            }

            // Zahlungseg ist null (sollte wegen Validierung auf dem Userinterface nicht möglich sein).
            if (zahlungsWegCount == 0)
            {
                result += new KissServiceResult(KissServiceResult.ResultType.Error, "Keine Ausgabe mit Zahlungsweg vorhanden.");
            }

            return result;
        }

        #endregion

        #endregion
    }
}